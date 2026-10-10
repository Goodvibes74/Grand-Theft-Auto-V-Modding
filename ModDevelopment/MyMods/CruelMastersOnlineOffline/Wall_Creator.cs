using System;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Wall_Creator : Script
{
	private enum FRONTEND_MENU_TYPE
	{
		FE_MENU_VERSION_CORONA_BETTING = -545108805,
		FE_MENU_VERSION_CORONA_INVITE_MATCHED_PLAYERS = 14955678,
		FE_MENU_VERSION_CORONA_INVITE_LAST_JOB_PLAYERS = -1664703635,
		FE_MENU_VERSION_CORONA_INVITE_FRIENDS = -818055323,
		FE_MENU_VERSION_CORONA_JOINED_PLAYERS = -708066240,
		FE_MENU_VERSION_CORONA = 889053273
	}

	private enum ePlayerSwitchTypes
	{
		SWITCH_TYPE_AUTO,
		SWITCH_TYPE_LONG,
		SWITCH_TYPE_MEDIUM,
		SWITCH_TYPE_SHORT
	}

	public static bool Wall_In_Progress = false;

	public static bool Wall2_In_Progress = false;

	public static bool Wall3_In_Progress = false;

	public static bool Wall4_In_Progress = false;

	public static bool WallFail_In_Progress = false;

	public static bool WallPass_In_Progress = false;

	public static string MissionType = "";

	public static string SelectedRobbery = "";

	public static string CashWonStat = "";

	public static int CashWon = 0;

	public static int RPWon = 0;

	public static int Waves = 0;

	public static int TotalKills = 0;

	public static string FailReason = "";

	public static int RobberyStartWall = 1;

	public static int RobberyFinishWall = 1;

	public static int MissionFinaleStartswitch = 1;

	public static int MissionFinalePassswitch = 1;

	public static int ShardMissionStartPass;

	public static int MISSIONPASSED;

	public static int MISSIONPASSED2;

	public static int MISSIONPASSED3;

	public static int ShardTimer = 0;

	public static int CleanUpSwitch = 0;

	public static Camera FailCam;

	public Wall_Creator()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		switch (RobberyStartWall)
		{
		case 1:
			if (SelectedRobbery != "" && MissionType != "" && Wall_In_Progress)
			{
				Audio.SetAudioFlag(AudioFlags.LoadMPData, toggle: true);
				DeleteMissionPassScaleform();
				RequestMissionPassScaleform();
				Script.Wait(500);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				HudHandler.HudandRadar(Hud: false, Radar: false);
				RobberyStartWall = 2;
			}
			break;
		case 2:
			CallFunction(MISSIONPASSED, "CLEANUP", "intro");
			CallFunction(MISSIONPASSED2, "CLEANUP", "intro");
			CallFunction(MISSIONPASSED3, "CLEANUP", "intro");
			CallFunction(MISSIONPASSED, "CREATE_STAT_WALL", "intro", "HUD_COLOUR_HEIST_BACKGROUND");
			CallFunction(MISSIONPASSED2, "CREATE_STAT_WALL", "intro", "HUD_COLOUR_HEIST_BACKGROUND");
			CallFunction(MISSIONPASSED3, "CREATE_STAT_WALL", "intro", "HUD_COLOUR_HEIST_BACKGROUND");
			CallFunction(MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", MissionType, SelectedRobbery, "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
			CallFunction(MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", MissionType, SelectedRobbery, "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
			CallFunction(MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", MissionType, SelectedRobbery, "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
			CallFunction(MISSIONPASSED, "PAUSE", "intro", 3);
			CallFunction(MISSIONPASSED2, "PAUSE", "intro", 3);
			CallFunction(MISSIONPASSED3, "PAUSE", "intro", 3);
			CallFunction(MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
			CallFunction(MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
			CallFunction(MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
			CallFunction(MISSIONPASSED, "SHOW_STAT_WALL", "intro");
			CallFunction(MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
			CallFunction(MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
			ShardTimer = Game.GameTime + 8000;
			RobberyStartWall = 3;
			break;
		case 3:
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			if (Game.GameTime > ShardTimer)
			{
				Function.Call(Hash.STOP_AUDIO_SCENES);
				DeleteMissionPassScaleform();
				SelectedRobbery = "";
				MissionType = "";
				ShardTimer = 0;
				Wall_In_Progress = false;
				RobberyStartWall = 1;
			}
			break;
		}
		switch (RobberyFinishWall)
		{
		case 1:
			if (SelectedRobbery != "" && Wall2_In_Progress)
			{
				Audio.SetAudioFlag(AudioFlags.LoadMPData, toggle: true);
				DeleteMissionPassScaleform();
				RequestMissionPassScaleform();
				Script.Wait(500);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				RobberyFinishWall = 2;
			}
			break;
		case 2:
			CallFunction(MISSIONPASSED, "CLEANUP", "CELEB_HEIST");
			CallFunction(MISSIONPASSED2, "CLEANUP", "CELEB_HEIST");
			CallFunction(MISSIONPASSED3, "CLEANUP", "CELEB_HEIST");
			CallFunction(MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_BLACK");
			CallFunction(MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_BLACK");
			CallFunction(MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_BLACK");
			CallFunction(MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", SelectedRobbery, "PASSED", "", true, true, true);
			CallFunction(MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", SelectedRobbery, "PASSED", "", true, true, true);
			CallFunction(MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", SelectedRobbery, "PASSED", "", true, true, true);
			CallFunction(MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED2, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED3, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			CallFunction(MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			CallFunction(MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			CallFunction(MISSIONPASSED, "ADD_STAT_TABLE_TO_WALL", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED2, "ADD_STAT_TABLE_TO_WALL", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED3, "ADD_STAT_TABLE_TO_WALL", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 75, 0);
			CallFunction(MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 75, 0);
			CallFunction(MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 75, 0);
			CallFunction(MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_HEIST");
			CallFunction(MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_HEIST");
			CallFunction(MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_HEIST");
			ShardTimer = Game.GameTime + 22000;
			Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
			RobberyFinishWall = 3;
			break;
		case 3:
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			if (Game.GameTime > ShardTimer)
			{
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				DeleteMissionPassScaleform();
				SelectedRobbery = "";
				MissionType = "";
				ShardTimer = 0;
				Wall2_In_Progress = false;
				RobberyFinishWall = 1;
			}
			break;
		}
		switch (MissionFinalePassswitch)
		{
		case 1:
			if (SelectedRobbery != "" && Wall4_In_Progress)
			{
				Audio.SetAudioFlag(AudioFlags.LoadMPData, toggle: true);
				DeleteMissionPassScaleform();
				RequestHeistPassScaleform();
				Script.Wait(500);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				MissionFinalePassswitch = 2;
			}
			break;
		case 2:
			CallFunction(MISSIONPASSED, "CLEANUP", "CELEB_HEIST");
			CallFunction(MISSIONPASSED2, "CLEANUP", "CELEB_HEIST");
			CallFunction(MISSIONPASSED3, "CLEANUP", "CELEB_HEIST");
			CallFunction(MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_WAYPOINTDARK");
			CallFunction(MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_WAYPOINTDARK");
			CallFunction(MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_HEIST", "HUD_COLOUR_WAYPOINTDARK");
			CallFunction(MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", SelectedRobbery, "PASSED", "", true, true, true);
			CallFunction(MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", SelectedRobbery, "PASSED", "", true, true, true);
			CallFunction(MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_HEIST", SelectedRobbery, "PASSED", "", true, true, true);
			CallFunction(MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED2, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED3, "CREATE_STAT_TABLE", "CELEB_HEIST", "CELEB_PSCORE");
			CallFunction(MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			CallFunction(MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			CallFunction(MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_HEIST", "CELEB_PSCORE", CruelMastersOnlineOffline.Player_Name, "PLATINUM", CruelMastersOnlineOffline.Player_Name, true, true, false, "HUD_COLOUR_PLATINUM");
			CallFunction(MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_HEIST", "SUMMARY");
			CallFunction(MISSIONPASSED2, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_HEIST", "SUMMARY");
			CallFunction(MISSIONPASSED3, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_HEIST", "SUMMARY");
			CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 0, CruelMastersOnlineOffline.Potential_Cut, "POTENTIAL TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 0, CruelMastersOnlineOffline.Potential_Cut, "POTENTIAL TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", 0, CruelMastersOnlineOffline.Potential_Cut, "POTENTIAL TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", CruelMastersOnlineOffline.Potential_Cut, Heist_Hud.Actual_Take, "ACTUAL TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", CruelMastersOnlineOffline.Potential_Cut, Heist_Hud.Actual_Take, "ACTUAL TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", CruelMastersOnlineOffline.Potential_Cut, Heist_Hud.Actual_Take, "ACTUAL TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, Heist_Hud.Actual_Take, "100% CUT OF TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, Heist_Hud.Actual_Take, "100% CUT OF TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, Heist_Hud.Actual_Take, "100% CUT OF TAKE", "", "", 3, 3);
			CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, Heist_Hud.Actual_Take, "TOTAL CASH EARNED", "", "", 3, 3);
			CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, Heist_Hud.Actual_Take, "TOTAL CASH EARNED", "", "", 3, 3);
			CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_HEIST", "SUMMARY", Heist_Hud.Actual_Take, Heist_Hud.Actual_Take, "TOTAL CASH EARNED", "", "", 3, 3);
			CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_HEIST", "SUMMARY");
			CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_HEIST", "SUMMARY");
			CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_HEIST", "SUMMARY");
			CallFunction(MISSIONPASSED, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_HEIST", 2);
			CallFunction(MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 90, 1);
			CallFunction(MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 90, 1);
			CallFunction(MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_HEIST", 90, 1);
			CallFunction(MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_HEIST");
			CallFunction(MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_HEIST");
			CallFunction(MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_HEIST");
			ShardTimer = Game.GameTime + 22000;
			MissionFinalePassswitch = 3;
			break;
		case 3:
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			if (Game.GameTime >= ShardTimer)
			{
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.CLEAR_GPS_MULTI_ROUTE);
				DeleteMissionPassScaleform();
				Heist_Hud.Actual_Take = 0;
				Wall4_In_Progress = false;
				ShardTimer = 0;
				MissionFinalePassswitch = 1;
			}
			break;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (FailCam != null)
		{
			FailCam.Delete();
		}
	}

	public unsafe static void DeleteMissionPassScaleform()
	{
		if (MISSIONPASSED != 0)
		{
			int mISSIONPASSED = MISSIONPASSED;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &mISSIONPASSED);
			MISSIONPASSED = 0;
		}
		if (MISSIONPASSED2 != 0)
		{
			int mISSIONPASSED2 = MISSIONPASSED2;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &mISSIONPASSED2);
			MISSIONPASSED2 = 0;
		}
		if (MISSIONPASSED3 != 0)
		{
			int mISSIONPASSED3 = MISSIONPASSED3;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &mISSIONPASSED3);
			MISSIONPASSED3 = 0;
		}
		Script.Yield();
	}

	public static void RequestMissionPassScaleform()
	{
		Script.Yield();
		MISSIONPASSED = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "MP_CELEBRATION_BG");
		while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, MISSIONPASSED))
		{
			Script.Wait(0);
		}
		MISSIONPASSED2 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "MP_CELEBRATION_FG");
		while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, MISSIONPASSED2))
		{
			Script.Wait(0);
		}
		MISSIONPASSED3 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "MP_CELEBRATION");
		while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, MISSIONPASSED3))
		{
			Script.Wait(0);
		}
	}

	public static void RequestHeistPassScaleform()
	{
		Script.Yield();
		MISSIONPASSED = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "HEIST_CELEBRATION_BG");
		MISSIONPASSED2 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "HEIST_CELEBRATION_FG");
		MISSIONPASSED3 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "HEIST_CELEBRATION");
	}

	public static void RequestHeist2PassScaleform()
	{
		Script.Yield();
		MISSIONPASSED = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "HEIST2_CELEBRATION_BG");
		MISSIONPASSED2 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "HEIST2_CELEBRATION_FG");
		MISSIONPASSED3 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "HEIST2_CELEBRATION");
	}

	public unsafe static void DeleteMissionShardScaleform()
	{
		int shardMissionStartPass = ShardMissionStartPass;
		Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &shardMissionStartPass);
		ShardMissionStartPass = 0;
	}

	public static void RequestMissionShardScaleform()
	{
		Script.Yield();
		ShardMissionStartPass = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MIDSIZED_MESSAGE");
	}

	public static void MissionCelebrate(int uParam1, int uParam2, int uParam3)
	{
		Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN_MASKED, uParam1, uParam2, 255, 255, 255, 255);
		Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, uParam3, 255, 255, 255, 255, 0);
	}

	public static void MissionShard(int uParam1)
	{
		Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, uParam1, 255, 255, 255, 255, 0);
	}

	public static void Shard_In(string ShardName, string ShardDescription, int color, float speed)
	{
		DeleteMissionShardScaleform();
		RequestMissionShardScaleform();
		Script.Wait(500);
		CallFunction(ShardMissionStartPass, "SHOW_SHARD_MIDSIZED_MESSAGE", ShardName, ShardDescription, 2, false, true);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Shard_Appear", "GTAO_FM_Events_Soundset", true);
		int num = Game.GameTime + 7000;
		while (Game.GameTime < num)
		{
			MissionShard(ShardMissionStartPass);
			Script.Wait(0);
		}
		Shard_Out(color, speed);
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			MissionShard(ShardMissionStartPass);
			Script.Wait(0);
		}
		DeleteMissionShardScaleform();
	}

	public static void Shard_Out(int color, float speed)
	{
		CallFunction(ShardMissionStartPass, "SHARD_ANIM_OUT", color, speed);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Shard_Disappear", "GTAO_FM_Events_Soundset", true);
	}

	public static void Mission_Shard_In(int timer = 6000, string color = "HUD_COLOUR_WAYPOINTDARK", string missiontype = "", string selectedmission = "", string challengetext = "", string challengepart = "", string targetTypeText = "", string targetValue = "", int delay = 0, string targetValuePrefix = "$", bool literalstring = true, string textcolor = "HUD_COLOUR_WHITE", int pausedur = 3, int alpha = 75, int walltype = 1)
	{
		int num = 0;
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
		DeleteMissionPassScaleform();
		RequestMissionPassScaleform();
		Script.Wait(500);
		Wall_In_Progress = true;
		Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
		HudHandler.HudandRadar(Hud: false, Radar: false);
		CallFunction(MISSIONPASSED, "CLEANUP", "intro");
		CallFunction(MISSIONPASSED2, "CLEANUP", "intro");
		CallFunction(MISSIONPASSED3, "CLEANUP", "intro");
		CallFunction(MISSIONPASSED, "CREATE_STAT_WALL", "intro", color, "100.0");
		CallFunction(MISSIONPASSED2, "CREATE_STAT_WALL", "intro", color, "100.0");
		CallFunction(MISSIONPASSED3, "CREATE_STAT_WALL", "intro", color, "100.0");
		CallFunction(MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", missiontype, selectedmission, challengetext, challengepart, targetTypeText, targetValue, delay, targetValuePrefix, literalstring, textcolor);
		CallFunction(MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", missiontype, selectedmission, challengetext, challengepart, targetTypeText, targetValue, delay, targetValuePrefix, literalstring, textcolor);
		CallFunction(MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", missiontype, selectedmission, challengetext, challengepart, targetTypeText, targetValue, delay, targetValuePrefix, literalstring, textcolor);
		CallFunction(MISSIONPASSED, "PAUSE", "intro", pausedur);
		CallFunction(MISSIONPASSED2, "PAUSE", "intro", pausedur);
		CallFunction(MISSIONPASSED3, "PAUSE", "intro", pausedur);
		CallFunction(MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", alpha, walltype);
		CallFunction(MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", alpha, walltype);
		CallFunction(MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", alpha, walltype);
		CallFunction(MISSIONPASSED, "SHOW_STAT_WALL", "intro");
		CallFunction(MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
		CallFunction(MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
		num = Game.GameTime + timer;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Function.Call(Hash.STOP_AUDIO_SCENES);
		Wall_In_Progress = false;
		HudHandler.HudandRadar(Hud: true, Radar: true);
		DeleteMissionPassScaleform();
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
	}

	public static void Mission_Fail_In(int timer = 6000, string color = "HUD_COLOUR_WAYPOINTDARK", string missionTextLabel = "", string passFailTextLabel = "", string messageLabel = "", bool isMessageRawText = true, bool isPassFailRawText = true, bool isMissionTextRawText = true, int pausedur = 3, int alpha = 75, int walltype = 1, string[] musicarg = null, Vector3[] pos = null, float[] heading = null, string selectedmission = "", string challengetext = "", string challengepart = "", string targetTypeText = "", string targetValue = "", string textcolor = "HUD_COLOUR_WHITE", int pausedur2 = 3, int alpha2 = 75, int walltype2 = 1, bool usingactionmode = true)
	{
		bool flag = false;
		int num = 0;
		Ped character = Game.Player.Character;
		Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
		Weapons.Anim_Weapon_Off();
		character.IsInvincible = true;
		CruelMastersOnlineOffline.LoadDict("anim@deathmatch_intros@unarmed");
		CruelMastersOnlineOffline.LoadDict("anim@heists@team_respawn@variations@variation_c");
		if (!Game.Player.Character.IsDead)
		{
			character.CanRagdoll = false;
			Function.Call(Hash.SET_PED_CONFIG_FLAG, character, 188, true);
			Audios.Stop_Music_Event();
			Function.Call(Hash.SET_HIDOF_OVERRIDE, 1, 1, 0f, Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_NEAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF) + 25f);
			WallFail_In_Progress = true;
			Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, usingactionmode);
			Game.Player.CanControlCharacter = false;
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
			Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFail", 0, false);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FAILED_SCREEN_SOUNDS", true);
			num = Game.GameTime + 2000;
			while (Game.GameTime < num)
			{
				Script.Wait(0);
			}
		}
		else
		{
			flag = true;
		}
		while (Game.Player.Character.IsDead)
		{
			Script.Wait(0);
		}
		if (flag)
		{
			Screen.FadeOut(0);
			Audios.Stop_Music_Event();
			Function.Call(Hash.SET_HIDOF_OVERRIDE, 1, 1, 0f, Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_NEAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF) + 25f);
			WallFail_In_Progress = true;
			Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, usingactionmode);
			Game.Player.CanControlCharacter = false;
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
			Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFail", 0, false);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FAILED_SCREEN_SOUNDS", true);
		}
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		if (FailCam != null)
		{
			FailCam.Delete();
			FailCam = null;
		}
		while (FailCam == null)
		{
			FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
			Script.Wait(0);
		}
		Random random = new Random();
		int num2 = random.Next(1, 8);
		if (num2 == 1)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 10f);
		}
		if (num2 == 2)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 1f, 3f, 0f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 10f);
		}
		if (num2 == 3)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 0.5f, 3f, 0f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 12f);
		}
		if (num2 == 4)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 1f, 3f, -1f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.5f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 12f);
		}
		if (num2 == 5)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 0f, 2f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 12f);
		}
		if (num2 == 6)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 0.5f, 0.5f, -1f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 1f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 25f);
		}
		if (num2 == 7)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, -0.5f, 2f, 0f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, 0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 15f);
		}
		World.RenderingCamera = FailCam;
		Script.Wait(1500);
		Screen.FadeIn(500);
		while (!Screen.IsFadedIn)
		{
			Script.Wait(0);
		}
		Weapons.Anim_Weapon_Off();
		Function.Call(Hash.SET_SEETHROUGH, false);
		Function.Call(Hash.SET_NIGHTVISION, false);
		Function.Call(Hash.SET_ARTIFICIAL_LIGHTS_STATE, false);
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFail", 0, false);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FAILED_SCREEN_SOUNDS", true);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
		DeleteMissionPassScaleform();
		RequestHeistPassScaleform();
		Script.Wait(1000);
		Wall_In_Progress = true;
		Function.Call(Hash.START_AUDIO_SCENE, "MP_CELEB_SCREEN_SCENE");
		HudHandler.HudandRadar(Hud: false, Radar: false);
		CallFunction(MISSIONPASSED, "CLEANUP", "CELEB_FAILED");
		CallFunction(MISSIONPASSED2, "CLEANUP", "CELEB_FAILED");
		CallFunction(MISSIONPASSED3, "CLEANUP", "CELEB_FAILED");
		CallFunction(MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_FAILED", color, 2);
		CallFunction(MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_FAILED", color, 2);
		CallFunction(MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_FAILED", color, 2);
		CallFunction(MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_FAILED", 0, "left");
		CallFunction(MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_FAILED", 0, "left");
		CallFunction(MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_FAILED", 0, "left");
		CallFunction(MISSIONPASSED, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", alpha, walltype);
		CallFunction(MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", alpha, walltype);
		CallFunction(MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", alpha, walltype);
		CallFunction(MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_FAILED");
		CallFunction(MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_FAILED");
		CallFunction(MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_FAILED");
		num = Game.GameTime + 300;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFailBW", 0, true);
		num = Game.GameTime + timer;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFailBW");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebEnd", 0, false);
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		DeleteMissionPassScaleform();
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		PlayerSwitch._SWITCH_OUT_PLAYER(character, 3, 1);
		FailCam.Delete();
		FailCam = null;
		World.RenderingCamera = null;
		Function.Call(Hash.ANIMPOSTFX_STOP_ALL);
		Function.Call(Hash.SET_HIDOF_OVERRIDE, 0, 0, 0f, 0f, 0f, 0f);
		Function.Call(Hash.STOP_AUDIO_SCENES);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
		num = Game.GameTime + 5000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "LEADER_BOARD", "HUD_FRONTEND_DEFAULT_SOUNDSET", true);
		while (!Game.IsControlJustPressed(Control.FrontendRt))
		{
			Scaleform scaleform = new Scaleform("instructional_buttons");
			scaleform.CallFunction("CLEAR_ALL");
			scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
			scaleform.CallFunction("CREATE_CONTAINER");
			scaleform.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 208, 0), "Quick Restart ");
			scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
			scaleform.Render2D();
			Script.Wait(0);
		}
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "LEADER_BOARD", "HUD_FRONTEND_DEFAULT_SOUNDSET", true);
		LoadingPrompt.Show("Loading", LoadingSpinnerType.Clockwise1);
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		Audios.TRIGGER_MUSIC_EVENT(musicarg[0]);
		Audios.TRIGGER_MUSIC_EVENT(musicarg[1]);
		num = Game.GameTime + 5000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		LoadingPrompt.Show("Loading", LoadingSpinnerType.SocialClubSaving);
		num2 = random.Next(pos.Length);
		character.Position = pos[num2];
		character.Heading = heading[num2];
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			LOAD_SCENES.LOAD_SCENE(pos[num2].X, pos[num2].Y, pos[num2].Z);
			Script.Wait(0);
		}
		Cameras.RESET_GAMEPLAY_CAM();
		Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
		Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
		PlayerSwitch.SWITCH_IN_PLAYER(character);
		string[] array = new string[6] { "a", "b", "c", "d", "e", "a" };
		while (CruelMastersOnlineOffline.CutsceneCam == null)
		{
			CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
			Script.Wait(0);
		}
		while (CruelMastersOnlineOffline.CutsceneCam2 == null)
		{
			CruelMastersOnlineOffline.CutsceneCam2 = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
			Script.Wait(0);
		}
		while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
		{
			LOAD_SCENES.LOAD_SCENE(pos[num2].X, pos[num2].Y, pos[num2].Z);
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Script.Wait(0);
		}
		while (World.RenderingCamera != CruelMastersOnlineOffline.CutsceneCam)
		{
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
			Script.Wait(0);
		}
		Game.Player.Character.Position = pos[num2];
		Game.Player.Character.Heading = heading[num2];
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 1f, 0f, 0f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, -1f, 0f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 50f);
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.5f, 2f, 0.5f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0f, 0f, 0.3f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam2, 26f);
		Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam2, true);
		Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CruelMastersOnlineOffline.CutsceneCam2, CruelMastersOnlineOffline.CutsceneCam, 5000, 3, 1);
		int num3 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 2);
		int num4 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 5);
		Game.Player.Character.Task.PlayAnimation("anim@deathmatch_intros@unarmed", "intro_male_unarmed_" + array[num4], 1000f, 1f, -1, AnimationFlags.None, 0f);
		LoadingPrompt.Hide();
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
		Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, usingactionmode);
		Mission_Shard_In(6000, "HUD_COLOUR_HSHARD", missionTextLabel, selectedmission, challengetext, challengepart, targetTypeText, targetValue, 5, "$", literalstring: true, textcolor, pausedur2, alpha2, walltype2);
		while (Wall_In_Progress)
		{
			Script.Wait(0);
		}
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.7983f, -0.9226f, 0.5243f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.2782f, 1.8498f, 0.1298f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 30f);
		Function.Call(Hash.SET_CAM_NEAR_CLIP, CruelMastersOnlineOffline.CutsceneCam2, 0.15f);
		Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_HEADING, 0f);
		Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_PITCH, 0f, 1f);
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.1208f, -1.7733f, 0.6538f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.4472f, 1.154f, 0.0844f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam2, 50f);
		Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam2, true);
		Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CruelMastersOnlineOffline.CutsceneCam2, CruelMastersOnlineOffline.CutsceneCam, 3000, 3, 1);
		num = Game.GameTime + 3000;
		while (Game.GameTime < num)
		{
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Script.Wait(0);
		}
		if (CruelMastersOnlineOffline.CutsceneCam != null)
		{
			CruelMastersOnlineOffline.CutsceneCam.Delete();
			CruelMastersOnlineOffline.CutsceneCam = null;
		}
		if (CruelMastersOnlineOffline.CutsceneCam2 != null)
		{
			CruelMastersOnlineOffline.CutsceneCam2.Delete();
			CruelMastersOnlineOffline.CutsceneCam2 = null;
		}
		Function.Call(Hash.SET_FOLLOW_PED_CAM_VIEW_MODE, 0);
		Function.Call(Hash.RENDER_SCRIPT_CAMS, false, true, 1000, false, false, 0);
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		Audios.TRIGGER_MUSIC_EVENT(musicarg[2]);
		Screen_Effects.PlayAnimPostFX("MinigameTransitionOut", 1000, looped: false);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hit", "RESPAWN_SOUNDSET", true);
		HudHandler.HudandRadar(Hud: true, Radar: true);
		Game.Player.CanControlCharacter = true;
		Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
		character.IsInvincible = false;
		character.CanRagdoll = true;
		Function.Call(Hash.SET_PED_CONFIG_FLAG, character, 188, false);
		WallFail_In_Progress = false;
	}

	public static void Mission_Fail_In_New(int timer = 6000, string color = "HUD_COLOUR_WAYPOINTDARK", string missionTextLabel = "", string passFailTextLabel = "", string messageLabel = "", bool isMessageRawText = true, bool isPassFailRawText = true, bool isMissionTextRawText = true, int pausedur = 3, int alpha = 75, int walltype = 1, string[] musicarg = null, Vector3[] pos = null, float[] heading = null, string selectedmission = "", string challengetext = "", string challengepart = "", string targetTypeText = "", string targetValue = "", string textcolor = "HUD_COLOUR_WHITE", int pausedur2 = 3, int alpha2 = 75, int walltype2 = 1, bool usingactionmode = true, Vector3 beforepos = default(Vector3), float beforehead = 0f, string shardincolor = "HUD_COLOUR_HSHARD")
	{
		bool flag = false;
		int num = 0;
		Ped character = Game.Player.Character;
		Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
		Weapons.Anim_Weapon_Off();
		character.IsInvincible = true;
		CruelMastersOnlineOffline.LoadDict("anim@deathmatch_intros@unarmed");
		CruelMastersOnlineOffline.LoadDict("anim@heists@team_respawn@variations@variation_c");
		if (!Game.Player.Character.IsDead)
		{
			character.CanRagdoll = false;
			Function.Call(Hash.SET_PED_CONFIG_FLAG, character, 188, true);
			Audios.Stop_Music_Event();
			Function.Call(Hash.SET_HIDOF_OVERRIDE, 1, 1, 0f, Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_NEAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF) + 25f);
			WallFail_In_Progress = true;
			Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, usingactionmode);
			Game.Player.CanControlCharacter = false;
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
			Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFail", 0, false);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FAILED_SCREEN_SOUNDS", true);
			num = Game.GameTime + 2000;
			while (Game.GameTime < num)
			{
				Script.Wait(0);
			}
		}
		else
		{
			flag = true;
		}
		while (Game.Player.Character.IsDead)
		{
			Script.Wait(0);
		}
		if (flag)
		{
			Screen.FadeOut(0);
			Audios.Stop_Music_Event();
			Function.Call(Hash.SET_HIDOF_OVERRIDE, 1, 1, 0f, Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_NEAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF) + 25f);
			WallFail_In_Progress = true;
			Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, usingactionmode);
			Game.Player.CanControlCharacter = false;
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
			Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFail", 0, false);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FAILED_SCREEN_SOUNDS", true);
			Game.Player.Character.Position = beforepos;
			Game.Player.Character.Heading = beforehead;
		}
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		while (FailCam == null)
		{
			FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
			Script.Wait(0);
		}
		Random random = new Random();
		int num2 = random.Next(1, 8);
		if (num2 == 1)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 10f);
		}
		if (num2 == 2)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 1f, 3f, 0f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 10f);
		}
		if (num2 == 3)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 0.5f, 3f, 0f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 12f);
		}
		if (num2 == 4)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 1f, 3f, -1f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 0.5f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 12f);
		}
		if (num2 == 5)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 0f, 2f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 12f);
		}
		if (num2 == 6)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, 0.5f, 0.5f, -1f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, -0.2f, 0f, 1f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 25f);
		}
		if (num2 == 7)
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, FailCam, Game.Player.Character, -0.5f, 2f, 0f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, FailCam, Game.Player.Character, 0.2f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, FailCam, 15f);
		}
		World.RenderingCamera = FailCam;
		Script.Wait(1500);
		Screen.FadeIn(500);
		while (!Screen.IsFadedIn)
		{
			Script.Wait(0);
		}
		Weapons.Anim_Weapon_Off();
		Function.Call(Hash.SET_SEETHROUGH, false);
		Function.Call(Hash.SET_NIGHTVISION, false);
		Function.Call(Hash.SET_ARTIFICIAL_LIGHTS_STATE, false);
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFail", 0, false);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FAILED_SCREEN_SOUNDS", true);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
		DeleteMissionPassScaleform();
		RequestHeistPassScaleform();
		Script.Wait(1000);
		Wall_In_Progress = true;
		Function.Call(Hash.START_AUDIO_SCENE, "MP_CELEB_SCREEN_SCENE");
		HudHandler.HudandRadar(Hud: false, Radar: false);
		CallFunction(MISSIONPASSED, "CLEANUP", "CELEB_FAILED");
		CallFunction(MISSIONPASSED2, "CLEANUP", "CELEB_FAILED");
		CallFunction(MISSIONPASSED3, "CLEANUP", "CELEB_FAILED");
		CallFunction(MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_FAILED", color, 2);
		CallFunction(MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_FAILED", color, 2);
		CallFunction(MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_FAILED", color, 2);
		CallFunction(MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_FAILED", 0, "left");
		CallFunction(MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_FAILED", 0, "left");
		CallFunction(MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_FAILED", 0, "left");
		CallFunction(MISSIONPASSED, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED2, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED3, "PAUSE", "CELEB_FAILED", pausedur);
		CallFunction(MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", alpha, walltype);
		CallFunction(MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", alpha, walltype);
		CallFunction(MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_FAILED", alpha, walltype);
		CallFunction(MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_FAILED");
		CallFunction(MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_FAILED");
		CallFunction(MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_FAILED");
		num = Game.GameTime + 300;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFail");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebFailBW", 0, true);
		num = Game.GameTime + timer;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebFailBW");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebEnd", 0, false);
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		DeleteMissionPassScaleform();
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		PlayerSwitch._SWITCH_OUT_PLAYER(character, 3, 1);
		FailCam.Delete();
		FailCam = null;
		World.RenderingCamera = null;
		Function.Call(Hash.ANIMPOSTFX_STOP_ALL);
		Function.Call(Hash.SET_HIDOF_OVERRIDE, 0, 0, 0f, 0f, 0f, 0f);
		Function.Call(Hash.STOP_AUDIO_SCENES);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
		num = Game.GameTime + 5000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "LEADER_BOARD", "HUD_FRONTEND_DEFAULT_SOUNDSET", true);
		while (!Game.IsControlJustPressed(Control.FrontendRt))
		{
			Scaleform scaleform = new Scaleform("instructional_buttons");
			scaleform.CallFunction("CLEAR_ALL");
			scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
			scaleform.CallFunction("CREATE_CONTAINER");
			scaleform.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 208, 0), "Quick Restart ");
			scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
			scaleform.Render2D();
			Script.Wait(0);
		}
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "LEADER_BOARD", "HUD_FRONTEND_DEFAULT_SOUNDSET", true);
		LoadingPrompt.Show("Loading", LoadingSpinnerType.Clockwise1);
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		Audios.TRIGGER_MUSIC_EVENT(musicarg[0]);
		Audios.TRIGGER_MUSIC_EVENT(musicarg[1]);
		num = Game.GameTime + 5000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		LoadingPrompt.Show("Loading", LoadingSpinnerType.SocialClubSaving);
		num2 = random.Next(pos.Length);
		character.Position = pos[num2];
		character.Heading = heading[num2];
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			LOAD_SCENES.LOAD_SCENE(pos[num2].X, pos[num2].Y, pos[num2].Z);
			Script.Wait(0);
		}
		Cameras.RESET_GAMEPLAY_CAM();
		Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
		Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
		PlayerSwitch.SWITCH_IN_PLAYER(character);
		string[] array = new string[6] { "a", "b", "c", "d", "e", "a" };
		while (CruelMastersOnlineOffline.CutsceneCam == null)
		{
			CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
			Script.Wait(0);
		}
		while (CruelMastersOnlineOffline.CutsceneCam2 == null)
		{
			CruelMastersOnlineOffline.CutsceneCam2 = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
			Script.Wait(0);
		}
		while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
		{
			LOAD_SCENES.LOAD_SCENE(pos[num2].X, pos[num2].Y, pos[num2].Z);
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Script.Wait(0);
		}
		while (World.RenderingCamera != CruelMastersOnlineOffline.CutsceneCam)
		{
			World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
			Script.Wait(0);
		}
		Game.Player.Character.Position = pos[num2];
		Game.Player.Character.Heading = heading[num2];
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 1f, 0f, 0f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, -1f, 0f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 50f);
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.5f, 2f, 0.5f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0f, 0f, 0.3f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam2, 26f);
		Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam2, true);
		Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CruelMastersOnlineOffline.CutsceneCam2, CruelMastersOnlineOffline.CutsceneCam, 5000, 3, 1);
		int num3 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 2);
		int num4 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 5);
		Game.Player.Character.Task.PlayAnimation("anim@deathmatch_intros@unarmed", "intro_male_unarmed_" + array[num4], 1000f, 1f, -1, AnimationFlags.None, 0f);
		LoadingPrompt.Hide();
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
		Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, usingactionmode);
		Mission_Shard_In(6000, shardincolor, missionTextLabel, selectedmission, challengetext, challengepart, targetTypeText, targetValue, 5, "$", literalstring: true, textcolor, pausedur2, alpha2, walltype2);
		while (Wall_In_Progress)
		{
			Script.Wait(0);
		}
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.7983f, -0.9226f, 0.5243f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.2782f, 1.8498f, 0.1298f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 30f);
		Function.Call(Hash.SET_CAM_NEAR_CLIP, CruelMastersOnlineOffline.CutsceneCam2, 0.15f);
		Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_HEADING, 0f);
		Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_PITCH, 0f, 1f);
		Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.1208f, -1.7733f, 0.6538f, true);
		Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.4472f, 1.154f, 0.0844f, true);
		Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam2, 50f);
		Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam2, true);
		Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CruelMastersOnlineOffline.CutsceneCam2, CruelMastersOnlineOffline.CutsceneCam, 3000, 3, 1);
		num = Game.GameTime + 3000;
		while (Game.GameTime < num)
		{
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Script.Wait(0);
		}
		if (CruelMastersOnlineOffline.CutsceneCam != null)
		{
			CruelMastersOnlineOffline.CutsceneCam.Delete();
			CruelMastersOnlineOffline.CutsceneCam = null;
		}
		if (CruelMastersOnlineOffline.CutsceneCam2 != null)
		{
			CruelMastersOnlineOffline.CutsceneCam2.Delete();
			CruelMastersOnlineOffline.CutsceneCam2 = null;
		}
		Function.Call(Hash.SIMULATE_PLAYER_INPUT_GAIT, Game.Player, 1f, 2000, 0f, 1, 0);
		Function.Call(Hash.FORCE_PED_MOTION_STATE, Game.Player, -668482597, true, 1, 0);
		Function.Call(Hash.SET_FOLLOW_PED_CAM_VIEW_MODE, 0);
		Function.Call(Hash.RENDER_SCRIPT_CAMS, false, true, 1000, false, false, 0);
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		Audios.TRIGGER_MUSIC_EVENT(musicarg[2]);
		Screen_Effects.PlayAnimPostFX("MinigameTransitionOut", 1000, looped: false);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hit", "RESPAWN_SOUNDSET", true);
		HudHandler.HudandRadar(Hud: true, Radar: true);
		Game.Player.CanControlCharacter = true;
		Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
		character.IsInvincible = false;
		character.CanRagdoll = true;
		Function.Call(Hash.SET_PED_CONFIG_FLAG, character, 188, false);
		WallFail_In_Progress = false;
	}

	public static void Mission_Pass_In(int timer = 7000, string color = "HUD_COLOUR_WAYPOINTDARK", string missionTextLabel = "", string passFailTextLabel = "", string messageLabel = "", bool isMessageRawText = true, bool isPassFailRawText = true, bool isMissionTextRawText = true, int pausedur = 3, int alpha = 75, int walltype = 1, string[] names = null, string[] challenges = null, string[] chaltext = null, bool[] chalcom = null, int totalchal = 0)
	{
		bool flag = false;
		int num = 0;
		Ped character = Game.Player.Character;
		character.IsInvincible = true;
		if (!Game.Player.Character.IsDead)
		{
			character.CanRagdoll = false;
			Function.Call(Hash.SET_PED_CONFIG_FLAG, character, 188, true);
			Function.Call(Hash.SET_HIDOF_OVERRIDE, 1, 1, 0f, Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_NEAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF) + 25f);
			WallPass_In_Progress = true;
			Game.Player.CanControlCharacter = false;
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebPass");
			Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebPass", 0, false);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_PREP_SCREEN_SOUNDS", true);
		}
		else
		{
			flag = true;
		}
		while (Game.Player.Character.IsDead)
		{
			Script.Wait(0);
		}
		if (flag)
		{
			Function.Call(Hash.SET_HIDOF_OVERRIDE, 1, 1, 0f, Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_NEAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF), Function.Call<float>(Hash.GET_FINAL_RENDERED_CAM_FAR_DOF) + 25f);
			WallPass_In_Progress = true;
			Game.Player.CanControlCharacter = false;
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebPass");
			Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebPass", 0, false);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_PREP_SCREEN_SOUNDS", true);
		}
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			Script.Wait(0);
		}
		while (!Screen.IsFadedIn)
		{
			Script.Wait(0);
		}
		Function.Call(Hash.SET_SEETHROUGH, false);
		Function.Call(Hash.SET_NIGHTVISION, false);
		Function.Call(Hash.SET_ARTIFICIAL_LIGHTS_STATE, false);
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebPass");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebPass", 0, false);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_PREP_SCREEN_SOUNDS", true);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
		DeleteMissionPassScaleform();
		RequestHeistPassScaleform();
		Script.Wait(1000);
		Function.Call(Hash.START_AUDIO_SCENE, "MP_CELEB_SCREEN_SCENE");
		HudHandler.HudandRadar(Hud: false, Radar: false);
		CallFunction(MISSIONPASSED, "CLEANUP", "CELEB_PASSED");
		CallFunction(MISSIONPASSED2, "CLEANUP", "CELEB_PASSED");
		CallFunction(MISSIONPASSED3, "CLEANUP", "CELEB_PASSED");
		CallFunction(MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_PASSED", color, 1);
		CallFunction(MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_PASSED", color, 1);
		CallFunction(MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_PASSED", color, 1);
		CallFunction(MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_PASSED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_PASSED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_PASSED", missionTextLabel, passFailTextLabel, messageLabel, isMessageRawText, isPassFailRawText, isMissionTextRawText);
		CallFunction(MISSIONPASSED, "CREATE_STAT_TABLE", "CELEB_PASSED", "CELEB_PSCORE");
		CallFunction(MISSIONPASSED2, "CREATE_STAT_TABLE", "CELEB_PASSED", "CELEB_PSCORE");
		CallFunction(MISSIONPASSED3, "CREATE_STAT_TABLE", "CELEB_PASSED", "CELEB_PSCORE");
		if (names[0] != "")
		{
			CallFunction(MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[0], "PLATINUM", names[0], true, true, false, "HUD_COLOUR_PLATINUM");
		}
		if (names[0] != "")
		{
			CallFunction(MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[0], "PLATINUM", names[0], true, true, false, "HUD_COLOUR_PLATINUM");
		}
		if (names[0] != "")
		{
			CallFunction(MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[0], "PLATINUM", names[0], true, true, false, "HUD_COLOUR_PLATINUM");
		}
		if (names[1] != "")
		{
			CallFunction(MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[1], "GOLD", names[1], true, true, false, "HUD_COLOUR_GOLD");
		}
		if (names[1] != "")
		{
			CallFunction(MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[1], "GOLD", names[1], true, true, false, "HUD_COLOUR_GOLD");
		}
		if (names[1] != "")
		{
			CallFunction(MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[1], "GOLD", names[1], true, true, false, "HUD_COLOUR_GOLD");
		}
		if (names[2] != "")
		{
			CallFunction(MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[2], "SILVER", names[2], true, true, false, "HUD_COLOUR_SILVER");
		}
		if (names[2] != "")
		{
			CallFunction(MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[2], "SILVER", names[2], true, true, false, "HUD_COLOUR_SILVER");
		}
		if (names[2] != "")
		{
			CallFunction(MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[2], "SILVER", names[2], true, true, false, "HUD_COLOUR_SILVER");
		}
		if (names[3] != "")
		{
			CallFunction(MISSIONPASSED, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[3], "BRONZE", names[3], true, true, false, "HUD_COLOUR_BRONZE");
		}
		if (names[3] != "")
		{
			CallFunction(MISSIONPASSED2, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[3], "BRONZE", names[3], true, true, false, "HUD_COLOUR_BRONZE");
		}
		if (names[3] != "")
		{
			CallFunction(MISSIONPASSED3, "ADD_STAT_TO_TABLE", "CELEB_PASSED", "CELEB_PSCORE", names[3], "BRONZE", names[3], true, true, false, "HUD_COLOUR_BRONZE");
		}
		CallFunction(MISSIONPASSED, "ADD_STAT_TABLE_TO_WALL", "CELEB_PASSED", "CELEB_PSCORE");
		CallFunction(MISSIONPASSED2, "ADD_STAT_TABLE_TO_WALL", "CELEB_PASSED", "CELEB_PSCORE");
		CallFunction(MISSIONPASSED3, "ADD_STAT_TABLE_TO_WALL", "CELEB_PASSED", "CELEB_PSCORE");
		CallFunction(MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_PASSED", 15, "right");
		CallFunction(MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_PASSED", 15, "right");
		CallFunction(MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_PASSED", 15, "right");
		if (challenges != null && chalcom != null && chaltext != null)
		{
			bool[] array = new bool[7];
			CallFunction(MISSIONPASSED, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_PASSED", "SUMMARY");
			CallFunction(MISSIONPASSED2, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_PASSED", "SUMMARY");
			CallFunction(MISSIONPASSED3, "CREATE_INCREMENTAL_CASH_ANIMATION", "CELEB_PASSED", "SUMMARY");
			if (challenges[0] != "")
			{
				if (chalcom[0])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, 1, "ELITE CHALLENGE", challenges[0], chaltext[0], 1, 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, 1, "ELITE CHALLENGE", challenges[0], chaltext[0], 1, 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, 1, "ELITE CHALLENGE", challenges[0], chaltext[0], 1, 3, 1);
					array[0] = true;
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, 1, "ELITE CHALLENGE", challenges[0], chaltext[0], 2, 1, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, 1, "ELITE CHALLENGE", challenges[0], chaltext[0], 2, 1, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, 1, "ELITE CHALLENGE", challenges[0], chaltext[0], 2, 1, 1);
				}
			}
			if (challenges[1] != "")
			{
				if (chalcom[1])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 1, 2, "ELITE CHALLENGE", challenges[1], chaltext[1], 1, 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 1, 2, "ELITE CHALLENGE", challenges[1], chaltext[1], 1, 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 1, 2, "ELITE CHALLENGE", challenges[1], chaltext[1], 1, 3, 1);
					array[1] = true;
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 1, 2, "ELITE CHALLENGE", challenges[1], chaltext[1], 2, 1, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 1, 2, "ELITE CHALLENGE", challenges[1], chaltext[1], 2, 1, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 1, 2, "ELITE CHALLENGE", challenges[1], chaltext[1], 2, 1, 1);
				}
			}
			if (challenges[2] != "")
			{
				if (chalcom[2])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 2, 3, "ELITE CHALLENGE", challenges[2], chaltext[2], 1, 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 2, 3, "ELITE CHALLENGE", challenges[2], chaltext[2], 1, 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 2, 3, "ELITE CHALLENGE", challenges[2], chaltext[2], 1, 3, 1);
					array[2] = true;
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 2, 3, "ELITE CHALLENGE", challenges[2], chaltext[2], 2, 1, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 2, 3, "ELITE CHALLENGE", challenges[2], chaltext[2], 2, 1, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 2, 3, "ELITE CHALLENGE", challenges[2], chaltext[2], 2, 1, 1);
				}
			}
			if (challenges[3] != "")
			{
				if (chalcom[3])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 3, 4, "ELITE CHALLENGE", challenges[3], chaltext[3], 1, 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 3, 4, "ELITE CHALLENGE", challenges[3], chaltext[3], 1, 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 3, 4, "ELITE CHALLENGE", challenges[3], chaltext[3], 1, 3, 1);
					array[3] = true;
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 3, 4, "ELITE CHALLENGE", challenges[3], chaltext[3], 2, 1, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 3, 4, "ELITE CHALLENGE", challenges[3], chaltext[3], 2, 1, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 3, 4, "ELITE CHALLENGE", challenges[3], chaltext[3], 2, 1, 1);
				}
			}
			if (challenges[4] != "")
			{
				if (chalcom[4])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 4, 5, "ELITE CHALLENGE", challenges[4], chaltext[4], 1, 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 4, 5, "ELITE CHALLENGE", challenges[4], chaltext[4], 1, 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 4, 5, "ELITE CHALLENGE", challenges[4], chaltext[4], 1, 3, 1);
					array[4] = true;
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 4, 5, "ELITE CHALLENGE", challenges[4], chaltext[4], 2, 1, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 4, 5, "ELITE CHALLENGE", challenges[4], chaltext[4], 2, 1, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 4, 5, "ELITE CHALLENGE", challenges[4], chaltext[4], 2, 1, 1);
				}
			}
			if (challenges[5] != "")
			{
				if (chalcom[5])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 5, 6, "ELITE CHALLENGE", challenges[5], chaltext[5], 1, 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 5, 6, "ELITE CHALLENGE", challenges[5], chaltext[5], 1, 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 5, 6, "ELITE CHALLENGE", challenges[5], chaltext[5], 1, 3, 1);
					array[5] = true;
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 5, 6, "ELITE CHALLENGE", challenges[5], chaltext[5], 2, 1, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 5, 6, "ELITE CHALLENGE", challenges[5], chaltext[5], 2, 1, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 5, 6, "ELITE CHALLENGE", challenges[5], chaltext[5], 2, 1, 1);
				}
			}
			if (totalchal == 1)
			{
				if (array[0])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
				}
			}
			if (totalchal == 2)
			{
				if (array[0] && array[1])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
				}
			}
			if (totalchal == 3)
			{
				if (array[0] && array[1] && array[2])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
				}
			}
			if (totalchal == 4)
			{
				if (array[0] && array[1] && array[2] && array[3])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
				}
			}
			if (totalchal == 5)
			{
				if (array[0] && array[1] && array[2] && array[3] && array[4])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
				}
			}
			if (totalchal == 6)
			{
				if (array[0] && array[1] && array[2] && array[3] && array[4] && array[5])
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE COMPLETE", "", "", 3, 3);
				}
				else
				{
					CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
					CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_WON_STEP", "CELEB_PASSED", "SUMMARY", 0, totalchal, "ELITE CHALLENGE INCOMPLETE", "", "", 3, 1);
				}
			}
			CallFunction(MISSIONPASSED, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_PASSED", "SUMMARY");
			CallFunction(MISSIONPASSED2, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_PASSED", "SUMMARY");
			CallFunction(MISSIONPASSED3, "ADD_INCREMENTAL_CASH_ANIMATION_TO_WALL", "CELEB_PASSED", "SUMMARY");
		}
		CallFunction(MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_PASSED", alpha, walltype);
		CallFunction(MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_PASSED", alpha, walltype);
		CallFunction(MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_PASSED", alpha, walltype);
		CallFunction(MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_PASSED");
		CallFunction(MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_PASSED");
		CallFunction(MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_PASSED");
		num = Game.GameTime + 300;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebPass");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebPassBW", 0, true);
		Audios.TRIGGER_MUSIC_EVENT("HEIST_STATS_SCREEN_START");
		num = Game.GameTime + timer;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Function.Call(Hash.ANIMPOSTFX_STOP, "HeistCelebPassBW");
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebEnd", 0, false);
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		Heist_Hud.CHALLENGE_RESET();
		DeleteMissionPassScaleform();
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		Screen.FadeOut(2000);
		while (Screen.IsFadingOut)
		{
			Script.Wait(0);
		}
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
		Function.Call(Hash.ANIMPOSTFX_STOP_ALL);
		Function.Call(Hash.SET_HIDOF_OVERRIDE, 0, 0, 0f, 0f, 0f, 0f);
		Function.Call(Hash.STOP_AUDIO_SCENES);
		num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		LoadingPrompt.Show("Loading", LoadingSpinnerType.Clockwise1);
		num = Game.GameTime + 5000;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		LoadingPrompt.Show("Saving", LoadingSpinnerType.Clockwise1);
		Audios.TRIGGER_MUSIC_EVENT("HEIST_STATS_SCREEN_STOP");
		num = Game.GameTime + 2000;
		while (Game.GameTime < num)
		{
			MissionCelebrate(MISSIONPASSED, MISSIONPASSED2, MISSIONPASSED3);
			Script.Wait(0);
		}
		LoadingPrompt.Hide();
		character.IsInvincible = false;
		character.CanRagdoll = true;
		Function.Call(Hash.SET_PED_CONFIG_FLAG, character, 188, false);
		WallPass_In_Progress = false;
	}

	public static void CallFunction(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
	}

	public static bool CallFunctionBool(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
		while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
		{
			Script.Yield();
		}
		return Function.Call<bool>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_BOOL, num);
	}

	public static int CallFunctionInt(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
		while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
		{
			Script.Yield();
		}
		return Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, num);
	}

	public static string CallFunctionString(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
		while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
		{
			Script.Yield();
		}
		return Function.Call<string>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_STRING, num);
	}

	public static void func_string_parm(string text)
	{
		Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING, text);
	}

	public static void func_string_parm2(string textheading)
	{
		Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING, textheading);
	}

	public static void ScaleformINT(int uParam2)
	{
		Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, uParam2);
	}

	public static void ScaleformFLOAT(float uParam1)
	{
		Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, uParam1);
	}

	public static void ScaleformBOOL(bool uParam0)
	{
		Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, uParam0);
	}

	public static int GET_TOTAL_WALL_DURATION()
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
		int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
		while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
		{
			Script.Wait(0);
		}
		int num2 = Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, num);
		if (CruelMastersOnlineOffline.DEBUG)
		{
			Notification.Show($"{num2}");
		}
		return num2;
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
