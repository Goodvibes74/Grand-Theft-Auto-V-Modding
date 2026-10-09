# GTA natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## CAN_PHONE_BE_SEEN_ON_SCREEN

```c
BOOL CAN_PHONE_BE_SEEN_ON_SCREEN()  // 0xC4E2813898C97A4B
```

build 323

> This one is weird and seems to return a TRUE state regardless of whether the phone is visible on screen or tucked away.
> 
> 
> I can confirm the above. This function is hard-coded to always return 1.

## CELL_CAM_ACTIVATE

```c
void CELL_CAM_ACTIVATE(BOOL p0, BOOL p1)  // 0xFDE8F069C542D126
```

build 323

## CELL_CAM_ACTIVATE_SELFIE_MODE

```c
void CELL_CAM_ACTIVATE_SELFIE_MODE(BOOL toggle)  // 0x015C49A93E3E086E
```

build 323 · old names: `_DISABLE_PHONE_THIS_FRAME`, `_CELL_CAM_DISABLE_THIS_FRAME`

## CELL_CAM_ACTIVATE_SHALLOW_DOF_MODE

```c
void CELL_CAM_ACTIVATE_SHALLOW_DOF_MODE(BOOL toggle)  // 0xA2CCBE62CD4C91A4
```

build 323

## CELL_CAM_IS_CHAR_VISIBLE_NO_FACE_CHECK

```c
BOOL CELL_CAM_IS_CHAR_VISIBLE_NO_FACE_CHECK(Entity entity)  // 0x439E9BC95B7E7FBE
```

build 323

## CELL_CAM_SET_SELFIE_MODE_DISTANCE_SCALING

```c
void CELL_CAM_SET_SELFIE_MODE_DISTANCE_SCALING(float distanceScaling)  // 0xAC2890471901861C
```

build 323

## CELL_CAM_SET_SELFIE_MODE_HEAD_PITCH_OFFSET

```c
void CELL_CAM_SET_SELFIE_MODE_HEAD_PITCH_OFFSET(float pitch)  // 0x466DA42C89865553
```

build 323

## CELL_CAM_SET_SELFIE_MODE_HEAD_ROLL_OFFSET

```c
void CELL_CAM_SET_SELFIE_MODE_HEAD_ROLL_OFFSET(float roll)  // 0xF1E22DC13F5EEBAD
```

build 323

## CELL_CAM_SET_SELFIE_MODE_HEAD_YAW_OFFSET

```c
void CELL_CAM_SET_SELFIE_MODE_HEAD_YAW_OFFSET(float yaw)  // 0xD6ADE981781FCA09
```

build 323

## CELL_CAM_SET_SELFIE_MODE_HORZ_PAN_OFFSET

```c
void CELL_CAM_SET_SELFIE_MODE_HORZ_PAN_OFFSET(float horizontalPan)  // 0x53F4892D18EC90A4
```

build 323

## CELL_CAM_SET_SELFIE_MODE_ROLL_OFFSET

```c
void CELL_CAM_SET_SELFIE_MODE_ROLL_OFFSET(float roll)  // 0x15E69E2802C24B8D
```

build 323

## CELL_CAM_SET_SELFIE_MODE_SIDE_OFFSET_SCALING

```c
void CELL_CAM_SET_SELFIE_MODE_SIDE_OFFSET_SCALING(float p0)  // 0x1B0B4AEED5B9B41C
```

build 323

## CELL_CAM_SET_SELFIE_MODE_VERT_PAN_OFFSET

```c
void CELL_CAM_SET_SELFIE_MODE_VERT_PAN_OFFSET(float vertPan)  // 0x3117D84EFA60F77B
```

build 323

## CELL_HORIZONTAL_MODE_TOGGLE

```c
void CELL_HORIZONTAL_MODE_TOGGLE(BOOL toggle)  // 0x44E44169EF70138E
```

build 323 · old names: `_SET_PHONE_LEAN`, `_CELL_CAM_SET_LEAN`

> if the bool "Toggle" is "true" so the phone is lean.
> if the bool "Toggle" is "false" so the phone is not lean.

## CELL_SET_INPUT

```c
void CELL_SET_INPUT(int direction)  // 0x95C9E72F3D7DEC9B
```

build 323 · old names: `_MOVE_FINGER`, `_CELL_CAM_MOVE_FINGER`

> For move the finger of player, the value of int goes 1 at 5.

## CREATE_MOBILE_PHONE

```c
void CREATE_MOBILE_PHONE(int phoneType)  // 0xA4E8E696C532FBC7
```

build 323

> Creates a mobile phone of the specified type.
> 
> Possible phone types:
> 
> 0 - Default phone / Michael's phone
> 1 - Trevor's phone
> 2 - Franklin's phone
> 3 - Unused police phone
> 4 - Prologue phone
> 
> Higher values may crash your game.

## DESTROY_MOBILE_PHONE

```c
void DESTROY_MOBILE_PHONE()  // 0x3BC861DF703E5097
```

build 323

> Destroys the currently active mobile phone.

## GET_MOBILE_PHONE_POSITION

```c
void GET_MOBILE_PHONE_POSITION(Vector3* position)  // 0x584FDFDA48805B86
```

build 323

## GET_MOBILE_PHONE_RENDER_ID

```c
void GET_MOBILE_PHONE_RENDER_ID(int* renderId)  // 0xB4A53E05F68B6FA1
```

build 323

## GET_MOBILE_PHONE_ROTATION

```c
void GET_MOBILE_PHONE_ROTATION(Vector3* rotation, Vehicle p1)  // 0x1CEFB61F193070AE
```

build 323

## SCRIPT_IS_MOVING_MOBILE_PHONE_OFFSCREEN

```c
void SCRIPT_IS_MOVING_MOBILE_PHONE_OFFSCREEN(BOOL toggle)  // 0xF511F759238A5122
```

build 323

> If bool Toggle = true so the mobile is hide to screen.
> If bool Toggle = false so the mobile is show to screen.

## SET_MOBILE_PHONE_DOF_STATE

```c
void SET_MOBILE_PHONE_DOF_STATE(BOOL toggle)  // 0x375A706A5C2FD084
```

build 372 · old names: `_SET_MOBILE_PHONE_UNK`

## SET_MOBILE_PHONE_POSITION

```c
void SET_MOBILE_PHONE_POSITION(float posX, float posY, float posZ)  // 0x693A5C6D6734085B
```

build 323

## SET_MOBILE_PHONE_ROTATION

```c
void SET_MOBILE_PHONE_ROTATION(float rotX, float rotY, float rotZ, Any p3)  // 0xBB779C0CA917E865
```

build 323

> Last parameter is unknown and always zero.

## SET_MOBILE_PHONE_SCALE

```c
void SET_MOBILE_PHONE_SCALE(float scale)  // 0xCBDD322A73D6D932
```

build 323

> The minimum/default is 500.0f. If you plan to make it bigger set it's position as well. Also this seems to need to be called in a loop as when you close the phone the scale is reset. If not in a loop you'd need to call it everytime before you re-open the phone.

