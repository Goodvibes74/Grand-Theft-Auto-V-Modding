# GTA.NaturalMotion (ScriptHookVDotNet v2 (legacy))

[Back to the ScriptHookVDotNet v2 (legacy) index](README.md)

> **Source:** `ScriptHookVDotNet2.dll` (file version 2.11.6, assembly version 2.11.6.0, 984,576 bytes, modified 2026-08-05, SHA-256 `8f9ec05e5ccf83781ef4abe45abfb51d8231e4fc9ee2b56884caf00d5a642594`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `ScriptHookVDotNet2.xml` from the NuGet package `scripthookvdotnet2` 2.11.6 (nuget.org), the same version as the installed DLL.

## ActivePoseHelper

class `GTA.NaturalMotion.ActivePoseHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ActivePoseHelper(Ped ped)`
  - Creates a new Instance of the ActivePoseHelper for sending a ActivePose `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ActivePose `Message` to.

### Properties

- `public AnimSource AnimSource { set; }`
  - Animation source.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation).
- `public bool UseGravityCompensation { set; }`
  - Apply gravity compensation.

## AdaptiveMode

enum `GTA.NaturalMotion.AdaptiveMode`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `NotAdaptive` | 0 |
| `OnlyDirection` | 1 |
| `DirectionAndSpeed` | 2 |
| `DirectionSpeedAndStrength` | 3 |

## AnimPoseHelper

class `GTA.NaturalMotion.AnimPoseHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public AnimPoseHelper(Ped ped)`
  - Creates a new Instance of the AnimPoseHelper for sending a AnimPose `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the AnimPose `Message` to.

### Properties

- `public AnimSource AnimSource { set; }`
- `public int ConnectedLeftFoot { set; }`
  - Is the left foot constrained to the world/ an object: -2=do not set in animpose (e.g. let the balancer decide), -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
- `public int ConnectedLeftHand { set; }`
  - Is the left hand constrained to the world/ an object: -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
- `public int ConnectedRightFoot { set; }`
  - Is the right foot constrained to the world/ an object: -2=do not set in animpose (e.g. let the balancer decide),-1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
- `public int ConnectedRightHand { set; }`
  - Is the right hand constrained to the world/ an object: -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
- `public int DampenSideMotionInstanceIndex { set; }`
  - LevelIndex of object to dampen side motion relative to. -1 means not used.
- `public float Damping { set; }`
  - Damping of masked joints.
- `public float DampingLeftArm { set; }`
  - Damping applied to left arm (applied after stiffness). If stiffness -ve then not applied (use current setting).
- `public float DampingLeftLeg { set; }`
  - Damping applied to left leg (applied after stiffness). If stiffness-ve then not applied (use current setting).
- `public float DampingRightArm { set; }`
  - Damping applied to right arm (applied after stiffness). If stiffness -ve then not applied (use current setting).
- `public float DampingRightLeg { set; }`
  - Damping applied to right leg (applied after stiffness). If stiffness -ve then not applied (use current setting).
- `public float DampingSpine { set; }`
  - Damping applied to spine (applied after stiffness). If stiffness-ve then not applied (use current setting).
- `public string EffectorMask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation).
- `public float GravCompLeftArm { set; }`
  - Gravity compensation applied to left arm (applied after gravityCompensation). If -ve then not applied (use current setting).
- `public float GravCompLeftLeg { set; }`
  - Gravity compensation applied to left leg (applied after gravityCompensation). If -ve then not applied (use current setting).
- `public float GravCompRightArm { set; }`
  - Gravity compensation applied to right arm (applied after gravityCompensation). If -ve then not applied (use current setting).
- `public float GravCompRightLeg { set; }`
  - Gravity compensation applied to right leg (applied after gravityCompensation). If -ve then not applied (use current setting).
- `public float GravCompSpine { set; }`
  - Gravity compensation applied to spine (applied after gravityCompensation). If -ve then not applied (use current setting).
- `public float GravityCompensation { set; }`
  - Gravity compensation applied to joints in the effectorMask. If -ve then not applied (use current setting).
- `public float MuscleStiffness { set; }`
  - Muscle stiffness of masked joints. -values mean don't apply (just use defaults or ones applied by behaviors - safer if you are going to return to a behavior).
- `public float MuscleStiffnessLeftArm { set; }`
  - Muscle stiffness applied to left arm (applied after stiffness). If -ve then not applied (use current setting).
- `public float MuscleStiffnessLeftLeg { set; }`
  - Muscle stiffness applied to left leg (applied after stiffness). If -ve then not applied (use current setting).
- `public float MuscleStiffnessRightArm { set; }`
  - Muscle stiffness applied to right arm (applied after stiffness). If -ve then not applied (use current setting).
- `public float MuscleStiffnessRightLeg { set; }`
  - Muscle stiffness applied to right leg (applied after stiffness). If -ve then not applied (use current setting).
- `public float MuscleStiffnessSpine { set; }`
  - Muscle stiffness applied to spine (applied after stiffness). If -ve then not applied (use current setting).
- `public bool OverideHeadlook { set; }`
  - Overide Headlook behavior (if animPose includes the head).
- `public bool OveridePointArm { set; }`
  - Overide PointArm behavior (if animPose includes the arm/arms).
- `public bool OveridePointGun { set; }`
  - Overide PointGun behavior (if animPose includes the arm/arms)//mmmmtodo not used at moment.
- `public float Stiffness { set; }`
  - Stiffness of masked joints. -ve values mean don't apply stiffness or damping (just use defaults or ones applied by behaviors). If you are using animpose fullbody on its own then this gives the opprtunity to use setStffness and setMuscle stiffness messages to set up the character's muscles. Mmmmtodo get rid of this -ve.
- `public float StiffnessLeftArm { set; }`
  - Stiffness applied to left arm (applied after stiffness). If -ve then not applied (use current setting).
- `public float StiffnessLeftLeg { set; }`
  - Stiffness applied to left leg (applied after stiffness). If -ve then not applied (use current setting).
- `public float StiffnessRightArm { set; }`
  - Stiffness applied to right arm (applied after stiffness). If -ve then not applied (use current setting).
- `public float StiffnessRightLeg { set; }`
  - Stiffness applied to right leg (applied after stiffness). If -ve then not applied (use current setting).
- `public float StiffnessSpine { set; }`
  - Stiffness applied to spine (applied after stiffness). If -ve then not applied (use current setting).
- `public bool UseZMPGravityCompensation { set; }`
  - If true then modify gravity compensation based on stance (can reduce gravity compensation to zero if cofm is outside of balance area).

## AnimSource

enum `GTA.NaturalMotion.AnimSource`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `CurrentItems` | 0 |
| `PreviousItems` | 1 |
| `AnimItems` | 2 |

## ApplyBulletImpulseHelper

class `GTA.NaturalMotion.ApplyBulletImpulseHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ApplyBulletImpulseHelper(Ped ped)`
  - Creates a new Instance of the ApplyBulletImpulseHelper for sending a ApplyBulletImpulse `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ApplyBulletImpulse `Message` to.

### Properties

- `public float EqualizeAmount { set; }`
  - 0 means straight impulse, 1 means multiply by the mass (change in velocity).
- `public float ExtraShare { set; }`
  - If not 0.0 then have an extra bullet applied to spine0 (approximates the COM). Uses setup from configureBulletsExtra. 0-1 shared 0.0 = no extra bullet, 0.5 = impulse split equally between extra and bullet, 1.0 only extra bullet. LT 0.0 then bullet + scaled extra bullet. Eg.-0.5 = bullet + 0.5 impulse extra bullet.
- `public Vector3 HitPoint { set; }`
  - Optional point on part where hit.
- `public Vector3 Impulse { set; }`
  - Impulse vector (impulse is change in momentum).
- `public bool LocalHitPointInfo { set; }`
  - True = hitPoint is in local coordinates of bodyPart, false = hit point is in world coordinates.
- `public int PartIndex { set; }`
  - Index of part being hit.

## ApplyImpulseHelper

class `GTA.NaturalMotion.ApplyImpulseHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ApplyImpulseHelper(Ped ped)`
  - Creates a new Instance of the ApplyImpulseHelper for sending a ApplyImpulse `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ApplyImpulse `Message` to.

### Properties

- `public bool AngularImpulse { set; }`
  - Impulse should be considered an angular impulse.
- `public float EqualizeAmount { set; }`
  - 0 means straight impulse, 1 means multiply by the mass (change in velocity).
- `public Vector3 HitPoint { set; }`
  - Optional point on part where hit. If not supplied then the impulse is applied at the part center.
- `public Vector3 Impulse { set; }`
  - Impulse vector (impulse is change in momentum).
- `public bool LocalHitPointInfo { set; }`
  - Hit point in local coordinates of body part.
- `public bool LocalImpulseInfo { set; }`
  - Impulse in local coordinates of body part.
- `public int PartIndex { set; }`
  - Index of part being hit. -1 apply impulse to COM.

## ArmDirections

enum `GTA.NaturalMotion.ArmDirections`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Backwards` | -1 |
| `Adaptive` | 0 |
| `Forwards` | 1 |

## ArmsWindmillAdaptiveHelper

class `GTA.NaturalMotion.ArmsWindmillAdaptiveHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ArmsWindmillAdaptiveHelper(Ped ped)`
  - Creates a new Instance of the ArmsWindmillAdaptiveHelper for sending a ArmsWindmillAdaptive `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ArmsWindmillAdaptive `Message` to.

### Properties

- `public float Amplitude { set; }`
  - Controls how large the motion is, higher values means the character waves his arms in a massive arc.
- `public float AngSpeed { set; }`
  - Controls the speed of the windmilling.
- `public ArmDirections ArmDirection { set; }`
- `public float ArmStiffness { set; }`
  - How stiff the arms are controls how pronounced the windmilling motion appears.
- `public bool BendLeftElbow { set; }`
  - If true, bend the left elbow to give a stunt man type scramble look.
- `public bool BendRightElbow { set; }`
  - If true, bend the right elbow to give a stunt man type scramble look.
- `public float BodyStiffness { set; }`
  - Controls how stiff the rest of the body is.
- `public bool DisableOnImpact { set; }`
  - If true, each arm will stop windmilling if it hits the ground.
- `public float ElbowRate { set; }`
  - Rate at which elbow tries to match *ElbowAngle.
- `public float Lean1mult { set; }`
  - 0 arms go up and down at the side. 1 circles. 0..1 elipse.
- `public float Lean1offset { set; }`
  - 0.f center of circle at side.
- `public float LeftElbowAngle { set; }`
  - If not negative then left arm will blend to this angle.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public float Phase { set; }`
  - Set to a non-zero value to desynchronize the left and right arms motion.
- `public float RightElbowAngle { set; }`
  - If not negative then right arm will blend to this angle.
- `public bool SetBackAngles { set; }`
  - If true, back angles will be set to compliment arms windmill.
- `public bool UseAngMom { set; }`
  - If true, use angular momentum about com to choose arm circling direction. Otherwise use com angular velocity.

## ArmsWindmillHelper

class `GTA.NaturalMotion.ArmsWindmillHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ArmsWindmillHelper(Ped ped)`
  - Creates a new Instance of the ArmsWindmillHelper for sending a ArmsWindmill `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ArmsWindmill `Message` to.

### Properties

- `public AdaptiveMode AdaptiveMode { set; }`
- `public float AngVelGain { set; }`
  - Multiplies angular speed of character to get speed of arms.
- `public float AngVelThreshold { set; }`
  - Value of character angular speed above which adaptive arm motion starts.
- `public bool DisableOnImpact { set; }`
  - If true, each arm will stop windmilling if it hits the ground.
- `public float DragReduction { set; }`
  - How much to compensate for movement of character/target.
- `public float ElbowDamping { set; }`
  - Damping applied to the elbows.
- `public float ElbowStiffness { set; }`
  - Stiffness applied to the elbows.
- `public bool ForceSync { set; }`
  - Toggles phase synchronization.
- `public float IKtwist { set; }`
  - Angle of elbow around twist axis ?.
- `public Vector3 LeftCentre { set; }`
  - Centre of circle in the space of partID.
- `public float LeftElbowMin { set; }`
  - Minimum left elbow bend.
- `public Vector3 LeftNormal { set; }`
  - Euler Angles orientation of circle in space of part with part ID.
- `public int LeftPartID { set; }`
  - ID of part that the circle uses as local space for positioning.
- `public float LeftRadius1 { set; }`
  - Radius for first axis of ellipse.
- `public float LeftRadius2 { set; }`
  - Radius for second axis of ellipse.
- `public float LeftSpeed { set; }`
  - Speed of target around the circle.
- `public MirrorMode MirrorMode { set; }`
- `public float PhaseOffset { set; }`
  - Phase offset(degrees) when phase synchronization is turned on.
- `public Vector3 RightCentre { set; }`
  - Centre of circle in the space of partID.
- `public float RightElbowMin { set; }`
  - Minimum right elbow bend.
- `public Vector3 RightNormal { set; }`
  - Euler Angles orientation of circle in space of part with part ID.
- `public int RightPartID { set; }`
  - ID of part that the circle uses as local space for positioning.
- `public float RightRadius1 { set; }`
  - Radius for first axis of ellipse.
- `public float RightRadius2 { set; }`
  - Radius for second axis of ellipse.
- `public float RightSpeed { set; }`
  - Speed of target around the circle.
- `public float ShoulderDamping { set; }`
  - Damping applied to the shoulders.
- `public float ShoulderStiffness { set; }`
  - Stiffness applied to the shoulders.
- `public bool UseLeft { set; }`
  - Use the left arm.
- `public bool UseRight { set; }`
  - Use the right arm.

## BalancerCollisionsReactionHelper

class `GTA.NaturalMotion.BalancerCollisionsReactionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public BalancerCollisionsReactionHelper(Ped ped)`
  - Creates a new Instance of the BalancerCollisionsReactionHelper for sending a BalancerCollisionsReaction `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the BalancerCollisionsReaction `Message` to.

### Properties

- `public float BackFrictionMultRate { set; }`
  - Friction multiplier reduced by this amount every second after slump starts (only if character is not slumping).
- `public float BackFrictionMultStart { set; }`
  - Friction multiplier applied to back when slump starts.
- `public bool BraceWall { set; }`
  - Brace against wall if forwards impact(at the moment only if bodyBalance is running/in charge of arms).
- `public float ExclusionZone { set; }`
  - Steps are ihibited to not go closer to the wall than this (after impact).
- `public bool FallOverHighWalls { set; }`
  - Trigger fall over wall if hit up to spine2 else only if hit up to spine1.
- `public bool FallOverWallDrape { set; }`
  - Use fallOverWall as the main drape reaction.
- `public float FootFrictionMultRate { set; }`
  - Friction multiplier reduced by this amount every second after slump starts (only if character is not slumping).
- `public float FootFrictionMultStart { set; }`
  - Friction multiplier applied to feet when slump starts.
- `public int ForwardMode { set; }`
  - 0=slump, 1=fallToKnees if shot is running, otherwise slump.
- `public float GlanceSpinDecayMult { set; }`
  - Multiplier used when decaying torque spin over time.
- `public float GlanceSpinMag { set; }`
  - Magnitude of the glance torque.
- `public float GlanceSpinTime { set; }`
  - Duration that the glance torque is applied for.
- `public float IgnoreColMassBelow { set; }`
  - Collisions with non-fixed objects with mass below this will not set this behavior off (e.g. ignore guns).
- `public float IgnoreColVolumeBelow { set; }`
  - Collisions with non-fixed objects with volume below this will not set this behavior off.
- `public int IgnoreColWithIndex { set; }`
  - Used so impact with the character that is pushing you over doesn't set off the behavior.
- `public float ImpactExagTime { set; }`
  - Time that the character exaggerates impact with spine.
- `public float ImpactLegStiffReduction { set; }`
  - Reduce the stiffness of the legs by this much as soon as an impact is detected.
- `public float ImpactLoosenessAmount { set; }`
  - How loose the character is on impact. Between 0 and 1.
- `public float ImpactWeaknessRampDuration { set; }`
  - Duration of the ramp to bring the character's upper body stiffness back to normal levels.
- `public float ImpactWeaknessZeroDuration { set; }`
  - Duration for which the character's upper body stays at minimum stiffness (not quite zero).
- `public int NumStepsTillSlump { set; }`
  - Begin slump and stop stepping after this many steps.
- `public bool ObjectBehindVictim { set; }`
  - Detected an object behind a shot victim in the direction of a bullet?.
- `public Vector3 ObjectBehindVictimNormal { set; }`
  - The normal of a detected object behind a shot victim in the direction of a bullet.
- `public Vector3 ObjectBehindVictimPos { set; }`
  - The intersection pos of a detected object behind a shot victim in the direction of a bullet.
- `public float ReactTime { set; }`
  - Time that the character reacts to the impact with ub flinch and writhe.
- `public float ReboundForce { set; }`
  - If forwards impact only: cheat force to try to get the character away from the wall. 3 is a good value.
- `public int ReboundMode { set; }`
  - 0=fall2knees/slump if shot not running, 1=stumble, 2=slump, 3=restart.
- `public float SlumpLegStiffRate { set; }`
  - Rate at which the stiffness of the legs is reduced during slump.
- `public float SlumpLegStiffReduction { set; }`
  - Reduce the stiffness of the legs by this much as soon as slump starts.
- `public int SlumpMode { set; }`
  - 0=Normal slump(less movement then slump and movement LT small), 1=fast slump, 2=less movement then slump.
- `public bool Snap { set; }`
  - Add a Snap to when you hit a wall to emphasize the hit.
- `public float SnapDirectionRandomness { set; }`
  - The character snaps in a prescribed way (decided by bullet direction) - Higher the value the more random this direction is.
- `public int SnapHipType { set; }`
  - Type of hip reaction 0=none, 1=side2side 2=steplike.
- `public bool SnapLeftArm { set; }`
  - Snap the leftArm.
- `public bool SnapLeftLeg { set; }`
  - Snap the leftLeg.
- `public float SnapMag { set; }`
  - The magnitude of the snap reaction.
- `public bool SnapNeck { set; }`
  - Snap the neck.
- `public bool SnapPhasedLegs { set; }`
  - Legs are either in phase with each other or not.
- `public bool SnapRightArm { set; }`
  - Snap the rightArm.
- `public bool SnapRightLeg { set; }`
  - Snap the rightLeg.
- `public bool SnapSpine { set; }`
  - Snap the spine.
- `public bool SnapUseTorques { set; }`
  - Use torques to make the snap otherwise use a change in the parts angular velocity.
- `public float Stable2SlumpTime { set; }`
  - Time after becoming stable leaning against a wall that slump starts.
- `public float TimeToForward { set; }`
  - Time after a forwards impact before forwardMode is called (leave sometime for a rebound or brace - the min of 0.1 is to ensure fallOverWall can start although it probably needs only 1or2 frames for the probes to return).
- `public float UnSnapInterval { set; }`
  - Interval before applying reverse snap.
- `public float UnSnapRatio { set; }`
  - The magnitude of the reverse snap.

## BodyBalanceHelper

class `GTA.NaturalMotion.BodyBalanceHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public BodyBalanceHelper(Ped ped)`
  - Creates a new Instance of the BodyBalanceHelper for sending a BodyBalance `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the BodyBalance `Message` to.

### Properties

- `public Vector3 AngVelMultiplier { set; }`
  - Somersault, twist, sideSomersault) multiplier of the angular velocity for arms out (lean2) (somersault, twist, sideSomersault).
- `public Vector3 AngVelThreshold { set; }`
  - Somersault, twist, sideSomersault) threshold above which angVel is used for arms out (lean2) Unless drunk - DO NOT EXCEED 7.0 for each component.
- `public float ArmDamping { set; }`
  - NB. WAS m_damping NeckDamping=1 ClaviclesDamping=1.
- `public float ArmsOutMinLean2 { set; }`
  - Minimum desiredLean2 applied to shoulder (to stop arms going above shoulder height or not).
- `public bool ArmsOutOnPush { set; }`
  - Put arms out based on lean2 of legs, or angular velocity (lean or twist), or lean (front/back or side/side).
- `public float ArmsOutOnPushMultiplier { set; }`
  - Arms out based on lean2 of the legs to simulate being pushed.
- `public float ArmsOutOnPushTimeout { set; }`
  - Number of seconds before turning off the armsOutOnPush response only for Arms out based on lean2 of the legs (NOT for the angle or angular velocity).
- `public float ArmsOutStraightenElbows { set; }`
  - Multiplier for straightening the elbows based on the amount of arms out(lean2) 0 = dont straighten elbows. Otherwise straighten elbows proportionately to armsOut.
- `public float ArmStiffness { set; }`
  - NB. WAS m_bodyStiffness ClaviclesStiffness=9.0f.
- `public bool BackwardsArms { set; }`
  - Bend elbows, relax shoulders and inhibit spine twist when moving backwards.
- `public bool BackwardsAutoTurn { set; }`
  - Automatically turn around if moving backwards.
- `public float BendElbowsGait { set; }`
  - Minimum desired angle of elbow during non contact arm swing.
- `public float BendElbowsTime { set; }`
  - Time after contact (with Upper body) that the min m_elbowAngleOnContact is applied.
- `public bool BlendToZeroPose { set; }`
  - Blend upper body to zero pose as the character comes to rest. If false blend to a stored pose.
- `public float BraceDistance { set; }`
  - If -ve then do not brace. distance from object at which to raise hands to brace 0.5 good if newBrace=true - otherwise 0.65.
- `public float BraceOffset { set; }`
  - BraceTarget is global headLookPos plus braceOffset m in the up direction.
- `public float BraceStiffness { set; }`
  - Stiffness of character. Catch_fall stiffness scales with this too, with its defaults at this values default.
- `public float Elbow { set; }`
  - How much the elbow swings based on the leg movement.
- `public float ElbowAngleOnContact { set; }`
  - On contact with upperbody the desired elbow angle is set to at least this value.
- `public float HandsDelayMax { set; }`
  - If bracing with 2 hands delay one hand by at most this amount of time to introduce some asymmetry.
- `public float HandsDelayMin { set; }`
  - If bracing with 2 hands delay one hand by at least this amount of time to introduce some asymmetry.
- `public float HeadLookAtVelProb { set; }`
  - Probability [0-1] that headLook will be looking in the direction of velocity when stepping.
- `public int HeadLookInstanceIndex { set; }`
  - Level index of thing to look at.
- `public Vector3 HeadLookPos { set; }`
  - Position of thing to look at.
- `public float HipL2ArmL2 { set; }`
  - Mmmmdrunk = 0.2 multiplier of hip lean2 (star jump) to give shoulder lean2 (flapping).
- `public float MinBraceTime { set; }`
  - Minimum bracing time so the character doesn't look twitchy.
- `public float MoveAmount { set; }`
  - Amount of leanForce applied away from pusher.
- `public float MoveRadius { set; }`
  - If -ve don't move away from pusher unless moveWhenBracing is true and braceDistance GT 0.0f. if the pusher is closer than moveRadius then move away from it.
- `public bool MoveWhenBracing { set; }`
  - Only move away from pusher when bracing against pusher.
- `public float ReachAbsorbtionTime { set; }`
  - Larger values and he absorbs the impact more.
- `public float ReturningToBalanceArmsOut { set; }`
  - Range 0:1 0 = don't raise arms if returning to upright position, 0.x = 0.x*raise arms based on angvel and 'angle' settings, 1 = raise arms based on angvel and 'angle' settings.
- `public float Shoulder { set; }`
  - How much the shoulder(lean1) swings based on the leg movement.
- `public float ShoulderL1 { set; }`
  - Mmmmdrunk 1.1 shoulder lean1 offset (+ve frankenstein).
- `public float ShoulderL2 { set; }`
  - Mmmmdrunk = 0.7 shoulder lean2 offset.
- `public float ShoulderTwist { set; }`
  - Mmmmdrunk = 0.0 shoulder twist.
- `public float SideSomersaultAngle { set; }`
  - Amount of side somersault 'angle' before sideSomersault is used for ArmsOut. Unless drunk - DO NOT EXCEED 0.8.
- `public float SideSomersaultAngleThreshold { set; }`
- `public float SomersaultAngle { set; }`
  - Multiplier of the somersault 'angle' (lean forward/back) for arms out (lean2).
- `public float SomersaultAngleThreshold { set; }`
  - Amount of somersault 'angle' before m_somersaultAngle is used for ArmsOut. Unless drunk - DO NOT EXCEED 0.8.
- `public float SpineDamping { set; }`
- `public float SpineStiffness { set; }`
- `public float TargetPredictionTime { set; }`
  - Time expected to get arms up from idle.
- `public float TimeToBackwardsBrace { set; }`
  - Time before arm brace kicks in when hit from behind.
- `public float Turn2TargetProb { set; }`
  - Weighted probability of turning towards headLook target. This is one of six turn type weights.
- `public float Turn2VelProb { set; }`
  - Weighted probability of turning towards velocity. This is one of six turn type weights.
- `public float TurnAwayProb { set; }`
  - Weighted probability of turning away from headLook target. This is one of six turn type weights.
- `public float TurnLeftProb { set; }`
  - Weighted probability of turning left. This is one of six turn type weights.
- `public float TurnOffProb { set; }`
  - Weighted probability that turn will be off. This is one of six turn type weights.
- `public float TurnRightProb { set; }`
  - Weighted probability of turning right. This is one of six turn type weights.
- `public float TurnWithBumpRadius { set; }`
  - 0.9 is a sensible value. If pusher within this distance then turn to get out of the way of the pusher.
- `public bool UseBodyTurn { set; }`
- `public bool UseHeadLook { set; }`
  - Enable and provide a look-at target to make the character's head turn to face it while balancing.

## BodyFoetalHelper

class `GTA.NaturalMotion.BodyFoetalHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public BodyFoetalHelper(Ped ped)`
  - Creates a new Instance of the BodyFoetalHelper for sending a BodyFoetal `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the BodyFoetal `Message` to.

### Properties

- `public float Asymmetry { set; }`
  - A value between 0-1 that controls how asymmetric the results are by varying stiffness across the body.
- `public float BackTwist { set; }`
  - Amount of random back twist to add.
- `public float DampingFactor { set; }`
  - Sets damping value for the character joints.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public int RandomSeed { set; }`
  - Random seed used to generate asymmetry values.
- `public float Stiffness { set; }`
  - The stiffness of the body determines how fast the character moves into the position, and how well that they hold it.

## BodyRelaxHelper

class `GTA.NaturalMotion.BodyRelaxHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Set the amount of relaxation across the whole body; Used to collapse the character into a rag-doll-like state.

### Constructors

- `public BodyRelaxHelper(Ped ped)`
  - Creates a new Instance of the BodyRelaxHelper for sending a BodyRelax `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the BodyRelax `Message` to.

### Properties

- `public float Damping { set; }`
- `public bool DisableJointDriving { set; }`
  - Sets the drive state to free - this reduces drifting on the ground.
- `public bool HoldPose { set; }`
  - Automatically hold the current pose as the character relaxes - can be used to avoid relaxing into a t-pose.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public float Relaxation { set; }`
  - How relaxed the body becomes, in percentage relaxed. 100 being totally rag-dolled, 0 being very stiff and rigid.

## BodyRollUpHelper

class `GTA.NaturalMotion.BodyRollUpHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public BodyRollUpHelper(Ped ped)`
  - Creates a new Instance of the BodyRollUpHelper for sending a BodyRollUp `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the BodyRollUp `Message` to.

### Properties

- `public bool ApplyMinMaxFriction { set; }`
  - Controls whether or not behavior enforces min/max friction.
- `public float ArmReachAmount { set; }`
  - The likeliness of the character reaching for the ground with its arms.
- `public float AsymmetricalLegs { set; }`
  - 0 is no leg asymmetry in 'foetal' position. greater than 0 a asymmetricalLegs-rand(30%), added/minus each joint of the legs in radians. Random number changes about once every roll. 0.4 gives a lot of asymmetry.
- `public float LegPush { set; }`
  - Used to keep rolling down slope, 1 is full (kicks legs out when pointing upwards).
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public float NoRollTimeBeforeSuccess { set; }`
  - Time that roll velocity has to be lower than rollVelForSuccess, before success message is sent.
- `public float RollVelForSuccess { set; }`
  - Lower threshold for roll velocity at which success message can be sent.
- `public float RollVelLinearContribution { set; }`
  - Contribution of linear COM velocity to roll Velocity (if 0, roll velocity equal to COM angular velocity).
- `public float Stiffness { set; }`
  - Stiffness of whole body.
- `public float UseArmToSlowDown { set; }`
  - The degree to which the character will try to stop a barrel roll with his arms.
- `public float VelocityOffset { set; }`
  - Offsets perceived body velocity. Increase to create larger "dead zone" around zero velocity where character will be less rolled. (NB: Reset to 0 to match earlier behavior).
- `public float VelocityScale { set; }`
  - Scales perceived body velocity. The higher this value gets, the more quickly the velocity measure saturates, resulting in a tighter roll at slower speeds. (NB: Set to 1 to match earlier behavior).

## BodyWritheHelper

class `GTA.NaturalMotion.BodyWritheHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public BodyWritheHelper(Ped ped)`
  - Creates a new Instance of the BodyWritheHelper for sending a BodyWrithe `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the BodyWrithe `Message` to.

### Properties

- `public bool ApplyStiffness { set; }`
  - Use writhe stiffnesses if true. If false don't set any stiffnesses.
- `public float ArmAmplitude { set; }`
- `public float ArmDamping { set; }`
  - Damping amount, less is underdamped.
- `public float ArmPeriod { set; }`
  - Controls how fast the writhe is executed, smaller values make faster motions.
- `public float ArmStiffness { set; }`
- `public float BackAmplitude { set; }`
  - Scales the amount of writhe. 0 = no writhe.
- `public float BackDamping { set; }`
  - Damping amount, less is underdamped.
- `public float BackPeriod { set; }`
  - Controls how fast the writhe is executed, smaller values make faster motions.
- `public float BackStiffness { set; }`
- `public float BlendArms { set; }`
  - Blend the writhe arms with the current desired arms (0=don't apply any writhe, 1=only writhe).
- `public float BlendBack { set; }`
  - Blend the writhe spine and neck with the current desired (0=don't apply any writhe, 1=only writhe).
- `public float BlendLegs { set; }`
  - Blend the writhe legs with the current desired legs (0=don't apply any writhe, 1=only writhe).
- `public float ElbowAmplitude { set; }`
- `public float KneeAmplitude { set; }`
- `public float Lean1BlendFactor { set; }`
  - Shoulder desired lean1 with shoulderLean1 angle blend factor. Set it to 0 to use original shoulder withe desired lean1 angle for shoulders. Note that onFire has to be set to true for this parameter to take any effect.
- `public float Lean2BlendFactor { set; }`
  - Shoulder desired lean2 with shoulderLean2 angle blend factor. Set it to 0 to use original shoulder withe desired lean2 angle for shoulders. Note that onFire has to be set to true for this parameter to take any effect.
- `public float LegAmplitude { set; }`
  - Scales the amount of writhe. 0 = no writhe.
- `public float LegDamping { set; }`
  - Damping amount, less is underdamped.
- `public float LegPeriod { set; }`
  - Controls how fast the writhe is executed, smaller values make faster motions.
- `public float LegStiffness { set; }`
  - The stiffness of the character will determine how 'determined' a writhe this is - high values will make him thrash about wildly.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public float MaxRollOverTime { set; }`
  - Rolling torque is ramped down over time. At this time in seconds torque value converges to zero. Use this parameter to restrict time the character is rolling. Note that onFire has to be set to true for this parameter to take any effect.
- `public bool OnFire { set; }`
  - Extra shoulderBlend. Rolling:one way only, maxRollOverTime, rollOverRadius, doesn't reduce arm stiffness to help rolling. No shoulder twist.
- `public bool RollOverFlag { set; }`
  - Flag to set trying to rollOver.
- `public float RollOverRadius { set; }`
  - Rolling torque is ramped down with distance measured from position where character hit the ground and started rolling. At this distance in meters torque value converges to zero. Use this parameter to restrict distance the character travels due to rolling. Note that onFire has to be set to true for this parameter to take any effect.
- `public float RollTorqueScale { set; }`
  - Scale rolling torque that is applied to character spine.
- `public float ShoulderLean1 { set; }`
  - Blend writhe shoulder desired lean1 with this angle in RAD. Note that onFire has to be set to true for this parameter to take any effect.
- `public float ShoulderLean2 { set; }`
  - Blend writhe shoulder desired lean2 with this angle in RAD. Note that onFire has to be set to true for this parameter to take any effect.

## BraceForImpactHelper

class `GTA.NaturalMotion.BraceForImpactHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public BraceForImpactHelper(Ped ped)`
  - Creates a new Instance of the BraceForImpactHelper for sending a BraceForImpact `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the BraceForImpact `Message` to.

### Properties

- `public bool BbArms { set; }`
  - Use bodyBalance arms for the default (non bracing) behavior if bodyBalance is active.
- `public float BodyStiffness { set; }`
  - Stiffness of character. Catch_fall stiffness scales with this too, with its defaults at this values default.
- `public float BraceDistance { set; }`
  - Distance from object at which to raise hands to brace 0.5 good if newBrace=true - otherwise 0.65.
- `public bool BraceOnImpact { set; }`
  - If true then if a shin or thigh is in contact with the car then brace. NB: newBrace must be true. For those situations where the car has pushed the ped backwards (at the same speed as the car) before the behavior has been started and so doesn't predict an impact.
- `public float DampSpin { set; }`
  - Amount to damp spinning by (cartwheeling and somersaulting).
- `public float DampSpinThresh { set; }`
  - Angular velocity above which we start damping.
- `public float DampUpVel { set; }`
  - Amount to damp upward velocity by to limit the amount of air above the car the character can get.
- `public float DampUpVelThresh { set; }`
  - Upward velocity above which we start damping.
- `public bool DampVel { set; }`
  - Damp out excessive spin and upward velocity when on car.
- `public float GrabDistance { set; }`
  - Relative distance at which the grab starts.
- `public bool GrabDontLetGo { set; }`
  - Once a constraint is made, keep reaching with whatever hand is allowed.
- `public float GrabHoldTimer { set; }`
  - Amount of time, in seconds, before grab automatically bails.
- `public float GrabReachAngle { set; }`
  - Angle from front at which the grab activates. If the point is outside this angle from front will not try to grab.
- `public float GrabStrength { set; }`
  - Strength in hands for grabbing (kg m/s), -1 to ignore/disable.
- `public float GsCarVelMin { set; }`
  - ID for glancing spin. Minimum car velocity.
- `public float GsEndMin { set; }`
  - ID for glancing spin. Min depth to be considered from either end (front/rear) of a car (-ve is inside the car area).
- `public string GsFricMask1 { set; }`
  - Glancing spin help. Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation). Note gsFricMask1 and gsFricMask2 are made independent by the code so you can have fb for gsFricMask1 but gsFricScale1 will not be applied to any body parts in gsFricMask2.
- `public string GsFricMask2 { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation). Note gsFricMask1 and gsFricMask2 are made independent by the code so you can have fb for gsFricMask1 but gsFricScale1 will not be applied to any body parts in gsFricMask2.
- `public float GsFricScale1 { set; }`
  - Glancing spin help. Friction scale applied when to the side of the car. e.g. make the character spin more by upping the friction against the car.
- `public float GsFricScale2 { set; }`
  - Glancing spin help. Friction scale applied when to the side of the car. e.g. make the character spin more by lowering the feet friction. You could also lower the wrist friction here to stop the car pulling along the hands i.e. gsFricMask2 = la|uw.
- `public bool GsHelp { set; }`
  - Enhance a glancing spin with the side of the car by modulating body friction.
- `public bool GsScale1Foot { set; }`
  - Apply gsFricScale1 to the foot if colliding with car. (Otherwise foot friction - with the ground - is determined by gsFricScale2 if it is in gsFricMask2).
- `public float GsSideMax { set; }`
  - ID for glancing spin. Max depth to be considered on the side of a car (+ve is outside the car area).
- `public float GsSideMin { set; }`
  - ID for glancing spin. Min depth to be considered on the side of a car (-ve is inside the car area).
- `public float GsUpness { set; }`
  - ID for glancing spin. Character has to be more upright than this value for it to be considered on the side of a car. Fully upright = 1, upsideDown = -1. Max Angle from upright is acos(gsUpness).
- `public float HandsDelayMax { set; }`
  - If bracing with 2 hands delay one hand by at most this amount of time to introduce some asymmetry.
- `public float HandsDelayMin { set; }`
  - If bracing with 2 hands delay one hand by at least this amount of time to introduce some asymmetry.
- `public int InstanceIndex { set; }`
  - LevelIndex of object to brace.
- `public float LegStiffness { set; }`
  - Balancer leg stiffness mmmmtodo remove this parameter and use configureBalance?.
- `public Vector3 Look { set; }`
  - Position to look at, e.g. the driver.
- `public float MaxGrabCarVelocity { set; }`
  - Don't try to grab a car moving above this speed mmmmtodo make this the relative velocity of car to character?.
- `public float MinBraceTime { set; }`
  - Minimum bracing time so the character doesn't look twitchy.
- `public bool MoveAway { set; }`
  - Move away from the car (if in reaching zone).
- `public float MoveAwayAmount { set; }`
  - ForceLean away amount (-ve is lean towards).
- `public float MoveAwayLean { set; }`
  - Lean away amount (-ve is lean towards).
- `public float MoveSideways { set; }`
  - Amount of sideways movement if at the front or back of the car to add to the move away from car.
- `public bool NewBrace { set; }`
  - Use the new brace prediction code.
- `public Vector3 Pos { set; }`
  - Location of the front part of the object to brace against. This should be the center of where his hands should meet the object.
- `public float ReachAbsorbtionTime { set; }`
  - Larger values and he absorbs the impact more.
- `public bool Roll2Velocity { set; }`
  - When rollDownStairs is running use roll2Velocity to control the helper torques (this only attempts to roll to the chaarcter's velocity not some default linear velocity mag.
- `public int RollType { set; }`
  - 0 = original/roll off/stay on car: Roll with character velocity, 1 = //Gentle: roll off/stay on car = use relative velocity of character to car to roll against, 2 = //roll over car: Roll against character velocity. i.e. roll against any velocity picked up by hitting car, 3 = //Gentle: roll over car: use relative velocity of character to car to roll with.
- `public float SnapBonnet { set; }`
  - Exaggeration amount of the secondary (torso) impact with bonnet. +ve fold with car impact (as if pushed at hips by the impact normal). -ve fold away from car impact.
- `public float SnapFloor { set; }`
  - Exaggeration amount of the impact with the floor after falling off of car +ve fold with floor impact (as if pushed at hips in the impact normal direction). -ve fold away from car impact.
- `public float SnapImpact { set; }`
  - Exaggeration amount of the initial impact (legs). +ve fold with car impact (as if pushed at hips in the car velocity direction). -ve fold away from car impact.
- `public bool SnapImpacts { set; }`
  - Exaggerate impacts using snap.
- `public float TargetPredictionTime { set; }`
  - Time epected to get arms up from idle.
- `public float TimeToBackwardsBrace { set; }`
  - Time before arm brace kicks in when hit from behind.

## BuoyancyHelper

class `GTA.NaturalMotion.BuoyancyHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Simple buoyancy model. No character movement just fluid forces/torques added to parts.

### Constructors

- `public BuoyancyHelper(Ped ped)`
  - Creates a new Instance of the BuoyancyHelper for sending a Buoyancy `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Buoyancy `Message` to.

### Properties

- `public float Buoyancy { set; }`
  - Buoyancy multiplier.
- `public float ChestBuoyancy { set; }`
  - Buoyancy multiplier for spine2/3. Helps character float upright.
- `public float Damping { set; }`
  - Damping for submerged parts.
- `public bool Righting { set; }`
  - Use righting torque to being character face-up in water?.
- `public float RightingStrength { set; }`
  - Strength of righting torque.
- `public float RightingTime { set; }`
  - How long to wait after chest hits water to begin righting torque.
- `public Vector3 SurfaceNormal { set; }`
  - Normal to surface of water.
- `public Vector3 SurfacePoint { set; }`
  - Arbitrary point on surface of water.

## CarriedHelper

class `GTA.NaturalMotion.CarriedHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Carried.

### Constructors

- `public CarriedHelper(Ped ped)`
  - Creates a new Instance of the CarriedHelper for sending a Carried `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Carried `Message` to.

## CatchFallHelper

class `GTA.NaturalMotion.CatchFallHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public CatchFallHelper(Ped ped)`
  - Creates a new Instance of the CatchFallHelper for sending a CatchFall `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the CatchFall `Message` to.

### Properties

- `public float ArmsStiffness { set; }`
  - Stiffness of arms.
- `public float BackwardsMinArmOffset { set; }`
  - 0 will prop arms up near his shoulders. -0.3 will place hands nearer his behind.
- `public float ExtraSit { set; }`
  - Scale extra-sit value 0..1. Setting to 0 helps with arched-back issues. Set to 1 for a more alive-looking finish.
- `public float ForwardMaxArmOffset { set; }`
  - 0 will point arms down with angled body, 0.45 will point arms forward a bit to catch nearer the head.
- `public float LegsStiffness { set; }`
  - Stiffness of legs.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public float TorsoStiffness { set; }`
  - Stiffness of torso.
- `public bool UseHeadLook { set; }`
  - Toggle to use the head look in this behavior.
- `public float ZAxisSpinReduction { set; }`
  - Tries to reduce the spin around the Z axis. Scale 0 - 1.

## ConfigureBalanceHelper

class `GTA.NaturalMotion.ConfigureBalanceHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

This single message allows you to configure various parameters used on any behavior that uses the dynamic balance.

### Constructors

- `public ConfigureBalanceHelper(Ped ped)`
  - Creates a new Instance of the ConfigureBalanceHelper for sending a ConfigureBalance `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureBalance `Message` to.

### Properties

- `public bool AirborneStep { set; }`
  - When airborne try to step. Set to false for e.g. shotGun reaction.
- `public bool AlwaysStepWithFarthest { set; }`
- `public float AnkleEquilibrium { set; }`
  - Ankle equilibrium angle used when static balancing.
- `public float AvoidFeedback { set; }`
  - NB. Very sensitive. Avoid tries to not step across a line of the inside of the stance leg's foot. Avoid doesn't allow the desired stepping foot to cross the line. avoidFeedback = how much of the actual crossing of that line is fedback as an error.
- `public float AvoidFootWidth { set; }`
  - NB. Very sensitive. Avoid tries to not step across a line of the inside of the stance leg's foot. AvoidFootWidth = how much inwards from the ankle this line is in (m).
- `public bool AvoidLeg { set; }`
  - If true then balancer tries to avoid leg2leg collisions/avoid crossing legs. Avoid tries to not step across a line of the inside of the stance leg's foot.
- `public float BackwardsLeanCutoff { set; }`
  - Backwards lean threshold to cut off stay upright forces. 0.0 Vertical - 1.0 horizontal. 0.6 is a sensible value. NB: the balancer does not fail in order to give stagger that extra step as it falls. A backwards lean of GT 0.6 will generally mean the balancer will soon fail without stayUpright forces.
- `public float BalanceAbortThreshold { set; }`
  - When the character gives up and goes into a fall. Larger values mean that the balancer can lean more before failing.
- `public float BalanceAbortThresholdEnd { set; }`
  - If this value is different from balanceAbortThreshold, actual balanceAbortThreshold will be ramped toward this value.
- `public bool BalanceIndefinitely { set; }`
  - Ignore maxSteps and maxBalanceTime and try to balance forever.
- `public float ChangeStepTime { set; }`
  - Time not in contact (airborne) before step is changed. If -ve don't change step.
- `public float DepthFudge { set; }`
  - Supposed to increase foot friction: Impact depth of a collision with the foot is changed when the balancer is running - impact.SetDepth(impact.GetDepth() - depthFudge).
- `public float DepthFudgeStagger { set; }`
  - Supposed to increase foot friction: Impact depth of a collision with the foot is changed when staggerFall is running - impact.SetDepth(impact.GetDepth() - depthFudgeStagger).
- `public float DontStepTime { set; }`
  - Amount of time at the start of a balance before the character is allowed to start stepping.
- `public float ExtraFeetApart { set; }`
  - Additional feet apart setting.
- `public int ExtraSteps { set; }`
  - Allow the balancer to take this many more steps before hitting maxSteps. If negative nothing happens(safe default).
- `public float ExtraTime { set; }`
  - Allow the balancer to balance for this many more seconds before hitting maxBalanceTime. If negative nothing happens(safe default).
- `public bool FailMustCollide { set; }`
  - The upper body of the character must be colliding and other failure conditions met to fail.
- `public float FallMult { set; }`
  - Multiply the rampDown of stiffness on falling by this amount ( GT 1 fall quicker).
- `public bool FallReduceGravityComp { set; }`
  - Reduce gravity compensation as the legs weaken on falling.
- `public FallType FallType { set; }`
  - How to fall after maxSteps or maxBalanceTime.
- `public bool FlatterStaticFeet { set; }`
- `public bool FlatterSwingFeet { set; }`
- `public float FootFriction { set; }`
  - Foot friction multiplier is multiplied by this amount if balancer is running.
- `public float FootFrictionStagger { set; }`
  - Foot friction multiplier is multiplied by this amount if staggerFall is running.
- `public bool FootSlipCompOnMovingFloor { set; }`
  - This parameter will be removed when footSlipCompensation preserves the foot angle on a moving floor]. If the character detects a moving floor and footSlipCompOnMovingFloor is false then it will turn off footSlipCompensation - at footSlipCompensation preserves the global heading of the feet. If footSlipCompensation is off then the character usually turns to the side in the end although when turning the vehicle turns it looks promising for a while.
- `public float GiveUpHeight { set; }`
  - Height between lowest foot and COM below which balancer will give up.
- `public float GiveUpHeightEnd { set; }`
  - If this value is different from giveUpHeight, actual giveUpHeight will be ramped toward this value.
- `public float GiveUpRampDuration { set; }`
  - Duration of ramp from start of behavior for above two parameters. If smaller than 0, no ramp is applied.
- `public float HipLeanAcc { set; }`
  - Multiplier on the floorAcceleration added to the leanHips.
- `public bool IgnoreFailure { set; }`
  - Ignore maxSteps and maxBalanceTime and try to balance forever.
- `public float LeanAcc { set; }`
  - Multiplier on the floorAcceleration added to the lean.
- `public float LeanAccMax { set; }`
  - Max floorAcceleration allowed for lean and leanHips.
- `public float LeanAgainstVelocity { set; }`
- `public float LeanToAbort { set; }`
  - Lean at which to send abort message when maxSteps or maxBalanceTime is reached.
- `public float LeftLegSwingDamping { set; }`
  - Damping of left leg during swing phase (mmmmDrunk used 1.25 to slow legs movement).
- `public float LegsApartMax { set; }`
  - FRICTION WORKAROUND: if the legs end up more than (legsApartMax + hipwidth) apart when balanced, adjust the feet positions to slide back so they are legsApartMax + hipwidth apart. Needs to be less than legsApartRestep to see any effect.
- `public float LegsApartRestep { set; }`
  - If the legs end up more than (legsApartRestep + hipwidth) apart even though balanced, take another step.
- `public float LegStiffness { set; }`
  - Stiffness of legs.
- `public float LegsTogetherRestep { set; }`
  - Mmmm0.1 for drunk if the legs end up less than (hipwidth - legsTogetherRestep) apart even though balanced, take another step. A value of 1 will turn off this feature and the max value is hipWidth = 0.23f by default but is model dependent.
- `public float MaxBalanceTime { set; }`
  - Maximum time(seconds) that the balancer will balance for.
- `public int MaxSteps { set; }`
  - Maximum number of steps that the balancer will take.
- `public float MinKneeAngle { set; }`
  - Minimum knee angle (-ve value will mean this functionality is not applied). 0.4 seems a good value.
- `public bool MovingFloor { set; }`
  - Temporary variable to ignore movingFloor code that generally causes the character to fall over if the feet probe a moving object e.g. treading on a gun.
- `public float OpposeGravityAnkles { set; }`
  - Gravity opposition applied to ankles. General balancer likes 1.0. StaggerFall likes 0.1.
- `public float OpposeGravityLegs { set; }`
  - Gravity opposition applied to hips and knees.
- `public float PredictionTime { set; }`
  - Amount of time (seconds) into the future that the character tries to step to. Bigger values try to recover with fewer, bigger steps. Smaller values recover with smaller steps, and generally recover less.
- `public float PredictionTimeHip { set; }`
  - Amount of time (seconds) into the future that the character tries to move hip to (kind of). Will be controlled by balancer in future but can help recover spine quicker from bending forwards to much.
- `public float PredictionTimeVariance { set; }`
  - Variance in predictionTime every step. If negative only takes away from predictionTime.
- `public bool RampHipPitchOnFail { set; }`
  - Bend over when falling after maxBalanceTime.
- `public float ResistAcc { set; }`
  - Level of cheat force added to character to resist the effect of floorAcceleration (anti-Acceleration) - added to upperbody.
- `public float ResistAccMax { set; }`
  - Max floorAcceleration allowed for anti-Acceleration. If GT 20.0 then it is probably in a crash.
- `public float RightLegSwingDamping { set; }`
  - Damping of right leg during swing phase (mmmmDrunk used 1.25 to slow legs movement).
- `public float StableLinSpeedThresh { set; }`
  - Linear speed threshold for successful balance.
- `public float StableRotSpeedThresh { set; }`
  - Rotational speed threshold for successful balance.
- `public bool StandUp { set; }`
  - Standup more with increased velocity.
- `public float StepClampScale { set; }`
- `public float StepClampScaleVariance { set; }`
  - Variance in clamp scale every step. If negative only takes away from clampScale.
- `public float StepDecisionThreshold { set; }`
- `public float StepHeight { set; }`
  - Maximum height that character steps vertically (above 0.2 is high ... But OK underwater).
- `public float StepHeightInc4Step { set; }`
  - Added to stepHeight if going up steps.
- `public bool StepIfInSupport { set; }`
  - The balancer sometimes decides to step even if balanced.
- `public bool TaperKneeStrength { set; }`
  - Does the knee strength reduce with angle.
- `public float UseComDirTurnVelThresh { set; }`
  - Velocity below which the balancer turns in the direction of the COM forward instead of the ComVel - for use with shot from running with high upright constraint use 1.9.

## ConfigureBalanceResetHelper

class `GTA.NaturalMotion.ConfigureBalanceResetHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Reset the values configurable by the Configure Balance message to their defaults.

### Constructors

- `public ConfigureBalanceResetHelper(Ped ped)`
  - Creates a new Instance of the ConfigureBalanceResetHelper for sending a ConfigureBalanceReset `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureBalanceReset `Message` to.

## ConfigureBulletsExtraHelper

class `GTA.NaturalMotion.ConfigureBulletsExtraHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ConfigureBulletsExtraHelper(Ped ped)`
  - Creates a new Instance of the ConfigureBulletsExtraHelper for sending a ConfigureBulletsExtra `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureBulletsExtra `Message` to.

### Properties

- `public bool CounterAfterMagReached { set; }`
  - Applies the counter impulse counterImpulseDelay(secs) after counterImpulseMag of the Impulse has been applied.
- `public float CounterImpulse2Hips { set; }`
  - Amount of the counter impulse applied to hips - the rest is applied to the part originally hit.
- `public float CounterImpulseDelay { set; }`
  - Time after impulse is applied that counter impulse is applied.
- `public float CounterImpulseMag { set; }`
  - Amount of the original impulse that is countered.
- `public bool DoCounterImpulse { set; }`
  - Add a counter impulse to the pelvis.
- `public float ImpulseAirApplyAbove { set; }`
  - If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
- `public float ImpulseAirMax { set; }`
  - Amount to clamp impulse to if character is airborne and dynamicBalance is OK.
- `public float ImpulseAirMult { set; }`
  - Amount to scale impulse by if the character is airborne and dynamicBalance is OK and impulse is above impulseAirMultStart.
- `public float ImpulseAirMultStart { set; }`
  - If impulse is above this value scale it by impulseAirMult.
- `public bool ImpulseAirOn { set; }`
  - Scale and/or clamp impulse if the character is airborne and dynamicBalance is OK.
- `public float ImpulseBalStabEnd { set; }`
  - 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
- `public float ImpulseBalStabMult { set; }`
  - 100% LE Start to impulseBalStabMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
- `public float ImpulseBalStabStart { set; }`
  - 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
- `public float ImpulseDelay { set; }`
  - Time from hit before impulses are being applied.
- `public float ImpulseNoBalMult { set; }`
  - Amount to scale impulse by if the dynamicBalance is not OK. 1.0 means this functionality is not applied.
- `public float ImpulseOneLegApplyAbove { set; }`
  - If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
- `public float ImpulseOneLegMax { set; }`
  - Amount to clamp impulse to if character is contacting with one foot only and dynamicBalance is OK.
- `public float ImpulseOneLegMult { set; }`
  - Amount to scale impulse by if the character is contacting with one foot only and dynamicBalance is OK and impulse is above impulseAirMultStart.
- `public float ImpulseOneLegMultStart { set; }`
  - If impulse is above this value scale it by impulseOneLegMult.
- `public bool ImpulseOneLegOn { set; }`
  - Scale and/or clamp impulse if the character is contacting with one leg only and dynamicBalance is OK.
- `public float ImpulsePeriod { set; }`
  - Duration that impulse is spread over (triangular shaped).
- `public float ImpulseSpineAngEnd { set; }`
  - 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
- `public float ImpulseSpineAngMult { set; }`
  - 100% GE Start to impulseSpineAngMult*100% LT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
- `public float ImpulseSpineAngStart { set; }`
  - 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
- `public bool ImpulseSpreadOverParts { set; }`
  - Spreads impulse across parts. Currently only for spine parts, not limbs.
- `public float ImpulseTorqueScale { set; }`
  - An impulse applied at a point on a body equivalent to an impulse at the center of the body and a torque. This parameter scales the torque component. (The torque component seems to be excite the rage looseness bug which sends the character in a sometimes wildly different direction to an applied impulse).
- `public float ImpulseVelEnd { set; }`
  - 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
- `public float ImpulseVelMult { set; }`
  - 100% LE Start to impulseVelMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
- `public float ImpulseVelStart { set; }`
  - 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
- `public float LiftGain { set; }`
  - Amount of lift (directly multiplies torque axis to give lift force).
- `public bool LoosenessFix { set; }`
  - Fix the rage looseness bug by applying only the impulse at the center of the body unless it is a spine part then apply the twist component only of the torque as well.
- `public float RbLowerShare { set; }`
  - Rigid body response is shared between the upper and lower body (rbUpperShare = 1-rbLowerShare). RbLowerShare=0.5 gives upper and lower share scaled by mass. i.e. if 70% ub mass and 30% lower mass then rbLowerShare=0.5 gives actualrbShare of 0.7ub and 0.3lb. rbLowerShare GT 0.5 scales the ub share down from 0.7 and the lb up from 0.3.
- `public float RbMaxBroomMomentArm { set; }`
  - Maximum broom((everything but the twist) arm moment of bullet applied.
- `public float RbMaxBroomMomentArmAirborne { set; }`
  - If Airborne: Maximum broom((everything but the twist) arm moment of bullet applied.
- `public float RbMaxBroomMomentArmOneLeg { set; }`
  - If only one leg in contact: Maximum broom((everything but the twist) arm moment of bullet applied.
- `public float RbMaxTwistMomentArm { set; }`
  - Maximum twist arm moment of bullet applied.
- `public float RbMaxTwistMomentArmAirborne { set; }`
  - If Airborne: Maximum twist arm moment of bullet applied.
- `public float RbMaxTwistMomentArmOneLeg { set; }`
  - If only one leg in contact: Maximum twist arm moment of bullet applied.
- `public float RbMoment { set; }`
  - 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
- `public float RbMomentAirborne { set; }`
  - If Airborne: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
- `public float RbMomentOneLeg { set; }`
  - If only one leg in contact: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
- `public bool RbPivot { set; }`
  - If false pivot around COM always, if true change pivot depending on foot contact: to feet center if both feet in contact, or foot position if 1 foot in contact or COM position if no feet in contact.
- `public float RbRatio { set; }`
  - 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
- `public float RbRatioAirborne { set; }`
  - If Airborne: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
- `public float RbRatioOneLeg { set; }`
  - If only one leg in contact: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
- `public RbTwistAxis RbTwistAxis { set; }`
- `public bool TorqueAlwaysSpine3 { set; }`
  - Always apply torques to spine3 instead of actual part hit.
- `public float TorqueCutoff { set; }`
  - Minimum ratio of impulse that remains after converting to torque (if in strength-proportional mode).
- `public float TorqueDelay { set; }`
  - Time from hit before torques are being applied.
- `public TorqueFilterMode TorqueFilterMode { set; }`
- `public float TorqueGain { set; }`
  - Multiplies impulse magnitude to arrive at torque that is applied.
- `public TorqueMode TorqueMode { set; }`
- `public float TorquePeriod { set; }`
  - Duration of torque.
- `public float TorqueReductionPerTick { set; }`
  - Ratio of torque for next tick (e.g. 1.0: not reducing over time, 0.9: each tick torque is reduced by 10%).
- `public TorqueSpinMode TorqueSpinMode { set; }`

## ConfigureBulletsHelper

class `GTA.NaturalMotion.ConfigureBulletsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ConfigureBulletsHelper(Ped ped)`
  - Creates a new Instance of the ConfigureBulletsHelper for sending a ConfigureBullets `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureBullets `Message` to.

### Properties

- `public bool CounterAfterMagReached { set; }`
  - Applies the counter impulse counterImpulseDelay(secs) after counterImpulseMag of the Impulse has been applied.
- `public float CounterImpulse2Hips { set; }`
  - Amount of the counter impulse applied to hips - the rest is applied to the part originally hit.
- `public float CounterImpulseDelay { set; }`
  - Time after impulse is applied that counter impulse is applied.
- `public float CounterImpulseMag { set; }`
  - Amount of the original impulse that is countered.
- `public bool DoCounterImpulse { set; }`
  - Add a counter impulse to the pelvis.
- `public float ImpulseAirApplyAbove { set; }`
  - If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
- `public float ImpulseAirMax { set; }`
  - Amount to clamp impulse to if character is airborne and dynamicBalance is OK.
- `public float ImpulseAirMult { set; }`
  - Amount to scale impulse by if the character is airborne and dynamicBalance is OK and impulse is above impulseAirMultStart.
- `public float ImpulseAirMultStart { set; }`
  - If impulse is above this value scale it by impulseAirMult.
- `public bool ImpulseAirOn { set; }`
  - Scale and/or clamp impulse if the character is airborne and dynamicBalance is OK.
- `public float ImpulseBalStabEnd { set; }`
  - 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
- `public float ImpulseBalStabMult { set; }`
  - 100% LE Start to impulseBalStabMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
- `public float ImpulseBalStabStart { set; }`
  - 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
- `public float ImpulseDelay { set; }`
  - Time from hit before impulses are being applied.
- `public bool ImpulseLeakageStrengthScaled { set; }`
  - For weaker characters subsequent impulses remain strong.
- `public float ImpulseMinLeakage { set; }`
  - The minimum amount of impulse leakage allowed.
- `public float ImpulseNoBalMult { set; }`
  - Amount to scale impulse by if the dynamicBalance is not OK. 1.0 means this functionality is not applied.
- `public float ImpulseOneLegApplyAbove { set; }`
  - If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
- `public float ImpulseOneLegMax { set; }`
  - Amount to clamp impulse to if character is contacting with one foot only and dynamicBalance is OK.
- `public float ImpulseOneLegMult { set; }`
  - Amount to scale impulse by if the character is contacting with one foot only and dynamicBalance is OK and impulse is above impulseAirMultStart.
- `public float ImpulseOneLegMultStart { set; }`
  - If impulse is above this value scale it by impulseOneLegMult.
- `public bool ImpulseOneLegOn { set; }`
  - Scale and/or clamp impulse if the character is contacting with one leg only and dynamicBalance is OK.
- `public float ImpulsePeriod { set; }`
  - Duration that impulse is spread over (triangular shaped).
- `public float ImpulseRecovery { set; }`
  - Recovery rate of impulse strength per second (impulse strength from 0.0:1.0). At 60fps a impulseRecovery=60.0 will recover in 1 frame.
- `public float ImpulseReductionPerShot { set; }`
  - By how much are subsequent impulses reduced (e.g. 0.0: no reduction, 0.1: 10% reduction each new hit).
- `public float ImpulseSpineAngEnd { set; }`
  - 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
- `public float ImpulseSpineAngMult { set; }`
  - 100% GE Start to impulseSpineAngMult*100% LT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
- `public float ImpulseSpineAngStart { set; }`
  - 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
- `public bool ImpulseSpreadOverParts { set; }`
  - Spreads impulse across parts. Currently only for spine parts, not limbs.
- `public float ImpulseTorqueScale { set; }`
  - An impulse applied at a point on a body equivalent to an impulse at the center of the body and a torque. This parameter scales the torque component. (The torque component seems to be excite the rage looseness bug which sends the character in a sometimes wildly different direction to an applied impulse).
- `public float ImpulseVelEnd { set; }`
  - 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
- `public float ImpulseVelMult { set; }`
  - 100% LE Start to impulseVelMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
- `public float ImpulseVelStart { set; }`
  - 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
- `public float LiftGain { set; }`
  - Amount of lift (directly multiplies torque axis to give lift force).
- `public bool LoosenessFix { set; }`
  - Fix the rage looseness bug by applying only the impulse at the center of the body unless it is a spine part then apply the twist component only of the torque as well.
- `public float RbLowerShare { set; }`
  - Rigid body response is shared between the upper and lower body (rbUpperShare = 1-rbLowerShare). RbLowerShare=0.5 gives upper and lower share scaled by mass. i.e. if 70% ub mass and 30% lower mass then rbLowerShare=0.5 gives actualrbShare of 0.7ub and 0.3lb. rbLowerShare GT 0.5 scales the ub share down from 0.7 and the lb up from 0.3.
- `public float RbMaxBroomMomentArm { set; }`
  - Maximum broom((everything but the twist) arm moment of bullet applied.
- `public float RbMaxBroomMomentArmAirborne { set; }`
  - If Airborne: Maximum broom((everything but the twist) arm moment of bullet applied.
- `public float RbMaxBroomMomentArmOneLeg { set; }`
  - If only one leg in contact: Maximum broom((everything but the twist) arm moment of bullet applied.
- `public float RbMaxTwistMomentArm { set; }`
  - Maximum twist arm moment of bullet applied.
- `public float RbMaxTwistMomentArmAirborne { set; }`
  - If Airborne: Maximum twist arm moment of bullet applied.
- `public float RbMaxTwistMomentArmOneLeg { set; }`
  - If only one leg in contact: Maximum twist arm moment of bullet applied.
- `public float RbMoment { set; }`
  - 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
- `public float RbMomentAirborne { set; }`
  - If Airborne: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
- `public float RbMomentOneLeg { set; }`
  - If only one leg in contact: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
- `public bool RbPivot { set; }`
  - If false pivot around COM always, if true change pivot depending on foot contact: to feet center if both feet in contact, or foot position if 1 foot in contact or COM position if no feet in contact.
- `public float RbRatio { set; }`
  - 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
- `public float RbRatioAirborne { set; }`
  - If Airborne: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
- `public float RbRatioOneLeg { set; }`
  - If only one leg in contact: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
- `public RbTwistAxis RbTwistAxis { set; }`
- `public bool TorqueAlwaysSpine3 { set; }`
  - Always apply torques to spine3 instead of actual part hit.
- `public float TorqueCutoff { set; }`
  - Minimum ratio of impulse that remains after converting to torque (if in strength-proportional mode).
- `public float TorqueDelay { set; }`
  - Time from hit before torques are being applied.
- `public TorqueFilterMode TorqueFilterMode { set; }`
- `public float TorqueGain { set; }`
  - Multiplies impulse magnitude to arrive at torque that is applied.
- `public TorqueMode TorqueMode { set; }`
- `public float TorquePeriod { set; }`
  - Duration of torque.
- `public float TorqueReductionPerTick { set; }`
  - Ratio of torque for next tick (e.g. 1.0: not reducing over time, 0.9: each tick torque is reduced by 10%).
- `public TorqueSpinMode TorqueSpinMode { set; }`

## ConfigureConstraintsHelper

class `GTA.NaturalMotion.ConfigureConstraintsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

One shot to give state of constraints on character and response to constraints.

### Constructors

- `public ConfigureConstraintsHelper(Ped ped)`
  - Creates a new Instance of the ConfigureConstraintsHelper for sending a ConfigureConstraints `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureConstraints `Message` to.

### Properties

- `public bool BespokeBehavior { set; }`
  - Not implemented.
- `public float Blend2ZeroPose { set; }`
  - Blend Arms to zero pose.
- `public bool HandCuffs { set; }`
- `public bool HandCuffsBehindBack { set; }`
  - Not implemented.
- `public bool LegCuffs { set; }`
  - Not implemented.
- `public int PassiveMode { set; }`
  - 0 setCurrent, 1= IK to dominant, (2=pointGunLikeIK //not implemented).
- `public bool RightDominant { set; }`

## ConfigureLimitsHelper

class `GTA.NaturalMotion.ConfigureLimitsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Enable/disable/edit character limits in real time. This adjusts limits in RAGE-native space and will *not* reorient the joint.

### Constructors

- `public ConfigureLimitsHelper(Ped ped)`
  - Creates a new Instance of the ConfigureLimitsHelper for sending a ConfigureLimits `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureLimits `Message` to.

### Properties

- `public bool Enable { set; }`
  - If false, disable (set all to PI, -PI) limits.
- `public int Index { set; }`
  - Index of effector to configure. Set to -1 to use mask.
- `public float Lean1 { set; }`
  - Custom limit values to use if not setting limits to desired. Limits are RAGE-native, not NM-wrapper-native.
- `public float Lean2 { set; }`
- `public float Margin { set; }`
  - Joint limit margin to add to current animation limits when using those to set runtime limits.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value for joint limits to configure. Ignored if index != -1.
- `public bool Restore { set; }`
  - Return to cached defaults?.
- `public bool ToCurAnimation { set; }`
  - If true, set limits to the current animated limits.
- `public bool ToDesired { set; }`
  - If true, set limits to accommodate current desired angles.
- `public float Twist { set; }`

## ConfigureSelfAvoidanceHelper

class `GTA.NaturalMotion.ConfigureSelfAvoidanceHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

This single message allows to configure self avoidance for the character.BBDD Self avoidance tech.

### Constructors

- `public ConfigureSelfAvoidanceHelper(Ped ped)`
  - Creates a new Instance of the ConfigureSelfAvoidanceHelper for sending a ConfigureSelfAvoidance `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureSelfAvoidance `Message` to.

### Properties

- `public float MaxTorsoSwingAngleRad { set; }`
  - Max value on the effector (wrist) to adjusted target offset.
- `public bool OverwriteDragReduction { set; }`
  - Specify whether self avoidance tech should use original IK input target or the target that has been already modified by getStabilisedPos() tech i.e. function that compensates for rotational and linear velocity of shoulder/thigh.
- `public bool OverwriteTwist { set; }`
  - Overwrite desired IK twist with self avoidance procedural twist.
- `public float Radius { set; }`
  - Self avoidance radius, measured out from the spine axis along the plane perpendicular to that axis. The closer is the proximity of reaching target to that radius, the more polar (curved) motion is used for offsetting the target. WARNING: Parameter only used by the alternative algorithm that is based on linear and polar target blending.
- `public float SelfAvoidAmount { set; }`
  - Amount of self avoidance offset applied when angle from effector (wrist) to target is greater then right angle i.e. when total offset is a blend between where effector currently is to value that is a product of total arm length and selfAvoidAmount. SelfAvoidAmount is in a range between [0, 1].
- `public bool SelfAvoidIfInSpineBoundsOnly { set; }`
  - Restrict self avoidance to operate on targets that are within character torso bounds only.
- `public float TorsoSwingFraction { set; }`
  - Place the adjusted target this much along the arc between effector (wrist) and target, value in range [0,1].
- `public bool UsePolarPathAlgorithm { set; }`
  - Use the alternative self avoidance algorithm that is based on linear and polar target blending. WARNING: It only requires "radius" in terms of parametrization.
- `public bool UseSelfAvoidance { set; }`
  - Enable or disable self avoidance tech.

## ConfigureShotInjuredArmHelper

class `GTA.NaturalMotion.ConfigureShotInjuredArmHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

This single message allows you to configure the injured arm reaction during shot.

### Constructors

- `public ConfigureShotInjuredArmHelper(Ped ped)`
  - Creates a new Instance of the ConfigureShotInjuredArmHelper for sending a ConfigureShotInjuredArm `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureShotInjuredArm `Message` to.

### Properties

- `public bool ForceStep { set; }`
  - Force a step to be taken whether pushed out of balance or not.
- `public float ForceStepExtraHeight { set; }`
  - Additional height added to stepping foot.
- `public float HipRoll { set; }`
  - Amount of hip roll.
- `public float HipYaw { set; }`
  - Amount of hip twist. (Negative values twist into bullet direction - probably not what is wanted).
- `public float InjuredArmTime { set; }`
  - Length of the reaction.
- `public bool StepTurn { set; }`
  - Turn the character using the balancer.
- `public float VelForceStep { set; }`
  - Velocity above which a step is not forced.
- `public float VelMultiplierEnd { set; }`
  - End velocity of ramp where parameters are scaled to zero.
- `public float VelMultiplierStart { set; }`
  - Start velocity where parameters begin to be ramped down to zero linearly.
- `public bool VelScales { set; }`
  - Use the velocity scaling parameters. Tune for standing still then use velocity scaling to make sure a running character stays balanced (the turning tends to make the character fall over more at speed).
- `public float VelStepTurn { set; }`
  - Velocity above which a stepTurn is not asked for.

## ConfigureShotInjuredLegHelper

class `GTA.NaturalMotion.ConfigureShotInjuredLegHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

This single message allows you to configure the injured leg reaction during shot.

### Constructors

- `public ConfigureShotInjuredLegHelper(Ped ped)`
  - Creates a new Instance of the ConfigureShotInjuredLegHelper for sending a ConfigureShotInjuredLeg `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureShotInjuredLeg `Message` to.

### Properties

- `public bool LegForceStep { set; }`
  - Force a step to be taken whether pushed out of balance or not.
- `public float LegInjury { set; }`
  - Leg injury - leg strength is reduced.
- `public float LegInjuryHipPitch { set; }`
  - Leg injury bend forwards amount when not lifting leg.
- `public float LegInjuryLiftHipPitch { set; }`
  - Leg injury bend forwards amount when lifting leg. (Lifting happens when not stepping with other leg).
- `public float LegInjuryLiftSpineBend { set; }`
  - Leg injury bend forwards amount when lifting leg. (Lifting happens when not stepping with other leg).
- `public float LegInjurySpineBend { set; }`
  - Leg injury bend forwards amount when not lifting leg.
- `public float LegInjuryTime { set; }`
  - Leg injury duration (reaction to being shot in leg).
- `public float LegLiftTime { set; }`
  - Leg lift duration (reaction to being shot in leg). (Lifting happens when not stepping with other leg).
- `public float LegLimpBend { set; }`
  - Bend the legs via the balancer by this amount if stepping on the injured leg. 0.2 seems a good default.
- `public float TimeBeforeCollapseWoundLeg { set; }`
  - Time before a wounded leg is set to be weak and cause the character to collapse.

## ConfigureSoftLimitHelper

class `GTA.NaturalMotion.ConfigureSoftLimitHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ConfigureSoftLimitHelper(Ped ped)`
  - Creates a new Instance of the ConfigureSoftLimitHelper for sending a ConfigureSoftLimit `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ConfigureSoftLimit `Message` to.

### Properties

- `public int ApproachDirection { set; }`
  - Limit angle can be measured relatively to joints hard limit minAngle or maxAngle. Set it to +1 to measure soft limit angle relatively to hard limit minAngle that corresponds to the maximum stretch of the elbow. Set it to -1 to measure soft limit angle relatively to hard limit maxAngle that corresponds to the maximum stretch of the knee.
- `public float Damping { set; }`
  - Damping of the soft limit. Parameter is used to calculate damper term that contributes to the desired acceleration. To have the system critically dampened set it to 1.0.
- `public int Index { set; }`
  - Select limb that the soft limit is going to be applied to.
- `public float LimitAngle { set; }`
  - Soft limit angle. Positive angle in RAD, measured relatively either from hard limit maxAngle (approach direction = -1) or minAngle (approach direction = 1). This angle will be clamped if outside the joint hard limit range.
- `public float Stiffness { set; }`
  - Stiffness of the soft limit. Parameter is used to calculate spring term that contributes to the desired acceleration.
- `public bool VelocityScaled { set; }`
  - Scale stiffness based on character angular velocity.

## CustomHelper

abstract class `GTA.NaturalMotion.CustomHelper` : `Message`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

A helper class for building a `Message` and sending it to a given `Ped`.

### Constructors

- `protected CustomHelper(Ped target, string message)`
  - Creates a helper class for building Natural Motion messages to send to a given `Ped`.
  - `target`: The `Ped` that the message will be applied to.
  - `message`: The name of the natural motion message.

### Methods

- `public void Abort()`
- `public void Start()`
  - Starts this Natural Motion behavior on the `Ped` that will loop until manually aborted.
- `public void Start(int duration)`
  - Starts this Natural Motion behavior on the `Ped` for a specified duration.
  - `duration`: How long to apply the behavior for (-1 for looped).
- `public void Stop()`
  - Stops this Natural Motion behavior on the `Ped`.

## DangleHelper

class `GTA.NaturalMotion.DangleHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Dangle.

### Constructors

- `public DangleHelper(Ped ped)`
  - Creates a new Instance of the DangleHelper for sending a Dangle `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Dangle `Message` to.

### Properties

- `public bool DoGrab { set; }`
- `public float GrabFrequency { set; }`

## DefineAttachedObjectHelper

class `GTA.NaturalMotion.DefineAttachedObjectHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public DefineAttachedObjectHelper(Ped ped)`
  - Creates a new Instance of the DefineAttachedObjectHelper for sending a DefineAttachedObject `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the DefineAttachedObject `Message` to.

### Properties

- `public float ObjectMass { set; }`
  - Mass of the attached object.
- `public int PartIndex { set; }`
  - Index of part to attach to.
- `public Vector3 WorldPos { set; }`
  - World position of attached object's center of mass. Must be updated each frame.

## ElectrocuteHelper

class `GTA.NaturalMotion.ElectrocuteHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ElectrocuteHelper(Ped ped)`
  - Creates a new Instance of the ElectrocuteHelper for sending a Electrocute `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Electrocute `Message` to.

### Properties

- `public float AirborneMult { set; }`
  - AirborneMult*stunMag = The magnitude of the reaction if airborne.
- `public bool ApplyStiffness { set; }`
  - Let electrocute apply a (higher generally) stiffness to the character whilst being vibrated.
- `public float BalancingMult { set; }`
  - BalancingMult*stunMag = The magnitude of the reaction if balancing = (not lying on the floor/ not upper body not collided) and not airborne.
- `public float DirectionRandomness { set; }`
  - The character vibrates in a prescribed way - Higher the value the more random this direction is.
- `public int HipType { set; }`
  - Type of hip reaction 0=none, 1=side2side 2=steplike.
- `public float InitialMult { set; }`
  - InitialMult*stunMag = The magnitude of the 1st snap reaction (other multipliers are applied after this).
- `public float LargeMaxTime { set; }`
  - Max time to next large random snap (about 28 snaps with stunInterval = 0.07s).
- `public float LargeMinTime { set; }`
  - Min time to next large random snap (about 14 snaps with stunInterval = 0.07s).
- `public float LargeMult { set; }`
  - LargeMult*stunMag = The magnitude of a random large snap reaction (other multipliers are applied after this).
- `public bool LeftArm { set; }`
  - Vibrate the leftArm.
- `public bool LeftLeg { set; }`
  - Vibrate the leftLeg.
- `public float MovingMult { set; }`
  - MovingMult*stunMag = The magnitude of the reaction if moving(comVelMag) faster than movingThresh.
- `public float MovingThresh { set; }`
  - If moving(comVelMag) faster than movingThresh then mvingMult applied to stunMag.
- `public bool Neck { set; }`
  - Vibrate the neck.
- `public bool PhasedLegs { set; }`
  - Legs are either in phase with each other or not.
- `public bool RightArm { set; }`
  - Vibrate the rightArm.
- `public bool RightLeg { set; }`
  - Vibrate the rightLeg.
- `public bool Spine { set; }`
  - Vibrate the spine.
- `public float StunInterval { set; }`
  - Direction flips every stunInterval.
- `public float StunMag { set; }`
  - The magnitude of the reaction.
- `public bool UseTorques { set; }`
  - Use torques to make vibration otherwise use a change in the parts angular velocity.

## Euphoria

class `GTA.NaturalMotion.Euphoria`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public ActivePoseHelper ActivePose { get; }`
  - Gets a ActivePose Helper class for sending ActivePose `Message` to this `Ped`.
- `public AnimPoseHelper AnimPose { get; }`
  - Gets a AnimPose Helper class for sending AnimPose `Message` to this `Ped`.
- `public ApplyBulletImpulseHelper ApplyBulletImpulse { get; }`
  - Gets a ApplyBulletImpulse Helper class for sending ApplyBulletImpulse `Message` to this `Ped`.
- `public ApplyImpulseHelper ApplyImpulse { get; }`
  - Gets a ApplyImpulse Helper class for sending ApplyImpulse `Message` to this `Ped`.
- `public ArmsWindmillHelper ArmsWindmill { get; }`
  - Gets a ArmsWindmill Helper class for sending ArmsWindmill `Message` to this `Ped`.
- `public ArmsWindmillAdaptiveHelper ArmsWindmillAdaptive { get; }`
  - Gets a ArmsWindmillAdaptive Helper class for sending ArmsWindmillAdaptive `Message` to this `Ped`.
- `public BalancerCollisionsReactionHelper BalancerCollisionsReaction { get; }`
  - Gets a BalancerCollisionsReaction Helper class for sending BalancerCollisionsReaction `Message` to this `Ped`.
- `public BodyBalanceHelper BodyBalance { get; }`
  - Gets a BodyBalance Helper class for sending BodyBalance `Message` to this `Ped`.
- `public BodyFoetalHelper BodyFoetal { get; }`
  - Gets a BodyFoetal Helper class for sending BodyFoetal `Message` to this `Ped`.
- `public BodyRelaxHelper BodyRelax { get; }`
  - Gets a BodyRelax Helper class for sending BodyRelax `Message` to this `Ped`.
- `public BodyRollUpHelper BodyRollUp { get; }`
  - Gets a BodyRollUp Helper class for sending BodyRollUp `Message` to this `Ped`.
- `public BodyWritheHelper BodyWrithe { get; }`
  - Gets a BodyWrithe Helper class for sending BodyWrithe `Message` to this `Ped`.
- `public BraceForImpactHelper BraceForImpact { get; }`
  - Gets a BraceForImpact Helper class for sending BraceForImpact `Message` to this `Ped`.
- `public BuoyancyHelper Buoyancy { get; }`
  - Gets a Buoyancy Helper class for sending Buoyancy `Message` to this `Ped`.
- `public CarriedHelper Carried { get; }`
  - Gets a Carried Helper class for sending Carried `Message` to this `Ped`.
- `public CatchFallHelper CatchFall { get; }`
  - Gets a CatchFall Helper class for sending CatchFall `Message` to this `Ped`.
- `public ConfigureBalanceHelper ConfigureBalance { get; }`
  - Gets a ConfigureBalance Helper class for sending ConfigureBalance `Message` to this `Ped`.
- `public ConfigureBalanceResetHelper ConfigureBalanceReset { get; }`
  - Gets a ConfigureBalanceReset Helper class for sending ConfigureBalanceReset `Message` to this `Ped`.
- `public ConfigureBulletsHelper ConfigureBullets { get; }`
  - Gets a ConfigureBullets Helper class for sending ConfigureBullets `Message` to this `Ped`.
- `public ConfigureBulletsExtraHelper ConfigureBulletsExtra { get; }`
  - Gets a ConfigureBulletsExtra Helper class for sending ConfigureBulletsExtra `Message` to this `Ped`.
- `public ConfigureConstraintsHelper ConfigureConstraints { get; }`
  - Gets a ConfigureConstraints Helper class for sending ConfigureConstraints `Message` to this `Ped`.
- `public ConfigureLimitsHelper ConfigureLimits { get; }`
  - Gets a ConfigureLimits Helper class for sending ConfigureLimits `Message` to this `Ped`.
- `public ConfigureSelfAvoidanceHelper ConfigureSelfAvoidance { get; }`
  - Gets a ConfigureSelfAvoidance Helper class for sending ConfigureSelfAvoidance `Message` to this `Ped`.
- `public ConfigureShotInjuredArmHelper ConfigureShotInjuredArm { get; }`
  - Gets a ConfigureShotInjuredArm Helper class for sending ConfigureShotInjuredArm `Message` to this `Ped`.
- `public ConfigureShotInjuredLegHelper ConfigureShotInjuredLeg { get; }`
  - Gets a ConfigureShotInjuredLeg Helper class for sending ConfigureShotInjuredLeg `Message` to this `Ped`.
- `public ConfigureSoftLimitHelper ConfigureSoftLimit { get; }`
  - Gets a ConfigureSoftLimit Helper class for sending ConfigureSoftLimit `Message` to this `Ped`.
- `public DangleHelper Dangle { get; }`
  - Gets a Dangle Helper class for sending Dangle `Message` to this `Ped`.
- `public DefineAttachedObjectHelper DefineAttachedObject { get; }`
  - Gets a DefineAttachedObject Helper class for sending DefineAttachedObject `Message` to this `Ped`.
- `public ElectrocuteHelper Electrocute { get; }`
  - Gets a Electrocute Helper class for sending Electrocute `Message` to this `Ped`.
- `public FallOverWallHelper FallOverWall { get; }`
  - Gets a FallOverWall Helper class for sending FallOverWall `Message` to this `Ped`.
- `public FireWeaponHelper FireWeapon { get; }`
  - Gets a FireWeapon Helper class for sending FireWeapon `Message` to this `Ped`.
- `public ForceLeanInDirectionHelper ForceLeanInDirection { get; }`
  - Gets a ForceLeanInDirection Helper class for sending ForceLeanInDirection `Message` to this `Ped`.
- `public ForceLeanRandomHelper ForceLeanRandom { get; }`
  - Gets a ForceLeanRandom Helper class for sending ForceLeanRandom `Message` to this `Ped`.
- `public ForceLeanToPositionHelper ForceLeanToPosition { get; }`
  - Gets a ForceLeanToPosition Helper class for sending ForceLeanToPosition `Message` to this `Ped`.
- `public ForceLeanTowardsObjectHelper ForceLeanTowardsObject { get; }`
  - Gets a ForceLeanTowardsObject Helper class for sending ForceLeanTowardsObject `Message` to this `Ped`.
- `public ForceToBodyPartHelper ForceToBodyPart { get; }`
  - Gets a ForceToBodyPart Helper class for sending ForceToBodyPart `Message` to this `Ped`.
- `public GrabHelper Grab { get; }`
  - Gets a Grab Helper class for sending Grab `Message` to this `Ped`.
- `public HeadLookHelper HeadLook { get; }`
  - Gets a HeadLook Helper class for sending HeadLook `Message` to this `Ped`.
- `public HighFallHelper HighFall { get; }`
  - Gets a HighFall Helper class for sending HighFall `Message` to this `Ped`.
- `public HipsLeanInDirectionHelper HipsLeanInDirection { get; }`
  - Gets a HipsLeanInDirection Helper class for sending HipsLeanInDirection `Message` to this `Ped`.
- `public HipsLeanRandomHelper HipsLeanRandom { get; }`
  - Gets a HipsLeanRandom Helper class for sending HipsLeanRandom `Message` to this `Ped`.
- `public HipsLeanToPositionHelper HipsLeanToPosition { get; }`
  - Gets a HipsLeanToPosition Helper class for sending HipsLeanToPosition `Message` to this `Ped`.
- `public HipsLeanTowardsObjectHelper HipsLeanTowardsObject { get; }`
  - Gets a HipsLeanTowardsObject Helper class for sending HipsLeanTowardsObject `Message` to this `Ped`.
- `public IncomingTransformsHelper IncomingTransforms { get; }`
  - Gets a IncomingTransforms Helper class for sending IncomingTransforms `Message` to this `Ped`.
- `public InjuredOnGroundHelper InjuredOnGround { get; }`
  - Gets a InjuredOnGround Helper class for sending InjuredOnGround `Message` to this `Ped`.
- `public LeanInDirectionHelper LeanInDirection { get; }`
  - Gets a LeanInDirection Helper class for sending LeanInDirection `Message` to this `Ped`.
- `public LeanRandomHelper LeanRandom { get; }`
  - Gets a LeanRandom Helper class for sending LeanRandom `Message` to this `Ped`.
- `public LeanToPositionHelper LeanToPosition { get; }`
  - Gets a LeanToPosition Helper class for sending LeanToPosition `Message` to this `Ped`.
- `public LeanTowardsObjectHelper LeanTowardsObject { get; }`
  - Gets a LeanTowardsObject Helper class for sending LeanTowardsObject `Message` to this `Ped`.
- `public OnFireHelper OnFire { get; }`
  - Gets a OnFire Helper class for sending OnFire `Message` to this `Ped`.
- `public PedalLegsHelper PedalLegs { get; }`
  - Gets a PedalLegs Helper class for sending PedalLegs `Message` to this `Ped`.
- `public PointArmHelper PointArm { get; }`
  - Gets a PointArm Helper class for sending PointArm `Message` to this `Ped`.
- `public PointGunHelper PointGun { get; }`
  - Gets a PointGun Helper class for sending PointGun `Message` to this `Ped`.
- `public PointGunExtraHelper PointGunExtra { get; }`
  - Gets a PointGunExtra Helper class for sending PointGunExtra `Message` to this `Ped`.
- `public RegisterWeaponHelper RegisterWeapon { get; }`
  - Gets a RegisterWeapon Helper class for sending RegisterWeapon `Message` to this `Ped`.
- `public RollDownStairsHelper RollDownStairs { get; }`
  - Gets a RollDownStairs Helper class for sending RollDownStairs `Message` to this `Ped`.
- `public SetCharacterCollisionsHelper SetCharacterCollisions { get; }`
  - Gets a SetCharacterCollisions Helper class for sending SetCharacterCollisions `Message` to this `Ped`.
- `public SetCharacterDampingHelper SetCharacterDamping { get; }`
  - Gets a SetCharacterDamping Helper class for sending SetCharacterDamping `Message` to this `Ped`.
- `public SetCharacterHealthHelper SetCharacterHealth { get; }`
  - Gets a SetCharacterHealth Helper class for sending SetCharacterHealth `Message` to this `Ped`.
- `public SetCharacterStrengthHelper SetCharacterStrength { get; }`
  - Gets a SetCharacterStrength Helper class for sending SetCharacterStrength `Message` to this `Ped`.
- `public SetCharacterUnderwaterHelper SetCharacterUnderwater { get; }`
  - Gets a SetCharacterUnderwater Helper class for sending SetCharacterUnderwater `Message` to this `Ped`.
- `public SetFallingReactionHelper SetFallingReaction { get; }`
  - Gets a SetFallingReaction Helper class for sending SetFallingReaction `Message` to this `Ped`.
- `public SetFrictionScaleHelper SetFrictionScale { get; }`
  - Gets a SetFrictionScale Helper class for sending SetFrictionScale `Message` to this `Ped`.
- `public SetMuscleStiffnessHelper SetMuscleStiffness { get; }`
  - Gets a SetMuscleStiffness Helper class for sending SetMuscleStiffness `Message` to this `Ped`.
- `public SetStiffnessHelper SetStiffness { get; }`
  - Gets a SetStiffness Helper class for sending SetStiffness `Message` to this `Ped`.
- `public SetWeaponModeHelper SetWeaponMode { get; }`
  - Gets a SetWeaponMode Helper class for sending SetWeaponMode `Message` to this `Ped`.
- `public ShotHelper Shot { get; }`
  - Gets a Shot Helper class for sending Shot `Message` to this `Ped`.
- `public ShotConfigureArmsHelper ShotConfigureArms { get; }`
  - Gets a ShotConfigureArms Helper class for sending ShotConfigureArms `Message` to this `Ped`.
- `public ShotFallToKneesHelper ShotFallToKnees { get; }`
  - Gets a ShotFallToKnees Helper class for sending ShotFallToKnees `Message` to this `Ped`.
- `public ShotFromBehindHelper ShotFromBehind { get; }`
  - Gets a ShotFromBehind Helper class for sending ShotFromBehind `Message` to this `Ped`.
- `public ShotHeadLookHelper ShotHeadLook { get; }`
  - Gets a ShotHeadLook Helper class for sending ShotHeadLook `Message` to this `Ped`.
- `public ShotInGutsHelper ShotInGuts { get; }`
  - Gets a ShotInGuts Helper class for sending ShotInGuts `Message` to this `Ped`.
- `public ShotNewBulletHelper ShotNewBullet { get; }`
  - Gets a ShotNewBullet Helper class for sending ShotNewBullet `Message` to this `Ped`.
- `public ShotRelaxHelper ShotRelax { get; }`
  - Gets a ShotRelax Helper class for sending ShotRelax `Message` to this `Ped`.
- `public ShotShockSpinHelper ShotShockSpin { get; }`
  - Gets a ShotShockSpin Helper class for sending ShotShockSpin `Message` to this `Ped`.
- `public ShotSnapHelper ShotSnap { get; }`
  - Gets a ShotSnap Helper class for sending ShotSnap `Message` to this `Ped`.
- `public SmartFallHelper SmartFall { get; }`
  - Gets a SmartFall Helper class for sending SmartFall `Message` to this `Ped`.
- `public StaggerFallHelper StaggerFall { get; }`
  - Gets a StaggerFall Helper class for sending StaggerFall `Message` to this `Ped`.
- `public StayUprightHelper StayUpright { get; }`
  - Gets a StayUpright Helper class for sending StayUpright `Message` to this `Ped`.
- `public StopAllBehavioursHelper StopAllBehaviours { get; }`
  - Gets a StopAllBehaviors Helper class for sending StopAllBehaviors `Message` to this `Ped`.
- `public TeeterHelper Teeter { get; }`
  - Gets a Teeter Helper class for sending Teeter `Message` to this `Ped`.
- `public UpperBodyFlinchHelper UpperBodyFlinch { get; }`
  - Gets a UpperBodyFlinch Helper class for sending UpperBodyFlinch `Message` to this `Ped`.
- `public YankedHelper Yanked { get; }`
  - Gets a Yanked Helper class for sending Yanked `Message` to this `Ped`.

## FallOverWallHelper

class `GTA.NaturalMotion.FallOverWallHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public FallOverWallHelper(Ped ped)`
  - Creates a new Instance of the FallOverWallHelper for sending a FallOverWall `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the FallOverWall `Message` to.

### Properties

- `public bool AdaptForcesToLowWall { set; }`
  - Will reduce the magnitude of the forces applied to the character to help him to fall over wall.
- `public float AngleDirWithWallNormal { set; }`
  - Maximum angle in degrees (between the direction of the velocity of the COM and the wall normal) to start to apply forces and torques to fall over the wall.
- `public float AngleTotallyBack { set; }`
  - Max angle in degrees (between 1.the vector between two hips and 2. WallEdge) to try to reach the wall just behind his pelvis with his arms when the character is back to the wall.
- `public bool BendSpine { set; }`
  - Bend spine to help falloverwall if true. Do nothing with the spine if false.
- `public float BodyStiffness { set; }`
  - Stiffness of the body, roll up stiffness scales with this and defaults at this default value.
- `public float BodyTwist { set; }`
  - Amount of twist to apply to the spine as the character tries to fling himself over the wall, provides more of a believable roll but increases the amount of lateral space the character needs to successfully flip.
- `public float Damping { set; }`
  - Damping in the effectors.
- `public float DistanceToSendSuccessMessage { set; }`
  - Minimum distance between the pelvis and the wall to send the success message. If negative doesn't take this parameter into account when sending feedback.
- `public Vector3 FallOverWallEndA { set; }`
  - One end of the wall to try to fall over.
- `public Vector3 FallOverWallEndB { set; }`
  - One end of the wall over which we are trying to fall over.
- `public float ForceAngleAbort { set; }`
  - The angle abort threshold.
- `public float ForceTimeOut { set; }`
  - The force time out.
- `public float LeaningAngleThreshold { set; }`
  - Maximum angle in degrees (between the vertical vector and a vector from pelvis to lower neck) to start to apply forces and torques to fall over the wall.
- `public float MagOfForce { set; }`
  - Magnitude of the falloverWall helper force.
- `public float MaxAngVel { set; }`
  - If the angular velocity is higher than maxAngVel, the torques and forces are not applied.
- `public float MaxDistanceFromPelToHitPoint { set; }`
  - The maximum distance away from the pelvis that hit points will be registered.
- `public float MaxForceDist { set; }`
  - Maximum distance between hitPoint and body part at which forces are applied to part.
- `public float MaxTwist { set; }`
  - Max angle the character can twist before twsit helper torques are turned off.
- `public float MaxWallHeight { set; }`
  - Maximum height (from the lowest foot) to start to apply forces and torques to fall over the wall.
- `public float MinLegHeight { set; }`
  - Minimum height of pelvis above feet at which fallOverWall is attempted.
- `public float MinReachDistanceFromHitPoint { set; }`
  - Minimal distance from predicted hitpoint where each hands will try to reach the wall. Used if the hand target is outside the wall Edge.
- `public bool MoveArms { set; }`
  - Lift the arms up if true. Do nothing with the arms if false (eg when using catchfall arms or brace etc).
- `public bool MoveLegs { set; }`
  - Move the legs if true. Do nothing with the legs if false (eg when using dynamicBalancer etc).
- `public float ReachDistanceFromHitPoint { set; }`
  - Distance from predicted hitpoint where each hands will try to reach the wall.
- `public float RollingBackThr { set; }`
  - Value of the angular velocity about the wallEgde above which the character is considered as rolling backwards i.e. goes in to fow_RollingBack state.
- `public float RollingPotential { set; }`
  - On impact with the wall if the rollingPotential(calculated from the characters linear velocity w.r.t the wall) is greater than this value the character will try to go over the wall otherwise it won't try (fow_Aborted).
- `public float StepExclusionZone { set; }`
  - Specifies extent of area in front of the wall in which balancer won't try to take another step.
- `public bool UseArmIK { set; }`
  - Try to reach the wallEdge. To configure the IK : use limitAngleBack, limitAngleFront and limitAngleTotallyBack.

## FallType

enum `GTA.NaturalMotion.FallType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `RampDownStiffness` | 0 |
| `DontChangeStep` | 1 |
| `ForceBalance` | 2 |
| `Slump` | 3 |

## FireWeaponHelper

class `GTA.NaturalMotion.FireWeaponHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

One shot message apply a force to the hand as we fire the gun that should be in this hand.

### Constructors

- `public FireWeaponHelper(Ped ped)`
  - Creates a new Instance of the FireWeaponHelper for sending a FireWeapon `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the FireWeapon `Message` to.

### Properties

- `public bool ApplyFireGunForceAtClavicle { set; }`
  - Should we apply some of the force at the shoulder. Force double handed weapons (Ak47 etc).
- `public Vector3 Direction { set; }`
  - Direction of impulse in gun frame.
- `public float FiredWeaponStrength { set; }`
  - The force of the gun.
- `public Hand GunHandEnum { set; }`
  - Which hand is the gun in.
- `public float InhibitTime { set; }`
  - Minimum time before next fire impulse.
- `public float Split { set; }`
  - Split force between hand and clavicle when applyFireGunForceAtClavicle is true. 1 = all hand, 0 = all clavicle.

## ForceLeanInDirectionHelper

class `GTA.NaturalMotion.ForceLeanInDirectionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ForceLeanInDirectionHelper(Ped ped)`
  - Creates a new Instance of the ForceLeanInDirectionHelper for sending a ForceLeanInDirection `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ForceLeanInDirection `Message` to.

### Properties

- `public int BodyPart { set; }`
  - Body part that the force is applied to.
- `public Vector3 Dir { set; }`
  - Direction to lean in.
- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.

## ForceLeanRandomHelper

class `GTA.NaturalMotion.ForceLeanRandomHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ForceLeanRandomHelper(Ped ped)`
  - Creates a new Instance of the ForceLeanRandomHelper for sending a ForceLeanRandom `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ForceLeanRandom `Message` to.

### Properties

- `public int BodyPart { set; }`
  - Body part that the force is applied to.
- `public float ChangeTimeMax { set; }`
  - Maximum time until changing direction.
- `public float ChangeTimeMin { set; }`
  - Min time until changing direction.
- `public float LeanAmountMax { set; }`
  - Maximum amount of lean.
- `public float LeanAmountMin { set; }`
  - Minimum amount of lean.

## ForceLeanToPositionHelper

class `GTA.NaturalMotion.ForceLeanToPositionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ForceLeanToPositionHelper(Ped ped)`
  - Creates a new Instance of the ForceLeanToPositionHelper for sending a ForceLeanToPosition `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ForceLeanToPosition `Message` to.

### Properties

- `public int BodyPart { set; }`
  - Body part that the force is applied to.
- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.
- `public Vector3 Pos { set; }`
  - Position to head towards.

## ForceLeanTowardsObjectHelper

class `GTA.NaturalMotion.ForceLeanTowardsObjectHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ForceLeanTowardsObjectHelper(Ped ped)`
  - Creates a new Instance of the ForceLeanTowardsObjectHelper for sending a ForceLeanTowardsObject `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ForceLeanTowardsObject `Message` to.

### Properties

- `public int BodyPart { set; }`
  - Body part that the force is applied to.
- `public int BoundIndex { set; }`
  - BoundIndex of object to move towards (0 = just use instance coordinates).
- `public int InstanceIndex { set; }`
  - LevelIndex of object to move towards.
- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.
- `public Vector3 Offset { set; }`
  - Offset from instance position added when calculating position to lean to.

## ForceToBodyPartHelper

class `GTA.NaturalMotion.ForceToBodyPartHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Apply an impulse to a named body part.

### Constructors

- `public ForceToBodyPartHelper(Ped ped)`
  - Creates a new Instance of the ForceToBodyPartHelper for sending a ForceToBodyPart `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ForceToBodyPart `Message` to.

### Properties

- `public Vector3 Force { set; }`
  - Force to apply.
- `public bool ForceDefinedInPartSpace { set; }`
- `public int PartIndex { set; }`
  - Part or link or bound index.

## GrabHelper

class `GTA.NaturalMotion.GrabHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public GrabHelper(Ped ped)`
  - Creates a new Instance of the GrabHelper for sending a Grab `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Grab `Message` to.

### Properties

- `public float ArmStiffness { set; }`
  - Stiffness of the arm.
- `public float BodyStiffness { set; }`
  - Stiffness of upper body. Scales the arm grab such that the armStiffness is default when this is at default value.
- `public bool DontLetGo { set; }`
  - Once a constraint is made, keep reaching with whatever hand is allowed - no matter what the angle/distance and whether or not the constraint has broken due to constraintForce GT grabStrength. mmmtodo this is a badly named parameter.
- `public float DropWeaponDistance { set; }`
  - Distance below which a weapon carrying hand will request weapon to be dropped.
- `public bool DropWeaponIfNecessary { set; }`
  - If hasn't grabbed when weapon carrying hand is close to target, grab anyway.
- `public bool FromEA { set; }`
  - Use 2 point.
- `public float GrabDistance { set; }`
  - Relative distance at which the grab starts.
- `public float GrabHoldMaxTimer { set; }`
  - Amount of time, in seconds, before grab automatically bails.
- `public float GrabStrength { set; }`
  - Strength in hands for grabbing (kg m/s), -1 to ignore/disable.
- `public bool HandsCollide { set; }`
  - Hand collisions on when grabbing (false turns off hand collisions making grab more stable esp. To grab points slightly inside geometry).
- `public int InstanceIndex { set; }`
  - LevelIndex of instance to grab (-1 = world coordinates).
- `public int InstancePartIndex { set; }`
  - BoundIndex of part on instance to grab (0 = just use instance coordinates).
- `public bool JustBrace { set; }`
  - Flag to toggle between grabbing and bracing.
- `public bool LookAtGrab { set; }`
  - If true, the character will look at the grab.
- `public float MaxReachDistance { set; }`
  - Distance to reach out towards the grab point.
- `public float MaxWristAngle { set; }`
  - When we are grabbing the max angle the wrist ccan be at before we break the grab.
- `public float Move2Radius { set; }`
  - Relative distance (additional to grabDistance - doesn't try to move inside grabDistance)at which the grab tries to use the balancer to move to the grab point.
- `public Vector3 NormalL { set; }`
  - Normal for the left grab point.
- `public Vector3 NormalL2 { set; }`
  - Normal for the 3rd left grab point (if pointsX4grab=true).
- `public Vector3 NormalR { set; }`
  - Normal for the right grab point.
- `public Vector3 NormalR2 { set; }`
  - Normal for the 2nd right grab point (if pointsX4grab=true).
- `public float OneSideReachAngle { set; }`
  - Angle at which we will only reach with one hand.
- `public float OrientationConstraintScale { set; }`
  - Scale torque used to rotate hands to face normals.
- `public bool PointsX4grab { set; }`
  - Use 2 point.
- `public Vector3 Pos1 { set; }`
  - Grab pos1, right hand if not using line or surface grab.
- `public Vector3 Pos2 { set; }`
  - Grab pos2, left hand if not using line or surface grab.
- `public Vector3 Pos3 { set; }`
- `public Vector3 Pos4 { set; }`
- `public float PullUpStrengthLeft { set; }`
  - Strength to pull up with the left arm. 0 = no pull up.
- `public float PullUpStrengthRight { set; }`
  - Strength to pull up with the right arm. 0 = no pull up.
- `public float PullUpTime { set; }`
  - Time to reach the full pullup strength.
- `public float ReachAngle { set; }`
  - Angle from front at which the grab activates. If the point is outside this angle from front will not try to grab.
- `public float StickyHands { set; }`
  - Strength of cheat force on hands to pull towards target and stick to target ("cleverHandIK" strength).
- `public bool SurfaceGrab { set; }`
  - Toggle surface grab on. Requires pos1,pos2,pos3 and pos4 to be specified.
- `public Vector3 TargetForHeadLook { set; }`
  - Only used if useHeadLookToTarget is true, the target in world space to look at.
- `public TurnType TurnToTarget { set; }`
- `public bool UseHeadLookToTarget { set; }`
  - If true, the character will look at targetForHeadLook after a hand grabs until the end of the behavior. (Before grabbing it looks at the grab target).
- `public bool UseLeft { set; }`
  - Flag to toggle use of left hand.
- `public bool UseLineGrab { set; }`
  - Use the line grab, Grab along the line (x-x2).
- `public bool UseRight { set; }`
  - Flag to toggle the use of the Right hand.

## Hand

enum `GTA.NaturalMotion.Hand`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Left` | 0 |
| `Right` | 1 |

## HeadLookHelper

class `GTA.NaturalMotion.HeadLookHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public HeadLookHelper(Ped ped)`
  - Creates a new Instance of the HeadLookHelper for sending a HeadLook `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the HeadLook `Message` to.

### Properties

- `public bool AlwaysEyesHorizontal { set; }`
  - Keep the eyes horizontal. Use true for impact with cars. Use false if you want better look at target accuracy when the character is on the floor or leaned over (when not leaned over the eyes are still kept horizontal if eyesHorizontal=true ) alot.
- `public bool AlwaysLook { set; }`
  - Flag to force always to look.
- `public float Damping { set; }`
  - Damping of the muscles.
- `public bool EyesHorizontal { set; }`
  - Keep the eyes horizontal. Use true for impact with cars. Use false if you want better look at target accuracy when the character is on the floor or leaned over alot.
- `public int InstanceIndex { set; }`
  - LevelIndex of object to be looked at. Vel parameters are ignored if this is non -1.
- `public bool KeepHeadAwayFromGround { set; }`
- `public Vector3 Pos { set; }`
  - The point being looked at.
- `public float Stiffness { set; }`
  - Stiffness of the muscles.
- `public bool TwistSpine { set; }`
  - Allow head look to twist spine.
- `public Vector3 Vel { set; }`
  - The velocity of the point being looked at.

## HighFallHelper

class `GTA.NaturalMotion.HighFallHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public HighFallHelper(Ped ped)`
  - Creates a new Instance of the HighFallHelper for sending a HighFall `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the HighFall `Message` to.

### Properties

- `public bool AdaptiveCircling { set; }`
  - Stunt man type fall. Arm and legs circling direction controlled by angmom and orientation.
- `public float AimAngleBase { set; }`
  - Angle from vertical the pdController is driving to (positive = forwards).
- `public bool AlanRickman { set; }`
  - If true then orientate the character to face the point from where it started falling. High fall like the one in "Die Hard" with Alan Rickman.
- `public float ArmAmplitude { set; }`
  - In armWindMillAdaptive.
- `public float ArmAngSpeed { set; }`
  - Arm circling speed in armWindMillAdaptive.
- `public bool ArmBendElbows { set; }`
  - In armWindMillAdaptive bend the elbows as a function of armAngle. For stunt man true otherwise false.
- `public float ArmPhase { set; }`
  - In armWindMillAdaptive 3.1 opposite for stuntman. 1.0 old default. 0.0 in phase.
- `public float Arms2LegsPhase { set; }`
  - Phase angle between the arms and legs circling angle.
- `public Synchroisation Arms2LegsSync { set; }`
  - Syncs the arms angle to what the leg angle is.
- `public float ArmsUp { set; }`
  - Where to put the arms when preparing to land. Approx 1 = above head, 0 = head height, -1 = down. LT -2.0 use catchFall arms, LT -3.0 use prepare for landing pose if Agent is due to land vertically, feet first.
- `public bool Balance { set; }`
  - If true have enough strength to balance. If false not enough strength in legs to balance (even though bodyBlance called).
- `public float Bodydamping { set; }`
  - The damping of the joints.
- `public float BodyStiffness { set; }`
  - Stiffness of body. Value feeds through to bodyBalance (synced with defaults), to armsWindmill (14 for this value at default ), legs pedal, head look and roll down stairs directly.
- `public float CatchFallCutOff { set; }`
  - 0.5angle is 0.878 dot. Cutoff to go to the catchFall ( internal) //mmmtodo do like crashOrLandCutOff.
- `public float Catchfalltime { set; }`
  - The length of time before the impact that the character transitions to the landing.
- `public float CrashOrLandCutOff { set; }`
  - 0.52angle is 0.868 dot//A threshold for deciding how far away from upright the character needs to be before bailing out (going into a foetal) instead of trying to land (keeping stretched out). NB: never does bailout if ignorWorldCollisions true.
- `public float FootVelCompScale { set; }`
  - Scale to change to amount of vel that is added to the foot ik from the velocity (Internal).
- `public float FowardOffsetOfLegIK { set; }`
  - Forward offset for the feet during prepareForLanding.
- `public bool FowardRoll { set; }`
  - Try to execute a forward Roll on landing.
- `public float FowardVelRotation { set; }`
  - Scale to add/subtract from aimAngle based on forward speed (Internal).
- `public bool Hula { set; }`
  - With stunt man type fall. Hula reaction if can't see floor and not rotating fast.
- `public bool IgnorWorldCollisions { set; }`
  - Never go into bailout (foetal).
- `public float LandingNormal { set; }`
  - Ray-cast normal doted with up direction has to be greater than this number to consider object flat enough to land on it.
- `public float LegAngSpeed { set; }`
  - In pedal.
- `public float LegAsymmetry { set; }`
  - 0.0 for stuntman. Random offset applied per leg to the angular speed to desynchronize the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
- `public float LegL { set; }`
  - Leg Length for ik (Internal)//unused.
- `public float LegRadius { set; }`
  - Radius of legs on pedal.
- `public float LegStrength { set; }`
  - Strength of the legs at landing.
- `public float MaxSpeedForRecoverableFall { set; }`
  - Character needs to be moving less than this speed to consider fall as a recoverable one.
- `public float MinSpeedForBrace { set; }`
  - Character needs to be moving at least this fast horizontally to start bracing for impact if there is an object along its trajectory.
- `public bool OrientateBodyToFallDirection { set; }`
  - Toggle to orientate to fall direction. i.e. orientate so that the character faces the horizontal velocity direction.
- `public float OrientateMax { set; }`
  - DEVEL parameter - suggest you don't edit it. Maximum torque the orientation controller can apply. If 0 then no helper torques will be used. 300 will orientate the character softly for all but extreme angles away from aimAngleBase. If abs (current -aimAngleBase) is getting near 3.0 then this can be reduced to give a softer feel.
- `public bool OrientateTwist { set; }`
  - If false don't worry about the twist angle of the character when orientating the character. If false this allows the twist axis of the character to be free (You can get a nice twisting highFall like the one in dieHard 4 when the car goes into the helicopter).
- `public float PdDamping { set; }`
  - Damping multiplier of the controller to keep the character at angle aimAngleBase from vertical. The actual damping is pdDamping*pdStrength*constant*angVel.
- `public float PdStrength { set; }`
  - Strength of the controller to keep the character at angle aimAngleBase from vertical.
- `public float SideD { set; }`
  - Side offset for the feet during prepareForLanding. +ve = right.
- `public bool UseZeroPose_withFowardRoll { set; }`
  - Blend to a zero pose when forward roll is attempted.

## HipsLeanInDirectionHelper

class `GTA.NaturalMotion.HipsLeanInDirectionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public HipsLeanInDirectionHelper(Ped ped)`
  - Creates a new Instance of the HipsLeanInDirectionHelper for sending a HipsLeanInDirection `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the HipsLeanInDirection `Message` to.

### Properties

- `public Vector3 Dir { set; }`
  - Direction to lean in.
- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.

## HipsLeanRandomHelper

class `GTA.NaturalMotion.HipsLeanRandomHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public HipsLeanRandomHelper(Ped ped)`
  - Creates a new Instance of the HipsLeanRandomHelper for sending a HipsLeanRandom `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the HipsLeanRandom `Message` to.

### Properties

- `public float ChangeTimeMax { set; }`
  - Maximum time until changing direction.
- `public float ChangeTimeMin { set; }`
  - Min time until changing direction.
- `public float LeanAmountMax { set; }`
  - Maximum amount of lean.
- `public float LeanAmountMin { set; }`
  - Minimum amount of lean.

## HipsLeanToPositionHelper

class `GTA.NaturalMotion.HipsLeanToPositionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public HipsLeanToPositionHelper(Ped ped)`
  - Creates a new Instance of the HipsLeanToPositionHelper for sending a HipsLeanToPosition `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the HipsLeanToPosition `Message` to.

### Properties

- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.
- `public Vector3 Pos { set; }`
  - Position to head towards.

## HipsLeanTowardsObjectHelper

class `GTA.NaturalMotion.HipsLeanTowardsObjectHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public HipsLeanTowardsObjectHelper(Ped ped)`
  - Creates a new Instance of the HipsLeanTowardsObjectHelper for sending a HipsLeanTowardsObject `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the HipsLeanTowardsObject `Message` to.

### Properties

- `public int BoundIndex { set; }`
  - BoundIndex of object to lean hips towards (0 = just use instance coordinates).
- `public int InstanceIndex { set; }`
  - LevelIndex of object to lean hips towards.
- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.
- `public Vector3 Offset { set; }`
  - Offset from instance position added when calculating position to lean to.

## IncomingTransformsHelper

class `GTA.NaturalMotion.IncomingTransformsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public IncomingTransformsHelper(Ped ped)`
  - Creates a new Instance of the IncomingTransformsHelper for sending a IncomingTransforms `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the IncomingTransforms `Message` to.

## InjuredOnGroundHelper

class `GTA.NaturalMotion.InjuredOnGroundHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

InjuredOnGround.

### Constructors

- `public InjuredOnGroundHelper(Ped ped)`
  - Creates a new Instance of the InjuredOnGroundHelper for sending a InjuredOnGround `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the InjuredOnGround `Message` to.

### Properties

- `public Vector3 AttackerPos { set; }`
- `public bool DontReachWithLeft { set; }`
- `public bool DontReachWithRight { set; }`
- `public int Injury1Component { set; }`
- `public Vector3 Injury1LocalNormal { set; }`
- `public Vector3 Injury1LocalPosition { set; }`
- `public int Injury2Component { set; }`
- `public Vector3 Injury2LocalNormal { set; }`
- `public Vector3 Injury2LocalPosition { set; }`
- `public int NumInjuries { set; }`
- `public bool StrongRollForce { set; }`

## LeanInDirectionHelper

class `GTA.NaturalMotion.LeanInDirectionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public LeanInDirectionHelper(Ped ped)`
  - Creates a new Instance of the LeanInDirectionHelper for sending a LeanInDirection `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the LeanInDirection `Message` to.

### Properties

- `public Vector3 Dir { set; }`
  - Direction to lean in.
- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.

## LeanRandomHelper

class `GTA.NaturalMotion.LeanRandomHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public LeanRandomHelper(Ped ped)`
  - Creates a new Instance of the LeanRandomHelper for sending a LeanRandom `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the LeanRandom `Message` to.

### Properties

- `public float ChangeTimeMax { set; }`
  - Maximum time until changing direction.
- `public float ChangeTimeMin { set; }`
  - Minimum time until changing direction.
- `public float LeanAmountMax { set; }`
  - Maximum amount of lean.
- `public float LeanAmountMin { set; }`
  - Minimum amount of lean.

## LeanToPositionHelper

class `GTA.NaturalMotion.LeanToPositionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public LeanToPositionHelper(Ped ped)`
  - Creates a new Instance of the LeanToPositionHelper for sending a LeanToPosition `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the LeanToPosition `Message` to.

### Properties

- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.
- `public Vector3 Pos { set; }`
  - Position to head towards.

## LeanTowardsObjectHelper

class `GTA.NaturalMotion.LeanTowardsObjectHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public LeanTowardsObjectHelper(Ped ped)`
  - Creates a new Instance of the LeanTowardsObjectHelper for sending a LeanTowardsObject `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the LeanTowardsObject `Message` to.

### Properties

- `public int BoundIndex { set; }`
  - BoundIndex of object to lean towards (0 = just use instance coordinates).
- `public int InstanceIndex { set; }`
  - LevelIndex of object to lean towards.
- `public float LeanAmount { set; }`
  - Amount of lean, 0 to about 0.5. -ve will move away from the target.
- `public Vector3 Offset { set; }`
  - Offset from instance position added when calculating position to lean to.

## Message

class `GTA.NaturalMotion.Message`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

A base class for manually building a `Message`.

### Constructors

- `public Message(string message)`
  - Creates a class to manually build `Message`s that can be sent to any `Ped`.
  - `message`: The name of the natural motion message.

### Methods

- `public void Abort(Ped target)`
  - Stops this Natural Motion behavior on the given `Ped`.
  - `target`: The `Ped` to send the Abort `Message` to.
- `public void CreateBoolIntFloatArgDictIfNotCreated()`
- `public void CreateStringVector3ArrayArgDictIfNotCreated()`
- `public void ResetArguments()`
  - Resets all arguments to their default values.
- `public void SendTo(Ped target, int duration)`
  - Starts this Natural Motion behavior on the `Ped` for a specified duration.
  - `target`: The `Ped` to send the `Message` to.
  - `duration`: How long to apply the behavior for (-1 for looped).
- `public void SendTo(Ped target)`
  - Starts this Natural Motion behavior on the `Ped` that will loop until manually aborted.
  - `target`: The `Ped` to send the `Message` to.
- `public void SetArgument(string message, Vector3 value)`
  - Sets a `Message` argument to a `Vector3` value.
  - `message`: The argument name.
  - `value`: The value to set the argument to.
- `public void SetArgument(string message, bool value)`
  - Sets a `Message` argument to a `Boolean` value.
  - `message`: The argument name.
  - `value`: The value to set the argument to.
- `public void SetArgument(string message, int value)`
  - Sets a `Message` argument to a `Int32` value.
  - `message`: The argument name.
  - `value`: The value to set the argument to.
- `public void SetArgument(string message, float value)`
  - Sets a `Message` argument to a `Single` value.
  - `message`: The argument name.
  - `value`: The value to set the argument to.
- `public void SetArgument(string message, string value)`
  - Sets a `Message` argument to a `String` value.
  - `message`: The argument name.
  - `value`: The value to set the argument to.
- `public virtual string ToString()`
  - Returns the internal message name.

## MirrorMode

enum `GTA.NaturalMotion.MirrorMode`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Independant` | 0 |
| `Mirrored` | 1 |
| `Parallel` | 2 |

## OnFireHelper

class `GTA.NaturalMotion.OnFireHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public OnFireHelper(Ped ped)`
  - Creates a new Instance of the OnFireHelper for sending a OnFire `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the OnFire `Message` to.

### Properties

- `public float ArmsPoseWritheBlend { set; }`
  - Blend the bodyWrithe arms with the current desired pose from on fire behavior when character is on the floor.
- `public float ArmsWindmillWritheBlend { set; }`
  - Blend armsWindmill with the bodyWrithe arms when character is upright.
- `public float LegsPoseWritheBlend { set; }`
  - Blend the bodyWrithe legs with the current desired pose from on fire behavior when character is on the floor.
- `public float LegsStumbleWritheBlend { set; }`
  - Blend legs stumble with the bodyWrithe legs when character is upright.
- `public float MaxRollOverTime { set; }`
  - Rolling torque is ramped down over time. At this time in seconds torque value converges to zero. Use this parameter to restrict time the character is rolling.
- `public float PredictTime { set; }`
  - Character pose depends on character facing direction that is evaluated from its COMTM orientation. Set this value to 0 to use no orientation prediction i.e. current character COMTM orientation will be used to determine character facing direction and finally the pose bodyWrithe is blending to. Set this value to GT 0 to predict character COMTM orientation this amount of time in seconds to the future.
- `public bool RollOverFlag { set; }`
  - Flag to set bodyWrithe trying to rollOver.
- `public float RollOverRadius { set; }`
  - Rolling torque is ramped down with distance measured from position where character hit the ground and started rolling. At this distance in meters torque value converges to zero. Use this parameter to restrict distance the character travels due to rolling.
- `public float RollTorqueScale { set; }`
  - Scale rolling torque that is applied to character spine by bodyWrithe. Torque magnitude is calculated with the following formula: m_rollOverDirection*rollOverPhase*rollTorqueScale.
- `public float SpinePoseWritheBlend { set; }`
  - Blend the bodyWrithe back with the current desired pose from on fire behavior when character is on the floor.
- `public float SpineStumbleWritheBlend { set; }`
  - Blend spine stumble with the bodyWrithe spine when character is upright.
- `public float StaggerLeanRate { set; }`
  - How quickly the character leans hips when staggering.
- `public float StaggerTime { set; }`
  - Max time for stumbling around before falling to ground.
- `public float StumbleMaxLeanBack { set; }`
  - Max the character leans hips back when staggering.
- `public float StumbleMaxLeanForward { set; }`
  - Max the character leans hips forwards when staggering.

## PedalLegsHelper

class `GTA.NaturalMotion.PedalLegsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public PedalLegsHelper(Ped ped)`
  - Creates a new Instance of the PedalLegsHelper for sending a PedalLegs `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the PedalLegs `Message` to.

### Properties

- `public bool AdaptivePedal4Dragging { set; }`
  - Will pedal in the direction of travel (if backPedal = false, against travel if backPedal = true) and with an angular velocity relative to speed upto a maximum of 13(rads/sec). Use when being dragged by a car. Overrides angularSpeed.
- `public float AngSpeedMultiplier4Dragging { set; }`
  - NewAngularSpeed = Clamp(angSpeedMultiplier4Dragging * linear_speed/pedalRadius, 0.0, angularSpeed).
- `public float AngularSpeed { set; }`
  - Rate of pedaling. If adaptivePedal4Dragging is true then the legsAngularSpeed calculated to match the linear speed of the character can have a maximum value of angularSpeed (this max used to be hard coded to 13.0).
- `public bool BackPedal { set; }`
  - Pedal forwards or backwards.
- `public float CentreForwards { set; }`
  - Move the center of the pedal for both legs forward (or backward -ve).
- `public float CentreSideways { set; }`
  - Move the center of the pedal for both legs sideways (+ve = right). NB: not applied to hula.
- `public float CentreUp { set; }`
  - Move the center of the pedal for both legs up (or down -ve).
- `public float DragReduction { set; }`
  - How much to account for the target moving through space rather than being static.
- `public float Ellipse { set; }`
  - Turn the circle into an ellipse. Ellipse has horizontal radius a and vertical radius b. If ellipse is +ve then a=radius*ellipse and b=radius. If ellipse is -ve then a=radius and b = radius*ellipse. 0.0 = vertical line of length 2*radius, 0.0:1.0 circle squashed horizontally (vertical radius = radius), 1.0=circle. -0.001 = horizontal line of length 2*radius, -0.0:-1.0 circle squashed vertically (horizontal radius = radius), -1.0 = circle.
- `public bool Hula { set; }`
  - If true circle the legs in a hula motion.
- `public float LegAngleVariance { set; }`
  - 0-1 value used to vary the angle of the legs from the hips during the pedal.
- `public float LegStiffness { set; }`
  - Stiffness of legs.
- `public bool PedalLeftLeg { set; }`
  - Pedal with this leg or not.
- `public float PedalOffset { set; }`
  - Move the center of the pedal for the left leg up by this amount, the right leg down by this amount.
- `public bool PedalRightLeg { set; }`
  - Pedal with this leg or not.
- `public float Radius { set; }`
  - Base radius of pedal action.
- `public float RadiusVariance { set; }`
  - 0-1 value used to add variance to the radius value while pedalling, to desynchonize the legs' movement and provide some variety.
- `public int RandomSeed { set; }`
  - Random seed used to generate speed changes.
- `public float SpeedAsymmetry { set; }`
  - Random offset applied per leg to the angular speed to desynchronize the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
- `public float Spread { set; }`
  - Spread legs.

## PointArmHelper

class `GTA.NaturalMotion.PointArmHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

BEHAVIOURS REFERENCED: AnimPose - allows animPose to override body parts: Arms (useLeftArm, useRightArm).

### Constructors

- `public PointArmHelper(Ped ped)`
  - Creates a new Instance of the PointArmHelper for sending a PointArm `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the PointArm `Message` to.

### Properties

- `public float ArmDampingLeft { set; }`
  - Damping value for arm used to point.
- `public float ArmDampingRight { set; }`
  - Damping value for arm used to point.
- `public float ArmStiffnessLeft { set; }`
  - Stiffness of arm.
- `public float ArmStiffnessRight { set; }`
  - Stiffness of arm.
- `public float ArmStraightnessLeft { set; }`
  - Values less than 1 can give the arm a more bent look.
- `public float ArmStraightnessRight { set; }`
  - Values less than 1 can give the arm a more bent look.
- `public int InstanceIndexLeft { set; }`
  - Level index of thing to point at, or -1 for none. if -1, target is specified in world space, otherwise it is an offset from the object specified by this index.
- `public int InstanceIndexRight { set; }`
  - Level index of thing to point at, or -1 for none. if -1, target is specified in world space, otherwise it is an offset from the object specified by this index.
- `public float PointSwingLimitLeft { set; }`
  - Swing limit.
- `public float PointSwingLimitRight { set; }`
  - Swing limit.
- `public Vector3 TargetLeft { set; }`
  - Point to point to (in world space).
- `public Vector3 TargetRight { set; }`
  - Point to point to (in world space).
- `public float TwistLeft { set; }`
  - Twist of the arm around point direction.
- `public float TwistRight { set; }`
  - Twist of the arm around point direction.
- `public bool UseLeftArm { set; }`
- `public bool UseRightArm { set; }`
- `public bool UseZeroPoseWhenNotPointingLeft { set; }`
- `public bool UseZeroPoseWhenNotPointingRight { set; }`

## PointGunExtraHelper

class `GTA.NaturalMotion.PointGunExtraHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Seldom set parameters for pointGun - just to keep number of parameters in any message less than or equal to 64.

### Constructors

- `public PointGunExtraHelper(Ped ped)`
  - Creates a new Instance of the PointGunExtraHelper for sending a PointGunExtra `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the PointGunExtra `Message` to.

### Properties

- `public float ConstraintStrength { set; }`
  - For supportConstraint = 2: force constraint strength of the supporting hands - it gets shaky at about 4.0.
- `public float ConstraintThresh { set; }`
  - For supportConstraint = 2: Like makeConstraintDistance. Force starts acting when the hands are LT 3.0*thresh apart but is maximum strength LT thresh. For comparison: 0.1 is used for reachForWound in shot, 0.25 is used in grab.
- `public float OriDamp { set; }`
  - Hand stabilization controller damping.
- `public float OriStiff { set; }`
  - Hand stabilization controller stiffness.
- `public float PosDamp { set; }`
  - Hand stabilization controller damping.
- `public float PosStiff { set; }`
  - Hand stabilization controller stiffness.
- `public bool TimeWarpActive { set; }`
  - Is timeWarpActive enabled?.
- `public float TimeWarpStrengthScale { set; }`
  - Scale for arm and helper strength when timewarp is enabled. 1 = normal compensation.
- `public int WeaponMask { set; }`
  - Currently unused - no intoWorldTest. RAGE bit mask to exclude weapons from ray probe - currently defaults to MP3 weapon flag.

## PointGunHelper

class `GTA.NaturalMotion.PointGunHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public PointGunHelper(Ped ped)`
  - Creates a new Instance of the PointGunHelper for sending a PointGun `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the PointGun `Message` to.

### Properties

- `public float AcrossLimit { set; }`
  - Max aiming angle(deg) sideways across body midline measured from chest forward that the character will try to point. i.e. for rightHanded gun this is the angle left of the midline.
- `public float Add2WeaponDistConnect { set; }`
  - Add to weaponDistance for point2Connect neutral pointing (to straighten the arm).
- `public float Add2WeaponDistSide { set; }`
  - Add to weaponDistance for point2Side neutral pointing (to straighten the arm).
- `public bool AllowShotLooseness { set; }`
  - Allow shot to set a lower arm muscleStiffness than pointGun normally would.
- `public bool AlwaysSupport { set; }`
  - Support a non pointing gunHand i.e. if in zero pose (constrain as well if constraint possible).
- `public float ArmDamping { set; }`
  - Damping.
- `public float ArmStiffness { set; }`
  - Stiffness of the arm.
- `public float ArmStiffnessDetSupport { set; }`
  - Stiffness of the arm on pointing arm when a support arm is detached from a two-handed weapon.
- `public float AwayLimit { set; }`
  - Max aiming angle(deg) sideways away from body midline measured from chest forward that the character will try to point. i.e. for rightHanded gun this is the angle right of the midline.
- `public float BreakingStrength { set; }`
  - For supportConstraint = 1: strength of the supporting hands constraint (kg m/s), -1 to ignore/disable.
- `public float BrokenSupportTime { set; }`
  - Once constraint is broken then do not try to reconnect/support for this amount of time.
- `public float BrokenToSideProb { set; }`
  - Probability that the when a constraint is broken that during brokenSupportTime a side pose will be selected.
- `public bool CheckNeutralPoint { set; }`
  - Check the neutral pointing is pointable, if it isn't then choose a neutral pose instead.
- `public float ClavicleBlend { set; }`
  - How much of blend should come from incoming transforms 0(all IK) .. 1(all ITMs) For pointing arms only. (Support arm uses the IK solution as is for clavicles).
- `public float ConnectAfter { set; }`
  - If gunArm has been controlled by other behaviors for this time when it could have been pointing but couldn't due to pointing only allowed if connected, change gunArm pose to something that could connect for connectFor seconds.
- `public float ConnectFor { set; }`
  - Time to try to reconnect for.
- `public bool ConstrainRifle { set; }`
  - Use hard constraint to keep rifle stock against shoulder?.
- `public float ConstraintMinDistance { set; }`
  - For supportConstraint = 1: Support hand constraint distance will be slowly reduced until it hits this value. This is for stability and also allows the pointing arm to lead a little. Don't set lower than NM_MIN_STABLE_DISTANCECONSTRAINT_DISTANCE 0.001f.
- `public bool DisableArmCollisions { set; }`
  - Disable collisions between right hand/forearm and the torso/legs.
- `public bool DisableRifleCollisions { set; }`
  - Disable collisions between right hand/forearm and spine3/spine2 if in rifle mode.
- `public float DownLimit { set; }`
  - Max aiming angle(deg) downwards from body midline measured from chest forward that the character will try to point.
- `public float ElbowAttitude { set; }`
  - Controls arm twist. (except in pistolIK).
- `public bool EnableLeft { set; }`
  - Allow right hand to point/support?.
- `public bool EnableRight { set; }`
  - Allow right hand to point/support?.
- `public float ErrorThreshold { set; }`
  - Angular difference between pointing direction and target direction above which feedback will be generated.
- `public int FallingLimits { set; }`
  - 0= don't apply limits. 1=apply the limits below only when the character is falling. 2 = always apply these limits (instead of applying maxAngleAcross and maxAngleAway which only limits the horizontal angle but implicity limits the updown (the limit shape is a vertical hinge).
- `public int FallingSupport { set; }`
  - Allow supporting of a rifle(or two handed pistol) when falling. 0 = false, 1 = support if allowed, 2 = support until constraint not active (don't allow support to restart), 3 = support until constraint not effective (support hand to support distance must be less than 0.15 - don't allow support to restart).
- `public int FallingTypeSupport { set; }`
  - What is considered a fall by fallingSupport). Apply fallingSupport 0=never(will support if allowed), 1 = falling, 2 = falling except if falling backwards, 3 = falling and collided, 4 = falling and collided except if falling backwards, 5 = falling except if falling backwards until collided.
- `public float FireWeaponRelaxAmount { set; }`
  - Relax multiplier following firing weapon. Recovers over relaxTime.
- `public float FireWeaponRelaxDistance { set; }`
  - Range of motion for ik-based recoil.
- `public float FireWeaponRelaxTime { set; }`
  - Duration of arms relax following firing weapon. NB:This is clamped (0,5) in pointGun.
- `public float GravityOpposition { set; }`
  - Amount of gravity opposition on pointing arm.
- `public float GravOppDetachedSupport { set; }`
  - Amount of gravity opposition on pointing arm when a support arm is detached from a two-handed weapon.
- `public float LeadTarget { set; }`
  - NB: Only Applied to single handed weapons (some more work is required to have this tech on two handed weapons). Amount to lead target based on target velocity relative to the chest.
- `public int LeftHandParentEffector { set; }`
  - 1 = Use leftShoulder. Effector from which the left hand pointing originates. Ie, point from this part to the target. -1 causes default offset for active weapon mode to be applied.
- `public Vector3 LeftHandParentOffset { set; }`
  - Pointing-from offset from parent effector, expressed in spine3's frame, x = back/forward, y = right/left, z = up/down.
- `public Vector3 LeftHandTarget { set; }`
  - Target for the left Hand.
- `public int LeftHandTargetIndex { set; }`
  - Index of the object that the left hand target is specified in, -1 is world space.
- `public float MakeConstraintDistance { set; }`
  - For supportConstraint = 1: Minimum distance within which support hand constraint will be made.
- `public float MassMultDetachedSupport { set; }`
  - Amount of mass of weapon taken into account by gravity opposition on pointing arm when a support arm is detached from a two-handed weapon. The lower the value the more the character doesn't know about the weapon mass and therefore is more affected by it.
- `public float MaxAngleAcross { set; }`
  - Max aiming angle(deg) sideways across body midline measured from chest forward that the character will try to point.
- `public float MaxAngleAway { set; }`
  - Max aiming angle(deg) sideways away from body midline measured from chest forward that the character will try to point.
- `public bool MeasureParentOffset { set; }`
  - If useIncomingTransforms = true and measureParentOffset=true then measure the Pointing-from offset from parent effector, using itms - this should point the barrel of the gun to the target. This is added to the rightHandParentOffset. NB NOT used if rightHandParentEffector LT 0.
- `public bool NeutralPoint4Pistols { set; }`
  - NOT IMPLEMENTED YET KEEP=false - use pointing for neutral targets in pistol modes.
- `public bool NeutralPoint4Rifle { set; }`
  - Use pointing for neutral targets in rifle mode.
- `public int OneHandedPointing { set; }`
  - 0 = don't allow, 1= allow for kPistol(two handed pistol) only, 2 = allow for kRifle only, 3 = allow for kPistol and kRifle. Allow one handed pointing - no constraint if cant be supported . If not allowed then gunHand does not try to point at target if it cannot be supported - the constraint will be controlled by always support.
- `public int PistolNeutralType { set; }`
  - 0 = byFace, 1=acrossFront, 2=bySide. NB: bySide is not connectible so be careful if combined with kPistol and oneHandedPointing = 0 or 2.
- `public Vector3 Point2Connect { set; }`
  - Side, up, back) side is left for left arm, right for rght arm mmmmtodo.
- `public Vector3 Point2Side { set; }`
  - Side, up, back) side is left for left arm, right for right arm mmmmtodo.
- `public bool PoseUnusedGunArm { set; }`
  - Apply neutral pose when a gun arm isn't in use. NB: at the moment Rifle hand is always controlled by pointGun.
- `public bool PoseUnusedOtherArm { set; }`
  - Apply neutral pose to the non-gun arm (otherwise it is always under the control of other behaviors or not set). If the non-gun hand is a supporting hand it is not controlled by this parameter but by poseUnusedSupportArm.
- `public bool PoseUnusedSupportArm { set; }`
  - Apply neutral pose when a support arm isn't in use.
- `public float PrimaryHandWeaponDistance { set; }`
  - Distance from the shoulder to hold the weapon. If -1 and useIncomingTransforms then weaponDistance is read from ITMs. WeaponDistance=primaryHandWeaponDistance clamped [0.2f:m_maxArmReach=0.65] if useIncomingTransforms = false. pistol 0.60383, rifle 0.336.
- `public float ReduceConstraintLengthVel { set; }`
  - For supportConstraint = 1: Velocity at which to reduce the support hand constraint length.
- `public float RifleConstraintMinDistance { set; }`
  - Rifle constraint distance. Deliberately kept large to create a flat constraint surface where rifle meets the shoulder.
- `public int RifleFall { set; }`
  - Pose the rifle hand to reduce complications with collisions. 0 = false, 1 = always when falling, 2 = when falling except if falling backwards.
- `public int RightHandParentEffector { set; }`
  - 1 = Use rightShoulder.. Effector from which the right hand pointing originates. Ie, point from this part to the target. -1 causes default offset for active weapon mode to be applied.
- `public Vector3 RightHandParentOffset { set; }`
  - Pointing-from offset from parent effector, expressed in spine3's frame, x = back/forward, y = right/left, z = up/down. This is added to the measured one if useIncomingTransforms=true and measureParentOffset=true. NB NOT used if rightHandParentEffector LT 0. Pistol(0,0,0) Rifle(0.0032, 0.0, -0.0).
- `public Vector3 RightHandTarget { set; }`
  - Target for the right Hand.
- `public int RightHandTargetIndex { set; }`
  - Index of the object that the right hand target is specified in, -1 is world space.
- `public int SupportConstraint { set; }`
  - Type of constraint between the support hand and gun. 0=no constraint, 1=hard distance constraint, 2=Force based constraint, 3=hard spherical constraint.
- `public float UpLimit { set; }`
  - Max aiming angle(deg) upwards from body midline measured from chest forward that the character will try to point.
- `public bool UseHeadLook { set; }`
  - Use head look to drive head?.
- `public bool UseIncomingTransforms { set; }`
  - Use the incoming transforms to inform the pointGun of the primaryWeaponDistance, poleVector for the arm.
- `public bool UsePistolIK { set; }`
  - Enable new ik for pistol pointing.
- `public bool UseSpineTwist { set; }`
  - Use spine twist to orient chest?.
- `public bool UseTurnToTarget { set; }`
  - Turn balancer to help gun point at target.

## RbTwistAxis

enum `GTA.NaturalMotion.RbTwistAxis`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `WorldUp` | 0 |
| `CharacterComUp` | 1 |

## RegisterWeaponHelper

class `GTA.NaturalMotion.RegisterWeaponHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Use this message to register weapon. This is an alternativeto the registerWeapon public function.

### Constructors

- `public RegisterWeaponHelper(Ped ped)`
  - Creates a new Instance of the RegisterWeaponHelper for sending a RegisterWeapon `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the RegisterWeapon `Message` to.

### Properties

- `public int ConstraintHandle { set; }`
  - Pointer to the hand-gun constraint handle.
- `public Vector3 GunToButtInGun { set; }`
  - Gun center to butt expressed in gun co-ordinates. The gun pivots around this point when aiming.
- `public Vector3 GunToHandA { set; }`
  - A vector of the gunToHand matrix. The gunToHandMatrix is the desired gunToHandMatrix in the aimingPose. (The gunToHandMatrix when pointGun starts can be different so will be blended to this desired one).
- `public Vector3 GunToHandB { set; }`
  - B vector of the gunToHand matrix.
- `public Vector3 GunToHandC { set; }`
  - C vector of the gunToHand matrix.
- `public Vector3 GunToHandD { set; }`
  - D vector of the gunToHand matrix.
- `public Vector3 GunToMuzzleInGun { set; }`
  - Gun center to muzzle expressed in gun co-ordinates. To get the line of sight/barrel of the gun. Assumption: the muzzle direction is always along the same primary axis of the gun.
- `public Hand Hand { set; }`
- `public int LevelIndex { set; }`
  - Level index of the weapon.

## RollDownStairsHelper

class `GTA.NaturalMotion.RollDownStairsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public RollDownStairsHelper(Ped ped)`
  - Creates a new Instance of the RollDownStairsHelper for sending a RollDownStairs `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the RollDownStairs `Message` to.

### Properties

- `public float AirborneReduction { set; }`
  - Ordinarily keep at 0.85. Make this lower if you want spinning in the air.
- `public bool ApplyFoetalToLegs { set; }`
  - If true, use rollup for upper body and a kind of foetal behavior for legs.
- `public bool ApplyHelPerTorqueToAlign { set; }`
  - Apply torque to align the body orthogonally to the direction of the roll.
- `public bool ApplyMinMaxFriction { set; }`
  - Pass-through to Roll Up. Controls whether or not behavior enforces min/max friction.
- `public bool ApplyNewRollingCheatingTorques { set; }`
  - If true will use the new way to apply cheating torques (like in fallOverWall), otherwise will use the old way.
- `public float ArmReachLength { set; }`
  - The length that the arm reaches and so how much it straightens.
- `public float AsymmetricalLegs { set; }`
  - 0 is no leg asymmetry in 'foetal' position. greater than 0 a asymmetricalLegs-rand(30%), added/minus each joint of the legs in radians. Random number changes about once every roll. 0.4 gives a lot of asymmetry.
- `public Vector3 CustomRollDir { set; }`
  - Pass in a custom direction in to have the character try and roll in that direction.
- `public float Damping { set; }`
  - Effector Damping.
- `public float DelayToAlignBody { set; }`
  - Only used if applyHelPerTorqueToAlign defined to true : delay to start to apply torques.
- `public float Forcemag { set; }`
  - Helper force strength. Do not go above 1 for a rollDownStairs/roll along ground reaction.
- `public bool LimitSpinReduction { set; }`
  - Scale zAxisSpinReduction back when rotating end-over-end (somersault) to give the body a chance to align with the axis of rotation.
- `public float M_armReachAmount { set; }`
  - How much the character reaches with his arms to brace against the ground.
- `public float M_legPush { set; }`
  - Amount that the legs push outwards when tumbling.
- `public float M_useArmToSlowDown { set; }`
  - The degree to which the character will try to stop a barrel roll with his arms.
- `public float MagOfTorqueToAlign { set; }`
  - Only used if applyHelPerTorqueToAlign defined to true : magnitude of the torque to align orthogonally the body.
- `public float MagOfTorqueToRoll { set; }`
  - Only used if applyNewRollingCheatingTorques defined to true : magnitude of the torque to roll down the stairs.
- `public float MaxAngVel { set; }`
  - Only used if applyNewRollingCheatingTorques defined to true : maximal angular velocity of the roll to apply cheating torque.
- `public float MaxAngVelAroundFrontwardAxis { set; }`
  - Only used if applyNewRollingCheatingTorques or applyHelPerTorqueToAlign defined to true : maximal angular velocity around frontward axis of the pelvis to apply cheating torques.
- `public float MinAngVel { set; }`
  - Only used if applyNewRollingCheatingTorques or applyHelPerTorqueToAlign defined to true : minimal angular velocity of the roll to apply cheating torques.
- `public float MovementLegsInFoetalPosition { set; }`
  - Only used if applyFoetalToLegs = true : define the variation of angles for the joints of the legs.
- `public bool OnlyApplyHelperForces { set; }`
  - Don't use rollup if true.
- `public bool SpinWhenInAir { set; }`
  - Applied cheat forces to spin the character when in the air, the forces are 40% of the forces applied when touching the ground. Be careful little bunny rabbits, the character could spin unnaturally in the air.
- `public float Stiffness { set; }`
  - Effector Stiffness. Value feeds through to rollUp directly.
- `public float StiffnessDecayTarget { set; }`
  - The target linear velocity used to start the rolling.
- `public float StiffnessDecayTime { set; }`
  - Time, in seconds, to decay stiffness down to the stiffnessDecayTarget value (or -1 to disable).
- `public float TargetLinearVelocity { set; }`
  - Helper torques are applied to match the spin of the character to the max of targetLinearVelocity and COMVelMag.
- `public float TargetLinearVelocityDecayTime { set; }`
  - Time for the targetlinearVelocity to decay to zero.
- `public bool TryToAvoidHeadButtingGround { set; }`
  - Blends between a zeroPose and the Rollup, Faster the character is rotating the less the zeroPose.
- `public bool UseCustomRollDir { set; }`
  - Pass in true to use the customRollDir parameter.
- `public bool UseRelativeVelocity { set; }`
  - UseVelocityOfObjectBelow uses a relative velocity of the character to the object underneath.
- `public bool UseVelocityOfObjectBelow { set; }`
  - Scale applied cheat forces/torques to (zero) if object underneath character has velocity greater than 1.f.
- `public bool UseZeroPose { set; }`
  - Blends between a zeroPose and the Rollup, Faster the character is rotating the less the zeroPose.
- `public float ZAxisSpinReduction { set; }`
  - Tries to reduce the spin around the z axis. Scale 0 - 1.

## SetCharacterCollisionsHelper

class `GTA.NaturalMotion.SetCharacterCollisionsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

SetCharacterCollisions:.

### Constructors

- `public SetCharacterCollisionsHelper(Ped ped)`
  - Creates a new Instance of the SetCharacterCollisionsHelper for sending a SetCharacterCollisions `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetCharacterCollisions `Message` to.

### Properties

- `public bool ApplyToAll { set; }`
- `public bool ApplyToClavicles { set; }`
- `public bool ApplyToSpine { set; }`
- `public bool ApplyToThighs { set; }`
- `public bool ApplyToUpperArms { set; }`
- `public bool FootSlip { set; }`
  - Allow foot slipping if collided.
- `public float MaxVelocity { set; }`
  - Torque = spin*(relative velocity) up to this maximum for relative velocity.
- `public float Spin { set; }`
  - Sliding friction turned into spin 80.0 (used in demo videos) good for rest of default params below. If 0.0 then no collision enhancement.
- `public int VehicleClass { set; }`
  - ClassType of the object against which to enhance the collision. All character vehicle interaction (e.g. braceForImpact glancing spins) relies on this value so EDIT WISELY. If it is used for things other than vehicles then NM should be informed.

## SetCharacterDampingHelper

class `GTA.NaturalMotion.SetCharacterDampingHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Damp out cartwheeling and somersaulting above a certain threshold.

### Constructors

- `public SetCharacterDampingHelper(Ped ped)`
  - Creates a new Instance of the SetCharacterDampingHelper for sending a SetCharacterDamping `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetCharacterDamping `Message` to.

### Properties

- `public float CartwheelDamp { set; }`
  - Amount to damp somersaulting by (spinning around front/back axis) - try 0.8.
- `public float CartwheelThresh { set; }`
  - Cartwheel AngularMomentum measure above which we start damping - try 27.0.
- `public float SomersaultDamp { set; }`
  - Amount to damp somersaulting by (spinning around left/right axis) - try 0.45.
- `public float SomersaultThresh { set; }`
  - Somersault AngularMomentum measure above which we start damping - try 34.0. Falling over straight backwards gives 54 on hitting ground.
- `public bool V2 { set; }`
  - If true damping is proportional to Angular momentum squared. If false proportional to Angular momentum.
- `public float VehicleCollisionTime { set; }`
  - Time after impact with a vehicle to apply characterDamping. -ve values mean always apply whether collided with vehicle or not. =0.0 never apply. =timestep apply for only that frame. A typical roll from being hit by a car lasts about 4secs.

## SetCharacterHealthHelper

class `GTA.NaturalMotion.SetCharacterHealthHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Sets character's health on the dead-to-alive scale: [0..1].

### Constructors

- `public SetCharacterHealthHelper(Ped ped)`
  - Creates a new Instance of the SetCharacterHealthHelper for sending a SetCharacterHealth `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetCharacterHealth `Message` to.

### Properties

- `public float CharacterHealth { set; }`
  - Health of character.

## SetCharacterStrengthHelper

class `GTA.NaturalMotion.SetCharacterStrengthHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Sets character's strength on the dead-granny-to-healthy-terminator scale: [0..1].

### Constructors

- `public SetCharacterStrengthHelper(Ped ped)`
  - Creates a new Instance of the SetCharacterStrengthHelper for sending a SetCharacterStrength `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetCharacterStrength `Message` to.

### Properties

- `public float CharacterStrength { set; }`
  - Strength of character.

## SetCharacterUnderwaterHelper

class `GTA.NaturalMotion.SetCharacterUnderwaterHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Sets viscosity applied to damping limbs.

### Constructors

- `public SetCharacterUnderwaterHelper(Ped ped)`
  - Creates a new Instance of the SetCharacterUnderwaterHelper for sending a SetCharacterUnderwater `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetCharacterUnderwater `Message` to.

### Properties

- `public float GravityFactor { set; }`
  - Gravity factor applied to character.
- `public bool LinearStroke { set; }`
  - Swimming force (linearStroke=true,False) = (f(v),f(v*v)).
- `public float Stroke { set; }`
  - Swimming force applied to character as a function of handVelocity and footVelocity.
- `public bool Underwater { set; }`
  - Is character underwater?.
- `public float Viscosity { set; }`
  - Viscosity applied to character's parts.

## SetFallingReactionHelper

class `GTA.NaturalMotion.SetFallingReactionHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Sets the type of reaction if catchFall is called.

### Constructors

- `public SetFallingReactionHelper(Ped ped)`
  - Creates a new Instance of the SetFallingReactionHelper for sending a SetFallingReaction `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetFallingReaction `Message` to.

### Properties

- `public bool AntiPropClav { set; }`
  - Discourage the character getting stuck propped up by elbows when falling backwards - by inhibiting backwards moving clavicles (keeps the arms slightly wider).
- `public bool AntiPropWeak { set; }`
  - Discourage the character getting stuck propped up by elbows when falling backwards - by weakening the arms as soon they hit the floor. (Also stops the hands lifting up when flat on back).
- `public float ArmReduceSpeed { set; }`
  - Strength is reduced in the catchFall when the arms contact the ground. 0.2 is good for handsAndKnees. 2.5 is good for normal catchFall, anything lower than 1.0 for normal catchFall may lead to bad catchFall poses.
- `public bool CallRDS { set; }`
  - If true catchFall will call rollDownstairs if comVel GT comVelRDSThresh - prevents excessive sliding in catchFall. Was previously only true for handsAndKnees.
- `public float ChangeFrictionTime { set; }`
  - Time after hitting ground that the catchFall can change the friction of parts to inhibit sliding.
- `public float ComVelRDSThresh { set; }`
  - ComVel above which rollDownstairs will start - prevents excessive sliding in catchFall.
- `public float FrictionMax { set; }`
  - Max Friction of an impact with a body part (not head, hands or feet) - to increase friction of slippy environment to get character to roll better. Applied in catchFall and rollUp(rollDownStairs).
- `public float FrictionMin { set; }`
  - Min Friction of an impact with a body part (not head, hands or feet) - to increase friction of slippy environment to get character to roll better. Applied in catchFall and rollUp(rollDownStairs).
- `public float GroundFriction { set; }`
  - 8.0 was used on yanked) Friction multiplier on body parts when on ground. Character can look too slidy with groundFriction = 1. Higher values give a more jerky reaction but this seems timestep dependent especially for dragged by the feet.
- `public bool HandsAndKnees { set; }`
  - Set to true to get handsAndKnees catchFall if catchFall called. If true allows the dynBalancer to stay on during the catchfall and modifies the catch fall to give a more alive looking performance (hands and knees for front landing or sitting up for back landing).
- `public bool HeadAsWeakAsArms { set; }`
  - Head weakens as arms weaken. If false and antiPropWeak when falls onto back doesn't loosen neck so early (matches bodyStrength instead).
- `public bool HkHeadAvoid { set; }`
  - Enable head ground avoidance when handsAndKnees is true.
- `public float InhibitRollingTime { set; }`
  - Time after hitting ground that the catchFall can call rds.
- `public float ReachLengthMultiplier { set; }`
  - Reach length multiplier that scales characters arm topological length, value in range from (0, 1 GT where 1.0 means reach length is maximum.
- `public bool ResistRolling { set; }`
  - For rds catchFall only: True to resist rolling motion (rolling motion is set off by ub contact and a sliding velocity), false to allow more of a continuous rolling (rolling motion is set off at a sliding velocity).
- `public bool RiflePose { set; }`
  - Hold rifle in a safe position to reduce complications with collision. Only applied if holding a rifle.
- `public float SpineLean1Offset { set; }`
  - Bias spine post towards hunched (away from arched).
- `public float StopManual { set; }`
  - Override slope value to manually force stopping on flat ground. Encourages character to come to rest face down or face up.
- `public bool StopOnSlopes { set; }`
  - Apply tactics to help stop on slopes.
- `public float StoppedStrengthDecay { set; }`
  - Speed at which strength reduces when stopped.
- `public float SuccessStrength { set; }`
  - When bodyStrength is less than successStrength send a success feedback - DO NOT GO OUTSIDE MIN/MAX PARAMETER VALUES OTHERWISE NO SUCCESS FEEDBACK WILL BE SENT.

## SetFrictionScaleHelper

class `GTA.NaturalMotion.SetFrictionScaleHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

SetFrictionScale:.

### Constructors

- `public SetFrictionScaleHelper(Ped ped)`
  - Creates a new Instance of the SetFrictionScaleHelper for sending a SetFrictionScale `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetFrictionScale `Message` to.

### Properties

- `public float GlobalMax { set; }`
  - Character-wide maximum impact friction. Affects all parts (not just those in mask).
- `public float GlobalMin { set; }`
  - Character-wide minimum impact friction. Affects all parts (not just those in mask).
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public float Scale { set; }`
  - Friction scale to be applied to parts in mask.

## SetMuscleStiffnessHelper

class `GTA.NaturalMotion.SetMuscleStiffnessHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Use this message to manually set the muscle stiffness values -before using Active Pose to drive to an animated pose, for example.

### Constructors

- `public SetMuscleStiffnessHelper(Ped ped)`
  - Creates a new Instance of the SetMuscleStiffnessHelper for sending a SetMuscle stiffness `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetMuscle stiffness `Message` to.

### Properties

- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
- `public float MuscleStiffness { set; }`
  - Muscle stiffness of joint/s.

## SetStiffnessHelper

class `GTA.NaturalMotion.SetStiffnessHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Use this message to manually set the body stiffness values -before using Active Pose to drive to an animated pose, for example.

### Constructors

- `public SetStiffnessHelper(Ped ped)`
  - Creates a new Instance of the SetStiffnessHelper for sending a SetStiffness `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetStiffness `Message` to.

### Properties

- `public float BodyStiffness { set; }`
  - Stiffness of whole character.
- `public float Damping { set; }`
  - Damping amount, less is underdamped.
- `public string Mask { set; }`
  - Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).

## SetWeaponModeHelper

class `GTA.NaturalMotion.SetWeaponModeHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Use this message to set the character's weapon mode. This is an alternativeto the setWeaponMode public function.

### Constructors

- `public SetWeaponModeHelper(Ped ped)`
  - Creates a new Instance of the SetWeaponModeHelper for sending a SetWeaponMode `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SetWeaponMode `Message` to.

### Properties

- `public WeaponMode WeaponMode { set; }`

## ShotConfigureArmsHelper

class `GTA.NaturalMotion.ShotConfigureArmsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Configure the arm reactions in shot.

### Constructors

- `public ShotConfigureArmsHelper(Ped ped)`
  - Creates a new Instance of the ShotConfigureArmsHelper for sending a ShotConfigureArms `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotConfigureArms `Message` to.

### Properties

- `public bool AllowLeftPistolRFW { set; }`
  - Allow character to reach for wound with left hand if holding a pistol. It never will for a rifle. If pointGun is running this will only happen if the hand cannot point and pointGun:poseUnusedGunArm = false.
- `public bool AllowRightPistolRFW { set; }`
  - Allow character to reach for wound with right hand if holding a pistol. It never will for a rifle. If pointGun is running this will only happen if the hand cannot point and pointGun:poseUnusedGunArm = false.
- `public float AlwaysReachTime { set; }`
  - Inhibit arms brace for this amount of time after reachForWound has begun.
- `public float AWRadiusMult { set; }`
  - For armsWindmill, multiplier on character speed - increase of radii is proportional to character speed (max radius increase = 0.45). E.g. lowering the value increases the range of velocity that the 0-0.45 is applied over.
- `public float AWSpeedMult { set; }`
  - For armsWindmill, multiplier on character speed - increase of speed of circling is proportional to character speed (max speed of circliing increase = 1.5). Eg. lowering the value increases the range of velocity that the 0-1.5 is applied over.
- `public float AWStiffnessAdd { set; }`
  - For armsWindmill, added arm stiffness ranges from 0 to AWStiffnessAdd.
- `public bool Brace { set; }`
  - Blind brace with arms if appropriate.
- `public bool Bust { set; }`
  - Has the character got a bust. If so then cupBust (move bust reach targets below bust) or bustElbowLift and cupSize (stop upperArm penetrating bust and move bust targets to surface of bust) are implemented.
- `public float BustElbowLift { set; }`
  - Lift the elbows up this much extra to avoid upper arm penetrating the bust (when target hits spine2 or spine3).
- `public bool CupBust { set; }`
  - All reach targets above or on the bust will cause a reach below the bust. (specifically moves spine3 and spine2 targets to spine1). BustElbowLift and cupSize are ignored.
- `public float CupSize { set; }`
  - Amount reach target to bust (spine2) will be offset forward by.
- `public bool Fling2 { set; }`
  - Type of reaction.
- `public float Fling2AngleMaxL { set; }`
  - Maximum fling angle for left arm.
- `public float Fling2AngleMaxR { set; }`
  - Maximum fling angle for right arm.
- `public float Fling2AngleMinL { set; }`
  - Minimum fling angle for left arm. Fling angle is random in the range fling2AngleMin:fling2AngleMax. Angle of fling in radians measured from the body horizontal sideways from shoulder. Positive is up, 0 shoulder level, negative down.
- `public float Fling2AngleMinR { set; }`
  - Minimum fling angle for right arm.
- `public bool Fling2Left { set; }`
  - Fling the left arm.
- `public float Fling2LengthMaxL { set; }`
  - Maximum left arm length.
- `public float Fling2LengthMaxR { set; }`
  - Max right arm length.
- `public float Fling2LengthMinL { set; }`
  - Minimum left arm length. Arm length is random in the range fling2LengthMin:fling2LengthMax. Arm length maps one to one with elbow angle. These values are scaled internally for the female character.
- `public float Fling2LengthMinR { set; }`
  - Min right arm length.
- `public float Fling2MStiffL { set; }`
  - Muscle stiffness of the left arm. If negative then uses the shots underlying muscle stiffness from controlStiffness (i.e. respects looseness).
- `public float Fling2MStiffR { set; }`
  - Muscle stiffness of the right arm. If negative then uses the shots underlying muscle stiffness from controlStiffness (i.e. respects looseness).
- `public bool Fling2OverrideStagger { set; }`
  - Override stagger arms even if staggerFall:m_upperBodyReaction = true.
- `public float Fling2RelaxTimeL { set; }`
  - Maximum time before the left arm relaxes in the fling. It will relax automatically when the arm has completed it's bent arm fling. This is what causes the arm to straighten.
- `public float Fling2RelaxTimeR { set; }`
  - Maximum time before the right arm relaxes in the fling. It will relax automatically when the arm has completed it's bent arm fling. This is what causes the arm to straighten.
- `public bool Fling2Right { set; }`
  - Fling the right arm.
- `public float Fling2Time { set; }`
  - Duration of the fling behavior.
- `public float Fling2TimeBefore { set; }`
  - Time after hit that the fling will start (allows for a bit of loose arm movement from bullet impact.snap etc).
- `public bool PointGun { set; }`
  - Point gun if appropriate.
- `public int ReachFalling { set; }`
  - Reach for wound when falling. 0 = false, 1 = true, 2 = once per shot performance.
- `public int ReachFallingWithOneHand { set; }`
  - Force character to reach for wound with only one hand when falling or fallen. 0 = allow two-handed reach, 1 = left only if two-handed possible, 2 = right only if two-handed possible, 3 = one handed but automatic (allows switching of hands).
- `public int ReachOnFloor { set; }`
  - ReachForWound when on floor - 0 = false, 1 = true, 2 = once per shot performance.
- `public int ReachWithOneHand { set; }`
  - Force character to reach for wound with only one hand. 0 = allow two-handed reach, 1 = left only if two-handed possible, 2 = right only if two-handed possible.
- `public int ReleaseWound { set; }`
  - Release wound if going sideways/forward fast enough. 0 = don't. 1 = only if bracing. 2 = any default arm reaction.
- `public bool RfwWithPistol { set; }`
  - Override pointGun and reachForWound if desired if holding a pistol. It never will for a rifle.
- `public bool UseArmsWindmill { set; }`
  - ArmsWindmill if going backwards fast enough.

## ShotFallToKneesHelper

class `GTA.NaturalMotion.ShotFallToKneesHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Configure the fall to knees shot.

### Constructors

- `public ShotFallToKneesHelper(Ped ped)`
  - Creates a new Instance of the ShotFallToKneesHelper for sending a ShotFallToKnees `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotFallToKnees `Message` to.

### Properties

- `public bool FallToKnees { set; }`
  - Type of reaction.
- `public bool FtkAlwaysChangeFall { set; }`
  - Always change fall behavior. If false only change when falling forward.
- `public float FtkBalanceAbortThreshold { set; }`
  - When the character gives up and goes into a fall.
- `public float FtkBalanceTime { set; }`
  - How long the balancer runs for before fallToKnees starts.
- `public float FtkBendRate { set; }`
  - Rate at which the legs are bent to go from standing to on knees.
- `public bool FtkFailMustCollide { set; }`
  - The upper body of the character must be colliding and other failure conditions met to fail.
- `public float FtkFallBelowStab { set; }`
  - Balancer instability below which the character starts to bend legs even if it isn't going to fall on to it's knees (i.e. if going backwards). 0.3 almost ensures a fall to knees but means the character will keep stepping backward until it slows down enough.
- `public float FtkFricMult { set; }`
  - Multiplier on the reduction of friction for the feet based on angle away from horizontal - helps the character fall to knees quicker.
- `public float FtkHelperForce { set; }`
  - Hip helper force magnitude - to help character lean over balance point of line between toes.
- `public bool FtkHelperForceOnSpine { set; }`
  - Helper force applied to spine3 as well.
- `public float FtkHipAngleFall { set; }`
  - Apply this hip angle when the character starts to fall backwards when on knees.
- `public float FtkHipBlend { set; }`
  - Blend from current hip to balancing on knees hip angle.
- `public float FtkImpactLooseness { set; }`
  - Looseness (muscleStiffness = 1.01f - m_parameters.ftkImpactLooseness) applied to upperBody on knee impacts.
- `public float FtkImpactLoosenessTime { set; }`
  - Time that looseness is applied after knee impacts.
- `public bool FtkKneeSpin { set; }`
  - When on knees allow some spinning of the character. If false then the balancers' footSlipCompensation remains on and tends to keep the character facing the same way as when it was balancing.
- `public float FtkLeanHelp { set; }`
  - Help balancer lean amount - to help character lean over balance point of line between toes. Half of this is also applied as hipLean.
- `public float FtkLungeProb { set; }`
  - Probability that a lunge reaction will be allowed.
- `public int FtkOnKneesArmType { set; }`
  - Type of arm response when on knees falling forward 0=useFallArms (from RollDownstairs or catchFall), 1= armsIn, 2=armsOut.
- `public float FtkPitchBackwards { set; }`
  - Hip pitch applied (+ve forward, -ve backwards) if character is falling backwards on way down to it's knees.
- `public float FtkPitchForwards { set; }`
  - Hip pitch applied (+ve forward, -ve backwards) if character is falling forwards on way down to it's knees.
- `public bool FtkReachForWound { set; }`
  - True = Keep reaching for wound regardless of fall/onground state. false = respect the shotConfigureArms params: reachFalling, reachFallingWithOneHand, reachOnFloor.
- `public bool FtkReleasePointGun { set; }`
  - Override the pointGun when knees hit.
- `public float FtkReleaseReachForWound { set; }`
  - Release the reachForWound this amount of time after the knees have hit. If LT 0.0 then keep reaching for wound regardless of fall/onground state.
- `public float FtkSpineBend { set; }`
  - Bend applied to spine when falling from knees. (+ve forward - try -0.1) (only if rds called).
- `public bool FtkStiffSpine { set; }`
  - Stiffen spine when falling from knees (only if rds called).

## ShotFromBehindHelper

class `GTA.NaturalMotion.ShotFromBehindHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Configure the shot from behind reaction.

### Constructors

- `public ShotFromBehindHelper(Ped ped)`
  - Creates a new Instance of the ShotFromBehindHelper for sending a ShotFromBehind `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotFromBehind `Message` to.

### Properties

- `public float SfbArmsOnset { set; }`
  - Amount of time before applying spread out arms pose.
- `public float SfbForceBalancePeriod { set; }`
  - Amount of time not taking a step.
- `public float SfbHipAmount { set; }`
  - Hip Pitch.
- `public int SfbIgnoreFail { set; }`
  - 0 = balancer fails as normal, 1 = ignore backArchedBack and leanedTooFarBack balancer failures, 2 = ignore backArchedBack balancer failure only, 3 = ignore leanedTooFarBack balancer failure only.
- `public float SfbKneeAmount { set; }`
  - Knee bend.
- `public float SfbKneesOnset { set; }`
  - Amount of time before bending knees a bit.
- `public float SfbNeckAmount { set; }`
  - Neck Bend.
- `public float SfbNoiseGain { set; }`
  - Controls additional independent randomized bending of left/right elbows.
- `public float SfbPeriod { set; }`
  - ShotFromBehind reaction period after being shot.
- `public float SfbSpineAmount { set; }`
  - SpineBend.
- `public bool ShotFromBehind { set; }`
  - Type of reaction.

## ShotHeadLookHelper

class `GTA.NaturalMotion.ShotHeadLookHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ShotHeadLookHelper(Ped ped)`
  - Creates a new Instance of the ShotHeadLookHelper for sending a ShotHeadLook `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotHeadLook `Message` to.

### Properties

- `public Vector3 HeadLook { set; }`
  - Position to look at with headlook flag.
- `public float HeadLookAtHeadPosMaxTimer { set; }`
  - Min time to look headLook or if zero - forward or in velocity direction.
- `public float HeadLookAtHeadPosMinTimer { set; }`
  - Max time to look headLook or if zero - forward or in velocity direction.
- `public float HeadLookAtWoundMaxTimer { set; }`
  - Max time to look at wound.
- `public float HeadLookAtWoundMinTimer { set; }`
  - Min time to look at wound.
- `public bool UseHeadLook { set; }`
  - Use head look. Default: looks at provided target or if this is zero - looks forward or in velocity direction. If reachForWound is enabled, switches between looking at the wound and at the default target.

## ShotHelper

class `GTA.NaturalMotion.ShotHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ShotHelper(Ped ped)`
  - Creates a new Instance of the ShotHelper for sending a Shot `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Shot `Message` to.

### Properties

- `public bool AllowInjuredArm { set; }`
  - Injured arm code runs if arm hit (turns and steps and bends injured arm).
- `public bool AllowInjuredLeg { set; }`
  - When false injured leg is not bent and character does not bend to reach it.
- `public bool AllowInjuredLowerLegReach { set; }`
  - When false don't try to reach for injured Lower Legs (shins/feet).
- `public bool AllowInjuredThighReach { set; }`
  - When false don't try to reach for injured Thighs.
- `public bool AlwaysResetLooseness { set; }`
  - Looseness always reset on shotNewBullet even if previous looseness ramp still running. Except for the neck which has it's own ramp.
- `public bool AlwaysResetNeckLooseness { set; }`
  - Neck looseness always reset on shotNewBullet even if previous looseness ramp still running.
- `public float AngVelScale { set; }`
  - How much to scale the angular velocity coming in from animation of a part if it is in angVelScaleMask (otherwise scale by 1.0).
- `public string AngVelScaleMask { set; }`
  - Parts to scale the initial angular velocity by angVelScale (otherwize scale by 1.0).
- `public float ArmStiffness { set; }`
  - Arm stiffness.
- `public float BodyStiffness { set; }`
  - Stiffness of body. Feeds through to roll_up.
- `public bool BulletProofVest { set; }`
  - Looseness applied to spine is different if bulletProofVest is true.
- `public bool ChickenArms { set; }`
  - Type of reaction.
- `public float CpainDuration { set; }`
  - Conscious pain duration at cpainMag/cpainTwistMag after cpainSmooth2Time.
- `public float CpainMag { set; }`
  - Conscious pain spine Lean(back/Forward) magnitude (Replaces spinePainMultiplier).
- `public float CpainSmooth2Time { set; }`
  - Conscious pain duration ramping from zero to cpainMag/cpainTwistMag.
- `public float CpainSmooth2Zero { set; }`
  - Conscious pain ramping to zero after cpainSmooth2Time + cpainDuration (Replaces spinePainTime).
- `public float CpainTwistMag { set; }`
  - Conscious pain spine Twist/Lean2Side magnitude Replaces spinePainTwistMultiplier).
- `public bool Crouching { set; }`
  - Is the guy crouching or not.
- `public float CStrLowerMax { set; }`
- `public float CStrLowerMin { set; }`
- `public float CStrUpperMax { set; }`
- `public float CStrUpperMin { set; }`
  - Proportions to what the strength would be normally.
- `public float DeathTime { set; }`
  - Time to death (HACK for underwater). If -ve don't ever die.
- `public float ExagDuration { set; }`
  - Exaggerate bullet duration (at exagMag/exagTwistMag).
- `public float ExagMag { set; }`
  - Exaggerate bullet spine Lean magnitude.
- `public float ExagSmooth2Zero { set; }`
  - Exaggerate bullet duration ramping to zero after exagDuration.
- `public float ExagTwistMag { set; }`
  - Exaggerate bullet spine Twist magnitude.
- `public float ExagZeroTime { set; }`
  - Exaggerate bullet time spent at 0 spine lean/twist after exagDuration + exagSmooth2Zero.
- `public int FallingReaction { set; }`
  - 0=Rollup, 1=Catchfall, 2=rollDownStairs, 3=smartFall.
- `public bool Fling { set; }`
  - Type of reaction.
- `public float FlingTime { set; }`
  - Duration of the fling behavior.
- `public float FlingWidth { set; }`
  - Width of the fling behavior.
- `public float GrabHoldTime { set; }`
  - How long to hold for before returning to relaxed arm position.
- `public float InitialNeckDamping { set; }`
  - Intial damping of neck after being shot.
- `public float InitialNeckDuration { set; }`
  - Duration for which the neck stays at intial stiffness/damping.
- `public float InitialNeckRampDuration { set; }`
  - Duration of the ramp to bring the neck stiffness/damping back to normal levels.
- `public float InitialNeckStiffness { set; }`
  - Initial stiffness of neck after being shot.
- `public float InitialWeaknessRampDuration { set; }`
  - Duration of the ramp to bring the character's upper body stiffness back to normal levels.
- `public float InitialWeaknessZeroDuration { set; }`
  - Duration for which the character's upper body stays at minimum stiffness (not quite zero).
- `public float KMult4Legs { set; }`
  - How much to add to leg stiffnesses dependent on looseness.
- `public float KMultOnLoose { set; }`
  - How much to add to upperbody stiffness dependent on looseness.
- `public float Looseness4Fall { set; }`
  - How loose the character is made by a newBullet if falling.
- `public float Looseness4Stagger { set; }`
  - How loose the upperBody of the character is made by a newBullet if staggerFall is running (and not falling). Note atm the neck ramp values are ignored in staggerFall.
- `public float LoosenessAmount { set; }`
  - How loose the character is made by a newBullet. Between 0 and 1.
- `public bool Melee { set; }`
- `public float MinArmsLooseness { set; }`
  - Minimum looseness to apply to the arms.
- `public float MinLegsLooseness { set; }`
  - Minimum looseness to apply to the Legs.
- `public float NeckDamping { set; }`
  - Damping of neck.
- `public float NeckStiffness { set; }`
  - Stiffness of neck.
- `public bool ReachForWound { set; }`
  - Type of reaction.
- `public bool SpineBlendExagCPain { set; }`
  - True: spine is blended with zero pose, false: spine is blended with zero pose if not setting exag or cpain.
- `public float SpineBlendZero { set; }`
  - Spine is always blended with zero pose this much and up to 1 as the character become stationary. If negative no blend is ever applied.
- `public float SpineDamping { set; }`
  - Stiffness of body. Feeds through to roll_up.
- `public bool StableHandsAndNeck { set; }`
  - Additional stability for hands and neck (less loose).
- `public float TimeBeforeReachForWound { set; }`
  - Time, in seconds, before the character begins to grab for the wound on the first hit.
- `public bool UseCStrModulation { set; }`
  - If enabled upper and lower body strength scales with character strength, using the range given by parameters below.
- `public bool UseExtendedCatchFall { set; }`
  - Keep the character active instead of relaxing at the end of the catch fall.

## ShotInGutsHelper

class `GTA.NaturalMotion.ShotInGutsHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Configure the shot in guts reaction.

### Constructors

- `public ShotInGutsHelper(Ped ped)`
  - Creates a new Instance of the ShotInGutsHelper for sending a ShotInGuts `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotInGuts `Message` to.

### Properties

- `public bool ShotInGuts { set; }`
  - Type of reaction.
- `public float SigForceBalancePeriod { set; }`
  - Amount of time not taking a step.
- `public float SigHipAmount { set; }`
  - Hip Pitch.
- `public float SigKneeAmount { set; }`
  - Knee bend.
- `public float SigKneesOnset { set; }`
  - Amount of time not taking a step.
- `public float SigNeckAmount { set; }`
  - Neck Bend.
- `public float SigPeriod { set; }`
  - Active time after being shot.
- `public float SigSpineAmount { set; }`
  - SpineBend.

## ShotNewBulletHelper

class `GTA.NaturalMotion.ShotNewBulletHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Send new wound information to the shot. Can cause shot to restart it's performance in part or in whole.

### Constructors

- `public ShotNewBulletHelper(Ped ped)`
  - Creates a new Instance of the ShotNewBulletHelper for sending a ShotNewBullet `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotNewBullet `Message` to.

### Properties

- `public int BodyPart { set; }`
  - Part ID on the body where the bullet hit.
- `public Vector3 BulletVel { set; }`
  - Bullet velocity in world coordinates.
- `public Vector3 HitPoint { set; }`
  - Position of impact on character. Can be local or global depending on localHitPointInfo.
- `public bool LocalHitPointInfo { set; }`
  - If true then normal and hitPoint should be supplied in local coordinates of bodyPart. If false then normal and hitPoint should be supplied in World coordinates.
- `public Vector3 Normal { set; }`
  - Normal coming out of impact point on character. Can be local or global depending on localHitPointInfo.

## ShotRelaxHelper

class `GTA.NaturalMotion.ShotRelaxHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ShotRelaxHelper(Ped ped)`
  - Creates a new Instance of the ShotRelaxHelper for sending a ShotRelax `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotRelax `Message` to.

### Properties

- `public float RelaxPeriodLower { set; }`
  - Time over which to relax to full relaxation for lower body.
- `public float RelaxPeriodUpper { set; }`
  - Time over which to relax to full relaxation for upper body.

## ShotShockSpinHelper

class `GTA.NaturalMotion.ShotShockSpinHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Configure the shockSpin effect in shot. Spin/Lift the character using cheat torques/forces.

### Constructors

- `public ShotShockSpinHelper(Ped ped)`
  - Creates a new Instance of the ShotShockSpinHelper for sending a ShotShockSpin `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotShockSpin `Message` to.

### Properties

- `public bool AddShockSpin { set; }`
  - If enabled, add a short 'shock' of torque to the character's spine to exaggerate bullet impact.
- `public bool AlwaysAddShockSpin { set; }`
  - If true, apply the shock spin no matter which body component was hit. Otherwise only apply if the spine or clavicles get hit.
- `public float BracedSideSpinMult { set; }`
  - If shot on a side with a forward foot and both feet are on the ground and balanced, increase the shockspin to compensate for the balancer naturally resisting spin to that side.
- `public bool RandomizeShockSpinDirection { set; }`
  - For use with close-range shotgun blasts, or similar.
- `public float ShockSpin1FootMult { set; }`
  - ShockSpin's torque is multipied by this value when the one of the character's feet are not in contact.
- `public float ShockSpinAirMult { set; }`
  - ShockSpin's torque is multipied by this value when both the character's feet are not in contact.
- `public float ShockSpinDecayMult { set; }`
  - Multiplier used when decaying torque spin over time.
- `public float ShockSpinFootGripMult { set; }`
  - ShockSpin scales the torques applied to the feet by footSlipCompensation.
- `public float ShockSpinLiftForceMult { set; }`
  - If greater than 0, apply a force to lift the character up while the torque is applied, trying to produce a dramatic spun/twist shotgun-to-the-chest effect. This is a scale of the torque applied, so 8.0 or so would give a reasonable amount of lift.
- `public float ShockSpinMax { set; }`
  - Maximum amount of torque to add if using shock-spin feature.
- `public float ShockSpinMaxTwistVel { set; }`
  - Shock spin ends when twist velocity is greater than this value (try 6.0). If set to -1 does not stop.
- `public float ShockSpinMin { set; }`
  - Minimum amount of torque to add if using shock-spin feature.
- `public bool ShockSpinScaleByLeverArm { set; }`
  - Shock spin scales by lever arm of bullet i.e. bullet impact point to center line.
- `public float ShockSpinScalePerComponent { set; }`
  - Torque applied is scaled by this amount across the spine components - spine2 recieving the full amount, then 3 and 1 and finally 0. Each time, this value is used to scale it down. 0.5 means half the torque each time.

## ShotSnapHelper

class `GTA.NaturalMotion.ShotSnapHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ShotSnapHelper(Ped ped)`
  - Creates a new Instance of the ShotSnapHelper for sending a ShotSnap `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the ShotSnap `Message` to.

### Properties

- `public bool Snap { set; }`
  - Add a Snap to shot.
- `public float SnapAirborneMult { set; }`
  - AirborneMult*snapMag = The magnitude of the reaction if airborne.
- `public float SnapBalancingMult { set; }`
  - BalancingMult*snapMag = The magnitude of the reaction if balancing = (not lying on the floor/ not upper body not collided) and not airborne.
- `public float SnapDirectionRandomness { set; }`
  - The character snaps in a prescribed way (decided by bullet direction) - Higher the value the more random this direction is.
- `public int SnapHipType { set; }`
  - Type of hip reaction 0=none, 1=side2side 2=steplike.
- `public bool SnapHitPart { set; }`
  - Snap only around the wounded part//mmmmtodo check whether bodyPart doesn't have to be remembered for unSnap.
- `public bool SnapLeftArm { set; }`
  - Snap the leftArm.
- `public bool SnapLeftLeg { set; }`
  - Snap the leftLeg.
- `public float SnapMag { set; }`
  - The magnitude of the reaction.
- `public float SnapMovingMult { set; }`
  - MovingMult*snapMag = The magnitude of the reaction if moving(comVelMag) faster than movingThresh.
- `public float SnapMovingThresh { set; }`
  - If moving(comVelMag) faster than movingThresh then mvingMult applied to stunMag.
- `public bool SnapNeck { set; }`
  - Snap the neck.
- `public bool SnapPhasedLegs { set; }`
  - Legs are either in phase with each other or not.
- `public bool SnapRightArm { set; }`
  - Snap the rightArm.
- `public bool SnapRightLeg { set; }`
  - Snap the rightLeg.
- `public bool SnapSpine { set; }`
  - Snap the spine.
- `public bool SnapUseBulletDir { set; }`
  - Legs are either in phase with each other or not.
- `public bool SnapUseTorques { set; }`
  - Use torques to make the snap otherwise use a change in the parts angular velocity.
- `public float UnSnapInterval { set; }`
  - Interval before applying reverse snap.
- `public float UnSnapRatio { set; }`
  - The magnitude of the reverse snap.

## SmartFallHelper

class `GTA.NaturalMotion.SmartFallHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Clone of High Fall with a wider range of operating conditions.

### Constructors

- `public SmartFallHelper(Ped ped)`
  - Creates a new Instance of the SmartFallHelper for sending a SmartFall `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the SmartFall `Message` to.

### Properties

- `public bool AdaptiveCircling { set; }`
  - Stunt man type fall. Arm and legs circling direction controlled by angmom and orientation.
- `public float AimAngleBase { set; }`
  - Angle from vertical the pdController is driving to (positive = forwards).
- `public bool AlanRickman { set; }`
  - If true then orientate the character to face the point from where it started falling. High fall like the one in "Die Hard" with Alan Rickman.
- `public float ArmAmplitude { set; }`
  - In armWindMillAdaptive.
- `public float ArmAngSpeed { set; }`
  - Arm circling speed in armWindMillAdaptive.
- `public bool ArmBendElbows { set; }`
  - In armWindMillAdaptive bend the elbows as a function of armAngle. For stunt man true otherwise false.
- `public float ArmPhase { set; }`
  - In armWindMillAdaptive 3.1 opposite for stuntman. 1.0 old default. 0.0 in phase.
- `public float Arms2LegsPhase { set; }`
  - Phase angle between the arms and legs circling angle.
- `public Synchroisation Arms2LegsSync { set; }`
  - Syncs the arms angle to what the leg angle is.
- `public float ArmsUp { set; }`
  - Where to put the arms when preparing to land. Approx 1 = above head, 0 = head height, -1 = down. LT -2.0 use catchFall arms, LT -3.0 use prepare for landing pose if Agent is due to land vertically, feet first.
- `public bool Balance { set; }`
  - If true have enough strength to balance. If false not enough strength in legs to balance (even though bodyBlance called).
- `public float BlendHeadWhenStopped { set; }`
  - Blend head to neutral pose com vel approaches zero. Linear between zero and value. Set to zero to disable.
- `public float Bodydamping { set; }`
  - The damping of the joints.
- `public float BodyStiffness { set; }`
  - Stiffness of body. Value feeds through to bodyBalance (synced with defaults), to armsWindmill (14 for this value at default ), legs pedal, head look and roll down stairs directly.
- `public float CatchFallCutOff { set; }`
  - 0.5angle is 0.878 dot. Cutoff to go to the catchFall (internal) //mmmtodo do like crashOrLandCutOff.
- `public float Catchfalltime { set; }`
  - The length of time before the impact that the character transitions to the landing.
- `public float CfZAxisSpinReduction { set; }`
  - Pass-through parameter for Catch Fall spin reduction. Increase to stop more spin. 0..1.
- `public bool ChangeExtremityFriction { set; }`
  - Allow friction changes to be applied to the hands and feet.
- `public float CrashOrLandCutOff { set; }`
  - 0.52angle is 0.868 dot//A threshold for deciding how far away from upright the character needs to be before bailing out (going into a foetal) instead of trying to land (keeping stretched out). NB: never does bailout if ignorWorldCollisions true.
- `public float FootVelCompScale { set; }`
  - Scale to change to amount of vel that is added to the foot ik from the velocity (Internal).
- `public bool ForceHeadAvoid { set; }`
  - Force head avoid to be active during Catch Fall even when character is not on the ground.
- `public float FowardOffsetOfLegIK { set; }`
  - Forward offset for the feet during prepareForLanding.
- `public bool FowardRoll { set; }`
  - Try to execute a forward Roll on landing.
- `public float FowardVelRotation { set; }`
  - Scale to add/subtract from aimAngle based on forward speed (Internal).
- `public bool Hula { set; }`
  - With stunt man type fall. Hula reaction if can't see floor and not rotating fast.
- `public bool IgnorWorldCollisions { set; }`
  - Never go into bailout (foetal).
- `public int InitialState { set; }`
  - Force initial state (used in vehicle bail out to start SF_CatchFall (6) earlier.
- `public float LandingNormal { set; }`
  - Ray-cast normal doted with up direction has to be greater than this number to consider object flat enough to land on it.
- `public float LegAngSpeed { set; }`
  - In pedal.
- `public float LegAsymmetry { set; }`
  - 0.0 for stunt man. Random offset applied per leg to the angular speed to desynchronize the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
- `public float LegL { set; }`
  - Leg Length for ik (Internal)//unused.
- `public float LegRadius { set; }`
  - Radius of legs on pedal.
- `public float LegStrength { set; }`
  - Strength of the legs at landing.
- `public float MaxSpeedForRecoverableFall { set; }`
  - Character needs to be moving less than this speed to consider fall as a recoverable one.
- `public float MinSpeedForBrace { set; }`
  - Character needs to be moving at least this fast horizontally to start bracing for impact if there is an object along its trajectory.
- `public bool OrientateBodyToFallDirection { set; }`
  - Toggle to orientate to fall direction. i.e. orientate so that the character faces the horizontal velocity direction.
- `public float OrientateMax { set; }`
  - DEVEL parameter - suggest you don't edit it. Maximum torque the orientation controller can apply. If 0 then no helper torques will be used. 300 will orientate the character softly for all but extreme angles away from aimAngleBase. If abs (current -aimAngleBase) is getting near 3.0 then this can be reduced to give a softer feel.
- `public bool OrientateTwist { set; }`
  - If false don't worry about the twist angle of the character when orientating the character. If false this allows the twist axis of the character to be free (You can get a nice twisting highFall like the one in dieHard 4 when the car goes into the helicopter).
- `public float PdDamping { set; }`
  - Damping multiplier of the controller to keep the character at angle aimAngleBase from vertical. The actual damping is pdDamping*pdStrength*constant*angVel.
- `public float PdStrength { set; }`
  - Strength of the controller to keep the character at angle aimAngleBase from vertical.
- `public float RdsForceMag { set; }`
- `public float RdsForceVelThreshold { set; }`
  - Velocity threshold under which RDS force mag will be applied.
- `public float RdsStartingFriction { set; }`
  - Catch Fall/RDS starting friction. Catch fall will overwrite based on setFallingReaction.
- `public float RdsStartingFrictionMin { set; }`
  - Catch Fall/RDS starting friction minimum. Catch fall will overwrite based on setFallingReaction.
- `public float RdsTargetLinearVelocity { set; }`
  - RDS: Helper torques are applied to match the spin of the character to the max of targetLinearVelocity and COMVelMag. -1 to use initial character velocity.
- `public float RdsTargetLinVeDecayTime { set; }`
  - RDS: Time for the targetlinearVelocity to decay to zero.
- `public bool RdsUseStartingFriction { set; }`
  - Start Catch Fall/RDS state with specified friction. Catch fall will overwrite based on setFallingReaction.
- `public string ReboundMask { set; }`
  - Part mask to apply rebound assistance.
- `public float ReboundScale { set; }`
  - Scale for rebound assistance. 0 = off, 1 = very bouncy, 2 = jbone crazy.
- `public float SideD { set; }`
  - Sideoffset for the feet during prepareForLanding. +ve = right.
- `public float SplatWhenStopped { set; }`
  - Transition to splat state when com vel is below value, regardless of character health or fall velocity. Set to zero to disable.
- `public float SpreadLegs { set; }`
  - Spread legs amount for pedal during fall.
- `public float StopRollingTime { set; }`
  - Time in seconds before ped should start actively trying to stop rolling.
- `public bool Teeter { set; }`
  - Set up an immediate teeter in the direction of trave if initial state is SF_Balance.
- `public float TeeterOffset { set; }`
  - Offset the default Teeter edge in the direction of travel. Will need to be tweaked depending on how close to the real edge AI tends to trigger the behavior.
- `public bool UseZeroPose_withFowardRoll { set; }`
  - Blend to a zero pose when forward roll is attempted.

## StaggerFallHelper

class `GTA.NaturalMotion.StaggerFallHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public StaggerFallHelper(Ped ped)`
  - Creates a new Instance of the StaggerFallHelper for sending a StaggerFall `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the StaggerFall `Message` to.

### Properties

- `public bool AlwaysBendForwards { set; }`
  - Bend forwards at the hip (hipBendMult) whether moving backwards or forwards.
- `public float ArmDamping { set; }`
  - Sets damping value for the arms.
- `public float ArmDampingStart { set; }`
  - ArmDamping during the yanked timescale i.e. timeAtStartValues.
- `public float ArmStiffness { set; }`
  - Stiffness of arms. Catch_fall's stiffness scales with this value, but has default values when this is default.
- `public float ArmStiffnessStart { set; }`
  - ArmStiffness during the yanked timescale i.e. timeAtStartValues.
- `public float HeadLookAtVelProb { set; }`
  - Probability [0-1] that headLook will be looking in the direction of velocity when stepping.
- `public int HeadLookInstanceIndex { set; }`
  - Level index of thing to look at.
- `public Vector3 HeadLookPos { set; }`
  - Position of thing to look at.
- `public float HipBendMult { set; }`
  - HipBend scaled with velocity.
- `public float Lean2multB { set; }`
  - Lean of spine to side in side velocity direction when going backwards.
- `public float Lean2multF { set; }`
  - Lean of spine to side in side velocity direction when going forwards.
- `public float LeanHipsMaxB { set; }`
  - Max of leanInDirectionHips magnitude when going backwards.
- `public float LeanHipsMaxF { set; }`
  - Max of leanInDirectionHips magnitude when going forwards.
- `public float LeanInDirMaxB { set; }`
  - Max of leanInDirection magnitude when going backwards.
- `public float LeanInDirMaxF { set; }`
  - Max of leanInDirection magnitude when going forwards.
- `public float LeanInDirRate { set; }`
  - LeanInDirection will be increased from 0 to leanInDirMax linearly at this rate.
- `public float LowerBodyStiffness { set; }`
  - LowerBodyStiffness should be 12.
- `public float LowerBodyStiffnessEnd { set; }`
  - LowerBodyStiffness at end.
- `public float MaxPushoffVel { set; }`
  - Stance leg will only pushOff to increase momentum if the vertical hip velocity is less than this value. 0.4 seems like a good value. The higher it is the less this functionality is applied. If it is very low or negative this can stop the pushOff altogether.
- `public float PerStepReduction1 { set; }`
  - LowerBody stiffness will be reduced every step to make the character fallover.
- `public float PredictionTime { set; }`
  - Amount of time (seconds) into the future that the character tries to step to. Bigger values try to recover with fewer, bigger steps. Smaller values recover with smaller steps, and generally recover less.
- `public float PushOffDist { set; }`
  - Amount stance foot is behind com in the direction of velocity before the leg tries to pushOff to increase momentum. Increase to lower the probability of the pushOff making the character bouncy.
- `public float RampTimeFromStartValues { set; }`
  - Time spent ramping from Start to end values for arms and spine stiffness and damping i.e. for whiplash effect (occurs after timeAtStartValues).
- `public float RampTimeToEndValues { set; }`
  - Time spent ramping from lowerBodyStiffness to lowerBodyStiffnessEnd.
- `public float SpineBendMult { set; }`
  - Spine bend scaled with velocity.
- `public float SpineDamping { set; }`
- `public float SpineDampingStart { set; }`
  - SpineDamping during the yanked timescale i.e. timeAtStartValues.
- `public float SpineStiffness { set; }`
- `public float SpineStiffnessStart { set; }`
  - SpineStiffness during the yanked timescale i.e. timeAtStartValues.
- `public float StaggerStepProb { set; }`
  - Probability per step of time spent in a stagger step.
- `public int StepsTillStartEnd { set; }`
  - Steps taken before lowerBodyStiffness starts ramping down by perStepReduction1.
- `public float TimeAtStartValues { set; }`
  - Time spent with Start values for arms and spine stiffness and damping i.e. for whiplash effect.
- `public float TimeStartEnd { set; }`
  - Time from start of behavior before lowerBodyStiffness starts ramping down for rampTimeToEndValues to endValues.
- `public float Turn2TargetProb { set; }`
  - Weighted probability of turning towards headLook target. This is one of six turn type weights.
- `public float Turn2VelProb { set; }`
  - Weighted probability of turning towards velocity. This is one of six turn type weights.
- `public float TurnAwayProb { set; }`
  - Weighted probability of turning away from headLook target. This is one of six turn type weights.
- `public float TurnLeftProb { set; }`
  - Weighted probability of turning left. This is one of six turn type weights.
- `public float TurnOffProb { set; }`
  - Weighted probability that turn will be off. This is one of six turn type weights.
- `public float TurnRightProb { set; }`
  - Weighted probability of turning right. This is one of six turn type weights.
- `public bool UpperBodyReaction { set; }`
  - Enable upper body reaction i.e. blindBrace and armswindmill.
- `public bool UseBodyTurn { set; }`
  - Enable and provide a positive bodyTurnTimeout and provide a look-at target to make the character turn to face it while balancing.
- `public bool UseHeadLook { set; }`
  - Enable and provide a look-at target to make the character's head turn to face it while balancing, balancer default is 0.2.

## StayUprightHelper

class `GTA.NaturalMotion.StayUprightHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public StayUprightHelper(Ped ped)`
  - Creates a new Instance of the StayUprightHelper for sending a StayUpright `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the StayUpright `Message` to.

### Properties

- `public float ForceDamping { set; }`
  - Damping in constraint: -1 makes it scale automagically with forceStrength. Other negative values will scale this automagic damping.
- `public float ForceFeetMult { set; }`
  - Multiplier to the force applied to the feet.
- `public float ForceInAirShare { set; }`
  - Share of the feet force to the airborne foot.
- `public float ForceLeanReduction { set; }`
  - How much the character lean is taken into account when reducing the force.
- `public float ForceMax { set; }`
  - See above.
- `public float ForceMin { set; }`
  - When min and max are greater than 0 the constraint strength is determined from character strength, scaled into the range given by min and max.
- `public float ForceSaturationVel { set; }`
  - When in velocityBased mode, the COM velocity at which constraint reaches maximum strength (forceStrength).
- `public float ForceSpine3Share { set; }`
  - Share of pelvis force applied to spine3.
- `public float ForceStrength { set; }`
  - Strength of constraint.
- `public float ForceThresholdVel { set; }`
  - When in velocityBased mode, the COM velocity above which constraint starts applying forces.
- `public float LastStandHorizDamping { set; }`
  - Higher values for more damping.
- `public float LastStandMaxTime { set; }`
  - Max time allowed in last stand mode.
- `public bool LastStandMode { set; }`
  - Uses position/orientation control on the spine and drifts in the direction of bullets. This ignores all other stayUpright settings.
- `public float LastStandSinkRate { set; }`
  - The sink rate (higher for a faster drop).
- `public float NoSupportForceMult { set; }`
  - Still apply this fraction of the upright constaint force if the foot is not in a position (defined by supportPosition) to generate the support for the upright constraint.
- `public float StayUpAcc { set; }`
  - How much the cheat force takes into account the acceleration of moving platforms.
- `public float StayUpAccMax { set; }`
  - The maximum floorAcceleration (of a moving platform) that the cheat force takes into account.
- `public float StepUpHelp { set; }`
  - Strength of cheat force applied upwards to spine3 to help the character up steps/slopes.
- `public float SupportPosition { set; }`
  - Distance the foot is behind Com projection that is still considered able to generate the support for the upright constraint.
- `public float TorqueDamping { set; }`
  - Damping of torque based constraint.
- `public bool TorqueOnlyInAir { set; }`
  - Only apply torque based constraint when airBorne.
- `public float TorqueSaturationVel { set; }`
  - When in velocityBased mode, the COM velocity at which constraint reaches maximum strength (torqueStrength).
- `public float TorqueStrength { set; }`
  - Strength of torque based constraint.
- `public float TorqueThresholdVel { set; }`
  - When in velocityBased mode, the COM velocity above which constraint starts applying torques.
- `public bool TurnTowardsBullets { set; }`
  - Use cheat torques to face the direction of bullets if not facing too far away.
- `public bool UseForces { set; }`
  - Enable force based constraint.
- `public bool UseTorques { set; }`
  - Enable torque based constraint.
- `public bool VelocityBased { set; }`
  - Make strength of constraint function of COM velocity. Uses -1 for forceDamping if the damping is positive.

## StopAllBehavioursHelper

class `GTA.NaturalMotion.StopAllBehavioursHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

Send this message to immediately stop all behaviors from executing.

### Constructors

- `public StopAllBehavioursHelper(Ped ped)`
  - Creates a new Instance of the StopAllBehaviorsHelper for sending a StopAllBehaviors `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the StopAllBehaviors `Message` to.

## Synchroisation

enum `GTA.NaturalMotion.Synchroisation`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `NotSynced` | 0 |
| `AlwaysSynced` | 1 |
| `SyncedAtStart` | 2 |

## TeeterHelper

class `GTA.NaturalMotion.TeeterHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public TeeterHelper(Ped ped)`
  - Creates a new Instance of the TeeterHelper for sending a Teeter `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Teeter `Message` to.

### Properties

- `public bool CallHighFall { set; }`
  - Call highFall if fallen over the edge. If false just call blended writhe (to go over the top of the fall behavior of the underlying behavior e.g. bodyBalance).
- `public Vector3 EdgeLeft { set; }`
  - Defines the left edge point (left of character facing edge).
- `public Vector3 EdgeRight { set; }`
  - Defines the right edge point (right of character facing edge).
- `public bool LeanAway { set; }`
  - Lean away from the edge based on velocity towards the edge (if closer than 2m from edge).
- `public float LeanAwayScale { set; }`
  - Scales stay upright lean and hip pitch.
- `public float LeanAwayTime { set; }`
  - Time-to-edge threshold to start leaning away from a potential fall.
- `public float PreTeeterTime { set; }`
  - Time-to-edge threshold to start pre-teeter (windmilling, etc).
- `public float TeeterTime { set; }`
  - Time-to-edge threshold to start full-on teeter (more aggressive lean, drop-and-twist, etc).
- `public bool UseExclusionZone { set; }`
  - Stop stepping across the line defined by edgeLeft and edgeRight.
- `public bool UseHeadLook { set; }`

## TorqueFilterMode

enum `GTA.NaturalMotion.TorqueFilterMode`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `ApplyEveryBullet` | 0 |
| `ApplyIfLastFinished` | 1 |
| `ApplyIfSpinDifferent` | 2 |

## TorqueMode

enum `GTA.NaturalMotion.TorqueMode`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Disabled` | 0 |
| `Proportional` | 1 |
| `Additive` | 2 |

## TorqueSpinMode

enum `GTA.NaturalMotion.TorqueSpinMode`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `FromImpulse` | 0 |
| `Random` | 1 |
| `Flipping` | 2 |

## TurnType

enum `GTA.NaturalMotion.TurnType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `DontTurn` | 0 |
| `ToTarget` | 1 |
| `AwayFromTarget` | 2 |

## UpperBodyFlinchHelper

class `GTA.NaturalMotion.UpperBodyFlinchHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public UpperBodyFlinchHelper(Ped ped)`
  - Creates a new Instance of the UpperBodyFlinchHelper for sending a UpperBodyFlinch `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the UpperBodyFlinch `Message` to.

### Properties

- `public bool ApplyStiffness { set; }`
  - Turned of by bcr.
- `public float BackBendAmount { set; }`
  - Amount to bend the back during the flinch.
- `public float BodyDamping { set; }`
  - Damping value used for upper body.
- `public float BodyStiffness { set; }`
  - Stiffness of body. Value carries over to head look, spine twist.
- `public bool DontBraceHead { set; }`
  - Don't protect head only brace from front. Turned on by bcr.
- `public float HandDistanceFrontBack { set; }`
  - Front-Back distance between the hands.
- `public float HandDistanceLeftRight { set; }`
  - Left-Right distance between the hands.
- `public float HandDistanceVertical { set; }`
  - Vertical distance between the hands.
- `public bool HeadLookAwayFromTarget { set; }`
  - Look away from target (unless protecting head then look between feet).
- `public bool NewHit { set; }`
  - Relaxes the character for 1 frame if set.
- `public float NoiseScale { set; }`
  - Amplitude of the perlin noise applied to the arms positions in the flinch to the front part of the behavior.
- `public Vector3 Pos { set; }`
  - Position in world-space of object to flinch from.
- `public bool ProtectHeadToggle { set; }`
  - Always protect head. Note if false then character flinches if target is in front, protects head if target is behind.
- `public int TurnTowards { set; }`
  - Ve balancer turn Towards, negative balancer turn Away, 0 balancer won't turn. There is a 50% chance that the character will not turn even if this parameter is set to turn.
- `public bool UseHeadLook { set; }`
  - Use headlook.
- `public bool UseLeftArm { set; }`
  - Toggle to Use the Left arm.
- `public bool UseRightArm { set; }`
  - Toggle to use the right arm.

## WeaponMode

enum `GTA.NaturalMotion.WeaponMode`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `None` | -1 |
| `Pistol` | 0 |
| `Dual` | 1 |
| `Rifle` | 2 |
| `SideArm` | 3 |
| `PistolLeft` | 4 |
| `PistolRight` | 5 |

## YankedHelper

class `GTA.NaturalMotion.YankedHelper` : `CustomHelper`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public YankedHelper(Ped ped)`
  - Creates a new Instance of the YankedHelper for sending a Yanked `Message` to a given `Ped`.
  - `ped`: The `Ped` to send the Yanked `Message` to.

### Properties

- `public float ArmDamping { set; }`
  - Sets damping value for the arms when upright.
- `public float ArmDampingStart { set; }`
  - Arm damping during the yanked timescale i.e. timeAtStartValues.
- `public float ArmStiffness { set; }`
  - Stiffness of arms when upright.
- `public float ArmStiffnessStart { set; }`
  - Arm stiffness during the yanked timescale i.e. timeAtStartValues.
- `public float ComVelRDSThresh { set; }`
  - For handsAndKnees catchfall ONLY: comVel above which rollDownstairs will start.
- `public float FootFriction { set; }`
  - Foot friction when standing/stepping. 0.5 gives a good slide sometimes.
- `public float GroundArmDamping { set; }`
  - Arm Damping when on the ground.
- `public float GroundArmStiffness { set; }`
  - Arm Stiffness when on the ground.
- `public float GroundFriction { set; }`
  - Friction multiplier on body parts when on ground. Character can look too slidy with groundFriction = 1. Higher values give a more jerky reaction but this seems timestep dependent especially for dragged by the feet.
- `public float GroundLegDamping { set; }`
  - Leg Damping when on the ground.
- `public float GroundLegStiffness { set; }`
  - Leg Stiffness when on the ground.
- `public float GroundSpineDamping { set; }`
  - Spine Damping when on the ground.
- `public float GroundSpineStiffness { set; }`
  - Spine Stiffness when on the ground.
- `public float HeadLookAtVelProb { set; }`
  - Probability [0-1] that headLook will be looking in the direction of velocity when stepping.
- `public int HeadLookInstanceIndex { set; }`
  - Level index of thing to look at.
- `public Vector3 HeadLookPos { set; }`
  - Position of thing to look at.
- `public float HipAmplitude { set; }`
  - Amount of hip movement.
- `public float HipPitchBack { set; }`
  - Amount to bend backwards at the hips (+ve backwards, -ve forwards). Behavior switches between hipPitchForward and hipPitchBack.
- `public float HipPitchForward { set; }`
  - Amount to bend forward at the hips (+ve forward, -ve backwards). Behavior switches between hipPitchForward and hipPitchBack.
- `public float HulaPeriod { set; }`
  - 0.25 A complete wiggle will take 4*hulaPeriod.
- `public float LowerBodyStiffness { set; }`
  - LowerBodyStiffness should be 12.
- `public float LowerBodyStiffnessEnd { set; }`
  - LowerBodyStiffness at end.
- `public float MaxRelaxPeriod { set; }`
  - Wriggle relaxes for a maximum of maxRelaxPeriod (if it is negative it is a multiplier on the time previously spent wriggling).
- `public float MinRelaxPeriod { set; }`
  - Wriggle relaxes for a minimum of minRelaxPeriod (if it is negative it is a multiplier on the time previously spent wriggling).
- `public float PerStepReduction { set; }`
  - LowerBody stiffness will be reduced every step to make the character fallover.
- `public float RampTimeFromStartValues { set; }`
  - Time spent ramping from Start to end values for arms and spine stiffness and damping i.e. for whiplash effect (occurs after timeAtStartValues).
- `public float RampTimeToEndValues { set; }`
  - Time spent ramping from lowerBodyStiffness to lowerBodyStiffnessEnd.
- `public float RollHelp { set; }`
  - Amount of cheat torque applied to turn the character over.
- `public float SpineAmplitude { set; }`
  - Amount of spine movement.
- `public float SpineBend { set; }`
  - Bend/Twist the spine amount.
- `public float SpineDamping { set; }`
  - Spine damping when upright.
- `public float SpineDampingStart { set; }`
  - Spine damping during the yanked timescale i.e. timeAtStartValues.
- `public float SpineStiffness { set; }`
  - Spine stiffness when upright.
- `public float SpineStiffnessStart { set; }`
  - Spine stiffness during the yanked timescale i.e. timeAtStartValues.
- `public int StepsTillStartEnd { set; }`
  - Steps taken before lowerBodyStiffness starts ramping down.
- `public float TimeAtStartValues { set; }`
  - Time spent with Start values for arms and spine stiffness and damping i.e. for whiplash effect.
- `public float TimeStartEnd { set; }`
  - Time from start of behavior before lowerBodyStiffness starts ramping down by perStepReduction1.
- `public float TurnThresholdMax { set; }`
  - Max angle at which the turn with toggle to the other direction (actual toggle angle is chosen randomly in range min to max). If it is 1 then it will never toggle. If negative then no turn is applied.
- `public float TurnThresholdMin { set; }`
  - Min angle at which the turn with toggle to the other direction (actual toggle angle is chosen randomly in range min to max). If it is 1 then it will never toggle. If negative then no turn is applied.
- `public bool UseHeadLook { set; }`
  - Enable and provide a look-at target to make the character's head turn to face it while balancing.

