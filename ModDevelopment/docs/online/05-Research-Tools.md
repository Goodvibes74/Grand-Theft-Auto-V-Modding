# 5. Research tools

How the facts in these guides were extracted, how to repeat it after a game update, and what the next research steps need. All tools are read-only: they decrypt in memory with the CodeWalker.Core library that ships with CodeWalker in `1cfcd8-CodeWalker30_dev46\`, and never write to an archive.

## 5.1 The tools

| Tool | What it does | Time |
| --- | --- | --- |
| `tools/rpf-cw.ps1` | Lists any archive, including Rockstar's encrypted ones and nested archives, and extracts matching plain files (`.xml`, `.meta`, `.ugc`, `.ipl` ...) | Seconds to a minute per archive |
| `tools/ysc-dump.ps1` | Decrypts every compiled script and writes its header numbers and string table to one text file per script, plus `_summary.tsv` | About 10 minutes for all 1,143 |
| `tools/dlc-scan.ps1` | Inventories all 89 DLC packs: names, vehicles, file counts (`ModDevelopment/docs/reference/DLC-Packs.md`) | About 5 minutes |
| `tools/rpf.ps1` | The older, dependency-free viewer for unencrypted archives (`docs/mods_info/RPF_TOOLS.md`) | Seconds |

Examples (PowerShell, from the game folder):

```powershell
# Online stats definitions
powershell -NoProfile -ExecutionPolicy Bypass -File tools\rpf-cw.ps1 -Archive update\update.rpf -Pattern "common\data\mpstats*" -ExtractTo "$env:TEMP\gta\data"

# All 1,001 local mission files
powershell -NoProfile -ExecutionPolicy Bypass -File tools\rpf-cw.ps1 -Archive update\update2.rpf -Pattern "common\data\ugc\*" -ExtractTo "$env:TEMP\gta\ugc"

# Strings of one script
powershell -NoProfile -ExecutionPolicy Bypass -File tools\ysc-dump.ps1 -Out "$env:TEMP\gta\ysc" -Only "am_mp_property_ext"
```

Keep the output outside the repo (a temp or scratch folder). It is Rockstar's data and must never be committed.

## 5.2 How the script reader works

CodeWalker decrypts a script entry and returns its system memory block (already decompressed). The script header (64-bit PC layout):

| Offset | Field |
| --- | --- |
| `0x00` | vtable pointer |
| `0x08` | page map pointer |
| `0x10` | code page table pointer |
| `0x18` | globals signature |
| `0x1C` | code size |
| `0x20` | parameter count |
| `0x24` | statics count |
| `0x28` | globals count (low 18 bits) and global block (high bits) |
| `0x2C` | natives count |
| `0x30`, `0x38`, `0x40` | statics, globals and natives pointers |
| `0x58` | name hash |
| `0x60` | script name pointer |
| `0x68` | string page table pointer |
| `0x70` | strings size |

Pointers are `0x50000000`-based offsets into the block. Strings are stored in pages of `0x4000` bytes as null-terminated text. The reader prints all of them; they include text labels, animation dictionaries, IPL and interior names, audio names, script names (which give the reference graph in guide 2), debug messages and cloud content IDs.

## 5.3 Next steps that need more tooling

1. **Decompiling scripts into readable code.** Strings show *what* a script touches; decompiling shows *how*. This needs a GTA V script decompiler (several community open-source ones exist). It is a third-party download, so it is installed only with the user's approval, into its own folder outside the game directory, and its output stays out of the repo.
2. **Naming the native calls.** In PC scripts the native table holds hashes for this specific build, stored rotated (each entry rotated left by `(code size + index) & 63` bits). Turning them into names needs a crossmap for build 3717 from the community native database. With it, each script's native list becomes readable (for example which scripts call `NET_GAMESERVER_*`).
3. **Mapping the UGC format.** Plain JSON, so only careful reading is needed: start with a few `re_` files and document every key the subset interpreter needs (guide 4, section 4.5).

## 5.4 After a game update

1. Check `ScriptHookV.log` first (the usual update breakage).
2. Re-run `tools/dlc-scan.ps1` for new packs and update `DLC-Packs.md`.
3. Re-run `tools/ysc-dump.ps1` and compare `_summary.tsv` with the previous run: new script names show new content; size changes show what Rockstar changed.
4. Re-extract the UGC folder and compare the file list.
