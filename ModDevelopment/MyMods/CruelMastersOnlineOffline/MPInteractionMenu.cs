using System;
using System.ComponentModel;
using System.IO;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;

namespace CruelMastersOnlineOffline;

internal class MPInteractionMenu : Script
{
	public static ObjectPool MenuPool = new ObjectPool();

	public static NativeMenu InteractionMenu;

	public static bool CAN_OPEN_INTERACTION_MENU = true;

	public static bool PI_MENU_IS_OPEN = false;

	public static int ScaleID;

	public static int ButtonHoldTimer = 0;

	public MPInteractionMenu()
	{
		Tick += onTick;
		Aborted += onShutdown;
		InteractionMenu = new NativeMenu(CruelMastersOnlineOffline.Player_Name, "INTERACTION MENU");
		// (LemonUI 2.x: banner title styling not available) InteractionMenu.Title.Outline = true;
		// (LemonUI 2.x: banner title styling not available) InteractionMenu.Title.Shadow = true;
		// (LemonUI 2.x: banner title styling not available) InteractionMenu.TitleFont = Font.ChaletComprimeCologne;
		InteractionMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		InteractionMenu.CloseOnInvalidClick = false;
		MenuPool.Add(InteractionMenu);
	}

	public unsafe static void SETUP_INTERACTION_MENU()
	{
		InteractionMenu.Clear();
		NativeMenu nativeMenu = new NativeMenu("", "Inventory", "Your Inventory contains carried items such as cash, body armor and snacks.");
		MenuPool.Add(nativeMenu);
		nativeMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem = new NativeSubmenuItem(nativeMenu, InteractionMenu);
		nativeSubmenuItem.AltTitle = "";
		InteractionMenu.Add(0, nativeSubmenuItem);
		NativeMenu nativeMenu2 = new NativeMenu("", "Cash", "");
		MenuPool.Add(nativeMenu2);
		nativeMenu2.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu2.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem2 = new NativeSubmenuItem(nativeMenu2, nativeMenu);
		nativeSubmenuItem2.AltTitle = "";
		nativeMenu.Add(0, nativeSubmenuItem2);
		NativeItem CashDisplayItem = new NativeItem("Cash", "The Current Amount of cash you have on hand.", $"${MPCash.Cash}");
		CashDisplayItem.Enabled = false;
		nativeMenu2.Add(CashDisplayItem);
		NativeItem nativeItem = new NativeItem("Transfer Cash to Bank", "Add your chosen amount of Cash to the Bank.", "");
		nativeMenu2.Add(nativeItem);
		NativeItem nativeItem2 = new NativeItem("Transfer All Cash to Bank", "Add all of your Cash to the Bank.", "");
		nativeMenu2.Add(nativeItem2);
		NativeItem BankDisplayItem = new NativeItem("Bank", "The Current Amount of cash you have in the Bank.", $"${MPCash.Bank}");
		BankDisplayItem.Enabled = false;
		nativeMenu2.Add(BankDisplayItem);
		NativeItem nativeItem3 = new NativeItem("Transfer Bank Cash to Wallet", "Add your chosen amount of Bank Cash to your Wallet.", "");
		nativeMenu2.Add(nativeItem3);
		NativeItem nativeItem4 = new NativeItem("Transfer All Bank Cash to Wallet", "Add all of your Bank Cash to your Wallet.", "");
		nativeMenu2.Add(nativeItem4);
		nativeItem.Activated += (object sender, EventArgs e) =>
		{
			string userInput = ONSCREEN_KEYBOARD.GetUserInput("", "0", 9);
			int result = 0;
			if (int.TryParse(userInput, out result) && MPCash.Cash >= result)
			{
				MPCash.REMOVE_CASH(result);
				MPCash.ADD_BANK(result);
				CashDisplayItem.AltTitle = $"${MPCash.Cash}";
				BankDisplayItem.AltTitle = $"${MPCash.Bank}";
				Notification.Show($"~g~${result}~w~ transfered.", blinking: true);
			}
		};
		nativeItem2.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.Cash > 0)
			{
				Notification.Show($"~g~${MPCash.Cash}~w~ transfered.", blinking: true);
				MPCash.ADD_BANK(MPCash.Cash);
				MPCash.REMOVE_CASH(MPCash.Cash);
				CashDisplayItem.AltTitle = $"${MPCash.Cash}";
				BankDisplayItem.AltTitle = $"${MPCash.Bank}";
			}
		};
		nativeItem3.Activated += (object sender, EventArgs e) =>
		{
			string userInput = ONSCREEN_KEYBOARD.GetUserInput("", "0", 9);
			int result = 0;
			if (int.TryParse(userInput, out result) && MPCash.Bank >= result)
			{
				MPCash.REMOVE_BANK(result);
				MPCash.ADD_CASH(result);
				CashDisplayItem.AltTitle = $"${MPCash.Cash}";
				BankDisplayItem.AltTitle = $"${MPCash.Bank}";
				Notification.Show($"~g~${result}~w~ transfered.", blinking: true);
			}
		};
		nativeItem4.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.Bank > 0)
			{
				Notification.Show($"~g~${MPCash.Bank}~w~ transfered.", blinking: true);
				MPCash.ADD_CASH(MPCash.Bank);
				MPCash.REMOVE_BANK(MPCash.Bank);
				CashDisplayItem.AltTitle = $"${MPCash.Cash}";
				BankDisplayItem.AltTitle = $"${MPCash.Bank}";
			}
		};
		MPInventory playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
		NativeMenu nativeMenu3 = new NativeMenu("", "Body Armor", "");
		MenuPool.Add(nativeMenu3);
		nativeMenu3.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu3.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem3 = new NativeSubmenuItem(nativeMenu3, nativeMenu);
		nativeSubmenuItem3.AltTitle = "";
		nativeMenu.Add(1, nativeSubmenuItem3);
		NativeListItem<string> ArmorCatagory = new NativeListItem<string>("Armor Type", "Choose the type of armor to buy.", "Super Light Armor-$100", "Light Armor-$200", "Standard Armor-$300", "Heavy Armor-$400", "Super Heavy Armor-$500");
		if (!CruelMastersOnlineOffline.OnMission)
		{
			ArmorCatagory.Enabled = true;
			if (MPRank.PlayerLevel > 5)
			{
				ArmorCatagory.Description = "This body armor offers good protection from small-caliber handgun projectiles but is also extremely lightweight and easily concealable.";
				ArmorCatagory.AltTitle = "$100";
				ArmorCatagory.RightBadgeSet = null;
			}
			else
			{
				ArmorCatagory.Description = "This Item unlocks at Rank 5.";
				ArmorCatagory.AltTitle = "";
				BadgeSet badgeSet = new BadgeSet();
				badgeSet.NormalDictionary = "commonmenu";
				badgeSet.NormalTexture = "shop_lock";
				badgeSet.HoveredDictionary = "commonmenu";
				badgeSet.HoveredTexture = "shop_lock";
				ArmorCatagory.RightBadgeSet = badgeSet;
			}
		}
		else
		{
			ArmorCatagory.Enabled = false;
			ArmorCatagory.Description = "You cannot purchase armor while on an active mission.";
		}
		ArmorCatagory.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			switch (ArmorCatagory.SelectedItem)
			{
			case "Super Light Armor-$100":
				if (MPRank.PlayerLevel > 5)
				{
					ArmorCatagory.Description = "This body armor offers good protection from small-caliber handgun projectiles but is also extremely lightweight and easily concealable.";
					ArmorCatagory.AltTitle = "$100";
					ArmorCatagory.RightBadgeSet = null;
				}
				else
				{
					ArmorCatagory.Description = "This Item unlocks at Rank 5.";
					ArmorCatagory.AltTitle = "";
					BadgeSet rightBadgeSet2 = new BadgeSet
					{
						NormalDictionary = "commonmenu",
						NormalTexture = "shop_lock",
						HoveredDictionary = "commonmenu",
						HoveredTexture = "shop_lock"
					};
					ArmorCatagory.RightBadgeSet = rightBadgeSet2;
				}
				break;
			case "Light Armor-$200":
				if (MPRank.PlayerLevel > 10)
				{
					ArmorCatagory.Description = "This lightweight body armor combines the comfort and mobility of a soft vest with the option of hard armor inserts for extra protection.";
					ArmorCatagory.AltTitle = "$200";
					ArmorCatagory.RightBadgeSet = null;
				}
				else
				{
					ArmorCatagory.Description = "This Item unlocks at Rank 10.";
					ArmorCatagory.AltTitle = "";
					BadgeSet rightBadgeSet5 = new BadgeSet
					{
						NormalDictionary = "commonmenu",
						NormalTexture = "shop_lock",
						HoveredDictionary = "commonmenu",
						HoveredTexture = "shop_lock"
					};
					ArmorCatagory.RightBadgeSet = rightBadgeSet5;
				}
				break;
			case "Standard Armor-$300":
				if (MPRank.PlayerLevel > 15)
				{
					ArmorCatagory.Description = "Featuring full-size hard armor panels to the front and rear, with the option to fit additional soft side panels, this ballistic vest offers excellent protection from handgun and rifle projectiles.";
					ArmorCatagory.AltTitle = "$300";
					ArmorCatagory.RightBadgeSet = null;
				}
				else
				{
					ArmorCatagory.Description = "This Item unlocks at Rank 15.";
					ArmorCatagory.AltTitle = "";
					BadgeSet rightBadgeSet3 = new BadgeSet
					{
						NormalDictionary = "commonmenu",
						NormalTexture = "shop_lock",
						HoveredDictionary = "commonmenu",
						HoveredTexture = "shop_lock"
					};
					ArmorCatagory.RightBadgeSet = rightBadgeSet3;
				}
				break;
			case "Heavy Armor-$400":
				if (MPRank.PlayerLevel > 20)
				{
					ArmorCatagory.Description = "This heavy-duty ballistic vest comes with full-size front and rear hard armor panels and optional hard armor side inserts for all-round protection.";
					ArmorCatagory.AltTitle = "$400";
					ArmorCatagory.RightBadgeSet = null;
				}
				else
				{
					ArmorCatagory.Description = "This Item unlocks at Rank 20.";
					ArmorCatagory.AltTitle = "";
					BadgeSet rightBadgeSet4 = new BadgeSet
					{
						NormalDictionary = "commonmenu",
						NormalTexture = "shop_lock",
						HoveredDictionary = "commonmenu",
						HoveredTexture = "shop_lock"
					};
					ArmorCatagory.RightBadgeSet = rightBadgeSet4;
				}
				break;
			case "Super Heavy Armor-$500":
				if (MPRank.PlayerLevel > 25)
				{
					ArmorCatagory.Description = "This heavy-duty body armor features full-size high tensile strength ballistic plate to the front, rear and sides for maximum protection against large-caliber firearm projectiles and high-explosive shell fragments.";
					ArmorCatagory.AltTitle = "$500";
					ArmorCatagory.RightBadgeSet = null;
				}
				else
				{
					ArmorCatagory.Description = "This Item unlocks at Rank 25.";
					ArmorCatagory.AltTitle = "";
					BadgeSet rightBadgeSet = new BadgeSet
					{
						NormalDictionary = "commonmenu",
						NormalTexture = "shop_lock",
						HoveredDictionary = "commonmenu",
						HoveredTexture = "shop_lock"
					};
					ArmorCatagory.RightBadgeSet = rightBadgeSet;
				}
				break;
			}
		};
		nativeMenu3.Add(ArmorCatagory);
		NativeItem SuperLightArmorItem = new NativeItem("Super Light Armor", "Use a Super Light Armor to refill your armor bar.", $"{playerInventory.ownedInventorys[0].SuperLightArmor}");
		SuperLightArmorItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory.ownedInventorys[0].SuperLightArmor > 0)
			{
				playerInventory.ownedInventorys[0].SuperLightArmor--;
				XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				SuperLightArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].SuperLightArmor}";
				Game.Player.Character.Armor += 20;
			}
		};
		nativeMenu3.Add(SuperLightArmorItem);
		NativeItem LightArmorItem = new NativeItem("Light Armor", "Use a Light Armor to refill your armor bar.", $"{playerInventory.ownedInventorys[0].LightArmor}");
		LightArmorItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory.ownedInventorys[0].LightArmor > 0)
			{
				playerInventory.ownedInventorys[0].LightArmor--;
				XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				LightArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].LightArmor}";
				Game.Player.Character.Armor += 40;
			}
		};
		nativeMenu3.Add(LightArmorItem);
		NativeItem StandardArmorItem = new NativeItem("Standard Armor", "Use a Standard Armor to refill your armor bar.", $"{playerInventory.ownedInventorys[0].StandardArmor}");
		StandardArmorItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory.ownedInventorys[0].StandardArmor > 0)
			{
				playerInventory.ownedInventorys[0].StandardArmor--;
				XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				StandardArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].StandardArmor}";
				Game.Player.Character.Armor += 60;
			}
		};
		nativeMenu3.Add(StandardArmorItem);
		NativeItem HeavyArmorItem = new NativeItem("Heavy Armor", "Use a Heavy Armor to refill your armor bar.", $"{playerInventory.ownedInventorys[0].HeavyArmor}");
		HeavyArmorItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory.ownedInventorys[0].HeavyArmor > 0)
			{
				playerInventory.ownedInventorys[0].HeavyArmor--;
				XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				HeavyArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].HeavyArmor}";
				Game.Player.Character.Armor += 80;
			}
		};
		nativeMenu3.Add(HeavyArmorItem);
		NativeItem SuperHeavyArmorItem = new NativeItem("Super Heavy Armor", "Use a Super Heavy Armor to refill your armor bar.", $"{playerInventory.ownedInventorys[0].SuperHeavyArmor}");
		SuperHeavyArmorItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory.ownedInventorys[0].SuperHeavyArmor > 0)
			{
				playerInventory.ownedInventorys[0].SuperHeavyArmor--;
				XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				SuperHeavyArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].SuperHeavyArmor}";
				Game.Player.Character.Armor += 100;
			}
		};
		nativeMenu3.Add(SuperHeavyArmorItem);
		ArmorCatagory.Activated += (object sender, EventArgs e) =>
		{
			switch (ArmorCatagory.SelectedItem)
			{
			case "Super Light Armor-$100":
				if (MPRank.PlayerLevel > 5 || CruelMastersOnlineOffline.DEBUG)
				{
					if (playerInventory.ownedInventorys[0].SuperLightArmor < 10)
					{
						if (MPCash.PROCESS_TRANSACTION(100))
						{
							playerInventory.ownedInventorys[0].SuperLightArmor++;
							XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							SuperLightArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].SuperLightArmor}";
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
						}
					}
					else
					{
						Notification.Show("Transaction Failed: Super Light Armor Full.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: Not Rank 5.", blinking: true);
				}
				break;
			case "Light Armor-$200":
				if (MPRank.PlayerLevel > 10 || CruelMastersOnlineOffline.DEBUG)
				{
					if (playerInventory.ownedInventorys[0].LightArmor < 10)
					{
						if (MPCash.PROCESS_TRANSACTION(200))
						{
							playerInventory.ownedInventorys[0].LightArmor++;
							XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							LightArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].LightArmor}";
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
						}
					}
					else
					{
						Notification.Show("Transaction Failed: Light Armor Full.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: Not Rank 10.", blinking: true);
				}
				break;
			case "Standard Armor-$300":
				if (MPRank.PlayerLevel > 15 || CruelMastersOnlineOffline.DEBUG)
				{
					if (playerInventory.ownedInventorys[0].StandardArmor < 10)
					{
						if (MPCash.PROCESS_TRANSACTION(300))
						{
							playerInventory.ownedInventorys[0].StandardArmor++;
							XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							StandardArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].StandardArmor}";
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
						}
					}
					else
					{
						Notification.Show("Transaction Failed: Standard Armor Full.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: Not Rank 15.", blinking: true);
				}
				break;
			case "Heavy Armor-$400":
				if (MPRank.PlayerLevel > 20 || CruelMastersOnlineOffline.DEBUG)
				{
					if (playerInventory.ownedInventorys[0].HeavyArmor < 10)
					{
						if (MPCash.PROCESS_TRANSACTION(400))
						{
							playerInventory.ownedInventorys[0].HeavyArmor++;
							XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							HeavyArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].HeavyArmor}";
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
						}
					}
					else
					{
						Notification.Show("Transaction Failed: Heavy Armor Full.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: Not Rank 20.", blinking: true);
				}
				break;
			case "Super Heavy Armor-$500":
				if (MPRank.PlayerLevel > 25 || CruelMastersOnlineOffline.DEBUG)
				{
					if (playerInventory.ownedInventorys[0].SuperHeavyArmor < 10)
					{
						if (MPCash.PROCESS_TRANSACTION(500))
						{
							playerInventory.ownedInventorys[0].SuperHeavyArmor++;
							XMLSerializer.SaveToXML(playerInventory, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							playerInventory = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
							SuperHeavyArmorItem.AltTitle = $"{playerInventory.ownedInventorys[0].SuperHeavyArmor}";
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
						}
					}
					else
					{
						Notification.Show("Transaction Failed: Super Heavy Armor Full.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: Not Rank 25.", blinking: true);
				}
				break;
			}
		};
		MPInventory playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
		NativeMenu nativeMenu4 = new NativeMenu("", "Snacks", "");
		MenuPool.Add(nativeMenu4);
		nativeMenu4.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu4.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem4 = new NativeSubmenuItem(nativeMenu4, nativeMenu);
		nativeSubmenuItem4.AltTitle = "";
		nativeMenu.Add(2, nativeSubmenuItem4);
		NativeListItem<string> SnackCatagory = new NativeListItem<string>("Snack Type", "The deliciously infectious soda.", "eCola-$3", "EgoChaser-$2", "Meteorite-$4", "P's & Q's-$1");
		if (!CruelMastersOnlineOffline.OnMission)
		{
			SnackCatagory.Enabled = true;
			SnackCatagory.Description = "The deliciously infectious soda.";
		}
		else
		{
			SnackCatagory.Enabled = false;
			SnackCatagory.Description = "You cannot purchase snacks while on an active mission.";
		}
		SnackCatagory.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			switch (SnackCatagory.SelectedItem)
			{
			case "eCola-$3":
				SnackCatagory.Description = "The deliciously infectious soda.";
				break;
			case "EgoChaser-$2":
				SnackCatagory.Description = "The energy bar that's all about YOU.";
				break;
			case "Meteorite-$4":
				SnackCatagory.Description = "Dark chocolate with GOOEY core.";
				break;
			case "P's & Q's-$1":
				SnackCatagory.Description = "The candy that kids and stoners love.";
				break;
			}
		};
		nativeMenu4.Add(SnackCatagory);
		NativeItem eColaItem = new NativeItem("eCola", "Drink a can of eCola.", $"{playerInventory2.ownedInventorys[0].eColas}");
		eColaItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory2.ownedInventorys[0].eColas > 0)
			{
				playerInventory2.ownedInventorys[0].eColas--;
				XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				eColaItem.AltTitle = $"{playerInventory2.ownedInventorys[0].eColas}";
				Game.Player.Character.Health += 35;
			}
		};
		nativeMenu4.Add(eColaItem);
		NativeItem EgoChasersItem = new NativeItem("EgoChaser", "Eat an EgoChaser bar.", $"{playerInventory2.ownedInventorys[0].EgoChasers}");
		EgoChasersItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory2.ownedInventorys[0].EgoChasers > 0)
			{
				playerInventory2.ownedInventorys[0].EgoChasers--;
				XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				EgoChasersItem.AltTitle = $"{playerInventory2.ownedInventorys[0].EgoChasers}";
				Game.Player.Character.Health += 20;
			}
		};
		nativeMenu4.Add(EgoChasersItem);
		NativeItem MeteoriteItem = new NativeItem("Meteorite", "Eat an Meteorite bar.", $"{playerInventory2.ownedInventorys[0].Meteorites}");
		MeteoriteItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory2.ownedInventorys[0].Meteorites > 0)
			{
				playerInventory2.ownedInventorys[0].Meteorites--;
				XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				MeteoriteItem.AltTitle = $"{playerInventory2.ownedInventorys[0].Meteorites}";
				Game.Player.Character.Health += 50;
			}
		};
		nativeMenu4.Add(MeteoriteItem);
		NativeItem PQSItem = new NativeItem("P's & Q's", "Eat a Pack of P's & Q's.", $"{playerInventory2.ownedInventorys[0].PQs}");
		PQSItem.Activated += (object sender, EventArgs e) =>
		{
			if (playerInventory2.ownedInventorys[0].PQs > 0)
			{
				playerInventory2.ownedInventorys[0].PQs--;
				XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
				PQSItem.AltTitle = $"{playerInventory2.ownedInventorys[0].PQs}";
				Game.Player.Character.Health += 10;
			}
		};
		nativeMenu4.Add(PQSItem);
		SnackCatagory.Activated += (object sender, EventArgs e) =>
		{
			switch (SnackCatagory.SelectedItem)
			{
			case "eCola-$3":
				if (playerInventory2.ownedInventorys[0].eColas < 10)
				{
					if (MPCash.PROCESS_TRANSACTION(3))
					{
						playerInventory2.ownedInventorys[0].eColas++;
						XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						eColaItem.AltTitle = $"{playerInventory2.ownedInventorys[0].eColas}";
					}
					else
					{
						Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: eCola Full.", blinking: true);
				}
				break;
			case "EgoChaser-$2":
				if (playerInventory2.ownedInventorys[0].EgoChasers < 15)
				{
					if (MPCash.PROCESS_TRANSACTION(2))
					{
						playerInventory2.ownedInventorys[0].EgoChasers++;
						XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						EgoChasersItem.AltTitle = $"{playerInventory2.ownedInventorys[0].EgoChasers}";
					}
					else
					{
						Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: EgoChasers Full.", blinking: true);
				}
				break;
			case "Meteorite-$4":
				if (playerInventory2.ownedInventorys[0].Meteorites < 5)
				{
					if (MPCash.PROCESS_TRANSACTION(4))
					{
						playerInventory2.ownedInventorys[0].Meteorites++;
						XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						MeteoriteItem.AltTitle = $"{playerInventory2.ownedInventorys[0].Meteorites}";
					}
					else
					{
						Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: Meteorites Full.", blinking: true);
				}
				break;
			case "P's & Q's-$1":
				if (playerInventory2.ownedInventorys[0].PQs < 30)
				{
					if (MPCash.PROCESS_TRANSACTION(1))
					{
						playerInventory2.ownedInventorys[0].PQs++;
						XMLSerializer.SaveToXML(playerInventory2, "scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						playerInventory2 = XMLSerializer.DeserializeXML<MPInventory>("scripts\\CruelMastersOnlineOfflineAssets\\Inventory\\PlayerInventory.xml");
						PQSItem.AltTitle = $"{playerInventory2.ownedInventorys[0].PQs}";
					}
					else
					{
						Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
					}
				}
				else
				{
					Notification.Show("Transaction Failed: P's & Q's Full.", blinking: true);
				}
				break;
			}
		};
		NativeMenu nativeMenu5 = new NativeMenu("", "Style", "View and change player options.");
		MenuPool.Add(nativeMenu5);
		nativeMenu5.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu5.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem5 = new NativeSubmenuItem(nativeMenu5, InteractionMenu);
		nativeSubmenuItem5.AltTitle = "";
		InteractionMenu.Add(1, nativeSubmenuItem5);
		MPSaveData thisStyleSaveData = MPSaveData.GET_MAIN_SAVE_DATA("Style Save Data");
		PIStyleSaveData thisPIStyleSaveData = thisStyleSaveData.PIStyleSaveDatas[0];
		NativeListItem<int> CustomOutfitsItem = new NativeListItem<int>("Outfits", "Select a Custom Outfit.");
		CustomOutfitsItem.Clear();
		for (int num = 1; num < 21; num++)
		{
			if (File.Exists($"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{num}.xml"))
			{
				CustomOutfitsItem.Add(num);
			}
		}
		CustomOutfitsItem.Activated += (object sender, EventArgs e) =>
		{
			if (File.Exists($"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{CustomOutfitsItem.SelectedItem}.xml"))
			{
				MPCustomOutfits mPCustomOutfits = XMLSerializer.DeserializeXML<MPCustomOutfits>($"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{CustomOutfitsItem.SelectedItem}.xml");
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 3, mPCustomOutfits.CustomOutfits[0].BodyType, mPCustomOutfits.CustomOutfits[0].BodyTypeVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 4, mPCustomOutfits.CustomOutfits[0].Pants, mPCustomOutfits.CustomOutfits[0].PantsVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 5, mPCustomOutfits.CustomOutfits[0].BAP, mPCustomOutfits.CustomOutfits[0].BAPVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 6, mPCustomOutfits.CustomOutfits[0].Shoes, mPCustomOutfits.CustomOutfits[0].ShoesVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 7, mPCustomOutfits.CustomOutfits[0].Accs, mPCustomOutfits.CustomOutfits[0].AccsVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 8, mPCustomOutfits.CustomOutfits[0].US, mPCustomOutfits.CustomOutfits[0].USVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 9, mPCustomOutfits.CustomOutfits[0].BA, mPCustomOutfits.CustomOutfits[0].BAVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 10, mPCustomOutfits.CustomOutfits[0].Decals, mPCustomOutfits.CustomOutfits[0].DecalsVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 11, mPCustomOutfits.CustomOutfits[0].Tops, mPCustomOutfits.CustomOutfits[0].TopsVar, 2);
				if (mPCustomOutfits.CustomOutfits[0].Hats != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 0, mPCustomOutfits.CustomOutfits[0].Hats, mPCustomOutfits.CustomOutfits[0].HatsVar, true);
				}
				else
				{
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0);
				}
				if (mPCustomOutfits.CustomOutfits[0].Glasses != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 1, mPCustomOutfits.CustomOutfits[0].Glasses, mPCustomOutfits.CustomOutfits[0].GlassesVar, true);
				}
				else
				{
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 1);
				}
				if (mPCustomOutfits.CustomOutfits[0].EarAccs != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 2, mPCustomOutfits.CustomOutfits[0].EarAccs, mPCustomOutfits.CustomOutfits[0].EarAccsVar, true);
				}
				else
				{
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 2);
				}
				if (mPCustomOutfits.CustomOutfits[0].Watches != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 6, mPCustomOutfits.CustomOutfits[0].Watches, mPCustomOutfits.CustomOutfits[0].WatchesVar, true);
				}
				else
				{
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 6);
				}
				if (mPCustomOutfits.CustomOutfits[0].Bracelets != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 7, mPCustomOutfits.CustomOutfits[0].Bracelets, mPCustomOutfits.CustomOutfits[0].BraceletsVar, true);
				}
				else
				{
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 7);
				}
				PedOutfit.GET_OUTFIT(Game.Player.Character);
				for (int i = 0; i < PedOutfit.OutfitPart.Length; i++)
				{
					CruelMastersOnlineOffline.Config.SetValue("Character", $"Outfit {i}", PedOutfit.OutfitPart[i]);
					CruelMastersOnlineOffline.Config.Save();
					CruelMastersOnlineOffline.Config.SetValue("Character", $"Outfit Variation {i}", PedOutfit.OutfitPart2[i]);
					CruelMastersOnlineOffline.Config.Save();
				}
				for (int i = 0; i < PedOutfit.OutfitPart3.Length; i++)
				{
					CruelMastersOnlineOffline.Config.SetValue("Character", $"Accessory {i}", PedOutfit.OutfitPart3[i]);
					CruelMastersOnlineOffline.Config.Save();
					CruelMastersOnlineOffline.Config.SetValue("Character", $"Accessory Variation {i}", PedOutfit.OutfitPart4[i]);
					CruelMastersOnlineOffline.Config.Save();
				}
			}
		};
		nativeMenu5.Add(CustomOutfitsItem);
		NativeMenu nativeMenu6 = new NativeMenu("", "Barber", "");
		MenuPool.Add(nativeMenu6);
		nativeMenu6.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu6.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem6 = new NativeSubmenuItem(nativeMenu6, nativeMenu5);
		nativeSubmenuItem6.AltTitle = "";
		nativeMenu5.Add(nativeSubmenuItem6);
		NativeMenu nativeMenu7 = new NativeMenu("", "Hairstyles", "");
		MenuPool.Add(nativeMenu7);
		nativeMenu7.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu7.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem7 = new NativeSubmenuItem(nativeMenu7, nativeMenu6);
		nativeSubmenuItem7.AltTitle = "";
		nativeMenu6.Add(nativeSubmenuItem7);
		nativeMenu7.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
			PedOutfit.MaskOFF(Game.Player.Character);
			while (CruelMastersOnlineOffline.CutsceneCam4 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam4 = World.CreateCamera(Game.Player.Character.Position, new Vector3(0f, 0f, 0f), 30f);
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam4.AttachTo(Game.Player.Character, new Vector3(0f, 1f, 0.6f));
			CruelMastersOnlineOffline.CutsceneCam4.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0.6f));
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam4;
		};
		nativeMenu7.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
			if (CruelMastersOnlineOffline.CutsceneCam4 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam4.Delete();
				CruelMastersOnlineOffline.CutsceneCam4 = null;
				World.RenderingCamera = null;
			}
		};
		NativeListItem<int> HairList = new NativeListItem<int>("Hair Style", "Change your Hair Style.");
		for (int num2 = 0; num2 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 2); num2++)
		{
			HairList.Add(num2);
		}
		HairList.SelectedIndex = PedOutfit.HairPart[0];
		nativeMenu7.Add(HairList);
		NativeListItem<int> HairCList = new NativeListItem<int>("Hair Color", "Change your Hair Color.");
		for (int num3 = 0; num3 < Function.Call<int>(Hash.GET_NUM_PED_HAIR_TINTS); num3++)
		{
			HairCList.Add(num3);
		}
		HairCList.SelectedIndex = CruelMastersOnlineOffline.MPHairColor;
		nativeMenu7.Add(HairCList);
		HairList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 2, HairList.SelectedItem, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			CruelMastersOnlineOffline.Config.SetValue("Character", "Hair", HairList.SelectedItem);
			CruelMastersOnlineOffline.Config.Save();
		};
		HairCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HAIR_TINT, Game.Player.Character, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			CruelMastersOnlineOffline.MPHairColor = HairCList.SelectedItem;
			CruelMastersOnlineOffline.Config.SetValue("Character", "Hair Color", HairCList.SelectedItem);
			CruelMastersOnlineOffline.Config.Save();
		};
		HairList.GoRight();
		HairList.GoLeft();
		HairList.Enabled = true;
		HairCList.GoRight();
		HairCList.GoLeft();
		HairCList.Enabled = true;
		NativeMenu nativeMenu8 = new NativeMenu("", "Beards", "");
		MenuPool.Add(nativeMenu8);
		nativeMenu8.MouseBehavior = MenuMouseBehavior.Movement;
		nativeMenu8.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem8 = new NativeSubmenuItem(nativeMenu8, nativeMenu6);
		nativeSubmenuItem8.AltTitle = "";
		nativeMenu6.Add(nativeSubmenuItem8);
		nativeMenu8.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
			PedOutfit.MaskOFF(Game.Player.Character);
			while (CruelMastersOnlineOffline.CutsceneCam4 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam4 = World.CreateCamera(Game.Player.Character.Position, new Vector3(0f, 0f, 0f), 30f);
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam4.AttachTo(Game.Player.Character, new Vector3(0f, 1f, 0.6f));
			CruelMastersOnlineOffline.CutsceneCam4.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0.6f));
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam4;
		};
		nativeMenu8.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
			if (CruelMastersOnlineOffline.CutsceneCam4 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam4.Delete();
				CruelMastersOnlineOffline.CutsceneCam4 = null;
				World.RenderingCamera = null;
			}
		};
		NativeListItem<int> FacialHairList = new NativeListItem<int>("Facial Hair", "Make changes to your Appearance.", -1);
		for (int num4 = 0; num4 < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 1); num4++)
		{
			FacialHairList.Add(num4);
		}
		FacialHairList.SelectedIndex = PedOutfit.OverlayPart[1] + 1;
		nativeMenu8.Add(FacialHairList);
		NativeGridPanel Opac1 = new NativeGridPanel();
		Opac1.LabelLeft = "0%";
		Opac1.LabelRight = "100%";
		Opac1.Style = GridStyle.Row;
		Opac1.X = PedOutfit.OpacityPart[1];
		FacialHairList.Panel = Opac1;
		FacialHairList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 1, FacialHairList.SelectedItem, Opac1.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, CruelMastersOnlineOffline.MPHairColor, 0);
			PedOutfit.OverlayPart[1] = FacialHairList.SelectedItem;
			CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY 1", PedOutfit.OverlayPart[1]);
		};
		Opac1.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 1, FacialHairList.SelectedItem, Opac1.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, CruelMastersOnlineOffline.MPHairColor, 0);
			PedOutfit.OpacityPart[1] = Opac1.X;
			CruelMastersOnlineOffline.SET_INI_VALUE_FLOAT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY OPACITY 1", PedOutfit.OpacityPart[1]);
		};
		FacialHairList.GoRight();
		FacialHairList.GoLeft();
		FacialHairList.Enabled = true;
		NativeMenu nativeMenu9 = new NativeMenu("", "Eyebrows", "");
		MenuPool.Add(nativeMenu9);
		nativeMenu9.MouseBehavior = MenuMouseBehavior.Movement;
		nativeMenu9.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem9 = new NativeSubmenuItem(nativeMenu9, nativeMenu6);
		nativeSubmenuItem9.AltTitle = "";
		nativeMenu6.Add(nativeSubmenuItem9);
		nativeMenu9.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
			PedOutfit.MaskOFF(Game.Player.Character);
			while (CruelMastersOnlineOffline.CutsceneCam4 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam4 = World.CreateCamera(Game.Player.Character.Position, new Vector3(0f, 0f, 0f), 30f);
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam4.AttachTo(Game.Player.Character, new Vector3(0f, 1f, 0.6f));
			CruelMastersOnlineOffline.CutsceneCam4.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0.6f));
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam4;
		};
		nativeMenu9.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
			if (CruelMastersOnlineOffline.CutsceneCam4 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam4.Delete();
				CruelMastersOnlineOffline.CutsceneCam4 = null;
				World.RenderingCamera = null;
			}
		};
		NativeListItem<int> FacialHairList2 = new NativeListItem<int>("Eyebrows", "Change your eyebrows.", -1);
		for (int num5 = 0; num5 < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 2); num5++)
		{
			FacialHairList2.Add(num5);
		}
		FacialHairList2.SelectedIndex = PedOutfit.OverlayPart[2] + 1;
		nativeMenu9.Add(FacialHairList2);
		NativeGridPanel Opac2 = new NativeGridPanel();
		Opac2.LabelLeft = "0%";
		Opac2.LabelRight = "100%";
		Opac2.Style = GridStyle.Row;
		Opac2.X = PedOutfit.OpacityPart[2];
		FacialHairList2.Panel = Opac2;
		FacialHairList2.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, FacialHairList2.SelectedItem, Opac2.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, CruelMastersOnlineOffline.MPHairColor, 0);
			PedOutfit.OverlayPart[2] = FacialHairList2.SelectedItem;
			CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY 2", PedOutfit.OverlayPart[2]);
		};
		Opac2.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, FacialHairList2.SelectedItem, Opac2.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, CruelMastersOnlineOffline.MPHairColor, 0);
			PedOutfit.OpacityPart[2] = Opac2.X;
			CruelMastersOnlineOffline.SET_INI_VALUE_FLOAT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY OPACITY 2", PedOutfit.OpacityPart[2]);
		};
		FacialHairList2.GoRight();
		FacialHairList2.GoLeft();
		FacialHairList2.Enabled = true;
		NativeMenu nativeMenu10 = new NativeMenu("", "Contacts", "");
		MenuPool.Add(nativeMenu10);
		nativeMenu10.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu10.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem10 = new NativeSubmenuItem(nativeMenu10, nativeMenu6);
		nativeSubmenuItem10.AltTitle = "";
		nativeMenu6.Add(nativeSubmenuItem10);
		nativeMenu10.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
			PedOutfit.MaskOFF(Game.Player.Character);
			while (CruelMastersOnlineOffline.CutsceneCam4 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam4 = World.CreateCamera(Game.Player.Character.Position, new Vector3(0f, 0f, 0f), 30f);
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam4.AttachTo(Game.Player.Character, new Vector3(0f, 1f, 0.6f));
			CruelMastersOnlineOffline.CutsceneCam4.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0.6f));
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam4;
		};
		nativeMenu10.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
			if (CruelMastersOnlineOffline.CutsceneCam4 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam4.Delete();
				CruelMastersOnlineOffline.CutsceneCam4 = null;
				World.RenderingCamera = null;
			}
		};
		NativeListItem<int> EyeCList = new NativeListItem<int>("Eye Color", "Change your eye color.");
		for (int num6 = 0; num6 < 33; num6++)
		{
			EyeCList.Add(num6);
		}
		EyeCList.SelectedIndex = CruelMastersOnlineOffline.MPEyeColor;
		nativeMenu10.Add(EyeCList);
		EyeCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, Game.Player.Character, EyeCList.SelectedItem);
			CruelMastersOnlineOffline.MPEyeColor = EyeCList.SelectedItem;
			CruelMastersOnlineOffline.Config.SetValue("Character", "Eye Color", CruelMastersOnlineOffline.MPEyeColor);
			CruelMastersOnlineOffline.Config.Save();
		};
		EyeCList.GoRight();
		EyeCList.GoLeft();
		EyeCList.Enabled = true;
		NativeMenu nativeMenu11 = new NativeMenu("", "Makeup", "");
		MenuPool.Add(nativeMenu11);
		nativeMenu11.MouseBehavior = MenuMouseBehavior.Movement;
		nativeMenu11.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem11 = new NativeSubmenuItem(nativeMenu11, nativeMenu6);
		nativeSubmenuItem11.AltTitle = "";
		nativeMenu6.Add(nativeSubmenuItem11);
		nativeMenu11.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character);
			PedOutfit.MaskOFF(Game.Player.Character);
			while (CruelMastersOnlineOffline.CutsceneCam4 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam4 = World.CreateCamera(Game.Player.Character.Position, new Vector3(0f, 0f, 0f), 30f);
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam4.AttachTo(Game.Player.Character, new Vector3(0f, 1f, 0.6f));
			CruelMastersOnlineOffline.CutsceneCam4.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0.6f));
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam4;
		};
		nativeMenu11.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
			if (CruelMastersOnlineOffline.CutsceneCam4 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam4.Delete();
				CruelMastersOnlineOffline.CutsceneCam4 = null;
				World.RenderingCamera = null;
			}
		};
		NativeListItem<int> EyeMList = new NativeListItem<int>("Eye Makeup", "Change your Eye Makeup.", -1);
		for (int num7 = 0; num7 < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 4); num7++)
		{
			EyeMList.Add(num7);
		}
		EyeMList.SelectedIndex = PedOutfit.OverlayPart[4] + 1;
		nativeMenu11.Add(EyeMList);
		NativeGridPanel Opac4 = new NativeGridPanel();
		Opac4.LabelLeft = "0%";
		Opac4.LabelRight = "100%";
		Opac4.Style = GridStyle.Row;
		Opac4.X = PedOutfit.OpacityPart[4];
		EyeMList.Panel = Opac4;
		EyeMList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac4.X);
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY 4", PedOutfit.OverlayPart[4]);
		};
		Opac4.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac4.X);
			PedOutfit.OpacityPart[4] = Opac4.X;
			CruelMastersOnlineOffline.SET_INI_VALUE_FLOAT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY OPACITY 4", PedOutfit.OpacityPart[4]);
		};
		EyeMList.GoRight();
		EyeMList.GoLeft();
		EyeMList.Enabled = true;
		NativeListItem<int> BlushList = new NativeListItem<int>("Blush", "Change your Blush.", -1);
		for (int num8 = 0; num8 < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 5); num8++)
		{
			BlushList.Add(num8);
		}
		BlushList.SelectedIndex = PedOutfit.OverlayPart[5] + 1;
		nativeMenu11.Add(BlushList);
		NativeGridPanel Opac5 = new NativeGridPanel();
		Opac5.LabelLeft = "0%";
		Opac5.LabelRight = "100%";
		Opac5.Style = GridStyle.Row;
		Opac5.X = PedOutfit.OpacityPart[5];
		BlushList.Panel = Opac5;
		BlushList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac5.X);
			PedOutfit.OverlayPart[5] = BlushList.SelectedItem;
			CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY 5", PedOutfit.OverlayPart[5]);
		};
		Opac5.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac5.X);
			PedOutfit.OpacityPart[5] = Opac5.X;
			CruelMastersOnlineOffline.SET_INI_VALUE_FLOAT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY OPACITY 5", PedOutfit.OpacityPart[5]);
		};
		BlushList.GoRight();
		BlushList.GoLeft();
		BlushList.Enabled = true;
		NativeListItem<int> MakeupCList = new NativeListItem<int>("Makeup Color", "Change your Makeup Color.");
		for (int num9 = 0; num9 < Function.Call<int>(Hash.GET_NUM_PED_MAKEUP_TINTS); num9++)
		{
			MakeupCList.Add(num9);
		}
		MakeupCList.SelectedIndex = CruelMastersOnlineOffline.MPMakeupColor;
		nativeMenu11.Add(MakeupCList);
		MakeupCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 4, 1, MakeupCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 5, 1, MakeupCList.SelectedItem, 0);
			CruelMastersOnlineOffline.MPMakeupColor = MakeupCList.SelectedItem;
			CruelMastersOnlineOffline.Config.SetValue("Character", "Makeup Color", CruelMastersOnlineOffline.MPMakeupColor);
			CruelMastersOnlineOffline.Config.Save();
		};
		MakeupCList.GoRight();
		MakeupCList.GoLeft();
		MakeupCList.Enabled = true;
		NativeListItem<int> LipstickList = new NativeListItem<int>("Lipstick", "Change your Lipstick.", -1);
		for (int num10 = 0; num10 < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 8); num10++)
		{
			LipstickList.Add(num10);
		}
		LipstickList.SelectedIndex = PedOutfit.OverlayPart[8] + 1;
		nativeMenu11.Add(LipstickList);
		NativeGridPanel Opac8 = new NativeGridPanel();
		Opac8.LabelLeft = "0%";
		Opac8.LabelRight = "100%";
		Opac8.Style = GridStyle.Row;
		Opac8.X = PedOutfit.OpacityPart[8];
		LipstickList.Panel = Opac8;
		LipstickList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac8.X);
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY 8", PedOutfit.OverlayPart[8]);
		};
		Opac8.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac8.X);
			PedOutfit.OpacityPart[8] = Opac8.X;
			CruelMastersOnlineOffline.SET_INI_VALUE_FLOAT(CruelMastersOnlineOffline.Config, "Character", "OVERLAY OPACITY 8", PedOutfit.OpacityPart[8]);
		};
		LipstickList.GoRight();
		LipstickList.GoLeft();
		LipstickList.Enabled = true;
		NativeListItem<int> LipstickCList = new NativeListItem<int>("Lipstick Color", "Change your Lipstick Color.");
		for (int num11 = 0; num11 < Function.Call<int>(Hash.GET_NUM_PED_MAKEUP_TINTS); num11++)
		{
			LipstickCList.Add(num11);
		}
		LipstickCList.SelectedIndex = CruelMastersOnlineOffline.MPLipstickColor;
		nativeMenu11.Add(LipstickCList);
		LipstickCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 8, 1, LipstickCList.SelectedItem, 0);
			CruelMastersOnlineOffline.MPLipstickColor = LipstickCList.SelectedItem;
			CruelMastersOnlineOffline.Config.SetValue("Character", "Lipstick Color", CruelMastersOnlineOffline.MPLipstickColor);
			CruelMastersOnlineOffline.Config.Save();
		};
		LipstickCList.GoRight();
		LipstickCList.GoLeft();
		LipstickCList.Enabled = true;
		NativeListItem<string> CustomMoodItem = new NativeListItem<string>("Player Mood", "Select a Mood for your player.", "Normal", "Aiming", "Angry", "Happy", "Injured", "Stressed", "Smug", "Sulking");
		CustomMoodItem.SelectedItem = thisPIStyleSaveData.PlayerMood;
		CustomMoodItem.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			if (Game.Player.Character.Gender == Gender.Male)
			{
				switch (CustomMoodItem.SelectedItem)
				{
				case "Normal":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_normal_1");
					break;
				case "Aiming":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_aiming_1");
					break;
				case "Angry":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_angry_1");
					break;
				case "Happy":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_happy_1");
					break;
				case "Injured":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_injured_1");
					break;
				case "Stressed":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_stressed_1");
					break;
				case "Smug":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_smug_1");
					break;
				case "Sulking":
					CruelMastersOnlineOffline.LoadDict("facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_sulk_1");
					break;
				}
			}
			else
			{
				switch (CustomMoodItem.SelectedItem)
				{
				case "Normal":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_normal_1");
					break;
				case "Aiming":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_aiming_1");
					break;
				case "Angry":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_angry_1");
					break;
				case "Happy":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_happy_1");
					break;
				case "Injured":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_injured_1");
					break;
				case "Stressed":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_stressed_1");
					break;
				case "Smug":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_smug_1");
					break;
				case "Sulking":
					CruelMastersOnlineOffline.LoadDict("facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_sulk_1");
					break;
				}
			}
			thisPIStyleSaveData.PlayerMood = CustomMoodItem.SelectedItem;
			MPSaveData.SAVE_DATA(thisStyleSaveData, "Style Save Data");
		};
		nativeMenu5.Add(CustomMoodItem);
		NativeListItem<string> CustomWalkStyleItem = new NativeListItem<string>("Walk Style", "Select a Walk Style for your player.", "Normal", "Femme", "Gangster", "Posh", "Tough Guy", "Grooving");
		CustomWalkStyleItem.SelectedItem = thisPIStyleSaveData.WalkStyle;
		CustomWalkStyleItem.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			string text = "M";
			if (Game.Player.Character.Gender == Gender.Female)
			{
				text = "F";
			}
			switch (CustomWalkStyleItem.SelectedItem)
			{
			case "Normal":
				Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character, 0.25f);
				break;
			case "Femme":
				while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@FEMME@"))
				{
					Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@FEMME@");
					Script.Wait(0);
				}
				Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@FEMME@", 0.25f);
				Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@FEMME@");
				break;
			case "Gangster":
				while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@GANGSTER@NG"))
				{
					Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@GANGSTER@NG");
					Script.Wait(0);
				}
				Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@GANGSTER@NG", 1f);
				Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@GANGSTER@NG");
				break;
			case "Posh":
				while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@POSH@"))
				{
					Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@POSH@");
					Script.Wait(0);
				}
				Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@POSH@", 1f);
				Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@POSH@");
				break;
			case "Tough Guy":
				while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@TOUGH_GUY@"))
				{
					Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@TOUGH_GUY@");
					Script.Wait(0);
				}
				Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@TOUGH_GUY@", 1f);
				Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@TOUGH_GUY@");
				break;
			case "Grooving":
				while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "ANIM@MOVE_" + text + "@GROOVING@"))
				{
					Function.Call(Hash.REQUEST_ANIM_SET, "ANIM@MOVE_" + text + "@GROOVING@");
					Script.Wait(0);
				}
				Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "ANIM@MOVE_" + text + "@GROOVING@", 1f);
				Function.Call(Hash.REMOVE_ANIM_SET, "ANIM@MOVE_" + text + "@GROOVING@");
				break;
			}
			thisPIStyleSaveData.WalkStyle = CustomWalkStyleItem.SelectedItem;
			MPSaveData.SAVE_DATA(thisStyleSaveData, "Style Save Data");
		};
		nativeMenu5.Add(CustomWalkStyleItem);
		NativeItem nativeItem5 = new NativeItem("Put on Mask", "Put on your current active mask if you don't see it currently.");
		nativeItem5.Activated += (object sender, EventArgs e) =>
		{
			CruelMastersOnlineOffline.LoadDict("mp_masks@on_foot");
			Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("mp_masks@on_foot"), "put_on_mask", 2f, -4f, -1, 16, 0f, false, false, false);
			PedOutfit.MaskON(Game.Player.Character, CruelMastersOnlineOffline.MPMask, CruelMastersOnlineOffline.MPMaskVar);
		};
		nativeMenu5.Add(nativeItem5);
		NativeListItem<string> AutoBikeHelmItem = new NativeListItem<string>("Auto Show Bike Helmet", "Sets whether or not a helmet is automatically put on when using a bike.", "Off", "On");
		if (Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, Game.Player.Character, 380, true))
		{
			AutoBikeHelmItem.SelectedItem = "Off";
		}
		else
		{
			AutoBikeHelmItem.SelectedItem = "On";
		}
		AutoBikeHelmItem.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			string selectedItem = AutoBikeHelmItem.SelectedItem;
			string text = selectedItem;
			if (!(text == "Off"))
			{
				if (text == "On")
				{
					Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 380, false);
				}
			}
			else
			{
				Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 380, true);
			}
			thisPIStyleSaveData.AutoShowBikeHelm = AutoBikeHelmItem.SelectedItem;
			MPSaveData.SAVE_DATA(thisStyleSaveData, "Style Save Data");
		};
		nativeMenu5.Add(AutoBikeHelmItem);
		NativeListItem<string> AutoAirHelmItem = new NativeListItem<string>("Auto Show Aircraft Helmet", "Sets whether or not a helmet is automatically put on when using an aircraft.", "Off", "On");
		if (Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, Game.Player.Character, 381, true))
		{
			AutoAirHelmItem.SelectedItem = "Off";
		}
		else
		{
			AutoAirHelmItem.SelectedItem = "On";
		}
		AutoAirHelmItem.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			string selectedItem = AutoAirHelmItem.SelectedItem;
			string text = selectedItem;
			if (!(text == "Off"))
			{
				if (text == "On")
				{
					Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 381, false);
				}
			}
			else
			{
				Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 381, true);
			}
			thisPIStyleSaveData.AutoShowAircraftHelm = AutoAirHelmItem.SelectedItem;
			MPSaveData.SAVE_DATA(thisStyleSaveData, "Style Save Data");
		};
		nativeMenu5.Add(AutoAirHelmItem);
		NativeItem nativeItem6 = new NativeItem("Re-Edit Character", "Re-Edit your character if you made a mistake in the editing process or want to change your appearance.");
		if (!CruelMastersOnlineOffline.OnMission)
		{
			nativeItem6.Description = "Re-Edit your character if you made a mistake in the editing process or want to change your appearance.";
			nativeItem6.Enabled = true;
		}
		else
		{
			nativeItem6.Description = "You cannot Re-edit your character while on an active mission.";
			nativeItem6.Enabled = false;
		}
		nativeItem6.Activated += (object sender, EventArgs e) =>
		{
			foreach (NativeMenu item3 in MenuPool)
			{
				item3.Visible = false;
			}
			Mobile_Phone.CAN_OPEN_PHONE = false;
			CAN_OPEN_INTERACTION_MENU = false;
			MPCash.CAN_SEE_CASH = false;
			MPRank.CAN_SEE_RANK_BAR = false;
			MPPlayerList.CAN_SHOW_LIST = false;
			Script.Wait(3000);
			PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
			int num15 = Game.GameTime + 5000;
			while (Game.GameTime < num15)
			{
				Script.Wait(0);
			}
			Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
			Game.Player.Character.Heading = 93.56179f;
			Cameras.RESET_GAMEPLAY_CAM();
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
			Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
			PlayerSwitch.SWITCH_IN_PLAYER(Game.Player.Character);
			while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
			{
				LOAD_SCENES.LOAD_SCENE(405.9204f, -997.1423f, -99.00402f);
				Script.Wait(0);
			}
			GTA.UI.Screen.FadeOut(0);
			Script.Wait(2000);
			Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
			Game.Player.Character.Heading = 93.56179f;
			Cameras.RESET_GAMEPLAY_CAM();
			if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
			{
				Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
			}
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
			CruelMastersOnlineOffline.LoadDict("mp_character_creation@customise@male_a");
			CruelMastersOnlineOffline.LoadDict("mp_character_creation@customise@male_a");
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM", false, -1);
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator", false, -1);
			Script.Wait(50);
			int scaleID = CruelMastersOnlineOffline.ScaleID;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
			CruelMastersOnlineOffline.ScaleID = 0;
			int scaleID2 = CruelMastersOnlineOffline.ScaleID2;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID2);
			CruelMastersOnlineOffline.ScaleID2 = 0;
			Script.Yield();
			Script.Wait(500);
			CruelMastersOnlineOffline.ScaleID = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MUGSHOT_BOARD_01");
			Script.Wait(500);
			CruelMastersOnlineOffline.ScaleID2 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "DIGITAL_CAMERA");
			Script.Wait(500);
			while (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
			{
				Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
				Script.Wait(0);
			}
			while (!Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
			{
				Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "ID_Text", 0);
				Script.Wait(0);
			}
			Function.Call(Hash.LINK_NAMED_RENDERTARGET, Game.GenerateHash("prop_police_id_text"));
			CruelMastersOnlineOffline.RenderID = Function.Call<int>(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, "ID_Text");
			Wall_Creator.CallFunction(CruelMastersOnlineOffline.ScaleID, "SET_BOARD", CruelMastersOnlineOffline.Player_Name, MPRank.CurrentXP, "LOS SANTOS POLICE DEPT", "ONLINE - OFFLINE", "", MPRank.PlayerLevel, MPRank.PlayerLevel);
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER();
			Props.RemoveProps();
			Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel("prop_police_id_board"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
			Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel("prop_police_id_text"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
			Props.propList[1].AttachTo(Props.propList[0], new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
			Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "mugshot");
			Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
			while (CruelMastersOnlineOffline.CutsceneCam == null)
			{
				CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SPLINE_CAMERA", 0);
				Script.Wait(0);
			}
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
			CruelMastersOnlineOffline.CutsceneCam.FieldOfView = 50f;
			CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
			Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, CruelMastersOnlineOffline.LoadDict("mp_character_creation@customise@male_a"), "intro", 0.0, 0.0, 0, 0, 1148846080, 0);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "intro", CruelMastersOnlineOffline.LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
			Function.Call(Hash.PLAY_FACIAL_ANIM, Game.Player.Character, "intro_facial", CruelMastersOnlineOffline.LoadDict("mp_character_creation@customise@male_a"));
			Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
			Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
			Function.Call(Hash.SET_CAM_SPLINE_PHASE, CruelMastersOnlineOffline.CutsceneCam, 1f);
			Function.Call(Hash.SET_CAM_SPLINE_DURATION, CruelMastersOnlineOffline.CutsceneCam, 13000);
			Function.Call(Hash.ADD_CAM_SPLINE_NODE, CruelMastersOnlineOffline.CutsceneCam, 402.865f, -1003.475f, -98.36557f, 0f, 0f, 358.6678f, 1, 100, 0);
			Function.Call(Hash.ADD_CAM_SPLINE_NODE, CruelMastersOnlineOffline.CutsceneCam, 402.8563f, -999.9777f, -98.44982f, -6.103765f, 0.008221734f, 43f / 75f, 1, 100, 0);
			GTA.UI.Screen.FadeIn(1000);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lights_on", "GTAO_MUGSHOT_ROOM_SOUNDS", false);
			while (Cameras.CAM_SPLINE_PHASE(CruelMastersOnlineOffline.CutsceneCam) < 1f)
			{
				Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, CruelMastersOnlineOffline.ScaleID, 2);
				Function.Call(Hash.SET_TEXT_RENDER_ID, CruelMastersOnlineOffline.RenderID);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE, CruelMastersOnlineOffline.ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
				Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam.Delete();
			CruelMastersOnlineOffline.CutsceneCam = null;
			while (CruelMastersOnlineOffline.CutsceneCam == null)
			{
				Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, CruelMastersOnlineOffline.ScaleID, 2);
				Function.Call(Hash.SET_TEXT_RENDER_ID, CruelMastersOnlineOffline.RenderID);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE, CruelMastersOnlineOffline.ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
				Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
				CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(402.8563f, -999.9777f, -98.44982f), new Vector3(-6.103765f, 0.008221734f, 43f / 75f), 50f);
				Script.Wait(0);
			}
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
			CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
			Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, CruelMastersOnlineOffline.LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "loop", CruelMastersOnlineOffline.LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
			Function.Call(Hash.CLEAR_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character);
			Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_Happy_1", 0);
			CruelMastersOnlineOffline.Menu_Switch = 1;
			CruelMastersOnlineOffline.StorySwitch = 0;
			CruelMastersOnlineOffline.ReditingCharacter = true;
		};
		nativeMenu5.Add(nativeItem6);
		NativeMenu nativeMenu12 = new NativeMenu("", "Vehicles", "View and change Personal Vehicle options.");
		MenuPool.Add(nativeMenu12);
		nativeMenu12.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu12.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem12 = new NativeSubmenuItem(nativeMenu12, InteractionMenu);
		nativeSubmenuItem12.AltTitle = "";
		InteractionMenu.Add(2, nativeSubmenuItem12);
		NativeItem nativeItem7 = new NativeItem("Request Personal Vehicle", "Get the mechanic to deliver your currently active Personal Vehicle.");
		nativeItem7.Activated += (object sender, EventArgs e) =>
		{
			if (CruelMastersOnlineOffline.PlayerVehicle == null)
			{
				OutputArgument outputArgument = new OutputArgument();
				OutputArgument outputArgument2 = new OutputArgument();
				OutputArgument outputArgument3 = new OutputArgument();
				OutputArgument outputArgument4 = new OutputArgument();
				Vector3 param = Game.Player.Character.Position.Around(60f);
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(param.X, param.Y, param.Z, 0f, 0f, 0f, 500f, 0);
					Script.Wait(50);
				}
				int num15 = 1;
				if (func_201(param) == 1)
				{
					num15 = 9;
				}
				if (Function.Call<bool>(Hash.GET_CLOSEST_VEHICLE_NODE_WITH_HEADING, param.X, param.Y, param.Z, outputArgument, outputArgument4, num15, 1077936128, 0))
				{
					while (CruelMastersOnlineOffline.PlayerVehicle == null)
					{
						if (!File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml"))
						{
							Notification.Show("You dont own a personal vehicle.");
							break;
						}
						CruelMastersOnlineOffline.PlayerVehicle = MPVehicleLoadout.GET_VEHICLE_LOADOUT("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", new Vector3(outputArgument.GetResult<Vector3>().X - 1f, outputArgument.GetResult<Vector3>().Y, outputArgument.GetResult<Vector3>().Z), outputArgument4.GetResult<float>());
						Script.Wait(0);
					}
				}
				else
				{
					Notification.Show("Personal Vehicle Couldn't Spawn.");
				}
				if (CruelMastersOnlineOffline.PlayerVehicle != null)
				{
					while (CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip == null)
					{
						CruelMastersOnlineOffline.PlayerVehicle.AddBlip();
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleCar;
					if (CruelMastersOnlineOffline.PlayerVehicle.Model.IsBike || CruelMastersOnlineOffline.PlayerVehicle.Model.IsAmphibiousQuadBike || CruelMastersOnlineOffline.PlayerVehicle.Model.IsQuadBike)
					{
						CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleBike;
					}
					CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Color = BlipColor.White;
					CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Name = "Personal Vehicle";
					CruelMastersOnlineOffline.PlayerVehicle.RadioStation = RadioStation.RadioOff;
				}
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
			}
			else
			{
				Notification.Show("You already have your current vehicle active.");
			}
		};
		nativeMenu12.Add(nativeItem7);
		NativeItem nativeItem8 = new NativeItem("Return Personal Vehicle to Storage", "Return your Personal Vehicle to storage.");
		nativeItem8.Activated += (object sender, EventArgs e) =>
		{
			if (CruelMastersOnlineOffline.PlayerVehicle != null)
			{
				if (Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle)
				{
					Game.Player.Character.Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
					while (Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle)
					{
						Script.Wait(0);
					}
				}
				int num15 = 255;
				while (num15 > 0)
				{
					Function.Call(Hash.SET_ENTITY_ALPHA, CruelMastersOnlineOffline.PlayerVehicle, num15, true);
					num15 -= 15;
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.PlayerVehicle.Delete();
				CruelMastersOnlineOffline.PlayerVehicle = null;
			}
			else
			{
				Notification.Show("You have no vehicle currently active.");
			}
		};
		nativeMenu12.Add(nativeItem8);
		NativeListItem<string> SetPVItem = new NativeListItem<string>("Set Personal Vehicle", "Set your personal vehicle to one of your currently owned vehicles.");
		string[] files = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles");
		foreach (string fileName in files)
		{
			MPOwnedVehicles mPOwnedVehicles = XMLSerializer.DeserializeXML<MPOwnedVehicles>(fileName);
			SetPVItem.Add(mPOwnedVehicles.ownedVehicles[0].VehicleName);
		}
		SetPVItem.Activated += (object sender, EventArgs e) =>
		{
			MPVehicleLoadout mPVehicleLoadout = new MPVehicleLoadout();
			MPOwnedVehicles mPOwnedVehicles2 = new MPOwnedVehicles();
			string[] files3 = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles");
			foreach (string text in files3)
			{
				mPOwnedVehicles2 = XMLSerializer.DeserializeXML<MPOwnedVehicles>(text);
				if (mPOwnedVehicles2.ownedVehicles[0].VehicleName == SetPVItem.SelectedItem)
				{
					Vehicle vehicle = MPOwnedVehicles.GET_VEHICLE_LOADOUT(text, Game.Player.Character.Position.Around(60f), 0f);
					MPVehicleLoadout.SAVE_VEHICLE(vehicle, "scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", mPOwnedVehicles2.ownedVehicles[0].VehicleName);
					vehicle.Delete();
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show(mPOwnedVehicles2.ownedVehicles[0].VehicleName + " is now your current vehicle", blinking: true);
					}
					break;
				}
			}
		};
		nativeMenu12.Add(SetPVItem);
		NativeMenu nativeMenu13 = new NativeMenu("", "Extra Settings", "Use this for extra settings such as activating/deactivating player settings and ect.");
		MenuPool.Add(nativeMenu13);
		nativeMenu13.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu13.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem13 = new NativeSubmenuItem(nativeMenu13, InteractionMenu);
		nativeSubmenuItem13.AltTitle = "";
		InteractionMenu.Add(3, nativeSubmenuItem13);
		NativeCheckboxItem WindscreenItem = new NativeCheckboxItem("Can Fly Through Windshield", "If you want to have your ped fly through their windshield if they hit another vehicle very Fast & Hard.", Game.Player.Character.CanFlyThroughWindscreen);
		WindscreenItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Game.Player.Character.CanFlyThroughWindscreen = WindscreenItem.Checked;
		};
		nativeMenu13.Add(WindscreenItem);
		NativeMenu CompanionMenu = new NativeMenu("", "Companions", "This controls your AI Companions that you have created in the AI Creator.");
		MenuPool.Add(CompanionMenu);
		CompanionMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		CompanionMenu.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem14 = new NativeSubmenuItem(CompanionMenu, InteractionMenu);
		nativeSubmenuItem14.AltTitle = "";
		InteractionMenu.Add(4, nativeSubmenuItem14);
		int num13 = 0;
		string[] files2 = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Companions");
		foreach (string file in files2)
		{
			MPAiInfo thisaiInfo = XMLSerializer.DeserializeXML<MPAiInfo>(file);
			NativeMenu AiMenu = new NativeMenu("", thisaiInfo.ownedInfos[0].Name, "");
			MenuPool.Add(AiMenu);
			AiMenu.MouseBehavior = MenuMouseBehavior.Disabled;
			AiMenu.CloseOnInvalidClick = false;
			NativeSubmenuItem AiSubbutton = new NativeSubmenuItem(AiMenu, CompanionMenu);
			AiSubbutton.AltTitle = "";
			CompanionMenu.Add(num13, AiSubbutton);
			NativeCheckboxItem InvincibleAi = new NativeCheckboxItem("Make " + thisaiInfo.ownedInfos[0].Name + " Invincible", "Make " + thisaiInfo.ownedInfos[0].Name + " immune to dying.", check: false);
			InvincibleAi.CheckboxChanged += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[i] != null)
					{
						if (MPAiCreator.Companions[i].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[i].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							flag = true;
							break;
						}
						num15++;
					}
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					MPAiCreator.Companions[num15].IsInvincible = InvincibleAi.Checked;
				}
			};
			AiMenu.Add(InvincibleAi);
			NativeCheckboxItem WindscreenAi = new NativeCheckboxItem("Can Fly Through Windshields.", "Make " + thisaiInfo.ownedInfos[0].Name + " immune/pervious to flying out windshields.", check: false);
			WindscreenAi.CheckboxChanged += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[i] != null)
					{
						if (MPAiCreator.Companions[i].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[i].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							flag = true;
							break;
						}
						num15++;
					}
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					MPAiCreator.Companions[num15].CanFlyThroughWindscreen = WindscreenAi.Checked;
				}
			};
			AiMenu.Add(WindscreenAi);
			NativeCheckboxItem EventsAi = new NativeCheckboxItem("Make " + thisaiInfo.ownedInfos[0].Name + " Block Events", "Make " + thisaiInfo.ownedInfos[0].Name + " block permanent events. (This can be useful if you're trying to stealth and this will stop them from blowing your cover right away.)", check: false);
			EventsAi.CheckboxChanged += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[i] != null)
					{
						if (MPAiCreator.Companions[i].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[i].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							flag = true;
							break;
						}
						num15++;
					}
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					MPAiCreator.Companions[num15].BlockPermanentEvents = EventsAi.Checked;
				}
			};
			AiMenu.Add(EventsAi);
			NativeCheckboxItem AlwaysTaskAi = new NativeCheckboxItem("Make " + thisaiInfo.ownedInfos[0].Name + " Always Keep Task", "Make " + thisaiInfo.ownedInfos[0].Name + " always keep task. (This can be useful if you're trying to keep them in a certain task.)", check: false);
			AlwaysTaskAi.CheckboxChanged += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[i] != null)
					{
						if (MPAiCreator.Companions[i].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[i].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							flag = true;
							break;
						}
						num15++;
					}
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					MPAiCreator.Companions[num15].AlwaysKeepTask = AlwaysTaskAi.Checked;
				}
			};
			AiMenu.Add(AlwaysTaskAi);
			NativeCheckboxItem CanRagdollAi = new NativeCheckboxItem("Can " + thisaiInfo.ownedInfos[0].Name + " Ragdoll", "Can " + thisaiInfo.ownedInfos[0].Name + " ragdoll. (This can be useful if you're trying to keep them from falling over or getting knocked over by anything.)", check: true);
			CanRagdollAi.CheckboxChanged += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[i] != null)
					{
						if (MPAiCreator.Companions[i].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[i].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							flag = true;
							break;
						}
						num15++;
					}
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					MPAiCreator.Companions[num15].CanRagdoll = CanRagdollAi.Checked;
				}
			};
			AiMenu.Add(CanRagdollAi);
			NativeListItem<WeaponHash> PrimaryWeaponItem = new NativeListItem<WeaponHash>("Primary Weapon", "Give " + thisaiInfo.ownedInfos[0].Name + " a Primary Weapon.");
			foreach (WeaponHash enumValue in typeof(WeaponHash).GetEnumValues())
			{
				PrimaryWeaponItem.Add(enumValue);
			}
			PrimaryWeaponItem.Activated += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[i] != null)
					{
						if (MPAiCreator.Companions[i].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[i].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							flag = true;
							break;
						}
						num15++;
					}
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					Weapons.GiveWeapon(MPAiCreator.Companions[num15], PrimaryWeaponItem.SelectedItem, 10000, equipNow: true, isAmmoLoaded: true);
					Weapons.EquipNow(MPAiCreator.Companions[num15], PrimaryWeaponItem.SelectedItem, equipNow: true);
				}
			};
			AiMenu.Add(PrimaryWeaponItem);
			NativeListItem<WeaponHash> SecondaryWeaponItem = new NativeListItem<WeaponHash>("Secondary Weapon", "Give " + thisaiInfo.ownedInfos[0].Name + " a Secondary Weapon.");
			foreach (WeaponHash enumValue2 in typeof(WeaponHash).GetEnumValues())
			{
				SecondaryWeaponItem.Add(enumValue2);
			}
			SecondaryWeaponItem.Activated += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[i] != null)
					{
						if (MPAiCreator.Companions[i].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[i].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							flag = true;
							break;
						}
						num15++;
					}
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					Weapons.GiveWeapon(MPAiCreator.Companions[num15], SecondaryWeaponItem.SelectedItem, 10000, equipNow: true, isAmmoLoaded: true);
					Weapons.EquipNow(MPAiCreator.Companions[num15], SecondaryWeaponItem.SelectedItem, equipNow: true);
				}
			};
			AiMenu.Add(SecondaryWeaponItem);
			NativeItem nativeItem9 = new NativeItem("Spawn " + thisaiInfo.ownedInfos[0].Name, "Spawn your " + thisaiInfo.ownedInfos[0].Name + " into your friend group and work as a group rather than solo to do stuff.", "");
			nativeItem9.Activated += (object sender, EventArgs e) =>
			{
				bool flag = true;
				int num15 = 0;
				int num16 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[num15] != null)
					{
						if (MPAiCreator.Companions[num15].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[num15].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
						{
							Notification.Show(thisaiInfo.ownedInfos[0].Name + " is already in your group.", blinking: true);
							flag = false;
							break;
						}
						num15++;
					}
				}
				if (flag)
				{
					if (num15 < MPAiCreator.Companions.Length)
					{
						while (MPAiCreator.Companions[num15] == null)
						{
							MPAiCreator.Companions[num15] = MPAiInfo.CREATE_COMPANION(file, new Vector3(Game.Player.Character.Position.X, Game.Player.Character.Position.Y, World.GetGroundHeight(Game.Player.Character.Position)).Around(2f), 0f);
							Script.Wait(0);
						}
						MPAiCreator.Companions[num15].IsInvincible = InvincibleAi.Checked;
						MPAiCreator.Companions[num15].CanFlyThroughWindscreen = WindscreenAi.Checked;
						MPAiCreator.Companions[num15].DropsEquippedWeaponOnDeath = false;
						MPAiCreator.Companions[num15].BlockPermanentEvents = EventsAi.Checked;
						MPAiCreator.Companions[num15].AlwaysKeepTask = AlwaysTaskAi.Checked;
						MPAiCreator.Companions[num15].CanRagdoll = CanRagdollAi.Checked;
						Weapons.GiveWeapon(MPAiCreator.Companions[num15], PrimaryWeaponItem.SelectedItem, 10000, equipNow: false, isAmmoLoaded: true);
						Weapons.GiveWeapon(MPAiCreator.Companions[num15], SecondaryWeaponItem.SelectedItem, 10000, equipNow: false, isAmmoLoaded: true);
						if (MPAiCreator.Companions[num15].AttachedBlip != null)
						{
							Notification.Show("<b>" + MPAiCreator.Companions[num15].AttachedBlip.Name + "</b> Joined.");
						}
						int num17 = 0;
						while (num17 < 255)
						{
							MPAiCreator.Companions[num15].Opacity = num17;
							num17 += 15;
							Script.Wait(0);
						}
					}
					else
					{
						Notification.Show("Your group is full.", blinking: true);
					}
				}
			};
			AiMenu.Add(nativeItem9);
			NativeItem nativeItem10 = new NativeItem("Send " + thisaiInfo.ownedInfos[0].Name + " home.", "Remove " + thisaiInfo.ownedInfos[0].Name + " from the group.", "");
			nativeItem10.Activated += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[num15] != null && MPAiCreator.Companions[num15].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[num15].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
					{
						flag = true;
						break;
					}
					num15++;
				}
				if (flag)
				{
					if (MPAiCreator.Companions[num15] != null)
					{
						int num16 = 255;
						while (num16 > 0)
						{
							MPAiCreator.Companions[num15].Opacity = num16;
							num16 -= 15;
							Script.Wait(0);
						}
						if (MPAiCreator.Companions[num15].AttachedBlip != null)
						{
							Notification.Show("<b>" + MPAiCreator.Companions[num15].AttachedBlip.Name + "</b> Left.");
							MPAiCreator.Companions[num15].Delete();
						}
						MPAiCreator.Companions[num15].Delete();
						MPAiCreator.Companions[num15] = null;
					}
				}
				else
				{
					Notification.Show(thisaiInfo.ownedInfos[0].Name + " isn't in in your group at the moment.", blinking: true);
				}
			};
			AiMenu.Add(nativeItem10);
			NativeItem nativeItem11 = new NativeItem("Re-Edit " + thisaiInfo.ownedInfos[0].Name + ".", "Re-edit " + thisaiInfo.ownedInfos[0].Name + "'s Apearance and Name.", "");
			if (!CruelMastersOnlineOffline.OnMission)
			{
				nativeItem11.Description = "Re-edit " + thisaiInfo.ownedInfos[0].Name + "'s Apearance and Name.";
				nativeItem11.Enabled = true;
			}
			else
			{
				nativeItem11.Description = "You cannot Re-edit " + thisaiInfo.ownedInfos[0].Name + "'s Appearance while on an active mission.";
				nativeItem11.Enabled = false;
			}
			nativeItem11.Activated += (object sender, EventArgs e) =>
			{
				foreach (NativeMenu item4 in MenuPool)
				{
					item4.Visible = false;
				}
				Mobile_Phone.CAN_OPEN_PHONE = false;
				CAN_OPEN_INTERACTION_MENU = false;
				MPCash.CAN_SEE_CASH = false;
				MPRank.CAN_SEE_RANK_BAR = false;
				MPPlayerList.CAN_SHOW_LIST = false;
				Mobile_Phone.CAN_OPEN_PHONE = false;
				MPAiCreator.CurrentlyEditingAiName = thisaiInfo.ownedInfos[0].Name;
				MPAiCreator.ReEditingAi = true;
				Script.Wait(1000);
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				int num15 = Game.GameTime + 5000;
				while (Game.GameTime < num15)
				{
					Script.Wait(0);
				}
				Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
				Game.Player.Character.Heading = 93.56179f;
				Cameras.RESET_GAMEPLAY_CAM();
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
				Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
				PlayerSwitch.SWITCH_IN_PLAYER(Game.Player.Character);
				while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
				{
					LOAD_SCENES.LOAD_SCENE(405.9204f, -997.1423f, -99.00402f);
					Script.Wait(0);
				}
				GTA.UI.Screen.FadeOut(0);
				Script.Wait(2000);
				Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
				Game.Player.Character.Heading = 93.56179f;
				Cameras.RESET_GAMEPLAY_CAM();
				if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
				MPAiCreator.LoadDict("mp_character_creation@customise@male_a");
				MPAiCreator.LoadDict("mp_character_creation@customise@male_a");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM", false, -1);
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator", false, -1);
				Script.Wait(50);
				int scaleID = MPAiCreator.ScaleID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
				MPAiCreator.ScaleID = 0;
				int scaleID2 = MPAiCreator.ScaleID2;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID2);
				MPAiCreator.ScaleID2 = 0;
				Script.Yield();
				Script.Wait(500);
				MPAiCreator.ScaleID = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MUGSHOT_BOARD_01");
				Script.Wait(500);
				MPAiCreator.ScaleID2 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "DIGITAL_CAMERA");
				Script.Wait(500);
				while (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
					Script.Wait(0);
				}
				while (!Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "ID_Text", 0);
					Script.Wait(0);
				}
				Function.Call(Hash.LINK_NAMED_RENDERTARGET, Game.GenerateHash("prop_police_id_text"));
				MPAiCreator.RenderID = Function.Call<int>(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, "ID_Text");
				Wall_Creator.CallFunction(MPAiCreator.ScaleID, "SET_BOARD", MPAiCreator.CurrentlyEditingAiName, "", "LOS SANTOS POLICE DEPT", "ONLINE - OFFLINE", "", 1, 1);
				Game.Player.ChangeModel(MPAiCreator.RequestModel(PedHash.Michael));
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				Script.Wait(500);
				if (thisaiInfo.ownedInfos[0].Gender == 0)
				{
					Game.Player.ChangeModel(MPAiCreator.RequestModel(PedHash.FreemodeMale01));
				}
				else
				{
					Game.Player.ChangeModel(MPAiCreator.RequestModel(PedHash.FreemodeFemale01));
				}
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				MPAiInfo mPAiInfo = thisaiInfo;
				Ped character = Game.Player.Character;
				Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, character, mPAiInfo.ownedInfos[0].HeadBlendData[0], mPAiInfo.ownedInfos[0].HeadBlendData[1], 0, mPAiInfo.ownedInfos[0].HeadBlendData[2], 0, 0, 0f, 0f, 0f, false);
				for (int i = 1; i < 20; i++)
				{
					Function.Call(Hash.SET_PED_MICRO_MORPH, character, i, mPAiInfo.ownedInfos[0].FacialFeatures[i]);
				}
				for (int i = 0; i < 10; i++)
				{
					if (mPAiInfo.ownedInfos[0].Overlay[i] != -1)
					{
						Function.Call(Hash.SET_PED_HEAD_OVERLAY, character, i, mPAiInfo.ownedInfos[0].Overlay[i], mPAiInfo.ownedInfos[0].OverlayOpac[i]);
					}
					if (i != 4 || i != 5 || i != 8)
					{
						Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, character, i, 1, mPAiInfo.ownedInfos[0].HairColor, 0);
					}
				}
				Function.Call(Hash.SET_PED_HAIR_TINT, character, mPAiInfo.ownedInfos[0].HairColor, 0);
				Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, character, mPAiInfo.ownedInfos[0].EyeColor);
				Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, character, 4, 1, mPAiInfo.ownedInfos[0].MakeupColor, 0);
				Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, character, 5, 1, mPAiInfo.ownedInfos[0].MakeupColor, 0);
				Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, character, 8, 1, mPAiInfo.ownedInfos[0].LipstickColor, 0);
				MPCustomOutfits outfit = mPAiInfo.ownedInfos[0].Outfit;
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 1, mPAiInfo.ownedInfos[0].Mask[0], mPAiInfo.ownedInfos[0].Mask[1], 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 2, mPAiInfo.ownedInfos[0].Hair, 0, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 3, outfit.CustomOutfits[0].BodyType, outfit.CustomOutfits[0].BodyTypeVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 4, outfit.CustomOutfits[0].Pants, outfit.CustomOutfits[0].PantsVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 5, outfit.CustomOutfits[0].BAP, outfit.CustomOutfits[0].BAPVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 6, outfit.CustomOutfits[0].Shoes, outfit.CustomOutfits[0].ShoesVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 7, outfit.CustomOutfits[0].Accs, outfit.CustomOutfits[0].AccsVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 8, outfit.CustomOutfits[0].US, outfit.CustomOutfits[0].USVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 9, outfit.CustomOutfits[0].BA, outfit.CustomOutfits[0].BAVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 10, outfit.CustomOutfits[0].Decals, outfit.CustomOutfits[0].DecalsVar, 2);
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, character, 11, outfit.CustomOutfits[0].Tops, outfit.CustomOutfits[0].TopsVar, 2);
				if (outfit.CustomOutfits[0].Hats != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, character, 0, outfit.CustomOutfits[0].Hats, outfit.CustomOutfits[0].HatsVar, true);
				}
				if (outfit.CustomOutfits[0].Glasses != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, character, 1, outfit.CustomOutfits[0].Glasses, outfit.CustomOutfits[0].GlassesVar, true);
				}
				if (outfit.CustomOutfits[0].EarAccs != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, character, 2, outfit.CustomOutfits[0].EarAccs, outfit.CustomOutfits[0].EarAccsVar, true);
				}
				if (outfit.CustomOutfits[0].Watches != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, character, 6, outfit.CustomOutfits[0].Watches, outfit.CustomOutfits[0].WatchesVar, true);
				}
				if (outfit.CustomOutfits[0].Bracelets != -1)
				{
					Function.Call(Hash.SET_PED_PROP_INDEX, character, 7, outfit.CustomOutfits[0].Bracelets, outfit.CustomOutfits[0].BraceletsVar, true);
				}
				Props.RemoveProps();
				Props.SPAWN_PROP_NO_OFFSET(MPAiCreator.RequestModel("prop_police_id_board"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(MPAiCreator.RequestModel("prop_police_id_text"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
				Props.propList[1].AttachTo(Props.propList[0], new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
				Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "mugshot");
				Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
				while (CruelMastersOnlineOffline.CutsceneCam == null)
				{
					CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SPLINE_CAMERA", 0);
					Script.Wait(0);
				}
				World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
				CruelMastersOnlineOffline.CutsceneCam.FieldOfView = 50f;
				MPAiCreator.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, MPAiCreator.TestCutsceneAnim, MPAiCreator.LoadDict("mp_character_creation@customise@male_a"), "intro", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, MPAiCreator.TestCutsceneAnim, "intro", MPAiCreator.LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_FACIAL_ANIM, Game.Player.Character, "intro_facial", MPAiCreator.LoadDict("mp_character_creation@customise@male_a"));
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
				Function.Call(Hash.SET_CAM_SPLINE_PHASE, CruelMastersOnlineOffline.CutsceneCam, 1f);
				Function.Call(Hash.SET_CAM_SPLINE_DURATION, CruelMastersOnlineOffline.CutsceneCam, 13000);
				Function.Call(Hash.ADD_CAM_SPLINE_NODE, CruelMastersOnlineOffline.CutsceneCam, 402.865f, -1003.475f, -98.36557f, 0f, 0f, 358.6678f, 1, 100, 0);
				Function.Call(Hash.ADD_CAM_SPLINE_NODE, CruelMastersOnlineOffline.CutsceneCam, 402.8563f, -999.9777f, -98.44982f, -6.103765f, 0.008221734f, 43f / 75f, 1, 100, 0);
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lights_on", "GTAO_MUGSHOT_ROOM_SOUNDS", false);
				while (Cameras.CAM_SPLINE_PHASE(CruelMastersOnlineOffline.CutsceneCam) < 1f)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, MPAiCreator.ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, MPAiCreator.RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, MPAiCreator.ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneCam.Delete();
				CruelMastersOnlineOffline.CutsceneCam = null;
				while (CruelMastersOnlineOffline.CutsceneCam == null)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, MPAiCreator.ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, MPAiCreator.RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, MPAiCreator.ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(402.8563f, -999.9777f, -98.44982f), new Vector3(-6.103765f, 0.008221734f, 43f / 75f), 50f);
					Script.Wait(0);
				}
				World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
				MPAiCreator.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, MPAiCreator.TestCutsceneAnim, MPAiCreator.LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, MPAiCreator.TestCutsceneAnim, "loop", MPAiCreator.LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.CLEAR_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character);
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_Happy_1", 0);
				MPAiCreator.Menu_Switch = 1;
			};
			AiMenu.Add(nativeItem11);
			NativeItem nativeItem12 = new NativeItem("Ban " + thisaiInfo.ownedInfos[0].Name + ".", "Ban " + thisaiInfo.ownedInfos[0].Name + " from GTA Online-Offline. (WARNING: This will delete this companion make sure you are certain before clicking.)", "");
			nativeItem12.Activated += (object sender, EventArgs e) =>
			{
				bool flag = false;
				int num15 = 0;
				for (int i = 0; i < MPAiCreator.Companions.Length; i++)
				{
					if (MPAiCreator.Companions[num15] != null && MPAiCreator.Companions[num15].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[num15].AttachedBlip.Name, thisaiInfo.ownedInfos[0].Name))
					{
						flag = true;
						break;
					}
					num15++;
				}
				if (flag && MPAiCreator.Companions[num15] != null)
				{
					int num16 = 255;
					while (num16 > 0)
					{
						MPAiCreator.Companions[num15].Opacity = num16;
						num16 -= 15;
						Script.Wait(0);
					}
					if (MPAiCreator.Companions[num15].AttachedBlip != null)
					{
						Notification.Show("<b>" + MPAiCreator.Companions[num15].AttachedBlip.Name + "</b> Left.");
						MPAiCreator.Companions[num15].Delete();
					}
					MPAiCreator.Companions[num15].Delete();
					MPAiCreator.Companions[num15] = null;
				}
				if (File.Exists(file))
				{
					File.Delete(file);
					AiMenu.Visible = false;
					if (CompanionMenu.Contains(AiSubbutton))
					{
						CompanionMenu.Remove(AiSubbutton);
					}
					Notification.Show(thisaiInfo.ownedInfos[0].Name + " has been banned from GTA Online-Offline.", blinking: true);
				}
			};
			AiMenu.Add(nativeItem12);
			num13++;
		}
		NativeMenu nativeMenu14 = new NativeMenu("", "Cleaner", "This menu is for cleaning up things in case something breaks.");
		MenuPool.Add(nativeMenu14);
		nativeMenu14.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu14.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem15 = new NativeSubmenuItem(nativeMenu14, InteractionMenu);
		nativeSubmenuItem15.AltTitle = "";
		InteractionMenu.Add(5, nativeSubmenuItem15);
		NativeItem nativeItem13 = new NativeItem("Fix Big Map", "If the radar is stuck in Big Mode than use this to fix it.");
		nativeItem13.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_BIGMAP_ACTIVE, false, false);
			Function.Call(Hash.DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS, false);
			MPBigMap.Timer = 0;
			MPBigMap.Timer2 = 0;
			MPBigMap.UseSwitch = 0;
		};
		nativeMenu14.Add(nativeItem13);
		NativeItem nativeItem14 = new NativeItem("Kill Yourself", "Commit suicide if you want to get out of a situation.", "$500");
		nativeItem14.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(500))
			{
				CruelMastersOnlineOffline.LoadDict("mp_suicide");
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 2))
				{
				case 0:
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					Weapons.Anim_Weapon_Off();
					int num16 = Game.GameTime + 3500;
					InteractionMenu.Visible = !InteractionMenu.Visible;
					Game.Player.Character.Task.PlayAnimation("mp_suicide", "pill", 8f, 8f, -1, AnimationFlags.None, -1000f);
					while (Game.GameTime < num16)
					{
						Script.Wait(0);
					}
					Game.Player.Character.HealthFloat = 0f;
					Mobile_Phone.CAN_OPEN_PHONE = true;
					break;
				}
				case 1:
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					int num15 = Game.GameTime + 800;
					InteractionMenu.Visible = !InteractionMenu.Visible;
					Game.Player.Character.Weapons.Give(WeaponHash.Pistol, 10000, equipNow: true, isAmmoLoaded: true);
					Game.Player.Character.Weapons.Select(WeaponHash.Pistol);
					Game.Player.Character.Task.PlayAnimation("mp_suicide", "pistol", 8f, 8f, -1, AnimationFlags.None, -1000f);
					while (Game.GameTime < num15)
					{
						Script.Wait(0);
					}
					Function.Call(Hash.SET_PED_SHOOTS_AT_COORD, Game.Player.Character, 0f, 0f, 0f, true);
					Game.Player.Character.HealthFloat = 0f;
					Function.Call(Hash.SET_PED_SHOOTS_AT_COORD, Game.Player.Character, 0f, 0f, 0f, false);
					Mobile_Phone.CAN_OPEN_PHONE = true;
					break;
				}
				}
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enoguh Money.");
			}
		};
		InteractionMenu.Add(6, nativeItem14);
	}

	public unsafe void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (MenuPool != null && MenuPool.AreAnyVisible)
		{
			MenuPool.Process();
		}
		Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 244, 1);
		if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "pi_menu"))
		{
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "pi_menu");
		}
		if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "am_pi_menu"))
		{
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "am_pi_menu");
		}
		if (!MenuPool.AreAnyVisible)
		{
			if (ScaleID != 0)
			{
				int scaleID = ScaleID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
				ScaleID = 0;
				Mobile_Phone.CAN_OPEN_PHONE = true;
				MPRank.CAN_SEE_RANK_BAR = true;
				MPCash.CAN_SEE_CASH = true;
				MPPlayerList.CAN_SHOW_LIST = true;
				PI_MENU_IS_OPEN = false;
			}
			if (Function.Call<bool>(Hash.IS_USING_KEYBOARD_AND_MOUSE, 0, 2))
			{
				if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, 0, 244) && CAN_OPEN_INTERACTION_MENU && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL)
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPCash.CAN_SEE_CASH = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					int scaleID2 = ScaleID;
					Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID2);
					ScaleID = 0;
					Script.Yield();
					int num = Game.GameTime + 50;
					while (Game.GameTime < num)
					{
						Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 244, 1);
						Script.Wait(0);
					}
					ScaleID = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MP_MENU_GLARE");
					num = Game.GameTime + 50;
					while (Game.GameTime < num)
					{
						Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 244, 1);
						Script.Wait(0);
					}
					Wall_Creator.CallFunction(ScaleID, "SET_DATA_SLOT", 0f);
					SETUP_INTERACTION_MENU();
					InteractionMenu.Visible = !InteractionMenu.Visible;
					PI_MENU_IS_OPEN = true;
				}
			}
			else if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, 244))
			{
				if (CAN_OPEN_INTERACTION_MENU && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL)
				{
					if (ButtonHoldTimer == 0)
					{
						ButtonHoldTimer = Game.GameTime + 200;
					}
					else if (Game.GameTime > ButtonHoldTimer)
					{
						Mobile_Phone.CAN_OPEN_PHONE = false;
						MPRank.CAN_SEE_RANK_BAR = false;
						MPCash.CAN_SEE_CASH = false;
						MPPlayerList.CAN_SHOW_LIST = false;
						int scaleID3 = ScaleID;
						Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID3);
						ScaleID = 0;
						int num2 = Game.GameTime + 1;
						while (Game.GameTime < num2)
						{
							Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 244, 1);
							Script.Wait(0);
						}
						num2 = Game.GameTime + 50;
						while (Game.GameTime < num2)
						{
							Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 244, 1);
							Script.Wait(0);
						}
						ScaleID = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MP_MENU_GLARE");
						num2 = Game.GameTime + 50;
						while (Game.GameTime < num2)
						{
							Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 244, 1);
							Script.Wait(0);
						}
						Wall_Creator.CallFunction(ScaleID, "SET_DATA_SLOT", 0f);
						SETUP_INTERACTION_MENU();
						InteractionMenu.Visible = !InteractionMenu.Visible;
						PI_MENU_IS_OPEN = true;
						ButtonHoldTimer = 0;
					}
				}
				else if (ButtonHoldTimer != 0)
				{
					ButtonHoldTimer = 0;
				}
			}
			else if (ButtonHoldTimer != 0)
			{
				ButtonHoldTimer = 0;
			}
		}
		else if (ScaleID != 0)
		{
			Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.465f + InteractionMenu.Offset.X, 0.509f + InteractionMenu.Offset.Y, 1f, 1.1f, 255, 255, 255, 255, 0);
		}
	}

	public unsafe void onShutdown(object sender, EventArgs e)
	{
		if (ScaleID != 0)
		{
			int scaleID = ScaleID;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
			ScaleID = 0;
		}
	}

	public static int func_201(Vector3 Param0)
	{
		string text = Function.Call<string>(Hash.GET_NAME_OF_ZONE, Param0.X, Param0.Y, Param0.Z);
		if (Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "SanAnd", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Alamo", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "ArmyB", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "BhamCa", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Baytre", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "BradT", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "BradP", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "CANNY", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "CCreak", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "ChamH", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "CHU", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "COSI", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "CMSW", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Cypre", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Desrt", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "ELGorl", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Galli", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Galfish", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Harmo", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "HumLab", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Jail", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "LAct", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "LDam", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Lago", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "MTChil", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "MTJose", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "MTGordo", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "NCHU", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Oceana", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Palmpow", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "PBluff", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Paleto", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "PalCov", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "PalFor", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "PalHigh", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "RTRAK", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Rancho", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "SANDY", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "TongvaH", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "TongvaV", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Zenora", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Slab", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "WindF", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "Zancudo", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "SanChia", text) || Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, "zQ_UAR", text))
		{
			return 1;
		}
		return 0;
	}

	public static int func_213(Vector3 mainpos)
	{
		OutputArgument outputArgument = new OutputArgument();
		OutputArgument outputArgument2 = new OutputArgument();
		int num = 1;
		if (func_201(mainpos) == 1)
		{
			num = 9;
		}
		int num2 = Function.Call<int>(Hash.GET_NTH_CLOSEST_VEHICLE_NODE_ID, mainpos.X, mainpos.Y, mainpos.Z, 1, num, 3f, 0f);
		if (Function.Call<bool>(Hash.IS_VEHICLE_NODE_ID_VALID, num2))
		{
			Function.Call(Hash.GET_VEHICLE_NODE_POSITION, num2, outputArgument);
			if (Function.Call<bool>(Hash.GET_POSITION_BY_SIDE_OF_ROAD, outputArgument.GetResult<Vector3>().X, outputArgument.GetResult<Vector3>().Y, outputArgument.GetResult<Vector3>().Z, 0, outputArgument2))
			{
				return 1;
			}
		}
		return 0;
	}

	public static int func_214(Vector3 mainpos, float heading)
	{
		OutputArgument outputArgument = new OutputArgument();
		OutputArgument outputArgument2 = new OutputArgument();
		OutputArgument outputArgument3 = new OutputArgument();
		OutputArgument outputArgument4 = new OutputArgument();
		int num = 1;
		if (func_201(mainpos) == 1)
		{
			num = 9;
		}
		int num2 = 0;
		if (Function.Call<bool>(Hash.IS_VEHICLE_NODE_ID_VALID, num2))
		{
			mainpos = new Vector3(mainpos.X + 1f, mainpos.Y, mainpos.Z);
			heading = outputArgument4.GetResult<float>();
			return 1;
		}
		return 0;
	}

	public static bool PI_MENU_OPEN()
	{
		return PI_MENU_IS_OPEN;
	}
}
