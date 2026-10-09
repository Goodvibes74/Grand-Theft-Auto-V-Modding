# ScriptHookVDotNet v2 (legacy) API reference

> **Source:** `ScriptHookVDotNet2.dll` (file version 2.11.6, assembly version 2.11.6.0, 984,576 bytes, modified 2026-08-05, SHA-256 `8f9ec05e5ccf83781ef4abe45abfb51d8231e4fc9ee2b56884caf00d5a642594`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `ScriptHookVDotNet2.xml` from the NuGet package `scripthookvdotnet2` 2.11.6 (nuget.org), the same version as the installed DLL.

Generated: don't edit by hand, re-run the generator instead.

Only for old mods. Write new scripts against v3. Mods built against the pre-2.10 API name `ScriptHookVDotNet` 0.0.0.0 (Cop_Arrest, Disarm, MapEditor, Stance) also run on this API: SHVDN redirects them here, as `ScriptHookVDotNet.log` shows.

215 public types.

## [GTA](GTA.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`AnimationFlags`](GTA.md#animationflags) | enum |  |
| [`Audio`](GTA.md#audio) | static class |  |
| [`AudioFlag`](GTA.md#audioflag) | enum |  |
| [`Blip`](GTA.md#blip) | class |  |
| [`BlipColor`](GTA.md#blipcolor) | enum |  |
| [`BlipSprite`](GTA.md#blipsprite) | enum |  |
| [`Bone`](GTA.md#bone) | enum |  |
| [`Camera`](GTA.md#camera) | class |  |
| [`CameraShake`](GTA.md#camerashake) | enum |  |
| [`CargobobHook`](GTA.md#cargobobhook) | enum |  |
| [`Control`](GTA.md#control) | enum |  |
| [`DlcWeaponComponentData.<desc>e__FixedBuffer`](GTA.md#dlcweaponcomponentdatadesce__fixedbuffer) | struct |  |
| [`DlcWeaponComponentData.<name>e__FixedBuffer`](GTA.md#dlcweaponcomponentdatanamee__fixedbuffer) | struct |  |
| [`DlcWeaponData.<desc>e__FixedBuffer`](GTA.md#dlcweapondatadesce__fixedbuffer) | struct |  |
| [`DlcWeaponData.<name>e__FixedBuffer`](GTA.md#dlcweapondatanamee__fixedbuffer) | struct |  |
| [`DlcWeaponData.<simpleDesc>e__FixedBuffer`](GTA.md#dlcweapondatasimpledesce__fixedbuffer) | struct |  |
| [`DlcWeaponData.<upperCaseName>e__FixedBuffer`](GTA.md#dlcweapondatauppercasenamee__fixedbuffer) | struct |  |
| [`DrivingStyle`](GTA.md#drivingstyle) | enum |  |
| [`Entity`](GTA.md#entity) | abstract class |  |
| [`ExplosionType`](GTA.md#explosiontype) | enum |  |
| [`FiringPattern`](GTA.md#firingpattern) | enum |  |
| [`Font`](GTA.md#font) | enum |  |
| [`ForceType`](GTA.md#forcetype) | enum |  |
| [`FormationType`](GTA.md#formationtype) | enum |  |
| [`Game`](GTA.md#game) | static class |  |
| [`GameplayCamera`](GTA.md#gameplaycamera) | static class |  |
| [`GameVersion`](GTA.md#gameversion) | enum |  |
| [`Gender`](GTA.md#gender) | enum |  |
| [`Global`](GTA.md#global) | struct |  |
| [`GlobalCollection`](GTA.md#globalcollection) | class |  |
| [`HelmetType`](GTA.md#helmettype) | enum |  |
| [`HudComponent`](GTA.md#hudcomponent) | enum |  |
| [`IHandleable`](GTA.md#ihandleable) | interface |  |
| [`IMenuItem`](GTA.md#imenuitem) | interface |  |
| [`InputMode`](GTA.md#inputmode) | enum |  |
| [`IntersectOptions`](GTA.md#intersectoptions) | enum |  |
| [`ISpatial`](GTA.md#ispatial) | interface |  |
| [`Language`](GTA.md#language) | enum |  |
| [`LeaveVehicleFlags`](GTA.md#leavevehicleflags) | enum |  |
| [`MarkerType`](GTA.md#markertype) | enum |  |
| [`Menu`](GTA.md#menu) | class |  |
| [`MenuBase`](GTA.md#menubase) | class |  |
| [`MenuButton`](GTA.md#menubutton) | class |  |
| [`MenuEnumScroller`](GTA.md#menuenumscroller) | class |  |
| [`MenuItemDoubleValueArgs`](GTA.md#menuitemdoublevalueargs) | class |  |
| [`MenuItemIndexArgs`](GTA.md#menuitemindexargs) | class |  |
| [`MenuLabel`](GTA.md#menulabel) | class |  |
| [`MenuNumericScroller`](GTA.md#menunumericscroller) | class |  |
| [`MenuToggle`](GTA.md#menutoggle) | class |  |
| [`MessageBox`](GTA.md#messagebox) | class |  |
| [`Model`](GTA.md#model) | struct |  |
| [`Notification`](GTA.md#notification) | class |  |
| [`NumberPlateMounting`](GTA.md#numberplatemounting) | enum |  |
| [`NumberPlateType`](GTA.md#numberplatetype) | enum |  |
| [`ParachuteTint`](GTA.md#parachutetint) | enum |  |
| [`Ped`](GTA.md#ped) | class |  |
| [`PedGroup`](GTA.md#pedgroup) | class |  |
| [`PedGroup.enumerator`](GTA.md#pedgroupenumerator) | class |  |
| [`Pickup`](GTA.md#pickup) | class |  |
| [`PickupType`](GTA.md#pickuptype) | enum |  |
| [`Player`](GTA.md#player) | class |  |
| [`Prop`](GTA.md#prop) | class |  |
| [`RadioStation`](GTA.md#radiostation) | enum |  |
| [`RaycastResult`](GTA.md#raycastresult) | struct |  |
| [`Relationship`](GTA.md#relationship) | enum |  |
| [`RequireScript`](GTA.md#requirescript) | class |  |
| [`Rope`](GTA.md#rope) | class |  |
| [`RopeType`](GTA.md#ropetype) | enum |  |
| [`Scaleform`](GTA.md#scaleform) | class |  |
| [`ScaleformArgumentTXD`](GTA.md#scaleformargumenttxd) | class |  |
| [`Script`](GTA.md#script) | abstract class |  |
| [`ScriptSettings`](GTA.md#scriptsettings) | class |  |
| [`SelectedIndexChangedArgs`](GTA.md#selectedindexchangedargs) | class |  |
| [`Tasks`](GTA.md#tasks) | class |  |
| [`TaskSequence`](GTA.md#tasksequence) | class |  |
| [`UI`](GTA.md#ui) | static class |  |
| [`UIContainer`](GTA.md#uicontainer) | class |  |
| [`UIElement`](GTA.md#uielement) | interface |  |
| [`UIRectangle`](GTA.md#uirectangle) | class |  |
| [`UISprite`](GTA.md#uisprite) | class |  |
| [`UIText`](GTA.md#uitext) | class |  |
| [`Vehicle`](GTA.md#vehicle) | class |  |
| [`VehicleClass`](GTA.md#vehicleclass) | enum |  |
| [`VehicleColor`](GTA.md#vehiclecolor) | enum |  |
| [`VehicleDoor`](GTA.md#vehicledoor) | enum |  |
| [`VehicleLandingGear`](GTA.md#vehiclelandinggear) | enum |  |
| [`VehicleLockStatus`](GTA.md#vehiclelockstatus) | enum |  |
| [`VehicleMod`](GTA.md#vehiclemod) | enum |  |
| [`VehicleNeonLight`](GTA.md#vehicleneonlight) | enum |  |
| [`VehicleRoofState`](GTA.md#vehicleroofstate) | enum |  |
| [`VehicleSeat`](GTA.md#vehicleseat) | enum |  |
| [`VehicleToggleMod`](GTA.md#vehicletogglemod) | enum |  |
| [`VehicleWheelType`](GTA.md#vehiclewheeltype) | enum |  |
| [`VehicleWindow`](GTA.md#vehiclewindow) | enum |  |
| [`VehicleWindowTint`](GTA.md#vehiclewindowtint) | enum |  |
| [`Viewport`](GTA.md#viewport) | class |  |
| [`Weapon`](GTA.md#weapon) | class |  |
| [`WeaponAsset`](GTA.md#weaponasset) | struct |  |
| [`WeaponCollection`](GTA.md#weaponcollection) | class |  |
| [`WeaponGroup`](GTA.md#weapongroup) | enum |  |
| [`WeaponTint`](GTA.md#weapontint) | enum |  |
| [`Weather`](GTA.md#weather) | enum |  |
| [`WindowTitle`](GTA.md#windowtitle) | enum |  |
| [`World`](GTA.md#world) | static class |  |

## [GTA.Math](GTA.Math.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`Matrix`](GTA.Math.md#matrix) | struct | Defines a 4x4 matrix. |
| [`Quaternion`](GTA.Math.md#quaternion) | struct |  |
| [`Vector2`](GTA.Math.md#vector2) | struct |  |
| [`Vector3`](GTA.Math.md#vector3) | struct |  |

## [GTA.Native](GTA.Native.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`Function`](GTA.Native.md#function) | static class |  |
| [`Hash`](GTA.Native.md#hash) | enum |  |
| [`InputArgument`](GTA.Native.md#inputargument) | class |  |
| [`OutputArgument`](GTA.Native.md#outputargument) | class |  |
| [`PedHash`](GTA.Native.md#pedhash) | enum |  |
| [`VehicleHash`](GTA.Native.md#vehiclehash) | enum |  |
| [`WeaponComponent`](GTA.Native.md#weaponcomponent) | enum |  |
| [`WeaponHash`](GTA.Native.md#weaponhash) | enum |  |

## [GTA.NaturalMotion](GTA.NaturalMotion.md)

| Type | Kind | Description |
| --- | --- | --- |
| [`ActivePoseHelper`](GTA.NaturalMotion.md#activeposehelper) | class |  |
| [`AdaptiveMode`](GTA.NaturalMotion.md#adaptivemode) | enum |  |
| [`AnimPoseHelper`](GTA.NaturalMotion.md#animposehelper) | class |  |
| [`AnimSource`](GTA.NaturalMotion.md#animsource) | enum |  |
| [`ApplyBulletImpulseHelper`](GTA.NaturalMotion.md#applybulletimpulsehelper) | class |  |
| [`ApplyImpulseHelper`](GTA.NaturalMotion.md#applyimpulsehelper) | class |  |
| [`ArmDirections`](GTA.NaturalMotion.md#armdirections) | enum |  |
| [`ArmsWindmillAdaptiveHelper`](GTA.NaturalMotion.md#armswindmilladaptivehelper) | class |  |
| [`ArmsWindmillHelper`](GTA.NaturalMotion.md#armswindmillhelper) | class |  |
| [`BalancerCollisionsReactionHelper`](GTA.NaturalMotion.md#balancercollisionsreactionhelper) | class |  |
| [`BodyBalanceHelper`](GTA.NaturalMotion.md#bodybalancehelper) | class |  |
| [`BodyFoetalHelper`](GTA.NaturalMotion.md#bodyfoetalhelper) | class |  |
| [`BodyRelaxHelper`](GTA.NaturalMotion.md#bodyrelaxhelper) | class | Set the amount of relaxation across the whole body; Used to collapse the character into a rag-doll-like state. |
| [`BodyRollUpHelper`](GTA.NaturalMotion.md#bodyrolluphelper) | class |  |
| [`BodyWritheHelper`](GTA.NaturalMotion.md#bodywrithehelper) | class |  |
| [`BraceForImpactHelper`](GTA.NaturalMotion.md#braceforimpacthelper) | class |  |
| [`BuoyancyHelper`](GTA.NaturalMotion.md#buoyancyhelper) | class | Simple buoyancy model. No character movement just fluid forces/torques added to parts. |
| [`CarriedHelper`](GTA.NaturalMotion.md#carriedhelper) | class | Carried. |
| [`CatchFallHelper`](GTA.NaturalMotion.md#catchfallhelper) | class |  |
| [`ConfigureBalanceHelper`](GTA.NaturalMotion.md#configurebalancehelper) | class | This single message allows you to configure various parameters used on any behavior that uses the dynamic balance. |
| [`ConfigureBalanceResetHelper`](GTA.NaturalMotion.md#configurebalanceresethelper) | class | Reset the values configurable by the Configure Balance message to their defaults. |
| [`ConfigureBulletsExtraHelper`](GTA.NaturalMotion.md#configurebulletsextrahelper) | class |  |
| [`ConfigureBulletsHelper`](GTA.NaturalMotion.md#configurebulletshelper) | class |  |
| [`ConfigureConstraintsHelper`](GTA.NaturalMotion.md#configureconstraintshelper) | class | One shot to give state of constraints on character and response to constraints. |
| [`ConfigureLimitsHelper`](GTA.NaturalMotion.md#configurelimitshelper) | class | Enable/disable/edit character limits in real time. This adjusts limits in RAGE-native space and will *not* reorient the joint. |
| [`ConfigureSelfAvoidanceHelper`](GTA.NaturalMotion.md#configureselfavoidancehelper) | class | This single message allows to configure self avoidance for the character.BBDD Self avoidance tech. |
| [`ConfigureShotInjuredArmHelper`](GTA.NaturalMotion.md#configureshotinjuredarmhelper) | class | This single message allows you to configure the injured arm reaction during shot. |
| [`ConfigureShotInjuredLegHelper`](GTA.NaturalMotion.md#configureshotinjuredleghelper) | class | This single message allows you to configure the injured leg reaction during shot. |
| [`ConfigureSoftLimitHelper`](GTA.NaturalMotion.md#configuresoftlimithelper) | class |  |
| [`CustomHelper`](GTA.NaturalMotion.md#customhelper) | abstract class | A helper class for building a `Message` and sending it to a given `Ped`. |
| [`DangleHelper`](GTA.NaturalMotion.md#danglehelper) | class | Dangle. |
| [`DefineAttachedObjectHelper`](GTA.NaturalMotion.md#defineattachedobjecthelper) | class |  |
| [`ElectrocuteHelper`](GTA.NaturalMotion.md#electrocutehelper) | class |  |
| [`Euphoria`](GTA.NaturalMotion.md#euphoria) | class |  |
| [`FallOverWallHelper`](GTA.NaturalMotion.md#falloverwallhelper) | class |  |
| [`FallType`](GTA.NaturalMotion.md#falltype) | enum |  |
| [`FireWeaponHelper`](GTA.NaturalMotion.md#fireweaponhelper) | class | One shot message apply a force to the hand as we fire the gun that should be in this hand. |
| [`ForceLeanInDirectionHelper`](GTA.NaturalMotion.md#forceleanindirectionhelper) | class |  |
| [`ForceLeanRandomHelper`](GTA.NaturalMotion.md#forceleanrandomhelper) | class |  |
| [`ForceLeanToPositionHelper`](GTA.NaturalMotion.md#forceleantopositionhelper) | class |  |
| [`ForceLeanTowardsObjectHelper`](GTA.NaturalMotion.md#forceleantowardsobjecthelper) | class |  |
| [`ForceToBodyPartHelper`](GTA.NaturalMotion.md#forcetobodyparthelper) | class | Apply an impulse to a named body part. |
| [`GrabHelper`](GTA.NaturalMotion.md#grabhelper) | class |  |
| [`Hand`](GTA.NaturalMotion.md#hand) | enum |  |
| [`HeadLookHelper`](GTA.NaturalMotion.md#headlookhelper) | class |  |
| [`HighFallHelper`](GTA.NaturalMotion.md#highfallhelper) | class |  |
| [`HipsLeanInDirectionHelper`](GTA.NaturalMotion.md#hipsleanindirectionhelper) | class |  |
| [`HipsLeanRandomHelper`](GTA.NaturalMotion.md#hipsleanrandomhelper) | class |  |
| [`HipsLeanToPositionHelper`](GTA.NaturalMotion.md#hipsleantopositionhelper) | class |  |
| [`HipsLeanTowardsObjectHelper`](GTA.NaturalMotion.md#hipsleantowardsobjecthelper) | class |  |
| [`IncomingTransformsHelper`](GTA.NaturalMotion.md#incomingtransformshelper) | class |  |
| [`InjuredOnGroundHelper`](GTA.NaturalMotion.md#injuredongroundhelper) | class | InjuredOnGround. |
| [`LeanInDirectionHelper`](GTA.NaturalMotion.md#leanindirectionhelper) | class |  |
| [`LeanRandomHelper`](GTA.NaturalMotion.md#leanrandomhelper) | class |  |
| [`LeanToPositionHelper`](GTA.NaturalMotion.md#leantopositionhelper) | class |  |
| [`LeanTowardsObjectHelper`](GTA.NaturalMotion.md#leantowardsobjecthelper) | class |  |
| [`Message`](GTA.NaturalMotion.md#message) | class | A base class for manually building a `Message`. |
| [`MirrorMode`](GTA.NaturalMotion.md#mirrormode) | enum |  |
| [`OnFireHelper`](GTA.NaturalMotion.md#onfirehelper) | class |  |
| [`PedalLegsHelper`](GTA.NaturalMotion.md#pedallegshelper) | class |  |
| [`PointArmHelper`](GTA.NaturalMotion.md#pointarmhelper) | class | BEHAVIOURS REFERENCED: AnimPose - allows animPose to override body parts: Arms (useLeftArm, useRightArm). |
| [`PointGunExtraHelper`](GTA.NaturalMotion.md#pointgunextrahelper) | class | Seldom set parameters for pointGun - just to keep number of parameters in any message less than or equal to 64. |
| [`PointGunHelper`](GTA.NaturalMotion.md#pointgunhelper) | class |  |
| [`RbTwistAxis`](GTA.NaturalMotion.md#rbtwistaxis) | enum |  |
| [`RegisterWeaponHelper`](GTA.NaturalMotion.md#registerweaponhelper) | class | Use this message to register weapon. This is an alternativeto the registerWeapon public function. |
| [`RollDownStairsHelper`](GTA.NaturalMotion.md#rolldownstairshelper) | class |  |
| [`SetCharacterCollisionsHelper`](GTA.NaturalMotion.md#setcharactercollisionshelper) | class | SetCharacterCollisions:. |
| [`SetCharacterDampingHelper`](GTA.NaturalMotion.md#setcharacterdampinghelper) | class | Damp out cartwheeling and somersaulting above a certain threshold. |
| [`SetCharacterHealthHelper`](GTA.NaturalMotion.md#setcharacterhealthhelper) | class | Sets character's health on the dead-to-alive scale: [0..1]. |
| [`SetCharacterStrengthHelper`](GTA.NaturalMotion.md#setcharacterstrengthhelper) | class | Sets character's strength on the dead-granny-to-healthy-terminator scale: [0..1]. |
| [`SetCharacterUnderwaterHelper`](GTA.NaturalMotion.md#setcharacterunderwaterhelper) | class | Sets viscosity applied to damping limbs. |
| [`SetFallingReactionHelper`](GTA.NaturalMotion.md#setfallingreactionhelper) | class | Sets the type of reaction if catchFall is called. |
| [`SetFrictionScaleHelper`](GTA.NaturalMotion.md#setfrictionscalehelper) | class | SetFrictionScale:. |
| [`SetMuscleStiffnessHelper`](GTA.NaturalMotion.md#setmusclestiffnesshelper) | class | Use this message to manually set the muscle stiffness values -before using Active Pose to drive to an animated pose, for example. |
| [`SetStiffnessHelper`](GTA.NaturalMotion.md#setstiffnesshelper) | class | Use this message to manually set the body stiffness values -before using Active Pose to drive to an animated pose, for example. |
| [`SetWeaponModeHelper`](GTA.NaturalMotion.md#setweaponmodehelper) | class | Use this message to set the character's weapon mode. This is an alternativeto the setWeaponMode public function. |
| [`ShotConfigureArmsHelper`](GTA.NaturalMotion.md#shotconfigurearmshelper) | class | Configure the arm reactions in shot. |
| [`ShotFallToKneesHelper`](GTA.NaturalMotion.md#shotfalltokneeshelper) | class | Configure the fall to knees shot. |
| [`ShotFromBehindHelper`](GTA.NaturalMotion.md#shotfrombehindhelper) | class | Configure the shot from behind reaction. |
| [`ShotHeadLookHelper`](GTA.NaturalMotion.md#shotheadlookhelper) | class |  |
| [`ShotHelper`](GTA.NaturalMotion.md#shothelper) | class |  |
| [`ShotInGutsHelper`](GTA.NaturalMotion.md#shotingutshelper) | class | Configure the shot in guts reaction. |
| [`ShotNewBulletHelper`](GTA.NaturalMotion.md#shotnewbullethelper) | class | Send new wound information to the shot. Can cause shot to restart it's performance in part or in whole. |
| [`ShotRelaxHelper`](GTA.NaturalMotion.md#shotrelaxhelper) | class |  |
| [`ShotShockSpinHelper`](GTA.NaturalMotion.md#shotshockspinhelper) | class | Configure the shockSpin effect in shot. Spin/Lift the character using cheat torques/forces. |
| [`ShotSnapHelper`](GTA.NaturalMotion.md#shotsnaphelper) | class |  |
| [`SmartFallHelper`](GTA.NaturalMotion.md#smartfallhelper) | class | Clone of High Fall with a wider range of operating conditions. |
| [`StaggerFallHelper`](GTA.NaturalMotion.md#staggerfallhelper) | class |  |
| [`StayUprightHelper`](GTA.NaturalMotion.md#stayuprighthelper) | class |  |
| [`StopAllBehavioursHelper`](GTA.NaturalMotion.md#stopallbehaviourshelper) | class | Send this message to immediately stop all behaviors from executing. |
| [`Synchroisation`](GTA.NaturalMotion.md#synchroisation) | enum |  |
| [`TeeterHelper`](GTA.NaturalMotion.md#teeterhelper) | class |  |
| [`TorqueFilterMode`](GTA.NaturalMotion.md#torquefiltermode) | enum |  |
| [`TorqueMode`](GTA.NaturalMotion.md#torquemode) | enum |  |
| [`TorqueSpinMode`](GTA.NaturalMotion.md#torquespinmode) | enum |  |
| [`TurnType`](GTA.NaturalMotion.md#turntype) | enum |  |
| [`UpperBodyFlinchHelper`](GTA.NaturalMotion.md#upperbodyflinchhelper) | class |  |
| [`WeaponMode`](GTA.NaturalMotion.md#weaponmode) | enum |  |
| [`YankedHelper`](GTA.NaturalMotion.md#yankedhelper) | class |  |

