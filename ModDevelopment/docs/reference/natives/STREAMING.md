# STREAMING natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _GET_TOTAL_MODEL_COST

```c
float _GET_TOTAL_MODEL_COST(Hash modelHash)  // 0x4A91423C04BAADA1
```

build 3717

## _SET_SPHERICAL_STREAM_DISTANT_HILODS_THIS_FRAME

```c
void _SET_SPHERICAL_STREAM_DISTANT_HILODS_THIS_FRAME()  // 0x68F1C25420D5F6AA
```

build 3717

## ADD_MODEL_TO_CREATOR_BUDGET

```c
BOOL ADD_MODEL_TO_CREATOR_BUDGET(Hash modelHash)  // 0x0BC3144DEB678666
```

build 323

## ALLOW_PLAYER_SWITCH_ASCENT

```c
void ALLOW_PLAYER_SWITCH_ASCENT()  // 0x8E2A065ABDAE6994
```

build 323

## ALLOW_PLAYER_SWITCH_DESCENT

```c
void ALLOW_PLAYER_SWITCH_DESCENT()  // 0xAD5FDF34B81BFE79
```

build 323

## ALLOW_PLAYER_SWITCH_OUTRO

```c
void ALLOW_PLAYER_SWITCH_OUTRO()  // 0x74DE2E8739086740
```

build 323

## ALLOW_PLAYER_SWITCH_PAN

```c
void ALLOW_PLAYER_SWITCH_PAN()  // 0x43D1680C6D19A8E9
```

build 323

## BEGIN_SRL

```c
void BEGIN_SRL()  // 0x9BADDC94EF83B823
```

build 323

## CLEAR_FOCUS

```c
void CLEAR_FOCUS()  // 0x31B73D1EA9F01DA2
```

build 323

## CLEAR_HD_AREA

```c
void CLEAR_HD_AREA()  // 0xCE58B1CFB9290813
```

build 323

## DISABLE_SWITCH_OUTRO_FX

```c
void DISABLE_SWITCH_OUTRO_FX()  // 0xBD605B8E0E18B3BB
```

build 323

## DOES_ANIM_DICT_EXIST

```c
BOOL DOES_ANIM_DICT_EXIST(const char* animDict)  // 0x2DA49C3B79856961
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## ENABLE_SWITCH_PAUSE_BEFORE_DESCENT

```c
void ENABLE_SWITCH_PAUSE_BEFORE_DESCENT()  // 0xD4793DFF3AF2ABCD
```

build 323

## END_SRL

```c
void END_SRL()  // 0x0A41540E63C9EE17
```

build 323

> Clear the current srl and stop rendering the area selected by PREFETCH_SRL and started with BEGIN_SRL.

## FORCE_ALLOW_TIME_BASED_FADING_THIS_FRAME

```c
void FORCE_ALLOW_TIME_BASED_FADING_THIS_FRAME()  // 0x03F1A106BDA7DD3E
```

build 323

## GET_GLOBAL_WATER_FILE

```c
int GET_GLOBAL_WATER_FILE()  // 0xF741BD853611592D
```

build 2189 · old names: `_GET_GLOBAL_WATER_TYPE`

## GET_IDEAL_PLAYER_SWITCH_TYPE

```c
int GET_IDEAL_PLAYER_SWITCH_TYPE(float x1, float y1, float z1, float x2, float y2, float z2)  // 0xB5D7B26B45720E05
```

build 323

> x1, y1, z1 -- Coords of your ped model
> x2, y2, z2 -- Coords of the ped you want to switch to

## GET_LODSCALE

```c
float GET_LODSCALE()  // 0x0C15B0E443B2349D
```

build 323

## GET_NUMBER_OF_STREAMING_REQUESTS

```c
int GET_NUMBER_OF_STREAMING_REQUESTS()  // 0x4060057271CEBC89
```

build 323

## GET_PLAYER_SHORT_SWITCH_STATE

```c
int GET_PLAYER_SHORT_SWITCH_STATE()  // 0x20F898A5D9782800
```

build 323

## GET_PLAYER_SWITCH_INTERP_OUT_CURRENT_TIME

```c
int GET_PLAYER_SWITCH_INTERP_OUT_CURRENT_TIME()  // 0x5B48A06DD0E792A5
```

build 323

## GET_PLAYER_SWITCH_INTERP_OUT_DURATION

```c
int GET_PLAYER_SWITCH_INTERP_OUT_DURATION()  // 0x08C2D6C52A3104BB
```

build 323 · old names: `SET_PLAYER_INVERTED_UP`

## GET_PLAYER_SWITCH_JUMP_CUT_INDEX

```c
int GET_PLAYER_SWITCH_JUMP_CUT_INDEX()  // 0x78C0D93253149435
```

build 323

## GET_PLAYER_SWITCH_STATE

```c
int GET_PLAYER_SWITCH_STATE()  // 0x470555300D10B2A5
```

build 323

## GET_PLAYER_SWITCH_TYPE

```c
int GET_PLAYER_SWITCH_TYPE()  // 0xB3C94A90D9FC9E62
```

build 323

## GET_USED_CREATOR_BUDGET

```c
float GET_USED_CREATOR_BUDGET()  // 0x3D3D8B3BE5A83D35
```

build 323 · old names: `_GET_USED_CREATOR_MODEL_MEMORY_PERCENTAGE`

> 0.0 = no memory used
> 1.0 = all memory used
> 
> Maximum model memory (as defined in common\data\missioncreatordata.meta) is 100 MiB

## HAS_ANIM_DICT_LOADED

```c
BOOL HAS_ANIM_DICT_LOADED(const char* animDict)  // 0xD031A9162D01088C
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## HAS_ANIM_SET_LOADED

```c
BOOL HAS_ANIM_SET_LOADED(const char* animSet)  // 0xC4EA073D86FB29B0
```

build 323

> Gets whether the specified animation set has finished loading. An animation set provides movement animations for a ped. See SET_PED_MOVEMENT_CLIPSET.
> 
> Animation set and clip set are synonymous.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## HAS_CLIP_SET_LOADED

```c
BOOL HAS_CLIP_SET_LOADED(const char* clipSet)  // 0x318234F4F3738AF3
```

build 323

> Alias for HAS_ANIM_SET_LOADED.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## HAS_COLLISION_FOR_MODEL_LOADED

```c
BOOL HAS_COLLISION_FOR_MODEL_LOADED(Hash model)  // 0x22CCA434E368F03A
```

build 323

## HAS_MODEL_LOADED

```c
BOOL HAS_MODEL_LOADED(Hash model)  // 0x98A4EB5D89A0C952
```

build 323

> Checks if the specified model has loaded into memory.

## HAS_NAMED_PTFX_ASSET_LOADED

```c
BOOL HAS_NAMED_PTFX_ASSET_LOADED(const char* fxName)  // 0x8702416E512EC454
```

build 323

## HAS_PTFX_ASSET_LOADED

```c
BOOL HAS_PTFX_ASSET_LOADED()  // 0xCA7D9B86ECA7481B
```

build 323

## INIT_CREATOR_BUDGET

```c
void INIT_CREATOR_BUDGET()  // 0xB5A4DB34FE89B88A
```

build 323 · old names: `_LOAD_MISSION_CREATOR_DATA`

## IPL_GROUP_SWAP_CANCEL

```c
void IPL_GROUP_SWAP_CANCEL()  // 0x63EB2B972A218CAC
```

build 323

## IPL_GROUP_SWAP_FINISH

```c
void IPL_GROUP_SWAP_FINISH()  // 0xF4A0DADB70F57FA6
```

build 323

## IPL_GROUP_SWAP_IS_ACTIVE

```c
BOOL IPL_GROUP_SWAP_IS_ACTIVE()  // 0x5068F488DDB54DD8
```

build 323

## IPL_GROUP_SWAP_IS_READY

```c
BOOL IPL_GROUP_SWAP_IS_READY()  // 0xFB199266061F820A
```

build 323

## IPL_GROUP_SWAP_START

```c
void IPL_GROUP_SWAP_START(const char* iplName1, const char* iplName2)  // 0x95A7DABDDBB78AE7
```

build 323

## IS_ENTITY_FOCUS

```c
BOOL IS_ENTITY_FOCUS(Entity entity)  // 0x2DDFF3FB9075D747
```

build 323

## IS_IPL_ACTIVE

```c
BOOL IS_IPL_ACTIVE(const char* iplName)  // 0x88A741E44A2B3495
```

build 323

> Full list of IPLs and interior entity sets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ipls.json

## IS_MODEL_A_PED

```c
BOOL IS_MODEL_A_PED(Hash model)  // 0x75816577FEA6DAD5
```

build 1103

## IS_MODEL_A_VEHICLE

```c
BOOL IS_MODEL_A_VEHICLE(Hash model)  // 0x19AAC8F07BFEC53E
```

build 323

> Returns whether the specified model represents a vehicle.

## IS_MODEL_IN_CDIMAGE

```c
BOOL IS_MODEL_IN_CDIMAGE(Hash model)  // 0x35B9E0803292B641
```

build 323

> Check if model is in cdimage(rpf)

## IS_MODEL_VALID

```c
BOOL IS_MODEL_VALID(Hash model)  // 0xC0296A2EDF545E92
```

build 323

> Returns whether the specified model exists in the game.

## IS_NETWORK_LOADING_SCENE

```c
BOOL IS_NETWORK_LOADING_SCENE()  // 0x41CA5A33160EA4AB
```

build 323

## IS_NEW_LOAD_SCENE_ACTIVE

```c
BOOL IS_NEW_LOAD_SCENE_ACTIVE()  // 0xA41A05B6CB741B85
```

build 323

## IS_NEW_LOAD_SCENE_LOADED

```c
BOOL IS_NEW_LOAD_SCENE_LOADED()  // 0x01B8247A7A8B9AD1
```

build 323

## IS_PLAYER_SWITCH_IN_PROGRESS

```c
BOOL IS_PLAYER_SWITCH_IN_PROGRESS()  // 0xD9D2CFFF49FAB35F
```

build 323

> Returns true if the player is currently switching, false otherwise.
> (When the camera is in the sky moving from Trevor to Franklin for example)

## IS_SAFE_TO_START_PLAYER_SWITCH

```c
BOOL IS_SAFE_TO_START_PLAYER_SWITCH()  // 0x71E7B2E657449AAD
```

build 323

## IS_SRL_LOADED

```c
BOOL IS_SRL_LOADED()  // 0xD0263801A4C5B0BB
```

build 323

> Returns true when the srl from BEGIN_SRL is loaded.

## IS_STREAMVOL_ACTIVE

```c
BOOL IS_STREAMVOL_ACTIVE()  // 0xBC9823AB80A3DCAC
```

build 323

## IS_SWITCH_READY_FOR_DESCENT

```c
BOOL IS_SWITCH_READY_FOR_DESCENT()  // 0xDFA80CB25D0A19B3
```

build 323

## IS_SWITCH_SKIPPING_DESCENT

```c
BOOL IS_SWITCH_SKIPPING_DESCENT()  // 0x5B74EA8CFD5E3E7E
```

build 323 · old names: `DESTROY_PLAYER_IN_PAUSE_MENU`

## IS_SWITCH_TO_MULTI_FIRSTPART_FINISHED

```c
BOOL IS_SWITCH_TO_MULTI_FIRSTPART_FINISHED()  // 0x933BBEEB8C61B5F4
```

build 323

## LOAD_ALL_OBJECTS_NOW

```c
void LOAD_ALL_OBJECTS_NOW()  // 0xBD6E84632DD4CB3F
```

build 323

## LOAD_GLOBAL_WATER_FILE

```c
void LOAD_GLOBAL_WATER_FILE(int waterType)  // 0x7E3F55ED251B76D3
```

build 2189 · old names: `_LOAD_GLOBAL_WATER_TYPE`

> 0 - default
> 1 - HeistIsland

## LOAD_SCENE

```c
void LOAD_SCENE(float x, float y, float z)  // 0x4448EB75B4904BDB
```

build 323

## NETWORK_UPDATE_LOAD_SCENE

```c
BOOL NETWORK_UPDATE_LOAD_SCENE()  // 0xC4582015556D1C46
```

build 323

## NEW_LOAD_SCENE_START

```c
BOOL NEW_LOAD_SCENE_START(float posX, float posY, float posZ, float offsetX, float offsetY, float offsetZ, float radius, int p7)  // 0x212A8D0D2BABFAC2
```

build 323

> `radius` value is usually between `3f` and `7000f` in original 1868 scripts.
> `p7` is 0, 1, 2, 3 or 4 used in decompiled scripts, 0 is by far the most common.
> Returns True if success, used only 7 times in decompiled scripts of 1868

## NEW_LOAD_SCENE_START_SPHERE

```c
BOOL NEW_LOAD_SCENE_START_SPHERE(float x, float y, float z, float radius, Any p4)  // 0xACCFB4ACF53551B0
```

build 323

## NEW_LOAD_SCENE_STOP

```c
void NEW_LOAD_SCENE_STOP()  // 0xC197616D221FF4A4
```

build 323

## OVERRIDE_LODSCALE_THIS_FRAME

```c
void OVERRIDE_LODSCALE_THIS_FRAME(float scaling)  // 0xA76359FC80B2438E
```

build 323

> This allows you to override "extended distance scaling" setting. Needs to be called each frame.
> Max scaling seems to be 200.0, normal is 1.0

## PREFETCH_SRL

```c
void PREFETCH_SRL(const char* srl)  // 0x3D245789CE12982C
```

build 323

> This native is used to attribute the SRL that BEGIN_SRL is going to load. This is usually used for 'in-game' cinematics (not cutscenes but camera stuff) instead of SET_FOCUS_POS_AND_VEL because it loads a specific area of the map which is pretty useful when the camera moves from distant areas.
> For instance, GTA:O opening cutscene.
> https://pastebin.com/2EeKVeLA : a list of SRL found in srllist.meta
> https://pastebin.com/zd9XYUWY here is the content of a SRL file opened with codewalker.

## REMAP_LODSCALE_RANGE_THIS_FRAME

```c
void REMAP_LODSCALE_RANGE_THIS_FRAME(float p0, float p1, float p2, float p3)  // 0xBED8CA5FF5E04113
```

build 323

## REMOVE_ANIM_DICT

```c
void REMOVE_ANIM_DICT(const char* animDict)  // 0xF66A602F829E2A06
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## REMOVE_ANIM_SET

```c
void REMOVE_ANIM_SET(const char* animSet)  // 0x16350528F93024B3
```

build 323

> Unloads the specified animation set. An animation set provides movement animations for a ped. See SET_PED_MOVEMENT_CLIPSET.
> 
> Animation set and clip set are synonymous.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## REMOVE_CLIP_SET

```c
void REMOVE_CLIP_SET(const char* clipSet)  // 0x01F73A131C18CD94
```

build 323

> Alias for REMOVE_ANIM_SET.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## REMOVE_IPL

```c
void REMOVE_IPL(const char* iplName)  // 0xEE6C5AD3ECE0A82D
```

build 323

> Removes an IPL from the map.
> 
> Full list of IPLs and interior entity sets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ipls.json
> 
> Example:
> C#:
> Function.Call(Hash.REMOVE_IPL, "trevorstrailertidy");
> 
> C++:
> STREAMING::REMOVE_IPL("trevorstrailertidy");
> 
> iplName = Name of IPL you want to remove.

## REMOVE_MODEL_FROM_CREATOR_BUDGET

```c
void REMOVE_MODEL_FROM_CREATOR_BUDGET(Hash modelHash)  // 0xF086AD9354FAC3A3
```

build 323

## REMOVE_NAMED_PTFX_ASSET

```c
void REMOVE_NAMED_PTFX_ASSET(const char* fxName)  // 0x5F61EBBE1A00F96D
```

build 323 · old names: `_REMOVE_NAMED_PTFX_ASSET`

## REMOVE_PTFX_ASSET

```c
void REMOVE_PTFX_ASSET()  // 0x88C6814073DD4A73
```

build 323

## REQUEST_ADDITIONAL_COLLISION_AT_COORD

```c
void REQUEST_ADDITIONAL_COLLISION_AT_COORD(float x, float y, float z)  // 0xC9156DC11411A9EA
```

build 323

> Alias of REQUEST_COLLISION_AT_COORD.

## REQUEST_ANIM_DICT

```c
void REQUEST_ANIM_DICT(const char* animDict)  // 0xD3BD40951412FEF6
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## REQUEST_ANIM_SET

```c
void REQUEST_ANIM_SET(const char* animSet)  // 0x6EA47DAE7FAD0EED
```

build 323

> Starts loading the specified animation set. An animation set provides movement animations for a ped. See SET_PED_MOVEMENT_CLIPSET.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## REQUEST_CLIP_SET

```c
void REQUEST_CLIP_SET(const char* clipSet)  // 0xD2A71E1A77418A49
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## REQUEST_COLLISION_AT_COORD

```c
void REQUEST_COLLISION_AT_COORD(float x, float y, float z)  // 0x07503F7948F491A7
```

build 323

## REQUEST_COLLISION_FOR_MODEL

```c
void REQUEST_COLLISION_FOR_MODEL(Hash model)  // 0x923CB32A3B874FCB
```

build 323

## REQUEST_IPL

```c
void REQUEST_IPL(const char* iplName)  // 0x41B4893843BBDB74
```

build 323

> Exemple: REQUEST_IPL("TrevorsTrailerTrash");
> 
> Full list of IPLs and interior entity sets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ipls.json

## REQUEST_MENU_PED_MODEL

```c
void REQUEST_MENU_PED_MODEL(Hash model)  // 0xA0261AEF7ACFC51E
```

build 323

## REQUEST_MODEL

```c
void REQUEST_MODEL(Hash model)  // 0x963D27A58DF860AC
```

build 323

> Request a model to be loaded into memory.
> 

## REQUEST_MODELS_IN_ROOM

```c
void REQUEST_MODELS_IN_ROOM(Interior interior, const char* roomName)  // 0x8A7A40100EDFEC58
```

build 323 · old names: `_REQUEST_INTERIOR_ROOM_BY_NAME`

> STREAMING::REQUEST_MODELS_IN_ROOM(l_13BC, "V_FIB01_cur_elev");
> STREAMING::REQUEST_MODELS_IN_ROOM(l_13BC, "limbo");
> STREAMING::REQUEST_MODELS_IN_ROOM(l_13BB, "V_Office_gnd_lifts");
> STREAMING::REQUEST_MODELS_IN_ROOM(l_13BB, "limbo");
> STREAMING::REQUEST_MODELS_IN_ROOM(l_13BC, "v_fib01_jan_elev");
> STREAMING::REQUEST_MODELS_IN_ROOM(l_13BC, "limbo");

## REQUEST_NAMED_PTFX_ASSET

```c
void REQUEST_NAMED_PTFX_ASSET(const char* fxName)  // 0xB80D8756B4668AB6
```

build 323

>  From the b678d decompiled scripts:
> 
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("core_snow");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("fm_mission_controler");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("proj_xmas_firework");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_apartment_mp");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_biolab_heist");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_indep_fireworks");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_indep_parachute");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_indep_wheelsmoke");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_mp_cig_plane");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_mp_creator");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_mp_tankbattle");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_ornate_heist");
>  STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_prison_break_heist_station");

## REQUEST_PTFX_ASSET

```c
void REQUEST_PTFX_ASSET()  // 0x944955FB2A3935C8
```

build 323

> maps script name (thread + 0xD0) by lookup via scriptfx.dat - does nothing when script name is empty

## SET_ALL_MAPDATA_CULLED

```c
void SET_ALL_MAPDATA_CULLED(Any p0)  // 0x4E52E752C76E7E7A
```

build 323

> This native does absolutely nothing, just a nullsub

## SET_DITCH_POLICE_MODELS

```c
void SET_DITCH_POLICE_MODELS(BOOL toggle)  // 0x42CBE54462D92634
```

build 323

> This is a NOP function. It does nothing at all.

## SET_FOCUS_ENTITY

```c
void SET_FOCUS_ENTITY(Entity entity)  // 0x198F77705FA0931D
```

build 323

> It seems to make the entity's coords mark the point from which LOD-distances are measured. In my testing, setting a vehicle as the focus entity and moving that vehicle more than 300 distance units away from the player will make the level of detail around the player go down drastically (shadows disappear, textures go extremely low res, etc). The player seems to be the default focus entity.

## SET_FOCUS_POS_AND_VEL

```c
void SET_FOCUS_POS_AND_VEL(float x, float y, float z, float offsetX, float offsetY, float offsetZ)  // 0xBB7454BAFF08FE25
```

build 323 · old names: `_SET_FOCUS_AREA`

> Override the area where the camera will render the terrain.
> p3, p4 and p5 are usually set to 0.0
> 

## SET_GAME_PAUSES_FOR_STREAMING

```c
void SET_GAME_PAUSES_FOR_STREAMING(BOOL toggle)  // 0x717CD6E6FAEBBEDC
```

build 323

## SET_HD_AREA

```c
void SET_HD_AREA(float x, float y, float z, float radius)  // 0xB85F26619073E775
```

build 323

## SET_INTERIOR_ACTIVE

```c
void SET_INTERIOR_ACTIVE(int interiorID, BOOL toggle)  // 0xE37B76C387BE28ED
```

build 323

## SET_ISLAND_ENABLED

```c
void SET_ISLAND_ENABLED(const char* name, BOOL toggle)  // 0x9A9D1BA639675CF1
```

build 2189 · old names: `_SET_ISLAND_HOPPER_ENABLED`

> Enables the specified island. For more information, see islandhopper.meta

## SET_MAPDATACULLBOX_ENABLED

```c
void SET_MAPDATACULLBOX_ENABLED(const char* name, BOOL toggle)  // 0xAF12610C644A35C9
```

build 323

> Possible p0 values:
> 
> "prologue"
> "Prologue_Main"

## SET_MODEL_AS_NO_LONGER_NEEDED

```c
void SET_MODEL_AS_NO_LONGER_NEEDED(Hash model)  // 0xE532F5D78798DAAB
```

build 323

> Unloads model from memory

## SET_PED_POPULATION_BUDGET

```c
void SET_PED_POPULATION_BUDGET(int p0)  // 0x8C95333CFC3340F3
```

build 323

> Control how many new (ambient?) peds will spawn in the game world.
> Range for p0 seems to be 0-3, where 0 is none and 3 is the normal level.

## SET_PLAYER_SHORT_SWITCH_STYLE

```c
void SET_PLAYER_SHORT_SWITCH_STYLE(int p0)  // 0x5F2013F8BC24EE69
```

build 323

## SET_PLAYER_SWITCH_ESTABLISHING_SHOT

```c
void SET_PLAYER_SWITCH_ESTABLISHING_SHOT(const char* name)  // 0x0FDE9DBFC0A6BC65
```

build 323

> All names can be found in playerswitchestablishingshots.meta

## SET_PLAYER_SWITCH_OUTRO

```c
void SET_PLAYER_SWITCH_OUTRO(float cameraCoordX, float cameraCoordY, float cameraCoordZ, float camRotationX, float camRotationY, float camRotationZ, float camFov, float camFarClip, int rotationOrder)  // 0xC208B673CE446B61
```

build 323

## SET_REDUCE_PED_MODEL_BUDGET

```c
void SET_REDUCE_PED_MODEL_BUDGET(BOOL toggle)  // 0x77B5F9A36BF96710
```

build 323

## SET_REDUCE_VEHICLE_MODEL_BUDGET

```c
void SET_REDUCE_VEHICLE_MODEL_BUDGET(BOOL toggle)  // 0x80C527893080CCF3
```

build 323

## SET_RENDER_HD_ONLY

```c
void SET_RENDER_HD_ONLY(BOOL toggle)  // 0x40AEFD1A244741F2
```

build 323

## SET_RESTORE_FOCUS_ENTITY

```c
void SET_RESTORE_FOCUS_ENTITY(Entity p0)  // 0x0811381EF5062FEC
```

build 323

## SET_SCENE_STREAMING_TRACKS_CAM_POS_THIS_FRAME

```c
void SET_SCENE_STREAMING_TRACKS_CAM_POS_THIS_FRAME()  // 0x1E9057A74FD73E23
```

build 323

## SET_SRL_FORCE_PRESTREAM

```c
void SET_SRL_FORCE_PRESTREAM(Any p0)  // 0xF8155A7F03DDFC8E
```

build 323

## SET_SRL_LONG_JUMP_MODE

```c
void SET_SRL_LONG_JUMP_MODE(BOOL p0)  // 0x20C6C7E4EB082A7F
```

build 323

## SET_SRL_POST_CUTSCENE_CAMERA

```c
void SET_SRL_POST_CUTSCENE_CAMERA(Any p0, Any p1, Any p2, Any p3, Any p4, Any p5)  // 0xEF39EE20C537E98C
```

build 323

## SET_SRL_READAHEAD_TIMES

```c
void SET_SRL_READAHEAD_TIMES(Any p0, Any p1, Any p2, Any p3)  // 0xBEB2D9A1D9A8F55A
```

build 323

## SET_SRL_TIME

```c
void SET_SRL_TIME(float p0)  // 0xA74A541C6884E7B8
```

build 323

## SET_STREAMING

```c
void SET_STREAMING(BOOL toggle)  // 0x6E0C692677008888
```

build 323

## SET_VEHICLE_POPULATION_BUDGET

```c
void SET_VEHICLE_POPULATION_BUDGET(int p0)  // 0xCB9E1EB3BE2AF4E9
```

build 323

## SHUTDOWN_CREATOR_BUDGET

```c
void SHUTDOWN_CREATOR_BUDGET()  // 0xCCE26000E9A6FAD7
```

build 323

## START_PLAYER_SWITCH

```c
void START_PLAYER_SWITCH(Ped from, Ped to, int flags, int switchType)  // 0xFAA23F2CBA159D67
```

build 323

> enum ePlayerSwitchTypes
> {
> 	SWITCH_TYPE_AUTO,
> 	SWITCH_TYPE_LONG,
> 	SWITCH_TYPE_MEDIUM,
> 	SWITCH_TYPE_SHORT
> };
> 
> Use GET_IDEAL_PLAYER_SWITCH_TYPE for the best switch type.
> 
> ----------------------------------------------------
> 
> Examples from the decompiled scripts:
> 
> STREAMING::START_PLAYER_SWITCH(l_832._f3, PLAYER::PLAYER_PED_ID(), 0, 3);
> STREAMING::START_PLAYER_SWITCH(l_832._f3, PLAYER::PLAYER_PED_ID(), 2050, 3);
> STREAMING::START_PLAYER_SWITCH(PLAYER::PLAYER_PED_ID(), l_832._f3, 1024, 3);
> STREAMING::START_PLAYER_SWITCH(g_141F27, PLAYER::PLAYER_PED_ID(), 513, v_14);
> 
> Note: DO NOT, use SWITCH_TYPE_LONG with flag 513. It leaves you stuck in the clouds. You'll have to call STOP_PLAYER_SWITCH() to return to your ped.
> 
> Flag 8 w/ SWITCH_TYPE_LONG will zoom out 3 steps, then zoom in 2/3 steps and stop on the 3rd and just hang there.
> Flag 8 w/ SWITCH_TYPE_MEDIUM will zoom out 1 step, and just hang there.

## STOP_PLAYER_SWITCH

```c
void STOP_PLAYER_SWITCH()  // 0x95C0A5BBDC189AA1
```

build 323

## STREAMVOL_CREATE_FRUSTUM

```c
int STREAMVOL_CREATE_FRUSTUM(float p0, float p1, float p2, float p3, float p4, float p5, float p6, Any p7, Any p8)  // 0x1F3F018BC3AFA77C
```

build 323

> Always returns zero.

## STREAMVOL_CREATE_LINE

```c
int STREAMVOL_CREATE_LINE(float p0, float p1, float p2, float p3, float p4, float p5, Any p6)  // 0x0AD9710CEE2F590F
```

build 323

> Always returns zero.

## STREAMVOL_CREATE_SPHERE

```c
int STREAMVOL_CREATE_SPHERE(float x, float y, float z, float rad, Any p4, Any p5)  // 0x219C7B8D53E429FD
```

build 323 · old names: `FORMAT_FOCUS_HEADING`

> Always returns zero.

## STREAMVOL_DELETE

```c
void STREAMVOL_DELETE(Any unused)  // 0x1EE7D8DF4425F053
```

build 323

## STREAMVOL_HAS_LOADED

```c
BOOL STREAMVOL_HAS_LOADED(Any unused)  // 0x7D41E9D2D17C5B2D
```

build 323

## STREAMVOL_IS_VALID

```c
BOOL STREAMVOL_IS_VALID(Any unused)  // 0x07C313F94746702C
```

build 323

## SUPPRESS_HD_MAP_STREAMING_THIS_FRAME

```c
void SUPPRESS_HD_MAP_STREAMING_THIS_FRAME()  // 0x472397322E92A856
```

build 323

## SWITCH_TO_MULTI_FIRSTPART

```c
void SWITCH_TO_MULTI_FIRSTPART(Ped ped, int flags, int switchType)  // 0xAAB3200ED59016BC
```

build 323 · old names: `_SWITCH_OUT_PLAYER`

> doesn't act normally when used on mount chilliad
> Flags is a bitflag:
> 2^n - Enabled Functionality:
> 0 - Skip camera rotate up
> 3 - Wait for SET_PLAYER_SWITCH_ESTABLISHING_SHOT / hang at last step. You will still need to run ALLOW_PLAYER_SWITCH_OUTRO to exit "properly" and then STOP_PLAYER_SWITCH
> 6 - Invert Switch Direction (false = out, true = in)
> 8 - Hang above ped
> 
> switchType: 0 - 3
> 0: 1 step towards ped
> 1: 3 steps out from ped
> 2: 1 step out from ped
> 3: 1 step towards ped

## SWITCH_TO_MULTI_SECONDPART

```c
void SWITCH_TO_MULTI_SECONDPART(Ped ped)  // 0xD8295AF639FD9CB8
```

build 323 · old names: `_SWITCH_IN_PLAYER`

