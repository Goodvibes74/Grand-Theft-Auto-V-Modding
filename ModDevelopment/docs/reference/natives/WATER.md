# WATER natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ADD_EXTRA_CALMING_QUAD

```c
int ADD_EXTRA_CALMING_QUAD(float xLow, float yLow, float xHigh, float yHigh, float height)  // 0xFDBF4CDBC07E1706
```

build 323 · old names: `_ADD_CURRENT_RISE`

## GET_DEEP_OCEAN_SCALER

```c
float GET_DEEP_OCEAN_SCALER()  // 0x2B2A2CC86778B619
```

build 323 · old names: `_GET_WAVES_INTENSITY`, `_GET_CURRENT_INTENSITY`

> Gets the aggressiveness factor of the ocean waves.

## GET_WATER_HEIGHT

```c
BOOL GET_WATER_HEIGHT(float x, float y, float z, float* height)  // 0xF6829842C06AE524
```

build 323

> This function set height to the value of z-axis of the water surface.
> 
> This function works with sea and lake. However it does not work with shallow rivers (e.g. raton canyon will return -100000.0f)
> 
> note: seems to return true when you are in water

## GET_WATER_HEIGHT_NO_WAVES

```c
BOOL GET_WATER_HEIGHT_NO_WAVES(float x, float y, float z, float* height)  // 0x8EE6B53CE13A9794
```

build 323

## MODIFY_WATER

```c
void MODIFY_WATER(float x, float y, float radius, float height)  // 0xC443FD757C3BA637
```

build 323

> Sets the water height for a given position and radius.
> 

## REMOVE_EXTRA_CALMING_QUAD

```c
void REMOVE_EXTRA_CALMING_QUAD(int calmingQuad)  // 0xB1252E3E59A82AAF
```

build 323 · old names: `_REMOVE_CURRENT_RISE`

> p0 is the handle returned from ADD_EXTRA_CALMING_QUAD

## RESET_DEEP_OCEAN_SCALER

```c
void RESET_DEEP_OCEAN_SCALER()  // 0x5E5E99285AE812DB
```

build 323 · old names: `_RESET_WAVES_INTENSITY`, `_RESET_CURRENT_INTENSITY`

> Sets the waves intensity back to original (1.0 in most cases).

## SET_CALMED_WAVE_HEIGHT_SCALER

```c
void SET_CALMED_WAVE_HEIGHT_SCALER(float height)  // 0x547237AA71AB44DE
```

build 573

## SET_DEEP_OCEAN_SCALER

```c
void SET_DEEP_OCEAN_SCALER(float intensity)  // 0xB96B00E976BE977F
```

build 323 · old names: `_SET_WAVES_INTENSITY`, `_SET_CURRENT_INTENSITY`

> Sets a value that determines how aggressive the ocean waves will be. Values of 2.0 or more make for very aggressive waves like you see during a thunderstorm.
> 
> Works only ~200 meters around the player.

## TEST_PROBE_AGAINST_ALL_WATER

```c
int TEST_PROBE_AGAINST_ALL_WATER(float x1, float y1, float z1, float x2, float y2, float z2, int flags, float* waterHeight)  // 0x8974647ED222EA5F
```

build 323

> enum eScriptWaterTestResult
> {
> 	SCRIPT_WATER_TEST_RESULT_NONE,
> 	SCRIPT_WATER_TEST_RESULT_WATER,
> 	SCRIPT_WATER_TEST_RESULT_BLOCKED,
> };

## TEST_PROBE_AGAINST_WATER

```c
BOOL TEST_PROBE_AGAINST_WATER(float x1, float y1, float z1, float x2, float y2, float z2, Vector3* result)  // 0xFFA5D878809819DB
```

build 323

## TEST_VERTICAL_PROBE_AGAINST_ALL_WATER

```c
int TEST_VERTICAL_PROBE_AGAINST_ALL_WATER(float x, float y, float z, int flags, float* waterHeight)  // 0x2B3451FA1E3142E2
```

build 323

> See TEST_PROBE_AGAINST_ALL_WATER.

