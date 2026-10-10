using System;
using System.Collections.Generic;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Mobile_Phone : Script
{
	public enum CONTROLS
	{
		INPUT_NEXT_CAMERA,
		INPUT_LOOK_LR,
		INPUT_LOOK_UD,
		INPUT_LOOK_UP_ONLY,
		INPUT_LOOK_DOWN_ONLY,
		INPUT_LOOK_LEFT_ONLY,
		INPUT_LOOK_RIGHT_ONLY,
		INPUT_CINEMATIC_SLOWMO,
		INPUT_SCRIPTED_FLY_UD,
		INPUT_SCRIPTED_FLY_LR,
		INPUT_SCRIPTED_FLY_ZUP,
		INPUT_SCRIPTED_FLY_ZDOWN,
		INPUT_WEAPON_WHEEL_UD,
		INPUT_WEAPON_WHEEL_LR,
		INPUT_WEAPON_WHEEL_NEXT,
		INPUT_WEAPON_WHEEL_PREV,
		INPUT_SELECT_NEXT_WEAPON,
		INPUT_SELECT_PREV_WEAPON,
		INPUT_SKIP_CUTSCENE,
		INPUT_CHARACTER_WHEEL,
		INPUT_MULTIPLAYER_INFO,
		INPUT_SPRINT,
		INPUT_JUMP,
		INPUT_ENTER,
		INPUT_ATTACK,
		INPUT_AIM,
		INPUT_LOOK_BEHIND,
		INPUT_PHONE,
		INPUT_SPECIAL_ABILITY,
		INPUT_SPECIAL_ABILITY_SECONDARY,
		INPUT_MOVE_LR,
		INPUT_MOVE_UD,
		INPUT_MOVE_UP_ONLY,
		INPUT_MOVE_DOWN_ONLY,
		INPUT_MOVE_LEFT_ONLY,
		INPUT_MOVE_RIGHT_ONLY,
		INPUT_DUCK,
		INPUT_SELECT_WEAPON,
		INPUT_PICKUP,
		INPUT_SNIPER_ZOOM,
		INPUT_SNIPER_ZOOM_IN_ONLY,
		INPUT_SNIPER_ZOOM_OUT_ONLY,
		INPUT_SNIPER_ZOOM_IN_SECONDARY,
		INPUT_SNIPER_ZOOM_OUT_SECONDARY,
		INPUT_COVER,
		INPUT_RELOAD,
		INPUT_TALK,
		INPUT_DETONATE,
		INPUT_HUD_SPECIAL,
		INPUT_ARREST,
		INPUT_ACCURATE_AIM,
		INPUT_CONTEXT,
		INPUT_CONTEXT_SECONDARY,
		INPUT_WEAPON_SPECIAL,
		INPUT_WEAPON_SPECIAL_TWO,
		INPUT_DIVE,
		INPUT_DROP_WEAPON,
		INPUT_DROP_AMMO,
		INPUT_THROW_GRENADE,
		INPUT_VEH_MOVE_LR,
		INPUT_VEH_MOVE_UD,
		INPUT_VEH_MOVE_UP_ONLY,
		INPUT_VEH_MOVE_DOWN_ONLY,
		INPUT_VEH_MOVE_LEFT_ONLY,
		INPUT_VEH_MOVE_RIGHT_ONLY,
		INPUT_VEH_SPECIAL,
		INPUT_VEH_GUN_LR,
		INPUT_VEH_GUN_UD,
		INPUT_VEH_AIM,
		INPUT_VEH_ATTACK,
		INPUT_VEH_ATTACK2,
		INPUT_VEH_ACCELERATE,
		INPUT_VEH_BRAKE,
		INPUT_VEH_DUCK,
		INPUT_VEH_HEADLIGHT,
		INPUT_VEH_EXIT,
		INPUT_VEH_HANDBRAKE,
		INPUT_VEH_HOTWIRE_LEFT,
		INPUT_VEH_HOTWIRE_RIGHT,
		INPUT_VEH_LOOK_BEHIND,
		INPUT_VEH_CIN_CAM,
		INPUT_VEH_NEXT_RADIO,
		INPUT_VEH_PREV_RADIO,
		INPUT_VEH_NEXT_RADIO_TRACK,
		INPUT_VEH_PREV_RADIO_TRACK,
		INPUT_VEH_RADIO_WHEEL,
		INPUT_VEH_HORN,
		INPUT_VEH_FLY_THROTTLE_UP,
		INPUT_VEH_FLY_THROTTLE_DOWN,
		INPUT_VEH_FLY_YAW_LEFT,
		INPUT_VEH_FLY_YAW_RIGHT,
		INPUT_VEH_PASSENGER_AIM,
		INPUT_VEH_PASSENGER_ATTACK,
		INPUT_VEH_SPECIAL_ABILITY_FRANKLIN,
		INPUT_VEH_STUNT_UD,
		INPUT_VEH_CINEMATIC_UD,
		INPUT_VEH_CINEMATIC_UP_ONLY,
		INPUT_VEH_CINEMATIC_DOWN_ONLY,
		INPUT_VEH_CINEMATIC_LR,
		INPUT_VEH_SELECT_NEXT_WEAPON,
		INPUT_VEH_SELECT_PREV_WEAPON,
		INPUT_VEH_ROOF,
		INPUT_VEH_JUMP,
		INPUT_VEH_GRAPPLING_HOOK,
		INPUT_VEH_SHUFFLE,
		INPUT_VEH_DROP_PROJECTILE,
		INPUT_VEH_MOUSE_CONTROL_OVERRIDE,
		INPUT_VEH_FLY_ROLL_LR,
		INPUT_VEH_FLY_ROLL_LEFT_ONLY,
		INPUT_VEH_FLY_ROLL_RIGHT_ONLY,
		INPUT_VEH_FLY_PITCH_UD,
		INPUT_VEH_FLY_PITCH_UP_ONLY,
		INPUT_VEH_FLY_PITCH_DOWN_ONLY,
		INPUT_VEH_FLY_UNDERCARRIAGE,
		INPUT_VEH_FLY_ATTACK,
		INPUT_VEH_FLY_SELECT_NEXT_WEAPON,
		INPUT_VEH_FLY_SELECT_PREV_WEAPON,
		INPUT_VEH_FLY_SELECT_TARGET_LEFT,
		INPUT_VEH_FLY_SELECT_TARGET_RIGHT,
		INPUT_VEH_FLY_VERTICAL_FLIGHT_MODE,
		INPUT_VEH_FLY_DUCK,
		INPUT_VEH_FLY_ATTACK_CAMERA,
		INPUT_VEH_FLY_MOUSE_CONTROL_OVERRIDE,
		INPUT_VEH_SUB_TURN_LR,
		INPUT_VEH_SUB_TURN_LEFT_ONLY,
		INPUT_VEH_SUB_TURN_RIGHT_ONLY,
		INPUT_VEH_SUB_PITCH_UD,
		INPUT_VEH_SUB_PITCH_UP_ONLY,
		INPUT_VEH_SUB_PITCH_DOWN_ONLY,
		INPUT_VEH_SUB_THROTTLE_UP,
		INPUT_VEH_SUB_THROTTLE_DOWN,
		INPUT_VEH_SUB_ASCEND,
		INPUT_VEH_SUB_DESCEND,
		INPUT_VEH_SUB_TURN_HARD_LEFT,
		INPUT_VEH_SUB_TURN_HARD_RIGHT,
		INPUT_VEH_SUB_MOUSE_CONTROL_OVERRIDE,
		INPUT_VEH_PUSHBIKE_PEDAL,
		INPUT_VEH_PUSHBIKE_SPRINT,
		INPUT_VEH_PUSHBIKE_FRONT_BRAKE,
		INPUT_VEH_PUSHBIKE_REAR_BRAKE,
		INPUT_MELEE_ATTACK_LIGHT,
		INPUT_MELEE_ATTACK_HEAVY,
		INPUT_MELEE_ATTACK_ALTERNATE,
		INPUT_MELEE_BLOCK,
		INPUT_PARACHUTE_DEPLOY,
		INPUT_PARACHUTE_DETACH,
		INPUT_PARACHUTE_TURN_LR,
		INPUT_PARACHUTE_TURN_LEFT_ONLY,
		INPUT_PARACHUTE_TURN_RIGHT_ONLY,
		INPUT_PARACHUTE_PITCH_UD,
		INPUT_PARACHUTE_PITCH_UP_ONLY,
		INPUT_PARACHUTE_PITCH_DOWN_ONLY,
		INPUT_PARACHUTE_BRAKE_LEFT,
		INPUT_PARACHUTE_BRAKE_RIGHT,
		INPUT_PARACHUTE_SMOKE,
		INPUT_PARACHUTE_PRECISION_LANDING,
		INPUT_MAP,
		INPUT_SELECT_WEAPON_UNARMED,
		INPUT_SELECT_WEAPON_MELEE,
		INPUT_SELECT_WEAPON_HANDGUN,
		INPUT_SELECT_WEAPON_SHOTGUN,
		INPUT_SELECT_WEAPON_SMG,
		INPUT_SELECT_WEAPON_AUTO_RIFLE,
		INPUT_SELECT_WEAPON_SNIPER,
		INPUT_SELECT_WEAPON_HEAVY,
		INPUT_SELECT_WEAPON_SPECIAL,
		INPUT_SELECT_CHARACTER_MICHAEL,
		INPUT_SELECT_CHARACTER_FRANKLIN,
		INPUT_SELECT_CHARACTER_TREVOR,
		INPUT_SELECT_CHARACTER_MULTIPLAYER,
		INPUT_SAVE_REPLAY_CLIP,
		INPUT_SPECIAL_ABILITY_PC,
		INPUT_CELLPHONE_UP,
		INPUT_CELLPHONE_DOWN,
		INPUT_CELLPHONE_LEFT,
		INPUT_CELLPHONE_RIGHT,
		INPUT_CELLPHONE_SELECT,
		INPUT_CELLPHONE_CANCEL,
		INPUT_CELLPHONE_OPTION,
		INPUT_CELLPHONE_EXTRA_OPTION,
		INPUT_CELLPHONE_SCROLL_FORWARD,
		INPUT_CELLPHONE_SCROLL_BACKWARD,
		INPUT_CELLPHONE_CAMERA_FOCUS_LOCK,
		INPUT_CELLPHONE_CAMERA_GRID,
		INPUT_CELLPHONE_CAMERA_SELFIE,
		INPUT_CELLPHONE_CAMERA_DOF,
		INPUT_CELLPHONE_CAMERA_EXPRESSION,
		INPUT_FRONTEND_DOWN,
		INPUT_FRONTEND_UP,
		INPUT_FRONTEND_LEFT,
		INPUT_FRONTEND_RIGHT,
		INPUT_FRONTEND_RDOWN,
		INPUT_FRONTEND_RUP,
		INPUT_FRONTEND_RLEFT,
		INPUT_FRONTEND_RRIGHT,
		INPUT_FRONTEND_AXIS_X,
		INPUT_FRONTEND_AXIS_Y,
		INPUT_FRONTEND_RIGHT_AXIS_X,
		INPUT_FRONTEND_RIGHT_AXIS_Y,
		INPUT_FRONTEND_PAUSE,
		INPUT_FRONTEND_PAUSE_ALTERNATE,
		INPUT_FRONTEND_ACCEPT,
		INPUT_FRONTEND_CANCEL,
		INPUT_FRONTEND_X,
		INPUT_FRONTEND_Y,
		INPUT_FRONTEND_LB,
		INPUT_FRONTEND_RB,
		INPUT_FRONTEND_LT,
		INPUT_FRONTEND_RT,
		INPUT_FRONTEND_LS,
		INPUT_FRONTEND_RS,
		INPUT_FRONTEND_LEADERBOARD,
		INPUT_FRONTEND_SOCIAL_CLUB,
		INPUT_FRONTEND_SOCIAL_CLUB_SECONDARY,
		INPUT_FRONTEND_DELETE,
		INPUT_FRONTEND_ENDSCREEN_ACCEPT,
		INPUT_FRONTEND_ENDSCREEN_EXPAND,
		INPUT_FRONTEND_SELECT,
		INPUT_SCRIPT_LEFT_AXIS_X,
		INPUT_SCRIPT_LEFT_AXIS_Y,
		INPUT_SCRIPT_RIGHT_AXIS_X,
		INPUT_SCRIPT_RIGHT_AXIS_Y,
		INPUT_SCRIPT_RUP,
		INPUT_SCRIPT_RDOWN,
		INPUT_SCRIPT_RLEFT,
		INPUT_SCRIPT_RRIGHT,
		INPUT_SCRIPT_LB,
		INPUT_SCRIPT_RB,
		INPUT_SCRIPT_LT,
		INPUT_SCRIPT_RT,
		INPUT_SCRIPT_LS,
		INPUT_SCRIPT_RS,
		INPUT_SCRIPT_PAD_UP,
		INPUT_SCRIPT_PAD_DOWN,
		INPUT_SCRIPT_PAD_LEFT,
		INPUT_SCRIPT_PAD_RIGHT,
		INPUT_SCRIPT_SELECT,
		INPUT_CURSOR_ACCEPT,
		INPUT_CURSOR_CANCEL,
		INPUT_CURSOR_X,
		INPUT_CURSOR_Y,
		INPUT_CURSOR_SCROLL_UP,
		INPUT_CURSOR_SCROLL_DOWN,
		INPUT_ENTER_CHEAT_CODE,
		INPUT_INTERACTION_MENU,
		INPUT_MP_TEXT_CHAT_ALL,
		INPUT_MP_TEXT_CHAT_TEAM,
		INPUT_MP_TEXT_CHAT_FRIENDS,
		INPUT_MP_TEXT_CHAT_CREW,
		INPUT_PC_PUSH_TO_TALK,
		INPUT_CREATOR_LS,
		INPUT_CREATOR_RS,
		INPUT_CREATOR_LT,
		INPUT_CREATOR_RT,
		INPUT_CREATOR_MENU_TOGGLE,
		INPUT_CREATOR_ACCEPT,
		INPUT_CREATOR_DELETE,
		INPUT_ATTACK2,
		INPUT_RAPPEL_JUMP,
		INPUT_RAPPEL_LONG_JUMP,
		INPUT_RAPPEL_SMASH_WINDOW,
		INPUT_PREV_WEAPON,
		INPUT_NEXT_WEAPON,
		INPUT_MELEE_ATTACK1,
		INPUT_MELEE_ATTACK2,
		INPUT_WHISTLE,
		INPUT_MOVE_LEFT,
		INPUT_MOVE_RIGHT,
		INPUT_MOVE_UP,
		INPUT_MOVE_DOWN,
		INPUT_LOOK_LEFT,
		INPUT_LOOK_RIGHT,
		INPUT_LOOK_UP,
		INPUT_LOOK_DOWN,
		INPUT_SNIPER_ZOOM_IN,
		INPUT_SNIPER_ZOOM_OUT,
		INPUT_SNIPER_ZOOM_IN_ALTERNATE,
		INPUT_SNIPER_ZOOM_OUT_ALTERNATE,
		INPUT_VEH_MOVE_LEFT,
		INPUT_VEH_MOVE_RIGHT,
		INPUT_VEH_MOVE_UP,
		INPUT_VEH_MOVE_DOWN,
		INPUT_VEH_GUN_LEFT,
		INPUT_VEH_GUN_RIGHT,
		INPUT_VEH_GUN_UP,
		INPUT_VEH_GUN_DOWN,
		INPUT_VEH_LOOK_LEFT,
		INPUT_VEH_LOOK_RIGHT,
		INPUT_REPLAY_START_STOP_RECORDING,
		INPUT_REPLAY_START_STOP_RECORDING_SECONDARY,
		INPUT_SCALED_LOOK_LR,
		INPUT_SCALED_LOOK_UD,
		INPUT_SCALED_LOOK_UP_ONLY,
		INPUT_SCALED_LOOK_DOWN_ONLY,
		INPUT_SCALED_LOOK_LEFT_ONLY,
		INPUT_SCALED_LOOK_RIGHT_ONLY,
		INPUT_REPLAY_MARKER_DELETE,
		INPUT_REPLAY_CLIP_DELETE,
		INPUT_REPLAY_PAUSE,
		INPUT_REPLAY_REWIND,
		INPUT_REPLAY_FFWD,
		INPUT_REPLAY_NEWMARKER,
		INPUT_REPLAY_RECORD,
		INPUT_REPLAY_SCREENSHOT,
		INPUT_REPLAY_HIDEHUD,
		INPUT_REPLAY_STARTPOINT,
		INPUT_REPLAY_ENDPOINT,
		INPUT_REPLAY_ADVANCE,
		INPUT_REPLAY_BACK,
		INPUT_REPLAY_TOOLS,
		INPUT_REPLAY_RESTART,
		INPUT_REPLAY_SHOWHOTKEY,
		INPUT_REPLAY_CYCLEMARKERLEFT,
		INPUT_REPLAY_CYCLEMARKERRIGHT,
		INPUT_REPLAY_FOVINCREASE,
		INPUT_REPLAY_FOVDECREASE,
		INPUT_REPLAY_CAMERAUP,
		INPUT_REPLAY_CAMERADOWN,
		INPUT_REPLAY_SAVE,
		INPUT_REPLAY_TOGGLETIME,
		INPUT_REPLAY_TOGGLETIPS,
		INPUT_REPLAY_PREVIEW,
		INPUT_REPLAY_TOGGLE_TIMELINE,
		INPUT_REPLAY_TIMELINE_PICKUP_CLIP,
		INPUT_REPLAY_TIMELINE_DUPLICATE_CLIP,
		INPUT_REPLAY_TIMELINE_PLACE_CLIP,
		INPUT_REPLAY_CTRL,
		INPUT_REPLAY_TIMELINE_SAVE,
		INPUT_REPLAY_PREVIEW_AUDIO,
		INPUT_VEH_DRIVE_LOOK,
		INPUT_VEH_DRIVE_LOOK2,
		INPUT_VEH_FLY_ATTACK2,
		INPUT_RADIO_WHEEL_UD,
		INPUT_RADIO_WHEEL_LR,
		INPUT_VEH_SLOWMO_UP,
		INPUT_VEH_SLOWMO_UP_ONLY,
		INPUT_VEH_SLOWMO_DOWN_ONLY,
		INPUT_VEH_HYDRAULICS_CONTROL_TOGGLE,
		INPUT_VEH_HYDRAULICS_CONTROL_LEFT,
		INPUT_VEH_HYDRAULICS_CONTROL_RIGHT,
		INPUT_VEH_HYDRAULICS_CONTROL_UP,
		INPUT_VEH_HYDRAULICS_CONTROL_DOWN,
		INPUT_VEH_HYDRAULICS_CONTROL_LR,
		INPUT_VEH_HYDRAULICS_CONTROL_UD,
		INPUT_SWITCH_VISOR,
		INPUT_VEH_MELEE_HOLD,
		INPUT_VEH_MELEE_LEFT,
		INPUT_VEH_MELEE_RIGHT,
		INPUT_MAP_POI,
		INPUT_REPLAY_SNAPMATIC_PHOTO,
		INPUT_VEH_CAR_JUMP,
		INPUT_VEH_ROCKET_BOOST,
		INPUT_VEH_FLY_BOOST,
		INPUT_VEH_PARACHUTE,
		INPUT_VEH_BIKE_WINGS,
		INPUT_VEH_FLY_BOMB_BAY,
		INPUT_VEH_FLY_COUNTER,
		INPUT_VEH_TRANSFORM,
		INPUT_QUAD_LOCO_REVERSE,
		INPUT_RESPAWN_FASTER,
		INPUT_HUDMARKER_SELECT,
		INPUT_EAT_SNACK,
		INPUT_USE_ARMOR,
		MAX_INPUTS
	}

	public static bool PHONE_OPEN = false;

	public static bool CALL_ACTIVE = false;

	public static bool PHONE_LOADED = false;

	public static bool APP_ACTIVE = false;

	public static bool MESSAGE_ACTIVE = false;

	public static bool CAN_CALL = false;

	public static bool CAN_OPEN_PHONE = true;

	public static int MobileID = -1;

	public static int CELLPHONE_IFRUIT = 0;

	public static int currentselection;

	public static int getcurrentselection;

	public static int MouseCheck;

	public static int ScrollTimer = Game.GameTime + 100;

	public static int CurrentEmailAmount = 0;

	public static int CurrentTextAmount = 0;

	public static int CurrentContactAmount = 0;

	public static int CurrentAppActive = -1;

	public static List<string> Text_Contact = new List<string>();

	public static List<string> Text_Message = new List<string>();

	public static List<string> Text_Pic = new List<string>();

	public static List<string> Email_Contact = new List<string>();

	public static List<string> Email_Message = new List<string>();

	public static List<string> Email_Message2 = new List<string>();

	public static List<string> Email_Message3 = new List<string>();

	public static List<string> Email_Pic = new List<string>();

	public static List<string> Email_PicID = new List<string>();

	public static List<string> Contact_Contact = new List<string>();

	public static List<string> Contact_Pic = new List<string>();

	public static string CurrentInContact = "char_default";

	public static int IdleTimer = 0;

	public static bool CallVL = false;

	public unsafe static void DeleteCALLSCREENScaleform()
	{
		int cELLPHONE_IFRUIT = CELLPHONE_IFRUIT;
		Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &cELLPHONE_IFRUIT);
		CELLPHONE_IFRUIT = 0;
	}

	public static void RequestCALLSCREENScaleform()
	{
		CELLPHONE_IFRUIT = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "CELLPHONE_IFRUIT");
	}

	public static void DrawCellphoneCallScaleform()
	{
		Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, CELLPHONE_IFRUIT, 1);
		Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, CELLPHONE_IFRUIT, true);
		Function.Call(Hash.SET_TEXT_RENDER_ID, MobileID);
		Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
		Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
		Function.Call(Hash.DRAW_SCALEFORM_MOVIE, CELLPHONE_IFRUIT, 0.1f, 0.179f, 0.2f, 0.356f, 255, 255, 255, 255);
		Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
	}

	public Mobile_Phone()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!PHONE_LOADED)
		{
			DeleteCALLSCREENScaleform();
			Script.Wait(50);
			DeleteCALLSCREENScaleform();
			RequestCALLSCREENScaleform();
			Script.Wait(50);
			Text_Contact.Clear();
			Text_Message.Clear();
			Text_Pic.Clear();
			Email_Contact.Clear();
			Email_Message.Clear();
			Email_Message2.Clear();
			Email_Message3.Clear();
			Email_Pic.Clear();
			Email_PicID.Clear();
			PHONE_LOADED = true;
		}
		if (Game.IsControlJustPressed(Control.Context))
		{
		}
		if (Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
		if (CAN_OPEN_PHONE && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Hud.IsVisible && Hud.IsRadarVisible && Cutscenes.HAS_CUTSCENE_FINISHED() && !Game.Player.Character.IsDead && !Hud.IsComponentActive(HudComponent.WeaponWheel) && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL)
		{
			if (!CALL_ACTIVE)
			{
				if (PHONE_OPEN)
				{
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_ATTACK, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_ATTACK2, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_AIM, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_VEH_FLY_ATTACK, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_MELEE_ATTACK_LIGHT, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_MELEE_ATTACK_HEAVY, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_VEH_SELECT_NEXT_WEAPON, true);
					if (Game.IsControlJustPressed(Control.PhoneCancel) && !APP_ACTIVE)
					{
						CLOSE_PHONE();
					}
					TitleBarTime();
					DrawCellphoneCallScaleform();
					PhoneSelection();
				}
				else if (Game.IsControlJustPressed(Control.Phone))
				{
					OPEN_PHONE();
				}
				return;
			}
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_ATTACK, true);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_ATTACK2, true);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_AIM, true);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_VEH_FLY_ATTACK, true);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_MELEE_ATTACK_LIGHT, true);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_MELEE_ATTACK_HEAVY, true);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, CONTROLS.INPUT_VEH_SELECT_NEXT_WEAPON, true);
			TitleBarTime();
			DrawCellphoneCallScaleform();
			if (!(CurrentInContact != "char_default"))
			{
				return;
			}
			int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1, 4);
			switch (CurrentInContact)
			{
			case "Gerald":
				if (CAN_CALL)
				{
					if (!CallVL)
					{
						Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
						Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
						Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "GERALD");
						Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_HUAA", "GERALD", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
						Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
						MPGeraldCMS.GeraldContact.Visible = true;
						IdleTimer = Game.GameTime + 10000;
						CallVL = true;
						break;
					}
					if (Game.GameTime > IdleTimer)
					{
						Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
						Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
						Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "GERALD");
						Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_HVAA", "GERALD", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
						Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
						IdleTimer = Game.GameTime + 10000;
					}
					if (Game.IsControlJustPressed(Control.PhoneCancel))
					{
						Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
						Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
						Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "GERALD");
						Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_HXAA", "GERALD", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
						Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
						MPGeraldCMS.GeraldContact.Visible = false;
						int num4 = Game.GameTime + 4000;
						while (Game.GameTime < num4)
						{
							DrawCellphoneCallScaleform();
							Script.Wait(0);
						}
						CurrentInContact = "char_default";
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 2f, Function.Call<int>(Hash.TO_FLOAT, 0));
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, 9f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hang_Up", "Phone_SoundSet_Default", true);
						APP_ACTIVE = true;
						CALL_ACTIVE = false;
						CallVL = false;
						IdleTimer = Game.GameTime + 10000;
					}
				}
				else
				{
					Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
					Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
					Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "GERALD");
					Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_HZAA", "GERALD", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
					Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
					int num5 = Game.GameTime + 5000;
					while (Game.GameTime < num5)
					{
						DrawCellphoneCallScaleform();
						Script.Wait(0);
					}
					MPGeraldCMS.GeraldContact.Visible = false;
					CurrentInContact = "char_default";
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 2f, Function.Call<int>(Hash.TO_FLOAT, 0));
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, 9f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hang_Up", "Phone_SoundSet_Default", true);
					APP_ACTIVE = true;
					CALL_ACTIVE = false;
					CallVL = false;
				}
				break;
			case "Simeon":
				if (CAN_CALL)
				{
					if (!CallVL)
					{
						Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
						Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
						Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "SIMEON");
						Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_FRAA", "SIMEON", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
						Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
						MPSimeonCMS.SimeonContact.Visible = true;
						IdleTimer = Game.GameTime + 10000;
						CallVL = true;
						break;
					}
					if (Game.GameTime > IdleTimer)
					{
						Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
						Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
						Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "SIMEON");
						Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_GEAA", "SIMEON", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
						Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
						IdleTimer = Game.GameTime + 10000;
					}
					if (Game.IsControlJustPressed(Control.PhoneCancel))
					{
						Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
						Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
						Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "SIMEON");
						Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_IQAA", "SIMEON", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
						Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
						MPSimeonCMS.SimeonContact.Visible = false;
						int num2 = Game.GameTime + 4000;
						while (Game.GameTime < num2)
						{
							DrawCellphoneCallScaleform();
							Script.Wait(0);
						}
						CurrentInContact = "char_default";
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 2f, Function.Call<int>(Hash.TO_FLOAT, 0));
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, 9f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hang_Up", "Phone_SoundSet_Default", true);
						APP_ACTIVE = true;
						CALL_ACTIVE = false;
						CallVL = false;
						IdleTimer = Game.GameTime + 10000;
					}
				}
				else
				{
					Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
					Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
					Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "SIMEON");
					Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_GBAA", "SIMEON", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
					Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
					int num3 = Game.GameTime + 5000;
					while (Game.GameTime < num3)
					{
						DrawCellphoneCallScaleform();
						Script.Wait(0);
					}
					MPSimeonCMS.SimeonContact.Visible = false;
					CurrentInContact = "char_default";
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 2f, Function.Call<int>(Hash.TO_FLOAT, 0));
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, 9f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hang_Up", "Phone_SoundSet_Default", true);
					APP_ACTIVE = true;
					CALL_ACTIVE = false;
					CallVL = false;
				}
				break;
			}
		}
		else if (PHONE_OPEN && !Cellphone_Camera.Camera_Active)
		{
			CLOSE_PHONE();
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		DESTROY_PHONE();
		Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 242, false);
		Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 243, false);
		Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 244, false);
		if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "npcphone"))
		{
			Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "npcphone");
		}
		if (Function.Call<bool>(Hash.IS_PED_RINGTONE_PLAYING, Game.Player.Character))
		{
			Function.Call(Hash.STOP_PED_RINGTONE, Game.Player.Character);
		}
		if (PHONE_LOADED)
		{
			DeleteCALLSCREENScaleform();
		}
		Text_Contact.Clear();
		Text_Message.Clear();
		Text_Pic.Clear();
	}

	public static void CLOSE_PHONE_AND_CAMERA()
	{
		Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, true, 0);
		Function.Call(Hash.FREEZE_ENTITY_POSITION, Game.Player.Character, false);
		HudHandler.HudandRadar(Hud: true, Radar: true);
		Game.Player.Character.IsVisible = true;
		Cellphone_Camera.CellCam.Delete();
		Cellphone_Camera.CellCam = null;
		World.RenderingCamera = null;
		Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
		Cellphone_Camera.ButtonPressTimer = Game.GameTime + 2000;
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Put_Away", "Phone_SoundSet_Default", true);
		Cellphone_Camera.Camera_Active = false;
		CLOSE_PHONE();
	}

	public unsafe static void OPEN_PHONE()
	{
		MobileID = -1;
		if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "npcphone"))
		{
			return;
		}
		Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "npcphone", 0);
		Script.Wait(0);
		if (!Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_LINKED, CruelMastersOnlineOffline.joaat("prop_npc_phone")))
		{
			Function.Call(Hash.LINK_NAMED_RENDERTARGET, CruelMastersOnlineOffline.joaat("prop_npc_phone"));
			Script.Wait(0);
			int mobileID = 0;
			Function.Call(Hash.GET_MOBILE_PHONE_RENDER_ID, &mobileID);
			MobileID = mobileID;
			TitleBarTime();
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SLEEP_MODE", false);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 2f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_THEME", 5);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_BACKGROUND_IMAGE", 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 1);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 0, 4, "Email", "Email", "Email", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 1, 2, "Texts", "Texts", "Texts", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 2, 5, "Contacts", "Contacts", "Contacts", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 3, 14, "Play Quick Job", "Play Quick Job", "Play Quick Job", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 4, 12, "Job List", "Job List", "Job List", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 5, 24, "Settings", "Settings", "Settings", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 6, 1, "Snapmatic", "Snapmatic", "Snapmatic", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 7, 6, "Internet", "Internet", "Internet", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 1, 8, 3, "Empty", "Empty", "Empty", "CELL_217", "CELL_217");
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
			Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 242, true);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 243, true);
			Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 244, true);
			CREATE_PHONE(0);
			if (Function.Call<bool>(Hash.GET_IS_HIDEF))
			{
				SET_MOBILE_PHONE_POSITION(Function.Call<float>(Hash.GET_SAFE_ZONE_SIZE) * 117.2f, -50f, -113f);
			}
			else
			{
				SET_MOBILE_PHONE_POSITION(Function.Call<float>(Hash.GET_SAFE_ZONE_SIZE) * 85.7f, -35f, -91.5f);
			}
			SET_MOBILE_PHONE_ROTATION(-90f, 0f, 0f);
			SET_MOBILE_PHONE_SCALE(500f);
			if (!CALL_ACTIVE)
			{
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pull_Out", "Phone_SoundSet_Default", true);
			}
			PHONE_OPEN = true;
		}
	}

	public static void CLOSE_PHONE()
	{
		if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "npcphone"))
		{
			Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "npcphone");
		}
		MobileID = -1;
		DESTROY_PHONE();
		Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 242, false);
		Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 243, false);
		Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 244, false);
		if (!CALL_ACTIVE)
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Put_Away", "Phone_SoundSet_Default", true);
		}
		APP_ACTIVE = false;
		MESSAGE_ACTIVE = false;
		CurrentAppActive = -1;
		PHONE_OPEN = false;
	}

	public static void SETUP_PHONECALL(string contactname, string txd, string callstate, string callstate2, bool isDialing = false, int timetodial = 4000, int timetoanswer = 6000)
	{
		CALL_ACTIVE = true;
		CLOSE_PHONE();
		CruelMastersOnlineOffline.LoadTexureDict(txd);
		Script.Wait(50);
		OPEN_PHONE();
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
		int num = 0;
		if (!isDialing)
		{
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 155, 255);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, -1f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 0, 15);
		}
		else
		{
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, -1f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 155, 255);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 6f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
			Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 0, 15);
		}
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 4);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 4, 0, 2, contactname, txd, callstate, "CELL_217", "CELL_217");
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 4f, Function.Call<int>(Hash.TO_FLOAT, 0));
		if (!isDialing)
		{
			Function.Call(Hash.PLAY_PED_RINGTONE, "Remote_Ring", Game.Player.Character, 1);
			num = Game.GameTime + timetodial;
			while (Game.GameTime < num)
			{
				DrawCellphoneCallScaleform();
				Script.Wait(0);
			}
		}
		else
		{
			Function.Call(Hash.PLAY_PED_RINGTONE, "Dial_and_Remote_Ring", Game.Player.Character, 1);
			num = Game.GameTime + timetoanswer;
			while (Game.GameTime < num)
			{
				DrawCellphoneCallScaleform();
				Script.Wait(0);
			}
		}
		Function.Call(Hash.STOP_PED_RINGTONE, Game.Player.Character);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, -1f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 155, 255);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 6f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 0, 15);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 4);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 4, 0, 2, contactname, txd, callstate2, "CELL_217", "CELL_217");
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 4f, Function.Call<int>(Hash.TO_FLOAT, 0));
	}

	public static void END_PHONECALL(bool isincutscene = false)
	{
		if (!isincutscene)
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hang_Up", "Phone_SoundSet_Default", true);
		}
		CLOSE_PHONE();
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 155, 255);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 6f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 0, 15);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 4);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 4, 0, 2, "", "", "", "CELL_217", "CELL_217");
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 4f, Function.Call<int>(Hash.TO_FLOAT, 0));
		CALL_ACTIVE = false;
	}

	public static void PhoneSelection()
	{
		if (Game.GameTime > MouseCheck)
		{
			Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, CELLPHONE_IFRUIT, "GET_CURRENT_SELECTION");
			currentselection = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
			MouseCheck = Game.GameTime + 100;
		}
		if (Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, currentselection))
		{
			getcurrentselection = Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, currentselection);
		}
		if (APP_ACTIVE)
		{
			if (Game.IsControlJustPressed(Control.PhoneUp) || Game.IsControlJustPressed(Control.PhoneScrollForward))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 1f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
			}
			if (Game.IsControlJustPressed(Control.PhoneDown) || Game.IsControlJustPressed(Control.PhoneScrollBackward))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 3f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
			}
			if (Game.IsControlJustPressed(Control.PhoneLeft) || Game.IsControlJustPressed(Control.PhoneScrollForward))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 4f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
			}
			if (Game.IsControlJustPressed(Control.PhoneRight) || Game.IsControlJustPressed(Control.PhoneScrollBackward))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
			}
			bool flag = false;
			if (Game.IsControlJustPressed(Control.PhoneSelect) && !MESSAGE_ACTIVE)
			{
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Accept", "Phone_SoundSet_Default", true);
				switch (CurrentAppActive)
				{
				case 0:
					if (Email_Contact.Count > 0 && Email_Message.Count > 0 && Email_Pic.Count > 0 && Email_PicID.Count > 0)
					{
						SET_MOBILE_PHONE_ROTATION(-90f, 0f, 90f);
						CruelMastersOnlineOffline.LoadTexureDict(Email_Pic[getcurrentselection]);
						CruelMastersOnlineOffline.LoadTexureDict(Email_Pic[getcurrentselection]);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 9);
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, CELLPHONE_IFRUIT, "SET_DATA_SLOT");
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 9);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 0);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 1);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, Email_Contact[getcurrentselection]);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, "<textarea rows=\"1000\" cols=\"1000\">" + Email_Message[getcurrentselection] + "</textarea>");
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, "<textarea rows=\"1000\" cols=\"1000\">" + Email_Message2[getcurrentselection] + "</textarea>");
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, "<textarea rows=\"1000\" cols=\"1000\">" + Email_Message3[getcurrentselection] + "</textarea>");
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, Email_PicID[getcurrentselection]);
						Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 9, 0, -1082130432, -1082130432, -1082130432);
						MESSAGE_ACTIVE = true;
					}
					break;
				case 1:
					if (Text_Contact.Count > 0 && Text_Message.Count > 0 && Text_Pic.Count > 0)
					{
						CruelMastersOnlineOffline.LoadTexureDict(Text_Pic[getcurrentselection]);
						CruelMastersOnlineOffline.LoadTexureDict(Text_Pic[getcurrentselection]);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 7);
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, CELLPHONE_IFRUIT, "SET_DATA_SLOT");
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 7);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 0);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, Text_Contact[getcurrentselection]);
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, "<textarea rows=\"1000\" cols=\"1000\">" + Text_Message[getcurrentselection] + "</textarea>");
						Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_PLAYER_NAME_STRING, Text_Pic[getcurrentselection]);
						Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 7, 0, -1082130432, -1082130432, -1082130432);
						MESSAGE_ACTIVE = true;
					}
					break;
				case 2:
				{
					Function.Call(Hash.PLAY_PED_RINGTONE, "Remote_Ring", Game.Player.Character, 1);
					CruelMastersOnlineOffline.LoadTexureDict(Contact_Pic[getcurrentselection]);
					CruelMastersOnlineOffline.LoadTexureDict(Contact_Pic[getcurrentselection]);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 4);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 4, 0, 2, Contact_Contact[getcurrentselection], Contact_Pic[getcurrentselection], "DIALING", "CELL_217", "CELL_217");
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 4f, Function.Call<int>(Hash.TO_FLOAT, 0));
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, -1f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, -1f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 6f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Franklin", true);
					int num = Game.GameTime + Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 4000, 6000);
					while (Game.GameTime < num)
					{
						if (Game.IsControlJustPressed(Control.PhoneCancel))
						{
							flag = true;
							break;
						}
						DrawCellphoneCallScaleform();
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_PED_RINGTONE, Game.Player.Character);
					if (flag)
					{
						CurrentInContact = "char_default";
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 2f, Function.Call<int>(Hash.TO_FLOAT, 0));
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, 9f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hang_Up", "Phone_SoundSet_Default", true);
						APP_ACTIVE = true;
					}
					else
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 4);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 4, 0, 2, Contact_Contact[getcurrentselection], Contact_Pic[getcurrentselection], "CONNECTED", "CELL_217", "CELL_217");
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 4f, Function.Call<int>(Hash.TO_FLOAT, 0));
						CurrentInContact = Contact_Contact[getcurrentselection];
						CALL_ACTIVE = true;
					}
					break;
				}
				}
			}
			int currentAppActive = CurrentAppActive;
			int num2 = currentAppActive;
			if (num2 == 6)
			{
				Cellphone_Camera.CAMERA_CONTROL(Cellphone_Camera.CellCam);
				if (Game.IsControlPressed(Control.FrontendAccept))
				{
					Cellphone_Camera.DeleteShutterScaleforms();
					Cellphone_Camera.RequestShutterScaleforms();
					int num3 = Game.GameTime + 500;
					while (Game.GameTime < num3)
					{
						Heist_Hud.drawSprite2("cs_nhp_overlay_grid", "overlay_grid", 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255);
						Cellphone_Camera.Photo_Active = true;
						Script.Wait(0);
					}
					Wall_Creator.CallFunction(Cellphone_Camera.CAMERA_SHUTTER, "CLOSE_THEN_OPEN_SHUTTER");
					num3 = Game.GameTime + 1000;
					while (Game.GameTime < num3)
					{
						Heist_Hud.drawSprite2("cs_nhp_overlay_grid", "overlay_grid", 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255);
						Cellphone_Camera.Photo_Active = true;
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, Cellphone_Camera.CAMERA_SHUTTER, 0.25f, 0.5f, 1f, 1f, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					Cellphone_Camera.Photo_Active = false;
					Cellphone_Camera.DeleteShutterScaleforms();
				}
			}
			if (!MESSAGE_ACTIVE)
			{
				if (Game.IsControlJustPressed(Control.PhoneCancel) && !flag)
				{
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, -1f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 100, 200);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 2f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
					if (CurrentAppActive == 1 || CurrentAppActive == 4 || CurrentAppActive == 7)
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
					else if (CurrentAppActive == 2 || CurrentAppActive == 5 || CurrentAppActive == 8)
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
					else if (CurrentAppActive == 3)
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
					else if (CurrentAppActive == 6)
					{
						Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, true, 0);
						Function.Call(Hash.FREEZE_ENTITY_POSITION, Game.Player.Character, false);
						HudHandler.HudandRadar(Hud: true, Radar: true);
						Game.Player.Character.IsVisible = true;
						Cellphone_Camera.CellCam.Delete();
						Cellphone_Camera.CellCam = null;
						World.RenderingCamera = null;
						Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
						Cellphone_Camera.ButtonPressTimer = Game.GameTime + 2000;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Put_Away", "Phone_SoundSet_Default", true);
						Cellphone_Camera.Camera_Active = false;
						CREATE_PHONE(0);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Back", "Phone_SoundSet_Default", true);
					SET_MOBILE_PHONE_ROTATION(-90f, 0f, 0f);
					APP_ACTIVE = false;
					CurrentAppActive = -1;
				}
			}
			else if (Game.IsControlJustPressed(Control.PhoneCancel))
			{
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Back", "Phone_SoundSet_Default", true);
				switch (CurrentAppActive)
				{
				case 0:
					SET_MOBILE_PHONE_ROTATION(-90f, 0f, 90f);
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 8f, Function.Call<int>(Hash.TO_FLOAT, 0));
					MESSAGE_ACTIVE = false;
					break;
				case 1:
					Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 6f, Function.Call<int>(Hash.TO_FLOAT, 0));
					MESSAGE_ACTIVE = false;
					break;
				case 2:
					break;
				}
			}
			return;
		}
		if (Game.GameTime > ScrollTimer)
		{
			if (Game.IsControlJustPressed(Control.PhoneUp))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 1f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
				ScrollTimer = Game.GameTime + 100;
			}
			if (Game.IsControlJustPressed(Control.PhoneDown))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 3f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
				ScrollTimer = Game.GameTime + 100;
			}
			if (Game.IsControlJustPressed(Control.PhoneLeft) || Game.IsControlJustPressed(Control.PhoneScrollForward))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 4f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
				if (CurrentAppActive == -1)
				{
					if (getcurrentselection == 3 || getcurrentselection == 6)
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 1f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
					if (getcurrentselection == 0)
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 1f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
				}
				ScrollTimer = Game.GameTime + 100;
			}
			if (Game.IsControlJustPressed(Control.PhoneRight) || Game.IsControlJustPressed(Control.PhoneScrollBackward))
			{
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Navigate", "Phone_SoundSet_Default", true);
				if (CurrentAppActive == -1)
				{
					if (getcurrentselection == 2 || getcurrentselection == 5)
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 3f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
					if (getcurrentselection == 8)
					{
						Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 3f, -1082130432, -1082130432, -1082130432, -1082130432);
					}
				}
				ScrollTimer = Game.GameTime + 100;
			}
		}
		if (Game.IsControlJustPressed(Control.PhoneSelect))
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Accept", "Phone_SoundSet_Default", true);
			switch (getcurrentselection)
			{
			case 0:
				CurrentAppActive = getcurrentselection;
				SET_MOBILE_PHONE_ROTATION(-90f, 0f, 90f);
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 8f, Function.Call<int>(Hash.TO_FLOAT, 0));
				APP_ACTIVE = true;
				break;
			case 1:
				CurrentAppActive = getcurrentselection;
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 6f, Function.Call<int>(Hash.TO_FLOAT, 0));
				APP_ACTIVE = true;
				break;
			case 2:
				CurrentAppActive = getcurrentselection;
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, 9f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
				Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "DISPLAY_VIEW", 2f, Function.Call<int>(Hash.TO_FLOAT, 0));
				APP_ACTIVE = true;
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
			{
				DESTROY_PHONE();
				CurrentAppActive = getcurrentselection;
				Vector3 position = Game.Player.Character.Position;
				Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, false, 256);
				Function.Call(Hash.FREEZE_ENTITY_POSITION, Game.Player.Character, true);
				HudHandler.HudandRadar(Hud: true, Radar: true);
				Game.Player.Character.IsVisible = false;
				Cellphone_Camera.camrotz = Game.Player.Character.Heading;
				Cellphone_Camera.camrotx = 0f;
				Cellphone_Camera.camzoom = 50f;
				Cellphone_Camera.CellCam = World.CreateCamera(new Vector3(position.X, position.Y, position.Z + 0.6f), new Vector3(0f, 0f, Game.Player.Character.Heading), 50f);
				World.RenderingCamera = Cellphone_Camera.CellCam;
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Menu_Accept", "Phone_SoundSet_Default", true);
				Cellphone_Camera.Camera_Active = true;
				APP_ACTIVE = true;
				break;
			}
			case 7:
				break;
			case 8:
				APP_ACTIVE = true;
				break;
			}
		}
	}

	public static void CREATE_TEXT(string contact = "Text_Contact", string message = "Text_Message", string pictxd = "char_default")
	{
		CruelMastersOnlineOffline.LoadTexureDict(pictxd);
		CruelMastersOnlineOffline.LoadTexureDict(pictxd);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 6, CurrentTextAmount, Function.Call<int>(Hash.GET_CLOCK_HOURS), Function.Call<int>(Hash.GET_CLOCK_MINUTES), contact, message);
		Text_Contact.Add(contact);
		Text_Message.Add(message);
		Text_Pic.Add(pictxd);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Text_Arrive_Tone", "Phone_SoundSet_Default", true);
		CurrentTextAmount++;
	}

	public static void CLEAR_TEXTS()
	{
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 6);
		Text_Contact.Clear();
		Text_Message.Clear();
		Text_Pic.Clear();
		CurrentTextAmount = 0;
	}

	public static void CREATE_EMAIL(string contact = "Text_Contact", string message = "Text_Message", string message2 = "message 2", string message3 = "message3", string pictxd = "char_default", string picid = "char_default", int lefticon = 0, bool imageicon = false)
	{
		CruelMastersOnlineOffline.LoadTexureDict(pictxd);
		CruelMastersOnlineOffline.LoadTexureDict(pictxd);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 8, CurrentEmailAmount, lefticon, imageicon, contact, message, message2, message3, picid);
		Email_Contact.Add(contact);
		Email_Message.Add(message);
		Email_Message2.Add(message2);
		Email_Message3.Add(message3);
		Email_Pic.Add(pictxd);
		Email_PicID.Add(picid);
		CurrentEmailAmount++;
	}

	public static void CLEAR_EMAILS()
	{
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 8);
		Email_Contact.Clear();
		Email_Message.Clear();
		Email_Message2.Clear();
		Email_Message3.Clear();
		Email_Pic.Clear();
		Email_PicID.Clear();
		CurrentEmailAmount = 0;
	}

	public static void CREATE_CONTACT(string contact = "Text_Contact", string txd = "char_default", bool icon_enabled = false)
	{
		CruelMastersOnlineOffline.LoadTexureDict(txd);
		CruelMastersOnlineOffline.LoadTexureDict(txd);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT", 2, CurrentContactAmount, icon_enabled, contact, txd, txd);
		Contact_Contact.Add(contact);
		Contact_Pic.Add(txd);
		CurrentContactAmount++;
	}

	public static void CLEAR_CONTACTS()
	{
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_DATA_SLOT_EMPTY", 2);
		CurrentContactAmount = 0;
	}

	public static void TitleBarTime()
	{
		int num = Function.Call<int>(Hash.GET_CLOCK_HOURS);
		int num2 = Function.Call<int>(Hash.GET_CLOCK_MINUTES);
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_TITLEBAR_TIME", num, num2, ReturnDay());
		int num3 = 0;
		int num4 = Function.Call<int>(Hash.GET_ZONE_SCUMMINESS, Function.Call<int>(Hash.GET_ZONE_AT_COORDS, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, true));
		num3 = num4 switch
		{
			0 => 5, 
			1 => 5, 
			2 => 4, 
			3 => 4, 
			4 => 3, 
			5 => 2, 
			_ => 3, 
		};
		int num5 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 8);
		if (num5 < 2 && num3 > 2)
		{
			num3--;
		}
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_PROVIDER_ICON", Function.Call<float>(Hash.TO_FLOAT, 1), Function.Call<float>(Hash.TO_FLOAT, num3));
		Wall_Creator.CallFunction(CELLPHONE_IFRUIT, "SET_SIGNAL_STRENGTH", Function.Call<float>(Hash.TO_FLOAT, num4));
	}

	public static string ReturnDay()
	{
		return Function.Call<int>(Hash.GET_CLOCK_DAY_OF_WEEK) switch
		{
			0 => "SUN", 
			1 => "MON", 
			2 => "TUES", 
			3 => "WED", 
			4 => "THUR", 
			5 => "FRI", 
			6 => "SAT", 
			_ => "", 
		};
	}

	public static void CREATE_PHONE(int phoneid)
	{
		Function.Call(Hash.CREATE_MOBILE_PHONE, phoneid);
	}

	public static void TOGGLE_PHONE(bool toggle)
	{
		Function.Call(Hash.SCRIPT_IS_MOVING_MOBILE_PHONE_OFFSCREEN, toggle);
	}

	public static void TOGGLE_PHONE_DOF(bool toggle)
	{
		Function.Call(Hash.SET_MOBILE_PHONE_DOF_STATE, toggle);
	}

	public static void SET_MOBILE_PHONE_POSITION(float x, float y, float z)
	{
		Function.Call(Hash.SET_MOBILE_PHONE_POSITION, x, y, z);
	}

	public static void SET_MOBILE_PHONE_ROTATION(float x, float y, float z)
	{
		Function.Call(Hash.SET_MOBILE_PHONE_ROTATION, x, y, z, 0);
	}

	public static void SET_MOBILE_PHONE_SCALE(float scale)
	{
		Function.Call(Hash.SET_MOBILE_PHONE_SCALE, scale);
	}

	public static void DESTROY_PHONE()
	{
		Function.Call(Hash.DESTROY_MOBILE_PHONE);
	}
}
