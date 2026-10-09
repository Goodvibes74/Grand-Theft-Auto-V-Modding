# GTA.UI (ScriptHookVDotNet v3)

[Back to the ScriptHookVDotNet v3 index](README.md)

> **Source:** `ScriptHookVDotNet3.dll` (file version 3.7.0.189, assembly version 3.7.0.189, 1,435,136 bytes, modified 2026-08-05, SHA-256 `0f2b8d30ebe79edd74cf364df3943afb7e6305d7453bc687503dcc7411ed5648`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `ScriptHookVDotNet3.xml` from the NuGet package `scripthookvdotnet3` 3.6.0 (nuget.org). The installed DLL is 3.7.0.189, so members added after 3.6.0 have no description.

## Alignment

enum `GTA.UI.Alignment`

| Name | Value |
| --- | --- |
| `Center` | 0 |
| `Left` | 1 |
| `Right` | 2 |

## ContainerElement

class `GTA.UI.ContainerElement` : `IWorldDrawableElement`, `IElement`

### Constructors

- `public ContainerElement()`
  - Initializes a new instance of the `ContainerElement` class used for grouping items on screen.
- `public ContainerElement(PointF position, SizeF size, Color color, bool centered)`
  - Initializes a new instance of the `ContainerElement` class used for grouping items on screen.
  - `position`: Set the `Position` on screen where to draw the `ContainerElement`.
  - `size`: Set the `Size` of the `ContainerElement`.
  - `color`: Set the `Color` used to draw the `ContainerElement`.
  - `centered`: Position the `ContainerElement` based on its center instead of top left corner, see also `Centered`.
- `public ContainerElement(PointF position, SizeF size, Color color)`
  - Initializes a new instance of the `ContainerElement` class used for grouping items on screen.
  - `position`: Set the `Position` on screen where to draw the `ContainerElement`.
  - `size`: Set the `Size` of the `ContainerElement`.
  - `color`: Set the `Color` used to draw the `ContainerElement`.
- `public ContainerElement(PointF position, SizeF size)`
  - Initializes a new instance of the `ContainerElement` class used for grouping items on screen.
  - `position`: Set the `Position` on screen where to draw the `ContainerElement`.
  - `size`: Set the `Size` of the `ContainerElement`.

### Properties

- `public bool Centered { get; set; }`
  - Gets or sets a value indicating whether this `ContainerElement` should be positioned based on its center or top left corner
- `public Color Color { get; set; }`
  - Gets or sets the color of this `ContainerElement`.
- `public bool Enabled { get; set; }`
  - Gets or sets a value indicating whether this `ContainerElement` will be drawn.
- `public List<IElement> Items { get; }`
  - The `IElement`s Contained inside this `ContainerElement`
- `public PointF Position { get; set; }`
  - Gets or sets the position of this `ContainerElement`.
- `public SizeF Size { get; set; }`
  - Gets or sets the size to draw the `ContainerElement`

### Methods

- `public virtual void Draw()`
  - Draws this `ContainerElement` this frame.
- `public virtual void Draw(SizeF offset)`
  - Draws this `ContainerElement` this frame at the specified offset.
  - `offset`: The offset to shift the draw position of this `ContainerElement` using a 1280*720 pixel base.
- `public virtual void ScaledDraw()`
  - Draws this `ContainerElement` this frame using the width returned in `ScaledWidth`.
- `public virtual void ScaledDraw(SizeF offset)`
  - Draws this `ContainerElement` this frame at the specified offset using the width returned in `ScaledWidth`.
  - `offset`: The offset to shift the draw position of this `ContainerElement` using a `ScaledWidth`*720 pixel base.
- `public virtual void WorldDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldDraw(Vector3 position)`
- `public virtual void WorldScaledDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldScaledDraw(Vector3 position)`

## CursorSprite

enum `GTA.UI.CursorSprite`

An enumeration of all possible cursor sprites.

| Name | Value |
| --- | --- |
| `Normal` | 1 |
| `LightArrow` | 2 |
| `OpenHand` | 3 |
| `GrabHand` | 4 |
| `MiddleFinger` | 5 |
| `LeftArrow` | 6 |
| `RightArrow` | 7 |
| `UpArrow` | 8 |
| `DownArrow` | 9 |
| `HorizontalDoubleArrow` | 10 |
| `NormalWithPlus` | 11 |
| `NormalWithMinus` | 12 |

## CustomSprite

class `GTA.UI.CustomSprite` : `ISpriteElement`, `IElement`, `IWorldDrawableElement`

A sprite element using a custom image texture.

### Constructors

- `public CustomSprite(string filename, SizeF size, PointF position, Color color, float rotation, bool centered)`
  - Initializes a new instance of the `CustomSprite` class used for drawing external textures on the screen.
  - `filename`: Full path to location of the `CustomSprite` on the disc.
  - `size`: Set the `Size` of the `CustomSprite`.
  - `position`: Set the `Position` on screen where to draw the `CustomSprite`.
  - `color`: Set the `Color` used to draw the `CustomSprite`.
  - `rotation`: Set the rotation to draw the sprite, measured in degrees, see also `Rotation`.
  - `centered`: Position the `CustomSprite` based on its center instead of top left corner, see also `Centered`.
- `public CustomSprite(string filename, SizeF size, PointF position, Color color, float rotation)`
  - Initializes a new instance of the `CustomSprite` class used for drawing external textures on the screen.
  - `filename`: Full path to location of the `CustomSprite` on the disc.
  - `size`: Set the `Size` of the `CustomSprite`.
  - `position`: Set the `Position` on screen where to draw the `CustomSprite`.
  - `color`: Set the `Color` used to draw the `CustomSprite`.
  - `rotation`: Set the rotation to draw the sprite, measured in degrees, see also `Rotation`.
- `public CustomSprite(string filename, SizeF size, PointF position, Color color)`
  - Initializes a new instance of the `CustomSprite` class used for drawing external textures on the screen.
  - `filename`: Full path to location of the `CustomSprite` on the disc.
  - `size`: Set the `Size` of the `CustomSprite`.
  - `position`: Set the `Position` on screen where to draw the `CustomSprite`.
  - `color`: Set the `Color` used to draw the `CustomSprite`.
- `public CustomSprite(string filename, SizeF size, PointF position)`
  - Initializes a new instance of the `CustomSprite` class used for drawing external textures on the screen.
  - `filename`: Full path to location of the `CustomSprite` on the disc.
  - `size`: Set the `Size` of the `CustomSprite`.
  - `position`: Set the `Position` on screen where to draw the `CustomSprite`.

### Properties

- `public bool Centered { get; set; }`
  - Gets or sets a value indicating whether this `CustomSprite` should be positioned based on its center or top left corner
- `public Color Color { get; set; }`
  - Gets or sets the color of this `CustomSprite`.
- `public bool Enabled { get; set; }`
  - Gets or sets a value indicating whether this `CustomSprite` will be drawn.
- `public string Path { get; }`
- `public PointF Position { get; set; }`
  - Gets or sets the position of this `CustomSprite`.
- `public float Rotation { get; set; }`
  - Gets or sets the rotation to draw thie `CustomSprite`.
- `public SizeF Size { get; set; }`
  - Gets or sets the size to draw the `CustomSprite`

### Methods

- `public void Draw()`
  - Draws this `CustomSprite`.
- `public void Draw(SizeF offset)`
  - Draws the `CustomSprite` at the specified offset.
  - `offset`: The offset.
- `public void LoadTexture(string path)`
- `public virtual void ScaledDraw()`
  - Draws this `CustomSprite` using the width returned in `ScaledWidth`.
- `public virtual void ScaledDraw(SizeF offset)`
  - Draws the `CustomSprite` at the specified offset using the width returned in `ScaledWidth`.
  - `offset`: The offset.
- `public virtual void WorldDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldDraw(Vector3 position)`
- `public virtual void WorldScaledDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldScaledDraw(Vector3 position)`

## FeedPost

class `GTA.UI.FeedPost`

### Properties

- `public int Handle { get; }`

### Methods

- `public void Delete()`
- `public bool Equals(FeedPost other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(FeedPost left, FeedPost right)`
- `public static InputArgument op_Implicit(FeedPost value)`
- `public static bool op_Inequality(FeedPost left, FeedPost right)`

## FeedTextIcon

enum `GTA.UI.FeedTextIcon`

| Name | Value |
| --- | --- |
| `Blank` | 0 |
| `Message` | 1 |
| `Email` | 2 |
| `NewContact` | 3 |
| `Driver` | 4 |
| `Hacker` | 5 |
| `Shooter` | 6 |
| `Invite` | 7 |
| `RP` | 8 |
| `Cash` | 9 |
| `AP` | 10 |
| `XPAlt` | 11 |
| `CashAlt` | 12 |

## FeedUnlockIcon

enum `GTA.UI.FeedUnlockIcon`

| Name | Value |
| --- | --- |
| `Invalid` | -1 |
| `Haircut` | 0 |
| `Tattoo` | 1 |
| `Weapon` | 2 |
| `WeaponPlus` | 3 |
| `Armor` | 4 |
| `Vehicle` | 5 |
| `Mask` | 6 |
| `Clothes` | 7 |
| `Kit` | 8 |
| `Makeup` | 9 |
| `Bag` | 10 |
| `BusinessProperty` | 11 |
| `USFlag` | 12 |
| `USProperty` | 13 |
| `Anchor` | 14 |
| `Plane` | 15 |
| `Heli` | 16 |
| `Bike` | 17 |
| `Discount` | 18 |
| `Mystery` | 19 |
| `Arcade` | 20 |

## Font

enum `GTA.UI.Font`

An enumeration of fonts the game supports.

| Name | Value | Description |
| --- | --- | --- |
| `ChaletLondon` | 0 | This font is for the standard font. Chalet London 1960 from House Industries will be used when the game language is set to a non-CJK language. The alternative standard font that contains appropriate CJK characters will be used when the game language is set to a CJK language. |
| `HouseScript` | 1 | This font is for the cursive font. Sign Painter House Brush from House Industries will be used when the game language is set to a non-CJK language. The standard font, which is the same as `ChaletLondon`, will be used when the game language is set to a CJK language unless the player have custom font files installed. |
| `RockstarTag` | 2 |  |
| `Leaderboard` | 3 | This font contains only Chevron arrows, some shield symbols, and hexagons. This font style specifies the same font unless the player have custom font files installed. |
| `ChaletComprimeCologne` | 4 | This font is for the condensed font for gamer tags or the distance info on the radar. You should use `ChaletComprimeCologneNotGamerName` if you want to draw strings with condensed font if possible but strings can contain some CJK characters (e.g. localized strings from gxt files). The native functions for text drawing will use the condensed font Chalet Comprim? Cologne 1960 regardness of the game language setting. The natives will draw strings that contain only non-CJK characters without any trouble, but without having custom font files installed, the natives will draw rectangles (a.k.a. tofus) instead of CJK characters because Chalet Comprim? Cologne 1960 doesn't contain any CJK characters. This font style specifies the same font unless the player have custom font files installed. |
| `FixedWidthNumbersStyle` | 5 | This font contains only glyphs of numbers (0 to 9), dollar sign, asterisk, plus sign, colon, semicolon, equals sign, slash, and backslash in ASCII. This font style specifies the same font unless the player have custom font files installed. |
| `ChaletComprimeCologneNotGamerName` | 6 | This font is for the condensed font for generic uses. Consider using `ChaletComprimeCologne` instead when the texts you want to draw only contain only non-CJK characters. The native functions for text drawing will use the condensed font Chalet Comprim? Cologne 1960 when the game language is set to a non-CJK language, but they will use the standard font, which is the same as `ChaletLondon`, when the game language is set to a CJK language (unless the player have custom font files installed). |
| `Pricedown` | 7 | Pricedown will be used when the game language is set to a non-CJK language. The standard font, which is the same as `ChaletLondon`, will be used when the game language is set to a CJK language unless the player have custom font files installed. |
| `Taxi` | 8 | The font for taxi will be used when the game language is set to a non-CJK language. The font does contain invisible glyphs for lower characters. The standard font, which is the same as `ChaletLondon`, will be used when the game language is set to a CJK language unless the player have custom font files installed. |
| `Monospace` | 2 | This font contains upper ASCII characters and some other shapes such as ones for tags. This font style specifies the same font unless the player have custom font files installed. |

## Hud

static class `GTA.UI.Hud`

Methods to manipulate the HUD (heads-up-display) of the game.

### Properties

- `public static CursorSprite CursorSprite { get; set; }`
  - Gets or sets the sprite the cursor should used when drawn
- `public static bool IsRadarVisible { get; set; }`
  - Gets or sets a value indicating whether the radar is visible.
- `public static bool IsVisible { get; set; }`
  - Gets or sets a value indicating whether any HUD components should be rendered.
- `public static int RadarZoom { get; set; }`
  - Sets how far the minimap should be zoomed in.

### Methods

- `public static void HideComponentThisFrame(HudComponent component)`
  - Hides the specified `HudComponent` this frame.
  - `component`: The `HudComponent` to hide.
- `public static bool IsComponentActive(HudComponent component)`
  - Determines whether a given `HudComponent` is active.
  - `component`: The `HudComponent` to check
  - Returns: `true` if the `HudComponent` is active; otherwise, `false`
- `public static void LockRadarDirection(int angle)`
- `public static void LockRadarPosition(Vector2 position)`
- `public static void ShowComponentThisFrame(HudComponent component)`
  - Draws the specified `HudComponent` this frame.
  - `component`: The `HudComponent`
- `public static void ShowCursorThisFrame()`
  - Shows the mouse cursor this frame.
- `public static void UnlockRadarDirection()`
- `public static void UnlockRadarPosition()`

## HudColor

enum `GTA.UI.HudColor`

236 values:

```text
Invalid = -1
PureWhite = 0
White = 1
Black = 2
Gray = 3
GrayLight = 4
GrayDark = 5
Red = 6
RedLight = 7
RedDark = 8
Blue = 9
BlueLight = 10
BlueDark = 11
Yellow = 12
YellowLight = 13
YellowDark = 14
Orange = 15
OrangeLight = 16
OrangeDark = 17
Green = 18
GreenLight = 19
GreenDark = 20
Purple = 21
PurpleLight = 22
PurpleDark = 23
Pink = 24
RadarHealth = 25
RadarArmor = 26
RadarDamage = 27
NetPlayer1 = 28
NetPlayer2 = 29
NetPlayer3 = 30
NetPlayer4 = 31
NetPlayer5 = 32
NetPlayer6 = 33
NetPlayer7 = 34
NetPlayer8 = 35
NetPlayer9 = 36
NetPlayer10 = 37
NetPlayer11 = 38
NetPlayer12 = 39
NetPlayer13 = 40
NetPlayer14 = 41
NetPlayer15 = 42
NetPlayer16 = 43
NetPlayer17 = 44
NetPlayer18 = 45
NetPlayer19 = 46
NetPlayer20 = 47
NetPlayer21 = 48
NetPlayer22 = 49
NetPlayer23 = 50
NetPlayer24 = 51
NetPlayer25 = 52
NetPlayer26 = 53
NetPlayer27 = 54
NetPlayer28 = 55
NetPlayer29 = 56
NetPlayer30 = 57
NetPlayer31 = 58
NetPlayer32 = 59
SimpleBlipDefault = 60
MenuBlue = 61
MenuGrayLight = 62
MenuBlueExtraDark = 63
MenuYellow = 64
MenuYellowDark = 65
MenuGreen = 66
MenuGray = 67
MenuGrayDark = 68
MenuHighlight = 69
MenuStandard = 70
MenuDimmed = 71
MenuExtraDimmed = 72
BriefTitle = 73
MidGrayMP = 74
NetPlayer1Dark = 75
NetPlayer2Dark = 76
NetPlayer3Dark = 77
NetPlayer4Dark = 78
NetPlayer5Dark = 79
NetPlayer6Dark = 80
NetPlayer7Dark = 81
NetPlayer8Dark = 82
NetPlayer9Dark = 83
NetPlayer10Dark = 84
NetPlayer11Dark = 85
NetPlayer12Dark = 86
NetPlayer13Dark = 87
NetPlayer14Dark = 88
NetPlayer15Dark = 89
NetPlayer16Dark = 90
NetPlayer17Dark = 91
NetPlayer18Dark = 92
NetPlayer19Dark = 93
NetPlayer20Dark = 94
NetPlayer21Dark = 95
NetPlayer22Dark = 96
NetPlayer23Dark = 97
NetPlayer24Dark = 98
NetPlayer25Dark = 99
NetPlayer26Dark = 100
NetPlayer27Dark = 101
NetPlayer28Dark = 102
NetPlayer29Dark = 103
NetPlayer30Dark = 104
NetPlayer31Dark = 105
NetPlayer32Dark = 106
Bronze = 107
Silver = 108
Gold = 109
Platinum = 110
Gang1 = 111
Gang2 = 112
Gang3 = 113
Gang4 = 114
SameCrew = 115
Freemode = 116
PauseBG = 117
Friendly = 118
Enemy = 119
Location = 120
Pickup = 121
PauseSingleplayer = 122
FreemodeDark = 123
InactiveMission = 124
Damage = 125
PinkLight = 126
PMMitemHighlight = 127
ScriptVariable = 128
Yoga = 129
Tennis = 130
Golf = 131
ShootingRange = 132
FlightSchool = 133
NorthBlue = 134
SocialClub = 135
PlatformBlue = 136
PlatformGreen = 137
PlatformGray = 138
FacebookBlue = 139
IngameBG = 140
Darts = 141
Waypoint = 142
Michael = 143
Franklin = 144
Trevor = 145
GolfP1 = 146
GolfP2 = 147
GolfP3 = 148
GolfP4 = 149
WaypointLight = 150
WaypointDark = 151
PanelLight = 152
MichaelDark = 153
FranklinDark = 154
TrevorDark = 155
ObjectiveRoute = 156
PauseMapTint = 157
PauseDeselect = 158
PMWeaponsPurchasable = 159
PMWeaponsLocked = 160
EndScreenBG = 161
Chop = 162
PauseMapTintHalf = 163
NorthBlueOfficial = 164
ScriptVariable2 = 165
H = 166
HDark = 167
T = 168
TDark = 169
HShard = 170
ControllerMichael = 171
ControllerFranklin = 172
ControllerTrevor = 173
ControllerChop = 174
VideoEditorVideo = 175
VideoEditorAudio = 176
VideoEditorText = 177
HBBlue = 178
HBYellow = 179
VideoEditorScore = 180
VideoEditorAudioFadeout = 181
VideoEditorTextFadeout = 182
VideoEditorScoreFadeout = 183
HeistBackground = 184
VideoEditorAmbient = 185
VideoEditorAmbientFadeout = 186
VideoEditorAmbientDark = 187
VideoEditorAmbientLight = 188
VideoEditorAmbientMid = 189
LowFlow = 190
LowFlowDark = 191
G1 = 192
G2 = 193
G3 = 194
G4 = 195
G5 = 196
G6 = 197
G7 = 198
G8 = 199
G9 = 200
G10 = 201
G11 = 202
G12 = 203
G13 = 204
G14 = 205
G15 = 206
Adversary = 207
DegenRed = 208
DegenYellow = 209
DegenGreen = 210
DegenCyan = 211
DegenBlue = 212
DegenMagenta = 213
Stunt1 = 214
Stunt2 = 215
SpecialRaceSeries = 216
SpecialRaceSeriesDark = 217
CS = 218
CSDark = 219
TechGreen = 220
TechGreenDark = 221
TechRed = 222
TechGreenVeryDark = 223
Placeholder01 = 224
Placeholder02 = 225
Placeholder03 = 226
Placeholder04 = 227
Placeholder05 = 228
Placeholder06 = 229
Placeholder07 = 230
Placeholder08 = 231
Placeholder09 = 232
Placeholder10 = 233
JunkEnergy = 234
```

## HudColors

static class `GTA.UI.HudColors`

### Methods

- `public static Color GetColor(HudColor hudColor)`
- `public static void Replace(HudColor target, HudColor source)`
- `public static void SetColor(HudColor destination, byte r, byte g, byte b, byte a)`
- `public static void SetColor(HudColor destination, Color color)`

## HudComponent

enum `GTA.UI.HudComponent`

An enumeration of all possible component of the HUD.

| Name | Value |
| --- | --- |
| `WantedStars` | 1 |
| `WeaponIcon` | 2 |
| `Cash` | 3 |
| `MpCash` | 4 |
| `MpMessage` | 5 |
| `VehicleName` | 6 |
| `AreaName` | 7 |
| `Unused` | 8 |
| `StreetName` | 9 |
| `HelpText` | 10 |
| `FloatingHelpText1` | 11 |
| `FloatingHelpText2` | 12 |
| `CashChange` | 13 |
| `Reticle` | 14 |
| `SubtitleText` | 15 |
| `RadioStationsWheel` | 16 |
| `Saving` | 17 |
| `GamingStreamUnusde` | 18 |
| `WeaponWheel` | 19 |
| `WeaponWheelStats` | 20 |
| `DrugsPurse01` | 21 |
| `DrugsPurse02` | 22 |
| `DrugsPurse03` | 23 |
| `DrugsPurse04` | 24 |
| `MpTagCashFromBank` | 25 |
| `MpTagPackages` | 26 |
| `MpTagCuffKeys` | 27 |
| `MpTagDownloadData` | 28 |
| `MpTagIfPedFollowing` | 29 |
| `MpTagKeyCard` | 30 |
| `MpTagRandomObject` | 31 |
| `MpTagRemoteControl` | 32 |
| `MpTagCashFromSafe` | 33 |
| `MpTagWeaponsPackage` | 34 |
| `MpTagKeys` | 35 |
| `MpVehicle` | 36 |
| `MpVehicleHeli` | 37 |
| `MpVehiclePlane` | 38 |
| `PlayerSwitchAlert` | 39 |
| `MpRankBar` | 40 |
| `DirectorMode` | 41 |
| `ReplayController` | 42 |
| `ReplayMouse` | 43 |
| `ReplayHeader` | 44 |
| `ReplayOptions` | 45 |
| `ReplayHelpText` | 46 |
| `ReplayMiscText` | 47 |
| `ReplayTopLine` | 48 |
| `ReplayBottomLine` | 49 |
| `ReplayLeftBar` | 50 |
| `ReplayTimer` | 51 |

## IElement

interface `GTA.UI.IElement`

### Properties

- `public bool Centered { get; set; }`
  - Gets or sets a value indicating whether this `IElement` should be positioned based on its center or top left corner
- `public Color Color { get; set; }`
  - Gets or sets the color of this `IElement`.
- `public bool Enabled { get; set; }`
  - Gets or sets a value indicating whether this `IElement` will be drawn.
- `public PointF Position { get; set; }`
  - Gets or sets the position of this `IElement`.

### Methods

- `public void Draw()`
  - Draws this `IElement` this frame.
- `public void Draw(SizeF offset)`
  - Draws this `IElement` this frame at the specified offset.
  - `offset`: The offset to shift the draw position of this `IElement` using a 1280*720 pixel base.
- `public void ScaledDraw()`
  - Draws this `IElement` this frame using the width returned in `ScaledWidth`.
- `public void ScaledDraw(SizeF offset)`
  - Draws this `IElement` this frame at the specified offset using the width returned in `ScaledWidth`.
  - `offset`: The offset to shift the draw position of this `IElement` using a `ScaledWidth`*720 pixel base.

## ISpriteElement

interface `GTA.UI.ISpriteElement` : `IElement`

### Properties

- `public float Rotation { get; set; }`
  - Gets or sets the rotation to draw thie `ISpriteElement`.
- `public SizeF Size { get; set; }`
  - Gets or sets the size to draw the `ISpriteElement`

## IWorldDrawableElement

interface `GTA.UI.IWorldDrawableElement` : `IElement`

### Methods

- `public void WorldDraw(Vector3 position, SizeF offset)`
- `public void WorldDraw(Vector3 position)`
- `public void WorldScaledDraw(Vector3 position, SizeF offset)`
- `public void WorldScaledDraw(Vector3 position)`

## LoadingPrompt

static class `GTA.UI.LoadingPrompt`

Methods to manage the display of a loading spinner prompt.

### Properties

- `public static bool IsActive { get; }`
  - Gets a value indicating whether the Loading Prompt is currently being displayed

### Methods

- `public static void Hide()`
  - Remove the loading prompt at the bottom right of the screen
- `public static void Show(string loadingText = null, LoadingSpinnerType spinnerType = 5)`
  - Creates a loading prompt at the bottom right of the screen with the given text and spinner type
  - `loadingText`: The text to display next to the spinner
  - `spinnerType`: The style of spinner to draw

## LoadingSpinnerType

enum `GTA.UI.LoadingSpinnerType`

An enumeration of possible loading spinner styles.

| Name | Value |
| --- | --- |
| `Clockwise1` | 1 |
| `Clockwise2` | 2 |
| `Clockwise3` | 3 |
| `SocialClubSaving` | 4 |
| `RegularClockwise` | 5 |

## Notification

static class `GTA.UI.Notification`

Methods to manage the display of notifications above the minimap.

### Methods

- `public static void Hide(int handle)`
  - Hides a `Notification` instantly.
  - `handle`: The handle of the `Notification` to hide.
- `public static FeedPost PostAward(string message, TextureAsset texAsset, int xp, HudColor awardColor, string title = null)`
- `public static FeedPost PostMessageText(string message, TextureAsset texAsset, bool isImportant, FeedTextIcon icon, string characterName, string subtitle = null)`
- `public static FeedPost PostTicker(string message, bool isImportant, bool cacheMessage = true)`
- `public static FeedPost PostTickerForced(string message, bool isImportant, bool cacheMessage = true)`
- `public static FeedPost PostTickerWithTokens(string message, bool isImportant, bool cacheMessage = true)`
- `public static FeedPost PostUnlock(string message, string title, FeedUnlockIcon iconType)`
- `public static FeedPost PostUnlockTitleUpdate(string message, string title, FeedUnlockIcon iconType, bool isImportant = true)`
- `public static FeedPost PostUnlockTitleUpdateWithColor(string message, string title, FeedUnlockIcon iconType, bool isImportant = true, HudColor titleColor = 0, bool titleIsLiteral = true)`
- `public static FeedPost PostVersusTitleUpdate(TextureAsset char1TexAsset, int val1, TextureAsset char2TexAsset, int val2, HudColor customColor1 = -1, HudColor customColor2 = -1)`
- `public static int Show(NotificationIcon icon, string sender, string subject, string message, bool fadeIn = false, bool blinking = false)`
  - **Obsolete.** Notification.Show is obsolete since it may fail to draw a texture icon for a text message.Use Notification.PostMessageText instead.
  - Creates a more advanced (SMS-alike) `Notification` above the minimap showing a sender icon, subject and the message.
  - `icon`: The notification icon.
  - `sender`: The sender name.
  - `subject`: The subject line.
  - `message`: The message itself.
  - `fadeIn`: If `true` the message will fade in.
  - `blinking`: if set to `true` the notification will blink.
  - Returns: The handle of the `Notification` which can be used to hide it using `Hide`.
- `public static int Show(string message, bool blinking = false)`
  - **Obsolete.** Use Notification.PostTicker instead.
  - Creates a `Notification` above the minimap with the given message.
  - `message`: The message in the notification.
  - `blinking`: if set to `true` the notification will blink.
  - Returns: The handle of the `Notification` which can be used to hide it using `Hide`.

## NotificationIcon

enum `GTA.UI.NotificationIcon`

167 values:

```text
Abigail = 0
AllPlayersConf = 1
Amanda = 2
Ammunation = 3
Andreas = 4
Antonia = 5
Arthur = 6
Ashley = 7
BankBol = 8
BankFleeca = 9
BankMaze = 10
Barry = 11
Beverly = 12
Bikesite = 13
BlankEntry = 14
Blimp = 15
Blocked = 16
Boatsite = 17
BrokenDownGirl = 18
Bugstars = 19
Call911 = 20
Carsite = 21
Carsite2 = 22
Castro = 23
ChatCall = 24
Chef = 25
Cheng = 26
Chengsr = 27
Chop = 28
Cris = 29
Dave = 30
Default = 31
Denise = 32
DetonateBomb = 33
DetonatePhone = 34
Devin = 35
DialASub = 36
Dom = 37
DomesticGirl = 38
Dreyfuss = 39
DrFriedlander = 40
Epsilon = 41
EstateAgent = 42
Facebook = 43
FilmNoir = 44
Floyd = 45
Franklin = 46
FrankTrevConf = 47
Gaymilitary = 48
Hao = 49
HitcherGirl = 50
HumanDefault = 51
Hunter = 52
Jimmy = 53
JimmyBoston = 54
Joe = 55
Josef = 56
Josh = 57
Lamar = 58
Lazlow = 59
Lester = 60
LesterDeathwish = 61
LesFrankConf = 62
LesMikeConf = 63
Lifeinvader = 64
LsCustoms = 65
LsTouristBoard = 66
Manuel = 67
Marnie = 68
Martin = 69
MaryAnn = 70
Maude = 71
Mechanic = 72
Michael = 73
MikeFrankConf = 74
MikeTrevConf = 75
Milsite = 76
Minotaur = 77
Molly = 78
MpArmyContact = 79
MpBikerBoss = 80
MpBikerMechanic = 81
MpBrucie = 82
MpDetonatePhone = 83
MpFamBoss = 84
MpFIBContact = 85
MpFmContact = 86
MpGerald = 87
MpJulio = 88
MpMechanic = 89
MpMerryweather = 90
MpMexBoss = 91
MpMexDocks = 92
MpMexLt = 93
MpMorsMutual = 94
MpProfBoss = 95
MpRayLavoy = 96
MpRoberto = 97
MpSnitch = 98
MpStretch = 99
MpStripclubPr = 100
MrsThornhill = 101
Multiplayer = 102
Nigel = 103
Omega = 104
Oneil = 105
Ortega = 106
Oscar = 107
Patricia = 108
PegasusDelivery = 109
Planesite = 110
PropertyArmsTrafficking = 111
PropertyBarAirport = 112
PropertyBarBayview = 113
PropertyBarCafeRojo = 114
PropertyBarCockotoos = 115
PropertyBarEclipse = 116
PropertyBarFes = 117
PropertyBarHenHouse = 118
PropertyBarHiMen = 119
PropertyBarHookies = 120
PropertyBarIrish = 121
PropertyBarLesBianco = 122
PropertyBarMirrorPark = 123
PropertyBarPitchers = 124
PropertyBarSingletons = 125
PropertyBarTequilala = 126
PropertyBarUnbranded = 127
PropertyCarModShop = 128
PropertyCarScrapYard = 129
PropertyCinemaDowntown = 130
PropertyCinemaMorningwood = 131
PropertyCinemaVinewood = 132
PropertyGolfClub = 133
PropertyPlaneScrapYard = 134
PropertySonarCollections = 135
PropertyTaxiLot = 136
PropertyTowingImpound = 137
PropertyWeedShop = 138
Ron = 139
Saeeda = 140
Sasquatch = 141
Simeon = 142
SocialClub = 143
Solomon = 144
Steve = 145
SteveMikeConf = 146
SteveTrevConf = 147
Stretch = 148
StripperChastity = 149
StripperCheetah = 150
StripperFufu = 151
StripperInfernus = 152
StripperJuliet = 153
StripperNikki = 154
StripperPeach = 155
StripperSapphire = 156
Tanisha = 157
Taxi = 158
TaxiLiz = 159
TennisCoach = 160
TowTonya = 161
Tracey = 162
Trevor = 163
Wade = 164
YouTube = 165
CreatorPortraits = 166
```

## Screen

static class `GTA.UI.Screen`

Methods to handle UI actions that affect the whole screen.

### Properties

- `public static bool AreScreenKillEffectsEnabled { get; }`
  - Gets a value indicating whether screen kill effects are enabled.
- `public static float AspectRatio { get; }`
  - Gets the current screen aspect ratio
- `public static bool IsFadedIn { get; }`
  - Gets a value indicating whether the screen is faded in.
- `public static bool IsFadedOut { get; }`
  - Gets a value indicating whether the screen is faded out.
- `public static bool IsFadingIn { get; }`
  - Gets a value indicating whether the screen is fading in.
- `public static bool IsFadingOut { get; }`
  - Gets a value indicating whether the screen is fading out.
- `public static bool IsHelpTextDisplayed { get; }`
  - Gets a value indicating whether a help message is currently displayed.
- `public static Size MainWindowResolution { get; }`
- `public static float PhysicalAspectRatio { get; }`
- `public static Size Resolution { get; }`
  - Gets the actual screen resolution the game is being rendered at
- `public static int SafeZoneSizeProfile { get; }`
- `public static float ScaledWidth { get; }`
  - Gets the screen width scaled against a 720pixel height base.

### Methods

- `public static void ClearHelpText()`
  - Clears a help message immediately.
- `public static void FadeIn(int time)`
  - Fades the screen in over a specific time, useful for transitioning
  - `time`: The time for the fade in to take
- `public static void FadeOut(int time)`
  - Fades the screen out over a specific time, useful for transitioning
  - `time`: The time for the fade out to take
- `public static bool IsEffectActive(ScreenEffect effectName)`
  - Gets a value indicating whether the specific screen effect is running.
  - `effectName`: The `ScreenEffect` to check.
  - Returns: `true` if the screen effect is active; otherwise, `false`.
- `public static bool IsSphereVisible(Vector3 position, float radius)`
- `public static void ShowHelpText(string helpText, int duration = -1, bool beep = true, bool looped = false)`
  - Displays a help message in the top corner of the screen infinitely.
  - `helpText`: The text to display.
  - `duration`: The duration how long the help text will be displayed in real time (not in game time which is influenced by game speed). if the value is not positive, the help text will be displayed for 7.5 seconds.
  - `beep`: Whether to play beeping sound.
  - `looped`: Whether to show this help message forever.
- `public static void ShowHelpTextThisFrame(string helpText, bool beep)`
  - Displays a help message in the top corner of the screen this frame. Specify whether beeping sound plays.
  - `helpText`: The text to display.
  - `beep`: Whether to play beeping sound
- `public static void ShowHelpTextThisFrame(string helpText)`
  - Displays a help message in the top corner of the screen this frame. Beeping sound will be played.
  - `helpText`: The text to display.
- `public static void ShowSubtitle(string message, int duration, bool drawImmediately = true)`
  - Shows a subtitle at the bottom of the screen for a given time
  - `message`: The message to display.
  - `duration`: The duration to display the subtitle in milliseconds.
  - `drawImmediately`: Whether to draw immediately or draw after all the queued subtitles have finished.
- `public static void ShowSubtitle(string message, int duration = 2500)`
  - Shows a subtitle at the bottom of the screen for a given time
  - `message`: The message to display.
  - `duration`: The duration to display the subtitle in milliseconds.
- `public static void StartEffect(ScreenEffect effectName, int duration = 0, bool looped = false)`
  - Starts applying the specified effect to the screen.
  - `effectName`: The `ScreenEffect` to start playing.
  - `duration`: The duration of the effect in milliseconds or zero to use the default length.
  - `looped`: If `true` the effect won't stop until `StopEffect` is called.
- `public static void StopEffect(ScreenEffect effectName)`
  - Stops applying the specified effect to the screen.
  - `effectName`: The `ScreenEffect` to stop playing.
- `public static void StopEffects()`
  - Stops all currently running effects.
- `public static PointF WorldToScreen(Vector3 position, bool scaleWidth = false)`
  - Translates a point in WorldSpace to its given Coordinates on the `Screen`
  - `position`: The position in the World.
  - `scaleWidth`: if set to `true` Returns the screen position scaled by `ScaledWidth`; otherwise, returns the screen position scaled by `Width`.

### Fields

- `public const float Height = 720`
  - The base height of the screen used for all UI Calculations
- `public const float Width = 1280`
  - The base width of the screen used for all UI Calculations, unless ScaledDraw is used

## ScreenEffect

enum `GTA.UI.ScreenEffect`

An enumeration of possible screen effects.

81 values:

```text
SwitchHudIn = 0
SwitchHudOut = 1
FocusIn = 2
FocusOut = 3
MinigameEndNeutral = 4
MinigameEndTrevor = 5
MinigameEndFranklin = 6
MinigameEndMichael = 7
MinigameTransitionOut = 8
MinigameTransitionIn = 9
SwitchShortNeutralIn = 10
SwitchShortFranklinIn = 11
SwitchShortTrevorIn = 12
SwitchShortMichaelIn = 13
SwitchOpenMichaelIn = 14
SwitchOpenFranklinIn = 15
SwitchOpenTrevorIn = 16
SwitchHudMichaelOut = 17
SwitchHudFranklinOut = 18
SwitchHudTrevorOut = 19
SwitchShortFranklinMid = 20
SwitchShortMichaelMid = 21
SwitchShortTrevorMid = 22
DeathFailOut = 23
CamPushInNeutral = 24
CamPushInFranklin = 25
CamPushInMichael = 26
CamPushInTrevor = 27
SwitchSceneFranklin = 28
SwitchSceneTrevor = 29
SwitchSceneMichael = 30
SwitchSceneNeutral = 31
MpCelebWin = 32
MpCelebWinOut = 33
MpCelebLose = 34
MpCelebLoseOut = 35
DeathFailNeutralIn = 36
DeathFailMpDark = 37
DeathFailMpIn = 38
MpCelebPreloadFade = 39
PeyoteEndOut = 40
PeyoteEndIn = 41
PeyoteIn = 42
PeyoteOut = 43
MpRaceCrash = 44
SuccessFranklin = 45
SuccessTrevor = 46
SuccessMichael = 47
DrugsMichaelAliensFightIn = 48
DrugsMichaelAliensFight = 49
DrugsMichaelAliensFightOut = 50
DrugsTrevorClownsFightIn = 51
DrugsTrevorClownsFight = 52
DrugsTrevorClownsFightOut = 53
HeistCelebPass = 54
HeistCelebPassBw = 55
HeistCelebEnd = 56
HeistCelebToast = 57
MenuMgHeistIn = 58
MenuMgTournamentIn = 59
MenuMgSelectionIn = 60
ChopVision = 61
DmtFlightIntro = 62
DmtFlight = 63
DrugsDrivingIn = 64
DrugsDrivingOut = 65
SwitchOpenNeutralFib5 = 66
HeistLocate = 67
MpJobLoad = 68
RaceTurbo = 69
MpIntroLogo = 70
HeistTripSkipFade = 71
MenuMgHeistOut = 72
MpCoronaSwitch = 73
MenuMgSelectionTint = 74
SuccessNeutral = 75
ExplosionJosh3 = 76
SniperOverlay = 77
RampageOut = 78
Rampage = 79
DontTazemeBro = 80
```

## Sprite

class `GTA.UI.Sprite` : `ISpriteElement`, `IElement`, `IWorldDrawableElement`, `IDisposable`

A sprite element using a built-in texture.

### Constructors

- `public Sprite(string textureDict, string textureName, SizeF size, PointF position, Color color, float rotation, bool centered)`
  - Initializes a new instance of the `Sprite` class used for drawing in game textures on the screen.
  - `textureDict`: The Texture dictionary where the `Sprite` is stored (the *.ytd file).
  - `textureName`: Name of the `Sprite` inside the Texture dictionary.
  - `size`: Set the `Size` of the `Sprite`.
  - `position`: Set the `Position` on screen where to draw the `Sprite`.
  - `color`: Set the `Color` used to draw the `Sprite`.
  - `rotation`: Set the rotation to draw the sprite, measured in degrees, see also `Rotation`.
  - `centered`: Position the `Sprite` based on its center instead of top left corner, see also `Centered`.
- `public Sprite(string textureDict, string textureName, SizeF size, PointF position, Color color, float rotation)`
  - Initializes a new instance of the `Sprite` class used for drawing in game textures on the screen.
  - `textureDict`: The Texture dictionary where the `Sprite` is stored (the *.ytd file).
  - `textureName`: Name of the `Sprite` inside the Texture dictionary.
  - `size`: Set the `Size` of the `Sprite`.
  - `position`: Set the `Position` on screen where to draw the `Sprite`.
  - `color`: Set the `Color` used to draw the `Sprite`.
  - `rotation`: Set the rotation to draw the sprite, measured in degrees, see also `Rotation`.
- `public Sprite(string textureDict, string textureName, SizeF size, PointF position, Color color)`
  - Initializes a new instance of the `Sprite` class used for drawing in game textures on the screen.
  - `textureDict`: The Texture dictionary where the `Sprite` is stored (the *.ytd file).
  - `textureName`: Name of the `Sprite` inside the Texture dictionary.
  - `size`: Set the `Size` of the `Sprite`.
  - `position`: Set the `Position` on screen where to draw the `Sprite`.
  - `color`: Set the `Color` used to draw the `Sprite`.
- `public Sprite(string textureDict, string textureName, SizeF size, PointF position)`
  - Initializes a new instance of the `Sprite` class used for drawing in game textures on the screen.
  - `textureDict`: The Texture dictionary where the `Sprite` is stored (the *.ytd file).
  - `textureName`: Name of the `Sprite` inside the Texture dictionary.
  - `size`: Set the `Size` of the `Sprite`.
  - `position`: Set the `Position` on screen where to draw the `Sprite`.

### Properties

- `public bool Centered { get; set; }`
  - Gets or sets a value indicating whether this `Sprite` should be positioned based on its center or top left corner
- `public Color Color { get; set; }`
  - Gets or sets the color of this `Sprite`.
- `public bool Enabled { get; set; }`
  - Gets or sets a value indicating whether this `Sprite` will be drawn.
- `public PointF Position { get; set; }`
  - Gets or sets the position of this `Sprite`.
- `public float Rotation { get; set; }`
  - Gets or sets the rotation to draw thie `Sprite`.
- `public SizeF Size { get; set; }`
  - Gets or sets the size to draw the `Sprite`
- `public RectangleF TextureCoordinates { get; set; }`

### Methods

- `public void Dispose()`
- `protected virtual void Dispose(bool disposing)`
- `public virtual void Draw()`
  - Draws this `Sprite`.
- `public virtual void Draw(SizeF offset)`
  - Draws the `Sprite` at the specified offset.
  - `offset`: The offset.
- `public virtual void ScaledDraw()`
  - Draws this `Sprite` using the width returned in `ScaledWidth`.
- `public virtual void ScaledDraw(SizeF offset)`
  - Draws the `Sprite` at the specified offset using the width returned in `ScaledWidth`.
  - `offset`: The offset.
- `public virtual void WorldDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldDraw(Vector3 position)`
- `public virtual void WorldScaledDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldScaledDraw(Vector3 position)`

## TextElement

class `GTA.UI.TextElement` : `IWorldDrawableElement`, `IElement`

### Constructors

- `public TextElement(string caption, PointF position, float scale, Color color, Font font, Alignment alignment, bool shadow, bool outline, float wrapWidth)`
  - Initializes a new instance of the `TextElement` class used for drawing text on the screen.
  - `caption`: The `TextElement` to draw.
  - `position`: Set the `Position` on screen where to draw the `TextElement`.
  - `scale`: Sets a `Scale` used to increase of decrease the size of the `TextElement`, for no scaling use 1.0f.
  - `color`: Set the `Color` used to draw the `TextElement`.
  - `font`: Sets the `Font` used when drawing the text.
  - `alignment`: Sets the `Alignment` used when drawing the text, `Left`,`Center` or `Right`.
  - `shadow`: Sets whether or not to draw the `TextElement` with a `Shadow` effect.
  - `outline`: Sets whether or not to draw the `TextElement` with an `Outline` around the letters.
  - `wrapWidth`: Sets how many horizontal pixel to draw before wrapping the `TextElement` on the next line down.
- `public TextElement(string caption, PointF position, float scale, Color color, Font font, Alignment alignment, bool shadow, bool outline)`
  - Initializes a new instance of the `TextElement` class used for drawing text on the screen.
  - `caption`: The `TextElement` to draw.
  - `position`: Set the `Position` on screen where to draw the `TextElement`.
  - `scale`: Sets a `Scale` used to increase of decrease the size of the `TextElement`, for no scaling use 1.0f.
  - `color`: Set the `Color` used to draw the `TextElement`.
  - `font`: Sets the `Font` used when drawing the text.
  - `alignment`: Sets the `Alignment` used when drawing the text, `Left`,`Center` or `Right`.
  - `shadow`: Sets whether or not to draw the `TextElement` with a `Shadow` effect.
  - `outline`: Sets whether or not to draw the `TextElement` with an `Outline` around the letters.
- `public TextElement(string caption, PointF position, float scale, Color color, Font font, Alignment alignment)`
  - Initializes a new instance of the `TextElement` class used for drawing text on the screen.
  - `caption`: The `TextElement` to draw.
  - `position`: Set the `Position` on screen where to draw the `TextElement`.
  - `scale`: Sets a `Scale` used to increase of decrease the size of the `TextElement`, for no scaling use 1.0f.
  - `color`: Set the `Color` used to draw the `TextElement`.
  - `font`: Sets the `Font` used when drawing the text.
  - `alignment`: Sets the `Alignment` used when drawing the text, `Left`,`Center` or `Right`.
- `public TextElement(string caption, PointF position, float scale, Color color, Font font)`
  - Initializes a new instance of the `TextElement` class used for drawing text on the screen.
  - `caption`: The `TextElement` to draw.
  - `position`: Set the `Position` on screen where to draw the `TextElement`.
  - `scale`: Sets a `Scale` used to increase of decrease the size of the `TextElement`, for no scaling use 1.0f.
  - `color`: Set the `Color` used to draw the `TextElement`.
  - `font`: Sets the `Font` used when drawing the text.
- `public TextElement(string caption, PointF position, float scale, Color color)`
  - Initializes a new instance of the `TextElement` class used for drawing text on the screen.
  - `caption`: The `TextElement` to draw.
  - `position`: Set the `Position` on screen where to draw the `TextElement`.
  - `scale`: Sets a `Scale` used to increase of decrease the size of the `TextElement`, for no scaling use 1.0f.
  - `color`: Set the `Color` used to draw the `TextElement`.
- `public TextElement(string caption, PointF position, float scale)`
  - Initializes a new instance of the `TextElement` class used for drawing text on the screen.
  - `caption`: The `TextElement` to draw.
  - `position`: Set the `Position` on screen where to draw the `TextElement`.
  - `scale`: Sets a `Scale` used to increase of decrease the size of the `TextElement`, for no scaling use 1.0f.

### Properties

- `public Alignment Alignment { get; set; }`
  - Gets or sets the alignment of this `TextElement`.
- `public string Caption { get; set; }`
  - Gets or sets the text to draw in this `TextElement`.
- `public bool Centered { get; set; }`
  - **Obsolete.** `TextElement.Centered` is obsolete because it is redundant and setting the property to false is confusing. Use `TextElement.Alignment` instead.
  - Gets or sets a value indicating whether the alignment of this `TextElement` is centered. See `Alignment`
- `public Color Color { get; set; }`
  - Gets or sets the color of this `TextElement`.
- `public bool Enabled { get; set; }`
  - Gets or sets a value indicating whether this `TextElement` will be drawn.
- `public Font Font { get; set; }`
  - Gets or sets the font of this `TextElement`.
- `public int LineCount { get; }`
- `public bool Outline { get; set; }`
  - Gets or sets a value indicating whether this `TextElement` is drawn with an outline.
- `public PointF Position { get; set; }`
  - Gets or sets the position of this `TextElement`.
- `public float Scale { get; set; }`
  - Gets or sets the scale of this `TextElement`.
- `public int ScaledLineCount { get; }`
- `public float ScaledWidth { get; }`
  - Measures how many pixels in the horizontal axis this `TextElement` will use when drawn against a `ScaledWidth` pixel base
- `public bool Shadow { get; set; }`
  - Gets or sets a value indicating whether this `TextElement` is drawn with a shadow effect.
- `public float Width { get; }`
  - Measures how many pixels in the horizontal axis this `TextElement` will use when drawn against a 1280 pixel base
- `public float WrapWidth { get; set; }`
  - Gets or sets the maximum size of the `TextElement` before it wraps to a new line.

### Methods

- `public virtual void Draw()`
  - Draws the `TextElement` this frame.
- `public virtual void Draw(SizeF offset)`
  - Draws the `TextElement` this frame at the specified offset.
  - `offset`: The offset to shift the draw position of this `TextElement` using a 1280*720 pixel base.
- `protected virtual void Finalize()`
- `public virtual void ScaledDraw()`
  - Draws the `TextElement` this frame using the width returned in `ScaledWidth`.
- `public virtual void ScaledDraw(SizeF offset)`
  - Draws the `TextElement` this frame at the specified offset using the width returned in `ScaledWidth`.
  - `offset`: The offset to shift the draw position of this `TextElement` using a `ScaledWidth`*720 pixel base.
- `public virtual void WorldDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldDraw(Vector3 position)`
- `public virtual void WorldScaledDraw(Vector3 position, SizeF offset)`
- `public virtual void WorldScaledDraw(Vector3 position)`
- `public static float GetScaledStringWidth(string text, Font font = 0, float scale = 1)`
  - Measures how many pixels in the horizontal axis the string will use when drawn
  - `text`: The string of text to measure.
  - `font`: The `Font` of the textu to measure.
  - `scale`: Sets a sclae value for increasing or decreasing the size of the text, default value 1.0f - no scaling.
  - Returns: The amount of pixels scaled by the pixel width base return in `ScaledWidth`
- `public static float GetStringWidth(string text, Font font = 0, float scale = 1)`
  - Measures how many pixels in the horizontal axis the string will use when drawn
  - `text`: The string of text to measure.
  - `font`: The `Font` of the textu to measure.
  - `scale`: Sets a sclae value for increasing or decreasing the size of the text, default value 1.0f - no scaling.
  - Returns: The amount of pixels scaled on a 1280 pixel width base

