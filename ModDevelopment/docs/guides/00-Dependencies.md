# 00 What each dependency is for

Every library and plugin you can build on in this install: what it is, what you need it for, what you get out of it, its limits, and which installed mods already use it. Read this first to decide what to build with.

> **Sources:** versions and dependencies from [`../reference/Installed-Files.md`](../reference/Installed-Files.md) (file metadata). "Imports ScriptHookV" from each `.asi`'s import table (`dumpbin /dependents`). "Who uses it" from each mod's .NET references and `ScriptHookVDotNet.log`. Details: [Where everything comes from](../README.md#where-everything-comes-from).

## How they stack

```text
GTA5.exe
 └─ dinput8.dll  ASI loader ................ loads every .asi in the game folder
     ├─ ScriptHookV.dll ..................... lets mods call the game's natives, once per frame
     │   ├─ your C++ mod (.asi) ............. uses cpp/ShvSdk headers
     │   ├─ ScriptHookVDotNet.asi ........... runs .NET mods
     │   │   ├─ ScriptHookVDotNet3.dll ...... v3 API  ── LemonUI.SHVDN3.dll, iFruitAddon2.dll
     │   │   └─ ScriptHookVDotNet2.dll ...... v2 API  ── NativeUI.dll (+ old "v1" mods)
     │   ├─ LUA.asi ......................... runs Lua scripts ── scripts/libs/GUI.lua
     │   └─ Menyoo.asi, TrainerV.asi ........ trainers
     └─ OpenIV.asi, limit adjusters, openCameraV, NoEditorRestrictions
                                              patch the game directly, no ScriptHookV needed
```

If a layer is missing or broken, everything above it stops working. After a game update, `ScriptHookV.dll` is usually what breaks, which takes down every script mod at once.

## Quick choice

| I want to... | Use |
| --- | --- |
| Make a normal mod with a menu | SHVDN v3 + LemonUI (C#) |
| Add a phone contact that triggers something | SHVDN v3 + iFruitAddon2 |
| Try an idea in five minutes without compiling | Lua plugin |
| Make a simple button menu in Lua | Lua plugin + `GUI.lua` |
| Get maximum speed, draw with DirectX, or read game memory | ScriptHookV directly (C++) |
| Do something no library offers | A native, from any of the above |
| Fix or update an old mod | SHVDN v2 / NativeUI, then port to v3 |

---

## ASI loader (`dinput8.dll`)

- **What it is:** Alexander Blade's loader for GTA V Legacy (1.0.0.1, 2015). The game loads `dinput8.dll` from its own folder, and this one then loads every `*.asi` file next to `GTA5.exe`.
- **You need it for:** anything that ships as an `.asi`: ScriptHookV-based mods, SHVDN, the Lua plugin, trainers, OpenIV, the limit adjusters, and your own C++ mods.
- **What you get:** your `.asi` running inside the game process, plus `asiloader.log` listing what loaded.
- **Limits:** only loads from the game folder, not subfolders.
- **You don't call it.** Just drop your `.asi` next to `GTA5.exe`.
- **Note:** `xinput1_4.dll` is a second ASI loader built for GTA V *Enhanced*. It's inactive here and you don't need it.

## ScriptHookV (`ScriptHookV.dll`)

- **What it is:** Alexander Blade's script hook (3889.0, game build 3725). The foundation of every script mod.
- **You need it for:** calling the game's native functions from a mod, running a script loop every frame, and getting keyboard events. SHVDN, the Lua plugin, Menyoo and TrainerV all import it.
- **What you get (C++):** 24 functions: register a script loop, wait a frame, call any native, a keyboard hook, draw textures, hook DirectX presentation, list all entities, read script globals. All listed in [`main.h`](../../cpp/ShvSdk/include/main.h).
- **Limits:** C++ only, with no safety net: a bug crashes the game. Breaks after every game update until a new version comes out. Blocks GTA Online by design.
- **Use it directly when:** you need speed (thousands of entities per frame), DirectX overlays, or memory access. Otherwise use SHVDN, which wraps it.
- **Guide:** [04](04-ScriptHookV-CPP.md).

## Our C++ SDK (`ModDevelopment/cpp/ShvSdk/`)

- **What it is:** headers and build settings written for this repo from ScriptHookV's export table, plus `natives.hpp` generated from NativeDB.
- **You need it for:** building C++ `.asi` mods, in place of the official ScriptHookV SDK download.
- **What you get:** all 24 ScriptHookV functions declared, all 6,701 natives as named C++ functions (`PLAYER::PLAYER_PED_ID()`), and an import library built automatically. It matches the installed ScriptHookV exactly.
- **Limits:** no sample projects beyond `MyMods/HelloAsi`. `getGameVersionInfo()` is left out because its return layout isn't published.

## ScriptHookVDotNet runtime (`ScriptHookVDotNet.asi`)

- **What it is:** the host for .NET mods (assembly version 3.7.0.189). Imports ScriptHookV.
- **You need it for:** any C# (or VB.NET) mod. It loads `scripts/*.dll` and `scripts/*.cs`, and works out which API version each one targets.
- **What you get:** script loading and reloading without restarting the game, the **F4 console** (9 commands: `Reload()`, `ListScripts()`, `Abort(...)`, ...), exception logging to `ScriptHookVDotNet.log`, and settings in `ScriptHookVDotNet.ini`.
- **Limits:** its own public types are internal plumbing; don't call them, use the v3 API.
- **Reference:** [SHVDN-Runtime](../reference/SHVDN-Runtime/README.md).

## SHVDN v3 API (`ScriptHookVDotNet3.dll`)

- **What it is:** the current C# API (3.7.0.189).
- **You need it for:** every new C# mod.
- **What you get:** an object model of the game: `Game.Player.Character`, `Ped`, `Vehicle`, `World`, tasks, weapons, blips, cameras, UI text and notifications, ini settings, and `Function.Call` for any native. Events for every frame (`Tick`) and every key (`KeyDown`). Exceptions are logged instead of crashing the game.
- **Limits:** a bit slower than C++ (fine for nearly everything). Some 3.7 members have no description in the reference, because the official docs are from 3.6.
- **Who uses it here:** Better Chases+, ImmersifyII, iFruitAddon2, LemonUI, ModGuide, `FoSAShelter.3.cs`.
- **Guide:** [02](02-SHVDN3-Scripting.md). **Reference:** [SHVDN3](../reference/SHVDN3/README.md).

## SHVDN v2 API (`ScriptHookVDotNet2.dll`)

- **What it is:** the previous C# API (2.11.6), kept so older mods run. SHVDN logs a deprecation warning when it's used.
- **You need it for:** running old mods. Nothing new.
- **What you get:** the same basic ideas as v3 (`Script`, `Tick`, `Game`, `World`), with older names (`UI.Notify`, `UIText`).
- **Limits:** deprecated and unmaintained, and it may be dropped in a future SHVDN release.
- **Who uses it here:** NativeUI, plus the four "v1" mods below.
- **Guide:** [07](07-Legacy-SHVDN2-NativeUI.md). **Reference:** [SHVDN2](../reference/SHVDN2/README.md).

## "SHVDN v1" (`ScriptHookVDotNet` 0.0.0.0)

- **What it is:** not a file. It's the name the v2 API had before SHVDN 2.10. Mods built back then reference `ScriptHookVDotNet` 0.0.0.0.
- **You need it for:** nothing. SHVDN redirects those mods to the v2 API automatically.
- **Who uses it here:** Cop_Arrest, Disarm, MapEditor, Stance. They work now, but they'll be the first to break if SHVDN drops v2. If one breaks, look for an updated version of the mod.

## LemonUI (`scripts/LemonUI.SHVDN3.dll`)

- **What it is:** a menu and UI library for SHVDN v3 (2.2.0), with official documentation.
- **You need it for:** any menu in a C# mod.
- **What you get:** menus that look like the game's own, with keyboard, mouse and controller handled for you. Item types: buttons, checkboxes, lists, sliders, submenus, separators, colour and grid panels. Also timer bars (mission-style bars at the bottom right), scaleforms ("big message" screens, instructional button hints), and resolution-independent text and images.
- **Limits:** v3 only.
- **Who uses it here:** ModGuide.
- **Guide:** [03](03-Menus-and-UI.md). **Reference:** [LemonUI](../reference/LemonUI/README.md).

## NativeUI (`scripts/NativeUI.dll`)

- **What it is:** the older menu library (1.9.0), built on SHVDN v2.
- **You need it for:** running the mods that depend on it. Don't use it for new mods.
- **What you get:** game-style menus (`UIMenu`, `MenuPool`) and pause-menu tabs.
- **Who uses it here:** MapEditor, and Better Chases+ (a v3 mod that references NativeUI 1.7, a mismatch that happens to work).
- **Reference:** [NativeUI](../reference/NativeUI/README.md).

## iFruitAddon2 (`scripts/iFruitAddon2.dll`)

- **What it is:** a library for the in-game phone (3.1.1, SHVDN v3). No official documentation ships with it.
- **You need it for:** adding contacts to the phone that run your code when called.
- **What you get:** `CustomiFruit` (the phone), `iFruitContact` (name, icon, `Answered` event, dial delay), contact icons for most characters, custom wallpapers and soft-key icons. `scripts/iFruitAddon2/config.ini` sets where added contacts start in the list.
- **Limits:** signatures only in the reference; behaviour learned from the sample.
- **Who uses it here:** no installed mod references it, as far as can be read. ImmersifyII's references can't be read (obfuscated).
- **Guide:** [03](03-Menus-and-UI.md#phone-contacts-with-ifruitaddon2). **Reference:** [iFruitAddon2](../reference/iFruitAddon2/README.md).

## ClearScript (`scripts/ClearScript.dll`)

- **What it is:** Microsoft's JavaScript engine for .NET (5.3.11).
- **You need it for:** MapEditor, which uses it to run scripts stored in maps.
- **What you get as a modder:** nothing game-specific. Leave it installed for MapEditor.

## Lua plugin (`LUA.asi`)

- **What it is:** Headscript's "Lua Plugin for Script Hook V" (1.0.0.1, 2015). Lua 5.2. Imports ScriptHookV, and also needs **`MSVCR120.dll`, the Visual C++ 2013 runtime**. It is installed on this PC (`C:WindowsSystem32msvcr120.dll`); on another PC, install the "Visual C++ Redistributable for Visual Studio 2013, x64" from Microsoft.
- **You need it for:** quick experiments and small personal tweaks, with no compiler and no project.
- **What you get:** Lua 5.2 with its standard libraries and LuaFileSystem (`lfs`), `get_key_pressed(key)`, `wait(ms)`, 4,824 natives under their 2015 names (`PLAYER.PLAYER_PED_ID()`), and an addin system: drop a `.lua` file in `scripts/addins/`.
- **Limits:** frozen since 2015: old native names, natives added after 2015 are missing, no console, no log, no debugger. A syntax error in any file stops every addin.
- **Guide:** [06](06-Lua.md). **Reference:** [Lua-Natives.md](../reference/Lua-Natives.md).

## Lua menu library (`scripts/libs/GUI.lua`)

- **What it is:** a small button-list menu written in Lua, loaded by `scripts/main.lua` into `Libs["GUI"]`.
- **You need it for:** a simple menu inside a Lua addin.
- **What you get:** `GUI.addButton(name, func, args, x, width, y-step, height)`, keyboard control (Numpad 8 / 2, Space), controller control (D-pad, A), and open/close button combos (A + RB + RS / B + LB + LT).
- **Limits:** one shared button list for all addins, no submenus, checkboxes or lists, basic look. Positions are raw screen fractions. The example addin (`exampleGUI.lua`) has a missing argument in its button lines (see [guide 06](06-Lua.md#the-gui-menu-library-scriptslibsguilua)).
- **Who uses it here:** only the example addin, which is off by default.

## Native functions (NativeDB)

- **What it is:** not an installed file. The game's 6,701 built-in functions, documented by the community at NativeDB.
- **You need it for:** anything the libraries don't wrap. Every library above is built on natives.
- **What you get:** the full list with parameters, hashes and descriptions in [`../reference/natives/`](../reference/natives/README.md), and named C++ wrappers in `natives.hpp`.
- **Limits:** names and descriptions are research, not official. Unknown parameters are named `p0`, `p1`...
- **Guide:** [05](05-Natives.md).

## Outside the game folder (Windows)

Some dependencies live in Windows, not the game folder: the DirectX June 2010 runtime, the Visual C++ 2013 and 2015-2022 runtimes, .NET Framework 4.8, and Media Foundation. For example, `LUA.asi` needs the VC++ 2013 runtime and every .NET mod needs .NET Framework 4.8. The full list, with what needs each one and where to get it: [`docs/mods_info/SYSTEM_REQUIREMENTS.md`](../../../docs/mods_info/SYSTEM_REQUIREMENTS.md). Check any PC with `powershell -ExecutionPolicy Bypass -File tools\check-system.ps1 -Dev` (from the game folder). Download links for every dependency, library and mod: [`docs/mods_info/DOWNLOADS.md`](../../../docs/mods_info/DOWNLOADS.md). On Linux: [`docs/mods_info/LINUX.md`](../../../docs/mods_info/LINUX.md).

## Not for scripting, but mods depend on them

| File | What it's for | Imports ScriptHookV? |
| --- | --- | --- |
| `OpenIV.asi` | Loads modified archives from `Mods/` instead of the originals. Needed for add-on cars, maps and anything inside `.rpf` files | No |
| `HeapAdjuster.asi`, `PackfileLimitAdjuster.asi`, `WeaponLimitsAdjuster.asi`, `fwBoxStreamerVariable_DecalsLimit-Patch.asi` | Raise engine limits so many add-ons fit. Settings: `docs/mods_info/SETTINGS.md` | No |
| `openCameraV.asi`, `NoEditorRestrictions.asi` | Camera and Rockstar Editor mods | No |
| `Menyoo.asi`, `TrainerV.asi` | Trainers. Use them while testing your mod (spawn things, teleport, change time and weather) | Yes |
