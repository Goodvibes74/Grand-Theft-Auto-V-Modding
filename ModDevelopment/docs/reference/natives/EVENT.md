# EVENT natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ADD_SHOCKING_EVENT_AT_POSITION

```c
int ADD_SHOCKING_EVENT_AT_POSITION(int eventType, float x, float y, float z, float duration)  // 0xD9F8455409B525E9
```

build 323

> eventType: https://alloc8or.re/gta5/doc/enums/eEventType.txt

## ADD_SHOCKING_EVENT_FOR_ENTITY

```c
int ADD_SHOCKING_EVENT_FOR_ENTITY(int eventType, Entity entity, float duration)  // 0x7FD8F3BE76F89422
```

build 323

> eventType: https://alloc8or.re/gta5/doc/enums/eEventType.txt

## BLOCK_DECISION_MAKER_EVENT

```c
void BLOCK_DECISION_MAKER_EVENT(Hash name, int eventType)  // 0xE42FCDFD0E4196F7
```

build 323

> eventType: https://alloc8or.re/gta5/doc/enums/eEventType.txt
> 
> This is limited to 4 blocked events at a time.

## CLEAR_DECISION_MAKER_EVENT_RESPONSE

```c
void CLEAR_DECISION_MAKER_EVENT_RESPONSE(Hash name, int eventType)  // 0x4FC9381A7AEE8968
```

build 323

> eventType: https://alloc8or.re/gta5/doc/enums/eEventType.txt

## IS_SHOCKING_EVENT_IN_SPHERE

```c
BOOL IS_SHOCKING_EVENT_IN_SPHERE(int eventType, float x, float y, float z, float radius)  // 0x1374ABB7C15BAB92
```

build 323

> eventType: https://alloc8or.re/gta5/doc/enums/eEventType.txt

## REMOVE_ALL_SHOCKING_EVENTS

```c
void REMOVE_ALL_SHOCKING_EVENTS(BOOL p0)  // 0xEAABE8FDFA21274C
```

build 323

## REMOVE_SHOCKING_EVENT

```c
BOOL REMOVE_SHOCKING_EVENT(ScrHandle event)  // 0x2CDA538C44C6CCE5
```

build 323

## REMOVE_SHOCKING_EVENT_SPAWN_BLOCKING_AREAS

```c
void REMOVE_SHOCKING_EVENT_SPAWN_BLOCKING_AREAS()  // 0x340F1415B68AEADE
```

build 323

## SET_DECISION_MAKER

```c
void SET_DECISION_MAKER(Ped ped, Hash name)  // 0xB604A2942ADED0EE
```

build 323

## SUPPRESS_AGITATION_EVENTS_NEXT_FRAME

```c
void SUPPRESS_AGITATION_EVENTS_NEXT_FRAME()  // 0x5F3B7749C112D552
```

build 323

## SUPPRESS_SHOCKING_EVENT_TYPE_NEXT_FRAME

```c
void SUPPRESS_SHOCKING_EVENT_TYPE_NEXT_FRAME(int eventType)  // 0x3FD2EC8BF1F1CF30
```

build 323

> eventType: https://alloc8or.re/gta5/doc/enums/eEventType.txt

## SUPPRESS_SHOCKING_EVENTS_NEXT_FRAME

```c
void SUPPRESS_SHOCKING_EVENTS_NEXT_FRAME()  // 0x2F9A292AD0A3BD89
```

build 323

## UNBLOCK_DECISION_MAKER_EVENT

```c
void UNBLOCK_DECISION_MAKER_EVENT(Hash name, int eventType)  // 0xD7CD9CF34F2C99E8
```

build 323

> eventType: https://alloc8or.re/gta5/doc/enums/eEventType.txt

