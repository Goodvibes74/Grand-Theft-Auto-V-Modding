using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Props : Script
{
	public static List<Prop> propList = new List<Prop>();

	public static List<Prop> gspropList = new List<Prop>();

	public Props()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			RemoveProps();
		}
	}

	public static void BlipUpProp(int sprite, BlipColor color, string name)
	{
		if (propList.Count <= 0)
		{
			return;
		}
		foreach (Prop prop in propList)
		{
			if (prop != null)
			{
				if (prop.AttachedBlip == null)
				{
					prop.AddBlip();
					continue;
				}
				prop.AttachedBlip.Sprite = (BlipSprite)sprite;
				prop.AttachedBlip.Color = color;
				prop.AttachedBlip.Name = name;
			}
		}
	}

	public static bool Does_Blip_Exist(Prop prop)
	{
		return prop.AttachedBlip != null;
	}

	public static void CheckBlips()
	{
		if (propList.Count <= 0)
		{
			return;
		}
		foreach (Prop item in propList.ToList())
		{
			if (item != null && item.HasBeenDamagedByAnyWeapon())
			{
				if (Does_Blip_Exist(item))
				{
					item.AttachedBlip.Delete();
				}
				item.MarkAsNoLongerNeeded();
				propList.Remove(item);
			}
		}
	}

	public static void RemoveProps()
	{
		if (propList.Count <= 0)
		{
			return;
		}
		foreach (Prop item in propList.ToList())
		{
			if (item != null)
			{
				if (Does_Blip_Exist(item))
				{
					item.AttachedBlip.Delete();
				}
				item.Delete();
				propList.Remove(item);
			}
		}
	}

	public static void SPAWN_PROP(string modelhash, Vector3 loc, Vector3 rot, bool dynamic, bool placeonground, bool frozen, bool collision, bool IsInvincible, bool IsVisible)
	{
		Prop prop = World.CreateProp(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic, placeonground);
		while (prop == null)
		{
			prop = World.CreateProp(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic, placeonground);
			Script.Wait(0);
		}
		prop.IsPositionFrozen = frozen;
		prop.IsCollisionEnabled = collision;
		prop.IsInvincible = IsInvincible;
		prop.IsVisible = IsVisible;
		propList.Add(prop);
	}

	public static void SPAWN_PROP(int modelhash, Vector3 loc, Vector3 rot, bool dynamic, bool placeonground, bool frozen, bool collision, bool IsInvincible, bool IsVisible)
	{
		Prop prop = World.CreateProp(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic, placeonground);
		while (prop == null)
		{
			prop = World.CreateProp(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic, placeonground);
			Script.Wait(0);
		}
		prop.IsPositionFrozen = frozen;
		prop.IsCollisionEnabled = collision;
		prop.IsInvincible = IsInvincible;
		prop.IsVisible = IsVisible;
		propList.Add(prop);
	}

	public static void SPAWN_PROP_NO_OFFSET(string modelhash, Vector3 loc, Vector3 rot, bool dynamic, bool frozen, bool collision, bool IsInvincible, bool IsVisible)
	{
		Prop prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
		while (prop == null)
		{
			prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
			Script.Wait(0);
		}
		prop.IsPositionFrozen = frozen;
		prop.IsCollisionEnabled = collision;
		prop.IsInvincible = IsInvincible;
		prop.IsVisible = IsVisible;
		propList.Add(prop);
	}

	public static void SPAWN_PROP_NO_OFFSET(int modelhash, Vector3 loc, Vector3 rot, bool dynamic, bool frozen, bool collision, bool IsInvincible, bool IsVisible)
	{
		Prop prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
		while (prop == null)
		{
			prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
			Script.Wait(0);
		}
		prop.IsPositionFrozen = frozen;
		prop.IsCollisionEnabled = collision;
		prop.IsInvincible = IsInvincible;
		prop.IsVisible = IsVisible;
		propList.Add(prop);
	}

	public static void SPAWN_PROP_NO_OFFSET_WITH_BLIP(string modelhash, Vector3 loc, Vector3 rot, bool dynamic, bool frozen, bool collision, bool IsInvincible, bool IsVisible, int blipid, BlipColor color, string name = "", bool minimaledge = true)
	{
		Prop prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
		while (prop == null)
		{
			prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
			Script.Wait(0);
		}
		prop.IsPositionFrozen = frozen;
		prop.IsCollisionEnabled = collision;
		prop.IsInvincible = IsInvincible;
		prop.IsVisible = IsVisible;
		while (prop.AttachedBlip == null)
		{
			prop.AddBlip();
			Script.Wait(0);
		}
		prop.AttachedBlip.Sprite = (BlipSprite)blipid;
		prop.AttachedBlip.Color = color;
		prop.AttachedBlip.Name = name;
		Function.Call(Hash.SET_BLIP_AS_SHORT_RANGE, prop.AttachedBlip, minimaledge);
		propList.Add(prop);
	}

	public static void SPAWN_PROP_NO_OFFSET_WITH_BLIP(int modelhash, Vector3 loc, Vector3 rot, bool dynamic, bool frozen, bool collision, bool IsInvincible, bool IsVisible, int blipid, BlipColor color, string name = "", bool minimaledge = true)
	{
		Prop prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
		while (prop == null)
		{
			prop = World.CreatePropNoOffset(CruelMastersOnlineOffline.RequestModel(modelhash), loc, rot, dynamic);
			Script.Wait(0);
		}
		prop.IsPositionFrozen = frozen;
		prop.IsCollisionEnabled = collision;
		prop.IsInvincible = IsInvincible;
		prop.IsVisible = IsVisible;
		while (prop.AttachedBlip == null)
		{
			prop.AddBlip();
			Script.Wait(0);
		}
		prop.AttachedBlip.Sprite = (BlipSprite)blipid;
		prop.AttachedBlip.Color = color;
		prop.AttachedBlip.Name = name;
		Function.Call(Hash.SET_BLIP_AS_SHORT_RANGE, prop.AttachedBlip, minimaledge);
		propList.Add(prop);
	}
}
