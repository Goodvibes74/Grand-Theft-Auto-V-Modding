# AUDIO natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _ENABLE_DRAG_RACE_STATIONARY_WARNING_SOUNDS

```c
void _ENABLE_DRAG_RACE_STATIONARY_WARNING_SOUNDS(Vehicle vehicle, BOOL enable)  // 0xBEFB80290414FD4F
```

build 3095

## _FORCE_VEHICLE_ENGINE_SYNTH

```c
void _FORCE_VEHICLE_ENGINE_SYNTH(Vehicle vehicle, BOOL force)  // 0xEB7D0E1FCC8FE17A
```

build 3258

> Called together with SET_VEHICLE_TYRES_CAN_BURST

## ACTIVATE_AUDIO_SLOWMO_MODE

```c
void ACTIVATE_AUDIO_SLOWMO_MODE(const char* mode)  // 0xD01005D2BA2EB778
```

build 323

> mode can be any of these: 
> SLOWMO_T1_TRAILER_SMASH
> SLOWMO_T1_RAYFIRE_EXPLOSION
> SLOWMO_PROLOGUE_VAULT
> NIGEL_02_SLOWMO_SETTING
> JSH_EXIT_TUNNEL_SLOWMO
> SLOWMO_BIG_SCORE_JUMP
> SLOWMO_FIB4_TRUCK_SMASH
> SLOWMO_EXTREME_04
> SLOW_MO_METH_HOUSE_RAYFIRE
> BARRY_02_SLOWMO
> BARRY_01_SLOWMO

## ADD_ENTITY_TO_AUDIO_MIX_GROUP

```c
void ADD_ENTITY_TO_AUDIO_MIX_GROUP(Entity entity, const char* groupName, float p2)  // 0x153973AB99FE8980
```

build 323 · old names: `_DYNAMIC_MIXER_RELATED_FN`

> All found occurrences in b678d:
> https://pastebin.com/ceu67jz8

## ADD_LINE_TO_CONVERSATION

```c
void ADD_LINE_TO_CONVERSATION(int index, const char* p1, const char* p2, int p3, int p4, BOOL p5, BOOL p6, BOOL p7, BOOL p8, int p9, BOOL p10, BOOL p11, BOOL p12)  // 0xC5EF963405593646
```

build 323

> NOTE: ones that are -1, 0 - 35 are determined by a function where it gets a TextLabel from a global then runs,
> GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME and depending on what the result is it goes in check order of 0 - 9 then A - Z then z (lowercase). So it will then return 0 - 35 or -1 if it's 'z'. The func to handle that ^^ is func_67 in dialog_handler.c atleast in TU27 Xbox360 scripts.
> 
> p0 is -1, 0 - 35
> p1 is a char or string (whatever you wanna call it)
> p2 is Global 10597 + i * 6. 'i' is a while(i < 70) loop
> p3 is again -1, 0 - 35 
> p4 is again -1, 0 - 35 
> p5 is either 0 or 1 (bool ?)
> p6 is either 0 or 1 (The func to determine this is bool)
> p7 is either 0 or 1 (The func to determine this is bool)
> p8 is either 0 or 1 (The func to determine this is bool)
> p9 is 0 - 3 (Determined by func_60 in dialogue_handler.c)
> p10 is either 0 or 1 (The func to determine this is bool)
> p11 is either 0 or 1 (The func to determine this is bool)
> p12 is unknown as in TU27 X360 scripts it only goes to p11.

## ADD_PED_TO_CONVERSATION

```c
void ADD_PED_TO_CONVERSATION(int index, Ped ped, const char* p2)  // 0x95D9F4BC443956E7
```

build 323

> 4 calls in the b617d scripts. The only one with p0 and p2 in clear text:
> 
> AUDIO::ADD_PED_TO_CONVERSATION(5, l_AF, "DINAPOLI");
> 
> =================================================
> One of the 2 calls in dialogue_handler.c p0 is in a while-loop, and so is determined to also possibly be 0 - 15.

## AUDIO_IS_MUSIC_PLAYING

```c
BOOL AUDIO_IS_MUSIC_PLAYING()  // 0x845FFC3A4FEEFA3E
```

build 323 · old names: `AUDIO_IS_SCRIPTED_MUSIC_PLAYING`

## AUDIO_IS_SCRIPTED_MUSIC_PLAYING

```c
BOOL AUDIO_IS_SCRIPTED_MUSIC_PLAYING()  // 0x2DD39BF3E2F9C47F
```

build 463 · old names: `_AUDIO_IS_SCRIPTED_MUSIC_PLAYING_2`

> This is an alias of AUDIO_IS_MUSIC_PLAYING.

## BLIP_SIREN

```c
void BLIP_SIREN(Vehicle vehicle)  // 0x1B9025BDA76822B6
```

build 323

> Plays the siren sound of a vehicle which is otherwise activated when fastly double-pressing the horn key.
> Only works on vehicles with a police siren.

## BLOCK_ALL_SPEECH_FROM_PED

```c
void BLOCK_ALL_SPEECH_FROM_PED(Ped ped, BOOL p1, BOOL p2)  // 0xF8AD2EED7C47E8FE
```

build 1734

## BLOCK_DEATH_JINGLE

```c
void BLOCK_DEATH_JINGLE(BOOL toggle)  // 0xF154B8D1775B2DEC
```

build 323

## BLOCK_SPEECH_CONTEXT_GROUP

```c
void BLOCK_SPEECH_CONTEXT_GROUP(const char* p0, int p1)  // 0xA8A7D434AFB4B97B
```

build 1493

## CAN_VEHICLE_RECEIVE_CB_RADIO

```c
BOOL CAN_VEHICLE_RECEIVE_CB_RADIO(Vehicle vehicle)  // 0x032A116663A4D5AC
```

build 323 · old names: `_IS_VEHICLE_RADIO_LOUD`

## CANCEL_ALL_POLICE_REPORTS

```c
void CANCEL_ALL_POLICE_REPORTS()  // 0xB4F90FAF7670B16F
```

build 323 · old names: `_DISABLE_POLICE_REPORTS`, `_CANCEL_CURRENT_POLICE_REPORT`

## CANCEL_MUSIC_EVENT

```c
BOOL CANCEL_MUSIC_EVENT(const char* eventName)  // 0x5B17A90291133DA5
```

build 323

> All music event names found in the b617d scripts: https://pastebin.com/GnYt0R3P
> Full list of music event names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/musicEventNames.json

## CLEAR_ALL_BROKEN_GLASS

```c
void CLEAR_ALL_BROKEN_GLASS()  // 0xB32209EFFDC04913
```

build 323

## CLEAR_AMBIENT_ZONE_LIST_STATE

```c
void CLEAR_AMBIENT_ZONE_LIST_STATE(const char* ambientZone, BOOL p1)  // 0x120C48C614909FA4
```

build 323

## CLEAR_AMBIENT_ZONE_STATE

```c
void CLEAR_AMBIENT_ZONE_STATE(const char* zoneName, BOOL p1)  // 0x218DD44AAAC964FF
```

build 323

> This function also has a p2, unknown. Signature AUDIO::CLEAR_AMBIENT_ZONE_STATE(const char* zoneName, bool p1, Any p2);
> 
> Still needs more research.
> 
> Full list of ambient zones by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ambientZones.json

## CLEAR_CUSTOM_RADIO_TRACK_LIST

```c
void CLEAR_CUSTOM_RADIO_TRACK_LIST(const char* radioStation)  // 0x1654F24A88A8E3FE
```

build 323

> 3 calls in the b617d scripts, removed duplicate.
> 
> AUDIO::CLEAR_CUSTOM_RADIO_TRACK_LIST("RADIO_16_SILVERLAKE");
> AUDIO::CLEAR_CUSTOM_RADIO_TRACK_LIST("RADIO_01_CLASS_ROCK");

## CREATE_NEW_SCRIPTED_CONVERSATION

```c
void CREATE_NEW_SCRIPTED_CONVERSATION()  // 0xD2C91A0B572AAE56
```

build 323

## DEACTIVATE_AUDIO_SLOWMO_MODE

```c
void DEACTIVATE_AUDIO_SLOWMO_MODE(const char* mode)  // 0xDDC635D5B3262C56
```

build 323

> see ACTIVATE_AUDIO_SLOWMO_MODE for modes

## DISABLE_PED_PAIN_AUDIO

```c
void DISABLE_PED_PAIN_AUDIO(Ped ped, BOOL toggle)  // 0xA9A41C1E940FB0E8
```

build 323

## DISTANT_COP_CAR_SIRENS

```c
void DISTANT_COP_CAR_SIRENS(BOOL value)  // 0x552369F549563AD5
```

build 323 · old names: `_FORCE_AMBIENT_SIREN`

> If value is set to true, and ambient siren sound will be played.
> Appears to enable/disable an audio flag.

## DOES_CONTEXT_EXIST_FOR_THIS_PED

```c
BOOL DOES_CONTEXT_EXIST_FOR_THIS_PED(Ped ped, const char* speechName, BOOL p2)  // 0x49B99BF3FDA89A7A
```

build 323 · old names: `_CAN_PED_SPEAK`

> Checks if the ped can play the speech or has the speech file, p2 is usually false.

## DOES_PLAYER_VEH_HAVE_RADIO

```c
BOOL DOES_PLAYER_VEH_HAVE_RADIO()  // 0x109697E2FFBAC8A1
```

build 323

## ENABLE_STALL_WARNING_SOUNDS

```c
void ENABLE_STALL_WARNING_SOUNDS(Vehicle vehicle, BOOL toggle)  // 0xC15907D667F7CFB2
```

build 323

> Works for planes only.

## ENABLE_STUNT_JUMP_AUDIO

```c
void ENABLE_STUNT_JUMP_AUDIO()  // 0xB81CF134AEB56FFB
```

build 791

## ENABLE_VEHICLE_EXHAUST_POPS

```c
void ENABLE_VEHICLE_EXHAUST_POPS(Vehicle vehicle, BOOL toggle)  // 0x2BE4BC731D039D5A
```

build 323

## ENABLE_VEHICLE_FANBELT_DAMAGE

```c
void ENABLE_VEHICLE_FANBELT_DAMAGE(Vehicle vehicle, BOOL toggle)  // 0x1C073274E065C6D2
```

build 323

## FIND_RADIO_STATION_INDEX

```c
int FIND_RADIO_STATION_INDEX(Hash stationNameHash)  // 0x8D67489793FF428B
```

build 323

## FORCE_MUSIC_TRACK_LIST

```c
void FORCE_MUSIC_TRACK_LIST(const char* radioStation, const char* trackListName, int milliseconds)  // 0x4E0AF9114608257C
```

build 2372 · old names: `_FORCE_RADIO_TRACK_LIST_POSITION`

> Changes start time of a tracklist (milliseconds)
> R* uses a random int: MISC::GET_RANDOM_INT_IN_RANGE(0, 13) * 60000)

## FORCE_PED_PANIC_WALLA

```c
void FORCE_PED_PANIC_WALLA()  // 0x062D5EAD4DA2FA6A
```

build 323

## FORCE_USE_AUDIO_GAME_OBJECT

```c
void FORCE_USE_AUDIO_GAME_OBJECT(Vehicle vehicle, const char* audioName)  // 0x4F0C413926060B38
```

build 323 · old names: `_SET_VEHICLE_AUDIO`, `_FORCE_VEHICLE_ENGINE_AUDIO`

> This native sets the audio of the specified vehicle to the audioName (p1).
> 
> Use the audioNameHash found in vehicles.meta
> 
> Example:
> FORCE_USE_AUDIO_GAME_OBJECT(veh, "ADDER");
> The selected vehicle will now have the audio of the Adder.

## FREEZE_MICROPHONE

```c
void FREEZE_MICROPHONE()  // 0xD57AAAE0E2214D11
```

build 323

## FREEZE_RADIO_STATION

```c
void FREEZE_RADIO_STATION(const char* radioStation)  // 0x344F393B027E38C3
```

build 323

## GET_AMBIENT_VOICE_NAME_HASH

```c
Hash GET_AMBIENT_VOICE_NAME_HASH(Ped ped)  // 0x5E203DA2BA15D436
```

build 463 · old names: `_GET_AMBIENT_VOICE_NAME_HASH`

## GET_AUDIBLE_MUSIC_TRACK_TEXT_ID

```c
int GET_AUDIBLE_MUSIC_TRACK_TEXT_ID()  // 0x50B196FC9ED6545B
```

build 323

## GET_CURRENT_SCRIPTED_CONVERSATION_LINE

```c
int GET_CURRENT_SCRIPTED_CONVERSATION_LINE()  // 0x480357EE890C295A
```

build 323

## GET_CURRENT_TRACK_PLAY_TIME

```c
int GET_CURRENT_TRACK_PLAY_TIME(const char* radioStationName)  // 0x3E65CDE5215832C1
```

build 1493 · old names: `_GET_CURRENT_RADIO_TRACK_PLAYBACK_TIME`

## GET_CURRENT_TRACK_SOUND_NAME

```c
Hash GET_CURRENT_TRACK_SOUND_NAME(const char* radioStationName)  // 0x34D66BC058019CE0
```

build 1493 · old names: `_GET_CURRENT_RADIO_TRACK_NAME`

## GET_CURRENT_TV_SHOW_PLAY_TIME

```c
int GET_CURRENT_TV_SHOW_PLAY_TIME()  // 0xDD3AA743AB7D4D75
```

build 3095

## GET_IS_PRELOADED_CONVERSATION_READY

```c
BOOL GET_IS_PRELOADED_CONVERSATION_READY()  // 0xE73364DB90778FFA
```

build 323

## GET_MUSIC_PLAYTIME

```c
int GET_MUSIC_PLAYTIME()  // 0xE7A0D23DC414507B
```

build 323

## GET_MUSIC_VOL_SLIDER

```c
int GET_MUSIC_VOL_SLIDER()  // 0x3A48AB4445D499BE
```

build 323

## GET_NETWORK_ID_FROM_SOUND_ID

```c
int GET_NETWORK_ID_FROM_SOUND_ID(int soundId)  // 0x2DE3F0A134FFBC0D
```

build 323

## GET_NEXT_AUDIBLE_BEAT

```c
BOOL GET_NEXT_AUDIBLE_BEAT(float* out1, float* out2, int* out3)  // 0xC64A06D939F826F5
```

build 1493

## GET_NUM_UNLOCKED_RADIO_STATIONS

```c
int GET_NUM_UNLOCKED_RADIO_STATIONS()  // 0xF1620ECB50E01DE7
```

build 323 · old names: `_MAX_RADIO_STATION_INDEX`

## GET_PLAYER_RADIO_STATION_GENRE

```c
int GET_PLAYER_RADIO_STATION_GENRE()  // 0xA571991A7FE6CCEB
```

build 323

## GET_PLAYER_RADIO_STATION_INDEX

```c
int GET_PLAYER_RADIO_STATION_INDEX()  // 0xE8AF77C4C06ADC93
```

build 323

> Returns 255 (radio off index) if the function fails.

## GET_PLAYER_RADIO_STATION_NAME

```c
const char* GET_PLAYER_RADIO_STATION_NAME()  // 0xF6D733C32076AD03
```

build 323

> Returns active radio station name

## GET_RADIO_STATION_NAME

```c
const char* GET_RADIO_STATION_NAME(int radioStation)  // 0xB28ECA15046CA8B9
```

build 323

> Converts radio station index to string. Use HUD::GET_FILENAME_FOR_AUDIO_CONVERSATION to get the user-readable text.

## GET_SOUND_ID

```c
int GET_SOUND_ID()  // 0x430386FE9BF80B45
```

build 323

## GET_SOUND_ID_FROM_NETWORK_ID

```c
int GET_SOUND_ID_FROM_NETWORK_ID(int netId)  // 0x75262FD12D0A1C84
```

build 323

## GET_STREAM_PLAY_TIME

```c
int GET_STREAM_PLAY_TIME()  // 0x4E72BBDBCA58A3DB
```

build 323

## GET_VARIATION_CHOSEN_FOR_SCRIPTED_LINE

```c
int GET_VARIATION_CHOSEN_FOR_SCRIPTED_LINE(Any* p0)  // 0xAA19F5572C38B564
```

build 323

## GET_VEHICLE_DEFAULT_HORN

```c
Hash GET_VEHICLE_DEFAULT_HORN(Vehicle vehicle)  // 0x02165D55000219AC
```

build 323

> Returns hash of default vehicle horn
> 
> Hash is stored in audVehicleAudioEntity

## GET_VEHICLE_DEFAULT_HORN_IGNORE_MODS

```c
Hash GET_VEHICLE_DEFAULT_HORN_IGNORE_MODS(Vehicle vehicle)  // 0xACB5DCCA1EC76840
```

build 323 · old names: `_GET_VEHICLE_HORN_HASH`

## GET_VEHICLE_HORN_SOUND_INDEX

```c
int GET_VEHICLE_HORN_SOUND_INDEX(Vehicle vehicle)  // 0xD53F3A29BCE2580E
```

build 1365 · old names: `_GET_VEHICLE_DEFAULT_HORN_VARIATION`

## HAS_LOADED_MP_DATA_SET

```c
BOOL HAS_LOADED_MP_DATA_SET()  // 0x544810ED9DB6BBE6
```

build 323 · old names: `_HAS_MULTIPLAYER_AUDIO_DATA_LOADED`

## HAS_LOADED_SP_DATA_SET

```c
BOOL HAS_LOADED_SP_DATA_SET()  // 0x5B50ABB1FE3746F4
```

build 323 · old names: `_HAS_MULTIPLAYER_AUDIO_DATA_UNLOADED`

## HAS_SOUND_FINISHED

```c
BOOL HAS_SOUND_FINISHED(int soundId)  // 0xFCBDCE714A7C88E5
```

build 323

## HINT_AMBIENT_AUDIO_BANK

```c
BOOL HINT_AMBIENT_AUDIO_BANK(const char* audioBank, BOOL p1, Any p2)  // 0x8F8C0E370AE62F5C
```

build 323

> p2 is always -1

## HINT_MISSION_AUDIO_BANK

```c
BOOL HINT_MISSION_AUDIO_BANK(const char* audioBank, BOOL p1, Any p2)  // 0x40763EA7B9B783E7
```

build 573

> p2 is always -1

## HINT_SCRIPT_AUDIO_BANK

```c
BOOL HINT_SCRIPT_AUDIO_BANK(const char* audioBank, BOOL p1, Any p2)  // 0xFB380A29641EC31A
```

build 323

> p2 is always -1

## INIT_SYNCH_SCENE_AUDIO_WITH_ENTITY

```c
void INIT_SYNCH_SCENE_AUDIO_WITH_ENTITY(const char* audioEvent, Entity entity)  // 0x950A154B8DAB6185
```

build 323 · old names: `_SET_SYNCHRONIZED_AUDIO_EVENT_POSITION_THIS_FRAME`

## INIT_SYNCH_SCENE_AUDIO_WITH_POSITION

```c
void INIT_SYNCH_SCENE_AUDIO_WITH_POSITION(const char* audioEvent, float x, float y, float z)  // 0xC8EDE9BDBCCBA6D4
```

build 323

## INTERRUPT_CONVERSATION

```c
void INTERRUPT_CONVERSATION(Ped ped, const char* voiceline, const char* speaker)  // 0xA018A12E5C5C2FA6
```

build 323

> Example from carsteal3.c: AUDIO::INTERRUPT_CONVERSATION(PLAYER::PLAYER_PED_ID(), "CST4_CFAA", "FRANKLIN");
> Voicelines can be found in GTAV\x64\audio\sfx in files starting with "SS_" which seems to mean scripted speech.

## INTERRUPT_CONVERSATION_AND_PAUSE

```c
void INTERRUPT_CONVERSATION_AND_PAUSE(Ped ped, const char* p1, const char* speaker)  // 0x8A694D7A68F8DC38
```

build 323

> One call found in the b617d scripts:
> 
> AUDIO::INTERRUPT_CONVERSATION_AND_PAUSE(NETWORK::NET_TO_PED(l_3989._f26F[0/*1*/]), "CONV_INTERRUPT_QUIT_IT", "LESTER");

## IS_ALARM_PLAYING

```c
BOOL IS_ALARM_PLAYING(const char* alarmName)  // 0x226435CB96CCFC8C
```

build 323

> Example:
> 
> bool playing = AUDIO::IS_ALARM_PLAYING("PORT_OF_LS_HEIST_FORT_ZANCUDO_ALARMS");
> Full list of alarm names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/alarmSounds.json

## IS_AMBIENT_SPEECH_DISABLED

```c
BOOL IS_AMBIENT_SPEECH_DISABLED(Ped ped)  // 0x932C2D096A2C3FFF
```

build 323

> Common in the scripts:
> AUDIO::IS_AMBIENT_SPEECH_DISABLED(PLAYER::PLAYER_PED_ID());

## IS_AMBIENT_SPEECH_PLAYING

```c
BOOL IS_AMBIENT_SPEECH_PLAYING(Ped ped)  // 0x9072C8B49907BFAD
```

build 323

## IS_AMBIENT_ZONE_ENABLED

```c
BOOL IS_AMBIENT_ZONE_ENABLED(const char* ambientZone)  // 0x01E2817A479A7F9B
```

build 323

> Full list of ambient zones by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ambientZones.json

## IS_ANIMAL_VOCALIZATION_PLAYING

```c
BOOL IS_ANIMAL_VOCALIZATION_PLAYING(Ped pedHandle)  // 0xC265DF9FB44A9FBD
```

build 323

## IS_ANY_POSITIONAL_SPEECH_PLAYING

```c
BOOL IS_ANY_POSITIONAL_SPEECH_PLAYING()  // 0x30CA2EF91D15ADF8
```

build 2189

## IS_ANY_SPEECH_PLAYING

```c
BOOL IS_ANY_SPEECH_PLAYING(Ped ped)  // 0x729072355FA39EC9
```

build 323

## IS_AUDIO_SCENE_ACTIVE

```c
BOOL IS_AUDIO_SCENE_ACTIVE(const char* scene)  // 0xB65B60556E2A9225
```

build 323

> Full list of audio scene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/audioSceneNames.json

## IS_GAME_IN_CONTROL_OF_MUSIC

```c
BOOL IS_GAME_IN_CONTROL_OF_MUSIC()  // 0x6D28DC1671E334FD
```

build 323

> Hardcoded to return 1

## IS_HORN_ACTIVE

```c
BOOL IS_HORN_ACTIVE(Vehicle vehicle)  // 0x9D6BFC12B05C6121
```

build 323

> Checks whether the horn of a vehicle is currently played.

## IS_MISSION_COMPLETE_PLAYING

```c
BOOL IS_MISSION_COMPLETE_PLAYING()  // 0x19A30C23F5827F8A
```

build 323

## IS_MISSION_COMPLETE_READY_FOR_UI

```c
BOOL IS_MISSION_COMPLETE_READY_FOR_UI()  // 0x6F259F82D873B8B8
```

build 323

## IS_MISSION_NEWS_STORY_UNLOCKED

```c
BOOL IS_MISSION_NEWS_STORY_UNLOCKED(int newsStory)  // 0x66E49BF55B4B1874
```

build 323 · old names: `GET_NUMBER_OF_PASSENGER_VOICE_VARIATIONS`

## IS_MOBILE_INTERFERENCE_ACTIVE

```c
BOOL IS_MOBILE_INTERFERENCE_ACTIVE()  // 0xC8B1B2425604CDD0
```

build 323

## IS_MOBILE_PHONE_CALL_ONGOING

```c
BOOL IS_MOBILE_PHONE_CALL_ONGOING()  // 0x7497D2CE2C30D24C
```

build 323

## IS_MOBILE_PHONE_RADIO_ACTIVE

```c
BOOL IS_MOBILE_PHONE_RADIO_ACTIVE()  // 0xB35CE999E8EF317E
```

build 323

## IS_MUSIC_ONESHOT_PLAYING

```c
BOOL IS_MUSIC_ONESHOT_PLAYING()  // 0xA097AB275061FB21
```

build 323

## IS_PED_IN_CURRENT_CONVERSATION

```c
BOOL IS_PED_IN_CURRENT_CONVERSATION(Ped ped)  // 0x049E937F18F4020C
```

build 323

## IS_PED_RINGTONE_PLAYING

```c
BOOL IS_PED_RINGTONE_PLAYING(Ped ped)  // 0x1E8E5E20937E3137
```

build 323

## IS_PLAYER_VEH_RADIO_ENABLE

```c
BOOL IS_PLAYER_VEH_RADIO_ENABLE()  // 0x5F43D83FD6738741
```

build 323 · old names: `_IS_PLAYER_VEHICLE_RADIO_ENABLED`

## IS_RADIO_FADED_OUT

```c
BOOL IS_RADIO_FADED_OUT()  // 0x0626A247D2405330
```

build 323

## IS_RADIO_RETUNING

```c
BOOL IS_RADIO_RETUNING()  // 0xA151A7394A214E65
```

build 323

## IS_RADIO_STATION_FAVOURITED

```c
BOOL IS_RADIO_STATION_FAVOURITED(const char* radioStation)  // 0x2B1784DB08AFEA79
```

build 2699 · old names: `_IS_RADIO_STATION_VISIBLE`

## IS_SCRIPTED_CONVERSATION_LOADED

```c
BOOL IS_SCRIPTED_CONVERSATION_LOADED()  // 0xDF0D54BE7A776737
```

build 323

## IS_SCRIPTED_CONVERSATION_ONGOING

```c
BOOL IS_SCRIPTED_CONVERSATION_ONGOING()  // 0x16754C556D2EDE3D
```

build 323

## IS_SCRIPTED_SPEECH_PLAYING

```c
BOOL IS_SCRIPTED_SPEECH_PLAYING(Ped p0)  // 0xCC9AA18DCC7084F4
```

build 323

## IS_STREAM_PLAYING

```c
BOOL IS_STREAM_PLAYING()  // 0xD11FA52EB849D978
```

build 323

## IS_VEHICLE_AUDIBLY_DAMAGED

```c
BOOL IS_VEHICLE_AUDIBLY_DAMAGED(Vehicle vehicle)  // 0x5DB8010EE71FDEF2
```

build 323

## IS_VEHICLE_RADIO_ON

```c
BOOL IS_VEHICLE_RADIO_ON(Vehicle vehicle)  // 0x0BE4BE946463F917
```

build 505 · old names: `_IS_VEHICLE_RADIO_ENABLED`

## LINK_STATIC_EMITTER_TO_ENTITY

```c
void LINK_STATIC_EMITTER_TO_ENTITY(const char* emitterName, Entity entity)  // 0x651D3228960D08AF
```

build 505 · old names: `_LINK_STATIC_EMITTER_TO_ENTITY`

> Full list of static emitters by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/staticEmitters.json

## LOAD_STREAM

```c
BOOL LOAD_STREAM(const char* streamName, const char* soundSet)  // 0x1F1F957154EC51DF
```

build 323

> Example:
> AUDIO::LOAD_STREAM("CAR_STEAL_1_PASSBY", "CAR_STEAL_1_SOUNDSET");
> 
> All found occurrences in the b678d decompiled scripts: https://pastebin.com/3rma6w5w
> 
> Stream names often ends with "_MASTER", "_SMALL" or "_STREAM". Also "_IN", "_OUT" and numbers.   
> 
> soundSet is often set to 0 in the scripts. These are common to end the soundSets: "_SOUNDS", "_SOUNDSET" and numbers.
> 
> Full list of audio / sound names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/soundNames.json

## LOAD_STREAM_WITH_START_OFFSET

```c
BOOL LOAD_STREAM_WITH_START_OFFSET(const char* streamName, int startOffset, const char* soundSet)  // 0x59C16B79F53B3712
```

build 323

> Example:
> AUDIO::LOAD_STREAM_WITH_START_OFFSET("STASH_TOXIN_STREAM", 2400, "FBI_05_SOUNDS");
> 
> Only called a few times in the scripts.
> 
> Full list of audio / sound names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/soundNames.json

## LOCK_RADIO_STATION

```c
void LOCK_RADIO_STATION(const char* radioStationName, BOOL toggle)  // 0x477D9DB48F889591
```

build 1493 · old names: `_SET_RADIO_STATION_DISABLED`, `_LOCK_RADIO_STATION`

> Disables the radio station (hides it from the radio wheel).

## LOCK_RADIO_STATION_TRACK_LIST

```c
void LOCK_RADIO_STATION_TRACK_LIST(const char* radioStation, const char* trackListName)  // 0xFF5E5EA2DCEEACF3
```

build 2372 · old names: `_LOCK_RADIO_STATION_TRACK_LIST`

## OVERRIDE_MICROPHONE_SETTINGS

```c
void OVERRIDE_MICROPHONE_SETTINGS(Hash hash, BOOL toggle)  // 0x75773E11BA459E90
```

build 323 · old names: `_OVERRIDE_MICROPHONE_SETTINGS`

> Sets audio flag "OverrideMicrophoneSettings"

## OVERRIDE_PLAYER_GROUND_MATERIAL

```c
void OVERRIDE_PLAYER_GROUND_MATERIAL(Hash hash, BOOL toggle)  // 0xD2CC78CD3D0B50F9
```

build 323

> Sets audio flag "OverridePlayerGroundMaterial"

## OVERRIDE_TREVOR_RAGE

```c
void OVERRIDE_TREVOR_RAGE(const char* voiceEffect)  // 0x13AD665062541A7E
```

build 323

> This native enables the audio flag "TrevorRageIsOverridden" and sets the voice effect to `voiceEffect`

## OVERRIDE_UNDERWATER_STREAM

```c
void OVERRIDE_UNDERWATER_STREAM(const char* p0, BOOL p1)  // 0xF2A9CDABCEA04BD6
```

build 323

## OVERRIDE_VEH_HORN

```c
void OVERRIDE_VEH_HORN(Vehicle vehicle, BOOL override, int hornHash)  // 0x3CDC1E622CCE0356
```

build 323

> Overrides the vehicle's horn hash.
> When changing this hash on a vehicle, it will not return the 'overwritten' hash. It will still always return the default horn hash (same as GET_VEHICLE_DEFAULT_HORN)
> 
> vehicle - the vehicle whose horn should be overwritten

## PAUSE_SCRIPTED_CONVERSATION

```c
void PAUSE_SCRIPTED_CONVERSATION(BOOL p0)  // 0x8530AD776CD72B12
```

build 323

## PLAY_AMBIENT_SPEECH_FROM_POSITION_NATIVE

```c
void PLAY_AMBIENT_SPEECH_FROM_POSITION_NATIVE(const char* speechName, const char* voiceName, float x, float y, float z, const char* speechParam)  // 0xED640017ED337E45
```

build 323 · old names: `_PLAY_AMBIENT_SPEECH_AT_COORDS`

> Full list of speeches and voices names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/speeches.json

## PLAY_ANIMAL_VOCALIZATION

```c
void PLAY_ANIMAL_VOCALIZATION(Ped pedHandle, int p1, const char* speechName)  // 0xEE066C7006C49C0A
```

build 323

> Plays sounds from a ped with chop model. For example it used to play bark or sniff sounds. p1 is always 3 or 4294967295 in decompiled scripts. By a quick disassembling I can assume that this arg is unused.
> This native is works only when you call it on the ped with right model (ac_chop only ?)
> Speech Name can be: CHOP_SNIFF_SEQ CHOP_WHINE CHOP_LICKS_MOUTH CHOP_PANT bark GROWL SNARL BARK_SEQ

## PLAY_DEFERRED_SOUND_FRONTEND

```c
void PLAY_DEFERRED_SOUND_FRONTEND(const char* soundName, const char* soundsetName)  // 0xCADA5A0D0702381E
```

build 323

> Only call found in the b617d scripts:
> 
> AUDIO::PLAY_DEFERRED_SOUND_FRONTEND("BACK", "HUD_FREEMODE_SOUNDSET");
> 
> Full list of audio / sound names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/soundNames.json

## PLAY_END_CREDITS_MUSIC

```c
void PLAY_END_CREDITS_MUSIC(BOOL play)  // 0xCD536C4D33DCC900
```

build 323

## PLAY_MISSION_COMPLETE_AUDIO

```c
void PLAY_MISSION_COMPLETE_AUDIO(const char* audioName)  // 0xB138AAB8A70D3C69
```

build 323

> Called 38 times in the scripts. There are 5 different audioNames used.
>  One unknown removed below.
> 
> AUDIO::PLAY_MISSION_COMPLETE_AUDIO("DEAD");
> AUDIO::PLAY_MISSION_COMPLETE_AUDIO("FRANKLIN_BIG_01");
> AUDIO::PLAY_MISSION_COMPLETE_AUDIO("GENERIC_FAILED");
> AUDIO::PLAY_MISSION_COMPLETE_AUDIO("TREVOR_SMALL_01");

## PLAY_PAIN

```c
void PLAY_PAIN(Ped ped, int painID, int p1, Any p3)  // 0xBC9AE166038A5CEC
```

build 323

> Needs another parameter [int p2]. The signature is PED::PLAY_PAIN(Ped ped, int painID, int p1, int p2);
> 
> Last 2 parameters always seem to be 0.
> 
> EX: Function.Call(Hash.PLAY_PAIN, TestPed, 6, 0, 0);
> 
> Known Pain IDs
> ________________________
> 
> 1 - Doesn't seem to do anything. Does NOT crash the game like previously said. (Latest patch)
> 6 - Scream (Short)
> 7 - Scared Scream (Kinda Long)
> 8 - On Fire
> 

## PLAY_PED_AMBIENT_SPEECH_AND_CLONE_NATIVE

```c
void PLAY_PED_AMBIENT_SPEECH_AND_CLONE_NATIVE(Ped ped, const char* speechName, const char* speechParam, Any p3)  // 0xC6941B4A3A8FBBB9
```

build 323 · old names: `_PLAY_AMBIENT_SPEECH2`

> Plays ambient speech. See also _0x5C57B85D.
> 
> See PLAY_PED_AMBIENT_SPEECH_NATIVE for parameter specifications.
> 
> Full list of speeches and voices names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/speeches.json

## PLAY_PED_AMBIENT_SPEECH_NATIVE

```c
void PLAY_PED_AMBIENT_SPEECH_NATIVE(Ped ped, const char* speechName, const char* speechParam, Any p3)  // 0x8E04FEDD28D42462
```

build 323 · old names: `_PLAY_AMBIENT_SPEECH1`

> Plays ambient speech. See also _0x444180DB.
> 
> ped: The ped to play the ambient speech.
> speechName: Name of the speech to play, eg. "GENERIC_HI".
> speechParam: Can be one of the following:
> SPEECH_PARAMS_STANDARD
> SPEECH_PARAMS_ALLOW_REPEAT
> SPEECH_PARAMS_BEAT
> SPEECH_PARAMS_FORCE
> SPEECH_PARAMS_FORCE_FRONTEND
> SPEECH_PARAMS_FORCE_NO_REPEAT_FRONTEND
> SPEECH_PARAMS_FORCE_NORMAL
> SPEECH_PARAMS_FORCE_NORMAL_CLEAR
> SPEECH_PARAMS_FORCE_NORMAL_CRITICAL
> SPEECH_PARAMS_FORCE_SHOUTED
> SPEECH_PARAMS_FORCE_SHOUTED_CLEAR
> SPEECH_PARAMS_FORCE_SHOUTED_CRITICAL
> SPEECH_PARAMS_FORCE_PRELOAD_ONLY
> SPEECH_PARAMS_MEGAPHONE
> SPEECH_PARAMS_HELI
> SPEECH_PARAMS_FORCE_MEGAPHONE
> SPEECH_PARAMS_FORCE_HELI
> SPEECH_PARAMS_INTERRUPT
> SPEECH_PARAMS_INTERRUPT_SHOUTED
> SPEECH_PARAMS_INTERRUPT_SHOUTED_CLEAR
> SPEECH_PARAMS_INTERRUPT_SHOUTED_CRITICAL
> SPEECH_PARAMS_INTERRUPT_NO_FORCE
> SPEECH_PARAMS_INTERRUPT_FRONTEND
> SPEECH_PARAMS_INTERRUPT_NO_FORCE_FRONTEND
> SPEECH_PARAMS_ADD_BLIP
> SPEECH_PARAMS_ADD_BLIP_ALLOW_REPEAT
> SPEECH_PARAMS_ADD_BLIP_FORCE
> SPEECH_PARAMS_ADD_BLIP_SHOUTED
> SPEECH_PARAMS_ADD_BLIP_SHOUTED_FORCE
> SPEECH_PARAMS_ADD_BLIP_INTERRUPT
> SPEECH_PARAMS_ADD_BLIP_INTERRUPT_FORCE
> SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED
> SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED_CLEAR
> SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED_CRITICAL
> SPEECH_PARAMS_SHOUTED
> SPEECH_PARAMS_SHOUTED_CLEAR
> SPEECH_PARAMS_SHOUTED_CRITICAL
> 
> Note: A list of Name and Parameters can be found here https://pastebin.com/1GZS5dCL
> 
> Full list of speeches and voices names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/speeches.json

## PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE

```c
void PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE(Ped ped, const char* speechName, const char* voiceName, const char* speechParam, BOOL p4)  // 0x3523634255FC3318
```

build 323 · old names: `_PLAY_AMBIENT_SPEECH_WITH_VOICE`

> This is the same as PLAY_PED_AMBIENT_SPEECH_NATIVE and PLAY_PED_AMBIENT_SPEECH_AND_CLONE_NATIVE but it will allow you to play a speech file from a specific voice file. It works on players and all peds, even animals.
> 
> EX (C#):
> GTA.Native.Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE, Game.Player.Character, "GENERIC_INSULT_HIGH", "s_m_y_sheriff_01_white_full_01", "SPEECH_PARAMS_FORCE_SHOUTED", 0);
> 
> The first param is the ped you want to play it on, the second is the speech name, the third is the voice name, the fourth is the speech param, and the last param is usually always 0.
> 
> Full list of speeches and voices names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/speeches.json

## PLAY_PED_AUDIO_EVENT_ANIM

```c
void PLAY_PED_AUDIO_EVENT_ANIM(Ped pedHandle, const char* audioEvent)  // 0xAD2191A6E3543189
```

build 3717

## PLAY_PED_RINGTONE

```c
void PLAY_PED_RINGTONE(const char* ringtoneName, Ped ped, BOOL p2)  // 0xF9E56683CA8E11A5
```

build 323

> All found occurrences in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/RFb4GTny
> 
> AUDIO::PLAY_PED_RINGTONE("Remote_Ring", PLAYER::PLAYER_PED_ID(), 1);
> AUDIO::PLAY_PED_RINGTONE("Dial_and_Remote_Ring", PLAYER::PLAYER_PED_ID(), 1);
> 

## PLAY_POLICE_REPORT

```c
int PLAY_POLICE_REPORT(const char* name, float p1)  // 0xDFEBD56D9BD1EB16
```

build 323

> Plays the given police radio message.
> 
> All found occurrences in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/GBnsQ5hr
> Full list of police report names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/policeReportNames.json

## PLAY_SOUND

```c
void PLAY_SOUND(int soundId, const char* audioName, const char* audioRef, BOOL p3, Any p4, BOOL p5)  // 0x7FF4944CC209192D
```

build 323

> All found occurrences in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/A8Ny8AHZ
> 
> Full list of audio / sound names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/soundNames.json

## PLAY_SOUND_FROM_COORD

```c
void PLAY_SOUND_FROM_COORD(int soundId, const char* audioName, float x, float y, float z, const char* audioRef, BOOL isNetwork, int range, BOOL p8)  // 0x8D8686B622B88120
```

build 323

> All found occurrences in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/eeFc5DiW
> 
> https://gtaforums.com/topic/795622-audio-for-mods
> 
> Full list of audio / sound names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/soundNames.json

## PLAY_SOUND_FROM_ENTITY

```c
void PLAY_SOUND_FROM_ENTITY(int soundId, const char* audioName, Entity entity, const char* audioRef, BOOL isNetwork, Any p5)  // 0xE65F427EB70AB1ED
```

build 323

> All found occurrences in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/f2A7vTj0 
> No changes made in b678d.
> 
> https://gtaforums.com/topic/795622-audio-for-mods
> 
> Full list of audio / sound names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/soundNames.json

## PLAY_SOUND_FROM_ENTITY_HASH

```c
void PLAY_SOUND_FROM_ENTITY_HASH(int soundId, Hash model, Entity entity, Hash soundSetHash, Any p4, Any p5)  // 0x5B9853296731E88D
```

build 877

> Only used with "formation_flying_blips_soundset" and "biker_formation_blips_soundset".
> p1 is always the model of p2

## PLAY_SOUND_FRONTEND

```c
void PLAY_SOUND_FRONTEND(int soundId, const char* audioName, const char* audioRef, BOOL p3)  // 0x67C540AA08E4A6F5
```

build 323

> List: https://pastebin.com/DCeRiaLJ
> 
> All occurrences as of Cayo Perico Heist DLC (b2189), sorted alphabetically and identical lines removed: https://git.io/JtLxM
> 
> Full list of audio / sound names by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/soundNames.json

## PLAY_STREAM_FROM_OBJECT

```c
void PLAY_STREAM_FROM_OBJECT(Object object)  // 0xEBAA9B64D76356FD
```

build 323

> Used with AUDIO::LOAD_STREAM
> 
> Example from finale_heist2b.c4:
> TASK::TASK_SYNCHRONIZED_SCENE(l_4C8[2/*14*/], l_4C8[2/*14*/]._f7, l_30A, "push_out_vault_l", 4.0, -1.5, 5, 713, 4.0, 0);
>                     PED::SET_SYNCHRONIZED_SCENE_PHASE(l_4C8[2/*14*/]._f7, 0.0);
>                     PED::FORCE_PED_AI_AND_ANIMATION_UPDATE(l_4C8[2/*14*/], 0, 0);
>                     PED::SET_PED_COMBAT_ATTRIBUTES(l_4C8[2/*14*/], 38, 1);
>                     PED::SET_BLOCKING_OF_NON_TEMPORARY_EVENTS(l_4C8[2/*14*/], 1);
>                     if (AUDIO::LOAD_STREAM("Gold_Cart_Push_Anim_01", "BIG_SCORE_3B_SOUNDS")) {
>                         AUDIO::PLAY_STREAM_FROM_OBJECT(l_36F[0/*1*/]);
>                     }

## PLAY_STREAM_FROM_PED

```c
void PLAY_STREAM_FROM_PED(Ped ped)  // 0x89049DD63C08B5D1
```

build 323

## PLAY_STREAM_FROM_POSITION

```c
void PLAY_STREAM_FROM_POSITION(float x, float y, float z)  // 0x21442F412E8DE56B
```

build 323 · old names: `SPECIAL_FRONTEND_EQUAL`

## PLAY_STREAM_FROM_VEHICLE

```c
void PLAY_STREAM_FROM_VEHICLE(Vehicle vehicle)  // 0xB70374A758007DFA
```

build 323

## PLAY_STREAM_FRONTEND

```c
void PLAY_STREAM_FRONTEND()  // 0x58FCE43488F9F5F4
```

build 323

## PLAY_SYNCHRONIZED_AUDIO_EVENT

```c
BOOL PLAY_SYNCHRONIZED_AUDIO_EVENT(int sceneID)  // 0x8B2FD4560E55DD2D
```

build 323

## PLAY_VEHICLE_DOOR_CLOSE_SOUND

```c
void PLAY_VEHICLE_DOOR_CLOSE_SOUND(Vehicle vehicle, int doorId)  // 0x62A456AA4769EF34
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## PLAY_VEHICLE_DOOR_OPEN_SOUND

```c
void PLAY_VEHICLE_DOOR_OPEN_SOUND(Vehicle vehicle, int doorId)  // 0x3A539D52857EA82D
```

build 323

> doorId: see SET_VEHICLE_DOOR_SHUT

## PRELOAD_SCRIPT_CONVERSATION

```c
void PRELOAD_SCRIPT_CONVERSATION(BOOL p0, BOOL p1, BOOL p2, BOOL p3)  // 0x3B3CAD6166916D87
```

build 323

## PRELOAD_SCRIPT_PHONE_CONVERSATION

```c
void PRELOAD_SCRIPT_PHONE_CONVERSATION(BOOL p0, BOOL p1)  // 0x6004BCB0E226AAEA
```

build 323

## PRELOAD_VEHICLE_AUDIO_BANK

```c
void PRELOAD_VEHICLE_AUDIO_BANK(Hash vehicleModel)  // 0xCA4CEA6AE0000A7E
```

build 1180 · old names: `_PRELOAD_VEHICLE_AUDIO`

## PREPARE_ALARM

```c
BOOL PREPARE_ALARM(const char* alarmName)  // 0x9D74AE343DB65533
```

build 323

> Example:
> 
> bool prepareAlarm = AUDIO::PREPARE_ALARM("PORT_OF_LS_HEIST_FORT_ZANCUDO_ALARMS");
> Full list of alarm names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/alarmSounds.json

## PREPARE_MUSIC_EVENT

```c
BOOL PREPARE_MUSIC_EVENT(const char* eventName)  // 0x1E5185B72EF5158A
```

build 323

> All music event names found in the b617d scripts: https://pastebin.com/GnYt0R3P
> Full list of music event names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/musicEventNames.json

## PREPARE_SYNCHRONIZED_AUDIO_EVENT

```c
BOOL PREPARE_SYNCHRONIZED_AUDIO_EVENT(const char* audioEvent, Any p1)  // 0xC7ABCACA4985A766
```

build 323

> p1 is always 0 in the scripts

## PREPARE_SYNCHRONIZED_AUDIO_EVENT_FOR_SCENE

```c
BOOL PREPARE_SYNCHRONIZED_AUDIO_EVENT_FOR_SCENE(int sceneID, const char* audioEvent)  // 0x029FE7CD1B7E2E75
```

build 323

## RECORD_BROKEN_GLASS

```c
void RECORD_BROKEN_GLASS(float x, float y, float z, float radius)  // 0xFBE20329593DEC9D
```

build 323

## REFRESH_CLOSEST_OCEAN_SHORELINE

```c
void REFRESH_CLOSEST_OCEAN_SHORELINE()  // 0x5D2BFAAB8D956E0E
```

build 573

## REGISTER_SCRIPT_WITH_AUDIO

```c
void REGISTER_SCRIPT_WITH_AUDIO(int p0)  // 0xC6ED9D5092438D91
```

build 323

> This native does absolutely nothing, just a nullsub

## RELEASE_AMBIENT_AUDIO_BANK

```c
void RELEASE_AMBIENT_AUDIO_BANK()  // 0x65475A218FFAA93D
```

build 323

## RELEASE_MISSION_AUDIO_BANK

```c
void RELEASE_MISSION_AUDIO_BANK()  // 0x0EC92A1BF0857187
```

build 323

## RELEASE_NAMED_SCRIPT_AUDIO_BANK

```c
void RELEASE_NAMED_SCRIPT_AUDIO_BANK(const char* audioBank)  // 0x77ED170667F50170
```

build 323

> Full list of script audio bank names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scriptAudioBankNames.json

## RELEASE_SCRIPT_AUDIO_BANK

```c
void RELEASE_SCRIPT_AUDIO_BANK()  // 0x7A2D8AD0A9EB9C3F
```

build 323

## RELEASE_SOUND_ID

```c
void RELEASE_SOUND_ID(int soundId)  // 0x353FC880830B88FA
```

build 323

## RELEASE_WEAPON_AUDIO

```c
void RELEASE_WEAPON_AUDIO()  // 0xCE4AC0439F607045
```

build 323

## REMOVE_ENTITY_FROM_AUDIO_MIX_GROUP

```c
void REMOVE_ENTITY_FROM_AUDIO_MIX_GROUP(Entity entity, float p1)  // 0x18EB48CFC41F2EA0
```

build 323

## REMOVE_INDIVIDUAL_PORTAL_SETTINGS_OVERRIDE

```c
void REMOVE_INDIVIDUAL_PORTAL_SETTINGS_OVERRIDE(Hash interiorNameHash, int roomIndex, int doorIndex)  // 0x8EF105736194F80C
```

build 3570

## REMOVE_PORTAL_SETTINGS_OVERRIDE

```c
void REMOVE_PORTAL_SETTINGS_OVERRIDE(const char* p0)  // 0xB4BBFD9CD8B3922B
```

build 323

>  Found in the b617d scripts, duplicates removed: 
> 
>  AUDIO::REMOVE_PORTAL_SETTINGS_OVERRIDE("V_CARSHOWROOM_PS_WINDOW_UNBROKEN");
>  AUDIO::REMOVE_PORTAL_SETTINGS_OVERRIDE("V_CIA_PS_WINDOW_UNBROKEN");
>  AUDIO::REMOVE_PORTAL_SETTINGS_OVERRIDE("V_DLC_HEIST_APARTMENT_DOOR_CLOSED");
>  AUDIO::REMOVE_PORTAL_SETTINGS_OVERRIDE("V_FINALEBANK_PS_VAULT_INTACT");
>  AUDIO::REMOVE_PORTAL_SETTINGS_OVERRIDE("V_MICHAEL_PS_BATHROOM_WITH_WINDOW");

## REQUEST_AMBIENT_AUDIO_BANK

```c
BOOL REQUEST_AMBIENT_AUDIO_BANK(const char* audioBank, BOOL p1, Any p2)  // 0xFE02FFBED8CA9D99
```

build 323

> All occurrences and usages found in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/XZ1tmGEz
> Full list of ambient audio bank names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ambientAudioBankNames.json
> p2 is always -1

## REQUEST_MISSION_AUDIO_BANK

```c
BOOL REQUEST_MISSION_AUDIO_BANK(const char* audioBank, BOOL p1, Any p2)  // 0x7345BDD95E62E0F2
```

build 323

> All occurrences and usages found in b617d: https://pastebin.com/NzZZ2Tmm
> Full list of mission audio bank names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/missionAudioBankNames.json
> p2 is always -1

## REQUEST_SCRIPT_AUDIO_BANK

```c
BOOL REQUEST_SCRIPT_AUDIO_BANK(const char* audioBank, BOOL p1, Any p2)  // 0x2F844A8B08D76685
```

build 323

> All occurrences and usages found in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/AkmDAVn6
> Full list of script audio bank names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scriptAudioBankNames.json
> p2 is always -1

## REQUEST_TENNIS_BANKS

```c
void REQUEST_TENNIS_BANKS(Ped ped)  // 0x4ADA3F19BE4A6047
```

build 323 · old names: `_SET_PED_TALK`

## RESET_PED_AUDIO_FLAGS

```c
void RESET_PED_AUDIO_FLAGS(Ped ped)  // 0xF54BB7B61036F335
```

build 323

## RESET_TREVOR_RAGE

```c
void RESET_TREVOR_RAGE()  // 0xE78503B10C4314E0
```

build 323

## RESET_VEHICLE_STARTUP_REV_SOUND

```c
void RESET_VEHICLE_STARTUP_REV_SOUND(Vehicle vehicle)  // 0xD2DCCD8E16E20997
```

build 323 · old names: `_RESET_VEHICLE_STARTUP_REV_SOUND`

## RESTART_SCRIPTED_CONVERSATION

```c
void RESTART_SCRIPTED_CONVERSATION()  // 0x9AEB285D1818C9AC
```

build 323

## SCRIPT_OVERRIDES_WIND_ELEVATION

```c
void SCRIPT_OVERRIDES_WIND_ELEVATION(BOOL p0, Any p1)  // 0x70B8EC8FC108A634
```

build 323

## SET_AGGRESSIVE_HORNS

```c
void SET_AGGRESSIVE_HORNS(BOOL toggle)  // 0x395BF71085D1B1D9
```

build 323

> Makes pedestrians sound their horn longer, faster and more agressive when they use their horn.

## SET_AMBIENT_VOICE_NAME

```c
void SET_AMBIENT_VOICE_NAME(Ped ped, const char* name)  // 0x6C8065A3B780185B
```

build 323

> Audio List
> https://gtaforums.com/topic/795622-audio-for-mods/
> 
> All found occurrences in b617d, sorted alphabetically and identical lines removed: https://pastebin.com/FTeAj4yZ

## SET_AMBIENT_VOICE_NAME_HASH

```c
void SET_AMBIENT_VOICE_NAME_HASH(Ped ped, Hash hash)  // 0x9A53DED9921DE990
```

build 463 · old names: `_SET_AMBIENT_VOICE_NAME_HASH`

## SET_AMBIENT_ZONE_LIST_STATE

```c
void SET_AMBIENT_ZONE_LIST_STATE(const char* ambientZone, BOOL p1, BOOL p2)  // 0x9748FA4DE50CCE3E
```

build 323

## SET_AMBIENT_ZONE_LIST_STATE_PERSISTENT

```c
void SET_AMBIENT_ZONE_LIST_STATE_PERSISTENT(const char* ambientZone, BOOL p1, BOOL p2)  // 0xF3638DAE8C4045E1
```

build 323

> Full list of ambient zones by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ambientZones.json

## SET_AMBIENT_ZONE_STATE

```c
void SET_AMBIENT_ZONE_STATE(const char* zoneName, BOOL p1, BOOL p2)  // 0xBDA07E5950085E46
```

build 323

> Full list of ambient zones by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ambientZones.json

## SET_AMBIENT_ZONE_STATE_PERSISTENT

```c
void SET_AMBIENT_ZONE_STATE_PERSISTENT(const char* ambientZone, BOOL p1, BOOL p2)  // 0x1D6650420CEC9D3B
```

build 323

> Full list of ambient zones by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/ambientZones.json

## SET_ANIMAL_MOOD

```c
void SET_ANIMAL_MOOD(Ped animal, int mood)  // 0xCC97B29285B1DC3B
```

build 323

> mood can be 0 or 1 (it's not a boolean value!). Effects audio of the animal.

## SET_AUDIO_FLAG

```c
void SET_AUDIO_FLAG(const char* flagName, BOOL toggle)  // 0xB9EFD5C25018725A
```

build 323

> Possible flag names:
> "ActivateSwitchWheelAudio"
> "AllowAmbientSpeechInSlowMo"
> "AllowCutsceneOverScreenFade"
> "AllowForceRadioAfterRetune"
> "AllowPainAndAmbientSpeechToPlayDuringCutscene"
> "AllowPlayerAIOnMission"
> "AllowPoliceScannerWhenPlayerHasNoControl"
> "AllowRadioDuringSwitch"
> "AllowRadioOverScreenFade"
> "AllowScoreAndRadio"
> "AllowScriptedSpeechInSlowMo"
> "AvoidMissionCompleteDelay"
> "DisableAbortConversationForDeathAndInjury"
> "DisableAbortConversationForRagdoll"
> "DisableBarks"
> "DisableFlightMusic"
> "DisableReplayScriptStreamRecording"
> "EnableHeadsetBeep"
> "ForceConversationInterrupt"
> "ForceSeamlessRadioSwitch"
> "ForceSniperAudio"
> "FrontendRadioDisabled"
> "HoldMissionCompleteWhenPrepared"
> "IsDirectorModeActive"
> "IsPlayerOnMissionForSpeech"
> "ListenerReverbDisabled"
> "LoadMPData"
> "MobileRadioInGame"
> "OnlyAllowScriptTriggerPoliceScanner"
> "PlayMenuMusic"
> "PoliceScannerDisabled"
> "ScriptedConvListenerMaySpeak"
> "SpeechDucksScore"
> "SuppressPlayerScubaBreathing"
> "WantedMusicDisabled"
> "WantedMusicOnMission"
> 
> -------------------------------
> No added flag names between b393d and b573d, including b573d.
> 
> #######################################################################
> 
> "IsDirectorModeActive" is an audio flag which will allow you to play speech infinitely without any pauses like in Director Mode.
> 
> -----------------------------------------------------------------------
> 
> All flag IDs and hashes:
> 
> ID: 00 | Hash: 0x0FED7A7F
> ID: 01 | Hash: 0x20A7858F
> ID: 02 | Hash: 0xA11C2259
> ID: 03 | Hash: 0x08DE4700
> ID: 04 | Hash: 0x989F652F
> ID: 05 | Hash: 0x3C9E76BA
> ID: 06 | Hash: 0xA805FEB0
> ID: 07 | Hash: 0x4B94EA26
> ID: 08 | Hash: 0x803ACD34
> ID: 09 | Hash: 0x7C741226
> ID: 10 | Hash: 0x31DB9EBD
> ID: 11 | Hash: 0xDF386F18
> ID: 12 | Hash: 0x669CED42
> ID: 13 | Hash: 0x51F22743
> ID: 14 | Hash: 0x2052B35C
> ID: 15 | Hash: 0x071472DC
> ID: 16 | Hash: 0xF9928BCC
> ID: 17 | Hash: 0x7ADBDD48
> ID: 18 | Hash: 0xA959BA1A
> ID: 19 | Hash: 0xBBE89B60
> ID: 20 | Hash: 0x87A08871
> ID: 21 | Hash: 0xED1057CE
> ID: 22 | Hash: 0x1584AD7A
> ID: 23 | Hash: 0x8582CFCB
> ID: 24 | Hash: 0x7E5E2FB0
> ID: 25 | Hash: 0xAE4F72DB
> ID: 26 | Hash: 0x5D16D1FA
> ID: 27 | Hash: 0x06B2F4B8
> ID: 28 | Hash: 0x5D4CDC96
> ID: 29 | Hash: 0x8B5A48BA
> ID: 30 | Hash: 0x98FBD539
> ID: 31 | Hash: 0xD8CB0473
> ID: 32 | Hash: 0x5CBB4874
> ID: 33 | Hash: 0x2E9F93A9
> ID: 34 | Hash: 0xD93BEA86
> ID: 35 | Hash: 0x92109B7D
> ID: 36 | Hash: 0xB7EC9E4D
> ID: 37 | Hash: 0xCABDBB1D
> ID: 38 | Hash: 0xB3FD4A52
> ID: 39 | Hash: 0x370D94E5
> ID: 40 | Hash: 0xA0F7938F
> ID: 41 | Hash: 0xCBE1CE81
> ID: 42 | Hash: 0xC27F1271
> ID: 43 | Hash: 0x9E3258EB
> ID: 44 | Hash: 0x551CDA5B
> ID: 45 | Hash: 0xCB6D663C
> ID: 46 | Hash: 0x7DACE87F
> ID: 47 | Hash: 0xF9DE416F
> ID: 48 | Hash: 0x882E6E9E
> ID: 49 | Hash: 0x16B447E7
> ID: 50 | Hash: 0xBD867739
> ID: 51 | Hash: 0xA3A58604
> ID: 52 | Hash: 0x7E046BBC
> ID: 53 | Hash: 0xD95FDB98
> ID: 54 | Hash: 0x5842C0ED
> ID: 55 | Hash: 0x285FECC6
> ID: 56 | Hash: 0x9351AC43
> ID: 57 | Hash: 0x50032E75
> ID: 58 | Hash: 0xAE6D0D59
> ID: 59 | Hash: 0xD6351785
> ID: 60 | Hash: 0xD25D71BC
> ID: 61 | Hash: 0x1F7F6423
> ID: 62 | Hash: 0xE24C3AA6
> ID: 63 | Hash: 0xBFFDD2B7

## SET_AUDIO_SCENE_VARIABLE

```c
void SET_AUDIO_SCENE_VARIABLE(const char* scene, const char* variable, float value)  // 0xEF21A9EF089A2668
```

build 323

> Full list of audio scene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/audioSceneNames.json

## SET_AUDIO_SCRIPT_CLEANUP_TIME

```c
void SET_AUDIO_SCRIPT_CLEANUP_TIME(int time)  // 0xA5F377B175A699C5
```

build 323

## SET_AUDIO_SPECIAL_EFFECT_MODE

```c
void SET_AUDIO_SPECIAL_EFFECT_MODE(int mode)  // 0x12561FCBB62D5B9C
```

build 323

> Needs to be called every frame.
> Audio mode to apply this frame: https://alloc8or.re/gta5/doc/enums/audSpecialEffectMode.txt

## SET_AUDIO_VEHICLE_PRIORITY

```c
void SET_AUDIO_VEHICLE_PRIORITY(Vehicle vehicle, Any p1)  // 0xE5564483E407F914
```

build 323

## SET_CONVERSATION_AUDIO_CONTROLLED_BY_ANIM

```c
void SET_CONVERSATION_AUDIO_CONTROLLED_BY_ANIM(BOOL p0)  // 0x0B568201DD99F0EB
```

build 323

## SET_CONVERSATION_AUDIO_PLACEHOLDER

```c
void SET_CONVERSATION_AUDIO_PLACEHOLDER(BOOL p0)  // 0x61631F5DF50D1C34
```

build 323

## SET_CUSTOM_RADIO_TRACK_LIST

```c
void SET_CUSTOM_RADIO_TRACK_LIST(const char* radioStation, const char* trackListName, BOOL p2)  // 0x4E404A9361F75BB2
```

build 323

> Examples:
> 
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_01_CLASS_ROCK", "END_CREDITS_KILL_MICHAEL", 1);
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_01_CLASS_ROCK", "END_CREDITS_KILL_MICHAEL", 1);
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_01_CLASS_ROCK", "END_CREDITS_KILL_TREVOR", 1);
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_01_CLASS_ROCK", "END_CREDITS_SAVE_MICHAEL_TREVOR", 1);
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_01_CLASS_ROCK", "OFF_ROAD_RADIO_ROCK_LIST", 1);
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_06_COUNTRY", "MAGDEMO2_RADIO_DINGHY", 1);
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_16_SILVERLAKE", "SEA_RACE_RADIO_PLAYLIST", 1);
> AUDIO::SET_CUSTOM_RADIO_TRACK_LIST("RADIO_01_CLASS_ROCK", "OFF_ROAD_RADIO_ROCK_LIST", 1);

## SET_CUTSCENE_AUDIO_OVERRIDE

```c
void SET_CUTSCENE_AUDIO_OVERRIDE(const char* name)  // 0x3B4BF5F0859204D9
```

build 323

> All occurrences found in b617d, sorted alphabetically and identical lines removed: 
> 
> AUDIO::SET_CUTSCENE_AUDIO_OVERRIDE("_AK");
> AUDIO::SET_CUTSCENE_AUDIO_OVERRIDE("_CUSTOM");
> AUDIO::SET_CUTSCENE_AUDIO_OVERRIDE("_TOOTHLESS");
> Full list of cutscene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/cutsceneNames.json

## SET_EMITTER_RADIO_STATION

```c
void SET_EMITTER_RADIO_STATION(const char* emitterName, const char* radioStation, Any p2)  // 0xACF57305B12AF907
```

build 323

> Full list of static emitters by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/staticEmitters.json

## SET_ENTITY_FOR_NULL_CONV_PED

```c
void SET_ENTITY_FOR_NULL_CONV_PED(int p0, Entity entity)  // 0x892B6AB8F33606F5
```

build 323

## SET_FRONTEND_RADIO_ACTIVE

```c
void SET_FRONTEND_RADIO_ACTIVE(BOOL active)  // 0xF7F26C6E9CC9EBB8
```

build 323

## SET_GLOBAL_RADIO_SIGNAL_LEVEL

```c
void SET_GLOBAL_RADIO_SIGNAL_LEVEL(Any p0)  // 0x159B7318403A1CD8
```

build 1103

## SET_GPS_ACTIVE

```c
void SET_GPS_ACTIVE(BOOL active)  // 0x3BD3F52BA9B1E4E8
```

build 323

## SET_HORN_ENABLED

```c
void SET_HORN_ENABLED(Vehicle vehicle, BOOL toggle)  // 0x76D683C108594D0E
```

build 323

## SET_HORN_PERMANENTLY_ON

```c
void SET_HORN_PERMANENTLY_ON(Vehicle vehicle)  // 0x9C11908013EA4715
```

build 323 · old names: `_SOUND_VEHICLE_HORN_THIS_FRAME`

## SET_HORN_PERMANENTLY_ON_TIME

```c
void SET_HORN_PERMANENTLY_ON_TIME(Vehicle vehicle, float time)  // 0x9D3AF56E94C9AE98
```

build 323

## SET_INDIVIDUAL_PORTAL_SETTINGS_OVERRIDE

```c
void SET_INDIVIDUAL_PORTAL_SETTINGS_OVERRIDE(Hash interiorNameHash, int roomIndex, int doorIndex, const char* newPortalSettingsName)  // 0xC9D623C5A3D8FD5D
```

build 3570

## SET_INITIAL_PLAYER_STATION

```c
void SET_INITIAL_PLAYER_STATION(const char* radioStation)  // 0x88795F13FACDA88D
```

build 323

## SET_MICROPHONE_POSITION

```c
void SET_MICROPHONE_POSITION(BOOL toggle, float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)  // 0xB6AE90EDDE95C762
```

build 323

> This native controls where the game plays audio from. By default the microphone is positioned on the player.
> When p0 is true the game will play audio from the 3 positions inputted.
> It is recommended to set all 3 positions to the same value as mixing different positions doesn't seem to work well.
> The scripts mostly use it with only one position such as in fbi3.c: 
> AUDIO::SET_MICROPHONE_POSITION(true, ENTITY::GET_ENTITY_COORDS(iLocal_3091, true), ENTITY::GET_ENTITY_COORDS(iLocal_3091, true), ENTITY::GET_ENTITY_COORDS(iLocal_3091, true));

## SET_MOBILE_PHONE_RADIO_STATE

```c
void SET_MOBILE_PHONE_RADIO_STATE(BOOL state)  // 0xBF286C554784F3DF
```

build 323

## SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY

```c
void SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY(BOOL toggle)  // 0x1098355A16064BB3
```

build 323

## SET_NEXT_RADIO_TRACK

```c
void SET_NEXT_RADIO_TRACK(const char* radioName, const char* radioTrack, const char* p2, const char* p3)  // 0x55ECF4D13D9903B0
```

build 1868

## SET_NO_DUCKING_FOR_CONVERSATION

```c
void SET_NO_DUCKING_FOR_CONVERSATION(BOOL p0)  // 0xB542DE8C3D1CB210
```

build 323

## SET_PED_CLOTH_EVENTS_ENABLED

```c
void SET_PED_CLOTH_EVENTS_ENABLED(Ped ped, BOOL toggle)  // 0x29DA3CA8D8B2692D
```

build 1493 · old names: `_SET_PED_AUDIO_FOOTSTEP_QUIET`

> Enables/disables ped's "quiet" footstep sound.

## SET_PED_FOOTSTEPS_EVENTS_ENABLED

```c
void SET_PED_FOOTSTEPS_EVENTS_ENABLED(Ped ped, BOOL toggle)  // 0x0653B735BFBDFE87
```

build 1493 · old names: `_SET_PED_AUDIO_FOOTSTEP_LOUD`

> Enables/disables ped's "loud" footstep sound.

## SET_PED_GENDER

```c
void SET_PED_GENDER(Ped ped, BOOL p1)  // 0xA5342D390CDA41D6
```

build 323 · old names: `_SET_PED_AUDIO_GENDER`

> BOOL p1: 0 = Female; 1 = Male

## SET_PED_INTERIOR_WALLA_DENSITY

```c
void SET_PED_INTERIOR_WALLA_DENSITY(float p0, float p1)  // 0x8BF907833BE275DE
```

build 323

## SET_PED_IS_DRUNK

```c
void SET_PED_IS_DRUNK(Ped ped, BOOL toggle)  // 0x95D2D383D5396B8A
```

build 323

> Sets the ped drunk sounds.  Only works with PLAYER_PED_ID
> 
> ====================================================
> 
> As mentioned above, this only sets the drunk sound to ped/player.
> 
> To give the Ped a drunk effect with drunk walking animation try using SET_PED_MOVEMENT_CLIPSET
> 
> Below is an example
> 
> if (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@verydrunk"))
>                 {
>                     Function.Call(Hash.REQUEST_ANIM_SET, "move_m@drunk@verydrunk");
>                 }
>                 Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Ped.Handle, "move_m@drunk@verydrunk", 0x3E800000);
> 
> 
> 
> And to stop the effect use
> RESET_PED_MOVEMENT_CLIPSET

## SET_PED_RACE_AND_VOICE_GROUP

```c
void SET_PED_RACE_AND_VOICE_GROUP(Ped ped, int p1, Hash voiceGroup)  // 0x1B7ABE26CBCBF8C7
```

build 372

## SET_PED_VOICE_FULL

```c
void SET_PED_VOICE_FULL(Ped ped)  // 0x40CF0D12D142A9E8
```

build 323 · old names: `_SET_PED_SCREAM`

> Assigns some ambient voice to the ped.

## SET_PED_VOICE_GROUP

```c
void SET_PED_VOICE_GROUP(Ped ped, Hash voiceGroupHash)  // 0x7CDC8C3B89F661B3
```

build 323 · old names: `_SET_PED_VOICE_GROUP`

> From the scripts:
> 
> AUDIO::SET_PED_VOICE_GROUP(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("PAIGE_PVG"));
> AUDIO::SET_PED_VOICE_GROUP(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("TALINA_PVG"));
> AUDIO::SET_PED_VOICE_GROUP(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("FEMALE_LOST_BLACK_PVG"));
> AUDIO::SET_PED_VOICE_GROUP(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("FEMALE_LOST_WHITE_PVG"));

## SET_PED_VOICE_GROUP_FROM_RACE_TO_PVG

```c
void SET_PED_VOICE_GROUP_FROM_RACE_TO_PVG(Ped ped, Hash voiceGroupHash)  // 0x0BABC1345ABBFB16
```

build 2699 · old names: `_SET_PED_VOICE_GROUP_RACE`

> Dat151RelType == 29

## SET_PED_WALLA_DENSITY

```c
void SET_PED_WALLA_DENSITY(float p0, float p1)  // 0x149AEE66F0CB3A99
```

build 323

## SET_PLAYER_ANGRY

```c
void SET_PLAYER_ANGRY(Ped ped, BOOL toggle)  // 0xEA241BB04110F091
```

build 323

## SET_PLAYER_VEHICLE_ALARM_AUDIO_ACTIVE

```c
void SET_PLAYER_VEHICLE_ALARM_AUDIO_ACTIVE(Vehicle vehicle, BOOL toggle)  // 0x6FDDAD856E36988A
```

build 323

## SET_PORTAL_SETTINGS_OVERRIDE

```c
void SET_PORTAL_SETTINGS_OVERRIDE(const char* p0, const char* p1)  // 0x044DBAD7A7FA2BE5
```

build 323

> Found in the b617d scripts, duplicates removed:  
> 
> AUDIO::SET_PORTAL_SETTINGS_OVERRIDE("V_CARSHOWROOM_PS_WINDOW_UNBROKEN", "V_CARSHOWROOM_PS_WINDOW_BROKEN");
> 
>  AUDIO::SET_PORTAL_SETTINGS_OVERRIDE("V_CIA_PS_WINDOW_UNBROKEN", "V_CIA_PS_WINDOW_BROKEN");
> 
>  AUDIO::SET_PORTAL_SETTINGS_OVERRIDE("V_DLC_HEIST_APARTMENT_DOOR_CLOSED", "V_DLC_HEIST_APARTMENT_DOOR_OPEN");
> 
>  AUDIO::SET_PORTAL_SETTINGS_OVERRIDE("V_FINALEBANK_PS_VAULT_INTACT", "V_FINALEBANK_PS_VAULT_BLOWN");
> 
>  AUDIO::SET_PORTAL_SETTINGS_OVERRIDE("V_MICHAEL_PS_BATHROOM_WITH_WINDOW", "V_MICHAEL_PS_BATHROOM_WITHOUT_WINDOW");

## SET_POSITION_FOR_NULL_CONV_PED

```c
void SET_POSITION_FOR_NULL_CONV_PED(Any p0, float p1, float p2, float p3)  // 0x33E3C6C6F2F0B506
```

build 323

## SET_POSITIONED_PLAYER_VEHICLE_RADIO_EMITTER_ENABLED

```c
void SET_POSITIONED_PLAYER_VEHICLE_RADIO_EMITTER_ENABLED(Any p0)  // 0xDA07819E452FFE8F
```

build 505

## SET_RADIO_AUTO_UNFREEZE

```c
void SET_RADIO_AUTO_UNFREEZE(BOOL toggle)  // 0xC1AA9F53CE982990
```

build 323

## SET_RADIO_FRONTEND_FADE_TIME

```c
void SET_RADIO_FRONTEND_FADE_TIME(float fadeTime)  // 0x2C96CDB04FCA358E
```

build 323

## SET_RADIO_POSITION_AUDIO_MUTE

```c
void SET_RADIO_POSITION_AUDIO_MUTE(BOOL p0)  // 0x02E93C796ABD3A97
```

build 323

> Does nothing (it's a nullsub).

## SET_RADIO_RETUNE_DOWN

```c
void SET_RADIO_RETUNE_DOWN()  // 0xDD6BCF9E94425DF9
```

build 323

> Tune Backwards...

## SET_RADIO_RETUNE_UP

```c
void SET_RADIO_RETUNE_UP()  // 0xFF266D1D0EB1195D
```

build 323

> Tune Forward...

## SET_RADIO_STATION_AS_FAVOURITE

```c
void SET_RADIO_STATION_AS_FAVOURITE(const char* radioStation, BOOL toggle)  // 0x4CAFEBFA21EC188D
```

build 2372 · old names: `_SET_RADIO_STATION_IS_VISIBLE`

> Doesn't have an effect in Story Mode.

## SET_RADIO_STATION_MUSIC_ONLY

```c
void SET_RADIO_STATION_MUSIC_ONLY(const char* radioStation, BOOL toggle)  // 0x774BD811F656A122
```

build 323

> 6 calls in the b617d scripts, removed identical lines:
> 
> AUDIO::SET_RADIO_STATION_MUSIC_ONLY("RADIO_01_CLASS_ROCK", 1);
> AUDIO::SET_RADIO_STATION_MUSIC_ONLY(AUDIO::GET_RADIO_STATION_NAME(10), 0);
> AUDIO::SET_RADIO_STATION_MUSIC_ONLY(AUDIO::GET_RADIO_STATION_NAME(10), 1);

## SET_RADIO_TO_STATION_INDEX

```c
void SET_RADIO_TO_STATION_INDEX(int radioStation)  // 0xA619B168B8A8570F
```

build 323

> Sets radio station by index.

## SET_RADIO_TO_STATION_NAME

```c
void SET_RADIO_TO_STATION_NAME(const char* stationName)  // 0xC69EDA28699D5107
```

build 323

> List of radio stations that are in the wheel, in clockwise order, as of LS Tuners DLC: https://git.io/J8a3k

## SET_RADIO_TRACK

```c
void SET_RADIO_TRACK(const char* radioStation, const char* radioTrack)  // 0xB39786F201FEE30B
```

build 323

> Only found this one in the decompiled scripts:
> 
> AUDIO::SET_RADIO_TRACK("RADIO_03_HIPHOP_NEW", "ARM1_RADIO_STARTS");
> 

## SET_RADIO_TRACK_WITH_START_OFFSET

```c
void SET_RADIO_TRACK_WITH_START_OFFSET(const char* radioStationName, const char* mixName, int p2)  // 0x2CB0075110BE1E56
```

build 1493 · old names: `_SET_RADIO_TRACK_MIX`

## SET_SCRIPT_UPDATE_DOOR_AUDIO

```c
void SET_SCRIPT_UPDATE_DOOR_AUDIO(Hash doorHash, BOOL toggle)  // 0x06C0023BED16DD6B
```

build 323

## SET_SIREN_BYPASS_MP_DRIVER_CHECK

```c
void SET_SIREN_BYPASS_MP_DRIVER_CHECK(Vehicle vehicle, BOOL toggle)  // 0xF584CF8529B51434
```

build 2372 · old names: `_SET_SIREN_KEEP_ON`

## SET_SIREN_CAN_BE_CONTROLLED_BY_AUDIO

```c
void SET_SIREN_CAN_BE_CONTROLLED_BY_AUDIO(Vehicle vehicle, BOOL p1)  // 0x43FA0DFC5DF87815
```

build 323

## SET_SIREN_WITH_NO_DRIVER

```c
void SET_SIREN_WITH_NO_DRIVER(Vehicle vehicle, BOOL toggle)  // 0x1FEF0683B96EBCF2
```

build 323

## SET_SKIP_MINIGUN_SPIN_UP_AUDIO

```c
void SET_SKIP_MINIGUN_SPIN_UP_AUDIO(BOOL p0)  // 0xBEF34B1D9624D5DD
```

build 323

## SET_STATIC_EMITTER_ENABLED

```c
void SET_STATIC_EMITTER_ENABLED(const char* emitterName, BOOL toggle)  // 0x399D2D3B33F1B8EB
```

build 323

> Example:
> AUDIO::SET_STATIC_EMITTER_ENABLED((Any*)"LOS_SANTOS_VANILLA_UNICORN_01_STAGE", false);    AUDIO::SET_STATIC_EMITTER_ENABLED((Any*)"LOS_SANTOS_VANILLA_UNICORN_02_MAIN_ROOM", false);    AUDIO::SET_STATIC_EMITTER_ENABLED((Any*)"LOS_SANTOS_VANILLA_UNICORN_03_BACK_ROOM", false);
> 
> This turns off surrounding sounds not connected directly to peds.
> 
> Full list of static emitters by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/staticEmitters.json

## SET_USER_RADIO_CONTROL_ENABLED

```c
void SET_USER_RADIO_CONTROL_ENABLED(BOOL toggle)  // 0x19F21E63AE6EAE4E
```

build 323

## SET_VARIABLE_ON_SOUND

```c
void SET_VARIABLE_ON_SOUND(int soundId, const char* variable, float p2)  // 0xAD6B3148A78AE9B6
```

build 323

## SET_VARIABLE_ON_STREAM

```c
void SET_VARIABLE_ON_STREAM(const char* variable, float p1)  // 0x2F9D3834AEB9EF79
```

build 323

> From the scripts, p0:
> 
> "ArmWrestlingIntensity",
> "INOUT",
> "Monkey_Stream",
> "ZoomLevel"

## SET_VARIABLE_ON_SYNCH_SCENE_AUDIO

```c
void SET_VARIABLE_ON_SYNCH_SCENE_AUDIO(const char* variableName, float value)  // 0xBCC29F935ED07688
```

build 323 · old names: `GET_PLAYER_HEADSET_SOUND_ALTERNATE`, `_SET_VARIABLE_ON_CUTSCENE_AUDIO`

## SET_VARIABLE_ON_UNDER_WATER_STREAM

```c
void SET_VARIABLE_ON_UNDER_WATER_STREAM(const char* variableName, float value)  // 0x733ADF241531E5C2
```

build 323

> AUDIO::SET_VARIABLE_ON_UNDER_WATER_STREAM("inTunnel", 1.0);
> AUDIO::SET_VARIABLE_ON_UNDER_WATER_STREAM("inTunnel", 0.0);

## SET_VEH_FORCED_RADIO_THIS_FRAME

```c
void SET_VEH_FORCED_RADIO_THIS_FRAME(Vehicle vehicle)  // 0xC1805D05E6D4FE10
```

build 323

## SET_VEH_HAS_NORMAL_RADIO

```c
void SET_VEH_HAS_NORMAL_RADIO(Vehicle vehicle)  // 0x3E45765F3FBB582F
```

build 2372 · old names: `_SET_VEH_HAS_RADIO_OVERRIDE`

## SET_VEH_RADIO_STATION

```c
void SET_VEH_RADIO_STATION(Vehicle vehicle, const char* radioStation)  // 0x1B9C0099CB942AC6
```

build 323

> List of radio stations that are in the wheel, in clockwise order, as of LS Tuners DLC: https://git.io/J8a3k

## SET_VEHICLE_AUDIO_BODY_DAMAGE_FACTOR

```c
void SET_VEHICLE_AUDIO_BODY_DAMAGE_FACTOR(Vehicle vehicle, float intensity)  // 0x01BB4D577D38BD9E
```

build 323

> intensity: 0.0f - 1.0f, only used once with 1.0f in R* Scripts (nigel2)
> Makes an engine rattling noise when you decelerate, you need to be going faster to hear lower values

## SET_VEHICLE_AUDIO_ENGINE_DAMAGE_FACTOR

```c
void SET_VEHICLE_AUDIO_ENGINE_DAMAGE_FACTOR(Vehicle vehicle, float damageFactor)  // 0x59E7B488451F4D3A
```

build 323

## SET_VEHICLE_BOOST_ACTIVE

```c
void SET_VEHICLE_BOOST_ACTIVE(Vehicle vehicle, BOOL toggle)  // 0x4A04DE7CAB2739A1
```

build 323

> SET_VEHICLE_BOOST_ACTIVE(vehicle, 1, 0);
> SET_VEHICLE_BOOST_ACTIVE(vehicle, 0, 0); 
> 
> Will give a boost-soundeffect.

## SET_VEHICLE_CONVERSATIONS_PERSIST

```c
void SET_VEHICLE_CONVERSATIONS_PERSIST(BOOL p0, BOOL p1)  // 0x58BB377BEC7CD5F4
```

build 323

## SET_VEHICLE_CONVERSATIONS_PERSIST_NEW

```c
void SET_VEHICLE_CONVERSATIONS_PERSIST_NEW(BOOL p0, BOOL p1, BOOL p2)  // 0x9BD7BD55E4533183
```

build 1290

## SET_VEHICLE_FORCE_REVERSE_WARNING

```c
void SET_VEHICLE_FORCE_REVERSE_WARNING(Any p0, Any p1)  // 0x97FFB4ADEED08066
```

build 2372

## SET_VEHICLE_HORN_SOUND_INDEX

```c
void SET_VEHICLE_HORN_SOUND_INDEX(Vehicle vehicle, int value)  // 0x0350E7E17BA767D0
```

build 1365 · old names: `_SET_VEHICLE_HORN_VARIATION`

## SET_VEHICLE_MISSILE_WARNING_ENABLED

```c
void SET_VEHICLE_MISSILE_WARNING_ENABLED(Vehicle vehicle, BOOL toggle)  // 0xF3365489E0DD50F9
```

build 323

## SET_VEHICLE_RADIO_ENABLED

```c
void SET_VEHICLE_RADIO_ENABLED(Vehicle vehicle, BOOL toggle)  // 0x3B988190C0AA6C0B
```

build 323

> can't seem to enable radio on cop cars etc

## SET_VEHICLE_RADIO_LOUD

```c
void SET_VEHICLE_RADIO_LOUD(Vehicle vehicle, BOOL toggle)  // 0xBB6F1CAEC68B0BCE
```

build 323

## SET_VEHICLE_STARTUP_REV_SOUND

```c
void SET_VEHICLE_STARTUP_REV_SOUND(Vehicle vehicle, const char* p1, const char* p2)  // 0xF1F8157B8C3F171C
```

build 323

## SKIP_RADIO_FORWARD

```c
void SKIP_RADIO_FORWARD()  // 0x6DDBBDD98E2E9C25
```

build 323

## SKIP_TO_NEXT_SCRIPTED_CONVERSATION_LINE

```c
void SKIP_TO_NEXT_SCRIPTED_CONVERSATION_LINE()  // 0x9663FE6B7A61EB00
```

build 323

## START_ALARM

```c
void START_ALARM(const char* alarmName, BOOL p2)  // 0x0355EF116C4C97B2
```

build 323

> Example:
> 
> This will start the alarm at Fort Zancudo.
> 
> AUDIO::START_ALARM("PORT_OF_LS_HEIST_FORT_ZANCUDO_ALARMS", 1);
> 
> First parameter (char) is the name of the alarm.
> Second parameter (bool) is unknown, it does not seem to make a difference if this one is 0 or 1.
> 
> ----------
> 
> It DOES make a difference but it has to do with the duration or something I dunno yet
> 
> ----------
> 
>  Found in the b617d scripts:
> 
>  AUDIO::START_ALARM("AGENCY_HEIST_FIB_TOWER_ALARMS", 0);
>  AUDIO::START_ALARM("AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER", 1);
>  AUDIO::START_ALARM("AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B", 0);
>  AUDIO::START_ALARM("BIG_SCORE_HEIST_VAULT_ALARMS", a_0);
>  AUDIO::START_ALARM("FBI_01_MORGUE_ALARMS", 1);
>  AUDIO::START_ALARM("FIB_05_BIOTECH_LAB_ALARMS", 0);
>  AUDIO::START_ALARM("JEWEL_STORE_HEIST_ALARMS", 0);
>  AUDIO::START_ALARM("PALETO_BAY_SCORE_ALARM", 1);
>  AUDIO::START_ALARM("PALETO_BAY_SCORE_CHICKEN_FACTORY_ALARM", 0);
>  AUDIO::START_ALARM("PORT_OF_LS_HEIST_FORT_ZANCUDO_ALARMS", 1);
>  AUDIO::START_ALARM("PORT_OF_LS_HEIST_SHIP_ALARMS", 0);
>  AUDIO::START_ALARM("PRISON_ALARMS", 0);
>  AUDIO::START_ALARM("PROLOGUE_VAULT_ALARMS", 0);
> Full list of alarm names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/alarmSounds.json

## START_AUDIO_SCENE

```c
BOOL START_AUDIO_SCENE(const char* scene)  // 0x013A80FC08F6E4F2
```

build 323

> Used to prepare a scene where the surrounding sound is muted or a bit changed. This does not play any sound.
> 
> List of all usable scene names found in b617d. Sorted alphabetically and identical names removed: https://pastebin.com/MtM9N9CC
> Full list of audio scene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/audioSceneNames.json

## START_PRELOADED_CONVERSATION

```c
void START_PRELOADED_CONVERSATION()  // 0x23641AFE870AF385
```

build 323

## START_SCRIPT_CONVERSATION

```c
void START_SCRIPT_CONVERSATION(BOOL p0, BOOL p1, BOOL p2, BOOL p3)  // 0x6B17C62C9635D2DC
```

build 323

## START_SCRIPT_PHONE_CONVERSATION

```c
void START_SCRIPT_PHONE_CONVERSATION(BOOL p0, BOOL p1)  // 0x252E5F915EABB675
```

build 323

## STOP_ALARM

```c
void STOP_ALARM(const char* alarmName, BOOL toggle)  // 0xA1CADDCD98415A41
```

build 323

> Example:
> 
> This will stop the alarm at Fort Zancudo.
> 
> AUDIO::STOP_ALARM("PORT_OF_LS_HEIST_FORT_ZANCUDO_ALARMS", 1);
> 
> First parameter (char) is the name of the alarm.
> Second parameter (bool) has to be true (1) to have any effect.
> Full list of alarm names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/alarmSounds.json

## STOP_ALL_ALARMS

```c
void STOP_ALL_ALARMS(BOOL stop)  // 0x2F794A877ADD4C92
```

build 323

## STOP_AUDIO_SCENE

```c
void STOP_AUDIO_SCENE(const char* scene)  // 0xDFE8422B3B94E688
```

build 323

> Full list of audio scene names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/audioSceneNames.json

## STOP_AUDIO_SCENES

```c
void STOP_AUDIO_SCENES()  // 0xBAC7FC81A75EC1A1
```

build 323

## STOP_CURRENT_PLAYING_AMBIENT_SPEECH

```c
void STOP_CURRENT_PLAYING_AMBIENT_SPEECH(Ped ped)  // 0xB8BEC0CA6F0EDB0F
```

build 323

## STOP_CURRENT_PLAYING_SPEECH

```c
void STOP_CURRENT_PLAYING_SPEECH(Ped ped)  // 0x7A73D05A607734C7
```

build 323 · old names: `_SET_PED_MUTE`

## STOP_CUTSCENE_AUDIO

```c
void STOP_CUTSCENE_AUDIO()  // 0x806058BBDC136E06
```

build 323

## STOP_PED_RINGTONE

```c
void STOP_PED_RINGTONE(Ped ped)  // 0x6C5AE23EFA885092
```

build 323

## STOP_PED_SPEAKING

```c
void STOP_PED_SPEAKING(Ped ped, BOOL shaking)  // 0x9D64D7405520E3D3
```

build 323

## STOP_PED_SPEAKING_SYNCED

```c
void STOP_PED_SPEAKING_SYNCED(Ped ped, BOOL p1)  // 0xAB6781A5F3101470
```

build 1868

## STOP_SCRIPTED_CONVERSATION

```c
int STOP_SCRIPTED_CONVERSATION(BOOL p0)  // 0xD79DEEFB53455EBA
```

build 323

## STOP_SMOKE_GRENADE_EXPLOSION_SOUNDS

```c
void STOP_SMOKE_GRENADE_EXPLOSION_SOUNDS()  // 0xE4E6DD5566D28C82
```

build 323

## STOP_SOUND

```c
void STOP_SOUND(int soundId)  // 0xA3B0C41BA5CC0BB5
```

build 323

## STOP_STREAM

```c
void STOP_STREAM()  // 0xA4718A1419D18151
```

build 323

## STOP_SYNCHRONIZED_AUDIO_EVENT

```c
BOOL STOP_SYNCHRONIZED_AUDIO_EVENT(int sceneID)  // 0x92D6A88E64A94430
```

build 323

## TRIGGER_MUSIC_EVENT

```c
BOOL TRIGGER_MUSIC_EVENT(const char* eventName)  // 0x706D57B0F50DA710
```

build 323

> List of all usable event names found in b617d used with this native. Sorted alphabetically and identical names removed: https://pastebin.com/RzDFmB1W
> 
> All music event names found in the b617d scripts: https://pastebin.com/GnYt0R3P
> Full list of music event names by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/musicEventNames.json

## TRIGGER_SIREN_AUDIO

```c
void TRIGGER_SIREN_AUDIO(Vehicle vehicle)  // 0x66C3FB05206041BA
```

build 1290 · old names: `_TRIGGER_SIREN`

## UNBLOCK_SPEECH_CONTEXT_GROUP

```c
void UNBLOCK_SPEECH_CONTEXT_GROUP(const char* p0)  // 0x2ACABED337622DF2
```

build 1493

## UNFREEZE_RADIO_STATION

```c
void UNFREEZE_RADIO_STATION(const char* radioStation)  // 0xFC00454CF60B91DD
```

build 323

## UNHINT_AMBIENT_AUDIO_BANK

```c
void UNHINT_AMBIENT_AUDIO_BANK()  // 0x19AF7ED9B9D23058
```

build 323

## UNHINT_NAMED_SCRIPT_AUDIO_BANK

```c
void UNHINT_NAMED_SCRIPT_AUDIO_BANK(const char* audioBank)  // 0x11579D940949C49E
```

build 678

## UNHINT_SCRIPT_AUDIO_BANK

```c
void UNHINT_SCRIPT_AUDIO_BANK()  // 0x9AC92EED5E4793AB
```

build 323

## UNLOCK_MISSION_NEWS_STORY

```c
void UNLOCK_MISSION_NEWS_STORY(int newsStory)  // 0xB165AB7C248B2DC1
```

build 323

> "news" that play on the radio after you've done something in story mode(?)

## UNLOCK_RADIO_STATION_TRACK_LIST

```c
void UNLOCK_RADIO_STATION_TRACK_LIST(const char* radioStation, const char* trackListName)  // 0x031ACB6ABA18C729
```

build 323

> AUDIO::UNLOCK_RADIO_STATION_TRACK_LIST("RADIO_16_SILVERLAKE", "MIRRORPARK_LOCKED");

## UNREGISTER_SCRIPT_WITH_AUDIO

```c
void UNREGISTER_SCRIPT_WITH_AUDIO()  // 0xA8638BE228D4751A
```

build 323

> This native does absolutely nothing, just a nullsub

## UNREQUEST_TENNIS_BANKS

```c
void UNREQUEST_TENNIS_BANKS()  // 0x0150B6FF25A9E2E5
```

build 323

## UPDATE_SOUND_COORD

```c
void UPDATE_SOUND_COORD(int soundId, float x, float y, float z)  // 0x7EC3C679D0E7E46B
```

build 678

## UPDATE_UNLOCKABLE_DJ_RADIO_TRACKS

```c
void UPDATE_UNLOCKABLE_DJ_RADIO_TRACKS(BOOL enableMixes)  // 0x47AED84213A47510
```

build 1493 · old names: `_UPDATE_LSUR`

> Just a nullsub (i.e. does absolutely nothing) since build 1604.

## USE_FOOTSTEP_SCRIPT_SWEETENERS

```c
void USE_FOOTSTEP_SCRIPT_SWEETENERS(Ped ped, BOOL p1, Hash hash)  // 0xBF4DC1784BE94DFA
```

build 323

## USE_SIREN_AS_HORN

```c
void USE_SIREN_AS_HORN(Vehicle vehicle, BOOL toggle)  // 0xFA932DE350266EF8
```

build 323

