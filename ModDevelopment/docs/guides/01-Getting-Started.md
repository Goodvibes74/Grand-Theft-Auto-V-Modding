# 01 Getting started

How mods run inside the game, which languages to learn, and how to set up Visual Studio.

> **Sources:** tool versions from the Visual Studio Installer (`vswhere`) and `dotnet --list-sdks` on this PC, 2026-10-09. Load order from `asiloader.log`. References from `ModDevelopment/Directory.Build.props`. Details: [Where everything comes from](../README.md#where-everything-comes-from).

## How a mod runs

```text
GTA5.exe starts
 └─ dinput8.dll (ASI loader) loads every *.asi in the game folder
     ├─ ScriptHookV.dll       hooks the game's script engine. Gives mods: "call native", "wait a frame", key events
     ├─ your C++ mod (.asi)   calls ScriptHookV directly                          (guide 04)
     ├─ ScriptHookVDotNet.asi starts .NET and loads scripts/*.dll and scripts/*.cs (guides 02, 03)
     │    └─ your C# mod      uses ScriptHookVDotNet3.dll + LemonUI.SHVDN3.dll
     └─ LUA.asi               runs scripts/main.lua, which loads scripts/addins/*.lua  (guide 06)
```

Every kind of mod works the same way underneath:

1. **A loop runs once per frame.** C# has the `Tick` event, C++ a `while (true)` loop with `scriptWait(0)`, Lua a `tick()` function.
2. **Inside the loop you call native functions,** the game's own API (`PLAYER_PED_ID`, `CREATE_VEHICLE`, `SET_ENTITY_COORDS`, ...).
3. **Then you give the frame back to the game.** If your loop takes too long, the game stutters. If it never returns, the game freezes.

Natives can only be called from a script thread, inside that loop. Not from a constructor in C++ (`DllMain`), not from a background thread.

## Languages to learn

| Language | Needed for | How much you need | Where to learn |
| --- | --- | --- | --- |
| **C#** | SHVDN scripts, the main path | Classes, properties, events and lambdas (`+= (s, e) => ...`), lists, `foreach`, enums | Microsoft Learn: "C# for beginners" and "Take your first steps with C#" (learn.microsoft.com/dotnet/csharp) |
| **C++** | `.asi` mods | Functions, pointers, structs, headers, `#include`. Modern C++ (17/20) helps | learncpp.com |
| **Lua 5.2** | Quick scripts with `LUA.asi` | Tables, functions, `require`, modules | "Programming in Lua" (lua.org/pil, first edition is free) |
| **XML / INI** | Mod settings, `.csproj`, game `.meta` files | Reading and editing | Any short tutorial |
| **GTA concepts** | All of the above | Entities and handles, models and hashes, natives, controls | This folder, and docs/reference/natives |

Start with C#. It has the best documentation, the most examples online, and the safest failure mode: an exception is logged and the game keeps running, while a C++ bug crashes the game.

## Key GTA concepts

- **Handle:** a number the game gives you for a thing in the world (ped, vehicle, object, blip, camera). In C#, SHVDN wraps it in a class (`Ped`, `Vehicle`). In C++ and Lua it's a plain `int`.
- **Entity:** anything physical in the world: a ped, vehicle or object (prop).
- **Ped:** any person or animal, including the player's character.
- **Model:** what an entity looks like (`adder`, `a_m_y_hipster_01`). Identified by a **hash**, a 32-bit number computed from the name (`joaat("adder")`). A model must be **requested** (loaded) before you create something with it.
- **Native:** one of the game's built-in script functions. See [guide 05](05-Natives.md).
- **Control:** a game action (`INPUT_JUMP`, `INPUT_FRONTEND_ACCEPT`) that maps to a key or button. Use controls for controller support, and keys for keyboard shortcuts.
- **Mission entity / no longer needed:** entities you create stay until you delete them or mark them as no longer needed. Forgetting this leaks memory and fills the world.

## Tools

What's installed on this PC, checked on 2026-10-09:

| Tool | Installed | Used for |
| --- | --- | --- |
| Visual Studio Community 2026 | Yes, with **.NET desktop development** | Editing and debugging C# scripts |
| Visual Studio Build Tools 2026 | Yes, with **C++ build tools** (MSVC 14.51, toolset v145, Windows SDK 10.0.26100) | Command-line builds of C++ `.asi` mods |
| .NET SDK | 10.0.103 and 10.0.401 | `dotnet build`, `dotnet run` |
| .NET Framework 4.8 targeting pack | Yes | SHVDN scripts target .NET Framework 4.8 |
| Visual Studio Community C++ workload | **No** | Needed to open and edit `.vcxproj` projects in the IDE. See [guide 08](08-Manual-Steps.md#1-install-the-c-workload-in-visual-studio-community) |

### Visual Studio settings for this repo

Nothing needs setting by hand for C#: `ModDevelopment/Directory.Build.props` sets the target framework and references, and `.editorconfig` sets the code style. Recommended options:

- **Tools > Options > Projects and Solutions > Build and Run:** set "On Run, when build or deployment errors occur" to "Do not launch", so a failed build doesn't start the game.
- **Tools > Options > Debugging > General:** turn off "Enable Just My Code" if you want to step into SHVDN's code while debugging.

### References a C# script needs

All set by `Directory.Build.props`, listed here so you know what they are:

| Reference | File | Why |
| --- | --- | --- |
| `ScriptHookVDotNet3` | `<game>\ScriptHookVDotNet3.dll` | The SHVDN v3 API (`GTA`, `GTA.UI`, `GTA.Native`, `GTA.Math` namespaces) |
| `LemonUI.SHVDN3` | `<game>\scripts\LemonUI.SHVDN3.dll` | Menus |
| `System.Windows.Forms` | .NET Framework | `Keys` and `KeyEventArgs` for keyboard events |
| `System.Drawing` | .NET Framework | `Color`, `PointF`, `SizeF` for UI |
| `iFruitAddon2` (optional) | `<game>\scripts\iFruitAddon2.dll` | Phone contacts. Add it in your `.csproj` like `Samples/Samples.csproj` does |

All are marked `Private=false` (not copied), because the game already has them. Never ship a copy of `ScriptHookVDotNet3.dll` with your mod.

## Your first C# script, step by step

1. From the game folder, create a project:

   ```powershell
   powershell -ExecutionPolicy Bypass -File ModDevelopment\New-ModScript.ps1 -Name MyFirstMod
   ```

2. Open `ModDevelopment\ModDevelopment.slnx` in Visual Studio. `MyFirstMod` is in Solution Explorer.
3. Pick a free key (see `docs/mods_info/HOTKEYS.md`) and set it in `scripts\MyFirstMod.ini`, for example `MenuKey=Pause`.
4. Edit `MyFirstModScript.cs`. Copy ideas from `ModDevelopment/Samples/`.
5. Close the game, then build (Ctrl+Shift+B). The Output window shows `MyFirstMod copied to ...\scripts\`.
6. Right-click `MyFirstMod` > **Set as Startup Project**, then **Ctrl+F5** starts the game.
7. In story mode, press your key. If nothing happens, press **F4** for the SHVDN console, and read `ScriptHookVDotNet.log`.

## Where to read next

- C# scripting: [02](02-SHVDN3-Scripting.md), then menus in [03](03-Menus-and-UI.md).
- C++: [04](04-ScriptHookV-CPP.md).
- Anything the libraries don't wrap: [05 natives](05-Natives.md).
