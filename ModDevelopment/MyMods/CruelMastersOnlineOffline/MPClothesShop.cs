using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Elements;
using LemonUI.Menus;

namespace CruelMastersOnlineOffline;

internal class MPClothesShop : Script
{
	public static ObjectPool MenuPool = new ObjectPool();

	public static NativeMenu ClothesStore;

	public static NativeMenu OutfitSlotMenu;

	private Prop[] clothesdoors;

	private Vector3[] WardrobeLoc = new Vector3[14]
	{
		new Vector3(429.819f, -811.5965f, 29.49115f),
		new Vector3(-819.7283f, -1067.114f, 11.32811f),
		new Vector3(71.22221f, -1387.537f, 29.37612f),
		new Vector3(1698.792f, 4817.916f, 42.06308f),
		new Vector3(-1100.211f, 2717.28f, 19.10786f),
		new Vector3(1202.092f, 2714.439f, 38.2226f),
		new Vector3(3.696442f, 6505.664f, 31.87785f),
		new Vector3(-703.5948f, -151.1863f, 37.41514f),
		new Vector3(-168.8468f, -299.4049f, 39.73328f),
		new Vector3(-1446.721f, -242.8166f, 49.82283f),
		new Vector3(-1180.754f, -764.0011f, 17.32656f),
		new Vector3(617.3639f, 2775.424f, 42.08814f),
		new Vector3(117.8534f, -233.8787f, 54.55787f),
		new Vector3(-3179.253f, 1034.151f, 20.86321f)
	};

	private float[] WardrobeHed = new float[14]
	{
		359.434f, 124.8824f, 179.664f, 7.316666f, 132.0794f, 90.4635f, 311.7396f, 165.6825f, 298.7864f, 93.27608f,
		123.2028f, 184.7107f, 339.4309f, 336.246f
	};

	public MPClothesShop()
	{
		Tick += onTick;
		Aborted += onShutdown;
		ClothesStore = new NativeMenu("", "SELECT AN OPTION");
		ScaledTexture banner = new ScaledTexture(ClothesStore.Banner.Position, new SizeF(ClothesStore.Banner.Size.Width, ClothesStore.Banner.Size.Height), "shopui_title_lowendfashion", "shopui_title_lowendfashion");
		ClothesStore.Banner = banner;
		ClothesStore.MouseBehavior = MenuMouseBehavior.Disabled;
		ClothesStore.HeldTime = 100;
		ClothesStore.CloseOnInvalidClick = false;
		MenuPool.Add(ClothesStore);
		OutfitSlotMenu = new NativeMenu("", "Puchase Custom Outfit", "");
		OutfitSlotMenu.Banner = banner;
		OutfitSlotMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		OutfitSlotMenu.HeldTime = 100;
		OutfitSlotMenu.CloseOnInvalidClick = false;
		MenuPool.Add(OutfitSlotMenu);
	}

	public static void SETUP_WARDROBE_MENU()
	{
		OutfitInfo[] array = new OutfitInfo[0];
		ClothesStore.Clear();
		ScaledTexture banner = new ScaledTexture(ClothesStore.Banner.Position, new SizeF(ClothesStore.Banner.Size.Width, ClothesStore.Banner.Size.Height), "shopui_title_lowendfashion", "shopui_title_lowendfashion");
		NativeMenu nativeMenu = new NativeMenu("", "Body Type", "Browse for a Body Type.");
		MenuPool.Add(nativeMenu);
		nativeMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu.CloseOnInvalidClick = false;
		nativeMenu.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem = new NativeSubmenuItem(nativeMenu, ClothesStore);
		nativeSubmenuItem.AltTitle = "";
		ClothesStore.Add(0, nativeSubmenuItem);
		nativeMenu.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.1f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> TorsoCompItem = new NativeListItem<int>("Component", "Select a Component.");
		TorsoCompItem.Clear();
		int iVar0;
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 3); iVar0++)
		{
			TorsoCompItem.Add(iVar0 + 1, iVar0);
		}
		TorsoCompItem.GoRight();
		TorsoCompItem.GoLeft();
		TorsoCompItem.Enabled = true;
		nativeMenu.Add(TorsoCompItem);
		NativeListItem<int> TorsoCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		TorsoCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 3, 0); iVar0++)
		{
			TorsoCompVarItem.Add(iVar0, iVar0);
		}
		TorsoCompVarItem.GoRight();
		TorsoCompVarItem.GoLeft();
		TorsoCompVarItem.Enabled = true;
		nativeMenu.Add(TorsoCompVarItem);
		TorsoCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			TorsoCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 3, TorsoCompItem.SelectedItem); iVar0++)
			{
				TorsoCompVarItem.Add(iVar0, iVar0);
			}
			TorsoCompVarItem.GoRight();
			TorsoCompVarItem.GoLeft();
			TorsoCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 3, TorsoCompItem.SelectedItem, 0, 2);
		};
		TorsoCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 3, TorsoCompItem.SelectedItem, TorsoCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu2 = new NativeMenu("", "Pants", "Browse for some Pants.");
		MenuPool.Add(nativeMenu2);
		nativeMenu2.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu2.CloseOnInvalidClick = false;
		nativeMenu2.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem2 = new NativeSubmenuItem(nativeMenu2, ClothesStore);
		nativeSubmenuItem2.AltTitle = "";
		ClothesStore.Add(1, nativeSubmenuItem2);
		nativeMenu2.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, -0.2f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -0.4f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 40f);
		};
		nativeMenu2.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> PantsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		PantsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 4); iVar0++)
		{
			PantsCompItem.Add(iVar0 + 1, iVar0);
		}
		PantsCompItem.GoRight();
		PantsCompItem.GoLeft();
		PantsCompItem.Enabled = true;
		nativeMenu2.Add(PantsCompItem);
		NativeListItem<int> PantsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		PantsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 4, 0); iVar0++)
		{
			PantsCompVarItem.Add(iVar0, iVar0);
		}
		PantsCompVarItem.GoRight();
		PantsCompVarItem.GoLeft();
		PantsCompVarItem.Enabled = true;
		nativeMenu2.Add(PantsCompVarItem);
		PantsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			PantsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 4, PantsCompItem.SelectedItem); iVar0++)
			{
				PantsCompVarItem.Add(iVar0, iVar0);
			}
			PantsCompVarItem.GoRight();
			PantsCompVarItem.GoLeft();
			PantsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 4, PantsCompItem.SelectedItem, 0, 2);
		};
		PantsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 4, PantsCompItem.SelectedItem, PantsCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu3 = new NativeMenu("", "Bags and Parachutes", "Browse for some Bags and Parachutes.");
		MenuPool.Add(nativeMenu3);
		nativeMenu3.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu3.CloseOnInvalidClick = false;
		nativeMenu3.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem3 = new NativeSubmenuItem(nativeMenu3, ClothesStore);
		nativeSubmenuItem3.AltTitle = "";
		ClothesStore.Add(2, nativeSubmenuItem3);
		nativeMenu3.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.5f, -0.6f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 50f);
		};
		nativeMenu3.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> BAPCompItem = new NativeListItem<int>("Component", "Select a Component.");
		BAPCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 5); iVar0++)
		{
			BAPCompItem.Add(iVar0 + 1, iVar0);
		}
		BAPCompItem.GoRight();
		BAPCompItem.GoLeft();
		BAPCompItem.Enabled = true;
		nativeMenu3.Add(BAPCompItem);
		NativeListItem<int> BAPCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		BAPCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 5, 0); iVar0++)
		{
			BAPCompVarItem.Add(iVar0, iVar0);
		}
		BAPCompVarItem.GoRight();
		BAPCompVarItem.GoLeft();
		BAPCompVarItem.Enabled = true;
		nativeMenu3.Add(BAPCompVarItem);
		BAPCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			BAPCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 5, BAPCompItem.SelectedItem); iVar0++)
			{
				BAPCompVarItem.Add(iVar0, iVar0);
			}
			BAPCompVarItem.GoRight();
			BAPCompVarItem.GoLeft();
			BAPCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 5, BAPCompItem.SelectedItem, 0, 2);
		};
		BAPCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 5, BAPCompItem.SelectedItem, BAPCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu4 = new NativeMenu("", "Shoes", "Browse for some Shoes.");
		MenuPool.Add(nativeMenu4);
		nativeMenu4.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu4.CloseOnInvalidClick = false;
		nativeMenu4.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem4 = new NativeSubmenuItem(nativeMenu4, ClothesStore);
		nativeSubmenuItem4.AltTitle = "";
		ClothesStore.Add(3, nativeSubmenuItem4);
		nativeMenu4.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.2f, 0.9f, -0.8f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -1f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 40f);
		};
		nativeMenu4.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> ShoeCompItem = new NativeListItem<int>("Component", "Select a Component.");
		ShoeCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 6); iVar0++)
		{
			ShoeCompItem.Add(iVar0 + 1, iVar0);
		}
		ShoeCompItem.GoRight();
		ShoeCompItem.GoLeft();
		ShoeCompItem.Enabled = true;
		nativeMenu4.Add(ShoeCompItem);
		NativeListItem<int> ShoeCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		ShoeCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 6, 0); iVar0++)
		{
			ShoeCompVarItem.Add(iVar0, iVar0);
		}
		ShoeCompVarItem.GoRight();
		ShoeCompVarItem.GoLeft();
		ShoeCompVarItem.Enabled = true;
		nativeMenu4.Add(ShoeCompVarItem);
		ShoeCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			ShoeCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 6, ShoeCompItem.SelectedItem); iVar0++)
			{
				ShoeCompVarItem.Add(iVar0, iVar0);
			}
			ShoeCompVarItem.GoRight();
			ShoeCompVarItem.GoLeft();
			ShoeCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 6, ShoeCompItem.SelectedItem, 0, 2);
		};
		ShoeCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 6, ShoeCompItem.SelectedItem, ShoeCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu5 = new NativeMenu("", "Accessories", "Browse for some Accessories.");
		MenuPool.Add(nativeMenu5);
		nativeMenu5.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu5.CloseOnInvalidClick = false;
		nativeMenu5.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem5 = new NativeSubmenuItem(nativeMenu5, ClothesStore);
		nativeSubmenuItem5.AltTitle = "";
		ClothesStore.Add(4, nativeSubmenuItem5);
		nativeMenu5.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 2f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu5.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> AccsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		AccsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 7); iVar0++)
		{
			AccsCompItem.Add(iVar0 + 1, iVar0);
		}
		AccsCompItem.GoRight();
		AccsCompItem.GoLeft();
		AccsCompItem.Enabled = true;
		nativeMenu5.Add(AccsCompItem);
		NativeListItem<int> AccsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		AccsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 7, 0); iVar0++)
		{
			AccsCompVarItem.Add(iVar0, iVar0);
		}
		AccsCompVarItem.GoRight();
		AccsCompVarItem.GoLeft();
		AccsCompVarItem.Enabled = true;
		nativeMenu5.Add(AccsCompVarItem);
		AccsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			AccsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 7, AccsCompItem.SelectedItem); iVar0++)
			{
				AccsCompVarItem.Add(iVar0, iVar0);
			}
			AccsCompVarItem.GoRight();
			AccsCompVarItem.GoLeft();
			AccsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 7, AccsCompItem.SelectedItem, 0, 2);
		};
		AccsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 7, AccsCompItem.SelectedItem, AccsCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu6 = new NativeMenu("", "Undershirts", "Browse for some Undershirts.");
		MenuPool.Add(nativeMenu6);
		nativeMenu6.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu6.CloseOnInvalidClick = false;
		nativeMenu6.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem6 = new NativeSubmenuItem(nativeMenu6, ClothesStore);
		nativeSubmenuItem6.AltTitle = "";
		ClothesStore.Add(5, nativeSubmenuItem6);
		nativeMenu6.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu6.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> USCompItem = new NativeListItem<int>("Component", "Select a Component.");
		USCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 8); iVar0++)
		{
			USCompItem.Add(iVar0 + 1, iVar0);
		}
		USCompItem.GoRight();
		USCompItem.GoLeft();
		USCompItem.Enabled = true;
		nativeMenu6.Add(USCompItem);
		NativeListItem<int> USCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		USCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 8, 0); iVar0++)
		{
			USCompVarItem.Add(iVar0, iVar0);
		}
		USCompVarItem.GoRight();
		USCompVarItem.GoLeft();
		USCompVarItem.Enabled = true;
		nativeMenu6.Add(USCompVarItem);
		USCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			USCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 8, USCompItem.SelectedItem); iVar0++)
			{
				USCompVarItem.Add(iVar0, iVar0);
			}
			USCompVarItem.GoRight();
			USCompVarItem.GoLeft();
			USCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 8, USCompItem.SelectedItem, 0, 2);
		};
		USCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 8, USCompItem.SelectedItem, USCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu7 = new NativeMenu("", "Body Armors", "Browse for some Body Armors.");
		MenuPool.Add(nativeMenu7);
		nativeMenu7.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu7.CloseOnInvalidClick = false;
		nativeMenu7.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem7 = new NativeSubmenuItem(nativeMenu7, ClothesStore);
		nativeSubmenuItem7.AltTitle = "";
		ClothesStore.Add(6, nativeSubmenuItem7);
		nativeMenu7.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu7.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> BACompItem = new NativeListItem<int>("Component", "Select a Component.");
		BACompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 9); iVar0++)
		{
			BACompItem.Add(iVar0 + 1, iVar0);
		}
		BACompItem.GoRight();
		BACompItem.GoLeft();
		BACompItem.Enabled = true;
		nativeMenu7.Add(BACompItem);
		NativeListItem<int> BACompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		BACompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 9, 0); iVar0++)
		{
			BACompVarItem.Add(iVar0, iVar0);
		}
		BACompVarItem.GoRight();
		BACompVarItem.GoLeft();
		BACompVarItem.Enabled = true;
		nativeMenu7.Add(BACompVarItem);
		BACompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			BACompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 9, BACompItem.SelectedItem); iVar0++)
			{
				BACompVarItem.Add(iVar0, iVar0);
			}
			BACompVarItem.GoRight();
			BACompVarItem.GoLeft();
			BACompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 9, BACompItem.SelectedItem, 0, 2);
		};
		BACompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 9, BACompItem.SelectedItem, BACompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu8 = new NativeMenu("", "Decals", "Browse for some Decals.");
		MenuPool.Add(nativeMenu8);
		nativeMenu8.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu8.CloseOnInvalidClick = false;
		nativeMenu8.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem8 = new NativeSubmenuItem(nativeMenu8, ClothesStore);
		nativeSubmenuItem8.AltTitle = "";
		ClothesStore.Add(7, nativeSubmenuItem8);
		NativeListItem<int> DecalCompItem = new NativeListItem<int>("Component", "Select a Component.");
		DecalCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 10); iVar0++)
		{
			DecalCompItem.Add(iVar0 + 1, iVar0);
		}
		DecalCompItem.GoRight();
		DecalCompItem.GoLeft();
		DecalCompItem.Enabled = true;
		nativeMenu8.Add(DecalCompItem);
		NativeListItem<int> DecalCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		DecalCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 10, 0); iVar0++)
		{
			DecalCompVarItem.Add(iVar0, iVar0);
		}
		DecalCompVarItem.GoRight();
		DecalCompVarItem.GoLeft();
		DecalCompVarItem.Enabled = true;
		nativeMenu8.Add(DecalCompVarItem);
		DecalCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			DecalCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 10, DecalCompItem.SelectedItem); iVar0++)
			{
				DecalCompVarItem.Add(iVar0, iVar0);
			}
			DecalCompVarItem.GoRight();
			DecalCompVarItem.GoLeft();
			DecalCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 10, DecalCompItem.SelectedItem, 0, 2);
		};
		DecalCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 10, DecalCompItem.SelectedItem, DecalCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu9 = new NativeMenu("", "Tops", "Browse for some Tops.");
		MenuPool.Add(nativeMenu9);
		nativeMenu9.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu9.CloseOnInvalidClick = false;
		nativeMenu9.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem9 = new NativeSubmenuItem(nativeMenu9, ClothesStore);
		nativeSubmenuItem9.AltTitle = "";
		ClothesStore.Add(8, nativeSubmenuItem9);
		nativeMenu9.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu9.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> TopsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		TopsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 11); iVar0++)
		{
			TopsCompItem.Add(iVar0 + 1, iVar0);
		}
		TopsCompItem.GoRight();
		TopsCompItem.GoLeft();
		TopsCompItem.Enabled = true;
		nativeMenu9.Add(TopsCompItem);
		NativeListItem<int> TopsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		TopsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 11, 0); iVar0++)
		{
			TopsCompVarItem.Add(iVar0, iVar0);
		}
		TopsCompVarItem.GoRight();
		TopsCompVarItem.GoLeft();
		TopsCompVarItem.Enabled = true;
		nativeMenu9.Add(TopsCompVarItem);
		TopsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			TopsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 11, TopsCompItem.SelectedItem); iVar0++)
			{
				TopsCompVarItem.Add(iVar0, iVar0);
			}
			TopsCompVarItem.GoRight();
			TopsCompVarItem.GoLeft();
			TopsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 11, TopsCompItem.SelectedItem, 0, 2);
		};
		TopsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 11, TopsCompItem.SelectedItem, TopsCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu10 = new NativeMenu("", "Hats", "Browse for some Hats.");
		MenuPool.Add(nativeMenu10);
		nativeMenu10.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu10.CloseOnInvalidClick = false;
		nativeMenu10.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem10 = new NativeSubmenuItem(nativeMenu10, ClothesStore);
		nativeSubmenuItem10.AltTitle = "";
		ClothesStore.Add(9, nativeSubmenuItem10);
		nativeMenu10.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.2f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu10.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> HatsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		HatsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 0); iVar0++)
		{
			HatsCompItem.Add(iVar0 + 1, iVar0);
		}
		HatsCompItem.GoRight();
		HatsCompItem.GoLeft();
		HatsCompItem.Enabled = true;
		nativeMenu10.Add(HatsCompItem);
		NativeListItem<int> HatsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		HatsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 0, 0); iVar0++)
		{
			HatsCompVarItem.Add(iVar0, iVar0);
		}
		HatsCompVarItem.GoRight();
		HatsCompVarItem.GoLeft();
		HatsCompVarItem.Enabled = true;
		nativeMenu10.Add(HatsCompVarItem);
		HatsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			HatsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 0, HatsCompItem.SelectedItem); iVar0++)
			{
				HatsCompVarItem.Add(iVar0, iVar0);
			}
			HatsCompVarItem.GoRight();
			HatsCompVarItem.GoLeft();
			HatsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 0, HatsCompItem.SelectedItem, 0, true);
			if (HatsCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
			}
		};
		HatsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 0, HatsCompItem.SelectedItem, HatsCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu11 = new NativeMenu("", "Glasses", "Browse for some Glasses.");
		MenuPool.Add(nativeMenu11);
		nativeMenu11.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu11.CloseOnInvalidClick = false;
		nativeMenu11.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem11 = new NativeSubmenuItem(nativeMenu11, ClothesStore);
		nativeSubmenuItem11.AltTitle = "";
		ClothesStore.Add(10, nativeSubmenuItem11);
		nativeMenu11.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.2f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu11.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> GlassesCompItem = new NativeListItem<int>("Component", "Select a Component.");
		GlassesCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 1); iVar0++)
		{
			GlassesCompItem.Add(iVar0 + 1, iVar0);
		}
		GlassesCompItem.GoRight();
		GlassesCompItem.GoLeft();
		GlassesCompItem.Enabled = true;
		nativeMenu11.Add(GlassesCompItem);
		NativeListItem<int> GlassesCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		GlassesCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 1, 0); iVar0++)
		{
			GlassesCompVarItem.Add(iVar0, iVar0);
		}
		GlassesCompVarItem.GoRight();
		GlassesCompVarItem.GoLeft();
		GlassesCompVarItem.Enabled = true;
		nativeMenu11.Add(GlassesCompVarItem);
		GlassesCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			GlassesCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 1, GlassesCompItem.SelectedItem); iVar0++)
			{
				GlassesCompVarItem.Add(iVar0, iVar0);
			}
			GlassesCompVarItem.GoRight();
			GlassesCompVarItem.GoLeft();
			GlassesCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 1, GlassesCompItem.SelectedItem, 1, true);
			if (GlassesCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 1, 0);
			}
		};
		GlassesCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 1, GlassesCompItem.SelectedItem, GlassesCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu12 = new NativeMenu("", "Ear Accessories", "Browse for some Ear Accessories.");
		MenuPool.Add(nativeMenu12);
		nativeMenu12.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu12.CloseOnInvalidClick = false;
		nativeMenu12.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem12 = new NativeSubmenuItem(nativeMenu12, ClothesStore);
		nativeSubmenuItem12.AltTitle = "";
		ClothesStore.Add(11, nativeSubmenuItem12);
		nativeMenu12.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.5f, 0.3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu12.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeItem nativeItem = new NativeItem("View Left Side", "Switch View of Camera to see a different Point of View.");
		nativeItem.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.5f, 0.3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu12.Add(nativeItem);
		NativeItem nativeItem2 = new NativeItem("View Right Side", "Switch View of Camera to see a different Point of View.");
		nativeItem2.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.5f, 0.3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu12.Add(nativeItem2);
		NativeListItem<int> EarAccsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		EarAccsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 2); iVar0++)
		{
			EarAccsCompItem.Add(iVar0 + 1, iVar0);
		}
		EarAccsCompItem.GoRight();
		EarAccsCompItem.GoLeft();
		EarAccsCompItem.Enabled = true;
		nativeMenu12.Add(EarAccsCompItem);
		NativeListItem<int> EarAccsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		EarAccsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 2, 0); iVar0++)
		{
			EarAccsCompVarItem.Add(iVar0, iVar0);
		}
		EarAccsCompVarItem.GoRight();
		EarAccsCompVarItem.GoLeft();
		EarAccsCompVarItem.Enabled = true;
		nativeMenu12.Add(EarAccsCompVarItem);
		EarAccsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			EarAccsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 2, EarAccsCompItem.SelectedItem); iVar0++)
			{
				EarAccsCompVarItem.Add(iVar0, iVar0);
			}
			EarAccsCompVarItem.GoRight();
			EarAccsCompVarItem.GoLeft();
			EarAccsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 2, EarAccsCompItem.SelectedItem, 1, true);
			if (EarAccsCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 2, 0);
			}
		};
		EarAccsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 2, EarAccsCompItem.SelectedItem, EarAccsCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu13 = new NativeMenu("", "Watches", "Browse for some Watches.");
		MenuPool.Add(nativeMenu13);
		nativeMenu13.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu13.CloseOnInvalidClick = false;
		nativeMenu13.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem13 = new NativeSubmenuItem(nativeMenu13, ClothesStore);
		nativeSubmenuItem13.AltTitle = "";
		ClothesStore.Add(12, nativeSubmenuItem13);
		nativeMenu13.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.7f, 0.2f, -0.05f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -0.05f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 45f);
		};
		nativeMenu13.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> WatchesCompItem = new NativeListItem<int>("Component", "Select a Component.");
		WatchesCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 6); iVar0++)
		{
			WatchesCompItem.Add(iVar0 + 1, iVar0);
		}
		WatchesCompItem.GoRight();
		WatchesCompItem.GoLeft();
		WatchesCompItem.Enabled = true;
		nativeMenu13.Add(WatchesCompItem);
		NativeListItem<int> WatchesCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		WatchesCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 6, 0); iVar0++)
		{
			WatchesCompVarItem.Add(iVar0, iVar0);
		}
		WatchesCompVarItem.GoRight();
		WatchesCompVarItem.GoLeft();
		WatchesCompVarItem.Enabled = true;
		nativeMenu13.Add(WatchesCompVarItem);
		WatchesCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			WatchesCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 6, WatchesCompItem.SelectedItem); iVar0++)
			{
				WatchesCompVarItem.Add(iVar0, iVar0);
			}
			WatchesCompVarItem.GoRight();
			WatchesCompVarItem.GoLeft();
			WatchesCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 6, WatchesCompItem.SelectedItem, 1, true);
			if (WatchesCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 6, 0);
			}
		};
		WatchesCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 6, WatchesCompItem.SelectedItem, WatchesCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu14 = new NativeMenu("", "Bracelets", "Browse for some Bracelets.");
		MenuPool.Add(nativeMenu14);
		nativeMenu14.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu14.CloseOnInvalidClick = false;
		nativeMenu14.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem14 = new NativeSubmenuItem(nativeMenu14, ClothesStore);
		nativeSubmenuItem14.AltTitle = "";
		ClothesStore.Add(13, nativeSubmenuItem14);
		nativeMenu14.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.7f, 0.2f, -0.05f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -0.05f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 45f);
		};
		nativeMenu14.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> BraceletsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		BraceletsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 7); iVar0++)
		{
			BraceletsCompItem.Add(iVar0 + 1, iVar0);
		}
		BraceletsCompItem.GoRight();
		BraceletsCompItem.GoLeft();
		BraceletsCompItem.Enabled = true;
		nativeMenu14.Add(BraceletsCompItem);
		NativeListItem<int> BraceletsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		BraceletsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 7, 0); iVar0++)
		{
			BraceletsCompVarItem.Add(iVar0, iVar0);
		}
		BraceletsCompVarItem.GoRight();
		BraceletsCompVarItem.GoLeft();
		BraceletsCompVarItem.Enabled = true;
		nativeMenu14.Add(BraceletsCompVarItem);
		BraceletsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			BraceletsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 7, BraceletsCompItem.SelectedItem); iVar0++)
			{
				BraceletsCompVarItem.Add(iVar0, iVar0);
			}
			BraceletsCompVarItem.GoRight();
			BraceletsCompVarItem.GoLeft();
			BraceletsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 7, BraceletsCompItem.SelectedItem, 1, true);
			if (BraceletsCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 7, 0);
			}
		};
		BraceletsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 7, BraceletsCompItem.SelectedItem, BraceletsCompVarItem.SelectedItem, true);
		};
		NativeSubmenuItem nativeSubmenuItem15 = new NativeSubmenuItem(OutfitSlotMenu, ClothesStore);
		nativeSubmenuItem15.AltTitle = "$20000";
		ClothesStore.Add(14, nativeSubmenuItem15);
		OutfitSlotMenu.ItemCount = CountVisibility.Always;
		OutfitSlotMenu.Clear();
		for (int num = 1; num < 21; num++)
		{
			SETUP_OUTFIT_SLOT(num);
		}
	}

	public static void SETUP_OUTFIT_SLOT(int i)
	{
		NativeItem CustomOutfitSlot1 = new NativeItem("Empty Slot", "Select a Slot.", "");
		if (File.Exists($"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{i}.xml"))
		{
			CustomOutfitSlot1.Title = "Overwrite Slot";
		}
		else
		{
			CustomOutfitSlot1.Title = "Empty Slot";
		}
		CustomOutfitSlot1.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(20000))
			{
				if (File.Exists($"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{i}.xml"))
				{
					XMLSerializer.DeserializeXML<MPCustomOutfits>($"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{i}.xml").CustomOutfits.Clear();
					MPCustomOutfits mPCustomOutfits = new MPCustomOutfits();
					OutfitInfo item = new OutfitInfo
					{
						BodyType = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 3),
						BodyTypeVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 3),
						Pants = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 4),
						PantsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 4),
						BAP = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 5),
						BAPVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 5),
						Shoes = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 6),
						ShoesVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 6),
						Accs = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 7),
						AccsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 7),
						US = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 8),
						USVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 8),
						BA = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 9),
						BAVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 9),
						Decals = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 10),
						DecalsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 10),
						Tops = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 11),
						TopsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 11),
						Hats = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 0),
						HatsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 0),
						Glasses = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 1),
						GlassesVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 1),
						EarAccs = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 2),
						EarAccsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 2),
						Watches = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 6),
						WatchesVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 6),
						Bracelets = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 7),
						BraceletsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 7)
					};
					mPCustomOutfits.CustomOutfits.Add(item);
					XMLSerializer.SaveToXML(mPCustomOutfits, $"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{i}.xml");
					PedOutfit.GET_OUTFIT(Game.Player.Character);
					for (int j = 0; j < PedOutfit.OutfitPart.Length; j++)
					{
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Outfit {j}", PedOutfit.OutfitPart[j]);
						CruelMastersOnlineOffline.Config.Save();
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Outfit Variation {j}", PedOutfit.OutfitPart2[j]);
						CruelMastersOnlineOffline.Config.Save();
					}
					for (int j = 0; j < PedOutfit.OutfitPart3.Length; j++)
					{
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Accessory {j}", PedOutfit.OutfitPart3[j]);
						CruelMastersOnlineOffline.Config.Save();
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Accessory Variation {j}", PedOutfit.OutfitPart4[j]);
						CruelMastersOnlineOffline.Config.Save();
					}
				}
				else
				{
					MPCustomOutfits mPCustomOutfits2 = new MPCustomOutfits();
					OutfitInfo item2 = new OutfitInfo
					{
						BodyType = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 3),
						BodyTypeVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 3),
						Pants = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 4),
						PantsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 4),
						BAP = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 5),
						BAPVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 5),
						Shoes = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 6),
						ShoesVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 6),
						Accs = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 7),
						AccsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 7),
						US = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 8),
						USVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 8),
						BA = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 9),
						BAVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 9),
						Decals = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 10),
						DecalsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 10),
						Tops = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 11),
						TopsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 11),
						Hats = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 0),
						HatsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 0),
						Glasses = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 1),
						GlassesVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 1),
						EarAccs = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 2),
						EarAccsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 2),
						Watches = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 6),
						WatchesVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 6),
						Bracelets = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 7),
						BraceletsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 7)
					};
					mPCustomOutfits2.CustomOutfits.Add(item2);
					XMLSerializer.SaveToXML(mPCustomOutfits2, $"scripts\\CruelMastersOnlineOfflineAssets\\Outfits\\CustomOutfit{i}.xml");
					PedOutfit.GET_OUTFIT(Game.Player.Character);
					for (int k = 0; k < PedOutfit.OutfitPart.Length; k++)
					{
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Outfit {k}", PedOutfit.OutfitPart[k]);
						CruelMastersOnlineOffline.Config.Save();
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Outfit Variation {k}", PedOutfit.OutfitPart2[k]);
						CruelMastersOnlineOffline.Config.Save();
					}
					for (int k = 0; k < PedOutfit.OutfitPart3.Length; k++)
					{
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Accessory {k}", PedOutfit.OutfitPart3[k]);
						CruelMastersOnlineOffline.Config.Save();
						CruelMastersOnlineOffline.Config.SetValue("Character", $"Accessory Variation {k}", PedOutfit.OutfitPart4[k]);
						CruelMastersOnlineOffline.Config.Save();
					}
					CustomOutfitSlot1.Title = "Overwrite Slot";
				}
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		OutfitSlotMenu.Add(i - 1, CustomOutfitSlot1);
	}

	public static void SETUP_OUTFIT_STORE_MENU()
	{
		ClothesStore.Clear();
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (MenuPool != null && MenuPool.AreAnyVisible)
		{
			MenuPool.Process();
		}
		for (int i = 0; i < WardrobeLoc.Length; i++)
		{
			if (Game.Player.Character.Position.DistanceTo(WardrobeLoc[i]) < 30f && !CruelMastersOnlineOffline.OnMission)
			{
				clothesdoors = World.GetAllProps(-1922281023, 1780022985, 868499217, -1148826190);
				Prop[] array = clothesdoors;
				foreach (Prop prop in array)
				{
					if (prop != null)
					{
						while (prop.IsPositionFrozen)
						{
							prop.IsPositionFrozen = false;
							Script.Wait(0);
						}
					}
				}
			}
			if (!(Game.Player.Character.Position.DistanceTo(WardrobeLoc[i]) < 2f) || CruelMastersOnlineOffline.OnMission)
			{
				continue;
			}
			GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to browse outfits.");
			if (Game.IsControlJustPressed(Control.Context) && !MenuPool.AreAnyVisible)
			{
				Mobile_Phone.CAN_OPEN_PHONE = false;
				MPRank.CAN_SEE_RANK_BAR = false;
				MPCash.CAN_SEE_CASH = false;
				MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
				MPPlayerList.CAN_SHOW_LIST = false;
				SETUP_WARDROBE_MENU();
				Game.Player.Character.Position = new Vector3(WardrobeLoc[i].X, WardrobeLoc[i].Y, WardrobeLoc[i].Z - 1f);
				Game.Player.Character.Heading = WardrobeHed[i];
				Cameras.RESET_GAMEPLAY_CAM();
				Game.Player.CanControlCharacter = false;
				while (CruelMastersOnlineOffline.CutsceneCam == null)
				{
					CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneCam.MotionBlurStrength = 1f;
				Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 4f, 0.3f, true);
				Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0f, true);
				Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
				World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
				CruelMastersOnlineOffline.LoadDict("clothingtie");
				Game.Player.Character.Task.PlayAnimation(CruelMastersOnlineOffline.LoadDict("clothingtie"), "try_tie_base", 1000f, -8f, -1, AnimationFlags.Loop, 0.1f);
				ClothesStore.Visible = !ClothesStore.Visible;
			}
			if (!MenuPool.AreAnyVisible && CruelMastersOnlineOffline.CutsceneCam != null)
			{
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.CanControlCharacter = true;
				CruelMastersOnlineOffline.CutsceneCam.Delete();
				CruelMastersOnlineOffline.CutsceneCam = null;
				World.RenderingCamera = null;
				Game.Player.Character.Task.PlayAnimation(CruelMastersOnlineOffline.LoadDict("clothingtie"), "outro", 1000f, -8f, -1, AnimationFlags.AbortOnPedMovement, 0.1f);
				Mobile_Phone.CAN_OPEN_PHONE = true;
				MPRank.CAN_SEE_RANK_BAR = true;
				MPCash.CAN_SEE_CASH = true;
				MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
				MPPlayerList.CAN_SHOW_LIST = true;
				MenuPool.HideAll();
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}

	public static void SET_CAM_NORMAL()
	{
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 4f, 0.3f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
	}
}
