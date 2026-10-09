# 04 ScriptHookV in C++ (.asi mods)

A C++ mod is a DLL renamed to `.asi`. The ASI loader (`dinput8.dll`) loads it into `GTA5.exe`, and it talks to `ScriptHookV.dll` directly. No .NET in between: faster, and it can do things C# can't (DirectX overlays, raw memory). The price: a bug crashes the whole game, and there's no console telling you why.

> **Sources:** every function from the export table of `ScriptHookV.dll` 3889.0.1158.13 (`dumpbin /exports`), verified by building and linking `HelloAsi.asi`. Native wrappers from NativeDB. Toolset and SDK versions from the Build Tools install. Details: [Where everything comes from](../README.md#where-everything-comes-from).

Use C++ when you need speed or low-level access. For everything else, C# is easier ([guide 02](02-SHVDN3-Scripting.md)).

## What's set up in this repo

| Path | What it is |
| --- | --- |
| `cpp/ShvSdk/include/main.h` | Every function ScriptHookV.dll exports, with explanations. Read this file: it is the API reference |
| `cpp/ShvSdk/include/types.h` | `Ped`, `Vehicle`, `Hash`, `Vector3` and the other native types |
| `cpp/ShvSdk/include/nativeCaller.h` | `invoke<R>(hash, args...)`, which calls any native by hash |
| `cpp/ShvSdk/include/natives.hpp` | All 6,701 natives as named functions (`PLAYER::PLAYER_PED_ID()`), generated from NativeDB |
| `cpp/ShvSdk/ScriptHookV.def` | The list of ScriptHookV's exports. The build turns it into `ScriptHookV.lib` |
| `cpp/ShvSdk/ShvSdk.props` | Shared build settings: include path, the `.lib`, `.asi` output, static runtime, C++20 |
| `HelloAsi/` | A starter mod that builds and links |
| `ModDevelopment.Cpp.slnx` | The C++ solution for Visual Studio |

These replace the official ScriptHookV SDK, so you don't have to download it. They were written from the DLL's own export table (`dumpbin /exports ScriptHookV.dll`), so they match the installed ScriptHookV exactly. Code written for the official SDK compiles against them. If you'd rather use the official SDK, see [guide 08](08-Manual-Steps.md#5-optional-the-official-scripthookv-sdk).

## The ScriptHookV API

Every exported function, grouped by job. Details for each are in [`main.h`](../../cpp/ShvSdk/include/main.h).

| Function | Use |
| --- | --- |
| `scriptRegister(HMODULE, void(*)())` | Register your script's main loop. Call from `DllMain` on attach |
| `scriptRegisterAdditionalThread(HMODULE, void(*)())` | Run a second loop as its own script thread |
| `scriptUnregister(HMODULE)` | Unregister everything. Call from `DllMain` on detach |
| `scriptWait(DWORD ms)` | Give control back to the game. `scriptWait(0)` waits one frame. **Every loop iteration must call it** |
| `scriptsAreLaunchedUsingReloading()` | Whether scripts were started by a reload |
| `keyboardHandlerRegister(handler)` / `keyboardHandlerUnregister` | Receive every key press and release (virtual-key code, repeat count, Alt, up/down) |
| `nativeInit(hash)`, `nativePush64(value)`, `nativeCall()` | Low-level native call. Use `invoke<>` or `natives.hpp` instead |
| `nativeCanExecuteInThisContext()` | Whether the current thread may call natives |
| `createTexture(file)`, `drawTexture(...)` | Load an image file and draw it on screen, outside the game's texture system |
| `presentCallbackRegister(cb)` / `presentCallbackUnregister` | Get the DirectX 11 swap chain every frame, for your own rendering |
| `getGlobalPtr(index)` | Pointer to a game script global. Indexes change between game builds |
| `getScriptHandleBaseAddress(handle)` | Memory address behind an entity handle. Offsets change between game builds |
| `worldGetAllVehicles/Peds/Objects/Pickups(int* arr, int size)` | Handles of every entity of that kind. Returns how many it wrote |
| `getGameVersion()` | The game build ScriptHookV detected |

`getGameVersionInfo()` is exported too but isn't declared, because the layout of the struct it returns isn't published. Use `getGameVersion()`.

## How a C++ mod is structured

```cpp
// main.cpp: Windows calls DllMain when the .asi is loaded.
BOOL APIENTRY DllMain(HMODULE module, DWORD reason, LPVOID)
{
    if (reason == DLL_PROCESS_ATTACH)
    {
        scriptRegister(module, ScriptMain);           // only register here: no natives in DllMain
        keyboardHandlerRegister(OnKeyboardMessage);
    }
    else if (reason == DLL_PROCESS_DETACH)
    {
        scriptUnregister(module);
        keyboardHandlerUnregister(OnKeyboardMessage);
    }
    return TRUE;
}

// script.cpp: the loop, on a game script thread.
void ScriptMain()
{
    while (true)
    {
        Ped player = PLAYER::PLAYER_PED_ID();
        if (PED::IS_PED_IN_ANY_VEHICLE(player, FALSE))
        {
            Vehicle car = PED::GET_VEHICLE_PED_IS_IN(player, FALSE);
            VEHICLE::SET_VEHICLE_FIXED(car);
        }
        scriptWait(0);                                // one frame
    }
}
```

The full working version, with notifications and on-screen text, is in [`HelloAsi/script.cpp`](../../HelloAsi/script.cpp).

### Rules

- **Natives only on the script thread,** inside `ScriptMain` (or a function it calls). Not in `DllMain`, not in the keyboard handler, not in your own `std::thread`.
- **Every loop iteration calls `scriptWait`.** A loop without it freezes the game.
- **The keyboard handler runs on another thread.** Only record the key there (a `volatile bool` or `std::atomic`) and act on it in the loop. `HelloAsi` shows this.
- **Text and drawing must be repeated every frame.**
- **Models must be loaded before use:** `STREAMING::REQUEST_MODEL(hash)`, then `while (!STREAMING::HAS_MODEL_LOADED(hash)) scriptWait(0);`, then create, then `STREAMING::SET_MODEL_AS_NO_LONGER_NEEDED(hash)`.
- **Hashes:** `MISC::GET_HASH_KEY("adder")` turns a model name into its hash.
- **Strings for on-screen text** go through the text commands: `HUD::BEGIN_TEXT_COMMAND_DISPLAY_TEXT("STRING")`, `HUD::ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text)`, `HUD::END_TEXT_COMMAND_DISPLAY_TEXT(x, y, 0)`.

## Building

### From the command line (works now)

```powershell
& "C:\Program Files (x86)\Microsoft Visual Studio\18\BuildTools\MSBuild\Current\Bin\MSBuild.exe" `
  ModDevelopment\HelloAsi\HelloAsi.vcxproj -p:Configuration=Release -p:Platform=x64
```

The output is `ModDevelopment\HelloAsi\bin\Release\HelloAsi.asi`. Before linking, the build runs `lib.exe` to make `ScriptHookV.lib` from `ScriptHookV.def`.

### In Visual Studio

Visual Studio Community needs the **Desktop development with C++** workload first: [guide 08, step 1](08-Manual-Steps.md#1-install-the-c-workload-in-visual-studio-community). Then open `ModDevelopment\ModDevelopment.Cpp.slnx`, pick **Release | x64**, and build.

The C++ projects are in their own solution because `dotnet build` (used for the C# solution) can't build `.vcxproj` files.

### Project settings that matter

All set by `ShvSdk.props` and the `.vcxproj`:

| Setting | Value | Why |
| --- | --- | --- |
| Configuration type | Dynamic library (`.dll`) | An `.asi` is a DLL |
| Target extension | `.asi` | The ASI loader only loads `.asi` files |
| Platform | x64 | GTA V is 64-bit |
| Platform toolset | v145 | The VS 2026 C++ compiler |
| Runtime library | `/MT` (static) | Players don't need the Visual C++ redistributable |
| Language | C++20 | `natives.hpp` and `invoke<>` use it |
| `/bigobj` | on | `natives.hpp` has thousands of functions |
| `NOMINMAX`, `WIN32_LEAN_AND_MEAN` | defined | Stops `windows.h` macros clashing with native parameter names |

### Installing and testing

1. Build Release.
2. **Close the game,** then copy `HelloAsi.asi` into the game folder (next to `GTA5.exe`). Or set `<CopyAsiToGame>true</CopyAsiToGame>` in the `.vcxproj` to copy it on every build.
3. Launch with `PlayGTAV.bat`.
4. `asiloader.log` lists every `.asi` that loaded. `ScriptHookV.log` lists registered scripts.
5. To uninstall, delete the `.asi` from the game folder.

## Making your own C++ mod

1. Copy the `HelloAsi` folder to `ModDevelopment\<YourMod>\` and rename `HelloAsi.vcxproj` to `<YourMod>.vcxproj`.
2. In the `.vcxproj`, change `<RootNamespace>` and generate a new `<ProjectGuid>` (PowerShell: `[guid]::NewGuid()`).
3. Add it to `ModDevelopment.Cpp.slnx`: in Visual Studio, right-click the solution > Add > Existing Project. Or add a `<Project Path="<YourMod>/<YourMod>.vcxproj" />` line to the file.
4. Write your loop in `script.cpp`. Look natives up in [`../reference/natives/`](../reference/natives/README.md).
5. Add it to `scripts/ModGuide.xml` and `docs/mods_info/MODS.md` when it works, and track the `.asi` in git like the other mods.

## Debugging C++

- A crash closes the game. Check `ScriptHookV.log` and Windows Event Viewer (Windows Logs > Application) for the faulting module.
- Breakpoints: build Debug, copy the `.asi` **and** its `.pdb` into the game folder, start the game, then in Visual Studio use Debug > Attach to Process > `GTA5.exe` with code type **Native**.
- Write your own log: `std::ofstream("HelloAsi.log", std::ios::app) << "message\n";` (relative paths are the game folder).
