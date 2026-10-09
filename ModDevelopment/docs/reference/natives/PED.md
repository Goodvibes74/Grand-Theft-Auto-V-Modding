# PED natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _BLOCK_PED_FROM_WRITHING_WHEN_INJURED

```c
void _BLOCK_PED_FROM_WRITHING_WHEN_INJURED(Ped ped, BOOL toggle)  // 0x5CBD1684E56BF99D
```

build 3889

## _GENERATE_PED_DAMAGE_EVENT

```c
void _GENERATE_PED_DAMAGE_EVENT(Ped ped, float x, float y, float z, Hash weaponType)  // 0x6D1FCD0950EFA3DD
```

build 3889

## _HAS_PED_CLEAR_LOS_TO_ENTITY

```c
BOOL _HAS_PED_CLEAR_LOS_TO_ENTITY(Ped ped, Entity entity, float x, float y, float z, int p5, BOOL p6, BOOL p7)  // 0xA32ABFEB2A03B306
```

build 3095

## _SET_BLOCK_AMBIENT_PEDS_FROM_DROPPING_WEAPONS_THIS_FRAME

```c
void _SET_BLOCK_AMBIENT_PEDS_FROM_DROPPING_WEAPONS_THIS_FRAME()  // 0xC73EFFC5E043A8BA
```

build 3258

## _SET_PED_SURVIVES_BEING_OUT_OF_WATER

```c
BOOL _SET_PED_SURVIVES_BEING_OUT_OF_WATER(Ped ped, BOOL toggle)  // 0x100CD221F572F6E1
```

build 3407

## ADD_ARMOUR_TO_PED

```c
void ADD_ARMOUR_TO_PED(Ped ped, int amount)  // 0x5BA652A0CD14DF2F
```

build 323

> Same as SET_PED_ARMOUR, but ADDS 'amount' to the armor the Ped already has.

## ADD_PED_DECORATION_FROM_HASHES

```c
void ADD_PED_DECORATION_FROM_HASHES(Ped ped, Hash collection, Hash overlay)  // 0x5F5D1665E352A839
```

build 323 · old names: `_APPLY_PED_OVERLAY`, `_SET_PED_DECORATION`

> Applies an Item from a PedDecorationCollection to a ped. These include tattoos and shirt decals.
> 
> collection - PedDecorationCollection filename hash
> overlay - Item name hash
> 
> Example:
> Entry inside "mpbeach_overlays.xml" -
> <Item>
>   <uvPos x="0.500000" y="0.500000" />
>   <scale x="0.600000" y="0.500000" />
>   <rotation value="0.000000" />
>   <nameHash>FM_Hair_Fuzz</nameHash>
>   <txdHash>mp_hair_fuzz</txdHash>
>   <txtHash>mp_hair_fuzz</txtHash>
>   <zone>ZONE_HEAD</zone>
>   <type>TYPE_TATTOO</type>
>   <faction>FM</faction>
>   <garment>All</garment>
>   <gender>GENDER_DONTCARE</gender>
>   <award />
>   <awardLevel />
> </Item>
> 
> Code:
> PED::ADD_PED_DECORATION_FROM_HASHES(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("mpbeach_overlays"), MISC::GET_HASH_KEY("fm_hair_fuzz"))
> 
> Full list of ped overlays / decorations by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedOverlayCollections.json

## ADD_PED_DECORATION_FROM_HASHES_IN_CORONA

```c
void ADD_PED_DECORATION_FROM_HASHES_IN_CORONA(Ped ped, Hash collection, Hash overlay)  // 0x5619BFA07CFD7833
```

build 323 · old names: `_SET_PED_FACIAL_DECORATION`

> Full list of ped overlays / decorations by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedOverlayCollections.json

## ADD_RELATIONSHIP_GROUP

```c
BOOL ADD_RELATIONSHIP_GROUP(const char* name, Hash* groupHash)  // 0xF372BC22FCB88606
```

build 323

> Can't select void. This function returns nothing. The hash of the created relationship group is output in the second parameter.

## ADD_SCENARIO_BLOCKING_AREA

```c
int ADD_SCENARIO_BLOCKING_AREA(float x1, float y1, float z1, float x2, float y2, float z2, BOOL p6, BOOL p7, BOOL p8, BOOL p9, Any p10)  // 0x1B5C85C612E5256E
```

build 323

## APPLY_DAMAGE_TO_PED

```c
void APPLY_DAMAGE_TO_PED(Ped ped, int damageAmount, BOOL p2, Any p3, Hash weaponType)  // 0x697157CED63F18D4
```

build 323

> damages a ped with the given amount

## APPLY_PED_BLOOD

```c
void APPLY_PED_BLOOD(Ped ped, int boneIndex, float xRot, float yRot, float zRot, const char* woundType)  // 0x83F7E01C7B769A26
```

build 323

> woundTypes:
> - soak_splat
> - wound_sheet
> - BulletSmall
> - BulletLarge
> - ShotgunSmall
> - ShotgunSmallMonolithic
> - ShotgunLarge
> - ShotgunLargeMonolithic
> - NonFatalHeadshot
> - stab
> - BasicSlash
> - Scripted_Ped_Splash_Back
> - BackSplash

## APPLY_PED_BLOOD_BY_ZONE

```c
void APPLY_PED_BLOOD_BY_ZONE(Ped ped, int p1, float p2, float p3, const char* p4)  // 0x3311E47B91EDCBBC
```

build 323

## APPLY_PED_BLOOD_DAMAGE_BY_ZONE

```c
void APPLY_PED_BLOOD_DAMAGE_BY_ZONE(Ped ped, Any p1, float p2, float p3, Any p4)  // 0x816F6981C60BF53B
```

build 323

## APPLY_PED_BLOOD_SPECIFIC

```c
void APPLY_PED_BLOOD_SPECIFIC(Ped ped, int p1, float p2, float p3, float p4, float p5, int p6, float p7, const char* p8)  // 0xEF0D582CBF2D9B0F
```

build 323

## APPLY_PED_DAMAGE_DECAL

```c
void APPLY_PED_DAMAGE_DECAL(Ped ped, int damageZone, float xOffset, float yOffset, float heading, float scale, float alpha, int variation, BOOL fadeIn, const char* decalName)  // 0x397C38AA7B4A5F83
```

build 323

> enum eDamageZone
> {
> 	DZ_Torso = 0,
> 	DZ_Head,
> 	DZ_LeftArm,
> 	DZ_RightArm,
> 	DZ_LeftLeg,
> 	DZ_RightLeg,
> };
> 
> Decal Names:
> scar
> blushing
> cs_flush_anger
> cs_flush_anger_face
> bruise
> bruise_large
> herpes
> ArmorBullet
> basic_dirt_cloth
> basic_dirt_skin
> cs_trev1_dirt
> 
> APPLY_PED_DAMAGE_DECAL(ped, 1, 0.5f, 0.513f, 0f, 1f, unk, 0, 0, "blushing");

## APPLY_PED_DAMAGE_PACK

```c
void APPLY_PED_DAMAGE_PACK(Ped ped, const char* damagePack, float damage, float mult)  // 0x46DF918788CB093F
```

build 323

> Damage Packs:
> 
> "SCR_TrevorTreeBang"
> "HOSPITAL_0"
> "HOSPITAL_1"
> "HOSPITAL_2"
> "HOSPITAL_3"
> "HOSPITAL_4"
> "HOSPITAL_5"
> "HOSPITAL_6"
> "HOSPITAL_7"
> "HOSPITAL_8"
> "HOSPITAL_9"
> "SCR_Dumpster"
> "BigHitByVehicle"
> "SCR_Finale_Michael_Face"
> "SCR_Franklin_finb"
> "SCR_Finale_Michael"
> "SCR_Franklin_finb2"
> "Explosion_Med"
> "SCR_Torture"
> "SCR_TracySplash"
> "Skin_Melee_0"
> 
> Additional damage packs:
> 
> https://gist.github.com/alexguirre/f3f47f75ddcf617f416f3c8a55ae2227
> Full list of ped damage packs by DurtyFree https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedDamagePacks.json

## ATTACH_SYNCHRONIZED_SCENE_TO_ENTITY

```c
void ATTACH_SYNCHRONIZED_SCENE_TO_ENTITY(int sceneID, Entity entity, int boneIndex)  // 0x272E4723B56A3B96
```

build 323

## BLOCK_PED_FROM_GENERATING_DEAD_BODY_EVENTS_WHEN_DEAD

```c
void BLOCK_PED_FROM_GENERATING_DEAD_BODY_EVENTS_WHEN_DEAD(Ped ped, BOOL toggle)  // 0xE43A13C9E4CCCBCF
```

build 323 · old names: `_BLOCK_PED_DEAD_BODY_SHOCKING_EVENTS`

## CAN_CREATE_RANDOM_BIKE_RIDER

```c
BOOL CAN_CREATE_RANDOM_BIKE_RIDER()  // 0xEACEEDA81751915C
```

build 323

## CAN_CREATE_RANDOM_COPS

```c
BOOL CAN_CREATE_RANDOM_COPS()  // 0x5EE2CAFF7F17770D
```

build 323

## CAN_CREATE_RANDOM_DRIVER

```c
BOOL CAN_CREATE_RANDOM_DRIVER()  // 0xB8EB95E5B4E56978
```

build 323

## CAN_CREATE_RANDOM_PED

```c
BOOL CAN_CREATE_RANDOM_PED(BOOL p0)  // 0x3E8349C08E4B82E4
```

build 323

## CAN_KNOCK_PED_OFF_VEHICLE

```c
BOOL CAN_KNOCK_PED_OFF_VEHICLE(Ped ped)  // 0x51AC07A44D4F5B8A
```

build 323

## CAN_PED_IN_COMBAT_SEE_TARGET

```c
BOOL CAN_PED_IN_COMBAT_SEE_TARGET(Ped ped, Ped target)  // 0xEAD42DE3610D0721
```

build 323

## CAN_PED_RAGDOLL

```c
BOOL CAN_PED_RAGDOLL(Ped ped)  // 0x128F79EDCECE4FD5
```

build 323

> Prevents the ped from going limp.
> 
> [Example: Can prevent peds from falling when standing on moving vehicles.]

## CAN_PED_SEE_HATED_PED

```c
BOOL CAN_PED_SEE_HATED_PED(Ped ped1, Ped ped2)  // 0x6CD5A433374D4CFB
```

build 323 · old names: `_CAN_PED_SEE_PED`

## CAN_PED_SHUFFLE_TO_OR_FROM_EXTRA_SEAT

```c
BOOL CAN_PED_SHUFFLE_TO_OR_FROM_EXTRA_SEAT(Ped ped, int* p1)  // 0x2DFC81C9B9608549
```

build 944

## CAN_PED_SHUFFLE_TO_OR_FROM_TURRET_SEAT

```c
BOOL CAN_PED_SHUFFLE_TO_OR_FROM_TURRET_SEAT(Ped ped, int* p1)  // 0x9C6A6C19B6C0C496
```

build 323

## CLEAR_ALL_PED_PROPS

```c
void CLEAR_ALL_PED_PROPS(Ped ped, Any p1)  // 0xCD8A7537A9B52F06
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## CLEAR_ALL_PED_VEHICLE_FORCED_SEAT_USAGE

```c
void CLEAR_ALL_PED_VEHICLE_FORCED_SEAT_USAGE(Ped ped)  // 0xE6CA85E7259CE16B
```

build 323

## CLEAR_COVER_POINT_FOR_PED

```c
void CLEAR_COVER_POINT_FOR_PED(Ped ped)  // 0x637822DC2AFEEBF8
```

build 1493 · old names: `_CLEAR_FACIAL_CLIPSET_OVERRIDE`

## CLEAR_FACIAL_IDLE_ANIM_OVERRIDE

```c
void CLEAR_FACIAL_IDLE_ANIM_OVERRIDE(Ped ped)  // 0x726256CC1EEB182F
```

build 323

## CLEAR_PED_ALTERNATE_MOVEMENT_ANIM

```c
void CLEAR_PED_ALTERNATE_MOVEMENT_ANIM(Ped ped, int stance, float p2)  // 0xD8D19675ED5FBDCE
```

build 323

## CLEAR_PED_ALTERNATE_WALK_ANIM

```c
void CLEAR_PED_ALTERNATE_WALK_ANIM(Ped ped, float p1)  // 0x8844BBFCE30AA9E9
```

build 323

## CLEAR_PED_BLOOD_DAMAGE

```c
void CLEAR_PED_BLOOD_DAMAGE(Ped ped)  // 0x8FE22675A5A45817
```

build 323

## CLEAR_PED_BLOOD_DAMAGE_BY_ZONE

```c
void CLEAR_PED_BLOOD_DAMAGE_BY_ZONE(Ped ped, int p1)  // 0x56E3B78C5408D9F4
```

build 323

## CLEAR_PED_DAMAGE_DECAL_BY_ZONE

```c
void CLEAR_PED_DAMAGE_DECAL_BY_ZONE(Ped ped, int p1, const char* p2)  // 0x523C79AEEFCC4A2A
```

build 323

> p1: from 0 to 5 in the b617d scripts.
> p2: "blushing" and "ALL" found in the b617d scripts.

## CLEAR_PED_DECORATIONS

```c
void CLEAR_PED_DECORATIONS(Ped ped)  // 0x0E5173C163976E38
```

build 323

## CLEAR_PED_DECORATIONS_LEAVE_SCARS

```c
void CLEAR_PED_DECORATIONS_LEAVE_SCARS(Ped ped)  // 0xE3B27E70CEAB9F0C
```

build 323 · old names: `_CLEAR_PED_FACIAL_DECORATIONS`

## CLEAR_PED_DRIVE_BY_CLIPSET_OVERRIDE

```c
void CLEAR_PED_DRIVE_BY_CLIPSET_OVERRIDE(Ped ped)  // 0x4AFE3690D7E0B5AC
```

build 323

## CLEAR_PED_ENV_DIRT

```c
void CLEAR_PED_ENV_DIRT(Ped ped)  // 0x6585D955A68452A5
```

build 323

## CLEAR_PED_FALL_UPPER_BODY_CLIPSET_OVERRIDE

```c
void CLEAR_PED_FALL_UPPER_BODY_CLIPSET_OVERRIDE(Ped ped)  // 0x80054D7FCC70EEC6
```

build 323

## CLEAR_PED_LAST_DAMAGE_BONE

```c
void CLEAR_PED_LAST_DAMAGE_BONE(Ped ped)  // 0x8EF6B7AC68E2F01B
```

build 323

## CLEAR_PED_MOTION_IN_COVER_CLIPSET_OVERRIDE

```c
void CLEAR_PED_MOTION_IN_COVER_CLIPSET_OVERRIDE(Ped ped)  // 0xC79196DCB36F6121
```

build 323 · old names: `_CLEAR_PED_COVER_CLIPSET_OVERRIDE`

## CLEAR_PED_NON_CREATION_AREA

```c
void CLEAR_PED_NON_CREATION_AREA()  // 0x2E05208086BA0651
```

build 323

## CLEAR_PED_PARACHUTE_PACK_VARIATION

```c
void CLEAR_PED_PARACHUTE_PACK_VARIATION(Ped ped)  // 0x1280804F7CFD2D6C
```

build 323

## CLEAR_PED_PROP

```c
void CLEAR_PED_PROP(Ped ped, int propId, Any p2)  // 0x0943E5B8E078E76E
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## CLEAR_PED_SCUBA_GEAR_VARIATION

```c
void CLEAR_PED_SCUBA_GEAR_VARIATION(Ped ped)  // 0xB50EB4CCB29704AC
```

build 323 · old names: `_REMOVE_PED_SCUBA_GEAR_NOW`

> Removes the scubagear (for mp male: component id: 8, drawableId: 123, textureId: any) from peds. Does not play the 'remove scuba gear' animation, but instantly removes it.

## CLEAR_PED_STORED_HAT_PROP

```c
void CLEAR_PED_STORED_HAT_PROP(Ped ped)  // 0x687C0B594907D2E8
```

build 323

## CLEAR_PED_WETNESS

```c
void CLEAR_PED_WETNESS(Ped ped)  // 0x9C720776DAA43E7E
```

build 323

> It clears the wetness of the selected Ped/Player. Clothes have to be wet to notice the difference.

## CLEAR_RAGDOLL_BLOCKING_FLAGS

```c
void CLEAR_RAGDOLL_BLOCKING_FLAGS(Ped ped, int blockingFlag)  // 0xD86D101FCFD00A4B
```

build 323 · old names: `_RESET_PED_RAGDOLL_BLOCKING_FLAGS`

> See SET_RAGDOLL_BLOCKING_FLAGS for flags

## CLEAR_RELATIONSHIP_BETWEEN_GROUPS

```c
void CLEAR_RELATIONSHIP_BETWEEN_GROUPS(int relationship, Hash group1, Hash group2)  // 0x5E29243FB56FC6D4
```

build 323

> Clears the relationship between two groups. This should be called twice (once for each group).
> 
> Relationship types:
> 0 = Companion
> 1 = Respect
> 2 = Like
> 3 = Neutral
> 4 = Dislike
> 5 = Hate
> 255 = Pedestrians
> (Credits: Inco)
> 
> Example:
> PED::CLEAR_RELATIONSHIP_BETWEEN_GROUPS(2, l_1017, 0xA49E591C);
> PED::CLEAR_RELATIONSHIP_BETWEEN_GROUPS(2, 0xA49E591C, l_1017);

## CLONE_PED

```c
Ped CLONE_PED(Ped ped, BOOL isNetwork, BOOL bScriptHostPed, BOOL copyHeadBlendFlag)  // 0xEF29A16337FACADB
```

build 323

## CLONE_PED_ALT

```c
Ped CLONE_PED_ALT(Ped ped, BOOL isNetwork, BOOL bScriptHostPed, BOOL copyHeadBlendFlag, BOOL p4)  // 0x668FD40BCBA5DE48
```

build 463 · old names: `_CLONE_PED_2`, `_CLONE_PED_EX`

## CLONE_PED_TO_TARGET

```c
void CLONE_PED_TO_TARGET(Ped ped, Ped targetPed)  // 0xE952D6431689AD9A
```

build 323 · old names: `_ASSIGN_PLAYER_TO_PED`

> Copies ped's components and props to targetPed.

## CLONE_PED_TO_TARGET_ALT

```c
void CLONE_PED_TO_TARGET_ALT(Ped ped, Ped targetPed, BOOL p2)  // 0x148B08C2D2ACB884
```

build 463 · old names: `_CLONE_PED_TO_TARGET_EX`

## COUNT_PEDS_IN_COMBAT_WITH_TARGET

```c
int COUNT_PEDS_IN_COMBAT_WITH_TARGET(Ped ped)  // 0x5407B7288D0478B7
```

build 323

## COUNT_PEDS_IN_COMBAT_WITH_TARGET_WITHIN_RADIUS

```c
int COUNT_PEDS_IN_COMBAT_WITH_TARGET_WITHIN_RADIUS(Ped ped, float x, float y, float z, float radius)  // 0x336B3D200AB007CB
```

build 323

## CREATE_GROUP

```c
int CREATE_GROUP(int unused)  // 0x90370EBE0FEE1A3D
```

build 323

> Creates a new ped group.
> Groups can contain up to 8 peds.
> 
> The parameter is unused.
> 
> Returns a handle to the created group, or 0 if a group couldn't be created.

## CREATE_NM_MESSAGE

```c
void CREATE_NM_MESSAGE(BOOL startImmediately, int messageId)  // 0x418EF2A1BCE56685
```

build 323

> Creates a new NaturalMotion message.
> 
> startImmediately: If set to true, the character will perform the message the moment it receives it by GIVE_PED_NM_MESSAGE. If false, the Ped will get the message but won't perform it yet. While it's a boolean value, if negative, the message will not be initialized.
> messageId: The ID of the NaturalMotion message.
> 
> If a message already exists, this function does nothing. A message exists until the point it has been successfully dispatched by GIVE_PED_NM_MESSAGE.

## CREATE_PARACHUTE_BAG_OBJECT

```c
Object CREATE_PARACHUTE_BAG_OBJECT(Ped ped, BOOL p1, BOOL p2)  // 0x8C4F3BF23B6237DB
```

build 323 · old names: `_CREATE_PARACHUTE_OBJECT`

## CREATE_PED

```c
Ped CREATE_PED(int pedType, Hash modelHash, float x, float y, float z, float heading, BOOL isNetwork, BOOL bScriptHostPed)  // 0xD49F9B0955C367DE
```

build 323

> https://alloc8or.re/gta5/doc/enums/ePedType.txt
> 
> Full list of peds by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/peds.json

## CREATE_PED_INSIDE_VEHICLE

```c
Ped CREATE_PED_INSIDE_VEHICLE(Vehicle vehicle, int pedType, Hash modelHash, int seat, BOOL isNetwork, BOOL bScriptHostPed)  // 0x7DD959874C1FD534
```

build 323

> pedType: see CREATE_PED
> 
> Full list of peds by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/peds.json

## CREATE_RANDOM_PED

```c
Ped CREATE_RANDOM_PED(float posX, float posY, float posZ)  // 0xB4AC7D0CF06BFE8F
```

build 323

> vb.net
> Dim ped_handle As Integer
>                     With Game.Player.Character
>                         Dim pos As Vector3 = .Position + .ForwardVector * 3
>                         ped_handle = Native.Function.Call(Of Integer)(Hash.CREATE_RANDOM_PED, pos.X, pos.Y, pos.Z)
>                     End With
> 
> Creates a Ped at the specified location, returns the Ped Handle.  
> Ped will not act until SET_PED_AS_NO_LONGER_NEEDED is called.

## CREATE_RANDOM_PED_AS_DRIVER

```c
Ped CREATE_RANDOM_PED_AS_DRIVER(Vehicle vehicle, BOOL returnHandle)  // 0x9B62392B474F44A0
```

build 323

## CREATE_SYNCHRONIZED_SCENE

```c
int CREATE_SYNCHRONIZED_SCENE(float x, float y, float z, float roll, float pitch, float yaw, int p6)  // 0x8C18E0F9080ADD73
```

build 323

> p6 always 2 (but it doesnt seem to matter...)
> 
> roll and pitch 0
> yaw to Ped.rotation

## CREATE_SYNCHRONIZED_SCENE_AT_MAP_OBJECT

```c
int CREATE_SYNCHRONIZED_SCENE_AT_MAP_OBJECT(float x, float y, float z, float radius, Hash object)  // 0x62EC273D00187DCA
```

build 323 · old names: `_CREATE_SYNCHRONIZED_SCENE_2`

## DELETE_PED

```c
void DELETE_PED(Ped* ped)  // 0x9614299DCB53E54B
```

build 323

> Deletes the specified ped, then sets the handle pointed to by the pointer to NULL.

## DETACH_SYNCHRONIZED_SCENE

```c
void DETACH_SYNCHRONIZED_SCENE(int sceneID)  // 0x6D38F1F04CBB37EA
```

build 323

## DISABLE_HEAD_BLEND_PALETTE_COLOR

```c
void DISABLE_HEAD_BLEND_PALETTE_COLOR(Ped ped)  // 0xA21C118553BBDF02
```

build 323

## DISABLE_PED_HEATSCALE_OVERRIDE

```c
void DISABLE_PED_HEATSCALE_OVERRIDE(Ped ped)  // 0x600048C60D5C2C51
```

build 323

## DISABLE_PED_INJURED_ON_GROUND_BEHAVIOUR

```c
void DISABLE_PED_INJURED_ON_GROUND_BEHAVIOUR(Ped ped)  // 0x733C87D4CE22BEA2
```

build 323

## DOES_GROUP_EXIST

```c
BOOL DOES_GROUP_EXIST(int groupId)  // 0x7C6B0C22F9F40BBE
```

build 323

## DOES_RELATIONSHIP_GROUP_EXIST

```c
BOOL DOES_RELATIONSHIP_GROUP_EXIST(Hash groupHash)  // 0xCC6E3B6BB69501F1
```

build 505 · old names: `_DOES_RELATIONSHIP_GROUP_EXIST`

## DOES_SCENARIO_BLOCKING_AREA_EXISTS

```c
BOOL DOES_SCENARIO_BLOCKING_AREA_EXISTS(float x1, float y1, float z1, float x2, float y2, float z2)  // 0x8A24B067D175A7BD
```

build 678 · old names: `_DOES_SCENARIO_BLOCKING_AREA_EXIST`

## DROP_AMBIENT_PROP

```c
void DROP_AMBIENT_PROP(Ped ped)  // 0xAFF4710E2A0A6C12
```

build 323

## ENABLE_MP_LIGHT

```c
void ENABLE_MP_LIGHT(Ped ped, BOOL toggle)  // 0xEE2476B9EE4A094F
```

build 1493 · old names: `_SET_ENABLE_SCUBA_GEAR_LIGHT`

## EXPLODE_PED_HEAD

```c
void EXPLODE_PED_HEAD(Ped ped, Hash weaponHash)  // 0x2D05CED3A38D0F3A
```

build 323

> Forces the ped to fall back and kills it.
> 
> It doesn't really explode the ped's head but it kills the ped

## FINALIZE_HEAD_BLEND

```c
void FINALIZE_HEAD_BLEND(Ped ped)  // 0x4668D80430D6C299
```

build 323

## FORCE_ALL_HEADING_VALUES_TO_ALIGN

```c
void FORCE_ALL_HEADING_VALUES_TO_ALIGN(Ped ped)  // 0xFF287323B0E2C69A
```

build 323 · old names: `_FREEZE_PED_CAMERA_ROTATION`

## FORCE_INSTANT_LEG_IK_SETUP

```c
void FORCE_INSTANT_LEG_IK_SETUP(Ped ped)  // 0xED3C76ADFA6D07C4
```

build 323

## FORCE_PED_AI_AND_ANIMATION_UPDATE

```c
void FORCE_PED_AI_AND_ANIMATION_UPDATE(Ped ped, BOOL p1, BOOL p2)  // 0x2208438012482A1A
```

build 323

## FORCE_PED_MOTION_STATE

```c
BOOL FORCE_PED_MOTION_STATE(Ped ped, Hash motionStateHash, BOOL shouldReset, int updateState, BOOL forceAIPreCameraUpdate)  // 0xF28965D04F570DCA
```

build 323

> enum CPedMotionStates__eMotionState
> {
> 	MotionState_None = 0xEE717723,
> 	MotionState_Idle = 0x9072A713,
> 	MotionState_Walk = 0xD827C3DB,
> 	MotionState_Run = 0xFFF7E7A4,
> 	MotionState_Sprint = 0xBD8817DB,
> 	MotionState_Crouch_Idle = 0x43FB099E,
> 	MotionState_Crouch_Walk = 0x08C31A98,
> 	MotionState_Crouch_Run = 0x3593CF09,
> 	MotionState_DoNothing = 0x0EC17E58,
> 	MotionState_AnimatedVelocity = 0x551AAC43,
> 	MotionState_InVehicle = 0x94D9D58D,
> 	MotionState_Aiming = 0x3F67C6AF,
> 	MotionState_Diving_Idle = 0x4848CDED,
> 	MotionState_Diving_Swim = 0x916E828C,
> 	MotionState_Swimming_TreadWater = 0xD1BF11C7,
> 	MotionState_Dead = 0x0DBB071C,
> 	MotionState_Stealth_Idle = 0x422D7A25,
> 	MotionState_Stealth_Walk = 0x042AB6A2,
> 	MotionState_Stealth_Run = 0xFB0B79E1,
> 	MotionState_Parachuting = 0xBAC0F10B,
> 	MotionState_ActionMode_Idle = 0xDA40A0DC,
> 	MotionState_ActionMode_Walk = 0xD2905EA7,
> 	MotionState_ActionMode_Run = 0x31BADE14,
> 	MotionState_Jetpack = 0x535E6A5E
> };

## FORCE_PED_TO_OPEN_PARACHUTE

```c
void FORCE_PED_TO_OPEN_PARACHUTE(Ped ped)  // 0x16E42E800B472221
```

build 323

## FORCE_ZERO_MASS_IN_COLLISIONS

```c
void FORCE_ZERO_MASS_IN_COLLISIONS(Ped ped)  // 0xD33DAA36272177C4
```

build 323

## GET_ANIM_INITIAL_OFFSET_POSITION

```c
Vector3 GET_ANIM_INITIAL_OFFSET_POSITION(const char* animDict, const char* animName, float x, float y, float z, float xRot, float yRot, float zRot, float p8, int p9)  // 0xBE22B26DD764C040
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## GET_ANIM_INITIAL_OFFSET_ROTATION

```c
Vector3 GET_ANIM_INITIAL_OFFSET_ROTATION(const char* animDict, const char* animName, float x, float y, float z, float xRot, float yRot, float zRot, float p8, int p9)  // 0x4B805E6046EE9E47
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## GET_CAN_PED_BE_GRABBED_BY_SCRIPT

```c
BOOL GET_CAN_PED_BE_GRABBED_BY_SCRIPT(Ped ped, BOOL p1, BOOL p2, BOOL p3, BOOL p4, BOOL p5, BOOL p6, BOOL p7, Any p8)  // 0x03EA03AF85A85CB7
```

build 323

## GET_CLOSEST_PED

```c
BOOL GET_CLOSEST_PED(float x, float y, float z, float radius, BOOL p4, BOOL p5, Ped* outPed, BOOL p7, BOOL p8, int pedType)  // 0xC33AB876A77F8164
```

build 323

> Gets the closest ped in a radius.
> 
> Ped Types:
> Any ped = -1
> Player = 1
> Male = 4 
> Female = 5 
> Cop = 6
> Human = 26
> SWAT = 27 
> Animal = 28
> Army = 29
> 
> ------------------
> P4 P5 P7 P8
> 1  0  x  x  = return nearest walking Ped
> 1  x  0  x  = return nearest walking Ped
> x  1  1  x  = return Ped you are using
> 0  0  x  x  = no effect
> 0  x  0  x  = no effect
> 
> x = can be 1 or 0. Does not have any obvious changes.
> 
> This function does not return ped who is:
> 1. Standing still
> 2. Driving
> 3. Fleeing
> 4. Attacking
> 
> This function only work if the ped is:
> 1. walking normally.
> 2. waiting to cross a road.
> 
> Note: PED::GET_PED_NEARBY_PEDS works for more peds.

## GET_COMBAT_FLOAT

```c
float GET_COMBAT_FLOAT(Ped ped, int p1)  // 0x52DFF8A10508090A
```

build 323

> p0: Ped Handle
> p1: int i | 0 <= i <= 27
> 
> p1 probably refers to the attributes configured in combatbehavior.meta. There are 13. Example:
> 
> <BlindFireChance value="0.1"/>
> <WeaponShootRateModifier value="1.0"/>
> <TimeBetweenBurstsInCover value="1.25"/>
> <BurstDurationInCover value="2.0"/>
> <TimeBetweenPeeks value="10.0"/>
> <WeaponAccuracy value="0.18"/>
> <FightProficiency value="0.8"/>
> <StrafeWhenMovingChance value="1.0"/>
> <WalkWhenStrafingChance value="0.0"/>
> <AttackWindowDistanceForCover value="55.0"/>
> <TimeToInvalidateInjuredTarget value="9.0"/>
> <TriggerChargeTime_Near value="4.0"/>
> <TriggerChargeTime_Far value="10.0"/>
> 
> -------------Confirmed by editing combatbehavior.meta:
> p1:
> 0=BlindFireChance
> 1=BurstDurationInCover
> 3=TimeBetweenBurstsInCover
> 4=TimeBetweenPeeks
> 5=StrafeWhenMovingChance
> 8=WalkWhenStrafingChance
> 11=AttackWindowDistanceForCover
> 12=TimeToInvalidateInjuredTarget
> 16=OptimalCoverDistance
> 

## GET_DEAD_PED_PICKUP_COORDS

```c
Vector3 GET_DEAD_PED_PICKUP_COORDS(Ped ped, float p1, float p2)  // 0xCD5003B097200F36
```

build 323

## GET_DEFAULT_SECONDARY_TINT_FOR_BARBER

```c
int GET_DEFAULT_SECONDARY_TINT_FOR_BARBER(int colorID)  // 0xAAA6A3698A69E048
```

build 323 · old names: `_GET_DEFAULT_SECONDARY_HAIR_BARBER_COLOR`

## GET_DEFAULT_SECONDARY_TINT_FOR_CREATOR

```c
int GET_DEFAULT_SECONDARY_TINT_FOR_CREATOR(int colorId)  // 0xEA9960D07DADCF10
```

build 323 · old names: `_GET_DEFAULT_SECONDARY_HAIR_CREATOR_COLOR`

## GET_FM_FEMALE_SHOP_PED_APPAREL_ITEM_INDEX

```c
int GET_FM_FEMALE_SHOP_PED_APPAREL_ITEM_INDEX(int p0)  // 0xF033419D1B81FAE8
```

build 323

## GET_FM_MALE_SHOP_PED_APPAREL_ITEM_INDEX

```c
int GET_FM_MALE_SHOP_PED_APPAREL_ITEM_INDEX(int p0)  // 0x1E77FA7A62EE6C4C
```

build 323

## GET_GROUP_SIZE

```c
void GET_GROUP_SIZE(int groupID, Any* p1, int* sizeInMembers)  // 0x8DE69FE35CA09A45
```

build 323

> p1 may be a BOOL representing whether or not the group even exists

## GET_HEAD_BLEND_EYE_COLOR

```c
int GET_HEAD_BLEND_EYE_COLOR(Ped ped)  // 0x76BBA2CEE66D47E9
```

build 1011 · old names: `_GET_PED_EYE_COLOR`

> A getter for SET_HEAD_BLEND_EYE_COLOR. Returns -1 if fails to get.

## GET_JACK_TARGET

```c
Ped GET_JACK_TARGET(Ped ped)  // 0x5486A79D9FBD342D
```

build 323

## GET_MELEE_TARGET_FOR_PED

```c
Ped GET_MELEE_TARGET_FOR_PED(Ped ped)  // 0x18A3E9EE1297FD39
```

build 323

## GET_MOUNT

```c
Ped GET_MOUNT(Ped ped)  // 0xE7E11B8DCBED1058
```

build 323

> 
> Function just returns 0
> void __fastcall ped__get_mount(NativeContext *a1)
> {
>   NativeContext *v1; // rbx@1
> 
>   v1 = a1;
>   GetAddressOfPedFromScriptHandle(a1->Args->Arg1);
>   v1->Returns->Item1= 0;
> }

## GET_MP_LIGHT_ENABLED

```c
BOOL GET_MP_LIGHT_ENABLED(Ped ped)  // 0x88274C11CF0D866D
```

build 1493 · old names: `_IS_SCUBA_GEAR_LIGHT_ENABLED`

## GET_MP_OUTFIT_DATA_FROM_METADATA

```c
BOOL GET_MP_OUTFIT_DATA_FROM_METADATA(Any* p0, Any* p1)  // 0x9E30E91FB03A2CAF
```

build 323

## GET_NUM_PED_HAIR_TINTS

```c
int GET_NUM_PED_HAIR_TINTS()  // 0xE5C0CF872C2AD150
```

build 323 · old names: `_GET_NUM_HAIR_COLORS`

## GET_NUM_PED_MAKEUP_TINTS

```c
int GET_NUM_PED_MAKEUP_TINTS()  // 0xD1F7CA1535D22818
```

build 323 · old names: `_GET_NUM_MAKEUP_COLORS`

## GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS

```c
int GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS(Ped ped, int componentId)  // 0x27561561732A7842
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS

```c
int GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS(Ped ped, int propId)  // 0x5FAF9754E789FB47
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS

```c
int GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS(Ped ped, int propId, int drawableId)  // 0xA6E7F1CEB523E171
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_NUMBER_OF_PED_TEXTURE_VARIATIONS

```c
int GET_NUMBER_OF_PED_TEXTURE_VARIATIONS(Ped ped, int componentId, int drawableId)  // 0x8F7156A3142A6BAD
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_PED_ACCURACY

```c
int GET_PED_ACCURACY(Ped ped)  // 0x37F4AD56ECBC0CD6
```

build 323

## GET_PED_ALERTNESS

```c
int GET_PED_ALERTNESS(Ped ped)  // 0xF6AA118530443FD2
```

build 323

> Returns the ped's alertness (0-3).
> 
> Values : 
> 
> 0 : Neutral
> 1 : Heard something (gun shot, hit, etc)
> 2 : Knows (the origin of the event)
> 3 : Fully alerted (is facing the event?)
> 
> If the Ped does not exist, returns -1.

## GET_PED_ARMOUR

```c
int GET_PED_ARMOUR(Ped ped)  // 0x9483AF821605B1D8
```

build 323

## GET_PED_AS_GROUP_LEADER

```c
Ped GET_PED_AS_GROUP_LEADER(int groupID)  // 0x5CCE68DBD5FE93EC
```

build 323 · old names: `_GET_PED_AS_GROUP_LEADER`

## GET_PED_AS_GROUP_MEMBER

```c
Ped GET_PED_AS_GROUP_MEMBER(int groupID, int memberNumber)  // 0x51455483CF23ED97
```

build 323

> from fm_mission_controller.c4 (variable names changed for clarity):
> 
> int groupID = PLAYER::GET_PLAYER_GROUP(PLAYER::PLAYER_ID());
> PED::GET_GROUP_SIZE(group, &unused, &groupSize);
> if (groupSize >= 1) {
> . . . . for (int memberNumber = 0; memberNumber < groupSize; memberNumber++) {
> . . . . . . . . Ped ped1 = PED::GET_PED_AS_GROUP_MEMBER(groupID, memberNumber);
> . . . . . . . . //and so on

## GET_PED_BONE_COORDS

```c
Vector3 GET_PED_BONE_COORDS(Ped ped, int boneId, float offsetX, float offsetY, float offsetZ)  // 0x17C07FC640E86B4E
```

build 323

> Gets the position of the specified bone of the specified ped.
> 
> ped: The ped to get the position of a bone from.
> boneId: The ID of the bone to get the position from. This is NOT the index.
> offsetX: The X-component of the offset to add to the position relative to the bone's rotation.
> offsetY: The Y-component of the offset to add to the position relative to the bone's rotation.
> offsetZ: The Z-component of the offset to add to the position relative to the bone's rotation.

## GET_PED_BONE_INDEX

```c
int GET_PED_BONE_INDEX(Ped ped, int boneId)  // 0x3F428D08BE5AAE31
```

build 323

> no bone= -1
> 
> boneIds:
>         SKEL_ROOT = 0x0,
>    SKEL_Pelvis = 0x2e28,
>  SKEL_L_Thigh = 0xe39f,
>     SKEL_L_Calf = 0xf9bb,
>  SKEL_L_Foot = 0x3779,
>  SKEL_L_Toe0 = 0x83c,
>   IK_L_Foot = 0xfedd,
>    PH_L_Foot = 0xe175,
>    MH_L_Knee = 0xb3fe,
>    SKEL_R_Thigh = 0xca72,
>     SKEL_R_Calf = 0x9000,
>  SKEL_R_Foot = 0xcc4d,
>  SKEL_R_Toe0 = 0x512d,
>  IK_R_Foot = 0x8aae,
>    PH_R_Foot = 0x60e6,
>    MH_R_Knee = 0x3fcf,
>    RB_L_ThighRoll = 0x5c57,
>   RB_R_ThighRoll = 0x192a,
>   SKEL_Spine_Root = 0xe0fd,
>  SKEL_Spine0 = 0x5c01,
>  SKEL_Spine1 = 0x60f0,
>  SKEL_Spine2 = 0x60f1,
>  SKEL_Spine3 = 0x60f2,
>  SKEL_L_Clavicle = 0xfcd9,
>  SKEL_L_UpperArm = 0xb1c5,
>  SKEL_L_Forearm = 0xeeeb,
>   SKEL_L_Hand = 0x49d9,
>  SKEL_L_Finger00 = 0x67f2,
>  SKEL_L_Finger01 = 0xff9,
>   SKEL_L_Finger02 = 0xffa,
>   SKEL_L_Finger10 = 0x67f3,
>  SKEL_L_Finger11 = 0x1049,
>  SKEL_L_Finger12 = 0x104a,
>  SKEL_L_Finger20 = 0x67f4,
>  SKEL_L_Finger21 = 0x1059,
>  SKEL_L_Finger22 = 0x105a,
>  SKEL_L_Finger30 = 0x67f5,
>  SKEL_L_Finger31 = 0x1029,
>  SKEL_L_Finger32 = 0x102a,
>  SKEL_L_Finger40 = 0x67f6,
>  SKEL_L_Finger41 = 0x1039,
>  SKEL_L_Finger42 = 0x103a,
>  PH_L_Hand = 0xeb95,
>    IK_L_Hand = 0x8cbd,
>    RB_L_ForeArmRoll = 0xee4f,
>     RB_L_ArmRoll = 0x1470,
>     MH_L_Elbow = 0x58b7,
>   SKEL_R_Clavicle = 0x29d2,
>  SKEL_R_UpperArm = 0x9d4d,
>  SKEL_R_Forearm = 0x6e5c,
>   SKEL_R_Hand = 0xdead,
>  SKEL_R_Finger00 = 0xe5f2,
>  SKEL_R_Finger01 = 0xfa10,
>  SKEL_R_Finger02 = 0xfa11,
>  SKEL_R_Finger10 = 0xe5f3,
>  SKEL_R_Finger11 = 0xfa60,
>  SKEL_R_Finger12 = 0xfa61,
>  SKEL_R_Finger20 = 0xe5f4,
>  SKEL_R_Finger21 = 0xfa70,
>  SKEL_R_Finger22 = 0xfa71,
>  SKEL_R_Finger30 = 0xe5f5,
>  SKEL_R_Finger31 = 0xfa40,
>  SKEL_R_Finger32 = 0xfa41,
>  SKEL_R_Finger40 = 0xe5f6,
>  SKEL_R_Finger41 = 0xfa50,
>  SKEL_R_Finger42 = 0xfa51,
>  PH_R_Hand = 0x6f06,
>    IK_R_Hand = 0x188e,
>    RB_R_ForeArmRoll = 0xab22,
>     RB_R_ArmRoll = 0x90ff,
>     MH_R_Elbow = 0xbb0,
>    SKEL_Neck_1 = 0x9995,
>  SKEL_Head = 0x796e,
>    IK_Head = 0x322c,
>  FACIAL_facialRoot = 0xfe2c,
>    FB_L_Brow_Out_000 = 0xe3db,
>    FB_L_Lid_Upper_000 = 0xb2b6,
>   FB_L_Eye_000 = 0x62ac,
>     FB_L_CheekBone_000 = 0x542e,
>   FB_L_Lip_Corner_000 = 0x74ac,
>  FB_R_Lid_Upper_000 = 0xaa10,
>   FB_R_Eye_000 = 0x6b52,
>     FB_R_CheekBone_000 = 0x4b88,
>   FB_R_Brow_Out_000 = 0x54c,
>     FB_R_Lip_Corner_000 = 0x2ba6,
>  FB_Brow_Centre_000 = 0x9149,
>   FB_UpperLipRoot_000 = 0x4ed2,
>  FB_UpperLip_000 = 0xf18f,
>  FB_L_Lip_Top_000 = 0x4f37,
>     FB_R_Lip_Top_000 = 0x4537,
>     FB_Jaw_000 = 0xb4a0,
>   FB_LowerLipRoot_000 = 0x4324,
>  FB_LowerLip_000 = 0x508f,
>  FB_L_Lip_Bot_000 = 0xb93b,
>     FB_R_Lip_Bot_000 = 0xc33b,
>     FB_Tongue_000 = 0xb987,
>    RB_Neck_1 = 0x8b93,
>    IK_Root = 0xdd1c

## GET_PED_CAUSE_OF_DEATH

```c
Hash GET_PED_CAUSE_OF_DEATH(Ped ped)  // 0x16FFE42AB2D2DC59
```

build 323

> Returns the hash of the weapon/model/object that killed the ped.

## GET_PED_COMBAT_MOVEMENT

```c
int GET_PED_COMBAT_MOVEMENT(Ped ped)  // 0xDEA92412FCAEB3F5
```

build 323

> See SET_PED_COMBAT_MOVEMENT

## GET_PED_COMBAT_RANGE

```c
int GET_PED_COMBAT_RANGE(Ped ped)  // 0xF9D9F7F2DB8E2FA0
```

build 323

> See SET_PED_COMBAT_RANGE

## GET_PED_CONFIG_FLAG

```c
BOOL GET_PED_CONFIG_FLAG(Ped ped, int flagId, BOOL p2)  // 0x7EE53118C892B513
```

build 323

> See SET_PED_CONFIG_FLAG

## GET_PED_CURRENT_MOVE_BLEND_RATIO

```c
BOOL GET_PED_CURRENT_MOVE_BLEND_RATIO(Ped ped, float* speedX, float* speedY)  // 0xF60165E1D2C5370B
```

build 323 · old names: `_GET_PED_CURRENT_MOVEMENT_SPEED`

## GET_PED_DECORATION_ZONE_FROM_HASHES

```c
int GET_PED_DECORATION_ZONE_FROM_HASHES(Hash collection, Hash overlay)  // 0x9FD452BFBE7A7A8B
```

build 323 · old names: `_GET_TATTOO_ZONE`

> Returns the zoneID for the overlay if it is a member of collection.
> enum ePedDecorationZone
> {
> 	ZONE_TORSO = 0,
> 	ZONE_HEAD = 1,
> 	ZONE_LEFT_ARM = 2,
> 	ZONE_RIGHT_ARM = 3,
> 	ZONE_LEFT_LEG = 4,
> 	ZONE_RIGHT_LEG = 5,
> 	ZONE_MEDALS = 6,
> 	ZONE_INVALID = 7
> };
> 
> Full list of ped overlays / decorations by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedOverlayCollections.json

## GET_PED_DECORATIONS_STATE

```c
int GET_PED_DECORATIONS_STATE(Ped ped)  // 0x71EAB450D86954A1
```

build 323

## GET_PED_DEFENSIVE_AREA_POSITION

```c
Vector3 GET_PED_DEFENSIVE_AREA_POSITION(Ped ped, BOOL p1)  // 0x3C06B8786DD94CD1
```

build 323

## GET_PED_DIES_IN_WATER

```c
BOOL GET_PED_DIES_IN_WATER(Ped ped)  // 0x65671A4FB8218930
```

build 2699 · old names: `_GET_PED_DIES_IN_WATER`

## GET_PED_DRAWABLE_VARIATION

```c
int GET_PED_DRAWABLE_VARIATION(Ped ped, int componentId)  // 0x67F3780DD425D4FC
```

build 323

> Ids
> 0 - Head
> 1 - Beard
> 2 - Hair
> 3 - Torso
> 4 - Legs
> 5 - Hands
> 6 - Foot
> 7 - ------
> 8 - Accessories 1
> 9 - Accessories 2
> 10- Decals
> 11 - Auxiliary parts for torso

## GET_PED_EMISSIVE_SCALE

```c
float GET_PED_EMISSIVE_SCALE(Ped ped)  // 0x1461B28A06717D68
```

build 944 · old names: `_GET_PED_REFLECTION_INTENSITY`, `_GET_PED_ILLUMINATED_CLOTHING_GLOW_INTENSITY`, `_GET_PED_EMISSIVE_INTENSITY`

> Use SET_PED_EMISSIVE_SCALE to set the illuminated clothing glow intensity for a specific ped.
> Returns a float between 0.0 and 1.0 representing the current illuminated clothing glow intensity.

## GET_PED_ENVEFF_SCALE

```c
float GET_PED_ENVEFF_SCALE(Ped ped)  // 0x9C14D30395A51A3C
```

build 323

## GET_PED_EXTRACTED_DISPLACEMENT

```c
Vector3 GET_PED_EXTRACTED_DISPLACEMENT(Ped ped, BOOL worldSpace)  // 0xE0AF41401ADF87E3
```

build 323

> Gets the offset the specified ped has moved since the previous tick.
> 
> If worldSpace is false, the returned offset is relative to the ped. That is, if the ped has moved 1 meter right and 5 meters forward, it'll return 1,5,0.
> 
> If worldSpace is true, the returned offset is relative to the world. That is, if the ped has moved 1 meter on the X axis and 5 meters on the Y axis, it'll return 1,5,0.

## GET_PED_GROUP_INDEX

```c
int GET_PED_GROUP_INDEX(Ped ped)  // 0xF162E133B4E7A675
```

build 323

> Returns the group id of which the specified ped is a member of.

## GET_PED_HAIR_TINT_COLOR

```c
void GET_PED_HAIR_TINT_COLOR(int hairColorIndex, int* outR, int* outG, int* outB)  // 0x4852FC386E2E1BB5
```

build 323 · old names: `_GET_HAIR_RGB_COLOR`, `_GET_PED_HAIR_RGB_COLOR`

> Input: Haircolor index, value between 0 and 63 (inclusive).
> Output: RGB values for the haircolor specified in the input.
> 
> This is used with the hair color swatches scaleform.
> Use `GET_PED_MAKEUP_TINT_COLOR` to get the makeup colors.

## GET_PED_HEAD_BLEND_DATA

```c
BOOL GET_PED_HEAD_BLEND_DATA(Ped ped, Any* headBlendData)  // 0x2746BD9D88C5C5D0
```

build 323 · old names: `_GET_PED_HEAD_BLEND_DATA`

> The pointer is to a padded struct that matches the arguments to SET_PED_HEAD_BLEND_DATA(...). There are 4 bytes of padding after each field.
> pass this struct in the second parameter 
> struct headBlendData
> {
>     int shapeFirst;
>     int padding1;
>     int shapeSecond;
>     int padding2;
>     int shapeThird;
>     int padding3;
>     int skinFirst;
>     int padding4;
>     int skinSecond;
>     int padding5;
>     int skinThird;
>     int padding6;
>     float shapeMix;
>     int padding7;
>     float skinMix;
>     int padding8;
>     float thirdMix;
>     int padding9;
>     bool isParent;
> };

## GET_PED_HEAD_BLEND_FIRST_INDEX

```c
int GET_PED_HEAD_BLEND_FIRST_INDEX(int type)  // 0x68D353AB88B97E0C
```

build 323 · old names: `_GET_FIRST_PARENT_ID_FOR_PED_TYPE`

> Type equals 0 for male non-dlc, 1 for female non-dlc, 2 for male dlc, and 3 for female dlc.
> 
> Used when calling SET_PED_HEAD_BLEND_DATA.

## GET_PED_HEAD_BLEND_NUM_HEADS

```c
int GET_PED_HEAD_BLEND_NUM_HEADS(int type)  // 0x5EF37013A6539C9D
```

build 323 · old names: `_GET_NUM_PARENT_PEDS_OF_TYPE`

> Type equals 0 for male non-dlc, 1 for female non-dlc, 2 for male dlc, and 3 for female dlc.

## GET_PED_HEAD_OVERLAY

```c
int GET_PED_HEAD_OVERLAY(Ped ped, int overlayID)  // 0xA60EF3B6461A4D43
```

build 323 · old names: `_GET_PED_HEAD_OVERLAY_VALUE`

> Likely a char, if that overlay is not set, e.i. "None" option, returns 255;
> 
> This might be the once removed native GET_PED_HEAD_OVERLAY.

## GET_PED_HEAD_OVERLAY_NUM

```c
int GET_PED_HEAD_OVERLAY_NUM(int overlayID)  // 0xCF1CE768BB43480E
```

build 323 · old names: `_GET_NUM_HEAD_OVERLAY_VALUES`

## GET_PED_HELMET_STORED_HAT_PROP_INDEX

```c
int GET_PED_HELMET_STORED_HAT_PROP_INDEX(Ped ped)  // 0x451294E859ECC018
```

build 323

## GET_PED_HELMET_STORED_HAT_TEX_INDEX

```c
int GET_PED_HELMET_STORED_HAT_TEX_INDEX(Ped ped)  // 0x9D728C1E12BF5518
```

build 323

## GET_PED_LAST_DAMAGE_BONE

```c
BOOL GET_PED_LAST_DAMAGE_BONE(Ped ped, int* outBone)  // 0xD75960F6BD9EA49C
```

build 323

## GET_PED_MAKEUP_TINT_COLOR

```c
void GET_PED_MAKEUP_TINT_COLOR(int makeupColorIndex, int* outR, int* outG, int* outB)  // 0x013E5CFC38CD5387
```

build 323 · old names: `_GET_MAKEUP_RGB_COLOR`, `_GET_PED_MAKEUP_RGB_COLOR`

> Input: Makeup color index, value between 0 and 63 (inclusive).
> Output: RGB values for the makeup color specified in the input.
> 
> This is used with the makeup color swatches scaleform.
> Use `GET_PED_HAIR_TINT_COLOR` to get the hair colors.

## GET_PED_MAX_HEALTH

```c
int GET_PED_MAX_HEALTH(Ped ped)  // 0x4700A416E8324EF3
```

build 323

## GET_PED_MONEY

```c
int GET_PED_MONEY(Ped ped)  // 0x3F69145BBA87BAE7
```

build 323

## GET_PED_NEARBY_PEDS

```c
int GET_PED_NEARBY_PEDS(Ped ped, Any* sizeAndPeds, int ignore)  // 0x23F8F5FC7E8C4A6B
```

build 323

> sizeAndPeds - is a pointer to an array. The array is filled with peds found nearby the ped supplied to the first argument.
> ignore - ped type to ignore
> 
> Return value is the number of peds found and added to the array passed.
> 
> -----------------------------------
> 
> To make this work in most menu bases at least in C++ do it like so,
> 
>  Formatted Example: https://pastebin.com/D8an9wwp
> 
> -----------------------------------
> 
> Example: https://gtaforums.com/topic/789788-function-args-to-pedget-ped-nearby-peds/?p=1067386687

## GET_PED_NEARBY_VEHICLES

```c
int GET_PED_NEARBY_VEHICLES(Ped ped, Any* sizeAndVehs)  // 0xCFF869CBFA210D82
```

build 323

> Returns size of array, passed into the second variable.
> 
> See below for usage information.
> 
> This function actually requires a struct, where the first value is the maximum number of elements to return.  Here is a sample of how I was able to get it to work correctly, without yet knowing the struct format.
> 
> //Setup the array
>  const int numElements = 10;
>    const int arrSize = numElements * 2 + 2;
>   Any veh[arrSize];
>  //0 index is the size of the array
>     veh[0] = numElements;
> 
>    int count = PED::GET_PED_NEARBY_VEHICLES(PLAYER::PLAYER_PED_ID(), veh);
> 
>  if (veh != NULL)
>   {
>      //Simple loop to go through results
>        for (int i = 0; i < count; i++)
>         {
>          int offsettedID = i * 2 + 2;
>           //Make sure it exists
>          if (veh[offsettedID] != NULL && ENTITY::DOES_ENTITY_EXIST(veh[offsettedID]))
>           {
>              //Do something
>             }
>      }
>  }  

## GET_PED_PALETTE_VARIATION

```c
int GET_PED_PALETTE_VARIATION(Ped ped, int componentId)  // 0xE3DD5F2A84B42281
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_PED_PARACHUTE_LANDING_TYPE

```c
int GET_PED_PARACHUTE_LANDING_TYPE(Ped ped)  // 0x8B9F1FC6AE8166C0
```

build 323

> -1: no landing
> 0: landing on both feet
> 1: stumbling
> 2: rolling
> 3: ragdoll

## GET_PED_PARACHUTE_STATE

```c
int GET_PED_PARACHUTE_STATE(Ped ped)  // 0x79CFD9827CC979B6
```

build 323

> Returns:
> 
> -1: Normal
> 0: Wearing parachute on back
> 1: Parachute opening
> 2: Parachute open
> 3: Falling to doom (e.g. after exiting parachute)
> 
> Normal means no parachute?

## GET_PED_PARACHUTE_TINT_INDEX

```c
void GET_PED_PARACHUTE_TINT_INDEX(Ped ped, int* outTintIndex)  // 0xEAF5F7E5AE7C6C9D
```

build 323

## GET_PED_PROP_INDEX

```c
int GET_PED_PROP_INDEX(Ped ped, int componentId, Any p2)  // 0x898CC20EA75BACD8
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_PED_PROP_TEXTURE_INDEX

```c
int GET_PED_PROP_TEXTURE_INDEX(Ped ped, int componentId)  // 0xE131A28626F81AB2
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_PED_RAGDOLL_BONE_INDEX

```c
int GET_PED_RAGDOLL_BONE_INDEX(Ped ped, int bone)  // 0x2057EF813397A772
```

build 323

## GET_PED_RELATIONSHIP_GROUP_DEFAULT_HASH

```c
Hash GET_PED_RELATIONSHIP_GROUP_DEFAULT_HASH(Ped ped)  // 0x42FDD0F017B1E38E
```

build 323

## GET_PED_RELATIONSHIP_GROUP_HASH

```c
Hash GET_PED_RELATIONSHIP_GROUP_HASH(Ped ped)  // 0x7DBDD04862D95F04
```

build 323

## GET_PED_RESET_FLAG

```c
BOOL GET_PED_RESET_FLAG(Ped ped, int flagId)  // 0xAF9E59B1B1FBF2A0
```

build 323

> See SET_PED_RESET_FLAG

## GET_PED_SOURCE_OF_DEATH

```c
Entity GET_PED_SOURCE_OF_DEATH(Ped ped)  // 0x93C8B64DEB84728C
```

build 323 · old names: `_GET_PED_KILLER`

> Returns the Entity (Ped, Vehicle, or ?Object?) that killed the 'ped'
> 
> Is best to check if the Ped is dead before asking for its killer.

## GET_PED_STEALTH_MOVEMENT

```c
BOOL GET_PED_STEALTH_MOVEMENT(Ped ped)  // 0x7C2AC9CA66575FBF
```

build 323

> Returns whether the entity is in stealth mode

## GET_PED_TARGET_FROM_COMBAT_PED

```c
Entity GET_PED_TARGET_FROM_COMBAT_PED(Ped ped, Any p1)  // 0x32C27A11307B01CC
```

build 2372 · old names: `_GET_PED_TASK_COMBAT_TARGET`

## GET_PED_TEXTURE_VARIATION

```c
int GET_PED_TEXTURE_VARIATION(Ped ped, int componentId)  // 0x04A355E041E004E6
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## GET_PED_TIME_OF_DEATH

```c
int GET_PED_TIME_OF_DEATH(Ped ped)  // 0x1E98817B311AE98A
```

build 323 · old names: `_GET_PED_TIME_OF_DEATH`

## GET_PED_TYPE

```c
int GET_PED_TYPE(Ped ped)  // 0xFF059E1E4C01E63C
```

build 323

> https://alloc8or.re/gta5/doc/enums/ePedType.txt

## GET_PED_VISUAL_FIELD_CENTER_ANGLE

```c
float GET_PED_VISUAL_FIELD_CENTER_ANGLE(Ped ped)  // 0xEF2C71A32CAD5FBD
```

build 1493 · old names: `_GET_PED_VISUAL_FIELD_CENTER_ANGLE`

## GET_PEDHEADSHOT_TXD_STRING

```c
const char* GET_PEDHEADSHOT_TXD_STRING(int id)  // 0xDB4EACD4AD0A5D6B
```

build 323

> https://gtaforums.com/topic/885580-ped-headshotmugshot-txd/

## GET_PEDS_JACKER

```c
Ped GET_PEDS_JACKER(Ped ped)  // 0x9B128DC36C1E04CF
```

build 323

## GET_PLAYER_PED_IS_FOLLOWING

```c
Player GET_PLAYER_PED_IS_FOLLOWING(Ped ped)  // 0x6A3975DEA89F9A17
```

build 323

## GET_POS_FROM_FIRED_EVENT

```c
BOOL GET_POS_FROM_FIRED_EVENT(Ped ped, int eventType, Any* outData)  // 0xBA656A3BB01BDEA3
```

build 2189 · old names: `_GET_PED_EVENT_DATA`

## GET_RANDOM_PED_AT_COORD

```c
Ped GET_RANDOM_PED_AT_COORD(float x, float y, float z, float xRadius, float yRadius, float zRadius, int pedType)  // 0x876046A8E3A4B71C
```

build 323

> Gets a random ped in the x/y/zRadius near the x/y/z coordinates passed. 
> 
> Ped Types:
> Any = -1
> Player = 1
> Male = 4 
> Female = 5 
> Cop = 6
> Human = 26
> SWAT = 27 
> Animal = 28
> Army = 29

## GET_RELATIONSHIP_BETWEEN_GROUPS

```c
int GET_RELATIONSHIP_BETWEEN_GROUPS(Hash group1, Hash group2)  // 0x9E6B70061662AE5C
```

build 323

> Gets the relationship between two groups. This should be called twice (once for each group).
> 
> Relationship types:
> 0 = Companion
> 1 = Respect
> 2 = Like
> 3 = Neutral
> 4 = Dislike
> 5 = Hate
> 255 = Pedestrians
> 
> Example:
> PED::GET_RELATIONSHIP_BETWEEN_GROUPS(l_1017, 0xA49E591C);
> PED::GET_RELATIONSHIP_BETWEEN_GROUPS(0xA49E591C, l_1017);

## GET_RELATIONSHIP_BETWEEN_PEDS

```c
int GET_RELATIONSHIP_BETWEEN_PEDS(Ped ped1, Ped ped2)  // 0xEBA5AD3A0EAF7121
```

build 323

> Gets the relationship between two peds. This should be called twice (once for each ped).
> 
> Relationship types:
> 0 = Companion
> 1 = Respect
> 2 = Like
> 3 = Neutral
> 4 = Dislike
> 5 = Hate
> 255 = Pedestrians
> (Credits: Inco)
> 
> Example:
> PED::GET_RELATIONSHIP_BETWEEN_PEDS(2, l_1017, 0xA49E591C);
> PED::GET_RELATIONSHIP_BETWEEN_PEDS(2, 0xA49E591C, l_1017);

## GET_SEAT_PED_IS_TRYING_TO_ENTER

```c
int GET_SEAT_PED_IS_TRYING_TO_ENTER(Ped ped)  // 0x6F4C85ACD641BCD2
```

build 323

## GET_SYNCHRONIZED_SCENE_PHASE

```c
float GET_SYNCHRONIZED_SCENE_PHASE(int sceneID)  // 0xE4A310B1D7FA73CC
```

build 323

## GET_SYNCHRONIZED_SCENE_RATE

```c
float GET_SYNCHRONIZED_SCENE_RATE(int sceneID)  // 0xD80932D577274D40
```

build 323

## GET_TIME_PED_DAMAGED_BY_WEAPON

```c
int GET_TIME_PED_DAMAGED_BY_WEAPON(Ped ped, Hash weaponHash)  // 0x36B77BB84687C318
```

build 323 · old names: `_GET_TIME_OF_LAST_PED_WEAPON_DAMAGE`

## GET_TINT_INDEX_FOR_LAST_GEN_HAIR_TEXTURE

```c
int GET_TINT_INDEX_FOR_LAST_GEN_HAIR_TEXTURE(Hash modelHash, int drawableId, int textureId)  // 0xC56FBF2F228E1DAC
```

build 323 · old names: `_GET_TINT_OF_HAIR_COMPONENT_VARIATION`

## GET_TRACKED_PED_PIXELCOUNT

```c
int GET_TRACKED_PED_PIXELCOUNT(Ped ped)  // 0x511F1A683387C7E2
```

build 323 · old names: `_GET_TRACKED_PED_VISIBILITY`

## GET_VEHICLE_PED_IS_ENTERING

```c
Vehicle GET_VEHICLE_PED_IS_ENTERING(Ped ped)  // 0xF92691AED837A5FC
```

build 323 · old names: `SET_EXCLUSIVE_PHONE_RELATIONSHIPS`

## GET_VEHICLE_PED_IS_IN

```c
Vehicle GET_VEHICLE_PED_IS_IN(Ped ped, BOOL includeEntering)  // 0x9A9112A0FE9A4713
```

build 323

> Gets the vehicle the specified Ped is in. Returns 0 if the ped is/was not in a vehicle.

## GET_VEHICLE_PED_IS_TRYING_TO_ENTER

```c
Vehicle GET_VEHICLE_PED_IS_TRYING_TO_ENTER(Ped ped)  // 0x814FA8BE5449445D
```

build 323

## GET_VEHICLE_PED_IS_USING

```c
Vehicle GET_VEHICLE_PED_IS_USING(Ped ped)  // 0x6094AD011A2EA87D
```

build 323

> Gets ID of vehicle player using. It means it can get ID at any interaction with vehicle. Enter\exit for example. And that means it is faster than GET_VEHICLE_PED_IS_IN but less safe.

## GIVE_PED_HELMET

```c
void GIVE_PED_HELMET(Ped ped, BOOL cannotRemove, int helmetFlag, int textureIndex)  // 0x54C7C4A94367717E
```

build 323

> PoliceMotorcycleHelmet   1024    
> RegularMotorcycleHelmet   4096    
> FiremanHelmet 16384   
> PilotHeadset  32768   
> PilotHelmet   65536
> --
> p2 is generally 4096 or 16384 in the scripts. p1 varies between 1 and 0.

## GIVE_PED_NM_MESSAGE

```c
void GIVE_PED_NM_MESSAGE(Ped ped)  // 0xB158DFCCC56E5C5B
```

build 323

> Sends the message that was created by a call to CREATE_NM_MESSAGE to the specified Ped.
> 
> If a message hasn't been created already, this function does nothing.
> If the Ped is not ragdolled with Euphoria enabled, this function does nothing.
> The following call can be used to ragdoll the Ped with Euphoria enabled: SET_PED_TO_RAGDOLL(ped, 4000, 5000, 1, 1, 1, 0);
> 
> Call order:
> SET_PED_TO_RAGDOLL
> CREATE_NM_MESSAGE
> GIVE_PED_NM_MESSAGE
> 
> Multiple messages can be chained. Eg. to make the ped stagger and swing his arms around, the following calls can be made:
> SET_PED_TO_RAGDOLL(ped, 4000, 5000, 1, 1, 1, 0);
> CREATE_NM_MESSAGE(true, 0); // stopAllBehaviours - Stop all other behaviours, in case the Ped is already doing some Euphoria stuff.
> GIVE_PED_NM_MESSAGE(ped); // Dispatch message to Ped.
> CREATE_NM_MESSAGE(true, 1151); // staggerFall - Attempt to walk while falling.
> GIVE_PED_NM_MESSAGE(ped); // Dispatch message to Ped.
> CREATE_NM_MESSAGE(true, 372); // armsWindmill - Swing arms around.
> GIVE_PED_NM_MESSAGE(ped); // Dispatch message to Ped.

## HAS_ACTION_MODE_ASSET_LOADED

```c
BOOL HAS_ACTION_MODE_ASSET_LOADED(const char* asset)  // 0xE4B5F4BF2CB24E65
```

build 323

## HAS_PED_HEAD_BLEND_FINISHED

```c
BOOL HAS_PED_HEAD_BLEND_FINISHED(Ped ped)  // 0x654CD0A825161131
```

build 323

## HAS_PED_PRELOAD_PROP_DATA_FINISHED

```c
BOOL HAS_PED_PRELOAD_PROP_DATA_FINISHED(Ped ped)  // 0x784002A632822099
```

build 323

## HAS_PED_PRELOAD_VARIATION_DATA_FINISHED

```c
BOOL HAS_PED_PRELOAD_VARIATION_DATA_FINISHED(Ped ped)  // 0x66680A92700F43DF
```

build 323

## HAS_PED_RECEIVED_EVENT

```c
BOOL HAS_PED_RECEIVED_EVENT(Ped ped, int eventId)  // 0x8507BCB710FA6DC0
```

build 323

## HAS_PEDHEADSHOT_IMG_UPLOAD_FAILED

```c
BOOL HAS_PEDHEADSHOT_IMG_UPLOAD_FAILED()  // 0x876928DDDFCCC9CD
```

build 323

## HAS_PEDHEADSHOT_IMG_UPLOAD_SUCCEEDED

```c
BOOL HAS_PEDHEADSHOT_IMG_UPLOAD_SUCCEEDED()  // 0xE8A169E666CBC541
```

build 323

## HAS_STEALTH_MODE_ASSET_LOADED

```c
BOOL HAS_STEALTH_MODE_ASSET_LOADED(const char* asset)  // 0xE977FC5B08AF3441
```

build 323

## HAVE_ALL_STREAMING_REQUESTS_COMPLETED

```c
BOOL HAVE_ALL_STREAMING_REQUESTS_COMPLETED(Ped ped)  // 0x7350823473013C02
```

build 323 · old names: `_HAS_STREAMED_PED_ASSETS_LOADED`

## HIDE_PED_BLOOD_DAMAGE_BY_ZONE

```c
void HIDE_PED_BLOOD_DAMAGE_BY_ZONE(Ped ped, Any p1, BOOL p2)  // 0x62AB793144DE75DC
```

build 323

## INSTANTLY_FILL_PED_POPULATION

```c
void INSTANTLY_FILL_PED_POPULATION()  // 0x4759CC730F947C81
```

build 323

## IS_ANY_HOSTILE_PED_NEAR_POINT

```c
BOOL IS_ANY_HOSTILE_PED_NEAR_POINT(Ped ped, float x, float y, float z, float radius)  // 0x68772DB2B2526F9F
```

build 323

## IS_ANY_PED_NEAR_POINT

```c
BOOL IS_ANY_PED_NEAR_POINT(float x, float y, float z, float radius)  // 0x083961498679DC9F
```

build 323

## IS_ANY_PED_SHOOTING_IN_AREA

```c
BOOL IS_ANY_PED_SHOOTING_IN_AREA(float x1, float y1, float z1, float x2, float y2, float z2, BOOL p6, BOOL p7)  // 0xA0D3D71EA1086C55
```

build 323

## IS_CONVERSATION_PED_DEAD

```c
BOOL IS_CONVERSATION_PED_DEAD(Ped ped)  // 0xE0A0AEC214B1FABA
```

build 323

## IS_COP_PED_IN_AREA_3D

```c
BOOL IS_COP_PED_IN_AREA_3D(float x1, float y1, float z1, float x2, float y2, float z2)  // 0x16EC4839969F9F5E
```

build 323

> xyz - relative to the world origin.

## IS_CURRENT_HEAD_PROP_A_HELMET

```c
BOOL IS_CURRENT_HEAD_PROP_A_HELMET(Any p0)  // 0xF2385935BFFD4D92
```

build 323

## IS_MOBILE_PHONE_TO_PED_EAR

```c
BOOL IS_MOBILE_PHONE_TO_PED_EAR(Ped ped)  // 0xA3F3564A5B3646C0
```

build 323

## IS_PED_A_PLAYER

```c
BOOL IS_PED_A_PLAYER(Ped ped)  // 0x12534C348C6CB68B
```

build 323

> Returns true if the given ped has a valid pointer to CPlayerInfo in its CPed class. That's all.

## IS_PED_AIMING_FROM_COVER

```c
BOOL IS_PED_AIMING_FROM_COVER(Ped ped)  // 0x3998B1276A3300E5
```

build 323

## IS_PED_BEING_JACKED

```c
BOOL IS_PED_BEING_JACKED(Ped ped)  // 0x9A497FE2DF198913
```

build 323

## IS_PED_BEING_STEALTH_KILLED

```c
BOOL IS_PED_BEING_STEALTH_KILLED(Ped ped)  // 0x863B23EFDE9C5DF2
```

build 323

## IS_PED_BEING_STUNNED

```c
BOOL IS_PED_BEING_STUNNED(Ped ped, int p1)  // 0x4FBACCE3B4138EE8
```

build 323

> p1 is always 0

## IS_PED_BLUSH_FACEPAINT_TINT_FOR_BARBER

```c
BOOL IS_PED_BLUSH_FACEPAINT_TINT_FOR_BARBER(int colorId)  // 0x09E7ECA981D9B210
```

build 1290 · old names: `_IS_PED_BODY_BLEMISH_VALID`, `_IS_PED_BLUSH_FACEPAINT_VALID_BARBER_COLOR`

## IS_PED_BLUSH_TINT_FOR_BARBER

```c
BOOL IS_PED_BLUSH_TINT_FOR_BARBER(int colorID)  // 0x604E810189EE3A59
```

build 323 · old names: `_IS_PED_BLUSH_COLOR_VALID`, `_IS_PED_BLUSH_VALID_BARBER_COLOR`

## IS_PED_BLUSH_TINT_FOR_CREATOR

```c
BOOL IS_PED_BLUSH_TINT_FOR_CREATOR(int colorId)  // 0xF41B5D290C99A3D6
```

build 323 · old names: `_IS_PED_BLUSH_COLOR_VALID_2`, `_IS_PED_BLUSH_VALID_CREATOR_COLOR`

## IS_PED_CLIMBING

```c
BOOL IS_PED_CLIMBING(Ped ped)  // 0x53E8CB4F48BFE623
```

build 323

## IS_PED_COMPONENT_VARIATION_VALID

```c
BOOL IS_PED_COMPONENT_VARIATION_VALID(Ped ped, int componentId, int drawableId, int textureId)  // 0xE825F6B6CEA7671D
```

build 323

> Checks if the component variation is valid, this works great for randomizing components using loops.
> 
> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html
> 
> Full list of ped components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedComponentVariations.json

## IS_PED_DEAD_OR_DYING

```c
BOOL IS_PED_DEAD_OR_DYING(Ped ped, BOOL checkMeleeDeathFlags)  // 0x3317DEDB88C95038
```

build 323

## IS_PED_DEFENSIVE_AREA_ACTIVE

```c
BOOL IS_PED_DEFENSIVE_AREA_ACTIVE(Ped ped, BOOL p1)  // 0xBA63D9FE45412247
```

build 323

## IS_PED_DIVING

```c
BOOL IS_PED_DIVING(Ped ped)  // 0x5527B8246FEF9B11
```

build 323

## IS_PED_DOING_A_BEAST_JUMP

```c
BOOL IS_PED_DOING_A_BEAST_JUMP(Any p0)  // 0x451D05012CCEC234
```

build 573

## IS_PED_DOING_DRIVEBY

```c
BOOL IS_PED_DOING_DRIVEBY(Ped ped)  // 0xB2C086CC1BF8F2BF
```

build 323

## IS_PED_DUCKING

```c
BOOL IS_PED_DUCKING(Ped ped)  // 0xD125AE748725C6BC
```

build 323

## IS_PED_EVASIVE_DIVING

```c
BOOL IS_PED_EVASIVE_DIVING(Ped ped, Entity* evadingEntity)  // 0x414641C26E105898
```

build 323

> Presumably returns the Entity that the Ped is currently diving out of the way of.
> 
> var num3;
>     if (PED::IS_PED_EVASIVE_DIVING(A_0, &num3) != 0)
>         if (ENTITY::IS_ENTITY_A_VEHICLE(num3) != 0)

## IS_PED_FACING_PED

```c
BOOL IS_PED_FACING_PED(Ped ped, Ped otherPed, float angle)  // 0xD71649DB0A545AA3
```

build 323

> angle is ped's view cone

## IS_PED_FALLING

```c
BOOL IS_PED_FALLING(Ped ped)  // 0xFB92A102F1C4DFA3
```

build 323

## IS_PED_FATALLY_INJURED

```c
BOOL IS_PED_FATALLY_INJURED(Ped ped)  // 0xD839450756ED5A80
```

build 323

> Gets a value indicating whether this ped's health is below its fatally injured threshold. The default threshold is 100.
> If the handle is invalid, the function returns true.

## IS_PED_FLEEING

```c
BOOL IS_PED_FLEEING(Ped ped)  // 0xBBCCE00B381F8482
```

build 323

## IS_PED_GESTURING

```c
BOOL IS_PED_GESTURING(Any p0)  // 0xC30BDAEE47256C13
```

build 1868

## IS_PED_GETTING_INTO_A_VEHICLE

```c
BOOL IS_PED_GETTING_INTO_A_VEHICLE(Ped ped)  // 0xBB062B2B5722478E
```

build 323

## IS_PED_GOING_INTO_COVER

```c
BOOL IS_PED_GOING_INTO_COVER(Ped ped)  // 0x9F65DBC537E59AD5
```

build 323

## IS_PED_GROUP_MEMBER

```c
BOOL IS_PED_GROUP_MEMBER(Ped ped, int groupId)  // 0x9BB01E3834671191
```

build 323

## IS_PED_HAIR_TINT_FOR_BARBER

```c
BOOL IS_PED_HAIR_TINT_FOR_BARBER(int colorID)  // 0xE0D36E5D9E99CC21
```

build 323 · old names: `_IS_PED_HAIR_COLOR_VALID`, `_IS_PED_HAIR_VALID_BARBER_COLOR`

## IS_PED_HAIR_TINT_FOR_CREATOR

```c
BOOL IS_PED_HAIR_TINT_FOR_CREATOR(int colorId)  // 0xED6D8E27A43B8CDE
```

build 323 · old names: `_IS_PED_HAIR_COLOR_VALID_2`, `_IS_PED_HAIR_VALID_CREATOR_COLOR`

## IS_PED_HANGING_ON_TO_VEHICLE

```c
BOOL IS_PED_HANGING_ON_TO_VEHICLE(Ped ped)  // 0x1C86D8AEF8254B78
```

build 323

## IS_PED_HEADING_TOWARDS_POSITION

```c
BOOL IS_PED_HEADING_TOWARDS_POSITION(Ped ped, float x, float y, float z, float p4)  // 0xFCF37A457CB96DC0
```

build 323

## IS_PED_HEADTRACKING_ENTITY

```c
BOOL IS_PED_HEADTRACKING_ENTITY(Ped ped, Entity entity)  // 0x813A0A7C9D2E831F
```

build 323

## IS_PED_HEADTRACKING_PED

```c
BOOL IS_PED_HEADTRACKING_PED(Ped ped1, Ped ped2)  // 0x5CD3CB88A7F8850D
```

build 323

## IS_PED_HELMET_VISOR_UP

```c
BOOL IS_PED_HELMET_VISOR_UP(Ped ped)  // 0xB9496CE47546DB2C
```

build 791 · old names: `_IS_PED_HELMET_UNK`

## IS_PED_HUMAN

```c
BOOL IS_PED_HUMAN(Ped ped)  // 0xB980061DA992779D
```

build 323

> Returns true/false if the ped is/isn't humanoid.

## IS_PED_HURT

```c
BOOL IS_PED_HURT(Ped ped)  // 0x5983BB449D7FDB12
```

build 323

> Returns whether the specified ped is hurt.

## IS_PED_IN_ANY_BOAT

```c
BOOL IS_PED_IN_ANY_BOAT(Ped ped)  // 0x2E0E1C2B4F6CB339
```

build 323

## IS_PED_IN_ANY_HELI

```c
BOOL IS_PED_IN_ANY_HELI(Ped ped)  // 0x298B91AE825E5705
```

build 323

## IS_PED_IN_ANY_PLANE

```c
BOOL IS_PED_IN_ANY_PLANE(Ped ped)  // 0x5FFF4CFC74D8FB80
```

build 323

## IS_PED_IN_ANY_POLICE_VEHICLE

```c
BOOL IS_PED_IN_ANY_POLICE_VEHICLE(Ped ped)  // 0x0BD04E29640C9C12
```

build 323

## IS_PED_IN_ANY_SUB

```c
BOOL IS_PED_IN_ANY_SUB(Ped ped)  // 0xFBFC01CCFB35D99E
```

build 323

## IS_PED_IN_ANY_TAXI

```c
BOOL IS_PED_IN_ANY_TAXI(Ped ped)  // 0x6E575D6A898AB852
```

build 323

## IS_PED_IN_ANY_TRAIN

```c
BOOL IS_PED_IN_ANY_TRAIN(Ped ped)  // 0x6F972C1AB75A1ED0
```

build 323

## IS_PED_IN_ANY_VEHICLE

```c
BOOL IS_PED_IN_ANY_VEHICLE(Ped ped, BOOL atGetIn)  // 0x997ABD671D25CA0B
```

build 323

> Gets a value indicating whether the specified ped is in any vehicle.
> 
> If 'atGetIn' is false, the function will not return true until the ped is sitting in the vehicle and is about to close the door. If it's true, the function returns true the moment the ped starts to get onto the seat (after opening the door). Eg. if false, and the ped is getting into a submersible, the function will not return true until the ped has descended down into the submersible and gotten into the seat, while if it's true, it'll return true the moment the hatch has been opened and the ped is about to descend into the submersible.

## IS_PED_IN_COMBAT

```c
BOOL IS_PED_IN_COMBAT(Ped ped, Ped target)  // 0x4859F1FC66A6278E
```

build 323

> Checks to see if ped and target are in combat with eachother. Only goes one-way: if target is engaged in combat with ped but ped has not yet reacted, the function will return false until ped starts fighting back.
> 
> p1 is usually 0 in the scripts because it gets the ped id during the task sequence. For instance: PED::IS_PED_IN_COMBAT(l_42E[4/*14*/], PLAYER::PLAYER_PED_ID()) // armenian2.ct4: 43794

## IS_PED_IN_COVER

```c
BOOL IS_PED_IN_COVER(Ped ped, BOOL exceptUseWeapon)  // 0x60DFD0691A170B88
```

build 323

> p1 is nearly always 0 in the scripts. 

## IS_PED_IN_COVER_FACING_LEFT

```c
BOOL IS_PED_IN_COVER_FACING_LEFT(Ped ped)  // 0x845333B3150583AB
```

build 323

## IS_PED_IN_FLYING_VEHICLE

```c
BOOL IS_PED_IN_FLYING_VEHICLE(Ped ped)  // 0x9134873537FA419C
```

build 323

## IS_PED_IN_GROUP

```c
BOOL IS_PED_IN_GROUP(Ped ped)  // 0x5891CAC5D4ACFF74
```

build 323

## IS_PED_IN_HIGH_COVER

```c
BOOL IS_PED_IN_HIGH_COVER(Ped ped)  // 0x6A03BF943D767C93
```

build 323 · old names: `_IS_PED_STANDING_IN_COVER`

## IS_PED_IN_MELEE_COMBAT

```c
BOOL IS_PED_IN_MELEE_COMBAT(Ped ped)  // 0x4E209B2C1EAD5159
```

build 323

> Notes: The function only returns true while the ped is: 
> A.) Swinging a random melee attack (including pistol-whipping)
> 
> B.) Reacting to being hit by a melee attack (including pistol-whipping)
> 
> C.) Is locked-on to an enemy (arms up, strafing/skipping in the default fighting-stance, ready to dodge+counter). 
> 
> You don't have to be holding the melee-targetting button to be in this stance; you stay in it by default for a few seconds after swinging at someone. If you do a sprinting punch, it returns true for the duration of the punch animation and then returns false again, even if you've punched and made-angry many peds

## IS_PED_IN_MODEL

```c
BOOL IS_PED_IN_MODEL(Ped ped, Hash modelHash)  // 0x796D90EFB19AA332
```

build 323

## IS_PED_IN_PARACHUTE_FREE_FALL

```c
BOOL IS_PED_IN_PARACHUTE_FREE_FALL(Ped ped)  // 0x7DCE8BDA0F1C1200
```

build 323

## IS_PED_IN_VEHICLE

```c
BOOL IS_PED_IN_VEHICLE(Ped ped, Vehicle vehicle, BOOL atGetIn)  // 0xA3EE4A07279BB9DB
```

build 323

> Gets a value indicating whether the specified ped is in the specified vehicle.
> 
> If 'atGetIn' is false, the function will not return true until the ped is sitting in the vehicle and is about to close the door. If it's true, the function returns true the moment the ped starts to get onto the seat (after opening the door). Eg. if false, and the ped is getting into a submersible, the function will not return true until the ped has descended down into the submersible and gotten into the seat, while if it's true, it'll return true the moment the hatch has been opened and the ped is about to descend into the submersible.

## IS_PED_INJURED

```c
BOOL IS_PED_INJURED(Ped ped)  // 0x84A2DD9AC37C35C1
```

build 323

> Gets a value indicating whether this ped's health is below its injured threshold.
> 
> The default threshold is 100.

## IS_PED_JACKING

```c
BOOL IS_PED_JACKING(Ped ped)  // 0x4AE4FF911DFB61DA
```

build 323

## IS_PED_JUMPING

```c
BOOL IS_PED_JUMPING(Ped ped)  // 0xCEDABC5900A0BF97
```

build 323

## IS_PED_JUMPING_OUT_OF_VEHICLE

```c
BOOL IS_PED_JUMPING_OUT_OF_VEHICLE(Ped ped)  // 0x433DDFFE2044B636
```

build 323

## IS_PED_LANDING

```c
BOOL IS_PED_LANDING(Any p0)  // 0x412F1364FA066CFB
```

build 573

## IS_PED_LIPSTICK_TINT_FOR_BARBER

```c
BOOL IS_PED_LIPSTICK_TINT_FOR_BARBER(int colorID)  // 0x0525A2C2562F3CD4
```

build 323 · old names: `_IS_PED_LIPSTICK_COLOR_VALID`, `_IS_PED_LIPSTICK_VALID_BARBER_COLOR`

## IS_PED_LIPSTICK_TINT_FOR_CREATOR

```c
BOOL IS_PED_LIPSTICK_TINT_FOR_CREATOR(int colorId)  // 0x3E802F11FBE27674
```

build 323 · old names: `_IS_PED_LIPSTICK_COLOR_VALID_2`, `_IS_PED_LIPSTICK_VALID_CREATOR_COLOR`

## IS_PED_MALE

```c
BOOL IS_PED_MALE(Ped ped)  // 0x6D9F5FAA7488BA46
```

build 323

> Returns true/false if the ped is/isn't male.

## IS_PED_MODEL

```c
BOOL IS_PED_MODEL(Ped ped, Hash modelHash)  // 0xC9D55B1A358A5BF7
```

build 323

## IS_PED_ON_ANY_BIKE

```c
BOOL IS_PED_ON_ANY_BIKE(Ped ped)  // 0x94495889E22C6479
```

build 323

## IS_PED_ON_FOOT

```c
BOOL IS_PED_ON_FOOT(Ped ped)  // 0x01FEE67DB37F59B2
```

build 323

## IS_PED_ON_MOUNT

```c
BOOL IS_PED_ON_MOUNT(Ped ped)  // 0x460BC76A0E10655E
```

build 323

> Same function call as PED::GET_MOUNT, aka just returns 0

## IS_PED_ON_SPECIFIC_VEHICLE

```c
BOOL IS_PED_ON_SPECIFIC_VEHICLE(Ped ped, Vehicle vehicle)  // 0xEC5F66E459AF3BB2
```

build 323

## IS_PED_ON_VEHICLE

```c
BOOL IS_PED_ON_VEHICLE(Ped ped)  // 0x67722AEB798E5FAB
```

build 323

> Gets a value indicating whether the specified ped is on top of any vehicle.
> 
> Return 1 when ped is on vehicle.
> Return 0 when ped is not on a vehicle.
> 

## IS_PED_OPENING_DOOR

```c
BOOL IS_PED_OPENING_DOOR(Ped ped)  // 0x26AF0E8E30BD2A2C
```

build 323 · old names: `_IS_PED_OPENING_A_DOOR`

> Returns true if the ped is currently opening a door (CTaskOpenDoor).

## IS_PED_PERFORMING_A_COUNTER_ATTACK

```c
BOOL IS_PED_PERFORMING_A_COUNTER_ATTACK(Ped ped)  // 0xEBD0EDBA5BE957CF
```

build 323 · old names: `IS_PED_PERFORMING_DEPENDENT_COMBO_LIMIT`

## IS_PED_PERFORMING_MELEE_ACTION

```c
BOOL IS_PED_PERFORMING_MELEE_ACTION(Ped ped)  // 0xDCCA191DF9980FD7
```

build 323

## IS_PED_PERFORMING_STEALTH_KILL

```c
BOOL IS_PED_PERFORMING_STEALTH_KILL(Ped ped)  // 0xFD4CCDBCC59941B7
```

build 323

## IS_PED_PLANTING_BOMB

```c
BOOL IS_PED_PLANTING_BOMB(Ped ped)  // 0xC70B5FAE151982D8
```

build 323

## IS_PED_PRONE

```c
BOOL IS_PED_PRONE(Ped ped)  // 0xD6A86331A537A7B9
```

build 323

## IS_PED_RAGDOLL

```c
BOOL IS_PED_RAGDOLL(Ped ped)  // 0x47E4E977581C5B55
```

build 323

> If the ped handle passed through the parenthesis is in a ragdoll state this will return true.

## IS_PED_RELOADING

```c
BOOL IS_PED_RELOADING(Ped ped)  // 0x24B100C68C645951
```

build 323

> Returns whether the specified ped is reloading.

## IS_PED_RESPONDING_TO_EVENT

```c
BOOL IS_PED_RESPONDING_TO_EVENT(Ped ped, Any event)  // 0x625B774D75C87068
```

build 323

## IS_PED_RUNNING_MELEE_TASK

```c
BOOL IS_PED_RUNNING_MELEE_TASK(Ped ped)  // 0xD1871251F3B5ACD7
```

build 323

## IS_PED_RUNNING_MOBILE_PHONE_TASK

```c
BOOL IS_PED_RUNNING_MOBILE_PHONE_TASK(Ped ped)  // 0x2AFE52F782F25775
```

build 323

## IS_PED_RUNNING_RAGDOLL_TASK

```c
BOOL IS_PED_RUNNING_RAGDOLL_TASK(Ped ped)  // 0xE3B6097CC25AA69E
```

build 323

## IS_PED_SHADER_READY

```c
BOOL IS_PED_SHADER_READY(Ped ped)  // 0x81AA517FBBA05D39
```

build 944 · old names: `_IS_PED_SHADER_EFFECT_VALID`

## IS_PED_SHELTERED

```c
BOOL IS_PED_SHELTERED(Ped ped)  // 0xB8B52E498014F5B0
```

build 323

## IS_PED_SHOOTING

```c
BOOL IS_PED_SHOOTING(Ped ped)  // 0x34616828CD07F1A1
```

build 323

> Returns whether the specified ped is shooting.

## IS_PED_SHOOTING_IN_AREA

```c
BOOL IS_PED_SHOOTING_IN_AREA(Ped ped, float x1, float y1, float z1, float x2, float y2, float z2, BOOL p7, BOOL p8)  // 0x7E9DFE24AC1E58EF
```

build 323

## IS_PED_SITTING_IN_ANY_VEHICLE

```c
BOOL IS_PED_SITTING_IN_ANY_VEHICLE(Ped ped)  // 0x826AA586EDB9FEF8
```

build 323

> Detect if ped is in any vehicle
> [True/False]

## IS_PED_SITTING_IN_VEHICLE

```c
BOOL IS_PED_SITTING_IN_VEHICLE(Ped ped, Vehicle vehicle)  // 0xA808AA1D79230FC2
```

build 323

> Detect if ped is sitting in the specified vehicle
> [True/False]

## IS_PED_STOPPED

```c
BOOL IS_PED_STOPPED(Ped ped)  // 0x530944F6F4B8A214
```

build 323

> Returns true if the ped doesn't do any movement. If the ped is being pushed forwards by using APPLY_FORCE_TO_ENTITY for example, the function returns false.

## IS_PED_SWIMMING

```c
BOOL IS_PED_SWIMMING(Ped ped)  // 0x9DE327631295B4C2
```

build 323

## IS_PED_SWIMMING_UNDER_WATER

```c
BOOL IS_PED_SWIMMING_UNDER_WATER(Ped ped)  // 0xC024869A53992F34
```

build 323

## IS_PED_SWITCHING_WEAPON

```c
BOOL IS_PED_SWITCHING_WEAPON(Ped Ped)  // 0x3795688A307E1EB6
```

build 505 · old names: `_IS_PED_SWAPPING_WEAPON`

## IS_PED_TAKING_OFF_HELMET

```c
BOOL IS_PED_TAKING_OFF_HELMET(Ped ped)  // 0x14590DDBEDB1EC85
```

build 323

## IS_PED_TRACKED

```c
BOOL IS_PED_TRACKED(Ped ped)  // 0x4C5E1F087CD10BB7
```

build 323

## IS_PED_TRYING_TO_ENTER_A_LOCKED_VEHICLE

```c
BOOL IS_PED_TRYING_TO_ENTER_A_LOCKED_VEHICLE(Ped ped)  // 0x44D28D5DDFE5F68C
```

build 323

## IS_PED_USING_ACTION_MODE

```c
BOOL IS_PED_USING_ACTION_MODE(Ped ped)  // 0x00E73468D085F745
```

build 323

## IS_PED_USING_ANY_SCENARIO

```c
BOOL IS_PED_USING_ANY_SCENARIO(Ped ped)  // 0x57AB4A3080F85143
```

build 323

## IS_PED_USING_SCENARIO

```c
BOOL IS_PED_USING_SCENARIO(Ped ped, const char* scenario)  // 0x1BF094736DD62C2E
```

build 323

> Full list of ped scenarios by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/scenariosCompact.json

## IS_PED_VAULTING

```c
BOOL IS_PED_VAULTING(Ped ped)  // 0x117C70D1F5730B5E
```

build 323

## IS_PED_WEARING_HELMET

```c
BOOL IS_PED_WEARING_HELMET(Ped ped)  // 0xF33BDFE19B309B19
```

build 323

> Returns true if the ped passed through the parenthesis is wearing a helmet.

## IS_PEDHEADSHOT_IMG_UPLOAD_AVAILABLE

```c
BOOL IS_PEDHEADSHOT_IMG_UPLOAD_AVAILABLE()  // 0xEBB376779A760AA8
```

build 323

## IS_PEDHEADSHOT_READY

```c
BOOL IS_PEDHEADSHOT_READY(int id)  // 0x7085228842B13A67
```

build 323

> https://gtaforums.com/topic/885580-ped-headshotmugshot-txd/

## IS_PEDHEADSHOT_VALID

```c
BOOL IS_PEDHEADSHOT_VALID(int id)  // 0xA0A9668F158129A2
```

build 323

> https://gtaforums.com/topic/885580-ped-headshotmugshot-txd/

## IS_SCRIPTED_SCENARIO_PED_USING_CONDITIONAL_ANIM

```c
BOOL IS_SCRIPTED_SCENARIO_PED_USING_CONDITIONAL_ANIM(Ped ped, const char* animDict, const char* anim)  // 0x6EC47A344923E1ED
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## IS_SYNCHRONIZED_SCENE_HOLD_LAST_FRAME

```c
BOOL IS_SYNCHRONIZED_SCENE_HOLD_LAST_FRAME(int sceneID)  // 0x7F2F4F13AC5257EF
```

build 323

## IS_SYNCHRONIZED_SCENE_LOOPED

```c
BOOL IS_SYNCHRONIZED_SCENE_LOOPED(int sceneID)  // 0x62522002E0C391BA
```

build 323

## IS_SYNCHRONIZED_SCENE_RUNNING

```c
BOOL IS_SYNCHRONIZED_SCENE_RUNNING(int sceneId)  // 0x25D39B935A038A26
```

build 323

> Returns true if a synchronized scene is running

## IS_TARGET_PED_IN_PERCEPTION_AREA

```c
BOOL IS_TARGET_PED_IN_PERCEPTION_AREA(Ped ped, Ped targetPed, float p2, float p3, float p4, float p5)  // 0x06087579E7AA85A9
```

build 323

## IS_TRACKED_PED_VISIBLE

```c
BOOL IS_TRACKED_PED_VISIBLE(Ped ped)  // 0x91C8E617F64188AC
```

build 323

> returns whether or not a ped is visible within your FOV, not this check auto's to false after a certain distance.
> 
> 
> Target needs to be tracked.. won't work otherwise.

## IS_USING_PED_SCUBA_GEAR_VARIATION

```c
BOOL IS_USING_PED_SCUBA_GEAR_VARIATION(Any p0)  // 0xFEC9A3B1820F3331
```

build 323

## KNOCK_OFF_PED_PROP

```c
void KNOCK_OFF_PED_PROP(Ped ped, BOOL p1, BOOL p2, BOOL p3, BOOL p4)  // 0x6FD7816A36615F48
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## KNOCK_PED_OFF_VEHICLE

```c
void KNOCK_PED_OFF_VEHICLE(Ped ped)  // 0x45BBCBA77C29A841
```

build 323

## MARK_PED_DECORATIONS_AS_CLONED_FROM_LOCAL_PLAYER

```c
void MARK_PED_DECORATIONS_AS_CLONED_FROM_LOCAL_PLAYER(Ped ped, BOOL p1)  // 0x2B694AFCF64E6994
```

build 323

## PED_HAS_SEXINESS_FLAG_SET

```c
BOOL PED_HAS_SEXINESS_FLAG_SET(Ped ped, int sexinessFlag)  // 0x46B05BCAE43856B0
```

build 323

> Checks if the specified sexiness flag is set
> 
> enum eSexinessFlags
> {
> 	SF_JEER_AT_HOT_PED = 0,
> 	SF_JEER_SCENARIO_ANIM = 1,
> 	SF_HOT_PERSON = 2,
> };

## PLAY_FACIAL_ANIM

```c
void PLAY_FACIAL_ANIM(Ped ped, const char* animName, const char* animDict)  // 0xE1E65CA8AC9C00ED
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## REGISTER_HATED_TARGETS_AROUND_PED

```c
void REGISTER_HATED_TARGETS_AROUND_PED(Ped ped, float radius)  // 0x9222F300BF8354FE
```

build 323

> Based on TASK_COMBAT_HATED_TARGETS_AROUND_PED, the parameters are likely similar (PedHandle, and area to attack in).

## REGISTER_PEDHEADSHOT

```c
int REGISTER_PEDHEADSHOT(Ped ped)  // 0x4462658788425076
```

build 323

> https://gtaforums.com/topic/885580-ped-headshotmugshot-txd/

## REGISTER_PEDHEADSHOT_HIRES

```c
int REGISTER_PEDHEADSHOT_HIRES(Ped ped)  // 0xBA8805A1108A2515
```

build 877 · old names: `_REGISTER_PEDHEADSHOT_3`

## REGISTER_PEDHEADSHOT_TRANSPARENT

```c
int REGISTER_PEDHEADSHOT_TRANSPARENT(Ped ped)  // 0x953563CE563143AF
```

build 323

> Similar to REGISTER_PEDHEADSHOT but creates a transparent background instead of black.

## REGISTER_TARGET

```c
void REGISTER_TARGET(Ped ped, Ped target)  // 0x2F25D9AEFA34FBA2
```

build 323

> PED::REGISTER_TARGET(l_216, PLAYER::PLAYER_PED_ID()); from re_prisonbreak.txt.
> 
> l_216 = RECSBRobber1

## RELEASE_PED_PRELOAD_PROP_DATA

```c
void RELEASE_PED_PRELOAD_PROP_DATA(Ped ped)  // 0xF79F9DEF0AADE61A
```

build 323

## RELEASE_PED_PRELOAD_VARIATION_DATA

```c
void RELEASE_PED_PRELOAD_VARIATION_DATA(Ped ped)  // 0x5AAB586FFEC0FD96
```

build 323

## RELEASE_PEDHEADSHOT_IMG_UPLOAD

```c
void RELEASE_PEDHEADSHOT_IMG_UPLOAD(int id)  // 0x5D517B27CF6ECD04
```

build 323

## REMOVE_ACTION_MODE_ASSET

```c
void REMOVE_ACTION_MODE_ASSET(const char* asset)  // 0x13E940F88470FA51
```

build 323

## REMOVE_GROUP

```c
void REMOVE_GROUP(int groupId)  // 0x8EB2F69076AF7053
```

build 323

## REMOVE_PED_DEFENSIVE_AREA

```c
void REMOVE_PED_DEFENSIVE_AREA(Ped ped, BOOL toggle)  // 0x74D4E028107450A9
```

build 323

> Ped will no longer get angry when you stay near him.

## REMOVE_PED_ELEGANTLY

```c
void REMOVE_PED_ELEGANTLY(Ped* ped)  // 0xAC6D445B994DF95E
```

build 323

> Judging purely from a quick disassembly, if the ped is in a vehicle, the ped will be deleted immediately. If not, it'll be marked as no longer needed. - very elegant..

## REMOVE_PED_FROM_GROUP

```c
void REMOVE_PED_FROM_GROUP(Ped ped)  // 0xED74007FFB146BC2
```

build 323

## REMOVE_PED_HELMET

```c
void REMOVE_PED_HELMET(Ped ped, BOOL instantly)  // 0xA7B2458D0AD6DED8
```

build 323

## REMOVE_PED_PREFERRED_COVER_SET

```c
void REMOVE_PED_PREFERRED_COVER_SET(Ped ped)  // 0xFDDB234CF74073D9
```

build 323

## REMOVE_RELATIONSHIP_GROUP

```c
void REMOVE_RELATIONSHIP_GROUP(Hash groupHash)  // 0xB6BA2444AB393DA2
```

build 323

## REMOVE_SCENARIO_BLOCKING_AREA

```c
void REMOVE_SCENARIO_BLOCKING_AREA(Any p0, BOOL p1)  // 0x31D16B74C6E29D66
```

build 323

## REMOVE_SCENARIO_BLOCKING_AREAS

```c
void REMOVE_SCENARIO_BLOCKING_AREAS()  // 0xD37401D78A929A49
```

build 323

## REMOVE_STEALTH_MODE_ASSET

```c
void REMOVE_STEALTH_MODE_ASSET(const char* asset)  // 0x9219857D21F0E842
```

build 323

## REQUEST_ACTION_MODE_ASSET

```c
void REQUEST_ACTION_MODE_ASSET(const char* asset)  // 0x290E2780BB7AA598
```

build 323

## REQUEST_PED_RESTRICTED_VEHICLE_VISIBILITY_TRACKING

```c
void REQUEST_PED_RESTRICTED_VEHICLE_VISIBILITY_TRACKING(Ped ped, BOOL p1)  // 0xCD018C591F94CB43
```

build 323

## REQUEST_PED_USE_SMALL_BBOX_VISIBILITY_TRACKING

```c
void REQUEST_PED_USE_SMALL_BBOX_VISIBILITY_TRACKING(Ped ped, BOOL p1)  // 0x75BA1CB3B7D40CAF
```

build 323

## REQUEST_PED_VEHICLE_VISIBILITY_TRACKING

```c
void REQUEST_PED_VEHICLE_VISIBILITY_TRACKING(Ped ped, BOOL p1)  // 0x2BC338A7B21F4608
```

build 323 · old names: `GET_PED_FLOOD_INVINCIBILITY`

## REQUEST_PED_VISIBILITY_TRACKING

```c
void REQUEST_PED_VISIBILITY_TRACKING(Ped ped)  // 0x7D7A2E43E74E2EB8
```

build 323

## REQUEST_PEDHEADSHOT_IMG_UPLOAD

```c
BOOL REQUEST_PEDHEADSHOT_IMG_UPLOAD(int id)  // 0xF0DAEF2F545BEE25
```

build 323

## REQUEST_RAGDOLL_BOUNDS_UPDATE

```c
void REQUEST_RAGDOLL_BOUNDS_UPDATE(Any p0, Any p1)  // 0x1216E0BFA72CC703
```

build 323

> This native does absolutely nothing, just a nullsub

## REQUEST_STEALTH_MODE_ASSET

```c
void REQUEST_STEALTH_MODE_ASSET(const char* asset)  // 0x2A0A62FCDEE16D4F
```

build 323

## RESET_AI_MELEE_WEAPON_DAMAGE_MODIFIER

```c
void RESET_AI_MELEE_WEAPON_DAMAGE_MODIFIER()  // 0x46E56A7CD1D63C3F
```

build 323

## RESET_AI_WEAPON_DAMAGE_MODIFIER

```c
void RESET_AI_WEAPON_DAMAGE_MODIFIER()  // 0xEA16670E7BA4743C
```

build 323

## RESET_FACIAL_IDLE_ANIM

```c
void RESET_FACIAL_IDLE_ANIM(Ped ped)  // 0x007FDE5A7897E426
```

build 2802

## RESET_GROUP_FORMATION_DEFAULT_SPACING

```c
void RESET_GROUP_FORMATION_DEFAULT_SPACING(int groupHandle)  // 0x63DAB4CCB3273205
```

build 323

## RESET_PED_IN_VEHICLE_CONTEXT

```c
void RESET_PED_IN_VEHICLE_CONTEXT(Ped ped)  // 0x22EF8FF8778030EB
```

build 323

## RESET_PED_LAST_VEHICLE

```c
void RESET_PED_LAST_VEHICLE(Ped ped)  // 0xBB8DE8CF6A8DD8BB
```

build 323

> Resets the value for the last vehicle driven by the Ped.

## RESET_PED_MOVEMENT_CLIPSET

```c
void RESET_PED_MOVEMENT_CLIPSET(Ped ped, float p1)  // 0xAA74EC0CB0AAEA2C
```

build 323

> If p1 is 0.0, I believe you are back to normal. 
> If p1 is 1.0, it looks like you can only rotate the ped, not walk.
> 
> Using the following code to reset back to normal
> PED::RESET_PED_MOVEMENT_CLIPSET(PLAYER::PLAYER_PED_ID(), 0.0);

## RESET_PED_RAGDOLL_TIMER

```c
void RESET_PED_RAGDOLL_TIMER(Ped ped)  // 0x9FA4664CF62E47E8
```

build 323

## RESET_PED_STRAFE_CLIPSET

```c
void RESET_PED_STRAFE_CLIPSET(Ped ped)  // 0x20510814175EA477
```

build 323

## RESET_PED_VISIBLE_DAMAGE

```c
void RESET_PED_VISIBLE_DAMAGE(Ped ped)  // 0x3AC1F7B898F30C05
```

build 323

## RESET_PED_WEAPON_MOVEMENT_CLIPSET

```c
void RESET_PED_WEAPON_MOVEMENT_CLIPSET(Ped ped)  // 0x97B0DB5B4AA74E77
```

build 323

## RESURRECT_PED

```c
void RESURRECT_PED(Ped ped)  // 0x71BC8E838B9C6035
```

build 323

> This function will simply bring the dead person back to life.
> 
> Try not to use it alone, since using this function alone, will make peds fall through ground in hell(well for the most of the times).
> 
> Instead, before calling this function, you may want to declare the position, where your Resurrected ped to be spawn at.(For instance, Around 2 floats of Player's current position.) 
> 
> Also, disabling any assigned task immediately helped in the number of scenarios, where If you want peds to perform certain decided tasks.

## REVIVE_INJURED_PED

```c
void REVIVE_INJURED_PED(Ped ped)  // 0x8D8ACD8388CD99CE
```

build 323

> It will revive/cure the injured ped. The condition is ped must not be dead.
> 
> Upon setting and converting the health int, found, if health falls below 5, the ped will lay on the ground in pain(Maximum default health is 100).
> 
> This function is well suited there.

## SET_AI_MELEE_WEAPON_DAMAGE_MODIFIER

```c
void SET_AI_MELEE_WEAPON_DAMAGE_MODIFIER(float modifier)  // 0x66460DEDDD417254
```

build 323

## SET_AI_WEAPON_DAMAGE_MODIFIER

```c
void SET_AI_WEAPON_DAMAGE_MODIFIER(float value)  // 0x1B1E2A40A65B8521
```

build 323

## SET_ALLOW_LOCKON_TO_PED_IF_FRIENDLY

```c
void SET_ALLOW_LOCKON_TO_PED_IF_FRIENDLY(Ped ped, BOOL toggle)  // 0x061CB768363D6424
```

build 323

## SET_ALLOW_STUNT_JUMP_CAMERA

```c
void SET_ALLOW_STUNT_JUMP_CAMERA(Ped ped, BOOL toggle)  // 0xFAB944D4D481ACCB
```

build 1734

## SET_AMBIENT_LAW_PED_ACCURACY_MODIFIER

```c
void SET_AMBIENT_LAW_PED_ACCURACY_MODIFIER(float multiplier)  // 0x87DDEB611B329A9C
```

build 1103

## SET_AMBIENT_PEDS_DROP_MONEY

```c
void SET_AMBIENT_PEDS_DROP_MONEY(BOOL p0)  // 0x6B0E6172C9A4D902
```

build 323

## SET_BLOCKING_OF_NON_TEMPORARY_EVENTS

```c
void SET_BLOCKING_OF_NON_TEMPORARY_EVENTS(Ped ped, BOOL toggle)  // 0x9F8AA94D6D97DBF4
```

build 323

> works with TASK::TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS to make a ped completely oblivious to all events going on around him

## SET_BLOCKING_OF_NON_TEMPORARY_EVENTS_FOR_AMBIENT_PEDS_THIS_FRAME

```c
void SET_BLOCKING_OF_NON_TEMPORARY_EVENTS_FOR_AMBIENT_PEDS_THIS_FRAME(BOOL p0)  // 0x9911F4A24485F653
```

build 323

## SET_CAN_ATTACK_FRIENDLY

```c
void SET_CAN_ATTACK_FRIENDLY(Ped ped, BOOL toggle, BOOL p2)  // 0xB3B1CB349FF9C75D
```

build 323

> Setting ped to true allows the ped to shoot "friendlies".
> 
> p2 set to true when toggle is also true seams to make peds permanently unable to aim at, even if you set p2 back to false.
> 
> p1 = false & p2 = false for unable to aim at.
> p1 = true & p2 = false for able to aim at. 

## SET_COMBAT_FLOAT

```c
void SET_COMBAT_FLOAT(Ped ped, int combatType, float p2)  // 0xFF41B4B141ED981C
```

build 323

> combatType can be between 0-14. See GET_COMBAT_FLOAT below for a list of possible parameters.

## SET_COP_PERCEPTION_OVERRIDES

```c
void SET_COP_PERCEPTION_OVERRIDES(float seeingRange, float seeingRangePeripheral, float hearingRange, float visualFieldMinAzimuthAngle, float visualFieldMaxAzimuthAngle, float fieldOfGazeMaxAngle, float p6)  // 0x2F074C904D85129E
```

build 393 · old names: `_SET_PED_PERCEPTION_OVERRIDE_THIS_FRAME`

## SET_CORPSE_RAGDOLL_FRICTION

```c
void SET_CORPSE_RAGDOLL_FRICTION(Ped ped, float p1)  // 0x2735233A786B1BEF
```

build 323

## SET_CREATE_RANDOM_COPS

```c
void SET_CREATE_RANDOM_COPS(BOOL toggle)  // 0x102E68B2024D536D
```

build 323

## SET_CREATE_RANDOM_COPS_NOT_ON_SCENARIOS

```c
void SET_CREATE_RANDOM_COPS_NOT_ON_SCENARIOS(BOOL toggle)  // 0x8A4986851C4EF6E7
```

build 323

## SET_CREATE_RANDOM_COPS_ON_SCENARIOS

```c
void SET_CREATE_RANDOM_COPS_ON_SCENARIOS(BOOL toggle)  // 0x444CB7D7DBE6973D
```

build 323

## SET_DISABLE_HIGH_FALL_DEATH

```c
void SET_DISABLE_HIGH_FALL_DEATH(Ped ped, BOOL toggle)  // 0x711794453CFD692B
```

build 463 · old names: `_SET_DISABLE_PED_FALL_DAMAGE`

## SET_DISABLE_PED_MAP_COLLISION

```c
void SET_DISABLE_PED_MAP_COLLISION(Ped ped)  // 0xDFE68C4B787E1BFB
```

build 1180

## SET_DRIVER_ABILITY

```c
void SET_DRIVER_ABILITY(Ped driver, float ability)  // 0xB195FFA8042FC5C3
```

build 323

> The function specifically verifies the value is equal to, or less than 1.0f. If it is greater than 1.0f, the function does nothing at all.

## SET_DRIVER_AGGRESSIVENESS

```c
void SET_DRIVER_AGGRESSIVENESS(Ped driver, float aggressiveness)  // 0xA731F608CA104E3C
```

build 323

> range 0.0f - 1.0f

## SET_DRIVER_RACING_MODIFIER

```c
void SET_DRIVER_RACING_MODIFIER(Ped driver, float modifier)  // 0xDED5AF5A0EA4B297
```

build 323

> Scripts use 0.2, 0.5 and 1.0. Value must be >= 0.0 && <= 1.0

## SET_ENABLE_BOUND_ANKLES

```c
void SET_ENABLE_BOUND_ANKLES(Ped ped, BOOL toggle)  // 0xC52E0F855C58FC2E
```

build 323

> Used with SET_ENABLE_HANDCUFFS in decompiled scripts. From my observations, I have noticed that while being ragdolled you are not able to get up but you can still run. Your legs can also bend.

## SET_ENABLE_HANDCUFFS

```c
void SET_ENABLE_HANDCUFFS(Ped ped, BOOL toggle)  // 0xDF1AF8B5D56542FA
```

build 323

> ped can not pull out a weapon when true

## SET_ENABLE_PED_ENVEFF_SCALE

```c
void SET_ENABLE_PED_ENVEFF_SCALE(Ped ped, BOOL toggle)  // 0xD2C5AA0C0E8D0F1E
```

build 323

## SET_ENABLE_SCUBA

```c
void SET_ENABLE_SCUBA(Ped ped, BOOL toggle)  // 0xF99F62004024D506
```

build 323

> Enables diving motion when underwater.

## SET_FACIAL_CLIPSET

```c
void SET_FACIAL_CLIPSET(Ped ped, const char* animDict)  // 0x5687C7F05B39E401
```

build 1493 · old names: `_SET_FACIAL_CLIPSET_OVERRIDE`

> Clipsets:
> facials@gen_female@base
> facials@gen_male@base
> facials@p_m_zero@base
> 
> Typically followed with SET_FACIAL_IDLE_ANIM_OVERRIDE:
> mood_drunk_1
> mood_stressed_1
> mood_happy_1
> mood_talking_1
> 

## SET_FACIAL_IDLE_ANIM_OVERRIDE

```c
void SET_FACIAL_IDLE_ANIM_OVERRIDE(Ped ped, const char* animName, const char* animDict)  // 0xFFC24B988B938B38
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json

## SET_FORCE_FOOTSTEP_UPDATE

```c
void SET_FORCE_FOOTSTEP_UPDATE(Ped ped, BOOL toggle)  // 0x129466ED55140F8D
```

build 323

## SET_FORCE_STEP_TYPE

```c
void SET_FORCE_STEP_TYPE(Ped ped, BOOL p1, int type, int p3)  // 0xCB968B53FC7F916D
```

build 323

## SET_GROUP_FORMATION

```c
void SET_GROUP_FORMATION(int groupId, int formationType)  // 0xCE2F5FC3AF7E8C1E
```

build 323

> 0: Default
> 1: Circle Around Leader
> 2: Alternative Circle Around Leader
> 3: Line, with Leader at center

## SET_GROUP_FORMATION_SPACING

```c
void SET_GROUP_FORMATION_SPACING(int groupId, float x, float y, float z)  // 0x1D9D45004C28C916
```

build 323

## SET_GROUP_SEPARATION_RANGE

```c
void SET_GROUP_SEPARATION_RANGE(int groupHandle, float separationRange)  // 0x4102C7858CFEE4E4
```

build 323

> Sets the range at which members will automatically leave the group.

## SET_HEAD_BLEND_EYE_COLOR

```c
void SET_HEAD_BLEND_EYE_COLOR(Ped ped, int index)  // 0x50B56988B170AFDF
```

build 323 · old names: `_SET_PED_EYE_COLOR`

> Used for freemode (online) characters.
> 
> For some reason, the scripts use a rounded float for the index.
> Indexes:
> 1. black
> 2. very light blue/green
> 3. dark blue
> 4. brown
> 5. darker brown
> 6. light brown
> 7. blue
> 8. light blue
> 9. pink
> 10. yellow
> 11. purple
> 12. black
> 13. dark green
> 14. light brown
> 15. yellow/black pattern
> 16. light colored spiral pattern
> 17. shiny red
> 18. shiny half blue/half red
> 19. half black/half light blue
> 20. white/red perimter
> 21. green snake
> 22. red snake
> 23. dark blue snake
> 24. dark yellow
> 25. bright yellow
> 26. all black
> 28. red small pupil
> 29. devil blue/black
> 30. white small pupil
> 31. glossed over

## SET_HEAD_BLEND_PALETTE_COLOR

```c
void SET_HEAD_BLEND_PALETTE_COLOR(Ped ped, int r, int g, int b, int id)  // 0xCC9682B8951C5229
```

build 323

> p4 seems to vary from 0 to 3.

## SET_HEALTH_SNACKS_CARRIED_BY_ALL_NEW_PEDS

```c
void SET_HEALTH_SNACKS_CARRIED_BY_ALL_NEW_PEDS(float p0, Any p1)  // 0xFF4803BC019852D9
```

build 323

> Related to Peds dropping pickup_health_snack; p0 is a value between [0.0, 1.0] that corresponds to drop rate

## SET_IK_TARGET

```c
void SET_IK_TARGET(Ped ped, int ikIndex, Entity entityLookAt, int boneLookAt, float offsetX, float offsetY, float offsetZ, Any p7, int blendInDuration, int blendOutDuration)  // 0xC32779C16FCEECD9
```

build 323

## SET_LADDER_CLIMB_INPUT_STATE

```c
void SET_LADDER_CLIMB_INPUT_STATE(Ped ped, int p1)  // 0x1A330D297AAC6BC1
```

build 323

> Only appears in lamar1 script.

## SET_MOVEMENT_MODE_OVERRIDE

```c
void SET_MOVEMENT_MODE_OVERRIDE(Ped ped, const char* name)  // 0x781DE8FA214E87D2
```

build 323

> name: "MP_FEMALE_ACTION" found multiple times in the b617d scripts.

## SET_PED_ACCURACY

```c
void SET_PED_ACCURACY(Ped ped, int accuracy)  // 0x7AEFB85C1D49DEB6
```

build 323

> accuracy = 0-100, 100 being perfectly accurate

## SET_PED_ALERTNESS

```c
void SET_PED_ALERTNESS(Ped ped, int value)  // 0xDBA71115ED9941A6
```

build 323

> value ranges from 0 to 3.

## SET_PED_ALLOW_HURT_COMBAT_FOR_ALL_MISSION_PEDS

```c
void SET_PED_ALLOW_HURT_COMBAT_FOR_ALL_MISSION_PEDS(BOOL toggle)  // 0xF2BEBCDFAFDAA19E
```

build 323

> ntoggle was always false except in one instance (b678).
> 
> The one time this is set to true seems to do with when you fail the mission.

## SET_PED_ALLOW_MINOR_REACTIONS_AS_MISSION_PED

```c
void SET_PED_ALLOW_MINOR_REACTIONS_AS_MISSION_PED(Ped ped, BOOL toggle)  // 0x49E50BDB8BA4DAB2
```

build 323

## SET_PED_ALLOW_VEHICLES_OVERRIDE

```c
void SET_PED_ALLOW_VEHICLES_OVERRIDE(Ped ped, BOOL toggle)  // 0x3C028C636A414ED9
```

build 323

## SET_PED_ALLOWED_TO_DUCK

```c
void SET_PED_ALLOWED_TO_DUCK(Ped ped, BOOL toggle)  // 0xDA1F1B7BE1A8766F
```

build 323

## SET_PED_ALTERNATE_MOVEMENT_ANIM

```c
void SET_PED_ALTERNATE_MOVEMENT_ANIM(Ped ped, int stance, const char* animDictionary, const char* animationName, float p4, BOOL p5)  // 0x90A43CC281FFAB46
```

build 323

> stance:
> 0 = idle
> 1 = walk
> 2 = running
> 
> p5 = usually set to true
> 
> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## SET_PED_ALTERNATE_WALK_ANIM

```c
void SET_PED_ALTERNATE_WALK_ANIM(Ped ped, const char* animDict, const char* animName, float p3, BOOL p4)  // 0x6C60394CB4F75E9A
```

build 323

> Full list of animation dictionaries and anims by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/animDictsCompact.json
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## SET_PED_ANGLED_DEFENSIVE_AREA

```c
void SET_PED_ANGLED_DEFENSIVE_AREA(Ped ped, float p1, float p2, float p3, float p4, float p5, float p6, float p7, BOOL p8, BOOL p9)  // 0xC7F76DF27A5045A1
```

build 323

## SET_PED_AO_BLOB_RENDERING

```c
void SET_PED_AO_BLOB_RENDERING(Ped ped, BOOL toggle)  // 0x2B5AA717A181FB4C
```

build 323

> Enable/disable ped shadow (ambient occlusion).

## SET_PED_ARMOUR

```c
void SET_PED_ARMOUR(Ped ped, int amount)  // 0xCEA04D83135264CC
```

build 323

> Sets the armor of the specified ped.
> 
> ped: The Ped to set the armor of.
> amount: A value between 0 and 100 indicating the value to set the Ped's armor to.

## SET_PED_AS_COP

```c
void SET_PED_AS_COP(Ped ped, BOOL toggle)  // 0xBB03C38DD3FB7FFD
```

build 323

> Turns the desired ped into a cop. If you use this on the player ped, you will become almost invisible to cops dispatched for you. You will also report your own crimes, get a generic cop voice, get a cop-vision-cone on the radar, and you will be unable to shoot at other cops. SWAT and Army will still shoot at you. Toggling ped as "false" has no effect; you must change p0's ped model to disable the effect.

## SET_PED_AS_ENEMY

```c
void SET_PED_AS_ENEMY(Ped ped, BOOL toggle)  // 0x02A0C9720B854BFA
```

build 323

## SET_PED_AS_GROUP_LEADER

```c
void SET_PED_AS_GROUP_LEADER(Ped ped, int groupId)  // 0x2A7819605465FBCE
```

build 323

## SET_PED_AS_GROUP_MEMBER

```c
void SET_PED_AS_GROUP_MEMBER(Ped ped, int groupId)  // 0x9F3480FE65DB31B5
```

build 323

## SET_PED_BLEND_FROM_PARENTS

```c
void SET_PED_BLEND_FROM_PARENTS(Ped ped, Any p1, Any p2, float p3, float p4)  // 0x137BBD05230DB22D
```

build 323

## SET_PED_BLOCKS_PATHING_WHEN_DEAD

```c
void SET_PED_BLOCKS_PATHING_WHEN_DEAD(Ped ped, BOOL toggle)  // 0x576594E8D64375E2
```

build 323

## SET_PED_BOUNDS_ORIENTATION

```c
void SET_PED_BOUNDS_ORIENTATION(Ped ped, float p1, float p2, float x, float y, float z)  // 0x4F5F651ACCC9C4CF
```

build 323

## SET_PED_CAN_ARM_IK

```c
void SET_PED_CAN_ARM_IK(Ped ped, BOOL toggle)  // 0x6C3B4D6D13B4C841
```

build 323

## SET_PED_CAN_BE_DRAGGED_OUT

```c
void SET_PED_CAN_BE_DRAGGED_OUT(Ped ped, BOOL toggle)  // 0xC1670E958EEE24E5
```

build 323

## SET_PED_CAN_BE_KNOCKED_OFF_BIKE

```c
void SET_PED_CAN_BE_KNOCKED_OFF_BIKE(Any p0, Any p1)  // 0xB282749D5E028163
```

build 877

> This native does absolutely nothing, just a nullsub

## SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE

```c
void SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE(Ped ped, int state)  // 0x7A6535691B477C48
```

build 323

> state: https://alloc8or.re/gta5/doc/enums/eKnockOffVehicle.txt

## SET_PED_CAN_BE_SHOT_IN_VEHICLE

```c
void SET_PED_CAN_BE_SHOT_IN_VEHICLE(Ped ped, BOOL toggle)  // 0xC7EF1BA83230BA07
```

build 323

## SET_PED_CAN_BE_TARGETED_WHEN_INJURED

```c
void SET_PED_CAN_BE_TARGETED_WHEN_INJURED(Ped ped, BOOL toggle)  // 0x638C03B0F9878F57
```

build 323

## SET_PED_CAN_BE_TARGETED_WITHOUT_LOS

```c
void SET_PED_CAN_BE_TARGETED_WITHOUT_LOS(Ped ped, BOOL toggle)  // 0x4328652AE5769C71
```

build 323

## SET_PED_CAN_BE_TARGETTED

```c
void SET_PED_CAN_BE_TARGETTED(Ped ped, BOOL toggle)  // 0x63F58F7C80513AAD
```

build 323

## SET_PED_CAN_BE_TARGETTED_BY_PLAYER

```c
void SET_PED_CAN_BE_TARGETTED_BY_PLAYER(Ped ped, Player player, BOOL toggle)  // 0x66B57B72E0836A76
```

build 323

## SET_PED_CAN_BE_TARGETTED_BY_TEAM

```c
void SET_PED_CAN_BE_TARGETTED_BY_TEAM(Ped ped, int team, BOOL toggle)  // 0xBF1CA77833E58F2C
```

build 323

## SET_PED_CAN_BODY_RECOIL_IK

```c
void SET_PED_CAN_BODY_RECOIL_IK(Ped ped, BOOL toggle)  // 0xE84EC1735FB39663
```

build 3717

## SET_PED_CAN_COWER_IN_COVER

```c
void SET_PED_CAN_COWER_IN_COVER(Ped ped, BOOL toggle)  // 0xCB7553CDCEF4A735
```

build 323

> It simply makes the said ped to cower behind cover object(wall, desk, car)
> 
> Peds flee attributes must be set to not to flee, first. Else, most of the peds, will just flee from gunshot sounds or any other panic situations.

## SET_PED_CAN_EVASIVE_DIVE

```c
void SET_PED_CAN_EVASIVE_DIVE(Ped ped, BOOL toggle)  // 0x6B7A646C242A7059
```

build 323

## SET_PED_CAN_HEAD_IK

```c
void SET_PED_CAN_HEAD_IK(Ped ped, BOOL toggle)  // 0xC11C18092C5530DC
```

build 323

## SET_PED_CAN_LEG_IK

```c
void SET_PED_CAN_LEG_IK(Ped ped, BOOL toggle)  // 0x73518ECE2485412B
```

build 323

## SET_PED_CAN_LOSE_PROPS_ON_DAMAGE

```c
void SET_PED_CAN_LOSE_PROPS_ON_DAMAGE(Ped ped, BOOL toggle, int p2)  // 0xE861D0B05C7662B8
```

build 323

## SET_PED_CAN_PEEK_IN_COVER

```c
void SET_PED_CAN_PEEK_IN_COVER(Ped ped, BOOL toggle)  // 0xC514825C507E3736
```

build 323

## SET_PED_CAN_PLAY_AMBIENT_ANIMS

```c
void SET_PED_CAN_PLAY_AMBIENT_ANIMS(Ped ped, BOOL toggle)  // 0x6373D1349925A70E
```

build 323

## SET_PED_CAN_PLAY_AMBIENT_BASE_ANIMS

```c
void SET_PED_CAN_PLAY_AMBIENT_BASE_ANIMS(Ped ped, BOOL toggle)  // 0x0EB0585D15254740
```

build 323

## SET_PED_CAN_PLAY_GESTURE_ANIMS

```c
void SET_PED_CAN_PLAY_GESTURE_ANIMS(Ped ped, BOOL toggle)  // 0xBAF20C5432058024
```

build 323

## SET_PED_CAN_PLAY_IN_CAR_IDLES

```c
void SET_PED_CAN_PLAY_IN_CAR_IDLES(Ped ped, BOOL toggle)  // 0x820E9892A77E97CD
```

build 877 · old names: `_SET_PED_CAN_PLAY_IN_CAR_IDLES`

> Toggles config flag CPED_CONFIG_FLAG_CanPlayInCarIdles.

## SET_PED_CAN_PLAY_VISEME_ANIMS

```c
void SET_PED_CAN_PLAY_VISEME_ANIMS(Ped ped, BOOL toggle, BOOL p2)  // 0xF833DDBA3B104D43
```

build 323

> p2 usually 0

## SET_PED_CAN_RAGDOLL

```c
void SET_PED_CAN_RAGDOLL(Ped ped, BOOL toggle)  // 0xB128377056A54E2A
```

build 323

## SET_PED_CAN_RAGDOLL_FROM_PLAYER_IMPACT

```c
void SET_PED_CAN_RAGDOLL_FROM_PLAYER_IMPACT(Ped ped, BOOL toggle)  // 0xDF993EE5E90ABA25
```

build 323

## SET_PED_CAN_SMASH_GLASS

```c
void SET_PED_CAN_SMASH_GLASS(Ped ped, BOOL p1, BOOL p2)  // 0x1CCE141467FF42A2
```

build 323

## SET_PED_CAN_SWITCH_WEAPON

```c
void SET_PED_CAN_SWITCH_WEAPON(Ped ped, BOOL toggle)  // 0xED7F7EFE9FABF340
```

build 323

## SET_PED_CAN_TELEPORT_TO_GROUP_LEADER

```c
void SET_PED_CAN_TELEPORT_TO_GROUP_LEADER(Ped pedHandle, int groupHandle, BOOL toggle)  // 0x2E2F4240B3F24647
```

build 323

> This only will teleport the ped to the group leader if the group leader teleports (sets coords).
> 
> Only works in singleplayer

## SET_PED_CAN_TORSO_IK

```c
void SET_PED_CAN_TORSO_IK(Ped ped, BOOL toggle)  // 0xF2B7106D37947CE0
```

build 323

## SET_PED_CAN_TORSO_REACT_IK

```c
void SET_PED_CAN_TORSO_REACT_IK(Ped ped, BOOL p1)  // 0xF5846EDB26A98A24
```

build 323

## SET_PED_CAN_TORSO_VEHICLE_IK

```c
void SET_PED_CAN_TORSO_VEHICLE_IK(Ped ped, BOOL p1)  // 0x6647C5F6F5792496
```

build 323

## SET_PED_CAN_USE_AUTO_CONVERSATION_LOOKAT

```c
void SET_PED_CAN_USE_AUTO_CONVERSATION_LOOKAT(Ped ped, BOOL toggle)  // 0xEC4686EC06434678
```

build 323

## SET_PED_CAPSULE

```c
void SET_PED_CAPSULE(Ped ped, float value)  // 0x364DF566EC833DE2
```

build 323

> Overrides the ped's collision capsule radius for the current tick.
> Must be called every tick to be effective.
> 
> Setting this to 0.001 will allow warping through some objects.

## SET_PED_CLOTH_PACKAGE_INDEX

```c
void SET_PED_CLOTH_PACKAGE_INDEX(Any p0, Any p1)  // 0x82A3D6D9CC2CB8E3
```

build 323 · old names: `SET_PED_CLOTH_PRONE`

## SET_PED_CLOTH_PIN_FRAMES

```c
void SET_PED_CLOTH_PIN_FRAMES(Any p0, Any p1)  // 0x78C4E9961DB3EB5B
```

build 323 · old names: `SET_PED_CLOTH_PACKAGE_INDEX`

## SET_PED_CLOTH_PRONE

```c
void SET_PED_CLOTH_PRONE(Any p0, BOOL p1)  // 0xA660FAF550EB37E5
```

build 323

## SET_PED_COMBAT_ABILITY

```c
void SET_PED_COMBAT_ABILITY(Ped ped, int abilityLevel)  // 0xC7622C0D36B2FDA8
```

build 323

> enum CCombatData__Ability
> {
> 	CA_Poor,
> 	CA_Average,
> 	CA_Professional,
> 	CA_NumTypes
> };

## SET_PED_COMBAT_ATTRIBUTES

```c
void SET_PED_COMBAT_ATTRIBUTES(Ped ped, int attributeId, BOOL enabled)  // 0x9F7794730795E019
```

build 323

> enum CCombatData__BehaviourFlags {
> 	BF_CanUseCover = 0,
> 	BF_CanUseVehicles = 1,
> 	BF_CanDoDrivebys = 2,
> 	BF_CanLeaveVehicle = 3,
> 	BF_CanUseDynamicStrafeDecisions = 4,
> 	BF_AlwaysFight = 5,
> 	BF_FleeWhilstInVehicle = 6,
> 	BF_JustFollowInVehicle = 7,
> 	BF_Unused_3 = 8,
> 	BF_WillScanForDeadPeds = 9,
> 	BF_Unused_1 = 10,
> 	BF_JustSeekCover = 11,
> 	BF_BlindFireWhenInCover = 12,
> 	BF_Aggressive = 13,
> 	BF_CanInvestigate = 14,
> 	BF_HasRadio = 15,
> 	BF_Unused_2 = 16,
> 	BF_AlwaysFlee = 17,
> 	BF_ForceInjuredOnGround = 18,
> 	BF_DisableInjuredOnGround = 19,
> 	BF_CanTauntInVehicle = 20,
> 	BF_CanChaseTargetOnFoot = 21,
> 	BF_WillDragInjuredPedsToSafety = 22,
> 	BF_RequiresLosToShoot = 23,
> 	BF_UseProximityFiringRate = 24,
> 	BF_DisableSecondaryTarget = 25,
> 	BF_DisableEntryReactions = 26,
> 	BF_PerfectAccuracy = 27,
> 	BF_CanUseFrustratedAdvance = 28,
> 	BF_MoveToLocationBeforeCoverSearch = 29,
> 	BF_CanShootWithoutLOS = 30,
> 	BF_MaintainMinDistanceToTarget = 31,
> 	BF_IgnoreHatedPedsInFastMovingVehicles = 32,
> 	BF_UseProximityAccuracy = 33,
> 	BF_CanUsePeekingVariations = 34,
> 	BF_DisablePinnedDown = 35,
> 	BF_DisablePinDownOthers = 36,
> 	BF_ClearAreaSetDefensiveIfDefensiveAreaReached = 37,
> 	BF_DisableBulletReactions = 38,
> 	BF_CanBust = 39,
> 	BF_IgnoredByOtherPedsWhenWanted = 40,
> 	BF_CanCommandeerVehicles = 41,
> 	BF_CanFlank = 42,
> 	BF_SwitchToAdvanceIfCantFindCover = 43,
> 	BF_SwitchToDefensiveIfInCover = 44,
> 	BF_ClearPrimaryDefensiveAreaWhenReached = 45,
> 	BF_CanFightArmedPedsWhenNotArmed = 46,
> 	BF_EnableTacticalPointsWhenDefensive = 47,
> 	BF_DisableCoverArcAdjustments = 48,
> 	BF_UseEnemyAccuracyScaling = 49,
> 	BF_CanCharge = 50,
> 	BF_ClearAreaSetAdvanceIfDefensiveAreaReached = 51,
> 	BF_UseVehicleAttack = 52,
> 	BF_UseVehicleAttackIfVehicleHasMountedGuns = 53,
> 	BF_AlwaysEquipBestWeapon = 54,
> 	BF_CanSeeUnderwaterPeds = 55,
> 	BF_DisableAimAtAITargetsInHelis = 56,
> 	BF_DisableSeekDueToLineOfSight = 57,
> 	BF_DisableFleeFromCombat = 58,
> 	BF_DisableTargetChangesDuringVehiclePursuit = 59,
> 	BF_CanThrowSmokeGrenade = 60,
> 	BF_NonMissionPedsFleeFromThisPedUnlessArmed = 61,
> 	BF_ClearAreaSetDefensiveIfDefensiveCannotBeReached = 62,
> 	BF_FleesFromInvincibleOpponents = 63,
> 	BF_DisableBlockFromPursueDuringVehicleChase = 64,
> 	BF_DisableSpinOutDuringVehicleChase = 65,
> 	BF_DisableCruiseInFrontDuringBlockDuringVehicleChase = 66,
> 	BF_CanIgnoreBlockedLosWeighting = 67,
> 	BF_DisableReactToBuddyShot = 68,
> 	BF_PreferNavmeshDuringVehicleChase = 69,
> 	BF_AllowedToAvoidOffroadDuringVehicleChase = 70,
> 	BF_PermitChargeBeyondDefensiveArea = 71,
> 	BF_UseRocketsAgainstVehiclesOnly = 72,
> 	BF_DisableTacticalPointsWithoutClearLos = 73,
> 	BF_DisablePullAlongsideDuringVehicleChase = 74,
> 	BF_DisableShoutTargetPosition = 75,
> 	BF_SetDisableShoutTargetPositionOnCombatStart = 76,
> 	BF_DisableRespondedToThreatBroadcast = 77,
> 	BF_DisableAllRandomsFlee = 78,
> 	BF_WillGenerateDeadPedSeenScriptEvents = 79,
> 	BF_UseMaxSenseRangeWhenReceivingEvents = 80,
> 	BF_RestrictInVehicleAimingToCurrentSide = 81,
> 	BF_UseDefaultBlockedLosPositionAndDirection = 82,
> 	BF_RequiresLosToAim = 83,
> 	BF_CruiseAndBlockInVehicle = 84,
> 	BF_PreferAirCombatWhenInAircraft = 85,
> 	BF_AllowDogFighting = 86,
> 	BF_PreferNonAircraftTargets = 87,
> 	BF_PreferKnownTargetsWhenCombatClosestTarget = 88,
> 	BF_ForceCheckAttackAngleForMountedGuns = 89,
> 	BF_BlockFireForVehiclePassengerMountedGuns = 90,
> 	MAX_COMBAT_FLAGS = 91,
> };

## SET_PED_COMBAT_MOVEMENT

```c
void SET_PED_COMBAT_MOVEMENT(Ped ped, int combatMovement)  // 0x4D9CA1009AFBD057
```

build 323

> enum CCombatData__Movement
> {
> 	CM_Stationary,
> 	CM_Defensive,
> 	CM_WillAdvance,
> 	CM_WillRetreat
> };

## SET_PED_COMBAT_RANGE

```c
void SET_PED_COMBAT_RANGE(Ped ped, int combatRange)  // 0x3C606747B23E497B
```

build 323

> enum CCombatData__Range
> {
> 	CR_Near,
> 	CR_Medium,
> 	CR_Far,
> 	CR_VeryFar,
> 	CR_NumRanges
> };

## SET_PED_COMPONENT_VARIATION

```c
void SET_PED_COMPONENT_VARIATION(Ped ped, int componentId, int drawableId, int textureId, int paletteId)  // 0x262B14F48D29DE80
```

build 323

> paletteId: 0 to 3.
> 
> componentId:
> enum ePedVarComp
> {
> 	PV_COMP_INVALID = -1,
> 	PV_COMP_HEAD,
> 	PV_COMP_BERD,
> 	PV_COMP_HAIR,
> 	PV_COMP_UPPR,
> 	PV_COMP_LOWR,
> 	PV_COMP_HAND,
> 	PV_COMP_FEET,
> 	PV_COMP_TEEF,
> 	PV_COMP_ACCS,
> 	PV_COMP_TASK,
> 	PV_COMP_DECL,
> 	PV_COMP_JBIB,
> 	PV_COMP_MAX
> };
> 
> Examples: https://gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html
> 
> Full list of ped components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedComponentVariations.json

## SET_PED_CONFIG_FLAG

```c
void SET_PED_CONFIG_FLAG(Ped ped, int flagId, BOOL value)  // 0x1913FE4CBF41C463
```

build 323

> enum ePedConfigFlags
> {
> 	CPED_CONFIG_FLAG_CreatedByFactory = 0,
> 	CPED_CONFIG_FLAG_CanBeShotInVehicle = 1,
> 	CPED_CONFIG_FLAG_NoCriticalHits = 2,
> 	CPED_CONFIG_FLAG_DrownsInWater = 3,
> 	CPED_CONFIG_FLAG_DrownsInSinkingVehicle = 4,
> 	CPED_CONFIG_FLAG_DiesInstantlyWhenSwimming = 5,
> 	CPED_CONFIG_FLAG_HasBulletProofVest = 6,
> 	CPED_CONFIG_FLAG_UpperBodyDamageAnimsOnly = 7,
> 	CPED_CONFIG_FLAG_NeverFallOffSkis = 8,
> 	CPED_CONFIG_FLAG_NeverEverTargetThisPed = 9,
> 	CPED_CONFIG_FLAG_ThisPedIsATargetPriority = 10,
> 	CPED_CONFIG_FLAG_TargettableWithNoLos = 11,
> 	CPED_CONFIG_FLAG_DoesntListenToPlayerGroupCommands = 12,
> 	CPED_CONFIG_FLAG_NeverLeavesGroup = 13,
> 	CPED_CONFIG_FLAG_DoesntDropWeaponsWhenDead = 14,
> 	CPED_CONFIG_FLAG_SetDelayedWeaponAsCurrent = 15,
> 	CPED_CONFIG_FLAG_KeepTasksAfterCleanUp = 16,
> 	CPED_CONFIG_FLAG_BlockNonTemporaryEvents = 17,
> 	CPED_CONFIG_FLAG_HasAScriptBrain = 18,
> 	CPED_CONFIG_FLAG_WaitingForScriptBrainToLoad = 19,
> 	CPED_CONFIG_FLAG_AllowMedicsToReviveMe = 20,
> 	CPED_CONFIG_FLAG_MoneyHasBeenGivenByScript = 21,
> 	CPED_CONFIG_FLAG_NotAllowedToCrouch = 22,
> 	CPED_CONFIG_FLAG_DeathPickupsPersist = 23,
> 	CPED_CONFIG_FLAG_IgnoreSeenMelee = 24,
> 	CPED_CONFIG_FLAG_ForceDieIfInjured = 25,
> 	CPED_CONFIG_FLAG_DontDragMeOutCar = 26,
> 	CPED_CONFIG_FLAG_StayInCarOnJack = 27,
> 	CPED_CONFIG_FLAG_ForceDieInCar = 28,
> 	CPED_CONFIG_FLAG_GetOutUndriveableVehicle = 29,
> 	CPED_CONFIG_FLAG_WillRemainOnBoatAfterMissionEnds = 30,
> 	CPED_CONFIG_FLAG_DontStoreAsPersistent = 31,
> 	CPED_CONFIG_FLAG_WillFlyThroughWindscreen = 32,
> 	CPED_CONFIG_FLAG_DieWhenRagdoll = 33,
> 	CPED_CONFIG_FLAG_HasHelmet = 34,
> 	CPED_CONFIG_FLAG_UseHelmet = 35,
> 	CPED_CONFIG_FLAG_DontTakeOffHelmet = 36,
> 	CPED_CONFIG_FLAG_HideInCutscene = 37,
> 	CPED_CONFIG_FLAG_PedIsEnemyToPlayer = 38,
> 	CPED_CONFIG_FLAG_DisableEvasiveDives = 39,
> 	CPED_CONFIG_FLAG_PedGeneratesDeadBodyEvents = 40,
> 	CPED_CONFIG_FLAG_DontAttackPlayerWithoutWantedLevel = 41,
> 	CPED_CONFIG_FLAG_DontInfluenceWantedLevel = 42,
> 	CPED_CONFIG_FLAG_DisablePlayerLockon = 43,
> 	CPED_CONFIG_FLAG_DisableLockonToRandomPeds = 44,
> 	CPED_CONFIG_FLAG_AllowLockonToFriendlyPlayers = 45,
> 	CPED_CONFIG_FLAG_DisableHornAudioWhenDead = 46,
> 	CPED_CONFIG_FLAG_PedBeingDeleted = 47,
> 	CPED_CONFIG_FLAG_BlockWeaponSwitching = 48,
> 	CPED_CONFIG_FLAG_BlockGroupPedAimedAtResponse = 49,
> 	CPED_CONFIG_FLAG_WillFollowLeaderAnyMeans = 50,
> 	CPED_CONFIG_FLAG_BlippedByScript = 51,
> 	CPED_CONFIG_FLAG_DrawRadarVisualField = 52,
> 	CPED_CONFIG_FLAG_StopWeaponFiringOnImpact = 53,
> 	CPED_CONFIG_FLAG_DissableAutoFallOffTests = 54,
> 	CPED_CONFIG_FLAG_SteerAroundDeadBodies = 55,
> 	CPED_CONFIG_FLAG_ConstrainToNavMesh = 56,
> 	CPED_CONFIG_FLAG_SyncingAnimatedProps = 57,
> 	CPED_CONFIG_FLAG_IsFiring = 58,
> 	CPED_CONFIG_FLAG_WasFiring = 59,
> 	CPED_CONFIG_FLAG_IsStanding = 60,
> 	CPED_CONFIG_FLAG_WasStanding = 61,
> 	CPED_CONFIG_FLAG_InVehicle = 62,
> 	CPED_CONFIG_FLAG_OnMount = 63,
> 	CPED_CONFIG_FLAG_AttachedToVehicle = 64,
> 	CPED_CONFIG_FLAG_IsSwimming = 65,
> 	CPED_CONFIG_FLAG_WasSwimming = 66,
> 	CPED_CONFIG_FLAG_IsSkiing = 67,
> 	CPED_CONFIG_FLAG_IsSitting = 68,
> 	CPED_CONFIG_FLAG_KilledByStealth = 69,
> 	CPED_CONFIG_FLAG_KilledByTakedown = 70,
> 	CPED_CONFIG_FLAG_Knockedout = 71,
> 	CPED_CONFIG_FLAG_ClearRadarBlipOnDeath = 72,
> 	CPED_CONFIG_FLAG_JustGotOffTrain = 73,
> 	CPED_CONFIG_FLAG_JustGotOnTrain = 74,
> 	CPED_CONFIG_FLAG_UsingCoverPoint = 75,
> 	CPED_CONFIG_FLAG_IsInTheAir = 76,
> 	CPED_CONFIG_FLAG_KnockedUpIntoAir = 77,
> 	CPED_CONFIG_FLAG_IsAimingGun = 78,
> 	CPED_CONFIG_FLAG_HasJustLeftCar = 79,
> 	CPED_CONFIG_FLAG_TargetWhenInjuredAllowed = 80,
> 	CPED_CONFIG_FLAG_CurrLeftFootCollNM = 81,
> 	CPED_CONFIG_FLAG_PrevLeftFootCollNM = 82,
> 	CPED_CONFIG_FLAG_CurrRightFootCollNM = 83,
> 	CPED_CONFIG_FLAG_PrevRightFootCollNM = 84,
> 	CPED_CONFIG_FLAG_HasBeenBumpedInCar = 85,
> 	CPED_CONFIG_FLAG_InWaterTaskQuitToClimbLadder = 86,
> 	CPED_CONFIG_FLAG_NMTwoHandedWeaponBothHandsConstrained = 87,
> 	CPED_CONFIG_FLAG_CreatedBloodPoolTimer = 88,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromAnyPedImpact = 89,
> 	CPED_CONFIG_FLAG_GroupPedFailedToEnterCover = 90,
> 	CPED_CONFIG_FLAG_AlreadyChattedOnPhone = 91,
> 	CPED_CONFIG_FLAG_AlreadyReactedToPedOnRoof = 92,
> 	CPED_CONFIG_FLAG_ForcePedLoadCover = 93,
> 	CPED_CONFIG_FLAG_BlockCoweringInCover = 94,
> 	CPED_CONFIG_FLAG_BlockPeekingInCover = 95,
> 	CPED_CONFIG_FLAG_JustLeftCarNotCheckedForDoors = 96,
> 	CPED_CONFIG_FLAG_VaultFromCover = 97,
> 	CPED_CONFIG_FLAG_AutoConversationLookAts = 98,
> 	CPED_CONFIG_FLAG_UsingCrouchedPedCapsule = 99,
> 	CPED_CONFIG_FLAG_HasDeadPedBeenReported = 100,
> 	CPED_CONFIG_FLAG_ForcedAim = 101,
> 	CPED_CONFIG_FLAG_SteersAroundPeds = 102,
> 	CPED_CONFIG_FLAG_SteersAroundObjects = 103,
> 	CPED_CONFIG_FLAG_OpenDoorArmIK = 104,
> 	CPED_CONFIG_FLAG_ForceReload = 105,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromVehicleImpact = 106,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromBulletImpact = 107,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromExplosions = 108,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromFire = 109,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromElectrocution = 110,
> 	CPED_CONFIG_FLAG_IsBeingDraggedToSafety = 111,
> 	CPED_CONFIG_FLAG_HasBeenDraggedToSafety = 112,
> 	CPED_CONFIG_FLAG_KeepWeaponHolsteredUnlessFired = 113,
> 	CPED_CONFIG_FLAG_ForceScriptControlledKnockout = 114,
> 	CPED_CONFIG_FLAG_FallOutOfVehicleWhenKilled = 115,
> 	CPED_CONFIG_FLAG_GetOutBurningVehicle = 116,
> 	CPED_CONFIG_FLAG_BumpedByPlayer = 117,
> 	CPED_CONFIG_FLAG_RunFromFiresAndExplosions = 118,
> 	CPED_CONFIG_FLAG_TreatAsPlayerDuringTargeting = 119,
> 	CPED_CONFIG_FLAG_IsHandCuffed = 120,
> 	CPED_CONFIG_FLAG_IsAnkleCuffed = 121,
> 	CPED_CONFIG_FLAG_DisableMelee = 122,
> 	CPED_CONFIG_FLAG_DisableUnarmedDrivebys = 123,
> 	CPED_CONFIG_FLAG_JustGetsPulledOutWhenElectrocuted = 124,
> 	CPED_CONFIG_FLAG_UNUSED_REPLACE_ME = 125,
> 	CPED_CONFIG_FLAG_WillNotHotwireLawEnforcementVehicle = 126,
> 	CPED_CONFIG_FLAG_WillCommandeerRatherThanJack = 127,
> 	CPED_CONFIG_FLAG_CanBeAgitated = 128,
> 	CPED_CONFIG_FLAG_ForcePedToFaceLeftInCover = 129,
> 	CPED_CONFIG_FLAG_ForcePedToFaceRightInCover = 130,
> 	CPED_CONFIG_FLAG_BlockPedFromTurningInCover = 131,
> 	CPED_CONFIG_FLAG_KeepRelationshipGroupAfterCleanUp = 132,
> 	CPED_CONFIG_FLAG_ForcePedToBeDragged = 133,
> 	CPED_CONFIG_FLAG_PreventPedFromReactingToBeingJacked = 134,
> 	CPED_CONFIG_FLAG_IsScuba = 135,
> 	CPED_CONFIG_FLAG_WillArrestRatherThanJack = 136,
> 	CPED_CONFIG_FLAG_RemoveDeadExtraFarAway = 137,
> 	CPED_CONFIG_FLAG_RidingTrain = 138,
> 	CPED_CONFIG_FLAG_ArrestResult = 139,
> 	CPED_CONFIG_FLAG_CanAttackFriendly = 140,
> 	CPED_CONFIG_FLAG_WillJackAnyPlayer = 141,
> 	CPED_CONFIG_FLAG_BumpedByPlayerVehicle = 142,
> 	CPED_CONFIG_FLAG_DodgedPlayerVehicle = 143,
> 	CPED_CONFIG_FLAG_WillJackWantedPlayersRatherThanStealCar = 144,
> 	CPED_CONFIG_FLAG_NoCopWantedAggro = 145,
> 	CPED_CONFIG_FLAG_DisableLadderClimbing = 146,
> 	CPED_CONFIG_FLAG_StairsDetected = 147,
> 	CPED_CONFIG_FLAG_SlopeDetected = 148,
> 	CPED_CONFIG_FLAG_HelmetHasBeenShot = 149,
> 	CPED_CONFIG_FLAG_CowerInsteadOfFlee = 150,
> 	CPED_CONFIG_FLAG_CanActivateRagdollWhenVehicleUpsideDown = 151,
> 	CPED_CONFIG_FLAG_AlwaysRespondToCriesForHelp = 152,
> 	CPED_CONFIG_FLAG_DisableBloodPoolCreation = 153,
> 	CPED_CONFIG_FLAG_ShouldFixIfNoCollision = 154,
> 	CPED_CONFIG_FLAG_CanPerformArrest = 155,
> 	CPED_CONFIG_FLAG_CanPerformUncuff = 156,
> 	CPED_CONFIG_FLAG_CanBeArrested = 157,
> 	CPED_CONFIG_FLAG_MoverConstrictedByOpposingCollisions = 158,
> 	CPED_CONFIG_FLAG_PlayerPreferFrontSeatMP = 159,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromImpactObject = 160,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromMelee = 161,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromWaterJet = 162,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromDrowning = 163,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromFalling = 164,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromRubberBullet = 165,
> 	CPED_CONFIG_FLAG_IsInjured = 166,
> 	CPED_CONFIG_FLAG_DontEnterVehiclesInPlayersGroup = 167,
> 	CPED_CONFIG_FLAG_SwimmingTasksRunning = 168,
> 	CPED_CONFIG_FLAG_PreventAllMeleeTaunts = 169,
> 	CPED_CONFIG_FLAG_ForceDirectEntry = 170,
> 	CPED_CONFIG_FLAG_AlwaysSeeApproachingVehicles = 171,
> 	CPED_CONFIG_FLAG_CanDiveAwayFromApproachingVehicles = 172,
> 	CPED_CONFIG_FLAG_AllowPlayerToInterruptVehicleEntryExit = 173,
> 	CPED_CONFIG_FLAG_OnlyAttackLawIfPlayerIsWanted = 174,
> 	CPED_CONFIG_FLAG_PlayerInContactWithKinematicPed = 175,
> 	CPED_CONFIG_FLAG_PlayerInContactWithSomethingOtherThanKinematicPed = 176,
> 	CPED_CONFIG_FLAG_PedsJackingMeDontGetIn = 177,
> 	CPED_CONFIG_FLAG_AdditionalRappellingPed = 178,
> 	CPED_CONFIG_FLAG_PedIgnoresAnimInterruptEvents = 179,
> 	CPED_CONFIG_FLAG_IsInCustody = 180,
> 	CPED_CONFIG_FLAG_ForceStandardBumpReactionThresholds = 181,
> 	CPED_CONFIG_FLAG_LawWillOnlyAttackIfPlayerIsWanted = 182,
> 	CPED_CONFIG_FLAG_IsAgitated = 183,
> 	CPED_CONFIG_FLAG_PreventAutoShuffleToDriversSeat = 184,
> 	CPED_CONFIG_FLAG_UseKinematicModeWhenStationary = 185,
> 	CPED_CONFIG_FLAG_EnableWeaponBlocking = 186,
> 	CPED_CONFIG_FLAG_HasHurtStarted = 187,
> 	CPED_CONFIG_FLAG_DisableHurt = 188,
> 	CPED_CONFIG_FLAG_PlayerIsWeird = 189,
> 	CPED_CONFIG_FLAG_PedHadPhoneConversation = 190,
> 	CPED_CONFIG_FLAG_BeganCrossingRoad = 191,
> 	CPED_CONFIG_FLAG_WarpIntoLeadersVehicle = 192,
> 	CPED_CONFIG_FLAG_DoNothingWhenOnFootByDefault = 193,
> 	CPED_CONFIG_FLAG_UsingScenario = 194,
> 	CPED_CONFIG_FLAG_VisibleOnScreen = 195,
> 	CPED_CONFIG_FLAG_DontCollideWithKinematic = 196,
> 	CPED_CONFIG_FLAG_ActivateOnSwitchFromLowPhysicsLod = 197,
> 	CPED_CONFIG_FLAG_DontActivateRagdollOnPedCollisionWhenDead = 198,
> 	CPED_CONFIG_FLAG_DontActivateRagdollOnVehicleCollisionWhenDead = 199,
> 	CPED_CONFIG_FLAG_HasBeenInArmedCombat = 200,
> 	CPED_CONFIG_FLAG_UseDiminishingAmmoRate = 201,
> 	CPED_CONFIG_FLAG_Avoidance_Ignore_All = 202,
> 	CPED_CONFIG_FLAG_Avoidance_Ignored_by_All = 203,
> 	CPED_CONFIG_FLAG_Avoidance_Ignore_Group1 = 204,
> 	CPED_CONFIG_FLAG_Avoidance_Member_of_Group1 = 205,
> 	CPED_CONFIG_FLAG_ForcedToUseSpecificGroupSeatIndex = 206,
> 	CPED_CONFIG_FLAG_LowPhysicsLodMayPlaceOnNavMesh = 207,
> 	CPED_CONFIG_FLAG_DisableExplosionReactions = 208,
> 	CPED_CONFIG_FLAG_DodgedPlayer = 209,
> 	CPED_CONFIG_FLAG_WaitingForPlayerControlInterrupt = 210,
> 	CPED_CONFIG_FLAG_ForcedToStayInCover = 211,
> 	CPED_CONFIG_FLAG_GeneratesSoundEvents = 212,
> 	CPED_CONFIG_FLAG_ListensToSoundEvents = 213,
> 	CPED_CONFIG_FLAG_AllowToBeTargetedInAVehicle = 214,
> 	CPED_CONFIG_FLAG_WaitForDirectEntryPointToBeFreeWhenExiting = 215,
> 	CPED_CONFIG_FLAG_OnlyRequireOnePressToExitVehicle = 216,
> 	CPED_CONFIG_FLAG_ForceExitToSkyDive = 217,
> 	CPED_CONFIG_FLAG_SteersAroundVehicles = 218,
> 	CPED_CONFIG_FLAG_AllowPedInVehiclesOverrideTaskFlags = 219,
> 	CPED_CONFIG_FLAG_DontEnterLeadersVehicle = 220,
> 	CPED_CONFIG_FLAG_DisableExitToSkyDive = 221,
> 	CPED_CONFIG_FLAG_ScriptHasDisabledCollision = 222,
> 	CPED_CONFIG_FLAG_UseAmbientModelScaling = 223,
> 	CPED_CONFIG_FLAG_DontWatchFirstOnNextHurryAway = 224,
> 	CPED_CONFIG_FLAG_DisablePotentialToBeWalkedIntoResponse = 225,
> 	CPED_CONFIG_FLAG_DisablePedAvoidance = 226,
> 	CPED_CONFIG_FLAG_ForceRagdollUponDeath = 227,
> 	CPED_CONFIG_FLAG_CanLosePropsOnDamage = 228,
> 	CPED_CONFIG_FLAG_DisablePanicInVehicle = 229,
> 	CPED_CONFIG_FLAG_AllowedToDetachTrailer = 230,
> 	CPED_CONFIG_FLAG_HasShotBeenReactedToFromFront = 231,
> 	CPED_CONFIG_FLAG_HasShotBeenReactedToFromBack = 232,
> 	CPED_CONFIG_FLAG_HasShotBeenReactedToFromLeft = 233,
> 	CPED_CONFIG_FLAG_HasShotBeenReactedToFromRight = 234,
> 	CPED_CONFIG_FLAG_AllowBlockDeadPedRagdollActivation = 235,
> 	CPED_CONFIG_FLAG_IsHoldingProp = 236,
> 	CPED_CONFIG_FLAG_BlocksPathingWhenDead = 237,
> 	CPED_CONFIG_FLAG_ForcePlayNormalScenarioExitOnNextScriptCommand = 238,
> 	CPED_CONFIG_FLAG_ForcePlayImmediateScenarioExitOnNextScriptCommand = 239,
> 	CPED_CONFIG_FLAG_ForceSkinCharacterCloth = 240,
> 	CPED_CONFIG_FLAG_LeaveEngineOnWhenExitingVehicles = 241,
> 	CPED_CONFIG_FLAG_PhoneDisableTextingAnimations = 242,
> 	CPED_CONFIG_FLAG_PhoneDisableTalkingAnimations = 243,
> 	CPED_CONFIG_FLAG_PhoneDisableCameraAnimations = 244,
> 	CPED_CONFIG_FLAG_DisableBlindFiringInShotReactions = 245,
> 	CPED_CONFIG_FLAG_AllowNearbyCoverUsage = 246,
> 	CPED_CONFIG_FLAG_InStrafeTransition = 247,
> 	CPED_CONFIG_FLAG_CanPlayInCarIdles = 248,
> 	CPED_CONFIG_FLAG_CanAttackNonWantedPlayerAsLaw = 249,
> 	CPED_CONFIG_FLAG_WillTakeDamageWhenVehicleCrashes = 250,
> 	CPED_CONFIG_FLAG_AICanDrivePlayerAsRearPassenger = 251,
> 	CPED_CONFIG_FLAG_PlayerCanJackFriendlyPlayers = 252,
> 	CPED_CONFIG_FLAG_OnStairs = 253,
> 	CPED_CONFIG_FLAG_SimulatingAiming = 254,
> 	CPED_CONFIG_FLAG_AIDriverAllowFriendlyPassengerSeatEntry = 255,
> 	CPED_CONFIG_FLAG_ParentCarIsBeingRemoved = 256,
> 	CPED_CONFIG_FLAG_AllowMissionPedToUseInjuredMovement = 257,
> 	CPED_CONFIG_FLAG_CanLoseHelmetOnDamage = 258,
> 	CPED_CONFIG_FLAG_NeverDoScenarioExitProbeChecks = 259,
> 	CPED_CONFIG_FLAG_SuppressLowLODRagdollSwitchWhenCorpseSettles = 260,
> 	CPED_CONFIG_FLAG_PreventUsingLowerPrioritySeats = 261,
> 	CPED_CONFIG_FLAG_JustLeftVehicleNeedsReset = 262,
> 	CPED_CONFIG_FLAG_TeleportIfCantReachPlayer = 263,
> 	CPED_CONFIG_FLAG_PedsInVehiclePositionNeedsReset = 264,
> 	CPED_CONFIG_FLAG_PedsFullyInSeat = 265,
> 	CPED_CONFIG_FLAG_AllowPlayerLockOnIfFriendly = 266,
> 	CPED_CONFIG_FLAG_UseCameraHeadingForDesiredDirectionLockOnTest = 267,
> 	CPED_CONFIG_FLAG_TeleportToLeaderVehicle = 268,
> 	CPED_CONFIG_FLAG_Avoidance_Ignore_WeirdPedBuffer = 269,
> 	CPED_CONFIG_FLAG_OnStairSlope = 270,
> 	CPED_CONFIG_FLAG_HasPlayedNMGetup = 271,
> 	CPED_CONFIG_FLAG_DontBlipCop = 272,
> 	CPED_CONFIG_FLAG_SpawnedAtExtendedRangeScenario = 273,
> 	CPED_CONFIG_FLAG_WalkAlongsideLeaderWhenClose = 274,
> 	CPED_CONFIG_FLAG_KillWhenTrapped = 275,
> 	CPED_CONFIG_FLAG_EdgeDetected = 276,
> 	CPED_CONFIG_FLAG_AlwaysWakeUpPhysicsOfIntersectedPeds = 277,
> 	CPED_CONFIG_FLAG_EquippedAmbientLoadOutWeapon = 278,
> 	CPED_CONFIG_FLAG_AvoidTearGas = 279,
> 	CPED_CONFIG_FLAG_StoppedSpeechUponFreezing = 280,
> 	CPED_CONFIG_FLAG_DisableGoToWritheWhenInjured = 281,
> 	CPED_CONFIG_FLAG_OnlyUseForcedSeatWhenEnteringHeliInGroup = 282,
> 	CPED_CONFIG_FLAG_ThrownFromVehicleDueToExhaustion = 283,
> 	CPED_CONFIG_FLAG_UpdateEnclosedSearchRegion = 284,
> 	CPED_CONFIG_FLAG_DisableWeirdPedEvents = 285,
> 	CPED_CONFIG_FLAG_ShouldChargeNow = 286,
> 	CPED_CONFIG_FLAG_RagdollingOnBoat = 287,
> 	CPED_CONFIG_FLAG_HasBrandishedWeapon = 288,
> 	CPED_CONFIG_FLAG_AllowMinorReactionsAsMissionPed = 289,
> 	CPED_CONFIG_FLAG_BlockDeadBodyShockingEventsWhenDead = 290,
> 	CPED_CONFIG_FLAG_PedHasBeenSeen = 291,
> 	CPED_CONFIG_FLAG_PedIsInReusePool = 292,
> 	CPED_CONFIG_FLAG_PedWasReused = 293,
> 	CPED_CONFIG_FLAG_DisableShockingEvents = 294,
> 	CPED_CONFIG_FLAG_MovedUsingLowLodPhysicsSinceLastActive = 295,
> 	CPED_CONFIG_FLAG_NeverReactToPedOnRoof = 296,
> 	CPED_CONFIG_FLAG_ForcePlayFleeScenarioExitOnNextScriptCommand = 297,
> 	CPED_CONFIG_FLAG_JustBumpedIntoVehicle = 298,
> 	CPED_CONFIG_FLAG_DisableShockingDrivingOnPavementEvents = 299,
> 	CPED_CONFIG_FLAG_ShouldThrowSmokeNow = 300,
> 	CPED_CONFIG_FLAG_DisablePedConstraints = 301,
> 	CPED_CONFIG_FLAG_ForceInitialPeekInCover = 302,
> 	CPED_CONFIG_FLAG_CreatedByDispatch = 303,
> 	CPED_CONFIG_FLAG_PointGunLeftHandSupporting = 304,
> 	CPED_CONFIG_FLAG_DisableJumpingFromVehiclesAfterLeader = 305,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromPlayerPedImpact = 306,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromAiRagdollImpact = 307,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromPlayerRagdollImpact = 308,
> 	CPED_CONFIG_FLAG_DisableQuadrupedSpring = 309,
> 	CPED_CONFIG_FLAG_IsInCluster = 310,
> 	CPED_CONFIG_FLAG_ShoutToGroupOnPlayerMelee = 311,
> 	CPED_CONFIG_FLAG_IgnoredByAutoOpenDoors = 312,
> 	CPED_CONFIG_FLAG_PreferInjuredGetup = 313,
> 	CPED_CONFIG_FLAG_ForceIgnoreMeleeActiveCombatant = 314,
> 	CPED_CONFIG_FLAG_CheckLoSForSoundEvents = 315,
> 	CPED_CONFIG_FLAG_JackedAbandonedCar = 316,
> 	CPED_CONFIG_FLAG_CanSayFollowedByPlayerAudio = 317,
> 	CPED_CONFIG_FLAG_ActivateRagdollFromMinorPlayerContact = 318,
> 	CPED_CONFIG_FLAG_HasPortablePickupAttached = 319,
> 	CPED_CONFIG_FLAG_ForcePoseCharacterCloth = 320,
> 	CPED_CONFIG_FLAG_HasClothCollisionBounds = 321,
> 	CPED_CONFIG_FLAG_HasHighHeels = 322,
> 	CPED_CONFIG_FLAG_TreatAsAmbientPedForDriverLockOn = 323,
> 	CPED_CONFIG_FLAG_DontBehaveLikeLaw = 324,
> 	CPED_CONFIG_FLAG_SpawnedAtScenario = 325,
> 	CPED_CONFIG_FLAG_DisablePoliceInvestigatingBody = 326,
> 	CPED_CONFIG_FLAG_DisableWritheShootFromGround = 327,
> 	CPED_CONFIG_FLAG_LowerPriorityOfWarpSeats = 328,
> 	CPED_CONFIG_FLAG_DisableTalkTo = 329,
> 	CPED_CONFIG_FLAG_DontBlip = 330,
> 	CPED_CONFIG_FLAG_IsSwitchingWeapon = 331,
> 	CPED_CONFIG_FLAG_IgnoreLegIkRestrictions = 332,
> 	CPED_CONFIG_FLAG_ScriptForceNoTimesliceIntelligenceUpdate = 333,
> 	CPED_CONFIG_FLAG_JackedOutOfMyVehicle = 334,
> 	CPED_CONFIG_FLAG_WentIntoCombatAfterBeingJacked = 335,
> 	CPED_CONFIG_FLAG_DontActivateRagdollForVehicleGrab = 336,
> 	CPED_CONFIG_FLAG_ForcePackageCharacterCloth = 337,
> 	CPED_CONFIG_FLAG_DontRemoveWithValidOrder = 338,
> 	CPED_CONFIG_FLAG_AllowTaskDoNothingTimeslicing = 339,
> 	CPED_CONFIG_FLAG_ForcedToStayInCoverDueToPlayerSwitch = 340,
> 	CPED_CONFIG_FLAG_ForceProneCharacterCloth = 341,
> 	CPED_CONFIG_FLAG_NotAllowedToJackAnyPlayers = 342,
> 	CPED_CONFIG_FLAG_InToStrafeTransition = 343,
> 	CPED_CONFIG_FLAG_KilledByStandardMelee = 344,
> 	CPED_CONFIG_FLAG_AlwaysLeaveTrainUponArrival = 345,
> 	CPED_CONFIG_FLAG_ForcePlayDirectedNormalScenarioExitOnNextScriptCommand = 346,
> 	CPED_CONFIG_FLAG_OnlyWritheFromWeaponDamage = 347,
> 	CPED_CONFIG_FLAG_UseSloMoBloodVfx = 348,
> 	CPED_CONFIG_FLAG_EquipJetpack = 349,
> 	CPED_CONFIG_FLAG_PreventDraggedOutOfCarThreatResponse = 350,
> 	CPED_CONFIG_FLAG_ScriptHasCompletelyDisabledCollision = 351,
> 	CPED_CONFIG_FLAG_NeverDoScenarioNavChecks = 352,
> 	CPED_CONFIG_FLAG_ForceSynchronousScenarioExitChecking = 353,
> 	CPED_CONFIG_FLAG_ThrowingGrenadeWhileAiming = 354,
> 	CPED_CONFIG_FLAG_HeadbobToRadioEnabled = 355,
> 	CPED_CONFIG_FLAG_ForceDeepSurfaceCheck = 356,
> 	CPED_CONFIG_FLAG_DisableDeepSurfaceAnims = 357,
> 	CPED_CONFIG_FLAG_DontBlipNotSynced = 358,
> 	CPED_CONFIG_FLAG_IsDuckingInVehicle = 359,
> 	CPED_CONFIG_FLAG_PreventAutoShuffleToTurretSeat = 360,
> 	CPED_CONFIG_FLAG_DisableEventInteriorStatusCheck = 361,
> 	CPED_CONFIG_FLAG_HasReserveParachute = 362,
> 	CPED_CONFIG_FLAG_UseReserveParachute = 363,
> 	CPED_CONFIG_FLAG_TreatDislikeAsHateWhenInCombat = 364,
> 	CPED_CONFIG_FLAG_OnlyUpdateTargetWantedIfSeen = 365,
> 	CPED_CONFIG_FLAG_AllowAutoShuffleToDriversSeat = 366,
> 	CPED_CONFIG_FLAG_DontActivateRagdollFromSmokeGrenade = 367,
> 	CPED_CONFIG_FLAG_LinkMBRToOwnerOnChain = 368,
> 	CPED_CONFIG_FLAG_AmbientFriendBumpedByPlayer = 369,
> 	CPED_CONFIG_FLAG_AmbientFriendBumpedByPlayerVehicle = 370,
> 	CPED_CONFIG_FLAG_InFPSUnholsterTransition = 371,
> 	CPED_CONFIG_FLAG_PreventReactingToSilencedCloneBullets = 372,
> 	CPED_CONFIG_FLAG_DisableInjuredCryForHelpEvents = 373,
> 	CPED_CONFIG_FLAG_NeverLeaveTrain = 374,
> 	CPED_CONFIG_FLAG_DontDropJetpackOnDeath = 375,
> 	CPED_CONFIG_FLAG_UseFPSUnholsterTransitionDuringCombatRoll = 376,
> 	CPED_CONFIG_FLAG_ExitingFPSCombatRoll = 377,
> 	CPED_CONFIG_FLAG_ScriptHasControlOfPlayer = 378,
> 	CPED_CONFIG_FLAG_PlayFPSIdleFidgetsForProjectile = 379,
> 	CPED_CONFIG_FLAG_DisableAutoEquipHelmetsInBikes = 380,
> 	CPED_CONFIG_FLAG_DisableAutoEquipHelmetsInAircraft = 381,
> 	CPED_CONFIG_FLAG_WasPlayingFPSGetup = 382,
> 	CPED_CONFIG_FLAG_WasPlayingFPSMeleeActionResult = 383,
> 	CPED_CONFIG_FLAG_PreferNoPriorityRemoval = 384,
> 	CPED_CONFIG_FLAG_FPSFidgetsAbortedOnFire = 385,
> 	CPED_CONFIG_FLAG_ForceFPSIKWithUpperBodyAnim = 386,
> 	CPED_CONFIG_FLAG_SwitchingCharactersInFirstPerson = 387,
> 	CPED_CONFIG_FLAG_IsClimbingLadder = 388,
> 	CPED_CONFIG_FLAG_HasBareFeet = 389,
> 	CPED_CONFIG_FLAG_UNUSED_REPLACE_ME_2 = 390,
> 	CPED_CONFIG_FLAG_GoOnWithoutVehicleIfItIsUnableToGetBackToRoad = 391,
> 	CPED_CONFIG_FLAG_BlockDroppingHealthSnacksOnDeath = 392,
> 	CPED_CONFIG_FLAG_ResetLastVehicleOnVehicleExit = 393,
> 	CPED_CONFIG_FLAG_ForceThreatResponseToNonFriendToFriendMeleeActions = 394,
> 	CPED_CONFIG_FLAG_DontRespondToRandomPedsDamage = 395,
> 	CPED_CONFIG_FLAG_AllowContinuousThreatResponseWantedLevelUpdates = 396,
> 	CPED_CONFIG_FLAG_KeepTargetLossResponseOnCleanup = 397,
> 	CPED_CONFIG_FLAG_PlayersDontDragMeOutOfCar = 398,
> 	CPED_CONFIG_FLAG_BroadcastRepondedToThreatWhenGoingToPointShooting = 399,
> 	CPED_CONFIG_FLAG_IgnorePedTypeForIsFriendlyWith = 400,
> 	CPED_CONFIG_FLAG_TreatNonFriendlyAsHateWhenInCombat = 401,
> 	CPED_CONFIG_FLAG_DontLeaveVehicleIfLeaderNotInVehicle = 402,
> 	CPED_CONFIG_FLAG_ChangeFromPermanentToAmbientPopTypeOnMigration = 403,
> 	CPED_CONFIG_FLAG_AllowMeleeReactionIfMeleeProofIsOn = 404,
> 	CPED_CONFIG_FLAG_UsingLowriderLeans = 405,
> 	CPED_CONFIG_FLAG_UsingAlternateLowriderLeans = 406,
> 	CPED_CONFIG_FLAG_UseNormalExplosionDamageWhenBlownUpInVehicle = 407,
> 	CPED_CONFIG_FLAG_DisableHomingMissileLockForVehiclePedInside = 408,
> 	CPED_CONFIG_FLAG_DisableTakeOffScubaGear = 409,
> 	CPED_CONFIG_FLAG_IgnoreMeleeFistWeaponDamageMult = 410,
> 	CPED_CONFIG_FLAG_LawPedsCanFleeFromNonWantedPlayer = 411,
> 	CPED_CONFIG_FLAG_ForceBlipSecurityPedsIfPlayerIsWanted = 412,
> 	CPED_CONFIG_FLAG_IsHolsteringWeapon = 413,
> 	CPED_CONFIG_FLAG_UseGoToPointForScenarioNavigation = 414,
> 	CPED_CONFIG_FLAG_DontClearLocalPassengersWantedLevel = 415,
> 	CPED_CONFIG_FLAG_BlockAutoSwapOnWeaponPickups = 416,
> 	CPED_CONFIG_FLAG_ThisPedIsATargetPriorityForAI = 417,
> 	CPED_CONFIG_FLAG_IsSwitchingHelmetVisor = 418,
> 	CPED_CONFIG_FLAG_ForceHelmetVisorSwitch = 419,
> 	CPED_CONFIG_FLAG_IsPerformingVehicleMelee = 420,
> 	CPED_CONFIG_FLAG_UseOverrideFootstepPtFx = 421,
> 	CPED_CONFIG_FLAG_DisableVehicleCombat = 422,
> 	CPED_CONFIG_FLAG_TreatAsFriendlyForTargetingAndDamage = 423,
> 	CPED_CONFIG_FLAG_AllowBikeAlternateAnimations = 424,
> 	CPED_CONFIG_FLAG_TreatAsFriendlyForTargetingAndDamageNonSynced = 425,
> 	CPED_CONFIG_FLAG_UseLockpickVehicleEntryAnimations = 426,
> 	CPED_CONFIG_FLAG_IgnoreInteriorCheckForSprinting = 427,
> 	CPED_CONFIG_FLAG_SwatHeliSpawnWithinLastSpottedLocation = 428,
> 	CPED_CONFIG_FLAG_DisableStartEngine = 429,
> 	CPED_CONFIG_FLAG_IgnoreBeingOnFire = 430,
> 	CPED_CONFIG_FLAG_DisableTurretOrRearSeatPreference = 431,
> 	CPED_CONFIG_FLAG_DisableWantedHelicopterSpawning = 432,
> 	CPED_CONFIG_FLAG_UseTargetPerceptionForCreatingAimedAtEvents = 433,
> 	CPED_CONFIG_FLAG_DisableHomingMissileLockon = 434,
> 	CPED_CONFIG_FLAG_ForceIgnoreMaxMeleeActiveSupportCombatants = 435,
> 	CPED_CONFIG_FLAG_StayInDefensiveAreaWhenInVehicle = 436,
> 	CPED_CONFIG_FLAG_DontShoutTargetPosition = 437,
> 	CPED_CONFIG_FLAG_DisableHelmetArmor = 438,
> 	CPED_CONFIG_FLAG_CreatedByConcealedPlayer = 439,
> 	CPED_CONFIG_FLAG_PermanentlyDisablePotentialToBeWalkedIntoResponse = 440,
> 	CPED_CONFIG_FLAG_PreventVehExitDueToInvalidWeapon = 441,
> 	CPED_CONFIG_FLAG_IgnoreNetSessionFriendlyFireCheckForAllowDamage = 442,
> 	CPED_CONFIG_FLAG_DontLeaveCombatIfTargetPlayerIsAttackedByPolice = 443,
> 	CPED_CONFIG_FLAG_CheckLockedBeforeWarp = 444,
> 	CPED_CONFIG_FLAG_DontShuffleInVehicleToMakeRoom = 445,
> 	CPED_CONFIG_FLAG_GiveWeaponOnGetup = 446,
> 	CPED_CONFIG_FLAG_DontHitVehicleWithProjectiles = 447,
> 	CPED_CONFIG_FLAG_DisableForcedEntryForOpenVehiclesFromTryLockedDoor = 448,
> 	CPED_CONFIG_FLAG_FiresDummyRockets = 449,
> 	CPED_CONFIG_FLAG_PedIsArresting = 450,
> 	CPED_CONFIG_FLAG_IsDecoyPed = 451,
> 	CPED_CONFIG_FLAG_HasEstablishedDecoy = 452,
> 	CPED_CONFIG_FLAG_BlockDispatchedHelicoptersFromLanding = 453,
> 	CPED_CONFIG_FLAG_DontCryForHelpOnStun = 454,
> 	CPED_CONFIG_FLAG_HitByTranqWeapon = 455,
> 	CPED_CONFIG_FLAG_CanBeIncapacitated = 456,
> 	CPED_CONFIG_FLAG_ForcedAimFromArrest = 457,
> 	CPED_CONFIG_FLAG_DontChangeTargetFromMelee = 458,
> 	CPED_CONFIG_FLAG_DisableHealthRegenerationWhenStunned = 459,
> 	CPED_CONFIG_FLAG_RagdollFloatsIndefinitely = 460,
> 	CPED_CONFIG_FLAG_BlockElectricWeaponDamage = 461,
> 	_0x262A3B8E = 462,
> 	_0x1AA79A25 = 463,
> 	_0x92293319 = 464,
> 	_0x8E997FDA = 465,
> 	_0x32EB48DC = 466,
> 	_0x760B91AE = 467,
> };

## SET_PED_COORDS_KEEP_VEHICLE

```c
void SET_PED_COORDS_KEEP_VEHICLE(Ped ped, float posX, float posY, float posZ)  // 0x9AFEFF481A85AB2E
```

build 323

> teleports ped to coords along with the vehicle ped is in

## SET_PED_COORDS_NO_GANG

```c
void SET_PED_COORDS_NO_GANG(Ped ped, float posX, float posY, float posZ)  // 0x87052FE446E07247
```

build 323

## SET_PED_COWER_HASH

```c
void SET_PED_COWER_HASH(Ped ped, const char* p1)  // 0xA549131166868ED3
```

build 323

> p1: Only "CODE_HUMAN_STAND_COWER" found in the b617d scripts.

## SET_PED_DEFAULT_COMPONENT_VARIATION

```c
void SET_PED_DEFAULT_COMPONENT_VARIATION(Ped ped)  // 0x45EEE61580806D63
```

build 323

> Sets Ped Default Clothes

## SET_PED_DEFENSIVE_AREA_ATTACHED_TO_PED

```c
void SET_PED_DEFENSIVE_AREA_ATTACHED_TO_PED(Ped ped, Ped attachPed, float p2, float p3, float p4, float p5, float p6, float p7, float p8, BOOL p9, BOOL p10)  // 0x4EF47FE21698A8B6
```

build 323

## SET_PED_DEFENSIVE_AREA_DIRECTION

```c
void SET_PED_DEFENSIVE_AREA_DIRECTION(Ped ped, float p1, float p2, float p3, BOOL p4)  // 0x413C6C763A4AFFAD
```

build 323

## SET_PED_DEFENSIVE_SPHERE_ATTACHED_TO_PED

```c
void SET_PED_DEFENSIVE_SPHERE_ATTACHED_TO_PED(Ped ped, Ped target, float xOffset, float yOffset, float zOffset, float radius, BOOL p6)  // 0xF9B8F91AAD3B953E
```

build 323

## SET_PED_DEFENSIVE_SPHERE_ATTACHED_TO_VEHICLE

```c
void SET_PED_DEFENSIVE_SPHERE_ATTACHED_TO_VEHICLE(Ped ped, Vehicle target, float xOffset, float yOffset, float zOffset, float radius, BOOL p6)  // 0xE4723DB6E736CCFF
```

build 323

## SET_PED_DENSITY_MULTIPLIER_THIS_FRAME

```c
void SET_PED_DENSITY_MULTIPLIER_THIS_FRAME(float multiplier)  // 0x95E3D6257B166CF2
```

build 323

## SET_PED_DESIRED_HEADING

```c
void SET_PED_DESIRED_HEADING(Ped ped, float heading)  // 0xAA5A7ECE2AA8FE70
```

build 323

## SET_PED_DIES_IN_SINKING_VEHICLE

```c
void SET_PED_DIES_IN_SINKING_VEHICLE(Ped ped, BOOL toggle)  // 0xD718A22995E2B4BC
```

build 323

## SET_PED_DIES_IN_VEHICLE

```c
void SET_PED_DIES_IN_VEHICLE(Ped ped, BOOL toggle)  // 0x2A30922C90C9B42C
```

build 323

## SET_PED_DIES_IN_WATER

```c
void SET_PED_DIES_IN_WATER(Ped ped, BOOL toggle)  // 0x56CEF0AC79073BDE
```

build 323

## SET_PED_DIES_INSTANTLY_IN_WATER

```c
void SET_PED_DIES_INSTANTLY_IN_WATER(Ped ped, BOOL toggle)  // 0xEEB64139BA29A7CF
```

build 323

## SET_PED_DIES_WHEN_INJURED

```c
void SET_PED_DIES_WHEN_INJURED(Ped ped, BOOL toggle)  // 0x5BA7919BED300023
```

build 323

## SET_PED_DRIVE_BY_CLIPSET_OVERRIDE

```c
void SET_PED_DRIVE_BY_CLIPSET_OVERRIDE(Ped ped, const char* clipset)  // 0xED34AB6C5CB36520
```

build 323

## SET_PED_DUCKING

```c
void SET_PED_DUCKING(Ped ped, BOOL toggle)  // 0x030983CA930B692D
```

build 323

> This is the SET_CHAR_DUCKING from GTA IV, that makes Peds duck. This function does nothing in GTA V. It cannot set the ped as ducking in vehicles, and IS_PED_DUCKING will always return false.

## SET_PED_EMISSIVE_SCALE

```c
void SET_PED_EMISSIVE_SCALE(Ped ped, float intensity)  // 0x4E90D746056E273D
```

build 944 · old names: `_SET_PED_REFLECTION_INTENSITY`, `_SET_PED_ILLUMINATED_CLOTHING_GLOW_INTENSITY`, `_SET_PED_EMISSIVE_INTENSITY`

> intensity: 0.0f - 1.0f
> 
> This native sets the emissive intensity for the given ped. It is used for different 'glow' levels on illuminated clothing.

## SET_PED_ENABLE_CREW_EMBLEM

```c
void SET_PED_ENABLE_CREW_EMBLEM(Ped ped, BOOL toggle)  // 0xE906EC930F5FE7C8
```

build 791

## SET_PED_ENABLE_WEAPON_BLOCKING

```c
void SET_PED_ENABLE_WEAPON_BLOCKING(Ped ped, BOOL toggle)  // 0x97A790315D3831FD
```

build 323

## SET_PED_ENVEFF_COLOR_MODULATOR

```c
void SET_PED_ENVEFF_COLOR_MODULATOR(Ped ped, int p1, int p2, int p3)  // 0xD69411AA0CEBF9E9
```

build 323

> Something related to the environmental effects natives.
> In the "agency_heist3b" script, p1 - p3 are always under 100 - usually they are {87, 81, 68}. If SET_PED_ENVEFF_SCALE is set to 0.65 (instead of the usual 1.0), they use {74, 69, 60}

## SET_PED_ENVEFF_CPV_ADD

```c
void SET_PED_ENVEFF_CPV_ADD(Ped ped, float p1)  // 0x110F526AB784111F
```

build 323

> In agency_heist3b.c4, its like this 90% of the time:
> 
> PED::SET_PED_ENVEFF_CPV_ADD(ped, 0.099);
> PED::SET_PED_ENVEFF_SCALE(ped, 1.0);
> PED::SET_PED_ENVEFF_CPV_ADD(ped, 87, 81, 68);
> PED::SET_ENABLE_PED_ENVEFF_SCALE(ped, 1);
> 
> and its like this 10% of the time:
> 
> PED::SET_PED_ENVEFF_CPV_ADD(ped, 0.2);
> PED::SET_PED_ENVEFF_SCALE(ped, 0.65);
> PED::SET_PED_ENVEFF_COLOR_MODULATOR(ped, 74, 69, 60);
> PED::SET_ENABLE_PED_ENVEFF_SCALE(ped, 1);

## SET_PED_ENVEFF_SCALE

```c
void SET_PED_ENVEFF_SCALE(Ped ped, float value)  // 0xBF29516833893561
```

build 323

> Values look to be between 0.0 and 1.0
> From decompiled scripts: 0.0, 0.6, 0.65, 0.8, 1.0
> 
> You are correct, just looked in IDA it breaks from the function if it's less than 0.0f or greater than 1.0f.

## SET_PED_FIRING_PATTERN

```c
void SET_PED_FIRING_PATTERN(Ped ped, Hash patternHash)  // 0x9AC577F5A12AD8A9
```

build 323

> FIRING_PATTERN_BURST_FIRE = 0xD6FF6D61 ( 1073727030 )
> FIRING_PATTERN_BURST_FIRE_IN_COVER = 0x026321F1 ( 40051185 )
> FIRING_PATTERN_BURST_FIRE_DRIVEBY = 0xD31265F2 ( -753768974 )
> FIRING_PATTERN_FROM_GROUND = 0x2264E5D6 ( 577037782 )
> FIRING_PATTERN_DELAY_FIRE_BY_ONE_SEC = 0x7A845691 ( 2055493265 )
> FIRING_PATTERN_FULL_AUTO = 0xC6EE6B4C ( -957453492 )
> FIRING_PATTERN_SINGLE_SHOT = 0x5D60E4E0 ( 1566631136 )
> FIRING_PATTERN_BURST_FIRE_PISTOL = 0xA018DB8A ( -1608983670 )
> FIRING_PATTERN_BURST_FIRE_SMG = 0xD10DADEE ( 1863348768 )
> FIRING_PATTERN_BURST_FIRE_RIFLE = 0x9C74B406 ( -1670073338 )
> FIRING_PATTERN_BURST_FIRE_MG = 0xB573C5B4 ( -1250703948 )
> FIRING_PATTERN_BURST_FIRE_PUMPSHOTGUN = 0x00BAC39B ( 12239771 )
> FIRING_PATTERN_BURST_FIRE_HELI = 0x914E786F ( -1857128337 )
> FIRING_PATTERN_BURST_FIRE_MICRO = 0x42EF03FD ( 1122960381 )
> FIRING_PATTERN_SHORT_BURSTS = 0x1A92D7DF ( 445831135 )
> FIRING_PATTERN_SLOW_FIRE_TANK = 0xE2CA3A71 ( -490063247 )
> 
> Firing pattern info: https://pastebin.com/Px036isB

## SET_PED_FLEE_ATTRIBUTES

```c
void SET_PED_FLEE_ATTRIBUTES(Ped ped, int attributeFlags, BOOL enable)  // 0x70A2D1137C8ED7C9
```

build 323

> bit 1 (0x2) = use vehicle
> bit 15 (0x8000) = force cower

## SET_PED_GENERATES_DEAD_BODY_EVENTS

```c
void SET_PED_GENERATES_DEAD_BODY_EVENTS(Ped ped, BOOL toggle)  // 0x7FB17BA2E7DECA5B
```

build 323

## SET_PED_GESTURE_GROUP

```c
void SET_PED_GESTURE_GROUP(Ped ped, const char* animGroupGesture)  // 0xDDF803377F94AAA8
```

build 323

> From the scripts:
> PED::SET_PED_GESTURE_GROUP(PLAYER::PLAYER_PED_ID(),
> "ANIM_GROUP_GESTURE_MISS_FRA0");
> PED::SET_PED_GESTURE_GROUP(PLAYER::PLAYER_PED_ID(),
> "ANIM_GROUP_GESTURE_MISS_DocksSetup1");

## SET_PED_GET_OUT_UPSIDE_DOWN_VEHICLE

```c
void SET_PED_GET_OUT_UPSIDE_DOWN_VEHICLE(Ped ped, BOOL toggle)  // 0xBC0ED94165A48BC2
```

build 323

## SET_PED_GRAVITY

```c
void SET_PED_GRAVITY(Ped ped, BOOL toggle)  // 0x9FF447B6B6AD960A
```

build 323

> enable or disable the gravity of a ped
> 
> Examples:
> PED::SET_PED_GRAVITY(PLAYER::PLAYER_PED_ID(), 0x00000001);
> PED::SET_PED_GRAVITY(Local_289[iVar0 /*20*/], 0x00000001);

## SET_PED_GROUP_MEMBER_PASSENGER_INDEX

```c
void SET_PED_GROUP_MEMBER_PASSENGER_INDEX(Ped ped, int index)  // 0x0BDDB8D9EC6BCF3C
```

build 323

## SET_PED_HAIR_TINT

```c
void SET_PED_HAIR_TINT(Ped ped, int colorID, int highlightColorID)  // 0x4CFFC65454C93A49
```

build 323 · old names: `_SET_PED_HAIR_COLOR`

## SET_PED_HEAD_BLEND_DATA

```c
void SET_PED_HEAD_BLEND_DATA(Ped ped, int shapeFirstID, int shapeSecondID, int shapeThirdID, int skinFirstID, int skinSecondID, int skinThirdID, float shapeMix, float skinMix, float thirdMix, BOOL isParent)  // 0x9414E18B9434C2FE
```

build 323

> The "shape" parameters control the shape of the ped's face. The "skin" parameters control the skin tone. ShapeMix and skinMix control how much the first and second IDs contribute,(typically mother and father.) ThirdMix overrides the others in favor of the third IDs. IsParent is set for "children" of the player character's grandparents during old-gen character creation. It has unknown effect otherwise.
> 
> The IDs start at zero and go Male Non-DLC, Female Non-DLC, Male DLC, and Female DLC.
>        headBlendData headData;
>        GET_PED_HEAD_BLEND_DATA(PLAYER_PED_ID(), &headData);
> 
>        SET_PED_HEAD_BLEND_DATA(PLAYER_PED_ID(), headData.shapeFirst, headData.shapeSecond, headData.shapeThird, headData.skinFirst, headData.skinSecond
>           , headData.skinThird, headData.shapeMix, headData.skinMix, headData.skinThird, 0);
> 
> 
> For more info please refer to this topic. 
> https://gtaforums.com/topic/858970-all-gtao-face-ids-pedset-ped-head-blend-data-explained

## SET_PED_HEAD_OVERLAY

```c
void SET_PED_HEAD_OVERLAY(Ped ped, int overlayID, int index, float opacity)  // 0x48F44967FA05CC1E
```

build 323

> OverlayID ranges from 0 to 12, index from 0 to GET_PED_HEAD_OVERLAY_NUM(overlayID)-1, and opacity from 0.0 to 1.0. 
> 
> overlayID       Part                  Index, to disable
> 0               Blemishes             0 - 23, 255
> 1               Facial Hair           0 - 28, 255
> 2               Eyebrows              0 - 33, 255
> 3               Ageing                0 - 14, 255
> 4               Makeup                0 - 74, 255
> 5               Blush                 0 - 6, 255
> 6               Complexion            0 - 11, 255
> 7               Sun Damage            0 - 10, 255
> 8               Lipstick              0 - 9, 255
> 9               Moles/Freckles        0 - 17, 255
> 10              Chest Hair            0 - 16, 255
> 11              Body Blemishes        0 - 11, 255
> 12              Add Body Blemishes    0 - 1, 255

## SET_PED_HEAD_OVERLAY_TINT

```c
void SET_PED_HEAD_OVERLAY_TINT(Ped ped, int overlayID, int colorType, int colorID, int secondColorID)  // 0x497BF74A7B9CB952
```

build 323 · old names: `_SET_PED_HEAD_OVERLAY_COLOR`

> 
> 
> ColorType is 1 for eyebrows, beards, and chest hair; 2 for blush and lipstick; and 0 otherwise, though not called in those cases.
> 
> Called after SET_PED_HEAD_OVERLAY().

## SET_PED_HEALTH_PENDING_LAST_DAMAGE_EVENT_OVERRIDE_FLAG

```c
void SET_PED_HEALTH_PENDING_LAST_DAMAGE_EVENT_OVERRIDE_FLAG(BOOL toggle)  // 0xB3352E018D6F89DF
```

build 2699

## SET_PED_HEARING_RANGE

```c
void SET_PED_HEARING_RANGE(Ped ped, float value)  // 0x33A8F7F7D5F7F33C
```

build 323

## SET_PED_HEATSCALE_OVERRIDE

```c
void SET_PED_HEATSCALE_OVERRIDE(Ped ped, float heatScale)  // 0xC1F6EBF9A3D55538
```

build 323

## SET_PED_HELMET

```c
void SET_PED_HELMET(Ped ped, BOOL canWearHelmet)  // 0x560A43136EB58105
```

build 323

## SET_PED_HELMET_FLAG

```c
void SET_PED_HELMET_FLAG(Ped ped, int helmetFlag)  // 0xC0E78D5C2CE3EB25
```

build 323

## SET_PED_HELMET_PROP_INDEX

```c
void SET_PED_HELMET_PROP_INDEX(Ped ped, int propIndex, BOOL p2)  // 0x26D83693ED99291C
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## SET_PED_HELMET_TEXTURE_INDEX

```c
void SET_PED_HELMET_TEXTURE_INDEX(Ped ped, int textureIndex)  // 0xF1550C4BD22582E2
```

build 323

## SET_PED_HELMET_VISOR_PROP_INDICES

```c
void SET_PED_HELMET_VISOR_PROP_INDICES(Ped ped, BOOL p1, int p2, int p3)  // 0x3F7325574E41B44D
```

build 791 · old names: `_SET_PED_HELMET_UNK`

## SET_PED_HIGHLY_PERCEPTIVE

```c
void SET_PED_HIGHLY_PERCEPTIVE(Ped ped, BOOL toggle)  // 0x52D59AB61DDC05DD
```

build 323

## SET_PED_ID_RANGE

```c
void SET_PED_ID_RANGE(Ped ped, float value)  // 0xF107E836A70DCE05
```

build 323

## SET_PED_IN_VEHICLE_CONTEXT

```c
void SET_PED_IN_VEHICLE_CONTEXT(Ped ped, Hash context)  // 0x530071295899A8C6
```

build 323

> PED::SET_PED_IN_VEHICLE_CONTEXT(l_128, MISC::GET_HASH_KEY("MINI_PROSTITUTE_LOW_PASSENGER"));
> PED::SET_PED_IN_VEHICLE_CONTEXT(l_128, MISC::GET_HASH_KEY("MINI_PROSTITUTE_LOW_RESTRICTED_PASSENGER"));
> PED::SET_PED_IN_VEHICLE_CONTEXT(l_3212, MISC::GET_HASH_KEY("MISS_FAMILY1_JIMMY_SIT"));
> PED::SET_PED_IN_VEHICLE_CONTEXT(l_3212, MISC::GET_HASH_KEY("MISS_FAMILY1_JIMMY_SIT_REAR"));
> PED::SET_PED_IN_VEHICLE_CONTEXT(l_95, MISC::GET_HASH_KEY("MISS_FAMILY2_JIMMY_BICYCLE"));
> PED::SET_PED_IN_VEHICLE_CONTEXT(num3, MISC::GET_HASH_KEY("MISSFBI2_MICHAEL_DRIVEBY"));
> PED::SET_PED_IN_VEHICLE_CONTEXT(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("MISS_ARMENIAN3_FRANKLIN_TENSE"));
> PED::SET_PED_IN_VEHICLE_CONTEXT(PLAYER::PLAYER_PED_ID(), MISC::GET_HASH_KEY("MISSFBI5_TREVOR_DRIVING"));

## SET_PED_INCREASED_AVOIDANCE_RADIUS

```c
void SET_PED_INCREASED_AVOIDANCE_RADIUS(Ped ped)  // 0x570389D1C3DE3C6B
```

build 323

## SET_PED_INJURED_ON_GROUND_BEHAVIOUR

```c
void SET_PED_INJURED_ON_GROUND_BEHAVIOUR(Ped ped, float p1)  // 0xEC4B4B3B9908052A
```

build 323

## SET_PED_INTO_VEHICLE

```c
void SET_PED_INTO_VEHICLE(Ped ped, Vehicle vehicle, int seatIndex)  // 0xF75B0D629E1C063D
```

build 323

> Ped: The ped to warp.
> vehicle: The vehicle to warp the ped into.
> Seat_Index: [-1 is driver seat, -2 first free passenger seat]
> 
> Moreinfo of Seat Index
> DriverSeat = -1
> Passenger = 0
> Left Rear = 1
> RightRear = 2

## SET_PED_IS_AVOIDED_BY_OTHERS

```c
void SET_PED_IS_AVOIDED_BY_OTHERS(Any p0, BOOL p1)  // 0xA9B61A329BFDCBEA
```

build 323

## SET_PED_IS_IGNORED_BY_AUTO_OPEN_DOORS

```c
void SET_PED_IS_IGNORED_BY_AUTO_OPEN_DOORS(Ped ped, BOOL p1)  // 0x33A60D8BDD6E508C
```

build 323 · old names: `_SET_PED_CAN_PLAY_INJURED_ANIMS`

## SET_PED_KEEP_TASK

```c
void SET_PED_KEEP_TASK(Ped ped, BOOL toggle)  // 0x971D38760FBC02EF
```

build 323

## SET_PED_LEG_IK_MODE

```c
void SET_PED_LEG_IK_MODE(Ped ped, int mode)  // 0xC396F5B86FF9FEBD
```

build 323

> "IK" stands for "Inverse kinematics." I assume this has something to do with how the ped uses his legs to balance. In the scripts, the second parameter is always an int with a value of 2, 0, or sometimes 1

## SET_PED_LOD_MULTIPLIER

```c
void SET_PED_LOD_MULTIPLIER(Ped ped, float multiplier)  // 0xDC2C5C242AAC342B
```

build 323

## SET_PED_MAX_HEALTH

```c
void SET_PED_MAX_HEALTH(Ped ped, int value)  // 0xF5F6378C4F3419D3
```

build 323

> Sets the maximum health of a ped.

## SET_PED_MAX_MOVE_BLEND_RATIO

```c
void SET_PED_MAX_MOVE_BLEND_RATIO(Ped ped, float value)  // 0x433083750C5E064A
```

build 323

## SET_PED_MAX_TIME_IN_WATER

```c
void SET_PED_MAX_TIME_IN_WATER(Ped ped, float value)  // 0x43C851690662113D
```

build 323

## SET_PED_MAX_TIME_UNDERWATER

```c
void SET_PED_MAX_TIME_UNDERWATER(Ped ped, float value)  // 0x6BA428C528D9E522
```

build 323

## SET_PED_MICRO_MORPH

```c
void SET_PED_MICRO_MORPH(Ped ped, int index, float scale)  // 0x71A5C1DBA060049E
```

build 323 · old names: `_SET_PED_FACE_FEATURE`, `_SET_PED_MICRO_MORPH_VALUE`

> Sets the various freemode face features, e.g. nose length, chin shape. Scale ranges from -1.0 to 1.0.
> 
> 
> 
> 0 - Nose Width (Thin/Wide)
> 
> 1 - Nose Peak (Up/Down)
> 
> 2 - Nose Length (Long/Short)
> 
> 3 - Nose Bone Curveness (Crooked/Curved)
> 
> 4 - Nose Tip (Up/Down)
> 
> 5 - Nose Bone Twist (Left/Right)
> 
> 6 - Eyebrow (Up/Down)
> 
> 7 - Eyebrow (In/Out)
> 
> 8 - Cheek Bones (Up/Down)
> 
> 9 - Cheek Sideways Bone Size (In/Out)
> 
> 10 - Cheek Bones Width (Puffed/Gaunt)
> 
> 11 - Eye Opening (Both) (Wide/Squinted)
> 
> 12 - Lip Thickness (Both) (Fat/Thin)
> 
> 13 - Jaw Bone Width (Narrow/Wide)
> 
> 14 - Jaw Bone Shape (Round/Square)
> 
> 15 - Chin Bone (Up/Down)
> 
> 16 - Chin Bone Length (In/Out or Backward/Forward)
> 
> 17 - Chin Bone Shape (Pointed/Square)
> 
> 18 - Chin Hole (Chin Bum)
> 
> 19 - Neck Thickness (Thin/Thick)

## SET_PED_MIN_GROUND_TIME_FOR_STUNGUN

```c
void SET_PED_MIN_GROUND_TIME_FOR_STUNGUN(Ped ped, int ms)  // 0xFA0675AB151073FA
```

build 323

> Ped will stay on the ground after being stunned for at lest ms time. (in milliseconds)

## SET_PED_MIN_MOVE_BLEND_RATIO

```c
void SET_PED_MIN_MOVE_BLEND_RATIO(Ped ped, float value)  // 0x01A898D26E2333DD
```

build 323

## SET_PED_MODEL_IS_SUPPRESSED

```c
void SET_PED_MODEL_IS_SUPPRESSED(Hash modelHash, BOOL toggle)  // 0xE163A4BCE4DE6F11
```

build 323

> Full list of peds by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/peds.json

## SET_PED_MONEY

```c
void SET_PED_MONEY(Ped ped, int amount)  // 0xA9C8960E8684C1B5
```

build 323

> Maximum possible amount of money on MP is 2000. ~JX
> 
> -----------------------------------------------------------------------------
> 
> Maximum amount that a ped can theoretically have is 65535 (0xFFFF) since the amount is stored as an unsigned short (uint16_t) value.

## SET_PED_MOTION_BLUR

```c
void SET_PED_MOTION_BLUR(Ped ped, BOOL toggle)  // 0x0A986918B102B448
```

build 323

## SET_PED_MOTION_IN_COVER_CLIPSET_OVERRIDE

```c
void SET_PED_MOTION_IN_COVER_CLIPSET_OVERRIDE(Ped ped, const char* p1)  // 0x9DBA107B4937F809
```

build 323 · old names: `_SET_PED_COVER_CLIPSET_OVERRIDE`

> Found in the b617d scripts:
> PED::SET_PED_MOTION_IN_COVER_CLIPSET_OVERRIDE(v_7, "trevor_heist_cover_2h");

## SET_PED_MOVE_ANIMS_BLEND_OUT

```c
void SET_PED_MOVE_ANIMS_BLEND_OUT(Ped ped)  // 0x9E8C908F41584ECD
```

build 323

## SET_PED_MOVE_RATE_IN_WATER_OVERRIDE

```c
void SET_PED_MOVE_RATE_IN_WATER_OVERRIDE(Ped ped, float p1)  // 0x0B3E35AC043707D9
```

build 573

## SET_PED_MOVE_RATE_OVERRIDE

```c
void SET_PED_MOVE_RATE_OVERRIDE(Ped ped, float value)  // 0x085BF80FA50A39D1
```

build 323

> Min: 0.00
> Max: 10.00
> 
> Can be used in combo with fast run cheat.
> 
> When value is set to 10.00:
> Sprinting without fast run cheat: 66 m/s
> Sprinting with fast run cheat: 77 m/s
> 
> Needs to be looped!
> 
> Note: According to IDA for the Xbox360 xex, when they check bgt they seem to have the min to 0.0f, but the max set to 1.15f not 10.0f.

## SET_PED_MOVEMENT_CLIPSET

```c
void SET_PED_MOVEMENT_CLIPSET(Ped ped, const char* clipSet, float transitionSpeed)  // 0xAF8A94EDE7712BEF
```

build 323

> transitionSpeed is the time in seconds it takes to transition from one movement clipset to another.	ransitionSpeed is usually 1.0f
> 
> List of movement clipsets:
> Thanks to elsewhat for list.
> 
>  "ANIM_GROUP_MOVE_BALLISTIC"
>  "ANIM_GROUP_MOVE_LEMAR_ALLEY"
>  "clipset@move@trash_fast_turn"
>  "FEMALE_FAST_RUNNER"
>  "missfbi4prepp1_garbageman"
>  "move_characters@franklin@fire"
>  "move_characters@Jimmy@slow@"
>  "move_characters@michael@fire"
>  "move_f@flee@a"
>  "move_f@scared"
>  "move_f@sexy@a"
>  "move_heist_lester"
>  "move_injured_generic"
>  "move_lester_CaneUp"
>  "move_m@bag"
>  "MOVE_M@BAIL_BOND_NOT_TAZERED"
>  "MOVE_M@BAIL_BOND_TAZERED"
>  "move_m@brave"
>  "move_m@casual@d"
>  "move_m@drunk@moderatedrunk"
>  "MOVE_M@DRUNK@MODERATEDRUNK"
>  "MOVE_M@DRUNK@MODERATEDRUNK_HEAD_UP"
>  "MOVE_M@DRUNK@SLIGHTLYDRUNK"
>  "MOVE_M@DRUNK@VERYDRUNK"
>  "move_m@fire"
>  "move_m@gangster@var_e"
>  "move_m@gangster@var_f"
>  "move_m@gangster@var_i"
>  "move_m@JOG@"
>  "MOVE_M@PRISON_GAURD"
>  "MOVE_P_M_ONE"
>  "MOVE_P_M_ONE_BRIEFCASE"
>  "move_p_m_zero_janitor"
>  "move_p_m_zero_slow"
>  "move_ped_bucket"
>  "move_ped_crouched"
>  "move_ped_mop"
>  "MOVE_M@FEMME@"
>  "MOVE_F@FEMME@"
>  "MOVE_M@GANGSTER@NG"
>  "MOVE_F@GANGSTER@NG"
>  "MOVE_M@POSH@"
>  "MOVE_F@POSH@"
>  "MOVE_M@TOUGH_GUY@"
>  "MOVE_F@TOUGH_GUY@"
> 
> ~ NotCrunchyTaco
> 
> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## SET_PED_NAME_DEBUG

```c
void SET_PED_NAME_DEBUG(Ped ped, const char* name)  // 0x98EFA132A4117BE1
```

build 323

> NOTE: Debugging functions are not present in the retail version of the game.
> 
> *untested but char *name could also be a hash for a localized string

## SET_PED_NEVER_LEAVES_GROUP

```c
void SET_PED_NEVER_LEAVES_GROUP(Ped ped, BOOL toggle)  // 0x3DBFC55D5C9BB447
```

build 323

## SET_PED_NO_TIME_DELAY_BEFORE_SHOT

```c
void SET_PED_NO_TIME_DELAY_BEFORE_SHOT(Any p0)  // 0xA52D5247A4227E14
```

build 323

## SET_PED_NON_CREATION_AREA

```c
void SET_PED_NON_CREATION_AREA(float x1, float y1, float z1, float x2, float y2, float z2)  // 0xEE01041D559983EA
```

build 323

> The distance between these points, is the diagonal of a box (remember it's 3D).

## SET_PED_PANIC_EXIT_SCENARIO

```c
BOOL SET_PED_PANIC_EXIT_SCENARIO(Any p0, Any p1, Any p2, Any p3)  // 0xFE07FF6495D52E2A
```

build 323

## SET_PED_PARACHUTE_TINT_INDEX

```c
void SET_PED_PARACHUTE_TINT_INDEX(Ped ped, int tintIndex)  // 0x333FC8DB079B7186
```

build 323

## SET_PED_PHONE_PALETTE_IDX

```c
void SET_PED_PHONE_PALETTE_IDX(Any p0, Any p1)  // 0x83A169EABCDB10A2
```

build 323

## SET_PED_PINNED_DOWN

```c
BOOL SET_PED_PINNED_DOWN(Ped ped, BOOL pinned, int i)  // 0xAAD6D1ACF08F4612
```

build 323

> i could be time. Only example in the decompiled scripts uses it as -1.

## SET_PED_PLAYS_HEAD_ON_HORN_ANIM_WHEN_DIES_IN_VEHICLE

```c
void SET_PED_PLAYS_HEAD_ON_HORN_ANIM_WHEN_DIES_IN_VEHICLE(Ped ped, BOOL toggle)  // 0x94D94BF1A75AED3D
```

build 323

> This native does absolutely nothing, just a nullsub

## SET_PED_PREFERRED_COVER_SET

```c
void SET_PED_PREFERRED_COVER_SET(Ped ped, Any itemSet)  // 0x8421EB4DA7E391B9
```

build 323

## SET_PED_PRELOAD_PROP_DATA

```c
int SET_PED_PRELOAD_PROP_DATA(Ped ped, int componentId, int drawableId, int TextureId)  // 0x2B16A3BFF1FBCE49
```

build 323 · old names: `_IS_PED_PROP_VALID`

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## SET_PED_PRELOAD_VARIATION_DATA

```c
int SET_PED_PRELOAD_VARIATION_DATA(Ped ped, int slot, int drawableId, int textureId)  // 0x39D55A620FCB6A3A
```

build 323

> from extreme3.c4
> PED::SET_PED_PRELOAD_VARIATION_DATA(PLAYER::PLAYER_PED_ID(), 8, PED::GET_PED_DRAWABLE_VARIATION(PLAYER::PLAYER_PED_ID(), 8), PED::GET_PED_TEXTURE_VARIATION(PLAYER::PLAYER_PED_ID(), 8));
> 
> p1 is probably componentId

## SET_PED_PRIMARY_LOOKAT

```c
void SET_PED_PRIMARY_LOOKAT(Ped ped, Ped lookAt)  // 0xCD17B554996A8D9E
```

build 323

> This is only called once in the scripts.
> 
> sub_1CD9(&l_49, 0, getElem(3, &l_34, 4), "MICHAEL", 0, 1);
>                     sub_1CA8("WORLD_HUMAN_SMOKING", 2);
>                     PED::SET_PED_PRIMARY_LOOKAT(getElem(3, &l_34, 4), PLAYER::PLAYER_PED_ID());

## SET_PED_PROP_INDEX

```c
void SET_PED_PROP_INDEX(Ped ped, int componentId, int drawableId, int TextureId, BOOL attach, Any p5)  // 0x93376B65A266EB5F
```

build 323

> ComponentId can be set to various things based on what category you're wanting to set
> enum PedPropsData
> {
>     PED_PROP_HATS = 0,
>     PED_PROP_GLASSES = 1,
>  PED_PROP_EARS = 2,
>     PED_PROP_WATCHES = 3,
> };
> Usage: SET_PED_PROP_INDEX(playerPed, PED_PROP_HATS, GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS(playerPed, PED_PROP_HATS), GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS(playerPed, PED_PROP_HATS, 0), TRUE);
> 
> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## SET_PED_RAGDOLL_FORCE_FALL

```c
void SET_PED_RAGDOLL_FORCE_FALL(Ped ped)  // 0x01F6594B923B9251
```

build 323

## SET_PED_RAGDOLL_ON_COLLISION

```c
void SET_PED_RAGDOLL_ON_COLLISION(Ped ped, BOOL toggle)  // 0xF0A4F1BBF4FA7497
```

build 323

> Causes Ped to ragdoll on collision with any object (e.g Running into trashcan). If applied to player you will sometimes trip on the sidewalk.

## SET_PED_RANDOM_COMPONENT_VARIATION

```c
void SET_PED_RANDOM_COMPONENT_VARIATION(Ped ped, int p1)  // 0xC8A9481A01E63C28
```

build 323

> p1 is always 0 in R* scripts.
> 
> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## SET_PED_RANDOM_PROPS

```c
void SET_PED_RANDOM_PROPS(Ped ped)  // 0xC44AA05345C992C6
```

build 323

> List of component/props ID
> gtaxscripting.blogspot.com/2016/04/gta-v-peds-component-and-props.html

## SET_PED_RELATIONSHIP_GROUP_DEFAULT_HASH

```c
void SET_PED_RELATIONSHIP_GROUP_DEFAULT_HASH(Ped ped, Hash hash)  // 0xADB3F206518799E8
```

build 323

## SET_PED_RELATIONSHIP_GROUP_HASH

```c
void SET_PED_RELATIONSHIP_GROUP_HASH(Ped ped, Hash hash)  // 0xC80A74AC829DDD92
```

build 323

## SET_PED_RESERVE_PARACHUTE_TINT_INDEX

```c
void SET_PED_RESERVE_PARACHUTE_TINT_INDEX(Ped ped, Any p1)  // 0xE88DA0751C22A2AD
```

build 323

## SET_PED_RESET_FLAG

```c
void SET_PED_RESET_FLAG(Ped ped, int flagId, BOOL value)  // 0xC1E8A365BF3B29F2
```

build 323

> enum ePedResetFlags
> {
> 	CPED_RESET_FLAG_FallenDown = 0,
> 	CPED_RESET_FLAG_DontRenderThisFrame = 1,
> 	CPED_RESET_FLAG_IsDrowning = 2,
> 	CPED_RESET_FLAG_PedHitWallLastFrame = 3,
> 	CPED_RESET_FLAG_UsingMobilePhone = 4,
> 	CPED_RESET_FLAG_BlockMovementAnims = 5,
> 	CPED_RESET_FLAG_ZeroDesiredMoveBlendRatios = 6,
> 	CPED_RESET_FLAG_DontChangeMbrInSimpleMoveDoNothing = 7,
> 	CPED_RESET_FLAG_FollowingRoute = 8,
> 	CPED_RESET_FLAG_TakingRouteSplineCorner = 9,
> 	CPED_RESET_FLAG_Wandering = 10,
> 	CPED_RESET_FLAG_ProcessPhysicsTasks = 11,
> 	CPED_RESET_FLAG_ProcessPreRender2 = 12,
> 	CPED_RESET_FLAG_SetLastMatrixDone = 13,
> 	CPED_RESET_FLAG_FiringWeapon = 14,
> 	CPED_RESET_FLAG_SearchingForCover = 15,
> 	CPED_RESET_FLAG_KeepCoverPoint = 16,
> 	CPED_RESET_FLAG_IsClimbing = 17,
> 	CPED_RESET_FLAG_IsJumping = 18,
> 	CPED_RESET_FLAG_IsLanding = 19,
> 	CPED_RESET_FLAG_CullExtraFarAway = 20,
> 	CPED_RESET_FLAG_DontActivateRagdollFromAnyPedImpactReset = 21,
> 	CPED_RESET_FLAG_ForceScriptControlledRagdoll = 22,
> 	CPED_RESET_FLAG_TaskUseKinematicPhysics = 23,
> 	CPED_RESET_FLAG_TemporarilyBlockWeaponSwitching = 24,
> 	CPED_RESET_FLAG_DoNotClampFootIk = 25,
> 	CPED_RESET_FLAG_MoveBlend_bFleeTaskRunning = 26,
> 	CPED_RESET_FLAG_IsAiming = 27,
> 	CPED_RESET_FLAG_MoveBlend_bTaskComplexGunRunning = 28,
> 	CPED_RESET_FLAG_MoveBlend_bMeleeTaskRunning = 29,
> 	CPED_RESET_FLAG_MoveBlend_bCopSearchTaskRunning = 30,
> 	CPED_RESET_FLAG_PatrollingInVehicle = 31,
> 	CPED_RESET_FLAG_RaiseVelocityChangeLimit = 32,
> 	CPED_RESET_FLAG_DimTargetReticule = 33,
> 	CPED_RESET_FLAG_IsWalkingRoundPlayer = 34,
> 	CPED_RESET_FLAG_GestureAnimsAllowed = 35,
> 	CPED_RESET_FLAG_VisemeAnimsBlocked = 36,
> 	CPED_RESET_FLAG_AmbientAnimsBlocked = 37,
> 	CPED_RESET_FLAG_KnockedToTheFloorByPlayer = 38,
> 	CPED_RESET_FLAG_RandomisePointsDuringNavigation = 39,
> 	CPED_RESET_FLAG_Prevent180SkidTurns = 40,
> 	CPED_RESET_FLAG_IsOnAssistedMovementRoute = 41,
> 	CPED_RESET_FLAG_ApplyVelocityDirectly = 42,
> 	CPED_RESET_FLAG_DisablePlayerLockon = 43,
> 	CPED_RESET_FLAG_ResetMoveGroupAfterRagdoll = 44,
> 	CPED_RESET_FLAG_DisablePedConstraints = 45,
> 	CPED_RESET_FLAG_DisablePlayerJumping = 46,
> 	CPED_RESET_FLAG_DisablePlayerVaulting = 47,
> 	CPED_RESET_FLAG_DisableAsleepImpulse = 48,
> 	CPED_RESET_FLAG_ForcePostCameraAIUpdate = 49,
> 	CPED_RESET_FLAG_ForcePostCameraAnimUpdate = 50,
> 	CPED_RESET_FLAG_ePostCameraAnimUpdateUseZeroTimestep = 51,
> 	CPED_RESET_FLAG_CollideWithGlassRagdoll = 52,
> 	CPED_RESET_FLAG_CollideWithGlassWeapon = 53,
> 	CPED_RESET_FLAG_SyncDesiredHeadingToCurrentHeading = 54,
> 	CPED_RESET_FLAG_AllowUpdateIfNoCollisionLoaded = 55,
> 	CPED_RESET_FLAG_InternalWalkingRndPlayer = 56,
> 	CPED_RESET_FLAG_PlacingCharge = 57,
> 	CPED_RESET_FLAG_ScriptDisableSecondaryAnimationTasks = 58,
> 	CPED_RESET_FLAG_SearchingForClimb = 59,
> 	CPED_RESET_FLAG_SearchingForDoors = 60,
> 	CPED_RESET_FLAG_WanderingStoppedForOtherPed = 61,
> 	CPED_RESET_FLAG_SupressGunfireEvents = 62,
> 	CPED_RESET_FLAG_InfiniteStamina = 63,
> 	CPED_RESET_FLAG_BlockWeaponReactionsUnlessDead = 64,
> 	CPED_RESET_FLAG_ForcePlayerFiring = 65,
> 	CPED_RESET_FLAG_InCoverFacingLeft = 66,
> 	CPED_RESET_FLAG_ForcePeekFromCover = 67,
> 	CPED_RESET_FLAG_NotAllowedToChangeCrouchState = 68,
> 	CPED_RESET_FLAG_ForcePedToStrafe = 69,
> 	CPED_RESET_FLAG_ForceMeleeStrafingAnims = 70,
> 	CPED_RESET_FLAG_UseKinematicPhysics = 71,
> 	CPED_RESET_FLAG_ClearLockonTarget = 72,
> 	CPED_RESET_FLAG_CanPedSeeHatedPedBeingUsed = 73,
> 	CPED_RESET_FLAG_InstantBlendToAim = 74,
> 	CPED_RESET_FLAG_ForceImprovedIdleTurns = 75,
> 	CPED_RESET_FLAG_HitPedWithWeapon = 76,
> 	CPED_RESET_FLAG_ForcePedToUseScripCamHeading = 77,
> 	CPED_RESET_FLAG_ProcessProbesWhenExtractingZ = 78,
> 	CPED_RESET_FLAG_KeepDesiredCoverPoint = 79,
> 	CPED_RESET_FLAG_HasProcessedCornering = 80,
> 	CPED_RESET_FLAG_StandingOnForkliftForks = 81,
> 	CPED_RESET_FLAG_AimWeaponReactionRunning = 82,
> 	CPED_RESET_FLAG_InContactWithFoliage = 83,
> 	CPED_RESET_FLAG_ForceExplosionCollisions = 84,
> 	CPED_RESET_FLAG_IgnoreTargetsCoverForLOS = 85,
> 	CPED_RESET_FLAG_BlockAnimatedWeaponReactions = 86,
> 	CPED_RESET_FLAG_DisablePedCapsule = 87,
> 	CPED_RESET_FLAG_DisableCrouchWhileInCover = 88,
> 	CPED_RESET_FLAG_IncreasedAvoidanceRadius = 89,
> 	CPED_RESET_FLAG_UNUSED_REPLACE_ME = 90,
> 	CPED_RESET_FLAG_ForceRunningSpeedForFragSmashing = 91,
> 	CPED_RESET_FLAG_EnableMoverAnimationWhileAttached = 92,
> 	CPED_RESET_FLAG_NoTimeDelayBeforeShot = 93,
> 	CPED_RESET_FLAG_SearchingForAutoVaultClimb = 94,
> 	CPED_RESET_FLAG_ExtraLongWeaponRange = 95,
> 	CPED_RESET_FLAG_ForcePlayerToEnterVehicleThroughDirectDoorOnly = 96,
> 	CPED_RESET_FLAG_TaskCullExtraFarAway = 97,
> 	CPED_RESET_FLAG_IsVaulting = 98,
> 	CPED_RESET_FLAG_IsParachuting = 99,
> 	CPED_RESET_FLAG_SuppressSlowingForCorners = 100,
> 	CPED_RESET_FLAG_DisableProcessProbes = 101,
> 	CPED_RESET_FLAG_DisablePlayerAutoVaulting = 102,
> 	CPED_RESET_FLAG_DisableGaitReduction = 103,
> 	CPED_RESET_FLAG_ExitVehicleTaskFinishedThisFrame = 104,
> 	CPED_RESET_FLAG_RequiresLegIk = 105,
> 	CPED_RESET_FLAG_JayWalking = 106,
> 	CPED_RESET_FLAG_UseBulletPenetration = 107,
> 	CPED_RESET_FLAG_ForceAimAtHead = 108,
> 	CPED_RESET_FLAG_IsInStationaryScenario = 109,
> 	CPED_RESET_FLAG_TemporarilyBlockWeaponEquipping = 110,
> 	CPED_RESET_FLAG_CoverOutroRunning = 111,
> 	CPED_RESET_FLAG_DisableSeeThroughChecksWhenTargeting = 112,
> 	CPED_RESET_FLAG_PuttingOnHelmet = 113,
> 	CPED_RESET_FLAG_AllowPullingPedOntoRoute = 114,
> 	CPED_RESET_FLAG_ApplyAnimatedVelocityWhilstAttached = 115,
> 	CPED_RESET_FLAG_AICoverEntryRunning = 116,
> 	CPED_RESET_FLAG_ResponseAfterScenarioPanic = 117,
> 	CPED_RESET_FLAG_IsNearDoor = 118,
> 	CPED_RESET_FLAG_DisableTorsoSolver = 119,
> 	CPED_RESET_FLAG_PanicInVehicle = 120,
> 	CPED_RESET_FLAG_DisableDynamicCapsuleRadius = 121,
> 	CPED_RESET_FLAG_IsRappelling = 122,
> 	CPED_RESET_FLAG_SkipReactInReactAndFlee = 123,
> 	CPED_RESET_FLAG_CannotBeTargeted = 124,
> 	CPED_RESET_FLAG_IsFalling = 125,
> 	CPED_RESET_FLAG_ForceInjuryAfterStunned = 126,
> 	CPED_RESET_FLAG_HurtThisFrame = 127,
> 	CPED_RESET_FLAG_BlockWeaponFire = 128,
> 	CPED_RESET_FLAG_ExpandPedCapsuleFromSkeleton = 129,
> 	CPED_RESET_FLAG_DisableWeaponLaserSight = 130,
> 	CPED_RESET_FLAG_PedExitedVehicleThisFrame = 131,
> 	CPED_RESET_FLAG_SearchingForDropDown = 132,
> 	CPED_RESET_FLAG_UseTighterTurnSettings = 133,
> 	CPED_RESET_FLAG_DisableArmSolver = 134,
> 	CPED_RESET_FLAG_DisableHeadSolver = 135,
> 	CPED_RESET_FLAG_DisableLegSolver = 136,
> 	CPED_RESET_FLAG_DisableTorsoReactSolver = 137,
> 	CPED_RESET_FLAG_ForcePreCameraAIUpdate = 138,
> 	CPED_RESET_FLAG_TasksNeedProcessMoveSignalCalls = 139,
> 	CPED_RESET_FLAG_ShootFromGround = 140,
> 	CPED_RESET_FLAG_NoCollisionMovementMode = 141,
> 	CPED_RESET_FLAG_IsNearLaddder = 142,
> 	CPED_RESET_FLAG_SkipAimingIdleIntro = 143,
> 	CPED_RESET_FLAG_IgnoredByAutoOpenDoors = 144,
> 	CPED_RESET_FLAG_BlockIkWeaponReactions = 145,
> 	CPED_RESET_FLAG_FirstPhysicsUpdate = 146,
> 	CPED_RESET_FLAG_SpawnedThisFrameByAmbientPopulation = 147,
> 	CPED_RESET_FLAG_DisableRootSlopeFixupSolver = 148,
> 	CPED_RESET_FLAG_SuspendInitiatedMeleeActions = 149,
> 	CPED_RESET_FLAG_SuppressInAirEvent = 150,
> 	CPED_RESET_FLAG_AllowTasksIncompatibleWithMotion = 151,
> 	CPED_RESET_FLAG_IsEnteringOrExitingVehicle = 152,
> 	CPED_RESET_FLAG_PlayerOnHorse = 153,
> 	CPED_RESET_FLAG_HasGunTaskWithAimingState = 154,
> 	CPED_RESET_FLAG_SuppressLethalMeleeActions = 155,
> 	CPED_RESET_FLAG_InstantBlendToAimFromScript = 156,
> 	CPED_RESET_FLAG_IsStillOnBicycle = 157,
> 	CPED_RESET_FLAG_IsSittingAndCycling = 158,
> 	CPED_RESET_FLAG_IsStandingAndCycling = 159,
> 	CPED_RESET_FLAG_IsDoingCoverAimOutro = 160,
> 	CPED_RESET_FLAG_ApplyCoverWeaponBlockingOffsets = 161,
> 	CPED_RESET_FLAG_IsInLowCover = 162,
> 	CPED_RESET_FLAG_AmbientIdleAndBaseAnimsBlocked = 163,
> 	CPED_RESET_FLAG_UseAlternativeWhenBlock = 164,
> 	CPED_RESET_FLAG_ForceLowLodWaterCheck = 165,
> 	CPED_RESET_FLAG_MakeHeadInvisible = 166,
> 	CPED_RESET_FLAG_NoAutoRunWhenFiring = 167,
> 	CPED_RESET_FLAG_PermitEventDuringScenarioExit = 168,
> 	CPED_RESET_FLAG_DisableSteeringAroundVehicles = 169,
> 	CPED_RESET_FLAG_DisableSteeringAroundPeds = 170,
> 	CPED_RESET_FLAG_DisableSteeringAroundObjects = 171,
> 	CPED_RESET_FLAG_DisableSteeringAroundNavMeshEdges = 172,
> 	CPED_RESET_FLAG_WantsToEnterVehicleFromCover = 173,
> 	CPED_RESET_FLAG_WantsToEnterCover = 174,
> 	CPED_RESET_FLAG_WantsToEnterVehicleFromAiming = 175,
> 	CPED_RESET_FLAG_CapsuleBeingPushedByVehicle = 176,
> 	CPED_RESET_FLAG_DisableTakeOffParachutePack = 177,
> 	CPED_RESET_FLAG_IsCallingPolice = 178,
> 	CPED_RESET_FLAG_ForceCombatTaunt = 179,
> 	CPED_RESET_FLAG_IgnoreCombatTaunts = 180,
> 	CPED_RESET_FLAG_SkipAiUpdateProcessControl = 181,
> 	CPED_RESET_FLAG_OverridePhysics = 182,
> 	CPED_RESET_FLAG_WasPhysicsOverridden = 183,
> 	CPED_RESET_FLAG_BlockWeaponHoldingAnims = 184,
> 	CPED_RESET_FLAG_DisableMoveTaskHeadingAdjustments = 185,
> 	CPED_RESET_FLAG_DisableBodyLookSolver = 186,
> 	CPED_RESET_FLAG_PreventAllMeleeTakedowns = 187,
> 	CPED_RESET_FLAG_PreventFailedMeleeTakedowns = 188,
> 	CPED_RESET_FLAG_IsPedalling = 189,
> 	CPED_RESET_FLAG_UseTighterAvoidanceSettings = 190,
> 	CPED_RESET_FLAG_IsHigherPriorityClipControllingPed = 191,
> 	CPED_RESET_FLAG_VehicleCrushingRagdoll = 192,
> 	CPED_RESET_FLAG_OnActivationUpdate = 193,
> 	CPED_RESET_FLAG_ForceMotionStateLeaveDesiredMBR = 194,
> 	CPED_RESET_FLAG_DisableDropDowns = 195,
> 	CPED_RESET_FLAG_InContactWithBIGFoliage = 196,
> 	CPED_RESET_FLAG_DisableTakeOffScubaGear = 197,
> 	CPED_RESET_FLAG_DisableCellphoneAnimations = 198,
> 	CPED_RESET_FLAG_IsExitingVehicle = 199,
> 	CPED_RESET_FLAG_DisableActionMode = 200,
> 	CPED_RESET_FLAG_EquippedWeaponChanged = 201,
> 	CPED_RESET_FLAG_TouchingOverhang = 202,
> 	CPED_RESET_FLAG_TooSteepForPlayer = 203,
> 	CPED_RESET_FLAG_BlockSecondaryAnim = 204,
> 	CPED_RESET_FLAG_IsInCombat = 205,
> 	CPED_RESET_FLAG_UseHeadOrientationForPerception = 206,
> 	CPED_RESET_FLAG_IsDoingDriveby = 207,
> 	CPED_RESET_FLAG_IsEnteringCover = 208,
> 	CPED_RESET_FLAG_ForceMovementScannerCheck = 209,
> 	CPED_RESET_FLAG_DisableJumpRagdollOnCollision = 210,
> 	CPED_RESET_FLAG_IsBeingMeleeHomedByPlayer = 211,
> 	CPED_RESET_FLAG_ShouldLaunchBicycleThisFrame = 212,
> 	CPED_RESET_FLAG_CanDoBicycleWheelie = 213,
> 	CPED_RESET_FLAG_ForceProcessPhysicsUpdateEachSimStep = 214,
> 	CPED_RESET_FLAG_DisablePedCapsuleMapCollision = 215,
> 	CPED_RESET_FLAG_DisableSeatShuffleDueToInjuredDriver = 216,
> 	CPED_RESET_FLAG_DisableParachuting = 217,
> 	CPED_RESET_FLAG_ProcessPostMovement = 218,
> 	CPED_RESET_FLAG_ProcessPostCamera = 219,
> 	CPED_RESET_FLAG_ProcessPostPreRender = 220,
> 	CPED_RESET_FLAG_PreventBicycleFromLeaningOver = 221,
> 	CPED_RESET_FLAG_KeepParachutePackOnAfterTeleport = 222,
> 	CPED_RESET_FLAG_DontRaiseFistsWhenLockedOn = 223,
> 	CPED_RESET_FLAG_PreferMeleeBodyIkHitReaction = 224,
> 	CPED_RESET_FLAG_ProcessPhysicsTasksMotion = 225,
> 	CPED_RESET_FLAG_ProcessPhysicsTasksMovement = 226,
> 	CPED_RESET_FLAG_DisableFriendlyGunReactAudio = 227,
> 	CPED_RESET_FLAG_DisableAgitationTriggers = 228,
> 	CPED_RESET_FLAG_ForceForwardTransitionInReactAndFlee = 229,
> 	CPED_RESET_FLAG_IsEnteringVehicle = 230,
> 	CPED_RESET_FLAG_DoNotSkipNavMeshTrackerUpdate = 231,
> 	CPED_RESET_FLAG_RagdollOnVehicle = 232,
> 	CPED_RESET_FLAG_BlockRagdollActivationInVehicle = 233,
> 	CPED_RESET_FLAG_DisableNMForRiverRapids = 234,
> 	CPED_RESET_FLAG_IsInWrithe = 235,
> 	CPED_RESET_FLAG_PreventGoingIntoStillInVehicleState = 236,
> 	CPED_RESET_FLAG_UseFastEnterExitVehicleRates = 237,
> 	CPED_RESET_FLAG_DisableGroundAttachment = 238,
> 	CPED_RESET_FLAG_DisableAgitation = 239,
> 	CPED_RESET_FLAG_DisableTalk = 240,
> 	CPED_RESET_FLAG_InterruptedToQuickStartEngine = 241,
> 	CPED_RESET_FLAG_PedEnteredFromLeftEntry = 242,
> 	CPED_RESET_FLAG_IsDiving = 243,
> 	CPED_RESET_FLAG_DisableVehicleImpacts = 244,
> 	CPED_RESET_FLAG_DeepVehicleImpacts = 245,
> 	CPED_RESET_FLAG_DisablePedCapsuleControl = 246,
> 	CPED_RESET_FLAG_UseProbeSlopeStairsDetection = 247,
> 	CPED_RESET_FLAG_DisableVehicleDamageReactions = 248,
> 	CPED_RESET_FLAG_DisablePotentialBlastReactions = 249,
> 	CPED_RESET_FLAG_OnlyAllowLeftArmDoorIk = 250,
> 	CPED_RESET_FLAG_OnlyAllowRightArmDoorIk = 251,
> 	CPED_RESET_FLAG_ForceProcessPedStandingUpdateEachSimStep = 252,
> 	CPED_RESET_FLAG_DisableFlashLight = 253,
> 	CPED_RESET_FLAG_DoingCombatRoll = 254,
> 	CPED_RESET_FLAG_DisableBodyRecoilSolver = 255,
> 	CPED_RESET_FLAG_CanAbortExitForInAirEvent = 256,
> 	CPED_RESET_FLAG_DisableSprintDamage = 257,
> 	CPED_RESET_FLAG_ForceEnableFlashLightForAI = 258,
> 	CPED_RESET_FLAG_IsDoingCoverAimIntro = 259,
> 	CPED_RESET_FLAG_IsAimingFromCover = 260,
> 	CPED_RESET_FLAG_WaitingForCompletedPathRequest = 261,
> 	CPED_RESET_FLAG_DisableCombatAudio = 262,
> 	CPED_RESET_FLAG_DisableCoverAudio = 263,
> 	CPED_RESET_FLAG_PreventBikeFromLeaning = 264,
> 	CPED_RESET_FLAG_InCoverTaskActive = 265,
> 	CPED_RESET_FLAG_EnableSteepSlopePrevention = 266,
> 	CPED_RESET_FLAG_InsideEnclosedSearchRegion = 267,
> 	CPED_RESET_FLAG_JumpingOutOfVehicle = 268,
> 	CPED_RESET_FLAG_IsTuckedOnBicycleThisFrame = 269,
> 	CPED_RESET_FLAG_ProcessPostMovementTimeSliced = 270,
> 	CPED_RESET_FLAG_EnablePressAndReleaseDives = 271,
> 	CPED_RESET_FLAG_OnlyExitVehicleOnButtonRelease = 272,
> 	CPED_RESET_FLAG_IsGoingToStandOnExitedVehicle = 273,
> 	CPED_RESET_FLAG_BlockRagdollFromVehicleFallOff = 274,
> 	CPED_RESET_FLAG_DisableTorsoVehicleSolver = 275,
> 	CPED_RESET_FLAG_IsExitingUpsideDownVehicle = 276,
> 	CPED_RESET_FLAG_IsExitingOnsideVehicle = 277,
> 	CPED_RESET_FLAG_IsExactStopping = 278,
> 	CPED_RESET_FLAG_IsExactStopSettling = 279,
> 	CPED_RESET_FLAG_IsTrainCrushingRagdoll = 280,
> 	CPED_RESET_FLAG_OverrideHairScale = 281,
> 	CPED_RESET_FLAG_ConsiderAsPlayerCoverThreatWithoutLOS = 282,
> 	CPED_RESET_FLAG_BlockCustomAIEntryAnims = 283,
> 	CPED_RESET_FLAG_IgnoreVehicleEntryCollisionTests = 284,
> 	CPED_RESET_FLAG_StreamActionModeAnimsIfDisabled = 285,
> 	CPED_RESET_FLAG_ForceUpdateRagdollMatrix = 286,
> 	CPED_RESET_FLAG_PreventGoingIntoShuntInVehicleState = 287,
> 	CPED_RESET_FLAG_DisableIndependentMoverFrame = 288,
> 	CPED_RESET_FLAG_DoingDrivebyOutro = 289,
> 	CPED_RESET_FLAG_BeingElectrocuted = 290,
> 	CPED_RESET_FLAG_DisableUnarmedDrivebys = 291,
> 	CPED_RESET_FLAG_TalkingToPlayer = 292,
> 	CPED_RESET_FLAG_DontActivateRagdollFromPlayerPedImpactReset = 293,
> 	CPED_RESET_FLAG_DontActivateRagdollFromAiRagdollImpactReset = 294,
> 	CPED_RESET_FLAG_DontActivateRagdollFromPlayerRagdollImpactReset = 295,
> 	CPED_RESET_FLAG_DisableVisemeBodyAdditive = 296,
> 	CPED_RESET_FLAG_CapsuleBeingPushedByPlayerCapsule = 297,
> 	CPED_RESET_FLAG_ForceActionMode = 298,
> 	CPED_RESET_FLAG_ForceUnarmedActionMode = 299,
> 	CPED_RESET_FLAG_UsingMoverExtraction = 300,
> 	CPED_RESET_FLAG_BeingJacked = 301,
> 	CPED_RESET_FLAG_EnableVoiceDrivenMouthMovement = 302,
> 	CPED_RESET_FLAG_IsReloading = 303,
> 	CPED_RESET_FLAG_UseTighterEnterVehicleSettings = 304,
> 	CPED_RESET_FLAG_InRaceMode = 305,
> 	CPED_RESET_FLAG_DisableAmbientMeleeMoves = 306,
> 	CPED_RESET_FLAG_ForceBuoyancyProcessingIfAsleep = 307,
> 	CPED_RESET_FLAG_AllowSpecialAbilityInVehicle = 308,
> 	CPED_RESET_FLAG_DisableInVehicleActions = 309,
> 	CPED_RESET_FLAG_ForceInstantSteeringWheelIkBlendIn = 310,
> 	CPED_RESET_FLAG_IgnoreThreatEngagePlayerCoverBonus = 311,
> 	CPED_RESET_FLAG_Block180Turns = 312,
> 	CPED_RESET_FLAG_DontCloseVehicleDoor = 313,
> 	CPED_RESET_FLAG_SkipExplosionOcclusion = 314,
> 	CPED_RESET_FLAG_ProcessPhysicsTasksTimeSliced = 315,
> 	CPED_RESET_FLAG_MeleeStrikeAgainstNonPed = 316,
> 	CPED_RESET_FLAG_IgnoreNavigationForDoorArmIK = 317,
> 	CPED_RESET_FLAG_DisableAimingWhileParachuting = 318,
> 	CPED_RESET_FLAG_DisablePedCollisionWithPedEvent = 319,
> 	CPED_RESET_FLAG_IgnoreVelocityWhenClosingVehicleDoor = 320,
> 	CPED_RESET_FLAG_SkipOnFootIdleIntro = 321,
> 	CPED_RESET_FLAG_DontWalkRoundObjects = 322,
> 	CPED_RESET_FLAG_DisablePedEnteredMyVehicleEvents = 323,
> 	CPED_RESET_FLAG_CancelLeftHandGripIk = 324,
> 	CPED_RESET_FLAG_ResetMovementStaticCounter = 325,
> 	CPED_RESET_FLAG_DisableInVehiclePedVariationBlocking = 326,
> 	CPED_RESET_FLAG_ReduceEffectOfVehicleRamControlLoss = 327,
> 	CPED_RESET_FLAG_DisablePlayerMeleeFriendlyAttacks = 328,
> 	CPED_RESET_FLAG_MotionPedDoPostMovementIndependentMover = 329,
> 	CPED_RESET_FLAG_IsMeleeTargetUnreachable = 330,
> 	CPED_RESET_FLAG_DisableAutoForceOutWhenBlowingUpCar = 331,
> 	CPED_RESET_FLAG_ThrowingProjectile = 332,
> 	CPED_RESET_FLAG_OverrideHairScaleLarger = 333,
> 	CPED_RESET_FLAG_DisableDustOffAnims = 334,
> 	CPED_RESET_FLAG_DisableMeleeHitReactions = 335,
> 	CPED_RESET_FLAG_VisemeAnimsAudioBlocked = 336,
> 	CPED_RESET_FLAG_AllowHeadPropInVehicle = 337,
> 	CPED_RESET_FLAG_IsInVehicleChase = 338,
> 	CPED_RESET_FLAG_DontQuitMotionAiming = 339,
> 	CPED_RESET_FLAG_SetLastBoundMatricesDone = 340,
> 	CPED_RESET_FLAG_PreserveAnimatedAngularVelocity = 341,
> 	CPED_RESET_FLAG_OpenDoorArmIK = 342,
> 	CPED_RESET_FLAG_UseTighterTurnSettingsForScript = 343,
> 	CPED_RESET_FLAG_ForcePreCameraProcessExternallyDrivenDOFs = 344,
> 	CPED_RESET_FLAG_LadderBlockingMovement = 345,
> 	CPED_RESET_FLAG_DisableVoiceDrivenMouthMovement = 346,
> 	CPED_RESET_FLAG_SteerIntoSkids = 347,
> 	CPED_RESET_FLAG_AllowOpenDoorIkBeforeFullMovement = 348,
> 	CPED_RESET_FLAG_AllowHomingMissileLockOnInVehicle = 349,
> 	CPED_RESET_FLAG_AllowCloneForcePostCameraAIUpdate = 350,
> 	CPED_RESET_FLAG_DisableHighHeels = 351,
> 	CPED_RESET_FLAG_BreakTargetLock = 352,
> 	CPED_RESET_FLAG_DontUseSprintEnergy = 353,
> 	CPED_RESET_FLAG_DontChangeHorseMbr = 354,
> 	CPED_RESET_FLAG_DisableMaterialCollisionDamage = 355,
> 	CPED_RESET_FLAG_DisableMPFriendlyLockon = 356,
> 	CPED_RESET_FLAG_DisableMPFriendlyLethalMeleeActions = 357,
> 	CPED_RESET_FLAG_IfLeaderStopsSeekCover = 358,
> 	CPED_RESET_FLAG_ProcessPostPreRenderAfterAttachments = 359,
> 	CPED_RESET_FLAG_DoDamageCoughFacial = 360,
> 	CPED_RESET_FLAG_IsUsingJetpack = 361,
> 	CPED_RESET_FLAG_UseInteriorCapsuleSettings = 362,
> 	CPED_RESET_FLAG_IsClosingVehicleDoor = 363,
> 	CPED_RESET_FLAG_DisableIdleExtraHeadingChange = 364,
> 	CPED_RESET_FLAG_OnlySelectVehicleWeapons = 365,
> 	CPED_RESET_FLAG_IsWarpingIntoVehicleMP = 366,
> 	CPED_RESET_FLAG_RemoveHelmet = 367,
> 	CPED_RESET_FLAG_IsRemovingHelmet = 368,
> 	CPED_RESET_FLAG_GestureAnimsBlockedFromScript = 369,
> 	CPED_RESET_FLAG_NeverRagdoll = 370,
> 	CPED_RESET_FLAG_DisableWallHitAnimation = 371,
> 	CPED_RESET_FLAG_PlayAgitatedAnimsInVehicle = 372,
> 	CPED_RESET_FLAG_IsSeatShuffling = 373,
> 	CPED_RESET_FLAG_IsThrowingProjectileWhileAiming = 374,
> 	CPED_RESET_FLAG_DisableProjectileThrowsWhileAimingGun = 375,
> 	CPED_RESET_FLAG_AllowControlRadioInAnySeatInMP = 376,
> 	CPED_RESET_FLAG_DisableSpycarTransformation = 377,
> 	CPED_RESET_FLAG_BlockQuadLocomotionIdleTurns = 378,
> 	CPED_RESET_FLAG_BlockHeadbobbingToRadio = 379,
> 	CPED_RESET_FLAG_PlayFPSIdleFidgets = 380,
> 	CPED_RESET_FLAG_ForceExtraLongBlendInForPedSkipIdleCoverTransition = 381,
> 	CPED_RESET_FLAG_BlendingOutFPSIdleFidgets = 382,
> 	CPED_RESET_FLAG_DisableMotionBaseVelocityOverride = 383,
> 	CPED_RESET_FLAG_FPSSwimUseSwimMotionTask = 384,
> 	CPED_RESET_FLAG_FPSSwimUseAimingMotionTask = 385,
> 	CPED_RESET_FLAG_FiringWeaponWhenReady = 386,
> 	CPED_RESET_FLAG_IsBlindFiring = 387,
> 	CPED_RESET_FLAG_IsPeekingFromCover = 388,
> 	CPED_RESET_FLAG_TaskSkipProcessPreComputeImpacts = 389,
> 	CPED_RESET_FLAG_DisableAssistedAimLockon = 390,
> 	CPED_RESET_FLAG_FPSAllowAimIKForThrownProjectile = 391,
> 	CPED_RESET_FLAG_TriggerRoadRageAnim = 392,
> 	CPED_RESET_FLAG_ForcePreCameraAiAnimUpdateIfFirstPerson = 393,
> 	CPED_RESET_FLAG_NoCollisionDamageFromOtherPeds = 394,
> 	CPED_RESET_FLAG_BlockCameraSwitching = 395,
> 	CPED_RESET_FLAG_NeverDieFromCapsuleRagdollSettings = 396,
> 	CPED_RESET_FLAG_InContactWithDeepSurface = 397,
> 	CPED_RESET_FLAG_DontSuppressUseNavMeshToNavigateToVehicleDoorWhenVehicleInWater = 398,
> 	CPED_RESET_FLAG_IncludePedReferenceVelocityWhenFiringProjectiles = 399,
> 	CPED_RESET_FLAG_IsDoingCoverOutroToPeek = 400,
> 	CPED_RESET_FLAG_InstantBlendToAimNoSettle = 401,
> 	CPED_RESET_FLAG_ForcePreCameraAnimUpdate = 402,
> 	CPED_RESET_FLAG_DisableHelmetCullFPS = 403,
> 	CPED_RESET_FLAG_ShouldIgnoreCoverAutoHeadingCorrection = 404,
> 	CPED_RESET_FLAG_DisableReticuleInCoverThisFrame = 405,
> 	CPED_RESET_FLAG_ForceScriptedCameraLowCoverAngleWhenEnteringCover = 406,
> 	CPED_RESET_FLAG_DisableCameraConstraintFallBackThisFrame = 407,
> 	CPED_RESET_FLAG_DisableFPSArmIK = 408,
> 	CPED_RESET_FLAG_DisableRightArmIKInCoverOutroFPS = 409,
> 	CPED_RESET_FLAG_DoFPSSprintBreakOut = 410,
> 	CPED_RESET_FLAG_DoFPSJumpBreakOut = 411,
> 	CPED_RESET_FLAG_IsExitingCover = 412,
> 	CPED_RESET_FLAG_WeaponBlockedInFPSMode = 413,
> 	CPED_RESET_FLAG_PoVCameraConstrained = 414,
> 	CPED_RESET_FLAG_ScriptClearingPedTasks = 415,
> 	CPED_RESET_FLAG_WasFPSJumpingWithProjectile = 416,
> 	CPED_RESET_FLAG_DisableMeleeWeaponSelection = 417,
> 	CPED_RESET_FLAG_WaypointPlaybackSlowMoreForCorners = 418,
> 	CPED_RESET_FLAG_FPSPlacingProjectile = 419,
> 	CPED_RESET_FLAG_UseBulletPenetrationForGlass = 420,
> 	CPED_RESET_FLAG_FPSPlantingBombOnFloor = 421,
> 	CPED_RESET_FLAG_ForceSkipFPSAimIntro = 422,
> 	CPED_RESET_FLAG_CanBePinnedByFriendlyBullets = 423,
> 	CPED_RESET_FLAG_DisableLeftArmIKInCoverOutroFPS = 424,
> 	CPED_RESET_FLAG_DisableSpikeStripRoadBlocks = 425,
> 	CPED_RESET_FLAG_SkipFPSUnHolsterTransition = 426,
> 	CPED_RESET_FLAG_PutDownHelmetFX = 427,
> 	CPED_RESET_FLAG_IsLowerPriorityMeleeTarget = 428,
> 	CPED_RESET_FLAG_ForceScanForEventsThisFrame = 429,
> 	CPED_RESET_FLAG_StartProjectileTaskWithPrimingDisabled = 430,
> 	CPED_RESET_FLAG_CheckFPSSwitchInCameraUpdate = 431,
> 	CPED_RESET_FLAG_ForceAutoEquipHelmetsInAicraft = 432,
> 	CPED_RESET_FLAG_BlockRemotePlayerRecording = 433,
> 	CPED_RESET_FLAG_InflictedDamageThisFrame = 434,
> 	CPED_RESET_FLAG_UseFirstPersonVehicleAnimsIfFPSCamNotDominant = 435,
> 	CPED_RESET_FLAG_ForceIntoStandPoseOnJetski = 436,
> 	CPED_RESET_FLAG_InAirDefenceSphere = 437,
> 	CPED_RESET_FLAG_SuppressTakedownMeleeActions = 438,
> 	CPED_RESET_FLAG_InvertLookAroundControls = 439,
> 	CPED_RESET_FLAG_IgnoreCombatManager = 440,
> 	CPED_RESET_FLAG_UseBlendedCamerasOnUpdateFpsCameraRelativeMatrix = 441,
> 	CPED_RESET_FLAG_ForceMeleeCounter = 442,
> 	CPED_RESET_FLAG_WasHitByVehicleMelee = 443,
> 	CPED_RESET_FLAG_SuppressNavmeshForEnterVehicleTask = 444,
> 	CPED_RESET_FLAG_DisableShallowWaterBikeJumpOutThisFrame = 445,
> 	CPED_RESET_FLAG_DisablePlayerCombatRoll = 446,
> 	CPED_RESET_FLAG_IgnoreDetachSafePositionCheck = 447,
> 	CPED_RESET_FLAG_DisableEasyLadderConditions = 448,
> 	CPED_RESET_FLAG_PlayerIgnoresScenarioSpawnRestrictions = 449,
> 	CPED_RESET_FLAG_UsingDrone = 450,
> 	CPED_RESET_FLAG_ForceWantedLevelWhenKilled = 451,
> 	CPED_RESET_FLAG_UseScriptedWeaponFirePosition = 452,
> 	CPED_RESET_FLAG_EnableCollisionOnNetworkCloneWhenFixed = 453,
> 	CPED_RESET_FLAG_UseExtendedRagdollCollisionCalculator = 454,
> 	CPED_RESET_FLAG_PreventLockonToFriendlyPlayers = 455,
> 	CPED_RESET_FLAG_OnlyAbortScriptedAnimOnMovementByInput = 456,
> 	CPED_RESET_FLAG_PreventAllStealthKills = 457,
> 	CPED_RESET_FLAG_BlockFallTaskFromExplosionDamage = 458,
> 	CPED_RESET_FLAG_AllowPedRearEntry = 459,
> };

## SET_PED_SCUBA_GEAR_VARIATION

```c
void SET_PED_SCUBA_GEAR_VARIATION(Ped ped)  // 0x36C6984C3ED0C911
```

build 323 · old names: `_SET_PED_SCUBA_GEAR_VARIATION`

> This native sets a scuba mask for freemode models and an oxygen bottle for player_* models. It works on freemode and player_* models.

## SET_PED_SEEING_RANGE

```c
void SET_PED_SEEING_RANGE(Ped ped, float value)  // 0xF29CF591C4BF6CEE
```

build 323

## SET_PED_SHOOT_RATE

```c
void SET_PED_SHOOT_RATE(Ped ped, int shootRate)  // 0x614DA022990752DC
```

build 323

> shootRate 0-1000

## SET_PED_SHOOTS_AT_COORD

```c
void SET_PED_SHOOTS_AT_COORD(Ped ped, float x, float y, float z, BOOL toggle)  // 0x96A05E4FB321B1BA
```

build 323

## SET_PED_SHOULD_IGNORE_SCENARIO_EXIT_COLLISION_CHECKS

```c
void SET_PED_SHOULD_IGNORE_SCENARIO_EXIT_COLLISION_CHECKS(Ped ped, BOOL p1)  // 0x425AECF167663F48
```

build 323

## SET_PED_SHOULD_IGNORE_SCENARIO_NAV_CHECKS

```c
void SET_PED_SHOULD_IGNORE_SCENARIO_NAV_CHECKS(Any p0, BOOL p1)  // 0x5B6010B3CBC29095
```

build 323

## SET_PED_SHOULD_PLAY_DIRECTED_NORMAL_SCENARIO_EXIT

```c
BOOL SET_PED_SHOULD_PLAY_DIRECTED_NORMAL_SCENARIO_EXIT(Any p0, Any p1, Any p2, Any p3)  // 0xEC6935EBE0847B90
```

build 323 · old names: `_SET_PED_SHOULD_PLAY_DIRECTED_SCENARIO_EXIT`

## SET_PED_SHOULD_PLAY_FLEE_SCENARIO_EXIT

```c
BOOL SET_PED_SHOULD_PLAY_FLEE_SCENARIO_EXIT(Ped ped, Any p1, Any p2, Any p3)  // 0xEEED8FAFEC331A70
```

build 323

## SET_PED_SHOULD_PLAY_IMMEDIATE_SCENARIO_EXIT

```c
void SET_PED_SHOULD_PLAY_IMMEDIATE_SCENARIO_EXIT(Ped ped)  // 0xF1C03A5352243A30
```

build 323

## SET_PED_SHOULD_PLAY_NORMAL_SCENARIO_EXIT

```c
void SET_PED_SHOULD_PLAY_NORMAL_SCENARIO_EXIT(Ped ped)  // 0xA3A9299C4F2ADB98
```

build 323

## SET_PED_SHOULD_PROBE_FOR_SCENARIO_EXITS_IN_ONE_FRAME

```c
void SET_PED_SHOULD_PROBE_FOR_SCENARIO_EXITS_IN_ONE_FRAME(Any p0, BOOL p1)  // 0xCEDA60A74219D064
```

build 323

## SET_PED_SPHERE_DEFENSIVE_AREA

```c
void SET_PED_SPHERE_DEFENSIVE_AREA(Ped ped, float x, float y, float z, float radius, BOOL p5, BOOL p6)  // 0x9D3151A373974804
```

build 323

## SET_PED_STAY_IN_VEHICLE_WHEN_JACKED

```c
void SET_PED_STAY_IN_VEHICLE_WHEN_JACKED(Ped ped, BOOL toggle)  // 0xEDF4079F9D54C9A1
```

build 323

## SET_PED_STEALTH_MOVEMENT

```c
void SET_PED_STEALTH_MOVEMENT(Ped ped, BOOL p1, const char* action)  // 0x88CBB5CEB96B7BD2
```

build 323

> p1 is usually 0 in the scripts. action is either 0 or a pointer to "DEFAULT_ACTION".

## SET_PED_STEER_BIAS

```c
void SET_PED_STEER_BIAS(Ped ped, float value)  // 0x288DF530C92DAD6F
```

build 323 · old names: `_SET_PED_STEER_BIAS`

## SET_PED_STEERS_AROUND_DEAD_BODIES

```c
void SET_PED_STEERS_AROUND_DEAD_BODIES(Ped ped, BOOL toggle)  // 0x2016C603D6B8987C
```

build 323

## SET_PED_STEERS_AROUND_OBJECTS

```c
void SET_PED_STEERS_AROUND_OBJECTS(Ped ped, BOOL toggle)  // 0x1509C089ADC208BF
```

build 323

## SET_PED_STEERS_AROUND_PEDS

```c
void SET_PED_STEERS_AROUND_PEDS(Ped ped, BOOL toggle)  // 0x46F2193B3AD1D891
```

build 323

## SET_PED_STEERS_AROUND_VEHICLES

```c
void SET_PED_STEERS_AROUND_VEHICLES(Ped ped, BOOL toggle)  // 0xEB6FB9D48DDE23EC
```

build 323

## SET_PED_STRAFE_CLIPSET

```c
void SET_PED_STRAFE_CLIPSET(Ped ped, const char* clipSet)  // 0x29A28F3F8CF6D854
```

build 323

> Full list of movement clipsets by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/movementClipsetsCompact.json

## SET_PED_SUFFERS_CRITICAL_HITS

```c
void SET_PED_SUFFERS_CRITICAL_HITS(Ped ped, BOOL toggle)  // 0xEBD76F2359F190AC
```

build 323

> Ped no longer takes critical damage modifiers if set to FALSE.
> Example: Headshotting a player no longer one shots them. Instead they will take the same damage as a torso shot.

## SET_PED_SWEAT

```c
void SET_PED_SWEAT(Ped ped, float sweat)  // 0x27B0405F59637D1F
```

build 323

> Sweat is set to 100.0 or 0.0 in the decompiled scripts.

## SET_PED_TARGET_LOSS_RESPONSE

```c
void SET_PED_TARGET_LOSS_RESPONSE(Ped ped, int responseType)  // 0x0703B9079823DA4A
```

build 323

> enum eTargetLossResponseType
> {
> 	TLR_ExitTask,
> 	TLR_NeverLoseTarget,
> 	TLR_SearchForTarget
> };

## SET_PED_TO_INFORM_RESPECTED_FRIENDS

```c
void SET_PED_TO_INFORM_RESPECTED_FRIENDS(Ped ped, float radius, int maxFriends)  // 0x112942C6E708F70B
```

build 323

## SET_PED_TO_LOAD_COVER

```c
void SET_PED_TO_LOAD_COVER(Ped ped, BOOL toggle)  // 0x332B562EEDA62399
```

build 323

## SET_PED_TO_RAGDOLL

```c
BOOL SET_PED_TO_RAGDOLL(Ped ped, int time1, int time2, int ragdollType, BOOL p4, BOOL p5, BOOL p6)  // 0xAE99FB955581844A
```

build 323

> p4/p5: Unused in TU27
> Ragdoll Types:
> **0**: CTaskNMRelax
> **1**: CTaskNMScriptControl: Hardcoded not to work in networked environments.
> **Else**: CTaskNMBalance
> time1- Time(ms) Ped is in ragdoll mode; only applies to ragdoll types 0 and not 1.
> 
> time2- Unknown time, in milliseconds
> 
> ragdollType-
> 0 : Normal ragdoll
> 1 : Falls with stiff legs/body
> 2 : Narrow leg stumble(may not fall)
> 3 : Wide leg stumble(may not fall)
> 
> p4, p5, p6- No idea. In R*'s scripts they are usually either "true, true, false" or "false, false, false".
> 
> 
> 
> 
> EDIT 3/11/16: unclear what 'mircoseconds' mean-- a microsecond is 1000x a ms, so time2 must be 1000x time1?  more testing needed.  -sob
> 
> Edit Mar 21, 2017: removed part about time2 being the microseconds version of time1. this just isn't correct. time2 is in milliseconds, and time1 and time2 don't seem to be connected in any way.

## SET_PED_TO_RAGDOLL_WITH_FALL

```c
BOOL SET_PED_TO_RAGDOLL_WITH_FALL(Ped ped, int time, int p2, int ragdollType, float x, float y, float z, float velocity, float p8, float p9, float p10, float p11, float p12, float p13)  // 0xD76632D99E4966C8
```

build 323

> Return variable is never used in R*'s scripts.
> 
> Not sure what p2 does. It seems like it would be a time judging by it's usage in R*'s scripts, but didn't seem to affect anything in my testings.
> 
> enum eRagdollType
> {
>  RD_MALE=0,
>  RD_FEMALE = 1,
>  RD_MALE_LARGE = 2,
>  RD_CUSTOM = 3,
> }
> 
> x, y, and z are coordinates, most likely to where the ped will fall.
> 
> p8 to p13 are always 0f in R*'s scripts.
> 
> (Simplified) Example of the usage of the function from R*'s scripts:
> ped::set_ped_to_ragdoll_with_fall(ped, 1500, 2000, 1, -entity::get_entity_forward_vector(ped), 1f, 0f, 0f, 0f, 0f, 0f, 0f);
> 

## SET_PED_TREATED_AS_FRIENDLY

```c
void SET_PED_TREATED_AS_FRIENDLY(Any p0, Any p1, Any p2)  // 0x0F62619393661D6E
```

build 877

## SET_PED_UPPER_BODY_DAMAGE_ONLY

```c
void SET_PED_UPPER_BODY_DAMAGE_ONLY(Ped ped, BOOL toggle)  // 0xAFC976FD0580C7B3
```

build 323

## SET_PED_USING_ACTION_MODE

```c
void SET_PED_USING_ACTION_MODE(Ped ped, BOOL p1, int p2, const char* action)  // 0xD75ACCF5E0FB5367
```

build 323

> p2 is usually -1 in the scripts. action is either 0 or "DEFAULT_ACTION".

## SET_PED_VEHICLE_FORCED_SEAT_USAGE

```c
void SET_PED_VEHICLE_FORCED_SEAT_USAGE(Ped ped, Vehicle vehicle, int seatIndex, int flags, Any p4)  // 0x952F06BEECD775CC
```

build 323

> seatIndex must be <= 2

## SET_PED_VISUAL_FIELD_CENTER_ANGLE

```c
void SET_PED_VISUAL_FIELD_CENTER_ANGLE(Ped ped, float angle)  // 0x3B6405E8AB34A907
```

build 323

## SET_PED_VISUAL_FIELD_MAX_ANGLE

```c
void SET_PED_VISUAL_FIELD_MAX_ANGLE(Ped ped, float value)  // 0x70793BDCA1E854D4
```

build 323

## SET_PED_VISUAL_FIELD_MAX_ELEVATION_ANGLE

```c
void SET_PED_VISUAL_FIELD_MAX_ELEVATION_ANGLE(Ped ped, float angle)  // 0x78D0B67629D75856
```

build 323

> This native refers to the field of vision the ped has above them, starting at 0 degrees. 90f would let the ped see enemies directly above of them.

## SET_PED_VISUAL_FIELD_MIN_ANGLE

```c
void SET_PED_VISUAL_FIELD_MIN_ANGLE(Ped ped, float value)  // 0x2DB492222FB21E26
```

build 323

## SET_PED_VISUAL_FIELD_MIN_ELEVATION_ANGLE

```c
void SET_PED_VISUAL_FIELD_MIN_ELEVATION_ANGLE(Ped ped, float angle)  // 0x7A276EB2C224D70F
```

build 323

> This native refers to the field of vision the ped has below them, starting at 0 degrees. The angle value should be negative.
> -90f should let the ped see 90 degrees below them, for example.

## SET_PED_VISUAL_FIELD_PERIPHERAL_RANGE

```c
void SET_PED_VISUAL_FIELD_PERIPHERAL_RANGE(Ped ped, float range)  // 0x9C74B0BC831B753A
```

build 323

## SET_PED_WEAPON_MOVEMENT_CLIPSET

```c
void SET_PED_WEAPON_MOVEMENT_CLIPSET(Ped ped, const char* clipSet)  // 0x2622E35B77D3ACA2
```

build 323

## SET_PED_WETNESS

```c
void SET_PED_WETNESS(Ped ped, float wetLevel)  // 0xAC0BB4D87777CAE2
```

build 2802

## SET_PED_WETNESS_ENABLED_THIS_FRAME

```c
void SET_PED_WETNESS_ENABLED_THIS_FRAME(Ped ped)  // 0xB5485E4907B53019
```

build 323

> combined with PED::SET_PED_WETNESS_HEIGHT(), this native makes the ped drenched in water up to the height specified in the other function

## SET_PED_WETNESS_HEIGHT

```c
void SET_PED_WETNESS_HEIGHT(Ped ped, float height)  // 0x44CB6447D2571AA0
```

build 323

> It adds the wetness level to the player clothing/outfit. As if player just got out from water surface.
> 
> 

## SET_PED_WILL_ONLY_ATTACK_WANTED_PLAYER

```c
void SET_PED_WILL_ONLY_ATTACK_WANTED_PLAYER(Any p0, Any p1)  // 0x3E9679C1DFCF422C
```

build 877

## SET_POP_CONTROL_SPHERE_THIS_FRAME

```c
void SET_POP_CONTROL_SPHERE_THIS_FRAME(float x, float y, float z, float min, float max)  // 0xD8C3BE3EE94CAF2D
```

build 323

> Min and max are usually 100.0 and 200.0

## SET_RAGDOLL_BLOCKING_FLAGS

```c
void SET_RAGDOLL_BLOCKING_FLAGS(Ped ped, int blockingFlag)  // 0x26695EC767728D84
```

build 323 · old names: `_SET_PED_RAGDOLL_BLOCKING_FLAGS`

> Works for both player and peds,
> 
> enum eRagdollBlockingFlags
> {
>  RBF_BULLET_IMPACT = 0,
>  RBF_VEHICLE_IMPACT = 1,
>  RBF_FIRE = 2,
>  RBF_ELECTROCUTION = 3,
>  RBF_PLAYER_IMPACT = 4,
>  RBF_EXPLOSION = 5,0
>  RBF_IMPACT_OBJECT = 6,
>  RBF_MELEE = 7,
>  RBF_RUBBER_BULLET = 8,
>  RBF_FALLING = 9,
>  RBF_WATER_JET = 10,
>  RBF_DROWNING = 11,
>  _0x9F52E2C4 = 12,
>  RBF_PLAYER_BUMP = 13,
>  RBF_PLAYER_RAGDOLL_BUMP = 14,
>  RBF_PED_RAGDOLL_BUMP = 15,
>  RBF_VEHICLE_GRAB = 16,
>  RBF_SMOKE_GRENADE = 17,
> };
> 
> 

## SET_RELATIONSHIP_BETWEEN_GROUPS

```c
void SET_RELATIONSHIP_BETWEEN_GROUPS(int relationship, Hash group1, Hash group2)  // 0xBF25EB89375A37AD
```

build 323

> Sets the relationship between two groups. This should be called twice (once for each group).
> 
> Relationship types:
> 0 = Companion
> 1 = Respect
> 2 = Like
> 3 = Neutral
> 4 = Dislike
> 5 = Hate
> 255 = Pedestrians
> 
> Example:
> PED::SET_RELATIONSHIP_BETWEEN_GROUPS(2, l_1017, 0xA49E591C);
> PED::SET_RELATIONSHIP_BETWEEN_GROUPS(2, 0xA49E591C, l_1017);

## SET_RELATIONSHIP_GROUP_AFFECTS_WANTED_LEVEL

```c
void SET_RELATIONSHIP_GROUP_AFFECTS_WANTED_LEVEL(Hash group, BOOL p1)  // 0x5615E0C5EB2BC6E2
```

build 877 · old names: `_SET_RELATIONSHIP_GROUP_DONT_AFFECT_WANTED_LEVEL`

## SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME

```c
void SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME(float p0, float p1)  // 0x7A556143A1C03898
```

build 323

## SET_SCENARIO_PEDS_SPAWN_IN_SPHERE_AREA

```c
void SET_SCENARIO_PEDS_SPAWN_IN_SPHERE_AREA(float x, float y, float z, float range, int p4)  // 0x28157D43CF600981
```

build 323

## SET_SCENARIO_PEDS_TO_BE_RETURNED_BY_NEXT_COMMAND

```c
void SET_SCENARIO_PEDS_TO_BE_RETURNED_BY_NEXT_COMMAND(BOOL value)  // 0x14F19A8782C8071E
```

build 323

> Sets a value indicating whether scenario peds should be returned by the next call to a command that returns peds. Eg. GET_CLOSEST_PED.

## SET_SCRIPTED_ANIM_SEAT_OFFSET

```c
void SET_SCRIPTED_ANIM_SEAT_OFFSET(Ped ped, float p1)  // 0x5917BBA32D06C230
```

build 323

## SET_SCRIPTED_CONVERSION_COORD_THIS_FRAME

```c
void SET_SCRIPTED_CONVERSION_COORD_THIS_FRAME(float x, float y, float z)  // 0x5086C7843552CF85
```

build 323

## SET_SYNCHRONIZED_SCENE_HOLD_LAST_FRAME

```c
void SET_SYNCHRONIZED_SCENE_HOLD_LAST_FRAME(int sceneID, BOOL toggle)  // 0x394B9CD12435C981
```

build 323 · old names: `_SET_SYNCHRONIZED_SCENE_OCCLUSION_PORTAL`

## SET_SYNCHRONIZED_SCENE_LOOPED

```c
void SET_SYNCHRONIZED_SCENE_LOOPED(int sceneID, BOOL toggle)  // 0xD9A897A4C6C2974F
```

build 323

## SET_SYNCHRONIZED_SCENE_ORIGIN

```c
void SET_SYNCHRONIZED_SCENE_ORIGIN(int sceneID, float x, float y, float z, float roll, float pitch, float yaw, BOOL p7)  // 0x6ACF6B7225801CD7
```

build 323

## SET_SYNCHRONIZED_SCENE_PHASE

```c
void SET_SYNCHRONIZED_SCENE_PHASE(int sceneID, float phase)  // 0x734292F4F0ABF6D0
```

build 323

## SET_SYNCHRONIZED_SCENE_RATE

```c
void SET_SYNCHRONIZED_SCENE_RATE(int sceneID, float rate)  // 0xB6C49F8A5E295A5D
```

build 323

## SET_TREAT_AS_AMBIENT_PED_FOR_DRIVER_LOCKON

```c
void SET_TREAT_AS_AMBIENT_PED_FOR_DRIVER_LOCKON(Ped ped, BOOL p1)  // 0x2F3C3D9F50681DE4
```

build 323

## SET_USE_CAMERA_HEADING_FOR_DESIRED_DIRECTION_LOCK_ON_TEST

```c
void SET_USE_CAMERA_HEADING_FOR_DESIRED_DIRECTION_LOCK_ON_TEST(Ped ped, BOOL toggle)  // 0xFD325494792302D7
```

build 323 · old names: `SET_TIME_EXCLUSIVE_DISPLAY_TEXTURE`

## SPAWNPOINTS_CANCEL_SEARCH

```c
void SPAWNPOINTS_CANCEL_SEARCH()  // 0xFEE4A5459472A9F8
```

build 323

## SPAWNPOINTS_GET_NUM_SEARCH_RESULTS

```c
int SPAWNPOINTS_GET_NUM_SEARCH_RESULTS()  // 0xA635C11B8C44AFC2
```

build 323

## SPAWNPOINTS_GET_SEARCH_RESULT

```c
void SPAWNPOINTS_GET_SEARCH_RESULT(int randomInt, float* x, float* y, float* z)  // 0x280C7E3AC7F56E90
```

build 323

## SPAWNPOINTS_GET_SEARCH_RESULT_FLAGS

```c
void SPAWNPOINTS_GET_SEARCH_RESULT_FLAGS(int p0, int* p1)  // 0xB782F8238512BAD5
```

build 323

## SPAWNPOINTS_IS_SEARCH_ACTIVE

```c
BOOL SPAWNPOINTS_IS_SEARCH_ACTIVE()  // 0x3C67506996001F5E
```

build 323

## SPAWNPOINTS_IS_SEARCH_COMPLETE

```c
BOOL SPAWNPOINTS_IS_SEARCH_COMPLETE()  // 0xA586FBEB32A53DBB
```

build 323

## SPAWNPOINTS_IS_SEARCH_FAILED

```c
BOOL SPAWNPOINTS_IS_SEARCH_FAILED()  // 0xF445DE8DA80A1792
```

build 323

## SPAWNPOINTS_START_SEARCH

```c
void SPAWNPOINTS_START_SEARCH(float p0, float p1, float p2, float p3, float p4, int interiorFlags, float scale, int duration)  // 0x2DF9038C90AD5264
```

build 323

## SPAWNPOINTS_START_SEARCH_IN_ANGLED_AREA

```c
void SPAWNPOINTS_START_SEARCH_IN_ANGLED_AREA(float x1, float y1, float z1, float x2, float y2, float z2, float width, int interiorFlags, float scale, int duration)  // 0xB2AFF10216DEFA2F
```

build 323

## SPECIAL_FUNCTION_DO_NOT_USE

```c
void SPECIAL_FUNCTION_DO_NOT_USE(Ped ped, BOOL p1)  // 0xF9ACF4A08098EA25
```

build 323

> p1 was always 1 (true).
> 
> Kicks the ped from the current vehicle and keeps the rendering-focus on this ped (also disables its collision). If doing this for your player ped, you'll still be able to drive the vehicle.

## STOP_ANY_PED_MODEL_BEING_SUPPRESSED

```c
void STOP_ANY_PED_MODEL_BEING_SUPPRESSED()  // 0xB47BD05FA66B40CF
```

build 323

## STOP_PED_WEAPON_FIRING_WHEN_DROPPED

```c
void STOP_PED_WEAPON_FIRING_WHEN_DROPPED(Ped ped)  // 0xC158D28142A34608
```

build 323

## SUPPRESS_AMBIENT_PED_AGGRESSIVE_CLEANUP_THIS_FRAME

```c
void SUPPRESS_AMBIENT_PED_AGGRESSIVE_CLEANUP_THIS_FRAME()  // 0x5A7F62FDA59759BD
```

build 323

## TAKE_OWNERSHIP_OF_SYNCHRONIZED_SCENE

```c
void TAKE_OWNERSHIP_OF_SYNCHRONIZED_SCENE(int scene)  // 0xCD9CC7E200A52A6F
```

build 323 · old names: `_DISPOSE_SYNCHRONIZED_SCENE`

## TELL_GROUP_PEDS_IN_AREA_TO_ATTACK

```c
void TELL_GROUP_PEDS_IN_AREA_TO_ATTACK(Ped ped, float x, float y, float z, float radius, Hash hash)  // 0xAD27D957598E49E9
```

build 1290

## TOGGLE_SCENARIO_PED_COWER_IN_PLACE

```c
void TOGGLE_SCENARIO_PED_COWER_IN_PLACE(Ped ped, BOOL toggle)  // 0x9A77DFD295E29B09
```

build 323 · old names: `_SET_PED_SCARED_WHEN_USING_SCENARIO`

## TRIGGER_IDLE_ANIMATION_ON_PED

```c
void TRIGGER_IDLE_ANIMATION_ON_PED(Ped ped)  // 0xC2EE020F5FB4DB53
```

build 323

## TRIGGER_PED_SCENARIO_PANICEXITTOFLEE

```c
BOOL TRIGGER_PED_SCENARIO_PANICEXITTOFLEE(Any p0, Any p1, Any p2, Any p3)  // 0x25361A96E0F7E419
```

build 323

## UNREGISTER_PEDHEADSHOT

```c
void UNREGISTER_PEDHEADSHOT(int id)  // 0x96B1361D9B24C2FF
```

build 323

> https://gtaforums.com/topic/885580-ped-headshotmugshot-txd/

## UPDATE_PED_HEAD_BLEND_DATA

```c
void UPDATE_PED_HEAD_BLEND_DATA(Ped ped, float shapeMix, float skinMix, float thirdMix)  // 0x723538F61C647C5A
```

build 323

> See SET_PED_HEAD_BLEND_DATA().

## WAS_PED_KILLED_BY_STEALTH

```c
BOOL WAS_PED_KILLED_BY_STEALTH(Ped ped)  // 0xF9800AA1A771B000
```

build 323

## WAS_PED_KILLED_BY_TAKEDOWN

```c
BOOL WAS_PED_KILLED_BY_TAKEDOWN(Ped ped)  // 0x7F08E26039C7347C
```

build 323

## WAS_PED_KNOCKED_OUT

```c
BOOL WAS_PED_KNOCKED_OUT(Ped ped)  // 0x61767F73EACEED21
```

build 323

## WAS_PED_SKELETON_UPDATED

```c
BOOL WAS_PED_SKELETON_UPDATED(Ped ped)  // 0x11B499C1E0FF8559
```

build 323

> Despite this function's name, it simply returns whether the specified handle is a Ped.

