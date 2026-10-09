# GTA (ScriptHookVDotNet v3)

[Back to the ScriptHookVDotNet v3 index](README.md)

> **Source:** `ScriptHookVDotNet3.dll` (file version 3.7.0.189, assembly version 3.7.0.189, 1,435,136 bytes, modified 2026-08-05, SHA-256 `0f2b8d30ebe79edd74cf364df3943afb7e6305d7453bc687503dcc7411ed5648`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `ScriptHookVDotNet3.xml` from the NuGet package `scripthookvdotnet3` 3.6.0 (nuget.org). The installed DLL is 3.7.0.189, so members added after 3.6.0 have no description.

## AbortScriptMode

enum `GTA.AbortScriptMode`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `Off` | 1 |
| `On` | 2 |

## AnimatedBuilding

class `GTA.AnimatedBuilding` : `IExistable`

### Properties

- `public int Handle { get; }`
  - The handle of this `AnimatedBuilding`. This property is provided mainly for safer instance handling, but this is also used for equality comparison.
- `public Matrix Matrix { get; }`
  - Gets this `AnimatedBuilding`s matrix which stores position and rotation information.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where the `AnimatedBuilding` is stored in memory.
- `public Model Model { get; }`
  - Gets the model of this `AnimatedBuilding`.
- `public Vector3 Position { get; }`
  - Gets or sets the position of this `AnimatedBuilding`.
- `public Quaternion Quaternion { get; }`
  - Gets the quaternion of this `AnimatedBuilding`.
- `public Vector3 Rotation { get; }`
  - Gets the rotation of this `AnimatedBuilding`.

### Methods

- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same entity as this `AnimatedBuilding`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same entity as this `AnimatedBuilding`; otherwise, `false`.
- `public bool Exists()`
  - Determines if this `Building` exists.
  - Returns: `true` if this `Building` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public static AnimatedBuilding FromHandle(int handle)`
  - Creates a new instance of an `AnimatedBuilding` from the given handle.
  - `handle`: The building handle.
  - Returns: Returns a `AnimatedBuilding` if this handle corresponds to a `AnimatedBuilding`. Returns `null` if no `AnimatedBuilding` exists this the specified `handle`
- `public static bool op_Equality(AnimatedBuilding left, AnimatedBuilding right)`
  - Determines if two `AnimatedBuilding`s refer to the same entity.
  - `left`: The left `AnimatedBuilding`.
  - `right`: The right `AnimatedBuilding`.
  - Returns: `true` if `left` is the same entity as `right`; otherwise, `false`.
- `public static bool op_Inequality(AnimatedBuilding left, AnimatedBuilding right)`
  - Determines if two `AnimatedBuilding`s don't refer to the same entity.
  - `left`: The left `AnimatedBuilding`.
  - `right`: The right `AnimatedBuilding`.
  - Returns: `true` if `left` is not the same entity as `right`; otherwise, `false`.

## AnimationBlendDelta

struct `GTA.AnimationBlendDelta` : `IEquatable<AnimationBlendDelta>`

### Constructors

- `public AnimationBlendDelta(float value)`

### Properties

- `public float Value { get; }`
- `public static AnimationBlendDelta FastBlendIn { get; }`
- `public static AnimationBlendDelta FastBlendOut { get; }`
- `public static AnimationBlendDelta InstantBlendIn { get; }`
- `public static AnimationBlendDelta InstantBlendOut { get; }`
- `public static AnimationBlendDelta NormalBlendIn { get; }`
- `public static AnimationBlendDelta NormalBlendOut { get; }`
- `public static AnimationBlendDelta SlowBlendIn { get; }`
- `public static AnimationBlendDelta SlowBlendOut { get; }`
- `public static AnimationBlendDelta VerySlowBlendIn { get; }`
- `public static AnimationBlendDelta VerySlowBlendOut { get; }`
- `public static AnimationBlendDelta WalkBlendIn { get; }`
- `public static AnimationBlendDelta WalkBlendOut { get; }`

### Methods

- `public bool Equals(AnimationBlendDelta blendDelta)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public virtual string ToString()`
- `public static bool op_Equality(AnimationBlendDelta left, AnimationBlendDelta right)`
- `public static float op_Explicit(AnimationBlendDelta value)`
- `public static AnimationBlendDelta op_Explicit(float value)`
- `public static InputArgument op_Implicit(AnimationBlendDelta value)`
- `public static bool op_Inequality(AnimationBlendDelta left, AnimationBlendDelta right)`

## AnimationBlendDuration

struct `GTA.AnimationBlendDuration` : `IEquatable<AnimationBlendDuration>`

### Constructors

- `public AnimationBlendDuration(float value)`

### Properties

- `public float Value { get; }`
- `public static AnimationBlendDuration Fast { get; }`
- `public static AnimationBlendDuration Instant { get; }`
- `public static AnimationBlendDuration MigrateSlow { get; }`
- `public static AnimationBlendDuration Normal { get; }`
- `public static AnimationBlendDuration ReallySlow { get; }`
- `public static AnimationBlendDuration Slow { get; }`
- `public static AnimationBlendDuration SuperSlow { get; }`

### Methods

- `public bool Equals(AnimationBlendDuration duration)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public virtual string ToString()`
- `public static AnimationBlendDuration FromBlendDelta(AnimationBlendDelta blendDelta)`
- `public static bool op_Equality(AnimationBlendDuration left, AnimationBlendDuration right)`
- `public static float op_Explicit(AnimationBlendDuration value)`
- `public static AnimationBlendDuration op_Explicit(float value)`
- `public static InputArgument op_Implicit(AnimationBlendDuration value)`
- `public static bool op_Inequality(AnimationBlendDuration left, AnimationBlendDuration right)`

## AnimationFlags

enum `GTA.AnimationFlags`

| Name | Value | Description |
| --- | --- | --- |
| `None` | 0 |  |
| `Loop` | 1 | Repeat the animation. |
| `StayInEndFrame` | 2 | Hold on the last frame of the animation. |
| `RepositionWhenFinished` | 4 | When the animation finishes pop the peds physical reprsentation position to match the visual representations position. Note that the animator of the animation must not unwind the animation and must have an independent mover node. |
| `NotInterruptable` | 8 | The task cannot be interupted by extenal events. |
| `UpperBodyOnly` | 16 | Only plays the upper body part of the animation. Dampens any motion caused by the lower body animation.Note that the animation should include the root node. |
| `Secondary` | 32 | The task will run in the secondary task slot. This means it can be used aswell as a movement task (for instance). |
| `ReorientWhenFinished` | 64 | When the animation finishes pop the peds physical reprsentation direction to match the visual representations direction. Note that the animator of the animation must not unwind the animation and must have an independent mover node. |
| `AbortOnPedMovement` | 128 | Ends the animation early if the ped attemps to move e.g. if the player tries to move using the controller. Can also be used to blend out automatically when an AI ped starts moving by combining it with the `Secondary` flag. |
| `Additive` | 256 | Play back the animation additively. Note that this will only produce sensible results on specifically authored additive animations. |
| `TurnOffCollision` | 512 | Do not react to collision detection whilst this anim is playing. |
| `OverridePhysics` | 1024 | Do not apply any physics forces whilst the anim is playing. Automatically turns off collision, extracts any initial offset provided in the clip and uses per frame mover extraction. |
| `IgnoreGravity` | 2048 | Do not apply gravity while the anim is playing. |
| `ExtractInitialOffset` | 4096 | Extract an initial offset from the playback position authored by the animator. Use this flag when playing back anims on different peds which have been authored to sync with each other. |
| `ExitAfterInterrupted` | 8192 | Exit the animation task if it is interrupted by another task (ie Natural Motion). Without this flag bing set looped animations will restart ofter the NM task |
| `TagSyncIn` | 16384 | Sync the anim whilst blending in (use for seamless transitions from walk / run into a full body anim). |
| `TagSyncOut` | 32768 | Sync the anim whilst blending out (use for seamless transitions from a full body anim into walking / running behaviour). |
| `TagSyncContinuous` | 65536 | Sync all the time (Only usefull to synchronize a partial anim e.g. an upper body). |
| `ForceStart` | 131072 | Force the anim task to start even if the ped is falling / ragdolling / etc. Can fix issues with peds not playing their anims immediately after a warp / etc. |
| `UseKinematicPhysics` | 262144 | Use the kinematic physics mode on the entity for the duration of the anim (it should push other entities out of the way, and not be pushed around by players / etc). |
| `UseMoverExtraction` | 524288 | Updates the peds capsule position every frame based on the animation. Use in conjunction with `UseKinematicPhysics` to create characters that cannot be pushed off course by other entities / geometry / etc whilst playing the anim. |
| `HideWeapon` | 1048576 | Indicates that the ped's weapon should be hidden while this animation is playing. |
| `EndsInDeadPose` | 2097152 | When the anim ends, kill the ped and use the currently playing anim as the dead pose. |
| `RagdollOnCollision` | 4194304 | If the peds ragdoll bounds make contact with something physical (that isn't flat ground) activate the ragdoll and fall over. |
| `DontExitOnDeath` | 8388608 | Currently used only on secondary anim tasks. Secondary anim tasks will end automatically when the ped dies. Setting this flag stops that from happening. |
| `AbortOnWeaponDamage` | 16777216 | Allow aborting from damage events (including non-ragdoll damage events) even when blocking other ai events using `NotInterruptable`. |
| `DisableForcedPhysicsUpdate` | 33554432 | Prevent adjusting the capsule on the enter state (useful if script is doing a sequence of scripted anims and they are known to more or less stand still). |
| `ProcessAttachmentsOnStart` | 67108864 | Force the attachments to be processed at the start of the clip. |
| `ExpandPedCapsuleFromSkeleton` | 134217728 | Expands the capsule to the extents of the skeleton. |
| `UseAlternativeFirstPersonAnim` | 268435456 | Plays an alternative first person version of the clip on the player when in first person mode. The first person clip must be in the same dictionary, and be named the same as the anim you're playing, but with `_FP` appended on the end. |
| `BlendOutWRTLastFrame` | 536870912 | Start blending out the anim early, so that the blend out duration completes at the end of the animation. |
| `UseFullBlending` | 1073741824 | Use full blending for this anim and override the heading/position adjustment in CTaskScriptedAnimation::CheckIfClonePlayerNeedsHeadingPositionAdjust(), so that the game doesn't correct errors (special case such as scrip-side implemented AI tasks, i.e. diving) |
| `AllowRotation` | 32 |  |
| `CancelableWithMovement` | 128 |  |

## AnimationIKControlFlags

enum `GTA.AnimationIKControlFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `DisableLegIK` | 1 |
| `DisableArmIK` | 2 |
| `DisableHeadIK` | 4 |
| `DisableTorsoIK` | 8 |
| `DisableTorsoReactIK` | 16 |
| `UseLegAllowTags` | 32 |
| `UseLegBlockTags` | 64 |
| `UseArmAllowTags` | 128 |
| `UseArmBlockTags` | 256 |
| `ProcessWeaponHandGrip` | 512 |
| `UseFirstPersonArmLeft` | 1024 |
| `UseFirstPersonArmRight` | 2048 |
| `DisableTorsoVehicleIK` | 4096 |
| `LinkedFacial` | 8192 |

## AtHashValue

struct `GTA.AtHashValue` : `IEquatable<AtHashValue>`, `IJoaatHashValue`

### Constructors

- `public AtHashValue(uint hash)`

### Properties

- `public bool IsNull { get; }`
- `public static AtHashValue Null { get; }`

### Methods

- `public bool Equals(AtHashValue other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public uint GetJoaatHash()`
- `public static uint ComputeHash(byte[] value)`
- `public static uint ComputeHash(string value)`
- `public static uint ComputeHashUtf8(string value)`
- `public static AtHashValue FromBytes(byte[] input)`
- `public static AtHashValue FromString(string input)`
- `public static AtHashValue FromStringUtf8(string input)`
- `public static bool op_Equality(AtHashValue left, AtHashValue right)`
- `public static int op_Explicit(AtHashValue value)`
- `public static uint op_Explicit(AtHashValue value)`
- `public static AtHashValue op_Explicit(int value)`
- `public static AtHashValue op_Explicit(uint value)`
- `public static InputArgument op_Implicit(AtHashValue value)`
- `public static bool op_Inequality(AtHashValue left, AtHashValue right)`

### Fields

- `public readonly uint Hash`

## AtLiteralHashValue

struct `GTA.AtLiteralHashValue` : `IEquatable<AtLiteralHashValue>`, `IJoaatHashValue`

### Constructors

- `public AtLiteralHashValue(uint hash)`

### Properties

- `public bool IsNull { get; }`
- `public static AtLiteralHashValue Null { get; }`

### Methods

- `public bool Equals(AtLiteralHashValue other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public uint GetJoaatHash()`
- `public static AtLiteralHashValue FromBytes(byte[] input)`
- `public static AtLiteralHashValue FromString(string input)`
- `public static AtLiteralHashValue FromStringUtf8(string input)`
- `public static bool op_Equality(AtLiteralHashValue left, AtLiteralHashValue right)`
- `public static uint op_Explicit(AtLiteralHashValue value)`
- `public static AtLiteralHashValue op_Explicit(uint value)`
- `public static bool op_Inequality(AtLiteralHashValue left, AtLiteralHashValue right)`

### Fields

- `public readonly uint Hash`

## Audio

static class `GTA.Audio`

Methods to manipulate audio.

### Methods

- `public static ScriptSound GetSoundId()`
- `public static bool HasSoundFinished(int id)`
  - **Obsolete.** Use ScriptSoundId.HasFinished instead.
  - Gets a boolean indicating whether the specified sound instance has completed playing.
  - `id`: The identifier of the active sound effect instance.
- `public static void PlayMusic(string musicFile)`
  - Plays music from the game's music files.
  - `musicFile`: The music file to play.
- `public static void PlaySoundAndForget(string soundName, string setName, bool enableOnReplay = true)`
- `public static int PlaySoundAt(Entity entity, string soundFile, string soundSet)`
  - **Obsolete.** Use ScriptSoundId.PlaySoundFromEntity or Audio.PlaySoundFromEntityAndForget instead.
  - Plays a sound from the game's sound files at the specified `entity`.
  - `entity`: The entity to play the sound at.
  - `soundFile`: The sound file to play.
  - `soundSet`: The name of the sound inside the file.
  - Returns: The identifier of the active sound effect instance.
- `public static int PlaySoundAt(Entity entity, string soundFile)`
  - **Obsolete.** Audio.PlaySoundAt is obsolete, use ScriptSoundId.PlaySoundFromEntity or Audio.PlaySoundFromEntityAndForget.
  - Plays a sound from the game's sound files at the specified `entity`.
  - `entity`: The entity to play the sound at.
  - `soundFile`: The sound file to play.
  - Returns: The identifier of the active sound effect instance.
- `public static int PlaySoundAt(Vector3 position, string soundFile, string soundSet)`
  - **Obsolete.** Use ScriptSoundId.PlaySoundFromPosition or Audio.PlaySoundFromPositionAndForget instead.
  - Plays a sound from the game's sound files at the specified `position`.
  - `position`: The world coordinates to play the sound at.
  - `soundFile`: The sound file to play.
  - `soundSet`: The name of the sound inside the file.
  - Returns: The identifier of the active sound effect instance.
- `public static int PlaySoundAt(Vector3 position, string soundFile)`
  - **Obsolete.** Use ScriptSoundId.PlaySoundFromPosition or Audio.PlaySoundFromPositionAndForget instead.
  - Plays a sound from the game's sound files at the specified `position`.
  - `position`: The world coordinates to play the sound at.
  - `soundFile`: The sound file to play.
  - Returns: The identifier of the active sound effect instance.
- `public static void PlaySoundFromEntityAndForget(Entity entity, string soundName, string setName = null)`
- `public static void PlaySoundFromPositionAndForget(Vector3 position, string soundName, string setName = null, bool isExteriorLoc = false)`
- `public static int PlaySoundFrontend(string soundFile, string soundSet)`
  - **Obsolete.** Use ScriptSoundId.PlaySoundFrontend or Audio.PlaySoundFrontendAndForget instead.
  - Plays a sound from the game's sound files without transformation.
  - `soundFile`: The sound file to play.
  - `soundSet`: The name of the sound inside the file.
  - Returns: The identifier of the active sound effect instance.
- `public static int PlaySoundFrontend(string soundFile)`
  - **Obsolete.** Use ScriptSoundId.PlaySoundFrontend or Audio.PlaySoundFrontendAndForget instead.
  - Plays a sound from the game's sound files without transformation.
  - `soundFile`: The sound file to play.
  - Returns: The identifier of the active sound effect instance.
- `public static void PlaySoundFrontendAndForget(string soundName, string setName, bool enableOnReplay = true)`
- `public static void ReleaseSound(int id)`
  - **Obsolete.** Use ScriptSoundId.Release instead.
  - Releases the specified sound instance. Call this for every sound effect started.
  - `id`: The identifier of the active sound effect instance.
- `public static void SetAudioFlag(AudioFlags flag, bool toggle)`
  - Sets an audio flag to modify subsequent sounds.
- `public static void StopMusic(string musicFile)`
  - Cancels playing a music file.
  - `musicFile`: The music file to stop.
- `public static void StopSound(int id)`
  - **Obsolete.** Use ScriptSoundId.Stop instead.
  - Cancels playing the specified sound instance.
  - `id`: The identifier of the active sound effect instance.

## AudioFlags

enum `GTA.AudioFlags`

An enumeration of all possible audio flags.

| Name | Value |
| --- | --- |
| `ActivateSwitchWheelAudio` | 0 |
| `AllowCutsceneOverScreenFade` | 1 |
| `AllowForceRadioAfterRetune` | 2 |
| `AllowPainAndAmbientSpeechToPlayDuringCutscene` | 3 |
| `AllowPlayerAIOnMission` | 4 |
| `AllowPoliceScannerWhenPlayerHasNoControl` | 5 |
| `AllowRadioDuringSwitch` | 6 |
| `AllowRadioOverScreenFade` | 7 |
| `AllowScoreAndRadio` | 8 |
| `AllowScriptedSpeechInSlowMo` | 9 |
| `AvoidMissionCompleteDelay` | 10 |
| `DisableAbortConversationForDeathAndInjury` | 11 |
| `DisableAbortConversationForRagdoll` | 12 |
| `DisableBarks` | 13 |
| `DisableFlightMusic` | 14 |
| `DisableReplayScriptStreamRecording` | 15 |
| `EnableHeadsetBeep` | 16 |
| `ForceConversationInterrupt` | 17 |
| `ForceSeamlessRadioSwitch` | 18 |
| `ForceSniperAudio` | 19 |
| `FrontendRadioDisabled` | 20 |
| `HoldMissionCompleteWhenPrepared` | 21 |
| `IsDirectorModeActive` | 22 |
| `IsPlayerOnMissionForSpeech` | 23 |
| `ListenerReverbDisabled` | 24 |
| `LoadMPData` | 25 |
| `MobileRadioInGame` | 26 |
| `OnlyAllowScriptTriggerPoliceScanner` | 27 |
| `PlayMenuMusic` | 28 |
| `PoliceScannerDisabled` | 29 |
| `ScriptedConvListenerMaySpeak` | 30 |
| `SpeechDucksScore` | 31 |
| `SuppressPlayerScubaBreathing` | 32 |
| `WantedMusicDisabled` | 33 |
| `WantedMusicOnMission` | 34 |

## BaseSubHandlingData

abstract class `GTA.BaseSubHandlingData`

### Properties

- `public HandlingType HandlingType { get; }`
- `public bool IsValid { get; }`
- `public IntPtr MemoryAddress { get; }`
- `public HandlingData Parent { get; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(BaseSubHandlingData left, BaseSubHandlingData right)`
- `public static bool op_Inequality(BaseSubHandlingData left, BaseSubHandlingData right)`

## BikeHandlingData

class `GTA.BikeHandlingData` : `BaseSubHandlingData`

### Properties

- `public float BikeOnStandLeanAngle { get; set; }`
- `public float BrakingStabilityMultiplier { get; set; }`
- `public float DesLeanReturnFraction { get; set; }`
- `public float FrontBalanceMultiplier { get; set; }`
- `public float FullAnimAngle { get; set; }`
- `public float InAirSteerMultiplier { get; set; }`
- `public float LeanBackCenterOfMassMultiplier { get; set; }`
- `public float LeanBackwardForceMultiplier { get; set; }`
- `public float LeanForwardCenterOfMassMultiplier { get; set; }`
- `public float LeanForwardForceMultiplier { get; set; }`
- `public float MaxBankAngle { get; set; }`
- `public float RearBalanceMultiplier { get; set; }`
- `public float StickLeanMultiplier { get; set; }`
- `public float StoppieBalancePoint { get; set; }`
- `public float WheelieBalancePoint { get; set; }`
- `public float WheelieSteerMultiplier { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(BikeHandlingData left, BikeHandlingData right)`
- `public static bool op_Inequality(BikeHandlingData left, BikeHandlingData right)`

## Blip

class `GTA.Blip` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`

### Constructors

- `public Blip(int handle)`

### Properties

- `public int Alpha { get; set; }`
  - Gets or sets the alpha of this `Blip` on the map. The value is up to 255.
- `public BlipType BlipType { get; }`
- `public BlipCategoryType CategoryType { get; set; }`
  - Gets or sets the category type of this `Blip`.
- `public BlipColor Color { get; set; }`
  - Gets or sets the color of this `Blip`.
- `public int DisplayNameHash { get; set; }`
  - Get or sets this `Blip`s display name hash. When `Name` is not set, the game will show the localized `String` from the games language files with a specified GXT key hash.
- `public BlipDisplayType DisplayType { get; set; }`
  - Gets or sets the display type of this `Blip`.
- `public Entity Entity { get; }`
  - Gets the `Entity` this `Blip` is attached to.
- `public int FlashInterval { get; set; }`
  - Gets or sets the interval in ms between each blip flashing. The value is up to 65535.
- `public int FlashTimeLeft { get; set; }`
  - Gets or sets the flash time left in ms before this `Blip` stops flashing. The max value is up to 65534. Set `-1` to let the `Blip` flash forever.
- `public bool IsFlashing { get; set; }`
  - Gets or sets a value indicating whether this `Blip` is flashing.
- `public bool IsFriendly { set; }`
  - Sets a value indicating whether this `Blip` is friendly.
- `public bool IsHiddenOnLegend { get; set; }`
  - Gets or sets a value indicating whether this `Blip` is hidden on the map legend.
- `public bool IsOnMinimap { get; }`
  - Gets a value indicating whether this `Blip` is on minimap.
- `public bool IsShortRange { get; set; }`
  - Gets or sets a value indicating whether this `Blip` is short range.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where the `Entity` is stored in memory.
- `public string Name { get; set; }`
  - Get or sets the custom name of this `Blip`. The custom name appears in the legends list on the map.
- `public int NumberLabel { get; set; }`
  - Gets or sets this `Blip`s label to the given number.
- `public Vector3 Position { get; set; }`
  - Gets or sets the position of this `Blip`.
- `public int Priority { get; set; }`
  - Gets or sets the priority of this `Blip`. Overlapping `Blip`s with a higher priority cover those with a smaller one. The value is up to 255.
- `public int Rotation { get; set; }`
  - Gets or sets the rotation of this `Blip` on the map as an `Int32`. Use `RotationFloat` instead if you need to get or set the value precisely, since a rotation value of a `Blip` are stored as a `Single` in v1.0.944.2 or later versions.
- `public float RotationFloat { get; set; }`
  - Gets or sets the rotation of this `Blip` on the map as a `Single`. The value does not have any decimal places in v1.0.877.1 or earlier versions because the value is stored as `UInt16` in these versions.
- `public float Scale { set; }`
  - Sets the scale of this `Blip` on the map.
- `public SizeF ScaleF { get; set; }`
- `public float ScaleX { get; set; }`
  - **Obsolete.** Use Blip.ScaleF instead.
  - Gets or sets the x-axis scale of this `Blip` on the map. The value is the same as `ScaleY` in v1.0.393.4 or earlier versions.
- `public float ScaleY { get; set; }`
  - **Obsolete.** Use Blip.ScaleF instead.
  - Gets or sets the y-axis scale of this `Blip` on the map. The value is the same as `ScaleX` in v1.0.393.4 or earlier versions.
- `public Color SecondaryColor { get; set; }`
  - Gets or sets the secondary color of this `Blip`.
- `public bool ShowRoute { get; set; }`
  - Gets or sets a value indicating whether the route to this `Blip` should be shown on the map.
- `public bool ShowsCrewIndicator { get; set; }`
  - Gets or sets a value indicating whether this `Blip` shows crew member indicator, which highlights the `Blip` by a left half cyan circle. The right half cyan circle indicator is used to indicate crew members in GTA: Online.
- `public bool ShowsDollarSign { get; set; }`
  - **Obsolete.** `Blip.ShowsDollarSign` is obsolete because the setter changes whether to show the tick, and also because `SHOW_FOR_SALE_ICON_ON_BLIP` was added in b2802, which reveals `ShowsDollarSign` is too different from internal flags for the blip "for sale" icon. For what the setter does, use `Blip.ShowsTick` instead.
  - Gets or sets a value indicating whether this `Blip` shows the dollar sign at the top left corner of the `Blip`.
- `public bool ShowsFriendIndicator { get; set; }`
  - Gets or sets a value indicating whether this `Blip` shows friend indicator, which highlights the `Blip` by a right half cyan circle. The right half cyan circle indicator is used to indicate friends in GTA: Online.
- `public bool ShowsHeadingIndicator { get; set; }`
  - Gets or sets a value indicating whether this `Blip` shows the heading indicator used for normal players in GTA: Online.
- `public bool ShowsOutlineIndicator { get; set; }`
  - Gets or sets a value indicating whether this `Blip` shows outline. The outline color can be changed by setting `SecondaryColor`.
- `public bool ShowsTick { get; set; }`
- `public BlipSprite Sprite { get; set; }`
  - Gets or sets the sprite of this `Blip`.
- `public int Type { get; }`
  - **Obsolete.** Use Blip.BlipType instead.
  - Gets the type of this `Blip`.

### Methods

- `public virtual void Delete()`
  - Removes this `Blip`.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same blip as this `Blip`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same blip as this `Blip`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `Blip` exists.
  - Returns: `true` if this `Blip` exists; otherwise, `false`.
- `public string GetAppropriateName()`
  - Gets the appropriate name of this `Blip` in the same way the game does.
- `public virtual int GetHashCode()`
- `public void RemoveNumberLabel()`
  - Removes the number label from this `Blip`.
- `public void ResetName()`
  - Sets the name of this `Blip` based on its current `Sprite`.
- `public static Blip Create(Vector3 position, float radius)`
- `public static Blip Create(Vector3 position)`
- `public static bool op_Equality(Blip left, Blip right)`
  - Determines if two `Blip`s refer to the same blip.
  - `left`: The left `Pickup`.
  - `right`: The right `Pickup`.
  - Returns: `true` if `left` is the same blip as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(Blip value)`
  - Converts a `Blip` to a native input argument.
- `public static bool op_Inequality(Blip left, Blip right)`
  - Determines if two `Blip`s don't refer to the same blip.
  - `left`: The left `Pickup`.
  - `right`: The right `Pickup`.
  - Returns: `true` if `left` is not the same blip as `right`; otherwise, `false`.

## BlipCategoryType

enum `GTA.BlipCategoryType`

| Name | Value | Description |
| --- | --- | --- |
| `NoDistanceShown` | 1 |  |
| `DistanceShown` | 2 |  |
| `OtherPlayers` | 7 | Blips will show under the "Other Players" category listing in the map legend, regardless of name. Also shows distance in the map legend. the blip name will show with `ChaletComprimeCologneNotGamerName`. |
| `Property` | 10 | Blips will show under the "Property" category listing in the map legend, regardless of name. |
| `OwnedProperty` | 11 | Blips will show under the "Owned Property" category listing in the map legend, regardless of name. |

## BlipColor

enum `GTA.BlipColor`

85 values:

```text
White = 0
Red = 1
Green = 2
Blue = 3
Yellow = 66
WhiteNotPure = 4
Yellow2 = 5
NetPlayer1 = 6
NetPlayer2 = 7
NetPlayer3 = 8
NetPlayer4 = 9
NetPlayer5 = 10
NetPlayer6 = 11
NetPlayer7 = 12
NetPlayer8 = 13
NetPlayer9 = 14
NetPlayer10 = 15
NetPlayer11 = 16
NetPlayer12 = 17
NetPlayer13 = 18
NetPlayer14 = 19
NetPlayer15 = 20
NetPlayer16 = 21
NetPlayer17 = 22
NetPlayer18 = 23
NetPlayer19 = 24
NetPlayer20 = 25
NetPlayer21 = 26
NetPlayer22 = 27
NetPlayer23 = 28
NetPlayer24 = 29
NetPlayer25 = 30
NetPlayer26 = 31
NetPlayer27 = 32
NetPlayer28 = 33
NetPlayer29 = 34
NetPlayer30 = 35
NetPlayer31 = 36
NetPlayer32 = 37
Freemode = 38
InactiveMission = 39
GreyDark = 40
RedLight = 41
Michael = 42
Franklin = 43
Trevor = 44
GolfPlayer1 = 45
GolfPlayer2 = 46
GolfPlayer3 = 47
GolfPlayer4 = 48
Red2 = 49
Purple = 50
Orange = 51
GreenDark = 52
BlueLight = 53
BlueDark = 54
Grey = 55
YellowDark = 56
Blue2 = 57
PurpleDark = 58
Red3 = 59
Yellow3 = 60
Pink = 61
GreyLight = 62
Gang = 63
Gang2 = 64
Gang3 = 65
Blue3 = 67
Blue4 = 68
Green2 = 69
Yellow4 = 70
Yellow5 = 71
White2 = 72
Yellow6 = 73
Blue5 = 74
Red4 = 75
RedDark = 76
Blue6 = 77
BlueDark2 = 78
RedDark2 = 79
MenuYellow = 80
SimpleBlipDefault = 81
Waypoint = 82
Blue7 = 83
UseColor32 = 84
```

## BlipDisplayType

enum `GTA.BlipDisplayType`

| Name | Value | Description |
| --- | --- | --- |
| `NoDisplay` | 0 |  |
| `BothMapSelectable` | 2 |  |
| `MainMapSelectable` | 3 |  |
| `Default` | 4 | The default value on blip creation. Works in the same way as `BothMapSelectable`. |
| `MiniMapOnly` | 5 |  |
| `BothMapNoSelectable` | 8 |  |

## BlipSprite

enum `GTA.BlipSprite`

699 values:

```text
Standard = 1
BigBlip = 2
PoliceOfficer = 3
PoliceArea = 4
Square = 5
Player = 6
North = 7
Waypoint = 8
BigCircle = 9
BigCircleOutline = 10
ArrowUpOutlined = 11
ArrowDownOutlined = 12
ArrowUp = 13
ArrowDown = 14
PoliceHelicopterAnimated = 15
Jet = 16
Number1 = 17
Number2 = 18
Number3 = 19
Number4 = 20
Number5 = 21
Number6 = 22
Number7 = 23
Number8 = 24
Number9 = 25
Number10 = 26
GTAOCrew = 27
GTAOFriendly = 28
Lift = 36
RaceFinish = 38
Safehouse = 40
PoliceOfficer2 = 41
PoliceCarDot = 42
PoliceHelicopter = 43
ChatBubble = 47
Garage2 = 50
Drugs = 51
Store = 52
PoliceCar = 56
CriminalWanted = 57
PolicePlayer = 58
HeistStore = 59
PoliceStation = 60
Hospital = 61
Elevator = 63
Helicopter = 64
StrangersAndFreaks = 66
ArmoredTruck = 67
TowTruck = 68
Barber = 71
LosSantosCustoms = 72
Clothes = 73
TattooParlor = 75
Simeon = 76
Lester = 77
Michael = 78
Trevor = 79
TheJewelStoreJob = 80
Rampage = 84
VinewoodTours = 85
Lamar = 86
Franklin = 88
Chinese = 89
Airport = 90
Bar = 93
BaseJump = 94
BiolabHeist = 96
CarWash = 100
ComedyClub = 102
Dart = 103
ThePortOfLSHeist = 104
TheBureauRaid = 105
FIB = 106
TheBigScore = 107
DollarSign = 108
Golf = 109
AmmuNation = 110
Exile = 112
TheSharmootaJob = 113
ThePaletoScore = 118
ShootingRange = 119
Solomon = 120
StripClub = 121
Tennis = 122
Exile2 = 123
Michael2 = 124
Triathlon = 126
OffRoadRaceFinish = 127
GangPolice = 128
GangMexicans = 129
GangBikers = 130
Snitch2 = 133
Key = 134
MovieTheater = 135
Music = 136
PoliceStation2 = 137
Marijuana = 140
Hunting = 141
Objective2 = 143
ArmsTraffickingGround = 147
Nigel = 149
AssaultRifle = 150
Bat = 151
Grenade = 152
Health = 153
Knife = 154
Molotov = 155
Pistol = 156
RPG = 157
Shotgun = 158
SMG = 159
Sniper = 160
SonicWave = 161
PointOfInterest = 162
GTAOPassive = 163
GTAOUsingMenu = 164
Link = 171
Minigun = 173
GrenadeLauncher = 174
Armor = 175
Castle = 176
CriminalSnitchMexican = 177
CriminalSnitchLost = 178
PropertyBikers = 181
PropertyPolice = 182
PropertyVagos = 183
Camera = 184
PlayerPositon = 185
BikerHandcuffKeys = 186
VagosHandcuffKeys = 187
Handcuffs = 188
VagosHandcuffsClosed = 189
Yoga = 197
Cab = 198
Number11 = 199
Number12 = 200
Number13 = 201
Number14 = 202
Number15 = 203
Number16 = 204
Shrink = 205
Epsilon = 206
DevinDollarSign2 = 207
Trevor2 = 208
Trevor3 = 209
Franklin2 = 210
Franklin3 = 211
FranklinC = 214
PersonalVehicleCar = 225
PersonalVehicleBike = 226
GangVehiclePolice = 227
GangPoliceHighlight = 233
Custody = 237
CustodyVagos = 238
ArmsTraffickingAir = 251
PlayerstateArrested = 252
PlayerstateCustody = 253
PlayerstateKeyholder = 255
PlayerstatePartner = 256
Fairground = 266
PropertyManagement = 267
GangHighlight = 268
Altruist = 269
Enemy = 270
OnMission = 271
CashPickup = 272
Chop = 273
Dead = 274
CashPickupLost = 276
CashPickupVagos = 277
CashPickupPolice = 278
Hooker = 279
Friend = 280
CustodyDropoff = 285
OnMissionPolice = 286
OnMissionLost = 287
OnMissionVagos = 288
CriminalCarstealPolice = 289
CriminalCarstealLost = 290
CriminalCarstealVagos = 291
SimeonFamily = 293
BountyHit = 303
GTAOMission = 304
GTAOSurvival = 305
CrateDrop = 306
PlaneDrop = 307
Sub = 308
Race = 309
Deathmatch = 310
ArmWrestling = 311
AmmuNationShootingRange = 313
RaceAir = 314
RaceCar = 315
RaceSea = 316
TowTruck2 = 317
GarbageTruck = 318
GetawayCar = 326
GangBike = 348
SafehouseForSale = 350
Package = 351
MartinMadrazo = 352
EnemyHelicopter = 353
Boost = 354
Devin = 355
Marina = 356
Garage = 357
GolfFlag = 358
Hangar = 359
Helipad = 360
JerryCan = 361
Masks = 362
HeistSetup = 363
Incapacitated = 364
PickupSpawn = 365
BoilerSuit = 366
Completed = 367
Rockets = 368
GarageForSale = 369
HelipadForSale = 370
MarinaForSale = 371
HangarForSale = 372
Business = 374
BusinessForSale = 375
RaceBike = 376
Parachute = 377
TeamDeathmatch = 378
RaceFoot = 379
VehicleDeathmatch = 380
Barry = 381
Dom = 382
MaryAnn = 383
Cletus = 384
Josh = 385
Minute = 386
Omega = 387
Tonya = 388
Paparazzo = 389
Crosshair = 390
Creator = 398
CreatorDirection = 399
Abigail = 400
Blimp = 401
Repair = 402
Testosterone = 403
Dinghy = 404
Fanatic = 405
Invisible = 406
Information = 407
CaptureBriefcase = 408
LastTeamStanding = 409
Boat = 410
CaptureHouse = 411
GTAOCrew2 = 412
JerryCan2 = 415
RP = 416
GTAOPlayerSafehouse = 417
GTAOPlayerSafehouseDead = 418
CaptureAmericanFlag = 419
CaptureFlag = 420
Tank = 421
HelicopterAnimated = 422
Plane = 423
PlayerNoColor = 425
GunCar = 426
Speedboat = 427
Heist = 428
Stopwatch = 430
DollarSignCircled = 431
Crosshair2 = 432
DollarSignSquared = 434
StuntRace = 435
HotProperty = 436
KillListCompetitive = 437
KingOfTheCastle = 438
King = 439
DeadDrop = 440
PennedIn = 441
Beast = 442
CrossTheLinePointer = 443
CrossTheLine = 444
LamarD = 445
Bennys = 446
LamarDNumber1 = 447
LamarDNumber2 = 448
LamarDNumber3 = 449
LamarDNumber4 = 450
LamarDNumber5 = 451
LamarDNumber6 = 452
LamarDNumber7 = 453
LamarDNumber8 = 454
Yacht = 455
FindersKeepers = 456
Briefcase2 = 457
ExecutiveSearch = 458
Wifi = 459
TurretedLimo = 460
AssetRecovery = 461
YachtLocation = 462
Beasted = 463
Loading = 464
Random = 465
SlowTime = 466
Flip = 467
ThermalVision = 468
Doped = 469
Railgun = 470
Seashark = 471
Blind = 472
Warehouse = 473
WarehouseForSale = 474
Office = 475
OfficeForSale = 476
Truck = 477
SpecialCargo = 478
Trailer = 479
VIP = 480
Cargobob = 481
AreaCutline = 482
Jammed = 483
Ghost = 484
Detonator = 485
Bomb = 486
Shield = 487
Stunt = 488
Heart = 489
StuntPremium = 490
Adversary = 491
BikerClubhouse = 492
CagedIn = 493
TurfWar = 494
Joust = 495
Weed = 496
Cocaine = 497
IdentityCard = 498
Meth = 499
DollarBill = 500
Package2 = 501
Capture1 = 502
Capture2 = 503
Capture3 = 504
Capture4 = 505
Capture5 = 506
Capture6 = 507
Capture7 = 508
Capture8 = 509
Capture9 = 510
Capture10 = 511
QuadBike = 512
Bus = 513
DrugPackage = 514
Hop = 515
Adversary4 = 516
Adversary8 = 517
Adversary10 = 518
Adversary12 = 519
Adversary16 = 520
Laptop = 521
Motorcycle = 522
SportsCar = 523
VehicleWarehouse = 524
Document = 525
PoliceStationInverted = 526
Junkyard = 527
PhantomWedge = 528
ArmoredBoxville = 529
Ruiner2000 = 530
RampBuggy = 531
Wastelander = 532
RocketVoltic = 533
TechnicalAqua = 534
TargetA = 535
TargetB = 536
TargetC = 537
TargetD = 538
TargetE = 539
TargetF = 540
TargetG = 541
TargetH = 542
Juggernaut = 543
Repair2 = 544
SteeringWheel = 545
Cup = 546
RocketBoost = 547
Rocket = 548
MachineGun = 549
Parachute2 = 550
FiveSeconds = 551
TenSeconds = 552
FifteenSeconds = 553
TwentySeconds = 554
ThirtySeconds = 555
WeaponSupplies = 556
Bunker = 557
APC = 558
Oppressor = 559
HalfTrack = 560
DuneFAV = 561
WeaponizedTampa = 562
WeaponizedTrailer = 563
MobileOperationsCenter = 564
AdversaryBunker = 565
BunkerVehicleWorkshop = 566
WeaponWorkshop = 567
Cargo = 568
GTAOHangar = 569
TransformCheckpoint = 570
TransformRace = 571
AlphaZ1 = 572
Bombushka = 573
Havok = 574
HowardNX25 = 575
Hunter = 576
Ultralight = 577
Mogul = 578
V65Molotok = 579
P45Nokota = 580
Pyro = 581
Rogue = 582
Starling = 583
Seabreeze = 584
Tula = 585
Equipment = 586
Treasure = 587
OrbitalCannon = 588
Avenger = 589
Facility = 590
HeistDoomsday = 591
SAMTurret = 592
Firewall = 593
Node = 594
Stromberg = 595
Deluxo = 596
Thruster = 597
Khanjali = 598
RCV = 599
Volatol = 600
Barrage = 601
Akula = 602
Chernobog = 603
CCTV = 604
StarterPackIdentifier = 605
TurretStation = 606
RotatingMirror = 607
StaticMirror = 608
Proxy = 609
TargetAssault = 610
SanAndreasSuperSportCircuit = 611
SeaSparrow = 612
Caracara = 613
NightclubProperty = 614
CargoBusinessBattle = 615
NightclubTruck = 616
Jewel = 617
Gold = 618
Keypad = 619
HackTarget = 620
HealthHeart = 621
BlastIncrease = 622
BlastDecrease = 623
BombIncrease = 624
BombDecrease = 625
Rival = 626
Drone = 627
CashRegister = 628
CCTV2 = 629
TargetBusinessBattle = 630
FestivalBus = 631
Terrorbyte = 632
Menacer = 633
Scramjet = 634
PounderCustom = 635
MuleCustom = 636
SpeedoCustom = 637
Blimp2 = 638
OppressorMkII = 639
B11StrikeForce = 640
ArenaSeries = 641
ArenaPremium = 642
ArenaWorkshop = 643
RaceArenaWar = 644
ArenaTurret = 645
RCVehicle = 646
RCWorkshop = 647
FirePit = 648
Flipper = 649
SeaMine = 650
TurnTable = 651
Pit = 652
Mines = 653
BarrelBomb = 654
RisingWall = 655
Bollards = 656
SideBollard = 657
Bruiser = 658
Brutus = 659
Cerberus = 660
Deathbike = 661
Dominator = 662
Impaler = 663
Imperator = 664
Issi = 665
Sasquatch = 666
Scarab = 667
Slamvam = 668
ZR380 = 669
ArenaPoints = 670
HardcoreComicStore = 671
CopCar = 672
RCBanditoTimeTrials = 673
KingOfTheHill = 674
KingOfTheHillTeams = 675
Rucksack = 676
ShippingContainer = 677
Agatha = 678
Casino = 679
TableGames = 680
LuckyWheel = 681
Concierge = 682
Chips = 683
HorseRacing = 684
AdversaryFeatured = 685
Roulette1 = 686
Roulette2 = 687
Roulette3 = 688
Roulette4 = 689
Roulette5 = 690
Roulette6 = 691
Roulette7 = 692
Roulette8 = 693
Roulette9 = 694
Roulette10 = 695
Roulette11 = 696
Roulette12 = 697
Roulette13 = 698
Roulette14 = 699
Roulette15 = 700
Roulette16 = 701
Roulette17 = 702
Roulette18 = 703
Roulette19 = 704
Roulette20 = 705
Roulette21 = 706
Roulette22 = 707
Roulette23 = 708
Roulette24 = 709
Roulette25 = 710
Roulette26 = 711
Roulette27 = 712
Roulette28 = 713
Roulette29 = 714
Roulette30 = 715
Roulette31 = 716
Roulette32 = 717
Roulette33 = 718
Roulette34 = 719
Roulette35 = 720
Roulette36 = 721
Roulette0 = 722
Roulette00 = 723
Limo = 724
AlienWeapon = 725
Enemy2 = 726
RappelPoint = 727
SwapCar = 728
ScubaGear = 729
ControlPanel1 = 730
ControlPanel2 = 731
ControlPanel3 = 732
ControlPanel4 = 733
SnowTruck = 734
Buggy1 = 735
Buggy2 = 736
Zhaba = 737
Gerald = 738
Ron = 739
Arcade = 740
DroneControls = 741
RCTank = 742
Stairs = 743
Camera2 = 744
Winky = 745
Minisub = 746
RetroKart = 747
ModernKart = 748
MilitaryQuad = 749
MilitaryTruck = 750
ShipWheel = 751
SpaceshipPart = 752
Sparrow = 753
Dinghy2 = 754
PatrolBoat = 755
RetroSportsCar = 756
Squadee = 757
FoldingWingJet = 758
Valkyrie2 = 759
Kosatka = 760
BoltCutters = 761
GrapplingEquipment = 762
Keycard = 763
Codes = 764
TheCayoPericoHeistPrep = 765
BeachParty = 766
ControlTower = 767
DrainageTunnel = 768
PowerStation = 769
MainGate = 770
RappelPoint2 = 771
Keypad2 = 772
SubControls = 773
SubPeriscope = 774
SubMissile = 775
Painting = 776
LSCarMeet = 777
TestTrack = 778
AutoShopProperty = 779
DocksExport = 780
PrizeCar = 781
TestCar = 782
JobBoard = 783
RobberyPrep = 784
StreetRaceSeries = 785
PursuitSeries = 786
CarMeetOrganizer = 787
SecuroServ = 788
BountyCollectibles = 789
MovieCollectibles = 790
TrailerRamp = 791
RaceOrganizer = 792
VehicleList = 793
ExportVehicle = 794
Train = 795
TheDiamondCasinoHeist = 796
TheDoomsdayHeist = 797
TheCayoPericoHeist = 798
Slamvan2 = 799
Crusader = 800
ConstructionOutfit = 801
Jammed2 = 802
TheCayoPericoHeist2 = 803
TheDiamondCasinoHeist2 = 804
TheDoomsdayHeist2 = 805
FeaturedSeries = 809
VehicleForSale = 810
VanKeys = 811
SUVService = 812
SecurityContract = 813
Safe = 814
Raymond = 815
Eugene = 816
Payphone = 817
PatriotMilSpec = 818
RecordAStudios = 819
Jubilee = 820
Granger3600LX = 821
SatchelCharge = 822
Deity = 823
DewbaucheeChampion = 824
BuffaloSTX = 825
Agency = 826
BikerCar = 827
SimeonOverlay = 828
JunkEnergySkydive = 829
LuxuryAutos = 830
CarShowroom = 831
SimeonCarShowroom = 832
FlamingSkull = 833
WeaponAmmo = 834
CommunitySeries = 835
CayoPericoSeries = 836
ClubhouseContract = 837
AgentULP = 838
Acid = 839
AcidLab = 840
Dax = 841
DeadDropPackage = 842
DowntownCabCo = 843
GunVan = 844
StashHouse = 845
Tractor = 846
TheFreakshop = 847
TheFreakshopDax = 848
Crowbar = 849
DuffelBag = 850
OilTanker = 851
AcidLabTent = 852
MCsGangVan = 853
AcidProductionBoost = 854
GangLeader = 855
EclipseBlvdGarage = 856
TheVinewoodCarClub = 857
AssaultOnCayoPerico = 858
Bicycle = 859
JunkEnergyTimeTrial = 860
F160Raiju = 861
BuckinghamWeaponizedConada = 862
ReadyForSellOverlay = 863
MissingSuppliesOverlay = 864
Streamer216 = 865
SignalJammer = 866
```

## BlipType

enum `GTA.BlipType`

| Name | Value |
| --- | --- |
| `Unused` | 0 |
| `Vehicle` | 1 |
| `Character` | 2 |
| `Object` | 3 |
| `Coords` | 4 |
| `Contact` | 5 |
| `Pickup` | 6 |
| `Radius` | 7 |
| `WeaponPickup` | 8 |
| `Cop` | 9 |
| `Stealth` | 10 |
| `Area` | 11 |
| `Custom` | 12 |
| `PickupObject` | 13 |

## BoatHandlingData

class `GTA.BoatHandlingData` : `BaseSubHandlingData`

### Properties

- `public float AquaplanePushWaterApply { get; set; }`
- `public float AquaplanePushWaterCap { get; set; }`
- `public float AquaplanePushWaterMultiplier { get; set; }`
- `public float DragCoefficient { get; set; }`
- `public float KeelSphereSize { get; set; }`
- `public float RudderForce { get; set; }`
- `public float RudderOffsetForce { get; set; }`
- `public float RudderOffsetSubmerge { get; set; }`
- `public Vector3 VectorTurnResistance { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(BoatHandlingData left, BoatHandlingData right)`
- `public static bool op_Inequality(BoatHandlingData left, BoatHandlingData right)`

## BoatMissionFlags

enum `GTA.BoatMissionFlags`

| Name | Value |
| --- | --- |
| `StopAtEnd` | 1 |
| `StopAtShore` | 2 |
| `AvoidShore` | 4 |
| `PreferForward` | 8 |
| `NeverStop` | 16 |
| `NeverNavMesh` | 32 |
| `NeverRoute` | 64 |
| `ForceBeached` | 128 |
| `UseWanderRoute` | 256 |
| `UseFleeRoute` | 512 |
| `NeverPause` | 1024 |
| `DefaultSettings` | 7 |
| `OpenOceanSettings` | 111 |

## Bone

enum `GTA.Bone`

359 values:

```text
Invalid = -1
SkelRoot = 0
SkelPelvis = 11816
SkelLeftThigh = 58271
SkelLeftCalf = 63931
SkelLeftFoot = 14201
SkelLeftToe0 = 2108
EOLeftFoot = 33989
EOLeftToe = 26813
IKLeftFoot = 65245
PHLeftFoot = 57717
MHLeftKnee = 46078
SkelRightThigh = 51826
SkelRightCalf = 36864
SkelRightFoot = 52301
SkelRightToe0 = 20781
EORightFoot = 4246
EORightToe = 29027
IKRightFoot = 35502
PHRightFoot = 24806
MHRightKnee = 16335
RBLeftThighRoll = 23639
RBRightThighRoll = 6442
SkelSpineRoot = 57597
SkelSpine0 = 23553
SkelSpine1 = 24816
SkelSpine2 = 24817
SkelSpine3 = 24818
SkelLeftClavicle = 64729
SkelLeftUpperArm = 45509
SkelLeftForearm = 61163
SkelLeftHand = 18905
SkelLeftFinger00 = 26610
SkelLeftFinger01 = 4089
SkelLeftFinger02 = 4090
SkelLeftFinger10 = 26611
SkelLeftFinger11 = 4169
SkelLeftFinger12 = 4170
SkelLeftFinger20 = 26612
SkelLeftFinger21 = 4185
SkelLeftFinger22 = 4186
SkelLeftFinger30 = 26613
SkelLeftFinger31 = 4137
SkelLeftFinger32 = 4138
SkelLeftFinger40 = 26614
SkelLeftFinger41 = 4153
SkelLeftFinger42 = 4154
PHLeftHand = 60309
IKLeftHand = 36029
RBLeftForeArmRoll = 61007
RBLeftArmRoll = 5232
MHLeftElbow = 22711
SkelRightClavicle = 10706
SkelRightUpperArm = 40269
SkelRightForearm = 28252
SkelRightHand = 57005
SkelRightFinger00 = 58866
SkelRightFinger01 = 64016
SkelRightFinger02 = 64017
SkelRightFinger10 = 58867
SkelRightFinger11 = 64096
SkelRightFinger12 = 64097
SkelRightFinger20 = 58868
SkelRightFinger21 = 64112
SkelRightFinger22 = 64113
SkelRightFinger30 = 58869
SkelRightFinger31 = 64064
SkelRightFinger32 = 64065
SkelRightFinger40 = 58870
SkelRightFinger41 = 64080
SkelRightFinger42 = 64081
PHRightHand = 28422
IKRightHand = 6286
RBRightForeArmRoll = 43810
RBRightArmRoll = 37119
MHRightElbow = 2992
SkelNeck1 = 39317
SkelHead = 31086
IKHead = 12844
FacialRoot = 65068
FBLeftBrowOut000 = 58331
FBLeftLidUpper000 = 45750
FBLeftEye000 = 25260
FBLeftCheekBone000 = 21550
FBLeftLipCorner000 = 29868
FBRightLidUpper000 = 43536
FBRightEye000 = 27474
FBRightCheekBone000 = 19336
FBRightBrowOut000 = 1356
FBRightLipCorner000 = 11174
FBBrowCentre000 = 37193
FBUpperLipRoot000 = 20178
FBUpperLip000 = 61839
FBLeftLipTop000 = 20279
FBRightLipTop000 = 17719
FBJaw000 = 46240
FBLowerLipRoot000 = 17188
FBLowerLip000 = 20623
FBLeftLipBot000 = 47419
FBRightLipBot000 = 49979
FBTongue000 = 47495
RBNeck1 = 35731
SPRLeftBreast = 64654
SPRRightBreast = 34911
IKRoot = 56604
SkelNeck2 = 24532
SkelPelvis1 = 53251
SkelPelvisRoot = 17916
SkelSADDLE = 38180
MHLeftCalfBack = 4115
MHLeftThighBack = 24589
SMLeftSkirt = 50201
MHRightCalfBack = 45075
MHRightThighBack = 20899
SMRightSkirt = 30482
SMMBackSkirtRoll = 3515
SMLeftBackSkirtRoll = 16562
SMRightBackSkirtRoll = 49473
SMMFrontSkirtRoll = 52667
SMLeftFrontSkirtRoll = 39785
SMRightFrontSkirtRoll = 34545
SMCockNBallsRoot = 50813
SMCockNBalls = 40244
MHLeftFinger00 = 35939
MHLeftFingerBulge00 = 24504
MHLeftFinger10 = 35923
MHLeftFingerTop00 = 41540
MHLeftHandSide = 51082
MHWatch = 10040
MHLeftSleeve = 37692
MHRightFinger00 = 11363
MHRightFingerBulge00 = 27064
MHRightFinger10 = 11347
MHRightFingerTop00 = 61259
MHRightHandSide = 26875
MHRightSleeve = 37596
FacialJaw = 2849
FacialUnderChin = 35477
FacialLeftUnderChin = 9038
FacialChin = 46456
FacialChinSkinBottom = 39100
FacialLeftChinSkinBottom = 16015
FacialRightChinSkinBottom = 40591
FacialTongueA = 19068
FacialTongueB = 19069
FacialTongueC = 19070
FacialTongueD = 19071
FacialTongueE = 19072
FacialLeftTongueE = 13810
FacialRightTongueE = 12274
FacialLeftTongueD = 13809
FacialRightTongueD = 12273
FacialLeftTongueC = 13808
FacialRightTongueC = 12272
FacialLeftTongueB = 13807
FacialRightTongueB = 12271
FacialLeftTongueA = 13806
FacialRightTongueA = 12270
FacialChinSkinTop = 29222
FacialLeftChinSkinTop = 16051
FacialChinSkinMid = 35226
FacialLeftChinSkinMid = 17447
FacialLeftChinSide = 19038
FacialRightChinSkinMid = 62895
FacialRightChinSkinTop = 61499
FacialRightChinSide = 43614
FacialRightUnderChin = 11252
FacialLeftLipLowerSDK = 47585
FacialLeftLipLowerAnalog = 9290
FacialLeftLipLowerThicknessV = 51017
FacialLeftLipLowerThicknessH = 50811
FacialLipLowerSDK = 29317
FacialLipLowerAnalog = 55675
FacialLipLowerThicknessV = 50619
FacialLipLowerThicknessH = 50669
FacialRightLipLowerSDK = 41012
FacialRightLipLowerAnalog = 49881
FacialRightLipLowerThicknessV = 50921
FacialRightLipLowerThicknessH = 50907
FacialNose = 8433
FacialLeftNostril = 29474
FacialLeftNostrilThickness = 49503
FacialNoseLower = 57434
FacialLeftNoseLowerThickness = 31189
FacialRightNoseLowerThickness = 31093
FacialNoseTip = 27232
FacialRightNostril = 31010
FacialRightNostrilThickness = 14079
FacialNoseUpper = 41039
FacialLeftNoseUpper = 8120
FacialNoseBridge = 39843
FacialLeftNasolabialFurrow = 23242
FacialLeftNasolabialBulge = 52600
FacialLeftCheekLower = 26887
FacialLeftCheekLowerBulge1 = 58363
FacialLeftCheekLowerBulge2 = 58364
FacialLeftCheekInner = 59307
FacialLeftCheekOuter = 33121
FacialLeftEyesackLower = 30491
FacialLeftEyeball = 5956
FacialLeftEyelidLower = 39308
FacialLeftEyelidLowerOuterSDK = 65100
FacialLeftEyelidLowerOuterAnalog = 47530
FacialLeftEyelashLowerOuter = 55286
FacialLeftEyelidLowerInnerSDK = 61777
FacialLeftEyelidLowerInnerAnalog = 33346
FacialLeftEyelashLowerInner = 19663
FacialLeftEyelidUpper = 38849
FacialLeftEyelidUpperOuterSDK = 44821
FacialLeftEyelidUpperOuterAnalog = 26618
FacialLeftEyelashUpperOuter = 10167
FacialLeftEyelidUpperInnerSDK = 54081
FacialLeftEyelidUpperInnerAnalog = 61586
FacialLeftEyelashUpperInner = 39711
FacialLeftEyesackUpperOuterBulge = 42329
FacialLeftEyesackUpperInnerBulge = 12074
FacialLeftEyesackUpperOuterFurrow = 50583
FacialLeftEyesackUpperInnerFurrow = 21159
FacialForehead = 37400
FacialLeftForeheadInner = 2115
FacialLeftForeheadInnerBulge = 30332
FacialLeftForeheadOuter = 36299
FacialSkull = 16929
FacialForeheadUpper = 63446
FacialLeftForeheadUpperInner = 53011
FacialLeftForeheadUpperOuter = 20635
FacialRightForeheadUpperInner = 52979
FacialRightForeheadUpperOuter = 20603
FacialLefttemple = 44921
FacialLeftEar = 6621
FacialLeftEarLower = 24625
FacialLeftmasseter = 10256
FacialLeftJawRecess = 40058
FacialLeftCheekOuterSkin = 5285
FacialRightCheekLower = 62311
FacialRightCheekLowerBulge1 = 22939
FacialRightCheekLowerBulge2 = 22940
FacialRightmasseter = 2064
FacialRightJawRecess = 37844
FacialRightEar = 4407
FacialRightEarLower = 32817
FacialRightEyesackLower = 30587
FacialRightNasolabialBulge = 54814
FacialRightCheekOuter = 3378
FacialRightCheekInner = 29564
FacialRightNoseUpper = 7382
FacialRightForeheadInner = 3651
FacialRightForeheadInnerBulge = 30364
FacialRightForeheadOuter = 36811
FacialRightCheekOuterSkin = 45876
FacialRightEyesackUpperInnerFurrow = 40878
FacialRightEyesackUpperOuterFurrow = 5135
FacialRightEyesackUpperInnerBulge = 41817
FacialRightEyesackUpperOuterBulge = 6905
FacialRightNasolabialFurrow = 11434
FacialRightTemple = 44825
FacialRightEyeball = 6468
FacialRightEyelidUpper = 32276
FacialRightEyelidUpperOuterSDK = 45333
FacialRightEyelidUpperOuterAnalog = 62042
FacialRightEyelashUpperOuter = 3594
FacialRightEyelidUpperInnerSDK = 54593
FacialRightEyelidUpperInnerAnalog = 31843
FacialRightEyelashUpperInner = 33138
FacialRightEyelidLower = 32735
FacialRightEyelidLowerOuterSDK = 445
FacialRightEyelidLowerOuterAnalog = 17787
FacialRightEyelashLowerOuter = 48713
FacialRightEyelidLowerInnerSDK = 62289
FacialRightEyelidLowerInnerAnalog = 3603
FacialRightEyelashLowerInner = 13090
FacialLeftLipUpperSDK = 36656
FacialLeftLipUpperAnalog = 45519
FacialLeftLipUpperThicknessH = 14286
FacialLeftLipUpperThicknessV = 14524
FacialLipUpperSDK = 6004
FacialLipUpperAnalog = 57444
FacialLipUpperThicknessH = 31123
FacialLipUpperThicknessV = 31105
FacialLeftLipCornerSDK = 2844
FacialLeftLipCornerAnalog = 58728
FacialLeftLipCornerThicknessUpper = 1980
FacialLeftLipCornerThicknessLower = 56642
FacialRightLipUpperSDK = 30083
FacialRightLipUpperAnalog = 20943
FacialRightLipUpperThicknessH = 14382
FacialRightLipUpperThicknessV = 14428
FacialRightLipCornerSDK = 2876
FacialRightLipCornerAnalog = 60942
FacialRightLipCornerThicknessUpper = 21699
FacialRightLipCornerThicknessLower = 11194
MHMulletRoot = 15987
MHMulletScaler = 41410
MHHairScale = 50788
MHHairCrown = 5749
SMTorch = 2262
FXLight = 35161
FXLightScale = 20536
FXLightSwitch = 57742
BagRoot = 44297
BagPivotRoot = 47158
BagPivot = 19729
BagBody = 43885
BagBoneRight = 2359
BagBoneLeft = 2449
SMLifeSaverFront = 37920
SMRightPouchesRoot = 10594
SMRightPouches = 16705
SMLeftPouchesRoot = 10754
SMLeftPouches = 19265
SMSuitBackFlapper = 55853
SPRCopRadio = 33349
SMLifeSaverBack = 8487
MHBlushSlider = 41166
SkelTail01 = 839
SkelTail02 = 840
MHLeftConcertinaB = 51592
MHLeftConcertinaA = 51591
MHRightConcertinaB = 51432
MHRightConcertinaA = 51431
MHLeftShoulderBladeRoot = 34577
MHLeftShoulderBlade = 20143
MHRightShoulderBladeRoot = 14858
MHRightShoulderBlade = 21679
FBRightEar000 = 27871
SPRRightEar = 25526
FBLeftEar000 = 25657
SPRLeftEar = 23312
FBTongueA000 = 16902
FBTongueB000 = 16903
FBTongueC000 = 16904
SkelLeftToe1 = 7531
SkelRightToe1 = 45631
SkelTail03 = 841
SkelTail04 = 842
SkelTail05 = 843
SPRGonadsRoot = 49118
SPRGonads = 7168
FBLeftBrowOut001 = 58331
FBLeftLidUpper001 = 45750
FBLeftEye001 = 25260
FBLeftCheekBone001 = 21550
FBLeftLipCorner001 = 29868
FBRightLidUpper001 = 43536
FBRightEye001 = 27474
FBRightCheekBone001 = 19336
FBRightBrowOut001 = 1356
FBRightLipCorner001 = 11174
FBBrowCentre001 = 37193
FBUpperLipRoot001 = 20178
FBUpperLip001 = 61839
FBLeftLipTop001 = 20279
FBRightLipTop001 = 17719
FBJaw001 = 46240
FBLowerLipRoot001 = 17188
FBLowerLip001 = 20623
FBLeftLipBot001 = 47419
FBRightLipBot001 = 49979
FBTongue001 = 47495
```

## Building

class `GTA.Building` : `IExistable`

### Properties

- `public int Handle { get; }`
  - The handle of this `Building`. This property is provided mainly for safer instance handling, but this is also used for equality comparison.
- `public Matrix Matrix { get; }`
  - Gets this `Building`s matrix which stores position and rotation information.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where the `Building` is stored in memory.
- `public Model Model { get; }`
  - Gets the model of this `Building`.
- `public Vector3 Position { get; }`
  - Gets or sets the position of this `Building`.
- `public Quaternion Quaternion { get; }`
  - Gets the quaternion of this `Building`.
- `public Vector3 Rotation { get; }`
  - Gets or sets the rotation of this `Building`.

### Methods

- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same entity as this `Building`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same entity as this `Building`; otherwise, `false`.
- `public bool Exists()`
  - Determines if this `Building` exists.
  - Returns: `true` if this `Building` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public static Building FromHandle(int handle)`
  - Creates a new instance of an `Building` from the given handle.
  - `handle`: The building handle.
  - Returns: Returns a `Building` if this handle corresponds to a `Building`. Returns `null` if no `Building` exists this the specified `handle`
- `public static bool op_Equality(Building left, Building right)`
  - Determines if two `Building`s refer to the same entity.
  - `left`: The left `Building`.
  - `right`: The right `Building`.
  - Returns: `true` if `left` is the same entity as `right`; otherwise, `false`.
- `public static bool op_Inequality(Building left, Building right)`
  - Determines if two `Building`s don't refer to the same entity.
  - `left`: The left `Building`.
  - `right`: The right `Building`.
  - Returns: `true` if `left` is not the same entity as `right`; otherwise, `false`.

## Button

enum `GTA.Button`

| Name | Value |
| --- | --- |
| `PadUp` | 117 |
| `PadDown` | 100 |
| `PadLeft` | 108 |
| `PadRight` | 114 |
| `PadA` | 97 |
| `PadB` | 98 |
| `PadX` | 120 |
| `PadY` | 121 |
| `PadLB` | 49 |
| `PadLT` | 50 |
| `PadRB` | 51 |
| `PadRT` | 52 |

## CamAnimationFlags

enum `GTA.CamAnimationFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `Looping` | 1 |

## Camera

class `GTA.Camera` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Constructors

- `public Camera(int handle)`

### Properties

- `public float AnimPhase { get; set; }`
- `public float DepthOfFieldStrength { set; }`
  - Sets the depth of field strength for this `Camera`.
- `public Vector3 Direction { get; set; }`
  - Gets or sets the direction this `Camera` is pointing in.
- `public float FarClip { get; set; }`
  - Gets or sets the far clip of this `Camera`.
- `public float FarDepthOfField { get; set; }`
  - Gets or sets the far depth of field of this `Camera`.
- `public float FieldOfView { get; set; }`
  - Gets or sets the field of view of this `Camera`.
- `public Vector3 ForwardVector { get; }`
  - Gets the forward vector of this `Camera`, see also `Direction`.
- `public bool IsActive { get; set; }`
  - Gets or sets a value indicating whether this `Camera` is currently being rendered.
- `public bool IsInterpolating { get; }`
  - Gets a value indicating whether this `Camera` is interpolating.
- `public bool IsShaking { get; }`
  - Gets a value indicating whether this `Camera` is shaking.
- `public Matrix Matrix { get; }`
  - Gets the matrix of this `Camera`.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address of this `Camera`.
- `public float MotionBlurStrength { set; }`
  - Sets the strength of the motion blur for this `Camera`
- `public float NearClip { get; set; }`
  - Gets or sets the near clip of this `Camera`.
- `public float NearDepthOfField { set; }`
  - Sets the near depth of field for this `Camera`.
- `public Vector3 Position { get; set; }`
  - Gets or sets the position of this `Camera`.
- `public Vector3 RightVector { get; }`
  - Gets the right vector of this `Camera`.
- `public Vector3 Rotation { get; set; }`
  - Gets or sets the rotation of this `Camera`.
- `public float ShakeAmplitude { set; }`
  - Sets the shake amplitude for this `Camera`.
- `public Vector3 UpVector { get; }`
  - Gets the up vector of this `Camera`.

### Methods

- `public void AttachTo(Entity entity, Vector3 offset)`
  - Attaches this `Camera` to a specific `Entity`.
  - `entity`: The `Entity` to attach to.
  - `offset`: The offset from the `entity` to attach to.
- `public void AttachTo(PedBone pedBone, Vector3 offset)`
  - Attaches this `Camera` to a specific `PedBone`.
  - `pedBone`: The `PedBone` to attach to.
  - `offset`: The offset from the `pedBone` to attach to.
- `public void AttachToVehicleBone(EntityBone vehicleBone, Vector3 positionOffset, bool offsetIsRelative = true)`
- `public virtual void Delete()`
  - Destroys this `Camera`.
- `public void Delete(bool shouldApplyAcrossAllThreads)`
- `public void Detach()`
  - Detaches this `Camera` from any `Entity` or `PedBone` it may be attached to.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same camera as this `Camera`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same camera as this `Camera`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `Camera` exists.
  - Returns: `true` if this `Camera` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public Vector3 GetOffsetPosition(Vector3 offset)`
  - Gets the position in world coordinates of an offset relative to this `Camera`
  - `offset`: The offset from this `Camera`.
- `public Vector3 GetPositionOffset(Vector3 worldCoords)`
  - Gets the relative offset of this `Camera` from a world coordinates position
  - `worldCoords`: The world coordinates.
- `public void HardAttachToVehicleBone(EntityBone vehicleBone, Vector3 rotationOffset, Vector3 positionOffset, bool offsetIsRelative = true)`
- `public void InterpolateToNewCamFrame(Vector3 position, Vector3 rotation, float fov, uint duration, CamFrameInterpolatorCurveType graphTypePos = 1, CamFrameInterpolatorCurveType graphTypeRot = 1, EulerRotationOrder rotOrder = 2)`
- `public void InterpTo(Camera destinationCam, int duration, CamFrameInterpolatorCurveType graphTypePos = 1, CamFrameInterpolatorCurveType graphTypeRot = 1)`
  - Moves this `Camera` to the `to` position.
- `public void InterpTo(Camera to, int duration, int easePosition, int easeRotation)`
  - **Obsolete.** Use Camera.InterpTo(Camera, int, CamFrameInterpolatorCurveType, CamFrameInterpolatorCurveType) instead.
  - Moves this `Camera` to the `to` position.
- `public bool IsPlayingAnim(CrClipAsset anim)`
- `public bool PlayAnim(CrClipAsset anim, Vector3 originPosition, Vector3 originRotation, CamAnimationFlags animFlags = 0, EulerRotationOrder rotOrder = 2)`
- `public bool PlaySynchronizedAnim(FwSyncedScene scene, CrClipAsset anim)`
- `public void PointAt(Entity target, Vector3 offset = null)`
  - Points this `Camera` at a specified `Entity`.
  - `target`: The `Entity` to point at.
  - `offset`: The offset from the `target` to point at.
- `public void PointAt(Vector3 target)`
  - Points this `Camera` at a specified position.
  - `target`: The position to point at.
- `public void PointAt(PedBone target, Vector3 offset = null)`
  - Points this `Camera` at a specified `PedBone`.
  - `target`: The `PedBone` to point at.
  - `offset`: The offset from the `target` to point at
- `public void SetCamFrameParameters(Vector3 position, Vector3 rotation, float fov, CamFrameInterpolatorCurveType graphTypePos = 1, CamFrameInterpolatorCurveType graphTypeRot = 1, EulerRotationOrder rotOrder = 2)`
- `public void Shake(CameraShake shakeType, float amplitude)`
  - Shakes this `Camera`.
  - `shakeType`: Type of the shake to apply.
  - `amplitude`: The amplitude of the shaking.
- `public void Shake(string shakeName, float amplitudeScalar)`
  - Shakes this `Camera`.
  - `shakeType`: Type of the shake to apply.
  - `amplitude`: The amplitude of the shaking.
- `public void StopPointing()`
  - Stops this `Camera` pointing at a specific target.
- `public void StopShaking()`
  - Stops shaking this `Camera`.
- `public void StopShaking(bool stopImmediately)`
- `public static Camera Create(ScriptedCameraNameHash cameraNameHash, Vector3 position, Vector3 rotation, float fov = 65, bool startActivated = false, EulerRotationOrder rotOrder = 2)`
- `public static Camera Create(ScriptedCameraNameHash cameraNameHash, bool startActivated = false)`
- `public static Camera Create(string cameraName, Vector3 position, Vector3 rotation, float fov = 65, bool startActivated = false, EulerRotationOrder rotOrder = 2)`
- `public static Camera Create(string cameraName, bool startActivated = false)`
- `public static void DeleteAllCameras(bool shouldApplyAcrossAllThreads = false)`
- `public static bool op_Equality(Camera left, Camera right)`
  - Determines if two `Camera`s refer to the same camera.
  - `left`: The left `Camera`.
  - `right`: The right `Camera`.
  - Returns: `true` if `left` is the same camera as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(Camera value)`
  - Converts a `Camera` to a native input argument.
- `public static bool op_Inequality(Camera left, Camera right)`
  - Determines if two `Checkpoint`s don't refer to the same camera.
  - `left`: The left `Camera`.
  - `right`: The right `Camera`.
  - Returns: `true` if `left` is not the same camera as `right`; otherwise, `false`.

## CameraHintHelperNameHash

enum `GTA.CameraHintHelperNameHash`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `DefaultHintHelper` | 1803756875 |
| `SkyDivingHintHelper` | 3567339302 |
| `VehicleHintHelper` | 181066347 |
| `NoFovHintHelper` | 1511508800 |
| `VehicleHighZoomHintHelper` | 1726668277 |
| `Arm3VehicleHintHelper` | 1726668277 |
| `AgencyHeist3BSkyDivingHintHelper` | 1213015174 |
| `Family3HouseVehicleHintHelper` | 3171128396 |
| `Arm2Mcs6VehicleHintHelper` | 2010485655 |
| `KillerCamHintHelper` | 1844968929 |
| `Family3CoachOnBalconyVehicleHintHelper` | 4207186672 |
| `ChopHintHelper` | 193150208 |

## CameraShake

enum `GTA.CameraShake`

| Name | Value |
| --- | --- |
| `Hand` | 0 |
| `SmallExplosion` | 1 |
| `MediumExplosion` | 2 |
| `LargeExplosion` | 3 |
| `Jolt` | 4 |
| `Vibrate` | 5 |
| `RoadVibration` | 6 |
| `Drunk` | 7 |
| `SkyDiving` | 8 |
| `FamilyDrugTrip` | 9 |
| `DeathFail` | 10 |
| `Wobbly` | 11 |

## CamFrameInterpolatorCurveType

enum `GTA.CamFrameInterpolatorCurveType`

| Name | Value |
| --- | --- |
| `Linear` | 0 |
| `SinAccelDecel` | 1 |
| `Accel` | 2 |
| `Decel` | 3 |
| `SlowIn` | 4 |
| `SlowOut` | 5 |
| `SlowInOut` | 6 |
| `VerySlowIn` | 7 |
| `VerySlowOut` | 8 |
| `VerySlowInSlowOut` | 9 |
| `SlowInVerySlowOut` | 10 |
| `VerySlowInVerySlowOut` | 11 |
| `EaseIn` | 12 |
| `EaseOut` | 13 |
| `QuadraticEaseIn` | 14 |
| `QuadraticEaseOut` | 15 |
| `QuadraticEaseInOut` | 16 |
| `CubicEaseIn` | 17 |
| `CubicEaseOut` | 18 |
| `CubicEaseInOut` | 19 |
| `QuarticEaseIn` | 20 |
| `QuarticEaseOut` | 21 |
| `QuarticEaseInOut` | 22 |
| `QuinticEaseIn` | 23 |
| `QuinticEaseOut` | 24 |
| `QuinticEaseInOut` | 25 |
| `CircularEaseIn` | 26 |
| `CircularEaseOut` | 27 |
| `CircularEaseInOut` | 28 |

## CamInVehicleState

enum `GTA.CamInVehicleState`

| Name | Value |
| --- | --- |
| `EnteringVehicle` | 0 |
| `InsideVehicle` | 1 |
| `ExitingVehicle` | 2 |
| `OutsideVehicle` | 3 |

## CamSplineSmoothingMode

enum `GTA.CamSplineSmoothingMode`

| Name | Value |
| --- | --- |
| `NoSmooth` | 0 |
| `SlowInSmooth` | 1 |
| `SlowOutSmooth` | 2 |
| `SlowInOutSmooth` | 3 |
| `VerySlowIn` | 4 |
| `VerySlowOut` | 5 |
| `VerySlowInSlowOut` | 6 |
| `SlowInVerySlowOut` | 7 |
| `VerySlowInVerySlowOut` | 8 |
| `EaseIn` | 9 |
| `EaseOut` | 10 |
| `QuadraticEaseIn` | 11 |
| `QuadraticEaseOut` | 12 |
| `QuadraticEaseInOut` | 13 |
| `CubicEaseIn` | 14 |
| `CubicEaseOut` | 15 |
| `CubicEaseInOut` | 16 |
| `QuarticEaseIn` | 17 |
| `QuarticEaseOut` | 18 |
| `QuarticEaseInOut` | 19 |
| `QuinticEaseIn` | 20 |
| `QuinticEaseOut` | 21 |
| `QuinticEaseInOut` | 22 |
| `CircularEaseIn` | 23 |
| `CircularEaseOut` | 24 |
| `CircularEaseInOut` | 25 |

## CamViewMode

enum `GTA.CamViewMode`

| Name | Value |
| --- | --- |
| `ThirdPersonNear` | 0 |
| `ThirdPersonMedium` | 1 |
| `ThirdPersonFar` | 2 |
| `Cinematic` | 3 |
| `FirstPerson` | 4 |

## CamViewModeContext

enum `GTA.CamViewModeContext`

| Name | Value |
| --- | --- |
| `OnFoot` | 0 |
| `InVehicle` | 1 |
| `OnBike` | 2 |
| `InBoat` | 3 |
| `InAircraft` | 4 |
| `InSubmarine` | 5 |
| `InHeli` | 6 |
| `InTurret` | 7 |

## CargobobHook

enum `GTA.CargobobHook`

| Name | Value |
| --- | --- |
| `Hook` | 0 |
| `Magnet` | 1 |

## CarHandlingData

class `GTA.CarHandlingData` : `BaseSubHandlingData`

### Properties

- `public float CamberFront { get; set; }`
- `public float CamberRear { get; set; }`
- `public float Castor { get; set; }`
- `public float EngineResistance { get; set; }`
- `public float ToeFront { get; set; }`
- `public float ToeRear { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(CarHandlingData left, CarHandlingData right)`
- `public static bool op_Inequality(CarHandlingData left, CarHandlingData right)`

## Checkpoint

class `GTA.Checkpoint` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`

### Constructors

- `public Checkpoint(int handle)`

### Properties

- `public Color Color { get; set; }`
  - Gets or sets the color of this `Checkpoint`.
- `public CheckpointCustomIcon CustomIcon { get; set; }`
  - Gets or sets a custom icon to be drawn in this `Checkpoint`.
- `public float CylinderFarHeight { get; set; }`
  - Gets or sets the far height of the cylinder of this `Checkpoint`.
- `public float CylinderNearHeight { get; set; }`
  - Gets or sets the near height of the cylinder of this `Checkpoint`.
- `public float CylinderRadius { get; set; }`
  - Gets or sets the radius of the cylinder in this `Checkpoint`.
- `public CheckpointIcon Icon { get; set; }`
  - Gets or sets the icon drawn in this `Checkpoint`.
- `public Color IconColor { get; set; }`
  - Gets or sets the color of the icon in this `Checkpoint`.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address of this `Checkpoint`.
- `public Vector3 Position { get; set; }`
  - Gets or sets the position of this `Checkpoint`.
- `public float Radius { get; set; }`
  - Gets or sets the radius of this `Checkpoint`.
- `public Vector3 TargetPosition { get; set; }`
  - Gets or sets the position where this `Checkpoint` points to.

### Methods

- `public virtual void Delete()`
  - Removes this `Checkpoint`.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same checkpoint as this `Checkpoint`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same checkpoint as this `Checkpoint`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `Checkpoint` exists.
  - Returns: `true` if this `Checkpoint` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public static Checkpoint Create(CheckpointCustomIcon icon, Vector3 position, Vector3 pointTo, float radius, Color color)`
- `public static Checkpoint Create(CheckpointIcon icon, Vector3 position, Vector3 pointTo, float radius, Color color)`
- `public static bool op_Equality(Checkpoint left, Checkpoint right)`
  - Determines if two `Checkpoint`s refer to the same checkpoint.
  - `left`: The left `Checkpoint`.
  - `right`: The right `Checkpoint`.
  - Returns: `true` if `left` is the same checkpoint as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(Checkpoint value)`
  - Converts a `Checkpoint` to a native input argument.
- `public static bool op_Inequality(Checkpoint left, Checkpoint right)`
  - Determines if two `Checkpoint`s don't refer to the same checkpoint.
  - `left`: The left `Checkpoint`.
  - `right`: The right `Checkpoint`.
  - Returns: `true` if `left` is not the same checkpoint as `right`; otherwise, `false`.

## CheckpointCustomIcon

struct `GTA.CheckpointCustomIcon` : `INativeValue`

### Constructors

- `public CheckpointCustomIcon(CheckpointCustomIconStyle iconStyle, byte iconNumber)`
  - Initializes a new instance of the `CheckpointCustomIcon` struct.
  - `iconStyle`: The icon style.
  - `iconNumber`: The icon number, if `iconStyle` is `Number` allowed range is 0 - 99 otherwise allowed range is 0 - 9.

### Properties

- `public ulong NativeValue { get; set; }`
- `public byte Number { get; set; }`
  - Gets or sets the number to display inside the icon.
- `public CheckpointCustomIconStyle Style { get; set; }`
  - Gets or sets the icon style.

### Methods

- `public virtual int GetHashCode()`
- `public virtual string ToString()`
- `public static InputArgument op_Implicit(CheckpointCustomIcon value)`
  - Converts a `CheckpointCustomIcon` to a native input argument.
- `public static byte op_Implicit(CheckpointCustomIcon icon)`
  - Converts a `CheckpointCustomIcon` to a native input argument.
- `public static CheckpointCustomIcon op_Implicit(byte value)`
  - Converts a `CheckpointCustomIcon` to a native input argument.

## CheckpointCustomIconStyle

enum `GTA.CheckpointCustomIconStyle`

| Name | Value |
| --- | --- |
| `Number` | 0 |
| `SingleArrow` | 1 |
| `DoubleArrow` | 2 |
| `TripleArrow` | 3 |
| `Ring` | 4 |
| `CycleArrow` | 5 |
| `Ring2` | 6 |
| `RingPointer` | 7 |
| `SegmentedRing` | 8 |
| `Sphere` | 9 |
| `Dollar` | 10 |
| `QuintupleLines` | 11 |
| `BeastIcon` | 12 |

## CheckpointIcon

enum `GTA.CheckpointIcon`

| Name | Value |
| --- | --- |
| `CylinderSingleArrow` | 0 |
| `CylinderDoubleArrow` | 1 |
| `CylinderTripleArrow` | 2 |
| `CylinderCycleArrow` | 3 |
| `CylinderCheckerboard` | 4 |
| `CylinderWrench` | 5 |
| `CylinderSingleArrow2` | 6 |
| `CylinderDoubleArrow2` | 7 |
| `CylinderTripleArrow2` | 8 |
| `CylinderCycleArrow2` | 9 |
| `CylinderCheckerboard2` | 10 |
| `CylinderWrench2` | 11 |
| `RingSingleArrow` | 12 |
| `RingDoubleArrow` | 13 |
| `RingTripleArrow` | 14 |
| `RingCycleArrow` | 15 |
| `RingCheckerboard` | 16 |
| `SingleArrow` | 17 |
| `DoubleArrow` | 18 |
| `TripleArrow` | 19 |
| `CycleArrow` | 20 |
| `Checkerboard` | 21 |
| `CylinderSingleArrow3` | 22 |
| `CylinderDoubleArrow3` | 23 |
| `CylinderTripleArrow3` | 24 |
| `CylinderCycleArrow3` | 25 |
| `CylinderCheckerboard3` | 26 |
| `CylinderSingleArrow4` | 27 |
| `CylinderDoubleArrow4` | 28 |
| `CylinderTripleArrow4` | 29 |
| `CylinderCycleArrow4` | 30 |
| `CylinderCheckerboard4` | 31 |
| `CylinderSingleArrow5` | 32 |
| `CylinderDoubleArrow5` | 33 |
| `CylinderTripleArrow5` | 34 |
| `CylinderCycleArrow5` | 35 |
| `CylinderCheckerboard5` | 36 |
| `RingPlaneUp` | 37 |
| `RingPlaneLeft` | 38 |
| `RingPlaneRight` | 39 |
| `RingPlaneDown` | 40 |
| `Empty` | 41 |
| `Ring` | 42 |
| `Empty2` | 43 |
| `Cyclinder` | 47 |
| `Cyclinder2` | 48 |
| `Cyclinder3` | 49 |

## CinematicCameraDirector

static class `GTA.CinematicCameraDirector`

### Properties

- `public static bool IsCinematicCamInputActive { get; }`
- `public static bool IsRendering { get; }`
- `public static bool IsRenderingIdleCam { get; }`
- `public static bool IsRenderingMountedCam { get; }`
- `public static bool IsRenderingPointOfViewCam { get; }`
- `public static bool IsShaking { get; }`
- `public static float ShakeAmplitude { set; }`

### Methods

- `public static void InvalidateIdleCam()`
- `public static void InvalidateVehicleIdleMode()`
- `public static void Shake(CameraShake shakeType, float amplitude)`
- `public static void StopShaking(bool stopImmediately = false)`

## ClearPropsFlags

enum `GTA.ClearPropsFlags`

| Name | Value |
| --- | --- |
| `ForceRespawnAmbientProps` | 2 |
| `IncludeDoors` | 4 |
| `IncludePropsWithScriptBrains` | 8 |
| `ExcludeLadder` | 16 |

## ClipSet

struct `GTA.ClipSet` : `IEquatable<ClipSet>`, `IScriptStreamingResource`

### Constructors

- `public ClipSet(string name)`

### Properties

- `public bool IsLoaded { get; }`
- `public string Name { get; }`

### Methods

- `public bool Equals(ClipSet other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public AtHashValue HashName()`
- `public void MarkAsNoLongerNeeded()`
- `public void Request()`
- `public virtual string ToString()`
- `public static bool op_Equality(ClipSet left, ClipSet right)`
- `public static string op_Explicit(ClipSet value)`
- `public static ClipSet op_Explicit(string value)`
- `public static InputArgument op_Implicit(ClipSet value)`
- `public static bool op_Inequality(ClipSet left, ClipSet right)`

## CombatAbility

enum `GTA.CombatAbility`

| Name | Value |
| --- | --- |
| `Poor` | 0 |
| `Average` | 1 |
| `Professional` | 2 |

## CombatAttributes

enum `GTA.CombatAttributes`

87 values:

```text
CanUseCover = 0
CanUseVehicles = 1
CanDoDrivebys = 2
CanLeaveVehicle = 3
CanUseDynamicStrafeDecisions = 4
AlwaysFight = 5
FleeWhilstInVehicle = 6
WillScanForDeadPeds = 9
JustSeekCover = 11
BlindFireWhenInCover = 12
Aggressive = 13
CanInvestigate = 14
HasRadio = 15
AlwaysFlee = 17
ForceInjuredOnGround = 18
DisableInjuredOnGround = 19
CanTauntInVehicle = 20
CanChaseTargetOnFoot = 21
WillDragInjuredPedsToSafety = 22
RequiresLosToShoot = 23
UseProximityFiringRate = 24
DisableSecondaryTarget = 25
DisableEntryReactions = 26
PerfectAccuracy = 27
CanUseFrustratedAdvance = 28
MoveToLocationBeforeCoverSearch = 29
CanShootWithoutLos = 30
MaintainMinDistanceToTarget = 31
IgnoreHatedPedsInFastMovingVehicles = 32
UseProximityAccuracy = 33
CanUsePeekingVariations = 34
DisablePinnedDown = 35
DisablePinDownOthers = 36
ClearAreaSetDefensiveIfDefensiveAreaReached = 37
DisableBulletReactions = 38
CanBust = 39
IgnoredByOtherPedsWhenWanted = 40
CanCommandeerVehicles = 41
CanFlank = 42
SwitchToAdvanceIfCantFindCover = 43
SwitchToDefensiveIfInCover = 44
ClearPrimaryDefensiveAreaWhenReached = 45
CanFightArmedPedsWhenNotArmed = 46
EnableTacticalPointsWhenDefensive = 47
DisableCoverArcAdjustments = 48
UseEnemyAccuracyScaling = 49
CanCharge = 50
ClearAreaSetAdvanceIfDefensiveAreaReached = 51
UseVehicleAttack = 52
UseVehicleAttackIfVehicleHasMountedGuns = 53
AlwaysEquipBestWeapon = 54
CanSeeUnderwaterPeds = 55
DisableAimAtAITargetsInHelis = 56
DisableSeekDueToLineOfSight = 57
DisableFleeFromCombat = 58
DisableTargetChangesDuringVehiclePursuit = 59
CanThrowSmokeGrenade = 60
NonMissionPedsFleeFromThisPedUnlessArmed = 61
ClearAreaSetDefensiveIfDefensiveCannotBeReached = 62
FleesFromInvincibleOpponents = 63
DisableBlockFromPursueDuringVehicleChase = 64
DisableSpinOutDuringVehicleChase = 65
DisableCruiseInFrontDuringBlockDuringVehicleChase = 66
CanIgnoreBlockedLosWeighting = 67
DisableReactToBuddyShot = 68
PreferNavmeshDuringVehicleChase = 69
AllowedToAvoidOffroadDuringVehicleChase = 70
PermitChargeBeyondDefensiveArea = 71
UseRocketsAgainstVehiclesOnly = 72
DisableTacticalPointsWithoutClearLos = 73
DisablePullAlongsideDuringVehicleChase = 74
DisableShoutTargetPosition = 75
SetDisableShoutTargetPositionOnCombatStart = 76
DisableRespondedToThreatBroadcast = 77
DisableAllRandomsFlee = 78
WillGenerateDeadPedSeenScriptEvents = 79
UseMaxSenseRangeWhenReceivingEvents = 80
RestrictInVehicleAimingToCurrentSide = 81
UseDefaultBlockedLosPositionAndDirection = 82
RequiresLosToAim = 83
CruiseAndBlockInVehicle = 84
PreferAirCombatWhenInAircraft = 85
AllowDogFighting = 86
PreferNonAircraftTargets = 87
PreferKnownTargetsWhenCombatClosestTarget = 88
ForceCheckAttackAngleForMountedGuns = 89
BlockFireForVehiclePassengerMountedGuns = 90
```

## CombatFloatAttributes

enum `GTA.CombatFloatAttributes`

| Name | Value |
| --- | --- |
| `BlindFireChance` | 0 |
| `BurstDurationInCover` | 1 |
| `MaxShootingDistance` | 2 |
| `TimeBetweenBurstsInCover` | 3 |
| `TimeBetweenPeeks` | 4 |
| `StrafeWhenMovingChance` | 5 |
| `WeaponAccuracy` | 6 |
| `FightProficiency` | 7 |
| `WalkWhenStrafingChance` | 8 |
| `HeliSpeedModifier` | 9 |
| `HeliSensesRange` | 10 |
| `AttackWindowDistanceForCover` | 11 |
| `TimeToInvalidateInjuredTarget` | 12 |
| `MinimumDistanceToTarget` | 13 |
| `BulletImpactDetectionRange` | 14 |
| `AimTurnThreshold` | 15 |
| `OptimalCoverDistance` | 16 |
| `AutomobileSpeedModifier` | 17 |
| `SpeedToFleeInVehicle` | 18 |
| `TriggerChargeTimeFar` | 19 |
| `TriggerChargeTimeNear` | 20 |
| `MaxDistanceToHearEvents` | 21 |
| `MaxDistanceToHearEventsUsingLOS` | 22 |
| `HomingRocketBreakLockAngle` | 23 |
| `HomingRocketBreakLockAngleClose` | 24 |
| `HomingRocketBreakLockCloseDistance` | 25 |
| `HomingRocketTurnRateModifier` | 26 |
| `TimeBetweenAggressiveMovesDuringVehicleChase` | 27 |
| `MaxVehicleTurretFiringRange` | 28 |
| `WeaponDamageModifier` | 29 |
| `UnarmedDamageModifier` | 30 |

## CombatMovement

enum `GTA.CombatMovement`

| Name | Value |
| --- | --- |
| `Stationary` | 0 |
| `Defensive` | 1 |
| `WillAdvance` | 2 |
| `WillRetreat` | 3 |

## CombatRange

enum `GTA.CombatRange`

| Name | Value |
| --- | --- |
| `Near` | 0 |
| `Medium` | 1 |
| `Far` | 2 |
| `VeryFar` | 3 |

## CommonPedFacialAnimation

enum `GTA.CommonPedFacialAnimation`

| Name | Value |
| --- | --- |
| `Burning` | 0 |
| `Coughing` | 1 |
| `Dead1` | 2 |
| `Dead2` | 3 |
| `Die1` | 4 |
| `Die2` | 5 |
| `Electrocuted` | 6 |
| `Effort` | 7 |
| `MeleeEffort1` | 8 |
| `MeleeEffort2` | 9 |
| `MeleeEffort3` | 10 |
| `MoodAiming` | 11 |
| `MoodAngry` | 12 |
| `MoodDrivefast` | 13 |
| `MoodDrunk` | 14 |
| `MoodExcited` | 15 |
| `MoodFrustrated` | 16 |
| `MoodHappy` | 17 |
| `MoodInjured` | 18 |
| `MoodNormal` | 19 |
| `MoodSleeping` | 20 |
| `MoodSkydive` | 21 |
| `MoodStressed` | 22 |
| `MoodTalking` | 23 |
| `Pain1` | 24 |
| `Pain2` | 25 |
| `Pain3` | 26 |
| `Pain4` | 27 |
| `Pain5` | 28 |
| `Pain6` | 29 |

## CommonPedFacialAnimationExtensions

static class `GTA.CommonPedFacialAnimationExtensions`

### Methods

- `public static string GetAnimationName(CommonPedFacialAnimation animation)`

## Control

enum `GTA.Control`

365 values:

```text
NextCamera = 0
LookLeftRight = 1
LookUpDown = 2
LookUpOnly = 3
LookDownOnly = 4
LookLeftOnly = 5
LookRightOnly = 6
CinematicSlowMo = 7
FlyUpDown = 8
FlyLeftRight = 9
ScriptedFlyZUp = 10
ScriptedFlyZDown = 11
WeaponWheelUpDown = 12
WeaponWheelLeftRight = 13
WeaponWheelNext = 14
WeaponWheelPrev = 15
SelectNextWeapon = 16
SelectPrevWeapon = 17
SkipCutscene = 18
CharacterWheel = 19
MultiplayerInfo = 20
Sprint = 21
Jump = 22
Enter = 23
Attack = 24
Aim = 25
LookBehind = 26
Phone = 27
SpecialAbility = 28
SpecialAbilitySecondary = 29
MoveLeftRight = 30
MoveUpDown = 31
MoveUpOnly = 32
MoveDownOnly = 33
MoveLeftOnly = 34
MoveRightOnly = 35
Duck = 36
SelectWeapon = 37
Pickup = 38
SniperZoom = 39
SniperZoomInOnly = 40
SniperZoomOutOnly = 41
SniperZoomInSecondary = 42
SniperZoomOutSecondary = 43
Cover = 44
Reload = 45
Talk = 46
Detonate = 47
HUDSpecial = 48
Arrest = 49
AccurateAim = 50
Context = 51
ContextSecondary = 52
WeaponSpecial = 53
WeaponSpecial2 = 54
Dive = 55
DropWeapon = 56
DropAmmo = 57
ThrowGrenade = 58
VehicleMoveLeftRight = 59
VehicleMoveUpDown = 60
VehicleMoveUpOnly = 61
VehicleMoveDownOnly = 62
VehicleMoveLeftOnly = 63
VehicleMoveRightOnly = 64
VehicleSpecial = 65
VehicleGunLeftRight = 66
VehicleGunUpDown = 67
VehicleAim = 68
VehicleAttack = 69
VehicleAttack2 = 70
VehicleAccelerate = 71
VehicleBrake = 72
VehicleDuck = 73
VehicleHeadlight = 74
VehicleExit = 75
VehicleHandbrake = 76
VehicleHotwireLeft = 77
VehicleHotwireRight = 78
VehicleLookBehind = 79
VehicleCinCam = 80
VehicleNextRadio = 81
VehiclePrevRadio = 82
VehicleNextRadioTrack = 83
VehiclePrevRadioTrack = 84
VehicleRadioWheel = 85
VehicleHorn = 86
VehicleFlyThrottleUp = 87
VehicleFlyThrottleDown = 88
VehicleFlyYawLeft = 89
VehicleFlyYawRight = 90
VehiclePassengerAim = 91
VehiclePassengerAttack = 92
VehicleSpecialAbilityFranklin = 93
VehicleStuntUpDown = 94
VehicleCinematicUpDown = 95
VehicleCinematicUpOnly = 96
VehicleCinematicDownOnly = 97
VehicleCinematicLeftRight = 98
VehicleSelectNextWeapon = 99
VehicleSelectPrevWeapon = 100
VehicleRoof = 101
VehicleJump = 102
VehicleGrapplingHook = 103
VehicleShuffle = 104
VehicleDropProjectile = 105
VehicleMouseControlOverride = 106
VehicleFlyRollLeftRight = 107
VehicleFlyRollLeftOnly = 108
VehicleFlyRollRightOnly = 109
VehicleFlyPitchUpDown = 110
VehicleFlyPitchUpOnly = 111
VehicleFlyPitchDownOnly = 112
VehicleFlyUnderCarriage = 113
VehicleFlyAttack = 114
VehicleFlySelectNextWeapon = 115
VehicleFlySelectPrevWeapon = 116
VehicleFlySelectTargetLeft = 117
VehicleFlySelectTargetRight = 118
VehicleFlyVerticalFlightMode = 119
VehicleFlyDuck = 120
VehicleFlyAttackCamera = 121
VehicleFlyMouseControlOverride = 122
VehicleSubTurnLeftRight = 123
VehicleSubTurnLeftOnly = 124
VehicleSubTurnRightOnly = 125
VehicleSubPitchUpDown = 126
VehicleSubPitchUpOnly = 127
VehicleSubPitchDownOnly = 128
VehicleSubThrottleUp = 129
VehicleSubThrottleDown = 130
VehicleSubAscend = 131
VehicleSubDescend = 132
VehicleSubTurnHardLeft = 133
VehicleSubTurnHardRight = 134
VehicleSubMouseControlOverride = 135
VehiclePushbikePedal = 136
VehiclePushbikeSprint = 137
VehiclePushbikeFrontBrake = 138
VehiclePushbikeRearBrake = 139
MeleeAttackLight = 140
MeleeAttackHeavy = 141
MeleeAttackAlternate = 142
MeleeBlock = 143
ParachuteDeploy = 144
ParachuteDetach = 145
ParachuteTurnLeftRight = 146
ParachuteTurnLeftOnly = 147
ParachuteTurnRightOnly = 148
ParachutePitchUpDown = 149
ParachutePitchUpOnly = 150
ParachutePitchDownOnly = 151
ParachuteBrakeLeft = 152
ParachuteBrakeRight = 153
ParachuteSmoke = 154
ParachutePrecisionLanding = 155
Map = 156
SelectWeaponUnarmed = 157
SelectWeaponMelee = 158
SelectWeaponHandgun = 159
SelectWeaponShotgun = 160
SelectWeaponSmg = 161
SelectWeaponAutoRifle = 162
SelectWeaponSniper = 163
SelectWeaponHeavy = 164
SelectWeaponSpecial = 165
SelectCharacterMichael = 166
SelectCharacterFranklin = 167
SelectCharacterTrevor = 168
SelectCharacterMultiplayer = 169
SaveReplayClip = 170
SpecialAbilityPC = 171
PhoneUp = 172
PhoneDown = 173
PhoneLeft = 174
PhoneRight = 175
PhoneSelect = 176
PhoneCancel = 177
PhoneOption = 178
PhoneExtraOption = 179
PhoneScrollForward = 180
PhoneScrollBackward = 181
PhoneCameraFocusLock = 182
PhoneCameraGrid = 183
PhoneCameraSelfie = 184
PhoneCameraDOF = 185
PhoneCameraExpression = 186
FrontendDown = 187
FrontendUp = 188
FrontendLeft = 189
FrontendRight = 190
FrontendRdown = 191
FrontendRup = 192
FrontendRleft = 193
FrontendRright = 194
FrontendAxisX = 195
FrontendAxisY = 196
FrontendRightAxisX = 197
FrontendRightAxisY = 198
FrontendPause = 199
FrontendPauseAlternate = 200
FrontendAccept = 201
FrontendCancel = 202
FrontendX = 203
FrontendY = 204
FrontendLb = 205
FrontendRb = 206
FrontendLt = 207
FrontendRt = 208
FrontendLs = 209
FrontendRs = 210
FrontendLeaderboard = 211
FrontendSocialClub = 212
FrontendSocialClubSecondary = 213
FrontendDelete = 214
FrontendEndscreenAccept = 215
FrontendEndscreenExpand = 216
FrontendSelect = 217
ScriptLeftAxisX = 218
ScriptLeftAxisY = 219
ScriptRightAxisX = 220
ScriptRightAxisY = 221
ScriptRUp = 222
ScriptRDown = 223
ScriptRLeft = 224
ScriptRRight = 225
ScriptLB = 226
ScriptRB = 227
ScriptLT = 228
ScriptRT = 229
ScriptLS = 230
ScriptRS = 231
ScriptPadUp = 232
ScriptPadDown = 233
ScriptPadLeft = 234
ScriptPadRight = 235
ScriptSelect = 236
CursorAccept = 237
CursorCancel = 238
CursorX = 239
CursorY = 240
CursorScrollUp = 241
CursorScrollDown = 242
EnterCheatCode = 243
InteractionMenu = 244
MpTextChatAll = 245
MpTextChatTeam = 246
MpTextChatFriends = 247
MpTextChatCrew = 248
PushToTalk = 249
CreatorLS = 250
CreatorRS = 251
CreatorLT = 252
CreatorRT = 253
CreatorMenuToggle = 254
CreatorAccept = 255
CreatorDelete = 256
Attack2 = 257
RappelJump = 258
RappelLongJump = 259
RappelSmashWindow = 260
PrevWeapon = 261
NextWeapon = 262
MeleeAttack1 = 263
MeleeAttack2 = 264
Whistle = 265
MoveLeft = 266
MoveRight = 267
MoveUp = 268
MoveDown = 269
LookLeft = 270
LookRight = 271
LookUp = 272
LookDown = 273
SniperZoomIn = 274
SniperZoomOut = 275
SniperZoomInAlternate = 276
SniperZoomOutAlternate = 277
VehicleMoveLeft = 278
VehicleMoveRight = 279
VehicleMoveUp = 280
VehicleMoveDown = 281
VehicleGunLeft = 282
VehicleGunRight = 283
VehicleGunUp = 284
VehicleGunDown = 285
VehicleLookLeft = 286
VehicleLookRight = 287
ReplayStartStopRecording = 288
ReplayStartStopRecordingSecondary = 289
ScaledLookLeftRight = 290
ScaledLookUpDown = 291
ScaledLookUpOnly = 292
ScaledLookDownOnly = 293
ScaledLookLeftOnly = 294
ScaledLookRightOnly = 295
ReplayMarkerDelete = 296
ReplayClipDelete = 297
ReplayPause = 298
ReplayRewind = 299
ReplayFfwd = 300
ReplayNewmarker = 301
ReplayRecord = 302
ReplayScreenshot = 303
ReplayHidehud = 304
ReplayStartpoint = 305
ReplayEndpoint = 306
ReplayAdvance = 307
ReplayBack = 308
ReplayTools = 309
ReplayRestart = 310
ReplayShowhotkey = 311
ReplayCycleMarkerLeft = 312
ReplayCycleMarkerRight = 313
ReplayFOVIncrease = 314
ReplayFOVDecrease = 315
ReplayCameraUp = 316
ReplayCameraDown = 317
ReplaySave = 318
ReplayToggletime = 319
ReplayToggletips = 320
ReplayPreview = 321
ReplayToggleTimeline = 322
ReplayTimelinePickupClip = 323
ReplayTimelineDuplicateClip = 324
ReplayTimelinePlaceClip = 325
ReplayCtrl = 326
ReplayTimelineSave = 327
ReplayPreviewAudio = 328
VehicleDriveLook = 329
VehicleDriveLook2 = 330
VehicleFlyAttack2 = 331
RadioWheelUpDown = 332
RadioWheelLeftRight = 333
VehicleSlowMoUpDown = 334
VehicleSlowMoUpOnly = 335
VehicleSlowMoDownOnly = 336
VehicleHydraulicsControlToggle = 337
VehicleHydraulicsControlLeft = 338
VehicleHydraulicsControlRight = 339
VehicleHydraulicsControlUp = 340
VehicleHydraulicsControlDown = 341
VehicleHydraulicsControlLeftRight = 342
VehicleHydraulicsControlUuDown = 343
SwitchVisor = 344
VehicleMeleeHold = 345
VehicleMeleeLeft = 346
VehicleMeleeRight = 347
MapPointOfInterest = 348
ReplaySnapmaticPhoto = 349
VehicleCarJump = 350
VehicleRocketBoost = 351
VehicleFlyBoost = 352
VehicleParachute = 353
VehicleBikeWings = 354
VehicleFlyBombBay = 355
VehicleFlyCounter = 356
VehicleFlyTransform = 357
QuadLocoReverse = 358
RespawnFaster = 359
HudmarkerSelect = 360
EatSnack = 361
UseArmor = 362
VehicleShiftGearUp = 363
VehicleShiftGearDown = 364
```

## CrClipAsset

struct `GTA.CrClipAsset` : `IEquatable<CrClipAsset>`

### Constructors

- `public CrClipAsset(CrClipDictionary clipDict, string animName)`
- `public CrClipAsset(string clipDictName, string animName)`

### Properties

- `public CrClipDictionary ClipDictionary { get; set; }`
- `public string ClipName { get; set; }`

### Methods

- `public void Deconstruct(out CrClipDictionary clipDict, out string clipName)`
- `public bool Equals(CrClipAsset other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public AtHashValue HashClipName()`
- `public static bool op_Equality(CrClipAsset left, CrClipAsset right)`
- `public static bool op_Inequality(CrClipAsset left, CrClipAsset right)`

## CrClipDictionary

struct `GTA.CrClipDictionary` : `IEquatable<CrClipDictionary>`, `IScriptStreamingResource`

### Constructors

- `public CrClipDictionary(string name)`

### Properties

- `public bool Exists { get; }`
- `public bool IsLoaded { get; }`
- `public string Name { get; }`

### Methods

- `public bool Equals(CrClipDictionary other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public AtHashValue HashName()`
- `public void MarkAsNoLongerNeeded()`
- `public void Request()`
- `public virtual string ToString()`
- `public static bool op_Equality(CrClipDictionary left, CrClipDictionary right)`
- `public static string op_Explicit(CrClipDictionary value)`
- `public static CrClipDictionary op_Explicit(string value)`
- `public static InputArgument op_Implicit(CrClipDictionary value)`
- `public static bool op_Inequality(CrClipDictionary left, CrClipDictionary right)`

## CrimeType

enum `GTA.CrimeType`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `PossessionGun` | 1 |
| `RunRedLight` | 2 |
| `RecklessDriving` | 3 |
| `Speeding` | 4 |
| `DriveAgainstTraffic` | 5 |
| `RidingBikeWithoutHelmet` | 6 |
| `StealVehicle` | 7 |
| `StealCar` | 8 |
| `BlockPoliceCar` | 9 |
| `StandOnPoliceCar` | 10 |
| `HitPed` | 11 |
| `HitCop` | 12 |
| `ShootPed` | 13 |
| `ShootCop` | 14 |
| `RunOverPed` | 15 |
| `RunOverCop` | 16 |
| `DestroyHeli` | 17 |
| `PedSetOnFire` | 18 |
| `CopSetOnFire` | 19 |
| `CarSetOnFire` | 20 |
| `DestroyPlane` | 21 |
| `CauseExplosion` | 22 |
| `StabPed` | 23 |
| `StabCop` | 24 |
| `DestroyVehicle` | 25 |
| `DamageToProperty` | 26 |
| `TargetCop` | 27 |
| `FirearmDischarge` | 28 |
| `ResistArrest` | 29 |
| `Molotov` | 30 |
| `ShootNonLethalPed` | 31 |
| `ShootNonLethalCop` | 32 |
| `KillCop` | 33 |
| `ShootAtCop` | 34 |
| `ShootVehicle` | 35 |
| `TerroristActivity` | 36 |
| `Hassle` | 37 |
| `ThrowGrenade` | 38 |
| `VehicleExplosion` | 39 |
| `KillPed` | 40 |
| `StealthKillCop` | 41 |
| `Suicide` | 42 |
| `Disturbance` | 43 |
| `CivilianNeedsAssistance` | 44 |
| `StealthKillPed` | 45 |
| `ShootPedSuppressed` | 46 |
| `JackDeadPed` | 47 |
| `ChainExplosion` | 48 |

## DamageType

enum `GTA.DamageType`

| Name | Value |
| --- | --- |
| `Unknown` | 0 |
| `None` | 1 |
| `Melee` | 2 |
| `Bullet` | 3 |
| `BulletRubber` | 4 |
| `Explosive` | 5 |
| `Fire` | 6 |
| `Collision` | 7 |
| `Fall` | 8 |
| `Drown` | 9 |
| `Electric` | 10 |
| `BarbedWire` | 11 |
| `FireExtinguisher` | 12 |
| `Smoke` | 13 |
| `WaterCannon` | 14 |
| `Tranquilizer` | 15 |

## DecisionMaker

struct `GTA.DecisionMaker` : `INativeValue`, `IEquatable<DecisionMaker>`

### Constructors

- `public DecisionMaker(DecisionMakerTypeHash hash)`
- `public DecisionMaker(int hash)`
- `public DecisionMaker(uint hash)`

### Properties

- `public DecisionMakerTypeHash Hash { get; }`
- `public bool IsNullValue { get; }`
- `public ulong NativeValue { get; set; }`

### Methods

- `public bool Equals(DecisionMaker group)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public virtual string ToString()`
- `public static bool op_Equality(DecisionMaker left, DecisionMaker right)`
- `public static InputArgument op_Implicit(DecisionMaker value)`
- `public static DecisionMaker op_Implicit(DecisionMakerTypeHash source)`
- `public static DecisionMaker op_Implicit(int source)`
- `public static DecisionMaker op_Implicit(string source)`
- `public static DecisionMaker op_Implicit(uint source)`
- `public static bool op_Inequality(DecisionMaker left, DecisionMaker right)`

## DecisionMakerTypeHash

enum `GTA.DecisionMakerTypeHash`

| Name | Value |
| --- | --- |
| `Player` | 1862763509 |
| `Cop` | 2761840924 |
| `Fireman` | 4230784871 |
| `Medic` | 2957130400 |
| `OffDutyEmt` | 756351882 |
| `Security` | 3222549788 |
| `Swat` | 2558032230 |
| `Empty` | 3151330285 |
| `Base` | 1155669136 |
| `Default` | 3839837909 |
| `Gang` | 3154537368 |
| `Family` | 389469343 |
| `Gull` | 872620134 |
| `Hen` | 3222287865 |
| `Rat` | 570755475 |
| `Fish` | 1630085303 |
| `Shark` | 580191176 |
| `Horse` | 2510745927 |
| `DomesticAnimal` | 899759671 |
| `Dog` | 2332652347 |
| `WildAnimal` | 2274167504 |
| `Cougar` | 3457367416 |
| `SmallAnimal` | 2935583381 |
| `Cat` | 1157867945 |
| `Rabbit` | 3443217914 |

## DecoratorInterface

static class `GTA.DecoratorInterface`

### Properties

- `public static bool IsLocked { get; set; }`

### Methods

- `public static bool ExistsOn(Entity entity, string decoratorName)`
- `public static bool GetBool(Entity entity, string decoratorName)`
- `public static float GetFloat(Entity entity, string decoratorName)`
- `public static int GetInt(Entity entity, string decoratorName)`
- `public static bool IsRegisteredAsType(string decoratorName, DecoratorType type)`
- `public static void Register(string decoratorName, DecoratorType type)`
- `public static bool Remove(Entity entity, string decoratorName)`
- `public static bool SetBool(Entity entity, string decoratorName, bool value)`
- `public static bool SetFloat(Entity entity, string decoratorName, float value)`
- `public static bool SetInt(Entity entity, string decoratorName, int value)`
- `public static bool SetTime(Entity entity, string decoratorName, int value)`

## DecoratorType

enum `GTA.DecoratorType`

| Name | Value |
| --- | --- |
| `Unknown` | 0 |
| `Float` | 1 |
| `Bool` | 2 |
| `Int` | 3 |
| `String` | 4 |
| `Time` | 5 |

## Direction

enum `GTA.Direction`

| Name | Value |
| --- | --- |
| `Any` | -1 |
| `Forwards` | 0 |
| `Backwards` | 1 |

## DispatchData

static class `GTA.DispatchData`

### Methods

- `public static float GetWantedLevelRadius(int wantedLevel)`
- `public static int GetWantedLevelThreshold(int wantedLevel)`

## DlcWeaponComponentData.<desc>e__FixedBuffer

struct `GTA.DlcWeaponComponentData.<desc>e__FixedBuffer`

### Fields

- `public byte FixedElementField`

## DlcWeaponComponentData.<name>e__FixedBuffer

struct `GTA.DlcWeaponComponentData.<name>e__FixedBuffer`

### Fields

- `public byte FixedElementField`

## DlcWeaponData.<desc>e__FixedBuffer

struct `GTA.DlcWeaponData.<desc>e__FixedBuffer`

### Fields

- `public byte FixedElementField`

## DlcWeaponData.<name>e__FixedBuffer

struct `GTA.DlcWeaponData.<name>e__FixedBuffer`

### Fields

- `public byte FixedElementField`

## DlcWeaponData.<simpleDesc>e__FixedBuffer

struct `GTA.DlcWeaponData.<simpleDesc>e__FixedBuffer`

### Fields

- `public byte FixedElementField`

## DlcWeaponData.<upperCaseName>e__FixedBuffer

struct `GTA.DlcWeaponData.<upperCaseName>e__FixedBuffer`

### Fields

- `public byte FixedElementField`

## DrawBoxFlags

enum `GTA.DrawBoxFlags`

| Name | Value |
| --- | --- |
| `OutsideOnly` | 1 |
| `InsideOnly` | 2 |
| `BothSides` | 3 |

## DrivingStyle

enum `GTA.DrivingStyle`

> **Obsolete.** Use VehicleDrivingFlags instead.

| Name | Value |
| --- | --- |
| `Normal` | 786603 |
| `IgnoreLights` | 2883621 |
| `SometimesOvertakeTraffic` | 5 |
| `Rushed` | 1074528293 |
| `AvoidTraffic` | 786468 |
| `AvoidTrafficExtremely` | 6 |

## EnterVehicleFlags

enum `GTA.EnterVehicleFlags`

Set of flags to define the behaviour of the enter and exit vehicle tasks. Shares the same flags with `LeaveVehicleFlags`.

| Name | Value | Description |
| --- | --- | --- |
| `None` | 0 |  |
| `ResumeIfInterupted` | 1 | Resume the enter vehicle task even if the task is interupted (bumped, shot). |
| `WarpToDoor` | 2 | Warp the `Ped` to entry point ready to open the door/enter seat. |
| `JackAnyone` | 8 | Allow the `Ped` to jack regardless of relationship status if they have to jack someone to complete the enter vehicle task. Without this flag, the `Ped` won't jack those they respect or like where the relationship is set to `Companion` or `Respect` towards them, but may jack those they don't respect or like. Without this flag, the `Ped` will abort the enter vehicle task if they have to jack one of those who respect or like to complete the enter vehicle task. |
| `WarpIn` | 16 | Warp the `Ped` onto the `Vehicle`. |
| `DontCloseDoor` | 256 | Dont close the vehicle door. |
| `WarpIfDoorIsBlocked` | 512 | Allow ped to warp to the seat if entry is blocked. If the shuffle link to that seat is blocked by someone but the entry point for the shuffle link is not directly blocked, the `Ped` won't warp. Consider using `WarpIfShuffleLinkIsBlocked` if you want the `Ped` to warp when the direct door and the shuffle link to that seat is blocked by someone. |
| `UseLeftEntry` | 131072 | Use entry/exit point on the left hand side. |
| `UseRightEntry` | 262144 | Use entry/exit point on the right hand side. |
| `JustPullPedOut` | 524288 | When jacking just open the door and/or pull the ped out, but don't get in. |
| `BlockSeatShuffling` | 1048576 | Disable shuffling, forcing ped to use direct door only. |
| `WarpIfShuffleLinkIsBlocked` | 4194304 | Allow ped to warp if the direct door is blocked and the shuffle link to that seat is blocked by someone. Unlike `WarpIfDoorIsBlocked`, this flag allows the the `Ped` to warp when the direct door and the shuffle link to that seat is blocked by someone (regardless of whether the door linked to the shuffle link is directly blocked). |
| `DontJackAnyone` | 8388608 | Never jack anyone when entering/exiting. This flag takes precedence over `AllowJacking`. |
| `AllowJacking` | 8 |  |
| `EnterFromOppositeSide` | 262144 |  |
| `OnlyOpenDoor` | 524288 |  |

## Entity

abstract class `GTA.Entity` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Properties

- `public Vector3 AbovePosition { get; }`
  - Gets a position directly above this `Entity`.
- `public bool AllowsFreezeWaitingOnCollision { get; set; }`
- `public Blip AttachedBlip { get; }`
  - Gets the `Blip` attached to this `Entity`.
- `public Blip[] AttachedBlips { get; }`
  - Gets an `array` of all `Blip`s attached to this `Entity`.
- `public Entity AttachedEntity { get; }`
  - Gets the `Entity` this `Entity` is attached to. returns `null` if this `Entity` isnt attached to any entity
- `public Vector3 BelowPosition { get; }`
  - Gets a position directly below this `Entity`.
- `public bool BlocksAnyDamageButHasReactions { get; set; }`
- `public bool BlocksDamageByRelGroup { get; set; }`
- `public EntityBoneCollection Bones { get; }`
  - Gets a collection of the `EntityBone`s in this `Entity`.
- `public bool CanBeAutoVaulted { get; set; }`
- `public bool CanBeClimbed { get; set; }`
- `public bool CanOnlyBeDamagedByRelGroup { get; set; }`
- `public Vector3 CenterOfGravityOffset { get; set; }`
- `public InteriorProxy CurrentInteriorProxy { get; }`
- `public int CurrentInteriorRoomKey { get; }`
- `public EntityDamageRecordCollection DamageRecords { get; }`
  - Gets a collection of the `EntityDamageRecord`s in this `Entity`.
- `public bool DontLoadCollision { get; set; }`
- `public EntityType EntityType { get; }`
  - Gets the type of the current `Entity`.
- `public Vector3 ForwardVector { get; }`
  - Gets the vector that points in front of this `Entity`.
- `public int FragmentGroupCount { get; }`
  - Returns the number of fragment group of this `Entity`.
- `public Vector3 FrontPosition { get; }`
  - Gets a position directly in front of this `Entity`.
- `public bool HasAnimationDirector { get; }`
- `public bool HasCollided { get; }`
  - Gets a value indicating whether this `Entity` has collided with anything.
- `public bool HasCollidedWithBuildingOrAnimatedBuilding { get; }`
- `public bool HasDrawable { get; }`
- `public bool HasGravity { get; set; }`
  - Gets or sets a value indicating whether this `Entity` has gravity.
- `public bool HasPhysics { get; }`
- `public bool HasSkeleton { get; }`
- `public float Heading { get; set; }`
  - Gets or sets the heading of this `Entity`.
- `public int Health { get; set; }`
  - Gets or sets the health of this `Entity` as an `Int32`. Use `HealthFloat` instead if you need to get or set the value precisely, since a health value of a `Entity` are stored as a `Single`.
- `public float HealthFloat { get; set; }`
  - Gets or sets the health of this `Entity` as a `Single`.
- `public float HeightAboveGround { get; }`
  - Gets how high above ground this `Entity` is.
- `public bool IsAlive { get; }`
  - Gets a value indicating whether this `Entity` exists and is alive.
- `public bool IsBulletProof { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is bullet proof.
- `public bool IsCollisionEnabled { get; set; }`
  - Gets or sets a value indicating whether this `Entity` has collision.
- `public bool IsCollisionProof { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is collision proof. Setting this property to `true` only does not prevent this `Entity` from getting ragdolled when another `Entity` collide with this `Entity`.
- `public bool IsDead { get; }`
  - Gets a value indicating whether this `Entity` is dead or does not exist.
- `public bool IsExplosionProof { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is explosion proof. Explosions cannot add force to this `Entity` and `Ped`s do not getting ragdolled with explosions when this property is set to `true`.
- `public bool IsFireProof { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is fire proof. This `Entity` does not catch fire naturally and `Ped`s do not getting ragdolled for being burned when this property is set to `true`.
- `public bool IsFragmentObject { get; }`
  - Determines if this `Entity` is a fragment object.
  - Returns: `true` if this `Entity` is a fragment object; otherwise, `false`. This will return `true` if this `Entity` is a `Ped` or a `Vehicle`.
- `public bool IsInAir { get; }`
  - Gets a value indicating whether this `Entity` is in the air.
- `public bool IsInvincible { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is invincible. Setting this property to `true` does not prevent `Ped`s from doing the reactions for getting hit with melee attacks.
- `public bool IsInWater { get; }`
  - Gets a value indicating whether this `Entity` is in water.
- `public bool IsInWaterStrict { get; }`
- `public bool IsMeleeProof { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is melee proof. `Ped`s are not susceptible to the reactions of melee attacks when this property is set to `true`.
- `public bool IsOccluded { get; }`
  - Gets a value indicating whether this `Entity` is occluded.
- `public bool IsOnFire { get; }`
  - Gets a value indicating whether this `Entity` is on fire.
- `public bool IsOnlyDamagedByPlayer { get; set; }`
  - Gets or sets a value indicating whether this `Entity` can only be damaged by `Player`s. `Ped`s are not susceptible to the reactions of melee attacks when this property is set to `true`, unlike `IsInvincible`.
- `public bool IsOnScreen { get; }`
  - Gets a value indicating whether this `Entity` is on screen.
- `public bool IsOwnedByAnyScript { get; }`
- `public bool IsOwnedByShvdnScript { get; }`
- `public bool IsPersistent { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is persistent.
- `public bool IsPickupByCargobobDisabled { get; set; }`
- `public bool IsPositionFrozen { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is frozen.
- `public bool IsRecordingCollisions { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is recording collisions.
- `public bool IsRendered { get; }`
  - Gets a value indicating whether this `Entity` is rendered.
- `public bool IsSmokeProof { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is smoke proof.
- `public bool IsStatic { get; }`
- `public bool IsSteamProof { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is steam proof.
- `public bool IsUpright { get; }`
  - Gets a value indicating whether this `Entity` is upright.
- `public bool IsUpsideDown { get; }`
  - Gets a value indicating whether this `Entity` is upside down.
- `public bool IsVisible { get; set; }`
  - Gets or sets a value indicating whether this `Entity` is visible.
- `public bool IsWaterCannonProof { get; set; }`
  - **Obsolete.** Entity.IsWaterCannonProof is obsolete because CPhysical has no flags that makes it water cannon proof.
  - Gets or sets a value indicating whether this `Entity` is water cannon proof. `Ped`s does not get ragdolled by the water jet from fire hydrants when this property is set to `true`.
- `public bool KeepsDamageFlagsOnCleanupMissionState { get; set; }`
- `public Vector3 LeftPosition { get; }`
  - Gets a position directly to the left of this `Entity`.
- `public Vector3 LocalRotationVelocity { get; set; }`
- `public int LodDistance { get; set; }`
  - Gets or sets the level of detail distance of this `Entity`.
- `public MaterialHash MaterialCollidingWith { get; }`
  - Gets the material this `Entity` is pushing up against.
- `public Matrix Matrix { get; }`
  - Gets this `Entity`s matrix which stores position and rotation information.
- `public int MaxHealth { get; set; }`
  - Gets or sets the maximum health of this `Entity` as an `Int32`. Use `MaxHealthFloat` instead if you need to get or set the value precisely, since a max health value of a `Entity` are stored as a `Single`.
- `public float MaxHealthFloat { get; set; }`
  - Gets or sets the maximum health of this `Entity` as a `Single`.
- `public float MaxSpeed { set; }`
  - Sets the maximum speed this `Entity` can move at.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where the `Entity` is stored in memory.
- `public Model Model { get; }`
  - Gets the model of the current `Entity`.
- `public int Opacity { get; set; }`
  - Gets or sets how opaque this `Entity` is.
- `public string OwnerScriptName { get; }`
- `public Ped PedCollidingWith { get; }`
- `public EntityPopulationType PopulationType { get; set; }`
  - Gets or sets the population type of the current `Entity`. This property can also be used to add or remove `Entity` persistence.
- `public Vector3 Position { get; set; }`
  - Gets or sets the position of this `Entity`. If the `Entity` is `Ped` and the `Ped` is in a `Vehicle`, the `Vehicle`'s position will be returned or changed.
- `public Vector3 PositionNoOffset { set; }`
  - Sets the position of this `Entity` without any offset.
- `public Prop PropCollidingWith { get; }`
- `public Quaternion Quaternion { get; set; }`
  - Gets or sets the quaternion of this `Entity`.
- `public Vector3 RearPosition { get; }`
  - Gets a position directly behind this `Entity`.
- `public Vector3 RightPosition { get; }`
  - Gets a position directly to the right of this `Entity`.
- `public Vector3 RightVector { get; }`
  - Gets the vector that points to the right of this `Entity`.
- `public Vector3 Rotation { get; set; }`
  - Gets or sets the rotation of this `Entity`.
- `public Vector3 RotationVelocity { get; set; }`
  - **Obsolete.** Entity.RotationVelocity is obsolete because GET_ENTITY_ROTATION_VELOCITY returns the world angular velocity with local to world conversion applied. Use Entity.LocalRotationVelocity instead.
  - Gets or sets the rotation velocity of this `Entity` in local space.
- `public bool ShouldRenderScorched { get; set; }`
- `public RelationshipGroup SpecificRelGroupForInflictorChecks { get; set; }`
- `public float Speed { get; set; }`
  - Gets or sets this `Entity`s speed.
- `public float SubmersionLevel { get; }`
  - Gets a value indicating how submersed this `Entity` is, 1.0f means the whole entity is submerged.
- `public float UprightValue { get; }`
- `public Vector3 UpVector { get; }`
  - Gets the vector that points above this `Entity`.
- `public Vehicle VehicleCollidingWith { get; }`
- `public Vector3 Velocity { get; set; }`
  - Gets or sets the velocity of this `Entity`.
- `public bool WasInWater { get; }`
- `public Vector3 WorldRotationVelocity { get; set; }`
  - Gets or sets the rotation velocity of this `Entity` in world space.

### Methods

- `public void ActivatePhysics()`
- `public Blip AddBlip()`
  - Creates a `Blip` on this `Entity`.
- `public void ApplyForce(Vector3 direction, Vector3 rotation = null, ForceType forceType = 3)`
  - Applies a force to this `Entity`.
  - `direction`: The direction to apply the force relative to world coordinates.
  - `rotation`: The offset from the root bone of this `Entity` where the force applies. "rotation" is incorrectly named parameter but is left for scripts that use the method with named parameters.
  - `forceType`: Type of the force to apply.
- `public void ApplyForceRelative(Vector3 direction, Vector3 rotation = null, ForceType forceType = 3)`
  - Applies a force to this `Entity`.
  - `direction`: The direction to apply the force relative to this `Entity`s rotation
  - `rotation`: The offset from the root bone of this `Entity` where the force applies. "rotation" is incorrectly named parameter but is left for scripts that use the method with named parameters.
  - `forceType`: Type of the force to apply.
- `public void ApplyRelativeForceCenterOfMass(Vector3 force, ForceType forceType, bool scaleByMass, bool applyToChildren = false)`
- `public void ApplyRelativeForceRelativeOffset(Vector3 force, Vector3 offset, ForceType forceType, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void ApplyRelativeForceWorldOffset(Vector3 force, Vector3 offset, ForceType forceType, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void ApplyWorldForceCenterOfMass(Vector3 force, ForceType forceType, bool scaleByMass, bool applyToChildren = false)`
- `public void ApplyWorldForceRelativeOffset(Vector3 force, Vector3 offset, ForceType forceType, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void ApplyWorldForceWorldOffset(Vector3 force, Vector3 offset, ForceType forceType, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void AttachTo(Entity entity, Vector3 offset, Vector3 rotation, bool detachWhenDead = false, bool detachWhenRagdoll = false, bool activeCollisions = false, bool useBasicAttachIfPed = false, EulerRotationOrder rotationOrder = 2, bool attachOffsetIsRelative = true, bool markAsNoLongerNeededWhenDetached = false)`
- `public void AttachTo(Entity entity, Vector3 position = null, Vector3 rotation = null)`
  - Attaches this `Entity` to a different `Entity`
  - `entity`: The `Entity` to attach this `Entity` to.
  - `position`: The position relative to the `entity` to attach this `Entity` to.
  - `rotation`: The rotation to apply to this `Entity` relative to the `entity`
- `public void AttachTo(EntityBone entityBone, Vector3 offset, Vector3 rotation, bool detachWhenDead = false, bool detachWhenRagdoll = false, bool activeCollisions = false, bool useBasicAttachIfPed = false, EulerRotationOrder rotationOrder = 2, bool attachOffsetIsRelative = true, bool markAsNoLongerNeededWhenDetached = false)`
- `public void AttachTo(EntityBone entityBone, Vector3 position = null, Vector3 rotation = null)`
  - Attaches this `Entity` to a different `Entity`
  - `entityBone`: The `EntityBone` to attach this `Entity` to.
  - `position`: The position relative to the `entityBone` to attach this `Entity` to.
  - `rotation`: The rotation to apply to this `Entity` relative to the `entityBone`
- `public void AttachToBonePhysically(EntityBone boneOfSecondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2)`
- `public void AttachToBonePhysicallyOverrideInverseMass(EntityBone boneOfSecondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2, float invMassScaleA = 1, float invMassScaleB = 1)`
- `public void AttachToMatrixPhysically(Entity secondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2)`
- `public void AttachToMatrixPhysicallyOverrideInverseMass(Entity secondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2, float invMassScaleA = 1, float invMassScaleB = 1)`
- `public virtual void ClearLastWeaponDamage()`
  - Clears the last weapon damage this `Entity` received.
- `public void ClearNotDamagedByRelGroup()`
- `public void ClearOnlyDamagedByRelGroup()`
- `public void DeactivatePhysics()`
- `public virtual void Delete()`
  - Destroys this `Entity` and sets `Handle` to 0. If you need to remove this `Entity` from collections that use `Equals` for equality comparison (e.g. `Dictionary`2`), remove this `Entity` element from these collections before calling this method.
- `public void Detach()`
  - Detaches this `Entity` from any `Entity` it may be attached to.
- `public void Detach(bool applyVelocity, bool noCollisionUntilClear)`
- `public bool DetachFragmentPart(int fragmentGroupIndex)`
  - Detachs a fragment part of this `Entity`. Can create a new `Entity`.
  - Returns: `true` if a new `Entity` is created; otherwise, `false`. Returning `false` does not necessarily mean detaching the part did not change the `Entity` in any ways. For example, detaching `seat_f` for `Vehicle` will return `false` but the `Ped` on the front seat will not be able to sit properly.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same entity as this `Entity`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same entity as this `Entity`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `Entity` exists. You should ensure `Entity`s still exist before manipulating them or getting some values for them on every tick, since some native functions may crash the game if invalid entity handles are passed.
  - Returns: `true` if this `Entity` exists; otherwise, `false`
- `public bool FindAnimationEventPhase(CrClipAsset crClipAsset, string eventName, out float startPhase, out float endPhase)`
- `public float GetAnimationCurrentTime(CrClipAsset crClipAsset)`
- `public float GetAnimationTotalTime(CrClipAsset crClipAsset)`
- `public virtual int GetHashCode()`
- `public Vector3 GetOffsetPosition(Vector3 offset)`
  - Gets the position in world coordinates of an offset relative this `Entity`.
  - `offset`: The offset from this `Entity`.
- `public Vector3 GetPositionOffset(Vector3 worldCoords)`
  - Gets the relative offset of this `Entity` from a world coordinates position.
  - `worldCoords`: The world coordinates.
- `public Vector3 GetSpeedVector(bool relativeToEntity)`
- `public bool HasAnimationEventFired(AtHashValue eventHash)`
- `public bool HasBeenDamagedBy(Entity entity)`
  - Determines whether this `Entity` has been damaged by a specified `Entity`.
  - `entity`: The `Entity` to check
  - Returns: `true` if this `Entity` has been damaged by the specified `Entity`; otherwise, `false`.
- `public virtual bool HasBeenDamagedBy(WeaponHash weapon)`
  - Determines whether this `Entity` has been damaged by a specific weapon].
  - `weapon`: The weapon to check.
  - Returns: `true` if this `Entity` has been damaged by the specified weapon; otherwise, `false`.
- `public virtual bool HasBeenDamagedByAnyMeleeWeapon()`
  - Determines whether this `Entity` has been damaged by any melee weapon.
  - Returns: `true` if this `Entity` has been damaged by any melee weapon; otherwise, `false`.
- `public virtual bool HasBeenDamagedByAnyWeapon()`
  - Determines whether this `Entity` has been damaged by any weapon.
  - Returns: `true` if this `Entity` has been damaged by any weapon; otherwise, `false`.
- `public bool HasClearLineOfSightTo(Entity target, IntersectFlags losFlags = 17)`
- `public bool HasClearLineOfSightToAdjustForCover(Entity target, IntersectFlags losFlags = 17)`
- `public bool HasClearLineOfSightToInFront(Entity target)`
- `public bool HasFinishedAnimation(CrClipAsset crClipAsset, EntityAnimationType type = 3)`
- `public bool IsAttached()`
  - Determines whether this `Entity` is attached to any other `Entity`.
  - Returns: `true` if this `Entity` is attached to another `Entity`; otherwise, `false`.
- `public bool IsAttachedTo(Entity entity)`
  - Determines whether this `Entity` is attached to the specified `Entity`.
  - `entity`: The `Entity` to check if this `Entity` is attached to.
  - Returns: `true` if this `Entity` is attached to `entity`; otherwise, `false`.
- `public bool IsAttachedToAnyPed()`
- `public bool IsAttachedToAnyProp()`
- `public bool IsAttachedToAnyVehicle()`
- `public bool IsInAngledArea(Vector3 originEdge, Vector3 extentEdge, float width, bool do3DCheck, PedTransportMode transportMode = 0)`
- `public bool IsInAngledArea(Vector3 originEdge, Vector3 extentEdge, float width, bool includeZAxis)`
  - Determines whether this `Entity` is in a specified angled area. An angled area is an X-Z oriented rectangle with three parameters: origin, extent, and width.
  - `originEdge`: The mid-point along a base edge of the rectangle.
  - `extentEdge`: The mid-point of opposite base edge on the other Z.
  - `width`: The length of the base edge.
  - `includeZAxis`: If set to `true`, the method will also check if the point is in area in Z axis as well as X and Y axes. If set to `false`, the method will only check if the point is in area in X and Y axes.
  - Returns: `true` if this `Entity` is in the specified angled area; otherwise, `false`.
- `public bool IsInAngledArea(Vector3 origin, Vector3 edge, float angle)`
  - Determines whether this `Entity` is in a specified angled area
  - `origin`: The mid-point along a base edge of the rectangle.
  - `edge`: The mid-point of opposite base edge on the other Z.
  - `angle`: The width. Wrongly named parameter but is kept for existing script compatibilities.
  - Returns: `true` if this `Entity` is in the specified angled area; otherwise, `false`.
- `public bool IsInArea(Vector3 minCoords, Vector3 maxCoords, bool do3DCheck, PedTransportMode transportMode = 0)`
  - Determines whether this `Entity` is in a specified area
  - `minBounds`: The minimum bounds.
  - `maxBounds`: The maximum bounds.
  - Returns: `true` if this `Entity` is in the specified area; otherwise, `false`.
- `public bool IsInArea(Vector3 minBounds, Vector3 maxBounds)`
  - Determines whether this `Entity` is in a specified area
  - `minBounds`: The minimum bounds.
  - `maxBounds`: The maximum bounds.
  - Returns: `true` if this `Entity` is in the specified area; otherwise, `false`.
- `public bool IsInRange(Vector3 position, float range)`
  - Determines whether this `Entity` is in range of a specified position
  - `position`: The position.
  - `range`: The maximum range.
  - Returns: `true` if this `Entity` is in range of the `position`; otherwise, `false`.
- `public bool IsNearEntity(Entity entity, Vector3 bounds, bool do3DCheck, PedTransportMode transportMode = 0)`
  - Determines whether this `Entity` is near a specified `Entity`.
  - `entity`: The `Entity` to check.
  - `bounds`: The max displacement from the `entity`.
  - Returns: `true` if this `Entity` is near the `entity`; otherwise, `false`.
- `public bool IsNearEntity(Entity entity, Vector3 bounds)`
  - Determines whether this `Entity` is near a specified `Entity`.
  - `entity`: The `Entity` to check.
  - `bounds`: The max displacement from the `entity`.
  - Returns: `true` if this `Entity` is near the `entity`; otherwise, `false`.
- `public bool IsPlayingAnimation(CrClipAsset crClipAsset, EntityAnimationType type = 3)`
- `public bool IsTouching(Entity entity)`
  - Determines whether this `Entity` is touching the `Entity``entity`.
  - `entity`: The `Entity` to check.
  - Returns: `true` if this `Entity` is touching `entity`; otherwise, `false`.
- `public bool IsTouching(Model model)`
  - Determines whether this `Entity` is touching an `Entity` with the `Model``model`.
  - `model`: The `Model` to check
  - Returns: `true` if this `Entity` is touching a `model`; otherwise, `false`.
- `public bool IsUprightWithin(float angleToVerticalLimit = 90)`
- `public void MarkAsMissionEntity(bool grabFromOtherScript = false)`
- `public void MarkAsNoLongerNeeded()`
  - Marks this `Entity` as no longer needed to keep and lets the game delete it when its too far away. You can still manipulate this `Entity` as long as the `Entity` exists.
- `public bool PlayAnimation(CrClipAsset crClipAsset, AnimationBlendDelta blendDelta, bool loop, bool holdLastFrame, bool driveToPose = false, float startPhase = 0, AnimationFlags animFlags = 0)`
- `public bool PlaySynchronizedAnim(FwSyncedScene scene, CrClipAsset anim, AnimationBlendDelta blendIn, AnimationBlendDelta? blendOut = null, SyncedSceneFlags flags = 0, AnimationBlendDelta? moverBlendIn = null)`
- `public void ProcessEntityAttachments()`
- `public void RemoveParticleEffects()`
  - Stops all particle effects attached to this `Entity`.
- `public void ResetOpacity()`
  - Resets the `Opacity`.
- `public void SetAnimationCurrentTime(CrClipAsset crClipAsset, float newCurrentTime)`
- `public void SetAnimationSpeed(CrClipAsset crClipAsset, float speedMultiplier)`
- `public void SetCenterOfGravityAtBoundCenter()`
- `public void SetDamping(PhysicsDampingType dampingType, float dampingValue)`
- `public void SetNoCollision(Entity entity, bool toggle)`
  - Sets the collision between this `Entity` and another `Entity`
  - `entity`: The `Entity` to set collision with
  - `toggle`: if set to `true` the 2 `Entity`s wont collide with each other.
- `public void SetNotDamagedByRelGroup(RelationshipGroup relGroup)`
- `public void SetOnlyDamagedByRelGroup(RelationshipGroup relGroup)`
- `public void SetOpacity(int opacity, bool useSmoothOpacity)`
- `public void SetShouldFreezeWaitingOnCollision(bool shouldFreeze)`
- `public void SetToRespondToPhysicsSystem()`
- `public bool StopAnimation(CrClipAsset crClipAsset, AnimationBlendDelta blendDelta)`
- `public bool StopSynchronizedAnim(AnimationBlendDelta blendOut, bool activateCollision)`
- `protected bool TryGetMemoryAddress(out IntPtr address)`
- `public bool TryGetPhysicalEntityFromLastCollisionRecord(out Entity entity)`
- `public static Entity FromHandle(int handle)`
  - Creates a new instance of an `Entity` from the given handle.
  - `handle`: The entity handle.
  - Returns: Returns a `Ped` if this handle corresponds to a Ped. Returns a `Vehicle` if this handle corresponds to a Vehicle. Returns a `Prop` if this handle corresponds to a Prop. Returns `null` if no `Entity` exists this the specified `handle`
- `public static bool IsNullOrNotExisting(Entity entity)`
- `public static bool op_Equality(Entity left, Entity right)`
  - Determines if two `Entity`s refer to the same entity.
  - `left`: The left `Entity`.
  - `right`: The right `Entity`.
  - Returns: `true` if `left` is the same entity as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(Entity value)`
  - Converts an `Entity` to a native input argument.
- `public static bool op_Inequality(Entity left, Entity right)`
  - Determines if two `Entity`s don't refer to the same entity.
  - `left`: The left `Entity`.
  - `right`: The right `Entity`.
  - Returns: `true` if `left` is not the same entity as `right`; otherwise, `false`.
- `public static bool PlaySynchronizedMapEntityAnim(Vector3 newPos, float radius, Model propModel, FwSyncedScene scene, CrClipAsset anim, AnimationBlendDelta blendIn, AnimationBlendDelta? blendOut = null, SyncedSceneFlags flags = 0, AnimationBlendDelta? moverBlendIn = null)`
- `public static bool StopSynchronizedMapEntityAnim(Vector3 newPos, float radius, Model propModel, AnimationBlendDelta blendOut)`

## EntityAnimationType

enum `GTA.EntityAnimationType`

| Name | Value |
| --- | --- |
| `Script` | 1 |
| `SyncedScene` | 2 |
| `Default` | 3 |

## EntityBone

class `GTA.EntityBone`

### Properties

- `public Vector3 ForwardVector { get; }`
  - Gets the vector that points in front of this `EntityBone` relative to the world.
- `public int FragmentGroupIndex { get; }`
  - Gets the fragment group index of this `EntityBone`. -1 will be returned if the `Entity` does not exist or `Index` is invalid.
- `public int Index { get; }`
  - Gets the bone index of this `EntityBone`.
- `public bool IsValid { get; }`
  - Determines if this `EntityBone` is valid.
- `public string Name { get; }`
- `public EntityBone NextSibling { get; }`
- `public Entity Owner { get; }`
  - Gets the owner `Entity` this bone belongs to.
- `public EntityBone Parent { get; }`
- `public Vector3 Pose { get; set; }`
  - Gets or sets the current pose offset (dynamic position) of this `EntityBone` relative to the `Entity` its part of.
- `public Matrix PoseMatrix { get; set; }`
  - Gets or sets the dynamic `Matrix` of this `EntityBone` relative to the `Entity` its part of.
- `public Quaternion PoseQuaternion { get; set; }`
- `public Vector3 PoseRotation { get; set; }`
- `public Vector3 Position { get; }`
  - Gets the position of this `EntityBone` in world coordinates.
- `public Quaternion Quaternion { get; }`
- `public Vector3 RelativeForwardVector { get; }`
  - Gets the vector that points in front of this `EntityBone` relative to the `Entity` its part of.
- `public Matrix RelativeMatrix { get; set; }`
  - Gets the `Matrix` of this `EntityBone` relative to the `Entity` its part of.
- `public Vector3 RelativePosition { get; set; }`
  - Gets the position of this `EntityBone` relative to the `Entity` its part of.
- `public Quaternion RelativeQuaternion { get; set; }`
- `public Vector3 RelativeRightVector { get; }`
  - Gets the vector that points to the right of this `EntityBone` relative to the `Entity` its part of.
- `public Vector3 RelativeRotation { get; set; }`
- `public Vector3 RelativeUpVector { get; }`
  - Gets the vector that points above this `EntityBone` relative to the `Entity` its part of.
- `public Vector3 RightVector { get; }`
  - Gets the vector that points to the right of this `EntityBone` relative to the world.
- `public Vector3 Rotation { get; }`
- `public int Tag { get; }`
- `public Vector3 UpVector { get; }`
  - Gets the vector that points above this `EntityBone` relative to the world.

### Methods

- `public void AttachToBone(EntityBone boneOfSecondEntity, bool activeCollisions = true, bool useBasicAttachIfPed = false)`
- `public void AttachToBonePhysically(EntityBone boneOfSecondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2)`
- `public void AttachToBonePhysicallyOverrideInverseMass(EntityBone boneOfSecondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2, float invMassScaleA = 1, float invMassScaleB = 1)`
- `public void AttachToBoneYForward(EntityBone boneOfSecondEntity, bool activeCollisions = true, bool useBasicAttachIfPed = false)`
- `public void AttachToEntityPhysically(Entity secondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2)`
- `public void AttachToEntityPhysicallyOverrideInverseMass(Entity secondEntity, Vector3 secondEntityOffset, Vector3 thisEntityOffset, Vector3 rotation, float physicalStrength, bool constrainRotation, bool doInitialWarp = true, bool collideWithEntity = false, bool addInitialSeparation = true, EulerRotationOrder rotationOrder = 2, float invMassScaleA = 1, float invMassScaleB = 1)`
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same bone as this `EntityBone`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same bone as this `EntityBone`; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public Vector3 GetOffsetPosition(Vector3 offset)`
  - Gets the position in world coordinates of an offset relative this `EntityBone`
  - `offset`: The offset from this `EntityBone`.
- `public Vector3 GetPositionOffset(Vector3 worldCoords)`
  - Gets the relative offset of this `EntityBone` from a world coordinates position
  - `worldCoords`: The world coordinates.
- `public Vector3 GetRelativeOffsetPosition(Vector3 offset)`
  - Gets the position relative to the `Entity` of an offset relative this `EntityBone`
  - `offset`: The offset from this `EntityBone`.
- `public Vector3 GetRelativePositionOffset(Vector3 entityOffset)`
  - Gets the relative offset of this `EntityBone` from an offset from the `Entity`
  - `entityOffset`: The `Entity` offset.
- `public static bool op_Equality(EntityBone entityBone, Bone boneId)`
  - Determines if an `EntityBone` refers to a specific bone.
  - `entityBone`: The `EntityBone` to check.
  - `boneId`: The `Bone` ID to check against.
  - Returns: `true` if `entityBone` refers to the `boneId`; otherwise, `false`.
- `public static bool op_Equality(EntityBone left, EntityBone right)`
  - Determines if two `EntityBone`s refer to the same bone.
  - `left`: The left `EntityBone`.
  - `right`: The right `EntityBone`.
  - Returns: `true` if `left` is the same bone as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(EntityBone entityBone)`
  - Converts an `EntityBone` to a native input argument.
- `public static int op_Implicit(EntityBone entityBone)`
  - Converts an `EntityBone` to a bone index.
- `public static bool op_Inequality(EntityBone entityBone, Bone boneId)`
  - Determines if an `EntityBone` doesn't refer to a specific bone.
  - `entityBone`: The `EntityBone` to check.
  - `boneId`: The `Bone` ID to check against.
  - Returns: `true` if `entityBone` does not refer to the `boneId`; otherwise, `false`.
- `public static bool op_Inequality(EntityBone left, EntityBone right)`
  - Determines if two `EntityBone`s don't refer to the same bone.
  - `left`: The left `EntityBone`.
  - `right`: The right `EntityBone`.
  - Returns: `true` if `left` is not the same bone as `right`; otherwise, `false`.

## EntityBoneCollection

class `GTA.EntityBoneCollection` : `IEnumerable<EntityBone>`, `IEnumerable`

### Properties

- `public EntityBone Core { get; }`
  - Gets the core bone of this `Entity`.
- `public int Count { get; }`
  - Gets the number of bones that this `Entity` has.
- `public EntityBone this[int boneIndex] { get; }`
  - Gets the `EntityBone` at the specified bone index.
  - `boneIndex`: The bone index.
- `public EntityBone this[string boneName] { get; }`
  - Gets the `EntityBone` with the specified bone name.
  - `boneName`: Name of the bone.
- `public EntityBone Root { get; }`
- `public Matrix TransformMatrix { get; }`

### Methods

- `public bool Contains(string boneName)`
  - Determines whether this `Entity` has a bone with the specified bone name
  - `boneName`: Name of the bone.
  - Returns: `true` if this `Entity` has a bone with the specified bone name; otherwise, `false`.
- `public IEnumerator<EntityBone> GetEnumerator()`
- `public virtual int GetHashCode()`

### Fields

- `protected readonly Entity _owner`

## EntityBoneCollection.Enumerator

class `GTA.EntityBoneCollection.Enumerator` : `IEnumerator<EntityBone>`, `IDisposable`, `IEnumerator`

### Constructors

- `public Enumerator(EntityBoneCollection collection)`

### Properties

- `public EntityBone Current { get; }`

### Methods

- `public bool MoveNext()`
- `public void Reset()`

## EntityDamageRecord

struct `GTA.EntityDamageRecord`

### Properties

- `public Entity Attacker { get; }`
  - Gets the attacker `Entity`. Can be `null`.
- `public int GameTime { get; }`
  - Gets the game time when the `Victim` took damage.
- `public Entity Victim { get; }`
  - Gets the victim `Entity`.
- `public WeaponHash WeaponHash { get; }`
  - Gets the weapon hash what the `Victim` took damage with.

### Methods

- `public void Deconstruct(out Entity victim, out Entity attacker, out WeaponHash weaponHash, out int gameTime)`
- `public void Deconstruct(out Entity attacker, out WeaponHash weaponHash, out int gameTime)`
- `public bool Equals(EntityDamageRecord entityDamageRecord)`
  - Determines if `entityDamageRecord` has the same properties as this `EntityDamageRecord`.
  - `entityDamageRecord`: The `Object` to check.
  - Returns: `true` if the `entityDamageRecord` has the same properties as this `EntityDamageRecord`; otherwise, `false`.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` is an `EntityDamageRecord` and has the same properties as this `EntityDamageRecord`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is an `EntityDamageRecord` and has the same properties as this `EntityDamageRecord`; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public static bool op_Equality(EntityDamageRecord left, EntityDamageRecord right)`
  - Determines if two `EntityDamageRecord`s have the same properties.
  - `left`: The left `Entity`.
  - `right`: The right `Entity`.
  - Returns: `true` if `left` has the same properties as `right`; otherwise, `false`.
- `public static bool op_Inequality(EntityDamageRecord left, EntityDamageRecord right)`
  - Determines if two `Entity`s do not have the same properties.
  - `left`: The left `Entity`.
  - `right`: The right `Entity`.
  - Returns: `true` if `left` does not have the same properties as `right`; otherwise, `false`.

## EntityDamageRecordCollection

class `GTA.EntityDamageRecordCollection` : `IEnumerable<EntityDamageRecord>`, `IEnumerable`

### Methods

- `public EntityDamageRecord[] GetAllDamageRecords()`
  - Gets all the `EntityDamageRecord` at the moment. The return array can contain up to 3 `EntityDamageRecord`s.
- `public IEnumerator<EntityDamageRecord> GetEnumerator()`

## EntityPopulationType

enum `GTA.EntityPopulationType`

| Name | Value | Description |
| --- | --- | --- |
| `Unknown` | 0 | The game does not automatically delete entities when this value is set. |
| `RandomPermanent` | 1 | The game does not automatically delete entities when this value is set. |
| `RandomParked` | 2 | This value is set when parked vehicles are created. |
| `RandomPatrol` | 3 |  |
| `RandomScenario` | 4 | This value is set when scenario peds are created. |
| `RandomAmbient` | 5 | This value is set when ambient entities are created or when SET_ENTITY_AS_NO_LONGER_NEEDED is called. |
| `Permanent` | 6 | The game does not automatically delete entities when this value is set. |
| `Mission` | 7 | This value is set when entities are created via native functions or when SET_ENTITY_AS_MISSION_ENTITY is called. The game does not automatically delete entities when this value is set. |
| `Replay` | 8 | The game does not automatically delete entities when this value is set. |
| `Cache` | 9 |  |
| `Tool` | 10 |  |

## EntityType

enum `GTA.EntityType`

| Name | Value |
| --- | --- |
| `Invalid` | 0 |
| `Ped` | 1 |
| `Vehicle` | 2 |
| `Prop` | 3 |

## EulerRotationOrder

enum `GTA.EulerRotationOrder`

Enums for the order in which to apply rotations in local space, just like how Rockstar Games define `EULER_ROT_ORDER`.

| Name | Value |
| --- | --- |
| `XYZ` | 0 |
| `XZY` | 1 |
| `YXZ` | 2 |
| `YZX` | 3 |
| `ZXY` | 4 |
| `ZYX` | 5 |

## EventType

enum `GTA.EventType`

151 values:

```text
AcquaintancePedDislike = 0
AcquaintancePedHate = 1
AcquaintancePedLike = 2
AcquaintancePedRespect = 3
AcquaintancePedWanted = 4
AcquaintancePedDead = 5
Agitated = 6
AgitatedAction = 7
EncroachingPed = 8
CallForCover = 9
CarUndriveable = 10
ClimbLadderOnRoute = 11
ClimbNavmeshOnRoute = 12
CombatTaunt = 13
CommunicateEvent = 14
CopCarBeingStolen = 15
CrimeReported = 16
Damage = 17
DeadPedFound = 18
Death = 19
DraggedOutCar = 20
DummyConversion = 21
Explosion = 22
ExplosionHeard = 23
FireNearby = 24
FlushTasks = 25
FootStepHeard = 26
GetOutOfWater = 27
GivePedTask = 28
GunAimedAt = 29
HelpAmbientFriend = 30
InjuredCryForHelp = 31
CrimeCryForHelp = 32
InAir = 33
InWater = 34
Incapacitated = 35
LeaderEnteredCarAsDriver = 36
LeaderEnteredCover = 37
LeaderExitedCarAsDriver = 38
LeaderHolsteredWeapon = 39
LeaderLeftCover = 40
LeaderUnholsteredWeapon = 41
MeleeAction = 42
MustLeaveBoat = 43
NewTask = 44
None = 45
ObjectCollision = 46
OnFire = 47
OpenDoor = 48
ShovePed = 49
PedCollisionWithPed = 50
PedCollisionWithPlayer = 51
PedEnteredMyVehicle = 52
PedJackingMyVehicle = 53
PedOnCarRoof = 54
PedToChase = 55
PedToFlee = 56
PlayerCollisionWithPed = 57
PlayerLockOnTarget = 58
PotentialBeWalkedInto = 59
PotentialBlast = 60
PotentialGetRunOver = 61
PotentialWalkIntoFire = 62
PotentialWalkIntoObject = 63
PotentialWalkIntoVehicle = 64
ProvidingCover = 65
RadioTargetPosition = 66
RanOverPed = 67
ReactionCombatVictory = 68
ReactionEnemyPed = 69
ReactionInvestigateDeadPed = 70
ReactionInvestigateThreat = 71
RequestHelpWithConfrontation = 72
RespondedToThreat = 73
Revived = 74
ScriptCommand = 75
ShockingBrokenGlass = 76
ShockingCarAlarm = 77
ShockingCarChase = 78
ShockingCarCrash = 79
ShockingBicycleCrash = 80
ShockingCarPileUp = 81
ShockingCarOnCar = 82
ShockingDangerousAnimal = 83
ShockingDeadBody = 84
ShockingDrivingOnPavement = 85
ShockingBicycleOnPavement = 86
ShockingEngineRevved = 87
ShockingExplosion = 88
ShockingFire = 89
ShockingGunFight = 90
ShockingGunshotFired = 91
ShockingHelicopterOverhead = 92
ShockingParachuterOverhead = 93
ShockingPedKnockedIntoByPlayer = 94
ShockingHornSounded = 95
ShockingInDangerousVehicle = 96
ShockingInjuredPed = 97
ShockingMadDriver = 98
ShockingMadDriverExtreme = 99
ShockingMadDriverBicycle = 100
ShockingMugging = 101
ShockingNonViolentWeaponAimedAt = 102
ShockingPedRunOver = 103
ShockingPedShot = 104
ShockingPlaneFlyBy = 105
ShockingPotentialBlast = 106
ShockingPropertyDamage = 107
ShockingRunningPed = 108
ShockingRunningStampede = 109
ShockingSeenCarStolen = 110
ShockingSeenConfrontation = 111
ShockingSeenGangFight = 112
ShockingSeenInsult = 113
ShockingSeenMeleeAction = 114
ShockingSeenNiceCar = 115
ShockingSeenPedKilled = 116
ShockingSeenVehicleTowed = 117
ShockingSeenWeaponThreat = 118
ShockingSeenWeirdPed = 119
ShockingSeenWeirdPedApproaching = 120
ShockingSiren = 121
ShockingStudioBomb = 122
ShockingVisibleWeapon = 123
ShotFired = 124
ShotFiredBulletImpact = 125
ShotFiredWhizzedBy = 126
FriendlyAimedAt = 127
FriendlyFireNearMiss = 128
ShoutBlockingLos = 129
ShoutTargetPosition = 130
StaticCountReachedMax = 131
StuckInAir = 132
SuspiciousActivity = 133
Switch2NmTask = 134
UnidentifiedPed = 135
VehicleCollision = 136
VehicleDamageWeapon = 137
VehicleOnFire = 138
WhistlingHeard = 139
Disturbance = 140
EntityDamaged = 141
EntityDestroyed = 142
Writhe = 143
HurtTransition = 144
PlayerUnableToEnterVehicle = 145
ScenarioForceAction = 146
StatValueChanged = 147
PlayerDeath = 148
PedSeenDeadPed = 149
Invalid = -1
```

## ExplosionType

enum `GTA.ExplosionType`

81 values:

```text
Grenade = 0
GrenadeL = 1
StickyBomb = 2
Molotov1 = 3
Rocket = 4
TankShell = 5
HiOctane = 6
Car = 7
Plane = 8
PetrolPump = 9
Bike = 10
Steam = 11
Flame = 12
WaterHydrant = 13
GasCanister = 14
Boat = 15
ShipDestroy = 16
Truck = 17
Bullet = 18
SmokeGL = 19
SmokeG = 20
BZGas = 21
Flare = 22
GasCanister2 = 23
Extinguisher = 24
ProgramAR = 25
Train = 26
Barrel = 27
Propane = 28
Blimp = 29
FlameExplode = 30
Tanker = 31
PlaneRocket = 32
VehicleBullet = 33
GasTank = 34
BirdCrap = 35
Railgun = 36
Blimp2 = 37
FireWork = 38
SnowBall = 39
ProxMine = 40
Valkyrie = 41
AirDefense = 42
PipeBomb = 43
VehicleMine = 44
ExplosiveAmmo = 45
ApcShell = 46
BombCluster = 47
BombGas = 48
BombIncendiary = 49
BombStandard = 50
Torpedo = 51
TorpedoUnderwater = 52
BombushkaCannon = 53
BombClusterSecondary = 54
HunterBarrage = 55
HunterCannon = 56
RogueCannon = 57
MineUnderwater = 58
OrbitalCannon = 59
BombStandardWide = 60
ExplosiveAmmoShotgun = 61
Oppressor2Cannon = 62
MortarKinetic = 63
VehiclemineKinetic = 64
VehiclemineEmp = 65
VehiclemineSpike = 66
VehiclemineSlick = 67
VehiclemineTar = 68
ScriptDrone = 69
RayGun = 70
BuriedMine = 71
ScriptMissile = 72
RCTankRocket = 73
BombWater = 74
BombWaterSecondary = 75
ScriptMissileLarge = 81
SubmarineBig = 82
EmpLauncherEmp = 83
RailgunXm3 = 84
BalancedCannons = 85
```

## ExtraWeaponComponentScriptResourceFlags

enum `GTA.ExtraWeaponComponentScriptResourceFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `Flash` | 1 |
| `Scope` | 2 |
| `Supp` | 4 |
| `Sclip2` | 8 |
| `Grip` | 16 |

## FireManager

static class `GTA.FireManager`

### Methods

- `public static int GetNumberOfFiresInRadius(Vector3 position, float radius)`
- `public static ScriptFire StartScriptFire(Vector3 position, int maxChildrenCount, bool isGasFire = false)`
- `public static void StopFireInRadius(Vector3 position, float radius)`
- `public static bool TryGetClosestFirePosition(Vector3 position, out Vector3 firePosition)`

## FiringPattern

enum `GTA.FiringPattern`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `FullAuto` | 3337513804 |
| `BurstFire` | 3607063905 |
| `BurstInCover` | 40051185 |
| `BurstFireDriveby` | 3541198322 |
| `FromGround` | 577037782 |
| `DelayFireByOneSec` | 2055493265 |
| `SingleShot` | 1566631136 |
| `BurstFirePistol` | 2685983626 |
| `BurstFireSMG` | 3507334638 |
| `BurstFireRifle` | 2624893958 |
| `BurstFireMG` | 3044263348 |
| `BurstFirePumpShotGun` | 12239771 |
| `BurstFireHeli` | 2437838959 |
| `BurstFireMicro` | 1122960381 |
| `BurstFireBursts` | 1122960381 |
| `BurstFireTank` | 3804904049 |
| `TampaMortar` | 2452873343 |
| `HunterBarrage` | 2905356422 |
| `AkulaBarrage` | 1392378214 |
| `ChernoBarrage` | 703122589 |
| `Pounder2Barrage` | 2228901467 |

## FleeAttributes

enum `GTA.FleeAttributes`

| Name | Value |
| --- | --- |
| `UseCover` | 1 |
| `UseVehicle` | 2 |
| `CanScream` | 4 |
| `PreferPavements` | 8 |
| `WanderAtEnd` | 16 |
| `LookForCrowds` | 32 |
| `ReturnToOriginalPositionAfterFlee` | 64 |
| `DisableHandsUp` | 128 |
| `UpdateToNearestHatedPed` | 256 |
| `NeverFlee` | 512 |
| `DisableCover` | 1024 |
| `DisableExitVehicle` | 2048 |
| `DisableReverseInVehicle` | 4096 |
| `DisableAccelerateInVehicle` | 8192 |
| `DisableFleeFromIndirectThreats` | 16384 |
| `CowerInsteadOfFlee` | 32768 |
| `ForceExitVehicle` | 65536 |
| `DisableHesitateInVehicle` | 131072 |
| `DisableAmbientClips` | 262144 |

## FlyingHandlingData

class `GTA.FlyingHandlingData` : `BaseSubHandlingData`

### Properties

- `public float AttackDiveMultiplier { get; set; }`
- `public float AttackLiftMultiplier { get; set; }`
- `public float ExtraLiftWithRoll { get; set; }`
- `public float FormLiftMultiplier { get; set; }`
- `public float GearDownDragV { get; set; }`
- `public float GearDownLiftMultiplier { get; set; }`
- `public float MoveResistance { get; set; }`
- `public float PitchMultiplier { get; set; }`
- `public float PitchStabilize { get; set; }`
- `public float RollMultiplier { get; set; }`
- `public float RollStabilize { get; set; }`
- `public float SideSlipMultiplier { get; set; }`
- `public float Thrust { get; set; }`
- `public float ThrustFallOff { get; set; }`
- `public float ThrustVectoring { get; set; }`
- `public Vector3 VectorSpeedResistance { get; set; }`
- `public Vector3 VectorTurnResistance { get; set; }`
- `public float WindMultiplier { get; set; }`
- `public float YawMultiplier { get; set; }`
- `public float YawStabilize { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(FlyingHandlingData left, FlyingHandlingData right)`
- `public static bool op_Inequality(FlyingHandlingData left, FlyingHandlingData right)`

## FollowNavMeshFlags

enum `GTA.FollowNavMeshFlags`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `NoStopping` | 1 |
| `AdvancedSlideToCoordAndAchieveHeadingAtEnd` | 2 |
| `GoFarAsPossibleIfTargetNavmeshNotLoaded` | 4 |
| `AllowSwimmingUnderwater` | 8 |
| `KeepToPavements` | 16 |
| `NeverEnterWater` | 32 |
| `DontAvoidObjects` | 64 |
| `AdvancedUseMaxSlopeNavigable` | 128 |
| `AccurateWalkRunStart` | 1024 |
| `DontAvoidPeds` | 2048 |
| `DontAdjustTargetPosition` | 4096 |
| `SuppressExactStop` | 8192 |
| `AdvancedUseClampMaxSearchDistance` | 16384 |
| `PullFromEdgeExtra` | 32768 |

## ForceAnimAIUpdateState

enum `GTA.ForceAnimAIUpdateState`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `CutsceneExit` | 1 |

## ForceType

enum `GTA.ForceType`

| Name | Value |
| --- | --- |
| `InternalForce` | 0 |
| `InternalImpulse` | 1 |
| `ExternalForce` | 2 |
| `ExternalImpulse` | 3 |
| `Torque` | 4 |
| `AngularImpulse` | 5 |
| `MinForce` | 0 |
| `MaxForceRot` | 1 |
| `MinForce2` | 2 |
| `MaxForceRot2` | 3 |
| `ForceNoRot` | 4 |
| `ForceRotPlusForce` | 5 |

## Formation

enum `GTA.Formation`

| Name | Value | Description |
| --- | --- | --- |
| `Loose` | 0 | The default value. |
| `SurroundFacingInwards` | 1 |  |
| `SurroundFacingAhead` | 2 |  |
| `LineAbreast` | 3 |  |
| `FollowInLine` | 4 |  |
| `Default` | 0 |  |
| `Circle1` | 1 |  |
| `Circle2` | 2 |  |
| `Line` | 4 |  |

## FwSyncedScene

class `GTA.FwSyncedScene` : `INativeValue`, `IEquatable<FwSyncedScene>`

### Properties

- `public int Handle { get; }`
- `public bool HoldsLastFrame { get; set; }`
- `public bool IsLooped { get; set; }`
- `public ulong NativeValue { get; set; }`
- `public float Phase { get; set; }`
- `public float Rate { get; set; }`

### Methods

- `public void AttachTo(Entity entity)`
- `public void AttachTo(EntityBone bone)`
- `public void Detach()`
- `public bool Equals(FwSyncedScene scene)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public virtual int GetHashCode()`
- `public void SetOrigin(Vector3 position, Vector3 orientation, EulerRotationOrder rotOrder = 2)`
- `public static FwSyncedScene Create(Vector3 position, Vector3 orientation, EulerRotationOrder rotOrder = 2)`
- `public static FwSyncedScene CreateAtMapObject(Vector3 newPos, float radius, Model propModel)`
- `public static bool op_Equality(FwSyncedScene left, FwSyncedScene right)`
- `public static InputArgument op_Implicit(FwSyncedScene value)`
- `public static bool op_Inequality(FwSyncedScene left, FwSyncedScene right)`

## Game

static class `GTA.Game`

### Properties

- `public static Version FileVersion { get; }`
- `public static float FPS { get; }`
  - Gets the current frame rate in frames per second.
- `public static int FrameCount { get; }`
  - Gets the total number of frames that have been rendered in this session.
- `public static int GameTime { get; }`
  - Gets how many milliseconds the game has been open in this session
- `public static bool IsCutsceneActive { get; }`
  - Gets a value indicating whether the cutscene is active.
- `public static bool IsLoading { get; }`
  - **Obsolete.** `Game.IsLoading` is obsolete because Script Hook V changed the way SHV scripts start inv1.0.3351.0 (SHV version and not game version) and they never be able to start before the game finished showing the loading screen since SHV v1.0.3351.0+. It is advised not to use `Game.IsLoading`at all.
  - Gets a value indicating whether there is a loading screen being displayed.
- `public static bool IsMissionActive { get; set; }`
  - Gets or sets a value informing the engine if a mission is in progress.
- `public static bool IsNightVisionActive { get; set; }`
  - Gets or sets a value indicating whether to render the world with a night vision filter.
- `public static bool IsPaused { get; set; }`
  - Gets or sets a value indicating whether the pause menu is active.
- `public static bool IsRandomEventActive { get; set; }`
  - Gets or sets a value informing the engine if a random event is in progress.
- `public static bool IsRiotModeEnabled { get; set; }`
- `public static bool IsThermalVisionActive { get; set; }`
  - Gets or sets a value indicating whether to render the world with a thermal vision filter.
- `public static bool IsVibrationEnabled { get; }`
  - Gets a value indicating whether the controller vibration is enabled.
- `public static bool IsWaypointActive { get; }`
  - Gets a value indicating whether there is a waypoint set on the map.
- `public static Language Language { get; }`
  - Gets the current game language.
- `public static float LastFrameTime { get; }`
  - Gets the time in seconds it took for the last frame to render.
- `public static InputMethod LastInputMethod { get; }`
  - Gets whether the last input was made with a GamePad or keyboard and mouse.
- `public static Ped LocalPlayerPed { get; }`
- `public static int MaxWantedLevel { get; set; }`
  - Gets or sets the maximum wanted level a `Player` can receive.
- `public static MeasurementSystem MeasurementSystem { get; }`
  - Gets the measurement system the game uses to display.
- `public static Blip NorthBlip { get; }`
  - Gets the north blip, which is shown on the radar.
- `public static Player Player { get; }`
  - Gets the `Player` that you are controlling.
- `public static Blip PlayerBlip { get; }`
  - Gets the blip of the `Player` that you are controlling.
- `public static PlayerTargetingMode PlayerTargetingMode { get; }`
  - Gets the current targeting mode of the local player.
- `public static RadioStation RadioStation { get; set; }`
  - Gets or sets the current radio station.
- `public static float TimeScale { get; set; }`
  - Gets or Sets the time scale of the game.
- `public static GameVersion Version { get; }`
  - **Obsolete.** `Game.Version` is deprecated because Script Hook V is deprecating `getGameVersion`, which the property is based on. Use `Game.FileVersion` instead.
  - Gets the version of the game.

### Methods

- `public static void DisableAllControlsThisFrame()`
  - **Obsolete.** Use GTA.Input.Controls.DisableAllControlActionsThisFrame(ControlType.PlayerControl) instead.
  - Disables all `Control`s this frame.
- `public static void DisableControlThisFrame(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.DisableControlActionThisFrame instead.
  - Makes the engine ignore input from the given `Control` this frame.
  - `control`: The `Control`.
- `public static void DoAutoSave()`
  - Performs an automatic game save.
- `public static void EnableAllControlsThisFrame()`
  - **Obsolete.** Use GTA.Input.Controls.EnableAllControlActionsThisFrame(ControlType.PlayerControl) instead.
  - Enables all `Control`s this frame.
- `public static void EnableControlThisFrame(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.EnableControlActionThisFrame instead.
  - Makes the engine respond to the given `Control` this frame.
  - `control`: The `Control` to enable..
- `public static IntPtr FindPattern(string pattern, IntPtr startAddress = null)`
  - Searches the address space of the current process for a memory pattern.
  - `pattern`: The pattern.
  - `startAddress`: The address to start searching at. If `Zero` (`default`), search is started at the base address.
  - Returns: The address of a region matching the pattern, or `Zero` if none was found.
- `public static IntPtr FindPattern(string pattern, string mask, IntPtr startAddress = null)`
  - Searches the address space of the current process for a memory pattern.
  - `pattern`: The pattern.
  - `mask`: The pattern mask.
  - `startAddress`: The address to start searching at. If `Zero` (`default`), search is started at the base address.
  - Returns: The address of a region matching the pattern, or `Zero` if none was found.
- `public static int GenerateHash(string input)`
  - **Obsolete.** Use StringHash.AtStringHash(string, uint), StringHash.AtStringHashUtf8(string, uint), AtHashValue.FromString(string, uint), or StringHash.AtStringHashUtf8(string, uint) instead.
  - Calculates a Jenkins One At A Time hash from the given `String` which can then be used by any native function that takes a hash. Can be called in any thread.
  - `input`: The input `String` to hash.
  - Returns: The Jenkins hash of the input `String`.
- `public static int GetControlValue(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.GetControlValue instead.
  - Gets an analog value of a `Control` input.
  - `control`: The `Control` to check.
  - Returns: The `Control` value.
- `public static float GetControlValueNormalized(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.GetControlValueNormalized instead.
  - Gets an analog value of a `Control` input between -1.0f and 1.0f.
  - `control`: The `Control` to check.
  - Returns: The normalized `Control` value.
- `public static float GetDisabledControlValueNormalized(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.GetDisabledControlNormal instead.
  - Gets an analog value of a disabled `Control` input between -1.0f and 1.0f.
  - `control`: The `Control` to check.
  - Returns: The normalized `Control` value.
- `public static string GetLocalizedString(int entryLabelHash)`
  - Returns a localized `String` from the games language files with a specified GXT key hash.
  - `entryLabelHash`: The GXT key hash.
  - Returns: The localized `String` if the key hash exists; otherwise, `Empty`
- `public static string GetLocalizedString(string entry)`
  - Returns a localized `String` from the games language files with a specified GXT key.
  - `entry`: The GXT key.
  - Returns: The localized `String` if the key exists; otherwise, `Empty`
- `public static int GetProfileSetting(int index)`
  - Gets an value associated with the specified index of the profile setting.
  - `index`: The index of the profile setting values.
  - Returns: The integer value associated with the specified index of the profile setting.
- `public static string GetUserInput(WindowTitle windowTitle, string defaultText, int maxLength)`
  - Creates an input box for the user to input text using the keyboard.
  - `windowTitle`: The title of the input box window.
  - `maxLength`: The maximum length of text input allowed.
  - `defaultText`: The default text.
  - Returns: The `String` of what the user entered or `Empty` if the user canceled.
- `public static string GetUserInput(string defaultText = "")`
  - Creates an input box for the user to input text using the keyboard.
  - `defaultText`: The default text.
  - Returns: The `String` of what the user entered or `Empty` if the user canceled.
- `public static bool IsControlEnabled(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.IsControlEnabled instead.
  - Gets whether a `Control` is enabled or disabled this frame.
  - `control`: The `Control` to check.
  - Returns: `true` if the `Control` is Enabled; otherwise, `false`
- `public static bool IsControlJustPressed(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.IsDisabledControlJustPressed instead.
  - Gets whether a `Control` was just pressed this frame
  - `control`: The `Control` to check.
  - Returns: `true` if the `Control` was just pressed this frame; otherwise, `false`
- `public static bool IsControlJustReleased(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.IsDisabledControlJustReleased instead.
  - Gets whether a `Control` was just released this frame
  - `control`: The `Control` to check.
  - Returns: `true` if the `Control` was just released this frame; otherwise, `false`
- `public static bool IsControlPressed(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.IsDisabledControlPressed instead.
  - Gets whether a `Control` is currently pressed.
  - `control`: The `Control` to check.
  - Returns: `true` if the `Control` is pressed; otherwise, `false`
- `public static bool IsEnabledControlJustPressed(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.IsControlJustPressed instead.
  - Gets whether a `Control` is enabled and was just pressed this frame.
  - `control`: The `Control` to check.
  - Returns: `true` if the `Control` was just pressed this frame; otherwise, `false`
- `public static bool IsEnabledControlJustReleased(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.IsControlJustReleased instead.
  - Gets whether a `Control` is enabled and was just released this frame.
  - `control`: The `Control` to check.
  - Returns: `true` if the `Control` was just released this frame; otherwise, `false`
- `public static bool IsEnabledControlPressed(Control control)`
  - **Obsolete.** Use GTA.Input.Controls.IsControlPressed instead.
  - Gets whether a `Control` is enabled and currently pressed.
  - `control`: The `Control` to check.
  - Returns: `true` if the `Control` is pressed; otherwise, `false`
- `public static bool IsKeyPressed(Keys key)`
  - Gets whether the specified key is currently held down.
  - `key`: The key to check.
- `public static void LockRadioStation(RadioStation station)`
- `public static void Pause(bool value)`
  - Pause/resume the game.
  - `value`: True/false for pause/resume.
- `public static void SetControlValueNormalized(Control control, float value)`
  - **Obsolete.** Use GTA.Input.Controls.SetControlNormalNextFrame instead.
  - Override a `Control` by giving it a user-defined value this frame.
  - `control`: The `Control` to check.
  - `value`: the value to set the control to.
- `public static void ShowSaveMenu()`
  - Shows the save menu enabling the user to perform a manual game save.
- `public static void UnlockAllRadioStations()`
- `public static void UnlockRadioStation(RadioStation station)`
- `public static bool WasButtonCombinationJustEntered(params Button[] buttons)`
  - Gets whether a specific sequence of `Button`s has been pressed.
  - `buttons`: The sequence of `Button`s in the order the user should enter them in-game.
  - Returns: `true` if the combination was just entered; otherwise, `false`
- `public static bool WasCheatStringJustEntered(string cheat)`
  - Gets whether a cheat code was entered into the cheat text box.
  - `cheat`: The name of the cheat to check.
  - Returns: `true` if the cheat was just entered; otherwise, `false`

## GameplayCamera

static class `GTA.GameplayCamera`

### Properties

- `public static CamViewModeContext ActiveViewModeContext { get; }`
- `public static Vector3 Direction { get; }`
  - Gets the direction the `GameplayCamera` is pointing in.
- `public static float FieldOfView { get; }`
  - Gets the field of view of the `GameplayCamera`.
- `public static float FirstPersonAimCamZoomFactor { get; set; }`
- `public static CamViewMode FollowPedCamViewMode { get; set; }`
- `public static CamViewMode FollowVehicleCamViewMode { get; set; }`
- `public static Vector3 ForwardVector { get; }`
  - Gets the forward vector of the `GameplayCamera`, see also `Direction`.
- `public static float HintBaseOrbitPitchOffset { set; }`
- `public static float HintCameraRelativeSideOffset { set; }`
- `public static float HintCameraRelativeVerticalOffset { set; }`
- `public static float HintFollowDistanceScalar { set; }`
- `public static float HintFovOverride { set; }`
- `public static bool IsAimCamActive { get; }`
  - Gets a value indicating whether the aiming camera is rendering.
- `public static bool IsCodeHintActive { get; }`
- `public static bool IsFirstPersonAimCamActive { get; }`
  - Gets a value indicating whether the first person aiming camera is rendering.
- `public static bool IsFollowPedCamActive { get; }`
- `public static bool IsFollowVehicleCamActive { get; }`
- `public static bool IsHintActive { get; }`
- `public static bool IsLookingBehind { get; }`
  - Gets a value indicating whether the `GameplayCamera` is looking behind.
- `public static bool IsRendering { get; }`
  - Gets a value indicating whether the `GameplayCamera` is rendering.
- `public static bool IsShaking { get; }`
  - Gets a value indicating whether the `GameplayCamera` is shaking.
- `public static Matrix Matrix { get; }`
  - Gets the matrix of the `GameplayCamera`.
- `public static IntPtr MemoryAddress { get; }`
  - Gets the memory address of the `GameplayCamera`.
- `public static Vector3 Position { get; }`
  - Gets the position of the `GameplayCamera`.
- `public static float RelativeHeading { get; set; }`
  - Gets or sets the relative heading of the `GameplayCamera`.
- `public static float RelativePitch { get; set; }`
  - Gets or sets the relative pitch of the `GameplayCamera`.
- `public static Vector3 RightVector { get; }`
  - Gets the right vector of the `GameplayCamera`.
- `public static Vector3 Rotation { get; }`
  - Gets the rotation of the `GameplayCamera`.
- `public static float ShakeAmplitude { set; }`
  - Sets the shake amplitude for the `GameplayCamera`.
- `public static Vector3 UpVector { get; }`
  - Gets the up vector of the `GameplayCamera`.
- `public static float Zoom { get; }`
  - **Obsolete.** GameplayCamera.Zoom is obsolete since it does not suggest the value is relevant only when a firstperson aim camera is used. Use GameplayCamera.FirstPersonAimCamZoomFactor instead.
  - Gets the zoom of the `GameplayCamera`.

### Methods

- `public static void DisableFirstPersonFlashEffectThisUpdate()`
- `public static void DisableOnFootFirstPersonViewThisUpdate()`
- `public static void FollowCameraIgnoreAttachParentMovementThisUpdate()`
- `public static void ForceRelativeHeadingAndPitch(float heading, float pitch, float smoothRate)`
- `public static CamViewMode GetCamViewModeForContext(CamViewModeContext context)`
- `public static Vector3 GetOffsetPosition(Vector3 offset)`
  - Gets the position in world coordinates of an offset relative to the `GameplayCamera`.
  - `offset`: The offset from the `GameplayCamera`.
- `public static Vector3 GetPositionOffset(Vector3 worldCoords)`
  - Gets the relative offset of the `GameplayCamera` from a world coordinates position.
  - `worldCoords`: The world coordinates.
- `public static void SetCamViewModeForContext(CamViewModeContext context, CamViewMode viewMode)`
- `public static void SetCoordHint(Vector3 coord, int dwellTime = 2000, int interpTo = 2000, int interpFrom = 2000, CameraHintHelperNameHash overriddenHintType = 0)`
- `public static void SetEntityHint(Entity entity, Vector3 offset, bool relativeOffset = true, int dwellTime = 2000, int interpTo = 2000, int interpFrom = 2000, CameraHintHelperNameHash overriddenHintType = 0)`
- `public static void SetInVehicleCameraStateThisUpdate(Vehicle vehicle, CamInVehicleState inVehicleState)`
- `public static void SetRelativePitch(float pitch, float smoothRate)`
- `public static void SetThirdPersonCameraOrbitDistanceLimitsThisUpdate(float minDistance, float maxDistance)`
- `public static void SetThirdPersonCameraRelativeHeadingLimitsThisUpdate(float minRelativeHeading, float maxRelativeHeading)`
- `public static void SetThirdPersonCameraRelativePitchLimitsThisUpdate(float minRelativePitch, float maxRelativePitch)`
- `public static void Shake(CameraShake shakeType, float amplitude)`
  - Shakes the `GameplayCamera`.
  - `shakeType`: Type of the shake to apply.
  - `amplitude`: The amplitude of the shaking.
- `public static void StopCodeGameplayHint(bool stopImmediately)`
- `public static void StopGameplayHint(bool stopImmediately)`
- `public static void StopShaking()`
  - Stops shaking the `GameplayCamera`.
- `public static void StopShaking(bool stopImmediately)`

### Fields

- `public const int DefaultDwellTime = 2000`
- `public const int DefaultInterpInTime = 2000`
- `public const int DefaultInterpOutTime = 2000`

## GameVersion

enum `GTA.GameVersion`

105 values:

```text
Unknown = -1
v1_0_335_2_Steam = 0
v1_0_335_2_NoSteam = 1
v1_0_350_1_Steam = 2
v1_0_350_2_NoSteam = 3
v1_0_372_2_Steam = 4
v1_0_372_2_NoSteam = 5
v1_0_393_2_Steam = 6
v1_0_393_2_NoSteam = 7
v1_0_393_4_Steam = 8
v1_0_393_4_NoSteam = 9
v1_0_463_1_Steam = 10
v1_0_463_1_NoSteam = 11
v1_0_505_2_Steam = 12
v1_0_505_2_NoSteam = 13
v1_0_573_1_Steam = 14
v1_0_573_1_NoSteam = 15
v1_0_617_1_Steam = 16
v1_0_617_1_NoSteam = 17
v1_0_678_1_Steam = 18
v1_0_678_1_NoSteam = 19
v1_0_757_2_Steam = 20
v1_0_757_2_NoSteam = 21
v1_0_757_3_Steam = 22
v1_0_757_4_NoSteam = 23
v1_0_791_2_Steam = 24
v1_0_791_2_NoSteam = 25
v1_0_877_1_Steam = 26
v1_0_877_1_NoSteam = 27
v1_0_944_2_Steam = 28
v1_0_944_2_NoSteam = 29
v1_0_1011_1_Steam = 30
v1_0_1011_1_NoSteam = 31
v1_0_1032_1_Steam = 32
v1_0_1032_1_NoSteam = 33
v1_0_1103_2_Steam = 34
v1_0_1103_2_NoSteam = 35
v1_0_1180_2_Steam = 36
v1_0_1180_2_NoSteam = 37
v1_0_1290_1_Steam = 38
v1_0_1290_1_NoSteam = 39
v1_0_1365_1_Steam = 40
v1_0_1365_1_NoSteam = 41
v1_0_1493_0_Steam = 42
v1_0_1493_0_NoSteam = 43
v1_0_1493_1_Steam = 44
v1_0_1493_1_NoSteam = 45
v1_0_1604_0_Steam = 46
v1_0_1604_0_NoSteam = 47
v1_0_1604_1_Steam = 48
v1_0_1604_1_NoSteam = 49
v1_0_1737_0_Steam = 50
v1_0_1737_0_NoSteam = 51
v1_0_1737_6_Steam = 52
v1_0_1737_6_NoSteam = 53
v1_0_1868_0_Steam = 54
v1_0_1868_0_NoSteam = 55
v1_0_1868_1_Steam = 56
v1_0_1868_1_NoSteam = 57
v1_0_1868_4_EGS = 58
v1_0_2060_0_Steam = 59
v1_0_2060_0_NoSteam = 60
v1_0_2060_1_Steam = 61
v1_0_2060_1_NoSteam = 62
v1_0_2189_0_Steam = 63
v1_0_2189_0_NoSteam = 64
v1_0_2215_0_Steam = 65
v1_0_2215_0_NoSteam = 66
v1_0_2245_0_Steam = 67
v1_0_2245_0_NoSteam = 68
v1_0_2372_0_Steam = 69
v1_0_2372_0_NoSteam = 70
v1_0_2545_0_Steam = 71
v1_0_2545_0_NoSteam = 72
v1_0_2612_1_Steam = 73
v1_0_2612_1_NoSteam = 74
v1_0_2628_2_Steam = 75
v1_0_2628_2_NoSteam = 76
v1_0_2699_0_Steam = 77
v1_0_2699_0_NoSteam = 78
v1_0_2699_16 = 79
v1_0_2802_0 = 80
v1_0_2824_0 = 81
v1_0_2845_0 = 82
v1_0_2944_0 = 83
v1_0_3028_0 = 84
v1_0_3095_0 = 85
v1_0_3179_0 = 86
v1_0_3258_0 = 87
v1_0_3274_0 = 88
v1_0_3323_0 = 89
v1_0_3337_0 = 90
v1_0_3351_0 = 91
v1_0_3407_0 = 92
v1_0_3411_0 = 93
v1_0_3442_0 = 94
v1_0_3504_0 = 95
v1_0_3521_0 = 96
v1_0_3570_0 = 97
v1_0_3586_0 = 98
v1_0_3717_0 = 99
v1_0_3725_0 = 100
v1_0_3751_0 = 101
v1_0_3788_0 = 102
v1_0_3889_0 = 103
```

## GameVersionNotSupportedException

class `GTA.GameVersionNotSupportedException` : `Exception`, `ISerializable`, `_Exception`

### Properties

- `public Version MinimumSupportedGameFileVersion { get; }`
- `public GameVersion MinimumSupportedGameVersion { get; }`
  - **Obsolete.** `GameVersionNotSupportedException.MinimumSupportedGameVersion` is deprecated because Script Hook V is deprecating `getGameVersion`, which the property is based on. Use `GameVersionNotSupportedException.MinimumSupportedGameFileVersion` instead.

### Methods

- `public virtual void GetObjectData(SerializationInfo info, StreamingContext context)`

## Gender

enum `GTA.Gender`

| Name | Value |
| --- | --- |
| `Male` | 0 |
| `Female` | 1 |

## GetClosestVehicleNodeFlags

enum `GTA.GetClosestVehicleNodeFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `IncludeSwitchedOffNodes` | 1 |
| `IncludeBoatNodes` | 2 |
| `IgnoreSlipLanes` | 4 |
| `IgnoreSwitchedOffDeadEnds` | 8 |

## GetGroundHeightMode

enum `GTA.GetGroundHeightMode`

| Name | Value |
| --- | --- |
| `Normal` | 0 |
| `ConsiderWaterAsGround` | 1 |
| `ConsiderWaterAsGroundNoWaves` | 2 |

## GetSafePositionFlags

enum `GTA.GetSafePositionFlags`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `OnlyPavement` | 1 |
| `NotIsolated` | 2 |
| `NotInterior` | 4 |
| `NotWater` | 8 |
| `OnlyNetworkSpawn` | 16 |
| `UseFloodFill` | 32 |

## HandlingData

class `GTA.HandlingData`

This class has most regular handling data. Currently compatible with 1.0.2060.0 or later. Note that this class gets data from or sets data to the `CHandlingData` instance as is, and thus not all the handling values don't match the equivalent values in the `handling.meta` file. The game multiplies or divides some values after reading values from the `handling.meta` file.

### Properties

- `public float AntiRollBarBiasFront { get; set; }`
  - Gets or sets the bias between front and rear for the anti-roll bar. This value will be set to the equivalent value in the `handling.meta` multiplied by 2 when `HandlingData` instances are initialized.
- `public float AntiRollBarForce { get; set; }`
  - Gets or sets the spring constant that is transmitted to the opposite wheel when under compression. Larger numbers result in a larger force being applied.
- `public BikeHandlingData BikeHandlingData { get; }`
- `public BoatHandlingData BoatHandlingData { get; }`
- `public float BoostMaxSpeed { get; set; }`
- `public float BrakeBiasFront { get; set; }`
- `public float BrakeForce { get; set; }`
- `public float CamberStiffness { get; set; }`
- `public CarHandlingData CarHandlingData { get; }`
- `public Vector3 CenterOfMassOffset { get; set; }`
- `public float ClutchChangeRateScaleDownShift { get; set; }`
  - Gets or sets the clutch speed multiplier on down shifts.
- `public float ClutchChangeRateScaleUpShift { get; set; }`
  - Gets or sets the clutch speed multiplier on up shifts.
- `public float CollisionDamageMultiplier { get; set; }`
- `public float DeformationDamageMultiplier { get; set; }`
- `public float DownForceModifier { get; set; }`
  - Gets or sets the amount of downforce applied to the vehicle.
- `public float DriveBiasFront { get; set; }`
  - Gets or sets how much the vehicle gives rear axles force. The rest of the force will be given to front axles. This value will be set to the equivalent value in the `handling.meta` multiplied by 2 when `HandlingData` instances are initialized. 0.0 is rear wheel drive, 2.0 is front wheel drive, and any value between 0.01 and 0.199 is four wheel drive (1.0 give both front and rear axles equal force, being perfect 4WD.)
- `public float DriveInertia { get; set; }`
  - Gets or sets the drive inertia that determines how fast the engine acceleration is.
- `public float EngineDamageMultiplier { get; set; }`
- `public FlyingHandlingData FlyingHandlingData { get; }`
- `public float HandBrakeForce { get; set; }`
- `public Vector3 InertiaMultiplier { get; set; }`
- `public float InitialDragCoefficient { get; set; }`
  - Gets or sets the drag coefficient.
- `public float InitialDriveForce { get; set; }`
  - Gets or sets the power engine produces in top gear.
- `public int InitialDriveGears { get; set; }`
  - Gets or sets the number of gears (excluding reverse).
- `public float InitialDriveMaxFlatVelocity { get; set; }`
  - Determines the speed at redline in high gear; Controls the final drive of the vehicle's gearbox. Setting this value does not guarantee the vehicle will reach this speed.
- `public float InitialDriveMaxVelocity { get; set; }`
- `public bool IsValid { get; }`
  - Returns true if this `HandlingData` is valid.
- `public float LowSpeedTractionLossMultiplier { get; set; }`
  - How much traction is reduced at low speed, 0.0 means normal traction. It affects mainly car burnout (spinning wheels when car doesn't move) when pressing gas. Decreasing value will cause less burnout, less sliding at start. However, the higher value, the more burnout car gets.
- `public float Mass { get; set; }`
  - Gets or sets the weight.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where the `HandlingData` is stored in memory.
- `public int MonetaryValue { get; set; }`
- `public float OilVolume { get; set; }`
  - Gets or sets the amount of oil.
- `public float PercentSubmerged { get; set; }`
  - Gets or sets the percentage of the "floating height" after it falls into the water, before sinking.
- `public float PetrolConsumptionRate { get; set; }`
- `public float PetrolTankVolume { get; set; }`
  - Gets or sets the amount of petrol that will leak after damaging a vehicle's tank.
- `public float PopUpLightRotation { get; set; }`
  - Gets or sets the rotation values in degree the parts pop-up headlights needs to be rotated when headlights are on.
- `public float RocketBoostCapacity { get; set; }`
- `public float RollCenterHeightFront { get; set; }`
- `public float RollCenterHeightRear { get; set; }`
- `public SeaPlaneHandlingData SeaPlaneHandlingData { get; }`
- `public float SeatOffsetDistanceX { get; set; }`
- `public float SeatOffsetDistanceY { get; set; }`
- `public float SeatOffsetDistanceZ { get; set; }`
- `public float SteeringLock { get; set; }`
  - Gets or sets a value that multiplies the game's calculation of the angle of the steer wheel will turn while at full turn in radians. Steering lock is directly related to over/under-steer. When `HandlingData` instances are initialized, the game converts the value in degrees read from `handling.meta` to radians before this value is initialized.
- `public SubmarineHandlingData SubmarineHandlingData { get; }`
- `public float SuspensionBiasFront { get; set; }`
  - Gets or sets the damping scale bias between front and rear wheels. This value determines which suspension is stronger, front or rear. This value will be set to the equivalent value in the `handling.meta` multiplied by 2 when `HandlingData` instances are initialized.
- `public float SuspensionCompressionDamping { get; set; }`
  - Gets or sets the damping during strut compression. This value will be set to the equivalent value in the `handling.meta` divided by 10 when `HandlingData` instances are initialized.
- `public float SuspensionForce { get; set; }`
  - Gets or sets the suspension force. Lower limit for zero force at full extension is calculated using (1.0f / (force * number of wheels)).
- `public float SuspensionLowerLimit { get; set; }`
  - Gets or sets how far the wheels can move down from their original position.
- `public float SuspensionRaise { get; set; }`
  - Gets or sets the adjustment from artist positioning.
- `public float SuspensionReboundDamping { get; set; }`
  - Gets or sets the damping during strut rebound. This value will be set to the equivalent value in the `handling.meta` divided by 10 when `HandlingData` instances are initialized.
- `public float SuspensionUpperLimit { get; set; }`
  - Gets or sets how far the wheels can move up from their original position.
- `public float TractionBiasFront { get; set; }`
  - Gets or sets the value that determines the distribution of traction from front to rear. This value will be set to the equivalent value in the `handling.meta` multiplied by 2 when `HandlingData` instances are initialized.
- `public float TractionCurveLateral { get; set; }`
- `public float TractionCurveMax { get; set; }`
- `public float TractionCurveMin { get; set; }`
- `public float TractionLossMultiplier { get; set; }`
  - Gets or sets how much traction is affected by material grip differences from 1.0f.
- `public float TractionSpringDeltaMax { get; set; }`
  - Gets or sets the maximum distance for traction spring.
- `public TrailerHandlingData TrailerHandlingData { get; }`
- `public VehicleWeaponHandlingData VehicleWeaponHandlingData { get; }`
- `public FlyingHandlingData VerticalFlyingHandlingData { get; }`
- `public float WeaponDamageMultiplier { get; set; }`
- `public float WeaponDamageScaledToVehicleHealthMultiplier { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static HandlingData GetByHash(int handlingNameHash)`
- `public static HandlingData GetByVehicleModel(Model VehicleModel)`
- `public static bool op_Equality(HandlingData left, HandlingData right)`
- `public static bool op_Inequality(HandlingData left, HandlingData right)`

## HandlingType

enum `GTA.HandlingType`

| Name | Value |
| --- | --- |
| `Bike` | 0 |
| `Flying` | 1 |
| `VerticalFlying` | 2 |
| `Boat` | 3 |
| `SeaPlane` | 4 |
| `Submarine` | 5 |
| `Trailer` | 7 |
| `Car` | 8 |
| `Weapon` | 9 |
| `SpecialFlight` | 10 |

## HeliMissionFlags

enum `GTA.HeliMissionFlags`

| Name | Value |
| --- | --- |
| `AttainRequestedOrientation` | 1 |
| `DontModifyOrientation` | 2 |
| `DontModifyPitch` | 4 |
| `DontModifyThrottle` | 8 |
| `DontModifyRoll` | 16 |
| `LandOnArrival` | 32 |
| `DontDoAvoidance` | 64 |
| `StartEngineImmediately` | 128 |
| `ForceHeightMapAvoidance` | 256 |
| `DontClampProbesToDestination` | 512 |
| `EnableTimeslicingWhenPossible` | 1024 |
| `CircleOppositeDirection` | 2048 |
| `MaintainHeightAboveTerrain` | 4096 |
| `IgnoreHiddenEntitiesDuringLand` | 8192 |
| `DisableAllHeightMapAvoidance` | 16384 |
| `None` | 0 |
| `HeightMapOnlyAvoidance` | 320 |

## Helmet

enum `GTA.Helmet`

> **Obsolete.** Use GTA.HelmetPropFlags instead.

| Name | Value |
| --- | --- |
| `RegularMotorcycleHelmet` | 4096 |
| `FiremanHelmet` | 16384 |
| `PilotHeadset` | 32768 |

## HelmetPropFlags

enum `GTA.HelmetPropFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `Bulky` | 1 |
| `Job` | 2 |
| `Sunny` | 4 |
| `Wet` | 8 |
| `Cold` | 16 |
| `NotInCar` | 32 |
| `BikeOnly` | 64 |
| `NotIndoors` | 128 |
| `FireRetardent` | 256 |
| `Armored` | 512 |
| `LightlyArmored` | 1024 |
| `HighDetail` | 2048 |
| `DefaultHelmet` | 4096 |
| `RandomHelmet` | 8192 |
| `ScriptHelmet` | 16384 |
| `FlightHelmet` | 32768 |
| `HideInFirstPerson` | 65536 |
| `UsePhysicsHat2` | 131072 |
| `PilotHelmet` | 262144 |

## IDeletable

interface `GTA.IDeletable` : `IExistable`

An object that can be deleted from the world.

### Methods

- `public void Delete()`

## IExistable

interface `GTA.IExistable`

An object that can exist in the world.

### Methods

- `public bool Exists()`

## IJoaatHashValue

interface `GTA.IJoaatHashValue`

### Methods

- `public uint GetJoaatHash()`

## IKPart

enum `GTA.IKPart`

| Name | Value |
| --- | --- |
| `Head` | 1 |
| `ArmLeft` | 3 |
| `ArmRight` | 4 |

## IKTargetFlags

enum `GTA.IKTargetFlags`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `ArmTargetWrtHandBone` | 1 |
| `ArmTargetWrtPointHelper` | 2 |
| `ArmTargetWrtIKHelper` | 4 |
| `IKTagModeNormal` | 8 |
| `IKTagModeAllow` | 16 |
| `IKTagModeBlock` | 32 |
| `IKArmUseOrientation` | 64 |

## InputMethod

enum `GTA.InputMethod`

| Name | Value |
| --- | --- |
| `MouseAndKeyboard` | 0 |
| `GamePad` | 2 |

## Interior

static class `GTA.Interior`

### Methods

- `public static void CullExteriorObjectGeometryThisFrame(Model nameHash)`
- `public static void CullExteriorObjectShadowThisFrame(Model nameHash)`
- `public static void ForceRoomForGameViewport(InteriorProxy interior, int roomKey)`
- `public static int GetRoomKeyForGameViewport()`
- `public static void SetRoomForGameViewport(int roomKey)`
- `public static void SetRoomForGameViewport(string roomName)`

## InteriorInstance

class `GTA.InteriorInstance` : `IExistable`

### Properties

- `public int Handle { get; }`
  - The handle of this `Building`. This property is provided mainly for safer instance handling, but this is also used for equality comparison.
- `public InteriorProxy InteriorProxy { get; }`
  - Gets the `InteriorProxy` this `InteriorInstance` is loaded from.
- `public Matrix Matrix { get; }`
  - Gets this `InteriorInstance`s matrix which stores position and rotation information.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where the `InteriorInstance` is stored in memory.
- `public Model Model { get; }`
  - Gets the model of this `InteriorInstance`.
- `public Vector3 Position { get; }`
  - Gets or sets the position of this `InteriorInstance`.
- `public Quaternion Quaternion { get; }`
  - Gets the quaternion of this `InteriorInstance`.
- `public Vector3 Rotation { get; }`
  - Gets the rotation of this `InteriorInstance`.

### Methods

- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same entity as this `InteriorInstance`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same entity as this `InteriorInstance`; otherwise, `false`.
- `public bool Exists()`
  - Determines if this `InteriorInstance` exists.
  - Returns: `true` if this `InteriorInstance` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public static InteriorInstance FromHandle(int handle)`
  - Creates a new instance of an `InteriorInstance` from the given handle.
  - `handle`: The interior instance handle.
  - Returns: Returns a `InteriorInstance` if this handle corresponds to a `InteriorInstance`. Returns `null` if no `InteriorInstance` exists this the specified `handle`
- `public static bool op_Equality(InteriorInstance left, InteriorInstance right)`
  - Determines if two `InteriorInstance`s refer to the same entity.
  - `left`: The left `InteriorInstance`.
  - `right`: The right `InteriorInstance`.
  - Returns: `true` if `left` is the same entity as `right`; otherwise, `false`.
- `public static bool op_Inequality(InteriorInstance left, InteriorInstance right)`
  - Determines if two `InteriorInstance`s don't refer to the same entity.
  - `left`: The left `InteriorInstance`.
  - `right`: The right `InteriorInstance`.
  - Returns: `true` if `left` is not the same entity as `right`; otherwise, `false`.

## InteriorProxy

class `GTA.InteriorProxy` : `INativeValue`, `IExistable`

### Properties

- `public InteriorInstance CurrentInteriorInstance { get; }`
  - Gets the current `InteriorInstance` this `InteriorProxy` is using.
- `public int Handle { get; }`
  - The handle of this `InteriorProxy`.
- `public bool IsCapped { get; }`
  - Gets a value indicating whether this `InteriorProxy` will only load a few elements of the interior. Doors can be loaded and the collision is not necessarily completely disabled (e.g. collisions for bullets and projectiles can work).
- `public bool IsDisabled { get; }`
  - Gets a value indicating whether this `InteriorProxy` will behave as if interior is not loaded completely.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where the `InteriorProxy` is stored in memory.
- `public Model Model { get; }`
  - Gets the model this `InteriorProxy` will load.
- `public ulong NativeValue { get; set; }`
  - The handle of this `InteriorProxy` translated to a native value.
- `public Vector3 Position { get; }`
  - Gets or sets the position of this `AnimatedBuilding`.

### Methods

- `public void ActivateEntitySet(string entitySetName)`
- `public void Cap(bool toggle)`
  - Caps the interior so this `InteriorProxy` will only load a few elements of the interior. Does nothing if the player `Ped` is in this `InteriorProxy`.
- `public void DeactivateEntitySet(string entitySetName)`
- `public void Disable(bool toggle)`
  - Disables the interior, making `InteriorProxy` behave as if interior is not loaded completely. Does not prevent from having a `InteriorInstance`. Does nothing if the player `Ped` is in this `InteriorProxy`.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same entity as this `InteriorProxy`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same entity as this `InteriorProxy`; otherwise, `false`.
- `public bool Exists()`
  - Determines if this `InteriorProxy` exists.
  - Returns: `true` if this `InteriorProxy` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public bool IsEntitySetActive(string entitySetName)`
- `public void PinInMemory()`
  - Makes this `InteriorProxy` keep the `InteriorProxy` this `InteriorProxy` is loaded.
- `public void Refresh()`
  - Refreshs the current `InteriorInstance` if loaded. Does not change the memory address or handle of the `InteriorInstance`.
- `public void SetEntitySetTintIndex(string entitySetName, int index)`
- `public void UnpinFromMemory()`
  - Lets this `InteriorProxy` free the `InteriorProxy` this `InteriorProxy` is loaded.
- `public static InteriorProxy FromHandle(int handle)`
  - Creates a new instance of an `InteriorProxy` from the given handle.
  - `handle`: The interior proxy handle.
  - Returns: Returns a `InteriorProxy` if this handle corresponds to a `InteriorProxy`. Returns `null` if no `Entity` exists this the specified `handle`
- `public static InteriorProxy GetInteriorProxyAt(Vector3 position)`
- `public static InteriorProxy GetInteriorProxyFromGameplayCam()`
  - Gets the `InteriorProxy` if the gameplay camera is in a interior.
- `public static bool op_Equality(InteriorProxy left, InteriorProxy right)`
  - Determines if two `InteriorProxy`s refer to the same entity.
  - `left`: The left `InteriorProxy`.
  - `right`: The right `InteriorProxy`.
  - Returns: `true` if `left` is the same entity as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(InteriorProxy value)`
  - Converts an `Entity` to a native input argument.
- `public static bool op_Inequality(InteriorProxy left, InteriorProxy right)`
  - Determines if two `Entity`s don't refer to the same entity.
  - `left`: The left `Entity`.
  - `right`: The right `Entity`.
  - Returns: `true` if `left` is not the same entity as `right`; otherwise, `false`.

## IntersectFlags

enum `GTA.IntersectFlags`

| Name | Value | Description |
| --- | --- | --- |
| `Map` | 1 |  |
| `Vehicles` | 2 |  |
| `PedCapsules` | 4 | Detect `Ped` who are not ragdolled (not running any NM tasks) by detecting the simple capsule shape of `Ped`. |
| `Ragdolls` | 8 | Detect `Ped`'s ragdoll. Can detect those who are not ragdolled. |
| `Peds` | 12 |  |
| `Objects` | 16 |  |
| `Pickups` | 32 |  |
| `Glass` | 64 |  |
| `Rivers` | 128 |  |
| `Foliage` | 256 | Detect foliage, which can be affected by the wind or contacts of `Entity`. |
| `Everything` | 511 |  |
| `LosToEntity` | 17 |  |
| `BoundingBox` | 126 |  |
| `MissionEntities` | 2 |  |
| `Vegetation` | 256 |  |

## InvertAxisFlags

enum `GTA.InvertAxisFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `X` | 1 |
| `Y` | 2 |
| `Z` | 4 |

## IPedVariation

interface `GTA.IPedVariation`

### Properties

- `public int Count { get; }`
- `public bool HasAnyVariations { get; }`
- `public bool HasTextureVariations { get; }`
- `public bool HasVariations { get; }`
- `public int Index { get; set; }`
- `public string Name { get; }`
- `public int TextureCount { get; }`
- `public int TextureIndex { get; set; }`

### Methods

- `public bool IsVariationValid(int index, int textureIndex = 0)`
- `public bool SetVariation(int index, int textureIndex = 0)`

## IScriptStreamingResource

interface `GTA.IScriptStreamingResource`

### Properties

- `public bool IsLoaded { get; }`

### Methods

- `public void MarkAsNoLongerNeeded()`
- `public void Request()`

## ISpatial

interface `GTA.ISpatial`

An object with position and rotation information.

### Properties

- `public Vector3 Position { get; set; }`
- `public Vector3 Rotation { get; set; }`

## KnockOffVehicleType

enum `GTA.KnockOffVehicleType`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `Never` | 1 |
| `Easy` | 2 |
| `Hard` | 3 |

## Language

enum `GTA.Language`

| Name | Value | Description |
| --- | --- | --- |
| `American` | 0 |  |
| `French` | 1 |  |
| `German` | 2 |  |
| `Italian` | 3 |  |
| `Spanish` | 4 |  |
| `Portuguese` | 5 |  |
| `Polish` | 6 |  |
| `Russian` | 7 |  |
| `Korean` | 8 |  |
| `Chinese` | 9 | Traditional Chinese |
| `Japanese` | 10 |  |
| `Mexican` | 11 |  |
| `ChineseSimplified` | 12 |  |

## LeaveVehicleFlags

enum `GTA.LeaveVehicleFlags`

Set of flags to define the behaviour of the enter and exit vehicle tasks. Shares the same flags with `EnterVehicleFlags`.

| Name | Value | Description |
| --- | --- | --- |
| `None` | 0 |  |
| `WarpOut` | 16 | Warp the ped out of the vehicle. |
| `DontWaitForVehicleToStop` | 64 | Don't wait for the vehicle to stop before exiting. |
| `LeaveDoorOpen` | 256 | Dont close the vehicle door. |
| `WarpIfDoorIsBlocked` | 512 | Allow ped to warp to the seat if entry is blocked. The player `Ped` will warp out of the vehicle without any flags if the entry is blocked. If the shuffle link to that seat is blocked by someone but the entry point for the shuffle link is not directly blocked, the `Ped` won't warp. Consider using `WarpIfShuffleLinkIsBlocked` if you want the `Ped` to warp when the direct door and the shuffle link to that seat is blocked by someone. |
| `BailOut` | 4096 | Jump out of the vehicle regardness of its speed. |
| `DontDefaultWarpIfDoorBlocked` | 65536 | `LeaveVehicle` (or `TASK_LEAVE_ANY_VEHICLE`) auto defaults the `WarpIfDoorIsBlocked`, set this flag to not set that. |
| `FromLeftSide` | 131072 | Use entry/exit point on the left hand side. |
| `FromRightSide` | 262144 | Use entry/exit point on the right hand side. |
| `BlockSeatShuffling` | 1048576 | Disable shuffling, forcing ped to use direct door only. |
| `WarpIfShuffleLinkIsBlocked` | 4194304 | Allow ped to warp if the direct door is blocked and the shuffle link to that seat is blocked by someone. The player `Ped` will warp out of the vehicle without any flags if the entry is blocked. Unlike `WarpIfDoorIsBlocked`, this flag allows the the `Ped` to warp when the direct door and the shuffle link to that seat is blocked by someone (regardless of whether the door linked to the shuffle link is directly blocked). |
| `DontJackAnyone` | 8388608 | Never jack anyone when entering/exiting. |
| `WaitForEntryPointToBeClear` | 16777216 | Wait for our entry point to be clear of peds before exiting. |

## LicensePlateStyle

enum `GTA.LicensePlateStyle`

| Name | Value |
| --- | --- |
| `BlueOnWhite1` | 3 |
| `BlueOnWhite2` | 0 |
| `BlueOnWhite3` | 4 |
| `YellowOnBlack` | 1 |
| `YellowOnBlue` | 2 |
| `NorthYankton` | 5 |
| `ECola` | 6 |
| `LasVenturas` | 7 |
| `LibertyCity` | 8 |
| `LSCarMeet` | 9 |
| `LSPanic` | 10 |
| `LSPounders` | 11 |
| `Sprunk` | 12 |

## LicensePlateType

enum `GTA.LicensePlateType`

| Name | Value |
| --- | --- |
| `FrontAndRearPlates` | 0 |
| `FrontPlate` | 1 |
| `RearPlate` | 2 |
| `None` | 3 |

## LookAtFlags

enum `GTA.LookAtFlags`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `SlowTurnRate` | 1 |
| `FastTurnRate` | 2 |
| `ExtendYawLimit` | 4 |
| `ExtendPitchLimit` | 8 |
| `WidestYawLimit` | 16 |
| `WidestPitchLimit` | 32 |
| `NarrowYawLimit` | 64 |
| `NarrowPitchLimit` | 128 |
| `NarrowestYawLimit` | 256 |
| `NarrowestPitchLimit` | 512 |
| `WhileNotInFov` | 2048 |
| `UseCameraFocus` | 4096 |
| `UseEyesOnly` | 8192 |
| `UseLookDir` | 16384 |

## LookAtPriority

enum `GTA.LookAtPriority`

| Name | Value |
| --- | --- |
| `VeryLow` | 0 |
| `Low` | 1 |
| `Medium` | 2 |
| `High` | 3 |
| `VeryHigh` | 4 |

## MarkerType

enum `GTA.MarkerType`

| Name | Value |
| --- | --- |
| `Cone` | 0 |
| `Cylinder` | 1 |
| `Arrow` | 2 |
| `ArrowFlat` | 3 |
| `Flag` | 4 |
| `RingFlag` | 5 |
| `Ring` | 6 |
| `Plane` | 7 |
| `BikeLogo1` | 8 |
| `BikeLogo2` | 9 |
| `Num0` | 10 |
| `Num1` | 11 |
| `Num2` | 12 |
| `Num3` | 13 |
| `Num4` | 14 |
| `Num5` | 15 |
| `Num6` | 16 |
| `Num7` | 17 |
| `Num8` | 18 |
| `Num9` | 19 |
| `Chevron1` | 20 |
| `Chevron2` | 21 |
| `Chevron3` | 22 |
| `RingFlat` | 23 |
| `Lap` | 24 |
| `Halo` | 25 |
| `HaloPoint` | 26 |
| `HaloRotate` | 27 |
| `Sphere` | 28 |
| `Money` | 29 |
| `Lines` | 30 |
| `Beast` | 31 |
| `QuestionMark` | 32 |
| `TransformPlane` | 33 |
| `TransformHelicopter` | 34 |
| `TransformBoat` | 35 |
| `TransformCar` | 36 |
| `TransformBike` | 37 |
| `TransformPushBike` | 38 |
| `TransformTruck` | 39 |
| `TransformParachute` | 40 |
| `TransformThruster` | 41 |
| `Warp` | 42 |
| `Boxes` | 43 |
| `PitLane` | 44 |
| `UpsideDownCone` | 0 |
| `VerticalCylinder` | 1 |
| `ThickChevronUp` | 2 |
| `ThinChevronUp` | 3 |
| `CheckeredFlagRect` | 4 |
| `CheckeredFlagCircle` | 5 |
| `VerticleCircle` | 6 |
| `PlaneModel` | 7 |
| `LostMCDark` | 8 |
| `LostMCLight` | 9 |
| `Number0` | 10 |
| `Number1` | 11 |
| `Number2` | 12 |
| `Number3` | 13 |
| `Number4` | 14 |
| `Number5` | 15 |
| `Number6` | 16 |
| `Number7` | 17 |
| `Number8` | 18 |
| `Number9` | 19 |
| `ChevronUpx1` | 20 |
| `ChevronUpx2` | 21 |
| `ChevronUpx3` | 22 |
| `HorizontalCircleFat` | 23 |
| `ReplayIcon` | 24 |
| `HorizontalCircleSkinny` | 25 |
| `HorizontalCircleSkinnyArrow` | 26 |
| `HorizontalSplitArrowCircle` | 27 |
| `DebugSphere` | 28 |

## MaterialHash

enum `GTA.MaterialHash`

214 values:

```text
None = 0
Default = 2519482235
Concrete = 1187676648
ConcretePothole = 359120722
ConcreteDusty = 3210327185
Tarmac = 282940568
TarmacPainted = 2993614768
TarmacPothole = 1886546517
RumbleStrip = 4044799021
BreezeBlock = 3340854742
Rock = 3454750755
RockMossy = 4170197704
Stone = 765206029
Cobblestone = 576169331
Brick = 1639053622
Marble = 1945073303
PavingSlab = 1907048430
SandstoneSolid = 592446772
SandstoneBrittle = 1913209870
SandLoose = 2699818980
SandCompact = 510490462
SandWet = 909950165
SandTrack = 2387446527
SandUnderwater = 3158909604
SandDryDeep = 509508168
SandWetDeep = 1288448767
Ice = 3508906581
IceTarmac = 2363942873
SnowLoose = 2357397706
SnowCompact = 3416406407
SnowDeep = 1619704960
SnowTarmac = 1550304810
GravelSmall = 951832588
GravelLarge = 2128369009
GravelDeep = 3938260814
GravelTrainTrack = 1925605558
DirtTrack = 2409420175
MudHard = 2352068586
MudPothole = 312396330
MudSoft = 1635937914
MudUnderwater = 4021477129
MudDeep = 1109728704
Marsh = 223086562
MarshDeep = 1584636462
Soil = 3594309083
ClayHard = 1144315879
ClaySoft = 560985072
GrassLong = 3833216577
Grass = 1333033863
GrassShort = 3008270349
Hay = 2461440131
Bushes = 581794674
Twigs = 3381615457
Leaves = 2253637325
Woodchips = 3985845843
TreeBark = 2379541433
MetalSolidSmall = 2847687191
MetalSolidMedium = 3929336056
MetalSolidLarge = 752131025
MetalHollowSmall = 15972667
MetalHollowMedium = 1849540536
MetalHollowLarge = 3711753465
MetalChainLinkSmall = 762193613
MetalChainLinkLarge = 125958708
MetalCorrugatedIron = 834144982
MetalGrille = 3868849285
MetalRailing = 2100727187
MetalDuct = 1761524221
MetalGarageDoor = 4063706601
MetalManhole = 3539969597
WoodSolidSmall = 3895095068
WoodSolidMedium = 555004797
WoodSolidLarge = 815762359
WoodSolidPolished = 126470059
WoodFloorDusty = 3545514974
WoodHollowSmall = 1993976879
WoodHollowMedium = 3929491133
WoodHollowLarge = 3369548007
WoodChipboard = 1176309403
WoodOldCreaky = 722686013
WoodHighDensity = 2552123904
WoodLattice = 2011204130
Ceramic = 3108646581
RoofTile = 1755188853
RoofFelt = 2877802565
Fiberglass = 1354180827
Tarpaulin = 3652308448
Plastic = 2221655295
PlasticHollow = 627123000
PlasticHighDensity = 2668971817
PlasticClear = 2435246283
PlasticHollowClear = 772722531
PlasticHighDensityClear = 2956494126
FiberglassHollow = 3528912198
Rubber = 4149231379
RubberHollow = 3511032624
Linoleum = 289630530
Laminate = 1845676458
CarpetSolid = 669292054
CarpetSolidDusty = 158576196
CarpetFloorboard = 2898482353
Cloth = 122789469
PlasterSolid = 3720844863
PlasterBrittle = 4043078398
CardboardSheet = 236511221
CardboardBox = 2885912856
Paper = 474149820
Foam = 808719444
FeatherPillow = 1341866303
Polystyrene = 2538039965
Leather = 3724496396
TvScreen = 1429989756
SlattedBlinds = 673696729
GlassShootThrough = 937503243
GlassBulletproof = 244521486
GlassOpaque = 1500272081
Perspex = 2675173228
CarMetal = 4201905313
CarPlastic = 2137197282
CarSoftTop = 3315319434
CarSoftTopClear = 2130571536
CarGlassWeak = 1247281098
CarGlassMedium = 602884284
CarGlassStrong = 1070994698
CarGlassBulletproof = 2573051366
CarGlassOpaque = 513061559
Water = 435688960
Blood = 5236042
Oil = 3660485991
Petrol = 2660782956
FreshMeat = 868733839
DriedMeat = 2849806867
EmissiveGlass = 1501078253
EmissivePlastic = 1059629996
VfxMetalElectrified = 3985833031
VfxMetalWaterTower = 611561919
VfxMetalSteam = 3603690002
VfxMetalFlame = 332778253
PhysNoFriction = 1666473731
PhysGolfBall = 2601153738
PhysTennisBall = 4038262533
PhysCaster = 4059664613
PhysCasterRusty = 2016463089
PhysCarVoid = 1345867677
PhysPedCapsule = 4003336261
PhysElectricFence = 3124923563
PhysElectricMetal = 2281206151
PhysBarbedWire = 2751643840
PhysPoolTableSurface = 605776921
PhysPoolTableCushion = 972939963
PhysPoolTableBall = 3546625734
Buttocks = 483400232
ThighLeft = 3834431425
ShinLeft = 652772852
FootLeft = 1926285543
ThighRight = 4057986041
ShinRight = 3848931141
FootRight = 2925830612
Spine0 = 2372680412
Spine1 = 3154854427
Spine2 = 1457572381
Spine3 = 32752644
ClavicleLeft = 2825350831
UpperArmLeft = 3784624938
LowerArmLeft = 1045062756
HandLeft = 113101985
ClavicleRight = 2737678298
UpperArmRight = 1501153539
LowerArmRight = 1777921590
HandRight = 2000961972
Neck = 1718294164
Head = 3559574543
AnimalDefault = 286224918
CarEngine = 2378027672
Puddle = 999829011
ConcretePavement = 2015599386
BrickPavement = 3147605720
PhysDynamicCoverBound = 2247498441
VfxWoodBeerBarrel = 998201806
WoodHighFriction = 2154880249
RockNoinst = 127813971
BushesNoinst = 1441114862
MetalSolidRoadSurface = 3565854962
StuntRampSurface = 2206792300
Temp01 = 746881105
Temp02 = 2316997185
Temp03 = 1911121241
Temp04 = 1923995104
Temp05 = 2901304848
Temp06 = 1061250033
Temp07 = 2529443614
Temp08 = 1343679702
Temp09 = 1026054937
Temp10 = 63305994
Temp11 = 47470226
Temp12 = 702596674
Temp13 = 2657481383
Temp14 = 3649011722
Temp15 = 2710969365
Temp16 = 2782232023
Temp17 = 1011960114
Temp18 = 1354993138
Temp19 = 3493162850
Temp20 = 2242086891
Temp21 = 3257211236
Temp22 = 3674578943
Temp23 = 465002639
Temp24 = 1963820161
Temp25 = 1952288305
Temp26 = 3178714198
Temp27 = 889255498
Temp28 = 3115293198
Temp29 = 1078418101
Temp30 = 13626292
```

## MeasurementSystem

enum `GTA.MeasurementSystem`

| Name | Value |
| --- | --- |
| `Imperial` | 0 |
| `Metric` | 1 |

## MinimumRequiredGameBuildAttribute

class `GTA.MinimumRequiredGameBuildAttribute` : `Attribute`, `_Attribute`

### Constructors

- `public MinimumRequiredGameBuildAttribute(int build)`

### Properties

- `public int Build { get; }`

## Model

struct `GTA.Model` : `IEquatable<Model>`, `INativeValue`, `IScriptStreamingResource`

### Constructors

- `public Model(PedHash hash)`
- `public Model(VehicleHash hash)`
- `public Model(WeaponHash hash)`
- `public Model(int hash)`
- `public Model(string name)`

### Properties

- `public ValueTuple<Vector3, Vector3> Dimensions { get; }`
  - Gets the dimensions of this `Model`.
  - Returns: rearBottomLeft is the minimum dimensions, which contains the rear bottom left relative offset from the origin of the model, frontTopRight is the maximum dimensions, which contains the front top right relative offset from the origin of the model.
- `public int Hash { get; }`
  - Gets the hash for this `Model`.
- `public bool IsAmphibiousCar { get; }`
  - Gets a value indicating whether this `Model` is an amphibious car.
- `public bool IsAmphibiousQuadBike { get; }`
  - Gets a value indicating whether this `Model` is an amphibious quad bike.
- `public bool IsAmphibiousVehicle { get; }`
  - Gets a value indicating whether this `Model` is an amphibious vehicle.
- `public bool IsAnimalPed { get; }`
  - Gets a value indicating whether this `Model` is a animal pedestrian.
- `public bool IsBicycle { get; }`
  - Gets a value indicating whether this `Model` is a bicycle.
- `public bool IsBigVehicle { get; }`
  - Gets a value indicating whether this `Model` is a big vehicle whose vehicle flag has "FLAG_BIG".
- `public bool IsBike { get; }`
  - Gets a value indicating whether this `Model` is a bike (either a motorcycle or a bicycle).
- `public bool IsBlimp { get; }`
  - Gets a value indicating whether this `Model` is a blimp.
- `public bool IsBoat { get; }`
  - Gets a value indicating whether this `Model` is a boat.
- `public bool IsBus { get; }`
  - Gets a value indicating whether this `Model` is an emergency vehicle.
- `public bool IsCar { get; }`
  - Gets a value indicating whether this `Model` is a car.
- `public bool IsCargobob { get; }`
  - Gets a value indicating whether this `Model` is a cargobob.
- `public bool IsCollisionLoaded { get; }`
  - Gets a value indicating whether the collision for this `Model` is loaded.
- `public bool IsDonk { get; }`
  - Gets a value indicating whether this `Model` is a donk car.
- `public bool IsElectricVehicle { get; }`
  - Gets a value indicating whether this `Model` is an electric vehicle.
- `public bool IsEmergencyVehicle { get; }`
  - Gets a value indicating whether this `Model` is an emergency vehicle.
- `public bool IsFemalePed { get; }`
  - Gets a value indicating whether this `Model` is a female pedestrian.
- `public bool IsFragment { get; }`
- `public bool IsGangPed { get; }`
  - Gets a value indicating whether this `Model` is a gangster pedestrian.
- `public bool IsHelicopter { get; }`
  - Gets a value indicating whether this `Model` is a helicopter.
- `public bool IsHumanPed { get; }`
  - Gets a value indicating whether this `Model` is a human pedestrian.
- `public bool IsInCdImage { get; }`
  - Gets a value indicating whether this `Model` is in the CD image.
- `public bool IsJetSki { get; }`
  - Gets a value indicating whether this `Model` is a jet ski.
- `public bool IsLawEnforcementVehicle { get; }`
  - Gets a value indicating whether this `Model` is a law enforcement vehicle.
- `public bool IsLoaded { get; }`
  - Gets a value indicating whether this `Model` is loaded so it can be spawned.
- `public bool IsLowrider { get; }`
  - Gets a value indicating whether this `Model` is a regular lowrider.
- `public bool IsMalePed { get; }`
  - Gets a value indicating whether this `Model` is a male pedestrian. Without modding `pedpersonality.ymt`, returns `true` if the `Hash` is one of the animal hashes.
- `public bool IsMlo { get; }`
  - Gets a value indicating whether this `Model` is a movable interior loader (also known as MLO or MILO).
- `public bool IsMotorcycle { get; }`
  - Gets a value indicating whether this `Model` is a motorcycle.
- `public bool IsOffRoadVehicle { get; }`
  - Gets a value indicating whether this `Model` is an off-road vehicle.
- `public bool IsPed { get; }`
  - Gets a value indicating whether this `Model` is a pedestrian.
- `public bool IsPlane { get; }`
  - Gets a value indicating whether this `Model` is a plane.
- `public bool IsProp { get; }`
  - Gets a value indicating whether this `Model` is a prop.
- `public bool IsQuadBike { get; }`
  - Gets a value indicating whether this `Model` is a quad bike.
- `public bool IsSubmarine { get; }`
  - Gets a value indicating whether this `Model` is a submarine.
- `public bool IsSubmarineCar { get; }`
  - Gets a value indicating whether this `Model` is a submarine car.
- `public bool IsTank { get; }`
  - Gets a value indicating whether this `Model` is a tank.
- `public bool IsTrailer { get; }`
  - Gets a value indicating whether this `Model` is a trailer.
- `public bool IsTrain { get; }`
  - Gets a value indicating whether this `Model` is a train.
- `public bool IsValid { get; }`
  - Gets if this `Model` is valid.
- `public bool IsVan { get; }`
  - Gets a value indicating whether this `Model` is a van.
- `public bool IsVehicle { get; }`
  - Gets a value indicating whether this `Model` is a vehicle.
- `public ulong NativeValue { get; set; }`
  - Gets the native representation of this `Model`.

### Methods

- `public bool Equals(Model model)`
- `public virtual bool Equals(object obj)`
- `public void GetDimensions(out Vector3 min, out Vector3 max)`
- `public virtual int GetHashCode()`
- `public void MarkAsNoLongerNeeded()`
  - Tells the game we have finished using this `Model` and it can be freed from memory.
- `public void Request()`
  - Attempts to load this `Model` into memory.
- `public bool Request(int timeout)`
  - Attempts to load this `Model` into memory for a given period of time.
  - `timeout`: The time (in milliseconds) before giving up trying to load this `Model`.
  - Returns: `true` if this `Model` is loaded; otherwise, `false`.
- `public void RequestCollision()`
  - Attempts to load this `Model`'s collision into memory.
- `public bool RequestCollision(int timeout)`
  - Attempts to load this `Model`'s collision into memory for a given period of time.
  - `timeout`: The time (in milliseconds) before giving up trying to load this `Model`.
  - Returns: `true` if this `Model`'s collision is loaded; otherwise, `false`.
- `public virtual string ToString()`
- `public static bool op_Equality(Model left, Model right)`
- `public static InputArgument op_Implicit(Model value)`
- `public static PedHash op_Implicit(Model source)`
- `public static VehicleHash op_Implicit(Model source)`
- `public static WeaponHash op_Implicit(Model source)`
- `public static int op_Implicit(Model source)`
- `public static Model op_Implicit(PedHash source)`
- `public static Model op_Implicit(VehicleHash source)`
- `public static Model op_Implicit(WeaponHash source)`
- `public static Model op_Implicit(int source)`
- `public static Model op_Implicit(string source)`
- `public static bool op_Inequality(Model left, Model right)`

## MoveNetworkFlags

enum `GTA.MoveNetworkFlags`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `UseKinematicPhysics` | 4 |
| `Secondary` | 8 |
| `UseFirstPersonArmIkLeft` | 16 |
| `UseFirstPersonArmIkRight` | 32 |
| `EnableCollisionOnNetworkCloneWhenFixed` | 64 |

## NavMeshBlockingObject

class `GTA.NavMeshBlockingObject` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`

### Methods

- `public virtual void Delete()`
- `public virtual bool Equals(object obj)`
- `public virtual bool Exists()`
- `public virtual int GetHashCode()`
- `public void Update(Vector3 position, Vector3 size, float headingDegrees, NavMeshBlockingObjectFlags flags)`
- `public static NavMeshBlockingObject Create(Vector3 position, Vector3 size, float headingDegrees, NavMeshBlockingObjectFlags flags = 7)`
- `public static bool op_Equality(NavMeshBlockingObject left, NavMeshBlockingObject right)`
- `public static InputArgument op_Implicit(NavMeshBlockingObject value)`
- `public static bool op_Inequality(NavMeshBlockingObject left, NavMeshBlockingObject right)`

## NavMeshBlockingObjectFlags

enum `GTA.NavMeshBlockingObjectFlags`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `WanderPath` | 1 |
| `ShortestPath` | 2 |
| `FleePath` | 4 |
| `AllPaths` | 7 |

## NavMeshRouteResult

enum `GTA.NavMeshRouteResult`

| Name | Value |
| --- | --- |
| `TaskNotFound` | 0 |
| `RouteNotYetTried` | 1 |
| `RouteNotFound` | 2 |
| `RouteFound` | 3 |

## NewLoadSceneFlags

enum `GTA.NewLoadSceneFlags`

| Name | Value |
| --- | --- |
| `RequireCollision` | 1 |
| `LongSwitchCutscene` | 2 |
| `InteriorAndExterior` | 4 |

## ParachuteLandingType

enum `GTA.ParachuteLandingType`

| Name | Value | Description |
| --- | --- | --- |
| `Invalid` | -1 | Ped is not in a valid parachute landing state. |
| `Slow` | 0 |  |
| `Regular` | 1 | Ped is landing at regular speed (they are stumbling). |
| `Fast` | 2 | Ped is landing at fast speed (they are rolling). |
| `Crashing` | 3 | Ped is crashing (ragdolling). |
| `Water` | 4 |  |
| `None` | -1 |  |
| `Stumbling` | 1 |  |
| `Rolling` | 2 |  |
| `Ragdoll` | 3 |  |

## ParachuteState

enum `GTA.ParachuteState`

| Name | Value |
| --- | --- |
| `None` | -1 |
| `FreeFalling` | 0 |
| `Deploying` | 1 |
| `Gliding` | 2 |
| `LandingOrFallingToDoom` | 3 |

## ParachuteTint

enum `GTA.ParachuteTint`

| Name | Value |
| --- | --- |
| `None` | -1 |
| `Rainbow` | 0 |
| `Red` | 1 |
| `SeasideStripes` | 2 |
| `WidowMaker` | 3 |
| `Patriot` | 4 |
| `Blue` | 5 |
| `Black` | 6 |
| `Hornet` | 7 |
| `AirFocce` | 8 |
| `Desert` | 9 |
| `Shadow` | 10 |
| `HighAltitude` | 11 |
| `Airbone` | 12 |
| `Sunrise` | 13 |

## ParkType

enum `GTA.ParkType`

| Name | Value |
| --- | --- |
| `Parallel` | 0 |
| `PerpendicularNoseIn` | 1 |
| `PerpendicularBackIn` | 2 |
| `PullOver` | 3 |
| `LeaveParallelSpace` | 4 |
| `BackOutPerpendicularSpace` | 5 |
| `PassengerExit` | 6 |
| `PullOverImmediate` | 7 |

## ParticleEffect

class `GTA.ParticleEffect` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`

### Properties

- `public string AssetName { get; }`
  - Gets the name of the asset used for this `ParticleEffect`.
- `public EntityBone Bone { get; }`
  - Gets the `EntityBone` that this `ParticleEffect` is attached to or `null` if there is none.
- `public Color Color { get; set; }`
  - Gets or sets the `Color` of this `ParticleEffect`.
- `public string EffectName { get; }`
  - Gets the name of the effect used for this `ParticleEffect`.
- `public Entity Entity { get; }`
  - Gets the `Entity` this `ParticleEffect` is attached to or `null` if there is none.
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where this `ParticleEffect` is located in game memory.
- `public Vector3 Offset { get; set; }`
  - Gets or sets the offset. If this `ParticleEffect` is attached to an `Entity`, this refers to the offset from the `Entity`; otherwise, this refers to its position in World coordinates
- `public float Range { get; set; }`
  - Gets or sets the range of this `ParticleEffect`.
- `public Vector3 Rotation { set; }`
  - Sets the rotation of this `ParticleEffect`
- `public float Scale { get; set; }`
  - Gets or sets the size scaling factor of this `ParticleEffect`.

### Methods

- `public virtual void Delete()`
  - Stops and removes this `ParticleEffect`.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same effect as this `ParticleEffect`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same effect as this `ParticleEffect`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `Checkpoint` exists.
  - Returns: `true` if this `Checkpoint` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public void SetParameter(string parameterName, float value)`
  - Modifys parameters of this `ParticleEffect`.
  - `parameterName`: Name of the parameter you want to modify, these are stored inside the effect files.
  - `value`: The new value for the parameter.
- `public virtual string ToString()`
- `public static bool op_Equality(ParticleEffect left, ParticleEffect right)`
  - Determines if two `ParticleEffect`s refer to the same effect.
  - `left`: The left `ParticleEffect`.
  - `right`: The right `ParticleEffect`.
  - Returns: `true` if `left` is the same effect as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(ParticleEffect effect)`
  - Converts a `ParticleEffect` to a native input argument.
- `public static bool op_Inequality(ParticleEffect left, ParticleEffect right)`
  - Determines if two `ParticleEffect`s don't refer to the same effect.
  - `left`: The left `ParticleEffect`.
  - `right`: The right `ParticleEffect`.
  - Returns: `true` if `left` is not the same effect as `right`; otherwise, `false`.

## ParticleEffectAsset

struct `GTA.ParticleEffectAsset` : `IEquatable<ParticleEffectAsset>`, `IScriptStreamingResource`

### Constructors

- `public ParticleEffectAsset(string assetName)`
  - Creates a class used for loading `ParticleEffectAsset`s than can be used to start `ParticleEffect`s from inside the Asset
  - `assetName`: The name of the asset file which contains all the `ParticleEffect`s you are wanting to start

### Properties

- `public string AssetName { get; }`
  - Gets the name of the this `ParticleEffectAsset` file.
- `public bool IsLoaded { get; }`
  - Gets a value indicating whether this `ParticleEffectAsset` is Loaded
- `public static Color NonLoopedColor { set; }`
  - Sets the `Color` for all NonLooped Particle Effects

### Methods

- `public bool Equals(ParticleEffectAsset asset)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public void MarkAsNoLongerNeeded()`
  - Tells the game we have finished using this `ParticleEffectAsset` and it can be freed from memory.
- `public void Request()`
  - Attempts to load this `ParticleEffectAsset` into memory so it can be used for starting `ParticleEffect`s.
- `public bool Request(int timeout)`
  - Attempts to load this `ParticleEffectAsset` into memory so it can be used for starting `ParticleEffect`s.
  - `timeout`: How long in milliseconds should the game wait while the model hasn't been loaded before giving up
  - Returns: `true` if the `ParticleEffectAsset` is Loaded; otherwise, `false`
- `public virtual string ToString()`
- `public static bool op_Equality(ParticleEffectAsset left, ParticleEffectAsset right)`
- `public static InputArgument op_Implicit(ParticleEffectAsset asset)`
  - Converts a `ParticleEffectAsset` to a native input argument.
- `public static bool op_Inequality(ParticleEffectAsset left, ParticleEffectAsset right)`

## PathFind

static class `GTA.PathFind`

### Methods

- `public static bool ArePathNodesLoadedForArea(Vector2 min, Vector2 max)`
- `public static PathNode[] GetAllVehicleNodes(Func<VehiclePathNodePropertyFlags, bool> predicate = null)`
- `public static PathNode GetClosestVehicleNode(Vector3 position, float radius, Func<VehiclePathNodePropertyFlags, bool> predicate = null)`
- `public static bool GetClosestVehicleNodePosition(Vector3 position, out Vector3 closestNodePosition, GetClosestVehicleNodeFlags flags = 0, float zMeasureMult = 3, float zTolerance = 0)`
- `public static PathNode[] GetNearbyVehicleNodes(Vector3 position, float radius, Func<VehiclePathNodePropertyFlags, bool> predicate = null)`
- `public static PathNode GetNthClosestVehicleNode(Vector3 position, int nthClosest, GetClosestVehicleNodeFlags flags = 0, float zMeasureMult = 3, float zTolerance = 0)`
- `public static bool GetNthClosestVehicleNodePosition(Vector3 position, int nthClosest, out Vector3 closestNodePosition, GetClosestVehicleNodeFlags flags = 0, float zMeasureMult = 3, float zTolerance = 0)`
- `public static bool GetNthClosestVehicleNodePositionWithHeading(Vector3 position, int nthClosest, out Vector3 closestNodePosition, out float heading, out int numLanes, GetClosestVehicleNodeFlags flags = 0, float zMeasureMult = 3, float zTolerance = 0)`
- `public static PathNode GetNthClosestVehicleNodeWithHeading(Vector3 position, int nthClosest, out float heading, out int numLanes, GetClosestVehicleNodeFlags flags = 0, float zMeasureMult = 3, float zTolerance = 0)`
- `public static PathNode[] GetVehicleNodesInArea(Vector3 min, Vector3 max, Func<VehiclePathNodePropertyFlags, bool> predicate = null)`
- `public static bool RequestPathNodesInAreaThisFrame(Vector2 min, Vector2 max)`
- `public static void SetPedPathsBackToOriginal(Vector3 min, Vector3 max, bool forceAbortCurrentPath)`
- `public static void SetVehicleNodesBackToOriginal(Vector3 min, Vector3 max)`
- `public static void SetVehicleNodesBackToOriginalInAngledArea(Vector3 position1, Vector3 position2, float areaWidth)`
- `public static void SwitchPedPathsInArea(Vector3 min, Vector3 max, bool active, bool forceAbortCurrentPath)`
- `public static void SwitchVehicleNodesInAngledArea(Vector3 position1, Vector3 position2, float areaWidth, bool active)`
- `public static void SwitchVehicleNodesInArea(Vector3 min, Vector3 max, bool active)`

## PathNode

class `GTA.PathNode` : `INativeValue`

### Properties

- `public int AreaId { get; }`
- `public int Handle { get; }`
- `public bool IsGpsAllowed { get; }`
- `public bool IsLoaded { get; }`
- `public bool IsSwitchedOff { get; set; }`
- `public IntPtr MemoryAddress { get; }`
- `public ulong NativeValue { get; set; }`
- `public int NodeId { get; }`
- `public Vector3 Position { get; }`
- `public int VehicleDensity { get; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public PathNodeLink[] GetAllPathNodeLinks()`
- `public virtual int GetHashCode()`
- `public VehiclePathNodePropertyFlags GetVehicleNodePropertyFlags()`
- `public static bool op_Equality(PathNode left, PathNode right)`
- `public static InputArgument op_Implicit(PathNode value)`
- `public static bool op_Inequality(PathNode left, PathNode right)`

## PathNodeLink

class `GTA.PathNodeLink`

### Properties

- `public int AreaId { get; }`
- `public int BackwardLaneCount { get; }`
- `public int ForwardLaneCount { get; }`
- `public int Index { get; }`
- `public bool IsLoaded { get; }`
- `public IntPtr MemoryAddress { get; }`
- `public int TargetAreaId { get; }`
- `public int TargetNodeId { get; }`
- `public PathNode TargetPathNode { get; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public ValueTuple<int, int> GetForwardAndBackwardLaneCounts()`
- `public bool GetForwardAndBackwardLaneCounts(out int forwardLaneCount, out int backwardLaneCount)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(PathNodeLink left, PathNodeLink right)`
- `public static bool op_Inequality(PathNodeLink left, PathNodeLink right)`

## Ped

class `GTA.Ped` : `Entity`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Properties

- `public int Accuracy { get; set; }`
  - Gets or sets how accurate this `Ped`s shooting ability is. The higher the value of this property is, the more likely it is that this `Ped` will shoot at exactly where they are aiming at.
- `public bool AlwaysKeepTask { set; }`
  - **Obsolete.** Ped.AlwaysKeepTask is obsolete because it does not indicate that it only affects when the ped is marked as no longer needed. Use Ped.KeepTaskWhenMarkedAsNoLongerNeeded instead.
  - Sets whether this `Ped` keeps their tasks when they are marked as no longer needed by `MarkAsNoLongerNeeded` or gets cleaned up by the mission script. Despite the property name, this property does not determine whether permanent events can interrupt the `Ped`'s tasks (e.g. seeing hated peds or getting shot at). If set to `false`, this `Ped`'s task will be immediately cleared and start some ambient tasks (most likely start wandering) when they are marked as no longer needed. If set to `true`, this `Ped` will keep their task until they have nothing to do (where their task stacks only contains `CTaskDoNothing`). Once this `Ped` has nothing to do, their task will clear and they'll start some ambient tasks (one-time-only).
- `public uint AmbientVoiceHash { get; set; }`
- `public int Armor { get; set; }`
  - Gets or sets how much armor this `Ped` is wearing as an `Int32`.
- `public float ArmorFloat { get; set; }`
  - Gets or sets how much Armor this `Ped` is wearing as a `Single`.
- `public bool BlockPermanentEvents { get; set; }`
  - Sets whether permanent events are blocked for this `Ped`. If set to `true`, this `Ped` will no longer react to permanent events and will only do as they're told. For example, the `Ped` will not flee when get shot at and they will not begin combat even if the decision maker specifies that seeing a hated ped should. However, the `Ped` will still respond to temporary events like walking around other peds or vehicles even if this property is set to `true`.
- `public PedBoneCollection Bones { get; }`
  - Gets a collection of the `PedBone`s in this `Ped`.
- `public bool CanBeDraggedOutOfVehicle { get; set; }`
- `public bool CanBeKnockedOffBike { set; }`
  - **Obsolete.** Use Ped.KnockOffVehicleType instead.
- `public bool CanBeKnockedOffVehicle { get; }`
- `public bool CanBeShotInVehicle { get; set; }`
- `public bool CanBeTargetted { get; set; }`
- `public bool CanFlyThroughWindscreen { get; set; }`
- `public bool CanPlayGestures { get; set; }`
- `public bool CanRagdoll { get; set; }`
- `public bool CanSufferCriticalHits { get; set; }`
  - Gets or Sets whether this `Ped` can suffer critical damage (which deals 1000 times base damages to non-player characters with default weapon configs) when bullets hit this `Ped`'s head bone or its child bones. If this `Ped` can't suffer critical damage, they will take base damage of weapons when bullets hit their head bone or its child bones, just like when bullets hit a bone other than their head bone, its child bones, or limb bones.
- `public bool CanSwitchWeapons { get; set; }`
  - Sets if this `Ped` can switch between different weapons.
- `public bool CanWearHelmet { get; set; }`
- `public bool CanWrithe { get; set; }`
- `public WeaponHash CauseOfDeath { get; }`
  - Gets the `WeaponHash` that this `Ped` is killed with. The return value is not necessarily a weapon hash for a human `Ped`s (e.g. can be the hash of `WEAPON_COUGAR`).
- `public CombatAbility CombatAbility { set; }`
- `public CombatMovement CombatMovement { get; set; }`
- `public CombatRange CombatRange { get; set; }`
- `public Ped CombatTarget { get; }`
- `public ScriptTaskNameHash CurrentScriptTaskNameHash { get; }`
- `public ScriptTaskStatus CurrentScriptTaskStatus { get; }`
- `public Vehicle CurrentVehicle { get; }`
  - Gets the current `Vehicle` this `Ped` is using.
- `public DecisionMaker DecisionMaker { get; set; }`
- `public bool DiesInstantlyInWater { get; set; }`
- `public bool DiesOnLowHealth { get; set; }`
- `public float DrivingAggressiveness { set; }`
- `public float DrivingSpeed { set; }`
- `public DrivingStyle DrivingStyle { set; }`
  - **Obsolete.** Use Ped.VehicleDrivingFlags instead.
- `public bool DropsEquippedWeaponOnDeath { get; set; }`
  - Sets whether this `Ped` will drop the equipped weapon when they get killed. Note that `Ped`s will drop only their equipped weapon when they get killed.
- `public bool DrownsInSinkingVehicle { get; set; }`
- `public bool DrownsInWater { get; set; }`
- `public Euphoria Euphoria { get; }`
  - Opens a list of `Euphoria` Helpers which can be applied to this `Ped`.
- `public float FatalInjuryHealthThreshold { get; set; }`
  - Gets or sets the fatal injury health threshold for this `Ped`. The pedestrian health will be set to 0.0 when it drops below this value.
- `public FiringPattern FiringPattern { get; set; }`
  - Gets of sets the pattern this `Ped` uses to fire weapons.
- `public Gender Gender { get; }`
  - Gets the gender of this `Ped`.
- `public Entity GroundEntity { get; }`
- `public float HearingRange { get; set; }`
- `public float InjuryHealthThreshold { get; set; }`
  - Gets or sets the injury health threshold for this `Ped`. The pedestrian is considered injured when its health drops below this value. The pedestrian dies on attacks when its health is below this value.
- `public bool IsAiming { get; }`
- `public bool IsAimingFromCover { get; }`
- `public bool IsAmbientSpeechEnabled { get; set; }`
- `public bool IsAmbientSpeechPlaying { get; }`
- `public bool IsAnySpeechPlaying { get; }`
- `public bool IsBeingJacked { get; }`
- `public bool IsBeingStealthKilled { get; }`
- `public bool IsBeingStunned { get; }`
- `public bool IsClimbing { get; }`
- `public bool IsClimbingLadder { get; }`
- `public bool IsCuffed { get; }`
- `public bool IsDiving { get; }`
- `public bool IsDoingDriveBy { get; }`
- `public bool IsDucking { get; set; }`
- `public bool IsEnemy { get; set; }`
- `public bool IsEnteringVehicle { get; }`
- `public bool IsExitingVehicle { get; }`
- `public bool IsFalling { get; }`
- `public bool IsFleeing { get; }`
- `public bool IsGettingIntoVehicle { get; }`
  - **Obsolete.** Use IsEnteringVehicle instead.
- `public bool IsGettingUp { get; }`
- `public bool IsGoingIntoCover { get; }`
- `public bool IsHuman { get; }`
  - Gets a value indicating whether this `Ped` is human.
- `public bool IsIdle { get; }`
- `public bool IsInBoat { get; }`
- `public bool IsInCombat { get; }`
- `public bool IsInCover { get; }`
- `public bool IsInCoverFacingLeft { get; }`
- `public bool IsInFlyingVehicle { get; }`
- `public bool IsInGroup { get; }`
  - Gets if this `Ped` is in a `PedGroup`.
- `public bool IsInHeli { get; }`
- `public bool IsInjured { get; }`
  - Gets a value indicating whether this `Ped` is injured (`Health` of the `Ped` is lower than `InjuryHealthThreshold`) or does not exist. Can be called safely to check if `Ped`s exist and are not injured without calling `Exists`.
- `public bool IsInMeleeCombat { get; }`
- `public bool IsInParachuteFreeFall { get; }`
- `public bool IsInPlane { get; }`
- `public bool IsInPoliceVehicle { get; }`
- `public bool IsInStealthMode { get; }`
- `public bool IsInSub { get; }`
- `public bool IsInTaxi { get; }`
- `public bool IsInTrain { get; }`
- `public bool IsJacking { get; }`
- `public bool IsJumping { get; }`
- `public bool IsJumpingOutOfVehicle { get; }`
  - Gets a value indicating whether this `Ped` is jumping out of their vehicle.
- `public bool IsOnBike { get; }`
- `public bool IsOnFoot { get; }`
- `public bool IsPainAudioEnabled { get; set; }`
- `public bool IsPerformingCounterAttack { get; }`
- `public bool IsPerformingMeleeAction { get; }`
- `public bool IsPerformingStealthKill { get; }`
- `public bool IsPlantingBomb { get; }`
- `public bool IsPlayer { get; }`
- `public bool IsPriorityTargetForEnemies { get; set; }`
- `public bool IsProne { get; }`
- `public bool IsRagdoll { get; }`
- `public bool IsReadyToShoot { get; }`
- `public bool IsReloading { get; }`
- `public bool IsRunning { get; }`
- `public bool IsRunningRagdollTask { get; }`
- `public bool IsScriptedSpeechPlaying { get; }`
- `public bool IsShooting { get; }`
- `public bool IsSprinting { get; }`
- `public bool IsStopped { get; }`
- `public bool IsSwimming { get; }`
- `public bool IsSwimmingUnderWater { get; }`
- `public bool IsTakingOffHelmet { get; }`
- `public bool IsTryingToEnterALockedVehicle { get; }`
- `public bool IsVaulting { get; }`
- `public bool IsWalking { get; }`
- `public bool IsWearingHelmet { get; }`
- `public bool IsWet { get; }`
- `public Ped Jacker { get; }`
- `public Ped JackTarget { get; }`
- `public bool KeepTaskWhenMarkedAsNoLongerNeeded { get; set; }`
- `public Entity Killer { get; }`
  - Gets the `Entity` that killed this `Ped`.
- `public KnockOffVehicleType KnockOffVehicleType { get; set; }`
- `public Vehicle LastVehicle { get; }`
  - Gets the last `Vehicle` this `Ped` used.
- `public Vector3 LastWeaponImpactPosition { get; }`
- `public float LowerWetnessHeight { get; set; }`
- `public float LowerWetnessLevel { get; set; }`
- `public float MaxDrivingSpeed { set; }`
  - Sets the maximum driving speed this `Ped` can drive at.
- `public int MaxHealth { get; set; }`
  - Gets or sets the maximum health of this `Ped` as an `Int32`.
- `public Ped MeleeTarget { get; }`
- `public int Money { get; set; }`
  - **Obsolete.** Use Ped.MoneyCarried instead, which also removes the $65535 limit.
  - Gets or sets how much money this `Ped` is carrying.
- `public uint MoneyCarried { get; set; }`
- `public string MovementAnimationSet { set; }`
  - **Obsolete.** Use Ped.SetMovementClipSet or Ped.ResetMovementClipSet instead.
  - Sets the animation dictionary or set this `Ped` should use or `null` to clear it.
- `public PedMoveNetworkTaskInterface MoveNetworkTaskInterface { get; }`
- `public bool NeverLeavesGroup { get; set; }`
- `public ParachuteLandingType ParachuteLandingType { get; }`
- `public ParachuteState ParachuteState { get; }`
- `public PedConfigFlags PedConfigFlags { get; }`
- `public PedGroup PedGroup { get; }`
  - Gets the PedGroup this `Ped` is in.
- `public PedResetFlags PedResetFlags { get; }`
- `public PedType PedType { get; }`
- `public RelationshipGroup RelationshipGroup { get; set; }`
- `public VehicleSeat SeatIndex { get; }`
  - Gets the `VehicleSeat` this `Ped` is in.
- `public float SeeingRange { get; set; }`
- `public int ShootRate { set; }`
  - Sets the rate this `Ped` will shoot at.
- `public bool StaysInVehicleWhenJacked { get; set; }`
  - Sets a value indicating whether this `Ped` will stay in the vehicle when the driver gets jacked.
- `public Style Style { get; }`
  - Opens a list of clothing and prop configurations that this `Ped` can wear.
- `public float Sweat { get; set; }`
  - Gets or sets the how much sweat should be rendered on this `Ped`.
- `public TargetLossResponse TargetLossResponse { set; }`
- `public TaskInvoker Task { get; }`
  - Opens a list of `TaskInvoker` that this `Ped` can carry out.
- `public int TaskSequenceProgress { get; }`
  - Gets the stage of the `TaskSequence` this `Ped` is currently executing.
- `public int TimeOfDeath { get; }`
  - Gets the time when this `Ped` is killed. This value determines how this `Ped` is rendered when `IsThermalVisionActive` is `true` and the `Ped` is dead.
- `public float UpperWetnessHeight { get; set; }`
- `public float UpperWetnessLevel { get; set; }`
- `public VehicleDrivingFlags VehicleDrivingFlags { set; }`
- `public Vehicle VehicleTryingToEnter { get; }`
  - Gets the `Vehicle` this `Ped` is trying to enter.
- `public VehicleWeaponHash VehicleWeapon { get; set; }`
  - Gets the vehicle weapon this `Ped` is using. The vehicle weapon, returns `Invalid` if this `Ped` isnt using a vehicle weapon.
- `public float VisualFieldCenterAngle { get; set; }`
- `public float VisualFieldMaxAngle { get; set; }`
- `public float VisualFieldMaxElevationAngle { get; set; }`
- `public float VisualFieldMinAngle { get; set; }`
- `public float VisualFieldMinElevationAngle { get; set; }`
- `public float VisualFieldPeripheralRange { get; set; }`
- `public string Voice { set; }`
  - **Obsolete.** Use Ped.AmbientVoiceHash = StringHash.AtStringHash(value) instead.
  - Sets the voice to use when this `Ped` speaks.
- `public bool WasKilledByStealth { get; }`
  - Gets a value indicating whether this `Ped` was killed by a stealth attack.
- `public bool WasKilledByTakedown { get; }`
  - Gets a value indicating whether this `Ped` was killed by a takedown.
- `public WeaponCollection Weapons { get; }`
  - Gets a collection of all this `Ped`s `Weapon`s.
- `public float WetnessHeight { set; }`
  - **Obsolete.** Ped.WetnessHeight is obsolete because it does not indicate that it clears the wetness effect from the ped if the value is exactly zero,while the value can take any values in the range of -2f to 1.99f inclusive. Please use Ped.Wet or Ped.ClearWetnessEffect instead.
  - Sets how high up on this `Ped`s body water should be visible.
- `public static bool RandomPedsBlockingNonTempEventsThisFrame { set; }`

### Methods

- `public void ApplyBloodDamage(PedDamageZone zone, Vector2 position, PedBloodDamage bloodDamage, float rotation, float scale, int frameIndex = -1, float woundAge = 0)`
- `public void ApplyBloodDamage(PedDamageZone zone, Vector2 position, PedBloodDamage bloodDamage)`
- `public void ApplyBloodDamage(PedDamageZone zone, Vector3 position, PedBloodDamage bloodDamage)`
- `public void ApplyDamage(int damageAmount)`
- `public void ApplyRelativeForceCenterOfMass(Vector3 force, ForceType forceType, RagdollComponent component, bool scaleByMass, bool applyToChildren = false)`
- `public void ApplyRelativeForceRelativeOffset(Vector3 force, Vector3 offset, ForceType forceType, RagdollComponent component, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void ApplyRelativeForceWorldOffset(Vector3 force, Vector3 offset, ForceType forceType, RagdollComponent component, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void ApplyWorldForceCenterOfMass(Vector3 force, ForceType forceType, RagdollComponent component, bool scaleByMass, bool applyToChildren = false)`
- `public void ApplyWorldForceRelativeOffset(Vector3 force, Vector3 offset, ForceType forceType, RagdollComponent component, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void ApplyWorldForceWorldOffset(Vector3 force, Vector3 offset, ForceType forceType, RagdollComponent component, bool scaleByMass, bool triggerAudio = false, bool scaleByTimeScale = true)`
- `public void CancelRagdoll()`
- `public void ClearBloodDamage()`
- `public void ClearCauseOfDeathRecord()`
  - Clears the record of the cause of death that killed this `Ped` with. Can be useful after resurrecting this `Ped`. Internally, when a `Ped` killed and the value for the cause of death in the instance of this `Ped` is not `0`, the game does not write the weapon hash value for the cause of death.
- `public void ClearFacialIdleAnimationOverride()`
- `public void ClearKillerRecord()`
  - Clears the `Entity` record that killed this `Ped`. Can be useful after resurrecting this `Ped`. Internally, when a `Ped` killed and the value for the source of death in the instance of this `Ped` is not `0` (not `null`), the game does not write the memory address of the `Ped` that killed this `Ped`.
- `public virtual void ClearLastWeaponDamage()`
- `public void ClearRagdollBlockingFlags(RagdollBlockingFlags flags = 1)`
- `public void ClearTimeOfDeathRecord()`
  - Clears the time record when this `Ped` is killed. Can be useful after resurrecting this `Ped`. Internally, when a `Ped` killed and the value for the time of death in the instance of this `Ped` is not `0`, the game does not write the game time value for the time of death.
- `public void ClearVisibleDamage()`
- `public Ped Clone(bool linkBlends)`
  - Spawn an identical clone of this `Ped`.
  - `heading`: The direction the clone should be facing.
- `public Ped Clone(float heading = 0)`
  - **Obsolete.** `Ped.Clone(float)` is obsolete because the float parameter does not make any sense. Use `Ped.Clone(bool)` instead.
  - Spawn an identical clone of this `Ped`.
  - `heading`: The direction the clone should be facing.
- `public Ped CloneAlt(bool linkBlends = true, bool cloneCompressedDamage = true)`
- `public void CloneToTarget(Ped target)`
- `public void CloneToTargetAlt(Ped target, bool cloneCompressedDamage = true)`
- `public void DryOff()`
- `public bool Exists()`
  - Determines if this `Ped` exists. You should ensure `Ped`s still exist before manipulating them or getting some values for them on every tick, since some native functions may crash the game if invalid entity handles are passed.
  - Returns: `true` if this `Ped` exists; otherwise, `false`
- `public void FireVehicleWeaponAt(Entity target)`
- `public void FireVehicleWeaponAt(Vector3 target)`
- `public bool ForceMotionStateThisFrame(PedMotionState state, bool restartState = false, ForceAnimAIUpdateState exitState = 0, bool forceAIPreCameraUpdate = false)`
- `public float GetCombatFloatAttribute(CombatFloatAttributes attribute)`
- `public bool GetConfigFlag(PedConfigFlagToggles configFlagToggle)`
- `public bool GetConfigFlag(int flagID)`
  - **Obsolete.** Use GetConfigFlag(PedConfigFlagToggles) instead.
- `public void GetCurrentScriptTaskNameHashAndStatus(out ScriptTaskNameHash nameHash, out ScriptTaskStatus status)`
- `public NavMeshRouteResult GetNavMeshRouteResult()`
- `public Relationship GetRelationshipWithPed(Ped ped)`
- `public bool GetResetFlag(PedResetFlagToggles configFlag)`
- `public ScriptTaskStatus GetScriptTaskStatus(ScriptTaskNameHash taskNameHash)`
- `public void GiveHelmet(bool canBeRemovedByPed, Helmet helmetType, int textureIndex)`
  - **Obsolete.** Use Ped.GiveHelmet(bool, HelmetPropFlags, int) instead.
- `public void GiveHelmet(bool dontTakeOffHelmet = true, HelmetPropFlags helmetPropFlags = 4096, int overwriteHelmetTextureId = -1)`
- `public virtual bool HasBeenDamagedBy(WeaponHash weapon)`
- `public virtual bool HasBeenDamagedByAnyMeleeWeapon()`
- `public virtual bool HasBeenDamagedByAnyWeapon()`
- `public bool HasReceivedEvent(EventType eventType)`
- `public bool IsArmed(WeaponCheckFlags flags = 7)`
- `public bool IsHeadtracking(Entity entity)`
- `public bool IsInCombatAgainst(Ped target)`
- `public bool IsInVehicle()`
- `public bool IsInVehicle(Vehicle vehicle)`
- `public bool IsRespondingToEvent(EventType eventType)`
- `public bool IsSittingInVehicle()`
- `public bool IsSittingInVehicle(Vehicle vehicle)`
- `public bool IsStandingOnVehicle()`
- `public bool IsStandingOnVehicle(Vehicle vehicle)`
- `public void Kill()`
  - Kills this `Ped` immediately.
- `public void LeaveGroup()`
- `public void OpenParachute()`
- `public void PlayAmbientSpeech(string speechName, SpeechModifier modifier = 0)`
- `public void PlayAmbientSpeech(string context, string voiceName, SpeechModifier modifier, int variation = 0)`
- `public void PlayAmbientSpeech(string speechName, string voiceName, SpeechModifier modifier = 0)`
- `public void PlayFacialAnimation(CommonPedFacialAnimation anim)`
- `public void PlayFacialAnimation(CrClipAsset clipAsset)`
- `public void PlayFacialAnimation(string animName)`
- `public void Ragdoll(int duration = -1, RagdollType ragdollType = 0)`
  - Enables this `Ped`'s ragdoll by starting a ragdoll task and applying to this `Ped`. If `ragdollType` is not set to `Relax` or `ScriptControl`, the ragdoll behavior for `Balance` will be used.
- `public void RemoveHelmet(bool instantly)`
- `public void ResetConfigFlag(int flagID)`
  - **Obsolete.** Ped.ResetConfigFlag is obsolete since SET_PED_RESET_FLAG uses different flag IDs from the IDs GET_PED_CONFIG_FLAG and SET_PED_CONFIG_FLAG use and the said overload always set the flag (2nd argument of SET_PED_RESET_FLAG) to true. Use Ped.SetResetFlag or Ped.GetResetFlag instead
- `public void ResetMovementClipSet(AnimationBlendDuration? blendDuration = null)`
- `public void ResetStrafeClipSet()`
- `public void ResetWeaponMovementClipSet()`
- `public void Resurrect()`
  - Resurrects this `Ped` from death.
- `public void SetAsCop(bool setRelationshipGroup = true)`
- `public void SetCombatAttribute(CombatAttributes attribute, bool activeSkill)`
- `public void SetCombatFloatAttribute(CombatFloatAttributes attribute, float newValue)`
- `public void SetConfigFlag(PedConfigFlagToggles configFlagToggle, bool value)`
- `public void SetConfigFlag(int flagID, bool value)`
  - **Obsolete.** Use SetConfigFlag(PedConfigFlagToggles, bool) instead.
- `public void SetFacialClipset(ClipSet clipSet)`
- `public void SetFacialIdleAnimationOverride(CommonPedFacialAnimation anim)`
- `public void SetFacialIdleAnimationOverride(CrClipAsset clipAsset)`
- `public void SetFacialIdleAnimationOverride(string animName)`
- `public void SetFleeAttributes(FleeAttributes attributes, bool activeSkill)`
- `public void SetIKTarget(IKPart ikPart, Entity targetEntity, int boneTag, Vector3 targetOffset, IKTargetFlags flags, int blendInTimeMS = -1, int blendOutTimeMS = -1)`
- `public void SetIKTarget(IKPart ikPart, EntityBone targetBone, Vector3 targetOffset, IKTargetFlags flags, int blendInTimeMS = -1, int blendOutTimeMS = -1)`
- `public void SetIKTarget(IKPart ikPart, Vector3 target, IKTargetFlags flags, int blendInTimeMS = -1, int blendOutTimeMS = -1)`
- `public void SetIKTarget(IKPart ikPart, PedBone targetBone, Vector3 targetOffset, IKTargetFlags flags, int blendInTimeMS = -1, int blendOutTimeMS = -1)`
- `public void SetIntoVehicle(Vehicle vehicle, VehicleSeat seat)`
- `public void SetIsPersistentNoClearTask(bool value)`
  - Sets a value indicating whether this `Entity` is persistent. Unlike `IsPersistent`, calling this method does not affect assigned tasks.
- `public void SetMovementClipSet(ClipSet clipSet, AnimationBlendDuration? blendDuration = null)`
- `public void SetRagdollBlockingFlags(RagdollBlockingFlags flags = 1)`
- `public void SetResetFlag(PedResetFlagToggles configFlag, bool value)`
- `public void SetStrafeClipSet(ClipSet clipSet)`
- `public bool SetToRagdoll(int minTime, int maxTime, RagdollType ragdollType, bool forceScriptControl = false)`
- `public bool SetToRagdollWithFall(int minTime, int maxTime, RagdollFallType fallType, Vector3 direction, float groundHeight)`
- `public void SetVehicleChaseBehaviorFlags(VehicleChaseBehaviorFlags flags, bool value)`
- `public void SetVehicleChaseIdealPursuitDistance(float distance)`
- `public void SetWeaponMovementClipSet(ClipSet clipSet)`
- `public void SetWetnessEnabledThisFrame()`
- `public void StopCurrentPlayingAmbientSpeech()`
- `public void StopCurrentPlayingSpeech()`
- `public bool TrySetVehicleWeapon(VehicleWeaponHash hash)`
- `public void Wet(float height, float wetLevel)`
- `public void Wet(float height)`
- `public static Ped Create(Model model, Vector3 position, float heading = 0)`
- `public static Ped CreateRandom(Vector3 position, float heading, Func<Model, bool> predicate = null)`
- `public static Ped CreateRandom(Vector3 position)`
- `public static PedHash[] GetAllLoadedModelsAppropriateForAmbientPeds()`
  - Gets an `array` of all loaded `PedHash`s that is appropriate to spawn as ambient vehicles. The result array can contains animal hashes, which CREATE_RANDOM_PED excludes to spawn. All the model hashes of the elements are loaded and the `Ped`s with the model hashes can be spawned immediately.
- `public static PedHash[] GetAllModels()`

## PedBloodDamage

enum `GTA.PedBloodDamage`

| Name | Value |
| --- | --- |
| `BulletSmall` | 0 |
| `BulletLarge` | 1 |
| `ShotgunSmall` | 2 |
| `ShotgunSmallMonolithic` | 3 |
| `ShotgunLarge` | 4 |
| `NonFatalHeadshot` | 5 |
| `Stab` | 6 |
| `BasicSlash` | 7 |
| `BackSplash` | 8 |
| `ScriptedBackSplash` | 9 |

## PedBone

class `GTA.PedBone` : `EntityBone`

### Properties

- `public PedBone NextSibling { get; }`
- `public Ped Owner { get; }`
- `public PedBone Parent { get; }`
- `public Bone Tag { get; }`

## PedBoneCollection

class `GTA.PedBoneCollection` : `EntityBoneCollection`, `IEnumerable<EntityBone>`, `IEnumerable`, `IEnumerable<PedBone>`

### Properties

- `public PedBone Core { get; }`
  - Gets the core bone of this `Ped`.
- `public PedBone this[Bone boneId] { get; }`
  - Gets the `PedBone` with the specified `boneId`.
  - `boneId`: The bone Id.
- `public PedBone this[int boneIndex] { get; }`
  - Gets the `PedBone` at the specified bone index.
  - `boneIndex`: The bone index.
- `public PedBone this[string boneName] { get; }`
  - Gets the `PedBone` with the specified bone name.
  - `boneName`: Name of the bone.
- `public PedBone LastDamaged { get; }`
  - Gets the last damaged bone for this `Ped`.

### Methods

- `public void ClearLastDamaged()`
  - Clears the last damage a bone on this `Ped` received.
- `public IEnumerator<PedBone> GetEnumerator()`

## PedBoneCollection.Enumerator

class `GTA.PedBoneCollection.Enumerator` : `IEnumerator<PedBone>`, `IDisposable`, `IEnumerator`

### Constructors

- `public Enumerator(PedBoneCollection collection)`

### Properties

- `public PedBone Current { get; }`

### Methods

- `public bool MoveNext()`
- `public void Reset()`

## PedComponent

class `GTA.PedComponent` : `IPedVariation`

### Properties

- `public int Count { get; }`
- `public bool HasAnyVariations { get; }`
  - **Obsolete.** PedComponent.HasAnyVariation is obsolete because it does not make sense as texture count cannot be determined without specifying both component id and drawable id.
- `public bool HasTextureVariations { get; }`
  - **Obsolete.** PedComponent.HasTextureVariations is obsolete because it does not make sense as texture count cannot be determined without specifying both component id and drawable id.
- `public bool HasVariations { get; }`
- `public int Index { get; set; }`
- `public string Name { get; }`
- `public int TextureCount { get; }`
- `public int TextureIndex { get; set; }`
- `public PedComponentType Type { get; }`

### Methods

- `public bool IsVariationValid(int index, int textureIndex = 0)`
- `public bool SetVariation(int index, int textureIndex = 0)`
- `public virtual string ToString()`

## PedComponentType

enum `GTA.PedComponentType`

| Name | Value |
| --- | --- |
| `Face` | 0 |
| `Head` | 1 |
| `Hair` | 2 |
| `Torso` | 3 |
| `Legs` | 4 |
| `Hands` | 5 |
| `Shoes` | 6 |
| `Special1` | 7 |
| `Special2` | 8 |
| `Special3` | 9 |
| `Textures` | 10 |
| `Torso2` | 11 |

## PedConfigFlags

class `GTA.PedConfigFlags`

### Properties

- `public KnockOffVehicleType KnockOffVehicleType { get; set; }`
- `public VehicleSeat PassengerIndexToUseInAGroup { get; set; }`
- `public PedLegIKMode PedLegIKMode { get; set; }`

### Methods

- `public bool GetConfigFlag(PedConfigFlagToggles configFlagToggle)`
- `public void SetConfigFlag(PedConfigFlagToggles configFlagToggle, bool value)`

## PedConfigFlagToggles

enum `GTA.PedConfigFlagToggles`

460 values:

```text
CreatedByFactory = 0
CanBeShotInVehicle = 1
NoCriticalHits = 2
DrownsInWater = 3
DrownsInSinkingVehicle = 4
DiesInstantlyWhenSwimming = 5
HasBulletProofVest = 6
UpperBodyDamageAnimsOnly = 7
NeverFallOffSkis = 8
NeverEverTargetThisPed = 9
ThisPedIsATargetPriority = 10
TargettableWithNoLos = 11
DoesntListenToPlayerGroupCommands = 12
NeverLeavesGroup = 13
DoesntDropWeaponsWhenDead = 14
SetDelayedWeaponAsCurrent = 15
KeepTasksAfterCleanUp = 16
BlockNonTemporaryEvents = 17
HasAScriptBrain = 18
WaitingForScriptBrainToLoad = 19
AllowMedicsToReviveMe = 20
MoneyHasBeenGivenByScript = 21
NotAllowedToCrouch = 22
DeathPickupsPersist = 23
IgnoreSeenMelee = 24
ForceDieIfInjured = 25
DontDragMeOutCar = 26
StayInCarOnJack = 27
ForceDieInCar = 28
GetOutUndriveableVehicle = 29
WillRemainOnBoatAfterMissionEnds = 30
DontStoreAsPersistent = 31
WillFlyThroughWindscreen = 32
DieWhenRagdoll = 33
HasHelmet = 34
UseHelmet = 35
DontTakeOffHelmet = 36
HideInCutscene = 37
PedIsEnemyToPlayer = 38
DisableEvasiveDives = 39
PedGeneratesDeadBodyEvents = 40
DontAttackPlayerWithoutWantedLevel = 41
DontInfluenceWantedLevel = 42
DisablePlayerLockOn = 43
DisableLockOnToRandomPeds = 44
AllowLockOnToFriendlyPlayers = 45
DisableHornAudioWhenDead = 46
PedBeingDeleted = 47
BlockWeaponSwitching = 48
BlockGroupPedAimedAtResponse = 49
WillFollowLeaderAnyMeans = 50
BlippedByScript = 51
DrawRadarVisualField = 52
StopWeaponFiringOnImpact = 53
DisableAutoFallOffTests = 54
SteerAroundDeadBodies = 55
ConstrainToNavMesh = 56
SyncingAnimatedProps = 57
IsFiring = 58
WasFiring = 59
IsStanding = 60
WasStanding = 61
InVehicle = 62
OnMount = 63
AttachedToVehicle = 64
IsSwimming = 65
WasSwimming = 66
IsSkiing = 67
IsSitting = 68
KilledByStealth = 69
KilledByTakedown = 70
KnockedOut = 71
ClearRadarBlipOnDeath = 72
JustGotOffTrain = 73
JustGotOnTrain = 74
UsingCoverPoint = 75
IsInTheAir = 76
KnockedUpIntoAir = 77
IsAimingGun = 78
HasJustLeftCar = 79
TargetWhenInjuredAllowed = 80
CurrLeftFootCollNM = 81
PrevLeftFootCollNM = 82
CurrRightFootCollNM = 83
PrevRightFootCollNM = 84
HasBeenBumpedInCar = 85
InWaterTaskQuitToClimbLadder = 86
NMTwoHandedWeaponBothHandsConstrained = 87
CreatedBloodPoolTimer = 88
DontActivateRagdollFromAnyPedImpact = 89
GroupPedFailedToEnterCover = 90
AlreadyChattedOnPhone = 91
AlreadyReactedToPedOnRoof = 92
ForcePedLoadCover = 93
BlockCoweringInCover = 94
BlockPeekingInCover = 95
JustLeftCarNotCheckedForDoors = 96
VaultFromCover = 97
AutoConversationLookAts = 98
UsingCrouchedPedCapsule = 99
HasDeadPedBeenReported = 100
ForcedAim = 101
SteersAroundPeds = 102
SteersAroundObjects = 103
OpenDoorArmIK = 104
ForceReload = 105
DontActivateRagdollFromVehicleImpact = 106
DontActivateRagdollFromBulletImpact = 107
DontActivateRagdollFromExplosions = 108
DontActivateRagdollFromFire = 109
DontActivateRagdollFromElectrocution = 110
IsBeingDraggedToSafety = 111
HasBeenDraggedToSafety = 112
KeepWeaponHolsteredUnlessFired = 113
ForceScriptControlledKnockout = 114
FallOutOfVehicleWhenKilled = 115
GetOutBurningVehicle = 116
BumpedByPlayer = 117
RunFromFiresAndExplosions = 118
TreatAsPlayerDuringTargeting = 119
IsHandcuffed = 120
IsAnkleCuffed = 121
DisableMelee = 122
DisableUnarmedDriveBys = 123
JustGetsPulledOutWhenElectrocuted = 124
WillNotHotwireLawEnforcementVehicle = 126
WillCommandeerRatherThanJack = 127
CanBeAgitated = 128
ForcePedToFaceLeftInCover = 129
ForcePedToFaceRightInCover = 130
BlockPedFromTurningInCover = 131
KeepRelationshipGroupAfterCleanUp = 132
ForcePedToBeDragged = 133
PreventPedFromReactingToBeingJacked = 134
IsScuba = 135
WillArrestRatherThanJack = 136
RemoveDeadExtraFarAway = 137
RidingTrain = 138
ArrestResult = 139
CanAttackFriendly = 140
WillJackAnyPlayer = 141
BumpedByPlayerVehicle = 142
DodgedPlayerVehicle = 143
WillJackWantedPlayersRatherThanStealCar = 144
NoCopWantedAggro = 145
DisableLadderClimbing = 146
StairsDetected = 147
SlopeDetected = 148
HelmetHasBeenShot = 149
CowerInsteadOfFlee = 150
CanActivateRagdollWhenVehicleUpsideDown = 151
AlwaysRespondToCriesForHelp = 152
DisableBloodPoolCreation = 153
ShouldFixIfNoCollision = 154
CanPerformArrest = 155
CanPerformUncuff = 156
CanBeArrested = 157
MoverConstrictedByOpposingCollisions = 158
PlayerPreferFrontSeatMP = 159
DontActivateRagdollFromImpactObject = 160
DontActivateRagdollFromMelee = 161
DontActivateRagdollFromWaterJet = 162
DontActivateRagdollFromDrowning = 163
DontActivateRagdollFromFalling = 164
DontActivateRagdollFromRubberBullet = 165
IsInjured = 166
DontEnterVehiclesInPlayersGroup = 167
SwimmingTasksRunning = 168
PreventAllMeleeTaunts = 169
ForceDirectEntry = 170
AlwaysSeeApproachingVehicles = 171
CanDiveAwayFromApproachingVehicles = 172
AllowPlayerToInterruptVehicleEntryExit = 173
OnlyAttackLawIfPlayerIsWanted = 174
PlayerInContactWithKinematicPed = 175
PlayerInContactWithSomethingOtherThanKinematicPed = 176
PedsJackingMeDontGetIn = 177
AdditionalRappellingPed = 178
PedIgnoresAnimInterruptEvents = 179
IsInCustody = 180
ForceStandardBumpReactionThresholds = 181
LawWillOnlyAttackIfPlayerIsWanted = 182
IsAgitated = 183
PreventAutoShuffleToDriversSeat = 184
UseKinematicModeWhenStationary = 185
EnableWeaponBlocking = 186
HasHurtStarted = 187
DisableHurt = 188
PlayerIsWeird = 189
PedHadPhoneConversation = 190
BeganCrossingRoad = 191
WarpIntoLeadersVehicle = 192
DoNothingWhenOnFootByDefault = 193
UsingScenario = 194
VisibleOnScreen = 195
DontCollideWithKinematic = 196
ActivateOnSwitchFromLowPhysicsLod = 197
DontActivateRagdollOnPedCollisionWhenDead = 198
DontActivateRagdollOnVehicleCollisionWhenDead = 199
HasBeenInArmedCombat = 200
UseDiminishingAmmoRate = 201
AvoidanceIgnoreAll = 202
AvoidanceIgnoredByAll = 203
AvoidanceIgnoreGroup1 = 204
AvoidanceMemberOfGroup1 = 205
ForcedToUseSpecificGroupSeatIndex = 206
LowPhysicsLodMayPlaceOnNavMesh = 207
DisableExplosionReactions = 208
DodgedPlayer = 209
WaitingForPlayerControlInterrupt = 210
ForcedToStayInCover = 211
GeneratesSoundEvents = 212
ListensToSoundEvents = 213
AllowToBeTargetedInAVehicle = 214
WaitForDirectEntryPointToBeFreeWhenExiting = 215
OnlyRequireOnePressToExitVehicle = 216
ForceExitToSkyDive = 217
SteersAroundVehicles = 218
AllowPedInVehiclesOverrideTaskFlags = 219
DontEnterLeadersVehicle = 220
DisableExitToSkyDive = 221
ScriptHasDisabledCollision = 222
UseAmbientModelScaling = 223
DontWatchFirstOnNextHurryAway = 224
DisablePotentialToBeWalkedIntoResponse = 225
DisablePedAvoidance = 226
ForceRagdollUponDeath = 227
CanLosePropsOnDamage = 228
DisablePanicInVehicle = 229
AllowedToDetachTrailer = 230
HasShotBeenReactedToFromFront = 231
HasShotBeenReactedToFromBack = 232
HasShotBeenReactedToFromLeft = 233
HasShotBeenReactedToFromRight = 234
AllowBlockDeadPedRagdollActivation = 235
IsHoldingProp = 236
BlocksPathingWhenDead = 237
ForcePlayNormalScenarioExitOnNextScriptCommand = 238
ForcePlayImmediateScenarioExitOnNextScriptCommand = 239
ForceSkinCharacterCloth = 240
LeaveEngineOnWhenExitingVehicles = 241
PhoneDisableTextingAnimations = 242
PhoneDisableTalkingAnimations = 243
PhoneDisableCameraAnimations = 244
DisableBlindFiringInShotReactions = 245
AllowNearbyCoverUsage = 246
InStrafeTransition = 247
CanPlayInCarIdles = 248
CanAttackNonWantedPlayerAsLaw = 249
WillTakeDamageWhenVehicleCrashes = 250
AICanDrivePlayerAsRearPassenger = 251
PlayerCanJackFriendlyPlayers = 252
OnStairs = 253
SimulatingAiming = 254
AIDriverAllowFriendlyPassengerSeatEntry = 255
ParentCarIsBeingRemoved = 256
AllowMissionPedToUseInjuredMovement = 257
CanLoseHelmetOnDamage = 258
NeverDoScenarioExitProbeChecks = 259
SuppressLowLodRagdollSwitchWhenCorpseSettles = 260
PreventUsingLowerPrioritySeats = 261
JustLeftVehicleNeedsReset = 262
TeleportIfCantReachPlayer = 263
PedsInVehiclePositionNeedsReset = 264
PedsFullyInSeat = 265
AllowPlayerLockOnIfFriendly = 266
UseCameraHeadingForDesiredDirectionLockOnTest = 267
TeleportToLeaderVehicle = 268
AvoidanceIgnoreWeirdPedBuffer = 269
OnStairSlope = 270
HasPlayedNMGetup = 271
DontBlipCop = 272
SpawnedAtExtendedRangeScenario = 273
WalkAlongsideLeaderWhenClose = 274
KillWhenTrapped = 275
EdgeDetected = 276
AlwaysWakeUpPhysicsOfIntersectedPeds = 277
EquippedAmbientLoadOutWeapon = 278
AvoidTearGas = 279
StoppedSpeechUponFreezing = 280
DisableGoToWritheWhenInjured = 281
OnlyUseForcedSeatWhenEnteringHeliInGroup = 282
ThrownFromVehicleDueToExhaustion = 283
UpdateEnclosedSearchRegion = 284
DisableWeirdPedEvents = 285
ShouldChargeNow = 286
RagdollingOnBoat = 287
HasBrandishedWeapon = 288
AllowMinorReactionsAsMissionPed = 289
BlockDeadBodyShockingEventsWhenDead = 290
PedHasBeenSeen = 291
PedIsInReusePool = 292
PedWasReused = 293
DisableShockingEvents = 294
MovedUsingLowLodPhysicsSinceLastActive = 295
NeverReactToPedOnRoof = 296
ForcePlayFleeScenarioExitOnNextScriptCommand = 297
JustBumpedIntoVehicle = 298
DisableShockingDrivingOnPavementEvents = 299
ShouldThrowSmokeNow = 300
DisablePedConstraints = 301
ForceInitialPeekInCover = 302
CreatedByDispatch = 303
PointGunLeftHandSupporting = 304
DisableJumpingFromVehiclesAfterLeader = 305
DontActivateRagdollFromPlayerPedImpact = 306
DontActivateRagdollFromAiRagdollImpact = 307
DontActivateRagdollFromPlayerRagdollImpact = 308
DisableQuadrupedSpring = 309
IsInCluster = 310
ShoutToGroupOnPlayerMelee = 311
IgnoredByAutoOpenDoors = 312
PreferInjuredGetup = 313
ForceIgnoreMeleeActiveCombatant = 314
CheckLoSForSoundEvents = 315
JackedAbandonedCar = 316
CanSayFollowedByPlayerAudio = 317
ActivateRagdollFromMinorPlayerContact = 318
HasPortablePickupAttached = 319
ForcePoseCharacterCloth = 320
HasClothCollisionBounds = 321
HasHighHeels = 322
TreatAsAmbientPedForDriverLockOn = 323
DontBehaveLikeLaw = 324
SpawnedAtScenario = 325
DisablePoliceInvestigatingBody = 326
DisableWritheShootFromGround = 327
LowerPriorityOfWarpSeats = 328
DisableTalkTo = 329
DontBlip = 330
IsSwitchingWeapon = 331
IgnoreLegIkRestrictions = 332
ScriptForceNoTimesliceIntelligenceUpdate = 333
JackedOutOfMyVehicle = 334
WentIntoCombatAfterBeingJacked = 335
DontActivateRagdollForVehicleGrab = 336
ForcePackageCharacterCloth = 337
DontRemoveWithValidOrder = 338
AllowTaskDoNothingTimeslicing = 339
ForcedToStayInCoverDueToPlayerSwitch = 340
ForceProneCharacterCloth = 341
NotAllowedToJackAnyPlayers = 342
InToStrafeTransition = 343
KilledByStandardMelee = 344
AlwaysLeaveTrainUponArrival = 345
ForcePlayDirectedNormalScenarioExitOnNextScriptCommand = 346
OnlyWritheFromWeaponDamage = 347
UseSloMoBloodVfx = 348
EquipJetpack = 349
PreventDraggedOutOfCarThreatResponse = 350
ScriptHasCompletelyDisabledCollision = 351
NeverDoScenarioNavChecks = 352
ForceSynchronousScenarioExitChecking = 353
ThrowingGrenadeWhileAiming = 354
HeadbobToRadioEnabled = 355
ForceDeepSurfaceCheck = 356
DisableDeepSurfaceAnims = 357
DontBlipNotSynced = 358
IsDuckingInVehicle = 359
PreventAutoShuffleToTurretSeat = 360
DisableEventInteriorStatusCheck = 361
HasReserveParachute = 362
UseReserveParachute = 363
TreatDislikeAsHateWhenInCombat = 364
OnlyUpdateTargetWantedIfSeen = 365
AllowAutoShuffleToDriversSeat = 366
DontActivateRagdollFromSmokeGrenade = 367
LinkMbrToOwnerOnChain = 368
AmbientFriendBumpedByPlayer = 369
AmbientFriendBumpedByPlayerVehicle = 370
InFpsUnholsterTransition = 371
PreventReactingToSilencedCloneBullets = 372
DisableInjuredCryForHelpEvents = 373
NeverLeaveTrain = 374
DontDropJetpackOnDeath = 375
UseFpsUnholsterTransitionDuringCombatRoll = 376
ExitingFpsCombatRoll = 377
ScriptHasControlOfPlayer = 378
PlayFpsIdleFidgetsForProjectile = 379
DisableAutoEquipHelmetsInBikes = 380
DisableAutoEquipHelmetsInAircraft = 381
WasPlayingFpsGetup = 382
WasPlayingFpsMeleeActionResult = 383
PreferNoPriorityRemoval = 384
FpsFidgetsAbortedOnFire = 385
ForceFpsIKWithUpperBodyAnim = 386
SwitchingCharactersInFirstPerson = 387
IsClimbingLadder = 388
HasBareFeet = 389
GoOnWithoutVehicleIfItIsUnableToGetBackToRoad = 391
BlockDroppingHealthSnacksOnDeath = 392
ResetLastVehicleOnVehicleExit = 393
ForceThreatResponseToNonFriendToFriendMeleeActions = 394
DontRespondToRandomPedsDamage = 395
AllowContinuousThreatResponseWantedLevelUpdates = 396
KeepTargetLossResponseOnCleanup = 397
PlayersDontDragMeOutOfCar = 398
BroadcastRespondedToThreatWhenGoingToPointShooting = 399
IgnorePedTypeForIsFriendlyWith = 400
TreatNonFriendlyAsHateWhenInCombat = 401
DontLeaveVehicleIfLeaderNotInVehicle = 402
ChangeFromPermanentToAmbientPopTypeOnMigration = 403
AllowMeleeReactionIfMeleeProofIsOn = 404
UsingLowriderLeans = 405
UsingAlternateLowriderLeans = 406
UseNormalExplosionDamageWhenBlownUpInVehicle = 407
DisableHomingMissileLockForVehiclePedInside = 408
DisableTakeOffScubaGear = 409
IgnoreMeleeFistWeaponDamageMult = 410
LawPedsCanFleeFromNonWantedPlayer = 411
ForceBlipSecurityPedsIfPlayerIsWanted = 412
IsHolsteringWeapon = 413
UseGoToPointForScenarioNavigation = 414
DontClearLocalPassengersWantedLevel = 415
BlockAutoSwapOnWeaponPickups = 416
ThisPedIsATargetPriorityForAI = 417
IsSwitchingHelmetVisor = 418
ForceHelmetVisorSwitch = 419
IsPerformingVehicleMelee = 420
UseOverrideFootstepPtFx = 421
DisableVehicleCombat = 422
TreatAsFriendlyForTargetingAndDamage = 423
AllowBikeAlternateAnimations = 424
TreatAsFriendlyForTargetingAndDamageNonSynced = 425
UseLockpickVehicleEntryAnimations = 426
IgnoreInteriorCheckForSprinting = 427
SwatHeliSpawnWithinLastSpottedLocation = 428
DisableStartEngine = 429
IgnoreBeingOnFire = 430
DisableTurretOrRearSeatPreference = 431
DisableWantedHelicopterSpawning = 432
UseTargetPerceptionForCreatingAimedAtEvents = 433
DisableHomingMissileLockon = 434
ForceIgnoreMaxMeleeActiveSupportCombatants = 435
StayInDefensiveAreaWhenInVehicle = 436
DontShoutTargetPosition = 437
DisableHelmetArmor = 438
CreatedByConcealedPlayer = 439
PermanentlyDisablePotentialToBeWalkedIntoResponse = 440
PreventVehExitDueToInvalidWeapon = 441
IgnoreNetSessionFriendlyFireCheckForAllowDamage = 442
DontLeaveCombatIfTargetPlayerIsAttackedByPolice = 443
CheckLockedBeforeWarp = 444
DontShuffleInVehicleToMakeRoom = 445
GiveWeaponOnGetup = 446
DontHitVehicleWithProjectiles = 447
DisableForcedEntryForOpenVehiclesFromTryLockedDoor = 448
FiresDummyRockets = 449
PedIsArresting = 450
IsDecoyPed = 451
HasEstablishedDecoy = 452
BlockDispatchedHelicoptersFromLanding = 453
DontCryForHelpOnStun = 454
HitByTranqWeapon = 455
CanBeIncapacitated = 456
ForcedAimFromArrest = 457
DontChangeTargetFromMelee = 458
DisableHealthRegenerationWhenStunned = 459
RagdollFloatsIndefinitely = 460
BlockElectricWeaponDamage = 461
```

## PedDamageZone

enum `GTA.PedDamageZone`

| Name | Value |
| --- | --- |
| `Torso` | 0 |
| `Head` | 1 |
| `LeftArm` | 2 |
| `RightArm` | 3 |
| `LeftLeg` | 4 |
| `RightLeg` | 5 |
| `Medals` | 6 |

## PedGroup

class `GTA.PedGroup` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`, `IEnumerable<Ped>`, `IEnumerable`, `IDisposable`

### Constructors

- `public PedGroup()`
- `public PedGroup(int handle)`

### Properties

- `public Formation Formation { set; }`
- `public bool HasLeader { get; }`
- `public Ped Leader { get; }`
- `public int MemberCount { get; }`
- `public float SeparationRange { set; }`

### Methods

- `public void Add(Ped ped, bool leader)`
- `public bool Contains(Ped ped)`
- `public virtual void Delete()`
  - Removes this `PedGroup`.
- `public void Dispose()`
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same group as this `PedGroup`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same group as this `PedGroup`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `PedGroup` exists.
  - Returns: `true` if this `PedGroup` exists; otherwise, `false`.
- `public IEnumerator<Ped> GetEnumerator()`
- `public virtual int GetHashCode()`
- `public Ped GetMember(int index)`
- `public void Remove(Ped ped)`
- `public void ResetFormationSpacing()`
- `public void SetFormationSpacing(float spacing, float adjustSpeedMinDistance = -1, float adjustSpeedMaxDistance = -1)`
- `public Ped[] ToArray(bool includingLeader = true)`
- `public List<Ped> ToList(bool includingLeader = true)`
- `public static bool op_Equality(PedGroup left, PedGroup right)`
  - Determines if two `PedGroup`s refer to the same group.
  - `left`: The left `Checkpoint`.
  - `right`: The right `Checkpoint`.
  - Returns: `true` if `left` is the same group as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(PedGroup value)`
  - Converts a `PedGroup` to a native input argument.
- `public static bool op_Inequality(PedGroup left, PedGroup right)`
  - Determines if two `PedGroup`s don't refer to the same group.
  - `left`: The left `PedGroup`.
  - `right`: The right `PedGroup`.
  - Returns: `true` if `left` is not the same group as `right`; otherwise, `false`.

## PedGroup.Enumerator

class `GTA.PedGroup.Enumerator` : `IEnumerator<Ped>`, `IDisposable`, `IEnumerator`

### Constructors

- `public Enumerator(PedGroup group)`

### Properties

- `public Ped Current { get; }`

### Methods

- `public bool MoveNext()`
- `public void Reset()`

## PedHash

enum `GTA.PedHash`

1053 values:

```text
Michael = 225514697
Franklin = 2602752943
Franklin02 = 2937109846
Trevor = 2608926626
Abigail = 1074457665
AcidLabCook = 4185372713
Agatha = 1855569864
Agent = 610988552
Agent02 = 1183124263
Agent14 = 4227433577
AhronWard = 927014855
AmandaTownley = 1830688247
Andreas = 1206185632
ARY = 3473698871
ARY02 = 2275358319
Ashley = 2129936603
AviSchwartzman = 939183526
AviSchwartzman02 = 3735478533
AviSchwartzman03 = 2100370963
Avery = 3088269167
Avon = 4242698434
BallasLeader = 3678516463
Ballasog = 2802535058
Bankman = 2426248831
Barry = 797459875
Benny = 3300333010
Benny02 = 1943113851
Bestmen = 1464257942
Beverly = 3181518428
Billionaire = 28135809
Brad = 3183167778
Bride = 1633872967
Brucie2 = 3893268832
CallGirl01 = 2872523215
CallGirl02 = 2450524033
Car3Guy1 = 2230970679
Car3Guy2 = 1975732938
Casey = 3774489940
Celeb01 = 3676106820
CharlieReed = 1818503341
Chef = 1240128502
Chef2 = 2240322243
Chef3 = 4138965971
Clay = 1825562762
Claypain = 2634057640
Cletus = 3865252245
CrisFormage = 678319271
Dale = 1182012905
DaveNorton = 365775923
Dax = 4050142444
Denise = 2181772221
Devin = 1952555184
Dix = 4207997581
DJBlaMadon = 4219210853
DJBlamRupert = 914073350
DJBlamRyanH = 400495475
DJBlamRyanS = 3057799231
DJDixManager = 4221366718
DJGeneric01 = 2580849741
DJSolFotios = 1241432569
DJSolJakob = 2486302027
DJSolManager = 2123514453
DJSolMike = 795497466
DJSolRobT = 1194880004
DJTalAurelia = 2972453492
DJTalIgnazio = 2787461577
DoaMan = 1646160893
Dom = 2620240008
Dreyfuss = 3666413874
DrFriedlander = 3422293493
DrFriedlander2 = 2692738449
DrugDealer = 520923037
EdToh = 712602007
EnglishDave = 205318924
EnglishDave02 = 905946442
EntourageA = 435539666
EntourageB = 3362171829
Fabien = 3499148112
FbiSuit01 = 988062523
Floyd = 2981205682
Fooliganz1 = 3809717386
Fooliganz2 = 944592636
Furry = 1344679353
G = 2216405299
GeorginaCheng = 4014713647
GolferA = 1067129421
GolferB = 1858893999
Groom = 4274948997
GunVanSeller = 1520835918
Gustavo = 3045437975
Hao = 1704428387
Hao02 = 4035146080
HelmsmanPavel = 3619807921
HippyLeader = 2017183759
Huang = 3218252083
Hunter = 3457361118
Imani = 772427594
IslandDJ00 = 3802345064
IslandDJ01 = 1866942414
IslandDJ02 = 1562223483
IslandDJ03 = 322310057
IslandDJ04 = 2154719772
IslandDJ04D01 = 2979249514
IslandDJ04D02 = 4260779566
IslandDJ04E01 = 590182749
Jackie = 2040422902
JamalAmir = 1011548258
Janet = 225287241
Jaywalker = 1283622549
JayNorris = 2050158196
Jewelass = 257763003
JimmyBoston = 3986688045
JimmyBoston02 = 1135976220
JimmyDisanto = 1459905209
JimmyDiSanto2 = 2217591510
JIO = 1937203007
JIO02 = 3494374974
JoeMinuteman = 3189787803
JohnnyGuns = 658984954
JohnnyKlebitz = 2278195374
Josef = 3776618420
Josh = 2040438510
JuanStrickler = 507392637
KarenDaniels = 3948009817
Kaylee = 2810251555
KerryMcintosh = 1530648845
KerryMcIntosh02 = 3628252818
Labrat = 2682084818
LaceyJones02 = 3426139884
LamarDavis = 1706635382
LamarDavis02 = 421830750
Lazlow = 3756278757
Lazlow2 = 2231650028
LesterCrest = 1302784073
LesterCrest2 = 1849883942
LesterCrest3 = 2013139108
Lifeinvad01 = 1401530684
Lifeinvad02 = 666718676
LilDee = 3356359010
Luchadora = 4163779209
Magenta = 4242313482
Malc = 4055673113
Manuel = 4248931856
Marnie = 411185872
MaryAnn = 2741999622
MasonDuggan = 1224757029
Maude = 1005070462
Mechanic01 = 482489509
Mechanic02 = 1590147279
Michelle = 3214308084
MiguelMadrazo = 2781707480
Milton = 3408943538
Mimi = 2018483349
MJO = 761115490
MJO02 = 952584644
Molly = 2936266209
Moodyman02 = 2547074227
MrK = 3990661997
MrsPhillips = 946007720
MrsR = 2642001958
MrsThornhill = 503621995
Musician00 = 595139263
Natalia = 3726105915
NervousRon = 3170921201
NervousRon2 = 74809322
Nigel = 3367442045
OldMan1a = 1906124788
OldMan2 = 4011150407
OldRichGuy = 1006915658
Omega = 1625728984
ONeil = 768005095
Orleans = 1641334641
Ortega = 648372919
Paper = 2577072326
PartyPromo = 2243470389
Patricia = 3312325004
Patricia02 = 3272690865
PernellMoss = 2239793254
Pilot = 2253313678
Pilot02 = 183230355
Popov = 645279998
Paige = 357551935
Priest = 1681385341
PrologueDriver = 2237544099
PrologueSec01 = 1888624839
PrologueSec02 = 666086773
RampGang = 3845001836
RampHic = 1165307954
RampHipster = 3740245870
RampMex = 3870061732
Rashkovsky = 940330470
ReqOfficer = 3944177684
RoccoPelosi = 3585757951
RoosterMcCraw = 2086307585
RussianDrunk = 1024089777
Sacha = 1476581877
ScreenWriter = 4293277303
SecurityA = 793664635
Sessanta = 924556713
SiemonYetarian = 1283141381
Sol = 3786117468
Solomon = 2260598310
SoundEng00 = 3661356520
SSS = 991486725
SteveHains = 941695432
Stretch = 915948376
SubCrewHead = 3801918077
TalCC = 3828621987
Talina = 3885222120
TalMM = 1182156569
Tanisha = 226559113
TaoCheng = 3697041061
TaoCheng2 = 1506159504
TaosTranslator = 2089096292
TaosTranslator2 = 3828553631
TennisCoach = 2721800023
Terry = 1728056212
Thornton = 2482949079
TomCasino = 55858852
TomEpsilon = 3447159466
Tonya = 3402126148
TonyPrince = 761829301
TracyDisanto = 3728026165
TrafficWarden = 1461287021
TylerDixon = 1382414087
TylerDixon02 = 1511543927
VagosLeader = 2205902046
VagosSpeak = 4194109068
Vernon = 3451031970
Vincent = 736659122
Vincent2 = 197443027
Vincent3 = 363712933
Vincent4 = 1764259993
Wade = 2459507570
WeiCheng = 2867128955
Wendy = 1850188817
YusufAmir = 1608114028
Zimbor = 188012277
AbigailCutscene = 2306246977
AgathaCutscene = 756308504
AgentCutscene = 3614493108
Agent14Cutscene = 1841036427
AlanJeromeCutscene = 1925887591
AmandaTownleyCutscene = 2515474659
AndreasCutscene = 3881194279
AnitaCutscene = 117698822
AntonCutscene = 2781317046
ARYCutscene = 3059505486
ARY02Cutscene = 3927407837
AshleyCutscene = 650367097
AveryCutscene = 1427949869
AvonCutscene = 406009421
AviSchwartzmanCutscene = 2560490906
AviSchwartzman02Cutscene = 2315189472
AviSchwartzman03Cutscene = 399022197
BallasLeaderCutscene = 3098086931
BallasogCutscene = 2884567044
BankmanCutscene = 2539657518
BarryCutscene = 1767447799
BeverlyCutscene = 3027157846
BillionaireCutscene = 3397673303
BogdanCutscene = 1594283837
BradCutscene = 4024807398
BradCadaverCutscene = 1915268960
BrideCutscene = 2193587873
Brucie2Cutscene = 3361779221
BryonyCutscene = 2006035933
BurgerDrugCutscene = 2363277399
CallGirl01Cutscene = 1613083234
CallGirl02Cutscene = 779177722
Car3Guy1Cutscene = 71501447
Car3Guy2Cutscene = 327394568
CarBuyerCutscene = 2362341647
CaseyCutscene = 3935738944
Celeb01Cutscene = 592225333
CharlieReedCutscene = 10366540
ChefCutscene = 2739391114
Chef2Cutscene = 2925257274
Chef3Cutscene = 2229008065
ChinGoonCutscene = 2831296918
ClayCutscene = 3687553076
CletusCutscene = 3404326357
CopCutscene = 2595446627
CrisFormageCutscene = 3253960934
CustomerCutscene = 2756669323
DaleCutscene = 216536661
DaveNortonCutscene = 2240226444
DaxCutscene = 1117614067
DebraCutscene = 3973074921
DeniseCutscene = 1870669624
DeniseFriendCutscene = 3045926185
DevinCutscene = 788622594
DixCutscene = 3957337349
DJBlaMadonCutscene = 1835399538
DomCutscene = 1198698306
DreyfussCutscene = 1012965715
DrFriedlanderCutscene = 2745392175
DrFriedlander2Cutscene = 3177620756
DrugDealerCutscene = 949115134
EnglishDaveCutscene = 3533210174
EnglishDave02Cutscene = 3713623407
FabienCutscene = 1191403201
FbiSuit01Cutscene = 1482427218
FloydCutscene = 103106535
FosRepCutscene = 466359675
GCutscene = 2727244247
GeorginaChengCutscene = 345107131
GolferACutscene = 2120159624
GolferBCutscene = 3706572452
GroomCutscene = 2058033618
GroveStrDlrCutscene = 3898166818
GuadalopeCutscene = 261428209
GurkCutscene = 3272931111
GustavoCutscene = 2331262242
HaoCutscene = 3969814300
Hao02Cutscene = 3211915155
HelmsmanPavelCutscene = 2675868152
HuangCutscene = 1064198787
HughCutscene = 1863555924
HunterCutscene = 1531218220
ImaniCutscene = 1987160310
ImranCutscene = 3812756443
IslandDJ00Cutscene = 2053038501
IslandDJ01Cutscene = 887084708
IslandDJ02Cutscene = 1712601360
IslandDJ03Cutscene = 2440761309
IslandDJ04Cutscene = 2998686303
JackHowitzerCutscene = 1153203121
JamalAmirCutscene = 3014899707
JanetCutscene = 808778210
JanitorCutscene = 3254803008
JewelassCutscene = 1145088004
JimmyBostonCutscene = 60192701
JimmyDisantoCutscene = 3100414644
JimmyDiSanto2Cutscene = 1836024091
JIOCutscene = 2727058989
JIO02Cutscene = 3702591664
JoeMinutemanCutscene = 4036845097
JohnnyGunsCutscene = 2108278433
JohnnyKlebitzCutscene = 4203395201
JosefCutscene = 1167549130
JoshCutscene = 1158606749
JuanStricklerCutscene = 3612049721
KarenDanielsCutscene = 1269774364
LabratCutscene = 1491358515
LamarDavisCutscene = 1162230285
LamarDavis02Cutscene = 22425093
LazlowCutscene = 949295643
Lazlow2Cutscene = 1598839101
LesterCrestCutscene = 3046438339
LesterCrest2Cutscene = 191074589
LesterCrest3Cutscene = 496317824
Lifeinvad01Cutscene = 1918178165
LuchadoraCutscene = 1373135346
MagentaCutscene = 1477887514
ManuelCutscene = 4222842058
MarnieCutscene = 1464721716
MartinMadrazoCutscene = 1129928304
MaryannCutscene = 161007533
MaudeCutscene = 3166991819
MerryWeatherCutscene = 1631478380
MichelleCutscene = 1890499016
MiguelMadrazoCutscene = 3685838978
MiltonCutscene = 3077190415
MimiCutscene = 2260860904
MJOCutscene = 2700978005
MJO02Cutscene = 2566126104
MollyCutscene = 1167167044
Moodyman02Cutscene = 2373903780
MoviePremFemaleCutscene = 1270514905
MoviePremMaleCutscene = 2372398717
MrKCutscene = 3284966005
MrsPhillipsCutscene = 3422397391
MrsThornhillCutscene = 1334976110
Musician00Cutscene = 3351027244
NataliaCutscene = 1325314544
NervousRonCutscene = 2023152276
NervousRon2Cutscene = 731167118
NigelCutscene = 3779566603
OldMan1aCutscene = 518814684
OldMan2Cutscene = 2566514544
OmegaCutscene = 2339419141
OrleansCutscene = 2905870170
OrtegaCutscene = 3235579087
OscarCutscene = 4095687067
PaigeCutscene = 1528799427
PaperCutscene = 1798879480
PopovCutscene = 1635617250
PartyPromoCutscene = 2564310175
PatriciaCutscene = 3750433537
Patricia02Cutscene = 788179139
PornDudesCutscene = 793443893
PriestCutscene = 1299047806
PrologueDriverCutscene = 4027271643
PrologueSec01Cutscene = 2141384740
PrologueSec02Cutscene = 512955554
RampGangCutscene = 3263172030
RampHicCutscene = 2240582840
RampHipsterCutscene = 569740212
RampMarineCutscene = 1634506681
RampMexCutscene = 4132362192
RashkovskyCutscene = 411081129
ReporterCutscene = 776079908
ReqOfficerCutscene = 2297916218
RoccoPelosiCutscene = 2858686092
RussianDrunkCutscene = 1179785778
ScreenWriterCutscene = 2346790124
SecurityACutscene = 734593052
SessantaCutscene = 3552233440
SiemonYetarianCutscene = 3230888450
SolCutscene = 1324952405
SolomonCutscene = 4140949582
SoundEng00Cutscene = 543190380
SSSCutscene = 3772505184
SteveHainsCutscene = 2766184958
StretchCutscene = 2302502917
Stripper01Cutscene = 2934601397
Stripper02Cutscene = 2168724337
TalCCCutscene = 3392144504
TalMMCutscene = 3785408493
TanishaCutscene = 1123963760
TaoChengCutscene = 2288257085
TaoCheng2Cutscene = 650034742
TaosTranslatorCutscene = 1397974313
TaosTranslator2Cutscene = 3017289007
TennisCoachCutscene = 1545995274
TerryCutscene = 978452933
ThorntonCutscene = 4086880849
TomCutscene = 1776856003
TomCasinoCutscene = 3488666811
TomEpsilonCutscene = 2349847778
TonyaCutscene = 1665391897
TonyPrinceCutscene = 1566545691
TracyDisantoCutscene = 101298480
TrafficWardenCutscene = 3727243251
UndercoverCopCutscene = 4017642090
VagosLeaderCutscene = 2201152485
VagosSpeakCutscene = 1224690857
VernonCutscene = 3178697670
VincentCutscene = 520636071
Vincent2Cutscene = 2782957088
Vincent4Cutscene = 2149958315
WadeCutscene = 3529955798
WeiChengCutscene = 819699067
WendyCutscene = 1437043119
ZimborCutscene = 3937184496
Boar = 3462393972
Boar2 = 2334752500
Cat = 1462895032
ChickenHawk = 2864127842
Chimp = 2825402133
Chimp2 = 2114741418
Chop = 351016938
Chop2 = 1039404993
Cormorant = 1457690978
Cow = 4244282910
Coyote = 1682622302
Coyote2 = 734582471
Crow = 402729631
Deer = 3630914197
Deer2 = 2857068496
Dolphin = 2344268885
Fish = 802685111
Hen = 1794449327
HammerShark = 1015224100
Humpback = 1193010354
Husky = 1318032802
KillerWhale = 2374682809
MountainLion = 307287994
MountainLion2 = 2368442193
Panther = 3877461608
Pig = 2971380566
Pigeon = 111281960
Poodle = 1125994524
Pug = 1832265812
Pug2 = 1072872081
Rabbit = 3753204865
Rabbit2 = 1553815115
Rat = 3283429734
Retriever = 882848737
Rhesus = 3268439891
Rottweiler = 2506301981
Seagull = 3549666813
Shepherd = 1126154828
Stingray = 2705875277
TigerShark = 113504370
Westy = 2910340283
Abner = 4037813798
AlDiNapoli = 4042020578
Antonb = 3479321132
Armoured01 = 3455013896
AvonGoon = 2618542997
Babyd = 3658575486
Bankman01 = 3272005365
Baygor = 1380197501
BethFemaleYoung01 = 2503965067
BogdanGoon = 1297520375
BikeHire01 = 1984382277
BikerChic = 4198014287
BlaneMaleMiddleAge = 2543361176
BoatStaff01M = 3361671816
BoatStaff01F = 848542158
BurgerDrug = 2340239206
CalebMaleYoung = 4150317356
CarDesignFemale01 = 606876839
CarolFemaleOld = 1415150394
CasinoCashFemaleMiddleAge01 = 3138220789
CasinoShopFemaleMiddleAge01 = 338154536
Chip = 610290475
Claude01 = 3237179831
ClubhouseBar01 = 3287737221
CocaineFemale01 = 1264941816
CocaineMale01 = 1456705429
ComJane = 3064628686
Corpse01UFM = 773063444
Corpse01UFY = 2624589981
Corpse01UMY = 2495782975
Corpse02UFY = 228356856
CounterfeitFemale01 = 3079205365
CounterfeitMale01 = 2555758964
CroupThiefMaleYoung01 = 2145640135
CurtisMaleMiddleAge = 4161104501
Cyclist01 = 755956971
DanceBurlFemaleYoung01 = 222643882
DanceBurlUMaleYoung01 = 1443057394
DanceLthrFemaleYoung01 = 130590395
DanceLthrUMaleYoung01 = 4202382694
DanceRaveFemaleYoung01 = 2900533745
DanceRaveUMaleYoung01 = 2145639711
DeadHooker = 1943971979
DeanMaleOld = 4188740747
DebbieFemaleMiddleAge01 = 223828550
Drowned = 3623056905
EileenFemaleOld = 2630685688
ExArmy01 = 1161072059
ExecutivePAMale01 = 1048844220
ExecutivePAFemale01 = 1126998116
ExecutivePAFemale02 = 1500695792
Famdd01 = 866411749
FemaleAgent = 1348537411
FibArchitect = 874722259
FibMugger01 = 2243544680
FibSec01 = 1558115333
FilmDirector = 728636342
FilmNoir = 732742363
Finguru01 = 1189322339
ForgeryFemale01 = 2014985464
ForgeryMale01 = 1631482011
FreemodeFemale01 = 2627665880
FreemodeMale01 = 1885233650
GabrielMaleYoung = 1278330017
Glenstank01 = 1169888870
Griff01 = 3293887675
Guido01 = 3333724719
GunVend01 = 3005388626
Hacker = 2579169528
HeliStaff01 = 431423238
Hippie01 = 4030826507
Hotposh01 = 2526768638
Imporage = 880829941
ImportExportFemale01 = 2225189146
ImportExportMale01 = 3164785898
Jesus01 = 3459037009
Jewelass01 = 4040474158
JewelSec01 = 2899099062
JewelThief = 3872144604
Juggernaut01M = 2431602996
Juggernaut02UMY = 2738943447
Juggernaut03UMM = 2680892058
Justin = 2109968527
LaurenFemaleYoung = 967594628
Mani = 3367706194
Markfost = 479578891
Marston01 = 943915367
MethFemale01 = 3534913217
MethMale01 = 3988008767
MilitaryBum = 1191548746
Miranda = 1095737979
Miranda02 = 3954904244
Mistress = 1573528872
Misty01 = 3509125021
MovieStar = 894928436
MPros01 = 1822283721
Niko01 = 4007317449
Paparazzi = 1346941736
Party01 = 921110016
PartyTarget = 2180468199
PestContDriver = 994527967
PestContGunman = 193469166
Pogo01 = 3696858125
Poppymich = 602513566
PoppyMich02 = 1823868411
Princess = 3538133636
Prisoner01 = 2073775040
PrologueHostage01 = 3306347811
PrologueMournFemale01 = 2718472679
PrologueMournMale01 = 3465937675
RivalPaparazzi = 1624626906
SecuroGuardMale01 = 3660355662
ShopKeep01 = 416176080
SmugMech01 = 3446096293
SpyActor = 2886641112
SpyActress = 1535236204
StreetArt01 = 1813637474
StripperLite = 695248020
Taphillbilly = 2585681490
TaylorFemaleYoung = 450271392
Tramp01 = 1787764635
UshiMaleYoung = 4218162071
VagosFun01 = 3299219389
VinceMaleMiddleAge = 2526968950
WarehouseBoss = 1108376739
WareMechMale01 = 4154933561
WillyFist = 2423691919
WeaponExpertMale01 = 921328393
WeaponWorkerMale01 = 1099321454
WeedFemale01 = 2992993187
WeedMale01 = 2441008217
YuleMonster = 3543068589
Zombie01 = 2890614022
YetiUMM = 2363925622
Acult01AMM = 1413662315
Acult01AMO = 1430544400
Acult01AMY = 3043264555
Acult02AMO = 1268862154
Acult02AMY = 2162532142
AfriAmer01AMM = 3513928062
Airhostess01SFY = 1567728751
AirworkerSMY = 1644266841
Ammucity01SMY = 2651349821
AmmuCountrySMM = 233415434
ArmBoss01GMM = 4058522530
ArmGoon01GMM = 4255728232
ArmGoon02GMY = 3310258058
ArmLieut01GMM = 3882958867
Armoured01SMM = 2512875213
Armoured02SMM = 1669696074
Armymech01SMY = 1657546978
Autopsy01SMY = 2988916046
Autoshop01SFM = 12394276
Autoshop01SMM = 68070371
Autoshop02SMM = 4033578141
Autoshop03SMM = 109850898
Azteca01GMY = 1752208920
BallaEast01GMY = 4096714883
BallaOrig01GMY = 588969535
Ballas01GFY = 361513884
BallaSout01GMY = 599294057
BankRobber01AMM = 3645767658
Barman01SMY = 3852538118
Bartender01SFY = 2014052797
Baywatch01SFY = 1250841910
Baywatch01SMY = 189425762
Beach01AFM = 808859815
Beach01AFY = 3349113128
Beach01AMM = 1077785853
Beach01AMO = 2217202584
Beach01AMY = 3523131524
Beach02AFY = 3105934379
Beach02AMM = 2021631368
Beach02AMO = 3243462130
Beach02AMY = 600300561
Beach03AMY = 3886638041
Beach04AMY = 3105523388
BeachBarStaff01SFY = 3269663242
Beachvesp01AMY = 2114544056
Beachvesp02AMY = 3394697810
BennyMech01F = 2139205821
Bevhills01AFM = 3188223741
Bevhills01AFY = 1146800212
Bevhills01AMM = 1423699487
Bevhills01AMY = 1982350912
Bevhills02AFM = 2688103263
Bevhills02AFY = 1546450936
Bevhills02AMM = 1068876755
Bevhills02AMY = 1720428295
Bevhills03AFY = 549978415
Bevhills04AFY = 920595805
Bevhills05AFY = 2464671085
Blackops01SMY = 3019107892
Blackops02SMY = 2047212121
Blackops03SMY = 1349953339
Bodybuild01AFM = 1004114196
Bouncer01SMM = 2681481517
Bouncer02SMM = 1376128402
Breakdance01AMY = 933205398
Busboy01SMY = 3640249671
Busicas01AMY = 2597531625
Business01AFY = 664399832
Business01AMM = 2120901815
Business01AMY = 3382649284
Business02AFM = 532905404
Business02AFY = 826475330
Business02AMY = 3014915558
Business03AFY = 2928082356
Business03AMY = 2705543429
Business04AFY = 3083210802
Busker01SMO = 2912874939
CarClub01AFY = 4245210443
CarClub01AMY = 1751120084
CartelGoons01GMM = 2572894111
CartelGuards01GMM = 2127932792
CartelGuards02GMM = 1821116645
Casino01SFY = 3163733717
Casino01SMY = 337826907
CasRN01GMM = 1020431539
CCrew01SMM = 3387290987
CCrew02SMM = 3080868068
CCrew03SMM = 3867258530
Chef01SMY = 261586155
ChemSec01SMM = 788443093
ChemWork01GMM = 4128603535
ChiBoss01GMM = 3118269184
ChiCold01GMM = 275618457
ChiGoon01GMM = 2119136831
ChiGoon02GMM = 4285659174
CiaSec01SMM = 1650288984
Clown01SMY = 71929310
ClubBar01SFY = 3240507723
ClubBar01SMY = 1299424319
ClubBar02SFY = 1438999163
ClubCust01AFY = 1744231373
ClubCust02AFY = 357447289
ClubCust03AFY = 10751269
ClubCust04AFY = 786557344
ClubCust01AMY = 2813792322
ClubCust02AMY = 3324988722
ClubCust03AMY = 3572886207
ClubCust04AMY = 3793814805
Cntrybar01SMM = 436345731
Construct01SMY = 3621428889
Construct02SMY = 3321821918
Cop01SFY = 368603149
Cop01SMM = 1762753038
Cop01SMY = 1581098148
Cyclist01AMY = 4257633223
Dealer01SMY = 3835149295
Devinsec01SMY = 2606068340
Dhill01AMY = 4282288299
Dockwork01SMM = 349680864
Dockwork01SMY = 2255894993
Doctor01SMM = 3564307372
Doorman01SMY = 579932932
Downtown01AFM = 1699403886
Downtown01AMY = 766375082
DrugProcess01SMM = 1547070595
DwService01SMY = 1976765073
DwService02SMY = 4119890438
Eastsa01AFM = 2638072698
Eastsa01AFY = 4121954205
Eastsa01AMM = 4188468543
Eastsa01AMY = 2756120947
Eastsa02AFM = 1674107025
Eastsa02AFY = 70821038
Eastsa02AMM = 131961260
Eastsa02AMY = 377976310
Eastsa03AFY = 1371553700
Epsilon01AFY = 1755064960
Epsilon01AMY = 2010389054
Epsilon02AMY = 2860711835
Factory01SFY = 1777626099
Factory01SMY = 1097048408
Famca01GMY = 3896218551
Famdnf01GMY = 3681718840
Famfor01GMY = 2217749257
Families01GFY = 1309468115
Farmer01AMM = 2488675799
FatBla01AFM = 4206136267
FatCult01AFM = 3050275044
Fatlatin01AMM = 1641152947
FatWhite01AFM = 951767867
FemBarberSFM = 373000027
FibOffice01SMM = 3988550982
FibOffice02SMM = 653289389
FibSec01SMM = 2072724299
FieldWorker01SMM = 2423573072
Fireman01SMY = 3065114024
Fitness01AFY = 1165780219
Fitness02AFY = 331645324
Fooliganz01GFM = 2705574861
Fooliganz01GMM = 620276966
FriedlanderGoons01GMM = 80921836
Gaffer01SMM = 2841034142
GarbageSMY = 4000686095
Gardener01SMM = 1240094341
Gay01AMY = 3519864886
Gay02AMY = 2775713665
GenBiker01AFM = 1956335717
GenBiker01AMM = 3739319678
GenCasPat01AFY = 2434503858
GenCasPat01AMY = 2600762591
Genfat01AMM = 115168927
Genfat02AMM = 330231874
Genhot01AFY = 793439294
GenStreet01AFM = 1261149561
Genstreet01AFO = 1640504453
Genstreet01AMO = 2908022696
Genstreet01AMY = 2557996913
Genstreet02AMY = 891398354
GenThug01GMM = 3540189323
GentransportSMM = 411102470
Golfer01AFY = 2111372120
Golfer01AMM = 2850754114
Golfer01AMY = 3609190705
Goons01GMM = 1642910562
Grip01SMY = 815693290
Hairdress01SMM = 1099825042
Hasjew01AMM = 1809430156
Hasjew01AMY = 3782053633
HazmatWorker01SMM = 3688051673
HeadTargets = 1173958009
Highsec01SMM = 4049719826
Highsec02SMM = 691061163
Highsec03SMM = 518696223
HighSec04SMM = 1442749254
HighSec05SMM = 985359552
Hiker01AFY = 813893651
Hiker01AMY = 1358380044
Hillbilly01AMM = 1822107721
Hillbilly02AMM = 2064532783
Hippie01AFY = 343259175
Hippy01AMY = 2097407511
Hipster01AFY = 2185745201
Hipster01AMY = 587703123
Hipster02AFY = 2549481101
Hipster02AMY = 349505262
Hipster03AFY = 2780469782
Hipster03AMY = 1312913862
Hipster04AFY = 429425116
Hooker01SFY = 42647445
Hooker02SFY = 348382215
Hooker03SFY = 51789996
Hwaycop01SMY = 1939545845
Indian01AFO = 3134700416
Indian01AFY = 153984193
Indian01AMM = 3721046572
Indian01AMY = 706935758
JanitorSMM = 2842417644
Jetski01AMY = 767028979
Juggalo01AFY = 3675473203
Juggalo01AMY = 2445950508
KorBoss01GMM = 891945583
Korean01GMY = 611648169
Korean02GMY = 2414729609
KorLieut01GMY = 2093736314
Ktown01AFM = 1388848350
Ktown01AFO = 1204772502
Ktown01AMM = 3512565361
Ktown01AMO = 355916122
Ktown01AMY = 452351020
Ktown02AFM = 1090617681
Ktown02AMY = 696250687
Lathandy01SMM = 2659242702
Latino01AMY = 321657486
Lifeinvad01SMM = 3724572669
LinecookSMM = 3684436375
Lost01GFY = 4250220510
Lost01GMY = 1330042375
Lost02GMY = 1032073858
Lost03GMY = 850468060
Lsmetro01SMM = 1985653476
Maid01SFM = 3767780806
Malibu01AMM = 803106487
MaraGrandeGMM = 2487843240
Mariachi01SMM = 2124742566
Marine01SMM = 4074414829
Marine01SMY = 1702441027
Marine02SMM = 4028996995
Marine02SMY = 1490458366
Marine03SMY = 1925237458
Methhead01AMY = 1768677545
MexBoss01GMM = 1466037421
MexBoss02GMM = 1226102803
MexCntry01AMM = 3716251309
MexGang01GMY = 3185399110
MexGoon01GMY = 653210662
MexGoon02GMY = 832784782
MexGoon03GMY = 2521633500
MexLabor01AMM = 2992445106
MexThug01AMY = 810804565
Migrant01SFY = 3579522037
Migrant01SMM = 3977045190
MimeSMY = 1021093698
MLCrisis01AMM = 1561088805
Motox01AMY = 1694362237
Motox02AMY = 2007797722
MovAlien01 = 1684083350
MovPrem01SFY = 587253782
Movprem01SMM = 3630066984
Movspace01SMM = 3887273010
Musclbeac01AMY = 1264920838
Musclbeac02AMY = 3374523516
OgBoss01AMM = 1746653202
Paparazzi01AMM = 3972697109
Paramedic01SMM = 3008586398
PestCont01SMY = 1209091352
Pilot01SMM = 3881519900
Pilot01SMY = 2872052743
Pilot02SMM = 4131252449
PoloGoon01GMY = 1329576454
PoloGoon02GMY = 2733138262
Polynesian01AMM = 2849617566
Polynesian01AMY = 2206530719
Postal01SMM = 1650036788
Postal02SMM = 1936142927
Prisguard01SMM = 1456041926
PrisMuscl01SMY = 1596003233
Prisoner01SMY = 2981862233
Prisoners01GMM = 565446671
PrologueHostage01AFM = 379310561
PrologueHostage01AMM = 2534589327
RaceOrg01SMM = 2597948825
Ranger01SFY = 2680682039
Ranger01SMY = 4017173934
RetailStaff01SFM = 3248235618
Roadcyc01AMY = 4116817094
Robber01SMY = 3227390873
RsRanger01AMO = 1011059922
Runner01AFY = 3343476521
Runner01AMY = 623927022
Runner02AMY = 2218630415
Rurmeth01AFY = 1064866854
Rurmeth01AMM = 1001210244
Salton01AFM = 3725461865
Salton01AFO = 3439295882
Salton01AMM = 1328415626
Salton01AMO = 539004493
Salton01AMY = 3613420592
Salton02AMM = 1626646295
Salton03AMM = 2995538501
Salton04AMM = 2521108919
SalvaBoss01GMY = 2422005962
SalvaGoon01GMY = 663522487
SalvaGoon02GMY = 846439045
SalvaGoon03GMY = 62440720
SbikeAMO = 1794381917
Scdressy01AFY = 3680420864
Scientist01SMM = 1092080539
Scrubs01SFY = 2874755766
Security01SMM = 3613962792
Sheriff01SFY = 1096929346
Sheriff01SMY = 2974087609
ShopHighSFM = 2923947184
ShopLowSFY = 2842568196
ShopMaskSMY = 1846684678
ShopMidSFY = 1055701597
Skater01AFY = 1767892582
Skater01AMM = 3654768780
Skater01AMY = 3250873975
Skater02AMY = 2952446692
Skidrow01AFM = 2962707003
Skidrow01AMM = 32417469
Slasher01GMM = 662575004
SlodHuman = 1057201338
SlodSmallQuadped = 762327283
SlodLargeQuadped = 2238511874
SmartCasPat01AFY = 279228114
SmartCasPat01AMY = 553826858
Snowcop01SMM = 451459928
Socenlat01AMM = 193817059
Soucent01AFM = 1951946145
Soucent01AFO = 1039800368
Soucent01AFY = 744758650
Soucent01AMM = 1750583735
Soucent01AMO = 718836251
Soucent01AMY = 3877027275
Soucent02AFM = 4079145784
Soucent02AFO = 2775443222
Soucent02AFY = 1519319503
Soucent02AMM = 2674735073
Soucent02AMO = 1082572151
Soucent02AMY = 2896414922
Soucent03AFY = 2276611093
Soucent03AMM = 2346291386
Soucent03AMO = 238213328
Soucent03AMY = 3287349092
Soucent04AMM = 3271294718
Soucent04AMY = 2318861297
Soucentmc01AFM = 3454621138
Staggrm01AMO = 2442448387
Stbla01AMY = 3482496489
Stbla02AMY = 2563194959
Stlat01AMY = 2255803900
Stlat02AMM = 3265820418
Stripper01SFY = 1381498905
Stripper02SFY = 1846523796
StripperLiteSFY = 1544875514
Strperf01SMM = 2035992488
Strpreach01SMM = 469792763
StrPunk01GMY = 4246489531
StrPunk02GMY = 228715206
Strvend01SMM = 3465614249
Strvend01SMY = 2457805603
Stwhi01AMY = 605602864
Stwhi02AMY = 919005580
StudioAssist01SFM = 3243617472
StudioAssist02SMM = 2679204136
StudioParty01AFY = 1152702280
StudioParty02AFY = 1984313950
StudioParty01AMM = 2342084645
StudioParty01AMY = 2989564573
StudioProd01SMM = 3819113407
StudioSouEng02SMM = 3725116432
SubCrew01SMM = 3738560875
Sunbathe01AMY = 3072929548
Surfer01AMY = 3938633710
Swat01SMY = 2374966032
Sweatshop01SFM = 824925120
Sweatshop01SFY = 2231547570
Tattoo01AMO = 2494442380
Tattoo01SMM = 3289859051
TattooCust01AMY = 2619283993
Tennis01AFY = 1426880966
Tennis01AMM = 1416254276
Topless01AFY = 2633130371
Tourist01AFM = 1347814329
Tourist01AFY = 1446741360
Tourist01AMM = 3365863812
Tourist02AFY = 2435054400
Tramp01AFM = 1224306523
Tramp01AMM = 516505552
Tramp01AMO = 390939205
TrampBeac01AFM = 2359345766
TrampBeac01AMM = 1404403376
Tranvest01AMM = 3773208948
Tranvest02AMM = 4144940484
Trucker01SMM = 1498487404
Ups01SMM = 2680389410
Ups02SMM = 3502104854
Uscg01SMY = 3389018345
Vagos01GFY = 1520708641
Valet01SMY = 999748158
Vindouche01AMY = 3247667175
Vinewood01AFY = 435429221
Vinewood01AMY = 1264851357
Vinewood02AFY = 3669401835
Vinewood02AMY = 1561705728
Vinewood03AFY = 933092024
Vinewood03AMY = 534725268
Vinewood04AFY = 4209271110
Vinewood04AMY = 835315305
Waiter01SMY = 2907468364
Warehouse01SFM = 3845594002
Warehouse01SMM = 660117393
WareTech01SMY = 1221043248
WestSec01SMY = 2719478597
WestSec02SMY = 3200789669
WinClean01SMY = 1426951581
Xmech01SMY = 1142162924
Xmech02SMY = 3189832196
Xmech02SMYMP = 1762949645
Yoga01AFY = 3290105390
Yoga01AMY = 2869588309
```

## PedHeadshot

class `GTA.PedHeadshot` : `INativeValue`

### Properties

- `public int Handle { get; }`
- `public bool IsReady { get; }`
- `public bool IsValid { get; }`
- `public ulong NativeValue { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public Txd GetTxdNoStatusCheck()`
- `public void Release()`
- `public bool TryGetTxd(out Txd txd)`
- `public static bool op_Equality(PedHeadshot left, PedHeadshot right)`
- `public static InputArgument op_Implicit(PedHeadshot value)`
- `public static bool op_Inequality(PedHeadshot left, PedHeadshot right)`
- `public static PedHeadshot Register(Ped ped)`
- `public static PedHeadshot RegisterHiRes(Ped ped)`
- `public static PedHeadshot RegisterTransparent(Ped ped)`

## PedLegIKMode

enum `GTA.PedLegIKMode`

| Name | Value |
| --- | --- |
| `Off` | 0 |
| `Partial` | 1 |
| `Full` | 2 |
| `FullMelee` | 3 |

## PedMotionState

enum `GTA.PedMotionState`

| Name | Value |
| --- | --- |
| `None` | 4000413475 |
| `Idle` | 2423432979 |
| `Walk` | 3626484699 |
| `Run` | 4294436772 |
| `Sprint` | 3179812827 |
| `CrouchIdle` | 1140525470 |
| `CrouchWalk` | 147004056 |
| `CrouchRun` | 898879241 |
| `DoNothing` | 247561816 |
| `AnimatedVelocity` | 1427811395 |
| `InVehicle` | 2497303949 |
| `Aiming` | 1063765679 |
| `DivingIdle` | 1212730861 |
| `DivingSwim` | 2439938700 |
| `SwimmingTreadWater` | 3518960071 |
| `Dead` | 230360860 |
| `StealthIdle` | 1110276645 |
| `StealthWalk` | 69908130 |
| `StealthRun` | 4211833313 |
| `Parachuting` | 3133206795 |
| `ActionModeIdle` | 3661668572 |
| `ActionModeWalk` | 3532676775 |
| `ActionModeRun` | 834330132 |
| `Jetpack` | 1398696542 |

## PedMoveBlendRatio

struct `GTA.PedMoveBlendRatio` : `IEquatable<PedMoveBlendRatio>`

### Constructors

- `public PedMoveBlendRatio(float value)`

### Properties

- `public float Value { get; }`
- `public static PedMoveBlendRatio Run { get; }`
- `public static PedMoveBlendRatio Sprint { get; }`
- `public static PedMoveBlendRatio Still { get; }`
- `public static PedMoveBlendRatio Walk { get; }`

### Methods

- `public bool Equals(PedMoveBlendRatio moveBlendRatio)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public virtual string ToString()`
- `public static bool op_Equality(PedMoveBlendRatio left, PedMoveBlendRatio right)`
- `public static float op_Explicit(PedMoveBlendRatio value)`
- `public static PedMoveBlendRatio op_Explicit(float value)`
- `public static InputArgument op_Implicit(PedMoveBlendRatio value)`
- `public static bool op_Inequality(PedMoveBlendRatio left, PedMoveBlendRatio right)`

## PedMoveNetworkTaskInterface

class `GTA.PedMoveNetworkTaskInterface`

### Properties

- `public string CurrentScriptStateName { get; }`
- `public bool IsReadyForTransition { get; }`
- `public bool IsTaskActive { get; }`

### Methods

- `public bool GetEvent(string eventName)`
- `public bool GetSignalBool(string signalName)`
- `public float GetSignalFloat(string signalName)`
- `public bool RequestStateTransition(string stateName)`
- `public void SetNetworkClipSet(AtHashValue clipSet, AtHashValue varClipSet = null)`
- `public void SetSignalBool(string signalName, bool signal)`
- `public void SetSignalFloat(string signalName, float signal)`
- `public void SetSignalFloatLerpRate(string signalName, float lerpRate)`

## PedProp

class `GTA.PedProp` : `IPedVariation`

### Properties

- `public PedPropAnchorPoint AnchorPoint { get; }`
- `public int Count { get; }`
- `public bool HasAnyVariations { get; }`
  - **Obsolete.** PedProp.HasAnyVariations is obsolete because it does not make sense as texture count cannot be determined without specifying both prop position id and drawable id.
- `public bool HasTextureVariations { get; }`
  - **Obsolete.** PedProp.HasTextureVariations is obsolete because it does not make sense as texture count cannot be determined without specifying both prop position id and drawable id.
- `public bool HasVariations { get; }`
- `public int Index { get; set; }`
- `public string Name { get; }`
- `public int TextureCount { get; }`
- `public int TextureIndex { get; set; }`
- `public PedPropType Type { get; }`
  - **Obsolete.** PedProp.Type is obsolete, use PedProp.AnchorPoint instead.

### Methods

- `public bool IsVariationValid(int index, int textureIndex = 0)`
- `public bool SetVariation(int index, int textureIndex = 0)`
- `public virtual string ToString()`

## PedPropAnchorPoint

enum `GTA.PedPropAnchorPoint`

| Name | Value |
| --- | --- |
| `Head` | 0 |
| `Eyes` | 1 |
| `Ears` | 2 |
| `Mouth` | 3 |
| `LeftHand` | 4 |
| `RightHand` | 5 |
| `LeftWrist` | 6 |
| `RightWrist` | 7 |
| `Hip` | 8 |

## PedPropType

enum `GTA.PedPropType`

| Name | Value |
| --- | --- |
| `Hats` | 0 |
| `Glasses` | 1 |
| `EarPieces` | 2 |
| `Unknown3` | 3 |
| `Unknown4` | 4 |
| `Unknown5` | 5 |
| `Watches` | 6 |
| `Wristbands` | 7 |
| `Unknown8` | 8 |
| `Unknown9` | 9 |

## PedResetFlags

class `GTA.PedResetFlags`

### Properties

- `public float EntityZFromGroundZHeight { get; set; }`
- `public float EntityZFromGroundZThreshold { get; set; }`
- `public bool HasJustLeftVehicle { get; }`
- `public bool IsCodeHeadIKBlocked { get; }`
- `public bool IsHeadIKBlocked { get; }`
- `public bool IsInCover { get; }`
- `public uint NumFramesNotToAcceptCodeIKLookAts { get; set; }`
- `public uint NumFramesNotToAcceptIKLookAts { get; set; }`
- `public byte NumFramesToBeKnockedByDoor { get; set; }`
- `public uint NumFramesToConsiderInCover { get; set; }`
- `public uint NumFramesToConsiderJustLeftVehicle { get; set; }`
- `public byte NumFramesToSetEntityZFromGround { get; set; }`

### Methods

- `public bool GetResetFlag(PedResetFlagToggles resetFlag)`
- `public void SetEntityZFromGroundZHeight(float height, float threshold = 1)`
- `public void SetIsCodeHeadIKBlocked()`
- `public void SetIsHeadIKBlocked()`
- `public void SetResetFlag(PedResetFlagToggles resetFlag, bool value)`

## PedResetFlagToggles

enum `GTA.PedResetFlagToggles`

456 values:

```text
FallenDown = 0
DontRenderThisFrame = 1
IsDrowning = 2
PedHitWallLastFrame = 3
UsingMobilePhone = 4
BlockMovementAnims = 5
ZeroDesiredMoveBlendRatios = 6
DontChangeMbrInSimpleMoveDoNothing = 7
FollowingRoute = 8
TakingRouteSplineCorner = 9
Wandering = 10
ProcessPhysicsTasks = 11
ProcessPreRender2 = 12
SetLastMatrixDone = 13
FiringWeapon = 14
SearchingForCover = 15
KeepCoverPoint = 16
IsClimbing = 17
IsJumping = 18
IsLanding = 19
CullExtraFarAway = 20
DontActivateRagdollFromAnyPedImpactReset = 21
ForceScriptControlledRagdoll = 22
TaskUseKinematicPhysics = 23
TemporarilyBlockWeaponSwitching = 24
DoNotClampFootIK = 25
MoveBlend_bFleeTaskRunning = 26
IsAiming = 27
MoveBlend_bTaskComplexGunRunning = 28
MoveBlend_bMeleeTaskRunning = 29
MoveBlend_bCopSearchTaskRunning = 30
PatrollingInVehicle = 31
RaiseVelocityChangeLimit = 32
DimTargetReticule = 33
IsWalkingRoundPlayer = 34
GestureAnimsAllowed = 35
VisemeAnimsBlocked = 36
AmbientAnimsBlocked = 37
KnockedToTheFloorByPlayer = 38
RandomisePointsDuringNavigation = 39
Prevent180SkidTurns = 40
IsOnAssistedMovementRoute = 41
ApplyVelocityDirectly = 42
DisablePlayerLockOn = 43
ResetMoveGroupAfterRagdoll = 44
DisablePedConstraints = 45
DisablePlayerJumping = 46
DisablePlayerVaulting = 47
DisableAsleepImpulse = 48
ForcePostCameraAIUpdate = 49
ForcePostCameraAnimUpdate = 50
PostCameraAnimUpdateUseZeroTimestep = 51
CollideWithGlassRagdoll = 52
CollideWithGlassWeapon = 53
SyncDesiredHeadingToCurrentHeading = 54
AllowUpdateIfNoCollisionLoaded = 55
InternalWalkingRndPlayer = 56
PlacingCharge = 57
ScriptDisableSecondaryAnimationTasks = 58
SearchingForClimb = 59
SearchingForDoors = 60
WanderingStoppedForOtherPed = 61
SuppressGunfireEvents = 62
InfiniteStamina = 63
BlockWeaponReactionsUnlessDead = 64
ForcePlayerFiring = 65
InCoverFacingLeft = 66
ForcePeekFromCover = 67
NotAllowedToChangeCrouchState = 68
ForcePedToStrafe = 69
ForceMeleeStrafingAnims = 70
UseKinematicPhysics = 71
ClearLockOnTarget = 72
CanPedSeeHatedPedBeingUsed = 73
InstantBlendToAim = 74
ForceImprovedIdleTurns = 75
HitPedWithWeapon = 76
ForcePedToUseScriptCamHeading = 77
ProcessProbesWhenExtractingZ = 78
KeepDesiredCoverPoint = 79
HasProcessedCornering = 80
StandingOnForkliftForks = 81
AimWeaponReactionRunning = 82
InContactWithFoliage = 83
ForceExplosionCollisions = 84
IgnoreTargetsCoverForLos = 85
BlockAnimatedWeaponReactions = 86
DisablePedCapsule = 87
DisableCrouchWhileInCover = 88
IncreasedAvoidanceRadius = 89
ForceRunningSpeedForFragSmashing = 91
EnableMoverAnimationWhileAttached = 92
NoTimeDelayBeforeShot = 93
SearchingForAutoVaultClimb = 94
ExtraLongWeaponRange = 95
ForcePlayerToEnterVehicleThroughDirectDoorOnly = 96
TaskCullExtraFarAway = 97
IsVaulting = 98
IsParachuting = 99
SuppressSlowingForCorners = 100
DisableProcessProbes = 101
DisablePlayerAutoVaulting = 102
DisableGaitReduction = 103
ExitVehicleTaskFinishedThisFrame = 104
RequiresLegIK = 105
JayWalking = 106
UseBulletPenetration = 107
ForceAimAtHead = 108
IsInStationaryScenario = 109
TemporarilyBlockWeaponEquipping = 110
CoverOutroRunning = 111
DisableSeeThroughChecksWhenTargeting = 112
PuttingOnHelmet = 113
AllowPullingPedOntoRoute = 114
ApplyAnimatedVelocityWhilstAttached = 115
AICoverEntryRunning = 116
ResponseAfterScenarioPanic = 117
IsNearDoor = 118
DisableTorsoSolver = 119
PanicInVehicle = 120
DisableDynamicCapsuleRadius = 121
IsRappelling = 122
SkipReactInReactAndFlee = 123
CannotBeTargeted = 124
IsFalling = 125
ForceInjuryAfterStunned = 126
HurtThisFrame = 127
BlockWeaponFire = 128
ExpandPedCapsuleFromSkeleton = 129
DisableWeaponLaserSight = 130
PedExitedVehicleThisFrame = 131
SearchingForDropDown = 132
UseTighterTurnSettings = 133
DisableArmSolver = 134
DisableHeadSolver = 135
DisableLegSolver = 136
DisableTorsoReactSolver = 137
ForcePreCameraAIUpdate = 138
TasksNeedProcessMoveSignalCalls = 139
ShootFromGround = 140
NoCollisionMovementMode = 141
IsNearLadder = 142
SkipAimingIdleIntro = 143
IgnoredByAutoOpenDoors = 144
BlockIKWeaponReactions = 145
FirstPhysicsUpdate = 146
SpawnedThisFrameByAmbientPopulation = 147
DisableRootSlopeFixupSolver = 148
SuspendInitiatedMeleeActions = 149
SuppressInAirEvent = 150
AllowTasksIncompatibleWithMotion = 151
IsEnteringOrExitingVehicle = 152
HasGunTaskWithAimingState = 154
SuppressLethalMeleeActions = 155
InstantBlendToAimFromScript = 156
IsStillOnBicycle = 157
IsSittingAndCycling = 158
IsStandingAndCycling = 159
IsDoingCoverAimOutro = 160
ApplyCoverWeaponBlockingOffsets = 161
IsInLowCover = 162
AmbientIdleAndBaseAnimsBlocked = 163
UseAlternativeWhenBlock = 164
ForceLowLodWaterCheck = 165
MakeHeadInvisible = 166
NoAutoRunWhenFiring = 167
PermitEventDuringScenarioExit = 168
DisableSteeringAroundVehicles = 169
DisableSteeringAroundPeds = 170
DisableSteeringAroundObjects = 171
DisableSteeringAroundNavMeshEdges = 172
WantsToEnterVehicleFromCover = 173
WantsToEnterCover = 174
WantsToEnterVehicleFromAiming = 175
CapsuleBeingPushedByVehicle = 176
DisableTakeOffParachutePack = 177
IsCallingPolice = 178
ForceCombatTaunt = 179
IgnoreCombatTaunts = 180
SkipAIUpdateProcessControl = 181
OverridePhysics = 182
WasPhysicsOverridden = 183
BlockWeaponHoldingAnims = 184
DisableMoveTaskHeadingAdjustments = 185
DisableBodyLookSolver = 186
PreventAllMeleeTakedowns = 187
PreventFailedMeleeTakedowns = 188
IsPedalling = 189
UseTighterAvoidanceSettings = 190
IsHigherPriorityClipControllingPed = 191
VehicleCrushingRagdoll = 192
OnActivationUpdate = 193
ForceMotionStateLeaveDesiredMbr = 194
DisableDropDowns = 195
InContactWithBigFoliage = 196
DisableTakeOffScubaGear = 197
DisableCellphoneAnimations = 198
IsExitingVehicle = 199
DisableActionMode = 200
EquippedWeaponChanged = 201
TouchingOverhang = 202
TooSteepForPlayer = 203
BlockSecondaryAnim = 204
IsInCombat = 205
UseHeadOrientationForPerception = 206
IsDoingDriveBy = 207
IsEnteringCover = 208
ForceMovementScannerCheck = 209
DisableJumpRagdollOnCollision = 210
IsBeingMeleeHomedByPlayer = 211
ShouldLaunchBicycleThisFrame = 212
CanDoBicycleWheelie = 213
ForceProcessPhysicsUpdateEachSimStep = 214
DisablePedCapsuleMapCollision = 215
DisableSeatShuffleDueToInjuredDriver = 216
DisableParachuting = 217
ProcessPostMovement = 218
ProcessPostCamera = 219
ProcessPostPreRender = 220
PreventBicycleFromLeaningOver = 221
KeepParachutePackOnAfterTeleport = 222
DontRaiseFistsWhenLockedOn = 223
PreferMeleeBodyIKHitReaction = 224
ProcessPhysicsTasksMotion = 225
ProcessPhysicsTasksMovement = 226
DisableFriendlyGunReactAudio = 227
DisableAgitationTriggers = 228
ForceForwardTransitionInReactAndFlee = 229
IsEnteringVehicle = 230
DoNotSkipNavMeshTrackerUpdate = 231
RagdollOnVehicle = 232
BlockRagdollActivationInVehicle = 233
DisableNMForRiverRapids = 234
IsInWrithe = 235
PreventGoingIntoStillInVehicleState = 236
UseFastEnterExitVehicleRates = 237
DisableGroundAttachment = 238
DisableAgitation = 239
DisableTalk = 240
InterruptedToQuickStartEngine = 241
PedEnteredFromLeftEntry = 242
IsDiving = 243
DisableVehicleImpacts = 244
DeepVehicleImpacts = 245
DisablePedCapsuleControl = 246
UseProbeSlopeStairsDetection = 247
DisableVehicleDamageReactions = 248
DisablePotentialBlastReactions = 249
OnlyAllowLeftArmDoorIK = 250
OnlyAllowRightArmDoorIK = 251
ForceProcessPedStandingUpdateEachSimStep = 252
DisableFlashlight = 253
DoingCombatRoll = 254
DisableBodyRecoilSolver = 255
CanAbortExitForInAirEvent = 256
DisableSprintDamage = 257
ForceEnableFlashlightForAI = 258
IsDoingCoverAimIntro = 259
IsAimingFromCover = 260
WaitingForCompletedPathRequest = 261
DisableCombatAudio = 262
DisableCoverAudio = 263
PreventBikeFromLeaning = 264
InCoverTaskActive = 265
EnableSteepSlopePrevention = 266
InsideEnclosedSearchRegion = 267
JumpingOutOfVehicle = 268
IsTuckedOnBicycleThisFrame = 269
ProcessPostMovementTimeSliced = 270
EnablePressAndReleaseDives = 271
OnlyExitVehicleOnButtonRelease = 272
IsGoingToStandOnExitedVehicle = 273
BlockRagdollFromVehicleFallOff = 274
DisableTorsoVehicleSolver = 275
IsExitingUpsideDownVehicle = 276
IsExitingOnsideVehicle = 277
IsExactStopping = 278
IsExactStopSettling = 279
IsTrainCrushingRagdoll = 280
OverrideHairScale = 281
ConsiderAsPlayerCoverThreatWithoutLos = 282
BlockCustomAIEntryAnims = 283
IgnoreVehicleEntryCollisionTests = 284
StreamActionModeAnimsIfDisabled = 285
ForceUpdateRagdollMatrix = 286
PreventGoingIntoShuntInVehicleState = 287
DisableIndependentMoverFrame = 288
DoingDriveByOutro = 289
BeingElectrocuted = 290
DisableUnarmedDriveBys = 291
TalkingToPlayer = 292
DontActivateRagdollFromPlayerPedImpactReset = 293
DontActivateRagdollFromAiRagdollImpactReset = 294
DontActivateRagdollFromPlayerRagdollImpactReset = 295
DisableVisemeBodyAdditive = 296
CapsuleBeingPushedByPlayerCapsule = 297
ForceActionMode = 298
ForceUnarmedActionMode = 299
UsingMoverExtraction = 300
BeingJacked = 301
EnableVoiceDrivenMouthMovement = 302
IsReloading = 303
UseTighterEnterVehicleSettings = 304
InRaceMode = 305
DisableAmbientMeleeMoves = 306
ForceBuoyancyProcessingIfAsleep = 307
AllowSpecialAbilityInVehicle = 308
DisableInVehicleActions = 309
ForceInstantSteeringWheelIKBlendIn = 310
IgnoreThreatEngagePlayerCoverBonus = 311
Block180Turns = 312
DontCloseVehicleDoor = 313
SkipExplosionOcclusion = 314
ProcessPhysicsTasksTimeSliced = 315
MeleeStrikeAgainstNonPed = 316
IgnoreNavigationForDoorArmIK = 317
DisableAimingWhileParachuting = 318
DisablePedCollisionWithPedEvent = 319
IgnoreVelocityWhenClosingVehicleDoor = 320
SkipOnFootIdleIntro = 321
DontWalkRoundObjects = 322
DisablePedEnteredMyVehicleEvents = 323
CancelLeftHandGripIK = 324
ResetMovementStaticCounter = 325
DisableInVehiclePedVariationBlocking = 326
ReduceEffectOfVehicleRamControlLoss = 327
DisablePlayerMeleeFriendlyAttacks = 328
MotionPedDoPostMovementIndependentMover = 329
IsMeleeTargetUnreachable = 330
DisableAutoForceOutWhenBlowingUpCar = 331
ThrowingProjectile = 332
OverrideHairScaleLarger = 333
DisableDustOffAnims = 334
DisableMeleeHitReactions = 335
VisemeAnimsAudioBlocked = 336
AllowHeadPropInVehicle = 337
IsInVehicleChase = 338
DontQuitMotionAiming = 339
SetLastBoundMatricesDone = 340
PreserveAnimatedAngularVelocity = 341
OpenDoorArmIK = 342
UseTighterTurnSettingsForScript = 343
ForcePreCameraProcessExternallyDrivenDofs = 344
LadderBlockingMovement = 345
DisableVoiceDrivenMouthMovement = 346
SteerIntoSkids = 347
AllowOpenDoorIkBeforeFullMovement = 348
AllowHomingMissileLockOnInVehicle = 349
AllowCloneForcePostCameraAIUpdate = 350
DisableHighHeels = 351
BreakTargetLock = 352
DontUseSprintEnergy = 353
DisableMaterialCollisionDamage = 355
DisableMPFriendlyLockOn = 356
DisableMPFriendlyLethalMeleeActions = 357
IfLeaderStopsSeekCover = 358
ProcessPostPreRenderAfterAttachments = 359
DoDamageCoughFacial = 360
UseInteriorCapsuleSettings = 362
IsClosingVehicleDoor = 363
DisableIdleExtraHeadingChange = 364
OnlySelectVehicleWeapons = 365
IsWarpingIntoVehicleMP = 366
RemoveHelmet = 367
IsRemovingHelmet = 368
GestureAnimsBlockedFromScript = 369
NeverRagdoll = 370
DisableWallHitAnimation = 371
PlayAgitatedAnimsInVehicle = 372
IsSeatShuffling = 373
IsThrowingProjectileWhileAiming = 374
DisableProjectileThrowsWhileAimingGun = 375
AllowControlRadioInAnySeatInMP = 376
DisableSpyCarTransformation = 377
BlockQuadLocomotionIdleTurns = 378
BlockHeadBobbingToRadio = 379
PlayFpsIdleFidgets = 380
ForceExtraLongBlendInForPedSkipIdleCoverTransition = 381
BlendingOutFpsIdleFidgets = 382
DisableMotionBaseVelocityOverride = 383
FpsSwimUseSwimMotionTask = 384
FpsSwimUseAimingMotionTask = 385
FiringWeaponWhenReady = 386
IsBlindFiring = 387
IsPeekingFromCover = 388
TaskSkipProcessPreComputeImpacts = 389
DisableAssistedAimLockOn = 390
FpsAllowAimIKForThrownProjectile = 391
TriggerRoadRageAnim = 392
ForcePreCameraAIAnimUpdateIfFirstPerson = 393
NoCollisionDamageFromOtherPeds = 394
BlockCameraSwitching = 395
NeverDieFromCapsuleRagdollSettings = 396
InContactWithDeepSurface = 397
DontSuppressUseNavMeshToNavigateToVehicleDoorWhenVehicleInWater = 398
IncludePedReferenceVelocityWhenFiringProjectiles = 399
IsDoingCoverOutroToPeek = 400
InstantBlendToAimNoSettle = 401
ForcePreCameraAnimUpdate = 402
DisableHelmetCullFps = 403
ShouldIgnoreCoverAutoHeadingCorrection = 404
DisableReticuleInCoverThisFrame = 405
ForceScriptedCameraLowCoverAngleWhenEnteringCover = 406
DisableCameraConstraintFallBackThisFrame = 407
DisableFpsArmIK = 408
DisableRightArmIKInCoverOutroFps = 409
DoFpsSprintBreakOut = 410
DoFpsJumpBreakOut = 411
IsExitingCover = 412
WeaponBlockedInFpsMode = 413
PoVCameraConstrained = 414
ScriptClearingPedTasks = 415
WasFpsJumpingWithProjectile = 416
DisableMeleeWeaponSelection = 417
WaypointPlaybackSlowMoreForCorners = 418
FpsPlacingProjectile = 419
UseBulletPenetrationForGlass = 420
FpsPlantingBombOnFloor = 421
ForceSkipFpsAimIntro = 422
CanBePinnedByFriendlyBullets = 423
DisableLeftArmIKInCoverOutroFps = 424
DisableSpikeStripRoadBlocks = 425
SkipFpsUnholsterTransition = 426
PutDownHelmetFX = 427
IsLowerPriorityMeleeTarget = 428
ForceScanForEventsThisFrame = 429
StartProjectileTaskWithPrimingDisabled = 430
CheckFpsSwitchInCameraUpdate = 431
ForceAutoEquipHelmetsInAircraft = 432
BlockRemotePlayerRecording = 433
InflictedDamageThisFrame = 434
UseFirstPersonVehicleAnimsIfFpsCamNotDominant = 435
ForceIntoStandPoseOnJetSki = 436
InAirDefenceSphere = 437
SuppressTakedownMeleeActions = 438
InvertLookAroundControls = 439
IgnoreCombatManager = 440
UseBlendedCamerasOnUpdateFpsCameraRelativeMatrix = 441
ForceMeleeCounter = 442
WasHitByVehicleMelee = 443
SuppressNavmeshForEnterVehicleTask = 444
DisableShallowWaterBikeJumpOutThisFrame = 445
DisablePlayerCombatRoll = 446
IgnoreDetachSafePositionCheck = 447
DisableEasyLadderConditions = 448
PlayerIgnoresScenarioSpawnRestrictions = 449
UsingDrone = 450
ForceWantedLevelWhenKilled = 451
UseScriptedWeaponFirePosition = 452
EnableCollisionOnNetworkCloneWhenFixed = 453
UseExtendedRagdollCollisionCalculator = 454
PreventLockOnToFriendlyPlayers = 455
OnlyAbortScriptedAnimOnMovementByInput = 456
PreventAllStealthKills = 457
BlockFallTaskFromExplosionDamage = 458
AllowPedRearEntry = 459
```

## PedTransportMode

enum `GTA.PedTransportMode`

| Name | Value |
| --- | --- |
| `Any` | 0 |
| `OnFoot` | 1 |
| `InVehicle` | 2 |

## PedType

enum `GTA.PedType`

| Name | Value |
| --- | --- |
| `Invalid` | -1 |
| `Player0` | 0 |
| `Player1` | 1 |
| `NetworkPlayer` | 2 |
| `Player2` | 3 |
| `CivMale` | 4 |
| `CivFemale` | 5 |
| `Cop` | 6 |
| `GangAlbanian` | 7 |
| `GangBiker1` | 8 |
| `GangBiker2` | 9 |
| `GangItalian` | 10 |
| `GangRussian` | 11 |
| `GangRussian2` | 12 |
| `GangIrish` | 13 |
| `GangJamaican` | 14 |
| `GangAfricanAmerican` | 15 |
| `GangKorean` | 16 |
| `GangChineseJapanese` | 17 |
| `GangPuertoRican` | 18 |
| `Dealer` | 19 |
| `Medic` | 20 |
| `Fire` | 21 |
| `Criminal` | 22 |
| `Bum` | 23 |
| `Prostitute` | 24 |
| `Special` | 25 |
| `Mission` | 26 |
| `Swat` | 27 |
| `Animal` | 28 |
| `Army` | 29 |

## PhysicsDampingType

enum `GTA.PhysicsDampingType`

| Name | Value |
| --- | --- |
| `LinearC` | 0 |
| `LinearV` | 1 |
| `LinearV2` | 2 |
| `AngularC` | 3 |
| `AngularV` | 4 |
| `AngularV2` | 5 |

## Pickup

class `GTA.Pickup` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`

### Constructors

- `public Pickup(int handle)`

### Properties

- `public bool IsCollected { get; }`
  - Gets if this `Pickup` has been collected.
- `public PickupObject Object { get; }`
- `public Vector3 Position { get; }`
  - The position of this `Pickup`.

### Methods

- `public virtual void Delete()`
  - Destroys this `Pickup`.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same pickup as this `Pickup`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same pickup as this `Pickup`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `Pickup` exists.
  - Returns: `true` if this `Pickup` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public bool ObjectExists()`
  - Determines if the object of this `Pickup` exists.
- `public static Pickup Create(PickupType type, Vector3 position, Vector3 rotation, PickupPlacementFlags placementFlags = 0, int amount = -1, EulerRotationOrder rotOrder = 2, Model customModel = null)`
- `public static Pickup Create(PickupType type, Vector3 position, PickupPlacementFlags placementFlags = 0, int amount = -1, Model customModel = null)`
- `public static bool op_Equality(Pickup left, Pickup right)`
  - Determines if two `Pickup`s refer to the same pickup.
  - `left`: The left `Pickup`.
  - `right`: The right `Pickup`.
  - Returns: `true` if `left` is the same pickup as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(Pickup value)`
  - Converts a `Pickup` to a native input argument.
- `public static bool op_Inequality(Pickup left, Pickup right)`
  - Determines if two `Pickup`s don't refer to the same pickup.
  - `left`: The left `Pickup`.
  - `right`: The right `Pickup`.
  - Returns: `true` if `left` is not the same pickup as `right`; otherwise, `false`.

## PickupObject

class `GTA.PickupObject` : `Prop`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Methods

- `public static PickupObject FromHandle(int handle)`

## PickupPlacementFlags

enum `GTA.PickupPlacementFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `Map` | 1 |
| `Fixed` | 2 |
| `Regenerates` | 4 |
| `SnapToGround` | 8 |
| `OrientToGround` | 16 |
| `LocalOnly` | 32 |
| `BlippedSimple` | 64 |
| `BlippedComplex` | 128 |
| `Upright` | 256 |
| `Rotate` | 512 |
| `FaceToPlayer` | 1024 |
| `HideInPhotos` | 2048 |
| `PlayerGift` | 4096 |
| `OnObject` | 8192 |
| `GlowInTeam` | 16384 |
| `AutoEquip` | 32768 |
| `CollectableInVehicle` | 65536 |
| `DisableWeaponHdModel` | 131072 |
| `ForceDeferredModel` | 262144 |

## PickupType

enum `GTA.PickupType`

165 values:

```text
CustomScript = 738282662
VehicleCustomScript = 2780351145
VehicleCustomScriptLowGlow = 1104334678
VehicleCustomScriptNoRotate = 83435908
Parachute = 1735599485
PortablePackage = 2158727964
PortablePackageLargeRadius = 1651898027
PortableCrateFixedInCar = 3993904883
PortableCrateFixedInCarSmall = 2817147086
PortableCrateFixedInCarWithPassengers = 2689501965
PortableCrateUnfixed = 1852930709
PortableCrateUnfixedInAirVehicleWithPassengers = 2431639355
PortableCrateUnfixedInAirVehicleWithPassengersUpright = 68603185
PortableCrateUnfixedInCar = 1263688126
PortableCrateUnfixedInCarSmall = 3285027633
PortableCrateUnfixedInCarWithPassengers = 79909481
PortableCrateUnfixedLowGlow = 2499414878
PortableFMContentMissionEntitySmall = 1610516839
PortableDLCVehiclePackage = 837436873
Camera = 3812460080
Submarine = 3889104844
Health = 2406513688
HealthSnack = 483577702
Armour = 1274757841
MoneyCase = 3463437675
MoneySecurityCase = 3732468094
MoneyVariable = 4263048111
MoneyMedBag = 341217064
MoneyPurse = 513448440
MoneyDepBag = 545862290
MoneyWallet = 1575005502
MoneyPaperBag = 1897726628
GangAttackMoney = 3782592152
WeaponPistol = 4189041807
WeaponPistolMk2 = 1234831722
WeaponCombatPistol = 2305275123
WeaponAPPistol = 996550793
WeaponPistol50 = 1817941018
WeaponStunGun = 4246083230
WeaponStunGunMultiplayer = 3025681922
WeaponSNSPistol = 3317114643
WeaponSNSPistolMk2 = 1038697149
WeaponHeavyPistol = 2633054488
WeaponVintagePistol = 3958938975
WeaponFlareGun = 3175998018
WeaponMarksmanPistol = 2329799797
WeaponRevolver = 1632369836
WeaponRevolverMk2 = 1835046764
WeaponDoubleActionRevolver = 990867623
WeaponUpNAtomizer = 3812817136
WeaponCeramicPistol = 1601729296
WeaponNavyRevolver = 3392027813
WeaponMetalDetector = 2226947771
WeaponPericoPistol = 2010690963
WeaponWM29Pistol = 3063083075
WeaponMicroSMG = 496339155
WeaponSMG = 978070226
WeaponSMGMk2 = 4012602256
WeaponAssaultSMG = 1948018762
WeaponCombatPDW = 2023061218
WeaponMachinePistol = 4123384540
WeaponMiniSMG = 3547474523
WeaponTacticalSMG = 2292608621
WeaponMG = 2244651441
WeaponCombatMG = 2995980820
WeaponCombatMGMk2 = 2837437579
WeaponGusenberg = 1393009900
WeaponUnholyHellbringer = 1959050722
WeaponAssaultRifle = 4080829360
WeaponAssaultRifleMk2 = 2173116527
WeaponCarbineRifle = 3748731225
WeaponCarbineRifleMk2 = 3185079484
WeaponAdvancedRifle = 2998219358
WeaponSpecialCarbine = 157823901
WeaponSpecialCarbineMk2 = 94531552
WeaponBullpupRifle = 2170382056
WeaponBullpupRifleMk2 = 2349845267
WeaponCompactRifle = 266812085
WeaponMilitaryRifle = 884272848
WeaponHeavyRifle = 1491498856
WeaponServiceCarbine = 2316705120
WeaponPumpShotgun = 2838846925
WeaponPumpShotgunMk2 = 1572258186
WeaponSawnoffShotgun = 2528383651
WeaponBullpupShotgun = 1850631618
WeaponAssaultShotgun = 2459552091
WeaponMusket = 1983869217
WeaponHeavyShotgun = 3201593029
WeaponDoubleBarrelShotgun = 4192395039
WeaponSweeperShotgun = 3167076850
WeaponCombatShotgun = 2074855423
WeaponSniperRifle = 4264178988
WeaponHeavySniper = 1765114797
WeaponMarksmanRifle = 127042729
WeaponMarksmanRifleMk2 = 2673201481
WeaponPrecisionRifle = 2821026276
WeaponGrenadeLauncher = 779501861
WeaponRPG = 1295434569
WeaponMinigun = 792114228
WeaponFirework = 582047296
WeaponRailgun = 3832418740
WeaponRailgunXmas3 = 4109932467
WeaponHomingLauncher = 3223238264
WeaponCompactGrenadeLauncher = 4041868857
WeaponCompactEMPLauncher = 4284229131
WeaponWidowmaker = 1000920287
WeaponGrenade = 1577485217
WeaponStickyBomb = 2081529176
WeaponSmokeGrenade = 483787975
WeaponMolotov = 768803961
WeaponPipeBomb = 2942905513
WeaponProximityMine = 1649373715
WeaponPetrolCan = 3332236287
WeaponPetrolcanSmallRadius = 3279969783
WeaponHazardousJerryCan = 2045070941
WeaponFertilizerCan = 3708929359
WeaponKnife = 663586612
WeaponNightstick = 1587637620
WeaponHammer = 693539241
WeaponBat = 2179883038
WeaponCrowbar = 2267924616
WeaponGolfclub = 2297080999
WeaponBottle = 4199656437
WeaponDagger = 3220073531
WeaponHatchet = 1311775952
WeaponKnuckleDuster = 4254904030
WeaponMachete = 3626334911
WeaponFlashlight = 3182886821
WeaponSwitchblade = 3722713114
WeaponBattleAxe = 158843122
WeaponPoolCue = 155106086
WeaponWrench = 3843167081
WeaponStoneHatchet = 3432031091
WeaponCandyCane = 1337246736
VehicleWeaponPistol = 2773149623
VehicleWeaponCombatPistol = 3500855031
VehicleWeaponAPPistol = 3431676165
VehicleWeaponPistol50 = 3550712678
VehicleWeaponMicroSMG = 3094015579
VehicleWeaponAssaultSMG = 1751145014
VehicleWeaponSawnoffShotgun = 772217690
VehicleWeaponGrenade = 2803366040
VehicleWeaponSmokeGrenade = 1705498857
VehicleWeaponStickyBomb = 746606563
VehicleWeaponMolotov = 2228647636
VehicleHealth = 160266735
VehicleHealthLowGlow = 4260266856
VehicleMoneyVariable = 1704231442
AmmoPistol = 544828034
AmmoFlareGun = 3759398940
AmmoSMG = 292537574
AmmoMG = 3730366643
AmmoRifle = 3837603782
AmmoShotgun = 2012476125
AmmoSniper = 3224170789
AmmoGrenadeLauncher = 2283450536
AmmoRPG = 2223210455
AmmoMinigun = 4065984953
AmmoHomingLauncher = 1548844439
AmmoFirework = 4180625516
AmmoFireworkMP = 1613316560
AmmoMissileMP = 4187887056
AmmoBulletMP = 1426343849
AmmoGrenadeLauncherMP = 2753668402
AmmoEMPLauncher = 2308161313
```

## Player

class `GTA.Player` : `INativeValue`

### Properties

- `public bool CanControlCharacter { get; set; }`
  - Gets or sets a value indicating whether this `Player` can control its `Ped`.
- `public bool CanControlRagdoll { set; }`
  - Sets a value indicating whether this `Player` can control ragdoll.
- `public bool CanLeaveParachuteSmokeTrail { set; }`
  - Sets a value indicating whether this `Player` can leave a parachute smoke trail.
- `public bool CanStartMission { get; }`
  - Gets a value indicating whether this `Player` can start a mission.
- `public bool CanUseCover { set; }`
  - Sets a value indicating whether this `Player` can use cover.
- `public Ped Character { get; }`
  - Gets the `Ped` this `Player` is controlling.
- `public Vector3 ClosestFreeAimTargetPos { get; }`
- `public bool DispatchsCops { get; set; }`
  - **Obsolete.** Use `GTA.Wanted.DispatchesCopsForPlayer` instead via the property `GTA.Player.Wanted`.
  - Sets a value indicating whether cops will be dispatched for this `Player`
- `public bool ForcedAim { get; set; }`
  - Sets a value indicating whether the player is forced to aim.
- `public int Handle { get; }`
- `public bool HasSpecialAbility { get; }`
- `public bool IgnoredByEveryone { get; set; }`
  - Sets a value indicating whether this `Player` is ignored by everyone.
- `public bool IgnoredByPolice { get; set; }`
  - Sets a value indicating whether this `Player` is ignored by the police.
- `public bool IsAiming { get; }`
  - Gets a value indicating whether this `Player` is aiming.
- `public bool IsAimingInAccurateMode { get; }`
- `public bool IsAlive { get; }`
  - Gets a value indicating whether this `Player` is alive.
- `public bool IsClimbing { get; }`
  - Gets a value indicating whether this `Player` is climbing.
- `public bool IsDead { get; }`
  - Gets a value indicating whether this `Player` is dead.
- `public bool IsInvincible { get; set; }`
  - Gets or sets a value indicating whether this `Player` is invincible.
- `public bool IsPlaying { get; }`
  - Gets a value indicating whether this `Player` is playing.
- `public bool IsPressingHorn { get; }`
  - Gets a value indicating whether this `Player` is pressing a horn.
- `public bool IsRidingTrain { get; }`
  - Gets a value indicating whether this `Player` is riding a train.
- `public bool IsSpecialAbilityActive { get; }`
  - Gets a value indicating whether this `Player` is using their special ability.
- `public bool IsSpecialAbilityEnabled { get; set; }`
  - Gets or sets a value indicating whether this `Player` can use their special ability.
- `public bool IsTargetingAnything { get; }`
  - Gets a value indicating whether this `Player` is targeting anything.
- `public Vector3 LastLockOnTargetPos { get; }`
- `public Vehicle LastVehicle { get; }`
  - Gets the last `Vehicle` this `Player` used.
- `public Entity LockedOnEntity { get; }`
  - Gets the `Entity` this `Player` is locking on when they are aiming with a firearm using a controller or they are locking on unarmed or with a melee weapon.
  - Returns: The `Entity` if this `Player` is automatically locking on any `Entity`; otherwise, `null`
- `public int MaxArmor { get; set; }`
  - Gets or sets the maximum amount of armor this `Player` can carry.
- `public int MaxHealth { get; set; }`
- `public float MaxSpecialAbilityMeter { get; set; }`
- `public IntPtr MemoryAddress { get; }`
- `public int Money { get; set; }`
  - Gets or sets how much money this `Player` has. Only works if current player is `Michael`, `Franklin` or `Trevor`
- `public string Name { get; }`
  - Gets the Social Club name of this `Player`.
- `public ulong NativeValue { get; set; }`
- `public Color ParachuteSmokeTrailColor { get; set; }`
  - Gets or sets the color of the parachute smoke trail for this `Player`.
- `public ParachuteTint PrimaryParachuteTint { get; set; }`
  - Gets or sets the primary parachute tint for this `Player`.
- `public float RemainingSpecialAbilityMeter { get; set; }`
- `public float RemainingSprintStamina { get; }`
  - Gets how much sprint stamina this `Player` currently has.
- `public float RemainingSprintTime { get; }`
  - Gets how long this `Player` can remain sprinting for.
- `public float RemainingUnderwaterTime { get; }`
  - Gets how long this `Player` can stay underwater before they start losing health.
- `public ParachuteTint ReserveParachuteTint { get; set; }`
  - Gets or sets the reserve parachute tint for this `Player`.
- `public Building TargetedBuilding { get; }`
- `public Entity TargetedEntity { get; }`
  - Gets the `Entity` this `Player` is free aiming.
  - Returns: The `Entity` if this `Player` is free aiming any `Entity`; otherwise, `null`
- `public Wanted Wanted { get; }`
- `public Vector3 WantedCenterPosition { get; set; }`
  - Gets or sets the wanted center position for this `Player`.
- `public int WantedLevel { get; set; }`
  - Gets or sets the wanted level for this `Player`.

### Methods

- `public void ActivateSpecialAbility()`
- `public bool ChangeModel(Model model)`
  - Attempts to change the `Model` of this `Player`.
  - `model`: The `Model` to change this `Player` to.
  - Returns: `true` if the change was successful; otherwise, `false`.
- `public void ChargeSpecialAbility(int absoluteAmount, bool ignoreActive)`
- `public void ChargeSpecialAbility(int absoluteAmount)`
  - Charges the special ability for this `Player`.
  - `absoluteAmount`: The absolute amount.
- `public void ChargeSpecialAbility(float normalizedRatio, bool ignoreActive)`
- `public void ChargeSpecialAbility(float normalizedRatio)`
  - Charges the special ability for this `Player`.
  - `normalizedRatio`: The amount between `0.0f` and `1.0f`
- `public void DeactivateSpecialAbility()`
- `public void DeactivateSpecialAbilityInstantly()`
- `public void DepleteSpecialAbility()`
  - Depletes the special ability for this `Player`.
- `public void DepleteSpecialAbility(bool ignoreActive)`
- `public void DisableFiringThisFrame()`
  - Prevents this `Player` firing this frame.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same player as this `Player`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same player as this `Player`; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public bool IsTargeting(Entity entity)`
  - Determines whether this `Player` is targeting the specified `Entity`.
  - `entity`: The `Entity` to check.
  - Returns: `true` if this `Player` is targeting the specified `Entity`; otherwise, `false`.
- `public void RefillSpecialAbility()`
  - Refills the special ability for this `Player`.
- `public void RefillSpecialAbility(bool ignoreActive)`
- `public void SetControlState(bool setControlOn, SetPlayerControlFlags flags = 0)`
- `public void SetExplosiveAmmoThisFrame()`
  - Makes this `Player` shoot explosive bullets this frame.
- `public void SetExplosiveMeleeThisFrame()`
  - Makes this `Player` have an explosive melee attack this frame.
- `public void SetFireAmmoThisFrame()`
  - Makes this `Player` shoot fire bullets this frame.
- `public void SetMayNotEnterAnyVehicleThisFrame()`
  - Blocks this `Player` from entering any `Vehicle` this frame.
- `public void SetMayOnlyEnterThisVehicleThisFrame(Vehicle vehicle)`
  - Only lets this `Player` enter a specific `Vehicle` this frame.
  - `vehicle`: The `Vehicle` this `Player` is allowed to enter.
- `public void SetRunSpeedMultThisFrame(float mult)`
  - Sets the run speed multiplier for this `Player` this frame.
  - `mult`: The factor - min: `0.0f`, default: `1.0f`, max: `1.499f`.
- `public void SetSuperJumpThisFrame()`
  - Lets this `Player` jump really high this frame.
- `public void SetSwimSpeedMultThisFrame(float mult)`
  - Sets the swim speed multiplier for this `Player` this frame.
  - `mult`: The factor - min: `0.0f`, default: `1.0f`, max: `1.499f`.
- `public static bool op_Equality(Player left, Player right)`
  - Determines if two `Player`s refer to the same player.
  - `left`: The left `Player`.
  - `right`: The right `Player`.
  - Returns: `true` if `left` is the same player as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(Player value)`
  - Converts a `Player` to a native input argument.
- `public static bool op_Inequality(Player left, Player right)`
  - Determines if two `Player`s don't refer to the same player.
  - `left`: The left `Player`.
  - `right`: The right `Player`.
  - Returns: `true` if `left` is not the same player as `right`; otherwise, `false`.

## PlayerTargetingMode

enum `GTA.PlayerTargetingMode`

| Name | Value |
| --- | --- |
| `AssistedAimFull` | 0 |
| `AssistedAimPartial` | 1 |
| `FreeAimAssisted` | 2 |
| `FreeAim` | 3 |

## PoolObject

abstract class `GTA.PoolObject` : `INativeValue`, `IDeletable`, `IExistable`

An object that resides in one of the available object pools.

### Constructors

- `protected PoolObject(int handle)`

### Properties

- `public int Handle { get; set; }`
  - The handle of the object.
- `public ulong NativeValue { get; set; }`
  - The handle of the object translated to a native value.

### Methods

- `public abstract void Delete()`
- `public abstract bool Exists()`

## Projectile

class `GTA.Projectile` : `Prop`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Properties

- `public Ped Owner { get; }`
  - **Obsolete.** The Projectile.Owner is obsolete in the v3 API because the actual owner can be a Vehicle, use Projectile.OwnerEntity instead.
  - Gets the `Ped` this `Projectile` belongs to. Can be `null` or a `Ped` instance whose handle is for `Vehicle`, which is not valid as a `Ped` instance.
- `public Entity OwnerEntity { get; }`
  - Gets the `Entity` this `Projectile` belongs to. Can be `null`.
- `public WeaponHash WeaponHash { get; }`
  - Gets the `WeaponHash` this `Projectile` was fired with.

### Methods

- `public void Explode()`
  - Explodes this `Projectile`. Note that calling this method does not necessarily delete this `Projectile` due to the weapon configuration.
- `public static Projectile FromHandle(int handle)`
  - Get a `Projectile` instance by its handle
  - Returns: Null if not found or the entity is not a `Prop`, otherwise, a `Projectile`

## ProjectileRocket

class `GTA.ProjectileRocket` : `Projectile`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Properties

- `public bool ApplyThrust { get; set; }`
- `public Vector3 CachedDirection { get; set; }`
- `public Vector3 CachedTargetPosition { get; set; }`
- `public Vector3 FlightModelInput { get; set; }`
- `public float FlightModelInputPitch { get; set; }`
- `public float FlightModelInputRoll { get; set; }`
- `public float FlightModelInputYaw { get; set; }`
- `public bool IsAccurate { get; set; }`
- `public bool IsRedirected { get; }`
- `public Vector3 LaunchDirection { get; set; }`
- `public float LauncherSpeed { get; set; }`
- `public bool LerpToLaunchDirection { get; set; }`
- `public bool OnFootHomingWeaponLockedOn { get; set; }`
- `public bool StopHoming { get; set; }`
- `public Entity Target { get; set; }`
- `public float TimeBeforeHoming { get; set; }`
- `public float TimeBeforeHomingAngleBreak { get; set; }`
- `public float TimeSinceLaunch { get; set; }`
- `public bool WasHoming { get; set; }`

### Methods

- `public static ProjectileRocket FromHandle(int handle)`

## ProjectileThrown

class `GTA.ProjectileThrown` : `Projectile`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Methods

- `public static ProjectileThrown FromHandle(int handle)`

## Prop

class `GTA.Prop` : `Entity`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Properties

- `public bool HasBeenDetachedFromParentEntity { get; }`
- `public Entity ParentEntityDetachedFrom { get; }`

### Methods

- `public Projectile AsProjectile()`
- `public ProjectileRocket AsProjectileRocket()`
- `public ProjectileThrown AsProjectileThrown()`
- `public bool Exists()`
  - Determines if this `Prop` exists. You should ensure `Prop`s still exist before manipulating them or getting some values for them on every tick, since some native functions may crash the game if invalid entity handles are passed.
  - Returns: `true` if this `Prop` exists; otherwise, `false`.
- `public static Prop Create(Model model, Vector3 position, Vector3 rotation, bool dynamic, bool placeOnGround)`
- `public static Prop Create(Model model, Vector3 position, bool dynamic, bool placeOnGround)`
- `public static Prop CreateNoOffset(Model model, Vector3 position, Vector3 rotation, bool dynamic)`
- `public static Prop CreateNoOffset(Model model, Vector3 position, bool dynamic)`

## RadioStation

enum `GTA.RadioStation`

| Name | Value |
| --- | --- |
| `LosSantosRockRadio` | 0 |
| `NonStopPopFM` | 1 |
| `RadioLosSantos` | 2 |
| `ChannelX` | 3 |
| `WestCoastTalkRadio` | 4 |
| `RebelRadio` | 5 |
| `SoulwaxFM` | 6 |
| `EastLosFM` | 7 |
| `WestCoastClassics` | 8 |
| `BlaineCountyRadio` | 9 |
| `TheBlueArk` | 10 |
| `WorldWideFM` | 11 |
| `FlyloFM` | 12 |
| `TheLowdown` | 13 |
| `RadioMirrorPark` | 14 |
| `Space` | 15 |
| `VinewoodBoulevardRadio` | 16 |
| `SelfRadio` | 17 |
| `TheLab` | 18 |
| `BlondedLosSantos` | 19 |
| `LosSantosUndergroundRadio` | 20 |
| `iFruitRadio` | 21 |
| `StillSlippingLosSantos` | 22 |
| `KultFM` | 23 |
| `MusicLocker` | 24 |
| `MediaPlayer` | 25 |
| `MotomamiLosSantos` | 26 |
| `RadioOff` | 255 |

## RagdollBlockingFlags

enum `GTA.RagdollBlockingFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `BulletImpact` | 1 |
| `VehicleImpact` | 2 |
| `Fire` | 4 |
| `Electrocution` | 8 |
| `PlayerImpact` | 16 |
| `Explosion` | 32 |
| `ImpactObject` | 64 |
| `Melee` | 128 |
| `RubberBullet` | 256 |
| `Falling` | 512 |
| `WaterJet` | 1024 |
| `Drowning` | 2048 |
| `AllowBlockDeadPed` | 4096 |
| `PlayerBump` | 8192 |
| `PlayerRagdollBump` | 16384 |
| `PedRagdollBump` | 32768 |
| `VehicleGrab` | 65536 |
| `SmokeGrenade` | 131072 |

## RagdollComponent

enum `GTA.RagdollComponent`

| Name | Value |
| --- | --- |
| `Buttocks` | 0 |
| `ThighLeft` | 1 |
| `ShinLeft` | 2 |
| `FootLeft` | 3 |
| `ThighRight` | 4 |
| `ShinRight` | 5 |
| `FootRight` | 6 |
| `Spine0` | 7 |
| `Spine1` | 8 |
| `Spine2` | 9 |
| `Spine3` | 10 |
| `ClavicleLeft` | 11 |
| `UpperArmLeft` | 12 |
| `LowerArmLeft` | 13 |
| `HandLeft` | 14 |
| `ClavicleRight` | 15 |
| `UpperArmRight` | 16 |
| `LowerArmRight` | 17 |
| `HandRight` | 18 |
| `Neck` | 19 |
| `Head` | 20 |

## RagdollFallType

enum `GTA.RagdollFallType`

| Name | Value |
| --- | --- |
| `Male` | 0 |
| `Female` | 1 |
| `MaleLarge` | 2 |
| `FallToDeath` | 4 |

## RagdollType

enum `GTA.RagdollType`

| Name | Value | Description |
| --- | --- | --- |
| `Relax` | 0 | `Ped`s will fall with their muscle relax, just like when `Ped`s' healths are set to zero and get killed by setting the healths. |
| `ScriptControl` | 1 | You can control `Ped`s' ragdoll behaviors by additional configrations. Consider using the `Euphoria` class for advanced and easier ragdoll configrations. |
| `Balance` | 2 | `Ped`s will try to balance. |
| `Normal` | 0 |  |
| `StiffLegs` | 1 |  |
| `NarrowLegs` | 2 |  |
| `WideLegs` | 3 |  |

## RaycastResult

struct `GTA.RaycastResult`

### Constructors

- `public RaycastResult(int handle)`

### Properties

- `public bool DidHit { get; }`
  - Gets a value indicating whether this ray cast collided with anything.
- `public Entity HitEntity { get; }`
  - Gets the `Entity` this ray cast collided with. Returns `null` if the ray cast didn't collide with any `Entity`.
- `public Vector3 HitPosition { get; }`
  - Gets the world coordinates where this ray cast collided. Returns `Zero` if the ray cast didn't collide with anything.
- `public MaterialHash MaterialHash { get; }`
  - Gets a hash indicating the material type of what this ray cast collided with. Returns `None` if the ray cast didn't collide with anything.
- `public int Result { get; }`
  - Gets the result code.
- `public Vector3 SurfaceNormal { get; }`
  - Gets the normal of the surface where this ray cast collided. Returns `Zero` if the ray cast didn't collide with anything.

## Relationship

enum `GTA.Relationship`

| Name | Value | Description |
| --- | --- | --- |
| `Companion` | 0 | The correct relationship name for this enum would be `Respect`. |
| `Respect` | 1 | The correct relationship name for this enum would be `Like`. |
| `Like` | 2 | The correct relationship name for this enum would be `Ignore`. |
| `Neutral` | 3 | The correct relationship name for this enum would be `Dislike`. |
| `Dislike` | 4 | The correct relationship name for this enum would be `Wanted`. Will be used for cops towards the player relationship group when the player is wanted. |
| `Hate` | 5 |  |
| `Dead` | 6 |  |
| `Pedestrians` | 255 | The correct relationship name for this enum would be `None`. |

## RelationshipGroup

struct `GTA.RelationshipGroup` : `INativeValue`, `IEquatable<RelationshipGroup>`

### Constructors

- `public RelationshipGroup(RelationshipGroupHash hash)`
- `public RelationshipGroup(int hash)`
- `public RelationshipGroup(uint hash)`

### Properties

- `public int Hash { get; }`
  - Gets the hash for this `RelationshipGroup`.
- `public ulong NativeValue { get; set; }`
  - Gets the native representation of this `RelationshipGroup`.

### Methods

- `public void ClearRelationshipBetweenGroups(RelationshipGroup targetGroup, Relationship relationship, bool bidirectionally = false)`
- `public bool Equals(RelationshipGroup group)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public Relationship GetRelationshipBetweenGroups(RelationshipGroup targetGroup)`
- `public void Remove()`
- `public void SetRelationshipBetweenGroups(RelationshipGroup targetGroup, Relationship relationship, bool bidirectionally = false)`
- `public virtual string ToString()`
- `public static bool op_Equality(RelationshipGroup left, RelationshipGroup right)`
- `public static InputArgument op_Implicit(RelationshipGroup value)`
- `public static RelationshipGroup op_Implicit(RelationshipGroupHash source)`
- `public static RelationshipGroup op_Implicit(int source)`
- `public static RelationshipGroup op_Implicit(string source)`
- `public static RelationshipGroup op_Implicit(uint source)`
- `public static bool op_Inequality(RelationshipGroup left, RelationshipGroup right)`

## RelationshipGroupHash

enum `GTA.RelationshipGroupHash`

| Name | Value |
| --- | --- |
| `Player` | 1862763509 |
| `CivilianMale` | 45677184 |
| `CivilianFemale` | 1191392768 |
| `Cop` | 2761840924 |
| `SecurityGuard` | 4111159735 |
| `PrivateSecurity` | 2827152215 |
| `Fireman` | 4230784871 |
| `AmbientGangLost` | 2429016672 |
| `AmbientGangMexican` | 296331235 |
| `AmbientGangFamily` | 1166638144 |
| `AmbientGangBallas` | 3261945386 |
| `AmbientGangMarabunte` | 2037579709 |
| `AmbientGangCult` | 2017343592 |
| `AmbientGangSalva` | 2473492219 |
| `AmbientGangWeiCheng` | 1782292358 |
| `AmbientGangHillbilly` | 3008990876 |
| `HatesPlayer` | 2229074605 |
| `Hen` | 3222287865 |
| `WildAnimal` | 2078959127 |
| `Shark` | 580191176 |
| `Cougar` | 3457367416 |
| `NoRelationship` | 4208871491 |
| `Army` | 3822679795 |
| `GuardDog` | 1378588234 |
| `AggressiveInvestigate` | 3947353312 |
| `Medic` | 2957130400 |
| `Cat` | 1157867945 |
| `FamilyMichael` | 2235626914 |
| `FamilyFranklin` | 2034589087 |
| `FamilyTrevor` | 722518339 |

## RequireScript

class `GTA.RequireScript` : `Attribute`, `_Attribute`

### Constructors

- `public RequireScript(Type dependency)`

### Properties

- `public Type Dependency { get; }`

## Rope

class `GTA.Rope` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`

### Constructors

- `public Rope(int handle)`

### Properties

- `public float Length { get; set; }`
  - Gets or sets the length of this `Rope`.
- `public int VertexCount { get; }`
  - Gets the number of vertices of this `Rope`.

### Methods

- `public void ActivatePhysics()`
  - Activates physics interactions for this `Rope`.
- `public void Attach(Entity entity, Vector3 position)`
  - Attaches a single `Entity` to this `Rope` at the specified `position`.
  - `entity`: The entity to attach.
  - `position`: The position in world coordinates to attach to.
- `public void Attach(Entity entity)`
  - Attaches a single `Entity` to this `Rope`.
  - `entity`: The entity to attach.
- `public void Connect(Entity entity1, Entity entity2, float length)`
  - Connects two `Entity`s with this `Rope`.
  - `entity1`: The first entity to attach.
  - `entity2`: The second entity to attach.
  - `length`: The rope length.
- `public void Connect(Entity entity1, Vector3 position1, Entity entity2, Vector3 position2, float length)`
  - Connects two `Entity`s with this `Rope` at the specified positions.
  - `entity1`: The first entity to attach.
  - `entity2`: The second entity to attach.
  - `position1`: The position in world coordinates to attach the first entity to.
  - `position2`: The position in world coordinates to attach the second entity to.
  - `length`: The rope length.
- `public virtual void Delete()`
  - Destroys this `Rope`.
- `public void Detach(Entity entity)`
  - Detaches a single `Entity` from this `Rope`.
  - `entity`: The entity to detach.
- `public virtual bool Equals(object obj)`
  - Determines if an `Object` refers to the same rope as this `Rope`.
  - `obj`: The `Object` to check.
  - Returns: `true` if the `obj` is the same rope as this `Rope`; otherwise, `false`.
- `public virtual bool Exists()`
  - Determines if this `Rope` exists.
  - Returns: `true` if this `Rope` exists; otherwise, `false`.
- `public virtual int GetHashCode()`
- `public Vector3 GetVertexCoord(int vertex)`
  - Gets the world coordinates of a single vertex of this `Rope`.
  - `vertex`: The index of the vertex.
  - Returns: The position of the vertex in world coordinates.
- `public void PinVertex(int vertex, Vector3 position)`
  - Pin a vertex of this `Rope` to a `position`.
  - `vertex`: The index of the vertex.
  - `position`: The position in world coordinates to pin to.
- `public void UnpinVertex(int vertex)`
  - Unpin a vertex of this `Rope`.
  - `vertex`: The index of the vertex.
- `public static bool op_Equality(Rope left, Rope right)`
  - Determines if two `Rope`s refer to the same rope.
  - `left`: The left `Rope`.
  - `right`: The right `Rope`.
  - Returns: `true` if `left` is the same rope as `right`; otherwise, `false`.
- `public static InputArgument op_Implicit(Rope value)`
  - Converts a `Rope` to a native input argument.
- `public static bool op_Inequality(Rope left, Rope right)`
  - Determines if two `Rope`s don't refer to the same rope.
  - `left`: The left `Rope`.
  - `right`: The right `Rope`.
  - Returns: `true` if `left` is not the same rope as `right`; otherwise, `false`.

## RopeType

enum `GTA.RopeType`

| Name | Value |
| --- | --- |
| `ThickRope` | 4 |
| `ThinMetalWire` | 5 |

## Scaleform

class `GTA.Scaleform` : `IDisposable`, `INativeValue`

A class which handles rendering of Scaleform elements.

### Constructors

- `public Scaleform(string scaleformID)`
  - **Obsolete.** The Scaleform constructor with a string parameter is obsolete. Use Scaleform.RequestMovie instead.

### Properties

- `public int Handle { get; }`
- `public bool IsLoaded { get; }`
- `public bool IsValid { get; }`
- `public ulong NativeValue { get; set; }`

### Methods

- `public void CallFunction(string function, params object[] arguments)`
- `public int CallFunctionReturn(string function, params object[] arguments)`
- `public void Dispose()`
- `public void Render2D()`
- `public void Render2DMasked(Scaleform background)`
- `public void Render2DScreenSpace(PointF position, PointF size)`
- `public void Render3D(Vector3 position, Vector3 rotation, Vector3 scale)`
- `public void Render3DAdditive(Vector3 position, Vector3 rotation, Vector3 scale)`
- `public static Scaleform FromHandle(int handle)`
- `public static InputArgument op_Implicit(Scaleform value)`
- `public static Scaleform RequestMovie(string fileName)`
- `public static Scaleform RequestMovieIgnoreSuperWidescreenAdjustment(string fileName)`
- `public static Scaleform RequestMovieSkipRenderWhilePaused(string fileName)`

## ScaleformArgumentTXD

class `GTA.ScaleformArgumentTXD`

### Constructors

- `public ScaleformArgumentTXD(string s)`

## Script

abstract class `GTA.Script`

A base class for all user scripts to inherit. Only scripts that inherit directly from this class and have a default (parameterless) public constructor will be detected and started.

### Constructors

- `public Script()`

### Properties

- `public string BaseDirectory { get; }`
  - Gets the Directory where this `Script` is stored.
- `public string Filename { get; }`
  - Gets the filename of this `Script`.
- `protected int Interval { get; set; }`
  - Gets or sets the interval in ms between `Tick` for this `Script`. Default value is 0 meaning the event will execute once each frame.
- `public bool IsExecuting { get; }`
  - Checks if this `Script` is executing.
- `public bool IsPaused { get; }`
  - Checks if this `Script` is paused.
- `public bool IsRunning { get; }`
  - Checks if this `Script` is running.
- `public string Name { get; }`
  - Gets the name of this `Script`.
- `public ScriptSettings Settings { get; }`
  - Gets an INI file associated with this `Script`. The File will be in the same location as this `Script` but with an extension of ".ini". Use this to save and load settings for this `Script`.

### Methods

- `public void Abort()`
  - Aborts execution of this `Script`.
- `public string GetRelativeFilePath(string filePath)`
  - Gets the full file path for a file relative to this `Script`. e.g: `GetRelativeFilePath("ScriptFiles\texture1.png")` may return `"C:\Program Files\Rockstar Games\Grand Theft Auto V\scripts\ScriptFiles\texture1.png"`.
  - `filePath`: The file path relative to the location of this `Script`.
- `public void Pause()`
  - Pause execution of this `Script`.
- `public void Resume()`
  - Starts execution of this `Script` after it has been Paused.
- `public virtual string ToString()`
  - Returns a string that represents this `Script`.
- `public static T InstantiateScript<T>()`
  - Spawns a new `Script` instance of the specified type.
- `public static void Wait(int ms)`
  - Pauses execution of the `Script` for a specific amount of time. Must be called inside the main script loop (the `Tick` event or any sub methods called from it).
  - `ms`: The time in milliseconds to pause for.
- `public static void Yield()`
  - Yields the execution of the script for 1 frame.

### Events

- `public event EventHandler Aborted`
  - An event that is raised when this `Script` gets aborted for any reason. This should be used for cleaning up anything created during this `Script`.
- `public event KeyEventHandler KeyDown`
  - An event that is raised when a key is first pressed. The `KeyEventArgs` contains the key that was pressed.
- `public event KeyEventHandler KeyUp`
  - An event that is raised when a key is lifted. The `KeyEventArgs` contains the key that was lifted.
- `public event EventHandler Tick`
  - An event that is raised every tick of the script. Put code that needs to be looped each frame in here.

## ScriptAttributes

class `GTA.ScriptAttributes` : `Attribute`, `_Attribute`

### Constructors

- `public ScriptAttributes()`

### Properties

- `public AbortScriptMode NativeCallResetsTimeout { get; set; }`

### Fields

- `public string Author`
- `public bool NoDefaultInstance`
- `public bool NoScriptThread`
- `public string SupportURL`

## ScriptCameraDirector

static class `GTA.ScriptCameraDirector`

### Properties

- `public static bool IsInterpolatingFromScriptCam { get; }`
- `public static bool IsInterpolatingToScriptCam { get; }`
- `public static Camera RenderingCam { get; }`

### Methods

- `public static void StartRendering()`
- `public static void StartRenderingWithInterp(int interpDuration = 3000, bool shouldLockInterpolationSourceFrame = true)`
- `public static void StopRendering(bool shouldApplyAcrossAllThreads = false)`
- `public static void StopRenderingUsingCatchUp(bool shouldApplyAcrossAllThreads = false, float distanceToBlend = 0, CamSplineSmoothingMode blendType = 3)`
- `public static void StopRenderingWithInterp(int interpDuration = 3000, bool shouldLockInterpolationSourceFrame = true, bool shouldApplyAcrossAllThreads = false)`

## ScriptedCameraNameHash

enum `GTA.ScriptedCameraNameHash`

| Name | Value |
| --- | --- |
| `DefaultScriptedCamera` | 26379945 |
| `DefaultScriptedFlyCamera` | 4292966205 |
| `DefaultSplineCamera` | 180543640 |
| `DefaultAnimatedCamera` | 964613260 |
| `DefaultTransitionCamera` | 3484689037 |
| `TimedSplineCamera` | 1775630800 |
| `RoundedSplineCamera` | 457439121 |
| `SmoothedSplineCamera` | 4175434708 |
| `CustomTimedSplineCamera` | 1665938388 |

## ScriptedVehicleLightSetting

enum `GTA.ScriptedVehicleLightSetting`

| Name | Value |
| --- | --- |
| `NoVehicleLightOverride` | 0 |
| `ForceVehicleLightsOff` | 1 |
| `ForceVehicleLightsOn` | 2 |
| `SetVehicleLightsOn` | 3 |
| `SetVehicleLightsOff` | 4 |

## ScriptFire

class `GTA.ScriptFire` : `PoolObject`, `INativeValue`, `IDeletable`, `IExistable`

### Methods

- `public virtual void Delete()`
- `public virtual bool Exists()`
- `public static ScriptFire FromHandle(int handle)`

## ScriptSettings

class `GTA.ScriptSettings`

### Methods

- `public void Clear()`
- `public bool ContainsKey(string sectionName, string keyName)`
- `public bool ContainsSection(string section)`
- `public string[] GetAllKeyNames(string sectionName)`
- `public string[] GetAllSectionNames()`
- `public T[] GetAllValues<T>(string sectionName, string keyName, IFormatProvider formatProvider)`
  - Reads all the values at a specified key and section from this `ScriptSettings`.
  - `section`: The section where the value is.
  - `name`: The name of the key the values are saved at.
- `public T[] GetAllValues<T>(string section, string name)`
  - Reads all the values at a specified key and section from this `ScriptSettings`.
  - `section`: The section where the value is.
  - `name`: The name of the key the values are saved at.
- `public T GetValue<T>(string sectionName, string keyName, T defaultValue, IFormatProvider formatProvider)`
  - Reads a value from this `ScriptSettings`.
  - `section`: The section where the value is.
  - `name`: The name of the key the value is saved at.
  - `defaultvalue`: The fall-back value if the key doesn't exist or casting to type `T` fails.
  - Returns: The value at `` in ``.
- `public T GetValue<T>(string section, string name, T defaultvalue)`
  - Reads a value from this `ScriptSettings`.
  - `section`: The section where the value is.
  - `name`: The name of the key the value is saved at.
  - `defaultvalue`: The fall-back value if the key doesn't exist or casting to type `T` fails.
  - Returns: The value at `` in ``.
- `public bool RemoveKey(string sectionName, string keyName)`
- `public bool RemoveSection(string sectionName)`
- `public bool Save()`
  - Saves this `ScriptSettings` to file.
  - Returns: `true` if the file saved successfully; otherwise, `false`
- `public void SetValue<T>(string sectionName, string keyName, T value, string format, IFormatProvider formatProvider)`
  - Sets a value in this `ScriptSettings`.
  - `section`: The section where the value is.
  - `name`: The name of the key the value is saved at.
  - `value`: The value to set the key to.
- `public void SetValue<T>(string section, string name, T value)`
  - Sets a value in this `ScriptSettings`.
  - `section`: The section where the value is.
  - `name`: The name of the key the value is saved at.
  - `value`: The value to set the key to.
- `public bool TryGetValue<T>(string sectionName, string keyName, out T value, IFormatProvider formatProvider)`
- `public bool TryGetValue<T>(string sectionName, string keyName, out T value)`
- `public static ScriptSettings Load(string filename)`
  - Loads a `ScriptSettings` from the specified file.
  - `filename`: The filename to load the settings from.

## ScriptSound

class `GTA.ScriptSound` : `IEquatable<ScriptSound>`

### Properties

- `public int Id { get; }`
- `public bool IsNull { get; }`

### Methods

- `public bool Equals(ScriptSound other)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public bool HasFinished()`
- `public void PlaySound(string soundName, string setName, bool enableOnReplay = true)`
- `public void PlaySoundFromEntity(Entity entity, string soundName, string setName = null)`
- `public void PlaySoundFromPosition(Vector3 position, string soundName, string setName = null, bool isExteriorLoc = false)`
- `public void PlaySoundFrontend(string soundName, string setName, bool enableOnReplay = true)`
- `public void Release()`
- `public void Stop()`
- `public void UpdatePosition(Vector3 position)`
- `public void UpdatePosition(string variableName, float variableValue)`
- `public static bool op_Equality(ScriptSound left, ScriptSound right)`
- `public static InputArgument op_Implicit(ScriptSound value)`
- `public static bool op_Inequality(ScriptSound left, ScriptSound right)`

## ScriptTaskNameHash

enum `GTA.ScriptTaskNameHash`

154 values:

```text
Any = 1435919172
Invalid = 2166240316
Pause = 63541484
StandStill = 3312640106
Jump = 608260166
Cower = 474215631
HandsUp = 2775823996
Duck = 490823532
EnterVehicle = 2500551826
LeaveVehicle = 451360105
VehicleDriveToCoord = 2477085294
VehicleDriveToCoordLongrange = 567490903
VehicleDriveWander = 4036695475
GoStraightToCoord = 2106541073
GoStraightToCoordRelativeToEntity = 2028736502
AchieveHeading = 1920390111
FollowPointRoute = 2989642351
GoToEntity = 1227113341
SmartFleePoint = 4043842218
SmartFleePed = 1805844857
WanderStandard = 3148068810
FollowNavMeshToCoord = 713668775
GoToCoordAnyMeans = 2470026873
PerformSequence = 242628503
LeaveAnyVehicle = 3466132403
AimGunScripted = 208245535
AimGunAtEntity = 1630799643
GoToCoordWhileShooting = 2475155115
TurnPedToFaceEntity = 3419293077
AimGunAtCoord = 1237250926
ShootAtCoord = 3641635208
ShuffleToNextVehicleSeat = 355471868
EveryoneLeaveVehicle = 2775183686
GoToEntityOffset = 2279858344
TurnPedToFaceCoord = 1464580341
DrivePointRoute = 3135320368
VehicleTempAction = 2176111930
BringVehicleToHalt = 815848505
VehicleMission = 3021937204
DriveBy = 2104565373
UseMobilePhone = 936589729
WarpPedIntoVehicle = 3159710621
ShootAtEntity = 167901368
Climb = 3087203786
PerformSequenceFromProgress = 1418067348
GoToEntityAiming = 2524881436
SetPedDecisionMaker = 1314604348
SetPedDefensiveArea = 10551752
PedSlideToCoord = 1045468327
DrivePointRouteAdvanced = 3932828223
PedSlideToCoordAndPlayAnim = 2315874548
PlayAnim = 2277090178
ArrestPed = 1392476864
Combat = 780511057
CombatTimed = 4075035274
SeekCoverFromPos = 2809792197
SeekCoverFromPed = 1910705116
SeekCoverToCoverPoint = 2578426019
ToggleDuck = 255558996
GuardDefensiveArea = 3747564455
PickupAndCarryObject = 2298630181
SeekCoverToCoords = 1812035420
GuardAngledDefensiveArea = 2226055072
StandGuard = 3633261790
ClimbLadder = 1715483475
GuardSphereDefensiveArea = 568906980
StartScenarioInPlace = 993674639
StartScenarioAtPosition = 3196503398
StartVehicleScenario = 2248240696
PutPedDirectlyIntoCover = 2335118350
PutPedDirectlyIntoCoverFromTarget = 2647921909
PutPedDirectlyIntoMelee = 4223627085
GuardCurrentPosition = 2363792692
UseNearestScenarioToPos = 1647992574
UseNearestScenarioChainToPos = 2614205159
PerformSequenceLocally = 3892030287
CombatHatedTargetsInArea = 1120685857
CombatHatedTargetsAroundPed = 2852500626
SwapWeapon = 716706914
ReloadWeapon = 3273846127
CombatHatedTargetsAroundPedTimed = 655999185
GetOffBoat = 2586290585
FollowNavmeshToCoordAdvanced = 2622471340
Patrol = 3041948268
StayInCover = 3787550361
HangGlider = 14754444
FollowToOffsetOfEntity = 1056466932
FollowToOffsetOfPickup = 1890514153
GoToCoordWhileAimingAtCoord = 432954108
GoToCoordWhileAimingAtEntity = 2536269655
GoToEntityWhileAimingAtCoord = 3135983996
GoToEntityWhileAimingAtEntity = 3087792932
UseWalkieTalkie = 700103780
ChatToPed = 264387021
FireFlare = 3736191119
BindPose = 1227476544
NMElectrocute = 2302978464
NMHighFall = 22897635
NMDangle = 189393644
NMSlungOverShoulder = 4042915776
NMStumble = 3134167095
SkyDive = 1264972124
Parachute = 1992968846
ParachuteToTarget = 1226945658
FollowWaypointRoute = 2605696984
NMAttachToVehicle = 1212655951
SetBlockingOfNonTemporaryEvents = 1872528988
MoveNetwork = 76834332
SynchronizedScene = 1785177548
VehicleShootAtCoord = 2937632804
VehicleShootAtEntity = 538064912
VehiclePark = 4022883198
MountAnimal = 1868526510
DismountAnimal = 501393341
ThrowProjectile = 2906111747
VehicleAimAtCoord = 12950610
VehicleAimAtEntity = 1865479361
VehicleAimUsingCamera = 1004259388
AdvanceToTargetInLine = 3425775300
RappelFromHeli = 4019022656
GeneralSweep = 1226471469
DragPedToCoord = 2275663850
VehicleFollowWaypointRecording = 4059134695
RappelDownFall = 2385108722
GoToCoordAndAimAtHatedEntitiesNearCoord = 688521916
WanderInArea = 923520851
VehicleGoToNavmesh = 4222893130
ForceMotionState = 2658708511
InCustody = 1833177545
LookAtEntity = 150319005
LookAtCoord = 3414437612
VehicleChase = 579380604
StealthKill = 1343540250
HeliChase = 657887634
PlaneChase = 47950271
PlaneLand = 71191126
ShockingEventBackAway = 2140673257
ShockingEventHurryAway = 3966259352
ShockingEventReact = 1233890275
Writhe = 2395094593
ExitCover = 1318460802
PlantBomb = 2166881562
InvestigateCoords = 2619673625
WanderSpecific = 3564073556
SharkCircleCoord = 1223610983
SharkCirclePed = 4245379110
ReactAndFleeCoord = 690397169
ReactAndFleePed = 2112745624
GoToCoordAnyMeansExtraParams = 1169531206
UseNearestTrainScenarioToPos = 2776655976
Jetpack = 2190391815
GoToCoordAnyMeansExtraParamsWithCruiseSpeed = 1306903184
AgitatedAction = 1418507444
WarpPedDirectlyIntoCover = 243280164
```

## ScriptTaskStatus

enum `GTA.ScriptTaskStatus`

| Name | Value |
| --- | --- |
| `WaitingToStart` | 0 |
| `Performing` | 1 |
| `Dormant` | 2 |
| `Vacant` | 3 |
| `Finished` | 7 |

## ScriptVehicleWheelIndex

enum `GTA.ScriptVehicleWheelIndex`

| Name | Value |
| --- | --- |
| `Invalid` | -1 |
| `CarFrontLeft` | 0 |
| `CarFrontRight` | 1 |
| `CarMidLeft` | 2 |
| `CarMidRight` | 3 |
| `CarRearLeft` | 4 |
| `CarRearRight` | 5 |
| `BikeFront` | 6 |
| `BikeRear` | 7 |

## SeaPlaneHandlingData

class `GTA.SeaPlaneHandlingData` : `BaseSubHandlingData`

### Properties

- `public float PontoonDragCoefficient { get; set; }`
- `public float PontoonVerticalDampingCoefficientDown { get; set; }`
- `public float PontoonVerticalDampingCoefficientUp { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(SeaPlaneHandlingData left, SeaPlaneHandlingData right)`
- `public static bool op_Inequality(SeaPlaneHandlingData left, SeaPlaneHandlingData right)`

## SetPlayerControlFlags

enum `GTA.SetPlayerControlFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `AmbientScript` | 2 |
| `ClearTasks` | 4 |
| `RemoveFires` | 8 |
| `RemoveExplosions` | 16 |
| `RemoveProjectiles` | 32 |
| `DeactivateGadgets` | 64 |
| `ReenableControlOnDeath` | 128 |
| `LeaveCameraControlOn` | 256 |
| `AllowPlayerDamage` | 512 |
| `DontStopOtherCarsAroundPlayer` | 1024 |
| `PreventEverybodyBackOff` | 2048 |
| `AllowPadShake` | 4096 |

## ShapeTest

static class `GTA.ShapeTest`

### Methods

- `public static ShapeTestHandle StartExpensiveSyncTestLOSProbe(Vector3 startPosition, Vector3 endPosition, IntersectFlags intersectFlags = 1, Entity excludeEntity = null, ShapeTestOptions options = 7)`
  - Start a expensive synchronous line-of-sight world probe shape test between 2 points and blocks the game until the shape test completes.
  - `startPosition`: The positon where the shape test starts.
  - `endPosition`: The positon where the shape test ends.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `excludeEntity`: Specify an `Entity` that the shape test should exclude, leave null for no entities ignored.
  - `options`: Specify options for the spape test.
- `public static ShapeTestHandle StartTestBound(Entity entity, IntersectFlags intersectFlags = 1, ShapeTestOptions options = 4)`
  - Start a shape test against the `Entity`'s bound where the entity can collide.
  - `entity`: The entity to inspect.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `options`: Specify options for the spape test.
- `public static ShapeTestHandle StartTestBoundingBox(Entity entity, IntersectFlags intersectFlags = 126, ShapeTestOptions options = 4)`
  - Start a shape test against the `Entity`'s bounding box.
  - `entity`: The entity to inspect.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `options`: Specify options for the spape test.
- `public static ShapeTestHandle StartTestBox(Vector3 sourcePosition, Vector3 dimension, Vector3 rotationAngles, EulerRotationOrder rotationOrder = 2, IntersectFlags intersectFlags = 1, Entity excludeEntity = null, ShapeTestOptions options = 4)`
  - Start a shape test against the `Entity`'s bound where the entity can collide.
  - `sourcePosition`: The source position.
  - `dimension`: The dimensions how much the shape test will search from the source position.
  - `rotationAngles`: The rotations in degree how much the dimension will be rotated before the shape test starts.
  - `rotationOrder`: The rotation order in local space the dimentions will be rotated in.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `excludeEntity`: Specify an `Entity` that the shape test should exclude, leave null for no entities ignored.
  - `options`: Specify options for the spape test.
- `public static ShapeTestHandle StartTestCapsule(Vector3 startPosition, Vector3 endPosition, float radius, IntersectFlags intersectFlags = 1, Entity excludeEntity = null, ShapeTestOptions options = 4)`
  - Start a shape test against the area where shape test capsule covers.
  - `startPosition`: The positon where the shape test starts.
  - `endPosition`: The positon where the shape test ends.
  - `radius`: The radius of the shape test capsule.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `excludeEntity`: Specify an `Entity` that the shape test should exclude, leave null for no entities ignored.
  - `options`: Specify options for the spape test.
- `public static ShapeTestHandle StartTestLOSProbe(Vector3 startPosition, Vector3 endPosition, IntersectFlags intersectFlags = 1, Entity excludeEntity = null, ShapeTestOptions options = 7)`
  - Start a line-of-sight world probe shape test between 2 points.
  - `startPosition`: The positon where the shape test starts.
  - `endPosition`: The positon where the shape test ends.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `excludeEntity`: Specify an `Entity` that the shape test should exclude, leave null for no entities ignored.
  - `options`: Specify options for the spape test.
- `public static ValueTuple<ShapeTestHandle, Vector3, Vector3> StartTestMouseCursorLOSProbe(IntersectFlags intersectFlags, Entity excludeEntity = null, ShapeTestOptions options = 7)`
  - Start a shape test between 2 points calculated based on the mouse cursor position. Works just like `StartTestLOSProbe` only the start and end points of the probe are calculated based on the mouse cursor position projected into the world.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `excludeEntity`: Specify an `Entity` that the shape test should exclude, leave null for no entities ignored.
  - `options`: Specify options for the spape test.
- `public static ShapeTestHandle StartTestMouseCursorLOSProbe(out Vector3 probeStartPosition, out Vector3 probeEndPosition, IntersectFlags intersectFlags = 1, Entity excludeEntity = null, ShapeTestOptions options = 7)`
  - Start a line-of-sight world probe shape test between 2 points calculated based on the mouse cursor position. Works just like `StartTestLOSProbe` only the start and end points of the probe are calculated based on the mouse cursor position projected into the world.
  - `probeStartPosition`: The returned start position of the probe in world space.
  - `probeEndPosition`: The returned end position of the probe in world space.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `excludeEntity`: Specify an `Entity` that the shape test should exclude, leave null for no entities ignored.
  - `options`: Specify options for the spape test.
- `public static ShapeTestHandle StartTestSweptSphere(Vector3 startPosition, Vector3 endPosition, float radius, IntersectFlags intersectFlags = 1, Entity excludeEntity = null, ShapeTestOptions options = 4)`
  - Start a shape test against the area where swept sphere (ellipsoid) for shape test covers.
  - `startPosition`: The positon where the shape test starts.
  - `endPosition`: The positon where the shape test ends.
  - `radius`: The radius of the swept sphere.
  - `intersectFlags`: What type of objects the shape test should intersect with.
  - `excludeEntity`: Specify an `Entity` that the shape test should exclude, leave null for no entities ignored.
  - `options`: Specify options for the spape test.

## ShapeTestHandle

struct `GTA.ShapeTestHandle` : `IEquatable<ShapeTestHandle>`, `INativeValue`

Represents a shape test handle. You need to call `GetResult` or `GetResultIncludingMaterial` every frame until one of the methods returns `Ready`.

### Properties

- `public int Handle { get; }`
  - Gets the shape test handle.
- `public bool IsRequestFailed { get; }`
  - Gets if the request of `ShapeTestHandle` is failed. There is a limit to the number that can be in the system. Therefore, native functions for shape tests may fail to create the shapetest requests.
- `public ulong NativeValue { get; set; }`
  - Gets the native representation of this `Model`.

### Methods

- `public bool Equals(ShapeTestHandle model)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public ValueTuple<ShapeTestStatus, ShapeTestResult> GetResult()`
  - If status returned is `Ready`, then returns whether something was hit, and if so nearest hit position and normal. You need to call this method until the result is ready since the shape test result may not be finished in the same frame you start the shape test.
- `public ShapeTestStatus GetResult(out ShapeTestResult result)`
  - If status returned is `Ready`, then returns whether something was hit, and if so nearest hit position and normal. You need to call this method until the result is ready since the shape test result may not be finished in the same frame you start the shape test.
- `public ValueTuple<ShapeTestStatus, ShapeTestResult, MaterialHash> GetResultIncludingMaterial()`
  - If status returned is `Ready`, then returns whether something was hit, and if so nearest hit position, normal, and a hash of the material name. You need to call this method until the result is ready since the shape test result may not be finished in the same frame you start the shape test.
- `public ShapeTestStatus GetResultIncludingMaterial(out ShapeTestResult result, out MaterialHash materialHash)`
  - If status returned is `Ready`, then returns whether something was hit, and if so nearest hit position, normal, and a hash of the material name. You need to call this method until the result is ready since the shape test result may not be finished in the same frame you start the shape test.
- `public static bool op_Equality(ShapeTestHandle left, ShapeTestHandle right)`
- `public static InputArgument op_Implicit(ShapeTestHandle value)`
- `public static bool op_Inequality(ShapeTestHandle left, ShapeTestHandle right)`

## ShapeTestOptions

enum `GTA.ShapeTestOptions`

| Name | Value |
| --- | --- |
| `IgnoreGlass` | 1 |
| `IgnoreSeeThrough` | 2 |
| `IgnoreNoCollision` | 4 |
| `Default` | 7 |

## ShapeTestResult

struct `GTA.ShapeTestResult`

Represents a shape test result.

### Properties

- `public bool DidHit { get; }`
  - Gets a value indicating whether this shape test collided with anything.
- `public Vector3 HitPosition { get; }`
  - Gets the world coordinates where this shape test hit. Returns `Zero` if the shape test didn't hit anything.
- `public Vector3 SurfaceNormal { get; }`
  - Gets the normal of the surface where this shape test hit. Returns `Zero` if the shape test didn't hit anything.

### Methods

- `public bool TryGetHitEntity(out Entity hitEntity)`
  - Try to get the `Entity` this shape test hit. Returns `false` if the shape test didn't hit or what was hit wasn't a `Entity`.

## ShapeTestStatus

enum `GTA.ShapeTestStatus`

| Name | Value | Description |
| --- | --- | --- |
| `NonExistent` | 0 | Shapetest requests are discarded if they are ignored for a frame or as soon as the results are returned. |
| `NotReady` | 1 | Not ready yet; try again next frame. |
| `Ready` | 2 | The result is ready and the results have been returned to you. The shape test request has also just been destroyed. |

## SpecialFlightHandlingData

class `GTA.SpecialFlightHandlingData` : `BaseSubHandlingData`

### Properties

- `public float BrakingThrustScale { get; set; }`
- `public float HoverVelocityScale { get; set; }`
- `public float MinSpeedForThrustFalloff { get; set; }`
- `public float PitchTorqueScale { get; set; }`
- `public float RollTorqueScale { get; set; }`
- `public float TransitionDuration { get; set; }`
- `public Vector3 VectorAngularDamping { get; set; }`
- `public Vector3 VectorAngularDampingMin { get; set; }`
- `public Vector3 VectorLinearDamping { get; set; }`
- `public Vector3 VectorLinearDampingMin { get; set; }`
- `public float YawTorqueScale { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(SpecialFlightHandlingData left, SpecialFlightHandlingData right)`
- `public static bool op_Inequality(SpecialFlightHandlingData left, SpecialFlightHandlingData right)`

## SpeechModifier

enum `GTA.SpeechModifier`

| Name | Value |
| --- | --- |
| `Standard` | 0 |
| `AllowRepeat` | 1 |
| `Beat` | 2 |
| `Force` | 3 |
| `ForceFrontend` | 4 |
| `ForceNoRepeatFrontend` | 5 |
| `ForceNormal` | 6 |
| `ForceNormalClear` | 7 |
| `ForceNormalCritical` | 8 |
| `ForceShouted` | 9 |
| `ForceShoutedClear` | 10 |
| `ForceShoutedCritical` | 11 |
| `ForcePreloadOnly` | 12 |
| `Megaphone` | 13 |
| `Helicopter` | 14 |
| `ForceMegaphone` | 15 |
| `ForceHelicopter` | 16 |
| `Interrupt` | 17 |
| `InterruptShouted` | 18 |
| `InterruptShoutedClear` | 19 |
| `InterruptShoutedCritical` | 20 |
| `InterruptNoForce` | 21 |
| `InterruptFrontend` | 22 |
| `InterruptNoForceFrontend` | 23 |
| `AddBlip` | 24 |
| `AddBlipAllowRepeat` | 25 |
| `AddBlipForce` | 26 |
| `AddBlipShouted` | 27 |
| `AddBlipShoutedForce` | 28 |
| `AddBlipInterrupt` | 29 |
| `AddBlipInterruptForce` | 30 |
| `ForcePreloadOnlyShouted` | 31 |
| `ForcePreloadOnlyShoutedClear` | 32 |
| `ForcePreloadOnlyShoutedCritical` | 33 |
| `Shouted` | 34 |
| `ShoutedClear` | 35 |
| `ShoutedCritical` | 36 |

## Streaming

static class `GTA.Streaming`

### Properties

- `public static Entity FocusEntity { set; }`
- `public static bool IsEnabled { set; }`
- `public static bool IsNewLoadSceneActive { get; }`
- `public static bool IsNewLoadSceneLoaded { get; }`

### Methods

- `public static void ClearOverriddenFocus()`
- `public static bool IsEntityFocus(Entity entity)`
- `public static void LoadScene(Vector3 position)`
- `public static void RequestCollisionAt(Vector3 point)`
- `public static void SetFocusPositionAndVelocity(Vector3 position, Vector3 velocity)`
- `public static void SetPedPopulationBudget(int amount)`
- `public static void SetVehiclePopulationBudget(int amount)`
- `public static bool StartNewFrustumLoadScene(Vector3 position, Vector3 direction, float farClip, NewLoadSceneFlags controlFlags = 0)`
- `public static bool StartNewSphereLoadScene(Vector3 position, float radius, NewLoadSceneFlags controlFlags = 0)`
- `public static void StopNewLoadScene()`

## StringHash

static class `GTA.StringHash`

### Methods

- `public static uint AtFinalizeHash(uint partialHashValue)`
- `public static uint AtLiteralStringHash(byte[] input, uint initValue = 0)`
- `public static uint AtLiteralStringHash(string input, uint initValue = 0)`
- `public static uint AtLiteralStringHashUtf8(string input, uint initValue = 0)`
- `public static uint AtPartialStringHash(byte[] input, uint initValue = 0)`
- `public static uint AtPartialStringHash(string input, uint initValue = 0)`
- `public static uint AtPartialStringHashUtf8(string input, uint initValue = 0)`
- `public static uint AtStringHash(byte[] input, uint initValue = 0)`
- `public static uint AtStringHash(string input, uint initValue = 0)`
- `public static uint AtStringHashUtf8(string input, uint initValue = 0)`

## Style

class `GTA.Style`

### Properties

- `public PedComponent this[PedComponentType componentId] { get; }`
- `public PedProp this[PedPropAnchorPoint anchorPoint] { get; }`
- `public PedProp this[PedPropType propId] { get; }`
  - **Obsolete.** Use the indexer overload with the type PedPropAnchorPoint instead.

### Methods

- `public void ClearProps()`
- `public PedComponent[] GetAllComponents()`
- `public PedProp[] GetAllProps()`
- `public IPedVariation[] GetAllVariations()`
- `public IEnumerator<IPedVariation> GetEnumerator()`
- `public bool HasLoadedPreloadPropData()`
- `public bool HasLoadedPreloadVariationData()`
- `public void PreloadPropData(PedPropAnchorPoint anchor, int propId, int textureId)`
- `public void PreloadVariationData(PedComponentType componentType, int drawableId, int textureId)`
- `public void RandomizeOutfit()`
- `public void RandomizeProps()`
- `public void ReleasePreloadPropData()`
- `public void ReleasePreloadVariationData()`
- `public void SetDefaultClothes()`

## SubmarineHandlingData

class `GTA.SubmarineHandlingData` : `BaseSubHandlingData`

### Properties

- `public float DiveSpeed { get; set; }`
- `public float PitchAngle { get; set; }`
- `public float PitchMultiplier { get; set; }`
- `public float YawMultiplier { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(SubmarineHandlingData left, SubmarineHandlingData right)`
- `public static bool op_Inequality(SubmarineHandlingData left, SubmarineHandlingData right)`

## SyncedSceneFlags

enum `GTA.SyncedSceneFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `UseKinematicPhysics` | 1 |
| `TagSyncOut` | 2 |
| `DontInterrupt` | 4 |
| `OnAbortStopScene` | 8 |
| `AbortOnWeaponDamage` | 16 |
| `BlockMoverUpdate` | 32 |
| `LoopWithinScene` | 64 |
| `PreserveVelocity` | 128 |
| `ExpandPedCapsuleFromSkeleton` | 256 |
| `ActivateRagdollOnCollision` | 512 |
| `HideWeapon` | 1024 |
| `AbortOnDeath` | 2048 |
| `VehicleAbortOnLargeImpact` | 4096 |
| `VehicleAllowPlayerEntry` | 8192 |
| `ProcessAttachmentsOnStart` | 16384 |
| `NetOnEarlyNonPedStopReturnToStart` | 32768 |
| `SetPedOutOfVehicleAtStart` | 65536 |
| `NetDisregardAttachmentChecks` | 131072 |

## TargetLossResponse

enum `GTA.TargetLossResponse`

| Name | Value |
| --- | --- |
| `ExitTask` | 0 |
| `NeverLoseTarget` | 1 |
| `SearchForTarget` | 2 |

## TaskCombatFlags

enum `GTA.TaskCombatFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `UseFlinchAimIntro` | 16384 |
| `UseSurprisedAimIntro` | 32768 |
| `ArrestTarget` | 65536 |
| `PreventChangingTarget` | 67108864 |
| `DisableAimIntro` | 134217728 |
| `UseSniperAimIntro` | 536870912 |

## TaskGoToPointAnyMeansFlags

enum `GTA.TaskGoToPointAnyMeansFlags`

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `IgnoreVehicleHealth` | 1 |
| `ConsiderAllNearbyVehicles` | 2 |
| `ProperIsDriveableCheck` | 4 |
| `RemainInVehicleAtDestination` | 8 |
| `NeverAbandonVehicle` | 16 |
| `NeverAbandonVehicleIfMoving` | 32 |
| `UseAITargetingForThreats` | 64 |

## TaskInvoker

class `GTA.TaskInvoker`

### Methods

- `public void AchieveHeading(float heading, int timeout = 0)`
- `public void AimAt(Entity target, int duration)`
  - **Obsolete.** Use TaskInvoker.AimGunAtEntity for entity targets instead.
- `public void AimAt(Vector3 target, int duration)`
  - **Obsolete.** Use TaskInvoker.AimGunAtPosition for coordinate targets instead.
- `public void AimGunAtEntity(Entity target, int duration, bool instantBlendToAim = false)`
- `public void AimGunAtPosition(Vector3 target, int duration, bool instantBlendToAim = false, bool playAimIntro = false)`
- `public void Arrest(Ped ped)`
- `public void ChaseWithGroundVehicle(Ped target)`
- `public void ChaseWithHelicopter(Ped target, Vector3 offset)`
- `public void ChaseWithPlane(Ped target, Vector3 offset)`
- `public void ChatTo(Ped ped)`
- `public void ClearAll()`
- `public void ClearAllImmediately()`
- `public void ClearAnimation(string animSet, string animName)`
  - **Obsolete.** Use StopScriptedAnimationTask instead.
- `public void ClearLookAt()`
- `public void ClearSecondary()`
- `public void Climb()`
- `public void ClimbLadder()`
- `public void ClimbLadder(bool fast)`
- `public void Combat(Ped target, TaskCombatFlags combatFlags = 0, TaskThreatResponseFlags taskThreatResponseFlags = 16)`
- `public void CombatHatedTargetsAroundPed(float radius, TaskCombatFlags combatFlags = 0)`
- `public void CombatHatedTargetsAroundPedTimed(float radius, int time, TaskCombatFlags combatFlags = 0)`
- `public void CombatHatedTargetsInArea(Vector3 position, float radius, TaskCombatFlags combatFlags = 0)`
- `public void CombatTimed(Ped target, int time, TaskCombatFlags combatFlags = 0)`
- `public void Cower(int duration)`
- `public void CruiseWithVehicle(Vehicle vehicle, float speed, DrivingStyle style = 786603)`
  - **Obsolete.** Use TaskInvoker.CruiseWithVehicle(Vehicle, float, VehicleDrivingFlags) instead.
- `public void CruiseWithVehicle(Vehicle vehicle, float speed, VehicleDrivingFlags drivingFlags)`
- `public void DriveTo(Vehicle vehicle, Vector3 target, float speed, VehicleDrivingFlags drivingFlags, float radius)`
- `public void DriveTo(Vehicle vehicle, Vector3 target, float radius, float speed, DrivingStyle style = 786603)`
  - **Obsolete.** Use DriveTo(Vehicle, Vector3, float, VehicleDrivingFlags, float) instead.
- `public void EnterAnyVehicle(VehicleSeat seat = -2, int timeout = -1, float speed = 1, EnterVehicleFlags flag = 0)`
- `public void EnterVehicle(Vehicle vehicle, VehicleSeat seat, int timeout, PedMoveBlendRatio? moveBlendRatio = null, EnterVehicleFlags flag = 0, string overriddenClipSet = null)`
- `public void EnterVehicle(Vehicle vehicle, VehicleSeat seat = -2, int timeout = -1, float speed = 1, EnterVehicleFlags flag = 0)`
- `public void FightAgainst(Ped target, int duration)`
  - **Obsolete.** Use TaskInvoker.CombatTimed instead.
- `public void FightAgainst(Ped target)`
  - **Obsolete.** Use TaskInvoker.Combat instead.
- `public void FightAgainstHatedTargets(float radius, int duration)`
  - **Obsolete.** Use TaskInvoker.CombatHatedTargetsAroundPedTimed instead.
- `public void FightAgainstHatedTargets(float radius)`
  - **Obsolete.** Use TaskInvoker.CombatHatedTargetsAroundPed instead.
- `public void FleeFrom(Vector3 position, int duration = -1)`
- `public void FleeFrom(Vector3 position, float safeDistance, int duration, bool quitIfOutOfRange = false)`
- `public void FleeFrom(Ped ped, int duration = -1)`
- `public void FleeFrom(Ped otherPed, float safeDistance, int duration)`
- `public void FollowNavMeshTo(Vector3 position, PedMoveBlendRatio moveBlendRatio, int timeBeforeWarp, float radius, FollowNavMeshFlags navigationFlags, float slideToCoordHeading, float maxSlopeNavigable, float clampMaxSearchDistance, float finalHeading = 40000)`
- `public void FollowNavMeshTo(Vector3 position, PedMoveBlendRatio? moveBlendRatio = null, int timeBeforeWarp = -1, float radius = 0.25, FollowNavMeshFlags navigationFlags = 0, float finalHeading = 40000)`
- `public void FollowPointRoute(params Vector3[] points)`
- `public void FollowPointRoute(float movementSpeed, params Vector3[] points)`
- `public void FollowToOffsetFromEntity(Entity target, Vector3 offset, float movementSpeed, int timeout = -1, float distanceToFollow = 10, bool persistFollowing = true)`
- `public void ForceMotionState(PedMotionState state, bool restartState = false)`
- `public void GoStraightTo(Vector3 position, int timeBeforeWarp, PedMoveBlendRatio moveBlendRatio, float finalHeading, float targetRadius)`
- `public void GoStraightTo(Vector3 position, int timeout = -1, float targetHeading = 0, float distanceToSlide = 0)`
- `public void GoTo(Entity target, Vector3 offset = null, int timeout = -1)`
- `public void GoTo(Vector3 position, int timeout = -1)`
  - **Obsolete.** TaskInvoker.GoTo with the position parameter may not obvious enough to suggest it uses navigation mesh. Use TaskInvoker.FollowNavMeshTo instead.
- `public void GoToPlanePreciseVtol(Vehicle plane, Vector3 target, int flightHeight, int minHeightAboveTerrain, float? desiredOrientation = null, bool autoPilot = false)`
- `public void GoToPointAnyMeans(Vector3 target, PedMoveBlendRatio moveBlendRatio, Vehicle vehicle, bool useLongRangeVehiclePathing = false, VehicleDrivingFlags drivingFlags = 786603, float maxRangeToShootTargets = -1)`
- `public void GoToPointAnyMeansExtraParams(Vector3 target, PedMoveBlendRatio moveBlendRatio, Vehicle vehicle, bool useLongRangeVehiclePathing = false, VehicleDrivingFlags drivingFlags = 786603, float maxRangeToShootTargets = -1, float extraVehToTargetDistToPreferVeh = 0, float driveStraightLineDistance = 20, TaskGoToPointAnyMeansFlags extraFlags = 0, float warpTimerMs = -1)`
- `public void GoToPointAnyMeansExtraParamsWithCruiseSpeed(Vector3 target, PedMoveBlendRatio moveBlendRatio, Vehicle vehicle, bool useLongRangeVehiclePathing = false, VehicleDrivingFlags drivingFlags = 786603, float maxRangeToShootTargets = -1, float extraVehToTargetDistToPreferVeh = 0, float driveStraightLineDistance = 20, TaskGoToPointAnyMeansFlags extraFlags = 0, float cruiseSpeed = -1, float targetArriveDist = 4)`
- `public void GoToSubmarineAndStop(Vehicle submarine, Vector3 position, bool autoPilot = false)`
- `public void GuardCurrentPosition()`
- `public void HandsUp(int duration)`
- `public void HeliChase(Entity target, Vector3 targetOffset)`
- `public void HeliEscortHeli(Vehicle heli, Vehicle escortHeli, Vector3 offset)`
- `public void Jump()`
- `public void Jump(bool doSuperJump, bool useFullSuperJumpForce)`
- `public void LandPlane(Vector3 startPosition, Vector3 touchdownPosition, Vehicle plane = null)`
- `public void LeaveVehicle(LeaveVehicleFlags flags = 0)`
- `public void LeaveVehicle(Vehicle vehicle, LeaveVehicleFlags flags)`
- `public void LeaveVehicle(Vehicle vehicle, bool closeDoor)`
- `public void LookAt(Entity target, int duration, LookAtFlags lookFlags = 0, LookAtPriority priority = 2)`
- `public void LookAt(Entity target, int duration = -1)`
- `public void LookAt(Vector3 position, int duration, LookAtFlags lookFlags = 0, LookAtPriority priority = 2)`
- `public void LookAt(Vector3 position, int duration = -1)`
- `public void OpenVehicleDoor(Vehicle vehicle, VehicleSeat seat = -2, int timeout = -1, PedMoveBlendRatio? moveBlendRatio = null)`
- `public void ParachuteTo(Vector3 position)`
- `public void ParkVehicle(Vehicle vehicle, Vector3 position, float directionDegrees, ParkType parkType, float toleranceDegrees = 20, bool keepEngineOn = false)`
- `public void ParkVehicle(Vehicle vehicle, Vector3 position, float heading, float radius = 20, bool keepEngineOn = false)`
- `public void Pause(int duration)`
- `public void PerformSequence(TaskSequence sequence)`
- `public void PlaneChase(Entity target, Vector3 targetOffset)`
- `public void PlaneTaxi(Vehicle plane, Vector3 position, float cruiseSpeed, float targetReachedDist)`
- `public void PlayAnimation(CrClipAsset crClipAsset, AnimationBlendDelta blendInSpeed, AnimationBlendDelta blendOutSpeed, int duration, AnimationFlags flags, float startPhase, bool phaseControlled, AnimationIKControlFlags ikFlags)`
- `public void PlayAnimation(CrClipAsset crClipAsset, AnimationBlendDelta blendInSpeed, AnimationBlendDelta blendOutSpeed, int duration, AnimationFlags flags, float startPhase)`
- `public void PlayAnimation(CrClipAsset crClipAsset, AnimationBlendDelta blendSpeed, int duration, float startPhase)`
- `public void PlayAnimation(CrClipAsset crClipAsset)`
- `public void PlayAnimation(string animDict, string animName, float blendInSpeed, int duration, AnimationFlags flags)`
- `public void PlayAnimation(string animDict, string animName, float speed, int duration, float playbackRate)`
- `public void PlayAnimation(string animDict, string animName, float blendInSpeed, float blendOutSpeed, int duration, AnimationFlags flags, float playbackRate)`
- `public void PlayAnimation(string animDict, string animName)`
- `public void PlayAnimationAdvanced(CrClipAsset crClipAsset, Vector3 position, Vector3 rotation, AnimationBlendDelta? blendInDelta = null, AnimationBlendDelta? blendOutDelta = null, int timeToPlay = -1, AnimationFlags flags = 0, float startPhase = 0, EulerRotationOrder rotOrder = 2, AnimationIKControlFlags ikFlags = 0)`
- `public void PlaySynchronizedScene(FwSyncedScene scene, CrClipAsset anim, AnimationBlendDelta blendIn, AnimationBlendDelta blendOut, SyncedSceneFlags flags = 0, RagdollBlockingFlags ragdollFlags = 0, AnimationBlendDelta? moverBlendIn = null, AnimationIKControlFlags ikFlags = 0)`
- `public void PutAwayMobilePhone()`
- `public void PutAwayParachute()`
- `public void PutDirectlyIntoMelee(Ped target, AnimationBlendDuration blendIn, float strafePhaseSync, TaskCombatFlags aiCombatFlags)`
- `public void PutDirectlyIntoMelee(Ped target, AnimationBlendDuration blendIn, float strafePhaseSync, float timeInTask)`
- `public void PutDirectlyIntoMelee(Ped target, AnimationBlendDuration blendIn, float strafePhaseSync)`
- `public void RappelFromHelicopter()`
- `public void ReactAndFlee(Ped ped)`
- `public void ReloadWeapon()`
- `public void RunTo(Vector3 position, bool ignorePaths = false, int timeout = -1)`
- `public void ShootAt(Vector3 position, int duration = -1, FiringPattern pattern = 0)`
- `public void ShootAt(Ped target, int duration = -1, FiringPattern pattern = 0)`
- `public void ShuffleToNextVehicleSeat(Vehicle vehicle = null)`
- `public void Skydive()`
- `public void SlideTo(Vector3 position, float heading)`
- `public void StandStill(int duration)`
- `public void StartBoatMission(Vehicle boat, Vector3 target, VehicleMissionType missionType, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float targetReachedDist, BoatMissionFlags missionFlags)`
  - Gives the boat a mission.
  - `boat`: The boat.
  - `target`: The target coordinate.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `drivingFlags`: The driving flags for the task.
  - `targetReachedDist`: distance (in meters) at which boat thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `missionFlags`: The boat mission flags for the task.
- `public void StartBoatMission(Vehicle boat, Ped target, VehicleMissionType missionType, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float targetReachedDist, BoatMissionFlags missionFlags)`
  - Gives the boat a mission.
  - `boat`: The boat.
  - `target`: The target `Ped`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `drivingFlags`: The driving flags for the task.
  - `targetReachedDist`: distance (in meters) at which boat thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `missionFlags`: The boat mission flags for the task.
- `public void StartBoatMission(Vehicle boat, Vehicle target, VehicleMissionType missionType, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float targetReachedDist, BoatMissionFlags missionFlags)`
  - Gives the boat a mission.
  - `boat`: The boat.
  - `target`: The target `Vehicle`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `drivingFlags`: The driving flags for the task.
  - `targetReachedDist`: distance (in meters) at which boat thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `missionFlags`: The boat mission flags for the task.
- `public void StartHeliMission(Vehicle heli, Vector3 target, VehicleMissionType missionType, float cruiseSpeed, float targetReachedDist, int flightHeight, int minHeightAboveTerrain, float heliOrientation = -1, float slowDownDistance = -1, HeliMissionFlags missionFlags = 0)`
  - Gives the helicopter a mission.
  - `heli`: The helicopter.
  - `target`: The target coodinate.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `targetReachedDist`: distance (in meters) at which heli thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `flightHeight`: The Z coordinate the heli tries to maintain (i.e. 30 == 30 meters above sea level).
  - `minHeightAboveTerrain`: The height in meters that the heli will try to stay above terrain (ie 20 == always tries to stay at least 20 meters above ground).
  - `heliOrientation`: The orientation the heli tries to be in (`0f` to `360f`). Use `-1f` if not bothered. `-1f` Should be used in 99% of the times.
  - `slowDownDistance`: In general, get more control with big number and more dynamic with smaller. Setting to `-1` means use default tuning(`100`).
  - `missionFlags`: The heli mission flags for the task.
- `public void StartHeliMission(Vehicle heli, Ped target, VehicleMissionType missionType, float cruiseSpeed, float targetReachedDist, int flightHeight, int minHeightAboveTerrain, float heliOrientation = -1, float slowDownDistance = -1, HeliMissionFlags missionFlags = 0)`
  - Gives the helicopter a mission.
  - `heli`: The helicopter.
  - `target`: The target `Ped`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `targetReachedDist`: distance (in meters) at which heli thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `flightHeight`: The Z coordinate the heli tries to maintain (i.e. 30 == 30 meters above sea level).
  - `minHeightAboveTerrain`: The height in meters that the heli will try to stay above terrain (ie 20 == always tries to stay at least 20 meters above ground).
  - `heliOrientation`: The orientation the heli tries to be in (`0f` to `360f`). Use `-1f` if not bothered. `-1f` Should be used in 99% of the times.
  - `slowDownDistance`: In general, get more control with big number and more dynamic with smaller. Setting to `-1` means use default tuning(`100`).
  - `missionFlags`: The heli mission flags for the task.
- `public void StartHeliMission(Vehicle heli, Vehicle target, VehicleMissionType missionType, float cruiseSpeed, float targetReachedDist, int flightHeight, int minHeightAboveTerrain, float heliOrientation = -1, float slowDownDistance = -1, HeliMissionFlags missionFlags = 0)`
  - Gives the helicopter a mission.
  - `heli`: The helicopter.
  - `target`: The target `Vehicle`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `targetReachedDist`: distance (in meters) at which heli thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `flightHeight`: The Z coordinate the heli tries to maintain (i.e. 30 == 30 meters above sea level).
  - `minHeightAboveTerrain`: The height in meters that the heli will try to stay above terrain (ie 20 == always tries to stay at least 20 meters above ground).
  - `heliOrientation`: The orientation the heli tries to be in (`0f` to `360f`). Use `-1f` if not bothered. `-1f` Should be used in 99% of the times.
  - `slowDownDistance`: In general, get more control with big number and more dynamic with smaller. Setting to `-1` means use default tuning(`100`).
  - `missionFlags`: The heli mission flags for the task.
- `public void StartMoveNetworkAdvancedByName(string networkName, Vector3 pos, Vector3 rot, EulerRotationOrder rotOrder = 2, AnimationBlendDuration? blendDuration = null, MoveNetworkFlags flags = 0)`
- `public void StartMoveNetworkAdvancedByNameWithInitParams(string networkName, TaskMoVEScriptedInitialParameters initParams, Vector3 pos, Vector3 rot, EulerRotationOrder rotOrder = 2, AnimationBlendDuration? blendDuration = null, MoveNetworkFlags flags = 0)`
- `public void StartMoveNetworkByName(string networkName, AnimationBlendDuration? blendDuration = null, MoveNetworkFlags flags = 0)`
- `public void StartMoveNetworkByNameWithInitParams(string networkName, TaskMoVEScriptedInitialParameters initParams, AnimationBlendDuration? blendDuration = null, MoveNetworkFlags flags = 0)`
- `public void StartPlaneMission(Vehicle plane, Vector3 target, VehicleMissionType missionType, float cruiseSpeed, float targetReachedDist, int flightHeight, int minHeightAboveTerrain, float planeOrientation = -1, bool precise = true)`
  - Gives the plane a mission.
  - `plane`: The plane.
  - `target`: The target coodinate.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `targetReachedDist`: distance (in meters) at which heli thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `flightHeight`: The Z coordinate the heli tries to maintain (i.e. 30 == 30 meters above sea level).
  - `minHeightAboveTerrain`: The height in meters that the heli will try to stay above terrain (ie 20 == always tries to stay at least 20 meters above ground).
  - `planeOrientation`: The orientation the plane tries to be in (`0f` to `360f`). Use `-1f` if not bothered. `-1f` Should be used in 99% of the times.
- `public void StartPlaneMission(Vehicle plane, Ped target, VehicleMissionType missionType, float cruiseSpeed, float targetReachedDist, int flightHeight, int minHeightAboveTerrain, float planeOrientation = -1, bool precise = true)`
  - Gives the plane a mission.
  - `plane`: The helicopter.
  - `target`: The target `Ped`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `targetReachedDist`: distance (in meters) at which heli thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `flightHeight`: The Z coordinate the heli tries to maintain (i.e. 30 == 30 meters above sea level).
  - `minHeightAboveTerrain`: The height in meters that the heli will try to stay above terrain (ie 20 == always tries to stay at least 20 meters above ground).
  - `planeOrientation`: The orientation the plane tries to be in (`0f` to `360f`). Use `-1f` if not bothered. `-1f` Should be used in 99% of the times.
- `public void StartPlaneMission(Vehicle plane, Vehicle target, VehicleMissionType missionType, float cruiseSpeed, float targetReachedDist, int flightHeight, int minHeightAboveTerrain, float planeOrientation = -1, bool precise = true)`
  - Gives the plane a mission.
  - `plane`: The helicopter.
  - `target`: The target `Vehicle`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `targetReachedDist`: distance (in meters) at which heli thinks it's arrived. Also used as the hover distance for `Attack` and `Circle`
  - `flightHeight`: The Z coordinate the heli tries to maintain (i.e. 30 == 30 meters above sea level).
  - `minHeightAboveTerrain`: The height in meters that the heli will try to stay above terrain (ie 20 == always tries to stay at least 20 meters above ground).
  - `planeOrientation`: The orientation the plane tries to be in (`0f` to `360f`). Use `-1f` if not bothered. `-1f` Should be used in 99% of the times.
- `public void StartScenario(string name, Vector3 position, float heading)`
  - **Obsolete.** TaskInvoker.StartScenario is obsolete, use TaskInvoker.StartScenarioAtPosition instead.
- `public void StartScenario(string name, float heading)`
  - **Obsolete.** TaskInvoker.StartScenario is obsolete, use TaskInvoker.StartScenarioInPlace instead.
- `public void StartScenarioAtPosition(string scenarioName, Vector3 position, float heading, int timeToLeave = 0, bool playIntroClip = true, bool warp = true)`
- `public void StartScenarioInPlace(string scenarioName, int timeToLeave = 0, bool playIntroClip = true)`
- `public void StartVehicleMission(Vehicle vehicle, Vector3 target, VehicleMissionType missionType, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float targetReachedDist, float straightLineDist, bool driveAgainstTraffic = true)`
  - Tells the `Ped` to target a coord with a `Vehicle`.
  - `vehicle`: The `Vehicle` to use to achieve the task.
  - `target`: The target coordinates.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `drivingFlags`: The driving flags for the task.
  - `targetReachedDist`: The distance at which the AI thinks the target has been reached and the car stops. To pick default value, the parameter can be passed in as `-1`.
  - `straightLineDist`: The distance at which the AI switches to heading for the target directly instead of following the nodes. To pick default value, the parameter can be passed in as `-1`.
  - `driveAgainstTraffic`: if set to `true`, allows the car to drive on the opposite side of the road into incoming traffic.
- `public void StartVehicleMission(Vehicle vehicle, Ped target, VehicleMissionType missionType, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float targetReachedDist, float straightLineDist, bool driveAgainstTraffic = true)`
  - Tells the `Ped` to target another ped with a vehicle.
  - `vehicle`: The `Vehicle` to use to achieve the task.
  - `target`: The target `Ped`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `drivingFlags`: The driving flags for the task.
  - `targetReachedDist`: The distance at which the AI thinks the target has been reached and the car stops. To pick default value, the parameter can be passed in as `-1`.
  - `straightLineDist`: The distance at which the AI switches to heading for the target directly instead of following the nodes. To pick default value, the parameter can be passed in as `-1`.
  - `driveAgainstTraffic`: if set to `true`, allows the car to drive on the opposite side of the road into incoming traffic.
- `public void StartVehicleMission(Vehicle vehicle, Vehicle target, VehicleMissionType missionType, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float targetReachedDist, float straightLineDist, bool driveAgainstTraffic = true)`
  - Tells the `Ped` to perform a task when in a `Vehicle` against another `Vehicle`.
  - `vehicle`: The `Vehicle` to use to achieve the task.
  - `target`: The target `Vehicle`.
  - `missionType`: The vehicle mission type.
  - `cruiseSpeed`: The cruise speed for the task.
  - `drivingFlags`: The driving flags for the task.
  - `targetReachedDist`: The distance at which the AI thinks the target has been reached and the car stops. To pick default value, the parameter can be passed in as `-1`.
  - `straightLineDist`: The distance at which the AI switches to heading for the target directly instead of following the nodes. To pick default value, the parameter can be passed in as `-1`.
  - `driveAgainstTraffic`: if set to `true`, allows the car to drive on the opposite side of the road into incoming traffic.
- `public void StopScriptedAnimationTask(CrClipAsset crClipAsset, AnimationBlendDelta? blendOutDelta = null)`
- `public void SwapWeapon()`
- `public void SwapWeapon(bool drawWeapon)`
- `public void TurnTo(Entity target, int duration = -1)`
- `public void TurnTo(Vector3 position, int duration = -1)`
- `public void UseMobilePhone()`
- `public void UseMobilePhone(int duration)`
- `public void UseParachute()`
- `public void VehicleChase(Ped target)`
- `public void VehicleEscort(Vehicle vehicle, Entity escortEntity, VehicleEscortType escortType, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float customOffset = -1, int minHeightAboveTerrain = 20, float straightLineDistance = 20)`
- `public void VehicleFollow(Vehicle vehicle, Entity followEntity, float cruiseSpeed, VehicleDrivingFlags drivingFlags, int followDistance = 20)`
- `public void VehicleHeliProtect(Vehicle heli, Entity protectEntity, float cruiseSpeed, VehicleDrivingFlags drivingFlags, float customOffset = -1, int minHeightAboveTerrain = 20, HeliMissionFlags missionFlags = 0)`
- `public void VehicleShootAtPed(Ped target)`
- `public void Wait(int duration)`
  - **Obsolete.** TaskInvoke.Wait is obsolete, use TaskInvoker.Pause instead.
- `public void Wander(float heading = 40000, bool keepMovingWhilstWaitingForFirstPath = false)`
- `public void WanderAround()`
  - **Obsolete.** the overload of TaskInvoker.WanderAround with no parameters is obsolete, use TaskInvoker.Wander instead.
- `public void WanderAround(Vector3 position, float radius, float minTime, float maxTime)`
- `public void WanderAround(Vector3 position, float radius)`
- `public void WarpIntoVehicle(Vehicle vehicle, VehicleSeat seat)`
- `public void WarpOutOfVehicle(Vehicle vehicle)`
- `public static void EveryoneLeaveVehicle(Vehicle vehicle)`
- `public static void UpdateParachuteTarget(Ped ped, Vector3 position)`

## TaskMoVEScriptedInitialParameters

class `GTA.TaskMoVEScriptedInitialParameters`

### Properties

- `public string BoolParamName0 { get; }`
- `public string BoolParamName1 { get; }`
- `public bool BoolParamValue0 { get; }`
- `public bool BoolParamValue1 { get; }`
- `public AtHashValue ClipSet0 { get; }`
- `public AtHashValue ClipSet1 { get; }`
- `public float FloatParamLerpValue0 { get; }`
- `public float FloatParamLerpValue1 { get; }`
- `public string FloatParamName0 { get; }`
- `public string FloatParamName1 { get; }`
- `public float FloatParamValue0 { get; }`
- `public float FloatParamValue1 { get; }`
- `public AtHashValue VarClipSet0 { get; }`
- `public AtHashValue VarClipSet1 { get; }`

## TaskMoVEScriptedInitialParametersBuilder

class `GTA.TaskMoVEScriptedInitialParametersBuilder`

### Constructors

- `public TaskMoVEScriptedInitialParametersBuilder()`

### Methods

- `public TaskMoVEScriptedInitialParametersBuilder BoolParamName0(string boolParamName0)`
- `public TaskMoVEScriptedInitialParametersBuilder BoolParamName1(string boolParamName1)`
- `public TaskMoVEScriptedInitialParametersBuilder BoolParamValue0(bool boolParamValue0)`
- `public TaskMoVEScriptedInitialParametersBuilder BoolParamValue1(bool boolParamValue1)`
- `public TaskMoVEScriptedInitialParameters Build()`
- `public TaskMoVEScriptedInitialParametersBuilder ClipSet0(AtHashValue clipSet0)`
- `public TaskMoVEScriptedInitialParametersBuilder ClipSet1(AtHashValue clipSet1)`
- `public TaskMoVEScriptedInitialParametersBuilder FloatParamLerpValue0(float floatParamLerpValue0)`
- `public TaskMoVEScriptedInitialParametersBuilder FloatParamLerpValue1(float floatParamLerpValue1)`
- `public TaskMoVEScriptedInitialParametersBuilder FloatParamName0(string floatParamName0)`
- `public TaskMoVEScriptedInitialParametersBuilder FloatParamName1(string floatParamName1)`
- `public TaskMoVEScriptedInitialParametersBuilder FloatParamValue0(float floatParamValue0)`
- `public TaskMoVEScriptedInitialParametersBuilder FloatParamValue1(float floatParamValue1)`
- `public TaskMoVEScriptedInitialParametersBuilder VarClipSet0(AtHashValue varClipSet0)`
- `public TaskMoVEScriptedInitialParametersBuilder VarClipSet1(AtHashValue varClipSet1)`

## TaskSequence

class `GTA.TaskSequence` : `IDisposable`

### Constructors

- `public TaskSequence()`
- `public TaskSequence(int handle)`

### Properties

- `public TaskInvoker AddTask { get; }`
- `public int Count { get; }`
- `public int Handle { get; }`
- `public bool IsClosed { get; }`

### Methods

- `public void Close()`
- `public void Close(bool repeat)`
- `public void Dispose()`

## TaskThreatResponseFlags

enum `GTA.TaskThreatResponseFlags`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `CanFightArmedPedsWhenNotArmed` | 16 |

## TrailerHandlingData

class `GTA.TrailerHandlingData` : `BaseSubHandlingData`

### Properties

- `public float AttachedMaxDistance { get; set; }`
- `public float AttachedMaxPenetration { get; set; }`
- `public float AttachLimitPitch { get; set; }`
- `public float AttachLimitRoll { get; set; }`
- `public float AttachLimitYaw { get; set; }`
- `public float PositionConstraintMassRatio { get; set; }`
- `public float UprightDampingConstant { get; set; }`
- `public float UprightSpringConstant { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(TrailerHandlingData left, TrailerHandlingData right)`
- `public static bool op_Inequality(TrailerHandlingData left, TrailerHandlingData right)`

## Vehicle

class `GTA.Vehicle` : `Entity`, `INativeValue`, `IDeletable`, `IExistable`, `ISpatial`

### Properties

- `public float Acceleration { get; }`
  - Gets the acceleration of this `Vehicle`.
- `public int AlarmTimeLeft { get; set; }`
  - Gets or sets time left before this `Vehicle` alarm stops. If greater than zero, the vehicle alarm will be sounding. the value is up to 65534.
- `public bool AllowRappel { get; }`
  - Gets a value indicating whether this `Vehicle` allows `Ped`s to rappel.
- `public bool AreBrakeLightsOn { set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its brake light on.
- `public bool AreExhaustPopsEnabled { set; }`
- `public bool AreHighBeamsOn { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its high beams on.
- `public bool AreLightsOn { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its lights on.
- `public bool AreWingsEnabledForSpecialFlightMode { get; set; }`
- `public float BodyHealth { get; set; }`
  - Gets or sets this `Vehicle`s body health.
- `public int BombAmmoCount { get; set; }`
- `public float BrakePower { get; set; }`
  - Gets or sets the current brake power of this `Vehicle`.
- `public bool CanBeVisiblyDamaged { set; }`
- `public bool CanEngineDegrade { set; }`
- `public bool CanJump { get; }`
  - Gets a value indicating whether this `Vehicle` can jump.
- `public bool CanPretendOccupants { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` can pretend it has the same `Ped`s. Set to `false` to prevent this `Vehicle` from creating new `Ped`s as its occupants.
- `public bool CanStandOnTop { get; }`
  - Gets a value indicating whether `Ped`s can stand on this `Vehicle` regardless of `Vehicle`s speed.
- `public bool CanTiresBurst { get; set; }`
- `public bool CanUseSiren { get; }`
- `public bool CanWheelsBreak { get; set; }`
- `public string ClassDisplayName { get; }`
  - Gets the display name of this `Vehicle`s `VehicleClass`. Use `GetLocalizedString` to get the localized class name.
- `public string ClassLocalizedName { get; }`
  - Gets the localized name of this `Vehicle`s `VehicleClass`.
- `public VehicleClass ClassType { get; }`
  - Gets the class of this `Vehicle`.
- `public float Clutch { get; set; }`
  - Gets or sets the current clutch of this `Vehicle`.
- `public int CountermeasureAmmoCount { get; set; }`
- `public int CurrentGear { get; set; }`
  - Gets or sets the current gear this `Vehicle` is using.
- `public float CurrentRPM { get; set; }`
  - Gets or sets the current RPM of this `Vehicle`.
- `public float DirtLevel { get; set; }`
- `public string DisplayName { get; }`
  - Gets the display name of this `Vehicle`. Use `GetLocalizedString` to get the localized name.
- `public VehicleDoorCollection Doors { get; }`
- `public Ped Driver { get; }`
- `public bool DropsMoneyOnExplosion { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` drops money when destroyed. Only works when the vehicle model is a car, quad bikes or trikes (strictly when the internal vehicle class is CAutomobile or derived class from CAutomobile).
- `public float EngineHealth { get; set; }`
  - Gets or sets this `Vehicle` engine health.
- `public float EnginePowerMultiplier { get; set; }`
- `public float EngineTemperature { get; }`
  - Gets the engine temperature of this `Vehicle`.
- `public float EngineTorqueMultiplier { set; }`
- `public float EnvEffLevel { get; set; }`
- `public VehicleExtraCollection Extras { get; }`
- `public float ForwardSpeed { set; }`
  - Sets this `Vehicle`s forward speed.
- `public float FuelLevel { get; set; }`
  - Gets or sets this `Vehicle` fuel level.
- `public int Gears { get; set; }`
  - **Obsolete.** Use Vehicle.HighGear for the high gear value and Vehicle.CurrentGear for the current gear value instead.
  - Gets or sets the gears value of this `Vehicle`.
- `public HandlingData HandlingData { get; }`
- `public bool HasBombBay { get; }`
- `public bool HasBulletProofGlass { get; }`
- `public bool HasDamageDecals { get; }`
- `public bool HasDonkHydraulics { get; }`
- `public bool HasForks { get; }`
  - Gets a value indicating whether this `Vehicle` has forks.
- `public bool HasLowerFrictionTires { set; }`
- `public bool HasLowriderHydraulics { get; }`
- `public bool HasParachute { get; }`
- `public bool HasRocketBoost { get; }`
- `public bool HasRoof { get; }`
- `public bool HasSiren { get; }`
  - Gets a value indicating whether this `Vehicle` has a siren.
- `public bool HasTowArm { get; }`
- `public float HeliBladesSpeed { get; set; }`
  - Gets or sets the blades speed for this heli.
- `public float HeliEngineHealth { get; set; }`
  - Gets or sets the engine health for this heli.
- `public float HeliMainRotorHealth { get; set; }`
  - Gets or sets the main rotor health for this heli.
- `public float HeliTailRotorHealth { get; set; }`
  - Gets or sets the tail rotor health for this heli.
- `public int HighGear { get; set; }`
- `public bool IsAircraft { get; }`
  - Gets a value indicating whether this `Vehicle` is an aircraft.
- `public bool IsAlarmSet { get; set; }`
  - Sets a value indicating whether this `Vehicle` has an alarm set.
- `public bool IsAlarmSounding { get; }`
  - Gets a value indicating whether this `Vehicle` is sounding its alarm.
- `public bool IsAmphibious { get; }`
  - Gets a value indicating whether this `Vehicle` is an amphibious vehicle.
- `public bool IsAmphibiousAutomobile { get; }`
  - Gets a value indicating whether this `Vehicle` is an amphibious automobile.
- `public bool IsAmphibiousQuadBike { get; }`
  - Gets a value indicating whether this `Vehicle` is an amphibious quad bike.
- `public bool IsAttachedToTrailer { get; }`
- `public bool IsAutomobile { get; }`
  - Gets a value indicating whether this `Vehicle` is an automobile.
- `public bool IsAxlesStrong { set; }`
- `public bool IsBeingBroughtToHalt { get; }`
  - Checks if this `Vehicle` is being brought to a halt.
- `public bool IsBicycle { get; }`
  - Gets a value indicating whether this `Vehicle` is a bicycle.
- `public bool IsBig { get; }`
- `public bool IsBike { get; }`
  - Gets a value indicating whether this `Vehicle` is a bike.
- `public bool IsBlimp { get; }`
  - Gets a value indicating whether this `Vehicle` is a helicopter.
- `public bool IsBoat { get; }`
  - Gets a value indicating whether this `Vehicle` is a boat.
- `public bool IsBurnoutForced { set; }`
- `public bool IsConsideredDestroyed { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` is considered destroyed. Will be set to `true` when `Vehicle`s are exploded or sinking for a short time. `IsDead` will return `true` and `IsDriveable` will return `false` if this value is set to `true`. Does not affect if this `Vehicle` will rendered scorched.
- `public bool IsConvertible { get; }`
- `public bool IsDamaged { get; }`
  - **Obsolete.** Use Vehicle.HasDamageDecals instead.
- `public bool IsDriveable { get; set; }`
- `public bool IsEngineRunning { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle`s engine is running.
- `public bool IsEngineStarting { get; }`
  - Gets or sets a value indicating whether this `Vehicle`s engine is currently starting.
- `public bool IsFrontBumperBrokenOff { get; }`
- `public bool IsHandbrakeForcedOn { set; }`
  - Sets a value indicating whether the Handbrake on this `Vehicle` is forced on.
- `public bool IsHelicopter { get; }`
  - Gets a value indicating whether this `Vehicle` is a helicopter.
- `public bool IsHornActive { get; }`
- `public bool IsHornEnabled { get; set; }`
- `public bool IsInBurnout { get; }`
- `public bool IsInteriorLightOn { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its interior lights on.
- `public bool IsLeftHeadLightBroken { get; set; }`
- `public bool IsLeftIndicatorLightOn { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its left indicator light on.
- `public bool IsMotorcycle { get; }`
  - Gets a value indicating whether this `Vehicle` is a motorcycle.
- `public bool IsOnAllWheels { get; }`
- `public bool IsParachuteDeployed { get; }`
- `public bool IsPlane { get; }`
  - Gets a value indicating whether this `Vehicle` is a plane.
- `public bool IsQuadBike { get; }`
  - Gets a value indicating whether this `Vehicle` is a quad bike.
- `public bool IsRadioEnabled { set; }`
  - Turns this `Vehicle`s radio on or off
- `public bool IsRearBumperBrokenOff { get; }`
- `public bool IsRegularAutomobile { get; }`
  - Gets a value indicating whether this `Vehicle` is a regular automobile.
- `public bool IsRegularQuadBike { get; }`
  - Gets a value indicating whether this `Vehicle` is a regular quad bike.
- `public bool IsRightHeadLightBroken { get; set; }`
- `public bool IsRightIndicatorLightOn { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its right indicator light on.
- `public bool IsRocketBoostActive { get; set; }`
- `public bool IsSearchLightOn { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its search light on.
- `public bool IsSirenActive { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its siren turned on.
- `public bool IsSirenSilent { get; set; }`
  - Sets a value indicating whether the siren on this `Vehicle` plays sounds.
- `public bool IsStolen { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` was stolen.
- `public bool IsStopped { get; }`
- `public bool IsStoppedAtTrafficLights { get; }`
- `public bool IsSubmarine { get; }`
  - Gets a value indicating whether this `Vehicle` is a submarine.
- `public bool IsSubmarineCar { get; }`
  - Gets a value indicating whether this `Vehicle` is a submarine car.
- `public bool IsTaxiLightOn { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` has its taxi light on.
- `public bool IsTrailer { get; }`
  - Gets a value indicating whether this `Vehicle` is a trailer.
- `public bool IsTrain { get; }`
  - Gets a value indicating whether this `Vehicle` is a train.
- `public bool IsUndriveable { set; }`
- `public bool IsWanted { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` is wanted by the police.
- `public VehicleLandingGearState LandingGearState { get; set; }`
- `public float LightsMultiplier { get; set; }`
- `public string LocalizedName { get; }`
  - Gets the localized name of this `Vehicle`
- `public VehicleLockStatus LockStatus { get; set; }`
- `public float LodMultiplier { get; set; }`
- `public float MaxBraking { get; }`
  - Gets the maximum brake power of this `Vehicle`.
- `public float MaxTraction { get; }`
  - Gets the maximum traction of this `Vehicle`.
- `public VehicleModCollection Mods { get; }`
- `public bool NeedsToBeHotwired { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` needs to be hotwired to start.
- `public int NextGear { get; set; }`
  - Gets or sets the next gear value of this `Vehicle`.
- `public Ped[] Occupants { get; }`
- `public float OilLevel { get; set; }`
  - Gets or sets this `Vehicle` oil level. If this value is above zero, this value decreases instead of `EngineHealth` when the engine emits black smoke.
- `public float OilVolume { get; }`
  - Gets the oil volume of this `Vehicle`.
- `public int PassengerCapacity { get; }`
- `public int PassengerCount { get; }`
- `public Ped[] Passengers { get; }`
- `public float PetrolTankHealth { get; set; }`
  - Gets or sets this `Vehicle` petrol tank health.
- `public float PetrolTankVolume { get; }`
  - Gets the petrol tank volume of this `Vehicle`.
- `public bool PreviouslyOwnedByPlayer { get; set; }`
  - Gets or sets a value indicating whether this `Vehicle` was previously owned by a `Player`.
- `public bool ProvidesCover { get; set; }`
  - Gets or sets a value indicating whether peds can use this `Vehicle` for cover.
- `public RadioStation RadioStation { set; }`
  - Sets this `Vehicle`s radio station.
- `public VehicleRoofState RoofState { get; set; }`
- `public bool SpecialFlightModeAllowed { get; set; }`
- `public float SpecialFlightModeCurrentRatio { get; set; }`
- `public float SpecialFlightModeTargetRatio { get; set; }`
- `public float SpecialFlightModeWingRatio { get; set; }`
- `public float SteeringAngle { get; set; }`
  - Gets or sets the steering angle of this `Vehicle`.
- `public float SteeringScale { get; set; }`
  - Gets or sets the steering scale of this `Vehicle`.
- `public float Throttle { get; set; }`
  - Gets or sets the current throttle of this `Vehicle`.
- `public float ThrottlePower { get; set; }`
  - Gets or sets the current throttle power of this `Vehicle`.
- `public float TowArmPosition { set; }`
- `public Vehicle TowedVehicle { get; }`
- `public Vehicle TrailerVehicle { get; }`
- `public float Turbo { get; set; }`
  - Gets or sets the current turbo value of this `Vehicle`.
- `public VehicleType Type { get; }`
  - Gets the type of this `Vehicle`.
- `public VehicleWheelCollection Wheels { get; }`
- `public float WheelSpeed { get; }`
  - Gets the speed the drive wheels are turning at, This is the value used for the dashboard speedometers(after being converted to mph).
- `public VehicleWindowCollection Windows { get; }`

### Methods

- `public void ApplyDamage(Vector3 position, float damageAmount, float radius)`
  - **Obsolete.** Use ApplyDamageDeformation instead.
- `public void ApplyDamageDeformation(Vector3 position, float damage, float deformation, bool localDamage)`
- `public void AttachOnToTrailer(Vehicle trailer, Vector3 offset, Vector3 trailerOffset, Vector3 rotation, float physicalStrength)`
- `public void AttachToTrailer(Vehicle trailer, float inverseMassScale = 1)`
- `public void BringToHalt(float stoppingDistance, int timeToStopFor, bool controlVerticalVelocity = false)`
  - Starts the task to decelerate this `Vehicle` until it comes to rest, possibly in an unphysically short distance.
  - `stoppingDistance`: The distance from the initial coords at which the vehicle should come to rest.
  - `timeToStopFor`: The length of time in seconds to hold the car at rest after stopping.
  - `controlVerticalVelocity`: If `false`, the task allows gravity to act normally in the Z direction. If `true`, the task will also arrest the car's vertical velocity.
- `public void CargoBobMagnetGrabVehicle()`
- `public void CargoBobMagnetReleaseVehicle()`
- `public void CloseBombBay()`
- `public Ped CreatePedOnSeat(VehicleSeat seat, Model model)`
- `public Ped CreateRandomPedOnSeat(VehicleSeat seat)`
- `public void DetachFromTowTruck()`
- `public void DetachFromTrailer()`
- `public void DetachTowedVehicle()`
- `public void DropCargobobHook(CargobobHook hook)`
- `public bool Exists()`
  - Determines if this `Vehicle` exists. You should ensure `Vehicle`s still exist before manipulating them or getting some values for them on every tick, since some native functions may crash the game if invalid entity handles are passed.
  - Returns: `true` if this `Vehicle` exists; otherwise, `false`
- `public void Explode()`
  - Explode this `Vehicle` instantaneously.
- `public bool ExtraExists(int extra)`
  - **Obsolete.** Use Vehicle.Extras[VehicleExtraIndex].Exists() instead!
- `public void ForceUseAudioGameObject(string gameObjectName)`
- `public VehicleMissionType GetActiveMissionType()`
  - Gets active vehicle mission type.
- `public Ped GetPedOnSeat(VehicleSeat seat)`
- `public int GetRestrictedAmmoCount(int vehicleWeaponIndex)`
- `public bool IsCargobobHookActive()`
- `public bool IsCargobobHookActive(CargobobHook hook)`
- `public bool IsExtraOn(int extra)`
  - **Obsolete.** Use Vehicle.Extras[VehicleExtraIndex].Enabled instead!
- `public bool IsSeatFree(VehicleSeat seat)`
- `public bool IsStuckTimerUp(VehicleStuckType stuckType, ushort requiredTime)`
- `public void OpenBombBay()`
- `public bool PlaceOnGround()`
- `public void PlaceOnNextStreet()`
- `public void Repair()`
  - Repair all damage to this `Vehicle` instantaneously.
- `public void ResetVehicleStuckTimer(VehicleStuckType stuckType)`
- `public void RetractCargobobHook()`
- `public void SetHeliYawPitchRollMult(float mult)`
- `public void SetHydraulicsControl(bool toggle)`
- `public void SetReducedGripLevel(int level)`
- `public void SetRestrictedAmmoCount(int vehicleWeaponIndex, int ammoCount)`
- `public void SetScriptedLightSetting(ScriptedVehicleLightSetting lightSetting)`
- `public void SetTrailerLegsLowered()`
- `public void SetTrailerLegsRaised()`
- `public void SoundHorn(int duration)`
  - Sounds the horn on this `Vehicle`.
  - `duration`: The duration in milliseconds to sound the horn for.
- `public void StartAlarm()`
  - Starts sounding the alarm on this `Vehicle`.
- `public void StartParachuting(bool allowPlayerToCancel)`
  - Open the vehicle's parachute (if any)
  - `allowPlayerToCancel`: Whether to allow the player to cancel parachuting before the vehicle lands
- `public void StopBringingToHalt()`
  - Stops bringing this `Vehicle` to a halt.
- `public void ToggleExtra(int extra, bool toggle)`
  - **Obsolete.** Use Vehicle.Extras[VehicleExtraIndex].Enabled instead!
- `public void TowVehicle(EntityBone vehicleBone, Vector3 attachPointOffset)`
- `public void TowVehicle(Vehicle vehicle, Vector3 attachPointOffset)`
- `public void TowVehicle(Vehicle vehicle, bool rear)`
  - **Obsolete.** Vehicle.TowVehicle(Vehicle, bool) is obsolete because the bone index parameter is incorrectly used as a bool parameter. Use one of the other overload instead.
- `public bool TrySetCanUseSiren(bool value)`
- `public void Wash()`
- `public static Vehicle Create(Model model, Vector3 position, float heading = 0)`
- `public static Vehicle CreateRandom(Vector3 position, float heading = 0, Func<Model, bool> predicate = null)`
- `public static VehicleHash[] GetAllLoadedModelsAppropriateForAmbientVehicles()`
  - Gets an `array` of all loaded `VehicleHash`s that is appropriate to spawn as ambient vehicles. All the model hashes of the elements are loaded and the `Vehicle`s with the model hashes can be spawned immediately.
- `public static VehicleHash[] GetAllModels()`
- `public static VehicleHash[] GetAllModelsOfClass(VehicleClass vehicleClass)`
- `public static VehicleHash[] GetAllModelsOfType(VehicleType vehicleType)`
- `public static int[] GetAllModelValues()`
- `public static string GetClassDisplayName(VehicleClass vehicleClass)`
- `public static VehicleClass GetModelClass(Model vehicleModel)`
- `public static string GetModelDisplayName(Model vehicleModel)`
- `public static string GetModelMakeName(Model vehicleModel)`
- `public static VehicleType GetModelType(Model vehicleModel)`

## VehicleChaseBehaviorFlags

enum `GTA.VehicleChaseBehaviorFlags`

| Name | Value |
| --- | --- |
| `CantBlock` | 1 |
| `CantBlockFromPursue` | 2 |
| `CantPursue` | 4 |
| `CantRam` | 8 |
| `CantSpinOut` | 16 |
| `CantMakeAggressiveMove` | 32 |
| `CantCruiseInFrontDuringBlock` | 64 |
| `UseContinuousRam` | 128 |
| `CantPullAlongside` | 256 |
| `CantPullAlongsideInFront` | 512 |

## VehicleClass

enum `GTA.VehicleClass`

| Name | Value |
| --- | --- |
| `Compacts` | 0 |
| `Sedans` | 1 |
| `SUVs` | 2 |
| `Coupes` | 3 |
| `Muscle` | 4 |
| `SportsClassics` | 5 |
| `Sports` | 6 |
| `Super` | 7 |
| `Motorcycles` | 8 |
| `OffRoad` | 9 |
| `Industrial` | 10 |
| `Utility` | 11 |
| `Vans` | 12 |
| `Cycles` | 13 |
| `Boats` | 14 |
| `Helicopters` | 15 |
| `Planes` | 16 |
| `Service` | 17 |
| `Emergency` | 18 |
| `Military` | 19 |
| `Commercial` | 20 |
| `Trains` | 21 |
| `OpenWheel` | 22 |

## VehicleColor

enum `GTA.VehicleColor`

161 values:

```text
MetallicBlack = 0
MetallicGraphiteBlack = 1
MetallicBlackSteel = 2
MetallicDarkSilver = 3
MetallicSilver = 4
MetallicBlueSilver = 5
MetallicSteelGray = 6
MetallicShadowSilver = 7
MetallicStoneSilver = 8
MetallicMidnightSilver = 9
MetallicGunMetal = 10
MetallicAnthraciteGray = 11
MatteBlack = 12
MatteGray = 13
MatteLightGray = 14
UtilBlack = 15
UtilBlackPoly = 16
UtilDarksilver = 17
UtilSilver = 18
UtilGunMetal = 19
UtilShadowSilver = 20
WornBlack = 21
WornGraphite = 22
WornSilverGray = 23
WornSilver = 24
WornBlueSilver = 25
WornShadowSilver = 26
MetallicRed = 27
MetallicTorinoRed = 28
MetallicFormulaRed = 29
MetallicBlazeRed = 30
MetallicGracefulRed = 31
MetallicGarnetRed = 32
MetallicDesertRed = 33
MetallicCabernetRed = 34
MetallicCandyRed = 35
MetallicSunriseOrange = 36
MetallicClassicGold = 37
MetallicOrange = 38
MatteRed = 39
MatteDarkRed = 40
MatteOrange = 41
MatteYellow = 42
UtilRed = 43
UtilBrightRed = 44
UtilGarnetRed = 45
WornRed = 46
WornGoldenRed = 47
WornDarkRed = 48
MetallicDarkGreen = 49
MetallicRacingGreen = 50
MetallicSeaGreen = 51
MetallicOliveGreen = 52
MetallicGreen = 53
MetallicGasolineBlueGreen = 54
MatteLimeGreen = 55
UtilDarkGreen = 56
UtilGreen = 57
WornDarkGreen = 58
WornGreen = 59
WornSeaWash = 60
MetallicMidnightBlue = 61
MetallicDarkBlue = 62
MetallicSaxonyBlue = 63
MetallicBlue = 64
MetallicMarinerBlue = 65
MetallicHarborBlue = 66
MetallicDiamondBlue = 67
MetallicSurfBlue = 68
MetallicNauticalBlue = 69
MetallicBrightBlue = 70
MetallicPurpleBlue = 71
MetallicSpinnakerBlue = 72
MetallicUltraBlue = 73
MetallicBrightBlue2 = 74
UtilDarkBlue = 75
UtilMidnightBlue = 76
UtilBlue = 77
UtilSeaFoamBlue = 78
UtilLightningBlue = 79
UtilMauiBluePoly = 80
UtilBrightBlue = 81
MatteDarkBlue = 82
MatteBlue = 83
MatteMidnightBlue = 84
WornDarkBlue = 85
WornBlue = 86
WornLightBlue = 87
MetallicTaxiYellow = 88
MetallicRaceYellow = 89
MetallicBronze = 90
MetallicYellowBird = 91
MetallicLime = 92
MetallicChampagne = 93
MetallicPuebloBeige = 94
MetallicDarkIvory = 95
MetallicChocoBrown = 96
MetallicGoldenBrown = 97
MetallicLightBrown = 98
MetallicStrawBeige = 99
MetallicMossBrown = 100
MetallicBistonBrown = 101
MetallicBeechwood = 102
MetallicDarkBeechwood = 103
MetallicChocoOrange = 104
MetallicBeachSand = 105
MetallicSunBleechedSand = 106
MetallicCream = 107
UtilBrown = 108
UtilMediumBrown = 109
UtilLightBrown = 110
MetallicWhite = 111
MetallicFrostWhite = 112
WornHoneyBeige = 113
WornBrown = 114
WornDarkBrown = 115
WornStrawBeige = 116
BrushedSteel = 117
BrushedBlackSteel = 118
BrushedAluminium = 119
Chrome = 120
WornOffWhite = 121
UtilOffWhite = 122
WornOrange = 123
WornLightOrange = 124
MetallicSecuricorGreen = 125
WornTaxiYellow = 126
PoliceCarBlue = 127
MatteGreen = 128
MatteBrown = 129
WornOrange2 = 130
MatteWhite = 131
WornWhite = 132
WornOliveArmyGreen = 133
PureWhite = 134
HotPink = 135
Salmonpink = 136
MetallicVermillionPink = 137
Orange = 138
Green = 139
Blue = 140
MettalicBlackBlue = 141
MetallicBlackPurple = 142
MetallicBlackRed = 143
HunterGreen = 144
MetallicPurple = 145
MetaillicVDarkBlue = 146
ModshopBlack1 = 147
MattePurple = 148
MatteDarkPurple = 149
MetallicLavaRed = 150
MatteForestGreen = 151
MatteOliveDrab = 152
MatteDesertBrown = 153
MatteDesertTan = 154
MatteFoliageGreen = 155
DefaultAlloyColor = 156
EpsilonBlue = 157
PureGold = 158
BrushedGold = 159
MP100GoldSpecular = 160
```

## VehicleDoor

class `GTA.VehicleDoor`

### Properties

- `public float AngleRatio { get; set; }`
- `public bool CanBeBroken { set; }`
- `public VehicleDoorIndex Index { get; }`
- `public bool IsBroken { get; }`
- `public bool IsFullyOpen { get; }`
- `public bool IsOpen { get; }`
- `public Vehicle Vehicle { get; }`

### Methods

- `public void Break(bool stayInTheWorld = true)`
- `public void Close(bool instantly = false)`
- `public void Open(bool loose = false, bool instantly = false)`

## VehicleDoorCollection

class `GTA.VehicleDoorCollection`

### Properties

- `public VehicleDoor this[VehicleDoorIndex index] { get; }`

### Methods

- `public bool Contains(VehicleDoorIndex door)`
- `public IEnumerator<VehicleDoor> GetEnumerator()`
- `public VehicleDoor[] ToArray()`

## VehicleDoorIndex

enum `GTA.VehicleDoorIndex`

| Name | Value |
| --- | --- |
| `FrontRightDoor` | 1 |
| `FrontLeftDoor` | 0 |
| `BackRightDoor` | 3 |
| `BackLeftDoor` | 2 |
| `Hood` | 4 |
| `Trunk` | 5 |

## VehicleDrivingFlags

enum `GTA.VehicleDrivingFlags`

| Name | Value | Description |
| --- | --- | --- |
| `None` | 0 |  |
| `StopForVehicles` | 1 |  |
| `StopForPeds` | 2 |  |
| `SwerveAroundAllVehicles` | 4 |  |
| `SteerAroundStationaryVehicles` | 8 |  |
| `SteerAroundPeds` | 16 |  |
| `SteerAroundObjects` | 32 |  |
| `DontSteerAroundPlayerPed` | 64 | Don't steer around the player ped even if `SteerAroundPeds` is set. |
| `StopAtTrafficLights` | 128 |  |
| `GoOffRoadWhenAvoiding` | 256 | Make the `Ped` prefer to go off the road rather than enter oncoming lanes when avoiding (steering around) obstacles if the correct lanes are full. Even if this value is set, the `Ped` will try to steer around obstacles by entering other correct lanes if the correct lanes are not full. |
| `AllowGoingWrongWay` | 512 | Allow the `Ped` to drive into the oncoming traffic if the correct lanes are full. Even if this value is set, the `Ped` will try to reach the correct lanes again as soon as possible. |
| `Reverse` | 1024 |  |
| `UseWanderFallbackInsteadOfStraightLine` | 2048 | If pathfinding fails, cruise randomly instead of going on a straight line. |
| `AvoidRestrictedAreas` | 4096 |  |
| `PreventBackgroundPathfinding` | 8192 | Only works when the car mission is set to MISSION_CRUISE. |
| `AdjustCruiseSpeedBasedOnRoadSpeed` | 16384 | Limit the speed based on the road speed if the max cruise speed for driving tasks exceeds the road speed. Only works when the car mission is set to MISSION_CRUISE. |
| `UseShortCutLinks` | 262144 | Allow the `Ped` to use short cut links (e.g. the 180? turns on the highways without the direction sign). |
| `ChangeLanesAroundObstructions` | 524288 | Make the driver change lanes around obstructions. Without this flag, even small obstacles make the driver completely change lanes. |
| `UseSwitchedOffNodes` | 2097152 | Allow the `Ped` to drive on switched off nodes, which are usually located at paths whose colors on the map are darker than roads for driving (e.g. some dirt roads), and on parking lots. You can check if some nodes are marked as switched off with `GET_VEHICLE_NODE_IS_SWITCHED_OFF`. |
| `PreferNavmeshRoute` | 4194304 | Make `Ped` prefer navigation mesh routes rather than vehicle nodes. Can be useful if you're going to be primarily driving off road. |
| `PlaneTaxiMode` | 8388608 | Only works for planes using `MISSION_GOTO`, will cause them to drive along the ground instead of fly. |
| `ForceStraightLine` | 16777216 | Force to go to the target directly instead of following the nodes regardless of the distance config for driving or vehicle mission tasks at which the ai switches to heading for the target directly. |
| `UseStringPullingAtJunctions` | 33554432 |  |
| `TryToAvoidHighways` | 536870912 | Avoid the highway unless the `Ped` has to drive on it to achieve the vehicle task. |
| `ForceJoinInRoadDirection` | 1073741824 |  |
| `StopAtDestination` | 2147483648 |  |
| `DrivingModeStopForVehicles` | 786603 | Standard driving mode. stops for cars, peds, and lights, goes around stationary obstructions, and obey lights. |
| `DrivingModeStopForVehiclesStrict` | 262275 | Like `DrivingModeStopForVehicles`, but doesn't steer around anything in its way - will only wait instead (doesn't deviate an inch). |
| `DrivingModeAvoidVehicles` | 786469 | Default "alerted" driving mode. Drives around everything, doesn't obey lights. |
| `DrivingModeAvoidVehiclesReckless` | 786468 | Very erratic driving. difference between this and `DrivingModeAvoidVehicles` is that it doesn't use the brakes at ALL to help with steering. |
| `DrivingModePloughThrough` | 262144 | Smashes through everything. |
| `DrivingModeStopForVehiclesIgnoreLights` | 786475 | Drives normally except for the fact that it ignores lights. |
| `DrivingModeAvoidVehiclesObeyLights` | 786597 | Try to swerve around everything, but stop for lights if necessary. |
| `DrivingModeAvoidVehiclesStopForPedsObeyLights` | 786599 | Swerve around cars, be careful around peds, and stop for lights. |
| `UseBlinkers` | 256 |  |
| `FollowTraffic` | 1 |  |
| `YieldToPeds` | 2 |  |
| `AvoidVehicles` | 4 |  |
| `AvoidEmptyVehicles` | 8 |  |
| `AvoidPeds` | 16 |  |
| `AvoidObjects` | 32 |  |
| `AllowMedianCrossing` | 262144 |  |
| `IgnorePathFinding` | 16777216 |  |
| `DriveBySight` | 4194304 |  |

## VehicleEscortType

enum `GTA.VehicleEscortType`

| Name | Value |
| --- | --- |
| `Rear` | -1 |
| `Front` | 0 |
| `Left` | 1 |
| `Right` | 2 |

## VehicleExtra

class `GTA.VehicleExtra`

### Properties

- `public EntityBone Bone { get; }`
- `public bool Enabled { get; set; }`
- `public VehicleExtraIndex Index { get; }`
- `public bool IsBrokenOff { get; }`
- `public Vehicle Owner { get; }`

### Methods

- `public bool BreakOff()`
- `public bool Exists()`

## VehicleExtraCollection

class `GTA.VehicleExtraCollection` : `IEnumerable<VehicleExtra>`, `IEnumerable`

### Properties

- `public VehicleExtra this[VehicleExtraIndex extra] { get; }`
- `public Vehicle Owner { get; }`

### Methods

- `public bool Contains(VehicleExtraIndex extra)`
- `public VehicleExtraCollection.Enumerator GetEnumerator()`
- `public VehicleExtra[] ToArray()`

## VehicleExtraCollection.Enumerator

struct `GTA.VehicleExtraCollection.Enumerator` : `IEnumerator<VehicleExtra>`, `IDisposable`, `IEnumerator`

### Properties

- `public VehicleExtra Current { get; }`

### Methods

- `public void Dispose()`
- `public bool MoveNext()`

## VehicleExtraIndex

enum `GTA.VehicleExtraIndex`

| Name | Value |
| --- | --- |
| `Extra1` | 1 |
| `Extra2` | 2 |
| `Extra3` | 3 |
| `Extra4` | 4 |
| `Extra5` | 5 |
| `Extra6` | 6 |
| `Extra7` | 7 |
| `Extra8` | 8 |
| `Extra9` | 9 |
| `Extra10` | 10 |
| `Extra11` | 11 |
| `Extra12` | 12 |
| `Extra13` | 13 |
| `Extra14` | 14 |
| `Extra15` | 15 |
| `Extra16` | 16 |

## VehicleHash

enum `GTA.VehicleHash`

843 values:

```text
Adder = 3078201489
Airbus = 1283517198
Airtug = 1560980623
Akula = 1181327175
Akuma = 1672195559
Aleutian = 4256087847
Alkonost = 3929093893
Alpha = 767087018
AlphaZ1 = 2771347558
Ambulance = 1171614426
Annihilator = 837858166
Annihilator2 = 295054921
Apc = 562680400
Ardent = 159274291
ArmyTanker = 3087536137
ArmyTrailer = 2818520053
ArmyTrailer2 = 2657817814
Asbo = 1118611807
Astron = 629969764
Asea = 2485144969
Asea2 = 2487343317
Asterope = 2391954683
Asterope2 = 3553846961
Autarch = 3981782132
Avarus = 2179174271
Avenger = 2176659152
Avenger2 = 408970549
Avenger3 = 3868033424
Avenger4 = 4225674290
Avisa = 2588363614
Bagger = 2154536131
BaleTrailer = 3895125590
Baller = 3486135912
Baller2 = 142944341
Baller3 = 1878062887
Baller4 = 634118882
Baller5 = 470404958
Baller6 = 666166960
Baller7 = 359875117
Baller8 = 3431608412
Banshee = 3253274834
Banshee2 = 633712403
Barracks = 3471458123
Barracks2 = 1074326203
Barracks3 = 630371791
Barrage = 4081974053
Bati = 4180675781
Bati2 = 3403504941
Benson = 2053223216
Benson2 = 728350375
Besra = 1824333165
BestiaGTS = 1274868363
BF400 = 86520421
BfInjection = 1126868326
Biff = 850991848
Bifta = 3945366167
Bison = 4278019151
Bison2 = 2072156101
Bison3 = 1739845664
BJXL = 850565707
Blade = 3089165662
Blazer = 2166734073
Blazer2 = 4246935337
Blazer3 = 3025077634
Blazer4 = 3854198872
Blazer5 = 2704629607
Blimp = 4143991942
Blimp2 = 3681241380
Blimp3 = 3987008919
Blista = 3950024287
Blista2 = 1039032026
Blista3 = 3703315515
Bmx = 1131912276
BoatTrailer = 524108981
BoatTrailer2 = 1835260592
BoatTrailer3 = 1539159908
BobcatXL = 1069929536
Bodhi2 = 2859047862
Bombushka = 4262088844
Boor = 996383885
Boxville = 2307837162
Boxville2 = 4061868990
Boxville3 = 121658888
Boxville4 = 444171386
Boxville5 = 682434785
Boxville6 = 3452201761
Brawler = 2815302597
Brickade = 3989239879
Brickade2 = 2718380883
Brigham = 3640468689
Brioso = 1549126457
Brioso2 = 1429622905
Brioso3 = 15214558
Bruiser = 668439077
Bruiser2 = 2600885406
Bruiser3 = 2252616474
Brutus = 2139203625
Brutus2 = 2403970600
Brutus3 = 2038858402
BType = 117401876
BType2 = 3463132580
BType3 = 3692679425
Buccaneer = 3612755468
Buccaneer2 = 3281516360
Buffalo = 3990165190
Buffalo2 = 736902334
Buffalo3 = 237764926
Buffalo4 = 3675036420
Buffalo5 = 165968051
Bulldozer = 1886712733
Bullet = 2598821281
Burrito = 2948279460
Burrito2 = 3387490166
Burrito3 = 2551651283
Burrito4 = 893081117
Burrito5 = 1132262048
Bus = 3581397346
Buzzard = 788747387
Buzzard2 = 745926877
CableCar = 3334677549
Caddy = 1147287684
Caddy2 = 3757070668
Caddy3 = 3525819835
Calico = 3101054893
Camper = 1876516712
Caracara = 1254014755
Caracara2 = 2945871676
Carbonizzare = 2072687711
CarbonRS = 11251904
Cargobob = 4244420235
Cargobob2 = 1621617168
Cargobob3 = 1394036463
Cargobob4 = 2025593404
CargoPlane = 368211810
CargoPlane2 = 2336777441
Casco = 941800958
Cavalcade = 2006918058
Cavalcade2 = 3505073125
Cavalcade3 = 3265236814
Cerberus = 3493417227
Cerberus2 = 679453769
Cerberus3 = 1909700336
Champion = 3379732821
Cheburek = 3306466016
Cheetah = 2983812512
Cheetah2 = 223240013
Chernobog = 3602674979
Chimera = 6774487
Chino = 349605904
Chino2 = 2933279331
Cinquemila = 2767531027
Clique = 2728360112
Clique2 = 3315674721
Cliffhanger = 390201602
Club = 2196012677
Coach = 2222034228
Cog55 = 906642318
Cog552 = 704435172
CogCabrio = 330661258
Cognoscenti = 2264796000
Cognoscenti2 = 3690124666
Comet2 = 3249425686
Comet3 = 2272483501
Comet4 = 1561920505
Comet5 = 661493923
Comet6 = 2568944644
Comet7 = 1141395928
Conada = 3817135397
Conada2 = 2635962482
Contender = 683047626
Coquette = 108773431
Coquette2 = 1011753235
Coquette3 = 784565758
Coquette4 = 2566281822
Corsita = 3540279623
Coureur = 610429990
Cruiser = 448402357
Crusader = 321739290
Cuban800 = 3650256867
Cutter = 3288047904
Cyclone = 1392481335
Cypher = 1755697647
Daemon = 2006142190
Daemon2 = 2890830793
DeathBike = 4267640610
DeathBike2 = 2482017624
DeathBike3 = 2920466844
Defiler = 822018448
Deity = 1532171089
Deluxo = 1483171323
Deveste = 1591739866
Deviant = 1279262537
Diablous = 4055125828
Diablous2 = 1790834270
Dilettante = 3164157193
Dilettante2 = 1682114128
Dinghy = 1033245328
Dinghy2 = 276773164
Dinghy3 = 509498602
Dinghy4 = 867467158
Dinghy5 = 3314393930
DLoader = 1770332643
DockTrailer = 2154757102
Docktug = 3410276810
Dodo = 3393804037
Dominator = 80636076
Dominator2 = 3379262425
Dominator3 = 3308022675
Dominator4 = 3606777648
Dominator5 = 2919906639
Dominator6 = 3001042683
Dominator7 = 426742808
Dominator8 = 736672010
Dominator9 = 3853757601
Dorado = 3526923154
Double = 2623969160
Drafter = 686471183
Draugur = 3526730918
DriftEuros = 821121576
DriftFR36 = 2815031719
DriftFuto = 4113404654
DriftJester = 2531693357
DriftRemus = 2670883828
DriftTampa = 2598648200
DriftYosemite = 2613313775
DriftZR350 = 1923534526
Dubsta = 1177543287
Dubsta2 = 3900892662
Dubsta3 = 3057713523
Dukes = 723973206
Dukes2 = 3968823444
Dukes3 = 2134119907
Dump = 2164484578
Dune = 2633113103
Dune2 = 534258863
Dune3 = 1897744184
Dune4 = 3467805257
Dune5 = 3982671785
Duster = 970356638
Dynasty = 310284501
Elegy = 196747873
Elegy2 = 3728579874
Ellie = 3027423925
Emerus = 1323778901
Emperor = 3609690755
Emperor2 = 2411965148
Emperor3 = 3053254478
Enduro = 1753414259
EntityMT = 1748565021
EntityXF = 3003014393
EntityXXR = 2174267100
Esskey = 2035069708
Eudora = 3045179290
Euros = 2038480341
Everon = 2538945576
Everon2 = 4163619118
Exemplar = 4289813342
F620 = 3703357000
Faction = 2175389151
Faction2 = 2504420315
Faction3 = 2255212070
Fagaloa = 1617472902
Faggio = 2452219115
Faggio2 = 55628203
Faggio3 = 3005788552
FBI = 1127131465
FBI2 = 2647026068
FCR = 627535535
FCR2 = 3537231886
Felon = 3903372712
Felon2 = 4205676014
Feltzer2 = 2299640309
Feltzer3 = 2728226064
FireTruck = 1938952078
Fixter = 3458454463
FlashGT = 3035832600
Flatbed = 1353720154
FMJ = 1426219628
Forklift = 1491375716
Formula = 340154634
Formula2 = 2334210311
FQ2 = 3157435195
FR36 = 3829141989
Freecrawler = 4240635011
Freight = 1030400667
Freight2 = 3852738056
FreightCar = 184361638
FreightCar2 = 3186376089
FreightCont1 = 920453016
FreightCont2 = 240201337
FreightGrain = 642617954
FreightTrailer = 3517691494
Frogger = 744705981
Frogger2 = 1949211328
Fugitive = 1909141499
Furia = 960812448
Furoregt = 3205927392
Fusilade = 499169875
Futo = 2016857647
Futo2 = 2787736776
Gargoyle = 741090084
Gauntlet = 2494797253
Gauntlet2 = 349315417
Gauntlet3 = 722226637
Gauntlet4 = 1934384720
Gauntlet5 = 2172320429
Gauntlet6 = 1336514315
GB200 = 1909189272
GBurrito = 2549763894
GBurrito2 = 296357396
Glendale = 75131841
Glendale2 = 3381377750
GP1 = 1234311532
GrainTrailer = 1019737494
Granger = 2519238556
Granger2 = 4033620423
Greenwood = 40817712
Gresley = 2751205197
Growler = 1304459735
GT500 = 2215179066
Guardian = 2186977100
Habanero = 884422927
Hakuchou = 1265391242
Hakuchou2 = 4039289119
HalfTrack = 4262731174
Handler = 444583674
Hauler = 1518533038
Hauler2 = 387748548
Havok = 2310691317
Hellion = 3932816511
Hermes = 15219735
Hexer = 301427732
Hotknife = 37348240
HotringSabre = 1115909093
Howard = 3287439187
Hunter = 4252008158
Huntley = 486987393
Hustler = 600450546
Hydra = 970385471
Inductor = 3397143273
Inductor2 = 2311345272
Ignus = 2850852987
Imorgon = 3162245632
Impaler = 2198276962
Impaler2 = 1009171724
Impaler3 = 2370166601
Impaler4 = 2550461639
Impaler5 = 3816328113
Impaler6 = 4116524922
Imperator = 444994115
Imperator2 = 1637620610
Imperator3 = 3539435063
Infernus = 418536135
Infernus2 = 2889029532
Ingot = 3005245074
Innovation = 4135840458
Insurgent = 2434067162
Insurgent2 = 2071877360
Insurgent3 = 2370534026
Intruder = 886934177
Issi2 = 3117103977
Issi3 = 931280609
Issi4 = 628003514
Issi5 = 1537277726
Issi6 = 1239571361
Issi7 = 1854776567
Issi8 = 1550581940
ItaliGTB = 2246633323
ItaliGTB2 = 3812247419
ItaliGTO = 3963499524
ItaliRSX = 3145241962
IWagen = 662793086
Jackal = 3670438162
JB700 = 1051415893
JB7002 = 394110044
Jester = 2997294755
Jester2 = 3188613414
Jester3 = 4080061290
Jester4 = 2712905841
Jet = 1058115860
Jetmax = 861409633
Journey = 4174679674
Journey2 = 2667889793
Jubilee = 461465043
Jugular = 4086055493
Kalahari = 92612664
Kamacho = 4173521127
Kanjo = 409049982
KanjoSJ = 4230891418
Khamelion = 544021352
Khanjali = 2859440138
Komoda = 3460613305
Kosatka = 1336872304
Krieger = 3630826055
Kuruma = 2922118804
Kuruma2 = 410882957
L35 = 2531292011
Landstalker = 1269098716
Landstalker2 = 3456868130
Lazer = 3013282534
LE7B = 3062131285
Lectro = 640818791
Lguard = 469291905
Limo2 = 4180339789
LM87 = 4284049613
Locust = 3353694737
Longfin = 1861786828
Lurcher = 2068293287
Luxor = 621481054
Luxor2 = 3080673438
Lynx = 482197771
Mamba = 2634021974
Mammatus = 2548391185
Menacer = 2044532910
Manana = 2170765704
Manana2 = 1717532765
Manchez = 2771538552
Manchez2 = 1086534307
Manchez3 = 1384502824
Marquis = 3251507587
Marshall = 1233534620
Massacro = 4152024626
Massacro2 = 3663206819
Maverick = 2634305738
Mesa = 914654722
Mesa2 = 3546958660
Mesa3 = 2230595153
MetroTrain = 868868440
Michelli = 1046206681
Microlight = 2531412055
Miljet = 165154707
MiniTank = 3040635986
Minivan = 3984502180
Minivan2 = 3168702960
Mixer = 3510150843
Mixer2 = 475220373
Mogul = 3545667823
Molotok = 1565978651
Monroe = 3861591579
Monster = 3449006043
Monster3 = 1721676810
Monster4 = 840387324
Monster5 = 3579220348
MonstroCiti = 802856453
Moonbeam = 525509695
Moonbeam2 = 1896491931
Mower = 1783355638
Mule = 904750859
Mule2 = 3244501995
Mule3 = 2242229361
Mule4 = 1945374990
Mule5 = 1343932732
Nebula = 3412338231
Nemesis = 3660088182
Neo = 2674840994
Neon = 2445973230
Nero = 1034187331
Nero2 = 1093792632
Nightblade = 2688780135
Nightshade = 2351681756
NightShark = 433954513
Nimbus = 2999939664
Ninef = 1032823388
Ninef2 = 2833484545
Nokota = 1036591958
Novak = 2465530446
Omnis = 3517794615
OmniseGT = 3789743831
OpenWheel1 = 1492612435
OpenWheel2 = 1181339704
Oppressor = 884483972
Oppressor2 = 2069146067
Oracle = 1348744438
Oracle2 = 3783366066
Osiris = 1987142870
Outlaw = 408825843
Packer = 569305213
Panthere = 2100457220
Panto = 3863274624
Paradise = 1488164764
Paragon = 3847255899
Paragon2 = 1416466158
Pariah = 867799010
Patriot = 3486509883
Patriot2 = 3874056184
Patriot3 = 3624880708
PatrolBoat = 4018222598
PBus = 2287941233
PBus2 = 345756458
PCJ = 3385765638
Penetrator = 2536829930
Penumbra = 3917501776
Penumbra2 = 3663644634
Peyote = 1830407356
Peyote2 = 2490551588
Peyote3 = 1107404867
Pfister811 = 2465164804
Phantom = 2157618379
Phantom2 = 2645431192
Phantom3 = 177270108
Phantom4 = 4165683409
Phoenix = 2199527893
Picador = 1507916787
Pigalle = 1078682497
PolGauntlet = 3061199846
Police = 2046537925
Police2 = 2667966721
Police3 = 1912215274
Police4 = 2321795001
Police5 = 2620582743
Policeb = 4260343491
PoliceOld1 = 2758042359
PoliceOld2 = 2515846680
PoliceT = 456714581
Polmav = 353883353
Pony = 4175309224
Pony2 = 943752001
Postlude = 4000288633
Pounder = 2112052861
Pounder2 = 1653666139
Powersurge = 2908631255
Prairie = 2844316578
Pranger = 741586030
Predator = 3806844075
Premier = 2411098011
Previon = 1416471345
Primo = 3144368207
Primo2 = 2254540506
PropTrailer = 356391690
Prototipo = 2123327359
Pyro = 2908775872
R300 = 1076201208
Radi = 2643899483
Raiden = 2765724541
Raiju = 239897677
RakeTrailer = 390902130
RancherXL = 1645267888
RancherXL2 = 1933662059
RallyTruck = 2191146052
RapidGT = 2360515092
RapidGT2 = 1737773231
RapidGT3 = 2049897956
Raptor = 3620039993
RatBike = 1873600305
Ratel = 3758861739
RatLoader = 3627815886
RatLoader2 = 3705788919
RCBandito = 4008920556
RE7B = 3062131285
Rebla = 83136452
Reaper = 234062309
Rebel = 3087195462
Rebel2 = 2249373259
Reever = 1993851908
Regina = 4280472072
Remus = 1377217886
RentalBus = 3196165219
Retinue = 1841130506
Retinue2 = 2031587082
Revolter = 3884762073
Rhapsody = 841808271
Rhinehart = 2439462158
Rhino = 782665360
Riata = 2762269779
Riot = 3089277354
Riot2 = 2601952180
Ripley = 3448987385
Rocoto = 2136773105
Rogue = 3319621991
Romero = 627094268
RRocket = 916547552
RT3000 = 3842363289
Rubble = 2589662668
Ruffian = 3401388520
Ruiner = 4067225593
Ruiner2 = 941494461
Ruiner3 = 777714999
Ruiner4 = 1706945532
Rumpo = 1162065741
Rumpo2 = 2518351607
Rumpo3 = 1475773103
Ruston = 719660200
SabreGT = 2609945748
SabreGT2 = 223258115
S80 = 3970348707
Sadler = 3695398481
Sadler2 = 734217681
Sanchez = 788045382
Sanchez2 = 2841686334
Sanctus = 1491277511
Sandking = 3105951696
Sandking2 = 989381445
Savage = 4212341271
Savestra = 903794909
SC1 = 1352136073
Scarab = 3147997943
Scarab2 = 1542143200
Scarab3 = 3715219435
Schafter2 = 3039514899
Schafter3 = 2809443750
Schafter4 = 1489967196
Schafter5 = 3406724313
Schafter6 = 1922255844
Schlagen = 3787471536
Schwarzer = 3548084598
Scorcher = 4108429845
Scramjet = 3656405053
Scrap = 2594165727
Seabreeze = 3902291871
Seashark = 3264692260
Seashark2 = 3678636260
Seashark3 = 3983945033
SeaSparrow = 3568198617
SeaSparrow2 = 1229411063
SeaSparrow3 = 1593933419
Seminole = 1221512915
Seminole2 = 2484160806
Sentinel = 1349725314
Sentinel2 = 873639469
Sentinel3 = 1104234922
Sentinel4 = 2938086457
Serrano = 1337041428
Seven70 = 2537130571
Shamal = 3080461301
Sheava = 819197656
Sheriff = 2611638396
Sheriff2 = 1922257928
Shinobi = 1353120668
Shotaro = 3889340782
Skylift = 1044954915
Slamtruck = 3249056020
SlamVan = 729783779
SlamVan2 = 833469436
SlamVan3 = 1119641113
SlamVan4 = 2233918197
SlamVan5 = 373261600
SlamVan6 = 1742022738
SM722 = 775514032
Sovereign = 743478836
Specter = 1886268224
Specter2 = 1074745671
Speeder = 231083307
Speeder2 = 437538602
Speedo = 3484649228
Speedo2 = 728614474
Speedo4 = 219613597
Speedo5 = 4250167832
Squaddie = 4192631813
Squalo = 400514754
Stafford = 321186144
Stalion = 1923400478
Stalion2 = 3893323758
Stanier = 2817386317
Starling = 2594093022
Stinger = 1545842587
StingerGT = 2196019706
StingerTT = 1447690049
Stockade = 1747439474
Stockade3 = 4080511798
Stratum = 1723137093
Streamer216 = 191916658
Streiter = 1741861769
Stretch = 2333339779
Strikeforce = 1692272545
Stromberg = 886810209
Stryder = 301304410
Stunt = 2172210288
Submersible = 771711535
Submersible2 = 3228633070
Sugoi = 987469656
Sultan = 970598228
Sultan2 = 872704284
Sultan3 = 4003946083
SultanRS = 3999278268
Suntrap = 4012021193
Superd = 1123216662
Supervolito = 710198397
Supervolito2 = 2623428164
Surano = 384071873
Surfer = 699456151
Surfer2 = 2983726598
Surfer3 = 3259477733
Surge = 2400073108
Swift2 = 1075432268
Swift = 3955379698
Swinger = 500482303
T20 = 1663218586
Taco = 1951180813
Tahoma = 3833117047
Tailgater = 3286105550
Tailgater2 = 3050505892
Taipan = 3160260734
Tampa = 972671128
Tampa2 = 3223586949
Tampa3 = 3084515313
Tanker = 3564062519
Tanker2 = 1956216962
TankerCar = 586013744
Taxi = 3338918751
Technical = 2198148358
Technical2 = 1180875963
Technical3 = 1356124575
Tempesta = 272929391
TenF = 3400983137
TenF2 = 274946574
Terminus = 167522317
Terrorbyte = 2306538597
Tezeract = 1031562256
Thrax = 1044193113
Thrust = 1836027715
Thruster = 1489874736
Tigon = 2936769864
TipTruck = 48339065
TipTruck2 = 3347205726
Titan = 1981688531
Toreador = 1455990255
Torero = 1504306544
Torero2 = 4129572538
Tornado = 464687292
Tornado2 = 1531094468
Tornado3 = 1762279763
Tornado4 = 2261744861
Tornado5 = 2497353967
Tornado6 = 2736567667
Toro = 1070967343
Toro2 = 908897389
Toros = 3126015148
Tourbus = 1941029835
TowTruck = 2971866336
TowTruck2 = 3852654278
TowTruck3 = 3623402354
TowTruck4 = 3392937977
TR2 = 2078290630
TR3 = 1784254509
TR4 = 2091594960
Tractor = 1641462412
Tractor2 = 2218488798
Tractor3 = 1445631933
TrailerLarge = 1502869817
TrailerLogs = 2016027501
Trailers = 3417488910
Trailers2 = 2715434129
Trailers3 = 2236089197
Trailers4 = 3194418602
Trailers5 = 2960513480
TrailerSmall = 712162987
TrailerSmall2 = 2413121211
Trash = 1917016601
Trash2 = 3039269212
TRFlat = 2942498482
TriBike = 1127861609
TriBike2 = 3061159916
TriBike3 = 3894672200
TrophyTruck = 101905590
TrophyTruck2 = 3631668194
Tropic = 290013743
Tropic2 = 1448677353
Tropos = 1887331236
Tug = 2194326579
Tulip = 1456744817
Tulip2 = 268758436
Tula = 1043222410
Turismor = 408192225
Turismo2 = 3312836369
Turismo3 = 4171974011
TVTrailer = 2524324030
TVTrailer2 = 471034616
Tyrant = 3918533058
Tyrus = 2067820283
UtilityTruck = 516990260
UtilityTruck2 = 887537515
UtilityTruck3 = 2132890591
Vacca = 338562499
Vader = 4154065143
Vagner = 1939284556
Vagrant = 740289177
Valkyrie = 2694714877
Valkyrie2 = 1543134283
Vamos = 4245851645
Vectre = 2754593701
Velum = 2621610858
Velum2 = 1077420264
Verlierer2 = 1102544804
Verus = 298565713
Vestra = 1341619767
Vetir = 2014313426
Veto = 3437611258
Veto2 = 2802050217
Vigero = 3469130167
Vigero2 = 2536587772
Vigero3 = 372621319
Vigilante = 3052358707
Vindicator = 2941886209
Virgo = 3796912450
Virgo2 = 3395457658
Virgo3 = 16646064
Virtue = 669204833
Viseris = 3903371924
Visione = 3296789504
Volatol = 447548909
Volatus = 2449479409
Voltic = 2672523198
Voltic2 = 989294410
Voodoo = 2006667053
Voodoo2 = 523724515
Vortex = 3685342204
VStr = 1456336509
Warrener = 1373123368
Warrener2 = 579912970
Washington = 1777363799
Wastelander = 2382949506
Weevil = 1644055914
Weevil2 = 3300595976
Windsor = 1581459400
Windsor2 = 2364918497
Winky = 4084658662
Wolfsbane = 3676349299
XA21 = 917809321
XLS = 1203490606
XLS2 = 3862958888
Yosemite = 1871995513
Yosemite2 = 1693751655
Yosemite3 = 67753863
Youga = 65402552
Youga2 = 1026149675
Youga3 = 1802742206
Youga4 = 1486521356
Zeno = 655665811
Zentorno = 2891838741
Zhaba = 1284356689
Zion = 3172678083
Zion2 = 3101863448
Zion3 = 1862507111
ZombieA = 3285698347
ZombieB = 3724934023
Zorrusso = 3612858749
ZR350 = 2436313176
ZR380 = 540101442
ZR3802 = 3188846534
ZR3803 = 2816263004
ZType = 758895617
Z190 = 838982985
Khanjari = 2859440138
```

## VehicleLandingGearState

enum `GTA.VehicleLandingGearState`

| Name | Value |
| --- | --- |
| `Deployed` | 0 |
| `Retracting` | 1 |
| `Deploying` | 3 |
| `Retracted` | 4 |
| `Broken` | 5 |

## VehicleLockStatus

enum `GTA.VehicleLockStatus`

| Name | Value | Description |
| --- | --- | --- |
| `None` | 0 |  |
| `Unlocked` | 1 |  |
| `CannotEnter` | 2 | The `Vehicle` cannot be entered regardless of whether the door is open or closed, or missing entirely. Warping into the `Vehicle` is the only way to make `Ped`s get in on a seat. |
| `PlayerCannotEnter` | 3 | Players cannot enter the `Vehicle` regardless of whether the door is open or closed, or missing entirely. Warping into the `Vehicle` is the only way to make `Ped`s get in on a seat. |
| `PlayerCannotLeaveCanBeBrokenIntoPersist` | 4 | Doesn't allow players to exit the `Vehicle` with the exit vehicle key or button. The `Vehicle` is locked and must be broken into even if already broken into (the same as `CanBeBrokenIntoPersist`). |
| `CannotEnterIfDriverExists` | 5 | For players, the `Vehicle` cannot open any door if it has a driver. For AI, entering vehicle tasks will not start if the target `Vehicle`'s lock status is set to this value and the `Vehicle` has a driver. |
| `CanBeBrokenInto` | 7 | Can be broken into the car. When a `Ped` breaks the window of the door the `Ped` is entering through, the value will be set to `Unlocked`. If the glass is broken when a `Ped` is about to open the `Vehicle`'s door, the value immediately will be set to `Unlocked`. |
| `CanBeBrokenIntoPersist` | 8 | The `Vehicle` is locked and must be broken into. Even if the door the `Ped` is entering through has its window broken, `Ped`s will always have to try to break it and enter the `Vehicle` consecutively. |
| `DriversSeatOnlyNoJacking` | 9 | `Ped`s can only get in on the driver's seat normally only when the `Vehicle` does not have a driver. Warping into the `Vehicle` is the only way to make `Ped`s get in on any other seat. `Ped`s cannot get any other `Ped`s out of the `Vehicle` to kill them. |
| `IgnoredByPlayer` | 10 | Players cannot attempt to enter the `Vehicle` with the enter vehicle key or button. |
| `Locked` | 2 |  |
| `LockedForPlayer` | 3 |  |
| `StickPlayerInside` | 4 | The `Vehicle` is locked and must be broken into even if already broken into (the same as `CanBeBrokenIntoPersist`). Doesn't allow players to exit the `Vehicle` with the exit vehicle key or button. |
| `CannotBeTriedToEnter` | 10 |  |

## VehicleMissionType

enum `GTA.VehicleMissionType`

| Name | Value |
| --- | --- |
| `None` | 0 |
| `Cruise` | 1 |
| `Ram` | 2 |
| `Block` | 3 |
| `GoTo` | 4 |
| `Stop` | 5 |
| `Attack` | 6 |
| `Follow` | 7 |
| `Flee` | 8 |
| `Circle` | 9 |
| `EscortLeft` | 10 |
| `EscortRight` | 11 |
| `EscortRear` | 12 |
| `EscortFront` | 13 |
| `GoToRacing` | 14 |
| `FollowRecording` | 15 |
| `PoliceBehaviour` | 16 |
| `ParkPerpendicular` | 17 |
| `ParkParallel` | 18 |
| `Land` | 19 |
| `LandAndWait` | 20 |
| `Crash` | 21 |
| `PullOver` | 22 |
| `HeliProtect` | 23 |
| `Escort` | 12 |

## VehicleMod

class `GTA.VehicleMod`

### Properties

- `public int Count { get; }`
- `public int Index { get; set; }`
- `public string LocalizedName { get; }`
- `public string LocalizedTypeName { get; }`
- `public VehicleModType Type { get; }`
- `public bool Variation { get; set; }`
- `public Vehicle Vehicle { get; }`

### Methods

- `public void Remove()`

## VehicleModCollection

class `GTA.VehicleModCollection`

### Properties

- `public VehicleWheelType[] AllowedWheelTypes { get; }`
- `public int ColorCombination { get; set; }`
- `public int ColorCombinationCount { get; }`
- `public Color CustomPrimaryColor { get; set; }`
- `public Color CustomSecondaryColor { get; set; }`
- `public VehicleColor DashboardColor { get; set; }`
- `public bool HasNeonLights { get; }`
- `public bool IsPrimaryColorCustom { get; }`
- `public bool IsSecondaryColorCustom { get; }`
- `public VehicleMod this[VehicleModType modType] { get; }`
- `public VehicleToggleMod this[VehicleToggleModType modType] { get; }`
- `public string LicensePlate { get; set; }`
- `public LicensePlateStyle LicensePlateStyle { get; set; }`
- `public LicensePlateType LicensePlateType { get; }`
- `public int Livery { get; set; }`
- `public int LiveryCount { get; }`
- `public string LocalizedLiveryName { get; }`
- `public string LocalizedWheelTypeName { get; }`
- `public Color NeonLightsColor { get; set; }`
- `public VehicleColor PearlescentColor { get; set; }`
- `public VehicleColor PrimaryColor { get; set; }`
- `public VehicleColor RimColor { get; set; }`
- `public VehicleColor SecondaryColor { get; set; }`
- `public Color TireSmokeColor { get; set; }`
- `public VehicleColor TrimColor { get; set; }`
- `public VehicleWheelType WheelType { get; set; }`
- `public VehicleWindowTint WindowTint { get; set; }`

### Methods

- `public void ClearCustomPrimaryColor()`
- `public void ClearCustomSecondaryColor()`
- `public bool Contains(VehicleModType type)`
- `public string GetLocalizedWheelTypeName(VehicleWheelType wheelType)`
- `public bool HasNeonLight(VehicleNeonLight neonLight)`
- `public void InstallModKit()`
- `public bool IsNeonLightsOn(VehicleNeonLight light)`
- `public bool RequestAdditionTextFile(int timeout = 1000)`
- `public void SetNeonLightsOn(VehicleNeonLight light, bool on)`
- `public VehicleMod[] ToArray()`

## VehicleModType

enum `GTA.VehicleModType`

| Name | Value |
| --- | --- |
| `None` | -1 |
| `Spoilers` | 0 |
| `FrontBumper` | 1 |
| `RearBumper` | 2 |
| `SideSkirt` | 3 |
| `Exhaust` | 4 |
| `Frame` | 5 |
| `Grille` | 6 |
| `Hood` | 7 |
| `Fender` | 8 |
| `RightFender` | 9 |
| `Roof` | 10 |
| `Engine` | 11 |
| `Brakes` | 12 |
| `Transmission` | 13 |
| `Horns` | 14 |
| `Suspension` | 15 |
| `Armor` | 16 |
| `FrontWheel` | 23 |
| `RearWheel` | 24 |
| `PlateHolder` | 25 |
| `VanityPlates` | 26 |
| `TrimDesign` | 27 |
| `Ornaments` | 28 |
| `Dashboard` | 29 |
| `DialDesign` | 30 |
| `DoorSpeakers` | 31 |
| `Seats` | 32 |
| `SteeringWheels` | 33 |
| `ColumnShifterLevers` | 34 |
| `Plaques` | 35 |
| `Speakers` | 36 |
| `Trunk` | 37 |
| `Hydraulics` | 38 |
| `EngineBlock` | 39 |
| `AirFilter` | 40 |
| `Struts` | 41 |
| `ArchCover` | 42 |
| `Aerials` | 43 |
| `Trim` | 44 |
| `Tank` | 45 |
| `Windows` | 46 |
| `Livery` | 48 |

## VehicleNeonLight

enum `GTA.VehicleNeonLight`

| Name | Value |
| --- | --- |
| `Left` | 0 |
| `Right` | 1 |
| `Front` | 2 |
| `Back` | 3 |

## VehiclePathNodePropertyFlags

enum `GTA.VehiclePathNodePropertyFlags`

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

## VehicleRoofState

enum `GTA.VehicleRoofState`

| Name | Value |
| --- | --- |
| `Closed` | 0 |
| `Opening` | 1 |
| `Opened` | 2 |
| `Closing` | 3 |

## VehicleSeat

enum `GTA.VehicleSeat`

| Name | Value |
| --- | --- |
| `None` | -3 |
| `Any` | -2 |
| `Driver` | -1 |
| `Passenger` | 0 |
| `LeftFront` | -1 |
| `RightFront` | 0 |
| `LeftRear` | 1 |
| `RightRear` | 2 |
| `ExtraSeat1` | 3 |
| `ExtraSeat2` | 4 |
| `ExtraSeat3` | 5 |
| `ExtraSeat4` | 6 |
| `ExtraSeat5` | 7 |
| `ExtraSeat6` | 8 |
| `ExtraSeat7` | 9 |
| `ExtraSeat8` | 10 |
| `ExtraSeat9` | 11 |
| `ExtraSeat10` | 12 |
| `ExtraSeat11` | 13 |
| `ExtraSeat12` | 14 |

## VehicleStuckType

enum `GTA.VehicleStuckType`

| Name | Value |
| --- | --- |
| `OnRoof` | 0 |
| `OnSide` | 1 |
| `HungUp` | 2 |
| `Jammed` | 3 |
| `ResetAll` | 4 |

## VehicleToggleMod

class `GTA.VehicleToggleMod`

### Properties

- `public bool IsInstalled { get; set; }`
- `public string LocalizedTypeName { get; }`
- `public VehicleToggleModType Type { get; }`
- `public Vehicle Vehicle { get; }`

### Methods

- `public void Remove()`

## VehicleToggleModType

enum `GTA.VehicleToggleModType`

| Name | Value |
| --- | --- |
| `Nitrous` | 17 |
| `Turbo` | 18 |
| `SubWoofer` | 19 |
| `TireSmoke` | 20 |
| `Hydraulics` | 21 |
| `XenonHeadlights` | 22 |

## VehicleType

enum `GTA.VehicleType`

| Name | Value | Description |
| --- | --- | --- |
| `None` | -1 | The default/invalid type. |
| `Automobile` | 0 | The non-special automobile type, such as general cars, taxis, trucks, and tanks. |
| `Plane` | 1 | The airplane type. |
| `Trailer` | 2 | The trailer type. |
| `QuadBike` | 3 | The non-special quad bike type. Also includes tricycles, such as `Chimera`, `RRocket`, and `Stryder`. |
| `SubmarineCar` | 5 | The submarine car type for the submarine cars, which can travel underwater like submarines. |
| `AmphibiousAutomobile` | 6 | The amphibious automobile type. |
| `AmphibiousQuadBike` | 7 | The amphibious quad bike type. |
| `Helicopter` | 8 | The helicopter type. `Thruster` is also classified as this type. |
| `Blimp` | 9 | The blimp type. |
| `Autogyro` | 10 | The autogyro type, which is not used in the stock game. |
| `Motorcycle` | 11 | The motorcycle type. |
| `Bicycle` | 12 | The bicycle type. |
| `Boat` | 13 | The boat type. |
| `Train` | 14 | The train type. |
| `Submarine` | 15 | The submarine type. |

## VehicleWeaponHandlingData

class `GTA.VehicleWeaponHandlingData` : `BaseSubHandlingData`

### Properties

- `public float[] TurretPitchMax { get; set; }`
- `public float[] TurretPitchMin { get; set; }`
- `public float[] TurretSpeed { get; set; }`
- `public VehicleWeaponHash[] WeaponHash { get; set; }`
- `public VehicleSeat[] WeaponSeats { get; set; }`
- `public VehicleModType[] WeaponVehicleModType { get; set; }`

### Methods

- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public static bool op_Equality(VehicleWeaponHandlingData left, VehicleWeaponHandlingData right)`
- `public static bool op_Inequality(VehicleWeaponHandlingData left, VehicleWeaponHandlingData right)`

## VehicleWeaponHash

enum `GTA.VehicleWeaponHash`

| Name | Value |
| --- | --- |
| `Invalid` | 4294967295 |
| `Tank` | 1945616459 |
| `SpaceRocket` | 4171469727 |
| `PlaneRocket` | 3473446624 |
| `PlayerLaser` | 4026335563 |
| `PlayerBullet` | 1259576109 |
| `PlayerBuzzard` | 1186503822 |
| `PlayerHunter` | 2669318622 |
| `PlayerLazer` | 3800181289 |
| `EnemyLaser` | 1566990507 |
| `SearchLight` | 3450622333 |
| `Radar` | 3530961278 |
| `WaterCannon` | 1741783703 |
| `Rotors` | 2971687502 |
| `Dune` | 987028236 |
| `ValkyrieNoseTurret` | 1097917585 |
| `ValkyrieTurret` | 2756787765 |
| `Technical` | 2144528907 |
| `Insurgent` | 1155224728 |
| `Stromberg` | 1176362368 |

## VehicleWheel

class `GTA.VehicleWheel`

### Properties

- `public VehicleWheelBoneId BoneId { get; }`
  - Gets the bone id this `VehicleWheel`.
- `public float Health { get; set; }`
  - Gets or sets the wheel health.
- `public Vector3 HitNormal { get; }`
- `public int Index { get; }`
  - **Obsolete.** Use VehicleWheel.BoneId or VehicleWheel.ScriptIndex instead.
  - Gets the index for native functions. Obsoleted in v3 API because there is no legiminate ways to get value from or modify any of the 4 wheels `wheel_lm2`, `wheel_rm2`, `wheel_lm3`, or `wheel_lm3` in native functions.
- `public bool IsBurst { get; }`
- `public bool IsBursted { get; }`
  - **Obsolete.** Use VehicleWheel.IsBurst instead.
  - Sets a value indicating whether this `VehicleWheel` is bursted.
- `public bool IsDrivingWheel { get; set; }`
  - Gets or sets a value indicating whether this `VehicleWheel` is a driving wheel.
- `public bool IsPunctured { get; }`
  - Sets a value indicating whether this `VehicleWheel` is punctured.
- `public bool IsSteeringWheel { get; set; }`
  - Gets or sets a value indicating whether this `VehicleWheel` is a steering wheel.
- `public bool IsTireOnFire { get; set; }`
  - Gets or sets a value indicating whether this `VehicleWheel`'s tire is on fire.
- `public bool IsTouchingSurface { get; }`
  - Gets a value indicating whether this `VehicleWheel` is touching any surface.
- `public Vector3 LastContactPosition { get; }`
  - Gets the last contact position.
- `public float MaxGripDiffFromWearRate { get; set; }`
- `public IntPtr MemoryAddress { get; }`
  - Gets the memory address where this `VehicleWheel` is stored in memory.
- `public ScriptVehicleWheelIndex ScriptIndex { get; }`
- `public float StaticForce { get; set; }`
- `public float SteeringLimitMultiplier { get; set; }`
  - Gets or sets the limit multiplier that affects how much this `VehicleWheel` can turn.
- `public float Temperature { get; set; }`
  - Gets or sets the temperature of `VehicleWheel`. This value rises when `Vehicle` is drifting, braking, or in burnout. If this value is kept at `59f` when `Vehicle` is on burnout for a short time, the tire will burst.
- `public float TireHealth { get; set; }`
  - Gets or sets the tire health. If `WearMultiplier` is set to exactly `0f`, the value will default to `350f` if the value is positive and less than `1000f`.
- `public Vehicle Vehicle { get; }`
  - Gets the `Vehicle`this `VehicleWheel` belongs to.
- `public float WearMultiplier { get; set; }`
  - Gets or sets the value indicating how fast the tires will wear out. The higher this value is, the greater downforce will be created. Only supported in v1.0.1868.0 and later versions. Will throw `GameVersionNotSupportedException` if the setter is called in earlier versions (the getter always returns `false` in earlier versions).
- `public float WearRateScale { get; set; }`

### Methods

- `public void Burst()`
  - Bursts this `VehicleWheel`'s tire completely.
- `public void Fix()`
  - Fixes this `VehicleWheel`'s tire.
- `public void Fix(bool leaveOtherBurstedTiresNotShowing)`
  - Fixes this `VehicleWheel`'s tire.
  - `leaveOtherBurstedTiresNotShowing`: If set to `false`, bursted tires will appear again just like `SET_VEHICLE_TYRE_FIXED` does.
- `public float GetHydraulicSuspensionRaiseFactor()`
- `public void Puncture(float damage = 1000)`
  - Punctures this `VehicleWheel`'s tire.
  - `damage`: How much damage this `VehicleWheel` will take.
- `public void SetHydraulicSuspensionRaiseFactor(float raiseFactor)`

## VehicleWheelBoneId

enum `GTA.VehicleWheelBoneId`

| Name | Value |
| --- | --- |
| `Invalid` | -1 |
| `WheelLeftFront` | 11 |
| `WheelRightFront` | 12 |
| `WheelLeftRear` | 13 |
| `WheelRightRear` | 14 |
| `WheelLeftMiddle1` | 15 |
| `WheelRightMiddle1` | 16 |
| `WheelLeftMiddle2` | 17 |
| `WheelRightMiddle2` | 18 |
| `WheelLeftMiddle3` | 19 |
| `WheelRightMiddle3` | 20 |

## VehicleWheelCollection

class `GTA.VehicleWheelCollection` : `IEnumerable<VehicleWheel>`, `IEnumerable`

### Properties

- `public int Count { get; }`
  - Gets the number of `VehicleWheel` this `VehicleWheelCollection` has. `0` will be returned if the owner vehicle does not exist.
- `public VehicleWheel this[ScriptVehicleWheelIndex index] { get; }`
- `public VehicleWheel this[VehicleWheelBoneId boneId] { get; }`
- `public VehicleWheel this[int index] { get; }`
  - **Obsolete.** Use VehicleWheelCollection.this[ScriptVehicleWheelIndex] instead.
- `public Vehicle Vehicle { get; }`
  - Gets the `Vehicle`this `VehicleWheelCollection` belongs to.

### Methods

- `public VehicleWheel[] GetAllWheels()`
  - Gets an `array` of all `VehicleWheel`s this `VehicleWheelCollection` has.
- `public IEnumerator<VehicleWheel> GetEnumerator()`
- `public VehicleWheel GetWheelByIndexOfCollection(int index)`
  - Gets the `VehicleWheel` by index.
  - `index`: The index of the wheel collection. The order is the same as how the wheel array of the owner `Vehicle` is aligned.

## VehicleWheelType

enum `GTA.VehicleWheelType`

| Name | Value |
| --- | --- |
| `Stock` | -1 |
| `Sport` | 0 |
| `Muscle` | 1 |
| `Lowrider` | 2 |
| `SUV` | 3 |
| `Offroad` | 4 |
| `Tuner` | 5 |
| `BikeWheels` | 6 |
| `HighEnd` | 7 |
| `BennysOriginals` | 8 |
| `BennysBespoke` | 9 |
| `OpenWheel` | 10 |
| `Street` | 11 |
| `Track` | 12 |

## VehicleWindow

class `GTA.VehicleWindow`

### Properties

- `public VehicleWindowIndex Index { get; }`
- `public bool IsIntact { get; }`
- `public Vehicle Vehicle { get; }`

### Methods

- `public void Remove()`
- `public void Repair()`
- `public void RollDown()`
- `public void RollUp()`
- `public void Smash()`

## VehicleWindowCollection

class `GTA.VehicleWindowCollection`

### Properties

- `public bool AllWindowsIntact { get; }`
- `public VehicleWindow this[VehicleWindowIndex index] { get; }`

### Methods

- `public void RollDownAllWindows()`

## VehicleWindowIndex

enum `GTA.VehicleWindowIndex`

| Name | Value |
| --- | --- |
| `FrontLeftWindow` | 0 |
| `FrontRightWindow` | 1 |
| `BackLeftWindow` | 2 |
| `BackRightWindow` | 3 |
| `MiddleLeftWindow` | 4 |
| `MiddleRightWindow` | 5 |
| `Windshield` | 6 |
| `BackWindshield` | 7 |
| `ExtraWindow1` | 4 |
| `ExtraWindow2` | 5 |
| `ExtraWindow3` | 6 |
| `ExtraWindow4` | 7 |

## VehicleWindowTint

enum `GTA.VehicleWindowTint`

| Name | Value |
| --- | --- |
| `Invalid` | -1 |
| `None` | 0 |
| `PureBlack` | 1 |
| `DarkSmoke` | 2 |
| `LightSmoke` | 3 |
| `Stock` | 4 |
| `Limo` | 5 |
| `Green` | 6 |

## Wanted

class `GTA.Wanted`

### Properties

- `public int CurrentCrimeValue { get; set; }`
- `public bool DispatchesCopsForPlayer { get; set; }`
- `public bool EverybodyBackOff { get; }`
- `public bool HasGrayedOutStars { get; }`
- `public Vector3 LastPositionSpottedByPolice { get; }`
- `public int NewCrimeValue { get; set; }`
- `public bool PoliceBackOff { get; }`
- `public int TimeHiddenEvasionStarted { get; set; }`
- `public int TimeLastSpotted { get; set; }`
- `public int TimeSearchLastRefocused { get; set; }`
- `public int TimeWhenNewCrimeValueTakesEffect { get; set; }`
- `public int WantedLevel { get; }`

### Methods

- `public void ApplyWantedLevelChangeNow(bool delayLawResponse)`
- `public void ForceStartHiddenEvasion()`
- `public void ReportCrime(CrimeType crimeToReport, int crimeValue = 0)`
- `public void ReportPoliceSpottingPlayer()`
- `public void SetEveryoneIgnorePlayer(bool value)`
- `public void SetPoliceIgnorePlayer(bool value)`
- `public void SetRadiusCenter(Vector3 pos)`
- `public void SetWantedLevel(int newLevel, bool delayLawResponse)`
- `public void SetWantedLevelNoDrop(int newLevel, bool delayLawResponse)`
- `public void SetWantedLevelNoRefocusSearchArea(int wantedLevel)`

## Water

static class `GTA.Water`

### Methods

- `public static bool GetWaterLevel(Vector3 position, out float height)`
- `public static bool GetWaterLevelNoWaves(Vector3 position, out float height)`
- `public static bool TestLineAgainstWater(Vector3 startPos, Vector3 endPos, out Vector3 intersectionPos)`

## Weapon

class `GTA.Weapon`

### Properties

- `public int Ammo { get; set; }`
- `public int AmmoInClip { get; set; }`
- `public bool CanUseOnParachute { get; }`
- `public WeaponComponentCollection Components { get; }`
- `public DamageType DamageType { get; }`
- `public int DefaultClipSize { get; }`
- `public string DisplayName { get; }`
- `public WeaponGroup Group { get; }`
- `public WeaponHash Hash { get; }`
- `public WeaponHudStats HudStats { get; }`
- `public bool InfiniteAmmo { set; }`
- `public bool InfiniteAmmoClip { set; }`
- `public bool IsPresent { get; }`
- `public string LocalizedName { get; }`
- `public int MaxAmmo { get; }`
- `public int MaxAmmoInClip { get; }`
- `public Model Model { get; }`
- `public int SlotHash { get; }`
- `public WeaponTint Tint { get; set; }`
- `public int TintCount { get; }`

### Methods

- `public static Model[] GetAllModels()`
- `public static WeaponHash[] GetAllWeaponHashesForHumanPeds()`
- `public static string GetDisplayNameFromHash(WeaponHash hash)`
- `public static string GetHumanNameFromHash(WeaponHash hash)`
- `public static WeaponHash op_Implicit(Weapon weapon)`

## WeaponAsset

struct `GTA.WeaponAsset` : `IEquatable<WeaponAsset>`, `INativeValue`, `IScriptStreamingResource`

### Constructors

- `public WeaponAsset(WeaponHash hash)`
- `public WeaponAsset(int hash)`
- `public WeaponAsset(uint hash)`

### Properties

- `public string DisplayName { get; }`
- `public int Hash { get; }`
  - Gets the hash for this `WeaponAsset`.
- `public string HumanName { get; }`
- `public bool IsLoaded { get; }`
  - Gets a value indicating whether this `WeaponAsset` is loaded so it can be spawned.
- `public bool IsValid { get; }`
  - Gets a value indicating whether this `WeaponAsset` is valid as a weapon or a ammo hash.
- `public bool IsValidAsWeaponHash { get; }`
  - Gets a value indicating whether this `WeaponAsset` is valid as a weapon hash.
- `public ulong NativeValue { get; set; }`
  - Gets the native representation of this `WeaponAsset`.
- `public int SlotHash { get; }`

### Methods

- `public bool Equals(WeaponAsset weaponAsset)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public void MarkAsNoLongerNeeded()`
  - Tells the game we have finished using this `WeaponAsset` and it can be freed from memory.
- `public void Request()`
  - Attempts to load this `WeaponAsset` into memory.
- `public void Request(WeaponScriptResourceFlags weaponResourceFlags, ExtraWeaponComponentScriptResourceFlags extraWeaponComponentResourceFlags = 0)`
- `public bool Request(int timeout)`
  - Attempts to load this `WeaponAsset` into memory for a given period of time.
  - `timeout`: The time (in milliseconds) before giving up trying to load this `WeaponAsset`.
  - Returns: `true` if this `WeaponAsset` is loaded; otherwise, `false`.
- `public virtual string ToString()`
- `public static bool op_Equality(WeaponAsset left, WeaponAsset right)`
- `public static InputArgument op_Implicit(WeaponAsset value)`
- `public static WeaponAsset op_Implicit(WeaponHash hash)`
- `public static WeaponAsset op_Implicit(int hash)`
- `public static WeaponAsset op_Implicit(uint hash)`
- `public static bool op_Inequality(WeaponAsset left, WeaponAsset right)`

## WeaponAttachmentPoint

enum `GTA.WeaponAttachmentPoint`

| Name | Value | Description |
| --- | --- | --- |
| `Invalid` | 4294967295 |  |
| `Barrel` | 2982890265 |  |
| `Clip` | 3723347892 |  |
| `Clip2` | 291640902 |  |
| `Flash` | 953267555 | Used for `Flashlight`. |
| `FlashLaser` | 679107254 |  |
| `FlashLaser2` | 2722126698 |  |
| `Supp` | 1863181664 |  |
| `Supp2` | 945598191 |  |
| `GunRoot` | 962500902 |  |
| `GunGripR` | 4263393586 | Used for `GunrunMk2Upgrade`. |
| `Scope` | 196630833 |  |
| `Scope2` | 1684637069 |  |
| `Grip` | 2972950469 |  |
| `Grip2` | 3748215485 |  |
| `TorchBulb` | 421673795 |  |
| `Rail` | 2451679629 |  |
| `Rail2` | 497110245 |  |

## WeaponCheckFlags

enum `GTA.WeaponCheckFlags`

| Name | Value |
| --- | --- |
| `IncludeMelee` | 1 |
| `IncludeProjectile` | 2 |
| `IncludeGun` | 4 |
| `All` | 7 |

## WeaponCollection

class `GTA.WeaponCollection` : `IEnumerable<Weapon>`, `IEnumerable`

### Properties

- `public Weapon BestWeapon { get; }`
- `public int Count { get; }`
- `public Weapon Current { get; }`
- `public Prop CurrentWeaponObject { get; }`
- `public Weapon this[WeaponHash hash] { get; }`
- `public Weapon this[string weaponName] { get; }`

### Methods

- `public void Drop()`
- `public WeaponHash[] GetAllWeaponHashes()`
- `public WeaponCollection.Enumerator GetEnumerator()`
- `public Weapon Give(WeaponHash weaponHash, int ammoCount, bool equipNow, bool isAmmoLoaded)`
  - Gives the speficied weapon if the owner `Ped` does not have one, or selects the weapon if they have one and `equipNow` is set to `true`.
  - `weaponHash`: The weapon hash.
  - `ammoCount`: The ammo count to be added to the weapon inventory of the owner `Ped`.
  - `equipNow`: If set to `true`, the owner `Ped` will switch their weapon to the weapon of `weaponHash` as soon as they can (not instantly).
  - `isAmmoLoaded`: Does not work since the ammo in clip is always full if not selected unless the game code related to auto-reload is modified. This was supposed to determine if the ammo will be loaded after the weapon is given to the owner `Ped`.
- `public Weapon Give(string name, int ammoCount, bool equipNow, bool isAmmoLoaded)`
  - Gives the speficied weapon if the owner `Ped` does not have one, or selects the weapon if they have one and `equipNow` is set to `true`.
  - `weaponHash`: The weapon hash.
  - `ammoCount`: The ammo count to be added to the weapon inventory of the owner `Ped`.
  - `equipNow`: If set to `true`, the owner `Ped` will switch their weapon to the weapon of `weaponHash` as soon as they can (not instantly).
  - `isAmmoLoaded`: Does not work since the ammo in clip is always full if not selected unless the game code related to auto-reload is modified. This was supposed to determine if the ammo will be loaded after the weapon is given to the owner `Ped`.
- `public bool HasWeapon(WeaponHash weaponHash)`
- `public bool HasWeapon(string weaponName)`
- `public bool IsWeaponValid(WeaponHash hash)`
- `public bool IsWeaponValid(string weaponName)`
- `public void Remove(Weapon weapon)`
- `public void Remove(WeaponHash weaponHash)`
- `public void Remove(string weaponName)`
- `public void RemoveAll()`
- `public bool Select(Weapon weapon)`
- `public bool Select(WeaponHash weaponHash, bool equipNow)`
- `public bool Select(WeaponHash weaponHash)`
- `public bool Select(string weaponName, bool forceInHand)`
- `public bool TryGetWeaponBySlotHash(int slotHash, out Weapon weapon)`
- `public bool TryGetWeaponHashBySlotHash(int slotHash, out WeaponHash weaponHash)`

## WeaponCollection.Enumerator

struct `GTA.WeaponCollection.Enumerator` : `IEnumerator<Weapon>`, `IDisposable`, `IEnumerator`

### Properties

- `public Weapon Current { get; }`

### Methods

- `public void Dispose()`
- `public bool MoveNext()`

## WeaponComponent

class `GTA.WeaponComponent`

### Properties

- `public bool Active { get; set; }`
- `public WeaponAttachmentPoint AttachmentPoint { get; }`
- `public WeaponComponentHash ComponentHash { get; }`
- `public string DisplayName { get; }`
- `public string LocalizedName { get; }`

### Methods

- `public static WeaponComponentHash[] GetAllHashes()`
- `public static WeaponComponentHash op_Implicit(WeaponComponent weaponComponent)`

## WeaponComponentCollection

class `GTA.WeaponComponentCollection`

### Properties

- `public int BarrelVariationsCount { get; }`
  - Gets the number of compatible barrel components.
- `public int ClipVariationsCount { get; }`
  - Gets the number of compatible clip components.
- `public int Count { get; }`
  - Gets the number of compatible components.
- `public int GunRootVariationsCount { get; }`
  - Gets the number of compatible components for `GunRoot`.
- `public WeaponComponent this[WeaponComponentHash componentHash] { get; }`
- `public WeaponComponent this[int index] { get; }`
- `public int ScopeVariationsCount { get; }`
  - Gets the number of compatible scope components.
- `public int SuppressorAndMuzzleBrakeVariationsCount { get; }`
  - Gets the number of compatible suppressor and muzzle brake components.

### Methods

- `public WeaponComponent GetBarrelComponent(int index)`
  - Gets the barrel component at the index.
  - `index`: The index of the barrel component subset of all the weapon component array.
  - Returns: A `WeaponComponent` instance if the `WeaponComponent` at the `index` of the barrel component subset is found; otherwise, the `WeaponComponent` instance representing the invalid component.
- `public WeaponComponent GetClipComponent(int index)`
  - Gets the clip component at the index.
  - `index`: The index of the clip component subset of all the weapon component array.
  - Returns: A `WeaponComponent` instance if the `WeaponComponent` at the `index` of the clip component subset is found; otherwise, the `WeaponComponent` instance representing the invalid component.
- `public IEnumerator<WeaponComponent> GetEnumerator()`
- `public WeaponComponent GetFlashLightComponent()`
  - Gets the flashlight component.
  - Returns: The `WeaponComponent` instance if the flashlight component is found; otherwise, the `WeaponComponent` instance representing the invalid component.
- `public WeaponComponent GetGunRootComponent(int index)`
  - Gets the component for `GunRoot` at the index.
  - `index`: The index of the components for `GunRoot` subset of all the weapon component array.
  - Returns: A `WeaponComponent` instance if the `WeaponComponent` at the `index` of the components for `GunRoot` is found; otherwise, the `WeaponComponent` instance representing the invalid component.
- `public WeaponComponent GetLuxuryFinishComponent()`
  - **Obsolete.** WeaponComponentCollection.GetLuxuryFinishComponent is wrongly named and cannot necessarily get all of the components for gun_root (e.g. camo components),use WeaponComponentCollection.GetGunRootComponent instead.
  - Gets the first component of all the components for `GunRoot`. Despite the method name, return value is not guaranteed to a `WeaponComponent` instance that represents the luxury finish component.
  - Returns: The `WeaponComponent` instance if the first component of all the components for `GunRoot` is found; otherwise, the `WeaponComponent` instance representing the invalid component.
- `public WeaponComponent GetScopeComponent(int index)`
  - Gets the scope component at the index.
  - `index`: The index of the scope component subset of all the weapon component array.
  - Returns: A `WeaponComponent` instance if the `WeaponComponent` at the `index` of the scope component subset is found; otherwise, the `WeaponComponent` instance representing the invalid component.
- `public WeaponComponent GetSuppressorComponent()`
  - Gets the suppressor component.
  - Returns: The `WeaponComponent` instance if the suppressor component is found; otherwise, the `WeaponComponent` instance representing the invalid component.
- `public WeaponComponent GetSuppressorOrMuzzleBrakeComponent(int index)`
  - Gets the suppressor or muzzle brake component at the index.
  - `index`: The index of the subset of the suppressor and muzzle brake components of all the weapon component array.
  - Returns: A `WeaponComponent` instance if the `WeaponComponent` at the `index` of the subset of the suppressor and muzzle brake components is found; otherwise, the `WeaponComponent` instance representing the invalid component.

## WeaponComponentHash

enum `GTA.WeaponComponentHash`

432 values:

```text
Invalid = 4294967295
AdvancedRifleClip01 = 4203716879
AdvancedRifleClip02 = 2395064697
AdvancedRifleVarmodLuxe = 930927479
APPistolClip01 = 834974250
APPistolClip02 = 614078421
APPistolVarmodLuxe = 2608252716
AssaultRifleClip01 = 3193891350
AssaultRifleClip02 = 2971750299
AssaultRifleClip03 = 3689981245
AssaultRifleVarmodLuxe = 1319990579
AssaultRifleMk2Camo = 2434475183
AssaultRifleMk2Camo02 = 937772107
AssaultRifleMk2Camo03 = 1401650071
AssaultRifleMk2Camo04 = 628662130
AssaultRifleMk2Camo05 = 3309920045
AssaultRifleMk2Camo06 = 3482022833
AssaultRifleMk2Camo07 = 2847614993
AssaultRifleMk2Camo08 = 4234628436
AssaultRifleMk2Camo09 = 2088750491
AssaultRifleMk2Camo10 = 2781053842
AssaultRifleMk2CamoIndependence01 = 3115408816
AssaultRifleMk2Clip01 = 2249208895
AssaultRifleMk2Clip02 = 3509242479
AssaultRifleMk2ClipArmorPiercing = 2816286296
AssaultRifleMk2ClipFMJ = 1675665560
AssaultRifleMk2ClipIncendiary = 4218476627
AssaultRifleMk2ClipTracer = 4012669121
AssaultShotgunClip01 = 2498239431
AssaultShotgunClip02 = 2260565874
AssaultSMGClip01 = 2366834608
AssaultSMGClip02 = 3141985303
AssaultSMGVarmodLowrider = 663517359
AtArAfGrip = 202788691
AtArAfGrip02 = 2640679034
AtArBarrel01 = 1134861606
AtArBarrel02 = 1447477866
AtArFlsh = 2076495324
AtArFlshReh = 2645680163
AtArSupp = 2205435306
AtArSupp02 = 2805810788
AtBpBarrel01 = 1704640795
AtBpBarrel02 = 1005743559
AtCrBarrel01 = 2201368575
AtCrBarrel02 = 2335983627
AtMGBarrel01 = 3276730932
AtMGBarrel02 = 3051509595
AtMrFlBarrel01 = 941317513
AtMrFlBarrel02 = 1748450780
AtMuzzle01 = 3113485012
AtMuzzle02 = 3362234491
AtMuzzle03 = 3725708239
AtMuzzle04 = 3968886988
AtMuzzle05 = 48731514
AtMuzzle06 = 880736428
AtMuzzle07 = 1303784126
AtMuzzle08 = 1602080333
AtMuzzle09 = 1764221345
AtPiComp = 568543123
AtPiComp02 = 2860680127
AtPiComp03 = 654802123
AtPiFlsh = 899381934
AtPiFlsh02 = 1140676955
AtPiFlsh03 = 1246324211
AtPiRail = 2396306288
AtPiRail02 = 1205768792
AtPiSupp = 3271853210
AtPiSupp02 = 1709866683
AtRailCover01 = 1967214384
AtSbBarrel01 = 3641720545
AtSbBarrel02 = 2774849419
AtScBarrel01 = 3879097257
AtScBarrel02 = 4185880635
AtScopeLarge = 3527687644
AtScopeLargeFixedZoom = 471997210
AtScopeLargeFixedZoomMk2 = 1528590652
AtScopeLargeMk2 = 2193687427
AtScopeMacro = 2637152041
AtScopeMacroMk2 = 77277509
AtScopeMacro02 = 1019656791
AtScopeMacro02Mk2 = 3842157419
AtScopeMacro02SMGMk2 = 3842157419
AtScopeMax = 3159677559
AtScopeMedium = 2698550338
AtScopeMediumMk2 = 3328927042
AtScopeNV = 3061846192
AtScopeSmall = 2855028148
AtScopeSmall02 = 1006677997
AtScopeSmallMk2 = 1060929921
AtScopeSmallSMGMk2 = 1038927834
AtScopeThermal = 776198721
AtSights = 1108334355
AtSightsSMG = 2681951826
AtSrBarrel01 = 2425761975
AtSrBarrel02 = 277524638
AtSrSupp = 3859329886
AtSrSupp03 = 2890063729
BattleRifleClip01 = 4002533646
BattleRifleClip02 = 494808810
BullpupRifleClip01 = 3315675008
BullpupRifleClip02 = 3009973007
BullpupRifleVarmodLow = 2824322168
BullpupRifleMk2Camo = 2923451831
BullpupRifleMk2Camo02 = 3104173419
BullpupRifleMk2Camo03 = 2797881576
BullpupRifleMk2Camo04 = 2491819116
BullpupRifleMk2Camo05 = 2318995410
BullpupRifleMk2Camo06 = 36929477
BullpupRifleMk2Camo07 = 4026522462
BullpupRifleMk2Camo08 = 3720197850
BullpupRifleMk2Camo09 = 3412267557
BullpupRifleMk2Camo10 = 2826785822
BullpupRifleMk2CamoIndependence01 = 3320426066
BullpupRifleMk2Clip01 = 25766362
BullpupRifleMk2Clip02 = 4021290536
BullpupRifleMk2ClipArmorPiercing = 4205311469
BullpupRifleMk2ClipFMJ = 1130501904
BullpupRifleMk2ClipIncendiary = 2845636954
BullpupRifleMk2ClipTracer = 2183159977
BullpupShotgunClip01 = 3377353998
CarbineRifleClip01 = 2680042476
CarbineRifleClip02 = 2433783441
CarbineRifleClip03 = 3127044405
CarbineRifleVarmodLuxe = 3634075224
CarbineRifleVarmodMich = 1605520746
CarbineRifleMk2Camo = 1272803094
CarbineRifleMk2Camo02 = 1080719624
CarbineRifleMk2Camo03 = 792221348
CarbineRifleMk2Camo04 = 3842785869
CarbineRifleMk2Camo05 = 3548192559
CarbineRifleMk2Camo06 = 2250671235
CarbineRifleMk2Camo07 = 4095795318
CarbineRifleMk2Camo08 = 2866892280
CarbineRifleMk2Camo09 = 2559813981
CarbineRifleMk2Camo10 = 1796459838
CarbineRifleMk2CamoIndependence01 = 3663056191
CarbineRifleMk2Clip01 = 1283078430
CarbineRifleMk2Clip02 = 1574296533
CarbineRifleMk2ClipArmorPiercing = 626875735
CarbineRifleMk2ClipFMJ = 1141059345
CarbineRifleMk2ClipIncendiary = 1025884839
CarbineRifleMk2ClipTracer = 391640422
CeramicPistolClip01 = 1423184737
CeramicPistolClip02 = 2172153001
CeramicPistolSupp = 2466764538
CombatMGClip01 = 3791631178
CombatMGClip02 = 3603274966
CombatMGVarmodLowrider = 2466172125
CombatMGMk2Camo = 1249283253
CombatMGMk2Camo02 = 3437259709
CombatMGMk2Camo03 = 3197423398
CombatMGMk2Camo04 = 1980349969
CombatMGMk2Camo05 = 1219453777
CombatMGMk2Camo06 = 2441508106
CombatMGMk2Camo07 = 2220186280
CombatMGMk2Camo08 = 457967755
CombatMGMk2Camo09 = 235171324
CombatMGMk2Camo10 = 42685294
CombatMGMk2CamoIndependence01 = 3607349581
CombatMGMk2Clip01 = 1227564412
CombatMGMk2Clip02 = 400507625
CombatMGMk2ClipArmorPiercing = 696788003
CombatMGMk2ClipFMJ = 1475288264
CombatMGMk2ClipIncendiary = 3274096058
CombatMGMk2ClipTracer = 4133787461
CombatPDWClip01 = 1125642654
CombatPDWClip02 = 860508675
CombatPDWClip03 = 1857603803
CombatPistolClip01 = 119648377
CombatPistolClip02 = 3598405421
CombatPistolVarmodLowrider = 3328527730
CombatShotgunClip01 = 3323278933
CompactEMPLauncherClip01 = 3532609777
CompactGrenadeLauncherClip01 = 1235472140
CompactRifleClip01 = 1363085923
CompactRifleClip02 = 1509923832
CompactRifleClip03 = 3322377230
DBShotgunClip01 = 703231006
DoubleActionClip01 = 1328622785
FireworkClip01 = 3840197261
FlareGunClip01 = 2481569177
FlashlightLight = 3719772431
GrenadeLauncherClip01 = 296639639
GunrunMk2Upgrade = 1623028892
GusenbergClip01 = 484812453
GusenbergClip02 = 3939025520
HeavyPistolClip01 = 222992026
HeavyPistolClip02 = 1694090795
HeavyPistolVarmodLuxe = 2053798779
HeavyRifleCamo01 = 3969903833
HeavyRifleClip01 = 1525977990
HeavyRifleClip02 = 1824470811
HeavyRifleSight01 = 3017917522
HeavyShotgunClip01 = 844049759
HeavyShotgunClip02 = 2535257853
HeavyShotgunClip03 = 2294798931
HeavySniperClip01 = 1198478068
HeavySniperMk2Camo = 4164123906
HeavySniperMk2Camo02 = 3317620069
HeavySniperMk2Camo03 = 3916506229
HeavySniperMk2Camo04 = 329939175
HeavySniperMk2Camo05 = 643374672
HeavySniperMk2Camo06 = 807875052
HeavySniperMk2Camo07 = 2893163128
HeavySniperMk2Camo08 = 3198471901
HeavySniperMk2Camo09 = 3447155842
HeavySniperMk2Camo10 = 2881858759
HeavySniperMk2CamoIndependence01 = 1815270123
HeavySniperMk2Clip01 = 4196276776
HeavySniperMk2Clip02 = 752418717
HeavySniperMk2ClipArmorPiercing = 4164277972
HeavySniperMk2ClipExplosive = 2313935527
HeavySniperMk2ClipFMJ = 1005144310
HeavySniperMk2ClipIncendiary = 247526935
HomingLauncherClip01 = 4162006335
KnuckleVarmodBallas = 4007263587
KnuckleVarmodBase = 4081463091
KnuckleVarmodDiamond = 2539772380
KnuckleVarmodDollar = 1351683121
KnuckleVarmodHate = 2112683568
KnuckleVarmodKing = 3800804335
KnuckleVarmodLove = 1062111910
KnuckleVarmodPimp = 3323197061
KnuckleVarmodPlayer = 146278587
KnuckleVarmodVagos = 2062808965
MachinePistolClip01 = 1198425599
MachinePistolClip02 = 3106695545
MachinePistolClip03 = 2850671348
MarksmanPistolClip01 = 3416146413
MarksmanRifleClip01 = 3627761985
MarksmanRifleClip02 = 3439143621
MarksmanRifleVarmodLuxe = 371102273
MarksmanRifleMk2Camo = 2425682848
MarksmanRifleMk2Camo02 = 1931539634
MarksmanRifleMk2Camo03 = 1624199183
MarksmanRifleMk2Camo04 = 4268133183
MarksmanRifleMk2Camo05 = 4084561241
MarksmanRifleMk2Camo06 = 423313640
MarksmanRifleMk2Camo07 = 276639596
MarksmanRifleMk2Camo08 = 3303610433
MarksmanRifleMk2Camo09 = 2612118995
MarksmanRifleMk2Camo10 = 996213771
MarksmanRifleMk2CamoIndependence01 = 3080918746
MarksmanRifleMk2Clip01 = 2497785294
MarksmanRifleMk2Clip02 = 3872379306
MarksmanRifleMk2ClipArmorPiercing = 4100968569
MarksmanRifleMk2ClipFMJ = 3779763923
MarksmanRifleMk2ClipIncendiary = 1842849902
MarksmanRifleMk2ClipTracer = 3615105746
MicroSMGClip01 = 3410538224
MicroSMGClip02 = 283556395
MicroSMGVarmodLuxe = 1215999497
MicroSMGVarmodFrn = 1694268374
MGClip01 = 4097109892
MGClip02 = 2182449991
MGVarmodLowrider = 3604658878
MilitaryRifleClip01 = 759617595
MilitaryRifleClip02 = 1749732930
MilitaryRifleSight01 = 1803744149
MinigunClip01 = 3370020614
MiniSMGClip01 = 2227745491
MiniSMGClip02 = 2474561719
MusketClip01 = 1322387263
NavyRevolverClip01 = 2556346983
PericoPistolClip01 = 2871488073
Pistol50Clip01 = 580369945
Pistol50Clip02 = 3654528146
Pistol50VarmodLuxe = 2008591151
PistolClip01 = 4275109233
PistolClip02 = 3978713628
PistolVarmodLuxe = 3610841222
PistolMk2Camo = 1550611612
PistolMk2Camo02 = 368550800
PistolMk2Camo03 = 2525897947
PistolMk2Camo04 = 24902297
PistolMk2Camo05 = 4066925682
PistolMk2Camo06 = 3710005734
PistolMk2Camo07 = 3141791350
PistolMk2Camo08 = 1301287696
PistolMk2Camo09 = 1597093459
PistolMk2Camo10 = 1769871776
PistolMk2CamoIndependence01 = 2467084625
PistolMk2CamoSlide = 3036451504
PistolMk2Camo02Slide = 438243936
PistolMk2Camo03Slide = 3839888240
PistolMk2Camo04Slide = 740920107
PistolMk2Camo05Slide = 3753350949
PistolMk2Camo06Slide = 1809261196
PistolMk2Camo07Slide = 2648428428
PistolMk2Camo08Slide = 3004802348
PistolMk2Camo09Slide = 3330502162
PistolMk2Camo10Slide = 1135718771
PistolMk2CamoIndependence01Slide = 1253942266
PistolMk2Clip01 = 2499030370
PistolMk2Clip02 = 1591132456
PistolMk2ClipFMJ = 1329061674
PistolMk2ClipHollowPoint = 2248057097
PistolMk2ClipIncendiary = 733837882
PistolMk2ClipTracer = 634039983
PoliceTorchFlashlight = 3315797997
PrecisionRifleClip01 = 4075474698
PumpShotgunClip01 = 3513717816
PumpShotgunVarmodLowrider = 2732039643
PumpShotgunMk2Camo = 3820854852
PumpShotgunMk2Camo02 = 387223451
PumpShotgunMk2Camo03 = 617753366
PumpShotgunMk2Camo04 = 4072589040
PumpShotgunMk2Camo05 = 8741501
PumpShotgunMk2Camo06 = 3693681093
PumpShotgunMk2Camo07 = 3783533691
PumpShotgunMk2Camo08 = 3639579478
PumpShotgunMk2Camo09 = 4012490698
PumpShotgunMk2Camo10 = 1739501925
PumpShotgunMk2CamoIndependence01 = 1178671645
PumpShotgunMk2Clip01 = 3449028929
PumpShotgunMk2ClipArmorPiercing = 1315288101
PumpShotgunMk2ClipExplosive = 1004815965
PumpShotgunMk2ClipHollowPoint = 3914869031
PumpShotgunMk2ClipIncendiary = 2676628469
RailgunClip01 = 59044840
RailgunXmas3Clip01 = 1130760338
RevolverClip01 = 3917905123
RevolverVarmodBoss = 384708672
RevolverVarmodGoon = 2492708877
RevolverMk2Camo = 3225415071
RevolverMk2Camo02 = 11918884
RevolverMk2Camo03 = 176157112
RevolverMk2Camo04 = 4074914441
RevolverMk2Camo05 = 288456487
RevolverMk2Camo06 = 398658626
RevolverMk2Camo07 = 628697006
RevolverMk2Camo08 = 925911836
RevolverMk2Camo09 = 1222307441
RevolverMk2Camo10 = 552442715
RevolverMk2CamoIndependence01 = 3646023783
RevolverMk2Clip01 = 3122911422
RevolverMk2ClipFMJ = 231258687
RevolverMk2ClipHollowPoint = 284438159
RevolverMk2ClipIncendiary = 15712037
RevolverMk2ClipTracer = 3336103030
RPGClip01 = 1319465907
RPGVarmodTvr = 3054824576
SawnoffShotgunClip01 = 3352699429
SawnoffShotgunVarmodLuxe = 2242268665
ServiceCarbineClip01 = 927578299
ServiceCarbineClip02 = 2241090895
SMGClip01 = 643254679
SMGClip02 = 889808635
SMGClip03 = 2043113590
SMGVarmodLuxe = 663170192
SMGMk2Camo = 3298267239
SMGMk2Camo02 = 940943685
SMGMk2Camo03 = 1263226800
SMGMk2Camo04 = 3966931456
SMGMk2Camo05 = 1224100642
SMGMk2Camo06 = 899228776
SMGMk2Camo07 = 616006309
SMGMk2Camo08 = 2733014785
SMGMk2Camo09 = 572063080
SMGMk2Camo10 = 1170588613
SMGMk2CamoIndependence01 = 966612367
SMGMk2Clip01 = 1277460590
SMGMk2Clip02 = 3112393518
SMGMk2ClipFMJ = 190476639
SMGMk2ClipHollowPoint = 974903034
SMGMk2ClipIncendiary = 3650233061
SMGMk2ClipTracer = 2146055916
SniperRifleClip01 = 2613461129
SniperRifleVarmodLuxe = 1077065191
SNSPistolClip01 = 4169150169
SNSPistolClip02 = 2063610803
SNSPistolVarmodLowrider = 2150886575
SNSPistolMk2Camo = 259780317
SNSPistolMk2Camo02 = 2321624822
SNSPistolMk2Camo03 = 1996130345
SNSPistolMk2Camo04 = 2839309484
SNSPistolMk2Camo05 = 2626704212
SNSPistolMk2Camo06 = 1308243489
SNSPistolMk2Camo07 = 1122574335
SNSPistolMk2Camo08 = 1420313469
SNSPistolMk2Camo09 = 109848390
SNSPistolMk2Camo10 = 593945703
SNSPistolMk2CamoIndependence01 = 1142457062
SNSPistolMk2CamoSlide = 3891161322
SNSPistolMk2Camo02Slide = 691432737
SNSPistolMk2Camo03Slide = 987648331
SNSPistolMk2Camo04Slide = 3863286761
SNSPistolMk2Camo05Slide = 3447384986
SNSPistolMk2Camo06Slide = 4202375078
SNSPistolMk2Camo07Slide = 3800418970
SNSPistolMk2Camo08Slide = 730876697
SNSPistolMk2Camo09Slide = 583159708
SNSPistolMk2Camo10Slide = 2366463693
SNSPistolMk2CamoIndependence01Slide = 520557834
SNSPistolMk2Clip01 = 21392614
SNSPistolMk2Clip02 = 3465283442
SNSPistolMk2ClipFMJ = 3239176998
SNSPistolMk2ClipHollowPoint = 2366665730
SNSPistolMk2ClipIncendiary = 3870121849
SNSPistolMk2ClipTracer = 2418909806
SpecialCarbineClip01 = 3334989185
SpecialCarbineClip02 = 2089537806
SpecialCarbineClip03 = 1801039530
SpecialCarbineVarmodLowrider = 1929467122
SpecialCarbineMk2Camo = 3557537083
SpecialCarbineMk2Camo02 = 1125852043
SpecialCarbineMk2Camo03 = 886015732
SpecialCarbineMk2Camo04 = 3032680157
SpecialCarbineMk2Camo05 = 3999758885
SpecialCarbineMk2Camo06 = 3750812792
SpecialCarbineMk2Camo07 = 172765678
SpecialCarbineMk2Camo08 = 2312089847
SpecialCarbineMk2Camo09 = 2072122460
SpecialCarbineMk2Camo10 = 2308747125
SpecialCarbineMk2CamoIndependence01 = 1377355801
SpecialCarbineMk2Clip01 = 382112385
SpecialCarbineMk2Clip02 = 3726614828
SpecialCarbineMk2ClipArmorPiercing = 1362433589
SpecialCarbineMk2ClipFMJ = 1346235024
SpecialCarbineMk2ClipIncendiary = 3724612230
SpecialCarbineMk2ClipTracer = 2271594122
SweeperShotgunClip01 = 169463950
SwitchbladeVarmodBase = 2436343040
SwitchbladeVarmodVar1 = 1530822070
SwitchbladeVarmodVar2 = 3885209186
TacticalSMGClip01 = 943088878
TacticalSMGClip02 = 310778254
UpNAtomizerVarmodXmas18 = 3621517063
VintagePistolClip01 = 1168357051
VintagePistolClip02 = 867832552
WM29PistolClip01 = 375646046
WM29PistolSupp = 503494624
```

## WeaponGroup

enum `GTA.WeaponGroup`

| Name | Value |
| --- | --- |
| `Unarmed` | 2685387236 |
| `Melee` | 3566412244 |
| `Pistol` | 416676503 |
| `SMG` | 3337201093 |
| `AssaultRifle` | 970310034 |
| `DigiScanner` | 3539449195 |
| `FireExtinguisher` | 4257178988 |
| `MG` | 1159398588 |
| `NightVision` | 3493187224 |
| `Parachute` | 431593103 |
| `Shotgun` | 860033945 |
| `Sniper` | 3082541095 |
| `Stungun` | 690389602 |
| `Heavy` | 2725924767 |
| `Thrown` | 1548507267 |
| `PetrolCan` | 1595662460 |

## WeaponHash

enum `GTA.WeaponHash`

114 values:

```text
Knife = 2578778090
Nightstick = 1737195953
Hammer = 1317494643
Bat = 2508868239
GolfClub = 1141786504
Crowbar = 2227010557
Bottle = 4192643659
SwitchBlade = 3756226112
BattleAxe = 3441901897
PoolCue = 2484171525
Wrench = 419712736
StoneHatchet = 940833800
CandyCane = 1703483498
Pistol = 453432689
PistolMk2 = 3219281620
CombatPistol = 1593441988
APPistol = 584646201
Pistol50 = 2578377531
FlareGun = 1198879012
MarksmanPistol = 3696079510
Revolver = 3249783761
RevolverMk2 = 3415619887
DoubleActionRevolver = 2548703416
UpNAtomizer = 2939590305
CeramicPistol = 727643628
NavyRevolver = 2441047180
MetalDetector = 3684886537
PericoPistol = 1470379660
WM29Pistol = 465894841
HackingDevice = 485882440
MicroSMG = 324215364
SMG = 736523883
SMGMk2 = 2024373456
AssaultSMG = 4024951519
CombatPDW = 171789620
MiniSMG = 3173288789
TacticalSMG = 350597077
AssaultRifle = 3220176749
AssaultrifleMk2 = 961495388
CarbineRifle = 2210333304
CarbineRifleMk2 = 4208062921
AdvancedRifle = 2937143193
CompactRifle = 1649403952
MilitaryRifle = 2636060646
HeavyRifle = 3347935668
ServiceCarbine = 3520460075
BattleRifle = 1924557585
MG = 2634544996
CombatMG = 2144741730
CombatMGMk2 = 3686625920
UnholyHellbringer = 1198256469
PumpShotgun = 487013001
PumpShotgunMk2 = 1432025498
SawnOffShotgun = 2017895192
AssaultShotgun = 3800352039
BullpupShotgun = 2640438543
DoubleBarrelShotgun = 4019527611
SweeperShotgun = 317205821
CombatShotgun = 94989220
StunGun = 911657153
StunGunMultiplayer = 1171102963
SniperRifle = 100416529
HeavySniper = 205991906
HeavySniperMk2 = 177293209
PrecisionRifle = 1853742572
GrenadeLauncher = 2726580491
GrenadeLauncherSmoke = 1305664598
CompactGrenadeLauncher = 125959754
CompactEMPLauncher = 3676729658
RPG = 2982836145
Minigun = 1119849093
Widowmaker = 3056410471
SnowballLauncher = 62870901
Grenade = 2481070269
StickyBomb = 741814745
SmokeGrenade = 4256991824
BZGas = 2694266206
Molotov = 615608432
PipeBomb = 3125143736
FireExtinguisher = 101631238
PetrolCan = 883325847
HazardousJerryCan = 3126027122
FertilizerCan = 406929569
AcidPackage = 4159824478
SNSPistol = 3218215474
SNSPistolMk2 = 2285322324
SpecialCarbine = 3231910285
SpecialCarbineMk2 = 2526821735
HeavyPistol = 3523564046
BullpupRifle = 2132975508
BullpupRifleMk2 = 2228681469
HomingLauncher = 1672152130
ProximityMine = 2874559379
Snowball = 126349499
VintagePistol = 137902532
Dagger = 2460120199
Firework = 2138347493
Musket = 2828843422
MarksmanRifle = 3342088282
MarksmanRifleMk2 = 1785463520
HeavyShotgun = 984333226
Gusenberg = 1627465347
Hatchet = 4191993645
Railgun = 1834241177
RailgunXmas3 = 4272043364
Unarmed = 2725352035
KnuckleDuster = 3638508604
Machete = 3713923289
MachinePistol = 3675956304
Flashlight = 2343591895
Ball = 600439132
Flare = 1233104067
NightVision = 2803906140
Parachute = 4222310262
```

## WeaponHudStats

struct `GTA.WeaponHudStats`

### Properties

- `public int Accuracy { get; }`
- `public int Capacity { get; }`
- `public int Damage { get; }`
- `public int Range { get; }`
- `public int Speed { get; }`

### Methods

- `public static ScrWeaponHudStats op_Implicit(WeaponHudStats value)`
- `public static WeaponHudStats op_Implicit(ScrWeaponHudStats value)`

## WeaponScriptResourceFlags

enum `GTA.WeaponScriptResourceFlags`

| Name | Value |
| --- | --- |
| `RequestBaseAnims` | 1 |
| `RequestCoverAnims` | 2 |
| `RequestMeleeAnims` | 4 |
| `RequestMotionAnims` | 8 |
| `RequestStealthAnims` | 16 |
| `RequestAllMovementVariationAnims` | 32 |
| `RequestAllAnims` | 31 |

## WeaponTint

enum `GTA.WeaponTint`

| Name | Value |
| --- | --- |
| `Normal` | 0 |
| `Green` | 1 |
| `Gold` | 2 |
| `Pink` | 3 |
| `Army` | 4 |
| `LSPD` | 5 |
| `Orange` | 6 |
| `Platinum` | 7 |

## Weather

enum `GTA.Weather`

| Name | Value |
| --- | --- |
| `Unknown` | -1 |
| `ExtraSunny` | 0 |
| `Clear` | 1 |
| `Clouds` | 2 |
| `Smog` | 3 |
| `Foggy` | 4 |
| `Overcast` | 5 |
| `Raining` | 6 |
| `ThunderStorm` | 7 |
| `Clearing` | 8 |
| `Neutral` | 9 |
| `Snowing` | 10 |
| `Blizzard` | 11 |
| `Snowlight` | 12 |
| `Christmas` | 13 |
| `Halloween` | 14 |

## WindowTitle

enum `GTA.WindowTitle`

| Name | Value | Description |
| --- | --- | --- |
| `EnterEyefindMessage` | 0 | "Enter your Eyefind message (MAX 500 characters)" |
| `MessageTooLong` | 1 | "Message too long. Try again (MAX 500 characters)" |
| `ForbiddenMessage` | 2 | "Forbidden message. Try again (MAX 500 characters)" |
| `EnterEyefindSubject` | 3 | "Enter your Eyefind subject (MAX 60 characters)" |
| `SubjectTooLong` | 4 | "Subject too long. Try again (MAX 60 characters)" |
| `EnterSynopsis` | 5 | "Enter Synopsis (MAX 125 characters)" |
| `EnterCustomTeamName` | 6 | "Enter Custom Team Name (MAX 15 characters)" |
| `ForbiddenText15` | 7 | "Forbidden Text. Try again (MAX 15 characters)" |
| `CustomTeamName` | 8 | "Custom Team Name" |
| `EnterMessage60` | 9 | "Enter Message (MAX 60 characters)" |
| `ForbiddenText60` | 10 | "Forbidden Text. Try again (MAX 60 characters)" |
| `InvalidMessage` | 11 | "Invalid Message. Try again (MAX 20 characters)" |
| `EnterMessage20` | 12 | "Enter Message (MAX 20 characters)" |
| `EnterOutfitName` | 13 | "Enter Outfit Name (MAX 15 characters)" |
| `InvalidOutfitName` | 14 | "Invalid Outfit Name. Try again (MAX 15 characters)" |
| `OutfitName` | 15 | "Outfit Name" |
| `EnterChallengeName` | 16 | "Enter your Challenge name (MAX 30 characters)" |

## World

static class `GTA.World`

### Properties

- `public static int AnimatedBuildingCapacity { get; }`
  - The total number of `AnimatedBuilding`s that can exist in the world.
- `public static int AnimatedBuildingCount { get; }`
  - A fast way to get the total number of `AnimatedBuilding`s spawned in the world.
- `public static bool Blackout { get; set; }`
  - Sets a value indicating whether lights in the `World` should be rendered.
- `public static int BuildingCapacity { get; }`
  - The total number of `Building`s that can exist in the world.
- `public static int BuildingCount { get; }`
  - A fast way to get the total number of `Building`s spawned in the world.
- `public static DateTime CurrentDate { get; set; }`
  - **Obsolete.** World.CurrentDate is obsolete because DateTime can represent the years only in the range of 1 to 9999, while the game supports wider range of years.Use properties or methods of GTA.Chrono.GameClock instead.
  - Gets or sets the current date and time in the GTA World.
- `public static TimeSpan CurrentTimeOfDay { get; set; }`
  - **Obsolete.** World.CurrentTimeOfDay is obsolete, use GTA.Chrono.GameClock.Today instead.
  - Gets or sets the current time of day in the GTA World.
- `public static int EntityColliderCapacity { get; }`
  - The total number of `Entity` colliders can be used. The return value can be different in different versions. When `EntityColliderCount` reaches this value, no more `Entity` will not be able to be physically moved and `Vehicle`s and `Prop`s will not be able to detach fragment parts properly.
- `public static int EntityColliderCount { get; }`
  - Returns the total number of `Entity` colliders used.
- `public static float GravityLevel { get; set; }`
  - Sets the gravity level for all `World` objects.
- `public static int InteriorInstanceCapacity { get; }`
  - The total number of `InteriorInstance`s that can exist in the world.
- `public static int InteriorInstanceCount { get; }`
  - A fast way to get the total number of `InteriorInstance`s spawned in the world.
- `public static int InteriorProxyCapacity { get; }`
  - The total number of `InteriorProxy`s the game can manage at the same time in the `InteriorProxy` pool.
- `public static int InteriorProxyCount { get; }`
  - A fast way to get the total number of `InteriorProxy`s managed in the `InteriorProxy` pool.
- `public static bool IsClockPaused { get; set; }`
  - **Obsolete.** World.IsClockPaused is obsolete, use GTA.Chrono.IsPaused instead.
  - Gets or sets a value indicating whether the in-game clock is paused.
- `public static int MillisecondsPerGameMinute { get; set; }`
  - **Obsolete.** World.MillisecondsPerGameMinute is obsolete, use GTA.Chrono.GameClock.MillisecondsPerGameMinute instead.
  - Gets or sets how many milliseconds in the real world one game minute takes.
- `public static Weather NextWeather { get; set; }`
  - Gets or sets the next weather.
- `public static int PedCapacity { get; }`
  - The total number of `Ped`s that can exist in the world.
- `public static int PedCount { get; }`
  - A fast way to get the total number of `Ped`s spawned in the world.
- `public static int PickupObjectCapacity { get; }`
  - The total number of `Prop`s in the world associated with a `Pickup` that can exist in the world.
- `public static int PickupObjectCount { get; }`
  - A fast way to get the total number of `Prop`s in the world associated with a `Pickup`.
- `public static int ProjectileCapacity { get; }`
  - The total number of `Projectile`s that can exist in the world. Always returns 50 currently since the limit is hard-coded in the exe.
- `public static int ProjectileCount { get; }`
  - A fast way to get the total number of `Projectile`s spawned in the world.
- `public static int PropCapacity { get; }`
  - The total number of `Prop`s that can exist in the world.
- `public static int PropCount { get; }`
  - A fast way to get the total number of `Prop`s spawned in the world.
- `public static float RainLevel { get; }`
- `public static float RainLevelOverride { set; }`
- `public static Camera RenderingCamera { get; set; }`
  - **Obsolete.** World.RenderingCamera is obsolete. Use ScriptCameraDirector.RenderingCam to get the rendering scripted camera. Use ScriptCameraDirector.StartRendering or ScriptCameraDirector.StopRendering to tell the game to render or stop rendering a scripted camera.
  - Gets or sets the rendering camera.
- `public static float SnowLevel { get; }`
- `public static float SnowLevelOverride { set; }`
- `public static int VehicleCapacity { get; }`
  - The total number of `Vehicle`s that can exist in the world.
- `public static int VehicleCount { get; }`
  - A fast way to get the total number of `Vehicle`s spawned in the world.
- `public static Blip WaypointBlip { get; }`
  - Gets the waypoint blip.
  - Returns: The `Vector3` coordinates of the Waypoint `Blip`
- `public static Vector3 WaypointPosition { get; set; }`
  - Gets or sets the waypoint position.
  - Returns: The `Vector3` coordinates of the Waypoint `Blip`
- `public static Weather Weather { get; set; }`
  - Gets or sets the weather.
- `public static Vector3 WindDirection { get; }`
- `public static float WindHeadingAngle { get; }`
- `public static float WindHeadingAngleOverride { set; }`
- `public static float WindSpeed { get; }`
- `public static float WindSpeedOverride { set; }`

### Methods

- `public static void AddExplosion(Vector3 position, ExplosionType type, float radius, float cameraShake, Ped owner = null, bool aubidble = true, bool invisible = false)`
  - Creates an explosion in the world
  - `position`: The position of the explosion.
  - `type`: The type of explosion.
  - `radius`: The radius of the explosion.
  - `cameraShake`: The amount of camera shake to apply to nearby cameras.
  - `owner`: The `Ped` who caused the explosion, leave null if no one caused the explosion.
  - `aubidble`: if set to `true` explosion can be heard.
  - `invisible`: if set to `true` explosion is invisible.
- `public static RelationshipGroup AddRelationshipGroup(string name)`
  - Creates a `RelationshipGroup` with the given name.
  - `name`: The name of the relationship group.
- `public static Rope AddRope(RopeType type, Vector3 position, Vector3 rotation, float length, float minLength, bool breakable)`
  - Spawns a `Rope`.
  - `type`: The type of `Rope`.
  - `position`: The position of the `Rope`.
  - `rotation`: The rotation of the `Rope`.
  - `length`: The length of the `Rope`.
  - `minLength`: The minimum length of the `Rope`.
  - `breakable`: if set to `true` the `Rope` will break if shot.
- `public static float CalculateTravelDistance(Vector3 origin, Vector3 destination)`
  - Calculates the travel distance using roads and paths between 2 positions.
  - `origin`: The origin.
  - `destination`: The destination.
  - Returns: The travel distance
- `public static void ClearAngledAreaOfVehicles(Vector3 position1, Vector3 position2, float areaWidth, bool leaveCarGenCars = false, bool checkViewFrustum = false, bool ifWrecked = false, bool ifAbandoned = false, bool ifEngineOnFire = false)`
- `public static void ClearArea(Vector3 position, float radius, bool deleteProjectiles, bool leaveCarGenCars = false, bool clearLowPriorityPickupsOnly = false)`
- `public static void ClearAreaOfCops(Vector3 position, float radius)`
- `public static void ClearAreaOfPeds(Vector3 position, float radius)`
- `public static void ClearAreaOfProjectiles(Vector3 position, float radius)`
- `public static void ClearAreaOfProps(Vector3 position, float radius, ClearPropsFlags flags)`
- `public static void ClearAreaOfVehicles(Vector3 position, float radius, bool leaveCarGenCars = false, bool checkViewFrustum = false, bool ifWrecked = false, bool ifAbandoned = false, bool ifEngineOnFire = false)`
- `public static Prop CreateAmbientPickup(PickupType type, Vector3 position, Model model, int value)`
  - **Obsolete.** The World.CreateAmbientPickup overload with non-optional custom model and amount (named "value") parameters are obsolete since they can lead to confusion in custom model parameter (which is actually not mandatory).Use World.CreateAmbientPickup(PickupType, Vector3, PickupPlacementFlags, int, Model, bool) instead.
  - Spawns a pickup `Prop` at the specified position.
- `public static Prop CreateAmbientPickup(PickupType type, Vector3 position, PickupPlacementFlags placementFlags = 0, int amount = -1, Model customModel = null, bool createAsScriptObject = false)`
  - Spawns a pickup `Prop` at the specified position.
- `public static Blip CreateBlip(Vector3 position, float radius)`
  - **Obsolete.** Use Blip.Create(Vector3, float) instead.
  - Creates a `Blip` for a circular area at the given position on the map.
  - `position`: The position of the blip on the map.
  - `radius`: The radius of the area on the map.
- `public static Blip CreateBlip(Vector3 position)`
  - **Obsolete.** Use Blip.Create(Vector3) instead.
  - Creates a `Blip` at the given position on the map.
  - `position`: The position of the blip on the map.
- `public static Camera CreateCamera(Vector3 position, Vector3 rotation, float fov)`
  - **Obsolete.** World.CreateCamera is obsolete. Use Camera.Create instead.
  - Creates a `Camera`, use `RenderingCamera` to switch to this camera
  - `position`: The position of the camera.
  - `rotation`: The rotation of the camera.
  - `fov`: The field of view of the camera.
- `public static Checkpoint CreateCheckpoint(CheckpointCustomIcon icon, Vector3 position, Vector3 pointTo, float radius, Color color)`
  - **Obsolete.** Use Checkpoint.Create(CheckpointCustomIcon, Vector3, Vector3, float, Color) instead.
  - Creates a `Checkpoint` in the world.
  - `icon`: The `CheckpointCustomIcon` to display inside the `Checkpoint`.
  - `position`: The position in the World.
  - `pointTo`: The position in the world where this `Checkpoint` should point.
  - `radius`: The radius of the `Checkpoint`.
  - `color`: The color of the `Checkpoint`.
- `public static Checkpoint CreateCheckpoint(CheckpointIcon icon, Vector3 position, Vector3 pointTo, float radius, Color color)`
  - **Obsolete.** Use Checkpoint.Create(CheckpointIcon, Vector3, Vector3, float, Color) instead.
  - Creates a `Checkpoint` in the world.
  - `icon`: The `CheckpointIcon` to display inside the `Checkpoint`.
  - `position`: The position in the World.
  - `pointTo`: The position in the world where this `Checkpoint` should point.
  - `radius`: The radius of the `Checkpoint`.
  - `color`: The color of the `Checkpoint`.
- `public static ParticleEffect CreateParticleEffect(ParticleEffectAsset asset, string effectName, Entity entity, Vector3 offset = null, Vector3 rotation = null, float scale = 1, InvertAxisFlags invertAxis = 0)`
  - Creates a `ParticleEffect` on an `Entity` that runs looped.
  - `asset`: The effect asset to use.
  - `effectName`: The name of the Effect
  - `entity`: The `Entity` the effect is attached to.
  - `offset`: The offset from the `entity` to attach the effect.
  - `rotation`: The rotation, relative to the `entity`, the effect has.
  - `scale`: How much to scale the size of the effect by.
  - `invertAxis`: Which axis to flip the effect in. For a car side exhaust you may need to flip in the Y Axis.
- `public static ParticleEffect CreateParticleEffect(ParticleEffectAsset asset, string effectName, EntityBone entityBone, Vector3 offset = null, Vector3 rotation = null, float scale = 1, InvertAxisFlags invertAxis = 0)`
  - Creates a `ParticleEffect` on an `EntityBone` that runs looped.
  - `asset`: The effect asset to use.
  - `effectName`: The name of the Effect
  - `entityBone`: The `EntityBone` the effect is attached to.
  - `offset`: The offset from the `entityBone` to attach the effect.
  - `rotation`: The rotation, relative to the `entityBone`, the effect has.
  - `scale`: How much to scale the size of the effect by.
  - `invertAxis`: Which axis to flip the effect in. For a car side exhaust you may need to flip in the Y Axis.
- `public static ParticleEffect CreateParticleEffect(ParticleEffectAsset asset, string effectName, Vector3 position, Vector3 rotation = null, float scale = 1, InvertAxisFlags invertAxis = 0)`
  - Creates a `ParticleEffect` at a position that runs looped.
  - `asset`: The effect asset to use.
  - `effectName`: The name of the effect.
  - `position`: The world coordinates where the effect is.
  - `rotation`: What rotation to apply to the effect.
  - `scale`: How much to scale the size of the effect by.
  - `invertAxis`: Which axis to flip the effect in.
- `public static bool CreateParticleEffectNonLooped(ParticleEffectAsset asset, string effectName, Entity entity, Vector3 off = null, Vector3 rot = null, float scale = 1, InvertAxisFlags invertAxis = 0)`
  - Starts a Particle Effect on an `Entity` that runs once then is destroyed.
  - `asset`: The effect asset to use.
  - `effectName`: the name of the effect.
  - `entity`: The `Entity` the effect is attached to.
  - `off`: The offset from the `entity` to attach the effect.
  - `rot`: The rotation, relative to the `entity`, the effect has.
  - `scale`: How much to scale the size of the effect by.
  - `invertAxis`: Which axis to flip the effect in. For a car side exahust you may need to flip in the Y Axis
  - Returns: `true`If the effect was able to start; otherwise, `false`.
- `public static bool CreateParticleEffectNonLooped(ParticleEffectAsset asset, string effectName, EntityBone entityBone, Vector3 off = null, Vector3 rot = null, float scale = 1, InvertAxisFlags invertAxis = 0)`
  - Starts a Particle Effect on an `EntityBone` that runs once then is destroyed.
  - `asset`: The effect asset to use.
  - `effectName`: the name of the effect.
  - `entityBone`: The `EntityBone` the effect is attached to.
  - `off`: The offset from the `entityBone` to attach the effect.
  - `rot`: The rotation, relative to the `entityBone`, the effect has.
  - `scale`: How much to scale the size of the effect by.
  - `invertAxis`: Which axis to flip the effect in. For a car side exahust you may need to flip in the Y Axis
  - Returns: `true`If the effect was able to start; otherwise, `false`.
- `public static bool CreateParticleEffectNonLooped(ParticleEffectAsset asset, string effectName, Vector3 pos, Vector3 rot = null, float scale = 1, InvertAxisFlags invertAxis = 0)`
  - Starts a Particle Effect that runs once at a given position then is destroyed.
  - `asset`: The effect asset to use.
  - `effectName`: The name of the effect.
  - `pos`: The World position where the effect is.
  - `rot`: What rotation to apply to the effect.
  - `scale`: How much to scale the size of the effect by.
  - `invertAxis`: Which axis to flip the effect in.
  - Returns: `true`If the effect was able to start; otherwise, `false`.
- `public static Ped CreatePed(Model model, Vector3 position, float heading = 0)`
  - **Obsolete.** Use Ped.Create(Model, Vector3, float) instead.
  - Spawns a `Ped` of the given `Model` at the position and heading specified.
  - `model`: The `Model` of the `Ped`.
  - `position`: The position to spawn the `Ped` at.
  - `heading`: The heading of the `Ped`.
- `public static Pickup CreatePickup(PickupType type, Vector3 position, Vector3 rotation, Model model, int value)`
  - **Obsolete.** The World.CreatePickup overloads with non-optional custom model and amount (named "value") parameters are obsolete since they can lead to confusion in custom model parameter (which is actually not mandatory).Use a World.CreatePickup overload with optional placement flags and amount parameters instead.
  - Spawns a `Pickup` at the specified position.
- `public static Pickup CreatePickup(PickupType type, Vector3 position, Vector3 rotation, PickupPlacementFlags placementFlags = 0, int amount = -1, EulerRotationOrder rotOrder = 2, Model customModel = null)`
  - **Obsolete.** Use Pickup.Create(PickupType, Vector3, Vector3, PickupPlacementFlags, int, EulerRotationOrder, Model) instead.
- `public static Pickup CreatePickup(PickupType type, Vector3 position, Model model, int value)`
  - **Obsolete.** The World.CreatePickup overloads with non-optional custom model and amount (named "value") parameters are obsolete since they can lead to confusion in custom model parameter (which is actually not mandatory).Use a World.CreatePickup overload with optional placement flags and amount parameters instead.
  - Spawns a `Pickup` at the specified position.
- `public static Pickup CreatePickup(PickupType type, Vector3 position, PickupPlacementFlags placementFlags = 0, int amount = -1, Model customModel = null)`
  - **Obsolete.** Use Pickup.Create(PickupType, Vector3, PickupPlacementFlags, int, Model) instead.
- `public static Prop CreateProp(Model model, Vector3 position, Vector3 rotation, bool dynamic, bool placeOnGround)`
  - **Obsolete.** Use Prop.Create(Model, Vector3, Vector3, bool, bool) instead.
  - Spawns a `Prop` of the given `Model` at the specified position.
  - `model`: The `Model` of the `Prop`.
  - `position`: The position to spawn the `Prop` at.
  - `rotation`: The rotation of the `Prop`.
  - `dynamic`: if set to `true` the `Prop` will have physics; otherwise, it will be static.
  - `placeOnGround`: if set to `true` place the prop on the ground nearest to the `position`.
- `public static Prop CreateProp(Model model, Vector3 position, bool dynamic, bool placeOnGround)`
  - **Obsolete.** Use Prop.Create(Model, Vector3, bool, bool) instead.
  - Spawns a `Prop` of the given `Model` at the specified position.
  - `model`: The `Model` of the `Prop`.
  - `position`: The position to spawn the `Prop` at.
  - `dynamic`: if set to `true` the `Prop` will have physics; otherwise, it will be static.
  - `placeOnGround`: if set to `true` place the prop on the ground nearest to the `position`.
- `public static Prop CreatePropNoOffset(Model model, Vector3 position, Vector3 rotation, bool dynamic)`
  - **Obsolete.** Use Prop.CreateNoOffset(Model, Vector3, Vector3, bool) instead.
  - Spawns a `Prop` of the given `Model` at the specified position without any offset.
  - `model`: The `Model` of the `Prop`.
  - `position`: The position to spawn the `Prop` at.
  - `rotation`: The rotation of the `Prop`.
  - `dynamic`: if set to `true` the `Prop` will have physics; otherwise, it will be static.
- `public static Prop CreatePropNoOffset(Model model, Vector3 position, bool dynamic)`
  - **Obsolete.** Use Prop.CreateNoOffset(Model, Vector3, bool) instead.
  - Spawns a `Prop` of the given `Model` at the specified position without any offset.
  - `model`: The `Model` of the `Prop`.
  - `position`: The position to spawn the `Prop` at.
  - `dynamic`: if set to `true` the `Prop` will have physics; otherwise, it will be static.
- `public static Ped CreateRandomPed(Vector3 position, float heading, Func<Model, bool> predicate = null)`
  - **Obsolete.** Use Ped.CreateRandom(Vector3, float, Func<Model, bool>) instead.
  - Spawns a `Ped` of a random `Model` at the position specified.
  - `position`: The position to spawn the `Ped` at.
  - `heading`: The heading of the `Ped`.
  - `predicate`: The method that determines whether a model should be considered when choosing a random model for the `Ped`. If `null` is set, gangster and animal models will not be chosen, just like CREATE_PED does.
- `public static Ped CreateRandomPed(Vector3 position)`
  - **Obsolete.** Use Ped.CreateRandom(Vector3) instead.
  - Spawns a `Ped` of a random `Model` at the position specified.
  - `position`: The position to spawn the `Ped` at.
- `public static Vehicle CreateRandomVehicle(Vector3 position, float heading = 0, Func<Model, bool> predicate = null)`
  - **Obsolete.** Use Vehicle.CreateRandom(Vector3, float, Func<Model, bool>) instead.
  - Spawns a `Vehicle` of a random `Model` at the position specified.
  - `position`: The position to spawn the `Vehicle` at.
  - `heading`: The heading of the `Vehicle`.
  - `predicate`: The method that determines whether a model should be considered when choosing a random model for the `Vehicle`.
- `public static Vehicle CreateVehicle(Model model, Vector3 position, float heading = 0)`
  - **Obsolete.** Use Vehicle.Create(Model, Vector3, float) instead.
  - Spawns a `Vehicle` of the given `Model` at the position and heading specified.
  - `model`: The `Model` of the `Vehicle`.
  - `position`: The position to spawn the `Vehicle` at.
  - `heading`: The heading of the `Vehicle`.
- `public static void DeleteAllTrains()`
- `public static void DestroyAllCameras()`
  - **Obsolete.** World.DestroyAllCameras is obsolete. Use Camera.DeleteAllCameras instead.
  - Destroys all user created `Camera`s.
- `public static void DrawBoxForAngledArea(Vector3 originEdge, Vector3 extentEdge, float width, Color color, DrawBoxFlags drawFlags = 1)`
  - Draws a box that occupies the angled area. An angled area is an X-Z oriented rectangle with three parameters: origin, extent, and width.
  - `originEdge`: The mid-point along a base edge of the rectangle.
  - `extentEdge`: The mid-point of opposite base edge on the other Z.
  - `width`: The length of the base edge.
  - `color`: The color of the box.
  - `drawFlags`: Which sides to draw.
- `public static void DrawLightWithRange(Vector3 position, Color color, float range, float intensity)`
  - Draws light around a region.
  - `position`: The position to center the light around.
  - `color`: The color of the light.
  - `range`: How far the light should extend to.
  - `intensity`: The intensity: `0.0f` being no intensity, `1.0f` being full intensity.
- `public static void DrawLine(Vector3 start, Vector3 end, Color color)`
- `public static void DrawMarker(MarkerType type, Vector3 pos, Vector3 dir, Vector3 rot, Vector3 scale, Color color, bool bobUpAndDown = false, bool faceCamera = false, bool rotateY = false, string textueDict = null, string textureName = null, bool drawOnEntity = false)`
  - Draws a marker in the world, this needs to be done on a per frame basis
  - `type`: The type of marker.
  - `pos`: The position of the marker.
  - `dir`: The direction the marker points in.
  - `rot`: The rotation of the marker.
  - `scale`: The amount to scale the marker by.
  - `color`: The color of the marker.
  - `bobUpAndDown`: if set to `true` the marker will bob up and down.
  - `faceCamera`: if set to `true` the marker will always face the camera, regardless of its rotation.
  - `rotateY`: if set to `true` rotates only on the y axis(heading).
  - `textueDict`: Name of texture dictionary to load the texture from, leave null for no texture in the marker.
  - `textureName`: Name of texture inside the dictionary to load the texture from, leave null for no texture in the marker.
  - `drawOnEntity`: if set to `true` draw on any `Entity` that intersects the marker.
- `public static void DrawMarkerEx(MarkerType type, Vector3 pos, Vector3 dir, Vector3 rot, Vector3 scale, Color color, bool bounce = false, bool faceCamera = false, EulerRotationOrder rotOrder = 2, bool rotate = false, TextureAsset? texAsset = null, bool renderInverted = false, bool usePreAlphaDepth = true, bool matchEntityRotOrder = false)`
- `public static void DrawPolygon(Vector3 vertexA, Vector3 vertexB, Vector3 vertexC, Color color)`
- `public static void DrawSpotLight(Vector3 pos, Vector3 dir, Color color, float distance, float brightness, float roundness, float radius, float fadeout)`
- `public static void DrawSpotLightWithShadow(Vector3 pos, Vector3 dir, Color color, float distance, float brightness, float roundness, float radius, float fadeout)`
- `public static void ForceLightningFlash()`
- `public static AnimatedBuilding[] GetAllAnimatedBuildings()`
- `public static Blip[] GetAllBlips(params BlipSprite[] blipTypes)`
  - Gets an `array` of all the `Blip`s on the map with a given `BlipSprite`.
  - `blipTypes`: The blip types to include, leave blank to get all `Blip`s.
- `public static Building[] GetAllBuildings()`
- `public static Checkpoint[] GetAllCheckpoints()`
  - Gets an `array` of all the `Checkpoint`s.
- `public static Entity[] GetAllEntities()`
  - Gets an `array` of all `Entity`s in the World.
- `public static InteriorInstance[] GetAllInteriorInstances()`
- `public static InteriorProxy[] GetAllInteriorProxies()`
- `public static Ped[] GetAllPeds(params Model[] models)`
  - Gets an `array`of all `Ped`s in the World.
  - `models`: The `Model` of `Ped`s to get, leave blank for all `Ped``Model`s.
- `public static Prop[] GetAllPickupObjects()`
  - Gets an `array` of all `Prop`s in the World associated with a `Pickup`.
- `public static Projectile[] GetAllProjectiles()`
  - Gets an `array` of all `Projectile`s in the World.
- `public static Prop[] GetAllProps(params Model[] models)`
  - Gets an `array` of all `Prop`s in the World.
  - `models`: The `Model` of `Prop`s to get, leave blank for all `Prop``Model`s.
- `public static ProjectileRocket[] GetAllRocketProjectiles()`
- `public static ProjectileThrown[] GetAllThrownProjectiles()`
- `public static Vehicle[] GetAllVehicles(params Model[] models)`
  - Gets an `array` of all `Vehicle`s in the World.
  - `models`: The `Model` of `Vehicle`s to get, leave blank for all `Vehicle``Model`s.
- `public static float GetApproxFloorForArea(Vector2 minPosition, Vector2 maxPosition)`
- `public static float GetApproxFloorForPoint(Vector2 position)`
- `public static float GetApproxHeightForArea(Vector2 minPosition, Vector2 maxPosition)`
- `public static float GetApproxHeightForPoint(Vector2 position)`
- `public static AnimatedBuilding GetClosest(Vector2 position, params AnimatedBuilding[] animatedBuildings)`
  - Gets the closest `AnimatedBuilding` to a given position in the World ignoring height.
  - `position`: The position to check against.
  - `animatedBuildings`: The animated building to check.
  - Returns: The closest `AnimatedBuilding` to the `position`
- `public static Building GetClosest(Vector2 position, params Building[] buildings)`
  - Gets the closest `Building` to a given position in the World ignoring height.
  - `position`: The position to check against.
  - `buildings`: The buildings to check.
  - Returns: The closest `Building` to the `position`
- `public static InteriorInstance GetClosest(Vector2 position, params InteriorInstance[] interiorInstances)`
  - Gets the closest `InteriorInstance` to a given position in the World ignoring height.
  - `position`: The position to check against.
  - `interiorInstances`: The interior instances to check.
  - Returns: The closest `InteriorInstance` to the `interiorInstances`
- `public static InteriorProxy GetClosest(Vector2 position, params InteriorProxy[] interiorProxies)`
  - Gets the closest `InteriorProxy` to a given position in the World ignoring height.
  - `position`: The position to check against.
  - `interiorProxies`: The spatials to check.
  - Returns: The closest `InteriorProxy` to the `position`
- `public static AnimatedBuilding GetClosest(Vector3 position, params AnimatedBuilding[] animatedBuildings)`
  - Gets the closest `AnimatedBuilding` to a given position in the World.
  - `position`: The position to check against.
  - `animatedBuildings`: The animated building to check.
  - Returns: The closest `AnimatedBuilding` to the `position`
- `public static Building GetClosest(Vector3 position, params Building[] buildings)`
  - Gets the closest `Building` to a given position in the World.
  - `position`: The position to check against.
  - `buildings`: The buildings to check.
  - Returns: The closest `Building` to the `position`
- `public static InteriorInstance GetClosest(Vector3 position, params InteriorInstance[] interiorInstances)`
  - Gets the closest `InteriorInstance` to a given position in the World.
  - `position`: The position to check against.
  - `interiorInstances`: The spatials to check.
  - Returns: The closest `InteriorInstance` to the `position`
- `public static InteriorProxy GetClosest(Vector3 position, params InteriorProxy[] interiorProxies)`
  - Gets the closest `InteriorProxy` to a given position in the World.
  - `position`: The position to check against.
  - `interiorProxies`: The spatials to check.
  - Returns: The closest `InteriorProxy` to the `position`
- `public static T GetClosest<T>(Vector2 position, params T[] spatials)`
  - Gets the closest `ISpatial` to a given position in the World ignoring height.
  - `position`: The position to check against.
  - `spatials`: The spatials to check.
  - Returns: The closest `ISpatial` to the `position`
- `public static T GetClosest<T>(Vector3 position, params T[] spatials)`
  - Gets the closest `ISpatial` to a given position in the World.
  - `position`: The position to check against.
  - `spatials`: The spatials to check.
  - Returns: The closest `ISpatial` to the `position`
- `public static AnimatedBuilding GetClosestAnimatedBuilding(Vector3 position, float radius)`
- `public static Building GetClosestBuilding(Vector3 position, float radius)`
- `public static InteriorInstance GetClosestInteriorInstance(Vector3 position, float radius)`
- `public static InteriorProxy GetClosestInteriorProxy(Vector3 position, float radius)`
- `public static Ped GetClosestPed(Vector3 position, float radius, params Model[] models)`
  - Gets the closest `Ped` to a given position in the World.
  - `position`: The position to find the nearest `Ped`.
  - `radius`: The maximum distance from the `position` to detect `Ped`s.
  - `models`: The `Model` of `Ped`s to get, leave blank for all `Ped``Model`s.
- `public static Prop GetClosestPickupObject(Vector3 position, float radius)`
  - Gets the closest `Prop` to a given position in the World associated with a `Pickup`.
  - `position`: The position to find the nearest `Prop`.
  - `radius`: The maximum distance from the `position` to detect `Prop`s.
- `public static Projectile GetClosestProjectile(Vector3 position, float radius)`
  - Gets the closest `Projectile` to a given position in the World.
  - `position`: The position to find the nearest `Projectile`.
  - `radius`: The maximum distance from the `position` to detect `Projectile`s.
- `public static Prop GetClosestProp(Vector3 position, float radius, params Model[] models)`
  - Gets the closest `Prop` to a given position in the World.
  - `position`: The position to find the nearest `Prop`.
  - `radius`: The maximum distance from the `position` to detect `Prop`s.
  - `models`: The `Model` of `Prop`s to get, leave blank for all `Prop``Model`s.
- `public static ProjectileRocket GetClosestRocketProjectile(Vector3 position, float radius)`
- `public static ProjectileThrown GetClosestThrownProjectile(Vector3 position, float radius)`
- `public static Vehicle GetClosestVehicle(Vector3 position, float radius, params Model[] models)`
  - Gets the closest `Vehicle` to a given position in the World.
  - `position`: The position to find the nearest `Vehicle`.
  - `radius`: The maximum distance from the `position` to detect `Vehicle`s.
  - `models`: The `Model` of `Vehicle`s to get, leave blank for all `Vehicle``Model`s.
- `public static RaycastResult GetCrosshairCoordinates()`
  - Determines where the crosshair intersects with the world.
  - Returns: A `RaycastResult` containing information about where the crosshair intersects with the world.
- `public static RaycastResult GetCrosshairCoordinates(IntersectFlags intersectOptions = 511, Entity ignoreEntity = null)`
  - Determines where the crosshair intersects with the world.
  - `intersectOptions`: Type of `IntersectFlags` the raycast should intersect with.
  - `ignoreEntity`: Prevent the raycast detecting a specific `Entity`.
  - Returns: A `RaycastResult` containing information about where the crosshair intersects with the world.
- `public static float GetDistance(Vector3 origin, Vector3 destination)`
  - **Obsolete.** Use Vector3.Distance(Vector3, Vector3) instead.
  - Gets the straight line distance between 2 positions.
  - `origin`: The origin.
  - `destination`: The destination.
  - Returns: The distance
- `public static float GetGroundHeight(Vector2 position)`
  - **Obsolete.** Use GetGroundHeight(Vector3, out float, GetGroundHeightMode) instead.
  - Gets the height of the ground at a given position.
  - `position`: The position.
  - Returns: The height measured in meters
- `public static bool GetGroundHeight(Vector3 position, out float height, GetGroundHeightMode mode = 0)`
- `public static float GetGroundHeight(Vector3 position)`
  - **Obsolete.** Use GetGroundHeight(Vector3, out float, GetGroundHeightMode) instead.
  - Gets the height of the ground at a given position. Note : If the Vector3 is already below the ground, this will return 0. You may want to use the other overloaded function to be safe.
  - `position`: The position.
  - Returns: The height measured in meters
- `public static bool GetGroundHeightAndNormal(Vector3 position, out float height, out Vector3 normal)`
- `public static bool GetGroundHeightExcludingProps(Vector3 position, out float height, GetGroundHeightMode mode = 0)`
- `public static AnimatedBuilding[] GetNearbyAnimatedBuildings(Vector3 position, float radius)`
- `public static Blip[] GetNearbyBlips(Vector3 position, float radius, params BlipSprite[] blipTypes)`
  - Gets an `array` of all `Blip`s in a given region in the World.
  - `position`: The position to check the `Blip` against.
  - `radius`: The maximum distance from the `position` to detect `Blip`s.
  - `blipTypes`: The blip types to include, leave blank to get all `Blip`s.
- `public static Building[] GetNearbyBuildings(Vector3 position, float radius)`
- `public static Entity[] GetNearbyEntities(Vector3 position, float radius)`
  - Gets an `array` of all `Entity`s in a given region in the World.
  - `position`: The position to check the `Entity` against.
  - `radius`: The maximun distance from the `position` to detect `Entity`s.
- `public static InteriorInstance[] GetNearbyInteriorInstances(Vector3 position, float radius)`
- `public static InteriorProxy[] GetNearbyInteriorProxies(Vector3 position, float radius)`
- `public static Ped[] GetNearbyPeds(Vector3 position, float radius, params Model[] models)`
  - Gets an `array` of all `Ped`s in a given region in the World.
  - `position`: The position to check the `Ped` against.
  - `radius`: The maximun distance from the `position` to detect `Ped`s.
  - `models`: The `Model` of `Ped`s to get, leave blank for all `Ped``Model`s.
- `public static Ped[] GetNearbyPeds(Ped ped, float radius, params Model[] models)`
  - Gets an `array` of all `Ped`s near a given `Ped` in the world
  - `ped`: The ped to check.
  - `radius`: The maximun distance from the `ped` to detect `Ped`s.
  - `models`: The `Model` of `Ped`s to get, leave blank for all `Ped``Model`s.
- `public static Prop[] GetNearbyPickupObjects(Vector3 position, float radius)`
  - Gets an `array` of all `Prop`s in a given region in the World associated with a `Pickup`.
  - `position`: The position to check the `Entity` against.
  - `radius`: The maximun distance from the `position` to detect `Prop`s.
- `public static Projectile[] GetNearbyProjectiles(Vector3 position, float radius)`
  - Gets an `array` of all `Projectile`s in a given region in the World.
  - `position`: The position to check the `Projectile` against.
  - `radius`: The maximum distance from the `position` to detect `Projectile`s.
- `public static Prop[] GetNearbyProps(Vector3 position, float radius, params Model[] models)`
  - Gets an `array` of all `Prop`s in a given region in the World.
  - `position`: The position to check the `Prop` against.
  - `radius`: The maximun distance from the `position` to detect `Prop`s.
  - `models`: The `Model` of `Prop`s to get, leave blank for all `Prop``Model`s.
- `public static ProjectileRocket[] GetNearbyRocketProjectiles(Vector3 position, float radius)`
- `public static ProjectileThrown[] GetNearbyThrownProjectiles(Vector3 position, float radius)`
- `public static Vehicle[] GetNearbyVehicles(Vector3 position, float radius, params Model[] models)`
  - Gets an `array` of all `Vehicle`s in a given region in the World.
  - `position`: The position to check the `Vehicle` against.
  - `radius`: The maximun distance from the `position` to detect `Vehicle`s.
  - `models`: The `Model` of `Vehicle`s to get, leave blank for all `Vehicle``Model`s.
- `public static Vehicle[] GetNearbyVehicles(Ped ped, float radius, params Model[] models)`
  - Gets an `array` of all `Vehicle`s near a given `Ped` in the world
  - `ped`: The ped to check.
  - `radius`: The maximun distance from the `ped` to detect `Vehicle`s.
  - `models`: The `Model` of `Vehicle`s to get, leave blank for all `Vehicle``Model`s.
- `public static Vector3 GetNextPositionOnSidewalk(Vector2 position)`
  - Gets the next position on the street where a `Ped` can be placed.
  - `position`: The position to check around.
- `public static Vector3 GetNextPositionOnSidewalk(Vector3 position)`
  - Gets the next position on the street where a `Ped` can be placed.
  - `position`: The position to check around.
- `public static Vector3 GetNextPositionOnStreet(Vector2 position, bool unoccupied = false)`
  - Gets the next position on the street where a `Vehicle` can be placed.
  - `position`: The position to check around.
  - `unoccupied`: if set to `true` only find positions that dont already have a vehicle in them.
- `public static Vector3 GetNextPositionOnStreet(Vector3 position, bool unoccupied = false)`
  - Gets the next position on the street where a `Vehicle` can be placed.
  - `position`: The position to check around.
  - `unoccupied`: if set to `true` only find positions that dont already have a vehicle in them.
- `public static Vector3 GetNextPositionOnStreetWithHeading(Vector2 position, out float heading, bool unoccupied = false)`
- `public static Vector3 GetNextPositionOnStreetWithHeading(Vector3 position, out float heading, bool unoccupied = false)`
- `public static Vector3 GetNextPositionOnWater(Vector2 position, bool unoccupied = false)`
- `public static Vector3 GetNextPositionOnWater(Vector3 position, bool unoccupied = false)`
- `public static bool GetPositionOnRoadside(Vector3 position, Direction direction, out Vector3 output)`
- `public static Vector3 GetSafeCoordForPed(Vector3 position, bool sidewalk = true, int flags = 0)`
  - **Obsolete.** World.GetSafeCoordForPed is obsolete since there is no way to check if the method is failed while GET_SAFE_COORD_FOR_PED provides one.Use GetSafePositionForPed instead.
  - Gets the nearest safe coordinate to position a `Ped`.
  - `position`: The position to check around.
  - `sidewalk`: if set to `true` Only find positions on the sidewalk.
  - `flags`: The flags.
- `public static bool GetSafePositionForPed(Vector3 position, out Vector3 safePosition, GetSafePositionFlags flags = 0)`
- `public static string GetStreetName(Vector2 position)`
  - Determines the name of the street which is the closest to the given coordinates.
- `public static string GetStreetName(Vector3 position, out string crossingRoadName)`
  - Determines the name of the street which is the closest to the given coordinates.
  - `position`: The coordinates of the street
  - `crossingRoadName`: If the coordinates are on an intersection, the name of the crossing road
  - Returns: Returns the name of the street the coordinates are on.
- `public static string GetStreetName(Vector3 position)`
  - Determines the name of the street which is the closest to the given coordinates.
- `public static string GetZoneDisplayName(Vector2 position)`
  - Gets the display name of the a zone in the map. Use `GetLocalizedString` to convert to the localized name.
  - `position`: The position on the map.
- `public static string GetZoneDisplayName(Vector3 position)`
  - Gets the display name of the a zone in the map. Use `GetLocalizedString` to convert to the localized name.
  - `position`: The position on the map.
- `public static string GetZoneLocalizedName(Vector2 position)`
  - Gets the localized name of the a zone in the map.
  - `position`: The position on the map.
- `public static string GetZoneLocalizedName(Vector3 position)`
  - Gets the localized name of the a zone in the map.
  - `position`: The position on the map.
- `public static bool IsPointInAngledArea(Vector3 point, Vector3 originEdge, Vector3 extentEdge, float width, bool includeZAxis = true)`
  - Determines whether the specified point is in the angled area. An angled area is an X-Z oriented rectangle with three parameters: origin, extent, and width.
  - `point`: The point to check whether is in the angled area.
  - `originEdge`: The mid-point along a base edge of the rectangle.
  - `extentEdge`: The mid-point of opposite base edge on the other Z.
  - `width`: The length of the base edge.
  - `includeZAxis`: If set to `true`, the method will also check if the point is in area in Z axis as well as X and Y axes. If set to `false`, the method will only check if the point is in area in X and Y axes.
  - Returns: `true` if the specified point is in the specified angled area; otherwise, `false`.
- `public static void PauseClock(bool value)`
  - **Obsolete.** The World.PauseClock is obsolete, use GTA.Chrono.IsPaused instead.
  - Pauses or resumes the in-game clock.
  - `value`: Pauses the game clock if set to `true`; otherwise, resumes the game clock.
- `public static RaycastResult Raycast(Vector3 source, Vector3 target, IntersectFlags options, Entity ignoreEntity = null)`
  - Creates a raycast between 2 points.
  - `source`: The source of the raycast.
  - `target`: The target of the raycast.
  - `options`: What type of objects the raycast should intersect with.
  - `ignoreEntity`: Specify an `Entity` that the raycast should ignore, leave null for no entities ignored.
- `public static RaycastResult Raycast(Vector3 source, Vector3 direction, float maxDistance, IntersectFlags options, Entity ignoreEntity = null)`
  - Creates a raycast between 2 points.
  - `source`: The source of the raycast.
  - `direction`: The direction of the raycast.
  - `maxDistance`: How far the raycast should go out to.
  - `options`: What type of objects the raycast should intersect with.
  - `ignoreEntity`: Specify an `Entity` that the raycast should ignore, leave null for no entities ignored.
- `public static RaycastResult RaycastCapsule(Vector3 source, Vector3 target, float radius, IntersectFlags options, Entity ignoreEntity = null)`
  - **Obsolete.** World.RaycastCapsule is obsolete because the result may not be made in the same frame you call the method. Use ShapeTest.StartTestCapsule instead.
  - Creates a 3D raycast between 2 points.
  - `source`: The source of the raycast.
  - `target`: The target of the raycast.
  - `radius`: The radius of the raycast.
  - `options`: What type of objects the raycast should intersect with.
  - `ignoreEntity`: Specify an `Entity` that the raycast should ignore, leave null for no entities ignored.
- `public static RaycastResult RaycastCapsule(Vector3 source, Vector3 direction, float maxDistance, float radius, IntersectFlags options, Entity ignoreEntity = null)`
  - **Obsolete.** World.RaycastCapsule is obsolete because the result may not be made in the same frame you call the method. Use ShapeTest.StartTestCapsule instead.
  - Creates a 3D raycast between 2 points.
  - `source`: The source of the raycast.
  - `direction`: The direction of the raycast.
  - `radius`: The radius of the raycast.
  - `maxDistance`: How far the raycast should go out to.
  - `options`: What type of objects the raycast should intersect with.
  - `ignoreEntity`: Specify an `Entity` that the raycast should ignore, leave null for no entities ignored.
- `public static void RemoveAllParticleEffectsInRange(Vector3 pos, float range)`
  - Stops all particle effects in a range.
  - `pos`: The position in the world to stop particle effects.
  - `range`: The maximum distance from the `pos` to stop particle effects.
- `public static void RemoveWaypoint()`
  - Removes the waypoint.
- `public static void SetAmbientPedDensityMultiplierThisFrame(float densityMult)`
- `public static void SetAmbientVehicleDensityMultiplierThisFrame(float densityMult)`
- `public static void SetRandomWeather()`
- `public static void SetWindSpeedOverrideBySpeed(float windSpeed)`
- `public static void ShootBullet(Vector3 sourcePosition, Vector3 targetPosition, Ped owner, WeaponAsset weaponAsset, int damage, float speed = -1)`
  - **Obsolete.** Use ShootSingleBullet instead.
  - Fires a single bullet in the world
  - `sourcePosition`: Where the bullet is fired from.
  - `targetPosition`: Where the bullet is fired to.
  - `owner`: The `Ped` who fired the bullet, leave `null` for no one.
  - `weaponAsset`: The weapon that the bullet is fired from.
  - `damage`: The damage the bullet will cause.
  - `speed`: The speed, only affects projectile weapons, leave -1 for default.
- `public static void ShootSingleBullet(Vector3 startPosition, Vector3 endPosition, int damage, WeaponAsset weapon, Ped owner = null, bool perfectAccuracy = true, bool createTraceVfx = true, bool allowRumble = true, float initialVelocity = -1)`
- `public static void ShootSingleBulletIgnoreEntity(Vector3 startPosition, Vector3 endPosition, int damage, WeaponAsset weapon, Ped owner = null, bool perfectAccuracy = true, bool createTraceVfx = true, bool allowRumble = true, float initialVelocity = -1, Entity ignoreEntity = null, Entity targetEntity = null)`
- `public static void ShootSingleBulletIgnoreEntityNew(Vector3 startPosition, Vector3 endPosition, int damage, WeaponAsset weapon, Ped owner = null, bool perfectAccuracy = true, bool createTraceVfx = true, bool allowRumble = true, float initialVelocity = -1, Entity ignoreEntity = null, bool forceCreateNewProjectileObject = false, bool disablePlayerCoverStartAdjustment = false, Entity targetEntity = null, bool freezeProjectileWaitingOnCollision = false, bool ignoreCollisionEntity = false, bool ignoreCollisionResetNoBB = false)`
- `public static void TransitionToWeather(Weather weather, float duration)`
  - Transitions to weather.
  - `weather`: The weather.
  - `duration`: The duration.
- `public static void VehicleHighSpeedBumpMultiplier(float multiplier)`

