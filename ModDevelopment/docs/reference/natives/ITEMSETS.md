# ITEMSETS natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ADD_TO_ITEMSET

```c
BOOL ADD_TO_ITEMSET(ScrHandle item, ScrHandle itemset)  // 0xE3945201F14637DD
```

build 323

## CLEAN_ITEMSET

```c
void CLEAN_ITEMSET(ScrHandle itemset)  // 0x41BC0D722FC04221
```

build 323

## CREATE_ITEMSET

```c
ScrHandle CREATE_ITEMSET(BOOL p0)  // 0x35AD299F50D91B24
```

build 323

## DESTROY_ITEMSET

```c
void DESTROY_ITEMSET(ScrHandle itemset)  // 0xDE18220B1C183EDA
```

build 323

## GET_INDEXED_ITEM_IN_ITEMSET

```c
ScrHandle GET_INDEXED_ITEM_IN_ITEMSET(int index, ScrHandle itemset)  // 0x7A197E2521EE2BAB
```

build 323

## GET_ITEMSET_SIZE

```c
int GET_ITEMSET_SIZE(ScrHandle itemset)  // 0xD9127E83ABF7C631
```

build 323

## IS_IN_ITEMSET

```c
BOOL IS_IN_ITEMSET(ScrHandle item, ScrHandle itemset)  // 0x2D0FC594D1E9C107
```

build 323

## IS_ITEMSET_VALID

```c
BOOL IS_ITEMSET_VALID(ScrHandle itemset)  // 0xB1B1EA596344DFAB
```

build 323

## REMOVE_FROM_ITEMSET

```c
void REMOVE_FROM_ITEMSET(ScrHandle item, ScrHandle itemset)  // 0x25E68244B0177686
```

build 323

