# 4. Making Online fully offline

How to get GTA Online's content (all DLCs) working in single player, with no Rockstar servers. It builds on guides 1 to 3 and turns them into an architecture and a plan. Single player only: none of this is for use in GTA Online.

## 4.1 Why Rockstar's Online scripts can't simply run offline

People's first idea is to start `freemode` in story mode. It doesn't work, for reasons that come from guide 1:

1. **No session.** `freemode`, the property scripts, the mission controllers and most `am_`, `gb_` and `fm_content_` scripts are *network scripts*. Without a session they can't register broadcast data, `NETWORK_IS_GAME_IN_PROGRESS` is false, and they stop or wait. **Verified** in the decompiled code: 431 scripts are network scripts (guide 6).
2. **No stats.** On start, Online loads the character from server stats. Offline, the load fails and the transition stops (the `HUD_CLOUDFAILMSG` and `HUD_RETRYSTAT` messages in `maintransition`). **Verified** (strings); **Known** (behaviour).
3. **No transactions.** Every purchase and payout waits for a server basket checkout (`NET_GAMESERVER_*`) that never answers. **Verified** for PC in `clothes_shop_mp` (guide 6).
4. **No tunables and no cloud jobs.** Prices, switches and most job files come from the cloud. **Known.**
5. **Globals are shared and fragile.** Online scripts depend on each other through thousands of globals whose indices change with every game update. Faking them is a moving target. **Known.**

Getting past points 1 to 4 would mean emulating Rockstar's servers or patching the network layer, which is not something we do. So the server side has to be rebuilt, not tricked.

## 4.2 The options

| Option | What it is | Verdict |
| --- | --- | --- |
| A. Rebuild in our own C# (the CruelMasters approach) | Our scripts recreate Online's systems (rank, cash, shops, properties, missions, lobby) and reuse Rockstar's assets and data | **Recommended.** Legal, stable across updates (natives rarely change), and fully under our control |
| B. Run Rockstar's Online scripts in story mode | Start `freemode` and friends and patch around the network | Not viable: needs network-layer patching, breaks every update, unstable |
| C. A private multiplayer platform | Separate client and server software built for roleplay servers | Out of scope: it is not offline single player and it is a different game client |

## 4.3 Recommended architecture

Six layers, from the bottom up. Each one replaces something the server or the network gave Online, and each one is reused by the layers above it.

| Layer | Replaces | What it does | Today (CruelMasters) |
| --- | --- | --- | --- |
| L0. Online world | The session start | Enter "Online mode" from story mode: Online IPLs and interiors, freemode character model, MP map state, killing the story scripts that clash | Done (`ON_ENTER_MP`, 98 IPLs, L key) |
| L1. Save | Server stats | One save for everything Online keeps in stats: character, rank, cash, bank, unlocks, properties, vehicles, mission flags, business stock | Partial (ini plus XML files) |
| L2. Economy | Server transactions and tunables | Local cash and bank, prices (from the shop catalogues where possible), payouts, an ini of tunable-like values | Partial (`MPCash`, fixed prices) |
| L3. World systems | `am_mp_*`, shop scripts, apps | Properties from the 83 entrance points, garages, shops from the clothing catalogues, phone apps, interaction menu | Partial (interaction menu, phone, dealership, mod shop) |
| L4. Content | Cloud jobs and Online mission scripts | Contact missions, business missions, heists, freemode events | Partial (Gerald, Simeon, one heist template) |
| L5. Lobby | Other players | Simulated AI players (roadmap section 5) | Companions only |

Rules that keep it maintainable:

- **Data first.** Wherever Rockstar left data on disk (guide 3), load it instead of hard-coding: clothing catalogues, outfits, vehicles, entrances, UGC coordinates.
- **One shared helper per pattern** (cutscenes, lobbies, mission end, loading), as started in batch 1 of the roadmap.
- **No globals, no memory hacks** unless there is no native for the job; they break with every game update.
- **Everything logged** to `scripts/CruelMastersOnlineOffline.log` so a play session can be read back.

## 4.4 Gap table: Online systems and how to rebuild them

| Online system | Rockstar scripts | Data on disk | CruelMasters today | Plan (roadmap item) |
| --- | --- | --- | --- | --- |
| Enter Online, map state | `maintransition`, `freemode` | IPL lists | Works | Keep; add story switching (21, 22) |
| Character creator | `maintransition` | Head blends, clothing | Works | Plastic surgeon (12) |
| Rank and RP | `freemode`, `mp_unlocks` | Stats names | Works | Keep |
| Cash, bank, prices | `freemode`, server | Clothing and mod prices | Works with fixed prices | Prices from catalogues (9, 35) |
| Interaction menu | `am_pi_menu` | | Works | Quit Game done (19); claim vehicle (38) |
| Phone and apps | `cellphone_controller`, `app*` | | Contacts, texts, camera, Quick Job | Internet (27), contacts (30), settings (31) |
| Clothes, barber, tattoo | `clothes_shop_mp`, `hairdo_shop_mp`, `tattoo_shop` | `*_shop.meta` catalogues | Wardrobe spot only | 9, 10, 11 |
| Vehicles and dealership | `appinternet` sites | 581 DLC models | 175 models up to 2014 | 35, 27 |
| Personal vehicle, tracking | `freemode` | | One saved car | 38, 41 |
| Garages and apartments | `am_mp_property_ext/int` | 83 entrances, interiors | None | 39, 40 |
| Businesses (CEO, MC, bunker, nightclub ...) | `gb_*`, `fm_content_*`, `am_mp_*` | UGC preps and sells, interiors | None | New items after 40 |
| Contact missions | `fmmc_launcher`, `fm_mission_controller` | 3 tutorial UGC files; rest on the cloud | Gerald and Simeon (hand-written) | 1, 2, 6 |
| Heists | `fm_mission_controller(_2020)`, `gb_casino_heist`, `fm_content_island_heist` | Cayo finale UGC, casino preps UGC | One custom template | 14 |
| Freemode events | `am_*`, `fm_content_*` random events | 180 `re_` UGC files | None | New item: events from `re_` files |
| Job lobby (corona) | `fmmc_launcher` | | Works (fixed) | Map cards (34) |
| Pause menu | `pausemenu_multiplayer` | | Online menu, Quit added | 20 |
| Other players | the session | | Companions | AI phases 42 to 48 |

## 4.5 Playing the local UGC files

The 1,001 local mission files are the biggest shortcut available, so they deserve their own note.

- **What they give:** spawn lists (peds, vehicles, objects, props), locations, rules and objectives, end conditions, and the title.
- **What they need:** an interpreter, our own small version of `fm_mission_controller`. The full controller is 6 MB of bytecode, so a complete copy is not realistic. A **subset interpreter** is: load a file, spawn its entities at their positions, set peds hostile or friendly, and support the common objectives (go to, kill, collect, deliver, survive).
- **Plan:** a research step first (map the JSON keys for the simplest category, the `re_` random events), then a prototype that plays one file end to end. If it works, each category becomes content almost for free. This is a new roadmap candidate, after the batch 2 items.

## 4.6 What to research next

1. **Decompile the key scripts** (guide 5, section 5.3) for the systems we build next: `am_mp_property_ext` and `am_mp_property_int` before garages; `clothes_shop_mp` before the clothes shop; `fmmc_launcher` before more lobbies. Reading Rockstar's real flow beats guessing it.
2. **Map the UGC JSON format** on a handful of `re_` files.
3. **Collect the clothing catalogues** from every DLC pack into one table for the shop.
4. **Extract the 83 property entrances** with their interior types into a data file for garages.
