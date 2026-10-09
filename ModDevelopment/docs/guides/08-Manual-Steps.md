# 08 Manual steps

Everything here needs you: installing software, downloading from websites, or testing in the game. Everything else is already set up and builds from the command line.

> **Sources:** install status from the Visual Studio Installer (`vswhere`), 2026-10-09. ScriptHookV download location from its official site. Details: [Where everything comes from](../README.md#where-everything-comes-from).

Status checked on 2026-10-09.

| # | Step | Needed for | Status |
| --- | --- | --- | --- |
| 0 | Check this PC has the Windows runtimes (DirectX, Visual C++, .NET) | Playing, mods and modding | Run `tools\check-system.ps1 -Dev`; all OK on 2026-10-09 |
| 1 | Install the C++ workload in Visual Studio Community | Editing C++ `.asi` mods in the IDE | **To do** |
| 2 | Check the .NET workload in Visual Studio Community | C# scripts in the IDE | Done (installed) |
| 3 | Test the starter mods in game | Confirming the toolchain works end to end | **To do** |
| 4 | Bookmark the online references | Looking up natives and APIs | Optional |
| 5 | The official ScriptHookV SDK | Only if you want Rockstar-era SDK samples | Optional |
| 6 | Update ScriptHookV and SHVDN after a game update | Keeping every mod working | When it happens |

## 1. Install the C++ workload in Visual Studio Community

The Build Tools can already compile C++ from the command line, but Visual Studio Community can't open `.vcxproj` projects until this is installed.

1. Open **Visual Studio Installer** (Start menu).
2. Next to **Visual Studio Community 2026**, click **Modify**.
3. On the **Workloads** tab, tick **Desktop development with C++**.
4. On the right, under "Installation details", make sure these are ticked (they are by default):
   - MSVC v145 build tools (x64/x86)
   - Windows 11 SDK (10.0.26100 or newer)
5. Click **Modify** and wait (several GB to download).
6. Open `ModDevelopment\ModDevelopment.Cpp.slnx`. Pick **Release** and **x64** in the toolbar, then **Build > Build Solution**.

If Visual Studio says the project needs "retargeting" to a different toolset, accept it: it only changes `<PlatformToolset>` in the `.vcxproj`.

## 2. Check the .NET workload

Already installed. To confirm, or after reinstalling Visual Studio: Visual Studio Installer > Modify > tick **.NET desktop development**, and under Individual components make sure **.NET Framework 4.8 targeting pack** is ticked.

## 3. Test the starter mods in game

None of these have been run in the game yet: only built.

**C# (Mod Guide, already installed):**

1. Launch with `PlayGTAV.bat` and load story mode.
2. Press **F12**. The Mod Guide menu should open.
3. If not, check `ScriptHookVDotNet.log` for `ModGuide`.

**C++ (HelloAsi):**

1. Close the game.
2. Build: `MSBuild ModDevelopment\MyMods\HelloAsi\HelloAsi.vcxproj -p:Configuration=Release -p:Platform=x64` (full command in [guide 04](04-ScriptHookV-CPP.md#building)).
3. Copy `ModDevelopment\MyMods\HelloAsi\bin\Release\HelloAsi.asi` into the game folder.
4. Launch. After the loading screen, a "HelloAsi loaded" notification should appear.
5. Check `asiloader.log` (lists `HelloAsi.asi`) and `ScriptHookV.log`.
6. Delete `HelloAsi.asi` from the game folder afterwards, so it doesn't load every time.

**Lua:** follow `docs/mods_info/LUA_MENU.md` to enable the example menu, launch, and open it.

## 4. Online references

| Site | What it's for |
| --- | --- |
| https://nativedb.dotindustries.dev | Search natives by name, with descriptions. Same data as `docs/reference/natives/` |
| https://github.com/scripthookvdotnet/scripthookvdotnet | SHVDN source code, releases and wiki |
| https://github.com/LemonUIbyLemon/LemonUI | LemonUI source, wiki with menu examples |
| https://docs.fivem.net/docs/game-references/ | Lists of controls, blips, ped models, vehicle models, weapons. Made for FiveM but the game data is the same |
| https://learn.microsoft.com/dotnet/csharp | Learning C# |
| https://www.learncpp.com | Learning C++ |
| https://www.lua.org/pil | Learning Lua |
| https://forums.gta5-mods.com | Help from other modders |

Only download mods from sources you trust, and never use mods in GTA Online.

## 5. Optional: the official ScriptHookV SDK

You don't need it: `ModDevelopment/cpp/ShvSdk/` replaces it, and it matches the installed ScriptHookV exactly. Get it only for its sample projects (a native trainer).

1. Go to **http://www.dev-c.com/gtav/scripthookv/** and download **ScriptHookV SDK** (a `.zip`).
2. Extract it to a new folder outside the game folder, for example `D:\Dev\ScriptHookV_SDK`.
3. Its `inc\main.h`, `inc\natives.h`, `inc\types.h`, `inc\enums.h` and `lib\ScriptHookV.lib` are the official versions. Its `natives.h` uses old native names: prefer our `natives.hpp`.
4. To build its samples, open the `.sln` in its `samples` folder and retarget to toolset v145 when asked.

Don't copy SDK files into `ModDevelopment/cpp/ShvSdk/`: our headers are written to be compatible, and mixing the two causes duplicate definitions.

## 6. After a game update

1. Check `ScriptHookV.log`. If it reports an unsupported version, every mod stops working until ScriptHookV is updated.
2. Download the new ScriptHookV from **http://www.dev-c.com/gtav/scripthookv/** and replace `ScriptHookV.dll` (and `dinput8.dll` only if the release includes a new one).
3. If .NET scripts fail, update SHVDN from its GitHub releases: replace `ScriptHookVDotNet.asi`, `ScriptHookVDotNet2.dll` and `ScriptHookVDotNet3.dll` together.
4. Regenerate the reference and the C++ headers:

   ```bash
   dotnet run -c Release --project ModDevelopment/tools/ApiDocGen
   ```

5. If ScriptHookV gained new exports, add them to `ModDevelopment/cpp/ShvSdk/ScriptHookV.def` (list them with `dumpbin /exports ScriptHookV.dll`) and declare them in `main.h`.
6. Rebuild everything:

   ```bash
   dotnet build -c Release ModDevelopment/ModDevelopment.slnx
   ```

   and the C++ solution with MSBuild.
7. Commit the updated DLLs and the regenerated files.
