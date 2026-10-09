# EXTRAMETADATA natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## DOES_CURRENT_PED_COMPONENT_HAVE_RESTRICTION_TAG

```c
BOOL DOES_CURRENT_PED_COMPONENT_HAVE_RESTRICTION_TAG(Ped ped, int componentId, Hash restrictionTagHash)  // 0x7796B21B76221BC5
```

build 2612 · old names: `_DOES_CUSTOMIZATION_COMPONENT_HAVE_RESTRICTION_TAG`

## DOES_CURRENT_PED_PROP_HAVE_RESTRICTION_TAG

```c
BOOL DOES_CURRENT_PED_PROP_HAVE_RESTRICTION_TAG(Ped ped, int componentId, Hash restrictionTagHash)  // 0xD726BAB4554DA580
```

build 2612 · old names: `_DOES_CUSTOMIZATION_PROP_HAVE_RESTRICTION_TAG`

## DOES_SHOP_PED_APPAREL_HAVE_RESTRICTION_TAG

```c
BOOL DOES_SHOP_PED_APPAREL_HAVE_RESTRICTION_TAG(Hash componentHash, Hash restrictionTagHash, int componentId)  // 0x341DE7ED1D2A1BFD
```

build 323

> Full list of restriction tags by DurtyFree: https://github.com/DurtyFree/gta-v-data-dumps/blob/master/pedApparelRestrictionTags.json
> 
> componentId/last parameter seems to be unused.

## EXECUTE_CONTENT_CHANGESET_GROUP_FOR_ALL

```c
void EXECUTE_CONTENT_CHANGESET_GROUP_FOR_ALL(Hash hash)  // 0x6BEDF5769AC2DC07
```

build 1604 · old names: `_LOAD_CONTENT_CHANGE_SET_GROUP`

> From fm_deathmatch_creator and fm_race_creator:
> 
> FILES::REVERT_CONTENT_CHANGESET_GROUP_FOR_ALL(joaat("GROUP_MAP_SP"));
> FILES::EXECUTE_CONTENT_CHANGESET_GROUP_FOR_ALL(joaat("GROUP_MAP"));

## GET_DLC_VEHICLE_DATA

```c
BOOL GET_DLC_VEHICLE_DATA(int dlcVehicleIndex, Any* outData)  // 0x33468EDC08E371F6
```

build 323

> dlcVehicleIndex takes a number from 0 - GET_NUM_DLC_VEHICLES() - 1.
> outData is a struct of 3 8-byte items.
> The Second item in the struct *(Hash *)(outData + 1) is the vehicle hash.

## GET_DLC_VEHICLE_FLAGS

```c
int GET_DLC_VEHICLE_FLAGS(int dlcVehicleIndex)  // 0x5549EE11FA22FCF2
```

build 323

## GET_DLC_VEHICLE_MOD_LOCK_HASH

```c
Hash GET_DLC_VEHICLE_MOD_LOCK_HASH(Hash hash)  // 0xC098810437312FFF
```

build 323

## GET_DLC_VEHICLE_MODEL

```c
Hash GET_DLC_VEHICLE_MODEL(int dlcVehicleIndex)  // 0xECC01B7C5763333C
```

build 323

> dlcVehicleIndex is 0 to GET_NUM_DLC_VEHICLS() - 1

## GET_DLC_WEAPON_COMPONENT_DATA

```c
BOOL GET_DLC_WEAPON_COMPONENT_DATA(int dlcWeaponIndex, int dlcWeapCompIndex, Any* ComponentDataPtr)  // 0x6CF598A2957C2BF8
```

build 323

> p0 seems to be the weapon index
> p1 seems to be the weapon component index
> struct DlcComponentData{
> int attachBone;
> int padding1;
> int bActiveByDefault;
> int padding2;
> int unk;
> int padding3;
> int componentHash;
> int padding4;
> int unk2;
> int padding5;
> int componentCost;
> int padding6;
> char nameLabel[64];
> char descLabel[64];
> };
> 

## GET_DLC_WEAPON_COMPONENT_DATA_SP

```c
BOOL GET_DLC_WEAPON_COMPONENT_DATA_SP(int dlcWeaponIndex, int dlcWeapCompIndex, Any* ComponentDataPtr)  // 0x31D5E073B6F93CDC
```

build 2060 · old names: `_GET_DLC_WEAPON_COMPONENT_DATA_SP`

> Same as GET_DLC_WEAPON_COMPONENT_DATA but only works for DLC components that are available in SP.

## GET_DLC_WEAPON_DATA

```c
BOOL GET_DLC_WEAPON_DATA(int dlcWeaponIndex, Any* outData)  // 0x79923CD21BECE14E
```

build 323

> 
> dlcWeaponIndex takes a number from 0 - GET_NUM_DLC_WEAPONS() - 1.
> struct DlcWeaponData
> {
> int emptyCheck; //use DLC1::IS_CONTENT_ITEM_LOCKED on this
> int padding1;
> int weaponHash;
> int padding2;
> int unk;
> int padding3;
> int weaponCost;
> int padding4;
> int ammoCost;
> int padding5;
> int ammoType;
> int padding6;
> int defaultClipSize;
> int padding7;
> char nameLabel[64];
> char descLabel[64];
> char desc2Label[64]; // usually "the" + name
> char upperCaseNameLabel[64];
> };

## GET_DLC_WEAPON_DATA_SP

```c
BOOL GET_DLC_WEAPON_DATA_SP(int dlcWeaponIndex, Any* outData)  // 0x310836EE7129BA33
```

build 2060 · old names: `_GET_DLC_WEAPON_DATA_SP`

> Same as GET_DLC_WEAPON_DATA but only works for DLC weapons that are available in SP.

## GET_FORCED_COMPONENT

```c
void GET_FORCED_COMPONENT(Hash componentHash, int forcedComponentIndex, Hash* nameHash, int* enumValue, int* componentType)  // 0x6C93ED8C2F74859B
```

build 323

## GET_FORCED_PROP

```c
void GET_FORCED_PROP(Hash componentHash, int forcedPropIndex, Hash* nameHash, int* enumValue, int* anchorPoint)  // 0xE1CA84EBF72E691D
```

build 323

## GET_HASH_NAME_FOR_COMPONENT

```c
Hash GET_HASH_NAME_FOR_COMPONENT(Entity entity, int componentId, int drawableVariant, int textureVariant)  // 0x0368B3A838070348
```

build 323

## GET_HASH_NAME_FOR_PROP

```c
Hash GET_HASH_NAME_FOR_PROP(Entity entity, int componentId, int propIndex, int propTextureIndex)  // 0x5D6160275CAEC8DD
```

build 323

## GET_NUM_DLC_VEHICLES

```c
int GET_NUM_DLC_VEHICLES()  // 0xA7A866D21CD2329B
```

build 323

## GET_NUM_DLC_WEAPON_COMPONENTS

```c
int GET_NUM_DLC_WEAPON_COMPONENTS(int dlcWeaponIndex)  // 0x405425358A7D61FE
```

build 323

> Returns the total number of DLC weapon components.

## GET_NUM_DLC_WEAPON_COMPONENTS_SP

```c
int GET_NUM_DLC_WEAPON_COMPONENTS_SP(int dlcWeaponIndex)  // 0xAD2A7A6DFF55841B
```

build 2060 · old names: `_GET_NUM_DLC_WEAPON_COMPONENTS_SP`

> Returns the total number of DLC weapon components that are available in SP.

## GET_NUM_DLC_WEAPONS

```c
int GET_NUM_DLC_WEAPONS()  // 0xEE47635F352DA367
```

build 323

> Returns the total number of DLC weapons.

## GET_NUM_DLC_WEAPONS_SP

```c
int GET_NUM_DLC_WEAPONS_SP()  // 0x4160B65AE085B5A9
```

build 2060 · old names: `_GET_NUM_DLC_WEAPONS_SP`

> Returns the total number of DLC weapons that are available in SP (availableInSP field in shop_weapon.meta).

## GET_NUM_TATTOO_SHOP_DLC_ITEMS

```c
int GET_NUM_TATTOO_SHOP_DLC_ITEMS(int character)  // 0x278F76C3B0A8F109
```

build 323 · old names: `_GET_NUM_DECORATIONS`

> Character types:
> 0 = Michael, 
> 1 = Franklin, 
> 2 = Trevor, 
> 3 = MPMale, 
> 4 = MPFemale

## GET_SHOP_PED_APPAREL_FORCED_COMPONENT_COUNT

```c
int GET_SHOP_PED_APPAREL_FORCED_COMPONENT_COUNT(Hash componentHash)  // 0xC6B9DB42C04DD8C3
```

build 323 · old names: `_GET_NUM_FORCED_COMPONENTS`

> Returns number of possible values of the forcedComponentIndex argument of GET_FORCED_COMPONENT.

## GET_SHOP_PED_APPAREL_FORCED_PROP_COUNT

```c
int GET_SHOP_PED_APPAREL_FORCED_PROP_COUNT(Hash componentHash)  // 0x017568A8182D98A6
```

build 323

> Returns number of possible values of the forcedPropIndex argument of GET_FORCED_PROP.

## GET_SHOP_PED_APPAREL_VARIANT_COMPONENT_COUNT

```c
int GET_SHOP_PED_APPAREL_VARIANT_COMPONENT_COUNT(Hash componentHash)  // 0xC17AD0E5752BECDA
```

build 323

## GET_SHOP_PED_APPAREL_VARIANT_PROP_COUNT

```c
int GET_SHOP_PED_APPAREL_VARIANT_PROP_COUNT(Hash propHash)  // 0xD40AAC51E8E4C663
```

build 791 · old names: `_GET_SHOP_PED_APPAREL_VARIANT_PROP_COUNT`

> `propHash`: Ped helmet prop hash?
> This native returns 1 when the player helmet has a visor (there is another prop index for the same helmet with closed/opened visor variant) that can be toggled. 0 if there's no alternative version with a visor for this helmet prop.

## GET_SHOP_PED_COMPONENT

```c
void GET_SHOP_PED_COMPONENT(Hash componentHash, Any* outComponent)  // 0x74C0E2A57EC66760
```

build 323

> More info here: https://gist.github.com/root-cause/3b80234367b0c856d60bf5cb4b826f86

## GET_SHOP_PED_OUTFIT

```c
void GET_SHOP_PED_OUTFIT(Any p0, Any* p1)  // 0xB7952076E444979D
```

build 323

## GET_SHOP_PED_OUTFIT_COMPONENT_VARIANT

```c
BOOL GET_SHOP_PED_OUTFIT_COMPONENT_VARIANT(Hash outfitHash, int variantIndex, Any* outComponentVariant)  // 0x19F2A026EDF0013F
```

build 323 · old names: `_GET_PROP_FROM_OUTFIT`

> See https://git.io/JtcBH for example and structs.

## GET_SHOP_PED_OUTFIT_LOCATE

```c
int GET_SHOP_PED_OUTFIT_LOCATE(Any p0)  // 0x073CA26B079F956E
```

build 323

## GET_SHOP_PED_OUTFIT_PROP_VARIANT

```c
BOOL GET_SHOP_PED_OUTFIT_PROP_VARIANT(Hash outfitHash, int variantIndex, Any* outPropVariant)  // 0xA9F9C2E0FDE11CBB
```

build 323

> See https://git.io/JtcBH for example and structs.

## GET_SHOP_PED_PROP

```c
void GET_SHOP_PED_PROP(Hash componentHash, Any* outProp)  // 0x5D5CAFF661DDF6FC
```

build 323

> More info here: https://gist.github.com/root-cause/3b80234367b0c856d60bf5cb4b826f86

## GET_SHOP_PED_QUERY_COMPONENT

```c
void GET_SHOP_PED_QUERY_COMPONENT(int componentId, Any* outComponent)  // 0x249E310B2D920699
```

build 323

> See https://git.io/JtcRf for example and structs.

## GET_SHOP_PED_QUERY_COMPONENT_INDEX

```c
int GET_SHOP_PED_QUERY_COMPONENT_INDEX(Hash componentHash)  // 0x96E2929292A4DB77
```

build 2189

> Returns some sort of index/offset for components.
> Needs SETUP_SHOP_PED_APPAREL_QUERY_TU to be called with p3 = false and componentId with the drawable's component slot first, returns -1 otherwise.

## GET_SHOP_PED_QUERY_OUTFIT

```c
void GET_SHOP_PED_QUERY_OUTFIT(int outfitIndex, Any* outfit)  // 0x6D793F03A631FE56
```

build 323

> outfitIndex: from 0 to SETUP_SHOP_PED_OUTFIT_QUERY(characterIndex, false) - 1.
> See https://git.io/JtcB8 for example and outfit struct.

## GET_SHOP_PED_QUERY_PROP

```c
void GET_SHOP_PED_QUERY_PROP(int componentId, Any* outProp)  // 0xDE44A00999B2837D
```

build 323

> See https://git.io/JtcRf for example and structs.

## GET_SHOP_PED_QUERY_PROP_INDEX

```c
int GET_SHOP_PED_QUERY_PROP_INDEX(Hash componentHash)  // 0x6CEBE002E58DEE97
```

build 2189

> Returns some sort of index/offset for props.
> Needs SETUP_SHOP_PED_APPAREL_QUERY_TU to be called with p3 = true and componentId = -1 first, returns -1 otherwise.

## GET_TATTOO_SHOP_DLC_ITEM_DATA

```c
BOOL GET_TATTOO_SHOP_DLC_ITEM_DATA(int characterType, int decorationIndex, Any* outComponent)  // 0xFF56381874F82086
```

build 323 · old names: `_GET_TATTOO_COLLECTION_DATA`

> Character types:
> 0 = Michael, 
> 1 = Franklin, 
> 2 = Trevor, 
> 3 = MPMale, 
> 4 = MPFemale
> 
> 
> enum TattooZoneData
> {  
>     ZONE_TORSO = 0,  
>     ZONE_HEAD = 1,  
>     ZONE_LEFT_ARM = 2,  
>     ZONE_RIGHT_ARM = 3,  
>     ZONE_LEFT_LEG = 4,  
>     ZONE_RIGHT_LEG = 5,  
>     ZONE_UNKNOWN = 6,
>     ZONE_NONE = 7,  
> };
> struct outComponent
> {
>     // these vars are suffixed with 4 bytes of padding each.
>     uint unk;
>     int unk2;
>     uint tattooCollectionHash;
>     uint tattooNameHash;
>     int unk3;
>     TattooZoneData zoneId;
>     uint unk4;
>     uint unk5;
>     // maybe more, not sure exactly, decompiled scripts are very vague around this part.
> }

## GET_TATTOO_SHOP_DLC_ITEM_INDEX

```c
int GET_TATTOO_SHOP_DLC_ITEM_INDEX(Hash overlayHash, Any p1, int character)  // 0x10144267DD22866C
```

build 2189

> Returns some sort of index/offset for overlays/decorations.
> 
> Character types:
> 0 = Michael, 
> 1 = Franklin, 
> 2 = Trevor, 
> 3 = MPMale, 
> 4 = MPFemale

## GET_VARIANT_COMPONENT

```c
void GET_VARIANT_COMPONENT(Hash componentHash, int variantComponentIndex, Hash* nameHash, int* enumValue, int* componentType)  // 0x6E11F282F11863B6
```

build 323

## GET_VARIANT_PROP

```c
void GET_VARIANT_PROP(Hash componentHash, int variantPropIndex, Hash* nameHash, int* enumValue, int* anchorPoint)  // 0xD81B7F27BC773E66
```

build 791 · old names: `_GET_VARIANT_PROP`

## INIT_SHOP_PED_COMPONENT

```c
void INIT_SHOP_PED_COMPONENT(Any* outComponent)  // 0x1E8C308FD312C036
```

build 323

## INIT_SHOP_PED_PROP

```c
void INIT_SHOP_PED_PROP(Any* outProp)  // 0xEB0A2B758F7B850F
```

build 323

## IS_CONTENT_ITEM_LOCKED

```c
BOOL IS_CONTENT_ITEM_LOCKED(Hash itemHash)  // 0xD4D7B033C3AA243C
```

build 323 · old names: `_IS_OUTFIT_EMPTY`, `_IS_DLC_DATA_EMPTY`

## IS_DLC_VEHICLE_MOD

```c
BOOL IS_DLC_VEHICLE_MOD(Hash hash)  // 0x0564B9FF9631B82C
```

build 323

## REVERT_CONTENT_CHANGESET_GROUP_FOR_ALL

```c
void REVERT_CONTENT_CHANGESET_GROUP_FOR_ALL(Hash hash)  // 0x3C1978285B036B25
```

build 1604 · old names: `_UNLOAD_CONTENT_CHANGE_SET_GROUP`

> From fm_deathmatch_creator and fm_race_creator:
> 
> FILES::REVERT_CONTENT_CHANGESET_GROUP_FOR_ALL(joaat("GROUP_MAP_SP"));
> FILES::EXECUTE_CONTENT_CHANGESET_GROUP_FOR_ALL(joaat("GROUP_MAP"));

## SETUP_SHOP_PED_APPAREL_QUERY

```c
int SETUP_SHOP_PED_APPAREL_QUERY(int p0, int p1, int p2, int p3)  // 0x50F457823CE6EB5F
```

build 323

## SETUP_SHOP_PED_APPAREL_QUERY_TU

```c
int SETUP_SHOP_PED_APPAREL_QUERY_TU(int character, int p1, int p2, BOOL p3, int p4, int componentId)  // 0x9BDF59818B1E38C1
```

build 323 · old names: `_GET_NUM_PROPS_FROM_OUTFIT`

> character is 0 for Michael, 1 for Franklin, 2 for Trevor, 3 for freemode male, and 4 for freemode female.
> 
> componentId is between 0 and 11 and corresponds to the usual component slots.
> 
> p1 could be the outfit number; unsure.
> 
> p2 is usually -1; unknown function.
> 
> p3 appears to be for selecting between clothes and props; false is used with components/clothes, true is used with props.
> 
> p4 is usually -1; unknown function.
> 
> componentId is -1 when p3 is true in decompiled scripts.

## SETUP_SHOP_PED_OUTFIT_QUERY

```c
int SETUP_SHOP_PED_OUTFIT_QUERY(int character, BOOL p1)  // 0xF3FBE2D50A6A8C28
```

build 323

> characters
> 
> 0: Michael
> 1: Franklin
> 2: Trevor
> 3: MPMale
> 4: MPFemale

