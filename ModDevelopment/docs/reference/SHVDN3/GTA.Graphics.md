# GTA.Graphics (ScriptHookVDotNet v3)

[Back to the ScriptHookVDotNet v3 index](README.md)

> **Source:** `ScriptHookVDotNet3.dll` (file version 3.7.0.189, assembly version 3.7.0.189, 1,435,136 bytes, modified 2026-08-05, SHA-256 `0f2b8d30ebe79edd74cf364df3943afb7e6305d7453bc687503dcc7411ed5648`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `ScriptHookVDotNet3.xml` from the NuGet package `scripthookvdotnet3` 3.6.0 (nuget.org). The installed DLL is 3.7.0.189, so members added after 3.6.0 have no description.

## Scripted2DGfxSettings

static class `GTA.Graphics.Scripted2DGfxSettings`

### Properties

- `public static ScriptedGfxDrawOrder DrawOrder { set; }`
- `public static bool DrawsBehindPauseMenu { set; }`

### Methods

- `public static PointF GetAlignPosition(PointF offset)`
- `public static void ResetAlignment()`
- `public static void SetAlignmentOffsetAndSize(PointF offset, SizeF size)`
- `public static void SetAlignmentType(UIAlignment alignX, UIAlignment alignY)`

## ScriptedGfxDrawOrder

enum `GTA.Graphics.ScriptedGfxDrawOrder`

| Name | Value |
| --- | --- |
| `BeforeHudPriorityLow` | 0 |
| `BeforeHud` | 1 |
| `BeforeHudPriorityHigh` | 2 |
| `AfterHudPriorityLow` | 3 |
| `AfterHud` | 4 |
| `AfterHudPriorityHigh` | 5 |
| `AfterFadePriorityLow` | 6 |
| `AfterFade` | 7 |
| `AfterFadePriorityHigh` | 8 |

## TextureAsset

struct `GTA.Graphics.TextureAsset` : `IEquatable<TextureAsset>`

### Constructors

- `public TextureAsset(Txd txd, string texName)`
- `public TextureAsset(string txdName, string texName)`

### Properties

- `public string TextureName { get; set; }`
- `public Txd Txd { get; set; }`

### Methods

- `public void Deconstruct(out Txd txd, out string texName)`
- `public bool Equals(TextureAsset other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public AtHashValue HashTextureName()`
- `public static bool op_Equality(TextureAsset left, TextureAsset right)`
- `public static bool op_Inequality(TextureAsset left, TextureAsset right)`

## Txd

struct `GTA.Graphics.Txd` : `IEquatable<Txd>`, `IScriptStreamingResource`

### Constructors

- `public Txd(string name)`

### Properties

- `public bool IsLoaded { get; }`
- `public string Name { get; }`

### Methods

- `public bool Equals(Txd other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public AtHashValue HashName()`
- `public void MarkAsNoLongerNeeded()`
- `public void Request()`
- `public virtual string ToString()`
- `public static bool op_Equality(Txd left, Txd right)`
- `public static string op_Explicit(Txd value)`
- `public static Txd op_Explicit(string value)`
- `public static InputArgument op_Implicit(Txd value)`
- `public static bool op_Inequality(Txd left, Txd right)`

## UIAlignment

enum `GTA.Graphics.UIAlignment`

| Name | Value |
| --- | --- |
| `Left` | 76 |
| `Right` | 82 |
| `Top` | 84 |
| `Bottom` | 66 |
| `Ignore` | 73 |

