# Installed binaries and settings files

> **Source:** every `.asi` and `.dll` in the game folder and in `scripts/`, and every settings file, scanned by `ModDevelopment/tools/ApiDocGen`.  
> **Method:** version fields and SHA-256 from each file; export counts from the PE export table; .NET references from the assembly metadata; "SHVDN API" from the last `ScriptHookVDotNet.log` (the game session before the scan). The "What it is" column is written by hand in the generator.

## Mods, hooks and libraries

| File | Kind | Version | Exports | .NET references | SHVDN API | What it is |
| --- | --- | --- | --- | --- | --- | --- |
| `dinput8.dll` | native | 1.0.0.1 | 5 |  |  | ASI loader for GTA V Legacy (Alexander Blade, 2015). Loads every `*.asi` in the game folder and writes `asiloader.log` |
| `fwBoxStreamerVariable_DecalsLimit-Patch.asi` | native |  | 0 |  |  | Raises decal and streamer limits. No API |
| `HeapAdjuster.asi` | native |  | 0 |  |  | Raises the game's memory heap. No API |
| `LUA.asi` | native | 1.0.0.1 | 0 |  |  | Lua 5.2 plugin by Headscript. **Reference**: [Lua-Natives.md](Lua-Natives.md), guide 06 |
| `Menyoo.asi` | native |  | 0 |  |  | Menyoo trainer. Finished mod, no API |
| `NoEditorRestrictions.asi` | native |  | 0 |  |  | Rockstar Editor tweaks. No API |
| `openCameraV.asi` | native | 1.0.0.1 | 0 |  |  | Camera mod. No API |
| `OpenIV.asi` | native | 1.2.0.1 | 0 |  |  | Redirects archive reads to `Mods/`. No API |
| `PackfileLimitAdjuster.asi` | native |  | 0 |  |  | Raises the archive limit. No API |
| `ScriptHookV.dll` | native | 3889.0.1158.13 | 24 |  |  | Native-call hook every mod depends on (Alexander Blade). **C++ API**: [`cpp/ShvSdk/include/main.h`](../../cpp/ShvSdk/include/main.h) |
| `ScriptHookVDotNet.asi` | .NET | 3.6.0.0 | 0 |  |  | SHVDN runtime: hosts .NET and loads `scripts/*.dll` and `*.cs`. Its file version says 3.6.0.0 but its assembly version is 3.7.0.189, matching the API DLLs. **Reference**: [SHVDN-Runtime](SHVDN-Runtime/README.md) (console commands) |
| `ScriptHookVDotNet2.dll` | .NET | 2.11.6 | 0 | ScriptHookVDotNet 3.7.0.189 |  | SHVDN v2 API (legacy). **Reference**: [SHVDN2](SHVDN2/README.md) |
| `ScriptHookVDotNet3.dll` | .NET | 3.7.0.189 | 0 | ScriptHookVDotNet 3.7.0.189 |  | SHVDN v3 API. **Reference**: [SHVDN3](SHVDN3/README.md) |
| `TrainerV.asi` | native | 18.4.0.0 | 5 |  |  | TrainerV trainer. Its 5 exports are internal values, not an API |
| `WeaponLimitsAdjuster.asi` | native |  | 0 |  |  | Raises weapon limits. No API |
| `xinput1_4.dll` | native | 1.0.0.2 | 14 |  |  | ASI loader for GTA V **Enhanced** (its strings name `GTA5_Enhanced.exe`). Not active here: `asiloader.log` only shows the Legacy loader. A leftover that does nothing in this install |
| `scripts/Better Chases+.dll` | .NET | 1.1.2 | 0 | ScriptHookVDotNet3 3.0.2.0, NativeUI 1.7.0.0 | 3.7.0 | Police chase mod. No API |
| `scripts/ClearScript.dll` | .NET | 5.3.11.0 | 0 |  | library only | Microsoft ClearScript (JavaScript engine for .NET). Needed by MapEditor. Not useful for game modding |
| `scripts/Cop_Arrest.dll` | .NET | 1.0.0.0 | 0 | ScriptHookVDotNet 0.0.0.0 | 2.11.6 | Arrest mod. No API |
| `scripts/Disarm.dll` | .NET | 1.0.0.0 | 0 | ScriptHookVDotNet 0.0.0.0 | 2.11.6 | Disarm mod. No API |
| `scripts/iFruitAddon2.dll` | .NET | 3.1.1.0 | 0 | ScriptHookVDotNet3 3.6.0.0 | 3.7.0 | Phone contacts library. **Reference**: [iFruitAddon2](iFruitAddon2/README.md) |
| `scripts/ImmersifyII.dll` | .NET | 2.5.0.0 | 0 | unreadable: nonstandard (likely obfuscated) metadata | 3.7.0 | World and NPC behaviour mod. No API |
| `scripts/LemonUI.SHVDN3.dll` | .NET | 2.2.0.0 | 0 | ScriptHookVDotNet3 3.6.0.0 |  | Menu library for SHVDN v3. **Reference**: [LemonUI](LemonUI/README.md) |
| `scripts/MapEditor.dll` | .NET | 1.0.0.0 | 0 | ScriptHookVDotNet 0.0.0.0, ClearScript 5.3.11.0, NativeUI 1.0.0.0 | 2.11.6 | Map editor. No API |
| `scripts/ModGuide.dll` | .NET | 1.0.0.0 | 0 | ScriptHookVDotNet3 3.7.0.189, LemonUI.SHVDN3 2.2.0.0 |  | Our in-game mod guide. Source: `ModDevelopment/ModGuide/` |
| `scripts/NativeUI.dll` | .NET | 1.9.0.0 | 0 | ScriptHookVDotNet2 2.10.9.0 | 2.11.6 | Menu library for SHVDN v2 (legacy). **Reference**: [NativeUI](NativeUI/README.md) |
| `scripts/Stance.dll` | .NET | 1.0.0.0 | 0 | ScriptHookVDotNet 0.0.0.0 | 2.11.6 | Stance mod. No API |

Mods built against `ScriptHookVDotNet` 0.0.0.0 (the API name before SHVDN 2.10) run on the v2 API: the log shows them resolved to 2.11.6.

## Game and launcher files (not mods)

Part of GTA V, its launcher or its platform layer. Nothing here is for mods to call. Don't change the launcher files (see `CLAUDE.md`).

| File | Version | Description |
| --- | --- | --- |
| `bink2w64.dll` | 1.994a | game: RAD Video Tools |
| `d3dcompiler_46.dll` | 9.30.9200.16384 | game: Direct3D HLSL Compiler |
| `d3dcsx_46.dll` | 9.30.9200.16384 | game: Direct3D 11 Compute Shader Extensions |
| `fvad.dll` |  | game: WebRTC voice activity detection (exports `WebRtcSpl_*`) |
| `GFSDK_ShadowLib.win64.dll` |  | game: NVIDIA ShadowWorks (shadow quality options) |
| `GFSDK_TXAA.win64.dll` |  | game: NVIDIA TXAA anti-aliasing |
| `GFSDK_TXAA_AlphaResolve.win64.dll` |  | game: NVIDIA TXAA anti-aliasing |
| `GPUPerfAPIDX11-x64.dll` | 2.14.1054.0 | game: GPUPerfAPIDX11 |
| `launc.dll` |  | launcher / platform: part of this install's launcher setup (one export, `launc`); not identified further. Don't touch |
| `libcurl.dll` | 8.4.0-DEV | game: libcurl Shared Library |
| `libtox.dll` |  | game: audio library (exports `tox_add_audio*`); exact purpose not confirmed |
| `NvPmApi.Core.win64.dll` | 4.1.0.14260 | game: NvPmApiCore.100 |
| `opus.dll` |  | game: Opus audio codec (exports `opus_*`) |
| `opusenc.dll` |  | game: Opus file encoder (exports `ope_*`) |
| `orig_socialclub.dll` | 2.0.2.5 | launcher / platform: Social Club |
| `socialclub.dll` |  | launcher / platform: Social Club layer used by this install (the original is orig_socialclub.dll) |
| `steam_api64.dll` |  | launcher / platform: Steam API layer used by this install (original: steam_api64.dll.orig; settings in steam_settings/) |
| `XCurl.dll` | 2403.3.0.0 (WinBuild.160101.0800) | game: Microsoft Xbox XCurl |
| `zlib1.dll` | 1.2.12 | game: zlib data compression library |

## Settings files

How to edit each one: `docs/mods_info/SETTINGS.md` in the game folder.

| File | Size |
| --- | --- |
| `fwBoxStreamerVariable_DecalsLimit-Patch.toml` | 264 bytes |
| `hashes.ini` | 18,559 bytes |
| `HeapAdjuster.ini` | 32 bytes |
| `menyooStuff/menyooConfig.ini` | 7,254 bytes |
| `NoEditorRestrictions.ini` | 999 bytes |
| `PackfileLimitAdjuster.ini` | 234 bytes |
| `ScriptHookVDotNet.ini` | 1,661 bytes |
| `scripts/BetterChasesConfig.xml` | 8,615 bytes |
| `scripts/Expanded ObjectList.ini` | 439,567 bytes |
| `scripts/iFruitAddon2/config.ini` | 26 bytes |
| `scripts/ImmersifyII.ini` | 12,432 bytes |
| `scripts/MapEditor.xml` | 876 bytes |
| `scripts/ModGuide.ini` | 746 bytes |
| `scripts/ModGuide.xml` | 9,749 bytes |
| `scripts/ObjectList.ini` | 381,279 bytes |
| `scripts/PedList.ini` | 16,467 bytes |
| `scripts/Stance.ini` | 109 bytes |
| `scripts/VehicleList.ini` | 8,589 bytes |
| `trainerv.ini` | 122,259 bytes |
| `WeaponLimitsAdjuster.ini` | 284 bytes |

