# NativeUI (legacy, SHVDN v2) API reference

> **Source:** `scripts/NativeUI.dll` (file version 1.9.0.0, assembly version 1.9.0.0, 97,792 bytes, modified 2019-05-02, SHA-256 `291d02fa1efe191ccbeda72ed7e52dce36dbbcf440b303a1afb58b7ddbc9275b`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `scripts/NativeUI.xml`, shipped with the installed DLL.

Generated: don't edit by hand, re-run the generator instead.

Older menu library built on SHVDN v2. Use LemonUI for new scripts.

49 public types.

## [NativeUI](NativeUI.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`BarTimerBar`](NativeUI.md#bartimerbar) | class |  |
| [`BigMessageHandler`](NativeUI.md#bigmessagehandler) | class |  |
| [`BigMessageThread`](NativeUI.md#bigmessagethread) | class |  |
| [`CheckboxChangeEvent`](NativeUI.md#checkboxchangeevent) | delegate |  |
| [`HudColor`](NativeUI.md#hudcolor) | enum |  |
| [`IListItem`](NativeUI.md#ilistitem) | interface |  |
| [`IndexChangedEvent`](NativeUI.md#indexchangedevent) | delegate |  |
| [`InstructionalButton`](NativeUI.md#instructionalbutton) | class |  |
| [`ItemActivatedEvent`](NativeUI.md#itemactivatedevent) | delegate |  |
| [`ItemCheckboxEvent`](NativeUI.md#itemcheckboxevent) | delegate |  |
| [`ItemListEvent`](NativeUI.md#itemlistevent) | delegate |  |
| [`ItemSelectEvent`](NativeUI.md#itemselectevent) | delegate |  |
| [`ItemSliderEvent`](NativeUI.md#itemsliderevent) | delegate |  |
| [`ListChangedEvent`](NativeUI.md#listchangedevent) | delegate |  |
| [`MenuChangeEvent`](NativeUI.md#menuchangeevent) | delegate |  |
| [`MenuCloseEvent`](NativeUI.md#menucloseevent) | delegate |  |
| [`MenuOpenEvent`](NativeUI.md#menuopenevent) | delegate |  |
| [`MenuPool`](NativeUI.md#menupool) | class | Helper class that handles all of your Menus. After instatiating it, you will have to add your menu by using the Add method. |
| [`MiscExtensions`](NativeUI.md#miscextensions) | static class |  |
| [`SliderChangedEvent`](NativeUI.md#sliderchangedevent) | delegate |  |
| [`Sprite`](NativeUI.md#sprite) | class |  |
| [`StringMeasurer`](NativeUI.md#stringmeasurer) | static class |  |
| [`TextTimerBar`](NativeUI.md#texttimerbar) | class |  |
| [`TimerBarBase`](NativeUI.md#timerbarbase) | abstract class |  |
| [`TimerBarPool`](NativeUI.md#timerbarpool) | class |  |
| [`UIMenu`](NativeUI.md#uimenu) | class | Base class for NativeUI. Calls the next events: OnIndexChange, OnListChanged, OnCheckboxChange, OnItemSelect, OnMenuClose, OnMenuchange. |
| [`UIMenu.MenuControls`](NativeUI.md#uimenumenucontrols) | enum |  |
| [`UIMenuCheckboxItem`](NativeUI.md#uimenucheckboxitem) | class |  |
| [`UIMenuColoredItem`](NativeUI.md#uimenucoloreditem) | class |  |
| [`UIMenuDynamicListItem`](NativeUI.md#uimenudynamiclistitem) | class |  |
| [`UIMenuDynamicListItem.ChangeDirection`](NativeUI.md#uimenudynamiclistitemchangedirection) | enum |  |
| [`UIMenuDynamicListItem.DynamicListItemChangeCallback`](NativeUI.md#uimenudynamiclistitemdynamiclistitemchangecallback) | delegate |  |
| [`UIMenuItem`](NativeUI.md#uimenuitem) | class | Simple item with a label. |
| [`UIMenuItem.BadgeStyle`](NativeUI.md#uimenuitembadgestyle) | enum |  |
| [`UIMenuListItem`](NativeUI.md#uimenulistitem) | class |  |
| [`UIMenuSliderItem`](NativeUI.md#uimenuslideritem) | class |  |
| [`UIResRectangle`](NativeUI.md#uiresrectangle) | class | A rectangle in 1080 pixels height system. |
| [`UIResText`](NativeUI.md#uirestext) | class | A Text object in the 1080 pixels height base system. |
| [`UIResText.Alignment`](NativeUI.md#uirestextalignment) | enum |  |

## [NativeUI.PauseMenu](NativeUI.PauseMenu.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`MissionInformation`](NativeUI.PauseMenu.md#missioninformation) | class |  |
| [`MissionLogo`](NativeUI.PauseMenu.md#missionlogo) | class |  |
| [`OnItemSelect`](NativeUI.PauseMenu.md#onitemselect) | delegate |  |
| [`TabInteractiveListItem`](NativeUI.PauseMenu.md#tabinteractivelistitem) | class |  |
| [`TabItem`](NativeUI.PauseMenu.md#tabitem) | class |  |
| [`TabItemSimpleList`](NativeUI.PauseMenu.md#tabitemsimplelist) | class |  |
| [`TabMissionSelectItem`](NativeUI.PauseMenu.md#tabmissionselectitem) | class |  |
| [`TabSubmenuItem`](NativeUI.PauseMenu.md#tabsubmenuitem) | class |  |
| [`TabTextItem`](NativeUI.PauseMenu.md#tabtextitem) | class |  |
| [`TabView`](NativeUI.PauseMenu.md#tabview) | class |  |

