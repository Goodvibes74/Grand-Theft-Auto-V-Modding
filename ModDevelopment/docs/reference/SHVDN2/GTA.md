# GTA (ScriptHookVDotNet v2 (legacy))

[Back to the ScriptHookVDotNet v2 (legacy) index](README.md)

> **Source:** `ScriptHookVDotNet2.dll` (file version 2.11.6, assembly version 2.11.6.0, 984,576 bytes, modified 2026-08-05, SHA-256 `8f9ec05e5ccf83781ef4abe45abfb51d8231e4fc9ee2b56884caf00d5a642594`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `ScriptHookVDotNet2.xml` from the NuGet package `scripthookvdotnet2` 2.11.6 (nuget.org), the same version as the installed DLL.

## AnimationFlags

enum `GTA.AnimationFlags`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `None` | 0 |
| `Loop` | 1 |
| `StayInEndFrame` | 2 |
| `UpperBodyOnly` | 16 |
| `AllowRotation` | 32 |
| `CancelableWithMovement` | 128 |
| `RagdollOnCollision` | 4194304 |

## Audio

static class `GTA.Audio`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Methods

- `public static bool HasSoundFinished(int id)`
- `public static int PlaySoundAt(Entity entity, string soundFile, string soundSet)`
- `public static int PlaySoundAt(Entity entity, string soundFile)`
- `public static int PlaySoundAt(Vector3 position, string soundFile, string soundSet)`
- `public static int PlaySoundAt(Vector3 position, string soundFile)`
- `public static int PlaySoundFromEntity(Entity entity, string sound, string set)`
- `public static int PlaySoundFromEntity(Entity entity, string sound)`
- `public static int PlaySoundFrontend(string soundFile, string soundSet)`
- `public static int PlaySoundFrontend(string soundFile)`
- `public static void ReleaseSound(int id)`
- `public static void SetAudioFlag(AudioFlag flag, bool toggle)`
- `public static void SetAudioFlag(string flag, bool toggle)`
- `public static void StopSound(int id)`

## AudioFlag

enum `GTA.AudioFlag`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

## Blip

class `GTA.Blip` : `IEquatable<Blip>`, `IHandleable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Blip(int handle)`

### Properties

- `public int Alpha { get; set; }`
- `public BlipColor Color { get; set; }`
- `public int Handle { get; }`
- `public bool IsFlashing { get; set; }`
- `public bool IsFriendly { set; }`
- `public bool IsOnMinimap { get; }`
- `public bool IsShortRange { get; set; }`
- `public string Name { set; }`
- `public Vector3 Position { get; set; }`
- `public int Rotation { set; }`
- `public float Scale { set; }`
- `public bool ShowRoute { set; }`
- `public BlipSprite Sprite { get; set; }`
- `public int Type { get; }`

### Methods

- `public bool Equals(Blip obj)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public virtual int GetHashCode()`
- `public void HideNumber()`
- `public void Remove()`
- `public void ShowNumber(int number)`
- `public static bool Exists(Blip blip)`
- `public static bool op_Equality(Blip left, Blip right)`
- `public static bool op_Inequality(Blip left, Blip right)`

## BlipColor

enum `GTA.BlipColor`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

84 values:

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
```

## BlipSprite

enum `GTA.BlipSprite`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

## Bone

enum `GTA.Bone`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

98 values:

```text
SKEL_ROOT = 0
SKEL_Pelvis = 11816
SKEL_L_Thigh = 58271
SKEL_L_Calf = 63931
SKEL_L_Foot = 14201
SKEL_L_Toe0 = 2108
IK_L_Foot = 65245
PH_L_Foot = 57717
MH_L_Knee = 46078
SKEL_R_Thigh = 51826
SKEL_R_Calf = 36864
SKEL_R_Foot = 52301
SKEL_R_Toe0 = 20781
IK_R_Foot = 35502
PH_R_Foot = 24806
MH_R_Knee = 16335
RB_L_ThighRoll = 23639
RB_R_ThighRoll = 6442
SKEL_Spine_Root = 57597
SKEL_Spine0 = 23553
SKEL_Spine1 = 24816
SKEL_Spine2 = 24817
SKEL_Spine3 = 24818
SKEL_L_Clavicle = 64729
SKEL_L_UpperArm = 45509
SKEL_L_Forearm = 61163
SKEL_L_Hand = 18905
SKEL_L_Finger00 = 26610
SKEL_L_Finger01 = 4089
SKEL_L_Finger02 = 4090
SKEL_L_Finger10 = 26611
SKEL_L_Finger11 = 4169
SKEL_L_Finger12 = 4170
SKEL_L_Finger20 = 26612
SKEL_L_Finger21 = 4185
SKEL_L_Finger22 = 4186
SKEL_L_Finger30 = 26613
SKEL_L_Finger31 = 4137
SKEL_L_Finger32 = 4138
SKEL_L_Finger40 = 26614
SKEL_L_Finger41 = 4153
SKEL_L_Finger42 = 4154
PH_L_Hand = 60309
IK_L_Hand = 36029
RB_L_ForeArmRoll = 61007
RB_L_ArmRoll = 5232
MH_L_Elbow = 22711
SKEL_R_Clavicle = 10706
SKEL_R_UpperArm = 40269
SKEL_R_Forearm = 28252
SKEL_R_Hand = 57005
SKEL_R_Finger00 = 58866
SKEL_R_Finger01 = 64016
SKEL_R_Finger02 = 64017
SKEL_R_Finger10 = 58867
SKEL_R_Finger11 = 64096
SKEL_R_Finger12 = 64097
SKEL_R_Finger20 = 58868
SKEL_R_Finger21 = 64112
SKEL_R_Finger22 = 64113
SKEL_R_Finger30 = 58869
SKEL_R_Finger31 = 64064
SKEL_R_Finger32 = 64065
SKEL_R_Finger40 = 58870
SKEL_R_Finger41 = 64080
SKEL_R_Finger42 = 64081
PH_R_Hand = 28422
IK_R_Hand = 6286
RB_R_ForeArmRoll = 43810
RB_R_ArmRoll = 37119
MH_R_Elbow = 2992
SKEL_Neck_1 = 39317
SKEL_Head = 31086
IK_Head = 12844
FACIAL_facialRoot = 65068
FB_L_Brow_Out_000 = 58331
FB_L_Lid_Upper_000 = 45750
FB_L_Eye_000 = 25260
FB_L_CheekBone_000 = 21550
FB_L_Lip_Corner_000 = 29868
FB_R_Lid_Upper_000 = 43536
FB_R_Eye_000 = 27474
FB_R_CheekBone_000 = 19336
FB_R_Brow_Out_000 = 1356
FB_R_Lip_Corner_000 = 11174
FB_Brow_Centre_000 = 37193
FB_UpperLipRoot_000 = 20178
FB_UpperLip_000 = 61839
FB_L_Lip_Top_000 = 20279
FB_R_Lip_Top_000 = 17719
FB_Jaw_000 = 46240
FB_LowerLipRoot_000 = 17188
FB_LowerLip_000 = 20623
FB_L_Lip_Bot_000 = 47419
FB_R_Lip_Bot_000 = 49979
FB_Tongue_000 = 47495
RB_Neck_1 = 35731
IK_Root = 56604
```

## Camera

class `GTA.Camera` : `IEquatable<Camera>`, `IHandleable`, `ISpatial`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Camera(int handle)`

### Properties

- `public float DepthOfFieldStrength { set; }`
- `public Vector3 Direction { get; set; }`
- `public float FarClip { get; set; }`
- `public float FarDepthOfField { get; set; }`
- `public float FieldOfView { get; set; }`
- `public int Handle { get; }`
- `public bool IsActive { get; set; }`
- `public bool IsInterpolating { get; }`
- `public bool IsShaking { get; }`
- `public float MotionBlurStrength { set; }`
- `public float NearClip { get; set; }`
- `public float NearDepthOfField { set; }`
- `public Vector3 Position { get; set; }`
- `public Vector3 Rotation { get; set; }`
- `public float ShakeAmplitude { set; }`

### Methods

- `public void AttachTo(Entity entity, Vector3 offset)`
- `public void AttachTo(Ped ped, int boneIndex, Vector3 offset)`
- `public void Destroy()`
- `public void Detach()`
- `public bool Equals(Camera obj)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public virtual int GetHashCode()`
- `public Vector3 GetOffsetFromWorldCoords(Vector3 worldCoords)`
- `public Vector3 GetOffsetInWorldCoords(Vector3 offset)`
- `public void InterpTo(Camera to, int duration, bool easePosition, bool easeRotation)`
- `public void PointAt(Entity target, Vector3 offset)`
- `public void PointAt(Entity target)`
- `public void PointAt(Vector3 target)`
- `public void PointAt(Ped target, int boneIndex, Vector3 offset)`
- `public void PointAt(Ped target, int boneIndex)`
- `public void Shake(CameraShake shakeType, float amplitude)`
- `public void StopPointing()`
- `public void StopShaking()`
- `public static bool Exists(Camera camera)`
- `public static bool op_Equality(Camera left, Camera right)`
- `public static bool op_Inequality(Camera left, Camera right)`

## CameraShake

enum `GTA.CameraShake`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

## CargobobHook

enum `GTA.CargobobHook`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Hook` | 0 |
| `Magnet` | 1 |

## Control

enum `GTA.Control`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

363 values:

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
```

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

## DrivingStyle

enum `GTA.DrivingStyle`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Normal` | 786603 |
| `IgnoreLights` | 2883621 |
| `SometimesOvertakeTraffic` | 5 |
| `Rushed` | 1074528293 |
| `AvoidTraffic` | 786468 |
| `AvoidTrafficExtremely` | 6 |

## Entity

abstract class `GTA.Entity` : `IEquatable<Entity>`, `IHandleable`, `ISpatial`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Entity(int handle)`

### Properties

- `public int Alpha { get; set; }`
- `public Blip CurrentBlip { get; }`
- `public Vector3 ForwardVector { get; }`
- `public bool FreezePosition { get; set; }`
- `public int Handle { get; }`
- `public bool HasCollidedWithAnything { get; }`
- `public bool HasCollision { get; set; }`
- `public bool HasGravity { set; }`
- `public float Heading { get; set; }`
- `public int Health { get; set; }`
- `public float HeightAboveGround { get; }`
- `public bool IsAlive { get; }`
- `public bool IsBulletProof { get; set; }`
- `public bool IsCollisionProof { get; set; }`
- `public bool IsDead { get; }`
- `public bool IsExplosionProof { get; set; }`
- `public bool IsFireProof { get; set; }`
- `public bool IsInAir { get; }`
- `public bool IsInvincible { get; set; }`
- `public bool IsInWater { get; }`
- `public bool IsMeleeProof { get; set; }`
- `public bool IsOccluded { get; }`
- `public bool IsOnFire { get; }`
- `public bool IsOnlyDamagedByPlayer { get; set; }`
- `public bool IsOnScreen { get; }`
- `public bool IsPersistent { get; set; }`
- `public bool IsUpright { get; }`
- `public bool IsUpsideDown { get; }`
- `public bool IsVisible { get; set; }`
- `public int LodDistance { get; set; }`
- `public int MaxHealth { get; set; }`
- `public float MaxSpeed { set; }`
- `public int* MemoryAddress { get; }`
- `public Model Model { get; }`
- `public Vector3 Position { get; set; }`
- `public Vector3 PositionNoOffset { set; }`
- `public Quaternion Quaternion { get; set; }`
- `public Vector3 RightVector { get; }`
- `public Vector3 Rotation { get; set; }`
- `public Vector3 UpVector { get; }`
- `public Vector3 Velocity { get; set; }`

### Methods

- `public Blip AddBlip()`
- `public void ApplyForce(Vector3 direction, Vector3 rotation, ForceType forceType)`
- `public void ApplyForce(Vector3 direction, Vector3 rotation)`
- `public void ApplyForce(Vector3 direction)`
- `public void ApplyForceRelative(Vector3 direction, Vector3 rotation, ForceType forceType)`
- `public void ApplyForceRelative(Vector3 direction, Vector3 rotation)`
- `public void ApplyForceRelative(Vector3 direction)`
- `public void AttachTo(Entity entity, int boneIndex, Vector3 position, Vector3 rotation)`
- `public void AttachTo(Entity entity, int boneIndex)`
- `public void Delete()`
- `public void Detach()`
- `public bool Equals(Entity obj)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public Vector3 GetBoneCoord(int boneIndex)`
- `public Vector3 GetBoneCoord(string boneName)`
- `public int GetBoneIndex(string boneName)`
- `public Entity GetEntityAttachedTo()`
- `public virtual int GetHashCode()`
- `public Vector3 GetOffsetFromWorldCoords(Vector3 worldCoords)`
- `public Vector3 GetOffsetInWorldCoords(Vector3 offset)`
- `public bool HasBeenDamagedBy(Entity entity)`
- `public bool HasBone(string boneName)`
- `public bool IsAttached()`
- `public bool IsAttachedTo(Entity entity)`
- `public bool IsInAngledArea(Vector3 origin, Vector3 edge, float angle)`
- `public bool IsInArea(Vector3 pos1, Vector3 pos2, float angle)`
  - **Obsolete.** Entity.IsInArea(Vector3, Vector3, float) is obsolete because it actually tests using an angled area. Call IS_ENTITY_IN_AREA manually to test with an axis aligned area in this API version instead. Use Entity.IsInAngledArea(Vector3, Vector3, float) to test with an angled area instead.
- `public bool IsInArea(Vector3 minBounds, Vector3 maxBounds)`
- `public bool IsInRangeOf(Vector3 position, float distance)`
- `public bool IsNearEntity(Entity entity, Vector3 distance)`
- `public bool IsTouching(Entity entity)`
- `public bool IsTouching(Model model)`
- `public void MarkAsNoLongerNeeded()`
- `public void ResetAlpha()`
- `public void SetNoCollision(Entity entity, bool toggle)`
- `public static bool Exists(Entity entity)`
- `public static bool op_Equality(Entity left, Entity right)`
- `public static bool op_Inequality(Entity left, Entity right)`

## ExplosionType

enum `GTA.ExplosionType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

## FiringPattern

enum `GTA.FiringPattern`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

## Font

enum `GTA.Font`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `ChaletLondon` | 0 |
| `HouseScript` | 1 |
| `Monospace` | 2 |
| `ChaletComprimeCologne` | 4 |
| `Pricedown` | 7 |

## ForceType

enum `GTA.ForceType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `MinForce` | 0 |
| `MaxForceRot` | 1 |
| `MinForce2` | 2 |
| `MaxForceRot2` | 3 |
| `ForceNoRot` | 4 |
| `ForceRotPlusForce` | 5 |

## FormationType

enum `GTA.FormationType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Default` | 0 |
| `Circle1` | 1 |
| `Circle2` | 2 |
| `Line` | 3 |

## Game

static class `GTA.Game`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public static InputMode CurrentInputMode { get; }`
- `public static float FPS { get; }`
- `public static int FrameCount { get; }`
- `public static int GameTime { get; }`
- `public static GlobalCollection Globals { get; }`
- `public static bool IsLoading { get; }`
  - **Obsolete.** `Game.IsLoading` is obsolete because Script Hook V changed the way SHV scripts start inv1.0.3351.0 (SHV version and not game version) and they never be able to start before the game finished showing the loading screen since SHV v1.0.3351.0+. It is advised not to use `Game.IsLoading`at all.
- `public static bool IsPaused { get; set; }`
- `public static bool IsScreenFadedIn { get; }`
- `public static bool IsScreenFadedOut { get; }`
- `public static bool IsScreenFadingIn { get; }`
- `public static bool IsScreenFadingOut { get; }`
- `public static bool IsWaypointActive { get; }`
- `public static Language Language { get; }`
- `public static float LastFrameTime { get; }`
- `public static int MaxWantedLevel { get; set; }`
- `public static bool MissionFlag { get; set; }`
- `public static bool Nightvision { get; set; }`
- `public static Player Player { get; }`
- `public static int RadarZoom { set; }`
- `public static RadioStation RadioStation { get; set; }`
- `public static Size ScreenResolution { get; }`
- `public static bool ShowsPoliceBlipsOnRadar { set; }`
- `public static bool ThermalVision { get; set; }`
- `public static float TimeScale { get; set; }`
- `public static GameVersion Version { get; }`
- `public static float WantedMultiplier { set; }`

### Methods

- `public static void DisableAllControlsThisFrame(int index)`
- `public static void DisableControl(int index, Control control)`
  - **Obsolete.** The Game.DisableControl is obsolete, use Game.DisableControlThisFrame instead.
- `public static void DisableControlThisFrame(int index, Control control)`
- `public static void DoAutoSave()`
- `public static void EnableAllControlsThisFrame(int index)`
- `public static void EnableControl(int index, Control control)`
  - **Obsolete.** The Game.EnableControl is obsolete, use Game.EnableControlThisFrame instead.
- `public static void EnableControlThisFrame(int index, Control control)`
- `public static void FadeScreenIn(int time)`
- `public static void FadeScreenOut(int time)`
- `public static int GenerateHash(string input)`
- `public static float GetControlNormal(int index, Control control)`
- `public static int GetControlValue(int index, Control control)`
- `public static float GetDisabledControlNormal(int index, Control control)`
- `public static string GetGXTEntry(string entry)`
- `public static string GetUserInput(WindowTitle windowTitle, int maxLength)`
- `public static string GetUserInput(WindowTitle windowTitle, string defaultText, int maxLength)`
- `public static string GetUserInput(int maxLength)`
- `public static string GetUserInput(string defaultText, int maxLength)`
- `public static bool IsControlEnabled(int index, Control control)`
- `public static bool IsControlJustPressed(int index, Control control)`
- `public static bool IsControlJustReleased(int index, Control control)`
- `public static bool IsControlPressed(int index, Control control)`
- `public static bool IsDisabledControlJustPressed(int index, Control control)`
- `public static bool IsDisabledControlJustReleased(int index, Control control)`
- `public static bool IsDisabledControlPressed(int index, Control control)`
- `public static bool IsEnabledControlJustPressed(int index, Control control)`
- `public static bool IsEnabledControlJustReleased(int index, Control control)`
- `public static bool IsEnabledControlPressed(int index, Control control)`
- `public static bool IsKeyPressed(Keys key)`
- `public static void Pause(bool value)`
- `public static void PauseClock(bool value)`
- `public static void PlayMusic(string musicFile)`
- `public static void PlaySound(string soundFile, string soundSet)`
- `public static void SetControlNormal(int index, Control control, float value)`
- `public static void ShowSaveMenu()`
- `public static void StopMusic(string musicFile)`

## GameplayCamera

static class `GTA.GameplayCamera`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public static Vector3 Direction { get; }`
- `public static float FieldOfView { get; }`
- `public static bool IsAimCamActive { get; }`
- `public static bool IsFirstPersonAimCamActive { get; }`
- `public static bool IsLookingBehind { get; }`
- `public static bool IsRendering { get; }`
- `public static bool IsShaking { get; }`
- `public static Vector3 Position { get; }`
- `public static float RelativeHeading { get; set; }`
- `public static float RelativePitch { get; set; }`
- `public static Vector3 Rotation { get; }`
- `public static float ShakeAmplitude { set; }`
- `public static float Zoom { get; }`

### Methods

- `public static void ClampPitch(float min, float max)`
- `public static void ClampYaw(float min, float max)`
- `public static Vector3 GetOffsetFromWorldCoords(Vector3 worldCoords)`
- `public static Vector3 GetOffsetInWorldCoords(Vector3 offset)`
- `public static void Shake(CameraShake shakeType, float amplitude)`
- `public static void StopShaking()`

## GameVersion

enum `GTA.GameVersion`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

104 values:

```text
Unknown = 0
VER_1_0_335_2_STEAM = 1
VER_1_0_335_2_NOSTEAM = 2
VER_1_0_350_1_STEAM = 3
VER_1_0_350_2_NOSTEAM = 4
VER_1_0_372_2_STEAM = 5
VER_1_0_372_2_NOSTEAM = 6
VER_1_0_393_2_STEAM = 7
VER_1_0_393_2_NOSTEAM = 8
VER_1_0_393_4_STEAM = 9
VER_1_0_393_4_NOSTEAM = 10
VER_1_0_463_1_STEAM = 11
VER_1_0_463_1_NOSTEAM = 12
VER_1_0_505_2_STEAM = 13
VER_1_0_505_2_NOSTEAM = 14
VER_1_0_573_1_STEAM = 15
VER_1_0_573_1_NOSTEAM = 16
VER_1_0_617_1_STEAM = 17
VER_1_0_617_1_NOSTEAM = 18
VER_1_0_678_1_STEAM = 19
VER_1_0_678_1_NOSTEAM = 20
VER_1_0_757_2_STEAM = 21
VER_1_0_757_2_NOSTEAM = 22
VER_1_0_757_3_STEAM = 23
VER_1_0_757_4_NOSTEAM = 24
VER_1_0_791_2_STEAM = 25
VER_1_0_791_2_NOSTEAM = 26
VER_1_0_877_1_STEAM = 27
VER_1_0_877_1_NOSTEAM = 28
VER_1_0_944_2_STEAM = 29
VER_1_0_944_2_NOSTEAM = 30
VER_1_0_1011_1_STEAM = 31
VER_1_0_1011_1_NOSTEAM = 32
VER_1_0_1032_1_STEAM = 33
VER_1_0_1032_1_NOSTEAM = 34
VER_1_0_1103_2_STEAM = 35
VER_1_0_1103_2_NOSTEAM = 36
VER_1_0_1180_2_STEAM = 37
VER_1_0_1180_2_NOSTEAM = 38
VER_1_0_1290_1_STEAM = 39
VER_1_0_1290_1_NOSTEAM = 40
VER_1_0_1365_1_STEAM = 41
VER_1_0_1365_1_NOSTEAM = 42
VER_1_0_1493_0_STEAM = 43
VER_1_0_1493_0_NOSTEAM = 44
VER_1_0_1493_1_STEAM = 45
VER_1_0_1493_1_NOSTEAM = 46
VER_1_0_1604_0_STEAM = 47
VER_1_0_1604_0_NOSTEAM = 48
VER_1_0_1604_1_STEAM = 49
VER_1_0_1604_1_NOSTEAM = 50
VER_1_0_1737_0_STEAM = 51
VER_1_0_1737_0_NOSTEAM = 52
VER_1_0_1737_6_STEAM = 53
VER_1_0_1737_6_NOSTEAM = 54
VER_1_0_1868_0_STEAM = 55
VER_1_0_1868_0_NOSTEAM = 56
VER_1_0_1868_1_STEAM = 57
VER_1_0_1868_1_NOSTEAM = 58
VER_1_0_1868_4_EGS = 59
VER_1_0_2060_0_STEAM = 60
VER_1_0_2060_0_NOSTEAM = 61
VER_1_0_2060_1_STEAM = 62
VER_1_0_2060_1_NOSTEAM = 63
VER_1_0_2189_0_STEAM = 64
VER_1_0_2189_0_NOSTEAM = 65
VER_1_0_2215_0_STEAM = 66
VER_1_0_2215_0_NOSTEAM = 67
VER_1_0_2245_0_STEAM = 68
VER_1_0_2245_0_NOSTEAM = 69
VER_1_0_2372_0_STEAM = 70
VER_1_0_2372_0_NOSTEAM = 71
VER_1_0_2545_0_STEAM = 72
VER_1_0_2545_0_NOSTEAM = 73
VER_1_0_2612_1_STEAM = 74
VER_1_0_2612_1_NOSTEAM = 75
VER_1_0_2628_2_STEAM = 76
VER_1_0_2628_2_NOSTEAM = 77
VER_1_0_2699_0_STEAM = 78
VER_1_0_2699_0_NOSTEAM = 79
VER_1_0_2699_16 = 80
VER_1_0_2802_0 = 81
VER_1_0_2824_0 = 82
VER_1_0_2845_0 = 83
VER_1_0_2944_0 = 84
VER_1_0_3028_0 = 85
VER_1_0_3095_0 = 86
VER_1_0_3179_0 = 87
VER_1_0_3258_0 = 88
VER_1_0_3274_0 = 89
VER_1_0_3323_0 = 90
VER_1_0_3337_0 = 91
VER_1_0_3351_0 = 92
VER_1_0_3407_0 = 93
VER_1_0_3411_0 = 94
VER_1_0_3442_0 = 95
VER_1_0_3504_0 = 96
VER_1_0_3521_0 = 97
VER_1_0_3570_0 = 98
VER_1_0_3586_0 = 99
VER_1_0_3717_0 = 100
VER_1_0_3725_0 = 101
VER_1_0_3751_0 = 102
VER_1_0_3788_0 = 103
```

## Gender

enum `GTA.Gender`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Male` | 0 |
| `Female` | 1 |

## Global

struct `GTA.Global`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public ulong* MemoryAddress { get; }`

### Methods

- `public float GetFloat()`
- `public int GetInt()`
- `public string GetString()`
- `public Vector3 GetVector3()`
- `public void SetFloat(float value)`
- `public void SetInt(int value)`
- `public void SetString(string value)`
- `public void SetVector3(Vector3 value)`

## GlobalCollection

class `GTA.GlobalCollection`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public Global this[int index] { get; set; }`

## HelmetType

enum `GTA.HelmetType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `RegularMotorcycleHelmet` | 4096 |
| `FiremanHelmet` | 16384 |
| `PilotHeadset` | 32768 |

## HudComponent

enum `GTA.HudComponent`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `WantedStars` | 1 |
| `WeaponIcon` | 2 |
| `Cash` | 3 |
| `MpCash` | 4 |
| `MpMessage` | 5 |
| `VehicleName` | 6 |
| `AreaName` | 7 |
| `Unused` | 8 |
| `StreetName` | 9 |
| `HelpText` | 10 |
| `FloatingHelpText1` | 11 |
| `FloatingHelpText2` | 12 |
| `CashChange` | 13 |
| `Reticle` | 14 |
| `SubtitleText` | 15 |
| `RadioStationsWheel` | 16 |
| `Saving` | 17 |
| `GamingStreamUnusde` | 18 |
| `WeaponWheel` | 19 |
| `WeaponWheelStats` | 20 |
| `DrugsPurse01` | 21 |
| `DrugsPurse02` | 22 |
| `DrugsPurse03` | 23 |
| `DrugsPurse04` | 24 |
| `MpTagCashFromBank` | 25 |
| `MpTagPackages` | 26 |
| `MpTagCuffKeys` | 27 |
| `MpTagDownloadData` | 28 |
| `MpTagIfPedFollowing` | 29 |
| `MpTagKeyCard` | 30 |
| `MpTagRandomObject` | 31 |
| `MpTagRemoteControl` | 32 |
| `MpTagCashFromSafe` | 33 |
| `MpTagWeaponsPackage` | 34 |
| `MpTagKeys` | 35 |
| `MpVehicle` | 36 |
| `MpVehicleHeli` | 37 |
| `MpVehiclePlane` | 38 |
| `PlayerSwitchAlert` | 39 |
| `MpRankBar` | 40 |
| `DirectorMode` | 41 |
| `ReplayController` | 42 |
| `ReplayMouse` | 43 |
| `ReplayHeader` | 44 |
| `ReplayOptions` | 45 |
| `ReplayHelpText` | 46 |
| `ReplayMiscText` | 47 |
| `ReplayTopLine` | 48 |
| `ReplayBottomLine` | 49 |
| `ReplayLeftBar` | 50 |
| `ReplayTimer` | 51 |

## IHandleable

interface `GTA.IHandleable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public int Handle { get; }`

### Methods

- `public bool Exists()`

## IMenuItem

interface `GTA.IMenuItem`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public string Caption { get; set; }`
- `public string Description { get; set; }`
- `public MenuBase Parent { get; set; }`

### Methods

- `public void Activate()`
- `public void Change(bool right)`
- `public void Deselect()`
- `public void Draw()`
- `public void Draw(Size offset)`
- `public void Select()`
- `public void SetOriginAndSize(Point topLeftOrigin, Size size)`

## InputMode

enum `GTA.InputMode`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `MouseAndKeyboard` | 0 |
| `GamePad` | 1 |

## IntersectOptions

enum `GTA.IntersectOptions`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Everything` | -1 |
| `Map` | 1 |
| `Mission_Entities` | 2 |
| `Peds1` | 12 |
| `Objects` | 16 |
| `Unk1` | 32 |
| `Unk2` | 64 |
| `Unk3` | 128 |
| `Vegetation` | 256 |
| `Unk4` | 512 |

## ISpatial

interface `GTA.ISpatial`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public Vector3 Position { get; set; }`
- `public Vector3 Rotation { get; set; }`

## Language

enum `GTA.Language`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `None` | 0 |
| `WarpOut` | 16 |
| `LeaveDoorOpen` | 256 |
| `BailOut` | 4096 |

## MarkerType

enum `GTA.MarkerType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
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
| `HorizontalCircleSkinny_Arrow` | 26 |
| `HorizontalSplitArrowCircle` | 27 |
| `DebugSphere` | 28 |
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

## Menu

class `GTA.Menu` : `MenuBase`

### Constructors

- `public Menu(string headerCaption, IMenuItem[] items, int MaxItemsToDraw)`
- `public Menu(string headerCaption, IMenuItem[] items)`

### Properties

- `public int FooterHeight { get; set; }`
- `public bool HasFooter { get; set; }`
- `public int HeaderHeight { get; set; }`
- `public int ItemHeight { get; set; }`
- `public List<IMenuItem> Items { get; set; }`
- `public int MaxDrawLimit { get; set; }`
- `public int SelectedIndex { get; set; }`
- `public int StartScrollOffset { get; set; }`
- `public int Width { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Initialize()`
- `public virtual void OnActivate()`
- `public virtual void OnChangeItem(bool right)`
- `public virtual void OnChangeSelection(bool down)`
- `public void OnChangeSelection(int newIndex)`
- `public virtual void OnClose()`
- `public virtual void OnOpen()`

### Events

- `public event EventHandler<SelectedIndexChangedArgs> SelectedIndexChanged`

## MenuBase

class `GTA.MenuBase`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public MenuBase()`

### Properties

- `public string Caption { get; set; }`
- `public bool FooterCentered { get; set; }`
- `public Color FooterColor { get; set; }`
- `public Font FooterFont { get; set; }`
- `public Color FooterTextColor { get; set; }`
- `public float FooterTextScale { get; set; }`
- `public bool HeaderCentered { get; set; }`
- `public Color HeaderColor { get; set; }`
- `public Font HeaderFont { get; set; }`
- `public Color HeaderTextColor { get; set; }`
- `public float HeaderTextScale { get; set; }`
- `public Font ItemFont { get; set; }`
- `public bool ItemTextCentered { get; set; }`
- `public float ItemTextScale { get; set; }`
- `public Viewport Parent { get; set; }`
- `public Point Position { get; set; }`
- `public Color SelectedItemColor { get; set; }`
- `public Color SelectedTextColor { get; set; }`
- `public Point TextOffset { get; set; }`
- `public Color UnselectedItemColor { get; set; }`
- `public Color UnselectedTextColor { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Initialize()`
- `public virtual void OnActivate()`
- `public virtual void OnChangeItem(bool right)`
- `public virtual void OnChangeSelection(bool down)`
- `public virtual void OnClose()`
- `public virtual void OnOpen()`

## MenuButton

class `GTA.MenuButton` : `IMenuItem`

> **Obsolete.** The built-in menu implementation is obsolete. Please consider using external alternatives instead.

### Constructors

- `public MenuButton(string caption, string description)`
- `public MenuButton(string caption)`

### Properties

- `public string Caption { get; set; }`
- `public string Description { get; set; }`
- `public MenuBase Parent { get; set; }`

### Methods

- `public virtual void Activate()`
- `public virtual void Change(bool right)`
- `public virtual void Deselect()`
- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Select()`
- `public virtual void SetOriginAndSize(Point origin, Size size)`

### Events

- `public event EventHandler<EventArgs> Activated`

## MenuEnumScroller

class `GTA.MenuEnumScroller` : `IMenuItem`

> **Obsolete.** The built-in menu implementation is obsolete. Please consider using external alternatives instead.

### Constructors

- `public MenuEnumScroller(string caption, string description, string[] entries, int selectedIndex)`
- `public MenuEnumScroller(string caption, string description, string[] entries)`

### Properties

- `public string Caption { get; set; }`
- `public string Description { get; set; }`
- `public int Index { get; set; }`
- `public MenuBase Parent { get; set; }`
- `public string Value { get; }`

### Methods

- `public virtual void Activate()`
- `public virtual void Change(bool right)`
- `public virtual void Deselect()`
- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Select()`
- `public virtual void SetOriginAndSize(Point origin, Size size)`

### Events

- `public event EventHandler<MenuItemIndexArgs> Activated`
- `public event EventHandler<MenuItemIndexArgs> Changed`

## MenuItemDoubleValueArgs

class `GTA.MenuItemDoubleValueArgs` : `EventArgs`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public MenuItemDoubleValueArgs(double value)`

### Properties

- `public double Index { get; }`

## MenuItemIndexArgs

class `GTA.MenuItemIndexArgs` : `EventArgs`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public MenuItemIndexArgs(int index)`

### Properties

- `public int Index { get; }`

## MenuLabel

class `GTA.MenuLabel` : `IMenuItem`

> **Obsolete.** The built-in menu implementation is obsolete. Please consider using external alternatives instead.

### Constructors

- `public MenuLabel(string caption, bool underlined)`
- `public MenuLabel(string caption)`

### Properties

- `public string Caption { get; set; }`
- `public string Description { get; set; }`
- `public MenuBase Parent { get; set; }`
- `public Color UnderlineColor { get; set; }`
- `public bool UnderlinedAbove { get; set; }`
- `public bool UnderlinedBelow { get; set; }`
- `public int UnderlineHeight { get; set; }`

### Methods

- `public virtual void Activate()`
- `public virtual void Change(bool right)`
- `public virtual void Deselect()`
- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Select()`
- `public virtual void SetOriginAndSize(Point origin, Size size)`

## MenuNumericScroller

class `GTA.MenuNumericScroller` : `IMenuItem`

> **Obsolete.** The built-in menu implementation is obsolete. Please consider using external alternatives instead.

### Constructors

- `public MenuNumericScroller(string caption, string description, double min, double max, double inc, int timesIncremented)`
- `public MenuNumericScroller(string caption, string description, double min, double max, double inc)`

### Properties

- `public string Caption { get; set; }`
- `public int DecimalFigures { get; set; }`
- `public string Description { get; set; }`
- `public double Increment { get; set; }`
- `public double Max { get; set; }`
- `public double Min { get; set; }`
- `public MenuBase Parent { get; set; }`
- `public int TimesIncremented { get; set; }`
- `public double Value { get; }`

### Methods

- `public virtual void Activate()`
- `public virtual void Change(bool right)`
- `public virtual void Deselect()`
- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Select()`
- `public virtual void SetOriginAndSize(Point origin, Size size)`

### Events

- `public event EventHandler<MenuItemDoubleValueArgs> Activated`
- `public event EventHandler<MenuItemDoubleValueArgs> Changed`

## MenuToggle

class `GTA.MenuToggle` : `IMenuItem`

> **Obsolete.** The built-in menu implementation is obsolete. Please consider using external alternatives instead.

### Constructors

- `public MenuToggle(string caption, string description, bool value)`
- `public MenuToggle(string caption, string description)`

### Properties

- `public string Caption { get; set; }`
- `public string Description { get; set; }`
- `public MenuBase Parent { get; set; }`
- `public bool Value { get; set; }`

### Methods

- `public virtual void Activate()`
- `public virtual void Change(bool right)`
- `public virtual void Deselect()`
- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Select()`
- `public virtual void SetOriginAndSize(Point origin, Size size)`

### Events

- `public event EventHandler<EventArgs> Changed`

## MessageBox

class `GTA.MessageBox` : `MenuBase`

> **Obsolete.** The built-in menu implementation is obsolete. Please consider using external alternatives instead.

### Constructors

- `public MessageBox(string headerCaption)`

### Properties

- `public int ButtonHeight { get; set; }`
- `public int Height { get; set; }`
- `public bool OkCancel { get; set; }`
- `public int Width { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`
- `public virtual void Initialize()`
- `public virtual void OnActivate()`
- `public virtual void OnChangeItem(bool right)`
- `public virtual void OnChangeSelection(bool down)`
- `public virtual void OnClose()`
- `public virtual void OnOpen()`

### Events

- `public event EventHandler<EventArgs> No`
- `public event EventHandler<EventArgs> Yes`

## Model

struct `GTA.Model` : `IEquatable<Model>`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Model(PedHash hash)`
- `public Model(VehicleHash hash)`
- `public Model(WeaponHash hash)`
- `public Model(int hash)`
- `public Model(string name)`

### Properties

- `public int Hash { get; }`
- `public bool IsBicycle { get; }`
- `public bool IsBike { get; }`
- `public bool IsBoat { get; }`
- `public bool IsCar { get; }`
- `public bool IsCargobob { get; }`
- `public bool IsCollisionLoaded { get; }`
- `public bool IsHelicopter { get; }`
- `public bool IsInCdImage { get; }`
- `public bool IsLoaded { get; }`
- `public bool IsPed { get; }`
- `public bool IsPlane { get; }`
- `public bool IsQuadbike { get; }`
- `public bool IsTrain { get; }`
- `public bool IsValid { get; }`
- `public bool IsVehicle { get; }`

### Methods

- `public bool Equals(Model obj)`
- `public virtual bool Equals(object obj)`
- `public Vector3 GetDimensions()`
- `public void GetDimensions(out Vector3 minimum, out Vector3 maximum)`
- `public virtual int GetHashCode()`
- `public void MarkAsNoLongerNeeded()`
- `public void Request()`
- `public bool Request(int timeout)`
- `public virtual string ToString()`
- `public static bool op_Equality(Model left, Model right)`
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

## Notification

class `GTA.Notification`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Methods

- `public void Hide()`

## NumberPlateMounting

enum `GTA.NumberPlateMounting`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `FrontAndRear` | 0 |
| `Front` | 1 |
| `Rear` | 2 |
| `None` | 3 |

## NumberPlateType

enum `GTA.NumberPlateType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `BlueOnWhite1` | 0 |
| `YellowOnBlack` | 1 |
| `YellowOnBlue` | 2 |
| `BlueOnWhite2` | 3 |
| `BlueOnWhite3` | 4 |
| `NorthYankton` | 5 |

## ParachuteTint

enum `GTA.ParachuteTint`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

## Ped

class `GTA.Ped` : `Entity`, `IEquatable<Entity>`, `IHandleable`, `ISpatial`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Ped(int handle)`

### Properties

- `public int Accuracy { get; set; }`
- `public bool AlwaysDiesOnLowHealth { set; }`
- `public bool AlwaysKeepTask { set; }`
- `public int Armor { get; set; }`
- `public bool BlockPermanentEvents { set; }`
- `public bool CanBeDraggedOutOfVehicle { set; }`
- `public bool CanBeKnockedOffBike { set; }`
- `public bool CanBeShotInVehicle { set; }`
- `public bool CanBeTargetted { set; }`
- `public bool CanFlyThroughWindscreen { get; set; }`
- `public bool CanPlayGestures { set; }`
- `public bool CanRagdoll { get; set; }`
- `public bool CanSufferCriticalHits { get; set; }`
- `public bool CanSwitchWeapons { set; }`
- `public bool CanWearHelmet { set; }`
- `public bool CanWrithe { get; set; }`
- `public PedGroup CurrentPedGroup { get; }`
- `public Vehicle CurrentVehicle { get; }`
- `public bool DiesInstantlyInWater { set; }`
- `public float DrivingSpeed { set; }`
- `public DrivingStyle DrivingStyle { set; }`
- `public bool DropsWeaponsOnDeath { get; set; }`
- `public bool DrownsInSinkingVehicle { set; }`
- `public bool DrownsInWater { set; }`
- `public Euphoria Euphoria { get; }`
- `public FiringPattern FiringPattern { set; }`
- `public Gender Gender { get; }`
- `public bool IsAimingFromCover { get; }`
- `public bool IsBeingJacked { get; }`
- `public bool IsBeingStealthKilled { get; }`
- `public bool IsBeingStunned { get; }`
- `public bool IsClimbing { get; }`
- `public bool IsCuffed { get; }`
- `public bool IsDiving { get; }`
- `public bool IsDoingDriveBy { get; }`
- `public bool IsDucking { get; set; }`
- `public bool IsEnemy { set; }`
- `public bool IsFalling { get; }`
- `public bool IsFleeing { get; }`
- `public bool IsGettingIntoAVehicle { get; }`
- `public bool IsGettingUp { get; }`
- `public bool IsGoingIntoCover { get; }`
- `public bool IsHuman { get; }`
- `public bool IsIdle { get; }`
- `public bool IsInBoat { get; }`
- `public bool IsInCombat { get; }`
- `public bool IsInCoverFacingLeft { get; }`
- `public bool IsInFlyingVehicle { get; }`
- `public bool IsInGroup { get; }`
- `public bool IsInHeli { get; }`
- `public bool IsInjured { get; }`
- `public bool IsInMeleeCombat { get; }`
- `public bool IsInParachuteFreeFall { get; }`
- `public bool IsInPlane { get; }`
- `public bool IsInPoliceVehicle { get; }`
- `public bool IsInSub { get; }`
- `public bool IsInTaxi { get; }`
- `public bool IsInTrain { get; }`
- `public bool IsJacking { get; }`
- `public bool IsJumping { get; }`
- `public bool IsJumpingOutOfVehicle { get; }`
- `public bool IsOnBike { get; }`
- `public bool IsOnFoot { get; }`
- `public bool IsPerformingStealthKill { get; }`
- `public bool IsPlayer { get; }`
- `public bool IsPriorityTargetForEnemies { set; }`
- `public bool IsProne { get; }`
- `public bool IsRagdoll { get; }`
- `public bool IsReloading { get; }`
- `public bool IsRunning { get; }`
- `public bool IsShooting { get; }`
- `public bool IsSprinting { get; }`
- `public bool IsStopped { get; }`
- `public bool IsSwimming { get; }`
- `public bool IsSwimmingUnderWater { get; }`
- `public bool IsTryingToEnterALockedVehicle { get; }`
- `public bool IsVaulting { get; }`
- `public bool IsWalking { get; }`
- `public bool IsWearingHelmet { get; }`
- `public Vehicle LastVehicle { get; }`
- `public float MaxDrivingSpeed { set; }`
- `public int MaxHealth { get; set; }`
- `public int Money { get; set; }`
- `public string MovementAnimationSet { set; }`
- `public bool NeverLeavesGroup { set; }`
- `public int RelationshipGroup { get; set; }`
- `public VehicleSeat SeatIndex { get; }`
- `public int ShootRate { set; }`
- `public bool StaysInVehicleWhenJacked { set; }`
- `public float Sweat { set; }`
- `public Tasks Task { get; }`
- `public int TaskSequenceProgress { get; }`
- `public string Voice { set; }`
- `public bool WasKilledByStealth { get; }`
- `public bool WasKilledByTakedown { get; }`
- `public WeaponCollection Weapons { get; }`
- `public float WetnessHeight { set; }`

### Methods

- `public void ApplyDamage(int damageAmount)`
- `public void ClearBloodDamage()`
- `public void Clone()`
- `public void Clone(float heading)`
- `public Vector3 GetBoneCoord(Bone BoneID, Vector3 Offset)`
- `public Vector3 GetBoneCoord(Bone BoneID)`
- `public int GetBoneIndex(Bone BoneID)`
- `public bool GetConfigFlag(int flagID)`
- `public Ped GetJacker()`
- `public Ped GetJackTarget()`
- `public Entity GetKiller()`
- `public Vector3 GetLastWeaponImpactCoords()`
- `public Ped GetMeleeTarget()`
- `public Relationship GetRelationshipWithPed(Ped ped)`
- `public Vehicle GetVehicleIsTryingToEnter()`
- `public void GiveHelmet(bool canBeRemovedByPed, HelmetType helmetType, int textureIndex)`
- `public bool IsHeadtracking(Entity entity)`
- `public bool IsInCombatAgainst(Ped target)`
- `public bool IsInCover()`
- `public bool IsInCover(bool expectUseWeapon)`
- `public bool IsInVehicle()`
- `public bool IsInVehicle(Vehicle vehicle)`
- `public bool IsSittingInVehicle()`
- `public bool IsSittingInVehicle(Vehicle vehicle)`
- `public void Kill()`
- `public void LeaveGroup()`
- `public void RandomizeOutfit()`
- `public void RemoveHelmet(bool instantly)`
- `public void ResetConfigFlag(int flagID)`
  - **Obsolete.** Ped.ResetConfigFlag is obsolete since SET_PED_RESET_FLAG uses different flag IDs from the IDs GET_PED_CONFIG_FLAG and SET_PED_CONFIG_FLAG useand Ped.ResetConfigFlag always set the flag (2nd argument of SET_PED_RESET_FLAG) to true. Call SET_PED_RESET_FLAG on your own.
- `public void ResetVisibleDamage()`
- `public void SetConfigFlag(int flagID, bool value)`
- `public void SetDefaultClothes()`
- `public void SetIntoVehicle(Vehicle vehicle, VehicleSeat seat)`

## PedGroup

class `GTA.PedGroup` : `IEquatable<PedGroup>`, `IEnumerable<Ped>`, `IEnumerable`, `IHandleable`, `IDisposable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public PedGroup()`
- `public PedGroup(int handle)`

### Properties

- `public FormationType FormationType { set; }`
- `public int Handle { get; }`
- `public Ped Leader { get; }`
- `public int MemberCount { get; }`
- `public float SeparationRange { set; }`

### Methods

- `public void Add(Ped ped, bool leader)`
- `public bool Contains(Ped ped)`
- `public void Dispose()`
- `protected virtual void Dispose(bool disposing)`
- `public bool Equals(PedGroup obj)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public virtual IEnumerator<Ped> GetEnumerator()`
- `public IEnumerator GetEnumerator2()`
- `public virtual int GetHashCode()`
- `public Ped GetMember(int index)`
- `public void Remove(Ped ped)`
- `public Ped[] ToArray(bool includingLeader)`
- `public List<Ped> ToList(bool includingLeader)`
- `public static bool Exists(PedGroup pedGroup)`
- `public static bool op_Equality(PedGroup left, PedGroup right)`
- `public static bool op_Inequality(PedGroup left, PedGroup right)`

## PedGroup.enumerator

class `GTA.PedGroup.enumerator` : `IEnumerator<Ped>`, `IDisposable`, `IEnumerator`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public enumerator(PedGroup group)`

### Properties

- `public Ped Current { get; }`
- `public object Current2 { get; }`

### Methods

- `public void Dispose()`
- `protected virtual void Dispose(bool disposing)`
- `public virtual bool MoveNext()`
- `public virtual void Reset()`

## Pickup

class `GTA.Pickup` : `IEquatable<Pickup>`, `IHandleable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Pickup(int handle)`

### Properties

- `public int Handle { get; }`
- `public bool IsCollected { get; }`
- `public Vector3 Position { get; }`

### Methods

- `public void Delete()`
- `public bool Equals(Pickup obj)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public virtual int GetHashCode()`
- `public bool ObjectExists()`
- `public static bool Exists(Pickup pickup)`
- `public static bool op_Equality(Pickup left, Pickup right)`
- `public static bool op_Inequality(Pickup left, Pickup right)`

## PickupType

enum `GTA.PickupType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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
PortableCrateFixedIncarSmall = 2817147086
PortableCrateFixedIncarWithPassengers = 2689501965
PortableCrateUnfixed = 1852930709
PortableCrateUnfixedInairvehicleWithPassengers = 2431639355
PortableCrateUnfixedInairvehicleWithPassengersUpright = 68603185
PortableCrateUnfixedIncar = 1263688126
PortableCrateUnfixedIncarSmall = 3285027633
PortableCrateUnfixedIncarWithPassengers = 79909481
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
VehicleMoneyVariable = 1704231442
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

class `GTA.Player` : `IEquatable<Player>`, `IHandleable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Player(int handle)`

### Properties

- `public bool CanControlCharacter { get; set; }`
- `public bool CanControlRagdoll { set; }`
- `public bool CanStartMission { get; }`
- `public bool CanUseCover { set; }`
- `public Ped Character { get; }`
- `public Color Color { get; }`
- `public int Handle { get; }`
- `public bool IgnoredByEveryone { set; }`
- `public bool IgnoredByPolice { set; }`
- `public bool IsAiming { get; }`
- `public bool IsAlive { get; }`
- `public bool IsClimbing { get; }`
- `public bool IsDead { get; }`
- `public bool IsInvincible { get; set; }`
- `public bool IsPlaying { get; }`
- `public bool IsPressingHorn { get; }`
- `public bool IsRidingTrain { get; }`
- `public bool IsTargettingAnything { get; }`
- `public Vehicle LastVehicle { get; }`
- `public int MaxArmor { get; set; }`
- `public int Money { get; set; }`
- `public string Name { get; }`
- `public ParachuteTint PrimaryParachuteTint { get; set; }`
- `public float RemainingSprintTime { get; }`
- `public float RemainingUnderwaterTime { get; }`
- `public ParachuteTint ReserveParachuteTint { get; set; }`
- `public Vector3 WantedCenterPosition { get; set; }`
- `public int WantedLevel { get; set; }`

### Methods

- `public bool ChangeModel(Model model)`
- `public void DisableFiringThisFrame()`
- `public bool Equals(Player obj)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public virtual int GetHashCode()`
- `public Entity GetTargetedEntity()`
- `public bool IsTargetting(Entity entity)`
- `public void RefillSpecialAbility()`
- `public void SetExplosiveAmmoThisFrame()`
- `public void SetExplosiveMeleeThisFrame()`
- `public void SetFireAmmoThisFrame()`
- `public void SetMayNotEnterAnyVehicleThisFrame()`
- `public void SetMayOnlyEnterThisVehicleThisFrame(Vehicle vehicle)`
- `public void SetRunSpeedMultThisFrame(float value)`
- `public void SetSuperJumpThisFrame()`
- `public void SetSwimSpeedMultThisFrame(float value)`
- `public static bool op_Equality(Player left, Player right)`
- `public static bool op_Inequality(Player left, Player right)`

## Prop

class `GTA.Prop` : `Entity`, `IEquatable<Entity>`, `IHandleable`, `ISpatial`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Prop(int handle)`

## RadioStation

enum `GTA.RadioStation`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Unknown` | -1 |
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

## RaycastResult

struct `GTA.RaycastResult`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public bool DitHitAnything { get; }`
- `public bool DitHitEntity { get; }`
- `public Vector3 HitCoords { get; }`
- `public Entity HitEntity { get; }`
- `public int Result { get; }`
- `public Vector3 SurfaceNormal { get; }`

## Relationship

enum `GTA.Relationship`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Hate` | 5 |
| `Dislike` | 4 |
| `Neutral` | 3 |
| `Like` | 2 |
| `Respect` | 1 |
| `Companion` | 0 |
| `Pedestrians` | 255 |

## RequireScript

class `GTA.RequireScript` : `Attribute`, `_Attribute`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public RequireScript(Type dependency)`

## Rope

class `GTA.Rope` : `IEquatable<Rope>`, `IHandleable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Rope(int handle)`

### Properties

- `public int Handle { get; }`
- `public float Length { get; set; }`
- `public int VertexCount { get; }`

### Methods

- `public void ActivatePhysics()`
- `public void AttachEntities(Entity entityOne, Entity entityTwo, float length)`
- `public void AttachEntities(Entity entityOne, Vector3 positionOne, Entity entityTwo, Vector3 positionTwo, float length)`
- `public void AttachEntity(Entity entity, Vector3 position)`
- `public void AttachEntity(Entity entity)`
- `public void Delete()`
- `public void DetachEntity(Entity entity)`
- `public bool Equals(Rope obj)`
- `public virtual bool Equals(object obj)`
- `public bool Exists()`
- `public virtual int GetHashCode()`
- `public Vector3 GetVertexCoord(int vertex)`
- `public void PinVertex(int vertex, Vector3 position)`
- `public void ResetLength(bool reset)`
- `public void UnpinVertex(int vertex)`
- `public static bool Exists(Rope rope)`
- `public static bool op_Equality(Rope left, Rope right)`
- `public static bool op_Inequality(Rope left, Rope right)`

## RopeType

enum `GTA.RopeType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Normal` | 4 |

## Scaleform

class `GTA.Scaleform` : `IDisposable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Scaleform(int handle)`
  - **Obsolete.** Use Scaleform(string scaleformID) in this API version instead. In the v3 API, use one of static constructors such as Scaleform.RequestMovie instead.
- `public Scaleform(string scaleformID)`

### Properties

- `public int Handle { get; }`
- `public bool IsLoaded { get; }`
- `public bool IsValid { get; }`

### Methods

- `public void CallFunction(string function, params object[] arguments)`
- `public void Dispose()`
- `public bool Load(string scaleformID)`
  - **Obsolete.** Use Scaleform(string scaleformID) in this API version instead. In the v3 API, use one of static constructors such as Scaleform.RequestMovie instead.
- `public void Render2D()`
- `public void Render2DScreenSpace(PointF position, PointF size)`
- `public void Render3D(Vector3 position, Vector3 rotation, Vector3 scale)`
- `public void Render3DAdditive(Vector3 position, Vector3 rotation, Vector3 scale)`
- `public void Unload()`

## ScaleformArgumentTXD

class `GTA.ScaleformArgumentTXD`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public ScaleformArgumentTXD(string s)`

## Script

abstract class `GTA.Script` : `IDisposable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Script()`

### Properties

- `public string Filename { get; }`
- `protected int Interval { get; set; }`
- `public string Name { get; }`
- `public ScriptSettings Settings { get; }`
- `public Viewport View { get; }`

### Methods

- `public void Abort()`
- `public void Dispose()`
- `protected virtual void Dispose(bool disposing)`
- `public virtual string ToString()`
- `public static void Wait(int ms)`
- `public static void Yield()`

### Events

- `public event EventHandler Aborted`
- `public event KeyEventHandler KeyDown`
- `public event KeyEventHandler KeyUp`
- `public event EventHandler Tick`

### Fields

- `public Keys ActivateKey`
- `public Keys BackKey`
- `public Keys DownKey`
- `public Keys LeftKey`
- `public Keys RightKey`
- `public Keys UpKey`

## ScriptSettings

class `GTA.ScriptSettings`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Methods

- `public string[] GetAllValues(string section, string key)`
- `public string GetValue(string section, string key, string defaultvalue)`
- `public string GetValue(string section, string key)`
- `public T GetValue<T>(string section, string name, T defaultvalue)`
- `public bool Save()`
- `public void SetValue(string section, string key, string value)`
- `public void SetValue<T>(string section, string name, T value)`
- `public static ScriptSettings Load(string filename)`

## SelectedIndexChangedArgs

class `GTA.SelectedIndexChangedArgs` : `EventArgs`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public SelectedIndexChangedArgs(int selectedIndex)`

### Properties

- `public int SelectedIndex { get; }`

## Tasks

class `GTA.Tasks`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Methods

- `public void AchieveHeading(float heading, int timeout)`
- `public void AchieveHeading(float heading)`
- `public void AimAt(Entity target, int duration)`
- `public void AimAt(Vector3 target, int duration)`
- `public void Arrest(Ped ped)`
- `public void ChatTo(Ped ped)`
- `public void ClearAll()`
- `public void ClearAllImmediately()`
- `public void ClearAnimation(string animSet, string animName)`
- `public void ClearLookAt()`
- `public void ClearSecondary()`
- `public void Climb()`
- `public void Cower(int duration)`
- `public void CruiseWithVehicle(Vehicle vehicle, float speed, int drivingstyle)`
- `public void CruiseWithVehicle(Vehicle vehicle, float speed)`
- `public void DriveTo(Vehicle vehicle, Vector3 position, float radius, float speed, int drivingstyle)`
- `public void DriveTo(Vehicle vehicle, Vector3 position, float radius, float speed)`
- `public void EnterVehicle()`
- `public void EnterVehicle(Vehicle vehicle, VehicleSeat seat, int timeout, float speed, int flag)`
- `public void EnterVehicle(Vehicle vehicle, VehicleSeat seat, int timeout, float speed)`
- `public void EnterVehicle(Vehicle vehicle, VehicleSeat seat, int timeout)`
- `public void EnterVehicle(Vehicle vehicle, VehicleSeat seat)`
- `public void FightAgainst(Ped target, int duration)`
- `public void FightAgainst(Ped target)`
- `public void FightAgainstHatedTargets(float radius, int duration)`
- `public void FightAgainstHatedTargets(float radius)`
- `public void FleeFrom(Vector3 position, int duration)`
- `public void FleeFrom(Vector3 position)`
- `public void FleeFrom(Ped ped, int duration)`
- `public void FleeFrom(Ped ped)`
- `public void FollowPointRoute(params Vector3[] points)`
- `public void FollowToOffsetFromEntity(Entity target, Vector3 offset, int timeout, float stoppingRange)`
- `public void FollowToOffsetFromEntity(Entity target, Vector3 offset, float movementSpeed, int timeout, float stoppingRange, bool persistFollowing)`
- `public void GoTo(Entity target, Vector3 offset, int timeout)`
- `public void GoTo(Entity target, Vector3 offset)`
- `public void GoTo(Entity target)`
- `public void GoTo(Vector3 position, bool ignorePaths, int timeout)`
- `public void GoTo(Vector3 position, bool ignorePaths)`
- `public void GoTo(Vector3 position)`
- `public void GuardCurrentPosition()`
- `public void HandsUp(int duration)`
- `public void Jump()`
- `public void LeaveVehicle()`
- `public void LeaveVehicle(LeaveVehicleFlags flags)`
- `public void LeaveVehicle(Vehicle vehicle, LeaveVehicleFlags flags)`
- `public void LeaveVehicle(Vehicle vehicle, bool closeDoor)`
- `public void LookAt(Entity target, int duration)`
- `public void LookAt(Entity target)`
- `public void LookAt(Vector3 position, int duration)`
- `public void LookAt(Vector3 position)`
- `public void ParachuteTo(Vector3 position)`
- `public void ParkVehicle(Vehicle vehicle, Vector3 position, float heading, float radius, bool keepEngineOn)`
- `public void ParkVehicle(Vehicle vehicle, Vector3 position, float heading, float radius)`
- `public void ParkVehicle(Vehicle vehicle, Vector3 position, float heading)`
- `public void PerformSequence(TaskSequence sequence)`
- `public void PlayAnimation(string animDict, string animName, float blendInSpeed, int duration, AnimationFlags flags)`
- `public void PlayAnimation(string animDict, string animName, float speed, int duration, bool loop, float playbackRate)`
- `public void PlayAnimation(string animDict, string animName, float blendInSpeed, float blendOutSpeed, int duration, AnimationFlags flags, float playbackRate)`
- `public void PlayAnimation(string animDict, string animName)`
- `public void PutAwayMobilePhone()`
- `public void PutAwayParachute()`
- `public void ReactAndFlee(Ped ped)`
- `public void ReloadWeapon()`
- `public void RunTo(Vector3 position, bool ignorePaths, int timeout)`
- `public void RunTo(Vector3 position, bool ignorePaths)`
- `public void RunTo(Vector3 position)`
- `public void ShootAt(Vector3 position, int duration, FiringPattern pattern)`
- `public void ShootAt(Vector3 position, int duration)`
- `public void ShootAt(Vector3 position)`
- `public void ShootAt(Ped target, int duration, FiringPattern pattern)`
- `public void ShootAt(Ped target, int duration)`
- `public void ShootAt(Ped target)`
- `public void ShuffleToNextVehicleSeat(Vehicle vehicle)`
- `public void Skydive()`
- `public void SlideTo(Vector3 position, float heading)`
- `public void StandStill(int duration)`
- `public void StartScenario(string name, Vector3 position, float heading)`
- `public void StartScenario(string name, Vector3 position)`
- `public void StartScenario(string name)`
- `public void SwapWeapon()`
- `public void TurnTo(Entity target, int duration)`
- `public void TurnTo(Entity target)`
- `public void TurnTo(Vector3 position, int duration)`
- `public void TurnTo(Vector3 position)`
- `public void UseMobilePhone()`
- `public void UseMobilePhone(int duration)`
- `public void UseParachute()`
- `public void VehicleChase(Ped target)`
- `public void VehicleShootAtPed(Ped target)`
- `public void Wait(int duration)`
- `public void WanderAround()`
- `public void WanderAround(Vector3 position, float radius)`
- `public void WarpIntoVehicle(Vehicle vehicle, VehicleSeat seat)`
- `public void WarpOutOfVehicle(Vehicle vehicle)`
- `public static void EveryoneLeaveVehicle(Vehicle vehicle)`

## TaskSequence

class `GTA.TaskSequence` : `IDisposable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public TaskSequence()`
- `public TaskSequence(int handle)`

### Properties

- `public Tasks AddTask { get; }`
- `public int Count { get; }`
- `public int Handle { get; }`
- `public bool IsClosed { get; }`

### Methods

- `public void Close()`
- `public void Close(bool repeat)`
- `public void Dispose()`

## UI

static class `GTA.UI`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Methods

- `public static void DrawTexture(string filename, int index, int level, int time, Point pos, PointF center, Size size, float rotation, Color color, float aspectRatio)`
- `public static void DrawTexture(string filename, int index, int level, int time, Point pos, PointF center, Size size, float rotation, Color color)`
- `public static void DrawTexture(string filename, int index, int level, int time, Point pos, Size size, float rotation, Color color)`
- `public static void DrawTexture(string filename, int index, int level, int time, Point pos, Size size)`
- `public static void HideHudComponentThisFrame(HudComponent component)`
- `public static bool IsHudComponentActive(HudComponent component)`
- `public static Notification Notify(string message, bool blinking)`
- `public static Notification Notify(string message)`
- `public static void ShowHelpMessage(string message, bool sound)`
- `public static void ShowHelpMessage(string message, int duration, bool sound)`
- `public static void ShowHelpMessage(string message, int duration)`
- `public static void ShowHelpMessage(string message)`
- `public static void ShowHudComponentThisFrame(HudComponent component)`
- `public static void ShowSubtitle(string message, int duration)`
- `public static void ShowSubtitle(string message)`
- `public static Point WorldToScreen(Vector3 position)`

### Fields

- `public static int HEIGHT`
- `public static int WIDTH`

## UIContainer

class `GTA.UIContainer` : `UIRectangle`, `UIElement`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public UIContainer()`
- `public UIContainer(Point position, Size size, Color color)`
- `public UIContainer(Point position, Size size)`

### Properties

- `public List<UIElement> Items { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`

## UIElement

interface `GTA.UIElement`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public Color Color { get; set; }`
- `public bool Enabled { get; set; }`
- `public Point Position { get; set; }`

### Methods

- `public void Draw()`
- `public void Draw(Size offset)`

## UIRectangle

class `GTA.UIRectangle` : `UIElement`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public UIRectangle()`
- `public UIRectangle(Point position, Size size, Color color)`
- `public UIRectangle(Point position, Size size)`

### Properties

- `public Color Color { get; set; }`
- `public bool Enabled { get; set; }`
- `public Point Position { get; set; }`
- `public Size Size { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`

## UISprite

class `GTA.UISprite` : `UIElement`, `IDisposable`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public UISprite(string textureDict, string textureName, Size scale, Point position, Color color, float rotation)`
- `public UISprite(string textureDict, string textureName, Size scale, Point position, Color color)`
- `public UISprite(string textureDict, string textureName, Size scale, Point position)`

### Properties

- `public Color Color { get; set; }`
- `public bool Enabled { get; set; }`
- `public Point Position { get; set; }`
- `public float Rotation { get; set; }`
- `public Size Scale { get; set; }`

### Methods

- `public void Dispose()`
- `protected virtual void Dispose(bool disposing)`
- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`

## UIText

class `GTA.UIText` : `UIElement`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public UIText(string caption, Point position, float scale, Color color, Font font, bool centered, bool shadow, bool outline)`
- `public UIText(string caption, Point position, float scale, Color color, Font font, bool centered)`
- `public UIText(string caption, Point position, float scale, Color color)`
- `public UIText(string caption, Point position, float scale)`

### Properties

- `public string Caption { get; set; }`
- `public bool Centered { get; set; }`
- `public Color Color { get; set; }`
- `public bool Enabled { get; set; }`
- `public Font Font { get; set; }`
- `public bool Outline { get; set; }`
- `public Point Position { get; set; }`
- `public float Scale { get; set; }`
- `public bool Shadow { get; set; }`

### Methods

- `public virtual void Draw()`
- `public virtual void Draw(Size offset)`

## Vehicle

class `GTA.Vehicle` : `Entity`, `IEquatable<Entity>`, `IHandleable`, `ISpatial`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Vehicle(int handle)`

### Properties

- `public float Acceleration { get; }`
- `public bool AlarmActive { get; }`
- `public float BodyHealth { get; set; }`
- `public bool BrakeLightsOn { set; }`
- `public bool CanBeVisiblyDamaged { set; }`
- `public bool CanTiresBurst { get; set; }`
- `public bool CanWheelsBreak { set; }`
- `public VehicleClass ClassType { get; }`
- `public int ColorCombination { get; set; }`
- `public int ColorCombinationCount { get; }`
- `public int CurrentGear { get; }`
- `public float CurrentRPM { get; set; }`
- `public Color CustomPrimaryColor { get; set; }`
- `public Color CustomSecondaryColor { get; set; }`
- `public VehicleColor DashboardColor { get; set; }`
- `public float DirtLevel { get; set; }`
- `public string DisplayName { get; }`
- `public Ped Driver { get; }`
- `public bool DropsMoneyOnExplosion { set; }`
- `public bool EngineCanDegrade { set; }`
- `public float EngineHealth { get; set; }`
- `public float EnginePowerMultiplier { set; }`
- `public bool EngineRunning { get; set; }`
- `public float EngineTorqueMultiplier { set; }`
- `public string FriendlyName { get; }`
- `public float FuelLevel { get; set; }`
- `public bool HandbrakeOn { set; }`
- `public bool HasAlarm { set; }`
- `public bool HasBombBay { get; }`
- `public bool HasForks { get; }`
- `public bool HasRoof { get; }`
- `public bool HasSiren { get; }`
- `public bool HasTowArm { get; }`
- `public bool HighBeamsOn { get; set; }`
- `public int HighGear { get; set; }`
- `public bool InteriorLightOn { set; }`
- `public bool IsAxlesStrong { set; }`
- `public bool IsConvertible { get; }`
- `public bool IsDamaged { get; }`
- `public bool IsDriveable { get; set; }`
- `public bool IsFrontBumperBrokenOff { get; }`
- `public bool IsOnAllWheels { get; }`
- `public bool IsPrimaryColorCustom { get; }`
- `public bool IsRadioEnabled { set; }`
- `public bool IsRearBumperBrokenOff { get; }`
- `public bool IsSecondaryColorCustom { get; }`
- `public bool IsSirenSilent { set; }`
- `public bool IsStolen { get; set; }`
- `public bool IsStopped { get; }`
- `public bool IsStoppedAtTrafficLights { get; }`
- `public bool IsWanted { set; }`
- `public VehicleLandingGear LandingGear { get; set; }`
- `public bool LeftHeadLightBroken { get; set; }`
- `public bool LeftIndicatorLightOn { set; }`
- `public float LightsMultiplier { set; }`
- `public bool LightsOn { get; set; }`
- `public int Livery { get; set; }`
- `public int LiveryCount { get; }`
- `public VehicleLockStatus LockStatus { get; set; }`
- `public float MaxBraking { get; }`
- `public float MaxTraction { get; }`
- `public bool NeedsToBeHotwired { get; set; }`
- `public Color NeonLightsColor { get; set; }`
- `public string NumberPlate { get; set; }`
- `public NumberPlateMounting NumberPlateMounting { get; }`
- `public NumberPlateType NumberPlateType { get; set; }`
- `public Ped[] Occupants { get; }`
- `public int PassengerCount { get; }`
- `public Ped[] Passengers { get; }`
- `public int PassengerSeats { get; }`
- `public VehicleColor PearlescentColor { get; set; }`
- `public float PetrolTankHealth { get; set; }`
- `public bool PreviouslyOwnedByPlayer { get; set; }`
- `public VehicleColor PrimaryColor { get; set; }`
- `public bool ProvidesCover { set; }`
- `public RadioStation RadioStation { set; }`
- `public bool RightHeadLightBroken { get; set; }`
- `public bool RightIndicatorLightOn { set; }`
- `public VehicleColor RimColor { get; set; }`
- `public VehicleRoofState RoofState { get; set; }`
- `public bool SearchLightOn { get; set; }`
- `public VehicleColor SecondaryColor { get; set; }`
- `public bool SirenActive { get; set; }`
- `public float Speed { get; set; }`
- `public float Steering { get; }`
  - **Obsolete.** Vehicle.Steering is obsolete, please use Vehicle.SteeringScale instead.
- `public float SteeringAngle { get; set; }`
- `public float SteeringScale { get; set; }`
- `public bool TaxiLightOn { get; set; }`
- `public Color TireSmokeColor { get; set; }`
- `public Vehicle TowedVehicle { get; }`
- `public float TowingCraneRaisedAmount { set; }`
- `public VehicleColor TrimColor { get; set; }`
- `public float WheelSpeed { get; }`
- `public VehicleWheelType WheelType { get; set; }`
- `public VehicleWindowTint WindowTint { get; set; }`

### Methods

- `public void ApplyDamage(Vector3 loc, float damageAmount, float radius)`
- `public void BreakDoor(VehicleDoor door)`
- `public void BurstTire(int wheel)`
- `public void CargoBobMagnetGrabVehicle()`
- `public void CargoBobMagnetReleaseVehicle()`
- `public void ClearCustomPrimaryColor()`
- `public void ClearCustomSecondaryColor()`
- `public void CloseBombBay()`
- `public void CloseDoor(VehicleDoor door, bool instantly)`
- `public Ped CreatePedOnSeat(VehicleSeat seat, Model model)`
- `public Ped CreateRandomPedOnSeat(VehicleSeat seat)`
- `public void DetachFromTowTruck()`
- `public void DetachTowedVehicle()`
- `public void DropCargobobHook(CargobobHook hookType)`
- `public void Explode()`
- `public bool ExtraExists(int extra)`
- `public void FixTire(int wheel)`
- `public void FixWindow(VehicleWindow window)`
- `public float GetDoorAngleRatio(VehicleDoor door)`
- `public VehicleDoor[] GetDoors()`
- `public int GetMod(VehicleMod modType)`
- `public int GetModCount(VehicleMod modType)`
- `public string GetModName(VehicleMod modType, int modValue)`
- `public string GetModTypeName(VehicleMod modType)`
- `public Ped GetPedOnSeat(VehicleSeat seat)`
- `public string GetToggleModTypeName(VehicleToggleMod toggleModType)`
- `public void InstallModKit()`
- `public bool IsCargobobHookActive()`
- `public bool IsCargobobHookActive(CargobobHook hookType)`
- `public bool IsDoorBroken(VehicleDoor door)`
- `public bool IsDoorOpen(VehicleDoor door)`
- `public bool IsExtraOn(int extra)`
- `public bool IsInBurnout()`
- `public bool IsNeonLightsOn(VehicleNeonLight light)`
- `public bool IsSeatFree(VehicleSeat seat)`
- `public bool IsTireBurst(int wheel)`
- `public bool IsToggleModOn(VehicleToggleMod toggleMod)`
- `public void OpenBombBay()`
- `public void OpenDoor(VehicleDoor door, bool loose, bool instantly)`
- `public bool PlaceOnGround()`
- `public void PlaceOnNextStreet()`
- `public void RemoveCargobobHook()`
- `public void RemoveWindow(VehicleWindow window)`
- `public void Repair()`
- `public void RollDownWindow(VehicleWindow window)`
- `public void RollDownWindows()`
- `public void RollUpWindow(VehicleWindow window)`
- `public void SetDoorBreakable(VehicleDoor door, bool isBreakable)`
- `public void SetHeliYawPitchRollMult(float mult)`
- `public void SetMod(VehicleMod modType, int modIndex, bool variations)`
- `public void SetNeonLightsOn(VehicleNeonLight light, bool on)`
- `public void SmashWindow(VehicleWindow window)`
- `public void SoundHorn(int duration)`
- `public void StartAlarm()`
- `public void ToggleExtra(int extra, bool toggle)`
- `public void ToggleMod(VehicleToggleMod toggleMod, bool toggle)`
- `public void TowVehicle(Vehicle vehicle, bool rear)`
- `public void Wash()`

## VehicleClass

enum `GTA.VehicleClass`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

enum `GTA.VehicleDoor`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `FrontRightDoor` | 1 |
| `FrontLeftDoor` | 0 |
| `BackRightDoor` | 3 |
| `BackLeftDoor` | 2 |
| `Hood` | 4 |
| `Trunk` | 5 |

## VehicleLandingGear

enum `GTA.VehicleLandingGear`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Deployed` | 0 |
| `Closing` | 1 |
| `Opening` | 3 |
| `Retracted` | 4 |
| `Broken` | 5 |

## VehicleLockStatus

enum `GTA.VehicleLockStatus`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value | Description |
| --- | --- | --- |
| `None` | 0 |  |
| `Unlocked` | 1 |  |
| `Locked` | 2 |  |
| `LockedForPlayer` | 3 |  |
| `StickPlayerInside` | 4 | Doesn't allow players to exit the vehicle with the exit vehicle key. |
| `CanBeBrokenInto` | 7 | Can be broken into the car. If the glass is broken, the value will be set to 1. |
| `CanBeBrokenIntoPersist` | 8 |  |
| `CannotBeTriedToEnter` | 10 |  |

## VehicleMod

enum `GTA.VehicleMod`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
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
| `FrontWheels` | 23 |
| `BackWheels` | 24 |
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

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Left` | 0 |
| `Right` | 1 |
| `Front` | 2 |
| `Back` | 3 |

## VehicleRoofState

enum `GTA.VehicleRoofState`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Closed` | 0 |
| `Opening` | 1 |
| `Opened` | 2 |
| `Closing` | 3 |

## VehicleSeat

enum `GTA.VehicleSeat`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

## VehicleToggleMod

enum `GTA.VehicleToggleMod`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Turbo` | 18 |
| `TireSmoke` | 20 |
| `XenonHeadlights` | 22 |

## VehicleWheelType

enum `GTA.VehicleWheelType`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

enum `GTA.VehicleWindow`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `FrontLeftWindow` | 0 |
| `FrontRightWindow` | 1 |
| `BackLeftWindow` | 2 |
| `BackRightWindow` | 3 |

## VehicleWindowTint

enum `GTA.VehicleWindowTint`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `None` | 0 |
| `PureBlack` | 1 |
| `DarkSmoke` | 2 |
| `LightSmoke` | 3 |
| `Stock` | 4 |
| `Limo` | 5 |
| `Green` | 6 |

## Viewport

class `GTA.Viewport`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public Viewport()`

### Properties

- `public int ActiveMenus { get; }`
- `public Point MenuOffset { get; set; }`
- `public Point MenuPosition { get; set; }`
- `public bool MenuTransitions { get; set; }`

### Methods

- `public void AddMenu(MenuBase newMenu)`
- `public void CloseAllMenus()`
- `public void Draw()`
- `public void HandleActivate()`
- `public void HandleBack()`
- `public void HandleChangeItem(bool right)`
- `public void HandleChangeSelection(bool down)`
- `public void PopMenu()`
- `public void RemoveMenu(MenuBase menu)`

## Weapon

class `GTA.Weapon`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public int Ammo { get; set; }`
- `public int AmmoInClip { get; set; }`
- `public bool CanUseOnParachute { get; }`
- `public int DefaultClipSize { get; }`
- `public WeaponGroup Group { get; }`
- `public WeaponHash Hash { get; }`
- `public bool InfiniteAmmo { set; }`
- `public bool InfiniteAmmoClip { set; }`
- `public bool IsPresent { get; }`
- `public int MaxAmmo { get; }`
- `public int MaxAmmoInClip { get; }`
- `public int MaxComponents { get; }`
- `public Model Model { get; }`
- `public string Name { get; }`
- `public WeaponTint Tint { get; set; }`

### Methods

- `public string ComponentName(WeaponComponent component)`
- `public WeaponComponent GetComponent(int index)`
- `public bool IsComponentActive(WeaponComponent component)`
- `public void SetComponent(WeaponComponent component, bool on)`
- `public static string GetComponentDisplayNameFromHash(WeaponHash hash, WeaponComponent component)`
- `public static WeaponComponent[] GetComponentsFromHash(WeaponHash hash)`
- `public static string GetDisplayNameFromHash(WeaponHash hash)`

## WeaponAsset

struct `GTA.WeaponAsset` : `IEquatable<WeaponAsset>`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Constructors

- `public WeaponAsset(WeaponHash weaponHash)`
- `public WeaponAsset(int weaponHash)`
- `public WeaponAsset(uint weaponHash)`

### Properties

- `public int Hash { get; }`
- `public bool IsLoaded { get; }`
- `public bool IsValid { get; }`

### Methods

- `public void Dismiss()`
- `public bool Equals(WeaponAsset obj)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public void Request()`
- `public bool Request(int timeout)`
- `public virtual string ToString()`
- `public static bool op_Equality(WeaponAsset left, WeaponAsset right)`
- `public static WeaponAsset op_Implicit(WeaponHash hash)`
- `public static WeaponAsset op_Implicit(int hash)`
- `public static WeaponAsset op_Implicit(uint hash)`
- `public static bool op_Inequality(WeaponAsset left, WeaponAsset right)`

## WeaponCollection

class `GTA.WeaponCollection`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public Weapon BestWeapon { get; }`
- `public Weapon Current { get; }`
- `public Prop CurrentWeaponObject { get; }`
- `public Weapon this[WeaponHash hash] { get; }`

### Methods

- `public void Drop()`
- `public Weapon Give(WeaponHash hash, int ammoCount, bool equipNow, bool isAmmoLoaded)`
- `public Weapon Give(string name, int ammoCount, bool equipNow, bool isAmmoLoaded)`
- `public bool HasWeapon(WeaponHash weaponHash)`
- `public bool IsWeaponValid(WeaponHash hash)`
- `public void Remove(WeaponHash weaponHash)`
- `public void Remove(Weapon weapon)`
- `public void RemoveAll()`
- `public bool Select(WeaponHash weaponHash, bool equipNow)`
- `public bool Select(WeaponHash weaponHash)`
- `public bool Select(Weapon weapon)`

## WeaponGroup

enum `GTA.WeaponGroup`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `Unarmed` | 2685387236 |
| `Melee` | 3566412244 |
| `Pistol` | 416676503 |
| `SMG` | 3337201093 |
| `AssaultRifle` | 970310034 |
| `MG` | 1159398588 |
| `Shotgun` | 860033945 |
| `Sniper` | 3082541095 |
| `Heavy` | 2725924767 |
| `Thrown` | 1548507267 |
| `PetrolCan` | 1595662460 |

## WeaponTint

enum `GTA.WeaponTint`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

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

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

| Name | Value |
| --- | --- |
| `CELL_EMAIL_BOD` | 0 |
| `CELL_EMAIL_BODE` | 1 |
| `CELL_EMAIL_BODF` | 2 |
| `CELL_EMAIL_SOD` | 3 |
| `CELL_EMAIL_SODE` | 4 |
| `CELL_EMAIL_SODF` | 5 |
| `CELL_EMASH_BOD` | 6 |
| `CELL_EMASH_BODE` | 7 |
| `CELL_EMASH_BODF` | 8 |
| `CELL_EMASH_SOD` | 9 |
| `CELL_EMASH_SODE` | 10 |
| `CELL_EMASH_SODF` | 11 |
| `FMMC_KEY_TIP10` | 12 |
| `FMMC_KEY_TIP12` | 13 |
| `FMMC_KEY_TIP12F` | 14 |
| `FMMC_KEY_TIP12N` | 15 |
| `FMMC_KEY_TIP8` | 16 |
| `FMMC_KEY_TIP8F` | 17 |
| `FMMC_KEY_TIP8FS` | 18 |
| `FMMC_KEY_TIP8S` | 19 |
| `FMMC_KEY_TIP9` | 20 |
| `FMMC_KEY_TIP9F` | 21 |
| `FMMC_KEY_TIP9N` | 22 |
| `PM_NAME_CHALL` | 23 |

## World

static class `GTA.World`

> **Obsolete.** The v2 API is deprecated, use the v3 API instead.

### Properties

- `public static DateTime CurrentDate { get; set; }`
- `public static TimeSpan CurrentDayTime { get; set; }`
- `public static int GravityLevel { set; }`
- `public static Weather NextWeather { get; set; }`
- `public static Camera RenderingCamera { get; set; }`
- `public static Weather Weather { get; set; }`
- `public static float WeatherTransition { get; set; }`

### Methods

- `public static void AddExplosion(Vector3 position, ExplosionType type, float radius, float cameraShake, bool Aubidble, bool Invis)`
- `public static void AddExplosion(Vector3 position, ExplosionType type, float radius, float cameraShake)`
- `public static void AddOwnedExplosion(Ped ped, Vector3 position, ExplosionType type, float radius, float cameraShake, bool Aubidble, bool Invis)`
- `public static void AddOwnedExplosion(Ped ped, Vector3 position, ExplosionType type, float radius, float cameraShake)`
- `public static int AddRelationshipGroup(string groupName)`
- `public static Rope AddRope(RopeType type, Vector3 position, Vector3 rotation, float length, float minLength, bool breakable)`
- `public static float CalculateTravelDistance(Vector3 origin, Vector3 destination)`
- `public static void ClearRelationshipBetweenGroups(Relationship relationship, int group1, int group2)`
- `public static Prop CreateAmbientPickup(PickupType type, Vector3 position, Model model, int value)`
- `public static Blip CreateBlip(Vector3 position, float radius)`
- `public static Blip CreateBlip(Vector3 position)`
- `public static Camera CreateCamera(Vector3 position, Vector3 rotation, float fov)`
- `public static Ped CreatePed(Model model, Vector3 position, float heading)`
- `public static Ped CreatePed(Model model, Vector3 position)`
- `public static Pickup CreatePickup(PickupType type, Vector3 position, Vector3 rotation, Model model, int value)`
- `public static Pickup CreatePickup(PickupType type, Vector3 position, Model model, int value)`
- `public static Prop CreateProp(Model model, Vector3 position, Vector3 rotation, bool dynamic, bool placeOnGround)`
- `public static Prop CreateProp(Model model, Vector3 position, bool dynamic, bool placeOnGround)`
- `public static Ped CreateRandomPed(Vector3 position)`
- `public static Vehicle CreateVehicle(Model model, Vector3 position, float heading)`
- `public static Vehicle CreateVehicle(Model model, Vector3 position)`
- `public static void DestroyAllCameras()`
- `public static void DrawLightWithRange(Vector3 position, Color color, float range, float intensity)`
- `public static void DrawMarker(MarkerType type, Vector3 pos, Vector3 dir, Vector3 rot, Vector3 scale, Color color, bool bobUpAndDown, bool faceCamY, int unk2, bool rotateY, string textueDict, string textureName, bool drawOnEnt)`
- `public static void DrawMarker(MarkerType type, Vector3 pos, Vector3 dir, Vector3 rot, Vector3 scale, Color color)`
- `public static void DrawSpotLight(Vector3 pos, Vector3 dir, Color color, float distance, float brightness, float roundness, float radius, float fadeout)`
- `public static void DrawSpotLightWithShadow(Vector3 pos, Vector3 dir, Color color, float distance, float brightness, float roundness, float radius, float fadeout)`
- `public static Blip[] GetActiveBlips()`
- `public static Entity[] GetAllEntities()`
- `public static Ped[] GetAllPeds()`
- `public static Ped[] GetAllPeds(Model model)`
- `public static Prop[] GetAllProps()`
- `public static Prop[] GetAllProps(Model model)`
- `public static Vehicle[] GetAllVehicles()`
- `public static Vehicle[] GetAllVehicles(Model model)`
- `public static T GetClosest<T>(Vector3 position, params T[] spatials)`
- `public static Ped GetClosestPed(Vector3 position, float radius)`
- `public static Vehicle GetClosestVehicle(Vector3 position, float radius)`
- `public static RaycastResult GetCrosshairCoordinates()`
- `public static float GetDistance(Vector3 origin, Vector3 destination)`
- `public static float GetGroundHeight(Vector2 position)`
- `public static float GetGroundHeight(Vector3 position)`
- `public static Entity[] GetNearbyEntities(Vector3 position, float radius)`
- `public static Ped[] GetNearbyPeds(Vector3 position, float radius, Model model)`
- `public static Ped[] GetNearbyPeds(Vector3 position, float radius)`
- `public static Ped[] GetNearbyPeds(Ped ped, float radius)`
- `public static Prop[] GetNearbyProps(Vector3 position, float radius, Model model)`
- `public static Prop[] GetNearbyProps(Vector3 position, float radius)`
- `public static Vehicle[] GetNearbyVehicles(Vector3 position, float radius, Model model)`
- `public static Vehicle[] GetNearbyVehicles(Vector3 position, float radius)`
- `public static Vehicle[] GetNearbyVehicles(Ped ped, float radius)`
- `public static Vector3 GetNextPositionOnSidewalk(Vector2 position)`
- `public static Vector3 GetNextPositionOnSidewalk(Vector3 position)`
- `public static Vector3 GetNextPositionOnStreet(Vector2 position, bool unoccupied)`
- `public static Vector3 GetNextPositionOnStreet(Vector3 position, bool unoccupied)`
- `public static Vector3 GetNextPositionOnStreet(Vector3 position)`
- `public static Relationship GetRelationshipBetweenGroups(int group1, int group2)`
- `public static Vector3 GetSafeCoordForPed(Vector3 position, bool sidewalk, int flags)`
- `public static Vector3 GetSafeCoordForPed(Vector3 position, bool sidewalk)`
- `public static Vector3 GetSafeCoordForPed(Vector3 position)`
- `public static string GetStreetName(Vector2 position)`
- `public static string GetStreetName(Vector3 position)`
- `public static Vector3 GetWaypointPosition()`
- `public static string GetZoneName(Vector2 position)`
- `public static string GetZoneName(Vector3 position)`
- `public static string GetZoneNameLabel(Vector2 position)`
- `public static string GetZoneNameLabel(Vector3 position)`
- `public static RaycastResult Raycast(Vector3 source, Vector3 target, IntersectOptions options, Entity ignoreEntity)`
- `public static RaycastResult Raycast(Vector3 source, Vector3 target, IntersectOptions options)`
- `public static RaycastResult Raycast(Vector3 source, Vector3 direction, float maxDistance, IntersectOptions options, Entity ignoreEntity)`
- `public static RaycastResult Raycast(Vector3 source, Vector3 direction, float maxDistance, IntersectOptions options)`
- `public static RaycastResult RaycastCapsule(Vector3 source, Vector3 target, float radius, IntersectOptions options, Entity ignoreEntity)`
- `public static RaycastResult RaycastCapsule(Vector3 source, Vector3 target, float radius, IntersectOptions options)`
- `public static RaycastResult RaycastCapsule(Vector3 source, Vector3 direction, float maxDistance, float radius, IntersectOptions options, Entity ignoreEntity)`
- `public static RaycastResult RaycastCapsule(Vector3 source, Vector3 direction, float maxDistance, float radius, IntersectOptions options)`
- `public static void RemoveRelationshipGroup(int group)`
- `public static void SetBlackout(bool enable)`
- `public static void SetRelationshipBetweenGroups(Relationship relationship, int group1, int group2)`
- `public static void ShootBullet(Vector3 sourcePosition, Vector3 targetPosition, Ped owner, Model model, int damage, float speed)`
- `public static void ShootBullet(Vector3 sourcePosition, Vector3 targetPosition, Ped owner, Model model, int damage)`
- `public static void TransitionToWeather(Weather value, float duration)`

