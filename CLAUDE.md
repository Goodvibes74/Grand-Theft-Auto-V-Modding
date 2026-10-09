# CLAUDE.md

This directory is a modded **GTA V Legacy** (Enhanced is a different build) install, tracked in git so mod configs and scripts can be versioned. Claude's role here:

1. **Explore** the game files and installed mods: work out what is installed, how it loads, and what each config does.
2. **Maintain** mods: fix broken configs, resolve conflicts, keep things working after game or ScriptHook updates.
3. **Improve and create**: tune configs, write new Lua/C# scripts, add Menyoo vehicles/outfits/maps, and take on other ideas the user brings.

## Environment

- Game version: `GTA5.exe` 1.0.3725.0 (ScriptHookV reports `VER_1_0_3717_0`). Check `ScriptHookV.log` after any game update. A version mismatch is the usual reason every script stops loading.
- Launch: `PlayGTAV.bat` runs `PlayGTAV.exe -nobattleye`. BattlEye must stay disabled, because modded single player does not work with it.
- Platform: Windows 11. Paths contain spaces, so always quote `"D:\Games\Grand Theft Auto V Legacy"`.
- Claude cannot run the game or see it. To test a change, the user launches the game and reports back, or Claude reads the logs written by the last session (see "Logs" below).

## How mods load

```text
GTA5.exe
 └─ dinput8.dll (ASI loader, Alexander Blade 2015)  -> loads every *.asi in root
     ├─ ScriptHookV.dll             native-call hook that all scripts depend on
     ├─ ScriptHookVDotNet.asi       SHVDN v2/v3 that loads .NET mods from scripts/*.dll and *.cs
     ├─ LUA.asi                     Lua runtime that runs scripts/main.lua
     ├─ OpenIV.asi                  redirects RPF reads to Mods/ (OpenIV "mods folder")
     ├─ Menyoo.asi                  trainer/spooner, data in menyooStuff/
     ├─ TrainerV.asi                trainer, configured by trainerv.ini (see docs/mods_info/KEYCODES.md)
     ├─ openCameraV.asi, NoEditorRestrictions.asi
     └─ limit adjusters: HeapAdjuster, PackfileLimitAdjuster, WeaponLimitsAdjuster,
        fwBoxStreamerVariable_DecalsLimit-Patch
```

### Key locations

| Path | What it is |
| --- | --- |
| `Mods/` | OpenIV mods folder holding modified copies of `common.rpf`, `x64a.rpf`, `update/update.rpf`, `update/update2.rpf`, plus add-on packs in `update/x64/dlcpacks/`. **Edit RPFs here, never the originals in root or `update/`.** |
| `Mods/MANIFEST.md` | Size and SHA-256 of every file in `Mods/`. This is how RPF changes get tracked, since the RPFs themselves stay out of git. |
| `tools/update-mods-manifest.sh` | Regenerates `Mods/MANIFEST.md` (`bash tools/update-mods-manifest.sh`, about 20 seconds). |
| `ModDevelopment/` | Source for our own mods: SHVDN C# scripts (solution `ModDevelopment.slnx`) and C++ `.asi` mods (solution `ModDevelopment.Cpp.slnx`, headers in `cpp/ShvSdk/`). See `ModDevelopment/README.md`. |
| `ModDevelopment/docs/` | Modding guides (C#, C++, Lua, natives) and a generated reference of every callable API: SHVDN v2/v3, LemonUI, NativeUI, iFruitAddon2, all natives, Lua natives. Check it before using an API member or native. Regenerate with `dotnet run -c Release --project ModDevelopment/tools/ApiDocGen` after updating any library. |
| `tools/rpf.ps1` | Read-only RPF viewer: `list` and `extract` for unencrypted archives and files (add-on packs, files replaced in `Mods/`). See `docs/mods_info/RPF_TOOLS.md`. |
| `MOD_TRACKING.md` | What to track and what never to track, plus a checklist for each modding session. |
| `scripts/` | SHVDN mods (`*.dll` plus their `.ini`/`.xml` configs, loose `.cs` scripts such as `FoSAShelter.3.cs`) and the Lua mod (`main.lua`, `keys.lua`, `utils.lua`, `libs/`, `addins/`). |
| `scripts/addins/` | Lua addins that `main.lua` auto-loads. `exampleGUI.lua` is the GUI template (disabled by default, see docs/mods_info/LUA_MENU.md). |
| `scripts/libs/GUI.lua` | Lua menu rendering and keyboard/controller input. |
| `menyooStuff/` | Menyoo data: `Vehicle/*.xml`, `Outfit/*.xml`, `PedList.xml`, `AddedVehicleModels.xml`, `MapMods.xml`, `menyooConfig.ini`. |
| `trainerv.ini` + `docs/mods_info/KEYCODES.md` | TrainerV keybinds. KEYCODES.md maps virtual-key codes and GTA control IDs. |
| `scripts/BetterChasesConfig.xml`, `ImmersifyII.ini`, `Stance.ini`, `iFruitAddon2/config.ini` | Per-mod gameplay configs. |
| `x64*.rpf`, `common.rpf`, `update/` | Vanilla game archives (about 40 GB). Read-only for our purposes. |

### Installed SHVDN mods (scripts/)

Better Chases+, Cop_Arrest, Disarm, iFruitAddon2, ImmersifyII, MapEditor, Stance, FoSAShelter (.cs), ModGuide (built from `ModDevelopment/ModGuide/`), plus the libraries LemonUI.SHVDN3, NativeUI and ClearScript.

### Installed add-on DLC packs (Mods/update/x64/dlcpacks/)

`forest_n` and `forest_s` (map), `gxetron` and `urus2018` (vehicles), `vremastered` (map and world visuals, no vehicles inside). Add-on vehicle model names: `gxetron`, `urus2018`.

### Identified non-vanilla files

`xinput1_4.dll` in the root is the "GTA V ENHANCED Asi loader" (from its version info; its strings name `GTA5_Enhanced.exe`). It's built for the Enhanced edition and is inactive here: `asiloader.log` only shows the Legacy loader (`dinput8.dll`). It's a leftover and harmless, but don't delete it without asking. Every binary in the install is listed in `ModDevelopment/docs/reference/Installed-Files.md`.

Four SHVDN mods (Cop_Arrest, Disarm, MapEditor, Stance) reference the pre-2.10 API name `ScriptHookVDotNet` 0.0.0.0. SHVDN redirects them to the deprecated v2 API (see `ScriptHookVDotNet.log`). If a future SHVDN update drops v2, these four break first.

## Logs (check these first when debugging)

Every launch rewrites these in the game root:

- `asiloader.log` shows which `.asi` files loaded.
- `ScriptHookV.log` shows the game version check and script registration.
- `ScriptHookVDotNet.log` shows each .NET script starting, plus exceptions and stack traces.
- `menyoolog.txt`, `OpenIV.log` (large), `NoEditorRestrictions.log`, `HeapAdjuster.log`, `iFruitAddon2.log`.

Logs are gitignored. Their timestamps show when the game last ran.

## Git

- `MOD_TRACKING.md` is the source of truth for what gets tracked. Keep it up to date when the mod setup changes.
- `.gitignore` excludes `*.rpf`, `*.exe`, `*.dll`, RAGE assets (`*.ytd`, `*.ydr`, `*.yft`, `*.ymt`, ...) and logs, then whitelists `*.ini`, `*.lua`, `*.cs`, `*.json`, `*.xml`, `*.txt`, `*.md`.
- Mod binaries are tracked through explicit `!` entries at the bottom of `.gitignore`: `scripts/*.dll`, `ScriptHookV.dll`, `ScriptHookVDotNet2.dll`, `ScriptHookVDotNet3.dll`, `dinput8.dll`, `xinput1_4.dll` and `menyooStuff/*.mp3`. When a new mod adds a binary somewhere else, add a `!` line for it there. `.asi` and `.pdb` files are tracked because no ignore pattern covers them.
- Never commit RPFs or game files. After any change in `Mods/`, run `bash tools/update-mods-manifest.sh` and commit the updated `Mods/MANIFEST.md`.
- `.gitattributes` keeps `*.sh` files on LF line endings and marks `dll`/`asi`/`mp3`/`png` as binary.
- Python is not installed. Use bash or PowerShell for scripts.
- Commit messages follow the existing style: a short imperative summary such as "Add Ghost Rider vehicle and configuration files".
- Commit only when the user asks.

## Working rules

- **Back up before editing anything that isn't in git** (RPFs, DLLs, untracked files). Copy it to `<name>.bak`, or confirm it's tracked first. The `.orig` files (`bink2w64.dll.orig`, `steam_api64.dll.orig`, `PlayGTAV.exe.orig`) are originals. Never overwrite or delete them.
- **Never modify vanilla RPFs** in the root or `update/`. All archive edits go through `Mods/`.
- Don't touch the files that make the install run (`steam_api64.dll`, `steam_settings/`, `socialclub.dll`, `orig_socialclub.dll`, `launc.dll`, `PlayGTAV.exe`) unless the user explicitly asks.
- Read RPF contents with `powershell -NoProfile -ExecutionPolicy Bypass -File tools/rpf.ps1 list|extract <archive> [pattern] -Out <scratchpad dir>`. It reads add-on packs and files replaced in `Mods/`. Rockstar's own files are encrypted one by one, so for vanilla files ask the user to export them with CodeWalker (`docs/mods_info/RPF_TOOLS.md`). The tool never writes archives. Binary RAGE formats (`.ytd`, `.yft`, `.ymt`, and so on) need OpenIV or CodeWalker on the user's side. Claude can still write or edit the XML/meta that goes into them (`vehicles.meta`, `carvariations.meta`, `handling.meta`, `dlclist.xml`, `content.xml`, `setup2.xml`).
- Add-on vehicle and ped workflow: the user installs the DLC pack into `Mods/update/x64/dlcpacks/<name>/` with OpenIV, adds `dlcpacks:/<name>/` to `dlclist.xml` inside `Mods/update/update.rpf`, then adds the model to `menyooStuff/AddedVehicleModels.xml` (and to `scripts/VehicleList.ini` / `PedList.ini` where relevant). Finish by regenerating the manifest and updating the DLC pack list above.
- Game updates usually break ScriptHookV until a matching release comes out. If the log shows a version error, tell the user to update ScriptHookV rather than trying to patch around it.
- Lua mod: `scripts/main.lua` does `dofile` on `keys.lua` and `utils.lua`, loads `libs/`, then runs addins. New features go in as a new file in `scripts/addins/`, following `basemodule.lua`.
- C# scripts: a loose `.cs` file in `scripts/` gets compiled by SHVDN at load time. Target SHVDN v3 (`using GTA;`, class extends `Script`). Use LemonUI for menus.
- Compiled C# scripts live in `ModDevelopment/<Name>/` (Visual Studio 2026 solution `ModDevelopment/ModDevelopment.slnx`). `Directory.Build.props` there sets `net48` and references `ScriptHookVDotNet3.dll` and `scripts/LemonUI.SHVDN3.dll` (not copied); `Directory.Build.targets` copies the DLL and PDB into `scripts/` after each build. Create a new script with `powershell -ExecutionPolicy Bypass -File ModDevelopment/New-ModScript.ps1 -Name <Name>`, and build with `dotnet build -c Release ModDevelopment/ModDevelopment.slnx` (game must be closed). Full workflow: `ModDevelopment/README.md`. Never put project sources under `scripts/`, because SHVDN would try to compile the `.cs` files.
- Native function names follow the NativeDB naming (`PAD.IS_CONTROL_JUST_PRESSED`, `ENTITY.*`, `VEHICLE.*`). Check the native exists for this game build before using it.
- Keep keybinds from colliding across mods (TrainerV, Menyoo, Lua GUI, and each SHVDN mod's ini). Check the existing binds before assigning a new one. Every function key F2 to F12 is taken (MapEditor moved to F2 and the Mod Guide took F12 on 2026-10-09). The Mod Guide (`scripts/ModGuide.xml`) lists every mod and its controls in game: update it whenever a mod or keybind changes. F3 is the TrainerV menu; Menyoo FreeCam was moved to F6 to avoid clashing with it.
- `docs/mods_info/` holds every doc about using the mods: `MODS.md` (each mod, how to activate it, keyboard and Xbox/PlayStation binds), `SETTINGS.md` (how to edit each mod's config), `HOTKEYS.md` (conflicts and keybind rules), `KEYCODES.md` and `LUA_MENU.md`. Update `SETTINGS.md` when a mod's config file or options change. Put new usage docs there, and record keybind changes in `MODS.md` and `HOTKEYS.md`.
- Single player only. Never suggest using mods in GTA Online, because doing so gets the account banned.
