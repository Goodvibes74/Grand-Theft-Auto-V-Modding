# ENTITY natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _GET_CHILD_ATTACHMENT

```c
Entity _GET_CHILD_ATTACHMENT(Entity entity)  // 0xD35ECEBF6FB2C261
```

build 3889

## _GET_LAST_ENTITY_HIT_BY_ENTITY

```c
Entity _GET_LAST_ENTITY_HIT_BY_ENTITY(Entity entity)  // 0xA75EE4F689B85391
```

build 2802

## _IS_ENTITY_FIXED

```c
BOOL _IS_ENTITY_FIXED(Entity entity)  // 0xDA5EF4092EDB83F4
```

build 3889

## _SET_ENTITY_NO_COLLISION_WITH_NETWORKED_ENTITY

```c
void _SET_ENTITY_NO_COLLISION_WITH_NETWORKED_ENTITY(Entity entity1, Entity entity2)  // 0x0A27A7827347B3B1
```

build 3407

## APPLY_FORCE_TO_ENTITY

```c
void APPLY_FORCE_TO_ENTITY(Entity entity, int forceFlags, float x, float y, float z, float offX, float offY, float offZ, int boneIndex, BOOL isDirectionRel, BOOL ignoreUpVec, BOOL isForceRel, BOOL p12, BOOL p13)  // 0xC5F68BE9613E2D18
```

build 323

> Documented here:
> https://gtaforums.com/topic/885669-precisely-define-object-physics/
> https://gtaforums.com/topic/887362-apply-forces-and-momentums-to-entityobject/
> 
> forceFlags:
> First bit (lowest): Strong force flag, factor 100
> Second bit: Unkown flag
> Third bit: Momentum flag=1 (vector (x,y,z) is a momentum, more research needed)
> If higher bits are unequal 0 the function doesn't applay any forces at all.
> (As integer possible values are 0-7)
> 
> 0: weak force
> 1: strong force
> 2: same as 0 (2nd bit?)
> 3: same as 1
> 4: weak momentum
> 5: strong momentum
> 6: same as 4
> 7: same as 5
> 
> isLocal: vector defined in local (body-fixed) coordinate frame
> isMassRel: if true the force gets multiplied with the objects mass (this is why it was known as highForce) and different objects will have the same acceleration.

## APPLY_FORCE_TO_ENTITY_CENTER_OF_MASS

```c
void APPLY_FORCE_TO_ENTITY_CENTER_OF_MASS(Entity entity, int forceType, float x, float y, float z, BOOL p5, BOOL isDirectionRel, BOOL isForceRel, BOOL p8)  // 0x18FF00FC7EFF559E
```

build 323

> Applies a force to the specified entity.
> 
> **List of force types (p1)**:
> public enum ForceType
> {
>     MinForce = 0,
>     MaxForceRot = 1,
>     MinForce2 = 2,
>     MaxForceRot2 = 3,
>     ForceNoRot = 4,
>     ForceRotPlusForce = 5
> }
> Research/documentation on the gtaforums can be found here https://gtaforums.com/topic/885669-precisely-define-object-physics/) and here https://gtaforums.com/topic/887362-apply-forces-and-momentums-to-entityobject/.
> 
> p6/relative - makes the xyz force not relative to world coords, but to something else
> p7/highForce - setting false will make the force really low

## ATTACH_ENTITY_BONE_TO_ENTITY_BONE

```c
void ATTACH_ENTITY_BONE_TO_ENTITY_BONE(Entity entity1, Entity entity2, int boneIndex1, int boneIndex2, BOOL p4, BOOL p5)  // 0x5C48B75732C8456C
```

build 791 · old names: `_ATTACH_ENTITY_BONE_TO_ENTITY_BONE`

## ATTACH_ENTITY_BONE_TO_ENTITY_BONE_Y_FORWARD

```c
void ATTACH_ENTITY_BONE_TO_ENTITY_BONE_Y_FORWARD(Entity entity1, Entity entity2, int boneIndex1, int boneIndex2, BOOL p4, BOOL p5)  // 0xFD1695C5D3B05439
```

build 791 · old names: `_ATTACH_ENTITY_BONE_TO_ENTITY_BONE_PHYSICALLY`

## ATTACH_ENTITY_TO_ENTITY

```c
void ATTACH_ENTITY_TO_ENTITY(Entity entity1, Entity entity2, int boneIndex, float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, BOOL p9, BOOL useSoftPinning, BOOL collision, BOOL isPed, int vertexIndex, BOOL fixedRot, Any p15)  // 0x6B9BBD38AB0796DF
```

build 323

> Attaches entity1 to bone (boneIndex) of entity2.
> 
> boneIndex - this is different to boneID, use GET_PED_BONE_INDEX to get the index from the ID. use the index for attaching to specific bones. entity1 will be attached to entity2's centre if bone index given doesn't correspond to bone indexes for that entity type.
> 
> useSoftPinning - if set to false attached entity will not detach when fixed
> collision - controls collision between the two entities (FALSE disables collision).
> isPed - pitch doesnt work when false and roll will only work on negative numbers (only peds)
> vertexIndex - position of vertex
> fixedRot - if false it ignores entity vector 
> 

## ATTACH_ENTITY_TO_ENTITY_PHYSICALLY

```c
void ATTACH_ENTITY_TO_ENTITY_PHYSICALLY(Entity entity1, Entity entity2, int boneIndex1, int boneIndex2, float xPos1, float yPos1, float zPos1, float xPos2, float yPos2, float zPos2, float xRot, float yRot, float zRot, float breakForce, BOOL fixedRot, BOOL p15, BOOL collision, BOOL p17, int p18)  // 0xC3675780C92F90F9
```

build 323

> breakForce is the amount of force required to break the bond.
> p14 - is always 1 in scripts
> p15 - is 1 or 0 in scripts - unknoun what it does
> p16 - controls collision between the two entities (FALSE disables collision).
> p17 - do not teleport entity to be attached to the position of the bone Index of the target entity (if 1, entity will not be teleported to target bone)
> p18 - is always 2 in scripts.
> 
> 

## ATTACH_ENTITY_TO_ENTITY_PHYSICALLY_OVERRIDE_INVERSE_MASS

```c
void ATTACH_ENTITY_TO_ENTITY_PHYSICALLY_OVERRIDE_INVERSE_MASS(Entity firstEntityIndex, Entity secondEntityIndex, int firstEntityBoneIndex, int secondEntityBoneIndex, float secondEntityOffsetX, float secondEntityOffsetY, float secondEntityOffsetZ, float firstEntityOffsetX, float firstEntityOffsetY, float firstEntityOffsetZ, float vecRotationX, float vecRotationY, float vecRotationZ, float physicalStrength, BOOL constrainRotation, BOOL doInitialWarp, BOOL collideWithEntity, BOOL addInitialSeperation, int rotOrder, float invMassScaleA, float invMassScaleB)  // 0x168A09D1B25B0BA4
```

build 2944

## CLEAR_ENTITY_LAST_DAMAGE_ENTITY

```c
void CLEAR_ENTITY_LAST_DAMAGE_ENTITY(Entity entity)  // 0xA72CD9CA74A5ECBA
```

build 323

## CREATE_FORCED_OBJECT

```c
void CREATE_FORCED_OBJECT(float x, float y, float z, Any p3, Hash modelHash, BOOL p5)  // 0x150E808B375A385A
```

build 323

## CREATE_MODEL_HIDE

```c
void CREATE_MODEL_HIDE(float x, float y, float z, float radius, Hash modelHash, BOOL p5)  // 0x8A97BCA30A0CE478
```

build 323

> p5 = sets as true in scripts
> Same as the comment for CREATE_MODEL_SWAP unless for some reason p5 affects it this only works with objects as well.
> 
> Network players do not see changes done with this.

## CREATE_MODEL_HIDE_EXCLUDING_SCRIPT_OBJECTS

```c
void CREATE_MODEL_HIDE_EXCLUDING_SCRIPT_OBJECTS(float x, float y, float z, float radius, Hash modelHash, BOOL p5)  // 0x3A52AE588830BF7F
```

build 323

## CREATE_MODEL_SWAP

```c
void CREATE_MODEL_SWAP(float x, float y, float z, float radius, Hash originalModel, Hash newModel, BOOL p6)  // 0x92C47782FDA8B2A3
```

build 323

> Only works with objects!

## DELETE_ENTITY

```c
void DELETE_ENTITY(Entity* entity)  // 0xAE3CBE5BF394C9C9
```

build 323

> Deletes the specified entity, then sets the handle pointed to by the pointer to NULL.

## DETACH_ENTITY

```c
void DETACH_ENTITY(Entity entity, BOOL dynamic, BOOL collision)  // 0x961AC54BF0613F5D
```

build 323

> If `collision` is set to true, both entities won't collide with the other until the distance between them is above 4 meters.
> Set `dynamic` to true to keep velocity after dettaching

## DOES_ENTITY_BELONG_TO_THIS_SCRIPT

```c
BOOL DOES_ENTITY_BELONG_TO_THIS_SCRIPT(Entity entity, BOOL p1)  // 0xDDE6DF5AE89981D2
```

build 323

## DOES_ENTITY_EXIST

```c
BOOL DOES_ENTITY_EXIST(Entity entity)  // 0x7239B21A38F536BA
```

build 323

> Checks whether an entity exists in the game world.

## DOES_ENTITY_HAVE_ANIM_DIRECTOR

```c
BOOL DOES_ENTITY_HAVE_ANIM_DIRECTOR(Entity entity)  // 0x2158E81A6AF65EA9
```

build 2699 · old names: `_DOES_ENTITY_HAVE_ANIM_DIRECTOR`

## DOES_ENTITY_HAVE_DRAWABLE

```c
BOOL DOES_ENTITY_HAVE_DRAWABLE(Entity entity)  // 0x060D6E96F8B8E48D
```

build 323

## DOES_ENTITY_HAVE_PHYSICS

```c
BOOL DOES_ENTITY_HAVE_PHYSICS(Entity entity)  // 0xDA95EA3317CC5064
```

build 323

## DOES_ENTITY_HAVE_SKELETON

```c
BOOL DOES_ENTITY_HAVE_SKELETON(Entity entity)  // 0x764EB96874EFFDC1
```

build 2699 · old names: `_DOES_ENTITY_HAVE_SKELETON_DATA`

## ENABLE_ENTITY_BULLET_COLLISION

```c
void ENABLE_ENTITY_BULLET_COLLISION(Entity entity)  // 0x6CE177D014502E8A
```

build 877 · old names: `_ENABLE_ENTITY_UNK`

## FIND_ANIM_EVENT_PHASE

```c
BOOL FIND_ANIM_EVENT_PHASE(const char* animDictionary, const char* animName, const char* p2, Any* p3, Any* p4)  // 0x07F1BE2BCCAA27A7
```

build 323

> In the script "player_scene_t_bbfight.c4":
> "if (ENTITY::FIND_ANIM_EVENT_PHASE(&l_16E, &l_19F[v_4/*16*/], v_9, &v_A, &v_B))"
> -- &l_16E (p0) is requested as an anim dictionary earlier in the script.
> -- &l_19F[v_4/*16*/] (p1) is used in other natives in the script as the "animation" param.
> -- v_9 (p2) is instantiated as "victim_fall"; I'm guessing that's another anim
> --v_A and v_B (p3 & p4) are both set as -1.0, but v_A is used immediately after this native for: 
> "if (v_A < ENTITY::GET_ENTITY_ANIM_CURRENT_TIME(...))"
> Both v_A and v_B are seemingly used to contain both Vector3's and floats, so I can't say what either really is other than that they are both output parameters. p4 looks more like a *Vector3 though
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## FORCE_ENTITY_AI_AND_ANIMATION_UPDATE

```c
void FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(Entity entity)  // 0x40FDEDB72F8293B2
```

build 323

> Based on carmod_shop script decompile this takes a vehicle parameter. It is called when repair is done on initial enter.

## FREEZE_ENTITY_POSITION

```c
void FREEZE_ENTITY_POSITION(Entity entity, BOOL toggle)  // 0x428CA6DBD1094446
```

build 323

> Freezes or unfreezes an entity preventing its coordinates to change by the player if set to `true`. You can still change the entity position using SET_ENTITY_COORDS.

## GET_ANIM_DURATION

```c
float GET_ANIM_DURATION(const char* animDict, const char* animName)  // 0xFEDDF04D62B8D790
```

build 323 · old names: `_GET_ANIM_DURATION`

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## GET_COLLISION_NORMAL_OF_LAST_HIT_FOR_ENTITY

```c
Vector3 GET_COLLISION_NORMAL_OF_LAST_HIT_FOR_ENTITY(Entity entity)  // 0xE465D4AB7CA6AE72
```

build 323

## GET_ENTITY_ALPHA

```c
int GET_ENTITY_ALPHA(Entity entity)  // 0x5A47B3B5E63E94C6
```

build 323

## GET_ENTITY_ANIM_CURRENT_TIME

```c
float GET_ENTITY_ANIM_CURRENT_TIME(Entity entity, const char* animDict, const char* animName)  // 0x346D81500D088F42
```

build 323

> Returns a float value representing animation's current playtime with respect to its total playtime. This value increasing in a range from [0 to 1] and wrap back to 0 when it reach 1.
> 
> Example:
> 0.000000 - mark the starting of animation.
> 0.500000 - mark the midpoint of the animation.
> 1.000000 - mark the end of animation.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## GET_ENTITY_ANIM_TOTAL_TIME

```c
float GET_ENTITY_ANIM_TOTAL_TIME(Entity entity, const char* animDict, const char* animName)  // 0x50BD2730B191E360
```

build 323

> Returns a float value representing animation's total playtime in milliseconds.
> 
> Example:
> GET_ENTITY_ANIM_TOTAL_TIME(PLAYER_ID(),"amb@world_human_yoga@female@base","base_b") 
> return 20800.000000
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## GET_ENTITY_ATTACHED_TO

```c
Entity GET_ENTITY_ATTACHED_TO(Entity entity)  // 0x48C2BED9180FE123
```

build 323

## GET_ENTITY_BONE_COUNT

```c
int GET_ENTITY_BONE_COUNT(Entity entity)  // 0xB328DCC3A3AA401B
```

build 791 · old names: `_GET_ENTITY_BONE_COUNT`

## GET_ENTITY_BONE_INDEX_BY_NAME

```c
int GET_ENTITY_BONE_INDEX_BY_NAME(Entity entity, const char* boneName)  // 0xFB71170B7E76ACBA
```

build 323

> Returns the index of the bone. If the bone was not found, -1 will be returned. 
> 
> list:
> https://pastebin.com/D7JMnX1g
> 
> BoneNames:
>   chassis,
>   windscreen,
>    seat_pside_r,
>  seat_dside_r,
>  bodyshell,
>     suspension_lm,
>     suspension_lr,
>     platelight,
>    attach_female,
>     attach_male,
>   bonnet,
>    boot,
>  chassis_dummy,  //Center of the dummy
>  chassis_Control,    //Not found yet
>    door_dside_f,   //Door left, front
>     door_dside_r,   //Door left, back
>  door_pside_f,   //Door right, front
>    door_pside_r,   //Door right, back
>     Gun_GripR,
>     windscreen_f,
>  platelight, //Position where the light above the numberplate is located
>    VFX_Emitter,
>   window_lf,  //Window left, front
>   window_lr,  //Window left, back
>    window_rf,  //Window right, front
>  window_rr,  //Window right, back
>   engine, //Position of the engine
>   gun_ammo,
>  ROPE_ATTATCH,   //Not misspelled. In script "finale_heist2b.c4".
>     wheel_lf,   //Wheel left, front
>    wheel_lr,   //Wheel left, back
>     wheel_rf,   //Wheel right, front
>   wheel_rr,   //Wheel right, back
>    exhaust,    //Exhaust. shows only the position of the stock-exhaust
>    overheat,   //A position on the engine(not exactly sure, how to name it)
>   misc_e, //Not a car-bone.
>  seat_dside_f,   //Driver-seat
>  seat_pside_f,   //Seat next to driver
>  Gun_Nuzzle,
>    seat_r
> 
> I doubt that the function is case-sensitive, since I found a "Chassis" and a "chassis". - Just tested: Definitely not case-sensitive.
> 
> 

## GET_ENTITY_BONE_OBJECT_POSTION

```c
Vector3 GET_ENTITY_BONE_OBJECT_POSTION(Entity entity, int boneIndex)  // 0xCF1247CC86961FD6
```

build 2802

## GET_ENTITY_BONE_OBJECT_ROTATION

```c
Vector3 GET_ENTITY_BONE_OBJECT_ROTATION(Entity entity, int boneIndex)  // 0xBD8D32550E5CEBFE
```

build 1734 · old names: `_GET_ENTITY_BONE_ROTATION_LOCAL`

> Gets the local rotation of the specified bone of the specified entity.

## GET_ENTITY_BONE_POSTION

```c
Vector3 GET_ENTITY_BONE_POSTION(Entity entity, int boneIndex)  // 0x46F8696933A63C9B
```

build 877 · old names: `_GET_WORLD_POSITION_OF_ENTITY_BONE_2`, `_GET_ENTITY_BONE_POSITION_2`

> Gets the world position of the specified bone of the specified entity.

## GET_ENTITY_BONE_ROTATION

```c
Vector3 GET_ENTITY_BONE_ROTATION(Entity entity, int boneIndex)  // 0xCE6294A232D03786
```

build 791 · old names: `_GET_WORLD_ROTATION_OF_ENTITY_BONE`, `_GET_ENTITY_BONE_ROTATION`

> Gets the world rotation of the specified bone of the specified entity.

## GET_ENTITY_CAN_BE_DAMAGED

```c
BOOL GET_ENTITY_CAN_BE_DAMAGED(Entity entity)  // 0xD95CC5D2AB15A09F
```

build 757 · old names: `_GET_ENTITY_CAN_BE_DAMAGED`

## GET_ENTITY_COLLISION_DISABLED

```c
BOOL GET_ENTITY_COLLISION_DISABLED(Entity entity)  // 0xCCF1E97BEFDAE480
```

build 323 · old names: `_GET_ENTITY_COLLISON_DISABLED`

## GET_ENTITY_COORDS

```c
Vector3 GET_ENTITY_COORDS(Entity entity, BOOL alive)  // 0x3FEF770D40960D5A
```

build 323

> Gets the current coordinates for a specified entity.
> `entity` = The entity to get the coordinates from.
> `alive` = Unused by the game, potentially used by debug builds of GTA in order to assert whether or not an entity was alive.

## GET_ENTITY_FORWARD_VECTOR

```c
Vector3 GET_ENTITY_FORWARD_VECTOR(Entity entity)  // 0x0A794A5A57F8DF91
```

build 323

> Gets the entity's forward vector.

## GET_ENTITY_FORWARD_X

```c
float GET_ENTITY_FORWARD_X(Entity entity)  // 0x8BB4EF4214E0E6D5
```

build 323

> Gets the X-component of the entity's forward vector.

## GET_ENTITY_FORWARD_Y

```c
float GET_ENTITY_FORWARD_Y(Entity entity)  // 0x866A4A5FAE349510
```

build 323

> Gets the Y-component of the entity's forward vector.

## GET_ENTITY_HEADING

```c
float GET_ENTITY_HEADING(Entity entity)  // 0xE83D4F9BA2A38914
```

build 323

> Returns the heading of the entity in degrees. Also know as the "Yaw" of an entity.

## GET_ENTITY_HEADING_FROM_EULERS

```c
float GET_ENTITY_HEADING_FROM_EULERS(Entity entity)  // 0x846BF6291198A71E
```

build 323 · old names: `_GET_ENTITY_PHYSICS_HEADING`

> Gets the heading of the entity physics in degrees, which tends to be more accurate than just "GET_ENTITY_HEADING". This can be clearly seen while, for example, ragdolling a ped/player.
> 
> NOTE: The name and description of this native are based on independent research. If you find this native to be more suitable under a different name and/or described differently, please feel free to do so.

## GET_ENTITY_HEALTH

```c
int GET_ENTITY_HEALTH(Entity entity)  // 0xEEF059FAD016D209
```

build 323

> Returns an integer value of entity's current health.
> 
> Example of range for ped:
> - Player [0 to 200]
> - Ped [100 to 200]
> - Vehicle [0 to 1000]
> - Object [0 to 1000]
> 
> Health is actually a float value but this native casts it to int.
> In order to get the actual value, do:
> float health = *(float *)(entityAddress + 0x280);

## GET_ENTITY_HEIGHT

```c
float GET_ENTITY_HEIGHT(Entity entity, float X, float Y, float Z, BOOL atTop, BOOL inWorldCoords)  // 0x5A504562485944DD
```

build 323

## GET_ENTITY_HEIGHT_ABOVE_GROUND

```c
float GET_ENTITY_HEIGHT_ABOVE_GROUND(Entity entity)  // 0x1DD55701034110E5
```

build 323

> Return height (z-dimension) above ground.
> Example: The pilot in a titan plane is 1.844176 above ground.

## GET_ENTITY_LOD_DIST

```c
int GET_ENTITY_LOD_DIST(Entity entity)  // 0x4159C2762B5791D6
```

build 323

> Returns the LOD distance of an entity.

## GET_ENTITY_MATRIX

```c
void GET_ENTITY_MATRIX(Entity entity, Vector3* forwardVector, Vector3* rightVector, Vector3* upVector, Vector3* position)  // 0xECB2FC7235A7D137
```

build 323

## GET_ENTITY_MAX_HEALTH

```c
int GET_ENTITY_MAX_HEALTH(Entity entity)  // 0x15D757606D170C3C
```

build 323

> Return an integer value of entity's maximum health.
> 
> Example:
> - Player = 200
> - Ped = 150

## GET_ENTITY_MODEL

```c
Hash GET_ENTITY_MODEL(Entity entity)  // 0x9F47B058362C84B5
```

build 323

> Returns the model hash from the entity

## GET_ENTITY_OF_TYPE_ATTACHED_TO_ENTITY

```c
Entity GET_ENTITY_OF_TYPE_ATTACHED_TO_ENTITY(Entity entity, Hash modelHash)  // 0x1F922734E259BD26
```

build 1180 · old names: `_GET_ENTITY_ATTACHED_TO_WITH_HASH`

> Gets the handle of an entity with a specific model hash attached to another entity, such as an object attached to a ped.
>  This native does not appear to have anything to do with pickups as in scripts it is used with objects.
> 
> Example from fm_mission_controller_2020.c:
> 
> iVar8 = ENTITY::GET_ENTITY_OF_TYPE_ATTACHED_TO_ENTITY(bParam0->f_9, joaat("p_cs_clipboard"));

## GET_ENTITY_PITCH

```c
float GET_ENTITY_PITCH(Entity entity)  // 0xD45DC2893621E1FE
```

build 323

## GET_ENTITY_POPULATION_TYPE

```c
int GET_ENTITY_POPULATION_TYPE(Entity entity)  // 0xF6F5161F4534EDFF
```

build 323

> A population type, from the following enum: https://alloc8or.re/gta5/doc/enums/ePopulationType.txt

## GET_ENTITY_PROOFS

```c
BOOL GET_ENTITY_PROOFS(Entity entity, BOOL* bulletProof, BOOL* fireProof, BOOL* explosionProof, BOOL* collisionProof, BOOL* meleeProof, BOOL* steamProof, BOOL* p7, BOOL* drownProof)  // 0xBE8CD9BE829BBEBF
```

build 1604 · old names: `_GET_ENTITY_PROOFS`

## GET_ENTITY_QUATERNION

```c
void GET_ENTITY_QUATERNION(Entity entity, float* x, float* y, float* z, float* w)  // 0x7B3703D2D32DFA18
```

build 323

> w is the correct parameter name!

## GET_ENTITY_ROLL

```c
float GET_ENTITY_ROLL(Entity entity)  // 0x831E0242595560DF
```

build 323

> Displays the current ROLL axis of the entity [-180.0000/180.0000+]
> (Sideways Roll) such as a vehicle tipped on its side

## GET_ENTITY_ROTATION

```c
Vector3 GET_ENTITY_ROTATION(Entity entity, int rotationOrder)  // 0xAFBD61CC738D9EB9
```

build 323

> rotationOrder is the order yaw, pitch and roll is applied. Usually 2. Returns a vector where the Z coordinate is the yaw.
> 
> rotationOrder refers to the order yaw pitch roll is applied; value ranges from 0 to 5 and is usually *2* in scripts.
> What you use for rotationOrder when getting must be the same as rotationOrder when setting the rotation.
> 
> What it returns is the yaw on the z part of the vector, which makes sense considering R* considers z as vertical. Here's a picture for those of you who don't understand pitch, yaw, and roll: https://web.archive.org/web/20160825124935/www.allstar.fiu.edu/aero/images/pic5-1.gif
> 
> Rotation Orders:
> 0: ZYX - Rotate around the z-axis, then the y-axis and finally the x-axis.
> 1: YZX - Rotate around the y-axis, then the z-axis and finally the x-axis.
> 2: ZXY - Rotate around the z-axis, then the x-axis and finally the y-axis.
> 3: XZY - Rotate around the x-axis, then the z-axis and finally the y-axis.
> 4: YXZ - Rotate around the y-axis, then the x-axis and finally the z-axis.
> 5: XYZ - Rotate around the x-axis, then the y-axis and finally the z-axis.

## GET_ENTITY_ROTATION_VELOCITY

```c
Vector3 GET_ENTITY_ROTATION_VELOCITY(Entity entity)  // 0x213B91045D09B983
```

build 323

## GET_ENTITY_SCRIPT

```c
const char* GET_ENTITY_SCRIPT(Entity entity, ScrHandle* script)  // 0xA6E9C38DB51D7748
```

build 323

> Returns the name of the script that owns/created the entity or nullptr. Second parameter is unused, can just be a nullptr.

## GET_ENTITY_SPEED

```c
float GET_ENTITY_SPEED(Entity entity)  // 0xD5037BA82E12416F
```

build 323

> result is in meters per second
> 
> ------------------------------------------------------------
> So would the conversion to mph and km/h, be along the lines of this.
> 
> float speed = GET_ENTITY_SPEED(veh);
> float kmh = (speed * 3.6);
> float mph = (speed * 2.236936);
> ------------------------------------------------------------

## GET_ENTITY_SPEED_VECTOR

```c
Vector3 GET_ENTITY_SPEED_VECTOR(Entity entity, BOOL relative)  // 0x9A8D700A51CB7B0D
```

build 323

> Relative can be used for getting speed relative to the frame of the vehicle, to determine for example, if you are going in reverse (-y speed) or not (+y speed). 

## GET_ENTITY_SUBMERGED_LEVEL

```c
float GET_ENTITY_SUBMERGED_LEVEL(Entity entity)  // 0xE81AFC1BC4CC41CE
```

build 323

> Get how much of the entity is submerged.  1.0f is whole entity.

## GET_ENTITY_TYPE

```c
int GET_ENTITY_TYPE(Entity entity)  // 0x8ACD366038D14505
```

build 323

> Returns:
> 0 = no entity
> 1 = ped
> 2 = vehicle
> 3 = object

## GET_ENTITY_UPRIGHT_VALUE

```c
float GET_ENTITY_UPRIGHT_VALUE(Entity entity)  // 0x95EED5A694951F9F
```

build 323

## GET_ENTITY_VELOCITY

```c
Vector3 GET_ENTITY_VELOCITY(Entity entity)  // 0x4805D2B1D8CF94A9
```

build 323

## GET_LAST_MATERIAL_HIT_BY_ENTITY

```c
Hash GET_LAST_MATERIAL_HIT_BY_ENTITY(Entity entity)  // 0x5C3D0A935F535C4C
```

build 323

## GET_NEAREST_PARTICIPANT_TO_ENTITY

```c
int GET_NEAREST_PARTICIPANT_TO_ENTITY(Entity entity)  // 0xFFBD7052D65BE0FF
```

build 2944

## GET_NEAREST_PLAYER_TO_ENTITY

```c
Player GET_NEAREST_PLAYER_TO_ENTITY(Entity entity)  // 0x7196842CB375CDB3
```

build 323

## GET_NEAREST_PLAYER_TO_ENTITY_ON_TEAM

```c
Player GET_NEAREST_PLAYER_TO_ENTITY_ON_TEAM(Entity entity, int team)  // 0x4DC9A62F844D9337
```

build 323

## GET_OBJECT_INDEX_FROM_ENTITY_INDEX

```c
Object GET_OBJECT_INDEX_FROM_ENTITY_INDEX(Entity entity)  // 0xD7E3B9735C0F89D6
```

build 323

> Simply returns whatever is passed to it (Regardless of whether the handle is valid or not).

## GET_OFFSET_FROM_ENTITY_GIVEN_WORLD_COORDS

```c
Vector3 GET_OFFSET_FROM_ENTITY_GIVEN_WORLD_COORDS(Entity entity, float posX, float posY, float posZ)  // 0x2274BC1C4885E333
```

build 323

> Converts world coords (posX - Z) to coords relative to the entity
> 
> Example:
> posX is given as 50
> entity's x coord is 40
> the returned x coord will then be 10 or -10, not sure haven't used this in a while (think it is 10 though).

## GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS

```c
Vector3 GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(Entity entity, float offsetX, float offsetY, float offsetZ)  // 0x1899F328B0E12848
```

build 323

> Offset values are relative to the entity.
> 
> x = left/right
> y = forward/backward
> z = up/down

## GET_PED_INDEX_FROM_ENTITY_INDEX

```c
Ped GET_PED_INDEX_FROM_ENTITY_INDEX(Entity entity)  // 0x04A2A40C73395041
```

build 323

> Simply returns whatever is passed to it (Regardless of whether the handle is valid or not).

## GET_VEHICLE_INDEX_FROM_ENTITY_INDEX

```c
Vehicle GET_VEHICLE_INDEX_FROM_ENTITY_INDEX(Entity entity)  // 0x4B53F92932ADFAC0
```

build 323

> Simply returns whatever is passed to it (Regardless of whether the handle is valid or not).

## GET_WORLD_POSITION_OF_ENTITY_BONE

```c
Vector3 GET_WORLD_POSITION_OF_ENTITY_BONE(Entity entity, int boneIndex)  // 0x44A8FCB8ED227738
```

build 323

> Returns the coordinates of an entity-bone.

## HAS_ANIM_EVENT_FIRED

```c
BOOL HAS_ANIM_EVENT_FIRED(Entity entity, Hash actionHash)  // 0xEAF4CD9EA3E7E922
```

build 323

> if (ENTITY::HAS_ANIM_EVENT_FIRED(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("CreateObject")))

## HAS_COLLISION_LOADED_AROUND_ENTITY

```c
BOOL HAS_COLLISION_LOADED_AROUND_ENTITY(Entity entity)  // 0xE9676F61BC0B3321
```

build 323

## HAS_ENTITY_ANIM_FINISHED

```c
BOOL HAS_ENTITY_ANIM_FINISHED(Entity entity, const char* animDict, const char* animName, int p3)  // 0x20B711662962B472
```

build 323

> P3 is always 3 as far as i cant tell
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## HAS_ENTITY_BEEN_DAMAGED_BY_ANY_OBJECT

```c
BOOL HAS_ENTITY_BEEN_DAMAGED_BY_ANY_OBJECT(Entity entity)  // 0x95EB9964FF5C5C65
```

build 323

## HAS_ENTITY_BEEN_DAMAGED_BY_ANY_PED

```c
BOOL HAS_ENTITY_BEEN_DAMAGED_BY_ANY_PED(Entity entity)  // 0x605F5A140F202491
```

build 323

## HAS_ENTITY_BEEN_DAMAGED_BY_ANY_VEHICLE

```c
BOOL HAS_ENTITY_BEEN_DAMAGED_BY_ANY_VEHICLE(Entity entity)  // 0xDFD5033FDBA0A9C8
```

build 323

## HAS_ENTITY_BEEN_DAMAGED_BY_ENTITY

```c
BOOL HAS_ENTITY_BEEN_DAMAGED_BY_ENTITY(Entity entity1, Entity entity2, BOOL p2)  // 0xC86D67D52A707CF8
```

build 323

> Entity 1 = Victim
> Entity 2 = Attacker
> 
> p2 seems to always be 1

## HAS_ENTITY_CLEAR_LOS_TO_ENTITY

```c
BOOL HAS_ENTITY_CLEAR_LOS_TO_ENTITY(Entity entity1, Entity entity2, int traceType)  // 0xFCDFF7B72D23A1AC
```

build 323

> traceType is always 17 in the scripts.
> 
> There is other codes used for traceType:
> 19 - in jewelry_prep1a
> 126 - in am_hunt_the_beast
> 256 & 287 - in fm_mission_controller

## HAS_ENTITY_CLEAR_LOS_TO_ENTITY_ADJUST_FOR_COVER

```c
BOOL HAS_ENTITY_CLEAR_LOS_TO_ENTITY_ADJUST_FOR_COVER(Entity entity1, Entity entity2, int traceType)  // 0x394BDE2A7BBA031E
```

build 1868 · old names: `_HAS_ENTITY_CLEAR_LOS_TO_ENTITY_2`

## HAS_ENTITY_CLEAR_LOS_TO_ENTITY_IN_FRONT

```c
BOOL HAS_ENTITY_CLEAR_LOS_TO_ENTITY_IN_FRONT(Entity entity1, Entity entity2)  // 0x0267D00AF114F17A
```

build 323

> Has the entity1 got a clear line of sight to the other entity2 from the direction entity1 is facing.
> This is one of the most CPU demanding BOOL natives in the game; avoid calling this in things like nested for-loops

## HAS_ENTITY_COLLIDED_WITH_ANYTHING

```c
BOOL HAS_ENTITY_COLLIDED_WITH_ANYTHING(Entity entity)  // 0x8BAD02F0368D9E14
```

build 323

> Called on tick.
> Tested with vehicles, returns true whenever the vehicle is touching any entity.
> 
> Note: for vehicles, the wheels can touch the ground and it will still return false, but if the body of the vehicle touches the ground, it will return true.

## IS_AN_ENTITY

```c
BOOL IS_AN_ENTITY(ScrHandle handle)  // 0x731EC8A916BD11A1
```

build 323

## IS_ENTITY_A_MISSION_ENTITY

```c
BOOL IS_ENTITY_A_MISSION_ENTITY(Entity entity)  // 0x0A7B270912999B3C
```

build 323

## IS_ENTITY_A_PED

```c
BOOL IS_ENTITY_A_PED(Entity entity)  // 0x524AC5ECEA15343E
```

build 323

## IS_ENTITY_A_VEHICLE

```c
BOOL IS_ENTITY_A_VEHICLE(Entity entity)  // 0x6AC7003FA6E5575E
```

build 323

## IS_ENTITY_AN_OBJECT

```c
BOOL IS_ENTITY_AN_OBJECT(Entity entity)  // 0x8D68C8FD0FACA94E
```

build 323

## IS_ENTITY_AT_COORD

```c
BOOL IS_ENTITY_AT_COORD(Entity entity, float xPos, float yPos, float zPos, float xSize, float ySize, float zSize, BOOL p7, BOOL p8, int p9)  // 0x20B60995556D004F
```

build 323

> Checks if entity is within x/y/zSize distance of x/y/z. 
> 
> Last three are unknown ints, almost always p7 = 0, p8 = 1, p9 = 0

## IS_ENTITY_AT_ENTITY

```c
BOOL IS_ENTITY_AT_ENTITY(Entity entity1, Entity entity2, float xSize, float ySize, float zSize, BOOL p5, BOOL p6, int p7)  // 0x751B70C3D034E187
```

build 323

> Checks if entity1 is within the box defined by x/y/zSize of entity2.
> 
> Last three parameters are almost alwasy p5 = 0, p6 = 1, p7 = 0

## IS_ENTITY_ATTACHED

```c
BOOL IS_ENTITY_ATTACHED(Entity entity)  // 0xB346476EF1A64897
```

build 323

> Whether the entity is attached to any other entity.

## IS_ENTITY_ATTACHED_TO_ANY_OBJECT

```c
BOOL IS_ENTITY_ATTACHED_TO_ANY_OBJECT(Entity entity)  // 0xCF511840CEEDE0CC
```

build 323

## IS_ENTITY_ATTACHED_TO_ANY_PED

```c
BOOL IS_ENTITY_ATTACHED_TO_ANY_PED(Entity entity)  // 0xB1632E9A5F988D11
```

build 323

## IS_ENTITY_ATTACHED_TO_ANY_VEHICLE

```c
BOOL IS_ENTITY_ATTACHED_TO_ANY_VEHICLE(Entity entity)  // 0x26AA915AD89BFB4B
```

build 323

## IS_ENTITY_ATTACHED_TO_ENTITY

```c
BOOL IS_ENTITY_ATTACHED_TO_ENTITY(Entity from, Entity to)  // 0xEFBE71898A993728
```

build 323

## IS_ENTITY_DEAD

```c
BOOL IS_ENTITY_DEAD(Entity entity, BOOL p1)  // 0x5F9532F3B5CC2551
```

build 323

## IS_ENTITY_IN_AIR

```c
BOOL IS_ENTITY_IN_AIR(Entity entity)  // 0x886E37EC497200B6
```

build 323

## IS_ENTITY_IN_ANGLED_AREA

```c
BOOL IS_ENTITY_IN_ANGLED_AREA(Entity entity, float x1, float y1, float z1, float x2, float y2, float z2, float width, BOOL debug, BOOL includeZ, Any p10)  // 0x51210CED3DA1C78A
```

build 323

> `p8` is a debug flag invoking functions in the same path as ``DRAW_MARKER``
> `p10` is some entity flag check, also used in `IS_ENTITY_AT_ENTITY`, `IS_ENTITY_IN_AREA`, and `IS_ENTITY_AT_COORD`.
> See IS_POINT_IN_ANGLED_AREA for the definition of an angled area.

## IS_ENTITY_IN_AREA

```c
BOOL IS_ENTITY_IN_AREA(Entity entity, float x1, float y1, float z1, float x2, float y2, float z2, BOOL p7, BOOL p8, Any p9)  // 0x54736AA40E271165
```

build 323

## IS_ENTITY_IN_WATER

```c
BOOL IS_ENTITY_IN_WATER(Entity entity)  // 0xCFB0A0D8EDD145A3
```

build 323

## IS_ENTITY_IN_ZONE

```c
BOOL IS_ENTITY_IN_ZONE(Entity entity, const char* zone)  // 0xB6463CF6AF527071
```

build 323

> Full list of zones by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/zones.json

## IS_ENTITY_OCCLUDED

```c
BOOL IS_ENTITY_OCCLUDED(Entity entity)  // 0xE31C2C72B8692B64
```

build 323

## IS_ENTITY_ON_SCREEN

```c
BOOL IS_ENTITY_ON_SCREEN(Entity entity)  // 0xE659E47AF827484B
```

build 323

> Returns true if the entity is in between the minimum and maximum values for the 2d screen coords. 
> This means that it will return true even if the entity is behind a wall for example, as long as you're looking at their location. 
> Chipping

## IS_ENTITY_PLAYING_ANIM

```c
BOOL IS_ENTITY_PLAYING_ANIM(Entity entity, const char* animDict, const char* animName, int taskFlag)  // 0x1F0B79228E461EC9
```

build 323

> See also PED::IS_SCRIPTED_SCENARIO_PED_USING_CONDITIONAL_ANIM
> 
> Taken from ENTITY::IS_ENTITY_PLAYING_ANIM(PLAYER::PLAYER_PED_ID(), "creatures@shark@move", "attack_player", 3)
> 
> p4 is always 3 in the scripts.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## IS_ENTITY_STATIC

```c
BOOL IS_ENTITY_STATIC(Entity entity)  // 0x1218E6886D3D8327
```

build 323

> a static ped will not react to natives like "APPLY_FORCE_TO_ENTITY" or "SET_ENTITY_VELOCITY" and oftentimes will not react to task-natives like "TASK::TASK_COMBAT_PED". The only way I know of to make one of these peds react is to ragdoll them (or sometimes to use CLEAR_PED_TASKS_IMMEDIATELY(). Static peds include almost all far-away peds, beach-combers, peds in certain scenarios, peds crossing a crosswalk, peds walking to get back into their cars, and others. If anyone knows how to make a ped non-static without ragdolling them, please edit this with the solution.

## IS_ENTITY_TOUCHING_ENTITY

```c
BOOL IS_ENTITY_TOUCHING_ENTITY(Entity entity, Entity targetEntity)  // 0x17FFC1B2BA35A494
```

build 323

## IS_ENTITY_TOUCHING_MODEL

```c
BOOL IS_ENTITY_TOUCHING_MODEL(Entity entity, Hash modelHash)  // 0x0F42323798A58C8C
```

build 323

## IS_ENTITY_UPRIGHT

```c
BOOL IS_ENTITY_UPRIGHT(Entity entity, float angle)  // 0x5333F526F6AB19AA
```

build 323

## IS_ENTITY_UPSIDEDOWN

```c
BOOL IS_ENTITY_UPSIDEDOWN(Entity entity)  // 0x1DBD58820FA61D71
```

build 323

## IS_ENTITY_VISIBLE

```c
BOOL IS_ENTITY_VISIBLE(Entity entity)  // 0x47D6F43D77935C75
```

build 323

## IS_ENTITY_VISIBLE_TO_SCRIPT

```c
BOOL IS_ENTITY_VISIBLE_TO_SCRIPT(Entity entity)  // 0xD796CB5BA8F20E32
```

build 323

## IS_ENTITY_WAITING_FOR_WORLD_COLLISION

```c
BOOL IS_ENTITY_WAITING_FOR_WORLD_COLLISION(Entity entity)  // 0xD05BFF0C0A12C68F
```

build 323

## PLAY_ENTITY_ANIM

```c
BOOL PLAY_ENTITY_ANIM(Entity entity, const char* animName, const char* animDict, float p3, BOOL loop, BOOL stayInAnim, BOOL p6, float delta, Any bitset)  // 0x7FB218262B810701
```

build 323

> delta and bitset are guessed fields. They are based on the fact that most of the calls have 0 or nil field types passed in.
> 
> The only time bitset has a value is 0x4000 and the only time delta has a value is during stealth with usually <1.0f values.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## PLAY_SYNCHRONIZED_ENTITY_ANIM

```c
BOOL PLAY_SYNCHRONIZED_ENTITY_ANIM(Entity entity, int syncedScene, const char* animation, const char* propName, float p4, float p5, Any p6, float p7)  // 0xC77720A12FE14A86
```

build 323

> p4 and p7 are usually 1000.0f.
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## PLAY_SYNCHRONIZED_MAP_ENTITY_ANIM

```c
BOOL PLAY_SYNCHRONIZED_MAP_ENTITY_ANIM(float x1, float y1, float z1, float x2, Any y2, float z2, const char* p6, const char* p7, float p8, float p9, Any p10, float p11)  // 0xB9C54555ED30FBC4
```

build 323

> p6,p7 probably animname and animdict
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## PROCESS_ENTITY_ATTACHMENTS

```c
void PROCESS_ENTITY_ATTACHMENTS(Entity entity)  // 0xF4080490ADC51C6F
```

build 323

> Called to update entity attachments.

## REMOVE_FORCED_OBJECT

```c
void REMOVE_FORCED_OBJECT(float x, float y, float z, float p3, Hash modelHash)  // 0x61B6775E83C0DB6F
```

build 323

## REMOVE_MODEL_HIDE

```c
void REMOVE_MODEL_HIDE(float x, float y, float z, float radius, Hash modelHash, BOOL p5)  // 0xD9E3006FB3CBD765
```

build 323

> This native makes entities visible that are hidden by the native CREATE_MODEL_HIDE.
> p5 should be false, true does nothing

## REMOVE_MODEL_SWAP

```c
void REMOVE_MODEL_SWAP(float x, float y, float z, float radius, Hash originalModel, Hash newModel, BOOL p6)  // 0x033C0F9A64E229AE
```

build 323

## RESET_ENTITY_ALPHA

```c
void RESET_ENTITY_ALPHA(Entity entity)  // 0x9B1E824FFBB7027A
```

build 323

## RESET_PICKUP_ENTITY_GLOW

```c
void RESET_PICKUP_ENTITY_GLOW(Entity entity)  // 0x490861B88F4FD846
```

build 944

> Similar to RESET_ENTITY_ALPHA

## SET_ALLOW_MIGRATE_TO_SPECTATOR

```c
void SET_ALLOW_MIGRATE_TO_SPECTATOR(Entity entity, Any p1)  // 0x36F32DE87082343E
```

build 1011

> p1 is always set to 1

## SET_CAN_AUTO_VAULT_ON_ENTITY

```c
void SET_CAN_AUTO_VAULT_ON_ENTITY(Entity entity, BOOL toggle)  // 0xE12ABE5E3A389A6C
```

build 323

> p1 always false.

## SET_CAN_CLIMB_ON_ENTITY

```c
void SET_CAN_CLIMB_ON_ENTITY(Entity entity, BOOL toggle)  // 0xA80AE305E0A3044F
```

build 323

> p1 always false.

## SET_ENTITY_ALPHA

```c
void SET_ENTITY_ALPHA(Entity entity, int alphaLevel, BOOL skin)  // 0x44A0870B7E92D7C0
```

build 323

> skin - everything alpha except skin
> Set entity alpha level. Ranging from 0 to 255 but chnages occur after every 20 percent (after every 51).

## SET_ENTITY_ALWAYS_PRERENDER

```c
void SET_ENTITY_ALWAYS_PRERENDER(Entity entity, BOOL toggle)  // 0xACAD101E1FB66689
```

build 323

## SET_ENTITY_ANGULAR_VELOCITY

```c
void SET_ENTITY_ANGULAR_VELOCITY(Entity entity, float x, float y, float z)  // 0x8339643499D1222E
```

build 2372 · old names: `_SET_ENTITY_ANGULAR_VELOCITY`

## SET_ENTITY_ANIM_CURRENT_TIME

```c
void SET_ENTITY_ANIM_CURRENT_TIME(Entity entity, const char* animDictionary, const char* animName, float time)  // 0x4487C259F0F70977
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## SET_ENTITY_ANIM_SPEED

```c
void SET_ENTITY_ANIM_SPEED(Entity entity, const char* animDictionary, const char* animName, float speedMultiplier)  // 0x28D1A16553C51776
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## SET_ENTITY_AS_MISSION_ENTITY

```c
void SET_ENTITY_AS_MISSION_ENTITY(Entity entity, BOOL bScriptHostObject, BOOL bGrabFromOtherScript)  // 0xAD738C3085FE7E11
```

build 323

> Makes the specified entity (ped, vehicle or object) persistent. Persistent entities will not automatically be removed by the engine.

## SET_ENTITY_AS_NO_LONGER_NEEDED

```c
void SET_ENTITY_AS_NO_LONGER_NEEDED(Entity* entity)  // 0xB736A491E64A32CF
```

build 323

> Marks the specified entity (ped, vehicle or object) as no longer needed if its population type is set to the mission type.
> If the entity is ped, it will also clear their tasks immediately just like when CLEAR_PED_TASKS_IMMEDIATELY is called.
> Entities marked as no longer needed, will be deleted as the engine sees fit.
> Use this if you just want to just let the game delete the ped:
> void MarkPedAsAmbientPed(Ped ped) {
>   auto addr = getScriptHandleBaseAddress(ped);
> 
>   if (!addr) {
>     return;
>   }
> 
>   //the game uses only lower 4 bits as entity population type 
>   BYTE origValue = *(BYTE *)(addr + 0xDA);
>   *(BYTE *)(addr + 0xDA) = ((origValue & 0xF0) | ePopulationType::POPTYPE_RANDOM_AMBIENT);
> }

## SET_ENTITY_CAN_BE_DAMAGED

```c
void SET_ENTITY_CAN_BE_DAMAGED(Entity entity, BOOL toggle)  // 0x1760FFA8AB074D66
```

build 323

## SET_ENTITY_CAN_BE_DAMAGED_BY_RELATIONSHIP_GROUP

```c
void SET_ENTITY_CAN_BE_DAMAGED_BY_RELATIONSHIP_GROUP(Entity entity, BOOL bCanBeDamaged, int relGroup)  // 0xE22D8FDE858B8119
```

build 323

## SET_ENTITY_CAN_BE_TARGETED_WITHOUT_LOS

```c
void SET_ENTITY_CAN_BE_TARGETED_WITHOUT_LOS(Entity entity, BOOL toggle)  // 0xD3997889736FD899
```

build 323

> Sets whether the entity can be targeted without being in line-of-sight.

## SET_ENTITY_CAN_ONLY_BE_DAMAGED_BY_ENTITY

```c
void SET_ENTITY_CAN_ONLY_BE_DAMAGED_BY_ENTITY(Entity entity1, Entity entity2)  // 0xB17BC6453F6CF5AC
```

build 944

## SET_ENTITY_CAN_ONLY_BE_DAMAGED_BY_SCRIPT_PARTICIPANTS

```c
void SET_ENTITY_CAN_ONLY_BE_DAMAGED_BY_SCRIPT_PARTICIPANTS(Entity entity, BOOL toggle)  // 0x352E2B5CF420BF3B
```

build 573

## SET_ENTITY_CANT_CAUSE_COLLISION_DAMAGED_ENTITY

```c
void SET_ENTITY_CANT_CAUSE_COLLISION_DAMAGED_ENTITY(Entity entity1, Entity entity2)  // 0x68B562E124CC0AEF
```

build 1180

## SET_ENTITY_COLLISION

```c
void SET_ENTITY_COLLISION(Entity entity, BOOL toggle, BOOL keepPhysics)  // 0x1A9205C1B9EE827F
```

build 323

## SET_ENTITY_COMPLETELY_DISABLE_COLLISION

```c
void SET_ENTITY_COMPLETELY_DISABLE_COLLISION(Entity entity, BOOL toggle, BOOL keepPhysics)  // 0x9EBC85ED0FFFE51C
```

build 323 · old names: `_SET_ENTITY_COLLISION_2`

## SET_ENTITY_COORDS

```c
void SET_ENTITY_COORDS(Entity entity, float xPos, float yPos, float zPos, BOOL xAxis, BOOL yAxis, BOOL zAxis, BOOL clearArea)  // 0x06843DA7060A026B
```

build 323

> p7 is always 1 in the scripts. Set to 1, an area around the destination coords for the moved entity is cleared from other entities. 
>  
> Often ends with 1, 0, 0, 1); in the scripts. It works. 
> 
> Axis - Invert Axis Flags

## SET_ENTITY_COORDS_NO_OFFSET

```c
void SET_ENTITY_COORDS_NO_OFFSET(Entity entity, float xPos, float yPos, float zPos, BOOL xAxis, BOOL yAxis, BOOL zAxis)  // 0x239A3351AC1DA385
```

build 323

> Axis - Invert Axis Flags

## SET_ENTITY_COORDS_WITHOUT_PLANTS_RESET

```c
void SET_ENTITY_COORDS_WITHOUT_PLANTS_RESET(Entity entity, float xPos, float yPos, float zPos, BOOL alive, BOOL deadFlag, BOOL ragdollFlag, BOOL clearArea)  // 0x621873ECE1178967
```

build 323 · old names: `_SET_ENTITY_COORDS_2`

## SET_ENTITY_DRAWABLE_LOD_THRESHOLDS

```c
void SET_ENTITY_DRAWABLE_LOD_THRESHOLDS(Entity entity, int highLod, int medLod, int lowLod, int vlowLod)  // 0xC12A19AC871A59C1
```

build 3889

## SET_ENTITY_DYNAMIC

```c
void SET_ENTITY_DYNAMIC(Entity entity, BOOL toggle)  // 0x1718DE8E3F2823CA
```

build 323

## SET_ENTITY_HAS_GRAVITY

```c
void SET_ENTITY_HAS_GRAVITY(Entity entity, BOOL toggle)  // 0x4A4722448F18EEF5
```

build 323

## SET_ENTITY_HEADING

```c
void SET_ENTITY_HEADING(Entity entity, float heading)  // 0x8E2530AA8ADA980E
```

build 323

> Set the heading of an entity in degrees also known as "Yaw".

## SET_ENTITY_HEALTH

```c
void SET_ENTITY_HEALTH(Entity entity, int health, Entity instigator, Hash weaponType)  // 0x6B76DC1F3AE6E6A3
```

build 323

> health >= 0
> male ped ~= 100 - 200
> female ped ~= 0 - 100

## SET_ENTITY_INVINCIBLE

```c
void SET_ENTITY_INVINCIBLE(Entity entity, BOOL toggle, BOOL dontResetOnCleanup)  // 0x3882114BDE571AD4
```

build 323

> Sets a ped or an object totally invincible. It doesn't take any kind of damage. Peds will not ragdoll on explosions and the tazer animation won't apply either.
> 
> If you use this for a ped and you want Ragdoll to stay enabled, then do:
> *(DWORD *)(pedAddress + 0x188) |= (1 << 9);
> 
> Use this if you want to get the invincibility status:
>   bool IsPedInvincible(Ped ped)
>  {
>      auto addr = getScriptHandleBaseAddress(ped);    
> 
>         if (addr)
>      {
>          DWORD flag = *(DWORD *)(addr + 0x188);
>             return ((flag & (1 << 8)) != 0) || ((flag & (1 << 9)) != 0);
>       }
> 
>        return false;
>  }

## SET_ENTITY_IS_IN_VEHICLE

```c
void SET_ENTITY_IS_IN_VEHICLE(Entity entity)  // 0x78E8E3A640178255
```

build 323

## SET_ENTITY_IS_TARGET_PRIORITY

```c
void SET_ENTITY_IS_TARGET_PRIORITY(Entity entity, BOOL p1, float p2)  // 0xEA02E132F5C68722
```

build 323

## SET_ENTITY_LIGHTS

```c
void SET_ENTITY_LIGHTS(Entity entity, BOOL toggle)  // 0x7CFBA6A80BDF3874
```

build 323

## SET_ENTITY_LOAD_COLLISION_FLAG

```c
void SET_ENTITY_LOAD_COLLISION_FLAG(Entity entity, BOOL toggle, Any p2)  // 0x0DC7CABAB1E9B67E
```

build 323

> Loads collision grid for an entity spawned outside of a player's loaded area. This allows peds to execute tasks rather than sit dormant because of a lack of a physics grid.
> Certainly not the main usage of this native but when set to true for a Vehicle, it will prevent the vehicle to explode if it is spawned far away from the player.

## SET_ENTITY_LOD_DIST

```c
void SET_ENTITY_LOD_DIST(Entity entity, int value)  // 0x5927F96A78577363
```

build 323

> LOD distance can be 0 to 0xFFFF (higher values will result in 0xFFFF) as it is actually stored as a 16-bit value (aka uint16_t).

## SET_ENTITY_MAX_HEALTH

```c
void SET_ENTITY_MAX_HEALTH(Entity entity, int value)  // 0x166E7CF68597D8B5
```

build 323

> For instance: ENTITY::SET_ENTITY_MAX_HEALTH(PLAYER::PLAYER_PED_ID(), 200); // director_mode.c4: 67849

## SET_ENTITY_MAX_SPEED

```c
void SET_ENTITY_MAX_SPEED(Entity entity, float speed)  // 0x0E46A3FCBDE2A1B1
```

build 323

## SET_ENTITY_MIRROR_REFLECTION_FLAG

```c
void SET_ENTITY_MIRROR_REFLECTION_FLAG(Entity entity, BOOL p1)  // 0xE66377CDDADA4810
```

build 1734

## SET_ENTITY_MOTION_BLUR

```c
void SET_ENTITY_MOTION_BLUR(Entity entity, BOOL toggle)  // 0x295D82A8559F9150
```

build 323

## SET_ENTITY_NO_COLLISION_ENTITY

```c
void SET_ENTITY_NO_COLLISION_ENTITY(Entity entity1, Entity entity2, BOOL thisFrameOnly)  // 0xA53ED5520C07654A
```

build 323

> Calling this function disables collision between two entities.
> The importance of the order for entity1 and entity2 is unclear.
> The third parameter, `thisFrame`, decides whether the collision is to be disabled until it is turned back on, or if it's just this frame.

## SET_ENTITY_NOWEAPONDECALS

```c
void SET_ENTITY_NOWEAPONDECALS(Entity entity, BOOL p1)  // 0x2C2E3DC128F44309
```

build 323 · old names: `_SET_ENTITY_DECALS_DISABLED`

## SET_ENTITY_ONLY_DAMAGED_BY_PLAYER

```c
void SET_ENTITY_ONLY_DAMAGED_BY_PLAYER(Entity entity, BOOL toggle)  // 0x79F020FF9EDC0748
```

build 323

## SET_ENTITY_ONLY_DAMAGED_BY_RELATIONSHIP_GROUP

```c
void SET_ENTITY_ONLY_DAMAGED_BY_RELATIONSHIP_GROUP(Entity entity, BOOL p1, Any p2)  // 0x7022BD828FA0B082
```

build 323

## SET_ENTITY_PROOFS

```c
void SET_ENTITY_PROOFS(Entity entity, BOOL bulletProof, BOOL fireProof, BOOL explosionProof, BOOL collisionProof, BOOL meleeProof, BOOL steamProof, BOOL dontResetOnCleanup, BOOL waterProof)  // 0xFAEE099C6F890BB8
```

build 323

> Enable / disable each type of damage.
> 
> waterProof is damage related to water not drowning
> --------------
> p7 is to to '1' in am_mp_property_ext/int: ENTITY::SET_ENTITY_PROOFS(uParam0->f_19, true, true, true, true, true, true, 1, true);
> 

## SET_ENTITY_QUATERNION

```c
void SET_ENTITY_QUATERNION(Entity entity, float x, float y, float z, float w)  // 0x77B21BE7AC540F07
```

build 323

> w is the correct parameter name!

## SET_ENTITY_RECORDS_COLLISIONS

```c
void SET_ENTITY_RECORDS_COLLISIONS(Entity entity, BOOL toggle)  // 0x0A50A1EEDAD01E65
```

build 323

## SET_ENTITY_RENDER_SCORCHED

```c
void SET_ENTITY_RENDER_SCORCHED(Entity entity, BOOL toggle)  // 0x730F5F8D3F0F2050
```

build 323

## SET_ENTITY_REQUIRES_MORE_EXPENSIVE_RIVER_CHECK

```c
void SET_ENTITY_REQUIRES_MORE_EXPENSIVE_RIVER_CHECK(Entity entity, BOOL toggle)  // 0x694E00132F2823ED
```

build 323

## SET_ENTITY_ROTATION

```c
void SET_ENTITY_ROTATION(Entity entity, float pitch, float roll, float yaw, int rotationOrder, BOOL p5)  // 0x8524A8B0171D5E07
```

build 323

> rotationOrder refers to the order yaw pitch roll is applied
> value ranges from 0 to 5. What you use for rotationOrder when setting must be the same as rotationOrder when getting the rotation. 
> Unsure what value corresponds to what rotation order, more testing will be needed for that.
> For the most part R* uses 1 or 2 as the order.
> p5 is usually set as true
> 

## SET_ENTITY_SHOULD_FREEZE_WAITING_ON_COLLISION

```c
void SET_ENTITY_SHOULD_FREEZE_WAITING_ON_COLLISION(Entity entity, BOOL toggle)  // 0x3910051CCECDB00C
```

build 323 · old names: `_SET_ENTITY_REGISTER`, `_SET_ENTITY_SOMETHING`, `_SET_ENTITY_CLEANUP_BY_ENGINE`

> True means it can be deleted by the engine when switching lobbies/missions/etc, false means the script is expected to clean it up.
> 
> "Allow Freeze If No Collision"

## SET_ENTITY_SORT_BIAS

```c
void SET_ENTITY_SORT_BIAS(Entity entity, float p1)  // 0x5C3B791D580E0BC2
```

build 323

> Only called once in the scripts.
> 
> Related to weapon objects.
> 

## SET_ENTITY_TRAFFICLIGHT_OVERRIDE

```c
void SET_ENTITY_TRAFFICLIGHT_OVERRIDE(Entity entity, int state)  // 0x57C5DB656185EAC4
```

build 323

> Example here: https://gtaforums.com/topic/830463-help-with-turning-lights-green-and-causing-peds-to-crash-into-each-other/#entry1068211340
> 
> 0 = green
> 1 = red
> 2 = yellow
> 3 = reset changes
> changing lights may not change the behavior of vehicles

## SET_ENTITY_USE_MAX_DISTANCE_FOR_WATER_REFLECTION

```c
void SET_ENTITY_USE_MAX_DISTANCE_FOR_WATER_REFLECTION(Entity entity, BOOL p1)  // 0x1A092BB0C3808B96
```

build 323

## SET_ENTITY_VELOCITY

```c
void SET_ENTITY_VELOCITY(Entity entity, float x, float y, float z)  // 0x1C99BB7B6E96D16F
```

build 323

> Note that the third parameter(denoted as z) is "up and down" with positive numbers encouraging upwards movement.

## SET_ENTITY_VISIBLE

```c
void SET_ENTITY_VISIBLE(Entity entity, BOOL toggle, BOOL p2)  // 0xEA1C610A04DB6BBB
```

build 323

> p2 is always 0.

## SET_ENTITY_WATER_REFLECTION_FLAG

```c
void SET_ENTITY_WATER_REFLECTION_FLAG(Entity entity, BOOL toggle)  // 0xC34BC448DA29F5E9
```

build 573

## SET_OBJECT_AS_NO_LONGER_NEEDED

```c
void SET_OBJECT_AS_NO_LONGER_NEEDED(Object* object)  // 0x3AE22DEB5BA5A3E6
```

build 323

> This is an alias of SET_ENTITY_AS_NO_LONGER_NEEDED.

## SET_PED_AS_NO_LONGER_NEEDED

```c
void SET_PED_AS_NO_LONGER_NEEDED(Ped* ped)  // 0x2595DD4236549CE3
```

build 323

> This is an alias of SET_ENTITY_AS_NO_LONGER_NEEDED.

## SET_PICK_UP_BY_CARGOBOB_DISABLED

```c
void SET_PICK_UP_BY_CARGOBOB_DISABLED(Entity entity, BOOL toggle)  // 0xD7B80E7C3BEFC396
```

build 1180

## SET_PICKUP_COLLIDES_WITH_PROJECTILES

```c
void SET_PICKUP_COLLIDES_WITH_PROJECTILES(Any p0, Any p1)  // 0xCEA7C8E1B48FF68C
```

build 678

## SET_VEHICLE_AS_NO_LONGER_NEEDED

```c
void SET_VEHICLE_AS_NO_LONGER_NEEDED(Vehicle* vehicle)  // 0x629BFA74418D6239
```

build 323

> This is an alias of SET_ENTITY_AS_NO_LONGER_NEEDED.

## SET_WAIT_FOR_COLLISIONS_BEFORE_PROBE

```c
void SET_WAIT_FOR_COLLISIONS_BEFORE_PROBE(Entity entity, BOOL toggle)  // 0xDC6F8601FAF2E893
```

build 323

> Only called within 1 script for x360. 'fm_mission_controller' and it used on an object. 
> 
> Ran after these 2 natives,
> set_object_targettable(uParam0, 0);
> set_entity_invincible(uParam0, 1);

## STOP_ENTITY_ANIM

```c
BOOL STOP_ENTITY_ANIM(Entity entity, const char* animation, const char* animGroup, float p3)  // 0x28004F88151E03E0
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> RAGEPluginHook list: docs.ragepluginhook.net/html/62951c37-a440-478c-b389-c471230ddfc5.htm

## STOP_SYNCHRONIZED_ENTITY_ANIM

```c
BOOL STOP_SYNCHRONIZED_ENTITY_ANIM(Entity entity, float p1, BOOL p2)  // 0x43D3807C077261E3
```

build 323

## STOP_SYNCHRONIZED_MAP_ENTITY_ANIM

```c
BOOL STOP_SYNCHRONIZED_MAP_ENTITY_ANIM(float x1, float y1, float z1, float x2, Any y2, float z2)  // 0x11E79CAB7183B6F5
```

build 323

## WOULD_ENTITY_BE_OCCLUDED

```c
BOOL WOULD_ENTITY_BE_OCCLUDED(Hash entityModelHash, float x, float y, float z, BOOL p4)  // 0xEE5D2A122E09EC42
```

build 323

