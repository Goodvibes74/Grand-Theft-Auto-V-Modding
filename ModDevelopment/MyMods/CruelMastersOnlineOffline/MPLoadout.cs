using System.Collections.Generic;
using System.IO;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

public class MPLoadout
{
	public List<WeaponWithComponents> CurrentLoadout = new List<WeaponWithComponents>();

	public static void SAVE_CURRENT_LOADOUT()
	{
		MPLoadout mPLoadout = new MPLoadout();
		foreach (WeaponHash enumValue in typeof(WeaponHash).GetEnumValues())
		{
			if (!Game.Player.Character.Weapons.HasWeapon(enumValue))
			{
				continue;
			}
			WeaponWithComponents weaponWithComponents = new WeaponWithComponents
			{
				Weapon = (WeaponHash)0u,
				Components = new List<WeaponComponentHash>()
			};
			weaponWithComponents.Weapon = enumValue;
			foreach (WeaponComponentHash enumValue2 in typeof(WeaponComponentHash).GetEnumValues())
			{
				if (Game.Player.Character.Weapons[enumValue].Components[enumValue2].Active)
				{
					weaponWithComponents.Components.Add(enumValue2);
					if (enumValue2.ToString().Contains("Camo"))
					{
						weaponWithComponents.CompTint = Function.Call<int>(Hash.GET_PED_WEAPON_COMPONENT_TINT_INDEX, Game.Player.Character, enumValue, enumValue2);
					}
				}
			}
			weaponWithComponents.Tint = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, enumValue);
			weaponWithComponents.Ammo = Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, enumValue);
			mPLoadout.CurrentLoadout.Add(weaponWithComponents);
		}
		XMLSerializer.SaveToXML(mPLoadout, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\CurrentLoadout.xml");
	}

	public static void GET_CURRENT_LOADOUT()
	{
		if (!File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\CurrentLoadout.xml"))
		{
			return;
		}
		Game.Player.Character.Weapons.RemoveAll();
		MPLoadout mPLoadout = XMLSerializer.DeserializeXML<MPLoadout>("scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\CurrentLoadout.xml");
		for (int i = 0; i < mPLoadout.CurrentLoadout.Count; i++)
		{
			Game.Player.Character.Weapons.Give(mPLoadout.CurrentLoadout[i].Weapon, mPLoadout.CurrentLoadout[i].Ammo, equipNow: true, isAmmoLoaded: true);
			foreach (WeaponComponentHash enumValue in typeof(WeaponComponentHash).GetEnumValues())
			{
				if (mPLoadout.CurrentLoadout[i].Components.Contains(enumValue))
				{
					for (int j = 0; j < mPLoadout.CurrentLoadout[i].Components.Count; j++)
					{
						Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, mPLoadout.CurrentLoadout[i].Weapon, mPLoadout.CurrentLoadout[i].Components[j]);
						Function.Call(Hash.SET_PED_WEAPON_COMPONENT_TINT_INDEX, Game.Player.Character, mPLoadout.CurrentLoadout[i].Weapon, mPLoadout.CurrentLoadout[i].Components[j], mPLoadout.CurrentLoadout[i].CompTint);
					}
				}
			}
			Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, mPLoadout.CurrentLoadout[i].Weapon, mPLoadout.CurrentLoadout[i].Tint);
		}
		Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
	}
}
