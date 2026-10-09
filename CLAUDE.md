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

```
GTA5.exe
 └─ dinput8.dll (ASI loader, Alexander Blade 2015)  -> loads every *.asi in root
     ├─ ScriptHookV.dll             native-call hook that all scripts depend on
     ├─ ScriptHookVDotNet.asi       SHVDN v2/v3 that loads .NET mods from scripts/*.dll and *.cs
     ├─ LUA.asi                     Lua runtime that runs scripts/main.lua
     ├─ OpenIV.asi                  redirects RPF reads to Mods/ (OpenIV "mods folder")
     ├─ Menyoo.asi                  trainer/spooner, data in menyooStuff/
     ├─ TrainerV.asi                trainer, configured by trainerv.ini (see KEYCODES.md)
     ├─ openCameraV.asi, NoEditorRestrictions.asi
     └─ limit adjusters: HeapAdjuster, PackfileLimitAdjuster, WeaponLimitsAdjuster,
        fwBoxStreamerVariable_DecalsLimit-Patch
```

### Key locations

| Path | What it is |
|---|---|
| `Mods/` | OpenIV mods folder holding modified copies of `common.rpf`, `x64a.rpf`, `update/update.rpf`, `update/update2.rpf`. **Edit RPFs here, never the originals in root or `update/`.** |
| `scripts/` | SHVDN mods (`*.dll` plus their `.ini`/`.xml` configs, loose `.cs` scripts such as `FoSAShelter.3.cs`) and the Lua mod (`main.lua`, `keys.lua`, `utils.lua`, `libs/`, `addins/`). |
| `scripts/addins/` | Lua addins that `main.lua` auto-loads. `exampleGUI.lua` is the GUI template (disabled by default, see README.md). |
| `scripts/libs/GUI.lua` | Lua menu rendering and keyboard/controller input. |
| `menyooStuff/` | Menyoo data: `Vehicle/*.xml`, `Outfit/*.xml`, `PedList.xml`, `AddedVehicleModels.xml`, `MapMods.xml`, `menyooConfig.ini`. |
| `trainerv.ini` + `KEYCODES.md` | TrainerV keybinds. KEYCODES.md maps virtual-key codes and GTA control IDs. |
| `scripts/BetterChasesConfig.xml`, `ImmersifyII.ini`, `Stance.ini`, `iFruitAddon2/config.ini` | Per-mod gameplay configs. |
| `x64*.rpf`, `common.rpf`, `update/` | Vanilla game archives (about 40 GB). Read-only for our purposes. |

### Installed SHVDN mods (scripts/)

Better Chases+, Cop_Arrest, Disarm, iFruitAddon2, ImmersifyII, MapEditor, Stance, FoSAShelter (.cs), plus the libraries LemonUI.SHVDN3, NativeUI and ClearScript.

## Logs (check these first when debugging)

Every launch rewrites these in the game root:

- `asiloader.log` shows which `.asi` files loaded.
- `ScriptHookV.log` shows the game version check and script registration.
- `ScriptHookVDotNet.log` shows each .NET script starting, plus exceptions and stack traces.
- `menyoolog.txt`, `OpenIV.log` (large), `NoEditorRestrictions.log`, `HeapAdjuster.log`, `iFruitAddon2.log`.

Logs are gitignored. Their timestamps show when the game last ran.

## Git

- Only text configs and scripts are tracked. `.gitignore` excludes `*.rpf`, `*.exe`, `*.dll`, RAGE assets (`*.ytd`, `*.ydr`, `*.yft`, `*.ymt`, ...), logs, and `/mods/`. It then whitelists `*.ini`, `*.lua`, `*.cs`, `*.json`, `*.xml`, `*.txt`, `*.md`.
- Some `.asi`/`.pdb` files are tracked (the binary patterns don't cover them). Don't add more large binaries.
- Commit messages follow the existing style: a short imperative summary such as "Add Ghost Rider vehicle and configuration files".
- Commit only when the user asks.

## Working rules

- **Back up before editing anything that isn't in git** (RPFs, DLLs, untracked files). Copy it to `<name>.bak`, or confirm it's tracked first. The `.orig` files (`bink2w64.dll.orig`, `steam_api64.dll.orig`, `PlayGTAV.exe.orig`) are originals. Never overwrite or delete them.
- **Never modify vanilla RPFs** in the root or `update/`. All archive edits go through `Mods/`.
- Don't touch the files that make the install run (`steam_api64.dll`, `steam_settings/`, `socialclub.dll`, `orig_socialclub.dll`, `launc.dll`, `PlayGTAV.exe`) unless the user explicitly asks.
- Claude can't open RPF archives directly. Binary RAGE formats (`.ytd`, `.yft`, `.ymt`, and so on) need OpenIV or CodeWalker on the user's side. Claude can still write or edit the XML/meta that goes into them (`vehicles.meta`, `carvariations.meta`, `handling.meta`, `dlclist.xml`, `content.xml`, `setup2.xml`).
- Add-on vehicle and ped workflow: the user installs the DLC pack into `Mods/update/x64/dlcpacks/<name>/` with OpenIV, adds `dlcpacks:/<name>/` to `dlclist.xml` inside `Mods/update/update.rpf`, then adds the model to `menyooStuff/AddedVehicleModels.xml` (and to `scripts/VehicleList.ini` / `PedList.ini` where relevant).
- Game updates usually break ScriptHookV until a matching release comes out. If the log shows a version error, tell the user to update ScriptHookV rather than trying to patch around it.
- Lua mod: `scripts/main.lua` does `dofile` on `keys.lua` and `utils.lua`, loads `libs/`, then runs addins. New features go in as a new file in `scripts/addins/`, following `basemodule.lua`.
- C# scripts: a loose `.cs` file in `scripts/` gets compiled by SHVDN at load time. Target SHVDN v3 (`using GTA;`, class extends `Script`). Use LemonUI for menus.
- Native function names follow the NativeDB naming (`PAD.IS_CONTROL_JUST_PRESSED`, `ENTITY.*`, `VEHICLE.*`). Check the native exists for this game build before using it.
- Keep keybinds from colliding across mods (TrainerV, Menyoo, Lua GUI, and each SHVDN mod's ini). Check the existing binds before assigning a new one, and record changes in KEYCODES.md or README.md.
- Single player only. Never suggest using mods in GTA Online, because doing so gets the account banned.
