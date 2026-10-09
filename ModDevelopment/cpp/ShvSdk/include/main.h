// ScriptHookV API: the functions ScriptHookV.dll exports for C++ (.asi) mods.
//
// Written for this repo from the DLL's export table (dumpbin /exports ScriptHookV.dll) so .asi mods can be
// built without downloading the official SDK. The names, parameters and calling convention match the official
// SDK's main.h, so code written for the SDK compiles against this file too.
// Full explanations: ModDevelopment/docs/guides/04-ScriptHookV-CPP.md

#pragma once

#include <windows.h>

#define IMPORT __declspec(dllimport)

// ---- Textures (.dds/.png drawn on screen, independent of the game's texture dictionaries)

// Loads a texture file and returns its id. Call once, not every frame.
IMPORT int createTexture(const char* texFileName);

// Draws a texture created with createTexture. Call every frame you want it visible.
//   id                       texture id from createTexture
//   index                    slot 0 to 63; drawing with the same id and index replaces the previous draw
//   level                    draw order; higher levels draw on top
//   time                     how long the draw stays, in ms
//   sizeX, sizeY             size, as a fraction of the screen width (both scaled by the width)
//   centerX, centerY         rotation centre inside the texture, 0.0 to 1.0
//   posX, posY               screen position, 0.0 to 1.0
//   rotation                 0.0 to 1.0 is one full turn
//   screenHeightScaleFactor  usually the screen aspect ratio
//   r, g, b, a               colour multiplier, 0.0 to 1.0
IMPORT void drawTexture(int id, int index, int level, int time,
	float sizeX, float sizeY, float centerX, float centerY,
	float posX, float posY, float rotation, float screenHeightScaleFactor,
	float r, float g, float b, float a);

// Called once per frame by the game's DirectX 11 swap chain (IDXGISwapChain*). For overlays drawn with D3D11.
typedef void (*PresentCallback)(void*);
IMPORT void presentCallbackRegister(PresentCallback cb);
IMPORT void presentCallbackUnregister(PresentCallback cb);

// ---- Keyboard

// Called for every key event, on the game's window thread. Keep it short: store the key state and return.
//   key            Windows virtual-key code (VK_F5, 'A', ...)
//   repeats        repeat count for held keys
//   scanCode       hardware scan code
//   isExtended     extended key (right Ctrl, arrow keys, ...)
//   isWithAlt      Alt was held
//   wasDownBefore  the key was already down (auto-repeat)
//   isUpNow        TRUE when the key was released, FALSE when pressed
typedef void (*KeyboardHandler)(DWORD key, WORD repeats, BYTE scanCode, BOOL isExtended, BOOL isWithAlt, BOOL wasDownBefore, BOOL isUpNow);
IMPORT void keyboardHandlerRegister(KeyboardHandler handler);
IMPORT void keyboardHandlerUnregister(KeyboardHandler handler);

// ---- Scripts

// Registers the function that runs your script. Call it from DllMain on DLL_PROCESS_ATTACH.
// The function runs on a game script thread and must loop forever, calling scriptWait() every iteration.
IMPORT void scriptRegister(HMODULE module, void (*LP_SCRIPT_MAIN)());

// Registers another loop for the same module, running as its own script thread.
IMPORT void scriptRegisterAdditionalThread(HMODULE module, void (*LP_SCRIPT_MAIN)());

// Unregisters every script of the module. Call it from DllMain on DLL_PROCESS_DETACH.
IMPORT void scriptUnregister(HMODULE module);

// Older form that unregisters one script function. Prefer the HMODULE version.
IMPORT void scriptUnregister(void (*LP_SCRIPT_MAIN)());

// Pauses the current script for at least `time` ms and lets the game run. scriptWait(0) waits one frame.
// Natives may only be called from a script thread, between these waits.
IMPORT void scriptWait(DWORD time);

// TRUE when scripts were started by ScriptHookV's reload feature (Ctrl+R in some setups) rather than at game start.
IMPORT bool scriptsAreLaunchedUsingReloading();

// ---- Native functions (normally used through invoke<> in nativeCaller.h, not directly)

// Starts a native call with the native's 64-bit hash.
IMPORT void nativeInit(UINT64 hash);
// Pushes one argument (any 8-byte value: int, float, BOOL, pointer, handle).
IMPORT void nativePush64(UINT64 val);
// Runs the native and returns a pointer to its result.
IMPORT PUINT64 nativeCall();
// TRUE when natives can be called from the current thread (a ScriptHookV script thread).
IMPORT bool nativeCanExecuteInThisContext();

// ---- Game memory

// Returns a pointer to the game script global with the given index. Indexes change with game updates.
IMPORT UINT64* getGlobalPtr(int globalId);

// Returns the address of the game object behind an entity handle (ped, vehicle, object). Offsets inside it
// change with game updates, so only use it if you know the exact build.
IMPORT BYTE* getScriptHandleBaseAddress(int handle);

// Fill `arr` with the handles of every entity of that kind in the world. Return the number written.
IMPORT int worldGetAllVehicles(int* arr, int arrSize);
IMPORT int worldGetAllPeds(int* arr, int arrSize);
IMPORT int worldGetAllObjects(int* arr, int arrSize);
IMPORT int worldGetAllPickups(int* arr, int arrSize);

// ---- Game version

// The game build ScriptHookV detected. Only the values needed to recognise current builds are listed;
// compare with the raw number for others. ScriptHookV.log prints the detected version at startup.
enum eGameVersion : int
{
	VER_UNK = -1,
};

IMPORT eGameVersion getGameVersion();

// Not declared here: getGameVersionInfo(). It returns a struct whose layout isn't published, so calling it
// with a guessed layout could corrupt memory. Use getGameVersion() instead.
