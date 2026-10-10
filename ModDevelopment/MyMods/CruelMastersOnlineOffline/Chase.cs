using System;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Chase : Script
{
	public enum VehicleNodeFlags
	{
		None = 0,
		IsDisabled = 1,
		UnknownBit2 = 2,
		SlowNormalRoad = 4,
		MinorRoad = 8,
		TunnelOrUndergroundParking = 0x10,
		UnknownBit32 = 0x20,
		Freeway = 0x40,
		Junction = 0x80,
		StopNode = 0x100,
		SpecialStopNode = 0x200
	}

	public static bool ChaseActive = false;

	public static bool[] PedAlive = new bool[5];

	public static Ped[] ChasePeds = new Ped[5];

	public static Blip[] ChaseBlips = new Blip[5];

	public static Vehicle[] ChaseVehicles = new Vehicle[5];

	public static int[] SpawnTimes = new int[3];

	public static VehicleHash vehicleHash = (VehicleHash)0u;

	public static PedHash pedHash = (PedHash)0u;

	public static WeaponHash[] weaponHash = new WeaponHash[3];

	public Chase()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public unsafe void onTick(object sender, EventArgs e)
	{
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsEnabledControlJustPressed(Control.Context))
		{
		}
		if (ChaseActive)
		{
			Vector3 vector = Game.Player.Character.Position;
			int num = 0;
			int num2 = 2;
			if (!PedAlive[0] && !PedAlive[1] && Game.GameTime > SpawnTimes[0])
			{
				if (Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_ACTIVE))
				{
					Function.Call(Hash.SPAWNPOINTS_CANCEL_SEARCH);
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Search Canceled");
					}
				}
				Function.Call(Hash.SPAWNPOINTS_START_SEARCH, vector.X, vector.Y, vector.Z, 130f, 5f, 2, 2f, 20000);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Search Started");
				}
				while (!Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_COMPLETE))
				{
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Searching");
					}
					Script.Wait(0);
				}
				num = Function.Call<int>(Hash.SPAWNPOINTS_GET_NUM_SEARCH_RESULTS);
				int num3 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, num);
				Function.Call(Hash.SPAWNPOINTS_GET_SEARCH_RESULT, num3, &vector.X, &vector.Y, &vector.Z);
				if (vector.DistanceTo(Game.Player.Character.Position) > 130f && vector.DistanceTo(Game.Player.Character.Position) < 70f)
				{
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Search Returned");
					}
					return;
				}
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"Search Complete : Spots:{num} Spot Chosen:{num3}, X{vector.X}, Y{vector.Y}, Z{vector.Z}");
				}
				vector = GetClosestVehNode(vector, 130f);
				if (!Function.Call<bool>(Hash.IS_POINT_ON_ROAD, vector.X, vector.Y, vector.Z))
				{
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Search Returned");
					}
					return;
				}
				ChaseVehicles[0] = World.CreateVehicle(vehicleHash, vector);
				while (ChaseVehicles[0] == null)
				{
					ChaseVehicles[0] = World.CreateVehicle(vehicleHash, World.GetSafeCoordForPed(Game.Player.Character.Position.Around(200f), sidewalk: false, 8), Game.Player.Character.Heading);
					Script.Wait(0);
				}
				if (ChaseVehicles[0].IsOnScreen)
				{
					ChaseVehicles[0].Delete();
					ChaseVehicles[0] = null;
					return;
				}
				Vector3 vector2 = new Vector3(0f, 0f, 0f);
				float heading = 0f;
				if (!Function.Call<bool>(Hash.GET_CLOSEST_VEHICLE_NODE_WITH_HEADING, ChaseVehicles[0].Position.X, ChaseVehicles[0].Position.Y, ChaseVehicles[0].Position.Z, &vector2, &heading, 1, 1077936128, 0))
				{
					return;
				}
				ChaseVehicles[0].Heading = heading;
				ChasePeds[0] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
				while (ChasePeds[0] == null)
				{
					ChasePeds[0] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
					Script.Wait(0);
				}
				ChasePeds[0].SetIntoVehicle(ChaseVehicles[0], VehicleSeat.Driver);
				ChasePeds[0].Weapons.Give(weaponHash[0], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[0].Weapons.Give(weaponHash[1], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[0].RelationshipGroup = Groups.AiTeam;
				ChasePeds[0].DrivingStyle = DrivingStyle.AvoidTrafficExtremely;
				ChasePeds[0].DrivingSpeed = 160f;
				ChasePeds[0].Accuracy = 25;
				ChasePeds[0].ShootRate = 25;
				Function.Call(Hash.SET_PED_COMBAT_RANGE, ChasePeds[0], 0);
				ChasePeds[0].FiringPattern = FiringPattern.BurstFire;
				ChaseBlips[0] = ChasePeds[0].AddBlip();
				ChaseBlips[0].Sprite = BlipSprite.Enemy;
				ChaseBlips[0].Color = BlipColor.Red;
				ChaseBlips[0].Name = "Enemy";
				ChasePeds[1] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
				while (ChasePeds[1] == null)
				{
					ChasePeds[1] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
					Script.Wait(0);
				}
				ChasePeds[1].SetIntoVehicle(ChaseVehicles[0], VehicleSeat.Passenger);
				ChasePeds[1].Weapons.Give(weaponHash[0], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[1].Weapons.Give(weaponHash[1], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[1].RelationshipGroup = Groups.AiTeam;
				ChaseBlips[1] = ChasePeds[1].AddBlip();
				ChaseBlips[1].Sprite = BlipSprite.Enemy;
				ChaseBlips[1].Color = BlipColor.Red;
				ChaseBlips[1].Name = "Enemy";
				ChasePeds[1].Accuracy = 25;
				ChasePeds[1].ShootRate = 25;
				Function.Call(Hash.SET_PED_COMBAT_RANGE, ChasePeds[1], 0);
				ChasePeds[1].FiringPattern = FiringPattern.BurstFire;
				CruelMastersOnlineOffline.SetRelationshipBetweenGroups(Relationship.Hate, Groups.AiTeam, Groups.playersTeam);
				CruelMastersOnlineOffline.SetRelationshipBetweenGroups(Relationship.Hate, Groups.playersTeam, Groups.AiTeam);
				Function.Call(Hash.TASK_COMBAT_PED, ChasePeds[0], Game.Player.Character, 67108864, 16);
				Function.Call(Hash.TASK_COMBAT_PED, ChasePeds[1], Game.Player.Character, 67108864, 16);
				ChasePeds[0].BlockPermanentEvents = true;
				ChasePeds[0].AlwaysKeepTask = true;
				ChasePeds[1].BlockPermanentEvents = true;
				ChasePeds[1].AlwaysKeepTask = true;
				PedAlive[0] = true;
				PedAlive[1] = true;
			}
			if (ChasePeds[0] != null && PedAlive[0] && ChasePeds[0].IsDead)
			{
				SpawnTimes[0] = Game.GameTime + 10000;
				ChaseBlips[0].Delete();
				ChaseBlips[0] = null;
				ChasePeds[0].MarkAsNoLongerNeeded();
				ChasePeds[0] = null;
				PedAlive[0] = false;
			}
			if (ChasePeds[0] != null && PedAlive[0] && ChasePeds[0].Position.DistanceTo(Game.Player.Character.Position) > 400f)
			{
				SpawnTimes[0] = Game.GameTime + 10000;
				ChaseBlips[0].Delete();
				ChaseBlips[0] = null;
				ChasePeds[0].MarkAsNoLongerNeeded();
				ChasePeds[0] = null;
				PedAlive[0] = false;
			}
			if (ChasePeds[1] != null && PedAlive[1] && ChasePeds[1].IsDead)
			{
				SpawnTimes[0] = Game.GameTime + 10000;
				ChaseBlips[1].Delete();
				ChaseBlips[1] = null;
				ChasePeds[1].MarkAsNoLongerNeeded();
				ChasePeds[1] = null;
				PedAlive[1] = false;
			}
			if (ChasePeds[1] != null && PedAlive[1] && ChasePeds[1].Position.DistanceTo(Game.Player.Character.Position) > 400f)
			{
				SpawnTimes[0] = Game.GameTime + 10000;
				ChaseBlips[1].Delete();
				ChaseBlips[1] = null;
				ChasePeds[1].MarkAsNoLongerNeeded();
				ChasePeds[1] = null;
				PedAlive[1] = false;
			}
			if (ChaseVehicles[0] != null && ChaseVehicles[0].IsDead)
			{
				SpawnTimes[0] = Game.GameTime + 10000;
				ChaseVehicles[0].MarkAsNoLongerNeeded();
				ChaseVehicles[0] = null;
			}
			if (ChaseVehicles[0] != null && !PedAlive[0] && !PedAlive[1])
			{
				SpawnTimes[0] = Game.GameTime + 10000;
				ChaseVehicles[0].MarkAsNoLongerNeeded();
				ChaseVehicles[0] = null;
			}
			if (ChaseVehicles[0] != null && ChaseVehicles[0].Position.DistanceTo(Game.Player.Character.Position) > 400f)
			{
				SpawnTimes[0] = Game.GameTime + 10000;
				if (ChaseBlips[0] != null)
				{
					ChaseBlips[0].Delete();
					ChaseBlips[0] = null;
				}
				if (ChasePeds[0] != null)
				{
					ChasePeds[0].MarkAsNoLongerNeeded();
					ChasePeds[0] = null;
				}
				PedAlive[0] = false;
				if (ChaseBlips[1] != null)
				{
					ChaseBlips[1].Delete();
					ChaseBlips[1] = null;
				}
				if (ChasePeds[1] != null)
				{
					ChasePeds[1].MarkAsNoLongerNeeded();
					ChasePeds[1] = null;
				}
				PedAlive[1] = false;
				ChaseVehicles[0].MarkAsNoLongerNeeded();
				ChaseVehicles[0] = null;
			}
			if (!PedAlive[2] && !PedAlive[3] && Game.GameTime > SpawnTimes[1])
			{
				if (Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_ACTIVE))
				{
					Function.Call(Hash.SPAWNPOINTS_CANCEL_SEARCH);
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Search Canceled");
					}
				}
				Function.Call(Hash.SPAWNPOINTS_START_SEARCH, vector.X, vector.Y, vector.Z, 130f, 5f, 2, 2f, 20000);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Search Started");
				}
				while (!Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_COMPLETE))
				{
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Searching");
					}
					Script.Wait(0);
				}
				num = Function.Call<int>(Hash.SPAWNPOINTS_GET_NUM_SEARCH_RESULTS);
				int num4 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, num);
				Function.Call(Hash.SPAWNPOINTS_GET_SEARCH_RESULT, num4, &vector.X, &vector.Y, &vector.Z);
				if (vector.DistanceTo(Game.Player.Character.Position) > 130f && vector.DistanceTo(Game.Player.Character.Position) < 70f)
				{
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Search Returned");
					}
					return;
				}
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"Search Complete : Spots:{num} Spot Chosen:{num4}, X{vector.X}, Y{vector.Y}, Z{vector.Z}");
				}
				vector = GetClosestVehNode(vector, 130f);
				if (!Function.Call<bool>(Hash.IS_POINT_ON_ROAD, vector.X, vector.Y, vector.Z))
				{
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Search Returned");
					}
					return;
				}
				ChaseVehicles[1] = World.CreateVehicle(vehicleHash, vector);
				while (ChaseVehicles[1] == null)
				{
					ChaseVehicles[1] = World.CreateVehicle(vehicleHash, World.GetNextPositionOnStreet(Game.Player.Character.Position.Around(200f), unoccupied: true), Game.Player.Character.Heading);
					Script.Wait(0);
				}
				if (ChaseVehicles[1].IsOnScreen)
				{
					ChaseVehicles[1].Delete();
					ChaseVehicles[1] = null;
					return;
				}
				Vector3 vector3 = new Vector3(0f, 0f, 0f);
				float heading2 = 0f;
				if (!Function.Call<bool>(Hash.GET_CLOSEST_VEHICLE_NODE_WITH_HEADING, ChaseVehicles[1].Position.X, ChaseVehicles[1].Position.Y, ChaseVehicles[1].Position.Z, &vector3, &heading2, 1, 1077936128, 0))
				{
					return;
				}
				ChaseVehicles[1].Heading = heading2;
				ChasePeds[2] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
				while (ChasePeds[2] == null)
				{
					ChasePeds[2] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
					Script.Wait(0);
				}
				ChasePeds[2].SetIntoVehicle(ChaseVehicles[1], VehicleSeat.Driver);
				ChasePeds[2].Weapons.Give(weaponHash[0], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[2].Weapons.Give(weaponHash[1], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[2].RelationshipGroup = Groups.AiTeam;
				ChasePeds[2].DrivingStyle = DrivingStyle.AvoidTrafficExtremely;
				ChasePeds[2].DrivingSpeed = 160f;
				ChaseBlips[2] = ChasePeds[2].AddBlip();
				ChaseBlips[2].Sprite = BlipSprite.Enemy;
				ChaseBlips[2].Color = BlipColor.Red;
				ChaseBlips[2].Name = "Enemy";
				ChasePeds[2].Accuracy = 25;
				ChasePeds[2].ShootRate = 25;
				Function.Call(Hash.SET_PED_COMBAT_RANGE, ChasePeds[2], 0);
				ChasePeds[2].FiringPattern = FiringPattern.BurstFire;
				ChasePeds[3] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
				while (ChasePeds[3] == null)
				{
					ChasePeds[3] = World.CreatePed(pedHash, GetClosestVehNode(Game.Player.Character.Position, 100f), Game.Player.Character.Heading);
					Script.Wait(0);
				}
				ChasePeds[3].SetIntoVehicle(ChaseVehicles[1], VehicleSeat.Passenger);
				ChasePeds[3].Weapons.Give(weaponHash[0], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[3].Weapons.Give(weaponHash[1], 10000, equipNow: true, isAmmoLoaded: true);
				ChasePeds[3].RelationshipGroup = Groups.AiTeam;
				ChaseBlips[3] = ChasePeds[3].AddBlip();
				ChaseBlips[3].Sprite = BlipSprite.Enemy;
				ChaseBlips[3].Color = BlipColor.Red;
				ChaseBlips[3].Name = "Enemy";
				ChasePeds[3].Accuracy = 25;
				ChasePeds[3].ShootRate = 25;
				Function.Call(Hash.SET_PED_COMBAT_RANGE, ChasePeds[3], 0);
				ChasePeds[3].FiringPattern = FiringPattern.BurstFire;
				CruelMastersOnlineOffline.SetRelationshipBetweenGroups(Relationship.Hate, Groups.AiTeam, Groups.playersTeam);
				CruelMastersOnlineOffline.SetRelationshipBetweenGroups(Relationship.Hate, Groups.playersTeam, Groups.AiTeam);
				Function.Call(Hash.TASK_COMBAT_PED, ChasePeds[2], Game.Player.Character, 67108864, 16);
				Function.Call(Hash.TASK_COMBAT_PED, ChasePeds[3], Game.Player.Character, 67108864, 16);
				ChasePeds[2].BlockPermanentEvents = true;
				ChasePeds[2].AlwaysKeepTask = true;
				ChasePeds[3].BlockPermanentEvents = true;
				ChasePeds[3].AlwaysKeepTask = true;
				PedAlive[2] = true;
				PedAlive[3] = true;
			}
			if (ChasePeds[2] != null && PedAlive[2] && ChasePeds[2].IsDead)
			{
				SpawnTimes[1] = Game.GameTime + 10000;
				ChaseBlips[2].Delete();
				ChaseBlips[2] = null;
				ChasePeds[2].MarkAsNoLongerNeeded();
				ChasePeds[2] = null;
				PedAlive[2] = false;
			}
			if (ChasePeds[2] != null && PedAlive[2] && ChasePeds[2].Position.DistanceTo(Game.Player.Character.Position) > 400f)
			{
				SpawnTimes[1] = Game.GameTime + 10000;
				ChaseBlips[2].Delete();
				ChaseBlips[2] = null;
				ChasePeds[2].MarkAsNoLongerNeeded();
				ChasePeds[2] = null;
				PedAlive[2] = false;
			}
			if (ChasePeds[3] != null && PedAlive[3] && ChasePeds[3].IsDead)
			{
				SpawnTimes[1] = Game.GameTime + 10000;
				ChaseBlips[3].Delete();
				ChaseBlips[3] = null;
				ChasePeds[3].MarkAsNoLongerNeeded();
				ChasePeds[3] = null;
				PedAlive[3] = false;
			}
			if (ChasePeds[3] != null && PedAlive[3] && ChasePeds[3].Position.DistanceTo(Game.Player.Character.Position) > 400f)
			{
				SpawnTimes[1] = Game.GameTime + 10000;
				ChaseBlips[3].Delete();
				ChaseBlips[3] = null;
				ChasePeds[3].MarkAsNoLongerNeeded();
				ChasePeds[3] = null;
				PedAlive[3] = false;
			}
			if (ChaseVehicles[1] != null && ChaseVehicles[1].IsDead)
			{
				SpawnTimes[1] = Game.GameTime + 10000;
				ChaseVehicles[1].MarkAsNoLongerNeeded();
				ChaseVehicles[1] = null;
			}
			if (ChaseVehicles[1] != null && !PedAlive[2] && !PedAlive[3])
			{
				SpawnTimes[1] = Game.GameTime + 10000;
				ChaseVehicles[1].MarkAsNoLongerNeeded();
				ChaseVehicles[1] = null;
			}
			if (ChaseVehicles[1] != null && ChaseVehicles[1].Position.DistanceTo(Game.Player.Character.Position) > 400f)
			{
				SpawnTimes[1] = Game.GameTime + 10000;
				if (ChaseBlips[2] != null)
				{
					ChaseBlips[2].Delete();
					ChaseBlips[2] = null;
				}
				if (ChasePeds[2] != null)
				{
					ChasePeds[2].MarkAsNoLongerNeeded();
					ChasePeds[2] = null;
				}
				PedAlive[2] = false;
				if (ChaseBlips[3] != null)
				{
					ChaseBlips[3].Delete();
					ChaseBlips[3] = null;
				}
				if (ChasePeds[3] != null)
				{
					ChasePeds[3].MarkAsNoLongerNeeded();
					ChasePeds[3] = null;
				}
				PedAlive[3] = false;
				ChaseVehicles[1].MarkAsNoLongerNeeded();
				ChaseVehicles[1] = null;
			}
		}
		if (!ChaseActive)
		{
			if (ChaseBlips[0] != null)
			{
				ChaseBlips[0].Delete();
				ChaseBlips[0] = null;
			}
			if (ChasePeds[0] != null)
			{
				ChasePeds[0].MarkAsNoLongerNeeded();
				ChasePeds[0] = null;
			}
			if (ChaseBlips[1] != null)
			{
				ChaseBlips[1].Delete();
				ChaseBlips[1] = null;
			}
			if (ChasePeds[1] != null)
			{
				ChasePeds[1].MarkAsNoLongerNeeded();
				ChasePeds[1] = null;
			}
			if (ChaseVehicles[0] != null)
			{
				ChaseVehicles[0].MarkAsNoLongerNeeded();
				ChaseVehicles[0] = null;
			}
			SpawnTimes[0] = 0;
			PedAlive[0] = false;
			PedAlive[1] = false;
			if (ChaseBlips[2] != null)
			{
				ChaseBlips[2].Delete();
				ChaseBlips[2] = null;
			}
			if (ChasePeds[2] != null)
			{
				ChasePeds[2].MarkAsNoLongerNeeded();
				ChasePeds[2] = null;
			}
			if (ChaseBlips[3] != null)
			{
				ChaseBlips[3].Delete();
				ChaseBlips[3] = null;
			}
			if (ChasePeds[3] != null)
			{
				ChasePeds[3].MarkAsNoLongerNeeded();
				ChasePeds[3] = null;
			}
			if (ChaseVehicles[1] != null)
			{
				ChaseVehicles[1].MarkAsNoLongerNeeded();
				ChaseVehicles[1] = null;
			}
			SpawnTimes[1] = 0;
			PedAlive[2] = false;
			PedAlive[3] = false;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (1 == 0)
		{
			return;
		}
		Ped[] chasePeds = ChasePeds;
		foreach (Ped ped in chasePeds)
		{
			if (ped != null)
			{
				ped.Delete();
			}
		}
		Blip[] chaseBlips = ChaseBlips;
		foreach (Blip blip in chaseBlips)
		{
			if (blip != null)
			{
				blip.Delete();
			}
		}
		Vehicle[] chaseVehicles = ChaseVehicles;
		foreach (Vehicle vehicle in chaseVehicles)
		{
			if (vehicle != null)
			{
				vehicle.Delete();
			}
		}
	}

	public static Vector3 GetClosestVehNode(Vector3 posfrom, float distance)
	{
		Vector3 vector = posfrom.Around(distance);
		OutputArgument outputArgument = new OutputArgument();
		Function.Call(Hash.GET_NTH_CLOSEST_VEHICLE_NODE, vector.X, vector.Y, vector.Z, 0, outputArgument, 1, 1077936128, 0);
		return outputArgument.GetResult<Vector3>();
	}

	public static void SET_CHASE_ACTIVATE(VehicleHash vehhash, PedHash pedhash, params WeaponHash[] weapons)
	{
		vehicleHash = vehhash;
		pedHash = pedhash;
		weaponHash[0] = weapons[0];
		weaponHash[1] = weapons[1];
		ChaseActive = true;
	}

	public static void SET_CHASE_DEACTIVATE()
	{
		vehicleHash = (VehicleHash)0u;
		pedHash = (PedHash)0u;
		weaponHash[0] = (WeaponHash)0u;
		weaponHash[1] = (WeaponHash)0u;
		ChaseActive = false;
	}
}
