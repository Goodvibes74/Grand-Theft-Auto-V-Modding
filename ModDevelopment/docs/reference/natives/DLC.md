# DLC natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ARE_ANY_CCS_PENDING

```c
BOOL ARE_ANY_CCS_PENDING()  // 0x241FCA5B1AA14F75
```

build 323

## DLC_CHECK_CLOUD_DATA_CORRECT

```c
BOOL DLC_CHECK_CLOUD_DATA_CORRECT()  // 0xF2E07819EF1A5289
```

build 323

> This function is hard-coded to always return 1.

## DLC_CHECK_COMPAT_PACK_CONFIGURATION

```c
BOOL DLC_CHECK_COMPAT_PACK_CONFIGURATION()  // 0xA213B11DFF526300
```

build 323

> This function is hard-coded to always return 1.

## GET_EVER_HAD_BAD_PACK_ORDER

```c
BOOL GET_EVER_HAD_BAD_PACK_ORDER()  // 0x8D30F648014A92B5
```

build 323 · old names: `_GET_EXTRA_CONTENT_PACK_HAS_BEEN_INSTALLED`

## GET_EXTRACONTENT_CLOUD_RESULT

```c
int GET_EXTRACONTENT_CLOUD_RESULT()  // 0x9489659372A81585
```

build 323

> This function is hard-coded to always return 0.

## GET_IS_INITIAL_LOADING_SCREEN_ACTIVE

```c
BOOL GET_IS_INITIAL_LOADING_SCREEN_ACTIVE()  // 0xC4637A6D03C24CC3
```

build 1734

## GET_IS_LOADING_SCREEN_ACTIVE

```c
BOOL GET_IS_LOADING_SCREEN_ACTIVE()  // 0x10D0A8F259E93EC9
```

build 323

## HAS_CLOUD_REQUESTS_FINISHED

```c
BOOL HAS_CLOUD_REQUESTS_FINISHED(BOOL* p0, int unused)  // 0x46E2B844905BC5F0
```

build 323 · old names: `_NULLIFY`

> Sets the value of the specified variable to 0.
> Always returns true.

## IS_DLC_PRESENT

```c
BOOL IS_DLC_PRESENT(Hash dlcHash)  // 0x812595A0644CE1DE
```

build 323

> Returns true if the given DLC pack is present.

## ON_ENTER_MP

```c
void ON_ENTER_MP()  // 0x0888C3502DBBEEF5
```

build 323 · old names: `_LOAD_MP_DLC_MAPS`

> This loads the GTA:O dlc map parts (high end garages, apartments).
> Works in singleplayer.
> In order to use GTA:O heist IPL's you have to call this native with the following params: SET_INSTANCE_PRIORITY_MODE(1);

## ON_ENTER_SP

```c
void ON_ENTER_SP()  // 0xD7C10C4A637992C9
```

build 323 · old names: `_LOAD_SP_DLC_MAPS`

> Unloads GROUP_MAP (GTAO/MP) DLC data and loads GROUP_MAP_SP DLC. Neither are loaded by default, ON_ENTER_MP is a cognate to this function and loads MP DLC (and unloads SP DLC by extension).
> Works in singleplayer.

