# PAD natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _GET_GAMEPAD_TYPE

```c
int _GET_GAMEPAD_TYPE()  // 0x18E474F40EF05F10
```

build 3570

> Always returns zero.

## _IS_CONTROL_HELD_DOWN

```c
BOOL _IS_CONTROL_HELD_DOWN(int control, int action, int duration)  // 0xE9CB8C56E90D5079
```

build 3407

## ALLOW_ALTERNATIVE_SCRIPT_CONTROLS_LAYOUT

```c
void ALLOW_ALTERNATIVE_SCRIPT_CONTROLS_LAYOUT(int control)  // 0x7F4724035FDCA1DD
```

build 323

> control: see IS_CONTROL_ENABLED

## CLEAR_CONTROL_LIGHT_EFFECT

```c
void CLEAR_CONTROL_LIGHT_EFFECT(int control)  // 0xCB0360EFEFB2580D
```

build 323

> control: see IS_CONTROL_ENABLED

## CLEAR_CONTROL_SHAKE_SUPPRESSED_ID

```c
void CLEAR_CONTROL_SHAKE_SUPPRESSED_ID(int control)  // 0xA0CEFCEA390AAB9B
```

build 323 · old names: `_CLEAR_SUPPRESSED_PAD_RUMBLE`

> control: see IS_CONTROL_ENABLED

## DISABLE_ALL_CONTROL_ACTIONS

```c
void DISABLE_ALL_CONTROL_ACTIONS(int control)  // 0x5F4B6931816E599B
```

build 323

> control: see IS_CONTROL_ENABLED

## DISABLE_CONTROL_ACTION

```c
void DISABLE_CONTROL_ACTION(int control, int action, BOOL disableRelatedActions)  // 0xFE99B66D079CF6BC
```

build 323

> control: see IS_CONTROL_ENABLED

## ENABLE_ALL_CONTROL_ACTIONS

```c
void ENABLE_ALL_CONTROL_ACTIONS(int control)  // 0xA5FFE9B05F199DE7
```

build 323

> control: see IS_CONTROL_ENABLED

## ENABLE_CONTROL_ACTION

```c
void ENABLE_CONTROL_ACTION(int control, int action, BOOL enableRelatedActions)  // 0x351220255D64C155
```

build 323

> control: see IS_CONTROL_ENABLED

## GET_ALLOW_MOVEMENT_WHILE_ZOOMED

```c
BOOL GET_ALLOW_MOVEMENT_WHILE_ZOOMED()  // 0xFC859E2374407556
```

build 323

> Returns profile setting 17.

## GET_CONTROL_GROUP_INSTRUCTIONAL_BUTTONS_STRING

```c
const char* GET_CONTROL_GROUP_INSTRUCTIONAL_BUTTONS_STRING(int control, int controlGroup, BOOL allowXOSwap)  // 0x80C2FD58D720C801
```

build 323 · old names: `GET_CONTROL_GROUP_INSTRUCTIONAL_BUTTON`

> control: unused parameter

## GET_CONTROL_HOW_LONG_AGO

```c
int GET_CONTROL_HOW_LONG_AGO(int control)  // 0xD7D22F5592AED8BA
```

build 323 · old names: `_GET_MS_SINCE_LAST_INPUT`

> Returns time in ms since last input.
> 
> control: see IS_CONTROL_ENABLED

## GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING

```c
const char* GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING(int control, int action, BOOL allowXOSwap)  // 0x0499D7B09FC9B407
```

build 323 · old names: `GET_CONTROL_INSTRUCTIONAL_BUTTON`

> allowXOSwap appears to always be true.
> 
> EG:
> GET_CONTROL_INSTRUCTIONAL_BUTTON (2, 201, 1) /*INPUT_FRONTEND_ACCEPT (e.g. Enter button)*/
> GET_CONTROL_INSTRUCTIONAL_BUTTON (2, 202, 1) /*INPUT_FRONTEND_CANCEL (e.g. ESC button)*/
> GET_CONTROL_INSTRUCTIONAL_BUTTON (2, 51, 1) /*INPUT_CONTEXT (e.g. E button)*/
> 
> https://gtaforums.com/topic/819070-c-draw-instructional-buttons-scaleform-movie/#entry1068197378
> 
> control: unused parameter

## GET_CONTROL_NORMAL

```c
float GET_CONTROL_NORMAL(int control, int action)  // 0xEC3C9B8D5327B563
```

build 323

> Returns the value of GET_CONTROL_VALUE normalized (i.e. a real number value between -1 and 1)
> 
> control: see IS_CONTROL_ENABLED

## GET_CONTROL_UNBOUND_NORMAL

```c
float GET_CONTROL_UNBOUND_NORMAL(int control, int action)  // 0x5B84D09CEC5209C5
```

build 323

> Seems to return values between -1 and 1 for controls like gas and steering.
> 
> control: see IS_CONTROL_ENABLED

## GET_CONTROL_VALUE

```c
int GET_CONTROL_VALUE(int control, int action)  // 0xD95E79E8686D2C27
```

build 323

> control: see IS_CONTROL_ENABLED

## GET_DISABLED_CONTROL_NORMAL

```c
float GET_DISABLED_CONTROL_NORMAL(int control, int action)  // 0x11E65974A982637C
```

build 323

> control: see IS_CONTROL_ENABLED

## GET_DISABLED_CONTROL_UNBOUND_NORMAL

```c
float GET_DISABLED_CONTROL_UNBOUND_NORMAL(int control, int action)  // 0x4F8A26A890FD62FB
```

build 323

> The "disabled" variant of GET_CONTROL_UNBOUND_NORMAL.
> 
> control: see IS_CONTROL_ENABLED

## GET_IS_USING_ALTERNATE_DRIVEBY

```c
BOOL GET_IS_USING_ALTERNATE_DRIVEBY()  // 0x0F70731BACCFBB96
```

build 323

> Returns profile setting 225.

## GET_IS_USING_ALTERNATE_HANDBRAKE

```c
BOOL GET_IS_USING_ALTERNATE_HANDBRAKE()  // 0x25AAA32BDC98F2A3
```

build 1365 · old names: `_GET_IS_USING_ALTERNATE_HANDBRAKE`

## GET_LOCAL_PLAYER_AIM_STATE

```c
int GET_LOCAL_PLAYER_AIM_STATE()  // 0xBB41AFBBBC0A0287
```

build 323

> Hard-coded to return 3 if using KBM, otherwise same behavior as GET_LOCAL_PLAYER_GAMEPAD_AIM_STATE.

## GET_LOCAL_PLAYER_GAMEPAD_AIM_STATE

```c
int GET_LOCAL_PLAYER_GAMEPAD_AIM_STATE()  // 0x59B9A7AF4C95133C
```

build 323 · old names: `_GET_LOCAL_PLAYER_AIM_STATE_2`

> Returns the local player's targeting mode. See PLAYER::SET_PLAYER_TARGETING_MODE.

## HAVE_CONTROLS_CHANGED

```c
BOOL HAVE_CONTROLS_CHANGED(int control)  // 0x6CD79468A1E595C6
```

build 323

> control: unused parameter

## INIT_PC_SCRIPTED_CONTROLS

```c
BOOL INIT_PC_SCRIPTED_CONTROLS(const char* schemeName)  // 0x3D42B92563939375
```

build 323 · old names: `_SWITCH_TO_INPUT_MAPPING_SCHEME`

> Used in carsteal3 script with schemeName = "Carsteal4_spycar".

## IS_CONTROL_ENABLED

```c
BOOL IS_CONTROL_ENABLED(int control, int action)  // 0x1CEA6BFDF248E5D9
```

build 323

> control: 0: PLAYER_CONTROL, 1: CAMERA_CONTROL, 2: FRONTEND_CONTROL
> For more info, see https://docs.fivem.net/docs/game-references/controls/

## IS_CONTROL_JUST_PRESSED

```c
BOOL IS_CONTROL_JUST_PRESSED(int control, int action)  // 0x580417101DDB492F
```

build 323

> Returns whether a control was newly pressed since the last check.
> control: see IS_CONTROL_ENABLED

## IS_CONTROL_JUST_RELEASED

```c
BOOL IS_CONTROL_JUST_RELEASED(int control, int action)  // 0x50F940259D3841E6
```

build 323

> Returns whether a control was newly released since the last check.
> control: see IS_CONTROL_ENABLED

## IS_CONTROL_PRESSED

```c
BOOL IS_CONTROL_PRESSED(int control, int action)  // 0xF3A21BCD95725A4A
```

build 323

> Returns whether a control is currently pressed.
> control: see IS_CONTROL_ENABLED

## IS_CONTROL_RELEASED

```c
BOOL IS_CONTROL_RELEASED(int control, int action)  // 0x648EE3E7F38877DD
```

build 323

> Returns whether a control is currently _not_ pressed.
> control: see IS_CONTROL_ENABLED

## IS_DISABLED_CONTROL_JUST_PRESSED

```c
BOOL IS_DISABLED_CONTROL_JUST_PRESSED(int control, int action)  // 0x91AEF906BCA88877
```

build 323

> control: see IS_CONTROL_ENABLED

## IS_DISABLED_CONTROL_JUST_RELEASED

```c
BOOL IS_DISABLED_CONTROL_JUST_RELEASED(int control, int action)  // 0x305C8DCD79DA8B0F
```

build 323

> control: see IS_CONTROL_ENABLED

## IS_DISABLED_CONTROL_PRESSED

```c
BOOL IS_DISABLED_CONTROL_PRESSED(int control, int action)  // 0xE2587F8CBBD87B1D
```

build 323

> control: see IS_CONTROL_ENABLED

## IS_DISABLED_CONTROL_RELEASED

```c
BOOL IS_DISABLED_CONTROL_RELEASED(int control, int action)  // 0xFB6C4072E9A32E92
```

build 757

> control: see IS_CONTROL_ENABLED

## IS_LOOK_INVERTED

```c
BOOL IS_LOOK_INVERTED()  // 0x77B612531280010D
```

build 323

## IS_MOUSE_LOOK_INVERTED

```c
BOOL IS_MOUSE_LOOK_INVERTED()  // 0xE1615EC03B3BB4FD
```

build 323

## IS_USING_CURSOR

```c
BOOL IS_USING_CURSOR(int control)  // 0x13337B38DB572509
```

build 323 · old names: `_IS_INPUT_JUST_DISABLED`, `_IS_USING_KEYBOARD_2`

> control: see IS_CONTROL_ENABLED

## IS_USING_KEYBOARD_AND_MOUSE

```c
BOOL IS_USING_KEYBOARD_AND_MOUSE(int control)  // 0xA571D46727E2B718
```

build 323 · old names: `_GET_LAST_INPUT_METHOD`, `_IS_INPUT_DISABLED`, `_IS_USING_KEYBOARD`

> control: unused parameter

## IS_USING_REMOTE_PLAY

```c
BOOL IS_USING_REMOTE_PLAY(int control)  // 0x23F09EADC01449D6
```

build 323

> control: see IS_CONTROL_ENABLED
> 
> Hardcoded to return false.

## SET_CONTROL_LIGHT_EFFECT_COLOR

```c
void SET_CONTROL_LIGHT_EFFECT_COLOR(int control, int red, int green, int blue)  // 0x8290252FFF36ACB5
```

build 323 · old names: `_SET_CONTROL_GROUP_COLOR`

> control: see IS_CONTROL_ENABLED

## SET_CONTROL_SHAKE

```c
void SET_CONTROL_SHAKE(int control, int duration, int frequency)  // 0x48B3886C1358D0D5
```

build 323 · old names: `SET_PAD_SHAKE`

> control: see IS_CONTROL_ENABLED
> duration in milliseconds 
> frequency should range from about 10 (slow vibration) to 255 (very fast)
> 
> example:
> SET_CONTROL_SHAKE(PLAYER_CONTROL, 100, 200);

## SET_CONTROL_SHAKE_SUPPRESSED_ID

```c
void SET_CONTROL_SHAKE_SUPPRESSED_ID(int control, int uniqueId)  // 0xF239400E16C23E08
```

build 323 · old names: `SET_PAD_SHAKE_SUPPRESSED_ID`

> control: see IS_CONTROL_ENABLED

## SET_CONTROL_TRIGGER_SHAKE

```c
void SET_CONTROL_TRIGGER_SHAKE(int control, int leftDuration, int leftFrequency, int rightDuration, int rightFrequency)  // 0x14D29BB12D47F68C
```

build 323

> Does nothing (it's a nullsub).

## SET_CONTROL_VALUE_NEXT_FRAME

```c
BOOL SET_CONTROL_VALUE_NEXT_FRAME(int control, int action, float value)  // 0xE8A25867FBA3B05E
```

build 323 · old names: `_SET_CONTROL_NORMAL`

> This is for simulating player input.
> value is a float value from 0 - 1
> 
> control: see IS_CONTROL_ENABLED

## SET_CURSOR_POSITION

```c
BOOL SET_CURSOR_POSITION(float x, float y)  // 0xFC695459D4D0E219
```

build 323 · old names: `_SET_CURSOR_LOCATION`

## SET_INPUT_EXCLUSIVE

```c
void SET_INPUT_EXCLUSIVE(int control, int action)  // 0xEDE476E5EE29EDB1
```

build 323

> control: see IS_CONTROL_ENABLED

## SET_PLAYERPAD_SHAKES_WHEN_CONTROLLER_DISABLED

```c
void SET_PLAYERPAD_SHAKES_WHEN_CONTROLLER_DISABLED(BOOL toggle)  // 0x798FDEB5B1575088
```

build 323

## SET_USE_ADJUSTED_MOUSE_COORDS

```c
void SET_USE_ADJUSTED_MOUSE_COORDS(BOOL toggle)  // 0x5B73C77D9EB66E24
```

build 323

## SHUTDOWN_PC_SCRIPTED_CONTROLS

```c
void SHUTDOWN_PC_SCRIPTED_CONTROLS()  // 0x643ED62D5EA3BEBD
```

build 323 · old names: `_RESET_INPUT_MAPPING_SCHEME`

## STOP_CONTROL_SHAKE

```c
void STOP_CONTROL_SHAKE(int control)  // 0x38C16A305E8CDC8D
```

build 323 · old names: `STOP_PAD_SHAKE`

> control: see IS_CONTROL_ENABLED

## SWITCH_PC_SCRIPTED_CONTROLS

```c
BOOL SWITCH_PC_SCRIPTED_CONTROLS(const char* schemeName)  // 0x4683149ED1DDE7A1
```

build 323 · old names: `_SWITCH_TO_INPUT_MAPPING_SCHEME_2`

> Same as INIT_PC_SCRIPTED_CONTROLS

