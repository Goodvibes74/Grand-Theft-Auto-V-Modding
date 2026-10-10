using System;
using System.Drawing;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Elements;
using LemonUI.Menus;

namespace CruelMastersOnlineOffline;

internal class MPMaskShop : Script
{
	public static ObjectPool MenuPool = new ObjectPool();

	public static NativeMenu MaskShop;

	public MPMaskShop()
	{
		Tick += onTick;
		Aborted += onShutdown;
		MaskShop = new NativeMenu("", "MASKS");
		ScaledTexture banner = new ScaledTexture(MaskShop.Banner.Position, new SizeF(MaskShop.Banner.Size.Width, MaskShop.Banner.Size.Height), "shopui_title_movie_masks", "shopui_title_movie_masks");
		MaskShop.Banner = banner;
		MaskShop.MouseBehavior = MenuMouseBehavior.Disabled;
		MaskShop.HeldTime = 100;
		MaskShop.CloseOnInvalidClick = false;
		MenuPool.Add(MaskShop);
	}

	public static void SETUP_MASK_SHOP()
	{
		MaskShop.Clear();
		NativeListItem<int> MasksCompItem = new NativeListItem<int>("Mask", "Select a Mask.");
		int iVar0;
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 1); iVar0++)
		{
			MasksCompItem.Add(iVar0, iVar0);
		}
		MasksCompItem.GoRight();
		MasksCompItem.GoLeft();
		MasksCompItem.Enabled = true;
		MasksCompItem.SelectedIndex = CruelMastersOnlineOffline.MPMask;
		MaskShop.Add(0, MasksCompItem);
		NativeListItem<int> MasksCompVarItem = new NativeListItem<int>("Mask Variation", "Select a Variation for your current Mask.");
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 1, MasksCompItem.SelectedIndex); iVar0++)
		{
			MasksCompVarItem.Add(iVar0, iVar0);
		}
		MasksCompVarItem.GoRight();
		MasksCompVarItem.GoLeft();
		MasksCompVarItem.Enabled = true;
		MasksCompVarItem.SelectedIndex = CruelMastersOnlineOffline.MPMaskVar;
		MaskShop.Add(1, MasksCompVarItem);
		NativeItem PurchaseMask = new NativeItem("Take Off Mask", "", "FREE");
		MaskShop.Add(2, PurchaseMask);
		MasksCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			MasksCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 1, MasksCompItem.SelectedItem); iVar0++)
			{
				MasksCompVarItem.Add(iVar0, iVar0);
			}
			MasksCompVarItem.GoRight();
			MasksCompVarItem.GoLeft();
			MasksCompVarItem.Enabled = true;
			if (MasksCompItem.SelectedItem == 0)
			{
				PedOutfit.MaskOFF(Game.Player.Character);
				PurchaseMask.Title = "Take Off Mask";
				PurchaseMask.AltTitle = "FREE";
			}
			else
			{
				PedOutfit.MaskON(Game.Player.Character, MasksCompItem.SelectedItem, MasksCompVarItem.SelectedItem);
				PurchaseMask.Title = "Purchase Mask";
				PurchaseMask.AltTitle = "$500";
			}
		};
		MasksCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			if (MasksCompItem.SelectedItem == 0)
			{
				PedOutfit.MaskOFF(Game.Player.Character);
				PurchaseMask.Title = "Take Off Mask";
				PurchaseMask.AltTitle = "FREE";
			}
			else
			{
				PedOutfit.MaskON(Game.Player.Character, MasksCompItem.SelectedItem, MasksCompVarItem.SelectedItem);
				PurchaseMask.Title = "Purchase Mask";
				PurchaseMask.AltTitle = "$500";
			}
		};
		PurchaseMask.Activated += (object sender, EventArgs e) =>
		{
			if (MasksCompItem.SelectedItem != 0)
			{
				if (MPCash.PROCESS_TRANSACTION(500) || CruelMastersOnlineOffline.DEBUG)
				{
					CruelMastersOnlineOffline.MPMask = MasksCompItem.SelectedItem;
					CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "Mask", CruelMastersOnlineOffline.MPMask);
					CruelMastersOnlineOffline.MPMaskVar = MasksCompVarItem.SelectedItem;
					CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "Mask Variation", CruelMastersOnlineOffline.MPMaskVar);
					Notification.Show("Mask Bought.", blinking: true);
					MaskShop.Visible = !MaskShop.Visible;
				}
				else
				{
					Notification.Show("Transaction Failed: Not Enough Money.", blinking: true);
				}
			}
			else
			{
				CruelMastersOnlineOffline.MPMask = 0;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "Mask", CruelMastersOnlineOffline.MPMask);
				CruelMastersOnlineOffline.MPMaskVar = 0;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Character", "Mask Variation", CruelMastersOnlineOffline.MPMaskVar);
			}
		};
	}

	public static void SETUP_MASK_SHOP_CASINO()
	{
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "clothes_shop_mp"))
		{
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "clothes_shop_mp");
		}
		if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "clothes_shop_sp"))
		{
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "clothes_shop_sp");
		}
		if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "shop_controller"))
		{
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "shop_controller");
		}
		if (MenuPool != null && MenuPool.AreAnyVisible)
		{
			MenuPool.Process();
		}
		if (Game.Player.Character.Position.DistanceTo(new Vector3(-1333.959f, -1277.02f, 4.96355f)) < 5f && !CruelMastersOnlineOffline.OnMission)
		{
			GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to browse masks.");
			if (Game.IsControlJustPressed(Control.Context) && !MenuPool.AreAnyVisible)
			{
				Mobile_Phone.CAN_OPEN_PHONE = false;
				MPRank.CAN_SEE_RANK_BAR = false;
				MPCash.CAN_SEE_CASH = false;
				MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
				MPPlayerList.CAN_SHOW_LIST = false;
				SETUP_MASK_SHOP();
				Game.Player.Character.Position = new Vector3(-1337.01f, -1279.718f, 3.8490248f);
				Game.Player.Character.Heading = 316.96f;
				Cameras.RESET_GAMEPLAY_CAM();
				Game.Player.CanControlCharacter = false;
				while (CruelMastersOnlineOffline.CutsceneCam == null)
				{
					CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneCam.MotionBlurStrength = 1f;
				Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.2f, 1f, 0.6f, true);
				Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
				Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
				World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
				MaskShop.Visible = !MaskShop.Visible;
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
		if (!MenuPool.AreAnyVisible)
		{
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}

	public static void SET_MASK_SHOP_BLIP_COLOR(BlipColor color)
	{
		Blip[] allBlips = World.GetAllBlips(BlipSprite.Masks);
		Blip[] array = allBlips;
		foreach (Blip blip in array)
		{
			if (blip != null)
			{
				blip.Color = color;
			}
		}
	}
}
