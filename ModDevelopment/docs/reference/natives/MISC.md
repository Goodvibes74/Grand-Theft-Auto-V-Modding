# MISC natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _GET_CONTENT_PROP_TYPE

```c
int _GET_CONTENT_PROP_TYPE(Hash model)  // 0x8BAF8AD59F47AAFC
```

build 3095

> Returns prop type for given model hash

## _IS_XBOXPC_VERSION

```c
BOOL _IS_XBOXPC_VERSION()  // 0xE2BCD0EFAE90D1F4
```

build 3504

## _SET_CONTENT_PROP_TYPE

```c
void _SET_CONTENT_PROP_TYPE(Hash model, int type)  // 0xBA4583AF4C678A9B
```

build 3095

## ABSF

```c
float ABSF(float value)  // 0x73D57CFFDD12C355
```

build 323

## ABSI

```c
int ABSI(int value)  // 0xF0D31AD191A74F87
```

build 323

## ACOS

```c
float ACOS(float p0)  // 0x1D08B970013C34B6
```

build 323

## ACTION_MANAGER_ENABLE_ACTION

```c
void ACTION_MANAGER_ENABLE_ACTION(Hash hash, BOOL enable)  // 0xA6A12939F16D85BE
```

build 323 · old names: `_REMOVE_STEALTH_KILL`

> Appears to remove stealth kill action from memory

## ACTIVITY_FEED_ACTION_START_WITH_COMMAND_LINE

```c
void ACTIVITY_FEED_ACTION_START_WITH_COMMAND_LINE(const char* p0, const char* p1)  // 0xEB078CA2B5E82ADD
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ACTIVITY_FEED_ACTION_START_WITH_COMMAND_LINE_ADD

```c
void ACTIVITY_FEED_ACTION_START_WITH_COMMAND_LINE_ADD(const char* p0)  // 0x703CC7F60CBB2B57
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ACTIVITY_FEED_ADD_INT_TO_CAPTION

```c
void ACTIVITY_FEED_ADD_INT_TO_CAPTION(Any p0)  // 0x97E7E2C04245115B
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ACTIVITY_FEED_ADD_LITERAL_SUBSTRING_TO_CAPTION

```c
void ACTIVITY_FEED_ADD_LITERAL_SUBSTRING_TO_CAPTION(const char* p0)  // 0xEBD3205A207939ED
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ACTIVITY_FEED_ADD_SUBSTRING_TO_CAPTION

```c
void ACTIVITY_FEED_ADD_SUBSTRING_TO_CAPTION(const char* p0)  // 0x31125FD509D9043F
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ACTIVITY_FEED_CREATE

```c
void ACTIVITY_FEED_CREATE(const char* p0, const char* p1)  // 0x4DCDF92BF64236CD
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ACTIVITY_FEED_LARGE_IMAGE_URL

```c
void ACTIVITY_FEED_LARGE_IMAGE_URL(const char* p0)  // 0x916CA67D26FD1E37
```

build 2060

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ACTIVITY_FEED_ONLINE_PLAYED_WITH_POST

```c
void ACTIVITY_FEED_ONLINE_PLAYED_WITH_POST(const char* p0)  // 0xBA4B8D83BDC75551
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.
> 
> Used only once in the scripts (ingamehud) with p0 = "AF_GAMEMODE"

## ACTIVITY_FEED_POST

```c
void ACTIVITY_FEED_POST()  // 0x8951EB9C6906D3C8
```

build 323

> Does nothing (it's a nullsub). Seems to be PS4 specific.

## ADD_DISPATCH_SPAWN_ANGLED_BLOCKING_AREA

```c
int ADD_DISPATCH_SPAWN_ANGLED_BLOCKING_AREA(float x1, float y1, float z1, float x2, float y2, float z2, float width)  // 0x918C7B2D2FF3928B
```

build 323 · old names: `_ADD_DISPATCH_SPAWN_BLOCKING_ANGLED_AREA`

> To remove, see: REMOVE_DISPATCH_SPAWN_BLOCKING_AREA
> See IS_POINT_IN_ANGLED_AREA for the definition of an angled area.

## ADD_DISPATCH_SPAWN_SPHERE_BLOCKING_AREA

```c
int ADD_DISPATCH_SPAWN_SPHERE_BLOCKING_AREA(float x1, float y1, float x2, float y2)  // 0x2D4259F1FEB81DA9
```

build 323 · old names: `_ADD_DISPATCH_SPAWN_BLOCKING_AREA`

## ADD_HOSPITAL_RESTART

```c
int ADD_HOSPITAL_RESTART(float x, float y, float z, float heading, int whenToUse)  // 0x1F464EF988465A81
```

build 323

> Returns the index of the newly created hospital spawn point.
> whenToUse: must be 0

## ADD_POLICE_RESTART

```c
int ADD_POLICE_RESTART(float x, float y, float z, float heading, int whenToUse)  // 0x452736765B31FC4B
```

build 323

> whenToUse: must be 0

## ADD_POP_MULTIPLIER_AREA

```c
int ADD_POP_MULTIPLIER_AREA(float x1, float y1, float z1, float x2, float y2, float z2, float p6, float p7, BOOL p8, BOOL p9)  // 0x67F6413D3220E18D
```

build 323

## ADD_POP_MULTIPLIER_SPHERE

```c
int ADD_POP_MULTIPLIER_SPHERE(float x, float y, float z, float radius, float pedMultiplier, float vehicleMultiplier, BOOL p6, BOOL p7)  // 0x32C7A7E8C43A1F80
```

build 323

> This native is adding a zone, where you can change density settings. For example, you can add a zone on 0.0, 0.0, 0.0 with radius 900.0 and vehicleMultiplier 0.0, and you will not see any new population vehicle spawned in a radius of 900.0 from 0.0, 0.0, 0.0. Returns the id. You can have only 15 zones at the same time. You can remove zone using REMOVE_POP_MULTIPLIER_SPHERE

## ADD_REPLAY_STAT_VALUE

```c
void ADD_REPLAY_STAT_VALUE(Any value)  // 0x69FE6DC87BD2A5E9
```

build 323

## ADD_STUNT_JUMP

```c
int ADD_STUNT_JUMP(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4, float camX, float camY, float camZ, int p15, int p16, int p17)  // 0x1A992DA297A4630C
```

build 323

> See description of `ADD_STUNT_JUMP_ANGLED` for detailed info. The only difference really is this one does not have the radius (or angle, not sure) floats parameters for entry and landing zones.

## ADD_STUNT_JUMP_ANGLED

```c
int ADD_STUNT_JUMP_ANGLED(float x1, float y1, float z1, float x2, float y2, float z2, float radius1, float x3, float y3, float z3, float x4, float y4, float z4, float radius2, float camX, float camY, float camZ, int p17, int p18, int p19)  // 0xBBE5D803A5360CBF
```

build 323

> Creates a new stunt jump.
> 
> The radius1 and radius2 might actually not be a radius at all, but that's what it seems to me testing them in-game. But they may be 'angle' floats instead, considering this native is named ADD_STUNT_JUMP_**ANGLED**.
> 
> Info about the specific 'parameter sections':
> 
> 
> **x1, y1, z1, x2, y2, z2 and radius1:**
> 
> First coordinates are for the jump entry area, and the radius that will be checked around that area. So if you're not exactly within the coordinates, but you are within the outter radius limit then it will still register as entering the stunt jump. Note as mentioned above, the radius is just a guess, I'm not really sure about it's exact purpose.
> 
> 
> **x3, y3, z3, x4, y4, z4 and radius2:**
> 
> Next part is the landing area, again starting with the left bottom (nearest to the stunt jump entry zone) coordinate, and the second one being the top right furthest away part of the landing area. Followed by another (most likely) radius float, this is usually slightly larger than the entry zone 'radius' float value, just because you have quite a lot of places where you can land (I'm guessing).
> 
> 
> **camX, camY and camZ:**
> 
> The final coordinate in this native is the Camera position. Rotation and zoom/FOV is managed by the game itself, you just need to provide the camera location.
> 
> 
> **unk1, unk2 and unk3:**
> 
> Not sure what these are for, but they're always `150, 0, 0` in decompiled scripts.
> 
> Here is a list of almost all of the stunt jumps from GTA V (taken from decompiled scripts): https://pastebin.com/EW1jBPkY

## ADD_TACTICAL_NAV_MESH_POINT

```c
void ADD_TACTICAL_NAV_MESH_POINT(float x, float y, float z)  // 0xB8721407EE9C3FF6
```

build 323 · old names: `_ADD_TACTICAL_ANALYSIS_POINT`

## ALLOW_MISSION_CREATOR_WARP

```c
void ALLOW_MISSION_CREATOR_WARP(BOOL toggle)  // 0xDEA36202FC3382DF
```

build 323

## ARE_CREDITS_RUNNING

```c
BOOL ARE_CREDITS_RUNNING()  // 0xD19C0826DC20CF1C
```

build 2802

## ARE_PROFILE_SETTINGS_VALID

```c
BOOL ARE_PROFILE_SETTINGS_VALID()  // 0x5AA3BEFA29F03AD4
```

build 323

## ARE_STRINGS_EQUAL

```c
BOOL ARE_STRINGS_EQUAL(const char* string1, const char* string2)  // 0x0C515FAB3FF9EA92
```

build 323

## ASIN

```c
float ASIN(float p0)  // 0xC843060B5765DCE7
```

build 323

## ATAN

```c
float ATAN(float p0)  // 0xA9D1795CD5043663
```

build 323

## ATAN2

```c
float ATAN2(float p0, float p1)  // 0x8927CBF9D22261A4
```

build 323

## BEGIN_REPLAY_STATS

```c
void BEGIN_REPLAY_STATS(Any p0, Any p1)  // 0xE0E500246FF73D66
```

build 323

## BLOCK_DISPATCH_SERVICE_RESOURCE_CREATION

```c
void BLOCK_DISPATCH_SERVICE_RESOURCE_CREATION(int dispatchService, BOOL toggle)  // 0x9B2BD3773123EA2F
```

build 323

## CANCEL_ONSCREEN_KEYBOARD

```c
void CANCEL_ONSCREEN_KEYBOARD()  // 0x58A39BE597CE99CD
```

build 757 · old names: `_CANCEL_ONSCREEN_KEYBOARD`

> DO NOT use this as it doesn't clean up the text input box properly and your script will get stuck in the UPDATE_ONSCREEN_KEYBOARD() loop.
> Use FORCE_CLOSE_TEXT_INPUT_BOX instead.

## CANCEL_STUNT_JUMP

```c
void CANCEL_STUNT_JUMP()  // 0xE6B7B0ACD4E4B75E
```

build 323

## CLEANUP_ASYNC_INSTALL

```c
void CLEANUP_ASYNC_INSTALL()  // 0xC79AE21974B01FB2
```

build 323 · old names: `_CLEANUP_ASYNC_INSTALL`

## CLEAR_ANGLED_AREA_OF_VEHICLES

```c
void CLEAR_ANGLED_AREA_OF_VEHICLES(float x1, float y1, float z1, float x2, float y2, float z2, float width, BOOL p7, BOOL p8, BOOL p9, BOOL p10, BOOL p11, Any p12, Any p13)  // 0x11DB3500F042A8AA
```

build 323

## CLEAR_AREA

```c
void CLEAR_AREA(float X, float Y, float Z, float radius, BOOL p4, BOOL ignoreCopCars, BOOL ignoreObjects, BOOL p7)  // 0xA56F01F3765B93A0
```

build 323

> Example: CLEAR_AREA(0, 0, 0, 30, true, false, false, false);

## CLEAR_AREA_LEAVE_VEHICLE_HEALTH

```c
void CLEAR_AREA_LEAVE_VEHICLE_HEALTH(float x, float y, float z, float radius, BOOL p4, BOOL p5, BOOL p6, BOOL p7)  // 0x957838AAF91BD12D
```

build 323 · old names: `_CLEAR_AREA_OF_EVERYTHING`

> MISC::CLEAR_AREA_LEAVE_VEHICLE_HEALTH(x, y, z, radius, false, false, false, false); seem to make all objects go away, peds, vehicles etc. All booleans set to true doesn't seem to change anything. 

## CLEAR_AREA_OF_COPS

```c
void CLEAR_AREA_OF_COPS(float x, float y, float z, float radius, int flags)  // 0x04F8FC8FCF58F88D
```

build 323

> flags appears to always be 0

## CLEAR_AREA_OF_OBJECTS

```c
void CLEAR_AREA_OF_OBJECTS(float x, float y, float z, float radius, int flags)  // 0xDD9B9B385AAC7F5B
```

build 323

## CLEAR_AREA_OF_PEDS

```c
void CLEAR_AREA_OF_PEDS(float x, float y, float z, float radius, int flags)  // 0xBE31FD6CE464AC59
```

build 323

> Example:       CLEAR_AREA_OF_PEDS(0, 0, 0, 10000, 1);

## CLEAR_AREA_OF_PROJECTILES

```c
void CLEAR_AREA_OF_PROJECTILES(float x, float y, float z, float radius, int flags)  // 0x0A1CB9094635D1A6
```

build 323

> flags is usually 0 in the scripts.

## CLEAR_AREA_OF_VEHICLES

```c
void CLEAR_AREA_OF_VEHICLES(float x, float y, float z, float radius, BOOL p4, BOOL p5, BOOL p6, BOOL p7, BOOL p8, BOOL p9, Any p10)  // 0x01C7B9B38428AEB6
```

build 323

> Example:
> CLEAR_AREA_OF_VEHICLES(0.0f, 0.0f, 0.0f, 10000.0f, false, false, false, false, false, false);

## CLEAR_BIT

```c
void CLEAR_BIT(int* address, int offset)  // 0xE80492A9AC099A93
```

build 323

> This sets bit [offset] of [address] to off.
> 
> Example:
> MISC::CLEAR_BIT(&bitAddress, 1);
> 
> To check if this bit has been enabled:
> MISC::IS_BIT_SET(bitAddress, 1); // will return 0 afterwards

## CLEAR_CODE_REQUESTED_AUTOSAVE

```c
void CLEAR_CODE_REQUESTED_AUTOSAVE()  // 0x06462A961E94B67C
```

build 323

## CLEAR_OVERRIDE_WEATHER

```c
void CLEAR_OVERRIDE_WEATHER()  // 0x338D2E3477711050
```

build 323

## CLEAR_REPLAY_STATS

```c
void CLEAR_REPLAY_STATS()  // 0x1B1AB132A16FDA55
```

build 323

## CLEAR_RESTART_COORD_OVERRIDE

```c
void CLEAR_RESTART_COORD_OVERRIDE()  // 0xA2716D40842EAF79
```

build 323 · old names: `_SET_NEXT_RESPAWN_TO_CUSTOM`, `_CLEAR_RESTART_CUSTOM_POSITION`

## CLEAR_SCENARIO_SPAWN_HISTORY

```c
void CLEAR_SCENARIO_SPAWN_HISTORY()  // 0x7EC6F9A478A6A512
```

build 323

> Possibly used to clear scenario points.

## CLEAR_TACTICAL_NAV_MESH_POINTS

```c
void CLEAR_TACTICAL_NAV_MESH_POINTS()  // 0xB3CD58CCA6CDA852
```

build 323 · old names: `_CLEAR_TACTICAL_ANALYSIS_POINTS`

## CLEAR_WEATHER_TYPE_NOW_PERSIST_NETWORK

```c
void CLEAR_WEATHER_TYPE_NOW_PERSIST_NETWORK(int milliseconds)  // 0x0CF97F497FE7D048
```

build 1103 · old names: `_CLEAR_WEATHER_TYPE_OVERTIME_PERSIST`

## CLEAR_WEATHER_TYPE_PERSIST

```c
void CLEAR_WEATHER_TYPE_PERSIST()  // 0xCCC39339BEF76CF5
```

build 323

## COMPARE_STRINGS

```c
int COMPARE_STRINGS(const char* str1, const char* str2, BOOL matchCase, int maxLength)  // 0x1E34710ECD4AB0EB
```

build 323

> Compares two strings up to a specified number of characters.
> 
> Parameters:
> str1 - String to be compared.
> str2 - String to be compared.
> matchCase - Comparison will be case-sensitive.
> maxLength - Maximum number of characters to compare. A value of -1 indicates an infinite length.
> 
> Returns:
> A value indicating the relationship between the strings:
> <0 - The first non-matching character in 'str1' is less than the one in 'str2'. (e.g. 'A' < 'B', so result = -1)
> 0 - The contents of both strings are equal.
> >0 - The first non-matching character in 'str1' is less than the one in 'str2'. (e.g. 'B' > 'A', so result = 1)
> 
> Examples:
> MISC::COMPARE_STRINGS("STRING", "string", false, -1); // 0; equal
> MISC::COMPARE_STRINGS("TESTING", "test", false, 4); // 0; equal
> MISC::COMPARE_STRINGS("R2D2", "R2xx", false, 2); // 0; equal
> MISC::COMPARE_STRINGS("foo", "bar", false, -1); // 4; 'f' > 'b'
> MISC::COMPARE_STRINGS("A", "A", true, 1); // 0; equal
> 
> When comparing case-sensitive strings, lower-case characters are greater than upper-case characters:
> MISC::COMPARE_STRINGS("A", "a", true, 1); // -1; 'A' < 'a'
> MISC::COMPARE_STRINGS("a", "A", true, 1); // 1; 'a' > 'A'

## COPY_SCRIPT_STRUCT

```c
void COPY_SCRIPT_STRUCT(Any* dst, Any* src, int size)  // 0x213AEB2B90CBA7AC
```

build 877 · old names: `_COPY_MEMORY`

## CREATE_INCIDENT

```c
BOOL CREATE_INCIDENT(int dispatchService, float x, float y, float z, int numUnits, float radius, int* outIncidentID, Any p7, Any p8)  // 0x3F892CAF67444AE7
```

build 323

> As for the 'police' incident, it will call police cars to you, but unlike PedsInCavalcades & Merryweather they won't start shooting at you unless you shoot first or shoot at them. The top 2 however seem to cancel theirselves if there is noone dead around you or a fire. I only figured them out as I found out the 3rd param is definately the amountOfPeople and they called incident 3 in scripts with 4 people (which the firetruck has) and incident 5 with 2 people (which the ambulence has). The 4 param I cant say is radius, but for the pedsInCavalcades and Merryweather R* uses 0.0f and for the top 3 (Emergency Services) they use 3.0f. 
> 
> Side Note: It seems calling the pedsInCavalcades or Merryweather then removing it seems to break you from calling the EmergencyEvents and I also believe pedsInCavalcades. (The V cavalcades of course not IV).
> 
> Side Note 2: I say it breaks as if you call this proper,
> if(CREATE_INCIDENT) etc it will return false if you do as I said above.
> =====================================================

## CREATE_INCIDENT_WITH_ENTITY

```c
BOOL CREATE_INCIDENT_WITH_ENTITY(int dispatchService, Ped ped, int numUnits, float radius, int* outIncidentID, Any p5, Any p6)  // 0x05983472F0494E60
```

build 323

> As for the 'police' incident, it will call police cars to you, but unlike PedsInCavalcades & Merryweather they won't start shooting at you unless you shoot first or shoot at them. The top 2 however seem to cancel theirselves if there is noone dead around you or a fire. I only figured them out as I found out the 3rd param is definately the amountOfPeople and they called incident 3 in scripts with 4 people (which the firetruck has) and incident 5 with 2 people (which the ambulence has). The 4 param I cant say is radius, but for the pedsInCavalcades and Merryweather R* uses 0.0f and for the top 3 (Emergency Services) they use 3.0f. 
> 
> Side Note: It seems calling the pedsInCavalcades or Merryweather then removing it seems to break you from calling the EmergencyEvents and I also believe pedsInCavalcades. (The V cavalcades of course not IV).
> 
> Side Note 2: I say it breaks as if you call this proper,
> if(CREATE_INCIDENT) etc it will return false if you do as I said above.
> =====================================================

## DELETE_INCIDENT

```c
void DELETE_INCIDENT(int incidentId)  // 0x556C1AA270D5A207
```

build 323

> Delete an incident with a given id.
> 
> =======================================================
> Correction, I have change this to int, instead of int*
> as it doesn't use a pointer to the createdIncident.
> If you try it you will crash (or) freeze.
> =======================================================

## DELETE_STUNT_JUMP

```c
void DELETE_STUNT_JUMP(int p0)  // 0xDC518000E39DAE1F
```

build 323

## DISABLE_HOSPITAL_RESTART

```c
void DISABLE_HOSPITAL_RESTART(int hospitalIndex, BOOL toggle)  // 0xC8535819C450EBA8
```

build 323

> The game by default has 5 hospital respawn points. Disabling them all will cause the player to respawn at the last position they were.

## DISABLE_POLICE_RESTART

```c
void DISABLE_POLICE_RESTART(int policeIndex, BOOL toggle)  // 0x23285DED6EBD7EA3
```

build 323

> Disables the spawn point at the police house on the specified index.
> 
> policeIndex: The police house index.
> toggle: true to enable the spawn point, false to disable.
> 
> - Nacorpio

## DISABLE_SCREEN_DIMMING_THIS_FRAME

```c
void DISABLE_SCREEN_DIMMING_THIS_FRAME()  // 0x23227DF0B2115469
```

build 323

> Does nothing (it's a nullsub).

## DISABLE_STUNT_JUMP_SET

```c
void DISABLE_STUNT_JUMP_SET(int p0)  // 0xA5272EBEDD4747F6
```

build 323

## DISPLAY_ONSCREEN_KEYBOARD

```c
void DISPLAY_ONSCREEN_KEYBOARD(int p0, const char* windowTitle, const char* p2, const char* defaultText, const char* defaultConcat1, const char* defaultConcat2, const char* defaultConcat3, int maxInputLength)  // 0x00DC833F2568DBF6
```

build 323

> note, p0 is set to 6 for PC platform in at least 1 script, or to `GET_CURRENT_LANGUAGE() == 0` otherwise.
> 
> NOTE: windowTitle uses text labels, and an invalid value will display nothing.
> 
> https://gtaforums.com/topic/788343-vrel-script-hook-v/?p=1067380474
> 
> windowTitle's
> -----------------
> CELL_EMAIL_BOD  =   "Enter your Eyefind message"
> CELL_EMAIL_BODE =   "Message too long. Try again"
> CELL_EMAIL_BODF    =   "Forbidden message. Try again"
> CELL_EMAIL_SOD    =   "Enter your Eyefind subject"
> CELL_EMAIL_SODE =   "Subject too long. Try again"
> CELL_EMAIL_SODF    =   "Forbidden text. Try again"
> CELL_EMASH_BOD   =   "Enter your Eyefind message"
> CELL_EMASH_BODE =   "Message too long. Try again"
> CELL_EMASH_BODF    =   "Forbidden message. Try again"
> CELL_EMASH_SOD    =   "Enter your Eyefind subject"
> CELL_EMASH_SODE =   "Subject too long. Try again"
> CELL_EMASH_SODF    =   "Forbidden Text. Try again"
> FMMC_KEY_TIP10   =   "Enter Synopsis"
> FMMC_KEY_TIP12  =   "Enter Custom Team Name"
> FMMC_KEY_TIP12F =   "Forbidden Text. Try again"
> FMMC_KEY_TIP12N  =   "Custom Team Name"
> FMMC_KEY_TIP8 =   "Enter Message"
> FMMC_KEY_TIP8F   =   "Forbidden Text. Try again"
> FMMC_KEY_TIP8FS  =   "Invalid Message. Try again"
> FMMC_KEY_TIP8S  =   "Enter Message"
> FMMC_KEY_TIP9    =   "Enter Outfit Name"
> FMMC_KEY_TIP9F   =   "Invalid Outfit Name. Try again"
> FMMC_KEY_TIP9N  =   "Outfit Name"
> PM_NAME_CHALL  =   "Enter Challenge Name"

## DISPLAY_ONSCREEN_KEYBOARD_WITH_LONGER_INITIAL_STRING

```c
void DISPLAY_ONSCREEN_KEYBOARD_WITH_LONGER_INITIAL_STRING(int p0, const char* windowTitle, Any* p2, const char* defaultText, const char* defaultConcat1, const char* defaultConcat2, const char* defaultConcat3, const char* defaultConcat4, const char* defaultConcat5, const char* defaultConcat6, const char* defaultConcat7, int maxInputLength)  // 0xCA78CFA0366592FE
```

build 323 · old names: `_DISPLAY_ONSCREEN_KEYBOARD_2`

## DO_AUTO_SAVE

```c
void DO_AUTO_SAVE()  // 0x50EEAAD86232EE55
```

build 323

## DOES_POP_MULTIPLIER_AREA_EXIST

```c
BOOL DOES_POP_MULTIPLIER_AREA_EXIST(int id)  // 0x1327E2FE9746BAEE
```

build 323

## DOES_POP_MULTIPLIER_SPHERE_EXIST

```c
BOOL DOES_POP_MULTIPLIER_SPHERE_EXIST(int id)  // 0x171BAFB3C60389F4
```

build 791

## ENABLE_DISPATCH_SERVICE

```c
void ENABLE_DISPATCH_SERVICE(int dispatchService, BOOL toggle)  // 0xDC0F817884CDD856
```

build 323

> https://alloc8or.re/gta5/doc/enums/DispatchType.txt

## ENABLE_STUNT_JUMP_SET

```c
void ENABLE_STUNT_JUMP_SET(int p0)  // 0xE369A5783B866016
```

build 323

## ENABLE_TENNIS_MODE

```c
void ENABLE_TENNIS_MODE(Ped ped, BOOL toggle, BOOL p2)  // 0x28A04B411933F8A6
```

build 323

> Makes the ped jump around like they're in a tennis match

## END_REPLAY_STATS

```c
void END_REPLAY_STATS()  // 0xA23E821FBDF8A5F2
```

build 323

## FIND_SPAWN_POINT_IN_DIRECTION

```c
BOOL FIND_SPAWN_POINT_IN_DIRECTION(float posX, float posY, float posZ, float fwdVecX, float fwdVecY, float fwdVecZ, float distance, Vector3* spawnPoint)  // 0x6874E2190B0C1972
```

build 323

> Finds a position ahead of the player by predicting the players next actions.
> The positions match path finding node positions.
> When roads diverge, the position may rapidly change between two or more positions. This is due to the engine not being certain of which path the player will take.

## FORCE_GAME_STATE_PLAYING

```c
void FORCE_GAME_STATE_PLAYING()  // 0xC0AA53F866B3134D
```

build 323 · old names: `_RESET_LOCALPLAYER_STATE`

> Sets the localplayer playerinfo state back to playing (State 0)
> 
> States are:
> -1: "Invalid"
> 0: "Playing"
> 1: "Died"
> 2: "Arrested"
> 3: "Failed Mission"
> 4: "Left Game"
> 5: "Respawn"
> 6: "In MP Cutscene"

## FORCE_LIGHTNING_FLASH

```c
void FORCE_LIGHTNING_FLASH()  // 0xF6062E089251C898
```

build 323 · old names: `_CREATE_LIGHTNING_THUNDER`

> creates single lightning+thunder at random position

## GET_ALLOCATED_STACK_SIZE

```c
int GET_ALLOCATED_STACK_SIZE()  // 0x8B3CA62B1EF19B62
```

build 323

## GET_ANGLE_BETWEEN_2D_VECTORS

```c
float GET_ANGLE_BETWEEN_2D_VECTORS(float x1, float y1, float x2, float y2)  // 0x186FC4BE848E1C92
```

build 323

## GET_BASE_ELEMENT_LOCATION_FROM_METADATA_BLOCK

```c
BOOL GET_BASE_ELEMENT_LOCATION_FROM_METADATA_BLOCK(Any* p0, Any* p1, Any p2, BOOL p3)  // 0xB335F761606DB47C
```

build 323 · old names: `_GET_BASE_ELEMENT_METADATA`

## GET_BENCHMARK_ITERATIONS

```c
int GET_BENCHMARK_ITERATIONS()  // 0x4750FC27570311EC
```

build 323 · old names: `_GET_BENCHMARK_ITERATIONS_FROM_COMMAND_LINE`

> Returns value of the '-benchmarkIterations' command line option.

## GET_BENCHMARK_PASS

```c
int GET_BENCHMARK_PASS()  // 0x1B2366C3F2A5C8DF
```

build 323 · old names: `_GET_BENCHMARK_PASS_FROM_COMMAND_LINE`

> Returns value of the '-benchmarkPass' command line option.

## GET_BITS_IN_RANGE

```c
int GET_BITS_IN_RANGE(int var, int rangeStart, int rangeEnd)  // 0x53158863FCC0893A
```

build 323

## GET_CITY_DENSITY

```c
float GET_CITY_DENSITY()  // 0xD10282B6E3751BA0
```

build 323

## GET_CLOSEST_POINT_ON_LINE

```c
Vector3 GET_CLOSEST_POINT_ON_LINE(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, BOOL clamp)  // 0x21C235BC64831E5A
```

build 323

> clamp: sets whether the product should be clamped between the given coordinates

## GET_CLOUDS_ALPHA

```c
float GET_CLOUDS_ALPHA()  // 0x20AC25E781AE4A84
```

build 323 · old names: `_GET_CLOUD_HAT_OPACITY`

## GET_CONTENT_ID_INDEX

```c
int GET_CONTENT_ID_INDEX(Hash contentId)  // 0xECF041186C5A94DC
```

build 2612 · old names: `_GET_CONTENT_MAP_INDEX`

## GET_CONTENT_TO_LOAD

```c
const char* GET_CONTENT_TO_LOAD()  // 0x24DA7D7667FD7B09
```

build 323 · old names: `_GET_GLOBAL_CHAR_BUFFER`

> Returns pointer to an empty string.

## GET_COORDS_OF_PROJECTILE_TYPE_IN_ANGLED_AREA

```c
BOOL GET_COORDS_OF_PROJECTILE_TYPE_IN_ANGLED_AREA(float vecAngledAreaPoint1X, float vecAngledAreaPoint1Y, float vecAngledAreaPoint1Z, float vecAngledAreaPoint2X, float vecAngledAreaPoint2Y, float vecAngledAreaPoint2Z, float distanceOfOppositeFace, Hash weaponType, Vector3* positionOut, BOOL bIsPlayer)  // 0x3DA8C28346B62CED
```

build 2802

## GET_COORDS_OF_PROJECTILE_TYPE_IN_AREA

```c
BOOL GET_COORDS_OF_PROJECTILE_TYPE_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, Hash projectileHash, Vector3* projectilePos, BOOL ownedByPlayer)  // 0x8D7A43EC6A5FEA45
```

build 323 · old names: `_GET_IS_PROJECTILE_TYPE_IN_AREA`

## GET_COORDS_OF_PROJECTILE_TYPE_WITHIN_DISTANCE

```c
BOOL GET_COORDS_OF_PROJECTILE_TYPE_WITHIN_DISTANCE(Ped ped, Hash weaponHash, float distance, Vector3* outCoords, BOOL p4)  // 0xDFB4138EEFED7B81
```

build 323 · old names: `_GET_PROJECTILE_NEAR_PED_COORDS`

## GET_CURR_WEATHER_STATE

```c
void GET_CURR_WEATHER_STATE(Hash* weatherType1, Hash* weatherType2, float* percentWeather2)  // 0xF3BBE884A14BB413
```

build 323 · old names: `_GET_WEATHER_TYPE_TRANSITION`

## GET_DISTANCE_BETWEEN_COORDS

```c
float GET_DISTANCE_BETWEEN_COORDS(float x1, float y1, float z1, float x2, float y2, float z2, BOOL useZ)  // 0xF1B760881820C952
```

build 323

> Returns the distance between two three-dimensional points, optionally ignoring the Z values.
> If useZ is false, only the 2D plane (X-Y) will be considered for calculating the distance.
> 
> Consider using this faster native instead: SYSTEM::VDIST - DVIST always takes in consideration the 3D coordinates.

## GET_FAKE_WANTED_LEVEL

```c
int GET_FAKE_WANTED_LEVEL()  // 0x4C9296CBCD1B971E
```

build 323

## GET_FRAME_COUNT

```c
int GET_FRAME_COUNT()  // 0xFC8202EFC642E6F2
```

build 323

## GET_FRAME_TIME

```c
float GET_FRAME_TIME()  // 0x15C40837039FFAF7
```

build 323

## GET_GAME_TIMER

```c
int GET_GAME_TIMER()  // 0x9CD27B0045628463
```

build 323

## GET_GROUND_Z_AND_NORMAL_FOR_3D_COORD

```c
BOOL GET_GROUND_Z_AND_NORMAL_FOR_3D_COORD(float x, float y, float z, float* groundZ, Vector3* normal)  // 0x8BDC7BFC57A81E76
```

build 323 · old names: `_GET_GROUND_Z_COORD_WITH_OFFSETS`

## GET_GROUND_Z_EXCLUDING_OBJECTS_FOR_3D_COORD

```c
BOOL GET_GROUND_Z_EXCLUDING_OBJECTS_FOR_3D_COORD(float x, float y, float z, float* groundZ, BOOL p4, BOOL p5)  // 0x9E82F0F362881B29
```

build 505 · old names: `_GET_GROUND_Z_FOR_3D_COORD_2`

## GET_GROUND_Z_FOR_3D_COORD

```c
BOOL GET_GROUND_Z_FOR_3D_COORD(float x, float y, float z, float* groundZ, BOOL ignoreWater, BOOL p5)  // 0xC906A7DAB05C8D2B
```

build 323

> Gets the ground elevation at the specified position. Note that if the specified position is below ground level, the function will output zero!
> 
> x: Position on the X-axis to get ground elevation at.
> y: Position on the Y-axis to get ground elevation at.
> z: Position on the Z-axis to get ground elevation at.
> groundZ: The ground elevation at the specified position.
> ignoreWater: Nearly always 0, very rarely 1 in the scripts
> 
> Bear in mind this native can only calculate the elevation when the coordinates are within the client's render distance.

## GET_HASH_KEY

```c
Hash GET_HASH_KEY(const char* string)  // 0xD24D37CC275948CC
```

build 323

> This native converts its past string to hash. It is hashed using jenkins one at a time method.

## GET_HEADING_FROM_VECTOR_2D

```c
float GET_HEADING_FROM_VECTOR_2D(float dx, float dy)  // 0x2FFB6B224F4B2926
```

build 323

> dx = x1 - x2
> dy = y1 - y2

## GET_INDEX_OF_CURRENT_LEVEL

```c
int GET_INDEX_OF_CURRENT_LEVEL()  // 0xCBAD6729F7B1F4FC
```

build 323

## GET_IS_AUTO_SAVE_OFF

```c
BOOL GET_IS_AUTO_SAVE_OFF()  // 0x6E04F06094C87047
```

build 323

> Returns true if profile setting 208 is equal to 0.

## GET_IS_PLAYER_IN_ANIMAL_FORM

```c
BOOL GET_IS_PLAYER_IN_ANIMAL_FORM()  // 0x9689123E3F213AA5
```

build 323

> Although we don't have a jenkins hash for this one, the name is 100% confirmed.

## GET_LINE_PLANE_INTERSECTION

```c
BOOL GET_LINE_PLANE_INTERSECTION(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7, float p8, float p9, float p10, float p11, float* p12)  // 0xF56DFB7B61BE7276
```

build 323

## GET_MISSION_FLAG

```c
BOOL GET_MISSION_FLAG()  // 0xA33CDCCDA663159E
```

build 323

## GET_MODEL_DIMENSIONS

```c
void GET_MODEL_DIMENSIONS(Hash modelHash, Vector3* minimum, Vector3* maximum)  // 0x03E8D3D5F549087A
```

build 323

> Gets the dimensions of a model.
> 
> Calculate (maximum - minimum) to get the size, in which case, Y will be how long the model is.
> 
> Example from the scripts: MISC::GET_MODEL_DIMENSIONS(ENTITY::GET_ENTITY_MODEL(PLAYER::PLAYER_PED_ID()), &v_1A, &v_17);

## GET_NEXT_WEATHER_TYPE_HASH_NAME

```c
Hash GET_NEXT_WEATHER_TYPE_HASH_NAME()  // 0x711327CD09C8F162
```

build 323 · old names: `_GET_NEXT_WEATHER_TYPE`

> Returns weather name hash

## GET_NUM_SUCCESSFUL_STUNT_JUMPS

```c
int GET_NUM_SUCCESSFUL_STUNT_JUMPS()  // 0x996DD1E1E02F1008
```

build 323

## GET_NUMBER_OF_FREE_STACKS_OF_THIS_SIZE

```c
int GET_NUMBER_OF_FREE_STACKS_OF_THIS_SIZE(int stackSize)  // 0xFEAD16FC8F9DFC0F
```

build 323 · old names: `_GET_FREE_STACK_SLOTS_COUNT`

## GET_NUMBER_RESOURCES_ALLOCATED_TO_WANTED_LEVEL

```c
int GET_NUMBER_RESOURCES_ALLOCATED_TO_WANTED_LEVEL(int dispatchService)  // 0xEB4A0C2D56441717
```

build 323 · old names: `_GET_NUMBER_OF_DISPATCHED_UNITS_FOR_PLAYER`, `_GET_NUM_DISPATCHED_UNITS_FOR_PLAYER`

## GET_ONSCREEN_KEYBOARD_RESULT

```c
const char* GET_ONSCREEN_KEYBOARD_RESULT()  // 0x8362B09B91893647
```

build 323

> Returns NULL unless UPDATE_ONSCREEN_KEYBOARD() returns 1 in the same tick.

## GET_POINT_AREA_OVERLAP

```c
BOOL GET_POINT_AREA_OVERLAP(Any p0, Any p1, Any p2, Any p3, Any p4, Any p5, Any p6, Any p7, Any p8, Any p9, Any p10, Any p11, Any p12, Any p13)  // 0xA0AD167E4B39D9A2
```

build 2189

## GET_PREV_WEATHER_TYPE_HASH_NAME

```c
Hash GET_PREV_WEATHER_TYPE_HASH_NAME()  // 0x564B884A05EC45A3
```

build 323 · old names: `_GET_PREV_WEATHER_TYPE`

> Returns current weather name hash

## GET_PROFILE_SETTING

```c
int GET_PROFILE_SETTING(int profileSetting)  // 0xC488FF2356EA7791
```

build 323

## GET_PROJECTILE_OF_PROJECTILE_TYPE_WITHIN_DISTANCE

```c
BOOL GET_PROJECTILE_OF_PROJECTILE_TYPE_WITHIN_DISTANCE(Ped ped, Hash weaponHash, float distance, Vector3* outCoords, Object* outProjectile, BOOL p5)  // 0x82FDE6A57EE4EE44
```

build 323 · old names: `_GET_PROJECTILE_NEAR_PED`

## GET_RAIN_LEVEL

```c
float GET_RAIN_LEVEL()  // 0x96695E368AD855F3
```

build 323

## GET_RANDOM_EVENT_FLAG

```c
BOOL GET_RANDOM_EVENT_FLAG()  // 0xD2D57F1D764117B1
```

build 323

## GET_RANDOM_FLOAT_IN_RANGE

```c
float GET_RANDOM_FLOAT_IN_RANGE(float startRange, float endRange)  // 0x313CE5879CEB6FCD
```

build 323

## GET_RANDOM_INT_IN_RANGE

```c
int GET_RANDOM_INT_IN_RANGE(int startRange, int endRange)  // 0xD53343AA4FB7DD28
```

build 323

## GET_RANDOM_MWC_INT_IN_RANGE

```c
int GET_RANDOM_MWC_INT_IN_RANGE(int startRange, int endRange)  // 0xF2D49816A804D134
```

build 1734 · old names: `_GET_RANDOM_INT_IN_RANGE_2`

## GET_RATIO_OF_CLOSEST_POINT_ON_LINE

```c
float GET_RATIO_OF_CLOSEST_POINT_ON_LINE(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, BOOL clamp)  // 0x7F8F6405F4777AF6
```

build 323 · old names: `_GET_PROGRESS_ALONG_LINE_BETWEEN_COORDS`

> returns a float between 0.0 and 1.0, clamp: sets whether the product should be clamped between the given coordinates

## GET_REAL_WORLD_TIME

```c
int GET_REAL_WORLD_TIME()  // 0x3F60413F5DF65748
```

build 2612

> GET_GAME_TIMER() / 1000

## GET_REPLAY_STAT_AT_INDEX

```c
int GET_REPLAY_STAT_AT_INDEX(int index)  // 0x8098C8D6597AAE18
```

build 323

## GET_REPLAY_STAT_COUNT

```c
int GET_REPLAY_STAT_COUNT()  // 0xDC9274A7EF6B2867
```

build 323

## GET_REPLAY_STAT_MISSION_ID

```c
int GET_REPLAY_STAT_MISSION_ID()  // 0x5B1F2E327B6B6FE1
```

build 323

## GET_REPLAY_STAT_MISSION_TYPE

```c
int GET_REPLAY_STAT_MISSION_TYPE()  // 0x2B626A0150E4D449
```

build 323

## GET_SAVE_HOUSE_DETAILS_AFTER_SUCCESSFUL_LOAD

```c
BOOL GET_SAVE_HOUSE_DETAILS_AFTER_SUCCESSFUL_LOAD(Vector3* p0, float* p1, BOOL* fadeInAfterLoad, BOOL* p3)  // 0xA4A0065E39C9F25C
```

build 323

## GET_SIZE_OF_SAVE_DATA

```c
int GET_SIZE_OF_SAVE_DATA(BOOL p0)  // 0xA09F896CE912481F
```

build 323

## GET_SNOW_LEVEL

```c
float GET_SNOW_LEVEL()  // 0xC5868A966E5BE3AE
```

build 323

## GET_STATUS_OF_MANUAL_SAVE

```c
int GET_STATUS_OF_MANUAL_SAVE()  // 0x397BAA01068BAA96
```

build 323

## GET_STATUS_OF_MISSION_REPEAT_SAVE

```c
int GET_STATUS_OF_MISSION_REPEAT_SAVE()  // 0x2B5E102E4A42F2BF
```

build 323

## GET_SYSTEM_TIME_STEP

```c
float GET_SYSTEM_TIME_STEP()  // 0xE599A503B3837E1B
```

build 323 · old names: `_GET_BENCHMARK_TIME`

## GET_TENNIS_SWING_ANIM_CAN_BE_INTERRUPTED

```c
BOOL GET_TENNIS_SWING_ANIM_CAN_BE_INTERRUPTED(Ped ped)  // 0x19BFED045C647C49
```

build 323

## GET_TENNIS_SWING_ANIM_COMPLETE

```c
BOOL GET_TENNIS_SWING_ANIM_COMPLETE(Ped ped)  // 0x17DF68D720AA77F8
```

build 323

## GET_TENNIS_SWING_ANIM_SWUNG

```c
BOOL GET_TENNIS_SWING_ANIM_SWUNG(Ped ped)  // 0xE95B0C7D5BA3B96B
```

build 323

## GET_TOTAL_SUCCESSFUL_STUNT_JUMPS

```c
int GET_TOTAL_SUCCESSFUL_STUNT_JUMPS()  // 0x6856EC3D35C81EA4
```

build 323

## GET_WIND_DIRECTION

```c
Vector3 GET_WIND_DIRECTION()  // 0x1F400FEF721170DA
```

build 323

## GET_WIND_SPEED

```c
float GET_WIND_SPEED()  // 0xA8CF1CC0AFCD3F12
```

build 323

## HAS_ASYNC_INSTALL_FINISHED

```c
BOOL HAS_ASYNC_INSTALL_FINISHED()  // 0x14832BF2ABA53FC5
```

build 323 · old names: `_HAS_ASYNC_INSTALL_FINISHED`

> Hardcoded to always return true.

## HAS_BULLET_IMPACTED_IN_AREA

```c
BOOL HAS_BULLET_IMPACTED_IN_AREA(float x, float y, float z, float radius, BOOL bIsPlayer, BOOL bIsEntry)  // 0x9870ACFB89A90995
```

build 323

> bIsPlayer: checks if the player fired the bullet
> bEntryOnly: only find entry impacts

## HAS_BULLET_IMPACTED_IN_BOX

```c
BOOL HAS_BULLET_IMPACTED_IN_BOX(float p0, float p1, float p2, float p3, float p4, float p5, BOOL p6, BOOL p7)  // 0xDC8C5D7CFEAB8394
```

build 323

## HAS_CHEAT_WITH_HASH_BEEN_ACTIVATED

```c
BOOL HAS_CHEAT_WITH_HASH_BEEN_ACTIVATED(Hash hash, int amount)  // 0x071E2A839DE82D90
```

build 323 · old names: `_HAS_BUTTON_COMBINATION_JUST_BEEN_ENTERED`

> This native appears on the cheat_controller script and tracks a combination of buttons, which may be used to toggle cheats in-game. Credits to ThreeSocks for the info. The hash contains the combination, while the "amount" represents the amount of buttons used in a combination. The following page can be used to make a button combination: gta5offset.com/ts/hash/
> 
> INT_SCORES_SCORTED was a hash collision

## HAS_CODE_REQUESTED_AUTOSAVE

```c
BOOL HAS_CODE_REQUESTED_AUTOSAVE()  // 0x2107A3773771186D
```

build 323

## HAS_GAME_INSTALLED_THIS_SESSION

```c
BOOL HAS_GAME_INSTALLED_THIS_SESSION()  // 0x6FDDF453C0C756EC
```

build 323

## HAS_PC_CHEAT_WITH_HASH_BEEN_ACTIVATED

```c
BOOL HAS_PC_CHEAT_WITH_HASH_BEEN_ACTIVATED(Hash hash)  // 0x557E43C447E700A8
```

build 323 · old names: `_HAS_CHEAT_STRING_JUST_BEEN_ENTERED`

> Get inputted "Cheat code", for example:
> 
> while (TRUE)
> {
>     if (MISC::HAS_PC_CHEAT_WITH_HASH_BEEN_ACTIVATED(${fugitive}))
>     {
>        // Do something.
>     }
>     SYSTEM::WAIT(0);
> }
> 
> Calling this will also set the last saved string hash to zero.
> 

## HAS_RESUMED_FROM_SUSPEND

```c
BOOL HAS_RESUMED_FROM_SUSPEND()  // 0xE8B9C0EC9E183F35
```

build 323 · old names: `_HAS_RESUMED_FROM_SUSPEND`

> Hardcoded to return false.

## HAVE_CREDITS_REACHED_END

```c
BOOL HAVE_CREDITS_REACHED_END()  // 0x075F1D57402C93BA
```

build 323

## HAVE_REPLAY_STATS_BEEN_STORED

```c
BOOL HAVE_REPLAY_STATS_BEEN_STORED()  // 0xD642319C54AADEB6
```

build 323

## IGNORE_NEXT_RESTART

```c
void IGNORE_NEXT_RESTART(BOOL toggle)  // 0x21FFB63D8C615361
```

build 323

## INFORM_CODE_OF_CONTENT_ID_OF_CURRENT_UGC_MISSION

```c
void INFORM_CODE_OF_CONTENT_ID_OF_CURRENT_UGC_MISSION(const char* p0)  // 0x8D74E26F54B4E5C3
```

build 323

## IS_AREA_OCCUPIED

```c
BOOL IS_AREA_OCCUPIED(float p0, float p1, float p2, float p3, float p4, float p5, BOOL p6, BOOL p7, BOOL p8, BOOL p9, BOOL p10, Any p11, BOOL p12)  // 0xA61B4DF533DCB56E
```

build 323

## IS_AREA_OCCUPIED_SLOW

```c
BOOL IS_AREA_OCCUPIED_SLOW(Any p0, Any p1, Any p2, Any p3, Any p4, Any p5, Any p6, Any p7, Any p8, Any p9, Any p10, Any p11, Any p12)  // 0x39455BF4F4F55186
```

build 1868

## IS_AUSSIE_VERSION

```c
BOOL IS_AUSSIE_VERSION()  // 0x9F1935CA1F724008
```

build 323

> Used to block some of the prostitute stuff due to laws in Australia.

## IS_AUTO_SAVE_IN_PROGRESS

```c
BOOL IS_AUTO_SAVE_IN_PROGRESS()  // 0x69240733738C19A0
```

build 323

## IS_BULLET_IN_ANGLED_AREA

```c
BOOL IS_BULLET_IN_ANGLED_AREA(float x1, float y1, float z1, float x2, float y2, float z2, float width, BOOL ownedByPlayer)  // 0x1A8B5F3C01E2B477
```

build 323

> For projectiles, see: IS_PROJECTILE_TYPE_IN_ANGLED_AREA
> See IS_POINT_IN_ANGLED_AREA for the definition of an angled area.
> Returns True if a bullet, as maintained by a pool within CWeaponManager, has been fired into the defined angled area.

## IS_BULLET_IN_AREA

```c
BOOL IS_BULLET_IN_AREA(float x, float y, float z, float radius, BOOL ownedByPlayer)  // 0x3F2023999AD51C1F
```

build 323

## IS_BULLET_IN_BOX

```c
BOOL IS_BULLET_IN_BOX(float x1, float y1, float z1, float x2, float y2, float z2, BOOL ownedByPlayer)  // 0xDE0F6D7450D37351
```

build 323

## IS_COMMANDLINE_END_USER_BENCHMARK

```c
BOOL IS_COMMANDLINE_END_USER_BENCHMARK()  // 0xA049A5BE0F04F2F8
```

build 323 · old names: `_IS_COMMAND_LINE_BENCHMARK_VALUE_SET`

> Returns true if command line option '-benchmark' is set.

## IS_DURANGO_VERSION

```c
BOOL IS_DURANGO_VERSION()  // 0x4D982ADB1978442D
```

build 323

> XBOX ONE

## IS_FRONTEND_FADING

```c
BOOL IS_FRONTEND_FADING()  // 0x7EA2B6AF97ECA6ED
```

build 323

> This function is hard-coded to always return 0.

## IS_INCIDENT_VALID

```c
BOOL IS_INCIDENT_VALID(int incidentId)  // 0xC8BC6461E629BEAA
```

build 323

> =======================================================
> Correction, I have change this to int, instead of int*
> as it doesn't use a pointer to the createdIncident.
> If you try it you will crash (or) freeze.
> =======================================================

## IS_JAPANESE_VERSION

```c
BOOL IS_JAPANESE_VERSION()  // 0xB8C0BB75D8A77DB3
```

build 2545 · old names: `_IS_JAPANESE_VERSION`

## IS_MEMORY_CARD_IN_USE

```c
BOOL IS_MEMORY_CARD_IN_USE()  // 0x8A75CE2956274ADD
```

build 323

## IS_MINIGAME_IN_PROGRESS

```c
BOOL IS_MINIGAME_IN_PROGRESS()  // 0x2B4A15E44DE0F478
```

build 323

## IS_NEXT_WEATHER_TYPE

```c
BOOL IS_NEXT_WEATHER_TYPE(const char* weatherType)  // 0x2FAA3A30BEC0F25D
```

build 323

## IS_ORBIS_VERSION

```c
BOOL IS_ORBIS_VERSION()  // 0xA72BC0B675B1519E
```

build 323

> PS4

## IS_PC_VERSION

```c
BOOL IS_PC_VERSION()  // 0x48AF36444B965238
```

build 323

## IS_POINT_OBSCURED_BY_A_MISSION_ENTITY

```c
BOOL IS_POINT_OBSCURED_BY_A_MISSION_ENTITY(float p0, float p1, float p2, float p3, float p4, float p5, Any p6)  // 0xE54E209C35FFA18D
```

build 323

## IS_POP_MULTIPLIER_AREA_NETWORKED

```c
BOOL IS_POP_MULTIPLIER_AREA_NETWORKED(int id)  // 0x1312F4B242609CE3
```

build 1290 · old names: `_IS_POP_MULTIPLIER_AREA_UNK`

## IS_POSITION_OCCUPIED

```c
BOOL IS_POSITION_OCCUPIED(float x, float y, float z, float range, BOOL p4, BOOL checkVehicles, BOOL checkPeds, BOOL p7, BOOL p8, Entity ignoreEntity, BOOL p10)  // 0xADCDE75E1C60F32D
```

build 323

> `range`: The range, seems to not be very accurate during testing.
> `p4`: Unknown, when set to true it seems to always return true no matter what I try.
> `checkVehicle`: Check for any vehicles in that area.
> `checkPeds`: Check for any peds in that area.
> `ignoreEntity`: This entity will be ignored if it's in the area. Set to 0 if you don't want to exclude any entities.
> The BOOL parameters that are documented have not been confirmed. They are just documented from what I've found during testing. They may not work as expected in all cases.
> 
> Returns true if there is anything in that location matching the provided parameters.

## IS_PREV_WEATHER_TYPE

```c
BOOL IS_PREV_WEATHER_TYPE(const char* weatherType)  // 0x44F28F86433B10A9
```

build 323

## IS_PROJECTILE_IN_AREA

```c
BOOL IS_PROJECTILE_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, BOOL ownedByPlayer)  // 0x5270A8FBC098C3F8
```

build 323

> Determines whether there is a projectile within the specified coordinates. The coordinates form a rectangle.
> 
> - Nacorpio
> 
> 
> ownedByPlayer = only projectiles fired by the player will be detected.

## IS_PROJECTILE_TYPE_IN_ANGLED_AREA

```c
BOOL IS_PROJECTILE_TYPE_IN_ANGLED_AREA(float x1, float y1, float z1, float x2, float y2, float z2, float width, Any p7, BOOL ownedByPlayer)  // 0xF0BC12401061DEA0
```

build 323

> See IS_POINT_IN_ANGLED_AREA for the definition of an angled area.

## IS_PROJECTILE_TYPE_IN_AREA

```c
BOOL IS_PROJECTILE_TYPE_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, int type, BOOL ownedByPlayer)  // 0x2E0DC353342C4A6D
```

build 323

> Determines whether there is a projectile of a specific type within the specified coordinates. The coordinates form a axis-aligned bounding box.

## IS_PROJECTILE_TYPE_WITHIN_DISTANCE

```c
BOOL IS_PROJECTILE_TYPE_WITHIN_DISTANCE(float x, float y, float z, Hash projectileHash, float radius, BOOL ownedByPlayer)  // 0x34318593248C8FB2
```

build 323 · old names: `_IS_PROJECTILE_TYPE_IN_RADIUS`

## IS_PROSPERO_VERSION

```c
BOOL IS_PROSPERO_VERSION()  // 0x807ABE1AB65C24D2
```

build 2612

> PS5 (Prospero) version...

## IS_PS3_VERSION

```c
BOOL IS_PS3_VERSION()  // 0xCCA1072C29D096C2
```

build 323

## IS_SCARLETT_VERSION

```c
BOOL IS_SCARLETT_VERSION()  // 0xC545AB1CF97ABB34
```

build 2612

> Xbox Series (Scarlett) version...

## IS_SCE_PLATFORM

```c
BOOL IS_SCE_PLATFORM()  // 0xF911E695C1EB8518
```

build 2612

## IS_SNIPER_BULLET_IN_AREA

```c
BOOL IS_SNIPER_BULLET_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2)  // 0xFEFCF11B01287125
```

build 323

> Determines whether there is a sniper bullet within the specified coordinates. The coordinates form an axis-aligned bounding box.

## IS_SNIPER_INVERTED

```c
BOOL IS_SNIPER_INVERTED()  // 0x61A23B7EDA9BDA24
```

build 323

> This function is hard-coded to always return 0.

## IS_STEAM_VERSION

```c
BOOL IS_STEAM_VERSION()  // 0x0A27B2B6282F7169
```

build 2545

## IS_STRING_NULL

```c
BOOL IS_STRING_NULL(const char* string)  // 0xF22B6C47C6EAB066
```

build 323

## IS_STRING_NULL_OR_EMPTY

```c
BOOL IS_STRING_NULL_OR_EMPTY(const char* string)  // 0xCA042B6957743895
```

build 323

## IS_STUNT_JUMP_IN_PROGRESS

```c
BOOL IS_STUNT_JUMP_IN_PROGRESS()  // 0x7A3F19700A4D0525
```

build 323

## IS_STUNT_JUMP_MESSAGE_SHOWING

```c
BOOL IS_STUNT_JUMP_MESSAGE_SHOWING()  // 0x2272B0A1343129F4
```

build 323

## IS_TENNIS_MODE

```c
BOOL IS_TENNIS_MODE(Ped ped)  // 0x5D5479D115290C3F
```

build 323

## IS_THIS_A_MINIGAME_SCRIPT

```c
BOOL IS_THIS_A_MINIGAME_SCRIPT()  // 0x7B30F65D7B710098
```

build 323

## IS_XBOX_PLATFORM

```c
BOOL IS_XBOX_PLATFORM()  // 0x138679CA01E21F53
```

build 2612

## IS_XBOX360_VERSION

```c
BOOL IS_XBOX360_VERSION()  // 0xF6201B4DAF662A9D
```

build 323

## LANDING_SCREEN_STARTED_END_USER_BENCHMARK

```c
BOOL LANDING_SCREEN_STARTED_END_USER_BENCHMARK()  // 0x3BBBD13E5041A79E
```

build 323 · old names: `_LANDING_MENU_IS_ACTIVE`

> Returns true if the current frontend menu is FE_MENU_VERSION_LANDING_MENU

## LOAD_CLOUD_HAT

```c
void LOAD_CLOUD_HAT(const char* name, float transitionTime)  // 0xFC4842A34657BFCB
```

build 323 · old names: `_SET_CLOUD_HAT_TRANSITION`

> The following cloudhats are useable:
> altostratus
> Cirrus
> cirrocumulus
> Clear 01
> Cloudy 01
> Contrails
> Horizon
> horizonband1
> horizonband2
> horizonband3
> horsey
> Nimbus
> Puffs
> RAIN
> Snowy 01
> Stormy 01
> stratoscumulus
> Stripey
> shower
> Wispy
> 

## NETWORK_SET_SCRIPT_IS_SAFE_FOR_NETWORK_GAME

```c
void NETWORK_SET_SCRIPT_IS_SAFE_FOR_NETWORK_GAME()  // 0x9243BAC96D64C050
```

build 323

## NEXT_ONSCREEN_KEYBOARD_RESULT_WILL_DISPLAY_USING_THESE_FONTS

```c
void NEXT_ONSCREEN_KEYBOARD_RESULT_WILL_DISPLAY_USING_THESE_FONTS(int p0)  // 0x3ED1438C1F5C6612
```

build 323

> p0 was always 2 in R* scripts.
> Called before calling DISPLAY_ONSCREEN_KEYBOARD if the input needs to be saved.

## OVERRIDE_FREEZE_FLAGS

```c
void OVERRIDE_FREEZE_FLAGS(BOOL p0)  // 0xFA3FFB0EEBC288A3
```

build 2060

## OVERRIDE_SAVE_HOUSE

```c
BOOL OVERRIDE_SAVE_HOUSE(BOOL p0, float p1, float p2, float p3, float p4, BOOL p5, float p6, float p7)  // 0x1162EA8AE9D24EEA
```

build 323

## PAUSE_DEATH_ARREST_RESTART

```c
void PAUSE_DEATH_ARREST_RESTART(BOOL toggle)  // 0x2C2B3493FBF51C71
```

build 323 · old names: `_DISABLE_AUTOMATIC_RESPAWN`

## PLAY_TENNIS_DIVE_ANIM

```c
void PLAY_TENNIS_DIVE_ANIM(Ped ped, int p1, float p2, float p3, float p4, BOOL p5)  // 0x8FA9C42FC5D7C64B
```

build 323

## PLAY_TENNIS_SWING_ANIM

```c
void PLAY_TENNIS_SWING_ANIM(Ped ped, const char* animDict, const char* animName, float p3, float p4, BOOL p5)  // 0xE266ED23311F24D4
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## PLM_GET_CONSTRAINED_DURATION_MS

```c
int PLM_GET_CONSTRAINED_DURATION_MS()  // 0xABB2FA71C83A1B72
```

build 323 · old names: `_GET_POWER_SAVING_MODE_DURATION`

> Returns duration of how long the game has been in power-saving mode (aka "constrained") in milliseconds.

## PLM_IS_IN_CONSTRAINED_MODE

```c
BOOL PLM_IS_IN_CONSTRAINED_MODE()  // 0x684A41975F077262
```

build 323 · old names: `_IS_IN_POWER_SAVING_MODE`

> aka "constrained"

## POPULATE_NOW

```c
void POPULATE_NOW()  // 0x7472BB270D7B4F3E
```

build 323

> spawns a few distant/out-of-sight peds, vehicles, animals etc each time it is called

## PRELOAD_CLOUD_HAT

```c
void PRELOAD_CLOUD_HAT(const char* name)  // 0x11B56FBBF7224868
```

build 323

## PREVENT_ARREST_STATE_THIS_FRAME

```c
void PREVENT_ARREST_STATE_THIS_FRAME()  // 0xE3D969D2785FFB5E
```

build 323

## QUEUE_MISSION_REPEAT_LOAD

```c
BOOL QUEUE_MISSION_REPEAT_LOAD()  // 0x72DE52178C291CB5
```

build 323

## QUEUE_MISSION_REPEAT_SAVE

```c
BOOL QUEUE_MISSION_REPEAT_SAVE()  // 0x44A0BDC559B35F6E
```

build 323

> Shows the screen which is visible before you redo a mission? The game will make a restoration point where you will cameback when the mission is over.
> Returns 1 if the message isn't currently on screen

## QUEUE_MISSION_REPEAT_SAVE_FOR_BENCHMARK_TEST

```c
BOOL QUEUE_MISSION_REPEAT_SAVE_FOR_BENCHMARK_TEST()  // 0xEB2104E905C6F2E9
```

build 323

## QUIT_GAME

```c
void QUIT_GAME()  // 0xEB6891F03362FB12
```

build 323 · old names: `_FORCE_SOCIAL_CLUB_UPDATE`

> Exits the game and downloads a fresh social club update on next restart.

## REGISTER_BOOL_TO_SAVE

```c
void REGISTER_BOOL_TO_SAVE(Any* p0, const char* name)  // 0xC8F4131414C835A1
```

build 323

## REGISTER_ENUM_TO_SAVE

```c
void REGISTER_ENUM_TO_SAVE(Any* p0, const char* name)  // 0x10C2FA78D0E128A1
```

build 323

## REGISTER_FLOAT_TO_SAVE

```c
void REGISTER_FLOAT_TO_SAVE(Any* p0, const char* name)  // 0x7CAEC29ECB5DFEBB
```

build 323

## REGISTER_INT_TO_SAVE

```c
void REGISTER_INT_TO_SAVE(Any* p0, const char* name)  // 0x34C9EE5986258415
```

build 323

## REGISTER_INT64_TO_SAVE

```c
void REGISTER_INT64_TO_SAVE(Any* p0, const char* name)  // 0xA735353C77334EA0
```

build 323 · old names: `_REGISTER_INT64_TO_SAVE`

## REGISTER_SAVE_HOUSE

```c
int REGISTER_SAVE_HOUSE(float x, float y, float z, float p3, const char* p4, Any p5, Any p6)  // 0xC0714D0A7EEECA54
```

build 323

> returns savehouseHandle

## REGISTER_TEXT_LABEL_15_TO_SAVE

```c
void REGISTER_TEXT_LABEL_15_TO_SAVE(Any* p0, const char* name)  // 0x6F7794F28C6B2535
```

build 323 · old names: `_REGISTER_TEXT_LABEL_TO_SAVE_2`

> MISC::REGISTER_TEXT_LABEL_15_TO_SAVE(&a_0._f1, "tlPlateText");
> MISC::REGISTER_TEXT_LABEL_15_TO_SAVE(&a_0._f1C, "tlPlateText_pending");
> MISC::REGISTER_TEXT_LABEL_15_TO_SAVE(&a_0._f10B, "tlCarAppPlateText");

## REGISTER_TEXT_LABEL_23_TO_SAVE

```c
void REGISTER_TEXT_LABEL_23_TO_SAVE(Any* p0, const char* name)  // 0x48F069265A0E4BEC
```

build 323

> Only found 3 times in decompiled scripts.
> 
> MISC::REGISTER_TEXT_LABEL_23_TO_SAVE(a_0, "Movie_Name_For_This_Player");
> MISC::REGISTER_TEXT_LABEL_23_TO_SAVE(&a_0._fB, "Ringtone_For_This_Player");
> MISC::REGISTER_TEXT_LABEL_23_TO_SAVE(&a_0._f1EC4._f12[v_A/*6*/], &v_13); // where v_13 is "MPATMLOGSCRS0" thru "MPATMLOGSCRS15"

## REGISTER_TEXT_LABEL_31_TO_SAVE

```c
void REGISTER_TEXT_LABEL_31_TO_SAVE(Any* p0, const char* name)  // 0x8269816F6CFD40F8
```

build 323

> Only found 2 times in decompiled scripts.
> 
> MISC::REGISTER_TEXT_LABEL_31_TO_SAVE(&a_0._f1F5A._f6[0/*8*/], "TEMPSTAT_LABEL"); // gets saved in a struct called "g_SaveData_STRING_ScriptSaves"
> MISC::REGISTER_TEXT_LABEL_31_TO_SAVE(&a_0._f4B4[v_1A/*8*/], &v_5); // where v_5 is "Name0" thru "Name9", gets saved in a struct called "OUTFIT_Name"

## REGISTER_TEXT_LABEL_63_TO_SAVE

```c
void REGISTER_TEXT_LABEL_63_TO_SAVE(Any* p0, const char* name)  // 0xFAA457EF263E8763
```

build 323

> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(a_0, "Thumb_label");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f10, "Photo_label");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(a_0, "GXTlabel");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f21, "StringComp");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f43, "SecondStringComp");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f53, "ThirdStringComp");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f32, "SenderStringComp");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f726[v_1A/*16*/], &v_20); // where v_20 is "LastJobTL_0_1" thru "LastJobTL_2_1", gets saved in a struct called "LAST_JobGamer_TL"
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f4B, "PAID_PLAYER");
> MISC::REGISTER_TEXT_LABEL_63_TO_SAVE(&a_0._f5B, "RADIO_STATION");

## REGISTER_TEXT_LABEL_TO_SAVE

```c
void REGISTER_TEXT_LABEL_TO_SAVE(Any* p0, const char* name)  // 0xEDB1232C5BEAE62F
```

build 323

## REMOVE_DISPATCH_SPAWN_BLOCKING_AREA

```c
void REMOVE_DISPATCH_SPAWN_BLOCKING_AREA(int p0)  // 0x264AC28B01B353A5
```

build 323

## REMOVE_POP_MULTIPLIER_AREA

```c
void REMOVE_POP_MULTIPLIER_AREA(int id, BOOL p1)  // 0xB129E447A2EDA4BF
```

build 323

## REMOVE_POP_MULTIPLIER_SPHERE

```c
void REMOVE_POP_MULTIPLIER_SPHERE(int id, BOOL p1)  // 0xE6869BECDD8F2403
```

build 323

> Removes population multiplier sphere

## RESET_DISPATCH_IDEAL_SPAWN_DISTANCE

```c
void RESET_DISPATCH_IDEAL_SPAWN_DISTANCE()  // 0x77A84429DD9F0A15
```

build 323

## RESET_DISPATCH_SPAWN_BLOCKING_AREAS

```c
void RESET_DISPATCH_SPAWN_BLOCKING_AREAS()  // 0xAC7BFD5C1D83EA75
```

build 323

## RESET_DISPATCH_SPAWN_LOCATION

```c
void RESET_DISPATCH_SPAWN_LOCATION()  // 0x5896F2BD5683A4E1
```

build 1868 · old names: `_RESET_DISPATCH_SPAWN_LOCATION`

## RESET_DISPATCH_TIME_BETWEEN_SPAWN_ATTEMPTS

```c
void RESET_DISPATCH_TIME_BETWEEN_SPAWN_ATTEMPTS(Any p0)  // 0xEB2DB0CAD13154B3
```

build 323

## RESET_END_USER_BENCHMARK

```c
void RESET_END_USER_BENCHMARK()  // 0x437138B6A830166A
```

build 323 · old names: `_RESET_BENCHMARK_RECORDING`

## RESET_WANTED_RESPONSE_NUM_PEDS_TO_SPAWN

```c
void RESET_WANTED_RESPONSE_NUM_PEDS_TO_SPAWN()  // 0xD9F692D349249528
```

build 323

## RESTART_GAME

```c
void RESTART_GAME()  // 0xE574A662ACAEFBB1
```

build 372 · old names: `_RESTART_GAME`

> In singleplayer it does exactly what the name implies. In FiveM / GTA:Online it shows `Disconnecting from GTA Online` HUD and then quits the game.

## SAVE_END_USER_BENCHMARK

```c
void SAVE_END_USER_BENCHMARK()  // 0x37DEB0AA183FB6D8
```

build 323 · old names: `_SAVE_BENCHMARK_RECORDING`

> Saves the benchmark recording to %USERPROFILE%\Documents\Rockstar Games\GTA V\Benchmarks and submits some metrics.

## SCRIPT_RACE_GET_PLAYER_SPLIT_TIME

```c
BOOL SCRIPT_RACE_GET_PLAYER_SPLIT_TIME(Player player, int* p1, int* p2)  // 0x8EF5573A1F801A5C
```

build 323

## SCRIPT_RACE_INIT

```c
void SCRIPT_RACE_INIT(int p0, int p1, Any p2, Any p3)  // 0x0A60017F841A54F2
```

build 323

## SCRIPT_RACE_PLAYER_HIT_CHECKPOINT

```c
void SCRIPT_RACE_PLAYER_HIT_CHECKPOINT(Player player, Any p1, Any p2, Any p3)  // 0x1BB299305C3E8C13
```

build 323

## SCRIPT_RACE_SHUTDOWN

```c
void SCRIPT_RACE_SHUTDOWN()  // 0x1FF6BF9A63E5757F
```

build 323

## SET_BEAST_JUMP_THIS_FRAME

```c
void SET_BEAST_JUMP_THIS_FRAME(Player player)  // 0x438822C279B73B93
```

build 573 · old names: `_SET_BEAST_MODE_ACTIVE`

## SET_BIT

```c
void SET_BIT(int* address, int offset)  // 0x933D6A9EEC1BACD0
```

build 323

> This sets bit [offset] of [address] to on.
> 
> The offsets used are different bits to be toggled on and off, typically there is only one address used in a script.
> 
> Example:
> MISC::SET_BIT(&bitAddress, 1);
> 
> To check if this bit has been enabled:
> MISC::IS_BIT_SET(bitAddress, 1); // will return 1 afterwards
> 
> Please note, this method may assign a value to [address] when used.

## SET_BITS_IN_RANGE

```c
void SET_BITS_IN_RANGE(int* var, int rangeStart, int rangeEnd, int p3)  // 0x8EF07E15701D61ED
```

build 323

## SET_CLOUD_SETTINGS_OVERRIDE

```c
void SET_CLOUD_SETTINGS_OVERRIDE(const char* p0)  // 0x02DEAAC8F8EA7FE7
```

build 323

## SET_CLOUDS_ALPHA

```c
void SET_CLOUDS_ALPHA(float opacity)  // 0xF36199225D6D8C86
```

build 323 · old names: `_SET_CLOUD_HAT_OPACITY`

## SET_CONTENT_ID_INDEX

```c
void SET_CONTENT_ID_INDEX(Hash contentId, int index)  // 0x4B82FA6F2D624634
```

build 2612 · old names: `_SET_CONTENT_MAP_INDEX`

## SET_CREDITS_ACTIVE

```c
void SET_CREDITS_ACTIVE(BOOL toggle)  // 0xB938B7E6D3C0620C
```

build 323

## SET_CREDITS_FADE_OUT_WITH_SCREEN

```c
void SET_CREDITS_FADE_OUT_WITH_SCREEN(BOOL toggle)  // 0xB51B9AB9EF81868C
```

build 323

## SET_CURR_WEATHER_STATE

```c
void SET_CURR_WEATHER_STATE(Hash weatherType1, Hash weatherType2, float percentWeather2)  // 0x578C752848ECFA0C
```

build 323 · old names: `_SET_WEATHER_TYPE_TRANSITION`

> Mixes two weather types. If percentWeather2 is set to 0.0f, then the weather will be entirely of weatherType1, if it is set to 1.0f it will be entirely of weatherType2. If it's set somewhere in between, there will be a mixture of weather behaviors. To test, try this in the RPH console, and change the float to different values between 0 and 1:
> 
> execute "NativeFunction.Natives.x578C752848ECFA0C(Game.GetHashKey(""RAIN""), Game.GetHashKey(""SMOG""), 0.50f);
> 
> Note that unlike most of the other weather natives, this native takes the hash of the weather name, not the plain string. These are the weather names and their hashes:
> 
> CLEAR  0x36A83D84
> EXTRASUNNY  0x97AA0A79
> CLOUDS  0x30FDAF5C
> OVERCAST    0xBB898D2D
> RAIN    0x54A69840
> CLEARING    0x6DB1A50D
> THUNDER 0xB677829F
> SMOG    0x10DCF4B5
> FOGGY   0xAE737644
> XMAS    0xAAC9C895
> SNOWLIGHT   0x23FB812B
> BLIZZARD    0x27EA2814
> 
> 
> 
> 
> 
> /* OLD INVALID INFO BELOW */
> Not tested. Based purely on disassembly. Instantly sets the weather to sourceWeather, then transitions to targetWeather over the specified transitionTime in seconds.
> 
> If an invalid hash is specified for sourceWeather, the current weather type will be used.
> If an invalid hash is specified for targetWeather, the next weather type will be used.
> If an invalid hash is specified for both sourceWeather and targetWeather, the function just changes the transition time of the current transition.

## SET_DISPATCH_IDEAL_SPAWN_DISTANCE

```c
void SET_DISPATCH_IDEAL_SPAWN_DISTANCE(float distance)  // 0x6FE601A64180D423
```

build 323

## SET_DISPATCH_SPAWN_LOCATION

```c
void SET_DISPATCH_SPAWN_LOCATION(float x, float y, float z)  // 0xD10F442036302D50
```

build 323

## SET_DISPATCH_TIME_BETWEEN_SPAWN_ATTEMPTS

```c
void SET_DISPATCH_TIME_BETWEEN_SPAWN_ATTEMPTS(Any p0, float p1)  // 0x44F7CBC1BEB3327D
```

build 323

## SET_DISPATCH_TIME_BETWEEN_SPAWN_ATTEMPTS_MULTIPLIER

```c
void SET_DISPATCH_TIME_BETWEEN_SPAWN_ATTEMPTS_MULTIPLIER(Any p0, float p1)  // 0x48838ED9937A15D1
```

build 323

## SET_EXPLOSIVE_AMMO_THIS_FRAME

```c
void SET_EXPLOSIVE_AMMO_THIS_FRAME(Player player)  // 0xA66C71C98D5F2CFB
```

build 323

## SET_EXPLOSIVE_MELEE_THIS_FRAME

```c
void SET_EXPLOSIVE_MELEE_THIS_FRAME(Player player)  // 0xFF1BED81BFDC0FE0
```

build 323

## SET_FADE_IN_AFTER_DEATH_ARREST

```c
void SET_FADE_IN_AFTER_DEATH_ARREST(BOOL toggle)  // 0xDA66D2796BA33F12
```

build 323

> Sets whether the game should fade in after the player dies or is arrested.

## SET_FADE_IN_AFTER_LOAD

```c
void SET_FADE_IN_AFTER_LOAD(BOOL toggle)  // 0xF3D78F59DFE18D79
```

build 323

## SET_FADE_OUT_AFTER_ARREST

```c
void SET_FADE_OUT_AFTER_ARREST(BOOL toggle)  // 0x1E0B4DC0D990A4E7
```

build 323

> Sets whether the game should fade out after the player is arrested.

## SET_FADE_OUT_AFTER_DEATH

```c
void SET_FADE_OUT_AFTER_DEATH(BOOL toggle)  // 0x4A18E01DF2C87B86
```

build 323

> Sets whether the game should fade out after the player dies.

## SET_FAKE_WANTED_LEVEL

```c
void SET_FAKE_WANTED_LEVEL(int fakeWantedLevel)  // 0x1454F2448DE30163
```

build 323

> Sets a visually fake wanted level on the user interface. Used by Rockstar's scripts to "override" regular wanted levels and make custom ones while the real wanted level and multipliers are still in effect.
> 
> Max is 6, anything above this makes it just 6. Also the mini-map gets the red & blue flashing effect.

## SET_FIRE_AMMO_THIS_FRAME

```c
void SET_FIRE_AMMO_THIS_FRAME(Player player)  // 0x11879CDD803D30F4
```

build 323

## SET_FORCED_JUMP_THIS_FRAME

```c
void SET_FORCED_JUMP_THIS_FRAME(Player player)  // 0xA1183BCFEE0F93D1
```

build 1180 · old names: `_SET_FORCE_PLAYER_TO_JUMP`

## SET_GAME_PAUSED

```c
void SET_GAME_PAUSED(BOOL toggle)  // 0x577D1284D6873711
```

build 323

> Make sure to call this from the correct thread if you're using multiple threads because all other threads except the one which is calling SET_GAME_PAUSED will be paused which means you will lose control and the game remains in paused mode until you exit GTA5.exe

## SET_GRAVITY_LEVEL

```c
void SET_GRAVITY_LEVEL(int level)  // 0x740E14FAD5842351
```

build 323

> level can be from 0 to 3
> 0: 9.8 - normal
> 1: 2.4 - low
> 2: 0.1 - very low
> 3: 0.0 - off

## SET_IDEAL_SPAWN_DISTANCE_FOR_INCIDENT

```c
void SET_IDEAL_SPAWN_DISTANCE_FOR_INCIDENT(int incidentId, float p1)  // 0xD261BA3E7E998072
```

build 323 · old names: `_SET_INCIDENT_UNK`

## SET_INCIDENT_REQUESTED_UNITS

```c
void SET_INCIDENT_REQUESTED_UNITS(int incidentId, int dispatchService, int numUnits)  // 0xB08B85D860E7BA3C
```

build 323

## SET_INSTANCE_PRIORITY_HINT

```c
void SET_INSTANCE_PRIORITY_HINT(int flag)  // 0xC5F0A8EBD3F361CE
```

build 323 · old names: `_SET_UNK_MAP_FLAG`

> Sets an unknown flag used by CScene in determining which entities from CMapData scene nodes to draw, similar to SET_INSTANCE_PRIORITY_MODE.

## SET_INSTANCE_PRIORITY_MODE

```c
void SET_INSTANCE_PRIORITY_MODE(int mode)  // 0x9BAE5AD2508DF078
```

build 323 · old names: `_ENABLE_MP_DLC_MAPS`, `_USE_FREEMODE_MAP_BEHAVIOR`, `_LOWER_MAP_PROP_DENSITY`

> Sets the maximum prop density and changes a loading screen flag from 'loading story mode' to 'loading GTA Online'. It causes a loading screen to show as it reloads map data.

## SET_MINIGAME_IN_PROGRESS

```c
void SET_MINIGAME_IN_PROGRESS(BOOL toggle)  // 0x19E00D7322C6F85B
```

build 323

## SET_MISSION_FLAG

```c
void SET_MISSION_FLAG(BOOL toggle)  // 0xC4301E5121A0ED73
```

build 323

> If true, the player can't save the game. 
> 
> 
> If the parameter is true, sets the mission flag to true, if the parameter is false, the function does nothing at all.
> 
> ^ also, if the mission flag is already set, the function does nothing at all

## SET_OVERRIDE_WEATHER

```c
void SET_OVERRIDE_WEATHER(const char* weatherType)  // 0xA43D5C6FE51ADBEF
```

build 323

> Appears to have an optional bool parameter that is unused in the scripts.
> 
> If you pass true, something will be set to zero.

## SET_OVERRIDE_WEATHEREX

```c
void SET_OVERRIDE_WEATHEREX(const char* weatherType, BOOL p1)  // 0x1178E104409FE58C
```

build 2189

> Identical to SET_OVERRIDE_WEATHER but has an additional BOOL param that sets some weather var to 0 if true

## SET_PLAYER_IS_IN_ANIMAL_FORM

```c
void SET_PLAYER_IS_IN_ANIMAL_FORM(BOOL toggle)  // 0x4EBB7E87AA0DBED4
```

build 323 · old names: `_SHOW_PED_IN_PAUSE_MENU`, `_SET_PLAYER_IS_IN_ANIMAL_FORM`

> If toggle is true, the ped's head is shown in the pause menu
> If toggle is false, the ped's head is not shown in the pause menu

## SET_PLAYER_IS_REPEATING_A_MISSION

```c
void SET_PLAYER_IS_REPEATING_A_MISSION(BOOL toggle)  // 0x9D8D44ADBBA61EF2
```

build 323 · old names: `_SET_PLAYER_ROCKSTAR_EDITOR_DISABLED`

## SET_RAIN

```c
void SET_RAIN(float intensity)  // 0x643E26EA6E024D92
```

build 323 · old names: `_SET_RAIN_FX_INTENSITY`, `_SET_RAIN_LEVEL`

> With an `intensity` higher than `0.5f`, only the creation of puddles gets faster, rain and rain sound won't increase after that.
> With an `intensity` of `0.0f` rain and rain sounds are disabled and there won't be any new puddles.
> To use the rain intensity of the current weather, call this native with `-1f` as `intensity`.

## SET_RANDOM_EVENT_FLAG

```c
void SET_RANDOM_EVENT_FLAG(BOOL toggle)  // 0x971927086CFD2158
```

build 323

> If the parameter is true, sets the random event flag to true, if the parameter is false, the function does nothing at all.
> Does nothing if the mission flag is set.

## SET_RANDOM_SEED

```c
void SET_RANDOM_SEED(int seed)  // 0x444D98F98C11F3EC
```

build 323

## SET_RANDOM_WEATHER_TYPE

```c
void SET_RANDOM_WEATHER_TYPE()  // 0x8B05F884CF7E8020
```

build 323

## SET_RESTART_COORD_OVERRIDE

```c
void SET_RESTART_COORD_OVERRIDE(float x, float y, float z, float heading)  // 0x706B5EDCAA7FA663
```

build 323 · old names: `_SET_CUSTOM_RESPAWN_POSITION`, `_SET_RESTART_CUSTOM_POSITION`

## SET_RIOT_MODE_ENABLED

```c
void SET_RIOT_MODE_ENABLED(BOOL toggle)  // 0x2587A48BC88DFADF
```

build 323

> Activates (usused?) riot mode. All NPCs are being hostile to each other (including player). Also the game will give weapons (pistols, smgs) to random NPCs.

## SET_SAVE_HOUSE

```c
void SET_SAVE_HOUSE(int savehouseHandle, BOOL p1, BOOL p2)  // 0x4F548CABEAE553BC
```

build 323

## SET_SAVE_MENU_ACTIVE

```c
void SET_SAVE_MENU_ACTIVE(BOOL ignoreVehicle)  // 0xC9BF75D28165FF77
```

build 323

> ignoreVehicle - bypasses vehicle check of the local player (it will not open if you are in a vehicle and this is set to false)

## SET_SCRIPT_HIGH_PRIO

```c
void SET_SCRIPT_HIGH_PRIO(BOOL toggle)  // 0x65D2EBB47E1CEC21
```

build 323

> Sets GtaThread+0x14A

## SET_SNOW

```c
void SET_SNOW(float level)  // 0x7F06937B0CDCBC1A
```

build 1868 · old names: `_SET_SNOW_LEVEL`

## SET_STUNT_JUMPS_CAN_TRIGGER

```c
void SET_STUNT_JUMPS_CAN_TRIGGER(BOOL toggle)  // 0xD79185689F8FD5DF
```

build 323

## SET_SUPER_JUMP_THIS_FRAME

```c
void SET_SUPER_JUMP_THIS_FRAME(Player player)  // 0x57FFF03E423A4C0B
```

build 323

## SET_TENNIS_MOVE_NETWORK_SIGNAL_FLOAT

```c
void SET_TENNIS_MOVE_NETWORK_SIGNAL_FLOAT(Ped ped, const char* p1, float p2)  // 0x54F157E0336A3822
```

build 323

> From the scripts:
> 
> MISC::SET_TENNIS_MOVE_NETWORK_SIGNAL_FLOAT(sub_aa49(a_0), "ForcedStopDirection", v_E);
> 
> Related to tennis mode.

## SET_THIS_IS_A_TRIGGER_SCRIPT

```c
void SET_THIS_IS_A_TRIGGER_SCRIPT(BOOL toggle)  // 0x6F2135B6129620C1
```

build 323

> Sets bit 3 in GtaThread+0x150

## SET_THIS_SCRIPT_CAN_BE_PAUSED

```c
void SET_THIS_SCRIPT_CAN_BE_PAUSED(BOOL toggle)  // 0xAA391C728106F7AF
```

build 323

## SET_THIS_SCRIPT_CAN_REMOVE_BLIPS_CREATED_BY_ANY_SCRIPT

```c
void SET_THIS_SCRIPT_CAN_REMOVE_BLIPS_CREATED_BY_ANY_SCRIPT(BOOL toggle)  // 0xB98236CAAECEF897
```

build 323

## SET_TICKER_JOHNMARSTON_IS_DONE

```c
void SET_TICKER_JOHNMARSTON_IS_DONE()  // 0xFB00CA71DA386228
```

build 323

## SET_TIME_SCALE

```c
void SET_TIME_SCALE(float timeScale)  // 0x1D408577D440E81E
```

build 323

> Maximum value is 1.
> At a value of 0 the game will still run at a minimum time scale.
> 
> Slow Motion 1: 0.6
> Slow Motion 2: 0.4
> Slow Motion 3: 0.2

## SET_WANTED_RESPONSE_NUM_PEDS_TO_SPAWN

```c
void SET_WANTED_RESPONSE_NUM_PEDS_TO_SPAWN(int p0, int p1)  // 0xE532EC1A63231B4F
```

build 323

## SET_WEATHER_TYPE_NOW

```c
void SET_WEATHER_TYPE_NOW(const char* weatherType)  // 0x29B487C359E19889
```

build 323

> The following weatherTypes are used in the scripts:
> "CLEAR"
> "EXTRASUNNY"
> "CLOUDS"
> "OVERCAST"
> "RAIN"
> "CLEARING"
> "THUNDER"
> "SMOG"
> "FOGGY"
> "XMAS"
> "SNOW"
> "SNOWLIGHT"
> "BLIZZARD"
> "HALLOWEEN"
> "NEUTRAL"

## SET_WEATHER_TYPE_NOW_PERSIST

```c
void SET_WEATHER_TYPE_NOW_PERSIST(const char* weatherType)  // 0xED712CA327900C8A
```

build 323

> The following weatherTypes are used in the scripts:
> "CLEAR"
> "EXTRASUNNY"
> "CLOUDS"
> "OVERCAST"
> "RAIN"
> "CLEARING"
> "THUNDER"
> "SMOG"
> "FOGGY"
> "XMAS"
> "SNOW"
> "SNOWLIGHT"
> "BLIZZARD"
> "HALLOWEEN"
> "NEUTRAL"

## SET_WEATHER_TYPE_OVERTIME_PERSIST

```c
void SET_WEATHER_TYPE_OVERTIME_PERSIST(const char* weatherType, float time)  // 0xFB5045B7C42B75BF
```

build 323 · old names: `_SET_WEATHER_TYPE_OVER_TIME`

## SET_WEATHER_TYPE_PERSIST

```c
void SET_WEATHER_TYPE_PERSIST(const char* weatherType)  // 0x704983DF373B198F
```

build 323

> The following weatherTypes are used in the scripts:
> "CLEAR"
> "EXTRASUNNY"
> "CLOUDS"
> "OVERCAST"
> "RAIN"
> "CLEARING"
> "THUNDER"
> "SMOG"
> "FOGGY"
> "XMAS"
> "SNOW"
> "SNOWLIGHT"
> "BLIZZARD"
> "HALLOWEEN"
> "NEUTRAL"

## SET_WIND

```c
void SET_WIND(float speed)  // 0xAC3A74E8384A9919
```

build 323

> Sets the the normalized wind speed value. The wind speed clamps always at 12.0, SET_WIND sets the wind in a percentage, 0.0 is 0 and 1.0 is 12.0. Setting this value to a negative number resumes the random wind speed changes provided by the game.

## SET_WIND_DIRECTION

```c
void SET_WIND_DIRECTION(float direction)  // 0xEB0F4468467B4528
```

build 323

> The wind direction in radians
> 180 degrees (PI), wind will blow from the south. Setting this value to a negative number resumes the random wind direction changes provided by the game.

## SET_WIND_SPEED

```c
void SET_WIND_SPEED(float speed)  // 0xEE09ECEDBABE47FC
```

build 323

> Using this native will set the absolute wind speed value. The wind speed clamps to a range of 0.0- 12.0. Setting this value to a negative number resumes the random wind speed changes provided by the game.

## SHOOT_SINGLE_BULLET_BETWEEN_COORDS

```c
void SHOOT_SINGLE_BULLET_BETWEEN_COORDS(float x1, float y1, float z1, float x2, float y2, float z2, int damage, BOOL p7, Hash weaponHash, Ped ownerPed, BOOL isAudible, BOOL isInvisible, float speed)  // 0x867654CBC7606F2C
```

build 323

## SHOOT_SINGLE_BULLET_BETWEEN_COORDS_IGNORE_ENTITY

```c
void SHOOT_SINGLE_BULLET_BETWEEN_COORDS_IGNORE_ENTITY(float x1, float y1, float z1, float x2, float y2, float z2, int damage, BOOL p7, Hash weaponHash, Ped ownerPed, BOOL isAudible, BOOL isInvisible, float speed, Entity entity, Any p14)  // 0xE3A7742E0B7A2F8B
```

build 323 · old names: `_SHOOT_SINGLE_BULLET_BETWEEN_COORDS_PRESET_PARAMS`

> entity - entity to ignore

## SHOOT_SINGLE_BULLET_BETWEEN_COORDS_IGNORE_ENTITY_NEW

```c
void SHOOT_SINGLE_BULLET_BETWEEN_COORDS_IGNORE_ENTITY_NEW(float x1, float y1, float z1, float x2, float y2, float z2, int damage, BOOL p7, Hash weaponHash, Ped ownerPed, BOOL isAudible, BOOL isInvisible, float speed, Entity entity, BOOL p14, BOOL p15, Entity targetEntity, BOOL p17, Any p18, Any p19, Any p20)  // 0xBFE5756E7407064A
```

build 323 · old names: `_SHOOT_SINGLE_BULLET_BETWEEN_COORDS_WITH_EXTRA_PARAMS`

> entity - entity to ignore
> targetEntity - entity to home in on, if the weapon hash provided supports homing

## SHOULD_USE_METRIC_MEASUREMENTS

```c
BOOL SHOULD_USE_METRIC_MEASUREMENTS()  // 0xD3D15555431AB793
```

build 323 · old names: `_IS_GAME_USING_METRIC_MEASUREMENT_SYSTEM`

> Returns true if the game is using the metric measurement system (profile setting 227), false if imperial is used.

## SLERP_NEAR_QUATERNION

```c
void SLERP_NEAR_QUATERNION(float t, float x, float y, float z, float w, float x1, float y1, float z1, float w1, float* outX, float* outY, float* outZ, float* outW)  // 0xF2F6A2FA49278625
```

build 323

> This native always come right before SET_ENTITY_QUATERNION where its final 4 parameters are SLERP_NEAR_QUATERNION p9 to p12

## START_END_USER_BENCHMARK

```c
void START_END_USER_BENCHMARK()  // 0x92790862E36C2ADA
```

build 323 · old names: `_START_BENCHMARK_RECORDING`

## START_SAVE_ARRAY_WITH_SIZE

```c
void START_SAVE_ARRAY_WITH_SIZE(Any* p0, int size, const char* arrayName)  // 0x60FE567DF1B1AF9D
```

build 323 · old names: `_START_SAVE_ARRAY`

## START_SAVE_DATA

```c
void START_SAVE_DATA(Any* p0, Any p1, BOOL p2)  // 0xA9575F812C6A7997
```

build 323

## START_SAVE_STRUCT_WITH_SIZE

```c
void START_SAVE_STRUCT_WITH_SIZE(Any* p0, int size, const char* structName)  // 0xBF737600CDDBEADD
```

build 323 · old names: `_START_SAVE_STRUCT`

## STOP_END_USER_BENCHMARK

```c
void STOP_END_USER_BENCHMARK()  // 0xC7DB36C24634F52B
```

build 323 · old names: `_STOP_BENCHMARK_RECORDING`

## STOP_SAVE_ARRAY

```c
void STOP_SAVE_ARRAY()  // 0x04456F95153C6BE4
```

build 323

## STOP_SAVE_DATA

```c
void STOP_SAVE_DATA()  // 0x74E20C9145FB66FD
```

build 323

## STOP_SAVE_STRUCT

```c
void STOP_SAVE_STRUCT()  // 0xEB1774DF12BB9F12
```

build 323

## STRING_TO_INT

```c
BOOL STRING_TO_INT(const char* string, int* outInteger)  // 0x5A5F40FE637EB584
```

build 323

> Returns false if it's a null or empty string or if the string is too long. outInteger will be set to -999 in that case.
> 
> If all checks have passed successfully, the return value will be set to whatever strtol(string, 0i64, 10); returns.

## SUPRESS_RANDOM_EVENT_THIS_FRAME

```c
void SUPRESS_RANDOM_EVENT_THIS_FRAME(int eventType, BOOL suppress)  // 0x1EAE0A6E978894A2
```

build 323

## TAN

```c
float TAN(float p0)  // 0x632106CC96E82E91
```

build 323

## TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME

```c
void TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME(const char* scriptName)  // 0x9DC711BC69C548DF
```

build 323

## TOGGLE_SHOW_OPTIONAL_STUNT_JUMP_CAMERA

```c
void TOGGLE_SHOW_OPTIONAL_STUNT_JUMP_CAMERA(BOOL toggle)  // 0xFB80AB299D2EE1BD
```

build 757

> Toggles some stunt jump stuff.

## UI_STARTED_END_USER_BENCHMARK

```c
BOOL UI_STARTED_END_USER_BENCHMARK()  // 0xEA2F2061875EED90
```

build 323 · old names: `_UI_IS_SINGLEPLAYER_PAUSE_MENU_ACTIVE`

> Returns true if the current frontend menu is FE_MENU_VERSION_SP_PAUSE

## UNLOAD_ALL_CLOUD_HATS

```c
void UNLOAD_ALL_CLOUD_HATS()  // 0x957E790EA1727B64
```

build 323 · old names: `_CLEAR_CLOUD_HAT`

## UNLOAD_CLOUD_HAT

```c
void UNLOAD_CLOUD_HAT(const char* name, float p1)  // 0xA74802FB8D0B7814
```

build 323

## UPDATE_ONSCREEN_KEYBOARD

```c
int UPDATE_ONSCREEN_KEYBOARD()  // 0x0CF2B696BBF945AE
```

build 323

> Returns the current status of the onscreen keyboard, and updates the output.
> 
> Status Codes:
> 
> -1: Keyboard isn't active
> 0: User still editing
> 1: User has finished editing
> 2: User has canceled editing

## USE_ACTIVE_CAMERA_FOR_TIMESLICING_CENTRE

```c
void USE_ACTIVE_CAMERA_FOR_TIMESLICING_CENTRE()  // 0x693478ACBD7F18E7
```

build 1103

## USING_MISSION_CREATOR

```c
void USING_MISSION_CREATOR(BOOL toggle)  // 0xF14878FC50BEC6EE
```

build 323

## WATER_OVERRIDE_FADE_IN

```c
void WATER_OVERRIDE_FADE_IN(float p0)  // 0xA8434F1DFF41D6E7
```

build 323

## WATER_OVERRIDE_FADE_OUT

```c
void WATER_OVERRIDE_FADE_OUT(float p0)  // 0xC3C221ADDDE31A11
```

build 323

## WATER_OVERRIDE_SET_OCEANNOISEMINAMPLITUDE

```c
void WATER_OVERRIDE_SET_OCEANNOISEMINAMPLITUDE(float minAmplitude)  // 0x31727907B2C43C55
```

build 323

## WATER_OVERRIDE_SET_OCEANWAVEAMPLITUDE

```c
void WATER_OVERRIDE_SET_OCEANWAVEAMPLITUDE(float amplitude)  // 0x405591EC8FD9096D
```

build 323

## WATER_OVERRIDE_SET_OCEANWAVEMAXAMPLITUDE

```c
void WATER_OVERRIDE_SET_OCEANWAVEMAXAMPLITUDE(float maxAmplitude)  // 0xB3E6360DDE733E82
```

build 323

## WATER_OVERRIDE_SET_OCEANWAVEMINAMPLITUDE

```c
void WATER_OVERRIDE_SET_OCEANWAVEMINAMPLITUDE(float minAmplitude)  // 0xF751B16FB32ABC1D
```

build 323

## WATER_OVERRIDE_SET_RIPPLEBUMPINESS

```c
void WATER_OVERRIDE_SET_RIPPLEBUMPINESS(float bumpiness)  // 0x7C9C0B1EEB1F9072
```

build 323

## WATER_OVERRIDE_SET_RIPPLEDISTURB

```c
void WATER_OVERRIDE_SET_RIPPLEDISTURB(float disturb)  // 0xB9854DFDE0D833D6
```

build 323

## WATER_OVERRIDE_SET_RIPPLEMAXBUMPINESS

```c
void WATER_OVERRIDE_SET_RIPPLEMAXBUMPINESS(float maxBumpiness)  // 0x9F5E6BB6B34540DA
```

build 323

## WATER_OVERRIDE_SET_RIPPLEMINBUMPINESS

```c
void WATER_OVERRIDE_SET_RIPPLEMINBUMPINESS(float minBumpiness)  // 0x6216B116083A7CB4
```

build 323

## WATER_OVERRIDE_SET_SHOREWAVEAMPLITUDE

```c
void WATER_OVERRIDE_SET_SHOREWAVEAMPLITUDE(float amplitude)  // 0xB8F87EAD7533B176
```

build 323

## WATER_OVERRIDE_SET_SHOREWAVEMAXAMPLITUDE

```c
void WATER_OVERRIDE_SET_SHOREWAVEMAXAMPLITUDE(float maxAmplitude)  // 0xA7A1127490312C36
```

build 323

## WATER_OVERRIDE_SET_SHOREWAVEMINAMPLITUDE

```c
void WATER_OVERRIDE_SET_SHOREWAVEMINAMPLITUDE(float minAmplitude)  // 0xC3EAD29AB273ECE8
```

build 323

## WATER_OVERRIDE_SET_STRENGTH

```c
void WATER_OVERRIDE_SET_STRENGTH(float strength)  // 0xC54A08C85AE4D410
```

build 323

> This seems to edit the water wave, intensity around your current location.
> 
> 0.0f = Normal
> 1.0f = So Calm and Smooth, a boat will stay still.
> 3.0f = Really Intense.

