using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class MPKillReward : Script
{
	public enum ePedType
	{
		PED_TYPE_PLAYER_0,
		PED_TYPE_PLAYER_1,
		PED_TYPE_NETWORK_PLAYER,
		PED_TYPE_PLAYER_2,
		PED_TYPE_CIVMALE,
		PED_TYPE_CIVFEMALE,
		PED_TYPE_COP,
		PED_TYPE_GANG_ALBANIAN,
		PED_TYPE_GANG_BIKER_1,
		PED_TYPE_GANG_BIKER_2,
		PED_TYPE_GANG_ITALIAN,
		PED_TYPE_GANG_RUSSIAN,
		PED_TYPE_GANG_RUSSIAN_2,
		PED_TYPE_GANG_IRISH,
		PED_TYPE_GANG_JAMAICAN,
		PED_TYPE_GANG_AFRICAN_AMERICAN,
		PED_TYPE_GANG_KOREAN,
		PED_TYPE_GANG_CHINESE_JAPANESE,
		PED_TYPE_GANG_PUERTO_RICAN,
		PED_TYPE_DEALER,
		PED_TYPE_MEDIC,
		PED_TYPE_FIREMAN,
		PED_TYPE_CRIMINAL,
		PED_TYPE_BUM,
		PED_TYPE_PROSTITUTE,
		PED_TYPE_SPECIAL,
		PED_TYPE_MISSION,
		PED_TYPE_SWAT,
		PED_TYPE_ANIMAL,
		PED_TYPE_ARMY
	}

	public static List<Ped> DeadBois = new List<Ped>();

	public MPKillReward()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch >= 2 || CruelMastersOnlineOffline.DEBUG)
		{
			XPController();
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}

	private void XPController()
	{
		Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character.Position, 500f);
		Ped[] array = nearbyPeds;
		foreach (Ped ped in array)
		{
			if (!(ped != null) || !ped.IsDead || DeadBois.Contains(ped))
			{
				continue;
			}
			Entity killer = ped.Killer;
			if (killer is Ped && killer as Ped == Game.Player.Character)
			{
				DeadBois.Add(ped);
				if (ped.GetRelationshipWithPed(Game.Player.Character) == Relationship.Hate || (ped.GetRelationshipWithPed(Game.Player.Character) == Relationship.Dislike && ped.GetRelationshipWithPed(Game.Player.Character) != Relationship.Pedestrians))
				{
					MPRank.CurrentXP += 25;
					CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player RP", MPRank.CurrentXP);
				}
				if (Function.Call<int>(Hash.GET_PED_TYPE, ped) != 28)
				{
					MPCash.ADD_CASH(Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 15, 200));
				}
				break;
			}
		}
		foreach (Ped item in DeadBois.ToList())
		{
			if (item == null || !item.Exists())
			{
				DeadBois.Remove(item);
			}
		}
	}
}
