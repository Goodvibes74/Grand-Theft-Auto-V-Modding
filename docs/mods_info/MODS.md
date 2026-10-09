# Mods: what each one does and how to activate it

This lists every installed mod, how to turn it on or open it in game (keyboard, Xbox and PlayStation), and the hotkey conflicts found across the configs. Keybinds were read from the config files and the conflict fixes were applied on 2026-10-09. Keybind values are virtual-key codes for keyboard and GTA control IDs for controller (see [`KEYCODES.md`](../KEYCODES.md)).

- Launch with `PlayGTAV.bat`. BattlEye blocks every mod.
- Single player only. Never go online with these mods installed.

## Controller button names

| Xbox | PlayStation 4 / 5 |
| --- | --- |
| A | Cross |
| B | Circle |
| X | Square |
| Y | Triangle |
| RB / LB | R1 / L1 |
| RT / LT | R2 / L2 |
| LS click / RS click | L3 / R3 |
| D-pad | D-pad |
| View / Menu | Touchpad / Options |

---

## 1. Mods with a menu or a hotkey

| Mod | How to activate | Keyboard | Xbox | PlayStation | Config |
| --- | --- | --- | --- | --- | --- |
| TrainerV | Open the menu. Enabled on startup (`EnabledOnStartup=1`). | F3 | RB + X | R1 + Square | `trainerv.ini` `[KeyBindings]` |
| TrainerV menu navigation | Move, select, go back. | Numpad 8 / 2 / 5 / 0, Backspace | D-pad, A, B | D-pad, Cross, Circle | `trainerv.ini` `MenuKey*`, `Controller*` |
| TrainerV airbreak | Toggle fly-through mode. | G + 6 | RB + LS | R1 + L3 | `trainerv.ini` `AirBreakKey*`, `ControllerAirbreak*` |
| Menyoo | Open the main menu. | F8 | RB + D-pad Left | R1 + D-pad Left | `menyooStuff/menyooConfig.ini` `open_key` |
| Menyoo Spooner | Toggle object spooner mode. | F9 | RB + D-pad Right | R1 + D-pad Right | `menyooConfig.ini` `SpoonerModeHotkey` |
| Menyoo FreeCam | Toggle free camera. | F6 | X + LS (fixed) | Square + L3 (fixed) | `menyooConfig.ini` `FreeCamButton` |
| Menyoo stop animation | Stop the current animation. | Home | none | none | `menyooConfig.ini` `stop_animation_key` |
| Menyoo clone protection | Toggle (an online feature, not needed in single player). | F11 | none | none | `menyooConfig.ini` `CloneProtectionHotkey` |
| Menyoo manual respawn | Respawn after death. | C (control 26) | RS click | R3 | `menyooConfig.ini` `manual_respawn_button` |
| Better Chases+ | Runs on its own during police chases. The menu opens settings. | F7 (menu) | none (menu) | none (menu) | `scripts/BetterChasesConfig.xml` `<MenuKey>` |
| Better Chases+ surrender | Surrender to police during a chase. | E | RB (cover) | R1 (cover) | `BetterChasesConfig.xml` `<SurrenderKey>`, `<SurrenderButton>` |
| MapEditor | Open the map editor. Gamepad support is on. | F2 | see in-game hints | see in-game hints | `scripts/MapEditor.xml` `<ActivationKey>` |
| Stance | Toggle the stance pose. `overrideStealthButton=true` also puts it on the stealth button. | Y | LS click (stealth) | L3 (stealth) | `scripts/Stance.ini` `stanceKey` |
| SHVDN console | Open the .NET script console for live errors. | F4 | none | none | `ScriptHookVDotNet.ini` `ConsoleKeyBinding` |
| Lua GUI (`exampleGUI.lua`) | **Disabled by default.** Enable it as described in [`LUA_MENU.md`](LUA_MENU.md). | Numpad 8 / 2 to move, Space to select | A + RB + RS to open, B + LB + LT to close | Cross + R1 + R3 to open, Circle + L1 + L2 to close | `scripts/libs/GUI.lua` |
| NoEditorRestrictions | Works on its own in the Rockstar Editor. The key toggles "streaming focus on camera". | F9 | none | none | `NoEditorRestrictions.ini` |

The controller label for Stance (stealth button) comes from the mod's own setting name and hasn't been checked in game.

### TrainerV hotkeys (keyboard only, work without opening the menu)

Two-key combos mean "hold the first, press the second". TrainerV has no controller binds for these.

| Action | Keys |
| --- | --- |
| Teleport to waypoint | F10, also Delete |
| Teleport to marker | `=` |
| God mode on | Right Ctrl + F5 |
| Car fix, flip, wash, color | Right Ctrl |
| Clone object | Right Ctrl + C |
| Spawn vehicle slot 1 to 12 | Left Alt + A, B, C, D, E, F, G, M, N, T, U, X |
| Spawn random vehicle | Left Alt + R |
| Air break | G + 6 (then W/S up/down, Numpad 8/2/4/6 to move) |
| Cruise control | G + 7 |
| Skylift attach | G + 8 |
| Vehicle god mode | G + 9 |
| Speed up / stop | Numpad 9 / Numpad 3 |
| Indicators left / right | K / L |
| Vehicle weapons | Numpad + |
| Next song / tune radio | N / Numpad * |
| Clear wanted level | Insert |
| Spawn attacking driver | Page Up |
| Waypoint to mission marker | Page Down |
| Alarm lights | End |
| Walk through closed door | `'` |
| Explode nearest car | `/` |
| World / Other quick menus | Right Alt / O |
| Open car doors | I |
| Saved vehicle: spawn, delete, teleport | K + Numpad 1 / 0 / 2 |
| Cycle passenger seat, gravity gun, explode cop car | K + Numpad 3 / 4 / 5 |
| Bodyguards teleport / spawn random | K + Numpad 6 / 7 |
| Ragdoll, night vision | K + Numpad 8 / 9 |
| Last animation, EPM down/up, ETM down/up | J + Numpad 0 / 1 / 2 / 3 / 4 |
| Aim time, drive time, hazard lights | J + Numpad 5 / 6 / 7 |
| Wanted level up / down | J + Numpad 8 / 9 |
| Add silencer | S + Numpad 1 |
| Sit | L + Numpad 0 |

---

## 2. Mods that work on their own

No hotkey is needed. If they don't work, check `ScriptHookVDotNet.log` or the log named in each row.

| Mod | What it does and how to use it |
| --- | --- |
| ImmersifyII | Immersion tweaks, always on (`MOD_TOGGLE_KEY=None`). Ped interaction prompts appear as an overlay panel. Settings in `scripts/ImmersifyII.ini`. |
| Cop_Arrest | Arrest people as police. No config file. Its key is hard-coded in the DLL and could not be read from the files. Check the mod's original readme or try it in game. |
| Disarm | Disarm armed NPCs. No config file. It reads keyboard input, but the key is hard-coded and could not be read from the DLL. |
| FoSAShelter | Loose C# script. Walk **on foot** into the shelter entrance near `-489.7, 2233.7, 149.5` and you get teleported inside. The exit zone is near `-485.4, 2232.4, 142.9`. Works the same on any input device. |
| iFruitAddon2 | Library that adds contacts to the phone. Open the phone (Up arrow, or D-pad Up on Xbox and PlayStation) to see them. Log: `iFruitAddon2.log`. |
| openCameraV | Camera mod. No config and no keybind found. Log: `openCameraV.log`. |
| OpenIV.asi | Loads everything in `Mods/`. Always on. |
| HeapAdjuster, PackfileLimitAdjuster, WeaponLimitsAdjuster, DecalsLimit-Patch | Raise engine limits. Always on. |
| LemonUI, NativeUI, ClearScript | Libraries that other mods need. |

### Add-on content

| Content | How to use it |
| --- | --- |
| `forest_n`, `forest_s` map packs | Load automatically when listed in `dlclist.xml`. |
| `gxetron`, `urus2018` vehicles | Spawn by model name in Menyoo (Vehicle Spawner, input model) or TrainerV. **`menyooStuff/AddedVehicleModels.xml` is empty**, so they don't appear in Menyoo's "Added" list yet. |
| `vremastered` | Graphics and vehicle pack, always on. |
| Saved Menyoo vehicles | Menyoo, Vehicle Spawner, Saved Files: Ghost Rider (three variants) and the Lamborghini Urus. |
| Saved Menyoo outfit | Menyoo wardrobe, saved outfits: `GhostRider`. |

---

## 3. Hotkey conflicts

### Fixed on 2026-10-09

| Key | Was used by | Fix |
| --- | --- | --- |
| F7 | Better Chases+ menu and MapEditor | MapEditor moved to **F2** (`scripts/MapEditor.xml`). The old file is saved as `scripts/MapEditor.xml.bak`. |
| J | Stance, Menyoo stop animation and the TrainerV `J + Numpad` combos | Stance moved to **Y** (`Stance.ini`). Menyoo stop animation moved to **Home**, code 36 (`menyooConfig.ini`). J now belongs to TrainerV only. |
| X + LS / Square + L3 | Menyoo FreeCam (fixed in Menyoo) and TrainerV airbreak | TrainerV airbreak moved to **RB + LS / R1 + L3** (`ControllerAirbreak1=206`). |
| `CruiseControl1` typo | `trainerv.ini` set `CruiseControl1` twice, so the second key was never read | Second line renamed to `CruiseControl2=55`, so cruise control is G + 7. |

### Still open (minor)

These are mostly TrainerV clashing with itself. They're left as they are because they're TrainerV's own defaults.

| Severity | Key | Who uses it | Effect |
| --- | --- | --- | --- |
| Medium | K | TrainerV left indicator and every `K + Numpad` combo | Using a K combo in a car also flips the left indicator. |
| Medium | L | TrainerV right indicator and sit (L + Numpad 0) | Same as K. |
| Medium | Numpad 9 / 3 | TrainerV speed up / stop and the J/K combos ending in Numpad 9 or 3 | J + Numpad 9 (wanted down) also boosts speed. K + Numpad 3 (cycle seat) also stops the car. |
| Medium | Right Ctrl | TrainerV car fix/color, god mode (RCtrl + F5), clone object (RCtrl + C) | Using either combo also fixes and recolors your car. |
| Low | N | TrainerV next song and spawn slot 9 (Left Alt + N) | Spawning slot 9 also skips the song. |
| Low | F9 | Menyoo Spooner and NoEditorRestrictions | Only inside the Rockstar Editor. |
| Low | E | Better Chases+ surrender and the game's E | Intended: E surrenders only during a chase. |
| Low | Numpad 8 / 2, Space | Lua GUI, TrainerV menu and airbreak, the game's Space | Only if the Lua GUI is enabled (off by default) and open along with TrainerV. |
| Low | RB / R1 combos | TrainerV (+ X / Square), TrainerV airbreak (+ LS / L3), Menyoo (+ D-pad Left), Spooner (+ D-pad Right) | Fine while the second buttons differ. TrainerV menu navigation uses the D-pad, so holding RB while moving in TrainerV can open Menyoo. |

### Check in game

- **New keys:** F2, Y and Home aren't used by any other mod. Check that they don't collide with your own GTA key settings (Settings, Keyboard / Mouse, Key Bindings). This matters most if you've bound Rockstar Editor actions to F2.
- **Lua GUI controller IDs (fixed 2026-10-09):** `scripts/libs/GUI.lua` had wrong control IDs (Up and Down swapped, R3 was really LB, LT was really RB), required all three combo buttons to go down in the same frame, and only looked for the `PAD` native namespace while LUA.asi uses `CONTROLS`. All three are fixed. The combos now use the `INPUT_FRONTEND_*` IDs, so on keyboard Enter + E + Left Ctrl also opens the menu and Backspace + Q + Page Down closes it.
- **F4:** SHVDN console. TrainerV's `HideMenuKey=115` (F4) is commented out in `trainerv.ini`. Leave it commented out.

After any rebind, update the keybind table in [`README.md`](../README.md) section 3 and this file.
