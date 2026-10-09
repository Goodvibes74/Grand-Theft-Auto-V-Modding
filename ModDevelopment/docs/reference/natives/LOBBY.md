# LOBBY natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## LOBBY_AUTO_MULTIPLAYER_EVENT

```c
BOOL LOBBY_AUTO_MULTIPLAYER_EVENT()  // 0x8AA464D4E0F6ACCD
```

build 323 · old names: `_LOADINGSCREEN_GET_LOAD_FREEMODE_WITH_EVENT_NAME`

## LOBBY_AUTO_MULTIPLAYER_FREEMODE

```c
BOOL LOBBY_AUTO_MULTIPLAYER_FREEMODE()  // 0xEF7D17BC6C85264C
```

build 323 · old names: `_LOADINGSCREEN_GET_LOAD_FREEMODE`

## LOBBY_AUTO_MULTIPLAYER_MENU

```c
BOOL LOBBY_AUTO_MULTIPLAYER_MENU()  // 0xF2CA003F167E21D2
```

build 323 · old names: `_RETURN_ZERO`

> This function is hard-coded to always return 0.

## LOBBY_AUTO_MULTIPLAYER_RANDOM_JOB

```c
BOOL LOBBY_AUTO_MULTIPLAYER_RANDOM_JOB()  // 0xC6DC823253FBB366
```

build 323 · old names: `_IS_UI_LOADING_MULTIPLAYER`, `_LOADINGSCREEN_IS_LOADING_FREEMODE`

## LOBBY_SET_AUTO_MP_RANDOM_JOB

```c
void LOBBY_SET_AUTO_MP_RANDOM_JOB(BOOL toggle)  // 0xC7E7181C09F33B69
```

build 323 · old names: `_LOADINGSCREEN_SET_IS_LOADING_FREEMODE`

## LOBBY_SET_AUTO_MULTIPLAYER

```c
void LOBBY_SET_AUTO_MULTIPLAYER(BOOL toggle)  // 0xB0C56BD3D808D863
```

build 323 · old names: `_GET_BROADCAST_FINSHED_LOS_SOUND`, `_LOADINGSCREEN_SET_LOAD_FREEMODE`

## LOBBY_SET_AUTO_MULTIPLAYER_EVENT

```c
void LOBBY_SET_AUTO_MULTIPLAYER_EVENT(BOOL toggle)  // 0xFC309E94546FCDB5
```

build 323 · old names: `_IS_IN_LOADING_SCREEN`, `_LOADINGSCREEN_SET_LOAD_FREEMODE_WITH_EVENT_NAME`

## SHUTDOWN_SESSION_CLEARS_AUTO_MULTIPLAYER

```c
void SHUTDOWN_SESSION_CLEARS_AUTO_MULTIPLAYER(BOOL toggle)  // 0xFA1E0E893D915215
```

build 323

