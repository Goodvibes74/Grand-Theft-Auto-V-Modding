using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;
using LemonUI.Scaleform;

namespace CruelMastersOnlineOffline;

public class CruelMastersOnlineOffline : Script
{
	public static ScriptSettings Config;

	public static bool DEBUG = false;

	public static int TeleTimer;

	public static int TeleSwitch;

	public static int lastHelpTime = 0;

	public static int helpInterval = 5000;

	public static TextElement myUIText;

	public static bool ContinueCOO = false;

	public static string Player_Name = Function.Call<string>(Hash.GET_PLAYER_NAME, Function.Call<int>(Hash.PLAYER_ID));

	public static int handle;

	public static bool NoCopsOnMission = false;

	public static bool ManualMaxWantedLevel = false;

	public static bool FuckOffCivilians = false;

	public static bool RadioAllowed = true;

	public static bool LoadMPData = true;

	public static bool OnMission = false;

	public static bool IsFreemodeMale = false;

	public static bool IsFreemodeFemale = false;

	public static int TestSwitch = 0;

	public static Vector3 prevpos = Game.Player.Character.Position;

	public static float prevhead = Game.Player.Character.Heading;

	private int test = 0;

	public static Ped CutsceneExtra1;

	public static Ped CutsceneExtra2;

	public static Ped CutsceneExtra3;

	public static Ped CutsceneExtra4;

	public static Ped CutsceneExtra5;

	public static Ped CutsceneExtra6;

	public static Ped CutsceneExtra7;

	public static Ped CutsceneExtra8;

	public static Ped CutsceneExtra9;

	public static Ped CutsceneExtra10;

	public static Prop Container;

	public static Prop ContainerColl;

	public static Prop Lock;

	public static Prop FakeCutsceneProp1;

	public static Prop FakeCutsceneProp2;

	public static Prop FakeCutsceneProp3;

	public static Prop FakeCutsceneProp4;

	public static Prop FakeCutsceneProp5;

	public static Prop FakeCutsceneProp6;

	public static Prop FakeCutsceneProp7;

	public static Prop FakeCutsceneProp8;

	public static Prop FakeCutsceneProp9;

	public static Prop FakeCutsceneProp10;

	public static Blip missionBlip;

	public static Blip ImportantStoryBlip;

	public static Camera CutsceneCam;

	public static Camera CutsceneCam2;

	public static Camera CutsceneCam3;

	public static Camera CutsceneCam4;

	public static Camera MenuCam;

	public static int Menu_Switch = 0;

	public static int checkpoint = -1;

	public static int StorySwitch = 0;

	public static int currentselection;

	public static int getcurrentselection;

	public static int MouseCheck;

	public static int getcurrentselection2;

	public static int getcurrentselection3;

	public static int GrinderSwitch = 0;

	public static int TestCutsceneAnim;

	public static int TestCutsceneAnim2;

	public static int TestCutsceneAnim3;

	public static int TestCutsceneAnim4;

	public static int TestCutsceneAnim5;

	public static int TestCutsceneAnim6;

	public static int SoundID;

	public static int SoundID2;

	public static int SoundID3;

	public static int SoundID4;

	public static int SoundID5;

	public static int SoundID6;

	public static int ScaleID;

	public static int ScaleID2;

	public static int ScaleID3;

	public static int ScaleID4;

	public static int ScaleID5;

	public static int ScaleID6;

	public static int RenderID;

	public static int RenderID2;

	public static int RenderID3;

	public static int RenderID4;

	public static int RenderID5;

	public static int RenderID6;

	public static int PTFXID;

	public static int PTFXID2;

	public static int PTFXID3;

	public static int PTFXID4;

	public static int PTFXID5;

	public static int PTFXID6;

	public static int LoadScreen;

	public static int FullLoadTime;

	public static int LoadTime;

	public static bool Loading;

	public static float fVar0 = 0f;

	public static float fVar1 = 0f;

	public static float fVar2 = 0f;

	public static int fVar3 = 0;

	public static int GuardAlertCountdown = -1;

	public static float Potential_Cut = 0f;

	public static Scaleform ContactText = new Scaleform("MP_MISSION_NAME_FREEMODE");

	public static bool doorunlocked = false;

	public static bool OwnsGrinder = false;

	public static bool ALERTED = false;

	public static Vehicle PlayerVehicle;

	public static Vehicle Manchez;

	public static ObjectPool MenuPool = new ObjectPool();

	public static NativeMenu CharCreator;

	public static NativeMenu MainMenu;

	public static int MPHairColor = 0;

	public static int MPEyeColor = 0;

	public static int MPMakeupColor = 0;

	public static int MPLipstickColor = 0;

	public static int MPGender = 0;

	public static int MPMask = 0;

	public static int MPMaskVar = 0;

	public static int PosSaveTimer = 0;

	public static float PreviousPosX = 0f;

	public static float PreviousPosY = 0f;

	public static float PreviousPosZ = 0f;

	public static bool ReditingCharacter = false;

	public static List<string> CutscenePed1Comp = new List<string>
	{
		"0_0_0", "1_0_0", "2_0_0", "3_0_0", "4_0_0", "5_0_0", "6_0_0", "7_0_0", "8_0_0", "9_0_0",
		"10_0_0", "11_0_0"
	};

	public static List<string> CutscenePed2Comp = new List<string>
	{
		"0_0_0", "1_0_0", "2_0_0", "3_0_0", "4_0_0", "5_0_0", "6_0_0", "7_0_0", "8_0_0", "9_0_0",
		"10_0_0", "11_0_0"
	};

	public static List<string> CutscenePed3Comp = new List<string>
	{
		"0_0_0", "1_0_0", "2_0_0", "3_0_0", "4_0_0", "5_0_0", "6_0_0", "7_0_0", "8_0_0", "9_0_0",
		"10_0_0", "11_0_0"
	};

	public static List<string> CutscenePed4Comp = new List<string>
	{
		"0_0_0", "1_0_0", "2_0_0", "3_0_0", "4_0_0", "5_0_0", "6_0_0", "7_0_0", "8_0_0", "9_0_0",
		"10_0_0", "11_0_0"
	};

	public static List<string> CutscenePed5Comp = new List<string>
	{
		"0_0_0", "1_0_0", "2_0_0", "3_0_0", "4_0_0", "5_0_0", "6_0_0", "7_0_0", "8_0_0", "9_0_0",
		"10_0_0", "11_0_0"
	};

	public static List<string> CutscenePed6Comp = new List<string>
	{
		"0_0_0", "1_0_0", "2_0_0", "3_0_0", "4_0_0", "5_0_0", "6_0_0", "7_0_0", "8_0_0", "9_0_0",
		"10_0_0", "11_0_0"
	};

	public static List<string> LoadAllIPLS = new List<string>
	{
		"xm_hatch_01_cutscene", "xm_hatch_02_cutscene", "xm_hatch_03_cutscene", "xm_hatch_04_cutscene", "xm_hatch_05_cutscene", "xm_hatch_06_cutscene", "xm_hatch_07_cutscene", "xm_hatch_08_cutscene", "xm_hatch_09_cutscene", "xm_hatch_10_cutscene",
		"xm_hatch_closed", "xm_hatches_terrain", "xm_hatches_terrain_lod", "sm_smugdlc_interior_placement", "xm_mpchristmasadditions", "xm_siloentranceclosed_x17", "id2_14_during1", "shr_int", "xm_x17dlc_int_placement_interior_8_x17dlc_int_sub_milo_", "bkr_bi_hw1_13_int",
		"bkr_bi_id1_23_door", "vw_dlc_casino_door", "xm_x17dlc_int_placement_interior_4_x17dlc_int_facility_milo_", "xm_x17dlc_int_placement_interior_5_x17dlc_int_facility2_milo_", "xm_x17dlc_int_placement_interior_0_x17dlc_int_base_ent_milo_", "xm_x17dlc_int_placement_interior_1_x17dlc_int_base_loop_milo_", "xm_x17dlc_int_placement_interior_2_x17dlc_int_bse_tun_milo_", "xm_x17dlc_int_placement_interior_3_x17dlc_int_base_milo_", "xm_x17dlc_int_placement_interior_6_x17dlc_int_silo_01_milo_", "xm_x17dlc_int_placement_interior_7_x17dlc_int_silo_02_milo_",
		"xm_x17dlc_int_placement_interior_10_x17dlc_int_tun_straight_milo_", "xm_x17dlc_int_placement_interior_11_x17dlc_int_tun_slope_flat_milo_", "xm_x17dlc_int_placement_interior_12_x17dlc_int_tun_flat_slope_milo_", "xm_x17dlc_int_placement_interior_13_x17dlc_int_tun_30d_r_milo_", "xm_x17dlc_int_placement_interior_14_x17dlc_int_tun_30d_l_milo_", "xm_x17dlc_int_placement_interior_15_x17dlc_int_tun_straight_milo_", "xm_x17dlc_int_placement_interior_16_x17dlc_int_tun_straight_milo_", "xm_x17dlc_int_placement_interior_17_x17dlc_int_tun_slope_flat_milo_", "xm_x17dlc_int_placement_interior_18_x17dlc_int_tun_slope_flat_milo_", "xm_x17dlc_int_placement_interior_19_x17dlc_int_tun_flat_slope_milo_",
		"xm_x17dlc_int_placement_interior_20_x17dlc_int_tun_flat_slope_milo_", "xm_x17dlc_int_placement_interior_21_x17dlc_int_tun_30d_r_milo_", "xm_x17dlc_int_placement_interior_22_x17dlc_int_tun_30d_r_milo_", "xm_x17dlc_int_placement_interior_23_x17dlc_int_tun_30d_r_milo_", "xm_x17dlc_int_placement_interior_24_x17dlc_int_tun_30d_r_milo_", "xm_x17dlc_int_placement_interior_25_x17dlc_int_tun_30d_l_milo_", "xm_x17dlc_int_placement_interior_26_x17dlc_int_tun_30d_l_milo_", "xm_x17dlc_int_placement_interior_27_x17dlc_int_tun_30d_l_milo_", "xm_x17dlc_int_placement_interior_28_x17dlc_int_tun_30d_l_milo_", "xm_x17dlc_int_placement_interior_29_x17dlc_int_tun_30d_l_milo_",
		"xm_x17dlc_int_placement_interior_34_x17dlc_int_lab_milo_", "xm_x17dlc_int_placement_interior_35_x17dlc_int_tun_entry_milo_", "xm_x17dlc_int_placement_strm_0", "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_", "xm_prop_x17_tem_control_01", "SP1_10_real_interior", "post_hiest_unload", "facelobby", "FIBlobby", "Coroner_Int_on",
		"h4_ch2_mansion_final", "hei_ch1_06e_strm_1", "ex_exec_warehouse_placement_interior_1_int_warehouse_s_dlc_milo", "FINBANK", "h4_islandairstrip_doorsopen", "v_tunnel_hole", "plane_crash_trench", "hei_dlc_casino_door", "vw_casino_main", "vw_casino_carpark",
		"vw_casino_garage", "vw_casino_penthouse", "hei_dlc_casino_aircon", "hei_dlc_casino_aircon_lod", "hei_dlc_casino_door", "hei_dlc_casino_door_lod", "hei_dlc_vw_roofdoors_locked", "hei_dlc_windows_casino", "hei_dlc_windows_casino_lod", "ch_chint09_closed",
		"bkr_biker_interior_placement_interior_0_biker_dlc_int_01_milo", "bkr_biker_interior_placement_interior_1_biker_dlc_int_02_milo", "h4_island_padlock_props", "h4_BoatBlockers", "h4_Mansion_Gate_Closed", "xm3_collision_fixes", "xm3_cutscene_doors", "xm3_doc_sign", "xm3_doc_sign_lod", "xm3_garage_fix",
		"xm3_garage_fix_lod", "xm3_security_fix", "xm3_stash_cams", "xm3_sum2_fix", "xm3_sum2_fix_lod", "xm3_warehouse", "xm3_warehouse_grnd", "xm3_warehouse_lod"
	};

	public static List<string> RemoveOnlyIPLS = new List<string>
	{
		"xm_bunkerentrance_door", "chemgrill_grp1", "id2_14_pre_no_int", "id2_14_post_no_int", "id2_14_on_fire", "id2_14_during_door", "id2_14_during2", "burnt_switch_off", "id2_14_during1", "fakeint",
		"fakeint_boards", "shr_int", "carshowroom_boarded", "carshowroom_broken", "SP1_10_fake_interior", "bh1_16_refurb", "jewel2fake", "FIBlobbyfake", "h4_islandairstrip_doorsclosed", "hei_po1_07_strm_2",
		"v_tunnel_hole_swap", "dt1_03_shutter", "dt1_03_gr_closed", "atriumglcut", "atriumglstatic", "atriumglmission", "FBI_repair", "FBI_colPLUG", "DT1_05_rubble", "DT1_05_HC_REMOVE",
		"DT1_05_HC_REQ", "dt1_05_slod", "dt1_05_damage_slod", "dt1_05_build1_damage_lod", "dt1_05_build1_damage", "dt1_05_build1_h", "DT1_05_REQUEST", "FBI_repair_lod", "dt1_05_build1_h", "dt1_05_build1_damage",
		"dt1_05_build1_damage_lod", "h4_island_padlock_props", "h4_islandxdock_water_hatch", "h4_islandx_barrack_hatch", "h4_BoatBlockers", "h4_underwater_gate_closed", "h4_Mansion_Gate_Broken", "h4_Mansion_Gate_Closed", "hei_ch1_06e_strm_2", "hei_ch1_06e_strm_1"
	};

	private static byte[] _strBufferForStringToCoTaskMemUTF8 = new byte[100];

	public static IntPtr CellEmailBcon => StringToCoTaskMemUTF8("CELL_EMAIL_BCON");

	public static string LoadTexureDict(string dict)
	{
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, dict))
		{
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, dict);
			Script.Yield();
		}
		return dict;
	}

	public static string LoadCutsceneWithFlag(string cutscene, int playbackflag)
	{
		while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED, cutscene))
		{
			Function.Call(Hash.REQUEST_CUTSCENE_WITH_PLAYBACK_LIST, cutscene, playbackflag, 8);
			Script.Yield();
		}
		return cutscene;
	}

	public static string LoadCutscene(string cutscene)
	{
		while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED, cutscene))
		{
			Function.Call(Hash.REQUEST_CUTSCENE, cutscene, 8);
			Script.Yield();
		}
		return cutscene;
	}

	// Patched: the original waited forever when a dictionary is missing from the game files, which made SHVDN
	// kill the whole script as "blocking". Now it gives up after 5 s and writes the name to
	// scripts\CruelMastersOnlineOffline.log so the missing dictionary can be found.
	public static void LogLine(string message)
	{
		try
		{
			File.AppendAllText(@"scripts\CruelMastersOnlineOffline.log", DateTime.Now.ToString("HH:mm:ss") + " " + message + Environment.NewLine);
		}
		catch (IOException)
		{
		}
	}

	public static string LoadDict(string dict)
	{
		// Real clock, not Game.GameTime: game time stops while the game is stalled, so it cannot time out a stall.
		System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
		bool alreadyLoaded = Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, dict);
		if (!alreadyLoaded)
		{
			LogLine("LoadDict: requesting \"" + dict + "\"");
		}
		while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, dict))
		{
			Function.Call(Hash.REQUEST_ANIM_DICT, dict);
			Script.Yield();
			if (watch.ElapsedMilliseconds > 5000)
			{
				LogLine("LoadDict: \"" + dict + "\" did not load in 5 s, continuing without it");
				return dict;
			}
		}
		if (!alreadyLoaded)
		{
			LogLine("LoadDict: \"" + dict + "\" loaded in " + watch.ElapsedMilliseconds + " ms");
		}
		return dict;
	}

	public static string LoadStream(string name, string dict)
	{
		while (!Function.Call<bool>(Hash.LOAD_STREAM, name, dict))
		{
			Function.Call(Hash.LOAD_STREAM, name, dict);
			Script.Yield();
		}
		return dict;
	}

	public static int LoadStream(string name, int dict)
	{
		while (!Function.Call<bool>(Hash.LOAD_STREAM, name, dict))
		{
			Function.Call(Hash.LOAD_STREAM, name, dict);
			Script.Yield();
		}
		return dict;
	}

	public static void SetPedOutfitCutscene(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_1"))
		{
			CutscenePed1Comp[0] = "0_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 0) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 0);
			CutscenePed1Comp[1] = "1_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 1) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 1);
			CutscenePed1Comp[2] = "2_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 2) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 2);
			CutscenePed1Comp[3] = "3_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 3) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 3);
			CutscenePed1Comp[4] = "4_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 4) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 4);
			CutscenePed1Comp[5] = "5_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 5) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 5);
			CutscenePed1Comp[6] = "6_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 6) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 6);
			CutscenePed1Comp[7] = "7_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 7) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 7);
			CutscenePed1Comp[8] = "8_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 8) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 8);
			CutscenePed1Comp[9] = "9_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 9) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 9);
			CutscenePed1Comp[10] = "10_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 10) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 10);
			CutscenePed1Comp[11] = "11_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 11) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 11);
		}
	}

	public static void GetPedOutfitCutscene(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_1"))
		{
			string[] array = CutscenePed1Comp[0].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[1].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[2].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[3].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[4].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[5].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[6].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[7].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[8].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[9].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[10].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed1Comp[11].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, int.Parse(array[1]), int.Parse(array[2]), 1);
		}
	}

	public static void SetPedOutfitCutscene_MP2(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_2"))
		{
			CutscenePed2Comp[0] = "0_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 0) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 0);
			CutscenePed2Comp[1] = "1_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 1) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 1);
			CutscenePed2Comp[2] = "2_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 2) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 2);
			CutscenePed2Comp[3] = "3_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 3) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 3);
			CutscenePed2Comp[4] = "4_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 4) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 4);
			CutscenePed2Comp[5] = "5_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 5) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 5);
			CutscenePed2Comp[6] = "6_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 6) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 6);
			CutscenePed2Comp[7] = "7_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 7) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 7);
			CutscenePed2Comp[8] = "8_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 8) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 8);
			CutscenePed2Comp[9] = "9_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 9) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 9);
			CutscenePed2Comp[10] = "10_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 10) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 10);
			CutscenePed2Comp[11] = "11_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 11) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 11);
		}
	}

	public static void GetPedOutfitCutscene_MP2(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_2"))
		{
			string[] array = CutscenePed2Comp[0].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[1].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[2].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[3].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[4].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[5].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[6].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[7].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[8].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[9].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[10].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed2Comp[11].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, int.Parse(array[1]), int.Parse(array[2]), 1);
		}
	}

	public static void SetPedOutfitCutscene_MP3(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_3"))
		{
			CutscenePed3Comp[0] = "0_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 0) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 0);
			CutscenePed3Comp[1] = "1_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 1) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 1);
			CutscenePed3Comp[2] = "2_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 2) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 2);
			CutscenePed3Comp[3] = "3_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 3) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 3);
			CutscenePed3Comp[4] = "4_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 4) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 4);
			CutscenePed3Comp[5] = "5_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 5) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 5);
			CutscenePed3Comp[6] = "6_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 6) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 6);
			CutscenePed3Comp[7] = "7_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 7) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 7);
			CutscenePed3Comp[8] = "8_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 8) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 8);
			CutscenePed3Comp[9] = "9_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 9) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 9);
			CutscenePed3Comp[10] = "10_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 10) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 10);
			CutscenePed3Comp[11] = "11_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 11) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 11);
		}
	}

	public static void GetPedOutfitCutscene_MP3(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_3"))
		{
			string[] array = CutscenePed3Comp[0].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[1].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[2].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[3].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[4].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[5].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[6].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[7].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[8].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[9].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[10].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed3Comp[11].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, int.Parse(array[1]), int.Parse(array[2]), 1);
		}
	}

	public static void SetPedOutfitCutscene_MP4(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_4"))
		{
			CutscenePed4Comp[0] = "0_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 0) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 0);
			CutscenePed4Comp[1] = "1_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 1) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 1);
			CutscenePed4Comp[2] = "2_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 2) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 2);
			CutscenePed4Comp[3] = "3_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 3) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 3);
			CutscenePed4Comp[4] = "4_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 4) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 4);
			CutscenePed4Comp[5] = "5_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 5) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 5);
			CutscenePed4Comp[6] = "6_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 6) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 6);
			CutscenePed4Comp[7] = "7_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 7) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 7);
			CutscenePed4Comp[8] = "8_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 8) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 8);
			CutscenePed4Comp[9] = "9_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 9) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 9);
			CutscenePed4Comp[10] = "10_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 10) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 10);
			CutscenePed4Comp[11] = "11_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 11) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 11);
		}
	}

	public static void GetPedOutfitCutscene_MP4(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_4"))
		{
			string[] array = CutscenePed4Comp[0].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[1].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[2].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[3].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[4].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[5].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[6].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[7].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[8].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[9].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[10].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed4Comp[11].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, int.Parse(array[1]), int.Parse(array[2]), 1);
		}
	}

	public static void SetPedOutfitCutscene_MP5(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_5"))
		{
			CutscenePed5Comp[0] = "0_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 0) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 0);
			CutscenePed5Comp[1] = "1_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 1) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 1);
			CutscenePed5Comp[2] = "2_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 2) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 2);
			CutscenePed5Comp[3] = "3_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 3) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 3);
			CutscenePed5Comp[4] = "4_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 4) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 4);
			CutscenePed5Comp[5] = "5_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 5) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 5);
			CutscenePed5Comp[6] = "6_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 6) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 6);
			CutscenePed5Comp[7] = "7_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 7) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 7);
			CutscenePed5Comp[8] = "8_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 8) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 8);
			CutscenePed5Comp[9] = "9_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 9) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 9);
			CutscenePed5Comp[10] = "10_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 10) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 10);
			CutscenePed5Comp[11] = "11_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 11) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 11);
		}
	}

	public static void GetPedOutfitCutscene_MP5(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_5"))
		{
			string[] array = CutscenePed5Comp[0].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[1].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[2].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[3].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[4].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[5].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[6].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[7].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[8].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[9].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[10].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed5Comp[11].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, int.Parse(array[1]), int.Parse(array[2]), 1);
		}
	}

	public static void SetPedOutfitCutscene_MP6(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_6"))
		{
			CutscenePed6Comp[0] = "0_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 0) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 0);
			CutscenePed6Comp[1] = "1_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 1) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 1);
			CutscenePed6Comp[2] = "2_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 2) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 2);
			CutscenePed6Comp[3] = "3_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 3) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 3);
			CutscenePed6Comp[4] = "4_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 4) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 4);
			CutscenePed6Comp[5] = "5_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 5) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 5);
			CutscenePed6Comp[6] = "6_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 6) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 6);
			CutscenePed6Comp[7] = "7_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 7) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 7);
			CutscenePed6Comp[8] = "8_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 8) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 8);
			CutscenePed6Comp[9] = "9_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 9) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 9);
			CutscenePed6Comp[10] = "10_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 10) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 10);
			CutscenePed6Comp[11] = "11_" + Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 11) + "_" + Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 11);
		}
	}

	public static void GetPedOutfitCutscene_MP6(string MP, Ped NonCutscene)
	{
		if (MP.Equals("MP_6"))
		{
			string[] array = CutscenePed6Comp[0].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[1].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[2].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[3].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[4].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[5].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[6].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[7].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[8].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[9].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[10].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, int.Parse(array[1]), int.Parse(array[2]), 1);
			array = CutscenePed6Comp[11].Split('_');
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, int.Parse(array[1]), int.Parse(array[2]), 1);
		}
	}

	public CruelMastersOnlineOffline()
	{
		Tick += onTick;
		LoadIniFile("scripts\\CruelMastersOnlineOffline.ini");
		StorySwitch = Config.GetValue("Main", "Progression", StorySwitch);
		Aborted += onShutdown;
		KeyDown += onKeyDown;
		LogLine("constructor: removing and requesting IPLs");
		foreach (string removeOnlyIPL in RemoveOnlyIPLS)
		{
			Function.Call(Hash.REMOVE_IPL, removeOnlyIPL);
		}
		foreach (string loadAllIPL in LoadAllIPLS)
		{
			Function.Call(Hash.REMOVE_IPL, loadAllIPL);
			Function.Call(Hash.REQUEST_IPL, loadAllIPL);
		}
		LogLine("constructor: IPLs done");
		SETUP_CHAR_CREATOR_MENU();
		SETUP_MAIN_MENU();
	}

	public static void LoadIniFile(string iniName)
	{
		Config = ScriptSettings.Load(iniName);
		int i = 1;
		float num = 0f;
		for (; i < 20; i++)
		{
			PedOutfit.FaceFeaturePart[i] = Config.GetValue("Character", $"Face Feature {i}", PedOutfit.FaceFeaturePart[i]);
		}
		PedOutfit.Data.ShapeFirst = Config.GetValue("Character", "Head Blend Data 1", PedOutfit.Data.ShapeFirst);
		PedOutfit.Data.ShapeSecond = Config.GetValue("Character", "Head Blend Data 2", PedOutfit.Data.ShapeSecond);
		PedOutfit.Data.SkinFirst = Config.GetValue("Character", "Head Blend Data 3", PedOutfit.Data.SkinFirst);
		PedOutfit.HairPart[0] = Config.GetValue("Character", "Hair", PedOutfit.HairPart[0]);
		MPHairColor = Config.GetValue("Character", "Hair Color", MPHairColor);
		MPEyeColor = Config.GetValue("Character", "Eye Color", MPEyeColor);
		MPMakeupColor = Config.GetValue("Character", "Makeup Color", MPMakeupColor);
		MPLipstickColor = Config.GetValue("Character", "Lipstick Color", MPLipstickColor);
		MPMask = Config.GetValue("Character", "Mask", MPMask);
		MPMaskVar = Config.GetValue("Character", "Mask Variation", MPMaskVar);
		for (i = 0; i < 10; i++)
		{
			PedOutfit.OverlayPart[i] = Config.GetValue("Character", $"Overlay {i}", PedOutfit.OverlayPart[i]);
			PedOutfit.OpacityPart[i] = Config.GetValue("Character", $"Overlay Opacity {i}", PedOutfit.OpacityPart[i]);
		}
		for (i = 0; i < PedOutfit.OutfitPart.Length; i++)
		{
			PedOutfit.OutfitPart[i] = Config.GetValue("Character", $"Outfit {i}", PedOutfit.OutfitPart[i]);
			PedOutfit.OutfitPart2[i] = Config.GetValue("Character", $"Outfit Variation {i}", PedOutfit.OutfitPart2[i]);
		}
		for (i = 0; i < PedOutfit.OutfitPart3.Length; i++)
		{
			PedOutfit.OutfitPart3[i] = Config.GetValue("Character", $"Accessory {i}", PedOutfit.OutfitPart3[i]);
			PedOutfit.OutfitPart4[i] = Config.GetValue("Character", $"Accessory Variation {i}", PedOutfit.OutfitPart4[i]);
		}
		MPGender = Config.GetValue("Character", "Gender", MPGender);
		MPRank.PlayerLevel = Config.GetValue("Rank", "Player Level", MPRank.PlayerLevel);
		MPRank.CurrentXP = Config.GetValue("Rank", "Player RP", MPRank.CurrentXP);
		MPRank.PreviousXP = Config.GetValue("Rank", "Player Previous RP", MPRank.PreviousXP);
		MPCash.Cash = Config.GetValue("Cash", "Player Cash", MPCash.Cash);
		MPCash.PreviousCash = Config.GetValue("Cash", "Player Previous Cash", MPCash.PreviousCash);
		MPCash.Bank = Config.GetValue("Cash", "Player Bank", MPCash.Bank);
		MPCash.PreviousBank = Config.GetValue("Cash", "Player Previous Bank", MPCash.PreviousBank);
	}

	public static void GET_MAIN_CHARACTER()
	{
		LoadIniFile("scripts\\CruelMastersOnlineOffline.ini");
		Script.Wait(50);
		Game.Player.ChangeModel(RequestModel(PedHash.Michael));
		Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
		Script.Wait(500);
		if (MPGender == 0)
		{
			Game.Player.ChangeModel(RequestModel(PedHash.FreemodeMale01));
		}
		else
		{
			Game.Player.ChangeModel(RequestModel(PedHash.FreemodeFemale01));
		}
		Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
		Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, PedOutfit.Data.ShapeFirst, PedOutfit.Data.ShapeSecond, 0, PedOutfit.Data.SkinFirst, 0, 0, 0f, 0f, 0f, false);
		for (int i = 1; i < 20; i++)
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, i, PedOutfit.FaceFeaturePart[i]);
		}
		for (int i = 0; i < 10; i++)
		{
			if (PedOutfit.OverlayPart[i] != -1)
			{
				Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, i, PedOutfit.OverlayPart[i], PedOutfit.OpacityPart[i]);
			}
			if (i != 4 || i != 5 || i != 8)
			{
				Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, i, 1, MPHairColor, 0);
			}
		}
		Function.Call(Hash.SET_PED_HAIR_TINT, Game.Player.Character, MPHairColor, 0);
		Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, Game.Player.Character, MPEyeColor);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 4, 1, MPMakeupColor, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 5, 1, MPMakeupColor, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 8, 1, MPLipstickColor, 0);
		PedOutfit pedOutfit = new PedOutfit
		{
			Components = new List<PedOutfit.OutfitComponent>(),
			Props = new List<PedOutfit.OutfitProp>()
		};
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_HAIR,
			DrawableId = PedOutfit.HairPart[0],
			TextureId = 0,
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
			DrawableId = PedOutfit.OutfitPart[3],
			TextureId = PedOutfit.OutfitPart2[3],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
			DrawableId = PedOutfit.OutfitPart[4],
			TextureId = PedOutfit.OutfitPart2[4],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
			DrawableId = PedOutfit.OutfitPart[5],
			TextureId = PedOutfit.OutfitPart2[5],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
			DrawableId = PedOutfit.OutfitPart[6],
			TextureId = PedOutfit.OutfitPart2[6],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
			DrawableId = PedOutfit.OutfitPart[7],
			TextureId = PedOutfit.OutfitPart2[7],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
			DrawableId = PedOutfit.OutfitPart[8],
			TextureId = PedOutfit.OutfitPart2[8],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
			DrawableId = PedOutfit.OutfitPart[9],
			TextureId = PedOutfit.OutfitPart2[9],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
			DrawableId = PedOutfit.OutfitPart[10],
			TextureId = PedOutfit.OutfitPart2[10],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
			DrawableId = PedOutfit.OutfitPart[11],
			TextureId = PedOutfit.OutfitPart2[11],
			PaletteId = 0
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
			DrawableId = PedOutfit.OutfitPart3[0],
			TextureId = PedOutfit.OutfitPart4[0]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = PedOutfit.PedPropsData.PED_PROP_GLASSES,
			DrawableId = PedOutfit.OutfitPart3[1],
			TextureId = PedOutfit.OutfitPart4[1]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = PedOutfit.PedPropsData.PED_PROP_EARS,
			DrawableId = PedOutfit.OutfitPart3[2],
			TextureId = PedOutfit.OutfitPart4[2]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = (PedOutfit.PedPropsData)6,
			DrawableId = PedOutfit.OutfitPart3[3],
			TextureId = PedOutfit.OutfitPart4[3]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = (PedOutfit.PedPropsData)7,
			DrawableId = PedOutfit.OutfitPart3[4],
			TextureId = PedOutfit.OutfitPart4[4]
		});
		pedOutfit.Equip(Game.Player.Character);
		if (MPMask == 0)
		{
			PedOutfit.MaskOFF(Game.Player.Character);
		}
		else
		{
			PedOutfit.MaskON(Game.Player.Character, MPMask, MPMaskVar);
		}
		Function.Call(Hash.SET_ABILITY_BAR_VISIBILITY, false);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 116, 45, 110, 185, 255);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 143, 45, 110, 185, 255);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 144, 45, 110, 185, 255);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 145, 45, 110, 185, 255);
		MPSaveData mPSaveData = MPSaveData.GET_MAIN_SAVE_DATA("Style Save Data");
		if (Game.Player.Character.Gender == Gender.Male)
		{
			switch (mPSaveData.PIStyleSaveDatas[0].PlayerMood)
			{
			case "Normal":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_normal_1");
				break;
			case "Aiming":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_aiming_1");
				break;
			case "Angry":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_angry_1");
				break;
			case "Happy":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_happy_1");
				break;
			case "Injured":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_injured_1");
				break;
			case "Stressed":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_stressed_1");
				break;
			case "Smug":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_smug_1");
				break;
			case "Sulking":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_sulk_1");
				break;
			}
		}
		else
		{
			switch (mPSaveData.PIStyleSaveDatas[0].PlayerMood)
			{
			case "Normal":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_normal_1");
				break;
			case "Aiming":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_aiming_1");
				break;
			case "Angry":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_angry_1");
				break;
			case "Happy":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_happy_1");
				break;
			case "Injured":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_injured_1");
				break;
			case "Stressed":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_stressed_1");
				break;
			case "Smug":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_smug_1");
				break;
			case "Sulking":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_sulk_1");
				break;
			}
		}
		string text = "M";
		if (Game.Player.Character.Gender == Gender.Female)
		{
			text = "F";
		}
		switch (mPSaveData.PIStyleSaveDatas[0].WalkStyle)
		{
		case "Normal":
			Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character, 0.25f);
			break;
		case "Femme":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@FEMME@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@FEMME@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@FEMME@", 0.25f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@FEMME@");
			break;
		case "Gangster":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@GANGSTER@NG"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@GANGSTER@NG");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@GANGSTER@NG", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@GANGSTER@NG");
			break;
		case "Posh":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@POSH@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@POSH@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@POSH@", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@POSH@");
			break;
		case "Tough Guy":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@TOUGH_GUY@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@TOUGH_GUY@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@TOUGH_GUY@", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@TOUGH_GUY@");
			break;
		case "Grooving":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "ANIM@MOVE_" + text + "@GROOVING@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "ANIM@MOVE_" + text + "@GROOVING@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "ANIM@MOVE_" + text + "@GROOVING@", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "ANIM@MOVE_" + text + "@GROOVING@");
			break;
		}
		string autoShowBikeHelm = mPSaveData.PIStyleSaveDatas[0].AutoShowBikeHelm;
		string text2 = autoShowBikeHelm;
		if (!(text2 == "Off"))
		{
			if (text2 == "On")
			{
				Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 380, false);
			}
		}
		else
		{
			Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 380, true);
		}
		string autoShowAircraftHelm = mPSaveData.PIStyleSaveDatas[0].AutoShowAircraftHelm;
		string text3 = autoShowAircraftHelm;
		if (!(text3 == "Off"))
		{
			if (text3 == "On")
			{
				Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 381, false);
			}
		}
		else
		{
			Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 381, true);
		}
	}

	public static void GET_MAIN_CHARACTER_WITHOUT_MODEL()
	{
		LoadIniFile("scripts\\CruelMastersOnlineOffline.ini");
		Script.Wait(50);
		Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
		Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, PedOutfit.Data.ShapeFirst, PedOutfit.Data.ShapeSecond, 0, PedOutfit.Data.SkinFirst, 0, 0, 0f, 0f, 0f, false);
		for (int i = 1; i < 20; i++)
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, i, PedOutfit.FaceFeaturePart[i]);
		}
		for (int i = 0; i < 10; i++)
		{
			if (PedOutfit.OverlayPart[i] != -1)
			{
				Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, i, PedOutfit.OverlayPart[i], PedOutfit.OpacityPart[i]);
			}
			if (i != 4 || i != 5 || i != 8)
			{
				Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, i, 1, MPHairColor, 0);
			}
		}
		Function.Call(Hash.SET_PED_HAIR_TINT, Game.Player.Character, MPHairColor, 0);
		Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, Game.Player.Character, MPEyeColor);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 4, 1, MPMakeupColor, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 5, 1, MPMakeupColor, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 8, 1, MPLipstickColor, 0);
		PedOutfit pedOutfit = new PedOutfit
		{
			Components = new List<PedOutfit.OutfitComponent>(),
			Props = new List<PedOutfit.OutfitProp>()
		};
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_HAIR,
			DrawableId = PedOutfit.HairPart[0],
			TextureId = 0,
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
			DrawableId = PedOutfit.OutfitPart[3],
			TextureId = PedOutfit.OutfitPart2[3],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
			DrawableId = PedOutfit.OutfitPart[4],
			TextureId = PedOutfit.OutfitPart2[4],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
			DrawableId = PedOutfit.OutfitPart[5],
			TextureId = PedOutfit.OutfitPart2[5],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
			DrawableId = PedOutfit.OutfitPart[6],
			TextureId = PedOutfit.OutfitPart2[6],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
			DrawableId = PedOutfit.OutfitPart[7],
			TextureId = PedOutfit.OutfitPart2[7],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
			DrawableId = PedOutfit.OutfitPart[8],
			TextureId = PedOutfit.OutfitPart2[8],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
			DrawableId = PedOutfit.OutfitPart[9],
			TextureId = PedOutfit.OutfitPart2[9],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
			DrawableId = PedOutfit.OutfitPart[10],
			TextureId = PedOutfit.OutfitPart2[10],
			PaletteId = 0
		});
		pedOutfit.Components.Add(new PedOutfit.OutfitComponent
		{
			ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
			DrawableId = PedOutfit.OutfitPart[11],
			TextureId = PedOutfit.OutfitPart2[11],
			PaletteId = 0
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
			DrawableId = PedOutfit.OutfitPart3[0],
			TextureId = PedOutfit.OutfitPart4[0]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = PedOutfit.PedPropsData.PED_PROP_GLASSES,
			DrawableId = PedOutfit.OutfitPart3[1],
			TextureId = PedOutfit.OutfitPart4[1]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = PedOutfit.PedPropsData.PED_PROP_EARS,
			DrawableId = PedOutfit.OutfitPart3[2],
			TextureId = PedOutfit.OutfitPart4[2]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = (PedOutfit.PedPropsData)6,
			DrawableId = PedOutfit.OutfitPart3[3],
			TextureId = PedOutfit.OutfitPart4[3]
		});
		pedOutfit.Props.Add(new PedOutfit.OutfitProp
		{
			ComponentId = (PedOutfit.PedPropsData)7,
			DrawableId = PedOutfit.OutfitPart3[4],
			TextureId = PedOutfit.OutfitPart4[4]
		});
		pedOutfit.Equip(Game.Player.Character);
		if (MPMask == 0)
		{
			PedOutfit.MaskOFF(Game.Player.Character);
		}
		else
		{
			PedOutfit.MaskON(Game.Player.Character, MPMask, MPMaskVar);
		}
		Function.Call(Hash.SET_ABILITY_BAR_VISIBILITY, false);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 116, 45, 110, 185, 255);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 143, 45, 110, 185, 255);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 144, 45, 110, 185, 255);
		Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, 145, 45, 110, 185, 255);
		MPSaveData mPSaveData = MPSaveData.GET_MAIN_SAVE_DATA("Style Save Data");
		if (Game.Player.Character.Gender == Gender.Male)
		{
			switch (mPSaveData.PIStyleSaveDatas[0].PlayerMood)
			{
			case "Normal":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_normal_1");
				break;
			case "Aiming":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_aiming_1");
				break;
			case "Angry":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_angry_1");
				break;
			case "Happy":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_happy_1");
				break;
			case "Injured":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_injured_1");
				break;
			case "Stressed":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_stressed_1");
				break;
			case "Smug":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_smug_1");
				break;
			case "Sulking":
				LoadDict("facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_male@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_sulk_1");
				break;
			}
		}
		else
		{
			switch (mPSaveData.PIStyleSaveDatas[0].PlayerMood)
			{
			case "Normal":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_normal_1");
				break;
			case "Aiming":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_aiming_1");
				break;
			case "Angry":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_angry_1");
				break;
			case "Happy":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_happy_1");
				break;
			case "Injured":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_injured_1");
				break;
			case "Stressed":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_stressed_1");
				break;
			case "Smug":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_smug_1");
				break;
			case "Sulking":
				LoadDict("facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_CLIPSET, Game.Player.Character, "facials@gen_female@base");
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_sulk_1");
				break;
			}
		}
		string text = "M";
		if (Game.Player.Character.Gender == Gender.Female)
		{
			text = "F";
		}
		switch (mPSaveData.PIStyleSaveDatas[0].WalkStyle)
		{
		case "Normal":
			Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character, 0.25f);
			break;
		case "Femme":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@FEMME@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@FEMME@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@FEMME@", 0.25f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@FEMME@");
			break;
		case "Gangster":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@GANGSTER@NG"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@GANGSTER@NG");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@GANGSTER@NG", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@GANGSTER@NG");
			break;
		case "Posh":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@POSH@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@POSH@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@POSH@", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@POSH@");
			break;
		case "Tough Guy":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "MOVE_" + text + "@TOUGH_GUY@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "MOVE_" + text + "@TOUGH_GUY@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "MOVE_" + text + "@TOUGH_GUY@", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "MOVE_" + text + "@TOUGH_GUY@");
			break;
		case "Grooving":
			while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "ANIM@MOVE_" + text + "@GROOVING@"))
			{
				Function.Call(Hash.REQUEST_ANIM_SET, "ANIM@MOVE_" + text + "@GROOVING@");
				Script.Wait(0);
			}
			Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "ANIM@MOVE_" + text + "@GROOVING@", 1f);
			Function.Call(Hash.REMOVE_ANIM_SET, "ANIM@MOVE_" + text + "@GROOVING@");
			break;
		}
		string autoShowBikeHelm = mPSaveData.PIStyleSaveDatas[0].AutoShowBikeHelm;
		string text2 = autoShowBikeHelm;
		if (!(text2 == "Off"))
		{
			if (text2 == "On")
			{
				Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 380, false);
			}
		}
		else
		{
			Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 380, true);
		}
		string autoShowAircraftHelm = mPSaveData.PIStyleSaveDatas[0].AutoShowAircraftHelm;
		string text3 = autoShowAircraftHelm;
		if (!(text3 == "Off"))
		{
			if (text3 == "On")
			{
				Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 381, false);
			}
		}
		else
		{
			Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 381, true);
		}
	}

	public static void SETUP_MAIN_MENU()
	{
		MainMenu = new NativeMenu("Online-Offline", "SELECT AN OPTION");
		MainMenu.Banner.Color = Color.Aqua;
		MainMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		MenuPool.Add(MainMenu);
		NativeItem nativeItem = new NativeItem("Start a New Session", "Enter a new Online - Offline Session.");
		MainMenu.Add(nativeItem);
		nativeItem.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_ABILITY_BAR_VISIBILITY, false);
			Function.Call(Hash.SET_MINIMAP_HIDE_FOW, true);
			Function.Call(Hash.SET_INSTANCE_PRIORITY_MODE, true);
			GlobalVariable.Get(4).Write(1);
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "cellphone_controller");
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "respawn_controller");
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "gunclub_shop");
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "clothes_shop_sp");
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "clothes_shop_mp");
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "shop_controller");
			Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 0, true);
			Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 1, true);
			Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 2, true);
			Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 3, true);
			Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 4, true);
			Function.Call(Hash.DISABLE_POLICE_RESTART, 0, true);
			Function.Call(Hash.DISABLE_POLICE_RESTART, 1, true);
			Function.Call(Hash.DISABLE_POLICE_RESTART, 2, true);
			Function.Call(Hash.DISABLE_POLICE_RESTART, 3, true);
			Function.Call(Hash.DISABLE_POLICE_RESTART, 4, true);
			Function.Call(Hash.DISABLE_POLICE_RESTART, 5, true);
			Function.Call(Hash.DISABLE_POLICE_RESTART, 6, true);
			LoadingPrompt.Show("Loading New Session", LoadingSpinnerType.Clockwise1);
			LoadIniFile("scripts\\CruelMastersOnlineOffline.ini");
			Script.Wait(50);
			MainMenu.Visible = !MainMenu.Visible;
			Mobile_Phone.CAN_OPEN_PHONE = false;
			Script.Wait(3000);
			PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
			int num = Game.GameTime + 2000;
			while (Game.GameTime < num)
			{
				Script.Wait(0);
			}
			GET_MAIN_CHARACTER();
			LoadingPrompt.Show("Getting Character", LoadingSpinnerType.Clockwise1);
			num = Game.GameTime + 2000;
			while (Game.GameTime < num)
			{
				Script.Wait(0);
			}
			MPLoadout.GET_CURRENT_LOADOUT();
			if (PlayerVehicle != null)
			{
				PlayerVehicle.Delete();
				PlayerVehicle = null;
			}
			while (PlayerVehicle == null && File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml"))
			{
				PlayerVehicle = MPVehicleLoadout.GET_VEHICLE_LOADOUT("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", new Vector3(-1034.005f, -2730.309f, 19.49528f), 240.448f);
				Script.Wait(0);
			}
			if (PlayerVehicle != null)
			{
				while (PlayerVehicle.AttachedBlip == null)
				{
					PlayerVehicle.AddBlip();
					Script.Wait(0);
				}
				PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleCar;
				if (PlayerVehicle.Model.IsBike || PlayerVehicle.Model.IsAmphibiousQuadBike || PlayerVehicle.Model.IsQuadBike)
				{
					PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleBike;
				}
				PlayerVehicle.AttachedBlip.Color = BlipColor.White;
				PlayerVehicle.AttachedBlip.Name = "Personal Vehicle";
			}
			LoadingPrompt.Show("Getting Save Data", LoadingSpinnerType.Clockwise1);
			num = Game.GameTime + 2000;
			while (Game.GameTime < num)
			{
				Script.Wait(0);
			}
			World.RemoveWaypoint();
			if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
			{
				LOAD_SCENES.NEW_LOAD_SCENE_START(-1037.893f, -2737.811f, 20.16927f, 0f, 0f, 0f, 500f, 0);
			}
			LoadingPrompt.Show("Setting Up New Session", LoadingSpinnerType.Clockwise1);
			num = Game.GameTime + 2000;
			while (Game.GameTime < num)
			{
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-1037.893f, -2737.811f, 20.16927f, 0f, 0f, 0f, 500f, 0);
				}
				Script.Wait(0);
			}
			LoadDict("anim@heists@team_respawn@respawn_01");
			LoadDict("anim@heists@team_respawn@respawn_01");
			Script.Wait(50);
			Game.Player.Character.Position = new Vector3(-1037.661f, -2737.689f, 19.16927f);
			Game.Player.Character.Heading = 330.0444f;
			Game.Player.Character.IsPositionFrozen = true;
			LoadingPrompt.Show("Entering New Session", LoadingSpinnerType.Clockwise1);
			num = Game.GameTime + 2000;
			while (Game.GameTime < num)
			{
				Game.Player.Character.Position = new Vector3(-1037.661f, -2737.689f, 19.16927f);
				Game.Player.Character.Heading = 330.0444f;
				Game.Player.Character.IsPositionFrozen = true;
				Cameras.RESET_GAMEPLAY_CAM();
				Script.Wait(0);
			}
			Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
			Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
			PlayerSwitch.SWITCH_IN_PLAYER(Game.Player.Character);
			Cameras.RESET_GAMEPLAY_CAM();
			while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
			{
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Game.Player.Character.Task.ClearAll();
				Game.Player.Character.Task.PlayAnimation("anim@heists@team_respawn@respawn_01", "heist_spawn_01_ped_b", 1000f, -1f, -1, AnimationFlags.AbortOnPedMovement, -1000f);
				Script.Wait(0);
			}
			LOAD_SCENES.NEW_LOAD_SCENE_STOP();
			LoadingPrompt.Hide();
			HudHandler.HudandRadar(Hud: true, Radar: true);
			Game.Player.Character.IsPositionFrozen = false;
			Mobile_Phone.CAN_OPEN_PHONE = true;
			Cameras.RESET_GAMEPLAY_CAM();
			StorySwitch = 2;
		};
	}

	public static void SETUP_CHAR_CREATOR_MENU()
	{
		CharCreator = new NativeMenu("Character Creator", "New Character");
		CharCreator.Banner.Color = Color.Aqua;
		CharCreator.MouseBehavior = MenuMouseBehavior.Disabled;
		CharCreator.Buttons.Clear();
		InstructionalButton[] array = new InstructionalButton[3]
		{
			new InstructionalButton("Cancel", GTA.Control.VehicleDuck),
			new InstructionalButton("Back", GTA.Control.PhoneCancel),
			new InstructionalButton("Select", GTA.Control.FrontendAccept)
		};
		CharCreator.Buttons.Add(array[0]);
		CharCreator.Buttons.Add(array[1]);
		CharCreator.Buttons.Add(array[2]);
		MenuPool.Add(CharCreator);
		NativeListItem<string> Sexbutton = new NativeListItem<string>("Sex", "Select the gender of your Character.~n~(WARNING - This WILL reset your characters current features when changed.)", "Male", "Female");
		CharCreator.Add(Sexbutton);
		NativeMenu nativeMenu = new NativeMenu("Character Creator", "Heritage", "Select to choose your parents.");
		MenuPool.Add(nativeMenu);
		NativeSubmenuItem nativeSubmenuItem = new NativeSubmenuItem(nativeMenu, CharCreator);
		nativeSubmenuItem.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem);
		nativeSubmenuItem.Activated += (object sender, EventArgs e) =>
		{
			while (CutsceneCam2 == null)
			{
				CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
				Script.Wait(0);
			}
			Function.Call(Hash.SET_CAM_ACTIVE, CutsceneCam, true);
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
			CutsceneCam2.FieldOfView = 43f;
			CutsceneCam.InterpTo(CutsceneCam2, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
		};
		nativeSubmenuItem.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			CutsceneCam2.InterpTo(CutsceneCam, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			CutsceneCam2.Delete();
			CutsceneCam2 = null;
		};
		NativeListItem<int> FaceList = new NativeListItem<int>("Face", "", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45);
		NativeListItem<int> ParentList = new NativeListItem<int>("Parent", "", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45);
		NativeListItem<int> STList = new NativeListItem<int>("Skin Tone", "", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);
		nativeMenu.Add(FaceList);
		nativeMenu.Add(ParentList);
		nativeMenu.Add(STList);
		FaceList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, FaceList.SelectedItem, ParentList.SelectedItem, 0, STList.SelectedItem, 0, 0, 0f, 0f, 0f, false);
		};
		ParentList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, FaceList.SelectedItem, ParentList.SelectedItem, 0, STList.SelectedItem, 0, 0, 0f, 0f, 0f, false);
		};
		STList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, FaceList.SelectedItem, ParentList.SelectedItem, 0, STList.SelectedItem, 0, 0, 0f, 0f, 0f, false);
		};
		NativeMenu nativeMenu2 = new NativeMenu("Character Creator", "Features", "Select to alter your facial features.");
		MenuPool.Add(nativeMenu2);
		nativeMenu2.MouseBehavior = MenuMouseBehavior.Movement;
		nativeMenu2.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem2 = new NativeSubmenuItem(nativeMenu2, CharCreator);
		nativeSubmenuItem2.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem2);
		nativeSubmenuItem2.Activated += (object sender, EventArgs e) =>
		{
			while (CutsceneCam2 == null)
			{
				CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
				Script.Wait(0);
			}
			Function.Call(Hash.SET_CAM_ACTIVE, CutsceneCam, true);
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
			CutsceneCam2.FieldOfView = 43f;
			CutsceneCam.InterpTo(CutsceneCam2, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
		};
		nativeSubmenuItem2.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			CutsceneCam2.InterpTo(CutsceneCam, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			CutsceneCam2.Delete();
			CutsceneCam2 = null;
		};
		NativeListItem<int> HairCList = new NativeListItem<int>("Hair Color", "Make changes to your Appearance.");
		for (int num = 0; num < Function.Call<int>(Hash.GET_NUM_PED_HAIR_TINTS); num++)
		{
			HairCList.Add(num);
		}
		NativeListItem<int> EyeBrowList = new NativeListItem<int>("Eyebrows", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 2); num++)
		{
			EyeBrowList.Add(num);
		}
		NativeListItem<int> BrowList = new NativeListItem<int>("Brow", "Make changes to your physical features.", -1);
		for (int num2 = 0; num2 < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 2); num2++)
		{
			BrowList.Add(num2);
		}
		nativeMenu2.Add(BrowList);
		NativeGridPanel BrowPanel = new NativeGridPanel();
		BrowPanel.LabelLeft = "In";
		BrowPanel.LabelTop = "Up";
		BrowPanel.LabelRight = "Out";
		BrowPanel.LabelBottom = "Down";
		BrowList.Panel = BrowPanel;
		BrowList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, BrowList.SelectedItem, 1f);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			EyeBrowList.SelectedItem = BrowList.SelectedItem;
		};
		BrowPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 6, BrowPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 7, BrowPanel.X * 2f - 1f);
		};
		NativeItem nativeItem = new NativeItem("Eyes", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem);
		NativeGridPanel EyePanel = new NativeGridPanel();
		EyePanel.LabelLeft = "Wide";
		EyePanel.LabelRight = "Squint";
		EyePanel.Style = GridStyle.Row;
		nativeItem.Panel = EyePanel;
		EyePanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 11, EyePanel.X * 2f - 1f);
		};
		NativeItem nativeItem2 = new NativeItem("Nose", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem2);
		NativeGridPanel NosePanel = new NativeGridPanel();
		NosePanel.LabelLeft = "Narrow";
		NosePanel.LabelTop = "Up";
		NosePanel.LabelRight = "Wide";
		NosePanel.LabelBottom = "Down";
		nativeItem2.Panel = NosePanel;
		NosePanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 0, NosePanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 1, NosePanel.Y * 2f - 1f);
		};
		NativeItem nativeItem3 = new NativeItem("Nose Profile", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem3);
		NativeGridPanel NosePPanel = new NativeGridPanel();
		NosePPanel.LabelLeft = "Short";
		NosePPanel.LabelTop = "Crooked";
		NosePPanel.LabelRight = "Long";
		NosePPanel.LabelBottom = "Curved";
		nativeItem3.Panel = NosePPanel;
		NosePPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 2, NosePPanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 3, NosePPanel.Y * 2f - 1f);
		};
		NativeItem nativeItem4 = new NativeItem("Nose Tip", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem4);
		NativeGridPanel NoseTPanel = new NativeGridPanel();
		NoseTPanel.LabelLeft = "Broken Left";
		NoseTPanel.LabelTop = "Tip Up";
		NoseTPanel.LabelRight = "Broken Right";
		NoseTPanel.LabelBottom = "Tip Down";
		nativeItem4.Panel = NoseTPanel;
		NoseTPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 4, NoseTPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 5, NoseTPanel.X * 2f - 1f);
		};
		NativeItem nativeItem5 = new NativeItem("Cheekbones", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem5);
		NativeGridPanel CheekBPanel = new NativeGridPanel();
		CheekBPanel.LabelLeft = "In";
		CheekBPanel.LabelTop = "Up";
		CheekBPanel.LabelRight = "Out";
		CheekBPanel.LabelBottom = "Down";
		nativeItem5.Panel = CheekBPanel;
		CheekBPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 8, CheekBPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 9, CheekBPanel.X * 2f - 1f);
		};
		NativeItem nativeItem6 = new NativeItem("Cheeks", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem6);
		NativeGridPanel CheeksPanel = new NativeGridPanel();
		CheeksPanel.LabelLeft = "Puffed";
		CheeksPanel.LabelRight = "Gaunt";
		CheeksPanel.Style = GridStyle.Row;
		nativeItem6.Panel = CheeksPanel;
		CheeksPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 10, CheeksPanel.X * 2f - 1f);
		};
		NativeItem nativeItem7 = new NativeItem("Lips", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem7);
		NativeGridPanel LipsPanel = new NativeGridPanel();
		LipsPanel.LabelLeft = "Fat";
		LipsPanel.LabelRight = "Thin";
		LipsPanel.Style = GridStyle.Row;
		nativeItem7.Panel = LipsPanel;
		LipsPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 12, LipsPanel.X * 2f - 1f);
		};
		NativeItem nativeItem8 = new NativeItem("Jaw", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem8);
		NativeGridPanel JawPanel = new NativeGridPanel();
		JawPanel.LabelLeft = "Narrow";
		JawPanel.LabelTop = "Round";
		JawPanel.LabelRight = "Wide";
		JawPanel.LabelBottom = "Squared";
		nativeItem8.Panel = JawPanel;
		JawPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 13, JawPanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 14, JawPanel.Y * 2f - 1f);
		};
		NativeItem nativeItem9 = new NativeItem("Chin Profile", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem9);
		NativeGridPanel ChinPPanel = new NativeGridPanel();
		ChinPPanel.LabelLeft = "In";
		ChinPPanel.LabelTop = "Up";
		ChinPPanel.LabelRight = "Out";
		ChinPPanel.LabelBottom = "Down";
		nativeItem9.Panel = ChinPPanel;
		ChinPPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 15, ChinPPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 16, ChinPPanel.X * 2f - 1f);
		};
		NativeItem nativeItem10 = new NativeItem("Chin Shape", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem10);
		NativeGridPanel ChinSPanel = new NativeGridPanel();
		ChinSPanel.LabelLeft = "Pointed";
		ChinSPanel.LabelTop = "Rounded";
		ChinSPanel.LabelRight = "Square";
		ChinSPanel.LabelBottom = "Bum";
		nativeItem10.Panel = ChinSPanel;
		ChinSPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 17, ChinSPanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 18, ChinSPanel.Y * 2f - 1f);
		};
		NativeMenu nativeMenu3 = new NativeMenu("Character Creator", "Appearance", "Select to change your Appearance.");
		MenuPool.Add(nativeMenu3);
		nativeMenu3.MouseBehavior = MenuMouseBehavior.Movement;
		nativeMenu3.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem3 = new NativeSubmenuItem(nativeMenu3, CharCreator);
		nativeSubmenuItem3.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem3);
		nativeSubmenuItem3.Activated += (object sender, EventArgs e) =>
		{
			while (CutsceneCam2 == null)
			{
				CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
				Script.Wait(0);
			}
			Function.Call(Hash.SET_CAM_ACTIVE, CutsceneCam, true);
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
			CutsceneCam2.FieldOfView = 43f;
			CutsceneCam.InterpTo(CutsceneCam2, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
		};
		nativeSubmenuItem3.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			CutsceneCam2.InterpTo(CutsceneCam, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			CutsceneCam2.Delete();
			CutsceneCam2 = null;
		};
		NativeListItem<int> HairList = new NativeListItem<int>("Hair", "Make changes to your Appearance.");
		for (int num3 = 0; num3 < 23; num3++)
		{
			HairList.Add(num3);
		}
		nativeMenu3.Add(HairList);
		nativeMenu3.Add(HairCList);
		MPHairColor = 0;
		HairList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 2, HairList.SelectedItem, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
		};
		HairCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HAIR_TINT, Game.Player.Character, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			MPHairColor = HairCList.SelectedItem;
		};
		HairList.GoRight();
		HairList.GoLeft();
		HairList.Enabled = true;
		HairCList.GoRight();
		HairCList.GoLeft();
		HairCList.Enabled = true;
		nativeMenu3.Add(EyeBrowList);
		NativeGridPanel Opac2 = new NativeGridPanel();
		Opac2.LabelLeft = "0%";
		Opac2.LabelRight = "100%";
		Opac2.Style = GridStyle.Row;
		EyeBrowList.Panel = Opac2;
		PedOutfit.OverlayPart[2] = -1;
		PedOutfit.OpacityPart[2] = 0f;
		EyeBrowList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, EyeBrowList.SelectedItem, Opac2.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[2] = EyeBrowList.SelectedItem;
			PedOutfit.OpacityPart[2] = Opac2.X;
		};
		Opac2.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, EyeBrowList.SelectedItem, Opac2.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[2] = EyeBrowList.SelectedItem;
			PedOutfit.OpacityPart[2] = Opac2.X;
		};
		EyeBrowList.GoRight();
		EyeBrowList.GoLeft();
		EyeBrowList.Enabled = true;
		NativeListItem<int> FacialHairList = new NativeListItem<int>("Facial Hair", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 1); num++)
		{
			FacialHairList.Add(num);
		}
		nativeMenu3.Add(FacialHairList);
		NativeGridPanel Opac3 = new NativeGridPanel();
		Opac3.LabelLeft = "0%";
		Opac3.LabelRight = "100%";
		Opac3.Style = GridStyle.Row;
		FacialHairList.Panel = Opac3;
		PedOutfit.OverlayPart[1] = -1;
		PedOutfit.OpacityPart[1] = 0f;
		FacialHairList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 1, FacialHairList.SelectedItem, Opac3.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[1] = FacialHairList.SelectedItem;
			PedOutfit.OpacityPart[1] = Opac3.X;
		};
		Opac3.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 1, FacialHairList.SelectedItem, Opac3.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[1] = FacialHairList.SelectedItem;
			PedOutfit.OpacityPart[1] = Opac3.X;
		};
		FacialHairList.GoRight();
		FacialHairList.GoLeft();
		FacialHairList.Enabled = true;
		NativeListItem<int> SkinBlemList = new NativeListItem<int>("Skin Blemishes", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 0); num++)
		{
			SkinBlemList.Add(num);
		}
		nativeMenu3.Add(SkinBlemList);
		NativeGridPanel Opac4 = new NativeGridPanel();
		Opac4.LabelLeft = "0%";
		Opac4.LabelRight = "100%";
		Opac4.Style = GridStyle.Row;
		SkinBlemList.Panel = Opac4;
		SkinBlemList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 0, SkinBlemList.SelectedItem, Opac4.X);
			PedOutfit.OverlayPart[0] = SkinBlemList.SelectedItem;
			PedOutfit.OpacityPart[0] = Opac4.X;
		};
		Opac4.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 0, SkinBlemList.SelectedItem, Opac4.X);
			PedOutfit.OverlayPart[0] = SkinBlemList.SelectedItem;
			PedOutfit.OpacityPart[0] = Opac4.X;
		};
		SkinBlemList.GoRight();
		SkinBlemList.GoLeft();
		SkinBlemList.Enabled = true;
		NativeListItem<int> SkinAgeList = new NativeListItem<int>("Skin Aging", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 3); num++)
		{
			SkinAgeList.Add(num);
		}
		nativeMenu3.Add(SkinAgeList);
		NativeGridPanel Opac5 = new NativeGridPanel();
		Opac5.LabelLeft = "0%";
		Opac5.LabelRight = "100%";
		Opac5.Style = GridStyle.Row;
		SkinAgeList.Panel = Opac5;
		SkinAgeList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 3, SkinAgeList.SelectedItem, Opac5.X);
			PedOutfit.OverlayPart[3] = SkinAgeList.SelectedItem;
			PedOutfit.OpacityPart[3] = Opac5.X;
		};
		Opac5.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 3, SkinAgeList.SelectedItem, Opac5.X);
			PedOutfit.OverlayPart[3] = SkinAgeList.SelectedItem;
			PedOutfit.OpacityPart[3] = Opac5.X;
		};
		SkinAgeList.GoRight();
		SkinAgeList.GoLeft();
		SkinAgeList.Enabled = true;
		NativeListItem<int> SkinCompList = new NativeListItem<int>("Skin Complexion", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 6); num++)
		{
			SkinCompList.Add(num);
		}
		nativeMenu3.Add(SkinCompList);
		NativeGridPanel Opac6 = new NativeGridPanel();
		Opac6.LabelLeft = "0%";
		Opac6.LabelRight = "100%";
		Opac6.Style = GridStyle.Row;
		SkinCompList.Panel = Opac6;
		SkinCompList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 6, SkinCompList.SelectedItem, Opac6.X);
			PedOutfit.OverlayPart[6] = SkinCompList.SelectedItem;
			PedOutfit.OpacityPart[6] = Opac6.X;
		};
		Opac6.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 6, SkinCompList.SelectedItem, Opac6.X);
			PedOutfit.OverlayPart[6] = SkinCompList.SelectedItem;
			PedOutfit.OpacityPart[6] = Opac6.X;
		};
		SkinCompList.GoRight();
		SkinCompList.GoLeft();
		SkinCompList.Enabled = true;
		NativeListItem<int> MAFList = new NativeListItem<int>("Moles & Freckles", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 9); num++)
		{
			MAFList.Add(num);
		}
		nativeMenu3.Add(MAFList);
		NativeGridPanel Opac9 = new NativeGridPanel();
		Opac9.LabelLeft = "0%";
		Opac9.LabelRight = "100%";
		Opac9.Style = GridStyle.Row;
		MAFList.Panel = Opac9;
		MAFList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 9, MAFList.SelectedItem, Opac9.X);
			PedOutfit.OverlayPart[9] = MAFList.SelectedItem;
			PedOutfit.OpacityPart[9] = Opac9.X;
		};
		Opac9.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 9, MAFList.SelectedItem, Opac9.X);
			PedOutfit.OverlayPart[9] = MAFList.SelectedItem;
			PedOutfit.OpacityPart[9] = Opac9.X;
		};
		MAFList.GoRight();
		MAFList.GoLeft();
		MAFList.Enabled = true;
		NativeListItem<int> SDList = new NativeListItem<int>("Skin Damage", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 7); num++)
		{
			SDList.Add(num);
		}
		nativeMenu3.Add(SDList);
		NativeGridPanel Opac10 = new NativeGridPanel();
		Opac10.LabelLeft = "0%";
		Opac10.LabelRight = "100%";
		Opac10.Style = GridStyle.Row;
		SDList.Panel = Opac10;
		SDList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 7, SDList.SelectedItem, Opac10.X);
			PedOutfit.OverlayPart[7] = SDList.SelectedItem;
			PedOutfit.OpacityPart[7] = Opac10.X;
		};
		Opac10.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 7, SDList.SelectedItem, Opac10.X);
			PedOutfit.OverlayPart[7] = SDList.SelectedItem;
			PedOutfit.OpacityPart[7] = Opac10.X;
		};
		SDList.GoRight();
		SDList.GoLeft();
		SDList.Enabled = true;
		NativeListItem<int> EyeCList = new NativeListItem<int>("Eye Color", "Make changes to your Appearance.");
		for (int num = 0; num < 33; num++)
		{
			EyeCList.Add(num);
		}
		nativeMenu3.Add(EyeCList);
		EyeCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, Game.Player.Character, EyeCList.SelectedItem);
			MPEyeColor = EyeCList.SelectedItem;
		};
		EyeCList.GoRight();
		EyeCList.GoLeft();
		EyeCList.Enabled = true;
		NativeListItem<int> EyeMList = new NativeListItem<int>("Eye Makeup", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 4); num++)
		{
			EyeMList.Add(num);
		}
		nativeMenu3.Add(EyeMList);
		NativeGridPanel Opac11 = new NativeGridPanel();
		Opac11.LabelLeft = "0%";
		Opac11.LabelRight = "100%";
		Opac11.Style = GridStyle.Row;
		EyeMList.Panel = Opac11;
		EyeMList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		Opac11.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		EyeMList.GoRight();
		EyeMList.GoLeft();
		EyeMList.Enabled = true;
		NativeListItem<int> BlushList = new NativeListItem<int>("Blush", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 5); num++)
		{
			BlushList.Add(num);
		}
		nativeMenu3.Add(BlushList);
		NativeGridPanel Opac12 = new NativeGridPanel();
		Opac12.LabelLeft = "0%";
		Opac12.LabelRight = "100%";
		Opac12.Style = GridStyle.Row;
		BlushList.Panel = Opac12;
		BlushList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac12.X);
			PedOutfit.OverlayPart[5] = BlushList.SelectedItem;
			PedOutfit.OpacityPart[5] = Opac12.X;
		};
		Opac12.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac12.X);
			PedOutfit.OverlayPart[5] = BlushList.SelectedItem;
			PedOutfit.OpacityPart[5] = Opac12.X;
		};
		BlushList.GoRight();
		BlushList.GoLeft();
		BlushList.Enabled = true;
		NativeListItem<int> MakeupCList = new NativeListItem<int>("Makeup Color", "Make changes to your Appearance.");
		for (int num = 0; num < Function.Call<int>(Hash.GET_NUM_PED_MAKEUP_TINTS); num++)
		{
			MakeupCList.Add(num);
		}
		nativeMenu3.Add(MakeupCList);
		EyeMList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 4, 1, MakeupCList.SelectedItem, 0);
			MPMakeupColor = MakeupCList.SelectedItem;
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		BlushList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac12.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 5, 1, MakeupCList.SelectedItem, 0);
			PedOutfit.OverlayPart[5] = BlushList.SelectedItem;
			PedOutfit.OpacityPart[5] = Opac12.X;
		};
		MakeupCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 4, 1, MakeupCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 5, 1, MakeupCList.SelectedItem, 0);
			MPMakeupColor = MakeupCList.SelectedItem;
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		EyeMList.GoRight();
		EyeMList.GoLeft();
		EyeMList.Enabled = true;
		BlushList.GoRight();
		BlushList.GoLeft();
		BlushList.Enabled = true;
		MakeupCList.GoRight();
		MakeupCList.GoLeft();
		MakeupCList.Enabled = true;
		NativeListItem<int> LipstickList = new NativeListItem<int>("Lipstick", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 8); num++)
		{
			LipstickList.Add(num);
		}
		nativeMenu3.Add(LipstickList);
		NativeGridPanel Opac13 = new NativeGridPanel();
		Opac13.LabelLeft = "0%";
		Opac13.LabelRight = "100%";
		Opac13.Style = GridStyle.Row;
		LipstickList.Panel = Opac13;
		LipstickList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		Opac13.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		LipstickList.GoRight();
		LipstickList.GoLeft();
		LipstickList.Enabled = true;
		NativeListItem<int> LipstickCList = new NativeListItem<int>("Lipstick Color", "Make changes to your Appearance.");
		for (int num = 0; num < Function.Call<int>(Hash.GET_NUM_PED_MAKEUP_TINTS); num++)
		{
			LipstickCList.Add(num);
		}
		nativeMenu3.Add(LipstickCList);
		LipstickList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 8, 1, LipstickCList.SelectedItem, 0);
			MPLipstickColor = LipstickCList.SelectedItem;
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		LipstickCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 8, 1, LipstickCList.SelectedItem, 0);
			MPLipstickColor = LipstickCList.SelectedItem;
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		LipstickList.GoRight();
		LipstickList.GoLeft();
		LipstickList.Enabled = true;
		LipstickCList.GoRight();
		LipstickCList.GoLeft();
		LipstickCList.Enabled = true;
		NativeMenu nativeMenu4 = new NativeMenu("Character Creator", "Apparel", "Select to change your Apparel.");
		MenuPool.Add(nativeMenu4);
		NativeSubmenuItem nativeSubmenuItem4 = new NativeSubmenuItem(nativeMenu4, CharCreator);
		nativeSubmenuItem4.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem4);
		NativeListItem<int> GlassesList = new NativeListItem<int>("Glasses", "Make changes to your Apparel.");
		NativeListItem<int> GlassesVList = new NativeListItem<int>("Glasses Variation", "Make changes to your Apparel.", -1);
		nativeSubmenuItem4.Activated += (object sender, EventArgs e) =>
		{
			while (CutsceneCam2 == null)
			{
				CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
				Script.Wait(0);
			}
			Function.Call(Hash.SET_CAM_ACTIVE, CutsceneCam, true);
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CutsceneCam2, Game.Player.Character, 0.5f, 4f, 0.1f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CutsceneCam2, Game.Player.Character, 0f, 0f, 0.1f, true);
			CutsceneCam2.FieldOfView = 35f;
			CutsceneCam.InterpTo(CutsceneCam2, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_intro", 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
			GlassesList.Clear();
			if (Game.Player.Character.Gender == Gender.Male)
			{
				for (int i = -1; i < 40; i++)
				{
					GlassesList.Add(i + 1, i);
				}
			}
			else
			{
				for (int j = -1; j < 42; j++)
				{
					GlassesList.Add(j + 1, j);
				}
			}
			GlassesList.GoRight();
			GlassesList.GoLeft();
			GlassesList.Enabled = true;
		};
		nativeSubmenuItem4.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			CutsceneCam2.InterpTo(CutsceneCam, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			CutsceneCam2.Delete();
			CutsceneCam2 = null;
			Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
		};
		NativeListItem<string> OutfitList = new NativeListItem<string>("Outfit", "Make changes to your Apparel.", "The Man", "The Felon", "The Corner", "The Hustler");
		NativeListItem<string> StyleList = new NativeListItem<string>("Style", "Make changes to your Apparel.", "Street", "Flashy", "Party", "Beach", "Smart", "Sporty", "Eccentric", "Casual");
		nativeMenu4.Add(StyleList);
		StyleList.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			OutfitList.Clear();
			switch (StyleList.SelectedItem)
			{
			case "Street":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The Man");
					OutfitList.Add(1, "The Felon");
					OutfitList.Add(2, "The Corner");
					OutfitList.Add(3, "The Hustler");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit9 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 15,
						TextureId = 9,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 12,
						TextureId = 12,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 17,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 2,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 0,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit9.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The Mamacita");
					OutfitList.Add(1, "The Militia");
					OutfitList.Add(2, "The Convict");
					OutfitList.Add(3, "The Community");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit10 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 4,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 3,
						TextureId = 8,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 4,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 1,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 3,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 32,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit10.Equip(Game.Player.Character);
				}
				break;
			case "Flashy":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The Blues");
					OutfitList.Add(1, "The Musician");
					OutfitList.Add(2, "The Royal");
					OutfitList.Add(3, "The V.I.P");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit3 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 12,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 25,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 10,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 29,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 31,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 31,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit3.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The A List");
					OutfitList.Add(1, "The Benefit");
					OutfitList.Add(2, "The Stylish");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit4 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 5,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 8,
						TextureId = 4,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 19,
						TextureId = 3,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 10,
						TextureId = 3,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 13,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 35,
						TextureId = 8,
						PaletteId = 0
					});
					pedOutfit4.Equip(Game.Player.Character);
				}
				break;
			case "Party":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The All Night");
					OutfitList.Add(1, "The DJ");
					OutfitList.Add(2, "The Sky High");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit11 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 14,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 26,
						TextureId = 8,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 22,
						TextureId = 11,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 23,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 35,
						TextureId = 6,
						PaletteId = 0
					});
					pedOutfit11.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The Spirit");
					OutfitList.Add(1, "The Stripe");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit12 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 4,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 0,
						TextureId = 7,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 20,
						TextureId = 5,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 11,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 3,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 33,
						TextureId = 4,
						PaletteId = 0
					});
					pedOutfit12.Equip(Game.Player.Character);
				}
				break;
			case "Beach":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The Dude");
					OutfitList.Add(1, "The Heat");
					OutfitList.Add(2, "The Paradise");
					OutfitList.Add(3, "The Skimpy");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit15 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 5,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 15,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 16,
						TextureId = 5,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 15,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 17,
						TextureId = 4,
						PaletteId = 0
					});
					pedOutfit15.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The Beach Babe");
					OutfitList.Add(1, "The Day Tripper");
					OutfitList.Add(2, "The Lifeguard");
					OutfitList.Add(3, "The Siesta");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit16 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 15,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 12,
						TextureId = 14,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 3,
						TextureId = 13,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 11,
						TextureId = 1,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 3,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 18,
						TextureId = 9,
						PaletteId = 0
					});
					pedOutfit16.Equip(Game.Player.Character);
				}
				break;
			case "Smart":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The Anchor");
					OutfitList.Add(1, "The Grind");
					OutfitList.Add(2, "The Sharp Gray Suit");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit5 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 12,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 22,
						TextureId = 5,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 21,
						TextureId = 10,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 21,
						TextureId = 12,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 28,
						TextureId = 13,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 24,
						TextureId = 5,
						PaletteId = 0
					});
					pedOutfit5.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The Campaign");
					OutfitList.Add(1, "The Suit");
					OutfitList.Add(2, "The Trader");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit6 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 6,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 36,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 20,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 6,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 13,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 25,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit6.Equip(Game.Player.Character);
				}
				break;
			case "Sporty":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The Athlete");
					OutfitList.Add(1, "The Pro");
					OutfitList.Add(2, "The Sweats");
					OutfitList.Add(3, "The Trainer");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit13 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 18,
						TextureId = 1,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 9,
						TextureId = 7,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 15,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 39,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit13.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The Olympian");
					OutfitList.Add(1, "The Pump");
					OutfitList.Add(2, "The Stretch");
					OutfitList.Add(3, "The Winner");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit14 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 14,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 12,
						TextureId = 8,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 10,
						TextureId = 3,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 3,
						TextureId = 4,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 3,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 14,
						TextureId = 10,
						PaletteId = 0
					});
					pedOutfit14.Equip(Game.Player.Character);
				}
				break;
			case "Eccentric":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The Animal");
					OutfitList.Add(1, "The Cool Cat");
					OutfitList.Add(2, "The Dork");
					OutfitList.Add(3, "The Prince");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit7 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 4,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 28,
						TextureId = 12,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 20,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 12,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 10,
						TextureId = 14,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 35,
						TextureId = 4,
						PaletteId = 0
					});
					pedOutfit7.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The Amazon");
					OutfitList.Add(1, "The Art Attack");
					OutfitList.Add(2, "The Pretty Kitty");
					OutfitList.Add(3, "The Spooky");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit8 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 4,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 24,
						TextureId = 9,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 8,
						TextureId = 8,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 11,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 3,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 33,
						TextureId = 8,
						PaletteId = 0
					});
					pedOutfit8.Equip(Game.Player.Character);
				}
				break;
			case "Casual":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					OutfitList.Add(0, "The Plain White");
					OutfitList.Add(1, "The Simple");
					OutfitList.Add(2, "The Denims");
					OutfitList.Add(3, "The Hangout");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 0,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 0,
						TextureId = 10,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 15,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 1,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Equip(Game.Player.Character);
				}
				else
				{
					OutfitList.Add(0, "The Casual");
					OutfitList.Add(1, "The Comfort");
					OutfitList.Add(2, "The Daily");
					OutfitList.Add(3, "The Easy");
					OutfitList.GoRight();
					OutfitList.GoLeft();
					OutfitList.Enabled = true;
					PedOutfit pedOutfit2 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 16,
						TextureId = 4,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 2,
						TextureId = 5,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 2,
						TextureId = 1,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 3,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 0,
						TextureId = 11,
						PaletteId = 0
					});
					pedOutfit2.Equip(Game.Player.Character);
				}
				break;
			}
		};
		nativeMenu4.Add(OutfitList);
		OutfitList.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			switch (StyleList.SelectedItem)
			{
			case "Street":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Man":
					{
						PedOutfit pedOutfit33 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 15,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 12,
							TextureId = 12,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 17,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 2,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit33.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 0,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit33.Equip(Game.Player.Character);
						break;
					}
					case "The Felon":
					{
						PedOutfit pedOutfit32 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 7,
							TextureId = 15,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 1,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit32.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 7,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit32.Equip(Game.Player.Character);
						break;
					}
					case "The Corner":
					{
						PedOutfit pedOutfit31 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 5,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 17,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit31.Equip(Game.Player.Character);
						break;
					}
					case "The Hustler":
					{
						PedOutfit pedOutfit30 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 7,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 12,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 17,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit30.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit30.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Mamacita":
					{
						PedOutfit pedOutfit37 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 3,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 4,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit37.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 32,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit37.Equip(Game.Player.Character);
						break;
					}
					case "The Militia":
					{
						PedOutfit pedOutfit36 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 30,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 24,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 5,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit36.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 4,
							TextureId = 14,
							PaletteId = 0
						});
						pedOutfit36.Equip(Game.Player.Character);
						break;
					}
					case "The Convict":
					{
						PedOutfit pedOutfit35 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 3,
							TextureId = 15,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 3,
							TextureId = 15,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit35.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 3,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit35.Equip(Game.Player.Character);
						break;
					}
					case "The Community":
					{
						PedOutfit pedOutfit34 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 11,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 3,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit34.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 3,
							TextureId = 12,
							PaletteId = 0
						});
						pedOutfit34.Equip(Game.Player.Character);
						break;
					}
					}
				}
				break;
			case "Flashy":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Blues":
					{
						PedOutfit pedOutfit12 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 12,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 25,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 10,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 29,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 31,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit12.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 31,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit12.Equip(Game.Player.Character);
						break;
					}
					case "The Musician":
					{
						PedOutfit pedOutfit11 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 10,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit11.Equip(Game.Player.Character);
						break;
					}
					case "The Royal":
					{
						PedOutfit pedOutfit10 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 26,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 20,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 5,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 5,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit10.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 4,
							TextureId = 14,
							PaletteId = 0
						});
						pedOutfit10.Equip(Game.Player.Character);
						break;
					}
					case "The V.I.P":
					{
						PedOutfit pedOutfit9 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 12,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 24,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 10,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 27,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 35,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit9.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 30,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit9.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					switch (OutfitList.SelectedItem)
					{
					case "The A List":
					{
						PedOutfit pedOutfit15 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 8,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 19,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 10,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 13,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit15.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 35,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit15.Equip(Game.Player.Character);
						break;
					}
					case "The Benefit":
					{
						PedOutfit pedOutfit14 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 8,
							TextureId = 12,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 8,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 11,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 13,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit14.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 8,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit14.Equip(Game.Player.Character);
						break;
					}
					case "The Stylish":
					{
						PedOutfit pedOutfit13 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 23,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 42,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 7,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 13,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit13.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 24,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit13.Equip(Game.Player.Character);
						break;
					}
					}
				}
				break;
			case "Party":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The All Night":
					{
						PedOutfit pedOutfit40 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 14,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 26,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 22,
							TextureId = 11,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 23,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit40.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 35,
							TextureId = 6,
							PaletteId = 0
						});
						pedOutfit40.Equip(Game.Player.Character);
						break;
					}
					case "The DJ":
					{
						PedOutfit pedOutfit39 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 27,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 1,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit39.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 22,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit39.Equip(Game.Player.Character);
						break;
					}
					case "The Sky High":
					{
						PedOutfit pedOutfit38 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 26,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 7,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit38.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 44,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit38.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					string selectedItem = OutfitList.SelectedItem;
					string text = selectedItem;
					if (!(text == "The Spirit"))
					{
						if (text == "The Stripe")
						{
							PedOutfit pedOutfit41 = new PedOutfit
							{
								Components = new List<PedOutfit.OutfitComponent>(),
								Props = new List<PedOutfit.OutfitProp>()
							};
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
								DrawableId = 5,
								TextureId = 0,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
								DrawableId = 27,
								TextureId = 7,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
								DrawableId = 0,
								TextureId = 0,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
								DrawableId = 19,
								TextureId = 1,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
								DrawableId = 4,
								TextureId = 2,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
								DrawableId = 28,
								TextureId = 1,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
								DrawableId = 0,
								TextureId = 0,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
								DrawableId = 0,
								TextureId = 0,
								PaletteId = 0
							});
							pedOutfit41.Components.Add(new PedOutfit.OutfitComponent
							{
								ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
								DrawableId = 31,
								TextureId = 6,
								PaletteId = 0
							});
							pedOutfit41.Equip(Game.Player.Character);
						}
					}
					else
					{
						PedOutfit pedOutfit42 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 0,
							TextureId = 7,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 20,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 11,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit42.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 33,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit42.Equip(Game.Player.Character);
					}
				}
				break;
			case "Beach":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Dude":
					{
						PedOutfit pedOutfit54 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 16,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit54.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 17,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit54.Equip(Game.Player.Character);
						break;
					}
					case "The Heat":
					{
						PedOutfit pedOutfit53 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 18,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 16,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit53.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 5,
							TextureId = 7,
							PaletteId = 0
						});
						pedOutfit53.Equip(Game.Player.Character);
						break;
					}
					case "The Paradise":
					{
						PedOutfit pedOutfit52 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 18,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 1,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit52.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit52.Equip(Game.Player.Character);
						break;
					}
					case "The Skimpy":
					{
						PedOutfit pedOutfit51 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 18,
							TextureId = 11,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 5,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit51.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit51.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Beach Babe":
					{
						PedOutfit pedOutfit58 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 12,
							TextureId = 14,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 3,
							TextureId = 13,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 11,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit58.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 18,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit58.Equip(Game.Player.Character);
						break;
					}
					case "The Day Tripper":
					{
						PedOutfit pedOutfit57 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 16,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 16,
							TextureId = 7,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 10,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 16,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit57.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 31,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit57.Equip(Game.Player.Character);
						break;
					}
					case "The Lifeguard":
					{
						PedOutfit pedOutfit56 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 11,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 17,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 16,
							TextureId = 7,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 3,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit56.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 11,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit56.Equip(Game.Player.Character);
						break;
					}
					case "The Siesta":
					{
						PedOutfit pedOutfit55 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 25,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 16,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 1,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit55.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 18,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit55.Equip(Game.Player.Character);
						break;
					}
					}
				}
				break;
			case "Smart":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Anchor":
					{
						PedOutfit pedOutfit18 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 12,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 22,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 21,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 21,
							TextureId = 12,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 28,
							TextureId = 13,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit18.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 24,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit18.Equip(Game.Player.Character);
						break;
					}
					case "The Grind":
					{
						PedOutfit pedOutfit17 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 11,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 25,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 21,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 21,
							TextureId = 11,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit17.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 26,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit17.Equip(Game.Player.Character);
						break;
					}
					case "The Sharp Gray Suit":
					{
						PedOutfit pedOutfit16 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 12,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 25,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 10,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 32,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit16.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 31,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit16.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Campaign":
					{
						PedOutfit pedOutfit21 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 36,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 20,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 13,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit21.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 25,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit21.Equip(Game.Player.Character);
						break;
					}
					case "The Suit":
					{
						PedOutfit pedOutfit20 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 13,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 25,
							TextureId = 6,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 7,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit20.Equip(Game.Player.Character);
						break;
					}
					case "The Trader":
					{
						PedOutfit pedOutfit19 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 7,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 19,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 1,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 24,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit19.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 28,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit19.Equip(Game.Player.Character);
						break;
					}
					}
				}
				break;
			case "Sporty":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Athlete":
					{
						PedOutfit pedOutfit46 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 18,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 9,
							TextureId = 7,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit46.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 39,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit46.Equip(Game.Player.Character);
						break;
					}
					case "The Pro":
					{
						PedOutfit pedOutfit45 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 6,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 9,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit45.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 9,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit45.Equip(Game.Player.Character);
						break;
					}
					case "The Sweats":
					{
						PedOutfit pedOutfit44 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 3,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 7,
							TextureId = 15,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 41,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit44.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 7,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit44.Equip(Game.Player.Character);
						break;
					}
					case "The Trainer":
					{
						PedOutfit pedOutfit43 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 8,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 14,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 2,
							TextureId = 13,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit43.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 38,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit43.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Olympian":
					{
						PedOutfit pedOutfit50 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 14,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 12,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 10,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 3,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit50.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 14,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit50.Equip(Game.Player.Character);
						break;
					}
					case "The Pump":
					{
						PedOutfit pedOutfit49 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 7,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 2,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 11,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 16,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit49.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 10,
							TextureId = 7,
							PaletteId = 0
						});
						pedOutfit49.Equip(Game.Player.Character);
						break;
					}
					case "The Stretch":
					{
						PedOutfit pedOutfit48 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 7,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 10,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 1,
							TextureId = 13,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 1,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 5,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit48.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 10,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit48.Equip(Game.Player.Character);
						break;
					}
					case "The Winner":
					{
						PedOutfit pedOutfit47 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 14,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 12,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 4,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit47.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 14,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit47.Equip(Game.Player.Character);
						break;
					}
					}
				}
				break;
			case "Eccentric":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Animal":
					{
						PedOutfit pedOutfit25 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 28,
							TextureId = 12,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 20,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 12,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 10,
							TextureId = 14,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit25.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 35,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit25.Equip(Game.Player.Character);
						break;
					}
					case "The Cool Cat":
					{
						PedOutfit pedOutfit24 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 27,
							TextureId = 6,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 12,
							TextureId = 15,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit24.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 22,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit24.Equip(Game.Player.Character);
						break;
					}
					case "The Dork":
					{
						PedOutfit pedOutfit23 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 12,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 27,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 23,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 22,
							TextureId = 6,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 26,
							TextureId = 6,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit23.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 35,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit23.Equip(Game.Player.Character);
						break;
					}
					case "The Prince":
					{
						PedOutfit pedOutfit22 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 14,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 26,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 23,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 23,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit22.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 24,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit22.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Amazon":
					{
						PedOutfit pedOutfit29 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 24,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 8,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 11,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit29.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 33,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit29.Equip(Game.Player.Character);
						break;
					}
					case "The Art Attack":
					{
						PedOutfit pedOutfit28 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 7,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 0,
							TextureId = 14,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 19,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 16,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit28.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 10,
							TextureId = 15,
							PaletteId = 0
						});
						pedOutfit28.Equip(Game.Player.Character);
						break;
					}
					case "The Pretty Kitty":
					{
						PedOutfit pedOutfit27 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 12,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 27,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 42,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 10,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit27.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 26,
							TextureId = 11,
							PaletteId = 0
						});
						pedOutfit27.Equip(Game.Player.Character);
						break;
					}
					case "The Spooky":
					{
						PedOutfit pedOutfit26 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 4,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 27,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 8,
							TextureId = 3,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 2,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 13,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit26.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 13,
							TextureId = 8,
							PaletteId = 0
						});
						pedOutfit26.Equip(Game.Player.Character);
						break;
					}
					}
				}
				break;
			case "Casual":
				if (Game.Player.Character.Gender == Gender.Male)
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Plain White":
					{
						PedOutfit pedOutfit4 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 0,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 0,
							TextureId = 10,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit4.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit4.Equip(Game.Player.Character);
						break;
					}
					case "The Simple":
					{
						PedOutfit pedOutfit3 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 1,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit3.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 22,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit3.Equip(Game.Player.Character);
						break;
					}
					case "The Denims":
					{
						PedOutfit pedOutfit2 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 8,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 4,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 4,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 38,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit2.Equip(Game.Player.Character);
						break;
					}
					case "The Hangout":
					{
						PedOutfit pedOutfit = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 0,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 1,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 17,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 15,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 33,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit.Equip(Game.Player.Character);
						break;
					}
					}
				}
				else
				{
					switch (OutfitList.SelectedItem)
					{
					case "The Casual":
					{
						PedOutfit pedOutfit8 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 16,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 2,
							TextureId = 5,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 2,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit8.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 0,
							TextureId = 11,
							PaletteId = 0
						});
						pedOutfit8.Equip(Game.Player.Character);
						break;
					}
					case "The Comfort":
					{
						PedOutfit pedOutfit7 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 2,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 2,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 2,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 5,
							TextureId = 4,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit7.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 2,
							TextureId = 6,
							PaletteId = 0
						});
						pedOutfit7.Equip(Game.Player.Character);
						break;
					}
					case "The Daily":
					{
						PedOutfit pedOutfit6 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 9,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 4,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 13,
							TextureId = 12,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 1,
							TextureId = 2,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit6.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 9,
							TextureId = 9,
							PaletteId = 0
						});
						pedOutfit6.Equip(Game.Player.Character);
						break;
					}
					case "The Easy":
					{
						PedOutfit pedOutfit5 = new PedOutfit
						{
							Components = new List<PedOutfit.OutfitComponent>(),
							Props = new List<PedOutfit.OutfitProp>()
						};
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
							DrawableId = 2,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
							DrawableId = 16,
							TextureId = 6,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
							DrawableId = 2,
							TextureId = 1,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
							DrawableId = 3,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
							DrawableId = 0,
							TextureId = 0,
							PaletteId = 0
						});
						pedOutfit5.Components.Add(new PedOutfit.OutfitComponent
						{
							ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
							DrawableId = 3,
							TextureId = 11,
							PaletteId = 0
						});
						pedOutfit5.Equip(Game.Player.Character);
						break;
					}
					}
				}
				break;
			}
		};
		NativeListItem<string> HatList = new NativeListItem<string>("Hat", "Make changes to your Apparel.", "Off", "Black Winter Hat", "Rasta Winter Hat", "Maroon Winter Hat", "Black LS Fitted Cap", "Gray LS Fitted Cap", "Black Saggy Beanie", "Blue Saggy Beanie", "Red Saggy Beanie", "Green Army Cap", "Woodland Army Cap", "Ranch Brown Army Cap", "White Flat Cap", "Black Flat Cap", "Brown Flat Cap", "Fruntalot Green Cap Back", "Stank Purple Cap Back", "Fruntalot Green Cap Front", "Stank Purple Cap Front", "Black Fedora", "White Fedora", "Red Fedora", "Black Cowboy Hat", "Brown Cowboy Hat", "Chocolate Cowboy Hat", "White Paisley Bandana", "Black Paisley Bandana", "Camo Bandana", "Beat Off White Headphones", "Beat Off Black Headphones", "Beat Off Red Headphones", "Red Canvas Hat", "Floral Canvas Hat", "Woodland Canvas Hat", "Tan Pork Pie", "Ushero Purple Pork Pie", "Black Pork Pie", "Black Bowler Hat", "Vintage Bowler Hat", "Ash Bowler Hat", "Black Top Hat", "Vintage Top Hat", "Ash Top Hat", "Cream Trilby", "Black & Red Trilby", "Blue Trilby");
		nativeMenu4.Add(HatList);
		HatList.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			if (Game.Player.Character.Gender == Gender.Male)
			{
				switch (HatList.SelectedItem)
				{
				case "Off":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Winter Hat":
				{
					PedOutfit pedOutfit45 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit45.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 2,
						TextureId = 0
					});
					pedOutfit45.Equip(Game.Player.Character);
					break;
				}
				case "Rasta Winter Hat":
				{
					PedOutfit pedOutfit44 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit44.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 2,
						TextureId = 3
					});
					pedOutfit44.Equip(Game.Player.Character);
					break;
				}
				case "Maroon Winter Hat":
				{
					PedOutfit pedOutfit43 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit43.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 2,
						TextureId = 7
					});
					pedOutfit43.Equip(Game.Player.Character);
					break;
				}
				case "Black LS Fitted Cap":
				{
					PedOutfit pedOutfit42 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit42.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 4,
						TextureId = 0
					});
					pedOutfit42.Equip(Game.Player.Character);
					break;
				}
				case "Gray LS Fitted Cap":
				{
					PedOutfit pedOutfit41 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit41.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 4,
						TextureId = 1
					});
					pedOutfit41.Equip(Game.Player.Character);
					break;
				}
				case "Black Saggy Beanie":
				{
					PedOutfit pedOutfit40 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit40.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 5,
						TextureId = 0
					});
					pedOutfit40.Equip(Game.Player.Character);
					break;
				}
				case "Blue Saggy Beanie":
				{
					PedOutfit pedOutfit39 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit39.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 28,
						TextureId = 0
					});
					pedOutfit39.Equip(Game.Player.Character);
					break;
				}
				case "Red Saggy Beanie":
				{
					PedOutfit pedOutfit38 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit38.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 28,
						TextureId = 2
					});
					pedOutfit38.Equip(Game.Player.Character);
					break;
				}
				case "Green Army Cap":
				{
					PedOutfit pedOutfit37 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit37.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 6,
						TextureId = 0
					});
					pedOutfit37.Equip(Game.Player.Character);
					break;
				}
				case "Woodland Army Cap":
				{
					PedOutfit pedOutfit36 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit36.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 6,
						TextureId = 5
					});
					pedOutfit36.Equip(Game.Player.Character);
					break;
				}
				case "Ranch Brown Army Cap":
				{
					PedOutfit pedOutfit35 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit35.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 6,
						TextureId = 7
					});
					pedOutfit35.Equip(Game.Player.Character);
					break;
				}
				case "White Flat Cap":
				{
					PedOutfit pedOutfit34 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit34.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 7,
						TextureId = 0
					});
					pedOutfit34.Equip(Game.Player.Character);
					break;
				}
				case "Black Flat Cap":
				{
					PedOutfit pedOutfit33 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit33.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 7,
						TextureId = 2
					});
					pedOutfit33.Equip(Game.Player.Character);
					break;
				}
				case "Brown Flat Cap":
				{
					PedOutfit pedOutfit32 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit32.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 7,
						TextureId = 5
					});
					pedOutfit32.Equip(Game.Player.Character);
					break;
				}
				case "Fruntalot Green Cap Back":
				{
					PedOutfit pedOutfit31 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit31.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 9,
						TextureId = 5
					});
					pedOutfit31.Equip(Game.Player.Character);
					break;
				}
				case "Stank Purple Cap Back":
				{
					PedOutfit pedOutfit30 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit30.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 10,
						TextureId = 7
					});
					pedOutfit30.Equip(Game.Player.Character);
					break;
				}
				case "Fruntalot Green Cap Front":
				{
					PedOutfit pedOutfit29 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit29.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 9,
						TextureId = 5
					});
					pedOutfit29.Equip(Game.Player.Character);
					break;
				}
				case "Stank Purple Cap Front":
				{
					PedOutfit pedOutfit28 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit28.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 10,
						TextureId = 7
					});
					pedOutfit28.Equip(Game.Player.Character);
					break;
				}
				case "Black Fedora":
				{
					PedOutfit pedOutfit27 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit27.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 12,
						TextureId = 0
					});
					pedOutfit27.Equip(Game.Player.Character);
					break;
				}
				case "White Fedora":
				{
					PedOutfit pedOutfit26 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit26.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 12,
						TextureId = 1
					});
					pedOutfit26.Equip(Game.Player.Character);
					break;
				}
				case "Red Fedora":
				{
					PedOutfit pedOutfit25 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit25.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 30,
						TextureId = 0
					});
					pedOutfit25.Equip(Game.Player.Character);
					break;
				}
				case "Black Cowboy Hat":
				{
					PedOutfit pedOutfit24 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit24.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 13,
						TextureId = 0
					});
					pedOutfit24.Equip(Game.Player.Character);
					break;
				}
				case "Brown Cowboy Hat":
				{
					PedOutfit pedOutfit23 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit23.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 13,
						TextureId = 1
					});
					pedOutfit23.Equip(Game.Player.Character);
					break;
				}
				case "Chocolate Cowboy Hat":
				{
					PedOutfit pedOutfit22 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit22.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 13,
						TextureId = 2
					});
					pedOutfit22.Equip(Game.Player.Character);
					break;
				}
				case "White Paisley Bandana":
				{
					PedOutfit pedOutfit21 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit21.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 14,
						TextureId = 2
					});
					pedOutfit21.Equip(Game.Player.Character);
					break;
				}
				case "Black Paisley Bandana":
				{
					PedOutfit pedOutfit20 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit20.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 14,
						TextureId = 1
					});
					pedOutfit20.Equip(Game.Player.Character);
					break;
				}
				case "Camo Bandana":
				{
					PedOutfit pedOutfit19 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit19.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 14,
						TextureId = 6
					});
					pedOutfit19.Equip(Game.Player.Character);
					break;
				}
				case "Beat Off White Headphones":
				{
					PedOutfit pedOutfit18 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit18.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 15,
						TextureId = 0
					});
					pedOutfit18.Equip(Game.Player.Character);
					break;
				}
				case "Beat Off Black Headphones":
				{
					PedOutfit pedOutfit17 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit17.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 15,
						TextureId = 1
					});
					pedOutfit17.Equip(Game.Player.Character);
					break;
				}
				case "Beat Off Red Headphones":
				{
					PedOutfit pedOutfit16 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit16.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 15,
						TextureId = 2
					});
					pedOutfit16.Equip(Game.Player.Character);
					break;
				}
				case "Red Canvas Hat":
				{
					PedOutfit pedOutfit15 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit15.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 20,
						TextureId = 3
					});
					pedOutfit15.Equip(Game.Player.Character);
					break;
				}
				case "Floral Canvas Hat":
				{
					PedOutfit pedOutfit14 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit14.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 20,
						TextureId = 4
					});
					pedOutfit14.Equip(Game.Player.Character);
					break;
				}
				case "Woodland Canvas Hat":
				{
					PedOutfit pedOutfit13 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit13.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 20,
						TextureId = 5
					});
					pedOutfit13.Equip(Game.Player.Character);
					break;
				}
				case "Tan Pork Pie":
				{
					PedOutfit pedOutfit12 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit12.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 21,
						TextureId = 0
					});
					pedOutfit12.Equip(Game.Player.Character);
					break;
				}
				case "Ushero Purple Pork Pie":
				{
					PedOutfit pedOutfit11 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit11.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 21,
						TextureId = 4
					});
					pedOutfit11.Equip(Game.Player.Character);
					break;
				}
				case "Black Pork Pie":
				{
					PedOutfit pedOutfit10 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit10.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 21,
						TextureId = 5
					});
					pedOutfit10.Equip(Game.Player.Character);
					break;
				}
				case "Black Bowler Hat":
				{
					PedOutfit pedOutfit9 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit9.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 26,
						TextureId = 0
					});
					pedOutfit9.Equip(Game.Player.Character);
					break;
				}
				case "Vintage Bowler Hat":
				{
					PedOutfit pedOutfit8 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit8.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 26,
						TextureId = 8
					});
					pedOutfit8.Equip(Game.Player.Character);
					break;
				}
				case "Ash Bowler Hat":
				{
					PedOutfit pedOutfit7 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit7.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 26,
						TextureId = 9
					});
					pedOutfit7.Equip(Game.Player.Character);
					break;
				}
				case "Black Top Hat":
				{
					PedOutfit pedOutfit6 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit6.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 27,
						TextureId = 0
					});
					pedOutfit6.Equip(Game.Player.Character);
					break;
				}
				case "Vintage Top Hat":
				{
					PedOutfit pedOutfit5 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit5.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 27,
						TextureId = 8
					});
					pedOutfit5.Equip(Game.Player.Character);
					break;
				}
				case "Ash Top Hat":
				{
					PedOutfit pedOutfit4 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit4.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 27,
						TextureId = 9
					});
					pedOutfit4.Equip(Game.Player.Character);
					break;
				}
				case "Cream Trilby":
				{
					PedOutfit pedOutfit3 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit3.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 29,
						TextureId = 2
					});
					pedOutfit3.Equip(Game.Player.Character);
					break;
				}
				case "Black & Red Trilby":
				{
					PedOutfit pedOutfit2 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit2.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 29,
						TextureId = 5
					});
					pedOutfit2.Equip(Game.Player.Character);
					break;
				}
				case "Blue Trilby":
				{
					PedOutfit pedOutfit = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 29,
						TextureId = 7
					});
					pedOutfit.Equip(Game.Player.Character);
					break;
				}
				}
			}
			else
			{
				switch (HatList.SelectedItem)
				{
				case "Off":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Winter Hat":
				{
					PedOutfit pedOutfit69 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit69.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 12,
						TextureId = 0
					});
					pedOutfit69.Equip(Game.Player.Character);
					break;
				}
				case "Rasta Winter Hat":
				{
					PedOutfit pedOutfit68 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit68.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 29,
						TextureId = 0
					});
					pedOutfit68.Equip(Game.Player.Character);
					break;
				}
				case "Maroon Winter Hat":
				{
					PedOutfit pedOutfit67 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit67.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 29,
						TextureId = 1
					});
					pedOutfit67.Equip(Game.Player.Character);
					break;
				}
				case "Black LS Fitted Cap":
				{
					PedOutfit pedOutfit66 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit66.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 4,
						TextureId = 0
					});
					pedOutfit66.Equip(Game.Player.Character);
					break;
				}
				case "Gray LS Fitted Cap":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Saggy Beanie":
				{
					PedOutfit pedOutfit65 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit65.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 5,
						TextureId = 0
					});
					pedOutfit65.Equip(Game.Player.Character);
					break;
				}
				case "Blue Saggy Beanie":
				{
					PedOutfit pedOutfit64 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit64.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 5,
						TextureId = 5
					});
					pedOutfit64.Equip(Game.Player.Character);
					break;
				}
				case "Red Saggy Beanie":
				{
					PedOutfit pedOutfit63 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit63.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 5,
						TextureId = 4
					});
					pedOutfit63.Equip(Game.Player.Character);
					break;
				}
				case "Green Army Cap":
				{
					PedOutfit pedOutfit62 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit62.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 6,
						TextureId = 1
					});
					pedOutfit62.Equip(Game.Player.Character);
					break;
				}
				case "Woodland Army Cap":
				{
					PedOutfit pedOutfit61 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit61.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 6,
						TextureId = 7
					});
					pedOutfit61.Equip(Game.Player.Character);
					break;
				}
				case "Ranch Brown Army Cap":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "White Flat Cap":
				{
					PedOutfit pedOutfit60 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit60.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 7,
						TextureId = 1
					});
					pedOutfit60.Equip(Game.Player.Character);
					break;
				}
				case "Black Flat Cap":
				{
					PedOutfit pedOutfit59 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit59.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 168,
						TextureId = 2
					});
					pedOutfit59.Equip(Game.Player.Character);
					break;
				}
				case "Brown Flat Cap":
				{
					PedOutfit pedOutfit58 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit58.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 7,
						TextureId = 3
					});
					pedOutfit58.Equip(Game.Player.Character);
					break;
				}
				case "Fruntalot Green Cap Back":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Stank Purple Cap Back":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Fruntalot Green Cap Front":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Stank Purple Cap Front":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Fedora":
				{
					PedOutfit pedOutfit57 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit57.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 13,
						TextureId = 6
					});
					pedOutfit57.Equip(Game.Player.Character);
					break;
				}
				case "White Fedora":
				{
					PedOutfit pedOutfit56 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit56.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 13,
						TextureId = 1
					});
					pedOutfit56.Equip(Game.Player.Character);
					break;
				}
				case "Red Fedora":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Cowboy Hat":
				{
					PedOutfit pedOutfit55 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit55.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 20,
						TextureId = 2
					});
					pedOutfit55.Equip(Game.Player.Character);
					break;
				}
				case "Brown Cowboy Hat":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Chocolate Cowboy Hat":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "White Paisley Bandana":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Paisley Bandana":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Camo Bandana":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Beat Off White Headphones":
				{
					PedOutfit pedOutfit54 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit54.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 0,
						TextureId = 4
					});
					pedOutfit54.Equip(Game.Player.Character);
					break;
				}
				case "Beat Off Black Headphones":
				{
					PedOutfit pedOutfit53 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit53.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 0,
						TextureId = 5
					});
					pedOutfit53.Equip(Game.Player.Character);
					break;
				}
				case "Beat Off Red Headphones":
				{
					PedOutfit pedOutfit52 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit52.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 0,
						TextureId = 0
					});
					pedOutfit52.Equip(Game.Player.Character);
					break;
				}
				case "Red Canvas Hat":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Floral Canvas Hat":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Woodland Canvas Hat":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Tan Pork Pie":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Ushero Purple Pork Pie":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Pork Pie":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black Bowler Hat":
				{
					PedOutfit pedOutfit51 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit51.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 26,
						TextureId = 0
					});
					pedOutfit51.Equip(Game.Player.Character);
					break;
				}
				case "Vintage Bowler Hat":
				{
					PedOutfit pedOutfit50 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit50.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 26,
						TextureId = 8
					});
					pedOutfit50.Equip(Game.Player.Character);
					break;
				}
				case "Ash Bowler Hat":
				{
					PedOutfit pedOutfit49 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit49.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 26,
						TextureId = 9
					});
					pedOutfit49.Equip(Game.Player.Character);
					break;
				}
				case "Black Top Hat":
				{
					PedOutfit pedOutfit48 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit48.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 27,
						TextureId = 0
					});
					pedOutfit48.Equip(Game.Player.Character);
					break;
				}
				case "Vintage Top Hat":
				{
					PedOutfit pedOutfit47 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit47.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 27,
						TextureId = 8
					});
					pedOutfit47.Equip(Game.Player.Character);
					break;
				}
				case "Ash Top Hat":
				{
					PedOutfit pedOutfit46 = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit46.Props.Add(new PedOutfit.OutfitProp
					{
						ComponentId = PedOutfit.PedPropsData.PED_PROP_HATS,
						DrawableId = 27,
						TextureId = 9
					});
					pedOutfit46.Equip(Game.Player.Character);
					break;
				}
				case "Cream Trilby":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Black & Red Trilby":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				case "Blue Trilby":
					Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
					break;
				}
			}
		};
		nativeMenu4.Add(GlassesList);
		GlassesList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			GlassesVList.Clear();
			for (int i = 0; i < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 1, GlassesList.SelectedItem); i++)
			{
				GlassesVList.Add(i, i);
			}
			GlassesVList.GoRight();
			GlassesVList.GoLeft();
			GlassesVList.Enabled = true;
			if (GlassesList.SelectedItem != -1)
			{
				PedOutfit pedOutfit = new PedOutfit
				{
					Components = new List<PedOutfit.OutfitComponent>(),
					Props = new List<PedOutfit.OutfitProp>()
				};
				pedOutfit.Props.Add(new PedOutfit.OutfitProp
				{
					ComponentId = PedOutfit.PedPropsData.PED_PROP_GLASSES,
					DrawableId = GlassesList.SelectedItem,
					TextureId = 0
				});
				pedOutfit.Equip(Game.Player.Character);
			}
			else
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 1, 0);
			}
		};
		nativeMenu4.Add(GlassesVList);
		GlassesVList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			PedOutfit pedOutfit = new PedOutfit
			{
				Components = new List<PedOutfit.OutfitComponent>(),
				Props = new List<PedOutfit.OutfitProp>()
			};
			pedOutfit.Props.Add(new PedOutfit.OutfitProp
			{
				ComponentId = PedOutfit.PedPropsData.PED_PROP_GLASSES,
				DrawableId = GlassesList.SelectedItem,
				TextureId = GlassesVList.SelectedItem
			});
			pedOutfit.Equip(Game.Player.Character);
		};
		Sexbutton.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			if (Sexbutton.SelectedItem == "Male")
			{
				Game.Player.ChangeModel(RequestModel(PedHash.FreemodeMale01));
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, 0, 0, 0, 0, 0, 0, 0f, 0f, 0f, false);
				PedOutfit pedOutfit = new PedOutfit
				{
					Components = new List<PedOutfit.OutfitComponent>(),
					Props = new List<PedOutfit.OutfitProp>()
				};
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
					DrawableId = 15,
					TextureId = 9,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
					DrawableId = 12,
					TextureId = 12,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
					DrawableId = 17,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
					DrawableId = 2,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
					DrawableId = 0,
					TextureId = 2,
					PaletteId = 0
				});
				pedOutfit.Equip(Game.Player.Character);
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
				Anims.SET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim, 1f);
				StyleList.GoRight();
				StyleList.GoLeft();
				MPGender = 0;
			}
			if (Sexbutton.SelectedItem == "Female")
			{
				Game.Player.ChangeModel(RequestModel(PedHash.FreemodeFemale01));
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, 0, 0, 0, 0, 0, 0, 0f, 0f, 0f, false);
				PedOutfit pedOutfit2 = new PedOutfit
				{
					Components = new List<PedOutfit.OutfitComponent>(),
					Props = new List<PedOutfit.OutfitProp>()
				};
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
					DrawableId = 4,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
					DrawableId = 3,
					TextureId = 8,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
					DrawableId = 4,
					TextureId = 2,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
					DrawableId = 1,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
					DrawableId = 3,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
					DrawableId = 32,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Equip(Game.Player.Character);
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
				Anims.SET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim, 1f);
				StyleList.GoRight();
				StyleList.GoLeft();
				MPGender = 1;
			}
		};
		NativeItem nativeItem11 = new NativeItem("Save & Continue", "Ready to start playing GTA Online-Offline?", "");
		CharCreator.Add(nativeItem11);
		nativeItem11.Activated += (object sender, EventArgs e) =>
		{
			if (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3))
			{
				CharCreator.Visible = !CharCreator.Visible;
				Menu_Switch = 2;
			}
		};
	}

	public unsafe void onTick(object sender, EventArgs e)
	{
		if (OnMission)
		{
			Mobile_Phone.CAN_CALL = false;
		}
		else
		{
			Mobile_Phone.CAN_CALL = true;
		}
		if (DEBUG)
		{
			if (CutsceneCam != null)
			{
			}
			myUIText = new TextElement(Cutscenes.GET_CUTSCENE_TIME().ToString(), new Point(10, 10), 0.4f, Color.WhiteSmoke, GTA.UI.Font.ChaletLondon);
			myUIText.Draw();
			if (Game.IsControlJustPressed(GTA.Control.Context))
			{
			}
			if (Game.IsControlJustPressed(GTA.Control.VehicleDuck))
			{
				test = 1;
			}
			int teleSwitch = TeleSwitch;
			int num = teleSwitch;
			if (num != 0 && num == 1 && Game.GameTime > TeleTimer)
			{
				Function.Call(Hash.SET_NEW_WAYPOINT, Game.Player.Character.Position.X, Game.Player.Character.Position.Y);
				Vector3 waypointPosition = World.WaypointPosition;
				if (Game.Player.Character.CurrentVehicle == null)
				{
					Game.Player.Character.Position = waypointPosition;
					Game.Player.Character.IsPositionFrozen = false;
				}
				else if (Game.Player.Character.CurrentVehicle != null)
				{
					Game.Player.Character.CurrentVehicle.Position = waypointPosition;
					Game.Player.Character.CurrentVehicle.IsPositionFrozen = false;
				}
				TeleTimer = 0;
				TeleSwitch = 0;
			}
			switch (test)
			{
			case 1:
				test = 2;
				break;
			}
		}
		if (Game.IsControlJustPressed(GTA.Control.Context))
		{
		}
		if (Game.IsControlJustPressed(GTA.Control.VehicleDuck))
		{
		}
		if (MenuPool != null && MenuPool.AreAnyVisible)
		{
			MenuPool.Process();
		}
		if (!ContinueCOO)
		{
			if (Game.IsLoading || Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE) || GTA.UI.Screen.IsFadingIn)
			{
				return;
			}
			Vehicle[] allVehicles = World.GetAllVehicles();
			Vehicle[] array = allVehicles;
			foreach (Vehicle vehicle in array)
			{
				if (isPlayerPrincipalVehicle(vehicle))
				{
					if (vehicle.AttachedBlip != null)
					{
						vehicle.AttachedBlip.Delete();
					}
					vehicle.Delete();
				}
			}
			LogLine("start-up: begin (xm_hatch_closed active: " + Interiors.IS_IPL_ACTIVE("xm_hatch_closed") + ")");
			if (!Interiors.IS_IPL_ACTIVE("xm_hatch_closed"))
			{
				LogLine("start-up: ON_ENTER_SP/MP, removing and requesting IPLs");
				Function.Call(Hash.ON_ENTER_SP);
				Function.Call(Hash.ON_ENTER_MP);
				LoadingPrompt.Hide();
				// Patched: log each IPL before touching it (the last line in the log names the one that stalls the game)
				// and hand control back to the game every 4 IPLs instead of streaming about 190 in a single frame.
				int iplCount = 0;
				foreach (string removeOnlyIPL in RemoveOnlyIPLS)
				{
					LogLine("REMOVE_IPL " + removeOnlyIPL);
					Function.Call(Hash.REMOVE_IPL, removeOnlyIPL);
					if (++iplCount % 4 == 0)
					{
						Script.Yield();
					}
				}
				foreach (string loadAllIPL in LoadAllIPLS)
				{
					LogLine("REQUEST_IPL " + loadAllIPL);
					Function.Call(Hash.REMOVE_IPL, loadAllIPL);
					Function.Call(Hash.REQUEST_IPL, loadAllIPL);
					if (++iplCount % 4 == 0)
					{
						Script.Yield();
					}
				}
				Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
				LogLine("start-up: IPL requests sent");
			}
			if (DEBUG)
			{
				Function.Call(Hash.SET_ABILITY_BAR_VISIBILITY, false);
				LoadDict("anim@move_m@grooving@");
				Script.Wait(50);
				Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character, "anim@move_m@grooving@", 1f);
				GET_MAIN_CHARACTER_WITHOUT_MODEL();
				MPLoadout.GET_CURRENT_LOADOUT();
				GTA.UI.Screen.ShowHelpTextThisFrame("b");
				GTA.UI.Screen.ShowSubtitle("b");
				Function.Call(Hash.SET_MINIMAP_HIDE_FOW, true);
				Function.Call(Hash.SET_INSTANCE_PRIORITY_MODE, true);
				GlobalVariable.Get(4).Write(1);
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "cellphone_controller");
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "respawn_controller");
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "gunclub_shop");
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "clothes_shop_sp");
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "clothes_shop_mp");
				Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 0, true);
				Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 1, true);
				Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 2, true);
				Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 3, true);
				Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 4, true);
				Function.Call(Hash.DISABLE_POLICE_RESTART, 0, true);
				Function.Call(Hash.DISABLE_POLICE_RESTART, 1, true);
				Function.Call(Hash.DISABLE_POLICE_RESTART, 2, true);
				Function.Call(Hash.DISABLE_POLICE_RESTART, 3, true);
				Function.Call(Hash.DISABLE_POLICE_RESTART, 4, true);
				Function.Call(Hash.DISABLE_POLICE_RESTART, 5, true);
				Function.Call(Hash.DISABLE_POLICE_RESTART, 6, true);
			}
			LoadDict("anim@move_m@grooving@");
			LoadDict("mp_facial");
			LoadDict("anim@amb@carmeet@checkout_engine@");
			Script.Wait(50);
			LogLine("start-up: done, ContinueCOO = true");
			ContinueCOO = true;
			return;
		}
		switch (StorySwitch)
		{
		case 0:
			switch (Menu_Switch)
			{
			case 0:
			{
				Mobile_Phone.CAN_OPEN_PHONE = false;
				Script.Wait(3000);
				PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
				int num9 = Game.GameTime + 5000;
				while (Game.GameTime < num9)
				{
					Script.Wait(0);
				}
				Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
				Game.Player.Character.Heading = 93.56179f;
				Cameras.RESET_GAMEPLAY_CAM();
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
				Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
				PlayerSwitch.SWITCH_IN_PLAYER(Game.Player.Character);
				while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
				{
					LOAD_SCENES.LOAD_SCENE(405.9204f, -997.1423f, -99.00402f);
					Script.Wait(0);
				}
				GTA.UI.Screen.FadeOut(0);
				Script.Wait(2000);
				Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
				Game.Player.Character.Heading = 93.56179f;
				Cameras.RESET_GAMEPLAY_CAM();
				if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
				LoadDict("mp_character_creation@customise@male_a");
				LoadDict("mp_character_creation@customise@male_a");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM", false, -1);
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator", false, -1);
				Script.Wait(50);
				int scaleID7 = ScaleID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID7);
				ScaleID = 0;
				int scaleID8 = ScaleID2;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID8);
				ScaleID2 = 0;
				Script.Yield();
				Script.Wait(500);
				ScaleID = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MUGSHOT_BOARD_01");
				Script.Wait(500);
				ScaleID2 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "DIGITAL_CAMERA");
				Script.Wait(500);
				while (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
					Script.Wait(0);
				}
				while (!Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "ID_Text", 0);
					Script.Wait(0);
				}
				Function.Call(Hash.LINK_NAMED_RENDERTARGET, Game.GenerateHash("prop_police_id_text"));
				RenderID = Function.Call<int>(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, "ID_Text");
				Wall_Creator.CallFunction(ScaleID, "SET_BOARD", Player_Name, "0000000001", "LOS SANTOS POLICE DEPT", "ONLINE - OFFLINE", "", 1, 1);
				Game.Player.ChangeModel(RequestModel(PedHash.Michael));
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				Script.Wait(500);
				Game.Player.ChangeModel(RequestModel(PedHash.FreemodeMale01));
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, 0, 0, 0, 0, 0, 0, 0f, 0f, 0f, false);
				PedOutfit pedOutfit = new PedOutfit
				{
					Components = new List<PedOutfit.OutfitComponent>(),
					Props = new List<PedOutfit.OutfitProp>()
				};
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
					DrawableId = 15,
					TextureId = 9,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
					DrawableId = 12,
					TextureId = 12,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
					DrawableId = 17,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
					DrawableId = 2,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
					DrawableId = 0,
					TextureId = 2,
					PaletteId = 0
				});
				pedOutfit.Equip(Game.Player.Character);
				Props.RemoveProps();
				Props.SPAWN_PROP_NO_OFFSET(RequestModel("prop_police_id_board"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
				Props.SPAWN_PROP_NO_OFFSET(RequestModel("prop_police_id_text"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
				Props.propList[1].AttachTo(Props.propList[0], new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
				Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "mugshot");
				Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
				while (CutsceneCam == null)
				{
					CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SPLINE_CAMERA", 0);
					Script.Wait(0);
				}
				World.RenderingCamera = CutsceneCam;
				CutsceneCam.FieldOfView = 50f;
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "intro", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_FACIAL_ANIM, Game.Player.Character, "intro_facial", LoadDict("mp_character_creation@customise@male_a"));
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
				Function.Call(Hash.SET_CAM_SPLINE_PHASE, CutsceneCam, 1f);
				Function.Call(Hash.SET_CAM_SPLINE_DURATION, CutsceneCam, 13000);
				Function.Call(Hash.ADD_CAM_SPLINE_NODE, CutsceneCam, 402.865f, -1003.475f, -98.36557f, 0f, 0f, 358.6678f, 1, 100, 0);
				Function.Call(Hash.ADD_CAM_SPLINE_NODE, CutsceneCam, 402.8563f, -999.9777f, -98.44982f, -6.103765f, 0.008221734f, 43f / 75f, 1, 100, 0);
				GTA.UI.Screen.FadeIn(1000);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lights_on", "GTAO_MUGSHOT_ROOM_SOUNDS", false);
				while (Cameras.CAM_SPLINE_PHASE(CutsceneCam) < 1f)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					Script.Wait(0);
				}
				CutsceneCam.Delete();
				CutsceneCam = null;
				while (CutsceneCam == null)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					CutsceneCam = World.CreateCamera(new Vector3(402.8563f, -999.9777f, -98.44982f), new Vector3(-6.103765f, 0.008221734f, 43f / 75f), 50f);
					Script.Wait(0);
				}
				World.RenderingCamera = CutsceneCam;
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.CLEAR_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character);
				Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_Happy_1", 0);
				Menu_Switch = 1;
				break;
			}
			case 1:
			{
				Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
				Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
				Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
				if (Function.Call<bool>(Hash.IS_USING_KEYBOARD_AND_MOUSE, 2))
				{
					if (Game.IsControlPressed(GTA.Control.Cover) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(GTA.Control.Cover))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
					if (Game.IsControlPressed(GTA.Control.Context) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(GTA.Control.Context))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
				}
				else
				{
					if (Game.IsControlPressed(GTA.Control.SelectWeapon) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(GTA.Control.Cover))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
					if (Game.IsControlPressed(GTA.Control.Cover) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(GTA.Control.Context))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
				}
				string[] array2 = new string[3] { "a", "b", "c" };
				if (Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_loop", 3))
				{
					Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_" + array2[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array2.Length)], 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
				}
				if (Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_intro", 3) || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_a", 3) || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_b", 3) || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_c", 3))
				{
					Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_loop", 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
				}
				if (!MenuPool.AreAnyVisible)
				{
					CharCreator.Visible = !CharCreator.Visible;
				}
				if (!ReditingCharacter || !Game.IsControlJustPressed(GTA.Control.VehicleDuck))
				{
					break;
				}
				GTA.UI.Screen.FadeOut(1000);
				int num7 = Game.GameTime + 1000;
				while (Game.GameTime < num7)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					if (MenuPool != null && MenuPool.AreAnyVisible)
					{
						MenuPool.Process();
					}
					Script.Wait(0);
				}
				foreach (NativeMenu item in MenuPool)
				{
					if (item.Visible)
					{
						item.Visible = false;
					}
				}
				if (CutsceneCam != null)
				{
					CutsceneCam.Delete();
					CutsceneCam = null;
				}
				if (CutsceneCam2 != null)
				{
					CutsceneCam2.Delete();
					CutsceneCam2 = null;
				}
				World.RenderingCamera = null;
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				LoadingPrompt.Hide();
				Props.RemoveProps();
				if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
				int scaleID5 = ScaleID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID5);
				ScaleID = 0;
				int scaleID6 = ScaleID2;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID6);
				ScaleID2 = 0;
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Game.Player.Character.Task.ClearAllImmediately();
				Game.Player.Character.Position = new Vector3(-1042.083f, -2746.112f, 20.35938f);
				Game.Player.Character.Heading = 328.8272f;
				Cameras.RESET_GAMEPLAY_CAM();
				HudHandler.HudandRadar(Hud: true, Radar: true);
				GET_MAIN_CHARACTER_WITHOUT_MODEL();
				MPLoadout.GET_CURRENT_LOADOUT();
				Mobile_Phone.CAN_OPEN_PHONE = true;
				MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
				MPCash.CAN_SEE_CASH = true;
				MPRank.CAN_SEE_RANK_BAR = true;
				MPPlayerList.CAN_SHOW_LIST = true;
				Menu_Switch = 0;
				StorySwitch = 2;
				GTA.UI.Screen.FadeIn(1000);
				ReditingCharacter = false;
				break;
			}
			case 2:
			{
				while (CutsceneCam2 == null)
				{
					CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_CAM_ACTIVE, CutsceneCam, true);
				Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
				Function.Call(Hash.POINT_CAM_AT_ENTITY, CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
				CutsceneCam2.FieldOfView = 43f;
				CutsceneCam.InterpTo(CutsceneCam2, 200, 0, 0);
				Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
				Wall_Creator.CallFunction(ScaleID2, "SHOW_REMAINING_PHOTOS", false);
				Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_FRAME", true);
				Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_BORDER", false);
				Wall_Creator.CallFunction(ScaleID2, "OPEN_SHUTTER");
				string[] array3 = new string[5] { "", "_a", "_b", "_c", "_d" };
				int num8 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array3.Length);
				Game.Player.Character.Task.ClearAllImmediately();
				TestCutsceneAnim = 0;
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "outro", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
					Scaleform scaleform2 = new Scaleform("instructional_buttons");
					scaleform2.CallFunction("CLEAR_ALL");
					scaleform2.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
					scaleform2.CallFunction("CREATE_CONTAINER");
					scaleform2.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 201, 0), "Accept");
					scaleform2.CallFunction("SET_DATA_SLOT", 1, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 177, 0), "Return to Menu");
					scaleform2.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
					scaleform2.Render2D();
					Script.Wait(0);
				}
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "outro_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "outro_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
				Menu_Switch = 3;
				break;
			}
			case 3:
			{
				Scaleform scaleform = new Scaleform("instructional_buttons");
				scaleform.CallFunction("CLEAR_ALL");
				scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
				scaleform.CallFunction("CREATE_CONTAINER");
				scaleform.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 201, 0), "Accept");
				scaleform.CallFunction("SET_DATA_SLOT", 1, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 177, 0), "Return to Menu");
				scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
				scaleform.Render2D();
				Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
				Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
				Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
				if (Game.IsControlJustPressed(GTA.Control.PhoneCancel))
				{
					CutsceneCam2.InterpTo(CutsceneCam, 200, 0, 0);
					Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
					CutsceneCam2.Delete();
					CutsceneCam2 = null;
					TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
					Menu_Switch = 1;
				}
				if (Game.IsControlJustPressed(GTA.Control.FrontendAccept))
				{
					LoadingPrompt.Show("Saving Character", LoadingSpinnerType.SocialClubSaving);
					Wall_Creator.CallFunction(ScaleID2, "CLOSE_SHUTTER", 250);
					Function.Call(Hash.PLAY_SOUND, -1, "Take_Picture", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
					Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "mp_gr_int01_white");
					int num5 = Game.GameTime + 5000;
					while (Game.GameTime < num5)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
					Function.Call(Hash.CLEAR_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character);
					LoadingPrompt.Show("Loading Online - Offline Session", LoadingSpinnerType.SocialClubSaving);
					Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_FRAME", false);
					Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_BORDER", true);
					Wall_Creator.CallFunction(ScaleID2, "OPEN_SHUTTER", 250);
					num5 = Game.GameTime + 11000;
					while (Game.GameTime < num5)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					PedOutfit.InitHeadBlendData();
					PedOutfit.InitExtensionListGet();
					num5 = Game.GameTime + 2000;
					while (Game.GameTime < num5)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					PedOutfit.GET_FACE(Game.Player.Character);
					PedOutfit.GET_OUTFIT(Game.Player.Character);
					num5 = 1;
					float num6 = 0f;
					for (; num5 < 20; num5++)
					{
						Config.SetValue("Character", $"Face Feature {num5}", PedOutfit.FaceFeaturePart[num5]);
						Config.Save();
					}
					Config.SetValue("Character", "Head Blend Data 1", PedOutfit.Data.ShapeFirst);
					Config.Save();
					Config.SetValue("Character", "Head Blend Data 2", PedOutfit.Data.ShapeSecond);
					Config.Save();
					Config.SetValue("Character", "Head Blend Data 3", PedOutfit.Data.SkinFirst);
					Config.Save();
					Config.SetValue("Character", "Hair", PedOutfit.HairPart[0]);
					Config.Save();
					Config.SetValue("Character", "Hair Color", MPHairColor);
					Config.Save();
					Config.SetValue("Character", "Eye Color", MPEyeColor);
					Config.Save();
					Config.SetValue("Character", "Makeup Color", MPMakeupColor);
					Config.Save();
					Config.SetValue("Character", "Lipstick Color", MPLipstickColor);
					Config.Save();
					for (num5 = 0; num5 < 11; num5++)
					{
						Config.SetValue("Character", $"Overlay {num5}", PedOutfit.OverlayPart[num5]);
						Config.Save();
						Config.SetValue("Character", $"Overlay Opacity {num5}", PedOutfit.OpacityPart[num5]);
						Config.Save();
					}
					for (num5 = 0; num5 < PedOutfit.OutfitPart.Length; num5++)
					{
						Config.SetValue("Character", $"Outfit {num5}", PedOutfit.OutfitPart[num5]);
						Config.Save();
						Config.SetValue("Character", $"Outfit Variation {num5}", PedOutfit.OutfitPart2[num5]);
						Config.Save();
					}
					for (num5 = 0; num5 < PedOutfit.OutfitPart3.Length; num5++)
					{
						Config.SetValue("Character", $"Accessory {num5}", PedOutfit.OutfitPart3[num5]);
						Config.Save();
						Config.SetValue("Character", $"Accessory Variation {num5}", PedOutfit.OutfitPart4[num5]);
						Config.Save();
					}
					Config.SetValue("Character", "Gender", MPGender);
					Config.Save();
					GTA.UI.Screen.FadeOut(1000);
					num5 = Game.GameTime + 1000;
					while (Game.GameTime < num5)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					if (CutsceneCam != null)
					{
						CutsceneCam.Delete();
						CutsceneCam = null;
					}
					if (CutsceneCam2 != null)
					{
						CutsceneCam2.Delete();
						CutsceneCam2 = null;
					}
					World.RenderingCamera = null;
					Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
					LoadingPrompt.Hide();
					Props.RemoveProps();
					if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
					{
						Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
					}
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
					int scaleID3 = ScaleID;
					Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID3);
					ScaleID = 0;
					int scaleID4 = ScaleID2;
					Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID4);
					ScaleID2 = 0;
					Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
					Screen_Effects.StopAllAnimPostFX();
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Game.Player.Character.Task.ClearAllImmediately();
					Game.Player.Character.Position = new Vector3(-1042.083f, -2746.112f, 20.35938f);
					Game.Player.Character.Heading = 328.8272f;
					Cameras.RESET_GAMEPLAY_CAM();
					HudHandler.HudandRadar(Hud: true, Radar: true);
					if (ReditingCharacter)
					{
						GET_MAIN_CHARACTER_WITHOUT_MODEL();
						MPLoadout.GET_CURRENT_LOADOUT();
						Mobile_Phone.CAN_OPEN_PHONE = true;
						MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
						MPCash.CAN_SEE_CASH = true;
						MPRank.CAN_SEE_RANK_BAR = true;
						MPPlayerList.CAN_SHOW_LIST = true;
						Menu_Switch = 0;
						StorySwitch = 2;
						GTA.UI.Screen.FadeIn(1000);
						ReditingCharacter = false;
					}
					else
					{
						Script.Wait(1000);
						Menu_Switch = 4;
					}
				}
				break;
			}
			case 4:
			{
				GTA.UI.Screen.FadeOut(0);
				Script.Wait(1000);
				while (!Audios.TRIGGER_MUSIC_EVENT_BOOL("FM_INTRO_START"))
				{
					Audios.TRIGGER_MUSIC_EVENT("FM_INTRO_START");
					Script.Wait(0);
				}
				Function.Call(Hash.SET_CLOCK_TIME, 19, 6, 0);
				int num2 = 0;
				HudHandler.HudandRadar(Hud: false, Radar: false);
				Game.Player.CanControlCharacter = false;
				while (CutsceneCam == null)
				{
					CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
					Script.Wait(0);
				}
				CutsceneCam.MotionBlurStrength = 1f;
				while (CutsceneCam2 == null)
				{
					CutsceneCam2 = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", false);
					Script.Wait(0);
				}
				CutsceneCam2.MotionBlurStrength = 1f;
				CutsceneCam.Detach();
				CutsceneCam.StopPointing();
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam.Position = new Vector3(-383.228f, -2303.435f, 54.47275f);
				CutsceneCam.Rotation = new Vector3(0f, 0f, 71.39185f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 40f);
				CutsceneCam2.Position = new Vector3(-353.5453f, -2273.986f, 51.67134f);
				CutsceneCam2.Rotation = new Vector3(10f, 0f, 89.32073f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, 36f);
				World.RenderingCamera = CutsceneCam;
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 15000, 3, 1);
				GTA.UI.Screen.FadeIn(1000);
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
				num2 = Game.GameTime + 6000;
				while (Game.GameTime < num2)
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("Welcome to GTA ~r~Online~w~-~p~Offline~w~.");
					if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
					{
						LOAD_SCENES.NEW_LOAD_SCENE_START(-383.228f, -2303.435f, 54.77275f, 0f, 0f, 0f, 530f, 0);
					}
					Script.Wait(0);
				}
				CutsceneCam.Detach();
				CutsceneCam.StopPointing();
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam.Position = new Vector3(-104.7599f, -1192.881f, 130.9377f);
				CutsceneCam.Rotation = new Vector3(0f, 0f, 2.333637f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 40f);
				CutsceneCam2.Position = new Vector3(-18.9879f, -1108.691f, 142.1894f);
				CutsceneCam2.Rotation = new Vector3(15f, 0f, 37.67196f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, 36f);
				World.RenderingCamera = CutsceneCam;
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 15000, 3, 1);
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
				num2 = Game.GameTime + 8000;
				while (Game.GameTime < num2)
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("With this mod you can play gta online but for singleplayer, so no more griefers or all of the other bs that comes with normal online.");
					if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
					{
						LOAD_SCENES.NEW_LOAD_SCENE_START(-104.7599f, -1192.881f, 131.2377f, 0f, 0f, 0f, 530f, 0);
					}
					Script.Wait(0);
				}
				CutsceneCam.Detach();
				CutsceneCam.StopPointing();
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam.Position = new Vector3(-1582.727f, -1032.249f, 25.57088f);
				CutsceneCam.Rotation = new Vector3(0f, 0f, 123.3521f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 40f);
				CutsceneCam2.Position = new Vector3(-1584.004f, -1034.765f, 14.5873f);
				CutsceneCam2.Rotation = new Vector3(15f, 0f, 123.3521f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, 36f);
				World.RenderingCamera = CutsceneCam;
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 15000, 3, 1);
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
				num2 = Game.GameTime + 8000;
				while (Game.GameTime < num2)
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("Everything will be free meaning no shark cards and everything will be properly priced, instead of needing 9 mil for every update.");
					if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
					{
						LOAD_SCENES.NEW_LOAD_SCENE_START(-1582.727f, -1032.249f, 14.57088f, 0f, 0f, 0f, 530f, 0);
					}
					Script.Wait(0);
				}
				CutsceneCam.Detach();
				CutsceneCam.StopPointing();
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam.Position = new Vector3(-1815.689f, -608.5884f, 25.5873f);
				CutsceneCam.Rotation = new Vector3(0f, 0f, 52.75578f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 40f);
				CutsceneCam2.Position = new Vector3(-1877.89f, -561.4197f, 27.19258f);
				CutsceneCam2.Rotation = new Vector3(15f, 0f, 57.8666f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, 36f);
				World.RenderingCamera = CutsceneCam;
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 13000, 0, 0);
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
				num2 = Game.GameTime + 13000;
				while (Game.GameTime < num2)
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("Thank you for your continued support and for downloading my mod and I hope you enjoy your experience.");
					if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
					{
						LOAD_SCENES.NEW_LOAD_SCENE_START(-1815.689f, -608.5884f, 12.7987f, 0f, 0f, 0f, 530f, 0);
					}
					Script.Wait(0);
				}
				CutsceneCam.Detach();
				CutsceneCam.StopPointing();
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam.Position = new Vector3(-1877.89f, -561.4197f, 27.19258f);
				CutsceneCam.Rotation = new Vector3(15f, 0f, 57.8666f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 36f);
				CutsceneCam2.Position = new Vector3(-1897.446f, -558.2964f, 44.4261f);
				CutsceneCam2.Rotation = new Vector3(10f, 0f, 96.37088f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, 40f);
				World.RenderingCamera = CutsceneCam;
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 18000, 0, 0);
				int scaleID = ScaleID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
				ScaleID = 0;
				Script.Wait(500);
				ScaleID = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "GTAV_ONLINE");
				num2 = Game.GameTime + 6000;
				while (Game.GameTime < num2)
				{
					Script.Wait(0);
				}
				Screen_Effects.PlayAnimPostFX("MP_intro_logo", 0, looped: false);
				num2 = Game.GameTime + 500;
				while (Game.GameTime < num2)
				{
					Script.Wait(0);
				}
				Wall_Creator.CallFunction(ScaleID, "SET_BIG_LOGO_VISIBLE", true, true);
				float num3 = 0f;
				num2 = Game.GameTime + 1500;
				while (Game.GameTime < num2)
				{
					num3 += 0.08f;
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID, 255, 255, 255, 255);
					myUIText = new TextElement("OFFLINE", new PointF(630f, 430f - num3), 3f, Color.Purple, GTA.UI.Font.Pricedown, Alignment.Center, shadow: true, outline: true);
					myUIText.Draw();
					Script.Wait(0);
				}
				num2 = Game.GameTime + 4000;
				while (Game.GameTime < num2)
				{
					num3 += 0.08f;
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID, 255, 255, 255, 255);
					myUIText = new TextElement("OFFLINE", new PointF(630f, 430f - num3), 3f, Color.Purple, GTA.UI.Font.Pricedown, Alignment.Center, shadow: true, outline: true);
					myUIText.Draw();
					Script.Wait(0);
				}
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
				if (!LOAD_SCENES.IS_NEW_LOAD_SCENE_ACTIVE())
				{
					LOAD_SCENES.NEW_LOAD_SCENE_START(-1188.608f, -1644.653f, 4.373932f, 0f, 0f, 0f, 530f, 0);
				}
				PlayerModelSet(Game.Player.Character);
				if (Game.Player.Character.Gender == Gender.Male)
				{
					LoadCutsceneWithFlag("mp_intro_concat", 31);
				}
				else if (Game.Player.Character.Gender == Gender.Female)
				{
					LoadCutsceneWithFlag("mp_intro_concat", 103);
				}
				CutsceneExtra1 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra1.IsVisible = false;
				CutsceneExtra2 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra2.IsVisible = false;
				CutsceneExtra3 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra3.IsVisible = false;
				CutsceneExtra4 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra4.IsVisible = false;
				CutsceneExtra5 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra5.IsVisible = false;
				CutsceneExtra6 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra6.IsVisible = false;
				CutsceneExtra7 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra7.IsVisible = false;
				CutsceneExtra8 = World.CreateRandomPed(new Vector3(-1188.608f, -1644.653f, 4.373932f));
				CutsceneExtra8.IsVisible = false;
				if (Game.Player.Character.Gender == Gender.Male)
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, "MP_Male_Character", 0, 0, 64);
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra1, "MP_Female_Character", 0, 0, 64);
				}
				else
				{
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, Game.Player.Character, "MP_Female_Character", 0, 0, 64);
					Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra1, "MP_Male_Character", 0, 0, 64);
				}
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra2, "MP_Plane_Passenger_1", 0, 0, 64);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra3, "MP_Plane_Passenger_2", 0, 0, 64);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra4, "MP_Plane_Passenger_3", 0, 0, 64);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra5, "MP_Plane_Passenger_4", 0, 0, 64);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra6, "MP_Plane_Passenger_5", 0, 0, 64);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra7, "MP_Plane_Passenger_6", 0, 0, 64);
				Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, CutsceneExtra8, "MP_Plane_Passenger_7", 0, 0, 64);
				Function.Call(Hash.START_CUTSCENE, 0);
				Script.Wait(50);
				int scaleID2 = ScaleID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID2);
				ScaleID = 0;
				GET_MAIN_CHARACTER_WITHOUT_MODEL();
				PlayerModelSetBack(Game.Player.Character);
				while (Cutscenes.GET_CUTSCENE_TIME() < 10000)
				{
					Script.Wait(0);
				}
				LOAD_SCENES.NEW_LOAD_SCENE_STOP();
				while (Cutscenes.GET_CUTSCENE_TIME() < 30000)
				{
					Script.Wait(0);
				}
				GTA.UI.Screen.FadeOut(1000);
				Script.Wait(1000);
				Function.Call(Hash.STOP_CUTSCENE_IMMEDIATELY);
				Function.Call(Hash.REMOVE_CUTSCENE);
				CutsceneExtra1.Delete();
				CutsceneExtra1 = null;
				CutsceneExtra2.Delete();
				CutsceneExtra2 = null;
				CutsceneExtra3.Delete();
				CutsceneExtra3 = null;
				CutsceneExtra4.Delete();
				CutsceneExtra4 = null;
				CutsceneExtra5.Delete();
				CutsceneExtra5 = null;
				CutsceneExtra6.Delete();
				CutsceneExtra6 = null;
				CutsceneExtra7.Delete();
				CutsceneExtra7 = null;
				CutsceneExtra8.Delete();
				CutsceneExtra8 = null;
				CutsceneCam.Detach();
				CutsceneCam.StopPointing();
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam.Position = new Vector3(-1038.94f, -2745.068f, 20.53538f);
				CutsceneCam.Rotation = new Vector3(0f, 0f, 108.2044f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 30f);
				CutsceneCam2.Position = new Vector3(-1037.35f, -2742.746f, 19.6799f);
				CutsceneCam2.Rotation = new Vector3(0f, 0f, 93.1311f);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, 26f);
				World.RenderingCamera = CutsceneCam;
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 5000, 3, 1);
				Script.Wait(1000);
				GTA.UI.Screen.FadeIn(1000);
				Game.Player.Character.Position = new Vector3(-1042.76f, -2746.389f, 20.35847f);
				Game.Player.Character.Heading = 330.0414f;
				Cameras.RESET_GAMEPLAY_CAM();
				Game.Player.Character.Task.ClearAll();
				Function.Call(Hash.FORCE_PED_MOTION_STATE, Game.Player.Character, 3626484699u, true, 0, 0);
				Game.Player.Character.Task.GoStraightTo(new Vector3(-1037.638f, -2737.672f, 20.16465f), -1, 334.5631f);
				num2 = Game.GameTime + 4000;
				while (Game.GameTime < num2)
				{
					Script.Wait(0);
				}
				CutsceneCam.Detach();
				CutsceneCam.StopPointing();
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam.AttachTo(Game.Player.Character, new Vector3(0f, 2f, 0.3f));
				CutsceneCam.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0.3f));
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 30f);
				CutsceneCam2.AttachTo(Game.Player.Character, new Vector3(0f, 3f, 0.6f));
				CutsceneCam2.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0.6f));
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, 26f);
				World.RenderingCamera = CutsceneCam;
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 5000, 0, 0);
				if (PlayerVehicle != null)
				{
					PlayerVehicle.Delete();
					PlayerVehicle = null;
				}
				int num4 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4);
				while (PlayerVehicle == null)
				{
					switch (num4)
					{
					case 0:
						PlayerVehicle = World.CreateVehicle(VehicleHash.Stanier, new Vector3(-1034.609f, -2730.188f, 19.66122f), 239.668f);
						break;
					case 1:
						PlayerVehicle = World.CreateVehicle(VehicleHash.Dukes2, new Vector3(-1034.609f, -2730.188f, 19.66122f), 239.668f);
						break;
					case 2:
						PlayerVehicle = World.CreateVehicle(VehicleHash.Gauntlet, new Vector3(-1034.609f, -2730.188f, 19.66122f), 239.668f);
						break;
					case 3:
						PlayerVehicle = World.CreateVehicle(VehicleHash.Kuruma, new Vector3(-1034.609f, -2730.188f, 19.66122f), 239.668f);
						break;
					}
					Script.Wait(0);
				}
				if (PlayerVehicle != null)
				{
					while (PlayerVehicle.AttachedBlip == null)
					{
						PlayerVehicle.AddBlip();
						Script.Wait(0);
					}
					PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleCar;
					if (PlayerVehicle.Model.IsBike || PlayerVehicle.Model.IsAmphibiousQuadBike || PlayerVehicle.Model.IsQuadBike)
					{
						PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleBike;
					}
					PlayerVehicle.AttachedBlip.Color = BlipColor.White;
					PlayerVehicle.AttachedBlip.Name = "Personal Vehicle";
					MPVehicleLoadout.SAVE_VEHICLE(PlayerVehicle, "scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", "StartVehicle");
					MPOwnedVehicles.SAVE_PREVIOUS_OWNED_VEHICLE("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", "StartVehicle");
				}
				num2 = Game.GameTime + 2500;
				while (Game.GameTime < num2)
				{
					Script.Wait(0);
				}
				Function.Call(Hash.SET_FOLLOW_PED_CAM_VIEW_MODE, 0);
				Cameras.RESET_GAMEPLAY_CAM();
				Game.Player.Character.Task.ClearAll();
				Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CutsceneCam, Game.Player.Character, 0.7983f, -0.9226f, 0.5243f, true);
				Function.Call(Hash.POINT_CAM_AT_ENTITY, CutsceneCam, Game.Player.Character, -0.2782f, 1.8498f, 0.1298f, true);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam, 30f);
				Function.Call(Hash.SET_CAM_NEAR_CLIP, CutsceneCam2, 0.15f);
				Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_HEADING, 0f);
				Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_PITCH, 0f, 1f);
				CutsceneCam2.Detach();
				CutsceneCam2.StopPointing();
				CutsceneCam2.Position = new Vector3(GameplayCamera.Position.X, GameplayCamera.Position.Y, GameplayCamera.Position.Z);
				CutsceneCam2.Rotation = new Vector3(GameplayCamera.Rotation.X, GameplayCamera.Rotation.Y, GameplayCamera.Rotation.Z);
				Function.Call(Hash.SET_CAM_FOV, CutsceneCam2, GameplayCamera.FieldOfView);
				Function.Call(Hash.SET_CAM_ACTIVE, CutsceneCam, true);
				Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, CutsceneCam2, CutsceneCam, 3000, 3, 1);
				Function.Call(Hash.SET_TRANSITION_OUT_OF_TIMECYCLE_MODIFIER, 7f);
				Function.Call(Hash.SET_HIDOF_OVERRIDE, 0, 0, 0f, 0f, 0f, 0f);
				num2 = Game.GameTime + 3000;
				while (Game.GameTime < num2)
				{
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Script.Wait(0);
				}
				CutsceneCam.Delete();
				CutsceneCam = null;
				CutsceneCam2.Delete();
				CutsceneCam2 = null;
				Function.Call(Hash.SET_FOLLOW_PED_CAM_VIEW_MODE, 0);
				Function.Call(Hash.RENDER_SCRIPT_CAMS, false, true, 1000, false, false, 0);
				Script.Wait(1000);
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Screen_Effects.PlayAnimPostFX("MinigameTransitionOut", 1000, looped: false);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Hit", "RESPAWN_SOUNDSET", true);
				Game.Player.CanControlCharacter = true;
				HudHandler.HudandRadar(Hud: true, Radar: true);
				MPRank.SET_RP(0);
				MPRank.SET_RANK(1);
				MPCash.SET_CASH(5000);
				MPCash.SET_BANK(20000);
				Game.Player.Character.Weapons.RemoveAll();
				Game.Player.Character.Weapons.Give(WeaponHash.Pistol, 10000, equipNow: false, isAmmoLoaded: true);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				MPInventory.CREATE_NEW_INVENTORY();
				MPSaveData.SAVE_DATA(MPSaveData.CREATE_FRESH_SAVE_DATA(), "Save Data");
				Menu_Switch = 0;
				StorySwitch = 1;
				Mobile_Phone.CAN_OPEN_PHONE = true;
				SET_INI_VALUE_INT(Config, "Main", "Progression", StorySwitch);
				GTA.UI.Screen.ShowHelpText("You can open up the session menu using the 'L' Key to then start your GTA ~r~Online~w~-~p~Offline~w~ Session.", 7000);
				break;
			}
			}
			break;
		case 2:
			if (OnMission)
			{
			}
			break;
		}
		if (Mobile_Phone.PHONE_OPEN && Mobile_Phone.MobileID == -1)
		{
		}
	}

	public unsafe void onShutdown(object sender, EventArgs e)
	{
		if (1 == 0)
		{
			return;
		}
		if (PlayerVehicle != null)
		{
			PlayerVehicle.Delete();
		}
		if (Manchez != null)
		{
			Manchez.Delete();
		}
		if (CutsceneExtra1 != null)
		{
			CutsceneExtra1.Delete();
		}
		if (CutsceneExtra2 != null)
		{
			CutsceneExtra2.Delete();
		}
		if (CutsceneExtra3 != null)
		{
			CutsceneExtra3.Delete();
		}
		if (CutsceneExtra4 != null)
		{
			CutsceneExtra4.Delete();
		}
		if (CutsceneExtra5 != null)
		{
			CutsceneExtra5.Delete();
		}
		if (CutsceneExtra6 != null)
		{
			CutsceneExtra6.Delete();
		}
		if (CutsceneExtra7 != null)
		{
			CutsceneExtra7.Delete();
		}
		if (CutsceneExtra8 != null)
		{
			CutsceneExtra8.Delete();
		}
		if (CutsceneExtra9 != null)
		{
			CutsceneExtra9.Delete();
		}
		if (CutsceneExtra10 != null)
		{
			CutsceneExtra10.Delete();
		}
		if (Container != null)
		{
			Container.Delete();
		}
		if (ContainerColl != null)
		{
			ContainerColl.Delete();
		}
		if (Lock != null)
		{
			Lock.Delete();
		}
		if (FakeCutsceneProp1 != null)
		{
			FakeCutsceneProp1.Delete();
		}
		if (FakeCutsceneProp2 != null)
		{
			FakeCutsceneProp2.Delete();
		}
		if (FakeCutsceneProp3 != null)
		{
			FakeCutsceneProp3.Delete();
		}
		if (FakeCutsceneProp4 != null)
		{
			FakeCutsceneProp4.Delete();
		}
		if (FakeCutsceneProp5 != null)
		{
			FakeCutsceneProp5.Delete();
		}
		if (FakeCutsceneProp6 != null)
		{
			FakeCutsceneProp6.Delete();
		}
		if (FakeCutsceneProp7 != null)
		{
			FakeCutsceneProp7.Delete();
		}
		if (FakeCutsceneProp8 != null)
		{
			FakeCutsceneProp8.Delete();
		}
		if (FakeCutsceneProp9 != null)
		{
			FakeCutsceneProp9.Delete();
		}
		if (FakeCutsceneProp10 != null)
		{
			FakeCutsceneProp10.Delete();
		}
		if (missionBlip != null)
		{
			missionBlip.Delete();
		}
		if (ImportantStoryBlip != null)
		{
			ImportantStoryBlip.Delete();
		}
		if (CutsceneCam != null)
		{
			CutsceneCam.Delete();
		}
		if (CutsceneCam2 != null)
		{
			CutsceneCam2.Delete();
		}
		if (CutsceneCam3 != null)
		{
			CutsceneCam3.Delete();
		}
		if (CutsceneCam4 != null)
		{
			CutsceneCam4.Delete();
		}
		if (MenuCam != null)
		{
			MenuCam.Delete();
		}
		if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
		{
			Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, PTFXID))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, PTFXID, 0);
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, PTFXID2))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, PTFXID2, 0);
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, PTFXID3))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, PTFXID3, 0);
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, PTFXID4))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, PTFXID4, 0);
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, PTFXID5))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, PTFXID5, 0);
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, PTFXID6))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, PTFXID6, 0);
		}
		Blip[] allBlips = World.GetAllBlips(BlipSprite.Standard);
		Blip[] array = allBlips;
		foreach (Blip blip in array)
		{
			if (blip != null)
			{
				blip.Delete();
			}
		}
		if (ContactText.IsLoaded)
		{
			ContactText.Dispose();
		}
		HudHandler.CLEAR_GPS_ROUTE();
		Function.Call(Hash.SET_PED_USING_ACTION_MODE, Game.Player.Character, false, -1, "DEFAULT_ACTION");
		Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, Game.Player.Character, false, "DEFAULT_ACTION");
		Screen_Effects.StopAllAnimPostFX();
		HudHandler.Remove_Wanted_Level();
		HudHandler.Set_Fake_Wanted_Level(0);
		Interiors.IslandLoad(isislandloaded: false);
		PlayerModelSetBack(Game.Player.Character);
		LoadingPrompt.Hide();
		Audio.StopSound(Alarms.Alarm_Sounds);
		Audio.ReleaseSound(Alarms.Alarm_Sounds);
		Alarms.STOP_ALL_ALARMS(stop: true);
		Audio.StopSound(SoundID);
		Audio.ReleaseSound(SoundID);
		Audio.StopSound(SoundID2);
		Audio.ReleaseSound(SoundID2);
		Audio.StopSound(SoundID3);
		Audio.ReleaseSound(SoundID3);
		Audio.StopSound(SoundID4);
		Audio.ReleaseSound(SoundID4);
		Audio.StopSound(SoundID5);
		Audio.ReleaseSound(SoundID5);
		Audio.StopSound(SoundID6);
		Audio.ReleaseSound(SoundID6);
		if (ScaleID != 0)
		{
			int scaleID = ScaleID;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
			ScaleID = 0;
		}
		if (ScaleID2 != 0)
		{
			int scaleID2 = ScaleID2;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID2);
			ScaleID2 = 0;
		}
		if (ScaleID3 != 0)
		{
			int scaleID3 = ScaleID3;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID3);
			ScaleID3 = 0;
		}
		if (ScaleID4 != 0)
		{
			int scaleID4 = ScaleID4;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID4);
			ScaleID4 = 0;
		}
		if (ScaleID5 != 0)
		{
			int scaleID5 = ScaleID5;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID5);
			ScaleID5 = 0;
		}
		if (ScaleID6 != 0)
		{
			int scaleID6 = ScaleID6;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID6);
			ScaleID6 = 0;
		}
		Function.Call(Hash.RESET_WANTED_LEVEL_DIFFICULTY, Game.Player);
		Function.Call(Hash.CANCEL_ALL_POLICE_REPORTS);
		Function.Call(Hash.STOP_CUTSCENE_IMMEDIATELY);
		Function.Call(Hash.REMOVE_CUTSCENE);
		Game.Player.Character.IsCollisionEnabled = true;
		Game.Player.Character.IsPositionFrozen = false;
		Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character, 1f);
		for (int j = 0; j <= 32; j++)
		{
			if (Function.Call<bool>(Hash.IS_PEDHEADSHOT_VALID, j))
			{
				Function.Call(Hash.UNREGISTER_PEDHEADSHOT, j);
			}
		}
		Function.Call(Hash.SET_NIGHTVISION, false);
		Function.Call(Hash.SET_ARTIFICIAL_LIGHTS_STATE, false);
		Function.Call(Hash.SET_TIME_SCALE, 1f);
		Game.Player.Character.CanSwitchWeapons = true;
		Function.Call(Hash.CLEAR_TIMECYCLE_MODIFIER);
		Function.Call(Hash.STOP_PLAYER_SWITCH);
		Function.Call(Hash.STOP_AUDIO_SCENES);
		Game.Player.Character.Task.ClearAll();
		Game.Player.Character.IsVisible = true;
		Game.Player.CanControlCharacter = true;
		Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, true, 0);
		Function.Call(Hash.SET_WIDESCREEN_BORDERS, false, 0);
		HudHandler.HudandRadar(Hud: true, Radar: true);
		World.RenderingCamera = null;
		World.DestroyAllCameras();
		if (GTA.UI.Screen.IsFadedOut || GTA.UI.Screen.IsFadingOut)
		{
			GTA.UI.Screen.FadeIn(0);
		}
		Function.Call(Hash.TRIGGER_SCREENBLUR_FADE_OUT, 0f);
		Function.Call(Hash.PAUSE_CLOCK, false);
		GlobalVariable.Get(4).Write(0);
		Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 0, false);
		Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 1, false);
		Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 2, false);
		Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 3, false);
		Function.Call(Hash.DISABLE_HOSPITAL_RESTART, 4, false);
		Function.Call(Hash.DISABLE_POLICE_RESTART, 0, false);
		Function.Call(Hash.DISABLE_POLICE_RESTART, 1, false);
		Function.Call(Hash.DISABLE_POLICE_RESTART, 2, false);
		Function.Call(Hash.DISABLE_POLICE_RESTART, 3, false);
		Function.Call(Hash.DISABLE_POLICE_RESTART, 4, false);
		Function.Call(Hash.DISABLE_POLICE_RESTART, 5, false);
		Function.Call(Hash.DISABLE_POLICE_RESTART, 6, false);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
		Function.Call(Hash.TRIGGER_MUSIC_EVENT, "GTA_ONLINE_STOP_SCORE");
		if (Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"))
		{
			Function.Call(Hash.ACTIVATE_FRONTEND_MENU, Function.Call<Hash>(Hash.GET_HASH_KEY, "FE_MENU_VERSION_CORONA"), false, -1);
		}
		if (Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
		{
			Function.Call(Hash.STOP_PLAYER_SWITCH);
		}
		Function.Call(Hash.SET_HIDOF_OVERRIDE, 0, 0, 0f, 0f, 0f, 0f);
		Function.Call(Hash.FORCE_CLOSE_TEXT_INPUT_BOX);
		Function.Call(Hash.SET_RADAR_ZOOM_PRECISE, 0f);
	}

	public void onKeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete && DEBUG)
		{
			Function.Call(Hash.STOP_CUTSCENE_IMMEDIATELY);
			if (Game.IsWaypointActive)
			{
				Vector3 waypointPosition = World.WaypointPosition;
				if (Game.Player.Character.CurrentVehicle == null)
				{
					Game.Player.Character.Position = waypointPosition;
					Game.Player.Character.IsPositionFrozen = true;
				}
				else if (Game.Player.Character.CurrentVehicle != null)
				{
					Game.Player.Character.CurrentVehicle.Position = waypointPosition;
					Game.Player.Character.CurrentVehicle.IsPositionFrozen = true;
				}
				TeleTimer = Game.GameTime + 600;
				TeleSwitch = 1;
			}
			if (!Game.IsWaypointActive)
			{
				Notification.Show("Waypoint not set");
			}
		}
		if (e.KeyCode == Keys.J)
		{
			GTA.UI.Screen.FadeIn(300);
			if (!Function.Call<bool>(Hash.HAS_CUTSCENE_FINISHED) && Game.IsControlPressed(GTA.Control.VehicleHandbrake))
			{
				Function.Call(Hash.STOP_CUTSCENE, true);
			}
			if (DEBUG && Game.Player.Character != null)
			{
				Thread thread;
				if (Game.Player.Character.IsInVehicle())
				{
					Notification.Show(Game.Player.Character.CurrentVehicle.IsSeatFree(VehicleSeat.LeftRear).ToString());
					Notification.Show(Function.Call<int>(Hash.GET_VEHICLE_MODEL_NUMBER_OF_SEATS, Game.Player.Character.CurrentVehicle.Model.Hash).ToString());
					if (Game.Player.Character.CurrentVehicle != null)
					{
						Notification.Show(Game.Player.Character.CurrentVehicle.Model.Hash.ToString() ?? "");
					}
					thread = new Thread(() =>
					{
						Clipboard.SetText(Game.Player.Character.CurrentVehicle.Position.X + "f, " + Game.Player.Character.CurrentVehicle.Position.Y + "f, " + Game.Player.Character.CurrentVehicle.Position.Z + "f, " + Game.Player.Character.CurrentVehicle.Heading);
					});
				}
				else
				{
					Notification.Show(Game.Player.Character.Model.Hash.ToString() ?? "");
					Function.Call(Hash.STOP_CUTSCENE);
					thread = new Thread(() =>
					{
						Clipboard.SetText(Game.Player.Character.Position.X + "f, " + Game.Player.Character.Position.Y + "f, " + Game.Player.Character.Position.Z + "f, " + Game.Player.Character.Heading);
					});
				}
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
				thread.Join();
			}
		}
		if (e.KeyCode == Keys.L && DEBUG)
		{
			RaycastResult crosshairCoordinates = World.GetCrosshairCoordinates();
			if (crosshairCoordinates.HitEntity != null)
			{
				GTA.UI.Screen.ShowSubtitle("you are aiming at an entity");
				if (Function.Call<int>(Hash.GET_ENTITY_TYPE, crosshairCoordinates.HitEntity) == 2)
				{
					CopyToClipboard($"(VehicleHash){crosshairCoordinates.HitEntity.Model}, new Vector3({crosshairCoordinates.HitEntity.Position.X}f, {crosshairCoordinates.HitEntity.Position.Y}f, {crosshairCoordinates.HitEntity.Position.Z}f - 1f ), {crosshairCoordinates.HitEntity.Rotation.Z}f");
				}
				if (Function.Call<int>(Hash.GET_ENTITY_TYPE, crosshairCoordinates.HitEntity) == 3)
				{
					CopyToClipboard($"Main.RequestModel({crosshairCoordinates.HitEntity.Model.GetHashCode()}), new Vector3({crosshairCoordinates.HitEntity.Position.X}f, {crosshairCoordinates.HitEntity.Position.Y}f, {crosshairCoordinates.HitEntity.Position.Z}f ), new Vector3({crosshairCoordinates.HitEntity.Rotation.X}f, {crosshairCoordinates.HitEntity.Rotation.Y}f, {crosshairCoordinates.HitEntity.Rotation.Z}f)");
				}
				if (Function.Call<int>(Hash.GET_ENTITY_TYPE, crosshairCoordinates.HitEntity) == 1)
				{
					CopyToClipboard($"(PedHash){crosshairCoordinates.HitEntity.Model}, new Vector3({crosshairCoordinates.HitEntity.Position.X}f, {crosshairCoordinates.HitEntity.Position.Y}f, {crosshairCoordinates.HitEntity.Position.Z}f - 1f), {crosshairCoordinates.HitEntity.Rotation.Z}f");
				}
			}
		}
		if (Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, Game.Player.Character))
		{
			Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, Game.Player.Character, 1, "DEFAULT_ACTION");
		}
		if (StorySwitch == 1 && e.KeyCode == Keys.L)
		{
			MainMenu.Visible = !MainMenu.Visible;
		}
	}

	public static bool isPlayerPrincipalVehicle(Entity vehicle)
	{
		int num = 3;
		string text = "Player_Vehicle";
		if (vehicle == null)
		{
			return false;
		}
		if (!vehicle.Exists())
		{
			return false;
		}
		if (!Function.Call<bool>(Hash.DECOR_IS_REGISTERED_AS_TYPE, text, num))
		{
			if (DEBUG)
			{
				Notification.Show("isn't registred as type");
			}
			return false;
		}
		return true;
	}

	public static void TriggerGuard(Ped Guard)
	{
		if (Guard != null && Guard.IsAlive)
		{
			if (Guard.AttachedBlip != null)
			{
				Function.Call(Hash.SET_BLIP_SHOW_CONE, Guard.AttachedBlip.Handle, false);
			}
			Function.Call(Hash.SET_PED_ALERTNESS, Guard, 3);
			Function.Call(Hash.TASK_COMBAT_PED, Guard, Game.Player.Character, 0, 16);
		}
	}

	public static void CallFunctionFrontend(string name, params object[] args)
	{
		if (Function.Call<bool>(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND, name))
		{
			pushArgs(args);
			Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
		}
	}

	public static void CallFunctionFrontendHeader(string name, params object[] args)
	{
		if (Function.Call<bool>(Hash.BEGIN_SCALEFORM_MOVIE_METHOD_ON_FRONTEND_HEADER, name))
		{
			pushArgs(args);
			Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
		}
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

	public unsafe static void PlayerModelSet(Ped ped)
	{
		if (IsFreemodeMale || IsFreemodeFemale)
		{
			ulong num = (ulong)(long)ped.MemoryAddress;
			ulong num2 = *(ulong*)(num + 32);
			*(long*)(num2 + 24) = 3214308084L;
		}
	}

	public unsafe static void PlayerModelSetBack(Ped ped)
	{
		if (IsFreemodeMale)
		{
			ulong num = (ulong)(long)ped.MemoryAddress;
			ulong num2 = *(ulong*)(num + 32);
			*(long*)(num2 + 24) = 1885233650L;
		}
		if (IsFreemodeFemale)
		{
			ulong num3 = (ulong)(long)ped.MemoryAddress;
			ulong num4 = *(ulong*)(num3 + 32);
			*(long*)(num4 + 24) = 2627665880L;
		}
	}

	public static void GetPedOutfitOnline(Ped NonCutscene)
	{
		if (NonCutscene != null)
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, NonCutscene, 44, 27, 0, 0, 0, 0, 0f, 0f, 0f, false);
			Function.Call(Hash.SET_PED_HAIR_TINT, NonCutscene, 19, 0);
			Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, NonCutscene, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, 0, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, 0, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, 54, 0, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, 1, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, 24, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, 0, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, 10, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, 38, 14, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, 38, 14, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, 154, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, 0, 0, 1);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, 322, 0, 1);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 0, 0, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 1, 1, 19, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 2, 1, 19, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 3, 0, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 4, 2, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 5, 2, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 6, 0, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 7, 0, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 8, 2, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 9, 0, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 10, 1, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 11, 0, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 12, 0, 0, 0);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 0, 0f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 1, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 2, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 3, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 4, 0f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 5, 0f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 6, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 7, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 8, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 9, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 10, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 11, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 12, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 13, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 14, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 15, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 16, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 17, -1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 18, 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 19, -1f);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 0, -1, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 1, 19, 1f);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 2, 14, 1f);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 3, -1, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 4, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 5, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 6, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 7, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 8, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 9, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 10, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 11, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 12, 0, 0);
			Function.Call(Hash.SET_PED_PROP_INDEX, NonCutscene, 0, 27, 0, true);
			Function.Call(Hash.SET_PED_PROP_INDEX, NonCutscene, 1, 19, 7, true);
		}
	}

	public static void GetJoeOutfit(Ped NonCutscene)
	{
		Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, NonCutscene, 44, 27, 0, 0, 0, 0, 0f, 0f, 0f, false);
		Function.Call(Hash.SET_PED_HAIR_TINT, NonCutscene, 19, 0);
		Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, NonCutscene, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 0, 0, 0, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, 0, 0, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 2, 54, 0, 2);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 3, 30, 0, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 4, 24, 1, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, 0, 0, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 6, 10, 0, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 7, -1, -1, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 8, 38, 14, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, 0, 0, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 10, 0, 0, 1);
		Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 11, 242, 0, 1);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 0, 0, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 1, 1, 19, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 2, 1, 19, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 3, 0, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 4, 2, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 5, 2, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 6, 0, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 7, 0, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 8, 2, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 9, 0, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 10, 1, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 11, 0, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, NonCutscene, 12, 0, 0, 0);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 0, -1f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 1, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 2, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 3, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 4, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 5, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 6, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 7, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 8, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 9, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 10, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 11, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 12, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 13, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 14, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 15, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 16, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 17, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 18, 0f);
		Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, 19, 0f);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 0, -1, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 1, 20, 1f);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 2, 14, 1f);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 3, -1, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 4, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 5, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 6, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 7, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 8, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 9, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 10, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 11, 0, 0);
		Function.Call(Hash.SET_PED_HEAD_OVERLAY, NonCutscene, 12, 0, 0);
		Function.Call(Hash.SET_PED_PROP_INDEX, NonCutscene, 0, 26, 0, true);
		Function.Call(Hash.SET_PED_PROP_INDEX, NonCutscene, 1, 17, 0, true);
	}

	public static void SET_MISSION_CONDITIONS(int hour, int minutes, int weather, bool pauseclock)
	{
		Function.Call(Hash.PAUSE_CLOCK, false);
		Function.Call(Hash.SET_CLOCK_TIME, hour, minutes, 0);
		World.Weather = (Weather)weather;
		Function.Call(Hash.PAUSE_CLOCK, pauseclock);
	}

	public static void SET_MISSION(bool noCopsOnMission, bool fuckOffCivilians, bool radioAllowed, bool onMission)
	{
		NoCopsOnMission = noCopsOnMission;
		FuckOffCivilians = fuckOffCivilians;
		RadioAllowed = radioAllowed;
		OnMission = onMission;
	}

	public static void SET_INI_VALUE_INT(ScriptSettings config, string section, string name, int value)
	{
		config.SetValue(section, name, value);
		config.Save();
	}

	public static void SET_INI_VALUE_STRING(ScriptSettings config, string section, string name, string value)
	{
		config.SetValue(section, name, value);
		config.Save();
	}

	public static void SET_INI_VALUE_FLOAT(ScriptSettings config, string section, string name, float value)
	{
		config.SetValue(section, name, value);
		config.Save();
	}

	public static void SET_INI_VALUE_BOOL(ScriptSettings config, string section, string name, bool value)
	{
		config.SetValue(section, name, value);
		config.Save();
	}

	public static void GetPedDuffelBagOn(Ped NonCutscene)
	{
		if (IsFreemodeMale || IsFreemodeFemale)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, 82, 0, 1);
		}
		if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, 1, 0, 2);
		}
	}

	public static void GetPedDuffelBagOff(Ped NonCutscene)
	{
		if (IsFreemodeMale || IsFreemodeFemale)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, 0, 0, 1);
		}
		if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, 0, 0, 2);
		}
	}

	public static Model RequestModel(int Name)
	{
		Model result = new Model(Name);
		result.Request(10000);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Model RequestModel(PedHash Name)
	{
		Model result = new Model(Name);
		result.Request(10000);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Model RequestModel(VehicleHash Name)
	{
		Model result = new Model(Name);
		result.Request(10000);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Model RequestModel(string Name)
	{
		Model result = new Model(Name);
		result.Request(250);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Hash joaat(string hash)
	{
		return Function.Call<Hash>(Hash.GET_HASH_KEY, hash);
	}

	public static void FindObjectModel(float distance)
	{
		Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, distance);
		Prop[] array = nearbyProps;
		foreach (Prop prop in array)
		{
			World.DrawMarker(MarkerType.Sphere, prop.Position, Vector3.Zero, Vector3.Zero, new Vector3(0.35f, 0.35f, 35f), Color.LightBlue);
			if (Game.IsControlJustPressed(GTA.Control.VehicleDuck))
			{
				Notification.Show("P.Model" + prop.Model.Hash);
			}
		}
	}

	public static void FindObjectPos(float distance)
	{
		Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, distance);
		Prop[] array = nearbyProps;
		foreach (Prop prop in array)
		{
			World.DrawMarker(MarkerType.Sphere, prop.Position, Vector3.Zero, Vector3.Zero, new Vector3(0.35f, 0.35f, 35f), Color.LightBlue);
			if (Game.IsControlJustPressed(GTA.Control.VehicleDuck))
			{
				Notification.Show("P.Model" + prop.Position);
			}
		}
	}

	public static void DisplayHelpText(string text)
	{
		InputArgument[] arguments = new InputArgument[1] { "STRING" };
		Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_HELP, arguments);
		InputArgument[] arguments2 = new InputArgument[1] { text };
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, arguments2);
		InputArgument[] arguments3 = new InputArgument[4] { 0, 0, 1, -1 };
		Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_HELP, arguments3);
	}

	public static void SetRelationshipBetweenGroups(Relationship relationship, int group1, int group2)
	{
		Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, (int)relationship, group1, group2);
		Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, (int)relationship, group2, group1);
	}

	public static int ShowNotification(string text, string txdname, string textureName, string sender, string subject, bool blink = false)
	{
		LoadTexureDict(txdname);
		LoadTexureDict(txdname);
		Script.Wait(50);
		Function.Call(Hash.BEGIN_TEXT_COMMAND_THEFEED_POST, CellEmailBcon);
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "<textarea maxlength=\"1000\" rows=\"1000\" cols=\"1000\">" + text + "</textarea>");
		Function.Call<int>(Hash.END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT, txdname, textureName, true, 1, sender, subject);
		return Function.Call<int>(Hash.END_TEXT_COMMAND_THEFEED_POST_TICKER, blink, true);
	}

	public static int ShowNotificationLong(string text, string text2, string text3, string txdname, string textureName, string sender, string subject, bool blink = false)
	{
		LoadTexureDict(txdname);
		LoadTexureDict(txdname);
		Script.Wait(50);
		Function.Call(Hash.BEGIN_TEXT_COMMAND_THEFEED_POST, CellEmailBcon);
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text2);
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text3);
		Function.Call<int>(Hash.END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT, txdname, textureName, true, 1, sender, subject);
		return Function.Call<int>(Hash.END_TEXT_COMMAND_THEFEED_POST_TICKER, blink, true);
	}

	public static void PictureNotification()
	{
	}

	public unsafe static IntPtr StringToCoTaskMemUTF8(string s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		int byteCount = Encoding.UTF8.GetByteCount(s);
		if (byteCount > _strBufferForStringToCoTaskMemUTF8.Length)
		{
			_strBufferForStringToCoTaskMemUTF8 = new byte[byteCount * 2];
		}
		Encoding.UTF8.GetBytes(s, 0, s.Length, _strBufferForStringToCoTaskMemUTF8, 0);
		IntPtr intPtr = Marshal.AllocCoTaskMem(byteCount + 1);
		if (intPtr == IntPtr.Zero)
		{
			throw new OutOfMemoryException();
		}
		Marshal.Copy(_strBufferForStringToCoTaskMemUTF8, 0, intPtr, byteCount);
		((sbyte*)intPtr.ToPointer())[byteCount] = 0;
		return intPtr;
	}

	public static int ShowContactAdded(string text, string txdname, string textureName, string nameofcontact)
	{
		LoadTexureDict(txdname);
		LoadTexureDict(txdname);
		Script.Wait(50);
		Function.Call(Hash.BEGIN_TEXT_COMMAND_THEFEED_POST, "INT");
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
		return Function.Call<int>(Hash.END_TEXT_COMMAND_THEFEED_POST_MESSAGETEXT, txdname, textureName, true, 3, "Contact Added: ", nameofcontact);
	}

	public static void CopyToClipboard(string text)
	{
		GTA.UI.Screen.ShowSubtitle("~y~Copied~s~: to clipboard!");
		Thread thread = new Thread(() =>
		{
			Clipboard.SetText(text);
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
	}
}
