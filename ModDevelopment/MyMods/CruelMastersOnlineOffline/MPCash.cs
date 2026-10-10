using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPCash : Script
{
	private enum SCRIPT_HUD_COMPONENTS
	{
		HUD_UNK_0,
		HUD_UNK_1,
		HUD_UNK_2,
		HUD_DRUG_PARCEL,
		HUD_CASH_PARCEL,
		HUD_UNK_5,
		HUD_UNK_6,
		HUD_UNK_7,
		HUD_UNK_8,
		HUD_UNK_9,
		HUD_UNK_10,
		HUD_UNK_11,
		HUD_UNK_12,
		HUD_CASH_PARCEL_2,
		HUD_CASH_PARCEL_3,
		HUD_CASH_PARCEL_4,
		HUD_CASH_PARCEL_5,
		HUD_CASH_PARCEL_6,
		HUD_RADAR_RIGHT_ICON,
		HUD_RANK_BAR,
		HUD_DIRECTOR_MODE,
		HUD_CASH,
		HUD_CHIPS
	}

	public static bool CAN_SEE_CASH = true;

	public static string MovieName => "HUD_CASH";

	public static int AddedCash { get; set; } = 0;

	public static int PreviousCash { get; set; } = 5000;

	public static int Cash { get; set; } = 5000;

	public static int AddedBank { get; set; } = 0;

	public static int PreviousBank { get; set; } = 20000;

	public static int Bank { get; set; } = 20000;

	public static int HudComponent { get; set; } = 21;

	public MPCash()
	{
		Tick += onTick;
		Aborted += onShutdown;
		KeyDown += onKeyDown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (CruelMastersOnlineOffline.DEBUG)
		{
			if (Game.IsControlJustPressed(GTA.Control.Context))
			{
			}
			if (!Game.IsControlJustPressed(GTA.Control.VehicleDuck))
			{
			}
		}
		if (Game.IsControlJustPressed(GTA.Control.MultiplayerInfo) && CAN_SEE_CASH && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL)
		{
			Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, 21);
			Function.Call(Hash.REQUEST_SCALEFORM_SCRIPT_HUD_MOVIE, 21);
			Script.Wait(0);
			CallHudFunction(21, "SET_PLAYER_MP_CASH_WITH_STRING", $"~g~${Cash}~w~ \n ~HC_GREENLIGHT~${Bank}~HUD_COLOUR_WHITE~");
			CallHudFunction(21, "SHOW", false);
			int num = Game.GameTime + 5000;
			while (Game.GameTime < num)
			{
				Function.Call(Hash.SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME, 21);
				Script.Wait(0);
			}
			CallHudFunction(21, "HIDE");
			num = Game.GameTime + 500;
			while (Game.GameTime < num)
			{
				Function.Call(Hash.SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME, 21);
				Script.Wait(0);
			}
			Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, 21);
		}
		else if (PreviousCash != Cash || (PreviousBank != Bank && CAN_SEE_CASH && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL))
		{
			Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, 21);
			Function.Call(Hash.REQUEST_SCALEFORM_SCRIPT_HUD_MOVIE, 21);
			Script.Wait(0);
			if (PreviousCash > Cash)
			{
				CallHudFunction(21, "SET_PLAYER_CASH_CHANGE", AddedCash, false);
				PreviousCash = Cash;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Previous Cash", PreviousCash);
				AddedCash = 0;
			}
			else if (PreviousCash < Cash)
			{
				CallHudFunction(21, "SET_PLAYER_CASH_CHANGE", AddedCash, true);
				PreviousCash = Cash;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Previous Cash", PreviousCash);
				AddedCash = 0;
			}
			if (PreviousBank > Bank)
			{
				CallHudFunction(21, "SET_PLAYER_CASH_CHANGE", AddedBank, false);
				PreviousBank = Bank;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Previous Bank", PreviousBank);
				AddedBank = 0;
			}
			else if (PreviousBank < Bank)
			{
				CallHudFunction(21, "SET_PLAYER_CASH_CHANGE", AddedBank, true);
				PreviousBank = Bank;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Previous Bank", PreviousBank);
				AddedBank = 0;
			}
			CallHudFunction(21, "SHOW", false);
			int num2 = Game.GameTime + 1000;
			while (Game.GameTime < num2)
			{
				Function.Call(Hash.SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME, 21);
				Script.Wait(0);
			}
			CallHudFunction(21, "HIDE");
			num2 = Game.GameTime + 500;
			while (Game.GameTime < num2)
			{
				Function.Call(Hash.SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME, 21);
				Script.Wait(0);
			}
			Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, 21);
		}
		if (Cash < 0)
		{
			SET_CASH(0);
		}
		if (Bank < 0)
		{
			SET_BANK(0);
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			if (Function.Call<bool>(Hash.HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED, 21))
			{
				Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, 21);
			}
			if (Function.Call<bool>(Hash.HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED, 22))
			{
				Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, 22);
			}
		}
	}

	public void onKeyDown(object sender, KeyEventArgs e)
	{
	}

	public static bool PROCESS_TRANSACTION(int cash)
	{
		if (Bank >= cash)
		{
			REMOVE_BANK(cash);
			return true;
		}
		if (Cash >= cash)
		{
			REMOVE_CASH(cash);
			return true;
		}
		if (Bank + Cash >= cash)
		{
			REMOVE_CASH(cash);
			REMOVE_BANK(cash);
			return true;
		}
		return false;
	}

	public static void SET_CASH(int cash)
	{
		Cash = cash;
		AddedCash = cash;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Cash", Cash);
	}

	public static void ADD_CASH(int cash)
	{
		Cash += cash;
		AddedCash = cash;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Cash", Cash);
	}

	public static void REMOVE_CASH(int cash)
	{
		Cash -= cash;
		AddedCash = cash;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Cash", Cash);
	}

	public static void SET_BANK(int cash)
	{
		Bank = cash;
		AddedBank = cash;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Bank", Bank);
	}

	public static void ADD_BANK(int cash)
	{
		Bank += cash;
		AddedBank = cash;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Bank", Bank);
	}

	public static void REMOVE_BANK(int cash)
	{
		Bank -= cash;
		AddedBank = cash;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Cash", "Player Bank", Bank);
	}

	public static void CallHudFunction(int component, string name, params object[] args)
	{
		while (!Function.Call<bool>(Hash.BEGIN_SCALEFORM_SCRIPT_HUD_MOVIE_METHOD, component, name))
		{
			Script.Wait(0);
		}
		pushArgs(args);
		Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
	}

	protected static void pushArgs(object[] args)
	{
		foreach (object obj in args)
		{
			if (obj.GetType() == typeof(int))
			{
				Function.Call<int>(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, (int)obj);
			}
			else if (obj.GetType() == typeof(float))
			{
				Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, (float)obj);
			}
			else if (obj.GetType() == typeof(double))
			{
				Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, (float)(double)obj);
			}
			else if (obj.GetType() == typeof(bool))
			{
				Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, (bool)obj);
			}
			else if (obj.GetType() == typeof(string))
			{
				Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "STRING");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (string)obj);
				Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
			}
			else if (obj.GetType() == typeof(char))
			{
				Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "STRING");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, ((char)obj).ToString());
				Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
			}
		}
	}
}
