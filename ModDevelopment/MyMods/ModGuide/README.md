# Mod Guide: updating and maintaining

Mod Guide is an in-game menu that lists every installed mod, what it does, and how to use it on keyboard, Xbox and PlayStation. Open it with **F12**, or hold **RB** and press **D-pad Down** (R1 + D-pad Down on PlayStation).

Most updates are edits to one XML file and don't need a rebuild. You only rebuild after changing the C# code.

## Files

| File | What it is | Rebuild after editing? |
| --- | --- | --- |
| `scripts/ModGuide.xml` | The menu content: every mod, its description and its controls. | No |
| `scripts/ModGuide.ini` | The open key, the controller combo, and whether controller names show as Xbox or PlayStation. | No |
| `ModDevelopment/ModGuide/ModGuideScript.cs` | The script: reads the two files above and builds the LemonUI menu. | Yes |
| `ModDevelopment/ModGuide/ModGuide.csproj` | Project file. Shared settings (.NET Framework 4.8, SHVDN and LemonUI references, the copy into `scripts/`) come from `ModDevelopment/Directory.Build.props` and `.targets`. | Yes |
| `scripts/ModGuide.dll`, `scripts/ModGuide.pdb` | Build output, loaded by ScriptHookVDotNet. Never edit these. | n/a |

The source has to stay in `ModDevelopment/`. SHVDN compiles every `.cs` file it finds in `scripts/`, so a copy of `ModGuideScript.cs` there would load a second copy of the menu.

## When to update it

Update `scripts/ModGuide.xml` every time you:

- install or remove a mod,
- change a keybind in any mod's config (`trainerv.ini`, `menyooConfig.ini`, `BetterChasesConfig.xml`, ...),
- add an add-on vehicle, map or saved Menyoo item,
- learn something new about a mod, such as the key for Cop_Arrest or Disarm.

Make the same change in `docs/mods_info/MODS.md`. The guide and that doc should always say the same thing. If you changed a key, check `docs/mods_info/HOTKEYS.md` first for clashes.

## Editing the mod list (`scripts/ModGuide.xml`)

Close the game first, or press F4 in game and type `Reload()` afterwards.

Each `<Mod>` is one entry in the menu, shown in the order it appears in the file:

```xml
<Mod name="Better Chases+">
  <Description>What the mod does, in a sentence or two.</Description>
  <Activate>How to turn it on or open it.</Activate>
  <Config>scripts/BetterChasesConfig.xml</Config>
  <Control action="Settings menu" keyboard="F7" />
  <Control action="Surrender" keyboard="E" xbox="RB (cover)" playstation="R1 (cover)" note="Only during a chase." />
</Mod>
```

| Part | Required | Shown as |
| --- | --- | --- |
| `name` | yes | The entry in the main list, and the subtitle of the mod's page. |
| `<Description>` | yes | The "What it does" line. Also shown when you move over the mod in the main list. |
| `<Activate>` | no | The "How to activate" line. |
| `<Config>` | no | The "Settings file" line. |
| `<Control>` | no, repeatable | One line per control. `action` is the line's title. `keyboard`, `xbox` and `playstation` are the buttons; any you leave out show as "none". `note` is optional extra text. |

### Rules

- **Never use `~`.** GTA reads it as a text formatting code, so it garbles the line. Write "tilde" if you need the word.
- **Escape XML characters** inside text and attributes: `&` as `&amp;`, `<` as `&lt;`, `>` as `&gt;`, and `"` inside an attribute as `&quot;`. Apostrophes are fine.
- **Keep text short.** Descriptions show in a box at the bottom of the menu. Two or three sentences fit well. Line breaks in the file are turned into spaces.
- **Write controller buttons the same way everywhere:** Xbox `A`, `B`, `X`, `Y`, `LB`, `RB`, `LT`, `RT`, `LS click`, `RS click`, `D-pad Up`. PlayStation `Cross`, `Circle`, `Square`, `Triangle`, `L1`, `R1`, `L2`, `R2`, `L3`, `R3`. Write combos as `RB + X`.
- **Add a note when a key hasn't been checked in game**, for example `note="Controller button not yet checked in game."`.

### Check the file before launching

A broken XML file leaves the menu with a single error line. Check it from the game folder with:

```powershell
[xml](Get-Content -Raw -Encoding UTF8 scripts/ModGuide.xml) | Out-Null; "OK"
```

If the file is valid, this prints `OK`. Otherwise it gives the line and position of the error.

## Changing the open key (`scripts/ModGuide.ini`)

| Setting | Default | Accepts |
| --- | --- | --- |
| `MenuKey` | `F12` | A .NET `Keys` name: `F12`, `Pause`, `NumPad5`, `OemSemicolon`, ... |
| `ControllerHold` | `FrontendRb` | A SHVDN `GTA.Control` name. `FrontendRb` is RB / R1. |
| `ControllerPress` | `FrontendDown` | A SHVDN `GTA.Control` name. `FrontendDown` is D-pad Down. |
| `ControllerType` | `Xbox` | `Xbox` or `PlayStation`. The game can't tell the two apart, so this decides which names show when you open the guide with a controller. |

A misspelled name is ignored and the default is used. Every function key from F2 to F12 is taken, and RB is already the first button of four other combos, so check `docs/mods_info/HOTKEYS.md` before you pick a new key. Record the change in `HOTKEYS.md`, `MODS.md`, and the "Mod Guide" entry at the top of `ModGuide.xml`.

## Changing the code

### Build

Run from the game folder:

```bash
dotnet build -c Release ModDevelopment/ModGuide/ModGuide.csproj
```

The build compiles against `ScriptHookVDotNet3.dll` (game root) and `scripts/LemonUI.SHVDN3.dll`, and then copies `ModGuide.dll` and `ModGuide.pdb` into `scripts/`. Close the game before building, because Windows locks a DLL that is in use and the copy fails.

What's needed: the .NET SDK (10.x is installed) and the .NET Framework 4.8 targeting pack (installed with Visual Studio Build Tools 2026). You can also open `ModGuide.csproj` in Visual Studio Community 2026 for autocomplete.

### How the code is laid out

All of it is in `ModGuideScript.cs`:

| Part | What it does |
| --- | --- |
| `LoadSettings()` | Reads `ModGuide.ini`. |
| `LoadMods()` | Reads `ModGuide.xml` into `ModEntry` and `ModControl` objects. Add a new XML field here. |
| `BuildMenus()` | Creates the main menu and one LemonUI submenu per mod. Every menu has to be added to `pool`, or it never draws. |
| `RefreshControlLabels()` | Fills the right-hand column with the keyboard, Xbox or PlayStation names, depending on "Show controls for". |
| `OnTick()` | Draws the menus and checks the controller combo. The combo only counts while a controller is the last input used, because the frontend controls also map to keyboard keys. |
| `OnKeyDown()` | Opens and closes the menu with `MenuKey`. |

Two warnings you'll see in the code:

- `Game.IsControlPressed` and `Game.IsControlJustPressed` are marked obsolete in SHVDN 3.7. They still work. Their replacement takes a different control type that can't be named in the ini, so the warning is switched off around those lines.
- In GTA text, `~n~` starts a new line and `~r~` / `~s~` set colours. That's why descriptions in the code use `~n~`, and why `~` is banned in the XML.

### Test

There's no automatic test. After building:

1. Launch the game with `PlayGTAV.bat`.
2. Look in `ScriptHookVDotNet.log` for `ModGuide` starting without an exception.
3. In game, open the guide with F12 and with the controller combo. Open a few mods and check their text.
4. Press F4 for the SHVDN console. Script errors show there too.

## After an update to SHVDN, LemonUI or the game

- **SHVDN update:** rebuild, so the DLL compiles against the new `ScriptHookVDotNet3.dll`. If it fails, the build error names the API that changed.
- **LemonUI update:** rebuild the same way. Menu classes (`NativeMenu`, `NativeItem`, `NativeListItem`) sometimes change between major versions.
- **Game update:** usually nothing changes here. If every script stops loading, update ScriptHookV first (see `ScriptHookV.log`).

## Troubleshooting

| Symptom | Likely cause | Fix |
| --- | --- | --- |
| Nothing opens, nothing in the log | SHVDN didn't load, or `ModGuide.dll` is missing from `scripts/`. | Check `asiloader.log` and `ScriptHookVDotNet.log`. Rebuild. |
| The menu shows "ModGuide.xml could not be read" | Broken XML. | Run the check command above and fix the line it reports. |
| F12 opens something else too | Another program uses F12 (Steam screenshots, an overlay). | Change `MenuKey` in the ini. |
| The controller combo does nothing | The last input was the keyboard, or `ControllerHold` / `ControllerPress` is misspelled. | Touch a stick first, and check the names in the ini. |
| Garbled text in one line | A `~` in `ModGuide.xml`. | Remove it. |
| The build says it "cannot copy" | The game is running and has the DLL locked. | Close the game and build again. |

## Committing

Commit the source (`ModDevelopment/ModGuide/*.cs`, `*.csproj`, this README), `scripts/ModGuide.xml`, `scripts/ModGuide.ini`, and the built `scripts/ModGuide.dll` and `.pdb`, so the game works straight from a checkout. `bin/` and `obj/` are gitignored.
