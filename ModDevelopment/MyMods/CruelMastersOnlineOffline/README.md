# CruelMastersOnlineOffline

Single-player recreation of GTA Online (2023 mod "Online Content in Singleplayer" by CruelMasters). It replaced the older GTA Online - Offline in this install (its patched source is kept in `../GTAOnlineOffline/`). Decompiled with ILSpy because there is no source, then patched to build against the installed LemonUI 2.x.

- **Size:** about 79,000 decompiled lines in about 50 `Script` classes: character editor, session mode (key **L**), clothes, mask, weapon and mod shops, dealership, interaction menu, phone, Simeon and Gerald contracts, heists, AI friends, rank and cash.
- **Language and API:** C#, SHVDN v3, LemonUI 2.x.
- **Build:** `dotnet build -c Release ModDevelopment/MyMods/CruelMastersOnlineOffline/CruelMastersOnlineOffline.csproj` (game closed; copies into `scripts/`). The assembly name must stay `CruelMastersOnlineOffline`.
- **Needs in `scripts/`:** `CruelMastersOnlineOffline.ini` and `CruelMastersOnlineOfflineAssets/` (both are also the save).
- **Not installed:** the small helper mods in the download (MP_Point, HideAbilityBar, NoPausedForGTAV, NoSlow) and its bundled LemonUI and NativeUI (ours are newer). NoSlow would cancel TrainerV slow motion.
- **Original files:** `original/` holds the untouched DLL and ini.

## Patches (LemonUI 2.x)

| Problem | Fix |
| --- | --- |
| `NativeMenu.UseMouse` is an error in LemonUI 2.x. | `MouseBehavior = MenuMouseBehavior.Disabled` / `.Movement`. |
| `NativeMenu.Subtitle` is an error. | `Name`. |
| `NativeMenu.Title` styling and `TitleFont` no longer exist. | Those cosmetic lines are commented out. |

Known risks, not changed: it sets wanted levels and the max wanted level, ends stock scripts (`atm_trigger`, `re_atmrobbery`), replaces the pause menu and calls `ChangeModel`. Not tested in game yet. Check `ScriptHookVDotNet.log` after each session.
