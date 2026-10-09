# BRAIN natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ADD_SCRIPT_TO_RANDOM_PED

```c
void ADD_SCRIPT_TO_RANDOM_PED(const char* name, Hash model, float p2, float p3)  // 0x4EE5367468A65CCC
```

build 323

> BRAIN::ADD_SCRIPT_TO_RANDOM_PED("pb_prostitute", ${s_f_y_hooker_01}, 100, 0);
> 
> - Nacorpio
> 
> -----
> 
> Hardcoded to not work in Multiplayer.

## DISABLE_SCRIPT_BRAIN_SET

```c
void DISABLE_SCRIPT_BRAIN_SET(int brainSet)  // 0x14D8518E9760F08F
```

build 323

## ENABLE_SCRIPT_BRAIN_SET

```c
void ENABLE_SCRIPT_BRAIN_SET(int brainSet)  // 0x67AA4D73F0CFA86B
```

build 323

## IS_OBJECT_WITHIN_BRAIN_ACTIVATION_RANGE

```c
BOOL IS_OBJECT_WITHIN_BRAIN_ACTIVATION_RANGE(Object object)  // 0xCCBA154209823057
```

build 323

## IS_WORLD_POINT_WITHIN_BRAIN_ACTIVATION_RANGE

```c
BOOL IS_WORLD_POINT_WITHIN_BRAIN_ACTIVATION_RANGE()  // 0xC5042CC6F5E3D450
```

build 323

> Gets whether the world point the calling script is registered to is within desired range of the player.

## REACTIVATE_ALL_OBJECT_BRAINS_THAT_ARE_WAITING_TILL_OUT_OF_RANGE

```c
void REACTIVATE_ALL_OBJECT_BRAINS_THAT_ARE_WAITING_TILL_OUT_OF_RANGE()  // 0x4D953DF78EBF8158
```

build 323 · old names: `_PREPARE_SCRIPT_BRAIN`

## REACTIVATE_ALL_WORLD_BRAINS_THAT_ARE_WAITING_TILL_OUT_OF_RANGE

```c
void REACTIVATE_ALL_WORLD_BRAINS_THAT_ARE_WAITING_TILL_OUT_OF_RANGE()  // 0x0B40ED49D7D6FF84
```

build 323

## REACTIVATE_NAMED_OBJECT_BRAINS_WAITING_TILL_OUT_OF_RANGE

```c
void REACTIVATE_NAMED_OBJECT_BRAINS_WAITING_TILL_OUT_OF_RANGE(const char* scriptName)  // 0x6E91B04E08773030
```

build 323

> Here are possible values of argument - 
> 
> "ob_tv"
> "launcher_Darts"

## REACTIVATE_NAMED_WORLD_BRAINS_WAITING_TILL_OUT_OF_RANGE

```c
void REACTIVATE_NAMED_WORLD_BRAINS_WAITING_TILL_OUT_OF_RANGE(const char* scriptName)  // 0x6D6840CEE8845831
```

build 323

> Possible values:
> 
> act_cinema
> am_mp_carwash_launch
> am_mp_carwash_control
> am_mp_property_ext
> chop
> fairgroundHub
> launcher_BasejumpHeli
> launcher_BasejumpPack
> launcher_CarWash
> launcher_golf
> launcher_Hunting_Ambient
> launcher_MrsPhilips
> launcher_OffroadRacing
> launcher_pilotschool
> launcher_Racing
> launcher_rampage
> launcher_rampage
> launcher_range
> launcher_stunts
> launcher_stunts
> launcher_tennis
> launcher_Tonya
> launcher_Triathlon
> launcher_Yoga
> ob_mp_bed_low
> ob_mp_bed_med

## REGISTER_OBJECT_SCRIPT_BRAIN

```c
void REGISTER_OBJECT_SCRIPT_BRAIN(const char* scriptName, Hash modelHash, int p2, float activationRange, int p4, int p5)  // 0x0BE84C318BA6EC22
```

build 323

> Registers a script for any object with a specific model hash.
> 
> BRAIN::REGISTER_OBJECT_SCRIPT_BRAIN("ob_telescope", ${prop_telescope_01}, 100, 4.0, -1, 9);
> 
> - Nacorpio

## REGISTER_WORLD_POINT_SCRIPT_BRAIN

```c
void REGISTER_WORLD_POINT_SCRIPT_BRAIN(const char* scriptName, float activationRange, int p2)  // 0x3CDC7136613284BD
```

build 323

