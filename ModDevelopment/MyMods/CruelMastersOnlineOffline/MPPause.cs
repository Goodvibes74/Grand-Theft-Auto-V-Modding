using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class MPPause : Script
{
	public static Hash PauseMenu = CruelMastersOnlineOffline.joaat("FE_MENU_VERSION_MP_PAUSE");

	public static int TimeTillNextPause = 0;

	public static bool CAN_PAUSE_GAME = true;

	public MPPause()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (!Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE) && Cutscenes.HAS_CUTSCENE_FINISHED() && CAN_PAUSE_GAME && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL && !MPInteractionMenu.PI_MENU_IS_OPEN && !Function.Call<bool>(Hash.IS_WARNING_MESSAGE_ACTIVE))
		{
			if (Function.Call<int>(Hash.UPDATE_ONSCREEN_KEYBOARD) != 1 && Function.Call<int>(Hash.UPDATE_ONSCREEN_KEYBOARD) != 2 && Function.Call<int>(Hash.UPDATE_ONSCREEN_KEYBOARD) != -1)
			{
				return;
			}
			if (TimeTillNextPause == 0)
			{
				TimeTillNextPause = Game.GameTime + 2000;
			}
			if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, 2, 199) || (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, 2, 200) && Game.GameTime > TimeTillNextPause))
			{
				Function.Call(Hash.TAKE_CONTROL_OF_FRONTEND);
				while (Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) != PauseMenu)
				{
					Function.Call(Hash.ACTIVATE_FRONTEND_MENU, PauseMenu, 0, -1);
					Script.Wait(200);
				}
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
				Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "CruelMaster's Online Offline");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " ");
				Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
				Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
				Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
				Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, false);
				Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "");
				Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
				Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
				Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
				Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, false);
				Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
				CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_MENU_HEADER_TEXT_BY_INDEX", 1, "ONLINE/OFFLINE");
				Function.Call(Hash.RELEASE_CONTROL_OF_FRONTEND);
			}
			return;
		}
		if (TimeTillNextPause != 0)
		{
			TimeTillNextPause = 0;
		}
		if (Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == PauseMenu)
		{
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 30, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 31, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 32, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 33, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 34, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 35, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 25, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 59, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 60, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 61, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 62, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 63, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 64, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 65, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 66, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 67, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 68, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 69, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 70, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 71, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 72, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 91, 1);
			for (int i = 0; i < 8; i++)
			{
				CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_MENU_ITEM_COLOUR", i, 116);
			}
			string text = $"{Function.Call<int>(Hash.GET_CLOCK_MINUTES)}";
			if (Function.Call<int>(Hash.GET_CLOCK_MINUTES) < 10)
			{
				text = $"0{Function.Call<int>(Hash.GET_CLOCK_MINUTES)}";
			}
			string text2 = $"{Function.Call<int>(Hash.GET_CLOCK_HOURS)}";
			if (Function.Call<int>(Hash.GET_CLOCK_HOURS) < 10)
			{
				text2 = $"0{Function.Call<int>(Hash.GET_CLOCK_HOURS)}";
			}
			string text3 = "Sunday";
			switch (Function.Call<int>(Hash.GET_CLOCK_DAY_OF_WEEK))
			{
			case 0:
				text3 = "Sunday";
				break;
			case 1:
				text3 = "Monday";
				break;
			case 2:
				text3 = "Tuesday";
				break;
			case 3:
				text3 = "Wednesday";
				break;
			case 4:
				text3 = "Thursday";
				break;
			case 5:
				text3 = "Friday";
				break;
			case 6:
				text3 = "Saturday";
				break;
			}
			CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_HEADING_DETAILS", CruelMastersOnlineOffline.Player_Name, text3 + " " + text2 + ":" + text, "BANK $" + MPCash.Bank.ToString("N0") + " CASH $" + MPCash.Cash.ToString("N0"), false);
			CruelMastersOnlineOffline.CallFunctionFrontendHeader("SHOW_HEADING_DETAILS", true);
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == PauseMenu)
		{
			Function.Call(Hash.ACTIVATE_FRONTEND_MENU, PauseMenu, 0, -1);
		}
	}
}
