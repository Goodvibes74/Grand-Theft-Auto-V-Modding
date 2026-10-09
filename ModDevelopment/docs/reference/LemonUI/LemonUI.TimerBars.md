# LemonUI.TimerBars (LemonUI for SHVDN v3)

[Back to the LemonUI for SHVDN v3 index](README.md)

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

## ObjectiveSpacing

enum `LemonUI.TimerBars.ObjectiveSpacing`

The spacing of the objectives in the timer bar.

| Name | Value | Description |
| --- | --- | --- |
| `Equal` | 0 | The objectives will be equally spaced. |
| `Fixed` | 1 | The items will all have the same spacing. |

## TimerBar

class `LemonUI.TimerBars.TimerBar` : `IDrawable`

Represents a Bar with text information shown in the bottom right.

### Constructors

- `public TimerBar(string title, string info)`
  - Creates a new `TimerBar` with the specified Title and Value.
  - `title`: The title of the bar.
  - `info`: The information shown on the bar.

### Properties

- `public Color Color { get; set; }`
  - The color of the information text.
- `public string Info { get; set; }`
  - The information shown on the right.
- `public float InfoWidth { get; }`
  - The Width of the information text.
- `public string Title { get; set; }`
  - The title of the bar, shown on the left.

### Methods

- `public virtual void Draw()`
  - Draws the timer bar information.
- `public virtual void Recalculate(PointF pos)`
  - Recalculates the position of the timer bar elements based on the location of it on the screen.
  - `pos`: The Top Left position of the Timer Bar.

### Fields

- `protected readonly ScaledTexture background`
  - The background of the timer bar.
- `protected readonly ScaledText info`
  - The information of the Timer Bar.
- `protected readonly ScaledText title`
  - The title of the timer bar.

## TimerBarCollection

class `LemonUI.TimerBars.TimerBarCollection` : `IContainer<TimerBar>`, `IRecalculable`, `IProcessable`

A collection or Set of `TimerBar`.

### Constructors

- `public TimerBarCollection(params TimerBar[] bars)`
  - Creates a new collection of Timer Bars.

### Properties

- `public PointF Offset { get; set; }`
  - The offset from it's starting point on the bottom right.
- `public List<TimerBar> TimerBars { get; }`
  - The `TimerBar`s that are part of this collection.
- `public bool Visible { get; set; }`
  - If this collection of Timer Bars is visible to the user.

### Methods

- `public void Add(TimerBar bar)`
  - Adds a `TimerBar` onto this collection.
  - `bar`: The `TimerBar` to add.
- `public void Clear()`
  - Removes all of the `TimerBar` in this collection.
- `public bool Contains(TimerBar bar)`
  - Checks if the `TimerBar` is part of this collection.
  - `bar`: The `TimerBar` to check.
- `public void Process()`
  - Draws the known timer bars.
- `public void Recalculate()`
  - Recalculates the positions and sizes of the `TimerBar`.
- `public void Remove(TimerBar bar)`
  - Removes a `TimerBar` from the Collection.
  - `bar`: The `TimerBar` to remove.
- `public void Remove(Func<TimerBar, bool> func)`
  - Removes all of the `TimerBar` that match the function.
  - `func`: The function to check the `TimerBar`.

## TimerBarObjective

class `LemonUI.TimerBars.TimerBarObjective` : `TimerBar`, `IDrawable`

A timer bar for a specific amount of objectives.

### Constructors

- `public TimerBarObjective(string title)`
  - Creates a new timer bar used to show objectives.
  - `title`: The title of the objective bar.

### Properties

- `public int Completed { get; set; }`
  - The number of completed objectives.
- `public Color CompletedColor { get; set; }`
  - The color used for completed objectives.
- `public int Count { get; set; }`
  - The number of objectives shown in the timer bar.
- `public ObjectiveSpacing Spacing { get; set; }`
  - The type of spacing between the objectives .

### Methods

- `public virtual void Draw()`
  - Draws the objective timer bar.
- `public virtual void Recalculate(PointF pos)`

## TimerBarProgress

class `LemonUI.TimerBars.TimerBarProgress` : `TimerBar`, `IDrawable`

Represents a Timer Bar that shows the progress of something.

### Constructors

- `public TimerBarProgress(string title)`
  - Creates a new `TimerBarProgress` with the specified title.
  - `title`: The title of the bar.

### Properties

- `public Color BackgroundColor { get; set; }`
  - The Background color of the Progress bar.
- `public Color ForegroundColor { get; set; }`
  - The Foreground color of the Progress bar.
- `public float Progress { get; set; }`
  - The progress of the bar.

### Methods

- `public virtual void Draw()`
  - Draws the TimerBar.
- `public virtual void Recalculate(PointF pos)`
  - Recalculates the position of the timer bar elements based on the location of it on the screen.
  - `pos`: The Top Left position of the Timer Bar.

### Fields

- `protected readonly ScaledRectangle barBackground`
  - The background of the Progress Bar.
- `protected readonly ScaledRectangle barForeground`
  - The foreground of the Progress Bar.

