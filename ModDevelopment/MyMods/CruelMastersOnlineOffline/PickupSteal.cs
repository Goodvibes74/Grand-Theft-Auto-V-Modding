using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class PickupSteal : Script
{
	public static bool AllowPickupSteal = false;

	public static int TotalAmount = 0;

	public static List<Pickup> PickupSpawn = new List<Pickup>();

	public PickupSteal()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
		if (AllowPickupSteal)
		{
			if (PickupSpawn.Count <= 0)
			{
				return;
			}
			{
				foreach (Pickup item in PickupSpawn.ToList())
				{
					if (item != null && !item.ObjectExists())
					{
						Heist_Hud.Actual_Take += TotalAmount;
						item.Delete();
						PickupSpawn.Remove(item);
					}
				}
				return;
			}
		}
		if (PickupSpawn.Count <= 0)
		{
			return;
		}
		foreach (Pickup item2 in PickupSpawn.ToList())
		{
			if (item2 != null && !item2.ObjectExists())
			{
				item2.Delete();
				PickupSpawn.Remove(item2);
			}
		}
	}

	public static void SPAWN_PICKUP(PickupType type, Vector3 pos, Vector3 rot, Model model, int value)
	{
		Pickup item = World.CreatePickup(type, pos, rot, model, value);
		PickupSpawn.Add(item);
	}

	public static void SPAWN_PICKUP_WITH_BLIP(PickupType type, Vector3 pos, Vector3 rot, Model model, int value, int blipid, BlipColor color, string name = "", bool minimaledge = true, float scale = 1f)
	{
		Blip blip = null;
		Pickup pickup = null;
		while (pickup == null)
		{
			pickup = World.CreatePickup(type, pos, rot, model, value);
			Script.Wait(0);
		}
		while (blip == null)
		{
			blip = Function.Call<Blip>(Hash.ADD_BLIP_FOR_PICKUP, pickup);
			Script.Wait(0);
		}
		blip.Sprite = (BlipSprite)blipid;
		blip.Color = color;
		blip.Name = name;
		blip.Scale = scale;
		Function.Call(Hash.SET_BLIP_AS_SHORT_RANGE, blip, minimaledge);
		PickupSpawn.Add(pickup);
	}

	public static void RemovePickups()
	{
		if (PickupSpawn.Count <= 0)
		{
			return;
		}
		foreach (Pickup item in PickupSpawn.ToList())
		{
			if (item != null)
			{
				item.Delete();
				PickupSpawn.Remove(item);
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		RemovePickups();
	}
}
