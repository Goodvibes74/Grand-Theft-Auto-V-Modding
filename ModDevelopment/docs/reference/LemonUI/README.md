# LemonUI for SHVDN v3 API reference

> **Source:** `scripts/LemonUI.SHVDN3.dll` (file version 2.2.0.0, assembly version 2.2.0.0, 103,936 bytes, modified 2025-05-22, SHA-256 `b52ef80136152ed7afdf335bd4ff16183977c8e27223aaf5c94a8c16e62e1aeb`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/LemonUI.SHVDN3.xml`, shipped with the installed DLL.

Generated: don't edit by hand, re-run the generator instead.

Menus and screen elements for SHVDN v3 scripts.

86 public types.

## [LemonUI.Elements](LemonUI.Elements.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`BaseElement`](LemonUI.Elements.md#baseelement) | abstract class | Base class for all of the 2D elements. |
| [`I2Dimensional`](LemonUI.Elements.md#i2dimensional) | interface | A 2D item that can be drawn on the screen. |
| [`IText`](LemonUI.Elements.md#itext) | interface | A Drawable screen text. |
| [`ScaledAnim`](LemonUI.Elements.md#scaledanim) | class | A scaled animation using YTD files with all of the frames. |
| [`ScaledBink`](LemonUI.Elements.md#scaledbink) | class | A Bink Video file. |
| [`ScaledRectangle`](LemonUI.Elements.md#scaledrectangle) | class | A 2D rectangle. |
| [`ScaledText`](LemonUI.Elements.md#scaledtext) | class | A text string. |
| [`ScaledTexture`](LemonUI.Elements.md#scaledtexture) | class | A 2D game texture. |

## [LemonUI.Extensions](LemonUI.Extensions.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`FloatExtensions`](LemonUI.Extensions.md#floatextensions) | static class | Extensions for the float class. |
| [`PointExtensions`](LemonUI.Extensions.md#pointextensions) | static class | Extensions for the Point and PointF classes. |
| [`SizeExtensions`](LemonUI.Extensions.md#sizeextensions) | static class | Extensions for the Size and SizeF classes. |

## [LemonUI](LemonUI.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`GFXAlignment`](LemonUI.md#gfxalignment) | enum | Represents the internal alignment of screen elements. |
| [`IContainer<T>`](LemonUI.md#icontainert) | interface | Represents a container that can hold other UI Elements. |
| [`IDrawable`](LemonUI.md#idrawable) | interface | Represents an item that can be drawn. |
| [`IProcessable`](LemonUI.md#iprocessable) | interface | Interface for items that can be processed in an Object Pool. |
| [`IRecalculable`](LemonUI.md#irecalculable) | interface | Interface for classes that have values that need to be recalculated on resolution changes. |
| [`ObjectPool`](LemonUI.md#objectpool) | class | Manager for Menus and Items. |
| [`ResolutionChangedEventArgs`](LemonUI.md#resolutionchangedeventargs) | class | Represents the information after a Resolution Change in the game. |
| [`ResolutionChangedEventHandler`](LemonUI.md#resolutionchangedeventhandler) | delegate | Represents the method that reports a Resolution change in the Game Settings. |
| [`SafeZoneChangedEventArgs`](LemonUI.md#safezonechangedeventargs) | class | Represents the information after a Safe Zone Change in the game. |
| [`SafeZoneChangedEventHandler`](LemonUI.md#safezonechangedeventhandler) | delegate | Represents the method that reports a Safe Zone change in the Game Settings. |
| [`Screen`](LemonUI.md#screen) | static class | Contains a set of tools to work with the screen information. |
| [`Sound`](LemonUI.md#sound) | class | Contains information for a Game Sound that is played at specific times. |

## [LemonUI.Menus](LemonUI.Menus.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`BadgeSet`](LemonUI.Menus.md#badgeset) | class | Represents a badge that can be applied to a `NativeItem`. |
| [`ColorSet`](LemonUI.Menus.md#colorset) | class | Stores the different colors required to make the colors of a `NativeItem` dynamic. |
| [`ColorTitleStyle`](LemonUI.Menus.md#colortitlestyle) | enum | The Style of title for the Color Panel. |
| [`CountVisibility`](LemonUI.Menus.md#countvisibility) | enum | The visibility setting for the Item Count of the Menu. |
| [`Direction`](LemonUI.Menus.md#direction) | enum | The movement direction of the item change. |
| [`GridStyle`](LemonUI.Menus.md#gridstyle) | enum | The style of the Grid Panel. |
| [`GridValueChangedArgs`](LemonUI.Menus.md#gridvaluechangedargs) | class | Represents the Previous and Current X and Y values when changing the position on a grid. |
| [`GridValueChangedEventHandler`](LemonUI.Menus.md#gridvaluechangedeventhandler) | delegate | Represents the method that is called when the value on a grid is changed. |
| [`HeaderBehavior`](LemonUI.Menus.md#headerbehavior) | enum | The behavior of the `NativeMenu`'s header. |
| [`ItemActivatedArgs`](LemonUI.Menus.md#itemactivatedargs) | class | Represents the arguments of an item activation. |
| [`ItemActivatedEventHandler`](LemonUI.Menus.md#itemactivatedeventhandler) | delegate | Represents the method that is called when an item is activated on a menu. |
| [`ItemChangedEventArgs<T>`](LemonUI.Menus.md#itemchangedeventargst) | class | Represents the change of the selection of an item. |
| [`ItemChangedEventHandler<T>`](LemonUI.Menus.md#itemchangedeventhandlert) | delegate | Represents the method that is called when the selected item is changed on a List Item. |
| [`ItemOperation`](LemonUI.Menus.md#itemoperation) | enum | The operation performed when the menu items are modified. |
| [`MenuModifiedEventArgs`](LemonUI.Menus.md#menumodifiedeventargs) | class | Represents the different |
| [`MenuModifiedEventHandler`](LemonUI.Menus.md#menumodifiedeventhandler) | delegate | Represents the method that is called when the items on a menu are changed (added or removed). |
| [`MenuMouseBehavior`](LemonUI.Menus.md#menumousebehavior) | enum | Defines the behavior of the mouse when a menu is open. |
| [`NativeCheckboxItem`](LemonUI.Menus.md#nativecheckboxitem) | class | Rockstar-like checkbox item. |
| [`NativeColorData`](LemonUI.Menus.md#nativecolordata) | class | Represents the Color Information shown on the Panel. |
| [`NativeColorPanel`](LemonUI.Menus.md#nativecolorpanel) | class | A Panel that allows you to select a Color. |
| [`NativeDynamicItem<T>`](LemonUI.Menus.md#nativedynamicitemt) | class | Dynamic Items allow you to dynamically change the item shown to the user. |
| [`NativeGridPanel`](LemonUI.Menus.md#nativegridpanel) | class | Represents a grid where you can select X and Y values. |
| [`NativeItem`](LemonUI.Menus.md#nativeitem) | class | Basic Rockstar-like item. |
| [`NativeListItem`](LemonUI.Menus.md#nativelistitem) | abstract class | Base class for list items. |
| [`NativeListItem<T>`](LemonUI.Menus.md#nativelistitemt) | class | An item that allows you to scroll between a set of objects. |
| [`NativeMenu`](LemonUI.Menus.md#nativemenu) | class | Menu that looks like the ones used by Rockstar. |
| [`NativePanel`](LemonUI.Menus.md#nativepanel) | abstract class | Represents a panel shown under the description of the item description. |
| [`NativeSeparatorItem`](LemonUI.Menus.md#nativeseparatoritem) | class | An item used to have a space between the items with text or no text. |
| [`NativeSlidableItem`](LemonUI.Menus.md#nativeslidableitem) | abstract class | Basic elements for a slidable item. |
| [`NativeSliderItem`](LemonUI.Menus.md#nativeslideritem) | class | A slider item for changing integer values. |
| [`NativeStatsInfo`](LemonUI.Menus.md#nativestatsinfo) | class | Represents the Information of a specific field in a `NativeStatsPanel`. |
| [`NativeStatsPanel`](LemonUI.Menus.md#nativestatspanel) | class | Represents a Statistics panel. |
| [`NativeSubmenuItem`](LemonUI.Menus.md#nativesubmenuitem) | class | Item used for opening submenus. |
| [`SelectedEventArgs`](LemonUI.Menus.md#selectedeventargs) | class | Represents the selection of an item in the screen. |
| [`SelectedEventHandler`](LemonUI.Menus.md#selectedeventhandler) | delegate | Represents the method that is called when a new item is selected in the Menu. |
| [`SubtitleBehavior`](LemonUI.Menus.md#subtitlebehavior) | enum | The behavior of the `NativeMenu`'s subtitle. |

## [LemonUI.Scaleform](LemonUI.Scaleform.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`BaseScaleform`](LemonUI.Scaleform.md#basescaleform) | abstract class | Represents a generic Scaleform object. |
| [`BigMessage`](LemonUI.Scaleform.md#bigmessage) | class | A customizable big message. |
| [`BruteForce`](LemonUI.Scaleform.md#bruteforce) | class | The BruteForce Hacking Minigame shown in multiple missions. |
| [`BruteForceBackground`](LemonUI.Scaleform.md#bruteforcebackground) | enum | The Background of the BruteForce Hack Minigame. |
| [`BruteForceFinishedEventArgs`](LemonUI.Scaleform.md#bruteforcefinishedeventargs) | class | Event information after an the BruteForce hack has finished. |
| [`BruteForceFinishedEventHandler`](LemonUI.Scaleform.md#bruteforcefinishedeventhandler) | delegate | Represents the method that is called when the end user finishes the BruteForce hack. |
| [`BruteForceStatus`](LemonUI.Scaleform.md#bruteforcestatus) | enum | The status of the BruteForce Hack after finishing. |
| [`Celebration`](LemonUI.Scaleform.md#celebration) | class | The foreground of the celebration scaleform. |
| [`CelebrationBackground`](LemonUI.Scaleform.md#celebrationbackground) | class | The background of the celebration scaleform. |
| [`CelebrationCore`](LemonUI.Scaleform.md#celebrationcore) | abstract class | The base of all MP_CELEBRATION* scaleforms. |
| [`CelebrationForeground`](LemonUI.Scaleform.md#celebrationforeground) | class | The foreground of the celebration scaleform. |
| [`CelebrationStyle`](LemonUI.Scaleform.md#celebrationstyle) | enum | The style of the Celebration scaleform. |
| [`Countdown`](LemonUI.Scaleform.md#countdown) | class | The Countdown scaleform in the GTA Online races. |
| [`InstructionalButton`](LemonUI.Scaleform.md#instructionalbutton) | struct | An individual instructional button. |
| [`InstructionalButtons`](LemonUI.Scaleform.md#instructionalbuttons) | class | Buttons shown on the bottom right of the screen. |
| [`IScaleform`](LemonUI.Scaleform.md#iscaleform) | interface | Scaleforms are 2D Adobe Flash-like objects. |
| [`LoadingScreen`](LemonUI.Scaleform.md#loadingscreen) | class | Loading screen like the transition between story mode and online. |
| [`MessageType`](LemonUI.Scaleform.md#messagetype) | enum | The type for a big message. |
| [`PopUp`](LemonUI.Scaleform.md#popup) | class | A warning pop-up. |

## [LemonUI.TimerBars](LemonUI.TimerBars.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`ObjectiveSpacing`](LemonUI.TimerBars.md#objectivespacing) | enum | The spacing of the objectives in the timer bar. |
| [`TimerBar`](LemonUI.TimerBars.md#timerbar) | class | Represents a Bar with text information shown in the bottom right. |
| [`TimerBarCollection`](LemonUI.TimerBars.md#timerbarcollection) | class | A collection or Set of `TimerBar`. |
| [`TimerBarObjective`](LemonUI.TimerBars.md#timerbarobjective) | class | A timer bar for a specific amount of objectives. |
| [`TimerBarProgress`](LemonUI.TimerBars.md#timerbarprogress) | class | Represents a Timer Bar that shows the progress of something. |

## [LemonUI.Tools](LemonUI.Tools.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`Extensions`](LemonUI.Tools.md#extensions) | static class | Extensions for converting values between relative and scaled. |
| [`GameScreen`](LemonUI.Tools.md#gamescreen) | static class | The screen of the game being rendered. |
| [`SafeZone`](LemonUI.Tools.md#safezone) | static class | Tools for changing, resetting and retrieving the Safe Zone of the game. |

