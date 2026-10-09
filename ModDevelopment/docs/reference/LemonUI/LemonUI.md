# LemonUI (LemonUI for SHVDN v3)

[Back to the LemonUI for SHVDN v3 index](README.md)

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

## GFXAlignment

enum `LemonUI.GFXAlignment`

Represents the internal alignment of screen elements.

| Name | Value | Description |
| --- | --- | --- |
| `Bottom` | 66 | Vertical Alignment to the Bottom. |
| `Top` | 84 | Vertical Alignment to the Top. |
| `Center` | 67 | Centered Vertically or Horizontally. |
| `Left` | 76 | Horizontal Alignment to the Left. |
| `Right` | 82 | Horizontal Alignment to the Right. |

## IContainer<T>

interface `LemonUI.IContainer`1` : `IRecalculable`, `IProcessable`

Represents a container that can hold other UI Elements.

### Methods

- `public void Add(T item)`
  - Adds the specified item into the Container.
  - `item`: The item to add.
- `public void Clear()`
  - Clears all of the items in the container.
- `public bool Contains(T item)`
  - Checks if the item is part of the container.
  - `item`: The item to check.
  - Returns: `true` if the item is in this container, `false` otherwise.
- `public void Remove(T item)`
  - Removes the item from the container.
  - `item`: The item to remove.
- `public void Remove(Func<T, bool> func)`
  - Removes all of the items that match the function.
  - `func`: The function to check items.

## IDrawable

interface `LemonUI.IDrawable`

Represents an item that can be drawn.

### Methods

- `public void Draw()`
  - Draws the item on the screen.

## IProcessable

interface `LemonUI.IProcessable`

Interface for items that can be processed in an Object Pool.

### Properties

- `public bool Visible { get; set; }`
  - If this processable item is visible on the screen.

### Methods

- `public void Process()`
  - Processes the object.

## IRecalculable

interface `LemonUI.IRecalculable`

Interface for classes that have values that need to be recalculated on resolution changes.

### Methods

- `public void Recalculate()`
  - Recalculates the values.

## ObjectPool

class `LemonUI.ObjectPool` : `IEnumerable<IProcessable>`, `IEnumerable`

Manager for Menus and Items.

### Constructors

- `public ObjectPool()`

### Properties

- `public bool AreAnyVisible { get; }`
  - Checks if there are objects visible on the screen.

### Methods

- `public void Add(IProcessable obj)`
  - Adds the object into the pool.
  - `obj`: The object to add.
- `public void ForEach<T>(Action<T> action)`
  - Performs the specified action on each element that matches T.
  - `action`: The action delegate to perform on each T.
- `public IEnumerator<IProcessable> GetEnumerator()`
- `public void HideAll()`
  - Hides all of the objects.
- `public void Process()`
  - Processes the objects and features in this pool. This needs to be called every tick.
- `public void RefreshAll()`
  - Refreshes all of the items.
- `public void Remove(IProcessable obj)`
  - Removes the object from the pool.
  - `obj`: The object to remove.

### Events

- `public event ResolutionChangedEventHandler ResolutionChanged`
  - Event triggered when the game resolution is changed.
- `public event SafeZoneChangedEventHandler SafezoneChanged`
  - Event triggered when the Safezone size option in the Display settings is changed.

## ResolutionChangedEventArgs

class `LemonUI.ResolutionChangedEventArgs`

Represents the information after a Resolution Change in the game.

### Properties

- `public SizeF After { get; }`
  - The Game Resolution after it was changed.
- `public SizeF Before { get; }`
  - The Game Resolution before it was changed.

## ResolutionChangedEventHandler

delegate `LemonUI.ResolutionChangedEventHandler` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that reports a Resolution change in the Game Settings.

### Constructors

- `public ResolutionChangedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, ResolutionChangedEventArgs e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, ResolutionChangedEventArgs e)`

## SafeZoneChangedEventArgs

class `LemonUI.SafeZoneChangedEventArgs`

Represents the information after a Safe Zone Change in the game.

### Properties

- `public float After { get; }`
  - The Safezone size after the change.
- `public float Before { get; }`
  - The raw Safezone size before the change.

## SafeZoneChangedEventHandler

delegate `LemonUI.SafeZoneChangedEventHandler` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that reports a Safe Zone change in the Game Settings.

### Constructors

- `public SafeZoneChangedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, SafeZoneChangedEventArgs e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, SafeZoneChangedEventArgs e)`

## Screen

static class `LemonUI.Screen`

> **Obsolete.** Use the LemonUI.Tools and LemonUI.Math namespaces.

Contains a set of tools to work with the screen information.

### Properties

- `public static float AspectRatio { get; }`
  - The Aspect Ratio of the screen resolution.
- `public static PointF CursorPositionRelative { get; }`
  - The location of the cursor on screen between 0 and 1.

### Methods

- `public static PointF GetRealPosition(PointF og)`
  - Converts the specified position into one that is aware of `SetElementAlignment`.
  - `og`: The original 1080p based position.
  - Returns: A new 1080p based position that is aware of the the Alignment.
- `public static PointF GetRealPosition(float x, float y)`
  - Converts the specified position into one that is aware of `SetElementAlignment`.
  - `x`: The 1080p based X position.
  - `y`: The 1080p based Y position.
  - Returns: A new 1080p based position that is aware of the the Alignment.
- `public static bool IsCursorInArea(PointF pos, SizeF size)`
  - Checks if the cursor is inside of the specified area.
  - `pos`: The start of the area.
  - `size`: The size of the area to check.
  - Returns: `true` if the cursor is in the specified bounds, `false` otherwise.
- `public static bool IsCursorInArea(float x, float y, float width, float height)`
  - Checks if the cursor is inside of the specified area.
  - `x`: The start X position.
  - `y`: The start Y position.
  - `width`: The height of the search area from X.
  - `height`: The height of the search area from Y.
  - Returns: `true` if the cursor is in the specified bounds, `false` otherwise.
- `public static void ResetElementAlignment()`
  - Resets the alignment of the game elements.
- `public static void SetElementAlignment(Alignment horizontal, GFXAlignment vertical)`
  - Sets the alignment of game elements like `ScaledRectangle`, `ScaledText` and `ScaledTexture`.
  - `horizontal`: The Horizontal alignment of the items.
  - `vertical`: The vertical alignment of the items.
- `public static void SetElementAlignment(GFXAlignment horizontal, GFXAlignment vertical)`
  - Sets the alignment of game elements like `ScaledRectangle`, `ScaledText` and `ScaledTexture`.
  - `horizontal`: The Horizontal alignment of the items.
  - `vertical`: The vertical alignment of the items.
- `public static void ShowCursorThisFrame()`
  - Shows the cursor during the current game frame.
- `public static void ToAbsolute(float relativeX, float relativeY, out float absoluteX, out float absoluteY)`
  - Converts a relative resolution into one scaled to 1080p.
  - `relativeX`: The relative value of X.
  - `relativeY`: The relative value of Y.
  - `absoluteX`: The value of X scaled to 1080p.
  - `absoluteY`: The value of Y scaled to 1080p.
- `public static void ToRelative(float absoluteX, float absoluteY, out float relativeX, out float relativeY)`
  - Converts a 1080p-based resolution into relative values.
  - `absoluteX`: The 1080p based X coord.
  - `absoluteY`: The 1080p based Y coord.
  - `relativeX`: The value of X converted to relative.
  - `relativeY`: The value of Y converted to relative.

## Sound

class `LemonUI.Sound`

Contains information for a Game Sound that is played at specific times.

### Constructors

- `public Sound(string set, string file)`
  - Creates a new `Sound` class with the specified Sound Set and File.
  - `set`: The Set where the sound is located.
  - `file`: The name of the sound file.

### Properties

- `public string File { get; set; }`
  - The name of the sound file.
- `public int Id { get; }`
  - The ID of the sound, if is being played.
- `public string Set { get; set; }`
  - The Set where the sound is located.

### Methods

- `public void PlayFrontend()`
  - Plays the sound for the local `Player`.
- `public void PlayFrontend(bool release)`
  - Plays the sound for the local `Player`.
  - `release`: If the sound ID should be automatically released.
- `public void Release()`
  - Releases the Sound ID.
- `public void Stop()`
  - Stops the audio from playing.

