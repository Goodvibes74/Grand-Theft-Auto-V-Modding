# GTAOnlineOffline

Single-player recreation of the early GTA Online story (intro, character creator, Lester phone menus, Eclipse Towers apartment, Fleeca heist, Kosatka travel). This is the 2021 mod "GTA ONLINE - OFFLINE", decompiled with ILSpy because we have no source, then patched to run on the installed LemonUI 2.2.

- **Language and API:** C#, SHVDN v3, LemonUI 2.x, NAudio. About 48,000 lines in one class (`OnlineMain.cs`), as the decompiler produced it.
- **Build:** `dotnet build -c Release ModDevelopment/MyMods/GTAOnlineOffline/GTAOnlineOffline.csproj` (game closed; copies `GTAOnline_Offline.dll` into `scripts/`). The assembly name must stay `GTAOnline_Offline`.
- **Needs next to it in `scripts/`:** `GTAOnline_Offline.ini` (config and save), `GTAOnlineOfflineAssets/*.wav`, `NAudio*.dll`.
- **Original files:** `original/` holds the untouched 2021 DLL and ini.

## Patches

| Problem | Fix |
| --- | --- |
| The character creator crashed on first use: `InvalidOperationException: The object is not the list of Items` (`NativeListItem.set_SelectedItem`). The old LemonUI ignored a saved value that isn't in a menu's list; LemonUI 2.x throws, and the throw aborted the whole script. | All 34 `X.SelectedItem = value;` assignments now go through `SafeMenu.Select`, which keeps the current selection when the value isn't in the list. |
| `NativeMenu.Open()` / `Close()` are errors in LemonUI 2.x. | Replaced with `Visible = true` / `false`. |
| `NativeMenu.Title` styling (outline, shadow) no longer exists. | Those five cosmetic lines are commented out. |
| `Ped.Clone(float)` is obsolete. | `Clone(false)`. |

Not tested past the character creator. Check `ScriptHookVDotNet.log` after each session.
