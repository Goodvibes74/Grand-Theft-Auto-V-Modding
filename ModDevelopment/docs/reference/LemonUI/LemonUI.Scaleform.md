# LemonUI.Scaleform (LemonUI for SHVDN v3)

[Back to the LemonUI for SHVDN v3 index](README.md)

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

## BaseScaleform

abstract class `LemonUI.Scaleform.BaseScaleform` : `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

Represents a generic Scaleform object.

### Constructors

- `public BaseScaleform(string sc)`
  - Creates a new Scaleform class with the specified Scaleform object name.
  - `sc`: The Scalform object.

### Properties

- `public int Handle { get; }`
  - The ID or Handle of the Scaleform.
- `public bool IsLoaded { get; }`
  - If the Scaleform is loaded or not.
- `public string Name { get; }`
  - The Name of the Scaleform.
- `public bool Visible { get; set; }`
  - If the Scaleform should be visible or not.

### Methods

- `public void CallFunction(string function, params object[] parameters)`
  - Calls a Scaleform function.
  - `function`: The name of the function to call.
  - `parameters`: The parameters to pass.
- `public T CallFunction<T>(string function, params object[] parameters)`
  - Calls a scaleform function and gets it's return value as soon as is available.
  - `function`: The function to call.
  - `parameters`: The parameters to call the function with.
  - Returns: The value returned by the function.
- `public int CallFunctionReturn(string function, params object[] parameters)`
  - Calls a Scaleform function with a return value.
  - `function`: The name of the function to call.
  - `parameters`: The parameters to pass.
- `public void Dispose()`
  - Marks the scaleform as no longer needed.
- `public virtual void Draw()`
  - Draws the scaleform full screen.
- `public virtual void DrawFullScreen()`
  - Draws the scaleform full screen.
- `public T GetValue<T>(int id)`
  - Gets a specific value.
  - `id`: The Identifier of the value.
  - Returns: The value returned by the native.
- `public bool IsValueReady(int id)`
  - Checks if the specified Scaleform Return Value is ready to be fetched.
  - `id`: The Identifier of the Value.
  - Returns: `true` if the value is ready, `false` otherwise.
- `public virtual void Process()`
  - Draws the scaleform full screen.
- `public abstract void Update()`
  - Updates the parameters of the Scaleform.

### Fields

- `protected Scaleform scaleform`
  - **Obsolete.** Please use the Handle or Name properties and call the methods manually.
  - The ID of the scaleform.

## BigMessage

class `LemonUI.Scaleform.BigMessage` : `BaseScaleform`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

A customizable big message.

### Constructors

- `public BigMessage(string title, MessageType type)`
  - Creates a custom message with the specified title.
  - `title`: The title to use.
  - `type`: The type of message.
- `public BigMessage(string title, int colorText, int colorBackground)`
  - Creates a standard customizable message with a specific title and custom colors.
  - `title`: The title to use.
  - `colorText`: The color of the text.
  - `colorBackground`: The color of the background.
- `public BigMessage(string title, int colorText)`
  - Creates a standard customizable message with a title and a custom text color.
  - `title`: The title to use.
  - `colorText`: The color of the text.
- `public BigMessage(string title, string weapon, WeaponHash hash)`
  - Creates a Weapon Purchase message with a custom text and weapons.
  - `title`: The title to use.
  - `weapon`: The name of the Weapon.
  - `hash`: The hash of the Weapon image.
- `public BigMessage(string title, string message, MessageType type)`
  - Creates a message with the specified type, title and message.
  - `title`: The title to use.
  - `message`: The message to show.
  - `type`: The type of message.
- `public BigMessage(string title, string message, string rank, WeaponHash weapon, int colorText, int colorBackground, MessageType type)`
  - Creates a message with all of the selected information.
  - `title`: The title to use.
  - `message`: The message to show.
  - `rank`: The Rank on Cops and Crooks.
  - `weapon`: The hash of the Weapon image.
  - `colorText`: The color of the text.
  - `colorBackground`: The color of the background.
  - `type`: The type of message.
- `public BigMessage(string title, string message, string weapon, WeaponHash hash)`
  - Creates a Weapon Purchase message with a custom text and weapons.
  - `title`: The title to use.
  - `message`: The message to show.
  - `weapon`: The name of the Weapon.
  - `hash`: The hash of the Weapon image.
- `public BigMessage(string title, string message, string rank, uint weapon, int colorText, int colorBackground, MessageType type)`
  - Creates a message with all of the selected information.
  - `title`: The title to use.
  - `message`: The message to show.
  - `rank`: The Rank on Cops and Crooks.
  - `weapon`: The hash of the Weapon image.
  - `colorText`: The color of the text.
  - `colorBackground`: The color of the background.
  - `type`: The type of message.
- `public BigMessage(string title, string message, string rank)`
  - Creates a Cops and Crooks message type.
  - `title`: The title to use.
  - `message`: The message to show.
  - `rank`: Text to show in the Rank space.
- `public BigMessage(string title, string message)`
  - Creates a standard customizable message with a title and message.
  - `title`: The title to use.
  - `message`: The message to show.
- `public BigMessage(string title)`
  - Creates a standard customizable message with just a title.
  - `title`: The title to use.

### Properties

- `public int BackgroundColor { get; set; }`
  - The color of the background in the Customizable message type.
- `public string Message { get; set; }`
  - The subtitle or description of the message.
- `public string Rank { get; set; }`
  - The Rank when the mode is set to Cops and Crooks.
- `public int TextColor { get; set; }`
  - The color of the text. Only used on the Customizable message type.
- `public string Title { get; set; }`
  - The title of the message.
- `public MessageType Type { get; set; }`
  - The type of message to show.
- `public WeaponHash Weapon { get; set; }`
  - The hash of the Weapon as an enum.
- `public uint WeaponHash { get; set; }`
  - The hash of the Weapon as it's native value.

### Methods

- `public virtual void DrawFullScreen()`
- `public void FadeOut(int time)`
  - Fades the big message out.
  - `time`: The time it will take to do the fade.
- `public virtual void Update()`
  - Does nothing.

## BruteForce

class `LemonUI.Scaleform.BruteForce` : `BaseScaleform`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

The BruteForce Hacking Minigame shown in multiple missions.

### Constructors

- `public BruteForce()`
  - Creates a new Hacking Scaleform.

### Properties

- `public BruteForceBackground Background { get; set; }`
  - The background of the Hacking minigame.
- `public bool CanRetry { get; set; }`
  - If the player can retry the hack after failing.
- `public int CloseAfter { get; set; }`
  - The time in milliseconds to wait before closing the Hack window automatically.
- `public TimeSpan Countdown { get; set; }`
  - The countdown of the Hack minigame.
- `public int CurrentLives { get; }`
  - The current number of lives that the player has.
- `public List<string> FailMessages { get; }`
  - The messages that will appear when the player fails.
- `public bool ResetOnRowFail { get; set; }`
  - If all of the rows should be restarted after the player fails one.
- `public bool ShowLives { get; set; }`
  - If the lives of the player should be shown on the top right.
- `public List<string> SuccessMessages { get; }`
  - The messages that might appear on success.
- `public int TotalLives { get; set; }`
  - The number of Lives of the minigame.
- `public bool Visible { get; set; }`
- `public string Word { get; set; }`
  - The Word shown to select in the menu.

### Methods

- `public void Reset()`
  - Resets the entire Hacking minigame.
- `public void RunProgram(int program)`
  - Runs the specified Hacking program.
  - `program`: The program to open.
- `public void SetColumnSpeed(int index, float speed)`
  - Sets the speed of one of the 8 columns.
  - `index`: The index of the column.
  - `speed`: The speed of the column.
- `public virtual void Update()`
  - Updates the information of the Hacking window.

### Events

- `public event BruteForceFinishedEventHandler HackFinished`
  - Event triggered when the player finishes a hack.

## BruteForceBackground

enum `LemonUI.Scaleform.BruteForceBackground`

The Background of the BruteForce Hack Minigame.

| Name | Value | Description |
| --- | --- | --- |
| `Black` | 0 | A simple Black background. |
| `Purple` | 1 | A simple Purple background. |
| `Gray` | 2 | A simple Gray background. |
| `LightBlue` | 3 | A simple Light Blue background. |
| `Wallpaper1` | 4 | A Light Blue Wallpaper. |
| `DarkFade` | 5 | A Fade from Gray in the center to Black in the corners. |

## BruteForceFinishedEventArgs

class `LemonUI.Scaleform.BruteForceFinishedEventArgs`

Event information after an the BruteForce hack has finished.

### Properties

- `public BruteForceStatus Status { get; }`
  - The final status of the Hack.

## BruteForceFinishedEventHandler

delegate `LemonUI.Scaleform.BruteForceFinishedEventHandler` : `MulticastDelegate`, `ICloneable`, `ISerializable`

Represents the method that is called when the end user finishes the BruteForce hack.

### Constructors

- `public BruteForceFinishedEventHandler(object object, IntPtr method)`

### Methods

- `public virtual IAsyncResult BeginInvoke(object sender, BruteForceFinishedEventArgs e, AsyncCallback callback, object object)`
- `public virtual void EndInvoke(IAsyncResult result)`
- `public virtual void Invoke(object sender, BruteForceFinishedEventArgs e)`

## BruteForceStatus

enum `LemonUI.Scaleform.BruteForceStatus`

The status of the BruteForce Hack after finishing.

| Name | Value | Description |
| --- | --- | --- |
| `Completed` | 0 | The user completed the hack successfully. |
| `OutOfTime` | 1 | The user ran out of time. |
| `OutOfLives` | 2 | The player ran out of lives. |

## Celebration

class `LemonUI.Scaleform.Celebration` : `CelebrationCore`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

The foreground of the celebration scaleform.

### Constructors

- `public Celebration()`
  - Initializes a new Celebration scaleform.

### Properties

- `public CelebrationBackground Background { get; }`
  - The background of the scaleform.
- `public string Challenge { get; set; }`
  - The challenge shown.
- `public int Duration { get; set; }`
  - For how long the scalefom is show.
- `public CelebrationForeground Foreground { get; }`
  - The foreground of the scaleform.
- `public string Job { get; set; }`
  - The job name shown.
- `public string Mode { get; set; }`
  - The mode name shown.
- `public CelebrationStyle Style { get; set; }`
  - The style of the celebration.

### Methods

- `public void Cancel()`
  - Cancels the current screen being shown.
- `public virtual void DrawFullScreen()`
  - Draws the celebration scaleform.
- `public virtual void Process()`
- `public void Show()`
  - Shows the celebration scaleform.

### Events

- `public event EventHandler Finished`
  - Event triggered when the scaleform has finished fading out.
- `public event EventHandler Shown`
  - Event triggered when the scaleform is shown on the screen.

## CelebrationBackground

class `LemonUI.Scaleform.CelebrationBackground` : `CelebrationCore`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

The background of the celebration scaleform.

### Constructors

- `public CelebrationBackground()`
  - Initializes a new Celebration background.

## CelebrationCore

abstract class `LemonUI.Scaleform.CelebrationCore` : `BaseScaleform`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

The base of all MP_CELEBRATION* scaleforms.

### Constructors

- `public CelebrationCore(string sc)`
  - Initializes a new class with the core behavior of the Celebration scaleform.
  - `sc`: The scaleform to use.

### Methods

- `public virtual void Update()`
  - Updates the celebration scaleform.

## CelebrationForeground

class `LemonUI.Scaleform.CelebrationForeground` : `CelebrationCore`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

The foreground of the celebration scaleform.

### Constructors

- `public CelebrationForeground()`
  - Initializes a new Celebration foreground.

## CelebrationStyle

enum `LemonUI.Scaleform.CelebrationStyle`

The style of the Celebration scaleform.

| Name | Value | Description |
| --- | --- | --- |
| `Clean` | 0 | General purpose clean style. used in missions. |
| `Prep` | 1 | The style used in the heist prep missions. |
| `Heist` | 2 | The style used in the heist finals and end of prep/final. |
| `Race` | 3 | The style used for the Stunt Races. |

## Countdown

class `LemonUI.Scaleform.Countdown` : `BaseScaleform`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

The Countdown scaleform in the GTA Online races.

### Constructors

- `public Countdown()`
  - Creates a new countdown scaleform.

### Properties

- `public Color ColorGo { get; set; }`
  - The color used for the GO at the end.
- `public Color ColorNumbers { get; set; }`
  - The color used for the numbers.
- `public Sound CountSound { get; set; }`
  - The sound played when counting down.
- `public int Current { get; }`
  - The current count.
- `public int Duration { get; set; }`
  - The duration of the countdown.
- `public Sound GoSound { get; set; }`
  - The sound played when the countdown has finished.

### Methods

- `public virtual void Process()`
- `public void Start()`
  - Starts the countdown.
- `public virtual void Update()`

### Events

- `public event EventHandler Finished`
  - Event triggered when the countdown has finished.
- `public event EventHandler Started`
  - Event triggered when the countdown starts.

### Fields

- `public static Sound DefaultCountSound`
  - The default sound played when the countdown
- `public static Sound DefaultGoSound`
  - The default sound when th

## InstructionalButton

struct `LemonUI.Scaleform.InstructionalButton`

An individual instructional button.

### Constructors

- `public InstructionalButton(string description, Control control)`
  - Creates an instructional button for a Control.
  - `description`: The text for the description.
  - `control`: The control to use.
- `public InstructionalButton(string description, string raw)`
  - Creates an instructional button for a raw control.
  - `description`: The text for the description.
  - `raw`: The raw value of the control.

### Properties

- `public Control Control { get; set; }`
  - The Control used by this button.
- `public string Description { get; set; }`
  - The description of this button.
- `public string Raw { get; set; }`
  - The Raw Control sent to the Scaleform.

## InstructionalButtons

class `LemonUI.Scaleform.InstructionalButtons` : `BaseScaleform`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

Buttons shown on the bottom right of the screen.

### Constructors

- `public InstructionalButtons(params InstructionalButton[] buttons)`
  - Creates a new set of Instructional Buttons.
  - `buttons`: The buttons to add into this menu.

### Methods

- `public void Add(InstructionalButton button)`
  - Adds an Instructional Button.
  - `button`: The button to add.
- `public void Clear()`
  - Removes all of the instructional buttons.
- `public void Remove(InstructionalButton button)`
  - Removes an Instructional Button.
  - `button`: The button to remove.
- `public virtual void Update()`
  - Refreshes the items shown in the Instructional buttons.

## IScaleform

interface `LemonUI.Scaleform.IScaleform` : `IDrawable`, `IProcessable`, `IDisposable`

Scaleforms are 2D Adobe Flash-like objects.

### Methods

- `public void DrawFullScreen()`
  - Draws the Scaleform in full screen.

## LoadingScreen

class `LemonUI.Scaleform.LoadingScreen` : `BaseScaleform`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

Loading screen like the transition between story mode and online.

### Constructors

- `public LoadingScreen(string title, string subtitle, string description, string dictionary, string texture)`
  - Creates a new GTA Online like loading screen with a custom texture.
  - `title`: The title of the screen.
  - `subtitle`: The subtitle of the screen.
  - `description`: The description of the screen.
  - `dictionary`: The dictionary where the texture is located.
  - `texture`: The texture to use on the right.
- `public LoadingScreen(string title, string subtitle, string description)`
  - Creates a new GTA Online like loading screen with no image.
  - `title`: The title of the screen.
  - `subtitle`: The subtitle of the screen.
  - `description`: The description of the screen.

### Properties

- `public string Description { get; set; }`
  - The description of the loading screen.
- `public string Dictionary { get; }`
  - The Texture Dictionary (TXD) where the texture is loaded.
- `public string Subtitle { get; set; }`
  - The subtitle of the loading screen.
- `public string Texture { get; }`
  - The texture in the dictionary.
- `public string Title { get; set; }`
  - The title of the loading screen.

### Methods

- `public void ChangeTexture(string dictionary, string texture)`
  - Changes the texture shown on the loading screen.
  - `dictionary`: The Texture Dictionary or TXD.
  - `texture`: The Texture name.
- `public virtual void Update()`
  - Updates the Title, Description and Image of the loading screen.

## MessageType

enum `LemonUI.Scaleform.MessageType`

The type for a big message.

| Name | Value | Description |
| --- | --- | --- |
| `Customizable` | 0 | A centered message with customizable text an d background colors. Internally called SHOW_SHARD_CENTERED_MP_MESSAGE. |
| `RankUp` | 1 | Used when you rank up on GTA Online. Internally called SHOW_SHARD_CREW_RANKUP_MP_MESSAGE. |
| `MissionPassedOldGen` | 2 | The Mission Passed screen on PS3 and Xbox 360. Internally called SHOW_MISSION_PASSED_MESSAGE. |
| `Wasted` | 3 | The Message Type shown on the Wasted screen. Internally called SHOW_SHARD_WASTED_MP_MESSAGE. |
| `Plane` | 4 | Used on the GTA Online Freemode event announcements. Internally called SHOW_PLANE_MESSAGE. |
| `CopsAndCrooks` | 5 | Development leftover from when GTA Online was Cops and Crooks. Internally called SHOW_BIG_MP_MESSAGE. |
| `Weapon` | 6 | Message shown when the player purchases a weapon. Internally called SHOW_WEAPON_PURCHASED. |
| `CenteredLarge` | 7 | Unknown where this one is used. Internally called SHOW_CENTERED_MP_MESSAGE_LARGE. |

## PopUp

class `LemonUI.Scaleform.PopUp` : `BaseScaleform`, `IScaleform`, `IDrawable`, `IProcessable`, `IDisposable`

A warning pop-up.

### Constructors

- `public PopUp()`
  - Creates a new Pop-up instance.

### Properties

- `public string Error { get; set; }`
  - The error message to show.
- `public string Prompt { get; set; }`
  - The prompt of the Pop-up.
- `public bool ShowBackground { get; set; }`
  - If the black background should be shown.
- `public string Subtitle { get; set; }`
  - The subtitle of the Pop-up.
- `public string Title { get; set; }`
  - The title of the Pop-up.

### Methods

- `public virtual void Update()`
  - Updates the texts of the Pop-up.

