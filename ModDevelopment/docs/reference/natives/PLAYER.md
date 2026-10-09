# PLAYER natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ADD_PLAYER_TARGETABLE_ENTITY

```c
void ADD_PLAYER_TARGETABLE_ENTITY(Player player, Entity entity)  // 0x9097EB6D4BB9A12A
```

build 1868

## ALLOW_EVASION_HUD_IF_DISABLING_HIDDEN_EVASION_THIS_FRAME

```c
void ALLOW_EVASION_HUD_IF_DISABLING_HIDDEN_EVASION_THIS_FRAME(Player player, Any p1)  // 0x2F41A3BAE005E5FA
```

build 372

## ARE_PLAYER_FLASHING_STARS_ABOUT_TO_DROP

```c
BOOL ARE_PLAYER_FLASHING_STARS_ABOUT_TO_DROP(Player player)  // 0xAFAF86043E5874E9
```

build 323

## ARE_PLAYER_STARS_GREYED_OUT

```c
BOOL ARE_PLAYER_STARS_GREYED_OUT(Player player)  // 0x0A6EB355EE14A2DB
```

build 323

## ASSISTED_MOVEMENT_CLOSE_ROUTE

```c
void ASSISTED_MOVEMENT_CLOSE_ROUTE()  // 0xAEBF081FFC0A0E5E
```

build 323

## ASSISTED_MOVEMENT_FLUSH_ROUTE

```c
void ASSISTED_MOVEMENT_FLUSH_ROUTE()  // 0x8621390F0CDCFE1F
```

build 323

## CAN_PED_HEAR_PLAYER

```c
BOOL CAN_PED_HEAR_PLAYER(Player player, Ped ped)  // 0xF297383AA91DCA29
```

build 323

## CAN_PLAYER_START_MISSION

```c
BOOL CAN_PLAYER_START_MISSION(Player player)  // 0xDE7465A27D403C06
```

build 323

## CHANGE_PLAYER_PED

```c
void CHANGE_PLAYER_PED(Player player, Ped ped, BOOL p2, BOOL resetDamage)  // 0x048189FAC643DEEE
```

build 323

## CLEAR_PLAYER_HAS_DAMAGED_AT_LEAST_ONE_NON_ANIMAL_PED

```c
void CLEAR_PLAYER_HAS_DAMAGED_AT_LEAST_ONE_NON_ANIMAL_PED(Player player)  // 0x4AACB96203D11A31
```

build 323

## CLEAR_PLAYER_HAS_DAMAGED_AT_LEAST_ONE_PED

```c
void CLEAR_PLAYER_HAS_DAMAGED_AT_LEAST_ONE_PED(Player player)  // 0xF0B67A4DE6AB5F98
```

build 323

## CLEAR_PLAYER_PARACHUTE_MODEL_OVERRIDE

```c
void CLEAR_PLAYER_PARACHUTE_MODEL_OVERRIDE(Player player)  // 0x8753997EB5F6EE3F
```

build 323

## CLEAR_PLAYER_PARACHUTE_PACK_MODEL_OVERRIDE

```c
void CLEAR_PLAYER_PARACHUTE_PACK_MODEL_OVERRIDE(Player player)  // 0x10C54E4389C12B42
```

build 323

## CLEAR_PLAYER_PARACHUTE_VARIATION_OVERRIDE

```c
void CLEAR_PLAYER_PARACHUTE_VARIATION_OVERRIDE(Player player)  // 0x0F4CC924CF8C7B21
```

build 323

## CLEAR_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE

```c
void CLEAR_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE(Player player)  // 0x290D248E25815AE8
```

build 2372 · old names: `_CLEAR_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE`

## CLEAR_PLAYER_WANTED_LEVEL

```c
void CLEAR_PLAYER_WANTED_LEVEL(Player player)  // 0xB302540597885499
```

build 323

> This executes at the same as speed as PLAYER::SET_PLAYER_WANTED_LEVEL(player, 0, false);
> 
> PLAYER::GET_PLAYER_WANTED_LEVEL(player); executes in less than half the time. Which means that it's worth first checking if the wanted level needs to be cleared before clearing. However, this is mostly about good code practice and can important in other situations. The difference in time in this example is negligible. 

## DISABLE_CAMERA_VIEW_MODE_CYCLE

```c
void DISABLE_CAMERA_VIEW_MODE_CYCLE(Player player)  // 0x5501B7A5CDB79D37
```

build 323

## DISABLE_PLAYER_FIRING

```c
void DISABLE_PLAYER_FIRING(Player player, BOOL toggle)  // 0x5E6CC07646BBEAB8
```

build 323

> Inhibits the player from using any method of combat including melee and firearms.
> 
> NOTE: Only disables the firing for one frame

## DISABLE_PLAYER_HEALTH_RECHARGE

```c
void DISABLE_PLAYER_HEALTH_RECHARGE(Player player)  // 0xBCB06442F7E52666
```

build 2802

> Needs to be called every frame.

## DISABLE_PLAYER_THROW_GRENADE_WHILE_USING_GUN

```c
void DISABLE_PLAYER_THROW_GRENADE_WHILE_USING_GUN()  // 0xB885852C39CC265D
```

build 323

> Used only once in R* scripts (freemode.ysc).

## DISABLE_PLAYER_VEHICLE_REWARDS

```c
void DISABLE_PLAYER_VEHICLE_REWARDS(Player player)  // 0xC142BE3BB9CE125F
```

build 323

## DISPLAY_SYSTEM_SIGNIN_UI

```c
void DISPLAY_SYSTEM_SIGNIN_UI(BOOL p0)  // 0x94DD7888C10A979E
```

build 323

> Purpose of the BOOL currently unknown.
> Both, true and false, work

## ENABLE_SPECIAL_ABILITY

```c
void ENABLE_SPECIAL_ABILITY(Player player, BOOL toggle, Any p2)  // 0x181EC197DAEFE121
```

build 323

## EXTEND_WORLD_BOUNDARY_FOR_PLAYER

```c
void EXTEND_WORLD_BOUNDARY_FOR_PLAYER(float x, float y, float z)  // 0x5006D96C995A5827
```

build 323 · old names: `_EXPAND_WORLD_LIMITS`

> Appears only 3 times in the scripts, more specifically in michael1.ysc
> 
> -
> This can be used to prevent dying if you are "out of the world"

## FORCE_CLEANUP

```c
void FORCE_CLEANUP(int cleanupFlags)  // 0xBC8983F38F78ED51
```

build 323

> used with 1,2,8,64,128 in the scripts

## FORCE_CLEANUP_FOR_ALL_THREADS_WITH_THIS_NAME

```c
void FORCE_CLEANUP_FOR_ALL_THREADS_WITH_THIS_NAME(const char* name, int cleanupFlags)  // 0x4C68DDDDF0097317
```

build 323

> PLAYER::FORCE_CLEANUP_FOR_ALL_THREADS_WITH_THIS_NAME("pb_prostitute", 1); // Found in decompilation

## FORCE_CLEANUP_FOR_THREAD_WITH_THIS_ID

```c
void FORCE_CLEANUP_FOR_THREAD_WITH_THIS_ID(int id, int cleanupFlags)  // 0xF745B37630DF176B
```

build 323

## FORCE_START_HIDDEN_EVASION

```c
void FORCE_START_HIDDEN_EVASION(Player player)  // 0xAD73CE5A09E42D12
```

build 323

> This has been found in use in the decompiled files.

## GET_ACHIEVEMENT_PROGRESS

```c
int GET_ACHIEVEMENT_PROGRESS(int achievementId)  // 0x1C186837D0619335
```

build 323 · old names: `_GET_ACHIEVEMENT_PROGRESSION`, `_GET_ACHIEVEMENT_PROGRESS`

> For Steam.
> Always returns 0 in retail version of the game.

## GET_ARE_CAMERA_CONTROLS_DISABLED

```c
BOOL GET_ARE_CAMERA_CONTROLS_DISABLED()  // 0x7C814D2FB49F40C0
```

build 323 · old names: `_IS_PLAYER_CAM_CONTROL_DISABLED`

> Returns true when the player is not able to control the cam i.e. when running a benchmark test, switching the player or viewing a cutscene.
> 
> Note: I am not 100% sure if the native actually checks if the cam control is disabled but it seems promising.

## GET_CAUSE_OF_MOST_RECENT_FORCE_CLEANUP

```c
int GET_CAUSE_OF_MOST_RECENT_FORCE_CLEANUP()  // 0x9A41CF4674A12272
```

build 323

## GET_ENTITY_PLAYER_IS_FREE_AIMING_AT

```c
BOOL GET_ENTITY_PLAYER_IS_FREE_AIMING_AT(Player player, Entity* entity)  // 0x2975C866E6713290
```

build 323

> Returns TRUE if it found an entity in your crosshair within range of your weapon. Assigns the handle of the target to the *entity that you pass it.
> Returns false if no entity found.

## GET_IS_MOPPING_AREA_FREE_IN_FRONT_OF_PLAYER

```c
BOOL GET_IS_MOPPING_AREA_FREE_IN_FRONT_OF_PLAYER(Player player, float p1)  // 0xDD2620B7B9D16FF1
```

build 323

> 2 occurrences in agency_heist3a. p1 was 0.7f then 0.4f.

## GET_IS_PLAYER_DRIVING_ON_HIGHWAY

```c
BOOL GET_IS_PLAYER_DRIVING_ON_HIGHWAY(Player player)  // 0x5FC472C501CCADB3
```

build 323

> Appears once in "re_dealgonewrong"

## GET_IS_PLAYER_DRIVING_WRECKLESS

```c
BOOL GET_IS_PLAYER_DRIVING_WRECKLESS(Player player, int p1)  // 0xF10B44FD479D69F3
```

build 323

> Only 1 occurrence. p1 was 2.

## GET_IS_USING_FPS_THIRD_PERSON_COVER

```c
BOOL GET_IS_USING_FPS_THIRD_PERSON_COVER()  // 0xB9CF1F793A9F1BF1
```

build 323

> Returns profile setting 237.

## GET_IS_USING_HOOD_CAMERA

```c
BOOL GET_IS_USING_HOOD_CAMERA()  // 0xCB645E85E97EA48B
```

build 372

> Returns profile setting 243.

## GET_MAX_WANTED_LEVEL

```c
int GET_MAX_WANTED_LEVEL()  // 0x462E0DB9B137DC5F
```

build 323

> Gets the maximum wanted level the player can get.
> Ranges from 0 to 5.

## GET_NUMBER_OF_PLAYERS

```c
int GET_NUMBER_OF_PLAYERS()  // 0x407C7F91DDB46C16
```

build 323

> Gets the number of players in the current session.
> If not multiplayer, always returns 1.

## GET_NUMBER_OF_PLAYERS_IN_TEAM

```c
int GET_NUMBER_OF_PLAYERS_IN_TEAM(int team)  // 0x1FC200409F10E6F1
```

build 1180 · old names: `_GET_NUMBER_OF_PLAYERS_IN_TEAM`

## GET_PLAYER_CURRENT_STEALTH_NOISE

```c
float GET_PLAYER_CURRENT_STEALTH_NOISE(Player player)  // 0x2F395D61F3A1F877
```

build 323

## GET_PLAYER_DEBUG_INVINCIBLE

```c
BOOL GET_PLAYER_DEBUG_INVINCIBLE(Player player)  // 0xDCC07526B8EC45AF
```

build 1868

> Always returns false.

## GET_PLAYER_FAKE_WANTED_LEVEL

```c
int GET_PLAYER_FAKE_WANTED_LEVEL(Player player)  // 0x56105E599CAB0EFA
```

build 323

## GET_PLAYER_GROUP

```c
int GET_PLAYER_GROUP(Player player)  // 0x0D127585F77030AF
```

build 323

> Returns the group ID the player is member of.

## GET_PLAYER_HAS_RESERVE_PARACHUTE

```c
BOOL GET_PLAYER_HAS_RESERVE_PARACHUTE(Player player)  // 0x5DDFE2FF727F3CA3
```

build 323

## GET_PLAYER_HEALTH_RECHARGE_MAX_PERCENT

```c
float GET_PLAYER_HEALTH_RECHARGE_MAX_PERCENT(Player player)  // 0x8BC515BAE4AAF8FF
```

build 617 · old names: `_GET_PLAYER_HEALTH_RECHARGE_LIMIT`

## GET_PLAYER_INDEX

```c
Player GET_PLAYER_INDEX()  // 0xA5EDC40EF369B48D
```

build 323

> Returns the same as PLAYER_ID and NETWORK_PLAYER_ID_TO_INT

## GET_PLAYER_INVINCIBLE

```c
BOOL GET_PLAYER_INVINCIBLE(Player player)  // 0xB721981B2B939E07
```

build 323

> Returns the Player's Invincible status.
> 
> This function will always return false if SET_PLAYER_INVINCIBLE_BUT_HAS_REACTIONS is used to set the invincibility status. To always get the correct result, use this:
> 
>  bool IsPlayerInvincible(Player player)
>     {
>      auto addr = getScriptHandleBaseAddress(GET_PLAYER_PED(player)); 
> 
>         if (addr)
>      {
>          DWORD flag = *(DWORD *)(addr + 0x188);
>             return ((flag & (1 << 8)) != 0) || ((flag & (1 << 9)) != 0);
>       }
> 
>        return false;
>  }
> 
> 

## GET_PLAYER_MAX_ARMOUR

```c
int GET_PLAYER_MAX_ARMOUR(Player player)  // 0x92659B4CE1863CB3
```

build 323

## GET_PLAYER_NAME

```c
const char* GET_PLAYER_NAME(Player player)  // 0x6D0DE6A7B5DA71F8
```

build 323

## GET_PLAYER_PARACHUTE_MODEL_OVERRIDE

```c
Hash GET_PLAYER_PARACHUTE_MODEL_OVERRIDE(Player player)  // 0xC219887CA3E65C41
```

build 2372 · old names: `_GET_PLAYER_PARACHUTE_MODEL_OVERRIDE`

## GET_PLAYER_PARACHUTE_PACK_TINT_INDEX

```c
void GET_PLAYER_PARACHUTE_PACK_TINT_INDEX(Player player, int* tintIndex)  // 0x6E9C742F340CE5A2
```

build 323

## GET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR

```c
void GET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR(Player player, int* r, int* g, int* b)  // 0xEF56DBABD3CD4887
```

build 323

## GET_PLAYER_PARACHUTE_TINT_INDEX

```c
void GET_PLAYER_PARACHUTE_TINT_INDEX(Player player, int* tintIndex)  // 0x75D3F7A1B0D9B145
```

build 323

> Tints:
>   None = -1,
>     Rainbow = 0,
>   Red = 1,
>   SeasideStripes = 2,
>    WidowMaker = 3,
>    Patriot = 4,
>   Blue = 5,
>  Black = 6,
>     Hornet = 7,
>    AirFocce = 8,
>  Desert = 9,
>    Shadow = 10,
>   HighAltitude = 11,
>     Airbone = 12,
>  Sunrise = 13,

## GET_PLAYER_PED

```c
Ped GET_PLAYER_PED(Player player)  // 0x43A66C31C68491C0
```

build 323

> Gets the ped for a specified player index.

## GET_PLAYER_PED_SCRIPT_INDEX

```c
Ped GET_PLAYER_PED_SCRIPT_INDEX(Player player)  // 0x50FAC3A3E030A6E1
```

build 323

> Identical to PLAYER::GET_PLAYER_PED

## GET_PLAYER_RECEIVED_BATTLE_EVENT_RECENTLY

```c
BOOL GET_PLAYER_RECEIVED_BATTLE_EVENT_RECENTLY(Player player, int p1, BOOL p2)  // 0xBC0753C9CA14B506
```

build 323

## GET_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE

```c
Hash GET_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE(Player player)  // 0x37FAAA68DCA9D08D
```

build 2372 · old names: `_GET_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE`

## GET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX

```c
void GET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX(Player player, int* index)  // 0xD5A016BC3C09CF40
```

build 323

> Tints:
>   None = -1,
>     Rainbow = 0,
>   Red = 1,
>   SeasideStripes = 2,
>    WidowMaker = 3,
>    Patriot = 4,
>   Blue = 5,
>  Black = 6,
>     Hornet = 7,
>    AirFocce = 8,
>  Desert = 9,
>    Shadow = 10,
>   HighAltitude = 11,
>     Airbone = 12,
>  Sunrise = 13,

## GET_PLAYER_RGB_COLOUR

```c
void GET_PLAYER_RGB_COLOUR(Player player, int* r, int* g, int* b)  // 0xE902EF951DCE178F
```

build 323

## GET_PLAYER_SPRINT_STAMINA_REMAINING

```c
float GET_PLAYER_SPRINT_STAMINA_REMAINING(Player player)  // 0x3F9F16F8E65A7ED7
```

build 323

## GET_PLAYER_SPRINT_TIME_REMAINING

```c
float GET_PLAYER_SPRINT_TIME_REMAINING(Player player)  // 0x1885BC9B108B4C99
```

build 323

## GET_PLAYER_TARGET_ENTITY

```c
BOOL GET_PLAYER_TARGET_ENTITY(Player player, Entity* entity)  // 0x13EDE1A5DBF797C9
```

build 323

> Assigns the handle of locked-on melee target to *entity that you pass it.
> Returns false if no entity found.

## GET_PLAYER_TARGETING_MODE

```c
int GET_PLAYER_TARGETING_MODE()  // 0x875BDD898B99C8CE
```

build 3570

## GET_PLAYER_TEAM

```c
int GET_PLAYER_TEAM(Player player)  // 0x37039302F4E0A008
```

build 323

> Gets the player's team.
> Does nothing in singleplayer.

## GET_PLAYER_UNDERWATER_TIME_REMAINING

```c
float GET_PLAYER_UNDERWATER_TIME_REMAINING(Player player)  // 0xA1FCF8E6AF40B731
```

build 323

## GET_PLAYER_WANTED_CENTRE_POSITION

```c
Vector3 GET_PLAYER_WANTED_CENTRE_POSITION(Player player)  // 0x0C92BA89F1AF26F8
```

build 323

## GET_PLAYER_WANTED_LEVEL

```c
int GET_PLAYER_WANTED_LEVEL(Player player)  // 0xE28E54788CE8F12D
```

build 323

## GET_PLAYERS_LAST_VEHICLE

```c
Vehicle GET_PLAYERS_LAST_VEHICLE()  // 0xB6997A7EB3F5C8C0
```

build 323

> Alternative: GET_VEHICLE_PED_IS_IN(PLAYER_PED_ID(), 1);

## GET_TIME_SINCE_LAST_ARREST

```c
int GET_TIME_SINCE_LAST_ARREST()  // 0x5063F92F07C2A316
```

build 323

> Returns the time since the character was arrested in (ms) milliseconds.
> 
> example
> 
> var time = Function.call<int>(Hash.GET_TIME_SINCE_LAST_ARREST();
> 
> UI.DrawSubtitle(time.ToString());
> 
> if player has not been arrested, the int returned will be -1.

## GET_TIME_SINCE_LAST_DEATH

```c
int GET_TIME_SINCE_LAST_DEATH()  // 0xC7034807558DDFCA
```

build 323

> Returns the time since the character died in (ms) milliseconds.
> 
> example
> 
> var time = Function.call<int>(Hash.GET_TIME_SINCE_LAST_DEATH();
> 
> UI.DrawSubtitle(time.ToString());
> 
> if player has not died, the int returned will be -1.

## GET_TIME_SINCE_PLAYER_DROVE_AGAINST_TRAFFIC

```c
int GET_TIME_SINCE_PLAYER_DROVE_AGAINST_TRAFFIC(Player player)  // 0xDB89591E290D9182
```

build 323

## GET_TIME_SINCE_PLAYER_DROVE_ON_PAVEMENT

```c
int GET_TIME_SINCE_PLAYER_DROVE_ON_PAVEMENT(Player player)  // 0xD559D2BE9E37853B
```

build 323

## GET_TIME_SINCE_PLAYER_HIT_PED

```c
int GET_TIME_SINCE_PLAYER_HIT_PED(Player player)  // 0xE36A25322DC35F42
```

build 323

## GET_TIME_SINCE_PLAYER_HIT_VEHICLE

```c
int GET_TIME_SINCE_PLAYER_HIT_VEHICLE(Player player)  // 0x5D35ECF3A81A0EE0
```

build 323

## GET_WANTED_LEVEL_RADIUS

```c
float GET_WANTED_LEVEL_RADIUS(Player player)  // 0x085DEB493BE80812
```

build 323

> Remnant from GTA IV. Does nothing in GTA V.

## GET_WANTED_LEVEL_THRESHOLD

```c
int GET_WANTED_LEVEL_THRESHOLD(int wantedLevel)  // 0xFDD179EAF45B556C
```

build 323

> Drft

## GET_WANTED_LEVEL_TIME_TO_ESCAPE

```c
int GET_WANTED_LEVEL_TIME_TO_ESCAPE()  // 0xA72200F51875FEA4
```

build 2372 · old names: `_GET_WANTED_LEVEL_PAROLE_DURATION`

## GIVE_ACHIEVEMENT_TO_PLAYER

```c
BOOL GIVE_ACHIEVEMENT_TO_PLAYER(int achievementId)  // 0xBEC7076D64130195
```

build 323

> 1 - Welcome to Los Santos
> 2 - A Friendship Resurrected
> 3 - A Fair Day's Pay
> 4 - The Moment of Truth
> 5 - To Live or Die in Los Santos
> 6 - Diamond Hard
> 7 - Subversive
> 8 - Blitzed
> 9 - Small Town, Big Job
> 10 - The Government Gimps
> 11 - The Big One!
> 12 - Solid Gold, Baby!
> 13 - Career Criminal
> 14 - San Andreas Sightseer
> 15 - All's Fare in Love and War
> 16 - TP Industries Arms Race
> 17 - Multi-Disciplined
> 18 - From Beyond the Stars
> 19 - A Mystery, Solved
> 20 - Waste Management
> 21 - Red Mist
> 22 - Show Off
> 23 - Kifflom!
> 24 - Three Man Army
> 25 - Out of Your Depth
> 26 - Altruist Acolyte
> 27 - A Lot of Cheddar
> 28 - Trading Pure Alpha
> 29 - Pimp My Sidearm
> 30 - Wanted: Alive Or Alive
> 31 - Los Santos Customs
> 32 - Close Shave
> 33 - Off the Plane
> 34 - Three-Bit Gangster
> 35 - Making Moves
> 36 - Above the Law
> 37 - Numero Uno
> 38 - The Midnight Club
> 39 - Unnatural Selection
> 40 - Backseat Driver
> 41 - Run Like The Wind
> 42 - Clean Sweep
> 43 - Decorated
> 44 - Stick Up Kid
> 45 - Enjoy Your Stay
> 46 - Crew Cut
> 47 - Full Refund
> 48 - Dialling Digits
> 49 - American Dream
> 50 - A New Perspective
> 51 - Be Prepared
> 52 - In the Name of Science
> 53 - Dead Presidents
> 54 - Parole Day
> 55 - Shot Caller
> 56 - Four Way
> 57 - Live a Little
> 58 - Can't Touch This
> 59 - Mastermind
> 60 - Vinewood Visionary
> 61 - Majestic
> 62 - Humans of Los Santos
> 63 - First Time Director
> 64 - Animal Lover
> 65 - Ensemble Piece
> 66 - Cult Movie
> 67 - Location Scout
> 68 - Method Actor
> 69 - Cryptozoologist
> 70 - Getting Started
> 71 - The Data Breaches
> 72 - The Bogdan Problem
> 73 - The Doomsday Scenario
> 74 - A World Worth Saving
> 75 - Orbital Obliteration
> 76 - Elitist
> 77 - Masterminds

## GIVE_PLAYER_RAGDOLL_CONTROL

```c
void GIVE_PLAYER_RAGDOLL_CONTROL(Player player, BOOL toggle)  // 0x3C49C870E66F0A28
```

build 323

## HAS_ACHIEVEMENT_BEEN_PASSED

```c
BOOL HAS_ACHIEVEMENT_BEEN_PASSED(int achievementId)  // 0x867365E111A3B6EB
```

build 323

> See GIVE_ACHIEVEMENT_TO_PLAYER

## HAS_FORCE_CLEANUP_OCCURRED

```c
BOOL HAS_FORCE_CLEANUP_OCCURRED(int cleanupFlags)  // 0xC968670BFACE42D9
```

build 323

## HAS_PLAYER_BEEN_SPOTTED_IN_STOLEN_VEHICLE

```c
BOOL HAS_PLAYER_BEEN_SPOTTED_IN_STOLEN_VEHICLE(Player player)  // 0xD705740BB0A1CF4C
```

build 323

## HAS_PLAYER_DAMAGED_AT_LEAST_ONE_NON_ANIMAL_PED

```c
BOOL HAS_PLAYER_DAMAGED_AT_LEAST_ONE_NON_ANIMAL_PED(Player player)  // 0xE4B90F367BD81752
```

build 323

## HAS_PLAYER_DAMAGED_AT_LEAST_ONE_PED

```c
BOOL HAS_PLAYER_DAMAGED_AT_LEAST_ONE_PED(Player player)  // 0x20CE80B0C2BF4ACC
```

build 323

## HAS_PLAYER_LEFT_THE_WORLD

```c
BOOL HAS_PLAYER_LEFT_THE_WORLD(Player player)  // 0xD55DDFB47991A294
```

build 323

## INCREASE_PLAYER_JUMP_SUPPRESSION_RANGE

```c
void INCREASE_PLAYER_JUMP_SUPPRESSION_RANGE(Player player)  // 0x9EDD76E87D5D51BA
```

build 323

## INT_TO_PARTICIPANTINDEX

```c
int INT_TO_PARTICIPANTINDEX(int value)  // 0x9EC6603812C24710
```

build 323

> Simply returns whatever is passed to it (Regardless of whether the handle is valid or not).
> --------------------------------------------------------
> if (NETWORK::NETWORK_IS_PARTICIPANT_ACTIVE(PLAYER::INT_TO_PARTICIPANTINDEX(i)))
> 

## INT_TO_PLAYERINDEX

```c
Player INT_TO_PLAYERINDEX(int value)  // 0x41BD2A6B006AF756
```

build 323

> Simply returns whatever is passed to it (Regardless of whether the handle is valid or not).

## IS_PLAYER_BATTLE_AWARE

```c
BOOL IS_PLAYER_BATTLE_AWARE(Player player)  // 0x38D28DA81E4E9BF9
```

build 323

> Returns true if an unk value is greater than 0.0f

## IS_PLAYER_BEING_ARRESTED

```c
BOOL IS_PLAYER_BEING_ARRESTED(Player player, BOOL atArresting)  // 0x388A47C51ABDAC8E
```

build 323

> Return true while player is being arrested / busted.
> 
> If atArresting is set to 1, this function will return 1 when player is being arrested (while player is putting his hand up, but still have control)
> 
> If atArresting is set to 0, this function will return 1 only when the busted screen is shown.

## IS_PLAYER_BLUETOOTH_ENABLE

```c
BOOL IS_PLAYER_BLUETOOTH_ENABLE(Player player)  // 0x65FAEE425DE637B0
```

build 323

## IS_PLAYER_CLIMBING

```c
BOOL IS_PLAYER_CLIMBING(Player player)  // 0x95E8F73DC65EFB9C
```

build 323

> Returns TRUE if the player ('s ped) is climbing at the moment.

## IS_PLAYER_CONTROL_ON

```c
BOOL IS_PLAYER_CONTROL_ON(Player player)  // 0x49C32D60007AFA47
```

build 323

> Can the player control himself, used to disable controls for player for things like a cutscene.
> 
> ---
> 
> You can't disable controls with this, use SET_PLAYER_CONTROL(...) for this. 

## IS_PLAYER_DEAD

```c
BOOL IS_PLAYER_DEAD(Player player)  // 0x424D4687FA1E5652
```

build 323

## IS_PLAYER_FREE_AIMING

```c
BOOL IS_PLAYER_FREE_AIMING(Player player)  // 0x2E397FD2ECD37C87
```

build 323

> Gets a value indicating whether the specified player is currently aiming freely.

## IS_PLAYER_FREE_AIMING_AT_ENTITY

```c
BOOL IS_PLAYER_FREE_AIMING_AT_ENTITY(Player player, Entity entity)  // 0x3C06B5C839B38F7B
```

build 323

> Gets a value indicating whether the specified player is currently aiming freely at the specified entity.

## IS_PLAYER_FREE_FOR_AMBIENT_TASK

```c
BOOL IS_PLAYER_FREE_FOR_AMBIENT_TASK(Player player)  // 0xDCCFD3F106C36AB4
```

build 323

## IS_PLAYER_LOGGING_IN_NP

```c
BOOL IS_PLAYER_LOGGING_IN_NP()  // 0x74556E1420867ECA
```

build 323

> this function is hard-coded to always return 0.

## IS_PLAYER_ONLINE

```c
BOOL IS_PLAYER_ONLINE()  // 0xF25D331DC2627BBC
```

build 323

> Returns TRUE if the game is in online mode and FALSE if in offline mode.
> 
> This is an alias for NETWORK_IS_SIGNED_ONLINE.

## IS_PLAYER_PLAYING

```c
BOOL IS_PLAYER_PLAYING(Player player)  // 0x5E9564D8246B909A
```

build 323

> Checks whether the specified player has a Ped, the Ped is not dead, is not injured and is not arrested.

## IS_PLAYER_PRESSING_HORN

```c
BOOL IS_PLAYER_PRESSING_HORN(Player player)  // 0xFA1E2BF8B10598F9
```

build 323

## IS_PLAYER_READY_FOR_CUTSCENE

```c
BOOL IS_PLAYER_READY_FOR_CUTSCENE(Player player)  // 0x908CBECC2CAA3690
```

build 323

## IS_PLAYER_RIDING_TRAIN

```c
BOOL IS_PLAYER_RIDING_TRAIN(Player player)  // 0x4EC12697209F2196
```

build 323

> Returns true if the player is riding a train.

## IS_PLAYER_SCRIPT_CONTROL_ON

```c
BOOL IS_PLAYER_SCRIPT_CONTROL_ON(Player player)  // 0x8A876A65283DD7D7
```

build 323

## IS_PLAYER_TARGETTING_ANYTHING

```c
BOOL IS_PLAYER_TARGETTING_ANYTHING(Player player)  // 0x78CFE51896B6B8A4
```

build 323

## IS_PLAYER_TARGETTING_ENTITY

```c
BOOL IS_PLAYER_TARGETTING_ENTITY(Player player, Entity entity)  // 0x7912F7FC4F6264B6
```

build 323

## IS_PLAYER_TELEPORT_ACTIVE

```c
BOOL IS_PLAYER_TELEPORT_ACTIVE()  // 0x02B15662D7F8886F
```

build 323

## IS_PLAYER_VEHICLE_WEAPON_TOGGLED_TO_NON_HOMING

```c
BOOL IS_PLAYER_VEHICLE_WEAPON_TOGGLED_TO_NON_HOMING(Any p0)  // 0x6E4361FF3E8CD7CA
```

build 1011

## IS_PLAYER_WANTED_LEVEL_GREATER

```c
BOOL IS_PLAYER_WANTED_LEVEL_GREATER(Player player, int wantedLevel)  // 0x238DB2A2C23EE9EF
```

build 323

## IS_REMOTE_PLAYER_IN_NON_CLONED_VEHICLE

```c
BOOL IS_REMOTE_PLAYER_IN_NON_CLONED_VEHICLE(Player player)  // 0x690A61A6D13583F6
```

build 323

## IS_SPECIAL_ABILITY_ACTIVE

```c
BOOL IS_SPECIAL_ABILITY_ACTIVE(Player player, Any p1)  // 0x3E5F7FC85D854E15
```

build 323

## IS_SPECIAL_ABILITY_ENABLED

```c
BOOL IS_SPECIAL_ABILITY_ENABLED(Player player, Any p1)  // 0xB1D200FE26AEF3CB
```

build 323

## IS_SPECIAL_ABILITY_METER_FULL

```c
BOOL IS_SPECIAL_ABILITY_METER_FULL(Player player, Any p1)  // 0x05A1FE504B7F2587
```

build 323

## IS_SPECIAL_ABILITY_UNLOCKED

```c
BOOL IS_SPECIAL_ABILITY_UNLOCKED(Hash playerModel)  // 0xC6017F6A6CDFA694
```

build 323

## IS_SYSTEM_UI_BEING_DISPLAYED

```c
BOOL IS_SYSTEM_UI_BEING_DISPLAYED()  // 0x5D511E3867C87139
```

build 323

## IS_WANTED_AND_HAS_BEEN_SEEN_BY_COPS

```c
BOOL IS_WANTED_AND_HAS_BEEN_SEEN_BY_COPS(Player player)  // 0x7E07C78925D5FD96
```

build 372

## NETWORK_PLAYER_ID_TO_INT

```c
int NETWORK_PLAYER_ID_TO_INT()  // 0xEE68096F9F37341E
```

build 323

> Does exactly the same thing as PLAYER_ID()

## PLAYER_ATTACH_VIRTUAL_BOUND

```c
void PLAYER_ATTACH_VIRTUAL_BOUND(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7)  // 0xED51733DC73AED51
```

build 323

> Only 1 match. ob_sofa_michael.
> 
> PLAYER::PLAYER_ATTACH_VIRTUAL_BOUND(-804.5928f, 173.1801f, 71.68436f, 0f, 0f, 0.590625f, 1f, 0.7f);1.0.335.2, 1.0.350.1/2, 1.0.372.2, 1.0.393.2, 1.0.393.4, 1.0.463.1;

## PLAYER_DETACH_VIRTUAL_BOUND

```c
void PLAYER_DETACH_VIRTUAL_BOUND()  // 0x1DD5897E2FA6E7C9
```

build 323

> 1.0.335.2, 1.0.350.1/2, 1.0.372.2, 1.0.393.2, 1.0.393.4, 1.0.463.1;

## PLAYER_ID

```c
Player PLAYER_ID()  // 0x4F8644AF03D0E0D6
```

build 323

> This returns YOUR 'identity' as a Player type.
> 
> Always returns 0 in story mode.

## PLAYER_PED_ID

```c
Ped PLAYER_PED_ID()  // 0xD80958FC74E988A6
```

build 323

> Returns current player ped

## REMOVE_PLAYER_HELMET

```c
void REMOVE_PLAYER_HELMET(Player player, BOOL p2)  // 0xF3AC26D3CC576528
```

build 323

## REMOVE_PLAYER_TARGETABLE_ENTITY

```c
void REMOVE_PLAYER_TARGETABLE_ENTITY(Player player, Entity entity)  // 0x9F260BFB59ADBCA3
```

build 1868

## REMOVE_SCRIPT_FIRE_POSITION

```c
void REMOVE_SCRIPT_FIRE_POSITION()  // 0x7148E0F43D11F0D9
```

build 1604

> Resets values set by SET_SCRIPT_FIRE_POSITION

## REPORT_CRIME

```c
void REPORT_CRIME(Player player, int crimeType, int wantedLvlThresh)  // 0xE9B09589827545E7
```

build 323

> PLAYER::REPORT_CRIME(PLAYER::PLAYER_ID(), 37, PLAYER::GET_WANTED_LEVEL_THRESHOLD(1));
> 
> From am_armybase.ysc.c4:
> 
> PLAYER::REPORT_CRIME(PLAYER::PLAYER_ID(4), 36, PLAYER::GET_WANTED_LEVEL_THRESHOLD(4));
> 
> -----
> 
> This was taken from the GTAV.exe v1.334. The function is called sub_140592CE8. For a full decompilation of the function, see here: https://pastebin.com/09qSMsN7 
> 
> -----
> crimeType:
> 1: Firearms possession
> 2: Person running a red light ("5-0-5")
> 3: Reckless driver
> 4: Speeding vehicle (a "5-10")
> 5: Traffic violation (a "5-0-5")
> 6: Motorcycle rider without a helmet
> 7: Vehicle theft (a "5-0-3")
> 8: Grand Theft Auto
> 9: ???
> 10: ???
> 11: Assault on a civilian (a "2-40")
> 12: Assault on an officer
> 13: Assault with a deadly weapon (a "2-45")
> 14: Officer shot (a "2-45")
> 15: Pedestrian struck by a vehicle
> 16: Officer struck by a vehicle
> 17: Helicopter down (an "AC"?)
> 18: Civilian on fire (a "2-40")
> 19: Officer set on fire (a "10-99")
> 20: Car on fire
> 21: Air unit down (an "AC"?)
> 22: An explosion (a "9-96")
> 23: A stabbing (a "2-45") (also something else I couldn't understand)
> 24: Officer stabbed (also something else I couldn't understand)
> 25: Attack on a vehicle ("MDV"?)
> 26: Damage to property
> 27: Suspect threatening officer with a firearm
> 28: Shots fired
> 29: ???
> 30: ???
> 31: ???
> 32: ???
> 33: ???
> 34: A "2-45"
> 35: ???
> 36: A "9-25"
> 37: ???
> 38: ???
> 39: ???
> 40: ???
> 41: ???
> 42: ???
> 43: Possible disturbance
> 44: Civilian in need of assistance
> 45: ???
> 46: ???

## REPORT_POLICE_SPOTTED_PLAYER

```c
void REPORT_POLICE_SPOTTED_PLAYER(Player player)  // 0xDC64D2C53493ED12
```

build 323

## RESET_LAW_RESPONSE_DELAY_OVERRIDE

```c
void RESET_LAW_RESPONSE_DELAY_OVERRIDE()  // 0x0032A6DBA562C518
```

build 323

## RESET_PLAYER_ARREST_STATE

```c
void RESET_PLAYER_ARREST_STATE(Player player)  // 0x2D03E13C460760D6
```

build 323

## RESET_PLAYER_INPUT_GAIT

```c
void RESET_PLAYER_INPUT_GAIT(Player player)  // 0x19531C47A2ABD691
```

build 323

## RESET_PLAYER_STAMINA

```c
void RESET_PLAYER_STAMINA(Player player)  // 0xA6F312FCCE9C1DFE
```

build 323

## RESET_WANTED_LEVEL_DIFFICULTY

```c
void RESET_WANTED_LEVEL_DIFFICULTY(Player player)  // 0xB9D0DD990DC141DD
```

build 323

## RESET_WANTED_LEVEL_HIDDEN_ESCAPE_TIME

```c
void RESET_WANTED_LEVEL_HIDDEN_ESCAPE_TIME(Player player)  // 0x823EC8E82BA45986
```

build 2060 · old names: `_RESET_WANTED_LEVEL_HIDDEN_EVASION_TIME`

## RESET_WORLD_BOUNDARY_FOR_PLAYER

```c
void RESET_WORLD_BOUNDARY_FOR_PLAYER()  // 0xDA1DF03D5A315F4E
```

build 323

## RESTORE_PLAYER_STAMINA

```c
void RESTORE_PLAYER_STAMINA(Player player, float p1)  // 0xA352C1B864CAFD33
```

build 323

## SET_ACHIEVEMENT_PROGRESS

```c
BOOL SET_ACHIEVEMENT_PROGRESS(int achievementId, int progress)  // 0xC2AFFFDABBDC2C5C
```

build 323 · old names: `_SET_ACHIEVEMENT_PROGRESSION`, `_SET_ACHIEVEMENT_PROGRESS`

> For Steam.
> Does nothing and always returns false in the retail version of the game.

## SET_AIR_DRAG_MULTIPLIER_FOR_PLAYERS_VEHICLE

```c
void SET_AIR_DRAG_MULTIPLIER_FOR_PLAYERS_VEHICLE(Player player, float multiplier)  // 0xCA7DC8329F0A1E9E
```

build 323

> This can be between 1.0f - 50.0f

## SET_ALL_NEUTRAL_RANDOM_PEDS_FLEE

```c
void SET_ALL_NEUTRAL_RANDOM_PEDS_FLEE(Player player, BOOL toggle)  // 0xDE45D1A1EF45EE61
```

build 323 · old names: `SET_HUD_ANIM_STOP_LEVEL`

## SET_ALL_NEUTRAL_RANDOM_PEDS_FLEE_THIS_FRAME

```c
void SET_ALL_NEUTRAL_RANDOM_PEDS_FLEE_THIS_FRAME(Player player)  // 0xC3376F42B1FACCC6
```

build 323 · old names: `SET_AREAS_GENERATOR_ORIENTATION`

> - This is called after SET_ALL_RANDOM_PEDS_FLEE_THIS_FRAME
> 

## SET_ALL_RANDOM_PEDS_FLEE

```c
void SET_ALL_RANDOM_PEDS_FLEE(Player player, BOOL toggle)  // 0x056E0FE8534C2949
```

build 323

## SET_ALL_RANDOM_PEDS_FLEE_THIS_FRAME

```c
void SET_ALL_RANDOM_PEDS_FLEE_THIS_FRAME(Player player)  // 0x471D2FF42A94B4F2
```

build 323

## SET_APPLY_WAYPOINT_OF_PLAYER

```c
void SET_APPLY_WAYPOINT_OF_PLAYER(Player player, int hudColor)  // 0x2382AB11450AE7BA
```

build 877

## SET_AUTO_GIVE_PARACHUTE_WHEN_ENTER_PLANE

```c
void SET_AUTO_GIVE_PARACHUTE_WHEN_ENTER_PLANE(Player player, BOOL toggle)  // 0x9F343285A00B4BB6
```

build 323

## SET_AUTO_GIVE_SCUBA_GEAR_WHEN_EXIT_VEHICLE

```c
void SET_AUTO_GIVE_SCUBA_GEAR_WHEN_EXIT_VEHICLE(Player player, BOOL toggle)  // 0xD2B315B6689D537D
```

build 323

## SET_DISABLE_AMBIENT_MELEE_MOVE

```c
void SET_DISABLE_AMBIENT_MELEE_MOVE(Player player, BOOL toggle)  // 0x2E8AABFA40A84F8C
```

build 323

## SET_DISPATCH_COPS_FOR_PLAYER

```c
void SET_DISPATCH_COPS_FOR_PLAYER(Player player, BOOL toggle)  // 0xDB172424876553F4
```

build 323

## SET_EVERYONE_IGNORE_PLAYER

```c
void SET_EVERYONE_IGNORE_PLAYER(Player player, BOOL toggle)  // 0x8EEDA153AD141BA4
```

build 323

## SET_IGNORE_LOW_PRIORITY_SHOCKING_EVENTS

```c
void SET_IGNORE_LOW_PRIORITY_SHOCKING_EVENTS(Player player, BOOL toggle)  // 0x596976B02B6B5700
```

build 323

## SET_LAW_PEDS_CAN_ATTACK_NON_WANTED_PLAYER_THIS_FRAME

```c
void SET_LAW_PEDS_CAN_ATTACK_NON_WANTED_PLAYER_THIS_FRAME(Player player)  // 0xFAC75988A7D078D3
```

build 463

## SET_LAW_RESPONSE_DELAY_OVERRIDE

```c
void SET_LAW_RESPONSE_DELAY_OVERRIDE(float p0)  // 0xB45EFF719D8427A6
```

build 323

> PLAYER::SET_LAW_RESPONSE_DELAY_OVERRIDE(rPtr((&l_122) + 71)); // Found in decompilation
> 
> ***
> 
> In "am_hold_up.ysc" used once:
> 
> l_8d._f47 = MISC::GET_RANDOM_FLOAT_IN_RANGE(18.0, 28.0);
> PLAYER::SET_LAW_RESPONSE_DELAY_OVERRIDE((l_8d._f47));

## SET_MAX_WANTED_LEVEL

```c
void SET_MAX_WANTED_LEVEL(int maxWantedLevel)  // 0xAA5F02DB48D704B9
```

build 323

## SET_PLAYER_BLUETOOTH_STATE

```c
void SET_PLAYER_BLUETOOTH_STATE(Player player, BOOL state)  // 0x5DC40A8869C22141
```

build 323

## SET_PLAYER_CAN_BE_HASSLED_BY_GANGS

```c
void SET_PLAYER_CAN_BE_HASSLED_BY_GANGS(Player player, BOOL toggle)  // 0xD5E460AD7020A246
```

build 323

> Sets whether this player can be hassled by gangs.

## SET_PLAYER_CAN_COLLECT_DROPPED_MONEY

```c
void SET_PLAYER_CAN_COLLECT_DROPPED_MONEY(Player player, BOOL p1)  // 0xCAC57395B151135F
```

build 323

## SET_PLAYER_CAN_DAMAGE_PLAYER

```c
void SET_PLAYER_CAN_DAMAGE_PLAYER(Player player1, Player player2, BOOL toggle)  // 0x55FCC0C390620314
```

build 573

## SET_PLAYER_CAN_DO_DRIVE_BY

```c
void SET_PLAYER_CAN_DO_DRIVE_BY(Player player, BOOL toggle)  // 0x6E8834B52EC20C77
```

build 323

> Set whether this player should be able to do drive-bys.
> 
> "A drive-by is when a ped is aiming/shooting from vehicle. This includes middle finger taunts. By setting this value to false I confirm the player is unable to do all that. Tested on tick."
> 

## SET_PLAYER_CAN_LEAVE_PARACHUTE_SMOKE_TRAIL

```c
void SET_PLAYER_CAN_LEAVE_PARACHUTE_SMOKE_TRAIL(Player player, BOOL enabled)  // 0xF401B182DBA8AF53
```

build 323

## SET_PLAYER_CAN_USE_COVER

```c
void SET_PLAYER_CAN_USE_COVER(Player player, BOOL toggle)  // 0xD465A8599DFF6814
```

build 323

> Sets whether this player can take cover.

## SET_PLAYER_CLOTH_LOCK_COUNTER

```c
void SET_PLAYER_CLOTH_LOCK_COUNTER(int value)  // 0x14D913B777DFF5DA
```

build 323

> 6 matches across 4 scripts. 5 occurrences were 240. The other was 255.

## SET_PLAYER_CLOTH_PACKAGE_INDEX

```c
void SET_PLAYER_CLOTH_PACKAGE_INDEX(int index)  // 0x9F7BBA2EA6372500
```

build 323

> Every occurrence was either 0 or 2.

## SET_PLAYER_CLOTH_PIN_FRAMES

```c
void SET_PLAYER_CLOTH_PIN_FRAMES(Player player, int p1)  // 0x749FADDF97DFE930
```

build 323

## SET_PLAYER_CONTROL

```c
void SET_PLAYER_CONTROL(Player player, BOOL bHasControl, int flags)  // 0x8D32347D6D4C40A2
```

build 323

> Flags:
> SPC_AMBIENT_SCRIPT = (1 << 1),
> SPC_CLEAR_TASKS = (1 << 2),
> SPC_REMOVE_FIRES = (1 << 3),
> SPC_REMOVE_EXPLOSIONS = (1 << 4),
> SPC_REMOVE_PROJECTILES = (1 << 5),
> SPC_DEACTIVATE_GADGETS = (1 << 6),
> SPC_REENABLE_CONTROL_ON_DEATH = (1 << 7),
> SPC_LEAVE_CAMERA_CONTROL_ON = (1 << 8),
> SPC_ALLOW_PLAYER_DAMAGE = (1 << 9),
> SPC_DONT_STOP_OTHER_CARS_AROUND_PLAYER = (1 << 10),
> SPC_PREVENT_EVERYBODY_BACKOFF = (1 << 11),
> SPC_ALLOW_PAD_SHAKE = (1 << 12)
> 
> See: https://alloc8or.re/gta5/doc/enums/eSetPlayerControlFlag.txt

## SET_PLAYER_EXPLOSIVE_DAMAGE_MODIFIER

```c
void SET_PLAYER_EXPLOSIVE_DAMAGE_MODIFIER(Player player, Any p1)  // 0xD821056B9ACF8052
```

build 1011

## SET_PLAYER_FALL_DISTANCE_TO_TRIGGER_RAGDOLL_OVERRIDE

```c
void SET_PLAYER_FALL_DISTANCE_TO_TRIGGER_RAGDOLL_OVERRIDE(Player player, float p1)  // 0xEFD79FA81DFBA9CB
```

build 573 · old names: `_SET_PLAYER_FALL_DISTANCE`

## SET_PLAYER_FORCE_SKIP_AIM_INTRO

```c
void SET_PLAYER_FORCE_SKIP_AIM_INTRO(Player player, BOOL toggle)  // 0x7651BC64AE59E128
```

build 323

## SET_PLAYER_FORCED_AIM

```c
void SET_PLAYER_FORCED_AIM(Player player, BOOL toggle)  // 0x0FEE4F80AC44A726
```

build 323

## SET_PLAYER_FORCED_ZOOM

```c
void SET_PLAYER_FORCED_ZOOM(Player player, BOOL toggle)  // 0x75E7D505F2B15902
```

build 323

## SET_PLAYER_HAS_RESERVE_PARACHUTE

```c
void SET_PLAYER_HAS_RESERVE_PARACHUTE(Player player)  // 0x7DDAB28D31FAC363
```

build 323

## SET_PLAYER_HEALTH_RECHARGE_MAX_PERCENT

```c
void SET_PLAYER_HEALTH_RECHARGE_MAX_PERCENT(Player player, float limit)  // 0xC388A0F065F5BC34
```

build 573 · old names: `_SET_PLAYER_HEALTH_RECHARGE_LIMIT`

## SET_PLAYER_HEALTH_RECHARGE_MULTIPLIER

```c
void SET_PLAYER_HEALTH_RECHARGE_MULTIPLIER(Player player, float regenRate)  // 0x5DB660B38DD98A31
```

build 323

> `regenRate`: The recharge multiplier, a value between 0.0 and 1.0.
> Use 1.0 to reset it back to normal

## SET_PLAYER_HOMING_DISABLED_FOR_ALL_VEHICLE_WEAPONS

```c
void SET_PLAYER_HOMING_DISABLED_FOR_ALL_VEHICLE_WEAPONS(Any p0, Any p1)  // 0xEE4EBDD2593BA844
```

build 1180 · old names: `_SET_PLAYER_HOMING_ROCKET_DISABLED`

## SET_PLAYER_INVINCIBLE

```c
void SET_PLAYER_INVINCIBLE(Player player, BOOL toggle)  // 0x239528EACDC3E7DE
```

build 323

> Simply sets you as invincible (Health will not deplete).
> 
> Use SET_PLAYER_INVINCIBLE_BUT_HAS_REACTIONS instead if you want Ragdoll enabled, which is roughly equal to:
> *(DWORD *)(playerPedAddress + 0x188) |= (1 << 9);

## SET_PLAYER_INVINCIBLE_BUT_HAS_REACTIONS

```c
void SET_PLAYER_INVINCIBLE_BUT_HAS_REACTIONS(Player player, BOOL toggle)  // 0x6BC97F4F4BB3C04B
```

build 463 · old names: `_SET_PLAYER_INVINCIBLE_KEEP_RAGDOLL_ENABLED`

## SET_PLAYER_LEAVE_PED_BEHIND

```c
void SET_PLAYER_LEAVE_PED_BEHIND(Player player, BOOL toggle)  // 0xFF300C7649724A0B
```

build 323

## SET_PLAYER_LOCKON

```c
void SET_PLAYER_LOCKON(Player player, BOOL toggle)  // 0x5C8B2F450EE4328E
```

build 323

> Example from fm_mission_controler.ysc.c4:
> 
> PLAYER::SET_PLAYER_LOCKON(PLAYER::PLAYER_ID(), 1);
> 
> All other decompiled scripts using this seem to be using the player id as the first parameter, so I feel the need to confirm it as so.
> 
> No need to confirm it says PLAYER_ID() so it uses PLAYER_ID() lol.

## SET_PLAYER_LOCKON_RANGE_OVERRIDE

```c
void SET_PLAYER_LOCKON_RANGE_OVERRIDE(Player player, float range)  // 0x29961D490E5814FD
```

build 323

> Affects the range of auto aim target.

## SET_PLAYER_MAX_ARMOUR

```c
void SET_PLAYER_MAX_ARMOUR(Player player, int value)  // 0x77DFCCF5948B8C71
```

build 323

> Default is 100. Use player id and not ped id. For instance: PLAYER::SET_PLAYER_MAX_ARMOUR(PLAYER::PLAYER_ID(), 100); // main_persistent.ct4

## SET_PLAYER_MAX_EXPLOSIVE_DAMAGE

```c
void SET_PLAYER_MAX_EXPLOSIVE_DAMAGE(Player player, float p1)  // 0x8D768602ADEF2245
```

build 463

## SET_PLAYER_MAY_NOT_ENTER_ANY_VEHICLE

```c
void SET_PLAYER_MAY_NOT_ENTER_ANY_VEHICLE(Player player)  // 0x1DE37BBF9E9CC14A
```

build 323

## SET_PLAYER_MAY_ONLY_ENTER_THIS_VEHICLE

```c
void SET_PLAYER_MAY_ONLY_ENTER_THIS_VEHICLE(Player player, Vehicle vehicle)  // 0x8026FF78F208978A
```

build 323

## SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER

```c
void SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER(Player player, float modifier, BOOL p2)  // 0x4A3DC7ECCC321032
```

build 323

> modifier's min value is 0.1

## SET_PLAYER_MELEE_WEAPON_DEFENSE_MODIFIER

```c
void SET_PLAYER_MELEE_WEAPON_DEFENSE_MODIFIER(Player player, float modifier)  // 0xAE540335B4ABC4E2
```

build 323

> modifier's min value is 0.1

## SET_PLAYER_MODEL

```c
void SET_PLAYER_MODEL(Player player, Hash model)  // 0x00A1CADD00108836
```

build 323

> Set the model for a specific Player. Be aware that this will destroy the current Ped for the Player and create a new one, any reference to the old ped should be reset
> Make sure to request the model first and wait until it has loaded.

## SET_PLAYER_NOISE_MULTIPLIER

```c
void SET_PLAYER_NOISE_MULTIPLIER(Player player, float multiplier)  // 0xDB89EF50FF25FCE9
```

build 323

## SET_PLAYER_PARACHUTE_MODEL_OVERRIDE

```c
void SET_PLAYER_PARACHUTE_MODEL_OVERRIDE(Player player, Hash model)  // 0x977DB4641F6FC3DB
```

build 323

## SET_PLAYER_PARACHUTE_PACK_MODEL_OVERRIDE

```c
void SET_PLAYER_PARACHUTE_PACK_MODEL_OVERRIDE(Player player, Hash model)  // 0xDC80A4C2F18A2B64
```

build 323

## SET_PLAYER_PARACHUTE_PACK_TINT_INDEX

```c
void SET_PLAYER_PARACHUTE_PACK_TINT_INDEX(Player player, int tintIndex)  // 0x93B0FB27C9A04060
```

build 323

> tints 0- 13
> 0 - unkown
> 1 - unkown
> 2 - unkown
> 3 - unkown
> 4 - unkown

## SET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR

```c
void SET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR(Player player, int r, int g, int b)  // 0x8217FD371A4625CF
```

build 323

## SET_PLAYER_PARACHUTE_TINT_INDEX

```c
void SET_PLAYER_PARACHUTE_TINT_INDEX(Player player, int tintIndex)  // 0xA3D0E54541D9A5E5
```

build 323

> Tints:
>    None = -1,
>     Rainbow = 0,
>   Red = 1,
>   SeasideStripes = 2,
>    WidowMaker = 3,
>    Patriot = 4,
>   Blue = 5,
>  Black = 6,
>     Hornet = 7,
>    AirFocce = 8,
>  Desert = 9,
>    Shadow = 10,
>   HighAltitude = 11,
>     Airbone = 12,
>  Sunrise = 13,
> 

## SET_PLAYER_PARACHUTE_VARIATION_OVERRIDE

```c
void SET_PLAYER_PARACHUTE_VARIATION_OVERRIDE(Player player, int p1, Any p2, Any p3, BOOL p4)  // 0xD9284A8C0D48352C
```

build 323

> p1 was always 5.
> p4 was always false.

## SET_PLAYER_PHONE_PALETTE_IDX

```c
void SET_PLAYER_PHONE_PALETTE_IDX(Player player, int idx)  // 0x11D5F725F0E780E0
```

build 323 · old names: `SET_PLAYER_RESET_FLAG_PREFER_REAR_SEATS`

## SET_PLAYER_PREVIOUS_VARIATION_DATA

```c
void SET_PLAYER_PREVIOUS_VARIATION_DATA(Player player, int p1, int p2, Any p3, Any p4, Any p5)  // 0x7BAE68775557AE0B
```

build 1290

## SET_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE

```c
void SET_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE(Player player, Hash model)  // 0x0764486AEDE748DB
```

build 2372 · old names: `_SET_PLAYER_RESERVE_PARACHUTE_MODEL_OVERRIDE`

## SET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX

```c
void SET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX(Player player, int index)  // 0xAF04C87F5DC1DF38
```

build 323

> Tints:
>    None = -1,
>     Rainbow = 0,
>   Red = 1,
>   SeasideStripes = 2,
>    WidowMaker = 3,
>    Patriot = 4,
>   Blue = 5,
>  Black = 6,
>     Hornet = 7,
>    AirFocce = 8,
>  Desert = 9,
>    Shadow = 10,
>   HighAltitude = 11,
>     Airbone = 12,
>  Sunrise = 13,

## SET_PLAYER_RESET_FLAG_PREFER_REAR_SEATS

```c
void SET_PLAYER_RESET_FLAG_PREFER_REAR_SEATS(Player player, Vehicle vehicle)  // 0xC1069B5E5B6EA13E
```

build 3889

## SET_PLAYER_SIMULATE_AIMING

```c
void SET_PLAYER_SIMULATE_AIMING(Player player, BOOL toggle)  // 0xC54C95DA968EC5B5
```

build 323

## SET_PLAYER_SNEAKING_NOISE_MULTIPLIER

```c
void SET_PLAYER_SNEAKING_NOISE_MULTIPLIER(Player player, float multiplier)  // 0xB2C1A29588A9F47C
```

build 323

> Values around 1.0f to 2.0f used in game scripts.

## SET_PLAYER_SPECTATED_VEHICLE_RADIO_OVERRIDE

```c
void SET_PLAYER_SPECTATED_VEHICLE_RADIO_OVERRIDE(BOOL p0)  // 0x2F7CEB6520288061
```

build 323

## SET_PLAYER_SPRINT

```c
void SET_PLAYER_SPRINT(Player player, BOOL toggle)  // 0xA01B8075D8B92DF4
```

build 323

## SET_PLAYER_STEALTH_PERCEPTION_MODIFIER

```c
void SET_PLAYER_STEALTH_PERCEPTION_MODIFIER(Player player, float value)  // 0x4E9021C1FCDD507A
```

build 323

## SET_PLAYER_STEALTH_SPEED

```c
void SET_PLAYER_STEALTH_SPEED(Player player, int stealthSpeed)  // 0xE6200F3AF46AC0B5
```

build 3889

> stealthSpeed must be between 80 and 120

## SET_PLAYER_TARGET_LEVEL

```c
void SET_PLAYER_TARGET_LEVEL(int targetLevel)  // 0x5702B917B99DB1CD
```

build 323

## SET_PLAYER_TARGETING_MODE

```c
void SET_PLAYER_TARGETING_MODE(int targetMode)  // 0xB1906895227793F3
```

build 323

> Sets your targeting mode.
> 0 = Assisted Aim - Full
> 1 = Assisted Aim - Partial
> 2 = Free Aim - Assisted
> 3 = Free Aim

## SET_PLAYER_TEAM

```c
void SET_PLAYER_TEAM(Player player, int team)  // 0x0299FA38396A4940
```

build 323

> Set player team on deathmatch and last team standing..

## SET_PLAYER_UNDERWATER_BREATH_PERCENT_REMAINING

```c
float SET_PLAYER_UNDERWATER_BREATH_PERCENT_REMAINING(Player player, float time)  // 0xA0D3E4F7AAFB7E78
```

build 757 · old names: `_SET_PLAYER_UNDERWATER_TIME_REMAINING`

## SET_PLAYER_VEHICLE_DAMAGE_MODIFIER

```c
void SET_PLAYER_VEHICLE_DAMAGE_MODIFIER(Player player, float modifier)  // 0xA50E117CDDF82F0C
```

build 323

> modifier's min value is 0.1

## SET_PLAYER_VEHICLE_DEFENSE_MODIFIER

```c
void SET_PLAYER_VEHICLE_DEFENSE_MODIFIER(Player player, float modifier)  // 0x4C60E6EFDAFF2462
```

build 323

> modifier's min value is 0.1

## SET_PLAYER_VEHICLE_WEAPON_TO_NON_HOMING

```c
void SET_PLAYER_VEHICLE_WEAPON_TO_NON_HOMING(Any p0)  // 0x237440E46D918649
```

build 1290

> Unsets playerPed+330 if the current weapon has certain flags.

## SET_PLAYER_WANTED_CENTRE_POSITION

```c
void SET_PLAYER_WANTED_CENTRE_POSITION(Player player, float x, float y, float z)  // 0x520E541A97A13354
```

build 323

> # Predominant call signatures
> PLAYER::SET_PLAYER_WANTED_CENTRE_POSITION(PLAYER::PLAYER_ID(), ENTITY::GET_ENTITY_COORDS(PLAYER::PLAYER_PED_ID(), 1));
> 
> # Parameter value ranges
> P0: PLAYER::PLAYER_ID()
> P1: ENTITY::GET_ENTITY_COORDS(PLAYER::PLAYER_PED_ID(), 1)
> P2: Not set by any call

## SET_PLAYER_WANTED_LEVEL

```c
void SET_PLAYER_WANTED_LEVEL(Player player, int wantedLevel, BOOL disableNoMission)  // 0x39FF19C64EF7DA5B
```

build 323

> Call SET_PLAYER_WANTED_LEVEL_NOW for immediate effect
> 
> wantedLevel is an integer value representing 0 to 5 stars even though the game supports the 6th wanted level but no police will appear since no definitions are present for it in the game files
> 
> disableNoMission-  Disables When Off Mission- appears to always be false
> 

## SET_PLAYER_WANTED_LEVEL_NO_DROP

```c
void SET_PLAYER_WANTED_LEVEL_NO_DROP(Player player, int wantedLevel, BOOL p2)  // 0x340E61DE7F471565
```

build 323

> p2 is always false in R* scripts

## SET_PLAYER_WANTED_LEVEL_NOW

```c
void SET_PLAYER_WANTED_LEVEL_NOW(Player player, BOOL p1)  // 0xE0A7D1E497FFCD6F
```

build 323

> Forces any pending wanted level to be applied to the specified player immediately.
> 
> Call SET_PLAYER_WANTED_LEVEL with the desired wanted level, followed by SET_PLAYER_WANTED_LEVEL_NOW.
> 
> Second parameter is unknown (always false).

## SET_PLAYER_WEAPON_DAMAGE_MODIFIER

```c
void SET_PLAYER_WEAPON_DAMAGE_MODIFIER(Player player, float modifier)  // 0xCE07B9F7817AADA3
```

build 323

> This modifies the damage value of your weapon. Whether it is a multiplier or base damage is unknown. 
> 
> Based on tests, it is unlikely to be a multiplier.
> 
> modifier's min value is 0.1

## SET_PLAYER_WEAPON_DEFENSE_MODIFIER

```c
void SET_PLAYER_WEAPON_DEFENSE_MODIFIER(Player player, float modifier)  // 0x2D83BC011CA14A3C
```

build 323

> modifier's min value is 0.1

## SET_PLAYER_WEAPON_MINIGUN_DEFENSE_MODIFIER

```c
void SET_PLAYER_WEAPON_MINIGUN_DEFENSE_MODIFIER(Player player, float modifier)  // 0xBCFDE9EDE4CF27DC
```

build 944 · old names: `_SET_PLAYER_WEAPON_DEFENSE_MODIFIER_2`

> modifier's min value is 0.1

## SET_PLAYER_WEAPON_TAKEDOWN_DEFENSE_MODIFIER

```c
void SET_PLAYER_WEAPON_TAKEDOWN_DEFENSE_MODIFIER(Player player, float p1)  // 0x31E90B8873A4CD3B
```

build 617

## SET_POLICE_IGNORE_PLAYER

```c
void SET_POLICE_IGNORE_PLAYER(Player player, BOOL toggle)  // 0x32C62AA929C2DA6A
```

build 323

> The player will be ignored by the police if toggle is set to true

## SET_POLICE_RADAR_BLIPS

```c
void SET_POLICE_RADAR_BLIPS(BOOL toggle)  // 0x43286D561B72B8BF
```

build 323

> If toggle is set to false:
>  The police won't be shown on the (mini)map
> 
> If toggle is set to true:
>  The police will be shown on the (mini)map

## SET_RUN_SPRINT_MULTIPLIER_FOR_PLAYER

```c
void SET_RUN_SPRINT_MULTIPLIER_FOR_PLAYER(Player player, float multiplier)  // 0x6DB47AA77FD94E09
```

build 323

> Multiplier goes up to 1.49 any value above will be completely overruled by the game and the multiplier will not take effect.
> 
> Just call it one time, it is not required to be called once every tick.

## SET_SCRIPT_FIRE_POSITION

```c
void SET_SCRIPT_FIRE_POSITION(float coordX, float coordY, float coordZ)  // 0x70A382ADEC069DD3
```

build 1604

## SET_SPECIAL_ABILITY_MP

```c
void SET_SPECIAL_ABILITY_MP(Player player, int p1, Any p2)  // 0xB214D570EAD7F81A
```

build 678 · old names: `_SET_SPECIAL_ABILITY`

## SET_SPECIAL_ABILITY_MULTIPLIER

```c
void SET_SPECIAL_ABILITY_MULTIPLIER(float multiplier)  // 0xA49C426ED0CA4AB7
```

build 323

## SET_SWIM_MULTIPLIER_FOR_PLAYER

```c
void SET_SWIM_MULTIPLIER_FOR_PLAYER(Player player, float multiplier)  // 0xA91C6F0FF7D16A13
```

build 323

> Swim speed multiplier.
> Multiplier goes up to 1.49
> 
> Just call it one time, it is not required to be called once every tick. - Note copied from below native.

## SET_WANTED_LEVEL_DIFFICULTY

```c
void SET_WANTED_LEVEL_DIFFICULTY(Player player, float difficulty)  // 0x9B0BB33B04405E7A
```

build 323

> Max value is 1.0

## SET_WANTED_LEVEL_HIDDEN_ESCAPE_TIME

```c
void SET_WANTED_LEVEL_HIDDEN_ESCAPE_TIME(Player player, int wantedLevel, int lossTime)  // 0x49B856B1360C47C7
```

build 2060 · old names: `_SET_WANTED_LEVEL_HIDDEN_EVASION_TIME`

## SET_WANTED_LEVEL_MULTIPLIER

```c
void SET_WANTED_LEVEL_MULTIPLIER(float multiplier)  // 0x020E5F00CDA207BA
```

build 323

## SIMULATE_PLAYER_INPUT_GAIT

```c
void SIMULATE_PLAYER_INPUT_GAIT(Player player, float amount, int gaitType, float speed, BOOL p4, BOOL p5, Any p6)  // 0x477D5D63E63ECA5D
```

build 323

> This is to make the player walk without accepting input from INPUT.
> 
> gaitType is in increments of 100s. 2000, 500, 300, 200, etc.
> 
> p4 is always 1 and p5 is always 0.
> 
> C# Example :
> 
> Function.Call(Hash.SIMULATE_PLAYER_INPUT_GAIT, Game.Player, 1.0f, 100, 1.0f, 1, 0); //Player will go forward for 100ms

## SPECIAL_ABILITY_ACTIVATE

```c
void SPECIAL_ABILITY_ACTIVATE(Player player, int p1)  // 0x821FDC827D6F4090
```

build 678 · old names: `_SPECIAL_ABILITY_ACTIVATE`

> p1 is always 0 in the scripts

## SPECIAL_ABILITY_CHARGE_ABSOLUTE

```c
void SPECIAL_ABILITY_CHARGE_ABSOLUTE(Player player, int p1, BOOL p2, Any p3)  // 0xB7B0870EB531D08D
```

build 323

> p1 appears as 5, 10, 15, 25, or 30. p2 is always true.

## SPECIAL_ABILITY_CHARGE_CONTINUOUS

```c
void SPECIAL_ABILITY_CHARGE_CONTINUOUS(Player player, Ped p1, Any p2)  // 0xED481732DFF7E997
```

build 323

> p1 appears to always be 1 (only comes up twice)

## SPECIAL_ABILITY_CHARGE_LARGE

```c
void SPECIAL_ABILITY_CHARGE_LARGE(Player player, BOOL p1, BOOL p2, Any p3)  // 0xF733F45FA4497D93
```

build 323

> 2 matches. p1 was always true.

## SPECIAL_ABILITY_CHARGE_MEDIUM

```c
void SPECIAL_ABILITY_CHARGE_MEDIUM(Player player, BOOL p1, BOOL p2, Any p3)  // 0xF113E3AA9BC54613
```

build 323

> Only 1 match. Both p1 & p2 were true.

## SPECIAL_ABILITY_CHARGE_NORMALIZED

```c
void SPECIAL_ABILITY_CHARGE_NORMALIZED(Player player, float normalizedValue, BOOL p2, Any p3)  // 0xA0696A65F009EE18
```

build 323 · old names: `RESET_SPECIAL_ABILITY_CONTROLS_CINEMATIC`

> 
> normalizedValue is from 0.0 - 1.0
> p2 is always 1

## SPECIAL_ABILITY_CHARGE_ON_MISSION_FAILED

```c
void SPECIAL_ABILITY_CHARGE_ON_MISSION_FAILED(Player player, Any p1)  // 0xC9A763D8FE87436A
```

build 323

## SPECIAL_ABILITY_CHARGE_SMALL

```c
void SPECIAL_ABILITY_CHARGE_SMALL(Player player, BOOL p1, BOOL p2, Any p3)  // 0x2E7B9B683481687D
```

build 323

> Every occurrence of p1 & p2 were both true.

## SPECIAL_ABILITY_DEACTIVATE

```c
void SPECIAL_ABILITY_DEACTIVATE(Player player, Any p1)  // 0xD6A953C6D1492057
```

build 323

## SPECIAL_ABILITY_DEACTIVATE_FAST

```c
void SPECIAL_ABILITY_DEACTIVATE_FAST(Player player, Any p1)  // 0x9CB5CE07A3968D5A
```

build 323

## SPECIAL_ABILITY_DEACTIVATE_MP

```c
void SPECIAL_ABILITY_DEACTIVATE_MP(Player player, int p1)  // 0x17F7471EACA78290
```

build 678 · old names: `_SPECIAL_ABILITY_DEPLETE`

> p1 is always 0 in the scripts

## SPECIAL_ABILITY_DEPLETE_METER

```c
void SPECIAL_ABILITY_DEPLETE_METER(Player player, BOOL p1, Any p2)  // 0x1D506DBBBC51E64B
```

build 323

> p1 was always true.

## SPECIAL_ABILITY_FILL_METER

```c
void SPECIAL_ABILITY_FILL_METER(Player player, BOOL p1, Any p2)  // 0x3DACA8DDC6FD4980
```

build 323 · old names: `_RECHARGE_SPECIAL_ABILITY`

## SPECIAL_ABILITY_LOCK

```c
void SPECIAL_ABILITY_LOCK(Hash playerModel, Any p1)  // 0x6A09D0D590A47D13
```

build 323

## SPECIAL_ABILITY_RESET

```c
void SPECIAL_ABILITY_RESET(Player player, Any p1)  // 0x375F0E738F861A94
```

build 323

## SPECIAL_ABILITY_UNLOCK

```c
void SPECIAL_ABILITY_UNLOCK(Hash playerModel, Any p1)  // 0xF145F3BE2EFA9A3B
```

build 323

## START_FIRING_AMNESTY

```c
void START_FIRING_AMNESTY(int duration)  // 0xBF9BD71691857E48
```

build 323

## START_PLAYER_TELEPORT

```c
void START_PLAYER_TELEPORT(Player player, float x, float y, float z, float heading, BOOL p5, BOOL findCollisionLand, BOOL p7)  // 0xAD15F075A4DA0FDE
```

build 323

> `findCollisionLand`: This teleports the player to land when set to true and will not consider the Z coordinate parameter provided by you. It will automatically put the Z coordinate so that you don't fall from sky.

## STOP_PLAYER_TELEPORT

```c
void STOP_PLAYER_TELEPORT()  // 0xC449EDED9D73009C
```

build 323

> Disables the player's teleportation

## SUPPRESS_CRIME_THIS_FRAME

```c
void SUPPRESS_CRIME_THIS_FRAME(Player player, int crimeType)  // 0x9A987297ED8BD838
```

build 323 · old names: `_SWITCH_CRIME_TYPE`

> crimeType: see REPORT_CRIME

## SUPPRESS_LOSING_WANTED_LEVEL_IF_HIDDEN_THIS_FRAME

```c
void SUPPRESS_LOSING_WANTED_LEVEL_IF_HIDDEN_THIS_FRAME(Player player)  // 0x4669B3ED80F24B4E
```

build 323

> This has been found in use in the decompiled files.

## SUPPRESS_WITNESSES_CALLING_POLICE_THIS_FRAME

```c
void SUPPRESS_WITNESSES_CALLING_POLICE_THIS_FRAME(Player player)  // 0x36F1B38855F2A8DF
```

build 323

## UPDATE_PLAYER_TELEPORT

```c
BOOL UPDATE_PLAYER_TELEPORT(Player player)  // 0xE23D5873C2394C61
```

build 323 · old names: `_HAS_PLAYER_TELEPORT_FINISHED`

## UPDATE_SPECIAL_ABILITY_FROM_STAT

```c
void UPDATE_SPECIAL_ABILITY_FROM_STAT(Player player, Any p1)  // 0xFFEE8FA29AB9A18E
```

build 323

## UPDATE_WANTED_POSITION_THIS_FRAME

```c
void UPDATE_WANTED_POSITION_THIS_FRAME(Player player)  // 0xBC9490CA15AEA8FB
```

build 323

> This native is used in both singleplayer and multiplayer scripts.
> 
> Always used like this in scripts
> PLAYER::UPDATE_WANTED_POSITION_THIS_FRAME(PLAYER::PLAYER_ID());

