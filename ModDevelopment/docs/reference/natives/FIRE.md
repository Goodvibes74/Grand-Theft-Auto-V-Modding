# FIRE natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _GET_MAXIMUM_NUMBER_OF_WATER_CANNONS

```c
int _GET_MAXIMUM_NUMBER_OF_WATER_CANNONS()  // 0x56581E7E219D6263
```

build 3717

## _GET_WATER_CANNON_COORDS

```c
Vector3 _GET_WATER_CANNON_COORDS(int index)  // 0xE61CBD3ED80E7327
```

build 3717

## _NETWORK_EXPECT_EXPLOSION_EVENTS_FOR_PLAYER

```c
void _NETWORK_EXPECT_EXPLOSION_EVENTS_FOR_PLAYER(BOOL expect, Player player)  // 0x5241DB47A8B8AD54
```

build 3570

## ADD_EXPLOSION

```c
void ADD_EXPLOSION(float x, float y, float z, int explosionType, float damageScale, BOOL isAudible, BOOL isInvisible, float cameraShake, BOOL noDamage)  // 0xE3AD2BDBAEE269AC
```

build 323

> BOOL isAudible = If explosion makes a sound.
> BOOL isInvisible = If the explosion is invisible or not.
> 
> explosionType: https://alloc8or.re/gta5/doc/enums/eExplosionTag.txt

## ADD_EXPLOSION_WITH_USER_VFX

```c
void ADD_EXPLOSION_WITH_USER_VFX(float x, float y, float z, int explosionType, Hash explosionFx, float damageScale, BOOL isAudible, BOOL isInvisible, float cameraShake)  // 0x36DD3FE58B5E5212
```

build 323 · old names: `_ADD_SPECFX_EXPLOSION`

> isAudible: If explosion makes a sound.
> isInvisible: If the explosion is invisible or not.
> explosionType: See ADD_EXPLOSION.

## ADD_OWNED_EXPLOSION

```c
void ADD_OWNED_EXPLOSION(Ped ped, float x, float y, float z, int explosionType, float damageScale, BOOL isAudible, BOOL isInvisible, float cameraShake)  // 0x172AA1B624FA1013
```

build 323

> isAudible: If explosion makes a sound.
> isInvisible: If the explosion is invisible or not.
> explosionType: See ADD_EXPLOSION.

## GET_CLOSEST_FIRE_POS

```c
BOOL GET_CLOSEST_FIRE_POS(Vector3* outPosition, float x, float y, float z)  // 0x352A9F6BCF90081F
```

build 323

> Returns TRUE if it found something. FALSE if not.

## GET_NUMBER_OF_FIRES_IN_RANGE

```c
int GET_NUMBER_OF_FIRES_IN_RANGE(float x, float y, float z, float radius)  // 0x50CAD495A460B305
```

build 323

## GET_OWNER_OF_EXPLOSION_IN_ANGLED_AREA

```c
Entity GET_OWNER_OF_EXPLOSION_IN_ANGLED_AREA(int explosionType, float x1, float y1, float z1, float x2, float y2, float z2, float radius)  // 0x14BA4BA137AF6CEC
```

build 323 · old names: `_GET_PED_INSIDE_EXPLOSION_AREA`, `_GET_ENTITY_INSIDE_EXPLOSION_AREA`

> Returns a handle to the first entity within the a circle spawned inside the 2 points from a radius.
> 
> explosionType: See ADD_EXPLOSION.

## GET_OWNER_OF_EXPLOSION_IN_SPHERE

```c
Entity GET_OWNER_OF_EXPLOSION_IN_SPHERE(int explosionType, float x, float y, float z, float radius)  // 0xB3CD51E3DB86F176
```

build 1290 · old names: `_GET_ENTITY_INSIDE_EXPLOSION_SPHERE`

> explosionType: See ADD_EXPLOSION.

## IS_ENTITY_ON_FIRE

```c
BOOL IS_ENTITY_ON_FIRE(Entity entity)  // 0x28D3FED7190D3A0B
```

build 323

## IS_EXPLOSION_ACTIVE_IN_AREA

```c
BOOL IS_EXPLOSION_ACTIVE_IN_AREA(int explosionType, float x1, float y1, float z1, float x2, float y2, float z2)  // 0x6070104B699B2EF4
```

build 323

> explosionType: See ADD_EXPLOSION.

## IS_EXPLOSION_IN_ANGLED_AREA

```c
BOOL IS_EXPLOSION_IN_ANGLED_AREA(int explosionType, float x1, float y1, float z1, float x2, float y2, float z2, float width)  // 0xA079A6C51525DC4B
```

build 323

> explosionType: See ADD_EXPLOSION, -1 for any explosion type
> 

## IS_EXPLOSION_IN_AREA

```c
BOOL IS_EXPLOSION_IN_AREA(int explosionType, float x1, float y1, float z1, float x2, float y2, float z2)  // 0x2E2EBA0EE7CED0E0
```

build 323

> explosionType: See ADD_EXPLOSION.

## IS_EXPLOSION_IN_SPHERE

```c
BOOL IS_EXPLOSION_IN_SPHERE(int explosionType, float x, float y, float z, float radius)  // 0xAB0F816885B0E483
```

build 323

> explosionType: See ADD_EXPLOSION.

## REMOVE_SCRIPT_FIRE

```c
void REMOVE_SCRIPT_FIRE(FireId fireHandle)  // 0x7FF548385680673F
```

build 323

## SET_FLAMMABILITY_MULTIPLIER

```c
void SET_FLAMMABILITY_MULTIPLIER(float p0)  // 0x8F390AC4155099BA
```

build 1734 · old names: `_SET_FIRE_SPREAD_RATE`

## START_ENTITY_FIRE

```c
FireId START_ENTITY_FIRE(Entity entity)  // 0xF6A9D9708F6F23DF
```

build 323

## START_SCRIPT_FIRE

```c
FireId START_SCRIPT_FIRE(float X, float Y, float Z, int maxChildren, BOOL isGasFire)  // 0x6B83617E04503888
```

build 323

> Starts a fire:
> 
> xyz: Location of fire
> maxChildren: The max amount of times a fire can spread to other objects. Must be 25 or less, or the function will do nothing.
> isGasFire: Whether or not the fire is powered by gasoline.

## STOP_ENTITY_FIRE

```c
void STOP_ENTITY_FIRE(Entity entity)  // 0x7F0DD2EBBB651AFF
```

build 323

## STOP_FIRE_IN_RANGE

```c
void STOP_FIRE_IN_RANGE(float x, float y, float z, float radius)  // 0x056A8A219B8E829F
```

build 323

