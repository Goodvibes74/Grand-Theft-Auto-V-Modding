using System;
using System.Drawing;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPCustomHeistCMS : Script
{
	public static Blip CustomHeistBlip;

	public static int CustomHeistSwitch = 0;

	public static int PreviousSelection = 0;

	public static int currentselection;

	public static int getcurrentselection;

	public static int MouseCheck;

	public static int MissionsSwitch = -1;

	public static int MissionSwitch = 0;

	public static int TeamLives = 1;

	public static float HardModeMultiplier = 1.5f;

	public static bool HardMode = false;

	public MPCustomHeistCMS()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch >= 2 || CruelMastersOnlineOffline.DEBUG)
		{
			switch (CustomHeistSwitch)
			{
			case 0:
				if (!CruelMastersOnlineOffline.OnMission)
				{
					if (CustomHeistBlip == null)
					{
						CustomHeistBlip = World.CreateBlip(new Vector3(-1037.005f, -2748.748f, 21.3594f));
					}
					else
					{
						CustomHeistBlip.Sprite = BlipSprite.Chinese;
						CustomHeistBlip.Color = BlipColor.White;
						CustomHeistBlip.Name = "Custom Heists (CruelMaster MC)";
						CustomHeistBlip.Alpha = 255;
						CustomHeistBlip.Priority = 5;
						CustomHeistBlip.IsShortRange = true;
					}
					if (Game.Player.Character.Position.DistanceTo(new Vector3(-1037.005f, -2748.748f, 21.3594f)) < 10f)
					{
						World.DrawMarker(MarkerType.Cylinder, new Vector3(-1037.005f, -2748.748f, 19.7594f), Vector3.Zero, Vector3.Zero, new Vector3(1.5f, 1.5f, 1.5f), Color.White);
					}
					if (!(Game.Player.Character.Position.DistanceTo(new Vector3(-1037.005f, -2748.748f, 21.3594f)) < 1.3f))
					{
						break;
					}
					Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter.");
					if (!Game.IsControlJustPressed(Control.Context))
					{
						break;
					}
					int num = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
					Ped ped = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num, 0);
					Ped ped2 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num, 1);
					Ped ped3 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num, 2);
					Mobile_Phone.CAN_OPEN_PHONE = false;
					int num2 = Game.GameTime + 4000;
					CruelMastersOnlineOffline.OnMission = true;
					Game.Player.CanControlCharacter = false;
					PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 8, 1);
					while (Game.GameTime < num2)
					{
						Script.Wait(0);
					}
					Function.Call(Hash.TAKE_CONTROL_OF_FRONTEND);
					while (Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) != Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"))
					{
						Function.Call(Hash.ACTIVATE_FRONTEND_MENU, Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"), 0, -1);
						Script.Wait(200);
					}
					CruelMastersOnlineOffline.WaitForFrontendReady("MPCustomHeistCMS lobby");
					PreviousSelection = -1;
					if (!CruelMastersOnlineOffline.IsFreemodeMale && !CruelMastersOnlineOffline.IsFreemodeFemale)
					{
						CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_CHAR_IMG", 0);
					}
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SHIFT_CORONA_DESC", false, false);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SHIFT_CORONA_DESC", true, false);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_ALL_HIGHLIGHTS", 1, 2);
					if (MPRank.PlayerLevel >= 5)
					{
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Darnell Bros Score");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (CruelMaster MC)");
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, false);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Break into the Darnell Bros Factory to procure a trolley full of cash.");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "  Think you got what it takes?");
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, false);
						Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
					}
					else
					{
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Darnell Bros Score");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (CruelMaster MC)");
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
					}
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 0, 0, 0, 0, 0, 1, "Darnell Bros Score");
					CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "CruelMaster MC", false, 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "5", false, 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
					CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "CruelMaster MC - Darnell Bros Score", "CruelMaster MC - Darnell Bros Score", "", "pause_map", "pm_series_featured", "", "", 0, 0, 0, "", "", "", "", "");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 3);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 0, 0, 0, 2, 100, true, CruelMastersOnlineOffline.Player_Name, 0, false, 0, 1, 0, "", false, "HOST", 18);
					int num3 = 1;
					if (ped.Exists())
					{
						string text = "Ai Friend 1";
						if (ped.AttachedBlip != null)
						{
							text = ped.AttachedBlip.Name;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 1, 0, 0, 2, 100, true, text, 0, false, 0, 1, 0, "", false, "JOINED", 18);
						num3++;
					}
					else
					{
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 1, 0, 0, 0, 100, true, "", 2, false, 0, 1, 0, "", false, "", 4);
					}
					if (ped2.Exists())
					{
						string text2 = "Ai Friend 2";
						if (ped2.AttachedBlip != null)
						{
							text2 = ped2.AttachedBlip.Name;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 2, 0, 0, 2, 100, true, text2, 0, false, 0, 1, 0, "", false, "JOINED", 18);
						num3++;
					}
					else
					{
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 2, 0, 0, 0, 100, true, "", 2, false, 0, 1, 0, "", false, "", 4);
					}
					if (ped3.Exists())
					{
						string text3 = "Ai Friend 3";
						if (ped3.AttachedBlip != null)
						{
							text3 = ped3.AttachedBlip.Name;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 3, 0, 0, 2, 100, true, text3, 0, false, 0, 1, 0, "", false, "JOINED", 18);
						num3++;
					}
					else
					{
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 3, 0, 0, 0, 100, true, "", 2, false, 0, 1, 0, "", false, "", 4);
					}
					CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 3);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DESCRIPTION", 0, "Select a Contact Mission.", true);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_HEADING_DETAILS", "", "", "", false);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SHOW_HEADING_DETAILS", false);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 0, "CUSTOM HEIST MISSIONS", 1f, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num3} OF 1-4", 1f, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 2, "DETAILS", 1f, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("LOCK_MOUSE_SUPPORT", true, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_FOCUS", 0, true, true, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("PAGE_FADE_IN");
					Function.Call(Hash.RELEASE_CONTROL_OF_FRONTEND);
					CustomHeistSwitch = 1;
				}
				else if (CustomHeistBlip != null)
				{
					CustomHeistBlip.Alpha = 0;
				}
				break;
			case 1:
				CHECK_MOUSE_INPUT();
				if (Game.IsControlJustPressed(Control.PhoneCancel))
				{
					Function.Call(Hash.ACTIVATE_FRONTEND_MENU, Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"), 0, -1);
					Mobile_Phone.CAN_OPEN_PHONE = true;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.OnMission = false;
					PlayerSwitch.STOP_PLAYER_SWITCH();
					CustomHeistSwitch = 0;
				}
				if (getcurrentselection != 0)
				{
					break;
				}
				if (MPRank.PlayerLevel >= 5)
				{
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "CruelMaster MC", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "5", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Heist", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "CruelMaster MC - Darnell Bros Score", "CruelMaster MC - Darnell Bros Score", "", "pause_map", "pm_dlc_geraldslast", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Darnell Bros Score");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (CruelMaster MC)");
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, false);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Break into the Darnell Bros Factory to procure a trolley full of cash.");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "  Think you got what it takes?");
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.ADD_TEXT_COMPONENT_INTEGER, 0);
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, false);
						Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
					}
					if (Game.IsControlJustPressed(Control.FrontendAccept))
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "SELECT", "HUD_FREEMODE_SOUNDSET", true);
						Script.Wait(500);
						Function.Call(Hash.ACTIVATE_FRONTEND_MENU, Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"), 0, -1);
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
						Function.Call(Hash.TRIGGER_SCREENBLUR_FADE_IN, 1f);
						Function.Call(Hash.ANIMPOSTFX_PLAY, "MP_job_load", 0, false);
						Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "SCREEN_FLASH", "CELEBRATION_SOUNDSET", true);
						LoadingPrompt.Show("Loading Custom Heist");
						Script.Wait(2000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 0;
						CustomHeistSwitch = 0;
					}
				}
				else
				{
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "CruelMaster MC", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "5", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Heist", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "CruelMaster MC - Darnell Bros Score", "CruelMaster MC - Darnell Bros Score", "", "pause_map", "pm_dlc_geraldslast", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Darnell Bros Score");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (CruelMaster MC)");
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
					}
					if (Game.IsControlJustPressed(Control.FrontendAccept))
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ERROR", "HUD_FRONTEND_DEFAULT_SOUNDSET", true);
					}
				}
				break;
			}
		}
		MISSION_CONTROLLER();
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (CustomHeistBlip != null)
		{
			CustomHeistBlip.Delete();
		}
	}

	public static int GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(int currentselection)
	{
		return Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, currentselection);
	}

	public static void CHECK_MOUSE_INPUT()
	{
		if (Game.GameTime > MouseCheck && Function.Call<bool>(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND, "GET_COLUMN_SELECTION"))
		{
			Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 0);
			currentselection = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
			MouseCheck = Game.GameTime + 100;
		}
		if (Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, currentselection))
		{
			getcurrentselection = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(currentselection);
		}
	}

	public static void MISSION_CONTROLLER()
	{
		if (MissionsSwitch != 0)
		{
			return;
		}
		if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
		{
			if (TeamLives > 0)
			{
				Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.86f, 0.2f, 0.04f, 255, 255, 255, 130);
				Heist_Hud.drawText("TEAM LIVES", 0.78f, 0.845f, 0.4f, 255, 255, 255);
				Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
				Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
				Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
				Function.Call(Hash.SET_TEXT_RIGHT_JUSTIFY, true);
				Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
				Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.84f, 0.1f);
			}
			else
			{
				Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.86f, 0.2f, 0.04f, 255, 255, 255, 130);
				Heist_Hud.drawText("TEAM LIVES", 0.78f, 0.845f, 0.4f, 255, 255, 255);
				Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
				Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
				Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
				Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
				Function.Call(Hash.SET_TEXT_RIGHT_JUSTIFY, true);
				Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
				Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.84f, 0.1f);
			}
			Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
			Heist_Hud.drawText("TAKE", 0.78f, 0.89f, 0.4f, 255, 255, 255);
			Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
			Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "$" + Heist_Hud.Actual_Take.ToString("N0"));
			Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
			Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
			Function.Call(Hash.SET_TEXT_RIGHT_JUSTIFY, true);
			Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
			Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
			if (Game.Player.Character.IsDead)
			{
				TeamLives--;
				while (Game.Player.Character.IsDead)
				{
					Script.Wait(0);
				}
				if (TeamLives < 0)
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Trollys.RemoveTrollys();
					Trollys.TrollyAmount = 0;
					Trollys.TotalAmount = 0;
					Trollys.AllowTrollyGrab = false;
					Chase.SET_CHASE_DEACTIVATE();
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random = new Random();
					int num = random.Next(1, 3);
					if (num == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					Screen.FadeIn(500);
					while (!Screen.IsFadedIn)
					{
						Script.Wait(0);
					}
					Weapons.Anim_Weapon_Off();
					Audios.Stop_Music_Event();
					Game.Player.IsInvincible = true;
					Function.Call(Hash.SET_SEETHROUGH, false);
					Function.Call(Hash.SET_NIGHTVISION, false);
					Function.Call(Hash.SET_ARTIFICIAL_LIGHTS_STATE, false);
					Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
					Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFail", 0, false);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FAILED_SCREEN_SOUNDS", true);
					Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
					Wall_Creator.DeleteMissionPassScaleform();
					Script.Wait(500);
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
					Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
					Wall_Creator.DeleteMissionPassScaleform();
					Wall_Creator.RequestHeist2PassScaleform();
					Script.Wait(500);
					Function.Call(Hash.START_AUDIO_SCENE, "MP_CELEB_SCREEN_SCENE");
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_FAILED");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_FAILED");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_FAILED");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_FAILED", "HUD_COLOUR_TECH_RED", 2);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_FAILED", "HUD_COLOUR_TECH_RED", 2);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_FAILED", "HUD_COLOUR_TECH_RED", 2);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "Out of Lives", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "Out of Lives", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "Out of Lives", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_FAILED", 1);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_FAILED", 1);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_FAILED", 1);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_FAILED", 0, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_FAILED", 0, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_FAILED", 0, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_FAILED", 1);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_FAILED", 1);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_FAILED", 1);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", 75, 0);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", 75, 0);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", 75, 0);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_FAILED");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_FAILED");
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_FAILED");
					int num2 = Game.GameTime + 6000;
					while (Game.GameTime < num2)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					Groups.RemoveEnemyPeds();
					Vehicles.RemoveVehicles();
					PickupSteal.RemovePickups();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					return;
				}
			}
		}
		switch (MissionSwitch)
		{
		case 0:
		{
			if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
			{
				LOAD_SCENES.NEW_LOAD_SCENE_START(831.4296f, -1012.343f, 26.74637f, 0f, 0f, 0f, 500f, 0);
			}
			string[] array4 = new string[15]
			{
				"MP_CHF_START", "MP_MC_START_HEIST_PREP_NEW", "MP_MC_START_HEIST_FIN_NEW", "MP_MC_CMH_IAA_PREP_START", "MP_MC_CMH_IAA_FINALE_START", "MP_MC_CMH_SUB_PREP_START", "MP_MC_CMH_SUB_FINALE_START", "MP_MC_CMH_SILO_PREP_START", "MP_MC_CMH_SILO_FINALE_START", "MP_MC_CM22_START_TRACK_11",
				"MP_MC_TUNER_START_MUSIC", "MP_MC_GR_START", "LOWRIDER_START_MUSIC", "LOWRIDER_FINALE_START_MUSIC", "MP_MC_START"
			};
			Audios.TRIGGER_MUSIC_EVENT(array4[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array4.Length)]);
			Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
			Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
			MPLoadout.GET_CURRENT_LOADOUT();
			MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(831.3835f, -999.0405f, 26.22587f), 94.5778f);
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
			Game.Player.Character.Task.ClearAll();
			Game.Player.CanControlCharacter = true;
			Game.Player.Character.Position = new Vector3(831.4296f, -1012.343f, 25.74637f);
			Game.Player.Character.Heading = 52.88664f;
			Game.Player.Character.IsPositionFrozen = true;
			Cameras.RESET_GAMEPLAY_CAM();
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Script.Wait(1000);
			LoadingPrompt.Hide();
			Function.Call(Hash.STOP_AUDIO_SCENES);
			Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
			Function.Call(Hash.TRIGGER_SCREENBLUR_FADE_OUT, 1f);
			Screen_Effects.StopAllAnimPostFX();
			Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
			PlayerSwitch.STOP_PLAYER_SWITCH();
			if (LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
			{
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
			}
			Game.Player.Character.IsPositionFrozen = false;
			Wall_Creator.DeleteMissionPassScaleform();
			Script.Wait(500);
			Wall_Creator.DeleteMissionPassScaleform();
			Wall_Creator.RequestMissionPassScaleform();
			Script.Wait(500);
			Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "intro");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "intro");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "intro");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "intro", "HUD_COLOUR_BLACK");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "intro", "HUD_COLOUR_BLACK");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "intro", "HUD_COLOUR_BLACK");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Darnell Bros Score", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Darnell Bros Score", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Darnell Bros Score", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
			Screen.FadeIn(1000);
			Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
			int num10 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
			int num11 = 0;
			while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num10))
			{
				Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
				Script.Wait(0);
			}
			num11 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num10);
			if (CruelMastersOnlineOffline.DEBUG)
			{
				Notification.Show($"{num11}");
			}
			int num12 = Game.GameTime + num11;
			while (Game.GameTime < num12)
			{
				Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
				Script.Wait(0);
			}
			Function.Call(Hash.STOP_AUDIO_SCENES);
			Wall_Creator.DeleteMissionPassScaleform();
			Mobile_Phone.CAN_OPEN_PHONE = true;
			HudHandler.HudandRadar(Hud: true, Radar: true);
			CruelMastersOnlineOffline.checkpoint = 1;
			Heist_Hud.Actual_Take = 0;
			TeamLives = 1;
			MissionSwitch = 1;
			break;
		}
		case 1:
		{
			Vector3[] array = new Vector3[2]
			{
				new Vector3(709.7264f, -979.1343f, 24.06498f),
				new Vector3(731.9211f, -979.6242f, 24.25032f)
			};
			float[] array2 = new float[2] { 274.2116f, 91.10085f };
			int num9 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array.Length);
			RESPAWN.SET_MIS_STAT(array[num9], array2[num9], 0, misretaskbool: true);
			Screen.ShowSubtitle("Go to the ~y~Darnell Bros Factory.~w~");
			if (CruelMastersOnlineOffline.missionBlip == null)
			{
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
				}
				while (CruelMastersOnlineOffline.missionBlip == null)
				{
					CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(718.228f, -978.915f, 24.11674f));
					Script.Wait(0);
				}
				HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
			}
			else if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 30f)
			{
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
					HudHandler.CLEAR_GPS_ROUTE();
				}
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
				MissionSwitch = 2;
			}
			break;
		}
		case 2:
		{
			Groups.RemoveEnemyPeds();
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(717.6945f, -965.621f, 29.40879f), 178.6609f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(714.5129f, -964.5287f, 29.40869f), -135.1738f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(711.3912f, -961.2954f, 29.40859f), -147.2004f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(707.9368f, -965.5706f, 29.4088f), -69.86568f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.BlipUpEnemyPeds();
			PickupSteal.RemovePickups();
			PickupSteal.SPAWN_PICKUP_WITH_BLIP(PickupType.Armour, new Vector3(719.4617f, -963.2683f, 30.45383f), new Vector3(-89.00083f, -3.05935E-06f, -42.65356f), CruelMastersOnlineOffline.RequestModel(701173564), 200, 175, BlipColor.Blue, "Armour", minimaledge: true, 0.7f);
			PickupSteal.SPAWN_PICKUP_WITH_BLIP(PickupType.Health, new Vector3(719.6255f, -963.6557f, 30.49379f), new Vector3(0f, 0f, -7.237727f), CruelMastersOnlineOffline.RequestModel(678958360), 200, 153, BlipColor.Green, "Health", minimaledge: true, 0.7f);
			Trollys.RemoveTrollys();
			Trollys.SPAWN_Trolly(new Vector3(706.3926f, -964.0923f, 29.90825f), 238.4378f, "Cash");
			Trollys.TotalAmount = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 15000, 25001);
			Trollys.TrollyAmount = 1;
			Trollys.AllowTrollyGrab = true;
			while (Trollys.TrollySpawn[0].AttachedBlip == null)
			{
				Trollys.TrollySpawn[0].AddBlip();
				Script.Wait(0);
			}
			Trollys.TrollySpawn[0].AttachedBlip.Sprite = BlipSprite.Standard;
			Trollys.TrollySpawn[0].AttachedBlip.Color = BlipColor.Green;
			Trollys.TrollySpawn[0].AttachedBlip.Name = "Cash Trolly";
			Prop[] nearbyProps = World.GetNearbyProps(new Vector3(717.9952f, -975.7184f, 24.90963f), 20f, -681066206, 245182344);
			Prop[] array3 = nearbyProps;
			foreach (Prop prop in array3)
			{
				if (prop != null)
				{
					prop.IsPositionFrozen = false;
				}
			}
			Audios.TRIGGER_MUSIC_EVENT("MP_CHF_ACTION");
			MissionSwitch = 3;
			break;
		}
		case 3:
			Screen.ShowSubtitle("Steal the ~g~cash.~w~");
			if (Trollys.TrollySpawn.Count == 0)
			{
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
				WeaponHash[] weapons = new WeaponHash[2]
				{
					WeaponHash.Pistol,
					WeaponHash.MicroSMG
				};
				Chase.SET_CHASE_ACTIVATE(VehicleHash.Cinquemila, PedHash.ArmGoon01GMM, weapons);
				Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ grabbed the cash.");
				MissionSwitch = 4;
			}
			break;
		case 4:
		{
			Vector3[] array5 = new Vector3[2]
			{
				new Vector3(707.7828f, -965.3373f, 30.41283f),
				new Vector3(719.7528f, -964.9153f, 30.39534f)
			};
			float[] array6 = new float[2] { 283.6858f, 114.5485f };
			int num13 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array5.Length);
			RESPAWN.SET_MIS_STAT(array5[num13], array6[num13], 0, misretaskbool: true);
			Vehicles.RemoveVehicles();
			Vehicles.SPAWN_VEHICLE(VehicleHash.Cinquemila, new Vector3(733.6369f, -981.9631f, 22.78998f), 54.91279f, sirenactive: false, IsInvincible: false);
			Vehicles.SPAWN_VEHICLE(VehicleHash.Cinquemila, new Vector3(731.4392f, -987.4202f, 22.63474f), 52.15868f, sirenactive: false, IsInvincible: false);
			Vehicles.SPAWN_VEHICLE(VehicleHash.Cinquemila, new Vector3(706.5524f, -981.8581f, 22.53673f), -101.7774f, sirenactive: false, IsInvincible: false);
			Vehicles.SPAWN_VEHICLE(VehicleHash.Cinquemila, new Vector3(702.5166f, -990.5064f, 22.44759f), -64.89253f, sirenactive: false, IsInvincible: false);
			Groups.RemoveEnemyPeds();
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(735.1954f, -979.9547f, 23.48477f), 78.12508f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(732.436f, -984.6622f, 23.30906f), 55.24744f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(728.7743f, -988.5727f, 23.1532f), 50.28299f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(710.1155f, -979.9114f, 23.12275f), -89.69753f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(706.6533f, -984.3474f, 23.12157f), -90.4138f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(704.4872f, -986.709f, 23.10032f), -80.89481f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.SPAWN_AI(PedHash.ArmGoon01GMM, new Vector3(705.225f, -991.6381f, 22.98169f), -60.8832f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
			Groups.BlipUpEnemyPeds();
			Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
			MissionSwitch = 5;
			break;
		}
		case 5:
			Screen.ShowSubtitle("Deliver the ~g~cash~w~ to the ~y~Buyer.~w~");
			if (CruelMastersOnlineOffline.missionBlip == null)
			{
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
				}
				while (CruelMastersOnlineOffline.missionBlip == null)
				{
					CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-2827.343f, -44.17366f, 3.100057f));
					Script.Wait(0);
				}
				HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
				break;
			}
			if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 200f && Chase.ChaseActive)
			{
				Chase.SET_CHASE_DEACTIVATE();
			}
			if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 30f)
			{
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
					HudHandler.CLEAR_GPS_ROUTE();
				}
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
				Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ delivered the cash to the buyer.");
				MissionSwitch = 6;
			}
			break;
		case 6:
		{
			int actual_Take = Heist_Hud.Actual_Take;
			int num3 = Heist_Hud.Actual_Take;
			int num4 = 100;
			int num5 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
			Ped ped = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num5, 0);
			Ped ped2 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num5, 1);
			Ped ped3 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num5, 2);
			Audios.Stop_Music_Event();
			Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
			Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
			Script.Wait(2000);
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
			Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
			Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
			Game.Player.CanControlCharacter = false;
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
			Script.Wait(1000);
			Wall_Creator.DeleteMissionPassScaleform();
			Script.Wait(500);
			Wall_Creator.DeleteMissionPassScaleform();
			Wall_Creator.RequestHeistPassScaleform();
			Script.Wait(500);
			Screen_Effects.StopAllAnimPostFX();
			Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
			Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
			Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_HEIST");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_HEIST");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_HEIST");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_BLACK", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_BLACK", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_BLACK", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", "HEIST", "PASSED", "", true, true, true);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", "HEIST", "PASSED", "", true, true, true);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", "HEIST", "PASSED", "", true, true, true);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			if (ped.Exists())
			{
				num4 -= 25;
				num3 /= 2;
				string text = "Ai Friend 1";
				if (ped.AttachedBlip != null)
				{
					text = ped.AttachedBlip.Name;
				}
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text, "GOLD", text, true, true, false, "HUD_COLOUR_GOLD");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text, "GOLD", text, true, true, false, "HUD_COLOUR_GOLD");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text, "GOLD", text, true, true, false, "HUD_COLOUR_GOLD");
			}
			if (ped2.Exists())
			{
				num4 -= 25;
				num3 /= 2;
				string text2 = "Ai Friend 2";
				if (ped2.AttachedBlip != null)
				{
					text2 = ped2.AttachedBlip.Name;
				}
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text2, "SILVER", text2, true, true, false, "HUD_COLOUR_SILVER");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text2, "SILVER", text2, true, true, false, "HUD_COLOUR_SILVER");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text2, "SILVER", text2, true, true, false, "HUD_COLOUR_SILVER");
			}
			if (ped3.Exists())
			{
				num4 -= 25;
				num3 /= 2;
				string text3 = "Ai Friend 3";
				if (ped3.AttachedBlip != null)
				{
					text3 = ped3.AttachedBlip.Name;
				}
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text3, "BRONZE", text3, true, true, false, "HUD_COLOUR_BRONZE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text3, "BRONZE", text3, true, true, false, "HUD_COLOUR_BRONZE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", text3, "BRONZE", text3, true, true, false, "HUD_COLOUR_BRONZE");
			}
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_STAT_TABLE_TO_WALL", "CELEB_HEIST", "CELEB_PSCORE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_STAT_TABLE_TO_WALL", "CELEB_HEIST", "CELEB_PSCORE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_STAT_TABLE_TO_WALL", "CELEB_HEIST", "CELEB_PSCORE");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_HEIST", "SUMMARY");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_HEIST", "SUMMARY");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_HEIST", "SUMMARY");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 0, 25000, "POTENTIAL TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 0, 25000, "POTENTIAL TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 0, 25000, "POTENTIAL TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 25000, Heist_Hud.Actual_Take, "ACTUAL TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 25000, Heist_Hud.Actual_Take, "ACTUAL TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 25000, Heist_Hud.Actual_Take, "ACTUAL TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, num3, $"{num4}% CUT OF TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, num3, $"{num4}% CUT OF TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, num3, $"{num4}% CUT OF TAKE", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", num3, num3, "TOTAL CASH EARNED", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", num3, num3, "TOTAL CASH EARNED", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", num3, num3, "TOTAL CASH EARNED", "", "", 3, 3);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_HEIST", "SUMMARY");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_HEIST", "SUMMARY");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_HEIST", "SUMMARY");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			int num6 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 700, 1500);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_HEIST", num6, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_HEIST", num6, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_HEIST", num6, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_HEIST", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 1);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 75, 0);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 75, 0);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 75, 0);
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_HEIST");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_HEIST");
			Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_HEIST");
			int num7 = Game.GameTime + 27000;
			while (Game.GameTime < num7)
			{
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
				Script.Wait(0);
			}
			Groups.RemoveEnemyPeds();
			Groups.ClearEnemyPedsList2();
			Vehicles.RemoveVehicles();
			Props.RemoveProps();
			PickupSteal.RemovePickups();
			Trollys.RemoveTrollys();
			Trollys.TrollyAmount = 0;
			Trollys.TotalAmount = 0;
			Trollys.AllowTrollyGrab = false;
			Heist_Hud.Actual_Take = 0;
			Screen_Effects.StopAllAnimPostFX();
			Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
			Function.Call(Hash.STOP_AUDIO_SCENES);
			Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
			Wall_Creator.DeleteMissionPassScaleform();
			Game.Player.CanControlCharacter = true;
			MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-1034.103f, -2730.103f, 20.07145f), 239.1848f);
			int num8 = Game.GameTime + 4000;
			Game.Player.CanControlCharacter = false;
			PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
			while (Game.GameTime < num8)
			{
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
			Function.Call(Hash.SET_ENTITY_COORDS, Game.Player.Character, -1037.913f, -2738.268f, 20.16934f, true, false, false, true);
			Function.Call(Hash.SET_ENTITY_HEADING, Game.Player.Character, 337.2306f);
			Cameras.RESET_GAMEPLAY_CAM();
			Game.Player.CanControlCharacter = true;
			Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
			Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
			PlayerSwitch.SWITCH_IN_PLAYER(Game.Player.Character);
			while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
			{
				Script.Wait(0);
			}
			HudHandler.HudandRadar(Hud: true, Radar: true);
			MPCash.ADD_CASH(actual_Take);
			MPRank.ADD_RP(num6);
			CruelMastersOnlineOffline.RadioAllowed = true;
			CruelMastersOnlineOffline.NoCopsOnMission = false;
			CruelMastersOnlineOffline.FuckOffCivilians = false;
			CruelMastersOnlineOffline.OnMission = false;
			CruelMastersOnlineOffline.checkpoint = 0;
			MissionsSwitch = -1;
			MissionSwitch = 0;
			break;
		}
		}
	}
}
