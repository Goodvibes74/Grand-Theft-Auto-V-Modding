# GTA V Legacy: Mod Management Guide

This is the main guide to the modded GTA V Legacy install in this folder. It covers what is installed, how the mods load, how to install, update and remove mods safely, how to recover when something breaks, and how changes are tracked in git.

| Doc | Purpose |
| --- | --- |
| `README.md` (this file) | How to manage and update mods. |
| [`MOD_TRACKING.md`](MOD_TRACKING.md) | What git tracks and doesn't track, plus a checklist for each modding session. |
| [`KEYCODES.md`](KEYCODES.md) | Keyboard and controller codes for `trainerv.ini` and other configs. |
| [`docs/LUA_MENU.md`](docs/LUA_MENU.md) | The custom Lua GUI menu: how to turn it on, and its controls. |
| [`CLAUDE.md`](CLAUDE.md) | Instructions for Claude Code when it works in this folder. |
| [`Mods/MANIFEST.md`](Mods/MANIFEST.md) | Generated size and hash list of every RPF in `Mods/`. |

---

## 1. Quick start

```bat
PlayGTAV.bat        :: starts PlayGTAV.exe -nobattleye
```

- Always launch through `PlayGTAV.bat`. BattlEye blocks every ASI mod.
- Single player only. **Never go online with these mods installed.** Your account will be banned.

---

## 2. Current setup

| Item | Value |
| --- | --- |
| Game build | `GTA5.exe` 1.0.3725.0. ScriptHookV reports `VER_1_0_3717_0`. |
| ScriptHookV | Build Jul 15 2026 (v3889.0) |
| ScriptHookVDotNet | v2 and v3 runtimes, `.asi` dated Aug 5 2025 |
| ASI loader | `dinput8.dll` (Alexander Blade, 2015) |

### How the mods load

```text
GTA5.exe
 └─ dinput8.dll  (ASI loader: loads every *.asi in the game root)
     ├─ ScriptHookV.dll          lets mods call game functions (natives); every script depends on it
     │   ├─ ScriptHookVDotNet.asi  .NET mods: scripts/*.dll and scripts/*.cs
     │   ├─ LUA.asi                Lua mod: scripts/main.lua
     │   ├─ Menyoo.asi             trainer and object spooner, data in menyooStuff/
     │   └─ TrainerV.asi           trainer, configured by trainerv.ini
     ├─ OpenIV.asi               loads modded RPF files from Mods/ in place of the originals
     ├─ openCameraV.asi, NoEditorRestrictions.asi
     └─ limit adjusters (raise engine limits so add-ons fit)
         HeapAdjuster, PackfileLimitAdjuster, WeaponLimitsAdjuster,
         fwBoxStreamerVariable_DecalsLimit-Patch
```

### Installed mods

**ASI plugins (game root)**

| Mod | Config | Notes |
| --- | --- | --- |
| Menyoo | `menyooStuff/menyooConfig.ini` | Trainer and object spooner (for placing and editing objects). Saved vehicles, outfits and maps go in `menyooStuff/`. |
| TrainerV | `trainerv.ini` | Trainer. Codes are listed in `KEYCODES.md`. |
| LUA.asi | `scripts/main.lua` | Runs the custom Lua scripts in `scripts/`. |
| OpenIV.asi | none | Required for anything in `Mods/`. |
| openCameraV | none | Camera mod. |
| NoEditorRestrictions | `NoEditorRestrictions.ini` | Removes Rockstar Editor limits. Free-cam speed 40. |
| HeapAdjuster | `HeapAdjuster.ini` | `HEAP_SIZE = 750` |
| PackfileLimitAdjuster | `PackfileLimitAdjuster.ini` | `packfile_list_size = 7344` |
| WeaponLimitsAdjuster | `WeaponLimitsAdjuster.ini` | 512 weapon infos, 1024 components |
| DecalsLimit-Patch | `fwBoxStreamerVariable_DecalsLimit-Patch.toml` | Raises the decal limit. |

**ScriptHookVDotNet mods (`scripts/`)**

| Mod | Config | Notes |
| --- | --- | --- |
| Better Chases+ | `BetterChasesConfig.xml` | Police chase and arrest overhaul. |
| Cop_Arrest | none | Lets you arrest people as police. |
| Disarm | none | Lets you disarm armed NPCs. |
| ImmersifyII | `ImmersifyII.ini`, `ImmersifyIIData.xml` | Immersion tweaks. |
| Stance | `Stance.ini` | Vehicle stance (wheel camber and offset). |
| iFruitAddon2 | `iFruitAddon2/config.ini` | Library that adds contacts to the phone. |
| MapEditor | `MapEditor/*.xml` | Map editor. Uses `ObjectList.ini` and `Expanded ObjectList.ini`. |
| FoSAShelter | `FoSAShelter.3.cs` | Loose C# script that SHVDN compiles at load time. |
| LemonUI, NativeUI, ClearScript | none | **Libraries other mods need. Do not delete them.** |

**Add-on DLC packs (`Mods/update/x64/dlcpacks/`)**

| Pack | Type |
| --- | --- |
| `forest_n`, `forest_s` | Map add-on |
| `gxetron` | Vehicle |
| `urus2018` | Vehicle (Lamborghini Urus) |
| `vremastered` | Graphics and vehicle pack |

**Other files**

| Path | What |
| --- | --- |
| `menyooStuff/Vehicle/` | Saved Menyoo vehicles: Ghost Rider (three variants) and the Lamborghini Urus. |
| `menyooStuff/Outfit/GhostRider.xml` | Ghost Rider outfit. |
| `xinput1_4.dll` | Not a vanilla file. Probably a controller mod. **Still unidentified.** |

---

## 3. Keybinds

| Action | Keyboard | Controller | Set in |
| --- | --- | --- | --- |
| TrainerV menu | F3 | RB + X | `trainerv.ini` `[KeyBindings]` |
| Menyoo menu | F8 | RB + D-pad Left | `menyooConfig.ini` `open_key` |
| Menyoo Spooner | F9 | RB + D-pad Right | `menyooConfig.ini` `SpoonerModeHotkey` |
| Menyoo FreeCam | F6 (code 117) | X + LS | `menyooConfig.ini` `FreeCamButton` |
| Menyoo clone protection | F11 | none | `menyooConfig.ini` |
| Better Chases+ menu | F7 | none | `BetterChasesConfig.xml` `<MenuKey>` |
| SHVDN console | F4 | none | `ScriptHookVDotNet.ini` |
| Stance menu | J | none | `Stance.ini` |
| TrainerV teleport | F10 | none | `trainerv.ini` `TeleportKey` |
| TrainerV god mode | Right Ctrl + F1 / F5 | none | `trainerv.ini` `GodKey*` |
| Lua GUI | Numpad 8 / 2, Space | A + RB + RL / B + LB + LT | `scripts/libs/GUI.lua` |

### Known conflicts

- **F3 (fixed 2026-10-09):** the TrainerV menu and Menyoo FreeCam both used F3. FreeCam moved to F6 (`FreeCamButton = 117`). F10 was not an option because TrainerV uses it for teleport.
- **Numpad 8 / 2:** TrainerV and the Lua GUI both use these to navigate. They only clash if both menus are open at the same time.
- **RB:** TrainerV, Menyoo and the Spooner all start their controller combos with RB. The second button tells them apart, so keep the second buttons different.

**Rule:** before you give a new mod a key, check this table and update it afterwards. `KEYCODES.md` lists the numeric codes.

---

## 4. Installing a new mod

Work through these steps in order. Start with a clean git tree so that you can roll back.

```bash
git status          # should print nothing
```

### 4a. ASI plugin (`*.asi`)

1. Copy `ModName.asi` and its `.ini` into the **game root**.
2. Launch the game, then check `asiloader.log` for `ASI: Loading "...ModName.asi"`.
3. If the mod has binds, add them to the keybind table (section 3).
4. Commit: `git add ModName.asi ModName.ini && git commit -m "Add ModName vX.Y"`.

### 4b. ScriptHookVDotNet mod (`*.dll` / `*.cs`)

1. Copy the `.dll` (or `.cs`) and its config files into `scripts/`. If the mod ships with LemonUI or NativeUI, keep whichever version is **newer**.
2. Check whether it targets SHVDN v2 or v3. Both runtimes are installed.
3. Launch the game. `ScriptHookVDotNet.log` should show `Started script ModName...` and no exception.
4. Press **F4** to open the SHVDN console for live errors. If you set `ReloadKeyBinding` in `ScriptHookVDotNet.ini`, scripts reload without a restart.
5. Commit. `scripts/*.dll` is already whitelisted in git.

### 4c. Add-on vehicle, ped or map (DLC pack)

Add-on packs add new items without replacing vanilla ones, so they are the safest kind of content mod.

1. In OpenIV, switch on **Edit mode** and go to `Mods/update/x64/dlcpacks/`.
2. Create a folder `<packname>/` and copy `dlc.rpf` into it.
3. Open `Mods/update/update.rpf/common/data/dlclist.xml` and add this line before `</Paths>`:

   ```xml
   <Item>dlcpacks:/<packname>/</Item>
   ```

4. Add the model name to `menyooStuff/AddedVehicleModels.xml` (or `PedList.xml`), and also to `scripts/VehicleList.ini` or `PedList.ini` if you want it in those menus.
5. Regenerate the manifest:

   ```bash
   bash tools/update-mods-manifest.sh
   ```

6. Spawn the item in game to test it.
7. Commit `Mods/MANIFEST.md`, the XML/INI edits, and the DLC pack table in this README.

### 4d. Replacement mod (overwrites vanilla files)

Use these only when no add-on version exists, because they are harder to undo.

1. **Back up first.** Extract the original file from `Mods/...rpf` with OpenIV and save a copy (for example in `Mods/_backup/`).
2. Replace the file inside the RPF in **`Mods/`**. **Never edit the root `x64*.rpf`, `common.rpf` or `update/` files.**
3. If you edited a text meta file (such as `handling.meta`, `vehicles.meta` or `gameconfig.xml`), also save a copy to `Mods/_meta/` so git can show the change.
4. Regenerate the manifest, test, and commit.

### 4e. Menyoo vehicles, outfits and maps

- Save them from inside Menyoo. They land in `menyooStuff/Vehicle/`, `Outfit/` and `Spooner/`.
- These are XML files and git tracks them automatically, so just commit.

---

## 5. Updating mods

### Routine mod update

1. Check `git status` (it should be clean).
2. Overwrite the old file with the new version (`.asi`, `.dll` or RPF). **Keep your edited `.ini`/`.xml`.** Don't overwrite configs blindly. Compare them instead:

   ```bash
   git diff -- scripts/ModName.ini
   ```

3. If the new version ships a new default config, merge your old values back in.
4. Test, check the logs (section 7), and commit with the new version number in the message.

### When the game updates (the big one)

A game update can cause the following:

- **ScriptHookV stops working**, so nothing in `scripts/` loads, and Menyoo, TrainerV and the Lua mod are gone. The log says the game version is not supported.
- **The vanilla `update.rpf` gets replaced** while `Mods/update/update.rpf` stays old. The game may crash or ignore the update.

How to recover:

1. Read the new version line in `ScriptHookV.log` and write it down.
2. Download a matching **ScriptHookV** from dev-c.com (Alexander Blade), and replace `ScriptHookV.dll`. Do the same for `dinput8.dll` only if the new release requires it.
3. Update **ScriptHookVDotNet** if its release notes mention the new build.
4. **Rebuild `Mods/update/update.rpf`:**
   1. Back up your old modded copy: `Mods/update/update.rpf` to `update.rpf.bak`.
   2. Copy the **new vanilla** `update/update.rpf` into `Mods/update/`.
   3. Use OpenIV to re-apply your edits. At minimum, add back every `dlclist.xml` entry from section 2.
   4. Do the same for `update2.rpf` if it changed.
5. Update the **OpenIV.asi** plugin if OpenIV offers it.
6. Check the limit adjusters. `PackfileLimitAdjuster` must be at least the `ArchiveCount` in the new `gameconfig.xml`.
7. Run `bash tools/update-mods-manifest.sh`, test, and commit. Update the "Current setup" table in this README.

**Tip:** if you don't need the update, you can hold off. Leaving the game files unchanged keeps every mod working.

---

## 6. Removing or disabling a mod

| Type | Disable temporarily | Remove permanently |
| --- | --- | --- |
| ASI | Rename `Mod.asi` to `Mod.asi.off` | Delete the `.asi` and `.ini` |
| SHVDN | Rename `Mod.dll` to `Mod.dll.off` | Delete the `.dll` and its configs |
| Lua addin | Comment it out or set it to `false` in `main.lua` | Delete the file in `scripts/addins/` |
| DLC pack | Comment out its `dlclist.xml` line | Remove the line **and** the `dlcpacks/<name>/` folder |
| Replacement | Restore the backed-up original into the `Mods/` RPF | Same |
| Everything at once | Temporarily rename `dinput8.dll` | Not applicable |

After any removal, commit it so the git history records what was taken out and why.

---

## 7. Troubleshooting

### Read the logs first

Every launch rewrites them in the game root.

| Log | What to look for |
| --- | --- |
| `asiloader.log` | Every `.asi` should appear under `ASI: Loading`. |
| `ScriptHookV.log` | `INIT: Success, game version is ...`. A version error here means you need to update ScriptHookV. |
| `ScriptHookVDotNet.log` | `[ERROR]` and stack traces, plus which script failed. |
| `menyoolog.txt` | Menyoo errors. |
| `OpenIV.log` | Large. Search it for errors about RPF or `Mods/` loading. |

### Common problems

| Symptom | Likely cause | Fix |
| --- | --- | --- |
| No mods load at all | ScriptHookV doesn't match the game version, or BattlEye is running | Update ScriptHookV. Launch with `PlayGTAV.bat`. |
| ASI mods work, `.NET` mods don't | SHVDN is outdated, or a library (LemonUI, NativeUI) is missing | Update SHVDN and check `ScriptHookVDotNet.log`. |
| Crash on the loading screen | Bad RPF edit, a limit was exceeded, or a broken `dlclist.xml` | Undo the last change (see below). Raise the packfile or heap limit. |
| Add-on vehicle won't spawn | Missing `dlclist.xml` entry, or a wrong model name | Check `dlclist.xml` and the model name in `vehicles.meta`. |
| Textures pop in or go missing | Heap or streaming limits | Raise `HEAP_SIZE` in `HeapAdjuster.ini`. |
| A key does nothing | Keybind conflict | Check section 3. |
| Script lag or a "script timeout" | A slow SHVDN script | Check `ScriptTimeoutThreshold` in `ScriptHookVDotNet.ini`, and the log. |

### Rolling back

```bash
git log --oneline                 # find the last good commit
git diff <good-commit> --stat     # see what changed since then
git checkout <good-commit> -- scripts/ trainerv.ini menyooStuff/   # restore configs and DLLs
```

RPFs are not in git. `Mods/MANIFEST.md` tells you **which** RPF changed, and you restore it from your `.bak` copy.

To find which mod causes a crash, disable half of the mods (section 6), test, and keep halving until you find the culprit.

---

## 8. Version control

For the full rules, see [`MOD_TRACKING.md`](MOD_TRACKING.md).

- **Tracked:** configs (`.ini`, `.xml`, `.json`, `.toml`), scripts (`.lua`, `.cs`), docs, `.asi` plugins, SHVDN mod DLLs, the ScriptHook DLLs, Menyoo data, and `Mods/MANIFEST.md`.
- **Not tracked:** game RPFs (about 40 GB), the modded RPFs in `Mods/` (2.7 GB, tracked through the manifest), game executables, launcher and DRM files, logs and media.
- **New mod binary outside `scripts/`?** Add a `!path/to/file.dll` line at the bottom of `.gitignore`.
- **Commit messages:** use the imperative and include the version, for example `Add Better Chases+ 2.1`, `Update ScriptHookV for 1.0.3725`, or `Tune Stance camber defaults`.

```bash
bash tools/update-mods-manifest.sh   # after any change in Mods/
git add -A
git commit -m "Add <mod> vX.Y"
```

---

## 9. Golden rules

1. Start with a clean `git status` before every modding session.
2. Never edit the vanilla RPFs. Use `Mods/` only.
3. Back up anything that git doesn't track before you change it.
4. Install one mod at a time, then test and commit, before the next one.
5. Prefer add-on mods to replacement mods.
6. Keep this README's tables (mods, DLC packs, keybinds) up to date.
7. Single player only. Never go online with these mods.
