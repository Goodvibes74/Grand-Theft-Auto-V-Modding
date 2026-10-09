# SHVDN (ScriptHookVDotNet runtime (ScriptHookVDotNet.asi))

[Back to the ScriptHookVDotNet runtime (ScriptHookVDotNet.asi) index](README.md)

> **Source:** `ScriptHookVDotNet.asi` (file version 3.6.0.0, assembly version 3.7.0.189, 240,128 bytes, modified 2026-08-05, SHA-256 `b96f27a11395c09d4e3858b7c29469bf6c7a5e8e79906c4e53a82dc19bbef65c`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** none: the library ships without XML documentation, so only signatures are listed.

## BlipPropertyFlags

enum `SHVDN.BlipPropertyFlags`

| Name | Value |
| --- | --- |
| `Brightness` | 1 |
| `Flashing` | 2 |
| `ShortRange` | 3 |
| `Route` | 4 |
| `ShowHeight` | 5 |
| `MarkerLongDistance` | 6 |
| `MinimiseOnEdge` | 7 |
| `Dead` | 8 |
| `UseExtendedHeightThreshold` | 9 |
| `CreatedForRelationshipGroupPed` | 10 |
| `ShowCone` | 11 |
| `MissionCreator` | 12 |
| `HighDetail` | 13 |
| `HiddenOnLegend` | 14 |
| `ShowTick` | 15 |
| `ShowGoldTick` | 16 |
| `ShowForSale` | 17 |
| `ShowHeadingIndicator` | 18 |
| `ShowOutlineIndicator` | 19 |
| `ShowFriendIndicator` | 20 |
| `ShowCrewIndicator` | 21 |
| `UseHeightOnEdge` | 22 |
| `HoveredOnPausemap` | 23 |
| `UseShortHeightThreshold` | 24 |

## CItemInfo

struct `SHVDN.CItemInfo`

### Methods

- `public uint GetClassNameHash()`

### Fields

- `public uint AudioHash`
- `public uint ModelHash`
- `public uint NameHash`
- `public uint Slot`
- `public ulong* vTable`

## CModelList.<ModelMemberIndices>e__FixedBuffer

struct `SHVDN.CModelList.<ModelMemberIndices>e__FixedBuffer`

### Fields

- `public uint FixedElementField`

## Console

class `SHVDN.Console` : `MarshalByRefObject`

### Constructors

- `public Console()`

### Properties

- `public List<string> CommandHistory { get; set; }`
- `public bool IsOpen { get; set; }`

### Methods

- `public void Clear()`
- `public string GetClipboardContent()`
- `public virtual object InitializeLifetimeService()`
- `public void PrintDebug(string msg, params object[] args)`
- `public void PrintDebug(string msg)`
- `public void PrintError(string msg, params object[] args)`
- `public void PrintError(string msg)`
- `public void PrintHelpText()`
- `public void PrintInfo(string msg, params object[] args)`
- `public void PrintInfo(string msg)`
- `public void PrintMessage(string headerStr, string msg, params object[] args)`
- `public void PrintMessage(string headerStr, string msg)`
- `public void PrintWarning(string msg, params object[] args)`
- `public void PrintWarning(string msg)`
- `public void RegisterCommand(ConsoleCommand command, MethodInfo methodInfo)`
- `public void RegisterCommands(Type type)`
- `public void SetClipboardContent(string str)`
- `public void UnregisterCommands(Type type)`

## ConsoleCommand

class `SHVDN.ConsoleCommand` : `Attribute`, `_Attribute`

### Constructors

- `public ConsoleCommand()`
- `public ConsoleCommand(string help)`

### Properties

- `public string Help { get; }`

## EntityDamageRecordForReturnValue

struct `SHVDN.EntityDamageRecordForReturnValue`

### Constructors

- `public EntityDamageRecordForReturnValue(int attackerEntityHandle, int weaponHash, int gameTime)`

### Fields

- `public int AttackerEntityHandle`
- `public int GameTime`
- `public int WeaponHash`

## FragPhysicsLodGroup.<_fragPhysicsLODAddresses>e__FixedBuffer

struct `SHVDN.FragPhysicsLodGroup.<_fragPhysicsLODAddresses>e__FixedBuffer`

### Fields

- `public ulong FixedElementField`

## FVector3

struct `SHVDN.FVector3`

### Constructors

- `public FVector3(float x, float y, float z)`

### Fields

- `public float X`
- `public float Y`
- `public float Z`

## IScriptTask

interface `SHVDN.IScriptTask`

### Methods

- `public void Run()`

## KeyboardEvent

struct `SHVDN.KeyboardEvent`

### Constructors

- `public KeyboardEvent(bool isKeyDown, KeyEventArgs args)`
- `public KeyboardEvent(KeyEventArgs args)`

### Fields

- `public readonly KeyEventArgs Args`
- `public readonly bool IsDown`

## KeyManager

class `SHVDN.KeyManager`

### Constructors

- `public KeyManager()`

### Methods

- `public void Register(Keys combined, Action action)`
- `public bool TryHandle(Keys input)`

## KeyManager.KeyBinding

class `SHVDN.KeyManager.KeyBinding`

### Constructors

- `public KeyBinding(Keys combined, Action action)`

### Properties

- `public Action Action { get; }`
- `public Keys Combined { get; }`

## Log

static class `SHVDN.Log`

### Methods

- `public static void Clear()`
- `public static void Message(Log.Level level, Log.Options opt, params string[] message)`
- `public static void Message(Log.Level level, params string[] message)`

## Log.Level

enum `SHVDN.Log.Level`

| Name | Value |
| --- | --- |
| `Error` | 0 |
| `Warning` | 1 |
| `Info` | 2 |
| `Debug` | 3 |

## Log.Options

struct `SHVDN.Log.Options`

### Constructors

- `public Options(bool forceLogToConsole)`

### Properties

- `public bool ForceLogToConsole { get; }`

## MemDataMarshal

static class `SHVDN.MemDataMarshal`

### Methods

- `public static uint CreateFirstNBitMaskUInt32(int n)`
- `public static bool IsBitSet(IntPtr address, int bit)`
- `public static IntPtr ReadAddress(IntPtr address)`
- `public static byte ReadByte(IntPtr address)`
- `public static float ReadFloat(IntPtr address)`
- `public static short ReadInt16(IntPtr address)`
- `public static int ReadInt32(IntPtr address)`
- `public static int ReadInt32BitField(IntPtr address, int startBitIndex, int bitWidth)`
- `public static float[] ReadMatrix(IntPtr address)`
- `public static string ReadString(IntPtr address)`
- `public static ushort ReadUInt16(IntPtr address)`
- `public static uint ReadUInt32(IntPtr address)`
- `public static uint ReadUInt32BitField(IntPtr address, int startBitIndex, int bitWidth)`
- `public static FVector3 ReadVector3(IntPtr address)`
- `public static uint RemoveSignExtensionInt32(int value, int bitWidth)`
- `public static void SetBit(IntPtr address, int bit, bool value = true)`
- `public static int SignExtendInt32(int value, int bitWidth)`
- `public static void WriteAddress(IntPtr address, IntPtr value)`
- `public static void WriteBitFieldAsInt32(IntPtr address, int value, int startBitIndex, int bitWidth)`
- `public static void WriteBitFieldAsUInt32(IntPtr address, uint value, int startBitIndex, int bitWidth)`
- `public static void WriteByte(IntPtr address, byte value)`
- `public static void WriteFloat(IntPtr address, float value)`
- `public static void WriteInt16(IntPtr address, short value)`
- `public static void WriteInt32(IntPtr address, int value)`
- `public static void WriteMatrix(IntPtr address, float[] value)`
- `public static void WriteUInt16(IntPtr address, ushort value)`
- `public static void WriteUInt32(IntPtr address, uint value)`
- `public static void WriteVector3(IntPtr address, FVector3 value)`

## MemScanner

static class `SHVDN.MemScanner`

### Methods

- `public static byte* FindPatternBmh(string pattern, string mask, IntPtr startAddress, ulong size)`
- `public static byte* FindPatternBmh(string pattern, string mask, IntPtr startAddress)`
- `public static byte* FindPatternBmh(string pattern, string mask)`
- `public static byte* FindPatternNaive(string pattern, string mask, IntPtr startAddress, ulong size)`
- `public static byte* FindPatternNaive(string pattern, string mask, IntPtr startAddress)`
- `public static byte* FindPatternNaive(string pattern, string mask)`

## NativeFunc

static class `SHVDN.NativeFunc`

### Methods

- `public static ulong* Invoke(ulong hash, params object[] args)`
- `public static ulong* Invoke(ulong hash, params ulong[] args)`
- `public static ulong* Invoke(ulong hash, ulong* argPtr, int argCount)`
- `public static ulong* InvokeInternal(ulong hash, params object[] args)`
- `public static ulong* InvokeInternal(ulong hash, params ulong[] args)`
- `public static ulong* InvokeInternal(ulong hash, ulong* argPtr, int argCount)`
- `public static ulong* InvokeLongBlockingFunc(ulong hash, ulong* argPtr, int argCount)`
- `public static void PushLongString(string str, Action<string> action, int maxLengthUtf8 = 99)`
- `public static void PushLongString(string str, int maxLengthUtf8 = 99)`

## NativeMemory

static class `SHVDN.NativeMemory`

### Properties

- `public static bool AreArtificialLightsDisabled { get; }`
- `public static int CAttackerArrayOfEntityOffset { get; }`
- `public static IntPtr CellEmailBcon { get; }`
- `public static int CPlayerInfoMaxHealthOffset { get; }`
- `public static int CPlayerPedTargetingOfffset { get; }`
- `public static int CurrentCrimeValueOffset { get; }`
- `public static int CurrentWantedLevelOffset { get; }`
- `public static int CursorSprite { get; }`
- `public static int CWantedIgnorePlayerFlagOffset { get; }`
- `public static int CWantedOffset { get; }`
- `public static int CWantedTimeHiddenEvasionStartedOffset { get; }`
- `public static int CWantedTimeLastSpottedOffset { get; }`
- `public static int CWantedTimeSearchLastRefocusedOffset { get; }`
- `public static int ElementCountOfCAttackerArrayOfEntityOffset { get; }`
- `public static int ElementSizeOfCAttackerArrayOfEntity { get; }`
- `public static int EntityMaxHealthOffset { get; }`
- `public static Version GameFileVersion { get; }`
- `public static int GetAngularVelocityVFuncOfEntityOffset { get; }`
- `public static int InteriorInstPtrInInteriorProxyOffset { get; }`
- `public static ulong* InteriorProxyPtrFromGameplayCamAddress { get; }`
- `public static bool IsCameraInAccurateMode { get; }`
- `public static bool IsClockPaused { get; }`
- `public static bool IsDecoratorLocked { get; set; }`
- `public static bool IsRiotModeEnabled { get; }`
- `public static int LastTimeClockTicked { get; set; }`
- `public static int MillisecondsPerGameMinute { set; }`
- `public static int NewCrimeValueOffset { get; }`
- `public static IntPtr NullString { get; }`
- `public static ReadOnlyCollection<int> PedModels { get; }`
- `public static int PedPlayerInfoOffset { get; set; }`
- `public static int PlayerPedSpecialAbilityOffset { get; }`
- `public static int ProjectileAmmoInfoOffset { get; }`
- `public static int ProjectileOwnerOffset { get; }`
- `public static int ProjectileRocketCachedDirectionOffset { get; }`
- `public static int ProjectileRocketCachedTargetPosOffset { get; }`
- `public static int ProjectileRocketFlagsOffset { get; }`
- `public static int ProjectileRocketFlightModelInputPitchOffset { get; }`
- `public static int ProjectileRocketFlightModelInputRollOffset { get; }`
- `public static int ProjectileRocketFlightModelInputYawOffset { get; }`
- `public static int ProjectileRocketLaunchDirOffset { get; }`
- `public static int ProjectileRocketLauncherSpeedOffset { get; }`
- `public static int ProjectileRocketTargetOffset { get; }`
- `public static int ProjectileRocketTimeBeforeHomingAngleBreakOffset { get; }`
- `public static int ProjectileRocketTimeBeforeHomingOffset { get; }`
- `public static int ProjectileRocketTimeSinceLaunchOffset { get; }`
- `public static int RadarZoomValue { get; }`
- `public static int SetAngularVelocityVFuncOfEntityOffset { get; }`
- `public static IntPtr String { get; }`
- `public static float TimeScale { get; }`
- `public static int TimeWhenNewCrimeValueTakesEffectOffset { get; }`
- `public static ReadOnlyCollection<ReadOnlyCollection<int>> VehicleModels { get; }`
- `public static ReadOnlyCollection<ReadOnlyCollection<int>> VehicleModelsGroupedByType { get; }`
- `public static ReadOnlyCollection<int> WeaponModels { get; }`
- `public static float WorldGravity { get; set; }`

### Methods

- `public static void ActivateSpecialAbility(int playerIndex)`
- `public static bool AnimatedBuildingHandleExists(int handle)`
- `public static void AssignToFwRegdRef(IntPtr lhs, IntPtr rhs)`
- `public static bool BuildingHandleExists(int handle)`
- `public static bool CEntityHasCrSkeleton(IntPtr cEntityAddress)`
- `public static bool CPhysicalRecordsCollision(IntPtr cPhysicalAddress)`
- `public static int CreateTexture(string filename)`
- `public static bool DetachFragmentPartByIndex(IntPtr entityAddress, int fragmentGroupIndex)`
- `public static void DrawTexture(int id, int instance, int level, int time, float sizeX, float sizeY, float centerX, float centerY, float posX, float posY, float rotation, float scaleFactor, float colorR, float colorG, float colorB, float colorA)`
- `public static bool EntityHasSkeleton(int handle)`
- `public static bool EntityRecordsCollision(int entityHandle)`
- `public static void ExplodeProjectile(IntPtr projectileAddress)`
- `public static List<uint> GetAllCompatibleWeaponComponentHashes(uint weaponHash)`
- `public static List<uint> GetAllWeaponComponentHashes()`
- `public static List<uint> GetAllWeaponHashesForHumanPeds()`
- `public static IntPtr GetAnimatedBuildingAddress(int handle)`
- `public static int GetAnimatedBuildingCapacity()`
- `public static int GetAnimatedBuildingCount()`
- `public static int[] GetAnimatedBuildingHandles()`
- `public static int[] GetAnimatedBuildingHandles(FVector3 position, float radius)`
- `public static IntPtr GetAsCProjectile(IntPtr cObjectAddress)`
- `public static IntPtr GetAsCProjectileRocket(IntPtr cObjectAddress)`
- `public static IntPtr GetAsCProjectileThrown(IntPtr cObjectAddress)`
- `public static int GetAssociatedInteriorInstHandleFromInteriorProxy(int interiorProxyHandle)`
- `public static uint GetAttachmentPointHash(uint weaponHash, uint componentHash)`
- `public static IntPtr GetBlipAddress(int handle)`
- `public static bool GetBlipPropertyFlag(IntPtr address, BlipPropertyFlags flag)`
- `public static int GetBoneIdForEntityBoneIndex(int entityHandle, int boneIndex)`
- `public static IntPtr GetBuildingAddress(int handle)`
- `public static int GetBuildingCapacity()`
- `public static int GetBuildingCount()`
- `public static int[] GetBuildingHandles()`
- `public static int[] GetBuildingHandles(FVector3 position, float radius)`
- `public static IntPtr GetCameraAddress(int handle)`
- `public static IntPtr GetCheckpointAddress(int handle)`
- `public static int[] GetCheckpointHandles()`
- `public static IntPtr GetCPlayerInfoAddress(int playerIndex)`
- `public static IntPtr GetCPlayerPedTargetingAddress(int playerIndex)`
- `public static IntPtr GetCWantedAddress(int playerIndex)`
- `public static IntPtr GetEntityAddress(int handle)`
- `public static float* GetEntityAngularVelocity(IntPtr entityAddress)`
- `public static int GetEntityBoneCount(int handle)`
- `public static IntPtr GetEntityBoneGlobalMatrixAddress(int handle, int boneIndex)`
- `public static string GetEntityBoneName(int entityHandle, int boneIndex)`
- `public static IntPtr GetEntityBoneObjectMatrixAddress(int handle, int boneIndex)`
- `public static IntPtr GetEntityBoneTransformMatrixAddress(int handle)`
- `public static int GetEntityColliderCapacity()`
- `public static int GetEntityColliderCount()`
- `public static EntityDamageRecordForReturnValue[] GetEntityDamageRecordEntries(IntPtr entityAddress)`
- `public static EntityDamageRecordForReturnValue GetEntityDamageRecordEntryAtIndex(IntPtr entityAddress, uint index)`
- `public static int GetEntityHandleFromAddress(IntPtr address)`
- `public static int[] GetEntityHandles()`
- `public static int[] GetEntityHandles(FVector3 position, float radius)`
- `public static int GetFragmentGroupCountFromEntity(IntPtr entityAddress)`
- `public static int GetFragmentGroupIndexByEntityBoneIndex(IntPtr entityAddress, int boneIndex)`
- `public static int GetFreeAimBuildingTargetHandleOfPlayer(int playerIndex)`
- `public static IntPtr GetGameplayCameraAddress()`
- `public static int GetGameVersion()`
- `public static IntPtr GetGlobalPtr(int index)`
- `public static string GetGxtEntryByHash(int entryLabelHash)`
- `public static IntPtr GetHandlingDataByHandlingNameHash(int handlingNameHash)`
- `public static IntPtr GetHandlingDataByModelHash(int modelHash)`
- `public static uint GetHumanNameHashOfWeaponComponentInfo(uint weaponComponentHash)`
- `public static uint GetHumanNameHashOfWeaponInfo(uint weaponHash)`
- `public static IntPtr GetInteriorInstAddress(int handle)`
- `public static int GetInteriorInstCapacity()`
- `public static int GetInteriorInstCount()`
- `public static int[] GetInteriorInstHandles()`
- `public static int[] GetInteriorInstHandles(FVector3 position, float radius)`
- `public static IntPtr GetInteriorProxyAddress(int handle)`
- `public static int GetInteriorProxyCapacity()`
- `public static int GetInteriorProxyCount()`
- `public static int GetInteriorProxyHandleFromGameplayCam()`
- `public static int GetInteriorProxyHandleFromInteriorInst(int interiorInstHandle)`
- `public static int[] GetInteriorProxyHandles()`
- `public static int[] GetInteriorProxyHandles(FVector3 position, float radius)`
- `public static List<int> GetLoadedAppropriatePedHashes()`
- `public static List<int> GetLoadedAppropriateVehicleHashes()`
- `public static int GetLocalPlayerIndex()`
- `public static IntPtr GetLocalPlayerPedAddress()`
- `public static int GetLocalPlayerPedHandle()`
- `public static Size GetMainWindowResolution()`
- `public static int GetModelHashFromEntity(IntPtr entityAddress)`
- `public static void GetNextSiblingBoneIndexAndIdOfEntityBoneIndex(int entityHandle, int boneIndex, out int nextSiblingBoneIndex, out int nextSiblingBoneTag)`
- `public static int[] GetNonCriticalRadarBlipHandles(params int[] spriteTypes)`
- `public static int[] GetNonCriticalRadarBlipHandles(FVector3? position = null, float radius = 0, params int[] spriteTypes)`
- `public static int GetNorthBlip()`
- `public static int GetObjectCapacity()`
- `public static int GetObjectCount()`
- `public static void GetParentBoneIndexAndIdOfEntityBoneIndex(int entityHandle, int boneIndex, out int parentBoneIndex, out int parentBoneTag)`
- `public static int GetParentEntityHandleOfPropDetachedFrom(int objHandle)`
- `public static int GetPedCapacity()`
- `public static int GetPedCount()`
- `public static int GetPedHandleEntityIsCollidingWith(int entityHandle)`
- `public static int[] GetPedHandles(FVector3 position, float radius, int[] modelHashes = null)`
- `public static int[] GetPedHandles(int[] modelHashes = null)`
- `public static int GetPhysicalEntityHandleFromLastCollisionEntryOfEntity(int entityHandle)`
- `public static int GetPickupObjectCapacity()`
- `public static int GetPickupObjectCount()`
- `public static int[] GetPickupObjectHandles()`
- `public static int[] GetPickupObjectHandles(FVector3 position, float radius)`
- `public static IntPtr GetPlayerPedAddress(int playerIndex)`
- `public static int GetPlayerPedHandle(int handle)`
- `public static IntPtr GetPrimarySpecialAbilityStructAddress(int playerIndex)`
- `public static int GetProjectileCapacity()`
- `public static int GetProjectileCount()`
- `public static int[] GetProjectileHandles()`
- `public static int[] GetProjectileHandles(FVector3 position, float radius)`
- `public static int GetPropHandleEntityIsCollidingWith(int entityHandle)`
- `public static int[] GetPropHandles(FVector3 position, float radius, int[] modelHashes = null)`
- `public static int[] GetPropHandles(int[] modelHashes = null)`
- `public static IntPtr GetPtfxAddress(int handle)`
- `public static void GetQuaternionFromMatrix(float* returnRotationArray, IntPtr matrixAddress)`
- `public static uint GetRageClassId(IntPtr addr)`
- `public static int[] GetRocketProjectileHandles()`
- `public static int[] GetRocketProjectileHandles(FVector3 position, float radius)`
- `public static void GetRotationFromMatrix(float* returnRotationArray, IntPtr matrixAddress, int rotationOrder = 2)`
- `public static int GetTargetEntityOfCProjectileRocket(IntPtr cProjectileRocketAddress)`
- `public static int[] GetThrownProjectileHandles()`
- `public static int[] GetThrownProjectileHandles(FVector3 position, float radius)`
- `public static int GetVehicleCapacity()`
- `public static int GetVehicleCount()`
- `public static int GetVehicleHandleEntityIsCollidingWith(int entityHandle)`
- `public static int[] GetVehicleHandles(FVector3 position, float radius, int[] modelHashes = null)`
- `public static int[] GetVehicleHandles(int[] modelHashes = null)`
- `public static string GetVehicleMakeName(int modelHash)`
- `public static int GetVehicleType(int modelHash)`
- `public static int GetWaypointBlip()`
- `public static bool HasEntityCollidedWithBuildingOrAnimatedBuilding(int entityHandle)`
- `public static bool HasPropBeenDetachedFromParentEntity(int objHandle)`
- `public static bool HasVehicleFlag(int modelHash, VehicleFlags flag)`
- `public static bool HasVehicleFlag(int modelHash, VehicleModelInfoFlags flag)`
- `public static bool InteriorInstHandleExists(int handle)`
- `public static bool InteriorProxyHandleExists(int handle)`
- `public static bool IsEntityFragmentObject(IntPtr entityAddress)`
- `public static bool IsHashValidAsWeaponHash(uint weaponHash)`
- `public static bool IsIndexOfEntityDamageRecordValid(IntPtr entityAddress, uint index)`
- `public static bool IsModelABlimp(int modelHash)`
- `public static bool IsModelAFemalePed(int modelHash)`
- `public static bool IsModelAFragment(int modelHash)`
- `public static bool IsModelAGangPed(int modelHash)`
- `public static bool IsModelAMalePed(int modelHash)`
- `public static bool IsModelAMlo(int modelHash)`
- `public static bool IsModelAMotorcycle(int modelHash)`
- `public static bool IsModelAnAnimalPed(int modelHash)`
- `public static bool IsModelAPed(int modelHash)`
- `public static bool IsModelASubmarine(int modelHash)`
- `public static bool IsModelASubmarineCar(int modelHash)`
- `public static bool IsModelATrailer(int modelHash)`
- `public static bool IsModelHumanPed(int modelHash)`
- `public static bool IsScaleformMovieHandleValid(uint handle)`
- `public static bool IsScriptFireHandleValid(int handle)`
- `public static bool IsTaskNmScriptControlOrEventSwitch2NmActive(IntPtr pedAddress)`
- `public static void SendNmMessage(int targetHandle, string messageName, Dictionary<string, ValueTuple<int, Type>> boolIntFloatParameters, Dictionary<string, object> stringVector3ArrayParameters)`
- `public static void SetBlipSecondaryColor(int handle, uint argb)`
- `public static void SetEntityAngularVelocity(IntPtr entityAddress, float x, float y, float z)`

## NativeMemory.PathFind

static class `SHVDN.NativeMemory.PathFind`

### Methods

- `public static int[] GetAllLoadedVehicleNodes(Func<int, bool> predicateForFlags)`
- `public static int GetClosestLoadedVehiclePathNode(float x, float y, float z, float radius, Func<int, bool> predicateForFlags)`
- `public static int[] GetLoadedVehicleNodesInArea(float x1, float y1, float z1, float x2, float y2, float z2, Func<int, bool> predicateForFlags)`
- `public static int[] GetLoadedVehicleNodesInRange(float x, float y, float z, float radius, Func<int, bool> predicateForFlags)`
- `public static IntPtr GetPathNodeAddress(int handle)`
- `public static IntPtr GetPathNodeLinkAddress(int areaId, int nodeLinkIndex)`
- `public static int[] GetPathNodeLinkIndicesOfPathNode(int handleOfPathNode)`
- `public static bool GetPathNodeLinkLanes(int areaId, int nodeLinkIndex, out int forwardLaneCount, out int backwardLaneCount)`
- `public static FVector3 GetPathNodePosition(int handle)`
- `public static bool GetPathNodeSwitchedOffFlag(int handle)`
- `public static bool GetTargetAreaAndNodeIdToTargetNode(int areaIdOfNodeLink, int nodeLinkIndex, out int targetAreaId, out int targetNodeId)`
- `public static int GetTargetNodeHandleFromNodeLink(int areaIdOfNodeLink, int nodeLinkIndex)`
- `public static int GetVehiclePathNodeDensity(int handle)`
- `public static int GetVehiclePathNodePropertyFlags(int handle)`
- `public static void SetPathNodeSwitchedOffFlag(int handle, bool toggle)`

## NativeMemory.Ped

static class `SHVDN.NativeMemory.Ped`

### Properties

- `public static int ArmorOffset { get; }`
- `public static int AttachCarSeatIndexOffset { get; }`
- `public static int AudSpeechAudioEntity__AmbientVoiceNameHashOffset { get; }`
- `public static int AudSpeechAudioEntity__DisablePainOffset { get; }`
- `public static int AudSpeechAudioEntity__SpeakingDisabledOffset { get; }`
- `public static int AudSpeechAudioEntity__SpeakingDisabledSyncedOffset { get; }`
- `public static int AudSpeechAudioEntityOffset { get; }`
- `public static int CauseOfDeathOffset { get; }`
- `public static int CEventCountOffset { get; }`
- `public static int CEventStackOffset { get; }`
- `public static int CPed__PedResetFlagsOffset { get; }`
- `public static int CTaskTreePedOffset { get; }`
- `public static int DropsWeaponsWhenDeadOffset { get; }`
- `public static int FatalInjuryHealthThresholdOffset { get; }`
- `public static int FiringPatternOffset { get; }`
- `public static int GroundPhysicalOffset { get; }`
- `public static int HearingRangeOffset { get; }`
- `public static int InjuryHealthThresholdOffset { get; }`
- `public static int IntentoryOfCPedOffset { get; }`
- `public static int IsInVehicleOffset { get; }`
- `public static int IsUsingWetEffectOffset { get; }`
- `public static int KnockOffVehicleTypeOffset { get; }`
- `public static int LastVehicleOffset { get; }`
- `public static int LowerWetnessHeightOffset { get; }`
- `public static int LowerWetnessLevelOffset { get; }`
- `public static int MoneyCarriedOffset { get; }`
- `public static int PedIntelligenceCombatTargetPedAddressOffset { get; }`
- `public static int PedIntelligenceCTaskInfoOffset { get; }`
- `public static int PedIntelligenceCurrentScriptTaskHashOffset { get; }`
- `public static int PedIntelligenceCurrentScriptTaskStatusOffset { get; }`
- `public static int PedIntelligenceDecisionMakerHashOffset { get; }`
- `public static int PedIntelligenceOffset { get; }`
- `public static int SeeingRangeOffset { get; }`
- `public static int SourceOfDeathOffset { get; }`
- `public static int SuffersCriticalHitOffset { get; }`
- `public static int SweatOffset { get; }`
- `public static int TimeOfDeathOffset { get; }`
- `public static int UnkStateOffset { get; }`
- `public static int UpperWetnessHeightOffset { get; }`
- `public static int UpperWetnessLevelOffset { get; }`
- `public static int VisualFieldCenterAngleOffset { get; }`
- `public static int VisualFieldMaxAngleOffset { get; }`
- `public static int VisualFieldMaxElevationAngleOffset { get; }`
- `public static int VisualFieldMinAngleOffset { get; }`
- `public static int VisualFieldMinElevationAngleOffset { get; }`
- `public static int VisualFieldPeripheralRangeOffset { get; }`

### Methods

- `public static uint[] GetAllWeaponHashesOfPedInventory(int pedHandle)`
- `public static uint GetAmbientVoiceNameHash(IntPtr pedAddress)`
- `public static int GetCombatTargetPedHandleFromCombatPed(int pedHandle)`
- `public static int GetCombatTargetPedHandleFromCombatPed(IntPtr pedAddress)`
- `public static IntPtr GetCPedIntelligence(IntPtr pedAddress)`
- `public static IntPtr GetCPedInventoryAddressFromPedHandle(int pedHandle)`
- `public static int GetGroundPhysicalOfCPed(IntPtr pedAddress)`
- `public static bool GetIsPainAudioDisabled(IntPtr pedAddress)`
- `public static int GetLastVehicleHandle(IntPtr pedAddress)`
- `public static void GetScriptTaskHashAndStatus(int pedHandle, out uint taskHash, out uint taskStatus)`
- `public static int GetVehicleHandlePedIsIn(IntPtr pedAddress)`
- `public static int PlayAmbientSpeech(IntPtr pedAddress, uint contextPHash, uint voiceHash, string speechParams, int variation = 0)`
- `public static void SetAmbientSpeechEnabled(IntPtr pedAddress, bool value)`
- `public static void SetAmbientVoiceNameHash(IntPtr pedAddress, uint hash)`
- `public static bool TryGetWeaponHashInPedInventoryBySlotHash(int pedHandle, uint slotHash, out uint weaponHash)`

## NativeMemory.Vehicle

static class `SHVDN.NativeMemory.Vehicle`

### Properties

- `public static int AccelerationOffset { get; }`
- `public static int AlarmTimeOffset { get; }`
- `public static int BrakePowerOffset { get; }`
- `public static int CanUseSirenOffset { get; }`
- `public static int CanWheelBreakOffset { get; }`
- `public static int ClutchOffset { get; }`
- `public static int CurrentRpmOffset { get; }`
- `public static int CVehicleEngineOffset { get; }`
- `public static int CVehicleEngineTurboOffset { get; }`
- `public static int CWheelDynamicFlagsOffset { get; }`
- `public static int CWheelFrontRearSelectorOffset { get; }`
- `public static int CWheelMaxGripDiffFromWearRateOffset { get; }`
- `public static int CWheelStaticForceOffset { get; }`
- `public static int CWheelSuspensionHealthOffset { get; }`
- `public static int CWheelTireHealthOffset { get; }`
- `public static int CWheelTireTemperatureOffset { get; }`
- `public static int CWheelTireWearRateOffset { get; }`
- `public static int CWheelWearRateScaleOffset { get; }`
- `public static int DisablePretendOccupantOffset { get; }`
- `public static int DropsMoneyWhenBlownUpOffset { get; }`
- `public static int EnginePowerMultiplierOffset { get; }`
- `public static int EngineTemperatureOffset { get; }`
- `public static int FirstVehicleFlagsOffset { get; }`
- `public static int FuelLevelOffset { get; }`
- `public static int GearOffset { get; }`
- `public static int HandlingDataOffset { get; }`
- `public static int HasMutedSirensBit { get; }`
- `public static int HasMutedSirensOffset { get; }`
- `public static int HeliBladesSpeedOffset { get; }`
- `public static int HeliMainRotorHealthOffset { get; }`
- `public static int HeliTailBoomHealthOffset { get; }`
- `public static int HeliTailRotorHealthOffset { get; }`
- `public static int HighGearOffset { get; }`
- `public static int IsEngineStartingOffset { get; }`
- `public static int IsHeadlightDamagedOffset { get; }`
- `public static int IsInteriorLightOnOffset { get; }`
- `public static int IsWantedOffset { get; }`
- `public static int LightsMultiplierOffset { get; }`
- `public static int LodMultiplierOffset { get; }`
- `public static int ModelSirenIdOffset { get; }`
- `public static int NeedsToBeHotwiredOffset { get; }`
- `public static int NextGearOffset { get; }`
- `public static int OilLevelOffset { get; }`
- `public static int PreviouslyOwnedByPlayerOffset { get; }`
- `public static int ProvidesCoverOffset { get; }`
- `public static int ShouldShowOnlyVehicleTiresWithPositiveHealthOffset { get; }`
- `public static int SirenBufferOffset { get; }`
- `public static int SpecialFlightAreWingsDisabledOffset { get; }`
- `public static int SpecialFlightCurrentRatioOffset { get; }`
- `public static int SpecialFlightModeAllowedOffset { get; }`
- `public static int SpecialFlightTargetRatioOffset { get; }`
- `public static int SpecialFlightWingRatioOffset { get; }`
- `public static int SteeringAngleOffset { get; }`
- `public static int SteeringScaleOffset { get; }`
- `public static int SubHandlingDataArrayOffset { get; }`
- `public static int ThrottlePowerOffset { get; }`
- `public static int VehicleTypeOffset { get; }`
- `public static int WheelBoneIdToPtrArrayIndexOffset { get; }`
- `public static int WheelCountOffset { get; }`
- `public static int WheelIdOffset { get; }`
- `public static int WheelPtrArrayOffset { get; }`
- `public static int WheelSpeedOffset { get; }`

### Methods

- `public static void BurstTireOnRim(IntPtr wheelAddress, IntPtr vehicleAddress)`
- `public static void FixVehicleWheel(IntPtr wheelAddress)`
- `public static int GetByteSirenIdOfVehicleModel(IntPtr vehicleModelAddress)`
- `public static IntPtr GetSubHandlingData(IntPtr handlingDataAddr, int handlingType)`
- `public static float GetTurbo(int handle)`
- `public static IntPtr GetVehicleWheelAddressByIndexOfWheelArray(IntPtr vehicleAddress, int index)`
- `public static bool HasMutedSirens(int vehicleHandle)`
- `public static bool HasSiren(int vehicleHandle)`
- `public static bool IsHornEnabled(int vehicleHandle)`
- `public static bool IsWheelTouchingSurface(IntPtr wheelAddress, IntPtr vehicleAddress)`
- `public static void PunctureTire(IntPtr wheelAddress, float damage, IntPtr vehicleAddress)`
- `public static void SetTurbo(int handle, float value)`

### Fields

- `public static int AudVehicleAudioEntity__IsHornEnabledBitTest`
- `public static int AudVehicleAudioEntity__IsHornEnabledOffset`

## RageAtArrayPtr

struct `SHVDN.RageAtArrayPtr`

### Methods

- `public ulong GetElementAddress(int i)`

### Fields

- `public ushort Capacity`
- `public ulong* Data`
- `public ushort Size`

## RageAtArrayPtr.<padding>e__FixedBuffer

struct `SHVDN.RageAtArrayPtr.<padding>e__FixedBuffer`

### Fields

- `public char FixedElementField`

## Script

class `SHVDN.Script` : `IDisposable`

### Constructors

- `public Script()`

### Properties

- `public string Filename { get; }`
- `public int Interval { get; set; }`
- `public bool IsExecuting { get; }`
- `public bool IsPaused { get; }`
- `public bool IsRunning { get; }`
- `public bool IsUsingThread { get; }`
- `public string Name { get; }`
- `public object ScriptInstance { get; }`

### Methods

- `public void Abort()`
- `public void Dispose()`
- `public void Pause()`
- `public void Resume()`
- `public void Start(bool useThread = true)`
- `public void Wait(int ms)`

### Events

- `public event EventHandler Aborted`
- `public event KeyEventHandler KeyDown`
- `public event KeyEventHandler KeyUp`
- `public event EventHandler Tick`

## ScriptDomain

class `SHVDN.ScriptDomain` : `MarshalByRefObject`, `IDisposable`

### Properties

- `public AppDomain AppDomain { get; }`
- `public string Name { get; }`
- `public Script[] RunningScripts { get; }`
- `public string ScriptPath { get; }`
- `public uint ScriptTimeoutThreshold { get; set; }`
- `public static ScriptDomain CurrentDomain { get; set; }`
- `public static Script ExecutingScript { get; }`

### Methods

- `public void Abort()`
- `public void AbortScripts(string filename)`
- `public void Dispose()`
- `public void ExecuteTaskInScriptDomainThread(IScriptTask task)`
- `public void ExecuteTaskWithGameThreadTlsContext(IScriptTask task, bool forceResetTimeoutStopwatch = false)`
- `protected virtual void Finalize()`
- `public virtual object InitializeLifetimeService()`
- `public Script InstantiateScript(Type scriptType)`
- `public bool IsKeyPressed(Keys key)`
- `public Script LookupScript(object scriptInstance)`
- `public string LookupScriptFilename(Type scriptType)`
- `public void PauseKeyEvents(bool pause)`
- `public IntPtr PinString(string str)`
- `public void Start()`
- `public void StartScripts(string filename)`
- `public static ScriptDomain Load(string basePath, string scriptPath)`
- `public static void Unload(ScriptDomain domain)`

## ScriptDomain.AbortScriptMode

enum `SHVDN.ScriptDomain.AbortScriptMode`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `Off` | 1 |
| `On` | 2 |

## ScrWeaponHudStats

struct `SHVDN.ScrWeaponHudStats`

### Constructors

- `public ScrWeaponHudStats(int damage, int speed, int capacity, int accuracy, int range)`

### Fields

- `public int Accuracy`
- `public int Capacity`
- `public int Damage`
- `public int Range`
- `public int Speed`

## StringMarshal

static class `SHVDN.StringMarshal`

### Methods

- `public static string PtrToStringUtf8(IntPtr ptr, int len)`
- `public static string PtrToStringUtf8(IntPtr ptr)`
- `public static IntPtr StringToCoTaskMemUtf8(string s)`

## VehicleFlags

enum `SHVDN.VehicleFlags`

| Name | Value |
| --- | --- |
| `Big` | 2 |
| `IsVan` | 32 |
| `CanStandOnTop` | 268435456 |
| `LawEnforcement` | 2147483648 |
| `EmergencyService` | 4294967296 |
| `AllowsRappel` | 549755813888 |
| `IsElectric` | 8796093022208 |
| `IsOffroadVehicle` | 281474976710656 |
| `IsBus` | 288230376151711744 |

## VehicleModelInfoFlags

enum `SHVDN.VehicleModelInfoFlags`

| Name | Value |
| --- | --- |
| `IsTank` | 512 |
| `HasBulletProofGlass` | 4096 |
| `HasLowriderHydraulics` | 8388608 |
| `HasLowriderDonkHydraulics` | 134217728 |

## VehiclePathNodeProperties

enum `SHVDN.VehiclePathNodeProperties`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `OffRoad` | 1 |
| `OnPlayersRoad` | 2 |
| `NoBigVehicles` | 4 |
| `SwitchedOff` | 8 |
| `TunnelOrInterior` | 16 |
| `LeadsToDeadEnd` | 32 |
| `Highway` | 64 |
| `Junction` | 128 |
| `TrafficLight` | 256 |
| `GiveWay` | 512 |
| `Boat` | 1024 |
| `DontAllowGps` | 2048 |

