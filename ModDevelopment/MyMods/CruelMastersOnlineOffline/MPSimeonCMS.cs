using System;
using System.Collections.Generic;
using System.Drawing;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;

namespace CruelMastersOnlineOffline;

internal class MPSimeonCMS : Script
{
	public class VariableTimer
	{
		public delegate void TimerExpired(object sender);

		private int TimerMax;

		private decimal TimerCounter;

		private bool IsRunning;

		public bool AutoReset;

		public int Counter => (int)TimerCounter;

		public event TimerExpired OnTimerExpired;

		public VariableTimer(int interval)
		{
			TimerCounter = interval;
			TimerMax = interval;
		}

		public void AddTime(decimal amount)
		{
			TimerCounter += amount;
		}

		public void RemoveTime(decimal amount)
		{
			TimerCounter -= amount;
			if (TimerCounter < 0m)
			{
				TimerCounter = 0m;
			}
		}

		public void Update(float timescale)
		{
			if (!IsRunning)
			{
				return;
			}
			float num = Game.LastFrameTime * 1000f;
			TimerCounter -= (decimal)(num * timescale);
			if (TimerCounter <= 0m)
			{
				OnTimerExpired?.Invoke(this);
				if (AutoReset)
				{
					TimerCounter += (decimal)TimerMax;
				}
				else
				{
					Stop();
				}
			}
		}

		public void Stop()
		{
			IsRunning = false;
		}

		public void Start()
		{
			IsRunning = true;
		}

		public void Reset()
		{
			TimerCounter = TimerMax;
		}
	}

	public static Blip SimeonBlip;

	public static int SimeonSwitch = 0;

	public static int PreviousSelection = 0;

	public static bool SimeonContactAdded = false;

	public static ObjectPool ContactPool = new ObjectPool();

	public static NativeMenu SimeonContact;

	public static int currentselection;

	public static int getcurrentselection;

	public static int MouseCheck;

	public static int MissionsSwitch = -1;

	public static int MissionSwitch = 0;

	public static int TeamControlSwitch = 0;

	public static int TeamLives = 1;

	public static float HardModeMultiplier = 1.5f;

	public static bool HardMode = false;

	public static Ped[] GroupIDs = new Ped[5];

	public static Vehicle[] GroupVehs = new Vehicle[10];

	public static Prop[] MissionProps = new Prop[10];

	public static Vehicle[] MissionVehs = new Vehicle[10];

	public static Blip[] MissionBlips = new Blip[10];

	public static Pickup[] MissionPickups = new Pickup[20];

	public static Ped[] MissionPeds = new Ped[20];

	public static DateTime MissionTimer;

	public static int MissionTime = 0;

	public static int hackingScalwform = 0;

	public static int uLocal_70 = 0;

	public static int Hacking_Index = 0;

	public static float Hacking_Lives = 3f;

	public static int FeedBackNumber = -1;

	public static int ErrorTimer = Game.GameTime;

	public static bool TRYDL = false;

	public static bool[] ClickBools = new bool[4];

	public static bool IpTry = false;

	public static int IpTryTimer = Game.GameTime;

	public static int IpTryFailedTimer = Game.GameTime;

	public static int IPSound = 0;

	public static int MoveSound = 0;

	public static Prop HackCard;

	public static Prop BagProp;

	public static Prop Laptop;

	public static int MoveTimer = Game.GameTime;

	public static int MoveSoundTimer = Game.GameTime;

	public static int Anim_Timer = Game.GameTime;

	public static VariableTimer MyHackingTimer;

	public static List<dynamic> HackingProps = new List<object>
	{
		"hei_prop_hei_securitypanel", "hei_prop_hei_keypad_01", "hei_prop_hei_keypad_02", "hei_prop_hei_keypad_03", "prop_ld_keypad_01", "prop_ld_keypad_01b", "prop_ld_keypad_01b_lod", "hei_prop_hei_cs_keyboard", "prop_cs_keyboard_01", "prop_keyboard_01a",
		"prop_keyboard_01b", "prop_laptop_jimmy", "prop_laptop_lester", "prop_laptop_lester2", "p_amb_lap_top_02", "p_cs_laptop_02", "p_laptop_02_s", "prop_laptop_01a"
	};

	public MPSimeonCMS()
	{
		Tick += onTick;
		Aborted += onShutdown;
		SimeonContact = new NativeMenu("", "SIMEON");
		SimeonContact.Banner.Position = new PointF(-1000f, -1000f);
		SimeonContact.MouseBehavior = MenuMouseBehavior.Disabled;
		ContactPool.Add(SimeonContact);
		NativeItem nativeItem = new NativeItem("Request Work", "Ask Simeon for some work.\n(This will throw you directly into a contact mission from Simeon.)", "");
		nativeItem.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.STOP_SCRIPTED_CONVERSATION);
			Function.Call(Hash.CREATE_NEW_SCRIPTED_CONVERSATION);
			Function.Call(Hash.ADD_PED_TO_CONVERSATION, 0, MPVoiceLinePed.VLPed, "SIMEON");
			Function.Call(Hash.ADD_LINE_TO_CONVERSATION, 0, "MPCT_GAAA", "SIMEON", 1, 1, 1, 1, 1, 1, 1, 0, 1, 1);
			Function.Call(Hash.START_SCRIPT_PHONE_CONVERSATION, 0, 0);
			SimeonContact.Visible = false;
			int num = Game.GameTime + 5000;
			while (Game.GameTime < num)
			{
				Mobile_Phone.DrawCellphoneCallScaleform();
				Script.Wait(0);
			}
			Mobile_Phone.CurrentInContact = "char_default";
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "DISPLAY_VIEW", 1f, Function.Call<int>(Hash.TO_FLOAT, 0));
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_INPUT_EVENT", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "DISPLAY_VIEW", 2f, Function.Call<int>(Hash.TO_FLOAT, 0));
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 1f, 1f, 9f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 1f, 0, 130, 200);
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 2f, 1f, 5f, -1f, -1f, "CELL_205", 0, 0, 0, 0);
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 2f, 0, 255, 50);
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_SOFT_KEYS", 3f, 1f, 4f, -1f, -1f, "CELL_206", 0, 0, 0, 0);
			Wall_Creator.CallFunction(Mobile_Phone.CELLPHONE_IFRUIT, "SET_SOFT_KEYS_COLOUR", 3f, 255, 50, 0);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hang_Up", "Phone_SoundSet_Default", true);
			Mobile_Phone.APP_ACTIVE = true;
			Mobile_Phone.CALL_ACTIVE = false;
			Mobile_Phone.CallVL = false;
			Script.Wait(2000);
			Mobile_Phone.CLOSE_PHONE();
			Script.Wait(1000);
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
			Function.Call(Hash.TRIGGER_SCREENBLUR_FADE_IN, 1f);
			Function.Call(Hash.ANIMPOSTFX_PLAY, "MP_job_load", 0, false);
			Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "SCREEN_FLASH", "CELEBRATION_SOUNDSET", true);
			LoadingPrompt.Show("Loading Contact Mission");
			Script.Wait(4000);
			CruelMastersOnlineOffline.RadioAllowed = false;
			CruelMastersOnlineOffline.NoCopsOnMission = true;
			CruelMastersOnlineOffline.FuckOffCivilians = false;
			CruelMastersOnlineOffline.OnMission = true;
			MissionsSwitch = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 13);
			SimeonSwitch = 0;
		};
		SimeonContact.Add(nativeItem);
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (ContactPool != null && ContactPool.AreAnyVisible)
		{
			ContactPool.Process();
		}
		// Patched: Simeon used to wait for rank 3 only. Passing Gerald's first mission now unlocks him too.
		MPSaveData mPSaveData = MPSaveData.GET_MAIN_SAVE_DATA("Save Data");
		if (mPSaveData == null || mPSaveData.ContactSaveDatas.Count == 0)
		{
			return;
		}
		if (MPRank.PlayerLevel < 3 && !mPSaveData.ContactSaveDatas[0].GeraldFirstMissionDone)
		{
			return;
		}
		if (mPSaveData.ContactSaveDatas[0].SimeonCutscene)
		{
			if (!SimeonContactAdded && Mobile_Phone.PHONE_LOADED)
			{
				Mobile_Phone.CREATE_CONTACT("Simeon", "char_simeon");
				SimeonContactAdded = true;
			}
			switch (SimeonSwitch)
			{
			case 0:
				if (!CruelMastersOnlineOffline.OnMission)
				{
					if (SimeonBlip == null)
					{
						SimeonBlip = World.CreateBlip(new Vector3(-32.04094f, -1111.233f, 26.42236f));
					}
					else
					{
						SimeonBlip.Sprite = BlipSprite.SimeonFamily;
						SimeonBlip.Color = BlipColor.Yellow;
						SimeonBlip.Name = "Simeon";
						SimeonBlip.Alpha = 255;
						SimeonBlip.Priority = 5;
						SimeonBlip.IsShortRange = true;
					}
					if (Game.Player.Character.Position.DistanceTo(new Vector3(-32.04094f, -1111.233f, 26.42236f)) < 10f)
					{
						World.DrawMarker(MarkerType.Cylinder, new Vector3(-32.04094f, -1111.233f, 24.82236f), Vector3.Zero, Vector3.Zero, new Vector3(1.5f, 1.5f, 1.5f), Color.Yellow);
					}
					if (!(Game.Player.Character.Position.DistanceTo(new Vector3(-32.04094f, -1111.233f, 26.42236f)) < 1.3f))
					{
						break;
					}
					GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter.");
					if (!Game.IsControlJustPressed(Control.Context))
					{
						break;
					}
					int num27 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
					Ped ped40 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num27, 0);
					if (ped40.Exists())
					{
						GroupIDs[0] = ped40;
					}
					Ped ped41 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num27, 1);
					if (ped41.Exists())
					{
						GroupIDs[1] = ped41;
					}
					Ped ped42 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num27, 2);
					if (ped42.Exists())
					{
						GroupIDs[2] = ped42;
					}
					Mobile_Phone.CAN_OPEN_PHONE = false;
					int num28 = Game.GameTime + 4000;
					CruelMastersOnlineOffline.OnMission = true;
					Game.Player.CanControlCharacter = false;
					PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 8, 1);
					while (Game.GameTime < num28)
					{
						Script.Wait(0);
					}
					Function.Call(Hash.TAKE_CONTROL_OF_FRONTEND);
					while (Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) != Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"))
					{
						Function.Call(Hash.ACTIVATE_FRONTEND_MENU, Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"), 0, -1);
						Script.Wait(200);
					}
					CruelMastersOnlineOffline.WaitForFrontendReady("MPSimeonCMS lobby");
					PreviousSelection = -1;
					if (!CruelMastersOnlineOffline.IsFreemodeMale && !CruelMastersOnlineOffline.IsFreemodeFemale)
					{
						CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_CHAR_IMG", 0);
					}
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SHIFT_CORONA_DESC", false, false);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SHIFT_CORONA_DESC", true, false);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_ALL_HIGHLIGHTS", 1, 116);
					Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
					Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "All in the Game");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 0, 0, 0, 0, 0, 1, "All in the Game");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 1, 0, 0, 0, 0, 1, "Blow Up I");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 2, 0, 0, 0, 0, 1, "Blow Up II");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 3, 0, 0, 0, 0, 1, "Blow Up III");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 4, 0, 0, 0, 0, 1, "Chasers");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 5, 0, 0, 0, 0, 1, "Chasers II");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 6, 0, 0, 0, 0, 1, "El Burro Heists");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 7, 0, 0, 0, 0, 1, "Gentry Does It");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 8, 0, 0, 0, 0, 1, "GTA Today");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 9, 0, 0, 0, 0, 1, "It Takes a Thief");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 10, 0, 0, 0, 0, 1, "Rich Men in Richman");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 11, 0, 0, 0, 0, 1, "Rockford Roll");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 0, 12, 0, 0, 0, 0, 1, "Where Credit's Due");
					CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
					CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - All in the Game", "Simeon - All in the Game", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 3);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 0, 0, 0, 2, 100, true, CruelMastersOnlineOffline.Player_Name, 116, false, 0, 1, 0, "", false, "HOST", 18);
					int num29 = 1;
					if (ped40.Exists())
					{
						string text = "Ai Friend 1";
						if (ped40.AttachedBlip != null)
						{
							text = ped40.AttachedBlip.Name;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 1, 0, 0, 2, 100, true, text, 116, false, 0, 1, 0, "", false, "JOINED", 18);
						num29++;
					}
					else
					{
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 1, 0, 0, 0, 100, true, "", 2, false, 0, 1, 0, "", false, "", 4);
					}
					if (ped41.Exists())
					{
						string text2 = "Ai Friend 2";
						if (ped41.AttachedBlip != null)
						{
							text2 = ped41.AttachedBlip.Name;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 2, 0, 0, 2, 100, true, text2, 116, false, 0, 1, 0, "", false, "JOINED", 18);
						num29++;
					}
					else
					{
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 2, 0, 0, 0, 100, true, "", 2, false, 0, 1, 0, "", false, "", 4);
					}
					if (ped42.Exists())
					{
						string text3 = "Ai Friend 3";
						if (ped42.AttachedBlip != null)
						{
							text3 = ped42.AttachedBlip.Name;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 3, 0, 0, 2, 100, true, text3, 116, false, 0, 1, 0, "", false, "JOINED", 18);
						num29++;
					}
					else
					{
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 3, 3, 0, 0, 0, 100, true, "", 2, false, 0, 1, 0, "", false, "", 4);
					}
					CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 3);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_DESCRIPTION", 0, "Select a Contact Mission.", true);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SET_HEADING_DETAILS", "", "", "", false);
					CruelMastersOnlineOffline.CallFunctionFrontendHeader("SHOW_HEADING_DETAILS", false);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 0, "CONTACT MISSIONS", 1f, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num29} OF 1-4", 1f, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 2, "DETAILS", 1f, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("LOCK_MOUSE_SUPPORT", true, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_FOCUS", 0, true, true, true);
					CruelMastersOnlineOffline.CallFunctionFrontend("PAGE_FADE_IN");
					Function.Call(Hash.RELEASE_CONTROL_OF_FRONTEND);
					SimeonSwitch = 1;
				}
				else if (SimeonBlip != null)
				{
					SimeonBlip.Alpha = 0;
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
					SimeonSwitch = 0;
				}
				switch (getcurrentselection)
				{
				case 0:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - All in the Game", "Simeon - All in the Game", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "All in the Game");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num13 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped19 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num13, 0);
						if (ped19.Exists())
						{
							GroupIDs[0] = ped19;
						}
						Ped ped20 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num13, 1);
						if (ped20.Exists())
						{
							GroupIDs[1] = ped20;
						}
						Ped ped21 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num13, 2);
						if (ped21.Exists())
						{
							GroupIDs[2] = ped21;
						}
						int num14 = 1;
						if (ped19.Exists())
						{
							num14++;
						}
						if (ped20.Exists())
						{
							num14++;
						}
						if (ped21.Exists())
						{
							num14++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num14} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 0;
						SimeonSwitch = 0;
					}
					break;
				case 1:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Blow Up I", "Simeon - Blow Up I", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Blow Up I");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num23 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped34 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num23, 0);
						if (ped34.Exists())
						{
							GroupIDs[0] = ped34;
						}
						Ped ped35 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num23, 1);
						if (ped35.Exists())
						{
							GroupIDs[1] = ped35;
						}
						Ped ped36 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num23, 2);
						if (ped36.Exists())
						{
							GroupIDs[2] = ped36;
						}
						int num24 = 1;
						if (ped34.Exists())
						{
							num24++;
						}
						if (ped35.Exists())
						{
							num24++;
						}
						if (ped36.Exists())
						{
							num24++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num24} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 1;
						SimeonSwitch = 0;
					}
					break;
				case 2:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Blow Up II", "Simeon - Blow Up II", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Blow Up II");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num11 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped16 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num11, 0);
						if (ped16.Exists())
						{
							GroupIDs[0] = ped16;
						}
						Ped ped17 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num11, 1);
						if (ped17.Exists())
						{
							GroupIDs[1] = ped17;
						}
						Ped ped18 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num11, 2);
						if (ped18.Exists())
						{
							GroupIDs[2] = ped18;
						}
						int num12 = 1;
						if (ped16.Exists())
						{
							num12++;
						}
						if (ped17.Exists())
						{
							num12++;
						}
						if (ped18.Exists())
						{
							num12++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num12} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 2;
						SimeonSwitch = 0;
					}
					break;
				case 3:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Blow Up III", "Simeon - Blow Up III", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Blow Up III");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num21 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped31 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num21, 0);
						if (ped31.Exists())
						{
							GroupIDs[0] = ped31;
						}
						Ped ped32 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num21, 1);
						if (ped32.Exists())
						{
							GroupIDs[1] = ped32;
						}
						Ped ped33 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num21, 2);
						if (ped33.Exists())
						{
							GroupIDs[2] = ped33;
						}
						int num22 = 1;
						if (ped31.Exists())
						{
							num22++;
						}
						if (ped32.Exists())
						{
							num22++;
						}
						if (ped33.Exists())
						{
							num22++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num22} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 3;
						SimeonSwitch = 0;
					}
					break;
				case 4:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Chasers I", "Simeon - Chasers I", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Chasers I");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num9 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped13 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num9, 0);
						if (ped13.Exists())
						{
							GroupIDs[0] = ped13;
						}
						Ped ped14 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num9, 1);
						if (ped14.Exists())
						{
							GroupIDs[1] = ped14;
						}
						Ped ped15 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num9, 2);
						if (ped15.Exists())
						{
							GroupIDs[2] = ped15;
						}
						int num10 = 1;
						if (ped13.Exists())
						{
							num10++;
						}
						if (ped14.Exists())
						{
							num10++;
						}
						if (ped15.Exists())
						{
							num10++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num10} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 4;
						SimeonSwitch = 0;
					}
					break;
				case 5:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Chasers II", "Simeon - Chasers II", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Chasers II");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num15 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped22 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num15, 0);
						if (ped22.Exists())
						{
							GroupIDs[0] = ped22;
						}
						Ped ped23 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num15, 1);
						if (ped23.Exists())
						{
							GroupIDs[1] = ped23;
						}
						Ped ped24 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num15, 2);
						if (ped24.Exists())
						{
							GroupIDs[2] = ped24;
						}
						int num16 = 1;
						if (ped22.Exists())
						{
							num16++;
						}
						if (ped23.Exists())
						{
							num16++;
						}
						if (ped24.Exists())
						{
							num16++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num16} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 5;
						SimeonSwitch = 0;
					}
					break;
				case 6:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - El Burro Heists", "Simeon - El Burro Heists", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "El Burro Heists");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num25 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped37 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num25, 0);
						if (ped37.Exists())
						{
							GroupIDs[0] = ped37;
						}
						Ped ped38 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num25, 1);
						if (ped38.Exists())
						{
							GroupIDs[1] = ped38;
						}
						Ped ped39 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num25, 2);
						if (ped39.Exists())
						{
							GroupIDs[2] = ped39;
						}
						int num26 = 1;
						if (ped37.Exists())
						{
							num26++;
						}
						if (ped38.Exists())
						{
							num26++;
						}
						if (ped39.Exists())
						{
							num26++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num26} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 6;
						SimeonSwitch = 0;
					}
					break;
				case 7:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Gentry Does It", "Simeon - Gentry Does It", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Gentry Does It");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num7 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped10 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num7, 0);
						if (ped10.Exists())
						{
							GroupIDs[0] = ped10;
						}
						Ped ped11 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num7, 1);
						if (ped11.Exists())
						{
							GroupIDs[1] = ped11;
						}
						Ped ped12 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num7, 2);
						if (ped12.Exists())
						{
							GroupIDs[2] = ped12;
						}
						int num8 = 1;
						if (ped10.Exists())
						{
							num8++;
						}
						if (ped11.Exists())
						{
							num8++;
						}
						if (ped12.Exists())
						{
							num8++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num8} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 7;
						SimeonSwitch = 0;
					}
					break;
				case 8:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - GTA Today", "Simeon - GTA Today", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "GTA Today");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num17 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped25 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num17, 0);
						if (ped25.Exists())
						{
							GroupIDs[0] = ped25;
						}
						Ped ped26 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num17, 1);
						if (ped26.Exists())
						{
							GroupIDs[1] = ped26;
						}
						Ped ped27 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num17, 2);
						if (ped27.Exists())
						{
							GroupIDs[2] = ped27;
						}
						int num18 = 1;
						if (ped25.Exists())
						{
							num18++;
						}
						if (ped26.Exists())
						{
							num18++;
						}
						if (ped27.Exists())
						{
							num18++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num18} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 8;
						SimeonSwitch = 0;
					}
					break;
				case 9:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - It Takes a Thief", "Simeon - It Takes a Thief", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "It Takes a Thief");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num3 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped4 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num3, 0);
						if (ped4.Exists())
						{
							GroupIDs[0] = ped4;
						}
						Ped ped5 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num3, 1);
						if (ped5.Exists())
						{
							GroupIDs[1] = ped5;
						}
						Ped ped6 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num3, 2);
						if (ped6.Exists())
						{
							GroupIDs[2] = ped6;
						}
						int num4 = 1;
						if (ped4.Exists())
						{
							num4++;
						}
						if (ped5.Exists())
						{
							num4++;
						}
						if (ped6.Exists())
						{
							num4++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num4} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 9;
						SimeonSwitch = 0;
					}
					break;
				case 10:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Rich Men in Richman", "Simeon - Rich Men in Richman", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Rich Men in Richman");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num19 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped28 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 0);
						if (ped28.Exists())
						{
							GroupIDs[0] = ped28;
						}
						Ped ped29 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 1);
						if (ped29.Exists())
						{
							GroupIDs[1] = ped29;
						}
						Ped ped30 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 2);
						if (ped30.Exists())
						{
							GroupIDs[2] = ped30;
						}
						int num20 = 1;
						if (ped28.Exists())
						{
							num20++;
						}
						if (ped29.Exists())
						{
							num20++;
						}
						if (ped30.Exists())
						{
							num20++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num20} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 10;
						SimeonSwitch = 0;
					}
					break;
				case 11:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Rockford Roll", "Simeon - Rockford Roll", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Rockford Roll");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num5 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped7 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num5, 0);
						if (ped7.Exists())
						{
							GroupIDs[0] = ped7;
						}
						Ped ped8 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num5, 1);
						if (ped8.Exists())
						{
							GroupIDs[1] = ped8;
						}
						Ped ped9 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num5, 2);
						if (ped9.Exists())
						{
							GroupIDs[2] = ped9;
						}
						int num6 = 1;
						if (ped7.Exists())
						{
							num6++;
						}
						if (ped8.Exists())
						{
							num6++;
						}
						if (ped9.Exists())
						{
							num6++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num6} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 11;
						SimeonSwitch = 0;
					}
					break;
				case 12:
					if (PreviousSelection != getcurrentselection)
					{
						PreviousSelection = getcurrentselection;
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 0, 0, 0, 0, 3, 0, "From", "Simeon", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 1, 0, 0, 0, 3, 0, "Opens at Rank", "1", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 2, 0, 0, 0, 3, 0, "Players", "1-4", false, 0);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", 1, 3, 5, 5, 2, 3, 0, "Type", "Mission", false, 12);
						CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", 1);
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", 1, "SIMEON - Where Credit's Due", "Simeon - Where Credit's Due", "", "pause_map", "pm_shops_simeons", "", "", 0, 0, 0, "", "", "", "", "");
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, "SET_HEADER_TITLE");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "FMMC_OFFLN_HD");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Where Credit's Due");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_TEXT_LABEL, "");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, " (Simeon)");
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
						int num = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
						Ped ped = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num, 0);
						if (ped.Exists())
						{
							GroupIDs[0] = ped;
						}
						Ped ped2 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num, 1);
						if (ped2.Exists())
						{
							GroupIDs[1] = ped2;
						}
						Ped ped3 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num, 2);
						if (ped3.Exists())
						{
							GroupIDs[2] = ped3;
						}
						int num2 = 1;
						if (ped.Exists())
						{
							num2++;
						}
						if (ped2.Exists())
						{
							num2++;
						}
						if (ped3.Exists())
						{
							num2++;
						}
						CruelMastersOnlineOffline.CallFunctionFrontend("SET_MENU_HEADER_TEXT_BY_INDEX", 1, $"PLAYERS {num2} OF 1-4", 1f, true);
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
						LoadingPrompt.Show("Loading Contact Mission");
						Script.Wait(5000);
						CruelMastersOnlineOffline.RadioAllowed = false;
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						CruelMastersOnlineOffline.FuckOffCivilians = false;
						MissionsSwitch = 12;
						SimeonSwitch = 0;
					}
					break;
				}
				break;
			}
			SIMEON_MISSION_CONTROLLER();
		}
		else
		{
			if (CruelMastersOnlineOffline.OnMission)
			{
				return;
			}
			Script.Wait(3000);
			Mobile_Phone.SETUP_PHONECALL("Simeon", "char_simeon", "INCOMING CALL", "CONNECTED", isDialing: false, 4000, 4000);
			Script.Wait(2000);
			// Patched: the intro never registered the player, removed the cutscene 50 ms after starting it and
			// had no fade. It now goes through PlayPlayerCutscene. If the cutscene fails to load, Simeon is
			// still unlocked so progression can't stall.
			Mobile_Phone.END_PHONECALL(isincutscene: true);
			string simeonIntro = Game.Player.Character.Gender == Gender.Male ? "mp_intro_mcs_11" : "mp_intro_mcs_11_a1";
			CruelMastersOnlineOffline.PlayPlayerCutscene(simeonIntro);
			mPSaveData.ContactSaveDatas[0].SimeonCutscene = true;
			MPSaveData.SAVE_DATA(mPSaveData, "Save Data");
			CruelMastersOnlineOffline.LogLine("progression: Simeon intro done, contact added");
			CruelMastersOnlineOffline.ShowContactAdded("Contact Added", "char_simeon", "char_simeon", "Simeon");
			GTA.UI.Screen.ShowHelpText("Simeon Contact Missions have been unlocked. Go to the Simeon Blip ~HUD_COLOUR_YELLOW~~BLIP_293~~HUD_COLOUR_WHITE~ marked on the map to start up his contact missions.", 7000);
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

	public static bool THIS_PLAYER_NOTIF(Ped pedthatwaskilled = null, string msg = "", bool blinking = true)
	{
		if (pedthatwaskilled != null)
		{
			Entity killer = pedthatwaskilled.Killer;
			if (killer is Ped && killer as Ped == Game.Player.Character)
			{
				Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~" + msg, blinking);
				return true;
			}
			if (killer is Ped && killer as Ped != Game.Player.Character && killer.AttachedBlip != null)
			{
				Notification.Show("~b~" + killer.AttachedBlip.Name + "~w~" + msg, blinking);
				return true;
			}
		}
		Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~" + msg, blinking);
		return false;
	}

	public unsafe static void UnloadLoadehacker()
	{
		int num = hackingScalwform;
		Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &num);
		hackingScalwform = 0;
	}

	public static void Loadehacker()
	{
		Hacking_Lives = 3f;
		Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 1);
		Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, "HACK", 3);
		Script.Yield();
		hackingScalwform = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_SKIP_RENDER_WHILE_PAUSED, "Hacking_PC");
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_CURSOR_VISIBILITY");
		Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, false);
		Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "HACKING_PC_desktop_0", 0);
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, "HACKING_PC_desktop_0"))
		{
			Script.Wait(0);
		}
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "HACKING_PC_desktop_1", 0);
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, "HACKING_PC_desktop_1"))
		{
			Script.Wait(0);
		}
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "HACKING_PC_desktop_2", 0);
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, "HACKING_PC_desktop_2"))
		{
			Script.Wait(0);
		}
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "HACKING_PC_desktop_3", 0);
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, "HACKING_PC_desktop_3"))
		{
			Script.Wait(0);
		}
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "HACKING_PC_desktop_4", 0);
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, "HACKING_PC_desktop_4"))
		{
			Script.Wait(0);
		}
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "HACKING_PC_desktop_5", 0);
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, "HACKING_PC_desktop_5"))
		{
			Script.Wait(0);
		}
	}

	public unsafe static void SIMEON_MISSION_CONTROLLER()
	{
		switch (MissionsSwitch)
		{
		case 0:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (MissionVehs[0] != null && MissionVehs[0].IsDead)
				{
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random14 = new Random();
					int num119 = random14.Next(1, 3);
					if (num119 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num119 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Baller Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Baller Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Baller Was Destroyed", true, true, true);
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
					int num120 = Game.GameTime + 6000;
					while (Game.GameTime < num120)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random15 = new Random();
						int num121 = random15.Next(1, 3);
						if (num121 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num121 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num122 = Game.GameTime + 6000;
						while (Game.GameTime < num122)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-1213.771f, -131.8127f, 41.2216f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-1178.875f, -135.8624f, 39.66801f), 241.2049f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-1213.771f, -131.8127f, 40.2216f);
				Game.Player.Character.Heading = 200.3156f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "All in the Game", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "All in the Game", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "All in the Game", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num131 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num132 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num131))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num132 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num131);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num132}");
				}
				int num133 = Game.GameTime + num132;
				while (Game.GameTime < num133)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array21 = new Vector3[2]
				{
					new Vector3(-104.165f, -1776.18f, 29.53906f),
					new Vector3(-58.09891f, -1768.021f, 28.97371f)
				};
				float[] array22 = new float[2] { 232.8893f, 164.4803f };
				int num134 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array21.Length);
				RESPAWN.SET_MIS_STAT(array21[num134], array22[num134], 0, misretaskbool: true);
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.BallaOrig01GMY, new Vector3(-59.70897f, -1840.84f, 25.60788f), -26.61774f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.BallaOrig01GMY, new Vector3(-58.9875f, -1842.859f, 25.55899f), -56.25167f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.BallaOrig01GMY, new Vector3(-55.03575f, -1846.459f, 25.39677f), -34.44838f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.BallaOrig01GMY, new Vector3(-52.14084f, -1823.555f, 25.68644f), -38.95071f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.BlipUpEnemyPeds();
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Baller, new Vector3(-57.22919f, -1844.644f, 25.46184f), 140.9569f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MatteLightGray;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MatteLightGray;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
				MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
				MissionVehs[0].AttachedBlip.Name = "Baller";
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Repo the ~HUD_COLOUR_BLUEDARK~Baller.~HUD_COLOUR_WHITE~");
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Groups.pedList.Count > 0)
				{
					foreach (Ped ped37 in Groups.pedList)
					{
						if (ped37.IsInCombatAgainst(Game.Player.Character) && !Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
						{
							Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
						}
					}
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected the Baller.", blinking: true);
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
					MissionSwitch = 3;
				}
				break;
			case 3:
			{
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				Vector3[] array23 = new Vector3[2]
				{
					MissionVehs[0].Position.Around(5f),
					MissionVehs[0].Position.Around(2f)
				};
				float[] array24 = new float[2];
				int num135 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array23.Length);
				RESPAWN.SET_MIS_STAT(array23[num135], array24[num135], 0, misretaskbool: true);
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 0;
					}
					GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~Baller~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
					if (CruelMastersOnlineOffline.missionBlip == null)
					{
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
						}
						while (CruelMastersOnlineOffline.missionBlip == null)
						{
							CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
							Script.Wait(0);
						}
						HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
						break;
					}
					if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
					{
						Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
						World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
					}
					if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
					{
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
						Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[0], 4f, 1, 1);
						Script.Wait(2000);
						Game.Player.Character.Task.LeaveVehicle();
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Audios.Stop_Music_Event();
						Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
						Script.Wait(3000);
						MissionSwitch = 4;
					}
				}
				else
				{
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 255;
					}
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					GTA.UI.Screen.ShowSubtitle("Repo the ~HUD_COLOUR_BLUEDARK~Baller.~HUD_COLOUR_WHITE~");
				}
				break;
			}
			case 4:
			{
				int num123 = 7300;
				string cutscene7 = "mp_int_mcs_12_a3";
				string text8 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num123 = 7300;
					cutscene7 = "mp_intro_mcs_12_a3";
					text8 = "MP_1";
					break;
				case 1:
					num123 = 12000;
					cutscene7 = "mp_int_mcs_12_a3_3";
					text8 = "MP_1";
					break;
				case 2:
					num123 = 12600;
					cutscene7 = "mp_int_mcs_12_a3_4";
					text8 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num123 = 17400;
						cutscene7 = "mp_intro_mcs_12_a1";
						text8 = "MP_Male_Character";
					}
					else
					{
						num123 = 19800;
						cutscene7 = "mp_intro_mcs_12_a2";
						text8 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num124 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped19 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num124, 0);
				Ped ped20 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num124, 1);
				Ped ped21 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num124, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene7);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene7);
					Script.Yield();
				}
				num124 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped19 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num124, 0);
				ped20 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num124, 1);
				ped21 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num124, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped19);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped20);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped21);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text8, 0, 0, 64);
				if (ped19.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped19, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped20.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped20, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped21.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped21, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped19);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped20);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped21);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num123)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num125 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 9300, 12001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num125, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num125, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num125, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num126 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1700, 1991);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num126, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num126, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num126, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num127 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num128 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num127))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num128 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num127);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num128}");
				}
				int num129 = Game.GameTime + num128;
				while (Game.GameTime < num129)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num130 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num130)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num125);
				MPRank.ADD_RP(num126);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 1:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random9 = new Random();
						int num70 = random9.Next(1, 3);
						if (num70 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num70 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num71 = Game.GameTime + 6000;
						while (Game.GameTime < num71)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(60.61551f, -1718.613f, 29.30934f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(66.8004f, -1702.688f, 28.38619f), 229.2315f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(60.61551f, -1718.613f, 28.30934f);
				Game.Player.Character.Heading = 75.76286f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up I", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up I", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up I", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num80 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num81 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num80))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num81 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num80);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num81}");
				}
				int num82 = Game.GameTime + num81;
				while (Game.GameTime < num82)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array13 = new Vector3[2]
				{
					new Vector3(-25.46144f, -1689.086f, 29.29755f),
					new Vector3(-47.45936f, -1662.581f, 29.20022f)
				};
				float[] array14 = new float[2] { 112.3384f, 148.853f };
				int num83 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array13.Length);
				RESPAWN.SET_MIS_STAT(array13[num83], array14[num83], 2, misretaskbool: true);
				Vehicles.RemoveVehicles();
				Vehicles.SPAWN_VEHICLE(VehicleHash.Habanero, new Vector3(-40.22151f, -1688.526f, 28.06295f), 25.43128f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Patriot, new Vector3(-43.723f, -1689.635f, 28.10052f), 17.68271f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Buffalo, new Vector3(-47.70295f, -1691.527f, 28.06085f), 21.61374f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Tornado, new Vector3(-51.90733f, -1692.423f, 28.19631f), -2.957487f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Jackal, new Vector3(-56.24442f, -1689.895f, 28.21636f), -49.75908f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Jackal, new Vector3(-58.22382f, -1686.347f, 28.21616f), -75.6245f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Habanero, new Vector3(-54.05857f, -1681.788f, 28.17371f), -126.4341f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Contender, new Vector3(-50.25024f, -1677.152f, 28.58412f), -129.9859f, sirenactive: false, IsInvincible: false);
				Weapons.GiveWeapon(Game.Player.Character, WeaponHash.PetrolCan, 10000, equipNow: false, isAmmoLoaded: true);
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Go to the ~y~rival dealership.~w~");
				if (CruelMastersOnlineOffline.missionBlip == null)
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
					}
					while (CruelMastersOnlineOffline.missionBlip == null)
					{
						CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-50.73091f, -1685.405f, 29.49482f));
						Script.Wait(0);
					}
					HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
				}
				else
				{
					if (!(Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 30f))
					{
						break;
					}
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
					if (Vehicles.vehList.Count > 0)
					{
						foreach (Vehicle veh in Vehicles.vehList)
						{
							if (veh != null)
							{
								while (veh.AttachedBlip == null)
								{
									veh.AddBlip();
									Script.Wait(0);
								}
								if (veh.AttachedBlip != null)
								{
									veh.AttachedBlip.Sprite = BlipSprite.Standard;
									veh.AttachedBlip.Color = BlipColor.Red;
									veh.AttachedBlip.Name = "Car";
									veh.AttachedBlip.IsShortRange = true;
									veh.AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
								}
							}
						}
					}
					MissionSwitch = 3;
				}
				break;
			case 3:
				GTA.UI.Screen.ShowSubtitle("Destroy the ~r~cars.~w~");
				if (Vehicles.vehList.Count < 7)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
					}
					CruelMastersOnlineOffline.NoCopsOnMission = false;
					Game.Player.WantedLevel = 2;
				}
				if (Vehicles.vehList.Count == 0)
				{
					MissionSwitch = 4;
				}
				break;
			case 4:
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					GTA.UI.Screen.ShowSubtitle("Go to the ~y~dealership.~w~");
					if (CruelMastersOnlineOffline.missionBlip == null)
					{
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
						}
						while (CruelMastersOnlineOffline.missionBlip == null)
						{
							CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
							Script.Wait(0);
						}
						HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
						break;
					}
					if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
					{
						Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
						World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
					}
					if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
					{
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Audios.Stop_Music_Event();
						Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
						Script.Wait(2000);
						MissionSwitch = 5;
					}
				}
				else
				{
					GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
				}
				break;
			case 5:
			{
				int num72 = 7300;
				string cutscene4 = "mp_int_mcs_12_a3";
				string text5 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num72 = 7300;
					cutscene4 = "mp_intro_mcs_12_a3";
					text5 = "MP_1";
					break;
				case 1:
					num72 = 12000;
					cutscene4 = "mp_int_mcs_12_a3_3";
					text5 = "MP_1";
					break;
				case 2:
					num72 = 12600;
					cutscene4 = "mp_int_mcs_12_a3_4";
					text5 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num72 = 17400;
						cutscene4 = "mp_intro_mcs_12_a1";
						text5 = "MP_Male_Character";
					}
					else
					{
						num72 = 19800;
						cutscene4 = "mp_intro_mcs_12_a2";
						text5 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num73 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped10 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num73, 0);
				Ped ped11 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num73, 1);
				Ped ped12 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num73, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene4);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene4);
					Script.Yield();
				}
				num73 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped10 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num73, 0);
				ped11 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num73, 1);
				ped12 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num73, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped10);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped11);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped12);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text5, 0, 0, 64);
				if (ped10.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped10, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped11.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped11, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped12.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped12, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped10);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped11);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped12);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num72)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num74 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 9300, 13001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num74, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num74, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num74, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num75 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1700, 2091);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num75, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num75, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num75, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num76 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num77 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num76))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num77 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num76);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num77}");
				}
				int num78 = Game.GameTime + num77;
				while (Game.GameTime < num78)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num79 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num79)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num74);
				MPRank.ADD_RP(num75);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 2:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (MissionVehs[0] != null && MissionVehs[0].IsDead)
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random21 = new Random();
					int num184 = random21.Next(1, 3);
					if (num184 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num184 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Banshee Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Banshee Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Banshee Was Destroyed", true, true, true);
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
					int num185 = Game.GameTime + 6000;
					while (Game.GameTime < num185)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random22 = new Random();
						int num186 = random22.Next(1, 3);
						if (num186 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num186 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num187 = Game.GameTime + 6000;
						while (Game.GameTime < num187)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(77.37017f, 259.0414f, 109.0347f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(68.8026f, 258.5068f, 109.2391f), 67.4599f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(77.37017f, 259.0414f, 108.0347f);
				Game.Player.Character.Heading = 312.5598f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up II", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up II", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up II", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num196 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num197 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num196))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num197 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num196);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num197}");
				}
				int num198 = Game.GameTime + num197;
				while (Game.GameTime < num198)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array35 = new Vector3[2]
				{
					new Vector3(182.9565f, 373.8492f, 108.5742f),
					new Vector3(229.5799f, 385.2776f, 106.5325f)
				};
				float[] array36 = new float[2] { 264.3879f, 75.92992f };
				int num199 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array35.Length);
				RESPAWN.SET_MIS_STAT(array35[num199], array36[num199], 3, misretaskbool: true);
				Vehicles.RemoveVehicles();
				Vehicles.SPAWN_VEHICLE(VehicleHash.Everon, new Vector3(193.1094f, 379.7986f, 107.124f), -5.489714f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Felon2, new Vector3(187.1388f, 380.1841f, 107.1292f), -5.367201f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Jackal, new Vector3(184.1739f, 380.3603f, 107.3378f), -5.371578f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Exemplar, new Vector3(181.209f, 380.5294f, 107.3927f), -5.361529f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Cavalcade, new Vector3(178.1599f, 394.0351f, 107.8549f), 171.731f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Tornado2, new Vector3(186.8381f, 392.5623f, 107.0599f), 171.4664f, sirenactive: false, IsInvincible: false);
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Banshee, new Vector3(181.0148f, 393.688f, 107.3639f), 171.4591f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicRaceYellow;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicRaceYellow;
				Weapons.GiveWeapon(Game.Player.Character, WeaponHash.PetrolCan, 10000, equipNow: false, isAmmoLoaded: true);
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Go to the ~y~parking lot.~w~");
				if (CruelMastersOnlineOffline.missionBlip == null)
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
					}
					while (CruelMastersOnlineOffline.missionBlip == null)
					{
						CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(198.8018f, 384.1644f, 107.7579f));
						Script.Wait(0);
					}
					HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
				}
				else
				{
					if (!(Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 20f))
					{
						break;
					}
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
					if (Vehicles.vehList.Count > 0)
					{
						foreach (Vehicle veh2 in Vehicles.vehList)
						{
							if (veh2 != null)
							{
								while (veh2.AttachedBlip == null)
								{
									veh2.AddBlip();
									Script.Wait(0);
								}
								if (veh2.AttachedBlip != null)
								{
									veh2.AttachedBlip.Sprite = BlipSprite.Standard;
									veh2.AttachedBlip.Color = BlipColor.Red;
									veh2.AttachedBlip.Name = "Car";
									veh2.AttachedBlip.IsShortRange = true;
									veh2.AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
								}
							}
						}
					}
					Mobile_Phone.CLEAR_TEXTS();
					Mobile_Phone.CREATE_TEXT("Simeon", "Remember and keep the yellow Banshee away from the carnage!", "char_simeon");
					CruelMastersOnlineOffline.ShowNotificationLong("Remember and keep the yellow ", "Banshee away from the carnage!", "", "char_simeon", "char_simeon", "Simeon", "", blink: true);
					MissionSwitch = 3;
				}
				break;
			case 3:
				GTA.UI.Screen.ShowSubtitle("Destroy the ~r~cars.~w~");
				if (Vehicles.vehList.Count < 5)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
					}
					CruelMastersOnlineOffline.NoCopsOnMission = false;
					Game.Player.WantedLevel = 3;
				}
				if (Vehicles.vehList.Count == 0)
				{
					while (MissionVehs[0].AttachedBlip == null)
					{
						MissionVehs[0].AddBlip();
						Script.Wait(0);
					}
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Banshee";
					MissionSwitch = 4;
				}
				break;
			case 4:
				GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Banshee.~HUD_COLOUR_WHITE~");
				if (MissionVehs[0] != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					MissionSwitch = 5;
				}
				break;
			case 5:
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (!(MissionVehs[0] != null))
					{
						break;
					}
					if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
					{
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 0;
						}
						GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~Banshee~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
						if (CruelMastersOnlineOffline.missionBlip == null)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
							}
							while (CruelMastersOnlineOffline.missionBlip == null)
							{
								CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
								Script.Wait(0);
							}
							HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							break;
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
						{
							Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
							World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
							Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[0], 4f, 1, 1);
							Script.Wait(2000);
							Game.Player.Character.Task.LeaveVehicle();
							HudHandler.HudandRadar(Hud: false, Radar: false);
							Audios.Stop_Music_Event();
							Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
							Script.Wait(2000);
							MissionSwitch = 6;
						}
					}
					else
					{
						GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Banshee.~HUD_COLOUR_WHITE~");
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 255;
						}
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
					}
					break;
				}
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
					HudHandler.CLEAR_GPS_ROUTE();
				}
				if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
				{
					Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
				}
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 0;
					}
				}
				else
				{
					GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Banshee.~HUD_COLOUR_WHITE~");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 255;
					}
				}
				break;
			case 6:
			{
				int num188 = 7300;
				string cutscene11 = "mp_int_mcs_12_a3";
				string text12 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num188 = 7300;
					cutscene11 = "mp_intro_mcs_12_a3";
					text12 = "MP_1";
					break;
				case 1:
					num188 = 12000;
					cutscene11 = "mp_int_mcs_12_a3_3";
					text12 = "MP_1";
					break;
				case 2:
					num188 = 12600;
					cutscene11 = "mp_int_mcs_12_a3_4";
					text12 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num188 = 17400;
						cutscene11 = "mp_intro_mcs_12_a1";
						text12 = "MP_Male_Character";
					}
					else
					{
						num188 = 19800;
						cutscene11 = "mp_intro_mcs_12_a2";
						text12 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num189 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped31 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num189, 0);
				Ped ped32 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num189, 1);
				Ped ped33 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num189, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene11);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene11);
					Script.Yield();
				}
				num189 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped31 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num189, 0);
				ped32 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num189, 1);
				ped33 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num189, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped31);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped32);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped33);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text12, 0, 0, 64);
				if (ped31.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped31, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped32.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped32, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped33.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped33, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped31);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped32);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped33);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num188)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num190 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 9300, 14001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num190, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num190, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num190, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num191 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1700, 2291);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num191, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num191, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num191, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num192 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num193 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num192))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num193 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num192);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num193}");
				}
				int num194 = Game.GameTime + num193;
				while (Game.GameTime < num194)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num195 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num195)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num190);
				MPRank.ADD_RP(num191);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 3:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random16 = new Random();
						int num136 = random16.Next(1, 3);
						if (num136 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num136 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num137 = Game.GameTime + 6000;
						while (Game.GameTime < num137)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-882.2346f, -358.1567f, 39.28168f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-902.5501f, -397.375f, 38.13522f), 114.3369f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-882.2346f, -358.1567f, 38.28168f);
				Game.Player.Character.Heading = 201.4771f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up III", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up III", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Blow Up III", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num146 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num147 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num146))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num147 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num146);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num147}");
				}
				int num148 = Game.GameTime + num147;
				while (Game.GameTime < num148)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array25 = new Vector3[2]
				{
					new Vector3(1143.043f, -3088.74f, 5.785075f),
					new Vector3(1163.498f, -3055.254f, 5.898693f)
				};
				float[] array26 = new float[2] { 314.5458f, 290.3168f };
				int num149 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array25.Length);
				RESPAWN.SET_MIS_STAT(array25[num149], array26[num149], 2, misretaskbool: true);
				Vehicles.RemoveVehicles();
				Vehicles.SPAWN_VEHICLE(VehicleHash.Greenwood, new Vector3(1207.602f, -3038.167f, 4.311625f), 62.83059f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Impaler, new Vector3(1208.525f, -3029.878f, 4.256729f), 99.49457f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Manana2, new Vector3(1208.397f, -3024.094f, 4.325405f), 73.90166f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Tampa, new Vector3(1209.17f, -3018.633f, 4.339718f), 98.77654f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Exemplar, new Vector3(1208.673f, -3012.717f, 4.474224f), 79.68522f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Oracle2, new Vector3(1208.969f, -3006.835f, 4.150675f), 97.70101f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Picador, new Vector3(1209.2f, -2995.89f, 4.52754f), 104.4079f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Zion, new Vector3(1209.462f, -2989.927f, 4.2565f), 84.7514f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Zion, new Vector3(1208.965f, -2981.708f, 4.257382f), 108.0901f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Zion, new Vector3(1208.808f, -2974.387f, 4.258826f), 78.09368f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Exemplar, new Vector3(1208.543f, -2967.517f, 4.473168f), 119.6013f, sirenactive: false, IsInvincible: false);
				if (Vehicles.vehList.Count > 0)
				{
					foreach (Vehicle veh3 in Vehicles.vehList)
					{
						if (veh3 != null)
						{
							while (veh3.AttachedBlip == null)
							{
								veh3.AddBlip();
								Script.Wait(0);
							}
							if (veh3.AttachedBlip != null)
							{
								veh3.AttachedBlip.Sprite = BlipSprite.Standard;
								veh3.AttachedBlip.Color = BlipColor.Red;
								veh3.AttachedBlip.Name = "Car";
								veh3.AttachedBlip.IsShortRange = true;
								veh3.AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
							}
						}
					}
				}
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1210.011f, -3034.444f, 4.872818f), 91.34019f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1212.762f, -3025.687f, 4.85224f), 87.40378f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1212.896f, -3022.72f, 4.878242f), 87.40378f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1217.035f, -3021.337f, 4.860308f), 86.47816f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1213.088f, -3018.435f, 4.880126f), 87.40378f, WeaponHash.Pistol, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1209.769f, -3010.385f, 4.87516f), 33.25401f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1216.577f, -3007.968f, 4.860962f), 90.98179f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1209.416f, -3004.516f, 4.860744f), 113.1473f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1210.036f, -2997.795f, 4.861194f), 61.55655f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1218.236f, -2996.227f, 4.860735f), 73.8399f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1211.316f, -2987.692f, 4.848808f), 82.07973f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1208.432f, -2978.51f, 4.850233f), 119.3392f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1217.392f, -2978.955f, 4.848443f), 71.58604f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1211.185f, -2971.893f, 4.866393f), 71.53584f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Korean01GMY, new Vector3(1208.295f, -2965.101f, 4.851907f), 115.6025f, WeaponHash.AssaultRifle, 100, 25, setascop: false, 0, 1, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.BlipUpEnemyPeds();
				Props.RemoveProps();
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(-629735826), new Vector3(1205.371f, -3047.669f, 4.889054f), new Vector3(0f, 0f, 0.2620437f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(874602658), new Vector3(1216.278f, -3029.152f, 4.869911f), new Vector3(0.0676934f, 0.01174437f, 88.81815f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(874602658), new Vector3(1216.136f, -3014.687f, 4.866834f), new Vector3(-0.03625263f, -0.0002641338f, 83.24184f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(314436594), new Vector3(1217.01f, -3002.403f, 4.866833f), new Vector3(0f, 0f, -90.82515f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(1022953480), new Vector3(1216.635f, -2985.521f, 4.866832f), new Vector3(-4.07111E-13f, 2.178462E-06f, -119.0219f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(314436594), new Vector3(1215.456f, -2965.477f, 4.86754f), new Vector3(-9.541664E-15f, 1.307884E-07f, -70.6076f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(874602658), new Vector3(1204.471f, -2958.276f, 4.81994f), new Vector3(-0.001773639f, 0.00962389f, -158.8739f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Weapons.GiveWeapon(Game.Player.Character, WeaponHash.PetrolCan, 10000, equipNow: false, isAmmoLoaded: true);
				MissionSwitch = 2;
				break;
			}
			case 2:
				if (Groups.pedList.Count > 0)
				{
					foreach (Ped ped38 in Groups.pedList)
					{
						if (ped38.IsInCombatAgainst(Game.Player.Character) && !Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
						{
							Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
						}
					}
				}
				GTA.UI.Screen.ShowSubtitle("Destroy the ~r~cars.~w~");
				if (Vehicles.vehList.Count == 0)
				{
					MissionSwitch = 3;
				}
				break;
			case 3:
				if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
				{
					Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
				}
				GTA.UI.Screen.ShowSubtitle("Go to the ~y~dealership.~w~");
				if (CruelMastersOnlineOffline.missionBlip == null)
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
					}
					while (CruelMastersOnlineOffline.missionBlip == null)
					{
						CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
						Script.Wait(0);
					}
					HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
					break;
				}
				if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
				{
					Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
					World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
				}
				if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Audios.Stop_Music_Event();
					Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
					Script.Wait(2000);
					MissionSwitch = 4;
				}
				break;
			case 4:
			{
				int num138 = 7300;
				string cutscene8 = "mp_int_mcs_12_a3";
				string text9 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num138 = 7300;
					cutscene8 = "mp_intro_mcs_12_a3";
					text9 = "MP_1";
					break;
				case 1:
					num138 = 12000;
					cutscene8 = "mp_int_mcs_12_a3_3";
					text9 = "MP_1";
					break;
				case 2:
					num138 = 12600;
					cutscene8 = "mp_int_mcs_12_a3_4";
					text9 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num138 = 17400;
						cutscene8 = "mp_intro_mcs_12_a1";
						text9 = "MP_Male_Character";
					}
					else
					{
						num138 = 19800;
						cutscene8 = "mp_intro_mcs_12_a2";
						text9 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num139 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped22 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num139, 0);
				Ped ped23 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num139, 1);
				Ped ped24 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num139, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene8);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene8);
					Script.Yield();
				}
				num139 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped22 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num139, 0);
				ped23 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num139, 1);
				ped24 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num139, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped22);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped23);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped24);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text9, 0, 0, 64);
				if (ped22.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped22, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped23.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped23, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped24.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped24, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped22);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped23);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped24);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num138)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num140 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 11900, 15001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num140, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num140, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num140, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num141 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1900, 2391);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num141, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num141, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num141, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num142 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num143 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num142))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num143 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num142);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num143}");
				}
				int num144 = Game.GameTime + num143;
				while (Game.GameTime < num144)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num145 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num145)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num140);
				MPRank.ADD_RP(num141);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 4:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (MissionVehs[0] != null && MissionVehs[0].IsDead)
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random17 = new Random();
					int num150 = random17.Next(1, 3);
					if (num150 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num150 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Coquette Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Coquette Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Coquette Was Destroyed", true, true, true);
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
					int num151 = Game.GameTime + 6000;
					while (Game.GameTime < num151)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random18 = new Random();
						int num152 = random18.Next(1, 3);
						if (num152 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num152 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num153 = Game.GameTime + 6000;
						while (Game.GameTime < num153)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-61.36988f, -91.23074f, 57.79235f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-52.41417f, -102.946f, 57.6965f), 67.66316f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-61.36988f, -91.23074f, 56.79235f);
				Game.Player.Character.Heading = 30.79373f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Chasers I", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Chasers I", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Chasers I", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num163 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num164 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num163))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num164 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num163);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num164}");
				}
				int num165 = Game.GameTime + num164;
				while (Game.GameTime < num165)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array27 = new Vector3[2]
				{
					new Vector3(-56.32621f, -96.19292f, 57.81401f),
					new Vector3(-60.7686f, -87.84058f, 57.74385f)
				};
				float[] array28 = new float[2] { 65.05773f, 42.95759f };
				int num162 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array27.Length);
				RESPAWN.SET_MIS_STAT(array27[num162], array28[num162], 0, misretaskbool: true);
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Coquette, new Vector3(-608.4349f, 687.5325f, 147.5247f), 78.87414f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicBlack;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicBlack;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Coquette";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.Musclbeac02AMY, new Vector3(-608.1781f, 689.2725f, 148.1578f), 104.2288f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.pedList[0].SetIntoVehicle(MissionVehs[0], VehicleSeat.Driver);
				Groups.pedList[0].Task.CruiseWithVehicle(MissionVehs[0], 20f);
				CruelMastersOnlineOffline.NoCopsOnMission = false;
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Retrieve the ~HUD_COLOUR_BLUEDARK~Coquette.~HUD_COLOUR_WHITE~");
				if (MissionVehs[0] != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					THIS_PLAYER_NOTIF(null, " collected the Coquette.");
					MissionSwitch = 3;
				}
				break;
			case 3:
			{
				Vector3[] array29 = new Vector3[2]
				{
					MissionVehs[0].Position.Around(5f),
					MissionVehs[0].Position.Around(2f)
				};
				float[] array30 = new float[2];
				int num166 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array29.Length);
				RESPAWN.SET_MIS_STAT(array29[num166], array30[num166], 2, misretaskbool: true);
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (!(MissionVehs[0] != null))
					{
						break;
					}
					if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
					{
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 0;
						}
						GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~Coquette~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
						if (CruelMastersOnlineOffline.missionBlip == null)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
							}
							while (CruelMastersOnlineOffline.missionBlip == null)
							{
								CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
								Script.Wait(0);
							}
							HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							break;
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
						{
							Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
							World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.3f, 0.3f, 1f), Color.Yellow);
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
							Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[0], 4f, 1, 1);
							Script.Wait(2000);
							Game.Player.Character.Task.LeaveVehicle();
							HudHandler.HudandRadar(Hud: false, Radar: false);
							Audios.Stop_Music_Event();
							Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
							Script.Wait(2000);
							MissionSwitch = 4;
						}
					}
					else
					{
						GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Coquette.~HUD_COLOUR_WHITE~");
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 255;
						}
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
					}
					break;
				}
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
					HudHandler.CLEAR_GPS_ROUTE();
				}
				if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
				{
					Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
				}
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 0;
					}
				}
				else
				{
					GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Coquette.~HUD_COLOUR_WHITE~");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 255;
					}
				}
				break;
			}
			case 4:
			{
				int num154 = 7300;
				string cutscene9 = "mp_int_mcs_12_a3";
				string text10 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num154 = 7300;
					cutscene9 = "mp_intro_mcs_12_a3";
					text10 = "MP_1";
					break;
				case 1:
					num154 = 12000;
					cutscene9 = "mp_int_mcs_12_a3_3";
					text10 = "MP_1";
					break;
				case 2:
					num154 = 12600;
					cutscene9 = "mp_int_mcs_12_a3_4";
					text10 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num154 = 17400;
						cutscene9 = "mp_intro_mcs_12_a1";
						text10 = "MP_Male_Character";
					}
					else
					{
						num154 = 19800;
						cutscene9 = "mp_intro_mcs_12_a2";
						text10 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num155 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped25 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num155, 0);
				Ped ped26 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num155, 1);
				Ped ped27 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num155, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene9);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene9);
					Script.Yield();
				}
				num155 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped25 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num155, 0);
				ped26 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num155, 1);
				ped27 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num155, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped25);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped26);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped27);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text10, 0, 0, 64);
				if (ped25.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped25, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped26.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped26, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped27.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped27, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped25);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped26);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped27);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num154)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num156 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 9300, 15001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num156, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num156, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num156, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num157 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1700, 2391);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num157, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num157, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num157, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num158 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num159 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num158))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num159 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num158);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num159}");
				}
				int num160 = Game.GameTime + num159;
				while (Game.GameTime < num160)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num161 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num161)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num156);
				MPRank.ADD_RP(num157);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 5:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (MissionVehs[0] != null && MissionVehs[0].IsDead)
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random12 = new Random();
					int num102 = random12.Next(1, 3);
					if (num102 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num102 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Tornado Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Tornado Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Tornado Was Destroyed", true, true, true);
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
					int num103 = Game.GameTime + 6000;
					while (Game.GameTime < num103)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random13 = new Random();
						int num104 = random13.Next(1, 3);
						if (num104 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num104 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num105 = Game.GameTime + 6000;
						while (Game.GameTime < num105)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-882.2346f, -358.1567f, 39.28168f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-902.5501f, -397.375f, 38.13522f), 114.3369f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-882.2346f, -358.1567f, 38.28168f);
				Game.Player.Character.Heading = 201.4771f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Chasers II", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Chasers II", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Chasers II", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num115 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num116 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num115))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num116 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num115);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num116}");
				}
				int num117 = Game.GameTime + num116;
				while (Game.GameTime < num117)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array17 = new Vector3[2]
				{
					new Vector3(-876.3773f, -353.8317f, 39.24165f),
					new Vector3(-882.5386f, -357.671f, 39.2462f)
				};
				float[] array18 = new float[2] { 195.0694f, 192.9737f };
				int num114 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array17.Length);
				RESPAWN.SET_MIS_STAT(array17[num114], array18[num114], 0, misretaskbool: true);
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Tornado2, new Vector3(155.1396f, -1796.545f, 27.56385f), -42.29309f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicRaceYellow;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicRaceYellow;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Tornado";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.BallaOrig01GMY, new Vector3(158.0714f, -1796.669f, 27.8693f), -24.40866f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.pedList[0].SetIntoVehicle(MissionVehs[0], VehicleSeat.Driver);
				Groups.pedList[0].Task.CruiseWithVehicle(MissionVehs[0], 20f);
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Retrieve the ~HUD_COLOUR_BLUEDARK~Tornado.~HUD_COLOUR_WHITE~");
				if (MissionVehs[0] != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					THIS_PLAYER_NOTIF(null, " collected the Tornado.");
					MissionSwitch = 3;
				}
				break;
			case 3:
			{
				Vector3[] array19 = new Vector3[2]
				{
					MissionVehs[0].Position.Around(5f),
					MissionVehs[0].Position.Around(2f)
				};
				float[] array20 = new float[2];
				int num118 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array19.Length);
				RESPAWN.SET_MIS_STAT(array19[num118], array20[num118], 2, misretaskbool: true);
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (!(MissionVehs[0] != null))
					{
						break;
					}
					if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
					{
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 0;
						}
						GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~Tornado~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
						if (CruelMastersOnlineOffline.missionBlip == null)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
							}
							while (CruelMastersOnlineOffline.missionBlip == null)
							{
								CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
								Script.Wait(0);
							}
							HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							break;
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
						{
							Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
							World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.3f, 0.3f, 1f), Color.Yellow);
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
							Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[0], 4f, 1, 1);
							Script.Wait(2000);
							Game.Player.Character.Task.LeaveVehicle();
							HudHandler.HudandRadar(Hud: false, Radar: false);
							Audios.Stop_Music_Event();
							Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
							Script.Wait(2000);
							MissionSwitch = 4;
						}
					}
					else
					{
						GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Tornado.~HUD_COLOUR_WHITE~");
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 255;
						}
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
					}
					break;
				}
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
					HudHandler.CLEAR_GPS_ROUTE();
				}
				if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
				{
					Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
				}
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 0;
					}
				}
				else
				{
					GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Tornado.~HUD_COLOUR_WHITE~");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 255;
					}
				}
				break;
			}
			case 4:
			{
				int num106 = 7300;
				string cutscene6 = "mp_int_mcs_12_a3";
				string text7 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num106 = 7300;
					cutscene6 = "mp_intro_mcs_12_a3";
					text7 = "MP_1";
					break;
				case 1:
					num106 = 12000;
					cutscene6 = "mp_int_mcs_12_a3_3";
					text7 = "MP_1";
					break;
				case 2:
					num106 = 12600;
					cutscene6 = "mp_int_mcs_12_a3_4";
					text7 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num106 = 17400;
						cutscene6 = "mp_intro_mcs_12_a1";
						text7 = "MP_Male_Character";
					}
					else
					{
						num106 = 19800;
						cutscene6 = "mp_intro_mcs_12_a2";
						text7 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num107 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped16 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num107, 0);
				Ped ped17 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num107, 1);
				Ped ped18 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num107, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene6);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene6);
					Script.Yield();
				}
				num107 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped16 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num107, 0);
				ped17 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num107, 1);
				ped18 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num107, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped16);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped17);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped18);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text7, 0, 0, 64);
				if (ped16.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped16, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped17.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped17, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped18.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped18, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped16);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped17);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped18);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num106)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num108 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 9300, 15001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num108, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num108, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num108, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num109 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1700, 2391);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num109, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num109, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num109, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num110 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num111 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num110))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num111 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num110);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num111}");
				}
				int num112 = Game.GameTime + num111;
				while (Game.GameTime < num112)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num113 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num113)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num108);
				MPRank.ADD_RP(num109);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 6:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (MissionVehs[0] != null && MissionVehs[0].IsDead)
				{
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random19 = new Random();
					int num167 = random19.Next(1, 3);
					if (num167 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num167 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Dominator Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Dominator Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Dominator Was Destroyed", true, true, true);
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
					int num168 = Game.GameTime + 6000;
					while (Game.GameTime < num168)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random20 = new Random();
						int num169 = random20.Next(1, 3);
						if (num169 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num169 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num170 = Game.GameTime + 6000;
						while (Game.GameTime < num170)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(1326.069f, -1635.1f, 52.14543f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(1317.808f, -1635.033f, 51.59124f), 307.1774f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(1326.069f, -1635.1f, 51.14543f);
				Game.Player.Character.Heading = 349.229f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "El Burro Heists", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "El Burro Heists", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "El Burro Heists", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num179 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num180 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num179))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num180 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num179);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num180}");
				}
				int num181 = Game.GameTime + num180;
				while (Game.GameTime < num181)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array31 = new Vector3[2]
				{
					new Vector3(1327.362f, -1639.313f, 52.01923f),
					new Vector3(1354.416f, -1606.845f, 52.58259f)
				};
				float[] array32 = new float[2] { 341.0022f, 38.99642f };
				int num182 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array31.Length);
				RESPAWN.SET_MIS_STAT(array31[num182], array32[num182], 0, misretaskbool: true);
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1318.591f, -1563.748f, 50.03598f), 71.58409f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1317.749f, -1561.71f, 49.88144f), 177.7332f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1318.089f, -1535.933f, 50.42583f), -168.5361f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1339.961f, -1529.406f, 52.88989f), -78.47131f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1342.346f, -1529.163f, 53.19201f), 127.9924f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1341.262f, -1531.183f, 52.93139f), 32.07985f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1346.641f, -1550.002f, 52.65903f), -132.257f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1349.609f, -1550.335f, 52.89751f), 127.2743f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1359.517f, -1550.872f, 54.95549f), 12.43273f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1370.418f, -1544.455f, 54.84071f), -32.09441f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1373.134f, -1543.526f, 55.24866f), 45.95666f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1370.435f, -1526.229f, 55.6778f), -131.7363f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1373.369f, -1523.769f, 55.94547f), -176.8777f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Azteca01GMY, new Vector3(1378.673f, -1523.989f, 56.10204f), 162.4963f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.BlipUpEnemyPeds();
				Groups.GIVE_AI_RANDOM_WEAPON();
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Dominator, new Vector3(1344.153f, -1549.02f, 51.66245f), -131.0948f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicOrange;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicOrange;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Dominator";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Repo the ~HUD_COLOUR_BLUEDARK~Dominator.~HUD_COLOUR_WHITE~");
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Groups.pedList.Count > 0)
				{
					foreach (Ped ped39 in Groups.pedList)
					{
						if (ped39.IsInCombatAgainst(Game.Player.Character) && !Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
						{
							Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
						}
					}
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected the Dominator.", blinking: true);
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
					MissionSwitch = 3;
				}
				break;
			case 3:
			{
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				Vector3[] array33 = new Vector3[2]
				{
					MissionVehs[0].Position.Around(5f),
					MissionVehs[0].Position.Around(2f)
				};
				float[] array34 = new float[2];
				int num183 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array33.Length);
				RESPAWN.SET_MIS_STAT(array33[num183], array34[num183], 0, misretaskbool: true);
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 0;
					}
					GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~Dominator~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
					if (CruelMastersOnlineOffline.missionBlip == null)
					{
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
						}
						while (CruelMastersOnlineOffline.missionBlip == null)
						{
							CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
							Script.Wait(0);
						}
						HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
						break;
					}
					if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
					{
						Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
						World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
					}
					if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
					{
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
						Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[0], 4f, 1, 1);
						Script.Wait(2000);
						Game.Player.Character.Task.LeaveVehicle();
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Audios.Stop_Music_Event();
						Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
						Script.Wait(3000);
						MissionSwitch = 4;
					}
				}
				else
				{
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 255;
					}
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					GTA.UI.Screen.ShowSubtitle("Repo the ~HUD_COLOUR_BLUEDARK~Dominator.~HUD_COLOUR_WHITE~");
				}
				break;
			}
			case 4:
			{
				int num171 = 7300;
				string cutscene10 = "mp_int_mcs_12_a3";
				string text11 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num171 = 7300;
					cutscene10 = "mp_intro_mcs_12_a3";
					text11 = "MP_1";
					break;
				case 1:
					num171 = 12000;
					cutscene10 = "mp_int_mcs_12_a3_3";
					text11 = "MP_1";
					break;
				case 2:
					num171 = 12600;
					cutscene10 = "mp_int_mcs_12_a3_4";
					text11 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num171 = 17400;
						cutscene10 = "mp_intro_mcs_12_a1";
						text11 = "MP_Male_Character";
					}
					else
					{
						num171 = 19800;
						cutscene10 = "mp_intro_mcs_12_a2";
						text11 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num172 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped28 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num172, 0);
				Ped ped29 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num172, 1);
				Ped ped30 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num172, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene10);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene10);
					Script.Yield();
				}
				num172 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped28 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num172, 0);
				ped29 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num172, 1);
				ped30 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num172, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped28);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped29);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped30);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text11, 0, 0, 64);
				if (ped28.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped28, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped29.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped29, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped30.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped30, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped28);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped29);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped30);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num171)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num173 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 9300, 13001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num173, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num173, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num173, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num174 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1700, 2091);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num174, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num174, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num174, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num175 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num176 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num175))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num176 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num175);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num176}");
				}
				int num177 = Game.GameTime + num176;
				while (Game.GameTime < num177)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num178 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num178)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num173);
				MPRank.ADD_RP(num174);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 7:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if ((MissionVehs[0] != null && MissionVehs[0].IsDead) || (MissionVehs[1] != null && MissionVehs[1].IsDead))
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random23 = new Random();
					int num200 = random23.Next(1, 3);
					if (num200 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num200 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
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
					int num201 = Game.GameTime + 6000;
					while (Game.GameTime < num201)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random24 = new Random();
						int num202 = random24.Next(1, 3);
						if (num202 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num202 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num203 = Game.GameTime + 6000;
						while (Game.GameTime < num203)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(62.49284f, -1059.905f, 29.3717f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(66.01556f, -1064.413f, 29.31396f), 155.254f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(62.49284f, -1059.905f, 28.3717f);
				Game.Player.Character.Heading = 38.04087f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Gentry Does It", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Gentry Does It", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Gentry Does It", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num212 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num213 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num212))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num213 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num212);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num213}");
				}
				int num214 = Game.GameTime + num213;
				while (Game.GameTime < num214)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array37 = new Vector3[2]
				{
					new Vector3(-68.70955f, 297.6281f, 106.2125f),
					new Vector3(-68.49014f, 317.2583f, 109.2076f)
				};
				float[] array38 = new float[2] { 79.52656f, 336.85f };
				int num215 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array37.Length);
				RESPAWN.SET_MIS_STAT(array37[num215], array38[num215], 0, misretaskbool: true);
				Vehicles.RemoveVehicles();
				Vehicles.SPAWN_VEHICLE(VehicleHash.Dominator, new Vector3(-62.11111f, 322.5129f, 108.4963f), 158.9244f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Deviant, new Vector3(-55.62764f, 335.9094f, 110.0487f), 153.8464f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Buffalo4, new Vector3(-52.30632f, 345.1398f, 110.7584f), -11.46303f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Cog55, new Vector3(-76.4118f, 346.3174f, 110.9668f), 154.1052f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Buffalo, new Vector3(-86.67421f, 351.0063f, 111.0638f), 154.7261f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Blista2, new Vector3(-86.14887f, 372.6885f, 110.9637f), -114.2218f, sirenactive: false, IsInvincible: false);
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.Hipster01AMY, new Vector3(-52.76717f, 342.9701f, 111.1548f), 140.3529f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Hipster01AMY, new Vector3(-52.11383f, 345.4608f, 111.2582f), 145.9307f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Hipster01AMY, new Vector3(-53.03136f, 348.8097f, 111.4099f), 163.9459f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Hipster01AMY, new Vector3(-55.23905f, 351.832f, 111.4293f), 145.7249f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Hipster01AMY, new Vector3(-58.09327f, 346.712f, 111.199f), 175.0505f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				if (Groups.pedList.Count > 0)
				{
					foreach (Ped ped40 in Groups.pedList)
					{
						if (ped40 != null)
						{
							ped40.AlwaysKeepTask = true;
							ped40.Task.Cower(-1);
						}
					}
				}
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Felon2, new Vector3(-83.15194f, 348.998f, 111.1233f), -25.22725f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicGarnetRed;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicGarnetRed;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Car";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				while (MissionVehs[1] == null)
				{
					MissionVehs[1] = World.CreateVehicle(VehicleHash.Banshee, new Vector3(-89.26288f, 365.7671f, 111.0441f), -114.2218f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[1], 100f);
				MissionVehs[1].Mods.InstallModKit();
				MissionVehs[1].Mods.PrimaryColor = VehicleColor.MetallicGarnetRed;
				MissionVehs[1].Mods.SecondaryColor = VehicleColor.MatteLightGray;
				while (MissionVehs[1].AttachedBlip == null)
				{
					MissionVehs[1].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[1].AttachedBlip != null)
				{
					MissionVehs[1].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[1].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[1].AttachedBlip.Name = "Car";
					MissionVehs[1].AttachedBlip.IsShortRange = false;
					MissionVehs[1].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				CruelMastersOnlineOffline.NoCopsOnMission = false;
				MissionSwitch = 2;
				break;
			}
			case 2:
			{
				Prop[] nearbyProps = World.GetNearbyProps(new Vector3(-61.69141f, 352.2548f, 112.4502f), 15f, -1857663329);
				Prop[] array39 = nearbyProps;
				foreach (Prop prop4 in array39)
				{
					if (prop4 != null)
					{
						prop4.Delete();
					}
				}
				int num217 = 0;
				int num218 = 0;
				if (MissionVehs[0] != null && MissionVehs[0].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					num218 = 0;
				}
				if (MissionVehs[1] != null && MissionVehs[1].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[1])
				{
					num218 = 1;
				}
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (MissionVehs[num218] != null)
					{
						if (Game.Player.Character.CurrentVehicle == MissionVehs[num218])
						{
							if (MissionVehs[num218].AttachedBlip != null && MissionVehs[num218].AttachedBlip.Alpha > 0)
							{
								Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected a car.", blinking: true);
								MissionVehs[num218].AttachedBlip.Alpha = 0;
							}
							GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~car~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
							if (CruelMastersOnlineOffline.missionBlip == null)
							{
								if (CruelMastersOnlineOffline.missionBlip != null)
								{
									CruelMastersOnlineOffline.missionBlip.Delete();
									CruelMastersOnlineOffline.missionBlip = null;
								}
								while (CruelMastersOnlineOffline.missionBlip == null)
								{
									CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
									Script.Wait(0);
								}
								HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							}
							else
							{
								if (MissionVehs[num218].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
								{
									Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
									World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
								}
								if (MissionVehs[num218].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f && MissionVehs[num218].AttachedBlip != null)
								{
									Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ delivered a car.", blinking: true);
									MissionVehs[num218].AttachedBlip.Delete();
									MissionVehs[num218].IsDriveable = false;
									MissionVehs[num218].LockStatus = VehicleLockStatus.CannotEnter;
									if (CruelMastersOnlineOffline.missionBlip != null)
									{
										CruelMastersOnlineOffline.missionBlip.Delete();
										CruelMastersOnlineOffline.missionBlip = null;
										HudHandler.CLEAR_GPS_ROUTE();
									}
									Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
									Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[num218], 4f, 1, 1);
									Script.Wait(2000);
									Game.Player.Character.Task.LeaveVehicle();
								}
							}
						}
						else
						{
							GTA.UI.Screen.ShowSubtitle("Steal the ~HUD_COLOUR_BLUEDARK~cars.~HUD_COLOUR_WHITE~");
							if (MissionVehs[num218].AttachedBlip != null)
							{
								MissionVehs[num218].AttachedBlip.Alpha = 255;
							}
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
						}
					}
				}
				else
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
					if (MissionVehs[num218] != null)
					{
						if (Game.Player.Character.CurrentVehicle == MissionVehs[num218])
						{
							GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
							if (MissionVehs[num218].AttachedBlip != null)
							{
								MissionVehs[num218].AttachedBlip.Alpha = 0;
							}
						}
						else
						{
							GTA.UI.Screen.ShowSubtitle("Steal the ~HUD_COLOUR_BLUEDARK~cars.~HUD_COLOUR_WHITE~");
							if (MissionVehs[num218].AttachedBlip != null)
							{
								MissionVehs[num218].AttachedBlip.Alpha = 255;
							}
						}
					}
				}
				for (int num219 = 0; num219 < 3; num219++)
				{
					if (MissionVehs[num219] != null && MissionVehs[num219].Position.DistanceTo(new Vector3(-11.24234f, -1080.94f, 26.67616f)) < 5f)
					{
						num217++;
					}
				}
				if (num217 >= 2)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Audios.Stop_Music_Event();
					Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
					Script.Wait(2000);
					MissionSwitch = 3;
				}
				break;
			}
			case 3:
			{
				int num204 = 7300;
				string cutscene12 = "mp_int_mcs_12_a3";
				string text13 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num204 = 7300;
					cutscene12 = "mp_intro_mcs_12_a3";
					text13 = "MP_1";
					break;
				case 1:
					num204 = 12000;
					cutscene12 = "mp_int_mcs_12_a3_3";
					text13 = "MP_1";
					break;
				case 2:
					num204 = 12600;
					cutscene12 = "mp_int_mcs_12_a3_4";
					text13 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num204 = 17400;
						cutscene12 = "mp_intro_mcs_12_a1";
						text13 = "MP_Male_Character";
					}
					else
					{
						num204 = 19800;
						cutscene12 = "mp_intro_mcs_12_a2";
						text13 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num205 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped34 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num205, 0);
				Ped ped35 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num205, 1);
				Ped ped36 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num205, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene12);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene12);
					Script.Yield();
				}
				num205 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped34 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num205, 0);
				ped35 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num205, 1);
				ped36 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num205, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped34);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped35);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped36);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text13, 0, 0, 64);
				if (ped34.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped34, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped35.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped35, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped36.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped36, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped34);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped35);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped36);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num204)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num206 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 12300, 16001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num206, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num206, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num206, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num207 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1900, 2491);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num207, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num207, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num207, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num208 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num209 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num208))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num209 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num208);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num209}");
				}
				int num210 = Game.GameTime + num209;
				while (Game.GameTime < num210)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num211 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num211)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num206);
				MPRank.ADD_RP(num207);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 8:
			if (CruelMastersOnlineOffline.checkpoint == 1)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				TimeSpan timeSpan3 = MissionTimer.AddSeconds(MissionTime) - DateTime.Now;
				if (timeSpan3 > TimeSpan.Zero)
				{
					if (timeSpan3.Seconds > 30 || (timeSpan3.Seconds <= 30 && timeSpan3.Minutes != 0))
					{
						Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.95100003f, 0.2f, 0.04f, 255, 255, 255, 130);
						Heist_Hud.drawText3("TIME", 0.78f, 0.935f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{timeSpan3:mm\\:ss}");
						Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
						Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
						Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
						Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.93f, 0.1f);
					}
					else if (timeSpan3.Seconds <= 30 && timeSpan3.Minutes == 0)
					{
						Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.95100003f, 0.2f, 0.04f, 255, 255, 255, 130);
						Heist_Hud.drawText3("TIME", 0.78f, 0.935f, 0.4f, 255, 0, 0, 2, 0.77f, 0.88f);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
						Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{timeSpan3:mm\\:ss}");
						Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
						Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
						Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
						Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
						Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.93f, 0.1f);
					}
				}
				if (timeSpan3 <= TimeSpan.Zero)
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random6 = new Random();
					int num51 = random6.Next(1, 3);
					if (num51 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num51 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "Out of Time", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "Out of Time", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "Out of Time", true, true, true);
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
					int num52 = Game.GameTime + 6000;
					while (Game.GameTime < num52)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if ((MissionVehs[0] != null && MissionVehs[0].IsDead) || (MissionVehs[1] != null && MissionVehs[1].IsDead))
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random7 = new Random();
					int num53 = random7.Next(1, 3);
					if (num53 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num53 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Target Vehicle Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Target Vehicle Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Target Vehicle Was Destroyed", true, true, true);
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
					int num54 = Game.GameTime + 6000;
					while (Game.GameTime < num54)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random8 = new Random();
						int num55 = random8.Next(1, 3);
						if (num55 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num55 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num56 = Game.GameTime + 6000;
						while (Game.GameTime < num56)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				MissionTimer = DateTime.Now;
				MissionTime = 1201;
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-1619.87f, -889.7184f, 9.157294f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-1586.645f, -823.4911f, 9.731589f), 230.2521f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-1619.87f, -889.7184f, 8.157294f);
				Game.Player.Character.Heading = 3.746815f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "GTA Today", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "GTA Today", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "GTA Today", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num67 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num68 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num67))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num68 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num67);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num68}");
				}
				int num69 = Game.GameTime + num68;
				while (Game.GameTime < num69)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
				Props.RemoveProps();
				Groups.RemoveEnemyPeds();
				Vehicles.RemoveVehicles();
				CLEANUP_MISSION_VEHICLE();
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(874602658), new Vector3(-422.6898f, -2659.162f, 5.001692f), new Vector3(0f, 0f, 45.67403f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(CruelMastersOnlineOffline.RequestModel(874602658), new Vector3(-418.0778f, -2654.44f, 5.001693f), new Vector3(0f, 0f, 45.67403f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				Vehicles.SPAWN_VEHICLE(VehicleHash.CogCabrio, new Vector3(155.3662f, -1270.492f, 27.74563f), 118.4594f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Exemplar, new Vector3(153.9805f, -1267.869f, 27.89958f), 118.4658f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.F620, new Vector3(152.5905f, -1265.249f, 27.88593f), 118.4676f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Felon, new Vector3(150.8332f, -1262.052f, 27.99809f), 118.4609f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Felon2, new Vector3(149.4089f, -1259.457f, 27.97221f), 118.4615f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Oracle2, new Vector3(159.4944f, -1264.338f, 27.57742f), 108.5787f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.KanjoSJ, new Vector3(158.6495f, -1261.592f, 27.58364f), 115.1666f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Jackal, new Vector3(157.316f, -1258.945f, 27.92119f), 115.1785f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Oracle, new Vector3(156.1413f, -1255.699f, 27.96235f), 105.9147f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Bullet, new Vector3(155.2759f, -1252.344f, 27.61445f), 106.7503f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Postlude, new Vector3(161.2692f, -1253.565f, 27.60179f), 108.2679f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Blade, new Vector3(160.4314f, -1251.066f, 27.63058f), 102.5894f, sirenactive: false, IsInvincible: false);
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Cheetah, new Vector3(162.3527f, -1256.854f, 27.57405f), 112.1263f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicFrostWhite;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicBlack;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Target Vehicle";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				Vehicles.SPAWN_VEHICLE(VehicleHash.Champion, new Vector3(-1571.049f, -86.71736f, 52.50778f), -90.31644f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Pfister811, new Vector3(-1564.3f, -86.62721f, 52.463f), -89.70398f, sirenactive: false, IsInvincible: false);
				while (MissionVehs[1] == null)
				{
					MissionVehs[1] = World.CreateVehicle(VehicleHash.Superd, new Vector3(-1550.864f, -83.73315f, 52.67568f), -89.14123f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[1], 100f);
				MissionVehs[1].Mods.InstallModKit();
				MissionVehs[1].Mods.PrimaryColor = VehicleColor.MatteDesertTan;
				MissionVehs[1].Mods.SecondaryColor = VehicleColor.MatteDesertTan;
				while (MissionVehs[1].AttachedBlip == null)
				{
					MissionVehs[1].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[1].AttachedBlip != null)
				{
					MissionVehs[1].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[1].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[1].AttachedBlip.Name = "Target Vehicle";
					MissionVehs[1].AttachedBlip.IsShortRange = false;
					MissionVehs[1].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1557.911f, -87.98491f, 53.13044f), 22.63289f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1568.64f, -89.81188f, 53.32812f), -33.29866f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1572.124f, -89.54217f, 53.32791f), -71.53128f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1581.948f, -86.04447f, 53.291f), -91.79527f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1589.176f, -83.97132f, 53.34155f), -106.6887f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1587.248f, -81.82761f, 53.34097f), -113.0882f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1584.056f, -81.20994f, 53.33644f), -132.5379f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1589.994f, -89.23446f, 53.32444f), 177.1015f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1565.664f, -125.7671f, 53.32829f), -51.67189f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1551.802f, -124.1071f, 53.32809f), -26.59308f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1536.479f, -72.69613f, 53.19162f), 35.28799f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Highsec01SMM, new Vector3(-1532.114f, -38.35735f, 56.38162f), 8.981658f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.BlipUpEnemyPeds();
				Groups.GIVE_AI_RANDOM_WEAPON();
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
				MissionTimer = DateTime.Now;
				MissionTime = 1201;
				MissionSwitch = 2;
				break;
			case 2:
			{
				int num65 = 0;
				int num66 = 0;
				if (MissionVehs[0] != null && MissionVehs[0].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					num66 = 0;
				}
				if (MissionVehs[1] != null && MissionVehs[1].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[1])
				{
					num66 = 1;
				}
				if (MissionVehs[num66] != null)
				{
					if (Game.Player.Character.CurrentVehicle == MissionVehs[num66])
					{
						if (MissionVehs[num66].AttachedBlip != null && MissionVehs[num66].AttachedBlip.Alpha > 0)
						{
							Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected a target vehicle.", blinking: true);
							MissionVehs[num66].AttachedBlip.Alpha = 0;
						}
						GTA.UI.Screen.ShowSubtitle("Take the ~HUD_COLOUR_BLUEDARK~vehicle~HUD_COLOUR_WHITE~ to the ~y~docks.~w~");
						if (CruelMastersOnlineOffline.missionBlip == null)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
							}
							while (CruelMastersOnlineOffline.missionBlip == null)
							{
								CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-417.166f, -2660.096f, 6.045636f));
								Script.Wait(0);
							}
							HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
						}
						else
						{
							if (MissionVehs[num66].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
							{
								Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
								World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
							}
							if (MissionVehs[num66].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 10f && MissionVehs[num66].AttachedBlip != null)
							{
								Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ delivered a target vehicle.", blinking: true);
								MissionVehs[num66].AttachedBlip.Delete();
								MissionVehs[num66].IsDriveable = false;
								MissionVehs[num66].LockStatus = VehicleLockStatus.CannotEnter;
								if (CruelMastersOnlineOffline.missionBlip != null)
								{
									CruelMastersOnlineOffline.missionBlip.Delete();
									CruelMastersOnlineOffline.missionBlip = null;
									HudHandler.CLEAR_GPS_ROUTE();
								}
								Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
								Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[num66], 4f, 1, 1);
								Script.Wait(2000);
								Game.Player.Character.Task.LeaveVehicle();
							}
						}
					}
					else
					{
						GTA.UI.Screen.ShowSubtitle("Steal the ~HUD_COLOUR_BLUEDARK~target vehicles.~HUD_COLOUR_WHITE~");
						if (MissionVehs[num66].AttachedBlip != null)
						{
							MissionVehs[num66].AttachedBlip.Alpha = 255;
						}
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
					}
				}
				for (int m = 0; m < 3; m++)
				{
					if (MissionVehs[m] != null && MissionVehs[m].Position.DistanceTo(new Vector3(-417.166f, -2660.096f, 6.045636f)) < 10f)
					{
						num65++;
					}
				}
				if (num65 < 2)
				{
					break;
				}
				if (MissionVehs[0] != null)
				{
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Delete();
					}
					MissionVehs[0].MarkAsNoLongerNeeded();
					MissionVehs[0] = null;
				}
				if (MissionVehs[1] != null)
				{
					if (MissionVehs[1].AttachedBlip != null)
					{
						MissionVehs[1].AttachedBlip.Delete();
					}
					MissionVehs[1].MarkAsNoLongerNeeded();
					MissionVehs[1] = null;
				}
				Mobile_Phone.CLEAR_TEXTS();
				Mobile_Phone.CREATE_TEXT("Simeon", "Another two vehicles to get my friend! Hurry! We do not have all night!", "char_simeon");
				CruelMastersOnlineOffline.ShowNotificationLong("Another two vehicles to get my friend!", " Hurry! We do not have all night!", "", "char_simeon", "char_simeon", "Simeon", "", blink: true);
				MissionSwitch = 3;
				break;
			}
			case 3:
				Groups.RemoveEnemyPeds();
				Vehicles.RemoveVehicles();
				Vehicles.SPAWN_VEHICLE(VehicleHash.Policeb, new Vector3(176.1317f, 97.52975f, 88.55379f), -36.006f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Policeb, new Vector3(175.7093f, 102.0055f, 89.7377f), -11.82316f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Police3, new Vector3(181.5978f, 109.6804f, 92.34521f), -91.61649f, sirenactive: false, IsInvincible: false);
				Groups.SPAWN_AI(PedHash.Cop01SMY, new Vector3(175.1246f, 98.36067f, 89.26472f), -22.62178f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Cop01SMY, new Vector3(176.8652f, 101.6875f, 90.22717f), -25.02724f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Cop01SMY, new Vector3(184.2898f, 107.9049f, 92.44958f), 129.6919f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Cop01SMY, new Vector3(182.045f, 111.3658f, 92.95259f), 135.22f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.StingerGT, new Vector3(181.3434f, 104.668f, 90.75089f), -21.26047f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicGreen;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicGreen;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Target Vehicle";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				Vehicles.SPAWN_VEHICLE(VehicleHash.Cyclone, new Vector3(327.9335f, -2027.664f, 19.409f), -37.40692f, sirenactive: false, IsInvincible: false);
				while (MissionVehs[1] == null)
				{
					MissionVehs[1] = World.CreateVehicle(VehicleHash.Turismor, new Vector3(332.3233f, -2031.83f, 19.3445f), 139.8475f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[1], 100f);
				MissionVehs[1].Mods.InstallModKit();
				MissionVehs[1].Mods.PrimaryColor = VehicleColor.MetallicDarkBlue;
				MissionVehs[1].Mods.SecondaryColor = VehicleColor.MetallicDarkBlue;
				while (MissionVehs[1].AttachedBlip == null)
				{
					MissionVehs[1].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[1].AttachedBlip != null)
				{
					MissionVehs[1].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[1].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[1].AttachedBlip.Name = "Target Vehicle";
					MissionVehs[1].AttachedBlip.IsShortRange = false;
					MissionVehs[1].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				Groups.SPAWN_AI(PedHash.MexGoon03GMY, new Vector3(335.951f, -2035.751f, 20.26797f), -99.51598f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.MexGoon03GMY, new Vector3(337.2058f, -2034.37f, 20.42561f), -154.6896f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.MexGoon03GMY, new Vector3(338.6539f, -2035.894f, 20.46088f), 102.4872f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.MexGoon03GMY, new Vector3(337.7887f, -2037.475f, 20.31959f), 7.546575f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.BlipUpEnemyPeds();
				Groups.GIVE_AI_RANDOM_WEAPON();
				MissionSwitch = 4;
				break;
			case 4:
			{
				int num63 = 0;
				int num64 = 0;
				if (MissionVehs[0] != null && MissionVehs[0].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					num64 = 0;
				}
				if (MissionVehs[1] != null && MissionVehs[1].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[1])
				{
					num64 = 1;
				}
				if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
				{
					Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
				}
				if (MissionVehs[num64] != null)
				{
					if (Game.Player.Character.CurrentVehicle == MissionVehs[num64])
					{
						if (MissionVehs[num64].AttachedBlip != null && MissionVehs[num64].AttachedBlip.Alpha > 0)
						{
							Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected a target vehicle.", blinking: true);
							MissionVehs[num64].AttachedBlip.Alpha = 0;
						}
						GTA.UI.Screen.ShowSubtitle("Take the ~HUD_COLOUR_BLUEDARK~vehicle~HUD_COLOUR_WHITE~ to the ~y~docks.~w~");
						if (CruelMastersOnlineOffline.missionBlip == null)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
							}
							while (CruelMastersOnlineOffline.missionBlip == null)
							{
								CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-417.166f, -2660.096f, 6.045636f));
								Script.Wait(0);
							}
							HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
						}
						else
						{
							if (MissionVehs[num64].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
							{
								Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
								World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
							}
							if (MissionVehs[num64].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 10f && MissionVehs[num64].AttachedBlip != null)
							{
								Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ delivered a target vehicle.", blinking: true);
								MissionVehs[num64].AttachedBlip.Delete();
								MissionVehs[num64].IsDriveable = false;
								MissionVehs[num64].LockStatus = VehicleLockStatus.CannotEnter;
								if (CruelMastersOnlineOffline.missionBlip != null)
								{
									CruelMastersOnlineOffline.missionBlip.Delete();
									CruelMastersOnlineOffline.missionBlip = null;
									HudHandler.CLEAR_GPS_ROUTE();
								}
								Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
								Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[num64], 4f, 1, 1);
								Script.Wait(2000);
								Game.Player.Character.Task.LeaveVehicle();
							}
						}
					}
					else
					{
						GTA.UI.Screen.ShowSubtitle("Steal the ~HUD_COLOUR_BLUEDARK~target vehicles.~HUD_COLOUR_WHITE~");
						if (MissionVehs[num64].AttachedBlip != null)
						{
							MissionVehs[num64].AttachedBlip.Alpha = 255;
						}
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
					}
				}
				for (int l = 0; l < 3; l++)
				{
					if (MissionVehs[l] != null && MissionVehs[l].Position.DistanceTo(new Vector3(-417.166f, -2660.096f, 6.045636f)) < 10f)
					{
						num63++;
					}
				}
				if (num63 < 2)
				{
					break;
				}
				if (MissionVehs[0] != null)
				{
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Delete();
					}
					MissionVehs[0].MarkAsNoLongerNeeded();
					MissionVehs[0] = null;
				}
				if (MissionVehs[1] != null)
				{
					if (MissionVehs[1].AttachedBlip != null)
					{
						MissionVehs[1].AttachedBlip.Delete();
					}
					MissionVehs[1].MarkAsNoLongerNeeded();
					MissionVehs[1] = null;
				}
				Script.Wait(2000);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Script.Wait(1000);
				Audios.Stop_Music_Event();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Script.Wait(1000);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Script.Wait(1000);
				MissionSwitch = 5;
				break;
			}
			case 5:
			{
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num57 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 12300, 18001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num57, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num57, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num57, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num58 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 2000, 3091);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num58, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num58, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num58, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num59 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num60 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num59))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num60 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num59);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num60}");
				}
				int num61 = Game.GameTime + num60;
				while (Game.GameTime < num61)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num62 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num62)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num57);
				MPRank.ADD_RP(num58);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 9:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if ((MissionVehs[0] != null && MissionVehs[0].IsDead) || (MissionVehs[1] != null && MissionVehs[1].IsDead))
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random10 = new Random();
					int num84 = random10.Next(1, 3);
					if (num84 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num84 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
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
					int num85 = Game.GameTime + 6000;
					while (Game.GameTime < num85)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random11 = new Random();
						int num86 = random11.Next(1, 3);
						if (num86 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num86 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num87 = Game.GameTime + 6000;
						while (Game.GameTime < num87)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-138.6569f, -1767.072f, 29.76977f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-118.3902f, -1761.79f, 29.28017f), 248.3432f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-138.6569f, -1767.072f, 28.76977f);
				Game.Player.Character.Heading = 207.8738f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "It Takes a Thief", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "It Takes a Thief", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "It Takes a Thief", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num96 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num97 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num96))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num97 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num96);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num97}");
				}
				int num98 = Game.GameTime + num97;
				while (Game.GameTime < num98)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array15 = new Vector3[2]
				{
					new Vector3(-110.1246f, -1770.861f, 29.85649f),
					new Vector3(-118.7042f, -1769.871f, 29.85334f)
				};
				float[] array16 = new float[2] { 255.6659f, 42.98373f };
				int num99 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array15.Length);
				RESPAWN.SET_MIS_STAT(array15[num99], array16[num99], 0, misretaskbool: true);
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Jackal, new Vector3(813.9736f, -3156.529f, 4.621095f), 59.92235f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicDarkBlue;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicDarkBlue;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Car";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				while (MissionVehs[1] == null)
				{
					MissionVehs[1] = World.CreateVehicle(VehicleHash.Coquette, new Vector3(824.1144f, -3160.47f, 4.193443f), 72.35915f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[1], 100f);
				MissionVehs[1].Mods.InstallModKit();
				MissionVehs[1].Mods.PrimaryColor = VehicleColor.MetallicRaceYellow;
				MissionVehs[1].Mods.SecondaryColor = VehicleColor.MetallicRaceYellow;
				while (MissionVehs[1].AttachedBlip == null)
				{
					MissionVehs[1].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[1].AttachedBlip != null)
				{
					MissionVehs[1].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[1].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[1].AttachedBlip.Name = "Car";
					MissionVehs[1].AttachedBlip.IsShortRange = false;
					MissionVehs[1].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.Bevhills02AMM, new Vector3(813.0821f, -3157.961f, 4.875438f), 30.62051f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.pedList[0].SetIntoVehicle(MissionVehs[0], VehicleSeat.Driver);
				Groups.pedList[0].Task.CruiseWithVehicle(MissionVehs[0], 30f, DrivingStyle.Rushed);
				Groups.SPAWN_AI(PedHash.Bevhills02AMM, new Vector3(823.676f, -3162.401f, 4.892153f), 56.87628f, WeaponHash.Unarmed, 0, 25, setascop: false, 2, 1, Relationship.Pedestrians, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.pedList[1].SetIntoVehicle(MissionVehs[1], VehicleSeat.Driver);
				Groups.pedList[1].Task.CruiseWithVehicle(MissionVehs[1], 30f, DrivingStyle.Rushed);
				CruelMastersOnlineOffline.NoCopsOnMission = false;
				MissionSwitch = 2;
				break;
			}
			case 2:
			{
				int num100 = 0;
				int num101 = 0;
				if (MissionVehs[0] != null && MissionVehs[0].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					num101 = 0;
				}
				if (MissionVehs[1] != null && MissionVehs[1].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[1])
				{
					num101 = 1;
				}
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (MissionVehs[num101] != null)
					{
						if (Game.Player.Character.CurrentVehicle == MissionVehs[num101])
						{
							if (MissionVehs[num101].AttachedBlip != null && MissionVehs[num101].AttachedBlip.Alpha > 0)
							{
								Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected a car.", blinking: true);
								MissionVehs[num101].AttachedBlip.Alpha = 0;
							}
							GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~car~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
							if (CruelMastersOnlineOffline.missionBlip == null)
							{
								if (CruelMastersOnlineOffline.missionBlip != null)
								{
									CruelMastersOnlineOffline.missionBlip.Delete();
									CruelMastersOnlineOffline.missionBlip = null;
								}
								while (CruelMastersOnlineOffline.missionBlip == null)
								{
									CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
									Script.Wait(0);
								}
								HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							}
							else
							{
								if (MissionVehs[num101].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
								{
									Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
									World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
								}
								if (MissionVehs[num101].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f && MissionVehs[num101].AttachedBlip != null)
								{
									Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ delivered a car.", blinking: true);
									MissionVehs[num101].AttachedBlip.Delete();
									MissionVehs[num101].IsDriveable = false;
									MissionVehs[num101].LockStatus = VehicleLockStatus.CannotEnter;
									if (CruelMastersOnlineOffline.missionBlip != null)
									{
										CruelMastersOnlineOffline.missionBlip.Delete();
										CruelMastersOnlineOffline.missionBlip = null;
										HudHandler.CLEAR_GPS_ROUTE();
									}
									Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
									Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[num101], 4f, 1, 1);
									Script.Wait(2000);
									Game.Player.Character.Task.LeaveVehicle();
								}
							}
						}
						else
						{
							GTA.UI.Screen.ShowSubtitle("Retrieve the ~HUD_COLOUR_BLUEDARK~cars.~HUD_COLOUR_WHITE~");
							if (MissionVehs[num101].AttachedBlip != null)
							{
								MissionVehs[num101].AttachedBlip.Alpha = 255;
							}
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
						}
					}
				}
				else
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
					if (MissionVehs[num101] != null)
					{
						if (Game.Player.Character.CurrentVehicle == MissionVehs[num101])
						{
							GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
							if (MissionVehs[num101].AttachedBlip != null)
							{
								MissionVehs[num101].AttachedBlip.Alpha = 0;
							}
						}
						else
						{
							GTA.UI.Screen.ShowSubtitle("Retrieve the ~HUD_COLOUR_BLUEDARK~cars.~HUD_COLOUR_WHITE~");
							if (MissionVehs[num101].AttachedBlip != null)
							{
								MissionVehs[num101].AttachedBlip.Alpha = 255;
							}
						}
					}
				}
				for (int n = 0; n < 3; n++)
				{
					if (MissionVehs[n] != null && MissionVehs[n].Position.DistanceTo(new Vector3(-11.24234f, -1080.94f, 26.67616f)) < 5f)
					{
						num100++;
					}
				}
				if (num100 >= 2)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Audios.Stop_Music_Event();
					Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
					Script.Wait(2000);
					MissionSwitch = 3;
				}
				break;
			}
			case 3:
			{
				int num88 = 7300;
				string cutscene5 = "mp_int_mcs_12_a3";
				string text6 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num88 = 7300;
					cutscene5 = "mp_intro_mcs_12_a3";
					text6 = "MP_1";
					break;
				case 1:
					num88 = 12000;
					cutscene5 = "mp_int_mcs_12_a3_3";
					text6 = "MP_1";
					break;
				case 2:
					num88 = 12600;
					cutscene5 = "mp_int_mcs_12_a3_4";
					text6 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num88 = 17400;
						cutscene5 = "mp_intro_mcs_12_a1";
						text6 = "MP_Male_Character";
					}
					else
					{
						num88 = 19800;
						cutscene5 = "mp_intro_mcs_12_a2";
						text6 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num89 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped13 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num89, 0);
				Ped ped14 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num89, 1);
				Ped ped15 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num89, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene5);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene5);
					Script.Yield();
				}
				num89 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped13 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num89, 0);
				ped14 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num89, 1);
				ped15 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num89, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped13);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped14);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped15);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text6, 0, 0, 64);
				if (ped13.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped13, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped14.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped14, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped15.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped15, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped13);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped14);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped15);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num88)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num90 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 13300, 17001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num90, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num90, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num90, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num91 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1901, 2591);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num91, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num91, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num91, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num92 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num93 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num92))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num93 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num92);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num93}");
				}
				int num94 = Game.GameTime + num93;
				while (Game.GameTime < num94)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num95 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num95)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 24.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num90);
				MPRank.ADD_RP(num91);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 10:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if ((MissionVehs[0] != null && MissionVehs[0].IsDead) || (MissionVehs[1] != null && MissionVehs[1].IsDead))
				{
					CruelMastersOnlineOffline.NoCopsOnMission = true;
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random3 = new Random();
					int num31 = random3.Next(1, 3);
					if (num31 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num31 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "A Car Was Destroyed", true, true, true);
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
					int num32 = Game.GameTime + 6000;
					while (Game.GameTime < num32)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						CruelMastersOnlineOffline.NoCopsOnMission = true;
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random4 = new Random();
						int num33 = random4.Next(1, 3);
						if (num33 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num33 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num34 = Game.GameTime + 6000;
						while (Game.GameTime < num34)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-1418.339f, 64.18626f, 52.32166f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-1420.017f, 51.76096f, 51.62347f), 6.841022f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-1418.339f, 64.18626f, 51.32166f);
				Game.Player.Character.Heading = 93.35679f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Rich Men in Richman", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Rich Men in Richman", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Rich Men in Richman", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num46 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num47 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num46))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num47 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num46);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num47}");
				}
				int num48 = Game.GameTime + num47;
				while (Game.GameTime < num48)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array9 = new Vector3[2]
				{
					new Vector3(-1479f, 61.82117f, 53.61823f),
					new Vector3(-1462.279f, 63.8334f, 52.81077f)
				};
				float[] array10 = new float[2] { 287.2708f, 111.6443f };
				int num45 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array9.Length);
				RESPAWN.SET_MIS_STAT(array9[num45], array10[num45], 0, misretaskbool: true);
				Function.Call(Hash.CLEAR_AREA, -1526.596f, 83.53424f, 56.58083f, 30f, true, false, false, false);
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.StingerGT, new Vector3(-1524.723f, 83.99756f, 54.96749f), 8.380297f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicBlack;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicBlack;
				MissionVehs[0].CanTiresBurst = false;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Car";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.NoDisplay;
				}
				while (MissionVehs[1] == null)
				{
					MissionVehs[1] = World.CreateVehicle(VehicleHash.Superd, new Vector3(-1528.742f, 83.43042f, 55.18333f), 5.557172f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[1], 100f);
				MissionVehs[1].Mods.InstallModKit();
				MissionVehs[1].Mods.PrimaryColor = VehicleColor.MatteDesertTan;
				MissionVehs[1].Mods.SecondaryColor = VehicleColor.MatteDesertTan;
				MissionVehs[1].CanTiresBurst = false;
				while (MissionVehs[1].AttachedBlip == null)
				{
					MissionVehs[1].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[1].AttachedBlip != null)
				{
					MissionVehs[1].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[1].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[1].AttachedBlip.Name = "Car";
					MissionVehs[1].AttachedBlip.IsShortRange = false;
					MissionVehs[1].AttachedBlip.DisplayType = BlipDisplayType.NoDisplay;
				}
				Groups.RemoveEnemyPeds();
				Groups.SPAWN_AI(PedHash.Security01SMM, new Vector3(-1492.371f, 94.73606f, 54.00407f), 134.5757f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Security01SMM, new Vector3(-1533.152f, 102.5769f, 55.78426f), -142.2609f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Security01SMM, new Vector3(-1544.188f, 107.7555f, 55.78495f), 92.09549f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.SPAWN_AI(PedHash.Security01SMM, new Vector3(-1548.015f, 103.9833f, 55.77425f), 2.17415f, WeaponHash.Pistol, 100, 25, setascop: false, 2, 2, Relationship.Hate, AlwaysKeppTask: false, BlockPermenentEvents: false);
				Groups.BlipUpEnemyPeds();
				Groups.GIVE_AI_RANDOM_WEAPON();
				Props.SPAWN_PROP_NO_OFFSET("hei_prop_hei_keypad_03", new Vector3(-1473.965f, 67.5168f, 53.8876f), new Vector3(0f, 0f, 94.4866f), dynamic: false, frozen: true, collision: true, IsInvincible: true, IsVisible: true);
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Go to ~y~Richman mansion.~w~");
				if (CruelMastersOnlineOffline.missionBlip == null)
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
					}
					while (CruelMastersOnlineOffline.missionBlip == null)
					{
						CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-1473.965f, 67.5168f, 53.8876f));
						Script.Wait(0);
					}
					HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
				}
				else if (Game.Player.Character.Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 30f)
				{
					CruelMastersOnlineOffline.missionBlip.Sprite = BlipSprite.Standard;
					CruelMastersOnlineOffline.missionBlip.Color = BlipColor.Green;
					CruelMastersOnlineOffline.missionBlip.Name = "Keypad";
					HudHandler.CLEAR_GPS_ROUTE();
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
					MissionSwitch = 3;
				}
				break;
			case 3:
			{
				Prop[] allProps = World.GetAllProps(-2125423493, -1859471240);
				Prop[] array11 = allProps;
				foreach (Prop prop in array11)
				{
					if (prop != null)
					{
						prop.IsPositionFrozen = true;
					}
				}
				GTA.UI.Screen.ShowSubtitle("Hack the ~g~keypad.~w~");
				Prop prop2 = Props.propList[0];
				switch (Hacking_Index)
				{
				case 0:
					if (!(Game.Player.Character.Position.DistanceTo(prop2.Position) < 1.5f))
					{
						break;
					}
					GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to hack the terminal.");
					if (Game.IsControlJustPressed(Control.Context))
					{
						Audios.TRIGGER_MUSIC_EVENT("FBI5A_CUT_PIPE_START");
						Game.Player.Character.IsInvincible = true;
						Hacking_Lives = 3f;
						TRYDL = false;
						ErrorTimer = 0;
						ClickBools[0] = false;
						ClickBools[1] = true;
						CruelMastersOnlineOffline.LoadDict("anim@heists@keypad@");
						CruelMastersOnlineOffline.LoadDict("anim@heists@keypad@");
						Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_MPHEIST/HEIST_USE_KEYPAD");
						Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_MPHEIST/HEIST_USE_KEYPAD", false, -1);
						Script.Wait(500);
						Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Game.Player.Character, false, true, true, false);
						int num49 = 0;
						Function.Call(Hash.OPEN_SEQUENCE_TASK, &num49);
						Vector3 vector = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, prop2, 0f, -0.4f, -0.6f);
						Vector3 vector2 = Function.Call<Vector3>(Hash.GET_ENTITY_ROTATION, prop2, 2);
						Function.Call(Hash.GET_GROUND_Z_FOR_3D_COORD, vector.X, vector.Y, vector.Z, &vector.Z, false, false);
						Vector3 vector3 = Function.Call<Vector3>(Hash.GET_ENTITY_COORDS, Game.Player.Character, true);
						if (Function.Call<float>(Hash.GET_DISTANCE_BETWEEN_COORDS, vector3.X, vector3.Y, vector3.Z, vector.X, vector.Y, vector.Z, false) > 0.2f)
						{
							Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 20000, 0.25f, 0, vector2.Z);
						}
						Function.Call(Hash.TASK_LOOK_AT_ENTITY, 0, prop2, 2000, 0, 2);
						Function.Call(Hash.CLOSE_SEQUENCE_TASK, num49);
						Function.Call(Hash.TASK_PERFORM_SEQUENCE, Game.Player.Character, num49);
						Function.Call(Hash.CLEAR_SEQUENCE_TASK, &num49);
						Script.Wait(500);
						while (Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, Game.Player.Character) != -1)
						{
							Script.Wait(0);
						}
						Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
						HudHandler.HudandRadar(Hud: false, Radar: false);
						while (CruelMastersOnlineOffline.CutsceneCam == null)
						{
							CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(-1473.818f, 66.8853f, 53.92913f), new Vector3(0f, 0f, 349.6172f), 50f);
							Script.Wait(0);
						}
						while (CruelMastersOnlineOffline.CutsceneCam2 == null)
						{
							CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-1473.818f, 66.4353f, 53.92913f), new Vector3(0f, 0f, 349.6172f), 48f);
							Script.Wait(0);
						}
						Vector3 vector4 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, prop2, 0f, -0.4f, -0.6f);
						Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, Game.Player.Character, "anim@heists@keypad@", "enter", vector4.X, vector4.Y, vector4.Z, 0f, 0f, prop2.Heading, 4f, -8f, -1, 1572874, 0f, 2, 0);
						Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
						World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
						CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 6000, 0, 0);
						while (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, "anim@heists@keypad@", "enter") < 0.99f)
						{
							Script.Wait(0);
						}
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, "anim@heists@keypad@", "idle_a", 8f, -8f, -1, 17825802, 0f, false, false, false);
						Script.Wait(2000);
						Function.Call(Hash.START_AUDIO_SCENE, "DLC_HEIST_PACIFIC_BANK_HACK_PASSWORD_SCENE");
						UnloadLoadehacker();
						Loadehacker();
						UnloadLoadehacker();
						Loadehacker();
						Script.Wait(500);
						Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
						if (Function.Call<bool>(Hash.GET_IS_WIDESCREEN))
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "ADD_PROGRAM", 7f, 4f, -1f, -1f, -1f, "MyComputer", 0, 0, 0, 0);
						}
						else
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "ADD_PROGRAM", 8f, 4f, -1f, -1f, -1f, "MyComputer", 0, 0, 0, 0);
						}
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_BACKGROUND", 4f, -1082130432, -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						string text4 = "GR_PWD_RA";
						Random random5 = new Random();
						int num50 = random5.Next(0, 14);
						if (num50 == 0)
						{
							text4 = "GR_PWD_RA";
						}
						if (num50 == 1)
						{
							text4 = "GR_PWD_PA";
						}
						if (num50 == 2)
						{
							text4 = "GR_PWD_PE";
						}
						if (num50 == 3)
						{
							text4 = "GR_PWD_GE";
						}
						if (num50 == 4)
						{
							text4 = "GR_PWD_CH";
						}
						if (num50 == 5)
						{
							text4 = "GR_PWD_FI";
						}
						if (num50 == 6)
						{
							text4 = "GR_PWD_PR";
						}
						if (num50 == 7)
						{
							text4 = "GR_PWD_UN";
						}
						if (num50 == 8)
						{
							text4 = "GR_PWD_DE";
						}
						if (num50 == 9)
						{
							text4 = "GR_PWD_FO";
						}
						if (num50 == 10)
						{
							text4 = "GR_PWD_AR";
						}
						if (num50 == 11)
						{
							text4 = "GR_PWD_TO";
						}
						if (num50 == 12)
						{
							text4 = "GR_PWD_IN";
						}
						if (num50 == 13)
						{
							text4 = "GR_PWD_PRI";
						}
						if (num50 == 14)
						{
							text4 = "GR_PWD_LA";
						}
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_STRING, hackingScalwform, "SET_ROULETTE_WORD", text4, 0, 0, 0, 0);
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_LABELS");
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "H_ICON_1");
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "H_ICON_2");
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "H_ICON_3");
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "H_ICON_4");
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "H_ICON_5");
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "H_ICON_6");
						Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
						Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_SPEED", 10f, -1082130432, -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 0f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 1f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 2f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 3f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 4f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 5f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 6f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COLUMN_SPEED", 7f, Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, 40f, 50f), -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "OPEN_APP", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COUNTDOWN", 0f, 59f, 0f, -1082130432, -1082130432);
						Game.Player.CanControlCharacter = false;
						Hacking_Index = 1;
					}
					break;
				case 1:
					if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 201) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 237) || Game.IsControlJustPressed(Control.FrontendAccept))
					{
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT_SELECT");
						uLocal_70 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK", 0, true);
					}
					if (Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, uLocal_70))
					{
						FeedBackNumber = Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, uLocal_70);
					}
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, hackingScalwform, 255, 255, 255, 255, 0);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 27, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 19, true);
					if (Game.GameTime > MoveTimer)
					{
						if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 32) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 172))
						{
							MoveTimer = Game.GameTime + 1;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 8);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "MOVE_CURSOR");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, 0f);
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, -10.5f);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 33) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 173))
						{
							MoveTimer = Game.GameTime + 1;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 9);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "MOVE_CURSOR");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, 0f);
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, 10.5f);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 34) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 174))
						{
							MoveTimer = Game.GameTime + 1;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 10);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "MOVE_CURSOR");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, -10.5f);
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, 0f);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 35) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 175))
						{
							MoveTimer = Game.GameTime + 1;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 11);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "MOVE_CURSOR");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, 10.5f);
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, 0f);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
					}
					if (FeedBackNumber == 82 && !TRYDL)
					{
						if (ClickBools[0])
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "OPEN_APP", 0f, -1082130432, -1082130432, -1082130432, -1082130432);
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COUNTDOWN", 0f, 60f, 0f, -1082130432, -1082130432);
							MyHackingTimer = new VariableTimer(60000);
							MyHackingTimer.Start();
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_GOOD", 0, true);
							IPSound = Function.Call<int>(Hash.GET_SOUND_ID);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, IPSound, "HACKING_COUNTDOWN_IP_FIND", 0, true);
							MoveSoundTimer = 0;
							FeedBackNumber = -1;
							Hacking_Index = 2;
						}
						else
						{
							ErrorTimer = Game.GameTime + 500;
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "OPEN_ERROR_POPUP", 1f, -1f, -1f, -1f, -1f, "TRYBRUTE", 0, 0, 0, 0);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_BAD", 0, true);
							TRYDL = true;
							FeedBackNumber = -1;
						}
					}
					if (FeedBackNumber == 83 && !TRYDL)
					{
						if (!ClickBools[0])
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "OPEN_APP", 1f, -1082130432, -1082130432, -1082130432, -1082130432);
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COUNTDOWN", 0f, 60f, 0f, -1082130432, -1082130432);
							MyHackingTimer = new VariableTimer(60000);
							MyHackingTimer.Start();
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_GOOD", 0, true);
							IPSound = Function.Call<int>(Hash.GET_SOUND_ID);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, IPSound, "HACKING_COUNTDOWN_IP_FIND", 0, true);
							FeedBackNumber = -1;
							Hacking_Index = 3;
						}
						else
						{
							ErrorTimer = Game.GameTime + 500;
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "OPEN_ERROR_POPUP", 1f, -1f, -1f, -1f, -1f, "TRYHACK", 0, 0, 0, 0);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_BAD", 0, true);
							TRYDL = true;
							FeedBackNumber = -1;
						}
					}
					if (FeedBackNumber == 80 && !TRYDL)
					{
						ErrorTimer = Game.GameTime + 500;
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "OPEN_ERROR_POPUP", 1f, -1f, -1f, -1f, -1f, "ACCESSD", 0, 0, 0, 0);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_BAD", 0, true);
						TRYDL = true;
						FeedBackNumber = -1;
					}
					if (ErrorTimer < Game.GameTime && TRYDL)
					{
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "OPEN_ERROR_POPUP", 0f, -1f, -1f, -1f, -1f, "ACCESSD", 0, 0, 0, 0);
						ErrorTimer = Game.GameTime + 3000;
						TRYDL = false;
					}
					if (ClickBools[0] && ClickBools[1])
					{
						ClickBools[0] = false;
						ClickBools[1] = false;
						Hacking_Index = 6;
					}
					break;
				case 2:
				{
					if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 201) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 237) || Game.IsControlJustPressed(Control.FrontendAccept))
					{
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT_SELECT");
						uLocal_70 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
					}
					if (Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, uLocal_70))
					{
						FeedBackNumber = Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, uLocal_70);
					}
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, hackingScalwform, 255, 255, 255, 255, 0);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 27, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 19, true);
					if (Game.GameTime > MoveTimer)
					{
						if (Game.IsControlPressed(Control.MoveUpOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 8);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Game.IsControlPressed(Control.MoveDownOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 9);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Game.IsControlPressed(Control.MoveLeftOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 10);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Game.IsControlPressed(Control.MoveRightOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 11);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
					}
					MyHackingTimer.Update(1f);
					TimeSpan timeSpan = TimeSpan.FromMilliseconds(MyHackingTimer.Counter);
					Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COUNTDOWN", 0f, (float)timeSpan.Seconds, (float)timeSpan.Milliseconds, -1082130432, -1082130432);
					if ((float)timeSpan.Seconds < 1f && (float)timeSpan.Milliseconds < 1f)
					{
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_FAILURE", 0, true);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "SET_IP_OUTCOME", 1f, -1f, -1f, -1f, -1f, "LOSTIP", 0, 0, 0, 0);
						Hacking_Index = 4;
						if (!Function.Call<bool>(Hash.HAS_SOUND_FINISHED, IPSound))
						{
							Function.Call(Hash.STOP_SOUND, IPSound);
							IPSound = 0;
						}
					}
					if (FeedBackNumber == 85)
					{
						if (Hacking_Lives > 0f)
						{
							Hacking_Lives--;
						}
						if (Hacking_Lives > 0f)
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_BAD", 0, true);
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD, hackingScalwform, "RESET_IP");
						}
						if (Hacking_Lives <= 0f)
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_FAILURE", 0, true);
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "SET_IP_OUTCOME", 1f, -1f, -1f, -1f, -1f, "LOSTIP", 0, 0, 0, 0);
							Hacking_Index = 4;
							if (!Function.Call<bool>(Hash.HAS_SOUND_FINISHED, IPSound))
							{
								Function.Call(Hash.STOP_SOUND, IPSound);
								IPSound = -1;
							}
						}
						FeedBackNumber = -1;
					}
					if (FeedBackNumber == 84)
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_GOOD", 0, true);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "SET_IP_OUTCOME", 1f, -1f, -1f, -1f, -1f, "WINIP", 0, 0, 0, 0);
						if (!Function.Call<bool>(Hash.HAS_SOUND_FINISHED, IPSound))
						{
							Function.Call(Hash.STOP_SOUND, IPSound);
							IPSound = -1;
						}
						Hacking_Index = 5;
						FeedBackNumber = -1;
					}
					if (MoveSoundTimer < Game.GameTime)
					{
						MoveSoundTimer = Game.GameTime + 200;
						if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 32) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 172) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 33) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 173) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 34) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 174) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 35) || Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 2, 175))
						{
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_MOVE_CURSOR", 0, true);
						}
					}
					break;
				}
				case 3:
				{
					if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 201) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 237) || Game.IsControlJustPressed(Control.FrontendAccept))
					{
						Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT_SELECT");
						uLocal_70 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
					}
					if (Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, uLocal_70))
					{
						FeedBackNumber = Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, uLocal_70);
					}
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, hackingScalwform, 255, 255, 255, 255, 0);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 27, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 19, true);
					if (Game.GameTime > MoveTimer)
					{
						if (Game.IsControlPressed(Control.MoveUpOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 8);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Game.IsControlPressed(Control.MoveDownOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 9);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Game.IsControlPressed(Control.MoveLeftOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 10);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
						if (Game.IsControlPressed(Control.MoveRightOnly))
						{
							MoveTimer = Game.GameTime + 100;
							Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, hackingScalwform, "SET_INPUT_EVENT");
							Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 11);
							Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
						}
					}
					MyHackingTimer.Update(1f);
					TimeSpan timeSpan2 = TimeSpan.FromMilliseconds(MyHackingTimer.Counter);
					Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_COUNTDOWN", 0f, (float)timeSpan2.Seconds, (float)timeSpan2.Milliseconds, -1082130432, -1082130432);
					if ((float)timeSpan2.Seconds < 1f && (float)timeSpan2.Milliseconds < 1f)
					{
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_FAILURE", 0, true);
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "SET_ROULETTE_OUTCOME", 1f, -1f, -1f, -1f, -1f, "LOSEBRUTE", 0, 0, 0, 0);
						IpTryFailedTimer = Game.GameTime + 1000;
						Hacking_Index = 4;
						if (!Function.Call<bool>(Hash.HAS_SOUND_FINISHED, IPSound))
						{
							Function.Call(Hash.STOP_SOUND, IPSound);
							IPSound = 0;
						}
					}
					if (FeedBackNumber == 87)
					{
						if (Hacking_Lives > 0f)
						{
							Hacking_Lives--;
						}
						if (Hacking_Lives > 0f)
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK_BAD", 0, true);
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD, hackingScalwform, "RESET_ROULETTE");
						}
						if (Hacking_Lives <= 0f)
						{
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_FAILURE", 0, true);
							Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "SET_ROULETTE_OUTCOME", 1f, -1f, -1f, -1f, -1f, "LOSEBRUTE", 0, 0, 0, 0);
							IpTryFailedTimer = Game.GameTime + 1000;
							Hacking_Index = 4;
							if (!Function.Call<bool>(Hash.HAS_SOUND_FINISHED, IPSound))
							{
								Function.Call(Hash.STOP_SOUND, IPSound);
								IPSound = -1;
							}
						}
						FeedBackNumber = -1;
					}
					if (FeedBackNumber == 86)
					{
						Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER_AND_STRING, hackingScalwform, "SET_ROULETTE_OUTCOME", 1f, -1f, -1f, -1f, -1f, "WINBRUTE", 0, 0, 0, 0);
						if (!Function.Call<bool>(Hash.HAS_SOUND_FINISHED, IPSound))
						{
							Function.Call(Hash.STOP_SOUND, IPSound);
							IPSound = -1;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_SUCCESS", 0, true);
						Hacking_Index = 5;
						FeedBackNumber = -1;
					}
					if (FeedBackNumber == 92)
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "HACKING_CLICK", 0, true);
						FeedBackNumber = -1;
					}
					break;
				}
				case 4:
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, hackingScalwform, 255, 255, 255, 255, 0);
					{
						foreach (Control value in Enum.GetValues(typeof(Control)))
						{
							if (Game.IsControlJustPressed(value))
							{
								Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD, hackingScalwform, "CLOSE_APP");
								Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "OPEN_APP", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
								Hacking_Index = 1;
								Hacking_Lives = 3f;
								Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
								break;
							}
						}
						break;
					}
				case 5:
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, hackingScalwform, 255, 255, 255, 255, 0);
					{
						foreach (Control value2 in Enum.GetValues(typeof(Control)))
						{
							if (Game.IsControlJustPressed(value2))
							{
								if (ClickBools[0])
								{
									ClickBools[1] = true;
								}
								else
								{
									ClickBools[0] = true;
								}
								Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD, hackingScalwform, "CLOSE_APP");
								Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "OPEN_APP", 2f, -1082130432, -1082130432, -1082130432, -1082130432);
								Hacking_Index = 1;
								Hacking_Lives = 3f;
								Function.Call(Hash.CALL_SCALEFORM_MOVIE_METHOD_WITH_NUMBER, hackingScalwform, "SET_LIVES", Hacking_Lives, -1082130432, -1082130432, -1082130432, -1082130432);
								break;
							}
						}
						break;
					}
				case 6:
				{
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
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					HudHandler.HudandRadar(Hud: true, Radar: true);
					Game.Player.CanControlCharacter = true;
					Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, -1, "unlocked_bleep", Game.Player.Character, "HACKING_DOOR_UNLOCK_SOUNDS", false, 0);
					Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
					Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, "anim@heists@keypad@", "exit", 8f, -8f, -1, 17825802, 0f, false, false, false);
					Script.Wait(1500);
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_MPHEIST/HEIST_USE_KEYPAD");
					UnloadLoadehacker();
					Function.Call(Hash.STOP_AUDIO_SCENE, "DLC_HEIST_PACIFIC_BANK_HACK_PASSWORD_SCENE");
					Game.Player.Character.Task.ClearAll();
					Script.Wait(1000);
					Game.Player.CanControlCharacter = true;
					HudHandler.HudandRadar(Hud: true, Radar: true);
					THIS_PLAYER_NOTIF(null, " hacked the keypad.");
					allProps = World.GetAllProps(-2125423493, -1859471240);
					Prop[] array12 = allProps;
					foreach (Prop prop3 in array12)
					{
						if (prop3 != null)
						{
							prop3.IsPositionFrozen = false;
						}
					}
					if (MissionVehs[0] != null && MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
					}
					if (MissionVehs[1] != null && MissionVehs[1].AttachedBlip != null)
					{
						MissionVehs[1].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
					}
					Game.Player.Character.IsInvincible = false;
					CruelMastersOnlineOffline.NoCopsOnMission = false;
					Hacking_Index = 0;
					MissionSwitch = 4;
					break;
				}
				}
				break;
			}
			case 4:
			{
				int num43 = 0;
				int num44 = 0;
				if (MissionVehs[0] != null && MissionVehs[0].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					num44 = 0;
				}
				if (MissionVehs[1] != null && MissionVehs[1].AttachedBlip != null && Game.Player.Character.CurrentVehicle == MissionVehs[1])
				{
					num44 = 1;
				}
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (MissionVehs[num44] != null)
					{
						if (Game.Player.Character.CurrentVehicle == MissionVehs[num44])
						{
							if (MissionVehs[num44].AttachedBlip != null && MissionVehs[num44].AttachedBlip.Alpha > 0)
							{
								Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected a car.", blinking: true);
								MissionVehs[num44].AttachedBlip.Alpha = 0;
							}
							GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~car~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
							if (CruelMastersOnlineOffline.missionBlip == null)
							{
								if (CruelMastersOnlineOffline.missionBlip != null)
								{
									CruelMastersOnlineOffline.missionBlip.Delete();
									CruelMastersOnlineOffline.missionBlip = null;
								}
								while (CruelMastersOnlineOffline.missionBlip == null)
								{
									CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
									Script.Wait(0);
								}
								HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							}
							else
							{
								if (MissionVehs[num44].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
								{
									Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
									World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 1f), Color.Yellow);
								}
								if (MissionVehs[num44].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f && MissionVehs[num44].AttachedBlip != null)
								{
									Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ delivered a car.", blinking: true);
									MissionVehs[num44].AttachedBlip.Delete();
									MissionVehs[num44].IsDriveable = false;
									MissionVehs[num44].LockStatus = VehicleLockStatus.CannotEnter;
									if (CruelMastersOnlineOffline.missionBlip != null)
									{
										CruelMastersOnlineOffline.missionBlip.Delete();
										CruelMastersOnlineOffline.missionBlip = null;
										HudHandler.CLEAR_GPS_ROUTE();
									}
									Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
									Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[num44], 4f, 1, 1);
									Script.Wait(2000);
									Game.Player.Character.Task.LeaveVehicle();
								}
							}
						}
						else
						{
							GTA.UI.Screen.ShowSubtitle("Repo the ~HUD_COLOUR_BLUEDARK~cars.~HUD_COLOUR_WHITE~");
							if (MissionVehs[num44].AttachedBlip != null)
							{
								MissionVehs[num44].AttachedBlip.Alpha = 255;
							}
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
						}
					}
				}
				else
				{
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
					if (MissionVehs[num44] != null)
					{
						if (Game.Player.Character.CurrentVehicle == MissionVehs[num44])
						{
							GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
							if (MissionVehs[num44].AttachedBlip != null)
							{
								MissionVehs[num44].AttachedBlip.Alpha = 0;
							}
						}
						else
						{
							GTA.UI.Screen.ShowSubtitle("Repo the ~HUD_COLOUR_BLUEDARK~cars.~HUD_COLOUR_WHITE~");
							if (MissionVehs[num44].AttachedBlip != null)
							{
								MissionVehs[num44].AttachedBlip.Alpha = 255;
							}
						}
					}
				}
				for (int i = 0; i < 3; i++)
				{
					if (MissionVehs[i] != null && MissionVehs[i].Position.DistanceTo(new Vector3(-11.24234f, -1080.94f, 26.67616f)) < 5f)
					{
						num43++;
					}
				}
				if (num43 >= 2)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Audios.Stop_Music_Event();
					Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
					Script.Wait(2000);
					MissionSwitch = 5;
				}
				break;
			}
			case 5:
			{
				int num35 = 7300;
				string cutscene3 = "mp_int_mcs_12_a3";
				string text3 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num35 = 7300;
					cutscene3 = "mp_intro_mcs_12_a3";
					text3 = "MP_1";
					break;
				case 1:
					num35 = 12000;
					cutscene3 = "mp_int_mcs_12_a3_3";
					text3 = "MP_1";
					break;
				case 2:
					num35 = 12600;
					cutscene3 = "mp_int_mcs_12_a3_4";
					text3 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num35 = 17400;
						cutscene3 = "mp_intro_mcs_12_a1";
						text3 = "MP_Male_Character";
					}
					else
					{
						num35 = 19800;
						cutscene3 = "mp_intro_mcs_12_a2";
						text3 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num36 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped7 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num36, 0);
				Ped ped8 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num36, 1);
				Ped ped9 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num36, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene3);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene3);
					Script.Yield();
				}
				num36 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped7 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num36, 0);
				ped8 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num36, 1);
				ped9 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num36, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped7);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped8);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped9);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text3, 0, 0, 64);
				if (ped7.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped7, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped8.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped8, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped9.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped9, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped7);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped8);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped9);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num35)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num37 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 14300, 18001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num37, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num37, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num37, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num38 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 2001, 2891);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num38, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num38, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num38, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num39 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num40 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num39))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num40 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num39);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num40}");
				}
				int num41 = Game.GameTime + num40;
				while (Game.GameTime < num41)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num42 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num42)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 24.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num37);
				MPRank.ADD_RP(num38);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 11:
			if (CruelMastersOnlineOffline.checkpoint == 1 || CruelMastersOnlineOffline.DEBUG)
			{
				if (TeamLives > 0)
				{
					Heist_Hud.drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				else
				{
					Heist_Hud.drawSprite2("timerbars", "all_red_bg", 0.88f, 0.906f, 0.2f, 0.04f, 255, 255, 255, 130);
					Heist_Hud.drawText3("TEAM LIVES", 0.78f, 0.89f, 0.4f, 255, 255, 255, 2, 0.77f, 0.88f);
					Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
					Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, $"{TeamLives}");
					Function.Call(Hash.SET_TEXT_COLOUR, 255, 0, 0, 255);
					Function.Call(Hash.SET_TEXT_SCALE, 0f, 0.56f);
					Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
					Function.Call(Hash.SET_TEXT_WRAP, 0.88f, 0.975f);
					Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.87f, 0.885f, 0.1f);
				}
				if (MissionVehs[0] != null && MissionVehs[0].IsDead)
				{
					while (Wall_Creator.FailCam == null)
					{
						Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
						Script.Wait(0);
					}
					Random random = new Random();
					int num14 = random.Next(1, 3);
					if (num14 == 1)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					if (num14 == 2)
					{
						Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
						Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
						Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
					}
					World.RenderingCamera = Wall_Creator.FailCam;
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(1500);
					GTA.UI.Screen.FadeIn(500);
					while (!GTA.UI.Screen.IsFadedIn)
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
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Cabrio Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Cabrio Was Destroyed", true, true, true);
					Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_FAILED", "MISSION", "FAILED", "The Cabrio Was Destroyed", true, true, true);
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
					int num15 = Game.GameTime + 6000;
					while (Game.GameTime < num15)
					{
						Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
						Script.Wait(0);
					}
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Wall_Creator.DeleteMissionPassScaleform();
					GTA.UI.Screen.FadeOut(1000);
					Script.Wait(1000);
					if (Wall_Creator.FailCam != null)
					{
						Wall_Creator.FailCam.Delete();
						Wall_Creator.FailCam = null;
					}
					World.RenderingCamera = null;
					if (CruelMastersOnlineOffline.missionBlip != null)
					{
						CruelMastersOnlineOffline.missionBlip.Delete();
						CruelMastersOnlineOffline.missionBlip = null;
						HudHandler.CLEAR_GPS_ROUTE();
					}
					Groups.RemoveEnemyPeds();
					Groups.ClearEnemyPedsList2();
					Vehicles.RemoveVehicles();
					Props.RemoveProps();
					CLEANUP_MISSION_BLIPS();
					CLEANUP_MISSION_PICKUPS();
					CLEANUP_MISSION_PROPS();
					CLEANUP_MISSION_VEHICLE();
					Game.Player.IsInvincible = false;
					MissionSwitch = 0;
					break;
				}
				if (Game.Player.Character.IsDead)
				{
					TeamLives--;
					while (Game.Player.Character.IsDead)
					{
						Script.Wait(0);
					}
					if (TeamLives < 0)
					{
						while (Wall_Creator.FailCam == null)
						{
							Wall_Creator.FailCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", 0);
							Script.Wait(0);
						}
						Random random2 = new Random();
						int num16 = random2.Next(1, 3);
						if (num16 == 1)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 2f, 3f, 0.6f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						if (num16 == 2)
						{
							Function.Call(Hash.ATTACH_CAM_TO_ENTITY, Wall_Creator.FailCam, Game.Player.Character, 1f, 3f, 0.5f, true);
							Function.Call(Hash.POINT_CAM_AT_ENTITY, Wall_Creator.FailCam, Game.Player.Character, -0.2f, 0f, 0.6f, true);
							Function.Call(Hash.SET_CAM_FOV, Wall_Creator.FailCam, 10f);
						}
						World.RenderingCamera = Wall_Creator.FailCam;
						HudHandler.HudandRadar(Hud: false, Radar: false);
						Script.Wait(1500);
						GTA.UI.Screen.FadeIn(500);
						while (!GTA.UI.Screen.IsFadedIn)
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
						int num17 = Game.GameTime + 6000;
						while (Game.GameTime < num17)
						{
							Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
							Script.Wait(0);
						}
						Function.Call(Hash.STOP_AUDIO_SCENES);
						Wall_Creator.DeleteMissionPassScaleform();
						GTA.UI.Screen.FadeOut(1000);
						Script.Wait(1000);
						if (Wall_Creator.FailCam != null)
						{
							Wall_Creator.FailCam.Delete();
							Wall_Creator.FailCam = null;
						}
						World.RenderingCamera = null;
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
						Groups.RemoveEnemyPeds();
						Groups.ClearEnemyPedsList2();
						Vehicles.RemoveVehicles();
						Props.RemoveProps();
						CLEANUP_MISSION_BLIPS();
						CLEANUP_MISSION_PICKUPS();
						CLEANUP_MISSION_PROPS();
						CLEANUP_MISSION_VEHICLE();
						Game.Player.IsInvincible = false;
						MissionSwitch = 0;
						break;
					}
				}
			}
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-17.24715f, -1099.193f, 26.67207f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-47.30293f, -1129.574f, 25.72269f), 91.00664f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-17.24715f, -1099.193f, 25.67207f);
				Game.Player.Character.Heading = 161.8473f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Rockford Roll", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Rockford Roll", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Rockford Roll", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num27 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num28 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num27))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num28 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num27);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num28}");
				}
				int num29 = Game.GameTime + num28;
				while (Game.GameTime < num29)
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Wall_Creator.DeleteMissionPassScaleform();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				CruelMastersOnlineOffline.checkpoint = 1;
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array5 = new Vector3[2]
				{
					new Vector3(-536.3847f, -445.5694f, 34.30395f),
					new Vector3(-593.8591f, -446.5593f, 34.32557f)
				};
				float[] array6 = new float[2] { 96.2022f, 268.5766f };
				int num26 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array5.Length);
				RESPAWN.SET_MIS_STAT(array5[num26], array6[num26], 0, misretaskbool: true);
				Vehicles.RemoveVehicles();
				Vehicles.SPAWN_VEHICLE(VehicleHash.Stretch, new Vector3(-574.4373f, -447.1775f, 32.83217f), 89.6736f, sirenactive: false, IsInvincible: false);
				Vehicles.SPAWN_VEHICLE(VehicleHash.Taxi, new Vector3(-589.9981f, -449.3405f, 32.80883f), 89.46674f, sirenactive: false, IsInvincible: false);
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Ninef2, new Vector3(-563.0855f, -446.6858f, 32.74552f), 91.26349f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.MetallicSilver;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.MetallicBlack;
				MissionVehs[0].CanTiresBurst = false;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Cabrio";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				CruelMastersOnlineOffline.NoCopsOnMission = false;
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Retrieve the ~HUD_COLOUR_BLUEDARK~Cabrio.~HUD_COLOUR_WHITE~");
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Groups.pedList.Count > 0)
				{
					foreach (Ped ped41 in Groups.pedList)
					{
						if (ped41.IsInCombatAgainst(Game.Player.Character) && !Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
						{
							Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
						}
					}
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected the Cabrio.", blinking: true);
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
					Game.Player.WantedLevel = 1;
					MissionSwitch = 3;
				}
				break;
			case 3:
			{
				Vector3[] array7 = new Vector3[2]
				{
					MissionVehs[0].Position.Around(5f),
					MissionVehs[0].Position.Around(2f)
				};
				float[] array8 = new float[2];
				int num30 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array7.Length);
				RESPAWN.SET_MIS_STAT(array7[num30], array8[num30], 2, misretaskbool: true);
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (!(MissionVehs[0] != null))
					{
						break;
					}
					if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
					{
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 0;
						}
						GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~Cabrio~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
						if (CruelMastersOnlineOffline.missionBlip == null)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
							}
							while (CruelMastersOnlineOffline.missionBlip == null)
							{
								CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
								Script.Wait(0);
							}
							HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							break;
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
						{
							Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
							World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.3f, 0.3f, 1f), Color.Yellow);
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
							Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[0], 4f, 1, 1);
							Script.Wait(2000);
							Game.Player.Character.Task.LeaveVehicle();
							HudHandler.HudandRadar(Hud: false, Radar: false);
							Audios.Stop_Music_Event();
							Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
							Script.Wait(2000);
							MissionSwitch = 4;
						}
					}
					else
					{
						GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Cabrio.~HUD_COLOUR_WHITE~");
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 255;
						}
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
					}
					break;
				}
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
					HudHandler.CLEAR_GPS_ROUTE();
				}
				if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
				{
					Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
				}
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 0;
					}
				}
				else
				{
					GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Cabrio.~HUD_COLOUR_WHITE~");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 255;
					}
				}
				break;
			}
			case 4:
			{
				int num18 = 7300;
				string cutscene2 = "mp_int_mcs_12_a3";
				string text2 = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num18 = 7300;
					cutscene2 = "mp_intro_mcs_12_a3";
					text2 = "MP_1";
					break;
				case 1:
					num18 = 12000;
					cutscene2 = "mp_int_mcs_12_a3_3";
					text2 = "MP_1";
					break;
				case 2:
					num18 = 12600;
					cutscene2 = "mp_int_mcs_12_a3_4";
					text2 = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num18 = 17400;
						cutscene2 = "mp_intro_mcs_12_a1";
						text2 = "MP_Male_Character";
					}
					else
					{
						num18 = 19800;
						cutscene2 = "mp_intro_mcs_12_a2";
						text2 = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num19 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped4 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 0);
				Ped ped5 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 1);
				Ped ped6 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene2);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene2);
					Script.Yield();
				}
				num19 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped4 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 0);
				ped5 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 1);
				ped6 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num19, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped4);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped5);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped6);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text2, 0, 0, 64);
				if (ped4.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped4, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped5.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped5, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped6.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped6, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped4);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped5);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped6);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num18)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num20 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 9300, 14001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num20, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num20, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num20, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num21 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1700, 2191);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num21, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num21, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num21, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num22 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num23 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num22))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num23 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num22);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num23}");
				}
				int num24 = Game.GameTime + num23;
				while (Game.GameTime < num24)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num25 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num25)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num20);
				MPRank.ADD_RP(num21);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		case 12:
			switch (MissionSwitch)
			{
			case 0:
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-70.69586f, -1100.849f, 26.25354f, 0f, 0f, 0f, 500f, 0);
				}
				Audios.TRIGGER_MUSIC_EVENT(RETURN_CONTACT_MUSIC_EVENTS()[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, RETURN_CONTACT_MUSIC_EVENTS().Length)]);
				Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
				Audios.TRIGGER_MUSIC_EVENT("FH2B_EXPLODE");
				MPLoadout.GET_CURRENT_LOADOUT();
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.13068f, -1101.374f, 25.82268f), 161.9887f);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				Game.Player.Character.Task.ClearAll();
				Game.Player.CanControlCharacter = true;
				Game.Player.Character.Position = new Vector3(-70.69586f, -1100.849f, 25.25354f);
				Game.Player.Character.Heading = 111.8636f;
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
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_INTRO_TO_WALL", "intro", "Mission", "Where Credit's Due", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_INTRO_TO_WALL", "intro", "Mission", "Where Credit's Due", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_INTRO_TO_WALL", "intro", "Mission", "Where Credit's Due", "", "", "", "", 0, 0, true, "HUD_COLOUR_WHITE");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "intro", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "intro", 75, 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "intro");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "intro");
				GTA.UI.Screen.FadeIn(1000);
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
				TeamLives = 1;
				MissionSwitch = 1;
				break;
			}
			case 1:
			{
				Vector3[] array = new Vector3[2]
				{
					new Vector3(411.3926f, -2080.822f, 20.97665f),
					new Vector3(407.1709f, -2060.001f, 21.79747f)
				};
				float[] array2 = new float[2] { 21.63816f, 223.4489f };
				int num9 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array.Length);
				RESPAWN.SET_MIS_STAT(array[num9], array2[num9], 0, misretaskbool: true);
				Vehicles.RemoveVehicles();
				Vehicles.SPAWN_VEHICLE(VehicleHash.Virgo3, new Vector3(414.7038f, -2068.182f, 19.93781f), 140.6903f, sirenactive: false, IsInvincible: false);
				CLEANUP_MISSION_VEHICLE();
				while (MissionVehs[0] == null)
				{
					MissionVehs[0] = World.CreateVehicle(VehicleHash.Zion, new Vector3(409.9106f, -2064.311f, 19.82077f), -40.17416f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, MissionVehs[0], 100f);
				MissionVehs[0].Mods.InstallModKit();
				MissionVehs[0].Mods.PrimaryColor = VehicleColor.HotPink;
				MissionVehs[0].Mods.SecondaryColor = VehicleColor.HotPink;
				MissionVehs[0].CanTiresBurst = false;
				while (MissionVehs[0].AttachedBlip == null)
				{
					MissionVehs[0].AddBlip();
					Script.Wait(0);
				}
				if (MissionVehs[0].AttachedBlip != null)
				{
					MissionVehs[0].AttachedBlip.Sprite = BlipSprite.Standard;
					MissionVehs[0].AttachedBlip.Color = BlipColor.BlueDark;
					MissionVehs[0].AttachedBlip.Name = "Zion";
					MissionVehs[0].AttachedBlip.IsShortRange = false;
					MissionVehs[0].AttachedBlip.DisplayType = BlipDisplayType.BothMapSelectable;
				}
				CruelMastersOnlineOffline.NoCopsOnMission = false;
				MissionSwitch = 2;
				break;
			}
			case 2:
				GTA.UI.Screen.ShowSubtitle("Repo the ~HUD_COLOUR_BLUEDARK~Zion.~HUD_COLOUR_WHITE~");
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Groups.pedList.Count > 0)
				{
					foreach (Ped ped42 in Groups.pedList)
					{
						if (ped42.IsInCombatAgainst(Game.Player.Character) && !Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_ACTION_HFIN"))
						{
							Audios.TRIGGER_MUSIC_EVENT("MP_MC_ACTION_HFIN");
						}
					}
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					Notification.Show("~b~" + CruelMastersOnlineOffline.Player_Name + "~w~ collected the Zion.", blinking: true);
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
					}
					Game.Player.WantedLevel = 1;
					MissionSwitch = 3;
				}
				break;
			case 3:
			{
				Vector3[] array3 = new Vector3[2]
				{
					MissionVehs[0].Position.Around(5f),
					MissionVehs[0].Position.Around(2f)
				};
				float[] array4 = new float[2];
				int num13 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array3.Length);
				RESPAWN.SET_MIS_STAT(array3[num13], array4[num13], 2, misretaskbool: true);
				if (Game.Player.WantedLevel == 0)
				{
					if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_SUSPENSE_HFIN"))
					{
						Audios.TRIGGER_MUSIC_EVENT("MP_MC_SUSPENSE_HFIN");
					}
					if (!(MissionVehs[0] != null))
					{
						break;
					}
					if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
					{
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 0;
						}
						GTA.UI.Screen.ShowSubtitle("Deliver the ~HUD_COLOUR_BLUEDARK~Zion~HUD_COLOUR_WHITE~ to the ~y~dealership.~w~");
						if (CruelMastersOnlineOffline.missionBlip == null)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
							}
							while (CruelMastersOnlineOffline.missionBlip == null)
							{
								CruelMastersOnlineOffline.missionBlip = World.CreateBlip(new Vector3(-11.24234f, -1080.94f, 26.67616f));
								Script.Wait(0);
							}
							HudHandler.SET_GPS(CruelMastersOnlineOffline.missionBlip, 156, displayonfoot: false, followplayer: true);
							break;
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 100f)
						{
							Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z, 5f, false, false, false, false, false, false);
							World.DrawMarker(MarkerType.Cylinder, new Vector3(CruelMastersOnlineOffline.missionBlip.Position.X, CruelMastersOnlineOffline.missionBlip.Position.Y, CruelMastersOnlineOffline.missionBlip.Position.Z - 1.2f), Vector3.Zero, Vector3.Zero, new Vector3(0.3f, 0.3f, 1f), Color.Yellow);
						}
						if (MissionVehs[0].Position.DistanceTo(CruelMastersOnlineOffline.missionBlip.Position) < 5f)
						{
							if (CruelMastersOnlineOffline.missionBlip != null)
							{
								CruelMastersOnlineOffline.missionBlip.Delete();
								CruelMastersOnlineOffline.missionBlip = null;
								HudHandler.CLEAR_GPS_ROUTE();
							}
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET", 1);
							Function.Call(Hash.BRING_VEHICLE_TO_HALT, MissionVehs[0], 4f, 1, 1);
							Script.Wait(2000);
							Game.Player.Character.Task.LeaveVehicle();
							HudHandler.HudandRadar(Hud: false, Radar: false);
							Audios.Stop_Music_Event();
							Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
							Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
							Script.Wait(2000);
							MissionSwitch = 4;
						}
					}
					else
					{
						GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Zion.~HUD_COLOUR_WHITE~");
						if (MissionVehs[0].AttachedBlip != null)
						{
							MissionVehs[0].AttachedBlip.Alpha = 255;
						}
						if (CruelMastersOnlineOffline.missionBlip != null)
						{
							CruelMastersOnlineOffline.missionBlip.Delete();
							CruelMastersOnlineOffline.missionBlip = null;
							HudHandler.CLEAR_GPS_ROUTE();
						}
					}
					break;
				}
				if (CruelMastersOnlineOffline.missionBlip != null)
				{
					CruelMastersOnlineOffline.missionBlip.Delete();
					CruelMastersOnlineOffline.missionBlip = null;
					HudHandler.CLEAR_GPS_ROUTE();
				}
				if (!Audios.TRIGGER_MUSIC_EVENT_BOOL("MP_MC_VEHICLE_CHASE_HFIN"))
				{
					Audios.TRIGGER_MUSIC_EVENT("MP_MC_VEHICLE_CHASE_HFIN");
				}
				if (!(MissionVehs[0] != null))
				{
					break;
				}
				if (Game.Player.Character.CurrentVehicle == MissionVehs[0])
				{
					GTA.UI.Screen.ShowSubtitle("Lose the Cops.");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 0;
					}
				}
				else
				{
					GTA.UI.Screen.ShowSubtitle("Get in the ~HUD_COLOUR_BLUEDARK~Zion.~HUD_COLOUR_WHITE~");
					if (MissionVehs[0].AttachedBlip != null)
					{
						MissionVehs[0].AttachedBlip.Alpha = 255;
					}
				}
				break;
			}
			case 4:
			{
				int num = 7300;
				string cutscene = "mp_int_mcs_12_a3";
				string text = "MP_1";
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4))
				{
				case 0:
					num = 7300;
					cutscene = "mp_intro_mcs_12_a3";
					text = "MP_1";
					break;
				case 1:
					num = 12000;
					cutscene = "mp_int_mcs_12_a3_3";
					text = "MP_1";
					break;
				case 2:
					num = 12600;
					cutscene = "mp_int_mcs_12_a3_4";
					text = "MP_1";
					break;
				case 3:
					if (Game.Player.Character.Gender == Gender.Male)
					{
						num = 17400;
						cutscene = "mp_intro_mcs_12_a1";
						text = "MP_Male_Character";
					}
					else
					{
						num = 19800;
						cutscene = "mp_intro_mcs_12_a2";
						text = "MP_Female_Character";
					}
					break;
				}
				while (CruelMastersOnlineOffline.CutsceneExtra1 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra1 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra1.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra2 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra2 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra2.IsVisible = false;
				while (CruelMastersOnlineOffline.CutsceneExtra3 == null)
				{
					CruelMastersOnlineOffline.CutsceneExtra3 = World.CreatePed(PedHash.FreemodeMale01, new Vector3(715.8922f, -981.1568f, 24.12039f));
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.CutsceneExtra3.IsVisible = false;
				int num2 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				Ped ped = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num2, 0);
				Ped ped2 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num2, 1);
				Ped ped3 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num2, 2);
				CruelMastersOnlineOffline.PlayerModelSet(Game.Player.Character);
				LoadingPrompt.Show("Starting Cutscene");
				CruelMastersOnlineOffline.LoadCutscene(cutscene);
				while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
				{
					CruelMastersOnlineOffline.LoadCutscene(cutscene);
					Script.Yield();
				}
				num2 = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
				ped = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num2, 0);
				ped2 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num2, 1);
				ped3 = Function.Call<Ped>(Hash.GET_PED_AS_GROUP_MEMBER, num2, 2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP2("MP_2", ped);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP3("MP_3", ped2);
				CruelMastersOnlineOffline.SetPedOutfitCutscene_MP4("MP_4", ped3);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, text, 0, 0, 64);
				if (ped.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped, "MP_2", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra1, "MP_2", 0, 0, 64);
				}
				if (ped2.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped2, "MP_3", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra2, "MP_3", 0, 0, 64);
				}
				if (ped3.Exists())
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, ped3, "MP_4", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CruelMastersOnlineOffline.CutsceneExtra3, "MP_4", 0, 0, 64);
				}
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				CruelMastersOnlineOffline.PlayerModelSetBack(Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene("MP_1", Game.Player.Character);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP2("MP_2", ped);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP3("MP_3", ped2);
				CruelMastersOnlineOffline.GetPedOutfitCutscene_MP4("MP_4", ped3);
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER_WITHOUT_MODEL();
				LoadingPrompt.Hide();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.REMOVE_CUTSCENE);
				while (Cutscenes.GET_CUTSCENE_TIME() < num)
				{
					Script.Wait(0);
				}
				Screen_Effects.CLEAR_ALL_HELP_MESSAGES();
				Screen_Effects.PlayAnimPostFX("HeistCelebEnd", 0, looped: true);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_FINALE_SCREEN_SOUNDS", true);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
				Script.Wait(1000);
				Wall_Creator.DeleteMissionPassScaleform();
				Script.Wait(500);
				Wall_Creator.DeleteMissionPassScaleform();
				Wall_Creator.RequestMissionPassScaleform();
				Script.Wait(500);
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.PlayAnimPostFX("HeistCelebPass", 0, looped: true);
				Function.Call(Hash.START_AUDIO_SCENE, "CREATOR_SCENES_AMBIENCE");
				Function.Call(Hash.START_AUDIO_SCENE, "MP_LEADERBOARD_SCENE");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CLEANUP", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "CREATE_STAT_WALL", "CELEB_MISSION", "HUD_COLOUR_BLACK");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_MISSION_RESULT_TO_WALL", "CELEB_MISSION", "MISSION", "PASSED", "", true, true, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_JOB_POINTS_TO_WALL", "CELEB_MISSION", 15, true);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num3 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 10001, 15001);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_CASH_TO_WALL", "CELEB_MISSION", num3, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_CASH_TO_WALL", "CELEB_MISSION", num3, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_CASH_TO_WALL", "CELEB_MISSION", num3, false);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				int num4 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1800, 2291);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num4, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num4, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", "CELEB_MISSION", num4, MPRank.CurrentXP, MPRank.XPStartLimit, MPRank.XPEndLimit, MPRank.PlayerLevel, MPRank.PlayerLevel + 1, "Rank", "UP");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "PAUSE", "CELEB_MISSION", 1);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "ADD_BACKGROUND_TO_WALL", "CELEB_MISSION", 75, 0);
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED2, "SHOW_STAT_WALL", "CELEB_MISSION");
				Wall_Creator.CallFunction(Wall_Creator.MISSIONPASSED3, "SHOW_STAT_WALL", "CELEB_MISSION");
				Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Wall_Creator.MISSIONPASSED, "GET_TOTAL_WALL_DURATION");
				int num5 = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
				int num6 = 0;
				while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num5))
				{
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				num6 = GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT(num5);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show($"{num6}");
				}
				int num7 = Game.GameTime + num6;
				while (Game.GameTime < num7)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Wall_Creator.MissionCelebrate(Wall_Creator.MISSIONPASSED, Wall_Creator.MISSIONPASSED2, Wall_Creator.MISSIONPASSED3);
					Script.Wait(0);
				}
				Screen_Effects.StopAllAnimPostFX();
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				Wall_Creator.DeleteMissionPassScaleform();
				Game.Player.CanControlCharacter = true;
				Groups.RemoveEnemyPeds();
				Groups.ClearEnemyPedsList2();
				Vehicles.RemoveVehicles();
				Props.RemoveProps();
				CLEANUP_MISSION_BLIPS();
				CLEANUP_MISSION_PICKUPS();
				CLEANUP_MISSION_PROPS();
				CLEANUP_MISSION_VEHICLE();
				int num8 = Game.GameTime + 4000;
				Game.Player.CanControlCharacter = false;
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				while (Game.GameTime < num8)
				{
					Script.Wait(0);
				}
				MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-75.16011f, -1101.33f, 26.1002f), 161.8743f);
				CruelMastersOnlineOffline.MissionEndReturn(new Vector3(-33.94191f, -1111.962f, 25.42235f), 319.3282f);
				Game.Player.Character.IsPositionFrozen = true;
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
				MPCash.ADD_CASH(num3);
				MPRank.ADD_RP(num4);
				Game.Player.Character.IsPositionFrozen = false;
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
			break;
		}
	}

	public static string[] RETURN_CONTACT_MUSIC_EVENTS()
	{
		return new string[93]
		{
			"MP_MC_CMH_IAA_PREP_START", "MP_MC_CMH_IAA_FINALE_START", "MP_MC_CMH_SUB_PREP_START", "MP_MC_CMH_SUB_FINALE_START", "MP_MC_CMH_SILO_PREP_START", "MP_MC_CMH_SILO_FINALE_START", "MP_MC_CM22_START_TRACK_11", "MP_MC_TUNER_START_MUSIC", "MP_MC_GR_START", "LOWRIDER_START_MUSIC",
			"LOWRIDER_FINALE_START_MUSIC", "MP_MC_START", "BTL_EXEC1_ADV_START", "MP_MC_ASSAULT_ADV_START", "MP_MC_START_CITY", "MP_MC_START_COUNTRY", "MP_MC_START_CAR_STEAL_CHIPS_2", "MP_MC_START_EYE_IN_SKY_3", "MP_MC_START_FUNK_JAM_3", "MP_MC_START_FUNK_JAM_TWO_4",
			"MP_MC_START_BEYOND_4", "MP_MC_START_BURNING_BAR_8", "MP_MC_START_PB1_8", "MP_MC_START_DARK_ROBBERY_8", "MP_MC_START_DIAMOND_DIARY_8", "MP_MC_START_DEBUNKED_8", "MP_MC_START_PB2_PUSSYFACE_8", "MP_MC_START_DR_DESTRUCTO_8", "MP_MC_START_DRAGONER_8", "MP_MC_START_GREYHOUND_8",
			"MP_MC_START_MEATY_8", "MP_MC_START_MISSION_SEVEN_8", "MP_MC_START_NINE_BLURT_8", "MP_MC_START_SCRAP_YARD_8", "MP_MC_START_SILVER_PUSSY_8", "MP_MC_START_VODKA_8", "MP_MC_START_STREETS_OF_FORTUNE_8", "MP_MC_START_TRACK_EIGHT_8", "MP_MC_START_VACUUM_8", "MP_MC_START_VINEGAR_TITS_8",
			"MP_MC_START_CITY_8", "MP_MC_START_GUN_NOVEL_8", "MP_MC_START_CHOP_8", "MP_MC_START_NT_ELC_8", "MP_MC_START_NT_TKB_4", "MP_MC_START_HEIST_4", "MP_MC_START_HEIST_8", "MP_MC_START_HEIST_FIN_NEW", "MP_MC_START_HEIST_PREP_NEW", "START_RANDOM",
			"START_URBAN", "START_ROCK", "START_ELECTRONIC", "HALLOWEEN_START_MUSIC", "EXEC1_MP_MC_START_CITY", "EXEC1_START_BESPOKE_BROKE", "EXEC1_START_CAR_STEAL", "EXEC1_START_CLIFF12", "EXEC1_START_CLIFF18", "EXEC1_MP_MC_START_CITY_STA",
			"EXEC1_START_CLIFF19", "EXEC1_START_CLIFF33", "EXEC1_START_GET_ON_THE_MOVE", "EXEC1_START_PSYCHOPATH", "EXEC1_START_RED_SQUARE", "EXEC1_START_WHO_CALLED_POPO", "BKR_GS_START", "BKR_DEADLINE_START_MUSIC", "BA_METZ_DEBUNKED", "BIKER_LAD_START",
			"IE_TW_START", "IE_SVM_START", "MP_MC_SMG_START", "MP_MC_SMGH_START", "MP_MC_CMH_START", "CMH_ADV_START", "MP_MC_CASINO_BRAWL_START", "MP_CHF_START", "MP_MC_SUM20_START", "HEI4_FIN_START_STA",
			"MP_MC_FIXER_HOLDOUT_START", "MP_MC_FIXER_START_MUSIC", "DATA_LEAK_GOLF_START_MUSIC", "DATA_LEAK_PARTY_PROMO_START_MUSIC", "DATA_LEAK_BILLIONAIRE_START_MUSIC", "DATA_LEAK_HOOD_PASS_START_MUSIC", "DATA_LEAK_FIRE_START_MUSIC", "DATA_LEAK_DFWD_START_MUSIC", "MP_MC_MPSUM2_START_MUSIC", "MP_MC_H22_ADV_START",
			"MP_MC_CM22_START_MUSIC", "MP_MC_CM22_TRIP_START_MUSIC", "CM22_REHAB_TRIP_START"
		};
	}

	public static string[] RETURN_CONTACT_MUSIC_START_EVENTS()
	{
		return new string[165]
		{
			"MP_MC_ACTION_2", "MP_MC_AIRBORNE_2", "MP_MC_SUSPENSE_2", "MP_MC_VEHICLE_CHASE_2", "FH2B_EXPLODE", "MP_MC_ACTION_3", "MP_MC_AIRBORNE_3", "MP_MC_SUSPENSE_3", "MP_MC_VEHICLE_CHASE_3", "MP_MC_ACTION_4",
			"MP_MC_AIRBORNE_4", "MP_MC_SUSPENSE_4", "MP_MC_ACTION_HFIN", "MP_MC_AIRBORNE_HFIN", "MP_MC_SUSPENSE_HFIN", "MP_MC_VEHICLE_CHASE_HFIN", "MP_MC_ACTION_HPREP", "MP_MC_AIRBORNE_HPREP", "MP_MC_SUSPENSE_HPREP", "MP_MC_VEHICLE_CHASE_HPREP",
			"MP_MC_IMP_EXP_ACTION", "MP_MC_IMP_EXP_AIRBORNE", "MP_MC_IMP_EXP_SUSPENSE", "MP_MC_IMP_EXP_VEHICLE_CHASE", "MP_MC_GR_ACTION", "MP_MC_GR_AIRBORNE", "MP_MC_GR_SUSPENSE", "MP_MC_GR_VEHICLE_CHASE", "MP_MC_CMH_ACTION", "MP_MC_CMH_AIRBORNE",
			"MP_MC_CMH_SUSPENSE", "MP_MC_CMH_VEHICLE_CHASE", "MP_MC_CMH_ADV_ACTION", "MP_MC_CMH_ADV_AIRBORNE", "MP_MC_CMH_ADV_SUSPENSE", "MP_MC_CMH_ADV_VEHICLE_CHASE", "MP_MC_ASSAULT_ADV_ACTION", "MP_MC_ASSAULT_ADV_AIRBORNE", "MP_MC_ASSAULT_ADV_SUSPENSE", "MP_MC_ASSAULT_ADV_VEHICLE_CHASE",
			"MP_MC_CASINO_BRAWL_ACTION", "MP_MC_CASINO_BRAWL_AIRBORNE", "MP_MC_CASINO_BRAWL_SUSPENSE", "MP_MC_CASINO_BRAWL_VEHICLE_CHASE", "MP_MC_SMG_ACTION", "MP_MC_SMG_AIRBORNE", "MP_MC_SMG_SUSPENSE", "MP_MC_SMG_VEHICLE_CHASE", "MP_CHF_ACTION", "MP_CHF_AIRBORNE",
			"MP_CHF_DRIVING", "MP_CHF_MED_INTENSITY", "MP_CHF_SUSPENSE_LOW", "MP_CHF_SUSPENSE_HIGH", "MP_CHF_VEHICLE_CHASE", "MP_MC_SUM20_ACTION", "MP_MC_SUM20_AIRBORNE", "MP_MC_SUM20_SUSPENSE", "MP_MC_SUM20_VEHICLE_CHASE", "HEI4_FIN_ACTION",
			"HEI4_FIN_AIRBORNE", "HEI4_FIN_DRIVING", "HEI4_FIN_MED_INTENSITY", "HEI4_FIN_SUSPENSE_LOW", "HEI4_FIN_SUSPENSE_HIGH", "HEI4_FIN_VEHICLE_CHASE", "HEI4_FIN_SAFE_ROOM", "HEI4_FIN_SAFE_ROOM_AGRRO", "MP_MC_TUNER_ACTION", "MP_MC_TUNER_AIRBORNE",
			"MP_MC_TUNER_DRIVING", "MP_MC_TUNER_MED_INTENSITY", "MP_MC_TUNER_SUSPENSE", "MP_MC_TUNER_VEHICLE_CHASE_A", "MP_MC_TUNER_VEHICLE_CHASE_B", "MP_MC_FIXER_HOLDOUT_ACTION", "MP_MC_FIXER_HOLDOUT_AIRBORNE", "MP_MC_FIXER_HOLDOUT_SUSPENSE", "MP_MC_FIXER_HOLDOUT_VEHICLE_CHASE", "MP_MC_FIXER_ACTION",
			"MP_MC_FIXER_AIRBORNE", "MP_MC_FIXER_DRIVING", "MP_MC_FIXER_MED_INTENSITY", "MP_MC_FIXER_SUSPENSE", "MP_MC_FIXER_VEHICLE_CHASE_A", "MP_MC_FIXER_VEHICLE_CHASE_B", "DATA_LEAK_GOLF_ACTION", "DATA_LEAK_GOLF_AIRBORNE", "DATA_LEAK_GOLF_DRIVING", "DATA_LEAK_GOLF_MED_INTENSITY",
			"DATA_LEAK_GOLF_SUSPENSE", "DATA_LEAK_GOLF_VEHICLE_CHASE_A", "DATA_LEAK_GOLF_VEHICLE_CHASE_B", "DATA_LEAK_PARTY_PROMO_ACTION", "DATA_LEAK_PARTY_PROMO_AIRBORNE", "DATA_LEAK_PARTY_PROMO_DRIVING", "DATA_LEAK_PARTY_PROMO_MED_INTENSITY", "DATA_LEAK_PARTY_PROMO_SUSPENSE", "DATA_LEAK_PARTY_PROMO_VEHICLE_CHASE_A", "DATA_LEAK_PARTY_PROMO_VEHICLE_CHASE_B",
			"DATA_LEAK_BILLIONAIRE_ACTION", "DATA_LEAK_BILLIONAIRE_AIRBORNE", "DATA_LEAK_BILLIONAIRE_DRIVING", "DATA_LEAK_BILLIONAIRE_MED_INTENSITY", "DATA_LEAK_BILLIONAIRE_SUSPENSE", "DATA_LEAK_BILLIONAIRE_VEHICLE_CHASE_A", "DATA_LEAK_BILLIONAIRE_VEHICLE_CHASE_B", "DATA_LEAK_HOOD_PASS_ACTION", "DATA_LEAK_HOOD_PASS_AIRBORNE", "DATA_LEAK_HOOD_PASS_DRIVING",
			"DATA_LEAK_HOOD_PASS_MED_INTENSITY", "DATA_LEAK_HOOD_PASS_SUSPENSE", "DATA_LEAK_HOOD_PASS_VEHICLE_CHASE_A", "DATA_LEAK_HOOD_PASS_VEHICLE_CHASE_B", "DATA_LEAK_FIRE_ACTION", "DATA_LEAK_FIRE_AIRBORNE", "DATA_LEAK_FIRE_DRIVING", "DATA_LEAK_FIRE_MED_INTENSITY", "DATA_LEAK_FIRE_SUSPENSE", "DATA_LEAK_FIRE_VEHICLE_CHASE_A",
			"DATA_LEAK_FIRE_VEHICLE_CHASE_B", "DATA_LEAK_DFWD_ACTION", "DATA_LEAK_DFWD_AIRBORNE", "DATA_LEAK_DFWD_DRIVING", "DATA_LEAK_DFWD_MED_INTENSITY", "DATA_LEAK_DFWD_SUSPENSE", "DATA_LEAK_DFWD_VEHICLE_CHASE_A", "DATA_LEAK_DFWD_VEHICLE_CHASE_B", "MP_MC_MPSUM2_ACTION", "MP_MC_MPSUM2_AIRBORNE",
			"MP_MC_MPSUM2_DRIVING", "MP_MC_MPSUM2_MED_INTENSITY", "MP_MC_MPSUM2_SUSPENSE", "MP_MC_MPSUM2_VEHICLE_CHASE_A", "MP_MC_MPSUM2_VEHICLE_CHASE_B", "MP_MC_H22_ADV_ACTION", "MP_MC_H22_ADV_AIRBORNE", "MP_MC_H22_ADV_SUSPENSE", "MP_MC_H22_ADV_VEHICLE_CHASE", "MP_MC_CM22_ACTION",
			"MP_MC_CM22_DRIVING", "MP_MC_CM22_AIRBORNE", "MP_MC_CM22_SUSPENSE", "MP_MC_CM22_MED_INTENSITY", "MP_MC_CM22_VEHICLE_CHASE_A", "MP_MC_CM22_VEHICLE_CHASE_B", "MP_MC_CM22_TRIP_ACTION", "MP_MC_CM22_TRIP_DRIVING", "MP_MC_CM22_TRIP_AIRBORNE", "MP_MC_CM22_TRIP_SUSPENSE",
			"MP_MC_CM22_TRIP_MED_INTENSITY", "MP_MC_CM22_TRIP_VEHICLE_CHASE_A", "MP_MC_CM22_TRIP_VEHICLE_CHASE_B", "CM22_REHAB_BREAK", "CM22_REHAB_WAVE_1", "CM22_REHAB_WAVE_2", "CM22_REHAB_WAVE_3", "CM22_REHAB_WAVE_4", "CM22_REHAB_WAVE_5", "CM22_REHAB_WAVE_6",
			"CM22_REHAB_WAVE_7", "MP_MC_ACTION", "MP_MC_AIRBORNE", "MP_MC_SUSPENSE", "MP_MC_VEHICLE_CHASE"
		};
	}

	public static void CLEANUP_MISSION_PROPS()
	{
		for (int i = 0; i < MissionProps.Length; i++)
		{
			if (MissionProps[i] != null)
			{
				if (MissionProps[i].AttachedBlip != null)
				{
					MissionProps[i].AttachedBlip.Delete();
				}
				MissionProps[i].Delete();
				MissionProps[i] = null;
			}
		}
	}

	public static void CLEANUP_MISSION_VEHICLE()
	{
		for (int i = 0; i < MissionVehs.Length; i++)
		{
			if (MissionVehs[i] != null)
			{
				if (MissionVehs[i].AttachedBlip != null)
				{
					MissionVehs[i].AttachedBlip.Delete();
				}
				MissionVehs[i].Delete();
				MissionVehs[i] = null;
			}
		}
	}

	public static void CLEANUP_GROUP_VEHICLES()
	{
		for (int i = 0; i < GroupVehs.Length; i++)
		{
			if (GroupVehs[i] != null)
			{
				if (GroupVehs[i].AttachedBlip != null)
				{
					GroupVehs[i].AttachedBlip.Delete();
				}
				GroupVehs[i].Delete();
				GroupVehs[i] = null;
			}
		}
	}

	public static void CLEANUP_MISSION_BLIPS()
	{
		for (int i = 0; i < MissionBlips.Length; i++)
		{
			if (MissionBlips[i] != null)
			{
				MissionBlips[i].Delete();
				MissionBlips[i] = null;
			}
		}
	}

	public static void CLEANUP_MISSION_PICKUPS()
	{
		for (int i = 0; i < MissionPickups.Length; i++)
		{
			if (MissionPickups[i] != null)
			{
				MissionPickups[i].Delete();
				MissionPickups[i] = null;
			}
		}
	}

	public static void CLEANUP_MISSION_PEDS()
	{
		for (int i = 0; i < MissionPeds.Length; i++)
		{
			if (MissionPeds[i] != null)
			{
				MissionPeds[i].Delete();
				MissionPeds[i] = null;
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (SimeonBlip != null)
		{
			SimeonBlip.Delete();
		}
		if (HackCard != null)
		{
			HackCard.Delete();
		}
		if (BagProp != null)
		{
			BagProp.Delete();
		}
		if (Laptop != null)
		{
			Laptop.Delete();
		}
		Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Game.Player.Character, true, false, true, false);
		CLEANUP_MISSION_PROPS();
		CLEANUP_MISSION_VEHICLE();
		CLEANUP_MISSION_BLIPS();
		CLEANUP_MISSION_PICKUPS();
		CLEANUP_MISSION_PEDS();
	}
}
