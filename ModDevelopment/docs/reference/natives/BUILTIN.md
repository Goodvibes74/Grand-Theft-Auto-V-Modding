# BUILTIN natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## CEIL

```c
int CEIL(float value)  // 0x11E019C8F43ACC8A
```

build 323

## COS

```c
float COS(float value)  // 0xD0FFB162F40A139C
```

build 323

## FLOOR

```c
int FLOOR(float value)  // 0xF34EE736CF047844
```

build 323

## LOG10

```c
float LOG10(float value)  // 0xE816E655DE37FE20
```

build 1493 · old names: `_LOG10`

## POW

```c
float POW(float base, float exponent)  // 0xE3621CC40F31FE2E
```

build 323

## ROUND

```c
int ROUND(float value)  // 0xF2DB717A73826179
```

build 323

## SET_THIS_THREAD_PRIORITY

```c
void SET_THIS_THREAD_PRIORITY(int priority)  // 0x42B65DEEF2EDF2A1
```

build 877

> THREAD_PRIO_HIGHEST = 0
> THREAD_PRIO_NORMAL = 1
> THREAD_PRIO_LOWEST = 2
> THREAD_PRIO_MANUAL_UPDATE = 100

## SETTIMERA

```c
void SETTIMERA(int value)  // 0xC1B1E9A034A63A62
```

build 323

## SETTIMERB

```c
void SETTIMERB(int value)  // 0x5AE11BC36633DE4E
```

build 323

## SHIFT_LEFT

```c
int SHIFT_LEFT(int value, int bitShift)  // 0xEDD95A39E5544DE8
```

build 323

## SHIFT_RIGHT

```c
int SHIFT_RIGHT(int value, int bitShift)  // 0x97EF1E5BCE9DC075
```

build 323

## SIN

```c
float SIN(float value)  // 0x0BADBFA3B172435F
```

build 323

## SQRT

```c
float SQRT(float value)  // 0x71D93B57D07F9804
```

build 323

## START_NEW_SCRIPT

```c
int START_NEW_SCRIPT(const char* scriptName, int stackSize)  // 0xE81651AD79516E48
```

build 323

> Examples:
>  g_384A = SYSTEM::START_NEW_SCRIPT("cellphone_flashhand", 1424);
>  l_10D = SYSTEM::START_NEW_SCRIPT("taxiService", 1828);
>  SYSTEM::START_NEW_SCRIPT("AM_MP_YACHT", 5000);
>  SYSTEM::START_NEW_SCRIPT("emergencycall", 512);
>  SYSTEM::START_NEW_SCRIPT("emergencycall", 512); 
>  SYSTEM::START_NEW_SCRIPT("FM_maintain_cloud_header_data", 1424);
>  SYSTEM::START_NEW_SCRIPT("FM_Mission_Controller", 31000);
>  SYSTEM::START_NEW_SCRIPT("tennis_family", 3650);
>  SYSTEM::START_NEW_SCRIPT("Celebrations", 3650);
> 
> Decompiled examples of usage when starting a script:
>  
>     SCRIPT::REQUEST_SCRIPT(a_0);
>     if (SCRIPT::HAS_SCRIPT_LOADED(a_0)) {
>         SYSTEM::START_NEW_SCRIPT(a_0, v_3);
>         SCRIPT::SET_SCRIPT_AS_NO_LONGER_NEEDED(a_0);
>         return 1;
>     }
>  
> or:
> 
>     v_2 = "MrsPhilips2";
>     SCRIPT::REQUEST_SCRIPT(v_2);
>     while (!SCRIPT::HAS_SCRIPT_LOADED(v_2)) {
>     SCRIPT::REQUEST_SCRIPT(v_2);
>     SYSTEM::WAIT(0);
>     }
>     sub_8792(36);
>     SYSTEM::START_NEW_SCRIPT(v_2, 17000);
>     SCRIPT::SET_SCRIPT_AS_NO_LONGER_NEEDED(v_2);

## START_NEW_SCRIPT_WITH_ARGS

```c
int START_NEW_SCRIPT_WITH_ARGS(const char* scriptName, Any* args, int argCount, int stackSize)  // 0xB8BA7F44DF1575E1
```

build 323

> return : script thread id, 0 if failed
> Pass pointer to struct of args in p1, size of struct goes into p2

## START_NEW_SCRIPT_WITH_NAME_HASH

```c
int START_NEW_SCRIPT_WITH_NAME_HASH(Hash scriptHash, int stackSize)  // 0xEB1C67C3A5333A92
```

build 323 · old names: `_START_NEW_STREAMED_SCRIPT`

## START_NEW_SCRIPT_WITH_NAME_HASH_AND_ARGS

```c
int START_NEW_SCRIPT_WITH_NAME_HASH_AND_ARGS(Hash scriptHash, Any* args, int argCount, int stackSize)  // 0xC4BB298BD441BE78
```

build 323 · old names: `_START_NEW_STREAMED_SCRIPT_WITH_ARGS`

## TIMERA

```c
int TIMERA()  // 0x83666F9FB8FEBD4B
```

build 323

> Counts up. Every 1000 is 1 real-time second. Use SETTIMERA(int value) to set the timer (e.g.: SETTIMERA(0)).

## TIMERB

```c
int TIMERB()  // 0xC9D9444186B5A374
```

build 323

## TIMESTEP

```c
float TIMESTEP()  // 0x0000000050597EE2
```

build 323

> Gets the current frame time.

## TO_FLOAT

```c
float TO_FLOAT(int value)  // 0xBBDA792448DB5A89
```

build 323

## VDIST

```c
float VDIST(float x1, float y1, float z1, float x2, float y2, float z2)  // 0x2A488C176D52CCA5
```

build 323

> Calculates distance between vectors.

## VDIST2

```c
float VDIST2(float x1, float y1, float z1, float x2, float y2, float z2)  // 0xB7A628320EFF8E47
```

build 323

> Calculates distance between vectors but does not perform Sqrt operations. (Its way faster)

## VMAG

```c
float VMAG(float x, float y, float z)  // 0x652D2EEEF1D3E62C
```

build 323

> Calculates the magnitude of a vector.

## VMAG2

```c
float VMAG2(float x, float y, float z)  // 0xA8CEACB4F35AE058
```

build 323

> Calculates the magnitude of a vector but does not perform Sqrt operations. (Its way faster)

## WAIT

```c
void WAIT(int ms)  // 0x4EDE34FBADD967A6
```

build 323

> Pauses execution of the current script, please note this behavior is only seen when called from one of the game script files(ysc). In order to wait an asi script use "static void WAIT(DWORD time);" found in main.h

