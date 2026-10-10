# Hotkeys and conflicts

Which keys clash between mods, what was fixed, and the rules for giving a mod a new key. The full list of what each key does is in [`MODS.md`](MODS.md). Key code numbers are in [`KEYCODES.md`](KEYCODES.md).

## Rules for a new keybind

1. Check [`MODS.md`](MODS.md) section 1 and the open conflicts below before you pick a key.
2. Every function key from F2 to F12 is taken. F2, Y and Home were picked on 2026-10-09, and F12 went to the Mod Guide the same day.
3. On controller, TrainerV, Menyoo and the Spooner all start with RB / R1. Give a new combo a different second button.
4. After the change, update [`MODS.md`](MODS.md) and this file.

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

## Conflicts

### Fixed on 2026-10-09

| Key | Was used by | Fix |
| --- | --- | --- |
| F3 | TrainerV menu and Menyoo FreeCam | Menyoo FreeCam moved to **F6** (`FreeCamButton = 117`). F10 was not an option because TrainerV uses it for teleport. |
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
| Low | E | Better Chases+ surrender, HomeInvasion enter/exit/intimidate, and the game's E | Better Chases+ only acts during a chase. HomeInvasion only acts at a red marker or inside a robbed home, but a robbery can start a chase, so mind which E you press. |
| Low | F5 | GTA Online - Offline phone (only when its phone is unlocked) and TrainerV god mode (Right Ctrl + F5) | The mod reacts to F5 with or without Ctrl, so the god-mode combo also opens its phone. Rebind one of them if it bothers you. |
| Low | Numpad 8 / 2, Space | Lua GUI, TrainerV menu and airbreak, the game's Space | Only if the Lua GUI is enabled (off by default) and open along with TrainerV. |
| Low | RB / R1 combos | TrainerV (+ X / Square), TrainerV airbreak (+ LS / L3), Menyoo (+ D-pad Left), Spooner (+ D-pad Right), Mod Guide (+ D-pad Down) | Fine while the second buttons differ. TrainerV menu navigation uses the D-pad, so holding RB while moving in TrainerV can open Menyoo. |

### Check in game

- **New keys:** F2, Y, Home and F12 aren't used by any other mod. Check that they don't collide with your own GTA key settings (Settings, Keyboard / Mouse, Key Bindings). This matters most if you've bound Rockstar Editor actions to F2. Also check that F12 doesn't take a Steam screenshot or open an overlay.
- **Lua GUI controller IDs (fixed 2026-10-09):** `scripts/libs/GUI.lua` had wrong control IDs (Up and Down swapped, R3 was really LB, LT was really RB), required all three combo buttons to go down in the same frame, and only looked for the `PAD` native namespace while LUA.asi uses `CONTROLS`. All three are fixed. The combos now use the `INPUT_FRONTEND_*` IDs, so on keyboard Enter + E + Left Ctrl also opens the menu and Backspace + Q + Page Down closes it.
- **F4:** SHVDN console. TrainerV's `HideMenuKey=115` (F4) is commented out in `trainerv.ini`. Leave it commented out.

