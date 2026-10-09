# WEAPON natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _GET_AMMO_IN_VEHICLE_WEAPON_CLIP

```c
BOOL _GET_AMMO_IN_VEHICLE_WEAPON_CLIP(Vehicle vehicle, int seat, int* ammo)  // 0x2857938C5D407AFA
```

build 3407

## _GET_TIME_BEFORE_VEHICLE_WEAPON_RELOAD_FINISHES

```c
int _GET_TIME_BEFORE_VEHICLE_WEAPON_RELOAD_FINISHES(Vehicle vehicle, int seat)  // 0xC8C6F4B1CDEB40EF
```

build 3407

## _GET_VEHICLE_WEAPON_RELOAD_TIME

```c
float _GET_VEHICLE_WEAPON_RELOAD_TIME(Vehicle vehicle, int seat)  // 0xD0AD348FFD7A6868
```

build 3407

## _HAS_WEAPON_RELOADING_IN_VEHICLE

```c
BOOL _HAS_WEAPON_RELOADING_IN_VEHICLE(Vehicle vehicle, int seat)  // 0x8062F07153F4446F
```

build 3407

## _SET_AMMO_IN_VEHICLE_WEAPON_CLIP

```c
BOOL _SET_AMMO_IN_VEHICLE_WEAPON_CLIP(Vehicle vehicle, int seat, int ammo)  // 0x873906720EE842C3
```

build 3407

## _SET_WEAPON_PED_DAMAGE_MODIFIER

```c
void _SET_WEAPON_PED_DAMAGE_MODIFIER(Hash weapon, float damageModifier)  // 0x1091922715B68DF0
```

build 3095

## _TRIGGER_VEHICLE_WEAPON_RELOAD

```c
BOOL _TRIGGER_VEHICLE_WEAPON_RELOAD(Vehicle vehicle, int seat, Ped ped)  // 0x5B1513F27F279A44
```

build 3407

## ADD_AMMO_TO_PED

```c
void ADD_AMMO_TO_PED(Ped ped, Hash weaponHash, int ammo)  // 0x78F0424C34306220
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## ADD_PED_AMMO_BY_TYPE

```c
void ADD_PED_AMMO_BY_TYPE(Ped ped, Hash ammoTypeHash, int ammo)  // 0x2472622CE1F2D45F
```

build 1103 · old names: `_ADD_PED_AMMO`, `_ADD_AMMO_TO_PED_BY_TYPE`

> Ammo types: https://gist.github.com/root-cause/faf41f59f7a6d818b7db0b839bd147c1

## CAN_USE_WEAPON_ON_PARACHUTE

```c
BOOL CAN_USE_WEAPON_ON_PARACHUTE(Hash weaponHash)  // 0xBC7BE5ABC0879F74
```

build 323

> this returns if you can use the weapon while using a parachute
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## CLEAR_ENTITY_LAST_WEAPON_DAMAGE

```c
void CLEAR_ENTITY_LAST_WEAPON_DAMAGE(Entity entity)  // 0xAC678E40BE7C74D2
```

build 323

## CLEAR_PED_LAST_WEAPON_DAMAGE

```c
void CLEAR_PED_LAST_WEAPON_DAMAGE(Ped ped)  // 0x0E98F88A24C5F4B8
```

build 323

> Does NOT seem to work with HAS_PED_BEEN_DAMAGED_BY_WEAPON. Use CLEAR_ENTITY_LAST_WEAPON_DAMAGE and HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON instead.

## CREATE_AIR_DEFENCE_ANGLED_AREA

```c
int CREATE_AIR_DEFENCE_ANGLED_AREA(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7, float p8, float radius, Hash weaponHash)  // 0x9DA58CDBF6BDBC08
```

build 1011 · old names: `_CREATE_AIR_DEFENSE_AREA`

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## CREATE_AIR_DEFENCE_SPHERE

```c
int CREATE_AIR_DEFENCE_SPHERE(float x, float y, float z, float radius, float p4, float p5, float p6, Hash weaponHash)  // 0x91EF34584710BE99
```

build 573 · old names: `_CREATE_AIR_DEFENSE_SPHERE`

> Both coordinates are from objects in the decompiled scripts. The only weapon hash used in the decompiled scripts is weapon_air_defence_gun. These two natives are used by the yacht script, decompiled scripts suggest it and the weapon hash used (valkyrie's rockets) are also used by yachts.

## CREATE_WEAPON_OBJECT

```c
Object CREATE_WEAPON_OBJECT(Hash weaponHash, int ammoCount, float x, float y, float z, BOOL showWorldModel, float scale, Any p7, Any p8, Any p9)  // 0x9541D3CF0D398F36
```

build 323

> Now has 8 params.

## DOES_AIR_DEFENCE_SPHERE_EXIST

```c
BOOL DOES_AIR_DEFENCE_SPHERE_EXIST(int zoneId)  // 0xCD79A550999D7D4F
```

build 678 · old names: `_DOES_AIR_DEFENSE_ZONE_EXIST`

## DOES_WEAPON_TAKE_WEAPON_COMPONENT

```c
BOOL DOES_WEAPON_TAKE_WEAPON_COMPONENT(Hash weaponHash, Hash componentHash)  // 0x5CEE3DF569CECAB0
```

build 323

> Full list of weapons & components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## ENABLE_LASER_SIGHT_RENDERING

```c
void ENABLE_LASER_SIGHT_RENDERING(BOOL toggle)  // 0xC8B46D7727D864AA
```

build 323

> Enables laser sight on any weapon.
> 
> It doesn't work. Neither on tick nor OnKeyDown

## EXPLODE_PROJECTILES

```c
void EXPLODE_PROJECTILES(Ped ped, Hash weaponHash, BOOL instant)  // 0xFC4BD125DE7611E4
```

build 323

## FIRE_AIR_DEFENCE_SPHERE_WEAPON_AT_POSITION

```c
void FIRE_AIR_DEFENCE_SPHERE_WEAPON_AT_POSITION(int zoneId, float x, float y, float z)  // 0x44F1012B69313374
```

build 573 · old names: `_FIRE_AIR_DEFENSE_WEAPON`

## GET_AMMO_IN_CLIP

```c
BOOL GET_AMMO_IN_CLIP(Ped ped, Hash weaponHash, int* ammo)  // 0x2E1202248937775C
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_AMMO_IN_PED_WEAPON

```c
int GET_AMMO_IN_PED_WEAPON(Ped ped, Hash weaponhash)  // 0x015A522136D7F951
```

build 323

> WEAPON::GET_AMMO_IN_PED_WEAPON(PLAYER::PLAYER_PED_ID(), a_0)
> 
> From decompiled scripts
> Returns total ammo in weapon
> 
> GTALua Example :
> natives.WEAPON.GET_AMMO_IN_PED_WEAPON(plyPed, WeaponHash)
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_BEST_PED_WEAPON

```c
Hash GET_BEST_PED_WEAPON(Ped ped, BOOL bIgnoreAmmoCheck)  // 0x8483E98E8B888AE2
```

build 323

> bIgnoreAmmoCheck is always false in the scripts.

## GET_CURRENT_PED_VEHICLE_WEAPON

```c
BOOL GET_CURRENT_PED_VEHICLE_WEAPON(Ped ped, Hash* weaponHash)  // 0x1017582BCD3832DC
```

build 323

> Example in VB
> 
>     Public Shared Function GetVehicleCurrentWeapon(Ped As Ped) As Integer
>         Dim arg As New OutputArgument()
>         Native.Function.Call(Hash.GET_CURRENT_PED_VEHICLE_WEAPON, Ped, arg)
>         Return arg.GetResult(Of Integer)()
>     End Function
> 
> Usage:
> If GetVehicleCurrentWeapon(Game.Player.Character) = -821520672 Then ...Do something
> Note: -821520672 = VEHICLE_WEAPON_PLANE_ROCKET

## GET_CURRENT_PED_WEAPON

```c
BOOL GET_CURRENT_PED_WEAPON(Ped ped, Hash* weaponHash, BOOL doDeadCheck)  // 0x3A87E44BB9A01D54
```

build 323

> Returns true if the hash of the equipped weapon object equals the weapon hash.
> doDeadCheck does nothing in release builds.

## GET_CURRENT_PED_WEAPON_ENTITY_INDEX

```c
Entity GET_CURRENT_PED_WEAPON_ENTITY_INDEX(Ped ped, BOOL doDeadCheck)  // 0x3B390A939AF0B5FC
```

build 323

> doDeadCheck does nothing in release builds.

## GET_IS_PED_GADGET_EQUIPPED

```c
BOOL GET_IS_PED_GADGET_EQUIPPED(Ped ped, Hash gadgetHash)  // 0xF731332072F5156C
```

build 323

> gadgetHash - was always 0xFBAB5776 ("GADGET_PARACHUTE").

## GET_LOCKON_DISTANCE_OF_CURRENT_PED_WEAPON

```c
float GET_LOCKON_DISTANCE_OF_CURRENT_PED_WEAPON(Ped ped)  // 0x840F03E9041E2C9C
```

build 323 · old names: `_GET_LOCKON_RANGE_OF_CURRENT_PED_WEAPON`

## GET_MAX_AMMO

```c
BOOL GET_MAX_AMMO(Ped ped, Hash weaponHash, int* ammo)  // 0xDC16122C7A20C933
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_MAX_AMMO_BY_TYPE

```c
BOOL GET_MAX_AMMO_BY_TYPE(Ped ped, Hash ammoTypeHash, int* ammo)  // 0x585847C5E4E11709
```

build 1103 · old names: `_GET_MAX_AMMO_2`, `_GET_MAX_AMMO_BY_TYPE`

> Returns the max ammo for an ammo type. Ammo types: https://gist.github.com/root-cause/faf41f59f7a6d818b7db0b839bd147c1

## GET_MAX_AMMO_IN_CLIP

```c
int GET_MAX_AMMO_IN_CLIP(Ped ped, Hash weaponHash, BOOL p2)  // 0xA38DCFFCEA8962FA
```

build 323

> p2 is mostly 1 in the scripts.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_MAX_RANGE_OF_CURRENT_PED_WEAPON

```c
float GET_MAX_RANGE_OF_CURRENT_PED_WEAPON(Ped ped)  // 0x814C9D19DFD69679
```

build 323

## GET_PED_AMMO_BY_TYPE

```c
int GET_PED_AMMO_BY_TYPE(Ped ped, Hash ammoTypeHash)  // 0x39D22031557946C1
```

build 323

## GET_PED_AMMO_TYPE_FROM_WEAPON

```c
Hash GET_PED_AMMO_TYPE_FROM_WEAPON(Ped ped, Hash weaponHash)  // 0x7FEAD38B326B9F74
```

build 323 · old names: `_GET_PED_AMMO_TYPE`

> Returns the current ammo type of the specified ped's specified weapon.
> MkII magazines will change the return value, like Pistol MkII returning AMMO_PISTOL without any components and returning AMMO_PISTOL_TRACER after Tracer Rounds component is attached.
> Use GET_PED_ORIGINAL_AMMO_TYPE_FROM_WEAPON if you always want AMMO_PISTOL.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_PED_LAST_WEAPON_IMPACT_COORD

```c
BOOL GET_PED_LAST_WEAPON_IMPACT_COORD(Ped ped, Vector3* coords)  // 0x6C4D0409BA1A2BC2
```

build 323

> Pass ped. Pass address of Vector3.
> The coord will be put into the Vector3.
> The return will determine whether there was a coord found or not.

## GET_PED_ORIGINAL_AMMO_TYPE_FROM_WEAPON

```c
Hash GET_PED_ORIGINAL_AMMO_TYPE_FROM_WEAPON(Ped ped, Hash weaponHash)  // 0xF489B44DD5AF4BD9
```

build 1103 · old names: `_GET_PED_AMMO_TYPE_FROM_WEAPON_2`

> Returns the base/default ammo type of the specified ped's specified weapon.
> Use GET_PED_AMMO_TYPE_FROM_WEAPON if you want current ammo type (like AMMO_MG_INCENDIARY/AMMO_MG_TRACER while using MkII magazines) and use this if you want base ammo type. (AMMO_MG)
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_PED_WEAPON_CAMO_INDEX

```c
int GET_PED_WEAPON_CAMO_INDEX(Ped ped, Hash weaponHash)  // 0xA2C9AC24B4061285
```

build 1103

## GET_PED_WEAPON_COMPONENT_TINT_INDEX

```c
int GET_PED_WEAPON_COMPONENT_TINT_INDEX(Ped ped, Hash weaponHash, Hash camoComponentHash)  // 0xF0A60040BE558F2D
```

build 1103 · old names: `_GET_PED_WEAPON_LIVERY_COLOR`

> Returns -1 if camoComponentHash is invalid/not attached to the weapon.
> Full list of weapons, components, tint indexes & weapon liveries by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_PED_WEAPON_TINT_INDEX

```c
int GET_PED_WEAPON_TINT_INDEX(Ped ped, Hash weaponHash)  // 0x2B9EEDC07BD06B9F
```

build 323

> Full list of weapons, components & tint indexes by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_PED_WEAPONTYPE_IN_SLOT

```c
Hash GET_PED_WEAPONTYPE_IN_SLOT(Ped ped, Hash weaponSlot)  // 0xEFFED78E9011134D
```

build 323

## GET_SELECTED_PED_WEAPON

```c
Hash GET_SELECTED_PED_WEAPON(Ped ped)  // 0x0A6DB4965674D243
```

build 323

> Returns the hash of the weapon. 
> 
>             var num7 = WEAPON::GET_SELECTED_PED_WEAPON(num4);
>             sub_27D3(num7);
>             switch (num7)
>             {
>                 case 0x24B17070:
> 
> Also see WEAPON::GET_CURRENT_PED_WEAPON. Difference?
> 
> -------------------------------------------------------------------------
> 
> The difference is that GET_SELECTED_PED_WEAPON simply returns the ped's current weapon hash but GET_CURRENT_PED_WEAPON also checks the weapon object and returns true if the hash of the weapon object equals the weapon hash
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPON_CLIP_SIZE

```c
int GET_WEAPON_CLIP_SIZE(Hash weaponHash)  // 0x583BE370B1EC6EB4
```

build 323

> // Returns the size of the default weapon component clip.
> 
> Use it like this:
> 
> char cClipSize[32];
> Hash cur;
> if (WEAPON::GET_CURRENT_PED_WEAPON(playerPed, &cur, 1))
> {
>     if (WEAPON::IS_WEAPON_VALID(cur))
>     {
>         int iClipSize = WEAPON::GET_WEAPON_CLIP_SIZE(cur);
>         sprintf_s(cClipSize, "ClipSize: %.d", iClipSize);
>         vDrawString(cClipSize, 0.5f, 0.5f);
>     }
> }
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPON_COMPONENT_HUD_STATS

```c
BOOL GET_WEAPON_COMPONENT_HUD_STATS(Hash componentHash, Any* outData)  // 0xB3CAF387AE12E9F8
```

build 323

## GET_WEAPON_COMPONENT_TYPE_MODEL

```c
Hash GET_WEAPON_COMPONENT_TYPE_MODEL(Hash componentHash)  // 0x0DB57B41EC1DB083
```

build 323

## GET_WEAPON_COMPONENT_VARIANT_EXTRA_COUNT

```c
int GET_WEAPON_COMPONENT_VARIANT_EXTRA_COUNT(Hash componentHash)  // 0x6558AC7C17BFEF58
```

build 372 · old names: `_GET_WEAPON_COMPONENT_VARIANT_EXTRA_COMPONENT_COUNT`

> Returns the amount of extra components the specified component has.
> Returns -1 if the component isn't of type CWeaponComponentVariantModel.

## GET_WEAPON_COMPONENT_VARIANT_EXTRA_MODEL

```c
Hash GET_WEAPON_COMPONENT_VARIANT_EXTRA_MODEL(Hash componentHash, int extraComponentIndex)  // 0x4D1CB8DC40208A17
```

build 372 · old names: `_GET_WEAPON_COMPONENT_VARIANT_EXTRA_COMPONENT_MODEL`

> Returns the model hash of the extra component at specified index.

## GET_WEAPON_DAMAGE

```c
float GET_WEAPON_DAMAGE(Hash weaponHash, Hash componentHash)  // 0x3133B907D8B32053
```

build 323 · old names: `_GET_WEAPON_DAMAGE`

> This native does not return damages of weapons from the melee and explosive group.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPON_DAMAGE_TYPE

```c
int GET_WEAPON_DAMAGE_TYPE(Hash weaponHash)  // 0x3BE0BB12D25FB305
```

build 323

> enum class eDamageType
> {
> 	UNKNOWN = 0,
> 	NONE = 1,
> 	MELEE = 2,
> 	BULLET = 3,
> 	BULLET_RUBBER = 4,
> 	EXPLOSIVE = 5,
> 	FIRE = 6,
> 	COLLISION = 7,
> 	FALL = 8,
> 	DROWN = 9,
> 	ELECTRIC = 10,
> 	BARBED_WIRE = 11,
> 	FIRE_EXTINGUISHER = 12,
> 	SMOKE = 13,
> 	WATER_CANNON = 14,
> 	TRANQUILIZER = 15,
> };
> 
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPON_HUD_STATS

```c
BOOL GET_WEAPON_HUD_STATS(Hash weaponHash, Any* outData)  // 0xD92C739EE34C9EBA
```

build 323

> struct WeaponHudStatsData
> {
>     BYTE hudDamage; // 0x0000
>     char _0x0001[0x7]; // 0x0001
>     BYTE hudSpeed; // 0x0008
>     char _0x0009[0x7]; // 0x0009
>     BYTE hudCapacity; // 0x0010
>     char _0x0011[0x7]; // 0x0011
>     BYTE hudAccuracy; // 0x0018
>     char _0x0019[0x7]; // 0x0019
>     BYTE hudRange; // 0x0020
> };
> 
> Usage:
> 
> WeaponHudStatsData data;
> if (GET_WEAPON_HUD_STATS(weaponHash, (int *)&data))
> {
>     // BYTE damagePercentage = data.hudDamage and so on
> }
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPON_OBJECT_COMPONENT_TINT_INDEX

```c
int GET_WEAPON_OBJECT_COMPONENT_TINT_INDEX(Object weaponObject, Hash camoComponentHash)  // 0xB3EA4FEABF41464B
```

build 1103 · old names: `_GET_WEAPON_OBJECT_LIVERY_COLOR`

> Returns -1 if camoComponentHash is invalid/not attached to the weapon object.
> Full list of weapons, components, tint indexes & weapon liveries by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPON_OBJECT_FROM_PED

```c
Object GET_WEAPON_OBJECT_FROM_PED(Ped ped, BOOL p1)  // 0xCAE1DC9A0E22A16D
```

build 323

> Drops the current weapon and returns the object
> 
> Unknown behavior when unarmed.

## GET_WEAPON_OBJECT_TINT_INDEX

```c
int GET_WEAPON_OBJECT_TINT_INDEX(Object weapon)  // 0xCD183314F7CD2E57
```

build 323

## GET_WEAPON_TIME_BETWEEN_SHOTS

```c
float GET_WEAPON_TIME_BETWEEN_SHOTS(Hash weaponHash)  // 0x065D2AACAD8CF7A4
```

build 1290 · old names: `_GET_WEAPON_TIME_BETWEEN_SHOTS`

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPON_TINT_COUNT

```c
int GET_WEAPON_TINT_COUNT(Hash weaponHash)  // 0x5DCF6C5CAB2E9BF7
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GET_WEAPONTYPE_GROUP

```c
Hash GET_WEAPONTYPE_GROUP(Hash weaponHash)  // 0xC3287EE3050FB74C
```

build 323

## GET_WEAPONTYPE_MODEL

```c
Hash GET_WEAPONTYPE_MODEL(Hash weaponHash)  // 0xF46CDC33180FDA94
```

build 323

> Returns the model of any weapon.

## GET_WEAPONTYPE_SLOT

```c
Hash GET_WEAPONTYPE_SLOT(Hash weaponHash)  // 0x4215460B9B8B7FA0
```

build 323

## GIVE_DELAYED_WEAPON_TO_PED

```c
void GIVE_DELAYED_WEAPON_TO_PED(Ped ped, Hash weaponHash, int ammoCount, BOOL bForceInHand)  // 0xB282DC6EBD803C75
```

build 323

> Gives a weapon to PED with a delay, example:
> 
> WEAPON::GIVE_DELAYED_WEAPON_TO_PED(PED::PLAYER_PED_ID(), MISC::GET_HASH_KEY("WEAPON_PISTOL"), 1000, false)
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GIVE_LOADOUT_TO_PED

```c
void GIVE_LOADOUT_TO_PED(Ped ped, Hash loadoutHash)  // 0x68F8BE6AF5CDF8A6
```

build 505 · old names: `_GIVE_LOADOUT_TO_PED`

> Gives the specified loadout to the specified ped. 
> Loadouts are defined in common.rpf\data\ai\loadouts.meta

## GIVE_WEAPON_COMPONENT_TO_PED

```c
void GIVE_WEAPON_COMPONENT_TO_PED(Ped ped, Hash weaponHash, Hash componentHash)  // 0xD966D51AA5B28BB9
```

build 323

> Full list of weapons & components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## GIVE_WEAPON_COMPONENT_TO_WEAPON_OBJECT

```c
void GIVE_WEAPON_COMPONENT_TO_WEAPON_OBJECT(Object weaponObject, Hash componentHash)  // 0x33E179436C0B31DB
```

build 323

> componentHash:
> (use WEAPON::GET_WEAPON_COMPONENT_TYPE_MODEL() to get hash value)
> ${component_at_ar_flsh}, ${component_at_ar_supp}, ${component_at_pi_flsh}, ${component_at_scope_large}, ${component_at_ar_supp_02}

## GIVE_WEAPON_OBJECT_TO_PED

```c
void GIVE_WEAPON_OBJECT_TO_PED(Object weaponObject, Ped ped)  // 0xB1FA61371AF7C4B7
```

build 323

## GIVE_WEAPON_TO_PED

```c
void GIVE_WEAPON_TO_PED(Ped ped, Hash weaponHash, int ammoCount, BOOL isHidden, BOOL bForceInHand)  // 0xBF0FD6E56C964FCB
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON

```c
BOOL HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON(Entity entity, Hash weaponHash, int weaponType)  // 0x131D401334815E94
```

build 323

> It determines what weapons caused damage:
> 
> If you want to define only a specific weapon, second parameter=weapon hash code, third parameter=0
> If you want to define any melee weapon, second parameter=0, third parameter=1.
> If you want to identify any weapon (firearms, melee, rockets, etc.), second parameter=0, third parameter=2.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## HAS_PED_BEEN_DAMAGED_BY_WEAPON

```c
BOOL HAS_PED_BEEN_DAMAGED_BY_WEAPON(Ped ped, Hash weaponHash, int weaponType)  // 0x2D343D2219CD027A
```

build 323

> It determines what weapons caused damage:
> 
> If you want to define only a specific weapon, second parameter=weapon hash code, third parameter=0
> If you want to define any melee weapon, second parameter=0, third parameter=1.
> If you want to identify any weapon (firearms, melee, rockets, etc.), second parameter=0, third parameter=2.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## HAS_PED_GOT_WEAPON

```c
BOOL HAS_PED_GOT_WEAPON(Ped ped, Hash weaponHash, BOOL p2)  // 0x8DECB02F88F428BC
```

build 323

> p2 should be FALSE, otherwise it seems to always return FALSE
> 
> Bool does not check if the weapon is current equipped, unfortunately.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## HAS_PED_GOT_WEAPON_COMPONENT

```c
BOOL HAS_PED_GOT_WEAPON_COMPONENT(Ped ped, Hash weaponHash, Hash componentHash)  // 0xC593212475FAE340
```

build 323

> Full list of weapons & components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## HAS_PED_GOT_WEAPON_MANAGER

```c
BOOL HAS_PED_GOT_WEAPON_MANAGER(Ped ped)  // 0xDB7CCCD153740D8E
```

build 3889

## HAS_VEHICLE_GOT_PROJECTILE_ATTACHED

```c
BOOL HAS_VEHICLE_GOT_PROJECTILE_ATTACHED(Ped driver, Vehicle vehicle, Hash weaponHash, Any p3)  // 0x717C8481234E3B88
```

build 323

> Fourth Parameter = unsure, almost always -1

## HAS_WEAPON_ASSET_LOADED

```c
BOOL HAS_WEAPON_ASSET_LOADED(Hash weaponHash)  // 0x36E353271F0E90EE
```

build 323

## HAS_WEAPON_GOT_WEAPON_COMPONENT

```c
BOOL HAS_WEAPON_GOT_WEAPON_COMPONENT(Object weapon, Hash componentHash)  // 0x76A18844E743BF91
```

build 323

> see DOES_WEAPON_TAKE_WEAPON_COMPONENT for full list of weapons & components

## HIDE_PED_WEAPON_FOR_SCRIPTED_CUTSCENE

```c
void HIDE_PED_WEAPON_FOR_SCRIPTED_CUTSCENE(Ped ped, BOOL toggle)  // 0x6F6981D2253C208F
```

build 323

> Hides the players weapon during a cutscene.

## IS_AIR_DEFENCE_SPHERE_IN_AREA

```c
BOOL IS_AIR_DEFENCE_SPHERE_IN_AREA(float x, float y, float z, float radius, int* outZoneId)  // 0xDAB963831DBFD3F4
```

build 1103 · old names: `_IS_AIR_DEFENSE_ZONE_INSIDE_SPHERE`, `_IS_ANY_AIR_DEFENSE_ZONE_INSIDE_SPHERE`

## IS_FLASH_LIGHT_ON

```c
BOOL IS_FLASH_LIGHT_ON(Ped ped)  // 0x4B7620C47217126C
```

build 323 · old names: `SET_WEAPON_SMOKEGRENADE_ASSIGNED`

## IS_PED_ARMED

```c
BOOL IS_PED_ARMED(Ped ped, int typeFlags)  // 0x475768A975D5AD17
```

build 323

> Checks if the ped is currently equipped with a weapon matching a bit specified using a bitwise-or in typeFlags.
> 
> Type flag bit values:
> 1 = Melee weapons
> 2 = Explosive weapons
> 4 = Any other weapons
> 
> Not specifying any bit will lead to the native *always* returning 'false', and for example specifying '4 | 2' will check for any weapon except fists and melee weapons.
> 7 returns true if you are equipped with any weapon except your fists.
> 6 returns true if you are equipped with any weapon except melee weapons.
> 5 returns true if you are equipped with any weapon except the Explosives weapon group.
> 4 returns true if you are equipped with any weapon except Explosives weapon group AND melee weapons.
> 3 returns true if you are equipped with either Explosives or Melee weapons (the exact opposite of 4).
> 2 returns true only if you are equipped with any weapon from the Explosives weapon group.
> 1 returns true only if you are equipped with any Melee weapon.
> 0 never returns true.
> 
> Note: When I say "Explosives weapon group", it does not include the Jerry can and Fire Extinguisher.

## IS_PED_CURRENT_WEAPON_SILENCED

```c
BOOL IS_PED_CURRENT_WEAPON_SILENCED(Ped ped)  // 0x65F0C5AE05943EC7
```

build 323

> This native returns a true or false value.
> 
> Ped ped = The ped whose weapon you want to check.

## IS_PED_WEAPON_COMPONENT_ACTIVE

```c
BOOL IS_PED_WEAPON_COMPONENT_ACTIVE(Ped ped, Hash weaponHash, Hash componentHash)  // 0x0D78DE0572D3969E
```

build 323

> Full list of weapons & components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## IS_PED_WEAPON_READY_TO_SHOOT

```c
BOOL IS_PED_WEAPON_READY_TO_SHOOT(Ped ped)  // 0xB80CA294F2F26749
```

build 323

## IS_WEAPON_VALID

```c
BOOL IS_WEAPON_VALID(Hash weaponHash)  // 0x937C71165CF334B3
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## MAKE_PED_RELOAD

```c
BOOL MAKE_PED_RELOAD(Ped ped)  // 0x20AE33F3AC9C0033
```

build 323

> Forces a ped to reload only if they are able to; if they have a full magazine, they will not reload.

## REFILL_AMMO_INSTANTLY

```c
BOOL REFILL_AMMO_INSTANTLY(Ped ped)  // 0x8C0D57EA686FAD87
```

build 323 · old names: `_PED_SKIP_NEXT_RELOADING`

## REMOVE_AIR_DEFENCE_SPHERE

```c
BOOL REMOVE_AIR_DEFENCE_SPHERE(int zoneId)  // 0x0ABF535877897560
```

build 573 · old names: `_REMOVE_AIR_DEFENSE_ZONE`

## REMOVE_ALL_AIR_DEFENCE_SPHERES

```c
void REMOVE_ALL_AIR_DEFENCE_SPHERES()  // 0x1E45B34ADEBEE48E
```

build 573 · old names: `_REMOVE_ALL_AIR_DEFENSE_ZONES`

## REMOVE_ALL_PED_WEAPONS

```c
void REMOVE_ALL_PED_WEAPONS(Ped ped, BOOL p1)  // 0xF25DF915FA38C5F3
```

build 323

> setting the last params to false it does that same so I would suggest its not a toggle

## REMOVE_ALL_PROJECTILES_OF_TYPE

```c
void REMOVE_ALL_PROJECTILES_OF_TYPE(Hash weaponHash, BOOL explode)  // 0xFC52E0F37E446528
```

build 323

> If `explode` true, then removal is done through exploding the projectile. Basically the same as EXPLODE_PROJECTILES but without defining the owner ped.

## REMOVE_WEAPON_ASSET

```c
void REMOVE_WEAPON_ASSET(Hash weaponHash)  // 0xAA08EF13F341C8FC
```

build 323

## REMOVE_WEAPON_COMPONENT_FROM_PED

```c
void REMOVE_WEAPON_COMPONENT_FROM_PED(Ped ped, Hash weaponHash, Hash componentHash)  // 0x1E8BE90C74FB4C09
```

build 323

> Full list of weapons & components by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## REMOVE_WEAPON_COMPONENT_FROM_WEAPON_OBJECT

```c
void REMOVE_WEAPON_COMPONENT_FROM_WEAPON_OBJECT(Object object, Hash componentHash)  // 0xF7D82B0D66777611
```

build 323

> see DOES_WEAPON_TAKE_WEAPON_COMPONENT for full list of weapons & components

## REMOVE_WEAPON_FROM_PED

```c
void REMOVE_WEAPON_FROM_PED(Ped ped, Hash weaponHash)  // 0x4899CB088EDF59B8
```

build 323

> This native removes a specified weapon from your selected ped.
> 
> Example:
> C#:
> Function.Call(Hash.REMOVE_WEAPON_FROM_PED, Game.Player.Character, 0x99B507EA);
> 
> C++:
> WEAPON::REMOVE_WEAPON_FROM_PED(PLAYER::PLAYER_PED_ID(), 0x99B507EA);
> 
> The code above removes the knife from the player.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## REQUEST_WEAPON_ASSET

```c
void REQUEST_WEAPON_ASSET(Hash weaponHash, int p1, int p2)  // 0x5443438F033E29C3
```

build 323

> Nearly every instance of p1 I found was 31. Nearly every instance of p2 I found was 0.
> 
> REQUEST_WEAPON_ASSET(iLocal_1888, 31, 26);

## REQUEST_WEAPON_HIGH_DETAIL_MODEL

```c
void REQUEST_WEAPON_HIGH_DETAIL_MODEL(Entity weaponObject)  // 0x48164DBB970AC3F0
```

build 323

## SET_AMMO_IN_CLIP

```c
BOOL SET_AMMO_IN_CLIP(Ped ped, Hash weaponHash, int ammo)  // 0xDCD2A934D65CB497
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_CAN_PED_SELECT_ALL_WEAPONS

```c
void SET_CAN_PED_SELECT_ALL_WEAPONS(Ped ped, BOOL toggle)  // 0xEFF296097FF1E509
```

build 1103 · old names: `_SET_CAN_PED_EQUIP_ALL_WEAPONS`

> Disable all weapons. Does the same as SET_CAN_PED_SELECT_INVENTORY_WEAPON except for all weapons.

## SET_CAN_PED_SELECT_INVENTORY_WEAPON

```c
void SET_CAN_PED_SELECT_INVENTORY_WEAPON(Ped ped, Hash weaponHash, BOOL toggle)  // 0xB4771B9AAF4E68E4
```

build 1103 · old names: `_SET_CAN_PED_SELECT_WEAPON`, `_SET_CAN_PED_EQUIP_WEAPON`

> Disables selecting the given weapon. Ped isn't forced to put the gun away. However you can't reselect the weapon if you holster then unholster. Weapon is also grayed out on the weapon wheel.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_CURRENT_PED_VEHICLE_WEAPON

```c
BOOL SET_CURRENT_PED_VEHICLE_WEAPON(Ped ped, Hash weaponHash)  // 0x75C55983C2C39DAA
```

build 323

> Full list of weapons by DurtyFree (Search for VEHICLE_*): https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_CURRENT_PED_WEAPON

```c
void SET_CURRENT_PED_WEAPON(Ped ped, Hash weaponHash, BOOL bForceInHand)  // 0xADF692B254977C0C
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_EQIPPED_WEAPON_START_SPINNING_AT_FULL_SPEED

```c
void SET_EQIPPED_WEAPON_START_SPINNING_AT_FULL_SPEED(Ped ped)  // 0xE4DCEC7FD5B739A5
```

build 323

## SET_FLASH_LIGHT_ACTIVE_HISTORY

```c
void SET_FLASH_LIGHT_ACTIVE_HISTORY(Ped ped, BOOL toggle)  // 0x988DB6FE9B3AC000
```

build 2060 · old names: `_SET_FLASH_LIGHT_ENABLED`

> Enables/disables flashlight on ped's weapon.

## SET_FLASH_LIGHT_FADE_DISTANCE

```c
BOOL SET_FLASH_LIGHT_FADE_DISTANCE(float distance)  // 0xCEA66DAD478CD39B
```

build 323

## SET_PED_AMMO

```c
void SET_PED_AMMO(Ped ped, Hash weaponHash, int ammo, BOOL p3)  // 0x14E56BC5B5DB6A19
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_PED_AMMO_BY_TYPE

```c
void SET_PED_AMMO_BY_TYPE(Ped ped, Hash ammoTypeHash, int ammo)  // 0x5FD1E1F011E76D7E
```

build 323

> Ammo types: https://gist.github.com/root-cause/faf41f59f7a6d818b7db0b839bd147c1

## SET_PED_AMMO_TO_DROP

```c
void SET_PED_AMMO_TO_DROP(Ped ped, int p1)  // 0xA4EFEF9440A5B0EF
```

build 323

## SET_PED_CHANCE_OF_FIRING_BLANKS

```c
void SET_PED_CHANCE_OF_FIRING_BLANKS(Ped ped, float xBias, float yBias)  // 0x8378627201D5497D
```

build 323

## SET_PED_CURRENT_WEAPON_VISIBLE

```c
void SET_PED_CURRENT_WEAPON_VISIBLE(Ped ped, BOOL visible, BOOL deselectWeapon, BOOL p3, BOOL p4)  // 0x0725A4CCFDED9A70
```

build 323

> Has 5 parameters since latest patches.

## SET_PED_CYCLE_VEHICLE_WEAPONS_ONLY

```c
void SET_PED_CYCLE_VEHICLE_WEAPONS_ONLY(Ped ped)  // 0x50276EF8172F5F12
```

build 1734

## SET_PED_DROPS_INVENTORY_WEAPON

```c
void SET_PED_DROPS_INVENTORY_WEAPON(Ped ped, Hash weaponHash, float xOffset, float yOffset, float zOffset, int ammoCount)  // 0x208A1888007FC0E6
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_PED_DROPS_WEAPON

```c
void SET_PED_DROPS_WEAPON(Ped ped)  // 0x6B7513D9966FBEC0
```

build 323

## SET_PED_DROPS_WEAPONS_WHEN_DEAD

```c
void SET_PED_DROPS_WEAPONS_WHEN_DEAD(Ped ped, BOOL toggle)  // 0x476AE72C1D19D1A8
```

build 323

## SET_PED_GADGET

```c
void SET_PED_GADGET(Ped ped, Hash gadgetHash, BOOL p2)  // 0xD0D7B1E680ED4A1A
```

build 323

> p1/gadgetHash was always 0xFBAB5776 ("GADGET_PARACHUTE").
> p2 is always true.

## SET_PED_INFINITE_AMMO

```c
void SET_PED_INFINITE_AMMO(Ped ped, BOOL toggle, Hash weaponHash)  // 0x3EDCB0505123623B
```

build 323

> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_PED_INFINITE_AMMO_CLIP

```c
void SET_PED_INFINITE_AMMO_CLIP(Ped ped, BOOL toggle)  // 0x183DADC6AA953186
```

build 323

## SET_PED_SHOOT_ORDNANCE_WEAPON

```c
Object SET_PED_SHOOT_ORDNANCE_WEAPON(Ped ped, float p1)  // 0xB4C8D77C80C0421E
```

build 323

> Returns handle of the projectile.

## SET_PED_STUN_GUN_FINITE_AMMO

```c
void SET_PED_STUN_GUN_FINITE_AMMO(Any p0, Any p1)  // 0x24C024BA8379A70A
```

build 1868

## SET_PED_WEAPON_COMPONENT_TINT_INDEX

```c
void SET_PED_WEAPON_COMPONENT_TINT_INDEX(Ped ped, Hash weaponHash, Hash camoComponentHash, int colorIndex)  // 0x9FE5633880ECD8ED
```

build 1103 · old names: `_SET_PED_WEAPON_LIVERY_COLOR`

> Colors:
> 0 = Gray
> 1 = Dark Gray
> 2 = Black
> 3 = White
> 4 = Blue
> 5 = Cyan
> 6 = Aqua
> 7 = Cool Blue
> 8 = Dark Blue
> 9 = Royal Blue
> 10 = Plum
> 11 = Dark Purple
> 12 = Purple
> 13 = Red
> 14 = Wine Red
> 15 = Magenta
> 16 = Pink
> 17 = Salmon
> 18 = Hot Pink
> 19 = Rust Orange
> 20 = Brown
> 21 = Earth
> 22 = Orange
> 23 = Light Orange
> 24 = Dark Yellow
> 25 = Yellow
> 26 = Light Brown
> 27 = Lime Green
> 28 = Olive
> 29 = Moss
> 30 = Turquoise
> 31 = Dark Green
> Full list of weapons, components, tint indexes & weapon liveries by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_PED_WEAPON_TINT_INDEX

```c
void SET_PED_WEAPON_TINT_INDEX(Ped ped, Hash weaponHash, int tintIndex)  // 0x50969B9B89ED5738
```

build 323

> tintIndex can be the following:
> 
> 0 - Normal
> 1 - Green
> 2 - Gold
> 3 - Pink
> 4 - Army
> 5 - LSPD
> 6 - Orange
> 7 - Platinum
> Full list of weapons, components & tint indexes by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_PICKUP_AMMO_AMOUNT_SCALER

```c
void SET_PICKUP_AMMO_AMOUNT_SCALER(float p0)  // 0xE620FD3512A04F18
```

build 323

## SET_PLAYER_TARGETTABLE_FOR_AIR_DEFENCE_SPHERE

```c
void SET_PLAYER_TARGETTABLE_FOR_AIR_DEFENCE_SPHERE(Player player, int zoneId, BOOL enable)  // 0xECDC202B25E5CF48
```

build 573 · old names: `_SET_PLAYER_AIR_DEFENSE_ZONE_FLAG`

## SET_WEAPON_ANIMATION_OVERRIDE

```c
void SET_WEAPON_ANIMATION_OVERRIDE(Ped ped, Hash animStyle)  // 0x1055AC3A667F09D9
```

build 323

> Changes the selected ped aiming animation style. 
> Note : You must use GET_HASH_KEY!
> 
> Strings to use with GET_HASH_KEY :
> 
>     "Ballistic",
>     "Default",
>   "Fat",
>   "Female",
>    "FirstPerson",
>   "FirstPersonAiming",
>     "FirstPersonFranklin",
>   "FirstPersonFranklinAiming",
>     "FirstPersonFranklinRNG",
>    "FirstPersonFranklinScope",
>  "FirstPersonMPFemale",
>   "FirstPersonMichael",
>    "FirstPersonMichaelAiming",
>  "FirstPersonMichaelRNG",
>     "FirstPersonMichaelScope",
>   "FirstPersonRNG",
>    "FirstPersonScope",
>  "FirstPersonTrevor",
>     "FirstPersonTrevorAiming",
>   "FirstPersonTrevorRNG",
>  "FirstPersonTrevorScope",
>    "Franklin",
>  "Gang",
>  "Gang1H",
>    "GangFemale",
>    "Hillbilly",
>     "MP_F_Freemode",
>     "Michael",
>   "SuperFat",
>  "Trevor"

## SET_WEAPON_AOE_MODIFIER

```c
void SET_WEAPON_AOE_MODIFIER(Hash weaponHash, float multiplier)  // 0x4AE5AC8B852D642C
```

build 2372 · old names: `_SET_WEAPON_EXPLOSION_RADIUS_MULTIPLIER`

## SET_WEAPON_DAMAGE_MODIFIER

```c
void SET_WEAPON_DAMAGE_MODIFIER(Hash weaponHash, float damageMultiplier)  // 0x4757F00BC6323CFE
```

build 505 · old names: `_SET_WEAPON_DAMAGE_MODIFIER`, `_SET_WEAPON_DAMAGE_MODIFIER_THIS_FRAME`

> Changes the weapon damage output by the given multiplier value. Must be run every frame.
> Full list of weapons by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_WEAPON_EFFECT_DURATION_MODIFIER

```c
void SET_WEAPON_EFFECT_DURATION_MODIFIER(Hash p0, float p1)  // 0xE6D2CEDD370FF98E
```

build 2372

> ex, WEAPON::SET_WEAPON_EFFECT_DURATION_MODIFIER(joaat("vehicle_weapon_mine_slick"), 1.0);

## SET_WEAPON_OBJECT_CAMO_INDEX

```c
void SET_WEAPON_OBJECT_CAMO_INDEX(Object weaponObject, int p1)  // 0x977CA98939E82E4B
```

build 1103

## SET_WEAPON_OBJECT_COMPONENT_TINT_INDEX

```c
void SET_WEAPON_OBJECT_COMPONENT_TINT_INDEX(Object weaponObject, Hash camoComponentHash, int colorIndex)  // 0x5DA825A85D0EA6E6
```

build 1103 · old names: `_SET_WEAPON_OBJECT_LIVERY_COLOR`

> Colors:
> 0 = Gray
> 1 = Dark Gray
> 2 = Black
> 3 = White
> 4 = Blue
> 5 = Cyan
> 6 = Aqua
> 7 = Cool Blue
> 8 = Dark Blue
> 9 = Royal Blue
> 10 = Plum
> 11 = Dark Purple
> 12 = Purple
> 13 = Red
> 14 = Wine Red
> 15 = Magenta
> 16 = Pink
> 17 = Salmon
> 18 = Hot Pink
> 19 = Rust Orange
> 20 = Brown
> 21 = Earth
> 22 = Orange
> 23 = Light Orange
> 24 = Dark Yellow
> 25 = Yellow
> 26 = Light Brown
> 27 = Lime Green
> 28 = Olive
> 29 = Moss
> 30 = Turquoise
> 31 = Dark Green
> Full list of weapons, components, tint indexes & weapon liveries by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

## SET_WEAPON_OBJECT_TINT_INDEX

```c
void SET_WEAPON_OBJECT_TINT_INDEX(Object weapon, int tintIndex)  // 0xF827589017D4E4A9
```

build 323

> Full list of weapons, components & tint indexes by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/weapons.json

