# Read-only list/extract for any archive, including Rockstar's encrypted ones, through the CodeWalker.Core library in
# 1cfcd8-CodeWalker30_dev46\. Lists every file (nested archives included) whose inner path matches -Pattern, and
# copies matching non-resource files to -ExtractTo. Never writes archives.
# Usage: powershell -NoProfile -ExecutionPolicy Bypass -File tools\rpf-cw.ps1 -Archive update\update.rpf -Pattern "common\data\mpstats*" [-ExtractTo <scratch folder>]
param([string]$Game = "D:\Games\Grand Theft Auto V Legacy", [Parameter(Mandatory = $true)][string]$Archive, [string]$Pattern = "*", [string]$ExtractTo)
$ErrorActionPreference = "Stop"
[void][Reflection.Assembly]::LoadFrom((Join-Path $Game "1cfcd8-CodeWalker30_dev46\CodeWalker30_dev46\CodeWalker.Core.dll"))
[CodeWalker.GameFiles.GTA5Keys]::LoadFromPath($Game, $null)
$rpf = New-Object CodeWalker.GameFiles.RpfFile((Join-Path $Game $Archive), $Archive)
$rpf.ScanStructure($null, $null)
$stack = New-Object System.Collections.Stack; $stack.Push($rpf)
while ($stack.Count -gt 0) {
    $f = $stack.Pop()
    if ($f.Children) { foreach ($c in $f.Children) { $stack.Push($c) } }
    foreach ($e in $f.AllEntries) {
        if (-not ($e -is [CodeWalker.GameFiles.RpfFileEntry])) { continue }
        $inner = $e.Path.Substring($Archive.Length).TrimStart('\')
        if ($inner -notlike $Pattern) { continue }
        Write-Output ("{0,10} {1}" -f $e.FileSize, $inner)
        if ($ExtractTo -and -not ($e -is [CodeWalker.GameFiles.RpfResourceFileEntry])) {
            $b = $f.ExtractFile($e)
            $dest = Join-Path $ExtractTo ($inner -replace '[\\/:]', '_')
            New-Item -ItemType Directory -Force $ExtractTo | Out-Null
            [IO.File]::WriteAllBytes($dest, $b)
        }
    }
}
