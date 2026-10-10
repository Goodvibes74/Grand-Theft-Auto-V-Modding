# MyMods

The mods we wrote ourselves for this install. One folder per mod, each with its source code and its own README.

New C# mods are created here by `New-ModScript.ps1`. For a new C++ mod, copy `HelloAsi` (see [guide 04](../docs/guides/04-ScriptHookV-CPP.md#making-your-own-c-mod)).

## The mods

| Mod | What it does | Use case | Language and dependencies | Installed? | Tested in game? |
| --- | --- | --- | --- | --- | --- |
| [ModGuide](ModGuide/README.md) | In-game menu that lists every installed mod: what it does, how to activate it, and its keyboard, Xbox and PlayStation controls. | You forget which key opens which mod, or want to check controller buttons without leaving the game. Also the reference example of a real LemonUI menu mod in this repo. | C#, SHVDN v3, LemonUI | Yes: `scripts/ModGuide.dll`, with `scripts/ModGuide.ini` and `scripts/ModGuide.xml` | Not yet |
| [HomeInvasion](HomeInvasion/README.md) | Rob houses around the map. Our build of the 2019 mod with configurable police behaviour (wanted level, dispatch delay, SWAT and cop weapons). | Tune how hard the police respond to a house robbery, or hand the response to RDE. | C#, SHVDN v2, NativeUI | Yes: `scripts/HomeInvasion.dll` and `scripts/HomeInvasion.xml` | Not yet |
| [GTAOnlineOffline](GTAOnlineOffline/README.md) | Single-player recreation of the GTA Online start: intro, character creator, Lester menus, apartment, Fleeca heist. Decompiled 2021 mod, patched for LemonUI 2.x. | Play the Online story offline, and the base for adding newer Online content. | C#, SHVDN v3, LemonUI, NAudio | Yes: `scripts/GTAOnline_Offline.dll` | Rebuilt after the character creator crash; not retested |
| [HelloAsi](HelloAsi/) | Shows a notification when the game finishes loading. With a toggle key set, draws the player's coordinates on screen. | Starting point for a C++ `.asi` mod. Proves the C++ toolchain (headers, import library, build settings) works. Copy it to start your own. | C++, ScriptHookV (through `../cpp/ShvSdk`) | No: build output stays in `HelloAsi/bin/`. Copy the `.asi` to the game folder to try it | Not yet |

### ModGuide

- **Open:** F12, or hold RB and press D-pad Down (R1 + D-pad Down).
- **Edit the content:** `scripts/ModGuide.xml`, no rebuild needed.
- **Build:** `dotnet build -c Release ModDevelopment/MyMods/ModGuide/ModGuide.csproj` (copies into `scripts/`).
- **Maintain:** whenever a mod or keybind changes, update `scripts/ModGuide.xml`. Full instructions: [ModGuide/README.md](ModGuide/README.md).

### HelloAsi

- **Build:** `MSBuild ModDevelopment\MyMods\HelloAsi\HelloAsi.vcxproj -p:Configuration=Release -p:Platform=x64`, or open `ModDevelopment.Cpp.slnx` in Visual Studio (needs the C++ workload).
- **Try it:** copy `bin\Release\HelloAsi.asi` into the game folder, launch, and look for the "HelloAsi loaded" notification. Delete it from the game folder afterwards.
- **Turn on the coordinates display:** set `ToggleKey` in `script.cpp` to a free key (`docs/mods_info/HOTKEYS.md`), for example `VK_PAUSE`, and rebuild.

## Examples (not mods)

`../Samples/` holds the C# examples used in the guides. They are compiled to check they still work against the installed libraries, but never installed. Copy the one you need into your own mod.

| Sample | Shows how to | Guide |
| --- | --- | --- |
| `01_HelloWorld.cs` | Run code every frame and react to a key | [02](../docs/guides/02-SHVDN3-Scripting.md) |
| `02_PlayerAndWorld.cs` | Spawn a car, arm the player, teleport to the waypoint, calm nearby peds, clean up | [02](../docs/guides/02-SHVDN3-Scripting.md) |
| `03_Natives.cs` | Call natives, with return values and output parameters | [05](../docs/guides/05-Natives.md) |
| `04_LemonMenu.cs` | Build a menu with buttons, a checkbox, a list, a slider and a submenu | [03](../docs/guides/03-Menus-and-UI.md) |
| `05_PhoneContact.cs` | Add a phone contact that does something when called | [03](../docs/guides/03-Menus-and-UI.md) |
| `06_SettingsAndText.cs` | Read and save an ini file, draw a speedometer on screen | [02](../docs/guides/02-SHVDN3-Scripting.md) |

## Adding a mod here

1. C#: `powershell -ExecutionPolicy Bypass -File ModDevelopment\New-ModScript.ps1 -Name <Name>` creates `MyMods\<Name>\` and adds it to the solution. C++: copy `HelloAsi`.
2. Pick its keys from the free ones in `docs/mods_info/HOTKEYS.md`.
3. When it works, add a row to the table above, an entry to `scripts/ModGuide.xml`, and its keys to `docs/mods_info/MODS.md` and `HOTKEYS.md`.
