# RECORDING natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## CANCEL_REPLAY_RECORDING

```c
void CANCEL_REPLAY_RECORDING()  // 0x88BB3507ED41A240
```

build 323 · old names: `_STOP_RECORDING_AND_DISCARD_CLIP`

> Stops recording and discards the recorded clip.

## IS_REPLAY_AVAILABLE

```c
BOOL IS_REPLAY_AVAILABLE()  // 0x4282E08174868BE3
```

build 323

## IS_REPLAY_INITIALIZED

```c
BOOL IS_REPLAY_INITIALIZED()  // 0xDF4B952F7D381B95
```

build 323

## IS_REPLAY_RECORD_SPACE_AVAILABLE

```c
BOOL IS_REPLAY_RECORD_SPACE_AVAILABLE(BOOL p0)  // 0x33D47E85B476ABCD
```

build 323

## IS_REPLAY_RECORDING

```c
BOOL IS_REPLAY_RECORDING()  // 0x1897CA71995A90B4
```

build 323 · old names: `_IS_RECORDING`

> Checks if you're recording, returns TRUE when you start recording (F1) or turn on action replay (F2)
> 
> mov al, cs:g_bIsRecordingGameplay // byte_141DD0CD0 in b944
> retn

## RECORD_GREATEST_MOMENT

```c
void RECORD_GREATEST_MOMENT(int p0, int p1, int p2)  // 0x66972397E0757E7A
```

build 323

> Does nothing (it's a nullsub).

## REPLAY_CANCEL_EVENT

```c
void REPLAY_CANCEL_EVENT()  // 0x13B350B8AD0EEE10
```

build 323

## REPLAY_CHECK_FOR_EVENT_THIS_FRAME

```c
void REPLAY_CHECK_FOR_EVENT_THIS_FRAME(const char* missionNameLabel, Any p1)  // 0x208784099002BC30
```

build 323

> -This function appears to be deprecated/ unused. Tracing the call internally leads to a _nullsub -
> 
> first one seems to be a string of a mission name, second one seems to be a bool/toggle
> 
> p1 was always 0.
> 

## REPLAY_DISABLE_CAMERA_MOVEMENT_THIS_FRAME

```c
void REPLAY_DISABLE_CAMERA_MOVEMENT_THIS_FRAME()  // 0xAF66DCEE6609B148
```

build 323 · old names: `_DISABLE_ROCKSTAR_EDITOR_CAMERA_CHANGES`

> This will disable the ability to make camera changes in R* Editor.

## REPLAY_PREVENT_RECORDING_THIS_FRAME

```c
void REPLAY_PREVENT_RECORDING_THIS_FRAME()  // 0xEB2D525B57F42B40
```

build 323 · old names: `_STOP_RECORDING_THIS_FRAME`

> This disable the recording feature and has to be called every frame.

## REPLAY_RECORD_BACK_FOR_TIME

```c
void REPLAY_RECORD_BACK_FOR_TIME(float p0, float p1, int p2)  // 0x293220DA1B46CEBC
```

build 323

## REPLAY_RESET_EVENT_INFO

```c
void REPLAY_RESET_EVENT_INFO()  // 0xF854439EFBB3B583
```

build 323

## REPLAY_START_EVENT

```c
void REPLAY_START_EVENT(int p0)  // 0x48621C9FCA3EBD28
```

build 323

## REPLAY_STOP_EVENT

```c
void REPLAY_STOP_EVENT()  // 0x81CBAE94390F9F89
```

build 323

## SAVE_REPLAY_RECORDING

```c
BOOL SAVE_REPLAY_RECORDING()  // 0x644546EC5287471B
```

build 323 · old names: `_SAVE_RECORDING_CLIP`

## START_REPLAY_RECORDING

```c
void START_REPLAY_RECORDING(int mode)  // 0xC3AC2FFF9612AC81
```

build 323 · old names: `_START_RECORDING`

> Starts recording a replay.
> If mode is 0, turns on action replay.
> If mode is 1, starts recording.
> If already recording a replay, does nothing.

## STOP_REPLAY_RECORDING

```c
void STOP_REPLAY_RECORDING()  // 0x071A5197D6AFC8B3
```

build 323 · old names: `_STOP_RECORDING`, `_STOP_RECORDING_AND_SAVE_CLIP`

> Stops recording and saves the recorded clip.

