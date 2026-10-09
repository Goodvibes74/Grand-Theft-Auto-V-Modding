# VEHICLE natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _ARE_MISSILE_BAYS_DEPLOYED

```c
BOOL _ARE_MISSILE_BAYS_DEPLOYED(Vehicle vehicle)  // 0xEA4743874D515F13
```

build 2944

## _ENABLE_INDIVIDUAL_PLANE_PROPELLER

```c
void _ENABLE_INDIVIDUAL_PLANE_PROPELLER(Vehicle vehicle, int propeller)  // 0xDC05D2777F855F44
```

build 3407

## _GET_IS_VEHICLE_ELECTRIC

```c
BOOL _GET_IS_VEHICLE_ELECTRIC(Hash vehicleModel)  // 0x1FCB07FE230B6639
```

build 3258

## _GET_MISSION_TRAIN_CONFIG_INDEX_BY_NAME

```c
int _GET_MISSION_TRAIN_CONFIG_INDEX_BY_NAME(const char* name)  // 0x7DFAD92A34F09C00
```

build 3717

## _GET_REMAINING_NITROUS_DURATION

```c
float _GET_REMAINING_NITROUS_DURATION(Vehicle vehicle)  // 0xBEC4B8653462450E
```

build 3095

## _GET_VEHICLE_ALLOW_HOMING_MISSLE_LOCKON_SYNCED

```c
BOOL _GET_VEHICLE_ALLOW_HOMING_MISSLE_LOCKON_SYNCED(Vehicle vehicle)  // 0x613A431BCD5A22EB
```

build 3717

## _GET_VEHICLE_CURRENT_DRIVE_GEAR

```c
int _GET_VEHICLE_CURRENT_DRIVE_GEAR(Vehicle vehicle)  // 0x56185A25D45A0DCD
```

build 3095

## _GET_VEHICLE_CURRENT_REV_RATIO

```c
float _GET_VEHICLE_CURRENT_REV_RATIO(Vehicle vehicle)  // 0xF9DDA40BC293A61E
```

build 3095

## _GET_VEHICLE_DESIRED_DRIVE_GEAR

```c
int _GET_VEHICLE_DESIRED_DRIVE_GEAR(Vehicle vehicle)  // 0xFD8CE53356B5D745
```

build 3095

## _GET_VEHICLE_DRIVETRAIN_TYPE

```c
int _GET_VEHICLE_DRIVETRAIN_TYPE(Hash vehicleModel)  // 0x1423725069EE1D14
```

build 3258

> Returns the vehicle's drivetrain type.
> 
> enum eVehicleDrivetrainType
> {
> 	VehicleDrivetrainType_INVALID,
> 	VehicleDrivetrainType_FWD,
> 	VehicleDrivetrainType_RWD,
> 	VehicleDrivetrainType_AWD
> };
> 
> _GET_VEHICLE_DE* - _GET_VEHICLE_DI*

## _GET_VEHICLE_EXHAUST_BONE

```c
BOOL _GET_VEHICLE_EXHAUST_BONE(Vehicle vehicle, int index, int* boneIndex, BOOL* axisX)  // 0xE728F090D538CB18
```

build 3095

## _GET_VEHICLE_MAX_DRIVE_GEAR_COUNT

```c
int _GET_VEHICLE_MAX_DRIVE_GEAR_COUNT(Vehicle vehicle)  // 0x24910C3D66BA770D
```

build 3095

## _GET_VEHICLE_MAX_EXHAUST_BONE_COUNT

```c
int _GET_VEHICLE_MAX_EXHAUST_BONE_COUNT()  // 0x3EE18B00CD86C54F
```

build 3095

## _GET_VEHICLE_MODEL_NUM_DRIVE_GEARS

```c
int _GET_VEHICLE_MODEL_NUM_DRIVE_GEARS(Hash vehicleModel)  // 0x61F02E4E9A7A61EA
```

build 3095

## _GET_VEHICLE_THROTTLE

```c
float _GET_VEHICLE_THROTTLE(Vehicle vehicle)  // 0x92D96892FC06AF22
```

build 3095

## _GET_VEHICLE_TRAILER_PARENT_VEHICLE

```c
Vehicle _GET_VEHICLE_TRAILER_PARENT_VEHICLE(Vehicle trailer)  // 0x80D9D32636369C92
```

build 2802

## _IS_VEHICLE_GEN9_EXCLUSIVE_MODEL

```c
BOOL _IS_VEHICLE_GEN9_EXCLUSIVE_MODEL(Hash vehicleModel)  // 0x6638C0F19DE692FE
```

build 3095

## _IS_VEHICLE_ON_BOOST_PAD

```c
BOOL _IS_VEHICLE_ON_BOOST_PAD(Vehicle vehicle)  // 0x71C6302CBCA6CA35
```

build 3407

## _SET_ALLOW_COLLISION_WHEN_IN_VEHICLE

```c
void _SET_ALLOW_COLLISION_WHEN_IN_VEHICLE(Vehicle vehicle, BOOL toggle)  // 0x27D27223E8EF22ED
```

build 3095

> _SET_ALLOW_R* - _SET_ALLOW_V*

## _SET_ATTACHED_VEHICLE_TO_TOW_TRUCK_ARM

```c
void _SET_ATTACHED_VEHICLE_TO_TOW_TRUCK_ARM(Vehicle towTruck, Vehicle vehicle)  // 0x48BD57D0DD17786A
```

build 3095

## _SET_BOUNDS_AFFECT_WATER_PROBES

```c
void _SET_BOUNDS_AFFECT_WATER_PROBES(Vehicle vehicle, BOOL toggle)  // 0x85FC953F6C6CBDE1
```

build 2802

> Use the vehicle bounds (instead of viewport) when deciding if a vehicle is sufficiently above the water (waterheight.dat), bypassing wave simulation checks

## _SET_DEPLOY_MISSILE_BAYS

```c
void _SET_DEPLOY_MISSILE_BAYS(Vehicle vehicle, BOOL deploy)  // 0x0C02468829E4AA65
```

build 2944

## _SET_DISABLE_EXPLODE_FROM_BODY_DAMAGE_RECEIVED_BY_AI_VEHICLE

```c
void _SET_DISABLE_EXPLODE_FROM_BODY_DAMAGE_RECEIVED_BY_AI_VEHICLE(Vehicle vehicle, BOOL disable)  // 0xB0B7DF5CB876FF5E
```

build 3407

> Prevents the vehicle from exploding when taking body damage if the inflictor is an AI-controlled vehicle. Only works for planes.

## _SET_DRIFT_SLIP_ANGLE_LIMITS

```c
void _SET_DRIFT_SLIP_ANGLE_LIMITS(Vehicle vehicle, float durationScalar, float amplitudeScalar, float slipAngleLimit)  // 0xDAF4C98C18AC6F06
```

build 3095

> First two floats relate to rumble, the last is a threshold

## _SET_MAKE_TRAIN_SCAN_FOR_BLOCKING_ENTITIES

```c
void _SET_MAKE_TRAIN_SCAN_FOR_BLOCKING_ENTITIES(Vehicle train, BOOL toggle)  // 0x559B6073DB7FFFF9
```

build 3717

## _SET_MINIMUM_TIME_BETWEEN_GEAR_SHIFTS

```c
void _SET_MINIMUM_TIME_BETWEEN_GEAR_SHIFTS(Vehicle vehicle, int time)  // 0x16CFBC5E7EB32861
```

build 3095

## _SET_NITROUS_IS_VISIBLE

```c
void _SET_NITROUS_IS_VISIBLE(Vehicle vehicle, BOOL enabled)  // 0x465EEA70AF251045
```

build 3095

## _SET_OVERRIDE_TRACTION_LOSS_MULTIPLIER

```c
void _SET_OVERRIDE_TRACTION_LOSS_MULTIPLIER(Vehicle vehicle, float modifier)  // 0xAFD262ACCA64479A
```

build 3095

## _SET_PLANE_AVOIDS_OTHERS

```c
void _SET_PLANE_AVOIDS_OTHERS(Vehicle vehicle, BOOL toggle)  // 0xBAFB99B304BC52A7
```

build 3407

## _SET_REMAINING_NITROUS_DURATION

```c
void _SET_REMAINING_NITROUS_DURATION(Vehicle vehicle, float duration)  // 0x1AD0F63A94E10EFF
```

build 3407

## _SET_TRANSMISSION_REDUCED_GEAR_RATIO

```c
void _SET_TRANSMISSION_REDUCED_GEAR_RATIO(Vehicle vehicle, BOOL toggle)  // 0x337EF33DA3DDB990
```

build 3095

## _SET_VEHICLE_EXPLOSIVE_DAMAGE_SCALE

```c
Any _SET_VEHICLE_EXPLOSIVE_DAMAGE_SCALE(Vehicle vehicle, float scale)  // 0x84D7FFD223CAAFFD
```

build 3407

> Does not actually return anything.

## _SET_VEHICLE_MAX_LAUNCH_ENGINE_REVS

```c
void _SET_VEHICLE_MAX_LAUNCH_ENGINE_REVS(Vehicle vehicle, float modifier)  // 0x5AE614ECA5FDD423
```

build 3095

> 0.0f = engine rev minimum
> 1.0f = engine rev limit

## _SET_VEHICLE_USE_HORN_BUTTON_FOR_NITROUS

```c
void _SET_VEHICLE_USE_HORN_BUTTON_FOR_NITROUS(BOOL toggle)  // 0x1980F68872CC2C3D
```

build 3095

## ADD_ROAD_NODE_SPEED_ZONE

```c
int ADD_ROAD_NODE_SPEED_ZONE(float x, float y, float z, float radius, float speed, BOOL p5)  // 0x2CE544C68FB812A0
```

build 323 · old names: `_ADD_SPEED_ZONE_FOR_COORD`

## ADD_VEHICLE_COMBAT_ANGLED_AVOIDANCE_AREA

```c
int ADD_VEHICLE_COMBAT_ANGLED_AVOIDANCE_AREA(float p0, float p1, float p2, float p3, float p4, float p5, float p6)  // 0x54B0F614960F4A5F
```

build 323 · old names: `_ADD_VEHICLE_COMBAT_AVOIDANCE_AREA`

## ADD_VEHICLE_PHONE_EXPLOSIVE_DEVICE

```c
void ADD_VEHICLE_PHONE_EXPLOSIVE_DEVICE(Vehicle vehicle)  // 0x99AD4CCCB128CBC9
```

build 323

## ADD_VEHICLE_STUCK_CHECK_WITH_WARP

```c
void ADD_VEHICLE_STUCK_CHECK_WITH_WARP(Any p0, float p1, Any p2, BOOL p3, BOOL p4, BOOL p5, Any p6)  // 0x2FA9923062DD396C
```

build 323

## ADD_VEHICLE_UPSIDEDOWN_CHECK

```c
void ADD_VEHICLE_UPSIDEDOWN_CHECK(Vehicle vehicle)  // 0xB72E26D81006005B
```

build 323

## ALLOW_AMBIENT_VEHICLES_TO_AVOID_ADVERSE_CONDITIONS

```c
void ALLOW_AMBIENT_VEHICLES_TO_AVOID_ADVERSE_CONDITIONS(Vehicle vehicle)  // 0xB264C4D2F2B0A78B
```

build 323

> This native doesn't seem to do anything, might be a debug-only native.
> 
> Confirmed, it is a debug native.

## ALLOW_BOAT_BOOM_TO_ANIMATE

```c
void ALLOW_BOAT_BOOM_TO_ANIMATE(Vehicle vehicle, BOOL toggle)  // 0x0F3B4D4E43177236
```

build 323 · old names: `_GET_BOAT_BOOM_POSITION_RATIO_3`

## ALLOW_TRAIN_TO_BE_REMOVED_BY_POPULATION

```c
void ALLOW_TRAIN_TO_BE_REMOVED_BY_POPULATION(Any p0)  // 0x2310A8F9421EBF43
```

build 2372

## APPLY_EMP_EFFECT

```c
void APPLY_EMP_EFFECT(Vehicle vehicle)  // 0x249249D74F813EB2
```

build 3095

## ARE_ALL_VEHICLE_WINDOWS_INTACT

```c
BOOL ARE_ALL_VEHICLE_WINDOWS_INTACT(Vehicle vehicle)  // 0x11D862A3E977A9EF
```

build 323 · old names: `_ARE_ALL_VEHICLE_WINDOWS_INTACT`

> Appears to return false if any window is broken.

## ARE_ANY_VEHICLE_SEATS_FREE

```c
BOOL ARE_ANY_VEHICLE_SEATS_FREE(Vehicle vehicle)  // 0x2D34FC3BC4ADB780
```

build 323 · old names: `_IS_ANY_VEHICLE_SEAT_EMPTY`

> Returns false if every seat is occupied.

## ARE_FOLDING_WINGS_DEPLOYED

```c
BOOL ARE_FOLDING_WINGS_DEPLOYED(Vehicle vehicle)  // 0xAEF12960FA943792
```

build 1290 · old names: `_ARE_HELI_STUB_WINGS_DEPLOYED`

> Only used with the "akula" and "annihilator2" in the decompiled native scripts.

## ARE_PLANE_CONTROL_PANELS_INTACT

```c
BOOL ARE_PLANE_CONTROL_PANELS_INTACT(Vehicle vehicle, BOOL p1)  // 0xF78F94D60248C737
```

build 323

## ARE_PLANE_PROPELLERS_INTACT

```c
BOOL ARE_PLANE_PROPELLERS_INTACT(Vehicle plane)  // 0x755D6D5267CBBD7E
```

build 323 · old names: `_ARE_PROPELLERS_UNDAMAGED`

## ARE_WINGS_OF_PLANE_INTACT

```c
BOOL ARE_WINGS_OF_PLANE_INTACT(Vehicle plane)  // 0x5991A01434CE9677
```

build 323 · old names: `ADD_A_MARKER_OVER_VEHICLE`, `_ARE_VEHICLE_WINGS_INTACT`, `_ARE_PLANE_WINGS_INTACT`

## ATTACH_CONTAINER_TO_HANDLER_FRAME_WHEN_LINED_UP

```c
void ATTACH_CONTAINER_TO_HANDLER_FRAME_WHEN_LINED_UP(Vehicle vehicle, Entity entity)  // 0x6A98C2ECF57FA5D4
```

build 323

## ATTACH_ENTITY_TO_CARGOBOB

```c
void ATTACH_ENTITY_TO_CARGOBOB(Any p0, Any p1, Any p2, Any p3, Any p4, Any p5)  // 0xA1DD82F3CCF9A01E
```

build 944

## ATTACH_VEHICLE_ON_TO_TRAILER

```c
void ATTACH_VEHICLE_ON_TO_TRAILER(Vehicle vehicle, Vehicle trailer, float offsetX, float offsetY, float offsetZ, float coordsX, float coordsY, float coordsZ, float rotationX, float rotationY, float rotationZ, BOOL disableCollisions)  // 0x16B5E274BDE402F8
```

build 323

> This is the proper way of attaching vehicles to the car carrier, it's what Rockstar uses. Video Demo: https://www.youtube.com/watch?v=2lVEIzf7bgo

## ATTACH_VEHICLE_TO_CARGOBOB

```c
void ATTACH_VEHICLE_TO_CARGOBOB(Vehicle cargobob, Vehicle vehicle, int p2, float x, float y, float z)  // 0x4127F1D84E347769
```

build 323

## ATTACH_VEHICLE_TO_TOW_TRUCK

```c
void ATTACH_VEHICLE_TO_TOW_TRUCK(Vehicle towTruck, Vehicle vehicle, BOOL rear, float hookOffsetX, float hookOffsetY, float hookOffsetZ)  // 0x29A16F8D621C4508
```

build 323

> HookOffset defines where the hook is attached. leave at 0 for default attachment.

## ATTACH_VEHICLE_TO_TRAILER

```c
void ATTACH_VEHICLE_TO_TRAILER(Vehicle vehicle, Vehicle trailer, float radius)  // 0x3C7D42D58F770B54
```

build 323

## BRING_VEHICLE_TO_HALT

```c
void BRING_VEHICLE_TO_HALT(Vehicle vehicle, float distance, int duration, BOOL p3)  // 0x260BE8F09E326A20
```

build 323 · old names: `_SET_VEHICLE_HALT`

> This native makes the vehicle stop immediately, as happens when we enter a MP garage.
> 
> . distance defines how far it will travel until stopping. Garage doors use 3.0.
> 
> . If killEngine is set to 1, you cannot resume driving the vehicle once it stops. This looks like is a bitmapped integer.

## CAN_ANCHOR_BOAT_HERE

```c
BOOL CAN_ANCHOR_BOAT_HERE(Vehicle vehicle)  // 0x26C10ECBDA5D043B
```

build 323 · old names: `_GET_BOAT_ANCHOR`, `_CAN_BOAT_BE_ANCHORED`

## CAN_ANCHOR_BOAT_HERE_IGNORE_PLAYERS

```c
BOOL CAN_ANCHOR_BOAT_HERE_IGNORE_PLAYERS(Vehicle vehicle)  // 0x24F4121D07579880
```

build 678 · old names: `_CAN_BOAT_BE_ANCHORED_2`, `_CAN_ANCHOR_BOAT_HERE_2`

## CAN_CARGOBOB_PICK_UP_ENTITY

```c
BOOL CAN_CARGOBOB_PICK_UP_ENTITY(Any p0, Any p1)  // 0x2C1D8B3B19E517CC
```

build 757

## CAN_SHUFFLE_SEAT

```c
BOOL CAN_SHUFFLE_SEAT(Vehicle vehicle, int seatIndex)  // 0x30785D90C956BF35
```

build 323

## CLEAR_LAST_DRIVEN_VEHICLE

```c
void CLEAR_LAST_DRIVEN_VEHICLE()  // 0xE01903C47C7AC89E
```

build 323

## CLEAR_NITROUS

```c
void CLEAR_NITROUS(Vehicle vehicle)  // 0xC889AE921400E1ED
```

build 3095

## CLEAR_VEHICLE_CUSTOM_PRIMARY_COLOUR

```c
void CLEAR_VEHICLE_CUSTOM_PRIMARY_COLOUR(Vehicle vehicle)  // 0x55E1D2758F34E437
```

build 323

## CLEAR_VEHICLE_CUSTOM_SECONDARY_COLOUR

```c
void CLEAR_VEHICLE_CUSTOM_SECONDARY_COLOUR(Vehicle vehicle)  // 0x5FFBDEEC3E8E2009
```

build 323

## CLEAR_VEHICLE_GENERATOR_AREA_OF_INTEREST

```c
void CLEAR_VEHICLE_GENERATOR_AREA_OF_INTEREST()  // 0x0A436B8643716D14
```

build 323

## CLEAR_VEHICLE_PETROLTANK_FIRE_CULPRIT

```c
void CLEAR_VEHICLE_PETROLTANK_FIRE_CULPRIT(Vehicle vehicle)  // 0x4419966C9936071A
```

build 463

## CLEAR_VEHICLE_PHONE_EXPLOSIVE_DEVICE

```c
void CLEAR_VEHICLE_PHONE_EXPLOSIVE_DEVICE()  // 0xAA3F739ABDDCF21F
```

build 463 · old names: `_CLEAR_VEHICLE_PHONE_EXPLOSIVE_DEVICE`

## CLEAR_VEHICLE_ROUTE_HISTORY

```c
void CLEAR_VEHICLE_ROUTE_HISTORY(Vehicle vehicle)  // 0x6D6AF961B72728AE
```

build 323

## CLOSE_BOMB_BAY_DOORS

```c
void CLOSE_BOMB_BAY_DOORS(Vehicle vehicle)  // 0x3556041742A0DC74
```

build 323

## CONTROL_LANDING_GEAR

```c
void CONTROL_LANDING_GEAR(Vehicle vehicle, int state)  // 0xCFC8BE9A5E1FE575
```

build 323 · old names: `_SET_VEHICLE_LANDING_GEAR`

> Works for vehicles with a retractable landing gear
> 
> Landing gear states:
> 
> 0: Deployed
> 1: Closing
> 2: Opening
> 3: Retracted

## COPY_VEHICLE_DAMAGES

```c
void COPY_VEHICLE_DAMAGES(Vehicle sourceVehicle, Vehicle targetVehicle)  // 0xE44A982368A4AF23
```

build 323

> Copies sourceVehicle's damage (broken bumpers, broken lights, etc.) to targetVehicle.

## CREATE_MISSION_TRAIN

```c
Vehicle CREATE_MISSION_TRAIN(int variation, float x, float y, float z, BOOL direction, Any p5, Any p6)  // 0x63C6CCA8E68AE8C8
```

build 323

> Train models HAVE TO be loaded (requested) before you use this.
> For variation 15 - request:
> 
> freight
> freightcar
> freightgrain
> freightcont1
> freightcont2
> freighttrailer
> 
> 

## CREATE_PICK_UP_ROPE_FOR_CARGOBOB

```c
void CREATE_PICK_UP_ROPE_FOR_CARGOBOB(Vehicle cargobob, int state)  // 0x7BEB0C7A235F6F3B
```

build 323 · old names: `_ENABLE_CARGOBOB_HOOK`

> Drops the Hook/Magnet on a cargobob
> 
> state
> enum eCargobobHook
> {
>   CARGOBOB_HOOK = 0,
>     CARGOBOB_MAGNET = 1,
> };

## CREATE_SCRIPT_VEHICLE_GENERATOR

```c
int CREATE_SCRIPT_VEHICLE_GENERATOR(float x, float y, float z, float heading, float p4, float p5, Hash modelHash, int p7, int p8, int p9, int p10, BOOL p11, BOOL p12, BOOL p13, BOOL p14, BOOL p15, int p16)  // 0x9DEF883114668116
```

build 323

> Creates a script vehicle generator at the given coordinates. Most parameters after the model hash are unknown.
> 
> Parameters:
> x/y/z - Generator position
> heading - Generator heading
> p4 - Unknown (always 5.0)
> p5 - Unknown (always 3.0)
> modelHash - Vehicle model hash
> p7/8/9/10 - Unknown (always -1)
> p11 - Unknown (usually TRUE, only one instance of FALSE)
> p12/13 - Unknown (always FALSE)
> p14 - Unknown (usally FALSE, only two instances of TRUE)
> p15 - Unknown (always TRUE)
> p16 - Unknown (always -1)
> 
> Vector3 coords = GET_ENTITY_COORDS(PLAYER_PED_ID(), 0);    CREATE_SCRIPT_VEHICLE_GENERATOR(coords.x, coords.y, coords.z, 1.0f, 5.0f, 3.0f, GET_HASH_KEY("adder"), -1. -1, -1, -1, -1, true, false, false, false, true, -1);

## CREATE_VEHICLE

```c
Vehicle CREATE_VEHICLE(Hash modelHash, float x, float y, float z, float heading, BOOL isNetwork, BOOL bScriptHostVeh, BOOL p7)  // 0xAF35D0D2583051B0
```

build 323

> p7 when set to true allows you to spawn vehicles under -100 z.
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## DELETE_ALL_TRAINS

```c
void DELETE_ALL_TRAINS()  // 0x736A718577F39C7D
```

build 323

## DELETE_MISSION_TRAIN

```c
void DELETE_MISSION_TRAIN(Vehicle* train)  // 0x5B76B14AE875C795
```

build 323

## DELETE_SCRIPT_VEHICLE_GENERATOR

```c
void DELETE_SCRIPT_VEHICLE_GENERATOR(int vehicleGenerator)  // 0x22102C9ABFCF125D
```

build 323

## DELETE_VEHICLE

```c
void DELETE_VEHICLE(Vehicle* vehicle)  // 0xEA386986E786A54F
```

build 323

> Deletes a vehicle.
> The vehicle must be a mission entity to delete, so call this before deleting: SET_ENTITY_AS_MISSION_ENTITY(vehicle, true, true);
> 
> eg how to use:
> SET_ENTITY_AS_MISSION_ENTITY(vehicle, true, true);
> DELETE_VEHICLE(&vehicle);
> 
> Deletes the specified vehicle, then sets the handle pointed to by the pointer to NULL.

## DETACH_CONTAINER_FROM_HANDLER_FRAME

```c
void DETACH_CONTAINER_FROM_HANDLER_FRAME(Vehicle vehicle)  // 0x7C0043FDFF6436BC
```

build 323

## DETACH_ENTITY_FROM_CARGOBOB

```c
BOOL DETACH_ENTITY_FROM_CARGOBOB(Vehicle cargobob, Entity entity)  // 0xAF03011701811146
```

build 678 · old names: `_DETACH_ENTITY_FROM_CARGOBOB`

## DETACH_VEHICLE_FROM_ANY_CARGOBOB

```c
BOOL DETACH_VEHICLE_FROM_ANY_CARGOBOB(Vehicle vehicle)  // 0xADF7BE450512C12F
```

build 323

## DETACH_VEHICLE_FROM_ANY_TOW_TRUCK

```c
BOOL DETACH_VEHICLE_FROM_ANY_TOW_TRUCK(Vehicle vehicle)  // 0xD0E9CE05A1E68CD8
```

build 323

## DETACH_VEHICLE_FROM_CARGOBOB

```c
void DETACH_VEHICLE_FROM_CARGOBOB(Vehicle vehicle, Vehicle cargobob)  // 0x0E21D3DF1051399D
```

build 323

## DETACH_VEHICLE_FROM_TOW_TRUCK

```c
void DETACH_VEHICLE_FROM_TOW_TRUCK(Vehicle towTruck, Vehicle vehicle)  // 0xC2DB6B6708350ED8
```

build 323

> First two parameters swapped. Scripts verify that towTruck is the first parameter, not the second.

## DETACH_VEHICLE_FROM_TRAILER

```c
void DETACH_VEHICLE_FROM_TRAILER(Vehicle vehicle)  // 0x90532EDF0D2BDD86
```

build 323

## DETONATE_VEHICLE_PHONE_EXPLOSIVE_DEVICE

```c
void DETONATE_VEHICLE_PHONE_EXPLOSIVE_DEVICE()  // 0xEF49CF0270307CBE
```

build 323 · old names: `_REQUEST_VEHICLE_PHONE_EXPLOSION`

## DISABLE_INDIVIDUAL_PLANE_PROPELLER

```c
void DISABLE_INDIVIDUAL_PLANE_PROPELLER(Vehicle vehicle, int propeller)  // 0x500873A45724C863
```

build 323

## DISABLE_PLANE_AILERON

```c
void DISABLE_PLANE_AILERON(Vehicle vehicle, BOOL p1, BOOL p2)  // 0x23428FC53C60919C
```

build 323

## DISABLE_VEHCILE_DYNAMIC_AMBIENT_SCALES

```c
void DISABLE_VEHCILE_DYNAMIC_AMBIENT_SCALES(Vehicle vehicle, int p1, int p2)  // 0xF0E4BA16D1DB546C
```

build 323 · old names: `_SET_VEHICLE_SHADOW_EFFECT`

> Adds some kind of shadow to the vehicle.
> 
> p1 and p2 use values from 0-255 and both make the shadow darker the lower the value is. -1 disables the effect.

## DISABLE_VEHICLE_EXPLOSION_BREAK_OFF_PARTS

```c
void DISABLE_VEHICLE_EXPLOSION_BREAK_OFF_PARTS()  // 0xF25E02CB9C5818F8
```

build 323

## DISABLE_VEHICLE_TURRET_MOVEMENT_THIS_FRAME

```c
void DISABLE_VEHICLE_TURRET_MOVEMENT_THIS_FRAME(Vehicle vehicle)  // 0x32CAEDF24A583345
```

build 463 · old names: `_DISABLE_VEHICLE_TURRET_MOVEMENT_THIS_FRAME`

## DISABLE_VEHICLE_WEAPON

```c
void DISABLE_VEHICLE_WEAPON(BOOL disabled, Hash weaponHash, Vehicle vehicle, Ped owner)  // 0xF4FC6A6F67D8D856
```

build 323

> Full list of weapons by DurtyFree (Search for VEHICLE_*): https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## DOES_CARGOBOB_HAVE_PICK_UP_ROPE

```c
BOOL DOES_CARGOBOB_HAVE_PICK_UP_ROPE(Vehicle cargobob)  // 0x1821D91AD4B56108
```

build 323 · old names: `_IS_CARGOBOB_HOOK_ACTIVE`

> Returns true only when the hook is active, will return false if the magnet is active

## DOES_CARGOBOB_HAVE_PICKUP_MAGNET

```c
BOOL DOES_CARGOBOB_HAVE_PICKUP_MAGNET(Vehicle cargobob)  // 0x6E08BF5B3722BAC9
```

build 323 · old names: `_IS_CARGOBOB_MAGNET_ACTIVE`, `_DOES_CARGOBOB_HAVE_PICKUP_MAGNET`

> Returns true only when the magnet is active, will return false if the hook is active

## DOES_EXTRA_EXIST

```c
BOOL DOES_EXTRA_EXIST(Vehicle vehicle, int extraId)  // 0x1262D55792428154
```

build 323

> Checks via CVehicleModelInfo

## DOES_SCRIPT_VEHICLE_GENERATOR_EXIST

```c
BOOL DOES_SCRIPT_VEHICLE_GENERATOR_EXIST(int vehicleGenerator)  // 0xF6086BC836400876
```

build 323

## DOES_VEHICLE_ALLOW_RAPPEL

```c
BOOL DOES_VEHICLE_ALLOW_RAPPEL(Vehicle vehicle)  // 0x4E417C547182C84D
```

build 757 · old names: `_DOES_VEHICLE_ALLOW_RAPPEL`

> Returns true if the vehicle has the FLAG_ALLOWS_RAPPEL flag set.

## DOES_VEHICLE_EXIST_WITH_DECORATOR

```c
Vehicle DOES_VEHICLE_EXIST_WITH_DECORATOR(const char* decorator)  // 0x956B409B984D9BF7
```

build 323

## DOES_VEHICLE_HAVE_ROOF

```c
BOOL DOES_VEHICLE_HAVE_ROOF(Vehicle vehicle)  // 0x8AC862B0B32C5B80
```

build 323

## DOES_VEHICLE_HAVE_SEARCHLIGHT

```c
BOOL DOES_VEHICLE_HAVE_SEARCHLIGHT(Vehicle vehicle)  // 0x99015ED7DBEA5113
```

build 2189 · old names: `_DOES_VEHICLE_HAVE_SEARCHLIGHT`

## DOES_VEHICLE_HAVE_STUCK_VEHICLE_CHECK

```c
BOOL DOES_VEHICLE_HAVE_STUCK_VEHICLE_CHECK(Vehicle vehicle)  // 0x57E4C39DE5EE8470
```

build 323

> Maximum amount of vehicles with vehicle stuck check appears to be 16.

## DOES_VEHICLE_HAVE_WEAPONS

```c
BOOL DOES_VEHICLE_HAVE_WEAPONS(Vehicle vehicle)  // 0x25ECB9F8017D98E0
```

build 323

## ENABLE_VEHICLE_DYNAMIC_AMBIENT_SCALES

```c
void ENABLE_VEHICLE_DYNAMIC_AMBIENT_SCALES(Vehicle vehicle)  // 0xF87D9F2301F7D206
```

build 323 · old names: `_REMOVE_VEHICLE_SHADOW_EFFECT`

> Remove the weird shadow applied by DISABLE_VEHCILE_DYNAMIC_AMBIENT_SCALES.

## EXPLODE_VEHICLE

```c
void EXPLODE_VEHICLE(Vehicle vehicle, BOOL isAudible, BOOL isInvisible)  // 0xBA71116ADF5B514C
```

build 323

> Explodes a selected vehicle.
> 
> Vehicle vehicle = Vehicle you want to explode.
> BOOL isAudible = If explosion makes a sound.
> BOOL isInvisible = If the explosion is invisible or not.
> 
> First BOOL does not give any visual explosion, the vehicle just falls apart completely but slowly and starts to burn.

## EXPLODE_VEHICLE_IN_CUTSCENE

```c
void EXPLODE_VEHICLE_IN_CUTSCENE(Vehicle vehicle, BOOL p1)  // 0x786A4EB67B01BF0B
```

build 323

## FIND_HANDLER_VEHICLE_CONTAINER_IS_ATTACHED_TO

```c
Vehicle FIND_HANDLER_VEHICLE_CONTAINER_IS_ATTACHED_TO(Entity entity)  // 0x375E7FC44F21C8AB
```

build 323 · old names: `_GET_VEHICLE_ATTACHED_TO_ENTITY`, `_FIND_VEHICLE_CARRYING_THIS_ENTITY`

> Finds the vehicle that is carrying this entity with a handler frame.
> The model of the entity must be prop_contr_03b_ld or the function will return 0.

## FIND_SPAWN_COORDINATES_FOR_HELI

```c
Vector3 FIND_SPAWN_COORDINATES_FOR_HELI(Ped ped)  // 0x8DC9675797123522
```

build 1290 · old names: `_FIND_RANDOM_POINT_IN_SPACE`

> Native is significantly more complicated than simply generating a random vector & length.
> The 'point' is either 400.0 or 250.0 units away from the Ped's current coordinates; and paths into functions like rage::grcViewport___IsSphereVisible

## FIX_VEHICLE_WINDOW

```c
void FIX_VEHICLE_WINDOW(Vehicle vehicle, int windowIndex)  // 0x772282EBEB95E682
```

build 323

> windowIndex:
> 0 = Front Left Window
> 1 = Front Right Window
> 2 = Rear Left Window
> 3 = Rear Right Window
> 4 = Front Windscreen
> 5 = Rear Windscreen
> 6 = Mid Left
> 7 = Mid Right
> 8 = Invalid
> 
> Additional information: FIX_VEHICLE_WINDOW (0x140D0BB88) references an array of bone vehicle indices (0x141D4B3E0) { 2Ah, 2Bh, 2Ch, 2Dh, 2Eh, 2Fh, 28h, 29h } that correspond to: window_lf, window_rf, window_lr, window_rr, window_lm, window_rm, windscreen, windscreen_r. This array is used by most vehwindow natives.
> 
> Also, this function is coded to not work on vehicles of type: CBike, Bmx, CBoat, CTrain, and CSubmarine.

## FORCE_PLAYBACK_RECORDED_VEHICLE_UPDATE

```c
void FORCE_PLAYBACK_RECORDED_VEHICLE_UPDATE(Vehicle vehicle, BOOL p1)  // 0x1F2E4E06DEA8992B
```

build 323

> Often called after START_PLAYBACK_RECORDED_VEHICLE and SKIP_TIME_IN_PLAYBACK_RECORDED_VEHICLE; similar in use to FORCE_ENTITY_AI_AND_ANIMATION_UPDATE.

## FORCE_SUB_THROTTLE_FOR_TIME

```c
void FORCE_SUB_THROTTLE_FOR_TIME(Vehicle vehicle, float p1, float p2)  // 0x99CAD8E7AFDB60FA
```

build 323

## FORCE_SUBMARINE_NEURTAL_BUOYANCY

```c
void FORCE_SUBMARINE_NEURTAL_BUOYANCY(Any p0, Any p1)  // 0xC67DB108A9ADE3BE
```

build 2189

## FORCE_SUBMARINE_SURFACE_MODE

```c
void FORCE_SUBMARINE_SURFACE_MODE(Vehicle vehicle, BOOL toggle)  // 0x33506883545AC0DF
```

build 323

## FULLY_CHARGE_NITROUS

```c
void FULLY_CHARGE_NITROUS(Vehicle vehicle)  // 0x1A2BCC8C636F9226
```

build 3095

## GENERATE_VEHICLE_CREATION_POS_FROM_PATHS

```c
BOOL GENERATE_VEHICLE_CREATION_POS_FROM_PATHS(Vector3* outVec, Any p1, Vector3* outVec1, Any p3, Any p4, Any p5, Any p6, Any p7, Any p8)  // 0xA4822F1CF23F4810
```

build 323

## GET_ALL_VEHICLES

```c
int GET_ALL_VEHICLES(Any* vehsStruct)  // 0x9B8E1BF04B51F2E8
```

build 1103 · old names: `_GET_ALL_VEHICLES`

## GET_ARE_BOMB_BAY_DOORS_OPEN

```c
BOOL GET_ARE_BOMB_BAY_DOORS_OPEN(Vehicle aircraft)  // 0xD0917A423314BBA8
```

build 1180 · old names: `_GET_ARE_BOMB_BAY_DOORS_OPEN`, `_ARE_BOMB_BAY_DOORS_OPEN`

> Returns true when the bomb bay doors of this plane are open. False if they're closed.

## GET_ATTACHED_PICK_UP_HOOK_POSITION

```c
Vector3 GET_ATTACHED_PICK_UP_HOOK_POSITION(Vehicle cargobob)  // 0xCBDB9B923CACC92D
```

build 323 · old names: `_GET_CARGOBOB_HOOK_POSITION`

> Gets the position of the cargobob hook, in world coords.

## GET_BOAT_BOOM_POSITION_RATIO

```c
float GET_BOAT_BOOM_POSITION_RATIO(Vehicle vehicle)  // 0x6636C535F6CC2725
```

build 323

## GET_BOAT_VEHICLE_MODEL_AGILITY

```c
float GET_BOAT_VEHICLE_MODEL_AGILITY(Hash modelHash)  // 0x5AA3F878A178C4FC
```

build 323 · old names: `_GET_VEHICLE_MODEL_MOVE_RESISTANCE`

> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_BOTH_VEHICLE_HEADLIGHTS_DAMAGED

```c
BOOL GET_BOTH_VEHICLE_HEADLIGHTS_DAMAGED(Vehicle vehicle)  // 0xEC69ADF931AAE0C3
```

build 505 · old names: `_IS_VEHICLE_ENGINE_ON_FIRE`

> Returns true when both headlights are broken. This does not include extralights.

## GET_CAN_VEHICLE_BE_PLACED_HERE

```c
BOOL GET_CAN_VEHICLE_BE_PLACED_HERE(Vehicle vehicle, float x, float y, float z, float rotX, float rotY, float rotZ, int p7, Any p8)  // 0x51F30DB60626A20E
```

build 1180

> Used in decompiled scripts in combination with GET_VEHICLE_SIZE
> p7 is usually 2
> p8 is usually 1

## GET_CAR_HAS_JUMP

```c
BOOL GET_CAR_HAS_JUMP(Vehicle vehicle)  // 0x9078C0C5EF8C19E9
```

build 944 · old names: `_HAS_VEHICLE_JUMPING_ABILITY`, `_DOES_VEHICLE_HAVE_JUMPING_ABILITY`, `_GET_CAN_VEHICLE_JUMP`

> Returns true if the vehicle has the FLAG_JUMPING_CAR flag set.

## GET_CLOSEST_VEHICLE

```c
Vehicle GET_CLOSEST_VEHICLE(float x, float y, float z, float radius, Hash modelHash, int flags)  // 0xF73EB622C4F1689B
```

build 323

> Example usage
> VEHICLE::GET_CLOSEST_VEHICLE(x, y, z, radius, hash, unknown leave at 70) 
> 
> x, y, z: Position to get closest vehicle to.
> radius: Max radius to get a vehicle.
> modelHash: Limit to vehicles with this model. 0 for any.
> flags: The bitwise flags altering the function's behaviour.
> 
> Does not return police cars or helicopters.
> 
> It seems to return police cars for me, does not seem to return helicopters, planes or boats for some reason
> 
> Only returns non police cars and motorbikes with the flag set to 70 and modelHash to 0. ModelHash seems to always be 0 when not a modelHash in the scripts, as stated above. 
> 
> These flags were found in the b617d scripts: 0,2,4,6,7,23,127,260,2146,2175,12294,16384,16386,20503,32768,67590,67711,98309,100359.
> Converted to binary, each bit probably represents a flag as explained regarding another native here: https://gtaforums.com/topic/822314-guide-driving-styles
> 
> Conversion of found flags to binary: https://pastebin.com/kghNFkRi
> 
> At exactly 16384 which is 0100000000000000 in binary and 4000 in hexadecimal only planes are returned. 
> 
> It's probably more convenient to use worldGetAllVehicles(int *arr, int arrSize) and check the shortest distance yourself and sort if you want by checking the vehicle type with for example VEHICLE::IS_THIS_MODEL_A_BOAT
> 
> -------------------------------------------------------------------------
> 
> Conclusion: This native is not worth trying to use. Use something like this instead: https://pastebin.com/xiFdXa7h
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_CONVERTIBLE_ROOF_STATE

```c
int GET_CONVERTIBLE_ROOF_STATE(Vehicle vehicle)  // 0xF8C397922FC03F41
```

build 323

> 0 -> up
> 1 -> lowering down
> 2 -> down
> 3 -> raising up

## GET_CURRENT_PLAYBACK_FOR_VEHICLE

```c
int GET_CURRENT_PLAYBACK_FOR_VEHICLE(Vehicle vehicle)  // 0x42BC05C27A946054
```

build 323

## GET_DISPLAY_NAME_FROM_VEHICLE_MODEL

```c
const char* GET_DISPLAY_NAME_FROM_VEHICLE_MODEL(Hash modelHash)  // 0xB215AAC32D25D019
```

build 323

> Returns model name of vehicle in all caps. Needs to be displayed through localizing text natives to get proper display name.
> -----------------------------------------------------------------------------------------------------------------------------------------
> While often the case, this does not simply return the model name of the vehicle (which could be hashed to return the model hash). Variations of the same vehicle may also use the same display name.
> -----------------------------------------------------------------------------------------------------------------------------------------
> 
> Returns "CARNOTFOUND" if the hash doesn't match a vehicle hash.
> 
> Using HUD::GET_FILENAME_FOR_AUDIO_CONVERSATION, you can get the localized name.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_DOES_VEHICLE_HAVE_DAMAGE_DECALS

```c
BOOL GET_DOES_VEHICLE_HAVE_DAMAGE_DECALS(Vehicle vehicle)  // 0xBCDC5017D3CE1E9E
```

build 323 · old names: `_IS_VEHICLE_DAMAGED`

> Appears to return true if the vehicle has any damage, including cosmetically.

## GET_DOES_VEHICLE_HAVE_TOMBSTONE

```c
BOOL GET_DOES_VEHICLE_HAVE_TOMBSTONE(Vehicle vehicle)  // 0x71AFB258CCED3A27
```

build 1604 · old names: `_GET_DOES_VEHICLE_HAVE_TOMBSTONE`

> Returns true only if the "tombstone" bone is attached to the vehicle, irrespective of "FLAG_HAS_TOMBSTONE" being present or not. Detaching the tombstone will return false.

## GET_DRIFT_TYRES_SET

```c
BOOL GET_DRIFT_TYRES_SET(Vehicle vehicle)  // 0x2F5A72430E78C8D3
```

build 2372 · old names: `_GET_DRIFT_TYRES_ENABLED`

## GET_ENTITY_ATTACHED_TO_CARGOBOB

```c
Entity GET_ENTITY_ATTACHED_TO_CARGOBOB(Any p0)  // 0x99093F60746708CA
```

build 1103 · old names: `_GET_ENTITY_ATTACHED_TO_CARGOBOB`

## GET_ENTITY_ATTACHED_TO_TOW_TRUCK

```c
Entity GET_ENTITY_ATTACHED_TO_TOW_TRUCK(Vehicle towTruck)  // 0xEFEA18DCF10F8F75
```

build 323

## GET_ENTRY_POINT_POSITION

```c
Vector3 GET_ENTRY_POINT_POSITION(Vehicle vehicle, int doorId)  // 0xC0572928C0ABFDA3
```

build 944 · old names: `_GET_ENTRY_POSITION_OF_DOOR`

> doorId: see SET_VEHICLE_DOOR_SHUT

## GET_FAKE_SUSPENSION_LOWERING_AMOUNT

```c
float GET_FAKE_SUSPENSION_LOWERING_AMOUNT(Vehicle vehicle)  // 0x53952FD2BAA19F17
```

build 323 · old names: `_GET_VEHICLE_SUSPENSION_HEIGHT`

> Gets the height of the vehicle's suspension.
> The higher the value the lower the suspension. Each 0.002 corresponds with one more level lowered.
> 0.000 is the stock suspension.
> 0.008 is Ultra Suspension.

## GET_FLYING_VEHICLE_MODEL_AGILITY

```c
float GET_FLYING_VEHICLE_MODEL_AGILITY(Hash modelHash)  // 0xC6AD107DDC9054CC
```

build 323 · old names: `_GET_VEHICLE_MODEL_MAX_KNOTS`

> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_HAS_RETRACTABLE_WHEELS

```c
BOOL GET_HAS_RETRACTABLE_WHEELS(Vehicle vehicle)  // 0xDCA174A42133F08C
```

build 944 · old names: `_GET_HAS_LOWERABLE_WHEELS`, `_DOES_VEHICLE_HAVE_RETRACTABLE_WHEELS`, `_GET_HAS_RETRACTABLE_WHEELS`

## GET_HAS_ROCKET_BOOST

```c
BOOL GET_HAS_ROCKET_BOOST(Vehicle vehicle)  // 0x36D782F68B309BDA
```

build 944 · old names: `_HAS_VEHICLE_ROCKET_BOOST`, `_DOES_VEHICLE_HAVE_ROCKET_BOOST`, `_GET_HAS_ROCKET_BOOST`

## GET_HAS_VEHICLE_BEEN_HIT_BY_SHUNT

```c
BOOL GET_HAS_VEHICLE_BEEN_HIT_BY_SHUNT(Vehicle vehicle)  // 0xE8718FAF591FD224
```

build 1604

## GET_HELI_MAIN_ROTOR_HEALTH

```c
float GET_HELI_MAIN_ROTOR_HEALTH(Vehicle vehicle)  // 0xE4CB7541F413D2C5
```

build 323 · old names: `_GET_HELI_MAIN_ROTOR_HEALTH`

> Max 1000.
> At 0 the main rotor will stall.

## GET_HELI_TAIL_BOOM_HEALTH

```c
float GET_HELI_TAIL_BOOM_HEALTH(Vehicle vehicle)  // 0xAC51915D27E4A5F7
```

build 323 · old names: `_GET_HELI_ENGINE_HEALTH`

> Max 1000.
> At -100 both helicopter rotors will stall.

## GET_HELI_TAIL_ROTOR_HEALTH

```c
float GET_HELI_TAIL_ROTOR_HEALTH(Vehicle vehicle)  // 0xAE8CE82A4219AC8C
```

build 323 · old names: `_GET_HELI_TAIL_ROTOR_HEALTH`

> Max 1000.
> At 0 the tail rotor will stall.

## GET_HYDRAULIC_SUSPENSION_RAISE_FACTOR

```c
float GET_HYDRAULIC_SUSPENSION_RAISE_FACTOR(Vehicle vehicle, int wheelId)  // 0x0BB5CBDDD0F25AE3
```

build 2372 · old names: `_GET_HYDRAULIC_WHEEL_VALUE`

## GET_IN_VEHICLE_CLIPSET_HASH_FOR_SEAT

```c
Hash GET_IN_VEHICLE_CLIPSET_HASH_FOR_SEAT(Vehicle vehicle, int p1)  // 0xA01BC64DD4BFBBAC
```

build 323

## GET_IS_BOAT_CAPSIZED

```c
BOOL GET_IS_BOAT_CAPSIZED(Vehicle vehicle)  // 0xBA91D045575699AD
```

build 877

## GET_IS_DOOR_VALID

```c
BOOL GET_IS_DOOR_VALID(Vehicle vehicle, int doorId)  // 0x645F4B6E8499F632
```

build 944 · old names: `_DOES_VEHICLE_HAVE_DOOR`, `_GET_IS_DOOR_VALID`

> doorId: see SET_VEHICLE_DOOR_SHUT

## GET_IS_LEFT_VEHICLE_HEADLIGHT_DAMAGED

```c
BOOL GET_IS_LEFT_VEHICLE_HEADLIGHT_DAMAGED(Vehicle vehicle)  // 0x5EF77C9ADD3B11A3
```

build 323 · old names: `_IS_HEADLIGHT_L_BROKEN`

> From the driver's perspective, is the left headlight broken.

## GET_IS_RIGHT_VEHICLE_HEADLIGHT_DAMAGED

```c
BOOL GET_IS_RIGHT_VEHICLE_HEADLIGHT_DAMAGED(Vehicle vehicle)  // 0xA7ECB73355EB2F20
```

build 323 · old names: `_IS_HEADLIGHT_R_BROKEN`

> From the driver's perspective, is the right headlight broken.

## GET_IS_VEHICLE_DISABLED_BY_EMP

```c
BOOL GET_IS_VEHICLE_DISABLED_BY_EMP(Vehicle vehicle)  // 0x0506ED94363AD905
```

build 1604 · old names: `_GET_IS_VEHICLE_EMP_DISABLED`

> Returns whether this vehicle is currently disabled by an EMP mine.

## GET_IS_VEHICLE_ENGINE_RUNNING

```c
BOOL GET_IS_VEHICLE_ENGINE_RUNNING(Vehicle vehicle)  // 0xAE31E7DF9B5B132E
```

build 323 · old names: `_IS_VEHICLE_ENGINE_ON`

> Returns true when in a vehicle, false whilst entering/exiting.

## GET_IS_VEHICLE_PRIMARY_COLOUR_CUSTOM

```c
BOOL GET_IS_VEHICLE_PRIMARY_COLOUR_CUSTOM(Vehicle vehicle)  // 0xF095C0405307B21B
```

build 323

## GET_IS_VEHICLE_SECONDARY_COLOUR_CUSTOM

```c
BOOL GET_IS_VEHICLE_SECONDARY_COLOUR_CUSTOM(Vehicle vehicle)  // 0x910A32E7AAD2656C
```

build 323

> Check if Vehicle Secondary is avaliable for customize

## GET_IS_VEHICLE_SHUNTING

```c
BOOL GET_IS_VEHICLE_SHUNTING(Vehicle vehicle)  // 0xA2459F72C14E2E8D
```

build 1604 · old names: `_GET_IS_VEHICLE_SHUNT_BOOST_ACTIVE`

## GET_IS_WHEELS_RETRACTED

```c
BOOL GET_IS_WHEELS_RETRACTED(Vehicle vehicle)  // 0x1DA0DA9CB3F0C8BF
```

build 944 · old names: `_GET_IS_WHEELS_LOWERED_STATE_ACTIVE`

## GET_LANDING_GEAR_STATE

```c
int GET_LANDING_GEAR_STATE(Vehicle vehicle)  // 0x9B0F3DCA3DB0F4CD
```

build 323 · old names: `_GET_VEHICLE_LANDING_GEAR`

> Landing gear states:
> 
> 0: Deployed
> 1: Closing (Retracting)
> 2: (Landing gear state 2 is never used.)
> 3: Opening (Deploying)
> 4: Retracted
> 
> Returns the current state of the vehicles landing gear.

## GET_LAST_DRIVEN_VEHICLE

```c
Vehicle GET_LAST_DRIVEN_VEHICLE()  // 0xB2D06FAEDE65B577
```

build 323

## GET_LAST_PED_IN_VEHICLE_SEAT

```c
Ped GET_LAST_PED_IN_VEHICLE_SEAT(Vehicle vehicle, int seatIndex)  // 0x83F969AA1EE2A664
```

build 323

## GET_LAST_SHUNT_VEHICLE

```c
Vehicle GET_LAST_SHUNT_VEHICLE(Vehicle vehicle)  // 0x04F2FA6E234162F7
```

build 1604 · old names: `_GET_LAST_RAMMED_VEHICLE`

> Returns last vehicle that was rammed by the given vehicle using the shunt boost.

## GET_LIVERY_NAME

```c
const char* GET_LIVERY_NAME(Vehicle vehicle, int liveryIndex)  // 0xB4C7A93837C91A1F
```

build 323

> Returns the text label of the vehicle's liveryIndex, as specified by the liveryNames section of the vehicle's modkit data in the carcols file.
> 
> example 
> 
> int count = VEHICLE::GET_VEHICLE_LIVERY_COUNT(veh);
> for (int i = 0; i < count; i++)  
>   {
>      const char* LiveryName = VEHICLE::GET_LIVERY_NAME(veh, i);
>   }
> 
> 
> this example will work fine to fetch all names 
> for example for Sanchez we get 
> 
> SANC_LV1
> SANC_LV2
> SANC_LV3
> SANC_LV4
> SANC_LV5
> 
> 
> Use GET_FILENAME_FOR_AUDIO_CONVERSATION, to get the localized livery name.
> 
> Full list of vehicle mod kits and mods by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicleModKits.json

## GET_MAKE_NAME_FROM_VEHICLE_MODEL

```c
const char* GET_MAKE_NAME_FROM_VEHICLE_MODEL(Hash modelHash)  // 0xF7AF4F159FF99F97
```

build 1868 · old names: `_GET_MAKE_NAME_FROM_VEHICLE_MODEL`

> Will return a vehicle's manufacturer display label.
> Returns "CARNOTFOUND" if the hash doesn't match a vehicle hash.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_MOD_SLOT_NAME

```c
const char* GET_MOD_SLOT_NAME(Vehicle vehicle, int modType)  // 0x51F0FEB9F6AE98C0
```

build 323

> Returns the name for the type of vehicle mod(Armour, engine etc)
> 

## GET_MOD_TEXT_LABEL

```c
const char* GET_MOD_TEXT_LABEL(Vehicle vehicle, int modType, int modValue)  // 0x8935624F8C5592CC
```

build 323

> Returns the text label of a mod type for a given vehicle
> 
> Use GET_FILENAME_FOR_AUDIO_CONVERSATION to get the part name in the game's language

## GET_NUM_MOD_COLORS

```c
int GET_NUM_MOD_COLORS(int paintType, BOOL p1)  // 0xA551BE18C11A476D
```

build 323

> paintType:
> 0: Normal
> 1: Metallic
> 2: Pearl
> 3: Matte
> 4: Metal
> 5: Chrome
> 6: Chameleon

## GET_NUM_MOD_KITS

```c
int GET_NUM_MOD_KITS(Vehicle vehicle)  // 0x33F2E3FE70EAAE1D
```

build 323

## GET_NUM_VEHICLE_MODS

```c
int GET_NUM_VEHICLE_MODS(Vehicle vehicle, int modType)  // 0xE38E9162A2500646
```

build 323

> Returns how many possible mods a vehicle has for a given mod type

## GET_NUM_VEHICLE_WINDOW_TINTS

```c
int GET_NUM_VEHICLE_WINDOW_TINTS()  // 0x9D1224004B3A6707
```

build 323

## GET_NUMBER_OF_VEHICLE_COLOURS

```c
int GET_NUMBER_OF_VEHICLE_COLOURS(Vehicle vehicle)  // 0x3B963160CD65D41E
```

build 323

> Returns the total amount of color combinations found in the vehicle's carvariations.meta entry.

## GET_NUMBER_OF_VEHICLE_DOORS

```c
int GET_NUMBER_OF_VEHICLE_DOORS(Vehicle vehicle)  // 0x92922A607497B14D
```

build 463 · old names: `_GET_NUMBER_OF_VEHICLE_DOORS`

## GET_NUMBER_OF_VEHICLE_NUMBER_PLATES

```c
int GET_NUMBER_OF_VEHICLE_NUMBER_PLATES()  // 0x4C4D6B2644F458CB
```

build 323

> Returns the number of *types* of licence plates, enumerated below in SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX.

## GET_OUTRIGGERS_DEPLOYED

```c
BOOL GET_OUTRIGGERS_DEPLOYED(Vehicle vehicle)  // 0x3A9128352EAC9E85
```

build 1290 · old names: `_ARE_CHERNOBOG_STABILIZERS_DEPLOYED`

> Checks if Chernobog's stabilizers are deployed or not.
> These are the metal supports that allow it to fire.
> This native only applies to the Chernobog.

## GET_PED_IN_VEHICLE_SEAT

```c
Ped GET_PED_IN_VEHICLE_SEAT(Vehicle vehicle, int seatIndex, BOOL p2)  // 0xBB40DD2270B65366
```

build 323

> If there is no ped in the seat, and the game considers the vehicle as ambient population, this will create a random occupant ped in the seat, which may be cleaned up by the game fairly soon if not marked as script-owned mission entity.
> 
> Seat indexes:
> -1 = Driver
> 0 = Front Right Passenger
> 1 = Back Left Passenger
> 2 = Back Right Passenger
> 3 = Further Back Left Passenger (vehicles > 4 seats)
> 4 = Further Back Right Passenger (vehicles > 4 seats)
> etc.
> 
> If p2 is true it uses a different GetOccupant function.

## GET_PED_USING_VEHICLE_DOOR

```c
Ped GET_PED_USING_VEHICLE_DOOR(Vehicle vehicle, int doord)  // 0x218297BF0CFD853B
```

build 323 · old names: `_GET_PED_USING_VEHICLE_DOOR`

> doorId: see SET_VEHICLE_DOOR_SHUT

## GET_POSITION_IN_RECORDING

```c
float GET_POSITION_IN_RECORDING(Vehicle vehicle)  // 0x2DACD605FC681475
```

build 323

> Distance traveled in the vehicles current recording.

## GET_POSITION_OF_VEHICLE_RECORDING_AT_TIME

```c
Vector3 GET_POSITION_OF_VEHICLE_RECORDING_AT_TIME(int recording, float time, const char* script)  // 0xD242728AA6F0FBA2
```

build 323

> This native does no interpolation between pathpoints. The same position will be returned for all times up to the next pathpoint in the recording.
> 
> See REQUEST_VEHICLE_RECORDING

## GET_POSITION_OF_VEHICLE_RECORDING_ID_AT_TIME

```c
Vector3 GET_POSITION_OF_VEHICLE_RECORDING_ID_AT_TIME(int id, float time)  // 0x92523B76657A517D
```

build 323

## GET_RANDOM_VEHICLE_BACK_BUMPER_IN_SPHERE

```c
Vehicle GET_RANDOM_VEHICLE_BACK_BUMPER_IN_SPHERE(float p0, float p1, float p2, float p3, int p4, int p5, int p6)  // 0xB50807EABE20A8DC
```

build 323

## GET_RANDOM_VEHICLE_FRONT_BUMPER_IN_SPHERE

```c
Vehicle GET_RANDOM_VEHICLE_FRONT_BUMPER_IN_SPHERE(float p0, float p1, float p2, float p3, int p4, int p5, int p6)  // 0xC5574E0AEB86BA68
```

build 323

## GET_RANDOM_VEHICLE_IN_SPHERE

```c
Vehicle GET_RANDOM_VEHICLE_IN_SPHERE(float x, float y, float z, float radius, Hash modelHash, int flags)  // 0x386F6CE5BAF6091C
```

build 323

> Gets a random vehicle in a sphere at the specified position, of the specified radius.
> 
> x: The X-component of the position of the sphere.
> y: The Y-component of the position of the sphere.
> z: The Z-component of the position of the sphere.
> radius: The radius of the sphere. Max is 9999.9004.
> modelHash: The vehicle model to limit the selection to. Pass 0 for any model.
> flags: The bitwise flags that modifies the behaviour of this function.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_RANDOM_VEHICLE_MODEL_IN_MEMORY

```c
void GET_RANDOM_VEHICLE_MODEL_IN_MEMORY(BOOL p0, Hash* modelHash, int* successIndicator)  // 0x055BF0AC0C34F4FD
```

build 323

> Not present in the retail version! It's just a nullsub.
> 
> p0 always true (except in one case)
> successIndicator: 0 if success, -1 if failed

## GET_ROTATION_OF_VEHICLE_RECORDING_AT_TIME

```c
Vector3 GET_ROTATION_OF_VEHICLE_RECORDING_AT_TIME(int recording, float time, const char* script)  // 0x2058206FBE79A8AD
```

build 323

> This native does no interpolation between pathpoints. The same rotation will be returned for all times up to the next pathpoint in the recording.
> 
> See REQUEST_VEHICLE_RECORDING

## GET_ROTATION_OF_VEHICLE_RECORDING_ID_AT_TIME

```c
Vector3 GET_ROTATION_OF_VEHICLE_RECORDING_ID_AT_TIME(int id, float time)  // 0xF0F2103EFAF8CBA7
```

build 323

## GET_SUBMARINE_IS_UNDER_DESIGN_DEPTH

```c
BOOL GET_SUBMARINE_IS_UNDER_DESIGN_DEPTH(Vehicle submarine)  // 0x3E71D0B300B7AA79
```

build 2189 · old names: `_GET_SUBMARINE_IS_BELOW_FIRST_CRUSH_DEPTH`

## GET_SUBMARINE_NUMBER_OF_AIR_LEAKS

```c
int GET_SUBMARINE_NUMBER_OF_AIR_LEAKS(Vehicle submarine)  // 0x093D6DDCA5B8FBAE
```

build 2189 · old names: `_GET_SUBMARINE_CRUSH_DEPTH_WARNING_STATE`

## GET_TIME_POSITION_IN_RECORDING

```c
float GET_TIME_POSITION_IN_RECORDING(Vehicle vehicle)  // 0x5746F3A7AB7FE544
```

build 323

> Can be used with GET_TOTAL_DURATION_OF_VEHICLE_RECORDING{_ID} to compute a percentage.

## GET_TOTAL_DURATION_OF_VEHICLE_RECORDING

```c
float GET_TOTAL_DURATION_OF_VEHICLE_RECORDING(int recording, const char* script)  // 0x0E48D1C262390950
```

build 323

> See REQUEST_VEHICLE_RECORDING

## GET_TOTAL_DURATION_OF_VEHICLE_RECORDING_ID

```c
float GET_TOTAL_DURATION_OF_VEHICLE_RECORDING_ID(int id)  // 0x102D125411A7B6E6
```

build 323

## GET_TRAIN_CARRIAGE

```c
Vehicle GET_TRAIN_CARRIAGE(Vehicle train, int trailerNumber)  // 0x08AAFD0814722BC3
```

build 323

> Corrected p1. it's basically the 'carriage/trailer number'. So if the train has 3 trailers you'd call the native once with a var or 3 times with 1, 2, 3.

## GET_TYRE_HEALTH

```c
float GET_TYRE_HEALTH(Vehicle vehicle, int wheelIndex)  // 0x55EAB010FAEE9380
```

build 1868 · old names: `_GET_TYRE_HEALTH`

> Usable wheels:
> 0: wheel_lf
> 1: wheel_rf
> 2: wheel_lm1
> 3: wheel_rm1
> 4: wheel_lr
> 5: wheel_rr

## GET_TYRE_WEAR_RATE

```c
float GET_TYRE_WEAR_RATE(Vehicle vehicle, int wheelIndex)  // 0x6E387895952F4F71
```

build 2060 · old names: `_GET_TYRE_WEAR_MULTIPLIER`

> Returns the multiplier value from SET_TYRE_WEAR_RATE
> 
> Usable wheels:
> 0: wheel_lf
> 1: wheel_rf
> 2: wheel_lm1
> 3: wheel_rm1
> 4: wheel_lr
> 5: wheel_rr

## GET_VEHICLE_ACCELERATION

```c
float GET_VEHICLE_ACCELERATION(Vehicle vehicle)  // 0x5DD35C8D074E57AE
```

build 323

> static - max acceleration

## GET_VEHICLE_ATTACHED_TO_CARGOBOB

```c
Vehicle GET_VEHICLE_ATTACHED_TO_CARGOBOB(Vehicle cargobob)  // 0x873B82D42AC2B9E5
```

build 323

> Returns attached vehicle (Vehicle in parameter must be cargobob)

## GET_VEHICLE_BODY_HEALTH

```c
float GET_VEHICLE_BODY_HEALTH(Vehicle vehicle)  // 0xF271147EB7B40F12
```

build 323

> Seems related to vehicle health, like the one in IV.
> Max 1000, min 0.
> Vehicle does not necessarily explode or become undrivable at 0.

## GET_VEHICLE_BOMB_AMMO

```c
int GET_VEHICLE_BOMB_AMMO(Vehicle vehicle)  // 0xEA12BD130D7569A1
```

build 1180 · old names: `_GET_AIRCRAFT_BOMB_COUNT`, `_GET_VEHICLE_BOMB_COUNT`

> Gets the amount of bombs that this vehicle has. As far as I know, this does _not_ impact vehicle weapons or the ammo of those weapons in any way, it is just a way to keep track of the amount of bombs in a specific plane.

## GET_VEHICLE_CAN_DEPLOY_PARACHUTE

```c
BOOL GET_VEHICLE_CAN_DEPLOY_PARACHUTE(Vehicle vehicle)  // 0xA916396DF4154EE3
```

build 944 · old names: `_CAN_VEHICLE_PARACHUTE_BE_ACTIVATED`, `_GET_VEHICLE_CAN_ACTIVATE_PARACHUTE`

## GET_VEHICLE_CAUSE_OF_DESTRUCTION

```c
Hash GET_VEHICLE_CAUSE_OF_DESTRUCTION(Vehicle vehicle)  // 0xE495D1EF4C91FD20
```

build 323

> iVar3 = get_vehicle_cause_of_destruction(uLocal_248[iVar2]);
> if (iVar3 == joaat("weapon_stickybomb"))
> {
> 	func_171(726);
> 	iLocal_260 = 1;
> }

## GET_VEHICLE_CLASS

```c
int GET_VEHICLE_CLASS(Vehicle vehicle)  // 0x29439776AAA00A62
```

build 323

> Returns an int
> 
> Vehicle Classes:
> 0: Compacts
> 1: Sedans
> 2: SUVs
> 3: Coupes
> 4: Muscle
> 5: Sports Classics
> 6: Sports
> 7: Super
> 8: Motorcycles
> 9: Off-road
> 10: Industrial
> 11: Utility
> 12: Vans
> 13: Cycles
> 14: Boats
> 15: Helicopters
> 16: Planes
> 17: Service
> 18: Emergency
> 19: Military
> 20: Commercial
> 21: Trains
> 
> char buffer[128];
> std::sprintf(buffer, "VEH_CLASS_%i", VEHICLE::GET_VEHICLE_CLASS(vehicle));
> 
> const char* className = HUD::GET_FILENAME_FOR_AUDIO_CONVERSATION(buffer);

## GET_VEHICLE_CLASS_ESTIMATED_MAX_SPEED

```c
float GET_VEHICLE_CLASS_ESTIMATED_MAX_SPEED(int vehicleClass)  // 0x00C09F246ABEDD82
```

build 323 · old names: `_GET_VEHICLE_CLASS_MAX_SPEED`

## GET_VEHICLE_CLASS_FROM_NAME

```c
int GET_VEHICLE_CLASS_FROM_NAME(Hash modelHash)  // 0xDEDF1C8BD47C2200
```

build 323

> char buffer[128];
> std::sprintf(buffer, "VEH_CLASS_%i", VEHICLE::GET_VEHICLE_CLASS_FROM_NAME (hash));
> 
> const char* className = HUD::GET_FILENAME_FOR_AUDIO_CONVERSATION(buffer);
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_CLASS_MAX_ACCELERATION

```c
float GET_VEHICLE_CLASS_MAX_ACCELERATION(int vehicleClass)  // 0x2F83E7E45D9EA7AE
```

build 323

## GET_VEHICLE_CLASS_MAX_AGILITY

```c
float GET_VEHICLE_CLASS_MAX_AGILITY(int vehicleClass)  // 0x4F930AD022D6DE3B
```

build 323

## GET_VEHICLE_CLASS_MAX_BRAKING

```c
float GET_VEHICLE_CLASS_MAX_BRAKING(int vehicleClass)  // 0x4BF54C16EC8FEC03
```

build 323

## GET_VEHICLE_CLASS_MAX_TRACTION

```c
float GET_VEHICLE_CLASS_MAX_TRACTION(int vehicleClass)  // 0xDBC86D85C5059461
```

build 323

## GET_VEHICLE_COLOR

```c
void GET_VEHICLE_COLOR(Vehicle vehicle, int* r, int* g, int* b)  // 0xF3CC740D36221548
```

build 323

## GET_VEHICLE_COLOUR_COMBINATION

```c
int GET_VEHICLE_COLOUR_COMBINATION(Vehicle vehicle)  // 0x6A842D197F845D56
```

build 323

> Returns the index of the color combination found in the vehicle's carvariations.meta entry.

## GET_VEHICLE_COLOURS

```c
void GET_VEHICLE_COLOURS(Vehicle vehicle, int* colorPrimary, int* colorSecondary)  // 0xA19435F193E081AC
```

build 323

## GET_VEHICLE_COLOURS_WHICH_CAN_BE_SET

```c
int GET_VEHICLE_COLOURS_WHICH_CAN_BE_SET(Vehicle vehicle)  // 0xEEBFC7A7EFDC35B4
```

build 323

> Some kind of flags.

## GET_VEHICLE_COUNTERMEASURE_AMMO

```c
int GET_VEHICLE_COUNTERMEASURE_AMMO(Vehicle vehicle)  // 0xF846AA63DF56B804
```

build 1180 · old names: `_GET_AIRCRAFT_COUNTERMEASURE_COUNT`, `_GET_VEHICLE_COUNTERMEASURE_COUNT`

> Similar to `GET_VEHICLE_BOMB_AMMO`, this gets the amount of countermeasures that are present on this vehicle.
> Use SET_VEHICLE_COUNTERMEASURE_AMMO to set the current amount.

## GET_VEHICLE_CURRENT_TIME_IN_SLIP_STREAM

```c
float GET_VEHICLE_CURRENT_TIME_IN_SLIP_STREAM(Vehicle vehicle)  // 0x36492C2F0D134C56
```

build 323 · old names: `_GET_VEHICLE_CURRENT_SLIPSTREAM_DRAFT`

> Returns a float value between 0.0 and 3.0 related to its slipstream draft (boost/speedup).

## GET_VEHICLE_CUSTOM_PRIMARY_COLOUR

```c
void GET_VEHICLE_CUSTOM_PRIMARY_COLOUR(Vehicle vehicle, int* r, int* g, int* b)  // 0xB64CF2CCA9D95F52
```

build 323

## GET_VEHICLE_CUSTOM_SECONDARY_COLOUR

```c
void GET_VEHICLE_CUSTOM_SECONDARY_COLOUR(Vehicle vehicle, int* r, int* g, int* b)  // 0x8389CD56CA8072DC
```

build 323

## GET_VEHICLE_DEFORMATION_AT_POS

```c
Vector3 GET_VEHICLE_DEFORMATION_AT_POS(Vehicle vehicle, float offsetX, float offsetY, float offsetZ)  // 0x4EC6CFBC7B2E9536
```

build 323

> The only example I can find of this function in the scripts, is this:
> 
> struct _s = VEHICLE::GET_VEHICLE_DEFORMATION_AT_POS(rPtr((A_0) + 4), 1.21f, 6.15f, 0.3f);
> 
> -----------------------------------------------------------------------------------------------------------------------------------------
> PC scripts:
> 
> v_5/*{3}*/ = VEHICLE::GET_VEHICLE_DEFORMATION_AT_POS(a_0._f1, 1.21, 6.15, 0.3);

## GET_VEHICLE_DIRT_LEVEL

```c
float GET_VEHICLE_DIRT_LEVEL(Vehicle vehicle)  // 0x8F17BC8BA08DA62B
```

build 323

> Dirt level does not become greater than 15.0

## GET_VEHICLE_DOOR_ANGLE_RATIO

```c
float GET_VEHICLE_DOOR_ANGLE_RATIO(Vehicle vehicle, int doorId)  // 0xFE3F9C29F7B32BD5
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## GET_VEHICLE_DOOR_LOCK_STATUS

```c
int GET_VEHICLE_DOOR_LOCK_STATUS(Vehicle vehicle)  // 0x25BC98A59C2EA962
```

build 323

> enum VehicleLockStatus = {
>     None = 0,
>     Unlocked = 1,
>     Locked = 2,
>     LockedForPlayer = 3,
>     StickPlayerInside = 4, -- Doesn't allow players to exit the vehicle with the exit vehicle key.
>     CanBeBrokenInto = 7, -- Can be broken into the car. If the glass is broken, the value will be set to 1
>     CanBeBrokenIntoPersist = 8, -- Can be broken into persist
>     CannotBeTriedToEnter = 10, -- Cannot be tried to enter (Nothing happens when you press the vehicle enter key).
> }

## GET_VEHICLE_DOORS_LOCKED_FOR_PLAYER

```c
BOOL GET_VEHICLE_DOORS_LOCKED_FOR_PLAYER(Vehicle vehicle, Player player)  // 0xF6AF6CB341349015
```

build 323

## GET_VEHICLE_ENGINE_HEALTH

```c
float GET_VEHICLE_ENGINE_HEALTH(Vehicle vehicle)  // 0xC45D23BAF168AAB8
```

build 323

> Returns 1000.0 if the function is unable to get the address of the specified vehicle or if it's not a vehicle.
> 
> Minimum: -4000
> Maximum: 1000
> 
> -4000: Engine is destroyed
> 0 and below: Engine catches fire and health rapidly declines
> 300: Engine is smoking and losing functionality
> 1000: Engine is perfect

## GET_VEHICLE_ENVEFF_SCALE

```c
float GET_VEHICLE_ENVEFF_SCALE(Vehicle vehicle)  // 0xA82819CAC9C4C403
```

build 323 · old names: `_GET_VEHICLE_PAINT_FADE`

> The result is a value from 0-1, where 0 is fresh paint.

## GET_VEHICLE_ESTIMATED_MAX_SPEED

```c
float GET_VEHICLE_ESTIMATED_MAX_SPEED(Vehicle vehicle)  // 0x53AF99BAA671CA47
```

build 323 · old names: `_GET_VEHICLE_MAX_SPEED`

## GET_VEHICLE_EXTRA_COLOUR_5

```c
void GET_VEHICLE_EXTRA_COLOUR_5(Vehicle vehicle, int* color)  // 0x7D1464D472D32136
```

build 505 · old names: `_GET_VEHICLE_INTERIOR_COLOUR`, `_GET_VEHICLE_INTERIOR_COLOR`

## GET_VEHICLE_EXTRA_COLOUR_6

```c
void GET_VEHICLE_EXTRA_COLOUR_6(Vehicle vehicle, int* color)  // 0xB7635E80A5C31BFF
```

build 505 · old names: `_GET_VEHICLE_DASHBOARD_COLOUR`, `_GET_VEHICLE_DASHBOARD_COLOR`

## GET_VEHICLE_EXTRA_COLOURS

```c
void GET_VEHICLE_EXTRA_COLOURS(Vehicle vehicle, int* pearlescentColor, int* wheelColor)  // 0x3BC4245933A166F7
```

build 323

## GET_VEHICLE_FLIGHT_NOZZLE_POSITION

```c
float GET_VEHICLE_FLIGHT_NOZZLE_POSITION(Vehicle plane)  // 0xDA62027C8BDB326E
```

build 1180 · old names: `_GET_PLANE_HOVER_MODE_PERCENTAGE`, `_GET_VEHICLE_HOVER_MODE_PERCENTAGE`, `_GET_PLANE_VTOL_DIRECTION`, `_GET_VEHICLE_FLIGHT_NOZZLE_POSITION`

## GET_VEHICLE_HAS_KERS

```c
BOOL GET_VEHICLE_HAS_KERS(Vehicle vehicle)  // 0x50634E348C8D44EF
```

build 372 · old names: `_HAS_VEHICLE_KERS_BOOST`

> Returns true if the vehicle has a HF_HAS_KERS (strHandlingFlags 0x4) handing flag set, for instance the lectro/vindicator bikes or the open wheelers.

## GET_VEHICLE_HAS_LANDING_GEAR

```c
BOOL GET_VEHICLE_HAS_LANDING_GEAR(Vehicle vehicle)  // 0xE43701C36CAFF1A4
```

build 1180 · old names: `_GET_VEHICLE_HAS_LANDING_GEAR`, `_DOES_VEHICLE_HAVE_LANDING_GEAR`

## GET_VEHICLE_HAS_PARACHUTE

```c
BOOL GET_VEHICLE_HAS_PARACHUTE(Vehicle vehicle)  // 0xBC9CFF381338CB4F
```

build 944 · old names: `_HAS_VEHICLE_PARACHUTE`, `_DOES_VEHICLE_HAVE_PARACHUTE`, `_GET_VEHICLE_HAS_PARACHUTE`

## GET_VEHICLE_HEALTH_PERCENTAGE

```c
float GET_VEHICLE_HEALTH_PERCENTAGE(Vehicle vehicle, float maxEngineHealth, float maxPetrolTankHealth, float maxBodyHealth, float maxMainRotorHealth, float maxTailRotorHealth, float maxUnkHealth)  // 0xB8EF61207C2393A9
```

build 323 · old names: `_GET_VEHICLE_BODY_HEALTH_2`

> 0 min 100 max
> starts at 100
> Seams to have health zones
> Front of vehicle when damaged goes from 100-50 and stops at 50.
> Rear can be damaged from 100-0
> Only tested with two cars.
> 
> --
> May return the vehicle health on a scale of 0.0 - 100.0 (needs to be confirmed)
> 
> example:
> 
> v_F = ENTITY::GET_ENTITY_MODEL(v_3);
> if (((v_F == ${tanker}) || (v_F == ${armytanker})) || (v_F == ${tanker2})) {
>     if (VEHICLE::GET_VEHICLE_HEALTH_PERCENTAGE(v_3) <= 1.0) {
>         NETWORK::NETWORK_EXPLODE_VEHICLE(v_3, 1, 1, -1);
>     }
> }

## GET_VEHICLE_HOMING_LOCKEDONTO_STATE

```c
int GET_VEHICLE_HOMING_LOCKEDONTO_STATE(Any p0)  // 0x6EAAEFC76ACC311F
```

build 757

## GET_VEHICLE_HOMING_LOCKON_STATE

```c
int GET_VEHICLE_HOMING_LOCKON_STATE(Vehicle vehicle)  // 0xE6B0E8CFC3633BF0
```

build 323

> Returns a value depending on the lock-on state of vehicle weapons.
> 0: not locked on
> 1: locking on
> 2: locked on

## GET_VEHICLE_INDIVIDUAL_DOOR_LOCK_STATUS

```c
int GET_VEHICLE_INDIVIDUAL_DOOR_LOCK_STATUS(Vehicle vehicle, int doorId)  // 0xCA4AC3EAAE46EC7B
```

build 1103 · old names: `_GET_VEHICLE_DOOR_DESTROY_TYPE`

> Returns vehicle door lock state previously set with SET_VEHICLE_INDIVIDUAL_DOORS_LOCKED

## GET_VEHICLE_IS_DUMMY

```c
BOOL GET_VEHICLE_IS_DUMMY(Any p0)  // 0x8533CAFDE1F0F336
```

build 505

## GET_VEHICLE_IS_MERCENARY

```c
BOOL GET_VEHICLE_IS_MERCENARY(Vehicle vehicle)  // 0xD4C4642CB7F50B5D
```

build 323

## GET_VEHICLE_LAYOUT_HASH

```c
Hash GET_VEHICLE_LAYOUT_HASH(Vehicle vehicle)  // 0x28D37D4F71AC5C58
```

build 323

> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_LIGHTS_STATE

```c
BOOL GET_VEHICLE_LIGHTS_STATE(Vehicle vehicle, BOOL* lightsOn, BOOL* highbeamsOn)  // 0xB91B4C20085BD12F
```

build 323

## GET_VEHICLE_LIVERY

```c
int GET_VEHICLE_LIVERY(Vehicle vehicle)  // 0x2BB9230590DA5E8A
```

build 323

> -1 = no livery

## GET_VEHICLE_LIVERY_COUNT

```c
int GET_VEHICLE_LIVERY_COUNT(Vehicle vehicle)  // 0x87B63E25A529D526
```

build 323

> Returns -1 if the vehicle has no livery

## GET_VEHICLE_LIVERY2

```c
int GET_VEHICLE_LIVERY2(Vehicle vehicle)  // 0x60190048C0764A26
```

build 505 · old names: `_GET_VEHICLE_ROOF_LIVERY`

> Returns index of the current vehicle's secondary livery. A getter for SET_VEHICLE_LIVERY2.

## GET_VEHICLE_LIVERY2_COUNT

```c
int GET_VEHICLE_LIVERY2_COUNT(Vehicle vehicle)  // 0x5ECB40269053C0D4
```

build 505 · old names: `_GET_VEHICLE_ROOF_LIVERY_COUNT`

> Returns a number of available secondary liveries, or -1 if vehicle has no secondary liveries available.

## GET_VEHICLE_LOCK_ON_TARGET

```c
BOOL GET_VEHICLE_LOCK_ON_TARGET(Vehicle vehicle, Entity* entity)  // 0x8F5EBAB1F260CFCE
```

build 323 · old names: `_GET_VEHICLE_OWNER`

## GET_VEHICLE_MAX_BRAKING

```c
float GET_VEHICLE_MAX_BRAKING(Vehicle vehicle)  // 0xAD7E85FC227197C4
```

build 323

## GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS

```c
int GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS(Vehicle vehicle)  // 0xA7C4F2C6E744A550
```

build 323

## GET_VEHICLE_MAX_TRACTION

```c
float GET_VEHICLE_MAX_TRACTION(Vehicle vehicle)  // 0xA132FB5370554DB0
```

build 323

## GET_VEHICLE_MOD

```c
int GET_VEHICLE_MOD(Vehicle vehicle, int modType)  // 0x772960298DA26FDB
```

build 323

> In b944, there are 50 (0 - 49) mod types. See SET_VEHICLE_MOD for the list.
> 
> Returns -1 if the vehicle mod is stock

## GET_VEHICLE_MOD_COLOR_1

```c
void GET_VEHICLE_MOD_COLOR_1(Vehicle vehicle, int* paintType, int* color, int* pearlescentColor)  // 0xE8D65CA700C9A693
```

build 323

## GET_VEHICLE_MOD_COLOR_1_NAME

```c
const char* GET_VEHICLE_MOD_COLOR_1_NAME(Vehicle vehicle, BOOL p1)  // 0xB45085B721EFD38C
```

build 323

> Returns a string which is the codename of the vehicle's currently selected primary color
> 
> p1 is always 0

## GET_VEHICLE_MOD_COLOR_2

```c
void GET_VEHICLE_MOD_COLOR_2(Vehicle vehicle, int* paintType, int* color)  // 0x81592BE4E3878728
```

build 323

## GET_VEHICLE_MOD_COLOR_2_NAME

```c
const char* GET_VEHICLE_MOD_COLOR_2_NAME(Vehicle vehicle)  // 0x4967A516ED23A5A1
```

build 323

> Returns a string which is the codename of the vehicle's currently selected secondary color

## GET_VEHICLE_MOD_IDENTIFIER_HASH

```c
Hash GET_VEHICLE_MOD_IDENTIFIER_HASH(Vehicle vehicle, int modType, int modIndex)  // 0x4593CF82AA179706
```

build 323 · old names: `_GET_VEHICLE_MOD_DATA`

> Can be used for IS_DLC_VEHICLE_MOD and GET_DLC_VEHICLE_MOD_LOCK_HASH

## GET_VEHICLE_MOD_KIT

```c
int GET_VEHICLE_MOD_KIT(Vehicle vehicle)  // 0x6325D1A044AE510D
```

build 323

## GET_VEHICLE_MOD_KIT_TYPE

```c
int GET_VEHICLE_MOD_KIT_TYPE(Vehicle vehicle)  // 0xFC058F5121E54C32
```

build 323

## GET_VEHICLE_MOD_MODIFIER_VALUE

```c
int GET_VEHICLE_MOD_MODIFIER_VALUE(Vehicle vehicle, int modType, int modIndex)  // 0x90A38E9838E0A8C1
```

build 323

## GET_VEHICLE_MOD_VARIATION

```c
int GET_VEHICLE_MOD_VARIATION(Vehicle vehicle, int modType)  // 0xB3924ECD70E095DC
```

build 323

> Only used for wheels(ModType = 23/24) Returns true if the wheels are custom wheels

## GET_VEHICLE_MODEL_ACCELERATION

```c
float GET_VEHICLE_MODEL_ACCELERATION(Hash modelHash)  // 0x8C044C5C84505B6A
```

build 323

> Returns the acceleration of the specified model.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_MODEL_ACCELERATION_MAX_MODS

```c
float GET_VEHICLE_MODEL_ACCELERATION_MAX_MODS(Hash modelHash)  // 0x53409B5163D5B846
```

build 323 · old names: `_GET_VEHICLE_MODEL_DOWN_FORCE`, `_GET_VEHICLE_MODEL_ESTIMATED_AGILITY`

> 9.8 * thrust if air vehicle, else 0.38 + drive force?
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_MODEL_ESTIMATED_MAX_SPEED

```c
float GET_VEHICLE_MODEL_ESTIMATED_MAX_SPEED(Hash modelHash)  // 0xF417C2502FFFED43
```

build 323 · old names: `_GET_VEHICLE_MODEL_MAX_SPEED`

> Returns max speed (without mods) of the specified vehicle model in m/s.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_MODEL_MAX_BRAKING

```c
float GET_VEHICLE_MODEL_MAX_BRAKING(Hash modelHash)  // 0xDC53FD41B4ED944C
```

build 323

> Returns max braking of the specified vehicle model.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_MODEL_MAX_BRAKING_MAX_MODS

```c
float GET_VEHICLE_MODEL_MAX_BRAKING_MAX_MODS(Hash modelHash)  // 0xBFBA3BA79CFF7EBF
```

build 323 · old names: `_GET_VEHICLE_MODEL_HAND_BRAKE`

> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_MODEL_MAX_TRACTION

```c
float GET_VEHICLE_MODEL_MAX_TRACTION(Hash modelHash)  // 0x539DE94D44FDFD0D
```

build 323

> Returns max traction of the specified vehicle model.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_MODEL_NUMBER_OF_SEATS

```c
int GET_VEHICLE_MODEL_NUMBER_OF_SEATS(Hash modelHash)  // 0x2AD93716F184EDA4
```

build 323 · old names: `_GET_VEHICLE_MODEL_MAX_NUMBER_OF_PASSENGERS`

> Returns max number of passengers (including the driver) for the specified vehicle model.
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## GET_VEHICLE_MODEL_VALUE

```c
int GET_VEHICLE_MODEL_VALUE(Hash vehicleModel)  // 0x5873C14A52D74236
```

build 463 · old names: `_GET_VEHICLE_MODEL_MONETARY_VALUE`

> Returns `nMonetaryValue` from handling.meta for specific model.

## GET_VEHICLE_NEON_COLOUR

```c
void GET_VEHICLE_NEON_COLOUR(Vehicle vehicle, int* r, int* g, int* b)  // 0x7619EEE8C886757F
```

build 323 · old names: `_GET_VEHICLE_NEON_LIGHTS_COLOUR`

> Gets the color of the neon lights of the specified vehicle.
> 
> See SET_VEHICLE_NEON_COLOUR (0x8E0A582209A62695) for more information

## GET_VEHICLE_NEON_ENABLED

```c
BOOL GET_VEHICLE_NEON_ENABLED(Vehicle vehicle, int index)  // 0x8C4B92553E4766A5
```

build 323 · old names: `_IS_VEHICLE_NEON_LIGHT_ENABLED`

> indices:
> 0 = Left
> 1 = Right
> 2 = Front
> 3 = Back

## GET_VEHICLE_NUM_OF_BROKEN_LOOSEN_PARTS

```c
int GET_VEHICLE_NUM_OF_BROKEN_LOOSEN_PARTS(Vehicle vehicle)  // 0x2C8CBFE1EA5FC631
```

build 323 · old names: `_GET_VEHICLE_NUMBER_OF_BROKEN_BONES`

## GET_VEHICLE_NUM_OF_BROKEN_OFF_PARTS

```c
int GET_VEHICLE_NUM_OF_BROKEN_OFF_PARTS(Vehicle vehicle)  // 0x42A4BEB35D372407
```

build 323 · old names: `_GET_VEHICLE_NUMBER_OF_BROKEN_OFF_BONES`

> Also includes some "turnOffBones" when vehicle mods are installed.

## GET_VEHICLE_NUMBER_OF_PASSENGERS

```c
int GET_VEHICLE_NUMBER_OF_PASSENGERS(Vehicle vehicle, BOOL includeDriver, BOOL includeDeadOccupants)  // 0x24CB2137731FFE89
```

build 323

> Gets the number of passengers.
> 
> This native was modified in b2545 to take two additional parameters, allowing you to include the driver or exclude dead passengers.
> 
> To keep it working like before b2545, set includeDriver to false and includeDeadOccupants to true.

## GET_VEHICLE_NUMBER_PLATE_TEXT

```c
const char* GET_VEHICLE_NUMBER_PLATE_TEXT(Vehicle vehicle)  // 0x7CE1CCB9B293020E
```

build 323

> Returns the license plate text from a vehicle. 8 chars maximum.

## GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX

```c
int GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX(Vehicle vehicle)  // 0xF11BC2DD9A3E7195
```

build 323

> Returns the PlateType of a vehicle
>       Blue_on_White_1 = 3,
>       Blue_on_White_2 = 0,
>       Blue_on_White_3 = 4,
>       Yellow_on_Blue = 2,
>        Yellow_on_Black = 1,
>       North_Yankton = 5,

## GET_VEHICLE_PETROL_TANK_HEALTH

```c
float GET_VEHICLE_PETROL_TANK_HEALTH(Vehicle vehicle)  // 0x7D5DABE888D2D074
```

build 323

> 1000 is max health
> Begins leaking gas at around 650 health
> -999.90002441406 appears to be minimum health, although nothing special occurs

## GET_VEHICLE_PLATE_TYPE

```c
int GET_VEHICLE_PLATE_TYPE(Vehicle vehicle)  // 0x9CCC9525BF2408E0
```

build 323

## GET_VEHICLE_RECORDING_ID

```c
int GET_VEHICLE_RECORDING_ID(int recording, const char* script)  // 0x21543C612379DB3C
```

build 323

> See REQUEST_VEHICLE_RECORDING

## GET_VEHICLE_SIZE

```c
void GET_VEHICLE_SIZE(Vehicle vehicle, Vector3* out1, Vector3* out2)  // 0xDF7E3EEB29642C38
```

build 323 · old names: `_GET_VEHICLE_SUSPENSION_BOUNDS`

> Outputs 2 Vector3's.
> Scripts check if out2.x - out1.x > someshit.x
> Could be suspension related, as in max suspension height and min suspension height, considering the natives location.

## GET_VEHICLE_TRAILER_VEHICLE

```c
BOOL GET_VEHICLE_TRAILER_VEHICLE(Vehicle vehicle, Vehicle* trailer)  // 0x1CDD6BADC297830D
```

build 323

> Gets the trailer of a vehicle and puts it into the trailer parameter.

## GET_VEHICLE_TYRE_SMOKE_COLOR

```c
void GET_VEHICLE_TYRE_SMOKE_COLOR(Vehicle vehicle, int* r, int* g, int* b)  // 0xB635392A4938B3C3
```

build 323

## GET_VEHICLE_TYRES_CAN_BURST

```c
BOOL GET_VEHICLE_TYRES_CAN_BURST(Vehicle vehicle)  // 0x678B9BB8C3F58FEB
```

build 323

## GET_VEHICLE_WEAPON_RESTRICTED_AMMO

```c
int GET_VEHICLE_WEAPON_RESTRICTED_AMMO(Vehicle vehicle, int weaponIndex)  // 0x8181CE2F25CB9BB7
```

build 1011 · old names: `_GET_VEHICLE_WEAPON_CAPACITY`

## GET_VEHICLE_WHEEL_TYPE

```c
int GET_VEHICLE_WHEEL_TYPE(Vehicle vehicle)  // 0xB3ED1BFB4BE636DC
```

build 323

> Returns an int
> 
> Wheel Types:
> 0: Sport
> 1: Muscle
> 2: Lowrider
> 3: SUV
> 4: Offroad
> 5: Tuner
> 6: Bike Wheels
> 7: High End
> 8: Benny's Originals
> 9: Benny's Bespoke
> 10: Racing
> 11: Street
> 12: Track
> 
> Tested in Los Santos Customs

## GET_VEHICLE_WINDOW_TINT

```c
int GET_VEHICLE_WINDOW_TINT(Vehicle vehicle)  // 0x0EE21293DAD47C95
```

build 323

## GET_VEHICLE_XENON_LIGHT_COLOR_INDEX

```c
int GET_VEHICLE_XENON_LIGHT_COLOR_INDEX(Vehicle vehicle)  // 0x3DFF319A831E0CDB
```

build 1604 · old names: `_GET_VEHICLE_HEADLIGHTS_COLOUR`, `_GET_VEHICLE_XENON_LIGHTS_COLOUR`, `_GET_VEHICLE_XENON_LIGHTS_COLOR`

> Returns the headlight color index from the vehicle. Value between 0, 12.
> Use SET_VEHICLE_XENON_LIGHT_COLOR_INDEX to set the headlights color for the vehicle.
> Must enable xenon headlights before it'll take affect.
> 
> Returns an int, value between 0-12 or 255 if no color is set.

## HAS_INSTANT_FILL_VEHICLE_POPULATION_FINISHED

```c
BOOL HAS_INSTANT_FILL_VEHICLE_POPULATION_FINISHED()  // 0x91D6DD290888CBAB
```

build 323 · old names: `_HAS_FILLED_VEHICLE_POPULATION`

## HAS_PRELOAD_MODS_FINISHED

```c
BOOL HAS_PRELOAD_MODS_FINISHED(Vehicle vehicle)  // 0x06F43E5175EB6D96
```

build 323

## HAS_VEHICLE_ASSET_LOADED

```c
BOOL HAS_VEHICLE_ASSET_LOADED(int vehicleAsset)  // 0x1BBE0523B8DB9A21
```

build 323

## HAS_VEHICLE_PETROLTANK_SET_ON_FIRE_BY_ENTITY

```c
BOOL HAS_VEHICLE_PETROLTANK_SET_ON_FIRE_BY_ENTITY(Any p0, Any p1)  // 0x5BA68A0840D546AC
```

build 463

## HAS_VEHICLE_PHONE_EXPLOSIVE_DEVICE

```c
BOOL HAS_VEHICLE_PHONE_EXPLOSIVE_DEVICE()  // 0x6ADAABD3068C5235
```

build 323

## HAS_VEHICLE_RECORDING_BEEN_LOADED

```c
BOOL HAS_VEHICLE_RECORDING_BEEN_LOADED(int recording, const char* script)  // 0x300D614A4C785FC4
```

build 323

> See REQUEST_VEHICLE_RECORDING

## HAVE_VEHICLE_MODS_STREAMED_IN

```c
BOOL HAVE_VEHICLE_MODS_STREAMED_IN(Vehicle vehicle)  // 0x9A83F5F9963775EF
```

build 323 · old names: `_IS_VEHICLE_MOD_LOAD_DONE`

## HAVE_VEHICLE_REAR_DOORS_BEEN_BLOWN_OPEN_BY_STICKYBOMB

```c
BOOL HAVE_VEHICLE_REAR_DOORS_BEEN_BLOWN_OPEN_BY_STICKYBOMB(Vehicle vehicle)  // 0x6B407F2525E93644
```

build 2944

## HIDE_TOMBSTONE

```c
void HIDE_TOMBSTONE(Vehicle vehicle, BOOL toggle)  // 0xAE71FB656C600587
```

build 1604 · old names: `_HIDE_VEHICLE_TOMBSTONE`

> Disables detachable bumber from domnator4, dominator5, dominator6

## INSTANTLY_FILL_VEHICLE_POPULATION

```c
void INSTANTLY_FILL_VEHICLE_POPULATION()  // 0x48ADC8A773564670
```

build 323

## IS_ANY_ENTITY_ATTACHED_TO_HANDLER_FRAME

```c
BOOL IS_ANY_ENTITY_ATTACHED_TO_HANDLER_FRAME(Vehicle vehicle)  // 0x62CA17B74C435651
```

build 323

## IS_ANY_PED_RAPPELLING_FROM_HELI

```c
BOOL IS_ANY_PED_RAPPELLING_FROM_HELI(Vehicle vehicle)  // 0x291E373D483E7EE7
```

build 323 · old names: `_ANY_PASSENGERS_RAPPELING`, `_IS_ANY_PASSENGER_RAPPELING_FROM_VEHICLE`

## IS_ANY_VEHICLE_NEAR_POINT

```c
BOOL IS_ANY_VEHICLE_NEAR_POINT(float x, float y, float z, float radius)  // 0x61E1DD6125A3EEE6
```

build 323

## IS_BIG_VEHICLE

```c
BOOL IS_BIG_VEHICLE(Vehicle vehicle)  // 0x9F243D3919F442FE
```

build 323

> Returns true if MF_IS_BIG (strModelFlags 0x8) handling model flag is set.

## IS_BOAT_ANCHORED

```c
BOOL IS_BOAT_ANCHORED(Vehicle vehicle)  // 0xB0AD1238A709B1A2
```

build 573 · old names: `_IS_BOAT_ANCHORED_AND_FROZEN`

## IS_COP_VEHICLE_IN_AREA_3D

```c
BOOL IS_COP_VEHICLE_IN_AREA_3D(float x1, float x2, float y1, float y2, float z1, float z2)  // 0x7EEF65D5F153E26A
```

build 323

> Usage:
> 
> public bool isCopInRange(Vector3 Location, float Range)
>         {
>             return Function.Call<bool>(Hash.IS_COP_PED_IN_AREA_3D, Location.X - Range, Location.Y - Range, Location.Z - Range, Location.X + Range, Location.Y + Range, Location.Z + Range);
>         }

## IS_ENTITY_ATTACHED_TO_HANDLER_FRAME

```c
BOOL IS_ENTITY_ATTACHED_TO_HANDLER_FRAME(Vehicle vehicle, Entity entity)  // 0x57715966069157AD
```

build 323 · old names: `SET_PED_ENABLED_BIKE_RINGTONE`, `_IS_VEHICLE_NEAR_ENTITY`

## IS_ENTRY_POINT_FOR_SEAT_CLEAR

```c
BOOL IS_ENTRY_POINT_FOR_SEAT_CLEAR(Ped ped, Vehicle vehicle, int seatIndex, BOOL side, BOOL onEnter)  // 0x639431E895B9AA57
```

build 323 · old names: `_IS_VEHICLE_SEAT_ACCESSIBLE`

> Check if a vehicle seat is accessible. If you park your vehicle near a wall and the ped cannot enter/exit this side, the return value toggles from true (not blocked) to false (blocked).
> 
> seatIndex  = -1 being the driver seat.
> Use GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS(vehicle) - 1 for last seat index.
> side = only relevant for bikes/motorcycles to check if the left (false)/right (true) side is blocked.
> onEnter = check if you can enter (true) or exit (false) a vehicle.

## IS_EXTRA_BROKEN_OFF

```c
BOOL IS_EXTRA_BROKEN_OFF(Vehicle vehicle, int extraId)  // 0x534E36D4DB9ECC5D
```

build 1493 · old names: `_DOES_VEHICLE_TYRE_EXIST`

> Returns true if specified extra part is broken off. It only works for extras that can break off during collisions, non-breakable extras always return false. Also returns true if the breakable extra is toggled off through script.

## IS_HANDLER_FRAME_LINED_UP_WITH_CONTAINER

```c
BOOL IS_HANDLER_FRAME_LINED_UP_WITH_CONTAINER(Vehicle vehicle, Entity entity)  // 0x89D630CF5EA96D23
```

build 323 · old names: `_IS_HANDLER_FRAME_ABOVE_CONTAINER`

## IS_HELI_LANDING_AREA_BLOCKED

```c
BOOL IS_HELI_LANDING_AREA_BLOCKED(Vehicle vehicle)  // 0x634148744F385576
```

build 323

## IS_HELI_PART_BROKEN

```c
BOOL IS_HELI_PART_BROKEN(Vehicle vehicle, BOOL p1, BOOL p2, BOOL p3)  // 0xBC74B4BE25EB6C8A
```

build 323

## IS_MISSION_TRAIN

```c
BOOL IS_MISSION_TRAIN(Vehicle train)  // 0xAD464F2E18836BFC
```

build 2372 · old names: `_IS_MISSION_TRAIN`

## IS_NITROUS_ACTIVE

```c
BOOL IS_NITROUS_ACTIVE(Vehicle vehicle)  // 0x491E822B2C464FE4
```

build 3095

## IS_PED_EXCLUSIVE_DRIVER_OF_VEHICLE

```c
BOOL IS_PED_EXCLUSIVE_DRIVER_OF_VEHICLE(Ped ped, Vehicle vehicle, int* outIndex)  // 0xB09D25E77C33EB3F
```

build 463 · old names: `_IS_PED_EXCLUSIVE_DRIVER_OF_VEHICLE`

## IS_PLANE_LANDING_GEAR_INTACT

```c
BOOL IS_PLANE_LANDING_GEAR_INTACT(Vehicle plane)  // 0x4198AB0022B15F87
```

build 323 · old names: `_VEHICLE_HAS_LANDING_GEAR`

## IS_PLAYBACK_GOING_ON_FOR_VEHICLE

```c
BOOL IS_PLAYBACK_GOING_ON_FOR_VEHICLE(Vehicle vehicle)  // 0x1C8A4C2C19E68EEC
```

build 323

## IS_PLAYBACK_USING_AI_GOING_ON_FOR_VEHICLE

```c
BOOL IS_PLAYBACK_USING_AI_GOING_ON_FOR_VEHICLE(Vehicle vehicle)  // 0xAEA8FD591FAD4106
```

build 323

## IS_ROCKET_BOOST_ACTIVE

```c
BOOL IS_ROCKET_BOOST_ACTIVE(Vehicle vehicle)  // 0x3D34E80EED4AE3BE
```

build 944 · old names: `_IS_VEHICLE_ROCKET_BOOST_ACTIVE`

## IS_SEAT_WARP_ONLY

```c
BOOL IS_SEAT_WARP_ONLY(Vehicle vehicle, int seatIndex)  // 0xF7F203E31F96F6A1
```

build 323

## IS_TAXI_LIGHT_ON

```c
BOOL IS_TAXI_LIGHT_ON(Vehicle vehicle)  // 0x7504C0F113AB50FC
```

build 323

## IS_THIS_MODEL_A_BICYCLE

```c
BOOL IS_THIS_MODEL_A_BICYCLE(Hash model)  // 0xBF94DD42F63BDED2
```

build 323

## IS_THIS_MODEL_A_BIKE

```c
BOOL IS_THIS_MODEL_A_BIKE(Hash model)  // 0xB50C0B0CEDC6CE84
```

build 323

## IS_THIS_MODEL_A_BOAT

```c
BOOL IS_THIS_MODEL_A_BOAT(Hash model)  // 0x45A9187928F4B9E3
```

build 323

## IS_THIS_MODEL_A_CAR

```c
BOOL IS_THIS_MODEL_A_CAR(Hash model)  // 0x7F6DB52EEFC96DF8
```

build 323

> To check if the model is an amphibious car, use IS_THIS_MODEL_AN_AMPHIBIOUS_CAR.

## IS_THIS_MODEL_A_HELI

```c
BOOL IS_THIS_MODEL_A_HELI(Hash model)  // 0xDCE4334788AF94EA
```

build 323

## IS_THIS_MODEL_A_JETSKI

```c
BOOL IS_THIS_MODEL_A_JETSKI(Hash model)  // 0x9537097412CF75FE
```

build 323 · old names: `_IS_THIS_MODEL_A_SUBMERSIBLE`, `_IS_THIS_MODEL_AN_EMERGENCY_BOAT`

> Checks if model is a boat, then checks for FLAG_IS_JETSKI.

## IS_THIS_MODEL_A_PLANE

```c
BOOL IS_THIS_MODEL_A_PLANE(Hash model)  // 0xA0948AB42D7BA0DE
```

build 323

## IS_THIS_MODEL_A_QUADBIKE

```c
BOOL IS_THIS_MODEL_A_QUADBIKE(Hash model)  // 0x39DAC362EE65FA28
```

build 323

## IS_THIS_MODEL_A_TRAIN

```c
BOOL IS_THIS_MODEL_A_TRAIN(Hash model)  // 0xAB935175B22E822B
```

build 323

## IS_THIS_MODEL_AN_AMPHIBIOUS_CAR

```c
BOOL IS_THIS_MODEL_AN_AMPHIBIOUS_CAR(Hash model)  // 0x633F6F44A537EBB6
```

build 944 · old names: `_IS_THIS_MODEL_AN_AMPHIBIOUS_CAR`

## IS_THIS_MODEL_AN_AMPHIBIOUS_QUADBIKE

```c
BOOL IS_THIS_MODEL_AN_AMPHIBIOUS_QUADBIKE(Hash model)  // 0xA1A9FC1C76A6730D
```

build 1103 · old names: `_IS_THIS_MODEL_AN_AMPHIBIOUS_QUADBIKE`

## IS_TOGGLE_MOD_ON

```c
BOOL IS_TOGGLE_MOD_ON(Vehicle vehicle, int modType)  // 0x84B233A8C8FC8AE7
```

build 323

## IS_TURRET_SEAT

```c
BOOL IS_TURRET_SEAT(Vehicle vehicle, int seatIndex)  // 0xE33FFA906CE74880
```

build 323

## IS_VEHICLE_A_CONVERTIBLE

```c
BOOL IS_VEHICLE_A_CONVERTIBLE(Vehicle vehicle, BOOL p1)  // 0x52F357A30698BCCE
```

build 323

> Returns true if the vehicle has a convertible roof.
> 
> p1 is false almost always. However, in launcher_carwash/carwash1/carwash2 scripts, p1 is true and is accompanied by DOES_VEHICLE_HAVE_ROOF. If p1 is true, it seems that every single vehicle will return true irrespective of being a convertible.

## IS_VEHICLE_ALARM_ACTIVATED

```c
BOOL IS_VEHICLE_ALARM_ACTIVATED(Vehicle vehicle)  // 0x4319E335B71FFF34
```

build 323

## IS_VEHICLE_ATTACHED_TO_CARGOBOB

```c
BOOL IS_VEHICLE_ATTACHED_TO_CARGOBOB(Vehicle cargobob, Vehicle vehicleAttached)  // 0xD40148F22E81A1D9
```

build 323

## IS_VEHICLE_ATTACHED_TO_TOW_TRUCK

```c
BOOL IS_VEHICLE_ATTACHED_TO_TOW_TRUCK(Vehicle towTruck, Vehicle vehicle)  // 0x146DF9EC4C4B9FD4
```

build 323

> Scripts verify that towTruck is the first parameter, not the second.

## IS_VEHICLE_ATTACHED_TO_TRAILER

```c
BOOL IS_VEHICLE_ATTACHED_TO_TRAILER(Vehicle vehicle)  // 0xE7CF3C4F9F489F0C
```

build 323

## IS_VEHICLE_BEING_BROUGHT_TO_HALT

```c
BOOL IS_VEHICLE_BEING_BROUGHT_TO_HALT(Vehicle vehicle)  // 0xC69BB1D832A710EF
```

build 1493 · old names: `_IS_VEHICLE_BEING_HALTED`

> Returns true if vehicle is halted by BRING_VEHICLE_TO_HALT

## IS_VEHICLE_BUMPER_BOUNCING

```c
BOOL IS_VEHICLE_BUMPER_BOUNCING(Vehicle vehicle, BOOL frontBumper)  // 0x27B926779DEB502D
```

build 323

## IS_VEHICLE_BUMPER_BROKEN_OFF

```c
BOOL IS_VEHICLE_BUMPER_BROKEN_OFF(Vehicle vehicle, BOOL frontBumper)  // 0x468056A6BB6F3846
```

build 323

## IS_VEHICLE_DOOR_DAMAGED

```c
BOOL IS_VEHICLE_DOOR_DAMAGED(Vehicle veh, int doorID)  // 0xB8E181E559464527
```

build 323

> doorID starts at 0, not seeming to skip any numbers. Four door vehicles intuitively range from 0 to 3.

## IS_VEHICLE_DOOR_FULLY_OPEN

```c
BOOL IS_VEHICLE_DOOR_FULLY_OPEN(Vehicle vehicle, int doorId)  // 0x3E933CFF7B111C22
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## IS_VEHICLE_DRIVEABLE

```c
BOOL IS_VEHICLE_DRIVEABLE(Vehicle vehicle, BOOL isOnFireCheck)  // 0x4C241E39B23DF959
```

build 323

> p1 is always 0 in the scripts.
> 
> p1 = check if vehicle is on fire

## IS_VEHICLE_EXTRA_TURNED_ON

```c
BOOL IS_VEHICLE_EXTRA_TURNED_ON(Vehicle vehicle, int extraId)  // 0xD2E6822DBFD6C8BD
```

build 323

## IS_VEHICLE_HIGH_DETAIL

```c
BOOL IS_VEHICLE_HIGH_DETAIL(Vehicle vehicle)  // 0x1F25887F3C104278
```

build 323

## IS_VEHICLE_IN_BURNOUT

```c
BOOL IS_VEHICLE_IN_BURNOUT(Vehicle vehicle)  // 0x1297A88E081430EB
```

build 323

> Returns whether the specified vehicle is currently in a burnout.
> 
> 
> vb.net
> Public Function isVehicleInBurnout(vh As Vehicle) As Boolean
>         Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_IN_BURNOUT, vh)
>     End Function

## IS_VEHICLE_IN_GARAGE_AREA

```c
BOOL IS_VEHICLE_IN_GARAGE_AREA(const char* garageName, Vehicle vehicle)  // 0xCEE4490CD57BB3C2
```

build 323

> garageName example "Michael - Beverly Hills"
> 
> Full list of garages by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/garages.json

## IS_VEHICLE_IN_SUBMARINE_MODE

```c
BOOL IS_VEHICLE_IN_SUBMARINE_MODE(Vehicle vehicle)  // 0xA77DC70BD689A1E5
```

build 1290 · old names: `_GET_IS_SUBMARINE_VEHICLE_TRANSFORMED`

## IS_VEHICLE_MOD_GEN9_EXCLUSIVE

```c
BOOL IS_VEHICLE_MOD_GEN9_EXCLUSIVE(Vehicle vehicle, int modType, int modIndex)  // 0x00834EAC4A96E010
```

build 2699 · old names: `_IS_VEHICLE_MOD_HSW_EXCLUSIVE`

> Returns true for any mod part listed in GEN9_EXCLUSIVE_ASSETS_VEHICLES_FILE.

## IS_VEHICLE_MODEL

```c
BOOL IS_VEHICLE_MODEL(Vehicle vehicle, Hash model)  // 0x423E8DE37D934D89
```

build 323

## IS_VEHICLE_ON_ALL_WHEELS

```c
BOOL IS_VEHICLE_ON_ALL_WHEELS(Vehicle vehicle)  // 0xB104CD1BABF302E2
```

build 323

>  Public Function isVehicleOnAllWheels(vh As Vehicle) As Boolean
>         Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_ON_ALL_WHEELS, vh)
>     End Function
> 

## IS_VEHICLE_PARACHUTE_DEPLOYED

```c
BOOL IS_VEHICLE_PARACHUTE_DEPLOYED(Vehicle vehicle)  // 0x3DE51E9C80B116CF
```

build 1011 · old names: `_IS_VEHICLE_PARACHUTE_ACTIVE`

## IS_VEHICLE_PRODUCING_SLIP_STREAM

```c
BOOL IS_VEHICLE_PRODUCING_SLIP_STREAM(Vehicle vehicle)  // 0x48C633E94A8142A7
```

build 877 · old names: `_IS_VEHICLE_SLIPSTREAM_LEADER`

> Returns true if the vehicle is being slipstreamed by another vehicle

## IS_VEHICLE_SEARCHLIGHT_ON

```c
BOOL IS_VEHICLE_SEARCHLIGHT_ON(Vehicle vehicle)  // 0xC0F97FCE55094987
```

build 323

> Possibly: Returns whether the searchlight (found on police vehicles) is toggled on.
> 
> @Author Nac

## IS_VEHICLE_SEAT_FREE

```c
BOOL IS_VEHICLE_SEAT_FREE(Vehicle vehicle, int seatIndex, BOOL isTaskRunning)  // 0x22AC59A870E6A669
```

build 323

> Check if a vehicle seat is free.
> 
> seatIndex  = -1 being the driver seat.
> Use GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS(vehicle) - 1 for last seat index.
> isTaskRunning = on true the function returns already false while a task on the target seat is running (TASK_ENTER_VEHICLE/TASK_SHUFFLE_TO_NEXT_VEHICLE_SEAT) - on false only when a ped is finally sitting in the seat.

## IS_VEHICLE_SIREN_AUDIO_ON

```c
BOOL IS_VEHICLE_SIREN_AUDIO_ON(Vehicle vehicle)  // 0xB5CC40FBCB586380
```

build 323 · old names: `_IS_VEHICLE_SIREN_SOUND_ON`

## IS_VEHICLE_SIREN_ON

```c
BOOL IS_VEHICLE_SIREN_ON(Vehicle vehicle)  // 0x4C9BF537BE2634B2
```

build 323

## IS_VEHICLE_SPRAYABLE

```c
BOOL IS_VEHICLE_SPRAYABLE(Vehicle vehicle)  // 0x8D474C8FAEFF6CDE
```

build 323 · old names: `_IS_VEHICLE_SHOP_RESPRAY_ALLOWED`

> Returns false if the vehicle has the FLAG_NO_RESPRAY flag set.

## IS_VEHICLE_STOLEN

```c
BOOL IS_VEHICLE_STOLEN(Vehicle vehicle)  // 0x4AF9BD80EEBEB453
```

build 323

> Only returns true if the vehicle was marked as stolen with SET_VEHICLE_IS_STOLEN.

## IS_VEHICLE_STOPPED

```c
BOOL IS_VEHICLE_STOPPED(Vehicle vehicle)  // 0x5721B434AD84D57A
```

build 323

> Returns true if the vehicle's current speed is less than, or equal to 0.0025f.
> 
> For some vehicles it returns true if the current speed is <= 0.00039999999.

## IS_VEHICLE_STOPPED_AT_TRAFFIC_LIGHTS

```c
BOOL IS_VEHICLE_STOPPED_AT_TRAFFIC_LIGHTS(Vehicle vehicle)  // 0x2959F696AE390A99
```

build 323

## IS_VEHICLE_STUCK_ON_ROOF

```c
BOOL IS_VEHICLE_STUCK_ON_ROOF(Vehicle vehicle)  // 0xB497F06B288DCFDF
```

build 323

## IS_VEHICLE_STUCK_TIMER_UP

```c
BOOL IS_VEHICLE_STUCK_TIMER_UP(Vehicle vehicle, int p1, int ms)  // 0x679BE1DAF71DA874
```

build 323

> p1 can be anywhere from 0 to 3 in the scripts.
> p2 being how long in milliseconds the vehicle has been stuck

## IS_VEHICLE_TYRE_BURST

```c
BOOL IS_VEHICLE_TYRE_BURST(Vehicle vehicle, int wheelID, BOOL completely)  // 0xBA291848A0815CA9
```

build 323

> wheelID used for 4 wheelers seem to be (0, 1, 4, 5)
> completely - is to check if tire completely gone from rim.
> 
> '0 = wheel_lf / bike, plane or jet front
> '1 = wheel_rf
> '2 = wheel_lm / in 6 wheels trailer, plane or jet is first one on left
> '3 = wheel_rm / in 6 wheels trailer, plane or jet is first one on right
> '4 = wheel_lr / bike rear / in 6 wheels trailer, plane or jet is last one on left
> '5 = wheel_rr / in 6 wheels trailer, plane or jet is last one on right
> '45 = 6 wheels trailer mid wheel left
> '47 = 6 wheels trailer mid wheel right

## IS_VEHICLE_VISIBLE

```c
BOOL IS_VEHICLE_VISIBLE(Vehicle vehicle)  // 0xAA0A52D24FB98293
```

build 323

> must be called after TRACK_VEHICLE_VISIBILITY 
> 
> it's not instant so probabilly must pass an 'update' to see correct result.

## IS_VEHICLE_WEAPON_DISABLED

```c
BOOL IS_VEHICLE_WEAPON_DISABLED(Hash weaponHash, Vehicle vehicle, Ped owner)  // 0x563B65A643ED072E
```

build 1011 · old names: `_IS_VEHICLE_WEAPON_DISABLED`

> Full list of weapons by DurtyFree (Search for VEHICLE_*): https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## IS_VEHICLE_WINDOW_INTACT

```c
BOOL IS_VEHICLE_WINDOW_INTACT(Vehicle vehicle, int windowIndex)  // 0x46E571A0E20D01F1
```

build 323

> This will return false if the window is broken, or rolled down.
> Window indexes:
> 0 = Front Right Window
> 1 = Front Left Window
> 2 = Back Right Window
> 3 = Back Left Window
> 
> 
> Those numbers go on for vehicles that have more than 4 doors with windows.

## LOCK_DOORS_WHEN_NO_LONGER_NEEDED

```c
void LOCK_DOORS_WHEN_NO_LONGER_NEEDED(Vehicle vehicle)  // 0xCFD778E7904C255E
```

build 323

## LOWER_CONVERTIBLE_ROOF

```c
void LOWER_CONVERTIBLE_ROOF(Vehicle vehicle, BOOL instantlyLower)  // 0xDED51F703D0FA83D
```

build 323

## LOWER_FORKLIFT_FORKS

```c
void LOWER_FORKLIFT_FORKS(Vehicle forklift)  // 0x923A293361DF44E5
```

build 2802

## MODIFY_VEHICLE_TOP_SPEED

```c
void MODIFY_VEHICLE_TOP_SPEED(Vehicle vehicle, float value)  // 0x93A3996368C94158
```

build 323 · old names: `_SET_VEHICLE_ENGINE_POWER_MULTIPLIER`

## NETWORK_CAP_EMPTY_CROWDING_VEHICLES_REMOVAL

```c
void NETWORK_CAP_EMPTY_CROWDING_VEHICLES_REMOVAL(int p0)  // 0xA4A9A4C40E615885
```

build 1604

> Default:1000||This sets a value which is used when NETWORK_ENABLE_EMPTY_CROWDING_VEHICLES_REMOVAL(true) is called each frame.

## NETWORK_ENABLE_EMPTY_CROWDING_VEHICLES_REMOVAL

```c
void NETWORK_ENABLE_EMPTY_CROWDING_VEHICLES_REMOVAL(BOOL toggle)  // 0x51DB102F4A3BA5E0
```

build 323

## NETWORK_USE_HIGH_PRECISION_TRAIN_BLENDING

```c
void NETWORK_USE_HIGH_PRECISION_TRAIN_BLENDING(Vehicle vehicle, BOOL toggle)  // 0xEC0C1D4922AF9754
```

build 2372 · old names: `_NETWORK_USE_HIGH_PRECISION_VEHICLE_BLENDING`

> Implemented only for trains.

## OPEN_BOMB_BAY_DOORS

```c
void OPEN_BOMB_BAY_DOORS(Vehicle vehicle)  // 0x87E7F24270732CB1
```

build 323 · old names: `_OPEN_VEHICLE_BOMB_BAY`

## OVERRIDE_PLANE_DAMAGE_THREHSOLD

```c
void OVERRIDE_PLANE_DAMAGE_THREHSOLD(Vehicle vehicle, float health)  // 0x5EE5632F47AE9695
```

build 463 · old names: `_OVERRIDE_OVERHEAT_HEALTH`

> Used for helis.

## PAUSE_PLAYBACK_RECORDED_VEHICLE

```c
void PAUSE_PLAYBACK_RECORDED_VEHICLE(Vehicle vehicle)  // 0x632A689BF42301B1
```

build 323

## POP_OFF_VEHICLE_ROOF_WITH_IMPULSE

```c
void POP_OFF_VEHICLE_ROOF_WITH_IMPULSE(Vehicle vehicle, float x, float y, float z)  // 0xE38CB9D7D39FDBCC
```

build 323 · old names: `_EJECT_JB700_ROOF`

> Pops off the "roof" bone in the direction of the specified offset from the vehicle.

## POP_OUT_VEHICLE_WINDSCREEN

```c
void POP_OUT_VEHICLE_WINDSCREEN(Vehicle vehicle)  // 0x6D645D59FB5F5AD3
```

build 323 · old names: `_DETACH_VEHICLE_WINDSCREEN`

> Detaches the vehicle's windscreen.
> For further information, see : https://gtaforums.com/topic/859570-glass/#entry1068894566

## PRELOAD_VEHICLE_MOD

```c
void PRELOAD_VEHICLE_MOD(Vehicle vehicle, int modType, int modIndex)  // 0x758F49C24925568A
```

build 323

## RAISE_CONVERTIBLE_ROOF

```c
void RAISE_CONVERTIBLE_ROOF(Vehicle vehicle, BOOL instantlyRaise)  // 0x8F5FB35D7E88FC70
```

build 323

## RELEASE_PRELOAD_MODS

```c
void RELEASE_PRELOAD_MODS(Vehicle vehicle)  // 0x445D79F995508307
```

build 323

## REMOVE_PICK_UP_ROPE_FOR_CARGOBOB

```c
void REMOVE_PICK_UP_ROPE_FOR_CARGOBOB(Vehicle cargobob)  // 0x9768CF648F54C804
```

build 323 · old names: `_RETRACT_CARGOBOB_HOOK`

> Retracts the hook on the cargobob.
> 
> Note: after you retract it the natives for dropping the hook no longer work

## REMOVE_ROAD_NODE_SPEED_ZONE

```c
BOOL REMOVE_ROAD_NODE_SPEED_ZONE(int speedzone)  // 0x1033371FC8E842A7
```

build 323 · old names: `_REMOVE_SPEED_ZONE`

## REMOVE_VEHICLE_ASSET

```c
void REMOVE_VEHICLE_ASSET(int vehicleAsset)  // 0xACE699C71AB9DEB5
```

build 323

## REMOVE_VEHICLE_COMBAT_AVOIDANCE_AREA

```c
void REMOVE_VEHICLE_COMBAT_AVOIDANCE_AREA(int p0)  // 0xE30524E1871F481D
```

build 323

## REMOVE_VEHICLE_HIGH_DETAIL_MODEL

```c
void REMOVE_VEHICLE_HIGH_DETAIL_MODEL(Vehicle vehicle)  // 0x00689CDE5F7C6787
```

build 323

## REMOVE_VEHICLE_MOD

```c
void REMOVE_VEHICLE_MOD(Vehicle vehicle, int modType)  // 0x92D619E420858204
```

build 323

## REMOVE_VEHICLE_RECORDING

```c
void REMOVE_VEHICLE_RECORDING(int recording, const char* script)  // 0xF1160ACCF98A3FC8
```

build 323

> See REQUEST_VEHICLE_RECORDING

## REMOVE_VEHICLE_STUCK_CHECK

```c
void REMOVE_VEHICLE_STUCK_CHECK(Vehicle vehicle)  // 0x8386BFB614D06749
```

build 323

## REMOVE_VEHICLE_UPSIDEDOWN_CHECK

```c
void REMOVE_VEHICLE_UPSIDEDOWN_CHECK(Vehicle vehicle)  // 0xC53EB42A499A7E90
```

build 323

## REMOVE_VEHICLE_WINDOW

```c
void REMOVE_VEHICLE_WINDOW(Vehicle vehicle, int windowIndex)  // 0xA711568EEDB43069
```

build 323

> windowIndex:
> 0 = Front Right Window
> 1 = Front Left Window
> 2 = Back Right Window
> 3 = Back Left Window
> 4 = Unknown
> 5 = Unknown
> 6 = Windscreen
> 7 = Rear Windscreen

## REMOVE_VEHICLES_FROM_GENERATORS_IN_AREA

```c
void REMOVE_VEHICLES_FROM_GENERATORS_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, Any p6)  // 0x46A1E1A299EC4BBA
```

build 323

## REQUEST_VEHICLE_ASSET

```c
void REQUEST_VEHICLE_ASSET(Hash vehicleHash, int vehicleAsset)  // 0x81A15811460FAB3A
```

build 323

> REQUEST_VEHICLE_ASSET(GET_HASH_KEY(cargobob3), 3);
> 
> vehicle found that have asset's:
> cargobob3
> submersible
> blazer

## REQUEST_VEHICLE_DIAL

```c
void REQUEST_VEHICLE_DIAL(Vehicle vehicle)  // 0xDBA3C090E3D74690
```

build 323 · old names: `_REQUEST_VEHICLE_DASHBOARD_SCALEFORM_MOVIE`

## REQUEST_VEHICLE_HIGH_DETAIL_MODEL

```c
void REQUEST_VEHICLE_HIGH_DETAIL_MODEL(Vehicle vehicle)  // 0xA6E9FDCB2C76785E
```

build 323

## REQUEST_VEHICLE_RECORDING

```c
void REQUEST_VEHICLE_RECORDING(int recording, const char* script)  // 0xAF514CABE74CBF15
```

build 323

> Request the vehicle recording defined by the lowercase format string "%s%03d.yvr". For example, REQUEST_VEHICLE_RECORDING(1, "FBIs1UBER") corresponds to fbis1uber001.yvr.
> For all vehicle recording/playback natives, "script" is a common prefix that usually corresponds to the script/mission the recording is used in, "recording" is its int suffix, and "id" (e.g., in native GET_TOTAL_DURATION_OF_VEHICLE_RECORDING_ID) corresponds to a unique identifier within the recording streaming module.
> Note that only 24 recordings (hardcoded in multiple places) can ever active at a given time before clobbering begins.

## RESET_FORMATION_LEADER

```c
void RESET_FORMATION_LEADER()  // 0xE2F53F172B45EDE1
```

build 877

> Resets the effect of SET_FORMATION_LEADER

## RESET_VEHICLE_STUCK_TIMER

```c
void RESET_VEHICLE_STUCK_TIMER(Vehicle vehicle, int nullAttributes)  // 0xD7591B0065AFAA7A
```

build 323

> The inner function has a switch on the second parameter. It's the stuck timer index.
> 
> Here's some pseudo code I wrote for the inner function:
> void __fastcall NATIVE_RESET_VEHICLE_STUCK_TIMER_INNER(CUnknown* unknownClassInVehicle, int timerIndex)
> {
>  switch (timerIndex)
>    {
>  case 0:
>        unknownClassInVehicle->FirstStuckTimer = (WORD)0u;
>  case 1:
>        unknownClassInVehicle->SecondStuckTimer = (WORD)0u;
>     case 2:
>        unknownClassInVehicle->ThirdStuckTimer = (WORD)0u;
>  case 3:
>        unknownClassInVehicle->FourthStuckTimer = (WORD)0u;
>     case 4:
>        unknownClassInVehicle->FirstStuckTimer = (WORD)0u;
>      unknownClassInVehicle->SecondStuckTimer = (WORD)0u;
>         unknownClassInVehicle->ThirdStuckTimer = (WORD)0u;
>      unknownClassInVehicle->FourthStuckTimer = (WORD)0u;
>         break;
>     };
> }

## RESET_VEHICLE_WHEELS

```c
void RESET_VEHICLE_WHEELS(Vehicle vehicle, BOOL toggle)  // 0x21D2E5662C1F6FED
```

build 323

## ROLL_DOWN_WINDOW

```c
void ROLL_DOWN_WINDOW(Vehicle vehicle, int windowIndex)  // 0x7AD9E6CE657D69E3
```

build 323

> windowIndex:
> 0 = Front Left Window
> 1 = Front Right Window
> 2 = Rear Left Window
> 3 = Rear Right Window
> 4 = Front Windscreen
> 5 = Rear Windscreen
> 6 = Mid Left
> 7 = Mid Right
> 8 = Invalid

## ROLL_DOWN_WINDOWS

```c
void ROLL_DOWN_WINDOWS(Vehicle vehicle)  // 0x85796B0549DDE156
```

build 323

> Roll down all the windows of the vehicle passed through the first parameter.

## ROLL_UP_WINDOW

```c
void ROLL_UP_WINDOW(Vehicle vehicle, int windowIndex)  // 0x602E548F46E24D59
```

build 323

> windowIndex:
> 0 = Front Left Window
> 1 = Front Right Window
> 2 = Rear Left Window
> 3 = Rear Right Window
> 4 = Front Windscreen
> 5 = Rear Windscreen
> 6 = Mid Left
> 7 = Mid Right
> 8 = Invalid

## SET_ADDITIONAL_ROTATION_FOR_RECORDED_VEHICLE_PLAYBACK

```c
void SET_ADDITIONAL_ROTATION_FOR_RECORDED_VEHICLE_PLAYBACK(Vehicle vehicle, float x, float y, float z, Any p4)  // 0x5845066D8A1EA7F7
```

build 323

## SET_AIRCRAFT_IGNORE_HIGHTMAP_OPTIMISATION

```c
void SET_AIRCRAFT_IGNORE_HIGHTMAP_OPTIMISATION(Vehicle vehicle, int p1)  // 0xF8B49F5BA7F850E7
```

build 2060

## SET_AIRCRAFT_PILOT_SKILL_NOISE_SCALAR

```c
void SET_AIRCRAFT_PILOT_SKILL_NOISE_SCALAR(Vehicle vehicle, float p1)  // 0xE5810AC70602F2F5
```

build 323

## SET_ALL_LOW_PRIORITY_VEHICLE_GENERATORS_ACTIVE

```c
void SET_ALL_LOW_PRIORITY_VEHICLE_GENERATORS_ACTIVE(BOOL active)  // 0x608207E7A8FB787C
```

build 323

## SET_ALL_VEHICLE_GENERATORS_ACTIVE

```c
void SET_ALL_VEHICLE_GENERATORS_ACTIVE()  // 0x34AD89078831A4BC
```

build 323

## SET_ALL_VEHICLE_GENERATORS_ACTIVE_IN_AREA

```c
void SET_ALL_VEHICLE_GENERATORS_ACTIVE_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, BOOL toggle, BOOL p7)  // 0xC12321827687FE4D
```

build 323

> When p6 is true, vehicle generators are active.
> p7 seems to always be true in story mode scripts, but it's sometimes false in online scripts.

## SET_ALLOW_RAMMING_SOOP_OR_RAMP

```c
void SET_ALLOW_RAMMING_SOOP_OR_RAMP(Any p0, Any p1)  // 0x80E3357FDEF45C21
```

build 944

## SET_ALLOW_VEHICLE_EXPLODES_ON_CONTACT

```c
void SET_ALLOW_VEHICLE_EXPLODES_ON_CONTACT(Vehicle vehicle, BOOL toggle)  // 0x3441CAD2F2231923
```

build 323

## SET_AMBIENT_VEHICLE_NEON_ENABLED

```c
void SET_AMBIENT_VEHICLE_NEON_ENABLED(BOOL p0)  // 0x35E0654F4BAD7971
```

build 323

## SET_AMBIENT_VEHICLE_RANGE_MULTIPLIER_THIS_FRAME

```c
void SET_AMBIENT_VEHICLE_RANGE_MULTIPLIER_THIS_FRAME(float value)  // 0x90B6DA738A9A25DA
```

build 323 · old names: `_SET_SOME_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME`

## SET_ARRIVE_DISTANCE_OVERRIDE_FOR_VEHICLE_PERSUIT_ATTACK

```c
void SET_ARRIVE_DISTANCE_OVERRIDE_FOR_VEHICLE_PERSUIT_ATTACK(Vehicle vehicle, float p1)  // 0x0205F5365292D2EB
```

build 1290

## SET_BIKE_EASY_TO_LAND

```c
void SET_BIKE_EASY_TO_LAND(Vehicle vehicle, BOOL toggle)  // 0x73561D4425A021A2
```

build 791

> When enabled, the player won't fall off the bike when landing from large heights.

## SET_BIKE_ON_STAND

```c
void SET_BIKE_ON_STAND(Vehicle vehicle, float x, float y)  // 0x9CFA4896C3A53CBB
```

build 323 · old names: `_SET_BIKE_LEAN_ANGLE`

> Only works on bikes, both X and Y work in the -1 - 1 range.
> 
> X forces the bike to turn left or right (-1, 1)
> Y forces the bike to lean to the left or to the right (-1, 1)

## SET_BOAT_ANCHOR

```c
void SET_BOAT_ANCHOR(Vehicle vehicle, BOOL toggle)  // 0x75DBEC174AEEAD10
```

build 323

## SET_BOAT_DISABLE_AVOIDANCE

```c
void SET_BOAT_DISABLE_AVOIDANCE(Vehicle vehicle, BOOL p1)  // 0x0A6A279F3AA4FD70
```

build 323

## SET_BOAT_IGNORE_LAND_PROBES

```c
void SET_BOAT_IGNORE_LAND_PROBES(Any p0, Any p1)  // 0xED5EDE9E676643C9
```

build 944

## SET_BOAT_LOW_LOD_ANCHOR_DISTANCE

```c
void SET_BOAT_LOW_LOD_ANCHOR_DISTANCE(Vehicle vehicle, float value)  // 0xE842A9398079BD82
```

build 323 · old names: `_SET_BOAT_ANCHOR_BUOYANCY_COEFFICIENT`, `_SET_BOAT_MOVEMENT_RESISTANCE`

## SET_BOAT_REMAINS_ANCHORED_WHILE_PLAYER_IS_DRIVER

```c
void SET_BOAT_REMAINS_ANCHORED_WHILE_PLAYER_IS_DRIVER(Vehicle vehicle, BOOL toggle)  // 0xE3EBAAE484798530
```

build 323 · old names: `_SET_BOAT_FROZEN_WHEN_ANCHORED`

## SET_BOAT_SINKS_WHEN_WRECKED

```c
void SET_BOAT_SINKS_WHEN_WRECKED(Vehicle vehicle, BOOL toggle)  // 0x8F719973E1445BA2
```

build 323 · old names: `_SET_BOAT_EXPLODES_ON_WRECKED_ACTION`

## SET_BOAT_WRECKED

```c
void SET_BOAT_WRECKED(Vehicle vehicle)  // 0xBD32E46AA95C1DD2
```

build 757 · old names: `_SET_BOAT_SINKING`, `_SET_BOAT_IS_SINKING`

## SET_CAN_ADJUST_GROUND_CLEARANCE

```c
void SET_CAN_ADJUST_GROUND_CLEARANCE(Vehicle vehicle, BOOL p1)  // 0xA7DCDF4DED40A8F4
```

build 323

## SET_CAN_RESPRAY_VEHICLE

```c
void SET_CAN_RESPRAY_VEHICLE(Vehicle vehicle, BOOL state)  // 0x52BBA29D5EC69356
```

build 323

> Hardcoded to not work in multiplayer.

## SET_CAN_USE_HYDRAULICS

```c
void SET_CAN_USE_HYDRAULICS(Vehicle vehicle, BOOL toggle)  // 0x1201E8A3290A3B98
```

build 505 · old names: `_SET_CAMBERED_WHEELS_DISABLED`

## SET_CAR_BOOT_OPEN

```c
void SET_CAR_BOOT_OPEN(Vehicle vehicle)  // 0xFC40CBF7B90CA77C
```

build 877

## SET_CAR_HIGH_SPEED_BUMP_SEVERITY_MULTIPLIER

```c
void SET_CAR_HIGH_SPEED_BUMP_SEVERITY_MULTIPLIER(float multiplier)  // 0x84FD40F56075E816
```

build 323 · old names: `_SET_CAR_HIGH_SPEED_BUMP_SEVERITY_MULTIPLIER`

## SET_CARGOBOB_EXCLUDE_FROM_PICKUP_ENTITY

```c
void SET_CARGOBOB_EXCLUDE_FROM_PICKUP_ENTITY(Any p0, Any p1)  // 0x1F34B0626C594380
```

build 757

## SET_CARGOBOB_EXTA_PICKUP_RANGE

```c
void SET_CARGOBOB_EXTA_PICKUP_RANGE(Any p0, Any p1)  // 0x72BECCF4B829522E
```

build 1103

## SET_CARGOBOB_FORCE_DONT_DETACH_VEHICLE

```c
void SET_CARGOBOB_FORCE_DONT_DETACH_VEHICLE(Vehicle cargobob, BOOL toggle)  // 0x571FEB383F629926
```

build 323 · old names: `_SET_CARGOBOB_HOOK_CAN_DETACH`

> Stops cargobob from being able to detach the attached vehicle.

## SET_CARGOBOB_PICKUP_MAGNET_ACTIVE

```c
void SET_CARGOBOB_PICKUP_MAGNET_ACTIVE(Vehicle cargobob, BOOL isActive)  // 0x9A665550F8DA349B
```

build 323 · old names: `_CARGOBOB_MAGNET_GRAB_VEHICLE`, `_SET_CARGOBOB_PICKUP_MAGNET_ACTIVE`

> Won't attract or magnetize to any helicopters or planes of course, but that's common sense.

## SET_CARGOBOB_PICKUP_MAGNET_ENSURE_PICKUP_ENTITY_UPRIGHT

```c
void SET_CARGOBOB_PICKUP_MAGNET_ENSURE_PICKUP_ENTITY_UPRIGHT(Vehicle vehicle, BOOL p1)  // 0x56EB5E94318D3FB6
```

build 323

## SET_CARGOBOB_PICKUP_MAGNET_FALLOFF

```c
void SET_CARGOBOB_PICKUP_MAGNET_FALLOFF(Vehicle cargobob, float p1)  // 0xA17BAD153B51547E
```

build 323 · old names: `SET_CARGOBOB_PICKUP_MAGNET_EFFECT_RADIUS`

## SET_CARGOBOB_PICKUP_MAGNET_PULL_ROPE_LENGTH

```c
void SET_CARGOBOB_PICKUP_MAGNET_PULL_ROPE_LENGTH(Vehicle vehicle, float p1)  // 0x685D5561680D088B
```

build 323 · old names: `SET_CARGOBOB_PICKUP_MAGNET_FALLOFF`

## SET_CARGOBOB_PICKUP_MAGNET_PULL_STRENGTH

```c
void SET_CARGOBOB_PICKUP_MAGNET_PULL_STRENGTH(Vehicle cargobob, float p1)  // 0xED8286F71A819BAA
```

build 323

## SET_CARGOBOB_PICKUP_MAGNET_REDUCED_FALLOFF

```c
void SET_CARGOBOB_PICKUP_MAGNET_REDUCED_FALLOFF(Vehicle cargobob, float p1)  // 0x6D8EAC07506291FB
```

build 323 · old names: `SET_CARGOBOB_PICKUP_MAGNET_PULL_ROPE_LENGTH`

## SET_CARGOBOB_PICKUP_MAGNET_REDUCED_STRENGTH

```c
void SET_CARGOBOB_PICKUP_MAGNET_REDUCED_STRENGTH(Vehicle cargobob, float p1)  // 0x66979ACF5102FD2F
```

build 323 · old names: `SET_CARGOBOB_PICKUP_MAGNET_REDUCED_FALLOFF`

## SET_CARGOBOB_PICKUP_MAGNET_SET_AMBIENT_MODE

```c
void SET_CARGOBOB_PICKUP_MAGNET_SET_AMBIENT_MODE(Vehicle vehicle, BOOL p1, BOOL p2)  // 0x9BDDC73CC6A115D4
```

build 323

## SET_CARGOBOB_PICKUP_MAGNET_SET_TARGETED_MODE

```c
void SET_CARGOBOB_PICKUP_MAGNET_SET_TARGETED_MODE(Vehicle vehicle, Vehicle cargobob)  // 0xE301BD63E9E13CF0
```

build 323 · old names: `SET_CARGOBOB_PICKUP_MAGNET_REDUCED_STRENGTH`

## SET_CARGOBOB_PICKUP_MAGNET_STRENGTH

```c
void SET_CARGOBOB_PICKUP_MAGNET_STRENGTH(Vehicle cargobob, float strength)  // 0xBCBFCD9D1DAC19E2
```

build 323 · old names: `_SET_CARGOBOB_PICKUP_MAGNET_STRENGTH`

## SET_CARGOBOB_PICKUP_ROPE_DAMPING_MULTIPLIER

```c
void SET_CARGOBOB_PICKUP_ROPE_DAMPING_MULTIPLIER(Any p0, Any p1)  // 0xCF1182F682F65307
```

build 323

## SET_CARGOBOB_PICKUP_ROPE_TYPE

```c
void SET_CARGOBOB_PICKUP_ROPE_TYPE(Any p0, Any p1)  // 0x0D5F65A8F4EBDAB5
```

build 1103

## SET_CARJACK_MISSION_REMOVAL_PARAMETERS

```c
void SET_CARJACK_MISSION_REMOVAL_PARAMETERS(Any p0, Any p1)  // 0xB9562064627FF9DB
```

build 573

## SET_CHECK_FOR_ENOUGH_ROOM_FOR_PED

```c
void SET_CHECK_FOR_ENOUGH_ROOM_FOR_PED(Vehicle vehicle, BOOL p1)  // 0xEF9D388F8D377F44
```

build 2699

> Only used in R* Script fm_content_cargo

## SET_CLEAR_FREEZE_WAITING_ON_COLLISION_ONCE_PLAYER_ENTERS

```c
void SET_CLEAR_FREEZE_WAITING_ON_COLLISION_ONCE_PLAYER_ENTERS(Vehicle vehicle, BOOL toggle)  // 0xB2E0C0D6922D31F2
```

build 944

## SET_CONVERTIBLE_ROOF

```c
void SET_CONVERTIBLE_ROOF(Vehicle vehicle, BOOL p1)  // 0xF39C4F538B5124C2
```

build 323

## SET_CONVERTIBLE_ROOF_LATCH_STATE

```c
void SET_CONVERTIBLE_ROOF_LATCH_STATE(Vehicle vehicle, BOOL state)  // 0x1A78AD3D8240536F
```

build 323

## SET_DEPLOY_FOLDING_WINGS

```c
void SET_DEPLOY_FOLDING_WINGS(Vehicle vehicle, BOOL deploy, BOOL p2)  // 0xB251E0B33E58B424
```

build 1290 · old names: `_SET_DEPLOY_HELI_STUB_WINGS`

> Only used with the "akula" and "annihilator2" in the decompiled native scripts.

## SET_DIP_STRAIGHT_DOWN_WHEN_CRASHING_PLANE

```c
void SET_DIP_STRAIGHT_DOWN_WHEN_CRASHING_PLANE(Vehicle vehicle, BOOL toggle)  // 0xAA653AE61924B0A0
```

build 1290

## SET_DISABLE_AUTOMATIC_CRASH_TASK

```c
void SET_DISABLE_AUTOMATIC_CRASH_TASK(Vehicle vehicle, BOOL toggle)  // 0x97841634EF7DF1D6
```

build 1180

> Sets a flag on heli and another vehicle type.

## SET_DISABLE_BMX_EXTRA_TRICK_FORCES

```c
void SET_DISABLE_BMX_EXTRA_TRICK_FORCES(Any p0)  // 0x26D99D5A82FD18E8
```

build 463

## SET_DISABLE_DAMAGE_WITH_PICKED_UP_ENTITY

```c
BOOL SET_DISABLE_DAMAGE_WITH_PICKED_UP_ENTITY(Any p0, Any p1)  // 0xD4196117AF7BB974
```

build 757

## SET_DISABLE_EXPLODE_FROM_BODY_DAMAGE_ON_COLLISION

```c
void SET_DISABLE_EXPLODE_FROM_BODY_DAMAGE_ON_COLLISION(Vehicle vehicle, BOOL disable)  // 0x26E13D440E7F6064
```

build 1290

> Prevents the vehicle from exploding when taking body damage if it was caused by a collision. Only works for planes.

## SET_DISABLE_HELI_EXPLODE_FROM_BODY_DAMAGE

```c
void SET_DISABLE_HELI_EXPLODE_FROM_BODY_DAMAGE(Vehicle vehicle, BOOL disable)  // 0xEDBC8405B3895CC9
```

build 1103

> Prevents the vehicle from exploding when taking body damage. Only works for helis and planes.

## SET_DISABLE_HOVER_MODE_FLIGHT

```c
void SET_DISABLE_HOVER_MODE_FLIGHT(Vehicle vehicle, BOOL toggle)  // 0x2D55FE374D5FDB91
```

build 1290 · old names: `_SET_VEHICLE_HOVER_TRANSFORM_ACTIVE`

> Disables "wings" for some flying vehicles. Works only for oppressor _2_ and deluxo.
> For deluxo it just immediately removes vehicle's "wings" and you will be not able to fly up.
> For oppressor 2 it will remove wings right after you land. And you will not able to fly up anymore too.
> But for opressor 2 you still can fly if you somehow get back in the air.

## SET_DISABLE_MAP_COLLISION

```c
void SET_DISABLE_MAP_COLLISION(Vehicle vehicle)  // 0x75627043C6AA90AD
```

build 1180 · old names: `_DISABLE_VEHICLE_WORLD_COLLISION`

> Disables collision for this vehicle (maybe it also supports other entities, not sure).
> Only world/building/fixed world objects will have their collisions disabled, props, peds, or any other entity still collides with the vehicle.

## SET_DISABLE_PED_STAND_ON_TOP

```c
void SET_DISABLE_PED_STAND_ON_TOP(Vehicle vehicle, BOOL toggle)  // 0x8235F1BEAD557629
```

build 1180

## SET_DISABLE_PRETEND_OCCUPANTS

```c
void SET_DISABLE_PRETEND_OCCUPANTS(Vehicle vehicle, BOOL toggle)  // 0x25367DE49D64CF16
```

build 323

## SET_DISABLE_RANDOM_TRAINS_THIS_FRAME

```c
void SET_DISABLE_RANDOM_TRAINS_THIS_FRAME(BOOL toggle)  // 0xD4B8E3D1917BC86B
```

build 323 · old names: `_SET_SOMETHING_MULTIPLIER_THIS_FRAME`

## SET_DISABLE_RETRACTING_WEAPON_BLADES

```c
void SET_DISABLE_RETRACTING_WEAPON_BLADES(BOOL toggle)  // 0x8F0D5BA1C2CC91D7
```

build 1604

## SET_DISABLE_SUPERDUMMY

```c
void SET_DISABLE_SUPERDUMMY(Vehicle vehicle, BOOL p1)  // 0xB088E9A47AE6EDD5
```

build 323 · old names: `_SET_DISABLE_SUPERDUMMY_MODE`

## SET_DISABLE_TURRET_MOVEMENT

```c
void SET_DISABLE_TURRET_MOVEMENT(Vehicle vehicle, int turretId)  // 0xE615BB7A7752C76A
```

build 1365 · old names: `_SET_DISABLE_TURRET_MOVEMENT`, `_SET_DISABLE_TURRET_MOVEMENT_THIS_FRAME`

> Disables turret movement when called in a loop. You can still fire and aim. You cannot shoot backwards though.

## SET_DISABLE_VEHICLE_ENGINE_FIRES

```c
void SET_DISABLE_VEHICLE_ENGINE_FIRES(Vehicle vehicle, BOOL toggle)  // 0x91A0BD635321F145
```

build 323

## SET_DISABLE_VEHICLE_EXPLOSIONS_DAMAGE

```c
void SET_DISABLE_VEHICLE_EXPLOSIONS_DAMAGE(BOOL toggle)  // 0x143921E45EC44D62
```

build 1604 · old names: `_SET_DISABLE_VEHICLE_UNK`

## SET_DISABLE_VEHICLE_PETROL_TANK_DAMAGE

```c
void SET_DISABLE_VEHICLE_PETROL_TANK_DAMAGE(Vehicle vehicle, BOOL toggle)  // 0x37C8252A7C92D017
```

build 323

## SET_DISABLE_VEHICLE_PETROL_TANK_FIRES

```c
void SET_DISABLE_VEHICLE_PETROL_TANK_FIRES(Vehicle vehicle, BOOL toggle)  // 0x465BF26AB9684352
```

build 323

## SET_DISABLE_VERTICAL_FLIGHT_MODE_TRANSITION

```c
void SET_DISABLE_VERTICAL_FLIGHT_MODE_TRANSITION(Vehicle vehicle, BOOL toggle)  // 0xCE2B43770B655F8F
```

build 1290 · old names: `_SET_PLANE_VTOL_ANIMATION_DISABLED`, `_SET_DISABLE_VEHICLE_FLIGHT_NOZZLE_POSITION`

> True stops vtols from switching modes. Doesn't stop the sound though.

## SET_DISABLE_WANTED_CONES_RESPONSE

```c
void SET_DISABLE_WANTED_CONES_RESPONSE(Vehicle vehicle, BOOL toggle)  // 0x4AD280EB48B2D8E6
```

build 1868

## SET_DISABLE_WEAPON_BLADE_FORCES

```c
void SET_DISABLE_WEAPON_BLADE_FORCES(BOOL toggle)  // 0x211E95CE9903940C
```

build 1604 · old names: `_SET_DISABLE_VEHICLE_UNK_2`

> Sets some global vehicle related bool

## SET_DISTANT_CARS_ENABLED

```c
void SET_DISTANT_CARS_ENABLED(BOOL toggle)  // 0xF796359A959DF65D
```

build 323 · old names: `_DISPLAY_DISTANT_VEHICLES`

> Toggles to render distant vehicles. They may not be vehicles but images to look like vehicles.

## SET_DONT_ALLOW_PLAYER_TO_ENTER_VEHICLE_IF_LOCKED_FOR_PLAYER

```c
void SET_DONT_ALLOW_PLAYER_TO_ENTER_VEHICLE_IF_LOCKED_FOR_PLAYER(Vehicle vehicle, BOOL p1)  // 0xDBC631F109350B8C
```

build 323

## SET_DONT_PROCESS_VEHICLE_GLASS

```c
void SET_DONT_PROCESS_VEHICLE_GLASS(Vehicle vehicle, BOOL toggle)  // 0x1087BC8EC540DAEB
```

build 1103 · old names: `_SET_DISABLE_VEHICLE_WINDOW_COLLISIONS`

> R* used it to "remove" vehicle windows when "nightshark" had some mod, which adding some kind of armored windows. When enabled, you can't break vehicles glass. All your bullets wiil shoot through glass. You also will not able to break the glass with any other way (hitting and etc)

## SET_DOOR_ALLOWED_TO_BE_BROKEN_OFF

```c
void SET_DOOR_ALLOWED_TO_BE_BROKEN_OFF(Vehicle vehicle, int doorId, BOOL isBreakable)  // 0x2FA133A4A9D37ED8
```

build 323 · old names: `_SET_VEHICLE_DOOR_BREAKABLE`, `_SET_VEHICLE_DOOR_CAN_BREAK`

> doorId: see SET_VEHICLE_DOOR_SHUT

## SET_DRIFT_TYRES

```c
void SET_DRIFT_TYRES(Vehicle vehicle, BOOL toggle)  // 0x5AC79C98C5C17F05
```

build 2372 · old names: `_SET_DRIFT_TYRES_ENABLED`

## SET_ENABLE_VEHICLE_SLIPSTREAMING

```c
void SET_ENABLE_VEHICLE_SLIPSTREAMING(BOOL toggle)  // 0xE6C0C80B8C867537
```

build 323

> Enable/Disables global slipstream physics

## SET_FAR_DRAW_VEHICLES

```c
void SET_FAR_DRAW_VEHICLES(BOOL toggle)  // 0x26324F33423F3CC3
```

build 323

## SET_FLEEING_VEHICLES_USE_SWITCHED_OFF_NODES

```c
void SET_FLEEING_VEHICLES_USE_SWITCHED_OFF_NODES(Any p0)  // 0xA247F9EF01D8082E
```

build 1103

## SET_FORCE_FIX_LINK_MATRICES

```c
void SET_FORCE_FIX_LINK_MATRICES(Vehicle vehicle)  // 0x887FA38787DE8C72
```

build 1365

## SET_FORCE_HD_VEHICLE

```c
void SET_FORCE_HD_VEHICLE(Vehicle vehicle, BOOL toggle)  // 0x97CE68CB032583F0
```

build 323

## SET_FORCE_LOW_LOD_ANCHOR_MODE

```c
void SET_FORCE_LOW_LOD_ANCHOR_MODE(Vehicle vehicle, BOOL p1)  // 0xB28B1FE5BFADD7F5
```

build 323

> No observed effect.

## SET_FORCE_VEHICLE_ENGINE_DAMAGE_BY_BULLET

```c
void SET_FORCE_VEHICLE_ENGINE_DAMAGE_BY_BULLET(Any p0, BOOL p1)  // 0x4D9D109F63FEE1D4
```

build 323

## SET_FORKLIFT_FORK_HEIGHT

```c
void SET_FORKLIFT_FORK_HEIGHT(Vehicle vehicle, float height)  // 0x37EBBF3117BD6A25
```

build 323

> 0.0 = Lowest 1.0 = Highest. This is best to be used if you wanna pick-up a car since un-realistically on GTA V forklifts can't pick up much of anything due to vehicle mass. If you put this under a car then set it above 0.0 to a 'lifted-value' it will raise the car with no issue lol

## SET_FORMATION_LEADER

```c
void SET_FORMATION_LEADER(Vehicle vehicle, float x, float y, float z, float p4)  // 0x428AD3E26C8D9EB0
```

build 877

## SET_GARBAGE_TRUCKS

```c
void SET_GARBAGE_TRUCKS(BOOL toggle)  // 0x2AFD795EEAC8D30D
```

build 323

## SET_GLIDER_ACTIVE

```c
void SET_GLIDER_ACTIVE(Vehicle vehicle, BOOL state)  // 0x544996C0081ABDEB
```

build 1103 · old names: `_SET_OPPRESSOR_TRANSFORM_STATE`

> Set state to true to extend the wings, false to retract them.

## SET_GLOBAL_POSITION_OFFSET_FOR_RECORDED_VEHICLE_PLAYBACK

```c
void SET_GLOBAL_POSITION_OFFSET_FOR_RECORDED_VEHICLE_PLAYBACK(Vehicle vehicle, float x, float y, float z)  // 0xFAF2A78061FD9EF4
```

build 323

## SET_GOON_BOSS_VEHICLE

```c
void SET_GOON_BOSS_VEHICLE(Vehicle vehicle, BOOL toggle)  // 0xAB31EF4DE6800CE9
```

build 573

> Used for GTAO CEO/Associate spawned vehicles.

## SET_GROUND_EFFECT_REDUCES_DRAG

```c
void SET_GROUND_EFFECT_REDUCES_DRAG(BOOL toggle)  // 0x430A7631A84C9BE7
```

build 1180

## SET_HELI_BLADES_FULL_SPEED

```c
void SET_HELI_BLADES_FULL_SPEED(Vehicle vehicle)  // 0xA178472EBB8AE60D
```

build 323

> Equivalent of SET_HELI_BLADES_SPEED(vehicleHandle, 1.0f);

## SET_HELI_BLADES_SPEED

```c
void SET_HELI_BLADES_SPEED(Vehicle vehicle, float speed)  // 0xFD280B4D7F3ABC4D
```

build 323

> Sets the speed of the helicopter blades in percentage of the full speed.
> 
> vehicleHandle: The helicopter.
> speed: The speed in percentage, 0.0f being 0% and 1.0f being 100%.

## SET_HELI_CAN_PICKUP_ENTITY_THAT_HAS_PICK_UP_DISABLED

```c
void SET_HELI_CAN_PICKUP_ENTITY_THAT_HAS_PICK_UP_DISABLED(Vehicle vehicle, BOOL toggle)  // 0x94A68DA412C4007D
```

build 1180 · old names: `_SET_CARGOBOB_HOOK_CAN_ATTACH`

> Stops the cargobob from being able to attach any vehicle

## SET_HELI_COMBAT_OFFSET

```c
void SET_HELI_COMBAT_OFFSET(Vehicle vehicle, float x, float y, float z)  // 0x0A3F820A9A9A9AC5
```

build 1180

## SET_HELI_CONTROL_LAGGING_RATE_SCALAR

```c
void SET_HELI_CONTROL_LAGGING_RATE_SCALAR(Vehicle helicopter, float multiplier)  // 0x6E0859B530A365CC
```

build 323 · old names: `_SET_HELICOPTER_ROLL_PITCH_YAW_MULT`

> value between 0.0 and 1.0

## SET_HELI_MAIN_ROTOR_HEALTH

```c
void SET_HELI_MAIN_ROTOR_HEALTH(Vehicle vehicle, float health)  // 0x4056EA1105F5ABD7
```

build 463 · old names: `_SET_HELI_MAIN_ROTOR_HEALTH`

## SET_HELI_RESIST_TO_EXPLOSION

```c
void SET_HELI_RESIST_TO_EXPLOSION(Vehicle vehicle, BOOL toggle)  // 0x8074CC1886802912
```

build 2545 · old names: `_SET_HELI_RESIST_TO_EXPLOSION`

## SET_HELI_TAIL_BOOM_CAN_BREAK_OFF

```c
BOOL SET_HELI_TAIL_BOOM_CAN_BREAK_OFF(Vehicle vehicle, BOOL toggle)  // 0x3EC8BF18AA453FE9
```

build 323 · old names: `WAS_COUNTER_ACTIVATED`, `SET_HELI_TAIL_EXPLODE_THROW_DASHBOARD`

## SET_HELI_TAIL_ROTOR_HEALTH

```c
void SET_HELI_TAIL_ROTOR_HEALTH(Vehicle vehicle, float health)  // 0xFE205F38AAA58E5B
```

build 463 · old names: `_SET_HELI_TAIL_ROTOR_HEALTH`

## SET_HELI_TURBULENCE_SCALAR

```c
void SET_HELI_TURBULENCE_SCALAR(Vehicle vehicle, float p1)  // 0xE6F13851780394DA
```

build 323

## SET_HOVER_MODE_WING_RATIO

```c
void SET_HOVER_MODE_WING_RATIO(Vehicle vehicle, float ratio)  // 0x70A252F60A3E036B
```

build 1365 · old names: `_SET_SPECIALFLIGHT_WING_RATIO`

## SET_HYDRAULIC_SUSPENSION_RAISE_FACTOR

```c
void SET_HYDRAULIC_SUSPENSION_RAISE_FACTOR(Vehicle vehicle, int wheelId, float value)  // 0x84EA99C62CB3EF0C
```

build 505 · old names: `_SET_HYDRAULIC_STATE`, `_SET_HYDRAULIC_WHEEL_VALUE`

> Works only on vehicles that support hydraulics.

## SET_HYDRAULIC_VEHICLE_STATE

```c
void SET_HYDRAULIC_VEHICLE_STATE(Vehicle vehicle, int state)  // 0x8EA86DF356801C7D
```

build 505 · old names: `_SET_HYDRAULIC_WHEEL_STATE`

> States:
> 4 = raise
> 5 = lower
> 6 = jump

## SET_HYDRAULIC_WHEEL_STATE

```c
void SET_HYDRAULIC_WHEEL_STATE(Vehicle vehicle, int wheelId, int state, float value, Any p4)  // 0xC24075310A8B9CD1
```

build 505 · old names: `_SET_HYDRAULIC_WHEEL_STATE_TRANSITION`

> Sets vehicle wheel hydraulic states transition. Known states:
> 0 - reset
> 1 - raise wheel
> 2 - jump using wheel

## SET_HYDRAULICS_CONTROL

```c
void SET_HYDRAULICS_CONTROL(Vehicle vehicle, BOOL toggle)  // 0x28B18377EB6E25F6
```

build 505 · old names: `_SET_HYDRAULIC_RAISED`

> If false, lowers hydraulics (if raised) and disables hydraulics controls. If true, raises hydraulics and enables hydraulics controls.
> 
> Only used once in each carmod script, on a car that does not have hydraulics to begin with.

## SET_IGNORE_PLANES_SMALL_PITCH_CHANGE

```c
void SET_IGNORE_PLANES_SMALL_PITCH_CHANGE(Any p0, Any p1)  // 0x8664170EF165C4A6
```

build 2189

## SET_INCREASE_WHEEL_CRUSH_DAMAGE

```c
void SET_INCREASE_WHEEL_CRUSH_DAMAGE(Vehicle vehicle, BOOL toggle)  // 0x2970EAA18FD5E42F
```

build 1604 · old names: `_SET_VEHICLE_WHEELS_DEAL_DAMAGE`

## SET_INVERT_VEHICLE_CONTROLS

```c
void SET_INVERT_VEHICLE_CONTROLS(Vehicle vehicle, BOOL state)  // 0x5B91B229243351A8
```

build 791 · old names: `_SET_VEHICLE_CONTROLS_INVERTED`

> Inverts vehicle's controls. So INPUT_VEH_ACCELERATE will be INPUT_VEH_BRAKE and vise versa (same for A/D controls)
> Doesn't work for planes/helis.

## SET_LAST_DRIVEN_VEHICLE

```c
void SET_LAST_DRIVEN_VEHICLE(Vehicle vehicle)  // 0xACFB2463CC22BED2
```

build 323

## SET_LIGHTS_CUTOFF_DISTANCE_TWEAK

```c
void SET_LIGHTS_CUTOFF_DISTANCE_TWEAK(float distance)  // 0xBC3CCA5844452B06
```

build 323

## SET_MISSION_TRAIN_AS_NO_LONGER_NEEDED

```c
void SET_MISSION_TRAIN_AS_NO_LONGER_NEEDED(Vehicle* train, BOOL p1)  // 0xBBE7648349B49BE8
```

build 323

> p1 is always 0

## SET_MISSION_TRAIN_COORDS

```c
void SET_MISSION_TRAIN_COORDS(Vehicle train, float x, float y, float z)  // 0x591CA673AA6AB736
```

build 323

## SET_NITROUS_IS_ACTIVE

```c
void SET_NITROUS_IS_ACTIVE(Vehicle vehicle, BOOL toggle)  // 0x9E566EA551F4F1A6
```

build 3407

## SET_NUMBER_OF_PARKED_VEHICLES

```c
void SET_NUMBER_OF_PARKED_VEHICLES(int value)  // 0xCAA15F13EBD417FF
```

build 323

## SET_OPEN_REAR_DOORS_ON_EXPLOSION

```c
void SET_OPEN_REAR_DOORS_ON_EXPLOSION(Vehicle vehicle, BOOL toggle)  // 0x1B212B26DD3C04DF
```

build 757

## SET_OVERRIDE_NITROUS_LEVEL

```c
void SET_OVERRIDE_NITROUS_LEVEL(Vehicle vehicle, BOOL toggle, float level, float power, float rechargeTime, BOOL disableSound)  // 0xC8E9B6B71B8E660D
```

build 1604 · old names: `_SET_VEHICLE_NITRO_ENABLED`

## SET_OVERRIDE_VEHICLE_DOOR_TORQUE

```c
void SET_OVERRIDE_VEHICLE_DOOR_TORQUE(Any p0, Any p1, Any p2)  // 0x66E3AAFACE2D1EB8
```

build 1103

## SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME

```c
void SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME(float multiplier)  // 0xEAE6DCC7EEE3DB1D
```

build 323

## SET_PEDS_CAN_FALL_OFF_THIS_VEHICLE_FROM_LARGE_FALL_DAMAGE

```c
void SET_PEDS_CAN_FALL_OFF_THIS_VEHICLE_FROM_LARGE_FALL_DAMAGE(Vehicle vehicle, BOOL toggle, float p2)  // 0x59C3757B3B7408E8
```

build 1493

> Sets some bit and float of vehicle. float is >= 0

## SET_PICKUP_ROPE_LENGTH_FOR_CARGOBOB

```c
void SET_PICKUP_ROPE_LENGTH_FOR_CARGOBOB(Vehicle cargobob, float length1, float length2, BOOL p3)  // 0x877C1EAEAC531023
```

build 323 · old names: `_SET_CARGOBOB_HOOK_POSITION`

> min: 1.9f, max: 100.0f

## SET_PICKUP_ROPE_LENGTH_WITHOUT_CREATING_ROPE_FOR_CARGOBOB

```c
void SET_PICKUP_ROPE_LENGTH_WITHOUT_CREATING_ROPE_FOR_CARGOBOB(Any p0, Any p1, Any p2)  // 0xC0ED6438E6D39BA8
```

build 944

## SET_PLANE_CONTROL_SECTIONS_SHOULD_BREAK_OFF_FROM_EXPLOSIONS

```c
void SET_PLANE_CONTROL_SECTIONS_SHOULD_BREAK_OFF_FROM_EXPLOSIONS(Vehicle vehicle, BOOL toggle)  // 0xDD8A2D3337F04196
```

build 3407

## SET_PLANE_ENGINE_HEALTH

```c
void SET_PLANE_ENGINE_HEALTH(Vehicle vehicle, float health)  // 0x2A86A0475B6A1434
```

build 1103 · old names: `_SET_PLANE_ENGINE_HEALTH`

> Works just like SET_VEHICLE_ENGINE_HEALTH, but only for planes.

## SET_PLANE_PROPELLER_HEALTH

```c
BOOL SET_PLANE_PROPELLER_HEALTH(Vehicle plane, float health)  // 0x4C815EB175086F84
```

build 1103 · old names: `_SET_PLANE_PROPELLERS_HEALTH`

## SET_PLANE_RESIST_TO_EXPLOSION

```c
void SET_PLANE_RESIST_TO_EXPLOSION(Vehicle vehicle, BOOL toggle)  // 0xE16142B94664DEFD
```

build 323

## SET_PLANE_SECTION_DAMAGE_SCALE

```c
void SET_PLANE_SECTION_DAMAGE_SCALE(Vehicle vehicle, Any p1, Any p2)  // 0x0BBB9A7A8FFE931B
```

build 1290

## SET_PLANE_TURBULENCE_MULTIPLIER

```c
void SET_PLANE_TURBULENCE_MULTIPLIER(Vehicle vehicle, float multiplier)  // 0xAD2D28A1AFDFF131
```

build 323

> This native sets the turbulence multiplier. It only works for planes.
> 0.0 = no turbulence at all.
> 1.0 = heavy turbulence.
> Works by just calling it once, does not need to be called every tick.

## SET_PLAYBACK_SPEED

```c
void SET_PLAYBACK_SPEED(Vehicle vehicle, float speed)  // 0x6683AB880E427778
```

build 323

## SET_PLAYBACK_TO_USE_AI

```c
void SET_PLAYBACK_TO_USE_AI(Vehicle vehicle, int drivingStyle)  // 0xA549C3B37EA28131
```

build 323

> Identical to SET_PLAYBACK_TO_USE_AI_TRY_TO_REVERT_BACK_LATER with 0 as arguments for p1 and p3.

## SET_PLAYBACK_TO_USE_AI_TRY_TO_REVERT_BACK_LATER

```c
void SET_PLAYBACK_TO_USE_AI_TRY_TO_REVERT_BACK_LATER(Vehicle vehicle, int time, int drivingStyle, BOOL p3)  // 0x6E63860BBB190730
```

build 323

> Time is number of milliseconds before reverting, zero for indefinitely.

## SET_PLAYERS_LAST_VEHICLE

```c
void SET_PLAYERS_LAST_VEHICLE(Vehicle vehicle)  // 0xBCDF8BAF56C87B6A
```

build 323

## SET_POLICE_FOCUS_WILL_TRACK_VEHICLE

```c
void SET_POLICE_FOCUS_WILL_TRACK_VEHICLE(Vehicle vehicle, BOOL toggle)  // 0x4E74E62E0A97E901
```

build 323

## SET_POSITION_OFFSET_FOR_RECORDED_VEHICLE_PLAYBACK

```c
void SET_POSITION_OFFSET_FOR_RECORDED_VEHICLE_PLAYBACK(Vehicle vehicle, float x, float y, float z)  // 0x796A877E459B99EA
```

build 323

## SET_RANDOM_BOATS

```c
void SET_RANDOM_BOATS(BOOL toggle)  // 0x84436EC293B1415F
```

build 323

## SET_RANDOM_BOATS_MP

```c
void SET_RANDOM_BOATS_MP(BOOL toggle)  // 0xDA5E12F728DB30CA
```

build 2372 · old names: `_SET_RANDOM_BOATS_IN_MP`

## SET_RANDOM_TRAINS

```c
void SET_RANDOM_TRAINS(BOOL toggle)  // 0x80D9F74197EA47D9
```

build 323

## SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME

```c
void SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME(float multiplier)  // 0xB3B3359379FE77D3
```

build 323

## SET_REDUCED_SUSPENSION_FORCE

```c
void SET_REDUCED_SUSPENSION_FORCE(Vehicle vehicle, BOOL enable)  // 0x3A375167F5782A65
```

build 2372 · old names: `_SET_REDUCE_DRIFT_VEHICLE_SUSPENSION`

> Lowers the vehicle's stance. Only works for vehicles that have strAdvancedFlags 0x8000 and 0x4000000 set.

## SET_RENDER_TRAIN_AS_DERAILED

```c
void SET_RENDER_TRAIN_AS_DERAILED(Vehicle train, BOOL toggle)  // 0x317B11A312DF5534
```

build 323

> Makes the train all jumbled up and derailed as it moves on the tracks (though that wont stop it from its normal operations)

## SET_ROCKET_BOOST_ACTIVE

```c
void SET_ROCKET_BOOST_ACTIVE(Vehicle vehicle, BOOL active)  // 0x81E1552E35DC3839
```

build 944 · old names: `_SET_VEHICLE_ROCKET_BOOST_ACTIVE`

## SET_ROCKET_BOOST_FILL

```c
void SET_ROCKET_BOOST_FILL(Vehicle vehicle, float percentage)  // 0xFEB2DDED3509562E
```

build 1103 · old names: `_SET_VEHICLE_ROCKET_BOOST_PERCENTAGE`

## SET_SCRIPT_RAMP_IMPULSE_SCALE

```c
void SET_SCRIPT_RAMP_IMPULSE_SCALE(Vehicle vehicle, float impulseScale)  // 0xEFC13B1CE30D755D
```

build 944 · old names: `_SET_VEHICLE_RAMP_LAUNCH_MODIFIER`

## SET_SCRIPT_ROCKET_BOOST_RECHARGE_TIME

```c
void SET_SCRIPT_ROCKET_BOOST_RECHARGE_TIME(Vehicle vehicle, float seconds)  // 0xE00F2AB100B76E89
```

build 944 · old names: `_SET_VEHICLE_ROCKET_BOOST_REFILL_TIME`

## SET_SCRIPT_VEHICLE_GENERATOR

```c
void SET_SCRIPT_VEHICLE_GENERATOR(int vehicleGenerator, BOOL enabled)  // 0xD9D620E0AC6DC4B0
```

build 323

> Only called once in the decompiled scripts. Presumably activates the specified generator.

## SET_SHORT_SLOWDOWN_FOR_LANDING

```c
void SET_SHORT_SLOWDOWN_FOR_LANDING(Vehicle vehicle)  // 0x107A473D7A6647A9
```

build 1290

> Used on helicopters and blimps during the CTaskVehicleLand task. Sets a value on the task to 10f

## SET_SHOULD_LERP_FROM_AI_TO_FULL_RECORDING

```c
void SET_SHOULD_LERP_FROM_AI_TO_FULL_RECORDING(Vehicle vehicle, BOOL p1)  // 0x063AE2B2CC273588
```

build 323

> A vehicle recording playback flag only used in jewelry_heist

## SET_SHOULD_RESET_TURRET_IN_SCRIPTED_CAMERAS

```c
void SET_SHOULD_RESET_TURRET_IN_SCRIPTED_CAMERAS(Vehicle vehicle, BOOL shouldReset)  // 0x78CEEE41F49F421F
```

build 1103

> Resets the vehicle's turret to its default position in scripted cameras. Doesn't seem to affect turrets that are occupied by a ped.

## SET_SLOW_DOWN_EFFECT_DISABLED

```c
void SET_SLOW_DOWN_EFFECT_DISABLED(BOOL disabled)  // 0x65B080555EA48149
```

build 1011

> Disables the screen effects and sound effects when driving over a slowdown pad.

## SET_SPECIAL_FLIGHT_MODE_ALLOWED

```c
void SET_SPECIAL_FLIGHT_MODE_ALLOWED(Vehicle vehicle, BOOL toggle)  // 0xF1211889DF15A763
```

build 1290 · old names: `_SET_VEHICLE_HOVER_TRANSFORM_ENABLED`

> It will override the ability to transform deluxo. For oppressor it will work just like SET_DISABLE_HOVER_MODE_FLIGHT

## SET_SPECIAL_FLIGHT_MODE_RATIO

```c
void SET_SPECIAL_FLIGHT_MODE_RATIO(Vehicle vehicle, float ratio)  // 0xD138FA15C9776837
```

build 1290 · old names: `_SET_VEHICLE_HOVER_TRANSFORM_RATIO`

> Used in conjunction with SET_SPECIAL_FLIGHT_MODE_TARGET_RATIO, in Rockstar's scripts. Using this will instantly transform the vehicle into hover mode starting from the given ratio (ranging from 0.0 to 1.0, values greater than 1.0 will put the vehicle into a glitched state.) If this is not used alongside SET_SPECIAL_FLIGHT_MODE_TARGET_RATIO, the vehicle will automatically transform back into car mode.
> 
> Usable only with the deluxo and other vehicles with deluxo-like hover mode toggle, modded or otherwise. Does nothing when used on oppressor2.
> 
> Example:
> Ped playerPed = PLAYER::PLAYER_PED_ID();
> Vehicle veh = PED::GET_VEHICLE_PED_IS_USING(playerPed);
> VEHICLE::SET_SPECIAL_FLIGHT_MODE_RATIO(veh, 0.7f);
> VEHICLE::SET_SPECIAL_FLIGHT_MODE_TARGET_RATIO(veh, 1.0f);

## SET_SPECIAL_FLIGHT_MODE_TARGET_RATIO

```c
void SET_SPECIAL_FLIGHT_MODE_TARGET_RATIO(Vehicle vehicle, float targetRatio)  // 0x438B3D7CA026FE91
```

build 1290 · old names: `_SET_VEHICLE_TRANSFORM_STATE`, `_SET_VEHICLE_HOVER_TRANSFORM_PERCENTAGE`

> Used in conjunction with SET_SPECIAL_FLIGHT_MODE_RATIO, in Rockstar's scripts. The vehicle will transform into the given targetRatio, starting from the vehicle's current hover mode transform ratio (which can also be manually set by SET_SPECIAL_FLIGHT_MODE_RATIO,) i.e. setting targetRatio to 0.0 while the vehicle is in hover mode will transform the vehicle into car mode, likewise setting targetRatio to 1.0 while the vehicle is in car mode will transform the vehicle into hover mode, and if the current transform ratio is set to 0.7 while targetRatio is 1.0 the vehicle will transform into hover mode starting from being already partially transformed.
> 
> targetRatio is recommended to always be 0.0 or 1.0, otherwise the vehicle will transform into a glitched state.
> 
> Usable only with the deluxo and other vehicles with deluxo-like hover mode toggle, modded or otherwise. Does nothing when used on oppressor2.
> 
> Example:
> Ped playerPed = PLAYER::PLAYER_PED_ID();
> Vehicle veh = PED::GET_VEHICLE_PED_IS_USING(playerPed);
> VEHICLE::SET_SPECIAL_FLIGHT_MODE_RATIO(veh, 0.7f);
> VEHICLE::SET_SPECIAL_FLIGHT_MODE_TARGET_RATIO(veh, 1.0f);

## SET_SPEED_BOOST_EFFECT_DISABLED

```c
void SET_SPEED_BOOST_EFFECT_DISABLED(BOOL disabled)  // 0x7BBE7FF626A591FE
```

build 877

> Disables the screen effects and sound effects when driving over a speed boost pad.

## SET_SUBMARINE_CRUSH_DEPTHS

```c
void SET_SUBMARINE_CRUSH_DEPTHS(Vehicle vehicle, BOOL p1, float depth1, float depth2, float depth3)  // 0xC59872A5134879C7
```

build 323 · old names: `_JITTER_VEHICLE`

## SET_TASK_VEHICLE_GOTO_PLANE_MIN_HEIGHT_ABOVE_TERRAIN

```c
void SET_TASK_VEHICLE_GOTO_PLANE_MIN_HEIGHT_ABOVE_TERRAIN(Vehicle plane, int height)  // 0xB893215D8D4C015B
```

build 323 · old names: `_SET_PLANE_MIN_HEIGHT_ABOVE_GROUND`, `_SET_PLANE_MIN_HEIGHT_ABOVE_TERRAIN`

## SET_TAXI_LIGHTS

```c
void SET_TAXI_LIGHTS(Vehicle vehicle, BOOL state)  // 0x598803E85E8448D9
```

build 323

> This is not tested - it's just an assumption.
> - Nac
> 
> Doesn't seem to work.  I'll try with an int instead. --JT
> 
> Read the scripts, im dumpass. 
> 
>                             if (!VEHICLE::IS_TAXI_LIGHT_ON(l_115)) {
>                                 VEHICLE::SET_TAXI_LIGHTS(l_115, 1);
>                             }

## SET_TRAILER_ATTACHMENT_ENABLED

```c
void SET_TRAILER_ATTACHMENT_ENABLED(Any p0, Any p1)  // 0x2FA2494B47FDD009
```

build 1103

## SET_TRAILER_INVERSE_MASS_SCALE

```c
void SET_TRAILER_INVERSE_MASS_SCALE(Vehicle vehicle, float scale)  // 0x2A8F319B392E7B3F
```

build 323

## SET_TRAILER_LEGS_LOWERED

```c
void SET_TRAILER_LEGS_LOWERED(Vehicle vehicle)  // 0x878C75C09FBDB942
```

build 1103 · old names: `_SET_TRAILER_LEGS_LOWERED`

## SET_TRAILER_LEGS_RAISED

```c
void SET_TRAILER_LEGS_RAISED(Vehicle vehicle)  // 0x95CF53B3D687F9FA
```

build 323

> in the decompiled scripts, seems to be always called on the vehicle right after being attached to a trailer.

## SET_TRAIN_CRUISE_SPEED

```c
void SET_TRAIN_CRUISE_SPEED(Vehicle train, float speed)  // 0x16469284DB8C62B5
```

build 323

## SET_TRAIN_SPEED

```c
void SET_TRAIN_SPEED(Vehicle train, float speed)  // 0xAA0BC91BE0B796E3
```

build 323

## SET_TRAIN_TRACK_SPAWN_FREQUENCY

```c
void SET_TRAIN_TRACK_SPAWN_FREQUENCY(int trackIndex, int frequency)  // 0x21973BBF8D17EDFA
```

build 323

> Only called once inside main_persitant with the parameters p0 = 0, p1 = 120000
> 
> trackIndex: 0 - 26
> Full list of all train tracks + track nodes by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/traintracks.json

## SET_TRANSFORM_RATE_FOR_ANIMATION

```c
void SET_TRANSFORM_RATE_FOR_ANIMATION(Vehicle vehicle, float transformRate)  // 0x498218259FB7C72D
```

build 1365 · old names: `_SET_UNK_FLOAT_FOR_SUBMARINE_VEHICLE_TASK`

> Affects the playback speed of the submarine car conversion animations. Does not affect hardcoded animations such as the wheels being retracted.

## SET_TRANSFORM_TO_SUBMARINE_USES_ALTERNATE_INPUT

```c
void SET_TRANSFORM_TO_SUBMARINE_USES_ALTERNATE_INPUT(Vehicle vehicle, BOOL toggle)  // 0x41B9FB92EDED32A6
```

build 1365 · old names: `_SET_UNK_BOOL_FOR_SUBMARINE_VEHICLE_TASK`

> When set to true, the key to transform a car to submarine mode changes from raise/lower convertible roof (hold H by default) to special vehicle transform (press X by default.)

## SET_TURRET_HIDDEN

```c
void SET_TURRET_HIDDEN(Vehicle vehicle, int index, BOOL toggle)  // 0xC60060EB0D8AC7B1
```

build 1290 · old names: `_SET_VEHICLE_TURRET_UNK`

> Toggles specific flag on turret

## SET_TYRE_HEALTH

```c
void SET_TYRE_HEALTH(Vehicle vehicle, int wheelIndex, float health)  // 0x74C68EF97645E79D
```

build 1868 · old names: `_SET_TYRE_HEALTH`

> SET_TYRE_WEAR_RATE must be active, otherwise values set to <1000.0f will default to 350.0f
> 
> Usable wheels:
> 0: wheel_lf
> 1: wheel_rf
> 2: wheel_lm1
> 3: wheel_rm1
> 4: wheel_lr
> 5: wheel_rr

## SET_TYRE_MAXIMUM_GRIP_DIFFERENCE_DUE_TO_WEAR_RATE

```c
void SET_TYRE_MAXIMUM_GRIP_DIFFERENCE_DUE_TO_WEAR_RATE(Vehicle vehicle, int wheelIndex, float multiplier)  // 0xC970D0E0FC31D768
```

build 2060 · old names: `_SET_TYRE_TRACTION_LOSS_MULTIPLIER`

> Controls how much traction the wheel loses.
> 
> Default values from Rockstar's Open Wheel Race JSON's:
> "owrtds" (Soft): 0.05
> "owrtdm" (Medium): 0.45
> "owrtdh" (Hard): 0.8
> 
> Usable wheels:
> 0: wheel_lf
> 1: wheel_rf
> 2: wheel_lm1
> 3: wheel_rm1
> 4: wheel_lr
> 5: wheel_rr

## SET_TYRE_WEAR_RATE

```c
void SET_TYRE_WEAR_RATE(Vehicle vehicle, int wheelIndex, float multiplier)  // 0x01894E2EDE923CA2
```

build 1868 · old names: `_SET_TYRE_WEAR_MULTIPLIER`

> Needs to be run for tire wear to work. Multiplier affects the downforce and how fast the tires will wear out, higher values essentially make the vehicle slower on straights and its tires will wear down quicker when cornering. Value must be >0f.
> Default value in Rockstar's Open Wheel Race JSON's ("owrtws", "owrtwm", "owrtwh") is 1.0
> 
> Usable wheels:
> 0: wheel_lf
> 1: wheel_rf
> 2: wheel_lm1
> 3: wheel_rm1
> 4: wheel_lr
> 5: wheel_rr

## SET_TYRE_WEAR_RATE_SCALE

```c
void SET_TYRE_WEAR_RATE_SCALE(Vehicle vehicle, int wheelIndex, float multiplier)  // 0x392183BB9EA57697
```

build 2060 · old names: `_SET_TYRE_SOFTNESS_MULTIPLIER`

> Controls how fast the tires wear out.
> 
> Default values from Rockstar's Open Wheel Race JSON's:
> "owrtss" (Soft): 2.2
> "owrtsm" (Medium): 1.7
> "owrtsh" (Hard): 1.2
> 
> Usable wheels:
> 0: wheel_lf
> 1: wheel_rf
> 2: wheel_lm1
> 3: wheel_rm1
> 4: wheel_lr
> 5: wheel_rr

## SET_USE_DESIRED_Z_CRUISE_SPEED_FOR_LANDING

```c
void SET_USE_DESIRED_Z_CRUISE_SPEED_FOR_LANDING(Vehicle vehicle, BOOL toggle)  // 0xB68CFAF83A02768D
```

build 1290

## SET_USE_DOUBLE_CLICK_FOR_CAR_JUMP

```c
void SET_USE_DOUBLE_CLICK_FOR_CAR_JUMP(BOOL toggle)  // 0x5BBCF35BF6E456F7
```

build 1604

> Changes the car jump control to require a double-tap to activate.

## SET_USE_HIGHER_CAR_JUMP

```c
void SET_USE_HIGHER_CAR_JUMP(Vehicle vehicle, BOOL toggle)  // 0xF06A16CA55D138D8
```

build 944 · old names: `_SET_USE_HIGHER_VEHICLE_JUMP_FORCE`

> Allows vehicles with the FLAG_JUMPING_CAR flag to jump higher (i.e. Ruiner 2000).

## SET_VEHICLE_ACT_AS_IF_HAS_SIREN_ON

```c
void SET_VEHICLE_ACT_AS_IF_HAS_SIREN_ON(Vehicle vehicle, BOOL p1)  // 0x9BECD4B9FEF3F8A6
```

build 323

## SET_VEHICLE_ACT_AS_IF_HIGH_SPEED_FOR_FRAG_SMASHING

```c
void SET_VEHICLE_ACT_AS_IF_HIGH_SPEED_FOR_FRAG_SMASHING(Vehicle vehicle, BOOL p1)  // 0x1F9FB66F3A3842D2
```

build 323

## SET_VEHICLE_ACTIVE_DURING_PLAYBACK

```c
void SET_VEHICLE_ACTIVE_DURING_PLAYBACK(Vehicle vehicle, BOOL toggle)  // 0xDFFCEF48E511DB48
```

build 323

## SET_VEHICLE_ACTIVE_FOR_PED_NAVIGATION

```c
void SET_VEHICLE_ACTIVE_FOR_PED_NAVIGATION(Vehicle vehicle, BOOL toggle)  // 0x21115BCD6E44656A
```

build 323 · old names: `_SET_VEHICLE_CLOSE_DOOR_DEFERED_ACTION`

## SET_VEHICLE_AI_CAN_USE_EXCLUSIVE_SEATS

```c
void SET_VEHICLE_AI_CAN_USE_EXCLUSIVE_SEATS(Vehicle vehicle, BOOL toggle)  // 0x41062318F23ED854
```

build 323

> Toggles a flag related to SET_VEHICLE_EXCLUSIVE_DRIVER, however, doesn't enable that feature (or trigger script events related to it).

## SET_VEHICLE_ALARM

```c
void SET_VEHICLE_ALARM(Vehicle vehicle, BOOL state)  // 0xCDE5E70C1DDB954C
```

build 323

## SET_VEHICLE_ALLOW_HOMING_MISSLE_LOCKON

```c
void SET_VEHICLE_ALLOW_HOMING_MISSLE_LOCKON(Vehicle vehicle, BOOL toggle, BOOL p2)  // 0x7D6F9A3EF26136A0
```

build 323

## SET_VEHICLE_ALLOW_HOMING_MISSLE_LOCKON_SYNCED

```c
void SET_VEHICLE_ALLOW_HOMING_MISSLE_LOCKON_SYNCED(Vehicle vehicle, BOOL canBeLockedOn, BOOL p2)  // 0x1DDA078D12879EEE
```

build 463 · old names: `_SET_VEHICLE_CAN_BE_LOCKED_ON`

## SET_VEHICLE_ALLOW_NO_PASSENGERS_LOCKON

```c
void SET_VEHICLE_ALLOW_NO_PASSENGERS_LOCKON(Vehicle veh, BOOL toggle)  // 0x5D14D4154BFE7B2C
```

build 323

> Makes the vehicle accept no passengers.

## SET_VEHICLE_AUTOMATICALLY_ATTACHES

```c
Entity SET_VEHICLE_AUTOMATICALLY_ATTACHES(Vehicle vehicle, BOOL p1, Any p2)  // 0x8BA6F76BC53A1493
```

build 323

## SET_VEHICLE_AVOID_PLAYER_VEHICLE_RIOT_VAN_MISSION

```c
void SET_VEHICLE_AVOID_PLAYER_VEHICLE_RIOT_VAN_MISSION(Any p0)  // 0xD3301660A57C9272
```

build 757

## SET_VEHICLE_BLIP_THROTTLE_RANDOMLY

```c
void SET_VEHICLE_BLIP_THROTTLE_RANDOMLY(Vehicle vehicle, BOOL p1)  // 0x9F3F689B814F2599
```

build 323

## SET_VEHICLE_BOBBLEHEAD_VELOCITY

```c
void SET_VEHICLE_BOBBLEHEAD_VELOCITY(float x, float y, float p2)  // 0x870B8B7A766615C8
```

build 505

> Controls how fast bobbleheads and tsurikawas move on each axis.
> 
> p2 is probably z, but changing that value didn't seem to have a noticeable effect.

## SET_VEHICLE_BODY_HEALTH

```c
void SET_VEHICLE_BODY_HEALTH(Vehicle vehicle, float value)  // 0xB77D05AC8C78AADB
```

build 323

> p2 often set to 1000.0 in the decompiled scripts.

## SET_VEHICLE_BOMB_AMMO

```c
void SET_VEHICLE_BOMB_AMMO(Vehicle vehicle, int bombCount)  // 0xF4B2ED59DEB5D774
```

build 1180 · old names: `_SET_VEHICLE_BOMBS`, `_SET_AIRCRAFT_BOMB_COUNT`, `_SET_VEHICLE_BOMB_COUNT`

> Sets the amount of bombs that this vehicle has. As far as I know, this does _not_ impact vehicle weapons or the ammo of those weapons in any way, it is just a way to keep track of the amount of bombs in a specific plane.

## SET_VEHICLE_BRAKE

```c
void SET_VEHICLE_BRAKE(Vehicle vehicle, BOOL toggle)  // 0xE4E2FD323574965C
```

build 757

## SET_VEHICLE_BRAKE_LIGHTS

```c
void SET_VEHICLE_BRAKE_LIGHTS(Vehicle vehicle, BOOL toggle)  // 0x92B35082E0B42F66
```

build 323

## SET_VEHICLE_BROKEN_PARTS_DONT_AFFECT_AI_HANDLING

```c
void SET_VEHICLE_BROKEN_PARTS_DONT_AFFECT_AI_HANDLING(Vehicle vehicle, BOOL p1)  // 0xC361AA040D6637A8
```

build 323

## SET_VEHICLE_BULLDOZER_ARM_POSITION

```c
void SET_VEHICLE_BULLDOZER_ARM_POSITION(Vehicle vehicle, float position, BOOL p2)  // 0xF8EBCCC96ADB9FB7
```

build 323

> Sets the arm position of a bulldozer. Position must be a value between 0.0 and 1.0. Ignored when `p2` is set to false, instead incrementing arm position by 0.1 (or 10%).

## SET_VEHICLE_BURNOUT

```c
void SET_VEHICLE_BURNOUT(Vehicle vehicle, BOOL toggle)  // 0xFB8794444A7D60FB
```

build 323

> On accelerating, spins the driven wheels with the others braked, so you don't go anywhere.

## SET_VEHICLE_CAN_BE_TARGETTED

```c
void SET_VEHICLE_CAN_BE_TARGETTED(Vehicle vehicle, BOOL state)  // 0x3750146A28097A82
```

build 323

> This has not yet been tested - it's just an assumption of what the types could be.

## SET_VEHICLE_CAN_BE_USED_BY_FLEEING_PEDS

```c
void SET_VEHICLE_CAN_BE_USED_BY_FLEEING_PEDS(Vehicle vehicle, BOOL toggle)  // 0x300504B23BD3B711
```

build 323

## SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED

```c
void SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED(Vehicle vehicle, BOOL state)  // 0x4C7028F78FFD3681
```

build 323

## SET_VEHICLE_CAN_BREAK

```c
void SET_VEHICLE_CAN_BREAK(Vehicle vehicle, BOOL toggle)  // 0x59BF8C3D52C92F66
```

build 323

## SET_VEHICLE_CAN_DEFORM_WHEELS

```c
void SET_VEHICLE_CAN_DEFORM_WHEELS(Vehicle vehicle, BOOL toggle)  // 0x0CDDA42F9E360CA6
```

build 323

## SET_VEHICLE_CAN_EJECT_PASSENGERS_IF_LOCKED

```c
void SET_VEHICLE_CAN_EJECT_PASSENGERS_IF_LOCKED(Any p0, Any p1)  // 0x065D03A9D6B2C6B5
```

build 463

## SET_VEHICLE_CAN_ENGINE_MISSFIRE

```c
void SET_VEHICLE_CAN_ENGINE_MISSFIRE(Vehicle vehicle, BOOL toggle)  // 0x206BC5DC9D1AC70A
```

build 323 · old names: `_SET_VEHICLE_CAN_ENGINE_OPERATE_ON_FIRE`

## SET_VEHICLE_CAN_LEAK_OIL

```c
void SET_VEHICLE_CAN_LEAK_OIL(Vehicle vehicle, BOOL toggle)  // 0x51BB2D88D31A914B
```

build 323

## SET_VEHICLE_CAN_LEAK_PETROL

```c
void SET_VEHICLE_CAN_LEAK_PETROL(Vehicle vehicle, BOOL toggle)  // 0x192547247864DFDD
```

build 323

## SET_VEHICLE_CAN_SAVE_IN_GARAGE

```c
void SET_VEHICLE_CAN_SAVE_IN_GARAGE(Vehicle vehicle, BOOL toggle)  // 0x428BACCDF5E26EAD
```

build 323

## SET_VEHICLE_CAUSES_SWERVING

```c
void SET_VEHICLE_CAUSES_SWERVING(Vehicle vehicle, BOOL toggle)  // 0x9849DE24FCF23CCC
```

build 1604

## SET_VEHICLE_CEILING_HEIGHT

```c
void SET_VEHICLE_CEILING_HEIGHT(Vehicle vehicle, float height)  // 0xA46413066687A328
```

build 323 · old names: `GET_VEHICLE_DEFORMATION_GET_TREE`

## SET_VEHICLE_CHEAT_POWER_INCREASE

```c
void SET_VEHICLE_CHEAT_POWER_INCREASE(Vehicle vehicle, float value)  // 0xB59E4BD37AE292DB
```

build 323 · old names: `_SET_VEHICLE_ENGINE_TORQUE_MULTIPLIER`

> <1.0 - Decreased torque
> =1.0 - Default torque
> >1.0 - Increased torque
> 
> Negative values will cause the vehicle to go backwards instead of forwards while accelerating.
> 
> value - is between 0.2 and 1.8 in the decompiled scripts. 
> 
> This needs to be called every frame to take effect.

## SET_VEHICLE_COLOUR_COMBINATION

```c
void SET_VEHICLE_COLOUR_COMBINATION(Vehicle vehicle, int colorCombination)  // 0x33E8CD3322E2FE31
```

build 323

> Sets the selected vehicle's colors to the specified index of the color combination found in the vehicle's carvariations.meta entry.

## SET_VEHICLE_COLOURS

```c
void SET_VEHICLE_COLOURS(Vehicle vehicle, int colorPrimary, int colorSecondary)  // 0x4F1D4BE3A7F24601
```

build 323

> colorPrimary & colorSecondary are the paint index for the vehicle.
> For a list of valid paint indexes, view: https://pastebin.com/pwHci0xK
> -------------------------------------------------------------------------
> Note: minimum color index is 0, maximum color index is (numColorIndices - 1)
> 
> Full list of vehicle colors by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicleColors.json

## SET_VEHICLE_COMBAT_MODE

```c
void SET_VEHICLE_COMBAT_MODE(BOOL toggle)  // 0x36DE109527A2C0C4
```

build 1604

> Does nothing. It's a nullsub.

## SET_VEHICLE_COUNTERMEASURE_AMMO

```c
void SET_VEHICLE_COUNTERMEASURE_AMMO(Vehicle vehicle, int counterMeasureCount)  // 0x9BDA23BF666F0855
```

build 1180 · old names: `_SET_AIRCRAFT_COUNTERMEASURE_COUNT`, `_SET_VEHICLE_COUNTERMEASURE_COUNT`

> Similar to SET_VEHICLE_BOMB_AMMO, this sets the amount of countermeasures that are present on this vehicle.
> Use GET_VEHICLE_BOMB_AMMO to get the current amount.

## SET_VEHICLE_CUSTOM_PATH_NODE_STREAMING_RADIUS

```c
void SET_VEHICLE_CUSTOM_PATH_NODE_STREAMING_RADIUS(Vehicle vehicle, float p1)  // 0x182F266C2D9E2BEB
```

build 323

## SET_VEHICLE_CUSTOM_PRIMARY_COLOUR

```c
void SET_VEHICLE_CUSTOM_PRIMARY_COLOUR(Vehicle vehicle, int r, int g, int b)  // 0x7141766F91D15BEA
```

build 323

> p1, p2, p3 are RGB values for color (255,0,0 for Red, ect)

## SET_VEHICLE_CUSTOM_SECONDARY_COLOUR

```c
void SET_VEHICLE_CUSTOM_SECONDARY_COLOUR(Vehicle vehicle, int r, int g, int b)  // 0x36CED73BFED89754
```

build 323

> p1, p2, p3 are RGB values for color (255,0,0 for Red, ect)

## SET_VEHICLE_DAMAGE

```c
void SET_VEHICLE_DAMAGE(Vehicle vehicle, float xOffset, float yOffset, float zOffset, float damage, float radius, BOOL focusOnModel)  // 0xA1DD317EA8FD4F29
```

build 323

> Apply damage to vehicle at a location. Location is relative to vehicle model (not world).
> 
> Radius of effect damage applied in a sphere at impact location
> When `focusOnModel` set to `true`, the damage sphere will travel towards the vehicle from the given point, thus guaranteeing an impact

## SET_VEHICLE_DAMAGE_SCALE

```c
BOOL SET_VEHICLE_DAMAGE_SCALE(Vehicle vehicle, float p1)  // 0x4E20D2A627011E8E
```

build 757 · old names: `_SET_VEHICLE_DAMAGE_MODIFIER`

## SET_VEHICLE_DAMAGE_SCALES

```c
void SET_VEHICLE_DAMAGE_SCALES(Vehicle vehicle, Any p1, Any p2, Any p3, Any p4)  // 0x9640E30A7F395E4B
```

build 1290

## SET_VEHICLE_DEFORMATION_FIXED

```c
void SET_VEHICLE_DEFORMATION_FIXED(Vehicle vehicle)  // 0x953DA1E1B12C0491
```

build 323

> This fixes the deformation of a vehicle but the vehicle health doesn't improve

## SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME

```c
void SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME(float multiplier)  // 0x245A6883D966D537
```

build 323

> Use this native inside a looped function.
> Values:
> - `0.0` = no vehicles on streets
> - `1.0` = normal vehicles on streets

## SET_VEHICLE_DETONATION_MODE

```c
void SET_VEHICLE_DETONATION_MODE(BOOL toggle)  // 0x82E0AC411E41A5B4
```

build 1604

> Does nothing. It's a nullsub.

## SET_VEHICLE_DIRT_LEVEL

```c
void SET_VEHICLE_DIRT_LEVEL(Vehicle vehicle, float dirtLevel)  // 0x79D3B596FE44EE8B
```

build 323

> You can't use values greater than 15.0
> Also, R* does (float)(rand() % 15) to get a random dirt level when generating a vehicle.

## SET_VEHICLE_DISABLE_COLLISION_UPON_CREATION

```c
void SET_VEHICLE_DISABLE_COLLISION_UPON_CREATION(Vehicle vehicle, BOOL disable)  // 0xAF60E6A2936F982A
```

build 1103

## SET_VEHICLE_DISABLE_HEIGHT_MAP_AVOIDANCE

```c
void SET_VEHICLE_DISABLE_HEIGHT_MAP_AVOIDANCE(Vehicle vehicle, BOOL p1)  // 0x8AA9180DE2FEDD45
```

build 323

## SET_VEHICLE_DISABLE_TOWING

```c
void SET_VEHICLE_DISABLE_TOWING(Vehicle vehicle, BOOL toggle)  // 0x2B6747FAA9DB9D6B
```

build 323

## SET_VEHICLE_DONT_TERMINATE_TASK_WHEN_ACHIEVED

```c
void SET_VEHICLE_DONT_TERMINATE_TASK_WHEN_ACHIEVED(Vehicle vehicle)  // 0x76D26A22750E849E
```

build 1103

## SET_VEHICLE_DOOR_AUTO_LOCK

```c
void SET_VEHICLE_DOOR_AUTO_LOCK(Vehicle vehicle, int doorId, BOOL toggle)  // 0x3B458DDB57038F08
```

build 877

> doorId: see SET_VEHICLE_DOOR_SHUT
> 
> Usually used alongside other vehicle door natives.

## SET_VEHICLE_DOOR_BROKEN

```c
void SET_VEHICLE_DOOR_BROKEN(Vehicle vehicle, int doorId, BOOL deleteDoor)  // 0xD4D4F6A4AB575A33
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## SET_VEHICLE_DOOR_CONTROL

```c
void SET_VEHICLE_DOOR_CONTROL(Vehicle vehicle, int doorId, int speed, float angle)  // 0xF2BFA0430F0A0FCB
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## SET_VEHICLE_DOOR_LATCHED

```c
void SET_VEHICLE_DOOR_LATCHED(Vehicle vehicle, int doorId, BOOL p2, BOOL p3, BOOL p4)  // 0xA5A9653A8D2CAF48
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## SET_VEHICLE_DOOR_OPEN

```c
void SET_VEHICLE_DOOR_OPEN(Vehicle vehicle, int doorId, BOOL loose, BOOL openInstantly)  // 0x7C65DAC73C35C862
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## SET_VEHICLE_DOOR_SHUT

```c
void SET_VEHICLE_DOOR_SHUT(Vehicle vehicle, int doorId, BOOL closeInstantly)  // 0x93D9BD300D7789E5
```

build 323

> enum eDoorId
> {
> 	VEH_EXT_DOOR_INVALID_ID = -1,
> 	VEH_EXT_DOOR_DSIDE_F,
> 	VEH_EXT_DOOR_DSIDE_R,
> 	VEH_EXT_DOOR_PSIDE_F,
> 	VEH_EXT_DOOR_PSIDE_R,
> 	VEH_EXT_BONNET,
> 	VEH_EXT_BOOT
> };

## SET_VEHICLE_DOORS_LOCKED

```c
void SET_VEHICLE_DOORS_LOCKED(Vehicle vehicle, int doorLockStatus)  // 0xB664292EAECF7FA6
```

build 323

> enum eVehicleLockState
> {
> 	VEHICLELOCK_NONE,
> 	VEHICLELOCK_UNLOCKED,
> 	VEHICLELOCK_LOCKED,
> 	VEHICLELOCK_LOCKOUT_PLAYER_ONLY,
> 	VEHICLELOCK_LOCKED_PLAYER_INSIDE,
> 	VEHICLELOCK_LOCKED_INITIALLY,
> 	VEHICLELOCK_FORCE_SHUT_DOORS,
> 	VEHICLELOCK_LOCKED_BUT_CAN_BE_DAMAGED,
> 	VEHICLELOCK_LOCKED_BUT_BOOT_UNLOCKED,
> 	VEHICLELOCK_LOCKED_NO_PASSENGERS,
> 	VEHICLELOCK_CANNOT_ENTER	
> };

## SET_VEHICLE_DOORS_LOCKED_FOR_ALL_PLAYERS

```c
void SET_VEHICLE_DOORS_LOCKED_FOR_ALL_PLAYERS(Vehicle vehicle, BOOL toggle)  // 0xA2F80B8D040727CC
```

build 323

> After some analysis, I've decided that these are what the parameters are.
> 
> We can see this being used in R* scripts such as "am_mp_property_int.ysc.c4":
> l_11A1 = PED::GET_VEHICLE_PED_IS_IN(PLAYER::PLAYER_PED_ID(), 1);
> ...
> VEHICLE::SET_VEHICLE_DOORS_LOCKED_FOR_ALL_PLAYERS(l_11A1, 1);

## SET_VEHICLE_DOORS_LOCKED_FOR_ALL_TEAMS

```c
void SET_VEHICLE_DOORS_LOCKED_FOR_ALL_TEAMS(Vehicle vehicle, BOOL toggle)  // 0x203B527D1B77904C
```

build 1365 · old names: `_SET_VEHICLE_DOORS_LOCKED_FOR_UNK`

## SET_VEHICLE_DOORS_LOCKED_FOR_NON_SCRIPT_PLAYERS

```c
void SET_VEHICLE_DOORS_LOCKED_FOR_NON_SCRIPT_PLAYERS(Vehicle vehicle, BOOL toggle)  // 0x9737A37136F07E75
```

build 323

## SET_VEHICLE_DOORS_LOCKED_FOR_PLAYER

```c
void SET_VEHICLE_DOORS_LOCKED_FOR_PLAYER(Vehicle vehicle, Player player, BOOL toggle)  // 0x517AAF684BB50CD1
```

build 323

## SET_VEHICLE_DOORS_LOCKED_FOR_TEAM

```c
void SET_VEHICLE_DOORS_LOCKED_FOR_TEAM(Vehicle vehicle, int team, BOOL toggle)  // 0xB81F6D4A8F5EEBA8
```

build 323

## SET_VEHICLE_DOORS_SHUT

```c
void SET_VEHICLE_DOORS_SHUT(Vehicle vehicle, BOOL closeInstantly)  // 0x781B3D62BB013EF5
```

build 323

> Closes all doors of a vehicle:

## SET_VEHICLE_DROPS_MONEY_WHEN_BLOWN_UP

```c
void SET_VEHICLE_DROPS_MONEY_WHEN_BLOWN_UP(Vehicle vehicle, BOOL toggle)  // 0x068F64F2470F9656
```

build 323 · old names: `_SET_VEHICLE_CREATES_MONEY_PICKUPS_WHEN_EXPLODED`

> Money pickups are created around cars when they explode. Only works when the vehicle model is a car. A single pickup is between 1 and 18 dollars in size. All car models seem to give the same amount of money.
> 
> https://youtu.be/3arlUxzHl5Y

## SET_VEHICLE_ENGINE_CAN_DEGRADE

```c
void SET_VEHICLE_ENGINE_CAN_DEGRADE(Vehicle vehicle, BOOL toggle)  // 0x983765856F2564F9
```

build 323

## SET_VEHICLE_ENGINE_HEALTH

```c
void SET_VEHICLE_ENGINE_HEALTH(Vehicle vehicle, float health)  // 0x45F6D8EEF34ABEF1
```

build 323

> 1000 is max health
> Begins leaking gas at around 650 health
> Minimum: -4000
> Maximum: 1000
> 
> -4000: Engine is destroyed
> 0 and below: Engine catches fire and health rapidly declines
> 300: Engine is smoking and losing functionality
> 1000: Engine is perfect

## SET_VEHICLE_ENGINE_ON

```c
void SET_VEHICLE_ENGINE_ON(Vehicle vehicle, BOOL value, BOOL instantly, BOOL disableAutoStart)  // 0x2497C4717C8B881E
```

build 323

> Starts or stops the engine on the specified vehicle.
> 
> vehicle: The vehicle to start or stop the engine on.
> value: true to turn the vehicle on; false to turn it off.
> instantly: if true, the vehicle will be set to the state immediately; otherwise, the current driver will physically turn on or off the engine.
> disableAutoStart: If true, the system will prevent the engine from starting when the player got into it.

## SET_VEHICLE_ENVEFF_SCALE

```c
void SET_VEHICLE_ENVEFF_SCALE(Vehicle vehicle, float fade)  // 0x3AFDC536C3D01674
```

build 323 · old names: `_SET_VEHICLE_PAINT_FADE`

> The parameter fade is a value from 0-1, where 0 is fresh paint.

## SET_VEHICLE_EXCLUSIVE_DRIVER

```c
void SET_VEHICLE_EXCLUSIVE_DRIVER(Vehicle vehicle, Ped ped, int index)  // 0xB5C51B5502E85E83
```

build 323

> index: 0 - 1

## SET_VEHICLE_EXPLODES_ON_EXPLOSION_DAMAGE_AT_ZERO_BODY_HEALTH

```c
void SET_VEHICLE_EXPLODES_ON_EXPLOSION_DAMAGE_AT_ZERO_BODY_HEALTH(Vehicle vehicle, BOOL toggle)  // 0xD565F438137F0E10
```

build 1103

## SET_VEHICLE_EXPLODES_ON_HIGH_EXPLOSION_DAMAGE

```c
void SET_VEHICLE_EXPLODES_ON_HIGH_EXPLOSION_DAMAGE(Vehicle vehicle, BOOL toggle)  // 0x71B0892EC081D60A
```

build 323

> Sets a vehicle to be strongly resistant to explosions. p0 is the vehicle; set p1 to false to toggle the effect on/off.

## SET_VEHICLE_EXTENDED_REMOVAL_RANGE

```c
void SET_VEHICLE_EXTENDED_REMOVAL_RANGE(Vehicle vehicle, int range)  // 0x79DF7E806202CE01
```

build 323

> Max value is 32767

## SET_VEHICLE_EXTRA

```c
void SET_VEHICLE_EXTRA(Vehicle vehicle, int extraId, BOOL disable)  // 0x7EE3A3C5E4A40CC9
```

build 323

> Available extraIds are 1-14, however none of the vehicles have extras above 12.

## SET_VEHICLE_EXTRA_COLOUR_5

```c
void SET_VEHICLE_EXTRA_COLOUR_5(Vehicle vehicle, int color)  // 0xF40DD601A65F7F19
```

build 505 · old names: `_SET_VEHICLE_INTERIOR_COLOUR`, `_SET_VEHICLE_INTERIOR_COLOR`

## SET_VEHICLE_EXTRA_COLOUR_6

```c
void SET_VEHICLE_EXTRA_COLOUR_6(Vehicle vehicle, int color)  // 0x6089CDF6A57F326C
```

build 505 · old names: `_SET_VEHICLE_DASHBOARD_COLOUR`, `_SET_VEHICLE_DASHBOARD_COLOR`

## SET_VEHICLE_EXTRA_COLOURS

```c
void SET_VEHICLE_EXTRA_COLOURS(Vehicle vehicle, int pearlescentColor, int wheelColor)  // 0x2036F561ADD12E33
```

build 323

> They use the same color indexs as SET_VEHICLE_COLOURS.

## SET_VEHICLE_FIXED

```c
void SET_VEHICLE_FIXED(Vehicle vehicle)  // 0x115722B1B9C14C1C
```

build 323

> This fixes a vehicle.
> If the vehicle's engine's broken then you cannot fix it with this native.

## SET_VEHICLE_FLIGHT_NOZZLE_POSITION

```c
void SET_VEHICLE_FLIGHT_NOZZLE_POSITION(Vehicle vehicle, float angleRatio)  // 0x30D779DE7C4F6DD3
```

build 323 · old names: `_SET_DESIRED_VERTICAL_FLIGHT_PHASE`, `_SET_PLANE_VTOL_DESIRED_DIRECTION`

## SET_VEHICLE_FLIGHT_NOZZLE_POSITION_IMMEDIATE

```c
void SET_VEHICLE_FLIGHT_NOZZLE_POSITION_IMMEDIATE(Vehicle vehicle, float angle)  // 0x9AA47FFF660CB932
```

build 323 · old names: `_SET_VERTICAL_FLIGHT_PHASE`, `_SET_PLANE_VTOL_DIRECTION`

## SET_VEHICLE_FORCE_AFTERBURNER

```c
void SET_VEHICLE_FORCE_AFTERBURNER(Vehicle vehicle, BOOL toggle)  // 0xB055A34527CB8FD7
```

build 323

## SET_VEHICLE_FORCE_INTERIORLIGHT

```c
void SET_VEHICLE_FORCE_INTERIORLIGHT(Vehicle vehicle, BOOL toggle)  // 0x8821196D91FA2DE5
```

build 1290

> Sets some bit of vehicle

## SET_VEHICLE_FORWARD_SPEED

```c
void SET_VEHICLE_FORWARD_SPEED(Vehicle vehicle, float speed)  // 0xAB54A438726D25D5
```

build 323

> SCALE: Setting the speed to 30 would result in a speed of roughly 60mph, according to speedometer.
> 
> Speed is in meters per second
> You can convert meters/s to mph here:
> https://www.calculateme.com/speed/meters-per-second/to-miles-per-hour/

## SET_VEHICLE_FORWARD_SPEED_XY

```c
void SET_VEHICLE_FORWARD_SPEED_XY(Vehicle vehicle, float speed)  // 0x6501129C9E0FFA05
```

build 877

> Seems to be identical to SET_VEHICLE_FORWARD_SPEED

## SET_VEHICLE_FRICTION_OVERRIDE

```c
void SET_VEHICLE_FRICTION_OVERRIDE(Vehicle vehicle, float friction)  // 0x1837AF7C627009BA
```

build 323

> Seems to be related to the metal parts, not tyres (like i was expecting lol)

## SET_VEHICLE_FULLBEAM

```c
void SET_VEHICLE_FULLBEAM(Vehicle vehicle, BOOL toggle)  // 0x8B7FD87F0DDB421E
```

build 323

> It switch to highbeam when p1 is set to true.

## SET_VEHICLE_GENERATES_ENGINE_SHOCKING_EVENTS

```c
void SET_VEHICLE_GENERATES_ENGINE_SHOCKING_EVENTS(Vehicle vehicle, BOOL toggle)  // 0x279D50DE5652D935
```

build 323

> Allows creation of CEventShockingPlaneFlyby, CEventShockingHelicopterOverhead, and other(?) Shocking events

## SET_VEHICLE_GENERATOR_AREA_OF_INTEREST

```c
void SET_VEHICLE_GENERATOR_AREA_OF_INTEREST(float x, float y, float z, float radius)  // 0x9A75585FB2E54FAD
```

build 323

> Related to car generators & CPlayerSwitchMgrLong

## SET_VEHICLE_GRAVITY

```c
void SET_VEHICLE_GRAVITY(Vehicle vehicle, BOOL toggle)  // 0x89F149B6131E57DA
```

build 323

## SET_VEHICLE_HANDBRAKE

```c
void SET_VEHICLE_HANDBRAKE(Vehicle vehicle, BOOL toggle)  // 0x684785568EF26A22
```

build 323

## SET_VEHICLE_HANDLING_OVERRIDE

```c
void SET_VEHICLE_HANDLING_OVERRIDE(Vehicle vehicle, Hash hash)  // 0x10655FAB9915623D
```

build 323 · old names: `_SET_VEHICLE_HANDLING_HASH_FOR_AI`

> Use the "AIHandling" string found in handling.meta

## SET_VEHICLE_HAS_BEEN_DRIVEN_FLAG

```c
void SET_VEHICLE_HAS_BEEN_DRIVEN_FLAG(Vehicle vehicle, BOOL toggle)  // 0x02398B627547189C
```

build 323

## SET_VEHICLE_HAS_BEEN_OWNED_BY_PLAYER

```c
void SET_VEHICLE_HAS_BEEN_OWNED_BY_PLAYER(Vehicle vehicle, BOOL owned)  // 0x2B5F9D2AF1F1722D
```

build 323

## SET_VEHICLE_HAS_MUTED_SIRENS

```c
void SET_VEHICLE_HAS_MUTED_SIRENS(Vehicle vehicle, BOOL toggle)  // 0xD8050E0EB60CF274
```

build 323 · old names: `DISABLE_VEHICLE_IMPACT_EXPLOSION_ACTIVATION`, `_SET_DISABLE_VEHICLE_SIREN_SOUND`

> If set to true, prevents vehicle sirens from having sound, leaving only the lights.

## SET_VEHICLE_HAS_STRONG_AXLES

```c
void SET_VEHICLE_HAS_STRONG_AXLES(Vehicle vehicle, BOOL toggle)  // 0x92F0CF722BC4202F
```

build 323

> if true, axles won't bend.

## SET_VEHICLE_HAS_UNBREAKABLE_LIGHTS

```c
void SET_VEHICLE_HAS_UNBREAKABLE_LIGHTS(Vehicle vehicle, BOOL toggle)  // 0x1AA8A837D2169D94
```

build 323 · old names: `_SET_VEHICLE_LIGHTS_CAN_BE_VISIBLY_DAMAGED`

## SET_VEHICLE_HEADLIGHT_SHADOWS

```c
void SET_VEHICLE_HEADLIGHT_SHADOWS(Vehicle vehicle, int p1)  // 0x1FD09E7390A74D54
```

build 323 · old names: `_SET_VEHICLE_LIGHTS_MODE`

> p1 can be either 0, 1 or 2.
> 
> Determines how vehicle lights behave when toggled.
> 
> 0 = Default (Lights can be toggled between off, normal and high beams)
> 1 = Lights Disabled (Lights are fully disabled, cannot be toggled)
> 2 = Always On (Lights can be toggled between normal and high beams)

## SET_VEHICLE_HOMING_LOCKEDONTO_STATE

```c
void SET_VEHICLE_HOMING_LOCKEDONTO_STATE(Any p0, Any p1)  // 0x407DC5E97DB1A4D3
```

build 1493

## SET_VEHICLE_IMPATIENCE_TIMER

```c
void SET_VEHICLE_IMPATIENCE_TIMER(Vehicle vehicle, Any p1)  // 0x6A973569BA094650
```

build 1604

> Seems to copy some values in vehicle

## SET_VEHICLE_IN_CAR_MOD_SHOP

```c
void SET_VEHICLE_IN_CAR_MOD_SHOP(Vehicle vehicle, BOOL toggle)  // 0x9D44FCCE98450843
```

build 323 · old names: `_SET_VEHICLE_SILENT`

> If set to TRUE, it seems to suppress door noises and doesn't allow the horn to be continuous.

## SET_VEHICLE_INACTIVE_DURING_PLAYBACK

```c
void SET_VEHICLE_INACTIVE_DURING_PLAYBACK(Vehicle vehicle, BOOL toggle)  // 0x06582AFF74894C75
```

build 323

## SET_VEHICLE_INDICATOR_LIGHTS

```c
void SET_VEHICLE_INDICATOR_LIGHTS(Vehicle vehicle, int turnSignal, BOOL toggle)  // 0xB5D45264751B7DF0
```

build 323

> Sets the turn signal enabled for a vehicle.
> Set turnSignal to 1 for left light, 0 for right light.

## SET_VEHICLE_INDIVIDUAL_DOORS_LOCKED

```c
void SET_VEHICLE_INDIVIDUAL_DOORS_LOCKED(Vehicle vehicle, int doorId, int doorLockStatus)  // 0xBE70724027F85BCD
```

build 323 · old names: `SET_PED_TARGETTABLE_VEHICLE_DESTROY`, `_SET_VEHICLE_DOOR_DESTROY_TYPE`

> doorId: see SET_VEHICLE_DOOR_SHUT

## SET_VEHICLE_INFLUENCES_WANTED_LEVEL

```c
void SET_VEHICLE_INFLUENCES_WANTED_LEVEL(Any p0, BOOL p1)  // 0x0AD9E8F87FF7C16F
```

build 323

## SET_VEHICLE_INTERIORLIGHT

```c
void SET_VEHICLE_INTERIORLIGHT(Vehicle vehicle, BOOL toggle)  // 0xBC2042F090AF6AD3
```

build 323

## SET_VEHICLE_IS_CONSIDERED_BY_PLAYER

```c
void SET_VEHICLE_IS_CONSIDERED_BY_PLAYER(Vehicle vehicle, BOOL toggle)  // 0x31B927BBC44156CD
```

build 323

> Setting this to false, makes the specified vehicle to where if you press Y your character doesn't even attempt the animation to enter the vehicle. Hence it's not considered aka ignored.

## SET_VEHICLE_IS_RACING

```c
void SET_VEHICLE_IS_RACING(Vehicle vehicle, BOOL toggle)  // 0x07116E24E9D1929D
```

build 323 · old names: `STEER_UNLOCK_BIAS`

> p1 (toggle) was always 1 (true) except in one case in the b678 scripts.

## SET_VEHICLE_IS_STOLEN

```c
void SET_VEHICLE_IS_STOLEN(Vehicle vehicle, BOOL isStolen)  // 0x67B2C79AA7FF5738
```

build 323

## SET_VEHICLE_IS_WANTED

```c
void SET_VEHICLE_IS_WANTED(Vehicle vehicle, BOOL state)  // 0xF7EC25A3EBEEC726
```

build 323

> Sets the wanted state of this vehicle.

## SET_VEHICLE_KEEP_ENGINE_ON_WHEN_ABANDONED

```c
void SET_VEHICLE_KEEP_ENGINE_ON_WHEN_ABANDONED(Vehicle vehicle, BOOL toggle)  // 0xB8FBC8B1330CA9B4
```

build 323 · old names: `_SET_VEHICLE_JET_ENGINE_ON`

## SET_VEHICLE_KERS_ALLOWED

```c
void SET_VEHICLE_KERS_ALLOWED(Vehicle vehicle, BOOL toggle)  // 0x99C82F8A139F3E4E
```

build 323 · old names: `_SET_VEHICLE_HUD_SPECIAL_ABILITY_BAR_ACTIVE`

## SET_VEHICLE_LIGHT_MULTIPLIER

```c
void SET_VEHICLE_LIGHT_MULTIPLIER(Vehicle vehicle, float multiplier)  // 0xB385454F8791F57C
```

build 323

> multiplier = brightness of head lights.
> this value isn't capped afaik.
> 
> multiplier = 0.0 no lights
> multiplier = 1.0 default game value
> 

## SET_VEHICLE_LIGHTS

```c
void SET_VEHICLE_LIGHTS(Vehicle vehicle, int state)  // 0x34E710FF01247C5A
```

build 323

> set's if the vehicle has lights or not.
> not an on off toggle.
> p1 = 0 ;vehicle normal lights, off then lowbeams, then highbeams
> p1 = 1 ;vehicle doesn't have lights, always off
> p1 = 2 ;vehicle has always on lights
> p1 = 3 ;or even larger like 4,5,... normal lights like =1
> note1: when using =2 on day it's lowbeam,highbeam
> but at night it's lowbeam,lowbeam,highbeam
> note2: when using =0 it's affected by day or night for highbeams don't exist in daytime.

## SET_VEHICLE_LIMIT_SPEED_WHEN_PLAYER_INACTIVE

```c
void SET_VEHICLE_LIMIT_SPEED_WHEN_PLAYER_INACTIVE(Vehicle vehicle, BOOL toggle)  // 0xC50CE861B55EAB8B
```

build 323

## SET_VEHICLE_LIVERY

```c
void SET_VEHICLE_LIVERY(Vehicle vehicle, int livery)  // 0x60BF608F1B8CD1B6
```

build 323

## SET_VEHICLE_LIVERY2

```c
void SET_VEHICLE_LIVERY2(Vehicle vehicle, int livery)  // 0xA6D3A8750DC73270
```

build 505 · old names: `_SET_VEHICLE_ROOF_LIVERY`

> Used to set the secondary livery (the roof on Tornado Custom being one such example.)
> 
> Livery value is dependent on the amount of liveries present in the vehicle's texture dictionary, for Tornado Custom this would be 0-6.

## SET_VEHICLE_LOD_MULTIPLIER

```c
void SET_VEHICLE_LOD_MULTIPLIER(Vehicle vehicle, float multiplier)  // 0x93AE6A61BE015BF1
```

build 323

## SET_VEHICLE_MAX_SPEED

```c
void SET_VEHICLE_MAX_SPEED(Vehicle vehicle, float speed)  // 0xBAA045B4E42F3C06
```

build 1103 · old names: `_SET_VEHICLE_MAX_SPEED`

> To reset the max speed, set the `speed` value to `0.0` or lower.

## SET_VEHICLE_MAY_BE_USED_BY_GOTO_POINT_ANY_MEANS

```c
void SET_VEHICLE_MAY_BE_USED_BY_GOTO_POINT_ANY_MEANS(Vehicle vehicle, BOOL p1)  // 0xE851E480B814D4BA
```

build 323

## SET_VEHICLE_MOD

```c
void SET_VEHICLE_MOD(Vehicle vehicle, int modType, int modIndex, BOOL customTires)  // 0x6AF0636DDEDCB6DD
```

build 323

> In b944, there are 50 (0 - 49) mod types.
> 
> Sets the vehicle mod.
> The vehicle must have a mod kit first.
> 
> Any out of range ModIndex is stock.
> 
> #Mod Type
> Spoilers - 0
> Front Bumper - 1
> Rear Bumper - 2
> Side Skirt - 3
> Exhaust - 4
> Frame - 5
> Grille - 6
> Hood - 7
> Fender - 8
> Right Fender - 9
> Roof - 10
> Engine - 11
> Brakes - 12
> Transmission - 13
> Horns - 14 (modIndex from 0 to 51)
> Suspension - 15
> Armor - 16
> Front Wheels - 23
> Back Wheels - 24 //only for motocycles
> Plate holders - 25
> Trim Design - 27
> Ornaments - 28
> Dial Design - 30
> Steering Wheel - 33
> Shifter Leavers - 34
> Plaques - 35
> Hydraulics - 38
> Livery - 48
> 
> ENUMS: https://pastebin.com/QzEAn02v

## SET_VEHICLE_MOD_COLOR_1

```c
void SET_VEHICLE_MOD_COLOR_1(Vehicle vehicle, int paintType, int color, int pearlescentColor)  // 0x43FEB945EE7F85B8
```

build 323

> paintType:
> 0: Normal
> 1: Metallic
> 2: Pearl
> 3: Matte
> 4: Metal
> 5: Chrome
> 6: Chameleon
> 
> color: number of the color.
> 
> p3 seems to always be 0.
> 
> Full list of vehicle colors and vehicle plates by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicleColors.json

## SET_VEHICLE_MOD_COLOR_2

```c
void SET_VEHICLE_MOD_COLOR_2(Vehicle vehicle, int paintType, int color)  // 0x816562BADFDEC83E
```

build 323

> Changes the secondary paint type and color
> paintType:
> 0: Normal
> 1: Metallic
> 2: Pearl
> 3: Matte
> 4: Metal
> 5: Chrome
> 6: Chameleon
> 
> color: number of the color
> 
> Full list of vehicle colors and vehicle plates by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicleColors.json

## SET_VEHICLE_MOD_KIT

```c
void SET_VEHICLE_MOD_KIT(Vehicle vehicle, int modKit)  // 0x1F2AA07F00B3217A
```

build 323

> Set modKit to 0 if you plan to call SET_VEHICLE_MOD. That's what the game does. Most body modifications through SET_VEHICLE_MOD will not take effect until this is set to 0.
> 
> Full list of vehicle mod kits and mods by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicleModKits.json

## SET_VEHICLE_MODEL_IS_SUPPRESSED

```c
void SET_VEHICLE_MODEL_IS_SUPPRESSED(Hash model, BOOL suppressed)  // 0x0FC2D89AC25A5814
```

build 323

> Makes the vehicle stop spawning naturally in traffic. Here's an essential example:
> 
> VEHICLE::SET_VEHICLE_MODEL_IS_SUPPRESSED(MISC::GET_HASH_KEY("taco"), true);
> 
> Full list of vehicles by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicles.json

## SET_VEHICLE_NAME_DEBUG

```c
void SET_VEHICLE_NAME_DEBUG(Vehicle vehicle, const char* name)  // 0xBFDF984E2C22B94F
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.

## SET_VEHICLE_NEEDS_TO_BE_HOTWIRED

```c
void SET_VEHICLE_NEEDS_TO_BE_HOTWIRED(Vehicle vehicle, BOOL toggle)  // 0xFBA550EA44404EE6
```

build 323

## SET_VEHICLE_NEON_COLOUR

```c
void SET_VEHICLE_NEON_COLOUR(Vehicle vehicle, int r, int g, int b)  // 0x8E0A582209A62695
```

build 323 · old names: `_SET_VEHICLE_NEON_LIGHTS_COLOUR`

> Sets the color of the neon lights of the specified vehicle.

## SET_VEHICLE_NEON_ENABLED

```c
void SET_VEHICLE_NEON_ENABLED(Vehicle vehicle, int index, BOOL toggle)  // 0x2AA720E4287BF269
```

build 323 · old names: `_SET_VEHICLE_NEON_LIGHT_ENABLED`

> Sets the neon lights of the specified vehicle on/off.
> 
> Indices:
> 0 = Left
> 1 = Right
> 2 = Front
> 3 = Back

## SET_VEHICLE_NEON_INDEX_COLOUR

```c
void SET_VEHICLE_NEON_INDEX_COLOUR(Vehicle vehicle, int index)  // 0xB93B2867F7B479D1
```

build 1493 · old names: `_SET_VEHICLE_NEON_LIGHTS_COLOUR_INDEX`

> Index references CVehicleModelColor

## SET_VEHICLE_NO_EXPLOSION_DAMAGE_FROM_DRIVER

```c
void SET_VEHICLE_NO_EXPLOSION_DAMAGE_FROM_DRIVER(Vehicle vehicle, BOOL toggle)  // 0x5E569EC46EC21CAE
```

build 323

## SET_VEHICLE_NOT_STEALABLE_AMBIENTLY

```c
void SET_VEHICLE_NOT_STEALABLE_AMBIENTLY(Vehicle vehicle, BOOL p1)  // 0xAB04325045427AAE
```

build 323

## SET_VEHICLE_NUMBER_PLATE_TEXT

```c
void SET_VEHICLE_NUMBER_PLATE_TEXT(Vehicle vehicle, const char* plateText)  // 0x95A88F0B409CDA47
```

build 323

> Sets a vehicle's license plate text.  8 chars maximum.
> 
> Example:
> Ped playerPed = PLAYER::PLAYER_PED_ID();
> Vehicle veh = PED::GET_VEHICLE_PED_IS_USING(playerPed);
> char *plateText = "KING";
> VEHICLE::SET_VEHICLE_NUMBER_PLATE_TEXT(veh, plateText);

## SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX

```c
void SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX(Vehicle vehicle, int plateIndex)  // 0x9088EB5A43FFB0A1
```

build 323

> Plates:
> Blue/White - 0
> Yellow/black - 1
> Yellow/Blue - 2
> Blue/White2 - 3
> Blue/White3 - 4
> Yankton - 5

## SET_VEHICLE_OCCUPANTS_TAKE_EXPLOSIVE_DAMAGE

```c
void SET_VEHICLE_OCCUPANTS_TAKE_EXPLOSIVE_DAMAGE(Vehicle vehicle, BOOL toggle)  // 0x35BB21DE06784373
```

build 463

## SET_VEHICLE_ON_GROUND_PROPERLY

```c
BOOL SET_VEHICLE_ON_GROUND_PROPERLY(Vehicle vehicle, float p1)  // 0x49733E92263139D1
```

build 323

> Sets a vehicle on the ground on all wheels.  Returns whether or not the operation was successful.
> 
> sfink: This has an additional param(Vehicle vehicle, float p1) which is always set to 5.0f in the b944 scripts.

## SET_VEHICLE_OUT_OF_CONTROL

```c
void SET_VEHICLE_OUT_OF_CONTROL(Vehicle vehicle, BOOL killDriver, BOOL explodeOnImpact)  // 0xF19D095E42D430CC
```

build 323

> Tested on the player's current vehicle. Unless you kill the driver, the vehicle doesn't loose control, however, if enabled, explodeOnImpact is still active. The moment you crash, boom.

## SET_VEHICLE_PETROL_TANK_HEALTH

```c
void SET_VEHICLE_PETROL_TANK_HEALTH(Vehicle vehicle, float health)  // 0x70DB57649FA8D0D8
```

build 323

> 1000 is max health
> Begins leaking gas at around 650 health
> -999.90002441406 appears to be minimum health, although nothing special occurs

## SET_VEHICLE_PROVIDES_COVER

```c
void SET_VEHICLE_PROVIDES_COVER(Vehicle vehicle, BOOL toggle)  // 0x5AFEEDD9BB2899D7
```

build 323

## SET_VEHICLE_READY_FOR_CLEANUP

```c
void SET_VEHICLE_READY_FOR_CLEANUP(Any p0)  // 0xCF9159024555488C
```

build 944

## SET_VEHICLE_REDUCE_GRIP

```c
void SET_VEHICLE_REDUCE_GRIP(Vehicle vehicle, BOOL toggle)  // 0x222FF6A823D122E2
```

build 323

> Reduces grip significantly so it's hard to go anywhere.

## SET_VEHICLE_REDUCE_GRIP_LEVEL

```c
void SET_VEHICLE_REDUCE_GRIP_LEVEL(Vehicle vehicle, int val)  // 0x6DEE944E1EE90CFB
```

build 1604 · old names: `_SET_VEHICLE_REDUCE_TRACTION`

> val is 0-3
> Often used in conjunction with: SET_VEHICLE_REDUCE_GRIP

## SET_VEHICLE_REMOVE_AGGRESSIVE_CARJACK_MISSION

```c
void SET_VEHICLE_REMOVE_AGGRESSIVE_CARJACK_MISSION(Any p0)  // 0xC4B3347BD68BD609
```

build 573

## SET_VEHICLE_RESPECTS_LOCKS_WHEN_HAS_DRIVER

```c
void SET_VEHICLE_RESPECTS_LOCKS_WHEN_HAS_DRIVER(Vehicle vehicle, BOOL p1)  // 0x2311DD7159F00582
```

build 323

## SET_VEHICLE_RUDDER_BROKEN

```c
void SET_VEHICLE_RUDDER_BROKEN(Vehicle vehicle, BOOL toggle)  // 0x09606148B6C71DEF
```

build 323

## SET_VEHICLE_SEARCHLIGHT

```c
void SET_VEHICLE_SEARCHLIGHT(Vehicle heli, BOOL toggle, BOOL canBeUsedByAI)  // 0x14E85C5EE7A4D542
```

build 323

> Only works during nighttime.

## SET_VEHICLE_SHOOT_AT_TARGET

```c
void SET_VEHICLE_SHOOT_AT_TARGET(Ped driver, Entity entity, float xTarget, float yTarget, float zTarget)  // 0x74CD9A9327A282EA
```

build 323

> Commands the driver of an armed vehicle (p0) to shoot its weapon at a target (p1). p3, p4 and p5 are the coordinates of the target. Example:
> 
> WEAPON::SET_CURRENT_PED_VEHICLE_WEAPON(pilot,MISC::GET_HASH_KEY("VEHICLE_WEAPON_PLANE_ROCKET"));                        VEHICLE::SET_VEHICLE_SHOOT_AT_TARGET(pilot, target, targPos.x, targPos.y, targPos.z);

## SET_VEHICLE_SHUNT_ON_STICK

```c
void SET_VEHICLE_SHUNT_ON_STICK(BOOL toggle)  // 0x99A05839C46CE316
```

build 1604

> Does nothing. It's a nullsub.

## SET_VEHICLE_SIREN

```c
void SET_VEHICLE_SIREN(Vehicle vehicle, BOOL toggle)  // 0xF4924635A19EB37D
```

build 323

> Activate siren on vehicle (Only works if the vehicle has a siren).

## SET_VEHICLE_SLIPSTREAMING_SHOULD_TIME_OUT

```c
void SET_VEHICLE_SLIPSTREAMING_SHOULD_TIME_OUT(BOOL toggle)  // 0xF051D9BFB6BA39C0
```

build 877

## SET_VEHICLE_STAYS_FROZEN_WHEN_CLEANED_UP

```c
void SET_VEHICLE_STAYS_FROZEN_WHEN_CLEANED_UP(Vehicle vehicle, BOOL toggle)  // 0x1CF38D529D7441D9
```

build 323

> Has something to do with trains. Always precedes SET_MISSION_TRAIN_AS_NO_LONGER_NEEDED.
> May be true that it can be used with trains not sure, but not specifically for trains. Go find Xbox360 decompiled scripts and search for 'func_1333' in freemode.c it isn't used just for trains. Thanks for the info tho.

## SET_VEHICLE_STEER_BIAS

```c
void SET_VEHICLE_STEER_BIAS(Vehicle vehicle, float value)  // 0x42A8EC77D5150CBE
```

build 323

> Locks the vehicle's steering to the desired angle, explained below.
> 
> Requires to be called onTick. Steering is unlocked the moment the function stops being called on the vehicle.
> 
> Steer bias:
> -1.0 = full right
> 0.0 = centered steering
> 1.0 = full left

## SET_VEHICLE_STEER_FOR_BUILDINGS

```c
void SET_VEHICLE_STEER_FOR_BUILDINGS(Vehicle vehicle, Any p1)  // 0xDCE97BDF8A0EABC8
```

build 1103

## SET_VEHICLE_STEERING_BIAS_SCALAR

```c
void SET_VEHICLE_STEERING_BIAS_SCALAR(Any p0, float p1)  // 0x9007A2F21DC108D4
```

build 323

## SET_VEHICLE_STOP_INSTANTLY_WHEN_PLAYER_INACTIVE

```c
void SET_VEHICLE_STOP_INSTANTLY_WHEN_PLAYER_INACTIVE(Vehicle vehicle, BOOL toggle)  // 0x6EBFB22D646FFC18
```

build 323

> sfink: sets bit in vehicle's structure, used by maintransition, fm_mission_controller, mission_race and a couple of other scripts. see dissassembly: 
> CVehicle *__fastcall sub_140CDAA10(signed int a1, char a2)
> {
>     CVehicle *result; // rax@1
> 
>     result = EntityAsCVehicle(a1);
>     if ( result )
>     {
>         result->field_886 &= 0xEFu;
>         result->field_886 |= 16 * (a2 & 1);
>     }
>     return result;
> }

## SET_VEHICLE_STRONG

```c
void SET_VEHICLE_STRONG(Vehicle vehicle, BOOL toggle)  // 0x3E8C8727991A8A0B
```

build 323

> If set to true, vehicle will not take crash damage, but is still susceptible to damage from bullets and explosives

## SET_VEHICLE_TAIL_BROKEN

```c
void SET_VEHICLE_TAIL_BROKEN(Vehicle vehicle, BOOL toggle)  // 0x6CB5B84B78AC55FE
```

build 3717

## SET_VEHICLE_TAIL_LIGHTS

```c
void SET_VEHICLE_TAIL_LIGHTS(Vehicle vehicle, BOOL toggle)  // 0x5815BD2763178DF4
```

build 2802

## SET_VEHICLE_TANK_STATIONARY

```c
void SET_VEHICLE_TANK_STATIONARY(Vehicle vehicle, BOOL p1)  // 0x737E398138550FFF
```

build 944

## SET_VEHICLE_TANK_TURRET_POSITION

```c
void SET_VEHICLE_TANK_TURRET_POSITION(Vehicle vehicle, float position, BOOL p2)  // 0x56B94C6D7127DFBA
```

build 323

## SET_VEHICLE_TIMED_EXPLOSION

```c
void SET_VEHICLE_TIMED_EXPLOSION(Vehicle vehicle, Ped ped, BOOL toggle)  // 0x2E0A74E1002380B1
```

build 323

## SET_VEHICLE_TOW_TRUCK_ARM_POSITION

```c
void SET_VEHICLE_TOW_TRUCK_ARM_POSITION(Vehicle vehicle, float position)  // 0xFE54B92A344583CA
```

build 323 · old names: `_SET_TOW_TRUCK_CRANE_RAISED`, `_SET_TOW_TRUCK_CRANE_HEIGHT`

> Sets how much the crane on the tow truck is raised, where 0.0 is fully lowered and 1.0 is fully raised.

## SET_VEHICLE_TURRET_SPEED_THIS_FRAME

```c
void SET_VEHICLE_TURRET_SPEED_THIS_FRAME(Vehicle vehicle, float speed)  // 0x1093408B4B9D1146
```

build 323

## SET_VEHICLE_TURRET_TARGET

```c
void SET_VEHICLE_TURRET_TARGET(Vehicle vehicle, BOOL p1, float x, float y, float z, BOOL p5)  // 0x0581730AB9380412
```

build 1103

## SET_VEHICLE_TYRE_BURST

```c
void SET_VEHICLE_TYRE_BURST(Vehicle vehicle, int index, BOOL onRim, float p3)  // 0xEC6A202EE4960385
```

build 323

> "To burst tyres VEHICLE::SET_VEHICLE_TYRE_BURST(vehicle, 0, true, 1000.0)
> to burst all tyres type it 8 times where p1 = 0 to 7.
> 
> p3 seems to be how much damage it has taken. 0 doesn't deflate them, 1000 completely deflates them.
> 
> '0 = wheel_lf / bike, plane or jet front
> '1 = wheel_rf
> '2 = wheel_lm / in 6 wheels trailer, plane or jet is first one on left
> '3 = wheel_rm / in 6 wheels trailer, plane or jet is first one on right
> '4 = wheel_lr / bike rear / in 6 wheels trailer, plane or jet is last one on left
> '5 = wheel_rr / in 6 wheels trailer, plane or jet is last one on right
> '45 = 6 wheels trailer mid wheel left
> '47 = 6 wheels trailer mid wheel right

## SET_VEHICLE_TYRE_FIXED

```c
void SET_VEHICLE_TYRE_FIXED(Vehicle vehicle, int tyreIndex)  // 0x6E13FC662B882D1D
```

build 323

> tyreIndex = 0 to 4 on normal vehicles
> 
> '0 = wheel_lf / bike, plane or jet front
> '1 = wheel_rf
> '2 = wheel_lm / in 6 wheels trailer, plane or jet is first one on left
> '3 = wheel_rm / in 6 wheels trailer, plane or jet is first one on right
> '4 = wheel_lr / bike rear / in 6 wheels trailer, plane or jet is last one on left
> '5 = wheel_rr / in 6 wheels trailer, plane or jet is last one on right
> '45 = 6 wheels trailer mid wheel left
> '47 = 6 wheels trailer mid wheel right

## SET_VEHICLE_TYRE_SMOKE_COLOR

```c
void SET_VEHICLE_TYRE_SMOKE_COLOR(Vehicle vehicle, int r, int g, int b)  // 0xB5BA80F839791C0F
```

build 323

> Sets the tire smoke's color of this vehicle.
> 
> vehicle: The vehicle that is the target of this method.
> r: The red level in the RGB color code.
> g: The green level in the RGB color code.
> b: The blue level in the RGB color code.
> 
> Note: setting r,g,b to 0 will give the car the "Patriot" tire smoke.

## SET_VEHICLE_TYRES_CAN_BURST

```c
void SET_VEHICLE_TYRES_CAN_BURST(Vehicle vehicle, BOOL toggle)  // 0xEB9DC3C7D8596C46
```

build 323

> Allows you to toggle bulletproof tires.

## SET_VEHICLE_UNDRIVEABLE

```c
void SET_VEHICLE_UNDRIVEABLE(Vehicle vehicle, BOOL toggle)  // 0x8ABA6AF54B942B95
```

build 323

## SET_VEHICLE_USE_ALTERNATE_HANDLING

```c
void SET_VEHICLE_USE_ALTERNATE_HANDLING(Vehicle vehicle, BOOL toggle)  // 0x1D97D1E3A70A649F
```

build 323

## SET_VEHICLE_USE_BOOST_BUTTON_FOR_WHEEL_RETRACT

```c
void SET_VEHICLE_USE_BOOST_BUTTON_FOR_WHEEL_RETRACT(BOOL toggle)  // 0x41290B40FA63E6DA
```

build 1011

> Used for blazer5. Changes the quadbike-jetski transformation input from raise/lower convertible roof (hold H by default) to horn (press E by default.)

## SET_VEHICLE_USE_CUTSCENE_WHEEL_COMPRESSION

```c
BOOL SET_VEHICLE_USE_CUTSCENE_WHEEL_COMPRESSION(Vehicle p0, BOOL p1, BOOL p2, BOOL p3)  // 0xE023E8AC4EF7C117
```

build 323 · old names: `SET_ALL_VEHICLES_SPAWN`

## SET_VEHICLE_USE_MORE_RESTRICTIVE_SPAWN_CHECKS

```c
void SET_VEHICLE_USE_MORE_RESTRICTIVE_SPAWN_CHECKS(Vehicle vehicle, BOOL p1)  // 0x88BC673CA9E0AE99
```

build 323

## SET_VEHICLE_USE_PLAYER_LIGHT_SETTINGS

```c
void SET_VEHICLE_USE_PLAYER_LIGHT_SETTINGS(Vehicle vehicle, BOOL toggle)  // 0xC45C27EF50F36ADC
```

build 323 · old names: `_SET_VEHICLE_USE_PLAYER_LIGHT_SETTINGS`

## SET_VEHICLE_USED_FOR_PILOT_SCHOOL

```c
void SET_VEHICLE_USED_FOR_PILOT_SCHOOL(Vehicle vehicle, BOOL toggle)  // 0xE05DD0E9707003A3
```

build 323

## SET_VEHICLE_USES_LARGE_REAR_RAMP

```c
void SET_VEHICLE_USES_LARGE_REAR_RAMP(Vehicle vehicle, BOOL toggle)  // 0xCAC66558B944DA67
```

build 323

> vehicle must be a plane

## SET_VEHICLE_USES_MP_PLAYER_DAMAGE_MULTIPLIER

```c
void SET_VEHICLE_USES_MP_PLAYER_DAMAGE_MULTIPLIER(Any p0, Any p1)  // 0xBB2333BB87DDD87F
```

build 757

## SET_VEHICLE_WEAPON_CAN_TARGET_OBJECTS

```c
void SET_VEHICLE_WEAPON_CAN_TARGET_OBJECTS(Vehicle vehicle, BOOL toggle)  // 0x86B4B6212CB8B627
```

build 1011 · old names: `_SET_VEHICLE_WEAPONS_DISABLED`

## SET_VEHICLE_WEAPON_DAMAGE_SCALE

```c
BOOL SET_VEHICLE_WEAPON_DAMAGE_SCALE(Vehicle vehicle, float multiplier)  // 0x45A561A9421AB6AD
```

build 944 · old names: `_SET_VEHICLE_UNK_DAMAGE_MULTIPLIER`

## SET_VEHICLE_WEAPON_RESTRICTED_AMMO

```c
void SET_VEHICLE_WEAPON_RESTRICTED_AMMO(Vehicle vehicle, int weaponIndex, int capacity)  // 0x44CD1F493DB2A0A6
```

build 944 · old names: `_SET_VEHICLE_WEAPON_CAPACITY`

> Set vehicle's primary mounted weapon 2 ammo. For example, use it on APC.
> For example, you can "remove" any vehicle weapon from any vehicle.
> ammoAmount -1 = infinite ammo (default value for any spawned vehicle tho)

## SET_VEHICLE_WHEEL_TYPE

```c
void SET_VEHICLE_WHEEL_TYPE(Vehicle vehicle, int WheelType)  // 0x487EB21CC7295BA1
```

build 323

> 0: Sport
> 1: Muscle
> 2: Lowrider
> 3: SUV
> 4: Offroad
> 5: Tuner
> 6: Bike Wheels
> 7: High End
> 8: Benny's Originals
> 9: Benny's Bespoke
> 10: Racing
> 11: Street
> 12: Track

## SET_VEHICLE_WHEELS_CAN_BREAK

```c
void SET_VEHICLE_WHEELS_CAN_BREAK(Vehicle vehicle, BOOL enabled)  // 0x29B18B4FD460CA8F
```

build 323

## SET_VEHICLE_WHEELS_CAN_BREAK_OFF_WHEN_BLOW_UP

```c
void SET_VEHICLE_WHEELS_CAN_BREAK_OFF_WHEN_BLOW_UP(Vehicle vehicle, BOOL toggle)  // 0xA37B9A517B133349
```

build 323 · old names: `SET_VEHICLE_MAX_STR_TRAP`

## SET_VEHICLE_WILL_FORCE_OTHER_VEHICLES_TO_STOP

```c
void SET_VEHICLE_WILL_FORCE_OTHER_VEHICLES_TO_STOP(Vehicle vehicle, BOOL toggle)  // 0xBE5C1255A1830FF5
```

build 323

## SET_VEHICLE_WILL_TELL_OTHERS_TO_HURRY

```c
void SET_VEHICLE_WILL_TELL_OTHERS_TO_HURRY(Vehicle vehicle, BOOL p1)  // 0x2C4A1590ABF43E8B
```

build 323

## SET_VEHICLE_WINDOW_TINT

```c
void SET_VEHICLE_WINDOW_TINT(Vehicle vehicle, int tint)  // 0x57C51E6BAD752696
```

build 323

> enum WindowTints
> {
>  WINDOWTINT_NONE,
>   WINDOWTINT_PURE_BLACK,
>     WINDOWTINT_DARKSMOKE,
>  WINDOWTINT_LIGHTSMOKE,
>     WINDOWTINT_STOCK,
>  WINDOWTINT_LIMO,
>   WINDOWTINT_GREEN
> };
> Full list of all vehicle window tints by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicleColors.json

## SET_VEHICLE_XENON_LIGHT_COLOR_INDEX

```c
void SET_VEHICLE_XENON_LIGHT_COLOR_INDEX(Vehicle vehicle, int colorIndex)  // 0xE41033B25D003A07
```

build 1604 · old names: `_SET_VEHICLE_HEADLIGHTS_COLOUR`, `_SET_VEHICLE_XENON_LIGHTS_COLOUR`, `_SET_VEHICLE_XENON_LIGHTS_COLOR`

> `color`: is the paint index for the vehicle.
> Paint index goes from 0 to 12.
> Be aware that it only works on xenon lights. Example: https://i.imgur.com/yV3cpG9.png
> Full list of all vehicle xenon lights by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/vehicleColors.json

## SET_WHEELIE_ENABLED

```c
void SET_WHEELIE_ENABLED(Vehicle vehicle, BOOL enabled)  // 0x1312DDD8385AEE4E
```

build 1103

> Enables/disables the ability to wheelie on motorcycles.

## SET_WHEELS_EXTENDED_INSTANTLY

```c
void SET_WHEELS_EXTENDED_INSTANTLY(Vehicle vehicle)  // 0xF660602546D27BA8
```

build 944 · old names: `_RAISE_LOWERABLE_WHEELS`, `_RAISE_RETRACTABLE_WHEELS`

## SET_WHEELS_RETRACTED_INSTANTLY

```c
void SET_WHEELS_RETRACTED_INSTANTLY(Vehicle vehicle)  // 0x5335BE58C083E74E
```

build 1011 · old names: `_LOWER_RETRACTABLE_WHEELS`

## SKIP_TIME_IN_PLAYBACK_RECORDED_VEHICLE

```c
void SKIP_TIME_IN_PLAYBACK_RECORDED_VEHICLE(Vehicle vehicle, float time)  // 0x9438F7AD68771A20
```

build 323

> SET_TIME_POSITION_IN_RECORDING can be emulated by: desired_time - GET_TIME_POSITION_IN_RECORDING(vehicle)

## SKIP_TO_END_AND_STOP_PLAYBACK_RECORDED_VEHICLE

```c
void SKIP_TO_END_AND_STOP_PLAYBACK_RECORDED_VEHICLE(Vehicle vehicle)  // 0xAB8E2EDA0C0A5883
```

build 323

## SMASH_VEHICLE_WINDOW

```c
void SMASH_VEHICLE_WINDOW(Vehicle vehicle, int windowIndex)  // 0x9E5B5E4D2CCD2259
```

build 323

> windowIndex:
> 0 = Front Left Window
> 1 = Front Right Window
> 2 = Rear Left Window
> 3 = Rear Right Window
> 4 = Front Windscreen
> 5 = Rear Windscreen
> 6 = Mid Left
> 7 = Mid Right
> 8 = Invalid

## STABILISE_ENTITY_ATTACHED_TO_HELI

```c
void STABILISE_ENTITY_ATTACHED_TO_HELI(Vehicle vehicle, Entity entity, float p2)  // 0x374706271354CB18
```

build 323

## START_PLAYBACK_RECORDED_VEHICLE

```c
void START_PLAYBACK_RECORDED_VEHICLE(Vehicle vehicle, int recording, const char* script, BOOL p3)  // 0x3F878F92B3A7A071
```

build 323

> p3 is some flag related to 'trailers' (invokes CVehicle::GetTrailer).
> 
> See REQUEST_VEHICLE_RECORDING

## START_PLAYBACK_RECORDED_VEHICLE_USING_AI

```c
void START_PLAYBACK_RECORDED_VEHICLE_USING_AI(Vehicle vehicle, int recording, const char* script, float speed, int drivingStyle)  // 0x29DE5FA52D00428C
```

build 323

> AI abides by the provided driving style (e.g., stopping at red lights or waiting behind traffic) while executing the specificed vehicle recording.
> 
> FORCE_PLAYBACK_RECORDED_VEHICLE_UPDATE is a related native that deals with the AI physics for such recordings.

## START_PLAYBACK_RECORDED_VEHICLE_WITH_FLAGS

```c
void START_PLAYBACK_RECORDED_VEHICLE_WITH_FLAGS(Vehicle vehicle, int recording, const char* script, int flags, int time, int drivingStyle)  // 0x7D80FD645D4DA346
```

build 323

> flags requires further research, e.g., 0x4/0x8 are related to the AI driving task and 0x20 is internally set and interacts with dynamic entity components.
> 
> time, often zero and capped at 500, is related to SET_PLAYBACK_TO_USE_AI_TRY_TO_REVERT_BACK_LATER

## START_VEHICLE_ALARM

```c
void START_VEHICLE_ALARM(Vehicle vehicle)  // 0xB8FF7AB45305C345
```

build 323

## START_VEHICLE_HORN

```c
void START_VEHICLE_HORN(Vehicle vehicle, int duration, Hash mode, BOOL forever)  // 0x9C8C6504B5B63D2C
```

build 323

> Sounds the horn for the specified vehicle.
> 
> vehicle: The vehicle to activate the horn for.
> mode: The hash of "NORMAL" or "HELDDOWN". Can be 0.
> duration: The duration to sound the horn, in milliseconds.
> 
> Note: If a player is in the vehicle, it will only sound briefly.

## STOP_ALL_GARAGE_ACTIVITY

```c
void STOP_ALL_GARAGE_ACTIVITY()  // 0x0F87E938BDF29D66
```

build 323

## STOP_BRINGING_VEHICLE_TO_HALT

```c
void STOP_BRINGING_VEHICLE_TO_HALT(Vehicle vehicle)  // 0x7C06330BFDDA182E
```

build 1103 · old names: `_STOP_BRING_VEHICLE_TO_HALT`

> Stops CTaskBringVehicleToHalt

## STOP_PLAYBACK_RECORDED_VEHICLE

```c
void STOP_PLAYBACK_RECORDED_VEHICLE(Vehicle vehicle)  // 0x54833611C17ABDEA
```

build 323

## SUPPRESS_NEONS_ON_VEHICLE

```c
void SUPPRESS_NEONS_ON_VEHICLE(Vehicle vehicle, BOOL toggle)  // 0x83F813570FF519DE
```

build 573 · old names: `_DISABLE_VEHICLE_NEON_LIGHTS`

## SWING_BOAT_BOOM_FREELY

```c
void SWING_BOAT_BOOM_FREELY(Vehicle vehicle, BOOL toggle)  // 0xC1F981A6F74F0C23
```

build 323 · old names: `_GET_BOAT_BOOM_POSITION_RATIO_2`

> Same call as ALLOW_BOAT_BOOM_TO_ANIMATE

## SWING_BOAT_BOOM_TO_RATIO

```c
void SWING_BOAT_BOOM_TO_RATIO(Vehicle vehicle, float ratio)  // 0xF488C566413B4232
```

build 323 · old names: `_SET_BOAT_BOOM_POSITION_RATIO`

> Sets the boat boom position for the `TR3` trailer.
> Ratio value is between `0.0` and `1.0`, where `0.0` is 90 degrees to the left of the boat, and `1.0` is just slightly to the right/back of the boat.
> To get the current boom position ratio, use GET_BOAT_BOOM_POSITION_RATIO

## SWITCH_TRAIN_TRACK

```c
void SWITCH_TRAIN_TRACK(int trackId, BOOL state)  // 0xFD813BB7DB977F20
```

build 323

> Toggles whether ambient trains can spawn on the specified track or not
> 
> `trackId` is the internal id of the train track to switch.
> `state` is whether ambient trains can spawn or not
> 
> trackIds
> 0 (`trains1.dat`) Main track around SA
> 1 (`trains2.dat`) Davis Quartz Quarry branch
> 2 (`trains3.dat`) Second track alongside live track along Roy Lewenstein Blv.
> 3 (`trains4.dat`) Metro track circuit
> 4 (`trains5.dat`) Branch in Mirror Park Railyard
> 5 (`trains6.dat`) Branch in Mirror Park Railyard
> 6 (`trains7.dat`) LS branch to Mirror Park Railyard
> 7 (`trains8.dat`) Overground part of metro track along Forum Dr.
> 8 (`trains9.dat`) Branch to Mirror Park Railyard
> 9 (`trains10.dat`) Yankton train
> 10 (`trains11.dat`) Part of metro track near mission row
> 11 (`trains12.dat`) Yankton prologue mission train
> Full list of all train tracks + track nodes by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/traintracks.json

## TOGGLE_VEHICLE_MOD

```c
void TOGGLE_VEHICLE_MOD(Vehicle vehicle, int modType, BOOL toggle)  // 0x2A1F4F37F95BAD08
```

build 323

> Toggles:
> UNK17 - 17
> Turbo - 18
> UNK19 - 19
> Tire Smoke - 20
> UNK21 - 21
> Xenon Headlights - 22

## TRACK_VEHICLE_VISIBILITY

```c
void TRACK_VEHICLE_VISIBILITY(Vehicle vehicle)  // 0x64473AEFDCF47DCA
```

build 323

> in script hook .net 
> 
> Vehicle v = ...;
> Function.Call(Hash.TRACK_VEHICLE_VISIBILITY, v.Handle);

## TRANSFORM_TO_CAR

```c
void TRANSFORM_TO_CAR(Vehicle vehicle, BOOL noAnimation)  // 0x2A69FFD1B42BFF9E
```

build 1290 · old names: `_TRANSFORM_STORMBERG_TO_ROAD_VEHICLE`, `_TRANSFORM_SUBMARINE_TO_VEHICLE`

> Transforms the `stormberg`/`toreador` to its "road vehicle" variant. If the vehicle is already in that state then the vehicle transformation audio will still play, but the vehicle won't change at all.

## TRANSFORM_TO_SUBMARINE

```c
BOOL TRANSFORM_TO_SUBMARINE(Vehicle vehicle, BOOL noAnimation)  // 0xBE4C854FFDB6EEBE
```

build 1365 · old names: `_TRANSFORM_STORMBERG_TO_WATER_VEHICLE`, `_TRANSFORM_VEHICLE_TO_SUBMARINE`

> Transforms the `stormberg`/`toreador` to its "submarine" variant. If the vehicle is already in that state then the vehicle transformation audio will still play, but the vehicle won't change at all.

## UNPAUSE_PLAYBACK_RECORDED_VEHICLE

```c
void UNPAUSE_PLAYBACK_RECORDED_VEHICLE(Vehicle vehicle)  // 0x8879EE09268305D5
```

build 323

## VEHICLE_SET_ENABLE_NORMALISE_RAMP_CAR_VERTICAL_VELOCTIY

```c
void VEHICLE_SET_ENABLE_NORMALISE_RAMP_CAR_VERTICAL_VELOCTIY(Any p0, Any p1)  // 0x756AE6E962168A04
```

build 944 · old names: `_SET_VEHICLE_RAMP_UPWARDS_LAUNCH_MOTION`

## VEHICLE_SET_ENABLE_RAMP_CAR_SIDE_IMPULSE

```c
void VEHICLE_SET_ENABLE_RAMP_CAR_SIDE_IMPULSE(Any p0, Any p1)  // 0x1BBAC99C0BC53656
```

build 944 · old names: `_SET_VEHICLE_RAMP_SIDEWAYS_LAUNCH_MOTION`

## VEHICLE_SET_EXTENABLE_SIDE_TARGET_RATIO

```c
int VEHICLE_SET_EXTENABLE_SIDE_TARGET_RATIO(Any p0, Any p1)  // 0xF3B0E0AED097A3F5
```

build 1103

## VEHICLE_SET_JET_WASH_FORCE_ENABLED

```c
void VEHICLE_SET_JET_WASH_FORCE_ENABLED(Any p0)  // 0x9D30687C57BAA0BB
```

build 1011

## VEHICLE_SET_OVERRIDE_EXTENABLE_SIDE_RATIO

```c
int VEHICLE_SET_OVERRIDE_EXTENABLE_SIDE_RATIO(Any p0, Any p1)  // 0x0419B167EE128F33
```

build 1103

## VEHICLE_SET_OVERRIDE_SIDE_RATIO

```c
int VEHICLE_SET_OVERRIDE_SIDE_RATIO(Any p0, Any p1)  // 0xD3E51C0AB8C26EEE
```

build 1103

## VEHICLE_SET_PARACHUTE_MODEL_OVERRIDE

```c
void VEHICLE_SET_PARACHUTE_MODEL_OVERRIDE(Vehicle vehicle, Hash modelHash)  // 0x4D610C6B56031351
```

build 1011 · old names: `_VEHICLE_SET_CUSTOM_PARACHUTE_MODEL`, `_SET_VEHICLE_PARACHUTE_MODEL`

> Parachute models:
> - sr_prop_specraces_para_s_01
> - imp_prop_impexp_para_s (SecuroServ; Default)
> Plus, many more props can be used as vehicle parachutes, like umbrellas (prop_beach_parasol_03), and unlike SET_PLAYER_PARACHUTE_MODEL_OVERRIDE, you won't get stuck mid-air when using an umbrella.

## VEHICLE_SET_PARACHUTE_MODEL_TINT_INDEX

```c
void VEHICLE_SET_PARACHUTE_MODEL_TINT_INDEX(Vehicle vehicle, int textureVariation)  // 0xA74AD2439468C883
```

build 1011 · old names: `_VEHICLE_SET_CUSTOM_PARACHUTE_TEXTURE`, `_SET_VEHICLE_PARACHUTE_TEXTURE_VARIATION`

> Variations available for the generic parachute (sr_prop_specraces_para_s_01):
> - 0: Rainbow
> - 1: Red
> - 2: White, blue, yellow
> - 3: Black, red, white
> - 4: Red, white, blue
> - 5: Blue
> - 6: Black
> - 7: Black, yellow

## VEHICLE_SET_RAMP_AND_RAMMING_CARS_TAKE_DAMAGE

```c
void VEHICLE_SET_RAMP_AND_RAMMING_CARS_TAKE_DAMAGE(Vehicle vehicle, BOOL toggle)  // 0x28D034A93FE31BF5
```

build 944 · old names: `_SET_RAMP_VEHICLE_RECEIVES_RAMP_DAMAGE`, `_SET_VEHICLE_RECEIVES_RAMP_DAMAGE`

## VEHICLE_START_PARACHUTING

```c
void VEHICLE_START_PARACHUTING(Vehicle vehicle, BOOL active)  // 0x0BFFB028B3DD0A97
```

build 944 · old names: `_SET_VEHICLE_PARACHUTE_ACTIVE`

