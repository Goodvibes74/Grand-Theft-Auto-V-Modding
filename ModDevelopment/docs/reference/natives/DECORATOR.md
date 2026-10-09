# DECORATOR natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## DECOR_EXIST_ON

```c
BOOL DECOR_EXIST_ON(Entity entity, const char* propertyName)  // 0x05661B80A8C9165F
```

build 323

> Returns whether or not the specified property is set for the entity.

## DECOR_GET_BOOL

```c
BOOL DECOR_GET_BOOL(Entity entity, const char* propertyName)  // 0xDACE671663F2F5DB
```

build 323

## DECOR_GET_FLOAT

```c
float DECOR_GET_FLOAT(Entity entity, const char* propertyName)  // 0x6524A2F114706F43
```

build 323 · old names: `_DECOR_GET_FLOAT`

## DECOR_GET_INT

```c
int DECOR_GET_INT(Entity entity, const char* propertyName)  // 0xA06C969B02A97298
```

build 323

## DECOR_IS_REGISTERED_AS_TYPE

```c
BOOL DECOR_IS_REGISTERED_AS_TYPE(const char* propertyName, int type)  // 0x4F14F9F870D6FBC8
```

build 323

> type: see DECOR_REGISTER

## DECOR_REGISTER

```c
void DECOR_REGISTER(const char* propertyName, int type)  // 0x9FD90732F56403CE
```

build 323

> enum eDecorType
> {
> 	DECOR_TYPE_UNKNOWN = 0,
> 	DECOR_TYPE_FLOAT = 1,
> 	DECOR_TYPE_BOOL = 2,
> 	DECOR_TYPE_INT = 3,
> 	DECOR_TYPE_STRING = 4,
> 	DECOR_TYPE_TIME = 5
> };

## DECOR_REGISTER_LOCK

```c
void DECOR_REGISTER_LOCK()  // 0xA9D14EEA259F9248
```

build 323

> Called after all decorator type initializations.

## DECOR_REMOVE

```c
BOOL DECOR_REMOVE(Entity entity, const char* propertyName)  // 0x00EE9F297C738720
```

build 323

## DECOR_SET_BOOL

```c
BOOL DECOR_SET_BOOL(Entity entity, const char* propertyName, BOOL value)  // 0x6B1E8E2ED1335B71
```

build 323

> This function sets metadata of type bool to specified entity.
> 

## DECOR_SET_FLOAT

```c
BOOL DECOR_SET_FLOAT(Entity entity, const char* propertyName, float value)  // 0x211AB1DD8D0F363A
```

build 323 · old names: `_DECOR_SET_FLOAT`

## DECOR_SET_INT

```c
BOOL DECOR_SET_INT(Entity entity, const char* propertyName, int value)  // 0x0CE3AA5E1CA19E10
```

build 323

> Sets property to int.

## DECOR_SET_TIME

```c
BOOL DECOR_SET_TIME(Entity entity, const char* propertyName, int timestamp)  // 0x95AED7B8E39ECAA4
```

build 323

