# LemonUI.Tools (LemonUI for SHVDN v3)

[Back to the LemonUI for SHVDN v3 index](README.md)

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

## Extensions

static class `LemonUI.Tools.Extensions`

Extensions for converting values between relative and scaled.

### Methods

- `public static PointF ToRelative(PointF point)`
  - Converts a scaled 1080p-based position into a relative one.
  - `point`: The scaled PointF.
  - Returns: A new PointF with relative values.
- `public static SizeF ToRelative(SizeF size)`
  - Converts a scaled 1080p-based position into a relative one.
  - `size`: The scaled SizeF.
  - Returns: A new SizeF with relative values.
- `public static PointF ToScaled(PointF point)`
  - Converts a relative 0-1 position into a scaled one.
  - `point`: The relative PointF.
  - Returns: A new PointF with scaled values.
- `public static SizeF ToScaled(SizeF size)`
  - Converts a relative 0-1 position into a scaled one.
  - `size`: The relative SizeF.
  - Returns: A new SizeF with scaled values.
- `public static float ToXRelative(float x)`
  - Converts the scaled X or Width to a relative one.
  - `x`: The value to convert.
  - Returns: A relative float between 0 and 1.
- `public static float ToXScaled(float x)`
  - Converts the relative X or Width float to a scaled one.
  - `x`: The float to convert.
  - Returns: A scaled float.
- `public static float ToYRelative(float y)`
  - Converts the scaled Y or Height to a relative one.
  - `y`: The value to convert.
  - Returns: A relative float between 0 and 1.
- `public static float ToYScaled(float y)`
  - Converts the relative Y or Height float to a scaled one.
  - `y`: The float to convert.
  - Returns: A scaled float.

## GameScreen

static class `LemonUI.Tools.GameScreen`

The screen of the game being rendered.

### Properties

- `public static SizeF AbsoluteResolution { get; }`
  - Gets the actual Screen resolution the game is being rendered at.
- `public static float AspectRatio { get; }`
  - The Aspect Ratio of the screen.
- `public static PointF Cursor { get; }`
  - The location of the cursor on screen between 0 and 1.

### Methods

- `public static bool IsCursorInArea(PointF pos, SizeF size)`
  - Checks if the cursor is inside of the scaled area.
  - `pos`: The scaled position.
  - `size`: The scaled size of the area.
  - Returns: `true` if the cursor is in the specified bounds, `false` otherwise.
- `public static bool IsCursorInArea(float x, float y, float width, float height)`
  - Checks if the cursor is inside of the scaled area.
  - `x`: The scaled X position.
  - `y`: The scaled Y position.
  - `width`: The scaled width of the area.
  - `height`: The scaled height of the area.
  - Returns: `true` if the cursor is in the specified bounds, `false` otherwise.
- `public static void ShowCursorThisFrame()`
  - Shows the cursor during the current game frame.

## SafeZone

static class `LemonUI.Tools.SafeZone`

Tools for changing, resetting and retrieving the Safe Zone of the game.

### Properties

- `public static PointF BottomLeft { get; }`
  - The bottom left corner after the safe zone.
- `public static PointF BottomRight { get; }`
  - The bottom right corner after the safe zone.
- `public static float Size { get; }`
  - The size of the safe zone.
- `public static PointF TopLeft { get; }`
  - The top left corner after the safe zone.
- `public static PointF TopRight { get; }`
  - The top right corner after the safe zone.

### Methods

- `public static PointF GetPositionAt(PointF position, Alignment horizontal, GFXAlignment vertical)`
  - Gets the specified position with the specified safe zone alignment.
  - `position`: The position to get.
  - `horizontal`: The horizontal alignment.
  - `vertical`: The vertical alignment.
  - Returns: The safe zone alignment.
- `public static PointF GetPositionAt(PointF position, GFXAlignment horizontal, GFXAlignment vertical)`
  - Gets the specified position with the specified safe zone alignment.
  - `position`: The position to get.
  - `horizontal`: The horizontal alignment.
  - `vertical`: The vertical alignment.
  - Returns: The scaled safe zone alignment.
- `public static PointF GetSafePosition(PointF og)`
  - Converts the specified position into one that is aware of the safe zone.
  - `og`: The original 1080p based position.
  - Returns: A new 1080p based position that is aware of the the Alignment.
- `public static PointF GetSafePosition(float x, float y)`
  - Converts the specified position into one that is aware of `SetAlignment`.
  - `x`: The 1080p based X position.
  - `y`: The 1080p based Y position.
  - Returns: A new 1080p based position that is aware of the the Alignment.
- `public static void ResetAlignment()`
  - Resets the alignment of the safe zone.
- `public static void SetAlignment(Alignment horizontal, GFXAlignment vertical)`
  - Sets the alignment for the safe zone.
  - `horizontal`: The Horizontal alignment of the items.
  - `vertical`: The vertical alignment of the items.
- `public static void SetAlignment(GFXAlignment horizontal, GFXAlignment vertical)`
  - Sets the alignment for the safe zone.
  - `horizontal`: The Horizontal alignment of the items.
  - `vertical`: The vertical alignment of the items.

