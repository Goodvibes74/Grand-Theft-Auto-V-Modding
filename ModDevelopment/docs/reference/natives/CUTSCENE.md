# CUTSCENE natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## CAN_REQUEST_ASSETS_FOR_CUTSCENE_ENTITY

```c
BOOL CAN_REQUEST_ASSETS_FOR_CUTSCENE_ENTITY()  // 0xB56BBBCC2955D9CB
```

build 323

## CAN_SET_ENTER_STATE_FOR_REGISTERED_ENTITY

```c
BOOL CAN_SET_ENTER_STATE_FOR_REGISTERED_ENTITY(const char* cutsceneEntName, Hash modelHash)  // 0x645D0B458D8E17B5
```

build 323

> modelHash (p1) was always 0 in R* scripts

## CAN_SET_EXIT_STATE_FOR_CAMERA

```c
BOOL CAN_SET_EXIT_STATE_FOR_CAMERA(BOOL p0)  // 0xB2CBCD0930DFB420
```

build 323

## CAN_SET_EXIT_STATE_FOR_REGISTERED_ENTITY

```c
BOOL CAN_SET_EXIT_STATE_FOR_REGISTERED_ENTITY(const char* cutsceneEntName, Hash modelHash)  // 0x4C6A6451C79E4662
```

build 323

## CAN_USE_MOBILE_PHONE_DURING_CUTSCENE

```c
BOOL CAN_USE_MOBILE_PHONE_DURING_CUTSCENE()  // 0x5EDEF0CF8C1DAB3C
```

build 323

## DOES_CUTSCENE_ENTITY_EXIST

```c
BOOL DOES_CUTSCENE_ENTITY_EXIST(const char* cutsceneEntName, Hash modelHash)  // 0x499EF20C5DB25C59
```

build 323

## DOES_CUTSCENE_HANDLE_EXIST

```c
int DOES_CUTSCENE_HANDLE_EXIST(int cutsceneHandle)  // 0x4FCD976DA686580C
```

build 1290

## GET_CUT_FILE_CONCAT_COUNT

```c
int GET_CUT_FILE_CONCAT_COUNT(const char* cutsceneName)  // 0x0ABC54DE641DC0FC
```

build 323 · old names: `_GET_CUT_FILE_NUM_SECTIONS`

> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## GET_CUT_FILE_OFFSET

```c
Vector3 GET_CUT_FILE_OFFSET(const char* cutsceneName, int index)  // 0x1FA904B60E492336
```

build 3570

## GET_CUTSCENE_CONCAT_SECTION_PLAYING

```c
int GET_CUTSCENE_CONCAT_SECTION_PLAYING()  // 0x583DF8E3D4AFBD98
```

build 323

## GET_CUTSCENE_END_TIME

```c
int GET_CUTSCENE_END_TIME()  // 0x971D7B15BCDBEF99
```

build 1734

## GET_CUTSCENE_PLAY_DURATION

```c
int GET_CUTSCENE_PLAY_DURATION()  // 0x5D583F71C901F2A3
```

build 2802

## GET_CUTSCENE_PLAY_TIME

```c
int GET_CUTSCENE_PLAY_TIME()  // 0x710286BC5EF4D6E1
```

build 3258

## GET_CUTSCENE_SECTION_PLAYING

```c
int GET_CUTSCENE_SECTION_PLAYING()  // 0x49010A6A396553D8
```

build 323

## GET_CUTSCENE_TIME

```c
int GET_CUTSCENE_TIME()  // 0xE625BEABBAFFDAB9
```

build 323

## GET_CUTSCENE_TOTAL_DURATION

```c
int GET_CUTSCENE_TOTAL_DURATION()  // 0xEE53B14A19E480D4
```

build 323

## GET_ENTITY_INDEX_OF_CUTSCENE_ENTITY

```c
Entity GET_ENTITY_INDEX_OF_CUTSCENE_ENTITY(const char* cutsceneEntName, Hash modelHash)  // 0x0A2E9FDB9A8C62F6
```

build 323

## GET_ENTITY_INDEX_OF_REGISTERED_ENTITY

```c
Entity GET_ENTITY_INDEX_OF_REGISTERED_ENTITY(const char* cutsceneEntName, Hash modelHash)  // 0xC0741A26499654CD
```

build 323

## HAS_CUT_FILE_LOADED

```c
BOOL HAS_CUT_FILE_LOADED(const char* cutsceneName)  // 0xA1C996C2A744262E
```

build 323

> Simply checks if the cutscene has loaded and doesn't check via CutSceneManager as opposed to HAS_[THIS]_CUTSCENE_LOADED.
> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## HAS_CUTSCENE_CUT_THIS_FRAME

```c
BOOL HAS_CUTSCENE_CUT_THIS_FRAME()  // 0x708BDD8CD795B043
```

build 323 · old names: `_HAS_CUTSCENE_CUT_THIS_FRAME`

> Possibly HAS_CUTSCENE_CUT_THIS_FRAME, needs more research.

## HAS_CUTSCENE_FINISHED

```c
BOOL HAS_CUTSCENE_FINISHED()  // 0x7C0A893088881D57
```

build 323

## HAS_CUTSCENE_LOADED

```c
BOOL HAS_CUTSCENE_LOADED()  // 0xC59F528E9AB9F339
```

build 323

## HAS_THIS_CUTSCENE_LOADED

```c
BOOL HAS_THIS_CUTSCENE_LOADED(const char* cutsceneName)  // 0x228D3D94F8A11C3C
```

build 323

> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## IS_CUTSCENE_ACTIVE

```c
BOOL IS_CUTSCENE_ACTIVE()  // 0x991251AFC3981F84
```

build 323

## IS_CUTSCENE_AUTHORIZED

```c
BOOL IS_CUTSCENE_AUTHORIZED(const char* cutsceneName)  // 0x4CEBC1ED31E8925E
```

build 323

> This function is hard-coded to always return 1.

## IS_CUTSCENE_PLAYBACK_FLAG_SET

```c
BOOL IS_CUTSCENE_PLAYBACK_FLAG_SET(int flag)  // 0x71B74D2AE19338D0
```

build 323

## IS_CUTSCENE_PLAYING

```c
BOOL IS_CUTSCENE_PLAYING()  // 0xD3C2E180A40F031E
```

build 323

## IS_MULTIHEAD_FADE_UP

```c
BOOL IS_MULTIHEAD_FADE_UP()  // 0xA0FE76168A189DDB
```

build 323

## NETWORK_SET_MOCAP_CUTSCENE_CAN_BE_SKIPPED

```c
void NETWORK_SET_MOCAP_CUTSCENE_CAN_BE_SKIPPED(BOOL toggle)  // 0x2F137B508DE238F2
```

build 323

## REGISTER_ENTITY_FOR_CUTSCENE

```c
void REGISTER_ENTITY_FOR_CUTSCENE(Ped cutscenePed, const char* cutsceneEntName, int p2, Hash modelHash, int p4)  // 0xE40C1C56DF95C2E8
```

build 323

## REMOVE_CUT_FILE

```c
void REMOVE_CUT_FILE(const char* cutsceneName)  // 0xD00D76A7DFC9D852
```

build 323

> Simply unloads the cutscene and doesn't do extra stuff that REMOVE_CUTSCENE does.
> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## REMOVE_CUTSCENE

```c
void REMOVE_CUTSCENE()  // 0x440AF51A3462B86F
```

build 323

## REQUEST_CUT_FILE

```c
void REQUEST_CUT_FILE(const char* cutsceneName)  // 0x06A3524161C502BA
```

build 323

> Simply loads the cutscene and doesn't do extra stuff that REQUEST_CUTSCENE does.
> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## REQUEST_CUTSCENE

```c
void REQUEST_CUTSCENE(const char* cutsceneName, int flags)  // 0x7A86743F475D9E09
```

build 323

> flags: Usually 8
> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## REQUEST_CUTSCENE_WITH_PLAYBACK_LIST

```c
void REQUEST_CUTSCENE_WITH_PLAYBACK_LIST(const char* cutsceneName, int playbackFlags, int flags)  // 0xC23DE0E91C30B58C
```

build 323 · old names: `_REQUEST_CUTSCENE_EX`

> flags: Usually 8
> 
> playbackFlags: Which scenes should be played.
> Example: 0x105 (bit 0, 2 and 8 set) will enable scene 1, 3 and 9.
> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## SET_CAN_DISPLAY_MINIMAP_DURING_CUTSCENE_THIS_UPDATE

```c
void SET_CAN_DISPLAY_MINIMAP_DURING_CUTSCENE_THIS_UPDATE()  // 0x2131046957F31B04
```

build 323 · old names: `REGISTER_SYNCHRONISED_SCRIPT_SPEECH`

## SET_CAR_GENERATORS_CAN_UPDATE_DURING_CUTSCENE

```c
void SET_CAR_GENERATORS_CAN_UPDATE_DURING_CUTSCENE(BOOL p0)  // 0xE36A98D8AB3D3C66
```

build 323

## SET_CUTSCENE_CAN_BE_SKIPPED

```c
void SET_CUTSCENE_CAN_BE_SKIPPED(BOOL p0)  // 0x41FAA8FB2ECE8720
```

build 323

## SET_CUTSCENE_ENTITY_STREAMING_FLAGS

```c
void SET_CUTSCENE_ENTITY_STREAMING_FLAGS(const char* cutsceneEntName, int p1, int p2)  // 0x4C61C75BEE8184C2
```

build 323

## SET_CUTSCENE_FADE_VALUES

```c
void SET_CUTSCENE_FADE_VALUES(BOOL p0, BOOL p1, BOOL p2, BOOL p3)  // 0x8093F23ABACCC7D4
```

build 323

## SET_CUTSCENE_MULTIHEAD_FADE

```c
void SET_CUTSCENE_MULTIHEAD_FADE(BOOL p0, BOOL p1, BOOL p2, BOOL p3)  // 0x20746F7B1032A3C7
```

build 323

## SET_CUTSCENE_MULTIHEAD_FADE_MANUAL

```c
void SET_CUTSCENE_MULTIHEAD_FADE_MANUAL(BOOL p0)  // 0x06EE9048FD080382
```

build 323

## SET_CUTSCENE_ORIGIN

```c
void SET_CUTSCENE_ORIGIN(float x, float y, float z, float p3, int p4)  // 0xB812B3FD1C01CF27
```

build 323

> p3 could be heading. Needs more research.

## SET_CUTSCENE_ORIGIN_AND_ORIENTATION

```c
void SET_CUTSCENE_ORIGIN_AND_ORIENTATION(float x1, float y1, float z1, float x2, float y2, float z2, int p6)  // 0x011883F41211432A
```

build 323

## SET_CUTSCENE_PED_COMPONENT_VARIATION

```c
void SET_CUTSCENE_PED_COMPONENT_VARIATION(const char* cutsceneEntName, int componentId, int drawableId, int textureId, Hash modelHash)  // 0xBA01E7B6DEEFBBC9
```

build 323

> Full list of ped components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedComponentVariations.json

## SET_CUTSCENE_PED_COMPONENT_VARIATION_FROM_PED

```c
void SET_CUTSCENE_PED_COMPONENT_VARIATION_FROM_PED(const char* cutsceneEntName, Ped ped, Hash modelHash)  // 0x2A56C06EBEF2B0D9
```

build 323

## SET_CUTSCENE_PED_PROP_VARIATION

```c
void SET_CUTSCENE_PED_PROP_VARIATION(const char* cutsceneEntName, int componentId, int drawableId, int textureId, Hash modelHash)  // 0x0546524ADE2E9723
```

build 323

> Thanks R*! ;)
> 
> if ((l_161 == 0) || (l_161 == 2)) {
>     sub_2ea27("Trying to set Jimmy prop variation");
>     CUTSCENE::SET_CUTSCENE_PED_PROP_VARIATION("Jimmy_Boston", 1, 0, 0, 0);
> }
> 
> Full list of ped components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedComponentVariations.json

## SET_CUTSCENE_TRIGGER_AREA

```c
void SET_CUTSCENE_TRIGGER_AREA(float x1, float y1, float z1, float x2, float y2, float z2)  // 0x9896CE4721BE84BA
```

build 323

> Only used twice in R* scripts

## SET_PAD_CAN_SHAKE_DURING_CUTSCENE

```c
void SET_PAD_CAN_SHAKE_DURING_CUTSCENE(BOOL toggle)  // 0xC61B86C9F61EB404
```

build 323

> Toggles a value (bool) for cutscenes.

## SET_SCRIPT_CAN_START_CUTSCENE

```c
void SET_SCRIPT_CAN_START_CUTSCENE(int threadId)  // 0x8D9DF6ECA8768583
```

build 323

> Sets the cutscene's owning thread ID.

## SET_VEHICLE_MODEL_PLAYER_WILL_EXIT_SCENE

```c
void SET_VEHICLE_MODEL_PLAYER_WILL_EXIT_SCENE(Hash modelHash)  // 0x7F96F23FA9B73327
```

build 323

> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## START_CUTSCENE

```c
void START_CUTSCENE(int flags)  // 0x186D5CB5E7B0FF7B
```

build 323

> flags: Usually 0.

## START_CUTSCENE_AT_COORDS

```c
void START_CUTSCENE_AT_COORDS(float x, float y, float z, int flags)  // 0x1C9ADDA3244A1FBF
```

build 323

> flags: Usually 0.

## STOP_CUTSCENE

```c
void STOP_CUTSCENE(BOOL p0)  // 0xC7272775B4DC786E
```

build 323

## STOP_CUTSCENE_IMMEDIATELY

```c
void STOP_CUTSCENE_IMMEDIATELY()  // 0xD220BDD222AC4A1E
```

build 323

## WAS_CUTSCENE_SKIPPED

```c
BOOL WAS_CUTSCENE_SKIPPED()  // 0x40C8656EDAEDD569
```

build 323

