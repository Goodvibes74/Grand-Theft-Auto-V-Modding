using System.Collections.Generic;
using GTA;

namespace CruelMastersOnlineOffline;

public class OwnedWeapons
{
	public static List<WeaponHash> ownedWeapons = new List<WeaponHash>();

	public static List<WeaponComponentHash> ownedWeaponComps = new List<WeaponComponentHash>();

	public static List<int> ownedWeaponTints = new List<int>();

	public static List<int> ownedWeaponCompTints = new List<int>();

	public static List<OwnedWeapons> OwnedWeapon = new List<OwnedWeapons>();

	public List<WeaponHash> Weapon;

	public List<WeaponComponentHash> Components;

	public List<int> Tint;

	public List<int> CompTint;
}
