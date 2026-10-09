# NativeUI.PauseMenu (NativeUI (legacy, SHVDN v2))

[Back to the NativeUI (legacy, SHVDN v2) index](README.md)

> **Source:** `scripts/NativeUI.dll` (file version 1.9.0.0, assembly version 1.9.0.0, 97,792 bytes, modified 2019-05-02, SHA-256 `291d02fa1efe191ccbeda72ed7e52dce36dbbcf440b303a1afb58b7ddbc9275b`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/NativeUI.xml`, shipped with the installed DLL.

## MissionInformation

class `NativeUI.PauseMenu.MissionInformation`

### Constructors

- `public MissionInformation(string name, IEnumerable<Tuple<string, string>> info)`
- `public MissionInformation(string name, string description, IEnumerable<Tuple<string, string>> info)`

### Properties

- `public string Description { get; set; }`
- `public MissionLogo Logo { get; set; }`
- `public string Name { get; set; }`
- `public List<Tuple<string, string>> ValueList { get; set; }`

## MissionLogo

class `NativeUI.PauseMenu.MissionLogo`

### Constructors

- `public MissionLogo(string textureDict, string textureName)`
  - Create a mission logo from a game texture.
  - `textureDict`: Name of the texture dictionary
  - `textureName`: Name of the texture.
- `public MissionLogo(string filepath)`
  - Create a logo from an external picture.
  - `filepath`: Path to the picture

## OnItemSelect

delegate `NativeUI.PauseMenu.OnItemSelect` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public OnItemSelect(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(MissionInformation selectedItem, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(MissionInformation selectedItem)`

## TabInteractiveListItem

class `NativeUI.PauseMenu.TabInteractiveListItem` : `TabItem`

### Constructors

- `public TabInteractiveListItem(string name, IEnumerable<UIMenuItem> items)`

### Properties

- `public int Index { get; set; }`
- `public bool IsInList { get; set; }`
- `public List<UIMenuItem> Items { get; set; }`

### Methods

- `public virtual void Draw()`
- `public void MoveDown()`
- `public void MoveUp()`
- `public virtual void ProcessControls()`
- `public void RefreshIndex()`

### Fields

- `protected int _maxItem`
- `protected int _minItem`
- `protected const int MaxItemsPerView = 15`

## TabItem

class `NativeUI.PauseMenu.TabItem`

### Constructors

- `public TabItem(string name)`

### Properties

- `public bool Active { get; set; }`
- `public Point BottomRight { get; set; }`
- `public bool CanBeFocused { get; set; }`
- `public bool FadeInWhenFocused { get; set; }`
- `public bool Focused { get; set; }`
- `public bool JustOpened { get; set; }`
- `public TabView Parent { get; set; }`
- `public Point SafeSize { get; set; }`
- `public string Title { get; set; }`
- `public Point TopLeft { get; set; }`
- `public bool UseDynamicPositionment { get; set; }`
- `public bool Visible { get; set; }`

### Methods

- `public virtual void Draw()`
- `public void OnActivated()`
- `public virtual void ProcessControls()`

### Events

- `public event EventHandler Activated`
- `public event EventHandler DrawInstructionalButtons`

### Fields

- `public bool DrawBg`
- `protected Sprite RockstarTile`

## TabItemSimpleList

class `NativeUI.PauseMenu.TabItemSimpleList` : `TabItem`

### Constructors

- `public TabItemSimpleList(string title, Dictionary<string, string> dict)`

### Properties

- `public Dictionary<string, string> Dictionary { get; set; }`

### Methods

- `public virtual void Draw()`

## TabMissionSelectItem

class `NativeUI.PauseMenu.TabMissionSelectItem` : `TabItem`

### Constructors

- `public TabMissionSelectItem(string name, IEnumerable<MissionInformation> list)`

### Properties

- `protected Sprite _noLogo { get; set; }`
- `public List<MissionInformation> Heists { get; set; }`
- `public int Index { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void ProcessControls()`

### Events

- `public event OnItemSelect OnItemSelect`

### Fields

- `protected int _maxItem`
- `protected int _minItem`
- `protected const int MaxItemsPerView = 15`

## TabSubmenuItem

class `NativeUI.PauseMenu.TabSubmenuItem` : `TabItem`

### Constructors

- `public TabSubmenuItem(string name, IEnumerable<TabItem> items)`

### Properties

- `public bool Focused { get; set; }`
- `public int Index { get; set; }`
- `public bool IsInList { get; set; }`
- `public List<TabItem> Items { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void ProcessControls()`
- `public void RefreshIndex()`

## TabTextItem

class `NativeUI.PauseMenu.TabTextItem` : `TabItem`

### Constructors

- `public TabTextItem(string name, string title, string text)`
- `public TabTextItem(string name, string title)`

### Properties

- `public string Text { get; set; }`
- `public string TextTitle { get; set; }`
- `public int WordWrap { get; set; }`

### Methods

- `public virtual void Draw()`

## TabView

class `NativeUI.PauseMenu.TabView`

### Constructors

- `public TabView(string title)`

### Properties

- `public bool CanLeave { get; set; }`
- `public int FocusLevel { get; set; }`
- `public bool HideTabs { get; set; }`
- `public string Money { get; set; }`
- `public string MoneySubtitle { get; set; }`
- `public string Name { get; set; }`
- `public Sprite Photo { get; set; }`
- `public List<TabItem> Tabs { get; set; }`
- `public bool TemporarilyHidden { get; set; }`
- `public string Title { get; set; }`
- `public bool Visible { get; set; }`

### Methods

- `public void AddTab(TabItem item)`
- `public void DrawInstructionalButton(int slot, Control control, string text)`
- `public void ProcessControls()`
- `public void RefreshIndex()`
- `public void ShowInstructionalButtons()`
- `public void Update()`

### Events

- `public event EventHandler OnMenuClose`

### Fields

- `public int Index`

