using System;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Cash_Grab_New : Script
{
	public static int ExtraLootSwitch = 1;

	public static int CashAnim = 0;

	public static int SpeedSwitch = 0;

	public static int clickytimer = 0;

	public static int clickyint = 0;

	public static float SCENE_POS = 0f;

	public static float SCENE_CASH_POS = 0f;

	public static bool AllowCashGrab = false;

	public static Prop Bag;

	public Cash_Grab_New()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
		if (!AllowCashGrab)
		{
			return;
		}
		Prop[] allProps = World.GetAllProps(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_cash_stack_01a"));
		Prop[] allProps2 = World.GetAllProps(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_gold_stack_01a"));
		Prop[] allProps3 = World.GetAllProps(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_weed_stack_01a"));
		Prop[] allProps4 = World.GetAllProps(CruelMastersOnlineOffline.RequestModel("h4_prop_h4_coke_stack_01a"));
		foreach (Prop item in allProps.ToList())
		{
			if (Game.Player.Character.Position.DistanceTo(item.Position) < 1f)
			{
				CASH_GRAB_NEW_METHOD(item, "cash");
			}
		}
		foreach (Prop item2 in allProps2.ToList())
		{
			if (Game.Player.Character.Position.DistanceTo(item2.Position) < 1f)
			{
				CASH_GRAB_NEW_METHOD(item2, "gold");
			}
		}
		foreach (Prop item3 in allProps3.ToList())
		{
			if (Game.Player.Character.Position.DistanceTo(item3.Position) < 1f)
			{
				CASH_GRAB_NEW_METHOD(item3, "weed");
			}
		}
		foreach (Prop item4 in allProps4.ToList())
		{
			if (Game.Player.Character.Position.DistanceTo(item4.Position) < 1f)
			{
				CASH_GRAB_NEW_METHOD(item4, "coke");
			}
		}
	}

	public unsafe static void CASH_GRAB_NEW_METHOD(Prop Cash, string type)
	{
		switch (ExtraLootSwitch)
		{
		default:
			return;
		case 1:
		{
			if (!(Game.Player.Character.Position.DistanceTo(Cash.Position) < 1f))
			{
				return;
			}
			Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to start looting.");
			if (!Game.IsControlJustPressed(Control.Context))
			{
				return;
			}
			Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
			CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@");
			CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@");
			CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@gold@male@");
			CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@gold@male@");
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEIST3/HEIST_FINALE_STEAL_PAINTINGS", false);
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01", false);
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
			Script.Wait(50);
			if (type == "cash" || type == "weed" || type == "coke")
			{
				Vector3 vector = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_POSITION, "anim@scripted@heist@ig1_table_grab@cash@male@", "enter", Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 0f, 2);
				Vector3 vector2 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_ROTATION, "anim@scripted@heist@ig1_table_grab@cash@male@", "enter", Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 0f, 2);
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
			}
			else
			{
				Vector3 vector3 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_POSITION, "anim@scripted@heist@ig1_table_grab@gold@male@", "enter", Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 0f, 2);
				Vector3 vector4 = Function.Call<Vector3>(Hash.GET_ANIM_INITIAL_OFFSET_ROTATION, "anim@scripted@heist@ig1_table_grab@gold@male@", "enter", Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 0f, 2);
				int num2 = 0;
				Function.Call(Hash.OPEN_SEQUENCE_TASK, &num2);
				if (Game.Player.Character.IsRunning || Game.Player.Character.IsSprinting)
				{
					Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector3.X, vector3.Y, vector3.Z, 1f, 5000, 0.1f, 512, vector4.Z);
				}
				else
				{
					Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, 0, vector3.X, vector3.Y, vector3.Z, 1f, 5000, 0.1f, 2, vector4.Z);
				}
				Function.Call(Hash.CLOSE_SEQUENCE_TASK, num2);
				Function.Call(Hash.TASK_PERFORM_SEQUENCE, Game.Player.Character, num2);
				Function.Call(Hash.CLEAR_SEQUENCE_TASK, &num2);
				Script.Wait(500);
				while (Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, Game.Player.Character) != -1)
				{
					Script.Wait(0);
				}
			}
			SpeedSwitch = 0;
			SCENE_POS = 0f;
			Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
			while (Bag == null)
			{
				Bag = World.CreateProp(CruelMastersOnlineOffline.RequestModel("hei_p_m_bag_var22_arm_s"), Game.Player.Character.Position, dynamic: false, placeOnGround: false);
				Script.Wait(0);
			}
			Bag.IsCollisionEnabled = false;
			if (!(Bag != null))
			{
				return;
			}
			int num3 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 3);
			CruelMastersOnlineOffline.GetPedDuffelBagOff(Game.Player.Character);
			if (CruelMastersOnlineOffline.CutsceneCam == null)
			{
				switch (num3)
				{
				case 0:
				{
					Vector3 position3 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, Cash, -0.7f, -0.7f, 0.3f);
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(position3, new Vector3(0f, 0f, 0f), 60f);
					break;
				}
				case 1:
				{
					Vector3 position2 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, Cash, -0.5f, 0.5f, 1f);
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(position2, new Vector3(0f, 0f, 0f), 30f);
					break;
				}
				case 2:
				{
					Vector3 position = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, Cash, 0.6f, 0.6f, 1f);
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(position, new Vector3(0f, 0f, 0f), 36f);
					break;
				}
				}
			}
			if (CruelMastersOnlineOffline.CutsceneCam != null)
			{
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 3))
				{
				case 0:
					CruelMastersOnlineOffline.CutsceneCam.PointAt(Game.Player.Character, new Vector3(0f, 0f, 0f));
					break;
				case 1:
					CruelMastersOnlineOffline.CutsceneCam.PointAt(Cash, new Vector3(0f, 0f, 0f));
					break;
				case 2:
					CruelMastersOnlineOffline.CutsceneCam.PointAt(Bag, new Vector3(0f, 0f, 0f));
					break;
				}
				CruelMastersOnlineOffline.CutsceneCam.Shake(CameraShake.Hand, 1f);
				Cameras.RENDER_SCRIPT_CAMS(render: true, ease: true, 2000, p3: false, p4: false, p5: false);
			}
			if (Cash.Model == "h4_prop_h4_cash_stack_01a")
			{
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, 0.0, 0.0, Cash.Heading, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@"), "enter", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_bag", CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@"), 1000f, 0f, 0, 1000f);
			}
			else if (Cash.Model == "h4_prop_h4_gold_stack_01a")
			{
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, 0.0, 0.0, Cash.Heading, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@gold@male@"), "enter", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_bag", CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@gold@male@"), 1000f, 0f, 0, 1000f);
			}
			else if (Cash.Model == "h4_prop_h4_coke_stack_01a")
			{
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, 0.0, 0.0, Cash.Heading, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@"), "enter", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_bag", CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@"), 1000f, 0f, 0, 1000f);
			}
			else if (Cash.Model == "h4_prop_h4_weed_stack_01a")
			{
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, 0.0, 0.0, Cash.Heading, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@"), "enter", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "enter_bag", CruelMastersOnlineOffline.LoadDict("anim@scripted@heist@ig1_table_grab@cash@male@"), 1000f, 0f, 0, 1000f);
			}
			while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) < 1f)
			{
				Script.Wait(0);
			}
			if (type == "cash" || type == "weed" || type == "coke")
			{
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@scripted@heist@ig1_table_grab@cash@male@", "grab_idle", 3.0, 3.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "grab_idle_bag", "anim@scripted@heist@ig1_table_grab@cash@male@", 3.0, 3.0, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
			}
			else
			{
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@scripted@heist@ig1_table_grab@gold@male@", "grab_idle", 3.0, 3.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "grab_idle_bag", "anim@scripted@heist@ig1_table_grab@gold@male@", 3.0, 3.0, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: true);
			}
			ExtraLootSwitch = 2;
			return;
		}
		case 2:
			if (type == "cash")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the cash.");
			}
			if (type == "gold")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the gold.");
			}
			if (type == "weed")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the drugs.");
			}
			if (type == "coke")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the drugs.");
			}
			if (type == "cash" || type == "weed" || type == "coke")
			{
				if (Game.IsControlJustPressed(Control.Attack))
				{
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@scripted@heist@ig1_table_grab@cash@male@", "grab", 3.0, 3.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "grab_bag", "anim@scripted@heist@ig1_table_grab@cash@male@", 3.0, 3.0, 0, 1000f);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Cash, CruelMastersOnlineOffline.TestCutsceneAnim, "grab_cash", "anim@scripted@heist@ig1_table_grab@cash@male@", 3.0, 3.0, 0, 1000f);
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
					Anims.SET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim, SCENE_POS);
					ExtraLootSwitch = 3;
				}
			}
			else if (Game.IsControlJustPressed(Control.Attack))
			{
				CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@scripted@heist@ig1_table_grab@gold@male@", "grab", 3.0, 3.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "grab_bag", "anim@scripted@heist@ig1_table_grab@gold@male@", 3.0, 3.0, 0, 1000f);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Cash, CruelMastersOnlineOffline.TestCutsceneAnim, "grab_gold", "anim@scripted@heist@ig1_table_grab@gold@male@", 3.0, 3.0, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
				Anims.SET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim, SCENE_POS);
				ExtraLootSwitch = 3;
			}
			return;
		case 3:
			if (type == "cash")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the cash.");
			}
			if (type == "gold")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the gold.");
			}
			if (type == "weed")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the drugs.");
			}
			if (type == "coke")
			{
				Screen.ShowHelpTextThisFrame("Repeatedly tap ~INPUT_ATTACK~ to quickly grab the drugs.");
			}
			if (type == "cash" || type == "weed" || type == "coke")
			{
				if (Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, "anim@scripted@heist@ig1_table_grab@cash@male@", "grab"))
				{
					SCENE_POS = Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim);
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
				if (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) >= 1f)
				{
					Cameras.RESET_GAMEPLAY_CAM();
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					Cameras.RENDER_SCRIPT_CAMS(render: false, ease: true, 2000, p3: false, p4: false, p5: false);
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@scripted@heist@ig1_table_grab@cash@male@", "exit", 3.0, 3.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "exit_bag", "anim@scripted@heist@ig1_table_grab@cash@male@", 3.0, 3.0, 0, 1000f);
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
					Anims.SET_SYNCHRONIZED_SCENE_RATE(CruelMastersOnlineOffline.TestCutsceneAnim, 1f);
					ExtraLootSwitch = 4;
				}
			}
			else
			{
				if (Anims.IS_ENTITY_PLAYING_ANIM(Game.Player.Character, "anim@scripted@heist@ig1_table_grab@gold@male@", "grab"))
				{
					SCENE_POS = Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim);
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
				if (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) >= 1f)
				{
					Cameras.RESET_GAMEPLAY_CAM();
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					Cameras.RENDER_SCRIPT_CAMS(render: false, ease: true, 2000, p3: false, p4: false, p5: false);
					CruelMastersOnlineOffline.TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, Cash.Position.X, Cash.Position.Y, Cash.Position.Z, Cash.Rotation.X, Cash.Rotation.Y, Cash.Rotation.Z, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, CruelMastersOnlineOffline.TestCutsceneAnim, "anim@scripted@heist@ig1_table_grab@gold@male@", "exit", 3.0, 3.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Bag, CruelMastersOnlineOffline.TestCutsceneAnim, "exit_bag", "anim@scripted@heist@ig1_table_grab@gold@male@", 3.0, 3.0, 0, 1000f);
					Anims.SET_SYNCHRONIZED_SCENE_LOOPED(CruelMastersOnlineOffline.TestCutsceneAnim, toggle: false);
					Anims.SET_SYNCHRONIZED_SCENE_RATE(CruelMastersOnlineOffline.TestCutsceneAnim, 1f);
					ExtraLootSwitch = 4;
				}
			}
			if (type == "cash" || type == "weed" || type == "coke")
			{
				switch (SpeedSwitch)
				{
				case 0:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.0674)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 1;
					}
					break;
				case 1:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.185)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 2;
					}
					break;
				case 2:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.287)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 3;
					}
					break;
				case 3:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.374)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 4;
					}
					break;
				case 4:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.443)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 5;
					}
					break;
				case 5:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.535)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 6;
					}
					break;
				case 6:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.628)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 7;
					}
					break;
				case 7:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.754)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 8;
					}
					break;
				case 8:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.78)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 9;
					}
					break;
				case 9:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.862)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 10;
					}
					break;
				case 10:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.876)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 11;
					}
					break;
				case 11:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.948)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take += 7500;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 33218;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 12322;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 18341;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = 12;
					}
					break;
				case 12:
					if ((double)Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.9899)
					{
						if (type == "cash")
						{
							Heist_Hud.Actual_Take = Heist_Hud.Actual_Take;
						}
						if (type == "gold")
						{
							Heist_Hud.Actual_Take += 6;
						}
						if (type == "weed")
						{
							Heist_Hud.Actual_Take += 6;
						}
						if (type == "coke")
						{
							Heist_Hud.Actual_Take += 3;
						}
						Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
						SpeedSwitch = -1;
					}
					break;
				}
				return;
			}
			switch (SpeedSwitch)
			{
			case 0:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.09f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 1;
				}
				break;
			case 1:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.18f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 2;
				}
				break;
			case 2:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.202f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 3;
				}
				break;
			case 3:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.288f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 4;
				}
				break;
			case 4:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.409f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 5;
				}
				break;
			case 5:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.522f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 6;
				}
				break;
			case 6:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.614f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 7;
				}
				break;
			case 7:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.761f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 8;
				}
				break;
			case 8:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.797f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 9;
				}
				break;
			case 9:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.931f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take += 7500;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 33218;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take += 12322;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 18341;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 10;
				}
				break;
			case 10:
				if (Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, CruelMastersOnlineOffline.TestCutsceneAnim) >= 0.988f)
				{
					if (type == "cash")
					{
						Heist_Hud.Actual_Take = Heist_Hud.Actual_Take;
					}
					if (type == "gold")
					{
						Heist_Hud.Actual_Take += 6;
					}
					if (type == "weed")
					{
						Heist_Hud.Actual_Take = Heist_Hud.Actual_Take;
					}
					if (type == "coke")
					{
						Heist_Hud.Actual_Take += 6;
					}
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "ROBBERY_MONEY_TOTAL", "HUD_FRONTEND_CUSTOM_SOUNDSET", 1);
					SpeedSwitch = 11;
				}
				break;
			}
			return;
		case 4:
			break;
		}
		while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(CruelMastersOnlineOffline.TestCutsceneAnim) < 1f)
		{
			Script.Wait(0);
		}
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEIST3/HEIST_FINALE_STEAL_PAINTINGS");
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01");
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET");
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_FRONTEND_CUSTOM_SOUNDSET");
		CruelMastersOnlineOffline.GetPedDuffelBagOn(Game.Player.Character);
		Bag.Delete();
		Bag = null;
		Game.Player.Character.Task.ClearAll();
		ExtraLootSwitch = 1;
		Cash.Delete();
		Props.propList.Remove(Cash);
		Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, false);
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (Bag != null)
		{
			Bag.Delete();
		}
	}
}
