# LemonUI.Elements (LemonUI for SHVDN v3)

[Back to the LemonUI for SHVDN v3 index](README.md)

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

## BaseElement

abstract class `LemonUI.Elements.BaseElement` : `I2Dimensional`, `IRecalculable`, `IDrawable`

Base class for all of the 2D elements.

### Constructors

- `public BaseElement(PointF pos, SizeF size)`
  - Creates a new `BaseElement` with the specified Position and Size.
  - `pos`: The position of the Element.
  - `size`: The size of the Element.

### Properties

- `public Color Color { get; set; }`
  - The Color of the drawable.
- `public float Heading { get; set; }`
  - The rotation of the drawable.
- `public PointF Position { get; set; }`
  - The Position of the drawable.
- `public SizeF Size { get; set; }`
  - The Size of the drawable.

### Methods

- `public abstract void Draw()`
  - Draws the item on the screen.
- `public virtual void Recalculate()`
  - Recalculates the size and position of this item.

### Fields

- `protected PointF literalPosition`
  - The 1080 scaled position.
- `protected SizeF literalSize`
  - The 1080 scaled size.
- `protected PointF relativePosition`
  - The relative position between 0 and 1.
- `protected SizeF relativeSize`
  - The relative size between 0 and 1.

## I2Dimensional

interface `LemonUI.Elements.I2Dimensional` : `IRecalculable`, `IDrawable`

A 2D item that can be drawn on the screen.

### Properties

- `public Color Color { get; set; }`
  - The Color of the drawable.
- `public PointF Position { get; set; }`
  - The Position of the drawable.
- `public SizeF Size { get; set; }`
  - The Size of the drawable.

## IText

interface `LemonUI.Elements.IText` : `IRecalculable`, `IDrawable`

A Drawable screen text.

### Properties

- `public Alignment Alignment { get; set; }`
  - The alignment of the text.
- `public Color Color { get; set; }`
  - The color of the text.
- `public Font Font { get; set; }`
  - The game font to use.
- `public int LineCount { get; }`
  - The number of lines used by this text.
- `public float LineHeight { get; }`
  - The height of each line of text.
- `public bool Outline { get; set; }`
  - If the text should have an outline.
- `public PointF Position { get; set; }`
  - The position of the text.
- `public float Scale { get; set; }`
  - The scale of the text.
- `public bool Shadow { get; set; }`
  - If the text should have a drop down shadow.
- `public string Text { get; set; }`
  - The text to draw.
- `public float Width { get; }`
  - The width that the text takes from the screen.
- `public float WordWrap { get; set; }`
  - The maximum distance from X where the text would wrap into a new line.

## ScaledAnim

class `LemonUI.Elements.ScaledAnim` : `ScaledTexture`, `I2Dimensional`, `IRecalculable`, `IDrawable`

A scaled animation using YTD files with all of the frames.

### Constructors

- `public ScaledAnim(string dict, PointF pos, SizeF size)`
  - Creates a new dictionary based animation.
  - `dict`: The texture dictionary (YTD) to use.
  - `pos`: The position of the animation.
  - `size`: The size of the animation.
- `public ScaledAnim(string dict, SizeF size)`
  - Creates a new dictionary based animation.
  - `dict`: The texture dictionary (YTD) to use.
  - `size`: The size of the animation.
- `public ScaledAnim(string dict)`
  - Creates a new dictionary based animation.
  - `dict`: The texture dictionary (YTD) to use.

### Properties

- `public int Duration { get; set; }`
  - The duration of the animation in milliseconds.
- `public float FrameRate { get; set; }`
  - The total number of frames per second.

### Methods

- `public virtual void Draw()`
  - Draws the animation.
- `public virtual void DrawSpecific(PointF topLeft, PointF bottomRight)`
  - Draws the animation while only drawing a specific part of the element.
  - `topLeft`: The top left corner of the area to draw.
  - `bottomRight`: The bottom right corner of the area to draw.

## ScaledBink

class `LemonUI.Elements.ScaledBink` : `BaseElement`, `I2Dimensional`, `IRecalculable`, `IDrawable`, `IDisposable`

A Bink Video file.

### Constructors

- `public ScaledBink(string name, PointF pos, SizeF size)`
  - Creates a new Bink Video playback.
  - `name`: The name of the bik file.
  - `pos`: The position of the video window.
  - `size`: The size of the video window.
- `public ScaledBink(string name, SizeF size)`
  - Creates a new Bink Video playback.
  - `name`: The name of the bik file.
  - `size`: The size of the video window.
- `public ScaledBink(string name)`
  - Creates a new Bink Video playback.
  - `name`: The name of the bik file.

### Properties

- `public int Id { get; }`
  - The ID of the Bink Video Instance.
- `public string Name { get; set; }`
  - The name of the Bink Video file.

### Methods

- `public void Dispose()`
  - Disposes the Bink Video ID.
- `public virtual void Draw()`
  - Draws the Bink Movie at the specified location.
- `protected virtual void Finalize()`
  - Finalizes an instance of the `ScaledBink` class.
- `public virtual void Recalculate()`
- `public void Stop()`
  - Stops the playback of the Bink Video.

## ScaledRectangle

class `LemonUI.Elements.ScaledRectangle` : `BaseElement`, `I2Dimensional`, `IRecalculable`, `IDrawable`

A 2D rectangle.

### Constructors

- `public ScaledRectangle(PointF pos, SizeF size)`
  - Creates a new `ScaledRectangle` with the specified Position and Size.
  - `pos`: The position of the Rectangle.
  - `size`: The size of the Rectangle.

### Methods

- `public virtual void Draw()`
  - Draws the rectangle on the screen.
- `public virtual void Recalculate()`
  - Recalculates the position based on the size.

## ScaledText

class `LemonUI.Elements.ScaledText` : `IText`, `IRecalculable`, `IDrawable`

A text string.

### Constructors

- `public ScaledText(PointF pos, string text, float scale, Font font)`
  - Creates a text with the specified options
  - `pos`: The position where the text should be located.
  - `text`: The text to show.
  - `scale`: The scale of the text.
  - `font`: The font to use.
- `public ScaledText(PointF pos, string text, float scale)`
  - Creates a text with the specified options.
  - `pos`: The position where the text should be located.
  - `text`: The text to show.
  - `scale`: The scale of the text.
- `public ScaledText(PointF pos, string text)`
  - Creates a text with the specified options.
  - `pos`: The position where the text should be located.
  - `text`: The text to show.

### Properties

- `public Alignment Alignment { get; set; }`
  - The alignment of the text.
- `public Color Color { get; set; }`
  - The color of the text.
- `public Font Font { get; set; }`
  - The game font to use.
- `public int LineCount { get; }`
  - The number of lines used by this text.
- `public float LineHeight { get; }`
  - The relative height of each line in the text.
- `public bool Outline { get; set; }`
  - If the test should have an outline.
- `public PointF Position { get; set; }`
  - The position of the text.
- `public float Scale { get; set; }`
  - The scale of the text.
- `public bool Shadow { get; set; }`
  - If the text should have a drop down shadow.
- `public string Text { get; set; }`
  - The text to draw.
- `public float Width { get; }`
  - The width that the text takes from the screen.
- `public float WordWrap { get; set; }`
  - The distance from the start position where the text will be wrapped into new lines.

### Methods

- `public void Draw()`
  - Draws the text on the screen.
- `public void Recalculate()`
  - Recalculates the size, position and word wrap of this item.

## ScaledTexture

class `LemonUI.Elements.ScaledTexture` : `BaseElement`, `I2Dimensional`, `IRecalculable`, `IDrawable`

A 2D game texture.

### Constructors

- `public ScaledTexture(PointF pos, SizeF size, string dictionary, string texture)`
  - Creates a new `ScaledTexture` with a Position and Size of zero.
  - `pos`: The position of the Texture.
  - `size`: The size of the Texture.
  - `dictionary`: The dictionary where the texture is located.
  - `texture`: The texture to draw.
- `public ScaledTexture(string dictionary, string texture)`
  - Creates a new `ScaledTexture` with a Position and Size of Zero.
  - `dictionary`: The dictionary where the texture is located.
  - `texture`: The texture to draw.

### Properties

- `public string Dictionary { get; set; }`
  - The dictionary where the texture is loaded.
- `public string Texture { get; set; }`
  - The texture to draw from the dictionary.

### Methods

- `public virtual void Draw()`
  - Draws the texture on the screen.
- `public virtual void DrawSpecific(PointF topLeft, PointF bottomRight)`
  - Draws a specific part of the texture on the screen.
  - `topLeft`: The top left corner of the area to draw.
  - `bottomRight`: The bottom right corner of the area to draw.
- `public virtual void Recalculate()`
  - Recalculates the position based on the size.

