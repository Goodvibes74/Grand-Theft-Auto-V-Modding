using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Weapons
{
	public static int GET_AMMO_IN_CLIP(Ped ped, WeaponHash weaponHash)
	{
		OutputArgument outputArgument = new OutputArgument();
		return Function.Call<bool>(Hash.GET_AMMO_IN_CLIP, ped, weaponHash, outputArgument) ? outputArgument.GetResult<int>() : 0;
	}

	public static int GET_AMMO_IN_PED_WEAPON(Ped ped, WeaponHash weaponHash)
	{
		return Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, ped, weaponHash);
	}

	public static void SET_PED_AMMO(Ped ped, WeaponHash weaponHash, int ammo)
	{
		Function.Call(Hash.SET_PED_AMMO, ped, weaponHash, ammo, 0);
	}

	public static void ADD_AMMO_TO_PED(Ped ped, WeaponHash weaponHash, int ammo)
	{
		Function.Call(Hash.ADD_AMMO_TO_PED, ped, weaponHash, ammo);
	}

	public static void GiveWeapon(Ped player, WeaponHash weapon, int ammoCount, bool equipNow, bool isAmmoLoaded)
	{
		while (!HAS_WEAPON(player, weapon))
		{
			player.Weapons.Give(weapon, ammoCount, equipNow, isAmmoLoaded);
			Script.Wait(0);
		}
	}

	public static void Give_Component(Ped player, string attachment, WeaponHash weaponhash)
	{
		if (HAS_WEAPON(player, weaponhash))
		{
			Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, player, (uint)weaponhash, Function.Call<Hash>(Hash.GET_HASH_KEY, attachment));
		}
	}

	public static void Remove_Component(Ped player, string attachment, WeaponHash weaponhash)
	{
		if (HAS_WEAPON(player, weaponhash))
		{
			Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, player, (uint)weaponhash, Function.Call<Hash>(Hash.GET_HASH_KEY, attachment));
		}
	}

	public static void EquipNow(Ped player, WeaponHash weapon, bool equipNow)
	{
		player.Weapons.Select(weapon, equipNow);
	}

	public static void Anim_Weapon_Off()
	{
		Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
	}

	public static bool HAS_WEAPON(Ped ped, WeaponHash weapon)
	{
		return ped.Weapons.HasWeapon(weapon);
	}

	public static bool HAS_WEAPON_COMPONENT(Ped ped, WeaponHash weaponhash, string attachment)
	{
		return Function.Call<bool>(Hash.IS_PED_WEAPON_COMPONENT_ACTIVE, ped, weaponhash, Function.Call<Hash>(Hash.GET_HASH_KEY, attachment));
	}
}
