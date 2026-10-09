# What to Track When Modding GTA V

This is a checklist of the files to keep under version control, and the ones to keep out, whenever you add, remove or change a mod.

It is based on a full scan of the install on 2026-10-09.

---

## 1. Already tracked (keep it this way)

These are already in git through the whitelist in `.gitignore` (`*.ini`, `*.lua`, `*.cs`, `*.xml`, `*.json`, `*.txt`, `*.md`).

| What | Where | Why it matters |
| --- | --- | --- |
| Mod configs | `*.ini`, `*.toml` in root (`HeapAdjuster.ini`, `PackfileLimitAdjuster.ini`, `WeaponLimitsAdjuster.ini`, `NoEditorRestrictions.ini`, `ScriptHookVDotNet.ini`, `fwBoxStreamerVariable_DecalsLimit-Patch.toml`) | Limits and behaviour tweaks. A bad value here causes crashes. |
| Trainer keybinds | `trainerv.ini`, `docs/mods_info/KEYCODES.md` | Keybind changes and conflicts between mods. |
| SHVDN mod configs | `scripts/*.ini`, `scripts/*.xml` (`BetterChasesConfig.xml`, `ImmersifyII.ini`, `ImmersifyIIData.xml`, `Stance.ini`, `VehicleList.ini`, `PedList.ini`, `ObjectList.ini`, `iFruitAddon2/config.ini`, `MapEditor/*.xml`) | Gameplay tuning. |
| Script source | `scripts/*.lua`, `scripts/libs/`, `scripts/addins/`, `scripts/*.cs` | Your own code. |
| Menyoo data | `menyooStuff/` (`menyooConfig.ini`, `AddedVehicleModels.xml`, `Vehicle/*.xml`, `Outfit/*.xml`, `PedList.xml`, `MapMods.xml`) | Saved vehicles, outfits, spooner maps, and the list of add-on models. |
| ASI plugins | `*.asi` in root | Which plugins are installed, and their versions. |
| Docs | `README.md` (main mod management guide), `docs/mods_info/` (how to use the mods), `CLAUDE.md`, this file | |

---

## 2. Added to tracking on 2026-10-09

The scan found these. They used to be ignored because `.gitignore` blocked `*.dll`, `*.mp3` and `/mods/`. They are now whitelisted at the bottom of `.gitignore`. Add any new mod binary there the same way.

### a) SHVDN mod DLLs in `scripts/` (about 7.5 MB in total)

Tracking these shows which version of each mod is installed and when it changed. They are also the only copy of some old mods that are hard to find again.

```text
scripts/Better Chases+.dll      scripts/LemonUI.SHVDN3.dll
scripts/ClearScript.dll         scripts/MapEditor.dll
scripts/Cop_Arrest.dll          scripts/NativeUI.dll
scripts/Disarm.dll              scripts/Stance.dll
scripts/iFruitAddon2.dll        scripts/ImmersifyII.dll
```

### b) The script hook layer in the root (about 4 MB)

Game updates break these, so their version history matters.

```text
ScriptHookV.dll            # Alexander Blade, must match the game build
ScriptHookVDotNet2.dll     # SHVDN v2 runtime
ScriptHookVDotNet3.dll     # SHVDN v3 runtime
dinput8.dll                # ASI loader that loads every .asi
xinput1_4.dll              # non-vanilla (dated 2025-03-22), probably a controller mod. Confirm what it is.
```

### c) The OpenIV `Mods/` folder (2.7 GB, 9 RPF files)

**Do not commit these to git.** They are too big, and every edit rewrites the whole archive. Track the **manifest** instead: `Mods/MANIFEST.md` lists each RPF with its size and SHA-256 hash, so any change shows up as a diff. Regenerate it with `bash tools/update-mods-manifest.sh` (about 20 seconds).

```text
Mods/common.rpf
Mods/x64a.rpf
Mods/update/update.rpf                       # holds dlclist.xml, handling, meta edits
Mods/update/update2.rpf
Mods/update/x64/dlcpacks/forest_n/dlc.rpf    # add-on map
Mods/update/x64/dlcpacks/forest_s/dlc.rpf    # add-on map
Mods/update/x64/dlcpacks/gxetron/dlc.rpf     # add-on vehicle
Mods/update/x64/dlcpacks/urus2018/dlc.rpf    # add-on vehicle (Lamborghini Urus)
Mods/update/x64/dlcpacks/vremastered/dlc.rpf # graphics/vehicle pack
```

Also worth tracking as plain text: anything you extract from these RPFs with OpenIV and edit, such as `dlclist.xml`, `handling.meta`, `vehicles.meta`, `carvariations.meta` and `gameconfig.xml`. Keep copies in a `Mods/_meta/` folder so the edits are visible in git.

### d) Small mod assets

```text
menyooStuff/JumpAroundMode.mp3   # Menyoo asset, ignored by *.mp3
```

---

## 3. Never track

| What | Why |
| --- | --- |
| `x64*.rpf`, `common.rpf`, `update/`, `x64/` in root | Vanilla game data (about 40 GB). It never changes, and the modded copies live in `Mods/`. |
| `GTA5.exe`, `PlayGTAV.exe`, launchers, `GTA5_BE.exe` | Game binaries. |
| `steam_api64.dll`, `socialclub.dll`, `orig_socialclub.dll`, `launc.dll`, `steam_settings/` (partly tracked) | Install-specific files that make the game run. They are not mods. |
| NVIDIA/DirectX/codec DLLs (`GFSDK_*`, `NvPmApi*`, `GPUPerfAPI*`, `d3dcompiler_46`, `bink2w64`, `opus*`, `libcurl`, `XCurl`, `zlib1`, `fvad`, `libtox`) | Shipped with the game. |
| `BattlEye/*.dll`, `*.exe` | Anti-cheat. It stays disabled. |
| `*.log` (`asiloader.log`, `ScriptHookV.log`, `ScriptHookVDotNet.log`, `OpenIV.log`, ...) | Rewritten on every launch. Read them for debugging, but don't version them. |
| `_Redist/`, `_Language Switcher/*.reg`, `unins000.*` | Installer leftovers. |
| Soundtrack, Wallpapers, Satellite Map, Brady Guide | Media and extras. |

---

## 4. Checklist for every modding session

### Before you install or change anything

- [ ] Run `git status` and make sure the tree is clean, so you have a known-good point to roll back to.
- [ ] Note the game version in `ScriptHookV.log` (currently `VER_1_0_3717_0`).

### When you install a mod, record

- [ ] New `.asi` files and their `.ini` files in the root.
- [ ] New `.dll` files and their `.ini`/`.xml` configs in `scripts/`.
- [ ] New add-on DLC: the `dlcpacks/<name>/` folder, the `dlclist.xml` entry, and the line in `menyooStuff/AddedVehicleModels.xml`.
- [ ] Any edited RPFs in `Mods/`. Run `bash tools/update-mods-manifest.sh` to regenerate `Mods/MANIFEST.md`.
- [ ] Keybinds the mod uses. Check for clashes with `trainerv.ini`, Menyoo and the Lua GUI.

### After you test in game

- [ ] Check `asiloader.log` to confirm the plugin loaded.
- [ ] Check `ScriptHookVDotNet.log` for exceptions.
- [ ] Commit with a message that names the mod and its version, for example "Add Better Chases+ 2.1 and tune arrest radius".

### After a game update

- [ ] Compare the game version line in `ScriptHookV.log` with the previous one.
- [ ] Update `ScriptHookV.dll` and SHVDN, then commit the change to the version list.
