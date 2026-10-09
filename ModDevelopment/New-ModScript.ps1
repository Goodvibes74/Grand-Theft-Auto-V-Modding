<#
.SYNOPSIS
    Creates a new ScriptHookVDotNet v3 script project in ModDevelopment and adds it to the solution.

.DESCRIPTION
    Creates ModDevelopment\<Name>\ with a project file, a starter script (a LemonUI menu opened by a key
    from scripts\<Name>.ini), a Visual Studio launch profile that starts the game with BattlEye off,
    and a README. Also creates scripts\<Name>.ini with no key assigned, so the new script can't clash
    with another mod until you pick a key (see docs\mods_info\HOTKEYS.md).

.EXAMPLE
    powershell -ExecutionPolicy Bypass -File ModDevelopment\New-ModScript.ps1 -Name SpeedCamera
#>
param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern('^[A-Z][A-Za-z0-9]*$')]
    [string]$Name
)

$ErrorActionPreference = 'Stop'

$devDir = $PSScriptRoot
$gameDir = Split-Path $devDir -Parent
$projectDir = Join-Path $devDir $Name
$iniPath = Join-Path $gameDir "scripts\$Name.ini"

if (Test-Path $projectDir) { throw "ModDevelopment\$Name already exists." }
if (Test-Path (Join-Path $gameDir "scripts\$Name.dll")) { throw "scripts\$Name.dll already exists. Pick another name." }

New-Item -ItemType Directory -Path (Join-Path $projectDir 'Properties') | Out-Null
$utf8 = New-Object System.Text.UTF8Encoding($false)

function Write-ProjectFile([string]$path, [string]$content) {
    [System.IO.File]::WriteAllText($path, $content.Replace("`r`n", "`n"), $utf8)
}

Write-ProjectFile (Join-Path $projectDir "$Name.csproj") @"
<Project Sdk="Microsoft.NET.Sdk">

  <!--
    $Name
    Shared settings (target framework, SHVDN and LemonUI references, copy into scripts\)
    come from ..\Directory.Build.props and ..\Directory.Build.targets.
  -->

</Project>
"@

Write-ProjectFile (Join-Path $projectDir "${Name}Script.cs") @"
using GTA;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;
using System;
using System.IO;
using System.Windows.Forms;

namespace $Name
{
	public class ${Name}Script : Script
	{
		private readonly ObjectPool pool = new ObjectPool();
		private readonly NativeMenu menu = new NativeMenu("$Name", "Main menu");

		private Keys menuKey = Keys.None;

		public ${Name}Script()
		{
			ScriptSettings settings = ScriptSettings.Load(Path.Combine(BaseDirectory, "$Name.ini"));
			if (Enum.TryParse(settings.GetValue("Keys", "MenuKey", "None"), true, out Keys key))
				menuKey = key;

			pool.Add(menu);

			NativeItem hello = new NativeItem("Say hello", "Shows a notification above the map.");
			hello.Activated += (sender, e) => Notification.PostTicker("Hello from $Name", false);
			menu.Add(hello);

			Tick += OnTick;
			KeyDown += OnKeyDown;
		}

		private void OnTick(object sender, EventArgs e)
		{
			pool.Process();
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (menuKey != Keys.None && e.KeyCode == menuKey)
				menu.Visible = !menu.Visible;
		}
	}
}
"@

$launch = [ordered]@{
    profiles = [ordered]@{
        'GTA V (BattlEye off)' = [ordered]@{
            commandName      = 'Executable'
            executablePath   = (Join-Path $gameDir 'PlayGTAV.exe')
            commandLineArgs  = '-nobattleye'
            workingDirectory = $gameDir
        }
    }
}
Write-ProjectFile (Join-Path $projectDir 'Properties\launchSettings.json') ($launch | ConvertTo-Json -Depth 5)

Write-ProjectFile (Join-Path $projectDir 'README.md') @"
# $Name

What this script does, and how to use it in game.

## Files

| File | What it is |
| --- | --- |
| ``ModDevelopment/$Name/${Name}Script.cs`` | The script. |
| ``scripts/$Name.ini`` | Settings. ``MenuKey`` opens the menu (no key by default). |
| ``scripts/$Name.dll``, ``scripts/$Name.pdb`` | Build output, copied there on every build. |

## Controls

| Action | Keyboard | Xbox | PlayStation |
| --- | --- | --- | --- |
| Open menu | (set ``MenuKey``) | none | none |

## Build

Open ``ModDevelopment/ModDevelopment.slnx`` in Visual Studio and build, or run
``dotnet build -c Release ModDevelopment/$Name/$Name.csproj`` from the game folder.

## When it's ready

Add it to ``scripts/ModGuide.xml``, ``docs/mods_info/MODS.md`` and ``docs/mods_info/HOTKEYS.md``.
"@

if (-not (Test-Path $iniPath)) {
    Write-ProjectFile $iniPath @"
; $Name settings. Edit with the game closed, or press F4 in game and type Reload().

[Keys]
; Key that opens the menu. A .NET Keys name (NumPad5, OemSemicolon, ...), or None for no key.
; F2 to F12 are taken by other mods. Check docs/mods_info/HOTKEYS.md before picking one.
MenuKey=None
"@
}

& dotnet sln (Join-Path $devDir 'ModDevelopment.slnx') add (Join-Path $projectDir "$Name.csproj")
if ($LASTEXITCODE -ne 0) { throw 'Adding the project to ModDevelopment.slnx failed.' }

Write-Host ""
Write-Host "Created ModDevelopment\$Name and scripts\$Name.ini."
Write-Host "Next: set MenuKey in scripts\$Name.ini, then build with:"
Write-Host "  dotnet build -c Release ModDevelopment\$Name\$Name.csproj"
