# HUD natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _GET_NOMINATED_JOB_REPORT_STATUS

```c
int _GET_NOMINATED_JOB_REPORT_STATUS(int index)  // 0xA3C8062CAB30E8A9
```

build 3889

## _REPORT_NOMINATED_JOB

```c
int _REPORT_NOMINATED_JOB(const char* jobNominated, Any* p1)  // 0x764EED2568508F13
```

build 3889

> p1 is unused

## _SET_BLIP_GPS_ROUTE_DISPLAY_DISTANCE

```c
void _SET_BLIP_GPS_ROUTE_DISPLAY_DISTANCE(Blip blip, int blipChangeParam46, BOOL blipChangeParam47)  // 0x25D984CFB64ED6DE
```

build 3095

> Applies to new eBlipParams _BLIP_CHANGE_46* and _BLIP_CHANGE_47*

## _SET_PAUSE_EXTERIOR_RENDERING_WHILE_IN_INTERIOR

```c
void _SET_PAUSE_EXTERIOR_RENDERING_WHILE_IN_INTERIOR()  // 0x35CCE12EAECB4A51
```

build 2944

## _SHOW_PURCHASE_INSTRUCTIONAL_BUTTON

```c
void _SHOW_PURCHASE_INSTRUCTIONAL_BUTTON(BOOL toggle)  // 0xF6865E26067B708C
```

build 3407

## _USE_VEHICLE_TARGETING_RETICULE_ON_VEHICLES

```c
void _USE_VEHICLE_TARGETING_RETICULE_ON_VEHICLES(BOOL enable)  // 0x1BC0EA2912708625
```

build 3095

## ACTIVATE_FRONTEND_MENU

```c
void ACTIVATE_FRONTEND_MENU(Hash menuhash, BOOL togglePause, int component)  // 0xEF01D36B9C9D0C7B
```

build 323

> Does stuff like this:
> https://i.gyazo.com/7fcb78ea3520e3dbc5b2c0c0f3712617.png
> 
> Example:
> int GetHash = GET_HASH_KEY("fe_menu_version_corona_lobby");
> ACTIVATE_FRONTEND_MENU(GetHash, 0, -1);
> 
> BOOL p1 is a toggle to define the game in pause.
> int p2 is unknown but -1 always works, not sure why though.
> 
> [30/03/2017] ins1de :
> 
> the int p2 is actually a component variable. When the pause menu is visible, it opens the tab related to it.
> 
> Example : Function.Call(Hash.ACTIVATE_FRONTEND_MENU,-1171018317, 0, 42);
> Result : Opens the "Online" tab without pausing the menu, with -1 it opens the map.Below is a list of all known Frontend Menu Hashes.
> - FE_MENU_VERSION_SP_PAUSE
> - FE_MENU_VERSION_MP_PAUSE
> - FE_MENU_VERSION_CREATOR_PAUSE
> - FE_MENU_VERSION_CUTSCENE_PAUSE
> - FE_MENU_VERSION_SAVEGAME
> - FE_MENU_VERSION_PRE_LOBBY
> - FE_MENU_VERSION_LOBBY
> - FE_MENU_VERSION_MP_CHARACTER_SELECT
> - FE_MENU_VERSION_MP_CHARACTER_CREATION
> - FE_MENU_VERSION_EMPTY
> - FE_MENU_VERSION_EMPTY_NO_BACKGROUND
> - FE_MENU_VERSION_TEXT_SELECTION
> - FE_MENU_VERSION_CORONA
> - FE_MENU_VERSION_CORONA_LOBBY
> - FE_MENU_VERSION_CORONA_JOINED_PLAYERS
> - FE_MENU_VERSION_CORONA_INVITE_PLAYERS
> - FE_MENU_VERSION_CORONA_INVITE_FRIENDS
> - FE_MENU_VERSION_CORONA_INVITE_CREWS
> - FE_MENU_VERSION_CORONA_INVITE_MATCHED_PLAYERS
> - FE_MENU_VERSION_CORONA_INVITE_LAST_JOB_PLAYERS
> - FE_MENU_VERSION_CORONA_RACE
> - FE_MENU_VERSION_CORONA_BETTING
> - FE_MENU_VERSION_JOINING_SCREEN
> - FE_MENU_VERSION_LANDING_MENU
> - FE_MENU_VERSION_LANDING_KEYMAPPING_MENU

## ADD_BLIP_FOR_AREA

```c
Blip ADD_BLIP_FOR_AREA(float x, float y, float z, float width, float height)  // 0xCE5D0E5E315DB238
```

build 463 · old names: `_ADD_BLIP_FOR_AREA`

> Adds a rectangular blip for the specified coordinates/area.
> 
> It is recommended to use SET_BLIP_ROTATION and SET_BLIP_COLOUR to make the blip not rotate along with the camera.
> 
> By default, the blip will show as a _regular_ blip with the specified color/sprite if it is outside of the minimap view.

## ADD_BLIP_FOR_COORD

```c
Blip ADD_BLIP_FOR_COORD(float x, float y, float z)  // 0x5A039BB0BCA604B6
```

build 323

> Creates an orange ( default ) Blip-object. Returns a Blip-object which can then be modified.

## ADD_BLIP_FOR_ENTITY

```c
Blip ADD_BLIP_FOR_ENTITY(Entity entity)  // 0x5CDE92C702A8FCE7
```

build 323

> Returns red ( default ) blip attached to entity.
> 
> Example:
> Blip blip; //Put this outside your case or option
> blip = HUD::ADD_BLIP_FOR_ENTITY(YourPedOrBodyguardName);
> HUD::SET_BLIP_AS_FRIENDLY(blip, true);

## ADD_BLIP_FOR_PICKUP

```c
Blip ADD_BLIP_FOR_PICKUP(Pickup pickup)  // 0xBE339365C863BD36
```

build 323

## ADD_BLIP_FOR_RADIUS

```c
Blip ADD_BLIP_FOR_RADIUS(float posX, float posY, float posZ, float radius)  // 0x46818D79B1F7499A
```

build 323

## ADD_NEXT_MESSAGE_TO_PREVIOUS_BRIEFS

```c
void ADD_NEXT_MESSAGE_TO_PREVIOUS_BRIEFS(BOOL p0)  // 0x60296AF4BA14ABC5
```

build 323

## ADD_POINT_TO_GPS_CUSTOM_ROUTE

```c
void ADD_POINT_TO_GPS_CUSTOM_ROUTE(float x, float y, float z)  // 0x311438A071DD9B1A
```

build 323

## ADD_POINT_TO_GPS_MULTI_ROUTE

```c
void ADD_POINT_TO_GPS_MULTI_ROUTE(float x, float y, float z)  // 0xA905192A6781C41B
```

build 323

## ADD_TEXT_COMPONENT_FLOAT

```c
void ADD_TEXT_COMPONENT_FLOAT(float value, int decimalPlaces)  // 0xE7DCB5B874BCD96E
```

build 323

## ADD_TEXT_COMPONENT_FORMATTED_INTEGER

```c
void ADD_TEXT_COMPONENT_FORMATTED_INTEGER(int value, BOOL commaSeparated)  // 0x0E4C749FF9DE9CC4
```

build 323

## ADD_TEXT_COMPONENT_INTEGER

```c
void ADD_TEXT_COMPONENT_INTEGER(int value)  // 0x03B504CF259931BC
```

build 323

## ADD_TEXT_COMPONENT_SUBSTRING_BLIP_NAME

```c
void ADD_TEXT_COMPONENT_SUBSTRING_BLIP_NAME(Blip blip)  // 0x80EAD8E2E1D5D52E
```

build 323

## ADD_TEXT_COMPONENT_SUBSTRING_KEYBOARD_DISPLAY

```c
void ADD_TEXT_COMPONENT_SUBSTRING_KEYBOARD_DISPLAY(const char* string)  // 0x5F68520888E69014
```

build 323 · old names: `_ADD_TEXT_COMPONENT_STRING3`, `_ADD_TEXT_COMPONENT_SCALEFORM`

## ADD_TEXT_COMPONENT_SUBSTRING_PHONE_NUMBER

```c
void ADD_TEXT_COMPONENT_SUBSTRING_PHONE_NUMBER(const char* p0, int p1)  // 0x761B77454205A61D
```

build 323 · old names: `_ADD_TEXT_COMPONENT_APP_TITLE`

> p1 was always -1

## ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME

```c
void ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(const char* text)  // 0x6C188BE134E074AA
```

build 323 · old names: `_ADD_TEXT_COMPONENT_STRING`

## ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL

```c
void ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL(const char* labelName)  // 0xC63CD5D2920ACBE7
```

build 323 · old names: `_ADD_TEXT_COMPONENT_ITEM_STRING`

## ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL_HASH_KEY

```c
void ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL_HASH_KEY(Hash gxtEntryHash)  // 0x17299B63C7683A2B
```

build 323

> It adds the localized text of the specified GXT entry name. Eg. if the argument is GET_HASH_KEY("ES_HELP"), adds "Continue". Just uses a text labels hash key

## ADD_TEXT_COMPONENT_SUBSTRING_TIME

```c
void ADD_TEXT_COMPONENT_SUBSTRING_TIME(int timestamp, int flags)  // 0x1115F16B8AB9E8BF
```

build 323

> Adds a timer (e.g. "00:00:00:000"). The appearance of the timer depends on the flags, which needs more research.

## ADD_TEXT_COMPONENT_SUBSTRING_WEBSITE

```c
void ADD_TEXT_COMPONENT_SUBSTRING_WEBSITE(const char* website)  // 0x94CF4AC034C9C986
```

build 323 · old names: `_ADD_TEXT_COMPONENT_STRING2`

> This native (along with ADD_TEXT_COMPONENT_SUBSTRING_KEYBOARD_DISPLAY and ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME) do not actually filter anything. They simply add the provided text (as of 944)

## ADD_VALID_VEHICLE_HIT_HASH

```c
void ADD_VALID_VEHICLE_HIT_HASH(Any p0)  // 0xE4C3B169876D33D7
```

build 1290

## ALLOW_DISPLAY_OF_MULTIPLAYER_CASH_TEXT

```c
void ALLOW_DISPLAY_OF_MULTIPLAYER_CASH_TEXT(BOOL allow)  // 0xE67C6DFD386EA5E7
```

build 323 · old names: `_ALLOW_ADDITIONAL_INFO_FOR_MULTIPLAYER_HUD_CASH`

> Controls whether to display 'Cash'/'Bank' next to the money balance HUD in Multiplayer (https://i.imgur.com/MiYUtNl.png)

## ALLOW_PAUSE_WHEN_NOT_IN_STATE_OF_PLAY_THIS_FRAME

```c
void ALLOW_PAUSE_WHEN_NOT_IN_STATE_OF_PLAY_THIS_FRAME()  // 0xCC3FDDED67BCFC63
```

build 323 · old names: `_ALLOW_PAUSE_MENU_WHEN_DEAD_THIS_FRAME`

> Allows opening the pause menu this frame, when the player is dead.

## ALLOW_SONAR_BLIPS

```c
void ALLOW_SONAR_BLIPS(BOOL toggle)  // 0x60734CC207C9833C
```

build 323

## ARE_ONLINE_POLICIES_UP_TO_DATE

```c
BOOL ARE_ONLINE_POLICIES_UP_TO_DATE()  // 0xF13FE2A80C05C561
```

build 323

## BEGIN_TEXT_COMMAND_ADD_DIRECTLY_TO_PREVIOUS_BRIEFS

```c
void BEGIN_TEXT_COMMAND_ADD_DIRECTLY_TO_PREVIOUS_BRIEFS(const char* p0)  // 0x23D69E0465570028
```

build 323 · old names: `_BEGIN_TEXT_COMMAND_OBJECTIVE`

## BEGIN_TEXT_COMMAND_BUSYSPINNER_ON

```c
void BEGIN_TEXT_COMMAND_BUSYSPINNER_ON(const char* string)  // 0xABA17D7CE615ADBF
```

build 323 · old names: `_SET_LOADING_PROMPT_TEXT_ENTRY`, `_BEGIN_TEXT_COMMAND_BUSY_STRING`

> Initializes the text entry for the the text next to a loading prompt. All natives for building UI texts can be used here
> 
> 
> e.g
> void StartLoadingMessage(char *text, int spinnerType = 3)
>   {
>      BEGIN_TEXT_COMMAND_BUSYSPINNER_ON("STRING");
>        ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
>        END_TEXT_COMMAND_BUSYSPINNER_ON(spinnerType);
>     }
> /*OR*/
>  void ShowLoadingMessage(char *text, int spinnerType = 3, int timeMs = 10000)
>   {
>      BEGIN_TEXT_COMMAND_BUSYSPINNER_ON("STRING");
>        ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
>        END_TEXT_COMMAND_BUSYSPINNER_ON(spinnerType);
>         WAIT(timeMs);
>      BUSYSPINNER_OFF();
>  }
> 
> 
> These are some localized strings used in the loading spinner.
> "PM_WAIT"                   = Please Wait
> "CELEB_WPLYRS"              = Waiting For Players.
> "CELL_SPINNER2"             = Scanning storage.
> "ERROR_CHECKYACHTNAME" = Registering your yacht's name. Please wait.
> "ERROR_CHECKPROFANITY"   = Checking your text for profanity. Please wait.
> "FM_COR_AUTOD"                        = Just spinner no text
> "FM_IHELP_WAT2"                        = Waiting for other players
> "FM_JIP_WAITO"                            = Game options are being set
> "FMMC_DOWNLOAD"                    = Downloading
> "FMMC_PLYLOAD"                         = Loading
> "FMMC_STARTTRAN"                    = Launching session
> "HUD_QUITTING"                           =  Quiting session
> "KILL_STRIP_IDM"                         = Waiting for to accept
> "MP_SPINLOADING"                      = Loading

## BEGIN_TEXT_COMMAND_CLEAR_PRINT

```c
void BEGIN_TEXT_COMMAND_CLEAR_PRINT(const char* text)  // 0xE124FA80A759019C
```

build 323

> clears a print text command with this text

## BEGIN_TEXT_COMMAND_DISPLAY_HELP

```c
void BEGIN_TEXT_COMMAND_DISPLAY_HELP(const char* inputType)  // 0x8509B634FBE7DA11
```

build 323 · old names: `_SET_TEXT_COMPONENT_FORMAT`

## BEGIN_TEXT_COMMAND_DISPLAY_TEXT

```c
void BEGIN_TEXT_COMMAND_DISPLAY_TEXT(const char* text)  // 0x25FBB336DF1804CB
```

build 323 · old names: `_SET_TEXT_ENTRY`

> The following were found in the decompiled script files:
> STRING, TWOSTRINGS, NUMBER, PERCENTAGE, FO_TWO_NUM, ESMINDOLLA, ESDOLLA, MTPHPER_XPNO, AHD_DIST, CMOD_STAT_0, CMOD_STAT_1, CMOD_STAT_2, CMOD_STAT_3, DFLT_MNU_OPT, F3A_TRAFDEST, ES_HELP_SOC3
> 
> ESDOLLA - cash
> ESMINDOLLA - cash (negative)

## BEGIN_TEXT_COMMAND_GET_NUMBER_OF_LINES_FOR_STRING

```c
void BEGIN_TEXT_COMMAND_GET_NUMBER_OF_LINES_FOR_STRING(const char* entry)  // 0x521FB041D93DD0E4
```

build 323 · old names: `_SET_TEXT_GXT_ENTRY`, `_BEGIN_TEXT_COMMAND_LINE_COUNT`

> int GetLineCount(char *text, float x, float y)
>     {
>      BEGIN_TEXT_COMMAND_GET_NUMBER_OF_LINES_FOR_STRING("STRING");
>                 ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
>       return BEGIN_TEXT_COMMAND_GET_NUMBER_OF_LINES_FOR_STRING(x, y);
>     }

## BEGIN_TEXT_COMMAND_GET_SCREEN_WIDTH_OF_DISPLAY_TEXT

```c
void BEGIN_TEXT_COMMAND_GET_SCREEN_WIDTH_OF_DISPLAY_TEXT(const char* text)  // 0x54CE8AC98E120CAB
```

build 323 · old names: `_SET_TEXT_ENTRY_FOR_WIDTH`, `_BEGIN_TEXT_COMMAND_WIDTH`, `_BEGIN_TEXT_COMMAND_GET_WIDTH`

## BEGIN_TEXT_COMMAND_IS_MESSAGE_DISPLAYED

```c
void BEGIN_TEXT_COMMAND_IS_MESSAGE_DISPLAYED(const char* text)  // 0x853648FD1063A213
```

build 323

> nothin doin. 
> 
> BOOL Message(const char* text)
>    {
>      BEGIN_TEXT_COMMAND_IS_MESSAGE_DISPLAYED("STRING");
>       ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
>        return END_TEXT_COMMAND_IS_MESSAGE_DISPLAYED();
>    }

## BEGIN_TEXT_COMMAND_IS_THIS_HELP_MESSAGE_BEING_DISPLAYED

```c
void BEGIN_TEXT_COMMAND_IS_THIS_HELP_MESSAGE_BEING_DISPLAYED(const char* labelName)  // 0x0A24DA3A41B718F5
```

build 323

> BOOL IsContextActive(char *ctx)
>     {
>      BEGIN_TEXT_COMMAND_IS_THIS_HELP_MESSAGE_BEING_DISPLAYED(ctx);
>      return END_TEXT_COMMAND_IS_THIS_HELP_MESSAGE_BEING_DISPLAYED(0);
>   }

## BEGIN_TEXT_COMMAND_OVERRIDE_BUTTON_TEXT

```c
void BEGIN_TEXT_COMMAND_OVERRIDE_BUTTON_TEXT(const char* gxtEntry)  // 0x8F9EE5687F8EECCD
```

build 323 · old names: `_BEGIN_TEXT_COMMAND_TIMER`

## BEGIN_TEXT_COMMAND_PRINT

```c
void BEGIN_TEXT_COMMAND_PRINT(const char* GxtEntry)  // 0xB87A37EEB7FAA67D
```

build 323 · old names: `_SET_TEXT_ENTRY_2`

> void ShowSubtitle(const char *text)
> {
>   BEGIN_TEXT_COMMAND_PRINT("STRING");
>  ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
>    END_TEXT_COMMAND_PRINT(2000, true);
> }

## BEGIN_TEXT_COMMAND_SET_BLIP_NAME

```c
void BEGIN_TEXT_COMMAND_SET_BLIP_NAME(const char* textLabel)  // 0xF9113A30DE5C6670
```

build 323

> Starts a text command to change the name of a blip displayed in the pause menu.
> This should be paired with `END_TEXT_COMMAND_SET_BLIP_NAME`, once adding all required text components.
> Example:
> 
> HUD::BEGIN_TEXT_COMMAND_SET_BLIP_NAME("STRING");
> HUD::ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME("Name");
> HUD::END_TEXT_COMMAND_SET_BLIP_NAME(blip);

## BEGIN_TEXT_COMMAND_THEFEED_POST

```c
void BEGIN_TEXT_COMMAND_THEFEED_POST(const char* text)  // 0x202709F4C58A0424
```

build 323 · old names: `_SET_NOTIFICATION_TEXT_ENTRY`

> Declares the entry type of a notification, for example "STRING".
> 
> int ShowNotification(char *text)
> {
> 	BEGIN_TEXT_COMMAND_THEFEED_POST("STRING");
> 	ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
> 	return END_TEXT_COMMAND_THEFEED_POST_TICKER(1, 1);
> }

## BUSYSPINNER_IS_DISPLAYING

```c
BOOL BUSYSPINNER_IS_DISPLAYING()  // 0xB2A592B04648A9CB
```

build 323

## BUSYSPINNER_IS_ON

```c
BOOL BUSYSPINNER_IS_ON()  // 0xD422FCC5F239A915
```

build 323 · old names: `_IS_LOADING_PROMPT_BEING_DISPLAYED`

## BUSYSPINNER_OFF

```c
void BUSYSPINNER_OFF()  // 0x10D373323E5B9C0D
```

build 323 · old names: `_REMOVE_LOADING_PROMPT`

> Removes the loading prompt at the bottom right of the screen.

## CHANGE_FAKE_MP_CASH

```c
void CHANGE_FAKE_MP_CASH(int cash, int bank)  // 0x0772DF77852C2E30
```

build 323 · old names: `_SET_SINGLEPLAYER_HUD_CASH`

> Displays cash change notifications on HUD.

## CLEAR_ADDITIONAL_TEXT

```c
void CLEAR_ADDITIONAL_TEXT(int p0, BOOL p1)  // 0x2A179DF17CCF04CD
```

build 323

## CLEAR_ALL_BLIP_ROUTES

```c
void CLEAR_ALL_BLIP_ROUTES()  // 0xD12882D3FF82BF11
```

build 877 · old names: `_CLEAR_ALL_BLIP_ROUTES`

## CLEAR_ALL_HELP_MESSAGES

```c
void CLEAR_ALL_HELP_MESSAGES()  // 0x6178F68A87A4D3A0
```

build 323

## CLEAR_BRIEF

```c
void CLEAR_BRIEF()  // 0x9D292F73ADBD9313
```

build 323

## CLEAR_DYNAMIC_PAUSE_MENU_ERROR_MESSAGE

```c
void CLEAR_DYNAMIC_PAUSE_MENU_ERROR_MESSAGE()  // 0x7792424AA0EAC32E
```

build 323

## CLEAR_FAKE_CONE_ARRAY

```c
void CLEAR_FAKE_CONE_ARRAY()  // 0x8410C5E0CD847B9D
```

build 1290

## CLEAR_FLOATING_HELP

```c
void CLEAR_FLOATING_HELP(int hudIndex, BOOL p1)  // 0x50085246ABD3FEFA
```

build 323

## CLEAR_GPS_CUSTOM_ROUTE

```c
void CLEAR_GPS_CUSTOM_ROUTE()  // 0xE6DE0561D9232A64
```

build 323

## CLEAR_GPS_FLAGS

```c
void CLEAR_GPS_FLAGS()  // 0x21986729D6A3A830
```

build 323

> Clears the GPS flags. Only the script that originally called SET_GPS_FLAGS can clear them.
> 
> Doesn't seem like the flags are actually read by the game at all.

## CLEAR_GPS_MULTI_ROUTE

```c
void CLEAR_GPS_MULTI_ROUTE()  // 0x67EEDEA1B9BAFD94
```

build 323

> Does the same as SET_GPS_MULTI_ROUTE_RENDER(false);

## CLEAR_GPS_PLAYER_WAYPOINT

```c
void CLEAR_GPS_PLAYER_WAYPOINT()  // 0xFF4FB7C8CDFA3DA7
```

build 323

## CLEAR_GPS_RACE_TRACK

```c
void CLEAR_GPS_RACE_TRACK()  // 0x7AA5B4CE533C858B
```

build 323

> Does the same as SET_RACE_TRACK_RENDER(false);

## CLEAR_HELP

```c
void CLEAR_HELP(BOOL toggle)  // 0x8DFCED7A656F8802
```

build 323

## CLEAR_PED_IN_PAUSE_MENU

```c
void CLEAR_PED_IN_PAUSE_MENU()  // 0x5E62BE5DC58E9E06
```

build 323

## CLEAR_PRINTS

```c
void CLEAR_PRINTS()  // 0xCC33FA791322B9D9
```

build 323

## CLEAR_REMINDER_MESSAGE

```c
void CLEAR_REMINDER_MESSAGE()  // 0xB57D8DD645CFA2CF
```

build 323

> This native does absolutely nothing, just a nullsub

## CLEAR_SMALL_PRINTS

```c
void CLEAR_SMALL_PRINTS()  // 0x2CEA2839313C09AC
```

build 323

## CLEAR_THIS_PRINT

```c
void CLEAR_THIS_PRINT(const char* p0)  // 0xCF708001E1E536DD
```

build 323

> p0: found arguments in the b617d scripts: https://pastebin.com/X5akCN7z

## CLEAR_VALID_VEHICLE_HIT_HASHES

```c
void CLEAR_VALID_VEHICLE_HIT_HASHES()  // 0xEB81A3DADD503187
```

build 1290

## CLOSE_MP_TEXT_CHAT

```c
void CLOSE_MP_TEXT_CHAT()  // 0x1AC8F4AD40E22127
```

build 323 · old names: `_ABORT_TEXT_CHAT`, `_CLOSE_MULTIPLAYER_CHAT`

## CLOSE_SOCIAL_CLUB_MENU

```c
void CLOSE_SOCIAL_CLUB_MENU()  // 0xD2B32BE3FC1626C6
```

build 323

## CODE_WANTS_SCRIPT_TO_TAKE_CONTROL

```c
BOOL CODE_WANTS_SCRIPT_TO_TAKE_CONTROL()  // 0x66E7CB63C97B7D20
```

build 323

## CREATE_FAKE_MP_GAMER_TAG

```c
int CREATE_FAKE_MP_GAMER_TAG(Ped ped, const char* username, BOOL pointedClanTag, BOOL isRockstarClan, const char* clanTag, int clanFlag)  // 0xBFEFE3321A3F5015
```

build 323 · old names: `_CREATE_MP_GAMER_TAG`

> clanFlag: takes a number 0-5

## CREATE_MP_GAMER_TAG_WITH_CREW_COLOR

```c
void CREATE_MP_GAMER_TAG_WITH_CREW_COLOR(Player player, const char* username, BOOL pointedClanTag, BOOL isRockstarClan, const char* clanTag, int clanFlag, int r, int g, int b)  // 0x6DD05E9D83EFA4C9
```

build 323 · old names: `_CREATE_MP_GAMER_TAG_COLOR`, `_SET_MP_GAMER_TAG_COLOR`, `_CREATE_MP_GAMER_TAG_FOR_NET_PLAYER`

> clanFlag: takes a number 0-5

## CUSTOM_MINIMAP_CLEAR_BLIPS

```c
void CUSTOM_MINIMAP_CLEAR_BLIPS()  // 0x2708FC083123F9FF
```

build 323 · old names: `_CLEAR_RACE_GALLERY_BLIPS`

## CUSTOM_MINIMAP_CREATE_BLIP

```c
int CUSTOM_MINIMAP_CREATE_BLIP(float x, float y, float z)  // 0x551DF99658DB6EE8
```

build 323 · old names: `_RACE_GALLERY_ADD_BLIP`

> Add a BLIP_GALLERY at the specific coordinate. Used in fm_maintain_transition_players to display race track points.

## CUSTOM_MINIMAP_SET_ACTIVE

```c
void CUSTOM_MINIMAP_SET_ACTIVE(BOOL toggle)  // 0x5354C5BA2EA868A4
```

build 323 · old names: `_SET_MAP_FULL_SCREEN`, `_RACE_GALLERY_FULLSCREEN`

> If toggle is true, the map is shown in full screen
> If toggle is false, the map is shown in normal mode

## CUSTOM_MINIMAP_SET_BLIP_OBJECT

```c
void CUSTOM_MINIMAP_SET_BLIP_OBJECT(int spriteId)  // 0x1EAE6DD17B7A5EFA
```

build 323 · old names: `_RACE_GALLERY_NEXT_BLIP_SPRITE`

> Sets the sprite of the next BLIP_GALLERY blip, values used in the native scripts: 143 (ObjectiveBlue), 144 (ObjectiveGreen), 145 (ObjectiveRed), 146 (ObjectiveYellow).

## DELETE_WAYPOINTS_FROM_THIS_PLAYER

```c
void DELETE_WAYPOINTS_FROM_THIS_PLAYER()  // 0xD8E694757BCEA8E9
```

build 323 · old names: `_DELETE_WAYPOINT`

## DISABLE_FRONTEND_THIS_FRAME

```c
void DISABLE_FRONTEND_THIS_FRAME()  // 0x6D3465A73092F0E6
```

build 323

## DISABLE_PAUSEMENU_SPINNER

```c
void DISABLE_PAUSEMENU_SPINNER(BOOL p0)  // 0x9245E81072704B8A
```

build 323 · old names: `_DISABLE_PAUSE_MENU_BUSYSPINNER`

## DISPLAY_AMMO_THIS_FRAME

```c
void DISPLAY_AMMO_THIS_FRAME(BOOL display)  // 0xA5E78BA2B1331C55
```

build 323

## DISPLAY_AREA_NAME

```c
void DISPLAY_AREA_NAME(BOOL toggle)  // 0x276B6CE369C33678
```

build 323

## DISPLAY_CASH

```c
void DISPLAY_CASH(BOOL toggle)  // 0x96DEC8D5430208B7
```

build 323

> "DISPLAY_CASH(false);" makes the cash amount render on the screen when appropriate
> "DISPLAY_CASH(true);" disables cash amount rendering

## DISPLAY_HELP_TEXT_THIS_FRAME

```c
void DISPLAY_HELP_TEXT_THIS_FRAME(const char* message, BOOL curvedWindow)  // 0x960C9FF8F616E41C
```

build 323

> The messages are localized strings.
> Examples:
> "No_bus_money"
> "Enter_bus"
> "Tour_help"
> "LETTERS_HELP2"
> "Dummy""
> 
> curvedWindow is unused.

## DISPLAY_HUD

```c
void DISPLAY_HUD(BOOL toggle)  // 0xA6294919E56FF02A
```

build 323

> If Hud should be displayed

## DISPLAY_HUD_WHEN_NOT_IN_STATE_OF_PLAY_THIS_FRAME

```c
void DISPLAY_HUD_WHEN_NOT_IN_STATE_OF_PLAY_THIS_FRAME()  // 0x7669F9E39DC17063
```

build 323 · old names: `_DISPLAY_HUD_WHEN_DEAD_THIS_FRAME`

> Enables drawing some hud components, such as help labels, this frame, when the player is dead.

## DISPLAY_HUD_WHEN_PAUSED_THIS_FRAME

```c
void DISPLAY_HUD_WHEN_PAUSED_THIS_FRAME()  // 0x402F9ED62087E898
```

build 323

## DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS

```c
void DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS(BOOL toggle)  // 0x82CEDC33687E1F50
```

build 323

> Toggles whether or not name labels are shown on the expanded minimap next to player blips, like in GTA:O.
> Doesn't need to be called every frame.
> 
> Make sure to call SET_BLIP_CATEGORY with index 7 for this to work on the desired blip.

## DISPLAY_RADAR

```c
void DISPLAY_RADAR(BOOL toggle)  // 0xA0EBB943C300E693
```

build 323

> If Minimap / Radar should be displayed.

## DISPLAY_SNIPER_SCOPE_THIS_FRAME

```c
void DISPLAY_SNIPER_SCOPE_THIS_FRAME()  // 0x73115226F4814E62
```

build 323

> Displays the crosshair for this frame.

## DOES_BLIP_EXIST

```c
BOOL DOES_BLIP_EXIST(Blip blip)  // 0xA6DB27D19ECBB7DA
```

build 323

## DOES_BLIP_HAVE_GPS_ROUTE

```c
BOOL DOES_BLIP_HAVE_GPS_ROUTE(Blip blip)  // 0xDD2238F57B977751
```

build 323

## DOES_PED_HAVE_AI_BLIP

```c
BOOL DOES_PED_HAVE_AI_BLIP(Ped ped)  // 0x15B8ECF844EE67ED
```

build 323

## DOES_TEXT_BLOCK_EXIST

```c
BOOL DOES_TEXT_BLOCK_EXIST(const char* gxt)  // 0x1C7302E725259789
```

build 323

## DOES_TEXT_LABEL_EXIST

```c
BOOL DOES_TEXT_LABEL_EXIST(const char* gxt)  // 0xAC09CA973C564252
```

build 323

> Checks if the passed gxt name exists in the game files.

## DONT_TILT_MINIMAP_THIS_FRAME

```c
void DONT_TILT_MINIMAP_THIS_FRAME()  // 0x6D14BFDC33B34F55
```

build 323 · old names: `_CENTER_PLAYER_ON_RADAR_THIS_FRAME`

> When calling this, the current frame will have the players "arrow icon" be focused on the dead center of the radar.

## DONT_ZOOM_MINIMAP_WHEN_RUNNING_THIS_FRAME

```c
void DONT_ZOOM_MINIMAP_WHEN_RUNNING_THIS_FRAME()  // 0x89DA85D949CE57A0
```

build 2802

## DONT_ZOOM_MINIMAP_WHEN_SNIPING_THIS_FRAME

```c
void DONT_ZOOM_MINIMAP_WHEN_SNIPING_THIS_FRAME()  // 0x55F5A5F07134DE60
```

build 1180

## DRAW_FRONTEND_BACKGROUND_THIS_FRAME

```c
void DRAW_FRONTEND_BACKGROUND_THIS_FRAME()  // 0x211C4EF450086857
```

build 323

> This native does absolutely nothing, just a nullsub

## DRAW_HUD_OVER_FADE_THIS_FRAME

```c
void DRAW_HUD_OVER_FADE_THIS_FRAME()  // 0xBF4F34A85CA2970C
```

build 323

## END_TEXT_COMMAND_ADD_DIRECTLY_TO_PREVIOUS_BRIEFS

```c
void END_TEXT_COMMAND_ADD_DIRECTLY_TO_PREVIOUS_BRIEFS(BOOL p0)  // 0xCFDBDF5AE59BA0F4
```

build 323 · old names: `_END_TEXT_COMMAND_OBJECTIVE`

## END_TEXT_COMMAND_BUSYSPINNER_ON

```c
void END_TEXT_COMMAND_BUSYSPINNER_ON(int busySpinnerType)  // 0xBD12F8228410D9B4
```

build 323 · old names: `_SHOW_LOADING_PROMPT`, `_END_TEXT_COMMAND_BUSY_STRING`

> enum eBusySpinnerType
> {
> 	BUSY_SPINNER_LEFT,
> 	BUSY_SPINNER_LEFT_2,
> 	BUSY_SPINNER_LEFT_3,
> 	BUSY_SPINNER_SAVE,
> 	BUSY_SPINNER_RIGHT,
> };

## END_TEXT_COMMAND_CLEAR_PRINT

```c
void END_TEXT_COMMAND_CLEAR_PRINT()  // 0xFCC75460ABA29378
```

build 323

## END_TEXT_COMMAND_DISPLAY_HELP

```c
void END_TEXT_COMMAND_DISPLAY_HELP(int p0, BOOL loop, BOOL beep, int shape)  // 0x238FFE5C7B0498A6
```

build 323 · old names: `_DISPLAY_HELP_TEXT_FROM_STRING_LABEL`

> shape goes from -1 to 50 (may be more).
> p0 is always 0.
> 
> Example:
> void FloatingHelpText(const char* text)
> {
>     BEGIN_TEXT_COMMAND_DISPLAY_HELP("STRING");
>   ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
>    END_TEXT_COMMAND_DISPLAY_HELP (0, 0, 1, -1);
> }
> 
> more inputs/icons:
> - https://pastebin.com/nqNYWMSB

## END_TEXT_COMMAND_DISPLAY_TEXT

```c
void END_TEXT_COMMAND_DISPLAY_TEXT(float x, float y, int p2)  // 0xCD015E5BB0D96A57
```

build 323 · old names: `_DRAW_TEXT`

> After applying the properties to the text (See HUD::SET_TEXT_), this will draw the text in the applied position. Also 0.0f < x, y < 1.0f, percentage of the axis.

## END_TEXT_COMMAND_GET_NUMBER_OF_LINES_FOR_STRING

```c
int END_TEXT_COMMAND_GET_NUMBER_OF_LINES_FOR_STRING(float x, float y)  // 0x9040DFB09BE75706
```

build 323 · old names: `_GET_TEXT_SCREEN_LINE_COUNT`, `_END_TEXT_COMMAND_GET_LINE_COUNT`, `_END_TEXT_COMMAND_LINE_COUNT`

> Determines how many lines the text string will use when drawn on screen. 
> Must use BEGIN_TEXT_COMMAND_GET_NUMBER_OF_LINES_FOR_STRING for setting up

## END_TEXT_COMMAND_GET_SCREEN_WIDTH_OF_DISPLAY_TEXT

```c
float END_TEXT_COMMAND_GET_SCREEN_WIDTH_OF_DISPLAY_TEXT(BOOL p0)  // 0x85F061DA64ED2F67
```

build 323 · old names: `_GET_TEXT_SCREEN_WIDTH`, `_END_TEXT_COMMAND_GET_WIDTH`

## END_TEXT_COMMAND_IS_MESSAGE_DISPLAYED

```c
BOOL END_TEXT_COMMAND_IS_MESSAGE_DISPLAYED()  // 0x8A9BA1AB3E237613
```

build 323

## END_TEXT_COMMAND_IS_THIS_HELP_MESSAGE_BEING_DISPLAYED

```c
BOOL END_TEXT_COMMAND_IS_THIS_HELP_MESSAGE_BEING_DISPLAYED(int p0)  // 0x10BDDBFC529428DD
```

build 323

## END_TEXT_COMMAND_OVERRIDE_BUTTON_TEXT

```c
void END_TEXT_COMMAND_OVERRIDE_BUTTON_TEXT(int p0)  // 0xA86911979638106F
```

build 323 · old names: `_END_TEXT_COMMAND_TIMER`

## END_TEXT_COMMAND_PRINT

```c
void END_TEXT_COMMAND_PRINT(int duration, BOOL drawImmediately)  // 0x9D77056A530643F6
```

build 323 · old names: `_DRAW_SUBTITLE_TIMED`

> Draws the subtitle at middle center of the screen.
> 
> int duration = time in milliseconds to show text on screen before disappearing
> 
> drawImmediately = If true, the text will be drawn immediately, if false, the text will be drawn after the previous subtitle has finished

## END_TEXT_COMMAND_SET_BLIP_NAME

```c
void END_TEXT_COMMAND_SET_BLIP_NAME(Blip blip)  // 0xBC38B49BCB83BC9B
```

build 323

> Finalizes a text command started with BEGIN_TEXT_COMMAND_SET_BLIP_NAME, setting the name of the specified blip.

## END_TEXT_COMMAND_THEFEED_POST_AWARD

```c
int END_TEXT_COMMAND_THEFEED_POST_AWARD(const char* textureDict, const char* textureName, int rpBonus, int colorOverlay, const char* titleLabel)  // 0xAA295B6F28BD587D
```

build 323 · old names: `_DRAW_NOTIFICATION_ICON`, `_DRAW_NOTIFICATION_AWARD`

> Shows an "award" notification above the minimap
> Example:
> 
> HUD::BEGIN_TEXT_COMMAND_THEFEED_POST("HUNT");
> HUD::END_TEXT_COMMAND_THEFEED_POST_AWARD("Hunting", "Hunting_Gold_128", 0, 109, "HUD_MED_UNLKED");

## END_TEXT_COMMAND_THEFEED_POST_CREW_RANKUP_WITH_LITERAL_FLAG

```c
int END_TEXT_COMMAND_THEFEED_POST_CREW_RANKUP_WITH_LITERAL_FLAG(const char* p0, const char* p1, const char* p2, BOOL p3, BOOL p4)  // 0x8EFCCF6EC66D85E4
```

build 323 · old names: `END_TEXT_COMMAND_THEFEED_POST_CREW_RANKUP`

## END_TEXT_COMMAND_THEFEED_POST_CREWTAG

```c
int END_TEXT_COMMAND_THEFEED_POST_CREWTAG(BOOL p0, BOOL p1, int* p2, int p3, BOOL isLeader, BOOL unk0, int clanDesc, int R, int G, int B)  // 0x97C9E4E7024A8F2C
```

build 323 · old names: `_NOTIFICATION_SEND_APARTMENT_INVITE`, `_DRAW_NOTIFICATION_APARTMENT_INVITE`

## END_TEXT_COMMAND_THEFEED_POST_CREWTAG_WITH_GAME_NAME

```c
int END_TEXT_COMMAND_THEFEED_POST_CREWTAG_WITH_GAME_NAME(BOOL p0, BOOL p1, int* p2, int p3, BOOL isLeader, BOOL unk0, int clanDesc, const char* playerName, int R, int G, int B)  // 0x137BC35589E34E1E
```

build 323 · old names: `_NOTIFICATION_SEND_CLAN_INVITE`, `_DRAW_NOTIFICATION_CLAN_INVITE`

## END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT

```c
int END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT(const char* txdName, const char* textureName, BOOL flash, int iconType, const char* sender, const char* subject)  // 0x1CCD9A37359072CF
```

build 323 · old names: `_SET_NOTIFICATION_MESSAGE`

> This function can show pictures of every texture that can be requested by REQUEST_STREAMED_TEXTURE_DICT.
> 
> List of picNames: https://pastebin.com/XdpJVbHz
> 
> 
> flash is a bool for fading in.
> iconTypes:
> 1 : Chat Box
> 2 : Email
> 3 : Add Friend Request
> 4 : Nothing
> 5 : Nothing
> 6 : Nothing
> 7 : Right Jumping Arrow
> 8 : RP Icon
> 9 : $ Icon
> 
> "sender" is the very top header. This can be any old string.
> "subject" is the header under the sender.

## END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_SUBTITLE_LABEL

```c
int END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_SUBTITLE_LABEL(const char* txdName, const char* textureName, BOOL flash, int iconType, const char* sender, const char* subject)  // 0xC6F580E4C94926AC
```

build 323 · old names: `_SET_NOTIFICATION_MESSAGE_3`, `_END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_ENTRY`, `_END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_GXT_ENTRY`

> This function can show pictures of every texture that can be requested by REQUEST_STREAMED_TEXTURE_DICT.
> 
> Needs more research.
> 
> Only one type of usage in the scripts:
> 
> HUD::END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_SUBTITLE_LABEL("CHAR_ACTING_UP", "CHAR_ACTING_UP", 0, 0, "DI_FEED_CHAR", a_0);

## END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_TU

```c
int END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_TU(const char* txdName, const char* textureName, BOOL flash, int iconType, const char* sender, const char* subject, float duration)  // 0x1E6611149DB3DB6B
```

build 323 · old names: `_SET_NOTIFICATION_MESSAGE_4`

> This function can show pictures of every texture that can be requested by REQUEST_STREAMED_TEXTURE_DICT.
> 
> NOTE: 'duration' is a multiplier, so 1.0 is normal, 2.0 is twice as long (very slow), and 0.5 is half as long.
> 
> Example, only occurrence in the scripts:
> v_8 = HUD::END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_TU("CHAR_SOCIAL_CLUB", "CHAR_SOCIAL_CLUB", 0, 0, &v_9, "", a_5);

## END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_WITH_CREW_TAG

```c
int END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_WITH_CREW_TAG(const char* txdName, const char* textureName, BOOL flash, int iconType, const char* sender, const char* subject, float duration, const char* clanTag)  // 0x5CBF7BADE20DB93E
```

build 323 · old names: `_SET_NOTIFICATION_MESSAGE_CLAN_TAG`

> This function can show pictures of every texture that can be requested by REQUEST_STREAMED_TEXTURE_DICT.
> 
> List of picNames https://pastebin.com/XdpJVbHz
> 
> flash is a bool for fading in.
> iconTypes:
> 1 : Chat Box
> 2 : Email
> 3 : Add Friend Request
> 4 : Nothing
> 5 : Nothing
> 6 : Nothing
> 7 : Right Jumping Arrow
> 8 : RP Icon
> 9 : $ Icon
> 
> "sender" is the very top header. This can be any old string.
> "subject" is the header under the sender.
> "duration" is a multiplier, so 1.0 is normal, 2.0 is twice as long (very slow), and 0.5 is half as long.
> "clanTag" shows a crew tag in the "sender" header, after the text. You need to use 3 underscores as padding. Maximum length of this field seems to be 7. (e.g. "MK" becomes "___MK", "ACE" becomes "___ACE", etc.)

## END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_WITH_CREW_TAG_AND_ADDITIONAL_ICON

```c
int END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_WITH_CREW_TAG_AND_ADDITIONAL_ICON(const char* txdName, const char* textureName, BOOL flash, int iconType1, const char* sender, const char* subject, float duration, const char* clanTag, int iconType2, int p9)  // 0x531B84E7DA981FB6
```

build 323 · old names: `_SET_NOTIFICATION_MESSAGE_CLAN_TAG_2`

> This function can show pictures of every texture that can be requested by REQUEST_STREAMED_TEXTURE_DICT.
> 
> List of picNames:  https://pastebin.com/XdpJVbHz
> 
> flash is a bool for fading in.
> iconTypes:
> 1 : Chat Box
> 2 : Email
> 3 : Add Friend Request
> 4 : Nothing
> 5 : Nothing
> 6 : Nothing
> 7 : Right Jumping Arrow
> 8 : RP Icon
> 9 : $ Icon
> 
> "sender" is the very top header. This can be any old string.
> "subject" is the header under the sender.
> "duration" is a multiplier, so 1.0 is normal, 2.0 is twice as long (very slow), and 0.5 is half as long.
> "clanTag" shows a crew tag in the "sender" header, after the text. You need to use 3 underscores as padding. Maximum length of this field seems to be 7. (e.g. "MK" becomes "___MK", "ACE" becomes "___ACE", etc.)
> iconType2 is a mirror of iconType. It shows in the "subject" line, right under the original iconType.
> 
> 
> int IconNotification(char *text, char *text2, char *Subject)
> {
>     BEGIN_TEXT_COMMAND_THEFEED_POST("STRING");
>  ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
>    END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT_WITH_CREW_TAG_AND_ADDITIONAL_ICON("CHAR_SOCIAL_CLUB", "CHAR_SOCIAL_CLUB", 1, 7, text2, Subject, 1.0f, "__EXAMPLE", 7);
>    return END_TEXT_COMMAND_THEFEED_POST_TICKER(1, 1);
> }

## END_TEXT_COMMAND_THEFEED_POST_MPTICKER

```c
int END_TEXT_COMMAND_THEFEED_POST_MPTICKER(BOOL blink, BOOL p1)  // 0xF020C96915705B3A
```

build 323 · old names: `_DRAW_NOTIFICATION_4`

## END_TEXT_COMMAND_THEFEED_POST_REPLAY

```c
int END_TEXT_COMMAND_THEFEED_POST_REPLAY(int type, int image, const char* text)  // 0xD202B92CBF1D816F
```

build 323 · old names: `_DRAW_NOTIFICATION_WITH_ICON`, `_END_TEXT_COMMAND_THEFEED_POST_REPLAY_ICON`

> returns a notification handle, prints out a notification like below:
> type range: 0 - 2
> if you set type to 1, image goes from 0 - 39 - Xbox you can add text to
> 
> example: 
> HUD::END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT(1, 20, "Who you trynna get crazy with, ese? Don't you know I'm LOCO?!");
> - https://i.imgur.com/lGBPCz3.jpeg

## END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT

```c
int END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT(int type, const char* button, const char* text)  // 0xDD6CB2CCE7C2735C
```

build 323 · old names: `_DRAW_NOTIFICATION_WITH_BUTTON`, `_END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT`

> returns a notification handle, prints out a notification like below:
> type range: 0 - 2
> if you set type to 1, button accepts "~INPUT_SOMETHING~"
> 
> example:
> HUD::END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT(1, "~INPUT_TALK~", "Who you trynna get crazy with, ese? Don't you know I'm LOCO?!");
> 
> Examples from the scripts:
> l_D1[1/*1*/]=HUD::END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT(1,"~INPUT_REPLAY_START_STOP_RECORDING~","");
> l_D1[2/*1*/]=HUD::END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT(1,"~INPUT_SAVE_REPLAY_CLIP~","");
> l_D1[1/*1*/]=HUD::END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT(1,"~INPUT_REPLAY_START_STOP_RECORDING~","");
> l_D1[2/*1*/]=HUD::END_TEXT_COMMAND_THEFEED_POST_REPLAY_INPUT(1,"~INPUT_REPLAY_START_STOP_RECORDING_SECONDARY~","");
> 

## END_TEXT_COMMAND_THEFEED_POST_STATS

```c
int END_TEXT_COMMAND_THEFEED_POST_STATS(const char* statTitle, int iconEnum, BOOL stepVal, int barValue, BOOL isImportant, const char* pictureTextureDict, const char* pictureTextureName)  // 0x2B7E9A4EAAA93C89
```

build 323 · old names: `_SET_NOTIFICATION_MESSAGE_2`

> List of picture names: https://pastebin.com/XdpJVbHz

## END_TEXT_COMMAND_THEFEED_POST_TICKER

```c
int END_TEXT_COMMAND_THEFEED_POST_TICKER(BOOL blink, BOOL p1)  // 0x2ED7843F8F801023
```

build 323 · old names: `_DRAW_NOTIFICATION`

## END_TEXT_COMMAND_THEFEED_POST_TICKER_FORCED

```c
int END_TEXT_COMMAND_THEFEED_POST_TICKER_FORCED(BOOL blink, BOOL p1)  // 0x44FA03975424A0EE
```

build 323 · old names: `_DRAW_NOTIFICATION_2`

## END_TEXT_COMMAND_THEFEED_POST_TICKER_WITH_TOKENS

```c
int END_TEXT_COMMAND_THEFEED_POST_TICKER_WITH_TOKENS(BOOL blink, BOOL p1)  // 0x378E809BF61EC840
```

build 323 · old names: `_DRAW_NOTIFICATION_3`

## END_TEXT_COMMAND_THEFEED_POST_UNLOCK

```c
int END_TEXT_COMMAND_THEFEED_POST_UNLOCK(const char* gxtLabel1, int p1, const char* gxtLabel2)  // 0x33EE12743CCD6343
```

build 323

## END_TEXT_COMMAND_THEFEED_POST_UNLOCK_TU

```c
int END_TEXT_COMMAND_THEFEED_POST_UNLOCK_TU(const char* gxtLabel1, int p1, const char* gxtLabel2, int p3)  // 0xC8F3AAF93D0600BF
```

build 323

## END_TEXT_COMMAND_THEFEED_POST_UNLOCK_TU_WITH_COLOR

```c
int END_TEXT_COMMAND_THEFEED_POST_UNLOCK_TU_WITH_COLOR(Any p0, Any p1, Any p2, Any p3, Any p4, Any p5)  // 0x7AE0589093A2E088
```

build 323

## END_TEXT_COMMAND_THEFEED_POST_VERSUS_TU

```c
int END_TEXT_COMMAND_THEFEED_POST_VERSUS_TU(const char* txdName1, const char* textureName1, int count1, const char* txdName2, const char* textureName2, int count2, int hudColor1, int hudColor2)  // 0xB6871B0555B02996
```

build 323

> This function can show pictures of every texture that can be requested by REQUEST_STREAMED_TEXTURE_DICT.
> 
> List of picNames: https://pastebin.com/XdpJVbHz
> 
> Shows a deathmatch score above the minimap, example: https://i.imgur.com/YmoMklG.png

## FLAG_PLAYER_CONTEXT_IN_TOURNAMENT

```c
void FLAG_PLAYER_CONTEXT_IN_TOURNAMENT(BOOL toggle)  // 0xCEF214315D276FD1
```

build 323 · old names: `_SET_IS_IN_TOURNAMENT`

## FLASH_ABILITY_BAR

```c
void FLASH_ABILITY_BAR(int millisecondsToFlash)  // 0x02CFBA0C9E9275CE
```

build 323

## FLASH_MINIMAP_DISPLAY

```c
void FLASH_MINIMAP_DISPLAY()  // 0xF2DD778C22B15BDA
```

build 323

> adds a short flash to the Radar/Minimap
> Usage: UI.FLASH_MINIMAP_DISPLAY

## FLASH_MINIMAP_DISPLAY_WITH_COLOR

```c
void FLASH_MINIMAP_DISPLAY_WITH_COLOR(int hudColorIndex)  // 0x6B1DE27EE78E6A19
```

build 323

## FLASH_WANTED_DISPLAY

```c
void FLASH_WANTED_DISPLAY(BOOL p0)  // 0xA18AFB39081B6A1F
```

build 323

## FORCE_CLOSE_REPORTUGC_MENU

```c
void FORCE_CLOSE_REPORTUGC_MENU()  // 0xEE4C0E6DBC6F2C6F
```

build 323

## FORCE_CLOSE_TEXT_INPUT_BOX

```c
void FORCE_CLOSE_TEXT_INPUT_BOX()  // 0x8817605C2BA76200
```

build 323 · old names: `_FORCE_CLOSE_TEXT_INPUT_BOX`

## FORCE_NEXT_MESSAGE_TO_PREVIOUS_BRIEFS_LIST

```c
void FORCE_NEXT_MESSAGE_TO_PREVIOUS_BRIEFS_LIST(int p0)  // 0x57D760D55F54E071
```

build 323

## FORCE_OFF_WANTED_STAR_FLASH

```c
void FORCE_OFF_WANTED_STAR_FLASH(BOOL toggle)  // 0xBA8D65C1C65702E5
```

build 323

## FORCE_SCRIPTED_GFX_WHEN_FRONTEND_ACTIVE

```c
void FORCE_SCRIPTED_GFX_WHEN_FRONTEND_ACTIVE(const char* p0)  // 0x2162C446DFDF38FD
```

build 323 · old names: `_LOG_DEBUG_INFO`

> Not present in retail version of the game

## FORCE_SONAR_BLIPS_THIS_FRAME

```c
BOOL FORCE_SONAR_BLIPS_THIS_FRAME()  // 0x1121BFA1A1A522A8
```

build 323

> Doesn't actually return anything.

## GET_AI_PED_PED_BLIP_INDEX

```c
Blip GET_AI_PED_PED_BLIP_INDEX(Ped ped)  // 0x7CD934010E115C2C
```

build 323 · old names: `_GET_AI_BLIP_2`

## GET_AI_PED_VEHICLE_BLIP_INDEX

```c
Blip GET_AI_PED_VEHICLE_BLIP_INDEX(Ped ped)  // 0x56176892826A4FE8
```

build 323 · old names: `_GET_AI_BLIP`

> Returns the current AI BLIP for the specified ped

## GET_BLIP_ALPHA

```c
int GET_BLIP_ALPHA(Blip blip)  // 0x970F608F0EE6C885
```

build 323

## GET_BLIP_COLOUR

```c
int GET_BLIP_COLOUR(Blip blip)  // 0xDF729E8D20CF7327
```

build 323

## GET_BLIP_COORDS

```c
Vector3 GET_BLIP_COORDS(Blip blip)  // 0x586AFE3FF72D996E
```

build 323

## GET_BLIP_FADE_DIRECTION

```c
int GET_BLIP_FADE_DIRECTION(Blip blip)  // 0x2C173AE2BDB9385E
```

build 463 · old names: `_GET_BLIP_FADE_STATUS`

> Returns -1, 0, +1, depending on if the blip is fading out, doing nothing, or fading in respectively.

## GET_BLIP_FROM_ENTITY

```c
Blip GET_BLIP_FROM_ENTITY(Entity entity)  // 0xBC8DBDCA2436F7E8
```

build 323

> Returns the Blip handle of given Entity.

## GET_BLIP_HUD_COLOUR

```c
int GET_BLIP_HUD_COLOUR(Blip blip)  // 0x729B5F1EFBC0AAEE
```

build 323

## GET_BLIP_INFO_ID_COORD

```c
Vector3 GET_BLIP_INFO_ID_COORD(Blip blip)  // 0xFA7C7F0AADF25D09
```

build 323

## GET_BLIP_INFO_ID_DISPLAY

```c
int GET_BLIP_INFO_ID_DISPLAY(Blip blip)  // 0x1E314167F701DC3B
```

build 323

## GET_BLIP_INFO_ID_ENTITY_INDEX

```c
Entity GET_BLIP_INFO_ID_ENTITY_INDEX(Blip blip)  // 0x4BA4E2553AFEDC2C
```

build 323

## GET_BLIP_INFO_ID_PICKUP_INDEX

```c
Pickup GET_BLIP_INFO_ID_PICKUP_INDEX(Blip blip)  // 0x9B6786E4C03DD382
```

build 323

> This function is hard-coded to always return 0.

## GET_BLIP_INFO_ID_TYPE

```c
int GET_BLIP_INFO_ID_TYPE(Blip blip)  // 0xBE9B0959FFD0779B
```

build 323

> Returns a value based on what the blip is attached to
> 1 - Vehicle
> 2 - Ped
> 3 - Object
> 4 - Coord
> 5 - unk
> 6 - Pickup
> 7 - Radius

## GET_BLIP_ROTATION

```c
int GET_BLIP_ROTATION(Blip blip)  // 0x003E92BA477F9D7F
```

build 2060 · old names: `_GET_BLIP_ROTATION`

## GET_BLIP_SPRITE

```c
int GET_BLIP_SPRITE(Blip blip)  // 0x1FC877464A04FC4F
```

build 323

> Blips Images + IDs:
> gtaxscripting.blogspot.com/2016/05/gta-v-blips-id-and-image.html

## GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME

```c
const char* GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME(const char* text, int position, int length)  // 0x169BD9382084C8C0
```

build 323 · old names: `_GET_TEXT_SUBSTRING`

> Returns a substring of a specified length starting at a specified position.
> 
> Example:
> // Get "STRING" text from "MY_STRING"
> subStr = HUD::GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME("MY_STRING", 3, 6);

## GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_BYTES

```c
const char* GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_BYTES(const char* text, int startPosition, int endPosition)  // 0xCE94AEBA5D82908A
```

build 323 · old names: `_GET_TEXT_SUBSTRING_SLICE`

> Returns a substring that is between two specified positions. The length of the string will be calculated using (endPosition - startPosition).
> 
> Example:
> // Get "STRING" text from "MY_STRING"
> subStr = HUD::GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_BYTES("MY_STRING", 3, 9);
> // Overflows are possibly replaced with underscores (needs verification)
> subStr = HUD::GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_BYTES("MY_STRING", 3, 10); // "STRING_"?

## GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_WITH_BYTE_LIMIT

```c
const char* GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_WITH_BYTE_LIMIT(const char* text, int position, int length, int maxLength)  // 0xB2798643312205C5
```

build 323 · old names: `_GET_TEXT_SUBSTRING_SAFE`

> Returns a substring of a specified length starting at a specified position. The result is guaranteed not to exceed the specified max length.
> 
> NOTE: The 'maxLength' parameter might actually be the size of the buffer that is returned. More research is needed. -CL69
> 
> Example:
> // Condensed example of how Rockstar uses this function
> strLen = HUD::GET_LENGTH_OF_LITERAL_STRING(MISC::GET_ONSCREEN_KEYBOARD_RESULT());
> subStr = HUD::GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_WITH_BYTE_LIMIT(MISC::GET_ONSCREEN_KEYBOARD_RESULT(), 0, strLen, 63);
> 
> --
> 
> "fm_race_creator.ysc", line 85115:
> // parameters modified for clarity
> BOOL sub_8e5aa(char *text, int length) {
>     for (i = 0; i <= (length - 2); i += 1) {
>         if (!MISC::ARE_STRINGS_EQUAL(HUD::GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME_WITH_BYTE_LIMIT(text, i, i + 1, 1), " ")) {
>             return FALSE;
>         }
>     }
>     return TRUE;
> }

## GET_CHARACTER_MENU_PED_FLOAT_STAT

```c
BOOL GET_CHARACTER_MENU_PED_FLOAT_STAT(float statHash, float* outValue, BOOL p2)  // 0x8F08017F9D7C47BD
```

build 323

## GET_CHARACTER_MENU_PED_INT_STAT

```c
BOOL GET_CHARACTER_MENU_PED_INT_STAT(Any p0, Any* p1, Any p2)  // 0xCA6B2F7CE32AB653
```

build 323

## GET_CHARACTER_MENU_PED_MASKED_INT_STAT

```c
BOOL GET_CHARACTER_MENU_PED_MASKED_INT_STAT(Hash statHash, Any* outValue, int p2, int mask, BOOL p4)  // 0x24A49BEAF468DC90
```

build 323

## GET_CLOSEST_BLIP_INFO_ID

```c
Blip GET_CLOSEST_BLIP_INFO_ID(int blipSprite)  // 0xD484BF71050CA1EE
```

build 1180 · old names: `_GET_CLOSEST_BLIP_OF_TYPE`

## GET_CURRENT_FRONTEND_MENU_VERSION

```c
Hash GET_CURRENT_FRONTEND_MENU_VERSION()  // 0x2309595AD6145265
```

build 323 · old names: `_GET_CURRENT_FRONTEND_MENU`

> if (HUD::GET_CURRENT_FRONTEND_MENU_VERSION() == joaat("fe_menu_version_empty_no_background"))

## GET_CURRENT_WEBPAGE_ID

```c
int GET_CURRENT_WEBPAGE_ID()  // 0x01A358D9128B7A86
```

build 323 · old names: `_GET_ACTIVE_WEBSITE_ID`

## GET_CURRENT_WEBSITE_ID

```c
int GET_CURRENT_WEBSITE_ID()  // 0x97D47996FC48CBAD
```

build 323

## GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID

```c
int GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID()  // 0x52F0982D7FD156B6
```

build 323

> This function is hard-coded to always return 1.

## GET_FAKE_SPECTATOR_MODE

```c
BOOL GET_FAKE_SPECTATOR_MODE()  // 0xC2D2AD9EAAE265B8
```

build 505

> Getter for SET_FAKE_SPECTATOR_MODE

## GET_FILENAME_FOR_AUDIO_CONVERSATION

```c
const char* GET_FILENAME_FOR_AUDIO_CONVERSATION(const char* labelName)  // 0x7B5280EBA9840C72
```

build 323 · old names: `_GET_LABEL_TEXT`

> Gets a localized string literal from a label name. Can be used for output of e.g. VEHICLE::GET_LIVERY_NAME. To check if a GXT label can be localized with this, HUD::DOES_TEXT_LABEL_EXIST can be used.

## GET_FIRST_BLIP_INFO_ID

```c
Blip GET_FIRST_BLIP_INFO_ID(int blipSprite)  // 0x1BEDE233E6CD2A1F
```

build 323

## GET_FIRST_N_CHARACTERS_OF_LITERAL_STRING

```c
const char* GET_FIRST_N_CHARACTERS_OF_LITERAL_STRING(const char* string, int length)  // 0x98C3CF913D895111
```

build 505

## GET_GLOBAL_ACTIONSCRIPT_FLAG

```c
int GET_GLOBAL_ACTIONSCRIPT_FLAG(int flagIndex)  // 0xE3B05614DCE1D014
```

build 323

> Returns the ActionScript flagValue.
> ActionScript flags are global flags that scaleforms use
> Flags found during testing
> 0: Returns 1 if the web_browser keyboard is open, otherwise 0
> 1: Returns 1 if the player has clicked back twice on the opening page, otherwise 0 (web_browser)
> 2: Returns how many links the player has clicked in the web_browser scaleform, returns 0 when the browser gets closed
> 9: Returns the current selection on the mobile phone scaleform
> 
> There are 20 flags in total.

## GET_HUD_COLOUR

```c
void GET_HUD_COLOUR(int hudColorIndex, int* r, int* g, int* b, int* a)  // 0x7C9C91AB74A0360F
```

build 323

## GET_HUD_COMPONENT_POSITION

```c
Vector3 GET_HUD_COMPONENT_POSITION(int id)  // 0x223CA69A8C4417FD
```

build 323

## GET_HUD_SCREEN_POSITION_FROM_WORLD_POSITION

```c
int GET_HUD_SCREEN_POSITION_FROM_WORLD_POSITION(float worldX, float worldY, float worldZ, float* screenX, float* screenY)  // 0xF9904D11F1ACBEC3
```

build 323 · old names: `_GET_2D_COORD_FROM_3D_COORD`

> World to relative screen coords, this world to screen will keep the text on screen.

## GET_LENGTH_OF_LITERAL_STRING

```c
int GET_LENGTH_OF_LITERAL_STRING(const char* string)  // 0xF030907CCBB8A9FD
```

build 323

> Returns the length of the string passed (much like strlen).

## GET_LENGTH_OF_LITERAL_STRING_IN_BYTES

```c
int GET_LENGTH_OF_LITERAL_STRING_IN_BYTES(const char* string)  // 0x43E4111189E54F0E
```

build 323 · old names: `_GET_LENGTH_OF_STRING`

## GET_LENGTH_OF_STRING_WITH_THIS_TEXT_LABEL

```c
int GET_LENGTH_OF_STRING_WITH_THIS_TEXT_LABEL(const char* gxt)  // 0x801BD273D3A23F74
```

build 323

> Returns the string length of the string from the gxt string .

## GET_MAIN_PLAYER_BLIP_ID

```c
Blip GET_MAIN_PLAYER_BLIP_ID()  // 0xDCD4EC3F419D02FA
```

build 323

## GET_MENU_LAYOUT_CHANGED_EVENT_DETAILS

```c
void GET_MENU_LAYOUT_CHANGED_EVENT_DETAILS(int* lastItemMenuId, int* selectedItemMenuId, int* selectedItemUniqueId)  // 0x7E17BE53E1AAABAF
```

build 323 · old names: `_GET_PAUSE_MENU_SELECTION_DATA`

> lastItemMenuId: this is the menuID of the last selected item minus 1000 (lastItem.menuID - 1000)
> selectedItemMenuId: same as lastItemMenuId except for the currently selected menu item
> selectedItemUniqueId: this is uniqueID of the currently selected menu item
> 
> when the pausemenu is closed:
> lastItemMenuId = -1
> selectedItemMenuId = -1
> selectedItemUniqueId = 0
> 
> when the header gains focus:
> lastItemMenuId updates as normal or 0 if the pausemenu was just opened
> selectedItemMenuId becomes a unique id for the pausemenu page that focus was taken from (?) or 0 if the pausemenu was just opened
> selectedItemUniqueId = -1
> 
> when focus is moved from the header to a pausemenu page:
> lastItemMenuId becomes a unique id for the pausemenu page that focus was moved to (?)
> selectedItemMenuId = -1
> selectedItemUniqueId updates as normal

## GET_MENU_PED_BOOL_STAT

```c
BOOL GET_MENU_PED_BOOL_STAT(Hash statHash, BOOL* outValue)  // 0x052991E59076E4E4
```

build 323

> p0 was always 0xAE2602A3.

## GET_MENU_PED_FLOAT_STAT

```c
BOOL GET_MENU_PED_FLOAT_STAT(Hash statHash, float* outValue)  // 0x5FBD7095FE7AE57F
```

build 323

## GET_MENU_PED_INT_STAT

```c
BOOL GET_MENU_PED_INT_STAT(Any p0, Any* p1)  // 0xEF4CED81CEBEDC6D
```

build 323 · old names: `SET_USERIDS_UIHIDDEN`

## GET_MENU_PED_MASKED_INT_STAT

```c
BOOL GET_MENU_PED_MASKED_INT_STAT(Hash statHash, int* outValue, int mask, BOOL p3)  // 0x90A6526CF0381030
```

build 323

## GET_MENU_TRIGGER_EVENT_DETAILS

```c
void GET_MENU_TRIGGER_EVENT_DETAILS(int* lastItemMenuId, int* selectedItemUniqueId)  // 0x36C1451A88A09630
```

build 323 · old names: `_GET_PAUSE_MENU_SELECTION`

## GET_MINIMAP_FOW_COORDINATE_IS_REVEALED

```c
BOOL GET_MINIMAP_FOW_COORDINATE_IS_REVEALED(float x, float y, float z)  // 0x6E31B91145873922
```

build 323 · old names: `_IS_MINIMAP_AREA_REVEALED`

## GET_MINIMAP_FOW_DISCOVERY_RATIO

```c
float GET_MINIMAP_FOW_DISCOVERY_RATIO()  // 0xE0130B41D3CF4574
```

build 323 · old names: `_GET_MINIMAP_REVEAL_PERCENTAGE`

## GET_MOUSE_EVENT

```c
BOOL GET_MOUSE_EVENT(int scaleformHandle, Any* p1, Any* p2, Any* p3)  // 0x632B2940C67F4EA9
```

build 323

## GET_NAMED_RENDERTARGET_RENDER_ID

```c
int GET_NAMED_RENDERTARGET_RENDER_ID(const char* name)  // 0x1A6478B61C6BDC3B
```

build 323

## GET_NEW_SELECTED_MISSION_CREATOR_BLIP

```c
Blip GET_NEW_SELECTED_MISSION_CREATOR_BLIP()  // 0x5C90988E7C8E1AF4
```

build 323 · old names: `DISABLE_BLIP_NAME_FOR_VAR`

## GET_NEXT_BLIP_INFO_ID

```c
Blip GET_NEXT_BLIP_INFO_ID(int blipSprite)  // 0x14F96AA50D6FBEA7
```

build 323

## GET_NORTH_BLID_INDEX

```c
Blip GET_NORTH_BLID_INDEX()  // 0x3F0CF9CB7E589B88
```

build 463 · old names: `_GET_NORTH_RADAR_BLIP`

## GET_NUMBER_OF_ACTIVE_BLIPS

```c
int GET_NUMBER_OF_ACTIVE_BLIPS()  // 0x9A3FF3DE163034E8
```

build 323

## GET_PAUSE_MENU_POSITION

```c
Vector3 GET_PAUSE_MENU_POSITION()  // 0x5BFF36D6ED83E0AE
```

build 323

## GET_PAUSE_MENU_STATE

```c
int GET_PAUSE_MENU_STATE()  // 0x272ACD84970869C5
```

build 323

> Returns:
> 
> 0
> 5
> 10
> 15
> 20
> 25
> 30
> 35
> 

## GET_PM_PLAYER_CREW_COLOR

```c
BOOL GET_PM_PLAYER_CREW_COLOR(int* r, int* g, int* b)  // 0xA238192F33110615
```

build 323

## GET_RENDERED_CHARACTER_HEIGHT

```c
float GET_RENDERED_CHARACTER_HEIGHT(float size, int font)  // 0xDB88A37483346780
```

build 323 · old names: `_GET_TEXT_SCALE_HEIGHT`

> This gets the height of the FONT and not the total text. You need to get the number of lines your text uses, and get the height of a newline (I'm using a smaller value) to get the total text height.

## GET_RENDERED_TEXT_PADDING_SIZE

```c
float GET_RENDERED_TEXT_PADDING_SIZE()  // 0xD6FAD05D855AF80F
```

build 3889

## GET_SCREEN_CODE_WANTS_SCRIPT_TO_CONTROL

```c
int GET_SCREEN_CODE_WANTS_SCRIPT_TO_CONTROL()  // 0x593FEAE1F73392D4
```

build 323

## GET_STANDARD_BLIP_ENUM_ID

```c
int GET_STANDARD_BLIP_ENUM_ID()  // 0x4A9923385BDB9DAD
```

build 323 · old names: `_GET_LEVEL_BLIP_SPRITE`

## GET_STREET_NAME_FROM_HASH_KEY

```c
const char* GET_STREET_NAME_FROM_HASH_KEY(Hash hash)  // 0xD0EF8A959B8A4CB9
```

build 323

> This functions converts the hash of a street name into a readable string.
> 
> For how to get the hashes, see PATHFIND::GET_STREET_NAME_AT_COORD.

## GET_WARNING_SCREEN_MESSAGE_HASH

```c
Hash GET_WARNING_SCREEN_MESSAGE_HASH()  // 0x81DF9ABA6C83DFF9
```

build 1290 · old names: `_GET_WARNING_MESSAGE_TITLE_HASH`

> Has to do with the confirmation overlay (E.g. confirm exit)

## GET_WAYPOINT_BLIP_ENUM_ID

```c
int GET_WAYPOINT_BLIP_ENUM_ID()  // 0x186E5D252FA50E7D
```

build 323 · old names: `_GET_BLIP_INFO_ID_ITERATOR`

## GET_WAYPOINT_CLEAR_ON_ARRIVAL_MODE

```c
int GET_WAYPOINT_CLEAR_ON_ARRIVAL_MODE()  // 0xF46851AB8B02EF40
```

build 3717

## GIVE_PED_TO_PAUSE_MENU

```c
void GIVE_PED_TO_PAUSE_MENU(Ped ped, int p1)  // 0xAC0BFBDC3BE00E14
```

build 323

> p1 is either 1 or 2 in the PC scripts.

## HAS_ADDITIONAL_TEXT_LOADED

```c
BOOL HAS_ADDITIONAL_TEXT_LOADED(int slot)  // 0x02245FE4BED318B8
```

build 323

## HAS_DIRECTOR_MODE_BEEN_LAUNCHED_BY_CODE

```c
BOOL HAS_DIRECTOR_MODE_BEEN_LAUNCHED_BY_CODE()  // 0xA277800A9EAE340E
```

build 323 · old names: `_HAS_DIRECTOR_MODE_BEEN_TRIGGERED`

## HAS_MENU_LAYOUT_CHANGED_EVENT_OCCURRED

```c
BOOL HAS_MENU_LAYOUT_CHANGED_EVENT_OCCURRED()  // 0x2E22FEFA0100275E
```

build 323

## HAS_MENU_TRIGGER_EVENT_OCCURRED

```c
BOOL HAS_MENU_TRIGGER_EVENT_OCCURRED()  // 0xF284AC67940C6812
```

build 323

## HAS_SCRIPT_HIDDEN_HELP_THIS_FRAME

```c
BOOL HAS_SCRIPT_HIDDEN_HELP_THIS_FRAME()  // 0x214CD562A939246A
```

build 323

## HAS_THIS_ADDITIONAL_TEXT_LOADED

```c
BOOL HAS_THIS_ADDITIONAL_TEXT_LOADED(const char* gxt, int slot)  // 0xADBF060E2B30C5BC
```

build 323

> Checks if the specified gxt has loaded into the passed slot.

## HIDE_HELP_TEXT_THIS_FRAME

```c
void HIDE_HELP_TEXT_THIS_FRAME()  // 0xD46923FC481CA285
```

build 323

## HIDE_HUD_AND_RADAR_THIS_FRAME

```c
void HIDE_HUD_AND_RADAR_THIS_FRAME()  // 0x719FF505F097FD20
```

build 323

> Hides HUD and radar this frame and prohibits switching to other weapons (or accessing the weapon wheel)

## HIDE_HUD_COMPONENT_THIS_FRAME

```c
void HIDE_HUD_COMPONENT_THIS_FRAME(int id)  // 0x6806C51AD12B83B8
```

build 323

> This function hides various HUD (Heads-up Display) components.
> Listed below are the integers and the corresponding HUD component.
> - 1 : WANTED_STARS
> - 2 : WEAPON_ICON
> - 3 : CASH
> - 4 : MP_CASH
> - 5 : MP_MESSAGE
> - 6 : VEHICLE_NAME
> - 7 : AREA_NAME
> - 8 : VEHICLE_CLASS
> - 9 : STREET_NAME
> - 10 : HELP_TEXT
> - 11 : FLOATING_HELP_TEXT_1
> - 12 : FLOATING_HELP_TEXT_2
> - 13 : CASH_CHANGE
> - 14 : RETICLE
> - 15 : SUBTITLE_TEXT
> - 16 : RADIO_STATIONS
> - 17 : SAVING_GAME
> - 18 : GAME_STREAM
> - 19 : WEAPON_WHEEL
> - 20 : WEAPON_WHEEL_STATS
> - 21 : HUD_COMPONENTS
> - 22 : HUD_WEAPONS
> 
> These integers also work for the `SHOW_HUD_COMPONENT_THIS_FRAME` native, but instead shows the HUD Component.

## HIDE_HUDMARKERS_THIS_FRAME

```c
void HIDE_HUDMARKERS_THIS_FRAME()  // 0x243296A510B562B6
```

build 2060

## HIDE_LOADING_ON_FADE_THIS_FRAME

```c
void HIDE_LOADING_ON_FADE_THIS_FRAME()  // 0x4B0311D3CDC4648F
```

build 323

## HIDE_MINIMAP_EXTERIOR_MAP_THIS_FRAME

```c
void HIDE_MINIMAP_EXTERIOR_MAP_THIS_FRAME()  // 0x5FBAE526203990C9
```

build 323 · old names: `_DISABLE_RADAR_THIS_FRAME`

## HIDE_MINIMAP_INTERIOR_MAP_THIS_FRAME

```c
void HIDE_MINIMAP_INTERIOR_MAP_THIS_FRAME()  // 0x20FE7FDFEEAD38C0
```

build 323

## HIDE_NUMBER_ON_BLIP

```c
void HIDE_NUMBER_ON_BLIP(Blip blip)  // 0x532CFF637EF80148
```

build 323

## HIDE_SCRIPTED_HUD_COMPONENT_THIS_FRAME

```c
void HIDE_SCRIPTED_HUD_COMPONENT_THIS_FRAME(int id)  // 0xE374C498D8BADC14
```

build 323

## HIDE_STREET_AND_CAR_NAMES_THIS_FRAME

```c
void HIDE_STREET_AND_CAR_NAMES_THIS_FRAME()  // 0xA4DEDE28B1814289
```

build 323 · old names: `_HIDE_AREA_AND_VEHICLE_NAME_THIS_FRAME`

> Hides area and vehicle name HUD components for one frame.

## HUD_FORCE_SPECIAL_VEHICLE_WEAPON_WHEEL

```c
void HUD_FORCE_SPECIAL_VEHICLE_WEAPON_WHEEL()  // 0x488043841BBE156F
```

build 1011 · old names: `_HUD_DISPLAY_LOADING_SCREEN_TIPS`

> Displays "blazer_wheels_up" and "blazer_wheels_down" "weapon" icons when switching between jetski and quadbike modes. Works only on vehicles using "VEHICLE_TYPE_AMPHIBIOUS_QUADBIKE" vehicle type. Needs to be called every time prior to switching modes, otherwise the icon will only appear when switching modes once.

## HUD_FORCE_WEAPON_WHEEL

```c
void HUD_FORCE_WEAPON_WHEEL(BOOL show)  // 0xEB354E5376BC81A7
```

build 323 · old names: `_SHOW_WEAPON_WHEEL`

> Forces the weapon wheel to show/hide.

## HUD_GET_WEAPON_WHEEL_CURRENTLY_HIGHLIGHTED

```c
Hash HUD_GET_WEAPON_WHEEL_CURRENTLY_HIGHLIGHTED()  // 0xA48931185F0536FE
```

build 323 · old names: `_HUD_WEAPON_WHEEL_GET_SELECTED_HASH`

> Returns the weapon hash to the selected/highlighted weapon in the wheel

## HUD_GET_WEAPON_WHEEL_TOP_SLOT

```c
Hash HUD_GET_WEAPON_WHEEL_TOP_SLOT(int weaponTypeIndex)  // 0xA13E93403F26C812
```

build 323 · old names: `_HUD_WEAPON_WHEEL_GET_SLOT_HASH`

> Returns the weapon hash active in a specific weapon wheel slotList

## HUD_SET_WEAPON_WHEEL_TOP_SLOT

```c
void HUD_SET_WEAPON_WHEEL_TOP_SLOT(Hash weaponHash)  // 0x72C1056D678BB7D8
```

build 323 · old names: `_HUD_WEAPON_WHEEL_SET_SLOT_HASH`

> Set the active slotIndex in the wheel weapon to the slot associated with the provided Weapon hash

## HUD_SHOWING_CHARACTER_SWITCH_SELECTION

```c
void HUD_SHOWING_CHARACTER_SWITCH_SELECTION(BOOL toggle)  // 0x14C9FDCC41F81F63
```

build 323 · old names: `_HUD_WEAPON_WHEEL_IGNORE_CONTROL_INPUT`

> Sets a global that disables many weapon input tasks (shooting, aiming, etc.). Does not work with vehicle weapons, only used in selector.ysc

## HUD_SUPPRESS_WEAPON_WHEEL_RESULTS_THIS_FRAME

```c
void HUD_SUPPRESS_WEAPON_WHEEL_RESULTS_THIS_FRAME()  // 0x0AFC4AF510774B47
```

build 323 · old names: `_BLOCK_WEAPON_WHEEL_THIS_FRAME`, `_HUD_WEAPON_WHEEL_IGNORE_SELECTION`

> Calling this each frame, stops the player from receiving a weapon via the weapon wheel.

## IS_BLIP_FLASHING

```c
BOOL IS_BLIP_FLASHING(Blip blip)  // 0xA5E41FD83AD6CEF0
```

build 323

## IS_BLIP_ON_MINIMAP

```c
BOOL IS_BLIP_ON_MINIMAP(Blip blip)  // 0xE41CA53051197A27
```

build 323

## IS_BLIP_SHORT_RANGE

```c
BOOL IS_BLIP_SHORT_RANGE(Blip blip)  // 0xDA5F8727EB75B926
```

build 323

## IS_FLOATING_HELP_TEXT_ON_SCREEN

```c
BOOL IS_FLOATING_HELP_TEXT_ON_SCREEN(int hudIndex)  // 0x2432784ACA090DA4
```

build 323

## IS_FRONTEND_READY_FOR_CONTROL

```c
BOOL IS_FRONTEND_READY_FOR_CONTROL()  // 0x3BAB9A4E4F2FF5C7
```

build 323

## IS_HELP_MESSAGE_BEING_DISPLAYED

```c
BOOL IS_HELP_MESSAGE_BEING_DISPLAYED()  // 0x4D79439A6B55AC67
```

build 323

## IS_HELP_MESSAGE_FADING_OUT

```c
BOOL IS_HELP_MESSAGE_FADING_OUT()  // 0x327EDEEEAC55C369
```

build 323

## IS_HELP_MESSAGE_ON_SCREEN

```c
BOOL IS_HELP_MESSAGE_ON_SCREEN()  // 0xDAD37F45428801AE
```

build 323

## IS_HOVERING_OVER_MISSION_CREATOR_BLIP

```c
BOOL IS_HOVERING_OVER_MISSION_CREATOR_BLIP()  // 0x4167EFE0527D706E
```

build 323

## IS_HUD_COMPONENT_ACTIVE

```c
BOOL IS_HUD_COMPONENT_ACTIVE(int id)  // 0xBC4C9EA5391ECC0D
```

build 323

> Full list of components below
> 
> HUD = 0;
> HUD_WANTED_STARS = 1;
> HUD_WEAPON_ICON = 2;
> HUD_CASH = 3;
> HUD_MP_CASH = 4;
> HUD_MP_MESSAGE = 5;
> HUD_VEHICLE_NAME = 6;
> HUD_AREA_NAME = 7;
> HUD_VEHICLE_CLASS = 8;
> HUD_STREET_NAME = 9;
> HUD_HELP_TEXT = 10;
> HUD_FLOATING_HELP_TEXT_1 = 11;
> HUD_FLOATING_HELP_TEXT_2 = 12;
> HUD_CASH_CHANGE = 13;
> HUD_RETICLE = 14;
> HUD_SUBTITLE_TEXT = 15;
> HUD_RADIO_STATIONS = 16;
> HUD_SAVING_GAME = 17;
> HUD_GAME_STREAM = 18;
> HUD_WEAPON_WHEEL = 19;
> HUD_WEAPON_WHEEL_STATS = 20;
> MAX_HUD_COMPONENTS = 21;
> MAX_HUD_WEAPONS = 22;
> MAX_SCRIPTED_HUD_COMPONENTS = 141;

## IS_HUD_COMPONENT_HIDDEN_THIS_FRAME

```c
BOOL IS_HUD_COMPONENT_HIDDEN_THIS_FRAME(int id)  // 0x8EDC335C943465C8
```

build 3717

## IS_HUD_HIDDEN

```c
BOOL IS_HUD_HIDDEN()  // 0xA86478C6958735C5
```

build 323

## IS_HUD_PREFERENCE_SWITCHED_ON

```c
BOOL IS_HUD_PREFERENCE_SWITCHED_ON()  // 0x1930DFA731813EC4
```

build 323

## IS_IME_IN_PROGRESS

```c
BOOL IS_IME_IN_PROGRESS()  // 0x801879A9B4F4B2FB
```

build 372

## IS_MESSAGE_BEING_DISPLAYED

```c
BOOL IS_MESSAGE_BEING_DISPLAYED()  // 0x7984C03AA5CC2F41
```

build 323

## IS_MINIMAP_RENDERING

```c
BOOL IS_MINIMAP_RENDERING()  // 0xAF754F20EB5CD51A
```

build 323 · old names: `_IS_RADAR_ENABLED`

## IS_MISSION_CREATOR_BLIP

```c
BOOL IS_MISSION_CREATOR_BLIP(Blip blip)  // 0x26F49BF3381D933D
```

build 323

## IS_MOUSE_ROLLED_OVER_INSTRUCTIONAL_BUTTONS

```c
BOOL IS_MOUSE_ROLLED_OVER_INSTRUCTIONAL_BUTTONS()  // 0x3D9ACB1EB139E702
```

build 323 · old names: `_IS_MOUSE_CURSOR_ABOVE_INSTRUCTIONAL_BUTTONS`

> Returns TRUE if mouse is hovering above instructional buttons. Works with all buttons gfx, such as popup_warning, pause_menu_instructional_buttons, instructional_buttons, etc. Note: You have to call TOGGLE_MOUSE_BUTTONS on the scaleform if you want this native to work.

## IS_MP_GAMER_TAG_ACTIVE

```c
BOOL IS_MP_GAMER_TAG_ACTIVE(int gamerTagId)  // 0x4E929E7A5796FD26
```

build 323

## IS_MP_GAMER_TAG_FREE

```c
BOOL IS_MP_GAMER_TAG_FREE(int gamerTagId)  // 0x595B5178E412E199
```

build 323 · old names: `ADD_TREVOR_RANDOM_MODIFIER`

## IS_MP_GAMER_TAG_MOVIE_ACTIVE

```c
BOOL IS_MP_GAMER_TAG_MOVIE_ACTIVE()  // 0x6E0EB3EB47C8D7AA
```

build 323 · old names: `_HAS_MP_GAMER_TAG`

## IS_MP_TEXT_CHAT_TYPING

```c
BOOL IS_MP_TEXT_CHAT_TYPING()  // 0xB118AF58B5F332A1
```

build 323 · old names: `_IS_TEXT_CHAT_ACTIVE`, `_IS_MULTIPLAYER_CHAT_ACTIVE`

> Returns whether or not the text chat (MULTIPLAYER_CHAT Scaleform component) is active.

## IS_NAMED_RENDERTARGET_LINKED

```c
BOOL IS_NAMED_RENDERTARGET_LINKED(Hash modelHash)  // 0x113750538FA31298
```

build 323

## IS_NAMED_RENDERTARGET_REGISTERED

```c
BOOL IS_NAMED_RENDERTARGET_REGISTERED(const char* name)  // 0x78DCDC15C9F116B4
```

build 323

## IS_NAVIGATING_MENU_CONTENT

```c
BOOL IS_NAVIGATING_MENU_CONTENT()  // 0x4E3CD0EF8A489541
```

build 323

## IS_ONLINE_POLICIES_MENU_ACTIVE

```c
BOOL IS_ONLINE_POLICIES_MENU_ACTIVE()  // 0x6F72CD94F7B5B68C
```

build 323

> Returns the same as IS_SOCIAL_CLUB_ACTIVE

## IS_PAUSE_MENU_ACTIVE

```c
BOOL IS_PAUSE_MENU_ACTIVE()  // 0xB0034A223497FFCB
```

build 323

## IS_PAUSE_MENU_RESTARTING

```c
BOOL IS_PAUSE_MENU_RESTARTING()  // 0x1C491717107431C7
```

build 323

## IS_PAUSEMAP_IN_INTERIOR_MODE

```c
BOOL IS_PAUSEMAP_IN_INTERIOR_MODE()  // 0x9049FE339D5F6F6F
```

build 323 · old names: `_IS_MINIMAP_IN_INTERIOR`

## IS_RADAR_HIDDEN

```c
BOOL IS_RADAR_HIDDEN()  // 0x157F93B036700462
```

build 323

## IS_RADAR_PREFERENCE_SWITCHED_ON

```c
BOOL IS_RADAR_PREFERENCE_SWITCHED_ON()  // 0x9EB6522EA68F22FE
```

build 323

## IS_REPORTUGC_MENU_OPEN

```c
BOOL IS_REPORTUGC_MENU_OPEN()  // 0x9135584D09A3437E
```

build 323

## IS_SCRIPTED_HUD_COMPONENT_ACTIVE

```c
BOOL IS_SCRIPTED_HUD_COMPONENT_ACTIVE(int id)  // 0xDD100EB17A94FF65
```

build 323

## IS_SCRIPTED_HUD_COMPONENT_HIDDEN_THIS_FRAME

```c
BOOL IS_SCRIPTED_HUD_COMPONENT_HIDDEN_THIS_FRAME(int id)  // 0x09C0403ED9A751C2
```

build 323

## IS_SOCIAL_CLUB_ACTIVE

```c
BOOL IS_SOCIAL_CLUB_ACTIVE()  // 0xC406BE343FC4B9AF
```

build 323

## IS_STORE_PENDING_NETWORK_SHUTDOWN_TO_OPEN

```c
BOOL IS_STORE_PENDING_NETWORK_SHUTDOWN_TO_OPEN()  // 0x2F057596F2BD0061
```

build 323

## IS_STREAMING_ADDITIONAL_TEXT

```c
BOOL IS_STREAMING_ADDITIONAL_TEXT(int p0)  // 0x8B6817B71B85EBF0
```

build 323

## IS_SUBTITLE_PREFERENCE_SWITCHED_ON

```c
BOOL IS_SUBTITLE_PREFERENCE_SWITCHED_ON()  // 0xAD6DACA4BA53E0A4
```

build 323

## IS_UPDATING_MP_GAMER_TAG_NAME_AND_CREW_DETAILS

```c
BOOL IS_UPDATING_MP_GAMER_TAG_NAME_AND_CREW_DETAILS(int gamerTagId)  // 0xEB709A36958ABE0D
```

build 323 · old names: `_HAS_MP_GAMER_TAG_2`, `_HAS_MP_GAMER_TAG_CREW_FLAGS_SET`, `_IS_VALID_MP_GAMER_TAG_MOVIE`

## IS_WARNING_MESSAGE_ACTIVE

```c
BOOL IS_WARNING_MESSAGE_ACTIVE()  // 0xE18B138FABC53103
```

build 323 · old names: `IS_MEDICAL_DISABLED`

## IS_WARNING_MESSAGE_READY_FOR_CONTROL

```c
BOOL IS_WARNING_MESSAGE_READY_FOR_CONTROL()  // 0xAF42195A42C63BBA
```

build 323 · old names: `_IS_WARNING_MESSAGE_ACTIVE_2`

## IS_WAYPOINT_ACTIVE

```c
BOOL IS_WAYPOINT_ACTIVE()  // 0x1DD1F58F493F1DA5
```

build 323

## LINK_NAMED_RENDERTARGET

```c
void LINK_NAMED_RENDERTARGET(Hash modelHash)  // 0xF6C09E276AEB3F2D
```

build 323

## LOCK_MINIMAP_ANGLE

```c
void LOCK_MINIMAP_ANGLE(int angle)  // 0x299FAEBB108AE05B
```

build 323

> Locks the minimap to the specified angle in integer degrees.
> 
> angle: The angle in whole degrees. If less than 0 or greater than 360, unlocks the angle.

## LOCK_MINIMAP_POSITION

```c
void LOCK_MINIMAP_POSITION(float x, float y)  // 0x1279E861A329E73F
```

build 323

> Locks the minimap to the specified world position.

## MP_TEXT_CHAT_DISABLE

```c
void MP_TEXT_CHAT_DISABLE(BOOL toggle)  // 0x1DB21A44B09E8BA3
```

build 323 · old names: `_SET_TEXT_CHAT_UNK`, `_MULTIPLAYER_CHAT_SET_DISABLED`

> Hides the chat history, closes the input box and makes it unable to be opened unless called again with FALSE.

## MP_TEXT_CHAT_IS_TEAM_JOB

```c
void MP_TEXT_CHAT_IS_TEAM_JOB(Any p0)  // 0x7C226D5346D4D10A
```

build 372

## OPEN_ONLINE_POLICIES_MENU

```c
void OPEN_ONLINE_POLICIES_MENU()  // 0x805D7CBB36FD6C4C
```

build 323 · old names: `_SHOW_SOCIAL_CLUB_LEGAL_SCREEN`

## OPEN_REPORTUGC_MENU

```c
void OPEN_REPORTUGC_MENU()  // 0x523A590C1A3CC0D3
```

build 323 · old names: `_DISPLAY_JOB_REPORT`

> Shows a menu for reporting UGC content.

## OPEN_SOCIAL_CLUB_MENU

```c
void OPEN_SOCIAL_CLUB_MENU(Hash menu)  // 0x75D3691713C3B05A
```

build 323

> Uses the `SOCIAL_CLUB2` scaleform.
> menu: GALLERY, MISSIONS, CREWS, MIGRATE, PLAYLISTS, JOBS

## OVERRIDE_MP_TEXT_CHAT_COLOR

```c
void OVERRIDE_MP_TEXT_CHAT_COLOR(int p0, int hudColor)  // 0xF47E567B3630DD12
```

build 678 · old names: `_OVERRIDE_MULTIPLAYER_CHAT_COLOUR`

## OVERRIDE_MP_TEXT_CHAT_TEAM_STRING

```c
void OVERRIDE_MP_TEXT_CHAT_TEAM_STRING(Hash gxtEntryHash)  // 0x6A1738B4323FE2D9
```

build 573 · old names: `_OVERRIDE_MULTIPLAYER_CHAT_PREFIX`

## PAUSE_MENU_ACTIVATE_CONTEXT

```c
void PAUSE_MENU_ACTIVATE_CONTEXT(Hash contextHash)  // 0xDD564BDD0472C936
```

build 323 · old names: `_ADD_FRONTEND_MENU_CONTEXT`

> Activates the specified frontend menu context.
> pausemenu.xml defines some specific menu options using 'context'. Context is basically a 'condition'. 
> The `*ALL*` part of the context means that whatever is being defined, will be active when any or all of those conditions after `*ALL*` are met.
> The `*NONE*` part of the context section means that whatever is being defined, will NOT be active if any or all of the conditions after `*NONE*` are met.
> This basically allows you to hide certain menu sections, or things like instructional buttons.

## PAUSE_MENU_DEACTIVATE_CONTEXT

```c
void PAUSE_MENU_DEACTIVATE_CONTEXT(Hash contextHash)  // 0x444D8CF241EC25C5
```

build 323 · old names: `OBJECT_DECAL_TOGGLE`

## PAUSE_MENU_GET_HAIR_COLOUR_INDEX

```c
int PAUSE_MENU_GET_HAIR_COLOUR_INDEX()  // 0xDE03620F8703A9DF
```

build 323

## PAUSE_MENU_GET_MOUSE_CLICK_EVENT

```c
BOOL PAUSE_MENU_GET_MOUSE_CLICK_EVENT(Any* p0, Any* p1, Any* p2)  // 0xC8E1071177A23BE5
```

build 323

## PAUSE_MENU_GET_MOUSE_HOVER_INDEX

```c
int PAUSE_MENU_GET_MOUSE_HOVER_INDEX()  // 0x359AF31A4B52F5ED
```

build 323

## PAUSE_MENU_GET_MOUSE_HOVER_UNIQUE_ID

```c
int PAUSE_MENU_GET_MOUSE_HOVER_UNIQUE_ID()  // 0x13C4B962653A5280
```

build 323

## PAUSE_MENU_IS_CONTEXT_ACTIVE

```c
BOOL PAUSE_MENU_IS_CONTEXT_ACTIVE(Hash contextHash)  // 0x84698AB38D0C6636
```

build 323

## PAUSE_MENU_IS_CONTEXT_MENU_ACTIVE

```c
BOOL PAUSE_MENU_IS_CONTEXT_MENU_ACTIVE()  // 0x2A25ADC48F87841F
```

build 323

## PAUSE_MENU_REDRAW_INSTRUCTIONAL_BUTTONS

```c
void PAUSE_MENU_REDRAW_INSTRUCTIONAL_BUTTONS(int p0)  // 0x4895BDEA16E7C080
```

build 323 · old names: `ENABLE_DEATHBLOOD_SEETHROUGH`

## PAUSE_MENU_SET_BUSY_SPINNER

```c
void PAUSE_MENU_SET_BUSY_SPINNER(BOOL p0, int position, int spinnerIndex)  // 0xC78E239AC5B2DDB9
```

build 323

## PAUSE_MENU_SET_WARN_ON_TAB_CHANGE

```c
void PAUSE_MENU_SET_WARN_ON_TAB_CHANGE(BOOL p0)  // 0xF06EBB91A81E09E3
```

build 323

## PAUSE_MENUCEPTION_GO_DEEPER

```c
void PAUSE_MENUCEPTION_GO_DEEPER(int page)  // 0x77F16B447824DA6C
```

build 323

## PAUSE_MENUCEPTION_THE_KICK

```c
void PAUSE_MENUCEPTION_THE_KICK()  // 0xCDCA26E80FAECB8F
```

build 323

## PAUSE_TOGGLE_FULLSCREEN_MAP

```c
void PAUSE_TOGGLE_FULLSCREEN_MAP(Any p0)  // 0x2DE6C5E2E996F178
```

build 372

## PRELOAD_BUSYSPINNER

```c
void PRELOAD_BUSYSPINNER()  // 0xC65AB383CD91DF98
```

build 323

## PULSE_BLIP

```c
void PULSE_BLIP(Blip blip)  // 0x742D6FD43115AF73
```

build 323

## REFRESH_WAYPOINT

```c
void REFRESH_WAYPOINT()  // 0x81FA173F170560D1
```

build 323

## REGISTER_NAMED_RENDERTARGET

```c
BOOL REGISTER_NAMED_RENDERTARGET(const char* name, BOOL p1)  // 0x57D9C12635E25CE3
```

build 323

## RELEASE_CONTROL_OF_FRONTEND

```c
void RELEASE_CONTROL_OF_FRONTEND()  // 0x14621BB1DF14E2B2
```

build 323

> Enables frontend (works in custom frontends, not sure about regular pause menu) navigation keys on keyboard if they were disabled using the native below.
> To disable the keys, use `0xEC9264727EEC0F28`

## RELEASE_NAMED_RENDERTARGET

```c
BOOL RELEASE_NAMED_RENDERTARGET(const char* name)  // 0xE9F6FFE837354DD4
```

build 323

## RELOAD_MAP_MENU

```c
void RELOAD_MAP_MENU()  // 0x2916A928514C9827
```

build 573

## REMOVE_BLIP

```c
void REMOVE_BLIP(Blip* blip)  // 0x86A652570E5F25DD
```

build 323

> In the C++ SDK, this seems not to work-- the blip isn't removed immediately. I use it for saving cars.
> 
> E.g.:
> 
> Ped pped = PLAYER::PLAYER_PED_ID();
> Vehicle v = PED::GET_VEHICLE_PED_IS_USING(pped);
> Blip b = HUD::ADD_BLIP_FOR_ENTITY(v);
> 
> works fine.
> But later attempting to delete it with:
> 
> Blip b = HUD::GET_BLIP_FROM_ENTITY(v);
> if (HUD::DOES_BLIP_EXIST(b)) HUD::REMOVE_BLIP(&b);
> 
> doesn't work. And yes, doesn't work without the DOES_BLIP_EXIST check either. Also, if you attach multiple blips to the same thing (say, a vehicle), and that thing disappears, the blips randomly attach to other things (in my case, a vehicle).
> 
> Thus for me, HUD::REMOVE_BLIP(&b) only works if there's one blip, (in my case) the vehicle is marked as no longer needed, you drive away from it and it eventually despawns, AND there is only one blip attached to it. I never intentionally attach multiple blips but if the user saves the car, this adds a blip. Then if they delete it, it is supposed to remove the blip, but it doesn't. Then they can immediately save it again, causing another blip to re-appear.
> -------------
> 
> Passing the address of the variable instead of the value works for me.
> e.g.
> int blip = HUD::ADD_BLIP_FOR_ENTITY(ped);
> HUD::REMOVE_BLIP(&blip);
> 
> 
> Remove blip will currently crash your game, just artificially remove the blip by setting the sprite to a id that is 'invisible'.

## REMOVE_COP_BLIP_FROM_PED

```c
void REMOVE_COP_BLIP_FROM_PED(Ped ped)  // 0xC594B315EDF2D4AF
```

build 323

> Interesting fact: A hash collision for this is RESET_JETPACK_MODEL_SETTINGS

## REMOVE_FAKE_CONE_DATA

```c
void REMOVE_FAKE_CONE_DATA(Blip blip)  // 0x35A3CD97B2C0A6D2
```

build 1290

## REMOVE_MP_GAMER_TAG

```c
void REMOVE_MP_GAMER_TAG(int gamerTagId)  // 0x31698AA80E0223F8
```

build 323

## REMOVE_MULTIPLAYER_BANK_CASH

```c
void REMOVE_MULTIPLAYER_BANK_CASH()  // 0xC7C6789AA1CFEDD0
```

build 323

## REMOVE_MULTIPLAYER_HUD_CASH

```c
void REMOVE_MULTIPLAYER_HUD_CASH()  // 0x968F270E39141ECA
```

build 323

> Removes multiplayer cash hud each frame

## REMOVE_MULTIPLAYER_WALLET_CASH

```c
void REMOVE_MULTIPLAYER_WALLET_CASH()  // 0x95CF81BD06EE1887
```

build 323

## REMOVE_WARNING_MESSAGE_OPTION_ITEMS

```c
void REMOVE_WARNING_MESSAGE_OPTION_ITEMS()  // 0x6EF54AB721DC6242
```

build 323 · old names: `_REMOVE_WARNING_MESSAGE_LIST_ITEMS`

## REPLACE_HUD_COLOUR

```c
void REPLACE_HUD_COLOUR(int hudColorIndex, int hudColorIndex2)  // 0x1CCC708F0F850613
```

build 323 · old names: `_SET_HUD_COLOURS_SWITCH`

> makes hudColorIndex2 color into hudColorIndex color

## REPLACE_HUD_COLOUR_WITH_RGBA

```c
void REPLACE_HUD_COLOUR_WITH_RGBA(int hudColorIndex, int r, int g, int b, int a)  // 0xF314CF4F0211894E
```

build 323 · old names: `_SET_HUD_COLOUR`

## REQUEST_ADDITIONAL_TEXT

```c
void REQUEST_ADDITIONAL_TEXT(const char* gxt, int slot)  // 0x71A78003C8E71424
```

build 323

> Request a gxt into the passed slot.

## REQUEST_ADDITIONAL_TEXT_FOR_DLC

```c
void REQUEST_ADDITIONAL_TEXT_FOR_DLC(const char* gxt, int slot)  // 0x6009F9F1AE90D8A6
```

build 323 · old names: `_REQUEST_ADDITIONAL_TEXT_2`

## RESET_GLOBAL_ACTIONSCRIPT_FLAG

```c
void RESET_GLOBAL_ACTIONSCRIPT_FLAG(int flagIndex)  // 0xB99C4E4D9499DF29
```

build 323

## RESET_HUD_COMPONENT_VALUES

```c
void RESET_HUD_COMPONENT_VALUES(int id)  // 0x450930E616475D0D
```

build 323

## RESET_RETICULE_VALUES

```c
void RESET_RETICULE_VALUES()  // 0x12782CE0A636E9F0
```

build 323

## RESTART_FRONTEND_MENU

```c
void RESTART_FRONTEND_MENU(Hash menuHash, int p1)  // 0x10706DC6AD2D49C0
```

build 323

> Before using this native click the native above and look at the decription.
> 
> Example:
> int GetHash = Function.Call<int>(Hash.GET_HASH_KEY, "fe_menu_version_corona_lobby");
> Function.Call(Hash.ACTIVATE_FRONTEND_MENU, GetHash, 0, -1);
> Function.Call(Hash.RESTART_FRONTEND_MENU(GetHash, -1);
> 
> This native refreshes the frontend menu.
> 
> p1 = Hash of Menu
> p2 = Unknown but always works with -1.

## SET_ABILITY_BAR_VALUE

```c
void SET_ABILITY_BAR_VALUE(float p0, float p1)  // 0x9969599CCFF5D85E
```

build 323

## SET_ABILITY_BAR_VISIBILITY

```c
void SET_ABILITY_BAR_VISIBILITY(BOOL visible)  // 0x1DFEDD15019315A9
```

build 1493 · old names: `_SET_ABILITY_BAR_VISIBILITY_IN_MULTIPLAYER`

## SET_ALL_MP_GAMER_TAGS_VISIBILITY

```c
void SET_ALL_MP_GAMER_TAGS_VISIBILITY(int gamerTagId, BOOL toggle)  // 0xEE76FF7E6A0166B0
```

build 323 · old names: `_SET_MP_GAMER_TAG_`, `_SET_MP_GAMER_TAG`, `_SET_MP_GAMER_TAG_ENABLED`

## SET_ALLOW_ABILITY_BAR

```c
void SET_ALLOW_ABILITY_BAR(BOOL toggle)  // 0x889329C80FE5963C
```

build 1868 · old names: `_SET_ALLOW_ABILITY_BAR_IN_MULTIPLAYER`

## SET_ALLOW_COMMA_ON_TEXT_INPUT

```c
void SET_ALLOW_COMMA_ON_TEXT_INPUT(Any p0)  // 0x577599CCED639CA2
```

build 505

## SET_BIGMAP_ACTIVE

```c
void SET_BIGMAP_ACTIVE(BOOL toggleBigMap, BOOL showFullMap)  // 0x231C8F89D0539D8F
```

build 323 · old names: `_SET_RADAR_BIGMAP_ENABLED`

> Toggles the big minimap state like in GTA:Online.

## SET_BLIP_ALPHA

```c
void SET_BLIP_ALPHA(Blip blip, int alpha)  // 0x45FF974EEE1C8734
```

build 323

> Sets alpha-channel for blip color.
> 
> Example:
> 
> Blip blip = HUD::ADD_BLIP_FOR_ENTITY(entity);
> HUD::SET_BLIP_COLOUR(blip , 3);
> HUD::SET_BLIP_ALPHA(blip , 64);
> 

## SET_BLIP_AS_FRIENDLY

```c
void SET_BLIP_AS_FRIENDLY(Blip blip, BOOL toggle)  // 0x6F6F290102C02AB4
```

build 323

> false for enemy
> true for friendly

## SET_BLIP_AS_MINIMAL_ON_EDGE

```c
void SET_BLIP_AS_MINIMAL_ON_EDGE(Blip blip, BOOL toggle)  // 0x2B6D467DAB714E8D
```

build 323 · old names: `_SET_BLIP_SHRINK`

> Makes a blip go small when off the minimap.

## SET_BLIP_AS_MISSION_CREATOR_BLIP

```c
void SET_BLIP_AS_MISSION_CREATOR_BLIP(Blip blip, BOOL toggle)  // 0x24AC0137444F9FD5
```

build 323

## SET_BLIP_AS_SHORT_RANGE

```c
void SET_BLIP_AS_SHORT_RANGE(Blip blip, BOOL toggle)  // 0xBE8BE4FE60E27B72
```

build 323

> Sets whether or not the specified blip should only be displayed when nearby, or on the minimap.

## SET_BLIP_BRIGHT

```c
void SET_BLIP_BRIGHT(Blip blip, BOOL toggle)  // 0xB203913733F27884
```

build 323

## SET_BLIP_CATEGORY

```c
void SET_BLIP_CATEGORY(Blip blip, int index)  // 0x234CDD44D996FD9A
```

build 323

> Index:
> 1 = No distance shown in legend
> 2 = Distance shown in legend
> 7 = "Other Players" category, also shows distance in legend
> 10 = "Property" category
> 11 = "Owned Property" category
> 
> Any other value behaves like index = 1, index wraps around after 255
> Blips with categories 7, 10 or 11 will all show under the specific categories listing in the map legend, regardless of sprite or name.
> Legend entries:
> 7 = Other Players (BLIP_OTHPLYR)
> 10 = Property (BLIP_PROPCAT)
> 11 = Owned Property (BLIP_APARTCAT)
> 
> Category needs to be `7` in order for blip names to show on the expanded minimap when using DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS.

## SET_BLIP_COLOUR

```c
void SET_BLIP_COLOUR(Blip blip, int color)  // 0x03D7FB09E75D6B7E
```

build 323

> https://gtaforums.com/topic/864881-all-blip-color-ids-pictured/

## SET_BLIP_COORDS

```c
void SET_BLIP_COORDS(Blip blip, float posX, float posY, float posZ)  // 0xAE2AF67E9D9AF65D
```

build 323

## SET_BLIP_DISPLAY

```c
void SET_BLIP_DISPLAY(Blip blip, int displayId)  // 0x9029B2F3DA924928
```

build 323

> Display Id behaviours:
> 0 = Doesn't show up, ever, anywhere.
> 1 = Doesn't show up, ever, anywhere.
> 2 = Shows on both main map and minimap. (Selectable on map)
> 3 = Shows on main map only. (Selectable on map)
> 4 = Shows on main map only. (Selectable on map)
> 5 = Shows on minimap only.
> 6 = Shows on both main map and minimap. (Selectable on map)
> 7 = Doesn't show up, ever, anywhere.
> 8 = Shows on both main map and minimap. (Not selectable on map)
> 9 = Shows on minimap only.
> 10 = Shows on both main map and minimap. (Not selectable on map)
> 
> Anything higher than 10 seems to be exactly the same as 10.

## SET_BLIP_EXTENDED_HEIGHT_THRESHOLD

```c
void SET_BLIP_EXTENDED_HEIGHT_THRESHOLD(Blip blip, BOOL toggle)  // 0xC4278F70131BAA6D
```

build 323 · old names: `_SET_BLIP_DISPLAY_INDICATOR_ON_BLIP`

> Must be toggled before being queued for animation

## SET_BLIP_FADE

```c
void SET_BLIP_FADE(Blip blip, int opacity, int duration)  // 0x2AEE8F8390D2298C
```

build 323

## SET_BLIP_FLASH_INTERVAL

```c
void SET_BLIP_FLASH_INTERVAL(Blip blip, Any p1)  // 0xAA51DB313C010A7E
```

build 323

## SET_BLIP_FLASH_TIMER

```c
void SET_BLIP_FLASH_TIMER(Blip blip, int duration)  // 0xD3CD6FD297AE87CC
```

build 323

> Adds up after viewing multiple R* scripts. I believe that the duration is in miliseconds.

## SET_BLIP_FLASHES

```c
void SET_BLIP_FLASHES(Blip blip, BOOL toggle)  // 0xB14552383D39CE3E
```

build 323

## SET_BLIP_FLASHES_ALTERNATE

```c
void SET_BLIP_FLASHES_ALTERNATE(Blip blip, BOOL toggle)  // 0x2E8D9498C56DD0D1
```

build 323

## SET_BLIP_HIDDEN_ON_LEGEND

```c
void SET_BLIP_HIDDEN_ON_LEGEND(Blip blip, BOOL toggle)  // 0x54318C915D27E4CE
```

build 323

## SET_BLIP_HIGH_DETAIL

```c
void SET_BLIP_HIGH_DETAIL(Blip blip, BOOL toggle)  // 0xE2590BC29220CEBB
```

build 323

## SET_BLIP_MARKER_LONG_DISTANCE

```c
void SET_BLIP_MARKER_LONG_DISTANCE(Any p0, Any p1)  // 0xB552929B85FC27EC
```

build 573

## SET_BLIP_NAME_FROM_TEXT_FILE

```c
void SET_BLIP_NAME_FROM_TEXT_FILE(Blip blip, const char* gxtEntry)  // 0xEAA0FFE120D92784
```

build 323

> Doesn't work if the label text of gxtEntry is >= 80.

## SET_BLIP_NAME_TO_PLAYER_NAME

```c
void SET_BLIP_NAME_TO_PLAYER_NAME(Blip blip, Player player)  // 0x127DE7B20C60A6A3
```

build 323

## SET_BLIP_PRIORITY

```c
void SET_BLIP_PRIORITY(Blip blip, int priority)  // 0xAE9FC9EF6A9FAC79
```

build 323

> See this topic for more details : https://gtaforums.com/topic/717612-v-scriptnative-documentation-and-research/page-35?p=1069477935

## SET_BLIP_ROTATION

```c
void SET_BLIP_ROTATION(Blip blip, int rotation)  // 0xF87683CDF73C3F6E
```

build 323

> After some testing, looks like you need to use CEIL() on the rotation (vehicle/ped heading) before using it there.

## SET_BLIP_ROTATION_WITH_FLOAT

```c
void SET_BLIP_ROTATION_WITH_FLOAT(Blip blip, float heading)  // 0xA8B6AFDAC320AC87
```

build 877 · old names: `_SET_BLIP_SQUARED_ROTATION`

> Does not require whole number/integer rotations.

## SET_BLIP_ROUTE

```c
void SET_BLIP_ROUTE(Blip blip, BOOL enabled)  // 0x4F7D8A9BFB0B43E9
```

build 323

> Enable / disable showing route for the Blip-object.

## SET_BLIP_ROUTE_COLOUR

```c
void SET_BLIP_ROUTE_COLOUR(Blip blip, int colour)  // 0x837155CD2F63DA09
```

build 323

## SET_BLIP_SCALE

```c
void SET_BLIP_SCALE(Blip blip, float scale)  // 0xD38744167B2FA257
```

build 323

## SET_BLIP_SCALE_2D

```c
void SET_BLIP_SCALE_2D(Blip blip, float xScale, float yScale)  // 0xCD6524439909C979
```

build 1734 · old names: `_SET_BLIP_SCALE_TRANSFORMATION`

> https://i.imgur.com/jH2JMUl.png

## SET_BLIP_SECONDARY_COLOUR

```c
void SET_BLIP_SECONDARY_COLOUR(Blip blip, int r, int g, int b)  // 0x14892474891E09EB
```

build 323

> Can be used to give blips any RGB colour with SET_BLIP_COLOUR(blip, 84).

## SET_BLIP_SHORT_HEIGHT_THRESHOLD

```c
void SET_BLIP_SHORT_HEIGHT_THRESHOLD(Any p0, Any p1)  // 0x4B5B620C9B59ED34
```

build 678

## SET_BLIP_SHOW_CONE

```c
void SET_BLIP_SHOW_CONE(Blip blip, BOOL toggle, int hudColorIndex)  // 0x13127EC3665E8EE1
```

build 323

> As of b2189, the third parameter sets the color of the cone (before b2189 it was ignored). Note that it uses HUD colors, not blip colors.

## SET_BLIP_SPRITE

```c
void SET_BLIP_SPRITE(Blip blip, int spriteId)  // 0xDF735600A4696DAF
```

build 323

> Sets the displayed sprite for a specific blip..
> 
> You may have your own list, but since dev-c didn't show it I was bored and started looking through scripts and functions to get a presumable almost positive list of a majority of blip IDs
> https://pastebin.com/Bpj9Sfft
> 
> Blips Images + IDs:
> https://gtaxscripting.blogspot.com/2016/05/gta-v-blips-id-and-image.html

## SET_BLIP_USE_HEIGHT_INDICATOR_ON_EDGE

```c
void SET_BLIP_USE_HEIGHT_INDICATOR_ON_EDGE(Blip blip, Any p1)  // 0x2C9F302398E13141
```

build 1103

## SET_BLOCK_WANTED_FLASH

```c
void SET_BLOCK_WANTED_FLASH(BOOL disabled)  // 0xD1942374085C8469
```

build 505

## SET_COLOUR_OF_NEXT_TEXT_COMPONENT

```c
void SET_COLOUR_OF_NEXT_TEXT_COMPONENT(int hudColor)  // 0x39BBF623FC803EAC
```

build 323 · old names: `_SET_NOTIFICATION_COLOR_NEXT`

## SET_COP_BLIP_SPRITE

```c
void SET_COP_BLIP_SPRITE(int p0, float p1)  // 0x9FCB3CBFB3EAD69A
```

build 1734

## SET_COP_BLIP_SPRITE_AS_STANDARD

```c
void SET_COP_BLIP_SPRITE_AS_STANDARD()  // 0xB7B873520C84C118
```

build 1734

## SET_CUSTOM_MP_HUD_COLOR

```c
void SET_CUSTOM_MP_HUD_COLOR(int hudColorId)  // 0x2ACCB195F3CCD9DE
```

build 2545 · old names: `_SET_CURRENT_CHARACTER_HUD_COLOR`

## SET_DESCRIPTION_FOR_UGC_MISSION_EIGHT_STRINGS

```c
void SET_DESCRIPTION_FOR_UGC_MISSION_EIGHT_STRINGS(BOOL p0, const char* p1, const char* p2, const char* p3, const char* p4, const char* p5, const char* p6, const char* p7, const char* p8)  // 0x817B86108EB94E51
```

build 323

## SET_DIRECTOR_MODE_AVAILABLE

```c
void SET_DIRECTOR_MODE_AVAILABLE(BOOL toggle)  // 0x04655F9D075D0AE5
```

build 323

## SET_DIRECTOR_MODE_LAUNCHED_BY_SCRIPT

```c
void SET_DIRECTOR_MODE_LAUNCHED_BY_SCRIPT()  // 0x2632482FD6B9AB87
```

build 323 · old names: `_SET_DIRECTOR_MODE_CLEAR_TRIGGERED_FLAG`

## SET_FAKE_GPS_PLAYER_POSITION_THIS_FRAME

```c
void SET_FAKE_GPS_PLAYER_POSITION_THIS_FRAME(float x, float y, float z)  // 0xA17784FCA9548D15
```

build 877

## SET_FAKE_MINIMAP_MAX_ALTIMETER_HEIGHT

```c
void SET_FAKE_MINIMAP_MAX_ALTIMETER_HEIGHT(float altitude, BOOL p1, Any p2)  // 0xD201F3FF917A506D
```

build 323 · old names: `_SET_MINIMAP_ATTITUDE_INDICATOR_LEVEL`, `_SET_MINIMAP_ALTITUDE_INDICATOR_LEVEL`

> Argument must be 0.0f or above 38.0f, or it will be ignored.

## SET_FAKE_PAUSEMAP_PLAYER_POSITION_THIS_FRAME

```c
void SET_FAKE_PAUSEMAP_PLAYER_POSITION_THIS_FRAME(float x, float y)  // 0x77E2DD177910E1CF
```

build 323 · old names: `_SET_PLAYER_BLIP_POSITION_THIS_FRAME`

> Sets the position of the arrow icon representing the player on both the minimap and world map.
> 
> Too bad this wouldn't work over the network (obviously not). Could spoof where we would be.

## SET_FAKE_SPECTATOR_MODE

```c
void SET_FAKE_SPECTATOR_MODE(BOOL toggle)  // 0xCD74233600C4EA6B
```

build 505

> Setter for GET_FAKE_SPECTATOR_MODE

## SET_FLOATING_HELP_TEXT_SCREEN_POSITION

```c
void SET_FLOATING_HELP_TEXT_SCREEN_POSITION(int hudIndex, float x, float y)  // 0x7679CC1BCEBE3D4C
```

build 323

## SET_FLOATING_HELP_TEXT_STYLE

```c
void SET_FLOATING_HELP_TEXT_STYLE(int hudIndex, int p1, int p2, int p3, int p4, int p5)  // 0x788E7FD431BD67F1
```

build 323

## SET_FLOATING_HELP_TEXT_TO_ENTITY

```c
void SET_FLOATING_HELP_TEXT_TO_ENTITY(int hudIndex, Entity entity, float offsetX, float offsetY)  // 0xB094BC1DB4018240
```

build 323

## SET_FLOATING_HELP_TEXT_WORLD_POSITION

```c
void SET_FLOATING_HELP_TEXT_WORLD_POSITION(int hudIndex, float x, float y, float z)  // 0x784BA7E0ECEB4178
```

build 323

## SET_FORCE_SHOW_GPS

```c
void SET_FORCE_SHOW_GPS(BOOL toggle)  // 0x2790F4B17D098E26
```

build 573 · old names: `_SET_FORCE_BLIP_ROUTES_ON_FOOT`

## SET_FRONTEND_ACTIVE

```c
void SET_FRONTEND_ACTIVE(BOOL active)  // 0x745711A75AB09277
```

build 323

## SET_GPS_CUSTOM_ROUTE_RENDER

```c
void SET_GPS_CUSTOM_ROUTE_RENDER(BOOL toggle, int radarThickness, int mapThickness)  // 0x900086F371220B6F
```

build 323

> radarThickness: The width of the GPS route on the radar
> mapThickness: The width of the GPS route on the map

## SET_GPS_FLAGS

```c
void SET_GPS_FLAGS(int p0, float p1)  // 0x5B440763A4C8D15B
```

build 323

> Only the script that originally called SET_GPS_FLAGS can set them again. Another script cannot set the flags, until the first script that called it has called CLEAR_GPS_FLAGS.
> 
> Doesn't seem like the flags are actually read by the game at all.

## SET_GPS_FLASHES

```c
void SET_GPS_FLASHES(BOOL toggle)  // 0x320D0E0D936A0E9B
```

build 323

## SET_GPS_MULTI_ROUTE_RENDER

```c
void SET_GPS_MULTI_ROUTE_RENDER(BOOL toggle)  // 0x3DDA37128DD1ACA8
```

build 323

## SET_HEALTH_HUD_DISPLAY_VALUES

```c
void SET_HEALTH_HUD_DISPLAY_VALUES(int health, int capacity, BOOL wasAdded)  // 0x3F5CC444DCAAA8F2
```

build 323

## SET_HELP_MESSAGE_STYLE

```c
void SET_HELP_MESSAGE_STYLE(int style, int hudColor, int alpha, int p3, int p4)  // 0xB9C362BABECDDC7A
```

build 463 · old names: `_SET_HELP_MESSAGE_TEXT_STYLE`

## SET_HUD_COMPONENT_POSITION

```c
void SET_HUD_COMPONENT_POSITION(int id, float x, float y)  // 0xAABB1F56E2A17CED
```

build 323

## SET_INSIDE_VERY_LARGE_INTERIOR

```c
void SET_INSIDE_VERY_LARGE_INTERIOR(BOOL toggle)  // 0x7EC8ABA5E74B3D7A
```

build 2372 · old names: `_SET_INTERIOR_ZOOM_LEVEL_DECREASED`

## SET_INSIDE_VERY_SMALL_INTERIOR

```c
void SET_INSIDE_VERY_SMALL_INTERIOR(BOOL toggle)  // 0x504DFE62A1692296
```

build 1493 · old names: `_SET_INTERIOR_ZOOM_LEVEL_INCREASED`

## SET_MAX_ARMOUR_HUD_DISPLAY

```c
void SET_MAX_ARMOUR_HUD_DISPLAY(int maximumValue)  // 0x06A320535F5F0248
```

build 323

## SET_MAX_HEALTH_HUD_DISPLAY

```c
void SET_MAX_HEALTH_HUD_DISPLAY(int maximumValue)  // 0x975D66A0BC17064C
```

build 323

## SET_MINIMAP_BACKGROUND_HIDDEN

```c
void SET_MINIMAP_BACKGROUND_HIDDEN(BOOL toggle)  // 0xB09D42557C45EBA1
```

build 3258

> This native does absolutely nothing on PC master builds, just a nullsub.

## SET_MINIMAP_BLOCK_WAYPOINT

```c
void SET_MINIMAP_BLOCK_WAYPOINT(BOOL toggle)  // 0x58FADDED207897DC
```

build 323

## SET_MINIMAP_COMPONENT

```c
BOOL SET_MINIMAP_COMPONENT(int componentId, BOOL toggle, int overrideColor)  // 0x75A9A10948D1DEA6
```

build 323

> This native is used to colorize certain map components like the army base at the top of the map.
> p2 appears to be always -1. If p2 is -1 then native wouldn't change the color.

## SET_MINIMAP_FOW_DO_NOT_UPDATE

```c
void SET_MINIMAP_FOW_DO_NOT_UPDATE(BOOL p0)  // 0x62E849B7EB28E770
```

build 323

## SET_MINIMAP_FOW_REVEAL_COORDINATE

```c
void SET_MINIMAP_FOW_REVEAL_COORDINATE(float x, float y, float z)  // 0x0923DBF87DFF735E
```

build 323

> Up to eight coordinates may be revealed per frame

## SET_MINIMAP_GOLF_COURSE

```c
void SET_MINIMAP_GOLF_COURSE(int hole)  // 0x71BDB63DBAF8DA59
```

build 323

> Not much is known so far on what it does _exactly_.
> All I know for sure is that it draws the specified hole ID on the pause menu map as well as on the mini-map/radar. This native also seems to change some other things related to the pause menu map's behaviour, for example: you can no longer set waypoints, the pause menu map starts up in a 'zoomed in' state. This native does not need to be executed every tick.
> You need to center the minimap manually as well as change/lock it's zoom and angle in order for it to appear correctly on the minimap.
> You'll also need to use the `GOLF` scaleform in order to get the correct minmap border to show up.
> Use `0x35edd5b2e3ff01c0` to reset the map when you no longer want to display any golf holes (you still need to unlock zoom, position and angle of the radar manually after calling this).

## SET_MINIMAP_GOLF_COURSE_OFF

```c
void SET_MINIMAP_GOLF_COURSE_OFF()  // 0x35EDD5B2E3FF01C0
```

build 323

## SET_MINIMAP_HIDE_FOW

```c
void SET_MINIMAP_HIDE_FOW(BOOL toggle)  // 0xF8DEE0A5600CBB93
```

build 323 · old names: `_SET_MINIMAP_REVEALED`

> If true, the entire map will be revealed.
> 
> FOW = Fog of War

## SET_MINIMAP_IN_PROLOGUE

```c
void SET_MINIMAP_IN_PROLOGUE(BOOL toggle)  // 0x9133955F1A2DA957
```

build 323 · old names: `_SET_DRAW_MAP_VISIBLE`, `_SET_NORTH_YANKTON_MAP`

> Toggles the North Yankton map

## SET_MINIMAP_IN_SPECTATOR_MODE

```c
void SET_MINIMAP_IN_SPECTATOR_MODE(BOOL toggle, Ped ped)  // 0x1A5CD7752DD28CD3
```

build 323 · old names: `KEY_HUD_COLOUR`

## SET_MINIMAP_SONAR_SWEEP

```c
void SET_MINIMAP_SONAR_SWEEP(BOOL toggle)  // 0x6B50FC8749632EC1
```

build 2189 · old names: `_SET_MINIMAP_SONAR_ENABLED`

## SET_MISSION_NAME

```c
void SET_MISSION_NAME(BOOL p0, const char* name)  // 0x5F28ECF5FC84772F
```

build 323

## SET_MISSION_NAME_FOR_UGC_MISSION

```c
void SET_MISSION_NAME_FOR_UGC_MISSION(BOOL p0, const char* name)  // 0xE45087D85F468BC2
```

build 323 · old names: `_SET_MISSION_NAME_2`

## SET_MOUSE_CURSOR_STYLE

```c
void SET_MOUSE_CURSOR_STYLE(int spriteId)  // 0x8DB8CFFD58B62552
```

build 323 · old names: `_SET_CURSOR_SPRITE`, `_SET_MOUSE_CURSOR_SPRITE`

> Changes the mouse cursor's sprite. 
> 1 = Normal
> 6 = Left Arrow
> 7 = Right Arrow

## SET_MOUSE_CURSOR_THIS_FRAME

```c
void SET_MOUSE_CURSOR_THIS_FRAME()  // 0xAAE7CE1D63167423
```

build 323 · old names: `_SHOW_CURSOR_THIS_FRAME`, `_SET_MOUSE_CURSOR_ACTIVE_THIS_FRAME`

> Shows the cursor on screen for one frame.

## SET_MOUSE_CURSOR_VISIBLE

```c
void SET_MOUSE_CURSOR_VISIBLE(BOOL toggle)  // 0x98215325A695E78A
```

build 323 · old names: `_SET_MOUSE_CURSOR_VISIBLE_IN_MENUS`

> Shows/hides the frontend cursor on the pause menu or similar menus.
> Clicking off and then on the game window will show it again.

## SET_MP_GAMER_TAG_ALPHA

```c
void SET_MP_GAMER_TAG_ALPHA(int gamerTagId, int component, int alpha)  // 0xD48FE545CD46F857
```

build 323

> Sets flag's sprite transparency. 0-255.

## SET_MP_GAMER_TAG_BIG_TEXT

```c
void SET_MP_GAMER_TAG_BIG_TEXT(int gamerTagId, const char* string)  // 0x7B7723747CCB55B6
```

build 323 · old names: `_SET_MP_GAMER_TAG_CHATTING`

## SET_MP_GAMER_TAG_COLOUR

```c
void SET_MP_GAMER_TAG_COLOUR(int gamerTagId, int component, int hudColorIndex)  // 0x613ED644950626AE
```

build 323

> Sets a gamer tag's component colour
> 
> gamerTagId is obtained using for example CREATE_FAKE_MP_GAMER_TAG
> Ranges from 0 to 255. 0 is grey health bar, ~50 yellow, 200 purple.

## SET_MP_GAMER_TAG_HEALTH_BAR_COLOUR

```c
void SET_MP_GAMER_TAG_HEALTH_BAR_COLOUR(int gamerTagId, int hudColorIndex)  // 0x3158C77A7E888AB4
```

build 323 · old names: `_SET_MP_GAMER_TAG_HEALTH_BAR_COLOR`

> Ranges from 0 to 255. 0 is grey health bar, ~50 yellow, 200 purple.
> Should be enabled as flag (2). Has 0 opacity by default.

## SET_MP_GAMER_TAG_NAME

```c
void SET_MP_GAMER_TAG_NAME(int gamerTagId, const char* string)  // 0xDEA2B8283BAA3944
```

build 323

## SET_MP_GAMER_TAG_NUM_PACKAGES

```c
void SET_MP_GAMER_TAG_NUM_PACKAGES(int gamerTagId, int p1)  // 0x9C16459B2324B2CF
```

build 877 · old names: `_SET_MP_GAMER_TAG_UNK`

## SET_MP_GAMER_TAG_VISIBILITY

```c
void SET_MP_GAMER_TAG_VISIBILITY(int gamerTagId, int component, BOOL toggle, Any p3)  // 0x63BB75ABEDC1F6A0
```

build 323

> enum eMpGamerTagComponent
> {
> 	MP_TAG_GAMER_NAME,
> 	MP_TAG_CREW_TAG,
> 	MP_TAG_HEALTH_ARMOUR,
> 	MP_TAG_BIG_TEXT,
> 	MP_TAG_AUDIO_ICON,
> 	MP_TAG_USING_MENU,
> 	MP_TAG_PASSIVE_MODE,
> 	MP_TAG_WANTED_STARS,
> 	MP_TAG_DRIVER,
> 	MP_TAG_CO_DRIVER,
> 	MP_TAG_TAGGED,
> 	MP_TAG_GAMER_NAME_NEARBY,
> 	MP_TAG_ARROW,
> 	MP_TAG_PACKAGES,
> 	MP_TAG_INV_IF_PED_FOLLOWING,
> 	MP_TAG_RANK_TEXT,
> 	MP_TAG_TYPING,
> 	MP_TAG_BAG_LARGE,
> 	MP_TAG_ARROW,
> 	MP_TAG_GANG_CEO,
> 	MP_TAG_GANG_BIKER,
> 	MP_TAG_BIKER_ARROW,
> 	MP_TAG_MC_ROLE_PRESIDENT,
> 	MP_TAG_MC_ROLE_VICE_PRESIDENT,
> 	MP_TAG_MC_ROLE_ROAD_CAPTAIN,
> 	MP_TAG_MC_ROLE_SARGEANT,
> 	MP_TAG_MC_ROLE_ENFORCER,
> 	MP_TAG_MC_ROLE_PROSPECT,
> 	MP_TAG_TRANSMITTER,
> 	MP_TAG_BOMB
> };

## SET_MP_GAMER_TAG_WANTED_LEVEL

```c
void SET_MP_GAMER_TAG_WANTED_LEVEL(int gamerTagId, int wantedlvl)  // 0xCF228E2AA03099C3
```

build 323

> displays wanted star above head

## SET_MP_GAMER_TAGS_POINT_HEALTH

```c
void SET_MP_GAMER_TAGS_POINT_HEALTH(int gamerTagId, int value, int maximumValue)  // 0x1563FE35E9928E67
```

build 1365 · old names: `_SET_MP_GAMER_HEALTH_BAR_MAX`

## SET_MP_GAMER_TAGS_SHOULD_USE_POINTS_HEALTH

```c
void SET_MP_GAMER_TAGS_SHOULD_USE_POINTS_HEALTH(int gamerTagId, BOOL toggle)  // 0xD29EC58C2F6B5014
```

build 1365 · old names: `_SET_MP_GAMER_HEALTH_BAR_DISPLAY`

## SET_MP_GAMER_TAGS_SHOULD_USE_VEHICLE_HEALTH

```c
void SET_MP_GAMER_TAGS_SHOULD_USE_VEHICLE_HEALTH(int gamerTagId, BOOL toggle)  // 0xA67F9C46D612B6F1
```

build 323 · old names: `_SET_MP_GAMER_TAG_ICONS`

> Displays a bunch of icons above the players name, and level, and their name twice

## SET_MULTIPLAYER_BANK_CASH

```c
void SET_MULTIPLAYER_BANK_CASH()  // 0xDD21B55DF695CD0A
```

build 323

## SET_MULTIPLAYER_HUD_CASH

```c
void SET_MULTIPLAYER_HUD_CASH(int p0, BOOL p1)  // 0xFD1D220394BCB824
```

build 323

> This native does absolutely nothing, just a nullsub

## SET_MULTIPLAYER_WALLET_CASH

```c
void SET_MULTIPLAYER_WALLET_CASH()  // 0xC2D15BEF167E27BC
```

build 323

## SET_NEW_WAYPOINT

```c
void SET_NEW_WAYPOINT(float x, float y)  // 0xFE43368D2AA4F2FC
```

build 323

## SET_PAUSE_MENU_ACTIVE

```c
void SET_PAUSE_MENU_ACTIVE(BOOL toggle)  // 0xDF47FC56C71569CF
```

build 323

## SET_PAUSE_MENU_PED_LIGHTING

```c
void SET_PAUSE_MENU_PED_LIGHTING(BOOL state)  // 0x3CA6050692BC61B0
```

build 323

> Toggles the light state for the pause menu ped in frontend menus.
> 
> This is used by R* in combination with `SET_PAUSE_MENU_PED_SLEEP_STATE` to toggle the "offline" or "online" state in the "friends" tab of the pause menu in GTA Online.
> 
> 
> Example:
> Lights On: https://vespura.com/hi/i/2019-04-01_16-09_540ee_1015.png
> Lights Off: https://vespura.com/hi/i/2019-04-01_16-10_8b5e7_1016.png

## SET_PAUSE_MENU_PED_SLEEP_STATE

```c
void SET_PAUSE_MENU_PED_SLEEP_STATE(BOOL state)  // 0xECF128344E9FF9F1
```

build 323

> Toggles the pause menu ped sleep state for frontend menus.
> 
> Example: https://vespura.com/hi/i/2019-04-01_15-51_8ed38_1014.gif
> 
> `state` 0 will make the ped slowly fall asleep, 1 will slowly wake the ped up.

## SET_PED_AI_BLIP_FORCED_ON

```c
void SET_PED_AI_BLIP_FORCED_ON(Ped ped, BOOL toggle)  // 0x0C4BBF625CA98C4E
```

build 323 · old names: `_IS_AI_BLIP_ALWAYS_SHOWN`

## SET_PED_AI_BLIP_GANG_ID

```c
void SET_PED_AI_BLIP_GANG_ID(Ped ped, int gangId)  // 0xE52B8E7F85D39A08
```

build 323 · old names: `_SET_AI_BLIP_TYPE`

## SET_PED_AI_BLIP_HAS_CONE

```c
void SET_PED_AI_BLIP_HAS_CONE(Ped ped, BOOL toggle)  // 0x3EED80DFF7325CAA
```

build 323 · old names: `HIDE_SPECIAL_ABILITY_LOCKON_OPERATION`

## SET_PED_AI_BLIP_NOTICE_RANGE

```c
void SET_PED_AI_BLIP_NOTICE_RANGE(Ped ped, float range)  // 0x97C65887D4B37FA9
```

build 323 · old names: `_SET_AI_BLIP_MAX_DISTANCE`

## SET_PED_AI_BLIP_SPRITE

```c
void SET_PED_AI_BLIP_SPRITE(Ped ped, int spriteId)  // 0xFCFACD0DB9D7A57D
```

build 877 · old names: `_SET_PED_AI_BLIP_SPRITE`

## SET_PED_HAS_AI_BLIP

```c
void SET_PED_HAS_AI_BLIP(Ped ped, BOOL hasCone)  // 0xD30C50DF888D58B5
```

build 323 · old names: `_SET_PED_ENEMY_AI_BLIP`, `_SET_PED_AI_BLIP`

> This native turns on the AI blip on the specified ped. It also disappears automatically when the ped is too far or if the ped is dead. You don't need to control it with other natives.
> 
> See https://gtaforums.com/topic/884370-native-research-ai-blips for further information.

## SET_PED_HAS_AI_BLIP_WITH_COLOUR

```c
void SET_PED_HAS_AI_BLIP_WITH_COLOUR(Ped ped, BOOL hasCone, int color)  // 0xB13DCB4C6FAAD238
```

build 505 · old names: `_SET_PED_HAS_AI_BLIP_WITH_COLOR`

> color: see SET_BLIP_COLOUR

## SET_PLAYER_ICON_COLOUR

```c
void SET_PLAYER_ICON_COLOUR(int color)  // 0x7B21E0BB01E8224A
```

build 323 · old names: `_SET_MAIN_PLAYER_BLIP_COLOUR`

## SET_PLAYER_IS_IN_DIRECTOR_MODE

```c
void SET_PLAYER_IS_IN_DIRECTOR_MODE(BOOL toggle)  // 0x808519373FD336A3
```

build 323 · old names: `_SET_DIRECTOR_MODE`, `_SET_PLAYER_IS_IN_DIRECTOR_MODE`

> If toggle is true, hides special ability bar / character name in the pause menu
> If toggle is false, shows special ability bar / character name in the pause menu

## SET_PM_WARNINGSCREEN_ACTIVE

```c
void SET_PM_WARNINGSCREEN_ACTIVE(BOOL p0)  // 0x41350B4FC28E3941
```

build 323

## SET_RACE_TRACK_RENDER

```c
void SET_RACE_TRACK_RENDER(BOOL toggle)  // 0x1EAC5F91BCBC5073
```

build 323

## SET_RADAR_AS_EXTERIOR_THIS_FRAME

```c
void SET_RADAR_AS_EXTERIOR_THIS_FRAME()  // 0xE81B7D2A3DAB2D81
```

build 323

## SET_RADAR_AS_INTERIOR_THIS_FRAME

```c
void SET_RADAR_AS_INTERIOR_THIS_FRAME(Hash interior, float x, float y, int z, int zoom)  // 0x59E727A1C9D3E31A
```

build 323

> List of interior hashes: https://pastebin.com/1FUyXNqY
> Not for every interior zoom > 0 available.

## SET_RADAR_ZOOM

```c
void SET_RADAR_ZOOM(int zoomLevel)  // 0x096EF57A0C999BBA
```

build 323

> zoomLevel ranges from 0 to 1400 in R* Scripts

## SET_RADAR_ZOOM_PRECISE

```c
void SET_RADAR_ZOOM_PRECISE(float zoom)  // 0xBD12C5EEE184C337
```

build 323 · old names: `RESPONDING_AS_TEMP`

> zoom ranges from 0 to 90f in R* Scripts

## SET_RADAR_ZOOM_TO_BLIP

```c
void SET_RADAR_ZOOM_TO_BLIP(Blip blip, float zoom)  // 0xF98E4B3E56AFC7B1
```

build 323

## SET_RADAR_ZOOM_TO_DISTANCE

```c
void SET_RADAR_ZOOM_TO_DISTANCE(float zoom)  // 0xCB7CC0D58405AD41
```

build 323 · old names: `_SET_RADAR_ZOOM_LEVEL_THIS_FRAME`

## SET_RADIUS_BLIP_EDGE

```c
void SET_RADIUS_BLIP_EDGE(Blip blip, BOOL toggle)  // 0x25615540D894B814
```

build 323

> Enabling this on a radius blip will make it outline only.

## SET_SAVEGAME_LIST_UNIQUE_ID

```c
void SET_SAVEGAME_LIST_UNIQUE_ID(Any p0)  // 0x0CF54F20DE43879C
```

build 323

## SET_SCRIPT_VARIABLE_HUD_COLOUR

```c
void SET_SCRIPT_VARIABLE_HUD_COLOUR(int r, int g, int b, int a)  // 0xD68A5FF8A3A89874
```

build 323

> Sets the color of HUD_COLOUR_SCRIPT_VARIABLE

## SET_SECOND_SCRIPT_VARIABLE_HUD_COLOUR

```c
void SET_SECOND_SCRIPT_VARIABLE_HUD_COLOUR(int r, int g, int b, int a)  // 0x16A304E6CB2BFAB9
```

build 323 · old names: `_SET_SCRIPT_VARIABLE_2_HUD_COLOUR`

> Sets the color of HUD_COLOUR_SCRIPT_VARIABLE_2

## SET_SOCIAL_CLUB_TOUR

```c
void SET_SOCIAL_CLUB_TOUR(const char* name)  // 0x9E778248D6685FE0
```

build 323

> HUD::SET_SOCIAL_CLUB_TOUR("Gallery");
> HUD::SET_SOCIAL_CLUB_TOUR("Missions");
> HUD::SET_SOCIAL_CLUB_TOUR("General");
> HUD::SET_SOCIAL_CLUB_TOUR("Playlists");

## SET_TEXT_CENTRE

```c
void SET_TEXT_CENTRE(BOOL align)  // 0xC02F4DBFB51D988B
```

build 323

## SET_TEXT_COLOUR

```c
void SET_TEXT_COLOUR(int red, int green, int blue, int alpha)  // 0xBE6B23FFA53FB442
```

build 323

## SET_TEXT_DROP_SHADOW

```c
void SET_TEXT_DROP_SHADOW()  // 0x1CA3E9EAC9D93E5E
```

build 323

## SET_TEXT_DROPSHADOW

```c
void SET_TEXT_DROPSHADOW(int distance, int r, int g, int b, int a)  // 0x465C84BC39F1C351
```

build 323

> distance - shadow distance in pixels, both horizontal and vertical
> r, g, b, a - color

## SET_TEXT_EDGE

```c
void SET_TEXT_EDGE(int p0, int r, int g, int b, int a)  // 0x441603240D202FA6
```

build 323

> This native does absolutely nothing, just a nullsub

## SET_TEXT_FONT

```c
void SET_TEXT_FONT(int fontType)  // 0x66E0276CC5F6B9DA
```

build 323

> fonts that mess up your text where made for number values/misc stuff

## SET_TEXT_INPUT_BOX_ENABLED

```c
void SET_TEXT_INPUT_BOX_ENABLED(BOOL p0)  // 0x1185A8087587322C
```

build 323

## SET_TEXT_JUSTIFICATION

```c
void SET_TEXT_JUSTIFICATION(int justifyType)  // 0x4E096588B13FFECA
```

build 323

> Types -
> 0: Center-Justify
> 1: Left-Justify
> 2: Right-Justify
> 
> Right-Justify requires SET_TEXT_WRAP, otherwise it will draw to the far right of the screen

## SET_TEXT_LEADING

```c
void SET_TEXT_LEADING(int p0)  // 0xA50ABC31E3CDFAFF
```

build 323

## SET_TEXT_LINE_HEIGHT_MULT

```c
void SET_TEXT_LINE_HEIGHT_MULT(float lineHeightMult)  // 0x9F4624F76E6953D1
```

build 3095

## SET_TEXT_OUTLINE

```c
void SET_TEXT_OUTLINE()  // 0x2513DFB0FB8400FE
```

build 323

## SET_TEXT_PROPORTIONAL

```c
void SET_TEXT_PROPORTIONAL(BOOL p0)  // 0x038C1F517D7FDCF8
```

build 323

> This native does absolutely nothing, just a nullsub

## SET_TEXT_RENDER_ID

```c
void SET_TEXT_RENDER_ID(int renderId)  // 0x5F15302936E07111
```

build 323

## SET_TEXT_RIGHT_JUSTIFY

```c
void SET_TEXT_RIGHT_JUSTIFY(BOOL toggle)  // 0x6B3C4650BC8BEE47
```

build 323

## SET_TEXT_SCALE

```c
void SET_TEXT_SCALE(float scale, float size)  // 0x07C837F9A01C34C9
```

build 323

> Size range : 0F to 1.0F
> p0 is unknown and doesn't seem to have an effect, yet in the game scripts it changes to 1.0F sometimes.

## SET_TEXT_WRAP

```c
void SET_TEXT_WRAP(float start, float end)  // 0x63145D9C883A1A70
```

build 323

> It sets the text in a specified box and wraps the text if it exceeds the boundries. Both values are for X axis. Useful when positioning text set to center or aligned to the right.
> 
> start - left boundry on screen position (0.0 - 1.0)
> end - right boundry on screen position (0.0 - 1.0)

## SET_USE_ISLAND_MAP

```c
void SET_USE_ISLAND_MAP(BOOL toggle)  // 0x5E1460624D194A38
```

build 2189 · old names: `_SET_TOGGLE_MINIMAP_HEIST_ISLAND`

> Toggles the Cayo Perico map.

## SET_USE_SET_DESTINATION_IN_PAUSE_MAP

```c
void SET_USE_SET_DESTINATION_IN_PAUSE_MAP(BOOL toggle)  // 0x6CDD58146A436083
```

build 573 · old names: `_SET_USE_WAYPOINT_AS_DESTINATION`

## SET_WARNING_MESSAGE

```c
void SET_WARNING_MESSAGE(const char* titleMsg, int flags, const char* promptMsg, BOOL p3, int p4, const char* p5, const char* p6, BOOL showBackground, int errorCode)  // 0x7B1776B3B53F8D74
```

build 323

> You can only use text entries. No custom text.
> 
> Example: SET_WARNING_MESSAGE("t20", 3, "adder", false, -1, 0, 0, true);
> errorCode: shows an error code at the bottom left if nonzero

## SET_WARNING_MESSAGE_OPTION_HIGHLIGHT

```c
BOOL SET_WARNING_MESSAGE_OPTION_HIGHLIGHT(Any p0)  // 0xDAF87174BE7454FF
```

build 323

## SET_WARNING_MESSAGE_OPTION_ITEMS

```c
BOOL SET_WARNING_MESSAGE_OPTION_ITEMS(int index, const char* name, int cash, int rp, int lvl, int colour)  // 0x0C5A80A9E096D529
```

build 323 · old names: `_SET_WARNING_MESSAGE_LIST_ROW`

> Some sort of list displayed in a warning message. Yet unknown how to prevent repeating.
> Param names copied from the corresponding scaleform function "SET_LIST_ROW".
> Example: https://i.imgur.com/arKvOYx.png

## SET_WARNING_MESSAGE_WITH_HEADER

```c
void SET_WARNING_MESSAGE_WITH_HEADER(const char* entryHeader, const char* entryLine1, int instructionalKey, const char* entryLine2, BOOL p4, Any p5, Any* showBackground, Any* p7, BOOL p8, Any p9)  // 0xDC38CC1E35B6A5D7
```

build 323 · old names: `_SET_WARNING_MESSAGE_2`

> Shows a warning message on screen with a header.
> Note: You can only use text entries. No custom text. You can recreate this easily with scaleforms.
> Example: https://i.imgur.com/ITJt8bJ.png

## SET_WARNING_MESSAGE_WITH_HEADER_AND_SUBSTRING_FLAGS

```c
void SET_WARNING_MESSAGE_WITH_HEADER_AND_SUBSTRING_FLAGS(const char* entryHeader, const char* entryLine1, int instructionalKey, const char* entryLine2, BOOL p4, Any p5, Any additionalIntInfo, const char* additionalTextInfoLine1, const char* additionalTextInfoLine2, BOOL showBackground, int errorCode)  // 0x701919482C74B5AB
```

build 323 · old names: `_SET_WARNING_MESSAGE_3`

> You can use this native for custom input, without having to use any scaleform-related natives.
> The native must be called on tick.
> The entryHeader must be a valid label.
> For Single lines use JL_INVITE_N as entryLine1, JL_INVITE_ND for multiple.
> Notes:
> - additionalIntInfo: replaces first occurrence of ~1~ in provided label with an integer
> - additionalTextInfoLine1: replaces first occurrence of ~a~ in provided label, with your custom text
> - additionalTextInfoLine2: replaces second occurrence of ~a~ in provided label, with your custom text
> - showBackground: shows black background of the warning screen
> - errorCode: shows an error code at the bottom left if nonzero
> Example of usage:
> SET_WARNING_MESSAGE_WITH_HEADER_AND_SUBSTRING_FLAGS("ALERT", "JL_INVITE_ND", 66, "", true, -1, -1, "Testing line 1", "Testing line 2", true, 0);
> Screenshot:
> https://i.imgur.com/MsSIhPV.png

## SET_WARNING_MESSAGE_WITH_HEADER_AND_SUBSTRING_FLAGS_EXTENDED

```c
void SET_WARNING_MESSAGE_WITH_HEADER_AND_SUBSTRING_FLAGS_EXTENDED(const char* labelTitle, const char* labelMessage, int p2, int p3, const char* labelMessage2, BOOL p5, int p6, int p7, const char* p8, const char* p9, BOOL background, int errorCode)  // 0x15803FEC3B9A872B
```

build 573 · old names: `_DRAW_FRONTEND_ALERT`, `_SET_WARNING_MESSAGE_WITH_ALERT`

> labelTitle: Label of the alert's title.
> labelMsg: Label of the alert's message.
> p2: This is an enum, check the description for a list.
> p3: This is an enum, check the description for a list.
> labelMsg2: Label of another message line
> p5: usually 0
> p6: usually -1
> p7: usually 0
> p8: unknown label
> p9: unknown label
> background: Set to anything other than 0 or false (even any string) and it will draw a background. Setting it to 0 or false will draw no background.
> errorCode: Error code, shown at the bottom left if set to value other than 0.
> 
> instructionalKey enum list:
> Buttons = {
>       Empty = 0,
>       Select = 1, -- (RETURN)
>       Ok = 2, -- (RETURN)
>       Yes = 4, -- (RETURN)
>       Back = 8, -- (ESC)
>       Cancel = 16, -- (ESC)
>       No = 32, -- (ESC)
>       RetrySpace = 64, -- (SPACE)
>       Restart = 128, -- (SPACE)
>       Skip = 256, -- (SPACE)
>       Quit = 512, -- (ESC)
>       Adjust = 1024, -- (ARROWS)
>       SpaceKey = 2048, -- (SPACE)
>       Share = 4096, -- (SPACE)
>       SignIn = 8192, -- (SPACE)
>       Continue = 16384, -- (RETURN)
>       AdjustLeftRight = 32768, -- (SCROLL L/R)
>       AdjustUpDown = 65536, -- (SCROLL U/D)
>       Overwrite = 131072, -- (SPACE)
>       SocialClubSignup = 262144, -- (RETURN)
>       Confirm = 524288, -- (RETURN)
>       Queue = 1048576, -- (RETURN)
>       RetryReturn = 2097152, -- (RETURN)
>       BackEsc = 4194304, -- (ESC)
>       SocialClub = 8388608, -- (RETURN)
>       Spectate = 16777216, -- (SPACE)
>       OkEsc = 33554432, -- (ESC)
>       CancelTransfer = 67108864, -- (ESC)
>       LoadingSpinner = 134217728,
>       NoReturnToGTA = 268435456, -- (ESC)
>       CancelEsc = 536870912, -- (ESC)
> }
> 
> Alt = {
>       Empty = 0,
>       No = 1, -- (SPACE)
>       Host = 2, -- (ESC)
>       SearchForJob = 4, -- (RETURN)
>       ReturnKey = 8, -- (TURN)
>       Freemode = 16, -- (ESC)
> }

## SET_WARNING_MESSAGE_WITH_HEADER_EXTENDED

```c
void SET_WARNING_MESSAGE_WITH_HEADER_EXTENDED(const char* entryHeader, const char* entryLine1, int flags, const char* entryLine2, BOOL p4, Any p5, Any* p6, Any* p7, BOOL showBg, Any p9, Any p10)  // 0x38B55259C2E078ED
```

build 1493 · old names: `_SET_WARNING_MESSAGE_WITH_HEADER_UNK`

## SET_WAYPOINT_CLEAR_ON_ARRIVAL_MODE

```c
void SET_WAYPOINT_CLEAR_ON_ARRIVAL_MODE(int mode)  // 0x3FFC556B62146F75
```

build 3717

## SET_WAYPOINT_OFF

```c
void SET_WAYPOINT_OFF()  // 0xA7E4E2D361C2627F
```

build 323

> This native removes the current waypoint from the map.
> 
> Example:
> C#:
> Function.Call(Hash.SET_WAYPOINT_OFF);
> 
> C++:
> HUD::SET_WAYPOINT_OFF();

## SET_WIDESCREEN_FORMAT

```c
void SET_WIDESCREEN_FORMAT(Any p0)  // 0xC3B07BA00A83B0F1
```

build 323

## SETUP_FAKE_CONE_DATA

```c
void SETUP_FAKE_CONE_DATA(Blip blip, float p1, float p2, float p3, float p4, float p5, float p6, Any p7, int p8)  // 0xF83D0FEBE75E62C9
```

build 1290

## SHOW_ACCOUNT_PICKER

```c
void SHOW_ACCOUNT_PICKER()  // 0x60E892BA4F5BDCA4
```

build 323 · old names: `_SHOW_SIGNIN_UI`

## SHOW_CONTACT_INSTRUCTIONAL_BUTTON

```c
void SHOW_CONTACT_INSTRUCTIONAL_BUTTON(BOOL toggle)  // 0xC772A904CDE1186F
```

build 2545 · old names: `_SHOW_CONTACT_INSTRUCTIONAL_BUTTON`

## SHOW_CREW_INDICATOR_ON_BLIP

```c
void SHOW_CREW_INDICATOR_ON_BLIP(Blip blip, BOOL toggle)  // 0xDCFB5D4DB8BF367E
```

build 323 · old names: `SET_BLIP_CREW`

> Enables or disables the blue half circle around the specified blip on the left side of the blip. This is used to indicate that the player is in your crew in GTA:O. Color is changeable by using `SET_BLIP_SECONDARY_COLOUR`.

## SHOW_FOR_SALE_ICON_ON_BLIP

```c
void SHOW_FOR_SALE_ICON_ON_BLIP(Blip blip, BOOL toggle)  // 0x19BD6E3C0E16A8FA
```

build 2802

## SHOW_FRIEND_INDICATOR_ON_BLIP

```c
void SHOW_FRIEND_INDICATOR_ON_BLIP(Blip blip, BOOL toggle)  // 0x23C3EB807312F01A
```

build 323 · old names: `SET_BLIP_FRIEND`

> Highlights a blip by a half cyan circle on the right side of the blip. Indicating that that player is a friend (in GTA:O). This color can not be changed.
> To toggle the left side (crew member indicator) of the half circle around the blip, use: `SHOW_CREW_INDICATOR_ON_BLIP`

## SHOW_GOLD_TICK_ON_BLIP

```c
void SHOW_GOLD_TICK_ON_BLIP(Blip blip, BOOL toggle)  // 0xCAC2031EBF79B1A8
```

build 2699 · old names: `_SHOW_TICK_ON_BLIP_2`, `_SHOW_HAS_COMPLETED_INDICATOR_ON_BLIP`

> Adds an orange checkmark on top of a given blip handle: https://i.imgur.com/KG9k6Fk.png

## SHOW_HEADING_INDICATOR_ON_BLIP

```c
void SHOW_HEADING_INDICATOR_ON_BLIP(Blip blip, BOOL toggle)  // 0x5FBCA48327B914DF
```

build 323

> Adds the GTA: Online player heading indicator to a blip.

## SHOW_HEIGHT_ON_BLIP

```c
void SHOW_HEIGHT_ON_BLIP(Blip blip, BOOL toggle)  // 0x75A16C3DA34F1245
```

build 323

## SHOW_HUD_COMPONENT_THIS_FRAME

```c
void SHOW_HUD_COMPONENT_THIS_FRAME(int id)  // 0x0B4DF1FA60C0E664
```

build 323

> This function hides various HUD (Heads-up Display) components.
> Listed below are the integers and the corresponding HUD component.
> - 1 : WANTED_STARS
> - 2 : WEAPON_ICON
> - 3 : CASH
> - 4 : MP_CASH
> - 5 : MP_MESSAGE
> - 6 : VEHICLE_NAME
> - 7 : AREA_NAME
> - 8 : VEHICLE_CLASS
> - 9 : STREET_NAME
> - 10 : HELP_TEXT
> - 11 : FLOATING_HELP_TEXT_1
> - 12 : FLOATING_HELP_TEXT_2
> - 13 : CASH_CHANGE
> - 14 : RETICLE
> - 15 : SUBTITLE_TEXT
> - 16 : RADIO_STATIONS
> - 17 : SAVING_GAME
> - 18 : GAME_STREAM
> - 19 : WEAPON_WHEEL
> - 20 : WEAPON_WHEEL_STATS
> - 21 : HUD_COMPONENTS
> - 22 : HUD_WEAPONS
> 
> These integers also work for the `HIDE_HUD_COMPONENT_THIS_FRAME` native, but instead hides the HUD Component.

## SHOW_NUMBER_ON_BLIP

```c
void SHOW_NUMBER_ON_BLIP(Blip blip, int number)  // 0xA3C0B359DCB848B6
```

build 323

## SHOW_OUTLINE_INDICATOR_ON_BLIP

```c
void SHOW_OUTLINE_INDICATOR_ON_BLIP(Blip blip, BOOL toggle)  // 0xB81656BC81FE24D1
```

build 323 · old names: `SET_BLIP_FRIENDLY`

> Highlights a blip by a cyan color circle.
> 
> Color can be changed with SET_BLIP_SECONDARY_COLOUR

## SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME

```c
void SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME(int id)  // 0x4F38DCA127DAAEA2
```

build 1734 · old names: `_SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME`

## SHOW_START_MISSION_INSTRUCTIONAL_BUTTON

```c
void SHOW_START_MISSION_INSTRUCTIONAL_BUTTON(BOOL toggle)  // 0xF1A6C18B35BCADE6
```

build 323

## SHOW_TICK_ON_BLIP

```c
void SHOW_TICK_ON_BLIP(Blip blip, BOOL toggle)  // 0x74513EA3E505181E
```

build 323 · old names: `_SET_BLIP_CHECKED`

> Adds a green checkmark on top of a blip.

## START_GPS_CUSTOM_ROUTE

```c
void START_GPS_CUSTOM_ROUTE(int hudColor, BOOL displayOnFoot, BOOL followPlayer)  // 0xDB34E8D56FC13B08
```

build 323

> Starts a new GPS custom-route, allowing you to plot lines on the map.
> Lines are drawn directly between points.
> The GPS custom route works like the GPS multi route, except it does not follow roads.
> hudColor: The HUD color of the GPS path.
> displayOnFoot: Draws the path regardless if the player is in a vehicle or not.
> followPlayer: Draw the path partially between the previous and next point based on the players position between them. When false, the GPS appears to not disappear after the last leg is completed.

## START_GPS_MULTI_ROUTE

```c
void START_GPS_MULTI_ROUTE(int hudColor, BOOL routeFromPlayer, BOOL displayOnFoot)  // 0x3D3D15AF7BCAAF83
```

build 323

> Starts a new GPS multi-route, allowing you to create custom GPS paths.
> GPS functions like the waypoint, except it can contain multiple points it's forced to go through.
> Once the player has passed a point, the GPS will no longer force its path through it.
> 
> Works independently from the player-placed waypoint and blip routes.
> hudColor: The HUD color of the GPS path.
> routeFromPlayer: Makes the GPS draw a path from the player to the next point, rather than the original path from the previous point.
> displayOnFoot: Draws the GPS path regardless if the player is in a vehicle or not.

## SUPPRESS_FRONTEND_RENDERING_THIS_FRAME

```c
void SUPPRESS_FRONTEND_RENDERING_THIS_FRAME()  // 0xBA751764F0821256
```

build 323

## TAKE_CONTROL_OF_FRONTEND

```c
void TAKE_CONTROL_OF_FRONTEND()  // 0xEC9264727EEC0F28
```

build 323

> Disables frontend (works in custom frontends, not sure about regular pause menu) navigation keys on keyboard. Not sure about controller. Does not disable mouse controls. No need to call this every tick.
> 
> To enable the keys again, use `0x14621BB1DF14E2B2`.

## THEFEED_AUTO_POST_GAMETIPS_OFF

```c
void THEFEED_AUTO_POST_GAMETIPS_OFF()  // 0xADED7F5748ACAFE6
```

build 323 · old names: `_THEFEED_SHOW_GTAO_TOOLTIPS`, `THEFEED_COMMENT_TELEPORT_POOL_OFF`

> Displays "normal" notifications again after calling `THEFEED_AUTO_POST_GAMETIPS_ON` (those that were drawn before calling this native too), though those will have a weird offset and stay on screen forever (tested with notifications created from same script).

## THEFEED_AUTO_POST_GAMETIPS_ON

```c
void THEFEED_AUTO_POST_GAMETIPS_ON()  // 0x56C8B608CFD49854
```

build 323 · old names: `THEFEED_COMMENT_TELEPORT_POOL_ON`

> Enables loading screen tips to be be shown (`THEFEED_SHOW`), blocks other kinds of notifications from being displayed (at least from current script). Call `THEFEED_AUTO_POST_GAMETIPS_OFF` to display those again.

## THEFEED_CLEAR_FROZEN_POST

```c
void THEFEED_CLEAR_FROZEN_POST()  // 0x80FE4F3AB4E1B62A
```

build 323 · old names: `_THEFEED_FLUSH_PERSISTENT`

## THEFEED_FLUSH_QUEUE

```c
void THEFEED_FLUSH_QUEUE()  // 0xA8FDB297A8D25FBA
```

build 323

## THEFEED_FORCE_RENDER_OFF

```c
void THEFEED_FORCE_RENDER_OFF()  // 0x583049884A2EEE3C
```

build 323 · old names: `_THEFEED_HIDE_GTAO_TOOLTIPS`

> Enables loading screen tips to be be shown (`THEFEED_SHOW`), blocks other kinds of notifications from being displayed (at least from current script). Call `0xADED7F5748ACAFE6` to display those again.

## THEFEED_FORCE_RENDER_ON

```c
void THEFEED_FORCE_RENDER_ON()  // 0xA13C11E1B5C06BFC
```

build 323

## THEFEED_FREEZE_NEXT_POST

```c
void THEFEED_FREEZE_NEXT_POST()  // 0xFDEC055AB549E328
```

build 323 · old names: `_THEFEED_SET_NEXT_POST_PERSISTENT`

> Requires manual management of game stream handles (i.e., THEFEED_REMOVE_ITEM).

## THEFEED_GET_LAST_SHOWN_PHONE_ACTIVATABLE_FEED_ID

```c
int THEFEED_GET_LAST_SHOWN_PHONE_ACTIVATABLE_FEED_ID()  // 0x82352748437638CA
```

build 323 · old names: `_GET_CURRENT_NOTIFICATION`, `_THEFEED_GET_CURRENT_NOTIFICATION`, `THEFEED_GET_FIRST_VISIBLE_DELETE_REMAINING`

> Returns the handle for the notification currently displayed on the screen. Name may be a hash collision, but describes the function accurately.

## THEFEED_HIDE

```c
void THEFEED_HIDE()  // 0x32888337579A5970
```

build 463 · old names: `_THEFEED_DISABLE`, `_THEFEED_DISABLE_LOADING_SCREEN_TIPS`

> Stops loading screen tips shown by invoking `THEFEED_SHOW`

## THEFEED_HIDE_THIS_FRAME

```c
void THEFEED_HIDE_THIS_FRAME()  // 0x25F87B30C382FCA7
```

build 323 · old names: `_HIDE_HUD_NOTIFICATIONS_THIS_FRAME`

> Once called each frame hides all above radar notifications.

## THEFEED_IS_PAUSED

```c
BOOL THEFEED_IS_PAUSED()  // 0xA9CBFD40B3FA3010
```

build 323

## THEFEED_ONLY_SHOW_TOOLTIPS

```c
void THEFEED_ONLY_SHOW_TOOLTIPS(BOOL toggle)  // 0x6F1554B0CC2089FA
```

build 323

## THEFEED_PAUSE

```c
void THEFEED_PAUSE()  // 0xFDB423997FA30340
```

build 323

## THEFEED_REMOVE_ITEM

```c
void THEFEED_REMOVE_ITEM(int notificationId)  // 0xBE4390CB40B3E627
```

build 323 · old names: `_REMOVE_NOTIFICATION`

> Removes a notification instantly instead of waiting for it to disappear

## THEFEED_REPORT_LOGO_OFF

```c
void THEFEED_REPORT_LOGO_OFF()  // 0xB695E2CD0A2DA9EE
```

build 323 · old names: `_THEFEED_DISABLE_BASELINE_OFFSET`, `THEFEED_SPS_EXTEND_WIDESCREEN_OFF`

## THEFEED_REPORT_LOGO_ON

```c
void THEFEED_REPORT_LOGO_ON()  // 0xD4438C0564490E63
```

build 323 · old names: `_THEFEED_ENABLE_BASELINE_OFFSET`, `THEFEED_SPS_EXTEND_WIDESCREEN_ON`

## THEFEED_RESET_ALL_PARAMETERS

```c
void THEFEED_RESET_ALL_PARAMETERS()  // 0xFDD85225B2DEA55E
```

build 323 · old names: `_THEFEED_CLEAR_ANIMPOSTFX`

## THEFEED_RESUME

```c
void THEFEED_RESUME()  // 0xE1CD1E48E025E661
```

build 323

## THEFEED_SET_BACKGROUND_COLOR_FOR_NEXT_POST

```c
void THEFEED_SET_BACKGROUND_COLOR_FOR_NEXT_POST(int hudColorIndex)  // 0x92F0DA1E27DB96DC
```

build 323 · old names: `_SET_NOTIFICATION_BACKGROUND_COLOR`, `_THEFEED_NEXT_POST_BACKGROUND_COLOR`, `_THEFEED_SET_NEXT_POST_BACKGROUND_COLOR`

> From the decompiled scripts:
> HUD::THEFEED_SET_BACKGROUND_COLOR_FOR_NEXT_POST(6);
> HUD::THEFEED_SET_BACKGROUND_COLOR_FOR_NEXT_POST(184);
> HUD::THEFEED_SET_BACKGROUND_COLOR_FOR_NEXT_POST(190);
> 
> sets background color for the next notification
> 6 = red
> 184 = green
> 190 = yellow
> 
> Here is a list of some colors that can be used: https://i.gyazo.com/68bd384455fceb0a85a8729e48216e15.gif

## THEFEED_SET_FLASH_DURATION_PARAMETER_FOR_NEXT_MESSAGE

```c
void THEFEED_SET_FLASH_DURATION_PARAMETER_FOR_NEXT_MESSAGE(int count)  // 0x17AD8C9706BDD88A
```

build 323 · old names: `_THEFEED_SET_ANIMPOSTFX_COUNT`

> Related to notification color flashing, setting count to 0 invalidates a `THEFEED_SET_RGBA_PARAMETER_FOR_NEXT_MESSAGE` call for the target notification.

## THEFEED_SET_RGBA_PARAMETER_FOR_NEXT_MESSAGE

```c
void THEFEED_SET_RGBA_PARAMETER_FOR_NEXT_MESSAGE(int red, int green, int blue, int alpha)  // 0x17430B918701C342
```

build 323 · old names: `_SET_NOTIFICATION_FLASH_COLOR`, `_THEFEED_SET_ANIMPOSTFX_COLOR`

## THEFEED_SET_SCRIPTED_MENU_HEIGHT

```c
void THEFEED_SET_SCRIPTED_MENU_HEIGHT(float pos)  // 0x55598D21339CB998
```

build 323 · old names: `_CLEAR_NOTIFICATIONS_POS`

## THEFEED_SET_SNAP_FEED_ITEM_POSITIONS

```c
void THEFEED_SET_SNAP_FEED_ITEM_POSITIONS(BOOL p0)  // 0xBAE4F9B97CD43B30
```

build 323 · old names: `_THEFEED_SET_FLUSH_ANIMPOSTFX`

## THEFEED_SET_VIBRATE_PARAMETER_FOR_NEXT_MESSAGE

```c
void THEFEED_SET_VIBRATE_PARAMETER_FOR_NEXT_MESSAGE(BOOL toggle)  // 0x4A0C7C9BB10ABB36
```

build 323 · old names: `_THEFEED_SET_ANIMPOSTFX_SOUND`

## THEFEED_SHOW

```c
void THEFEED_SHOW()  // 0x15CFA549788D35EF
```

build 463 · old names: `_THEFEED_ENABLE`, `_THEFEED_DISPLAY_LOADING_SCREEN_TIPS`

> Displays loading screen tips, requires `THEFEED_AUTO_POST_GAMETIPS_ON` to be called beforehand.

## THEFEED_UPDATE_ITEM_TEXTURE

```c
void THEFEED_UPDATE_ITEM_TEXTURE(const char* txdString1, const char* txnString1, const char* txdString2, const char* txnString2)  // 0x317EBA71D7543F52
```

build 323 · old names: `_THEFEED_ADD_TXD_REF`

> Used in the native scripts to reference "GET_PEDHEADSHOT_TXD_STRING" and "CHAR_DEFAULT".

## TOGGLE_STEALTH_RADAR

```c
void TOGGLE_STEALTH_RADAR(BOOL toggle)  // 0x6AFDFB93754950C7
```

build 323

## TRIGGER_SONAR_BLIP

```c
void TRIGGER_SONAR_BLIP(float posX, float posY, float posZ, float radius, int p4)  // 0x72DD432F3CDFC0EE
```

build 323

## UNLOCK_MINIMAP_ANGLE

```c
void UNLOCK_MINIMAP_ANGLE()  // 0x8183455E16C42E3A
```

build 323

## UNLOCK_MINIMAP_POSITION

```c
void UNLOCK_MINIMAP_POSITION()  // 0x3E93E06DB8EF1F30
```

build 323

## UPDATE_RADAR_ZOOM_TO_BLIP

```c
void UPDATE_RADAR_ZOOM_TO_BLIP()  // 0xD2049635DEB9C375
```

build 323

> Does nothing (it's a nullsub).

## USE_FAKE_MP_CASH

```c
void USE_FAKE_MP_CASH(BOOL toggle)  // 0x170F541E1CADD1DE
```

build 323

> Related to displaying cash on the HUD
> Always called before HUD::CHANGE_FAKE_MP_CASH in decompiled scripts

## USE_VEHICLE_TARGETING_RETICULE

```c
void USE_VEHICLE_TARGETING_RETICULE(Any p0)  // 0x0C698D8F099174C7
```

build 1180

