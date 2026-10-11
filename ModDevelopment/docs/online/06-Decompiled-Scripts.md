# 6. Decompiled scripts

Rockstar's scripts decompiled into readable C-like code, with every native call named. This is the main source for understanding how an Online system really works before rebuilding it offline.

## 6.1 Where they are

The research folder lives outside the game folder and outside git: `D:\GTA FITG\GTA stuff\`.

| Path | What it is |
| --- | --- |
| `GTA-V-Decompiled-Scripts-senpai\GTA-V-Decompiled-Scripts-senpai\decompiled_scripts\*.c` | 1,156 decompiled scripts (3.4 GB), natives named (`NETWORK::NETWORK_IS_GAME_IN_PROGRESS()`) |
| `...\native_tables\*.txt` | Each script's native table as raw hashes |
| `...\scripts\*_ysc\` | The raw script files the decompile was made from |
| `...\all_script_names.txt` | Script name list |
| `GTA-V-Script-Decompiler-master\` | The original njames93 decompiler (source only, not built; not needed while the decompiled set is available) |
| `GTA V 1\893b9d-Cayo Perico Heist in SP Mod FIles 11.0 ...zip` | An existing single-player Cayo Perico port (C#), prior art for heists (roadmap item 14) |
| `GTA V 2\527cd7-PacificStandard\` | A single-player Pacific Standard heist mod (C#), prior art |
| `Extracts\Enable-All-Interiors-...` | A mod that opens Online interiors in story mode, prior art for properties |
| `Extracts\GTAONLINE-OFFLINE-4.1\` | The older offline Online mod CruelMasters replaced |
| `1cfcd8-CodeWalker30_dev46\` | A second copy of CodeWalker |

Source of the decompiled set: [calamity-inc/GTA-V-Decompiled-Scripts](https://github.com/calamity-inc/GTA-V-Decompiled-Scripts), branch `senpai`. It is Rockstar's code: never copy it into the repo or into a mod.

## 6.2 Which build it is

The download is the newest commit (game build **3889**), not this install's **3725**. **Verified** by comparing script lists: it has every one of this install's 1,143 scripts plus 13 newer ones (`fm_content_kortz_*`, `kortz_planning`, `fm_mission_controller_v3`, `fmmc_lasers`, `am_mp_mansion_art_workshop`, `mansion_art_workshop_seating`, `mp_strand_f9`).

What that means in practice:

- **Logic and flow** (what a script does, in what order, with which natives) rarely changes between two updates. Safe to learn from.
- **Global indices (`Global_2739327`), function numbers (`func_6694`) and local numbers** change with every build. Never copy them into our code; we don't use globals anyway.
- **Coordinates, model names, text labels and animation names** are usually stable, but check them against this install's own strings (`tools/ysc-dump.ps1`) before relying on them.
- For an exact match, download the commit "Update for 1.72-3725.0" (17 December 2025) from the repo's history.

## 6.3 How to search it

The files are huge (`freemode.c` is 31 MB), so search instead of opening:

```bash
cd "/d/GTA FITG/GTA stuff/GTA-V-Decompiled-Scripts-senpai/GTA-V-Decompiled-Scripts-senpai/decompiled_scripts"
grep -l "NET_GAMESERVER_BASKET_START" *.c | wc -l        # which scripts use a native
grep -n -- "-197.3405" am_mp_property_ext.c              # where a coordinate is used
grep -o "[A-Z]*::[A-Z_0-9]*" clothes_shop_mp.c | sort | uniq -c | sort -rn | head   # a script's most used natives
```

A full grep over all scripts takes one to two minutes.

## 6.4 Findings so far (2026-10-11)

All **Verified** in the build-3889 decompile; build-specific numbers are shown only to help find the code again.

**How much of Online depends on the network layer:**

| Native | Scripts using it | Meaning |
| --- | --- | --- |
| `NETWORK_SET_THIS_SCRIPT_IS_NETWORK_SCRIPT` | 431 | Script runs as a network script |
| `NETWORK_REGISTER_HOST_BROADCAST_VARIABLES` | 367 | Keeps state in host-synced memory |
| `NETWORK_REGISTER_PLAYER_BROADCAST_VARIABLES` | 361 | Keeps per-player synced state |
| `STAT_GET_INT` | 794 | Reads stats (shared helper code is compiled into most scripts) |
| `NET_GAMESERVER_BASKET_START` | 292 | Contains the server purchase flow |
| `UGC_*` | 148 | Reads or queries mission-creator content |
| `NETWORK_ACCESS_TUNABLE_INT_HASH` | 22 | Reads tunables directly; most scripts read tunables from globals that a few scripts fill |

**`freemode` is started by `maintransition`.** A helper requests the script and calls `START_NEW_SCRIPT("freemode", 35250)` (35,250 is the stack size); the content creator variant starts `"Creator"` with 28,000. `freemode` itself calls `NETWORK_SET_THIS_SCRIPT_IS_NETWORK_SCRIPT(32, false, -1)` (up to 32 players).

**How a shop purchase works on PC (`clothes_shop_mp`).** A helper returns `NET_GAMESERVER_USE_SERVER_TRANSACTIONS()` when `IS_PC_VERSION()` is true. When it is, the purchase ends any open basket, calls `NET_GAMESERVER_BASKET_START`, adds the item (`NET_GAMESERVER_BASKET_ADD_ITEM`) and checks out (`NET_GAMESERVER_CHECKOUT_START`), then waits for the result. Only when server transactions are off does it skip the basket. Spending is reported with `MONEY::NETWORK_SPENT_*` natives. Offline there is no server, so our shops charge `MPCash` directly.

**The property table (`am_mp_property_ext`).** A function switches on the property index and returns each property's entrance position: case 8 is `284.96, -159.99, 63.62`, case 12 is `-197.34, 88.11, 68.74`, case 14 is `-973.38, -1429.43, 6.68`, and so on. These match the `AM_MP_PROPERTY_EXT` trigger points in `ambient_mp.ipl` (guide 3). The script checks `NETWORK_IS_GAME_IN_PROGRESS()` in several places and has more than 11,000 lines that use globals, which is why it can't simply run offline. Next step for garages (roadmap 39): read this script's entrance, buy and enter flow and extract the full index-to-entrance-to-interior table.

## 6.5 Next deep dives, in roadmap order

| Roadmap item | Read first |
| --- | --- |
| 9, 10, 11 shops | `clothes_shop_mp`, `hairdo_shop_mp`, `tattoo_shop`, `shop_controller` |
| 27 internet | `appinternet` (site list, vehicle site layout) |
| 34 map cards | `pausemenu_multiplayer`, `freemode` blip handling |
| 39, 40 garages and apartments | `am_mp_property_ext`, `am_mp_property_int`, `am_mp_garage_control` |
| 41 car tracking | `freemode` personal vehicle code (search `PERSONAL_VEHICLE`, Mors Mutual labels) |
| 4.5 UGC interpreter | `fm_mission_controller` (how rules and objectives in a UGC file are read) |
| 14 heists | the Cayo and Pacific Standard SP mods above, then `fm_content_island_heist` |
