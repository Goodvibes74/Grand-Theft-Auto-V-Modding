# Editing mod settings

How to change the settings of every installed mod: which file holds them, how the file is laid out, what the main options do, and what to watch out for. Values shown are the ones in the files on 2026-10-09.

For keybinds see [`MODS.md`](MODS.md) and [`HOTKEYS.md`](HOTKEYS.md). For key code numbers see [`KEYCODES.md`](KEYCODES.md).

## Contents

1. [Before you edit anything](#1-before-you-edit-anything)
2. [Better Chases+](#2-better-chases)
3. [ImmersifyII](#3-immersifyii)
4. [MapEditor](#4-mapeditor)
5. [Stance](#5-stance)
6. [iFruitAddon2](#6-ifruitaddon2)
7. [FoSAShelter](#7-fosashelter)
8. [TrainerV](#8-trainerv)
9. [Menyoo](#9-menyoo)
10. [Lua mod and GUI menu](#10-lua-mod-and-gui-menu)
11. [ScriptHookVDotNet](#11-scripthookvdotnet)
12. [NoEditorRestrictions](#12-noeditorrestrictions)
13. [Engine limit adjusters](#13-engine-limit-adjusters)
14. [Model and object lists](#14-model-and-object-lists)
15. [Mods with no settings file](#15-mods-with-no-settings-file)
16. [Quick reference](#16-quick-reference)

---

## 1. Before you edit anything

### Close the game first

Edit settings with the game closed. Several mods write their config back to disk while the game runs (Menyoo does it on a timer, Better Chases+, MapEditor and TrainerV do it when you change options in their menus). If the game is open, your edit can be overwritten, and most mods only read their file at startup anyway.

### Every config is in git

All the files in this manual are tracked in git, so you don't need a `.bak` copy. To see what you changed, or undo it:

```bash
git diff -- scripts/ImmersifyII.ini        # show your changes
git checkout -- scripts/ImmersifyII.ini    # throw them away
```

Commit once the change works in game.

### File formats

| Format | Files | Rules |
| --- | --- | --- |
| INI | most `.ini` files | `key=value` under a `[Section]`. Keep the section header above its keys. Comment styles differ per mod (see each section). |
| XML | `BetterChasesConfig.xml`, `MapEditor.xml`, Menyoo `*.xml` | Change only the text between `<Tag>` and `</Tag>`. Every tag you open must be closed. A broken tag usually makes the mod fall back to defaults or fail to load. |
| TOML | `fwBoxStreamerVariable_DecalsLimit-Patch.toml` | `key = value` under `[Section]`. `#` starts a comment. |
| Lua | `scripts/**/*.lua` | Code, not settings. See [section 10](#10-lua-mod-and-gui-menu). |

Value types you'll see:

- **Booleans:** `true`/`false` in .NET mods and Menyoo, `1`/`0` in TrainerV.
- **Keys in .NET mods** (Better Chases+, MapEditor, Stance, SHVDN): a .NET `Keys` name such as `F7`, `Y`, `E`, `NumPad5`, `OemSemicolon`, or `None` to disable.
- **Keys in TrainerV and Menyoo:** a decimal Windows virtual-key code (`114` = F3). NoEditorRestrictions uses hex (`0x78` = F9). Look codes up in [`KEYCODES.md`](KEYCODES.md).
- **Controller buttons:** GTA control IDs (`206` = RB / R1). Also in [`KEYCODES.md`](KEYCODES.md).

### Checking that it worked

1. Launch with `PlayGTAV.bat` and test the change.
2. If the mod stops working, check its log in the game root: `ScriptHookVDotNet.log` for the .NET mods, `menyoolog.txt` for Menyoo, `asiloader.log` for the `.asi` mods.
3. If you changed a key, check [`HOTKEYS.md`](HOTKEYS.md) for clashes first, and record the new key in `MODS.md` and `HOTKEYS.md`.

---

## 2. Better Chases+

**File:** `scripts/BetterChasesConfig.xml` · **Format:** XML · **In-game menu:** F7 (saves back to this file)

Changes how police chases escalate, how many units respond, and what counts as a crime.

### Top-level options

| Tag | Current | What it does |
| --- | --- | --- |
| `<MenuKey>` | `F7` | Opens the Better Chases+ settings menu. |
| `<SurrenderKey>` | `E` | Keyboard key to surrender during a chase. |
| `<SurrenderButton>` | `Cover` | Controller action used to surrender (the GTA "Cover" control, RB / R1). |
| `<DisplayHints>` | `true` | Show help text. |

### `<BetterChases>` block

| Tag | Current | What it does |
| --- | --- | --- |
| `<Enabled>` | `true` | Master switch for the chase features. |
| `<WantedLevelControl>` | `Full` | How much the mod takes over the wanted level from the game. |
| `<CopsManageTraffic>` | `true` | Police clear traffic during chases. |
| `<WreckedCopsStopChasing>` | `true` | Units with a wrecked car drop out. |
| `<DisallowCopCommandeering>` | `true` | Cops can't steal civilian cars to keep chasing. |
| `<RequirePITAuthorization>` | `true` | Cops only PIT you once a phase or crime authorises it. |
| `<RequireLethalForceAuthorization>` | `true` | Cops only shoot once a phase or crime authorises it. |
| `<AllowBustOpportunity>` | `true` | Gives you a chance to be arrested instead of killed. |
| `<ShowHUD>`, `<ShowNotifications>`, `<ShowBigMessages>` | `true` | On-screen feedback. |
| `<IconOffsetX>`, `<IconOffsetY>` | `0` | Move the HUD icon if it overlaps another mod's HUD. |

**`<ChaseEscalates>`**: a chase goes through `PhaseOne` to `PhaseFour`. In each phase:

- `Enabled`: use this phase.
- `Length`: how long the phase lasts before escalating (30 for all four).
- `WantedLevel`: stars set when the phase starts (`0` keeps the current level; `PhaseFour` sets 3).
- `PITAuthorized`, `LethalForceAuthorized`: unlocks PIT manoeuvres or shooting in this phase.
- `RequestBackup`: more units get called.

To make chases calmer, raise `Length` or set `PhaseFour` `PITAuthorized` to `false`. To make them harsher, authorise force in earlier phases.

**`<CopDispatch>`**: units per wanted level (`OneStar` to `FiveStar`).

- `GroundMin` / `GroundMax`: range of ground units.
- `AirMin`: minimum helicopters.
- `PITAuthorized`, `LethalForceAuthorized`: as above.
- `FiveStar` uses `-1` and `0`, which seems to leave five-star dispatch to the game.

**`<Crimes>`**: one block per crime (`GTA`, `Stolen`, `Speeding`, `Reckless`, `Armed`, `Aiming`, `Assault`, `PoliceAssault`, `Shooting`, `Murder`, `PoliceMurder`).

- `Enabled`: whether cops react to this crime.
- `WantedLevel`: stars given when witnessed.
- `MaxWantedLevel`: highest level this crime alone can reach (`0` on the murder crimes, which appears to mean no cap).
- `PoliceWitnessThreshold`: how readily police notice it. Lower values are stricter.
- `Speed`: speed threshold for `Speeding` (35) and `Reckless` (15). Raise it to be pulled over less.
- `PITAuthorized`, `LethalForceAuthorized`, `RequestBackup`: as above.

### `<ArrestWarrants>` block

| Tag | Current | What it does |
| --- | --- | --- |
| `<Enabled>` | `true` | Escaping a chase leaves an active warrant. |
| `<WarrantLenghts>` (spelled this way in the file, keep it) | 6 / 18 / 24 / 48 / 72 | How long a warrant lasts for each star level (`OneStar` to `FiveStar`). |
| `<SpotSpeed>` | `100` | How fast police recognise you while a warrant is active. |
| `<RememberChase>` | `true` | Police remember the car you escaped in. |
| `<ShowSpottedMeter>`, `<ShowSpottedIndicators>` | `true` | Detection HUD. |
| `*OffsetX`, `*OffsetY` | `0` | Move the warrant HUD elements. |

---

## 3. ImmersifyII

**File:** `scripts/ImmersifyII.ini` · **Format:** INI, comments start with `//` · **In-game menu:** none

NPC behaviour, gang life, dynamic events, security cameras and police scenarios.

> **Don't edit `scripts/ImmersifyIIData.xml`.** It is the mod's save state (event timers), not a settings file.
>
> **Leave `[Auth] Email=` empty** unless you own the Advanced (Patreon) edition. Several options below say `[Advanced only]` and do nothing without it.

Text after `//` on a line is a comment, so `PROCESSED_NPC_LIMIT=15   // ...` is fine. Keep the value directly after `=`.

| Section | Key options (current value) | Notes |
| --- | --- | --- |
| `[General]` | `MOD_ENABLED=true`, `PROCESSED_NPC_LIMIT=15`, `DISABLE_DURING_MISSION=true`, `MOD_TOGGLE_KEY=None` | Lower `PROCESSED_NPC_LIMIT` if you lose FPS. Set `MOD_TOGGLE_KEY` to a free .NET key name (check `HOTKEYS.md`) to switch the mod on and off in game. |
| | `DYNAMIC_WEAPONS=true`, `GANG_COLORED_BLIPS=true`, `HIDE_BLIPS=false`, `DISABLE_NOTIFICATIONS=false` | |
| | `TRAFFIC_ACCIDENT_REPORT_CHANCE=25`, `PED_CHANCE_TO_SURRENDER_VEHICLE=50` | Chances are percentages (0 to 100). |
| | `PROCESS_EACH_NUMBER_OF_TICKS=10` | Higher is lighter on the CPU but slower to react. |
| `[NpcCombat]` | `FLEE_CHANCE=25`, `DISARM_CHANCE=50`, `WRITHE_IF_LOW_HP_CHANCE=30` | Percentages. |
| | `REINFORCEMENTS_ENABLED=true`, `REINFORCEMENTS_SPAWN_CHANCE_PERCENT=50`, `REINFORCEMENT_VEHICLES_ONLY=false` | |
| | `MORALE_ENABLED=true`, `MORALE_BREAK_THRESHOLD=25`, `SURRENDER_CHANCE_PERCENT=50` | Morale is 0 to 100. Raise the threshold and enemies give up sooner. |
| | `PREVENT_ANIMAL_ATTACKS=false`, `DISPLAY_PERSONALITY_BLIPS=false` | |
| `[EnemiesSearch]` | `SEARCH_DURATION_SECONDS=120`, `ENEMY_FOV=75`, `STEALTH_ENEMY_BLIPS_OPACITY=60` | Opacity is 0 to 255. |
| `[DynamicEvents]` | `MINUTES_BETWEEN_ALL_EVENTS=5`, `MINUTES_BETWEEN_EVENTS_OF_SAME_KIND=5`, `MINUTES_BETWEEN_EVENTS_AT_SAME_PLACE=60`, `EVENT_DESPAWN_DISTANCE=200` | Raise the minutes for fewer random events. |
| `[DynamicEventsPool]` | `Chase`, `DriveBy`, `GangWar`, `ShopRobbery`, `PedPickup`, `Mugging`, `HostageSituation` (all `true`) | Set one to `false` to remove that event type. |
| `[BodyMarkers]` | `ENABLED=true`, `DISTANCE_TO_HIDE=400` | Markers on downed NPCs. |
| `[SecurityCameras]` | `ENABLED=true`, `REPORT_SECONDS=3`, `DETECTION_DISTANCE=40` | |
| `[PedHud]` | `ENABLED=false` | Health and morale bars over aimed enemies. Only shows in Windowed or Borderless mode. |
| `[EnhancedInteraction]` | `ENABLED=true`, `USE_OVERLAY_PROMPT=true` | The overlay prompt falls back to a button bar in exclusive fullscreen. |
| `[CopScenarios]` | `ENABLED=true`, `NIGHT_START_HOUR=20`, `NIGHT_END_HOUR=5`, `OUTCOME_WEIGHT_*` | Outcome weights are relative to each other, not percentages. |
| `[GangFirearmsPool]`, `[GangMeleePool]` | `Pistol=5`, `AssaultRifle=1`, `Bat=4`, ... | Weights. Higher means more common. You can add any weapon by its `WeaponHash` name ([list](https://nitanmarcel.github.io/scripthookvdotnet/scripting_v3/GTA.WeaponHash.html)). Set a weight to `0` to remove it. |
| `[GangBlipColors]` | `Ballas=50`, `Families=2`, ... | GTA blip colour IDs. |
| `[GangAliases]` | `Madrazo="Madrazo Cartel"` | Display names. Use quotes when the name has a space. |
| `[GangVehicleColors]` | `Ballas=148,145,142` | Comma-separated vehicle colour IDs ([list](https://wiki.rage.mp/wiki/Vehicle_Colors), ID column). `0` means common colours only. |

---

## 4. MapEditor

**File:** `scripts/MapEditor.xml` · **Format:** XML · **In-game menu:** F2, then its settings page (saves back to this file)

`scripts/MapEditor.xml.bak` is the copy from before F7 was changed to F2. Don't edit the `.bak`.

| Tag | Current | What it does |
| --- | --- | --- |
| `<ActivationKey>` | `F2` | Opens the editor. Every key F2 to F12 is taken, so check `HOTKEYS.md` before changing it. |
| `<Translation>` | `Auto` | Menu language. Matches a file in `scripts/MapEditor/` (`French`, `German`, ...) or `Auto`. |
| `<Gamepad>` | `true` | Controller support. |
| `<CrosshairType>` | `Crosshair` | Cursor style. |
| `<CameraSensivity>` (spelled this way) / `<GamepadCameraSensitivity>` | `30` / `5` | Camera look speed. |
| `<KeyboardMovementSensitivity>` / `<GamepadMovementSensitivity>` | `30` / `15` | Camera move speed. |
| `<InstructionalButtons>`, `<PropCounterDisplay>` | `true` | On-screen hints and prop count. |
| `<SnapCameraToSelectedObject>` | `true` | Camera jumps to the object you select. |
| `<AutosaveInterval>` | `5` | Minutes between autosaves. |
| `<DrawDistance>` | `-1` | `-1` uses the default. |
| `<LoadScripts>` | `true` | Run the scripts attached to saved maps. |
| `<OmitInvalidObjects>` | `true` | Skip objects whose model doesn't exist when loading a map. |

The props, peds and vehicles listed inside MapEditor come from the lists in [section 14](#14-model-and-object-lists).

---

## 5. Stance

**File:** `scripts/Stance.ini` · **Format:** INI, comments start with `;`

| Key | Current | What it does |
| --- | --- | --- |
| `[Keys] stanceKey` | `Y` | Toggle the stance pose. A .NET `Keys` name. |
| `[Settings] overrideStealthButton` | `true` | Also uses the stealth button (LS / L3) for stance, replacing crouch-walk. Set to `false` to keep the normal stealth. |

---

## 6. iFruitAddon2

**File:** `scripts/iFruitAddon2/config.ini` · **Format:** INI

| Key | Current | What it does |
| --- | --- | --- |
| `[General] StartIndex` | `40` | The slot in the phone contact list where added contacts start. Only change it if another mod's contacts overlap or vanish. |

Log: `iFruitAddon2.log`.

---

## 7. FoSAShelter

**File:** `scripts/FoSAShelter.3.cs` · **Format:** C# source, compiled by SHVDN at load

There is no settings file. The options are constants at the top of the class:

| Field | Current | What it does |
| --- | --- | --- |
| `entranceBoundingBox`, `exitBoundingBox` | coordinates near `-489.7, 2233.7, 149.5` | Trigger zones you walk into. |
| `fadeDuration` | `300` | Screen fade in milliseconds. |
| `waitAfterTeleport` | `1000` | Pause after teleporting, in milliseconds, so the interior can load. |
| `Teleport(...)` calls in `OnTick` | positions and headings | Where you appear inside and outside. |

Change only the numbers. If the script has a syntax error, SHVDN won't compile it, and the error appears in `ScriptHookVDotNet.log` and the F4 console.

---

## 8. TrainerV

**File:** `trainerv.ini` (game root, about 6,000 lines) · **Format:** INI, comments start with `//` after a tab · **In-game menu:** F3

The file explains itself in its own text, but it's long. Find a section with your editor's search (`[Defaults]`, `[AddedCars]`, ...).

**Comment rule:** number values can have a `//` comment after a tab, as in `MenuFont=0  //Font for menu`. Keep the value right after `=`. Text values (`ModelName`, `MenuDescription`, ...) take the whole line, so don't put comments after them. Lines starting with `;` are switched off (that's why `; HideMenuKey=115` doesn't take F4 from the SHVDN console; keep it that way).

| Section (line, approx.) | What's in it | How to edit |
| --- | --- | --- |
| `[KeyBindings]` (22) | Menu keys, controller buttons and every direct hotkey. Combos use two keys: `...Key1` is held, `...Key2` is pressed. | Decimal virtual-key codes for keys, GTA control IDs for `Controller*`. The file lists both tables right below the bindings. Check `HOTKEYS.md` before changing one. |
| `[Defaults]` (386) | What's on when the game starts, and menu colours. | `1` turns an option on at startup, `0` off. Examples: `Never_Wanted`, `Always_God`, `NoHelicopters`, `UnlimitedParachute`, `MaxWanted` (1 to 5, used when `Max_Wanted=1`), `StartupHour`/`StartupMinute` (used when `FixedTime=1`), `Weather` (0 to 13). Colours are RGB triples (`MenuColor1/2/3`, `HighLightColor1/2/3`, `NeonColor1/2/3`). **Don't change the lines marked "Used Internally by trainer"** (`Menu`, `HighLight`, `Rect`, `ClockC`, ...). |
| `[BodyGuards]` (568) | Default bodyguard model, weapon, health, driving. | `PedHealth`, `GodMode`, `DrivingSpeed` (18 is about 64 km/h). |
| `[CarColorSlot1]` to `[CarColorSlot6]` | Saved paint jobs. | Easiest to save from the in-game menu. |
| `[ModelClothes1-5]`, `[BModelClothes1-5]` | Saved outfits. | Save from the menu. |
| `[CarSpawnOption1]` to `[CarSpawnOption12]` (953) | The cars spawned by Left Alt + A, B, C, D, E, F, G, M, N, T, U, X. | Set `ModelName` to any model name, including add-ons such as `gxetron` or `urus2018`. `Description` is the notification text, `BlipName` the map label, `Warp=1` puts you in the driver's seat. |
| `[Teleport1Slot0]` to `[Teleport9Slot9]` (1027) | Teleport menu locations. | `x`, `y`, `z` and `MenuDescription`. Get coordinates in game with `DisplayCoordinates=1` or Menyoo's coordinate display. |
| `[AnimationSlot1-10]`, `[BAnimationSlot1-10]` (1512) | Favourite animations. | `AnimationSequence` is the dictionary, `AnimationName` the clip. |
| `[AddedCars]` (1575) | Add-on cars in the TrainerV spawn menu (1,200 slots). | For slot N set `EnableN=1`, `ModelNameN=<model>`, `DisplayNameN=<label>`. The `[Defaults]` option `DefineAddedVehiclesInIni` controls whether this list is used. |
| `[AddedPeds]` (5183) | Add-on peds (200 slots). | Same pattern as cars. |
| `[AddedWeapons]` (5788) | Add-on weapons. | Same pattern. `CModelNameN` / `CDisplayNameN` add an attachment (component) to the weapon. |

---

## 9. Menyoo

**Main file:** `menyooStuff/menyooConfig.ini` · **Format:** INI, comments start with `;` · **In-game menu:** F8 (Settings saves back to this file)

> **Edit with the game closed.** `sync_with_config_at_intervals = true` makes Menyoo rewrite this file every few seconds while running, which undoes any change you make with the game open.

| Section | What's in it | Notes |
| --- | --- | --- |
| `[settings]` | `open_key = 119` (F8), `open_button_for_gamepad_1/2 = 206/189` (RB + D-pad Left), `menuPosX`/`menuPosY`, `language`, `log level` (0 to 3), `manual_respawn_button = 26`, `stop_animation_key = 36` (Home), `DeathModelReset = true` | Keys are decimal virtual-key codes, gamepad values are GTA control IDs. Keep `DeathModelReset = true`; it stops a crash when you die as a non-story ped. |
| `[general]` | `FreeCamButton = 117` (F6) | The controller bind (X + LS) is fixed in Menyoo and can't be changed. |
| `[object-spooner]` | `SpoonerModeHotkey = 120` (F9), `SpoonerModeGamepadBind_1/2 = 206/190` (RB + D-pad Right), camera sensitivities, spawn defaults (`SpawnDynamicProps`, `SpawnInvincibleEntities`, `FreezeEntityWhenMovingIt`, ...) | |
| `[free-camera]` | `default_speed`, `default_fov`, `min/max_speed`, `min/max_fov`, step sizes | FreeCam feel. |
| `[colours]` | `titlebox_*`, `BG_*`, `optiontext_*`, `selectionhi_*`, ... and `gradients`, `rainbow_mode` | Each colour is `_R`, `_G`, `_B`, `_A` from 0 to 255. `_A` is opacity. |
| `[fonts]` | `title`, `options`, `selection`, `breaks`, `font_hud`, `font_speedo` | `0` normal, `1` italic, `2` caps, `4` impact, `7` pricedown. |
| `[hax-values]` | Saved state of every toggle in the menu (`player_invincibility`, `vehicle_spawner_plate_text = MENYOO`, `weapon_damage_multiplier = 0.72`, speedo and clock positions, ...) | Menyoo writes these itself. Change them in game. Editing by hand works but is easy to get wrong. Leave the online-only options (`CloneProtection*`, `player_off_the_radar`, `all_player_trackers`, ...) alone; they do nothing in single player. |

### Other Menyoo files

| File | What it is | How to edit |
| --- | --- | --- |
| `menyooStuff/AddedVehicleModels.xml` | Add-on cars in Vehicle Spawner, Added Models. One line per car: `<VehModel hash="0x87D9502C" /> <!-- gxetron -->`. | Easiest: in game use Vehicle Spawner, "Add New Vehicle Model", and type the model name. Menyoo writes the hash for you. Keep the `<!-- name -->` comment so you can tell entries apart. |
| `menyooStuff/Vehicle/*.xml` | Saved vehicles (Ghost Rider x3, Lamborghini Urus). | Save and load from Vehicle Spawner, Saved Files. Hand edits are possible (colours, mods, attached props) but the in-game editor is safer. |
| `menyooStuff/Outfit/*.xml` | Saved outfits (`GhostRider`). | Save from the wardrobe menu. |
| `menyooStuff/MapMods.xml` | Built-in map mods (object lists with positions). | Add a new `<MapMod>` block in the same shape as the existing ones, or build it with the Spooner and save it from there. |
| `menyooStuff/PedList.xml` | Ped models in the model changer. | Add an entry in the same shape as the others. |
| `menyooStuff/TimecycModifiers.xml` | Screen filters in the timecycle menu. | Rarely needs changes. |
| `menyooStuff/Spooner/`, `WeaponsLoadout/` | Your Spooner saves and weapon loadouts. | Created from the menu. See the `*.readme.txt` in each folder. |
| `menyooStuff/Graphics/`, `Audio/` | Speedo and clock images, sounds. | Replace files with ones of the same name and format. |

---

## 10. Lua mod and GUI menu

**Files:** `scripts/main.lua`, `scripts/keys.lua`, `scripts/libs/GUI.lua`, `scripts/addins/*.lua` · **Format:** Lua code

There is no settings file. You change behaviour by editing code. A Lua syntax error stops every addin from loading, so change one thing at a time and restart the game to test.

| What you want | Where |
| --- | --- |
| Turn the example menu on or off | `scripts/addins/exampleGUI.lua`. Steps are in [`LUA_MENU.md`](LUA_MENU.md). |
| Change menu keyboard keys | `scripts/libs/GUI.lua`, the `GUI.isKeyboardPressed(Keys.NumPad8 / NumPad2 / Space)` calls. Key names come from `scripts/keys.lua`. |
| Change controller buttons | `GUI.controller` table at the top of `scripts/libs/GUI.lua` (GTA `INPUT_FRONTEND_*` IDs). |
| Change the open and close combos | `GUI.openCombo = { "A", "RB", "RL" }` and `GUI.closeCombo = { "B", "LB", "LT" }`. Use names from `GUI.controller`. |
| Add a feature | New file in `scripts/addins/`, copied from `basemodule.lua`. |

Don't edit `scripts/keys.lua` unless a key code is wrong. It is a lookup table, not a list of binds.

---

## 11. ScriptHookVDotNet

**File:** `ScriptHookVDotNet.ini` (game root) · **Format:** INI, comments start with `;`, `#` or `//`

| Key | Current | What it does |
| --- | --- | --- |
| `ConsoleKeyBinding` | `F4` | Opens the SHVDN console, which shows script errors live. |
| `ReloadKeyBinding` | `None` | Key to reload all .NET scripts without restarting. Handy while tuning a `.cs` script; pick a free key from `HOTKEYS.md`. Without it, type `Reload()` in the F4 console. |
| `ScriptTimeoutThreshold` | `5000` | Milliseconds a script may block before SHVDN kills it. |
| `ScriptsLocation` | `"scripts"` | Leave as is. Most mods expect `scripts`. |
| `AutoLoadScripts` | `true` | Set to `false` only to chase random crashes; you then start scripts with `StartAllScripts` in the console. |

Most .NET mods (Better Chases+, ImmersifyII, Stance, iFruitAddon2) only read their config when they start, so `Reload()` also picks up changes to their files.

---

## 12. NoEditorRestrictions

**File:** `NoEditorRestrictions.ini` (game root) · **Format:** INI, comments start with `;` · Affects the Rockstar Editor only

| Key | Current | What it does |
| --- | --- | --- |
| `disable_free_cam_collision_1/2/3` | `true` | Free camera passes through walls while editing, playing back, and blending. |
| `attach_streaming_focus_to_camera` | `false` | Load the world in highest detail around the camera instead of the player. |
| `attach_streaming_focus_to_camera_key` | `0x78` (F9) | Toggles the option above in the editor. **Hex** code. `-1` disables the key. |
| `max_horizontal_free_cam_speed`, `max_vertical_free_cam_speed` | `40` | Free camera top speed. Must be positive. |
| `disable_profanity_filter` | `false` | Allows any project name. |

---

## 13. Engine limit adjusters

These raise hard limits in the game engine. They're read once at startup. Only raise a value when a log or crash tells you a limit was hit (usually after adding many add-on packs, weapons or decals). Lowering below the default can crash the game.

| File | Key | Current | Raise it when |
| --- | --- | --- | --- |
| `HeapAdjuster.ini` | `[HEAP_SETTINGS] HEAP_SIZE` | `750` (MB) | Crashes or "out of memory" while loading many add-on vehicles or maps. |
| `PackfileLimitAdjuster.ini` | `[SETTINGS] packfile_list_size` | `7344` | You add many DLC packs and the game crashes on load. Comments use `#`. |
| `WeaponLimitsAdjuster.ini` | `CWeaponInfoBlob` / `CWeaponComponentInfo` | `512` / `1024` | You add many add-on weapons or attachments. Comments use `#`. |
| `fwBoxStreamerVariable_DecalsLimit-Patch.toml` | `[DecalLimitPatcher] DecalDefs` | `620` (min 512) | Decals stop appearing or the game crashes with many decal mods. |
| | `[fwBoxStreamerVariableSizePatcher] fwBoxStreamerVariableSize` | `6000` (min 1048) | Big map mods (such as the forest packs) cause crashes or missing parts. |

---

## 14. Model and object lists

Name-to-hash lists that the .NET mods (mainly MapEditor) use to show readable names. One entry per line, `Name=hash`:

| File | Contents |
| --- | --- |
| `scripts/VehicleList.ini` | Vehicles, e.g. `Dominator=80636076`. |
| `scripts/PedList.ini` | Peds. |
| `scripts/ObjectList.ini`, `scripts/Expanded ObjectList.ini` | Props for MapEditor. |
| `hashes.ini` (game root) | Vehicles in `hash name` order (a space, not `=`). Which mod reads it hasn't been confirmed. |

To add an add-on model, append a line with its model name and hash. The hash is the GTA "joaat" hash of the lowercase model name. You can read it from Menyoo (`AddedVehicleModels.xml` stores it in hex; convert it to a signed decimal number for these lists), or look it up on a GTA hash site.

---

## 15. Mods with no settings file

| Mod | Why there's nothing to edit |
| --- | --- |
| Cop_Arrest, Disarm | Keys and behaviour are fixed inside the DLL. |
| openCameraV | No config. Log: `openCameraV.log`. |
| OpenIV.asi | Just loads `Mods/`. Changes to the game's own data go through OpenIV and the RPFs in `Mods/` (see [`RPF_TOOLS.md`](RPF_TOOLS.md) and the main `README.md`). |
| LemonUI, NativeUI, ClearScript | Libraries. The `.xml` files next to them (`LemonUI.SHVDN3.xml`, `NativeUI.xml`) are API documentation, not settings. |
| ScriptHookV, dinput8 (ASI loader) | No user settings. |
| BattlEye files | Must stay disabled. Don't edit them. |

---

## 16. Quick reference

| Mod | File | Format | Edit in game? |
| --- | --- | --- | --- |
| Better Chases+ | `scripts/BetterChasesConfig.xml` | XML | Yes, F7 |
| ImmersifyII | `scripts/ImmersifyII.ini` | INI (`//`) | No |
| MapEditor | `scripts/MapEditor.xml` | XML | Yes, F2 |
| Stance | `scripts/Stance.ini` | INI (`;`) | No |
| iFruitAddon2 | `scripts/iFruitAddon2/config.ini` | INI | No |
| FoSAShelter | `scripts/FoSAShelter.3.cs` | C# | No |
| TrainerV | `trainerv.ini` | INI (`//`) | Partly, F3 |
| Menyoo | `menyooStuff/menyooConfig.ini` and `menyooStuff/*.xml` | INI (`;`), XML | Yes, F8 |
| Lua GUI | `scripts/libs/GUI.lua`, `scripts/addins/*.lua` | Lua | No |
| SHVDN | `ScriptHookVDotNet.ini` | INI | No |
| NoEditorRestrictions | `NoEditorRestrictions.ini` | INI (`;`) | No |
| Heap / Packfile / Weapon limits | `HeapAdjuster.ini`, `PackfileLimitAdjuster.ini`, `WeaponLimitsAdjuster.ini` | INI | No |
| Decal and streamer limits | `fwBoxStreamerVariable_DecalsLimit-Patch.toml` | TOML | No |
| Model lists | `scripts/VehicleList.ini`, `PedList.ini`, `ObjectList.ini` | INI | No |
| Mod Guide | `scripts/ModGuide.ini` (keys), `scripts/ModGuide.xml` (the mod list: one `<Mod>` per entry, one `<Control>` per key) | INI (`;`), XML | No. Edit with the game closed or use `Reload()` in the F4 console. Source in `ModDevelopment/MyMods/ModGuide/`. |
