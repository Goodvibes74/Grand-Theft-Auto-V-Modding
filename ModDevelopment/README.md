# ModDevelopment

Source code for the scripts we write ourselves. Each folder here is one ScriptHookVDotNet v3 script (C#, .NET Framework 4.8). Building a project copies its DLL into the game's `scripts/` folder, where SHVDN loads it.

| Project | What it is | Docs |
| --- | --- | --- |
| `ModGuide` | In-game list of every installed mod and its controls (F12, or RB + D-pad Down). | [`ModGuide/README.md`](ModGuide/README.md) |

## What's in this folder

| File | What it does |
| --- | --- |
| `ModDevelopment.slnx` | The Visual Studio 2026 solution. Open this. |
| `Directory.Build.props` | Settings every project shares: .NET Framework 4.8, latest C#, and references to `ScriptHookVDotNet3.dll` and `LemonUI.SHVDN3.dll` from the game folder. Visual Studio applies it to every project automatically. |
| `Directory.Build.targets` | Copies each project's `.dll` and `.pdb` into `scripts/` after every build. |
| `.editorconfig` | Code style: tabs in C#, braces on their own line. Visual Studio formats to it. |
| `New-ModScript.ps1` | Creates a new script project from a starter template and adds it to the solution. |
| `<Project>/Properties/launchSettings.json` | Lets Visual Studio start the game with BattlEye off. |

Because of the two `Directory.Build` files, a project's `.csproj` only lists what's special about it. `ModGuide.csproj` adds just `System.Xml.Linq`.

## Requirements

All of these are installed on this PC:

- Visual Studio Community 2026 with the **.NET desktop development** workload (or Build Tools 2026 for command-line builds).
- .NET Framework 4.8 targeting pack.
- .NET SDK 10.

## Open and build in Visual Studio

1. Open `ModDevelopment\ModDevelopment.slnx`.
2. Pick **Release** in the toolbar (Debug works too).
3. **Close the game**, then use **Build > Build Solution** (Ctrl+Shift+B). Windows locks a DLL the game has loaded, so the copy into `scripts/` fails while the game runs.
4. The Output window shows `<Name> copied to ...\scripts\` for each project.

From a terminal in the game folder, the same build is:

```bash
dotnet build -c Release ModDevelopment/ModDevelopment.slnx
```

## Run and debug

- **Start the game from Visual Studio:** choose the project as the startup project (right-click it, **Set as Startup Project**), then press **Ctrl+F5** (Start Without Debugging). It builds, copies, and launches `PlayGTAV.exe -nobattleye`, the same as `PlayGTAV.bat`. Always keep `-nobattleye`: mods don't work with BattlEye.
- **Debug with breakpoints:** F5 only attaches to the launcher, not the game. Instead, once you're in story mode, use **Debug > Attach to Process**, set "Attach to" to **Managed (.NET Framework 4.x) code**, and choose `GTA5.exe`. Breakpoints then work, because the `.pdb` is copied next to the DLL. Pausing on a breakpoint freezes the game, so alt-tab out first.
- **Reload without restarting the game:** this doesn't work for a rebuilt DLL, because the game locks it. Close the game, build, and launch again. Settings files (`.ini`, `.xml`) can be reloaded with F4, then `Reload()`.
- **Errors:** SHVDN writes load errors and exceptions to `ScriptHookVDotNet.log` in the game folder, and shows them in the F4 console.

## Add a new script

From the game folder:

```powershell
powershell -ExecutionPolicy Bypass -File ModDevelopment\New-ModScript.ps1 -Name SpeedCamera
```

The name must start with a capital letter and use only letters and digits. The script creates:

- `ModDevelopment/SpeedCamera/SpeedCamera.csproj`, added to the solution.
- `ModDevelopment/SpeedCamera/SpeedCameraScript.cs`, a working starter: a LemonUI menu with one item, opened by the key in its ini.
- `ModDevelopment/SpeedCamera/Properties/launchSettings.json`, so Ctrl+F5 starts the game.
- `ModDevelopment/SpeedCamera/README.md`, to fill in.
- `scripts/SpeedCamera.ini` with `MenuKey=None`, so the new script can't clash with another mod until you choose a key.

If Visual Studio is open, it notices the solution changed and offers to reload it.

Then:

1. Choose a key. Check `docs/mods_info/HOTKEYS.md` first: F2 to F12 are taken, and RB already starts five controller combos. Set it in `scripts/SpeedCamera.ini`.
2. Write the script, build, and test in game.
3. When it works, add it to `scripts/ModGuide.xml` (so it shows in the in-game guide), `docs/mods_info/MODS.md` and `docs/mods_info/HOTKEYS.md`, and fill in its README.

## Rules

- **Keep source code here, never in `scripts/`.** SHVDN compiles every loose `.cs` file in `scripts/`, so source files there would load a second copy of the script, or fail to compile.
- **Target SHVDN v3:** `using GTA;`, the class extends `Script`. Use LemonUI (`LemonUI.Menus`) for menus.
- **Read settings from `scripts/<Name>.ini`** with `ScriptSettings.Load(Path.Combine(BaseDirectory, "<Name>.ini"))`, so keys can change without a rebuild.
- **Don't reference other DLLs from the game folder** unless they're already in `scripts/`. Anything else has to be copied there too.
- **Single player only.** Never test these scripts in GTA Online: the account gets banned.

## Committing

Commit the project folder (`.cs`, `.csproj`, `Properties/launchSettings.json`, `README.md`), the solution and shared files, the script's `scripts/<Name>.ini` and other settings files, and the built `scripts/<Name>.dll` and `.pdb`, so the game works straight from a checkout. `bin/`, `obj/`, `.vs/` and `*.user` are gitignored.
