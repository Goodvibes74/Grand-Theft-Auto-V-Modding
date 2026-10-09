# PHYSICS natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ACTIVATE_PHYSICS

```c
void ACTIVATE_PHYSICS(Entity entity)  // 0x710311ADF0E20730
```

build 323

## ADD_ROPE

```c
int ADD_ROPE(float x, float y, float z, float rotX, float rotY, float rotZ, float length, int ropeType, float maxLength, float minLength, float windingSpeed, BOOL p11, BOOL p12, BOOL rigid, float p14, BOOL breakWhenShot, Any* unkPtr)  // 0xE832D760399EB220
```

build 323

> Creates a rope at the specific position, that extends in the specified direction when not attached to any entities.
> __
> 
> Add_Rope(pos.x,pos.y,pos.z,0.0,0.0,0.0,20.0,4,20.0,1.0,0.0,false,false,false,5.0,false,NULL)
> 
> When attached, Position<vector> does not matter
> When attached, Angle<vector> does not matter
> 
> Rope Type:
> 4 and bellow is a thick rope
> 5 and up are small metal wires
> 0 crashes the game
> 
> Max_length - Rope is forced to this length, generally best to keep this the same as your rope length.
> 
> windingSpeed - Speed the Rope is being winded, using native START_ROPE_WINDING. Set positive for winding and negative for unwinding.
> 
> Rigid - If max length is zero, and this is set to false the rope will become rigid (it will force a specific distance, what ever length is, between the objects).
> 
> breakable - Whether or not shooting the rope will break it.
> 
> unkPtr - unknown ptr, always 0 in orig scripts
> __
> 
> Lengths can be calculated like so:
> 
> float distance = abs(x1 - x2) + abs(y1 - y2) + abs(z1 - z2); // Rope length
> 
> 
> NOTES:
> 
> Rope does NOT interact with anything you attach it to, in some cases it make interact with the world AFTER it breaks (seems to occur if you set the type to -1).
> 
> Rope will sometimes contract and fall to the ground like you'd expect it to, but since it doesn't interact with the world the effect is just jaring.

## APPLY_IMPULSE_TO_CLOTH

```c
void APPLY_IMPULSE_TO_CLOTH(float posX, float posY, float posZ, float vecX, float vecY, float vecZ, float impulse)  // 0xE37F721824571784
```

build 323

## ATTACH_ENTITIES_TO_ROPE

```c
void ATTACH_ENTITIES_TO_ROPE(int ropeId, Entity ent1, Entity ent2, float ent1_x, float ent1_y, float ent1_z, float ent2_x, float ent2_y, float ent2_z, float length, BOOL p10, BOOL p11, Any* p12, Any* p13)  // 0x3D95EC8B6D940AC3
```

build 323

> Attaches entity 1 to entity 2.

## ATTACH_ROPE_TO_ENTITY

```c
void ATTACH_ROPE_TO_ENTITY(int ropeId, Entity entity, float x, float y, float z, BOOL p5)  // 0x4B490A6832559A65
```

build 323

> The position supplied can be anywhere, and the entity should anchor relative to that point from it's origin.

## BREAK_ENTITY_GLASS

```c
void BREAK_ENTITY_GLASS(Entity entity, float p1, float p2, float p3, float p4, float p5, float p6, float p7, float p8, Any p9, BOOL p10)  // 0x2E648D16F6E308F3
```

build 323

## DELETE_CHILD_ROPE

```c
void DELETE_CHILD_ROPE(int ropeId)  // 0xAA5D6B1888E4DB20
```

build 323

## DELETE_ROPE

```c
void DELETE_ROPE(int* ropeId)  // 0x52B4829281364649
```

build 323

## DETACH_ROPE_FROM_ENTITY

```c
void DETACH_ROPE_FROM_ENTITY(int ropeId, Entity entity)  // 0xBCF3026912A8647D
```

build 323

## DOES_ROPE_EXIST

```c
BOOL DOES_ROPE_EXIST(int* ropeId)  // 0xFD5448BE3111ED96
```

build 323

## DOES_SCRIPT_OWN_ROPE

```c
BOOL DOES_SCRIPT_OWN_ROPE(int ropeId)  // 0x271C9D3ACA5D6409
```

build 323 · old names: `_DOES_ROPE_BELONG_TO_THIS_SCRIPT`

## GET_CGOFFSET

```c
Vector3 GET_CGOFFSET(Entity entity)  // 0x8214A4B5A7A33612
```

build 323

## GET_DAMPING

```c
Vector3 GET_DAMPING(Entity entity, int type)  // 0x8C520A929415BCD2
```

build 3407

## GET_IS_ENTITY_A_FRAG

```c
BOOL GET_IS_ENTITY_A_FRAG(Object object)  // 0x0C112765300C7E1E
```

build 505 · old names: `_DOES_ENTITY_HAVE_FRAG_INST`, `_GET_HAS_OBJECT_FRAG_INST`

## GET_ROPE_LAST_VERTEX_COORD

```c
Vector3 GET_ROPE_LAST_VERTEX_COORD(int ropeId)  // 0x21BB0FBD3E217C2D
```

build 323

## GET_ROPE_VERTEX_COORD

```c
Vector3 GET_ROPE_VERTEX_COORD(int ropeId, int vertex)  // 0xEA61CA8E80F09E4D
```

build 323

## GET_ROPE_VERTEX_COUNT

```c
int GET_ROPE_VERTEX_COUNT(int ropeId)  // 0x3655F544CD30F0B5
```

build 323

## IS_ROPE_ATTACHED_AT_BOTH_ENDS

```c
BOOL IS_ROPE_ATTACHED_AT_BOTH_ENDS(int* ropeId)  // 0x84DE3B5FB3E666F0
```

build 323

## LOAD_ROPE_DATA

```c
void LOAD_ROPE_DATA(int ropeId, const char* rope_preset)  // 0xCBB203C04D1ABD27
```

build 323

> Rope presets can be found in the gamefiles. One example is "ropeFamily3", it is NOT a hash but rather a string.

## PIN_ROPE_VERTEX

```c
void PIN_ROPE_VERTEX(int ropeId, int vertex, float x, float y, float z)  // 0x2B320CF14146B69A
```

build 323

## RESET_DISABLE_BREAKING

```c
void RESET_DISABLE_BREAKING(Object object)  // 0xCC6E963682533882
```

build 323

## ROPE_ARE_TEXTURES_LOADED

```c
BOOL ROPE_ARE_TEXTURES_LOADED()  // 0xF2D0E6A75CC05597
```

build 323

## ROPE_ATTACH_VIRTUAL_BOUND_GEOM

```c
void ROPE_ATTACH_VIRTUAL_BOUND_GEOM(int ropeId, int p1, float p2, float p3, float p4, float p5, float p6, float p7, float p8, float p9, float p10, float p11, float p12, float p13)  // 0xBC0CE682D4D05650
```

build 323

## ROPE_CHANGE_SCRIPT_OWNER

```c
void ROPE_CHANGE_SCRIPT_OWNER(Any p0, BOOL p1, BOOL p2)  // 0xB1B6216CA2E7B55E
```

build 323

## ROPE_CONVERT_TO_SIMPLE

```c
void ROPE_CONVERT_TO_SIMPLE(int ropeId)  // 0x5389D48EFA2F079A
```

build 323

## ROPE_DRAW_ENABLED

```c
void ROPE_DRAW_ENABLED(int* ropeId, BOOL p1)  // 0xA1AE736541B0FCA3
```

build 1868

## ROPE_DRAW_SHADOW_ENABLED

```c
void ROPE_DRAW_SHADOW_ENABLED(int* ropeId, BOOL toggle)  // 0xF159A63806BB5BA8
```

build 323

## ROPE_FORCE_LENGTH

```c
void ROPE_FORCE_LENGTH(int ropeId, float length)  // 0xD009F759A723DB1B
```

build 323

> Forces a rope to a certain length.

## ROPE_GET_DISTANCE_BETWEEN_ENDS

```c
float ROPE_GET_DISTANCE_BETWEEN_ENDS(int ropeId)  // 0x73040398DFF9A4A6
```

build 323 · old names: `_GET_ROPE_LENGTH`

## ROPE_LOAD_TEXTURES

```c
void ROPE_LOAD_TEXTURES()  // 0x9B9039DBF2D258C1
```

build 323

> Loads rope textures for all ropes in the current scene.

## ROPE_RESET_LENGTH

```c
void ROPE_RESET_LENGTH(int ropeId, float length)  // 0xC16DE94D9BEA14A0
```

build 323

> Reset a rope to a certain length.

## ROPE_SET_REFFRAMEVELOCITY_COLLIDERORDER

```c
void ROPE_SET_REFFRAMEVELOCITY_COLLIDERORDER(int ropeId, int p1)  // 0xB743F735C03D7810
```

build 323

## ROPE_SET_SMOOTH_REELIN

```c
void ROPE_SET_SMOOTH_REELIN(int ropeId, BOOL p1)  // 0x36CCB9BE67B970FD
```

build 323

## ROPE_SET_UPDATE_ORDER

```c
void ROPE_SET_UPDATE_ORDER(int ropeId, Any p1)  // 0xDC57A637A20006ED
```

build 323

## ROPE_SET_UPDATE_PINVERTS

```c
void ROPE_SET_UPDATE_PINVERTS(int ropeId)  // 0xC8D667EE52114ABA
```

build 323

## ROPE_UNLOAD_TEXTURES

```c
void ROPE_UNLOAD_TEXTURES()  // 0x6CE36C35C1AC8163
```

build 323

> Unloads rope textures for all ropes in the current scene.

## SET_CG_AT_BOUNDCENTER

```c
void SET_CG_AT_BOUNDCENTER(Entity entity)  // 0xBE520D9761FF811F
```

build 323

## SET_CGOFFSET

```c
void SET_CGOFFSET(Entity entity, float x, float y, float z)  // 0xD8FA3908D7B86904
```

build 323

## SET_DAMPING

```c
void SET_DAMPING(Entity entity, int vertex, float value)  // 0xEEA3B200A6FEB65B
```

build 323

## SET_DISABLE_BREAKING

```c
void SET_DISABLE_BREAKING(Object object, BOOL toggle)  // 0x5CEC1A84620E7D5B
```

build 323

## SET_DISABLE_FRAG_DAMAGE

```c
void SET_DISABLE_FRAG_DAMAGE(Object object, BOOL toggle)  // 0x01BA3AED21C16CFB
```

build 323

## SET_IN_ARENA_MODE

```c
void SET_IN_ARENA_MODE(BOOL toggle)  // 0xAA6A6098851C396F
```

build 1604 · old names: `_SET_LAUNCH_CONTROL_ENABLED`

> Related to the lower-end of a vehicles fTractionCurve, e.g., from standing starts and acceleration from low/zero speeds.

## SET_IN_STUNT_MODE

```c
void SET_IN_STUNT_MODE(BOOL p0)  // 0x9EBD751E5787BAF2
```

build 791

## SET_USE_KINEMATIC_PHYSICS

```c
void SET_USE_KINEMATIC_PHYSICS(Entity entity, BOOL toggle)  // 0x15F944730C832252
```

build 463 · old names: `_SET_ENTITY_PROOF_UNK`

## START_ROPE_UNWINDING_FRONT

```c
void START_ROPE_UNWINDING_FRONT(int ropeId)  // 0x538D1179EC1AA9A9
```

build 323

## START_ROPE_WINDING

```c
void START_ROPE_WINDING(int ropeId)  // 0x1461C72C889E343E
```

build 323

## STOP_ROPE_UNWINDING_FRONT

```c
void STOP_ROPE_UNWINDING_FRONT(int ropeId)  // 0xFFF3A50779EFBBB3
```

build 323

## STOP_ROPE_WINDING

```c
void STOP_ROPE_WINDING(int ropeId)  // 0xCB2D4AB84A19AA7C
```

build 323

## UNPIN_ROPE_VERTEX

```c
void UNPIN_ROPE_VERTEX(int ropeId, int vertex)  // 0x4B5AE2EEE4A8F180
```

build 323

