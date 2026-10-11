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

## Patches (behaviour)

| Problem | Fix |
| --- | --- |
| Online loaded at game start (MP IPLs in the constructor, `ON_ENTER_MP` and the character creator on the first tick). | The game stays in story mode until **L** is pressed (`OnlineRequested`). The first L press runs start-up, and with `PROGRESSION = 1` the session menu opens once loading is done. |
| `ON_ENTER_MP` blocked about 22 s and SHVDN aborted the script (5 s per-tick limit). | Logs and `Script.Yield()` after `ON_ENTER_MP` and every 4 IPLs. `ON_ENTER_SP` is no longer called: in free roam it hung the game. The screen fades out during the map swap. |
| D-pad Up opened the phone while scrolling up in a menu, and the phone also ran in story mode. | `Mobile_Phone` opens only after L, never while a CruelMasters menu is visible (`ANY_MENU_VISIBLE`), and not while the AppDomain flags `ModGuide.MenuOpen` or `PhoneGuard.MenuOpen` (TrainerV and Menyoo, see `../PhoneGuard/`) are set. |

## Patches (roadmap batch 1, 2026-10-11)

Plan and status: [ROADMAP.md](ROADMAP.md).

| Problem | Fix |
| --- | --- |
| Online pause menu's Quit does nothing, so the game could only be closed with Alt+F4. | Interaction menu **Quit Game** (select twice within 5 s), then `QUIT_GAME`. |
| Mission lobbies (corona) showed headers but no missions or players: data was pushed before the frontend movie was ready and silently dropped. | `WaitForFrontendReady` after opening each lobby (Gerald, Simeon, custom heist), plus a forced first refresh (`PreviousSelection = -1`). |
| Simeon only unlocked at rank 3, and Gerald's first mission paid a random 500-1300 RP. | New save flag `GeraldFirstMissionDone` unlocks Simeon after one pass; that mission pays a fixed 1250 RP. |
| `MPSimeonCMS` read and parsed `Save Data.xml` every frame. | `MPSaveData` caches saves in memory and updates the cache on save. |
| `LoadCutscene` looped forever on a missing cutscene. | 10 s timeout, logged once per cutscene (`TryLoadCutscene`). |
| Simeon intro: no fade, player not registered, cutscene removed 50 ms after start. | New `PlayPlayerCutscene` helper (fade, timed load, register MP_1, start, wait, remove, fade in, log). Simeon is unlocked even if the cutscene fails. |
| Phone Quick Job and Job List did nothing. | Quick Job sets a waypoint to the nearest unlocked contact; Job List shows what is unlocked. |
| Missions ended by teleporting to the contact marker, some 1 m below the floor (fell through the map). | `MissionEndReturn`: stay where the mission ended; optional `[MISSIONS] RETURN TO CONTACT = true` puts you back on the ground at the marker. |

Known risks, not changed: it sets wanted levels and the max wanted level, ends stock scripts (`atm_trigger`, `re_atmrobbery`), replaces the pause menu and calls `ChangeModel`. Not tested in game yet. Check `ScriptHookVDotNet.log` after each session.
