# CruelMasters Online Offline: Roadmap

Plan for improving our patched CruelMasters build (offline GTA Online simulation in single player). It records what the session of 2026-10-11 found in the logs and the source, every improvement discussed, how each one will be built, and the order of work.

Tick items off as they ship (`[x]`), and add the commit hash next to them.

## 1. Where things stand (session of 2026-10-11)

Read from the logs of the game session on 2026-10-11, 01:52 to 02:55.

- **Load chain is healthy.** All 16 `.asi` plugins loaded, ScriptHookV passed the version check (`VER_1_0_3717_0`), and SHVDN started every script, including all 50 CruelMasters scripts. No exceptions in any log. Clean exit at 02:55.
- **Start-up fix works.** Pressing L at 02:16:36 entered Online in about 3 seconds (`ON_ENTER_MP`, 47 IPLs removed, 98 requested, `ContinueCOO = true`). The two older sessions in `scripts/CruelMastersOnlineOffline.log` froze or stopped part way.
- **Gameplay seen in the log:** respawn animation, a shop till robbery, a mask, then `mp_suicide`. Rank went from 2 to 4 (1396 to 5170 RP), cash moved to the bank ($45,580), and the Simeon intro cutscene was marked done. Saved in commit `43cf4e4`.
- **Only warning:** Menyoo reported Gen9 content in the DLC packs, which it says can make Menyoo spawns unstable.

## 2. Problems found in the source

| # | Problem | Cause | Where |
| --- | --- | --- | --- |
| P1 | Gerald's first mission had to be played about four times before Simeon called | Simeon's intro is gated on **rank 3** (2,250 RP), and that mission pays a random 500 to 1,300 RP. Nothing tells the player this. | `MPSimeonCMS.cs:252`, `MPGeraldCMS.cs:1885`, `MPRank.cs:109` |
| P2 | Cutscenes load in a weird way | No fade or scene streaming before `START_CUTSCENE`, so the world pops in. The Simeon intro never registers the player (`REGISTER_ENTITY_FOR_CUTSCENE`), so the cutscene uses its own stand-in ped. `REMOVE_CUTSCENE` runs 50 ms after start (14 times in `MPSimeonCMS.cs`). The incoming call is still on screen when the cutscene starts. `LoadCutscene` re-requests every frame with no timeout. | `MPSimeonCMS.cs:1528-1584`, `CruelMastersOnlineOffline.cs:352` |
| P3 | Clothes, barber and tattoo shops don't work | Clothes stores only have an invisible "browse outfits" spot (2 m radius, no marker). Barber and tattoo shops don't exist in the world; haircuts only live in the interaction menu, and `MPBlipKiller` hides their blips. Story-mode shop scripts only support Michael, Franklin and Trevor. | `MPClothesShop.cs:1030`, `MPInteractionMenu.cs:738`, `MPBlipKiller.cs:22` |
| P4 | Can't quit the game from the pause menu while Online | The mod replaces the pause menu with Rockstar's Online pause menu (`FE_MENU_VERSION_MP_PAUSE`). Its Quit and Story Mode buttons are handled by Online network code that isn't running, so they do nothing. Workaround until fixed: Alt+F4 (CruelMasters saves to its ini on every change). | `MPPause.cs:37-44` |
| P5 | Mission lobby (corona) shows headers but no mission info or players | `CallFunctionFrontend` drops the call when the frontend movie isn't ready yet, and the data is pushed straight after opening the menu. The header uses a different movie that loads first. The details column then only refreshes when the selection changes. | `CruelMastersOnlineOffline.cs:11053`, `MPSimeonCMS.cs:321-420` (same pattern in Gerald and custom heist lobbies) |
| P6 | Pause-map pop-ups on mission blips are empty | Never implemented. `MPMapBlipInfos.cs` has an empty tick and an empty `GERALD_MAP_BLIP_HANDLE`; the original DLL is the same. | `MPMapBlipInfos.cs` |
| P7 | Phone is limited | Email opens empty. Quick Job, Job List, Settings, Internet and the ninth slot do nothing (their `case` is an empty `break`). Snapmatic is a basic frozen camera. | `Mobile_Phone.cs:800-808`, `Mobile_Phone.cs:1238-1263` |
| P8 | AI "online players" feel thin | There are no free-roam simulated players, only up to 7 companions from the AI Creator. Combat is basic, and the player list shows the player's own rank and job points for every companion. | `MPAiCreator.cs`, `Groups.cs:683-760`, `MPPlayerList.cs:103` |
| P9 | Can't switch between story characters and the Online character | CruelMasters treats Online as permanent. See section 4. | `CruelMastersOnlineOffline.cs:784-793` |

## 3. Improvement list

Effort: **S** about an hour, **M** a session, **L** several sessions.

### A. Progression and flow

- [ ] **1.** Unlock Simeon after finishing Gerald's first mission once (or at rank 2) instead of rank 3, with a "next contact" hint. (S) **Built 2026-10-11, awaiting in-game test.**
- [ ] **2.** The same treatment for Lester and Trevor, in a clear order: Gerald, Simeon, Lester, Trevor. (M)
- [ ] **3.** A fixed, fair RP payout for Gerald's first mission instead of a random 500 to 1,300. (S) **Built 2026-10-11, awaiting in-game test.**
- [ ] **4.** A Contacts page in the phone or interaction menu showing what is unlocked and what comes next. (M)

### B. Cutscenes and loading

- [ ] **5.** One shared cutscene helper: fade out, stream the scene, register the player and crew, start, wait for the end, remove, fade in. It logs every cutscene to `CruelMastersOnlineOffline.log` and gives up after 10 s instead of hanging. First target: the Simeon intro. (M) **Built 2026-10-11, awaiting in-game test.**
- [ ] **6.** Move every intro cutscene (Gerald, Simeon, Lester, Trevor) onto the helper. (M)
- [ ] **7.** Replace the fixed 4 to 5 s "Loading Contact Mission" waits with a wait for the scene to actually load. (S)
- [ ] **8.** Timeouts on the cutscene and model loaders (the animation loader already has one). (S) **Cutscene loader built 2026-10-11 (awaiting test); model loaders still to do.**

### C. Character customization (side project)

- [ ] **9.** Clothes stores: marker and blip at all 14 stores, a LemonUI shop with categories (tops, legs, shoes, accessories, hats, glasses), prices, live preview and an orbit camera. (L)
- [ ] **10.** Barber shops at all 7 locations: hair, hair colour, beard, eyebrows, makeup. Reuses the interaction menu's Barber code. (M)
- [ ] **11.** Tattoo parlours at 6 locations, using the game's tattoo data. (L)
- [ ] **12.** Plastic surgeon: reopen the character creator in the world for a fee. (M)
- [ ] **13.** Saved outfits: a wardrobe in the apartment or garage that saves and loads named outfits. (M)

### D. Content from the user's DLCs

Inventory: [DLC-Packs.md](../../docs/reference/DLC-Packs.md). All 48 content updates up to December 2025 are installed and active. The dealership stops at Festive Surprise 2014, so 581 DLC vehicle models aren't for sale.

- [ ] **35.** Dealership and Internet car sites stocked from the DLC inventory: group by update and price from `GET_VEHICLE_MODEL_VALUE`, and skip police and drift-only variants. Pairs with 27. (M)
- [ ] **14.** Port specific contact missions, heists or businesses. The user picks which (Lester heists, casino, Cayo Perico, and so on). (L each)
- [ ] **15.** DLC clothing in the shops (pairs with 9). (M)

### E. Stability and housekeeping

- [ ] **16.** Move the six v2-API mods to v3 where we have source. HomeInvasion is ours; Cop_Arrest, Disarm, MapEditor and Stance would need decompiling. (M)
- [ ] **17.** Look into Menyoo's Gen9 content warning before it causes a crash. (S)
- [ ] **18.** An ini option to auto-start Online without pressing L. (S)

### F. Pause menu and exit

- [x] **19.** "Quit Game" in the interaction menu: save CruelMasters data, then `QUIT_GAME` (`0xEB6891F03362FB12`). (S) **Verified in game 2026-10-11 (clean exit 04:19).**
- [ ] **20.** Make the Online pause menu's own Quit and Exit buttons work. (M)

### G. Switching between story and Online characters

- [ ] **21.** "Return to Story Mode": a clean exit from Online that reverses the map changes, restarts the killed story scripts, restores Michael's position and outfit, blocks autosave while Online, and backs up the story save first. (L)
- [ ] **22.** A character switch between the Online character, Michael, Franklin and Trevor, through our own menu with the swoop camera and the state checks in section 4. (L)

### H. AI online players

- [ ] **23.** Free-roam lobby simulation: 4 to 8 AI players with names, ranks, generated looks and personal vehicles. They join and leave with notices, have blips, and drive, wander and hang out. (L)
- [ ] **24.** Behaviours for them: peaceful players and griefers, occasional police chases, races and fights between them, reactions to gunfire, respawns. Must coexist with SixStarResponse. (L)
- [ ] **25.** Companion upgrades: their own rank and progress, levelling from missions, combat roles (driver, gunner, cover) and following in their own car. (M)
- [ ] **26.** A real player list: each AI's own rank and headshot, and a Report, Invite and Kick menu per name, including inviting free-roam AIs into the crew. (M)

### I. Phone

- [ ] **27.** Internet app. Start with our own browser built inside the phone, with sites that call the existing dealership, cash and bank code: car purchases delivered to the garage, Maze Bank deposit and withdraw, Ammu-Nation delivery, Dynasty 8 once properties exist. Then try driving the game's own web browser movie for the car sites. (L)
- [ ] **28.** Quick Job and Job List: start any unlocked contact mission from the phone. (S) **Verified 2026-10-11 (waypoint only, no teleport): Quick Job sets a waypoint to the nearest unlocked contact, Job List shows unlock status. Launching a mission straight from the phone is still to do.**
- [ ] **29.** Snapmatic upgrade: selfie mode, expressions, filters, a saved gallery, walking with the camera up. (M)
- [ ] **30.** Contacts that do things: Lester removes the wanted level, Simeon delivers a vehicle, Mors Mutual insurance, call a companion to you. (M)
- [ ] **31.** Settings: themes, wallpaper, ringtone, sleep mode. (S)
- [ ] **32.** Email and texts with content: briefings, payment notices, flavour messages. (M)

### J. Lobby and map menus

- [x] **33.** Fix the empty mission lobby: wait for `IS_FRONTEND_READY_FOR_CONTROL` (with a timeout) before pushing data, retry dropped frontend calls for a few frames, and force one refresh after opening. One shared fix covers the Gerald, Simeon and custom heist lobbies. (S) **Verified in game 2026-10-11 (Simeon lobby ready after 131 ms, details shown).**
- [ ] **34.** Build the pause-map info cards: mark contact and mission blips with `SET_BLIP_AS_MISSION_CREATOR_BLIP`, detect hovering with `IS_HOVERING_OVER_MISSION_CREATOR_BLIP` / `GET_NEW_SELECTED_MISSION_CREATOR_BLIP`, and fill the card through the existing `MPMapBlipInfos` helpers (contact, mission, rank, players, payout, done or locked). (M)

### K. Fixes from the first test (2026-10-11)

- [ ] **36.** Missions no longer teleport the player back to the contact marker when they end. 33 mission-pass endings in Gerald and Simeon went to the marker, several of them 1 m below the floor, so the player fell through the map. `MissionEndReturn` keeps the player where they finished; `[MISSIONS] RETURN TO CONTACT = true` restores the old return, placed on the ground. **Built 2026-10-11, awaiting in-game test.**
- [ ] **37.** PhoneGuard missed Menyoo input: Menyoo disables the frontend controls while open, and PhoneGuard used the plain `IS_CONTROL_*` checks, so its guess timed out after 20 s and D-pad Up opened the phone. It now uses `IS_DISABLED_CONTROL_*`. **Built 2026-10-11, awaiting in-game test.**

### L. Vehicles and property

- [ ] **38.** Save vehicles you enter: an interaction menu option "Claim this vehicle" that stores the car you are sitting in (model, colours, mods, plate) as an owned vehicle, using the existing `MPOwnedVehicles` and `VehicleWithComponents` save. Police, mission and emergency vehicles excluded. (M)
- [ ] **39.** Garages: buy a garage (Dynasty 8 site, item 27), with an entrance marker, a vehicle interior (2, 6 or 10 cars), parking saves the car, selecting one spawns it outside. Vehicles from item 38 and the dealership go here. Today the mod has only one personal vehicle (`CurrentVehicle.xml`) and no property at all. (L)
- [ ] **40.** Apartments and safehouses: a buyable apartment with entrance, bed (save and skip time), wardrobe (item 13) and garage link. Respawn there after death. (L)

## 4. What makes story and Online switching hard

1. **Killed story scripts.** Entering Online terminates `cellphone_controller`, `shop_controller`, `clothes_shop_sp`, `respawn_controller`, `restrictedareas`, `gunclub_shop`, vending and ATM scripts. Going back means restarting them, and Rockstar scripts don't always resume cleanly mid-session.
2. **Map state.** Online swaps 47 IPLs out and 98 in. Story missions expect the original layout, so the swap has to be reversed exactly.
3. **Story save corruption (biggest risk).** An autosave while the player is the Online character or the world is in Online state can damage the story save. Autosave must be blocked while Online, and the story save folder backed up before the first switch.
4. **The character wheel and swoop camera belong to Rockstar's selector scripts.** They only know Michael, Franklin and Trevor, so the Online character can't be added to the vanilla wheel. Use our own menu with the swoop camera the mod already uses for missions.
5. **Per-character state.** Each story character has a saved position, outfit and wanted level that must be restored.
6. **CruelMasters assumes Online is permanent.** Its 50 scripts run off one `StorySwitch` value. Each has to clean up on exit: blips, contact calls, `NoCopsOnMission` and similar flags.
7. **When switching is allowed:** never during a mission, cutscene, wanted level, death or while in a vehicle.

## 5. Approach

- **Source of truth:** our patched sources in `ModDevelopment/MyMods/CruelMastersOnlineOffline/`. Build with `dotnet build -c Release ModDevelopment/ModDevelopment.slnx` with the game closed; the DLL is copied into `scripts/`.
- **Verification:** Claude can't run the game. Every change adds a `LogLine` to `scripts/CruelMastersOnlineOffline.log`, the user plays, and Claude reads the log and `ScriptHookVDotNet.log` afterwards.
- **One vertical slice first:** each system is proven on one case (the Simeon intro for cutscenes, one clothes store for shops, one AI player for the lobby) before it is rolled out everywhere.
- **Shared helpers over copy-paste:** the decompiled code repeats the same blocks across Gerald, Simeon and the heists. Fixes go into one helper in `CruelMastersOnlineOffline.cs` and the call sites switch to it.
- **No infinite waits:** every load or wait loop gets a timeout and a log line. SHVDN kills scripts that block.
- **Keybinds:** F2 to F12 are all taken. New actions go in the interaction menu or the phone, not on new keys. Update `scripts/ModGuide.xml`, `docs/mods_info/MODS.md` and `HOTKEYS.md` when controls change.
- **Saves:** back up `scripts/CruelMastersOnlineOfflineAssets/Save Data/` and the story save before anything that touches save logic (items 1, 2 and 21).
- **Reverse engineering:** not needed for most of this, since we have full C# source. The `reverse-engineer-anything` skill becomes useful for memory offsets in `GTA5.exe` or for studying Rockstar's `freemode` script (items 20, 21, 27 option a).
- **Commits:** one commit per shipped item or batch, in the existing style, only when the user asks.

## 6. Priority order

### Batch 1: fix what feels broken (all small)

1. **19** Quit Game in the interaction menu
2. **33** Empty mission lobby fix
3. **1** Simeon unlock after Gerald's first mission
4. **3** Fixed RP for Gerald's first mission
5. **8** Loader timeouts
6. **5** Shared cutscene helper, proven on the Simeon intro
7. **6** Roll the helper out to every intro cutscene
8. **28** Quick Job and Job List in the phone

**Test after batch 1:** start Online, open a contact lobby (data should show at once), finish Gerald's first mission once (Simeon should call, and the cutscene should fade in cleanly with the player's own character), quit from the interaction menu.

### Batch 2: customization and phone

38, 9, 10, 34, 27, 30, 35, 7, 4

### Batch 3: big systems

39, 40, 23, 24, 25, 26, then 21, 22, then 29, 20

### Later or on request

2, 11, 12, 13, 14, 15, 16, 17, 18, 31, 32
