using System;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Crate_Grab : Script
{
	public static bool AllowCrateGrab = false;

	public static bool OwnsCrowbar = false;

	public static int ExtraLootSwitch = 1;

	public static int TotalAmount = 0;

	public static Prop Bag;

	public static Prop Crowbar;

	public static Prop Loot;

	public Crate_Grab()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
		if (!AllowCrateGrab)
		{
			return;
		}
		Prop[] allProps = World.GetAllProps(CruelMastersOnlineOffline.RequestModel("xm3_prop_xm3_crate_01a"));
		foreach (Prop item in allProps.ToList())
		{
			if (Props.propList.Count > 0 && Props.propList.Contains(item) && Game.Player.Character.Position.DistanceTo(item.Position) < 2f)
			{
				CRATE_GRAB_METHOD(item);
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			if (Bag != null)
			{
				Bag.Delete();
			}
			if (Crowbar != null)
			{
				Crowbar.Delete();
			}
			if (Loot != null)
			{
				Loot.Delete();
			}
		}
	}

	public unsafe static void CRATE_GRAB_METHOD(Prop loot)
	{
		switch (ExtraLootSwitch)
		{
		case 1:
		{
			if (!(Game.Player.Character.Position.DistanceTo(loot.Position) < 2f))
			{
				break;
			}
			if (!OwnsCrowbar)
			{
				Screen.ShowHelpTextThisFrame("Requires: Crowbar", beep: true);
			}
			else
			{
				Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to search the crate.", beep: true);
			}
			if (!Game.IsControlJustPressed(Control.Context) || !OwnsCrowbar)
			{
				break;
			}
			int num2 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 5);
			string dict = "anim@scripted@player@mission@trn_ig1_loot@male@";
			string text = "loot";
			if (num2 == 0 || num2 == 2 || num2 == 4)
			{
				dict = "anim@scripted@player@mission@trn_ig1_loot@male@";
				text = "loot";
			}
			if (num2 == 1 || num2 == 3)
			{
				dict = "anim@scripted@player@mission@trn_ig2_empty@male@";
				text = "empty";
			}
			Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
			CruelMastersOnlineOffline.LoadDict("anim@scripted@player@mission@trn_ig1_loot@male@");
			CruelMastersOnlineOffline.LoadDict("anim@scripted@player@mission@trn_ig2_empty@male@");
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_GENERIC_01");
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_FREEMODE_01");
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_GENERIC_01", false);
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_FREEMODE_01", false);
			Script.Wait(50);
			Vector3 vector = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_POSITION, "anim@scripted@player@mission@trn_ig1_loot@male@", "loot", loot.Position.X, loot.Position.Y, loot.Position.Z, loot.Rotation.X, loot.Rotation.Y, loot.Rotation.Z, 0f, 2);
			Vector3 vector2 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_ROTATION, "anim@scripted@player@mission@trn_ig1_loot@male@", "loot", loot.Position.X, loot.Position.Y, loot.Position.Z, loot.Rotation.X, loot.Rotation.Y, loot.Rotation.Z, 0f, 2);
			int num3 = 0;
			Function.Call(Hash.OPEN_SEQUENCE_TASK, &num3);
			if (Game.Player.Character.IsRunning || Game.Player.Character.IsSprinting)
			{
				Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 512, vector2.Z);
			}
			else
			{
				Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector.X, vector.Y, vector.Z, 1f, 5000, 0.1f, 2, vector2.Z);
			}
			Function.Call(Hash.CLOSE_SEQUENCE_TASK, num3);
			Function.Call(Hash.TASK_PERFORM_SEQUENCE, Game.Player.Character, num3);
			Function.Call(Hash.CLEAR_SEQUENCE_TASK, &num3);
			Script.Wait(500);
			Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
			HudHandler.HudandRadar(Hud: false, Radar: false);
			while (Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, Game.Player.Character) != -1)
			{
				Script.Wait(0);
			}
			while (Crowbar == null)
			{
				Crowbar = Function.Call<Prop>(Hash.CREATE_WEAPON_OBJECT, WeaponHash.Crowbar, 1, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, true, 1f, 0, 0, 0);
				Script.Wait(0);
			}
			Crowbar.IsCollisionEnabled = false;
			Crowbar.IsVisible = false;
			if (num2 == 0 || num2 == 2 || num2 == 4)
			{
				while (Loot == null)
				{
					Loot = World.CreateProp(CruelMastersOnlineOffline.RequestModel("xm3_prop_xm3_can_hl_01a"), Game.Player.Character.Position, dynamic: false, placeOnGround: false);
					Script.Wait(0);
				}
				Loot.IsCollisionEnabled = false;
				Loot.IsVisible = false;
			}
			int num4 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 4);
			if (CruelMastersOnlineOffline.CutsceneCam == null)
			{
				Vector3 position2 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, loot, 0.5f, -0.69f, 1.2f);
				CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(position2, new Vector3(0f, 0f, 0f), 60f);
			}
			if (CruelMastersOnlineOffline.CutsceneCam != null)
			{
				CruelMastersOnlineOffline.CutsceneCam.PointAt(Crowbar, new Vector3(0f, 0f, 0f));
				CruelMastersOnlineOffline.CutsceneCam.Shake(CameraShake.Hand, 1f);
				Cameras.RENDER_SCRIPT_CAMS(render: true, ease: false, 2000, p3: false, p4: false, p5: false);
			}
			CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, loot.Position.X, loot.Position.Y, loot.Position.Z, 0.0, 0.0, loot.Heading, 2);
			Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, CruelMastersOnlineOffline.LoadDict(dict), text, 0.0, 0.0, 0, 0, 1148846080, 0);
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Crowbar, CruelMastersOnlineOffline.TestCutsceneAnim, text + "_crowbar", CruelMastersOnlineOffline.LoadDict(dict), 1000f, 0f, 0, 1000f);
			if (Loot != null)
			{
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Loot, CruelMastersOnlineOffline.TestCutsceneAnim, text + "_can", CruelMastersOnlineOffline.LoadDict(dict), 1000f, 0f, 0, 1000f);
			}
			Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, loot, CruelMastersOnlineOffline.TestCutsceneAnim, text + "_crate", CruelMastersOnlineOffline.LoadDict(dict), 1000f, 0f, 0, 1000f);
			Function.Call(Hash.PLAY_FACIAL_ANIM, Game.Player.Character, text + "_facial", CruelMastersOnlineOffline.LoadDict(dict));
			Crowbar.IsVisible = true;
			if (Loot != null)
			{
				Loot.IsVisible = true;
			}
			while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) < 0.31f)
			{
				Script.Wait(0);
			}
			ExtraLootSwitch = 2;
			break;
		}
		case 2:
		{
			float num = 0.31f;
			while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) < 0.39f)
			{
				Screen.ShowHelpTextThisFrame("Repeatedly Press ~INPUT_ATTACK~ to break open the crate.", beep: true);
				Anims.SET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim, num);
				if (Game.IsControlPressed(Control.Attack))
				{
					num += 0.001f;
					CruelMastersOnlineOffline.CutsceneCam.FieldOfView += 0.2f;
				}
				else if (!Game.IsControlJustPressed(Control.Attack) && Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) > 0.31f)
				{
					num -= 0.00015f;
					if (CruelMastersOnlineOffline.CutsceneCam.FieldOfView >= 60f)
					{
						CruelMastersOnlineOffline.CutsceneCam.FieldOfView -= 0.2f;
					}
				}
				Script.Wait(0);
			}
			Anims.SET_SYNCHRONIZED_SCENE_RATE(CruelMastersOnlineOffline.TestCutsceneAnim, 1f);
			CruelMastersOnlineOffline.CutsceneCam.Delete();
			CruelMastersOnlineOffline.CutsceneCam = null;
			if (CruelMastersOnlineOffline.CutsceneCam == null)
			{
				Vector3 position = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, loot, 0f, 0.5f, 0.3f);
				CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(position, new Vector3(0f, 0f, 0f), 30f);
			}
			if (CruelMastersOnlineOffline.CutsceneCam != null)
			{
				CruelMastersOnlineOffline.CutsceneCam.PointAt(Game.Player.Character, new Vector3(0f, 0.5f, 0.5f));
				CruelMastersOnlineOffline.CutsceneCam.Shake(CameraShake.Hand, 1f);
				Cameras.RENDER_SCRIPT_CAMS(render: true, ease: false, 2000, p3: false, p4: false, p5: false);
			}
			while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) < 0.6f)
			{
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.CutsceneCam.Delete();
			CruelMastersOnlineOffline.CutsceneCam = null;
			while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) < 1f)
			{
				Script.Wait(0);
			}
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_GENERIC_01");
			Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_FREEMODE_01");
			Crowbar.Delete();
			Crowbar = null;
			if (Loot != null)
			{
				Loot.Delete();
				Loot = null;
				Heist_Hud.Actual_Take += Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 350000, 550000);
			}
			Game.Player.Character.Task.ClearAll();
			Cameras.RESET_GAMEPLAY_CAM();
			HudHandler.HudandRadar(Hud: true, Radar: true);
			ExtraLootSwitch = 1;
			if (loot.AttachedBlip != null)
			{
				loot.AttachedBlip.Delete();
			}
			loot.MarkAsNoLongerNeeded();
			Props.propList.Remove(loot);
			World.RenderingCamera = null;
			Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
			break;
		}
		}
	}
}
