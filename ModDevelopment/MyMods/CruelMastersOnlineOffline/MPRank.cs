using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPRank : Script
{
	public static int BarID = 0;

	public static int BarTimer = 0;

	public static int BarSwitch = -1;

	public static bool CAN_SEE_RANK_BAR = true;

	public static string MovieName => "MP_RANK_BAR";

	public static int HudComponent => 19;

	public static int XPStartLimit { get; set; } = 0;

	public static int XPEndLimit { get; set; } = 1000;

	public static int PreviousXP { get; set; } = 0;

	public static int CurrentXP { get; set; } = 0;

	public static int PlayerLevel { get; set; } = 1;

	public MPRank()
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
		while (!Function.Call<bool>(Hash.HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED, 19))
		{
			Function.Call(Hash.REQUEST_SCALEFORM_SCRIPT_HUD_MOVIE, 19);
			Script.Wait(0);
		}
		if (Function.Call<bool>(Hash.HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED, 19) && CAN_SEE_RANK_BAR && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL && Function.Call<bool>(Hash.IS_SCRIPTED_HUD_COMPONENT_ACTIVE, 19) && CAN_SEE_RANK_BAR && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
		{
			XPStartLimit = CalculateXP(PlayerLevel - 1);
			XPEndLimit = CalculateXP(PlayerLevel);
			if (Game.IsControlJustPressed(Control.MultiplayerInfo) || (PreviousXP != CurrentXP && CAN_SEE_RANK_BAR && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS()))
			{
				SetColor(116, 123);
				CallHudFunction("OVERRIDE_ANIMATION_SPEED", 2000);
				CallHudFunction("OVERRIDE_ONSCREEN_DURATION", 6000);
				BeforeDraw();
				PreviousXP = CurrentXP;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player Previous RP", PreviousXP);
			}
			if (CurrentXP >= XPEndLimit && CAN_SEE_RANK_BAR && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
			{
				XPStartLimit = CalculateXP(PlayerLevel - 1);
				XPEndLimit = CalculateXP(PlayerLevel);
				SetColor(116, 123);
				CallHudFunction("OVERRIDE_ANIMATION_SPEED", 2000);
				CallHudFunction("OVERRIDE_ONSCREEN_DURATION", 6000);
				BeforeDraw();
				PreviousXP = CurrentXP;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player Previous RP", PreviousXP);
				PlayerLevel++;
				CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player Level", PlayerLevel);
				CallHudFunction("OVERRIDE_ANIMATION_SPEED", 2000);
				CallHudFunction("OVERRIDE_ONSCREEN_DURATION", 6000);
				SetColor(116, 123);
				CallHudFunction("SET_RANK_SCORES", XPStartLimit, XPEndLimit, PreviousXP, CurrentXP, PlayerLevel, 100);
				CallHudFunction("RESET_MOVIE");
				XPStartLimit = CalculateXP(PlayerLevel - 1);
				XPEndLimit = CalculateXP(PlayerLevel);
				CallHudFunction("OVERRIDE_ANIMATION_SPEED", 2000);
				CallHudFunction("OVERRIDE_ONSCREEN_DURATION", 6000);
				SetColor(116, 123);
				CallHudFunction("SET_RANK_SCORES", XPStartLimit, XPEndLimit, PreviousXP, CurrentXP, PlayerLevel, 100);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "RANK_UP", "HUD_AWARDS", true);
			}
		}
	}

	public unsafe void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			if (BarID != 0)
			{
				int barID = BarID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &barID);
				BarID = 0;
			}
			if (Function.Call<bool>(Hash.HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED, 19))
			{
				Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, 19);
			}
		}
	}

	public static int CalculateXP(int rank)
	{
		return (1000 + (rank - 1) * 125) * rank;
	}

	public static float CurrentExpLvl(float exp)
	{
		float num = 0.04f;
		return (float)((double)num * Math.Sqrt(exp));
	}

	public static void SET_RANK(int rank)
	{
		PlayerLevel = rank;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player Level", PlayerLevel);
	}

	public static void SET_RP(int rp)
	{
		PreviousXP = rp;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player Previous RP", PreviousXP);
		CurrentXP = rp;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player RP", CurrentXP);
	}

	public static void ADD_RP(int rp)
	{
		PreviousXP += rp;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player Previous RP", PreviousXP);
		CurrentXP += rp;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player RP", CurrentXP);
	}

	public static void REMOVE_RP(int rp)
	{
		PreviousXP -= rp;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player Previous RP", PreviousXP);
		CurrentXP -= rp;
		CruelMastersOnlineOffline.SET_INI_VALUE_INT(CruelMastersOnlineOffline.Config, "Rank", "Player RP", CurrentXP);
	}

	public static void SetColor(int color1, int color2)
	{
		CallHudFunction("SET_COLOUR", color1, color2);
	}

	public static void StayOnScreen()
	{
		CallHudFunction("STAY_ON_SCREEN");
	}

	public static void Reset()
	{
		CallHudFunction("RESET_MOVIE");
	}

	public static void BeforeDraw()
	{
		SetRankScores(XPStartLimit, XPEndLimit, PreviousXP, CurrentXP, PlayerLevel, PlayerLevel + 1);
	}

	public static void SetRankScores(int xpStartLimit, int xpEndLimit, int previousXP, int currentXP, int playerLevel, int rankNext)
	{
		CallHudFunction("SET_RANK_SCORES", xpStartLimit, xpEndLimit, previousXP, currentXP, playerLevel, 100, rankNext);
	}

	public static void CallHudFunction(string name, params object[] args)
	{
		while (!Function.Call<bool>(Hash.BEGIN_SCALEFORM_SCRIPT_HUD_MOVIE_METHOD, 19, name))
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
