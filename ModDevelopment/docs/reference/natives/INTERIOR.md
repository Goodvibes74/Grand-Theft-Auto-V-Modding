# INTERIOR natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ACTIVATE_INTERIOR_ENTITY_SET

```c
void ACTIVATE_INTERIOR_ENTITY_SET(Interior interior, const char* entitySetName)  // 0x55E86AF2712B36A1
```

build 323 · old names: `_ENABLE_INTERIOR_PROP`

> More info: https://gtaforums.com/topic/836367-adding-props-to-interiors/
> 
> Full list of IPLs and interior entity sets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ipls.json

## ACTIVATE_INTERIOR_GROUPS_USING_CAMERA

```c
void ACTIVATE_INTERIOR_GROUPS_USING_CAMERA()  // 0x483ACA1176CA93F1
```

build 1103

## ADD_PICKUP_TO_INTERIOR_ROOM_BY_NAME

```c
void ADD_PICKUP_TO_INTERIOR_ROOM_BY_NAME(Pickup pickup, const char* roomName)  // 0x3F6167F351168730
```

build 323

## CAP_INTERIOR

```c
void CAP_INTERIOR(Interior interior, BOOL toggle)  // 0xD9175F941610DB54
```

build 323

> Does something similar to INTERIOR::DISABLE_INTERIOR

## CLEAR_INTERIOR_STATE_OF_ENTITY

```c
void CLEAR_INTERIOR_STATE_OF_ENTITY(Entity entity)  // 0x85D5422B2039A70D
```

build 2189 · old names: `_CLEAR_INTERIOR_FOR_ENTITY`

> Immediately removes entity from an interior. Like sets entity to `limbo` room.

## CLEAR_ROOM_FOR_ENTITY

```c
void CLEAR_ROOM_FOR_ENTITY(Entity entity)  // 0xB365FC0C4E27FFA7
```

build 323

## CLEAR_ROOM_FOR_GAME_VIEWPORT

```c
void CLEAR_ROOM_FOR_GAME_VIEWPORT()  // 0x23B59D8912F94246
```

build 323

## DEACTIVATE_INTERIOR_ENTITY_SET

```c
void DEACTIVATE_INTERIOR_ENTITY_SET(Interior interior, const char* entitySetName)  // 0x420BD37289EEE162
```

build 323 · old names: `_DISABLE_INTERIOR_PROP`

> Full list of IPLs and interior entity sets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ipls.json

## DISABLE_INTERIOR

```c
void DISABLE_INTERIOR(Interior interior, BOOL toggle)  // 0x6170941419D7D8EC
```

build 323

## DISABLE_METRO_SYSTEM

```c
void DISABLE_METRO_SYSTEM(BOOL toggle)  // 0x9E6542F0CE8E70A3
```

build 323

## ENABLE_EXTERIOR_CULL_MODEL_THIS_FRAME

```c
void ENABLE_EXTERIOR_CULL_MODEL_THIS_FRAME(Hash mapObjectHash)  // 0xA97F257D0151A6AB
```

build 323 · old names: `_HIDE_MAP_OBJECT_THIS_FRAME`

> This is the native that is used to hide the exterior of GTA Online apartment buildings when you are inside an apartment.
> 
> More info: https://gtaforums.com/topic/836301-hiding-gta-online-apartment-exteriors/

## ENABLE_SHADOW_CULL_MODEL_THIS_FRAME

```c
void ENABLE_SHADOW_CULL_MODEL_THIS_FRAME(Hash mapObjectHash)  // 0x50C375537449F369
```

build 757 · old names: `_ENABLE_SCRIPT_CULL_MODEL_THIS_FRAME`

## ENABLE_STADIUM_PROBES_THIS_FRAME

```c
void ENABLE_STADIUM_PROBES_THIS_FRAME(BOOL toggle)  // 0x7ECDF98587E92DEC
```

build 1604

## FORCE_ACTIVATING_TRACKING_ON_ENTITY

```c
void FORCE_ACTIVATING_TRACKING_ON_ENTITY(Any p0, Any p1)  // 0x38C1CB1CB119A016
```

build 1493

## FORCE_ROOM_FOR_ENTITY

```c
void FORCE_ROOM_FOR_ENTITY(Entity entity, Interior interior, Hash roomHashKey)  // 0x52923C4710DD9907
```

build 323

## FORCE_ROOM_FOR_GAME_VIEWPORT

```c
void FORCE_ROOM_FOR_GAME_VIEWPORT(int interiorID, Hash roomHashKey)  // 0x920D853F3E17F1DA
```

build 323

## GET_INTERIOR_AT_COORDS

```c
Interior GET_INTERIOR_AT_COORDS(float x, float y, float z)  // 0xB0F7F8663821D9C3
```

build 323

> Returns interior ID from specified coordinates. If coordinates are outside, then it returns 0.
> 
> Example for VB.NET
> Dim interiorID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, X, Y, Z)

## GET_INTERIOR_AT_COORDS_WITH_TYPE

```c
Interior GET_INTERIOR_AT_COORDS_WITH_TYPE(float x, float y, float z, const char* interiorType)  // 0x05B7A89BD78797FC
```

build 323

> Returns the interior ID representing the requested interior at that location (if found?). The supplied interior string is not the same as the one used to load the interior.
> 
> Use: INTERIOR::UNPIN_INTERIOR(INTERIOR::GET_INTERIOR_AT_COORDS_WITH_TYPE(x, y, z, interior))
> 
> Interior types include: "V_Michael", "V_Franklins", "V_Franklinshouse", etc.. you can find them in the scripts.
> 
> Not a very useful native as you could just use GET_INTERIOR_AT_COORDS instead and get the same result, without even having to specify the interior type.

## GET_INTERIOR_AT_COORDS_WITH_TYPEHASH

```c
Interior GET_INTERIOR_AT_COORDS_WITH_TYPEHASH(float x, float y, float z, Hash typeHash)  // 0xF0F77ADB9F67E79D
```

build 323 · old names: `_UNK_GET_INTERIOR_AT_COORDS`

> Hashed version of GET_INTERIOR_AT_COORDS_WITH_TYPE

## GET_INTERIOR_FROM_COLLISION

```c
Interior GET_INTERIOR_FROM_COLLISION(float x, float y, float z)  // 0xEC4CF9FCB29A4424
```

build 323

## GET_INTERIOR_FROM_ENTITY

```c
Interior GET_INTERIOR_FROM_ENTITY(Entity entity)  // 0x2107BA504071A6BB
```

build 323

> Returns the handle of the interior that the entity is in. Returns 0 if outside.

## GET_INTERIOR_FROM_PRIMARY_VIEW

```c
Interior GET_INTERIOR_FROM_PRIMARY_VIEW()  // 0xE7D267EC6CA966C3
```

build 1604 · old names: `_GET_INTERIOR_FROM_GAMEPLAY_CAM`

> Returns the current interior id from gameplay camera

## GET_INTERIOR_GROUP_ID

```c
int GET_INTERIOR_GROUP_ID(Interior interior)  // 0xE4A84ABF135EF91A
```

build 323

> Returns the group ID of the specified interior.
> 0 = default
> 1 = subway station, subway tracks, sewers
> 3 = train tunnel under mirror park
> 5 = tunnel near del perro
> 6 = train tunnel near chilliad
> 7 = train tunnel near josiah
> 8 = train tunnel in sandy shores
> 9 = braddock tunnel (near chilliad)
> 12 = tunnel under fort zancudo
> 14 = train tunnel under cypress flats
> 18 = rockford plaza parking garage
> 19 = arcadius parking garage
> 20 = union depository parking garage
> 21 = fib parking garage

## GET_INTERIOR_HEADING

```c
float GET_INTERIOR_HEADING(Interior interior)  // 0xF49B58631D9E22D9
```

build 1493 · old names: `_GET_INTERIOR_HEADING`

## GET_INTERIOR_LOCATION_AND_NAMEHASH

```c
void GET_INTERIOR_LOCATION_AND_NAMEHASH(Interior interior, Vector3* position, Hash* nameHash)  // 0x252BDC06B73FA6EA
```

build 1290 · old names: `_GET_INTERIOR_INFO`

## GET_KEY_FOR_ENTITY_IN_ROOM

```c
Hash GET_KEY_FOR_ENTITY_IN_ROOM(Entity entity)  // 0x399685DB942336BC
```

build 323

> Seems to do the exact same as INTERIOR::GET_ROOM_KEY_FROM_ENTITY

## GET_OFFSET_FROM_INTERIOR_IN_WORLD_COORDS

```c
Vector3 GET_OFFSET_FROM_INTERIOR_IN_WORLD_COORDS(Interior interior, float x, float y, float z)  // 0x9E3B3E6D66F6E22F
```

build 323

## GET_ROOM_KEY_FOR_GAME_VIEWPORT

```c
Hash GET_ROOM_KEY_FOR_GAME_VIEWPORT()  // 0xA6575914D2A0B450
```

build 323 · old names: `_GET_ROOM_KEY_FROM_GAMEPLAY_CAM`

## GET_ROOM_KEY_FROM_ENTITY

```c
Hash GET_ROOM_KEY_FROM_ENTITY(Entity entity)  // 0x47C2A06D4F5F424B
```

build 323

> Gets the room hash key from the room that the specified entity is in. Each room in every interior has a unique key. Returns 0 if the entity is outside.

## IS_COLLISION_MARKED_OUTSIDE

```c
BOOL IS_COLLISION_MARKED_OUTSIDE(float x, float y, float z)  // 0xEEA5AC2EDA7C33E8
```

build 323 · old names: `_ARE_COORDS_COLLIDING_WITH_EXTERIOR`

> Returns true if the collision at the specified coords is marked as being outside (false if there's an interior)

## IS_INTERIOR_CAPPED

```c
BOOL IS_INTERIOR_CAPPED(Interior interior)  // 0x92BAC8ACF88CEC26
```

build 323

## IS_INTERIOR_DISABLED

```c
BOOL IS_INTERIOR_DISABLED(Interior interior)  // 0xBC5115A5A939DD15
```

build 323

## IS_INTERIOR_ENTITY_SET_ACTIVE

```c
BOOL IS_INTERIOR_ENTITY_SET_ACTIVE(Interior interior, const char* entitySetName)  // 0x35F7DD45E8C0A16D
```

build 323 · old names: `_IS_INTERIOR_PROP_ENABLED`

> Full list of IPLs and interior entity sets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ipls.json

## IS_INTERIOR_READY

```c
BOOL IS_INTERIOR_READY(Interior interior)  // 0x6726BDCCC1932F0E
```

build 323

## IS_INTERIOR_SCENE

```c
BOOL IS_INTERIOR_SCENE()  // 0xBC72B5D7A1CBD54D
```

build 323

## IS_VALID_INTERIOR

```c
BOOL IS_VALID_INTERIOR(Interior interior)  // 0x26B0E73D7EAAF4D3
```

build 323

## PIN_INTERIOR_IN_MEMORY

```c
void PIN_INTERIOR_IN_MEMORY(Interior interior)  // 0x2CA429C029CCF247
```

build 323 · old names: `_LOAD_INTERIOR`

## REFRESH_INTERIOR

```c
void REFRESH_INTERIOR(Interior interior)  // 0x41F37C3427C75AE0
```

build 323

## RETAIN_ENTITY_IN_INTERIOR

```c
void RETAIN_ENTITY_IN_INTERIOR(Entity entity, Interior interior)  // 0x82EBB79E258FA2B7
```

build 323

## SET_INTERIOR_ENTITY_SET_TINT_INDEX

```c
void SET_INTERIOR_ENTITY_SET_TINT_INDEX(Interior interior, const char* entitySetName, int color)  // 0xC1F1920BAF281317
```

build 877 · old names: `_SET_INTERIOR_PROP_COLOR`, `_SET_INTERIOR_ENTITY_SET_COLOR`

> Full list of IPLs and interior entity sets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ipls.json

## SET_INTERIOR_IN_USE

```c
BOOL SET_INTERIOR_IN_USE(Interior interior)  // 0x4C2330E61D3DEB56
```

build 323

> Only used once in the entire game scripts.
> Does not actually return anything.

## SET_IS_EXTERIOR_ONLY

```c
void SET_IS_EXTERIOR_ONLY(Entity entity, BOOL toggle)  // 0x7241CCB7D020DB69
```

build 791

> Jenkins hash _might_ be 0xFC227584.

## SET_ROOM_FOR_GAME_VIEWPORT_BY_KEY

```c
void SET_ROOM_FOR_GAME_VIEWPORT_BY_KEY(Hash roomHashKey)  // 0x405DC2AEF6AF95B9
```

build 323

> Usage: INTERIOR::SET_ROOM_FOR_GAME_VIEWPORT_BY_KEY(INTERIOR::GET_KEY_FOR_ENTITY_IN_ROOM(PLAYER::PLAYER_PED_ID()));

## SET_ROOM_FOR_GAME_VIEWPORT_BY_NAME

```c
void SET_ROOM_FOR_GAME_VIEWPORT_BY_NAME(const char* roomName)  // 0xAF348AFCB575A441
```

build 323

> Example of use (carmod_shop)
> INTERIOR::SET_ROOM_FOR_GAME_VIEWPORT_BY_NAME("V_CarModRoom");

## UNPIN_INTERIOR

```c
void UNPIN_INTERIOR(Interior interior)  // 0x261CCE7EED010641
```

build 323

> Does something similar to INTERIOR::DISABLE_INTERIOR.
> 
> You don't fall through the floor but everything is invisible inside and looks the same as when INTERIOR::DISABLE_INTERIOR is used. Peds behaves normally inside. 

