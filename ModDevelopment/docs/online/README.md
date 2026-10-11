# GTA Online, understood for offline play

These guides explain how GTA Online is built inside this install (game build 1.0.3725.0, Legacy, all DLCs up to December 2025) and what it takes to run its content fully offline in single player. They are the foundation for CruelMasters Online Offline and for its roadmap (`ModDevelopment/MyMods/CruelMastersOnlineOffline/ROADMAP.md`).

Everything marked **Verified** was read from this install's own files on 2026-10-11 with the read-only tools in `tools/` (CodeWalker.Core decrypts in memory; nothing was written to an archive). Statements marked **Known** come from general knowledge of the game and the modding community and should be checked before they are relied on.

## The guides

| # | Guide | What it answers |
| --- | --- | --- |
| 1 | [How Online works](01-How-Online-Works.md) | The layers of GTA Online: session, scripts, globals, stats, transactions, tunables, cloud content, and how they depend on Rockstar's servers |
| 2 | [Script catalog](02-Script-Catalog.md) | All 1,143 compiled scripts, grouped (core, properties, freemode events, content missions, organisation work, jobs, apps, shops), with what each group does |
| 3 | [Online data files](03-Online-Data-Files.md) | The data Online reads that is on disk: 1,001 local mission files, stats definitions, clothing shop catalogues, preset outfits, property entrances, vehicle mods, DLC packs |
| 4 | [Making it offline](04-Making-It-Offline.md) | Why Rockstar's Online scripts can't simply be run offline, the options, the recommended architecture, and a system-by-system gap table mapped to the roadmap |
| 5 | [Research tools](05-Research-Tools.md) | How the facts were extracted, how to repeat it after a game update, and the next research steps |

## The short version

1. **All of Online's logic is script.** 1,143 compiled scripts live in `update\update2.rpf\x64\levels\gta5\script\script_rel.rpf` (plus 4 Pilot School scripts in `x64w.rpf`). About 560 of them are Online-only. The biggest is `freemode` (7.5 MB of bytecode, 2,798 native calls, 25,876 strings). **Verified.**
2. **DLC packs bring assets, not logic.** None of the 89 DLC packs contains a script. They add vehicles, clothing, maps, interiors, cutscenes and metadata. The code for every DLC's missions and businesses is already in `script_rel.rpf`. **Verified.**
3. **Online state lives on Rockstar's servers.** 17,933 Online stats are defined in `mpstatssetup.xml`, and 13,630 of them are marked `ServerAuthoritative`. Money changes go through server "basket" transactions (`NET_GAMESERVER_*`), prices and switches come from cloud tunables, and most jobs are downloaded from the cloud by ID (575 distinct content IDs are hard-coded in the scripts). **Verified** (definitions, natives, IDs); **Known** (runtime behaviour).
4. **A lot of content is on disk anyway.** 1,001 mission-creator files (`.ugc`, JSON) ship in `update2.rpf`: freemode random events, salvage, dispatch, business preps, the tutorial missions and the Cayo Perico finale. Clothing catalogues with prices, 3,868 preset outfits and the 83 property entrance points are on disk too. **Verified.**
5. **So "fully offline" means rebuilding the server's job and the network glue in our own C#,** while reusing Rockstar's assets and data: interiors, cutscenes, animations, clothing data, mission files and entrance points. That is what CruelMasters does in a small way today; guide 4 lays out how to do it for everything.
