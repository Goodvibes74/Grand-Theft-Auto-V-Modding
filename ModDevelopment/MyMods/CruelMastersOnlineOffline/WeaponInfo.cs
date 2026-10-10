using System.Collections.Generic;
using GTA;

namespace CruelMastersOnlineOffline;

public class WeaponInfo
{
	public WeaponHash weaponHash;

	public int weaponCost;

	public int rankNeeded;

	public List<string> compHashName;

	public List<int> compCost;

	public List<int> compRank;

	public List<string> compLabel;

	public List<string> compDesc;

	public int AmmoPer;

	public int AmmoCost;

	public WeaponInfo(WeaponHash weaponhash, int weaponcost, int rankreq, List<string> comphashname, List<int> compcost, List<int> comprank, List<string> complabel, List<string> compdesc, int ammoPer, int ammoCost)
	{
		weaponHash = weaponhash;
		weaponCost = weaponcost;
		rankNeeded = rankreq;
		compHashName = comphashname;
		compCost = compcost;
		compRank = comprank;
		compLabel = complabel;
		compDesc = compdesc;
		AmmoPer = ammoPer;
		AmmoCost = ammoCost;
	}
}
