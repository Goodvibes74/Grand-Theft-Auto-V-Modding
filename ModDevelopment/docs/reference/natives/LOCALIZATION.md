# LOCALIZATION natives

[Back to the natives index](README.md)

> **Source:** `natives.json` from [alloc8or/gta5-nativedb-data](https://github.com/alloc8or/gta5-nativedb-data), commit `424fb51b0890` (2026-09-15), downloaded 2026-10-09. It is the data behind https://nativedb.dotindustries.dev.  
> **Method:** downloaded by `ModDevelopment/tools/ApiDocGen` and converted to Markdown. Names, parameters and descriptions are community research, not from Rockstar or from the game files. The hashes are what the game uses to identify each native.

## GET_CURRENT_LANGUAGE

```c
int GET_CURRENT_LANGUAGE()  // 0x2BDD44CC428A7EAE
```

build 323 · old names: `_GET_UI_LANGUAGE_ID`, `_GET_CURRENT_LANGUAGE_ID`

> 0 = american (en-US)
> 1 = french (fr-FR)
> 2 = german (de-DE)
> 3 = italian (it-IT)
> 4 = spanish (es-ES)
> 5 = brazilian (pt-BR)
> 6 = polish (pl-PL)
> 7 = russian (ru-RU)
> 8 = korean (ko-KR)
> 9 = chinesetrad (zh-TW)
> 10 = japanese (ja-JP)
> 11 = mexican (es-MX)
> 12 = chinesesimp (zh-CN)

## LOCALIZATION_GET_SYSTEM_DATE_TYPE

```c
int LOCALIZATION_GET_SYSTEM_DATE_TYPE()  // 0xA8AE43AEC1A61314
```

build 323 · old names: `_GET_USER_LANGUAGE_ID`, `_LOCALIZATION_GET_SYSTEM_DATE_FORMAT`

> Possible return values: 0, 1, 2

## LOCALIZATION_GET_SYSTEM_LANGUAGE

```c
int LOCALIZATION_GET_SYSTEM_LANGUAGE()  // 0x497420E022796B3F
```

build 877 · old names: `_LOCALIZATION_GET_SYSTEM_LANGUAGE`

> Same return values as GET_CURRENT_LANGUAGE

