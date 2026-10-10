using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class EnemyHandler : Script
{
	public static List<Vector3> CayoPericoCompound = new List<Vector3>
	{
		new Vector3(4962.263f, -5787.381f, 20.03307f),
		new Vector3(5083.578f, -5733.974f, 14.80494f)
	};

	public static Vector3 ClosePos;

	public static List<Ped> Enemies = new List<Ped>();

	public static int MaxPeds = 5;

	public static int TimeBetweenSpawns = 4000;

	public static int Time;

	public static int Area = -1;

	public static List<PedHash> CayoPericoPeds = new List<PedHash>
	{
		PedHash.CartelGuards01GMM,
		PedHash.CartelGuards02GMM
	};

	public static Random Rand = new Random();

	public static bool Started { get; private set; } = false;

	public EnemyHandler()
	{
		Tick += onTick;
		Aborted += onShutdown;
		CruelMastersOnlineOffline.SetRelationshipBetweenGroups(Relationship.Hate, Groups.playersTeam, Groups.AiTeam);
		CruelMastersOnlineOffline.SetRelationshipBetweenGroups(Relationship.Hate, Groups.AiTeam, Groups.playersTeam);
	}

	public void onTick(object sender, EventArgs e)
	{
		Spawn_Ai(Area);
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			RemoveEnemies();
		}
	}

	public static void Spawn_Ai(int Areas)
	{
		if (Areas == 0 && Game.GameTime > Time + TimeBetweenSpawns && Enemies.Count < MaxPeds)
		{
			int index = -1;
			bool flag = false;
			ClosePos = CayoPericoCompound[0];
			foreach (Vector3 item in CayoPericoCompound)
			{
				if (item.DistanceTo(Game.Player.Character.Position) < ClosePos.DistanceTo(Game.Player.Character.Position))
				{
					ClosePos = item;
				}
			}
			while (!flag)
			{
				index = Rand.Next(0, CayoPericoCompound.Count);
				if (CayoPericoCompound[index] != ClosePos)
				{
					flag = true;
				}
			}
			int num = Rand.Next(0, CayoPericoPeds.Count);
			Ped ped = World.CreatePed(CayoPericoPeds[num], CayoPericoCompound[index]);
			while (ped == null)
			{
				Script.Wait(0);
			}
			switch (num)
			{
			case 0:
				ped.Weapons.Give(WeaponHash.AssaultRifle, 1000, equipNow: true, isAmmoLoaded: true);
				Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, 2);
				break;
			case 1:
				ped.Weapons.Give(WeaponHash.MilitaryRifle, 1000, equipNow: true, isAmmoLoaded: true);
				Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, 2);
				break;
			}
			Function.Call(Hash.SET_PED_COMBAT_ABILITY, ped, 2);
			Function.Call(Hash.SET_PED_COMBAT_RANGE, ped, 2);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, ped, 132, true);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, ped, 32, false);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, ped, 118, false);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, ped, 208, true);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, ped, 188, true);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, ped, 281, true);
			ped.FiringPattern = FiringPattern.BurstFire;
			ped.ShootRate = 60;
			Function.Call(Hash.SET_PED_SPHERE_DEFENSIVE_AREA, 5018.392f, -5753.753f, 19.85898f, 200f, 1, 0);
			ped.FiringPattern = FiringPattern.BurstFire;
			ped.Armor = 200;
			ped.Accuracy = 15;
			ped.RelationshipGroup = Groups.AiTeam;
			ped.BlockPermanentEvents = true;
			ped.AlwaysKeepTask = true;
			ped.Task.FightAgainstHatedTargets(Groups.playersTeam);
			ped.AddBlip();
			ped.AttachedBlip.Sprite = BlipSprite.Enemy;
			ped.AttachedBlip.Color = BlipColor.Red;
			ped.AttachedBlip.Name = "Enemy";
			ped.AttachedBlip.Scale = 1f;
			Function.Call(Hash.SET_PED_DROPS_WEAPONS_WHEN_DEAD, ped, false);
			Enemies.Add(ped);
			Time = Game.GameTime;
		}
		CheckPeds();
	}

	public static void Start()
	{
		Started = true;
	}

	public static void Stop()
	{
		Started = false;
	}

	public static void CheckPeds()
	{
		if (Enemies.Count <= 0)
		{
			return;
		}
		foreach (Ped item in Enemies.ToList())
		{
			if (item == null || !item.Exists())
			{
				Enemies.Remove(item);
			}
			else if (item.IsDead)
			{
				item.AttachedBlip.Delete();
				item.MarkAsNoLongerNeeded();
				Enemies.Remove(item);
			}
		}
	}

	public static void RemoveEnemies()
	{
		foreach (Ped item in Enemies.ToList())
		{
			item.AttachedBlip.Delete();
			item.Delete();
			Enemies.Remove(item);
		}
	}
}
