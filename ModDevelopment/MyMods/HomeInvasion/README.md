# HomeInvasion

Rob houses around the map (76 entry points, red blips). Walk to a marker with no wanted level, press E to enter, grab the loot, avoid waking the residents. This is the original mod (Josh, 2019), decompiled with ILSpy and extended with configurable police behaviour.

- **Language and API:** C#, ScriptHookVDotNet **v2** (the original's API). The project removes the shared SHVDN v3 and LemonUI references and uses `ScriptHookVDotNet2.dll` and `scripts/NativeUI.dll`.
- **Build:** `dotnet build -c Release ModDevelopment/MyMods/HomeInvasion/HomeInvasion.csproj` (close the game first; it copies the DLL and PDB into `scripts/`).
- **Config:** `scripts/HomeInvasion.xml`. The new `<Cops>` block controls the wanted level, the dispatch delay, whether the mod spawns its own cops, the SWAT chance, count, armor and weapons, the second-cop chance, and how likely a witness is to phone the police. Every entry is optional and the defaults equal the original behaviour.
- **With RDE installed:** set `SpawnInteriorUnits` to `false` if you see doubled units. RDE then handles the response and the mod only sets the wanted level.
- **Original files:** `original/HomeInvasion.dll` and `original/HomeInvasion.xml` are the untouched 2019 files. Copy them back into `scripts/` to undo everything.

## What changed from the original

| Original (hard-coded) | Now |
| --- | --- |
| Wanted level 2 | `WantedLevel` |
| 5 to 20 s before units arrive | `DispatchDelayMinMs` / `DispatchDelayMaxMs` |
| Always spawns its own units | `SpawnInteriorUnits` |
| 1 in 4 SWAT, 2 SWAT, armor 100, SMG | `SwatChancePercent`, `SwatCount`, `SwatArmor`, `SwatWeapon` |
| Pump shotgun cop, 50% second cop with a pistol | `CopWeapon`, `SecondCopChancePercent`, `SecondCopWeapon` |
| 1 in 6 witness phones the police | `CallPolicePercent` (17) |

Not tested in game yet. The original code's remaining logic is unchanged (decompiler output).
