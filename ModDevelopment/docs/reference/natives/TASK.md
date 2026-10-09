# TASK natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _SET_AMBIENT_PED_ENABLE_COLLISION_ON_NETWORK_CLONE_WHEN_FIXED

```c
void _SET_AMBIENT_PED_ENABLE_COLLISION_ON_NETWORK_CLONE_WHEN_FIXED(Ped ped, BOOL enable)  // 0x0EFE4834A2F40563
```

build 3570

## _SET_SCRIPT_TASK_ENABLE_COLLISION_ON_NETWORK_CLONE_WHEN_FIXED

```c
void _SET_SCRIPT_TASK_ENABLE_COLLISION_ON_NETWORK_CLONE_WHEN_FIXED(Ped ped, BOOL enable)  // 0x32F6EEF031F943DC
```

build 3095

## ADD_COVER_BLOCKING_AREA

```c
void ADD_COVER_BLOCKING_AREA(float startX, float startY, float startZ, float endX, float endY, float endZ, BOOL blockObjects, BOOL blockVehicles, BOOL blockMap, BOOL blockPlayer)  // 0x45C597097DD7CB81
```

build 323

## ADD_COVER_POINT

```c
ScrHandle ADD_COVER_POINT(float x, float y, float z, float direction, int usage, int height, int arc, BOOL isPriority)  // 0xD5C12A75C7B9497F
```

build 323

## ADD_PATROL_ROUTE_LINK

```c
void ADD_PATROL_ROUTE_LINK(int nodeId1, int nodeId2)  // 0x23083260DEC3A551
```

build 323

## ADD_PATROL_ROUTE_NODE

```c
void ADD_PATROL_ROUTE_NODE(int nodeId, const char* nodeType, float posX, float posY, float posZ, float headingX, float headingY, float headingZ, int duration)  // 0x8EDF950167586B7C
```

build 323

> Example: 
> TASK::ADD_PATROL_ROUTE_NODE(2, "WORLD_HUMAN_GUARD_STAND", -193.4915, -2378.864990234375, 10.9719, -193.4915, -2378.864990234375, 10.9719, 3000);
> 
> p0 is between 0 and 4 in the scripts.
> 
> p1 is "WORLD_HUMAN_GUARD_STAND" or "StandGuard".
> 
> p2, p3 and p4 is only one parameter sometimes in the scripts. Most likely a Vector3 hence p2, p3 and p4 are coordinates. 
> Examples: 
> TASK::ADD_PATROL_ROUTE_NODE(1, "WORLD_HUMAN_GUARD_STAND", l_739[7/*3*/], 0.0, 0.0, 0.0, 0);
> 
> TASK::ADD_PATROL_ROUTE_NODE(1, "WORLD_HUMAN_GUARD_STAND", l_B0[17/*44*/]._f3, l_B0[17/*44*/]._f3, 2000);
> 
> p5, p6 and p7 are for example set to: 1599.0406494140625, 2713.392578125, 44.4309.
> 
> p8 is an int, often random set to for example: MISC::GET_RANDOM_INT_IN_RANGE(5000, 10000).

## ADD_SCRIPTED_COVER_AREA

```c
void ADD_SCRIPTED_COVER_AREA(float x, float y, float z, float radius)  // 0x28B7B9BFDAF274AA
```

build 2545 · old names: `_ADD_SCRIPTED_BLOCKING_AREA`

## ADD_VEHICLE_SUBTASK_ATTACK_COORD

```c
void ADD_VEHICLE_SUBTASK_ATTACK_COORD(Ped ped, float x, float y, float z)  // 0x5CF0D8F9BBA0DD75
```

build 323

> x, y, z: offset in world coords from some entity.

## ADD_VEHICLE_SUBTASK_ATTACK_PED

```c
void ADD_VEHICLE_SUBTASK_ATTACK_PED(Ped ped, Ped target)  // 0x85F462BADC7DA47F
```

build 323

## ASSISTED_MOVEMENT_IS_ROUTE_LOADED

```c
BOOL ASSISTED_MOVEMENT_IS_ROUTE_LOADED(const char* route)  // 0x60F9A4393A21F741
```

build 323

## ASSISTED_MOVEMENT_OVERRIDE_LOAD_DISTANCE_THIS_FRAME

```c
void ASSISTED_MOVEMENT_OVERRIDE_LOAD_DISTANCE_THIS_FRAME(float dist)  // 0x13945951E16EF912
```

build 323

## ASSISTED_MOVEMENT_REMOVE_ROUTE

```c
void ASSISTED_MOVEMENT_REMOVE_ROUTE(const char* route)  // 0x3548536485DD792B
```

build 323

## ASSISTED_MOVEMENT_REQUEST_ROUTE

```c
void ASSISTED_MOVEMENT_REQUEST_ROUTE(const char* route)  // 0x817268968605947A
```

build 323

> Routes: "1_FIBStairs", "2_FIBStairs", "3_FIBStairs", "4_FIBStairs", "5_FIBStairs", "5_TowardsFire", "6a_FIBStairs", "7_FIBStairs", "8_FIBStairs", "Aprtmnt_1", "AssAfterLift", "ATM_1", "coroner2", "coroner_stairs", "f5_jimmy1", "fame1", "family5b", "family5c", "Family5d", "family5d", "FIB_Glass1", "FIB_Glass2", "FIB_Glass3", "finaBroute1A", "finalb1st", "finalB1sta", "finalbround", "finalbroute2", "Hairdresser1", "jan_foyet_ft_door", "Jo_3", "Lemar1", "Lemar2", "mansion_1", "Mansion_1", "pols_1", "pols_2", "pols_3", "pols_4", "pols_5", "pols_6", "pols_7", "pols_8", "Pro_S1", "Pro_S1a", "Pro_S2", "Towards_case", "trev_steps", "tunrs1", "tunrs2", "tunrs3", "Wave01457s"

## ASSISTED_MOVEMENT_SET_ROUTE_PROPERTIES

```c
void ASSISTED_MOVEMENT_SET_ROUTE_PROPERTIES(const char* route, int props)  // 0xD5002D78B7162E1B
```

build 323

## CLEAR_DEFAULT_PRIMARY_TASK

```c
void CLEAR_DEFAULT_PRIMARY_TASK(Ped ped)  // 0x6100B3CEFD43452E
```

build 2189

## CLEAR_DRIVEBY_TASK_UNDERNEATH_DRIVING_TASK

```c
void CLEAR_DRIVEBY_TASK_UNDERNEATH_DRIVING_TASK(Ped ped)  // 0xC35B5CDB2824CF69
```

build 323

## CLEAR_PED_SCRIPT_TASK_IF_RUNNING_THREAT_RESPONSE_NON_TEMP_TASK

```c
void CLEAR_PED_SCRIPT_TASK_IF_RUNNING_THREAT_RESPONSE_NON_TEMP_TASK(Ped ped)  // 0xF6DC48E56BE1243A
```

build 3407

## CLEAR_PED_SECONDARY_TASK

```c
void CLEAR_PED_SECONDARY_TASK(Ped ped)  // 0x176CECF6F920D707
```

build 323

## CLEAR_PED_TASKS

```c
void CLEAR_PED_TASKS(Ped ped)  // 0xE1EF3C1216AFF2CD
```

build 323

## CLEAR_PED_TASKS_IMMEDIATELY

```c
void CLEAR_PED_TASKS_IMMEDIATELY(Ped ped)  // 0xAAA34F8A7CB32098
```

build 323

> Immediately stops the pedestrian from whatever it's doing. They stop fighting, animations, etc. they forget what they were doing.

## CLEAR_PRIMARY_VEHICLE_TASK

```c
void CLEAR_PRIMARY_VEHICLE_TASK(Vehicle vehicle)  // 0xDBBC7A2432524127
```

build 1290 · old names: `_CLEAR_VEHICLE_TASKS`

> This native is very useful when switching the player to a ped inside a vehicle that has a task assigned prior to the player switch.
> It is necessary to clear the ped's tasks AND call this native with the vehicle the player is switching into in order to allow the player to control the vehicle after the player switches.

## CLEAR_SEQUENCE_TASK

```c
void CLEAR_SEQUENCE_TASK(int* taskSequenceId)  // 0x3841422E9C488D8C
```

build 323

## CLEAR_VEHICLE_CRASH_TASK

```c
void CLEAR_VEHICLE_CRASH_TASK(Vehicle vehicle)  // 0x53DDC75BC3AC0A90
```

build 1290

## CLOSE_PATROL_ROUTE

```c
void CLOSE_PATROL_ROUTE()  // 0xB043ECA801B8CBC1
```

build 323

## CLOSE_SEQUENCE_TASK

```c
void CLOSE_SEQUENCE_TASK(int taskSequenceId)  // 0x39E72BC99E6360CB
```

build 323

## CONTROL_MOUNTED_WEAPON

```c
BOOL CONTROL_MOUNTED_WEAPON(Ped ped)  // 0xDCFE42068FE0135A
```

build 323

> Forces the ped to use the mounted weapon.
> Returns false if task is not possible.

## CREATE_PATROL_ROUTE

```c
void CREATE_PATROL_ROUTE()  // 0xAF8A443CCC8018DC
```

build 323

## DELETE_PATROL_ROUTE

```c
void DELETE_PATROL_ROUTE(const char* patrolRoute)  // 0x7767DD9D65E91319
```

build 323

> From the b617d scripts:
> 
> TASK::DELETE_PATROL_ROUTE("miss_merc0");
> TASK::DELETE_PATROL_ROUTE("miss_merc1");
> TASK::DELETE_PATROL_ROUTE("miss_merc2");
> TASK::DELETE_PATROL_ROUTE("miss_dock");

## DOES_SCENARIO_EXIST_IN_AREA

```c
BOOL DOES_SCENARIO_EXIST_IN_AREA(float x, float y, float z, float radius, BOOL mustBeFree)  // 0x5A59271FFADD33C1
```

build 323

## DOES_SCENARIO_GROUP_EXIST

```c
BOOL DOES_SCENARIO_GROUP_EXIST(const char* scenarioGroup)  // 0xF9034C136C9E00D3
```

build 323

> Full list of scenario groups used in scripts by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenarioGroupNames.json
> Occurrences in the b617d scripts:
> 
> "ARMY_GUARD",
> "ARMY_HELI",
> "Cinema_Downtown",
> "Cinema_Morningwood",
> "Cinema_Textile",
> "City_Banks",
> "Countryside_Banks",
> "DEALERSHIP",
> "GRAPESEED_PLANES",
> "KORTZ_SECURITY",
> "LOST_BIKERS",
> "LSA_Planes",
> "LSA_Planes",
> "MP_POLICE",
> "Observatory_Bikers", 
> "POLICE_POUND1",
> "POLICE_POUND2",
> "POLICE_POUND3",
> "POLICE_POUND4",
> "POLICE_POUND5"
> "QUARRY",
> "SANDY_PLANES",
> "SCRAP_SECURITY",
> "SEW_MACHINE",
> "SOLOMON_GATE",
> "Triathlon_1_Start", 
> "Triathlon_2_Start", 
> "Triathlon_3_Start"
> 
> Sometimes used with IS_SCENARIO_GROUP_ENABLED:
> if (TASK::DOES_SCENARIO_GROUP_EXIST("Observatory_Bikers") && (!TASK::IS_SCENARIO_GROUP_ENABLED("Observatory_Bikers"))) {
> else if (TASK::IS_SCENARIO_GROUP_ENABLED("BLIMP")) {
> 

## DOES_SCENARIO_OF_TYPE_EXIST_IN_AREA

```c
BOOL DOES_SCENARIO_OF_TYPE_EXIST_IN_AREA(float x, float y, float z, const char* scenarioName, float radius, BOOL mustBeFree)  // 0x0A9D0C2A3BBC86C1
```

build 323

## DOES_SCRIPTED_COVER_POINT_EXIST_AT_COORDS

```c
BOOL DOES_SCRIPTED_COVER_POINT_EXIST_AT_COORDS(float x, float y, float z)  // 0xA98B8E3C088E5A31
```

build 323

> Checks if there is a cover point at position

## GET_ACTIVE_VEHICLE_MISSION_TYPE

```c
int GET_ACTIVE_VEHICLE_MISSION_TYPE(Vehicle vehicle)  // 0x534AEBA6E5ED4CAB
```

build 323

> See TASK_VEHICLE_MISSION

## GET_CLIP_SET_FOR_SCRIPTED_GUN_TASK

```c
const char* GET_CLIP_SET_FOR_SCRIPTED_GUN_TASK(int gunTaskType)  // 0x3A8CADC7D37AACC5
```

build 323

## GET_IS_TASK_ACTIVE

```c
BOOL GET_IS_TASK_ACTIVE(Ped ped, int taskType)  // 0xB0760331C7AA4155
```

build 323

> enum class eTaskType
> {
> 	TASK_INVALID_ID                                         = -1,
> 	TASK_HANDS_UP                                           = 0,   // CTaskHandsUp
> 	TASK_CLIMB_LADDER                                       = 1,   // CTaskClimbLadder
> 	TASK_EXIT_VEHICLE                                       = 2,   // CTaskExitVehicle
> 	TASK_COMBAT_ROLL                                        = 3,   // CTaskCombatRoll
> 	TASK_AIM_GUN_ON_FOOT                                    = 4,   // CTaskAimGunOnFoot
> 	TASK_MOVE_PLAYER                                        = 5,   // CTaskMovePlayer
> 	TASK_PLAYER_ON_FOOT                                     = 6,   // CTaskPlayerOnFoot
> 	TASK_PLAYER_ON_HORSE                                    = 7,   // CTaskPlayerOnHorse
> 	TASK_WEAPON                                             = 8,   // CTaskWeapon
> 	TASK_PLAYER_WEAPON                                      = 9,   // CTaskPlayerWeapon
> 	TASK_PLAYER_IDLES                                       = 10,  // CTaskPlayerIdles
> 	TASK_UNINTERRUPTABLE                                    = 13,  // CTaskUninterruptable
> 	TASK_PAUSE                                              = 14,  // CTaskPause
> 	TASK_DO_NOTHING                                         = 15,  // CTaskDoNothing
> 	TASK_GET_UP                                             = 16,  // CTaskGetUp
> 	TASK_GET_UP_AND_STAND_STILL                             = 17,  // CTaskGetUpAndStandStill
> 	TASK_FALL_OVER                                          = 18,  // CTaskFallOver
> 	TASK_FALL_AND_GET_UP                                    = 19,  // CTaskFallAndGetUp
> 	TASK_CRAWL                                              = 20,  // CTaskCrawl
> 	TASK_HIT_RESPONSE                                       = 24,  // CTaskHitResponse
> 	TASK_COMPLEX_ON_FIRE                                    = 25,  // CTaskComplexOnFire
> 	TASK_DAMAGE_ELECTRIC                                    = 26,  // CTaskDamageElectric
> 	TASK_TRIGGER_LOOK_AT                                    = 28,  // CTaskTriggerLookAt
> 	TASK_CLEAR_LOOK_AT                                      = 29,  // CTaskClearLookAt
> 	TASK_SET_CHAR_DECISION_MAKER                            = 30,  // CTaskSetCharDecisionMaker
> 	TASK_SET_PED_DEFENSIVE_AREA                             = 31,  // CTaskSetPedDefensiveArea
> 	TASK_USE_SEQUENCE                                       = 32,  // CTaskUseSequence
> 	TASK_SIMPLE_CONTROL_MOVEMENT                            = 33,  // CTaskComplexControlMovement
> 	TASK_MOVE_STAND_STILL                                   = 34,  // CTaskMoveStandStill
> 	TASK_COMPLEX_CONTROL_MOVEMENT                           = 35,  // CTaskComplexControlMovement
> 	TASK_COMPLEX_MOVE_SEQUENCE                              = 36,  // CTaskMoveSequence
> 	TASK_MOVE_AROUND_COVERPOINTS                            = 37,  // CTaskMoveAroundCoverPoints
> 	TASK_AMBIENT_CLIPS                                      = 38,  // CTaskAmbientClips
> 	TASK_MOVE_IN_AIR                                        = 39,  // CTaskMoveInAir
> 	TASK_NETWORK_CLONE                                      = 40,  // CTaskNetworkClone
> 	TASK_USE_CLIMB_ON_ROUTE                                 = 41,  // CTaskUseClimbOnRoute
> 	TASK_USE_DROPDOWN_ON_ROUTE                              = 42,  // CTaskUseDropDownOnRoute
> 	TASK_USE_LADDER_ON_ROUTE                                = 43,  // CTaskUseLadderOnRoute
> 	TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS               = 44,  // CTaskSetBlockingOfNonTemporaryEvents
> 	TASK_FORCE_MOTION_STATE                                 = 45,  // CTaskForceMotionState
> 	TASK_ON_FOOT_SLOPE_SCRAMBLE                             = 46,  // CTaskSlopeScramble
> 	TASK_GO_TO_AND_CLIMB_LADDER                             = 47,  // CTaskGoToAndClimbLadder
> 	TASK_CLIMB_LADDER_FULLY                                 = 48,  // CTaskClimbLadderFully
> 	TASK_RAPPEL                                             = 49,  // CTaskRappel
> 	TASK_VAULT                                              = 50,  // CTaskVault
> 	TASK_DROP_DOWN                                          = 51,  // CTaskDropDown
> 	TASK_AFFECT_SECONDARY_BEHAVIOUR                         = 52,  // CTaskAffectSecondaryBehaviour
> 	TASK_AMBIENT_LOOK_AT_EVENT                              = 53,  // CTaskAmbientLookAtEvent
> 	TASK_OPEN_DOOR                                          = 54,  // CTaskOpenDoor
> 	TASK_SHOVE_PED                                          = 55,  // CTaskShovePed
> 	TASK_SWAP_WEAPON                                        = 56,  // CTaskSwapWeapon
> 	TASK_GENERAL_SWEEP                                      = 57,  // CTaskGeneralSweep
> 	TASK_POLICE                                             = 58,  // CTaskPolice
> 	TASK_POLICE_ORDER_RESPONSE                              = 59,  // CTaskPoliceOrderResponse
> 	TASK_PURSUE_CRIMINAL                                    = 60,  // CTaskPursueCriminal
> 	TASK_ARREST_PED                                         = 62,  // CTaskArrestPed
> 	TASK_ARREST_PED2                                        = 63,  // CTaskArrestPed2
> 	TASK_BUSTED                                             = 64,  // CTaskBusted
> 	TASK_FIRE_PATROL                                        = 65,  // CTaskFirePatrol
> 	TASK_HELI_ORDER_RESPONSE                                = 66,  // CTaskHeliOrderResponse
> 	TASK_HELI_PASSENGER_RAPPEL                              = 67,  // CTaskHeliPassengerRappel
> 	TASK_AMBULANCE_PATROL                                   = 68,  // CTaskAmbulancePatrol
> 	TASK_POLICE_WANTED_RESPONSE                             = 69,  // CTaskPoliceWantedResponse
> 	TASK_SWAT                                               = 70,  // CTaskSwat
> 	TASK_SWAT_WANTED_RESPONSE                               = 72,  // CTaskSwatWantedResponse
> 	TASK_SWAT_ORDER_RESPONSE                                = 73,  // CTaskSwatOrderResponse
> 	TASK_SWAT_GO_TO_STAGING_AREA                            = 74,  // CTaskSwatGoToStagingArea
> 	TASK_SWAT_FOLLOW_IN_LINE                                = 75,  // CTaskSwatFollowInLine
> 	TASK_WITNESS                                            = 76,  // CTaskWitness
> 	TASK_GANG_PATROL                                        = 77,  // CTaskGangPatrol
> 	TASK_ARMY                                               = 78,  // CTaskArmy
> 	TASK_SHOCKING_EVENT_WATCH                               = 80,  // CTaskShockingEventWatch
> 	TASK_SHOCKING_EVENT_GOTO                                = 82,  // CTaskShockingEventGoto
> 	TASK_SHOCKING_EVENT_HURRYAWAY                           = 83,  // CTaskShockingEventHurryAway
> 	TASK_SHOCKING_EVENT_REACT_TO_AIRCRAFT                   = 84,  // CTaskShockingEventReactToAircraft
> 	TASK_SHOCKING_EVENT_REACT                               = 85,  // CTaskShockingEventReact
> 	TASK_SHOCKING_EVENT_BACK_AWAY                           = 86,  // CTaskShockingEventBackAway
> 	TASK_SHOCKING_POLICE_INVESTIGATE                        = 87,  // CTaskShockingPoliceInvestigate
> 	TASK_SHOCKING_EVENT_STOP_AND_STARE                      = 88,  // CTaskShockingEventStopAndStare
> 	TASK_SHOCKING_NICE_CAR_PICTURE                          = 89,  // CTaskShockingNiceCarPicture
> 	TASK_SHOCKING_EVENT_THREAT_RESPONSE                     = 90,  // CTaskShockingEventThreatResponse
> 	TASK_PUT_ON_HELMET                                      = 91,  // CTaskPutOnHelmet
> 	TASK_TAKE_OFF_HELMET                                    = 92,  // CTaskTakeOffHelmet
> 	TASK_CAR_REACT_TO_VEHICLE_COLLISION                     = 93,  // CTaskCarReactToVehicleCollision
> 	TASK_REACT_TO_RUNNING_PED_OVER                          = 94,  // CTaskReactToRanPedOver
> 	TASK_CAR_REACT_TO_VEHICLE_COLLISION_GET_OUT             = 95,  // CTaskCarReactToVehicleCollisionGetOut
> 	TASK_DYING_DEAD                                         = 97,  // CTaskDyingDead
> 	TASK_PARKED_VEHICLE_SCENARIO                            = 99,  // CTaskParkedVehicleScenario
> 	TASK_WANDERING_SCENARIO                                 = 100, // CTaskWanderingScenario
> 	TASK_WANDERING_IN_RADIUS_SCENARIO                       = 101, // CTaskWanderingInRadiusScenario
> 	TASK_MOVE_BETWEEN_POINTS_SCENARIO                       = 103, // CTaskMoveBetweenPointsScenario
> 	TASK_CHAT_SCENARIO                                      = 104, // CTaskChatScenario
> 	TASK_COWER_SCENARIO                                     = 106, // CTaskCowerScenario
> 	TASK_DEAD_BODY_SCENARIO                                 = 107, // CTaskDeadBodyScenario
> 	TASK_SAY_AUDIO                                          = 114, // CTaskSayAudio
> 	TASK_WAIT_FOR_STEPPING_OUT                              = 116, // CTaskWaitForSteppingOut
> 	TASK_COUPLE_SCENARIO                                    = 117, // CTaskCoupleScenario
> 	TASK_USE_SCENARIO                                       = 118, // CTaskUseScenario
> 	TASK_USE_VEHICLE_SCENARIO                               = 119, // CTaskUseVehicleScenario
> 	TASK_UNALERTED                                          = 120, // CTaskUnalerted
> 	TASK_STEAL_VEHICLE                                      = 121, // CTaskStealVehicle
> 	TASK_REACT_TO_PURSUIT                                   = 122, // CTaskReactToPursuit
> 	TASK_RUN_CLIP                                           = 123, // CTaskRunClip
> 	TASK_RUN_NAMED_CLIP                                     = 124, // CTaskRunNamedClip
> 	TASK_HIT_WALL                                           = 125, // CTaskHitWall
> 	TASK_COWER                                              = 126, // CTaskCower
> 	TASK_CROUCH                                             = 127, // CTaskCrouch
> 	TASK_MELEE                                              = 128, // CTaskMelee
> 	TASK_MOVE_MELEE_MOVEMENT                                = 129, // CTaskMoveMeleeMovement
> 	TASK_MELEE_ACTION_RESULT                                = 130, // CTaskMeleeActionResult
> 	TASK_MELEE_UPPERBODY_ANIM                               = 131, // CTaskMeleeUpperbodyAnims
> 	TASK_MELEE_UNINTERRUPTABLE                              = 132, // CTaskMeleeUninterruptable
> 	TASK_MOVE_SCRIPTED                                      = 133, // CTaskMoVEScripted
> 	TASK_SCRIPTED_ANIMATION                                 = 134, // CTaskScriptedAnimation
> 	TASK_SYNCHRONIZED_SCENE                                 = 135, // CTaskSynchronizedScene
> 	TASK_REACH_ARM                                          = 136, // CTaskReachArm
> 	TASK_COMPLEX_EVASIVE_STEP                               = 137, // CTaskComplexEvasiveStep
> 	TASK_MOVE_WANDER_AROUND_VEHICLE                         = 138, // CTaskWalkRoundCarWhileWandering
> 	TASK_WALK_ROUND_FIRE                                    = 139, // CTaskWalkRoundFire
> 	TASK_COMPLEX_STUCK_IN_AIR                               = 140, // CTaskComplexStuckInAir
> 	TASK_WALK_ROUND_ENTITY                                  = 141, // CTaskWalkRoundEntity
> 	TASK_MOVE_WALK_ROUND_VEHICLE                            = 142, // CTaskMoveWalkRoundVehicle
> 	TASK_MOVE_WALK_ROUND_VEHICLE_DOOR                       = 143, // CTaskWalkRoundVehicleDoor
> 	TASK_REACT_TO_GUN_AIMED_AT                              = 144, // CTaskReactToGunAimedAt
> 	TASK_ON_FOOT_DUCK_AND_COVER                             = 146, // CTaskDuckAndCover
> 	TASK_AGGRESSIVE_RUBBERNECK                              = 147, // CTaskAggressiveRubberneck
> 	TASK_IN_VEHICLE_BASIC                                   = 150, // CTaskInVehicleBasic
> 	TASK_CAR_DRIVE_WANDER                                   = 151, // CTaskCarDriveWander
> 	TASK_LEAVE_ANY_CAR                                      = 152, // CTaskLeaveAnyCar
> 	TASK_COMPLEX_GET_OFF_BOAT                               = 153, // CTaskComplexGetOffBoat
> 	TASK_CAR_DRIVE_POINT_ROUTE                              = 154, // CTaskDrivePointRoute
> 	TASK_CAR_SET_TEMP_ACTION                                = 155, // CTaskCarSetTempAction
> 	TASK_BRING_VEHICLE_TO_HALT                              = 156, // CTaskBringVehicleToHalt
> 	TASK_CAR_DRIVE                                          = 157, // CTaskCarDrive
> 	TASK_PLAYER_DRIVE                                       = 159, // CTaskPlayerDrive
> 	TASK_ENTER_VEHICLE                                      = 160, // CTaskEnterVehicle
> 	TASK_ENTER_VEHICLE_ALIGN                                = 161, // CTaskEnterVehicleAlign
> 	TASK_OPEN_VEHICLE_DOOR_FROM_OUTSIDE                     = 162, // CTaskOpenVehicleDoorFromOutside
> 	TASK_ENTER_VEHICLE_SEAT                                 = 163, // CTaskEnterVehicleSeat
> 	TASK_CLOSE_VEHICLE_DOOR_FROM_INSIDE                     = 164, // CTaskCloseVehicleDoorFromInside
> 	TASK_IN_VEHICLE_SEAT_SHUFFLE                            = 165, // CTaskInVehicleSeatShuffle
> 	TASK_OPEN_VEHICLE_DOOR_FROM_INSIDE                      = 166, // CTaskOpenVehicleDoorFromInside
> 	TASK_EXIT_VEHICLE_SEAT                                  = 167, // CTaskExitVehicleSeat
> 	TASK_CLOSE_VEHICLE_DOOR_FROM_OUTSIDE                    = 168, // CTaskCloseVehicleDoorFromOutside
> 	TASK_CONTROL_VEHICLE                                    = 169, // CTaskControlVehicle
> 	TASK_MOTION_IN_AUTOMOBILE                               = 170, // CTaskMotionInAutomobile
> 	TASK_MOTION_ON_BICYCLE                                  = 171, // CTaskMotionOnBicycle
> 	TASK_MOTION_ON_BICYCLE_CONTROLLER                       = 172, // CTaskMotionOnBicycleController
> 	TASK_MOTION_IN_VEHICLE                                  = 173, // CTaskMotionInVehicle
> 	TASK_MOTION_IN_TURRET                                   = 174, // CTaskMotionInTurret
> 	TASK_REACT_TO_BEING_JACKED                              = 175, // CTaskReactToBeingJacked
> 	TASK_REACT_TO_BEING_ASKED_TO_LEAVE_VEHICLE              = 176, // CTaskReactToBeingAskedToLeaveVehicle
> 	TASK_TRY_TO_GRAB_VEHICLE_DOOR                           = 177, // CTaskTryToGrabVehicleDoor
> 	TASK_GET_ON_TRAIN                                       = 178, // CTaskGetOnTrain
> 	TASK_GET_OFF_TRAIN                                      = 179, // CTaskGetOffTrain
> 	TASK_RIDE_TRAIN                                         = 180, // CTaskRideTrain
> 	TASK_MOUNT_THROW_PROJECTILE                             = 190, // CTaskMountThrowProjectile
> 	TASK_GO_TO_CAR_DOOR_AND_STAND_STILL                     = 195, // CTaskGoToCarDoorAndStandStill
> 	TASK_MOVE_GO_TO_VEHICLE_DOOR                            = 196, // CTaskMoveGoToVehicleDoor
> 	TASK_SET_PED_IN_VEHICLE                                 = 197, // CTaskSetPedInVehicle
> 	TASK_SET_PED_OUT_OF_VEHICLE                             = 198, // CTaskSetPedOutOfVehicle
> 	TASK_VEHICLE_MOUNTED_WEAPON                             = 199, // CTaskVehicleMountedWeapon
> 	TASK_VEHICLE_GUN                                        = 200, // CTaskVehicleGun
> 	TASK_VEHICLE_PROJECTILE                                 = 201, // CTaskVehicleProjectile
> 	TASK_SMASH_CAR_WINDOW                                   = 204, // CTaskSmashCarWindow
> 	TASK_MOVE_GO_TO_POINT                                   = 205, // CTaskMoveGoToPoint
> 	TASK_MOVE_ACHIEVE_HEADING                               = 206, // CTaskMoveAchieveHeading
> 	TASK_MOVE_FACE_TARGET                                   = 207, // CTaskMoveFaceTarget
> 	TASK_MOVE_GO_TO_POINT_AND_STAND_STILL                   = 208, // CTaskMoveGoToPointAndStandStill
> 	TASK_MOVE_FOLLOW_POINT_ROUTE                            = 209, // CTaskMoveFollowPointRoute
> 	TASK_MOVE_SEEK_ENTITY_STANDARD                          = 210, // TTaskMoveSeekEntityStandard
> 	TASK_MOVE_SEEK_ENTITY_LAST_NAV_MESH_INTERSECTION        = 211, // TTaskMoveSeekEntityLastNavMeshIntersection
> 	TASK_MOVE_SEEK_ENTITY_OFFSET_ROTATE                     = 212, // TTaskMoveSeekEntityXYOffsetRotated
> 	TASK_MOVE_SEEK_ENTITY_OFFSET_FIXED                      = 213, // TTaskMoveSeekEntityXYOffsetFixed
> 	TASK_MOVE_SEEK_ENTITY_RADIUS_ANGLE                      = 214, // TTaskMoveSeekEntityRadiusAngleOffset
> 	TASK_EXHAUSTED_FLEE                                     = 215, // CTaskExhaustedFlee
> 	TASK_GROWL_AND_FLEE                                     = 216, // CTaskGrowlAndFlee
> 	TASK_SCENARIO_FLEE                                      = 217, // CTaskScenarioFlee
> 	TASK_SMART_FLEE                                         = 218, // CTaskSmartFlee
> 	TASK_FLY_AWAY                                           = 219, // CTaskFlyAway
> 	TASK_WALK_AWAY                                          = 220, // CTaskWalkAway
> 	TASK_WANDER                                             = 221, // CTaskWander
> 	TASK_WANDER_IN_AREA                                     = 222, // CTaskWanderInArea
> 	TASK_FOLLOW_LEADER_IN_FORMATION                         = 223, // CTaskFollowLeaderInFormation
> 	TASK_GO_TO_POINT_ANY_MEANS                              = 224, // CTaskGoToPointAnyMeans
> 	TASK_COMPLEX_TURN_TO_FACE_ENTITY                        = 225, // CTaskTurnToFaceEntityOrCoord
> 	TASK_FOLLOW_LEADER_ANY_MEANS                            = 226, // CTaskFollowLeaderAnyMeans
> 	TASK_FLY_TO_POINT                                       = 228, // CTaskFlyToPoint
> 	TASK_FLYING_WANDER                                      = 229, // CTaskFlyingWander
> 	TASK_GO_TO_POINT_AIMING                                 = 230, // CTaskGoToPointAiming
> 	TASK_GO_TO_SCENARIO                                     = 231, // CTaskGoToScenario
> 	TASK_FOLLOW_PATROL_ROUTE                                = 232, // CTaskFollowPatrolRoute
> 	TASK_SEEK_ENTITY_AIMING                                 = 233, // CTaskSeekEntityAiming
> 	TASK_SLIDE_TO_COORD                                     = 234, // CTaskSlideToCoord
> 	TASK_SWIMMING_WANDER                                    = 235, // CTaskSwimmingWander
> 	TASK_MOVE_TRACKING_ENTITY                               = 237, // CTaskMoveTrackingEntity
> 	TASK_MOVE_FOLLOW_NAVMESH                                = 238, // CTaskMoveFollowNavMesh
> 	TASK_MOVE_GO_TO_POINT_ON_ROUTE                          = 239, // CTaskMoveGoToPointOnRoute
> 	TASK_ESCAPE_BLAST                                       = 240, // CTaskEscapeBlast
> 	TASK_MOVE_WANDER                                        = 241, // CTaskMoveWander
> 	TASK_MOVE_BE_IN_FORMATION                               = 242, // CTaskMoveBeInFormation
> 	TASK_MOVE_CROWD_AROUND_LOCATION                         = 243, // CTaskMoveCrowdAroundLocation
> 	TASK_MOVE_CROSS_ROAD_AT_TRAFFIC_LIGHTS                  = 244, // CTaskMoveCrossRoadAtTrafficLights
> 	TASK_MOVE_WAIT_FOR_TRAFFIC                              = 245, // CTaskMoveWaitForTraffic
> 	TASK_MOVE_GOTO_POINT_STAND_STILL_ACHIEVE_HEADING        = 246, // CTaskMoveGoToPointStandStillAchieveHeading
> 	TASK_MOVE_WAIT_FOR_NAVMESH_SPECIAL_ACTION_EVENT         = 247, // CTaskMoveWaitForNavMeshSpecialActionEvent
> 	TASK_MOVE_GOTO_SAFE_POSITION_ON_NAVMESH                 = 248, // CTasMoveGoToSafePositionOnNavMesh
> 	TASK_MOVE_RETURN_TO_ROUTE                               = 249, // CTaskMoveReturnToRoute
> 	TASK_MOVE_GOTO_SHELTER_AND_WAIT                         = 250, // CTaskMoveGoToShelterAndWait
> 	TASK_MOVE_GET_ONTO_MAIN_NAVMESH                         = 251, // CTaskMoveGetOntoMainNavMesh
> 	TASK_MOVE_SLIDE_TO_COORD                                = 252, // CTaskMoveSlideToCoord
> 	TASK_MOVE_GOTO_POINT_RELATIVE_TO_ENTITY_AND_STAND_STILL = 253, // CTaskMoveGoToPointRelativeToEntityAndStandStill
> 	TASK_HELICOPTER_STRAFE                                  = 254, // CTaskHelicopterStrafe
> 	TASK_COMPLEX_USE_MOBILE_PHONE_AND_MOVEMENT              = 255, // CTaskComplexUseMobilePhoneAndMovement
> 	TASK_GET_OUT_OF_WATER                                   = 256, // CTaskGetOutOfWater
> 	TASK_MOVE_FOLLOW_ENTITY_OFFSET                          = 259, // CTaskMoveFollowEntityOffset
> 	TASK_FOLLOW_WAYPOINT_RECORDING                          = 261, // CTaskFollowWaypointRecording
> 	TASK_GENERIC_MOVE_TO_POINT                              = 263, // CTaskGenericMoveToPoint
> 	TASK_MOTION_PED                                         = 264, // CTaskMotionPed
> 	TASK_MOTION_PED_LOW_LOD                                 = 265, // CTaskMotionPedLowLod
> 	TASK_MOTION_BASIC_LOCOMOTION                            = 267, // CTaskMotionBasicLocomotion
> 	TASK_HUMAN_LOCOMOTION                                   = 268, // CTaskHumanLocomotion
> 	TASK_MOTION_BASIC_LOCOMOTION_LOW_LOD                    = 269, // CTaskMotionBasicLocomotionLowLod
> 	TASK_MOTION_STRAFING                                    = 270, // CTaskMotionStrafing
> 	TASK_MOTION_TENNIS                                      = 271, // CTaskMotionTennis
> 	TASK_MOTION_AIMING                                      = 272, // CTaskMotionAiming
> 	TASK_ON_FOOT_BIRD                                       = 273, // CTaskBirdLocomotion
> 	TASK_ON_FOOT_FLIGHTLESS_BIRD                            = 274, // CTaskFlightlessBirdLocomotion
> 	TASK_ON_FOOT_FISH                                       = 278, // CTaskFishLocomotion
> 	TASK_ON_FOOT_QUAD                                       = 279, // CTaskQuadLocomotion
> 	TASK_MOTION_DIVING                                      = 280, // CTaskMotionDiving
> 	TASK_MOTION_SWIMMING                                    = 281, // CTaskMotionSwimming
> 	TASK_MOTION_PARACHUTING                                 = 282, // CTaskMotionParachuting
> 	TASK_MOTION_DRUNK                                       = 283, // CTaskMotionDrunk
> 	TASK_REPOSITION_MOVE                                    = 284, // CTaskRepositionMove
> 	TASK_MOTION_AIMING_TRANSITION                           = 285, // CTaskMotionAimingTransition
> 	TASK_THROW_PROJECTILE                                   = 286, // CTaskThrowProjectile
> 	TASK_COVER                                              = 287, // CTaskCover
> 	TASK_MOTION_IN_COVER                                    = 288, // CTaskMotionInCover
> 	TASK_AIM_AND_THROW_PROJECTILE                           = 289, // CTaskAimAndThrowProjectile
> 	TASK_GUN                                                = 290, // CTaskGun
> 	TASK_AIM_FROM_GROUND                                    = 291, // CTaskAimFromGround
> 	TASK_AIM_GUN_VEHICLE_DRIVE_BY                           = 295, // CTaskAimGunVehicleDriveBy
> 	TASK_AIM_GUN_SCRIPTED                                   = 296, // CTaskAimGunScripted
> 	TASK_RELOAD_GUN                                         = 298, // CTaskReloadGun
> 	TASK_WEAPON_BLOCKED                                     = 299, // CTaskWeaponBlocked
> 	TASK_ENTER_COVER                                        = 300, // CTaskEnterCover
> 	TASK_EXIT_COVER                                         = 301, // CTaskExitCover
> 	TASK_AIM_GUN_FROM_COVER_INTRO                           = 302, // CTaskAimGunFromCoverIntro
> 	TASK_AIM_GUN_FROM_COVER_OUTRO                           = 303, // CTaskAimGunFromCoverOutro
> 	TASK_AIM_GUN_BLIND_FIRE                                 = 304, // CTaskAimGunBlindFire
> 	TASK_COMBAT_CLOSEST_TARGET_IN_AREA                      = 307, // CTaskCombatClosestTargetInArea
> 	TASK_ADDITIONAL_COMBAT_TASK                             = 308, // CTaskCombatAdditionalTask
> 	TASK_IN_COVER                                           = 309, // CTaskInCover
> 	TASK_AIM_SWEEP                                          = 313, // CTaskAimSweep
> 	TASK_ARREST                                             = 314, // CTaskArrest
> 	TASK_CUFFED                                             = 315, // CTaskCuffed
> 	TASK_IN_CUSTODY                                         = 316, // CTaskInCustody
> 	TASK_INCAPACITATED                                      = 317, // CTaskIncapacitated
> 	TASK_PLAY_CUFFED_SECONDARY_ANIMS                        = 318, // CTaskPlayCuffedSecondaryAnims
> 	TASK_SHARK_CIRCLE                                       = 319, // CTaskSharkCircle
> 	TASK_SHARK_ATTACK                                       = 320, // CTaskSharkAttack
> 	TASK_AGITATED                                           = 321, // CTaskAgitated
> 	TASK_AGITATED_ACTION                                    = 322, // CTaskAgitatedAction
> 	TASK_CONFRONT                                           = 323, // CTaskConfront
> 	TASK_INTIMIDATE                                         = 324, // CTaskIntimidate
> 	TASK_SHOVE                                              = 325, // CTaskShove
> 	TASK_SHOVED                                             = 326, // CTaskShoved
> 	TASK_CROUCH_TOGGLE                                      = 328, // CTaskCrouchToggle
> 	TASK_REVIVE                                             = 329, // CTaskRevive
> 	TASK_COMPLEX_USE_MOBILE_PHONE                           = 331, // CTaskComplexUseMobilePhone
> 	TASK_PARACHUTE                                          = 335, // CTaskParachute
> 	TASK_PARACHUTE_OBJECT                                   = 336, // CTaskParachuteObject
> 	TASK_TAKE_OFF_PED_VARIATION                             = 337, // CTaskTakeOffPedVariation
> 	TASK_COMBAT_SEEK_COVER                                  = 340, // CTaskCombatSeekCover
> 	TASK_COMBAT_CHARGE                                      = 341, // CTaskCombatChargeSubtask
> 	TASK_COMBAT_FLANK                                       = 342, // CTaskCombatFlank
> 	TASK_COMBAT                                             = 343, // CTaskCombat
> 	TASK_COMBAT_MOUNTED                                     = 344, // CTaskCombatMounted
> 	TASK_MOVE_CIRCLE                                        = 345, // CTaskMoveCircle
> 	TASK_MOVE_COMBAT_MOUNTED                                = 346, // CTaskMoveCombatMounted
> 	TASK_SEARCH                                             = 347, // CTaskSearch
> 	TASK_SEARCH_ON_FOOT                                     = 348, // CTaskSearchOnFoot
> 	TASK_SEARCH_IN_AUTOMOBILE                               = 349, // CTaskSearchInAutomobile
> 	TASK_SEARCH_IN_BOAT                                     = 350, // CTaskSearchInBoat
> 	TASK_SEARCH_IN_HELI                                     = 351, // CTaskSearchInHeli
> 	TASK_THREAT_RESPONSE                                    = 352, // CTaskThreatResponse
> 	TASK_INVESTIGATE                                        = 353, // CTaskInvestigate
> 	TASK_STAND_GUARD_FSM                                    = 354, // CTaskStandGuardFSM
> 	TASK_PATROL                                             = 355, // CTaskPatrol
> 	TASK_SHOOT_AT_TARGET                                    = 356, // CTaskShootAtTarget
> 	TASK_SET_AND_GUARD_AREA                                 = 357, // CTaskSetAndGuardArea
> 	TASK_STAND_GUARD                                        = 358, // CTaskStandGuard
> 	TASK_SEPARATE                                           = 359, // CTaskSeparate
> 	TASK_STAY_IN_COVER                                      = 360, // CTaskStayInCover
> 	TASK_VEHICLE_COMBAT                                     = 361, // CTaskVehicleCombat
> 	TASK_VEHICLE_PERSUIT                                    = 362, // CTaskVehiclePersuit
> 	TASK_VEHICLE_CHASE                                      = 363, // CTaskVehicleChase
> 	TASK_DRAGGING_TO_SAFETY                                 = 364, // CTaskDraggingToSafety
> 	TASK_DRAGGED_TO_SAFETY                                  = 365, // CTaskDraggedToSafety
> 	TASK_VARIED_AIM_POSE                                    = 366, // CTaskVariedAimPose
> 	TASK_MOVE_WITHIN_ATTACK_WINDOW                          = 367, // CTaskMoveWithinAttackWindow
> 	TASK_MOVE_WITHIN_DEFENSIVE_AREA                         = 368, // CTaskMoveWithinDefensiveArea
> 	TASK_SHOOT_OUT_TIRE                                     = 369, // CTaskShootOutTire
> 	TASK_SHELL_SHOCKED                                      = 370, // CTaskShellShocked
> 	TASK_BOAT_CHASE                                         = 371, // CTaskBoatChase
> 	TASK_BOAT_COMBAT                                        = 372, // CTaskBoatCombat
> 	TASK_BOAT_STRAFE                                        = 373, // CTaskBoatStrafe
> 	TASK_HELI_CHASE                                         = 374, // CTaskHeliChase
> 	TASK_HELI_COMBAT                                        = 375, // CTaskHeliCombat
> 	TASK_SUBMARINE_COMBAT                                   = 376, // CTaskSubmarineCombat
> 	TASK_SUBMARINE_CHASE                                    = 377, // CTaskSubmarineChase
> 	TASK_PLANE_CHASE                                        = 378, // CTaskPlaneChase
> 	TASK_TARGET_UNREACHABLE                                 = 379, // CTaskTargetUnreachable
> 	TASK_TARGET_UNREACHABLE_IN_INTERIOR                     = 380, // CTaskTargetUnreachableInInterior
> 	TASK_TARGET_UNREACHABLE_IN_EXTERIOR                     = 381, // CTaskTargetUnreachableInExterior
> 	TASK_STEALTH_KILL                                       = 382, // CTaskStealthKill
> 	TASK_WRITHE                                             = 383, // CTaskWrithe
> 	TASK_ADVANCE                                            = 384, // CTaskAdvance
> 	TASK_CHARGE                                             = 385, // CTaskCharge
> 	TASK_MOVE_TO_TACTICAL_POINT                             = 386, // CTaskMoveToTacticalPoint
> 	TASK_TO_HURT_TRANSIT                                    = 387, // CTaskToHurtTransit
> 	TASK_ANIMATED_HIT_BY_EXPLOSION                          = 388, // CTaskAnimatedHitByExplosion
> 	TASK_NM_RELAX                                           = 389, // CTaskNMRelax
> 	TASK_NM_ROLL_UP_AND_RELAX                               = 390, // CTaskNMRollUpAndRelax
> 	TASK_NM_POSE                                            = 391, // CTaskNMPose
> 	TASK_NM_BRACE                                           = 392, // CTaskNMBrace
> 	TASK_NM_SHOT                                            = 395, // CTaskNMShot
> 	TASK_NM_HIGH_FALL                                       = 396, // CTaskNMHighFall
> 	TASK_NM_BALANCE                                         = 397, // CTaskNMBalance
> 	TASK_NM_ELECTROCUTE                                     = 398, // CTaskNMElectrocute
> 	TASK_NM_EXPLOSION                                       = 400, // CTaskNMExplosion
> 	TASK_NM_ONFIRE                                          = 401, // CTaskNMOnFire
> 	TASK_NM_SCRIPT_CONTROL                                  = 402, // CTaskNMScriptControl
> 	TASK_NM_JUMP_ROLL_FROM_ROAD_VEHICLE                     = 403, // CTaskNMJumpRollFromRoadVehicle
> 	TASK_NM_FLINCH                                          = 404, // CTaskNMFlinch
> 	TASK_NM_SIT                                             = 405, // CTaskNMSit
> 	TASK_NM_FALL_DOWN                                       = 406, // CTaskNMFallDown
> 	TASK_BLEND_FROM_NM                                      = 407, // CTaskBlendFromNM
> 	TASK_NM_CONTROL                                         = 408, // CTaskNMControl
> 	TASK_NM_DANGLE                                          = 409, // CTaskNMDangle
> 	TASK_NM_SLUNG_OVER_SHOULDER                             = 410, // CTaskNMSlungOverShoulder
> 	TASK_NM_GENERIC_ATTACH                                  = 412, // CTaskNMGenericAttach
> 	TASK_NM_DRUNK                                           = 413, // CTaskNMDrunk
> 	TASK_NM_DRAGGING_TO_SAFETY                              = 414, // CTaskNMDraggingToSafety
> 	TASK_NM_THROUGH_WINDSCREEN                              = 415, // CTaskNMThroughWindscreen
> 	TASK_NM_SIMPLE                                          = 417, // CTaskNMSimple
> 	TASK_RAGE_RAGDOLL                                       = 418, // CTaskRageRagdoll
> 	TASK_JUMPVAULT                                          = 421, // CTaskJumpVault
> 	TASK_JUMP                                               = 422, // CTaskJump
> 	TASK_FALL                                               = 423, // CTaskFall
> 	TASK_REACT_AIM_WEAPON                                   = 425, // CTaskReactAimWeapon
> 	TASK_CHAT                                               = 426, // CTaskChat
> 	TASK_MOBILE_PHONE                                       = 427, // CTaskMobilePhone
> 	TASK_REACT_TO_DEAD_PED                                  = 428, // CTaskReactToDeadPed
> 	TASK_WATCH_INVESTIGATION                                = 429, // CTaskWatchInvestigation
> 	TASK_SEARCH_FOR_UNKNOWN_THREAT                          = 430, // CTaskSearchForUnknownThreat
> 	TASK_CHECK_PED_IS_DEAD                                  = 431, // CTaskCheckPedIsDead
> 	TASK_BOMB                                               = 432, // CTaskBomb
> 	TASK_DETONATOR                                          = 433, // CTaskDetonator
> 	TASK_ANIMATED_ATTACH                                    = 435, // CTaskAnimatedAttach
> 	TASK_CUTSCENE                                           = 441, // CTaskCutScene
> 	TASK_REACT_TO_EXPLOSION                                 = 442, // CTaskReactToExplosion
> 	TASK_REACT_TO_IMMINENT_EXPLOSION                        = 443, // CTaskReactToImminentExplosion
> 	TASK_DIVE_TO_GROUND                                     = 444, // CTaskDiveToGround
> 	TASK_REACT_AND_FLEE                                     = 445, // CTaskReactAndFlee
> 	TASK_SIDESTEP                                           = 446, // CTaskSidestep
> 	TASK_CALL_POLICE                                        = 447, // CTaskCallPolice
> 	TASK_REACT_IN_DIRECTION                                 = 448, // CTaskReactInDirection
> 	TASK_REACT_TO_BUDDY_SHOT                                = 449, // CTaskReactToBuddyShot
> 	TASK_VEHICLE_GOTO                                       = 453, // CTaskVehicleGoTo
> 	TASK_VEHICLE_GOTO_AUTOMOBILE_NEW                        = 454, // CTaskVehicleGoToAutomobileNew
> 	TASK_VEHICLE_GOTO_PLANE                                 = 455, // CTaskVehicleGoToPlane
> 	TASK_VEHICLE_GOTO_HELICOPTER                            = 456, // CTaskVehicleGoToHelicopter
> 	TASK_VEHICLE_GOTO_SUBMARINE                             = 457, // CTaskVehicleGoToSubmarine
> 	TASK_VEHICLE_GOTO_BOAT                                  = 458, // CTaskVehicleGoToBoat
> 	TASK_VEHICLE_GOTO_POINT_AUTOMOBILE                      = 459, // CTaskVehicleGoToPointAutomobile
> 	TASK_VEHICLE_GOTO_POINT_WITH_AVOIDANCE_AUTOMOBILE       = 460, // CTaskVehicleGoToPointWithAvoidanceAutomobile
> 	TASK_VEHICLE_PURSUE                                     = 461, // CTaskVehiclePursue
> 	TASK_VEHICLE_RAM                                        = 462, // CTaskVehicleRam
> 	TASK_VEHICLE_SPIN_OUT                                   = 463, // CTaskVehicleSpinOut
> 	TASK_VEHICLE_APPROACH                                   = 464, // CTaskVehicleApproach
> 	TASK_VEHICLE_THREE_POINT_TURN                           = 465, // CTaskVehicleThreePointTurn
> 	TASK_VEHICLE_DEAD_DRIVER                                = 466, // CTaskVehicleDeadDriver
> 	TASK_VEHICLE_CRUISE_NEW                                 = 467, // CTaskVehicleCruiseNew
> 	TASK_VEHICLE_CRUISE_BOAT                                = 468, // CTaskVehicleCruiseBoat
> 	TASK_VEHICLE_STOP                                       = 469, // CTaskVehicleStop
> 	TASK_VEHICLE_PULL_OVER                                  = 470, // CTaskVehiclePullOver
> 	TASK_VEHICLE_FLEE                                       = 472, // CTaskVehicleFlee
> 	TASK_VEHICLE_FLEE_AIRBORNE                              = 473, // CTaskVehicleFleeAirborne
> 	TASK_VEHICLE_FLEE_BOAT                                  = 474, // CTaskVehicleFleeBoat
> 	TASK_VEHICLE_FOLLOW_RECORDING                           = 475, // CTaskVehicleFollowRecording
> 	TASK_VEHICLE_FOLLOW                                     = 476, // CTaskVehicleFollow
> 	TASK_VEHICLE_BLOCK                                      = 477, // CTaskVehicleBlock
> 	TASK_VEHICLE_BLOCK_CRUISE_IN_FRONT                      = 478, // CTaskVehicleBlockCruiseInFront
> 	TASK_VEHICLE_BLOCK_BRAKE_IN_FRONT                       = 479, // CTaskVehicleBlockBrakeInFront
> 	TASK_VEHICLE_BLOCK_BACK_AND_FORTH                       = 480, // CTaskVehicleBlockBackAndForth
> 	TASK_VEHICLE_CRASH                                      = 481, // CTaskVehicleCrash
> 	TASK_VEHICLE_LAND                                       = 482, // CTaskVehicleLand
> 	TASK_VEHICLE_LAND_PLANE                                 = 483, // CTaskVehicleLandPlane
> 	TASK_VEHICLE_HOVER                                      = 484, // CTaskVehicleHover
> 	TASK_VEHICLE_ATTACK                                     = 485, // CTaskVehicleAttack
> 	TASK_VEHICLE_ATTACK_TANK                                = 486, // CTaskVehicleAttackTank
> 	TASK_VEHICLE_CIRCLE                                     = 487, // CTaskVehicleCircle
> 	TASK_VEHICLE_POLICE_BEHAVIOUR                           = 488, // CTaskVehiclePoliceBehaviour
> 	TASK_VEHICLE_ESCORT                                     = 491, // CTaskVehicleEscort
> 	TASK_VEHICLE_HELI_PROTECT                               = 492, // CTaskVehicleHeliProtect
> 	TASK_VEHICLE_PLAYER_DRIVE                               = 493, // CTaskVehiclePlayerDrive
> 	TASK_VEHICLE_PLAYER_DRIVE_AUTOMOBILE                    = 494, // CTaskVehiclePlayerDriveAutomobile
> 	TASK_VEHICLE_PLAYER_DRIVE_BIKE                          = 495, // CTaskVehiclePlayerDriveBike
> 	TASK_VEHICLE_PLAYER_DRIVE_BOAT                          = 496, // CTaskVehiclePlayerDriveBoat
> 	TASK_VEHICLE_PLAYER_DRIVE_SUBMARINE                     = 497, // CTaskVehiclePlayerDriveSubmarine
> 	TASK_VEHICLE_PLAYER_DRIVE_SUBMARINECAR                  = 498, // CTaskVehiclePlayerDriveSubmarineCar
> 	TASK_VEHICLE_PLAYER_DRIVE_AMPHIBIOUS_AUTOMOBILE         = 499, // CTaskVehiclePlayerDriveAmphibiousAutomobile
> 	TASK_VEHICLE_PLAYER_DRIVE_PLANE                         = 500, // CTaskVehiclePlayerDrivePlane
> 	TASK_VEHICLE_PLAYER_DRIVE_HELI                          = 501, // CTaskVehiclePlayerDriveHeli
> 	TASK_VEHICLE_PLAYER_DRIVE_AUTOGYRO                      = 502, // CTaskVehiclePlayerDriveAutogyro
> 	TASK_VEHICLE_PLAYER_DRIVE_DIGGER_ARM                    = 503, // CTaskVehiclePlayerDriveDiggerArm
> 	TASK_VEHICLE_PLAYER_DRIVE_TRAIN                         = 504, // CTaskVehiclePlayerDriveTrain
> 	TASK_VEHICLE_PLANE_CHASE                                = 505, // CTaskVehiclePlaneChase
> 	TASK_VEHICLE_NO_DRIVER                                  = 506, // CTaskVehicleNoDriver
> 	TASK_VEHICLE_ANIMATION                                  = 507, // CTaskVehicleAnimation
> 	TASK_VEHICLE_CONVERTIBLE_ROOF                           = 508, // CTaskVehicleConvertibleRoof
> 	TASK_VEHICLE_PARK_NEW                                   = 509, // CTaskVehicleParkNew
> 	TASK_VEHICLE_FOLLOW_WAYPOINT_RECORDING                  = 510, // CTaskVehicleFollowWaypointRecording
> 	TASK_VEHICLE_GOTO_NAVMESH                               = 511, // CTaskVehicleGoToNavmesh
> 	TASK_VEHICLE_REACT_TO_COP_SIREN                         = 512, // CTaskVehicleReactToCopSiren
> 	TASK_VEHICLE_GOTO_LONGRANGE                             = 513, // CTaskVehicleGotoLongRange
> 	TASK_VEHICLE_WAIT                                       = 514, // CTaskVehicleWait
> 	TASK_VEHICLE_REVERSE                                    = 515, // CTaskVehicleReverse
> 	TASK_VEHICLE_BRAKE                                      = 516, // CTaskVehicleBrake
> 	TASK_VEHICLE_HANDBRAKE                                  = 517, // CTaskVehicleHandBrake
> 	TASK_VEHICLE_TURN                                       = 518, // CTaskVehicleTurn
> 	TASK_VEHICLE_GO_FORWARD                                 = 519, // CTaskVehicleGoForward
> 	TASK_VEHICLE_SWERVE                                     = 520, // CTaskVehicleSwerve
> 	TASK_VEHICLE_FLY_DIRECTION                              = 521, // CTaskVehicleFlyDirection
> 	TASK_VEHICLE_HEADON_COLLISION                           = 522, // CTaskVehicleHeadonCollision
> 	TASK_VEHICLE_BOOST_USE_STEERING_ANGLE                   = 523, // CTaskVehicleBoostUseSteeringAngle
> 	TASK_VEHICLE_SHOT_TIRE                                  = 524, // CTaskVehicleShotTire
> 	TASK_VEHICLE_BURNOUT                                    = 525, // CTaskVehicleBurnout
> 	TASK_VEHICLE_REV_ENGINE                                 = 526, // CTaskVehicleRevEngine
> 	TASK_VEHICLE_SURFACE_IN_SUBMARINE                       = 527, // CTaskVehicleSurfaceInSubmarine
> 	TASK_VEHICLE_PULL_ALONGSIDE                             = 528, // CTaskVehiclePullAlongside
> 	TASK_VEHICLE_TRANSFORM_TO_SUBMARINE                     = 529, // CTaskVehicleTransformToSubmarine
> 	TASK_ANIMATED_FALLBACK                                  = 530, // CTaskAnimatedFallback
> 	MAX_NUM_TASK_TYPES                                      = 531,
> };

## GET_IS_WAYPOINT_RECORDING_LOADED

```c
BOOL GET_IS_WAYPOINT_RECORDING_LOADED(const char* name)  // 0xCB4E8BE8A0063C5D
```

build 323

> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json

## GET_NAVMESH_ROUTE_DISTANCE_REMAINING

```c
int GET_NAVMESH_ROUTE_DISTANCE_REMAINING(Ped ped, float* distanceRemaining, BOOL* isPathReady)  // 0xC6F5C0BCDC74D62D
```

build 323

> Looks like the last parameter returns true if the path has been calculated, while the first returns the remaining distance to the end of the path.
> Return value of native is the same as GET_NAVMESH_ROUTE_RESULT
> Looks like the native returns an int for the path's state:
> 1 - ???
> 2 - ???
> 3 - Finished Generating 

## GET_NAVMESH_ROUTE_RESULT

```c
int GET_NAVMESH_ROUTE_RESULT(Ped ped)  // 0x632E831F382A0FA8
```

build 323

> See GET_NAVMESH_ROUTE_DISTANCE_REMAINING for more details.

## GET_PATROL_TASK_INFO

```c
BOOL GET_PATROL_TASK_INFO(Ped ped, int* timeLeftAtNode, int* nodeId)  // 0x52F734CEBE20DFBA
```

build 2545 · old names: `_GET_PATROL_TASK_STATUS`

## GET_PED_DESIRED_MOVE_BLEND_RATIO

```c
float GET_PED_DESIRED_MOVE_BLEND_RATIO(Ped ped)  // 0x8517D4A6CA8513ED
```

build 323

## GET_PED_WAYPOINT_DISTANCE

```c
float GET_PED_WAYPOINT_DISTANCE(Any p0)  // 0xE6A877C64CAF1BC5
```

build 323

## GET_PED_WAYPOINT_PROGRESS

```c
int GET_PED_WAYPOINT_PROGRESS(Ped ped)  // 0x2720AAA75001E094
```

build 323

## GET_PHONE_GESTURE_ANIM_CURRENT_TIME

```c
float GET_PHONE_GESTURE_ANIM_CURRENT_TIME(Ped ped)  // 0x47619ABE8B268C60
```

build 323

## GET_PHONE_GESTURE_ANIM_TOTAL_TIME

```c
float GET_PHONE_GESTURE_ANIM_TOTAL_TIME(Ped ped)  // 0x1EE0F68A7C25DEC6
```

build 323

## GET_SCRIPT_TASK_STATUS

```c
int GET_SCRIPT_TASK_STATUS(Ped ped, Hash taskHash)  // 0x77F1BEB8863288D5
```

build 323

> Gets the status of a script-assigned task.
> 
> enum ScriptTaskStatus
> {
> 	WAITING_TO_START_TASK = 0,
> 	PERFORMING_TASK,
> 	DORMANT_TASK,
> 	VACANT_STAGE,
> 	GROUP_TASK_STAGE,
> 	ATTRACTOR_SCRIPT_TASK_STAGE,
> 	SECONDARY_TASK_STAGE,
> 	FINISHED_TASK
> };
> 
> enum ScriptTaskTypes : Hash
> {
> 	SCRIPT_TASK_ANY = 0x55966344,
> 	SCRIPT_TASK_INVALID = 0x811E343C,
> 	SCRIPT_TASK_PAUSE = 0x03C990EC,
> 	SCRIPT_TASK_STAND_STILL = 0xC572E06A,
> 	DEPRECATED_SCRIPT_TASK_FALL_AND_GET_UP = 0xA6296C9D,
> 	SCRIPT_TASK_JUMP = 0x24415046,
> 	SCRIPT_TASK_COWER = 0x1C43F4CF,
> 	SCRIPT_TASK_HANDS_UP = 0xA573B67C,
> 	SCRIPT_TASK_DUCK = 0x1D415F6C,
> 	DEPRECATED_SCRIPT_TASK_SCRATCH_HEAD = 0xD9162485,
> 	DEPRECATED_SCRIPT_TASK_LOOK_ABOUT = 0x255F21CC,
> 	SCRIPT_TASK_ENTER_VEHICLE = 0x950B6492,
> 	SCRIPT_TASK_LEAVE_VEHICLE = 0x1AE73569,
> 	SCRIPT_TASK_VEHICLE_DRIVE_TO_COORD = 0x93A5526E,
> 	SCRIPT_TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE = 0x21D33957,
> 	SCRIPT_TASK_VEHICLE_DRIVE_WANDER = 0xF09B15B3,
> 	SCRIPT_TASK_GO_STRAIGHT_TO_COORD = 0x7D8F4411,
> 	SCRIPT_TASK_GO_STRAIGHT_TO_COORD_RELATIVE_TO_ENTITY = 0x78EC0FF6,
> 	DEPRECATED_SCRIPT_TASK_GO_STRAIGHT_TO_COORD_RELATIVE_TO_VEHICLE = 0x96066708,
> 	SCRIPT_TASK_ACHIEVE_HEADING = 0x7276D3DF,
> 	SCRIPT_TASK_FOLLOW_POINT_ROUTE = 0xB232526F,
> 	SCRIPT_TASK_GO_TO_ENTITY = 0x4924437D,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_PED = 0xD7F626D1,
> 	SCRIPT_TASK_0xEEDD9B66 = 0xEEDD9B66,
> 	SCRIPT_TASK_0x114F64E3 = 0x114F64E3,
> 	SCRIPT_TASK_0xF10822AA = 0xF10822AA,
> 	SCRIPT_TASK_SMART_FLEE_PED = 0x6BA30179,
> 	SCRIPT_TASK_WANDER_STANDARD = 0xBBA3B7CA,
> 	SCRIPT_TASK_FOLLOW_NAV_MESH_TO_COORD = 0x2A89B8A7,
> 	SCRIPT_TASK_GO_TO_COORD_ANY_MEANS = 0x93399E79,
> 	SCRIPT_TASK_PERFORM_SEQUENCE = 0x0E763797,
> 	SCRIPT_TASK_LEAVE_ANY_VEHICLE = 0xCE98FBB3,
> 	SCRIPT_TASK_AIM_GUN_SCRIPTED = 0x0C69931F,
> 	SCRIPT_TASK_AIM_GUN_AT_ENTITY = 0x6134071B,
> 	SCRIPT_TASK_GO_TO_COORD_WHILE_SHOOTING = 0x9387DEAB,
> 	SCRIPT_TASK_TURN_PED_TO_FACE_ENTITY = 0xCBCE4595,
> 	DEPRECATED_SCRIPT_TASK_TURN_PED_TO_FACE_PED = 0xE51B372C,
> 	SCRIPT_TASK_AIM_GUN_AT_COORD = 0x49BEF36E,
> 	SCRIPT_TASK_SHOOT_AT_COORD = 0xD90EF188,
> 	DEPRECATED_SCRIPT_TASK_DESTROY_VEHICLE = 0x0B45DACC,
> 	DEPRECATED_SCRIPT_TASK_DIVE_AND_GET_UP = 0x7BA620DD,
> 	SCRIPT_TASK_SHUFFLE_TO_NEXT_VEHICLE_SEAT = 0x153011FC,
> 	SCRIPT_TASK_EVERYONE_LEAVE_VEHICLE = 0xA569F146,
> 	DEPRECATED_SCRIPT_TASK_DIVE_FROM_ATTACHMENT_AND_GET_UP = 0xC09E33A2,
> 	SCRIPT_TASK_GOTO_ENTITY_OFFSET = 0x87E3E0A8,
> 	DEPRECATED_SCRIPT_TASK_GOTO_PED_OFFSET = 0xBF57AF1C,
> 	DEPRECATED_SCRIPT_TASK_SIT_DOWN = 0x190DC01B,
> 	SCRIPT_TASK_TURN_PED_TO_FACE_COORD = 0x574BB8F5,
> 	SCRIPT_TASK_DRIVE_POINT_ROUTE = 0xBAE13130,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_COORD_WHILE_AIMING = 0x7DEC090B,
> 	SCRIPT_TASK_VEHICLE_TEMP_ACTION = 0x81B4D53A,
> 	SCRIPT_TASK_0x30A0DC39 = 0x30A0DC39,
> 	SCRIPT_TASK_VEHICLE_MISSION = 0xB41F1A34,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_OBJECT = 0xE4A207BD,
> 	DEPRECATED_SCRIPT_TASK_WEAPON_ROLL = 0xB2A2BF11,
> 	DEPRECATED_SCRIPT_TASK_SIDEWAYS_DIVE = 0x2C1A612F,
> 	SCRIPT_TASK_DRIVE_BY = 0x7D711E7D,
> 	SCRIPT_TASK_USE_MOBILE_PHONE = 0x37D339A1,
> 	SCRIPT_TASK_WARP_PED_INTO_VEHICLE = 0xBC555B9D,
> 	DEPRECATED_SCRIPT_TASK_USE_ATTRACTOR = 0x63694D9D,
> 	SCRIPT_TASK_SHOOT_AT_ENTITY = 0x0A01F8B8,
> 	DEPRECATED_SCRIPT_TASK_SHOOT_AT_PED = 0x15F49B5F,
> 	SCRIPT_TASK_0x3A82EBC5 = 0x3A82EBC5,
> 	DEPRECATED_SCRIPT_TASK_DEAD = 0xF793E251,
> 	DEPRECATED_SCRIPT_TASK_GOTO_VEHICLE = 0x9A2943F2,
> 	SCRIPT_TASK_CLIMB = 0xB802FDCA,
> 	SCRIPT_TASK_PERFORM_SEQUENCE_FROM_PROGRESS = 0x5485FD94,
> 	SCRIPT_TASK_GOTO_ENTITY_AIMING = 0x967EA21C,
> 	DEPRECATED_SCRIPT_TASK_GOTO_PED_AIMING = 0x1A230A59,
> 	DEPRECATED_SCRIPT_TASK_JETPACK = 0x6EA2E79A,
> 	SCRIPT_TASK_SET_PED_DECISION_MAKER = 0x4E5B453C,
> 	SCRIPT_TASK_SET_PED_DEFENSIVE_AREA = 0x00A101C8,
> 	DEPRECATED_SCRIPT_TASK_HOLD_OBJECT = 0xC8BCA367,
> 	DEPRECATED_SCRIPT_TASK_COMPLEX_PICKUP_OBJECT = 0xA9D6E737,
> 	SCRIPT_TASK_PED_SLIDE_TO_COORD = 0x3E5094A7,
> 	DEPRECATED_SCRIPT_TASK_SWIM_TO_COORD = 0xABFCB97C,
> 	SCRIPT_TASK_DRIVE_POINT_ROUTE_ADVANCED = 0xEA6A323F,
> 	SCRIPT_TASK_PED_SLIDE_TO_COORD_AND_PLAY_ANIM = 0x8A0970F4,
> 	SCRIPT_TASK_0x22024D52 = 0x22024D52,
> 	DEPRECATED_SCRIPT_TASK_GREET_PARTNER = 0xAD4CD615,
> 	DEPRECATED_SCRIPT_TASK_DIE_NAMED_ANIM = 0xD73264BC,
> 	DEPRECATED_SCRIPT_TASK_FOLLOW_FOOTSTEPS = 0xA0A7761F,
> 	DEPRECATED_SCRIPT_TASK_WALK_ALONGSIDE_PED = 0xA92F7B36,
> 	DEPRECATED_SCRIPT_TASK_USE_CLOSEST_MAP_ATTRACTOR = 0xD0D5F297,
> 	DEPRECATED_SCRIPT_TASK_SET_IGNORE_WEAPON_RANGE_FLAG = 0xADC7E889,
> 	DEPRECATED_SCRIPT_TASK_HAND_GESTURE = 0x1F53A7DA,
> 	SCRIPT_TASK_PLAY_ANIM = 0x87B9A382,
> 	DEPRECATED_SCRIPT_TASK_PLAY_ANIM_ADVANCED = 0x8ECCBFB3,
> 	DEPRECATED_SCRIPT_SET_TASK_PLAY_ANIM_PLAYBACK_COORDS = 0xAF35BD9C,
> 	DEPRECATED_SCRIPT_TASK_PED_ARREST_PED = 0xB99876B9,
> 	SCRIPT_TASK_ARREST_PED = 0x52FF82C0,
> 	SCRIPT_TASK_COMBAT = 0x2E85A751,
> 	SCRIPT_TASK_COMBAT_TIMED = 0xF2E41A8A,
> 	SCRIPT_TASK_SEEK_COVER_FROM_POS = 0xA77A06C5,
> 	SCRIPT_TASK_SEEK_COVER_FROM_PED = 0x71E30BDC,
> 	SCRIPT_TASK_SEEK_COVER_TO_COVER_POINT = 0x99AFA8A3,
> 	DEPRECATED_SCRIPT_TASK_SET_COMBAT_DECISION_MAKER = 0x9B95A683,
> 	SCRIPT_TASK_TOGGLE_DUCK = 0x0F3B8554,
> 	DEPRECATED_SCRIPT_TASK_USE_SKIS = 0x97AE64AB,
> 	SCRIPT_TASK_GUARD_DEFENSIVE_AREA = 0xDF5F4BA7,
> 	SCRIPT_TASK_PICKUP_AND_CARRY_OBJECT = 0x89025025,
> 	DEPRECATED_SCRIPT_TASK_SEEK_COVER_TO_OBJECT = 0x5A2825BB,
> 	SCRIPT_TASK_SEEK_COVER_TO_COORDS = 0x6C01775C,
> 	DEPRECATED_SCRIPT_TASK_SIT_DOWN_PLAY_ANIM = 0xBA284891,
> 	SCRIPT_TASK_GUARD_ANGLED_DEFENSIVE_AREA = 0x84AEE7A0,
> 	SCRIPT_TASK_STAND_GUARD = 0xD88F2CDE,
> 	SCRIPT_TASK_CLIMB_LADDER = 0x66403353,
> 	DEPRECATED_SCRIPT_TASK_SIT_DOWN_ON_OBJECT = 0xFD790A1B,
> 	SCRIPT_TASK_GUARD_SPHERE_DEFENSIVE_AREA = 0x21E8D4E4,
> 	SCRIPT_TASK_START_SCENARIO_IN_PLACE = 0x3B3A458F,
> 	SCRIPT_TASK_START_SCENARIO_AT_POSITION = 0xBE86C566,
> 	SCRIPT_TASK_START_VEHICLE_SCENARIO = 0x86016E38,
> 	SCRIPT_TASK_PUT_PED_DIRECTLY_INTO_COVER = 0x8B2F140E,
> 	SCRIPT_TASK_PUT_PED_DIRECTLY_INTO_COVER_FROM_TARGET = 0x9DD414F5,
> 	SCRIPT_TASK_PUT_PED_DIRECTLY_INTO_MELEE = 0xFBBF6F4D,
> 	SCRIPT_TASK_GUARD_CURRENT_POSITION = 0x8CE49D34,
> 	SCRIPT_TASK_USE_NEAREST_SCENARIO_TO_POS = 0x623A5EFE,
> 	SCRIPT_TASK_USE_NEAREST_SCENARIO_CHAIN_TO_POS = 0x9BD19AE7,
> 	DEPRECATED_SCRIPT_TASK_LEAVE_GROUP = 0x9F5DBCE5,
> 	SCRIPT_TASK_PERFORM_SEQUENCE_LOCALLY = 0xE7FBAB4F,
> 	SCRIPT_TASK_COMBAT_HATED_TARGETS_IN_AREA = 0x42CC4F21,
> 	SCRIPT_TASK_COMBAT_HATED_TARGETS_AROUND_PED = 0xAA05B492,
> 	DEPRECATED_SCRIPT_TASK_HOLSTERING_WEAPON = 0x81FB0B11,
> 	DEPRECATED_SCRIPT_TASK_COMBAT_ROLL = 0x71F49E88,
> 	DEPRECATED_SCRIPT_TASK_MOBILE_CONVERSATION = 0xE3380A30,
> 	SCRIPT_TASK_SWAP_WEAPON = 0x2AB81462,
> 	SCRIPT_TASK_RELOAD_WEAPON = 0xC322ED6F,
> 	SCRIPT_TASK_0xAB4B293A = 0xAB4B293A,
> 	SCRIPT_TASK_COMBAT_HATED_TARGETS_AROUND_PED_TIMED = 0x2719C0D1,
> 	SCRIPT_TASK_GET_OFF_BOAT = 0x9A27A999,
> 	SCRIPT_TASK_FOLLOW_NAVMESH_TO_COORD_ADVANCED = 0x9C4FBCAC,
> 	SCRIPT_TASK_PATROL = 0xB550726C,
> 	SCRIPT_TASK_STAY_IN_COVER = 0xE1C16E99,
> 	SCRIPT_TASK_HANG_GLIDER = 0x00E1228C,
> 	SCRIPT_TASK_FOLLOW_TO_OFFSET_OF_ENTITY = 0x3EF867F4,
> 	SCRIPT_TASK_FOLLOW_TO_OFFSET_OF_PICKUP = 0x70AEF4E9,
> 	SCRIPT_TASK_GO_TO_COORD_WHILE_AIMING_AT_COORD = 0x19CE5AFC,
> 	SCRIPT_TASK_GO_TO_COORD_WHILE_AIMING_AT_ENTITY = 0x972C6757,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_COORD_WHILE_AIMING_AT_PED = 0x0A81CE80,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_COORD_WHILE_AIMING_AT_VEHICLE = 0xE677F9FB,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_COORD_WHILE_AIMING_AT_OBJECT = 0x89E45204,
> 	SCRIPT_TASK_GO_TO_ENTITY_WHILE_AIMING_AT_COORD = 0xBAEB517C,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_PED_WHILE_AIMING_AT_COORD = 0xA2B07D24,
> 	SCRIPT_TASK_GO_TO_ENTITY_WHILE_AIMING_AT_ENTITY = 0xB80BFB24,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_PED_WHILE_AIMING_AT_PED = 0x6C095462,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_PED_WHILE_AIMING_AT_VEHICLE = 0x7BF24249,
> 	DEPRECATED_SCRIPT_TASK_GO_TO_PED_WHILE_AIMING_AT_OBJECT = 0xC93D7834,
> 	SCRIPT_TASK_USE_WALKIE_TALKIE = 0x29BABC64,
> 	SCRIPT_TASK_CHAT_TO_PED = 0x0FC239CD,
> 	DEPRECATED_SCRIPT_TASK_WARP_PED_ONTO_VEHICLE = 0xFCC0F996,
> 	SCRIPT_TASK_FIRE_FLARE = 0xDEB1C08F,
> 	SCRIPT_TASK_BIND_POSE = 0x4929CE40,
> 	SCRIPT_TASK_NM_ELECTROCUTE = 0x8944A9A0,
> 	SCRIPT_TASK_NM_HIGH_FALL = 0x015D63E3,
> 	SCRIPT_TASK_NM_DANGLE = 0x0B49EAEC,
> 	SCRIPT_TASK_NM_SLUNG_OVER_SHOULDER = 0xF0F9FFC0,
> 	SCRIPT_TASK_NM_STUMBLE = 0xBACF9837,
> 	SCRIPT_TASK_SKY_DIVE = 0x4B65F15C,
> 	SCRIPT_TASK_PARACHUTE = 0x76CA4A8E,
> 	SCRIPT_TASK_PARACHUTE_TO_TARGET = 0x4921B47A,
> 	SCRIPT_TASK_0x9B4FC7D8 = 0x9B4FC7D8,
> 	DEPRECATED_SCRIPT_TASK_GET_ON_SKI_LIFT = 0x536E59F9,
> 	SCRIPT_TASK_NM_ATTACH_TO_VEHICLE = 0x4847A94F,
> 	SCRIPT_TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS = 0x6F9C865C,
> 	SCRIPT_TASK_MOVE_NETWORK = 0x0494661C,
> 	SCRIPT_TASK_SYNCHRONIZED_SCENE = 0x6A67A5CC,
> 	SCRIPT_TASK_VEHICLE_SHOOT_AT_COORD = 0xAF18B824,
> 	SCRIPT_TASK_VEHICLE_SHOOT_AT_ENTITY = 0x20123810,
> 	SCRIPT_TASK_VEHICLE_PARK = 0xEFC8537E,
> 	SCRIPT_TASK_MOUNT_ANIMAL = 0x6F5F73AE,
> 	SCRIPT_TASK_DISMOUNT_ANIMAL = 0x1DE2A7BD,
> 	SCRIPT_TASK_THROW_PROJECTILE = 0xAD37BF03,
> 	SCRIPT_TASK_VEHICLE_AIM_AT_COORD = 0x00C59C52,
> 	SCRIPT_TASK_VEHICLE_AIM_AT_ENTITY = 0x6F30F4C1,
> 	SCRIPT_TASK_VEHICLE_AIM_USING_CAMERA = 0x3BDBC83C,
> 	SCRIPT_TASK_ADVANCE_TO_TARGET_IN_LINE = 0xCC312EC4,
> 	SCRIPT_TASK_RAPPEL_FROM_HELI = 0xEF8D6B40,
> 	SCRIPT_TASK_GENERAL_SWEEP = 0x491A782D,
> 	SCRIPT_TASK_DRAG_PED_TO_COORD = 0x87A3DFEA,
> 	SCRIPT_TASK_VEHICLE_FOLLOW_WAYPOINT_RECORDING = 0xF1F17AE7,
> 	SCRIPT_TASK_RAPPEL_DOWN_WALL = 0x8E29DEF2,
> 	SCRIPT_TASK_GO_TO_COORD_AND_AIM_AT_HATED_ENTITIES_NEAR_COORD = 0x290A02BC,
> 	SCRIPT_TASK_WANDER_IN_AREA = 0x370BCF53,
> 	SCRIPT_TASK_VEHICLE_GOTO_NAVMESH = 0xFBB43C4A,
> 	SCRIPT_TASK_FORCE_MOTION_STATE = 0x9E78AC1F,
> 	SCRIPT_TASK_IN_CUSTODY = 0x6D4411C9,
> 	SCRIPT_TASK_LOOK_AT_ENTITY = 0x08F5AF9D,
> 	SCRIPT_TASK_LOOK_AT_COORD = 0xCB842EEC,
> 	SCRIPT_TASK_VEHICLE_CHASE = 0x2288A57C,
> 	SCRIPT_TASK_STEALTH_KILL = 0x5014CC1A,
> 	SCRIPT_TASK_HELI_CHASE = 0x27369192,
> 	SCRIPT_TASK_PLANE_CHASE = 0x02DBA9BF,
> 	SCRIPT_TASK_PLANE_LAND = 0x043E4A56,
> 	SCRIPT_TASK_0x7F9814E9 = 0x7F9814E9,
> 	SCRIPT_TASK_0xEC685098 = 0xEC685098,
> 	SCRIPT_TASK_SHOCKING_EVENT_REACT = 0x498BABE3,
> 	SCRIPT_TASK_WRITHE = 0x8EC23E41,
> 	SCRIPT_TASK_EXIT_COVER = 0x4E961D82,
> 	SCRIPT_TASK_PLANT_BOMB = 0x8127FD1A,
> 	SCRIPT_TASK_INVESTIGATE_COORDS = 0x9C250C19,
> 	SCRIPT_TASK_WANDER_SPECIFIC = 0xD46F7254,
> 	SCRIPT_TASK_SHARK_CIRCLE_COORD = 0x48EED267,
> 	SCRIPT_TASK_SHARK_CIRCLE_PED = 0xFD0B5826,
> 	SCRIPT_TASK_0x29269FF1 = 0x29269FF1,
> 	SCRIPT_TASK_REACT_AND_FLEE_PED = 0x7DEDF098,
> 	SCRIPT_TASK_GO_TO_COORD_ANY_MEANS_EXTRA_PARAMS = 0x45B5A146,
> 	SCRIPT_TASK_USE_NEAREST_TRAIN_SCENARIO_TO_POS = 0xA5806868,
> 	SCRIPT_TASK_JETPACK = 0x828EBA07,
> 	SCRIPT_TASK_GO_TO_COORD_ANY_MEANS_EXTRA_PARAMS_WITH_CRUISE_SPEED = 0x4DE5C290,
> 	SCRIPT_TASK_AGITATED_ACTION = 0x548CB4B4,
> 	SCRIPT_TASK_WARP_PED_DIRECTLY_INTO_COVER = 0x0E802924
> };

## GET_SCRIPTED_COVER_POINT_COORDS

```c
Vector3 GET_SCRIPTED_COVER_POINT_COORDS(ScrHandle coverpoint)  // 0x594A1028FC2A3E85
```

build 323

## GET_SEQUENCE_PROGRESS

```c
int GET_SEQUENCE_PROGRESS(Ped ped)  // 0x00A9010CFE1E3533
```

build 323

> returned values:
> 0 to 7 = task that's currently in progress, 0 meaning the first one.
> -1 no task sequence in progress.

## GET_TASK_MOVE_NETWORK_EVENT

```c
BOOL GET_TASK_MOVE_NETWORK_EVENT(Ped ped, const char* eventName)  // 0xB4F47213DF45A64C
```

build 323

## GET_TASK_MOVE_NETWORK_SIGNAL_BOOL

```c
BOOL GET_TASK_MOVE_NETWORK_SIGNAL_BOOL(Ped ped, const char* signalName)  // 0xA7FFBA498E4AAF67
```

build 323

## GET_TASK_MOVE_NETWORK_SIGNAL_FLOAT

```c
float GET_TASK_MOVE_NETWORK_SIGNAL_FLOAT(Ped ped, const char* signalName)  // 0x44AB0B3AFECCE242
```

build 1493 · old names: `_GET_TASK_MOVE_NETWORK_SIGNAL_FLOAT`

## GET_TASK_MOVE_NETWORK_STATE

```c
const char* GET_TASK_MOVE_NETWORK_STATE(Ped ped)  // 0x717E4D1F2048376D
```

build 323

## GET_TASK_RAPPEL_DOWN_WALL_STATE

```c
int GET_TASK_RAPPEL_DOWN_WALL_STATE(Ped ped)  // 0x9D252648778160DF
```

build 1868

## GET_VEHICLE_WAYPOINT_PROGRESS

```c
int GET_VEHICLE_WAYPOINT_PROGRESS(Vehicle vehicle)  // 0x9824CFF8FC66E159
```

build 323

## GET_VEHICLE_WAYPOINT_TARGET_POINT

```c
int GET_VEHICLE_WAYPOINT_TARGET_POINT(Vehicle vehicle)  // 0x416B62AC8B9E5BBD
```

build 323

## GET_WAYPOINT_DISTANCE_ALONG_ROUTE

```c
float GET_WAYPOINT_DISTANCE_ALONG_ROUTE(const char* name, int point)  // 0xA5B769058763E497
```

build 323

## IS_CONTROLLED_VEHICLE_UNABLE_TO_GET_TO_ROAD

```c
BOOL IS_CONTROLLED_VEHICLE_UNABLE_TO_GET_TO_ROAD(Ped ped)  // 0x3E38E28A1D80DDF6
```

build 323

## IS_DRIVEBY_TASK_UNDERNEATH_DRIVING_TASK

```c
BOOL IS_DRIVEBY_TASK_UNDERNEATH_DRIVING_TASK(Ped ped)  // 0x8785E6E40C7A8818
```

build 323

## IS_MOUNTED_WEAPON_TASK_UNDERNEATH_DRIVING_TASK

```c
BOOL IS_MOUNTED_WEAPON_TASK_UNDERNEATH_DRIVING_TASK(Ped ped)  // 0xA320EF046186FA3B
```

build 323

## IS_MOVE_BLEND_RATIO_RUNNING

```c
BOOL IS_MOVE_BLEND_RATIO_RUNNING(Ped ped)  // 0xD4D8636C0199A939
```

build 323

## IS_MOVE_BLEND_RATIO_SPRINTING

```c
BOOL IS_MOVE_BLEND_RATIO_SPRINTING(Ped ped)  // 0x24A2AD74FA9814E2
```

build 323

## IS_MOVE_BLEND_RATIO_STILL

```c
BOOL IS_MOVE_BLEND_RATIO_STILL(Ped ped)  // 0x349CE7B56DAFD95C
```

build 323

## IS_MOVE_BLEND_RATIO_WALKING

```c
BOOL IS_MOVE_BLEND_RATIO_WALKING(Ped ped)  // 0xF133BBBE91E1691F
```

build 323

## IS_PED_ACTIVE_IN_SCENARIO

```c
BOOL IS_PED_ACTIVE_IN_SCENARIO(Ped ped)  // 0xAA135F9482C82CC3
```

build 323

## IS_PED_BEING_ARRESTED

```c
BOOL IS_PED_BEING_ARRESTED(Ped ped)  // 0x90A09F3A45FED688
```

build 323

> This function is hard-coded to always return 0.

## IS_PED_CUFFED

```c
BOOL IS_PED_CUFFED(Ped ped)  // 0x74E559B3BC910685
```

build 323

## IS_PED_GETTING_UP

```c
BOOL IS_PED_GETTING_UP(Ped ped)  // 0x2A74E1D5F2F00EEC
```

build 323

## IS_PED_IN_WRITHE

```c
BOOL IS_PED_IN_WRITHE(Ped ped)  // 0xDEB6D52126E7D640
```

build 323

> This native checks if a ped is on the ground, in pain from a (gunshot) wound.
> Returns `true` if the ped is in writhe, `false` otherwise.

## IS_PED_PLAYING_BASE_CLIP_IN_SCENARIO

```c
BOOL IS_PED_PLAYING_BASE_CLIP_IN_SCENARIO(Ped ped)  // 0x621C6E4729388E41
```

build 323

> Used only once (am_mp_property_int)
> 
> ped was PLAYER_PED_ID()
> 
> Related to CTaskAmbientClips.

## IS_PED_RUNNING

```c
BOOL IS_PED_RUNNING(Ped ped)  // 0xC5286FFC176F28A2
```

build 323

## IS_PED_RUNNING_ARREST_TASK

```c
BOOL IS_PED_RUNNING_ARREST_TASK(Ped ped)  // 0x3DC52677769B4AE0
```

build 323

## IS_PED_SPRINTING

```c
BOOL IS_PED_SPRINTING(Ped ped)  // 0x57E457CD2C0FC168
```

build 323

## IS_PED_STILL

```c
BOOL IS_PED_STILL(Ped ped)  // 0xAC29253EEF8F0180
```

build 323

## IS_PED_STRAFING

```c
BOOL IS_PED_STRAFING(Ped ped)  // 0xE45B7F222DE47E09
```

build 323

## IS_PED_WALKING

```c
BOOL IS_PED_WALKING(Ped ped)  // 0xDE4C184B2B9B071A
```

build 323

## IS_PLAYING_PHONE_GESTURE_ANIM

```c
BOOL IS_PLAYING_PHONE_GESTURE_ANIM(Ped ped)  // 0xB8EBB1E9D3588C10
```

build 323

## IS_SCENARIO_GROUP_ENABLED

```c
BOOL IS_SCENARIO_GROUP_ENABLED(const char* scenarioGroup)  // 0x367A09DED4E05B99
```

build 323

> Full list of scenario groups used in scripts by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenarioGroupNames.json
> Occurrences in the b617d scripts: 
> 
>  "ARMY_GUARD",
>  "ARMY_HELI",
>  "BLIMP",
>  "Cinema_Downtown",
>  "Cinema_Morningwood",
>  "Cinema_Textile",
>  "City_Banks",
>  "Countryside_Banks",
>  "DEALERSHIP",
>  "KORTZ_SECURITY",
>  "LSA_Planes",
>  "MP_POLICE",
>  "Observatory_Bikers",
>  "POLICE_POUND1",
>  "POLICE_POUND2",
>  "POLICE_POUND3",
>  "POLICE_POUND4",
>  "POLICE_POUND5",
>  "Rampage1",
>  "SANDY_PLANES",
>  "SCRAP_SECURITY",
>  "SEW_MACHINE",
>  "SOLOMON_GATE"
> 
> Sometimes used with DOES_SCENARIO_GROUP_EXIST:
> if (TASK::DOES_SCENARIO_GROUP_EXIST("Observatory_Bikers") &&   (!TASK::IS_SCENARIO_GROUP_ENABLED("Observatory_Bikers"))) {
> else if (TASK::IS_SCENARIO_GROUP_ENABLED("BLIMP")) {

## IS_SCENARIO_OCCUPIED

```c
BOOL IS_SCENARIO_OCCUPIED(float x, float y, float z, float maxRange, BOOL onlyUsersActuallyAtScenario)  // 0x788756D73AC2E07C
```

build 323

## IS_SCENARIO_TYPE_ENABLED

```c
BOOL IS_SCENARIO_TYPE_ENABLED(const char* scenarioType)  // 0x3A815DB3EA088722
```

build 323

> Full list of scenario types used in scripts by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenariosCompact.json
> Occurrences in the b617d scripts:
> "PROP_HUMAN_SEAT_CHAIR",
> "WORLD_HUMAN_DRINKING",
> "WORLD_HUMAN_HANG_OUT_STREET",
> "WORLD_HUMAN_SMOKING",
> "WORLD_MOUNTAIN_LION_WANDER",
> "WORLD_HUMAN_DRINKING"
> 
> Sometimes used together with MISC::IS_STRING_NULL_OR_EMPTY in the scripts.
> 
> scenarioType could be the same as scenarioName, used in for example TASK::TASK_START_SCENARIO_AT_POSITION.
> 

## IS_TASK_MOVE_NETWORK_ACTIVE

```c
BOOL IS_TASK_MOVE_NETWORK_ACTIVE(Ped ped)  // 0x921CE12C489C4C41
```

build 323

## IS_TASK_MOVE_NETWORK_READY_FOR_TRANSITION

```c
BOOL IS_TASK_MOVE_NETWORK_READY_FOR_TRANSITION(Ped ped)  // 0x30ED88D5E0C56A37
```

build 323

## IS_WAYPOINT_PLAYBACK_GOING_ON_FOR_PED

```c
BOOL IS_WAYPOINT_PLAYBACK_GOING_ON_FOR_PED(Ped ped)  // 0xE03B3F2D3DC59B64
```

build 323

## IS_WAYPOINT_PLAYBACK_GOING_ON_FOR_VEHICLE

```c
BOOL IS_WAYPOINT_PLAYBACK_GOING_ON_FOR_VEHICLE(Vehicle vehicle)  // 0xF5134943EA29868C
```

build 323

## OPEN_PATROL_ROUTE

```c
void OPEN_PATROL_ROUTE(const char* patrolRoute)  // 0xA36BFB5EE89F3D82
```

build 323

>  patrolRoutes found in the b617d scripts:
>  "miss_Ass0",
>  "miss_Ass1",
>  "miss_Ass2",
>  "miss_Ass3",
>  "miss_Ass4",
>  "miss_Ass5",
>  "miss_Ass6",
>  "MISS_PATROL_6",
>  "MISS_PATROL_7",
>  "MISS_PATROL_8",
>  "MISS_PATROL_9",
>  "miss_Tower_01",
>  "miss_Tower_02",
>  "miss_Tower_03",
>  "miss_Tower_04",
>  "miss_Tower_05",
>  "miss_Tower_06",
>  "miss_Tower_07",
>  "miss_Tower_08",
>  "miss_Tower_10"

## OPEN_SEQUENCE_TASK

```c
void OPEN_SEQUENCE_TASK(int* taskSequenceId)  // 0xE8854A4326B9E12B
```

build 323

## PED_HAS_USE_SCENARIO_TASK

```c
BOOL PED_HAS_USE_SCENARIO_TASK(Ped ped)  // 0x295E3CCEC879CCD7
```

build 323

## PLAY_ANIM_ON_RUNNING_SCENARIO

```c
void PLAY_ANIM_ON_RUNNING_SCENARIO(Ped ped, const char* animDict, const char* animName)  // 0x748040460F8DF5DC
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## PLAY_ENTITY_SCRIPTED_ANIM

```c
void PLAY_ENTITY_SCRIPTED_ANIM(Entity entity, int* priorityLowData, int* priorityMidData, int* priorityHighData, float blendInDelta, float blendOutDelta)  // 0x77A1EEC547E7FCF1
```

build 323

## REMOVE_ALL_COVER_BLOCKING_AREAS

```c
void REMOVE_ALL_COVER_BLOCKING_AREAS()  // 0xDB6708C0B46F56D8
```

build 323

## REMOVE_COVER_BLOCKING_AREAS_AT_POSITION

```c
void REMOVE_COVER_BLOCKING_AREAS_AT_POSITION(float x, float y, float z)  // 0xFA83CA6776038F64
```

build 1493 · old names: `_REMOVE_COVER_BLOCKING_AREAS_AT_COORD`

## REMOVE_COVER_POINT

```c
void REMOVE_COVER_POINT(ScrHandle coverpoint)  // 0xAE287C923D891715
```

build 323

## REMOVE_SPECIFIC_COVER_BLOCKING_AREAS

```c
void REMOVE_SPECIFIC_COVER_BLOCKING_AREAS(float startX, float startY, float startZ, float endX, float endY, float endZ, BOOL blockObjects, BOOL blockVehicles, BOOL blockMap, BOOL blockPlayer)  // 0x1F351CF1C6475734
```

build 505 · old names: `_REMOVE_SPECIFIC_COVER_BLOCKING_AREA`

## REMOVE_WAYPOINT_RECORDING

```c
void REMOVE_WAYPOINT_RECORDING(const char* name)  // 0xFF1B8B4AA1C25DC8
```

build 323

> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json

## REQUEST_TASK_MOVE_NETWORK_STATE_TRANSITION

```c
BOOL REQUEST_TASK_MOVE_NETWORK_STATE_TRANSITION(Ped ped, const char* name)  // 0xD01015C7316AE176
```

build 323

## REQUEST_WAYPOINT_RECORDING

```c
void REQUEST_WAYPOINT_RECORDING(const char* name)  // 0x9EEFB62EB27B5792
```

build 323

> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json
> For a full list of the points, see here: goo.gl/wIH0vn
> 
> Max number of loaded recordings is 32.

## RESET_EXCLUSIVE_SCENARIO_GROUP

```c
void RESET_EXCLUSIVE_SCENARIO_GROUP()  // 0x4202BBCB8684563D
```

build 323

## RESET_SCENARIO_GROUPS_ENABLED

```c
void RESET_SCENARIO_GROUPS_ENABLED()  // 0xDD902D0349AFAD3A
```

build 323

## RESET_SCENARIO_TYPES_ENABLED

```c
void RESET_SCENARIO_TYPES_ENABLED()  // 0x0D40EE2A7F2B2D6D
```

build 323

## SET_ANIM_LOOPED

```c
void SET_ANIM_LOOPED(Entity entity, BOOL looped, int priority, BOOL secondary)  // 0x70033C3CC29A1FF4
```

build 323

## SET_ANIM_PHASE

```c
void SET_ANIM_PHASE(Entity entity, float phase, int priority, BOOL secondary)  // 0xDDF3CB5A0A4C0B49
```

build 2372 · old names: `_SET_ANIM_PLAYBACK_TIME`

## SET_ANIM_RATE

```c
void SET_ANIM_RATE(Entity entity, float rate, int priority, BOOL secondary)  // 0x032D49C5E359C847
```

build 323

## SET_ANIM_WEIGHT

```c
void SET_ANIM_WEIGHT(Entity entity, float weight, int priority, int index, BOOL secondary)  // 0x207F1A47C0342F48
```

build 323

## SET_DRIVE_TASK_CRUISE_SPEED

```c
void SET_DRIVE_TASK_CRUISE_SPEED(Ped driver, float cruiseSpeed)  // 0x5C9B84BD7D31D908
```

build 323

## SET_DRIVE_TASK_DRIVING_STYLE

```c
void SET_DRIVE_TASK_DRIVING_STYLE(Ped ped, int drivingStyle)  // 0xDACE1BE37D88AF67
```

build 323

> This native is used to set the driving style for specific ped.
> 
> Driving styles id seems to be:
> 786468
> 262144
> 786469
> 
> https://gtaforums.com/topic/822314-guide-driving-styles/

## SET_DRIVE_TASK_MAX_CRUISE_SPEED

```c
void SET_DRIVE_TASK_MAX_CRUISE_SPEED(Ped ped, float speed, BOOL updateBaseTask)  // 0x404A5AA9B9F0B746
```

build 323

## SET_DRIVEBY_TASK_TARGET

```c
void SET_DRIVEBY_TASK_TARGET(Ped shootingPed, Ped targetPed, Vehicle targetVehicle, float x, float y, float z)  // 0xE5B302114D8162EE
```

build 323

> For p1 & p2 (Ped, Vehicle). I could be wrong, as the only time this native is called in scripts is once and both are 0, but I assume this native will work like SET_MOUNTED_WEAPON_TARGET in which has the same exact amount of parameters and the 1st and last 3 parameters are right and the same for both natives.

## SET_EXCLUSIVE_SCENARIO_GROUP

```c
void SET_EXCLUSIVE_SCENARIO_GROUP(const char* scenarioGroup)  // 0x535E97E1F7FC0C6A
```

build 323

> Full list of scenario groups used in scripts by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenarioGroupNames.json
> Groups found in the scripts used with this native:
> 
> "AMMUNATION",
> "QUARRY",
> "Triathlon_1",
> "Triathlon_2",
> "Triathlon_3"

## SET_EXPECTED_CLONE_NEXT_TASK_MOVE_NETWORK_STATE

```c
BOOL SET_EXPECTED_CLONE_NEXT_TASK_MOVE_NETWORK_STATE(Ped ped, const char* state)  // 0xAB13A5565480B6D9
```

build 323

> Used only once in the scripts (fm_mission_controller) like so:
> 
> TASK::SET_EXPECTED_CLONE_NEXT_TASK_MOVE_NETWORK_STATE(iLocal_3160, "Cutting");

## SET_GLOBAL_MIN_BIRD_FLIGHT_HEIGHT

```c
void SET_GLOBAL_MIN_BIRD_FLIGHT_HEIGHT(float height)  // 0x6C6B148586F934F7
```

build 323

> Needs to be looped! And yes, it does work and is not a hash collision.
> Birds will try to reach the given height.

## SET_HIGH_FALL_TASK

```c
void SET_HIGH_FALL_TASK(Ped ped, int minTime, int maxTime, int entryType)  // 0x8C825BDC7741D37C
```

build 323

> Makes the ped ragdoll like when falling from a great height

## SET_MOUNTED_WEAPON_TARGET

```c
void SET_MOUNTED_WEAPON_TARGET(Ped shootingPed, Ped targetPed, Vehicle targetVehicle, float x, float y, float z, int taskMode, BOOL ignoreTargetVehDeadCheck)  // 0xCCD892192C6D2BB9
```

build 323

> Note: Look in decompiled scripts and the times that p1 and p2 aren't 0. They are filled with vars. If you look through out that script what other natives those vars are used in, you can tell p1 is a ped and p2 is a vehicle. Which most likely means if you want the mounted weapon to target a ped set targetVehicle to 0 or vice-versa.

## SET_NEXT_DESIRED_MOVE_STATE

```c
void SET_NEXT_DESIRED_MOVE_STATE(float nextMoveState)  // 0xF1B9F16E89E2C93A
```

build 323

> This native does absolutely nothing, just a nullsub
> 
> R* Comment:
> SET_NEXT_DESIRED_MOVE_STATE - Function is deprecated - do not use anymore

## SET_PARACHUTE_TASK_TARGET

```c
void SET_PARACHUTE_TASK_TARGET(Ped ped, float x, float y, float z)  // 0xC313379AF0FCEDA7
```

build 323

## SET_PARACHUTE_TASK_THRUST

```c
void SET_PARACHUTE_TASK_THRUST(Ped ped, float thrust)  // 0x0729BAC1B8C64317
```

build 323

## SET_PED_CAN_PLAY_AMBIENT_IDLES

```c
void SET_PED_CAN_PLAY_AMBIENT_IDLES(Ped ped, BOOL blockIdleClips, BOOL removeIdleClipIfPlaying)  // 0x8FD89A6240813FD0
```

build 323

> Appears only in fm_mission_controller and used only 3 times.
> 
> ped was always PLAYER_PED_ID()
> p1 was always true
> p2 was always true

## SET_PED_DESIRED_MOVE_BLEND_RATIO

```c
void SET_PED_DESIRED_MOVE_BLEND_RATIO(Ped ped, float newMoveBlendRatio)  // 0x1E982AC8716912C5
```

build 323

## SET_PED_PATH_AVOID_FIRE

```c
void SET_PED_PATH_AVOID_FIRE(Ped ped, BOOL avoidFire)  // 0x4455517B28441E60
```

build 323

## SET_PED_PATH_CAN_DROP_FROM_HEIGHT

```c
void SET_PED_PATH_CAN_DROP_FROM_HEIGHT(Ped ped, BOOL Toggle)  // 0xE361C5C71C431A4F
```

build 323

## SET_PED_PATH_CAN_USE_CLIMBOVERS

```c
void SET_PED_PATH_CAN_USE_CLIMBOVERS(Ped ped, BOOL Toggle)  // 0x8E06A6FE76C9EFF4
```

build 323

## SET_PED_PATH_CAN_USE_LADDERS

```c
void SET_PED_PATH_CAN_USE_LADDERS(Ped ped, BOOL Toggle)  // 0x77A5B103C87F476E
```

build 323

## SET_PED_PATH_CLIMB_COST_MODIFIER

```c
void SET_PED_PATH_CLIMB_COST_MODIFIER(Ped ped, float modifier)  // 0x88E32DB8C1A4AA4B
```

build 323

> Default modifier is 1.0, minimum is 0.0 and maximum is 10.0.

## SET_PED_PATH_MAY_ENTER_WATER

```c
void SET_PED_PATH_MAY_ENTER_WATER(Ped ped, BOOL mayEnterWater)  // 0xF35425A4204367EC
```

build 323 · old names: `SET_PED_PATHS_WIDTH_PLANT`

## SET_PED_PATH_PREFER_TO_AVOID_WATER

```c
void SET_PED_PATH_PREFER_TO_AVOID_WATER(Ped ped, BOOL avoidWater)  // 0x38FE1EC73743793C
```

build 323

## SET_PED_WAYPOINT_PROGRESS

```c
void SET_PED_WAYPOINT_PROGRESS(Ped ped, int progress)  // 0x686ECCD99D4E61BB
```

build 3570

## SET_PED_WAYPOINT_ROUTE_OFFSET

```c
BOOL SET_PED_WAYPOINT_ROUTE_OFFSET(Ped ped, float x, float y, float z)  // 0xED98E10B0AFCE4B4
```

build 323

## SET_SCENARIO_GROUP_ENABLED

```c
void SET_SCENARIO_GROUP_ENABLED(const char* scenarioGroup, BOOL enabled)  // 0x02C8E5B49848664E
```

build 323

> Full list of scenario groups used in scripts by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenarioGroupNames.json
> Occurrences in the b617d scripts: https://pastebin.com/Tvg2PRHU

## SET_SCENARIO_TYPE_ENABLED

```c
void SET_SCENARIO_TYPE_ENABLED(const char* scenarioType, BOOL toggle)  // 0xEB47EC4E34FB7EE1
```

build 323

> Full list of scenario types used in scripts by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenariosCompact.json
> seems to enable/disable specific scenario-types from happening in the game world.
> 
> Here are some scenario types from the scripts:
> "WORLD_MOUNTAIN_LION_REST"                                             
> "WORLD_MOUNTAIN_LION_WANDER"                                            
> "DRIVE"                                                                  
> "WORLD_VEHICLE_POLICE_BIKE"                                             
> "WORLD_VEHICLE_POLICE_CAR"                                             
> "WORLD_VEHICLE_POLICE_NEXT_TO_CAR"                                        
> "WORLD_VEHICLE_DRIVE_SOLO"                                                 
> "WORLD_VEHICLE_BIKER"                                                      
> "WORLD_VEHICLE_DRIVE_PASSENGERS"                                           
> "WORLD_VEHICLE_SALTON_DIRT_BIKE"                                           
> "WORLD_VEHICLE_BICYCLE_MOUNTAIN"                                           
> "PROP_HUMAN_SEAT_CHAIR"                                             
> "WORLD_VEHICLE_ATTRACTOR"                                             
> "WORLD_HUMAN_LEANING"                                                 
> "WORLD_HUMAN_HANG_OUT_STREET"                                        
> "WORLD_HUMAN_DRINKING"                                                
> "WORLD_HUMAN_SMOKING"                                                
> "WORLD_HUMAN_GUARD_STAND"                                            
> "WORLD_HUMAN_CLIPBOARD"                                              
> "WORLD_HUMAN_HIKER"                                                  
> "WORLD_VEHICLE_EMPTY"                                                      
> "WORLD_VEHICLE_BIKE_OFF_ROAD_RACE"                                      
> "WORLD_HUMAN_PAPARAZZI"                                               
> "WORLD_VEHICLE_PARK_PERPENDICULAR_NOSE_IN"                            
> "WORLD_VEHICLE_PARK_PARALLEL"                                              
> "WORLD_VEHICLE_CONSTRUCTION_SOLO"                               
> "WORLD_VEHICLE_CONSTRUCTION_PASSENGERS"                                                                    
> "WORLD_VEHICLE_TRUCK_LOGS"
> 
> scenarioType could be the same as scenarioName, used in for example TASK::TASK_START_SCENARIO_AT_POSITION.

## SET_SEQUENCE_PREVENT_MIGRATION

```c
void SET_SEQUENCE_PREVENT_MIGRATION(int taskSequenceId)  // 0xF5D1F489147CB683
```

build 3570

## SET_SEQUENCE_TO_REPEAT

```c
void SET_SEQUENCE_TO_REPEAT(int taskSequenceId, BOOL repeat)  // 0x58C70CF3A41E4AE7
```

build 323

## SET_TASK_MOVE_NETWORK_ANIM_SET

```c
void SET_TASK_MOVE_NETWORK_ANIM_SET(Ped ped, Hash clipSet, Hash variableClipSet)  // 0x8423541E8B3A1589
```

build 1493

## SET_TASK_MOVE_NETWORK_ENABLE_COLLISION_ON_NETWORK_CLONE_WHEN_FIXED

```c
BOOL SET_TASK_MOVE_NETWORK_ENABLE_COLLISION_ON_NETWORK_CLONE_WHEN_FIXED(Ped ped, BOOL enable)  // 0x0FFB3C758E8C07B9
```

build 2060

> Doesn't actually return anything.

## SET_TASK_MOVE_NETWORK_SIGNAL_BOOL

```c
void SET_TASK_MOVE_NETWORK_SIGNAL_BOOL(Ped ped, const char* signalName, BOOL value)  // 0xB0A6CFD2C69C1088
```

build 323 · old names: `_SET_TASK_PROPERTY_BOOL`

## SET_TASK_MOVE_NETWORK_SIGNAL_FLOAT

```c
void SET_TASK_MOVE_NETWORK_SIGNAL_FLOAT(Ped ped, const char* signalName, float value)  // 0xD5BB4025AE449A4E
```

build 323 · old names: `_SET_TASK_PROPERTY_FLOAT`

> signalName - "Phase", "Wobble", "x_axis","y_axis","introphase","speed".
> p2 - From what i can see it goes up to 1f (maybe).
> 
> Example: TASK::SET_TASK_MOVE_NETWORK_SIGNAL_FLOAT(PLAYER::PLAYER_PED_ID(), "Phase", 0.5);

## SET_TASK_MOVE_NETWORK_SIGNAL_FLOAT_LERP_RATE

```c
void SET_TASK_MOVE_NETWORK_SIGNAL_FLOAT_LERP_RATE(Ped ped, const char* signalName, float value)  // 0x8634CEF2522D987B
```

build 1493

## SET_TASK_MOVE_NETWORK_SIGNAL_LOCAL_FLOAT

```c
void SET_TASK_MOVE_NETWORK_SIGNAL_LOCAL_FLOAT(Ped ped, const char* signalName, float value)  // 0x373EF409B82697A3
```

build 1493 · old names: `_SET_TASK_MOVE_NETWORK_SIGNAL_FLOAT_2`

## SET_TASK_VEHICLE_CHASE_BEHAVIOR_FLAG

```c
void SET_TASK_VEHICLE_CHASE_BEHAVIOR_FLAG(Ped ped, int flag, BOOL set)  // 0xCC665AAC360D31E7
```

build 323

> Flag 8: Medium-aggressive boxing tactic with a bit of PIT
> Flag 1: Aggressive ramming of suspect
> Flag 2: Ram attempts
> Flag 32: Stay back from suspect, no tactical contact. Convoy-like.
> Flag 16: Ramming, seems to be slightly less aggressive than 1-2.

## SET_TASK_VEHICLE_CHASE_IDEAL_PURSUIT_DISTANCE

```c
void SET_TASK_VEHICLE_CHASE_IDEAL_PURSUIT_DISTANCE(Ped ped, float distance)  // 0x639B642FACBE4EDD
```

build 323

## STOP_ANIM_PLAYBACK

```c
void STOP_ANIM_PLAYBACK(Entity entity, int priority, BOOL secondary)  // 0xEE08C992D238C5D1
```

build 323

> Looks like p1 may be a flag, still need to do some research, though.

## STOP_ANIM_TASK

```c
void STOP_ANIM_TASK(Entity entity, const char* animDictionary, const char* animationName, float blendDelta)  // 0x97FF36A1D40EA00A
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## TASK_ACHIEVE_HEADING

```c
void TASK_ACHIEVE_HEADING(Ped ped, float heading, int timeout)  // 0x93B93A37987F1F3D
```

build 323

> Makes the specified ped achieve the specified heading.
> 
> pedHandle: The handle of the ped to assign the task to.
> heading: The desired heading.
> timeout: The time, in milliseconds, to allow the task to complete. If the task times out, it is cancelled, and the ped will stay at the heading it managed to reach in the time.

## TASK_AGITATED_ACTION_CONFRONT_RESPONSE

```c
void TASK_AGITATED_ACTION_CONFRONT_RESPONSE(Ped ped, Ped ped2)  // 0x19D1B791CB3670FE
```

build 877 · old names: `TASK_AGITATED_ACTION`

## TASK_AIM_GUN_AT_COORD

```c
void TASK_AIM_GUN_AT_COORD(Ped ped, float x, float y, float z, int time, BOOL instantBlendToAim, BOOL playAnimIntro)  // 0x6671F3EEC681BDA1
```

build 323

## TASK_AIM_GUN_AT_ENTITY

```c
void TASK_AIM_GUN_AT_ENTITY(Ped ped, Entity entity, int duration, BOOL instantBlendToAim)  // 0x9B53BB6E8943AF53
```

build 323

> duration: the amount of time in milliseconds to do the task.  -1 will keep the task going until either another task is applied, or CLEAR_ALL_TASKS() is called with the ped

## TASK_AIM_GUN_SCRIPTED

```c
void TASK_AIM_GUN_SCRIPTED(Ped ped, Hash scriptTask, BOOL disableBlockingClip, BOOL instantBlendToAim)  // 0x7A192BE16D373D00
```

build 323

## TASK_AIM_GUN_SCRIPTED_WITH_TARGET

```c
void TASK_AIM_GUN_SCRIPTED_WITH_TARGET(Ped ped, Ped target, float x, float y, float z, int gunTaskType, BOOL disableBlockingClip, BOOL forceAim)  // 0x8605AF0DE8B3A5AC
```

build 323

## TASK_ARREST_PED

```c
void TASK_ARREST_PED(Ped ped, Ped target)  // 0xF3B9A78A178572B1
```

build 323

> Example from "me_amanda1.ysc.c4":
> TASK::TASK_ARREST_PED(l_19F /* This is a Ped */ , PLAYER::PLAYER_PED_ID());
> 
> Example from "armenian1.ysc.c4":
> if (!PED::IS_PED_INJURED(l_B18[0/*1*/])) {
>     TASK::TASK_ARREST_PED(l_B18[0/*1*/], PLAYER::PLAYER_PED_ID());
> }
> 
> I would love to have time to experiment to see if a player Ped can arrest another Ped. Might make for a good cop mod.
> 
> 
> Looks like only the player can be arrested this way. Peds react and try to arrest you if you task them, but the player charater doesn't do anything if tasked to arrest another ped.

## TASK_BOAT_MISSION

```c
void TASK_BOAT_MISSION(Ped pedDriver, Vehicle vehicle, Vehicle targetVehicle, Ped targetPed, float x, float y, float z, int mission, float maxSpeed, int drivingStyle, float targetReached, Any boatFlags)  // 0x15C86013127CE63F
```

build 323

> You need to call PED::SET_BLOCKING_OF_NON_TEMPORARY_EVENTS after TASK_BOAT_MISSION in order for the task to execute.
> 
> Working example
> float vehicleMaxSpeed = VEHICLE::GET_VEHICLE_ESTIMATED_MAX_SPEED(ENTITY::GET_ENTITY_MODEL(pedVehicle));
> TASK::TASK_BOAT_MISSION(pedDriver, pedVehicle, 0, 0, waypointCoord.x, waypointCoord.y, waypointCoord.z, 4, vehicleMaxSpeed, 786469, -1.0, 7);
> PED::SET_BLOCKING_OF_NON_TEMPORARY_EVENTS(pedDriver, 1);
> 
> P8 appears to be driving style flag - see https://gtaforums.com/topic/822314-guide-driving-styles/ for documentation

## TASK_CHAT_TO_PED

```c
void TASK_CHAT_TO_PED(Ped ped, Ped target, int flags, float goToLocationX, float goToLocationY, float goToLocationZ, float headingDegs, float idleTime)  // 0x8C338E0263E4FD19
```

build 323

> p2 tend to be 16, 17 or 1
> p3 to p7 tend to be 0.0

## TASK_CLEAR_DEFENSIVE_AREA

```c
void TASK_CLEAR_DEFENSIVE_AREA(Ped ped)  // 0x95A6C46A31D1917D
```

build 323

## TASK_CLEAR_LOOK_AT

```c
void TASK_CLEAR_LOOK_AT(Ped ped)  // 0x0F804F1DB19B9689
```

build 323

## TASK_CLIMB

```c
void TASK_CLIMB(Ped ped, BOOL usePlayerLaunchForce)  // 0x89D9FCC2435112F1
```

build 323

> Climbs or vaults the nearest thing.
> usePlayerLaunchForce is unused.

## TASK_CLIMB_LADDER

```c
void TASK_CLIMB_LADDER(Ped ped, BOOL fast)  // 0xB6C987F9285A3814
```

build 323

## TASK_COMBAT_HATED_TARGETS_AROUND_PED

```c
void TASK_COMBAT_HATED_TARGETS_AROUND_PED(Ped ped, float radius, int combatFlags)  // 0x7BF835BB9E2698C8
```

build 323

> Despite its name, it only attacks ONE hated target. The one closest hated target.
> 
> p2 seems to be always 0

## TASK_COMBAT_HATED_TARGETS_AROUND_PED_TIMED

```c
void TASK_COMBAT_HATED_TARGETS_AROUND_PED_TIMED(Ped ped, float radius, int time, int combatFlags)  // 0x2BBA30B854534A0C
```

build 323

## TASK_COMBAT_HATED_TARGETS_IN_AREA

```c
void TASK_COMBAT_HATED_TARGETS_IN_AREA(Ped ped, float x, float y, float z, float radius, int combatFlags)  // 0x4CF5F55DAC3280A0
```

build 323

> Despite its name, it only attacks ONE hated target. The one closest to the specified position.

## TASK_COMBAT_PED

```c
void TASK_COMBAT_PED(Ped ped, Ped targetPed, int combatFlags, int threatResponseFlags)  // 0xF166E48407BAC484
```

build 323

> Makes the specified ped attack the target ped.
> p2 should be 0
> p3 should be 16

## TASK_COMBAT_PED_TIMED

```c
void TASK_COMBAT_PED_TIMED(Ped ped, Ped target, int time, int flags)  // 0x944F30DCB7096BDE
```

build 323

## TASK_COWER

```c
void TASK_COWER(Ped ped, int duration)  // 0x3EB1FE9E8E908E15
```

build 323

## TASK_DRIVE_BY

```c
void TASK_DRIVE_BY(Ped driverPed, Ped targetPed, Vehicle targetVehicle, float targetX, float targetY, float targetZ, float distanceToShoot, int pedAccuracy, BOOL pushUnderneathDrivingTaskIfDriving, Hash firingPattern)  // 0x2F8AF0E82773A171
```

build 323

> Example:
> 
> TASK::TASK_DRIVE_BY(l_467[1/*22*/], PLAYER::PLAYER_PED_ID(), 0, 0.0, 0.0, 2.0, 300.0, 100, 0, ${firing_pattern_burst_fire_driveby});
> 
> 
> 
> 
> Needs working example. Doesn't seem to do anything.
> 
> I marked p2 as targetVehicle as all these shooting related tasks seem to have that in common.
> I marked p6 as distanceToShoot as if you think of GTA's Logic with the native SET_VEHICLE_SHOOT natives, it won't shoot till it gets within a certain distance of the target.
> I marked p7 as pedAccuracy as it seems it's mostly 100 (Completely Accurate), 75, 90, etc. Although this could be the ammo count within the gun, but I highly doubt it. I will change this comment once I find out if it's ammo count or not.

## TASK_ENTER_VEHICLE

```c
void TASK_ENTER_VEHICLE(Ped ped, Vehicle vehicle, int timeout, int seat, float speed, int flag, const char* overrideEntryClipsetName)  // 0xC20E50AA46D09CA8
```

build 323

> speed 1.0 = walk, 2.0 = run
> p5 1 = normal, 3 = teleport to vehicle, 16 = teleport directly into vehicle
> p6 is always 0
> 
> Usage of seat 
> -1 = driver
> 0 = passenger
> 1 = left back seat
> 2 = right back seat
> 3 = outside left
> 4 = outside right

## TASK_EVERYONE_LEAVE_VEHICLE

```c
void TASK_EVERYONE_LEAVE_VEHICLE(Vehicle vehicle)  // 0x7F93691AB4B92272
```

build 323

## TASK_EXIT_COVER

```c
void TASK_EXIT_COVER(Ped ped, int exitType, float x, float y, float z)  // 0x79B258E397854D29
```

build 323

> p1 is 1, 2, or 3 in scripts

## TASK_EXTEND_ROUTE

```c
void TASK_EXTEND_ROUTE(float x, float y, float z)  // 0x1E7889778264843A
```

build 323

> MulleKD19: Adds a new point to the current point route. Call TASK_FLUSH_ROUTE before the first call to this. Call TASK_FOLLOW_POINT_ROUTE to make the Ped go the route.
> 
> A maximum of 8 points can be added.

## TASK_FLUSH_ROUTE

```c
void TASK_FLUSH_ROUTE()  // 0x841142A1376E9006
```

build 323

> MulleKD19: Clears the current point route. Call this before TASK_EXTEND_ROUTE and TASK_FOLLOW_POINT_ROUTE.

## TASK_FOLLOW_NAV_MESH_TO_COORD

```c
void TASK_FOLLOW_NAV_MESH_TO_COORD(Ped ped, float x, float y, float z, float moveBlendRatio, int time, float targetRadius, int flags, float targetHeading)  // 0x15D3A79D4E44B913
```

build 323

> If no timeout, set timeout to -1.

## TASK_FOLLOW_NAV_MESH_TO_COORD_ADVANCED

```c
void TASK_FOLLOW_NAV_MESH_TO_COORD_ADVANCED(Ped ped, float x, float y, float z, float moveBlendRatio, int time, float targetRadius, int flags, float slideToCoordHeading, float maxSlopeNavigable, float clampMaxSearchDistance, float targetHeading)  // 0x17F58B88D085DBAC
```

build 323

## TASK_FOLLOW_POINT_ROUTE

```c
void TASK_FOLLOW_POINT_ROUTE(Ped ped, float speed, int mode)  // 0x595583281858626E
```

build 323

> MulleKD19: Makes the ped go on the created point route.
> 
> ped: The ped to give the task to.
> speed: The speed to move at in m/s.
> int: Unknown. Can be 0, 1, 2 or 3.
> 
> Example:
> TASK_FLUSH_ROUTE();
> TASK_EXTEND_ROUTE(0f, 0f, 70f);
> TASK_EXTEND_ROUTE(10f, 0f, 70f);
> TASK_EXTEND_ROUTE(10f, 10f, 70f);
> TASK_FOLLOW_POINT_ROUTE(GET_PLAYER_PED(), 1f, 0);

## TASK_FOLLOW_TO_OFFSET_OF_ENTITY

```c
void TASK_FOLLOW_TO_OFFSET_OF_ENTITY(Ped ped, Entity entity, float offsetX, float offsetY, float offsetZ, float movementSpeed, int timeout, float stoppingRange, BOOL persistFollowing)  // 0x304AE42E357B8C7E
```

build 323

> p6 always -1
> p7 always 10.0
> p8 always 1

## TASK_FOLLOW_WAYPOINT_RECORDING

```c
void TASK_FOLLOW_WAYPOINT_RECORDING(Ped ped, const char* name, int p2, int p3, int p4)  // 0x0759591819534F7B
```

build 323

## TASK_FORCE_MOTION_STATE

```c
void TASK_FORCE_MOTION_STATE(Ped ped, Hash state, BOOL forceRestart)  // 0x4F056E1AFFEF17AB
```

build 323

> p2 always false
> 
> [30/03/2017] ins1de :
> 
> See FORCE_PED_MOTION_STATE

## TASK_GET_OFF_BOAT

```c
void TASK_GET_OFF_BOAT(Ped ped, Vehicle boat)  // 0x9C00E77AF14B2DFF
```

build 323 · old names: `_TASK_GET_OFF_BOAT`

## TASK_GO_STRAIGHT_TO_COORD

```c
void TASK_GO_STRAIGHT_TO_COORD(Ped ped, float x, float y, float z, float speed, int timeout, float targetHeading, float distanceToSlide)  // 0xD76B57B44F1E6F8B
```

build 323

## TASK_GO_STRAIGHT_TO_COORD_RELATIVE_TO_ENTITY

```c
void TASK_GO_STRAIGHT_TO_COORD_RELATIVE_TO_ENTITY(Ped ped, Entity entity, float x, float y, float z, float moveBlendRatio, int time)  // 0x61E360B7E040D12E
```

build 323

## TASK_GO_TO_COORD_AND_AIM_AT_HATED_ENTITIES_NEAR_COORD

```c
void TASK_GO_TO_COORD_AND_AIM_AT_HATED_ENTITIES_NEAR_COORD(Ped pedHandle, float goToLocationX, float goToLocationY, float goToLocationZ, float focusLocationX, float focusLocationY, float focusLocationZ, float speed, BOOL shootAtEnemies, float distanceToStopAt, float noRoadsDistance, BOOL useNavMesh, int navFlags, int taskFlags, Hash firingPattern)  // 0xA55547801EB331FC
```

build 323

> The ped will walk or run towards goToLocation, aiming towards goToLocation or focusLocation (depending on the aimingFlag) and shooting if shootAtEnemies = true to any enemy in his path.
> 
> If the ped is closer than noRoadsDistance, the ped will ignore pathing/navmesh and go towards goToLocation directly. This could cause the ped to get stuck behind tall walls if the goToLocation is on the other side. To avoid this, use 0.0f and the ped will always use pathing/navmesh to reach his destination.
> 
> If the speed is set to 0.0f, the ped will just stand there while aiming, if set to 1.0f he will walk while aiming, 2.0f will run while aiming.
> 
> The ped will stop aiming when he is closer than distanceToStopAt to goToLocation.
> 
> I still can't figure out what unkTrue is used for. I don't notice any difference if I set it to false but in the decompiled scripts is always true.
> 
> I think that unkFlag, like the driving styles, could be a flag that "work as a list of 32 bits converted to a decimal integer. Each bit acts as a flag, and enables or disables a function". What leads me to this conclusion is the fact that in the decompiled scripts, unkFlag takes values like: 0, 1, 5 (101 in binary) and 4097 (4096 + 1 or 1000000000001 in binary). For now, I don't know what behavior enable or disable this possible flag so I leave it at 0.
> 
> Note: After some testing, using unkFlag = 16 (0x10) enables the use of sidewalks while moving towards goToLocation.
> 
> The aimingFlag takes 2 values: 0 to aim at the focusLocation, 1 to aim at where the ped is heading (goToLocation).
> 
> Example:
> 
> enum AimFlag
> {
>    AimAtFocusLocation,
>    AimAtGoToLocation
> };
> 
> Vector3 goToLocation1 = { 996.2867f, 0, -2143.044f, 0, 28.4763f, 0 }; // remember the padding.
> 
> Vector3 goToLocation2 = { 990.2867f, 0, -2140.044f, 0, 28.4763f, 0 }; // remember the padding.
> 
> Vector3 focusLocation = { 994.3478f, 0, -2136.118f, 0, 29.2463f, 0 }; // the coord z should be a little higher, around +1.0f to avoid aiming at the ground
> 
> // 1st example
> TASK::TASK_GO_TO_COORD_AND_AIM_AT_HATED_ENTITIES_NEAR_COORD(pedHandle, goToLocation1.x, goToLocation1.y, goToLocation1.z, focusLocation.x, focusLocation.y, focusLocation.z, 2.0f /*run*/, true /*shoot*/, 3.0f /*stop at*/, 0.0f /*noRoadsDistance*/, true /*always true*/, 0 /*possible flag*/, AimFlag::AimAtGoToLocation, -957453492 /*FullAuto pattern*/);
> 
> // 2nd example
> TASK::TASK_GO_TO_COORD_AND_AIM_AT_HATED_ENTITIES_NEAR_COORD(pedHandle, goToLocation2.x, goToLocation2.y, goToLocation2.z, focusLocation.x, focusLocation.y, focusLocation.z, 1.0f /*walk*/, false /*don't shoot*/, 3.0f /*stop at*/, 0.0f /*noRoadsDistance*/, true /*always true*/, 0 /*possible flag*/, AimFlag::AimAtFocusLocation, -957453492 /*FullAuto pattern*/);
> 
> 
> 1st example: The ped (pedhandle) will run towards goToLocation1. While running and aiming towards goToLocation1, the ped will shoot on sight to any enemy in his path, using "FullAuto" firing pattern. The ped will stop once he is closer than distanceToStopAt to goToLocation1.
> 
> 2nd example: The ped will walk towards goToLocation2. This time, while walking towards goToLocation2 and aiming at focusLocation, the ped will point his weapon on sight to any enemy in his path without shooting. The ped will stop once he is closer than distanceToStopAt to goToLocation2.

## TASK_GO_TO_COORD_ANY_MEANS

```c
void TASK_GO_TO_COORD_ANY_MEANS(Ped ped, float x, float y, float z, float moveBlendRatio, Vehicle vehicle, BOOL useLongRangeVehiclePathing, int drivingFlags, float maxRangeToShootTargets)  // 0x5BC448CB78FA3E88
```

build 323

> example from fm_mission_controller
> 
> TASK::TASK_GO_TO_COORD_ANY_MEANS(l_649, sub_f7e86(-1, 0), 1.0, 0, 0, 786603, 0xbf800000);
>  

## TASK_GO_TO_COORD_ANY_MEANS_EXTRA_PARAMS

```c
void TASK_GO_TO_COORD_ANY_MEANS_EXTRA_PARAMS(Ped ped, float x, float y, float z, float moveBlendRatio, Vehicle vehicle, BOOL useLongRangeVehiclePathing, int drivingFlags, float maxRangeToShootTargets, float extraVehToTargetDistToPreferVehicle, float driveStraightLineDistance, int extraFlags, float warpTimerMS)  // 0x1DD45F9ECFDB1BC9
```

build 323

## TASK_GO_TO_COORD_ANY_MEANS_EXTRA_PARAMS_WITH_CRUISE_SPEED

```c
void TASK_GO_TO_COORD_ANY_MEANS_EXTRA_PARAMS_WITH_CRUISE_SPEED(Ped ped, float x, float y, float z, float moveBlendRatio, Vehicle vehicle, BOOL useLongRangeVehiclePathing, int drivingFlags, float maxRangeToShootTargets, float extraVehToTargetDistToPreferVehicle, float driveStraightLineDistance, int extraFlags, float cruiseSpeed, float targetArriveDist)  // 0xB8ECD61F531A7B02
```

build 323

## TASK_GO_TO_COORD_WHILE_AIMING_AT_COORD

```c
void TASK_GO_TO_COORD_WHILE_AIMING_AT_COORD(Ped ped, float x, float y, float z, float aimAtX, float aimAtY, float aimAtZ, float moveBlendRatio, BOOL shoot, float targetRadius, float slowDistance, BOOL useNavMesh, int navFlags, BOOL instantBlendToAim, Hash firingPattern)  // 0x11315AB3385B8AC0
```

build 323

> movement_speed: mostly 2f, but also 1/1.2f, etc.
> p8: always false
> p9: 2f
> p10: 0.5f
> p11: true
> p12: 0 / 512 / 513, etc.
> p13: 0
> firing_pattern: ${firing_pattern_full_auto}, 0xC6EE6B4C

## TASK_GO_TO_COORD_WHILE_AIMING_AT_ENTITY

```c
void TASK_GO_TO_COORD_WHILE_AIMING_AT_ENTITY(Ped ped, float x, float y, float z, Entity aimAtID, float moveBlendRatio, BOOL shoot, float targetRadius, float slowDistance, BOOL useNavMesh, int navFlags, BOOL instantBlendToAim, Hash firingPattern, int time)  // 0xB2A16444EAD9AE47
```

build 323

## TASK_GO_TO_ENTITY

```c
void TASK_GO_TO_ENTITY(Entity entity, Entity target, int duration, float distance, float moveBlendRatio, float slowDownDistance, int flags)  // 0x6A071245EB0D1882
```

build 323

> The entity will move towards the target until time is over (duration) or get in target's range (distance). p5 and p6 are unknown, but you could leave p5 = 1073741824 or 100 or even 0 (didn't see any difference but on the decompiled scripts, they use 1073741824 mostly) and p6 = 0
> 
> Note: I've only tested it on entity -> ped and target -> vehicle. It could work differently on other entities, didn't try it yet.
> 
> Example: TASK::TASK_GO_TO_ENTITY(pedHandle, vehicleHandle, 5000, 4.0, 100, 1073741824, 0)
> 
> Ped will run towards the vehicle for 5 seconds and stop when time is over or when he gets 4 meters(?) around the vehicle (with duration = -1, the task duration will be ignored).
> 
> enum EGOTO_ENTITY_SCRIPT_FLAGS
> {
> 	EGOTO_ENTITY_NEVER_SLOW_FOR_PATH_LENGTH = 0x01,
> };

## TASK_GO_TO_ENTITY_WHILE_AIMING_AT_COORD

```c
void TASK_GO_TO_ENTITY_WHILE_AIMING_AT_COORD(Ped ped, Entity entity, float aimX, float aimY, float aimZ, float moveBlendRatio, BOOL shoot, float targetRadius, float slowDistance, BOOL useNavMesh, BOOL instantBlendToAim, Hash firingPattern)  // 0x04701832B739DCE5
```

build 323

## TASK_GO_TO_ENTITY_WHILE_AIMING_AT_ENTITY

```c
void TASK_GO_TO_ENTITY_WHILE_AIMING_AT_ENTITY(Ped ped, Entity entityToWalkTo, Entity entityToAimAt, float speed, BOOL shootatEntity, float targetRadius, float slowDistance, BOOL useNavMesh, BOOL instantBlendToAim, Hash firingPattern)  // 0x97465886D35210E9
```

build 323

> shootatEntity:
> If true, peds will shoot at Entity till it is dead.
> If false, peds will just walk till they reach the entity and will cease shooting.

## TASK_GOTO_ENTITY_AIMING

```c
void TASK_GOTO_ENTITY_AIMING(Ped ped, Entity target, float distanceToStopAt, float StartAimingDist)  // 0xA9DA48FAB8A76C12
```

build 323

> eg
> 
>  TASK::TASK_GOTO_ENTITY_AIMING(v_2, PLAYER::PLAYER_PED_ID(), 5.0, 25.0);
> 
> ped = Ped you want to perform this task.
> target = the Entity they should aim at.
> distanceToStopAt = distance from the target, where the ped should stop to aim.
> StartAimingDist = distance where the ped should start to aim.

## TASK_GOTO_ENTITY_OFFSET

```c
void TASK_GOTO_ENTITY_OFFSET(Ped ped, Entity entity, int time, float seekRadius, float seekAngleDeg, float moveBlendRatio, int gotoEntityOffsetFlags)  // 0xE39B4FF4FDEBDE27
```

build 323

> enum ESEEK_ENTITY_OFFSET_FLAGS
> {
> 	ESEEK_OFFSET_ORIENTATES_WITH_ENTITY = 0x01,
> 	ESEEK_KEEP_TO_PAVEMENTS = 0x02
> };

## TASK_GOTO_ENTITY_OFFSET_XY

```c
void TASK_GOTO_ENTITY_OFFSET_XY(Ped ped, Entity entity, int duration, float targetRadius, float offsetX, float offsetY, float moveBlendRatio, int gotoEntityOffsetFlags)  // 0x338E7EF52B6095A9
```

build 323

## TASK_GUARD_ASSIGNED_DEFENSIVE_AREA

```c
void TASK_GUARD_ASSIGNED_DEFENSIVE_AREA(Ped ped, float x, float y, float z, float heading, float maxPatrolProximity, int timer)  // 0xD2A207EEBDF9889B
```

build 323

## TASK_GUARD_CURRENT_POSITION

```c
void TASK_GUARD_CURRENT_POSITION(Ped ped, float maxPatrolProximity, float defensiveAreaRadius, BOOL setDefensiveArea)  // 0x4A58A47A72E3FCB4
```

build 323

> From re_prisonvanbreak:
> 
> TASK::TASK_GUARD_CURRENT_POSITION(l_DD, 35.0, 35.0, 1);

## TASK_GUARD_SPHERE_DEFENSIVE_AREA

```c
void TASK_GUARD_SPHERE_DEFENSIVE_AREA(Ped ped, float defendPositionX, float defendPositionY, float defendPositionZ, float heading, float maxPatrolProximity, int time, float x, float y, float z, float defensiveAreaRadius)  // 0xC946FE14BE0EB5E2
```

build 323

## TASK_HANDS_UP

```c
void TASK_HANDS_UP(Ped ped, int duration, Ped facingPed, int timeToFacePed, int flags)  // 0xF2EAB31979A7F910
```

build 323

> In the scripts, p3 was always -1.
> 
> p3 seems to be duration or timeout of turn animation.
> Also facingPed can be 0 or -1 so ped will just raise hands up.

## TASK_HELI_CHASE

```c
void TASK_HELI_CHASE(Ped pilot, Entity entityToFollow, float x, float y, float z)  // 0xAC83B1DB38D0ADA0
```

build 323

> Ped pilot should be in a heli.
> EntityToFollow can be a vehicle or Ped.
> 
> x,y,z appear to be how close to the EntityToFollow the heli should be. Scripts use 0.0, 0.0, 80.0. Then the heli tries to position itself 80 units above the EntityToFollow. If you reduce it to -5.0, it tries to go below (if the EntityToFollow is a heli or plane)
> 
> 
> NOTE: If the pilot finds enemies, it will engage them, then remain there idle, not continuing to chase the Entity given.

## TASK_HELI_ESCORT_HELI

```c
void TASK_HELI_ESCORT_HELI(Ped pilot, Vehicle heli1, Vehicle heli2, float offsetX, float offsetY, float offsetZ)  // 0xB385523325077210
```

build 1290

## TASK_HELI_MISSION

```c
void TASK_HELI_MISSION(Ped pilot, Vehicle aircraft, Vehicle targetVehicle, Ped targetPed, float destinationX, float destinationY, float destinationZ, int missionFlag, float maxSpeed, float radius, float targetHeading, int maxHeight, int minHeight, float slowDownDistance, int behaviorFlags)  // 0xDAD029E187A2BEB4
```

build 323

> Must have targetVehicle, targetPed, OR destination X/Y/Z set
> Will follow targeted vehicle/ped, or fly to destination
> Set whichever is not being used to 0
> 
> 
> Mission mode type:
>  - 4, 7: Forces heli to snap to the heading if set, flies to destination or tracks specified entity (mode 4 only works for coordinates, 7 works for coordinates OR ped/vehicle)
>  - 6: Attacks the target ped/vehicle with mounted weapons. If radius is set, will maintain that distance from target.
>  - 8: Makes the heli flee from the ped/vehicle/coordinate
>  - 9: Circles around target ped/vehicle, snaps to angle if set. Behavior flag (last parameter) of 2048 switches from counter-clockwise to clockwise circling. Does not work with coordinate destination.
>  - 10, 11: Follows ped/vehicle target and imitates target heading. Only works with ped/vehicle target, not coord target
>  - 19: Heli lands at specified coordinate, ignores heading (lands facing whatever direction it is facing when the task is started)
>  - 20: Makes the heli land when near target ped. It won't resume chasing.
>  - 21: Emulates a helicopter crash
>  - 23: makes the heli circle erratically around ped
> 
> 
> Heli will fly at maxSpeed (up to actual maximum speed defined by the model's handling config)
> You can use SET_DRIVE_TASK_CRUISE_SPEED to modulate the speed based on distance to the target without having to re-invoke the task native. Setting to 8.0 when close to the destination results in a much smoother approach.
> 
> If minHeight and maxHeight are set, heli will fly between those specified elevations, relative to ground level and any obstructions/buildings below. You can specify -1 for either if you only want to specify one. Usually it is easiest to leave maxHeight at -1, and specify a reasonable minHeight to ensure clearance over any obstacles. Note this MUST be passed as an INT, not a FLOAT. 
> 
> Radius affects how closely the heli will follow tracked ped/vehicle, and when circling (mission type 9) sets the radius (in meters) that it will circle the target from
> 
> Heading is -1.0 for default behavior, which will point the nose of the helicopter towards the destination. Set a heading and the heli will lock to that direction when near its destination/target, but may still turn towards the destination when flying at higher speed from a further distance.
> 
> Behavior Flags is a bitwise value that modifies the AI behavior. Not clear what all flags do, but here are some guesses/notes:
>    1: Forces heading to face E
>    2: Unknown
>    4: Tight circles around coordinate destination
>    8: Unknown
>   16: Circles around coordinate destination facing towards destination
>   32: Flys to normally, then lands at coordinate destination and stays on the ground (using mission type 4)
>   64: Ignores obstacles when flying, will follow at specified minHeight above ground level but will not avoid buildings, vehicles, etc.
>  128: Unknown
>  256: Unknown
>  512: Unknown
> 1024: Unknown 
> 2048: Reverses direction of circling (mission type 9) to clockwise
> 4096: Hugs closer to the ground, maintains minHeight from ground generally, but barely clears buildings and dips down more between buildings instead of taking a more efficient/safe route
> 8192: Unknown
> 
> Unk3 is a float value, you may see -1082130432 for this value in decompiled native scripts, this is the equivalent to -1.0f. Seems to affect acceleration/aggressiveness, but not sure exactly how it works. Higher value seems to result in lower acceleration/less aggressive flying. Almost always -1.0 in native scripts, occasionally 20.0 or 50.0. Setting to 400.0 seems to work well for making the pilot not overshoot the destination when using coordinate destination.
> 
> Notes updated by PNWParksFan, May 2021
> 

## TASK_JUMP

```c
void TASK_JUMP(Ped ped, BOOL usePlayerLaunchForce, BOOL doSuperJump, BOOL useFullSuperJumpForce)  // 0x0AE4086104E067B1
```

build 323

> Definition is wrong. This has 4 parameters (Not sure when they were added. v350 has 2, v678 has 4).
> 
> v350: Ped ped, bool unused
> v678: Ped ped, bool unused, bool flag1, bool flag2
> 
> flag1 = super jump, flag2 = do nothing if flag1 is false and doubles super jump height if flag1 is true.

## TASK_LEAVE_ANY_VEHICLE

```c
void TASK_LEAVE_ANY_VEHICLE(Ped ped, int delayTime, int flags)  // 0x504D54DF3F6F2247
```

build 323

> Flags are the same flags used in TASK_LEAVE_VEHICLE

## TASK_LEAVE_VEHICLE

```c
void TASK_LEAVE_VEHICLE(Ped ped, Vehicle vehicle, int flags)  // 0xD3DBCE61A490BE02
```

build 323

> Flags from decompiled scripts:
> 0 = normal exit and closes door.
> 1 = normal exit and closes door.
> 16 = teleports outside, door kept closed.
> 64 = normal exit and closes door, maybe a bit slower animation than 0.
> 256 = normal exit but does not close the door.
> 4160 = ped is throwing himself out, even when the vehicle is still.
> 262144 = ped moves to passenger seat first, then exits normally
> 
> Others to be tried out: 320, 512, 131072.

## TASK_LOOK_AT_COORD

```c
void TASK_LOOK_AT_COORD(Entity entity, float x, float y, float z, int duration, int flags, int priority)  // 0x6FA46612594F7973
```

build 323

> enum eScriptLookatFlags
> {
> 	SLF_SLOW_TURN_RATE            = 1,    // turn the head toward the target slowly
> 	SLF_FAST_TURN_RATE            = 2,    // turn the head toward the target quickly
> 	SLF_EXTEND_YAW_LIMIT        = 4,    // wide yaw head limits
> 	SLF_EXTEND_PITCH_LIMIT        = 8,    // wide pitch head limit
> 	SLF_WIDEST_YAW_LIMIT        = 16,   // widest yaw head limit
> 	SLF_WIDEST_PITCH_LIMIT        = 32,   // widest pitch head limit
> 	SLF_NARROW_YAW_LIMIT        = 64,   // narrow yaw head limits
> 	SLF_NARROW_PITCH_LIMIT        = 128,  // narrow pitch head limit
> 	SLF_NARROWEST_YAW_LIMIT        = 256,  // narrowest yaw head limit
> 	SLF_NARROWEST_PITCH_LIMIT    = 512,  // narrowest pitch head limit
> 	SLF_USE_TORSO                = 1024, // use the torso aswell as the neck and head (currently disabled)
> 	SLF_WHILE_NOT_IN_FOV        = 2048, // keep tracking the target even if they are not in the hard coded FOV
> 	SLF_USE_CAMERA_FOCUS        = 4096, // use the camera as the target
> 	SLF_USE_EYES_ONLY            = 8192, // only track the target with the eyes  
> 	SLF_USE_LOOK_DIR            = 16384, // use information in look dir DOF
> 	SLF_FROM_SCRIPT                = 32768, // internal use only
> 	SLF_USE_REF_DIR_ABSOLUTE    = 65536  // use absolute reference direction mode for solver
> };

## TASK_LOOK_AT_ENTITY

```c
void TASK_LOOK_AT_ENTITY(Ped ped, Entity lookAt, int duration, int flags, int priority)  // 0x69F4BE8C8CC4796C
```

build 323

> For flags, please refer to TASK_LOOK_AT_COORD.

## TASK_MOVE_NETWORK_ADVANCED_BY_NAME

```c
void TASK_MOVE_NETWORK_ADVANCED_BY_NAME(Ped ped, const char* network, float x, float y, float z, float rotX, float rotY, float rotZ, int rotOrder, float blendDuration, BOOL allowOverrideCloneUpdate, const char* animDict, int flags)  // 0xD5B35BEA41919ACB
```

build 323 · old names: `_TASK_MOVE_NETWORK_ADVANCED`

> Example:
> TASK::TASK_MOVE_NETWORK_ADVANCED_BY_NAME(PLAYER::PLAYER_PED_ID(), "minigame_tattoo_michael_parts", 324.13f, 181.29f, 102.6f, 0.0f, 0.0f, 22.32f, 2, 0, false, 0, 0);

## TASK_MOVE_NETWORK_ADVANCED_BY_NAME_WITH_INIT_PARAMS

```c
void TASK_MOVE_NETWORK_ADVANCED_BY_NAME_WITH_INIT_PARAMS(Ped ped, const char* network, int* initialParameters, float x, float y, float z, float rotX, float rotY, float rotZ, int rotOrder, float blendDuration, BOOL allowOverrideCloneUpdate, const char* dictionary, int flags)  // 0x29682E2CCF21E9B5
```

build 1868

## TASK_MOVE_NETWORK_BY_NAME

```c
void TASK_MOVE_NETWORK_BY_NAME(Ped ped, const char* task, float multiplier, BOOL allowOverrideCloneUpdate, const char* animDict, int flags)  // 0x2D537BA194896636
```

build 323 · old names: `_TASK_MOVE_NETWORK`

> Example:
> TASK::TASK_MOVE_NETWORK_BY_NAME(PLAYER::PLAYER_PED_ID(), "arm_wrestling_sweep_paired_a_rev3", 0.0f, true, "mini@arm_wrestling", 0);

## TASK_MOVE_NETWORK_BY_NAME_WITH_INIT_PARAMS

```c
void TASK_MOVE_NETWORK_BY_NAME_WITH_INIT_PARAMS(Ped ped, const char* network, int* initialParameters, float blendDuration, BOOL allowOverrideCloneUpdate, const char* animDict, int flags)  // 0x3D45B0B355C5E0C9
```

build 1493 · old names: `_TASK_MOVE_NETWORK_SCRIPTED`, `_TASK_MOVE_NETWORK_BY_NAME_WITH_INIT_PARAMS`

> Used only once in the scripts (am_mp_nightclub)

## TASK_OPEN_VEHICLE_DOOR

```c
void TASK_OPEN_VEHICLE_DOOR(Ped ped, Vehicle vehicle, int timeOut, int seat, float speed)  // 0x965791A9A488A062
```

build 323

> The given ped will try to open the nearest door to 'seat'.
> Example: telling the ped to open the door for the driver seat does not necessarily mean it will open the driver door, it may choose to open the passenger door instead if that one is closer.

## TASK_PARACHUTE

```c
void TASK_PARACHUTE(Ped ped, BOOL giveParachuteItem, BOOL instant)  // 0xD2F1C53C97EE81AB
```

build 323

> Second parameter is unused.
> 
> second parameter was for jetpack in the early stages of gta and the hard coded code is now removed

## TASK_PARACHUTE_TO_TARGET

```c
void TASK_PARACHUTE_TO_TARGET(Ped ped, float x, float y, float z)  // 0xB33E291AFA6BD03A
```

build 323

> makes ped parachute to coords x y z. Works well with PATHFIND::GET_SAFE_COORD_FOR_PED

## TASK_PATROL

```c
void TASK_PATROL(Ped ped, const char* patrolRouteName, int alertState, BOOL canChatToPeds, BOOL useHeadLookAt)  // 0xBDA5DF49D080FE4E
```

build 323

> After looking at some scripts the second parameter seems to be an id of some kind. Here are some I found from some R* scripts:
> 
> "miss_Tower_01" (this went from 01 - 10)
> "miss_Ass0" (0, 4, 6, 3)
> "MISS_PATROL_8"
> 
> I think they're patrol routes, but I'm not sure. And I believe the 3rd parameter is a BOOL, but I can't confirm other than only seeing 0 and 1 being passed.
> 
> 
> As far as I can see the patrol routes names such as "miss_Ass0" have been defined earlier in the scripts. This leads me to believe we can defined our own new patrol routes by following the same approach. 
> From the scripts
> 
>     TASK::OPEN_PATROL_ROUTE("miss_Ass0");
>     TASK::ADD_PATROL_ROUTE_NODE(0, "WORLD_HUMAN_GUARD_STAND", l_738[0/*3*/], -139.4076690673828, -993.4732055664062, 26.2754, MISC::GET_RANDOM_INT_IN_RANGE(5000, 10000));
>     TASK::ADD_PATROL_ROUTE_NODE(1, "WORLD_HUMAN_GUARD_STAND", l_738[1/*3*/], -116.1391830444336, -987.4984130859375, 26.38541030883789, MISC::GET_RANDOM_INT_IN_RANGE(5000, 10000));
>     TASK::ADD_PATROL_ROUTE_NODE(2, "WORLD_HUMAN_GUARD_STAND", l_738[2/*3*/], -128.46847534179688, -979.0340576171875, 26.2754, MISC::GET_RANDOM_INT_IN_RANGE(5000, 10000));
>     TASK::ADD_PATROL_ROUTE_LINK(0, 1);
>     TASK::ADD_PATROL_ROUTE_LINK(1, 2);
>     TASK::ADD_PATROL_ROUTE_LINK(2, 0);
>     TASK::CLOSE_PATROL_ROUTE();
>     TASK::CREATE_PATROL_ROUTE();
> 
> 

## TASK_PAUSE

```c
void TASK_PAUSE(Ped ped, int ms)  // 0xE73A266DB0CA9042
```

build 323

> Stand still (?)

## TASK_PED_SLIDE_TO_COORD

```c
void TASK_PED_SLIDE_TO_COORD(Ped ped, float x, float y, float z, float heading, float speed)  // 0xD04FE6765D990A06
```

build 323

## TASK_PED_SLIDE_TO_COORD_HDG_RATE

```c
void TASK_PED_SLIDE_TO_COORD_HDG_RATE(Ped ped, float x, float y, float z, float heading, float speed, float headingChangeRate)  // 0x5A4A6A6D3DC64F52
```

build 323

## TASK_PERFORM_SEQUENCE

```c
void TASK_PERFORM_SEQUENCE(Ped ped, int taskSequenceId)  // 0x5ABA3986D90D8A3B
```

build 323

## TASK_PERFORM_SEQUENCE_FROM_PROGRESS

```c
void TASK_PERFORM_SEQUENCE_FROM_PROGRESS(Ped ped, int taskIndex, int progress1, int progress2)  // 0x89221B16730234F0
```

build 323

## TASK_PERFORM_SEQUENCE_LOCALLY

```c
void TASK_PERFORM_SEQUENCE_LOCALLY(Ped ped, int taskSequenceId)  // 0x8C33220C8D78CA0D
```

build 944

## TASK_PLANE_CHASE

```c
void TASK_PLANE_CHASE(Ped pilot, Entity entityToFollow, float x, float y, float z)  // 0x2D2386F273FF7A25
```

build 323

## TASK_PLANE_GOTO_PRECISE_VTOL

```c
void TASK_PLANE_GOTO_PRECISE_VTOL(Ped ped, Vehicle vehicle, float x, float y, float z, int flightHeight, int minHeightAboveTerrain, BOOL useDesiredOrientation, float desiredOrientation, BOOL autopilot)  // 0xF7F9DCCA89E7505B
```

build 1290

## TASK_PLANE_LAND

```c
void TASK_PLANE_LAND(Ped pilot, Vehicle plane, float runwayStartX, float runwayStartY, float runwayStartZ, float runwayEndX, float runwayEndY, float runwayEndZ)  // 0xBF19721FA34D32C0
```

build 323

## TASK_PLANE_MISSION

```c
void TASK_PLANE_MISSION(Ped pilot, Vehicle aircraft, Vehicle targetVehicle, Ped targetPed, float destinationX, float destinationY, float destinationZ, int missionFlag, float angularDrag, float targetReached, float targetHeading, float maxZ, float minZ, BOOL precise)  // 0x23703CD154E83B88
```

build 323

> EXAMPLE USAGE:
> 
> Fly around target (Precautiously, keeps high altitude):
> Function.Call(Hash.TASK_PLANE_MISSION, pilot, selectedAirplane, 0, 0, Target.X, Target.Y, Target.Z, 4, 100f, 0f, 90f, 0, 200f);
> 
> Fly around target (Dangerously, keeps VERY low altitude):
> Function.Call(Hash.TASK_PLANE_MISSION, pilot, selectedAirplane, 0, 0, Target.X, Target.Y, Target.Z, 4, 100f, 0f, 90f, 0, -500f);
> 
> Fly directly into target:
> Function.Call(Hash.TASK_PLANE_MISSION, pilot, selectedAirplane, 0, 0, Target.X, Target.Y, Target.Z, 4, 100f, 0f, 90f, 0, -5000f);
> 
> EXPANDED INFORMATION FOR ADVANCED USAGE (custom pilot)
> 
> 'physicsSpeed': (THIS IS NOT YOUR ORDINARY SPEED PARAMETER: READ!!)
> Think of this -first- as a radius value, not a true speed value.  The ACTUAL effective speed of the plane will be that of the maximum speed permissible to successfully fly in a -circle- with a radius of 'physicsSpeed'.  This also means that the plane must complete a circle before it can begin its "bombing run", its straight line pass towards the target.  p9 appears to influence the angle at which a "bombing run" begins, although I can't confirm yet.
> 
> VERY IMPORTANT: A "bombing run" will only occur if a plane can successfully determine a possible navigable route (the slower the value of 'physicsSpeed', the more precise the pilot can be due to less influence of physics on flightpath).  Otherwise, the pilot will continue to patrol around Destination (be it a dynamic Entity position vector or a fixed world coordinate vector.)
> 
> 0 = Plane's physics are almost entirely frozen, plane appears to "orbit" around precise destination point
> 1-299 = Blend of "frozen, small radius" vs. normal vs. "accelerated, hyperfast, large radius"
> 300+ =  Vehicle behaves entirely like a normal gameplay plane.
> 
> 'patrolBlend' (The lower the value, the more the Destination is treated as a "fly AT" rather than a "fly AROUND point".)
> 
> Scenario: Destination is an Entity on ground level, wide open field
> -5000 = Pilot kamikazes directly into Entity
> -1000 = Pilot flies extremely low -around- Entity, very prone to crashing
> -200 = Pilot flies lower than average around Entity.
> 0 = Pilot flies around Entity, normal altitude
> 200 = Pilot flies an extra eighty units or so higher than 0 while flying around Destination (this doesn't seem to correlate directly into distance units.)
> 
> -- Valid mission types found in the exe: --
> 
> 0 = None
> 1 = Unk
> 2 = CTaskVehicleRam
> 3 = CTaskVehicleBlock
> 4 = CTaskVehicleGoToPlane
> 5 = CTaskVehicleStop
> 6 = CTaskVehicleAttack
> 7 = CTaskVehicleFollow
> 8 = CTaskVehicleFleeAirborne
> 9= CTaskVehicleCircle
> 10 = CTaskVehicleEscort
> 15 = CTaskVehicleFollowRecording
> 16 = CTaskVehiclePoliceBehaviour
> 17 = CTaskVehicleCrash

## TASK_PLANE_TAXI

```c
void TASK_PLANE_TAXI(Ped pilot, Vehicle aircraft, float x, float y, float z, float cruiseSpeed, float targetReached)  // 0x92C360B5F15D2302
```

build 1103

## TASK_PLANT_BOMB

```c
void TASK_PLANT_BOMB(Ped ped, float x, float y, float z, float heading)  // 0x965FEC691D55E9BF
```

build 323

## TASK_PLAY_ANIM

```c
void TASK_PLAY_ANIM(Ped ped, const char* animDictionary, const char* animationName, float blendInSpeed, float blendOutSpeed, int duration, int flag, float playbackRate, BOOL lockX, BOOL lockY, BOOL lockZ)  // 0xEA47FE3719165B94
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> float speed > normal speed is 8.0f
> ----------------------
> 
> float speedMultiplier > multiply the playback speed
> ----------------------
> 
> int duration: time in millisecond
> ----------------------
> -1 _ _ _ _ _ _ _> Default (see flag)
> 0 _ _ _ _ _ _ _ > Not play at all
> Small value _ _ > Slow down animation speed
> Other _ _ _ _ _ > freeze player control until specific time (ms) has 
> _ _ _ _ _ _ _ _ _ passed. (No effect if flag is set to be 
> _ _ _ _ _ _ _ _ _ controllable.)
> 
> int flag:
> ----------------------
> enum eAnimationFlags
> {
>  ANIM_FLAG_NORMAL = 0,
>    ANIM_FLAG_REPEAT = 1,
>    ANIM_FLAG_STOP_LAST_FRAME = 2,
>    ANIM_FLAG_UPPERBODY = 16,
>    ANIM_FLAG_ENABLE_PLAYER_CONTROL = 32,
>    ANIM_FLAG_CANCELABLE = 120,
> };
> Odd number : loop infinitely
> Even number : Freeze at last frame
> Multiple of 4: Freeze at last frame but controllable
> 
> 01 to 15 > Full body
> 10 to 31 > Upper body
> 32 to 47 > Full body > Controllable
> 48 to 63 > Upper body > Controllable
> ...
> 001 to 255 > Normal
> 256 to 511 > Garbled
> ...
> 
> playbackRate:
> 
> values are between 0.0 and 1.0
> 
> 
> lockX:  
> 
> 0 in most cases 1 for rcmepsilonism8 and rcmpaparazzo_3
> > 1 for mini@sprunk
>  
> 
> lockY:
> 
> 0 in most cases 
> 1 for missfam5_yoga, missfra1mcs_2_crew_react
> 
> 
> lockZ: 
> 
>     0 for single player 
>     Can be 1 but only for MP 

## TASK_PLAY_ANIM_ADVANCED

```c
void TASK_PLAY_ANIM_ADVANCED(Ped ped, const char* animDict, const char* animName, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float animEnterSpeed, float animExitSpeed, int duration, Any flag, float animTime, int rotOrder, int ikFlags)  // 0x83CDB10EA29B370B
```

build 323

> It's similar to TASK_PLAY_ANIM, except the first 6 floats let you specify the initial position and rotation of the task. (Ped gets teleported to the position).
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## TASK_PLAY_PHONE_GESTURE_ANIMATION

```c
void TASK_PLAY_PHONE_GESTURE_ANIMATION(Ped ped, const char* animDict, const char* animation, const char* boneMaskType, float blendInDuration, float blendOutDuration, BOOL isLooping, BOOL holdLastFrame)  // 0x8FBB6758B3B3E9EC
```

build 323

> Known boneMaskTypes
> "BONEMASK_HEADONLY"
> "BONEMASK_HEAD_NECK_AND_ARMS"
> "BONEMASK_HEAD_NECK_AND_L_ARM"
> "BONEMASK_HEAD_NECK_AND_R_ARM"
> 
> p4 known args - 0.0f, 0.5f, 0.25f
> p5 known args - 0.0f, 0.25f
> p6 known args - 1 if a global if check is passed.
> p7 known args - 1 if a global if check is passed.
> 
> The values found above, I found within the 5 scripts this is ever called in. (fmmc_launcher, fm_deathmatch_controller, fm_impromptu_dm_controller, fm_mission_controller, and freemode).
> =========================================================
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## TASK_PUT_PED_DIRECTLY_INTO_COVER

```c
void TASK_PUT_PED_DIRECTLY_INTO_COVER(Ped ped, float x, float y, float z, int time, BOOL allowPeekingAndFiring, float blendInDuration, BOOL forceInitialFacingDirection, BOOL forceFaceLeft, int identifier, BOOL doEntry)  // 0x4172393E6BE1FECE
```

build 323

## TASK_PUT_PED_DIRECTLY_INTO_MELEE

```c
void TASK_PUT_PED_DIRECTLY_INTO_MELEE(Ped ped, Ped meleeTarget, float blendInDuration, float timeInMelee, float strafePhaseSync, int aiCombatFlags)  // 0x1C6CD14A876FFE39
```

build 323

> from armenian3.c4
> 
> TASK::TASK_PUT_PED_DIRECTLY_INTO_MELEE(PlayerPed, armenianPed, 0.0, -1.0, 0.0, 0);
> 

## TASK_RAPPEL_DOWN_WALL_USING_CLIPSET_OVERRIDE

```c
void TASK_RAPPEL_DOWN_WALL_USING_CLIPSET_OVERRIDE(Ped ped, float x1, float y1, float z1, float x2, float y2, float z2, float minZ, int ropeHandle, const char* clipSet, Any p10, Any p11)  // 0xEAF66ACDDC794793
```

build 1868 · old names: `TASK_RAPPEL_DOWN_WALL`

> Attaches a ped to a rope and allows player control to rappel down a wall. Disables all collisions while on the rope.
> p10: Usually 1 in the scripts, clipSet: Clipset to use for the task, minZ: Minimum Z that the player can descend to, ropeHandle: Rope to attach this task to created with ADD_ROPE

## TASK_RAPPEL_FROM_HELI

```c
void TASK_RAPPEL_FROM_HELI(Ped ped, float minHeightAboveGround)  // 0x09693B0312F91649
```

build 323

> minHeightAboveGround: the minimum height above ground the heli must be at before the ped can start rappelling
> 
> Only appears twice in the scripts.
> 
> TASK::TASK_RAPPEL_FROM_HELI(PLAYER::PLAYER_PED_ID(), 10.0f);
> TASK::TASK_RAPPEL_FROM_HELI(a_0, 10.0f);

## TASK_REACT_AND_FLEE_PED

```c
void TASK_REACT_AND_FLEE_PED(Ped ped, Ped fleeTarget)  // 0x72C896464915D1B1
```

build 323

## TASK_RELOAD_WEAPON

```c
void TASK_RELOAD_WEAPON(Ped ped, BOOL drawWeapon)  // 0x62D2916F56B9CD2D
```

build 323

> The 2nd param (drawWeapon) is not implemented.
> 
> -----------------------------------------------------------------------
> 
> The only occurrence I found in a R* script ("assassin_construction.ysc.c4"):
> 
>             if (((v_3 < v_4) && (TASK::GET_SCRIPT_TASK_STATUS(PLAYER::PLAYER_PED_ID(), 0x6a67a5cc) != 1)) && (v_5 > v_3)) {
>                 TASK::TASK_RELOAD_WEAPON(PLAYER::PLAYER_PED_ID(), 1);
>             }

## TASK_SCRIPTED_ANIMATION

```c
void TASK_SCRIPTED_ANIMATION(Ped ped, int* priorityLowData, int* priorityMidData, int* priorityHighData, float blendInDelta, float blendOutDelta)  // 0x126EF75F1E17ABE5
```

build 323

> From fm_mission_controller.c:
> reserve_network_mission_objects(get_num_reserved_mission_objects(0) + 1);
>            vVar28 = {0.094f, 0.02f, -0.005f};
>             vVar29 = {-92.24f, 63.64f, 150.24f};
>           func_253(&uVar30, joaat("prop_ld_case_01"), Global_1592429.imm_34757[iParam1 <268>], 1, 1, 0, 1);
>          set_entity_lod_dist(net_to_ent(uVar30), 500);
>          attach_entity_to_entity(net_to_ent(uVar30), iParam0, get_ped_bone_index(iParam0, 28422), vVar28, vVar29, 1, 0, 0, 0, 2, 1);
>            Var31.imm_4 = 1065353216;
>          Var31.imm_5 = 1065353216;
>          Var31.imm_9 = 1065353216;
>          Var31.imm_10 = 1065353216;
>             Var31.imm_14 = 1065353216;
>             Var31.imm_15 = 1065353216;
>             Var31.imm_17 = 1040187392;
>             Var31.imm_18 = 1040187392;
>             Var31.imm_19 = -1;
>             Var32.imm_4 = 1065353216;
>          Var32.imm_5 = 1065353216;
>          Var32.imm_9 = 1065353216;
>          Var32.imm_10 = 1065353216;
>             Var32.imm_14 = 1065353216;
>             Var32.imm_15 = 1065353216;
>             Var32.imm_17 = 1040187392;
>             Var32.imm_18 = 1040187392;
>             Var32.imm_19 = -1;
>             Var31 = 1;
>             Var31.imm_1 = "weapons@misc@jerrycan@mp_male";
>           Var31.imm_2 = "idle";
>            Var31.imm_20 = 1048633;
>            Var31.imm_4 = 0.5f;
>            Var31.imm_16 = get_hash_key("BONEMASK_ARMONLY_R");
>           task_scripted_animation(iParam0, &Var31, &Var32, &Var32, 0f, 0.25f);
>           set_model_as_no_longer_needed(joaat("prop_ld_case_01"));
>             remove_anim_dict("anim@heists@biolab@");

## TASK_SEEK_COVER_FROM_PED

```c
void TASK_SEEK_COVER_FROM_PED(Ped ped, Ped target, int duration, BOOL allowPeekingAndFiring)  // 0x84D32B3BEC531324
```

build 323

## TASK_SEEK_COVER_FROM_POS

```c
void TASK_SEEK_COVER_FROM_POS(Ped ped, float x, float y, float z, int duration, BOOL allowPeekingAndFiring)  // 0x75AC2B60386D89F2
```

build 323

## TASK_SEEK_COVER_TO_COORDS

```c
void TASK_SEEK_COVER_TO_COORDS(Ped ped, float x1, float y1, float z1, float x2, float y2, float z2, int timeout, BOOL shortRoute)  // 0x39246A6958EF072C
```

build 323

> p8 causes the ped to take the shortest route to the cover position. It may have something to do with navmesh or pathfinding mechanics.
> 
> from michael2:
> TASK::TASK_SEEK_COVER_TO_COORDS(ped, 967.5164794921875, -2121.603515625, 30.479299545288086, 978.94677734375, -2125.84130859375, 29.4752, -1, 1);
> 
> 
> appears to be shorter variation
> from michael3:
> TASK::TASK_SEEK_COVER_TO_COORDS(ped, -2231.011474609375, 263.6326599121094, 173.60195922851562, -1, 0);

## TASK_SEEK_COVER_TO_COVER_POINT

```c
void TASK_SEEK_COVER_TO_COVER_POINT(Ped ped, ScrHandle coverpoint, float x, float y, float z, int time, BOOL allowPeekingAndFiring)  // 0xD43D95C7A869447F
```

build 323

> p5 is always -1

## TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS

```c
void TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS(Ped ped, BOOL toggle)  // 0x90D2156198831D69
```

build 323

> I cant believe I have to define this, this is one of the best natives.
> 
> It makes the ped ignore basically all shocking events around it. Occasionally the ped may comment or gesture, but other than that they just continue their daily activities. This includes shooting and wounding the ped. And - most importantly - they do not flee.
> 
> Since it is a task, every time the native is called the ped will stop for a moment. 

## TASK_SET_DECISION_MAKER

```c
void TASK_SET_DECISION_MAKER(Ped ped, Hash decisionMakerId)  // 0xEB8517DDA73720DA
```

build 323

> p1 is always GET_HASH_KEY("empty") in scripts, for the rare times this is used

## TASK_SET_SPHERE_DEFENSIVE_AREA

```c
void TASK_SET_SPHERE_DEFENSIVE_AREA(Ped ped, float x, float y, float z, float radius)  // 0x933C06518B52A9A4
```

build 323

## TASK_SHARK_CIRCLE_COORD

```c
void TASK_SHARK_CIRCLE_COORD(Ped ped, float x, float y, float z, float moveBlendRatio, float radius)  // 0x60A19CF85FF4CEFA
```

build 3407

## TASK_SHOCKING_EVENT_REACT

```c
void TASK_SHOCKING_EVENT_REACT(Ped ped, int eventHandle)  // 0x452419CBD838065B
```

build 323

## TASK_SHOOT_AT_COORD

```c
void TASK_SHOOT_AT_COORD(Ped ped, float x, float y, float z, int duration, Hash firingPattern)  // 0x46A6CC01E0826106
```

build 323

> Firing Pattern Hash Information: https://pastebin.com/Px036isB

## TASK_SHOOT_AT_ENTITY

```c
void TASK_SHOOT_AT_ENTITY(Entity entity, Entity target, int duration, Hash firingPattern)  // 0x08DA95E8298AE772
```

build 323

> //this part of the code is to determine at which entity the player is aiming, for example if you want to create a mod where you give orders to peds
> Entity aimedentity;
> Player player = PLAYER::PLAYER_ID();
> PLAYER::_GET_AIMED_ENTITY(player, &aimedentity);
> 
> //bg is an array of peds
> TASK::TASK_SHOOT_AT_ENTITY(bg[i], aimedentity, 5000, MISC::GET_HASH_KEY("FIRING_PATTERN_FULL_AUTO"));
> 
> in practical usage, getting the entity the player is aiming at and then task the peds to shoot at the entity, at a button press event would be better.
> 
> Firing Pattern Hash Information: https://pastebin.com/Px036isB

## TASK_SHUFFLE_TO_NEXT_VEHICLE_SEAT

```c
void TASK_SHUFFLE_TO_NEXT_VEHICLE_SEAT(Ped ped, Vehicle vehicle, BOOL useAlternateShuffle)  // 0x7AA80209BDA643EB
```

build 323

> Makes the specified ped shuffle to the next vehicle seat.
> The ped MUST be in a vehicle and the vehicle parameter MUST be the ped's current vehicle.

## TASK_SKY_DIVE

```c
void TASK_SKY_DIVE(Ped ped, BOOL instant)  // 0x601736CFE536B0A0
```

build 323

## TASK_SMART_FLEE_COORD

```c
void TASK_SMART_FLEE_COORD(Ped ped, float x, float y, float z, float distance, int time, BOOL preferPavements, BOOL quitIfOutOfRange)  // 0x94587F17E9C365D5
```

build 323

> Makes the specified ped flee the specified distance from the specified position.

## TASK_SMART_FLEE_PED

```c
void TASK_SMART_FLEE_PED(Ped ped, Ped fleeTarget, float safeDistance, int fleeTime, BOOL preferPavements, BOOL updateToNearestHatedPed)  // 0x22B0D0E37CCB840D
```

build 323

> Makes a ped run away from another ped (fleeTarget).
> 
> distance = ped will flee this distance.
> fleeTime = ped will flee for this amount of time, set to "-1" to flee forever

## TASK_STAND_GUARD

```c
void TASK_STAND_GUARD(Ped ped, float x, float y, float z, float heading, const char* scenarioName)  // 0xAE032F8BBA959E90
```

build 323

> scenarioName example: "WORLD_HUMAN_GUARD_STAND"

## TASK_STAND_STILL

```c
void TASK_STAND_STILL(Ped ped, int time)  // 0x919BE13EED931959
```

build 323

> Makes the specified ped stand still for (time) milliseconds.

## TASK_START_SCENARIO_AT_POSITION

```c
void TASK_START_SCENARIO_AT_POSITION(Ped ped, const char* scenarioName, float x, float y, float z, float heading, int duration, BOOL sittingScenario, BOOL teleport)  // 0xFA4EFC79F69D4F07
```

build 323

> Full list of ped scenarios by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenariosCompact.json
> 
> Also a few more listed at TASK::TASK_START_SCENARIO_IN_PLACE just above.
> ---------------
> The first parameter in every scenario has always been a Ped of some sort. The second like TASK_START_SCENARIO_IN_PLACE is the name of the scenario. 
> 
> The next 4 parameters were harder to decipher. After viewing "hairdo_shop_mp.ysc.c4", and being confused from seeing the case in other scripts, they passed the first three of the arguments as one array from a function, and it looked like it was obviously x, y, and z.
> 
> I haven't seen the sixth parameter go to or over 360, making me believe that it is rotation, but I really can't confirm anything.
> 
> I have no idea what the last 3 parameters are, but I'll try to find out.
> 
> -going on the last 3 parameters, they appear to always be "0, 0, 1"
> 
> p6 -1 also used in scrips
> 
> p7 used for sitting scenarios
> 
> p8 teleports ped to position

## TASK_START_SCENARIO_IN_PLACE

```c
void TASK_START_SCENARIO_IN_PLACE(Ped ped, const char* scenarioName, int unkDelay, BOOL playEnterAnim)  // 0x142A02425FF02BD9
```

build 323

> Plays a scenario on a Ped at their current location.
> 
> unkDelay - Usually 0 or -1, doesn't seem to have any effect. Might be a delay between sequences.
> playEnterAnim - Plays the "Enter" anim if true, otherwise plays the "Exit" anim. Scenarios that don't have any "Enter" anims won't play if this is set to true.
> 
> ----
> 
> From "am_hold_up.ysc.c4" at line 339:
> 
> TASK::TASK_START_SCENARIO_IN_PLACE(NETWORK::NET_TO_PED(l_8D._f4), sub_adf(), 0, 1);
> 
> I'm unsure of what the last two parameters are, however sub_adf() randomly returns 1 of 3 scenarios, those being:
> WORLD_HUMAN_SMOKING
> WORLD_HUMAN_HANG_OUT_STREET
> WORLD_HUMAN_STAND_MOBILE
> 
> This makes sense, as these are what I commonly see when going by a liquor store.
> -------------------------
> List of scenarioNames: https://pastebin.com/6mrYTdQv
> 
> Also these:
> WORLD_FISH_FLEE
> DRIVE
> WORLD_HUMAN_HIKER
> WORLD_VEHICLE_ATTRACTOR
> WORLD_VEHICLE_BICYCLE_MOUNTAIN
> WORLD_VEHICLE_BIKE_OFF_ROAD_RACE
> WORLD_VEHICLE_BIKER
> WORLD_VEHICLE_CONSTRUCTION_PASSENGERS
> WORLD_VEHICLE_CONSTRUCTION_SOLO
> WORLD_VEHICLE_DRIVE_PASSENGERS
> WORLD_VEHICLE_DRIVE_SOLO
> WORLD_VEHICLE_EMPTY
> WORLD_VEHICLE_PARK_PARALLEL
> WORLD_VEHICLE_PARK_PERPENDICULAR_NOSE_IN
> WORLD_VEHICLE_POLICE_BIKE
> WORLD_VEHICLE_POLICE_CAR
> WORLD_VEHICLE_POLICE_NEXT_TO_CAR
> WORLD_VEHICLE_SALTON_DIRT_BIKE
> WORLD_VEHICLE_TRUCK_LOGS
> 
> Full list of ped scenarios by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenariosCompact.json

## TASK_STAY_IN_COVER

```c
void TASK_STAY_IN_COVER(Ped ped)  // 0xE5DA8615A6180789
```

build 323

> Makes the ped run to take cover

## TASK_STEALTH_KILL

```c
void TASK_STEALTH_KILL(Ped killer, Ped target, Hash stealthKillActionResultHash, float desiredMoveBlendRatio, int stealthFlags)  // 0xAA5DC05579D60BD9
```

build 323

> known "killTypes" are: "AR_stealth_kill_knife" and "AR_stealth_kill_a".

## TASK_STOP_PHONE_GESTURE_ANIMATION

```c
void TASK_STOP_PHONE_GESTURE_ANIMATION(Ped ped, float blendOutOverride)  // 0x3FA00D4F4641BFAE
```

build 323 · old names: `_TASK_STOP_PHONE_GESTURE_ANIMATION`

## TASK_SUBMARINE_GOTO_AND_STOP

```c
void TASK_SUBMARINE_GOTO_AND_STOP(Ped ped, Vehicle submarine, float x, float y, float z, BOOL autopilot)  // 0xC22B40579A498CA4
```

build 2189

> Used in am_vehicle_spawn.ysc and am_mp_submarine.ysc.
> 
> p0 is always 0, p5 is always 1
> 
> p1 is the vehicle handle of the submarine. Submarine must have a driver, but the ped handle is not passed to the native.
> 
> Speed can be set by calling SET_DRIVE_TASK_CRUISE_SPEED after

## TASK_SWAP_WEAPON

```c
void TASK_SWAP_WEAPON(Ped ped, BOOL drawWeapon)  // 0xA21C51255B205245
```

build 323

## TASK_SWEEP_AIM_ENTITY

```c
void TASK_SWEEP_AIM_ENTITY(Ped ped, const char* animDict, const char* lowAnimName, const char* medAnimName, const char* hiAnimName, int runtime, Entity targetEntity, float turnRate, float blendInDuration)  // 0x2047C02158D6405A
```

build 323

> This function is called on peds in vehicles.
> 
> anim: animation name
> p2, p3, p4: "sweep_low", "sweep_med" or "sweep_high"
> p5: no idea what it does but is usually -1

## TASK_SWEEP_AIM_POSITION

```c
void TASK_SWEEP_AIM_POSITION(Ped ped, const char* animDict, const char* lowAnimName, const char* medAnimName, const char* hiAnimName, int runtime, float x, float y, float z, float turnRate, float blendInDuration)  // 0x7AFE8FDC10BC07D2
```

build 323

## TASK_SYNCHRONIZED_SCENE

```c
void TASK_SYNCHRONIZED_SCENE(Ped ped, int scene, const char* animDictionary, const char* animationName, float blendIn, float blendOut, int flags, int ragdollBlockingFlags, float moverBlendDelta, int ikFlags)  // 0xEEA929141F699854
```

build 323

>  TASK::TASK_SYNCHRONIZED_SCENE(ped, scene, "creatures@rottweiler@in_vehicle@std_car", "get_in", 1000.0, -8.0, 4, 0, 0x447a0000, 0);
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## TASK_THROW_PROJECTILE

```c
void TASK_THROW_PROJECTILE(Ped ped, float x, float y, float z, int ignoreCollisionEntityIndex, BOOL createInvincibleProjectile)  // 0x7285951DBF6B5A51
```

build 323

> In every case of this native, I've only seen the first parameter passed as 0, although I believe it's a Ped after seeing tasks around it using 0. That's because it's used in a Sequence Task.
> 
> The last 3 parameters are definitely coordinates after seeing them passed in other scripts, and even being used straight from the player's coordinates.
> ---
> It seems that - in the decompiled scripts - this native was used on a ped who was in a vehicle to throw a projectile out the window at the player. This is something any ped will naturally do if they have a throwable and they are doing driveby-combat (although not very accurately).
> It is possible, however, that this is how SWAT throws smoke grenades at the player when in cover.
> ----------------------------------------------------
> The first comment is right it definately is the ped as if you look in script finale_heist2b.c line 59628 in Xbox Scripts atleast you will see task_throw_projectile and the first param is Local_559[2 <14>] if you look above it a little bit line 59622 give_weapon_to_ped uses the same exact param Local_559[2 <14>] and we all know the first param of that native is ped. So it guaranteed has to be ped. 0 just may mean to use your ped by default for some reason.

## TASK_TOGGLE_DUCK

```c
void TASK_TOGGLE_DUCK(Ped ped, int toggleType)  // 0xAC96609B9995EDF8
```

build 323

> used in sequence task
> 
> both parameters seems to be always 0

## TASK_TURN_PED_TO_FACE_COORD

```c
void TASK_TURN_PED_TO_FACE_COORD(Ped ped, float x, float y, float z, int duration)  // 0x1DDA930A0AC38571
```

build 323

> duration in milliseconds

## TASK_TURN_PED_TO_FACE_ENTITY

```c
void TASK_TURN_PED_TO_FACE_ENTITY(Ped ped, Entity entity, int duration)  // 0x5AD23D40115353AC
```

build 323

> duration: the amount of time in milliseconds to do the task. -1 will keep the task going until either another task is applied, or CLEAR_ALL_TASKS() is called with the ped

## TASK_USE_MOBILE_PHONE

```c
void TASK_USE_MOBILE_PHONE(Ped ped, BOOL usePhone, int desiredPhoneMode)  // 0xBD2A8EC3AF4DE7DB
```

build 323

## TASK_USE_MOBILE_PHONE_TIMED

```c
void TASK_USE_MOBILE_PHONE_TIMED(Ped ped, int duration)  // 0x5EE02954A14C69DB
```

build 323

## TASK_USE_NEAREST_SCENARIO_CHAIN_TO_COORD

```c
void TASK_USE_NEAREST_SCENARIO_CHAIN_TO_COORD(Ped ped, float x, float y, float z, float maxRange, int timeToLeave)  // 0x9FDA1B3D7E7028B3
```

build 323

> p5 is always 0 in scripts

## TASK_USE_NEAREST_SCENARIO_CHAIN_TO_COORD_WARP

```c
void TASK_USE_NEAREST_SCENARIO_CHAIN_TO_COORD_WARP(Ped ped, float x, float y, float z, float radius, int timeToLeave)  // 0x97A28E63F0BA5631
```

build 323

> p5 is always -1 or 0 in scripts

## TASK_USE_NEAREST_SCENARIO_TO_COORD

```c
void TASK_USE_NEAREST_SCENARIO_TO_COORD(Ped ped, float x, float y, float z, float distance, int duration)  // 0x277F471BA9DB000B
```

build 323

> Updated variables
> 
> An alternative to TASK::TASK_USE_NEAREST_SCENARIO_TO_COORD_WARP. Makes the ped walk to the scenario instead.

## TASK_USE_NEAREST_SCENARIO_TO_COORD_WARP

```c
void TASK_USE_NEAREST_SCENARIO_TO_COORD_WARP(Ped ped, float x, float y, float z, float radius, int timeToLeave)  // 0x58E2E0F23F6B76C3
```

build 323

## TASK_VEHICLE_AIM_AT_COORD

```c
void TASK_VEHICLE_AIM_AT_COORD(Ped ped, float x, float y, float z)  // 0x447C1E9EF844BC0F
```

build 323

## TASK_VEHICLE_AIM_AT_PED

```c
void TASK_VEHICLE_AIM_AT_PED(Ped ped, Ped target)  // 0xE41885592B08B097
```

build 323

## TASK_VEHICLE_CHASE

```c
void TASK_VEHICLE_CHASE(Ped driver, Entity targetEnt)  // 0x3C08A8E30363B353
```

build 323

> chases targetEnt fast and aggressively
> --
> Makes ped (needs to be in vehicle) chase targetEnt.

## TASK_VEHICLE_DRIVE_TO_COORD

```c
void TASK_VEHICLE_DRIVE_TO_COORD(Ped ped, Vehicle vehicle, float x, float y, float z, float speed, Any p6, Hash vehicleModel, int drivingMode, float stopRange, float straightLineDistance)  // 0xE2A2AA2F659D77A7
```

build 323

> info about driving modes: https://gtaforums.com/topic/822314-guide-driving-styles/

## TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE

```c
void TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE(Ped ped, Vehicle vehicle, float x, float y, float z, float speed, int driveMode, float stopRange)  // 0x158BB33F920D360C
```

build 323

## TASK_VEHICLE_DRIVE_WANDER

```c
void TASK_VEHICLE_DRIVE_WANDER(Ped ped, Vehicle vehicle, float speed, int drivingStyle)  // 0x480142959D337D00
```

build 323

## TASK_VEHICLE_ESCORT

```c
void TASK_VEHICLE_ESCORT(Ped ped, Vehicle vehicle, Vehicle targetVehicle, int mode, float speed, int drivingStyle, float minDistance, int minHeightAboveTerrain, float noRoadsDistance)  // 0x0FA6E4B75F302400
```

build 323

> Makes a ped follow the targetVehicle with <minDistance> in between.
> 
> note: minDistance is ignored if drivingstyle is avoiding traffic, but Rushed is fine.
> 
> Mode: The mode defines the relative position to the targetVehicle. The ped will try to position its vehicle there.
> -1 = behind
> 0 = ahead
> 1 = left
> 2 = right
> 3 = back left
> 4 = back right
> 
> if the target is closer than noRoadsDistance, the driver will ignore pathing/roads and follow you directly.
> 
> Driving Styles guide: https://gtaforums.com/topic/822314-guide-driving-styles/

## TASK_VEHICLE_FOLLOW

```c
void TASK_VEHICLE_FOLLOW(Ped driver, Vehicle vehicle, Entity targetEntity, float speed, int drivingStyle, int minDistance)  // 0xFC545A9F0626E3B6
```

build 323 · old names: `_TASK_VEHICLE_FOLLOW`

> Makes a ped in a vehicle follow an entity (ped, vehicle, etc.)
> 
> drivingStyle: https://gtaforums.com/topic/822314-guide-driving-styles/

## TASK_VEHICLE_FOLLOW_WAYPOINT_RECORDING

```c
void TASK_VEHICLE_FOLLOW_WAYPOINT_RECORDING(Ped ped, Vehicle vehicle, const char* WPRecording, int p3, int p4, int p5, int p6, float p7, BOOL p8, float p9)  // 0x3123FAA6DB1CF7ED
```

build 323

> 
> 
> p2 = Waypoint recording string (found in update\update.rpf\x64\levels\gta5\waypointrec.rpf
> p3 = 786468
> p4 = 0
> p5 = 16
> p6 = -1 (angle?)
> p7/8/9 = usually v3.zero
> p10 = bool (repeat?)
> p11 = 1073741824
> 
> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json

## TASK_VEHICLE_GOTO_NAVMESH

```c
void TASK_VEHICLE_GOTO_NAVMESH(Ped ped, Vehicle vehicle, float x, float y, float z, float speed, int behaviorFlag, float stoppingRange)  // 0x195AEEB13CEFE2EE
```

build 323

> Differs from TASK_VEHICLE_DRIVE_TO_COORDS in that it will pick the shortest possible road route without taking one-way streets and other "road laws" into consideration.
> 
> WARNING:
> A behaviorFlag value of 0 will result in a clunky, stupid driver!
> 
> Recommended settings:
> speed = 30.0f,
> behaviorFlag = 156, 
> stoppingRange = 5.0f;
> 
> If you simply want to have your driver move to a fixed location, call it only once, or, when necessary in the event of interruption. 
> 
> If using this to continually follow a Ped who is on foot:  You will need to run this in a tick loop.  Call it in with the Ped's updated coordinates every 20 ticks or so and you will have one hell of a smart, fast-reacting NPC driver -- provided he doesn't get stuck.  If your update frequency is too fast, the Ped may not have enough time to figure his way out of being stuck, and thus, remain stuck.  One way around this would be to implement an "anti-stuck" mechanism, which allows the driver to realize he's stuck, temporarily pause the tick, unstuck, then resume the tick.
> 
> EDIT: This is being discussed in more detail at https://gtaforums.com/topic/818504-any-idea-on-how-to-make-peds-clever-and-insanely-fast-c/

## TASK_VEHICLE_HELI_PROTECT

```c
void TASK_VEHICLE_HELI_PROTECT(Ped pilot, Vehicle vehicle, Entity entityToFollow, float targetSpeed, int drivingFlags, float radius, int altitude, int heliFlags)  // 0x1E09C32048FEFD1C
```

build 323

> pilot, vehicle and altitude are rather self-explanatory.
> 
> p4: is unused variable in the function.
> 
> entityToFollow: you can provide a Vehicle entity or a Ped entity, the heli will protect them.
> 
> 'targetSpeed':  The pilot will dip the nose AS MUCH AS POSSIBLE so as to reach this value AS FAST AS POSSIBLE.  As such, you'll want to modulate it as opposed to calling it via a hard-wired, constant #.
> 
> 'radius' isn't just "stop within radius of X of target" like with ground vehicles.  In this case, the pilot will fly an entire circle around 'radius' and continue to do so.
> 
> NOT CONFIRMED:  p7 appears to be a FlyingStyle enum.  Still investigating it as of this writing, but playing around with values here appears to result in different -behavior- as opposed to offsetting coordinates, altitude, target speed, etc.
> 
> NOTE: If the pilot finds enemies, it will engage them until it kills them, but will return to protect the ped/vehicle given shortly thereafter.

## TASK_VEHICLE_MISSION

```c
void TASK_VEHICLE_MISSION(Ped driver, Vehicle vehicle, Vehicle vehicleTarget, int missionType, float cruiseSpeed, int drivingStyle, float targetReached, float straightLineDistance, BOOL DriveAgainstTraffic)  // 0x659427E0EF36BCDE
```

build 323

> enum VehMissionType
> {
> 	MISSION_NONE,
> 	MISSION_CRUISE,
> 	MISSION_RAM,
> 	MISSION_BLOCK,
> 	MISSION_GOTO,
> 	MISSION_STOP,
> 	MISSION_ATTACK,
> 	MISSION_FOLLOW,
> 	MISSION_FLEE,
> 	MISSION_CIRCLE,
> 	MISSION_ESCORT_LEFT,
> 	MISSION_ESCORT_RIGHT,
> 	MISSION_ESCORT_REAR,
> 	MISSION_ESCORT_FRONT,
> 	MISSION_GOTO_RACING,
> 	MISSION_FOLLOW_RECORDING,
> 	MISSION_POLICE_BEHAVIOUR,
> 	MISSION_PARK_PERPENDICULAR,
> 	MISSION_PARK_PARALLEL,
> 	MISSION_LAND,
> 	MISSION_LAND_AND_WAIT,
> 	MISSION_CRASH,
> 	MISSION_PULL_OVER,
> 	MISSION_PROTECT,
> };

## TASK_VEHICLE_MISSION_COORS_TARGET

```c
void TASK_VEHICLE_MISSION_COORS_TARGET(Ped ped, Vehicle vehicle, float x, float y, float z, int mission, float cruiseSpeed, int drivingStyle, float targetReached, float straightLineDistance, BOOL DriveAgainstTraffic)  // 0xF0AF20AA7731F8C3
```

build 323

> See TASK_VEHICLE_MISSION

## TASK_VEHICLE_MISSION_PED_TARGET

```c
void TASK_VEHICLE_MISSION_PED_TARGET(Ped ped, Vehicle vehicle, Ped pedTarget, int missionType, float maxSpeed, int drivingStyle, float minDistance, float straightLineDistance, BOOL DriveAgainstTraffic)  // 0x9454528DF15D657A
```

build 323

> See TASK_VEHICLE_MISSION

## TASK_VEHICLE_PARK

```c
void TASK_VEHICLE_PARK(Ped ped, Vehicle vehicle, float x, float y, float z, float heading, int mode, float radius, BOOL keepEngineOn)  // 0x0F3E34E968EA374E
```

build 323

> Modes:
> 0 - ignore heading
> 1 - park forward
> 2 - park backwards
> 
> Depending on the angle of approach, the vehicle can park at the specified heading or at its exact opposite (-180) angle.
> 
> Radius seems to define how close the vehicle has to be -after parking- to the position for this task considered completed. If the value is too small, the vehicle will try to park again until it's exactly where it should be. 20.0 Works well but lower values don't, like the radius is measured in centimeters or something.

## TASK_VEHICLE_PLAY_ANIM

```c
void TASK_VEHICLE_PLAY_ANIM(Vehicle vehicle, const char* animationSet, const char* animationName)  // 0x69F5C3BD0F3EBD89
```

build 323

> Most probably plays a specific animation on vehicle. For example getting chop out of van etc...
> 
> Here's how its used - 
> 
> TASK::TASK_VEHICLE_PLAY_ANIM(l_325, "rcmnigel1b", "idle_speedo");
> 
> TASK::TASK_VEHICLE_PLAY_ANIM(l_556[0/*1*/], "missfra0_chop_drhome", "InCar_GetOutofBack_Speedo");
> 
> FYI : Speedo is the name of van in which chop was put in the mission.

## TASK_VEHICLE_SHOOT_AT_COORD

```c
void TASK_VEHICLE_SHOOT_AT_COORD(Ped ped, float x, float y, float z, float fireTolerance)  // 0x5190796ED39C9B6D
```

build 323

## TASK_VEHICLE_SHOOT_AT_PED

```c
void TASK_VEHICLE_SHOOT_AT_PED(Ped ped, Ped target, float fireTolerance)  // 0x10AB107B887214D8
```

build 323

## TASK_VEHICLE_TEMP_ACTION

```c
void TASK_VEHICLE_TEMP_ACTION(Ped driver, Vehicle vehicle, int action, int time)  // 0xC429DCEEB339E129
```

build 323

> '1 - brake
> '3 - brake + reverse
> '4 - turn left 90 + braking
> '5 - turn right 90 + braking
> '6 - brake strong (handbrake?) until time ends
> '7 - turn left + accelerate
> '8 - turn right + accelerate
> '9 - weak acceleration
> '10 - turn left + restore wheel pos to center in the end
> '11 - turn right + restore wheel pos to center in the end
> '13 - turn left + go reverse
> '14 - turn left + go reverse
> '16 - crash the game after like 2 seconds :)
> '17 - keep actual state, game crashed after few tries
> '18 - game crash
> '19 - strong brake + turn left/right
> '20 - weak brake + turn left then turn right
> '21 - weak brake + turn right then turn left
> '22 - brake + reverse
> '23 - accelerate fast
> '24 - brake
> '25 - brake turning left then when almost stopping it turns left more
> '26 - brake turning right then when almost stopping it turns right more
> '27 - brake until car stop or until time ends
> '28 - brake + strong reverse acceleration
> '30 - performs a burnout (brake until stop + brake and accelerate)
> '31 - accelerate + handbrake
> '32 - accelerate very strong
> 
> Seems to be this:
> Works on NPCs, but overrides their current task. If inside a task sequence (and not being the last task), "time" will work, otherwise the task will be performed forever until tasked with something else

## TASK_WANDER_IN_AREA

```c
void TASK_WANDER_IN_AREA(Ped ped, float x, float y, float z, float radius, float minimalLength, float timeBetweenWalks)  // 0xE054346CA3A0F315
```

build 323

## TASK_WANDER_SPECIFIC

```c
void TASK_WANDER_SPECIFIC(Ped ped, const char* conditionalAnimGroupStr, const char* conditionalAnimStr, float heading)  // 0x6919A2F136426098
```

build 1868

## TASK_WANDER_STANDARD

```c
void TASK_WANDER_STANDARD(Ped ped, float heading, int flags)  // 0xBB9CE077274F6A1B
```

build 323

> Makes ped walk around the area.
> 
> set p1 to 10.0f and p2 to 10 if you want the ped to walk anywhere without a duration.

## TASK_WARP_PED_DIRECTLY_INTO_COVER

```c
void TASK_WARP_PED_DIRECTLY_INTO_COVER(Ped ped, int time, BOOL allowPeekingAndFiring, BOOL forceInitialFacingDirection, BOOL forceFaceLeft, int identifier)  // 0x6E01E9E8D89F8276
```

build 2545

## TASK_WARP_PED_INTO_VEHICLE

```c
void TASK_WARP_PED_INTO_VEHICLE(Ped ped, Vehicle vehicle, int seat)  // 0x9A7D091411C5F684
```

build 323

> Seat Numbers
> -------------------------------
> Driver = -1
> Any = -2
> Left-Rear = 1
> Right-Front = 0
> Right-Rear = 2
> Extra seats = 3-14(This may differ from vehicle type e.g. Firetruck Rear Stand, Ambulance Rear)

## TASK_WRITHE

```c
void TASK_WRITHE(Ped ped, Ped target, int minFireLoops, int startState, BOOL forceShootOnGround, int shootFromGroundTimer)  // 0xCDDC2B77CE54AC6E
```

build 323

> EX: Function.Call(Ped1, Ped2, Time, 0);
> 
> The last parameter is always 0 for some reason I do not know. The first parameter is the pedestrian who will writhe to the pedestrian in the other parameter. The third paremeter is how long until the Writhe task ends. When the task ends, the ped will die. If set to -1, he will not die automatically, and the task will continue until something causes it to end. This can be being touched by an entity, being shot, explosion, going into ragdoll, having task cleared. Anything that ends the current task will kill the ped at this point.
> 
> 
> 
> Third parameter does not appear to be time. The last parameter is not implemented (It's not used, regardless of value).

## UNCUFF_PED

```c
void UNCUFF_PED(Ped ped)  // 0x67406F2C8F87FC4F
```

build 323

## UPDATE_TASK_AIM_GUN_SCRIPTED_TARGET

```c
void UPDATE_TASK_AIM_GUN_SCRIPTED_TARGET(Ped ped, Ped target, float x, float y, float z, BOOL disableBlockingClip)  // 0x9724FB59A3E72AD0
```

build 323

## UPDATE_TASK_HANDS_UP_DURATION

```c
void UPDATE_TASK_HANDS_UP_DURATION(Ped ped, int duration)  // 0xA98FCAFD7893C834
```

build 323

## UPDATE_TASK_SWEEP_AIM_ENTITY

```c
void UPDATE_TASK_SWEEP_AIM_ENTITY(Ped ped, Entity entity)  // 0xE4973DBDBE6E44B3
```

build 323

## UPDATE_TASK_SWEEP_AIM_POSITION

```c
void UPDATE_TASK_SWEEP_AIM_POSITION(Ped ped, float x, float y, float z)  // 0xBB106883F5201FC4
```

build 323

## USE_WAYPOINT_RECORDING_AS_ASSISTED_MOVEMENT_ROUTE

```c
void USE_WAYPOINT_RECORDING_AS_ASSISTED_MOVEMENT_ROUTE(const char* name, BOOL p1, float p2, float p3)  // 0x5A353B8E6B1095B5
```

build 323

## VEHICLE_WAYPOINT_PLAYBACK_GET_IS_PAUSED

```c
BOOL VEHICLE_WAYPOINT_PLAYBACK_GET_IS_PAUSED(Vehicle vehicle)  // 0xE435D3539EFDCD1B
```

build 3570

## VEHICLE_WAYPOINT_PLAYBACK_OVERRIDE_SPEED

```c
void VEHICLE_WAYPOINT_PLAYBACK_OVERRIDE_SPEED(Vehicle vehicle, float speed)  // 0x121F0593E0A431D7
```

build 323

## VEHICLE_WAYPOINT_PLAYBACK_PAUSE

```c
void VEHICLE_WAYPOINT_PLAYBACK_PAUSE(Vehicle vehicle)  // 0x8A4E6AC373666BC5
```

build 323

## VEHICLE_WAYPOINT_PLAYBACK_RESUME

```c
void VEHICLE_WAYPOINT_PLAYBACK_RESUME(Vehicle vehicle)  // 0xDC04FCAA7839D492
```

build 323

## VEHICLE_WAYPOINT_PLAYBACK_USE_DEFAULT_SPEED

```c
void VEHICLE_WAYPOINT_PLAYBACK_USE_DEFAULT_SPEED(Vehicle vehicle)  // 0x5CEB25A7D2848963
```

build 323

## WAYPOINT_PLAYBACK_GET_IS_PAUSED

```c
BOOL WAYPOINT_PLAYBACK_GET_IS_PAUSED(Any p0)  // 0x701375A7D43F01CB
```

build 323

## WAYPOINT_PLAYBACK_OVERRIDE_SPEED

```c
void WAYPOINT_PLAYBACK_OVERRIDE_SPEED(Any p0, float p1, BOOL p2)  // 0x7D7D2B47FA788E85
```

build 323

## WAYPOINT_PLAYBACK_PAUSE

```c
void WAYPOINT_PLAYBACK_PAUSE(Any p0, BOOL p1, BOOL p2)  // 0x0F342546AA06FED5
```

build 323

## WAYPOINT_PLAYBACK_RESUME

```c
void WAYPOINT_PLAYBACK_RESUME(Any p0, BOOL p1, Any p2, Any p3)  // 0x244F70C84C547D2D
```

build 323

## WAYPOINT_PLAYBACK_START_AIMING_AT_COORD

```c
void WAYPOINT_PLAYBACK_START_AIMING_AT_COORD(Ped ped, float x, float y, float z, BOOL p4)  // 0x8968400D900ED8B3
```

build 323

## WAYPOINT_PLAYBACK_START_AIMING_AT_PED

```c
void WAYPOINT_PLAYBACK_START_AIMING_AT_PED(Ped ped, Ped target, BOOL p2)  // 0x20E330937C399D29
```

build 323

## WAYPOINT_PLAYBACK_START_SHOOTING_AT_COORD

```c
void WAYPOINT_PLAYBACK_START_SHOOTING_AT_COORD(Ped ped, float x, float y, float z, BOOL p4, Hash firingPattern)  // 0x057A25CFCC9DB671
```

build 323

## WAYPOINT_PLAYBACK_START_SHOOTING_AT_PED

```c
void WAYPOINT_PLAYBACK_START_SHOOTING_AT_PED(Ped ped, Ped ped2, BOOL p2, BOOL p3)  // 0xE70BA7B90F8390DC
```

build 323

## WAYPOINT_PLAYBACK_STOP_AIMING_OR_SHOOTING

```c
void WAYPOINT_PLAYBACK_STOP_AIMING_OR_SHOOTING(Ped ped)  // 0x47EFA040EBB8E2EA
```

build 323

## WAYPOINT_PLAYBACK_USE_DEFAULT_SPEED

```c
void WAYPOINT_PLAYBACK_USE_DEFAULT_SPEED(Any p0)  // 0x6599D834B12D0800
```

build 323

## WAYPOINT_RECORDING_GET_CLOSEST_WAYPOINT

```c
BOOL WAYPOINT_RECORDING_GET_CLOSEST_WAYPOINT(const char* name, float x, float y, float z, int* point)  // 0xB629A298081F876F
```

build 323

> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json
> For a full list of the points, see here: goo.gl/wIH0vn

## WAYPOINT_RECORDING_GET_COORD

```c
BOOL WAYPOINT_RECORDING_GET_COORD(const char* name, int point, Vector3* coord)  // 0x2FB897405C90B361
```

build 323

> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json
> For a full list of the points, see here: goo.gl/wIH0vn

## WAYPOINT_RECORDING_GET_NUM_POINTS

```c
BOOL WAYPOINT_RECORDING_GET_NUM_POINTS(const char* name, int* points)  // 0x5343532C01A07234
```

build 323

> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json
> For a full list of the points, see here: goo.gl/wIH0vn

## WAYPOINT_RECORDING_GET_SPEED_AT_POINT

```c
float WAYPOINT_RECORDING_GET_SPEED_AT_POINT(const char* name, int point)  // 0x005622AEBC33ACA9
```

build 323

> Full list of waypoint recordings by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/waypointRecordings.json

