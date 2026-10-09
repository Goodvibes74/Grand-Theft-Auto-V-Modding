# CAMERA natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _ACTIVATE_CAM_WITH_INTERP_AND_FOV_CURVE

```c
void _ACTIVATE_CAM_WITH_INTERP_AND_FOV_CURVE(Cam camTo, Cam camFrom, int duration, int easeLocation, int easeRotation, int easeFov)  // 0x34CFC4C2A38E83E3
```

build 3258

## _GET_THIRD_PERSON_CAM_MAX_ORBIT_DISTANCE_SPRING

```c
float _GET_THIRD_PERSON_CAM_MAX_ORBIT_DISTANCE_SPRING()  // 0xD4592A16D36673ED
```

build 3095

## _GET_THIRD_PERSON_CAM_MIN_ORBIT_DISTANCE_SPRING

```c
float _GET_THIRD_PERSON_CAM_MIN_ORBIT_DISTANCE_SPRING()  // 0xBC456FB703431785
```

build 3095

## ADD_CAM_SPLINE_NODE

```c
void ADD_CAM_SPLINE_NODE(Cam camera, float x, float y, float z, float xRot, float yRot, float zRot, int length, int smoothingStyle, int rotationOrder)  // 0x8609C75EC438FB3B
```

build 323

> I filled p1-p6 (the floats) as they are as other natives with 6 floats in a row are similar and I see no other method. So if a test from anyone proves them wrong please correct.
> 
> p7 (length) determines the length of the spline, affects camera path and duration of transition between previous node and this one
> 
> p8 big values ~100 will slow down the camera movement before reaching this node
> 
> p9 != 0 seems to override the rotation/pitch (bool?)

## ADD_CAM_SPLINE_NODE_USING_CAMERA

```c
void ADD_CAM_SPLINE_NODE_USING_CAMERA(Cam cam, Cam cam2, int length, int p3)  // 0x0FB82563989CF4FB
```

build 323

> p0 is the spline camera to which the node is being added.
> p1 is the camera used to create the node.
> p3 is always 3 in scripts. It might be smoothing style or rotation order.

## ADD_CAM_SPLINE_NODE_USING_CAMERA_FRAME

```c
void ADD_CAM_SPLINE_NODE_USING_CAMERA_FRAME(Cam cam, Cam cam2, int length, int p3)  // 0x0A9F2A468B328E74
```

build 323

> p0 is the spline camera to which the node is being added.
> p1 is the camera used to create the node.
> p3 is always 3 in scripts. It might be smoothing style or rotation order.

## ADD_CAM_SPLINE_NODE_USING_GAMEPLAY_FRAME

```c
void ADD_CAM_SPLINE_NODE_USING_GAMEPLAY_FRAME(Cam cam, int length, int p2)  // 0x609278246A29CA34
```

build 323

> p2 is always 2 in scripts. It might be smoothing style or rotation order.

## ALLOW_MOTION_BLUR_DECAY

```c
void ALLOW_MOTION_BLUR_DECAY(Any p0, BOOL p1)  // 0x271017B9BA825366
```

build 323

## ANIMATED_SHAKE_CAM

```c
void ANIMATED_SHAKE_CAM(Cam cam, const char* p1, const char* p2, const char* p3, float amplitude)  // 0xA2746EEAE3E577CD
```

build 323

> Example from michael2 script.
> 
> CAM::ANIMATED_SHAKE_CAM(l_5069, "shake_cam_all@", "light", "", 1f);

## ANIMATED_SHAKE_SCRIPT_GLOBAL

```c
void ANIMATED_SHAKE_SCRIPT_GLOBAL(const char* p0, const char* p1, const char* p2, float p3)  // 0xC2EAE3FB8CDBED31
```

build 323

> CAM::ANIMATED_SHAKE_SCRIPT_GLOBAL("SHAKE_CAM_medium", "medium", "", 0.5f);
> 
> Full list of cam shake types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/camShakeTypesCompact.json

## ARE_WIDESCREEN_BORDERS_ACTIVE

```c
BOOL ARE_WIDESCREEN_BORDERS_ACTIVE()  // 0x4879E4FE39074CDF
```

build 372

## ATTACH_CAM_TO_ENTITY

```c
void ATTACH_CAM_TO_ENTITY(Cam cam, Entity entity, float xOffset, float yOffset, float zOffset, BOOL isRelative)  // 0xFEDB7D269E8C60E3
```

build 323

> Last param determines if its relative to the Entity

## ATTACH_CAM_TO_PED_BONE

```c
void ATTACH_CAM_TO_PED_BONE(Cam cam, Ped ped, int boneIndex, float x, float y, float z, BOOL heading)  // 0x61A3DBA14AB7F411
```

build 323

## ATTACH_CAM_TO_VEHICLE_BONE

```c
void ATTACH_CAM_TO_VEHICLE_BONE(Cam cam, Vehicle vehicle, int boneIndex, BOOL relativeRotation, float rotX, float rotY, float rotZ, float offsetX, float offsetY, float offsetZ, BOOL fixedDirection)  // 0x8DB3F12A02CAEF72
```

build 1290 · old names: `_ATTACH_CAM_TO_VEHICLE_BONE`

> This native works with vehicles only. Bone indexes are usually given by this native GET_ENTITY_BONE_INDEX_BY_NAME.

## BLOCK_FIRST_PERSON_ORIENTATION_RESET_THIS_UPDATE

```c
void BLOCK_FIRST_PERSON_ORIENTATION_RESET_THIS_UPDATE()  // 0x9F97DA93681F87EA
```

build 1734

## BYPASS_CAMERA_COLLISION_BUOYANCY_TEST_THIS_UPDATE

```c
void BYPASS_CAMERA_COLLISION_BUOYANCY_TEST_THIS_UPDATE()  // 0xA7092AFE81944852
```

build 2189

## BYPASS_CUTSCENE_CAM_RENDERING_THIS_UPDATE

```c
void BYPASS_CUTSCENE_CAM_RENDERING_THIS_UPDATE()  // 0xDB629FFD9285FA06
```

build 323 · old names: `STOP_CUTSCENE_CAM_SHAKING`

## CAMERA_PREVENT_COLLISION_SETTINGS_FOR_TRIPLEHEAD_IN_INTERIORS_THIS_UPDATE

```c
void CAMERA_PREVENT_COLLISION_SETTINGS_FOR_TRIPLEHEAD_IN_INTERIORS_THIS_UPDATE()  // 0x62374889A4D59F72
```

build 877

## CREATE_CAM

```c
Cam CREATE_CAM(const char* camName, BOOL p1)  // 0xC3981DCE61D9E13F
```

build 323

> "DEFAULT_SCRIPTED_CAMERA"
> "DEFAULT_ANIMATED_CAMERA"
> "DEFAULT_SPLINE_CAMERA"
> "DEFAULT_SCRIPTED_FLY_CAMERA"
> "TIMED_SPLINE_CAMERA"

## CREATE_CAM_WITH_PARAMS

```c
Cam CREATE_CAM_WITH_PARAMS(const char* camName, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float fov, BOOL p8, int p9)  // 0xB51194800B257161
```

build 323

> camName is always set to "DEFAULT_SCRIPTED_CAMERA" in Rockstar's scripts.
> ------------
> Camera names found in the b617d scripts:
> "DEFAULT_ANIMATED_CAMERA"
> "DEFAULT_SCRIPTED_CAMERA"
> "DEFAULT_SCRIPTED_FLY_CAMERA"
> "DEFAULT_SPLINE_CAMERA"
> ------------
> Side Note: It seems p8 is basically to represent what would be the bool p1 within CREATE_CAM native. As well as the p9 since it's always 2 in scripts seems to represent what would be the last param within SET_CAM_ROT native which normally would be 2.

## CREATE_CAMERA

```c
Cam CREATE_CAMERA(Hash camHash, BOOL p1)  // 0x5E3CF89C6BCCA67D
```

build 323

## CREATE_CAMERA_WITH_PARAMS

```c
Cam CREATE_CAMERA_WITH_PARAMS(Hash camHash, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float fov, BOOL p8, Any p9)  // 0x6ABFA3E16460F22D
```

build 323

> p9 uses 2 by default

## CREATE_CINEMATIC_SHOT

```c
void CREATE_CINEMATIC_SHOT(Hash p0, int time, BOOL p2, Entity entity)  // 0x741B0129D4560F31
```

build 323

> hash is always JOAAT("CAMERA_MAN_SHOT") in decompiled scripts

## DESTROY_ALL_CAMS

```c
void DESTROY_ALL_CAMS(BOOL bScriptHostCam)  // 0x8E5FB15663F79120
```

build 323

> BOOL param indicates whether the cam should be destroyed if it belongs to the calling script.

## DESTROY_CAM

```c
void DESTROY_CAM(Cam cam, BOOL bScriptHostCam)  // 0x865908C81A2C22E9
```

build 323

> BOOL param indicates whether the cam should be destroyed if it belongs to the calling script.

## DETACH_CAM

```c
void DETACH_CAM(Cam cam)  // 0xA2FABBE87F4BAD82
```

build 323

## DISABLE_AIM_CAM_THIS_UPDATE

```c
void DISABLE_AIM_CAM_THIS_UPDATE()  // 0x1A31FE0049E542F6
```

build 323

## DISABLE_CAM_COLLISION_FOR_OBJECT

```c
void DISABLE_CAM_COLLISION_FOR_OBJECT(Entity entity)  // 0x49482F9FCD825AAA
```

build 323

## DISABLE_CINEMATIC_BONNET_CAMERA_THIS_UPDATE

```c
void DISABLE_CINEMATIC_BONNET_CAMERA_THIS_UPDATE()  // 0xADFF1B2A555F5FBA
```

build 323 · old names: `_DISABLE_VEHICLE_FIRST_PERSON_CAM_THIS_FRAME`

## DISABLE_CINEMATIC_SLOW_MO_THIS_UPDATE

```c
BOOL DISABLE_CINEMATIC_SLOW_MO_THIS_UPDATE()  // 0x17FCA7199A530203
```

build 323

## DISABLE_CINEMATIC_VEHICLE_IDLE_MODE_THIS_UPDATE

```c
void DISABLE_CINEMATIC_VEHICLE_IDLE_MODE_THIS_UPDATE()  // 0x62ECFCFDEE7885D6
```

build 323

## DISABLE_FIRST_PERSON_CAMERA_WATER_CLIPPING_TEST_THIS_UPDATE

```c
void DISABLE_FIRST_PERSON_CAMERA_WATER_CLIPPING_TEST_THIS_UPDATE()  // 0xB1381B97F70C7B30
```

build 1180

> Sets some flag on cinematic camera

## DISABLE_FIRST_PERSON_FLASH_EFFECT_THIS_UPDATE

```c
void DISABLE_FIRST_PERSON_FLASH_EFFECT_THIS_UPDATE()  // 0x59424BD75174C9B1
```

build 323

## DISABLE_GAMEPLAY_CAM_ALTITUDE_FOV_SCALING_THIS_UPDATE

```c
void DISABLE_GAMEPLAY_CAM_ALTITUDE_FOV_SCALING_THIS_UPDATE()  // 0xEA7F0AD7E9BA676F
```

build 323 · old names: `_ENABLE_CROSSHAIR_THIS_FRAME`

> Shows the crosshair even if it wouldn't show normally. Only works for one frame, so make sure to call it repeatedly.

## DISABLE_NEAR_CLIP_SCAN_THIS_UPDATE

```c
void DISABLE_NEAR_CLIP_SCAN_THIS_UPDATE()  // 0x5A43C76F7FC7BA5F
```

build 323

## DISABLE_ON_FOOT_FIRST_PERSON_VIEW_THIS_UPDATE

```c
void DISABLE_ON_FOOT_FIRST_PERSON_VIEW_THIS_UPDATE()  // 0xDE2EF5DA284CC8DF
```

build 323 · old names: `_DISABLE_FIRST_PERSON_CAM_THIS_FRAME`

> Disables first person camera for the current frame.
> 
> Found in decompiled scripts:
> GRAPHICS::DRAW_DEBUG_TEXT_2D("Disabling First Person Cam", 0.5, 0.8, 0.0, 0, 0, 255, 255);
> CAM::DISABLE_ON_FOOT_FIRST_PERSON_VIEW_THIS_UPDATE();

## DO_SCREEN_FADE_IN

```c
void DO_SCREEN_FADE_IN(int duration)  // 0xD4E8E24955024033
```

build 323

> Fades the screen in.
> 
> duration: The time the fade should take, in milliseconds.

## DO_SCREEN_FADE_OUT

```c
void DO_SCREEN_FADE_OUT(int duration)  // 0x891B5B39AC6302AF
```

build 323

> Fades the screen out.
> 
> duration: The time the fade should take, in milliseconds.

## DOES_CAM_EXIST

```c
BOOL DOES_CAM_EXIST(Cam cam)  // 0xA7A932170592B50E
```

build 323

> Returns whether or not the passed camera handle exists.

## FORCE_BONNET_CAMERA_RELATIVE_HEADING_AND_PITCH

```c
void FORCE_BONNET_CAMERA_RELATIVE_HEADING_AND_PITCH(float p0, float p1)  // 0x28B022A17B068A3A
```

build 1734

## FORCE_CAM_FAR_CLIP

```c
void FORCE_CAM_FAR_CLIP(Cam cam, float p1)  // 0xAABD62873FFB1A33
```

build 2189

## FORCE_CAMERA_RELATIVE_HEADING_AND_PITCH

```c
void FORCE_CAMERA_RELATIVE_HEADING_AND_PITCH(float roll, float pitch, float yaw)  // 0x48608C3464F58AB4
```

build 505 · old names: `_SET_GAMEPLAY_CAM_RELATIVE_ROTATION`

## FORCE_CINEMATIC_RENDERING_THIS_UPDATE

```c
void FORCE_CINEMATIC_RENDERING_THIS_UPDATE(BOOL toggle)  // 0xA41BCD7213805AAC
```

build 323

## FORCE_TIGHTSPACE_CUSTOM_FRAMING_THIS_UPDATE

```c
void FORCE_TIGHTSPACE_CUSTOM_FRAMING_THIS_UPDATE()  // 0x380B4968D1E09E55
```

build 1290

## FORCE_VEHICLE_CAM_STUNT_SETTINGS_THIS_UPDATE

```c
void FORCE_VEHICLE_CAM_STUNT_SETTINGS_THIS_UPDATE()  // 0x0AA27680A0BD43FA
```

build 1103

## GET_CAM_ACTIVE_VIEW_MODE_CONTEXT

```c
int GET_CAM_ACTIVE_VIEW_MODE_CONTEXT()  // 0x19CAFA3C87F7C2FF
```

build 323 · old names: `_GET_CAM_ACTIVE_VIEW_MODE_CONTEXT`

> enum camControlHelperMetadataViewMode__eViewModeContext
> {
> 	ON_FOOT,
> 	IN_VEHICLE,
> 	ON_BIKE,
> 	IN_BOAT,
> 	IN_AIRCRAFT,
> 	IN_SUBMARINE,
> 	IN_HELI,
> 	IN_TURRET
> };

## GET_CAM_ANIM_CURRENT_PHASE

```c
float GET_CAM_ANIM_CURRENT_PHASE(Cam cam)  // 0xA10B2DB49E92A6B0
```

build 323

## GET_CAM_COORD

```c
Vector3 GET_CAM_COORD(Cam cam)  // 0xBAC038F7459AE5AE
```

build 323

## GET_CAM_DOF_STRENGTH

```c
float GET_CAM_DOF_STRENGTH(Cam cam)  // 0x06D153C0B99B6128
```

build 2699 · old names: `_GET_CAM_DOF_STRENGTH`

## GET_CAM_FAR_CLIP

```c
float GET_CAM_FAR_CLIP(Cam cam)  // 0xB60A9CFEB21CA6AA
```

build 323

## GET_CAM_FAR_DOF

```c
float GET_CAM_FAR_DOF(Cam cam)  // 0x255F8DAFD540D397
```

build 323

## GET_CAM_FOV

```c
float GET_CAM_FOV(Cam cam)  // 0xC3330A45CCCDB26A
```

build 323

## GET_CAM_NEAR_CLIP

```c
float GET_CAM_NEAR_CLIP(Cam cam)  // 0xC520A34DAFBF24B1
```

build 323

## GET_CAM_NEAR_DOF

```c
float GET_CAM_NEAR_DOF(Cam cam)  // 0xC2612D223D915A1C
```

build 2699 · old names: `_GET_CAM_NEAR_DOF`

## GET_CAM_ROT

```c
Vector3 GET_CAM_ROT(Cam cam, int rotationOrder)  // 0x7D304C1C955E3E12
```

build 323

> The last parameter, as in other "ROT" methods, is usually 2.

## GET_CAM_SPLINE_NODE_INDEX

```c
int GET_CAM_SPLINE_NODE_INDEX(Cam cam)  // 0xB22B17DF858716A6
```

build 323

## GET_CAM_SPLINE_NODE_PHASE

```c
float GET_CAM_SPLINE_NODE_PHASE(Cam cam)  // 0xD9D0E694C8282C96
```

build 323

> I'm pretty sure the parameter is the camera as usual, but I am not certain so I'm going to leave it as is.

## GET_CAM_SPLINE_PHASE

```c
float GET_CAM_SPLINE_PHASE(Cam cam)  // 0xB5349E36C546509A
```

build 323

> Can use this with SET_CAM_SPLINE_PHASE to set the float it this native returns.
> 
> (returns 1.0f when no nodes has been added, reached end of non existing spline)

## GET_CAM_VIEW_MODE_FOR_CONTEXT

```c
int GET_CAM_VIEW_MODE_FOR_CONTEXT(int context)  // 0xEE778F8C7E1142E2
```

build 323

> context: see GET_CAM_ACTIVE_VIEW_MODE_CONTEXT

## GET_DEBUG_CAM

```c
Cam GET_DEBUG_CAM()  // 0x77C3CEC46BE286F6
```

build 2372 · old names: `_GET_DEBUG_CAMERA`

## GET_FINAL_RENDERED_CAM_COORD

```c
Vector3 GET_FINAL_RENDERED_CAM_COORD()  // 0xA200EB1EE790F448
```

build 323 · old names: `_GET_GAMEPLAY_CAM_COORDS`

## GET_FINAL_RENDERED_CAM_FAR_CLIP

```c
float GET_FINAL_RENDERED_CAM_FAR_CLIP()  // 0xDFC8CBC606FDB0FC
```

build 323 · old names: `_GET_GAMEPLAY_CAM_FAR_CLIP`

## GET_FINAL_RENDERED_CAM_FAR_DOF

```c
float GET_FINAL_RENDERED_CAM_FAR_DOF()  // 0x9780F32BCAF72431
```

build 323 · old names: `_GET_GAMEPLAY_CAM_FAR_DOF`

## GET_FINAL_RENDERED_CAM_FOV

```c
float GET_FINAL_RENDERED_CAM_FOV()  // 0x80EC114669DAEFF4
```

build 323

> Gets some camera fov

## GET_FINAL_RENDERED_CAM_MOTION_BLUR_STRENGTH

```c
float GET_FINAL_RENDERED_CAM_MOTION_BLUR_STRENGTH()  // 0x162F9D995753DC19
```

build 323 · old names: `_GET_GAMEPLAY_CAM_FAR_CLIP_2`

## GET_FINAL_RENDERED_CAM_NEAR_CLIP

```c
float GET_FINAL_RENDERED_CAM_NEAR_CLIP()  // 0xD0082607100D7193
```

build 323 · old names: `_GET_GAMEPLAY_CAM_NEAR_CLIP`

## GET_FINAL_RENDERED_CAM_NEAR_DOF

```c
float GET_FINAL_RENDERED_CAM_NEAR_DOF()  // 0xA03502FC581F7D9B
```

build 323 · old names: `_GET_GAMEPLAY_CAM_NEAR_DOF`

## GET_FINAL_RENDERED_CAM_ROT

```c
Vector3 GET_FINAL_RENDERED_CAM_ROT(int rotationOrder)  // 0x5B4E4C817FCC2DFB
```

build 323 · old names: `_GET_GAMEPLAY_CAM_ROT_2`

> p0 seems to consistently be 2 across scripts
> 
> Function is called faily often by CAM::CREATE_CAM_WITH_PARAMS

## GET_FINAL_RENDERED_REMOTE_PLAYER_CAM_FOV

```c
float GET_FINAL_RENDERED_REMOTE_PLAYER_CAM_FOV(Player player)  // 0x5F35F6732C3FBBA0
```

build 323 · old names: `GET_FINAL_RENDERED_IN_WHEN_FRIENDLY_FOV`

## GET_FINAL_RENDERED_REMOTE_PLAYER_CAM_ROT

```c
Vector3 GET_FINAL_RENDERED_REMOTE_PLAYER_CAM_ROT(Player player, int rotationOrder)  // 0x26903D9CD1175F2C
```

build 323 · old names: `GET_FINAL_RENDERED_IN_WHEN_FRIENDLY_ROT`

## GET_FIRST_PERSON_AIM_CAM_ZOOM_FACTOR

```c
float GET_FIRST_PERSON_AIM_CAM_ZOOM_FACTOR()  // 0x7EC52CC40597D170
```

build 323 · old names: `_GET_GAMEPLAY_CAM_ZOOM`

## GET_FOCUS_PED_ON_SCREEN

```c
Ped GET_FOCUS_PED_ON_SCREEN(float p0, int p1, float p2, float p3, float p4, float p5, float p6, int p7, int p8)  // 0x89215EC747DF244A
```

build 323

## GET_FOLLOW_PED_CAM_VIEW_MODE

```c
int GET_FOLLOW_PED_CAM_VIEW_MODE()  // 0x8D4D46230B2C353A
```

build 323

> See viewmode enum in CAM.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE for return value

## GET_FOLLOW_PED_CAM_ZOOM_LEVEL

```c
int GET_FOLLOW_PED_CAM_ZOOM_LEVEL()  // 0x33E6C8EFD0CD93E9
```

build 323

## GET_FOLLOW_VEHICLE_CAM_VIEW_MODE

```c
int GET_FOLLOW_VEHICLE_CAM_VIEW_MODE()  // 0xA4FF579AC0E3AAAE
```

build 323

> Returns the type of camera:
> 
> enum camControlHelperMetadataViewMode__eViewMode
> {
> 	THIRD_PERSON_NEAR = 0,
> 	THIRD_PERSON_MEDIUM = 1,
> 	THIRD_PERSON_FAR = 2,
> 	CINEMATIC = 3,
> 	FIRST_PERSON = 4
> };

## GET_FOLLOW_VEHICLE_CAM_ZOOM_LEVEL

```c
int GET_FOLLOW_VEHICLE_CAM_ZOOM_LEVEL()  // 0xEE82280AB767B690
```

build 323

## GET_GAMEPLAY_CAM_COORD

```c
Vector3 GET_GAMEPLAY_CAM_COORD()  // 0x14D6F5678D8F1B37
```

build 323

## GET_GAMEPLAY_CAM_FOV

```c
float GET_GAMEPLAY_CAM_FOV()  // 0x65019750A0324133
```

build 323

## GET_GAMEPLAY_CAM_RELATIVE_HEADING

```c
float GET_GAMEPLAY_CAM_RELATIVE_HEADING()  // 0x743607648ADD4587
```

build 323

## GET_GAMEPLAY_CAM_RELATIVE_PITCH

```c
float GET_GAMEPLAY_CAM_RELATIVE_PITCH()  // 0x3A6867B4845BEDA2
```

build 323

## GET_GAMEPLAY_CAM_ROT

```c
Vector3 GET_GAMEPLAY_CAM_ROT(int rotationOrder)  // 0x837765A25378F0BB
```

build 323

> p0 dosen't seem to change much, I tried it with 0, 1, 2:
> 0-Pitch(X): -70.000092
> 0-Roll(Y): -0.000001
> 0-Yaw(Z): -43.886459
> 1-Pitch(X): -70.000092
> 1-Roll(Y): -0.000001
> 1-Yaw(Z): -43.886463
> 2-Pitch(X): -70.000092
> 2-Roll(Y): -0.000002
> 2-Yaw(Z): -43.886467

## GET_RENDERING_CAM

```c
Cam GET_RENDERING_CAM()  // 0x5234F9F10919EABA
```

build 323

## HARD_ATTACH_CAM_TO_ENTITY

```c
void HARD_ATTACH_CAM_TO_ENTITY(Cam cam, Entity entity, float xRot, float yRot, float zRot, float xOffset, float yOffset, float zOffset, BOOL isRelative)  // 0x202A5ED9CE01D6E7
```

build 2189 · old names: `_ATTACH_CAM_TO_ENTITY_WITH_FIXED_DIRECTION`

> Example from am_mp_drone script: 
> 
> CAM::HARD_ATTACH_CAM_TO_ENTITY(Local_190.f_169, NETWORK::NET_TO_OBJ(Local_190.f_159), 0f, 0f, 180f, Var0, 1);

## HARD_ATTACH_CAM_TO_PED_BONE

```c
void HARD_ATTACH_CAM_TO_PED_BONE(Cam cam, Ped ped, int boneIndex, float p3, float p4, float p5, float p6, float p7, float p8, BOOL p9)  // 0x149916F50C34A40D
```

build 1180 · old names: `_ATTACH_CAM_TO_PED_BONE_2`

## IGNORE_MENU_PREFERENCE_FOR_BONNET_CAMERA_THIS_UPDATE

```c
void IGNORE_MENU_PREFERENCE_FOR_BONNET_CAMERA_THIS_UPDATE()  // 0x7B8A361C1813FBEF
```

build 573

## INTERPOLATE_CAMERA_WITH_PARAMS

```c
void INTERPOLATE_CAMERA_WITH_PARAMS(Cam camera, float camPosX, float camPosY, float camPosZ, float camRotX, float camRotY, float camRotZ, float fov, int duration, int posCurveType, int rotCurveType, int rotOrder, int fovCurveType)  // 0xDDA77EE33C005AAF
```

build 3258 · old names: `_INTERPOLATE_CAM_WITH_PARAMS`

## INVALIDATE_CINEMATIC_VEHICLE_IDLE_MODE

```c
void INVALIDATE_CINEMATIC_VEHICLE_IDLE_MODE()  // 0x9E4CFFF989258472
```

build 323 · old names: `_INVALIDATE_VEHICLE_IDLE_CAM`

> Resets the vehicle idle camera timer. Calling this in a loop will disable the idle camera.

## INVALIDATE_IDLE_CAM

```c
void INVALIDATE_IDLE_CAM()  // 0xF4F2C0D4EE209E20
```

build 323

> Resets the idle camera timer. Calling that in a loop once every few seconds is enough to disable the idle cinematic camera.

## IS_AIM_CAM_ACTIVE

```c
BOOL IS_AIM_CAM_ACTIVE()  // 0x68EDDA28A5976D07
```

build 323

## IS_AIM_CAM_ACTIVE_IN_ACCURATE_MODE

```c
BOOL IS_AIM_CAM_ACTIVE_IN_ACCURATE_MODE()  // 0x74BD83EA840F6BC9
```

build 323 · old names: `_IS_AIM_CAM_THIRD_PERSON_ACTIVE`

## IS_ALLOWED_INDEPENDENT_CAMERA_MODES

```c
BOOL IS_ALLOWED_INDEPENDENT_CAMERA_MODES()  // 0xEAF0FA793D05C592
```

build 323

## IS_BONNET_CINEMATIC_CAM_RENDERING

```c
BOOL IS_BONNET_CINEMATIC_CAM_RENDERING()  // 0xD7360051C885628B
```

build 372

## IS_CAM_ACTIVE

```c
BOOL IS_CAM_ACTIVE(Cam cam)  // 0xDFB2B516207D3534
```

build 323

> Returns whether or not the passed camera handle is active.

## IS_CAM_INTERPOLATING

```c
BOOL IS_CAM_INTERPOLATING(Cam cam)  // 0x036F97C908C2B52C
```

build 323

## IS_CAM_PLAYING_ANIM

```c
BOOL IS_CAM_PLAYING_ANIM(Cam cam, const char* animName, const char* animDictionary)  // 0xC90621D8A0CEECF2
```

build 323

## IS_CAM_RENDERING

```c
BOOL IS_CAM_RENDERING(Cam cam)  // 0x02EC0AF5C5A49B7A
```

build 323

## IS_CAM_SHAKING

```c
BOOL IS_CAM_SHAKING(Cam cam)  // 0x6B24BFE83A2BE47B
```

build 323

## IS_CAM_SPLINE_PAUSED

```c
BOOL IS_CAM_SPLINE_PAUSED(Cam cam)  // 0x0290F35C0AD97864
```

build 323

## IS_CINEMATIC_CAM_INPUT_ACTIVE

```c
BOOL IS_CINEMATIC_CAM_INPUT_ACTIVE()  // 0xF5F1E89A970B7796
```

build 1493 · old names: `_IS_CINEMATIC_CAM_ACTIVE`

> Tests some cinematic camera flags

## IS_CINEMATIC_CAM_RENDERING

```c
BOOL IS_CINEMATIC_CAM_RENDERING()  // 0xB15162CB5826E9E8
```

build 323

## IS_CINEMATIC_CAM_SHAKING

```c
BOOL IS_CINEMATIC_CAM_SHAKING()  // 0xBBC08F6B4CB8FF0A
```

build 323

## IS_CINEMATIC_FIRST_PERSON_VEHICLE_INTERIOR_CAM_RENDERING

```c
BOOL IS_CINEMATIC_FIRST_PERSON_VEHICLE_INTERIOR_CAM_RENDERING()  // 0x4F32C0D5A90A9B40
```

build 323 · old names: `_IS_IN_VEHICLE_CAM_DISABLED`

## IS_CINEMATIC_IDLE_CAM_RENDERING

```c
BOOL IS_CINEMATIC_IDLE_CAM_RENDERING()  // 0xCA9D2AA3E326D720
```

build 323

## IS_CINEMATIC_SHOT_ACTIVE

```c
BOOL IS_CINEMATIC_SHOT_ACTIVE(Hash p0)  // 0xCC9F3371A7C28BC9
```

build 323

> Hash is always JOAAT("CAMERA_MAN_SHOT") in decompiled scripts

## IS_CODE_GAMEPLAY_HINT_ACTIVE

```c
BOOL IS_CODE_GAMEPLAY_HINT_ACTIVE()  // 0xBF72910D0F26F025
```

build 323

## IS_FIRST_PERSON_AIM_CAM_ACTIVE

```c
BOOL IS_FIRST_PERSON_AIM_CAM_ACTIVE()  // 0x5E346D934122613F
```

build 323

## IS_FOLLOW_PED_CAM_ACTIVE

```c
BOOL IS_FOLLOW_PED_CAM_ACTIVE()  // 0xC6D3D26810C8E0F9
```

build 323

## IS_FOLLOW_VEHICLE_CAM_ACTIVE

```c
BOOL IS_FOLLOW_VEHICLE_CAM_ACTIVE()  // 0xCBBDE6D335D6D496
```

build 323

## IS_GAMEPLAY_CAM_LOOKING_BEHIND

```c
BOOL IS_GAMEPLAY_CAM_LOOKING_BEHIND()  // 0x70FDA869F3317EA9
```

build 323

## IS_GAMEPLAY_CAM_RENDERING

```c
BOOL IS_GAMEPLAY_CAM_RENDERING()  // 0x39B5D1B10383F0C8
```

build 323

> Examples when this function will return 0 are:
> - During busted screen.
> - When player is coming out from a hospital.
> - When player is coming out from a police station.
> - When player is buying gun from AmmuNation.

## IS_GAMEPLAY_CAM_SHAKING

```c
BOOL IS_GAMEPLAY_CAM_SHAKING()  // 0x016C090630DF1F89
```

build 323

## IS_GAMEPLAY_HINT_ACTIVE

```c
BOOL IS_GAMEPLAY_HINT_ACTIVE()  // 0xE520FF1AD2785B40
```

build 323

## IS_IN_VEHICLE_MOBILE_PHONE_CAMERA_RENDERING

```c
BOOL IS_IN_VEHICLE_MOBILE_PHONE_CAMERA_RENDERING()  // 0x1F2300CB7FA7B7F6
```

build 323

## IS_INTERPOLATING_FROM_SCRIPT_CAMS

```c
BOOL IS_INTERPOLATING_FROM_SCRIPT_CAMS()  // 0x3044240D2E0FA842
```

build 323

## IS_INTERPOLATING_TO_SCRIPT_CAMS

```c
BOOL IS_INTERPOLATING_TO_SCRIPT_CAMS()  // 0x705A276EBFF3133D
```

build 323

## IS_SCREEN_FADED_IN

```c
BOOL IS_SCREEN_FADED_IN()  // 0x5A859503B0C08678
```

build 323

## IS_SCREEN_FADED_OUT

```c
BOOL IS_SCREEN_FADED_OUT()  // 0xB16FCE9DDC7BA182
```

build 323

## IS_SCREEN_FADING_IN

```c
BOOL IS_SCREEN_FADING_IN()  // 0x5C544BC6C57AC575
```

build 323

## IS_SCREEN_FADING_OUT

```c
BOOL IS_SCREEN_FADING_OUT()  // 0x797AC7CB535BA28F
```

build 323

## IS_SCRIPT_GLOBAL_SHAKING

```c
BOOL IS_SCRIPT_GLOBAL_SHAKING()  // 0xC912AF078AF19212
```

build 323

> In drunk_controller.c4, sub_309
> if (CAM::IS_SCRIPT_GLOBAL_SHAKING()) {
>     CAM::STOP_SCRIPT_GLOBAL_SHAKING(0);
> }

## IS_SPHERE_VISIBLE

```c
BOOL IS_SPHERE_VISIBLE(float x, float y, float z, float radius)  // 0xE33D59DA70B58FDF
```

build 323

## OVERRIDE_CAM_SPLINE_MOTION_BLUR

```c
void OVERRIDE_CAM_SPLINE_MOTION_BLUR(Cam cam, int p1, float p2, float p3)  // 0x7DCF7C708D292D55
```

build 323

> Max value for p1 is 15.

## OVERRIDE_CAM_SPLINE_VELOCITY

```c
void OVERRIDE_CAM_SPLINE_VELOCITY(Cam cam, int p1, float p2, float p3)  // 0x40B62FA033EB0346
```

build 323

## PLAY_CAM_ANIM

```c
BOOL PLAY_CAM_ANIM(Cam cam, const char* animName, const char* animDictionary, float x, float y, float z, float xRot, float yRot, float zRot, BOOL p9, int p10)  // 0x9A2D0FB2E7852392
```

build 323

> Atleast one time in a script for the zRot Rockstar uses GET_ENTITY_HEADING to help fill the parameter.
> 
> p9 is unknown at this time.
> p10 throughout all the X360 Scripts is always 2.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## PLAY_SYNCHRONIZED_CAM_ANIM

```c
BOOL PLAY_SYNCHRONIZED_CAM_ANIM(Any p0, Any p1, const char* animName, const char* animDictionary)  // 0xE32EFE9AB4A9AA0C
```

build 323

> Examples:
> 
> CAM::PLAY_SYNCHRONIZED_CAM_ANIM(l_2734, NETWORK::NETWORK_GET_LOCAL_SCENE_FROM_NETWORK_ID(l_2739), "PLAYER_EXIT_L_CAM", "mp_doorbell");
> 
> CAM::PLAY_SYNCHRONIZED_CAM_ANIM(l_F0D[7/*1*/], l_F4D[15/*1*/], "ah3b_attackheli_cam2", "missheistfbi3b_helicrash");

## POINT_CAM_AT_COORD

```c
void POINT_CAM_AT_COORD(Cam cam, float x, float y, float z)  // 0xF75497BB865F0803
```

build 323

## POINT_CAM_AT_ENTITY

```c
void POINT_CAM_AT_ENTITY(Cam cam, Entity entity, float p2, float p3, float p4, BOOL p5)  // 0x5640BFF86B16E8DC
```

build 323

> p5 always seems to be 1 i.e TRUE

## POINT_CAM_AT_PED_BONE

```c
void POINT_CAM_AT_PED_BONE(Cam cam, Ped ped, int boneIndex, float x, float y, float z, BOOL p6)  // 0x68B2B5F33BA63C41
```

build 323

> Parameters p0-p5 seems correct. The bool p6 is unknown, but through every X360 script it's always 1. Please correct p0-p5 if any prove to be wrong. 

## RENDER_SCRIPT_CAMS

```c
void RENDER_SCRIPT_CAMS(BOOL render, BOOL ease, int easeTime, BOOL p3, BOOL p4, Any p5)  // 0x07E5B515DB0636FC
```

build 323

> ease - smooth transition between the camera's positions
> easeTime - Time in milliseconds for the transition to happen
> 
> If you have created a script (rendering) camera, and want to go back to the 
> character (gameplay) camera, call this native with render set to 0.
> Setting ease to 1 will smooth the transition.

## REPLAY_GET_MAX_DISTANCE_ALLOWED_FROM_PLAYER

```c
float REPLAY_GET_MAX_DISTANCE_ALLOWED_FROM_PLAYER()  // 0x8BFCEB5EA1B161B6
```

build 323 · old names: `_REPLAY_FREE_CAM_GET_MAX_RANGE`

## RESET_GAMEPLAY_CAM_FULL_ATTACH_PARENT_TRANSFORM_TIMER

```c
void RESET_GAMEPLAY_CAM_FULL_ATTACH_PARENT_TRANSFORM_TIMER()  // 0x7295C203DD659DFE
```

build 2699

## SET_ALLOW_CUSTOM_VEHICLE_DRIVE_BY_CAM_THIS_UPDATE

```c
void SET_ALLOW_CUSTOM_VEHICLE_DRIVE_BY_CAM_THIS_UPDATE(BOOL p0)  // 0x4008EDF7D6E48175
```

build 323

## SET_CAM_ACTIVE

```c
void SET_CAM_ACTIVE(Cam cam, BOOL active)  // 0x026FB97D0A425F84
```

build 323

> Set camera as active/inactive.

## SET_CAM_ACTIVE_WITH_INTERP

```c
void SET_CAM_ACTIVE_WITH_INTERP(Cam camTo, Cam camFrom, int duration, int easeLocation, int easeRotation)  // 0x9FBDA379383A52A4
```

build 323

> Previous declaration void SET_CAM_ACTIVE_WITH_INTERP(Cam camTo, Cam camFrom, int duration, BOOL easeLocation, BOOL easeRotation) is completely wrong. The last two params are integers not BOOLs...
> 

## SET_CAM_AFFECTS_AIMING

```c
void SET_CAM_AFFECTS_AIMING(Cam cam, BOOL toggle)  // 0x8C1DC7770C51DC8D
```

build 323

> Allows you to aim and shoot at the direction the camera is facing.

## SET_CAM_ANIM_CURRENT_PHASE

```c
void SET_CAM_ANIM_CURRENT_PHASE(Cam cam, float phase)  // 0x4145A4C44FF3B5A6
```

build 323

## SET_CAM_CONTROLS_MINI_MAP_HEADING

```c
void SET_CAM_CONTROLS_MINI_MAP_HEADING(Cam cam, BOOL toggle)  // 0x661B5C8654ADD825
```

build 323 · old names: `_SET_CAM_CONTROLS_RADAR_ROTATION`

> Rotates the radar to match the camera's Z rotation

## SET_CAM_COORD

```c
void SET_CAM_COORD(Cam cam, float posX, float posY, float posZ)  // 0x4D41783FB745E42E
```

build 323

> Sets the position of the cam.

## SET_CAM_DEATH_FAIL_EFFECT_STATE

```c
void SET_CAM_DEATH_FAIL_EFFECT_STATE(int p0)  // 0x80C8B1846639BB19
```

build 323 · old names: `_SET_CAM_EFFECT`

> if p0 is 0, effect is cancelled
> 
> if p0 is 1, effect zooms in, gradually tilts cam clockwise apx 30 degrees, wobbles slowly. Motion blur is active until cancelled.
> 
> if p0 is 2, effect immediately tilts cam clockwise apx 30 degrees, begins to wobble slowly, then gradually tilts cam back to normal. The wobbling will continue until the effect is cancelled.

## SET_CAM_DEBUG_NAME

```c
void SET_CAM_DEBUG_NAME(Cam camera, const char* name)  // 0x1B93E0107865DD40
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## SET_CAM_DOF_FNUMBER_OF_LENS

```c
void SET_CAM_DOF_FNUMBER_OF_LENS(Cam camera, float p1)  // 0x7DD234D6F3914C5B
```

build 323 · old names: `_SET_CAM_DOF_FNUMBER_OF_LENS`

> This native has its name defined inside its codE
> 

## SET_CAM_DOF_FOCAL_LENGTH_MULTIPLIER

```c
void SET_CAM_DOF_FOCAL_LENGTH_MULTIPLIER(Cam camera, float multiplier)  // 0x47B595D60664CFFA
```

build 1011 · old names: `_SET_CAM_DOF_FOCAL_LENGTH_MULTIPLIER`

> Native name labeled within its code

## SET_CAM_DOF_FOCUS_DISTANCE_BIAS

```c
void SET_CAM_DOF_FOCUS_DISTANCE_BIAS(Cam camera, float p1)  // 0xC669EEA5D031B7DE
```

build 323 · old names: `_SET_CAM_DOF_FOCUS_DISTANCE_BIAS`

> This native has a name defined inside its code

## SET_CAM_DOF_MAX_NEAR_IN_FOCUS_DISTANCE

```c
void SET_CAM_DOF_MAX_NEAR_IN_FOCUS_DISTANCE(Cam camera, float p1)  // 0xC3654A441402562D
```

build 323 · old names: `_SET_CAM_DOF_MAX_NEAR_IN_FOCUS_DISTANCE`

> This native has a name defined inside its code

## SET_CAM_DOF_MAX_NEAR_IN_FOCUS_DISTANCE_BLEND_LEVEL

```c
void SET_CAM_DOF_MAX_NEAR_IN_FOCUS_DISTANCE_BLEND_LEVEL(Cam camera, float p1)  // 0x2C654B4943BDDF7C
```

build 323 · old names: `_SET_CAM_DOF_MAX_NEAR_IN_FOCUS_DISTANCE_BLEND_LEVEL`

> This native has a name defined inside its code

## SET_CAM_DOF_OVERRIDDEN_FOCUS_DISTANCE

```c
void SET_CAM_DOF_OVERRIDDEN_FOCUS_DISTANCE(Cam camera, float p1)  // 0xF55E4046F6F831DC
```

build 323

## SET_CAM_DOF_OVERRIDDEN_FOCUS_DISTANCE_BLEND_LEVEL

```c
void SET_CAM_DOF_OVERRIDDEN_FOCUS_DISTANCE_BLEND_LEVEL(Any p0, float p1)  // 0xE111A7C0D200CBC5
```

build 323

## SET_CAM_DOF_PLANES

```c
void SET_CAM_DOF_PLANES(Cam cam, float p1, float p2, float p3, float p4)  // 0x3CF48F6F96E749DC
```

build 323

## SET_CAM_DOF_SHOULD_KEEP_LOOK_AT_TARGET_IN_FOCUS

```c
void SET_CAM_DOF_SHOULD_KEEP_LOOK_AT_TARGET_IN_FOCUS(Cam camera, BOOL state)  // 0x7CF3AF51DCFE4108
```

build 2944

> This native has a name defined inside its code

## SET_CAM_DOF_STRENGTH

```c
void SET_CAM_DOF_STRENGTH(Cam cam, float dofStrength)  // 0x5EE29B4D7D5DF897
```

build 323

## SET_CAM_FAR_CLIP

```c
void SET_CAM_FAR_CLIP(Cam cam, float farClip)  // 0xAE306F2A904BF86E
```

build 323

## SET_CAM_FAR_DOF

```c
void SET_CAM_FAR_DOF(Cam cam, float farDOF)  // 0xEDD91296CD01AEE0
```

build 323

## SET_CAM_FOV

```c
void SET_CAM_FOV(Cam cam, float fieldOfView)  // 0xB13C14F66A00D047
```

build 323

> Sets the field of view of the cam.
> ---------------------------------------------
> Min: 1.0f
> Max: 130.0f

## SET_CAM_INHERIT_ROLL_VEHICLE

```c
void SET_CAM_INHERIT_ROLL_VEHICLE(Cam cam, BOOL p1)  // 0x45F1DE9C34B93AE6
```

build 323

> The native seems to only be called once.
> 
> The native is used as so,
> CAM::SET_CAM_INHERIT_ROLL_VEHICLE(l_544, getElem(2, &l_525, 4));
> In the exile1 script.

## SET_CAM_IS_INSIDE_VEHICLE

```c
void SET_CAM_IS_INSIDE_VEHICLE(Cam cam, BOOL toggle)  // 0xA2767257A320FC82
```

build 323 · old names: `_SET_CAM_SMOOTH_SHADOWS`

> When set to true shadows appear more smooth but less detailed.
> Set to false by default.

## SET_CAM_MOTION_BLUR_STRENGTH

```c
void SET_CAM_MOTION_BLUR_STRENGTH(Cam cam, float strength)  // 0x6F0F77FBA9A8F2E6
```

build 323

## SET_CAM_NEAR_CLIP

```c
void SET_CAM_NEAR_CLIP(Cam cam, float nearClip)  // 0xC7848EFCCC545182
```

build 323

## SET_CAM_NEAR_DOF

```c
void SET_CAM_NEAR_DOF(Cam cam, float nearDOF)  // 0x3FA4BF0A7AB7DE2C
```

build 323

## SET_CAM_PARAMS

```c
void SET_CAM_PARAMS(Cam cam, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float fieldOfView, Any p8, int p9, int p10, int p11)  // 0xBFD8727AEA3CCEBA
```

build 323

## SET_CAM_ROT

```c
void SET_CAM_ROT(Cam cam, float rotX, float rotY, float rotZ, int rotationOrder)  // 0x85973643155D0B07
```

build 323

> Sets the rotation of the cam.
> Last parameter unknown.
> 
> Last parameter seems to always be set to 2.

## SET_CAM_SHAKE_AMPLITUDE

```c
void SET_CAM_SHAKE_AMPLITUDE(Cam cam, float amplitude)  // 0xD93DB43B82BC0D00
```

build 323

## SET_CAM_SPLINE_DURATION

```c
void SET_CAM_SPLINE_DURATION(Cam cam, int timeDuration)  // 0x1381539FEE034CDA
```

build 323

> I named p1 as timeDuration as it is obvious. I'm assuming tho it is ran in ms(Milliseconds) as usual.

## SET_CAM_SPLINE_NODE_EASE

```c
void SET_CAM_SPLINE_NODE_EASE(Cam cam, int easingFunction, int p2, float p3)  // 0x83B8201ED82A9A2D
```

build 323

## SET_CAM_SPLINE_NODE_EXTRA_FLAGS

```c
void SET_CAM_SPLINE_NODE_EXTRA_FLAGS(Cam cam, int p1, int flags)  // 0x7BF1A54AE67AC070
```

build 323

## SET_CAM_SPLINE_NODE_VELOCITY_SCALE

```c
void SET_CAM_SPLINE_NODE_VELOCITY_SCALE(Cam cam, int p1, float scale)  // 0xA6385DEB180F319F
```

build 323

## SET_CAM_SPLINE_PHASE

```c
void SET_CAM_SPLINE_PHASE(Cam cam, float p1)  // 0x242B5874F0A4E052
```

build 323

## SET_CAM_SPLINE_SMOOTHING_STYLE

```c
void SET_CAM_SPLINE_SMOOTHING_STYLE(Cam cam, int smoothingStyle)  // 0xD1B0F412F109EA5D
```

build 323

## SET_CAM_USE_SHALLOW_DOF_MODE

```c
void SET_CAM_USE_SHALLOW_DOF_MODE(Cam cam, BOOL toggle)  // 0x16A96863A17552BB
```

build 323

## SET_CAM_VIEW_MODE_FOR_CONTEXT

```c
void SET_CAM_VIEW_MODE_FOR_CONTEXT(int context, int viewMode)  // 0x2A2173E46DAECD12
```

build 323

> context: see GET_CAM_ACTIVE_VIEW_MODE_CONTEXT, viewmode: see CAM.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE

## SET_CINEMATIC_BUTTON_ACTIVE

```c
void SET_CINEMATIC_BUTTON_ACTIVE(BOOL p0)  // 0x51669F7D1FB53D9F
```

build 323

## SET_CINEMATIC_CAM_SHAKE_AMPLITUDE

```c
void SET_CINEMATIC_CAM_SHAKE_AMPLITUDE(float p0)  // 0xC724C701C30B2FE7
```

build 323

## SET_CINEMATIC_MODE_ACTIVE

```c
void SET_CINEMATIC_MODE_ACTIVE(BOOL toggle)  // 0xDCF0754AC3D6FD4E
```

build 323

> Toggles the vehicle cinematic cam; requires the player ped to be in a vehicle to work.

## SET_CINEMATIC_NEWS_CHANNEL_ACTIVE_THIS_UPDATE

```c
void SET_CINEMATIC_NEWS_CHANNEL_ACTIVE_THIS_UPDATE()  // 0xDC9DA9E8789F5246
```

build 323

## SET_CUTSCENE_CAM_FAR_CLIP_THIS_UPDATE

```c
void SET_CUTSCENE_CAM_FAR_CLIP_THIS_UPDATE(float p0)  // 0x12DED8CA53D47EA5
```

build 323

> Hardcoded to only work in multiplayer.

## SET_FIRST_PERSON_AIM_CAM_NEAR_CLIP_THIS_UPDATE

```c
void SET_FIRST_PERSON_AIM_CAM_NEAR_CLIP_THIS_UPDATE(float p0)  // 0x0AF7B437918103B3
```

build 323 · old names: `_SET_FIRST_PERSON_CAM_NEAR_CLIP`

## SET_FIRST_PERSON_AIM_CAM_RELATIVE_HEADING_LIMITS_THIS_UPDATE

```c
void SET_FIRST_PERSON_AIM_CAM_RELATIVE_HEADING_LIMITS_THIS_UPDATE(float p0, float p1)  // 0x2F7F2B26DD3F18EE
```

build 323

## SET_FIRST_PERSON_AIM_CAM_RELATIVE_PITCH_LIMITS_THIS_UPDATE

```c
void SET_FIRST_PERSON_AIM_CAM_RELATIVE_PITCH_LIMITS_THIS_UPDATE(float p0, float p1)  // 0xBCFC632DB7673BF0
```

build 323 · old names: `_SET_FIRST_PERSON_CAM_PITCH_RANGE`

## SET_FIRST_PERSON_AIM_CAM_ZOOM_FACTOR

```c
void SET_FIRST_PERSON_AIM_CAM_ZOOM_FACTOR(float zoomFactor)  // 0x70894BD0915C5BCA
```

build 323

## SET_FIRST_PERSON_AIM_CAM_ZOOM_FACTOR_LIMITS_THIS_UPDATE

```c
void SET_FIRST_PERSON_AIM_CAM_ZOOM_FACTOR_LIMITS_THIS_UPDATE(float p0, float p1)  // 0xCED08CBE8EBB97C7
```

build 323

## SET_FIRST_PERSON_FLASH_EFFECT_TYPE

```c
void SET_FIRST_PERSON_FLASH_EFFECT_TYPE(Any p0)  // 0x5C41E6BABC9E2112
```

build 323

## SET_FIRST_PERSON_FLASH_EFFECT_VEHICLE_MODEL_HASH

```c
void SET_FIRST_PERSON_FLASH_EFFECT_VEHICLE_MODEL_HASH(Hash vehicleModel)  // 0x11FA5D3479C7DD47
```

build 323 · old names: `_SET_GAMEPLAY_CAM_VEHICLE_CAMERA_NAME`

## SET_FIRST_PERSON_FLASH_EFFECT_VEHICLE_MODEL_NAME

```c
void SET_FIRST_PERSON_FLASH_EFFECT_VEHICLE_MODEL_NAME(const char* vehicleName)  // 0x21E253A7F8DA5DFB
```

build 323 · old names: `_SET_GAMEPLAY_CAM_VEHICLE_CAMERA`

> From b617 scripts:
> 
> CAM::SET_FIRST_PERSON_FLASH_EFFECT_VEHICLE_MODEL_NAME("DINGHY");
> CAM::SET_FIRST_PERSON_FLASH_EFFECT_VEHICLE_MODEL_NAME("ISSI2");
> CAM::SET_FIRST_PERSON_FLASH_EFFECT_VEHICLE_MODEL_NAME("SPEEDO");

## SET_FIRST_PERSON_SHOOTER_CAMERA_HEADING

```c
void SET_FIRST_PERSON_SHOOTER_CAMERA_HEADING(float yaw)  // 0x103991D4A307D472
```

build 323 · old names: `_SET_GAMEPLAY_CAM_RAW_YAW`

> Does nothing

## SET_FIRST_PERSON_SHOOTER_CAMERA_PITCH

```c
void SET_FIRST_PERSON_SHOOTER_CAMERA_PITCH(float pitch)  // 0x759E13EBC1C15C5A
```

build 323 · old names: `_SET_GAMEPLAY_CAM_RAW_PITCH`

## SET_FLY_CAM_COORD_AND_CONSTRAIN

```c
void SET_FLY_CAM_COORD_AND_CONSTRAIN(Cam cam, float x, float y, float z)  // 0xC91C6C55199308CA
```

build 323

## SET_FLY_CAM_HORIZONTAL_RESPONSE

```c
void SET_FLY_CAM_HORIZONTAL_RESPONSE(Cam cam, float p1, float p2, float p3)  // 0x503F5920162365B2
```

build 323

## SET_FLY_CAM_MAX_HEIGHT

```c
void SET_FLY_CAM_MAX_HEIGHT(Cam cam, float height)  // 0xF9D02130ECDD1D77
```

build 323 · old names: `_SET_CAMERA_RANGE`

## SET_FLY_CAM_VERTICAL_CONTROLS_THIS_UPDATE

```c
void SET_FLY_CAM_VERTICAL_CONTROLS_THIS_UPDATE(Cam cam)  // 0xC8B5C4A79CC18B94
```

build 323

## SET_FLY_CAM_VERTICAL_RESPONSE

```c
void SET_FLY_CAM_VERTICAL_RESPONSE(Cam cam, float p1, float p2, float p3)  // 0xE827B9382CFB41BA
```

build 791 · old names: `_SET_FLY_CAM_VERTICAL_SPEED_MULTIPLIER`

## SET_FOLLOW_CAM_IGNORE_ATTACH_PARENT_MOVEMENT_THIS_UPDATE

```c
void SET_FOLLOW_CAM_IGNORE_ATTACH_PARENT_MOVEMENT_THIS_UPDATE()  // 0xDD79DF9F4D26E1C9
```

build 323

## SET_FOLLOW_PED_CAM_LADDER_ALIGN_THIS_UPDATE

```c
void SET_FOLLOW_PED_CAM_LADDER_ALIGN_THIS_UPDATE()  // 0xC8391C309684595A
```

build 323

## SET_FOLLOW_PED_CAM_THIS_UPDATE

```c
BOOL SET_FOLLOW_PED_CAM_THIS_UPDATE(const char* camName, int p1)  // 0x44A113DD6FFC48D1
```

build 323 · old names: `SET_FOLLOW_PED_CAM_CUTSCENE_CHAT`

> From the scripts:
> 
> CAM::SET_FOLLOW_PED_CAM_THIS_UPDATE("FOLLOW_PED_ATTACHED_TO_ROPE_CAMERA", 0);
> CAM::SET_FOLLOW_PED_CAM_THIS_UPDATE("FOLLOW_PED_ON_EXILE1_LADDER_CAMERA", 1500);
> CAM::SET_FOLLOW_PED_CAM_THIS_UPDATE("FOLLOW_PED_SKY_DIVING_CAMERA", 0);
> CAM::SET_FOLLOW_PED_CAM_THIS_UPDATE("FOLLOW_PED_SKY_DIVING_CAMERA", 3000);
> CAM::SET_FOLLOW_PED_CAM_THIS_UPDATE("FOLLOW_PED_SKY_DIVING_FAMILY5_CAMERA", 0);
> CAM::SET_FOLLOW_PED_CAM_THIS_UPDATE("FOLLOW_PED_SKY_DIVING_CAMERA", 0);

## SET_FOLLOW_PED_CAM_VIEW_MODE

```c
void SET_FOLLOW_PED_CAM_VIEW_MODE(int viewMode)  // 0x5A4F9EDF1673F704
```

build 323

> Sets the type of Player camera:
> 
> 0 - Third Person Close
> 1 - Third Person Mid
> 2 - Third Person Far
> 4 - First Person

## SET_FOLLOW_VEHICLE_CAM_HIGH_ANGLE_MODE_EVERY_UPDATE

```c
void SET_FOLLOW_VEHICLE_CAM_HIGH_ANGLE_MODE_EVERY_UPDATE(BOOL p0, BOOL p1)  // 0x9DFE13ECDC1EC196
```

build 323 · old names: `SET_TIME_IDLE_DROP`

## SET_FOLLOW_VEHICLE_CAM_HIGH_ANGLE_MODE_THIS_UPDATE

```c
void SET_FOLLOW_VEHICLE_CAM_HIGH_ANGLE_MODE_THIS_UPDATE(BOOL p0)  // 0x91EF6EE6419E5B97
```

build 323

## SET_FOLLOW_VEHICLE_CAM_SEAT_THIS_UPDATE

```c
void SET_FOLLOW_VEHICLE_CAM_SEAT_THIS_UPDATE(int seatIndex)  // 0x5C90CAB09951A12F
```

build 1365 · old names: `_SET_FOLLOW_TURRET_SEAT_CAM`

## SET_FOLLOW_VEHICLE_CAM_VIEW_MODE

```c
void SET_FOLLOW_VEHICLE_CAM_VIEW_MODE(int viewMode)  // 0xAC253D7842768F48
```

build 323

> Sets the type of Player camera in vehicles:
> viewmode: see CAM.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE

## SET_FOLLOW_VEHICLE_CAM_ZOOM_LEVEL

```c
void SET_FOLLOW_VEHICLE_CAM_ZOOM_LEVEL(int zoomLevel)  // 0x19464CB6E4078C8A
```

build 323

## SET_GAMEPLAY_CAM_ALTITUDE_FOV_SCALING_STATE

```c
void SET_GAMEPLAY_CAM_ALTITUDE_FOV_SCALING_STATE(BOOL p0)  // 0xDB90C6CCA48940F1
```

build 323

## SET_GAMEPLAY_CAM_ENTITY_TO_LIMIT_FOCUS_OVER_BOUNDING_SPHERE_THIS_UPDATE

```c
void SET_GAMEPLAY_CAM_ENTITY_TO_LIMIT_FOCUS_OVER_BOUNDING_SPHERE_THIS_UPDATE(Entity entity)  // 0xFD3151CD37EA2245
```

build 323

## SET_GAMEPLAY_CAM_FOLLOW_PED_THIS_UPDATE

```c
void SET_GAMEPLAY_CAM_FOLLOW_PED_THIS_UPDATE(Ped ped)  // 0x8BBACBF51DA047A8
```

build 323

> Forces gameplay cam to specified ped as if you were the ped or spectating it

## SET_GAMEPLAY_CAM_IGNORE_ENTITY_COLLISION_THIS_UPDATE

```c
void SET_GAMEPLAY_CAM_IGNORE_ENTITY_COLLISION_THIS_UPDATE(Entity entity)  // 0x2AED6301F67007D5
```

build 323 · old names: `_DISABLE_CAM_COLLISION_FOR_ENTITY`

## SET_GAMEPLAY_CAM_MAX_MOTION_BLUR_STRENGTH_THIS_UPDATE

```c
void SET_GAMEPLAY_CAM_MAX_MOTION_BLUR_STRENGTH_THIS_UPDATE(float p0)  // 0x0225778816FDC28C
```

build 323

> some camera effect that is (also) used in the drunk-cheat, and turned off (by setting it to 0.0) along with the shaking effects once the drunk cheat is disabled.

## SET_GAMEPLAY_CAM_MOTION_BLUR_SCALING_THIS_UPDATE

```c
void SET_GAMEPLAY_CAM_MOTION_BLUR_SCALING_THIS_UPDATE(float p0)  // 0x487A82C650EB7799
```

build 323

> some camera effect that is used in the drunk-cheat, and turned off (by setting it to 0.0) along with the shaking effects once the drunk cheat is disabled.

## SET_GAMEPLAY_CAM_RELATIVE_HEADING

```c
void SET_GAMEPLAY_CAM_RELATIVE_HEADING(float heading)  // 0xB4EC2312F4E5B1F1
```

build 323

> Sets the camera position relative to heading in float from -360 to +360.
> 
> Heading is alwyas 0 in aiming camera.

## SET_GAMEPLAY_CAM_RELATIVE_PITCH

```c
void SET_GAMEPLAY_CAM_RELATIVE_PITCH(float angle, float scalingFactor)  // 0x6D0858B8EDFD2B7D
```

build 323

> This native sets the camera's pitch (rotation on the x-axis).

## SET_GAMEPLAY_CAM_SHAKE_AMPLITUDE

```c
void SET_GAMEPLAY_CAM_SHAKE_AMPLITUDE(float amplitude)  // 0xA87E00932DB4D85D
```

build 323

> Sets the amplitude for the gameplay (i.e. 3rd or 1st) camera to shake. Used in script "drunk_controller.ysc.c4" to simulate making the player drunk.

## SET_GAMEPLAY_COORD_HINT

```c
void SET_GAMEPLAY_COORD_HINT(float x, float y, float z, int duration, int blendOutDuration, int blendInDuration, int p6)  // 0xD51ADCD2D8BC0FB3
```

build 323

## SET_GAMEPLAY_ENTITY_HINT

```c
void SET_GAMEPLAY_ENTITY_HINT(Entity entity, float xOffset, float yOffset, float zOffset, BOOL p4, int time, int easeInTime, int easeOutTime, int p8)  // 0x189E955A8313E298
```

build 323

> p8 could be some sort of flag. Scripts use:
> -244429742
> 0
> 1726668277
> 1844968929

## SET_GAMEPLAY_HINT_BASE_ORBIT_PITCH_OFFSET

```c
void SET_GAMEPLAY_HINT_BASE_ORBIT_PITCH_OFFSET(float value)  // 0xD1F8363DFAD03848
```

build 323 · old names: `_SET_GAMEPLAY_HINT_ANGLE`

## SET_GAMEPLAY_HINT_CAMERA_BLEND_TO_FOLLOW_PED_MEDIUM_VIEW_MODE

```c
void SET_GAMEPLAY_HINT_CAMERA_BLEND_TO_FOLLOW_PED_MEDIUM_VIEW_MODE(BOOL toggle)  // 0xE3433EADAAF7EE40
```

build 323 · old names: `GET_IS_MULTIPLAYER_BRIEF`, `_SET_GAMEPLAY_HINT_ANIM_CLOSEUP`

## SET_GAMEPLAY_HINT_CAMERA_RELATIVE_SIDE_OFFSET

```c
void SET_GAMEPLAY_HINT_CAMERA_RELATIVE_SIDE_OFFSET(float xOffset)  // 0x5D7B620DAE436138
```

build 323 · old names: `_SET_GAMEPLAY_HINT_ANIM_OFFSETX`

## SET_GAMEPLAY_HINT_CAMERA_RELATIVE_VERTICAL_OFFSET

```c
void SET_GAMEPLAY_HINT_CAMERA_RELATIVE_VERTICAL_OFFSET(float yOffset)  // 0xC92717EF615B6704
```

build 323 · old names: `_SET_GAMEPLAY_HINT_ANIM_OFFSETY`

## SET_GAMEPLAY_HINT_FOLLOW_DISTANCE_SCALAR

```c
void SET_GAMEPLAY_HINT_FOLLOW_DISTANCE_SCALAR(float value)  // 0xF8BDBF3D573049A1
```

build 323 · old names: `_SET_GAMEPLAY_HINT_ANIM_OFFSETZ`

## SET_GAMEPLAY_HINT_FOV

```c
void SET_GAMEPLAY_HINT_FOV(float FOV)  // 0x513403FB9C56211F
```

build 323

## SET_GAMEPLAY_OBJECT_HINT

```c
void SET_GAMEPLAY_OBJECT_HINT(Object object, float xOffset, float yOffset, float zOffset, BOOL p4, int time, int easeInTime, int easeOutTime)  // 0x83E87508A2CA2AC6
```

build 323

## SET_GAMEPLAY_PED_HINT

```c
void SET_GAMEPLAY_PED_HINT(Ped ped, float x1, float y1, float z1, BOOL p4, int duration, int blendOutDuration, int blendInDuration)  // 0x2B486269ACD548D3
```

build 323

## SET_GAMEPLAY_VEHICLE_HINT

```c
void SET_GAMEPLAY_VEHICLE_HINT(Vehicle vehicle, float offsetX, float offsetY, float offsetZ, BOOL p4, int time, int easeInTime, int easeOutTime)  // 0xA2297E18F3E71C2E
```

build 323

> Focuses the camera on the specified vehicle.

## SET_IN_VEHICLE_CAM_STATE_THIS_UPDATE

```c
void SET_IN_VEHICLE_CAM_STATE_THIS_UPDATE(Vehicle p0, int p1)  // 0xE9EA16D6E54CDCA4
```

build 323

> Forces gameplay cam to specified vehicle as if you were in it

## SET_SCRIPTED_CAMERA_IS_FIRST_PERSON_THIS_FRAME

```c
void SET_SCRIPTED_CAMERA_IS_FIRST_PERSON_THIS_FRAME(BOOL p0)  // 0x469F2ECDEC046337
```

build 323

## SET_TABLE_GAMES_CAMERA_THIS_UPDATE

```c
BOOL SET_TABLE_GAMES_CAMERA_THIS_UPDATE(Hash hash)  // 0x79C0E43EB9B944E2
```

build 1734

## SET_THIRD_PERSON_AIM_CAM_NEAR_CLIP_THIS_UPDATE

```c
void SET_THIRD_PERSON_AIM_CAM_NEAR_CLIP_THIS_UPDATE(float p0)  // 0x42156508606DE65E
```

build 323 · old names: `_SET_THIRD_PERSON_AIM_CAM_NEAR_CLIP`

## SET_THIRD_PERSON_CAM_ORBIT_DISTANCE_LIMITS_THIS_UPDATE

```c
void SET_THIRD_PERSON_CAM_ORBIT_DISTANCE_LIMITS_THIS_UPDATE(float p0, float distance)  // 0xDF2E1F7742402E81
```

build 323 · old names: `_ANIMATE_GAMEPLAY_CAM_ZOOM`

> Seems to animate the gameplay camera zoom.
> 
> Eg. SET_THIRD_PERSON_CAM_ORBIT_DISTANCE_LIMITS_THIS_UPDATE(1f, 1000f);
> will animate the camera zooming in from 1000 meters away.
> 
> Game scripts use it like this:
> 
> // Setting this to 1 prevents V key from changing zoom
> PLAYER::SET_PLAYER_FORCED_ZOOM(PLAYER::PLAYER_ID(), 1);
> 
> // These restrict how far you can move cam up/down left/right
> CAM::SET_THIRD_PERSON_CAM_RELATIVE_HEADING_LIMITS_THIS_UPDATE(-20f, 50f);
> CAM::SET_THIRD_PERSON_CAM_RELATIVE_PITCH_LIMITS_THIS_UPDATE(-60f, 0f);
> 
> CAM::SET_THIRD_PERSON_CAM_ORBIT_DISTANCE_LIMITS_THIS_UPDATE(1f, 1f);

## SET_THIRD_PERSON_CAM_RELATIVE_HEADING_LIMITS_THIS_UPDATE

```c
void SET_THIRD_PERSON_CAM_RELATIVE_HEADING_LIMITS_THIS_UPDATE(float minimum, float maximum)  // 0x8F993D26E0CA5E8E
```

build 323 · old names: `_CLAMP_GAMEPLAY_CAM_YAW`

> minimum: Degrees between -180f and 180f.
> maximum: Degrees between -180f and 180f.
> 
> Clamps the gameplay camera's current yaw.
> 
> Eg. SET_THIRD_PERSON_CAM_RELATIVE_HEADING_LIMITS_THIS_UPDATE(0.0f, 0.0f) will set the horizontal angle directly behind the player.

## SET_THIRD_PERSON_CAM_RELATIVE_PITCH_LIMITS_THIS_UPDATE

```c
void SET_THIRD_PERSON_CAM_RELATIVE_PITCH_LIMITS_THIS_UPDATE(float minimum, float maximum)  // 0xA516C198B7DCA1E1
```

build 323 · old names: `_CLAMP_GAMEPLAY_CAM_PITCH`

> minimum: Degrees between -90f and 90f.
> maximum: Degrees between -90f and 90f.
> 
> Clamps the gameplay camera's current pitch.
> 
> Eg. SET_THIRD_PERSON_CAM_RELATIVE_PITCH_LIMITS_THIS_UPDATE(0.0f, 0.0f) will set the vertical angle directly behind the player.

## SET_USE_HI_DOF

```c
void SET_USE_HI_DOF()  // 0xA13B0222F3D94A94
```

build 323

## SET_USE_HI_DOF_ON_SYNCED_SCENE_THIS_UPDATE

```c
void SET_USE_HI_DOF_ON_SYNCED_SCENE_THIS_UPDATE()  // 0x731A880555DA3647
```

build 2699 · old names: `_SET_USE_HI_DOF_IN_CUTSCENE`

> Only used in R* Script fm_mission_controller_2020

## SET_WIDESCREEN_BORDERS

```c
void SET_WIDESCREEN_BORDERS(BOOL p0, int p1)  // 0xDCD4EA924F42D01A
```

build 323

## SHAKE_CAM

```c
void SHAKE_CAM(Cam cam, const char* type, float amplitude)  // 0x6A25241C340D3822
```

build 323

> Possible shake types (updated b617d):
> 
> DEATH_FAIL_IN_EFFECT_SHAKE
> DRUNK_SHAKE
> FAMILY5_DRUG_TRIP_SHAKE
> HAND_SHAKE
> JOLT_SHAKE
> LARGE_EXPLOSION_SHAKE
> MEDIUM_EXPLOSION_SHAKE
> SMALL_EXPLOSION_SHAKE
> ROAD_VIBRATION_SHAKE
> SKY_DIVING_SHAKE
> VIBRATE_SHAKE
> 
> Full list of cam shake types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/camShakeTypesCompact.json

## SHAKE_CINEMATIC_CAM

```c
void SHAKE_CINEMATIC_CAM(const char* shakeType, float amount)  // 0xDCE214D9ED58F3CF
```

build 323

> p0 argument found in the b617d scripts: "DRUNK_SHAKE"
> 
> Full list of cam shake types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/camShakeTypesCompact.json

## SHAKE_GAMEPLAY_CAM

```c
void SHAKE_GAMEPLAY_CAM(const char* shakeName, float intensity)  // 0xFD55E49555E017CF
```

build 323

> Possible shake types (updated b617d):
> 
> DEATH_FAIL_IN_EFFECT_SHAKE
> DRUNK_SHAKE
> FAMILY5_DRUG_TRIP_SHAKE
> HAND_SHAKE
> JOLT_SHAKE
> LARGE_EXPLOSION_SHAKE
> MEDIUM_EXPLOSION_SHAKE
> SMALL_EXPLOSION_SHAKE
> ROAD_VIBRATION_SHAKE
> SKY_DIVING_SHAKE
> VIBRATE_SHAKE
> 
> Full list of cam shake types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/camShakeTypesCompact.json

## SHAKE_SCRIPT_GLOBAL

```c
void SHAKE_SCRIPT_GLOBAL(const char* p0, float p1)  // 0xF4C8CF9E353AFECA
```

build 323

> CAM::SHAKE_SCRIPT_GLOBAL("HAND_SHAKE", 0.2);
> 
> Full list of cam shake types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/camShakeTypesCompact.json

## STOP_CAM_POINTING

```c
void STOP_CAM_POINTING(Cam cam)  // 0xF33AB75780BA57DE
```

build 323

## STOP_CAM_SHAKING

```c
void STOP_CAM_SHAKING(Cam cam, BOOL p1)  // 0xBDECF64367884AC3
```

build 323

## STOP_CINEMATIC_CAM_SHAKING

```c
void STOP_CINEMATIC_CAM_SHAKING(BOOL p0)  // 0x2238E588E588A6D7
```

build 323

## STOP_CINEMATIC_SHOT

```c
void STOP_CINEMATIC_SHOT(Hash p0)  // 0x7660C6E75D3A078E
```

build 323

> Only used once in carsteal3 with p0 set to -1096069633 (CAMERA_MAN_SHOT)

## STOP_CODE_GAMEPLAY_HINT

```c
void STOP_CODE_GAMEPLAY_HINT(BOOL p0)  // 0x247ACBC4ABBC9D1C
```

build 323

## STOP_CUTSCENE_CAM_SHAKING

```c
void STOP_CUTSCENE_CAM_SHAKING(Any p0)  // 0x324C5AA411DA7737
```

build 323

## STOP_GAMEPLAY_CAM_SHAKING

```c
void STOP_GAMEPLAY_CAM_SHAKING(BOOL p0)  // 0x0EF93E9F3D08C178
```

build 323

## STOP_GAMEPLAY_HINT

```c
void STOP_GAMEPLAY_HINT(BOOL p0)  // 0xF46C581C61718916
```

build 323

## STOP_GAMEPLAY_HINT_BEING_CANCELLED_THIS_UPDATE

```c
void STOP_GAMEPLAY_HINT_BEING_CANCELLED_THIS_UPDATE(BOOL p0)  // 0xCCD078C2665D2973
```

build 323

> This native does absolutely nothing, just a nullsub

## STOP_RENDERING_SCRIPT_CAMS_USING_CATCH_UP

```c
void STOP_RENDERING_SCRIPT_CAMS_USING_CATCH_UP(BOOL render, float p1, int p2, Any p3)  // 0xC819F3CBB62BF692
```

build 323 · old names: `_RENDER_FIRST_PERSON_CAM`

> This native makes the gameplay camera zoom into first person/third person with a special effect.

## STOP_SCRIPT_GLOBAL_SHAKING

```c
void STOP_SCRIPT_GLOBAL_SHAKING(BOOL p0)  // 0x1C9D7949FA533490
```

build 323

> In drunk_controller.c4, sub_309
> if (CAM::IS_SCRIPT_GLOBAL_SHAKING()) {
>     CAM::STOP_SCRIPT_GLOBAL_SHAKING(0);
> }

## TRIGGER_VEHICLE_PART_BROKEN_CAMERA_SHAKE

```c
void TRIGGER_VEHICLE_PART_BROKEN_CAMERA_SHAKE(Vehicle vehicle, int p1, float p2)  // 0x5D96CFB59DA076A0
```

build 2060

> p1: 0..16

## USE_DEDICATED_STUNT_CAMERA_THIS_UPDATE

```c
void USE_DEDICATED_STUNT_CAMERA_THIS_UPDATE(const char* camName)  // 0x425A920FDB9A0DDA
```

build 1180 · old names: `_SET_GAMEPLAY_CAM_HASH`

> Sets gameplay camera to hash

## USE_SCRIPT_CAM_FOR_AMBIENT_POPULATION_ORIGIN_THIS_FRAME

```c
void USE_SCRIPT_CAM_FOR_AMBIENT_POPULATION_ORIGIN_THIS_FRAME(BOOL p0, BOOL p1)  // 0x271401846BD26E92
```

build 323

## USE_VEHICLE_CAM_STUNT_SETTINGS_THIS_UPDATE

```c
void USE_VEHICLE_CAM_STUNT_SETTINGS_THIS_UPDATE()  // 0x6493CF69859B116A
```

build 791 · old names: `_USE_STUNT_CAMERA_THIS_FRAME`

## WAS_FLY_CAM_CONSTRAINED_ON_PREVIOUS_UDPATE

```c
BOOL WAS_FLY_CAM_CONSTRAINED_ON_PREVIOUS_UDPATE(Cam cam)  // 0x5C48A1D6E3B33179
```

build 323

