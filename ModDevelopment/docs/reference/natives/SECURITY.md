# SECURITY natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## FORCE_CHECK_SCRIPT_VARIABLES

```c
void FORCE_CHECK_SCRIPT_VARIABLES()  // 0x8E580AB902917360
```

build 2545 · old names: `_FORCE_CHECK_PROTECTED_VARIABLES_NOW`

## REGISTER_SCRIPT_VARIABLE

```c
void REGISTER_SCRIPT_VARIABLE(Any* variable)  // 0x40EB1EFD921822BC
```

build 2545 · old names: `_REGISTER_PROTECTED_VARIABLE`

> Registers a protected variable that will be checked for modifications by the anticheat

## UNREGISTER_SCRIPT_VARIABLE

```c
void UNREGISTER_SCRIPT_VARIABLE(Any* variable)  // 0x340A36A700E99699
```

build 2545 · old names: `_UNREGISTER_PROTECTED_VARIABLE`

