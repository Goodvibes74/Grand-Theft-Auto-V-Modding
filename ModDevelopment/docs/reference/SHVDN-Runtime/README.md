# ScriptHookVDotNet runtime (ScriptHookVDotNet.asi) API reference

> **Source:** `ScriptHookVDotNet.asi` (file version 3.6.0.0, assembly version 3.7.0.189, 240,128 bytes, modified 2026-08-05, SHA-256 `b96f27a11395c09d4e3858b7c29469bf6c7a5e8e79906c4e53a82dc19bbef65c`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** none: the library ships without XML documentation, so only signatures are listed.

Generated: don't edit by hand, re-run the generator instead.

The host that loads .NET scripts. Its public types are SHVDN's internal plumbing: scripts should use the v3 API instead, and these can change in any SHVDN update. Documented here for completeness and for the console commands below.

33 public types.

## Console commands (F4)

Every method marked with the `ConsoleCommand` attribute. Type them in the console exactly as shown, with the brackets. String arguments go in double quotes.

| Command | What it does |
| --- | --- |
| `Help(string command)` | Print the help for a specific command |
| `Help()` | Print the default help |
| `Clear()` | Clear the console history and pages |
| `Reload()` | Reload all scripts from the scripts directory |
| `Start(string filename)` | Load scripts from a file |
| `StartAllScripts()` | Load all scripts in the scripts folder |
| `Abort(string filename)` | Abort all scripts from a file |
| `AbortAll()` | Abort all scripts currently running |
| `ListScripts()` | List all loaded scripts |

## [global](global.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`ScriptHookVDotNet`](global.md#scripthookvdotnet) | class |  |

## [SHVDN](SHVDN.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`BlipPropertyFlags`](SHVDN.md#blippropertyflags) | enum |  |
| [`CItemInfo`](SHVDN.md#citeminfo) | struct |  |
| [`CModelList.<ModelMemberIndices>e__FixedBuffer`](SHVDN.md#cmodellistmodelmemberindicese__fixedbuffer) | struct |  |
| [`Console`](SHVDN.md#console) | class |  |
| [`ConsoleCommand`](SHVDN.md#consolecommand) | class |  |
| [`EntityDamageRecordForReturnValue`](SHVDN.md#entitydamagerecordforreturnvalue) | struct |  |
| [`FragPhysicsLodGroup.<_fragPhysicsLODAddresses>e__FixedBuffer`](SHVDN.md#fragphysicslodgroup_fragphysicslodaddressese__fixedbuffer) | struct |  |
| [`FVector3`](SHVDN.md#fvector3) | struct |  |
| [`IScriptTask`](SHVDN.md#iscripttask) | interface |  |
| [`KeyboardEvent`](SHVDN.md#keyboardevent) | struct |  |
| [`KeyManager`](SHVDN.md#keymanager) | class |  |
| [`KeyManager.KeyBinding`](SHVDN.md#keymanagerkeybinding) | class |  |
| [`Log`](SHVDN.md#log) | static class |  |
| [`Log.Level`](SHVDN.md#loglevel) | enum |  |
| [`Log.Options`](SHVDN.md#logoptions) | struct |  |
| [`MemDataMarshal`](SHVDN.md#memdatamarshal) | static class |  |
| [`MemScanner`](SHVDN.md#memscanner) | static class |  |
| [`NativeFunc`](SHVDN.md#nativefunc) | static class |  |
| [`NativeMemory`](SHVDN.md#nativememory) | static class |  |
| [`NativeMemory.PathFind`](SHVDN.md#nativememorypathfind) | static class |  |
| [`NativeMemory.Ped`](SHVDN.md#nativememoryped) | static class |  |
| [`NativeMemory.Vehicle`](SHVDN.md#nativememoryvehicle) | static class |  |
| [`RageAtArrayPtr`](SHVDN.md#rageatarrayptr) | struct |  |
| [`RageAtArrayPtr.<padding>e__FixedBuffer`](SHVDN.md#rageatarrayptrpaddinge__fixedbuffer) | struct |  |
| [`Script`](SHVDN.md#script) | class |  |
| [`ScriptDomain`](SHVDN.md#scriptdomain) | class |  |
| [`ScriptDomain.AbortScriptMode`](SHVDN.md#scriptdomainabortscriptmode) | enum |  |
| [`ScrWeaponHudStats`](SHVDN.md#scrweaponhudstats) | struct |  |
| [`StringMarshal`](SHVDN.md#stringmarshal) | static class |  |
| [`VehicleFlags`](SHVDN.md#vehicleflags) | enum |  |
| [`VehicleModelInfoFlags`](SHVDN.md#vehiclemodelinfoflags) | enum |  |
| [`VehiclePathNodeProperties`](SHVDN.md#vehiclepathnodeproperties) | enum |  |

