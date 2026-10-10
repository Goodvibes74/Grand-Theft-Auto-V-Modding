# Mods and how to activate them

Every installed mod and how to turn it on or open it in game, with keyboard, Xbox and PlayStation controls. Keybinds were read from the config files on 2026-10-09. For clashes between keys see [`HOTKEYS.md`](HOTKEYS.md). For key code numbers see [`KEYCODES.md`](KEYCODES.md).

- Launch with `PlayGTAV.bat`. BattlEye blocks every mod.
- Single player only. Never go online with these mods installed.
- PlayStation names for the Xbox buttons are in [`HOTKEYS.md`](HOTKEYS.md#controller-button-names).

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
| Mod Guide | In-game list of every mod, what it does and its keyboard, Xbox and PlayStation controls. Choose a mod, then move over each line to read it. | F12 | RB + D-pad Down | R1 + D-pad Down | `scripts/ModGuide.ini` (keys), `scripts/ModGuide.xml` (content) |
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
| HomeInvasion | Rob houses around the map (76 red blips, config in `scripts/HomeInvasion.xml`). Walk to a red marker with **no wanted level** and press **E** (Xbox A, PlayStation Cross, the on-foot context button) to enter. Inside, press E to take loot or to intimidate a targeted resident, and E at the door to leave. Residents who spot you may flee, fight or phone the police: you get a wanted level and cops or SWAT arrive inside after a delay. Our build of the 2019 mod, source in `ModDevelopment/MyMods/HomeInvasion/`. Police odds, delay, weapons and wanted level are in the `<Cops>` block (`SETTINGS.md` section 7a). |
| iFruitAddon2 | Library that adds contacts to the phone. Open the phone (Up arrow, or D-pad Up on Xbox and PlayStation) to see them. Log: `iFruitAddon2.log`. |
| GTA Online - Offline | Single-player recreation of the GTA Online start: intro, character creator, Lester phone menus, Eclipse Towers apartment, Fleeca heist and Kosatka travel. **First launch plays the intro and switches you to a freemode character** (the ini starts at `INTRO = False`). Back up or start a new save first. Progress is saved in `scripts/GTAOnline_Offline.ini`. Needs `scripts/GTAOnlineOfflineAssets/` and the `NAudio*.dll` files. Phone key: **F5** (once the mod unlocks its phone). Lester's "Cops turn a blind eye" purchase ($12,568) sets the max wanted level to 0, which turns off RDE and Better Chases+ until you reset it. Debug keys (Delete, J) are off. |
| openCameraV | Camera mod. No config and no keybind found. Log: `openCameraV.log`. |
| RDE police overhaul (`rde`, `wov_expansion`, `rdeplus`, SixStarResponse, LiveryChanger, SSRPlus) | Replaces police dispatch, with a sixth wanted star and roadblocks. Always on. **Ctrl+F10** turns SixStarResponse off and on (off lets story missions run unchanged). Better Chases+ must leave dispatch to it (see `SETTINGS.md`). Configs: `scripts/SixStarResponse/SixStarResponse.ini` and `scripts/SSRPlus.ini`. |
| OpenIV.asi | Loads everything in `Mods/`. Always on. |
| HeapAdjuster, PackfileLimitAdjuster, WeaponLimitsAdjuster, DecalsLimit-Patch | Raise engine limits. Always on. |
| LemonUI, NativeUI, ClearScript | Libraries that other mods need. |

### Add-on content

| Content | How to use it |
| --- | --- |
| `forest_n`, `forest_s` map packs | Load automatically when listed in `dlclist.xml`. |
| `gxetron`, `urus2018`, `rmodmi8` vehicles | Model names `gxetron`, `urus2018` and `rmodmi8` (a BMW i8 with body-kit parts such as grills, bumpers, wings and a rollcage). In Menyoo they are under Vehicle Spawner, "Added Models" (listed by hash in `menyooStuff/AddedVehicleModels.xml`). If they don't show there, use "Add New Vehicle Model" in that menu and type the model name. You can also spawn them by name in TrainerV. |
| `vremastered` | Map and world visuals (no vehicles inside), always on. |
| Saved Menyoo vehicles | Menyoo, Vehicle Spawner, Saved Files: Ghost Rider (three variants), the Lamborghini Urus and `TheOne`. |
| Saved Menyoo outfit | Menyoo wardrobe, saved outfits: `GhostRider`. |

