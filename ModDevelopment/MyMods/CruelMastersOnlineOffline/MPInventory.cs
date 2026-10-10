using System.Collections.Generic;

namespace CruelMastersOnlineOffline;

public class MPInventory
{
	public List<OwnedInventory> ownedInventorys = new List<OwnedInventory>();

	public static void CREATE_NEW_INVENTORY()
	{
		MPInventory mPInventory = new MPInventory();
		OwnedInventory ownedInventory = new OwnedInventory();
		ownedInventory.SuperLightArmor = 0;
		ownedInventory.LightArmor = 0;
		ownedInventory.StandardArmor = 0;
		ownedInventory.HeavyArmor = 0;
		ownedInventory.SuperHeavyArmor = 0;
		ownedInventory.PQs = 0;
		ownedInventory.EgoChasers = 0;
		ownedInventory.Meteorites = 0;
		ownedInventory.eColas = 0;
		mPInventory.ownedInventorys.Add(ownedInventory);
		XMLSerializer.SaveToXML(mPInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
	}
}
