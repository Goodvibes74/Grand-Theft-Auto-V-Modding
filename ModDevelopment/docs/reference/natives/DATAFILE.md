# DATAFILE natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## DATAARRAY_ADD_BOOL

```c
void DATAARRAY_ADD_BOOL(Any* arrayData, BOOL value)  // 0xF8B0F5A43E928C76
```

build 323 · old names: `_ARRAY_VALUE_ADD_BOOLEAN`

## DATAARRAY_ADD_DICT

```c
Any* DATAARRAY_ADD_DICT(Any* arrayData)  // 0x6889498B3E19C797
```

build 323 · old names: `_ARRAY_VALUE_ADD_OBJECT`

## DATAARRAY_ADD_FLOAT

```c
void DATAARRAY_ADD_FLOAT(Any* arrayData, float value)  // 0x57A995FD75D37F56
```

build 323 · old names: `_ARRAY_VALUE_ADD_FLOAT`

## DATAARRAY_ADD_INT

```c
void DATAARRAY_ADD_INT(Any* arrayData, int value)  // 0xCABDB751D86FE93B
```

build 323 · old names: `_ARRAY_VALUE_ADD_INTEGER`

## DATAARRAY_ADD_STRING

```c
void DATAARRAY_ADD_STRING(Any* arrayData, const char* value)  // 0x2F0661C155AEEEAA
```

build 323 · old names: `_ARRAY_VALUE_ADD_STRING`

## DATAARRAY_ADD_VECTOR

```c
void DATAARRAY_ADD_VECTOR(Any* arrayData, float valueX, float valueY, float valueZ)  // 0x407F8D034F70F0C2
```

build 323 · old names: `_ARRAY_VALUE_ADD_VECTOR3`

## DATAARRAY_GET_BOOL

```c
BOOL DATAARRAY_GET_BOOL(Any* arrayData, int arrayIndex)  // 0x50C1B2874E50C114
```

build 323 · old names: `_ARRAY_VALUE_GET_BOOLEAN`

## DATAARRAY_GET_COUNT

```c
int DATAARRAY_GET_COUNT(Any* arrayData)  // 0x065DB281590CEA2D
```

build 323 · old names: `_ARRAY_VALUE_GET_SIZE`

## DATAARRAY_GET_DICT

```c
Any* DATAARRAY_GET_DICT(Any* arrayData, int arrayIndex)  // 0x8B5FADCC4E3A145F
```

build 323 · old names: `_ARRAY_VALUE_GET_OBJECT`

## DATAARRAY_GET_FLOAT

```c
float DATAARRAY_GET_FLOAT(Any* arrayData, int arrayIndex)  // 0xC0C527B525D7CFB5
```

build 323 · old names: `_ARRAY_VALUE_GET_FLOAT`

## DATAARRAY_GET_INT

```c
int DATAARRAY_GET_INT(Any* arrayData, int arrayIndex)  // 0x3E5AE19425CD74BE
```

build 323 · old names: `_ARRAY_VALUE_GET_INTEGER`

## DATAARRAY_GET_STRING

```c
const char* DATAARRAY_GET_STRING(Any* arrayData, int arrayIndex)  // 0xD3F2FFEB8D836F52
```

build 323 · old names: `_ARRAY_VALUE_GET_STRING`

## DATAARRAY_GET_TYPE

```c
int DATAARRAY_GET_TYPE(Any* arrayData, int arrayIndex)  // 0x3A0014ADB172A3C5
```

build 323 · old names: `_ARRAY_VALUE_GET_TYPE`

> Types:
> 1 = Boolean
> 2 = Integer
> 3 = Float
> 4 = String
> 5 = Vector3
> 6 = Object
> 7 = Array

## DATAARRAY_GET_VECTOR

```c
Vector3 DATAARRAY_GET_VECTOR(Any* arrayData, int arrayIndex)  // 0x8D2064E5B64A628A
```

build 323 · old names: `_ARRAY_VALUE_GET_VECTOR3`

## DATADICT_CREATE_ARRAY

```c
Any* DATADICT_CREATE_ARRAY(Any* objectData, const char* key)  // 0x5B11728527CA6E5F
```

build 323 · old names: `_OBJECT_VALUE_ADD_ARRAY`

## DATADICT_CREATE_DICT

```c
Any* DATADICT_CREATE_DICT(Any* objectData, const char* key)  // 0xA358F56F10732EE1
```

build 323 · old names: `_OBJECT_VALUE_ADD_OBJECT`

## DATADICT_GET_ARRAY

```c
Any* DATADICT_GET_ARRAY(Any* objectData, const char* key)  // 0x7A983AA9DA2659ED
```

build 323 · old names: `_OBJECT_VALUE_GET_ARRAY`

## DATADICT_GET_BOOL

```c
BOOL DATADICT_GET_BOOL(Any* objectData, const char* key)  // 0x1186940ED72FFEEC
```

build 323 · old names: `_OBJECT_VALUE_GET_BOOLEAN`

## DATADICT_GET_DICT

```c
Any* DATADICT_GET_DICT(Any* objectData, const char* key)  // 0xB6B9DDC412FCEEE2
```

build 323 · old names: `_OBJECT_VALUE_GET_OBJECT`

## DATADICT_GET_FLOAT

```c
float DATADICT_GET_FLOAT(Any* objectData, const char* key)  // 0x06610343E73B9727
```

build 323 · old names: `_OBJECT_VALUE_GET_FLOAT`

## DATADICT_GET_INT

```c
int DATADICT_GET_INT(Any* objectData, const char* key)  // 0x78F06F6B1FB5A80C
```

build 323 · old names: `_OBJECT_VALUE_GET_INTEGER`

## DATADICT_GET_STRING

```c
const char* DATADICT_GET_STRING(Any* objectData, const char* key)  // 0x3D2FD9E763B24472
```

build 323 · old names: `_OBJECT_VALUE_GET_STRING`

## DATADICT_GET_TYPE

```c
int DATADICT_GET_TYPE(Any* objectData, const char* key)  // 0x031C55ED33227371
```

build 323 · old names: `_OBJECT_VALUE_GET_TYPE`

> Types:
> 1 = Boolean
> 2 = Integer
> 3 = Float
> 4 = String
> 5 = Vector3
> 6 = Object
> 7 = Array

## DATADICT_GET_VECTOR

```c
Vector3 DATADICT_GET_VECTOR(Any* objectData, const char* key)  // 0x46CD3CB66E0825CC
```

build 323 · old names: `_OBJECT_VALUE_GET_VECTOR3`

## DATADICT_SET_BOOL

```c
void DATADICT_SET_BOOL(Any* objectData, const char* key, BOOL value)  // 0x35124302A556A325
```

build 323 · old names: `_OBJECT_VALUE_ADD_BOOLEAN`

## DATADICT_SET_FLOAT

```c
void DATADICT_SET_FLOAT(Any* objectData, const char* key, float value)  // 0xC27E1CC2D795105E
```

build 323 · old names: `_OBJECT_VALUE_ADD_FLOAT`

## DATADICT_SET_INT

```c
void DATADICT_SET_INT(Any* objectData, const char* key, int value)  // 0xE7E035450A7948D5
```

build 323 · old names: `_OBJECT_VALUE_ADD_INTEGER`

## DATADICT_SET_STRING

```c
void DATADICT_SET_STRING(Any* objectData, const char* key, const char* value)  // 0x8FF3847DADD8E30C
```

build 323 · old names: `_OBJECT_VALUE_ADD_STRING`

## DATADICT_SET_VECTOR

```c
void DATADICT_SET_VECTOR(Any* objectData, const char* key, float valueX, float valueY, float valueZ)  // 0x4CD49B76338C7DEE
```

build 323 · old names: `_OBJECT_VALUE_ADD_VECTOR3`

## DATAFILE_CLEAR_WATCH_LIST

```c
void DATAFILE_CLEAR_WATCH_LIST()  // 0x6CC86E78358D5119
```

build 323

## DATAFILE_CREATE

```c
void DATAFILE_CREATE(int p0)  // 0xD27058A1CA2B13EE
```

build 323

## DATAFILE_DELETE

```c
void DATAFILE_DELETE(int p0)  // 0x9AB9C1CFC8862DFB
```

build 323

## DATAFILE_DELETE_FOR_ADDITIONAL_DATA_FILE

```c
void DATAFILE_DELETE_FOR_ADDITIONAL_DATA_FILE(Any p0)  // 0x6AD0BD5E087866CB
```

build 2189

## DATAFILE_DELETE_REQUESTED_FILE

```c
BOOL DATAFILE_DELETE_REQUESTED_FILE(int requestId)  // 0x8F5EA1C01D65A100
```

build 323

## DATAFILE_FLUSH_MISSION_HEADER

```c
void DATAFILE_FLUSH_MISSION_HEADER()  // 0xC55854C7D7274882
```

build 323

## DATAFILE_GET_FILE_DICT

```c
Any* DATAFILE_GET_FILE_DICT(int p0)  // 0x906B778CA1DC72B6
```

build 323

## DATAFILE_GET_FILE_DICT_FOR_ADDITIONAL_DATA_FILE

```c
Any* DATAFILE_GET_FILE_DICT_FOR_ADDITIONAL_DATA_FILE(Any p0)  // 0xDBF860CF1DB8E599
```

build 2189

## DATAFILE_HAS_LOADED_FILE_DATA

```c
BOOL DATAFILE_HAS_LOADED_FILE_DATA(int requestId)  // 0x15FF52B809DB2353
```

build 323

## DATAFILE_HAS_VALID_FILE_DATA

```c
BOOL DATAFILE_HAS_VALID_FILE_DATA(int requestId)  // 0xF8CC1EBE0B62E29F
```

build 323

## DATAFILE_IS_SAVE_PENDING

```c
BOOL DATAFILE_IS_SAVE_PENDING()  // 0xBEDB96A7584AA8CF
```

build 323

## DATAFILE_IS_VALID_REQUEST_ID

```c
BOOL DATAFILE_IS_VALID_REQUEST_ID(int index)  // 0xFCCAE5B92A830878
```

build 323

## DATAFILE_LOAD_OFFLINE_UGC

```c
BOOL DATAFILE_LOAD_OFFLINE_UGC(const char* filename, Any p1)  // 0xC5238C011AF405E4
```

build 323 · old names: `_LOAD_UGC_FILE`

> Loads a User-Generated Content (UGC) file. These files can be found in "[GTA5]\data\ugc" and "[GTA5]\common\patch\ugc". They seem to follow a naming convention, most likely of "[name]_[part].ugc". See example below for usage.
> 
> Returns whether or not the file was successfully loaded.
> 
> Example:
> DATAFILE::DATAFILE_LOAD_OFFLINE_UGC("RockstarPlaylists") // loads "rockstarplaylists_00.ugc"

## DATAFILE_LOAD_OFFLINE_UGC_FOR_ADDITIONAL_DATA_FILE

```c
BOOL DATAFILE_LOAD_OFFLINE_UGC_FOR_ADDITIONAL_DATA_FILE(Any p0, Any p1)  // 0xA6EEF01087181EDD
```

build 2189

## DATAFILE_SELECT_ACTIVE_FILE

```c
BOOL DATAFILE_SELECT_ACTIVE_FILE(int requestId, Any p1)  // 0x22DA66936E0FFF37
```

build 323

## DATAFILE_SELECT_CREATOR_STATS

```c
BOOL DATAFILE_SELECT_CREATOR_STATS(int p0, Any p1)  // 0x01095C95CD46B624
```

build 323

## DATAFILE_SELECT_UGC_DATA

```c
BOOL DATAFILE_SELECT_UGC_DATA(int p0, Any p1)  // 0xA69AC4ADE82B57A4
```

build 323

## DATAFILE_SELECT_UGC_PLAYER_DATA

```c
BOOL DATAFILE_SELECT_UGC_PLAYER_DATA(int p0, Any p1)  // 0x52818819057F2B40
```

build 323

## DATAFILE_SELECT_UGC_STATS

```c
BOOL DATAFILE_SELECT_UGC_STATS(int p0, BOOL p1, Any p2)  // 0x9CB0BFA7A9342C3D
```

build 323

## DATAFILE_START_SAVE_TO_CLOUD

```c
BOOL DATAFILE_START_SAVE_TO_CLOUD(const char* filename, Any p1)  // 0x83BCCE3224735F05
```

build 323

## DATAFILE_STORE_MISSION_HEADER

```c
void DATAFILE_STORE_MISSION_HEADER(int p0)  // 0x2ED61456317B8178
```

build 323

## DATAFILE_UPDATE_SAVE_TO_CLOUD

```c
BOOL DATAFILE_UPDATE_SAVE_TO_CLOUD(BOOL* p0)  // 0x4DFDD9EB705F8140
```

build 323

## DATAFILE_WATCH_REQUEST_ID

```c
void DATAFILE_WATCH_REQUEST_ID(int requestId)  // 0xAD6875BBC0FC899C
```

build 323

> Adds the given requestID to the watch list.

## UGC_CREATE_CONTENT

```c
BOOL UGC_CREATE_CONTENT(Any* data, int dataCount, const char* contentName, const char* description, const char* tagsCsv, const char* contentTypeName, BOOL publish, Any p7)  // 0xC84527E235FCA219
```

build 323

## UGC_CREATE_MISSION

```c
BOOL UGC_CREATE_MISSION(const char* contentName, const char* description, const char* tagsCsv, const char* contentTypeName, BOOL publish, Any p5)  // 0xA5EFC3E847D60507
```

build 323

## UGC_SET_PLAYER_DATA

```c
BOOL UGC_SET_PLAYER_DATA(const char* contentId, float rating, const char* contentTypeName, Any p3)  // 0x692D808C34A82143
```

build 323

## UGC_UPDATE_CONTENT

```c
BOOL UGC_UPDATE_CONTENT(const char* contentId, Any* data, int dataCount, const char* contentName, const char* description, const char* tagsCsv, const char* contentTypeName, Any p7)  // 0x648E7A5434AF7969
```

build 323

## UGC_UPDATE_MISSION

```c
BOOL UGC_UPDATE_MISSION(const char* contentId, const char* contentName, const char* description, const char* tagsCsv, const char* contentTypeName, Any p5)  // 0x4645DE9980999E93
```

build 323

