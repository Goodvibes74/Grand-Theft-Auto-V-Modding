# SHAPETEST natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## GET_SHAPE_TEST_RESULT

```c
int GET_SHAPE_TEST_RESULT(int shapeTestHandle, BOOL* hit, Vector3* endCoords, Vector3* surfaceNormal, Entity* entityHit)  // 0x3D87450E15D98694
```

build 323 · old names: `_GET_RAYCAST_RESULT`

> Returns the result of a shape test: 0 if the handle is invalid, 1 if the shape test is still pending, or 2 if the shape test has completed, and the handle should be invalidated.
> 
> When used with an asynchronous shape test, this native should be looped until returning 0 or 2, after which the handle is invalidated.

## GET_SHAPE_TEST_RESULT_INCLUDING_MATERIAL

```c
int GET_SHAPE_TEST_RESULT_INCLUDING_MATERIAL(int shapeTestHandle, BOOL* hit, Vector3* endCoords, Vector3* surfaceNormal, Hash* materialHash, Entity* entityHit)  // 0x65287525D951F6BE
```

build 323 · old names: `_GET_SHAPE_TEST_RESULT_EX`

> Returns the result of a shape test, also returning the material of any touched surface.
> 
> When used with an asynchronous shape test, this native should be looped until returning 0 or 2, after which the handle is invalidated.
> 
> Unless the return value is 2, the other return values are undefined.

## RELEASE_SCRIPT_GUID_FROM_ENTITY

```c
void RELEASE_SCRIPT_GUID_FROM_ENTITY(Entity entityHit)  // 0x2B3334BCA57CD799
```

build 323 · old names: `_SHAPE_TEST_RESULT_ENTITY`

> Invalidates the entity handle passed by removing the fwScriptGuid from the entity. This should be used when receiving an ambient entity from shape testing natives, but can also be used for other natives returning an 'irrelevant' entity handle.

## START_EXPENSIVE_SYNCHRONOUS_SHAPE_TEST_LOS_PROBE

```c
int START_EXPENSIVE_SYNCHRONOUS_SHAPE_TEST_LOS_PROBE(float x1, float y1, float z1, float x2, float y2, float z2, int flags, Entity entity, int p8)  // 0x377906D8A31E5586
```

build 323 · old names: `_CAST_RAY_POINT_TO_POINT`, `_START_SHAPE_TEST_RAY`

> Does the same as START_SHAPE_TEST_LOS_PROBE, except blocking until the shape test completes.

## START_SHAPE_TEST_BOUND

```c
int START_SHAPE_TEST_BOUND(Entity entity, int flags1, int flags2)  // 0x37181417CE7C8900
```

build 323

## START_SHAPE_TEST_BOUNDING_BOX

```c
int START_SHAPE_TEST_BOUNDING_BOX(Entity entity, int flags1, int flags2)  // 0x052837721A854EC7
```

build 323

## START_SHAPE_TEST_BOX

```c
int START_SHAPE_TEST_BOX(float x, float y, float z, float dimX, float dimY, float dimZ, float rotX, float rotY, float rotZ, Any p9, int flags, Entity entity, Any p12)  // 0xFE466162C4401D18
```

build 323

## START_SHAPE_TEST_CAPSULE

```c
int START_SHAPE_TEST_CAPSULE(float x1, float y1, float z1, float x2, float y2, float z2, float radius, int flags, Entity entity, int p9)  // 0x28579D1B8F8AAC80
```

build 323 · old names: `_CAST_3D_RAY_POINT_TO_POINT`

> Raycast from point to point, where the ray has a radius. 
> 
> flags:
> vehicles=10
> peds =12
> 
> Iterating through flags yields many ped / vehicle/ object combinations
> 
> p9 = 7, but no idea what it does
> 
> Entity is an entity to ignore

## START_SHAPE_TEST_LOS_PROBE

```c
int START_SHAPE_TEST_LOS_PROBE(float x1, float y1, float z1, float x2, float y2, float z2, int flags, Entity entity, int p8)  // 0x7EE9F5D83DD4F90E
```

build 323

> Asynchronously starts a line-of-sight (raycast) world probe shape test.
> 
> Use the handle with GET_SHAPE_TEST_RESULT or GET_SHAPE_TEST_RESULT_INCLUDING_MATERIAL until it returns 0 or 2.
> 
> p8 is a bit mask with bits 1, 2 and/or 4, relating to collider types; 4 should usually be used.

## START_SHAPE_TEST_MOUSE_CURSOR_LOS_PROBE

```c
int START_SHAPE_TEST_MOUSE_CURSOR_LOS_PROBE(Vector3* pVec1, Vector3* pVec2, int flag, Entity entity, int flag2)  // 0xFF6BE494C7987F34
```

build 323 · old names: `_START_SHAPE_TEST_SURROUNDING_COORDS`

> Returns a ShapeTest handle that can be used with GET_SHAPE_TEST_RESULT.
> 
> In its only usage in game scripts its called with flag set to 511, entity to player_ped_id and flag2 set to 7

## START_SHAPE_TEST_SWEPT_SPHERE

```c
int START_SHAPE_TEST_SWEPT_SPHERE(float x1, float y1, float z1, float x2, float y2, float z2, float radius, int flags, Entity entity, Any p9)  // 0xE6AC6C45FBE83004
```

build 323 · old names: `_START_SHAPE_TEST_CAPSULE_2`

