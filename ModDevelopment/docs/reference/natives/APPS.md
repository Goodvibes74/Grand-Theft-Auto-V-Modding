# APPS natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## APP_CLEAR_BLOCK

```c
void APP_CLEAR_BLOCK()  // 0x5FE1DF3342DB7DBA
```

build 323

## APP_CLOSE_APP

```c
void APP_CLOSE_APP()  // 0xE41C65E07A5F05FC
```

build 323

## APP_CLOSE_BLOCK

```c
void APP_CLOSE_BLOCK()  // 0xE8E3FCF72EAC0EF8
```

build 323

## APP_DATA_VALID

```c
BOOL APP_DATA_VALID()  // 0x846AA8E7D55EE5B6
```

build 323

## APP_DELETE_APP_DATA

```c
BOOL APP_DELETE_APP_DATA(const char* appName)  // 0x44151AEA95C8A003
```

build 323

## APP_GET_DELETED_FILE_STATUS

```c
int APP_GET_DELETED_FILE_STATUS()  // 0xC9853A2BE3DED1A6
```

build 323

## APP_GET_FLOAT

```c
float APP_GET_FLOAT(const char* property)  // 0x1514FB24C02C2322
```

build 323

## APP_GET_INT

```c
int APP_GET_INT(const char* property)  // 0xD3A58A12C77D9D4B
```

build 323

## APP_GET_STRING

```c
const char* APP_GET_STRING(const char* property)  // 0x749B023950D2311C
```

build 323

## APP_HAS_LINKED_SOCIAL_CLUB_ACCOUNT

```c
BOOL APP_HAS_LINKED_SOCIAL_CLUB_ACCOUNT()  // 0x71EEE69745088DA0
```

build 323

## APP_HAS_SYNCED_DATA

```c
BOOL APP_HAS_SYNCED_DATA(const char* appName)  // 0xCA52279A7271517F
```

build 323

## APP_SAVE_DATA

```c
void APP_SAVE_DATA()  // 0x95C5D356CDA6E85F
```

build 323

## APP_SET_APP

```c
void APP_SET_APP(const char* appName)  // 0xCFD0406ADAF90D2B
```

build 323

> Called in the gamescripts like:
> APP::APP_SET_APP("car");
> APP::APP_SET_APP("dog");

## APP_SET_BLOCK

```c
void APP_SET_BLOCK(const char* blockName)  // 0x262AB456A3D21F93
```

build 323

## APP_SET_FLOAT

```c
void APP_SET_FLOAT(const char* property, float value)  // 0x25D7687C68E0DAA4
```

build 323

## APP_SET_INT

```c
void APP_SET_INT(const char* property, int value)  // 0x607E8E3D3E4F9611
```

build 323

## APP_SET_STRING

```c
void APP_SET_STRING(const char* property, const char* value)  // 0x3FF2FCEC4B7721B4
```

build 323

