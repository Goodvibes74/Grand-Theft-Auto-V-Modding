# CLOCK natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## ADD_TO_CLOCK_TIME

```c
void ADD_TO_CLOCK_TIME(int hours, int minutes, int seconds)  // 0xD716F30D8C8980E2
```

build 323

## ADVANCE_CLOCK_TIME_TO

```c
void ADVANCE_CLOCK_TIME_TO(int hour, int minute, int second)  // 0xC8CA9670B9D83B3B
```

build 323

## GET_CLOCK_DAY_OF_MONTH

```c
int GET_CLOCK_DAY_OF_MONTH()  // 0x3D10BC92A4DB1D35
```

build 323

## GET_CLOCK_DAY_OF_WEEK

```c
int GET_CLOCK_DAY_OF_WEEK()  // 0xD972E4BD7AEB235F
```

build 323

> Gets the current day of the week.
> 
> 0: Sunday
> 1: Monday
> 2: Tuesday
> 3: Wednesday
> 4: Thursday
> 5: Friday
> 6: Saturday

## GET_CLOCK_HOURS

```c
int GET_CLOCK_HOURS()  // 0x25223CA6B4D20B7F
```

build 323

> Gets the current ingame hour, expressed without zeros. (09:34 will be represented as 9)

## GET_CLOCK_MINUTES

```c
int GET_CLOCK_MINUTES()  // 0x13D2B8ADD79640F2
```

build 323

> Gets the current ingame clock minute.

## GET_CLOCK_MONTH

```c
int GET_CLOCK_MONTH()  // 0xBBC72712E80257A1
```

build 323

## GET_CLOCK_SECONDS

```c
int GET_CLOCK_SECONDS()  // 0x494E97C2EF27C470
```

build 323

> Gets the current ingame clock second. Note that ingame clock seconds change really fast since a day in GTA is only 48 minutes in real life.

## GET_CLOCK_YEAR

```c
int GET_CLOCK_YEAR()  // 0x961777E64BDAF717
```

build 323

## GET_LOCAL_TIME

```c
void GET_LOCAL_TIME(int* year, int* month, int* day, int* hour, int* minute, int* second)  // 0x50C7A99057A69748
```

build 323

> Gets local system time as year, month, day, hour, minute and second.
> 
> Example usage:
> 
> int year;
> int month;
> int day;
> int hour;
> int minute;
> int second;
> or use std::tm struct
> 
> TIME::GET_LOCAL_TIME(&year, &month, &day, &hour, &minute, &second);
> 

## GET_MILLISECONDS_PER_GAME_MINUTE

```c
int GET_MILLISECONDS_PER_GAME_MINUTE()  // 0x2F8B4D1C595B11DB
```

build 323

## GET_POSIX_TIME

```c
void GET_POSIX_TIME(int* year, int* month, int* day, int* hour, int* minute, int* second)  // 0xDA488F299A5B164E
```

build 323

> Gets system time as year, month, day, hour, minute and second.
> 
> Example usage:
> 
>     int year;
>  int month;
>     int day;
>   int hour;
>  int minute;
>    int second;
> 
>  TIME::GET_POSIX_TIME(&year, &month, &day, &hour, &minute, &second);
> 

## GET_UTC_TIME

```c
void GET_UTC_TIME(int* year, int* month, int* day, int* hour, int* minute, int* second)  // 0x8117E09A19EEF4D3
```

build 323 · old names: `_GET_LOCAL_TIME`, `_GET_UTC_TIME`

> Gets current UTC time

## PAUSE_CLOCK

```c
void PAUSE_CLOCK(BOOL toggle)  // 0x4055E40BD2DBEC1D
```

build 323

## SET_CLOCK_DATE

```c
void SET_CLOCK_DATE(int day, int month, int year)  // 0xB096419DF0D06CE7
```

build 323

## SET_CLOCK_TIME

```c
void SET_CLOCK_TIME(int hour, int minute, int second)  // 0x47C3B5848C3E45D8
```

build 323

> SET_CLOCK_TIME(12, 34, 56);

