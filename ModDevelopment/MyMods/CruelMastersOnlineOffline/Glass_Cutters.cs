using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Glass_Cutters : Script
{
	public static bool AllowGlassCutterGrab = false;

	public static bool AllowGlassCutterGrab2 = false;

	public static int ExtraLootSwitch = 0;

	public static int CutterTemp = 0;

	public static int CutterProgress = 0;

	public static int SoundId = 0;

	public static int cuttingsound = 0;

	public static int overheatsound = 0;

	public static int plasmaeffects;

	public static int heateffects;

	public static int TotalGlass = 0;

	public static int TotalAmount = 0;

	public static Prop Bag;

	public static Prop GlassCutter;

	public static List<Prop> GCSpawn = new List<Prop>();

	public static List<Prop> GC2Spawn = new List<Prop>();

	public static List<Prop> LootSpawn = new List<Prop>();

	public static List<Prop> LootStandSpawn = new List<Prop>();

	public Glass_Cutters()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		BlipUpLockBoxs();
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
		if (AllowGlassCutterGrab)
		{
			foreach (Prop item in GCSpawn.ToList())
			{
				if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item.Position, 2))
				{
					Glass_Cutter_Method(item);
				}
			}
		}
		if (!AllowGlassCutterGrab2)
		{
			return;
		}
		foreach (Prop item2 in GCSpawn.ToList())
		{
			if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item2.Position, 2))
			{
				Glass_Cutter_Method2(item2);
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (Bag != null)
		{
			Bag.Delete();
		}
		if (GlassCutter != null)
		{
			GlassCutter.Delete();
		}
		RemoveCases();
		if (SoundId != 0)
		{
			Audio.StopSound(SoundId);
			Audio.ReleaseSound(SoundId);
		}
		if (cuttingsound != 0)
		{
			Audio.StopSound(cuttingsound);
			Audio.ReleaseSound(cuttingsound);
		}
		if (overheatsound != 0)
		{
			Audio.StopSound(overheatsound);
			Audio.ReleaseSound(overheatsound);
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, plasmaeffects, 0);
		}
		if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
		{
			Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, heateffects, 0);
		}
	}

	public unsafe static void Glass_Cutter_Method(Prop GlassCase)
	{
		switch (ExtraLootSwitch)
		{
		case 0:
			if (!(Game.Player.Character.Position.DistanceTo(GlassCase.Position) < 2f))
			{
				break;
			}
			Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to cut the glass.");
			if (Game.IsControlJustPressed(Control.Context))
			{
				Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
				CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01", false, -1);
				Script.Wait(50);
				Vector3 vector = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_POSITION, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "enter", GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 0f, 2);
				Vector3 vector2 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_ROTATION, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "enter", GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 0f, 2);
				int num4 = 0;
				Function.Call(Hash.OPEN_SEQUENCE_TASK, &num4);
				if (Game.Player.Character.IsRunning || Game.Player.Character.IsSprinting)
				{
					Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 512, vector2.Z);
				}
				else
				{
					Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 2, vector2.Z);
				}
				Function.Call(Hash.CLOSE_SEQUENCE_TASK, num4);
				Function.Call(Hash.TASK_PERFORM_SEQUENCE, Game.Player.Character, num4);
				Function.Call(Hash.CLEAR_SEQUENCE_TASK, &num4);
				Script.Wait(500);
				CutterTemp = 0;
				CutterProgress = 0;
				while (Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, Game.Player.Character) != -1)
				{
					Script.Wait(0);
				}
				Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				while (Bag == null)
				{
					Bag = World.CreateProp(CruelMastersOnlineOffline.RequestModel("hei_p_m_bag_var22_arm_s"), Game.Player.Character.Position, dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
				while (GlassCutter == null)
				{
					GlassCutter = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_cutter_01a"), Game.Player.Character.Position, dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
				while (CruelMastersOnlineOffline.CutsceneCam == null)
				{
					CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_ANIMATED_CAMERA", 0);
					Script.Wait(0);
				}
				GlassCutter.IsVisible = false;
				Vector3 position = GlassCase.Position;
				Vector3 rotation = GlassCase.Rotation;
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "enter", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, GlassCutter, Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				GlassCutter.IsVisible = true;
				CruelMastersOnlineOffline.GetPedDuffelBagOff(Game.Player.Character);
				World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
				while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "enter", 3))
				{
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "idle", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				GlassCutter.Detach();
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
				Script.Wait(500);
				ExtraLootSwitch = 1;
			}
			break;
		case 1:
		{
			float num = (float)CutterTemp / 500f;
			float num2 = 1f - num;
			float percent = num;
			drawSprite5("timerbars", "all_black_bg", 0.89f, 0.97f, 0.21f, 0.04f, 255, 255, 255, 130);
			if (CutterTemp > 400)
			{
				drawSprite5("timerbars", "damagebarfill_128", 0.94f, 0.97f, 0.08f, 0.03f, 255, 0, 0, 130);
				drawSprite5("timerbars", "damagebarfill_128", progressxcoord(percent), 0.97f, progresswidth(percent), 0.03f, 255, 0, 0, 255);
			}
			else
			{
				drawSprite5("timerbars", "damagebarfill_128", 0.94f, 0.97f, 0.08f, 0.03f, 115, 115, 255, 130);
				drawSprite5("timerbars", "damagebarfill_128", progressxcoord(percent), 0.97f, progresswidth(percent), 0.03f, 115, 115, 255, 255);
			}
			drawText("HEAT", 0.805f, 0.961f, 0.3f, 255, 255, 255);
			float num3 = (float)CutterTemp / 500f;
			Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "IslandGlassPlinthHeat");
			Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, num3);
			if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
			{
				Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, heateffects, "heat", (float)CutterTemp / 500f, 0);
			}
			if (CutterTemp > 0)
			{
				CutterTemp -= 2;
			}
			if (Game.IsControlPressed(Control.Attack))
			{
				if (!Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "CUTTING_LOOP"))
				{
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "CUTTING_LOOP", 6.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
					Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
					if (SoundId == 0)
					{
						SoundId = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, SoundId, "StartCutting", GlassCutter, "DLC_H4_anims_glass_cutter_Sounds", true, 80);
					}
				}
				if (!Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
				{
					Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_ih_fin");
					Function.Call(Hash.USE_PARTICLE_FX_ASSET, "scr_ih_fin");
					plasmaeffects = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, "scr_ih_fin_glass_cutter_cut", GlassCutter, 0f, 0f, 0f, 0f, 0f, 0f, 1065353216, 0, 0, 0, 1065353216, 1065353216, 1065353216, 0);
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, plasmaeffects, "power", 0f, 0);
				}
				else
				{
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, plasmaeffects, "power", 1f, 0);
				}
				if (!Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
				{
					Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_ih_fin");
					Function.Call(Hash.USE_PARTICLE_FX_ASSET, "scr_ih_fin");
					heateffects = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, "scr_ih_fin_glass_cutter_overheat", GlassCutter, 0f, 0f, 0f, 0f, 0f, 0f, 1065353216, 0, 0, 0, 1065353216, 1065353216, 1065353216, 0);
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, heateffects, "heat", 0f, 0);
				}
				else
				{
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, heateffects, "heat", (float)CutterTemp / 500f, 0);
				}
				CutterTemp += 4;
				CutterProgress++;
				if (CutterTemp >= 500 && !Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "OVERHEAT_REACT_01"))
				{
					Audio.StopSound(SoundId);
					Audio.ReleaseSound(SoundId);
					SoundId = 0;
					if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
					{
						Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, plasmaeffects, 0);
					}
					if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
					{
						Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, heateffects, 0);
					}
					Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, 0, "Overheated", GlassCutter, "DLC_H4_anims_glass_cutter_Sounds", true, 50);
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "OVERHEAT_REACT_01", 6.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
					Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
					while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "OVERHEAT_REACT_01", 3))
					{
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "idle", 6.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
					Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
				}
				if (CutterProgress < 400 || Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "success"))
				{
					break;
				}
				foreach (Prop item in GC2Spawn.ToList())
				{
					if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item.Position, 2) && item != null && GC2Spawn.Count > 0)
					{
						item.IsVisible = true;
						item.IsCollisionEnabled = true;
						item.MarkAsNoLongerNeeded();
						GC2Spawn.Remove(item);
					}
				}
				GlassCase.IsVisible = false;
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Screen_Effects.StopAllAnimPostFX();
				Audio.StopSound(SoundId);
				Audio.ReleaseSound(SoundId);
				SoundId = 0;
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, plasmaeffects, 0);
				}
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, heateffects, 0);
				}
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "success", 6.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "success_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "success_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "success_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "success_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
				while (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) < 0.538f)
				{
					Script.Wait(0);
				}
				foreach (Prop item2 in LootSpawn.ToList())
				{
					if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item2.Position, 2) && item2 != null && LootSpawn.Count > 0)
					{
						if (RETURN_LOOT_TYPE(item2) == 0)
						{
							Heist_Hud.Actual_Take += 2090000;
						}
						if (RETURN_LOOT_TYPE(item2) == 1)
						{
							Heist_Hud.Actual_Take += 1430000;
						}
						if (RETURN_LOOT_TYPE(item2) == 2)
						{
							Heist_Hud.Actual_Take += 1100000;
						}
						if (RETURN_LOOT_TYPE(item2) == 3)
						{
							Heist_Hud.Actual_Take += 990000;
						}
						item2.Delete();
						LootSpawn.Remove(item2);
					}
				}
				foreach (Prop item3 in LootStandSpawn.ToList())
				{
					if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item3.Position, 2) && item3 != null && LootStandSpawn.Count > 0)
					{
						item3.MarkAsNoLongerNeeded();
						LootStandSpawn.Remove(item3);
					}
				}
				while (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) < 0.99f)
				{
					Script.Wait(0);
				}
				GameplayCamera.RelativeHeading = Game.Player.Character.Heading - Game.Player.Character.Heading;
				CruelMastersOnlineOffline.CutsceneCam.Delete();
				CruelMastersOnlineOffline.CutsceneCam = null;
				Cameras.RENDER_SCRIPT_CAMS(render: false, ease: true, 1000, p3: false, p4: false, p5: false);
				if (GCSpawn.Count > 0)
				{
					if (GlassCase.AttachedBlip != null)
					{
						GlassCase.AttachedBlip.Delete();
					}
					GlassCase.Delete();
					GCSpawn.Remove(GlassCase);
				}
				if (GlassCutter != null)
				{
					GlassCutter.Delete();
					GlassCutter = null;
				}
				CruelMastersOnlineOffline.GetPedDuffelBagOn(Game.Player.Character);
				if (Bag != null)
				{
					Bag.Delete();
					Bag = null;
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01");
				Game.Player.Character.Task.ClearAll();
				HudHandler.HudandRadar(Hud: true, Radar: true);
				Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
				ExtraLootSwitch = 0;
				break;
			}
			Screen.ShowHelpTextThisFrame("Use ~INPUT_ATTACK~ to cut through the glass. Be careful or the cutter will overheat.", beep: false);
			if (!Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "idle"))
			{
				Audio.StopSound(SoundId);
				Audio.ReleaseSound(SoundId);
				SoundId = 0;
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, plasmaeffects, 0);
				}
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, heateffects, 0);
				}
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "idle", 6.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
			}
			break;
		}
		}
	}

	public unsafe static void Glass_Cutter_Method2(Prop GlassCase)
	{
		switch (ExtraLootSwitch)
		{
		case 0:
			if (!(Game.Player.Character.Position.DistanceTo(GlassCase.Position) < 2f))
			{
				break;
			}
			Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to cut the glass.");
			if (Game.IsControlJustPressed(Control.Context))
			{
				Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
				CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01", false, -1);
				Script.Wait(50);
				Vector3 vector = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_POSITION, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "enter", GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 0f, 2);
				Vector3 vector2 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_ROTATION, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "enter", GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 0f, 2);
				int num4 = 0;
				Function.Call(Hash.OPEN_SEQUENCE_TASK, &num4);
				if (Game.Player.Character.IsRunning || Game.Player.Character.IsSprinting)
				{
					Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 512, vector2.Z);
				}
				else
				{
					Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 2, vector2.Z);
				}
				Function.Call(Hash.CLOSE_SEQUENCE_TASK, num4);
				Function.Call(Hash.TASK_PERFORM_SEQUENCE, Game.Player.Character, num4);
				Function.Call(Hash.CLEAR_SEQUENCE_TASK, &num4);
				Script.Wait(500);
				CutterTemp = 0;
				CutterProgress = 0;
				while (Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, Game.Player.Character) != -1)
				{
					Script.Wait(0);
				}
				Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
				HudHandler.HudandRadar(Hud: false, Radar: false);
				while (Bag == null)
				{
					Bag = World.CreateProp(CruelMastersOnlineOffline.RequestModel("hei_p_m_bag_var22_arm_s"), Game.Player.Character.Position, dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
				while (GlassCutter == null)
				{
					GlassCutter = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_cutter_01a"), Game.Player.Character.Position, dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
				while (CruelMastersOnlineOffline.CutsceneCam == null)
				{
					CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_ANIMATED_CAMERA", 0);
					Script.Wait(0);
				}
				GlassCutter.IsVisible = false;
				Vector3 position = GlassCase.Position;
				Vector3 rotation = GlassCase.Rotation;
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "enter", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, GlassCutter, Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				GlassCutter.IsVisible = true;
				CruelMastersOnlineOffline.GetPedDuffelBagOff(Game.Player.Character);
				World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
				while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "enter", 3))
				{
					Script.Wait(0);
				}
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "idle", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				GlassCutter.Detach();
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
				Script.Wait(500);
				ExtraLootSwitch = 1;
			}
			break;
		case 1:
		{
			float num = (float)CutterTemp / 500f;
			float num2 = 1f - num;
			float percent = num;
			drawSprite5("timerbars", "all_black_bg", 0.89f, 0.97f, 0.21f, 0.04f, 255, 255, 255, 130);
			if (CutterTemp > 400)
			{
				drawSprite5("timerbars", "damagebarfill_128", 0.94f, 0.97f, 0.08f, 0.03f, 255, 0, 0, 130);
				drawSprite5("timerbars", "damagebarfill_128", progressxcoord(percent), 0.97f, progresswidth(percent), 0.03f, 255, 0, 0, 255);
			}
			else
			{
				drawSprite5("timerbars", "damagebarfill_128", 0.94f, 0.97f, 0.08f, 0.03f, 115, 115, 255, 130);
				drawSprite5("timerbars", "damagebarfill_128", progressxcoord(percent), 0.97f, progresswidth(percent), 0.03f, 115, 115, 255, 255);
			}
			drawText("HEAT", 0.805f, 0.961f, 0.3f, 255, 255, 255);
			float num3 = (float)CutterTemp / 500f;
			Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "IslandGlassPlinthHeat");
			Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, num3);
			if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
			{
				Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, heateffects, "heat", (float)CutterTemp / 500f, 0);
			}
			if (CutterTemp > 0)
			{
				CutterTemp -= 2;
			}
			if (Game.IsControlPressed(Control.Attack))
			{
				if (!Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "CUTTING_LOOP"))
				{
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "CUTTING_LOOP", 6.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
					Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "CUTTING_LOOP_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
					if (SoundId == 0)
					{
						SoundId = Function.Call<int>(Hash.GET_SOUND_ID);
						Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, SoundId, "StartCutting", GlassCutter, "DLC_H4_anims_glass_cutter_Sounds", true, 80);
					}
				}
				if (!Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
				{
					Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_ih_fin");
					Function.Call(Hash.USE_PARTICLE_FX_ASSET, "scr_ih_fin");
					plasmaeffects = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, "scr_ih_fin_glass_cutter_cut", GlassCutter, 0f, 0f, 0f, 0f, 0f, 0f, 1065353216, 0, 0, 0, 1065353216, 1065353216, 1065353216, 0);
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, plasmaeffects, "power", 0f, 0);
				}
				else
				{
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, plasmaeffects, "power", 1f, 0);
				}
				if (!Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
				{
					Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_ih_fin");
					Function.Call(Hash.USE_PARTICLE_FX_ASSET, "scr_ih_fin");
					heateffects = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, "scr_ih_fin_glass_cutter_overheat", GlassCutter, 0f, 0f, 0f, 0f, 0f, 0f, 1065353216, 0, 0, 0, 1065353216, 1065353216, 1065353216, 0);
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, heateffects, "heat", 0f, 0);
				}
				else
				{
					Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, heateffects, "heat", (float)CutterTemp / 500f, 0);
				}
				CutterTemp += 4;
				CutterProgress++;
				if (CutterTemp >= 500 && !Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "OVERHEAT_REACT_01"))
				{
					Audio.StopSound(SoundId);
					Audio.ReleaseSound(SoundId);
					SoundId = 0;
					if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
					{
						Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, plasmaeffects, 0);
					}
					if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
					{
						Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, heateffects, 0);
					}
					Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, 0, "Overheated", GlassCutter, "DLC_H4_anims_glass_cutter_Sounds", true, 50);
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "OVERHEAT_REACT_01", 6.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
					Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "OVERHEAT_REACT_01_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
					while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "OVERHEAT_REACT_01", 3))
					{
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "idle", 6.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
					Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
				}
				if (CutterProgress < 400 || Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "success"))
				{
					break;
				}
				foreach (Prop item in GC2Spawn.ToList())
				{
					if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item.Position, 2) && item != null && GC2Spawn.Count > 0)
					{
						item.IsVisible = true;
						item.IsCollisionEnabled = true;
						item.MarkAsNoLongerNeeded();
						GC2Spawn.Remove(item);
					}
				}
				GlassCase.IsVisible = false;
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Screen_Effects.StopAllAnimPostFX();
				Audio.StopSound(SoundId);
				Audio.ReleaseSound(SoundId);
				SoundId = 0;
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, plasmaeffects, 0);
				}
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, heateffects, 0);
				}
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "success", 6.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "success_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "success_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "success_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "success_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
				while (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) < 0.538f)
				{
					Script.Wait(0);
				}
				foreach (Prop item2 in LootSpawn.ToList())
				{
					if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item2.Position, 2) && item2 != null && LootSpawn.Count > 0)
					{
						Heist_Hud.Actual_Take += TotalAmount / TotalGlass;
						item2.Delete();
						LootSpawn.Remove(item2);
					}
				}
				foreach (Prop item3 in LootStandSpawn.ToList())
				{
					if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item3.Position, 2) && item3 != null && LootStandSpawn.Count > 0)
					{
						item3.MarkAsNoLongerNeeded();
						LootStandSpawn.Remove(item3);
					}
				}
				while (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) < 0.99f)
				{
					Script.Wait(0);
				}
				GameplayCamera.RelativeHeading = Game.Player.Character.Heading - Game.Player.Character.Heading;
				CruelMastersOnlineOffline.CutsceneCam.Delete();
				CruelMastersOnlineOffline.CutsceneCam = null;
				Cameras.RENDER_SCRIPT_CAMS(render: false, ease: true, 1000, p3: false, p4: false, p5: false);
				if (GCSpawn.Count > 0)
				{
					if (GlassCase.AttachedBlip != null)
					{
						GlassCase.AttachedBlip.Delete();
					}
					GlassCase.Delete();
					GCSpawn.Remove(GlassCase);
				}
				if (GlassCutter != null)
				{
					GlassCutter.Delete();
					GlassCutter = null;
				}
				CruelMastersOnlineOffline.GetPedDuffelBagOn(Game.Player.Character);
				if (Bag != null)
				{
					Bag.Delete();
					Bag = null;
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01");
				Game.Player.Character.Task.ClearAll();
				HudHandler.HudandRadar(Hud: true, Radar: true);
				Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
				ExtraLootSwitch = 0;
				break;
			}
			Screen.ShowHelpTextThisFrame("Use ~INPUT_ATTACK~ to cut through the glass. Be careful or the cutter will overheat.", beep: false);
			if (!Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), "idle"))
			{
				Audio.StopSound(SoundId);
				Audio.ReleaseSound(SoundId);
				SoundId = 0;
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, plasmaeffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, plasmaeffects, 0);
				}
				if (Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, heateffects))
				{
					Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, heateffects, 0);
				}
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, GlassCase.Position.X, GlassCase.Position.Y, GlassCase.Position.Z, GlassCase.Rotation.X, GlassCase.Rotation.Y, GlassCase.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", "idle", 6.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_bag", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCutter, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cutter", CruelMastersOnlineOffline.LoadDict("ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@"), 1000f, 0f, 0, 1000f);
				Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(GlassCutter);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, GlassCase, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_glass_display", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@", 1000f, 0f, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_CAM_ANIM, CruelMastersOnlineOffline.CutsceneCam, CruelMastersOnlineOffline.TestCutsceneAnim, "idle_cam", "ANIM@SCRIPTED@HEIST@IG16_GLASS_CUT@MALE@");
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
			}
			break;
		}
		}
	}

	public static void RemoveCases()
	{
		if (GCSpawn.Count > 0)
		{
			foreach (Prop item in GCSpawn.ToList())
			{
				if (item != null)
				{
					item.Delete();
					GCSpawn.Remove(item);
				}
			}
		}
		if (GC2Spawn.Count > 0)
		{
			foreach (Prop item2 in GC2Spawn.ToList())
			{
				if (item2 != null)
				{
					item2.Delete();
					GC2Spawn.Remove(item2);
				}
			}
		}
		if (LootSpawn.Count > 0)
		{
			foreach (Prop item3 in LootSpawn.ToList())
			{
				if (item3 != null)
				{
					item3.Delete();
					LootSpawn.Remove(item3);
				}
			}
		}
		if (LootStandSpawn.Count <= 0)
		{
			return;
		}
		foreach (Prop item4 in LootStandSpawn.ToList())
		{
			if (item4 != null)
			{
				item4.Delete();
				LootStandSpawn.Remove(item4);
			}
		}
	}

	public static void BlipUpLockBoxs()
	{
		if (GCSpawn.Count <= 0)
		{
			return;
		}
		foreach (Prop item in GCSpawn)
		{
			if (item != null)
			{
				if (item.AttachedBlip == null)
				{
					item.AddBlip();
				}
				if (item.AttachedBlip != null)
				{
					item.IsInvincible = true;
					item.IsPositionFrozen = true;
					item.AttachedBlip.Sprite = BlipSprite.Standard;
					item.AttachedBlip.Color = BlipColor.Green;
					item.AttachedBlip.Name = "Glass Display";
					item.AttachedBlip.IsShortRange = true;
				}
			}
		}
	}

	public static Prop RandomCase(Vector3 pposition, float HHeading)
	{
		Model model = new Model("h4_prop_h4_glass_disp_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		Random random = new Random();
		string[] array = new string[3] { "h4_prop_h4_t_bottle_01a", "h4_prop_h4_t_bottle_02a", "h4_prop_h4_t_bottle_02b" };
		int num = random.Next(array.Length);
		switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1, 5))
		{
		case 1:
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop12 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop12.IsVisible = false;
				prop12.Heading = HHeading;
				if (prop12 != null)
				{
					GC2Spawn.Add(prop12);
				}
				Prop prop13 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_art_pant_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop13.Heading = HHeading;
				if (prop13 != null)
				{
					LootSpawn.Add(prop13);
				}
				return prop;
			}
			break;
		case 2:
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop7 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop7.IsVisible = false;
				prop7.Heading = HHeading;
				if (prop7 != null)
				{
					GC2Spawn.Add(prop7);
				}
				Prop prop8 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_diamond_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1.2f), dynamic: false, placeOnGround: false);
				prop8.Heading = HHeading;
				if (prop8 != null)
				{
					LootSpawn.Add(prop8);
				}
				Prop prop9 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_diamond_disp_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop9.Heading = HHeading;
				if (prop9 != null)
				{
					LootStandSpawn.Add(prop9);
				}
				return prop;
			}
			break;
		case 3:
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop4 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop4.IsVisible = false;
				prop4.Heading = HHeading;
				if (prop4 != null)
				{
					GC2Spawn.Add(prop4);
				}
				Prop prop5 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_necklace_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1.2f), dynamic: false, placeOnGround: false);
				prop5.Heading = HHeading;
				if (prop5 != null)
				{
					LootSpawn.Add(prop5);
				}
				Prop prop6 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_neck_disp_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop6.Heading = HHeading;
				if (prop6 != null)
				{
					LootStandSpawn.Add(prop6);
				}
				return prop;
			}
			break;
		case 4:
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop10 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop10.IsVisible = false;
				prop10.Heading = HHeading;
				if (prop10 != null)
				{
					GC2Spawn.Add(prop10);
				}
				Prop prop11 = World.CreateProp(CruelMastersOnlineOffline.RequestModel(array[num]), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop11.Heading = HHeading;
				if (prop11 != null)
				{
					LootSpawn.Add(prop11);
				}
				return prop;
			}
			break;
		default:
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop2 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop2.IsVisible = false;
				prop2.Heading = HHeading;
				if (prop2 != null)
				{
					GC2Spawn.Add(prop2);
				}
				Prop prop3 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_art_pant_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop3.Heading = HHeading;
				if (prop3 != null)
				{
					LootSpawn.Add(prop3);
				}
				return prop;
			}
			break;
		}
		return prop;
	}

	public static Prop PantherCase(Vector3 pposition, float HHeading)
	{
		Model model = new Model("h4_prop_h4_glass_disp_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1, 2);
		int num2 = num;
		int num3 = num2;
		if (num3 == 1)
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop2 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop2.IsVisible = false;
				prop2.Heading = HHeading;
				if (prop2 != null)
				{
					GC2Spawn.Add(prop2);
				}
				Prop prop3 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_art_pant_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop3.Heading = HHeading;
				if (prop3 != null)
				{
					LootSpawn.Add(prop3);
				}
				return prop;
			}
		}
		else
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop4 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop4.IsVisible = false;
				prop4.Heading = HHeading;
				if (prop4 != null)
				{
					GC2Spawn.Add(prop4);
				}
				Prop prop5 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_art_pant_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop5.Heading = HHeading;
				if (prop5 != null)
				{
					LootSpawn.Add(prop5);
				}
				return prop;
			}
		}
		return prop;
	}

	public static Prop DiamondCase(Vector3 pposition, float HHeading)
	{
		Model model = new Model("h4_prop_h4_glass_disp_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1, 2);
		int num2 = num;
		int num3 = num2;
		if (num3 == 1)
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop2 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop2.IsVisible = false;
				prop2.Heading = HHeading;
				if (prop2 != null)
				{
					GC2Spawn.Add(prop2);
				}
				Prop prop3 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_diamond_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1.2f), dynamic: false, placeOnGround: false);
				prop3.Heading = HHeading;
				if (prop3 != null)
				{
					LootSpawn.Add(prop3);
				}
				Prop prop4 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_diamond_disp_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop4.Heading = HHeading;
				if (prop4 != null)
				{
					LootStandSpawn.Add(prop4);
				}
				return prop;
			}
		}
		else
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop5 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop5.IsVisible = false;
				prop5.Heading = HHeading;
				if (prop5 != null)
				{
					GC2Spawn.Add(prop5);
				}
				Prop prop6 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_diamond_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1.2f), dynamic: false, placeOnGround: false);
				prop6.Heading = HHeading;
				if (prop6 != null)
				{
					LootSpawn.Add(prop6);
				}
				Prop prop7 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_diamond_disp_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop7.Heading = HHeading;
				if (prop7 != null)
				{
					LootStandSpawn.Add(prop7);
				}
				return prop;
			}
		}
		return prop;
	}

	public static Prop NecklaceCase(Vector3 pposition, float HHeading)
	{
		Model model = new Model("h4_prop_h4_glass_disp_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1, 2);
		int num2 = num;
		int num3 = num2;
		if (num3 == 1)
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop2 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop2.IsVisible = false;
				prop2.Heading = HHeading;
				if (prop2 != null)
				{
					GC2Spawn.Add(prop2);
				}
				Prop prop3 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_necklace_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1.2f), dynamic: false, placeOnGround: false);
				prop3.Heading = HHeading;
				if (prop3 != null)
				{
					LootSpawn.Add(prop3);
				}
				Prop prop4 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_neck_disp_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop4.Heading = HHeading;
				if (prop4 != null)
				{
					LootStandSpawn.Add(prop4);
				}
				return prop;
			}
		}
		else
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop5 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop5.IsVisible = false;
				prop5.Heading = HHeading;
				if (prop5 != null)
				{
					GC2Spawn.Add(prop5);
				}
				Prop prop6 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_necklace_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1.2f), dynamic: false, placeOnGround: false);
				prop6.Heading = HHeading;
				if (prop6 != null)
				{
					LootSpawn.Add(prop6);
				}
				Prop prop7 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_neck_disp_01a"), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop7.Heading = HHeading;
				if (prop7 != null)
				{
					LootStandSpawn.Add(prop7);
				}
				return prop;
			}
		}
		return prop;
	}

	public static Prop TequilaCase(Vector3 pposition, float HHeading)
	{
		Model model = new Model("h4_prop_h4_glass_disp_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		Random random = new Random();
		string[] array = new string[3] { "h4_prop_h4_t_bottle_01a", "h4_prop_h4_t_bottle_02a", "h4_prop_h4_t_bottle_02b" };
		int num = random.Next(array.Length);
		int num2 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 1, 2);
		int num3 = num2;
		int num4 = num3;
		if (num4 == 1)
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop2 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop2.IsVisible = false;
				prop2.Heading = HHeading;
				if (prop2 != null)
				{
					GC2Spawn.Add(prop2);
				}
				Prop prop3 = World.CreateProp(CruelMastersOnlineOffline.RequestModel(array[num]), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop3.Heading = HHeading;
				if (prop3 != null)
				{
					LootSpawn.Add(prop3);
				}
				return prop;
			}
		}
		else
		{
			model = new Model("h4_prop_h4_glass_disp_01a");
			model.Request(10000);
			if (model.IsValid && model.IsInCdImage)
			{
				while (!model.IsLoaded)
				{
					Script.Wait(50);
				}
				prop = World.CreateProp(model, pposition, new Vector3(0f, 0f, HHeading), dynamic: false, placeOnGround: false);
				if (prop != null)
				{
					GCSpawn.Add(prop);
				}
				Prop prop4 = World.CreateProp(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_glass_disp_01b"), pposition, dynamic: false, placeOnGround: false);
				prop4.IsVisible = false;
				prop4.Heading = HHeading;
				if (prop4 != null)
				{
					GC2Spawn.Add(prop4);
				}
				Prop prop5 = World.CreateProp(CruelMastersOnlineOffline.RequestModel(array[num]), new Vector3(pposition.X, pposition.Y, pposition.Z + 1f), dynamic: false, placeOnGround: false);
				prop5.Heading = HHeading;
				if (prop5 != null)
				{
					LootSpawn.Add(prop5);
				}
				return prop;
			}
		}
		return prop;
	}

	public static void SPAWN_CASE(Vector3 pposition, float HHeading, string loottype = "Random")
	{
		if (loottype == "Random")
		{
			Prop prop = RandomCase(pposition, HHeading + 180f);
		}
		if (loottype == "Panther Statue")
		{
			Prop prop2 = PantherCase(pposition, HHeading + 180f);
		}
		if (loottype == "Pink Diamond")
		{
			Prop prop3 = DiamondCase(pposition, HHeading + 180f);
		}
		if (loottype == "Ruby Necklace")
		{
			Prop prop4 = NecklaceCase(pposition, HHeading + 180f);
		}
		if (loottype == "Tequila")
		{
			Prop prop5 = TequilaCase(pposition, HHeading + 180f);
		}
	}

	public static int RETURN_LOOT_TYPE(Prop loot)
	{
		if (loot.Model == "h4_prop_h4_art_pant_01a")
		{
			return 0;
		}
		if (loot.Model == "h4_prop_h4_diamond_01a")
		{
			return 1;
		}
		if (loot.Model == "h4_prop_h4_necklace_01a")
		{
			return 2;
		}
		if (loot.Model == "h4_prop_h4_t_bottle_01a" || loot.Model == "h4_prop_h4_t_bottle_02a" || loot.Model == "h4_prop_h4_t_bottle_02b")
		{
			return 3;
		}
		return 0;
	}

	public static void drawSprite5(string textureDict, string textureName, float screenX, float screenY, float width, float height, int r, int g, int b, int alpha)
	{
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, textureDict, 0);
		if (Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, textureDict))
		{
			Function.Call(Hash.DRAW_SPRITE, textureDict, textureName, screenX, screenY, width, height, 0, r, g, b, alpha, 0);
		}
	}

	public static void drawText(string text, float x, float y, float scale, int r, int g, int b)
	{
		Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
		Function.Call(Hash.SET_TEXT_COLOUR, r, g, b, 255);
		Function.Call(Hash.SET_TEXT_SCALE, 0f, scale);
		Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, x, y, 0.1);
	}

	public static float progresswidth(float percent)
	{
		return 0.08f * percent;
	}

	public static float progressxcoord(float percent)
	{
		float num = 0.04f * percent;
		return 0.9f + num;
	}
}
