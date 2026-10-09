# NativeUI (NativeUI (legacy, SHVDN v2))

[Back to the NativeUI (legacy, SHVDN v2) index](README.md)

> **Source:** `scripts/NativeUI.dll` (file version 1.9.0.0, assembly version 1.9.0.0, 97,792 bytes, modified 2019-05-02, SHA-256 `291d02fa1efe191ccbeda72ed7e52dce36dbbcf440b303a1afb58b7ddbc9275b`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/NativeUI.xml`, shipped with the installed DLL.

## BarTimerBar

class `NativeUI.BarTimerBar` : `TimerBarBase`

### Constructors

- `public BarTimerBar(string label)`

### Properties

- `public Color BackgroundColor { get; set; }`
- `public Color ForegroundColor { get; set; }`
- `public float Percentage { get; set; }`
  - Bar percentage. Goes from 0 to 1.

### Methods

- `public virtual void Draw(int interval)`

## BigMessageHandler

class `NativeUI.BigMessageHandler`

### Constructors

- `public BigMessageHandler()`

### Methods

- `public void Dispose()`
- `public void Load()`
- `public void ShowColoredShard(string msg, string desc, HudColor textColor, HudColor bgColor, int time = 5000)`
- `public void ShowCustomShard(string funcName, params object[] paremeters)`
- `public void ShowMissionPassedMessage(string msg, int time = 5000)`
- `public void ShowMpMessageLarge(string msg, int time = 5000)`
- `public void ShowOldMessage(string msg, int time = 5000)`
- `public void ShowRankupMessage(string msg, string subtitle, int rank, int time = 5000)`
- `public void ShowSimpleShard(string title, string subtitle, int time = 5000)`
- `public void ShowWeaponPurchasedMessage(string bigMessage, string weaponName, WeaponHash weapon, int time = 5000)`

## BigMessageThread

class `NativeUI.BigMessageThread` : `Script`, `IDisposable`

### Constructors

- `public BigMessageThread()`

### Properties

- `public static BigMessageHandler MessageInstance { get; set; }`

## CheckboxChangeEvent

delegate `NativeUI.CheckboxChangeEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public CheckboxChangeEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, UIMenuCheckboxItem checkboxItem, bool Checked, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender, UIMenuCheckboxItem checkboxItem, bool Checked)`

## HudColor

enum `NativeUI.HudColor`

180 values:

```text
HUD_COLOUR_PURE_WHITE = 0
HUD_COLOUR_WHITE = 1
HUD_COLOUR_BLACK = 2
HUD_COLOUR_GREY = 3
HUD_COLOUR_GREYLIGHT = 4
HUD_COLOUR_GREYDARK = 5
HUD_COLOUR_RED = 6
HUD_COLOUR_REDLIGHT = 7
HUD_COLOUR_REDDARK = 8
HUD_COLOUR_BLUE = 9
HUD_COLOUR_BLUELIGHT = 10
HUD_COLOUR_BLUEDARK = 11
HUD_COLOUR_YELLOW = 12
HUD_COLOUR_YELLOWLIGHT = 13
HUD_COLOUR_YELLOWDARK = 14
HUD_COLOUR_ORANGE = 15
HUD_COLOUR_ORANGELIGHT = 16
HUD_COLOUR_ORANGEDARK = 17
HUD_COLOUR_GREEN = 18
HUD_COLOUR_GREENLIGHT = 19
HUD_COLOUR_GREENDARK = 20
HUD_COLOUR_PURPLE = 21
HUD_COLOUR_PURPLELIGHT = 22
HUD_COLOUR_PURPLEDARK = 23
HUD_COLOUR_PINK = 24
HUD_COLOUR_RADAR_HEALTH = 25
HUD_COLOUR_RADAR_ARMOUR = 26
HUD_COLOUR_RADAR_DAMAGE = 27
HUD_COLOUR_NET_PLAYER1 = 28
HUD_COLOUR_NET_PLAYER2 = 29
HUD_COLOUR_NET_PLAYER3 = 30
HUD_COLOUR_NET_PLAYER4 = 31
HUD_COLOUR_NET_PLAYER5 = 32
HUD_COLOUR_NET_PLAYER6 = 33
HUD_COLOUR_NET_PLAYER7 = 34
HUD_COLOUR_NET_PLAYER8 = 35
HUD_COLOUR_NET_PLAYER9 = 36
HUD_COLOUR_NET_PLAYER10 = 37
HUD_COLOUR_NET_PLAYER11 = 38
HUD_COLOUR_NET_PLAYER12 = 39
HUD_COLOUR_NET_PLAYER13 = 40
HUD_COLOUR_NET_PLAYER14 = 41
HUD_COLOUR_NET_PLAYER15 = 42
HUD_COLOUR_NET_PLAYER16 = 43
HUD_COLOUR_NET_PLAYER17 = 44
HUD_COLOUR_NET_PLAYER18 = 45
HUD_COLOUR_NET_PLAYER19 = 46
HUD_COLOUR_NET_PLAYER20 = 47
HUD_COLOUR_NET_PLAYER21 = 48
HUD_COLOUR_NET_PLAYER22 = 49
HUD_COLOUR_NET_PLAYER23 = 50
HUD_COLOUR_NET_PLAYER24 = 51
HUD_COLOUR_NET_PLAYER25 = 52
HUD_COLOUR_NET_PLAYER26 = 53
HUD_COLOUR_NET_PLAYER27 = 54
HUD_COLOUR_NET_PLAYER28 = 55
HUD_COLOUR_NET_PLAYER29 = 56
HUD_COLOUR_NET_PLAYER30 = 57
HUD_COLOUR_NET_PLAYER31 = 58
HUD_COLOUR_NET_PLAYER32 = 59
HUD_COLOUR_SIMPLEBLIP_DEFAULT = 60
HUD_COLOUR_MENU_BLUE = 61
HUD_COLOUR_MENU_GREY_LIGHT = 62
HUD_COLOUR_MENU_BLUE_EXTRA_DARK = 63
HUD_COLOUR_MENU_YELLOW = 64
HUD_COLOUR_MENU_YELLOW_DARK = 65
HUD_COLOUR_MENU_GREEN = 66
HUD_COLOUR_MENU_GREY = 67
HUD_COLOUR_MENU_GREY_DARK = 68
HUD_COLOUR_MENU_HIGHLIGHT = 69
HUD_COLOUR_MENU_STANDARD = 70
HUD_COLOUR_MENU_DIMMED = 71
HUD_COLOUR_MENU_EXTRA_DIMMED = 72
HUD_COLOUR_BRIEF_TITLE = 73
HUD_COLOUR_MID_GREY_MP = 74
HUD_COLOUR_NET_PLAYER1_DARK = 75
HUD_COLOUR_NET_PLAYER2_DARK = 76
HUD_COLOUR_NET_PLAYER3_DARK = 77
HUD_COLOUR_NET_PLAYER4_DARK = 78
HUD_COLOUR_NET_PLAYER5_DARK = 79
HUD_COLOUR_NET_PLAYER6_DARK = 80
HUD_COLOUR_NET_PLAYER7_DARK = 81
HUD_COLOUR_NET_PLAYER8_DARK = 82
HUD_COLOUR_NET_PLAYER9_DARK = 83
HUD_COLOUR_NET_PLAYER10_DARK = 84
HUD_COLOUR_NET_PLAYER11_DARK = 85
HUD_COLOUR_NET_PLAYER12_DARK = 86
HUD_COLOUR_NET_PLAYER13_DARK = 87
HUD_COLOUR_NET_PLAYER14_DARK = 88
HUD_COLOUR_NET_PLAYER15_DARK = 89
HUD_COLOUR_NET_PLAYER16_DARK = 90
HUD_COLOUR_NET_PLAYER17_DARK = 91
HUD_COLOUR_NET_PLAYER18_DARK = 92
HUD_COLOUR_NET_PLAYER19_DARK = 93
HUD_COLOUR_NET_PLAYER20_DARK = 94
HUD_COLOUR_NET_PLAYER21_DARK = 95
HUD_COLOUR_NET_PLAYER22_DARK = 96
HUD_COLOUR_NET_PLAYER23_DARK = 97
HUD_COLOUR_NET_PLAYER24_DARK = 98
HUD_COLOUR_NET_PLAYER25_DARK = 99
HUD_COLOUR_NET_PLAYER26_DARK = 100
HUD_COLOUR_NET_PLAYER27_DARK = 101
HUD_COLOUR_NET_PLAYER28_DARK = 102
HUD_COLOUR_NET_PLAYER29_DARK = 103
HUD_COLOUR_NET_PLAYER30_DARK = 104
HUD_COLOUR_NET_PLAYER31_DARK = 105
HUD_COLOUR_NET_PLAYER32_DARK = 106
HUD_COLOUR_BRONZE = 107
HUD_COLOUR_SILVER = 108
HUD_COLOUR_GOLD = 109
HUD_COLOUR_PLATINUM = 110
HUD_COLOUR_GANG1 = 111
HUD_COLOUR_GANG2 = 112
HUD_COLOUR_GANG3 = 113
HUD_COLOUR_GANG4 = 114
HUD_COLOUR_SAME_CREW = 115
HUD_COLOUR_FREEMODE = 116
HUD_COLOUR_PAUSE_BG = 117
HUD_COLOUR_FRIENDLY = 118
HUD_COLOUR_ENEMY = 119
HUD_COLOUR_LOCATION = 120
HUD_COLOUR_PICKUP = 121
HUD_COLOUR_PAUSE_SINGLEPLAYER = 122
HUD_COLOUR_FREEMODE_DARK = 123
HUD_COLOUR_INACTIVE_MISSION = 124
HUD_COLOUR_DAMAGE = 125
HUD_COLOUR_PINKLIGHT = 126
HUD_COLOUR_PM_MITEM_HIGHLIGHT = 127
HUD_COLOUR_SCRIPT_VARIABLE = 128
HUD_COLOUR_YOGA = 129
HUD_COLOUR_TENNIS = 130
HUD_COLOUR_GOLF = 131
HUD_COLOUR_SHOOTING_RANGE = 132
HUD_COLOUR_FLIGHT_SCHOOL = 133
HUD_COLOUR_NORTH_BLUE = 134
HUD_COLOUR_SOCIAL_CLUB = 135
HUD_COLOUR_PLATFORM_BLUE = 136
HUD_COLOUR_PLATFORM_GREEN = 137
HUD_COLOUR_PLATFORM_GREY = 138
HUD_COLOUR_FACEBOOK_BLUE = 139
HUD_COLOUR_INGAME_BG = 140
HUD_COLOUR_DARTS = 141
HUD_COLOUR_WAYPOINT = 142
HUD_COLOUR_MICHAEL = 143
HUD_COLOUR_FRANKLIN = 144
HUD_COLOUR_TREVOR = 145
HUD_COLOUR_GOLF_P1 = 146
HUD_COLOUR_GOLF_P2 = 147
HUD_COLOUR_GOLF_P3 = 148
HUD_COLOUR_GOLF_P4 = 149
HUD_COLOUR_WAYPOINTLIGHT = 150
HUD_COLOUR_WAYPOINTDARK = 151
HUD_COLOUR_PANEL_LIGHT = 152
HUD_COLOUR_MICHAEL_DARK = 153
HUD_COLOUR_FRANKLIN_DARK = 154
HUD_COLOUR_TREVOR_DARK = 155
HUD_COLOUR_OBJECTIVE_ROUTE = 156
HUD_COLOUR_PAUSEMAP_TINT = 157
HUD_COLOUR_PAUSE_DESELECT = 158
HUD_COLOUR_PM_WEAPONS_PURCHASABLE = 159
HUD_COLOUR_PM_WEAPONS_LOCKED = 160
HUD_COLOUR_END_SCREEN_BG = 161
HUD_COLOUR_CHOP = 162
HUD_COLOUR_PAUSEMAP_TINT_HALF = 163
HUD_COLOUR_NORTH_BLUE_OFFICIAL = 164
HUD_COLOUR_SCRIPT_VARIABLE_2 = 165
HUD_COLOUR_H = 166
HUD_COLOUR_HDARK = 167
HUD_COLOUR_T = 168
HUD_COLOUR_TDARK = 169
HUD_COLOUR_HSHARD = 170
HUD_COLOUR_CONTROLLER_MICHAEL = 171
HUD_COLOUR_CONTROLLER_FRANKLIN = 172
HUD_COLOUR_CONTROLLER_TREVOR = 173
HUD_COLOUR_CONTROLLER_CHOP = 174
HUD_COLOUR_VIDEO_EDITOR_VIDEO = 175
HUD_COLOUR_VIDEO_EDITOR_AUDIO = 176
HUD_COLOUR_VIDEO_EDITOR_TEXT = 177
HUD_COLOUR_HB_BLUE = 178
HUD_COLOUR_HB_YELLOW = 179
```

## IListItem

interface `NativeUI.IListItem`

### Methods

- `public string CurrentItem()`

## IndexChangedEvent

delegate `NativeUI.IndexChangedEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public IndexChangedEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, int newIndex, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender, int newIndex)`

## InstructionalButton

class `NativeUI.InstructionalButton`

### Constructors

- `public InstructionalButton(Control control, string text)`
  - Add a dynamic button to the instructional buttons array. Changes whether the controller is being used and changes depending on keybinds.
  - `control`: GTA.Control that gets converted into a button.
  - `text`: Help text that goes with the button.
- `public InstructionalButton(string keystring, string text)`
  - Adds a keyboard button to the instructional buttons array.
  - `keystring`: Custom keyboard button, like "I", or "O", or "F5".
  - `text`: Help text that goes with the button.

### Properties

- `public UIMenuItem ItemBind { get; }`
- `public string Text { get; set; }`

### Methods

- `public void BindToItem(UIMenuItem item)`
  - Bind this button to an item, so it's only shown when that item is selected.
  - `item`: Item to bind to.
- `public string GetButtonId()`

## ItemActivatedEvent

delegate `NativeUI.ItemActivatedEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public ItemActivatedEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, UIMenuItem selectedItem, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender, UIMenuItem selectedItem)`

## ItemCheckboxEvent

delegate `NativeUI.ItemCheckboxEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public ItemCheckboxEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenuCheckboxItem sender, bool Checked, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenuCheckboxItem sender, bool Checked)`

## ItemListEvent

delegate `NativeUI.ItemListEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public ItemListEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenuListItem sender, int newIndex, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenuListItem sender, int newIndex)`

## ItemSelectEvent

delegate `NativeUI.ItemSelectEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public ItemSelectEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, UIMenuItem selectedItem, int index, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender, UIMenuItem selectedItem, int index)`

## ItemSliderEvent

delegate `NativeUI.ItemSliderEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public ItemSliderEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenuSliderItem sender, int newIndex, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenuSliderItem sender, int newIndex)`

## ListChangedEvent

delegate `NativeUI.ListChangedEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public ListChangedEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, UIMenuListItem listItem, int newIndex, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender, UIMenuListItem listItem, int newIndex)`

## MenuChangeEvent

delegate `NativeUI.MenuChangeEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public MenuChangeEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu oldMenu, UIMenu newMenu, bool forward, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu oldMenu, UIMenu newMenu, bool forward)`

## MenuCloseEvent

delegate `NativeUI.MenuCloseEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public MenuCloseEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender)`

## MenuOpenEvent

delegate `NativeUI.MenuOpenEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public MenuOpenEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender)`

## MenuPool

class `NativeUI.MenuPool`

Helper class that handles all of your Menus. After instatiating it, you will have to add your menu by using the Add method.

### Constructors

- `public MenuPool()`

### Properties

- `public string AUDIO_BACK { set; }`
- `public string AUDIO_ERROR { set; }`
- `public string AUDIO_LIBRARY { set; }`
- `public string AUDIO_SELECT { set; }`
- `public string AUDIO_UPDOWN { set; }`
- `public bool ControlDisablingEnabled { set; }`
- `public string CounterPretext { set; }`
- `public bool DisableInstructionalButtons { set; }`
- `public bool FormatDescriptions { set; }`
- `public bool MouseEdgeEnabled { set; }`
- `public bool ResetCursorOnOpen { set; }`
- `public int WidthOffset { set; }`

### Methods

- `public void Add(UIMenu menu)`
  - Add your menu to the menu pool.
- `public UIMenu AddSubMenu(UIMenu menu, string text, Point offset)`
  - Create and add a submenu to the menu pool with a custom offset. Adds an item with the given text to the menu, creates a corresponding submenu, and binds the submenu to the item. The submenu inherits its title from the menu, and its subtitle from the item text.
  - `menu`: The parent menu to which the submenu must be added.
  - `text`: The name of the submenu
  - `offset`: The offset of the menu
  - Returns: The newly created submenu.
- `public UIMenu AddSubMenu(UIMenu menu, string text, string description, Point offset)`
  - Create and add a submenu to the menu pool. Adds an item with the given text and description to the menu, creates a corresponding submenu, and binds the submenu to the item. The submenu inherits its title from the menu, and its subtitle from the item text.
  - `menu`: The parent menu to which the submenu must be added.
  - `text`: The name of the submenu.
  - `description`: The name of the submenu.
  - Returns: The newly created submenu.
- `public UIMenu AddSubMenu(UIMenu menu, string text, string description)`
  - Create and add a submenu to the menu pool. Adds an item with the given text and description to the menu, creates a corresponding submenu, and binds the submenu to the item. The submenu inherits its title from the menu, and its subtitle from the item text.
  - `menu`: The parent menu to which the submenu must be added.
  - `text`: The name of the submenu.
  - `description`: The name of the submenu.
  - Returns: The newly created submenu.
- `public UIMenu AddSubMenu(UIMenu menu, string text)`
  - Create and add a submenu to the menu pool. Adds an item with the given text to the menu, creates a corresponding submenu, and binds the submenu to the item. The submenu inherits its title from the menu, and its subtitle from the item text.
  - `menu`: The parent menu to which the submenu must be added.
  - `text`: The name of the submenu.
  - Returns: The newly created submenu.
- `public void CloseAllMenus()`
  - Closes all of your menus.
- `public void Draw()`
  - Draws all visible menus.
- `public bool IsAnyMenuOpen()`
  - Checks if any menu is currently visible.
  - Returns: true if at least one menu is visible, false if not.
- `public void ProcessControl()`
  - Processes all of your visible menus' controls.
- `public void ProcessKey(Keys key)`
  - Processes all of your visible menus' keys.
- `public void ProcessMenus()`
  - Process all of your menus' functions. Call this in a tick event.
- `public void ProcessMouse()`
  - Processes all of your visible menus' mouses.
- `public void RefreshIndex()`
  - Refresh index of every menu in the pool. Use this after you have finished constructing the entire menu pool.
- `public void ResetKey(UIMenu.MenuControls menuControl)`
- `public void SetBannerType(Sprite bannerType)`
- `public void SetBannerType(UIResRectangle bannerType)`
- `public void SetBannerType(string bannerPath)`
- `public void SetKey(UIMenu.MenuControls menuControl, Control control, int controllerIndex)`
- `public void SetKey(UIMenu.MenuControls menuControl, Control control)`
- `public void SetKey(UIMenu.MenuControls menuControl, Keys control)`
- `public List<UIMenu> ToList()`
  - Returns all of your menus.

### Fields

- `public bool BannerInheritance`
- `public bool OffsetInheritance`

## MiscExtensions

static class `NativeUI.MiscExtensions`

### Methods

- `public static Point AddPoints(Point left, Point right)`
- `public static float Clamp(float val, float min, float max)`
- `public static float LinearFloatLerp(float start, float end, int currentTime, int duration)`
- `public static Vector3 LinearVectorLerp(Vector3 start, Vector3 end, int currentTime, int duration)`
- `public static float QuadraticEasingLerp(float start, float end, int currentTime, int duration)`
- `public static Point SubtractPoints(Point left, Point right)`
- `public static Vector3 VectorLerp(Vector3 start, Vector3 end, int currentTime, int duration, Func<float, float, int, int, float> easingFunc)`

### Fields

- `public static Random SharedRandom`

## SliderChangedEvent

delegate `NativeUI.SliderChangedEvent` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public SliderChangedEvent(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenu sender, UIMenuSliderItem listItem, int newIndex, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(UIMenu sender, UIMenuSliderItem listItem, int newIndex)`

## Sprite

class `NativeUI.Sprite`

### Constructors

- `public Sprite(string textureDict, string textureName, Point position, Size size, float heading, Color color)`
  - Creates a game sprite object from a texture dictionary and texture name.
- `public Sprite(string textureDict, string textureName, Point position, Size size)`
  - Creates a game sprite object from a texture dictionary and texture name.

### Properties

- `public string TextureDict { get; set; }`

### Methods

- `public void Draw()`
  - Draws the sprite on a 1080-pixels height base.
- `public static void Draw(string dict, string name, int xpos, int ypos, int boxWidth, int boxHeight, float rotation, Color color)`
- `public static void DrawTexture(string path, Point position, Size size, float rotation, Color color)`
  - Draw a custom texture from a file on a 1080-pixels height base.
  - `path`: Path to texture file.
- `public static void DrawTexture(string path, Point position, Size size)`
  - Draw a custom texture from a file on a 1080-pixels height base.
  - `path`: Path to texture file.
- `public static string WriteFileFromResources(Assembly yourAssembly, string fullResourceName, string savePath)`
  - Save an embedded resource to a concrete path.
  - `yourAssembly`: Your executing assembly.
  - `fullResourceName`: Resource name including your solution name. E.G MyMenuMod.banner.png
  - `savePath`: Path to where save the file, including the filename.
  - Returns: Absolute path to the written file.
- `public static string WriteFileFromResources(Assembly yourAssembly, string fullResourceName)`
  - Save an embedded resource to a temporary file.
  - `yourAssembly`: Your executing assembly.
  - `fullResourceName`: Resource name including your solution name. E.G MyMenuMod.banner.png
  - Returns: Absolute path to the written file.

### Fields

- `public Color Color`
- `public float Heading`
- `public Point Position`
- `public Size Size`
- `public string TextureName`
- `public bool Visible`

## StringMeasurer

static class `NativeUI.StringMeasurer`

### Methods

- `public static float MeasureString(string input, Font font, float scale)`
  - Measures width of a 0.35 scale string.
- `public static int MeasureString(string input)`
  - Measures width of a 0.35 scale string.

## TextTimerBar

class `NativeUI.TextTimerBar` : `TimerBarBase`

### Constructors

- `public TextTimerBar(string label, string text)`

### Properties

- `public string Text { get; set; }`

### Methods

- `public virtual void Draw(int interval)`

## TimerBarBase

abstract class `NativeUI.TimerBarBase`

### Constructors

- `public TimerBarBase(string label)`

### Properties

- `public string Label { get; set; }`

### Methods

- `public virtual void Draw(int interval)`

## TimerBarPool

class `NativeUI.TimerBarPool`

### Constructors

- `public TimerBarPool()`

### Methods

- `public void Add(TimerBarBase timer)`
- `public void Draw()`
- `public void Remove(TimerBarBase timer)`
- `public List<TimerBarBase> ToList()`

## UIMenu

class `NativeUI.UIMenu`

Base class for NativeUI. Calls the next events: OnIndexChange, OnListChanged, OnCheckboxChange, OnItemSelect, OnMenuClose, OnMenuchange.

### Constructors

- `public UIMenu(string title, string subtitle, Point offset, string spriteLibrary, string spriteName)`
  - Advanced Menu constructor that allows custom title banner.
  - `title`: Title that appears on the big banner. Set to "" if you are using a custom banner.
  - `subtitle`: Subtitle that appears in capital letters in a small black bar.
  - `offset`: Point object with X and Y data for offsets. Applied to all menu elements.
  - `spriteLibrary`: Sprite library name for the banner.
  - `spriteName`: Sprite name for the banner.
- `public UIMenu(string title, string subtitle, Point offset, string customBanner)`
  - Initialise a menu with a custom texture banner.
  - `title`: Title that appears on the big banner. Set to "" if you don't want a title.
  - `subtitle`: Subtitle that appears in capital letters in a small black bar. Set to "" if you dont want a subtitle.
  - `offset`: Point object with X and Y data for offsets. Applied to all menu elements.
  - `customBanner`: Path to your custom texture.
- `public UIMenu(string title, string subtitle, Point offset)`
  - Basic Menu constructor with an offset.
  - `title`: Title that appears on the big banner.
  - `subtitle`: Subtitle that appears in capital letters in a small black bar. Set to "" if you dont want a subtitle.
  - `offset`: Point object with X and Y data for offsets. Applied to all menu elements.
- `public UIMenu(string title, string subtitle)`
  - Basic Menu constructor.
  - `title`: Title that appears on the big banner.
  - `subtitle`: Subtitle that appears in capital letters in a small black bar.

### Properties

- `public UIResRectangle BannerRectangle { get; }`
- `public Sprite BannerSprite { get; }`
- `public string BannerTexture { get; }`
- `public Dictionary<UIMenuItem, UIMenu> Children { get; }`
- `public string CounterPretext { get; set; }`
  - String to pre-attach to the counter string. Useful for color codes.
- `public int CurrentSelection { get; set; }`
  - Returns the current selected item's index. Change the current selected item to index. Use this after you add or remove items dynamically.
- `public Point Offset { get; }`
- `public UIMenuItem ParentItem { get; set; }`
  - If this is a nested menu, returns the item it was bound to.
- `public UIMenu ParentMenu { get; set; }`
  - If this is a nested menu, returns the parent menu. You can also set it to a menu so when pressing Back it goes to that menu.
- `public int Size { get; }`
  - Returns the amount of items in the menu.
- `public UIResText Subtitle { get; }`
  - Returns the subtitle object.
- `public UIResText Title { get; }`
  - Returns the title object.
- `public bool Visible { get; set; }`
  - Change whether this menu is visible to the user.
- `public int WidthOffset { get; }`
  - Returns the current width offset.
- `public static bool IsUsingController { get; }`
  - Returns false if last input was made with mouse and keyboard, true if it was made with a controller.

### Methods

- `public void AddInstructionalButton(InstructionalButton button)`
- `public void AddItem(UIMenuItem item)`
  - Add an item to the menu.
  - `item`: Item object to be added. Can be normal item, checkbox or list item.
- `public void BindMenuToItem(UIMenu menuToBind, UIMenuItem itemToBindTo)`
  - Makes the specified item open a menu when is activated.
  - `menuToBind`: The menu that is going to be opened when the item is activated.
  - `itemToBindTo`: The item that is going to activate the menu.
- `protected virtual void CheckboxChange(UIMenuCheckboxItem sender, bool Checked)`
- `public void Clear()`
  - Remove all items from the menu.
- `public void DisableInstructionalButtons(bool disable)`
  - Enable or disable the instructional buttons.
- `public void Draw()`
  - Draw the menu and all of it's components.
- `public void GoBack()`
  - Close or go back in a menu chain.
- `public void GoDown()`
  - Go up the menu if the number of items is less than or equal to the maximum items on screen.
- `public void GoDownOverflow()`
  - Go down the menu if the number of items is more than maximum items on screen.
- `public void GoLeft()`
  - Go left on a UIMenuListItem, UIMenuDynamicListItem or UIMenuSliderItem.
- `public void GoRight()`
  - Go right on a UIMenuListItem.
- `public void GoUp()`
  - Go up the menu if the number of items is less than or equal to the maximum items on screen.
- `public void GoUpOverflow()`
  - Go up the menu if the number of items is more than maximum items on screen.
- `public bool HasControlJustBeenPressed(UIMenu.MenuControls control, Keys key = 0)`
  - Check whether a menucontrol has been pressed.
  - `control`: Control to check for.
  - `key`: Key if you're using keys.
- `public bool HasControlJustBeenReleaseed(UIMenu.MenuControls control, Keys key = 0)`
  - Check whether a menucontrol has been released.
  - `control`: Control to check for.
  - `key`: Key if you're using keys.
- `protected virtual void IndexChange(int newindex)`
- `public bool IsControlBeingPressed(UIMenu.MenuControls control, Keys key = 0)`
  - Check whether a menucontrol is being pressed.
- `protected virtual void ItemSelect(UIMenuItem selecteditem, int index)`
- `protected virtual void ListChange(UIMenuListItem sender, int newindex)`
- `protected virtual void MenuChangeEv(UIMenu newmenu, bool forward)`
- `protected virtual void MenuCloseEv()`
- `protected virtual void MenuOpenEv()`
- `public void ProcessControl(Keys key = 0)`
  - Process control-stroke. Call this in the OnTick event.
- `public void ProcessKey(Keys key)`
  - Process keystroke. Call this in the OnKeyDown event.
- `public void ProcessMouse()`
  - Process the mouse's position and check if it's hovering over any UI element. Call this in OnTick
- `public void RefreshIndex()`
  - Reset the current selected item to 0. Use this after you add or remove items dynamically.
- `public bool ReleaseMenuFromItem(UIMenuItem releaseFrom)`
  - Remove menu binding from button.
  - `releaseFrom`: Button to release from.
  - Returns: Returns true if the operation was successful.
- `public void Remove(Func<UIMenuItem, bool> predicate)`
  - Removes the items that matches the predicate.
  - `predicate`: The function to use as the check.
- `public void RemoveInstructionalButton(InstructionalButton button)`
- `public void RemoveItemAt(int index)`
  - Remove an item at index n.
  - `index`: Index to remove the item at.
- `public void ResetKey(UIMenu.MenuControls control)`
  - Remove all controls on a control.
- `public void SelectItem()`
  - Activate the current selected item.
- `public void SetBannerType(Sprite spriteBanner)`
  - Set the banner to your own Sprite object.
  - `spriteBanner`: Sprite object. The position and size does not matter.
- `public void SetBannerType(UIResRectangle rectangle)`
  - Set the banner to your own Rectangle.
  - `rectangle`: UIResRectangle object. Position and size does not matter.
- `public void SetBannerType(string pathToCustomSprite)`
  - Set the banner to your own custom texture. Set it to "" if you want to restore the banner.
  - `pathToCustomSprite`: Path to your sprite image.
- `public void SetKey(UIMenu.MenuControls control, Control gtaControl, int controlIndex)`
  - Set a GTA.Control to control a menu only on a specific index.
- `public void SetKey(UIMenu.MenuControls control, Control gtaControl)`
  - Set a GTA.Control to control a menu. Can be multiple controls. This applies it to all indexes.
- `public void SetKey(UIMenu.MenuControls control, Keys keyToSet)`
  - Set a key to control a menu. Can be multiple keys for each control.
- `public void SetMenuWidthOffset(int widthOffset)`
  - Change the menu's width. The width is calculated as DefaultWidth + WidthOffset, so a width offset of 10 would enlarge the menu by 10 pixels.
  - `widthOffset`: New width offset.
- `protected virtual void SliderChange(UIMenuSliderItem sender, int newindex)`
- `public void UpdateScaleform()`
  - Manually update the instructional buttons scaleform.
- `public static void DisEnableControls(bool enable)`
  - Enable or disable all controls but the necessary to operate a menu.
- `public static Point GetSafezoneBounds()`
  - Returns the safezone bounds in pixel, relative to the 1080pixel based system.
- `public static SizeF GetScreenResolutionMaintainRatio()`
  - Returns the 1080pixels-based screen resolution while mantaining current aspect ratio.
- `public static SizeF GetScreenResolutionMantainRatio()`
  - **Obsolete.** Use GetScreenResolutionMaintainRatio
  - Old GetScreenResolutionMantainRatio Method to support old versions
- `public static bool IsMouseInBounds(Point topLeft, Size boxSize)`
  - Chech whether the mouse is inside the specified rectangle.
  - `topLeft`: top left point of your rectangle.
  - `boxSize`: size of your rectangle.

### Events

- `public event CheckboxChangeEvent OnCheckboxChange`
  - Called when user presses enter on a checkbox item.
- `public event IndexChangedEvent OnIndexChange`
  - Called when user presses up or down, changing current selection.
- `public event ItemSelectEvent OnItemSelect`
  - Called when user selects a simple item.
- `public event ListChangedEvent OnListChange`
  - Called when user presses left or right, changing a list position.
- `public event MenuChangeEvent OnMenuChange`
  - Called when user either clicks on a binded button or goes back to a parent menu.
- `public event MenuCloseEvent OnMenuClose`
  - Called when user closes the menu or goes back in a menu chain.
- `public event MenuOpenEvent OnMenuOpen`
  - Called when user opens the menu.
- `public event SliderChangedEvent OnSliderChange`
  - Called when user presses left or right, changing a slider position.

### Fields

- `public string AUDIO_BACK`
- `public string AUDIO_ERROR`
- `public string AUDIO_LEFTRIGHT`
- `public string AUDIO_LIBRARY`
- `public string AUDIO_SELECT`
- `public string AUDIO_UPDOWN`
- `public bool ControlDisablingEnabled`
- `public bool FormatDescriptions`
- `public List<UIMenuItem> MenuItems`
- `public bool MouseControlsEnabled`
- `public bool MouseEdgeEnabled`
- `public bool ResetCursorOnOpen`
- `public bool ScaleWithSafezone`

## UIMenu.MenuControls

enum `NativeUI.UIMenu.MenuControls`

| Name | Value |
| --- | --- |
| `Up` | 0 |
| `Down` | 1 |
| `Left` | 2 |
| `Right` | 3 |
| `Select` | 4 |
| `Back` | 5 |

## UIMenuCheckboxItem

class `NativeUI.UIMenuCheckboxItem` : `UIMenuItem`

### Constructors

- `public UIMenuCheckboxItem(string text, bool check, string description)`
  - Checkbox item with a toggleable checkbox.
  - `text`: Item label.
  - `check`: Boolean value whether the checkbox is checked.
  - `description`: Description for this item.
- `public UIMenuCheckboxItem(string text, bool check)`
  - Checkbox item with a toggleable checkbox.
  - `text`: Item label.
  - `check`: Boolean value whether the checkbox is checked.

### Properties

- `public bool Checked { get; set; }`
  - Change or get whether the checkbox is checked.

### Methods

- `public void CheckboxEventTrigger()`
- `public virtual void Draw()`
  - Draw item.
- `public virtual void Position(int y)`
  - Change item's position.
  - `y`: New Y value.
- `public virtual void SetRightBadge(UIMenuItem.BadgeStyle badge)`
- `public virtual void SetRightLabel(string text)`

### Events

- `public event ItemCheckboxEvent CheckboxEvent`
  - Triggered when the checkbox state is changed.

### Fields

- `protected Sprite _checkedSprite`

## UIMenuColoredItem

class `NativeUI.UIMenuColoredItem` : `UIMenuItem`

### Constructors

- `public UIMenuColoredItem(string label, Color color, Color highlightColor)`
- `public UIMenuColoredItem(string label, string description, Color color, Color highlightColor)`

### Properties

- `public Color HighlightColor { get; set; }`
- `public Color HighlightedTextColor { get; set; }`
- `public Color MainColor { get; set; }`
- `public Color TextColor { get; set; }`

### Methods

- `public virtual void Draw()`
- `protected void Init()`

## UIMenuDynamicListItem

class `NativeUI.UIMenuDynamicListItem` : `UIMenuItem`, `IListItem`

### Constructors

- `public UIMenuDynamicListItem(string text, string startingItem, UIMenuDynamicListItem.DynamicListItemChangeCallback changeCallback)`
  - List item with items generated at runtime
  - `text`: Label text
- `public UIMenuDynamicListItem(string text, string description, string startingItem, UIMenuDynamicListItem.DynamicListItemChangeCallback changeCallback)`
  - List item with items generated at runtime
  - `text`: Label text
  - `description`: Item description

### Properties

- `public UIMenuDynamicListItem.DynamicListItemChangeCallback Callback { get; set; }`
- `public string CurrentListItem { get; }`

### Methods

- `public string CurrentItem()`
- `public virtual void Draw()`
  - Draw item.
- `public virtual void Position(int y)`
  - Change item's position.
  - `y`: New Y position.
- `public virtual void SetRightBadge(UIMenuItem.BadgeStyle badge)`
- `public virtual void SetRightLabel(string text)`

### Fields

- `protected Sprite _arrowLeft`
- `protected Sprite _arrowRight`
- `protected UIResText _itemText`

## UIMenuDynamicListItem.ChangeDirection

enum `NativeUI.UIMenuDynamicListItem.ChangeDirection`

| Name | Value |
| --- | --- |
| `Left` | 0 |
| `Right` | 1 |

## UIMenuDynamicListItem.DynamicListItemChangeCallback

delegate `NativeUI.UIMenuDynamicListItem.DynamicListItemChangeCallback` : `MulticastDelegate`, `ICloneable`, `ISerializable`

### Constructors

- `public DynamicListItemChangeCallback(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(UIMenuDynamicListItem sender, UIMenuDynamicListItem.ChangeDirection direction, AsyncCallback callback, object object)`
- `public virtual string EndInvoke(IAsyncResult result)`
- `public virtual string Invoke(UIMenuDynamicListItem sender, UIMenuDynamicListItem.ChangeDirection direction)`

## UIMenuItem

class `NativeUI.UIMenuItem`

Simple item with a label.

### Constructors

- `public UIMenuItem(string text, string description)`
  - Basic menu button.
  - `text`: Button label.
  - `description`: Description.
- `public UIMenuItem(string text)`
  - Basic menu button.
  - `text`: Button label.

### Properties

- `public string Description { get; set; }`
  - This item's description.
- `public bool Enabled { get; set; }`
  - Whether this item is enabled or disabled (text is greyed out and you cannot select it).
- `public bool Hovered { get; set; }`
  - Whether this item is currently being hovered on with a mouse.
- `public UIMenuItem.BadgeStyle LeftBadge { get; }`
  - Returns the current left badge.
- `public Point Offset { get; set; }`
  - This item's offset.
- `public UIMenu Parent { get; set; }`
  - Returns the menu this item is in.
- `public UIMenuItem.BadgeStyle RightBadge { get; }`
  - Returns the current right badge.
- `public string RightLabel { get; }`
  - Returns the current right label.
- `public bool Selected { get; set; }`
  - Whether this item is currently selected.
- `public string Text { get; set; }`
  - Returns this item's label.

### Methods

- `public virtual void Draw()`
  - Draw this item.
- `public virtual void Position(int y)`
  - Set item's position.
- `public virtual void SetLeftBadge(UIMenuItem.BadgeStyle badge)`
  - Set the left badge. Set it to None to remove the badge.
- `public virtual void SetRightBadge(UIMenuItem.BadgeStyle badge)`
  - Set the right badge. Set it to None to remove the badge.
- `public virtual void SetRightLabel(string text)`
  - Set the right label.
  - `text`: Text as label. Set it to "" to remove the label.

### Events

- `public event ItemActivatedEvent Activated`
  - Called when user selects the current item.

### Fields

- `protected Sprite _badgeLeft`
- `protected Sprite _badgeRight`
- `protected UIResText _labelText`
- `protected UIResRectangle _rectangle`
- `protected Sprite _selectedSprite`
- `protected UIResText _text`

## UIMenuItem.BadgeStyle

enum `NativeUI.UIMenuItem.BadgeStyle`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `BronzeMedal` | 1 |
| `GoldMedal` | 2 |
| `SilverMedal` | 3 |
| `Alert` | 4 |
| `Crown` | 5 |
| `Ammo` | 6 |
| `Armour` | 7 |
| `Barber` | 8 |
| `Clothes` | 9 |
| `Franklin` | 10 |
| `Bike` | 11 |
| `Car` | 12 |
| `Gun` | 13 |
| `Heart` | 14 |
| `Makeup` | 15 |
| `Mask` | 16 |
| `Michael` | 17 |
| `Star` | 18 |
| `Tatoo` | 19 |
| `Trevor` | 20 |
| `Lock` | 21 |
| `Tick` | 22 |
| `Sale` | 23 |
| `ArrowLeft` | 24 |
| `ArrowRight` | 25 |
| `Audio1` | 26 |
| `Audio2` | 27 |
| `Audio3` | 28 |
| `AudioInactive` | 29 |
| `AudioMute` | 30 |

## UIMenuListItem

class `NativeUI.UIMenuListItem` : `UIMenuItem`, `IListItem`

### Constructors

- `public UIMenuListItem(string text, List<object> items, int index, string description)`
  - List item, with left/right arrows.
  - `text`: Item label.
  - `items`: List that contains your items.
  - `index`: Index in the list. If unsure user 0.
  - `description`: Description for this item.
- `public UIMenuListItem(string text, List<object> items, int index)`
  - List item, with left/right arrows.
  - `text`: Item label.
  - `items`: List that contains your items.
  - `index`: Index in the list. If unsure user 0.

### Properties

- `public int Index { get; set; }`
  - Returns the current selected index.
- `public List<object> Items { get; set; }`
  - Returns the current selected index.

### Methods

- `public string CurrentItem()`
  - **Obsolete.** Use UIMenuListItem.Items[Index].ToString() instead.
- `public virtual void Draw()`
  - Draw item.
- `public virtual object IndexToItem(int index)`
  - **Obsolete.** Use UIMenuListItem.Items[Index] instead.
  - Find an item by it's index and return the item.
  - `index`: Item's index.
  - Returns: Item
- `public virtual int ItemToIndex(object item)`
  - **Obsolete.** Use UIMenuListItem.Items.FindIndex(p => ReferenceEquals(p, item)) instead.
  - Find an item in the list and return it's index.
  - `item`: Item to search for.
  - Returns: Item index.
- `public virtual void Position(int y)`
  - Change item's position.
  - `y`: New Y position.
- `public virtual void SetRightBadge(UIMenuItem.BadgeStyle badge)`
- `public virtual void SetRightLabel(string text)`

### Events

- `public event ItemListEvent OnListChanged`
  - Triggered when the list is changed.

### Fields

- `protected Sprite _arrowLeft`
- `protected Sprite _arrowRight`
- `protected int _index`
- `protected List<object> _items`
- `protected UIResText _itemText`

## UIMenuSliderItem

class `NativeUI.UIMenuSliderItem` : `UIMenuItem`

### Constructors

- `public UIMenuSliderItem(string text, string description, bool divider)`
  - List item, with slider.
  - `text`: Item label.
  - `items`: List that contains your items.
  - `index`: Index in the list. If unsure user 0.
  - `description`: Description for this item.
  - `divider`: Put a divider in the center of the slider
- `public UIMenuSliderItem(string text, string description)`
  - List item, with slider.
  - `text`: Item label.
  - `items`: List that contains your items.
  - `index`: Index in the list. If unsure user 0.
  - `description`: Description for this item.
- `public UIMenuSliderItem(string text)`
  - List item, with slider.
  - `text`: Item label.
  - `items`: List that contains your items.
  - `index`: Index in the list. If unsure user 0.

### Properties

- `public int Maximum { get; set; }`
  - The maximum value of the slider.
- `public int Multiplier { get; set; }`
  - The multiplier of the left and right navigation movements.
- `public int Value { get; set; }`
  - Curent value of the slider.

### Methods

- `public virtual void Draw()`
  - Draw item.
- `public virtual void Position(int y)`
  - Change item's position.
  - `y`: New Y position.

### Events

- `public event ItemSliderEvent OnSliderChanged`
  - Triggered when the slider is changed.

### Fields

- `protected Sprite _arrowLeft`
- `protected Sprite _arrowRight`
- `protected int _max`
- `protected int _multiplier`
- `protected UIResRectangle _rectangleBackground`
- `protected UIResRectangle _rectangleDivider`
- `protected UIResRectangle _rectangleSlider`
- `protected int _value`

## UIResRectangle

class `NativeUI.UIResRectangle` : `UIRectangle`, `UIElement`

A rectangle in 1080 pixels height system.

### Constructors

- `public UIResRectangle()`
- `public UIResRectangle(Point pos, Size size, Color color)`
- `public UIResRectangle(Point pos, Size size)`

### Methods

- `public virtual void Draw(Size offset)`
- `public static void Draw(int xPos, int yPos, int boxWidth, int boxHeight, Color color)`

## UIResText

class `NativeUI.UIResText` : `UIText`, `UIElement`

A Text object in the 1080 pixels height base system.

### Constructors

- `public UIResText(string caption, Point position, float scale, Color color, Font font, UIResText.Alignment justify)`
- `public UIResText(string caption, Point position, float scale, Color color)`
- `public UIResText(string caption, Point position, float scale)`

### Properties

- `public bool DropShadow { get; set; }`
- `public bool Outline { get; set; }`
- `public UIResText.Alignment TextAlignment { get; set; }`
- `public Size WordWrap { get; set; }`

### Methods

- `public virtual void Draw(Size offset)`
- `public static void AddLongString(string str)`
  - Push a long string into the stack.
- `public static void Draw(string caption, int xPos, int yPos, Font font, float scale, Color color, UIResText.Alignment alignment, bool dropShadow, bool outline, int wordWrap)`
- `public static float MeasureStringWidth(string str, Font font, float scale)`
- `public static float MeasureStringWidthNoConvert(string str, Font font, float scale)`

## UIResText.Alignment

enum `NativeUI.UIResText.Alignment`

| Name | Value |
| --- | --- |
| `Left` | 0 |
| `Centered` | 1 |
| `Right` | 2 |

