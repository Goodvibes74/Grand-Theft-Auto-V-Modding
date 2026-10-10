using System;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPVendingMachines : Script
{
	public static string Dict = "MINI@SPRUNK";

	public static int SodaSwitch = 0;

	public static Prop SodaCan;

	private Prop[] alleColaMachines = World.GetAllProps(992069095);

	private Prop[] allSprunkMachines = World.GetAllProps(1114264700);

	private Prop[] allJunkMachines = World.GetAllProps(-1103205386);

	public MPVendingMachines()
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
		if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "ob_vend1"))
		{
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "ob_vend1");
		}
		if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "ob_vend2"))
		{
			Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "ob_vend2");
		}
		int i = 0;
		for (alleColaMachines = World.GetAllProps(992069095); i < alleColaMachines.Length; i++)
		{
			if (!(alleColaMachines[i] != null))
			{
				continue;
			}
			Vector3 position = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, alleColaMachines[i], 0f, -1f, -1f);
			if (!(Game.Player.Character.Position.DistanceTo(position) < 1.1f))
			{
				continue;
			}
			if (MPCash.Cash > 0)
			{
				switch (SodaSwitch)
				{
				case 0:
					Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to buy a soda for $1.", beep: false);
					if (Game.IsControlJustPressed(Control.Context))
					{
						if (SodaCan != null)
						{
							SodaCan.Delete();
							SodaCan = null;
						}
						Weapons.Anim_Weapon_Off();
						Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, true, 0);
						Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
						Game.Player.Character.IsInvincible = true;
						if (Function.Call<bool>(Hash.IS_PED_WEARING_HELMET, Game.Player.Character))
						{
							Function.Call(Hash.REMOVE_PED_HELMET, Game.Player.Character, true);
						}
						Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, Game.Player.Character, false, "DEFAULT_ACTION");
						Function.Call(Hash.SET_PED_USING_ACTION_MODE, Game.Player.Character, false, -1, "DEFAULT_ACTION");
						Function.Call(Hash.RELEASE_AMBIENT_AUDIO_BANK);
						Function.Call(Hash.REQUEST_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Script.Wait(500);
						if (GameplayCamera.IsFirstPersonAimCamActive)
						{
							Dict = "MINI@SPRUNK@FIRST_PERSON";
						}
						else
						{
							Dict = "MINI@SPRUNK";
						}
						CruelMastersOnlineOffline.LoadDict(Dict);
						Script.Wait(50);
						Function.Call(Hash.HINT_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Function.Call(Hash.TASK_LOOK_AT_ENTITY, Game.Player.Character, alleColaMachines[i], 2000, 2048, 2);
						Function.Call(Hash.SET_PED_RESET_FLAG, Game.Player.Character, 322, true);
						Function.Call(Hash.TASK_GO_STRAIGHT_TO_COORD, Game.Player.Character, position.X, position.Y, position.Z, 1f, 2500, alleColaMachines[i].Heading, 0.1f);
						int num = Game.GameTime + 2500;
						while (Game.GameTime < num)
						{
							Script.Wait(0);
						}
						if (Game.Player.Character.Position.DistanceTo(position) > 1.1f)
						{
							Game.Player.Character.Position = new Vector3(position.X, position.Y, position.Z);
							Game.Player.Character.Heading = alleColaMachines[i].Heading;
						}
						Game.Player.Character.Task.ClearAll();
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1", 2f, -4f, -1, 1048576, 0f, false, false, false);
						MPCash.REMOVE_CASH(1);
						SodaSwitch = 1;
					}
					break;
				case 1:
					if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1", 3))
					{
						break;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1") < 0.31f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Screen.ShowHelpTextThisFrame(string.Format("{0}", Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1")), beep: false);
						}
						Vector3 vector = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, alleColaMachines[i], 0f, -0.97f, 0.05f);
						while (SodaCan == null)
						{
							SodaCan = Function.Call<Prop>(Hash.CREATE_OBJECT_NO_OFFSET, CruelMastersOnlineOffline.RequestModel("prop_ecola_can"), vector.X, vector.Y, vector.Z, true, false, false);
							Script.Wait(0);
						}
						SodaCan.IsVisible = false;
						Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, SodaCan, Game.Player.Character, Function.Call<int>(Hash.GET_PED_BONE_INDEX, Game.Player.Character, 28422), 0f, 0f, 0f, 0f, 0f, 0f, true, true, false, false, 2, true, 0);
					}
					else if (SodaCan != null)
					{
						SodaCan.IsVisible = true;
					}
					if (Function.Call<bool>(Hash.DOES_ENTITY_EXIST, SodaCan) && Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1") > 0.98f)
					{
						Game.Player.Character.Task.ClearAll();
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2", 4f, -1000f, -1, 16, 0f, false, 2052, false);
						Function.Call(Hash.FORCE_PED_AI_AND_ANIMATION_UPDATE, Game.Player.Character, false, false);
						SodaSwitch = 2;
					}
					break;
				case 2:
					if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2", 3) && Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2") > 0.98f && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 3))
					{
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 1000f, -4f, -1, 16, 0f, false, 2048, false);
						Function.Call(Hash.FORCE_PED_AI_AND_ANIMATION_UPDATE, Game.Player.Character, false, false);
						SodaSwitch = 3;
					}
					break;
				case 3:
					if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 3))
					{
						break;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.1f)
					{
						Game.Player.Character.Health = 200;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.306f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Notification.Show("Can Threw", blinking: true);
						}
						if (SodaCan != null)
						{
							Function.Call(Hash.DETACH_ENTITY, SodaCan, true, true);
							Function.Call(Hash.APPLY_FORCE_TO_ENTITY, SodaCan, 1, 6f, 10f, 2f, 0f, 0f, 0f, 0, true, true, false, false, true);
							SodaCan.MarkAsNoLongerNeeded();
							SodaCan = null;
						}
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.306f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Notification.Show("Anim Finished", blinking: true);
						}
						Game.Player.Character.IsInvincible = false;
						Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Character, false);
						if (Function.Call<bool>(Hash.REQUEST_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1))
						{
							Function.Call(Hash.RELEASE_AMBIENT_AUDIO_BANK);
						}
						Function.Call(Hash.HINT_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Function.Call(Hash.SET_PED_RESET_FLAG, Game.Player.Character, 322, false);
						SodaSwitch = 0;
					}
					break;
				}
			}
			else
			{
				Screen.ShowHelpTextThisFrame("You don't have enough money to use the machine.", beep: false);
			}
		}
		i = 0;
		for (allSprunkMachines = World.GetAllProps(1114264700); i < allSprunkMachines.Length; i++)
		{
			if (!(allSprunkMachines[i] != null))
			{
				continue;
			}
			Vector3 position2 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, allSprunkMachines[i], 0f, -1f, -1f);
			if (!(Game.Player.Character.Position.DistanceTo(position2) < 1.1f))
			{
				continue;
			}
			if (MPCash.Cash > 0)
			{
				switch (SodaSwitch)
				{
				case 0:
					Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to buy a soda for $1.", beep: false);
					if (Game.IsControlJustPressed(Control.Context))
					{
						if (SodaCan != null)
						{
							SodaCan.Delete();
							SodaCan = null;
						}
						Weapons.Anim_Weapon_Off();
						Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, true, 0);
						Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
						Game.Player.Character.IsInvincible = true;
						if (Function.Call<bool>(Hash.IS_PED_WEARING_HELMET, Game.Player.Character))
						{
							Function.Call(Hash.REMOVE_PED_HELMET, Game.Player.Character, true);
						}
						Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, Game.Player.Character, false, "DEFAULT_ACTION");
						Function.Call(Hash.SET_PED_USING_ACTION_MODE, Game.Player.Character, false, -1, "DEFAULT_ACTION");
						Function.Call(Hash.RELEASE_AMBIENT_AUDIO_BANK);
						Function.Call(Hash.REQUEST_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Script.Wait(500);
						if (GameplayCamera.IsFirstPersonAimCamActive)
						{
							Dict = "MINI@SPRUNK@FIRST_PERSON";
						}
						else
						{
							Dict = "MINI@SPRUNK";
						}
						CruelMastersOnlineOffline.LoadDict(Dict);
						Script.Wait(50);
						Function.Call(Hash.HINT_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Function.Call(Hash.TASK_LOOK_AT_ENTITY, Game.Player.Character, allSprunkMachines[i], 2000, 2048, 2);
						Function.Call(Hash.SET_PED_RESET_FLAG, Game.Player.Character, 322, true);
						Function.Call(Hash.TASK_GO_STRAIGHT_TO_COORD, Game.Player.Character, position2.X, position2.Y, position2.Z, 1f, 2500, allSprunkMachines[i].Heading, 0.1f);
						int num2 = Game.GameTime + 2500;
						while (Game.GameTime < num2)
						{
							Script.Wait(0);
						}
						if (Game.Player.Character.Position.DistanceTo(position2) > 1.1f)
						{
							Game.Player.Character.Position = new Vector3(position2.X, position2.Y, position2.Z);
							Game.Player.Character.Heading = allSprunkMachines[i].Heading;
						}
						Game.Player.Character.Task.ClearAll();
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1", 2f, -4f, -1, 1048576, 0f, false, false, false);
						MPCash.REMOVE_CASH(1);
						SodaSwitch = 1;
					}
					break;
				case 1:
					if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1", 3))
					{
						break;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1") < 0.31f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Screen.ShowHelpTextThisFrame(string.Format("{0}", Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1")), beep: false);
						}
						Vector3 vector2 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, allSprunkMachines[i], 0f, -0.97f, 0.05f);
						while (SodaCan == null)
						{
							SodaCan = Function.Call<Prop>(Hash.CREATE_OBJECT_NO_OFFSET, CruelMastersOnlineOffline.RequestModel("prop_ld_can_01b"), vector2.X, vector2.Y, vector2.Z, true, false, false);
							Script.Wait(0);
						}
						SodaCan.IsVisible = false;
						Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, SodaCan, Game.Player.Character, Function.Call<int>(Hash.GET_PED_BONE_INDEX, Game.Player.Character, 28422), 0f, 0f, 0f, 0f, 0f, 0f, true, true, false, false, 2, true, 0);
					}
					else if (SodaCan != null)
					{
						SodaCan.IsVisible = true;
					}
					if (Function.Call<bool>(Hash.DOES_ENTITY_EXIST, SodaCan) && Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1") > 0.98f)
					{
						Game.Player.Character.Task.ClearAll();
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2", 4f, -1000f, -1, 16, 0f, false, 2052, false);
						Function.Call(Hash.FORCE_PED_AI_AND_ANIMATION_UPDATE, Game.Player.Character, false, false);
						SodaSwitch = 2;
					}
					break;
				case 2:
					if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2", 3) && Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2") > 0.98f && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 3))
					{
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 1000f, -4f, -1, 16, 0f, false, 2048, false);
						Function.Call(Hash.FORCE_PED_AI_AND_ANIMATION_UPDATE, Game.Player.Character, false, false);
						SodaSwitch = 3;
					}
					break;
				case 3:
					if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 3))
					{
						break;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.1f)
					{
						Game.Player.Character.Health = 200;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.306f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Notification.Show("Can Threw", blinking: true);
						}
						if (SodaCan != null)
						{
							Function.Call(Hash.DETACH_ENTITY, SodaCan, true, true);
							Function.Call(Hash.APPLY_FORCE_TO_ENTITY, SodaCan, 1, 6f, 10f, 2f, 0f, 0f, 0f, 0, true, true, false, false, true);
							SodaCan.MarkAsNoLongerNeeded();
							SodaCan = null;
						}
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.306f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Notification.Show("Anim Finished", blinking: true);
						}
						Game.Player.Character.IsInvincible = false;
						Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Character, false);
						if (Function.Call<bool>(Hash.REQUEST_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1))
						{
							Function.Call(Hash.RELEASE_AMBIENT_AUDIO_BANK);
						}
						Function.Call(Hash.HINT_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Function.Call(Hash.SET_PED_RESET_FLAG, Game.Player.Character, 322, false);
						SodaSwitch = 0;
					}
					break;
				}
			}
			else
			{
				Screen.ShowHelpTextThisFrame("You don't have enough money to use the machine.", beep: false);
			}
		}
		i = 0;
		for (allJunkMachines = World.GetAllProps(-1103205386); i < allJunkMachines.Length; i++)
		{
			if (!(allJunkMachines[i] != null))
			{
				continue;
			}
			Vector3 position3 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, allJunkMachines[i], 0f, -1f, 0f);
			if (!(Game.Player.Character.Position.DistanceTo(position3) < 1.1f))
			{
				continue;
			}
			if (MPCash.Cash > 0)
			{
				switch (SodaSwitch)
				{
				case 0:
					Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to buy a soda for $1.", beep: false);
					if (Game.IsControlJustPressed(Control.Context))
					{
						if (SodaCan != null)
						{
							SodaCan.Delete();
							SodaCan = null;
						}
						Weapons.Anim_Weapon_Off();
						Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, true, 0);
						Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player, true);
						Game.Player.Character.IsInvincible = true;
						if (Function.Call<bool>(Hash.IS_PED_WEARING_HELMET, Game.Player.Character))
						{
							Function.Call(Hash.REMOVE_PED_HELMET, Game.Player.Character, true);
						}
						Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, Game.Player.Character, false, "DEFAULT_ACTION");
						Function.Call(Hash.SET_PED_USING_ACTION_MODE, Game.Player.Character, false, -1, "DEFAULT_ACTION");
						Function.Call(Hash.RELEASE_AMBIENT_AUDIO_BANK);
						Function.Call(Hash.REQUEST_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Script.Wait(500);
						if (GameplayCamera.IsFirstPersonAimCamActive)
						{
							Dict = "MINI@SPRUNK@FIRST_PERSON";
						}
						else
						{
							Dict = "MINI@SPRUNK";
						}
						CruelMastersOnlineOffline.LoadDict(Dict);
						Script.Wait(50);
						Function.Call(Hash.HINT_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Function.Call(Hash.TASK_LOOK_AT_ENTITY, Game.Player.Character, allJunkMachines[i], 2000, 2048, 2);
						Function.Call(Hash.SET_PED_RESET_FLAG, Game.Player.Character, 322, true);
						Function.Call(Hash.TASK_GO_STRAIGHT_TO_COORD, Game.Player.Character, position3.X, position3.Y, position3.Z, 1f, 2500, allJunkMachines[i].Heading, 0.1f);
						int num3 = Game.GameTime + 2500;
						while (Game.GameTime < num3)
						{
							Script.Wait(0);
						}
						if (Game.Player.Character.Position.DistanceTo(position3) > 1.1f)
						{
							Game.Player.Character.Position = new Vector3(position3.X, position3.Y, position3.Z);
							Game.Player.Character.Heading = allJunkMachines[i].Heading;
						}
						Game.Player.Character.Task.ClearAll();
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1", 2f, -4f, -1, 1048576, 0f, false, false, false);
						MPCash.REMOVE_CASH(1);
						SodaSwitch = 1;
					}
					break;
				case 1:
					if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1", 3))
					{
						break;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1") < 0.31f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Screen.ShowHelpTextThisFrame(string.Format("{0}", Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1")), beep: false);
						}
						Vector3 vector3 = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, allJunkMachines[i], 0f, -0.97f, 1f);
						while (SodaCan == null)
						{
							SodaCan = Function.Call<Prop>(Hash.CREATE_OBJECT_NO_OFFSET, CruelMastersOnlineOffline.RequestModel("sf_prop_sf_can_01a"), vector3.X, vector3.Y, vector3.Z, true, false, false);
							Script.Wait(0);
						}
						SodaCan.IsVisible = false;
						Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, SodaCan, Game.Player.Character, Function.Call<int>(Hash.GET_PED_BONE_INDEX, Game.Player.Character, 28422), 0f, 0f, 0f, 0f, 0f, 0f, true, true, false, false, 2, true, 0);
					}
					else if (SodaCan != null)
					{
						SodaCan.IsVisible = true;
					}
					if (Function.Call<bool>(Hash.DOES_ENTITY_EXIST, SodaCan) && Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT1") > 0.98f)
					{
						Game.Player.Character.Task.ClearAll();
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2", 4f, -1000f, -1, 16, 0f, false, 2052, false);
						Function.Call(Hash.FORCE_PED_AI_AND_ANIMATION_UPDATE, Game.Player.Character, false, false);
						SodaSwitch = 2;
					}
					break;
				case 2:
					if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2", 3) && Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT2") > 0.98f && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 3))
					{
						Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 1000f, -4f, -1, 16, 0f, false, 2048, false);
						Function.Call(Hash.FORCE_PED_AI_AND_ANIMATION_UPDATE, Game.Player.Character, false, false);
						SodaSwitch = 3;
					}
					break;
				case 3:
					if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3", 3))
					{
						break;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.1f)
					{
						Game.Player.Character.Health = 200;
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.306f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Notification.Show("Can Threw", blinking: true);
						}
						if (SodaCan != null)
						{
							Function.Call(Hash.DETACH_ENTITY, SodaCan, true, true);
							Function.Call(Hash.APPLY_FORCE_TO_ENTITY, SodaCan, 1, 6f, 10f, 2f, 0f, 0f, 0f, 0, true, true, false, false, true);
							SodaCan.MarkAsNoLongerNeeded();
							SodaCan = null;
						}
					}
					if (Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, Dict, "PLYR_BUY_DRINK_PT3") > 0.306f)
					{
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Notification.Show("Anim Finished", blinking: true);
						}
						Game.Player.Character.IsInvincible = false;
						Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Character, false);
						if (Function.Call<bool>(Hash.REQUEST_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1))
						{
							Function.Call(Hash.RELEASE_AMBIENT_AUDIO_BANK);
						}
						Function.Call(Hash.HINT_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", false, -1);
						Function.Call(Hash.SET_PED_RESET_FLAG, Game.Player.Character, 322, false);
						SodaSwitch = 0;
					}
					break;
				}
			}
			else
			{
				Screen.ShowHelpTextThisFrame("You don't have enough money to use the machine.", beep: false);
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (SodaCan != null)
		{
			SodaCan.Delete();
		}
	}
}
