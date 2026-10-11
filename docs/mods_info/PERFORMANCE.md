# Performance and stability

How to keep this heavily modded install running on this PC without freezes. Written 2026-10-11 from the hardware, the graphics settings and the Windows event logs.

## The PC

| Part | What it is | What it means |
| --- | --- | --- |
| CPU | Intel Core i5-8350U, 4 cores and 8 threads, a 15 W laptop chip | Slows itself down when hot: Windows logged 29 "processor speed limited by firmware" events in two weeks |
| Graphics | Intel UHD Graphics 620 (integrated) | Below GTA V's recommended GPU. It has no memory of its own and borrows from system RAM |
| RAM | 16 GB, shared with the graphics | GTA, the graphics, every mod and Windows all fit in the same 16 GB |
| Disk | 512 GB SSD; C: 25 GB free (10 GB pagefile), D: 34 GB free | Keep at least 20 GB free on C: for the pagefile |

**What went wrong before:** between 5 and 10 October Windows recorded 5 sudden shutdowns. Four of them have the power-button flag and no bluescreen, so the machine froze and was switched off by hand. That usually means memory ran out or the laptop overheated. GTA itself also stopped twice on 9 October with its own fatal error (`0x80000003`, same offset both times), which is typical of running out of memory or streaming space.

## Graphics settings (changed 2026-10-11)

File: `Documents\Rockstar Games\GTA V\settings.xml`. The previous file is kept as `settings.xml.bak-2026-10-11`; copy it back over `settings.xml` to undo.

| Setting | Before | Now |
| --- | --- | --- |
| Shader quality | Very High | Normal |
| Shadow quality | Very High | Normal |
| Soft shadows | on | off |
| Reflection quality | High | Normal |
| Reflection MSAA | 4x | off |
| SSAO | Normal | off |
| Anisotropic filtering | 4x | off |
| Texture quality | High | Normal (frees shared memory) |
| Particle quality | Very High | Normal |
| Water and grass quality | High | Normal |
| Screen-space anti-aliasing | on | off |
| VSync | on (59 FPS) | **half (about 30 FPS)**: less heat, so less throttling |

Kept as they were: 1280×768, view distance 0.2, population density 0.1, FXAA on, post FX normal, motion blur off.

The game can rewrite this file when settings are changed in its menu. If the game feels too slow, raise texture quality last.

## Mod profiles

`tools/mod-profile.ps1` switches mod sets before launch. It renames mods to `.disabled` and back, and changes a few settings after saving the originals as `.story`, so nothing is lost. Close the game first.

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File tools\mod-profile.ps1 online-lite   # CruelMasters, police mods kept with lighter settings
powershell -NoProfile -ExecutionPolicy Bypass -File tools\mod-profile.ps1 online        # CruelMasters, lightest (police mods off)
powershell -NoProfile -ExecutionPolicy Bypass -File tools\mod-profile.ps1 story         # everything on, normal settings
powershell -NoProfile -ExecutionPolicy Bypass -File tools\mod-profile.ps1 status        # show what is on
```

Try `online-lite` first. If the game still freezes, use `online`.

### `online-lite`

Keeps SixStarResponse, SSRPlus, Better Chases+ and the RDE plugin on, turns off only Cop_Arrest and HomeInvasion, and switches to these lighter settings:

| File | Normal | Lite | Why it helps |
| --- | --- | --- | --- |
| `SixStarResponse\SixStarResponse.ini` | Max units per star 2, 3, 5, 7, 10, 15, 17, 18, 19, 20 | 1, 2, 3, 4, 6, 8, 9, 10, 10, 10 | Fewer police peds and cars alive at once |
| | `AmbientBackup=1` (up to 50 extra cops for NPC fights) | `0` | No police spawned for fights you are not in |
| | `DespawnImmunityTime=20` | `10` | Units left behind are removed sooner |
| | `LogToFileLevel=VERBOSE` | `WARN` | Stops writing every event to disk |
| `SSRPlus.ini` | `CopAdditionalSpeech`, `ManageSearchlights` on | off | Less audio and per-car work; the prison and Cayo fixes stay on |
| `BetterChasesConfig.xml` | `CopsManageTraffic` true, arrest warrants on | false, off | No traffic steering and no constant "spotted" checks; chase escalation stays |

### `online`

| Turned off by `online` | Why |
| --- | --- |
| `scripts\SixStarResponse.dll` (32 scripts) and `RDE_Auxiliary.asi` | Heavy police spawning; clashes with CruelMasters missions, which turn the police off |
| `scripts\SSRPlus.dll` | Add-on for SixStarResponse |
| `scripts\Better Chases+.dll` | Police chase overhaul, same clash |
| `scripts\Cop_Arrest.dll` | Police arrest mod |
| `scripts\HomeInvasion.dll` | Story-mode house robberies |

Switch back to `story` before committing to git: git sees disabled DLLs and lite settings as changes. `*.disabled` and `*.story` copies are ignored.

**Map packs can't be switched by the tool.** `vremastered`, `forest_n` and `forest_s` are the heaviest add-on packs for memory. Turning them off means commenting out their lines in `dlclist.xml` inside `Mods\update\update.rpf` with OpenIV (for example `<!--<Item>dlcpacks:/vremastered/</Item>-->`), then regenerating `Mods/MANIFEST.md`. Try that if freezes continue after the steps above.

## Your checklist before playing

- Plug the laptop in, and set Windows power mode to **Best performance** (it is on Balanced).
- Put the laptop on a hard, flat surface or a cooling pad, never on a bed or lap.
- Close browsers, VS Code, Discord and other apps.
- Keep at least 20 GB free on C:.
- Update the Intel graphics driver (yours is 31.0.101.2145) with Intel Driver & Support Assistant.
- If the game freezes, wait a minute before holding the power button; GTA sometimes recovers once streaming catches up.

## What we do in our own mods

- Never read files or rebuild menus every frame (the per-frame save read in CruelMasters was removed on 2026-10-11).
- Every wait has a timeout, so a script can't hang the game.
- Keep spawned peds and vehicles capped and deleted when no longer needed (AI players plan, roadmap section 5).
- A timing log to find expensive CruelMasters scripts is on the roadmap (item 49).
