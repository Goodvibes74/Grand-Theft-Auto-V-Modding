# Mods: what each one does and how to activate it

This lists every installed mod, how to turn it on or open it in game, and every keybind clash found across the configs. The keybinds were read from the config files on 2026-10-09. Keybind values are virtual-key codes for keyboard and GTA control IDs for controller (see [`KEYCODES.md`](../KEYCODES.md)).

- Launch with `PlayGTAV.bat`. BattlEye blocks every mod.
- Single player only. Never go online with these mods installed.

---

## 1. Mods with a menu or a hotkey

| Mod | How to activate | Keyboard | Controller | Config |
| --- | --- | --- | --- | --- |
| TrainerV | Open the menu. Enabled on startup (`EnabledOnStartup=1`). | F3 | RB + X | `trainerv.ini` `[KeyBindings]` |
| Menyoo | Open the main menu. | F8 | RB + D-pad Left | `menyooStuff/menyooConfig.ini` `open_key` |
| Menyoo Spooner | Toggle object spooner mode. | F9 | RB + D-pad Right | `menyooConfig.ini` `SpoonerModeHotkey` |
| Menyoo FreeCam | Toggle free camera. | F6 | X + LS (fixed) | `menyooConfig.ini` `FreeCamButton` |
| Menyoo stop animation | Stop the current animation. | J | none | `menyooConfig.ini` `stop_animation_key` |
| Menyoo clone protection | Toggle (an online feature, not needed in single player). | F11 | none | `menyooConfig.ini` `CloneProtectionHotkey` |
| Menyoo manual respawn | Respawn after death. | C (control 26) | R3 | `menyooConfig.ini` `manual_respawn_button` |
| Better Chases+ | Runs on its own during police chases. The menu opens settings. | F7 (menu), E (surrender) | Cover button (surrender) | `scripts/BetterChasesConfig.xml` |
| MapEditor | Open the map editor. Gamepad support is on. | F7 | see in-game hints | `scripts/MapEditor.xml` `ActivationKey` |
| Stance | Toggle the stance pose (replaces the stealth button, `overrideStealthButton=true`). | J | stealth button | `scripts/Stance.ini` |
| SHVDN console | Open the .NET script console for live errors. | F4 | none | `ScriptHookVDotNet.ini` `ConsoleKeyBinding` |
| Lua GUI (`exampleGUI.lua`) | **Disabled by default.** Enable it as described in [`LUA_MENU.md`](LUA_MENU.md). | Numpad 8 / 2 to move, Space to select | A + RB + RL to open | `scripts/libs/GUI.lua` |
| NoEditorRestrictions | Works on its own in the Rockstar Editor. The key toggles "streaming focus on camera". | F9 | none | `NoEditorRestrictions.ini` |

### TrainerV hotkeys (work without opening the menu)

TrainerV has many direct hotkeys. Two-key combos mean "hold the first, press the second".

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
| FoSAShelter | Loose C# script. Walk **on foot** into the shelter entrance near `-489.7, 2233.7, 149.5` and you get teleported inside. The exit zone is near `-485.4, 2232.4, 142.9`. |
| iFruitAddon2 | Library that adds contacts to the phone. Open the phone (Up arrow) to see them. Log: `iFruitAddon2.log`. |
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
| Saved Menyoo outfit | Menyoo, Player Options, Wardrobe, Saved Outfits: `GhostRider`. |

---

## 3. Hotkey conflicts

Sorted by severity. "High" means pressing the key does two unrelated things.

| # | Severity | Key | Who uses it | Effect |
| --- | --- | --- | --- | --- |
| 1 | High | **F7** | Better Chases+ menu (`BetterChasesConfig.xml` `<MenuKey>`) and MapEditor (`MapEditor.xml` `<ActivationKey>`) | Both menus open at once. `MapEditor.xml` is new and untracked, so this clash appeared when MapEditor first ran and wrote its default config. |
| 2 | High | **J** | Stance (`stanceKey=J`), Menyoo stop animation (`stop_animation_key = 74`), and the TrainerV `J + Numpad` combos | Every TrainerV `J + Numpad` combo also toggles your stance and cancels your animation. TrainerV "last played animation" (J + Numpad 0) gets cancelled by Menyoo straight away. |
| 3 | High (controller) | **X + LS** | Menyoo FreeCam (fixed, can't be changed) and TrainerV airbreak (`ControllerAirbreak1=203`, `ControllerAirbreak2=86`) | Both toggle at once on a controller. |
| 4 | Medium | **K** | TrainerV left indicator (`LeftIndicator=75`) and every TrainerV `K + Numpad` combo | Using a K combo in a car also flips the left indicator. |
| 5 | Medium | **L** | TrainerV right indicator (`RightIndicator=76`) and TrainerV sit (L + Numpad 0) | Same as K. |
| 6 | Medium | **Numpad 9 / Numpad 3** | TrainerV speed up / stop (single keys) and the J/K combos that end in Numpad 9 or 3 | J + Numpad 9 (wanted down) also boosts speed. K + Numpad 3 (cycle seat) also stops the car. |
| 7 | Medium | **Right Ctrl** | TrainerV car fix/color (single key), god mode (RCtrl + F5), clone object (RCtrl + C) | Using either combo also fixes and recolors your car. Harmless but surprising. |
| 8 | Low | **N** | TrainerV next song (`MusicNext=78`) and spawn slot 9 (Left Alt + N) | Spawning slot 9 also skips the song. |
| 9 | Low | **F9** | Menyoo Spooner and NoEditorRestrictions (`attach_streaming_focus_to_camera_key = 0x78`) | Only matters inside the Rockstar Editor, where NoEditorRestrictions is active. |
| 10 | Low | **E** | Better Chases+ surrender and the game's E (context action) | Intended by the mod: E surrenders only during a chase. |
| 11 | Low | **Numpad 8 / 2, Space** | Lua GUI navigation, TrainerV menu and airbreak navigation, and the game's Space (jump/handbrake) | Only if the Lua GUI is enabled (it is off by default) and open along with TrainerV. |
| 12 | Low (controller) | **RB + ...** | TrainerV (RB + X), Menyoo (RB + D-pad Left), Spooner (RB + D-pad Right), Lua GUI (A + RB + RL) | Fine as long as the second buttons stay different. TrainerV menu navigation uses the D-pad, so pressing RB while moving in TrainerV can open Menyoo. |

### Watch out for

- **F4:** SHVDN console. TrainerV's `HideMenuKey=115` (F4) is commented out in `trainerv.ini`. Leave it commented out.
- **`trainerv.ini` typo:** `CruiseControl1` is set twice (`71` then `55`). The second line was probably meant to be `CruiseControl2=55`. As written, cruise control may not bind to G + 7 as listed above.
- **F2** is the only function key that no mod uses. It's the first choice for any rebind.

### Suggested fixes (not applied)

| Conflict | Suggested change |
| --- | --- |
| #1 F7 | Move MapEditor to F2: `<ActivationKey>F2</ActivationKey>` in `scripts/MapEditor.xml`. |
| #2 J | Move Menyoo stop animation off J (`stop_animation_key` in `menyooConfig.ini`) and move Stance to a key nothing else uses (`stanceKey` in `Stance.ini`). Check the game's own key settings before picking one. |
| #3 X + LS | Change TrainerV's `ControllerAirbreak2` to another button (Menyoo's FreeCam combo can't be changed). |
| #4 to #8 | TrainerV design. Rebind its single-key actions (indicators, speed, car fix, next song) in `[KeyBindings]` if they get in the way. |
| `CruiseControl1` typo | Rename the second line to `CruiseControl2=55`. |

After any rebind, update the keybind table in [`README.md`](../README.md) section 3 and this file.
