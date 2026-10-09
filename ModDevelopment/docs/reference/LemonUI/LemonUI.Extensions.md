# LemonUI.Extensions (LemonUI for SHVDN v3)

[Back to the LemonUI for SHVDN v3 index](README.md)

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

## FloatExtensions

static class `LemonUI.Extensions.FloatExtensions`

> **Obsolete.** Please use LemonUI.Tools.Extensions instead.

Extensions for the float class.

### Methods

- `public static float ToXAbsolute(float fin)`
  - Converts an relative X or Width float to an scaled one.
  - `fin`: The float to convert.
  - Returns: A scaled float.
- `public static float ToXRelative(float fin)`
  - Converts a scaled X or Width float to a relative one.
  - `fin`: The float to convert.
  - Returns: A relative float between 0 and 1.
- `public static float ToYAbsolute(float fin)`
  - Converts an relative Y or Height float to an scaled one.
  - `fin`: The float to convert.
  - Returns: A scaled float.
- `public static float ToYRelative(float fin)`
  - Converts a scaled Y or Height float to a relative one.
  - `fin`: The float to convert.
  - Returns: A relative float between 0 and 1.

## PointExtensions

static class `LemonUI.Extensions.PointExtensions`

> **Obsolete.** Please use LemonUI.Tools.Extensions instead.

Extensions for the Point and PointF classes.

### Methods

- `public static PointF ToAbsolute(PointF point)`
  - Converts a normalized 0-1 position into a scaled one.
  - `point`: The relative PointF.
  - Returns: A new PointF with scaled values.
- `public static PointF ToRelative(PointF point)`
  - Converts a scaled 1080-based position into a relative one.
  - `point`: The scaled PointF.
  - Returns: A new PointF with relative values.

## SizeExtensions

static class `LemonUI.Extensions.SizeExtensions`

> **Obsolete.** Please use LemonUI.Tools.Extensions instead.

Extensions for the Size and SizeF classes.

### Methods

- `public static SizeF ToAbsolute(SizeF size)`
  - Converts a normalized 0-1 size into a scaled one.
  - `size`: The relative SizeF.
  - Returns: A new SizeF with scaled values.
- `public static SizeF ToRelative(SizeF size)`
  - Converts a scaled 1080-based size into a relative one.
  - `size`: The scaled SizeF.
  - Returns: A new SizeF with relative values.

