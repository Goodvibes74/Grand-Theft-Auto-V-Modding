# GRAPHICS natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _CALCULATE_LINE_ORIENTATION_FROM_RENDERED_CAMERA

```c
void _CALCULATE_LINE_ORIENTATION_FROM_RENDERED_CAMERA(Vector3* result, float x1, float y1, float z1, float x2, float y2, float z2)  // 0x9F7996F4E32B3026
```

build 3889

## _CALCULATE_ROTATED_VECTOR

```c
void _CALCULATE_ROTATED_VECTOR(Vector3* direction, float roll, float pitch, float yaw)  // 0xA7804512D1FDD22A
```

build 3889

## _DRAW_CAPSULE_LIGHT

```c
void _DRAW_CAPSULE_LIGHT(float posX, float posY, float posZ, float dirX, float dirY, float dirZ, int colorR, int colorG, int colorB, float falloff, float intensity, float capsuleExtent, float exponent)  // 0x330F4FA20FB57738
```

build 3889

## _DRAW_MARKER_GLOW

```c
void _DRAW_MARKER_GLOW(float x, float y, float z, float size, int red, int green, int blue, float intensity)  // 0xE59B0A106CC15FC2
```

build 3889

## _FORCE_ALLOW_SNOW_FOOT_VFX_ON_ICE

```c
void _FORCE_ALLOW_SNOW_FOOT_VFX_ON_ICE(BOOL toggle)  // 0xA342A3763B3AFB6C
```

build 3095

## _FORCE_GROUND_SNOW_PASS

```c
void _FORCE_GROUND_SNOW_PASS(BOOL toggle)  // 0x6E9EF3A33C8899F8
```

build 3095

## _HAS_SCALEFORM_MOVIE_NAMED_LOADED

```c
BOOL _HAS_SCALEFORM_MOVIE_NAMED_LOADED(int* scaleformHandle, const char* scaleformName)  // 0x9743BCCF7CD6E1F6
```

build 3407

## _MAKE_GLOWS_ADDITIVE

```c
void _MAKE_GLOWS_ADDITIVE(BOOL toggle)  // 0xDC60226A3F4D9F42
```

build 3889

> If enabled sets the blend state of all GameGlows to BS_AlphaAdd

## _SET_BLEND_STATE_ALPHA_ADDITIVE

```c
void _SET_BLEND_STATE_ALPHA_ADDITIVE()  // 0x01677A72A8BDCD1A
```

build 3889

> Issues a ScriptIM command that sets the blend state to BS_AlphaAdd

## _SET_BLEND_STATE_NORMAL

```c
void _SET_BLEND_STATE_NORMAL()  // 0x976D155439608592
```

build 3889

> Issues a ScriptIM command that sets the blend state to BS_Normal

## _SET_PARTICLE_FX_LOOPED_CAMERA_BIAS

```c
void _SET_PARTICLE_FX_LOOPED_CAMERA_BIAS(int ptfxHandle, float p1)  // 0x4100BF0346A8D2C3
```

build 3095

## _SET_SCALEFORM_MOVIE_NAMED_AS_NO_LONGER_NEEDED

```c
void _SET_SCALEFORM_MOVIE_NAMED_AS_NO_LONGER_NEEDED(int scaleformHandle, const char* scaleformName)  // 0x2FDFB1B04C76E9C3
```

build 3407

## _SET_TV_CHANNEL_PLAYLIST_DIRTY

```c
Any _SET_TV_CHANNEL_PLAYLIST_DIRTY(int tvChannel, BOOL p1)  // 0xEE831F15A8D0D94A
```

build 3095

> Does not actually return anything.

## _START_VEHICLE_PARTICLE_FX_LOOPED

```c
int _START_VEHICLE_PARTICLE_FX_LOOPED(Vehicle vehicle, const char* effectName, BOOL frontBack, BOOL leftRight, BOOL localOnly)  // 0xDF269BE2909E181A
```

build 3095

> Returns ptfxHandle
> effectName: scr_sv_drag_burnout

## _UPDATE_LIGHTS_LOCATION_FROM_ENTITY

```c
void _UPDATE_LIGHTS_LOCATION_FROM_ENTITY(Entity entity)  // 0x988C5FE3B815C998
```

build 3889

## ABORT_VEHICLE_CREW_EMBLEM_REQUEST

```c
BOOL ABORT_VEHICLE_CREW_EMBLEM_REQUEST(int* p0)  // 0x82ACC484FFA3B05F
```

build 372

## ADD_DECAL

```c
int ADD_DECAL(int decalType, float posX, float posY, float posZ, float p4, float p5, float p6, float p7, float p8, float p9, float width, float height, float rCoef, float gCoef, float bCoef, float opacity, float timeout, BOOL p17, BOOL p18, BOOL p19)  // 0xB302244A1839BDAD
```

build 323

> decal types:
> 
> public enum DecalTypes
> {
>     splatters_blood = 1010,
>     splatters_blood_dir = 1015,
>     splatters_blood_mist = 1017,
>     splatters_mud = 1020,
>     splatters_paint = 1030,
>     splatters_water = 1040,
>     splatters_water_hydrant = 1050,
>     splatters_blood2 = 1110,
>     weapImpact_metal = 4010,
>     weapImpact_concrete = 4020,
>     weapImpact_mattress = 4030,
>     weapImpact_mud = 4032,
>     weapImpact_wood = 4050,
>     weapImpact_sand = 4053,
>     weapImpact_cardboard = 4040,
>     weapImpact_melee_glass = 4100,
>     weapImpact_glass_blood = 4102,
>     weapImpact_glass_blood2 = 4104,
>     weapImpact_shotgun_paper = 4200,
>     weapImpact_shotgun_mattress,
>     weapImpact_shotgun_metal,
>     weapImpact_shotgun_wood,
>     weapImpact_shotgun_dirt,
>     weapImpact_shotgun_tvscreen,
>     weapImpact_shotgun_tvscreen2,
>     weapImpact_shotgun_tvscreen3,
>     weapImpact_melee_concrete = 4310,
>     weapImpact_melee_wood = 4312,
>     weapImpact_melee_metal = 4314,
>     burn1 = 4421,
>     burn2,
>     burn3,
>     burn4,
>     burn5,
>     bang_concrete_bang = 5000,
>     bang_concrete_bang2,
>     bang_bullet_bang,
>     bang_bullet_bang2 = 5004,
>     bang_glass = 5031,
>     bang_glass2,
>     solidPool_water = 9000,
>     solidPool_blood,
>     solidPool_oil,
>     solidPool_petrol,
>     solidPool_mud,
>     porousPool_water,
>     porousPool_blood,
>     porousPool_oil,
>     porousPool_petrol,
>     porousPool_mud,
>     porousPool_water_ped_drip,
>     liquidTrail_water = 9050
> }

## ADD_ENTITY_ICON

```c
int ADD_ENTITY_ICON(Entity entity, const char* icon)  // 0x9CD43EEE12BF4DD0
```

build 323

> Example:
> GRAPHICS::ADD_ENTITY_ICON(a_0, "MP_Arrow");
> 
> I tried this and nothing happened...

## ADD_OIL_DECAL

```c
int ADD_OIL_DECAL(float x, float y, float z, float groundLvl, float width, float transparency)  // 0x126D7F89FE859A5E
```

build 2699 · old names: `_ADD_PETROL_DECAL_2`, `_ADD_OIL_DECAL`

## ADD_PETROL_DECAL

```c
int ADD_PETROL_DECAL(float x, float y, float z, float groundLvl, float width, float transparency)  // 0x4F5212C7AD880DF8
```

build 323

## ADD_PETROL_TRAIL_DECAL_INFO

```c
void ADD_PETROL_TRAIL_DECAL_INFO(float x, float y, float z, float p3)  // 0x967278682CB6967A
```

build 323

## ADD_TCMODIFIER_OVERRIDE

```c
void ADD_TCMODIFIER_OVERRIDE(const char* modifierName1, const char* modifierName2)  // 0x1A8E2C8B9CF4549C
```

build 323

## ADD_VEHICLE_CREW_EMBLEM

```c
BOOL ADD_VEHICLE_CREW_EMBLEM(Vehicle vehicle, Ped ped, int boneIndex, float x1, float x2, float x3, float y1, float y2, float y3, float z1, float z2, float z3, float scale, Any p13, int alpha)  // 0x428BDCB9DA58DA53
```

build 323 · old names: `_ADD_CLAN_DECAL_TO_VEHICLE`

> boneIndex is always chassis_dummy in the scripts. The x/y/z params are location relative to the chassis bone.

## ADJUST_NEXT_POS_SIZE_AS_NORMALIZED_16_9

```c
void ADJUST_NEXT_POS_SIZE_AS_NORMALIZED_16_9()  // 0xEFABC7722293DA7C
```

build 323

## ANIMPOSTFX_GET_CURRENT_TIME

```c
float ANIMPOSTFX_GET_CURRENT_TIME(const char* effectName)  // 0xE35B38A27E8E7179
```

build 877 · old names: `_ANIMPOSTFX_GET_UNK`

> See ANIMPOSTFX_PLAY
> 
> Full list of animpostFX / screen effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animPostFxNamesCompact.json

## ANIMPOSTFX_IS_RUNNING

```c
BOOL ANIMPOSTFX_IS_RUNNING(const char* effectName)  // 0x36AD3E690DA5ACEB
```

build 323 · old names: `_GET_SCREEN_EFFECT_IS_ACTIVE`

> Returns whether the specified effect is active.
> See ANIMPOSTFX_PLAY
> 
> Full list of animpostFX / screen effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animPostFxNamesCompact.json

## ANIMPOSTFX_PLAY

```c
void ANIMPOSTFX_PLAY(const char* effectName, int duration, BOOL looped)  // 0x2206BF9A37B7F724
```

build 323 · old names: `_START_SCREEN_EFFECT`

> duration - is how long to play the effect for in milliseconds. If 0, it plays the default length
> if loop is true, the effect won't stop until you call ANIMPOSTFX_STOP on it. (only loopable effects)
> 
> Full list of animpostFX / screen effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animPostFxNamesCompact.json

## ANIMPOSTFX_STOP

```c
void ANIMPOSTFX_STOP(const char* effectName)  // 0x068E835A1D0DC0E3
```

build 323 · old names: `_STOP_SCREEN_EFFECT`

> See ANIMPOSTFX_PLAY
> 
> Full list of animpostFX / screen effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animPostFxNamesCompact.json

## ANIMPOSTFX_STOP_ALL

```c
void ANIMPOSTFX_STOP_ALL()  // 0xB4EDDC19532BFB85
```

build 323 · old names: `_STOP_ALL_SCREEN_EFFECTS`

> Stops ALL currently playing effects.

## ANIMPOSTFX_STOP_AND_FLUSH_REQUESTS

```c
void ANIMPOSTFX_STOP_AND_FLUSH_REQUESTS(const char* effectName)  // 0xD2209BE128B5418C
```

build 323 · old names: `_ANIMPOSTFX_STOP_AND_DO_UNK`

> Stops the effect and sets a value (bool) in its data (+0x199) to false.
> See ANIMPOSTFX_PLAY
> 
> Full list of animpostFX / screen effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animPostFxNamesCompact.json

## ATTACH_TV_AUDIO_TO_ENTITY

```c
void ATTACH_TV_AUDIO_TO_ENTITY(Entity entity)  // 0x845BAD77CC770633
```

build 323

## BEGIN_CREATE_LOW_QUALITY_COPY_OF_PHOTO

```c
BOOL BEGIN_CREATE_LOW_QUALITY_COPY_OF_PHOTO(Any p0)  // 0x759650634F07B6B4
```

build 323

## BEGIN_CREATE_MISSION_CREATOR_PHOTO_PREVIEW

```c
BOOL BEGIN_CREATE_MISSION_CREATOR_PHOTO_PREVIEW()  // 0x7FA5D82B8F58EC06
```

build 323

## BEGIN_SCALEFORM_MOVIE_METHOD

```c
BOOL BEGIN_SCALEFORM_MOVIE_METHOD(int scaleform, const char* methodName)  // 0xF6E48914C7A8694E
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_FUNCTION`

> Push a function from the Scaleform onto the stack
> 

## BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND

```c
BOOL BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND(const char* methodName)  // 0xAB58C27C2E6123C6
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_FUNCTION_N`, `_BEGIN_SCALEFORM_MOVIE_METHOD_N`

> Starts frontend (pause menu) scaleform movie methods.
> This can be used when you want to make custom frontend menus, and customize things like images or text in the menus etc.
> Use `BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER` for header scaleform functions.

## BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER

```c
BOOL BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER(const char* methodName)  // 0xB9449845F73F5E9C
```

build 323 · old names: `_BEGIN_SCALEFORM_MOVIE_METHOD_V`

> Starts frontend (pause menu) scaleform movie methods for header options.
> Use `BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND` to customize the content inside the frontend menus.

## BEGIN_SCALEFORM_SCRIPT_HUD_MOVIE_METHOD

```c
BOOL BEGIN_SCALEFORM_SCRIPT_HUD_MOVIE_METHOD(int hudComponent, const char* methodName)  // 0x98C494FD5BDFBFD5
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_FUNCTION_FROM_HUD_COMPONENT`, `_BEGIN_SCALEFORM_MOVIE_METHOD_HUD_COMPONENT`

> Pushes a function from the Hud component Scaleform onto the stack. Same behavior as GRAPHICS::BEGIN_SCALEFORM_MOVIE_METHOD, just a hud component id instead of a Scaleform.
> 
> Known components:
> 19 - MP_RANK_BAR
> 20 - HUD_DIRECTOR_MODE
> 
> This native requires more research - all information can be found inside of 'hud.gfx'. Using a decompiler, the different components are located under "scripts\__Packages\com\rockstargames\gtav\hud\hudComponents" and "scripts\__Packages\com\rockstargames\gtav\Multiplayer".

## BEGIN_TAKE_HIGH_QUALITY_PHOTO

```c
BOOL BEGIN_TAKE_HIGH_QUALITY_PHOTO()  // 0xA67C35C56EB1BD9D
```

build 323

## BEGIN_TAKE_MISSION_CREATOR_PHOTO

```c
BOOL BEGIN_TAKE_MISSION_CREATOR_PHOTO()  // 0x1DD2139A9A20DCE8
```

build 323

## BEGIN_TEXT_COMMAND_SCALEFORM_STRING

```c
void BEGIN_TEXT_COMMAND_SCALEFORM_STRING(const char* componentType)  // 0x80338406F3475E55
```

build 323 · old names: `_BEGIN_TEXT_COMPONENT`

> Called prior to adding a text component to the UI. After doing so, GRAPHICS::END_TEXT_COMMAND_SCALEFORM_STRING is called.
> 
> Examples:
> GRAPHICS::BEGIN_TEXT_COMMAND_SCALEFORM_STRING("NUMBER");
> HUD::ADD_TEXT_COMPONENT_INTEGER(MISC::ABSI(a_1));
> GRAPHICS::END_TEXT_COMMAND_SCALEFORM_STRING();
> 
> GRAPHICS::BEGIN_TEXT_COMMAND_SCALEFORM_STRING("STRING");
> HUD::ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(a_2);
> GRAPHICS::END_TEXT_COMMAND_SCALEFORM_STRING();
> 
> GRAPHICS::BEGIN_TEXT_COMMAND_SCALEFORM_STRING("STRTNM2");
> HUD::ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL_HASH_KEY(v_3);
> HUD::ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL_HASH_KEY(v_4);
> GRAPHICS::END_TEXT_COMMAND_SCALEFORM_STRING();
> 
> GRAPHICS::BEGIN_TEXT_COMMAND_SCALEFORM_STRING("STRTNM1");
> HUD::ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL_HASH_KEY(v_3);
> GRAPHICS::END_TEXT_COMMAND_SCALEFORM_STRING();

## CALL_SCALEFORM_MOVIE_METHOD

```c
void CALL_SCALEFORM_MOVIE_METHOD(int scaleform, const char* method)  // 0xFBD96D87AC96D533
```

build 323 · old names: `_CALL_SCALEFORM_MOVIE_FUNCTION_VOID`

> Calls the Scaleform function.

## CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER

```c
void CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER(int scaleform, const char* methodName, float param1, float param2, float param3, float param4, float param5)  // 0xD0837058AE2E4BEE
```

build 323 · old names: `_CALL_SCALEFORM_MOVIE_FUNCTION_FLOAT_PARAMS`

> Calls the Scaleform function and passes the parameters as floats.
> 
> The number of parameters passed to the function varies, so the end of the parameter list is represented by -1.0.

## CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING

```c
void CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING(int scaleform, const char* methodName, float floatParam1, float floatParam2, float floatParam3, float floatParam4, float floatParam5, const char* stringParam1, const char* stringParam2, const char* stringParam3, const char* stringParam4, const char* stringParam5)  // 0xEF662D8D57E290B1
```

build 323 · old names: `_CALL_SCALEFORM_MOVIE_FUNCTION_MIXED_PARAMS`

> Calls the Scaleform function and passes both float and string parameters (in their respective order).
> 
> The number of parameters passed to the function varies, so the end of the float parameters is represented by -1.0, and the end of the string parameters is represented by 0 (NULL).
> 
> NOTE: The order of parameters in the function prototype is important! All float parameters must come first, followed by the string parameters.
> 
> Examples:
> // function MY_FUNCTION(floatParam1, floatParam2, stringParam)
> GRAPHICS::CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING(scaleform, "MY_FUNCTION", 10.0, 20.0, -1.0, -1.0, -1.0, "String param", 0, 0, 0, 0);
> 
> // function MY_FUNCTION_2(floatParam, stringParam1, stringParam2)
> GRAPHICS::CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING(scaleform, "MY_FUNCTION_2", 10.0, -1.0, -1.0, -1.0, -1.0, "String param #1", "String param #2", 0, 0, 0);

## CALL_SCALEFORM_MOVIE_METHOD_WITH_STRING

```c
void CALL_SCALEFORM_MOVIE_METHOD_WITH_STRING(int scaleform, const char* methodName, const char* param1, const char* param2, const char* param3, const char* param4, const char* param5)  // 0x51BC1ED3CC44E8F7
```

build 323 · old names: `_CALL_SCALEFORM_MOVIE_FUNCTION_STRING_PARAMS`

> Calls the Scaleform function and passes the parameters as strings.
> 
> The number of parameters passed to the function varies, so the end of the parameter list is represented by 0 (NULL).

## CASCADE_SHADOWS_CLEAR_SHADOW_SAMPLE_TYPE

```c
void CASCADE_SHADOWS_CLEAR_SHADOW_SAMPLE_TYPE()  // 0x27CB772218215325
```

build 323 · old names: `_CASCADESHADOWS_RESET_TYPE`

## CASCADE_SHADOWS_ENABLE_ENTITY_TRACKER

```c
void CASCADE_SHADOWS_ENABLE_ENTITY_TRACKER(BOOL toggle)  // 0x80ECBC0C856D3B0B
```

build 323 · old names: `_SET_FAR_SHADOWS_SUPPRESSED`

> When this is set to ON, shadows only draw as you get nearer.
> 
> When OFF, they draw from a further distance.

## CASCADE_SHADOWS_ENABLE_FREEZER

```c
void CASCADE_SHADOWS_ENABLE_FREEZER(BOOL p0)  // 0x0AE73D8DF3A762B2
```

build 323

## CASCADE_SHADOWS_INIT_SESSION

```c
void CASCADE_SHADOWS_INIT_SESSION()  // 0x03FC694AE06C5A20
```

build 323

## CASCADE_SHADOWS_SET_AIRCRAFT_MODE

```c
void CASCADE_SHADOWS_SET_AIRCRAFT_MODE(BOOL p0)  // 0x6DDBF9DFFC4AC080
```

build 323

## CASCADE_SHADOWS_SET_BOUND_POSITION

```c
void CASCADE_SHADOWS_SET_BOUND_POSITION(Any p0)  // 0x259BA6D4E6F808F1
```

build 1011

## CASCADE_SHADOWS_SET_CASCADE_BOUNDS

```c
void CASCADE_SHADOWS_SET_CASCADE_BOUNDS(Any p0, BOOL p1, float p2, float p3, float p4, float p5, BOOL p6, float p7)  // 0xD2936CAB8B58FCBD
```

build 323

## CASCADE_SHADOWS_SET_CASCADE_BOUNDS_SCALE

```c
void CASCADE_SHADOWS_SET_CASCADE_BOUNDS_SCALE(float p0)  // 0x5F0F3F56635809EF
```

build 323

## CASCADE_SHADOWS_SET_DYNAMIC_DEPTH_MODE

```c
void CASCADE_SHADOWS_SET_DYNAMIC_DEPTH_MODE(BOOL p0)  // 0xD39D13C9FEBF0511
```

build 323

## CASCADE_SHADOWS_SET_DYNAMIC_DEPTH_VALUE

```c
void CASCADE_SHADOWS_SET_DYNAMIC_DEPTH_VALUE(float p0)  // 0x02AC28F3A01FA04A
```

build 323

## CASCADE_SHADOWS_SET_ENTITY_TRACKER_SCALE

```c
void CASCADE_SHADOWS_SET_ENTITY_TRACKER_SCALE(float p0)  // 0x5E9DAF5A20F15908
```

build 323

## CASCADE_SHADOWS_SET_SCREEN_SIZE_CHECK_ENABLED

```c
void CASCADE_SHADOWS_SET_SCREEN_SIZE_CHECK_ENABLED(BOOL p0)  // 0x25FC3E33A31AD0C9
```

build 323

## CASCADE_SHADOWS_SET_SHADOW_SAMPLE_TYPE

```c
void CASCADE_SHADOWS_SET_SHADOW_SAMPLE_TYPE(const char* type)  // 0xB11D94BC55F41932
```

build 323 · old names: `_CASCADESHADOWS_SET_TYPE`

> Possible values:
> "CSM_ST_POINT"
> "CSM_ST_LINEAR"
> "CSM_ST_TWOTAP"
> "CSM_ST_BOX3x3"
> "CSM_ST_BOX4x4"
> "CSM_ST_DITHER2_LINEAR"
> "CSM_ST_CUBIC"
> "CSM_ST_DITHER4"
> "CSM_ST_DITHER16"
> "CSM_ST_SOFT16"
> "CSM_ST_DITHER16_RPDB"
> "CSM_ST_POISSON16_RPDB_GNORM"
> "CSM_ST_HIGHRES_BOX4x4"
> "CSM_ST_CLOUDS_SIMPLE"
> "CSM_ST_CLOUDS_LINEAR"
> "CSM_ST_CLOUDS_TWOTAP"
> "CSM_ST_CLOUDS_BOX3x3"
> "CSM_ST_CLOUDS_BOX4x4"
> "CSM_ST_CLOUDS_DITHER2_LINEAR"
> "CSM_ST_CLOUDS_SOFT16"
> "CSM_ST_CLOUDS_DITHER16_RPDB"
> "CSM_ST_CLOUDS_POISSON16_RPDB_GNORM"

## CASCADE_SHADOWS_SET_SPLIT_Z_EXP_WEIGHT

```c
void CASCADE_SHADOWS_SET_SPLIT_Z_EXP_WEIGHT(float p0)  // 0x36F6626459D91457
```

build 323

## CLEAR_ALL_TCMODIFIER_OVERRIDES

```c
void CLEAR_ALL_TCMODIFIER_OVERRIDES(const char* p0)  // 0x15E33297C3E8DC60
```

build 323 · old names: `REMOVE_TCMODIFIER_OVERRIDE`

## CLEAR_DRAW_ORIGIN

```c
void CLEAR_DRAW_ORIGIN()  // 0xFF0B610F6BE0D7AF
```

build 323

> Resets the screen's draw-origin which was changed by the function GRAPHICS::SET_DRAW_ORIGIN(...) back to x=0,y=0.
> 
> See GRAPHICS::SET_DRAW_ORIGIN(...) for further information.

## CLEAR_EXTRA_TCMODIFIER

```c
void CLEAR_EXTRA_TCMODIFIER()  // 0x92CCC17A7A2285DA
```

build 323 · old names: `_CLEAR_EXTRA_TIMECYCLE_MODIFIER`

> Clears the secondary timecycle modifier usually set with SET_EXTRA_TCMODIFIER

## CLEAR_PARTICLE_FX_SHOOTOUT_BOAT

```c
void CLEAR_PARTICLE_FX_SHOOTOUT_BOAT()  // 0x2A251AA48B2B46DB
```

build 323

## CLEAR_STATUS_OF_SORTED_LIST_OPERATION

```c
void CLEAR_STATUS_OF_SORTED_LIST_OPERATION()  // 0x4AF92ACD3141D96C
```

build 323

## CLEAR_TIMECYCLE_MODIFIER

```c
void CLEAR_TIMECYCLE_MODIFIER()  // 0x0F07E7745A236711
```

build 323

## CLEAR_TV_CHANNEL_PLAYLIST

```c
void CLEAR_TV_CHANNEL_PLAYLIST(int tvChannel)  // 0xBEB3D46BB7F043C0
```

build 323

## CREATE_CHECKPOINT

```c
int CREATE_CHECKPOINT(int type, float posX1, float posY1, float posZ1, float posX2, float posY2, float posZ2, float diameter, int red, int green, int blue, int alpha, int reserved)  // 0x0134F0835AB6BFCB
```

build 323

> Creates a checkpoint. Returns the handle of the checkpoint.
> 
> 20/03/17 : Attention, checkpoints are already handled by the game itself, so you must not loop it like markers.
> 
> Parameters:
> * type - The type of checkpoint to create. See below for a list of checkpoint types.
> * pos1 - The position of the checkpoint.
> * pos2 - The position of the next checkpoint to point to.
> * radius - The radius of the checkpoint.
> * color - The color of the checkpoint.
> * reserved - Special parameter, see below for details. Usually set to 0 in the scripts.
> 
> Checkpoint types:
> 0-4---------Cylinder: 1 arrow, 2 arrow, 3 arrows, CycleArrow, Checker
> 5-9---------Cylinder: 1 arrow, 2 arrow, 3 arrows, CycleArrow, Checker
> 10-14-------Ring: 1 arrow, 2 arrow, 3 arrows, CycleArrow, Checker
> 15-19-------1 arrow, 2 arrow, 3 arrows, CycleArrow, Checker      
> 20-24-------Cylinder: 1 arrow, 2 arrow, 3 arrows, CycleArrow, Checker 
> 25-29-------Cylinder: 1 arrow, 2 arrow, 3 arrows, CycleArrow, Checker    
> 30-34-------Cylinder: 1 arrow, 2 arrow, 3 arrows, CycleArrow, Checker 
> 35-38-------Ring: Airplane Up, Left, Right, UpsideDown
> 39----------?
> 40----------Ring: just a ring
> 41----------?
> 42-44-------Cylinder w/ number (uses 'reserved' parameter)
> 45-47-------Cylinder no arrow or number
> 
> If using type 42-44, reserved sets number / number and shape to display
> 
> 0-99------------Just numbers (0-99)
> 100-109-----------------Arrow (0-9)
> 110-119------------Two arrows (0-9)
> 120-129----------Three arrows (0-9)
> 130-139----------------Circle (0-9)
> 140-149------------CycleArrow (0-9)
> 150-159----------------Circle (0-9)
> 160-169----Circle  w/ pointer (0-9)
> 170-179-------Perforated ring (0-9)
> 180-189----------------Sphere (0-9)

## CREATE_TRACKED_POINT

```c
int CREATE_TRACKED_POINT()  // 0xE2C9439ED45DEA60
```

build 323

> Creates a tracked point, useful for checking the visibility of a 3D point on screen.

## DELETE_CHECKPOINT

```c
void DELETE_CHECKPOINT(int checkpoint)  // 0xF5ED37F54CD4D52E
```

build 323

## DESTROY_TRACKED_POINT

```c
void DESTROY_TRACKED_POINT(int point)  // 0xB25DC90BAD56CA42
```

build 323

## DISABLE_COMPOSITE_SHOTGUN_DECALS

```c
void DISABLE_COMPOSITE_SHOTGUN_DECALS(BOOL toggle)  // 0x0E4299C549F0D1F1
```

build 323

## DISABLE_DOWNWASH_PTFX

```c
void DISABLE_DOWNWASH_PTFX(BOOL toggle)  // 0x5F6DF3D92271E8A1
```

build 323 · old names: `SET_PARTICLE_FX_BLOOD_SCALE`

## DISABLE_HDTEX_THIS_FRAME

```c
void DISABLE_HDTEX_THIS_FRAME()  // 0xC35A6D07C93802B2
```

build 323

## DISABLE_IN_WATER_PTFX

```c
void DISABLE_IN_WATER_PTFX(BOOL toggle)  // 0xCFD16F0DB5A3535C
```

build 2060

## DISABLE_MOON_CYCLE_OVERRIDE

```c
void DISABLE_MOON_CYCLE_OVERRIDE()  // 0x2BF72AD5B41AA739
```

build 323 · old names: `_RESET_EXTRA_TIMECYCLE_MODIFIER_STRENGTH`

> Resets the timecycle modifier strength normally set with ENABLE_MOON_CYCLE_OVERRIDE

## DISABLE_OCCLUSION_THIS_FRAME

```c
void DISABLE_OCCLUSION_THIS_FRAME()  // 0x3669F1B198DCAA4F
```

build 323

## DISABLE_PROCOBJ_CREATION

```c
void DISABLE_PROCOBJ_CREATION()  // 0x1612C45F9E3E0D44
```

build 323

## DISABLE_REGION_VFX

```c
void DISABLE_REGION_VFX(Any p0)  // 0xEFD97FF47B745B8D
```

build 791 · old names: `_DISABLE_SCRIPT_AMBIENT_EFFECTS`

## DISABLE_SCREENBLUR_FADE

```c
void DISABLE_SCREENBLUR_FADE()  // 0xDE81239437E8C5A8
```

build 323 · old names: `PAUSED_SCREENBLUR_LOADED`

## DISABLE_SCUFF_DECALS

```c
void DISABLE_SCUFF_DECALS(BOOL toggle)  // 0x02369D5C8A51FDCF
```

build 323

## DISABLE_VEHICLE_DISTANTLIGHTS

```c
void DISABLE_VEHICLE_DISTANTLIGHTS(BOOL toggle)  // 0xC9F98AC1884E73A2
```

build 323

## DOES_LATEST_BRIEF_STRING_EXIST

```c
BOOL DOES_LATEST_BRIEF_STRING_EXIST(int p0)  // 0x5E657EF1099EDD65
```

build 323

## DOES_PARTICLE_FX_LOOPED_EXIST

```c
BOOL DOES_PARTICLE_FX_LOOPED_EXIST(int ptfxHandle)  // 0x74AFEF0D2E1E409B
```

build 323

## DOES_THIS_PHOTO_SLOT_CONTAIN_A_VALID_PHOTO

```c
BOOL DOES_THIS_PHOTO_SLOT_CONTAIN_A_VALID_PHOTO(Any p0)  // 0xE791DF1F73ED2C8B
```

build 323

> This function is hard-coded to always return 0.

## DOES_VEHICLE_HAVE_CREW_EMBLEM

```c
BOOL DOES_VEHICLE_HAVE_CREW_EMBLEM(Vehicle vehicle, int p1)  // 0x060D935D3981A275
```

build 323 · old names: `_HAS_VEHICLE_GOT_DECAL`, `_DOES_VEHICLE_HAVE_DECAL`

## DONT_RENDER_IN_GAME_UI

```c
void DONT_RENDER_IN_GAME_UI(BOOL p0)  // 0x22A249A53034450A
```

build 323

## DRAW_BINK_MOVIE

```c
void DRAW_BINK_MOVIE(int binkMovie, float p1, float p2, float p3, float p4, float p5, int r, int g, int b, int a)  // 0x7118E83EEB9F7238
```

build 1290 · old names: `_DRAW_BINK_MOVIE`

## DRAW_BOX

```c
void DRAW_BOX(float x1, float y1, float z1, float x2, float y2, float z2, int red, int green, int blue, int alpha)  // 0xD3A9971CADAC7252
```

build 323

> x,y,z = start pos
> x2,y2,z2 = end pos
> 
> Draw's a 3D Box between the two x,y,z coords.
> --------------
> Keep in mind that the edges of the box do only align to the worlds base-vectors. Therefore something like rotation cannot be applied. That means this function is pretty much useless, unless you want a static unicolor box somewhere.
> I recommend using a predefined function to call this.
> [VB.NET]
> Public Sub DrawBox(a As Vector3, b As Vector3, col As Color)
>     [Function].Call(Hash.DRAW_BOX,a.X, a.Y, a.Z,b.X, b.Y, b.Z,col.R, col.G, col.B, col.A)
> End Sub
> 
> [C#]
> public void DrawBox(Vector3 a, Vector3 b, Color col)
> {
>     Function.Call(Hash.DRAW_BOX,a.X, a.Y, a.Z,b.X, b.Y, b.Z,col.R, col.G, col.B, col.A);
> }

## DRAW_DEBUG_BOX

```c
void DRAW_DEBUG_BOX(float x1, float y1, float z1, float x2, float y2, float z2, int r, int g, int b, int alpha)  // 0x083A2CA4F2E573BD
```

build 323

## DRAW_DEBUG_CROSS

```c
void DRAW_DEBUG_CROSS(float x, float y, float z, float size, int red, int green, int blue, int alpha)  // 0x73B1189623049839
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## DRAW_DEBUG_LINE

```c
void DRAW_DEBUG_LINE(float x1, float y1, float z1, float x2, float y2, float z2, int r, int g, int b, int alpha)  // 0x7FDFADE676AA3CB0
```

build 323

## DRAW_DEBUG_LINE_WITH_TWO_COLOURS

```c
void DRAW_DEBUG_LINE_WITH_TWO_COLOURS(float x1, float y1, float z1, float x2, float y2, float z2, int r1, int g1, int b1, int r2, int g2, int b2, int alpha1, int alpha2)  // 0xD8B9A8AC5608FF94
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## DRAW_DEBUG_SPHERE

```c
void DRAW_DEBUG_SPHERE(float x, float y, float z, float radius, int red, int green, int blue, int alpha)  // 0xAAD68E1AB39DA632
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## DRAW_DEBUG_TEXT

```c
void DRAW_DEBUG_TEXT(const char* text, float x, float y, float z, int red, int green, int blue, int alpha)  // 0x3903E216620488E8
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## DRAW_DEBUG_TEXT_2D

```c
void DRAW_DEBUG_TEXT_2D(const char* text, float x, float y, float z, int red, int green, int blue, int alpha)  // 0xA3BB2E9555C05A8F
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## DRAW_LIGHT_WITH_RANGE

```c
void DRAW_LIGHT_WITH_RANGE(float posX, float posY, float posZ, int colorR, int colorG, int colorB, float range, float intensity)  // 0xF2A1B2771A01DBD4
```

build 323

## DRAW_LIGHT_WITH_RANGEEX

```c
void DRAW_LIGHT_WITH_RANGEEX(float x, float y, float z, int r, int g, int b, float range, float intensity, float shadow)  // 0xF49E9A9716A04595
```

build 323 · old names: `_DRAW_LIGHT_WITH_RANGE_WITH_SHADOW`, `_DRAW_LIGHT_WITH_RANGE_AND_SHADOW`

## DRAW_LINE

```c
void DRAW_LINE(float x1, float y1, float z1, float x2, float y2, float z2, int red, int green, int blue, int alpha)  // 0x6B7256074AE34680
```

build 323

> Draws a depth-tested line from one point to another.
> ----------------
> x1, y1, z1 : Coordinates for the first point
> x2, y2, z2 : Coordinates for the second point
> r, g, b, alpha : Color with RGBA-Values
> I recommend using a predefined function to call this.
> [VB.NET]
> Public Sub DrawLine(from As Vector3, [to] As Vector3, col As Color)
>     [Function].Call(Hash.DRAW_LINE, from.X, from.Y, from.Z, [to].X, [to].Y, [to].Z, col.R, col.G, col.B, col.A)
> End Sub
> 
> [C#]
> public void DrawLine(Vector3 from, Vector3 to, Color col)
> {
>     Function.Call(Hash.DRAW_LINE, from.X, from.Y, from.Z, to.X, to.Y, to.Z, col.R, col.G, col.B, col.A);
> }

## DRAW_LOW_QUALITY_PHOTO_TO_PHONE

```c
void DRAW_LOW_QUALITY_PHOTO_TO_PHONE(BOOL p0, BOOL p1)  // 0x1072F115DAB0717E
```

build 323

## DRAW_MARKER

```c
void DRAW_MARKER(int type, float posX, float posY, float posZ, float dirX, float dirY, float dirZ, float rotX, float rotY, float rotZ, float scaleX, float scaleY, float scaleZ, int red, int green, int blue, int alpha, BOOL bobUpAndDown, BOOL faceCamera, int rotationOrder, BOOL rotate, const char* textureDict, const char* textureName, BOOL invert)  // 0x28477EC23D892089
```

build 323

> Draws a marker with the specified appearance at the target location. This has to be called every frame.
> 
> type: The marker type to draw.
> posX: The X coordinate to draw the marker at.
> posY: The Y coordinate to draw the marker at.
> posZ: The Z coordinate to draw the marker at.
> dirX: The X component of the direction vector for the marker, or 0.0 to use rotX/Y/Z.
> dirY: The Y component of the direction vector for the marker, or 0.0 to use rotX/Y/Z.
> dirZ: The Z component of the direction vector for the marker, or 0.0 to use rotX/Y/Z.
> rotX: The X rotation for the marker. Only used if the direction vector is 0.0.
> rotY: The Y rotation for the marker. Only used if the direction vector is 0.0.
> rotZ: The Z rotation for the marker. Only used if the direction vector is 0.0.
> scaleX: The scale for the marker on the X axis.
> scaleY: The scale for the marker on the Y axis.
> scaleZ: The scale for the marker on the Z axis.
> red: The red component of the marker color, on a scale from 0-255.
> green: The green component of the marker color, on a scale from 0-255.
> blue: The blue component of the marker color, on a scale from 0-255.
> alpha: The alpha component of the marker color, on a scale from 0-255.
> bobUpAndDown: Whether or not the marker should slowly animate up/down.
> faceCamera: Whether the marker should be a 'billboard', as in, should constantly face the camera.
> rotationOrder: The order yaw, pitch and roll is applied. Usually 2.
> rotate: Rotations only apply to the heading.
> textureDict: A texture dictionary to draw the marker with, or NULL. Example: 'GolfPutting'
> textureName: A texture name in textureDict to draw the marker with, or NULL. Example: 'PuttingMarker'
> invert: Whether or not the marker should use an inverted depth test.
> 
> enum eMarkerType
> {
> 	MARKER_CONE = 0,
> 	MARKER_CYLINDER = 1,
> 	MARKER_ARROW = 2,
> 	MARKER_ARROW_FLAT = 3,
> 	MARKER_FLAG = 4,
> 	MARKER_RING_FLAG = 5,
> 	MARKER_RING = 6,
> 	MARKER_PLANE = 7,
> 	MARKER_BIKE_LOGO_1 = 8,
> 	MARKER_BIKE_LOGO_2 = 9,
> 	MARKER_NUM_0 = 10,
> 	MARKER_NUM_1 = 11,
> 	MARKER_NUM_2 = 12,
> 	MARKER_NUM_3 = 13,
> 	MARKER_NUM_4 = 14,
> 	MARKER_NUM_5 = 15,
> 	MARKER_NUM_6 = 16,
> 	MARKER_NUM_7 = 17,
> 	MARKER_NUM_8 = 18,
> 	MARKER_NUM_9 = 19,
> 	MARKER_CHEVRON_1 = 20,
> 	MARKER_CHEVRON_2 = 21,
> 	MARKER_CHEVRON_3 = 22,
> 	MARKER_RING_FLAT = 23,
> 	MARKER_LAP = 24,
> 	MARKER_HALO = 25,
> 	MARKER_HALO_POINT = 26,
> 	MARKER_HALO_ROTATE = 27,
> 	MARKER_SPHERE = 28,
> 	MARKER_MONEY = 29,
> 	MARKER_LINES = 30,
> 	MARKER_BEAST = 31,
> 	MARKER_QUESTION_MARK = 32,
> 	MARKER_TRANSFORM_PLANE = 33,
> 	MARKER_TRANSFORM_HELICOPTER = 34,
> 	MARKER_TRANSFORM_BOAT = 35,
> 	MARKER_TRANSFORM_CAR = 36,
> 	MARKER_TRANSFORM_BIKE = 37,
> 	MARKER_TRANSFORM_PUSH_BIKE = 38,
> 	MARKER_TRANSFORM_TRUCK = 39,
> 	MARKER_TRANSFORM_PARACHUTE = 40,
> 	MARKER_TRANSFORM_THRUSTER = 41,
> 	MARKER_WARP = 42,
> 	MARKER_BOXES = 43,
> 	MARKER_PIT_LANE = 44,
> };

## DRAW_MARKER_EX

```c
void DRAW_MARKER_EX(int type, float posX, float posY, float posZ, float dirX, float dirY, float dirZ, float rotX, float rotY, float rotZ, float scaleX, float scaleY, float scaleZ, int red, int green, int blue, int alpha, BOOL bobUpAndDown, BOOL faceCamera, int rotationOrder, BOOL rotate, const char* textureDict, const char* textureName, BOOL invert, BOOL usePreAlphaDepth, BOOL matchEntityRotOrder)  // 0xE82728F0DE75D13A
```

build 573 · old names: `_DRAW_MARKER_2`

> See DRAW_MARKER

## DRAW_MARKER_SPHERE

```c
void DRAW_MARKER_SPHERE(float x, float y, float z, float radius, int red, int green, int blue, float alpha)  // 0x799017F9E3B10112
```

build 463 · old names: `_DRAW_SPHERE`

> Draws a 3D sphere, typically seen in the GTA:O freemode event "Penned In".
> Example: https://i.imgur.com/nCbtS4H.png
> 
> alpha - The alpha for the sphere. Goes from 0.0 to 1.0.

## DRAW_POLY

```c
void DRAW_POLY(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, int red, int green, int blue, int alpha)  // 0xAC26716048436851
```

build 323

> x/y/z - Location of a vertex (in world coords), presumably.
> ----------------
> x1, y1, z1     : Coordinates for the first point
> x2, y2, z2     : Coordinates for the second point
> x3, y3, z3     : Coordinates for the third point
> r, g, b, alpha : Color with RGBA-Values
> 
> Keep in mind that only one side of the drawn triangle is visible: It's the side, in which the vector-product of the vectors heads to: (b-a)x(c-a) Or (b-a)x(c-b).
> But be aware: The function seems to work somehow differently. I have trouble having them drawn in rotated orientation. Try it yourself and if you somehow succeed, please edit this and post your solution.
> I recommend using a predefined function to call this.
> [VB.NET]
> Public Sub DrawPoly(a As Vector3, b As Vector3, c As Vector3, col As Color)
>     [Function].Call(Hash.DRAW_POLY, a.X, a.Y, a.Z, b.X, b.Y, b.Z, c.X, c.Y, c.Z, col.R, col.G, col.B, col.A)
> End Sub
> 
> [C#]
> public void DrawPoly(Vector3 a, Vector3 b, Vector3 c, Color col)
> {
>     Function.Call(Hash.DRAW_POLY, a.X, a.Y, a.Z, b.X, b.Y, b.Z, c.X, c.Y, c.Z, col.R, col.G, col.B, col.A);
> }
> BTW: Intersecting triangles are not supported: They overlap in the order they were called.

## DRAW_RECT

```c
void DRAW_RECT(float x, float y, float width, float height, int r, int g, int b, int a, BOOL p8)  // 0x3A618A217E5154F0
```

build 323

> Draws a rectangle on the screen.
> 
> -x: The relative X point of the center of the rectangle. (0.0-1.0, 0.0 is the left edge of the screen, 1.0 is the right edge of the screen)
> 
> -y: The relative Y point of the center of the rectangle. (0.0-1.0, 0.0 is the top edge of the screen, 1.0 is the bottom edge of the screen)
> 
> -width: The relative width of the rectangle. (0.0-1.0, 1.0 means the whole screen width)
> 
> -height: The relative height of the rectangle. (0.0-1.0, 1.0 means the whole screen height)
> 
> -R: Red part of the color. (0-255)
> 
> -G: Green part of the color. (0-255)
> 
> -B: Blue part of the color. (0-255)
> 
> -A: Alpha part of the color. (0-255, 0 means totally transparent, 255 means totally opaque)
> 
> The total number of rectangles to be drawn in one frame is apparently limited to 399.
> 

## DRAW_SCALEFORM_MOVIE

```c
void DRAW_SCALEFORM_MOVIE(int scaleformHandle, float x, float y, float width, float height, int red, int green, int blue, int alpha, int p9)  // 0x54972ADAF0294A93
```

build 323

## DRAW_SCALEFORM_MOVIE_3D

```c
void DRAW_SCALEFORM_MOVIE_3D(int scaleform, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float p7, float p8, float p9, float scaleX, float scaleY, float scaleZ, int rotationOrder)  // 0x87D51D72255D4E78
```

build 323

## DRAW_SCALEFORM_MOVIE_3D_SOLID

```c
void DRAW_SCALEFORM_MOVIE_3D_SOLID(int scaleform, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float p7, float p8, float p9, float scaleX, float scaleY, float scaleZ, int rotationOrder)  // 0x1CE592FDC749D6F5
```

build 323 · old names: `_DRAW_SCALEFORM_MOVIE_3D_NON_ADDITIVE`

## DRAW_SCALEFORM_MOVIE_FULLSCREEN

```c
void DRAW_SCALEFORM_MOVIE_FULLSCREEN(int scaleform, int red, int green, int blue, int alpha, int p5)  // 0x0DF606929C105BE1
```

build 323

> unk is not used so no need

## DRAW_SCALEFORM_MOVIE_FULLSCREEN_MASKED

```c
void DRAW_SCALEFORM_MOVIE_FULLSCREEN_MASKED(int scaleform1, int scaleform2, int red, int green, int blue, int alpha)  // 0xCF537FDE4FBD4CE5
```

build 323

## DRAW_SHADOWED_SPOT_LIGHT

```c
void DRAW_SHADOWED_SPOT_LIGHT(float posX, float posY, float posZ, float dirX, float dirY, float dirZ, int colorR, int colorG, int colorB, float distance, float brightness, float roundness, float radius, float falloff, int shadowId)  // 0x5BCA583A583194DB
```

build 323 · old names: `_DRAW_SPOT_LIGHT_WITH_SHADOW`

## DRAW_SPOT_LIGHT

```c
void DRAW_SPOT_LIGHT(float posX, float posY, float posZ, float dirX, float dirY, float dirZ, int colorR, int colorG, int colorB, float distance, float brightness, float hardness, float radius, float falloff)  // 0xD0F64B265C8C8B33
```

build 323

> Parameters:
> * pos - coordinate where the spotlight is located
> * dir - the direction vector the spotlight should aim at from its current position
> * r,g,b - color of the spotlight
> * distance - the maximum distance the light can reach
> * brightness - the brightness of the light
> * roundness - "smoothness" of the circle edge
> * radius - the radius size of the spotlight
> * falloff - the falloff size of the light's edge
> 
> Example in C# (spotlight aims at the closest vehicle):
> Vector3 myPos = Game.Player.Character.Position;
> Vehicle nearest = World.GetClosestVehicle(myPos , 1000f);
> Vector3 destinationCoords = nearest.Position;
> Vector3 dirVector = destinationCoords - myPos;
> dirVector.Normalize();
> Function.Call(Hash.DRAW_SPOT_LIGHT, pos.X, pos.Y, pos.Z, dirVector.X, dirVector.Y, dirVector.Z, 255, 255, 255, 100.0f, 1f, 0.0f, 13.0f, 1f);

## DRAW_SPRITE

```c
void DRAW_SPRITE(const char* textureDict, const char* textureName, float screenX, float screenY, float width, float height, float heading, int red, int green, int blue, int alpha, BOOL p11, Any p12)  // 0xE7FFAE5EBF23D890
```

build 323

> Draws a 2D sprite on the screen.
> 
> Parameters:
> textureDict - Name of texture dictionary to load texture from (e.g. "CommonMenu", "MPWeaponsCommon", etc.)
> 
> textureName - Name of texture to load from texture dictionary (e.g. "last_team_standing_icon", "tennis_icon", etc.)
> 
> screenX/Y - Screen offset (0.5 = center)
> scaleX/Y - Texture scaling. Negative values can be used to flip the texture on that axis. (0.5 = half)
> 
> heading - Texture rotation in degrees (default = 0.0) positive is clockwise, measured in degrees
> 
> red,green,blue - Sprite color (default = 255/255/255)
> 
> alpha - opacity level

## DRAW_SPRITE_ARX

```c
void DRAW_SPRITE_ARX(const char* textureDict, const char* textureName, float x, float y, float width, float height, float p6, int red, int green, int blue, int alpha, Any p11, Any p12)  // 0x2D3B147AFAD49DE0
```

build 1290

> Used in arcade games and Beam hack minigame in Doomsday Heist. I will most certainly dive into this to try replicate arcade games.
> x position must be between 0.0 and 1.0 (1.0 being the most right side of the screen)
> y position must be between 0.0 and 1.0 (1.0 being the most bottom side of the screen)
> width 0.0 - 1.0 is the reasonable amount generally
> height 0.0 - 1.0 is the reasonable amount generally
> p6 almost always 0.0
> p11 seems to be unknown but almost always 0 int

## DRAW_SPRITE_ARX_WITH_UV

```c
void DRAW_SPRITE_ARX_WITH_UV(const char* textureDict, const char* textureName, float x, float y, float width, float height, float u1, float v1, float u2, float v2, float heading, int red, int green, int blue, int alpha, Any p15)  // 0x95812F9B26074726
```

build 1868 · old names: `_DRAW_SPRITE_UV`

> Similar to DRAW_SPRITE, but allows to specify the texture coordinates used to draw the sprite.
> 
> u1, v1 - texture coordinates for the top-left corner
> u2, v2 - texture coordinates for the bottom-right corner

## DRAW_SPRITE_NAMED_RENDERTARGET

```c
void DRAW_SPRITE_NAMED_RENDERTARGET(const char* textureDict, const char* textureName, float screenX, float screenY, float width, float height, float heading, int red, int green, int blue, int alpha, Any p11)  // 0x2BC54A8188768488
```

build 877 · old names: `_DRAW_INTERACTIVE_SPRITE`

> Similar to DRAW_SPRITE, but seems to be some kind of "interactive" sprite, at least used by render targets.
> These seem to be the only dicts ever requested by this native:
> 
> prop_screen_biker_laptop
> Prop_Screen_GR_Disruption
> Prop_Screen_TaleOfUs
> prop_screen_nightclub
> Prop_Screen_IE_Adhawk
> prop_screen_sm_free_trade_shipping
> prop_screen_hacker_truck
> MPDesktop
> Prop_Screen_Nightclub
> And a few others
> 

## DRAW_TEXTURED_POLY

```c
void DRAW_TEXTURED_POLY(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, int red, int green, int blue, int alpha, const char* textureDict, const char* textureName, float u1, float v1, float w1, float u2, float v2, float w2, float u3, float v3, float w3)  // 0x29280002282F1928
```

build 877 · old names: `_DRAW_SPRITE_POLY`

> Used for drawling Deadline trailing lights, see deadline.ytd
> 
> p15 through p23 are values that appear to be related to illiumation, scaling, and rotation; more testing required.
> For UVW mapping (u,v,w parameters), reference your favourite internet resource for more details.

## DRAW_TEXTURED_POLY_WITH_THREE_COLOURS

```c
void DRAW_TEXTURED_POLY_WITH_THREE_COLOURS(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float red1, float green1, float blue1, int alpha1, float red2, float green2, float blue2, int alpha2, float red3, float green3, float blue3, int alpha3, const char* textureDict, const char* textureName, float u1, float v1, float w1, float u2, float v2, float w2, float u3, float v3, float w3)  // 0x736D7AA1B750856B
```

build 877 · old names: `_DRAW_SPRITE_POLY_2`

> Used for drawling Deadline trailing lights, see deadline.ytd
> 
> Each vertex has its own colour that is blended/illuminated on the texture. Additionally, the R, G, and B components are floats that are int-casted internally.
> For UVW mapping (u,v,w parameters), reference your favourite internet resource for more details.

## DRAW_TV_CHANNEL

```c
void DRAW_TV_CHANNEL(float xPos, float yPos, float xScale, float yScale, float rotation, int red, int green, int blue, int alpha)  // 0xFDDC2B4ED3C69DF0
```

build 323

> All calls to this native are preceded by calls to GRAPHICS::SET_SCRIPT_GFX_DRAW_ORDER and GRAPHICS::SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, respectively.
> 
> "act_cinema.ysc", line 1483:
> HUD::SET_HUD_COMPONENT_POSITION(15, 0.0, -0.0375);
> HUD::SET_TEXT_RENDER_ID(l_AE);
> GRAPHICS::SET_SCRIPT_GFX_DRAW_ORDER(4);
> GRAPHICS::SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU(1);
> if (GRAPHICS::IS_TVSHOW_CURRENTLY_PLAYING(${movie_arthouse})) {
>     GRAPHICS::DRAW_TV_CHANNEL(0.5, 0.5, 0.7375, 1.0, 0.0, 255, 255, 255, 255);
> } else { 
>     GRAPHICS::DRAW_TV_CHANNEL(0.5, 0.5, 1.0, 1.0, 0.0, 255, 255, 255, 255);
> }
> 
> "am_mp_property_int.ysc", line 102545:
> if (ENTITY::DOES_ENTITY_EXIST(a_2._f3)) {
>     if (HUD::IS_NAMED_RENDERTARGET_LINKED(ENTITY::GET_ENTITY_MODEL(a_2._f3))) {
>         HUD::SET_TEXT_RENDER_ID(a_2._f1);
>         GRAPHICS::SET_SCRIPT_GFX_DRAW_ORDER(4);
>         GRAPHICS::SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU(1);
>         GRAPHICS::DRAW_TV_CHANNEL(0.5, 0.5, 1.0, 1.0, 0.0, 255, 255, 255, 255);
>         if (GRAPHICS::GET_TV_CHANNEL() == -1) {
>             sub_a8fa5(a_2, 1);
>         } else { 
>             sub_a8fa5(a_2, 1);
>             GRAPHICS::ATTACH_TV_AUDIO_TO_ENTITY(a_2._f3);
>         }
>         HUD::SET_TEXT_RENDER_ID(HUD::GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID());
>     }
> }
> 

## ENABLE_ALIEN_BLOOD_VFX

```c
void ENABLE_ALIEN_BLOOD_VFX(BOOL toggle)  // 0x9DCE1F0F78260875
```

build 323

> Creates a motion-blur sort of effect, this native does not seem to work, however by using the `START_SCREEN_EFFECT` native with `DrugsMichaelAliensFight` as the effect parameter, you should be able to get the effect.

## ENABLE_CLOWN_BLOOD_VFX

```c
void ENABLE_CLOWN_BLOOD_VFX(BOOL toggle)  // 0xD821490579791273
```

build 323 · old names: `SET_CAMERA_ENDTIME`

> Creates cartoon effect when Michel smokes the weed

## ENABLE_MOON_CYCLE_OVERRIDE

```c
void ENABLE_MOON_CYCLE_OVERRIDE(float strength)  // 0x2C328AF17210F009
```

build 323 · old names: `_SET_EXTRA_TIMECYCLE_MODIFIER_STRENGTH`, `_ENABLE_EXTRA_TIMECYCLE_MODIFIER_STRENGTH`

> The same as SET_TIMECYCLE_MODIFIER_STRENGTH but for the secondary timecycle modifier.

## ENABLE_MOVIE_KEYFRAME_WAIT

```c
void ENABLE_MOVIE_KEYFRAME_WAIT(BOOL toggle)  // 0x74C180030FDE4B69
```

build 323

## ENABLE_MOVIE_SUBTITLES

```c
void ENABLE_MOVIE_SUBTITLES(BOOL toggle)  // 0x873FA65C778AD970
```

build 323

## ENABLE_PROCOBJ_CREATION

```c
void ENABLE_PROCOBJ_CREATION()  // 0x5DEBD9C4DC995692
```

build 323

## END_PETROL_TRAIL_DECALS

```c
void END_PETROL_TRAIL_DECALS()  // 0x0A123435A26C36CD
```

build 323

## END_SCALEFORM_MOVIE_METHOD

```c
void END_SCALEFORM_MOVIE_METHOD()  // 0xC6796A8FFA375E53
```

build 323 · old names: `_POP_SCALEFORM_MOVIE_FUNCTION_VOID`

> Pops and calls the Scaleform function on the stack

## END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE

```c
int END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE()  // 0xC50AA39A577AF886
```

build 323 · old names: `_POP_SCALEFORM_MOVIE_FUNCTION`, `_END_SCALEFORM_MOVIE_METHOD_RETURN`

## END_TEXT_COMMAND_SCALEFORM_STRING

```c
void END_TEXT_COMMAND_SCALEFORM_STRING()  // 0x362E2D3FE93A9959
```

build 323 · old names: `_END_TEXT_COMPONENT`

## END_TEXT_COMMAND_UNPARSED_SCALEFORM_STRING

```c
void END_TEXT_COMMAND_UNPARSED_SCALEFORM_STRING()  // 0xAE4E8157D9ECF087
```

build 323 · old names: `_END_TEXT_COMMAND_SCALEFORM_STRING_2`

> Same as END_TEXT_COMMAND_SCALEFORM_STRING but does not perform HTML conversion for text tokens.

## FADE_DECALS_IN_RANGE

```c
void FADE_DECALS_IN_RANGE(float x, float y, float z, float p3, float p4)  // 0xD77EDADB0420E6E0
```

build 323

> Fades nearby decals within the range specified

## FADE_UP_PED_LIGHT

```c
void FADE_UP_PED_LIGHT(float p0)  // 0xC9B18B4619F48F7B
```

build 323

## FORCE_EXPOSURE_READBACK

```c
void FORCE_EXPOSURE_READBACK(BOOL toggle)  // 0x814AF7DCAACC597B
```

build 372

## FORCE_PARTICLE_FX_IN_VEHICLE_INTERIOR

```c
void FORCE_PARTICLE_FX_IN_VEHICLE_INTERIOR(Any p0, Any p1)  // 0xBA0127DA25FD54C9
```

build 372

## FORCE_POSTFX_BULLET_IMPACTS_AFTER_HUD

```c
void FORCE_POSTFX_BULLET_IMPACTS_AFTER_HUD(BOOL p0)  // 0x9B079E5221D984D3
```

build 323

## FORCE_RENDER_IN_GAME_UI

```c
void FORCE_RENDER_IN_GAME_UI(BOOL toggle)  // 0xDC459CFA0CCE245B
```

build 323

## FREE_MEMORY_FOR_HIGH_QUALITY_PHOTO

```c
void FREE_MEMORY_FOR_HIGH_QUALITY_PHOTO()  // 0xD801CC02177FA3F1
```

build 323

## FREE_MEMORY_FOR_LOW_QUALITY_PHOTO

```c
void FREE_MEMORY_FOR_LOW_QUALITY_PHOTO()  // 0x6A12D88881435DCA
```

build 323

## FREE_MEMORY_FOR_MISSION_CREATOR_PHOTO

```c
void FREE_MEMORY_FOR_MISSION_CREATOR_PHOTO()  // 0x0A46AF8A78DC5E0A
```

build 323

## FREE_MEMORY_FOR_MISSION_CREATOR_PHOTO_PREVIEW

```c
void FREE_MEMORY_FOR_MISSION_CREATOR_PHOTO_PREVIEW()  // 0x346EF3ECAAAB149E
```

build 323

## GET_ACTUAL_SCREEN_RESOLUTION

```c
void GET_ACTUAL_SCREEN_RESOLUTION(int* x, int* y)  // 0x873C9F3104101DD3
```

build 323 · old names: `_GET_SCREEN_ACTIVE_RESOLUTION`, `_GET_ACTIVE_SCREEN_RESOLUTION`

> Returns current screen resolution.

## GET_ASPECT_RATIO

```c
float GET_ASPECT_RATIO(BOOL b)  // 0xF1307EF624A80D87
```

build 323 · old names: `_GET_SCREEN_ASPECT_RATIO`, `_GET_ASPECT_RATIO`

## GET_BINK_MOVIE_TIME

```c
float GET_BINK_MOVIE_TIME(int binkMovie)  // 0x8E17DDD6B9D5BF29
```

build 1734 · old names: `_GET_BINK_MOVIE_TIME`

> In percentage: 0.0 - 100.0

## GET_CURRENT_NUMBER_OF_CLOUD_PHOTOS

```c
int GET_CURRENT_NUMBER_OF_CLOUD_PHOTOS()  // 0x473151EBC762C6DA
```

build 323 · old names: `_GET_NUMBER_OF_PHOTOS`, `_GET_CURRENT_NUMBER_OF_PHOTOS`

## GET_CURRENT_TV_CLIP_NAMEHASH

```c
Hash GET_CURRENT_TV_CLIP_NAMEHASH()  // 0x30432A0118736E00
```

build 1493

## GET_DECAL_WASH_LEVEL

```c
float GET_DECAL_WASH_LEVEL(int decal)  // 0x323F647679A09103
```

build 323

## GET_EXTRA_TCMODIFIER

```c
int GET_EXTRA_TCMODIFIER()  // 0xBB0527EC6341496D
```

build 323 · old names: `_GET_EXTRA_TIMECYCLE_MODIFIER_INDEX`

> See GET_TIMECYCLE_MODIFIER_INDEX for use, works the same just for the secondary timecycle modifier.
> Returns an integer representing the Timecycle modifier

## GET_IS_HIDEF

```c
BOOL GET_IS_HIDEF()  // 0x84ED31191CC5D2C9
```

build 323

> false = Any resolution < 1280x720
> true = Any resolution >= 1280x720

## GET_IS_PETROL_DECAL_IN_RANGE

```c
BOOL GET_IS_PETROL_DECAL_IN_RANGE(float xCoord, float yCoord, float zCoord, float radius)  // 0x2F09F7976C512404
```

build 323

## GET_IS_TIMECYCLE_TRANSITIONING_OUT

```c
BOOL GET_IS_TIMECYCLE_TRANSITIONING_OUT()  // 0x98D18905BF723B99
```

build 1493

## GET_IS_WIDESCREEN

```c
BOOL GET_IS_WIDESCREEN()  // 0x30CF4BDA4FCB1905
```

build 323

> Setting Aspect Ratio Manually in game will return:
> 
> false - for Narrow format Aspect Ratios (3:2, 4:3, 5:4, etc. )
> true - for Wide format Aspect Ratios (5:3, 16:9, 16:10, etc. )
> 
> Setting Aspect Ratio to "Auto" in game will return "false" or "true" based on the actual set Resolution Ratio.

## GET_LIGHT_OVERRIDE_MAX_INTENSITY_SCALE

```c
float GET_LIGHT_OVERRIDE_MAX_INTENSITY_SCALE()  // 0x393BD2275CEB7793
```

build 1103

## GET_LOAD_HIGH_QUALITY_PHOTO_STATUS

```c
int GET_LOAD_HIGH_QUALITY_PHOTO_STATUS(int p0)  // 0x40AFB081F8ADD4EE
```

build 323 · old names: `_RETURN_TWO`

> Hardcoded to always return 2.

## GET_MAXIMUM_NUMBER_OF_CLOUD_PHOTOS

```c
int GET_MAXIMUM_NUMBER_OF_CLOUD_PHOTOS()  // 0xDC54A7AF8B3A14EF
```

build 323 · old names: `_GET_MAXIMUM_NUMBER_OF_PHOTOS_2`

> This function is hard-coded to always return 96.

## GET_MAXIMUM_NUMBER_OF_PHOTOS

```c
int GET_MAXIMUM_NUMBER_OF_PHOTOS()  // 0x34D23450F028B0BF
```

build 323

> This function is hard-coded to always return 0.

## GET_MOTIONBLUR_MAX_VEL_SCALER

```c
float GET_MOTIONBLUR_MAX_VEL_SCALER()  // 0xE59343E9E96529E7
```

build 323

> Getter for SET_MOTIONBLUR_MAX_VEL_SCALER

## GET_REQUESTINGNIGHTVISION

```c
BOOL GET_REQUESTINGNIGHTVISION()  // 0x35FB78DC42B7BD21
```

build 323

## GET_SAFE_ZONE_SIZE

```c
float GET_SAFE_ZONE_SIZE()  // 0xBAF107B6BB2C97F0
```

build 323

> Gets the scale of safe zone. if the safe zone size scale is max, it will return 1.0.

## GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_BOOL

```c
BOOL GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_BOOL(int methodReturn)  // 0xD80A80346A45D761
```

build 757 · old names: `_GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_BOOL`

> methodReturn: The return value of this native: END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE

## GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT

```c
int GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(int methodReturn)  // 0x2DE7EFA66B906036
```

build 323 · old names: `_GET_SCALEFORM_MOVIE_FUNCTION_RETURN_INT`

> methodReturn: The return value of this native: END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE
> Used to get a return value from a scaleform function. Returns an int in the same way GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_STRING returns a string.

## GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_STRING

```c
const char* GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_STRING(int methodReturn)  // 0xE1E258829A885245
```

build 323 · old names: `SITTING_TV`, `_GET_SCALEFORM_MOVIE_FUNCTION_RETURN_STRING`

> methodReturn: The return value of this native: END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE
> Used to get a return value from a scaleform function. Returns a string in the same way GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT returns an int.

## GET_SCREEN_ASPECT_RATIO

```c
float GET_SCREEN_ASPECT_RATIO()  // 0xB2EBE8CBC58B90E9
```

build 323

## GET_SCREEN_COORD_FROM_WORLD_COORD

```c
BOOL GET_SCREEN_COORD_FROM_WORLD_COORD(float worldX, float worldY, float worldZ, float* screenX, float* screenY)  // 0x34E82F05DF2974F5
```

build 323 · old names: `_WORLD3D_TO_SCREEN2D`

> Convert a world coordinate into its relative screen coordinate.  (WorldToScreen)
> 
> Returns a boolean; whether or not the operation was successful. It will return false if the coordinates given are not visible to the rendering camera.
> 
> 
> For .NET users...
> 
> VB:
> Public Shared Function World3DToScreen2d(pos as vector3) As Vector2
> 
>         Dim x2dp, y2dp As New Native.OutputArgument
> 
>         Native.Function.Call(Of Boolean)(Native.Hash.GET_SCREEN_COORD_FROM_WORLD_COORD , pos.x, pos.y, pos.z, x2dp, y2dp)
>         Return New Vector2(x2dp.GetResult(Of Single), y2dp.GetResult(Of Single))
>       
>     End Function
> 
> C#:
> Vector2 World3DToScreen2d(Vector3 pos)
>     {
>         var x2dp = new OutputArgument();
>         var y2dp = new OutputArgument();
> 
>         Function.Call<bool>(Hash.GET_SCREEN_COORD_FROM_WORLD_COORD , pos.X, pos.Y, pos.Z, x2dp, y2dp);
>         return new Vector2(x2dp.GetResult<float>(), y2dp.GetResult<float>());
>     }
> //USE VERY SMALL VALUES FOR THE SCALE OF RECTS/TEXT because it is dramatically larger on screen than in 3D, e.g '0.05' small.
> 
> It does seem however that calling SET_DRAW_ORIGIN then your natives, then ending it. Seems to work better for certain things such as keeping boxes around people for a predator missile e.g.

## GET_SCREEN_RESOLUTION

```c
void GET_SCREEN_RESOLUTION(int* x, int* y)  // 0x888D57E407E63624
```

build 323

> int screenresx,screenresy;
> GET_SCREEN_RESOLUTION(&screenresx,&screenresy);

## GET_SCREENBLUR_FADE_CURRENT_TIME

```c
float GET_SCREENBLUR_FADE_CURRENT_TIME()  // 0x5CCABFFCA31DDE33
```

build 323 · old names: `IS_PARTICLE_FX_DELAYED_BLINK`

## GET_SCRIPT_GFX_ALIGN_POSITION

```c
void GET_SCRIPT_GFX_ALIGN_POSITION(float x, float y, float* calculatedX, float* calculatedY)  // 0x6DD8F5AA635EB4B2
```

build 323 · old names: `_GET_SCRIPT_GFX_POSITION`

> Calculates the effective X/Y fractions when applying the values set by SET_SCRIPT_GFX_ALIGN and SET_SCRIPT_GFX_ALIGN_PARAMS

## GET_STATUS_OF_CREATE_LOW_QUALITY_COPY_OF_PHOTO

```c
int GET_STATUS_OF_CREATE_LOW_QUALITY_COPY_OF_PHOTO(int p0)  // 0xCB82A0BF0E3E3265
```

build 323 · old names: `_GET_STATUS_OF_DRAW_LOW_QUALITY_PHOTO`

## GET_STATUS_OF_CREATE_MISSION_CREATOR_PHOTO_PREVIEW

```c
int GET_STATUS_OF_CREATE_MISSION_CREATOR_PHOTO_PREVIEW()  // 0x5B0316762AFD4A64
```

build 323

## GET_STATUS_OF_LOAD_MISSION_CREATOR_PHOTO

```c
int GET_STATUS_OF_LOAD_MISSION_CREATOR_PHOTO(Any* p0)  // 0x1670F8D05056F257
```

build 323

## GET_STATUS_OF_SAVE_HIGH_QUALITY_PHOTO

```c
int GET_STATUS_OF_SAVE_HIGH_QUALITY_PHOTO()  // 0x0C0C4E81E1AC60A0
```

build 323

## GET_STATUS_OF_SORTED_LIST_OPERATION

```c
int GET_STATUS_OF_SORTED_LIST_OPERATION(Any p0)  // 0xF5BED327CEA362B1
```

build 323

> 3 matches across 3 scripts. First 2 were 0, 3rd was 1. Possibly a bool.
> appcamera, appmedia, and cellphone_controller.

## GET_STATUS_OF_TAKE_HIGH_QUALITY_PHOTO

```c
int GET_STATUS_OF_TAKE_HIGH_QUALITY_PHOTO()  // 0x0D6CA79EEEBD8CA3
```

build 323

## GET_STATUS_OF_TAKE_MISSION_CREATOR_PHOTO

```c
int GET_STATUS_OF_TAKE_MISSION_CREATOR_PHOTO()  // 0x90A78ECAA4E78453
```

build 323

## GET_TEXTURE_RESOLUTION

```c
Vector3 GET_TEXTURE_RESOLUTION(const char* textureDict, const char* textureName)  // 0x35736EE65BD00C11
```

build 323

> Returns the texture resolution of the passed texture dict+name.
> 
> Note: Most texture resolutions are doubled compared to the console version of the game.

## GET_TIMECYCLE_MODIFIER_INDEX

```c
int GET_TIMECYCLE_MODIFIER_INDEX()  // 0xFDF3D97C674AFB66
```

build 323

> Only use for this in the PC scripts is:
> 
> if (GRAPHICS::GET_TIMECYCLE_MODIFIER_INDEX() != -1)

## GET_TIMECYCLE_TRANSITION_MODIFIER_INDEX

```c
int GET_TIMECYCLE_TRANSITION_MODIFIER_INDEX()  // 0x459FD2C8D0AB78BC
```

build 323

## GET_TOGGLE_PAUSED_RENDERPHASES_STATUS

```c
BOOL GET_TOGGLE_PAUSED_RENDERPHASES_STATUS()  // 0xEB3DAC2C86001E5E
```

build 323

## GET_TV_CHANNEL

```c
int GET_TV_CHANNEL()  // 0xFC1E275A90D39995
```

build 323

## GET_TV_VOLUME

```c
float GET_TV_VOLUME()  // 0x2170813D3DD8661B
```

build 323

## GET_USINGNIGHTVISION

```c
BOOL GET_USINGNIGHTVISION()  // 0x2202A3F42C8E5F79
```

build 323 · old names: `_IS_NIGHTVISION_INACTIVE`, `_IS_NIGHTVISION_ACTIVE`

## GET_USINGSEETHROUGH

```c
BOOL GET_USINGSEETHROUGH()  // 0x44B80ABAB9D80BD3
```

build 323 · old names: `_IS_SEETHROUGH_ACTIVE`

## GET_VEHICLE_CREW_EMBLEM_REQUEST_STATE

```c
int GET_VEHICLE_CREW_EMBLEM_REQUEST_STATE(Vehicle vehicle, int p1)  // 0xFE26117A5841B2FF
```

build 323

## GOLF_TRAIL_GET_MAX_HEIGHT

```c
float GOLF_TRAIL_GET_MAX_HEIGHT()  // 0xA4819F5E23E2FFAD
```

build 323

## GOLF_TRAIL_GET_VISUAL_CONTROL_POINT

```c
Vector3 GOLF_TRAIL_GET_VISUAL_CONTROL_POINT(int p0)  // 0xA4664972A9B8F8BA
```

build 323

## GOLF_TRAIL_SET_COLOUR

```c
void GOLF_TRAIL_SET_COLOUR(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11)  // 0x12995F2E53FFA601
```

build 323

## GOLF_TRAIL_SET_ENABLED

```c
void GOLF_TRAIL_SET_ENABLED(BOOL toggle)  // 0xA51C4B86B71652AE
```

build 323

## GOLF_TRAIL_SET_FACING

```c
void GOLF_TRAIL_SET_FACING(BOOL p0)  // 0x06F761EA47C1D3ED
```

build 323

## GOLF_TRAIL_SET_FIXED_CONTROL_POINT

```c
void GOLF_TRAIL_SET_FIXED_CONTROL_POINT(int type, float xPos, float yPos, float zPos, float p4, int red, int green, int blue, int alpha)  // 0xB1BB03742917A5D6
```

build 323

> 12 matches across 4 scripts. All 4 scripts were job creators.
> 
> type ranged from 0 - 2.
> p4 was always 0.2f. Likely scale.
> assuming p5 - p8 is RGBA, the graphic is always yellow (255, 255, 0, 255).
> 
> Tested but noticed nothing.

## GOLF_TRAIL_SET_FIXED_CONTROL_POINT_ENABLE

```c
void GOLF_TRAIL_SET_FIXED_CONTROL_POINT_ENABLE(BOOL p0)  // 0xC0416B061F2B7E5E
```

build 323

## GOLF_TRAIL_SET_PATH

```c
void GOLF_TRAIL_SET_PATH(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7, BOOL p8)  // 0x312342E1A4874F3F
```

build 323

> p8 seems to always be false.

## GOLF_TRAIL_SET_RADIUS

```c
void GOLF_TRAIL_SET_RADIUS(float p0, float p1, float p2)  // 0x2485D34E50A22E84
```

build 323

## GOLF_TRAIL_SET_SHADER_PARAMS

```c
void GOLF_TRAIL_SET_SHADER_PARAMS(float p0, float p1, float p2, float p3, float p4)  // 0x9CFDD90B2B844BF7
```

build 323

> Only appeared in Golf & Golf_mp. Parameters were all ptrs

## GOLF_TRAIL_SET_TESSELLATION

```c
void GOLF_TRAIL_SET_TESSELLATION(int p0, int p1)  // 0xDBAA5EC848BA2D46
```

build 323

## GRAB_PAUSEMENU_OWNERSHIP

```c
void GRAB_PAUSEMENU_OWNERSHIP()  // 0x851CD923176EBA7C
```

build 323

## GRASSBATCH_DISABLE_FLATTENING

```c
void GRASSBATCH_DISABLE_FLATTENING()  // 0x302C91AB2D477F7E
```

build 323 · old names: `_GRASS_LOD_RESET_SCRIPT_AREAS`

## GRASSBATCH_ENABLE_FLATTENING_EXT_IN_SPHERE

```c
void GRASSBATCH_ENABLE_FLATTENING_EXT_IN_SPHERE(float x, float y, float z, Any p3, float p4, float p5, float p6, float scale)  // 0xAAE9BE70EC7C69AB
```

build 1290

## GRASSBATCH_ENABLE_FLATTENING_IN_SPHERE

```c
void GRASSBATCH_ENABLE_FLATTENING_IN_SPHERE(float x, float y, float z, float radius, float p4, float p5, float p6)  // 0x6D955F6A9E0295B1
```

build 323 · old names: `_GRASS_LOD_SHRINK_SCRIPT_AREAS`

> Wraps GRASSBATCH_ENABLE_FLATTENING_EXT_IN_SPHERE with FLT_MAX as p7

## HAS_SCALEFORM_CONTAINER_MOVIE_LOADED_INTO_PARENT

```c
BOOL HAS_SCALEFORM_CONTAINER_MOVIE_LOADED_INTO_PARENT(int scaleformHandle)  // 0x8217150E1217EBFD
```

build 323

## HAS_SCALEFORM_MOVIE_FILENAME_LOADED

```c
BOOL HAS_SCALEFORM_MOVIE_FILENAME_LOADED(const char* scaleformName)  // 0x0C1C5D756FB5F337
```

build 323 · old names: `_HAS_NAMED_SCALEFORM_MOVIE_LOADED`

> Only values used in the scripts are:
> 
> "heist_mp"
> "heistmap_mp"
> "instructional_buttons"
> "heist_pre"

## HAS_SCALEFORM_MOVIE_LOADED

```c
BOOL HAS_SCALEFORM_MOVIE_LOADED(int scaleformHandle)  // 0x85F01B8D5B90570E
```

build 323

## HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED

```c
BOOL HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED(int hudComponent)  // 0xDF6E5987D2B4D140
```

build 323 · old names: `_HAS_HUD_SCALEFORM_LOADED`

## HAS_STREAMED_TEXTURE_DICT_LOADED

```c
BOOL HAS_STREAMED_TEXTURE_DICT_LOADED(const char* textureDict)  // 0x0145F696AAAAD2E4
```

build 323

## IS_ACTIVE_SCALEFORM_MOVIE_DELETING

```c
BOOL IS_ACTIVE_SCALEFORM_MOVIE_DELETING(int scaleformHandle)  // 0x2FCB133CA50A49EB
```

build 1290

## IS_DECAL_ALIVE

```c
BOOL IS_DECAL_ALIVE(int decal)  // 0xC694D74949CAFD0C
```

build 323

## IS_PLAYLIST_ON_CHANNEL

```c
BOOL IS_PLAYLIST_ON_CHANNEL(int tvChannel, Any p1)  // 0x1F710BFF7DAE6261
```

build 1604 · old names: `_IS_PLAYLIST_UNK`

## IS_SCALEFORM_MOVIE_DELETING

```c
BOOL IS_SCALEFORM_MOVIE_DELETING(int scaleformHandle)  // 0x86255B1FC929E33E
```

build 1290

## IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY

```c
BOOL IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY(int methodReturn)  // 0x768FF8961BA904D6
```

build 323 · old names: `_GET_SCALEFORM_MOVIE_FUNCTION_RETURN_BOOL`

> methodReturn: The return value of this native: END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE
> Returns true if the return value of a scaleform function is ready to be collected (using GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_STRING or GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT).

## IS_SCREENBLUR_FADE_RUNNING

```c
BOOL IS_SCREENBLUR_FADE_RUNNING()  // 0x7B226C785A52A0A9
```

build 323

> Returns whether screen transition to blur/from blur is running.

## IS_TRACKED_POINT_VISIBLE

```c
BOOL IS_TRACKED_POINT_VISIBLE(int point)  // 0xC45CCDAAC9221CA8
```

build 323

## IS_TVSHOW_CURRENTLY_PLAYING

```c
BOOL IS_TVSHOW_CURRENTLY_PLAYING(Hash videoCliphash)  // 0x0AD973CA1E077B60
```

build 323 · old names: `_LOAD_TV_CHANNEL`, `_IS_TV_PLAYLIST_ITEM_PLAYING`

## LOAD_HIGH_QUALITY_PHOTO

```c
BOOL LOAD_HIGH_QUALITY_PHOTO(Any p0)  // 0xEC72C258667BE5EA
```

build 323

> This function is hard-coded to always return 0.

## LOAD_MISSION_CREATOR_PHOTO

```c
BOOL LOAD_MISSION_CREATOR_PHOTO(Any* p0, Any p1, Any p2, Any p3)  // 0x4862437A486F91B0
```

build 323

## LOAD_MOVIE_MESH_SET

```c
int LOAD_MOVIE_MESH_SET(const char* movieMeshSetName)  // 0xB66064452270E8F1
```

build 323

## MOVE_VEHICLE_DECALS

```c
void MOVE_VEHICLE_DECALS(Any p0, Any p1)  // 0x84C8D7C2D30D3280
```

build 323

## OVERRIDE_INTERIOR_SMOKE_END

```c
void OVERRIDE_INTERIOR_SMOKE_END()  // 0xEFB55E7C25D3B3BE
```

build 323

## OVERRIDE_INTERIOR_SMOKE_LEVEL

```c
void OVERRIDE_INTERIOR_SMOKE_LEVEL(float level)  // 0x1600FD8CF72EBC12
```

build 323

## OVERRIDE_INTERIOR_SMOKE_NAME

```c
void OVERRIDE_INTERIOR_SMOKE_NAME(const char* name)  // 0x2A2A52824DB96700
```

build 323

## OVERRIDE_NIGHTVISION_LIGHT_RANGE

```c
void OVERRIDE_NIGHTVISION_LIGHT_RANGE(float p0)  // 0x43FA7CBE20DAB219
```

build 1290

## OVERRIDE_PED_CREW_LOGO_TEXTURE

```c
BOOL OVERRIDE_PED_CREW_LOGO_TEXTURE(Ped ped, const char* txd, const char* txn)  // 0x95EB5E34F821BABE
```

build 877 · old names: `_OVERRIDE_PED_BADGE_TEXTURE`

> Overriding ped badge texture to a passed texture. It's synced between players (even custom textures!), don't forget to request used dict on *all* clients to make it sync properly. Can be removed by passing empty strings.

## PASS_KEYBOARD_INPUT_TO_SCALEFORM

```c
BOOL PASS_KEYBOARD_INPUT_TO_SCALEFORM(int scaleformHandle)  // 0xD1C7CB175E012964
```

build 323

## PATCH_DECAL_DIFFUSE_MAP

```c
void PATCH_DECAL_DIFFUSE_MAP(int decalType, const char* textureDict, const char* textureName)  // 0x8A35C742130C6080
```

build 323 · old names: `_ADD_DECAL_TO_MARKER`, `_OVERRIDE_DECAL_TEXTURE`

## PHONEPHOTOEDITOR_IS_ACTIVE

```c
BOOL PHONEPHOTOEDITOR_IS_ACTIVE()  // 0xBCEDB009461DA156
```

build 323

## PHONEPHOTOEDITOR_SET_FRAME_TXD

```c
BOOL PHONEPHOTOEDITOR_SET_FRAME_TXD(const char* textureDict, BOOL p1)  // 0x27FEB5254759CDE3
```

build 323

## PHONEPHOTOEDITOR_TOGGLE

```c
BOOL PHONEPHOTOEDITOR_TOGGLE(BOOL p0)  // 0x7AC24EAB6D74118D
```

build 323

## PLAY_BINK_MOVIE

```c
void PLAY_BINK_MOVIE(int binkMovie)  // 0x70D2CC8A542A973C
```

build 1290 · old names: `_PLAY_BINK_MOVIE`

## POP_TIMECYCLE_MODIFIER

```c
void POP_TIMECYCLE_MODIFIER()  // 0x3C8938D7D872211E
```

build 323

## PRESET_INTERIOR_AMBIENT_CACHE

```c
void PRESET_INTERIOR_AMBIENT_CACHE(const char* timecycleModifierName)  // 0xD7021272EB0A451E
```

build 323 · old names: `_PRESET_INTERIOR_AMBIENT_CACHE`

> Only one match in the scripts:
> 
> GRAPHICS::PRESET_INTERIOR_AMBIENT_CACHE("int_carrier_hanger");

## PROCGRASS_DISABLE_AMBSCALESCAN

```c
void PROCGRASS_DISABLE_AMBSCALESCAN()  // 0x0218BA067D249DEA
```

build 323

## PROCGRASS_DISABLE_CULLSPHERE

```c
void PROCGRASS_DISABLE_CULLSPHERE(int handle)  // 0x649C97D52332341A
```

build 323

## PROCGRASS_ENABLE_AMBSCALESCAN

```c
void PROCGRASS_ENABLE_AMBSCALESCAN()  // 0x14FC5833464340A8
```

build 323

## PROCGRASS_ENABLE_CULLSPHERE

```c
void PROCGRASS_ENABLE_CULLSPHERE(int handle, float x, float y, float z, float scale)  // 0xAE51BC858F32BA66
```

build 323

## PROCGRASS_IS_CULLSPHERE_ENABLED

```c
BOOL PROCGRASS_IS_CULLSPHERE_ENABLED(int handle)  // 0x2C42340F916C5930
```

build 323

## PUSH_TIMECYCLE_MODIFIER

```c
void PUSH_TIMECYCLE_MODIFIER()  // 0x58F735290861E6B4
```

build 323

## QUERY_MOVIE_MESH_SET_STATE

```c
int QUERY_MOVIE_MESH_SET_STATE(Any p0)  // 0x9B6E70C5CEEF4EEB
```

build 323

## QUEUE_OPERATION_TO_CREATE_SORTED_LIST_OF_PHOTOS

```c
BOOL QUEUE_OPERATION_TO_CREATE_SORTED_LIST_OF_PHOTOS(Any p0)  // 0x2A893980E96B659A
```

build 323

> 2 matches across 2 scripts. Only showed in appcamera & appmedia. Both were 0.

## REGISTER_NOIR_LENS_EFFECT

```c
void REGISTER_NOIR_LENS_EFFECT()  // 0xA44FF770DFBC5DAE
```

build 323 · old names: `_REGISTER_NOIR_SCREEN_EFFECT_THIS_FRAME`

> Used with 'NG_filmnoir_BW{01,02}' timecycles and the "NOIR_FILTER_SOUNDS" audioref.

## REGISTER_POSTFX_BULLET_IMPACT

```c
void REGISTER_POSTFX_BULLET_IMPACT(float weaponWorldPosX, float weaponWorldPosY, float weaponWorldPosZ, float intensity)  // 0x170911F37F646F29
```

build 2802

## RELEASE_BINK_MOVIE

```c
void RELEASE_BINK_MOVIE(int binkMovie)  // 0x04D950EEFA4EED8C
```

build 1290 · old names: `_RELEASE_BINK_MOVIE`

## RELEASE_MOVIE_MESH_SET

```c
void RELEASE_MOVIE_MESH_SET(int movieMeshSet)  // 0xEB119AA014E89183
```

build 323

## REMOVE_DECAL

```c
void REMOVE_DECAL(int decal)  // 0xED3F346429CCD659
```

build 323

## REMOVE_DECALS_FROM_OBJECT

```c
void REMOVE_DECALS_FROM_OBJECT(Object obj)  // 0xCCF71CBDDF5B6CB9
```

build 323

## REMOVE_DECALS_FROM_OBJECT_FACING

```c
void REMOVE_DECALS_FROM_OBJECT_FACING(Object obj, float x, float y, float z)  // 0xA6F6F70FDC6D144C
```

build 323

## REMOVE_DECALS_FROM_VEHICLE

```c
void REMOVE_DECALS_FROM_VEHICLE(Vehicle vehicle)  // 0xE91F1B65F2B48D57
```

build 323

## REMOVE_DECALS_IN_RANGE

```c
void REMOVE_DECALS_IN_RANGE(float x, float y, float z, float range)  // 0x5D6B2D4830A67C62
```

build 323

> Removes all decals in range from a position, it includes the bullet holes, blood pools, petrol...

## REMOVE_GRASS_CULL_SPHERE

```c
void REMOVE_GRASS_CULL_SPHERE(int handle)  // 0x61F95E5BB3E0A8C6
```

build 323

> This native does absolutely nothing, just a nullsub

## REMOVE_PARTICLE_FX

```c
void REMOVE_PARTICLE_FX(int ptfxHandle, BOOL p1)  // 0xC401503DFE8D53CF
```

build 323

## REMOVE_PARTICLE_FX_FROM_ENTITY

```c
void REMOVE_PARTICLE_FX_FROM_ENTITY(Entity entity)  // 0xB8FEAEEBCC127425
```

build 323

## REMOVE_PARTICLE_FX_IN_RANGE

```c
void REMOVE_PARTICLE_FX_IN_RANGE(float X, float Y, float Z, float radius)  // 0xDD19FA1C6D657305
```

build 323

## REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE

```c
void REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE(int hudComponent)  // 0xF44A5456AC3F4F97
```

build 323

## REMOVE_VEHICLE_CREW_EMBLEM

```c
void REMOVE_VEHICLE_CREW_EMBLEM(Vehicle vehicle, int p1)  // 0xD2300034310557E4
```

build 323

## RENDER_SHADOWED_LIGHTS_WITH_NO_SHADOWS

```c
void RENDER_SHADOWED_LIGHTS_WITH_NO_SHADOWS(BOOL p0)  // 0x03300B57FCAC6DDB
```

build 323

## REQUEST_EARLY_LIGHT_CHECK

```c
void REQUEST_EARLY_LIGHT_CHECK()  // 0x98EDF76A7271E4F2
```

build 323

## REQUEST_SCALEFORM_MOVIE

```c
int REQUEST_SCALEFORM_MOVIE(const char* scaleformName)  // 0x11FE353CF9733E6F
```

build 323

## REQUEST_SCALEFORM_MOVIE_INSTANCE

```c
int REQUEST_SCALEFORM_MOVIE_INSTANCE(const char* scaleformName)  // 0xC514489CFB8AF806
```

build 323

## REQUEST_SCALEFORM_MOVIE_SKIP_RENDER_WHILE_PAUSED

```c
int REQUEST_SCALEFORM_MOVIE_SKIP_RENDER_WHILE_PAUSED(const char* scaleformName)  // 0xBD06C611BB9048C2
```

build 323 · old names: `_REQUEST_SCALEFORM_MOVIE3`, `_REQUEST_SCALEFORM_MOVIE_INTERACTIVE`

> Similar to REQUEST_SCALEFORM_MOVIE, but seems to be some kind of "interactive" scaleform movie?
> 
> These seem to be the only scaleforms ever requested by this native:
> "breaking_news"
> "desktop_pc"
> "ECG_MONITOR"
> "Hacking_PC"
> "TEETH_PULLING"
> 
> Note: Unless this hash is out-of-order, this native is next-gen only.
> 

## REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN

```c
int REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN(const char* scaleformName)  // 0x65E7E78842E74CDB
```

build 372 · old names: `_REQUEST_SCALEFORM_MOVIE_2`

> Another REQUEST_SCALEFORM_MOVIE equivalent.

## REQUEST_SCALEFORM_SCRIPT_HUD_MOVIE

```c
void REQUEST_SCALEFORM_SCRIPT_HUD_MOVIE(int hudComponent)  // 0x9304881D6F6537EA
```

build 323 · old names: `_REQUEST_HUD_SCALEFORM`

## REQUEST_STREAMED_TEXTURE_DICT

```c
void REQUEST_STREAMED_TEXTURE_DICT(const char* textureDict, BOOL p1)  // 0xDFA2EF8E04127DD5
```

build 323

> This function can requests texture dictonaries from following RPFs:
> scaleform_generic.rpf
> scaleform_minigames.rpf
> scaleform_minimap.rpf
> scaleform_web.rpf
> 
> last param isnt a toggle

## RESET_ADAPTATION

```c
void RESET_ADAPTATION(int p0)  // 0xE3E2C1B4C59DBC77
```

build 323

> Sets an value related to timecycles.

## RESET_PARTICLE_FX_OVERRIDE

```c
void RESET_PARTICLE_FX_OVERRIDE(const char* name)  // 0x89C8553DD3274AAE
```

build 323 · old names: `_RESET_PARTICLE_FX_ASSET_OLD_TO_NEW`

> Resets the effect of SET_PARTICLE_FX_OVERRIDE
> 
> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## RESET_PAUSED_RENDERPHASES

```c
void RESET_PAUSED_RENDERPHASES()  // 0xE1C8709406F2C41C
```

build 323

## RESET_SCRIPT_GFX_ALIGN

```c
void RESET_SCRIPT_GFX_ALIGN()  // 0xE3A3DB414A373DAB
```

build 323 · old names: `_SCREEN_DRAW_POSITION_END`

> This function resets the alignment set using SET_SCRIPT_GFX_ALIGN and SET_SCRIPT_GFX_ALIGN_PARAMS to the default values ('I', 'I'; 0, 0, 0, 0).
> This should be used after having used the aforementioned functions in order to not affect any other scripts attempting to draw.

## SAVE_HIGH_QUALITY_PHOTO

```c
BOOL SAVE_HIGH_QUALITY_PHOTO(int unused)  // 0x3DEC726C25A11BAC
```

build 323

> 1 match in 1 script. cellphone_controller.
> p0 is -1 in scripts.

## SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL

```c
void SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL(BOOL value)  // 0xC58424BA936EB458
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_BOOL`, `_PUSH_SCALEFORM_MOVIE_METHOD_PARAMETER_BOOL`

> Pushes a boolean for the Scaleform function onto the stack.

## SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT

```c
void SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT(float value)  // 0xD69736AAE04DB51A
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT`, `_PUSH_SCALEFORM_MOVIE_METHOD_PARAMETER_FLOAT`

> Pushes a float for the Scaleform function onto the stack.

## SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT

```c
void SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT(int value)  // 0xC3D0841A0CC546A6
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT`, `_PUSH_SCALEFORM_MOVIE_METHOD_PARAMETER_INT`

> Pushes an integer for the Scaleform function onto the stack.

## SCALEFORM_MOVIE_METHOD_ADD_PARAM_LATEST_BRIEF_STRING

```c
void SCALEFORM_MOVIE_METHOD_ADD_PARAM_LATEST_BRIEF_STRING(int value)  // 0xEC52C631A1831C03
```

build 323 · old names: `_SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT_STRING`

## SCALEFORM_MOVIE_METHOD_ADD_PARAM_LITERAL_STRING

```c
void SCALEFORM_MOVIE_METHOD_ADD_PARAM_LITERAL_STRING(const char* string)  // 0x77FE3402004CD1B0
```

build 573 · old names: `_PUSH_SCALEFORM_MOVIE_METHOD_PARAMETER_STRING_2`, `_SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING_2`

> Same as SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING
> Both SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING / SCALEFORM_MOVIE_METHOD_ADD_PARAM_LITERAL_STRING works, but SCALEFORM_MOVIE_METHOD_ADD_PARAM_LITERAL_STRING is usually used for "name" (organisation, players..).

## SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING

```c
void SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING(const char* string)  // 0xE83A3E3557A56640
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_METHOD_PARAMETER_BUTTON_NAME`

## SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING

```c
void SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING(const char* string)  // 0xBA7148484BD90365
```

build 323 · old names: `_PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_STRING`, `_PUSH_SCALEFORM_MOVIE_METHOD_PARAMETER_STRING`

## SEETHROUGH_GET_MAX_THICKNESS

```c
float SEETHROUGH_GET_MAX_THICKNESS()  // 0x43DBAE39626CE83F
```

build 1290 · old names: `_SEETHROUGH_GET_MAX_THICKNESS`

## SEETHROUGH_RESET

```c
void SEETHROUGH_RESET()  // 0x70A64C0234EF522C
```

build 323

## SEETHROUGH_SET_COLOR_NEAR

```c
void SEETHROUGH_SET_COLOR_NEAR(int red, int green, int blue)  // 0x1086127B3A63505E
```

build 573 · old names: `_SEETHROUGH_SET_COLOR_NEAR`

## SEETHROUGH_SET_FADE_ENDDISTANCE

```c
void SEETHROUGH_SET_FADE_ENDDISTANCE(float distance)  // 0x9D75795B9DC6EBBF
```

build 573 · old names: `_SEETHROUGH_SET_FADE_END_DISTANCE`

## SEETHROUGH_SET_FADE_STARTDISTANCE

```c
void SEETHROUGH_SET_FADE_STARTDISTANCE(float distance)  // 0xA78DE25577300BA1
```

build 573 · old names: `_SEETHROUGH_SET_FADE_START_DISTANCE`

## SEETHROUGH_SET_HEATSCALE

```c
void SEETHROUGH_SET_HEATSCALE(int index, float heatScale)  // 0xD7D0B00177485411
```

build 323

> min: 0.0
> max: 0.75

## SEETHROUGH_SET_HIGHLIGHT_NOISE

```c
void SEETHROUGH_SET_HIGHLIGHT_NOISE(float noise)  // 0x1636D7FC127B10D2
```

build 573 · old names: `_SEETHROUGH_SET_HI_LIGHT_NOISE`

## SEETHROUGH_SET_HILIGHT_INTENSITY

```c
void SEETHROUGH_SET_HILIGHT_INTENSITY(float intensity)  // 0x19E50EB6E33E1D28
```

build 573 · old names: `_SEETHROUGH_SET_HI_LIGHT_INTENSITY`

## SEETHROUGH_SET_MAX_THICKNESS

```c
void SEETHROUGH_SET_MAX_THICKNESS(float thickness)  // 0x0C8FAC83902A62DF
```

build 573 · old names: `_SEETHROUGH_SET_MAX_THICKNESS`

> 0.0 = you will not be able to see people behind the walls. 50.0 and more = you will see everyone through the walls. More value is "better" view.
> min: 1.0
> max: 10000.0

## SEETHROUGH_SET_NOISE_MAX

```c
void SEETHROUGH_SET_NOISE_MAX(float amount)  // 0xFEBFBFDFB66039DE
```

build 573 · old names: `_SEETHROUGH_SET_NOISE_AMOUNT_MAX`

## SEETHROUGH_SET_NOISE_MIN

```c
void SEETHROUGH_SET_NOISE_MIN(float amount)  // 0xFF5992E1C9E65D05
```

build 573 · old names: `_SEETHROUGH_SET_NOISE_AMOUNT_MIN`

## SET_ARENA_THEME_AND_VARIATION_FOR_TAKEN_PHOTO

```c
void SET_ARENA_THEME_AND_VARIATION_FOR_TAKEN_PHOTO(Any p0, int p1)  // 0xF3F776ADA161E47D
```

build 1604

## SET_ARTIFICIAL_LIGHTS_STATE

```c
void SET_ARTIFICIAL_LIGHTS_STATE(BOOL state)  // 0x1268615ACE24D504
```

build 323 · old names: `_SET_BLACKOUT`

> Does not affect weapons, particles, fire/explosions, flashlights or the sun.
> When set to true, all emissive textures (including ped components that have light effects), street lights, building lights, vehicle lights, etc will all be turned off.
> 
> Used in Humane Labs Heist for EMP.
> 
> state: True turns off all artificial light sources in the map: buildings, street lights, car lights, etc. False turns them back on.

## SET_ARTIFICIAL_VEHICLE_LIGHTS_STATE

```c
void SET_ARTIFICIAL_VEHICLE_LIGHTS_STATE(BOOL toggle)  // 0xE2B187C0939B3D32
```

build 2060 · old names: `_SET_ARTIFICIAL_LIGHTS_STATE_AFFECTS_VEHICLES`

> If "blackout" is enabled, this native allows you to ignore "blackout" for vehicles.

## SET_BACKFACECULLING

```c
void SET_BACKFACECULLING(BOOL toggle)  // 0x23BA6B0C2AD7B0D3
```

build 323

## SET_BINK_MOVIE

```c
int SET_BINK_MOVIE(const char* name)  // 0x338D9F609FD632DB
```

build 1290 · old names: `_SET_BINK_MOVIE_REQUESTED`, `_SET_BINK_MOVIE`

## SET_BINK_MOVIE_AUDIO_FRONTEND

```c
void SET_BINK_MOVIE_AUDIO_FRONTEND(int binkMovie, BOOL p1)  // 0xF816F2933752322D
```

build 1868 · old names: `_SET_BINK_MOVIE_UNK_2`

## SET_BINK_MOVIE_TIME

```c
void SET_BINK_MOVIE_TIME(int binkMovie, float progress)  // 0x0CB6B3446855B57A
```

build 1290 · old names: `_SET_BINK_MOVIE_PROGRESS`, `_SET_BINK_MOVIE_TIME`

> In percentage: 0.0 - 100.0

## SET_BINK_MOVIE_VOLUME

```c
void SET_BINK_MOVIE_VOLUME(int binkMovie, float value)  // 0xAFF33B1178172223
```

build 1290 · old names: `_SET_BINK_MOVIE_UNK`, `_SET_BINK_MOVIE_VOLUME`

> binkMovie: Is return value from SET_BINK_MOVIE.

## SET_BINK_SHOULD_SKIP

```c
void SET_BINK_SHOULD_SKIP(int binkMovie, BOOL bShouldSkip)  // 0x6805D58CAA427B72
```

build 1290 · old names: `_SET_BINK_SHOULD_SKIP`

## SET_CHECKPOINT_CLIPPLANE_WITH_POS_NORM

```c
void SET_CHECKPOINT_CLIPPLANE_WITH_POS_NORM(int checkpoint, float posX, float posY, float posZ, float unkX, float unkY, float unkZ)  // 0xF51D36185993515D
```

build 323

## SET_CHECKPOINT_CYLINDER_HEIGHT

```c
void SET_CHECKPOINT_CYLINDER_HEIGHT(int checkpoint, float nearHeight, float farHeight, float radius)  // 0x2707AAE9D9297D89
```

build 323

> Sets the cylinder height of the checkpoint.
> 
> Parameters:
> * nearHeight - The height of the checkpoint when inside of the radius.
> * farHeight - The height of the checkpoint when outside of the radius.
> * radius - The radius of the checkpoint.

## SET_CHECKPOINT_DECAL_ROT_ALIGNED_TO_CAMERA_ROT

```c
void SET_CHECKPOINT_DECAL_ROT_ALIGNED_TO_CAMERA_ROT(int checkpoint)  // 0x615D3925E87A3B26
```

build 323

> Unknown. Called after creating a checkpoint (type: 51) in the creators.

## SET_CHECKPOINT_DIRECTION

```c
void SET_CHECKPOINT_DIRECTION(int checkpoint, float posX, float posY, float posZ)  // 0x3C788E7F6438754D
```

build 1180

## SET_CHECKPOINT_FORCE_DIRECTION

```c
void SET_CHECKPOINT_FORCE_DIRECTION(int checkpoint)  // 0xDB1EA9411C8911EC
```

build 1180

## SET_CHECKPOINT_FORCE_OLD_ARROW_POINTING

```c
void SET_CHECKPOINT_FORCE_OLD_ARROW_POINTING(int checkpoint)  // 0xFCF6788FC4860CD4
```

build 1734

## SET_CHECKPOINT_INSIDE_CYLINDER_HEIGHT_SCALE

```c
void SET_CHECKPOINT_INSIDE_CYLINDER_HEIGHT_SCALE(int checkpoint, float scale)  // 0x4B5B4DA5D79F1943
```

build 323 · old names: `_SET_CHECKPOINT_SCALE`

## SET_CHECKPOINT_INSIDE_CYLINDER_SCALE

```c
void SET_CHECKPOINT_INSIDE_CYLINDER_SCALE(int checkpoint, float scale)  // 0x44621483FF966526
```

build 877 · old names: `_SET_CHECKPOINT_ICON_SCALE`

## SET_CHECKPOINT_RGBA

```c
void SET_CHECKPOINT_RGBA(int checkpoint, int red, int green, int blue, int alpha)  // 0x7167371E8AD747F7
```

build 323

> Sets the checkpoint color.

## SET_CHECKPOINT_RGBA2

```c
void SET_CHECKPOINT_RGBA2(int checkpoint, int red, int green, int blue, int alpha)  // 0xB9EA40907C680580
```

build 323 · old names: `_SET_CHECKPOINT_ICON_RGBA`

> Sets the checkpoint icon color.

## SET_CURRENT_PLAYER_TCMODIFIER

```c
void SET_CURRENT_PLAYER_TCMODIFIER(const char* modifierName)  // 0xBBF327DED94E4DEB
```

build 323

## SET_DEBUG_LINES_AND_SPHERES_DRAWING_ACTIVE

```c
void SET_DEBUG_LINES_AND_SPHERES_DRAWING_ACTIVE(BOOL enabled)  // 0x175B6BFC15CDD0C5
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## SET_DECAL_BULLET_IMPACT_RANGE_SCALE

```c
void SET_DECAL_BULLET_IMPACT_RANGE_SCALE(float p0)  // 0x46D1A61A21F566FC
```

build 323

## SET_DEPTHWRITING

```c
void SET_DEPTHWRITING(BOOL toggle)  // 0xC5C8F970D4EDFF71
```

build 877

## SET_DISABLE_DECAL_RENDERING_THIS_FRAME

```c
void SET_DISABLE_DECAL_RENDERING_THIS_FRAME()  // 0x4B5CFC83122DF602
```

build 323

## SET_DISABLE_PETROL_DECALS_IGNITING_THIS_FRAME

```c
void SET_DISABLE_PETROL_DECALS_IGNITING_THIS_FRAME()  // 0xD9454B5752C857DC
```

build 323

## SET_DISABLE_PETROL_DECALS_RECYCLING_THIS_FRAME

```c
void SET_DISABLE_PETROL_DECALS_RECYCLING_THIS_FRAME()  // 0x27CFB1B1E078CB2D
```

build 323

## SET_DISTANCE_BLUR_STRENGTH_OVERRIDE

```c
void SET_DISTANCE_BLUR_STRENGTH_OVERRIDE(float p0)  // 0xE2892E7E55D7073A
```

build 323

## SET_DRAW_ORIGIN

```c
void SET_DRAW_ORIGIN(float x, float y, float z, BOOL p3)  // 0xAA0008F3BBB8F416
```

build 323

> Sets the on-screen drawing origin for draw-functions (which is normally x=0,y=0 in the upper left corner of the screen) to a world coordinate.
> From now on, the screen coordinate which displays the given world coordinate on the screen is seen as x=0,y=0.
> 
> Example in C#:
> Vector3 boneCoord = somePed.GetBoneCoord(Bone.SKEL_Head);
> Function.Call(Hash.SET_DRAW_ORIGIN, boneCoord.X, boneCoord.Y, boneCoord.Z, 0);
> Function.Call(Hash.DRAW_SPRITE, "helicopterhud", "hud_corner", -0.01, -0.015, 0.013, 0.013, 0.0, 255, 0, 0, 200);
> Function.Call(Hash.DRAW_SPRITE, "helicopterhud", "hud_corner", 0.01, -0.015, 0.013, 0.013, 90.0, 255, 0, 0, 200);
> Function.Call(Hash.DRAW_SPRITE, "helicopterhud", "hud_corner", -0.01, 0.015, 0.013, 0.013, 270.0, 255, 0, 0, 200);
> Function.Call(Hash.DRAW_SPRITE, "helicopterhud", "hud_corner", 0.01, 0.015, 0.013, 0.013, 180.0, 255, 0, 0, 200);
> Function.Call(Hash.CLEAR_DRAW_ORIGIN);
> 
> If the pedestrian starts walking around now, the sprites are always around her head, no matter where the head is displayed on the screen.
> 
> This function also effects the drawing of texts and other UI-elements.
> The effect can be reset by calling GRAPHICS::CLEAR_DRAW_ORIGIN().

## SET_ENTITY_ICON_COLOR

```c
void SET_ENTITY_ICON_COLOR(Entity entity, int red, int green, int blue, int alpha)  // 0x1D5F595CCAE2E238
```

build 323

## SET_ENTITY_ICON_VISIBILITY

```c
void SET_ENTITY_ICON_VISIBILITY(Entity entity, BOOL toggle)  // 0xE0E8BEECCA96BA31
```

build 323

## SET_EXPOSURETWEAK

```c
void SET_EXPOSURETWEAK(BOOL toggle)  // 0xEF398BEEE4EF45F9
```

build 323

## SET_EXTRA_TCMODIFIER

```c
void SET_EXTRA_TCMODIFIER(const char* modifierName)  // 0x5096FD9CCB49056D
```

build 323 · old names: `_SET_EXTRA_TIMECYCLE_MODIFIER`

> Full list of timecycle modifiers by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/timecycleModifiers.json

## SET_FLASH

```c
void SET_FLASH(float p0, float p1, float fadeIn, float duration, float fadeOut)  // 0x0AB84296FED9CFC6
```

build 323

> Purpose of p0 and p1 unknown.

## SET_FORCE_MOTIONBLUR

```c
void SET_FORCE_MOTIONBLUR(BOOL toggle)  // 0x6A51F78772175A51
```

build 1011

## SET_GRASS_CULL_SPHERE

```c
int SET_GRASS_CULL_SPHERE(float p0, float p1, float p2, float p3)  // 0xBE197EAA669238F4
```

build 323

> This function is hard-coded to always return 0.

## SET_HIDOF_OVERRIDE

```c
void SET_HIDOF_OVERRIDE(BOOL p0, BOOL p1, float nearplaneOut, float nearplaneIn, float farplaneOut, float farplaneIn)  // 0xBA3D65906822BED5
```

build 323 · old names: `_SET_HIDOF_ENV_BLUR_PARAMS`

## SET_LIGHT_OVERRIDE_MAX_INTENSITY_SCALE

```c
void SET_LIGHT_OVERRIDE_MAX_INTENSITY_SCALE(Any p0)  // 0x9641588DAB93B4B5
```

build 877

## SET_LOCK_ADAPTIVE_DOF_DISTANCE

```c
void SET_LOCK_ADAPTIVE_DOF_DISTANCE(BOOL p0)  // 0xB569F41F3E7E83A4
```

build 1103

## SET_MOTIONBLUR_MAX_VEL_SCALER

```c
void SET_MOTIONBLUR_MAX_VEL_SCALER(float p0)  // 0xB3C641F3630BF6DA
```

build 323

> Setter for GET_MOTIONBLUR_MAX_VEL_SCALER

## SET_NEXT_PLAYER_TCMODIFIER

```c
void SET_NEXT_PLAYER_TCMODIFIER(const char* modifierName)  // 0xBF59707B3E5ED531
```

build 323

## SET_NIGHTVISION

```c
void SET_NIGHTVISION(BOOL toggle)  // 0x18F621F7A5B1F85D
```

build 323

> Enables Night Vision.
> 
> Example:
> C#: Function.Call(Hash.SET_NIGHTVISION, true);
> C++: GRAPHICS::SET_NIGHTVISION(true);
> 
> BOOL toggle:
> true = turns night vision on for your player.
> false = turns night vision off for your player.

## SET_NOISEOVERIDE

```c
void SET_NOISEOVERIDE(BOOL toggle)  // 0xE787BF1C5CF823C9
```

build 323

## SET_NOISINESSOVERIDE

```c
void SET_NOISINESSOVERIDE(float value)  // 0xCB6A7C3BB17A0C67
```

build 323

## SET_ON_ISLAND_X_FOR_TAKEN_PHOTO

```c
void SET_ON_ISLAND_X_FOR_TAKEN_PHOTO(Any p0)  // 0xADD6627C4D325458
```

build 2189

## SET_PARTICLE_FX_BANG_SCRAPE_LODRANGE_SCALE

```c
void SET_PARTICLE_FX_BANG_SCRAPE_LODRANGE_SCALE(float p0)  // 0x54E22EA2C1956A8D
```

build 323

## SET_PARTICLE_FX_BLOOD_SCALE

```c
void SET_PARTICLE_FX_BLOOD_SCALE(Any p0)  // 0x908311265D42A820
```

build 323

## SET_PARTICLE_FX_BULLET_IMPACT_LODRANGE_SCALE

```c
void SET_PARTICLE_FX_BULLET_IMPACT_LODRANGE_SCALE(float p0)  // 0xBB90E12CAC1DAB25
```

build 323

## SET_PARTICLE_FX_BULLET_IMPACT_SCALE

```c
void SET_PARTICLE_FX_BULLET_IMPACT_SCALE(float scale)  // 0x27E32866E9A5C416
```

build 323

## SET_PARTICLE_FX_BULLET_TRACE_NO_ANGLE_REJECT

```c
void SET_PARTICLE_FX_BULLET_TRACE_NO_ANGLE_REJECT(BOOL p0)  // 0xCA4AE345A153D573
```

build 323

## SET_PARTICLE_FX_CAM_INSIDE_NONPLAYER_VEHICLE

```c
void SET_PARTICLE_FX_CAM_INSIDE_NONPLAYER_VEHICLE(Vehicle vehicle, BOOL p1)  // 0xACEE6F360FC1F6B6
```

build 323

## SET_PARTICLE_FX_CAM_INSIDE_VEHICLE

```c
void SET_PARTICLE_FX_CAM_INSIDE_VEHICLE(BOOL p0)  // 0xEEC4047028426510
```

build 323

## SET_PARTICLE_FX_FOOT_LODRANGE_SCALE

```c
void SET_PARTICLE_FX_FOOT_LODRANGE_SCALE(float p0)  // 0x949F397A288B28B3
```

build 323

## SET_PARTICLE_FX_FOOT_OVERRIDE_NAME

```c
void SET_PARTICLE_FX_FOOT_OVERRIDE_NAME(const char* p0)  // 0xBA3D194057C79A7B
```

build 877

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## SET_PARTICLE_FX_FORCE_VEHICLE_INTERIOR

```c
void SET_PARTICLE_FX_FORCE_VEHICLE_INTERIOR(BOOL toggle)  // 0x8CDE909A0370BB3A
```

build 323

> Used only once in the scripts (taxi_clowncar)

## SET_PARTICLE_FX_LOOPED_ALPHA

```c
void SET_PARTICLE_FX_LOOPED_ALPHA(int ptfxHandle, float alpha)  // 0x726845132380142E
```

build 323

## SET_PARTICLE_FX_LOOPED_COLOUR

```c
void SET_PARTICLE_FX_LOOPED_COLOUR(int ptfxHandle, float r, float g, float b, BOOL p4)  // 0x7F8F65877F88783B
```

build 323

> only works on some fx's
> 
> p4 = 0

## SET_PARTICLE_FX_LOOPED_EVOLUTION

```c
void SET_PARTICLE_FX_LOOPED_EVOLUTION(int ptfxHandle, const char* propertyName, float amount, BOOL noNetwork)  // 0x5F0C4B5B1C393BE2
```

build 323

## SET_PARTICLE_FX_LOOPED_FAR_CLIP_DIST

```c
void SET_PARTICLE_FX_LOOPED_FAR_CLIP_DIST(int ptfxHandle, float range)  // 0xDCB194B85EF7B541
```

build 323 · old names: `_SET_PARTICLE_FX_LOOPED_RANGE`

## SET_PARTICLE_FX_LOOPED_OFFSETS

```c
void SET_PARTICLE_FX_LOOPED_OFFSETS(int ptfxHandle, float x, float y, float z, float rotX, float rotY, float rotZ)  // 0xF7DDEBEC43483C43
```

build 323

## SET_PARTICLE_FX_LOOPED_SCALE

```c
void SET_PARTICLE_FX_LOOPED_SCALE(int ptfxHandle, float scale)  // 0xB44250AAA456492D
```

build 323

## SET_PARTICLE_FX_NON_LOOPED_ALPHA

```c
void SET_PARTICLE_FX_NON_LOOPED_ALPHA(float alpha)  // 0x77168D722C58B2FC
```

build 323

> Usage example for C#:
> 
> Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_ALPHA, new InputArgument[] { 0.1f });
> 
> Note: the argument alpha ranges from 0.0f-1.0f !

## SET_PARTICLE_FX_NON_LOOPED_COLOUR

```c
void SET_PARTICLE_FX_NON_LOOPED_COLOUR(float r, float g, float b)  // 0x26143A59EF48B262
```

build 323

> only works on some fx's, not networked

## SET_PARTICLE_FX_NON_LOOPED_EMITTER_SIZE

```c
void SET_PARTICLE_FX_NON_LOOPED_EMITTER_SIZE(float p0, float p1, float scale)  // 0x1E2E01C00837D26E
```

build 2699 · old names: `_SET_PARTICLE_FX_NON_LOOPED_EMITTER_SCALE`

## SET_PARTICLE_FX_NON_LOOPED_SCALE

```c
void SET_PARTICLE_FX_NON_LOOPED_SCALE(float scale)  // 0xB7EF5850C39FABCA
```

build 2802

## SET_PARTICLE_FX_OVERRIDE

```c
void SET_PARTICLE_FX_OVERRIDE(const char* oldAsset, const char* newAsset)  // 0xEA1E2D93F6F75ED9
```

build 323 · old names: `_SET_PTFX_ASSET_OLD_2_NEW`, `_SET_PARTICLE_FX_ASSET_OLD_TO_NEW`

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## SET_PARTICLE_FX_SHOOTOUT_BOAT

```c
void SET_PARTICLE_FX_SHOOTOUT_BOAT(Any p0)  // 0x96EF97DAEB89BEF5
```

build 323

## SET_PARTICLE_FX_SLIPSTREAM_LODRANGE_SCALE

```c
void SET_PARTICLE_FX_SLIPSTREAM_LODRANGE_SCALE(float scale)  // 0x2B40A97646381508
```

build 1011

## SET_PLAYER_TCMODIFIER_TRANSITION

```c
void SET_PLAYER_TCMODIFIER_TRANSITION(float value)  // 0xBDEB86F4D5809204
```

build 323

## SET_PTFX_FORCE_VEHICLE_INTERIOR_FLAG

```c
void SET_PTFX_FORCE_VEHICLE_INTERIOR_FLAG(Any p0)  // 0xC6730E0D14E50703
```

build 2545

## SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED

```c
void SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED(int* scaleformHandle)  // 0x1D132D614DD86811
```

build 323

## SET_SCALEFORM_MOVIE_TO_USE_LARGE_RT

```c
void SET_SCALEFORM_MOVIE_TO_USE_LARGE_RT(int scaleformHandle, BOOL toggle)  // 0x32F34FF7F617643B
```

build 573

## SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT

```c
void SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT(int scaleformHandle, BOOL toggle)  // 0xE6A9F00D4240B519
```

build 877 · old names: `_SET_SCALEFORM_FIT_RENDERTARGET`

> This native is used in some casino scripts to fit the scaleform in the rendertarget.

## SET_SCALEFORM_MOVIE_TO_USE_SYSTEM_TIME

```c
void SET_SCALEFORM_MOVIE_TO_USE_SYSTEM_TIME(int scaleform, BOOL toggle)  // 0x6D8EB211944DCE08
```

build 323

## SET_SCRIPT_GFX_ALIGN

```c
void SET_SCRIPT_GFX_ALIGN(int horizontalAlign, int verticalAlign)  // 0xB8A850F20A067EB6
```

build 323 · old names: `_SET_SCREEN_DRAW_POSITION`, `_SCREEN_DRAW_POSITION_BEGIN`

> horizontalAlign: The horizontal alignment. This can be 67 ('C'), 76 ('L'), or 82 ('R').
> verticalAlign: The vertical alignment. This can be 67 ('C'), 66 ('B'), or 84 ('T').
> 
> This function anchors script draws to a side of the safe zone. This needs to be called to make the interface independent of the player's safe zone configuration.
> 
> These values are equivalent to alignX and alignY in common:/data/ui/frontend.xml, which can be used as a baseline for default alignment.
> 
> Using any other value (including 0) will result in the safe zone not being taken into account for this draw. The canonical value for this is 'I' (73).
> 
> For example, you can use SET_SCRIPT_GFX_ALIGN(0, 84) to only scale on the Y axis (to the top), but not change the X axis.
> 
> To reset the value, use RESET_SCRIPT_GFX_ALIGN.

## SET_SCRIPT_GFX_ALIGN_PARAMS

```c
void SET_SCRIPT_GFX_ALIGN_PARAMS(float x, float y, float w, float h)  // 0xF5A2C681787E579D
```

build 323 · old names: `_SCREEN_DRAW_POSITION_RATIO`

> Sets the draw offset/calculated size for SET_SCRIPT_GFX_ALIGN. If using any alignment other than left/top, the game expects the width/height to be configured using this native in order to get a proper starting position for the draw command.

## SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU

```c
void SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU(BOOL toggle)  // 0xC6372ECD45D73BCD
```

build 323

> Sets a flag defining whether or not script draw commands should continue being drawn behind the pause menu. This is usually used for TV channels and other draw commands that are used with a world render target.

## SET_SCRIPT_GFX_DRAW_ORDER

```c
void SET_SCRIPT_GFX_DRAW_ORDER(int drawOrder)  // 0x61BB1D9B3A95D802
```

build 323 · old names: `_SET_2D_LAYER`, `_SET_UI_LAYER`

> Sets the draw order for script draw commands.
> 
> Examples from decompiled scripts:
> GRAPHICS::SET_SCRIPT_GFX_DRAW_ORDER(7);
> GRAPHICS::DRAW_RECT(0.5, 0.5, 3.0, 3.0, v_4, v_5, v_6, a_0._f172, 0);
> 
> GRAPHICS::SET_SCRIPT_GFX_DRAW_ORDER(1);
> GRAPHICS::DRAW_RECT(0.5, 0.5, 1.5, 1.5, 0, 0, 0, 255, 0);

## SET_SEETHROUGH

```c
void SET_SEETHROUGH(BOOL toggle)  // 0x7E08924259E08CE0
```

build 323

> Toggles Heatvision on/off.

## SET_SKIDMARK_RANGE_SCALE

```c
void SET_SKIDMARK_RANGE_SCALE(float scale)  // 0x5DBF05DB5926D089
```

build 1011

## SET_STREAMED_TEXTURE_DICT_AS_NO_LONGER_NEEDED

```c
void SET_STREAMED_TEXTURE_DICT_AS_NO_LONGER_NEEDED(const char* textureDict)  // 0xBE2CACCF5A8AA805
```

build 323

## SET_TAKEN_PHOTO_IS_MUGSHOT

```c
void SET_TAKEN_PHOTO_IS_MUGSHOT(BOOL toggle)  // 0x1BBC135A4D25EDDE
```

build 323

## SET_TIMECYCLE_MODIFIER

```c
void SET_TIMECYCLE_MODIFIER(const char* modifierName)  // 0x2C933ABF17A1DF41
```

build 323

> Loads the specified timecycle modifier. Modifiers are defined separately in another file (e.g. "timecycle_mods_1.xml")
> 
> Parameters:
> modifierName - The modifier to load (e.g. "V_FIB_IT3", "scanline_cam", etc.)
> 
> Full list of timecycle modifiers by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/timecycleModifiers.json

## SET_TIMECYCLE_MODIFIER_STRENGTH

```c
void SET_TIMECYCLE_MODIFIER_STRENGTH(float strength)  // 0x82E7FFCD5B2326B3
```

build 323

## SET_TRACKED_POINT_INFO

```c
void SET_TRACKED_POINT_INFO(int point, float x, float y, float z, float radius)  // 0x164ECBB3CF750CB0
```

build 323

## SET_TRANSITION_OUT_OF_TIMECYCLE_MODIFIER

```c
void SET_TRANSITION_OUT_OF_TIMECYCLE_MODIFIER(float strength)  // 0x1CBA05AE7BD7EE05
```

build 323 · old names: `_SET_TRANSITION_TIMECYCLE_MODIFIER_STOP_WITH_BLEND`

## SET_TRANSITION_TIMECYCLE_MODIFIER

```c
void SET_TRANSITION_TIMECYCLE_MODIFIER(const char* modifierName, float transition)  // 0x3BCF567485E1971C
```

build 323

> Full list of timecycle modifiers by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/timecycleModifiers.json

## SET_TV_AUDIO_FRONTEND

```c
void SET_TV_AUDIO_FRONTEND(BOOL toggle)  // 0x113D2C5DC57E1774
```

build 323

> Probably changes tvs from being a 3d audio to being "global" audio

## SET_TV_CHANNEL

```c
void SET_TV_CHANNEL(int channel)  // 0xBAABBB23EB6E484E
```

build 323

## SET_TV_CHANNEL_PLAYLIST

```c
void SET_TV_CHANNEL_PLAYLIST(int tvChannel, const char* playlistName, BOOL restart)  // 0xF7B38B8305F1FE8B
```

build 323 · old names: `_LOAD_TV_CHANNEL_SEQUENCE`

> Loads specified video sequence into the TV Channel
> TV_Channel ranges from 0-2
> VideoSequence can be any of the following:
> "PL_STD_CNT" CNT Standard Channel
> "PL_STD_WZL" Weazel Standard Channel
> "PL_LO_CNT"
> "PL_LO_WZL"
> "PL_SP_WORKOUT"
> "PL_SP_INV" - Jay Norris Assassination Mission Fail
> "PL_SP_INV_EXP" - Jay Norris Assassination Mission Success
> "PL_LO_RS" - Righteous Slaughter Ad
> "PL_LO_RS_CUTSCENE" - Righteous Slaughter Cut-scene
> "PL_SP_PLSH1_INTRO"
> "PL_LES1_FAME_OR_SHAME"
> "PL_STD_WZL_FOS_EP2"
> "PL_MP_WEAZEL" - Weazel Logo on loop
> "PL_MP_CCTV" - Generic CCTV loop
> 
> Restart:
> 0=video sequence continues as normal
> 1=sequence restarts from beginning every time that channel is selected
> 
> 
> The above playlists work as intended, and are commonly used, but there are many more playlists, as seen in `tvplaylists.xml`. A pastebin below outlines all playlists, they will be surronded by the name tag I.E. (<Name>PL_STD_CNT</Name> = PL_STD_CNT).
> https://pastebin.com/zUzGB6h7

## SET_TV_CHANNEL_PLAYLIST_AT_HOUR

```c
void SET_TV_CHANNEL_PLAYLIST_AT_HOUR(int tvChannel, const char* playlistName, int hour)  // 0x2201C576FACAEBE8
```

build 323

## SET_TV_PLAYER_WATCHING_THIS_FRAME

```c
void SET_TV_PLAYER_WATCHING_THIS_FRAME(Any p0)  // 0xD1C55B110E4DF534
```

build 323

## SET_TV_VOLUME

```c
void SET_TV_VOLUME(float volume)  // 0x2982BF73F66E9DDC
```

build 323

## SET_WEATHER_PTFX_OVERRIDE_CURR_LEVEL

```c
void SET_WEATHER_PTFX_OVERRIDE_CURR_LEVEL(float p0)  // 0xF78B803082D4386F
```

build 323

## SET_WEATHER_PTFX_USE_OVERRIDE_SETTINGS

```c
void SET_WEATHER_PTFX_USE_OVERRIDE_SETTINGS(BOOL p0)  // 0xA46B73FAA3460AE1
```

build 323

## START_NETWORKED_PARTICLE_FX_LOOPED_ON_ENTITY

```c
int START_NETWORKED_PARTICLE_FX_LOOPED_ON_ENTITY(const char* effectName, Entity entity, float xOffset, float yOffset, float zOffset, float xRot, float yRot, float zRot, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis, float r, float g, float b, float a)  // 0x6F60E89A7B64EE1D
```

build 323 · old names: `_START_PARTICLE_FX_LOOPED_ON_ENTITY_2`

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_NETWORKED_PARTICLE_FX_LOOPED_ON_ENTITY_BONE

```c
int START_NETWORKED_PARTICLE_FX_LOOPED_ON_ENTITY_BONE(const char* effectName, Entity entity, float xOffset, float yOffset, float zOffset, float xRot, float yRot, float zRot, int boneIndex, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis, float r, float g, float b, float a)  // 0xDDE23F30CC5A0F03
```

build 323 · old names: `_START_PARTICLE_FX_LOOPED_ON_ENTITY_BONE_2`

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_NETWORKED_PARTICLE_FX_NON_LOOPED_AT_COORD

```c
BOOL START_NETWORKED_PARTICLE_FX_NON_LOOPED_AT_COORD(const char* effectName, float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis, BOOL p11)  // 0xF56B8137DF10135D
```

build 323 · old names: `_START_PARTICLE_FX_NON_LOOPED_AT_COORD_2`

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_NETWORKED_PARTICLE_FX_NON_LOOPED_ON_ENTITY

```c
BOOL START_NETWORKED_PARTICLE_FX_NON_LOOPED_ON_ENTITY(const char* effectName, Entity entity, float offsetX, float offsetY, float offsetZ, float rotX, float rotY, float rotZ, float scale, BOOL axisX, BOOL axisY, BOOL axisZ)  // 0xC95EB1DB6E92113D
```

build 323 · old names: `_START_PARTICLE_FX_NON_LOOPED_ON_ENTITY_2`

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_NETWORKED_PARTICLE_FX_NON_LOOPED_ON_PED_BONE

```c
BOOL START_NETWORKED_PARTICLE_FX_NON_LOOPED_ON_PED_BONE(const char* effectName, Ped ped, float offsetX, float offsetY, float offsetZ, float rotX, float rotY, float rotZ, int boneIndex, float scale, BOOL axisX, BOOL axisY, BOOL axisZ)  // 0xA41B6A43642AC2CF
```

build 323 · old names: `_START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE_2`

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_PARTICLE_FX_LOOPED_AT_COORD

```c
int START_PARTICLE_FX_LOOPED_AT_COORD(const char* effectName, float x, float y, float z, float xRot, float yRot, float zRot, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis, BOOL p11)  // 0xE184F4F0DC5910E7
```

build 323

> GRAPHICS::START_PARTICLE_FX_LOOPED_AT_COORD("scr_fbi_falling_debris", 93.7743f, -749.4572f, 70.86904f, 0f, 0f, 0f, 0x3F800000, 0, 0, 0, 0)
> 
> 
> p11 seems to be always 0
> 
> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_PARTICLE_FX_LOOPED_ON_ENTITY

```c
int START_PARTICLE_FX_LOOPED_ON_ENTITY(const char* effectName, Entity entity, float xOffset, float yOffset, float zOffset, float xRot, float yRot, float zRot, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis)  // 0x1AE42C1660FD6517
```

build 323

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_PARTICLE_FX_LOOPED_ON_ENTITY_BONE

```c
int START_PARTICLE_FX_LOOPED_ON_ENTITY_BONE(const char* effectName, Entity entity, float xOffset, float yOffset, float zOffset, float xRot, float yRot, float zRot, int boneIndex, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis)  // 0xC6EB449E33977F0B
```

build 323

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_PARTICLE_FX_LOOPED_ON_PED_BONE

```c
int START_PARTICLE_FX_LOOPED_ON_PED_BONE(const char* effectName, Ped ped, float xOffset, float yOffset, float zOffset, float xRot, float yRot, float zRot, int boneIndex, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis)  // 0xF28DA9F38CD1787C
```

build 323

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_PARTICLE_FX_NON_LOOPED_AT_COORD

```c
BOOL START_PARTICLE_FX_NON_LOOPED_AT_COORD(const char* effectName, float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float scale, BOOL xAxis, BOOL yAxis, BOOL zAxis)  // 0x25129531F77B9ED3
```

build 323

> GRAPHICS::START_PARTICLE_FX_NON_LOOPED_AT_COORD("scr_paleto_roof_impact", -140.8576f, 6420.789f, 41.1391f, 0f, 0f, 267.3957f, 0x3F800000, 0, 0, 0);
> 
> Axis - Invert Axis Flags
> 
> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json
> 
> 
> -------------------------------------------------------------------
> C#
> 
> Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, = you are calling this function.
> 
> char *effectname = This is an in-game effect name, for e.g. "scr_fbi4_trucks_crash" is used to give the effects when truck crashes etc
> 
> float x, y, z pos = this one is Simple, you just have to declare, where do you want this effect to take place at, so declare the ordinates
> 
> float xrot, yrot, zrot = Again simple? just mention the value in case if you want the effect to rotate.
> 
> float scale = is declare the scale of the effect, this may vary as per the effects for e.g 1.0f
> 
> bool xaxis, yaxis, zaxis = To bool the axis values.
> 
> example:
> Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, "scr_fbi4_trucks_crash", GTA.Game.Player.Character.Position.X, GTA.Game.Player.Character.Position.Y, GTA.Game.Player.Character.Position.Z + 4f, 0, 0, 0, 5.5f, 0, 0, 0);

## START_PARTICLE_FX_NON_LOOPED_ON_ENTITY

```c
BOOL START_PARTICLE_FX_NON_LOOPED_ON_ENTITY(const char* effectName, Entity entity, float offsetX, float offsetY, float offsetZ, float rotX, float rotY, float rotZ, float scale, BOOL axisX, BOOL axisY, BOOL axisZ)  // 0x0D53A3B8DA0809D2
```

build 323

> Starts a particle effect on an entity for example your player.
> 
> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json
> 
> Example:
> C#:
> Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_rcbarry2");                     Function.Call(Hash.USE_PARTICLE_FX_ASSET, "scr_rcbarry2");                             Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_clown_appears", Game.Player.Character, 0.0, 0.0, -0.5, 0.0, 0.0, 0.0, 1.0, false, false, false);
> 
> Internally this calls the same function as GRAPHICS::START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE
> however it uses -1 for the specified bone index, so it should be possible to start a non looped fx on an entity bone using that native
> 
> -can confirm START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE does NOT work on vehicle bones.

## START_PARTICLE_FX_NON_LOOPED_ON_ENTITY_BONE

```c
BOOL START_PARTICLE_FX_NON_LOOPED_ON_ENTITY_BONE(const char* effectName, Entity entity, float offsetX, float offsetY, float offsetZ, float rotX, float rotY, float rotZ, int boneIndex, float scale, BOOL axisX, BOOL axisY, BOOL axisZ)  // 0x02B1F2A72E0F5325
```

build 2189 · old names: `_START_NETWORKED_PARTICLE_FX_NON_LOOPED_ON_ENTITY_BONE`

> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE

```c
BOOL START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE(const char* effectName, Ped ped, float offsetX, float offsetY, float offsetZ, float rotX, float rotY, float rotZ, int boneIndex, float scale, BOOL axisX, BOOL axisY, BOOL axisZ)  // 0x0E7E72961BA18619
```

build 323

> GRAPHICS::START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE("scr_sh_bong_smoke", PLAYER::PLAYER_PED_ID(), -0.025f, 0.13f, 0f, 0f, 0f, 0f, 31086, 0x3F800000, 0, 0, 0);
> 
> Axis - Invert Axis Flags
> 
> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## START_PETROL_TRAIL_DECALS

```c
void START_PETROL_TRAIL_DECALS(float p0)  // 0x99AC7F0D8B9C893D
```

build 323

## STOP_BINK_MOVIE

```c
void STOP_BINK_MOVIE(int binkMovie)  // 0x63606A61DE68898A
```

build 1290 · old names: `_STOP_BINK_MOVIE`

## STOP_PARTICLE_FX_LOOPED

```c
void STOP_PARTICLE_FX_LOOPED(int ptfxHandle, BOOL p1)  // 0x8F75998877616996
```

build 323

> p1 is always 0 in the native scripts

## TERRAINGRID_ACTIVATE

```c
void TERRAINGRID_ACTIVATE(BOOL toggle)  // 0xA356990E161C9E65
```

build 323

> This native enables/disables the gold putting grid display.
> This requires these two natives to be called as well to configure the grid: `TERRAINGRID_SET_PARAMS` and `TERRAINGRID_SET_COLOURS`.

## TERRAINGRID_SET_COLOURS

```c
void TERRAINGRID_SET_COLOURS(int lowR, int lowG, int lowB, int lowAlpha, int r, int g, int b, int alpha, int highR, int highG, int highB, int highAlpha)  // 0x5CE62918F8D703C7
```

build 323

> This native is used along with these two natives: `TERRAINGRID_ACTIVATE` and `TERRAINGRID_SET_PARAMS`.
> This native sets the colors for the golf putting grid. the 'min...' values are for the lower areas that the grid covers, the 'max...' values are for the higher areas that the grid covers, all remaining values are for the 'normal' ground height.

## TERRAINGRID_SET_PARAMS

```c
void TERRAINGRID_SET_PARAMS(float x, float y, float z, float forwardX, float forwardY, float forwardZ, float sizeX, float sizeY, float sizeZ, float gridScale, float glowIntensity, float normalHeight, float heightDiff)  // 0x1C4FC5752BCD8E48
```

build 323

> This native is used along with these two natives: `TERRAINGRID_ACTIVATE` and `TERRAINGRID_SET_COLOURS`.
> This native configures the location, size, rotation, normal height, and the difference ratio between min, normal and max.
> 
> This native renders a box at the given position, with a special shader that renders a grid on world geometry behind it. This box does not have backface culling.
> The forward args here are a direction vector, something similar to what's returned by GET_ENTITY_FORWARD_VECTOR.
> normalHeight and heightDiff are used for positioning the color gradient of the grid, colors specified via TERRAINGRID_SET_COLOURS.
> 
> Example with box superimposed on the image to demonstrate: https://i.imgur.com/wdqskxd.jpg

## TOGGLE_PAUSED_RENDERPHASES

```c
void TOGGLE_PAUSED_RENDERPHASES(BOOL toggle)  // 0xDFC252D8A3E15AB7
```

build 323 · old names: `_ENABLE_GAMEPLAY_CAM`, `_SET_FROZEN_RENDERING_DISABLED`

## TOGGLE_PLAYER_DAMAGE_OVERLAY

```c
void TOGGLE_PLAYER_DAMAGE_OVERLAY(BOOL toggle)  // 0xE63D7C6EECECB66B
```

build 323

## TRIGGER_SCREENBLUR_FADE_IN

```c
BOOL TRIGGER_SCREENBLUR_FADE_IN(float transitionTime)  // 0xA328A24AAA6B7FDC
```

build 323 · old names: `_TRANSITION_TO_BLURRED`

> time in ms to transition to fully blurred screen

## TRIGGER_SCREENBLUR_FADE_OUT

```c
BOOL TRIGGER_SCREENBLUR_FADE_OUT(float transitionTime)  // 0xEFACC8AEF94430D5
```

build 323 · old names: `_TRANSITION_FROM_BLURRED`

> time in ms to transition from fully blurred to normal

## UI3DSCENE_ASSIGN_PED_TO_SLOT

```c
BOOL UI3DSCENE_ASSIGN_PED_TO_SLOT(const char* presetName, Ped ped, int slot, float posX, float posY, float posZ)  // 0x98C4FE6EC34154CA
```

build 323

> It's called after UI3DSCENE_IS_AVAILABLE and UI3DSCENE_PUSH_PRESET
> 
> presetName was always "CELEBRATION_WINNER"
> All presets can be found in common\data\ui\uiscenes.meta

## UI3DSCENE_CLEAR_PATCHED_DATA

```c
void UI3DSCENE_CLEAR_PATCHED_DATA()  // 0x7A42B2E236E71415
```

build 323

## UI3DSCENE_IS_AVAILABLE

```c
BOOL UI3DSCENE_IS_AVAILABLE()  // 0xD3A10FC7FD8D98CD
```

build 323

## UI3DSCENE_MAKE_PUSHED_PRESET_PERSISTENT

```c
void UI3DSCENE_MAKE_PUSHED_PRESET_PERSISTENT(BOOL toggle)  // 0x108BE26959A9D9BB
```

build 323

## UI3DSCENE_PUSH_PRESET

```c
BOOL UI3DSCENE_PUSH_PRESET(const char* presetName)  // 0xF1CEA8A4198D8E9A
```

build 323

> All presets can be found in common\data\ui\uiscenes.meta

## UNPATCH_DECAL_DIFFUSE_MAP

```c
void UNPATCH_DECAL_DIFFUSE_MAP(int decalType)  // 0xB7ED70C49521A61D
```

build 323 · old names: `_UNDO_DECAL_TEXTURE_OVERRIDE`

## UPDATE_LIGHTS_ON_ENTITY

```c
void UPDATE_LIGHTS_ON_ENTITY(Entity entity)  // 0xDEADC0DEDEADC0DE
```

build 323 · old names: `_ENTITY_DESCRIPTION_TEXT`

## USE_PARTICLE_FX_ASSET

```c
void USE_PARTICLE_FX_ASSET(const char* name)  // 0x6C38AF3693A69A91
```

build 323 · old names: `_SET_PTFX_ASSET_NEXT_CALL`, `_USE_PARTICLE_FX_ASSET_NEXT_CALL`

> From the b678d decompiled scripts:
> 
>  GRAPHICS::USE_PARTICLE_FX_ASSET("FM_Mission_Controler");
>  GRAPHICS::USE_PARTICLE_FX_ASSET("scr_apartment_mp");
>  GRAPHICS::USE_PARTICLE_FX_ASSET("scr_indep_fireworks");
>  GRAPHICS::USE_PARTICLE_FX_ASSET("scr_mp_cig_plane");
>  GRAPHICS::USE_PARTICLE_FX_ASSET("scr_mp_creator");
>  GRAPHICS::USE_PARTICLE_FX_ASSET("scr_ornate_heist");
>  GRAPHICS::USE_PARTICLE_FX_ASSET("scr_prison_break_heist_station");
> 
> Full list of particle effect dictionaries and effects by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/particleEffectsCompact.json

## USE_SNOW_FOOT_VFX_WHEN_UNSHELTERED

```c
void USE_SNOW_FOOT_VFX_WHEN_UNSHELTERED(BOOL toggle)  // 0xAEEDAD1420C65CC0
```

build 323 · old names: `_SET_FORCE_PED_FOOTSTEPS_TRACKS`

> Forces footstep tracks on all surfaces.

## USE_SNOW_WHEEL_VFX_WHEN_UNSHELTERED

```c
void USE_SNOW_WHEEL_VFX_WHEN_UNSHELTERED(BOOL toggle)  // 0x4CC7F0FEA5283FE0
```

build 323 · old names: `_SET_FORCE_VEHICLE_TRAILS`

> Forces vehicle trails on all surfaces.

## WASH_DECALS_FROM_VEHICLE

```c
void WASH_DECALS_FROM_VEHICLE(Vehicle vehicle, float p1)  // 0x5B712761429DBC14
```

build 323

## WASH_DECALS_IN_RANGE

```c
void WASH_DECALS_IN_RANGE(float x, float y, float z, float range, float p4)  // 0x9C30613D50A6ADEF
```

build 323

## WATER_REFLECTION_SET_SCRIPT_OBJECT_VISIBILITY

```c
void WATER_REFLECTION_SET_SCRIPT_OBJECT_VISIBILITY(Any p0)  // 0xCA465D9CC0D231BA
```

build 1011

