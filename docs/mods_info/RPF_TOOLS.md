# Looking inside RPF archives

GTA V keeps its files inside `.rpf` archives. This guide covers two ways to see what's in them:

1. **`tools/rpf.ps1`**: a read-only script in this folder. It reads the add-on packs completely, and the files you've added or replaced with OpenIV in the `Mods/` archives. It lists everything else. No downloads, no keys. Claude uses this one.
2. **CodeWalker**: a free, open-source GUI that also opens **encrypted** archives and files (the vanilla game files) and converts compiled assets to XML.

Neither of them is for editing. Archive edits still go through OpenIV, and only in `Mods/` (see the main [`README.md`](../../README.md) section 4).

## What is encrypted?

GTA V encrypts at two levels:

- **The archive's file list.** The fourth group of 4 bytes in the header says whether it's encrypted. `OPEN` means it isn't.
- **Each file inside.** Even in an `OPEN` archive, Rockstar's own files stay encrypted one by one. Files that OpenIV adds or replaces are stored unencrypted.

So `rpf.ps1` can always **list** an `OPEN` archive. It can **extract** only the unencrypted files: add-on packs, plus whatever you've replaced with OpenIV. Checked on 2026-10-09:

| Archive | File list | Files inside | `rpf.ps1` | CodeWalker |
| --- | --- | --- | --- | --- |
| Add-on packs (`Mods/update/x64/dlcpacks/*/dlc.rpf`) | `OPEN` | not encrypted | List and extract everything | Yes |
| `Mods/update/update.rpf` | `OPEN` | 900 of 1,187 entries encrypted. Your edits (such as `dlclist.xml`, `gameconfig.xml`, `weapons.meta`, weather and lens-flare XML) are readable | List all, extract your edits | Yes |
| `Mods/update/update2.rpf`, `Mods/common.rpf`, `Mods/x64a.rpf` | `OPEN` | mostly encrypted, your edits readable | List all, extract your edits | Yes |
| Vanilla `update/update.rpf` | `OPEN` | mostly encrypted (`dlclist.xml` is readable) | List all, extract a few | Yes |
| Vanilla root `common.rpf`, `x64a.rpf` to `x64w.rpf` | encrypted | encrypted | No | Yes |

Encrypted entries show `(encrypted)` in the `list` output, and `extract` skips them with a warning.

---

## 1. `tools/rpf.ps1` (read-only, built in)

### What it does

- **`list`** prints every entry in an archive, including what's inside nested `.rpf` archives. Each line shows the kind, the size and the path inside the archive.
- **`extract`** copies plain files (`.xml`, `.meta`, `.dat`, `.gxt2`, ...) out to a folder.
- Compiled assets (kind `resource`: `.ytd`, `.yft`, `.ydr`, `.ymap`, `.ytyp`, ...) are listed but never extracted. Use CodeWalker to turn them into XML.
- It opens the archive read-only and never changes it. It's safe to run while OpenIV has the file open.

### Commands

Run from the game folder. From **PowerShell**:

```powershell
# List everything in an add-on pack
powershell -NoProfile -ExecutionPolicy Bypass -File tools\rpf.ps1 list Mods\update\x64\dlcpacks\urus2018\dlc.rpf

# List only matching paths (wildcards, case-insensitive)
powershell -NoProfile -ExecutionPolicy Bypass -File tools\rpf.ps1 list Mods\update\update.rpf "*dlclist*"

# Extract the meta files of a vehicle pack to a folder
powershell -NoProfile -ExecutionPolicy Bypass -File tools\rpf.ps1 extract Mods\update\x64\dlcpacks\gxetron\dlc.rpf "*.meta" -Out "$env:TEMP\rpf\gxetron"

# Extract dlclist.xml from the modded update.rpf
powershell -NoProfile -ExecutionPolicy Bypass -File tools\rpf.ps1 extract Mods\update\update.rpf "common/data/dlclist.xml" -Out "$env:TEMP\rpf\update"
```

From **Git Bash** it's the same command with forward slashes.

| Argument | Meaning |
| --- | --- |
| `list` / `extract` | What to do. |
| archive path | The `.rpf` file to open. |
| pattern | Optional wildcard matched against the path inside the archive, using `/` as separator. Default `*`. Examples: `"*.meta"`, `"*/data/*"`, `"x64/vehicles.rpf/*"`. |
| `-Out <folder>` | Where `extract` writes files, keeping the folder structure. Default: `%TEMP%\rpf-extract\<archive name>`. Don't extract into the game folder. |
| `-NoRecurse` | Don't look inside nested `.rpf` archives. |

`-ExecutionPolicy Bypass` only applies to that one command. It lets an unsigned local script run without changing your system settings.

### Example output

```text
file             5,999  data/vehicles.meta
archive     75,106,816  x64/vehicles.rpf
resource     9,206,807  x64/vehicles.rpf/urus2018.ytd
36 of 36 entries matched, 0 of them encrypted (contents not readable, see docs/mods_info/RPF_TOOLS.md)
```

### What it's good for

- Checking that `dlclist.xml` lists every add-on pack.
- Reading the real model names from a pack's `vehicles.meta` (for `menyooStuff/AddedVehicleModels.xml`).
- Reading a pack's `handling.meta`, `carvariations.meta`, `content.xml` and `setup2.xml` before you edit them in OpenIV.
- Reading the files you've already replaced in the `Mods/` archives. For the original vanilla version of a file, use CodeWalker.

---

## 2. CodeWalker (for encrypted archives and compiled assets)

CodeWalker is a free, open-source GTA V tool by dexyfex. It has a 3D map viewer and an **RPF Explorer**. It reads the decryption keys from your own `GTA5.exe`, so it can open every archive in the game. It can also export compiled assets (`.ymap`, `.ytyp`, `.ymt`, `.ytd` and more) as XML or images.

### 2.1 Download

1. Get it from one of the two official places:
   - GitHub: <https://github.com/dexyfex/CodeWalker> (Releases page)
   - GTA5-Mods: search for "CodeWalker" on <https://www.gta5-mods.com/tools>
2. Download the latest release `.zip`. Don't take it from other sites, since game tools are a common way to spread malware.
3. The release page lists the .NET runtime it needs. Install that from Microsoft if Windows asks for it when you first start CodeWalker.

### 2.2 Install

1. Extract the zip into its **own folder outside the game folder**, for example `D:\Tools\CodeWalker\`. Keeping it out of `D:\Games\Grand Theft Auto V Legacy` stops git and the ASI loader from seeing its files.
2. Don't put any CodeWalker files in the game root or `scripts/`. It isn't a mod.

### 2.3 First start

1. Run `CodeWalker.exe`. A small launcher window opens with a list of tools.
2. It asks for the GTA V folder. Pick `D:\Games\Grand Theft Auto V Legacy`.
3. If it asks which version, choose **Legacy**, not Enhanced. This install is GTA V Legacy (`GTA5.exe` 1.0.3725.0).
4. On the first run it scans `GTA5.exe` for the decryption keys. This can take a minute. Later starts are faster.
5. If it says it can't find the keys, the usual cause is a game update newer than your CodeWalker build. Download the newest CodeWalker release and try again.

### 2.4 Browse an archive (RPF Explorer)

1. In the launcher, open **RPF Explorer**.
2. The left side shows the game folder tree. Expand it like a normal file browser. Archives (`.rpf`) open like folders, including nested ones.
3. Useful places:

   | What | Where |
   | --- | --- |
   | Vanilla vehicle meta | `update\update.rpf\common\data\levels\gta5\vehicles.meta`, plus `update\update.rpf\dlc_patch\<dlc>\common\data\levels\gta5\vehicles.meta` for DLC cars |
   | Vanilla handling | `update\update.rpf\common\data\handling.meta` |
   | DLC list | `update\update.rpf\common\data\dlclist.xml` |
   | Map files (`.ymap`, `.ytyp`) | `x64*.rpf\levels\gta5\...` and DLC packs |
   | Textures (`.ytd`) | Inside the `.rpf` that holds the model |
   | Your modded copies | `Mods\...` (same layout as the vanilla files) |

4. Use the **search box** at the top to find a file by name across every archive, for example `handling.meta` or `urus2018`.
5. Double-click a file to view it. Text files open as text. Many compiled files open as XML. Textures open in a texture viewer.

### 2.5 Export files

1. Right-click a file in RPF Explorer.
2. Choose one of:
   - **Export / Extract (raw)**: the file exactly as stored. Use this for `.meta` and `.xml` files.
   - **Export XML**: converts a compiled asset (`.ymap`, `.ytyp`, `.ymt`, `.ycd` and others) into readable XML. Use this when you want Claude to read or change one.
   - For textures (`.ytd`), the texture viewer can save each texture as `.dds` or `.png`.
3. Save into a folder **outside the game folder**, for example `D:\GTA_exports\`. Keep the original folder names in the path so it's clear where each file came from.
4. Tell Claude the folder path. Claude can read and edit the exported XML there.

### 2.6 Getting a change back into the game

CodeWalker's RPF Explorer can also edit archives, but in this install **all archive edits go through OpenIV in `Mods/`**:

1. Let Claude edit the exported XML or `.meta` file.
2. For a compiled asset, import the XML back to the binary format in CodeWalker (right-click a folder in an editable location, **Import XML**), or use OpenIV's XML import.
3. Put the result into the matching archive under **`Mods/`** with OpenIV in Edit mode.
4. Run `bash tools/update-mods-manifest.sh` and test.

### 2.7 Safety rules

- **Never edit or save into the vanilla archives** in the game root or `update/`. CodeWalker has an edit mode in RPF Explorer. Leave it off when you're browsing the vanilla files.
- Close the game before you change anything in `Mods/`. Reading while the game runs is fine.
- Back up any `Mods/` archive before changing it (see `MOD_TRACKING.md`).
- Single player only. Nothing here changes that.

### 2.8 Optional: let Claude read encrypted archives directly

CodeWalker's file-reading code is a separate library (`CodeWalker.Core`) in the same GitHub repository. The .NET SDK is installed on this PC, so Claude could build a small read-only command-line tool on top of it. It would work like `rpf.ps1` but for the encrypted vanilla archives too. It loads the keys from `GTA5.exe` the same way the GUI does.

This needs the CodeWalker source downloaded from GitHub. Ask Claude for it when you want it, and it will ask before downloading anything.
