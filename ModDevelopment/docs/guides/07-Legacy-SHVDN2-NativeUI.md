# 07 Legacy: SHVDN v2 and NativeUI

`ScriptHookVDotNet2.dll` (2.11.6) and `scripts/NativeUI.dll` (1.9.0) are here so older mods keep working. **Don't write new scripts against them.** This guide is for reading, fixing or porting an old mod.

> **Sources:** v2 API from `ScriptHookVDotNet2.dll` 2.11.6 with its NuGet docs. NativeUI from `scripts/NativeUI.dll` 1.9.0 and its shipped docs. Which mods use which API from their assembly references and `ScriptHookVDotNet.log`. Details: [Where everything comes from](../README.md#where-everything-comes-from).

References: [`../reference/SHVDN2/README.md`](../reference/SHVDN2/README.md), [`../reference/NativeUI/README.md`](../reference/NativeUI/README.md).

## How to tell which version a mod uses

- A compiled mod: the DLL references `ScriptHookVDotNet2` or `ScriptHookVDotNet3`. In PowerShell:

  ```powershell
  [Reflection.Assembly]::ReflectionOnlyLoadFrom("D:\Games\Grand Theft Auto V Legacy\scripts\SomeMod.dll").GetReferencedAssemblies().Name
  ```

- A `.cs` file: v2 uses `UI.Notify(...)`, `UIText`, `World.CreateVehicle`. v3 uses `Notification.PostTicker(...)`, `GTA.UI.TextElement`.
- Loose `.cs` scripts compile as v2 unless the file name ends in `.3.cs`, like `FoSAShelter.3.cs`.

## Installed mods by API

From each DLL's references and the last `ScriptHookVDotNet.log` (full table: [`../reference/Installed-Files.md`](../reference/Installed-Files.md)):

| API | Mods |
| --- | --- |
| v3 (3.7.0) | Better Chases+, ImmersifyII, iFruitAddon2, LemonUI, ModGuide, `FoSAShelter.3.cs` |
| v2 (2.11.6) | NativeUI |
| `ScriptHookVDotNet` 0.0.0.0, the API name used before SHVDN 2.10 (sometimes called "v1"), redirected to v2 | Cop_Arrest, Disarm, MapEditor, Stance |

There is no separate v1 runtime or DLL. SHVDN maps the old name to `ScriptHookVDotNet2.dll` and logs a warning that v2 is deprecated.

Better Chases+ is a v3 mod that also references NativeUI 1.7 (the installed NativeUI is 1.9, built on v2). It works in this install, but it's an example of why mixing v2 and v3 libraries is fragile.

## v2 versus v3

| Task | v2 | v3 |
| --- | --- | --- |
| Notification | `UI.Notify("text")` | `Notification.PostTicker("text", false)` |
| Subtitle | `UI.ShowSubtitle("text", 2000)` | `Screen.ShowSubtitle("text", 2000)` |
| Text on screen | `new UIText("text", new Point(x, y), 0.5f).Draw()` | `new TextElement("text", new PointF(x, y), 0.5f).Draw()` |
| Rectangle | `UIRectangle`, `UIContainer` | `ContainerElement` |
| Spawn a vehicle | `World.CreateVehicle(model, pos, heading)` | `Vehicle.Create(model, pos, heading)` |
| Wanted level | `Game.Player.WantedLevel = 0` | `Game.Player.Wanted.SetWantedLevel(0, false)` then `ApplyWantedLevelChangeNow(false)` |
| Natives | `Function.Call(Hash.X, ...)` | Same |
| Script class, `Tick`, `KeyDown`, `Interval` | Same | Same |
| Namespaces | `GTA`, `GTA.Native`, `GTA.Math`, `GTA.NaturalMotion` | Adds `GTA.UI`, `GTA.Input`, `GTA.Chrono`, `GTA.Graphics` |
| Screen positions | Pixels on a 1280 x 720 canvas | Same |
| Enum values | Some names differ (`WeaponHash`, `VehicleHash` were renamed or extended) | Check the reference |

Many v2 members exist in v3 under a new name or class. If a v3 member is marked **Obsolete** in the reference, its message names the replacement.

## NativeUI versus LemonUI

| NativeUI (v2) | LemonUI (v3) |
| --- | --- |
| `MenuPool pool = new MenuPool();` | `ObjectPool pool = new ObjectPool();` |
| `UIMenu menu = new UIMenu("Title", "Subtitle");` | `NativeMenu menu = new NativeMenu("Title", "Subtitle");` |
| `pool.Add(menu);` | `pool.Add(menu);` |
| `menu.AddItem(new UIMenuItem("Text", "Description"));` | `menu.Add(new NativeItem("Text", "Description"));` |
| `UIMenuCheckboxItem`, `UIMenuListItem` | `NativeCheckboxItem`, `NativeListItem<T>` |
| `menu.OnItemSelect += (sender, item, index) => ...` | `item.Activated += (sender, e) => ...` |
| `menu.OnCheckboxChange`, `menu.OnListChange` | `item.CheckboxChanged`, `item.ItemChanged` |
| `pool.AddSubMenu(menu, "Text")` or `menu.BindMenuToItem(sub, item)` | `menu.AddSubMenu(sub)` |
| `pool.ProcessMenus();` every tick | `pool.Process();` every tick |

## Porting a v2 mod to v3

1. Create a v3 project with `New-ModScript.ps1`.
2. Copy the old code in.
3. Build. The compiler lists everything that changed: fix each error using the table above and the SHVDN3 reference.
4. Swap NativeUI for LemonUI using the table above.
5. Fix the **Obsolete** warnings (the message names the replacement).
6. Test in game, then remove the old v2 mod from `scripts/`.
