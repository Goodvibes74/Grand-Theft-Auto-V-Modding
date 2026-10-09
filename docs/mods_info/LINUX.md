# Playing and modding on Linux

What this modded GTA V Legacy install needs on Linux, both to play it with its mods and to develop new mods.

> **Status:** not tested on Linux. This install lives on Windows 11 and there's no WSL or Linux machine to try it on. What's **verified** comes from the files themselves (what each one imports, what kind of assembly it is) and from builds run on Windows using the same route Linux would use. The rest is standard Proton/Wine practice, marked *expected*. Update this file once you've tried it.

Download links for everything below: [`DOWNLOADS.md`](DOWNLOADS.md#6-for-linux).

## How it works

GTA V and every mod here are Windows programs. On Linux they run under **Proton** (Steam's version of Wine) or plain **Wine**:

- Wine runs the Windows code. DXVK, part of Proton, turns the game's Direct3D 11 into Vulkan.
- Each game gets a **prefix**: a fake Windows folder (`drive_c`) with its own registry and `System32`.
- The Windows runtimes from [`SYSTEM_REQUIREMENTS.md`](SYSTEM_REQUIREMENTS.md) (Visual C++, .NET Framework, DirectX June 2010) go **into that prefix**, not onto Linux itself. You install them with `protontricks` (Steam) or `winetricks` (plain Wine).

## Part 1: play with mods

### Install on Linux itself

| Package | Why | Where |
| --- | --- | --- |
| Steam, with Proton Experimental or GE-Proton | Runs the game | Your distribution's packages, or store.steampowered.com. GE-Proton via ProtonUp-Qt |
| Vulkan driver: Mesa (AMD, Intel) or NVIDIA's proprietary driver | DXVK needs Vulkan. Check with `vulkaninfo --summary` | Your distribution's packages |
| protontricks (or winetricks for plain Wine) | Installs Windows runtimes into the game's prefix | Packages or Flathub |

### Set up the game

1. **Copy the game folder** to a Linux file system (ext4, btrfs). Running from an NTFS drive often fails under Proton.
2. In Steam: **Add a Game > Add a Non-Steam Game**, and pick `PlayGTAV.exe`.
3. In its **Properties > Compatibility**, force a Proton version.
4. Set its **Launch Options** to:

   ```text
   WINEDLLOVERRIDES="dinput8=n,b" %command% -nobattleye
   ```

   - `dinput8=n,b` makes Wine load the game folder's `dinput8.dll`, the ASI loader, instead of Wine's own. Without it, **no `.asi` mod loads at all**: not ScriptHookV, SHVDN, Lua, Menyoo or TrainerV.
   - `-nobattleye` does the same job as `PlayGTAV.bat` on Windows.
5. Start it once so Proton creates the prefix, then quit.
6. Install the runtimes into the prefix. Find the game's ID with `protontricks -l`, then:

   ```bash
   protontricks <id> vcrun2022 vcrun2013 dotnet48
   ```

   Add `d3dx9_43 d3dcompiler_43 xinput` only if the game complains about those files. Wine has its own versions that usually work.
7. Start the game. The logs appear in the game folder, the same as on Windows (`asiloader.log`, `ScriptHookV.log`, `ScriptHookVDotNet.log`).

### What each part needs under Proton

| Part | Needs in the prefix | Why (verified from the files) | Expected to work? |
| --- | --- | --- | --- |
| Game | vcrun2022 for the launchers and audio/network libraries; Wine covers DirectX | Import tables | Yes. GTA V story mode is widely run on Proton |
| ASI loader (`dinput8.dll`) | The `dinput8=n,b` override | Wine prefers its built-in `dinput8.dll` | Yes, with the override |
| ScriptHookV | Nothing extra | Imports only standard Windows DLLs | Expected |
| SHVDN (`ScriptHookVDotNet.asi`) and every .NET mod | **dotnet48** (real .NET Framework 4.8) | It's a mixed C++/.NET assembly (it contains C++/CLI `msclr` types). Wine's built-in Mono runtime can't load those | Expected with dotnet48; won't load with Wine Mono |
| Lua plugin (`LUA.asi`) | **vcrun2013** | Imports `msvcr120.dll`, `msvcp120.dll` | Expected |
| Menyoo, WeaponLimitsAdjuster | vcrun2022 | Import `vcruntime140`, `msvcp140` | Expected |
| OpenIV.asi, limit adjusters, openCameraV, NoEditorRestrictions | Nothing extra | Standard Windows DLLs only | Expected |
| Mods drawing their own overlay with DirectX (none installed) | | Run on DXVK, not real Direct3D | May look different |

GTA Online doesn't run on Linux at all, which doesn't matter here: these mods are for single player only.

## Part 2: develop mods on Linux

| Kind of work | Works on Linux? | What you need |
| --- | --- | --- |
| **C# mods** (SHVDN v3, LemonUI) | **Yes.** Verified route: building with the NuGet reference assemblies, as Linux does, succeeds on Windows with no warnings | .NET SDK for Linux. `ModDevelopment/Directory.Build.props` automatically uses the `Microsoft.NETFramework.ReferenceAssemblies` NuGet package when not on Windows (first build needs internet) |
| Creating a C# project | Yes | PowerShell 7 (`pwsh`): `pwsh ModDevelopment/New-ModScript.ps1 -Name MyMod` |
| Editing C# | Yes | VS Code with the C# Dev Kit, or JetBrains Rider. Visual Studio doesn't exist on Linux |
| Debugging C# with breakpoints | Not practical | Attaching a debugger to a game under Wine isn't supported. Use the F4 console, `ScriptHookVDotNet.log` and on-screen text |
| **Regenerating the API reference** | **Yes.** Verified: it produces identical output with the NuGet reference assemblies | .NET SDK. `dotnet run -c Release --project ModDevelopment/tools/ApiDocGen` |
| **Lua mods** | Yes | Any text editor. Nothing to build |
| **C++ `.asi` mods** | Possible, harder, untested | See below |
| Editing archives (OpenIV, CodeWalker) | Unreliable | They're Windows GUI programs. Try them under Wine, or use a Windows VM |
| `tools/check-system.ps1` | No | It reads the Windows registry and `System32`. On Linux, list the prefix's runtimes with `protontricks <id> list-installed` |

### Building C++ `.asi` mods on Linux

The Microsoft C++ compiler doesn't run on Linux, and **MinGW (GCC) can't be used**. ScriptHookV exports its functions with Microsoft-style C++ names (`?scriptWait@@YAXK@Z`), and only a Microsoft-compatible compiler produces matching names.

The workable route is **clang-cl** (LLVM's Microsoft-compatible compiler) with Microsoft's headers and libraries fetched by **xwin**. Untested outline, from the game folder:

```bash
# once: Microsoft C runtime + Windows SDK headers and libraries (you accept Microsoft's license)
xwin --accept-license splat --output "$HOME/xwin"

SDK=ModDevelopment/cpp/ShvSdk
X="$HOME/xwin"

# import library for ScriptHookV, from our .def file
llvm-lib /def:$SDK/ScriptHookV.def /machine:x64 /out:ScriptHookV.lib

# compile and link HelloAsi
clang-cl --target=x86_64-pc-windows-msvc /std:c++20 /O2 /MT /bigobj /DNOMINMAX /DWIN32_LEAN_AND_MEAN \
  -imsvc "$X/crt/include" -imsvc "$X/sdk/include/ucrt" -imsvc "$X/sdk/include/um" -imsvc "$X/sdk/include/shared" \
  /I $SDK/include /c ModDevelopment/MyMods/HelloAsi/main.cpp ModDevelopment/MyMods/HelloAsi/script.cpp
lld-link /dll /out:HelloAsi.asi main.obj script.obj ScriptHookV.lib \
  /libpath:"$X/crt/lib/x86_64" /libpath:"$X/sdk/lib/um/x86_64" /libpath:"$X/sdk/lib/ucrt/x86_64"
```

Needs `clang`, `lld` and `llvm` from your distribution, and xwin from its GitHub releases. If this fails, build in a Windows VM with the normal Visual Studio project.

## Checklist for a Linux PC

1. Steam, Proton, Vulkan driver, protontricks.
2. Game folder on a Linux file system, added as a non-Steam game, with `WINEDLLOVERRIDES="dinput8=n,b" %command% -nobattleye`.
3. `protontricks <id> vcrun2022 vcrun2013 dotnet48`.
4. Start the game and check `asiloader.log` lists the `.asi` files.
5. For modding: .NET SDK, PowerShell 7, VS Code or Rider. Add clang, lld, llvm and xwin only for C++.
