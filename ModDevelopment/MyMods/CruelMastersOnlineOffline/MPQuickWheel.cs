using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPQuickWheel : Script
{
	public static int UseSwitch;

	public MPQuickWheel()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if ((CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG) || !Hud.IsComponentActive(HudComponent.WeaponWheel) || !(Game.Player.Character.CurrentVehicle == null))
		{
			return;
		}
		if (Function.Call<bool>(Hash.IS_USING_KEYBOARD_AND_MOUSE, 2))
		{
			Screen.ShowHelpTextThisFrame("Press ~INPUT_LOOK_BEHIND~ to eat a snack.\nPress ~INPUT_NEXT_CAMERA~ to use armor.", beep: false);
			if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 26) && UseSwitch == 0)
			{
				MPInventory mPInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				if (mPInventory.ownedInventorys[0].Meteorites > 0)
				{
					mPInventory.ownedInventorys[0].Meteorites--;
					XMLSerializer.SaveToXML(mPInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Health += 50;
				}
				else if (mPInventory.ownedInventorys[0].eColas > 0)
				{
					mPInventory.ownedInventorys[0].eColas--;
					XMLSerializer.SaveToXML(mPInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Health += 35;
				}
				else if (mPInventory.ownedInventorys[0].EgoChasers > 0)
				{
					mPInventory.ownedInventorys[0].EgoChasers--;
					XMLSerializer.SaveToXML(mPInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Health += 20;
				}
				else if (mPInventory.ownedInventorys[0].PQs > 0)
				{
					mPInventory.ownedInventorys[0].PQs--;
					XMLSerializer.SaveToXML(mPInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Health += 10;
				}
				else if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Snack Used", blinking: true);
				}
			}
			if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 0) && UseSwitch == 0)
			{
				MPInventory mPInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				if (mPInventory2.ownedInventorys[0].SuperHeavyArmor > 0)
				{
					mPInventory2.ownedInventorys[0].SuperHeavyArmor--;
					XMLSerializer.SaveToXML(mPInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Armor += 100;
				}
				else if (mPInventory2.ownedInventorys[0].HeavyArmor > 0)
				{
					mPInventory2.ownedInventorys[0].HeavyArmor--;
					XMLSerializer.SaveToXML(mPInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Armor += 80;
				}
				else if (mPInventory2.ownedInventorys[0].StandardArmor > 0)
				{
					mPInventory2.ownedInventorys[0].StandardArmor--;
					XMLSerializer.SaveToXML(mPInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Armor += 60;
				}
				else if (mPInventory2.ownedInventorys[0].LightArmor > 0)
				{
					mPInventory2.ownedInventorys[0].LightArmor--;
					XMLSerializer.SaveToXML(mPInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Armor += 40;
				}
				else if (mPInventory2.ownedInventorys[0].SuperLightArmor > 0)
				{
					mPInventory2.ownedInventorys[0].SuperLightArmor--;
					XMLSerializer.SaveToXML(mPInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
					Game.Player.Character.Armor += 20;
				}
				else if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Armor Used", blinking: true);
				}
			}
			return;
		}
		Screen.ShowHelpTextThisFrame("Press ~INPUT_FRONTEND_UP~ to eat a snack.\nPress ~INPUT_LOOK_BEHIND~ to use armor.", beep: false);
		if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 188) && UseSwitch == 0)
		{
			MPInventory mPInventory3 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
			if (mPInventory3.ownedInventorys[0].Meteorites > 0)
			{
				mPInventory3.ownedInventorys[0].Meteorites--;
				XMLSerializer.SaveToXML(mPInventory3, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				Game.Player.Character.Health += 50;
			}
			else if (mPInventory3.ownedInventorys[0].eColas > 0)
			{
				mPInventory3.ownedInventorys[0].eColas--;
				XMLSerializer.SaveToXML(mPInventory3, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				Game.Player.Character.Health += 35;
			}
			else if (mPInventory3.ownedInventorys[0].EgoChasers > 0)
			{
				mPInventory3.ownedInventorys[0].EgoChasers--;
				XMLSerializer.SaveToXML(mPInventory3, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				Game.Player.Character.Health += 20;
			}
			else if (mPInventory3.ownedInventorys[0].PQs > 0)
			{
				mPInventory3.ownedInventorys[0].PQs--;
				XMLSerializer.SaveToXML(mPInventory3, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				Game.Player.Character.Health += 10;
			}
			else if (CruelMastersOnlineOffline.DEBUG)
			{
				Notification.Show("Snack Used", blinking: true);
			}
		}
		if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 26) && UseSwitch == 0)
		{
			MPInventory mPInventory4 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
			if (mPInventory4.ownedInventorys[0].SuperHeavyArmor > 0)
			{
				mPInventory4.ownedInventorys[0].SuperHeavyArmor--;
				Game.Player.Character.Armor += 100;
				XMLSerializer.SaveToXML(mPInventory4, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
			}
			else if (mPInventory4.ownedInventorys[0].HeavyArmor > 0)
			{
				mPInventory4.ownedInventorys[0].HeavyArmor--;
				Game.Player.Character.Armor += 80;
				XMLSerializer.SaveToXML(mPInventory4, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
			}
			else if (mPInventory4.ownedInventorys[0].StandardArmor > 0)
			{
				mPInventory4.ownedInventorys[0].StandardArmor--;
				Game.Player.Character.Armor += 60;
				XMLSerializer.SaveToXML(mPInventory4, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
			}
			else if (mPInventory4.ownedInventorys[0].LightArmor > 0)
			{
				mPInventory4.ownedInventorys[0].LightArmor--;
				Game.Player.Character.Armor += 40;
				XMLSerializer.SaveToXML(mPInventory4, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
			}
			else if (mPInventory4.ownedInventorys[0].SuperLightArmor > 0)
			{
				mPInventory4.ownedInventorys[0].SuperLightArmor--;
				Game.Player.Character.Armor += 20;
				XMLSerializer.SaveToXML(mPInventory4, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
			}
			else if (CruelMastersOnlineOffline.DEBUG)
			{
				Notification.Show("Armor Used", blinking: true);
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}
}
