# Where to get everything

Official download locations for every dependency, library, mod and tool this install uses. Use these, not reuploads: repacked mod files are a common way malware spreads, and **ScriptHookV in particular should only ever come from dev-c.com**.

Installed versions are from the files in this install (see `ModDevelopment/docs/reference/Installed-Files.md`). Links checked on 2026-10-09: GitHub, Microsoft Learn and dotnet.microsoft.com answered normally. dev-c.com, openiv.com, microsoft.com/download and gta5-mods.com block automated checks, so those are given as the official sites but weren't fetched. For mods hosted on gta5-mods.com, search the site for the exact name given.

Single player only. Never take a modded game into GTA Online.

## 1. Windows runtimes (install on the PC, not in the game folder)

What needs each one: [`SYSTEM_REQUIREMENTS.md`](SYSTEM_REQUIREMENTS.md). Check what's missing with `tools\check-system.ps1`.

| Runtime | Installed here | Get it from |
| --- | --- | --- |
| Visual C++ Redistributable v14 (2015-2022 and later), **x64** | 14.51 | https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist → "Latest supported redistributable", X64 |
| Visual C++ Redistributable for Visual Studio 2013 (v12), **x64** | 12.0.40664 | Same page → section "Visual Studio 2013 (VC++ 12.0)", X64 |
| DirectX End-User Runtime (June 2010) | Installed | In the game folder: `_Redist\dxwebsetup.exe`. Or microsoft.com/download → search "DirectX End-User Runtime Web Installer" |
| .NET Framework 4.8 / 4.8.1 | 4.8.1 | https://dotnet.microsoft.com/download/dotnet-framework/net481 (Windows 11 already includes it) |
| Media Feature Pack (Windows "N" editions only) | Not needed | Windows Settings > Apps > Optional features > Add a feature > "Media Feature Pack" |
| Graphics driver | | NVIDIA, AMD or Intel's own site |

## 2. Script hooks and loaders (game folder)

| File | Installed | Author | Get it from |
| --- | --- | --- | --- |
| `ScriptHookV.dll`, `dinput8.dll` (ASI loader) | 3889.0 / 1.0.0.1 | Alexander Blade | http://www.dev-c.com/gtav/scripthookv/ (the zip's `bin` folder has both). Update after every game update |
| `ScriptHookVDotNet.asi`, `ScriptHookVDotNet2.dll`, `ScriptHookVDotNet3.dll` | 3.7.0 nightly 189 | SHVDN team | Nightly builds: https://github.com/scripthookvdotnet/scripthookvdotnet-nightly/releases (current game builds need these; newest is nightly 193). Stable (3.6.0, 2022, too old for current game builds): https://github.com/scripthookvdotnet/scripthookvdotnet/releases. Replace all three files together |
| `LUA.asi` | 1.0.0.1 | Headscript | gta5-mods.com → search "Lua Plugin for Script Hook V" |

## 3. Libraries for scripts (`scripts/`)

| File | Installed | Latest | Get it from |
| --- | --- | --- | --- |
| `LemonUI.SHVDN3.dll` (+ `.xml` docs) | 2.2.0 | 2.2 | https://github.com/LemonUIbyLemon/LemonUI/releases (take the SHVDN3 build) |
| `iFruitAddon2.dll` | 3.1.1 | 3.1.1 | https://github.com/Bob74/iFruitAddon2/releases |
| `NativeUI.dll` (+ `.xml`) | 1.9.0 | 1.9.1 | https://github.com/Guad/NativeUI/releases (legacy; only for mods that need it) |
| `ClearScript.dll` | 5.3.11 | | Ships with MapEditor; don't download separately |

## 4. Installed mods

| Mod | Installed | Author | Get it from |
| --- | --- | --- | --- |
| Menyoo | `Menyoo.asi` | MAFINS, now maintained by itsjustcurtis | https://github.com/itsjustcurtis/MenyooSP/releases (newest 2.4.4) |
| TrainerV (Simple Trainer for GTAV) | 18.4 | sjaak327 | gta5-mods.com → search "Simple Trainer for GTAV" |
| OpenIV (tool and `OpenIV.asi`) | 1.2.0.1 (asi) | GooD-NTS | https://openiv.com. Install `OpenIV.asi` from inside OpenIV: Tools > ASI Manager |
| Better Chases+ | 1.1.2 | Josh Glassmaker | gta5-mods.com → search "Better Chases+" |
| ImmersifyII | 2.5.0 | kassiter | gta5-mods.com → search "ImmersifyII". The Advanced edition is on https://www.patreon.com/kassiter (named in `ImmersifyII.ini`) |
| MapEditor | 1.0 | Guadmaz | gta5-mods.com → search "Map Editor" |
| Stance | 1.2 | jedijosh920 | gta5-mods.com → search "Stance" by jedijosh920 |
| Cop_Arrest, Disarm, FoSAShelter, openCameraV, NoEditorRestrictions | | Not recorded in their files | gta5-mods.com → search the mod name |
| HeapAdjuster, PackfileLimitAdjuster, WeaponLimitsAdjuster, fwBoxStreamerVariable_DecalsLimit-Patch | | Not recorded in their files | gta5-mods.com → search the file name |
| Add-on packs (`gxetron`, `urus2018`, `forest_n`/`forest_s`, `vremastered`) | | | gta5-mods.com → search the pack name |

When you find the page for a mod that says "search", add its URL to this table so the next update is quicker.

## 5. Modding tools

| Tool | Used for | Get it from |
| --- | --- | --- |
| Visual Studio Community 2026 | Editing and debugging C# and C++ mods | https://visualstudio.microsoft.com/downloads/ (workloads: ".NET desktop development", "Desktop development with C++") |
| Visual Studio Build Tools 2026 | Command-line builds without the IDE | Same page → "Tools for Visual Studio" → Build Tools |
| .NET SDK | `dotnet build`, the doc generator | https://dotnet.microsoft.com/download |
| CodeWalker | Opening encrypted game archives, map editing | https://github.com/dexyfex/CodeWalker/releases |
| OpenIV | Editing `.rpf` archives in `Mods/` | https://openiv.com |
| NativeDB | Looking up native functions | https://nativedb.dotindustries.dev (data: https://github.com/alloc8or/gta5-nativedb-data) |
| ScriptHookV SDK (optional) | Official C++ headers and samples | http://www.dev-c.com/gtav/scripthookv/ → "ScriptHookV SDK". Not needed: `ModDevelopment/cpp/ShvSdk` replaces it |

## 6. For Linux

See [`LINUX.md`](LINUX.md) for what each part needs on Linux.

| Tool | Get it from |
| --- | --- |
| Steam and Proton | Your distribution's package manager, or https://store.steampowered.com/about/. Proton source: https://github.com/ValveSoftware/Proton |
| protontricks (installs Windows runtimes into a Proton game) | https://github.com/Matoking/protontricks, or your package manager / Flathub |
| winetricks (the same, for plain Wine) | https://github.com/Winetricks/winetricks, or your package manager |
| .NET SDK for Linux | https://learn.microsoft.com/dotnet/core/install/linux |
| xwin (Microsoft C++ headers and libraries on Linux, for building `.asi` with clang) | https://github.com/Jake-Shadle/xwin |
