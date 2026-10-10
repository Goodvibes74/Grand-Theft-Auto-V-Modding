using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Vehicles : Script
{
	public static List<Vehicle> vehList = new List<Vehicle>();

	public Vehicles()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		CheckVehicles();
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			RemoveVehicles();
		}
	}

	public static void CheckVehicles()
	{
		if (vehList.Count <= 0)
		{
			return;
		}
		foreach (Vehicle item in vehList.ToList())
		{
			if (item != null && item.IsDead)
			{
				if (item.AttachedBlip != null)
				{
					item.AttachedBlip.Delete();
				}
				item.MarkAsNoLongerNeeded();
				vehList.Remove(item);
			}
			if (!(item != null))
			{
				continue;
			}
			if (Game.Player.Character.CurrentVehicle == item)
			{
				if (item.AttachedBlip != null)
				{
					item.AttachedBlip.Alpha = 0;
				}
			}
			else if (item.AttachedBlip != null)
			{
				item.AttachedBlip.Alpha = 255;
			}
		}
	}

	public static void RemoveVehicles()
	{
		if (vehList.Count <= 0)
		{
			return;
		}
		foreach (Vehicle item in vehList.ToList())
		{
			if (item != null)
			{
				if (item.AttachedBlip != null)
				{
					item.AttachedBlip.Delete();
				}
				item.Delete();
				vehList.Remove(item);
			}
		}
	}

	public static void SET_VEHICLE_DOORS_LOCKED(Vehicle vehicle, int doorLockStatus)
	{
		Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, vehicle, doorLockStatus);
	}

	public static void REMOVE_AMBIANT_MISSION_VEHICLES(Vector3 position, float radius)
	{
		Vehicle[] nearbyVehicles = World.GetNearbyVehicles(position, radius);
		Vehicle[] array = nearbyVehicles;
		foreach (Vehicle vehicle in array)
		{
			if (vehicle != null)
			{
				vehicle.MarkAsNoLongerNeeded();
			}
		}
	}

	public static void REMOVE_AMBIANT_MISSION_VEHICLES_BESIDES(Vector3 position, float radius, Vehicle dontdelete)
	{
		Vehicle[] nearbyVehicles = World.GetNearbyVehicles(position, radius);
		Vehicle[] array = nearbyVehicles;
		foreach (Vehicle vehicle in array)
		{
			if (vehicle != null && vehicle != dontdelete)
			{
				vehicle.MarkAsNoLongerNeeded();
			}
		}
	}

	public static void SET_VEHICLE_DOOR_BROKEN(Vehicle vehicle, int doorIndex, bool deleteDoor)
	{
		if (vehicle != null)
		{
			Function.Call(Hash.SET_VEHICLE_DOOR_BROKEN, vehicle, doorIndex, deleteDoor);
		}
	}

	public static void SET_VEHICLE_DOOR_OPEN(Vehicle vehicle, int doorIndex, bool loose, bool openInstantly)
	{
		if (vehicle != null)
		{
			Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, vehicle, doorIndex, loose, openInstantly);
		}
	}

	public static void SET_VEHICLE_DOOR_SHUT(Vehicle vehicle, int doorIndex, bool openInstantly)
	{
		if (vehicle != null)
		{
			Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, vehicle, doorIndex, openInstantly);
		}
	}

	public static bool IS_VEHICLE_DOOR_FULLY_OPEN(Vehicle vehicle, int doorid)
	{
		return Function.Call<bool>(Hash.IS_VEHICLE_DOOR_FULLY_OPEN, vehicle, doorid);
	}

	public static void SPAWN_VEHICLE(VehicleHash vehiclehash, Vector3 positiontospawn, float heading, bool sirenactive, bool IsInvincible)
	{
		Vehicle vehicle = World.CreateVehicle(vehiclehash, positiontospawn, heading);
		if (vehicle.HasSiren)
		{
			vehicle.IsSirenActive = sirenactive;
		}
		vehicle.IsInvincible = IsInvincible;
		Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, vehicle, 100f);
		vehList.Add(vehicle);
	}
}
