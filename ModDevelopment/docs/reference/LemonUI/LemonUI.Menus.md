# LemonUI.Menus (LemonUI for SHVDN v3)

[Back to the LemonUI for SHVDN v3 index](README.md)

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

## BadgeSet

class `LemonUI.Menus.BadgeSet`

Represents a badge that can be applied to a `NativeItem`.

### Constructors

- `public BadgeSet()`
  - Creates a new empty `BadgeSet`.
- `public BadgeSet(string normalDict, string normalTexture, string hoveredDict, string hoveredTexture)`
  - Creates a new `BadgeSet` where both textures are in different dictionaries.
  - `normalDict`: The dictionary where the normal texture is located.
  - `normalTexture`: The normal texture name.
  - `hoveredDict`: The dictionary where the hovered texture is located.
  - `hoveredTexture`: The hovered texture name.
- `public BadgeSet(string dict, string normal, string hovered)`
  - Creates a new `BadgeSet` where both textures are in the same dictionary.
  - `dict`: The dictionary where the textures are located.
  - `normal`: The normal texture name.
  - `hovered`: The hovered texture name.

### Properties

- `public string HoveredDictionary { get; set; }`
  - The texture dictionary where the normal texture is located.
- `public string HoveredTexture { get; set; }`
  - The texture to use when the item is hovered.
- `public string NormalDictionary { get; set; }`
  - The texture dictionary where the normal texture is located.
- `public string NormalTexture { get; set; }`
  - The texture to use when the item is not hovered.

## ColorSet

class `LemonUI.Menus.ColorSet`

Stores the different colors required to make the colors of a `NativeItem` dynamic.

### Constructors

- `public ColorSet()`

### Properties

- `public Color AltTitleDisabled { get; set; }`
  - The color of the `AltTitle` when the `NativeItem` is disabled.
- `public Color AltTitleHovered { get; set; }`
  - The color of the `AltTitle` when the `NativeItem` is hovered.
- `public Color AltTitleNormal { get; set; }`
  - The color of the `AltTitle` when the `NativeItem` is not hovered and enabled.
- `public Color ArrowsDisabled { get; set; }`
  - The color of the `NativeSlidableItem` arrows when the item is disabled.
- `public Color ArrowsHovered { get; set; }`
  - The color of the `NativeSlidableItem` arrows when the item is hovered.
- `public Color ArrowsNormal { get; set; }`
  - The color of the `NativeSlidableItem` arrows when the item is not hovered and enabled.
- `public Color BackgroundDisabled { get; set; }`
  - The disabled color of the custom background if `UseCustomBackground` is set to `true`.
- `public Color BackgroundHovered { get; set; }`
  - The hovered color of the custom background if `UseCustomBackground` is set to `true`.
- `public Color BackgroundNormal { get; set; }`
  - The normal color of the custom background if `UseCustomBackground` is set to `true`.
- `public Color BadgeLeftDisabled { get; set; }`
  - The color of the `LeftBadge` when the `NativeItem` is disabled.
- `public Color BadgeLeftHovered { get; set; }`
  - The color of the `LeftBadge` when the `NativeItem` is hovered.
- `public Color BadgeLeftNormal { get; set; }`
  - The color of the `LeftBadge` when the `NativeItem` is not hovered and enabled.
- `public Color BadgeRightDisabled { get; set; }`
  - The color of the `RightBadge` or `NativeCheckboxItem` checkbox when the `NativeItem` is disabled.
- `public Color BadgeRightHovered { get; set; }`
  - The color of the `RightBadge` or `NativeCheckboxItem` checkbox when the `NativeItem` is hovered.
- `public Color BadgeRightNormal { get; set; }`
  - The color of the `RightBadge` or `NativeCheckboxItem` checkbox when the `NativeItem` is not hovered and enabled.
- `public Color TitleDisabled { get; set; }`
  - The color of the `Title` when the `NativeItem` is disabled.
- `public Color TitleHovered { get; set; }`
  - The color of the `Title` when the `NativeItem` is hovered.
- `public Color TitleNormal { get; set; }`
  - The color of the `Title` when the `NativeItem` is not hovered and enabled.

## ColorTitleStyle

enum `LemonUI.Menus.ColorTitleStyle`

The Style of title for the Color Panel.

| Name | Value | Description |
| --- | --- | --- |
| `None` | -1 | Does not shows any Title. The count will still be shown if `ShowCount` is set to `true`. |
| `Simple` | 0 | Shows a Simple Title for all of the Colors. |
| `ColorName` | 1 | Shows the Color Name as the Title. |

## CountVisibility

enum `LemonUI.Menus.CountVisibility`

The visibility setting for the Item Count of the Menu.

| Name | Value | Description |
| --- | --- | --- |
| `Never` | -1 | The Item Count is never shown. |
| `Auto` | 0 | The Item Count is shown when is not possible to show all of the items in the screen. |
| `Always` | 1 | The Item Count is always shown. |

## Direction

enum `LemonUI.Menus.Direction`

The movement direction of the item change.

| Name | Value | Description |
| --- | --- | --- |
| `Unknown` | 0 | The Direction is Unknown. |
| `Left` | 1 | The item was moved to the Left. |
| `Right` | 2 | The item was moved to the Right. |

## GridStyle

enum `LemonUI.Menus.GridStyle`

The style of the Grid Panel.

| Name | Value | Description |
| --- | --- | --- |
| `Full` | 0 | The full grid with X and Y values. |
| `Row` | 1 | A single row on the center with the X value only. |
| `Column` | 2 | A single column on the center with the Y value only. |

## GridValueChangedArgs

class `LemonUI.Menus.GridValueChangedArgs`

Represents the Previous and Current X and Y values when changing the position on a grid.

### Properties

- `public PointF After { get; }`
  - The values present after they were changed.
- `public PointF Before { get; }`
  - The values present before they were changed.

## GridValueChangedEventHandler

delegate `LemonUI.Menus.GridValueChangedEventHandler` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that is called when the value on a grid is changed.

### Constructors

- `public GridValueChangedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, GridValueChangedArgs e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, GridValueChangedArgs e)`

## HeaderBehavior

enum `LemonUI.Menus.HeaderBehavior`

The behavior of the `NativeMenu`'s header.

| Name | Value | Description |
| --- | --- | --- |
| `AlwaysShow` | 0 | The header will always be shown. |
| `ShowIfRequired` | 1 | The header will always be shown, except when is empty. |
| `AlwaysHide` | 2 | The header will never be shown. |

## ItemActivatedArgs

class `LemonUI.Menus.ItemActivatedArgs`

Represents the arguments of an item activation.

### Properties

- `public NativeItem Item { get; }`
  - The item that was just activated.

## ItemActivatedEventHandler

delegate `LemonUI.Menus.ItemActivatedEventHandler` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that is called when an item is activated on a menu.

### Constructors

- `public ItemActivatedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, ItemActivatedArgs e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, ItemActivatedArgs e)`

## ItemChangedEventArgs<T>

class `LemonUI.Menus.ItemChangedEventArgs`1`

Represents the change of the selection of an item.

### Properties

- `public Direction Direction { get; }`
  - The direction of the Item Changed event.
- `public int Index { get; }`
  - The index of the object.
- `public T Object { get; set; }`
  - The new object.

## ItemChangedEventHandler<T>

delegate `LemonUI.Menus.ItemChangedEventHandler`1` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that is called when the selected item is changed on a List Item.

### Constructors

- `public ItemChangedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, ItemChangedEventArgs<T> e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, ItemChangedEventArgs<T> e)`

## ItemOperation

enum `LemonUI.Menus.ItemOperation`

The operation performed when the menu items are modified.

| Name | Value | Description |
| --- | --- | --- |
| `Removed` | -1 | The item has been removed. |
| `Added` | 0 | The item has been added. |

## MenuModifiedEventArgs

class `LemonUI.Menus.MenuModifiedEventArgs`

Represents the different

### Constructors

- `public MenuModifiedEventArgs(NativeItem item, ItemOperation operation)`
  - Creates a new `MenuModifiedEventArgs`.
  - `item`: The item that was modified.
  - `operation`: The operation that was performed in the item.

### Properties

- `public NativeItem Item { get; }`
  - The item that was modified.
- `public ItemOperation Operation { get; }`
  - The operation that was performed in the item.

## MenuModifiedEventHandler

delegate `LemonUI.Menus.MenuModifiedEventHandler` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that is called when the items on a menu are changed (added or removed).

### Constructors

- `public MenuModifiedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, MenuModifiedEventArgs e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, MenuModifiedEventArgs e)`

## MenuMouseBehavior

enum `LemonUI.Menus.MenuMouseBehavior`

Defines the behavior of the mouse when a menu is open.

| Name | Value | Description |
| --- | --- | --- |
| `Disabled` | 0 | The mouse will not be usable in the menu. |
| `Movement` | 1 | The menu can be used to click the items and navigate to them. |
| `Scrolling` | 2 | The wheel can be used to navigate in the menu, click can be used to confirm and right click to return/exit. |

## NativeCheckboxItem

class `LemonUI.Menus.NativeCheckboxItem` : `NativeItem`, `IDrawable`

Rockstar-like checkbox item.

### Constructors

- `public NativeCheckboxItem(string title, bool check)`
  - Creates a new `NativeCheckboxItem`.
  - `title`: The title used for the Item.
  - `check`: If the checkbox should be enabled or not.
- `public NativeCheckboxItem(string title, string description, bool check)`
  - Creates a new `NativeCheckboxItem`.
  - `title`: The title used for the Item.
  - `description`: The description of the Item.
  - `check`: If the checkbox should be enabled or not.
- `public NativeCheckboxItem(string title, string description)`
  - Creates a new `NativeCheckboxItem`.
  - `title`: The title used for the Item.
  - `description`: The description of the Item.
- `public NativeCheckboxItem(string title)`
  - Creates a new `NativeCheckboxItem`.
  - `title`: The title used for the Item.

### Properties

- `public bool Checked { get; set; }`
  - If this item is checked or not.
- `public BadgeSet CheckedSet { get; set; }`
  - The textures used when the checkbox is checked.
- `public BadgeSet UncheckedSet { get; set; }`
  - The textures used when the checkbox is unchecked.

### Methods

- `public virtual void Draw()`
  - Draws the Checkbox on the screen.
- `public virtual void Recalculate(PointF pos, SizeF size, bool selected)`
  - Recalculates the item positions and sizes with the specified values.
  - `pos`: The position of the item.
  - `size`: The size of the item.
  - `selected`: If this item has been selected.
- `public virtual void UpdateColors()`
- `protected void UpdateTexture(bool selected)`
  - Updates the texture of the sprite.

### Events

- `public event EventHandler CheckboxChanged`
  - Event triggered when the checkbox changes.

### Fields

- `protected ScaledTexture check`
  - The image shown on the checkbox.
- `public static readonly BadgeSet DefaultCheckedSet`
  - The default checkbox textures when the checkbox is checked.
- `public static readonly BadgeSet DefaultUncheckedSet`
  - The default checkbox textures when the checkbox is not checked.

## NativeColorData

class `LemonUI.Menus.NativeColorData`

Represents the Color Information shown on the Panel.

### Constructors

- `public NativeColorData(string name, Color color)`
  - Creates a new Color Panel information.
  - `name`: The name of the color.
  - `color`: The RGBA values of the color.

### Properties

- `public Color Color { get; set; }`
  - The RGBA values of the color.
- `public string Name { get; set; }`
  - The name of the color.

## NativeColorPanel

class `LemonUI.Menus.NativeColorPanel` : `NativePanel`, `IEnumerable<NativeColorData>`, `IEnumerable`

A Panel that allows you to select a Color.

### Constructors

- `public NativeColorPanel()`
  - Creates a color panel with no Items or Title.
- `public NativeColorPanel(string title, params NativeColorData[] colors)`
  - Creates a Panel with a specific Title and set of Colors.
  - `title`: The title of the panel.
  - `colors`: The colors of the panel.

### Properties

- `public bool Clickable { get; }`
- `public List<NativeColorData> Colors { get; }`
  - The colors shown on this Panel.
- `public int MaxItems { get; set; }`
  - THe maximum number of items shown on the screen.
- `public int Opacity { get; set; }`
  - The opacity value of the color.
- `public Color SelectedColor { get; }`
  - The currently selected color.
- `public int SelectedIndex { get; set; }`
  - The index of the currently selected Color.
- `public NativeColorData SelectedItem { get; }`
  - Returns the currently selected `NativeColorData`.
- `public bool ShowCount { get; set; }`
  - If the count of items should be shown as part of the title.
- `public bool ShowOpacity { get; set; }`
  - If the Opacity selector should be shown.
- `public Sound Sound { get; set; }`
  - The sound played when the item is changed.
- `public string Title { get; set; }`
  - The Title used for the Panel when `TitleStyle` is set to `Simple`.
- `public ColorTitleStyle TitleStyle { get; set; }`
  - The style of the Panel Title.

### Methods

- `public void Add(NativeColorData color)`
  - Adds a color to the Panel.
  - `color`: The color to add.
- `public void Clear()`
  - Removes all of the colors from the Panel.
- `public void Contains(NativeColorData color)`
  - Checks if the Color Data is present on this Panel.
  - `color`: The Color Data to check.
- `public IEnumerator<NativeColorData> GetEnumerator()`
- `public void Next()`
  - Moves to the Next Color.
- `public void Previous()`
  - Moves to the Previous Color.
- `public virtual void Process()`
  - Draws the Color Panel.
- `public virtual void Recalculate(PointF position, float width)`
  - Recalculates the position of the Color Panel.
  - `position`: The position of the panel.
  - `width`: The width of the menu.
- `public void Remove(NativeColorData color)`
  - Removes a color from the panel.
  - `color`: The color to remove.
- `public void Remove(Func<NativeColorData, bool> func)`
  - Removes all of the

### Fields

- `public static readonly Sound DefaultSound`
  - The default sound used for the Color Navigation.

## NativeDynamicItem<T>

class `LemonUI.Menus.NativeDynamicItem`1` : `NativeSlidableItem`, `IDrawable`

Dynamic Items allow you to dynamically change the item shown to the user.

### Constructors

- `public NativeDynamicItem(string title, T item)`
  - Creates a new Dynamic List Item.
  - `title`: The Title of the item.
  - `item`: The Item to set.
- `public NativeDynamicItem(string title, string description, T item)`
  - Creates a new Dynamic List Item.
  - `title`: The Title of the item.
  - `description`: The Description of the item.
  - `item`: The Item to set.
- `public NativeDynamicItem(string title, string description)`
  - Creates a new Dynamic List Item.
  - `title`: The Title of the item.
  - `description`: The Description of the item.
- `public NativeDynamicItem(string title)`
  - Creates a new Dynamic List Item.
  - `title`: The Title of the item.

### Properties

- `public T SelectedItem { get; set; }`
  - The currently selected item.

### Methods

- `public virtual void Draw()`
  - Draws the List on the screen.
- `public virtual void GoLeft()`
  - Gets the previous item.
- `public virtual void GoRight()`
  - Gets the next item.
- `public virtual void Recalculate(PointF pos, SizeF size, bool selected)`
  - Recalculates the position of the current List Item.
  - `pos`: The new position of the item.
  - `size`: The Size of the item.
  - `selected`: If the item is selected or not.
- `public virtual void UpdateColors()`

### Events

- `public event ItemChangedEventHandler<T> ItemChanged`
  - Event triggered when the user has changed the item.

## NativeGridPanel

class `LemonUI.Menus.NativeGridPanel` : `NativePanel`

Represents a grid where you can select X and Y values.

### Constructors

- `public NativeGridPanel()`
  - Creates a new `NativeGridPanel`.

### Properties

- `public bool Clickable { get; }`
- `public string LabelBottom { get; set; }`
  - The text label shown on the bottom.
- `public string LabelLeft { get; set; }`
  - The text label shown on the left.
- `public string LabelRight { get; set; }`
  - The text label shown on the right.
- `public string LabelTop { get; set; }`
  - The text label shown on the top.
- `public GridStyle Style { get; set; }`
  - The style of this grid.
- `public float X { get; set; }`
  - The X value between 0 and 1.
- `public float Y { get; set; }`
  - The X value between 0 and 1.

### Methods

- `public virtual void Process()`
- `public virtual void Recalculate(PointF position, float width)`

### Events

- `public event GridValueChangedEventHandler ValuesChanged`
  - Event triggered when X and/or Y values are changed.

## NativeItem

class `LemonUI.Menus.NativeItem` : `IDrawable`

Basic Rockstar-like item.

### Constructors

- `public NativeItem(string title, string description, string altTitle)`
  - Creates a new `NativeItem`.
  - `title`: The title of the item.
  - `description`: The description of the item.
  - `altTitle`: The alternative title of the item, shown on the right.
- `public NativeItem(string title, string description)`
  - Creates a new `NativeItem`.
  - `title`: The title of the item.
  - `description`: The description of the item.
- `public NativeItem(string title)`
  - Creates a new `NativeItem`.
  - `title`: The title of the item.

### Properties

- `public string AltTitle { get; set; }`
  - The alternative title of the item shown on the right.
- `public Font AltTitleFont { get; set; }`
  - The font of alternative title item shown on the right.
- `public ColorSet Colors { get; set; }`
  - The different colors that change dynamically when the item is used.
- `public string Description { get; set; }`
  - The description of the item.
- `public bool Enabled { get; set; }`
  - If this item can be used or not.
- `public bool IsHovered { get; }`
  - If this item is being hovered.
- `public I2Dimensional LeftBadge { get; set; }`
  - The Left badge of the Item.
- `public BadgeSet LeftBadgeSet { get; set; }`
  - The Left badge set of the Item.
- `public NativePanel Panel { get; set; }`
  - The Panel associated to this `NativeItem`.
- `public I2Dimensional RightBadge { get; set; }`
  - The Right badge of the Item.
- `public BadgeSet RightBadgeSet { get; set; }`
  - The Right badge set of the Item.
- `public object Tag { get; set; }`
  - Object that contains data about this Item.
- `public string Title { get; set; }`
  - The title of the item.
- `public Font TitleFont { get; set; }`
  - The font of title item.
- `public bool UseCustomBackground { get; set; }`
  - If a custom colored background should be used.

### Methods

- `public virtual void Draw()`
  - Draws the item.
- `protected void OnActivated(object sender)`
  - Triggers the Activated event.
  - `sender`: The source of the event.
- `protected void OnSelected(object sender, SelectedEventArgs e)`
  - Triggers the Selected event.
  - `sender`: The source of the event.
  - `e`: A `SelectedEventArgs` with the index information.
- `protected void Recalculate()`
  - Recalculates the item with the last known values.
- `public virtual void Recalculate(PointF pos, SizeF size, bool selected)`
  - Recalculates the item positions and sizes with the specified values.
  - `pos`: The position of the item.
  - `size`: The size of the item.
  - `selected`: If this item has been selected.
- `public virtual void UpdateColors()`
  - Updates the colors of the `Elements` from the `Colors``ColorSet`.

### Events

- `public event EventHandler Activated`
  - Event triggered when the item is activated.
- `public event EventHandler EnabledChanged`
  - Event triggered when the `Enabled` property is changed.
- `public event SelectedEventHandler Selected`
  - Event triggered when the item is selected.

### Fields

- `protected ScaledText altTitle`
  - The alternate title of the menu.
- `protected I2Dimensional badgeLeft`
  - The left badge of the Item.
- `protected I2Dimensional badgeRight`
  - The left badge of the Item.
- `protected PointF lastPosition`
  - The last known Item Position.
- `protected bool lastSelected`
  - The last known Item Selection.
- `protected SizeF lastSize`
  - The last known Item Size.
- `protected ScaledText title`
  - The title of the object.

## NativeListItem

abstract class `LemonUI.Menus.NativeListItem` : `NativeSlidableItem`, `IDrawable`

Base class for list items.

### Constructors

- `public NativeListItem(string title, string subtitle)`
  - Creates a new list item with a title and subtitle.
  - `title`: The title of the Item.
  - `subtitle`: The subtitle of the Item.

### Fields

- `protected ScaledText text`
  - The text of the current item.

## NativeListItem<T>

class `LemonUI.Menus.NativeListItem`1` : `NativeListItem`, `IDrawable`, `IEnumerable<T>`, `IEnumerable`

An item that allows you to scroll between a set of objects.

### Constructors

- `public NativeListItem(string title, params T[] objs)`
  - Creates a new `NativeListItem`.
  - `title`: The title of the Item.
  - `objs`: The objects that are available on the Item.
- `public NativeListItem(string title, string subtitle, params T[] objs)`
  - Creates a new `NativeListItem`.
  - `title`: The title of the Item.
  - `subtitle`: The subtitle of the Item.
  - `objs`: The objects that are available on the Item.

### Properties

- `public List<T> Items { get; set; }`
  - The objects used by this item.
- `public int SelectedIndex { get; set; }`
  - The index of the currently selected index.
- `public T SelectedItem { get; set; }`
  - The currently selected item.

### Methods

- `public void Add(T item)`
  - Adds a `T` into this item.
  - `item`: The `T` to add.
- `public void Add(int position, T item)`
  - Adds a `T` in a specific location.
  - `position`: The position where the item should be added.
  - `item`: The `T` to add.
- `public void Clear()`
  - Removes all of the `T` from this item.
- `public virtual void Draw()`
  - Draws the List on the screen.
- `public IEnumerator<T> GetEnumerator()`
- `public virtual void GoLeft()`
  - Moves to the previous item.
- `public virtual void GoRight()`
  - Moves to the next item.
- `public virtual void Recalculate(PointF pos, SizeF size, bool selected)`
  - Recalculates the item positions and sizes with the specified values.
  - `pos`: The position of the item.
  - `size`: The size of the item.
  - `selected`: If this item has been selected.
- `public void Remove(T item)`
  - Removes a specific `T`.
  - `item`: The `T` to remove.
- `public void Remove(Func<T, bool> pred)`
  - Removes all of the items that match the `pred`.
  - `pred`: The function to use as a check.
- `public void RemoveAt(int position)`
  - Removes a `T` at a specific location.
  - `position`: The position of the `T`.
- `public virtual void UpdateColors()`

### Events

- `public event ItemChangedEventHandler<T> ItemChanged`
  - Event triggered when the selected item is changed.

## NativeMenu

class `LemonUI.Menus.NativeMenu` : `IContainer<NativeItem>`, `IRecalculable`, `IProcessable`, `IEnumerable<NativeItem>`, `IEnumerable`

Menu that looks like the ones used by Rockstar.

### Constructors

- `public NativeMenu(string bannerText, string name, string description, I2Dimensional banner)`
  - Creates a new menu with the specified banner text, name, description and banner.
  - `bannerText`: The title of the menu.
  - `name`: The name of this menu.
  - `description`: The description used for submenus.
  - `banner`: The drawable to use as the banner.
- `public NativeMenu(string bannerText, string name, string description)`
  - Creates a new menu with the specified banner text, name and description.
  - `bannerText`: The title of the menu.
  - `name`: The name of this menu.
  - `description`: The description used for submenus.
- `public NativeMenu(string bannerText, string name)`
  - Creates a new menu with the specified banner text and name.
  - `bannerText`: The title of the menu.
  - `name`: The name of this menu.
- `public NativeMenu(string title)`
  - Creates a new menu with the specified title.
  - `title`: The title of the menu.

### Properties

- `public bool AcceptsInput { get; set; }`
  - If the menu accepts user input for navigation.
- `public Alignment Alignment { get; set; }`
  - The alignment of the menu.
- `public I2Dimensional Banner { get; set; }`
  - The banner shown at the top of the menu.
- `public ScaledText BannerText { get; set; }`
  - The text shown on top of the banner.
- `public InstructionalButtons Buttons { get; }`
  - The instructional buttons shown in the bottom right.
- `public bool CloseOnInvalidClick { get; set; }`
  - If the menu should be closed when the user clicks out of bounds (aka anywhere else other than the items).
- `public string Description { get; set; }`
  - The description used when this menu is used as a submenu.
- `public Font DescriptionFont { get; set; }`
  - The font of description text.
- `public bool DisableControls { get; set; }`
  - If the conflictive controls should be disabled while the menu is open.
- `public HeaderBehavior HeaderBehavior { get; set; }`
  - The behavior of the black bar showing the name.
- `public int HeldTime { get; set; }`
  - The time between item changes when holding left, right, up or down.
- `public CountVisibility ItemCount { get; set; }`
  - If the count of items should be shown on the right of the name.
- `public Font ItemCountFont { get; set; }`
  - The font of item count text.
- `public List<NativeItem> Items { get; }`
  - The items that this menu contain.
- `public bool KeepNameCasing { get; set; }`
  - Whether the name of the menu should keep its casing or not.
- `public int MaxItems { get; set; }`
  - The maximum allowed number of items in the menu at once.
- `public MenuMouseBehavior MouseBehavior { get; set; }`
  - The behavior of the mouse when the menu is open.
- `public string Name { get; set; }`
  - The name of this menu.
- `public Font NameFont { get; set; }`
  - The font of name text.
- `public string NoItemsText { get; set; }`
  - Text shown when there are no items in the menu.
- `public PointF Offset { get; set; }`
  - The offset of the menu position.
- `public NativeMenu Parent { get; set; }`
  - The parent menu of this menu.
- `public List<Control> RequiredControls { get; }`
  - The controls that are required for some menu operations.
- `public bool ResetCursorWhenOpened { get; set; }`
  - If the cursor should be reset when the menu is opened.
- `public bool RotateCamera { get; set; }`
  - If the camera should be rotated when the cursor is on the left and right corners of the screen.
- `public bool SafeZoneAware { get; set; }`
  - If this menu should be aware of the Safe Zone when doing calculations.
- `public int SelectedIndex { get; set; }`
  - The current index of the menu.
- `public NativeItem SelectedItem { get; set; }`
  - Returns the currently selected item.
- `public Sound SoundActivated { get; set; }`
  - The `Sound` played when a `NativeItem` is activated.
- `public Sound SoundClose { get; set; }`
  - The `Sound` played when the menu is closed.
- `public Sound SoundDisabled { get; set; }`
  - The `Sound` played when the user activates a `NativeItem` that is disabled.
- `public Sound SoundLeftRight { get; set; }`
  - The `Sound` played when the user navigates Left and Right on a `NativeSlidableItem`.
- `public Sound SoundOpened { get; set; }`
  - The `Sound` played when the menu is opened.
- `public Sound SoundUpDown { get; set; }`
  - The `Sound` played when the user navigates Up or Down the menu.
- `public string Subtitle { get; set; }`
  - **Obsolete.** Please use Name instead.
  - The name of the menu.
- `public SubtitleBehavior SubtitleBehavior { get; set; }`
  - **Obsolete.** Please use NameBehavior instead.
  - The behavior of the black bar showing the name.
- `public Font SubtitleFont { get; set; }`
  - **Obsolete.** Please use NameFont instead.
  - The font of name text.
- `public ScaledText Title { get; set; }`
  - **Obsolete.** Please use BannerText instead.
  - The text shown on top of the banner.
- `public Font TitleFont { get; set; }`
  - **Obsolete.** Please use BannerText.Font instead.
  - The font of the text shown on top of the banner.
- `public bool UseMouse { get; set; }`
  - **Obsolete.** This parameter is ambiguous, please use the MouseBehavior property instead instead.
  - If the mouse should be used for navigating the menu.
- `public bool Visible { get; set; }`
  - If the menu is visible on the screen.
- `public float Width { get; set; }`
  - The width of the menu.

### Methods

- `public void Add(NativeItem item)`
  - Adds an item at the end of the menu.
  - `item`: The item to add.
- `public void Add(NativeMenu menu)`
  - Adds a specific menu as a submenu with an item.
  - `menu`: The menu to add.
- `public virtual void Add(int position, NativeItem item)`
  - Adds an item at the specified position.
  - `position`: The position of the item.
  - `item`: The item to add.
- `public NativeSubmenuItem AddSubMenu(NativeMenu menu, string endlabel)`
  - Adds a specific menu as a submenu with an item and endlabel string.
  - `menu`: The menu to add.
  - `endlabel`: The alternative title of the item, shown on the right.
  - Returns: The item that points to the submenu.
- `public NativeSubmenuItem AddSubMenu(NativeMenu menu)`
  - Adds a specific menu as a submenu with an item.
  - `menu`: The menu to add.
  - Returns: The item that points to the submenu.
- `public void Back()`
  - Returns to the previous menu or closes the existing one.
- `public void Clear()`
  - Removes all of the items from this menu.
- `public void Close()`
  - **Obsolete.** Set Visible to false instead.
  - Closes the menu.
- `public bool Contains(NativeItem item)`
  - Checks if an item is part of the menu.
  - `item`: The item to check.
- `public IEnumerator<NativeItem> GetEnumerator()`
- `public void Next()`
  - Moves to the next item. Does nothing if the menu has no items.
- `public void Open()`
  - **Obsolete.** Set Visible to true instead.
  - Opens the menu.
- `public void Previous()`
  - Moves to the previous item. Does nothing if the menu has no items.
- `public virtual void Process()`
  - Draws the menu and handles the controls.
- `public virtual void Recalculate()`
  - Calculates the positions and sizes of the elements.
- `public void Remove(NativeItem item)`
  - Removes an item from the menu.
  - `item`: The item to remove.
- `public void Remove(Func<NativeItem, bool> pred)`
  - Removes the items that match the predicate.
  - `pred`: The function to use as a check.
- `public void ResetCursor()`
  - Resets the current position of the cursor.

### Events

- `public event EventHandler Closed`
  - Event triggered when the menu finishes closing.
- `public event CancelEventHandler Closing`
  - Event triggered when the menu starts closing.
- `public event ItemActivatedEventHandler ItemActivated`
  - Event triggered when an item in the menu is activated.
- `public event MenuModifiedEventHandler MenuModified`
  - Event triggered when the contents of the menu are changed.
- `public event CancelEventHandler Opening`
  - Event triggered when the menu is being opened.
- `public event SelectedEventHandler SelectedIndexChanged`
  - Event triggered when the index has been changed.
- `public event EventHandler Shown`
  - Event triggered when the menu is opened and shown to the user.

### Fields

- `public static readonly Sound DefaultActivatedSound`
  - The default `Sound` played when the current `NativeItem` is changed or activated.
- `public static readonly Sound DefaultCloseSound`
  - The default `Sound` played when the menu is closed.
- `public static readonly Sound DefaultDisabledSound`
  - The default `Sound` played when the user activates a `NativeItem` that is disabled.
- `public static readonly Sound DefaultLeftRightSound`
  - The default `Sound` played when the user navigates Left and Right on a `NativeSlidableItem`.
- `public static readonly Sound DefaultUpDownSound`
  - The default `Sound` played when the user navigates Up and Down.

## NativePanel

abstract class `LemonUI.Menus.NativePanel`

Represents a panel shown under the description of the item description.

### Constructors

- `protected NativePanel()`

### Properties

- `public ScaledTexture Background { get; }`
  - The Background of the panel itself.
- `public bool Clickable { get; }`
  - If the item has controls that can be clicked.
- `public bool Visible { get; set; }`
  - If this panel is visible to the user.

### Methods

- `public virtual void Process()`
  - Processes and Draws the panel.
- `public virtual void Recalculate(PointF position, float width)`
  - Recalculates the menu contents.
  - `position`: The position of the panel.
  - `width`: The width of the menu.

## NativeSeparatorItem

class `LemonUI.Menus.NativeSeparatorItem` : `NativeItem`, `IDrawable`

An item used to have a space between the items with text or no text.

### Constructors

- `public NativeSeparatorItem()`
  - Creates a new separator.
- `public NativeSeparatorItem(string title)`
  - Creates a new separator with a specific title.
  - `title`: The title of the item.

### Methods

- `public virtual void Draw()`
- `public virtual void Recalculate(PointF pos, SizeF size, bool selected)`

## NativeSlidableItem

abstract class `LemonUI.Menus.NativeSlidableItem` : `NativeItem`, `IDrawable`

Basic elements for a slidable item.

### Constructors

- `public NativeSlidableItem(string title, string description)`
  - Creates a new item that can be sliden.
  - `title`: The title of the Item.
  - `description`: The description of the Item.

### Properties

- `public bool ArrowsAlwaysVisible { get; set; }`
  - Whether the arrows should always be shown regardless of the visibility of the Item.
- `public ScaledTexture LeftArrow { get; }`
  - The arrow pointing to the Left.
- `public ScaledTexture RightArrow { get; }`
  - The arrow pointing to the Right.

### Methods

- `public virtual void Draw()`
  - Draws the left and right arrow.
- `public abstract void GoLeft()`
  - Moves to the previous item.
- `public abstract void GoRight()`
  - Moves to the next item.
- `public virtual void Recalculate(PointF pos, SizeF size, bool selected)`
  - Recalculates the item positions and sizes with the specified values.
  - `pos`: The position of the item.
  - `size`: The size of the item.
  - `selected`: If this item has been selected.
- `public virtual void UpdateColors()`

### Fields

- `protected ScaledTexture arrowLeft`
  - **Obsolete.** arrowLeft is Obsolete, use LeftArrow instead.
  - The arrow pointing to the Left.
- `protected ScaledTexture arrowRight`
  - **Obsolete.** arrowRight is Obsolete, use RightArrow instead.
  - The arrow pointing to the Right.

## NativeSliderItem

class `LemonUI.Menus.NativeSliderItem` : `NativeSlidableItem`, `IDrawable`

A slider item for changing integer values.

### Constructors

- `public NativeSliderItem(string title, int max, int value)`
  - Creates a `NativeSliderItem` with a specific current and maximum value.
  - `title`: The title of the Item.
  - `max`: The maximum value of the Slider.
  - `value`: The current value of the Slider.
- `public NativeSliderItem(string title, string description, int max, int value)`
  - Creates a `NativeSliderItem` with a specific maximum.
  - `title`: The title of the Item.
  - `description`: The description of the Item.
  - `max`: The maximum value of the Slider.
  - `value`: The current value of the Slider.
- `public NativeSliderItem(string title, string description)`
  - Creates a `NativeSliderItem` with a maximum of 100.
  - `title`: The title of the Item.
  - `description`: The description of the Item.
- `public NativeSliderItem(string title)`
  - Creates a `NativeSliderItem` with a maximum of 100.
  - `title`: The title of the Item.

### Properties

- `public int Maximum { get; set; }`
  - The maximum value of the slider.
- `public int Multiplier { get; set; }`
  - The multiplier for increasing and decreasing the value.
- `public Color SliderColor { get; set; }`
  - The color of the Slider.
- `public int Value { get; set; }`
  - The current value of the slider.

### Methods

- `public virtual void Draw()`
  - Draws the slider.
- `public virtual void GoLeft()`
  - Reduces the value of the slider.
- `public virtual void GoRight()`
  - Increases the value of the slider.
- `public virtual void Recalculate(PointF pos, SizeF size, bool selected)`
  - Recalculates the item positions and sizes with the specified values.
  - `pos`: The position of the item.
  - `size`: The size of the item.
  - `selected`: If this item has been selected.
- `protected void UpdatePosition()`
  - Updates the position of the bar based on the value.

### Events

- `public event EventHandler ValueChanged`
  - Event triggered when the value of the menu changes.

### Fields

- `protected ScaledRectangle background`
  - The background of the slider.
- `protected ScaledRectangle slider`
  - THe front of the slider.

## NativeStatsInfo

class `LemonUI.Menus.NativeStatsInfo`

Represents the Information of a specific field in a `NativeStatsPanel`.

### Constructors

- `public NativeStatsInfo(string name, int value)`
  - Creates a new Stat Info with the specified name and value.
  - `name`: The name of the Stat.
- `public NativeStatsInfo(string name)`
  - Creates a new Stat Info with the specified name and value set to zero.
  - `name`: The name of the Stat.

### Properties

- `public string Name { get; set; }`
  - The name of the Stats Field.
- `public float Value { get; set; }`
  - The value of the Stats bar.

### Methods

- `public void Draw()`
  - Draws the stat information.
- `public void Recalculate(PointF position, float width)`
  - Recalculates the position of the stat Text and Bar.
  - `position`: The new position fot the Stat.
  - `width`: The Width of the parent Stats Panel.

## NativeStatsPanel

class `LemonUI.Menus.NativeStatsPanel` : `NativePanel`, `IContainer<NativeStatsInfo>`, `IRecalculable`, `IProcessable`, `IEnumerable<NativeStatsInfo>`, `IEnumerable`

Represents a Statistics panel.

### Constructors

- `public NativeStatsPanel(params NativeStatsInfo[] stats)`
  - Creates a new Stats Panel.
  - `stats`: The Statistics to add.

### Properties

- `public Color BackgroundColor { get; set; }`
  - The color of the background of the bars.
- `public Color ForegroundColor { get; set; }`
  - The color of the foreground of the bars.

### Methods

- `public void Add(NativeStatsInfo field)`
  - Adds a stat to the player field.
  - `field`: The Field to add.
- `public void Clear()`
  - Removes all of the Stats fields.
- `public bool Contains(NativeStatsInfo field)`
  - Checks if the field is part of the Stats Panel.
  - `field`: The field to check.
  - Returns: `true` if the item is part of the Panel, `false` otherwise.
- `public IEnumerator<NativeStatsInfo> GetEnumerator()`
- `public virtual void Process()`
  - Processes the Stats Panel.
- `public void Recalculate()`
  - Recalculates the Stats panel with the last known Position and Width.
- `public virtual void Recalculate(PointF position, float width)`
  - Recalculates the position of the Stats panel.
  - `position`: The new position of the Stats Panel.
  - `width`: The width of the menu.
- `public void Remove(NativeStatsInfo field)`
  - Removes a field from the panel.
  - `field`: The field to remove.
- `public void Remove(Func<NativeStatsInfo, bool> func)`
  - Removes the items that match the function.
  - `func`: The function used to match items.

## NativeSubmenuItem

class `LemonUI.Menus.NativeSubmenuItem` : `NativeItem`, `IDrawable`

Item used for opening submenus.

### Constructors

- `public NativeSubmenuItem(NativeMenu menu, NativeMenu parent, string endLabel)`
  - Creates a new Item that opens a Submenu.
  - `menu`: The menu that this item will open.
  - `parent`: The parent menu where this item will be located.
  - `endLabel`: The alternative title of the item, shown on the right.
- `public NativeSubmenuItem(NativeMenu menu, NativeMenu parent)`
  - Creates a new Item that opens a Submenu.
  - `menu`: The menu that this item will open.
  - `parent`: The parent menu where this item will be located.

### Properties

- `public NativeMenu Menu { get; }`
  - The menu opened by this item.

### Methods

- `public virtual void Draw()`

## SelectedEventArgs

class `LemonUI.Menus.SelectedEventArgs`

Represents the selection of an item in the screen.

### Constructors

- `public SelectedEventArgs(int index, int screen)`
  - Creates a new `SelectedEventArgs`.
  - `index`: The index of the item in the menu.
  - `screen`: The index of the item based on the number of items shown on screen,

### Properties

- `public int Index { get; }`
  - The index of the item in the full list of items.
- `public int OnScreen { get; }`
  - The index of the item in the screen.

## SelectedEventHandler

delegate `LemonUI.Menus.SelectedEventHandler` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that is called when a new item is selected in the Menu.

### Constructors

- `public SelectedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, SelectedEventArgs e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, SelectedEventArgs e)`

## SubtitleBehavior

enum `LemonUI.Menus.SubtitleBehavior`

> **Obsolete.** Please use HeaderBehavior instead

The behavior of the `NativeMenu`'s subtitle.

| Name | Value | Description |
| --- | --- | --- |
| `AlwaysShow` | 0 | The subtitle will always be shown. |
| `ShowIfRequired` | 1 | The subtitle will always be shown, except when is empty. |
| `AlwaysHide` | 2 | The subtitle will never be shown. |

