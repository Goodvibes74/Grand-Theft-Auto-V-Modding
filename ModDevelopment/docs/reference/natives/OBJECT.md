# OBJECT natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _SET_OBJECT_TARGETTABLE_BY_PLAYER

```c
void _SET_OBJECT_TARGETTABLE_BY_PLAYER(Object object, BOOL setFlag34, BOOL setFlag35)  // 0xB39F03368DB0CAA2
```

build 3258

> Sets the 34th and 35th object flags related to player peds.

## _SET_PICKUP_GLOW_DISABLED

```c
void _SET_PICKUP_GLOW_DISABLED(Pickup pickup, BOOL toggle)  // 0x08BD8BA5BDE2C2FA
```

build 3407

## ADD_DOOR_TO_SYSTEM

```c
void ADD_DOOR_TO_SYSTEM(Hash doorHash, Hash modelHash, float x, float y, float z, BOOL p5, BOOL scriptDoor, BOOL isLocal, Any p8)  // 0x6F8838D03D1DC226
```

build 323

> doorHash has to be unique. scriptDoor false; relies upon getNetworkGameScriptHandler. isLocal On true disables the creation CRequestDoorEvent's in DOOR_SYSTEM_SET_DOOR_STATE.
> p5 only set to true in single player native scripts.
> If scriptDoor is true, register the door on the script handler host (note: there's a hardcap on the number of script IDs that can be added to the system at a given time). If scriptDoor and isLocal are both false, the door is considered to be in a "Persists w/o netobj" state.
> 
> door hashes normally look like PROP_[int]_DOOR_[int] for interior doors and PROP_BUILDING_[int]_DOOR_[int] exterior doors but you can just make up your own hash if you want
> All doors need to be registered with ADD_DOOR_TO_SYSTEM before they can be manipulated with the door natives and the easiest way to get door models is just find the door in codewalker.
> 
> Example: AddDoorToSystem("PROP_43_DOOR_0", "hei_v_ilev_fh_heistdoor2", -1456.818, -520.5037, 69.67043, 0, 0, 0)

## ADD_EXTENDED_PICKUP_PROBE_AREA

```c
void ADD_EXTENDED_PICKUP_PROBE_AREA(float x, float y, float z, float radius)  // 0xD4A7A435B3710D05
```

build 1290

> Adds an area that seems to be related to pickup physics behavior.
> Max amount of areas is 10. Only works in multiplayer.

## ALLOW_ALL_PLAYERS_TO_COLLECT_PICKUPS_OF_TYPE

```c
void ALLOW_ALL_PLAYERS_TO_COLLECT_PICKUPS_OF_TYPE(Hash pickupHash)  // 0xFDC07C58E8AAB715
```

build 1734

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## ALLOW_DAMAGE_EVENTS_FOR_NON_NETWORKED_OBJECTS

```c
void ALLOW_DAMAGE_EVENTS_FOR_NON_NETWORKED_OBJECTS(BOOL value)  // 0xABDABF4E1EDECBFA
```

build 1365 · old names: `_SET_UNK_GLOBAL_BOOL_RELATED_TO_DAMAGE`

## ALLOW_PICKUP_ARROW_MARKER_WHEN_UNCOLLECTABLE

```c
void ALLOW_PICKUP_ARROW_MARKER_WHEN_UNCOLLECTABLE(Pickup pickup, BOOL toggle)  // 0x834344A414C7C85D
```

build 2372

## ALLOW_PICKUP_BY_NONE_PARTICIPANT

```c
void ALLOW_PICKUP_BY_NONE_PARTICIPANT(Pickup pickup, BOOL toggle)  // 0xAA059C615DE9DD03
```

build 1180

## ALLOW_PORTABLE_PICKUP_TO_MIGRATE_TO_NON_PARTICIPANTS

```c
void ALLOW_PORTABLE_PICKUP_TO_MIGRATE_TO_NON_PARTICIPANTS(Pickup pickup, BOOL toggle)  // 0x641F272B52E2F0F8
```

build 877

## ARE_ENTITIES_ENTIRELY_INSIDE_GARAGE

```c
BOOL ARE_ENTITIES_ENTIRELY_INSIDE_GARAGE(Hash garageHash, BOOL p1, BOOL p2, BOOL p3, Any p4)  // 0x85B6C850546FDDE2
```

build 323

## ATTACH_PORTABLE_PICKUP_TO_PED

```c
void ATTACH_PORTABLE_PICKUP_TO_PED(Object pickupObject, Ped ped)  // 0x8DC39368BDD57755
```

build 323

## BLOCK_PLAYERS_FOR_AMBIENT_PICKUP

```c
void BLOCK_PLAYERS_FOR_AMBIENT_PICKUP(Any p0, Any p1)  // 0x1E3F1B1B891A2AAA
```

build 573

## BREAK_OBJECT_FRAGMENT_CHILD

```c
void BREAK_OBJECT_FRAGMENT_CHILD(Object p0, Any p1, BOOL p2)  // 0xE7E4C198B0185900
```

build 323

## CLEAR_ALL_PICKUP_REWARD_TYPE_SUPPRESSION

```c
void CLEAR_ALL_PICKUP_REWARD_TYPE_SUPPRESSION()  // 0xA2C1F5E92AFE49ED
```

build 323

## CLEAR_EXTENDED_PICKUP_PROBE_AREAS

```c
void CLEAR_EXTENDED_PICKUP_PROBE_AREAS()  // 0xB7C6D80FB371659A
```

build 1290

> Clears all areas created by ADD_EXTENDED_PICKUP_PROBE_AREA

## CLEAR_GARAGE

```c
void CLEAR_GARAGE(Hash garageHash, BOOL isNetwork)  // 0xDA05194260CDCDF9
```

build 678 · old names: `_CLEAR_GARAGE_AREA`

## CLEAR_OBJECTS_INSIDE_GARAGE

```c
void CLEAR_OBJECTS_INSIDE_GARAGE(Hash garageHash, BOOL vehicles, BOOL peds, BOOL objects, BOOL isNetwork)  // 0x190428512B240692
```

build 323

## CLEAR_PICKUP_REWARD_TYPE_SUPPRESSION

```c
void CLEAR_PICKUP_REWARD_TYPE_SUPPRESSION(int rewardType)  // 0x762DB2D380B48D04
```

build 323

## CLOSE_ALL_BARRIERS_FOR_RACE

```c
void CLOSE_ALL_BARRIERS_FOR_RACE()  // 0x701FDA1E82076BA4
```

build 323

> Clears the fields sets by OPEN_ALL_BARRIERS_FOR_RACE and iterates over the global CDoor's bucket-list.
> Related to its "Pre-networked state"?

## CLOSE_SAFEHOUSE_GARAGES

```c
void CLOSE_SAFEHOUSE_GARAGES()  // 0x66A49D021870FE88
```

build 323

## CONVERT_OLD_PICKUP_TYPE_TO_NEW

```c
Hash CONVERT_OLD_PICKUP_TYPE_TO_NEW(Hash pickupHash)  // 0x5EAAD83F8CFB4575
```

build 323 · old names: `_GET_PICKUP_HASH`

> returns pickup hash.
> 
> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## CREATE_AMBIENT_PICKUP

```c
Object CREATE_AMBIENT_PICKUP(Hash pickupHash, float posX, float posY, float posZ, int flags, int value, Hash modelHash, BOOL p7, BOOL p8)  // 0x673966A0C0FD7171
```

build 323

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## CREATE_MONEY_PICKUPS

```c
void CREATE_MONEY_PICKUPS(float x, float y, float z, int value, int amount, Hash model)  // 0x0589B5E791CE9B2B
```

build 323

> Spawns one or more money pickups.
> 
> x: The X-component of the world position to spawn the money pickups at.
> y: The Y-component of the world position to spawn the money pickups at.
> z: The Z-component of the world position to spawn the money pickups at.
> value: The combined value of the pickups (in dollars).
> amount: The number of pickups to spawn.
> model: The model to use, or 0 for default money model.
> 
> Example:
> CREATE_MONEY_PICKUPS(x, y, z, 1000, 3, 0x684a97ae);
> 
> Spawns 3 spray cans that'll collectively give $1000 when picked up. (Three spray cans, each giving $334, $334, $332 = $1000).
> 
> ==============================================
> 
> Max is 2000 in MP. So if you put the amount to 20, but the value to $400,000 eg. They will only be able to pickup 20 - $2,000 bags. So, $40,000

## CREATE_NON_NETWORKED_AMBIENT_PICKUP

```c
Object CREATE_NON_NETWORKED_AMBIENT_PICKUP(Hash pickupHash, float posX, float posY, float posZ, int flags, int value, Hash modelHash, BOOL p7, BOOL p8)  // 0x9C93764223E29C50
```

build 2372 · old names: `_CREATE_NON_NETWORKED_AMBIENT_PICKUP`

## CREATE_NON_NETWORKED_PORTABLE_PICKUP

```c
Object CREATE_NON_NETWORKED_PORTABLE_PICKUP(Hash pickupHash, float x, float y, float z, BOOL placeOnGround, Hash modelHash)  // 0x125494B98A21AAF7
```

build 323 · old names: `_CREATE_PORTABLE_PICKUP_2`

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## CREATE_OBJECT

```c
Object CREATE_OBJECT(Hash modelHash, float x, float y, float z, BOOL isNetwork, BOOL bScriptHostObj, BOOL dynamic)  // 0x509D5878EB39E842
```

build 323

> List of object models that can be created without any additional effort like making sure ytyp is loaded etc: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ObjectList.ini

## CREATE_OBJECT_NO_OFFSET

```c
Object CREATE_OBJECT_NO_OFFSET(Hash modelHash, float x, float y, float z, BOOL isNetwork, BOOL bScriptHostObj, BOOL dynamic, Any p7)  // 0x9A294B2138ABB884
```

build 323

> List of object models that can be created without any additional effort like making sure ytyp is loaded etc: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ObjectList.ini

## CREATE_PICKUP

```c
Pickup CREATE_PICKUP(Hash pickupHash, float posX, float posY, float posZ, int p4, int value, BOOL p6, Hash modelHash)  // 0xFBA08C503DD5FA58
```

build 323

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## CREATE_PICKUP_ROTATE

```c
Pickup CREATE_PICKUP_ROTATE(Hash pickupHash, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, int flag, int amount, Any p9, BOOL p10, Hash modelHash)  // 0x891804727E0A98B7
```

build 323

> flags:
> 8 (1 << 3): place on ground
> 512 (1 << 9): spin around
> 
> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## CREATE_PORTABLE_PICKUP

```c
Object CREATE_PORTABLE_PICKUP(Hash pickupHash, float x, float y, float z, BOOL placeOnGround, Hash modelHash)  // 0x2EAF1FDB2FB55698
```

build 323

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## DAMAGE_OBJECT_FRAGMENT_CHILD

```c
void DAMAGE_OBJECT_FRAGMENT_CHILD(Any p0, Any p1, Any p2)  // 0xE05F6AEEFEB0BB02
```

build 1180

## DELETE_OBJECT

```c
void DELETE_OBJECT(Object* object)  // 0x539E0AE3E6634B9F
```

build 323

> Deletes the specified object, then sets the handle pointed to by the pointer to NULL.

## DETACH_PORTABLE_PICKUP_FROM_PED

```c
void DETACH_PORTABLE_PICKUP_FROM_PED(Object pickupObject)  // 0xCF463D1E9A0AECB1
```

build 323

## DISABLE_TIDYING_UP_IN_GARAGE

```c
void DISABLE_TIDYING_UP_IN_GARAGE(int id, BOOL toggle)  // 0x659F9D71F52843F8
```

build 1290

> Sets a flag. A valid id is 0x157DC10D

## DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS

```c
BOOL DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS(float x, float y, float z, float radius, Hash hash, BOOL p5)  // 0xBFA48E2FF417213F
```

build 323

> p5 is usually 0.

## DOES_PICKUP_EXIST

```c
BOOL DOES_PICKUP_EXIST(Pickup pickup)  // 0xAFC1CA75AD4074D1
```

build 323

## DOES_PICKUP_OBJECT_EXIST

```c
BOOL DOES_PICKUP_OBJECT_EXIST(Object pickupObject)  // 0xD9EFB6DBF7DAAEA3
```

build 323

## DOES_PICKUP_OF_TYPE_EXIST_IN_AREA

```c
BOOL DOES_PICKUP_OF_TYPE_EXIST_IN_AREA(Hash pickupHash, float x, float y, float z, float radius)  // 0xF9C36251F6E48E33
```

build 323 · old names: `_IS_PICKUP_WITHIN_RADIUS`

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## DOES_RAYFIRE_MAP_OBJECT_EXIST

```c
BOOL DOES_RAYFIRE_MAP_OBJECT_EXIST(Object object)  // 0x52AF537A0C5B8AAD
```

build 323 · old names: `_DOES_DES_OBJECT_EXIST`

> Returns true if a destructible object with this handle exists, false otherwise.  

## DOOR_SYSTEM_FIND_EXISTING_DOOR

```c
BOOL DOOR_SYSTEM_FIND_EXISTING_DOOR(float x, float y, float z, Hash modelHash, Hash* outDoorHash)  // 0x589F80B325CC82C5
```

build 323

> Search radius: 0.5

## DOOR_SYSTEM_GET_AUTOMATIC_DISTANCE

```c
float DOOR_SYSTEM_GET_AUTOMATIC_DISTANCE(Hash doorHash)  // 0xE851471AEFC3374F
```

build 1868 · old names: `_DOOR_SYSTEM_GET_AUTOMATIC_DISTANCE`

## DOOR_SYSTEM_GET_DOOR_PENDING_STATE

```c
int DOOR_SYSTEM_GET_DOOR_PENDING_STATE(Hash doorHash)  // 0x4BC2854478F3A749
```

build 323

## DOOR_SYSTEM_GET_DOOR_STATE

```c
int DOOR_SYSTEM_GET_DOOR_STATE(Hash doorHash)  // 0x160AA1B32F6139B8
```

build 323

## DOOR_SYSTEM_GET_IS_PHYSICS_LOADED

```c
BOOL DOOR_SYSTEM_GET_IS_PHYSICS_LOADED(Any p0)  // 0xDF97CDD4FC08FD34
```

build 323

## DOOR_SYSTEM_GET_IS_SPRING_REMOVED

```c
BOOL DOOR_SYSTEM_GET_IS_SPRING_REMOVED(Hash doorHash)  // 0x8562FD8AB1E94D39
```

build 3407

## DOOR_SYSTEM_GET_OPEN_RATIO

```c
float DOOR_SYSTEM_GET_OPEN_RATIO(Hash doorHash)  // 0x65499865FCA6E5EC
```

build 323

## DOOR_SYSTEM_SET_AUTOMATIC_DISTANCE

```c
void DOOR_SYSTEM_SET_AUTOMATIC_DISTANCE(Hash doorHash, float distance, BOOL requestDoor, BOOL forceUpdate)  // 0x9BA001CB45CBF627
```

build 323

> `forceUpdate` on true invokes DOOR_SYSTEM_SET_DOOR_STATE otherwise requestDoor is unused.

## DOOR_SYSTEM_SET_AUTOMATIC_RATE

```c
void DOOR_SYSTEM_SET_AUTOMATIC_RATE(Hash doorHash, float rate, BOOL requestDoor, BOOL forceUpdate)  // 0x03C27E13B42A0E82
```

build 323

> Includes networking check: ownership vs. or the door itself **isn't** networked.
> `forceUpdate` on true invokes DOOR_SYSTEM_SET_DOOR_STATE otherwise requestDoor is unused.

## DOOR_SYSTEM_SET_DOOR_OPEN_FOR_RACES

```c
void DOOR_SYSTEM_SET_DOOR_OPEN_FOR_RACES(Hash doorHash, BOOL p1)  // 0xA85A21582451E951
```

build 323

> Some property related to gates. Native name between ``DOOR_SYSTEM_SET_AUTOMATIC_RATE`` and ``DOOR_SYSTEM_SET_DOOR_STATE``.

## DOOR_SYSTEM_SET_DOOR_STATE

```c
void DOOR_SYSTEM_SET_DOOR_STATE(Hash doorHash, int state, BOOL requestDoor, BOOL forceUpdate)  // 0x6BAB9442830C7F53
```

build 323 · old names: `_SET_DOOR_ACCELERATION_LIMIT`

> Lockstates not applied and CNetObjDoor's not created until DOOR_SYSTEM_GET_IS_PHYSICS_LOADED returns true.
> `requestDoor` on true, and when door system is configured to, i.e., "persists w/o netobj", generate a CRequestDoorEvent.
> `forceUpdate` on true, forces an update on the door system (same path as netObjDoor_applyDoorStuff)
> Door lock states:
> 0: UNLOCKED
> 1: LOCKED
> 2: DOORSTATE_FORCE_LOCKED_UNTIL_OUT_OF_AREA
> 3: DOORSTATE_FORCE_UNLOCKED_THIS_FRAME
> 4: DOORSTATE_FORCE_LOCKED_THIS_FRAME
> 5: DOORSTATE_FORCE_OPEN_THIS_FRAME
> 6: DOORSTATE_FORCE_CLOSED_THIS_FRAME

## DOOR_SYSTEM_SET_HOLD_OPEN

```c
void DOOR_SYSTEM_SET_HOLD_OPEN(Hash doorHash, BOOL toggle)  // 0xD9B71952F78A2640
```

build 323

> Includes networking check: ownership vs. or the door itself **isn't** networked.

## DOOR_SYSTEM_SET_OPEN_RATIO

```c
void DOOR_SYSTEM_SET_OPEN_RATIO(Hash doorHash, float ajar, BOOL requestDoor, BOOL forceUpdate)  // 0xB6E6FBA95C7324AC
```

build 323 · old names: `_SET_DOOR_AJAR_ANGLE`

> Sets the ajar angle of a door.
> Ranges from -1.0 to 1.0, and 0.0 is closed / default.
> `forceUpdate` on true invokes DOOR_SYSTEM_SET_DOOR_STATE otherwise requestDoor is unused.

## DOOR_SYSTEM_SET_SPRING_REMOVED

```c
void DOOR_SYSTEM_SET_SPRING_REMOVED(Hash doorHash, BOOL removed, BOOL requestDoor, BOOL forceUpdate)  // 0xC485E07E4F0B7958
```

build 323

> Includes networking check: ownership vs. or the door itself **isn't** networked.
> `forceUpdate` on true invokes DOOR_SYSTEM_SET_DOOR_STATE otherwise requestDoor is unused.

## ENABLE_SAVING_IN_GARAGE

```c
void ENABLE_SAVING_IN_GARAGE(Hash garageHash, BOOL toggle)  // 0xF2E1A7133DD356A6
```

build 323

## FIX_OBJECT_FRAGMENT

```c
void FIX_OBJECT_FRAGMENT(Object object)  // 0xF9C1681347C8BD15
```

build 323

## FORCE_ACTIVATE_PHYSICS_ON_UNFIXED_PICKUP

```c
void FORCE_ACTIVATE_PHYSICS_ON_UNFIXED_PICKUP(Pickup pickup, BOOL toggle)  // 0x4C134B4DF76025D0
```

build 1180

## FORCE_PICKUP_REGENERATE

```c
void FORCE_PICKUP_REGENERATE(Any p0)  // 0x758A5C1B3B1E1990
```

build 1011

## FORCE_PICKUP_ROTATE_FACE_UP

```c
void FORCE_PICKUP_ROTATE_FACE_UP()  // 0x394CD08E31313C28
```

build 944

## FORCE_PORTABLE_PICKUP_LAST_ACCESSIBLE_POSITION_SETTING

```c
void FORCE_PORTABLE_PICKUP_LAST_ACCESSIBLE_POSITION_SETTING(Object object)  // 0x5CE2E45A5CE2E45A
```

build 2545

## GET_CLOSEST_OBJECT_OF_TYPE

```c
Object GET_CLOSEST_OBJECT_OF_TYPE(float x, float y, float z, float radius, Hash modelHash, BOOL isMission, BOOL p6, BOOL p7)  // 0xE143FA2249364369
```

build 323

> Has 8 params in the latest patches.
> 
> isMission - if true doesn't return mission objects

## GET_COORDS_AND_ROTATION_OF_CLOSEST_OBJECT_OF_TYPE

```c
BOOL GET_COORDS_AND_ROTATION_OF_CLOSEST_OBJECT_OF_TYPE(float x, float y, float z, float radius, Hash modelHash, Vector3* outPosition, Vector3* outRotation, int rotationOrder)  // 0x163F8B586BC95F2A
```

build 323

## GET_DEFAULT_AMMO_FOR_WEAPON_PICKUP

```c
int GET_DEFAULT_AMMO_FOR_WEAPON_PICKUP(Hash pickupHash)  // 0xDB41D07A45A6D4B7
```

build 323

## GET_HAS_OBJECT_BEEN_COMPLETELY_DESTROYED

```c
BOOL GET_HAS_OBJECT_BEEN_COMPLETELY_DESTROYED(Any p0)  // 0x2542269291C6AC84
```

build 1180

## GET_IS_ARTICULATED_JOINT_AT_MAX_ANGLE

```c
BOOL GET_IS_ARTICULATED_JOINT_AT_MAX_ANGLE(Any p0, Any p1)  // 0x3BD770D281982DB5
```

build 1604

## GET_IS_ARTICULATED_JOINT_AT_MIN_ANGLE

```c
BOOL GET_IS_ARTICULATED_JOINT_AT_MIN_ANGLE(Object object, Any p1)  // 0x43C677F1E1158005
```

build 1604 · old names: `_GET_IS_ARENA_PROP_PHYSICS_DISABLED`

## GET_OBJECT_FRAGMENT_DAMAGE_HEALTH

```c
float GET_OBJECT_FRAGMENT_DAMAGE_HEALTH(Any p0, BOOL p1)  // 0xB6FBFD079B8D0596
```

build 323

## GET_OBJECT_TINT_INDEX

```c
int GET_OBJECT_TINT_INDEX(Object object)  // 0xE84EB93729C5F36A
```

build 757 · old names: `_GET_OBJECT_TEXTURE_VARIATION`

## GET_OFFSET_FROM_COORD_AND_HEADING_IN_WORLD_COORDS

```c
Vector3 GET_OFFSET_FROM_COORD_AND_HEADING_IN_WORLD_COORDS(float xPos, float yPos, float zPos, float heading, float xOffset, float yOffset, float zOffset)  // 0x163E252DE035A133
```

build 323 · old names: `_GET_OBJECT_OFFSET_FROM_COORDS`

## GET_PICKUP_COORDS

```c
Vector3 GET_PICKUP_COORDS(Pickup pickup)  // 0x225B8B35C88029B3
```

build 323

## GET_PICKUP_GENERATION_RANGE_MULTIPLIER

```c
float GET_PICKUP_GENERATION_RANGE_MULTIPLIER()  // 0xB3ECA65C7317F174
```

build 944 · old names: `_GET_PICKUP_GENERATION_RANGE_MULTIPLIER`

## GET_PICKUP_OBJECT

```c
Object GET_PICKUP_OBJECT(Pickup pickup)  // 0x5099BC55630B25AE
```

build 323

## GET_PICKUP_TYPE_FROM_WEAPON_HASH

```c
Hash GET_PICKUP_TYPE_FROM_WEAPON_HASH(Hash weaponHash)  // 0xD6429A016084F1A5
```

build 1290 · old names: `_GET_PICKUP_HASH_FROM_WEAPON`

> Returns the pickup hash for the given weapon hash

## GET_RAYFIRE_MAP_OBJECT

```c
Object GET_RAYFIRE_MAP_OBJECT(float x, float y, float z, float radius, const char* name)  // 0xB48FCED898292E52
```

build 323 · old names: `_GET_DES_OBJECT`

> Example:
> OBJECT::GET_RAYFIRE_MAP_OBJECT(-809.9619750976562, 170.919, 75.7406997680664, 3.0, "des_tvsmash");

## GET_RAYFIRE_MAP_OBJECT_ANIM_PHASE

```c
float GET_RAYFIRE_MAP_OBJECT_ANIM_PHASE(Object object)  // 0x260EE4FDBDF4DB01
```

build 323 · old names: `_GET_DES_OBJECT_ANIM_PROGRESS`

> `object`: The des-object handle to get the animation progress from.
> Return value is a float between 0.0 and 1.0, 0.0 is the beginning of the animation, 1.0 is the end. Value resets to 0.0 instantly after reaching 1.0.

## GET_SAFE_PICKUP_COORDS

```c
Vector3 GET_SAFE_PICKUP_COORDS(float x, float y, float z, float p3, float p4)  // 0x6E16BC2503FF1FF0
```

build 323

## GET_STATE_OF_CLOSEST_DOOR_OF_TYPE

```c
void GET_STATE_OF_CLOSEST_DOOR_OF_TYPE(Hash type, float x, float y, float z, BOOL* locked, float* heading)  // 0xEDC1A5B84AEF33FF
```

build 323

> locked is 0 if no door is found
> locked is 0 if door is unlocked
> locked is 1 if door is found and unlocked.
> 
> -------------
> the locked bool is either 0(unlocked)(false) or 1(locked)(true)

## GET_STATE_OF_RAYFIRE_MAP_OBJECT

```c
int GET_STATE_OF_RAYFIRE_MAP_OBJECT(Object object)  // 0x899BA936634A322E
```

build 323 · old names: `_GET_DES_OBJECT_STATE`

> Get a destructible object's state.
> Substract 1 to get the real state.
> See SET_STATE_OF_RAYFIRE_MAP_OBJECT to see the different states
> For example, if the object just spawned (state 2), the native will return 3.

## GET_WEAPON_TYPE_FROM_PICKUP_TYPE

```c
Hash GET_WEAPON_TYPE_FROM_PICKUP_TYPE(Hash pickupHash)  // 0x08F96CA6C551AD51
```

build 323 · old names: `_GET_WEAPON_HASH_FROM_PICKUP`

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## HAS_CLOSEST_OBJECT_OF_TYPE_BEEN_BROKEN

```c
BOOL HAS_CLOSEST_OBJECT_OF_TYPE_BEEN_BROKEN(float p0, float p1, float p2, float p3, Hash modelHash, Any p5)  // 0x761B0E69AC4D007E
```

build 323

## HAS_CLOSEST_OBJECT_OF_TYPE_BEEN_COMPLETELY_DESTROYED

```c
BOOL HAS_CLOSEST_OBJECT_OF_TYPE_BEEN_COMPLETELY_DESTROYED(float x, float y, float z, float radius, Hash modelHash, BOOL p5)  // 0x46494A2475701343
```

build 323

## HAS_OBJECT_BEEN_BROKEN

```c
BOOL HAS_OBJECT_BEEN_BROKEN(Object object, Any p1)  // 0x8ABFB70C49CC43E2
```

build 323

## HAS_PICKUP_BEEN_COLLECTED

```c
BOOL HAS_PICKUP_BEEN_COLLECTED(Pickup pickup)  // 0x80EC48E6679313F9
```

build 323

## HIDE_PORTABLE_PICKUP_WHEN_DETACHED

```c
void HIDE_PORTABLE_PICKUP_WHEN_DETACHED(Object pickupObject, BOOL toggle)  // 0x867458251D47CCB2
```

build 463 · old names: `_HIDE_PICKUP`

## IS_ANY_ENTITY_ENTIRELY_INSIDE_GARAGE

```c
BOOL IS_ANY_ENTITY_ENTIRELY_INSIDE_GARAGE(Hash garageHash, BOOL p1, BOOL p2, BOOL p3, Any p4)  // 0x673ED815D6E323B7
```

build 323

## IS_ANY_OBJECT_NEAR_POINT

```c
BOOL IS_ANY_OBJECT_NEAR_POINT(float x, float y, float z, float range, BOOL p4)  // 0x397DC58FF00298D1
```

build 323

## IS_DOOR_CLOSED

```c
BOOL IS_DOOR_CLOSED(Hash doorHash)  // 0xC531EE8A1145A149
```

build 323

## IS_DOOR_REGISTERED_WITH_SYSTEM

```c
BOOL IS_DOOR_REGISTERED_WITH_SYSTEM(Hash doorHash)  // 0xC153C43EA202C8C1
```

build 323 · old names: `_DOES_DOOR_EXIST`

> if (OBJECT::IS_DOOR_REGISTERED_WITH_SYSTEM(doorHash)) 
> {
>     OBJECT::REMOVE_DOOR_FROM_SYSTEM(doorHash);
> }

## IS_GARAGE_EMPTY

```c
BOOL IS_GARAGE_EMPTY(Hash garageHash, BOOL p1, int p2)  // 0x90E47239EA1980B8
```

build 323

## IS_OBJECT_A_PICKUP

```c
BOOL IS_OBJECT_A_PICKUP(Object object)  // 0xFC481C641EBBD27D
```

build 1365

## IS_OBJECT_A_PORTABLE_PICKUP

```c
BOOL IS_OBJECT_A_PORTABLE_PICKUP(Object object)  // 0x0378C08504160D0D
```

build 323

## IS_OBJECT_ENTIRELY_INSIDE_GARAGE

```c
BOOL IS_OBJECT_ENTIRELY_INSIDE_GARAGE(Hash garageHash, Entity entity, float p2, int p3)  // 0x372EF6699146A1E4
```

build 323

> Despite the name, it does work for any entity type.

## IS_OBJECT_NEAR_POINT

```c
BOOL IS_OBJECT_NEAR_POINT(Hash objectHash, float x, float y, float z, float range)  // 0x8C90FE4B381BA60A
```

build 323

## IS_OBJECT_PARTIALLY_INSIDE_GARAGE

```c
BOOL IS_OBJECT_PARTIALLY_INSIDE_GARAGE(Hash garageHash, Entity entity, int p2)  // 0xF0EED5A6BC7B237A
```

build 323

> Despite the name, it does work for any entity type.

## IS_OBJECT_VISIBLE

```c
BOOL IS_OBJECT_VISIBLE(Object object)  // 0x8B32ACE6326A7546
```

build 323

## IS_PICKUP_WEAPON_OBJECT_VALID

```c
BOOL IS_PICKUP_WEAPON_OBJECT_VALID(Object object)  // 0x11D1E53A726891FE
```

build 323

## IS_PLAYER_ENTIRELY_INSIDE_GARAGE

```c
BOOL IS_PLAYER_ENTIRELY_INSIDE_GARAGE(Hash garageHash, Player player, float p2, int p3)  // 0x024A60DEB0EA69F0
```

build 323

## IS_PLAYER_PARTIALLY_INSIDE_GARAGE

```c
BOOL IS_PLAYER_PARTIALLY_INSIDE_GARAGE(Hash garageHash, Player player, int p2)  // 0x1761DC5D8471CBAA
```

build 323

## IS_POINT_IN_ANGLED_AREA

```c
BOOL IS_POINT_IN_ANGLED_AREA(float xPos, float yPos, float zPos, float x1, float y1, float z1, float x2, float y2, float z2, float width, BOOL debug, BOOL includeZ)  // 0x2A70BAE8883E4C81
```

build 323

> An angled area is an X-Z oriented rectangle with three parameters:
> 1. origin: the mid-point along a base edge of the rectangle;
> 2. extent: the mid-point of opposite base edge on the other Z;
> 3. width: the length of the base edge; (named derived from logging strings ``CNetworkRoadNodeWorldStateData``).
> 
> The oriented rectangle can then be derived from the direction of the two points (``norm(origin - extent)``), its orthonormal, and the width.

## IS_PROP_LIGHT_OVERRIDEN

```c
BOOL IS_PROP_LIGHT_OVERRIDEN(Object object)  // 0xADF084FB8F075D06
```

build 1604

## ONLY_CLEAN_UP_OBJECT_WHEN_OUT_OF_RANGE

```c
void ONLY_CLEAN_UP_OBJECT_WHEN_OUT_OF_RANGE(Object object)  // 0xADBE4809F19F927A
```

build 323 · old names: `_MARK_OBJECT_FOR_DELETION`

## OPEN_ALL_BARRIERS_FOR_RACE

```c
void OPEN_ALL_BARRIERS_FOR_RACE(BOOL p0)  // 0xC7F29CA00F46350E
```

build 323

## PLACE_OBJECT_ON_GROUND_OR_OBJECT_PROPERLY

```c
BOOL PLACE_OBJECT_ON_GROUND_OR_OBJECT_PROPERLY(Object object)  // 0xD76EEEF746057FD6
```

build 505 · old names: `_PLACE_OBJECT_ON_GROUND_PROPERLY_2`

## PLACE_OBJECT_ON_GROUND_PROPERLY

```c
BOOL PLACE_OBJECT_ON_GROUND_PROPERLY(Object object)  // 0x58A850EAEE20FAA3
```

build 323

## PLAY_OBJECT_AUTO_START_ANIM

```c
void PLAY_OBJECT_AUTO_START_ANIM(Any p0)  // 0x006E4B040ED37EC3
```

build 1868

## PREVENT_COLLECTION_OF_PORTABLE_PICKUP

```c
void PREVENT_COLLECTION_OF_PORTABLE_PICKUP(Object object, BOOL p1, BOOL p2)  // 0x92AEFB5F6E294023
```

build 323

## REMOVE_ALL_PICKUPS_OF_TYPE

```c
void REMOVE_ALL_PICKUPS_OF_TYPE(Hash pickupHash)  // 0x27F9D613092159CF
```

build 323

> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## REMOVE_DOOR_FROM_SYSTEM

```c
void REMOVE_DOOR_FROM_SYSTEM(Hash doorHash, Any p1)  // 0x464D8E1427156FE4
```

build 323

> CDoor and CDoorSystemData still internally allocated (and their associations between doorHash, modelHash, and coordinates).
> Only its NetObj removed and flag ``*(v2 + 192) |= 8u`` (1604 retail) toggled.

## REMOVE_OBJECT_HIGH_DETAIL_MODEL

```c
void REMOVE_OBJECT_HIGH_DETAIL_MODEL(Object object)  // 0x4A39DB43E47CF3AA
```

build 323

## REMOVE_PICKUP

```c
void REMOVE_PICKUP(Pickup pickup)  // 0x3288D8ACAECD2AB2
```

build 323

## RENDER_FAKE_PICKUP_GLOW

```c
void RENDER_FAKE_PICKUP_GLOW(float x, float y, float z, int colorIndex)  // 0x3430676B11CDF21D
```

build 323 · old names: `_HIGHLIGHT_PLACEMENT_COORDS`

> draws circular marker at pos
> -1 = none
> 0 = red
> 1 = green
> 2 = blue
> 3 = green larger
> 4 = nothing
> 5 = green small

## ROTATE_OBJECT

```c
BOOL ROTATE_OBJECT(Object object, float p1, float p2, BOOL p3)  // 0xAFE24E4D29249E4A
```

build 1734

## SET_ACTIVATE_OBJECT_PHYSICS_AS_SOON_AS_IT_IS_UNFROZEN

```c
void SET_ACTIVATE_OBJECT_PHYSICS_AS_SOON_AS_IT_IS_UNFROZEN(Object object, BOOL toggle)  // 0x406137F8EF90EAF5
```

build 323

## SET_CUSTOM_PICKUP_WEAPON_HASH

```c
void SET_CUSTOM_PICKUP_WEAPON_HASH(Hash pickupHash, Pickup pickup)  // 0x826D1EE4D1CAFC78
```

build 505

## SET_CUTSCENES_WEAPON_FLASHLIGHT_ON_THIS_FRAME

```c
void SET_CUTSCENES_WEAPON_FLASHLIGHT_ON_THIS_FRAME(Object object, BOOL toggle)  // 0xBCE595371A5FBAAF
```

build 323 · old names: `_SET_CREATE_WEAPON_OBJECT_LIGHT_SOURCE`

> Requires a component_at_*_flsh to be attached to the weapon object

## SET_DISABLE_COLLISIONS_BETWEEN_CARS_AND_CAR_PARACHUTE

```c
void SET_DISABLE_COLLISIONS_BETWEEN_CARS_AND_CAR_PARACHUTE(Any p0)  // 0x8CAAB2BD3EA58BD4
```

build 1011

## SET_DRIVE_ARTICULATED_JOINT

```c
void SET_DRIVE_ARTICULATED_JOINT(Object object, BOOL toggle, int p2)  // 0x911024442F4898F0
```

build 1604 · old names: `_SET_ENABLE_ARENA_PROP_PHYSICS`

> Activate the physics to: "xs_prop_arena_{flipper,wall,bollard,turntable,pit}"

## SET_DRIVE_ARTICULATED_JOINT_WITH_INFLICTOR

```c
void SET_DRIVE_ARTICULATED_JOINT_WITH_INFLICTOR(Object object, BOOL toggle, int p2, Ped ped)  // 0xB20834A7DD3D8896
```

build 1604 · old names: `_SET_ENABLE_ARENA_PROP_PHYSICS_ON_PED`

## SET_ENTITY_FLAG_RENDER_SMALL_SHADOW

```c
void SET_ENTITY_FLAG_RENDER_SMALL_SHADOW(Object object, BOOL toggle)  // 0xB2D0BDE54F0E8E5A
```

build 323

## SET_ENTITY_FLAG_SUPPRESS_SHADOW

```c
void SET_ENTITY_FLAG_SUPPRESS_SHADOW(Entity entity, BOOL toggle)  // 0xD05A3241B9A86F19
```

build 1180

> Sets entity+38 to C (when false) or 0xFF3f (when true)

## SET_FORCE_OBJECT_THIS_FRAME

```c
void SET_FORCE_OBJECT_THIS_FRAME(float x, float y, float z, float p3)  // 0xF538081986E49E9D
```

build 323

## SET_IS_OBJECT_ARTICULATED

```c
void SET_IS_OBJECT_ARTICULATED(Object object, BOOL toggle)  // 0x1C57C94A6446492A
```

build 1604

## SET_IS_OBJECT_BALL

```c
void SET_IS_OBJECT_BALL(Object object, BOOL toggle)  // 0xB5B7742424BD4445
```

build 1604

## SET_LOCAL_PLAYER_CAN_COLLECT_PORTABLE_PICKUPS

```c
void SET_LOCAL_PLAYER_CAN_COLLECT_PORTABLE_PICKUPS(BOOL toggle)  // 0x78857FC65CADB909
```

build 323

## SET_LOCAL_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_WITH_MODEL

```c
void SET_LOCAL_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_WITH_MODEL(Hash modelHash, BOOL toggle)  // 0x88EAEC617CD26926
```

build 323 · old names: `_SET_LOCAL_PLAYER_CAN_USE_PICKUPS_WITH_THIS_MODEL`

> Maximum amount of pickup models that can be disallowed is 30.

## SET_LOCKED_UNSTREAMED_IN_DOOR_OF_TYPE

```c
void SET_LOCKED_UNSTREAMED_IN_DOOR_OF_TYPE(Hash modelHash, float x, float y, float z, BOOL locked, float xRotMult, float yRotMult, float zRotMult)  // 0x9B12F9A24FABEDB0
```

build 323 · old names: `_DOOR_CONTROL`

> Hardcoded not to work in multiplayer environments.
> When you set locked to 0 the door open and to 1 the door close
> OBJECT::SET_LOCKED_UNSTREAMED_IN_DOOR_OF_TYPE(${prop_gate_prison_01}, 1845.0, 2605.0, 45.0, 0, 0.0, 50.0, 0);  //door open
> 
> OBJECT::SET_LOCKED_UNSTREAMED_IN_DOOR_OF_TYPE(${prop_gate_prison_01}, 1845.0, 2605.0, 45.0, 1, 0.0, 50.0, 0);  //door close

## SET_MAX_NUM_PORTABLE_PICKUPS_CARRIED_BY_PLAYER

```c
void SET_MAX_NUM_PORTABLE_PICKUPS_CARRIED_BY_PLAYER(Hash modelHash, int number)  // 0x0BF3B3BD47D79C08
```

build 323

## SET_OBJECT_ALLOW_LOW_LOD_BUOYANCY

```c
void SET_OBJECT_ALLOW_LOW_LOD_BUOYANCY(Object object, BOOL toggle)  // 0x4D89D607CB3DD1D2
```

build 323 · old names: `_SET_OBJECT_CAN_CLIMB_ON`

> Overrides the climbing/blocking flags of the object, used in the native scripts mostly for "prop_dock_bouy_*"

## SET_OBJECT_FORCE_VEHICLES_TO_AVOID

```c
void SET_OBJECT_FORCE_VEHICLES_TO_AVOID(Object object, BOOL toggle)  // 0x77F33F2CCF64B3AA
```

build 323 · old names: `_SET_OBJECT_SOMETHING`

> Overrides a flag on the object which determines if the object should be avoided by a vehicle in task CTaskVehicleGoToPointWithAvoidanceAutomobile.

## SET_OBJECT_GLOW_IN_SAME_TEAM

```c
void SET_OBJECT_GLOW_IN_SAME_TEAM(Pickup pickup)  // 0x62454A641B41F3C5
```

build 678

## SET_OBJECT_IS_A_PRESSURE_PLATE

```c
void SET_OBJECT_IS_A_PRESSURE_PLATE(Object object, BOOL toggle)  // 0x734E1714D077DA9A
```

build 1604

## SET_OBJECT_IS_SPECIAL_GOLFBALL

```c
void SET_OBJECT_IS_SPECIAL_GOLFBALL(Object object, BOOL toggle)  // 0xC6033D32241F6FB5
```

build 323

## SET_OBJECT_IS_VISIBLE_IN_MIRRORS

```c
void SET_OBJECT_IS_VISIBLE_IN_MIRRORS(Object object, BOOL toggle)  // 0x3B2FD68DB5F8331C
```

build 757 · old names: `_SET_OBJECT_COLOUR`

## SET_OBJECT_PHYSICS_PARAMS

```c
void SET_OBJECT_PHYSICS_PARAMS(Object object, float weight, float p2, float p3, float p4, float p5, float gravity, float p7, float p8, float p9, float p10, float buoyancy)  // 0xF6DF6E90DE7DF90F
```

build 323

> Adjust the physics parameters of a prop, or otherwise known as "object". This is useful for simulated gravity.
> 
> Other parameters seem to be unknown.
> 
> p2: seems to be weight and gravity related. Higher value makes the obj fall faster. Very sensitive?
> p3: seems similar to p2
> p4: makes obj fall slower the higher the value
> p5: similar to p4

## SET_OBJECT_SPEED_BOOST_AMOUNT

```c
void SET_OBJECT_SPEED_BOOST_AMOUNT(Object object, Any p1)  // 0x96EE0EBA0163DF80
```

build 791 · old names: `_SET_OBJECT_STUNT_PROP_SPEEDUP`

## SET_OBJECT_SPEED_BOOST_DURATION

```c
void SET_OBJECT_SPEED_BOOST_DURATION(Object object, float duration)  // 0xDF6CA0330F2E737B
```

build 791 · old names: `_SET_OBJECT_STUNT_PROP_DURATION`

## SET_OBJECT_TAKES_DAMAGE_FROM_COLLIDING_WITH_BUILDINGS

```c
void SET_OBJECT_TAKES_DAMAGE_FROM_COLLIDING_WITH_BUILDINGS(Any p0, BOOL p1)  // 0xEB6F1A9B5510A5D2
```

build 323

## SET_OBJECT_TARGETTABLE

```c
void SET_OBJECT_TARGETTABLE(Object object, BOOL targettable, Any p2)  // 0x8A7391690F5AFD81
```

build 323

## SET_OBJECT_TINT_INDEX

```c
void SET_OBJECT_TINT_INDEX(Object object, int tintIndex)  // 0x971DA0055324D033
```

build 323 · old names: `_SET_OBJECT_TEXTURE_VARIANT`, `_SET_OBJECT_TEXTURE_VARIATION`

## SET_ONLY_ALLOW_AMMO_COLLECTION_WHEN_LOW

```c
void SET_ONLY_ALLOW_AMMO_COLLECTION_WHEN_LOW(BOOL p0)  // 0x31F924B53EADDF65
```

build 323

## SET_PICKUP_GENERATION_RANGE_MULTIPLIER

```c
void SET_PICKUP_GENERATION_RANGE_MULTIPLIER(float multiplier)  // 0x318516E02DE3ECE2
```

build 323

## SET_PICKUP_GLOW_OFFSET

```c
void SET_PICKUP_GLOW_OFFSET(Pickup pickup, float p1)  // 0x0596843B34B95CE5
```

build 505

> p1 is always 0.51. This native is called before SET_PICKUP_REGENERATION_TIME in all occurances.

## SET_PICKUP_HIDDEN_WHEN_UNCOLLECTABLE

```c
void SET_PICKUP_HIDDEN_WHEN_UNCOLLECTABLE(Pickup pickup, BOOL toggle)  // 0x3ED2B83AB2E82799
```

build 757

## SET_PICKUP_OBJECT_ALPHA_WHEN_TRANSPARENT

```c
void SET_PICKUP_OBJECT_ALPHA_WHEN_TRANSPARENT(int p0)  // 0x8CFF648FBD7330F1
```

build 757

> p0 is either 0 or 50 in scripts.

## SET_PICKUP_OBJECT_ARROW_MARKER

```c
void SET_PICKUP_OBJECT_ARROW_MARKER(Pickup pickup, BOOL toggle)  // 0x39A5FB7EAF150840
```

build 678

## SET_PICKUP_OBJECT_COLLECTABLE_IN_VEHICLE

```c
void SET_PICKUP_OBJECT_COLLECTABLE_IN_VEHICLE(Pickup pickup)  // 0x7813E8B8C4AE4799
```

build 1734

## SET_PICKUP_OBJECT_GLOW_OFFSET

```c
void SET_PICKUP_OBJECT_GLOW_OFFSET(Pickup pickup, float p1, BOOL p2)  // 0xA08FE5E49BDC39DD
```

build 323

> p1 is always -0.2 in scripts and p2 is always true in scripts.

## SET_PICKUP_OBJECT_GLOW_WHEN_UNCOLLECTABLE

```c
void SET_PICKUP_OBJECT_GLOW_WHEN_UNCOLLECTABLE(Pickup pickup, BOOL toggle)  // 0x27F248C3FEBFAAD3
```

build 2372

## SET_PICKUP_OBJECT_TRANSPARENT_WHEN_UNCOLLECTABLE

```c
void SET_PICKUP_OBJECT_TRANSPARENT_WHEN_UNCOLLECTABLE(Pickup pickup, BOOL toggle)  // 0x8881C98A31117998
```

build 678

## SET_PICKUP_REGENERATION_TIME

```c
void SET_PICKUP_REGENERATION_TIME(Pickup pickup, int duration)  // 0x78015C9B4B3ECC9D
```

build 323

## SET_PICKUP_TRACK_DAMAGE_EVENTS

```c
void SET_PICKUP_TRACK_DAMAGE_EVENTS(Pickup pickup, BOOL toggle)  // 0xBFFE53AE7E67FCDC
```

build 1290

## SET_PICKUP_TRANSPARENT_WHEN_UNCOLLECTABLE

```c
void SET_PICKUP_TRANSPARENT_WHEN_UNCOLLECTABLE(Pickup pickup, BOOL toggle)  // 0x858EC9FD25DE04AA
```

build 757

## SET_PICKUP_UNCOLLECTABLE

```c
void SET_PICKUP_UNCOLLECTABLE(Pickup pickup, BOOL toggle)  // 0x1C1B69FAE509BA97
```

build 757

## SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE

```c
void SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE(Player player, Hash pickupHash, BOOL toggle)  // 0x616093EC6B139DD9
```

build 323 · old names: `_TOGGLE_USE_PICKUPS_FOR_PLAYER`

> Disabling/enabling a player from getting pickups. From the scripts:
> 
> OBJECT::SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE(PLAYER::PLAYER_ID(), ${pickup_portable_package}, 0);
> OBJECT::SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE(PLAYER::PLAYER_ID(), ${pickup_portable_package}, 0);
> OBJECT::SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE(PLAYER::PLAYER_ID(), ${pickup_portable_package}, 1);
> OBJECT::SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE(PLAYER::PLAYER_ID(), ${pickup_portable_package}, 0);
> OBJECT::SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE(PLAYER::PLAYER_ID(), ${pickup_armour_standard}, 0);
> OBJECT::SET_PLAYER_PERMITTED_TO_COLLECT_PICKUPS_OF_TYPE(PLAYER::PLAYER_ID(), ${pickup_armour_standard}, 1);
> 
> Full list of pickup types by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pickupTypes.json

## SET_PORTABLE_PICKUP_PERSIST

```c
void SET_PORTABLE_PICKUP_PERSIST(Pickup pickup, BOOL toggle)  // 0x46F3ADD1E2D5BAF2
```

build 877

## SET_PROJECTILES_SHOULD_EXPLODE_ON_CONTACT

```c
void SET_PROJECTILES_SHOULD_EXPLODE_ON_CONTACT(Entity entity, Any p1)  // 0x63ECF581BC70E363
```

build 1365

## SET_PROP_LIGHT_COLOR

```c
BOOL SET_PROP_LIGHT_COLOR(Object object, BOOL p1, int r, int g, int b)  // 0x5F048334B4A4E774
```

build 1493 · old names: `_SET_OBJECT_LIGHT_COLOR`

## SET_PROP_TINT_INDEX

```c
void SET_PROP_TINT_INDEX(Object object, int tintIndex)  // 0x31574B1B41268673
```

build 2189

## SET_STATE_OF_CLOSEST_DOOR_OF_TYPE

```c
void SET_STATE_OF_CLOSEST_DOOR_OF_TYPE(Hash type, float x, float y, float z, BOOL locked, float heading, BOOL p6)  // 0xF82D8F1926A02C3D
```

build 323

> Hardcoded to not work in multiplayer.
> 
> 
> Used to lock/unlock doors to interior areas of the game.
> 
> (Possible) Door Types:
> 
> https://pastebin.com/9S2m3qA4
> 
> Heading is either 1, 0 or -1 in the scripts. Means default closed(0) or opened either into(1) or out(-1) of the interior.
> Locked means that the heading is locked.  
> p6 is always 0. 
> 
> 225 door types, model names and coords found in stripclub.c4:
> https://pastebin.com/gywnbzsH
> 
> get door info: https://pastebin.com/i14rbekD

## SET_STATE_OF_RAYFIRE_MAP_OBJECT

```c
void SET_STATE_OF_RAYFIRE_MAP_OBJECT(Object object, int state)  // 0x5C29F698D404C5E1
```

build 323 · old names: `_SET_DES_OBJECT_STATE`

> Defines the state of a destructible object.
> Use the GET_RAYFIRE_MAP_OBJECT native to find an object's handle with its name / coords.
> State 2 == object just spawned
> State 4 == Beginning of the animation
> State 6 == Start animation
> State 9 == End of the animation

## SET_TEAM_PICKUP_OBJECT

```c
void SET_TEAM_PICKUP_OBJECT(Object object, Any p1, BOOL p2)  // 0x53E0DF1A2A3CF0CA
```

build 323

## SET_TINT_INDEX_CLOSEST_BUILDING_OF_TYPE

```c
BOOL SET_TINT_INDEX_CLOSEST_BUILDING_OF_TYPE(float x, float y, float z, float radius, Hash modelHash, int tintIndex)  // 0xF12E33034D887F66
```

build 1103 · old names: `_SET_TEXTURE_VARIATION_OF_CLOSEST_OBJECT_OF_TYPE`

## SET_WEAPON_IMPACTS_APPLY_GREATER_FORCE

```c
void SET_WEAPON_IMPACTS_APPLY_GREATER_FORCE(Object object, BOOL p1)  // 0x1A6CBB06E2D0D79D
```

build 1604

## SLIDE_OBJECT

```c
BOOL SLIDE_OBJECT(Object object, float toX, float toY, float toZ, float speedX, float speedY, float speedZ, BOOL collision)  // 0x2FDFF4107B8C1147
```

build 323

> Returns true if the object has finished moving.
> 
> If false, moves the object towards the specified X, Y and Z coordinates with the specified X, Y and Z speed.
> 
> See also: https://gtagmodding.com/opcode-database/opcode/034E/
> Has to be looped until it returns true.

## SUPPRESS_PICKUP_REWARD_TYPE

```c
void SUPPRESS_PICKUP_REWARD_TYPE(int rewardType, BOOL suppress)  // 0xF92099527DB8E2A7
```

build 323

> enum ePickupRewardType
> {
> 	PICKUP_REWARD_TYPE_NONE = 0,
> 	PICKUP_REWARD_TYPE_AMMO = (1 << 0),
> 	PICKUP_REWARD_TYPE_BULLET_MP = (1 << 1),
> 	PICKUP_REWARD_TYPE_MISSILE_MP = (1 << 2),
> 	PICKUP_REWARD_TYPE_GRENADE_LAUNCHER_MP = (1 << 3),
> 	PICKUP_REWARD_TYPE_ARMOUR = (1 << 4),
> 	PICKUP_REWARD_TYPE_HEALTH = (1 << 5),
> 	PICKUP_REWARD_TYPE_HEALTH_VARIABLE = PICKUP_REWARD_TYPE_HEALTH,
> 	PICKUP_REWARD_TYPE_MONEY_FIXED = (1 << 6),
> 	PICKUP_REWARD_TYPE_MONEY_VARIABLE = PICKUP_REWARD_TYPE_MONEY_FIXED,
> 	PICKUP_REWARD_TYPE_WEAPON = (1 << 7),
> 	PICKUP_REWARD_TYPE_STAT = (1 << 8),
> 	PICKUP_REWARD_TYPE_STAT_VARIABLE = PICKUP_REWARD_TYPE_STAT,
> 	PICKUP_REWARD_TYPE_VEHICLE_FIX = (1 << 9),
> 	PICKUP_REWARD_TYPE_FIREWORK_MP = (1 << 10),
> 	PICKUP_REWARD_TYPE_ALL = (1 << 11) - 1
> };

## SUPPRESS_PICKUP_SOUND_FOR_PICKUP

```c
void SUPPRESS_PICKUP_SOUND_FOR_PICKUP(Any p0, Any p1)  // 0x8DCA505A5C196F05
```

build 1180

## TRACK_OBJECT_VISIBILITY

```c
void TRACK_OBJECT_VISIBILITY(Object object)  // 0xB252BC036B525623
```

build 323

