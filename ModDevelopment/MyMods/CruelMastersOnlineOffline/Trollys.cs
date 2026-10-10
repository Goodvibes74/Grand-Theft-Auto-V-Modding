using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Trollys : Script
{
	public static bool AllowTrollyGrab = false;

	public static int ExtraLootSwitch = 0;

	public static int CashAnim = 0;

	public static int SpeedSwitch = 0;

	public static int clickytimer = 0;

	public static int clickyint = 0;

	public static int TrollyAmount = 0;

	public static int PileAmount = 45;

	public static int TotalAmount = 0;

	public static float SCENE_POS = 0f;

	public static float SCENE_CASH_POS = 0f;

	public static float _polarAngleDeg = 0f;

	public static float _azimuthAngleDeg = 90f;

	public static float _radius = 1.4f;

	public static float currentheading = 0f;

	public static float _orbitAngle;

	public static Prop Bag;

	public static Prop Bar;

	public static List<Prop> TrollySpawn = new List<Prop>();

	public Trollys()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
		if (!AllowTrollyGrab)
		{
			return;
		}
		foreach (Prop item in TrollySpawn.ToList())
		{
			if (Groups.IS_PED_AT_DESTINATION(Game.Player.Character, item.Position, 1))
			{
				Trollys_Method(item);
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (Bag != null)
		{
			Bag.Delete();
		}
		if (Bar != null)
		{
			Bar.Delete();
		}
		RemoveTrollys();
	}

	public unsafe static void Trollys_Method(Prop Trolly)
	{
		if (CruelMastersOnlineOffline.CutsceneCam != null)
		{
			if (Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 0 || Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 1 || Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 2)
			{
				CamRotate();
				World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
			}
			if (Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 4)
			{
				World.RenderingCamera = null;
			}
		}
		string[] array = new string[3] { "ch_cash", "gold", "diamond" };
		string[] array2 = new string[3] { "a", "b", "c" };
		switch (ExtraLootSwitch)
		{
		case 0:
		{
			if (!(Game.Player.Character.Position.DistanceTo(Trolly.Position) < 1f))
			{
				break;
			}
			if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[2])
			{
				Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to begin grabbing the cash.");
			}
			if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[2])
			{
				Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to begin grabbing the gold.");
			}
			if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[2])
			{
				Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to begin grabbing the diamonds.");
			}
			if (!Game.IsControlJustPressed(Control.Context))
			{
				break;
			}
			SCENE_POS = 0f;
			SCENE_CASH_POS = 0f;
			Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
			CruelMastersOnlineOffline.LoadDict("anim@heists@ornate_bank@grab_cash");
			CruelMastersOnlineOffline.LoadDict("anim@heists@ornate_bank@grab_cash");
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_MPHEIST/HEIST_STASH_SWAG");
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_MPHEIST/HEIST_STASH_SWAG", false, -1);
			Script.Wait(50);
			Vector3 vector = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_POSITION, "anim@heists@ornate_bank@grab_cash", "intro", Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 0f, 2);
			Vector3 vector2 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_ROTATION, "anim@heists@ornate_bank@grab_cash", "intro", Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 0f, 2);
			int num = 0;
			Function.Call(Hash.OPEN_SEQUENCE_TASK, &num);
			if (Game.Player.Character.IsRunning || Game.Player.Character.IsSprinting)
			{
				Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 512, vector2.Z);
			}
			else
			{
				Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 2, vector2.Z);
			}
			Function.Call(Hash.CLOSE_SEQUENCE_TASK, num);
			Function.Call(Hash.TASK_PERFORM_SEQUENCE, Game.Player.Character, num);
			Function.Call(Hash.CLEAR_SEQUENCE_TASK, &num);
			Script.Wait(500);
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
			Bag.IsVisible = false;
			Bag.IsCollisionEnabled = false;
			Bag.IsPositionFrozen = true;
			Vector3 offsetPosition = Game.Player.Character.GetOffsetPosition(new Vector3(0f, 0.1f, 0f));
			Vector3 offsetPosition2 = Game.Player.Character.GetOffsetPosition(new Vector3(0.7f, 1.9f, 0.2f));
			Vector3 vector3 = polar3DToWorld3D(offsetPosition, _radius, _polarAngleDeg, _azimuthAngleDeg);
			while (CruelMastersOnlineOffline.CutsceneCam == null)
			{
				CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(vector3.X, vector3.Y, vector3.Z), new Vector3(0f, 0f, 0f), 50f);
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam.PointAt(offsetPosition);
			if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[2])
			{
				CruelMastersOnlineOffline.Potential_Cut = 2115000f;
				while (Bar == null)
				{
					Bar = World.CreateProp(CruelMastersOnlineOffline.RequestModel("hei_prop_heist_cash_pile"), new Vector3(2519.042f, -247.6816f, -66.20467f), dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
			}
			if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[2])
			{
				CruelMastersOnlineOffline.Potential_Cut = 2585000f;
				while (Bar == null)
				{
					Bar = World.CreateProp(CruelMastersOnlineOffline.RequestModel("ch_prop_gold_bar_01a"), new Vector3(2519.042f, -247.6816f, -66.20467f), dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
			}
			if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[2])
			{
				CruelMastersOnlineOffline.Potential_Cut = 3619000f;
				while (Bar == null)
				{
					Bar = World.CreateProp(CruelMastersOnlineOffline.RequestModel("ch_prop_vault_dimaondbox_01a"), new Vector3(2519.042f, -247.6816f, -66.20467f), dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
			}
			Bar.IsVisible = false;
			CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 2);
			Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@heists@ornate_bank@grab_cash", "intro", 1.0, 3.0, 0, 0, 1148846080, 0);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "bag_intro", "anim@heists@ornate_bank@grab_cash", 1.0, 3.0, 0, 1000f);
			Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Bar, Game.Player.Character, Function.Call<int>(Hash.GET_PED_BONE_INDEX, Game.Player.Character, 60309), 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
			Anims.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(Bar);
			CruelMastersOnlineOffline.GetPedDuffelBagOff(Game.Player.Character);
			Bag.IsCollisionEnabled = true;
			Bag.IsPositionFrozen = false;
			Bag.IsVisible = true;
			while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("anim@heists@ornate_bank@grab_cash"), "intro", 3))
			{
				if (Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 0 || Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 1 || Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 2)
				{
					CamRotate();
					GameplayCamera.RelativeHeading = CruelMastersOnlineOffline.CutsceneCam.Rotation.Z - Game.Player.Character.Heading;
					if (!Function.Call<bool>(Hash.IS_CAM_RENDERING, CruelMastersOnlineOffline.CutsceneCam))
					{
						Cameras.RENDER_SCRIPT_CAMS(render: true, ease: true, 2000, p3: false, p4: false, p5: false);
					}
				}
				if (Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) == 4)
				{
					World.RenderingCamera = null;
				}
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 2);
			Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@heists@ornate_bank@grab_cash", "grab_idle", 3.0, 3.0, 0, 0, 1148846080, 0);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "bag_grab_idle", "anim@heists@ornate_bank@grab_cash", 3.0, 3.0, 0, 1000f);
			Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
			SpeedSwitch = 1;
			ExtraLootSwitch = 2;
			break;
		}
		case 2:
			if (Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, "anim@heists@ornate_bank@grab_cash", "grab"))
			{
				SCENE_POS = Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim);
				SCENE_CASH_POS = Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CashAnim);
				if (clickyint < 7 && (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 237) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, 2, 201)))
				{
					clickyint++;
					clickytimer = Game.GameTime + 500;
				}
				if (clickyint > 0 && Game.GameTime > clickytimer)
				{
					clickyint--;
					clickytimer = Game.GameTime + 500;
				}
				switch (clickyint)
				{
				case 0:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 0.55f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 0.55);
					}
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 0.55f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 0.55);
					}
					break;
				case 1:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 0.6f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 0.6);
					}
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 0.6)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 0.6);
					}
					break;
				case 2:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 0.75f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 0.75);
					}
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 0.75)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 0.75);
					}
					break;
				case 3:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 0.9f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 0.9);
					}
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 0.9)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 0.9);
					}
					break;
				case 4:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 1f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 1.0);
					}
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 1.0)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 1.0);
					}
					break;
				case 5:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 1.05f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 1.05);
					}
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 1.05)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 1.05);
					}
					break;
				case 6:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 1.12f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 1.12);
					}
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 1.12)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 1.12);
					}
					break;
				case 7:
					if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) != 1.32f)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim, 1.32);
					}
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CashAnim) != 1.32)
					{
						Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, CashAnim, 1.32);
					}
					break;
				}
			}
			if (!Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, "anim@heists@ornate_bank@grab_cash", "grab"))
			{
				if (Game.IsControlJustPressed(Control.Attack))
				{
					CashAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 2);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Trolly, CashAnim, "cart_cash_dissapear", "anim@heists@ornate_bank@grab_cash", 3.0, 3.0, 0, 1000f);
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CashAnim, toggle: false);
					Anims.SET_SYNCHRONIZED_SCENE_PHASE(CashAnim, SCENE_CASH_POS);
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@heists@ornate_bank@grab_cash", "grab", 3.0, 3.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "bag_grab", "anim@heists@ornate_bank@grab_cash", 3.0, 3.0, 0, 1000f);
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
					Anims.SET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim, SCENE_POS);
				}
			}
			else if (!Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, "anim@heists@ornate_bank@grab_cash", "grab_idle") && Function.Call<bool>(Hash.HAS_ANIM_EVENT_FIRED, Game.Player.Character, Function.Call<Hash>(Hash.GET_HASH_KEY, "RELEASE_CASH_DESTROY")) && !Game.IsControlPressed(Control.Attack) && !Game.IsControlJustPressed(Control.Attack) && Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_RATE, CruelMastersOnlineOffline.TestCutsceneAnim) == 0.55f)
			{
				CashAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 2);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Trolly, CashAnim, "cart_cash_dissapear", "anim@heists@ornate_bank@grab_cash", 3.0, 3.0, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_PHASE(CashAnim, SCENE_CASH_POS);
				Anims.SET_SYNCHRONIZED_SCENE_RATE(CashAnim, 0f);
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@heists@ornate_bank@grab_cash", "grab_idle", 3.0, 3.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "bag_grab_idle", "anim@heists@ornate_bank@grab_cash", 3.0, 3.0, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
			}
			if (SCENE_CASH_POS >= 1f)
			{
				Heist_Hud.Actual_Take += TotalAmount / TrollyAmount / PileAmount;
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "LOCAL_PLYR_CASH_COUNTER_COMPLETE", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS", 1);
				SpeedSwitch = 0;
				if (Trolly.AttachedBlip != null)
				{
					Trolly.AttachedBlip.Delete();
				}
				Trolly.MarkAsNoLongerNeeded();
				TrollySpawn.Remove(Trolly);
				Bar.Delete();
				Bar = null;
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Trolly.Position.X, Trolly.Position.Y, Trolly.Position.Z, Trolly.Rotation.X, Trolly.Rotation.Y, Trolly.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@heists@ornate_bank@grab_cash", "exit", 3.0, 3.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "bag_exit", "anim@heists@ornate_bank@grab_cash", 3.0, 3.0, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
				Cameras.RENDER_SCRIPT_CAMS(render: false, ease: true, 2000, p3: false, p4: false, p5: false);
				GameplayCamera.RelativeHeading = CruelMastersOnlineOffline.CutsceneCam.Rotation.Z - Game.Player.Character.Heading;
				while (!Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("anim@heists@ornate_bank@grab_cash"), "exit", 3))
				{
					CamRotate();
					Script.Wait(0);
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_MPHEIST/HEIST_STASH_SWAG");
				CruelMastersOnlineOffline.CutsceneCam.Delete();
				CruelMastersOnlineOffline.CutsceneCam = null;
				CruelMastersOnlineOffline.GetPedDuffelBagOn(Game.Player.Character);
				Bag.Delete();
				Bag = null;
				Game.Player.Character.Task.ClearAll();
				HudHandler.HudandRadar(Hud: true, Radar: true);
				Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
				ExtraLootSwitch = 0;
			}
			break;
		}
		int speedSwitch = SpeedSwitch;
		int num2 = speedSwitch;
		if (num2 != 1)
		{
			return;
		}
		if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[0] + "_trolly_01" + array2[2])
		{
			Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the cash.");
		}
		if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[1] + "_trolly_01" + array2[2])
		{
			Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the gold.");
		}
		if (RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[0] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[1] || RETURN_LOOT_TYPE(Trolly) == "ch_prop_" + array[2] + "_trolly_01" + array2[2])
		{
			Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the diamonds.");
		}
		if (Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, "anim@heists@ornate_bank@grab_cash", "grab"))
		{
			if (Function.Call<bool>(Hash.HAS_ANIM_EVENT_FIRED, Game.Player.Character, Function.Call<Hash>(Hash.GET_HASH_KEY, "CASH_APPEAR")))
			{
				Function.Call(Hash.RELEASE_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET");
				Function.Call(Hash.SET_ENTITY_VISIBLE, Bar, true, 0);
			}
			if (Function.Call<bool>(Hash.HAS_ANIM_EVENT_FIRED, Game.Player.Character, Function.Call<Hash>(Hash.GET_HASH_KEY, "RELEASE_CASH_DESTROY")))
			{
				Heist_Hud.Actual_Take += TotalAmount / TrollyAmount / PileAmount;
				Function.Call(Hash.SET_ENTITY_VISIBLE, Bar, false, 0);
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
				Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "LOCAL_PLYR_CASH_COUNTER_INCREASE", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS", 1);
			}
		}
	}

	public static Prop RandomTrolly(Vector3 pposition, float HHeading)
	{
		string[] array = new string[3] { "ch_cash", "gold", "diamond" };
		int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 3);
		string[] array2 = new string[3] { "a", "b", "c" };
		int num2 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 3);
		Model model = new Model("ch_prop_ch_cash_trolly_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		model = new Model("ch_prop_" + array[num] + "_trolly_01" + array2[num2]);
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
				TrollySpawn.Add(prop);
			}
			return prop;
		}
		return prop;
	}

	public static Prop CashTrolly(Vector3 pposition, float HHeading)
	{
		string[] array = new string[3] { "a", "b", "c" };
		int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 3);
		Model model = new Model("ch_prop_ch_cash_trolly_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		model = new Model("ch_prop_ch_cash_trolly_01" + array[num]);
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
				TrollySpawn.Add(prop);
			}
			return prop;
		}
		return prop;
	}

	public static Prop GoldTrolly(Vector3 pposition, float HHeading)
	{
		string[] array = new string[3] { "a", "b", "c" };
		int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 3);
		Model model = new Model("ch_prop_gold_trolly_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		model = new Model("ch_prop_gold_trolly_01" + array[num]);
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
				TrollySpawn.Add(prop);
			}
			return prop;
		}
		return prop;
	}

	public static Prop DiamondTrolly(Vector3 pposition, float HHeading)
	{
		string[] array = new string[3] { "a", "b", "c" };
		int num = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 3);
		Model model = new Model("ch_prop_diamond_trolly_01a");
		Prop prop = World.CreatePropNoOffset(model, new Vector3(0f, 0f, 0f), dynamic: false);
		prop.MarkAsNoLongerNeeded();
		if (prop != null)
		{
			prop.Delete();
		}
		model = new Model("ch_prop_diamond_trolly_01" + array[num]);
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
				TrollySpawn.Add(prop);
			}
			return prop;
		}
		return prop;
	}

	public static void SPAWN_Trolly(Vector3 pposition, float HHeading, string loot = "Random")
	{
		if (loot == "Random")
		{
			Prop prop = RandomTrolly(pposition, HHeading);
		}
		if (loot == "Cash")
		{
			Prop prop2 = CashTrolly(pposition, HHeading);
		}
		if (loot == "Gold")
		{
			Prop prop3 = GoldTrolly(pposition, HHeading);
		}
		if (loot == "Diamond")
		{
			Prop prop4 = DiamondTrolly(pposition, HHeading);
		}
	}

	public static void RemoveTrollys()
	{
		if (TrollySpawn.Count > 0)
		{
			foreach (Prop item in TrollySpawn.ToList())
			{
				if (item != null)
				{
					item.Delete();
					TrollySpawn.Remove(item);
				}
			}
		}
		if (Bag != null)
		{
			Bag.Delete();
			Bag = null;
		}
		if (Bar != null)
		{
			Bar.Delete();
			Bar = null;
		}
		ExtraLootSwitch = 0;
	}

	public static Model RETURN_LOOT_TYPE(Prop loot)
	{
		return loot.Model;
	}

	public static void CamRotate()
	{
		float num = Function.Call<float>(Hash.GET_DISABLED_CONTROL_NORMAL, 0, 1);
		float num2 = Function.Call<float>(Hash.GET_DISABLED_CONTROL_NORMAL, 0, 2);
		_polarAngleDeg += num * 10f;
		if (_polarAngleDeg >= 360f)
		{
			_polarAngleDeg = 0f;
		}
		_azimuthAngleDeg += num2 * 10f;
		if (_azimuthAngleDeg >= 360f)
		{
			_azimuthAngleDeg = 0f;
		}
		Vector3 offsetPosition = Game.Player.Character.GetOffsetPosition(new Vector3(0f, 0.1f, 0f));
		Vector3 vector = polar3DToWorld3D(offsetPosition, _radius, _polarAngleDeg, _azimuthAngleDeg);
		World.RenderingCamera.Position = new Vector3(vector.X, vector.Y, vector.Z);
		World.RenderingCamera.PointAt(offsetPosition);
	}

	public static Vector3 polar3DToWorld3D(Vector3 entityPosition, float radius, float polarAngleDeg, float azimuthAngleDeg)
	{
		double num = (double)polarAngleDeg * Math.PI / 180.0;
		double num2 = (double)azimuthAngleDeg * Math.PI / 180.0;
		float x = entityPosition.X + radius * (float)(Math.Sin(num2) * Math.Cos(num));
		float y = entityPosition.Y - radius * (float)(Math.Sin(num2) * Math.Sin(num));
		float z = entityPosition.Z - radius * (float)Math.Cos(num2);
		return new Vector3(x, y, z);
	}

	public static void OnTickRotateChange(Prop Crate)
	{
		if (World.RenderingCamera != null && (Game.IsControlPressed(Control.LookRightOnly) || Game.IsControlPressed(Control.WeaponWheelLeftRight)))
		{
			_orbitAngle++;
			if (_orbitAngle >= 360f)
			{
				_orbitAngle = 0f;
			}
			Vector2 vector = RotateAround(Crate.Position, 2f, _orbitAngle);
			Vector3 offsetPosition = Crate.GetOffsetPosition(new Vector3(0f, 0f, 0.2f));
			World.RenderingCamera.Position = new Vector3(vector.X, vector.Y, offsetPosition.Z);
		}
		else if (World.RenderingCamera != null && Game.IsControlPressed(Control.LookLeftOnly))
		{
			_orbitAngle--;
			Vector2 vector2 = RotateAround(Crate.Position, 2f, _orbitAngle);
			Vector3 offsetPosition2 = Crate.GetOffsetPosition(new Vector3(0f, 0f, 0.2f));
			World.RenderingCamera.Position = new Vector3(vector2.X, vector2.Y, offsetPosition2.Z);
		}
	}

	public static Vector2 RotateAround(Vector3 entityPosition, float radius, float orbitAngle)
	{
		float x = entityPosition.X + radius * (float)Math.Cos((double)orbitAngle * Math.PI / 180.0);
		float y = entityPosition.Y - radius * (float)Math.Sin((double)orbitAngle * Math.PI / 180.0);
		return new Vector2(x, y);
	}

	public static float TO_FLOAT(int iParam0)
	{
		return Function.Call<float>(Hash.TO_FLOAT, iParam0);
	}
}
