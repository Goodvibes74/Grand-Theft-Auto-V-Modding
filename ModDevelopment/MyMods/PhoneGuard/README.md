# PhoneGuard

Keeps the phone shut while a TrainerV or Menyoo menu is open.

On a controller, D-pad Up is both "menu up" and the phone button (`INPUT_PHONE`, control 27), and on the keyboard the Up arrow is both too. Neither trainer blocks the phone while its menu is open, and neither tells other scripts whether its menu is open. PhoneGuard guesses it from their buttons and disables `INPUT_PHONE` while it thinks a menu is open.

## How it guesses

- **Opened or closed:** F3 or RB + X (TrainerV), F8 or RB + D-pad Left (Menyoo). Each press flips the state.
- **Still open:** any menu input (D-pad, A, Num 2/4/5/6/8, arrows, Enter) keeps it open.
- **Closed:** two back presses (B, Backspace or Num 0) within a second, or one back press followed by 3 s with no menu input, or 20 s with no menu input at all.
- It reads the buttons with `IS_DISABLED_CONTROL_*`, because Menyoo disables the menu controls while it is open. With the plain checks it saw no input and gave up after 20 s (fixed 2026-10-11).

It is a guess. If it gets out of step (the phone won't open with no menu on screen), press B twice. That always resets it.

## Other mods

- It publishes its guess as the AppDomain flag `PhoneGuard.MenuOpen`. The CruelMasters phone reads it, because that script ticks before PhoneGuard and would see the control disable too late.
- The Mod Guide (`ModGuide.MenuOpen`), the Lua GUI and the CruelMasters menus block the phone themselves. PhoneGuard doesn't need to know about them.

## Files

| File | What it is |
| --- | --- |
| `ModDevelopment/MyMods/PhoneGuard/PhoneGuardScript.cs` | The script. |
| `scripts/PhoneGuard.ini` | Settings: the trainers' keyboard keys (must match `trainerv.ini` and `menyooConfig.ini`) and the two timeouts. |
| `scripts/PhoneGuard.dll`, `scripts/PhoneGuard.pdb` | Build output, copied there on every build. |

## Controls

None of its own. It only reacts to the trainers' buttons.

## Build

Open `ModDevelopment/ModDevelopment.slnx` in Visual Studio and build, or run
`dotnet build -c Release ModDevelopment/MyMods/PhoneGuard/PhoneGuard.csproj` from the game folder.
