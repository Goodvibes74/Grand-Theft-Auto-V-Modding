# Decompiling script DLLs

Most SHVDN mods are .NET assemblies (`scripts/*.dll`) with no source code shipped. A decompiler turns them back into readable C# so you can see how a mod works, change its settings, or fix it after a library update. We used this for [HomeInvasion](../../ModDevelopment/MyMods/HomeInvasion/README.md) and [GTAOnlineOffline](../../ModDevelopment/MyMods/GTAOnlineOffline/README.md).

This works only for .NET mods. `.asi` files (Menyoo, TrainerV, openCameraV, RDE plugins) are native C++ and cannot be turned back into source this way. Check first: a .NET DLL has `Found 1 script(s) in <name>.dll` in `ScriptHookVDotNet.log`.

**Respect the author.** Decompile for your own use, to learn, repair or tweak a mod you installed. Do not re-upload someone else's mod, with or without changes, and keep their credit in the readme.

## What you need

- The .NET 8 (or newer) runtime, which the .NET SDK you already use for `ModDevelopment/` includes.
- ILSpy's command-line tool, `ilspycmd`. It installs from NuGet and needs internet once.

Install it into a folder of its own, so nothing is changed system-wide:

```powershell
dotnet tool install ilspycmd --tool-path "$env:TEMP\ilspy"
```

For a window instead of the command line, use the ILSpy app (`https://github.com/icsharpcode/ILSpy/releases`) or dnSpy. Both show the same C#. The steps below use the command line because it writes a ready-to-build project.

## Steps

1. **Back up the DLL.** Copy it somewhere safe before you change anything (`name.dll.bak`, or an `original/` folder next to your project). Mods that are not in git can't be recovered otherwise.
2. **Close the game.** A loaded DLL is locked by Windows.
3. **Decompile into a new, empty folder.** Run from the game root and **pass the reference folders with `-r`**:

   ```powershell
   & "$env:TEMP\ilspy\ilspycmd.exe" -p -o "$env:TEMP\decompiled\MyMod" -r . -r scripts "scripts\MyMod.dll"
   ```

   - `-p` writes a project (`.csproj` plus one `.cs` file per class).
   - `-o` is the output folder.
   - `-r .` and `-r scripts` tell it where `ScriptHookVDotNet2/3.dll`, `LemonUI.SHVDN3.dll`, `NativeUI.dll` and the other libraries are.
   - **Do not skip `-r`.** Without it ILSpy cannot resolve the types and writes ugly code (`InputArgument.op_Implicit(true)`, `(Entity)(object)x`) that does not compile. With it the code reads normally.
4. **Read it.** Start with the class that extends `Script`: its constructor (what it hooks), `OnTick` (what runs every frame) and `OnKeyDown` (the keys). Searching the output for `Keys.`, `Control.`, `WantedLevel`, `.ini` or `.xml` quickly shows keybinds, config files and what it changes.
5. **Make a project of your own.** Copy the `.cs` files into `ModDevelopment/MyMods/<Name>/` with a short `.csproj` and put the untouched DLL in `original/`. Look at `MyMods/HomeInvasion/HomeInvasion.csproj` (SHVDN v2 mod) and `MyMods/GTAOnlineOffline/GTAOnlineOffline.csproj` (v3 mod) as templates. Add the project to `ModDevelopment.slnx`.
6. **Build.** `dotnet build -c Release ModDevelopment/MyMods/<Name>/<Name>.csproj`. The build copies the DLL into `scripts/`.
7. **Test, then read the logs.** Launch the game and check `ScriptHookVDotNet.log`.

## Which SHVDN version?

Open the decompiled `.csproj`. A reference to `ScriptHookVDotNet2` means a v2 mod: in your project remove the shared `ScriptHookVDotNet3` and `LemonUI.SHVDN3` references and add `ScriptHookVDotNet2.dll`, as `HomeInvasion.csproj` does. A reference to `ScriptHookVDotNet3` or `ScriptHookVDotNet` (with LemonUI or NativeUI) is v3 and works with the shared settings.

## Problems you will meet

| Symptom | Cause and fix |
| --- | --- |
| Hundreds of `op_Implicit` or `cannot explicitly call operator` errors | Decompiled without `-r`. Delete the output and run again with `-r . -r scripts`. |
| `CS0619 ... is obsolete` as an error | The mod was written for an older library. Use what the message says: for LemonUI, `Open()` and `Close()` become `Visible = true` and `Visible = false`. A line that only styles the UI can be commented out. |
| The script crashes at runtime with `InvalidOperationException` from `LemonUI` | An old LemonUI silently ignored bad values and 2.x throws. Wrap the call in `try/catch` (see `SafeMenu.cs` in `GTAOnlineOffline`). |
| Hash values like `(Hash)8938107252012227927L` instead of native names | Normal. ILSpy cannot know the native name. Look the number up in the native reference in `ModDevelopment/docs/`. |
| Variable names like `num4` and `ped2` | Local names are lost in compiled code. Rename them as you work out what they do. |
| The `.pdb` next to the DLL | It adds real local names and line numbers in the log. If the mod ships with one, keep it next to the DLL while you decompile. |
| Strings are readable but code is hard to follow | Search the decompiled text for the message strings you see in game and read the code around them. |

## After a change

Record it as the project rules ask: update `ModDevelopment/MyMods/README.md`, [`MODS.md`](MODS.md), [`SETTINGS.md`](SETTINGS.md), [`HOTKEYS.md`](HOTKEYS.md) and `scripts/ModGuide.xml` where keys or settings changed, and `MOD_TRACKING.md` for new files.
