using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class KeyPad_Hacking : Script
{
	public static bool AllowKeyPadHack = false;

	public static bool HelpSHOW = false;

	public static bool AllowControl = true;

	public static bool HackOutCome = false;

	public static bool IsUsingActionMode = false;

	public static int ExtraLootSwitch = 0;

	public static int SoundId = 0;

	public static int SoundId2 = 0;

	public static int[] BGSwitch = new int[5];

	public static int[] bgtimer = new int[5];

	public static int[] bgset = new int[5];

	public static int HackSwitch = 0;

	public static int PrintsAllowed = 1;

	public static int fcalpha = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 127, 255);

	public static int[] RandomSpots = new int[9];

	public static Random RNG = new Random(DateTime.Now.Millisecond);

	public static int[] PrintChoice = new int[6];

	public static List<int> SelectedTiles = new List<int>();

	public static int currentlySelectedTile = 0;

	public static int previousUpdate = Game.GameTime;

	public static int iVar6 = 0;

	public static int timer = 0;

	public static int MoveLR = 0;

	public static int MoveUD = 0;

	public static int Lives = 0;

	public static int AbortTimer = 0;

	public static int animchoice = 1;

	public static int Bink = 0;

	public static int numMin = 0;

	public static int numSec = 0;

	public static int numSec2 = 0;

	public static int numMil = 0;

	public static int numMil2 = 0;

	public static int previousUpdate2 = Game.GameTime;

	public static int iVar62 = 31;

	public static Vector3 keycardzoffset = new Vector3(0f, 0f, -70.3772f);

	public static Vector3 keypadzoffset = new Vector3(0f, 0f, 0f);

	public static Prop Phone;

	public static Prop USB;

	public static string doormodel = "";

	public static float disttodoor = 5f;

	public static List<Prop> KeyPadSpawn = new List<Prop>();

	public KeyPad_Hacking()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
		if (!AllowKeyPadHack)
		{
			return;
		}
		foreach (Prop item in KeyPadSpawn.ToList())
		{
			if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item.Position, 1))
			{
				KeyPads_Method(item);
				if (HelpSHOW)
				{
					HELP();
				}
			}
		}
	}

	public unsafe static void KeyPads_Method(Prop KeyPad)
	{
		switch (ExtraLootSwitch)
		{
		case 0:
		{
			if (!(Game.Player.Character.Position.DistanceTo(KeyPad.Position) < 1f) || !(KeyPad.AttachedBlip != null))
			{
				break;
			}
			Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to hack the keypad.");
			if (!Game.IsControlJustPressed(Control.Context))
			{
				break;
			}
			Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
			if (Groups.IS_PED_USING_ACTION_MODE(Game.Player.Character))
			{
				Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, use: false);
				IsUsingActionMode = true;
			}
			else
			{
				IsUsingActionMode = false;
			}
			AllowControl = true;
			iVar62 = 31;
			numMin = 3;
			numSec = 6;
			numSec2 = 0;
			numMil = 0;
			numMil2 = 0;
			Random random = new Random();
			animchoice = random.Next(1, 3);
			PrintsAllowed = random.Next(1, 5);
			MoveLR = 1;
			MoveUD = 1;
			SelectedTiles.Clear();
			Lives = random.Next(1, 7);
			RandomSpots[0] = 0;
			RandomSpots[1] = 0;
			RandomSpots[2] = 0;
			RandomSpots[3] = 0;
			RandomSpots[4] = 0;
			RandomSpots[5] = 0;
			RandomSpots[6] = 0;
			RandomSpots[7] = 0;
			RandomSpots[8] = 0;
			PrintChoice[0] = 0;
			PrintChoice[1] = 0;
			PrintChoice[2] = 0;
			PrintChoice[3] = 0;
			CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@");
			CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@");
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Fingerprint_Match");
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Fingerprint_Match", false, -1);
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Door_Hacking");
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Door_Hacking", false, -1);
			Script.Wait(50);
			Vector3 vector = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_POSITION, "anim_heist@hs3f@ig1_hack_keypad@male@", "action_var_0" + animchoice, KeyPad.Position.X, KeyPad.Position.Y, KeyPad.Position.Z, KeyPad.Rotation.X, KeyPad.Rotation.Y, KeyPad.Rotation.Z, 0f, 2);
			Vector3 vector2 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_ROTATION, "anim_heist@hs3f@ig1_hack_keypad@male@", "action_var_0" + animchoice, KeyPad.Position.X, KeyPad.Position.Y, KeyPad.Position.Z, KeyPad.Rotation.X, KeyPad.Rotation.Y, KeyPad.Rotation.Z, 0f, 2);
			int num63 = 0;
			Function.Call(Hash.OPEN_SEQUENCE_TASK, &num63);
			if (Game.Player.Character.IsRunning || Game.Player.Character.IsSprinting)
			{
				Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 512, vector2.Z);
			}
			else
			{
				Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 2, vector2.Z);
			}
			Function.Call(Hash.CLOSE_SEQUENCE_TASK, num63);
			Function.Call(Hash.TASK_PERFORM_SEQUENCE, Game.Player.Character, num63);
			Function.Call(Hash.CLEAR_SEQUENCE_TASK, &num63);
			Script.Wait(500);
			while (Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, Game.Player.Character) != -1)
			{
				Script.Wait(0);
			}
			Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
			while (Phone == null)
			{
				Phone = World.CreateProp(CruelMastersOnlineOffline.RequestModel("prop_phone_ing"), new Vector3(0f, 0f, 0f), dynamic: false, placeOnGround: false);
				Script.Wait(0);
			}
			Phone.IsVisible = false;
			while (USB == null)
			{
				USB = World.CreateProp(CruelMastersOnlineOffline.RequestModel("ch_prop_ch_usb_drive01x"), new Vector3(0f, 0f, 0f), dynamic: false, placeOnGround: false);
				Script.Wait(0);
			}
			USB.IsVisible = false;
			CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, KeyPad.Position.X, KeyPad.Position.Y, KeyPad.Position.Z, KeyPad.Rotation.X, KeyPad.Rotation.Y, KeyPad.Rotation.Z, 2);
			Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim_heist@hs3f@ig1_hack_keypad@male@", "action_var_0" + animchoice, 0.0, 0.0, 0, 0, 1148846080, 0);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Phone, CruelMastersOnlineOffline.TestCutsceneAnim, "action_var_0" + animchoice + "prop_phone_ing", CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), 1000f, 0f, 0, 1000f);
			Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Phone, Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
			Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(Phone);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, USB, CruelMastersOnlineOffline.TestCutsceneAnim, "action_var_0" + animchoice + "ch_prop_ch_usb_drive01x", CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), 1000f, 0f, 0, 1000f);
			Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, USB, Game.Player.Character, Game.Player.Character.Bones[Bone.PHLeftHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
			Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(USB);
			USB.IsVisible = true;
			Phone.IsVisible = true;
			while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), "action_var_0" + animchoice, 3))
			{
				Script.Wait(0);
			}
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_Common");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_Grid");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_Grid1");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_Grid2");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_GridDetails");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_Decor");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_Decor1");
			int num64 = 0;
			while (num64 <= 3)
			{
				Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "MPFClone_Print" + num64);
				num64++;
				Script.Wait(0);
			}
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "mphackinggameoverlay");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "mphackinggameoverlay1");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "mphackinggame");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "mphackinggamebg");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "mphackinggamewin");
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "mphackinggamewin3");
			int num65 = 0;
			while (num65 < 4)
			{
				int num66 = RNG.Next(1, 5);
				if (!PrintChoice.Contains(num66))
				{
					PrintChoice[num65] = num66;
					num65++;
				}
				else
				{
					num66 = RNG.Next(1, 5);
				}
				Script.Wait(0);
			}
			int num67 = 1;
			while (num67 <= 8)
			{
				int num68 = RNG.Next(1, 9);
				if (!RandomSpots.Contains(num68))
				{
					RandomSpots[num67] = num68;
					num67++;
				}
				else
				{
					num68 = RNG.Next(1, 9);
				}
				Script.Wait(0);
			}
			fcalpha = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 127, 255);
			CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, KeyPad.Position.X, KeyPad.Position.Y, KeyPad.Position.Z, KeyPad.Rotation.X, KeyPad.Rotation.Y, KeyPad.Rotation.Z, 2);
			Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim_heist@hs3f@ig1_hack_keypad@male@", "hack_loop_var_0" + animchoice, 0.0, 0.0, 0, 0, 1148846080, 0);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Phone, CruelMastersOnlineOffline.TestCutsceneAnim, "hack_loop_var_0" + animchoice + "prop_phone_ing", CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), 1000f, 0f, 0, 1000f);
			Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(Phone);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, USB, CruelMastersOnlineOffline.TestCutsceneAnim, "hack_loop_var_0" + animchoice + "ch_prop_ch_usb_drive01x", CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), 1000f, 0f, 0, 1000f);
			Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(USB);
			Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
			HudHandler.HudandRadar(Hud: false, Radar: false);
			Script.Wait(1000);
			Function.Call(Hash.START_AUDIO_SCENE, "DLC_H3_Fingerprint_Hack_Scene");
			while (Bink == 0 && !Game.Player.Character.IsDead)
			{
				Bink = Function.Call<int>(Hash.SET_BINK_MOVIE, "INTRO_FC");
				Script.Wait(0);
			}
			Function.Call(Hash.PLAY_BINK_MOVIE, Bink);
			Function.Call(Hash.SET_BINK_MOVIE_TIME, Bink, 0f);
			while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 0.1f && !Game.Player.Character.IsDead)
			{
				Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
				Script.Wait(0);
			}
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Startup_Sequence", "DLC_H3_Cas_Door_Minigame_Sounds", true);
			while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 75f && !Game.Player.Character.IsDead)
			{
				Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
				Script.Wait(0);
			}
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Draw_Screen", "DLC_H3_Cas_Door_Minigame_Sounds", true);
			while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 99f && !Game.Player.Character.IsDead)
			{
				Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
				Script.Wait(0);
			}
			Function.Call(Hash.STOP_BINK_MOVIE, Bink);
			Function.Call(Hash.RELEASE_BINK_MOVIE, Bink);
			SoundId = Function.Call<int>(Hash.GET_SOUND_ID);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId, "Background_Hum", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
			Bink = 0;
			HelpSHOW = true;
			ExtraLootSwitch = 1;
			break;
		}
		case 1:
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 27, true);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 19, true);
			func_687();
			Function.Call(Hash.DRAW_SPRITE, "mphackinggamebg", "bg", 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Black_BG", 0.5f, 0.5f, 1f, 1f, 0f, 5, 5, 5, 100, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "background_layout", 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "mphackinggameoverlay", "grid_rgb_pixels", 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "mphackinggameoverlay1", "ScreenGrid", 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
			switch (BGSwitch[0])
			{
			case 0:
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Decor", "techaration_" + bgset[0], 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.439f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.902f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > bgtimer[0])
				{
					bgset[0]++;
					bgtimer[0] = Game.GameTime + 500;
				}
				if (bgset[0] > 1)
				{
					BGSwitch[0] = 1;
					bgtimer[0] = Game.GameTime + 500;
				}
				break;
			case 1:
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Decor1", "techaration_" + bgset[0], 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.439f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.902f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > bgtimer[0])
				{
					bgset[0]++;
					bgtimer[0] = Game.GameTime + 500;
				}
				if (bgset[0] > 3)
				{
					bgset[0] = 0;
					BGSwitch[0] = 0;
				}
				break;
			}
			if (BGSwitch[1] == 0)
			{
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disc_a" + bgset[1], func_10943(0.983f), 0.669f, 5f / 96f, 5f / 54f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disc_b" + bgset[1], func_10943(0.983f), 0.669f, 5f / 96f, 5f / 54f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disc_c" + bgset[1], func_10943(0.983f), 0.669f, 5f / 96f, 5f / 54f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > bgtimer[1])
				{
					bgset[1]++;
					bgtimer[1] = Game.GameTime + 500;
				}
				if (bgset[1] > 2)
				{
					bgset[1] = 0;
					bgtimer[1] = Game.GameTime + 500;
				}
			}
			if (BGSwitch[3] == 0)
			{
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_colon", func_10943(0.122f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_colon", func_10943(0.215f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				numMil2--;
				if (numMil > 9)
				{
					numMil = 0;
				}
				else if (numMil < 0)
				{
					numMil = 9;
				}
				if (numMil2 > 9)
				{
					numMil2 = 0;
				}
				else if (numMil2 < 0)
				{
					numMil2 = 9;
				}
				if (numMil2 == 0)
				{
					numMil2 = 9;
					numMil--;
					if (numMil < 0)
					{
						numSec2--;
						numMil = 9;
					}
				}
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_" + numMil, func_10943(0.24599999f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_" + numMil2, func_10943(0.277f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				if (numSec > 6)
				{
					numSec = 0;
				}
				else if (numSec < 0)
				{
					numSec = 6;
				}
				if (numSec2 > 9)
				{
					numSec2 = 0;
				}
				else if (numSec2 < -1)
				{
					numSec2 = 9;
				}
				if (numSec2 == -1)
				{
					numSec2 = 9;
					numSec--;
					if (numSec < 0)
					{
						numSec2 = 0;
						numMin--;
						numSec = 6;
					}
				}
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_" + numSec, func_10943(0.153f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_" + numSec2, func_10943(0.184f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				if (numSec == 0 && numSec2 == -1)
				{
					numMin--;
					if (numMin < 0)
					{
						numMin = 3;
					}
				}
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_0", func_10943(0.060000002f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "numbers_" + numMin, func_10943(0.091000006f), 0.144f, 1f / 48f, 1f / 18f, 0f, 255, 255, 255, 255, 0);
				if (numMin == 0 && numSec == 0 && numSec2 == 0)
				{
					HackSwitch = 50;
				}
			}
			switch (HackSwitch)
			{
			case 0:
			{
				if (AllowControl)
				{
					CONTROLS();
				}
				int num42 = PrintChoice[0] - 1;
				for (int num43 = 1; num43 <= 8; num43++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num42, "fp" + PrintChoice[0] + "_" + num43, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num44 = 1;
				float uParam19 = 0f;
				float uParam20 = 0f;
				for (; num44 <= 8; num44++)
				{
					int num45 = (SelectedTiles.Contains(RandomSpots[num44]) ? 255 : 125);
					func_10961(RandomSpots[num44], out uParam19, out uParam20);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num42}", $"fp{PrintChoice[0]}_comp_{num44}", func_10943(uParam19), uParam20, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num45, 0);
				}
				for (int num46 = 1; num46 <= Lives; num46++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num46, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.536f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				if (num42 == 0)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[4]) && SelectedTiles.Contains(RandomSpots[6]) && SelectedTiles.Contains(RandomSpots[7]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 1;
					}
				}
				if (num42 == 1)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 1;
					}
				}
				if (num42 == 2)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 1;
					}
				}
				if (num42 == 3)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 1;
					}
				}
				if (Lives <= 0)
				{
					HackSwitch = 50;
				}
				break;
			}
			case 1:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num21 = PrintChoice[0] - 1;
				for (int num22 = 1; num22 <= 8; num22++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num21, "fp" + PrintChoice[0] + "_" + num22, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num23 = 1;
				float uParam11 = 0f;
				float uParam12 = 0f;
				for (; num23 <= 8; num23++)
				{
					int num24 = (SelectedTiles.Contains(RandomSpots[num23]) ? 255 : 125);
					func_10961(RandomSpots[num23], out uParam11, out uParam12);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num21}", $"fp{PrintChoice[0]}_comp_{num23}", func_10943(uParam11), uParam12, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num24, 0);
				}
				for (int num25 = 1; num25 <= Lives; num25++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num25, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.536f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > previousUpdate + 60)
				{
					previousUpdate = Game.GameTime;
					if (iVar6 < 35)
					{
						iVar6++;
					}
				}
				for (int num26 = 0; num26 < iVar6; num26++)
				{
					float fParam2 = 0.33f + 0.01f * (float)num26;
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Bar_Segment", func_10943(fParam2), 0.516f, 1f / 160f, 1f / 27f, 0f, 255, 255, 255, 255, 0);
				}
				if (iVar6 >= 35)
				{
					Audio.StopSound(SoundId2);
					Audio.ReleaseSound(SoundId2);
					if (HackOutCome)
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Target_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					else
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "No_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					bgtimer[2] = Game.GameTime + 500;
					iVar6 = 0;
					HackSwitch = 2;
				}
				break;
			}
			case 2:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num27 = PrintChoice[0] - 1;
				for (int num28 = 1; num28 <= 8; num28++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num27, "fp" + PrintChoice[0] + "_" + num28, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num29 = 1;
				float uParam13 = 0f;
				float uParam14 = 0f;
				for (; num29 <= 8; num29++)
				{
					int num30 = (SelectedTiles.Contains(RandomSpots[num29]) ? 255 : 125);
					func_10961(RandomSpots[num29], out uParam13, out uParam14);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num27}", $"fp{PrintChoice[0]}_comp_{num29}", func_10943(uParam13), uParam14, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num30, 0);
				}
				for (int num31 = 1; num31 <= Lives; num31++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num31, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.536f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (HackOutCome)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "correct_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				else
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "incorrect_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				if (timer >= 6)
				{
					if (!HackOutCome)
					{
						AllowControl = true;
						Lives--;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Appears", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 0;
					}
					else if (PrintsAllowed > 1)
					{
						AllowControl = true;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Appears", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 3;
					}
					else
					{
						AllowControl = true;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						HackSwitch = 12;
					}
				}
				break;
			}
			case 3:
			{
				if (AllowControl)
				{
					CONTROLS();
				}
				int num37 = PrintChoice[1] - 1;
				for (int num38 = 1; num38 <= 8; num38++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num37, "fp" + PrintChoice[1] + "_" + num38, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num39 = 1;
				float uParam17 = 0f;
				float uParam18 = 0f;
				for (; num39 <= 8; num39++)
				{
					int num40 = (SelectedTiles.Contains(RandomSpots[num39]) ? 255 : 125);
					func_10961(RandomSpots[num39], out uParam17, out uParam18);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num37}", $"fp{PrintChoice[1]}_comp_{num39}", func_10943(uParam17), uParam18, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num40, 0);
				}
				for (int num41 = 1; num41 <= Lives; num41++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num41, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.662f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				if (num37 == 0)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[4]) && SelectedTiles.Contains(RandomSpots[6]) && SelectedTiles.Contains(RandomSpots[7]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 4;
					}
				}
				if (num37 == 1)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 4;
					}
				}
				if (num37 == 2)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 4;
					}
				}
				if (num37 == 3)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 4;
					}
				}
				if (Lives <= 0)
				{
					HackSwitch = 50;
				}
				break;
			}
			case 4:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num15 = PrintChoice[1] - 1;
				for (int num16 = 1; num16 <= 8; num16++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num15, "fp" + PrintChoice[1] + "_" + num16, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num17 = 1;
				float uParam9 = 0f;
				float uParam10 = 0f;
				for (; num17 <= 8; num17++)
				{
					int num18 = (SelectedTiles.Contains(RandomSpots[num17]) ? 255 : 125);
					func_10961(RandomSpots[num17], out uParam9, out uParam10);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num15}", $"fp{PrintChoice[1]}_comp_{num17}", func_10943(uParam9), uParam10, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num18, 0);
				}
				for (int num19 = 1; num19 <= Lives; num19++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num19, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.662f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > previousUpdate + 60)
				{
					previousUpdate = Game.GameTime;
					if (iVar6 < 35)
					{
						iVar6++;
					}
				}
				for (int num20 = 0; num20 < iVar6; num20++)
				{
					float fParam = 0.33f + 0.01f * (float)num20;
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Bar_Segment", func_10943(fParam), 0.516f, 1f / 160f, 1f / 27f, 0f, 255, 255, 255, 255, 0);
				}
				if (iVar6 >= 35)
				{
					Audio.StopSound(SoundId2);
					Audio.ReleaseSound(SoundId2);
					if (HackOutCome)
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Target_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					else
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "No_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					bgtimer[2] = Game.GameTime + 500;
					iVar6 = 0;
					HackSwitch = 5;
				}
				break;
			}
			case 5:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num3 = PrintChoice[1] - 1;
				for (int l = 1; l <= 8; l++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num3, "fp" + PrintChoice[1] + "_" + l, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int m = 1;
				float uParam3 = 0f;
				float uParam4 = 0f;
				for (; m <= 8; m++)
				{
					int num4 = (SelectedTiles.Contains(RandomSpots[m]) ? 255 : 125);
					func_10961(RandomSpots[m], out uParam3, out uParam4);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num3}", $"fp{PrintChoice[1]}_comp_{m}", func_10943(uParam3), uParam4, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num4, 0);
				}
				for (int n = 1; n <= Lives; n++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)n, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.662f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (HackOutCome)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "correct_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				else
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "incorrect_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				if (timer >= 6)
				{
					if (!HackOutCome)
					{
						AllowControl = true;
						Lives--;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Appears", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 3;
					}
					else if (PrintsAllowed > 2)
					{
						AllowControl = true;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Appears", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 6;
					}
					else
					{
						AllowControl = true;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						HackSwitch = 12;
					}
				}
				break;
			}
			case 6:
			{
				if (AllowControl)
				{
					CONTROLS();
				}
				int num = PrintChoice[2] - 1;
				for (int i = 1; i <= 8; i++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num, "fp" + PrintChoice[2] + "_" + i, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int j = 1;
				float uParam = 0f;
				float uParam2 = 0f;
				for (; j <= 8; j++)
				{
					int num2 = (SelectedTiles.Contains(RandomSpots[j]) ? 255 : 125);
					func_10961(RandomSpots[j], out uParam, out uParam2);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num}", $"fp{PrintChoice[2]}_comp_{j}", func_10943(uParam), uParam2, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num2, 0);
				}
				for (int k = 1; k <= Lives; k++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)k, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.782f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				if (num == 0)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[4]) && SelectedTiles.Contains(RandomSpots[6]) && SelectedTiles.Contains(RandomSpots[7]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 7;
					}
				}
				if (num == 1)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 7;
					}
				}
				if (num == 2)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 7;
					}
				}
				if (num == 3)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 7;
					}
				}
				if (Lives <= 0)
				{
					HackSwitch = 50;
				}
				break;
			}
			case 7:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num54 = PrintChoice[2] - 1;
				for (int num55 = 1; num55 <= 8; num55++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num54, "fp" + PrintChoice[2] + "_" + num55, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num56 = 1;
				float uParam23 = 0f;
				float uParam24 = 0f;
				for (; num56 <= 8; num56++)
				{
					int num57 = (SelectedTiles.Contains(RandomSpots[num56]) ? 255 : 125);
					func_10961(RandomSpots[num56], out uParam23, out uParam24);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num54}", $"fp{PrintChoice[2]}_comp_{num56}", func_10943(uParam23), uParam24, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num57, 0);
				}
				for (int num58 = 1; num58 <= Lives; num58++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num58, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.782f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > previousUpdate + 60)
				{
					previousUpdate = Game.GameTime;
					if (iVar6 < 35)
					{
						iVar6++;
					}
				}
				for (int num59 = 0; num59 < iVar6; num59++)
				{
					float fParam4 = 0.33f + 0.01f * (float)num59;
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Bar_Segment", func_10943(fParam4), 0.516f, 1f / 160f, 1f / 27f, 0f, 255, 255, 255, 255, 0);
				}
				if (iVar6 >= 35)
				{
					Audio.StopSound(SoundId2);
					Audio.ReleaseSound(SoundId2);
					if (HackOutCome)
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Target_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					else
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "No_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					bgtimer[2] = Game.GameTime + 500;
					iVar6 = 0;
					HackSwitch = 8;
				}
				break;
			}
			case 8:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num10 = PrintChoice[2] - 1;
				for (int num11 = 1; num11 <= 8; num11++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num10, "fp" + PrintChoice[2] + "_" + num11, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num12 = 1;
				float uParam7 = 0f;
				float uParam8 = 0f;
				for (; num12 <= 8; num12++)
				{
					int num13 = (SelectedTiles.Contains(RandomSpots[num12]) ? 255 : 125);
					func_10961(RandomSpots[num12], out uParam7, out uParam8);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num10}", $"fp{PrintChoice[2]}_comp_{num12}", func_10943(uParam7), uParam8, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num13, 0);
				}
				for (int num14 = 1; num14 <= Lives; num14++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num14, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.782f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (HackOutCome)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "correct_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				else
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "incorrect_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				if (timer >= 6)
				{
					if (!HackOutCome)
					{
						AllowControl = true;
						Lives--;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Appears", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 6;
					}
					else if (PrintsAllowed > 3)
					{
						AllowControl = true;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Appears", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 9;
					}
					else
					{
						AllowControl = true;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						HackSwitch = 12;
					}
				}
				break;
			}
			case 9:
			{
				if (AllowControl)
				{
					CONTROLS();
				}
				int num32 = PrintChoice[3] - 1;
				for (int num33 = 1; num33 <= 8; num33++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num32, "fp" + PrintChoice[3] + "_" + num33, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num34 = 1;
				float uParam15 = 0f;
				float uParam16 = 0f;
				for (; num34 <= 8; num34++)
				{
					int num35 = (SelectedTiles.Contains(RandomSpots[num34]) ? 255 : 125);
					func_10961(RandomSpots[num34], out uParam15, out uParam16);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num32}", $"fp{PrintChoice[3]}_comp_{num34}", func_10943(uParam15), uParam16, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num35, 0);
				}
				for (int num36 = 1; num36 <= Lives; num36++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num36, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.905f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				if (num32 == 0)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[4]) && SelectedTiles.Contains(RandomSpots[6]) && SelectedTiles.Contains(RandomSpots[7]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 10;
					}
				}
				if (num32 == 1)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 10;
					}
				}
				if (num32 == 2)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 10;
					}
				}
				if (num32 == 3)
				{
					if (SelectedTiles.Contains(RandomSpots[1]) && SelectedTiles.Contains(RandomSpots[2]) && SelectedTiles.Contains(RandomSpots[3]) && SelectedTiles.Contains(RandomSpots[4]))
					{
						HackOutCome = true;
					}
					else
					{
						HackOutCome = false;
					}
					if (SelectedTiles.Count == 4 && Game.IsControlJustPressed(Control.Context))
					{
						iVar62 = 31;
						AllowControl = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Window_Draw", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						SoundId2 = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, SoundId2, "Processing", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 10;
					}
				}
				if (Lives <= 0)
				{
					HackSwitch = 50;
				}
				break;
			}
			case 10:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num47 = PrintChoice[3] - 1;
				for (int num48 = 1; num48 <= 8; num48++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num47, "fp" + PrintChoice[3] + "_" + num48, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num49 = 1;
				float uParam21 = 0f;
				float uParam22 = 0f;
				for (; num49 <= 8; num49++)
				{
					int num50 = (SelectedTiles.Contains(RandomSpots[num49]) ? 255 : 125);
					func_10961(RandomSpots[num49], out uParam21, out uParam22);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num47}", $"fp{PrintChoice[3]}_comp_{num49}", func_10943(uParam21), uParam22, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num50, 0);
				}
				for (int num51 = 1; num51 <= Lives; num51++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num51, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.905f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > previousUpdate + 60)
				{
					previousUpdate = Game.GameTime;
					if (iVar6 < 35)
					{
						iVar6++;
					}
				}
				for (int num52 = 0; num52 < iVar6; num52++)
				{
					float fParam3 = 0.33f + 0.01f * (float)num52;
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Bar_Segment", func_10943(fParam3), 0.516f, 1f / 160f, 1f / 27f, 0f, 255, 255, 255, 255, 0);
				}
				if (iVar6 >= 35)
				{
					Audio.StopSound(SoundId2);
					Audio.ReleaseSound(SoundId2);
					if (HackOutCome)
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Target_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					else
					{
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "No_Match", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					}
					bgtimer[2] = Game.GameTime + 500;
					iVar6 = 0;
					HackSwitch = 11;
				}
				break;
			}
			case 11:
			{
				if (MoveLR == 1 && MoveUD == 1)
				{
					currentlySelectedTile = 1;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 1)
				{
					currentlySelectedTile = 2;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 2)
				{
					currentlySelectedTile = 3;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 2)
				{
					currentlySelectedTile = 4;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 3)
				{
					currentlySelectedTile = 5;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 3)
				{
					currentlySelectedTile = 6;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 1 && MoveUD == 4)
				{
					currentlySelectedTile = 7;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				if (MoveLR == 2 && MoveUD == 4)
				{
					currentlySelectedTile = 8;
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				}
				int num5 = PrintChoice[3] - 1;
				for (int num6 = 1; num6 <= 8; num6++)
				{
					Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num5, "fp" + PrintChoice[3] + "_" + num6, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
				}
				int num7 = 1;
				float uParam5 = 0f;
				float uParam6 = 0f;
				for (; num7 <= 8; num7++)
				{
					int num8 = (SelectedTiles.Contains(RandomSpots[num7]) ? 255 : 125);
					func_10961(RandomSpots[num7], out uParam5, out uParam6);
					Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num5}", $"fp{PrintChoice[3]}_comp_{num7}", func_10943(uParam5), uParam6, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num8, 0);
				}
				for (int num9 = 1; num9 <= Lives; num9++)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "life", func_10943(0.983f), 0.19f + 0.055f * (float)num9, 1f / 30f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				}
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.905f), 0.832f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (HackOutCome)
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "correct_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				else
				{
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "incorrect_" + bgset[2], 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
					if (Game.GameTime > bgtimer[2])
					{
						timer++;
						bgset[2]++;
						bgtimer[2] = Game.GameTime + 500;
					}
					if (bgset[2] > 1)
					{
						bgset[2] = 0;
						bgtimer[2] = Game.GameTime + 500;
					}
				}
				if (timer >= 6)
				{
					if (!HackOutCome)
					{
						AllowControl = true;
						Lives--;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Appears", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
						HackSwitch = 9;
					}
					else
					{
						AllowControl = true;
						timer = 0;
						SelectedTiles.Clear();
						RANDOMIZE_PRINTS_COMPS();
						MoveLR = 1;
						MoveUD = 1;
						HackOutCome = false;
						HackSwitch = 12;
					}
				}
				break;
			}
			case 12:
			{
				Audio.StopSound(SoundId);
				Audio.ReleaseSound(SoundId);
				Audio.StopSound(SoundId2);
				Audio.ReleaseSound(SoundId2);
				Phone.Delete();
				Phone = null;
				while (Bink == 0 && !Game.Player.Character.IsDead)
				{
					Bink = Function.Call<int>(Hash.SET_BINK_MOVIE, "Success_FC");
					Script.Wait(0);
				}
				Function.Call(Hash.PLAY_BINK_MOVIE, Bink);
				Function.Call(Hash.SET_BINK_MOVIE_TIME, Bink, 0f);
				HelpSHOW = false;
				while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 0.1f && !Game.Player.Character.IsDead)
				{
					Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
					Script.Wait(0);
				}
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hack_Success", "DLC_H3_Cas_Door_Minigame_Sounds", true);
				while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 75f && !Game.Player.Character.IsDead)
				{
					Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
					Script.Wait(0);
				}
				while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 99f && !Game.Player.Character.IsDead)
				{
					Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_BINK_MOVIE, Bink);
				Function.Call(Hash.RELEASE_BINK_MOVIE, Bink);
				Function.Call(Hash.STOP_AUDIO_SCENES);
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, KeyPad.Position.X, KeyPad.Position.Y, KeyPad.Position.Z, KeyPad.Rotation.X, KeyPad.Rotation.Y, KeyPad.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim_heist@hs3f@ig1_hack_keypad@male@", "success_react_exit_var_0" + animchoice, 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, USB, CruelMastersOnlineOffline.TestCutsceneAnim, "success_react_exit_var_0" + animchoice + "_ch_prop_ch_usb_drive01x", CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), 1000f, 0f, 0, 1000f);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(USB);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
				HudHandler.HudandRadar(Hud: true, Radar: true);
				Bink = 0;
				HackSwitch = 0;
				BGSwitch[0] = 0;
				BGSwitch[1] = 0;
				bgset[0] = 0;
				bgset[1] = 0;
				bgset[2] = 0;
				ExtraLootSwitch = 0;
				while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), "success_react_exit_var_0" + animchoice, 3))
				{
					Script.Wait(0);
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Fingerprint_Match");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Door_Hacking");
				Prop[] nearbyProps = World.GetNearbyProps(KeyPad.Position, disttodoor, CruelMastersOnlineOffline.RequestModel(doormodel));
				Prop[] array = nearbyProps;
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
				USB.Delete();
				USB = null;
				if (KeyPad.AttachedBlip != null)
				{
					KeyPad.AttachedBlip.Delete();
				}
				Game.Player.Character.Task.ClearAll();
				if (IsUsingActionMode)
				{
					Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, use: true);
				}
				Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
				break;
			}
			case 50:
				Audio.StopSound(SoundId);
				Audio.ReleaseSound(SoundId);
				Audio.StopSound(SoundId2);
				Audio.ReleaseSound(SoundId2);
				Phone.Delete();
				Phone = null;
				while (Bink == 0 && !Game.Player.Character.IsDead)
				{
					Bink = Function.Call<int>(Hash.SET_BINK_MOVIE, "FAIL_FC");
					Script.Wait(0);
				}
				Function.Call(Hash.PLAY_BINK_MOVIE, Bink);
				Function.Call(Hash.SET_BINK_MOVIE_TIME, Bink, 0f);
				HelpSHOW = false;
				while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 0.1f && !Game.Player.Character.IsDead)
				{
					Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
					Script.Wait(0);
				}
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hack_Failed", "DLC_H3_Cas_Door_Minigame_Sounds", true);
				while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 75f && !Game.Player.Character.IsDead)
				{
					Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
					Script.Wait(0);
				}
				while (Function.Call<float>(Hash.GET_BINK_MOVIE_TIME, Bink) < 99f && !Game.Player.Character.IsDead)
				{
					Function.Call(Hash.DRAW_BINK_MOVIE, Bink, 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255);
					Script.Wait(0);
				}
				Function.Call(Hash.STOP_BINK_MOVIE, Bink);
				Function.Call(Hash.RELEASE_BINK_MOVIE, Bink);
				Function.Call(Hash.STOP_AUDIO_SCENES);
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, KeyPad.Position.X, KeyPad.Position.Y, KeyPad.Position.Z, KeyPad.Rotation.X, KeyPad.Rotation.Y, KeyPad.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim_heist@hs3f@ig1_hack_keypad@male@", "fail_react_quick", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, USB, CruelMastersOnlineOffline.TestCutsceneAnim, "fail_react_quick_ch_prop_ch_usb_drive01x", CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), 1000f, 0f, 0, 1000f);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(USB);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
				HudHandler.HudandRadar(Hud: true, Radar: true);
				Bink = 0;
				HackSwitch = 0;
				BGSwitch[0] = 0;
				BGSwitch[1] = 0;
				bgset[0] = 0;
				bgset[1] = 0;
				bgset[2] = 0;
				ExtraLootSwitch = 0;
				while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("anim_heist@hs3f@ig1_hack_keypad@male@"), "fail_react_quick", 3))
				{
					Script.Wait(0);
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Fingerprint_Match");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Door_Hacking");
				USB.Delete();
				USB = null;
				Game.Player.Character.Task.ClearAll();
				if (IsUsingActionMode)
				{
					Groups.SET_PED_USING_ACTION_MODE(Game.Player.Character, use: true);
				}
				Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
				break;
			}
			if (Game.IsControlPressed(Control.Reload))
			{
				if (Game.GameTime > AbortTimer)
				{
					AbortTimer = 0;
					HackSwitch = 50;
				}
			}
			else
			{
				AbortTimer = Game.GameTime + 3000;
			}
			if (ExtraLootSwitch != 1)
			{
				break;
			}
			if (PrintsAllowed == 1)
			{
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			}
			if (PrintsAllowed == 2)
			{
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[1], func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			}
			if (PrintsAllowed == 3)
			{
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[1], func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[2], func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			}
			if (PrintsAllowed == 4)
			{
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[1], func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[2], func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[3], func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			}
			switch (BGSwitch[4])
			{
			case 0:
			{
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Scrambler_BG", 0.313f, 0.846f, 5f / 24f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > previousUpdate2)
				{
					previousUpdate2 = Game.GameTime + 3000;
					if (iVar62 > 0 && AllowControl)
					{
						iVar62--;
					}
				}
				for (int num61 = 0; num61 < iVar62; num61++)
				{
					float num62 = 0.217f + 0.00635f * (float)num61;
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "scrambler_fill_segment", num62, 0.852f, 1f / 160f, 2f / 27f, 0f, 255, 255, 255, 255, 0);
				}
				if (iVar62 == 0)
				{
					SelectedTiles.Clear();
					MoveLR = 1;
					MoveUD = 1;
					AllowControl = false;
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Print_Shuffle", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
					bgtimer[2] = Game.GameTime + 500;
					iVar62 = 31;
					AllowControl = false;
					BGSwitch[4] = 1;
				}
				break;
			}
			case 1:
			{
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Scrambler_BG", 0.313f, 0.846f, 5f / 24f, 8f / 135f, 0f, 255, 255, 255, 255, 0);
				Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "loading_window_blank", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
				if (Game.GameTime > previousUpdate + 130)
				{
					RANDOMIZE_PRINTS_COMPS();
					previousUpdate = Game.GameTime;
					if (iVar6 < 35)
					{
						iVar6++;
					}
				}
				for (int num60 = 0; num60 < iVar6; num60++)
				{
					float fParam5 = 0.33f + 0.01f * (float)num60;
					Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Loading_Bar_Segment", func_10943(fParam5), 0.516f, 1f / 160f, 1f / 27f, 0f, 255, 255, 255, 255, 0);
				}
				if (iVar6 >= 35)
				{
					AllowControl = true;
					bgtimer[2] = Game.GameTime + 500;
					iVar6 = 0;
					BGSwitch[4] = 0;
				}
				break;
			}
			}
			break;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (Phone != null)
		{
			Phone.Delete();
		}
		if (USB != null)
		{
			USB.Delete();
		}
		RemoveKeyPads();
		Audio.StopSound(SoundId);
		Audio.ReleaseSound(SoundId);
		Audio.StopSound(SoundId2);
		Audio.ReleaseSound(SoundId2);
		if (Bink != 0)
		{
			Function.Call(Hash.STOP_BINK_MOVIE, Bink);
			Function.Call(Hash.RELEASE_BINK_MOVIE, Bink);
		}
	}

	public static Prop KeyPad(Vector3 pposition, float HHeading)
	{
		Model model = new Model("ch_prop_fingerprint_scanner_01c");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		model = new Model("ch_prop_fingerprint_scanner_01c");
		model.Request(10000);
		if (model.IsValid && model.IsInCdImage)
		{
			while (!model.IsLoaded)
			{
				Script.Wait(50);
			}
			prop = World.CreatePropNoOffset(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false);
			if (prop != null)
			{
				KeyPadSpawn.Add(prop);
			}
			return prop;
		}
		return prop;
	}

	public static void SPAWN_KEYPAD(Vector3 pposition, float HHeading)
	{
		Prop prop = KeyPad(pposition, HHeading);
		BlipUpKeyPads();
	}

	public static void RemoveKeyPads()
	{
		if (KeyPadSpawn.Count > 0)
		{
			foreach (Prop item in KeyPadSpawn.ToList())
			{
				if (item != null)
				{
					item.Delete();
					KeyPadSpawn.Remove(item);
				}
			}
		}
		Audio.StopSound(SoundId);
		Audio.ReleaseSound(SoundId);
		Audio.StopSound(SoundId2);
		Audio.ReleaseSound(SoundId2);
		if (Phone != null)
		{
			Phone.Delete();
			Phone = null;
		}
		if (USB != null)
		{
			USB.Delete();
			USB = null;
		}
		if (Bink != 0)
		{
			Bink = 0;
			Function.Call(Hash.STOP_BINK_MOVIE, Bink);
			Function.Call(Hash.RELEASE_BINK_MOVIE, Bink);
		}
		HackSwitch = 0;
		BGSwitch[0] = 0;
		BGSwitch[1] = 0;
		bgset[0] = 0;
		bgset[1] = 0;
		bgset[2] = 0;
		ExtraLootSwitch = 0;
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Fingerprint_Match");
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Door_Hacking");
	}

	public static void RecycleKeyPads()
	{
		if (KeyPadSpawn.Count > 0)
		{
			foreach (Prop item in KeyPadSpawn.ToList())
			{
				if (item != null)
				{
					item.MarkAsNoLongerNeeded();
					KeyPadSpawn.Remove(item);
				}
			}
		}
		Audio.StopSound(SoundId);
		Audio.ReleaseSound(SoundId);
		Audio.StopSound(SoundId2);
		Audio.ReleaseSound(SoundId2);
		if (Phone != null)
		{
			Phone.Delete();
			Phone = null;
		}
		if (USB != null)
		{
			USB.Delete();
			USB = null;
		}
		if (Bink != 0)
		{
			Bink = 0;
			Function.Call(Hash.STOP_BINK_MOVIE, Bink);
			Function.Call(Hash.RELEASE_BINK_MOVIE, Bink);
		}
		HackSwitch = 0;
		BGSwitch[0] = 0;
		BGSwitch[1] = 0;
		bgset[0] = 0;
		bgset[1] = 0;
		bgset[2] = 0;
		ExtraLootSwitch = 0;
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Fingerprint_Match");
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/Door_Hacking");
	}

	public static void BlipUpKeyPads()
	{
		if (KeyPadSpawn.Count <= 0)
		{
			return;
		}
		foreach (Prop item in KeyPadSpawn)
		{
			if (!(item != null))
			{
				continue;
			}
			if (item.AttachedBlip == null)
			{
				item.AddBlip();
			}
			if (item.AttachedBlip != null)
			{
				if (Game.Player.Character.Position.DistanceTo(item.Position) < 3f)
				{
					item.AttachedBlip.Alpha = 255;
				}
				else
				{
					item.AttachedBlip.Alpha = 0;
				}
				item.IsInvincible = true;
				item.IsPositionFrozen = true;
				item.AttachedBlip.Sprite = BlipSprite.ControlPanel3;
				item.AttachedBlip.Color = BlipColor.Green;
				item.AttachedBlip.Name = "Keypad";
			}
		}
	}

	public static float IntToFloat(int num)
	{
		return Function.Call<float>(Hash.TO_FLOAT, num);
	}

	public static float func_10943(float fParam0)
	{
		fParam0 = 0.5f - (0.5f - fParam0) / Function.Call<float>(Hash.GET_ASPECT_RATIO, 0);
		return fParam0;
	}

	public static void func_10961(int iParam0, out float uParam1, out float uParam2)
	{
		uParam1 = 0.105f;
		uParam2 = 0.306f;
		switch (iParam0)
		{
		case 1:
			uParam1 = 0.105f;
			uParam2 = 0.306f;
			break;
		case 2:
			uParam1 = 0.239f;
			uParam2 = 0.306f;
			break;
		case 3:
			uParam1 = 0.105f;
			uParam2 = 0.439f;
			break;
		case 4:
			uParam1 = 0.239f;
			uParam2 = 0.439f;
			break;
		case 5:
			uParam1 = 0.105f;
			uParam2 = 0.572f;
			break;
		case 6:
			uParam1 = 0.239f;
			uParam2 = 0.572f;
			break;
		case 7:
			uParam1 = 0.105f;
			uParam2 = 0.706f;
			break;
		case 8:
			uParam1 = 0.239f;
			uParam2 = 0.706f;
			break;
		}
	}

	public static void RANDOMIZE_PRINTS_COMPS()
	{
		RandomSpots[0] = 0;
		RandomSpots[1] = 0;
		RandomSpots[2] = 0;
		RandomSpots[3] = 0;
		RandomSpots[4] = 0;
		RandomSpots[5] = 0;
		RandomSpots[6] = 0;
		RandomSpots[7] = 0;
		RandomSpots[8] = 0;
		int num = 1;
		while (num <= 8)
		{
			int num2 = RNG.Next(1, 9);
			if (!RandomSpots.Contains(num2))
			{
				RandomSpots[num] = num2;
				num++;
			}
			else
			{
				num2 = RNG.Next(1, 9);
			}
		}
	}

	public static void CONTROLS()
	{
		if (Game.IsControlJustPressed(Control.MoveRightOnly) || Game.IsControlJustPressed(Control.PhoneRight))
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Cursor_Move", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
			MoveLR++;
		}
		if (Game.IsControlJustPressed(Control.MoveLeftOnly) || Game.IsControlJustPressed(Control.PhoneLeft))
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Cursor_Move", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
			MoveLR--;
		}
		if (MoveLR > 2)
		{
			MoveLR = 1;
		}
		if (MoveLR < 1)
		{
			MoveLR = 2;
		}
		if (Game.IsControlJustPressed(Control.MoveUpOnly) || Game.IsControlJustPressed(Control.PhoneUp))
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Cursor_Move", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
			MoveUD--;
		}
		if (Game.IsControlJustPressed(Control.MoveDownOnly) || Game.IsControlJustPressed(Control.PhoneDown))
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Cursor_Move", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
			MoveUD++;
		}
		if (MoveUD > 4)
		{
			MoveUD = 1;
		}
		if (MoveUD < 1)
		{
			MoveUD = 4;
		}
		if (MoveLR == 1 && MoveUD == 1)
		{
			currentlySelectedTile = 1;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 1)
		{
			currentlySelectedTile = 2;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 1 && MoveUD == 2)
		{
			currentlySelectedTile = 3;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 2)
		{
			currentlySelectedTile = 4;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 1 && MoveUD == 3)
		{
			currentlySelectedTile = 5;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 3)
		{
			currentlySelectedTile = 6;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 1 && MoveUD == 4)
		{
			currentlySelectedTile = 7;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 4)
		{
			currentlySelectedTile = 8;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (!Game.IsControlJustPressed(Control.FrontendAccept))
		{
			return;
		}
		if (!SelectedTiles.Contains(currentlySelectedTile))
		{
			if (SelectedTiles.Count != 4)
			{
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Select_Print_Tile", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
				SelectedTiles.Add(currentlySelectedTile);
			}
		}
		else if (SelectedTiles.Count != 0)
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Deselect_Print_Tile", "DLC_H3_Cas_Finger_Minigame_Sounds", true);
			SelectedTiles.Remove(currentlySelectedTile);
		}
	}

	public static void DRAW_PREV()
	{
		Function.Call(Hash.DRAW_SPRITE, "mphackinggamebg", "bg", 0.5f, 0.5f, 1f, 1f, 0f, 255, 255, 255, 255, 0);
		Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "Black_BG", 0.5f, 0.5f, 1f, 1f, 0f, 5, 5, 5, 100, 0);
		Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "background_layout", 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
		Function.Call(Hash.DRAW_SPRITE, "mphackinggameoverlay", "grid_rgb_pixels", 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
		Function.Call(Hash.DRAW_SPRITE, "mphackinggameoverlay1", "ScreenGrid", 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
		switch (BGSwitch[0])
		{
		case 0:
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Decor", "techaration_" + bgset[0], 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.439f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.902f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
			if (Game.GameTime > bgtimer[0])
			{
				bgset[0]++;
				bgtimer[0] = Game.GameTime + 500;
			}
			if (bgset[0] > 1)
			{
				BGSwitch[0] = 1;
				bgtimer[0] = Game.GameTime + 500;
			}
			break;
		case 1:
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Decor1", "techaration_" + bgset[0], 0.5f, 0.5f, 79f / 120f, 47f / 54f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.439f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_GridDetails", "griddetails_" + bgset[0], func_10943(0.902f), 0.379f, 1f / 120f, 64f / 135f, 0f, 255, 255, 255, 255, 0);
			if (Game.GameTime > bgtimer[0])
			{
				bgset[0]++;
				bgtimer[0] = Game.GameTime + 500;
			}
			if (bgset[0] > 3)
			{
				bgset[0] = 0;
				BGSwitch[0] = 0;
			}
			break;
		}
		if (BGSwitch[1] == 0)
		{
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disc_a" + bgset[1], func_10943(0.983f), 0.669f, 5f / 96f, 5f / 54f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disc_b" + bgset[1], func_10943(0.983f), 0.669f, 5f / 96f, 5f / 54f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disc_c" + bgset[1], func_10943(0.983f), 0.669f, 5f / 96f, 5f / 54f, 0f, 255, 255, 255, 255, 0);
			if (Game.GameTime > bgtimer[1])
			{
				bgset[1]++;
				bgtimer[1] = Game.GameTime + 500;
			}
			if (bgset[1] > 2)
			{
				bgset[1] = 0;
				bgtimer[1] = Game.GameTime + 500;
			}
		}
		if (MoveLR == 1 && MoveUD == 1)
		{
			currentlySelectedTile = 1;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 1)
		{
			currentlySelectedTile = 2;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.306f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 1 && MoveUD == 2)
		{
			currentlySelectedTile = 3;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 2)
		{
			currentlySelectedTile = 4;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.439f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 1 && MoveUD == 3)
		{
			currentlySelectedTile = 5;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 3)
		{
			currentlySelectedTile = 6;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.572f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 1 && MoveUD == 4)
		{
			currentlySelectedTile = 7;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.105f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		if (MoveLR == 2 && MoveUD == 4)
		{
			currentlySelectedTile = 8;
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "selectorframe", func_10943(0.239f), 0.706f, 3f / 32f, 1f / 6f, 0f, 255, 255, 255, 255, 0);
		}
		int num = PrintChoice[0] - 1;
		for (int i = 1; i <= 8; i++)
		{
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Print" + num, "fp" + PrintChoice[0] + "_" + i, func_10943(0.674f), 0.379f, 5f / 24f, 64f / 135f, 0f, 255, 255, 255, fcalpha, 0);
		}
		int j = 1;
		float uParam = 0f;
		float uParam2 = 0f;
		for (; j <= 8; j++)
		{
			int num2 = (SelectedTiles.Contains(RandomSpots[j]) ? 255 : 125);
			func_10961(RandomSpots[j], out uParam, out uParam2);
			Function.Call(Hash.DRAW_SPRITE, $"MPFClone_Print{num}", $"fp{PrintChoice[0]}_comp_{j}", func_10943(uParam), uParam2, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, num2, 0);
		}
		Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decyphered_selector", func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
		Function.Call(Hash.DRAW_SPRITE, "mphackinggame", "loading_window", 0.5f, 0.5f, 0.25f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
		if (PrintsAllowed == 1)
		{
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
		}
		if (PrintsAllowed == 2)
		{
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[1], func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
		}
		if (PrintsAllowed == 3)
		{
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[1], func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[2], func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "disabled_signal", func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
		}
		if (PrintsAllowed == 4)
		{
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[0], func_10943(0.536f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[1], func_10943(0.662f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[2], func_10943(0.782f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
			Function.Call(Hash.DRAW_SPRITE, "MPFClone_Common", "decypher_" + PrintChoice[3], func_10943(0.905f), 0.832f, 1f / 15f, 16f / 135f, 0f, 255, 255, 255, 255, 0);
		}
	}

	public static void HELP()
	{
		Scaleform scaleform = new Scaleform("instructional_buttons");
		scaleform.CallFunction("CLEAR_ALL");
		scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
		scaleform.CallFunction("CREATE_CONTAINER");
		if (SelectedTiles.Count == 4)
		{
			scaleform.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 45, 0), "Abort Hack (Hold)");
			scaleform.CallFunction("SET_DATA_SLOT", 1, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 201, 0), "Select");
			scaleform.CallFunction("SET_DATA_SLOT", 2, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 51, 0), "Run Check");
			scaleform.CallFunction("SET_DATA_SLOT", 3, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 175, 0), "");
			scaleform.CallFunction("SET_DATA_SLOT", 4, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 174, 0), "");
			scaleform.CallFunction("SET_DATA_SLOT", 5, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 173, 0), "");
			scaleform.CallFunction("SET_DATA_SLOT", 6, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 172, 0), "Move Selector");
		}
		else
		{
			scaleform.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 45, 0), "Abort Hack (Hold)");
			scaleform.CallFunction("SET_DATA_SLOT", 1, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 201, 0), "Select");
			scaleform.CallFunction("SET_DATA_SLOT", 2, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 175, 0), "");
			scaleform.CallFunction("SET_DATA_SLOT", 3, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 174, 0), "");
			scaleform.CallFunction("SET_DATA_SLOT", 4, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 173, 0), "");
			scaleform.CallFunction("SET_DATA_SLOT", 5, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 172, 0), "Move Selector");
		}
		scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
		scaleform.Render2D();
	}

	public static void func_10998(out string sParam0, out int iParam1)
	{
		sParam0 = "Numbers_";
		iParam1 = 0;
		iParam1++;
		if (iParam1 > 9)
		{
			iParam1 = 9;
		}
		else if (iParam1 < 0)
		{
			iParam1 = 0;
		}
		else
		{
			iParam1 = iParam1;
		}
	}

	public static void func_687()
	{
		Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
		Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
		if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
		{
			Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
		}
	}
}
