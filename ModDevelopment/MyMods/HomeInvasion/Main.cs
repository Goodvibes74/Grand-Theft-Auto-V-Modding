using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;

namespace HomeInvasion;

public class Main : Script
{
	private class Marker
	{
		public Vector3 pos;

		public MarkerType markerType;

		public Color color;

		public int homeIndex;
	}

	private List<Vector3> entryPoints = new List<Vector3>();

	private List<Vector3> exitPoints = new List<Vector3>
	{
		new Vector3(-110.3269f, -14.06401f, 70.51962f),
		new Vector3(266.2035f, -1007.058f, -100.9378f),
		new Vector3(-3095.75f, 350.9808f, 14.4436f),
		new Vector3(346.3665f, -1012.362f, -99.1962f),
		new Vector3(151.7148f, -1007.599f, -99f),
		new Vector3(1397.9995f, 1164.1033f, 114.3336f),
		new Vector3(-273.7722f, -967.0415f, 77.2314f)
	};

	private Vector3 currentExitPoint;

	private Vector3 lastEntryPoint;

	private List<int> homeTypes = new List<int>();

	private int currentHomeType;

	private List<Blip> houseBlips = new List<Blip>();

	private List<Ped> homePeds = new List<Ped>();

	private List<Ped> homePedsAlerted = new List<Ped>();

	private List<Prop> homePickups = new List<Prop>();

	private bool copsCalled;

	private Ped homePedCallingPolice;

	private int homePedCallingPoliceStatus = -1;

	private int homePedCallingPoliceGameTimer;

	private int homeRelationship = World.AddRelationshipGroup("murica_nigga");

	private int dispatchTimer;

	private Random rand = new Random();

	private int oldComponentIndex;

	private int oldDrawableIndex;

	private int oldTextureIndex;

	public static bool drawMarkers = true;

	public static bool alertMessage = true;

	public static bool playerMasks = true;

	private bool invokeNewMarker;

	private CultureInfo invC = CultureInfo.InvariantCulture;

	private bool homeInvasion;

	private Marker currentMarker;

	public Main()
	{
		Function.Call(Hash._0x0888C3502DBBEEF5, new InputArgument[0]);
		World.SetRelationshipBetweenGroups(Relationship.Hate, homeRelationship, Game.Player.Character.RelationshipGroup);
		LoadData();
		Utils.SetInteriorActive(234497);
		Utils.SetInteriorActive(149761);
		Utils.SetInteriorActive(148225);
		Utils.SetInteriorActive(149505);
		Utils.SetInteriorActive(205825);
		Utils.SetInteriorActive(141825);
		Function.Call(Hash._0x41B4893843BBDB74, new InputArgument[1] { "ch1_02_open" });
		Tick += OnTick;
		Aborted += OnAborted;
	}

	private void OnAborted(object sender, EventArgs e)
	{
		foreach (Blip houseBlip in houseBlips)
		{
			houseBlip.Remove();
		}
		foreach (Ped homePed in homePeds)
		{
			homePed.Delete();
		}
		foreach (Ped item in homePedsAlerted)
		{
			item.Delete();
		}
		foreach (Prop homePickup in homePickups)
		{
			homePickup.Delete();
		}
	}

	private void OnTick(object sender, EventArgs e)
	{
		if (currentMarker != null)
		{
			if (drawMarkers)
			{
				World.DrawMarker(currentMarker.markerType, new Vector3(currentMarker.pos.X, currentMarker.pos.Y, currentMarker.pos.Z), Vector3.Zero, Vector3.Zero, new Vector3(0.75f, 0.75f, 0.75f), currentMarker.color, bobUpAndDown: false, faceCamY: false, 0, rotateY: false, "", "", drawOnEnt: false);
			}
			if ((Game.Player.Character.Position.DistanceTo(currentMarker.pos) >= 25f || invokeNewMarker) && !homeInvasion)
			{
				currentMarker = null;
				invokeNewMarker = false;
			}
		}
		if (!homeInvasion)
		{
			if (currentMarker == null)
			{
				for (int i = 0; i < entryPoints.Count; i++)
				{
					if (Game.Player.Character.Position.DistanceTo(entryPoints[i]) <= 25f)
					{
						currentMarker = new Marker
						{
							pos = new Vector3(entryPoints[i].X, entryPoints[i].Y, entryPoints[i].Z - 1f),
							color = Color.Red,
							markerType = MarkerType.VerticalCylinder,
							homeIndex = homeTypes[i]
						};
						break;
					}
				}
				Script.Wait(1000);
			}
			else
			{
				if (!(Game.Player.Character.Position.DistanceTo(currentMarker.pos) <= 2f))
				{
					return;
				}
				if (Game.Player.WantedLevel > 0)
				{
					Utils.DisplayHelpTextThisFrame("You cannot rob this home at the moment.");
					return;
				}
				Utils.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter home.");
				if (!Game.IsControlJustPressed(0, GTA.Control.Context))
				{
					return;
				}
				if (playerMasks && (Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Trevor))
				{
					Game.Player.Character.TaskPlayAnim("misscommon@van_put_on_masks", "put_on_mask_ps", 48, 2000);
					Script.Wait(0);
					Function.Call(Hash._0x4487C259F0F70977, new InputArgument[4]
					{
						Game.Player.Character,
						"misscommon@van_put_on_masks",
						"put_on_mask_ps",
						0.1f
					});
					Script.Wait(750);
					if (Game.Player.Character.Model == PedHash.Michael)
					{
						oldComponentIndex = 8;
						oldDrawableIndex = Function.Call<int>(Hash._0x67F3780DD425D4FC, new InputArgument[2]
						{
							Game.Player.Character,
							oldComponentIndex
						});
						oldTextureIndex = Function.Call<int>(Hash._0x04A355E041E004E6, new InputArgument[2]
						{
							Game.Player.Character,
							oldComponentIndex
						});
						Function.Call(Hash._0x262B14F48D29DE80, new InputArgument[5]
						{
							Game.Player.Character,
							oldComponentIndex,
							23,
							0,
							0
						});
					}
					else if (Game.Player.Character.Model == PedHash.Franklin)
					{
						oldComponentIndex = 2;
						oldDrawableIndex = Function.Call<int>(Hash._0x67F3780DD425D4FC, new InputArgument[2]
						{
							Game.Player.Character,
							oldComponentIndex
						});
						oldTextureIndex = Function.Call<int>(Hash._0x04A355E041E004E6, new InputArgument[2]
						{
							Game.Player.Character,
							oldComponentIndex
						});
						Function.Call(Hash._0x262B14F48D29DE80, new InputArgument[5]
						{
							Game.Player.Character,
							oldComponentIndex,
							5,
							0,
							0
						});
					}
					else if (Game.Player.Character.Model == PedHash.Trevor)
					{
						oldComponentIndex = 8;
						oldDrawableIndex = Function.Call<int>(Hash._0x67F3780DD425D4FC, new InputArgument[2]
						{
							Game.Player.Character,
							oldComponentIndex
						});
						oldTextureIndex = Function.Call<int>(Hash._0x04A355E041E004E6, new InputArgument[2]
						{
							Game.Player.Character,
							oldComponentIndex
						});
						Function.Call(Hash._0x262B14F48D29DE80, new InputArgument[5]
						{
							Game.Player.Character,
							oldComponentIndex,
							6,
							0,
							0
						});
					}
				}
				Function.Call(Hash._0x67C540AA08E4A6F5, new InputArgument[4] { -1, "WOODEN_DOOR_OPEN_HANDLE_AT", 0, 1 });
				int homeIndex = currentMarker.homeIndex;
				lastEntryPoint = Game.Player.Character.Position;
				currentHomeType = homeIndex;
				currentExitPoint = exitPoints[currentHomeType];
				copsCalled = false;
				Game.FadeScreenOut(500);
				Script.Wait(1000);
				Game.Player.Character.Position = exitPoints[homeIndex];
				Script.Wait(1000);
				Utils.ReloadCurrentInterior();
				switch (currentHomeType)
				{
				case 0:
					homePeds.Add(World.CreateRandomPed(new Vector3(-110.9446f, -7.061514f, 70.51968f)));
					homePeds[homePeds.Count - 1].Heading = 21.87156f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-112.1017f, -11.38829f, 70.51959f)));
					homePeds[homePeds.Count - 1].Heading = 119.7133f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					Utils.ReloadCurrentInterior();
					break;
				case 1:
					homePeds.Add(World.CreateRandomPed(new Vector3(264.8016f, -996.1455f, -99.01591f)));
					homePeds[homePeds.Count - 1].Heading = 0.02730385f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(262.5344f, -1004.347f, -98.26906f)));
					homePeds[homePeds.Count - 1].Heading = -83.86935f;
					Function.Call(Hash._0x142A02425FF02BD9, new InputArgument[4]
					{
						homePeds[homePeds.Count - 1],
						"WORLD_HUMAN_SUNBATHE_BACK",
						0,
						false
					});
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(255.4765f, -1000.799f, -99.00992f)));
					homePeds[homePeds.Count - 1].Heading = 5.034902f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(258.7537f, -997.5314f, -99.01644f)));
					homePeds[homePeds.Count - 1].Heading = 27.02235f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					Utils.ReloadCurrentInterior();
					break;
				case 2:
					homePeds.Add(World.CreateRandomPed(new Vector3(-3098.702f, 343.5427f, 14.44128f)));
					homePeds[homePeds.Count - 1].Heading = 140.4014f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					Utils.ReloadCurrentInterior();
					break;
				case 3:
					Utils.SetInteriorActive(148225);
					homePeds.Add(World.CreateRandomPed(new Vector3(349.5251f, -1007.837f, -99.19622f)));
					homePeds[homePeds.Count - 1].Heading = -62.02513f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(338.7294f, -1002.771f, -99.19617f)));
					homePeds[homePeds.Count - 1].Heading = -17.31543f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(339.9942f, -996.8333f, -99.19622f)));
					homePeds[homePeds.Count - 1].Heading = 91.29521f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(342.3742f, -1001.615f, -99.19622f)));
					homePeds[homePeds.Count - 1].Heading = 101.9451f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(347.4945f, -994.1389f, -99.19622f)));
					homePeds[homePeds.Count - 1].Heading = 99.09791f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreatePed(PedHash.Genfat02AMM, new Vector3(349.5222f, -996.4797f, -98.5399f)));
					homePeds[homePeds.Count - 1].Heading = 88.80507f;
					Function.Call(Hash._0x142A02425FF02BD9, new InputArgument[4]
					{
						homePeds[homePeds.Count - 1],
						"WORLD_HUMAN_PUSH_UPS",
						0,
						false
					});
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreatePed(PedHash.Stripper01SFY, new Vector3(349.5222f, -996.4797f, -98.5399f)));
					homePeds[homePeds.Count - 1].Heading = -271.6967f;
					homePeds[homePeds.Count - 2].SetNoCollision(homePeds[homePeds.Count - 1], toggle: true);
					homePeds[homePeds.Count - 1].SetNoCollision(homePeds[homePeds.Count - 2], toggle: true);
					Function.Call(Hash._0x142A02425FF02BD9, new InputArgument[4]
					{
						homePeds[homePeds.Count - 1],
						"WORLD_HUMAN_SUNBATHE_BACK",
						0,
						false
					});
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					Utils.ReloadCurrentInterior();
					break;
				case 4:
					homePeds.Add(World.CreateRandomPed(new Vector3(153.9488f, -1000.922f, -98.99998f)));
					homePeds[homePeds.Count - 1].Heading = 0f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(154.2823f, -1004.537f, -98.41702f)));
					homePeds[homePeds.Count - 1].Heading = 92.99926f;
					Function.Call(Hash._0x142A02425FF02BD9, new InputArgument[4]
					{
						homePeds[homePeds.Count - 1],
						"WORLD_HUMAN_BUM_SLUMPED",
						0,
						false
					});
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					Utils.ReloadCurrentInterior();
					break;
				case 5:
					homePeds.Add(World.CreateRandomPed(new Vector3(1403.854f, 1145.764f, 114.3336f)));
					homePeds[homePeds.Count - 1].Heading = 0f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(1392.431f, 1147.365f, 114.3336f)));
					homePeds[homePeds.Count - 1].Heading = 101.9994f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(1406.982f, 1147.552f, 114.3336f)));
					homePeds[homePeds.Count - 1].Heading = 86.30238f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(1392.823f, 1132.014f, 114.3336f)));
					homePeds[homePeds.Count - 1].Heading = -88.00368f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(1400.88f, 1132.1f, 114.3336f)));
					homePeds[homePeds.Count - 1].Heading = 64.14417f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(1396.742f, 1151.399f, 114.3336f)));
					homePeds[homePeds.Count - 1].Heading = -151.0885f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(1399.634f, 1160.804f, 114.3305f)));
					homePeds[homePeds.Count - 1].Heading = 175.2635f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					Utils.ReloadCurrentInterior();
					break;
				case 6:
					homePeds.Add(World.CreateRandomPed(new Vector3(-262.45215f, -970.74634f, 77.21938f)));
					homePeds[homePeds.Count - 1].Heading = -113.930305f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-273.48544f, -962.24963f, 77.21924f)));
					homePeds[homePeds.Count - 1].Heading = 122.67544f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-257.70718f, -944.21674f, 75.83975f)));
					homePeds[homePeds.Count - 1].Heading = -93.8025f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-270.1221f, -953.3684f, 75.840034f)));
					homePeds[homePeds.Count - 1].Heading = 160.66852f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-262.22186f, -965.7254f, 73.41683f)));
					homePeds[homePeds.Count - 1].Heading = 160.32169f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-259.0751f, -958.2172f, 71.0117f)));
					homePeds[homePeds.Count - 1].Heading = -104.11081f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-266.52542f, -947.1682f, 71.00941f)));
					homePeds[homePeds.Count - 1].Heading = 67.21161f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-266.98865f, -955.9773f, 71.01044f)));
					homePeds[homePeds.Count - 1].Heading = -106.70965f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreateRandomPed(new Vector3(-266.41827f, -938.8149f, 75.84288f)));
					homePeds[homePeds.Count - 1].Heading = -18.212254f;
					homePeds[homePeds.Count - 1].DoRandomScenario();
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					homePeds.Add(World.CreatePed(PedHash.Stripper02SFY, new Vector3(-258.8029f, -949.394f, 71.7547f)));
					homePeds[homePeds.Count - 1].Heading = -105.9329f;
					Function.Call(Hash._0x142A02425FF02BD9, new InputArgument[4]
					{
						homePeds[homePeds.Count - 1],
						"WORLD_HUMAN_SUNBATHE",
						0,
						false
					});
					homePeds[homePeds.Count - 1].RelationshipGroup = homeRelationship;
					homePeds[homePeds.Count - 1].Money = rand.Next(10, 301);
					Utils.ReloadCurrentInterior();
					break;
				}
				foreach (Ped homePed in homePeds)
				{
					homePed.RandomizeOutfit();
					Function.Call(Hash._0xC44AA05345C992C6, new InputArgument[1] { homePed });
				}
				Script.Wait(1000);
				Utils.ReloadCurrentInterior();
				Game.FadeScreenIn(500);
				Function.Call(Hash._0x88CBB5CEB96B7BD2, new InputArgument[3]
				{
					Game.Player.Character,
					1,
					"DEFAULT_ACTION"
				});
				Script.Wait(1000);
				Function.Call(Hash._0x67C540AA08E4A6F5, new InputArgument[4] { -1, "WOODEN_DOOR_CLOSING_AT", 0, 1 });
				switch (currentHomeType)
				{
				case 0:
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(-109.4951f, -6.625166f, 70.51959f), "prop_money_bag_01", rand.Next(100, 5001)));
					break;
				case 1:
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(262.3905f, -1000.743f, -98.61726f), "prop_money_bag_01", rand.Next(100, 5001)));
					break;
				case 2:
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(-3102.759f, 345.6238f, 15.82368f), "prop_money_bag_01", rand.Next(100, 5001)));
					break;
				case 3:
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(349.916f, -1007.145f, -99.19622f), "prop_money_bag_01", rand.Next(100, 5001)));
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(352.4192f, -998.579f, -99.38727f), "prop_money_bag_01", rand.Next(100, 5001)));
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(339.5906f, -1001.053f, -98.86863f), "prop_money_bag_01", rand.Next(100, 5001)));
					break;
				case 4:
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(154.4588f, -1007.276f, -98.82834f), "prop_money_bag_01", rand.Next(100, 5001)));
					break;
				case 5:
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(1397.016f, 1152.986f, 114.6984f), "prop_money_bag_01", rand.Next(100, 5001)));
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(1395.269f, 1132.566f, 114.3336f), "prop_money_bag_01", rand.Next(100, 5001)));
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(1394.793f, 1144.02f, 114.8336f), "prop_money_bag_01", rand.Next(100, 5001)));
					break;
				case 6:
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(-264.247f, -950.6919f, 70.0461f), "prop_money_bag_01", rand.Next(100, 5001)));
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(-272.313f, -956.7936f, 76.9758f), "prop_money_bag_01", rand.Next(100, 5001)));
					homePickups.Add(CreateAmbientPickupInteriorFix(PickupType.MoneyCase, new Vector3(-269.0392f, -939.8447f, 75.8408f), "prop_money_bag_01", rand.Next(100, 5001)));
					break;
				}
				currentMarker = new Marker
				{
					pos = new Vector3(currentExitPoint.X, currentExitPoint.Y, currentExitPoint.Z),
					color = Color.Yellow,
					markerType = MarkerType.UpsideDownCone
				};
				homeInvasion = true;
			}
			return;
		}
		if (Game.Player.Character.Position.DistanceTo(currentMarker.pos) <= 2f)
		{
			Utils.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to exit home.");
			if (Game.IsControlJustPressed(0, GTA.Control.Context))
			{
				Function.Call(Hash._0x67C540AA08E4A6F5, new InputArgument[4] { -1, "WOODEN_DOOR_OPEN_HANDLE_AT", 0, 1 });
				dispatchTimer = 0;
				Game.FadeScreenOut(500);
				Script.Wait(1000);
				Game.Player.Character.Position = lastEntryPoint;
				if (homePedsAlerted.Count > 0 && Game.Player.WantedLevel < CopSettings.WantedLevel)
				{
					Game.Player.WantedLevel = CopSettings.WantedLevel;
				}
				int num;
				for (num = 0; num < homePeds.Count; num++)
				{
					homePeds[num].Delete();
					homePeds.RemoveAt(num);
					num--;
				}
				int num2;
				for (num2 = 0; num2 < homePedsAlerted.Count; num2++)
				{
					homePedsAlerted.RemoveAt(num2);
					num2--;
				}
				int num3;
				for (num3 = 0; num3 < homePickups.Count; num3++)
				{
					homePickups[num3].Delete();
					homePickups.RemoveAt(num3);
					num3--;
				}
				homePedCallingPolice = null;
				homePedCallingPoliceStatus = -1;
				homePedCallingPoliceGameTimer = 0;
				Script.Wait(1000);
				Game.FadeScreenIn(500);
				Script.Wait(1000);
				Function.Call(Hash._0x67C540AA08E4A6F5, new InputArgument[4] { -1, "WOODEN_DOOR_CLOSING_AT", 0, 1 });
				if (Game.Player.WantedLevel > 0)
				{
					Game.Player.Character.PlayAmbientSpeech("GET_WANTED_LEVEL", immediately: true, new string[2] { "SPOT_POLICE", "GENERIC_CURSE_HIGH" });
				}
				if (playerMasks && (Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Trevor))
				{
					Game.Player.Character.TaskPlayAnim("misscommon@std_take_off_masks", "take_off_mask_rps", 48, 1000);
					Script.Wait(0);
					Function.Call(Hash._0x4487C259F0F70977, new InputArgument[4]
					{
						Game.Player.Character,
						"misscommon@std_take_off_masks",
						"take_off_mask_rps",
						0.1f
					});
					Script.Wait(500);
					Function.Call(Hash._0x262B14F48D29DE80, new InputArgument[5]
					{
						Game.Player.Character,
						oldComponentIndex,
						oldDrawableIndex,
						oldTextureIndex,
						0
					});
				}
				invokeNewMarker = true;
				homeInvasion = false;
			}
		}
		for (int j = 0; j < homePeds.Count; j++)
		{
			Ped ped = homePeds[j];
			if (!ped.IsInList(homePedsAlerted) && ped.IsAlive)
			{
				if (!ped.IsFleeing && !ped.IsInCombat && (!Game.Player.Character.IsRunning || !(ped.Position.DistanceTo(Game.Player.Character.Position) <= 10f)) && (!Game.Player.Character.IsWalking || Function.Call<bool>(Hash._0x7C2AC9CA66575FBF, new InputArgument[1] { Game.Player.Character }) || !(ped.Position.DistanceTo(Game.Player.Character.Position) <= 5f)))
				{
					continue;
				}
				Game.Player.Character.PlayAmbientSpeech("GENERIC_CURSE_HIGH");
				ped.Task.ClearAll();
				ped.PlayAmbientSpeech("OVER_THERE", immediately: true, new string[3] { "UP_THERE", "GUN_BEG", "GENERIC_FRIGHTENED_HIGH" });
				int num4 = 0;
				num4 = ((!copsCalled && rand.Next(0, 100) < CopSettings.CallPolicePercent) ? 5 : rand.Next(0, 5));
				if (alertMessage)
				{
					Function.Call(Hash._0x67C540AA08E4A6F5, new InputArgument[4] { -1, "HACKING_FAILURE", 0, true });
					BigMessageThread.MessageInstance.ShowSimpleShard("~r~ALERTED", "You have been detected by ~r~someone.", 2000);
				}
				switch (num4)
				{
				case 0:
					ped.PlayAmbientSpeech("GUN_BEG", immediately: true, new string[3] { "GUN_COOL", "GENERIC_FRIGHTENED_HIGH", "GENERIC_FRIGHTENED_MED" });
					Function.Call(Hash._0xF2EAB31979A7F910, new InputArgument[5]
					{
						ped,
						-1,
						Game.Player.Character,
						-1,
						0
					});
					Function.Call(Hash._0xDF993EE5E90ABA25, new InputArgument[2] { ped, false });
					ped.Health = 1;
					break;
				case 1:
					ped.PlayAmbientSpeech("GUN_BEG", immediately: true, new string[3] { "GUN_COOL", "GENERIC_FRIGHTENED_HIGH", "GENERIC_FRIGHTENED_MED" });
					ped.Task.Cower(-1);
					Function.Call(Hash._0xDF993EE5E90ABA25, new InputArgument[2] { ped, false });
					ped.Health = 1;
					break;
				case 2:
					ped.Task.ReactAndFlee(Game.Player.Character);
					break;
				case 3:
					ped.Task.FleeFrom(Game.Player.Character);
					break;
				case 4:
					Function.Call(Hash._0xD30C50DF888D58B5, new InputArgument[2] { ped.Handle, true });
					Function.Call(Hash._0x9F7794730795E019, new InputArgument[3] { ped, 46, true });
					ped.Armor = 100;
					ped.GiveWeaponIfChance(50);
					ped.Task.FightAgainst(Game.Player.Character);
					break;
				case 5:
					ped.Task.UseMobilePhone();
					ped.AddBlip();
					ped.CurrentBlip.Sprite = BlipSprite.PoliceStation;
					ped.CurrentBlip.Color = BlipColor.Red;
					homePedCallingPolice = ped;
					homePedCallingPoliceGameTimer = Game.GameTime + rand.Next(5000, 7000);
					Function.Call(Hash._0xF9E56683CA8E11A5, new InputArgument[3] { "Dial_and_Remote_Ring", homePedCallingPolice, 1 });
					if (alertMessage)
					{
						UI.ShowSubtitle("~r~Someone~s~ is calling the police.", 5000);
					}
					homePedCallingPoliceStatus = 0;
					copsCalled = true;
					break;
				}
				ped.AlwaysKeepTask = true;
				ped.BlockPermanentEvents = true;
				homePedsAlerted.Add(ped);
				break;
			}
			if (ped.IsInCombat || !ped.IsAlive || !(Game.Player.GetTargetedEntity() == ped) || ped.IsPlayingAnim("mp_bank_heist_1", "prone_l_front_intro"))
			{
				continue;
			}
			Utils.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to intimidate.");
			if (!Game.IsControlJustPressed(0, GTA.Control.Context))
			{
				continue;
			}
			Game.Player.Character.PlayAmbientSpeech("SHOP_HURRY", immediately: false, new string[2] { "DRAW_GUN", "FIGHT" });
			if (Function.Call<int>(Hash._0xD53343AA4FB7DD28, new InputArgument[2] { 0, 4 }) != 0)
			{
				continue;
			}
			if (ped == homePedCallingPolice)
			{
				Function.Call(Hash._0x6C5AE23EFA885092, new InputArgument[1] { homePedCallingPolice });
				homePedCallingPolice.CurrentBlip.Remove();
				homePedCallingPoliceStatus = -1;
				homePedCallingPoliceGameTimer = -1;
				homePedCallingPolice = null;
			}
			if (Function.Call<int>(Hash._0xD53343AA4FB7DD28, new InputArgument[2] { 0, 4 }) == 0)
			{
				ped.Task.ClearAllImmediately();
				Function.Call(Hash._0xD30C50DF888D58B5, new InputArgument[2] { ped.Handle, true });
				Function.Call(Hash._0x9F7794730795E019, new InputArgument[3] { ped, 46, true });
				ped.GiveWeaponIfChance(75);
				ped.Task.FightAgainst(Game.Player.Character);
				continue;
			}
			ped.PlayAmbientSpeech("GUN_BEG", immediately: true, new string[2] { "GUN_COOL", "GENERIC_FRIGHTENED_HIGH" });
			ped.Task.ClearAll();
			ped.TaskPlayAnim("mp_bank_heist_1", "prone_l_front_intro", 2, -1);
			ped.Task.LookAt(Game.Player.Character);
			Function.Call(Hash._0xDF993EE5E90ABA25, new InputArgument[2] { ped, false });
			ped.Health = 1;
			if (ped.Money > 0)
			{
				CreateAmbientPickupInteriorFix(PickupType.MoneyWallet, ped.Position, "prop_money_bag_01", ped.Money);
				ped.Money = 0;
			}
		}
		if (homePedCallingPolice != null && homePedCallingPolice.Exists())
		{
			if (homePedCallingPolice.IsDead || homePedCallingPolice.IsRagdoll)
			{
				Function.Call(Hash._0x6C5AE23EFA885092, new InputArgument[1] { homePedCallingPolice });
				homePedCallingPolice.CurrentBlip.Remove();
				homePedCallingPoliceStatus = -1;
				homePedCallingPoliceGameTimer = -1;
				homePedCallingPolice = null;
				return;
			}
			switch (homePedCallingPoliceStatus)
			{
			case 0:
				if (Game.GameTime >= homePedCallingPoliceGameTimer)
				{
					Function.Call(Hash._0x6C5AE23EFA885092, new InputArgument[1] { homePedCallingPolice });
					homePedCallingPolice.PlayAmbientSpeech("PHONE_CALL_COPS", immediately: true, new string[3] { "GUN_BEG", "GENERIC_FRIGHTENED_HIGH", "GENERIC_FRIGHTENED_MED" });
					homePedCallingPoliceStatus++;
				}
				break;
			case 1:
				if (!Function.Call<bool>(Hash._0x9072C8B49907BFAD, new InputArgument[1] { homePedCallingPolice }))
				{
					if (Game.Player.WantedLevel < CopSettings.WantedLevel)
					{
						Game.Player.WantedLevel = CopSettings.WantedLevel;
					}
					dispatchTimer = Game.GameTime + rand.Next(CopSettings.DispatchDelayMinMs, CopSettings.DispatchDelayMaxMs + 1);
					homePedCallingPolice.Task.ClearAll();
					homePedCallingPolice.Task.Cower(-1);
					Function.Call(Hash._0xDF993EE5E90ABA25, new InputArgument[2] { homePedCallingPolice, false });
					homePedCallingPolice.Health = 1;
					homePedCallingPolice.CurrentBlip.Remove();
					homePedCallingPoliceStatus++;
					if (alertMessage)
					{
						UI.ShowSubtitle("The ~r~police~s~ will arrive at the scene shortly.", 5000);
					}
				}
				break;
			}
		}
		if (Game.Player.Character.IsDead)
		{
			Script.Wait(9500);
			int num5;
			for (num5 = 0; num5 < homePeds.Count; num5++)
			{
				homePeds[num5].Delete();
				homePeds.RemoveAt(num5);
				num5--;
			}
			int num6;
			for (num6 = 0; num6 < homePedsAlerted.Count; num6++)
			{
				homePedsAlerted.RemoveAt(num6);
				num6--;
			}
			int num7;
			for (num7 = 0; num7 < homePickups.Count; num7++)
			{
				homePickups[num7].Delete();
				homePickups.RemoveAt(num7);
				num7--;
			}
		}
		if (dispatchTimer == 0 || Game.GameTime < dispatchTimer)
		{
			return;
		}
		if (!CopSettings.SpawnInteriorUnits)
		{
			dispatchTimer = 0;
			return;
		}
		if (rand.Next(0, 100) < CopSettings.SwatChancePercent)
		{
			if (alertMessage)
			{
				Function.Call(Hash._0x67C540AA08E4A6F5, new InputArgument[4] { -1, "HACKING_FAILURE", 0, true });
				BigMessageThread.MessageInstance.ShowSimpleShard("~r~SWAT TEAM", "The ~r~SWAT team~s~ has arrived!", 2000);
			}
			for (int k = 0; k < CopSettings.SwatCount; k++)
			{
				Ped ped2 = World.CreatePed(PedHash.Swat01SMY, currentExitPoint);
				ped2.Weapons.Give(CopSettings.SwatWeapon, 100, equipNow: true, isAmmoLoaded: true);
				ped2.Armor = CopSettings.SwatArmor;
				Function.Call(Hash._0x93376B65A266EB5F, new InputArgument[5] { ped2, 0, 0, 0, 0 });
				ped2.Task.FightAgainst(Game.Player.Character);
				ped2.RelationshipGroup = homeRelationship;
				ped2.ForceRoomInCurrentInterior();
				ped2.PlayAmbientSpeech("MOVE_IN", immediately: true, new string[2] { "GENERIC_WAR_CRY", "DRAW_GUN" });
				homePedsAlerted.Add(ped2);
				homePeds.Add(ped2);
				if (currentHomeType == 6)
				{
					ped2.Position = new Vector3(-264.025f, -966.7958f, 77.2314f);
				}
			}
		}
		else
		{
			if (alertMessage)
			{
				Function.Call(Hash._0x67C540AA08E4A6F5, new InputArgument[4] { -1, "HACKING_FAILURE", 0, true });
				BigMessageThread.MessageInstance.ShowSimpleShard("~r~POLICE", "The ~r~police~s~ have arrived!", 2000);
			}
			Ped ped3 = World.CreatePed(PedHash.Cop01SMY, currentExitPoint);
			ped3.RandomizeOutfit();
			Function.Call(Hash._0xC44AA05345C992C6, new InputArgument[1] { ped3 });
			ped3.Weapons.Give(CopSettings.CopWeapon, 100, equipNow: true, isAmmoLoaded: true);
			ped3.Task.FightAgainst(Game.Player.Character);
			ped3.RelationshipGroup = homeRelationship;
			ped3.ForceRoomInCurrentInterior();
			ped3.PlayAmbientSpeech("COP_ARRIVAL_ANNOUNCE", immediately: true, new string[3] { "GENERIC_WAR_CRY", "GET_HIM", "OVER_THERE" });
			homePedsAlerted.Add(ped3);
			homePeds.Add(ped3);
			if (currentHomeType == 6)
			{
				ped3.Position = new Vector3(-264.025f, -966.7958f, 77.2314f);
			}
			if (rand.Next(0, 100) < CopSettings.SecondCopChancePercent)
			{
				Ped ped4 = World.CreatePed(PedHash.Cop01SMY, currentExitPoint);
				ped4.RandomizeOutfit();
				Function.Call(Hash._0xC44AA05345C992C6, new InputArgument[1] { ped4 });
				ped4.Weapons.Give(CopSettings.SecondCopWeapon, 100, equipNow: true, isAmmoLoaded: true);
				ped4.Task.FightAgainst(Game.Player.Character);
				ped4.RelationshipGroup = homeRelationship;
				ped4.ForceRoomInCurrentInterior();
				ped4.PlayAmbientSpeech("COP_ARRIVAL_ANNOUNCE", immediately: true, new string[3] { "GENERIC_WAR_CRY", "GET_HIM", "OVER_THERE" });
				homePedsAlerted.Add(ped4);
				homePeds.Add(ped4);
				if (currentHomeType == 6)
				{
					ped4.Position = new Vector3(-264.025f, -966.7958f, 77.2314f);
				}
			}
		}
		dispatchTimer = 0;
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.J)
		{
		}
	}

	private Prop CreateAmbientPickupInteriorFix(PickupType pickupType, Vector3 pos, Model model, int value)
	{
		return World.CreateAmbientPickup(pickupType, pos, model, value);
	}

	private void SaveData()
	{
		if (!File.Exists("scripts\\HomeInvasion.xml"))
		{
			File.WriteAllText("scripts\\HomeInvasion.xml", "<Data></Data>");
		}
		else
		{
			File.Delete("scripts\\HomeInvasion.xml");
			File.WriteAllText("scripts\\HomeInvasion.xml", "<Data></Data>");
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load("scripts\\HomeInvasion.xml");
		XmlNode xmlNode = xmlDocument.SelectSingleNode("//Data");
		for (int i = 0; i < entryPoints.Count; i++)
		{
			XmlNode xmlNode2 = xmlDocument.CreateNode(XmlNodeType.Element, "EntryPoint", null);
			XmlNode xmlNode3 = xmlDocument.CreateNode(XmlNodeType.Element, "X", null);
			XmlNode xmlNode4 = xmlDocument.CreateNode(XmlNodeType.Element, "Y", null);
			XmlNode xmlNode5 = xmlDocument.CreateNode(XmlNodeType.Element, "Z", null);
			XmlNode xmlNode6 = xmlDocument.CreateNode(XmlNodeType.Element, "HomeType", null);
			xmlNode3.InnerText = entryPoints[i].X.ToString();
			xmlNode4.InnerText = entryPoints[i].Y.ToString();
			xmlNode5.InnerText = entryPoints[i].Z.ToString();
			xmlNode6.InnerText = homeTypes[i].ToString();
			xmlNode2.AppendChild(xmlNode3);
			xmlNode2.AppendChild(xmlNode4);
			xmlNode2.AppendChild(xmlNode5);
			xmlNode2.AppendChild(xmlNode6);
			xmlNode.AppendChild(xmlNode2);
		}
		xmlDocument.Save("scripts\\HomeInvasion.xml");
	}

	private void LoadData()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load("scripts\\HomeInvasion.xml");
		XmlElement documentElement = xmlDocument.DocumentElement;
		CopSettings.Load(xmlDocument);
		drawMarkers = bool.Parse(xmlDocument.SelectNodes("//Settings")[0].SelectSingleNode("DrawMarkers").Attributes["value"].InnerText);
		alertMessage = bool.Parse(xmlDocument.SelectNodes("//Settings")[0].SelectSingleNode("AlertMessages").Attributes["value"].InnerText);
		playerMasks = bool.Parse(xmlDocument.SelectNodes("//Settings")[0].SelectSingleNode("PlayerMasks").Attributes["value"].InnerText);
		foreach (XmlElement item in xmlDocument.SelectNodes("//EntryPoint"))
		{
			Vector3 vector = new Vector3(float.Parse(item.SelectSingleNode("X").InnerText, invC), float.Parse(item.SelectSingleNode("Y").InnerText, invC), float.Parse(item.SelectSingleNode("Z").InnerText, invC));
			homeTypes.Add(int.Parse(item.SelectSingleNode("HomeType").InnerText, invC));
			entryPoints.Add(vector);
			Blip blip = World.CreateBlip(vector);
			blip.Sprite = BlipSprite.Safehouse;
			blip.Color = BlipColor.Red;
			blip.IsShortRange = true;
			blip.Name = "Home Invasion";
			houseBlips.Add(blip);
		}
	}

	private void ResetData()
	{
		int num;
		for (num = 0; num < entryPoints.Count; num++)
		{
			entryPoints.RemoveAt(num);
			homeTypes.RemoveAt(num);
			num--;
		}
		File.Delete("scripts\\HomeInvasion.xml");
		File.WriteAllText("scripts\\HomeInvasion.xml", "<Data></Data>");
	}
}
