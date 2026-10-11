# Switches between mod sets before launching the game, to save memory and CPU on a low-end PC.
#   online-lite : for CruelMasters Online Offline with police mods kept. SixStarResponse, SSRPlus and Better
#                 Chases+ stay on with lighter settings (fewer units, no ambient backup, less logging, no traffic
#                 management or warrant spotting). Cop_Arrest and HomeInvasion are turned off.
#   online      : for CruelMasters Online Offline on the lightest setup. Also turns off SixStarResponse and its
#                 RDE plugin, SSRPlus and Better Chases+.
#   story       : everything on with the normal settings (the normal install).
#   status      : shows which mods are on or off and which settings are active.
# Mods are turned off by renaming to "<name>.disabled". Settings are changed in place after saving the original as
# "<name>.story"; "story" puts the originals back. The game must be closed.
# Switch back to "story" before committing: git sees disabled mods and lite settings as changes.
# Usage: powershell -NoProfile -ExecutionPolicy Bypass -File tools\mod-profile.ps1 online-lite|online|story|status
param([Parameter(Mandatory = $true)][ValidateSet("online-lite", "online", "story", "status")][string]$Profile)
$ErrorActionPreference = "Stop"
$game = Split-Path $PSScriptRoot -Parent

# Files each profile turns off. Paths are relative to the game folder.
$liteOff = @("scripts\Cop_Arrest.dll", "scripts\HomeInvasion.dll")
$onlineOff = $liteOff + @("scripts\SixStarResponse.dll", "scripts\SSRPlus.dll", "scripts\Better Chases+.dll", "RDE_Auxiliary.asi")

# Lighter settings for "online-lite": file, a regex for the setting, and its replacement.
$liteSettings = @(
    @{ File = "scripts\SixStarResponse\SixStarResponse.ini"; Edits = @(
        # Fewer police units per wanted level (normal: 2, 3, 5, 7, 10, 15, 17, 18, 19, 20).
        @("(?m)^MaxResponse_1Star=\d+", "MaxResponse_1Star=1"),
        @("(?m)^MaxResponse_2Star=\d+", "MaxResponse_2Star=2"),
        @("(?m)^MaxResponse_3Star=\d+", "MaxResponse_3Star=3"),
        @("(?m)^MaxResponse_4Star=\d+", "MaxResponse_4Star=4"),
        @("(?m)^MaxResponse_5Star=\d+", "MaxResponse_5Star=6"),
        @("(?m)^MaxResponse_6Star=\d+", "MaxResponse_6Star=8"),
        @("(?m)^MaxResponse_7Star=\d+", "MaxResponse_7Star=9"),
        @("(?m)^MaxResponse_8Star=\d+", "MaxResponse_8Star=10"),
        @("(?m)^MaxResponse_9Star=\d+", "MaxResponse_9Star=10"),
        @("(?m)^MaxResponse_10Star=\d+", "MaxResponse_10Star=10"),
        # No police spawned for fights between NPCs (it could add up to 50 cops on its own).
        @("(?m)^AmbientBackup=\d", "AmbientBackup=0"),
        # Units behind the player can be removed sooner.
        @("(?m)^DespawnImmunityTime=\d+", "DespawnImmunityTime=10"),
        # Log warnings only instead of every event (constant disk writes).
        @("(?m)^LogToFileLevel=\w+", "LogToFileLevel=WARN")
    ) },
    @{ File = "scripts\SSRPlus.ini"; Edits = @(
        @("(?m)^CopAdditionalSpeech=\w+", "CopAdditionalSpeech=false"),
        @("(?m)^ManageSearchlights=\w+", "ManageSearchlights=false")
    ) },
    @{ File = "scripts\BetterChasesConfig.xml"; Edits = @(
        # Cops no longer clear and steer traffic during chases.
        @("<CopsManageTraffic>true</CopsManageTraffic>", "<CopsManageTraffic>false</CopsManageTraffic>"),
        # Arrest warrants (constant "were you spotted" checks) off.
        @("(?s)(<ArrestWarrants>.*?)<Enabled>true</Enabled>", '${1}<Enabled>false</Enabled>')
    ) }
)

if ($Profile -ne "status" -and (Get-Process GTA5, PlayGTAV -ErrorAction SilentlyContinue)) {
    Write-Host "Close the game first." -ForegroundColor Red
    exit 1
}

function Get-State([string]$rel) {
    $on = Join-Path $game $rel
    if (Test-Path -LiteralPath $on) { return "on" }
    if (Test-Path -LiteralPath "$on.disabled") { return "off" }
    return "missing"
}

function Set-ModState([string]$rel, [bool]$wantOn) {
    $on = Join-Path $game $rel
    $off = "$on.disabled"
    $state = Get-State $rel
    if (-not $wantOn -and $state -eq "on") { Rename-Item -LiteralPath $on -NewName (Split-Path $off -Leaf); $state = "off" }
    elseif ($wantOn -and $state -eq "off") { Rename-Item -LiteralPath $off -NewName (Split-Path $on -Leaf); $state = "on" }
    $color = @{ on = "Green"; off = "Yellow"; missing = "Red" }[$state]
    Write-Host ("{0,-8} {1}" -f $state, $rel) -ForegroundColor $color
}

function Set-Settings([bool]$lite) {
    foreach ($s in $liteSettings) {
        $path = Join-Path $game $s.File
        $backup = "$path.story"
        if (-not (Test-Path -LiteralPath $path)) { Write-Host ("missing  {0}" -f $s.File) -ForegroundColor Red; continue }
        if ($lite) {
            if (-not (Test-Path -LiteralPath $backup)) { Copy-Item -LiteralPath $path -Destination $backup }
            $text = [IO.File]::ReadAllText($backup)
            foreach ($e in $s.Edits) { $text = [regex]::Replace($text, $e[0], $e[1]) }
            [IO.File]::WriteAllText($path, $text)
            Write-Host ("lite     {0}" -f $s.File) -ForegroundColor Cyan
        }
        elseif (Test-Path -LiteralPath $backup) {
            Move-Item -LiteralPath $backup -Destination $path -Force
            Write-Host ("normal   {0}" -f $s.File) -ForegroundColor Green
        }
        elseif ($Profile -ne "status") {
            Write-Host ("normal   {0}" -f $s.File) -ForegroundColor Green
        }
    }
}

if ($Profile -eq "status") {
    foreach ($rel in $onlineOff) {
        $state = Get-State $rel
        Write-Host ("{0,-8} {1}" -f $state, $rel) -ForegroundColor (@{ on = "Green"; off = "Yellow"; missing = "Red" }[$state])
    }
    foreach ($s in $liteSettings) {
        $isLite = Test-Path -LiteralPath ((Join-Path $game $s.File) + ".story")
        Write-Host ("{0,-8} {1}" -f $(if ($isLite) { "lite" } else { "normal" }), $s.File) -ForegroundColor $(if ($isLite) { "Cyan" } else { "Green" })
    }
    exit 0
}

foreach ($rel in $onlineOff) {
    $wantOn = switch ($Profile) { "story" { $true } "online" { $false } "online-lite" { $liteOff -notcontains $rel } }
    Set-ModState $rel $wantOn
}
Set-Settings ($Profile -eq "online-lite")

switch ($Profile) {
    "online-lite" { Write-Host "`nOnline-lite profile active: police mods on with lighter settings. Run 'story' to restore (do that before committing)." }
    "online" { Write-Host "`nOnline profile active: police mods off. Run 'story' to restore (do that before committing)." }
    "story" { Write-Host "`nStory profile active: all mods on with normal settings." }
}
