# Mod development documentation

Everything you can call when writing your own GTA V mods in this install: what each library is, every function it offers, and how to use it. Start with the guides, and look things up in the reference.

The mods we wrote ourselves are in [`../MyMods/`](../MyMods/README.md), each with its use case.

## Which library do I use?

For what each dependency gives you, what it costs, and which installed mods use it, read [00 What each dependency is for](guides/00-Dependencies.md).

| You want to... | Use | Language | Guide |
| --- | --- | --- | --- |
| Write a script mod with menus (recommended) | ScriptHookVDotNet v3 + LemonUI | C# | [02](guides/02-SHVDN3-Scripting.md), [03](guides/03-Menus-and-UI.md) |
| Write a fast, low-level mod, or one that draws with DirectX | ScriptHookV (C++ `.asi`) | C++ | [04](guides/04-ScriptHookV-CPP.md) |
| Make a quick change without compiling anything | The Lua plugin (`LUA.asi`) | Lua | [06](guides/06-Lua.md) |
| Read or fix an old mod | ScriptHookVDotNet v2 + NativeUI | C# | [07](guides/07-Legacy-SHVDN2-NativeUI.md) |
| Add contacts to the in-game phone | iFruitAddon2 (with SHVDN v3) | C# | [03](guides/03-Menus-and-UI.md#phone-contacts-with-ifruitaddon2) |
| Do something no library wraps | A native function | any | [05](guides/05-Natives.md) |

All of them end up calling **native functions**: the 6,700 functions the game's own mission scripts use. The libraries wrap the common ones in friendlier names.

## Guides (read in order)

| Guide | What it covers |
| --- | --- |
| [00 What each dependency is for](guides/00-Dependencies.md) | Every library and plugin: what you need it for, what you get out of it, its limits, and who uses it. Start here. |
| [01 Getting started](guides/01-Getting-Started.md) | How mods load, the languages to learn, Visual Studio setup, and the steps you have to do yourself. |
| [02 SHVDN v3 scripting](guides/02-SHVDN3-Scripting.md) | Script lifecycle, events, the player, peds, vehicles, the world, settings files, drawing text, debugging. |
| [03 Menus and UI](guides/03-Menus-and-UI.md) | Building menus with LemonUI, notifications, help text, phone contacts. |
| [04 ScriptHookV in C++](guides/04-ScriptHookV-CPP.md) | Every ScriptHookV function, the `.asi` project, building and installing. |
| [05 Native functions](guides/05-Natives.md) | Finding natives and calling them from C#, C++ and Lua, plus the old and new names. |
| [06 Lua plugin](guides/06-Lua.md) | What `LUA.asi` offers, how `main.lua` and addins work, writing an addin. |
| [07 Legacy: SHVDN v2 and NativeUI](guides/07-Legacy-SHVDN2-NativeUI.md) | How the old API differs, so you can read older mods. |
| [08 Manual steps](guides/08-Manual-Steps.md) | Checklist of everything that needs you: installs, downloads, testing in game. |
| [Downloads](../../docs/mods_info/DOWNLOADS.md) | Where to get every dependency, library, mod and tool. |
| [Linux](../../docs/mods_info/LINUX.md) | Playing with mods and developing mods on Linux (Proton/Wine). |

## GTA Online internals

How GTA Online is built in this install and how to run its content fully offline: the script layers, the 1,143 compiled scripts, the Online data on disk (1,001 local mission files, stats, clothing catalogues, property entrances), the offline architecture and the research tools. Start at [online/README.md](online/README.md).

## Reference (every function)

Generated from the files installed in the game, so it matches exactly what you can call. Re-generate after updating a library (see [Updating the reference](#updating-the-reference)).

| Reference | Contents | Size |
| --- | --- | --- |
| [SHVDN3/](reference/SHVDN3/README.md) | ScriptHookVDotNet v3: every class, property, method, event and enum. | 437 types, about 5,200 members |
| [LemonUI/](reference/LemonUI/README.md) | LemonUI menus, items, screen elements, timer bars, scaleforms. | about 625 members |
| [natives/](reference/natives/README.md) | Every native function by namespace, with parameters, hash and description. | 6,701 natives |
| [Lua-Natives.md](reference/Lua-Natives.md) | Every native the Lua plugin can call, with its current name. | 4,824 natives |
| [iFruitAddon2/](reference/iFruitAddon2/README.md) | Phone contact library. | 8 types |
| [SHVDN2/](reference/SHVDN2/README.md) | ScriptHookVDotNet v2 (legacy). | |
| [SHVDN-Runtime/](reference/SHVDN-Runtime/README.md) | The SHVDN host (`ScriptHookVDotNet.asi`): the F4 console commands, and its internal types (don't call those). | 9 console commands |
| [NativeUI/](reference/NativeUI/README.md) | NativeUI (legacy). | |
| ScriptHookV C++ API | All 24 exported functions, documented in the header itself. | [`../cpp/ShvSdk/include/main.h`](../cpp/ShvSdk/include/main.h) |
| [Installed-Files.md](reference/Installed-Files.md) | Every `.asi`, `.dll` and settings file in the install: version, .NET or native, exports, what it depends on, which SHVDN API it runs on, and what it is. | 46 binaries, 20 settings files |

Every generated page starts with a **Source** block naming the exact file it was read from (path, version, size, date, SHA-256) and how. See [Where everything comes from](#where-everything-comes-from).

## Where everything comes from

| Information | Source | How it was obtained | How far to trust it |
| --- | --- | --- | --- |
| SHVDN v3 types and members | `ScriptHookVDotNet3.dll` 3.7.0.189 | .NET metadata, read without running the code | Exact for this install |
| SHVDN v3 descriptions | `ScriptHookVDotNet3.xml` from NuGet package `scripthookvdotnet3` 3.6.0 | Downloaded | Official, but one version behind: 3.7 additions have none |
| SHVDN v2 types, members, descriptions | `ScriptHookVDotNet2.dll` 2.11.6 and NuGet `scripthookvdotnet2` 2.11.6 | Metadata, downloaded docs | Exact, same version |
| SHVDN console commands | `ScriptHookVDotNet.asi` (assembly 3.7.0.189) | Metadata: methods with the `ConsoleCommand` attribute and their help text | Exact |
| LemonUI, NativeUI | `scripts/LemonUI.SHVDN3.dll` 2.2.0, `scripts/NativeUI.dll` 1.9.0, and the `.xml` docs shipped next to each | Metadata, shipped docs | Exact and official |
| iFruitAddon2 | `scripts/iFruitAddon2.dll` 3.1.1 | Metadata (it ships no docs) | Exact signatures, no descriptions |
| ScriptHookV C++ functions | `ScriptHookV.dll` 3889.0.1158.13 | Export table (`dumpbin /exports`). The decorated C++ names include every parameter type | Exact. Verified by building and linking `HelloAsi.asi` |
| Natives (names, parameters, hashes, descriptions) | `natives.json` from github.com/alloc8or/gta5-nativedb-data (commit and date in [natives/README.md](reference/natives/README.md)) | Downloaded | Hashes exact. Names and descriptions are community research |
| Lua plugin natives and functions | `LUA.asi` 1.0.0.1 | Printable strings in the binary | Names and namespaces exact. How arguments are passed is inferred from `scripts/libs/GUI.lua`, not confirmed |
| Lua GUI library | `scripts/libs/GUI.lua`, `scripts/addins/exampleGUI.lua` | Read in full | Exact |
| Which SHVDN API each mod runs on | `ScriptHookVDotNet.log` from the last game session | Parsed | Exact for that session |
| Which plugins depend on ScriptHookV, and LUA.asi needing `MSVCR120.dll` | Import table of each `.asi` | `dumpbin /dependents` | Exact |
| What each installed file is | File version fields, exports, references, plus hand-written notes in the generator | Scan | Facts exact; notes are our description |
| C# examples in the guides | `ModDevelopment/Samples/` | Compiled against the installed DLLs | Compile, with no warnings. Not yet tested in game |

Not read: the `.pdb` files (debug symbols only, no extra API) and the machine code of any `.asi` or `.dll` (no disassembly).

## What's installed and callable

Full list with versions and dependencies: [Installed-Files.md](reference/Installed-Files.md).

| File | What it is | Version | Callable from your code? |
| --- | --- | --- | --- |
| `ScriptHookV.dll` | Native-call hook every mod depends on | 3889.0 (build 3725) | Yes, from C++ |
| `dinput8.dll` | ASI loader for GTA V Legacy: loads every `.asi` in the game root | 1.0.0.1 | No |
| `xinput1_4.dll` | ASI loader for GTA V **Enhanced**. Inactive in this Legacy install | 1.0.0.2 | No |
| `ScriptHookVDotNet.asi` | Runs .NET scripts from `scripts/`, and the F4 console | 3.7.0.189 (its file version label says 3.6.0.0) | Indirectly (it hosts your script) |
| `ScriptHookVDotNet3.dll` | SHVDN v3 API | 3.7.0.189 | Yes, from C# |
| `ScriptHookVDotNet2.dll` | SHVDN v2 API (old mods) | 2.11.6 | Yes, from C# (legacy) |
| `scripts/LemonUI.SHVDN3.dll` | Menu library | 2.2.0 | Yes, from C# |
| `scripts/NativeUI.dll` | Old menu library for v2 | 1.9.0 | Yes (legacy) |
| `scripts/iFruitAddon2.dll` | Phone contacts | 3.1.1 | Yes, from C# |
| `LUA.asi` | Lua 5.2 plugin by Headscript (2015) | 1.0.0.1 | Yes, from Lua |
| `scripts/ClearScript.dll` | Microsoft's JavaScript engine for .NET, needed by MapEditor | 5.3.11 | Not useful for game modding |
| `Menyoo.asi`, `TrainerV.asi`, `OpenIV.asi`, `openCameraV.asi`, limit adjusters | Finished mods | | No: they don't export functions for other mods |

### Old mods and "SHVDN v1"

There is no separate SHVDN v1 file. Before SHVDN 2.10, the v2 API was called `ScriptHookVDotNet` (version 0.0.0.0). Four installed mods were built against that old name: Cop_Arrest, Disarm, MapEditor and Stance. SHVDN redirects them to the v2 API (`ScriptHookVDotNet2.dll` 2.11.6), and `ScriptHookVDotNet.log` warns that v2 is deprecated. They work, but could stop working in a future SHVDN release.

## Folder layout

```text
ModDevelopment/
├─ docs/
│  ├─ README.md          this file
│  ├─ guides/            how-to guides, numbered
│  └─ reference/         generated API reference (don't edit by hand)
├─ cpp/ShvSdk/           C++ headers and import library definition for ScriptHookV
├─ MyMods/               our own mods, one folder each (see MyMods/README.md)
│  ├─ ModGuide/          the in-game mod guide (installed)
│  └─ HelloAsi/          C++ starter mod (.asi)
├─ Samples/              C# examples used in the guides (compile-checked, not installed)
└─ tools/ApiDocGen/      generator for docs/reference and cpp/ShvSdk/include/natives.hpp
```

## Updating the reference

Run after updating SHVDN, LemonUI, ScriptHookV or the game:

```bash
dotnet run -c Release --project ModDevelopment/tools/ApiDocGen
```

It reads the DLLs in the game folder, downloads SHVDN's documentation from NuGet and the latest native list from NativeDB (into `tools/ApiDocGen/cache/`, which is gitignored), and rewrites `docs/reference/` and `cpp/ShvSdk/include/natives.hpp`. Delete `tools/ApiDocGen/cache/` first to force fresh downloads.
