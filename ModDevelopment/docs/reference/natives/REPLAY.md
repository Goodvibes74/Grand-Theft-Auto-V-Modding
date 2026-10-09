# REPLAY natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ACTIVATE_ROCKSTAR_EDITOR

```c
void ACTIVATE_ROCKSTAR_EDITOR(int p0)  // 0x49DA8145672B2725
```

build 323 · old names: `_ACTIVATE_ROCKSTAR_EDITOR`

> Please note that you will need to call DO_SCREEN_FADE_IN after exiting the Rockstar Editor when you call this.

## REGISTER_EFFECT_FOR_REPLAY_EDITOR

```c
void REGISTER_EFFECT_FOR_REPLAY_EDITOR(const char* p0, BOOL p1)  // 0x7E2BD3EF6C205F09
```

build 323

> Does nothing (it's a nullsub).

## REPLAY_CONTROL_SHUTDOWN

```c
void REPLAY_CONTROL_SHUTDOWN()  // 0x3353D13F09307691
```

build 323 · old names: `_RESET_EDITOR_VALUES`

> Sets (almost, not sure) all Rockstar Editor values (bIsRecording etc) to 0.

## REPLAY_SYSTEM_HAS_REQUESTED_A_SCRIPT_CLEANUP

```c
BOOL REPLAY_SYSTEM_HAS_REQUESTED_A_SCRIPT_CLEANUP()  // 0x95AB8B5C992C7B58
```

build 323 · old names: `_IS_INTERIOR_RENDERING_DISABLED`

> Returns a bool if interior rendering is disabled, if yes, all "normal" rendered interiors are invisible

## SET_REPLAY_SYSTEM_PAUSED_FOR_SAVE

```c
void SET_REPLAY_SYSTEM_PAUSED_FOR_SAVE(BOOL p0)  // 0xE058175F8EAFE79A
```

build 323

## SET_SCRIPTS_HAVE_CLEANED_UP_FOR_REPLAY_SYSTEM

```c
void SET_SCRIPTS_HAVE_CLEANED_UP_FOR_REPLAY_SYSTEM()  // 0x5AD3932DAEB1E5D3
```

build 323

> Disables some other rendering (internal)

