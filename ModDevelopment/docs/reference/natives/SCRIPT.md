# SCRIPT natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## _SEND_TU_SCRIPT_EVENT_NEW

```c
void _SEND_TU_SCRIPT_EVENT_NEW(int eventGroup, Any* eventData, int eventDataSize, int playerBits, Hash eventType)  // 0x71A6F836422FDD2B
```

build 3095

> New variant of SEND_TU_SCRIPT_EVENT that automatically initializes the event data header.
> See TRIGGER_SCRIPT_EVENT for more info.

## BG_DOES_LAUNCH_PARAM_EXIST

```c
BOOL BG_DOES_LAUNCH_PARAM_EXIST(int scriptIndex, const char* p1)  // 0x0F6F1EBBC4E1D5E6
```

build 323

## BG_END_CONTEXT

```c
void BG_END_CONTEXT(const char* contextName)  // 0xDC2BACD920D0A0DD
```

build 323

> Deletes the given context from the background scripts context map.

## BG_END_CONTEXT_HASH

```c
void BG_END_CONTEXT_HASH(Hash contextHash)  // 0x107E5CC7CA942BC1
```

build 323

> Hashed version of BG_END_CONTEXT.

## BG_GET_LAUNCH_PARAM_VALUE

```c
int BG_GET_LAUNCH_PARAM_VALUE(int scriptIndex, const char* p1)  // 0x22E21FBCFC88C149
```

build 323

## BG_GET_SCRIPT_ID_FROM_NAME_HASH

```c
int BG_GET_SCRIPT_ID_FROM_NAME_HASH(Hash p0)  // 0x829CD22E043A2577
```

build 323

## BG_IS_EXITFLAG_SET

```c
BOOL BG_IS_EXITFLAG_SET()  // 0x836B62713E0534CA
```

build 323 · old names: `_BG_EXITED_BECAUSE_BACKGROUND_THREAD_STOPPED`

> Returns true if bit 0 in GtaThread+0x154 is set.

## BG_SET_EXITFLAG_RESPONSE

```c
void BG_SET_EXITFLAG_RESPONSE()  // 0x760910B49D2B98EA
```

build 323

> Sets bit 1 in GtaThread+0x154

## BG_START_CONTEXT

```c
void BG_START_CONTEXT(const char* contextName)  // 0x9D5A25BADB742ACD
```

build 323

> Inserts the given context into the background scripts context map.

## BG_START_CONTEXT_HASH

```c
void BG_START_CONTEXT_HASH(Hash contextHash)  // 0x75B18E49607874C7
```

build 323

> Hashed version of BG_START_CONTEXT.

## COMMIT_TO_LOADINGSCREEN_SELCTION

```c
void COMMIT_TO_LOADINGSCREEN_SELCTION()  // 0xB1577667C3708F9B
```

build 323

## DOES_SCRIPT_EXIST

```c
BOOL DOES_SCRIPT_EXIST(const char* scriptName)  // 0xFC04745FBE67C19A
```

build 323

## DOES_SCRIPT_WITH_NAME_HASH_EXIST

```c
BOOL DOES_SCRIPT_WITH_NAME_HASH_EXIST(Hash scriptHash)  // 0xF86AA3C56BA31381
```

build 323 · old names: `_DOES_SCRIPT_WITH_NAME_HASH_EXIST`

## GET_EVENT_AT_INDEX

```c
int GET_EVENT_AT_INDEX(int eventGroup, int eventIndex)  // 0xD8F66A3A60C62153
```

build 323

> eventGroup: 0 = SCRIPT_EVENT_QUEUE_AI (CEventGroupScriptAI), 1 = SCRIPT_EVENT_QUEUE_NETWORK (CEventGroupScriptNetwork)

## GET_EVENT_DATA

```c
BOOL GET_EVENT_DATA(int eventGroup, int eventIndex, Any* eventData, int eventDataSize)  // 0x2902843FCD2B2D79
```

build 323

> eventGroup: 0 = SCRIPT_EVENT_QUEUE_AI (CEventGroupScriptAI), 1 = SCRIPT_EVENT_QUEUE_NETWORK (CEventGroupScriptNetwork)
> 
> Note: eventDataSize is NOT the size in bytes, it is the size determined by the SIZE_OF operator (RAGE Script operator, not C/C++ sizeof). That is, the size in bytes divided by 8 (script variables are always 8-byte aligned!).

## GET_EVENT_EXISTS

```c
BOOL GET_EVENT_EXISTS(int eventGroup, int eventIndex)  // 0x936E6168A9BCEDB5
```

build 323

> eventGroup: 0 = SCRIPT_EVENT_QUEUE_AI (CEventGroupScriptAI), 1 = SCRIPT_EVENT_QUEUE_NETWORK (CEventGroupScriptNetwork)

## GET_HASH_OF_THIS_SCRIPT_NAME

```c
Hash GET_HASH_OF_THIS_SCRIPT_NAME()  // 0x8A1C8B1738FFE87E
```

build 323 · old names: `_GET_THIS_SCRIPT_HASH`

## GET_ID_OF_THIS_THREAD

```c
int GET_ID_OF_THIS_THREAD()  // 0xC30338E8088E2E21
```

build 323

## GET_NAME_OF_SCRIPT_WITH_THIS_ID

```c
const char* GET_NAME_OF_SCRIPT_WITH_THIS_ID(int threadId)  // 0x05A42BA9FC8DA96B
```

build 323 · old names: `_GET_THREAD_NAME`, `_GET_NAME_OF_THREAD`

## GET_NO_LOADING_SCREEN

```c
BOOL GET_NO_LOADING_SCREEN()  // 0x18C1270EA7F199BC
```

build 323 · old names: `_GET_NO_LOADING_SCREEN`

## GET_NUMBER_OF_EVENTS

```c
int GET_NUMBER_OF_EVENTS(int eventGroup)  // 0x5F92A689A06620AA
```

build 323

> eventGroup: 0 = SCRIPT_EVENT_QUEUE_AI (CEventGroupScriptAI), 1 = SCRIPT_EVENT_QUEUE_NETWORK (CEventGroupScriptNetwork)

## GET_NUMBER_OF_THREADS_RUNNING_THE_SCRIPT_WITH_THIS_HASH

```c
int GET_NUMBER_OF_THREADS_RUNNING_THE_SCRIPT_WITH_THIS_HASH(Hash scriptHash)  // 0x2C83A9DA6BFFC4F9
```

build 323 · old names: `_GET_NUMBER_OF_INSTANCES_OF_STREAMED_SCRIPT`, `_GET_NUMBER_OF_INSTANCES_OF_SCRIPT_WITH_NAME_HASH`, `_GET_NUMBER_OF_REFERENCES_OF_SCRIPT_WITH_NAME_HASH`

> Gets the number of instances of the specified script is currently running.
> 
> Actually returns numRefs - 1.
> if (program)
> 	v3 = rage::scrProgram::GetNumRefs(program) - 1;
> return v3;

## GET_THIS_SCRIPT_NAME

```c
const char* GET_THIS_SCRIPT_NAME()  // 0x442E0A7EDE4A738A
```

build 323

## HAS_SCRIPT_LOADED

```c
BOOL HAS_SCRIPT_LOADED(const char* scriptName)  // 0xE6CC9F3BA0FB9EF1
```

build 323

> Returns if a script has been loaded into the game. Used to see if a script was loaded after requesting.

## HAS_SCRIPT_WITH_NAME_HASH_LOADED

```c
BOOL HAS_SCRIPT_WITH_NAME_HASH_LOADED(Hash scriptHash)  // 0x5F0F0C783EB16C04
```

build 323 · old names: `_HAS_STREAMED_SCRIPT_LOADED`

## IS_THREAD_ACTIVE

```c
BOOL IS_THREAD_ACTIVE(int threadId)  // 0x46E9AE36D8FA6417
```

build 323

## REQUEST_SCRIPT

```c
void REQUEST_SCRIPT(const char* scriptName)  // 0x6EB5F71AA68F2E8E
```

build 323

## REQUEST_SCRIPT_WITH_NAME_HASH

```c
void REQUEST_SCRIPT_WITH_NAME_HASH(Hash scriptHash)  // 0xD62A67D26D9653E6
```

build 323 · old names: `_REQUEST_STREAMED_SCRIPT`

## SCRIPT_THREAD_ITERATOR_GET_NEXT_THREAD_ID

```c
int SCRIPT_THREAD_ITERATOR_GET_NEXT_THREAD_ID()  // 0x30B4FA1C82DD4B9F
```

build 323 · old names: `_GET_ID_OF_NEXT_THREAD_IN_ENUMERATION`

> If the function returns 0, the end of the iteration has been reached.

## SCRIPT_THREAD_ITERATOR_RESET

```c
void SCRIPT_THREAD_ITERATOR_RESET()  // 0xDADFADA5A20143A8
```

build 323 · old names: `_BEGIN_ENUMERATING_THREADS`

> Starts a new iteration of the current threads.
> Call this first, then SCRIPT_THREAD_ITERATOR_GET_NEXT_THREAD_ID (0x30B4FA1C82DD4B9F)

## SET_NO_LOADING_SCREEN

```c
void SET_NO_LOADING_SCREEN(BOOL toggle)  // 0x5262CC1995D07E09
```

build 323

## SET_SCRIPT_AS_NO_LONGER_NEEDED

```c
void SET_SCRIPT_AS_NO_LONGER_NEEDED(const char* scriptName)  // 0xC90D2DCACD56184C
```

build 323

## SET_SCRIPT_WITH_NAME_HASH_AS_NO_LONGER_NEEDED

```c
void SET_SCRIPT_WITH_NAME_HASH_AS_NO_LONGER_NEEDED(Hash scriptHash)  // 0xC5BC038960E9DB27
```

build 323 · old names: `_SET_STREAMED_SCRIPT_AS_NO_LONGER_NEEDED`

## SHUTDOWN_LOADING_SCREEN

```c
void SHUTDOWN_LOADING_SCREEN()  // 0x078EBE9809CCD637
```

build 323

## TERMINATE_THIS_THREAD

```c
void TERMINATE_THIS_THREAD()  // 0x1090044AD1DA76FA
```

build 323

## TERMINATE_THREAD

```c
void TERMINATE_THREAD(int threadId)  // 0xC8B189ED9138BCD4
```

build 323

## TRIGGER_SCRIPT_EVENT

```c
void TRIGGER_SCRIPT_EVENT(int eventGroup, Any* eventData, int eventDataSize, int playerBits)  // 0x5AE99C571D5BBE5D
```

build 323

> eventGroup: 0 = SCRIPT_EVENT_QUEUE_AI (CEventGroupScriptAI), 1 = SCRIPT_EVENT_QUEUE_NETWORK (CEventGroupScriptNetwork)
> 
> Note: eventDataSize is NOT the size in bytes, it is the size determined by the SIZE_OF operator (RAGE Script operator, not C/C++ sizeof). That is, the size in bytes divided by 8 (script variables are always 8-byte aligned!).
> 
> playerBits (also known as playersToBroadcastTo) is a bitset that indicates which players this event should be sent to. In order to send the event to specific players only, use (1 << playerIndex). Set all bits if it should be broadcast to all players.

