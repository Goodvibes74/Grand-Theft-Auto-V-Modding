using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Groups : Script
{
	public enum COMBAT_ATTRIBUTE_FLOATS
	{
		CCF_BLIND_FIRE_CHANCE,
		CCF_BURST_DURATION_IN_COVER,
		CCF_MAX_SHOOTING_DISTANCE,
		CCF_TIME_BETWEEN_BURSTS_IN_COVER,
		CCF_TIME_BETWEEN_PEEKS,
		CCF_STRAFE_WHEN_MOVING_CHANCE,
		CCF_WEAPON_ACCURACY,
		CCF_FIGHT_PROFICIENCY,
		CCF_WALK_WHEN_STRAFING_CHANCE,
		CCF_HELI_SPEED_MODIFIER,
		CCF_HELI_SENSES_RANGE,
		CCF_ATTACK_WINDOW_DISTANCE_FOR_COVER,
		CCF_TIME_TO_INVALIDATE_INJURED_TARGET,
		CCF_MIN_DISTANCE_TO_TARGET,
		CCF_BULLET_IMPACT_DETECTION_RANGE,
		CCF_AIM_TURN_THRESHOLD,
		CCF_OPTIMAL_COVER_DISTANCE,
		CCF_AUTOMOBILE_SPEED_MODIFIER,
		CCF_SPEED_TO_FLEE_IN_VEHICLE,
		CCF_TRIGGER_CHARGE_TIME_NEAR,
		CCF_TRIGGER_CHARGE_TIME_FAR,
		CCF_MAX_DISTANCE_TO_HEAR_EVENTS,
		CCF_MAX_DISTANCE_TO_HEAR_EVENTS_USING_LOS,
		CCF_HOMING_ROCKET_BREAK_LOCK_ANGLE,
		CCF_HOMING_ROCKET_BREAK_LOCK_ANGLE_CLOSE,
		CCF_HOMING_ROCKET_BREAK_LOCK_CLOSE_DISTANCE,
		CCF_HOMING_ROCKET_TURN_RATE_MODIFIER,
		CCF_TIME_BETWEEN_AGGRESSIVE_MOVES_DURING_VEHICLE_CHASE,
		CCF_MAX_VEHICLE_TURRET_FIRING_RANGE,
		CCF_WEAPON_DAMAGE_MODIFIER,
		MAX_COMBAT_FLOATS
	}

	public enum COMBAT_ATTRIBUTE
	{
		CA_INVALID = -1,
		CA_USE_COVER = 0,
		CA_USE_VEHICLE = 1,
		CA_DO_DRIVEBYS = 2,
		CA_LEAVE_VEHICLES = 3,
		CA_CAN_USE_DYNAMIC_STRAFE_DECISIONS = 4,
		CA_ALWAYS_FIGHT = 5,
		CA_FLEE_WHILST_IN_VEHICLE = 6,
		CA_JUST_FOLLOW_VEHICLE = 7,
		CA_PLAY_REACTION_ANIMS = 8,
		CA_WILL_SCAN_FOR_DEAD_PEDS = 9,
		CA_IS_A_GUARD = 10,
		CA_JUST_SEEK_COVER = 11,
		CA_BLIND_FIRE_IN_COVER = 12,
		CA_AGGRESSIVE = 13,
		CA_CAN_INVESTIGATE = 14,
		CA_CAN_USE_RADIO = 15,
		CA_CAN_CAPTURE_ENEMY_PEDS = 16,
		CA_ALWAYS_FLEE = 17,
		CA_CAN_TAUNT_IN_VEHICLE = 20,
		CA_CAN_CHASE_TARGET_ON_FOOT = 21,
		CA_WILL_DRAG_INJURED_PEDS_TO_SAFETY = 22,
		CA_REQUIRES_LOS_TO_SHOOT = 23,
		CA_USE_PROXIMITY_FIRING_RATE = 24,
		CA_DISABLE_SECONDARY_TARGET = 25,
		CA_DISABLE_ENTRY_REACTIONS = 26,
		CA_PERFECT_ACCURACY = 27,
		CA_CAN_USE_FRUSTRATED_ADVANCE = 28,
		CA_MOVE_TO_LOCATION_BEFORE_COVER_SEARCH = 29,
		CA_CAN_SHOOT_WITHOUT_LOS = 30,
		CA_MAINTAIN_MIN_DISTANCE_TO_TARGET = 31,
		CA_CAN_USE_PEEKING_VARIATIONS = 34,
		CA_DISABLE_PINNED_DOWN = 35,
		CA_DISABLE_PIN_DOWN_OTHERS = 36,
		CA_OPEN_COMBAT_WHEN_DEFENSIVE_AREA_IS_REACHED = 37,
		CA_DISABLE_BULLET_REACTIONS = 38,
		CA_CAN_BUST = 39,
		CA_IGNORED_BY_OTHER_PEDS_WHEN_WANTED = 40,
		CA_CAN_COMMANDEER_VEHICLES = 41,
		CA_CAN_FLANK = 42,
		CA_SWITCH_TO_ADVANCE_IF_CANT_FIND_COVER = 43,
		CA_SWITCH_TO_DEFENSIVE_IF_IN_COVER = 44,
		CA_CLEAR_PRIMARY_DEFENSIVE_AREA_WHEN_REACHED = 45,
		CA_CAN_FIGHT_ARMED_PEDS_WHEN_NOT_ARMED = 46,
		CA_ENABLE_TACTICAL_POINTS_WHEN_DEFENSIVE = 47,
		CA_DISABLE_COVER_ARC_ADJUSTMENTS = 48,
		CA_USE_ENEMY_ACCURACY_SCALING = 49,
		CA_CAN_CHARGE = 50,
		CA_REMOVE_AREA_SET_WILL_ADVANCE_WHEN_DEFENSIVE_AREA_REACHED = 51,
		CA_USE_VEHICLE_ATTACK = 52,
		CA_USE_VEHICLE_ATTACK_IF_VEHICLE_HAS_MOUNTED_GUNS = 53,
		CA_ALWAYS_EQUIP_BEST_WEAPON = 54,
		CA_CAN_SEE_UNDERWATER_PEDS = 55,
		CA_DISABLE_AIM_AT_AI_TARGETS_IN_HELIS = 56,
		CA_DISABLE_SEEK_DUE_TO_LINE_OF_SIGHT = 57,
		CA_DISABLE_FLEE_FROM_COMBAT = 58,
		CA_DISABLE_TARGET_CHANGES_DURING_VEHICLE_PURSUIT = 59,
		CA_CAN_THROW_SMOKE_GRENADE = 60,
		CA_CLEAR_AREA_SET_DEFENSIVE_IF_DEFENSIVE_CANNOT_BE_REACHED = 62,
		CA_DISABLE_BLOCK_FROM_PURSUE_DURING_VEHICLE_CHASE = 64,
		CA_DISABLE_SPIN_OUT_DURING_VEHICLE_CHASE = 65,
		CA_DISABLE_CRUISE_IN_FRONT_DURING_BLOCK_DURING_VEHICLE_CHASE = 66,
		CA_CAN_IGNORE_BLOCKED_LOS_WEIGHTING = 67,
		CA_DISABLE_REACT_TO_BUDDY_SHOT = 68,
		CA_PREFER_NAVMESH_DURING_VEHICLE_CHASE = 69,
		CA_ALLOWED_TO_AVOID_OFFROAD_DURING_VEHICLE_CHASE = 70,
		CA_PERMIT_CHARGE_BEYOND_DEFENSIVE_AREA = 71,
		CA_USE_ROCKETS_AGAINST_VEHICLES_ONLY = 72,
		CA_DISABLE_TACTICAL_POINTS_WITHOUT_CLEAR_LOS = 73,
		CA_DISABLE_PULL_ALONGSIDE_DURING_VEHICLE_CHASE = 74,
		CA_DISABLE_ALL_RANDOMS_FLEE = 78,
		CA_WILL_GENERATE_DEAD_PED_SEEN_SCRIPT_EVENTS = 79,
		CA_USE_MAX_SENSE_RANGE_WHEN_RECEIVING_EVENTS = 80,
		CA_RESTRICT_IN_VEHICLE_AIMING_TO_CURRENT_SIDE = 81,
		CA_USE_DEFAULT_BLOCKED_LOS_POSITION_AND_DIRECTION = 82,
		CA_REQUIRES_LOS_TO_AIM = 83,
		CA_CAN_CRUISE_AND_BLOCK_IN_VEHICLE = 84,
		CA_PREFER_AIR_COMBAT_WHEN_IN_AIRCRAFT = 85,
		CA_ALLOW_DOG_FIGHTING = 86,
		CA_PREFER_NON_AIRCRAFT_TARGETS = 87,
		CA_PREFER_KNOWN_TARGETS_WHEN_COMBAT_CLOSEST_TARGET = 88,
		CA_FORCE_CHECK_ATTACK_ANGLE_FOR_MOUNTED_GUNS = 89,
		CA_BLOCK_FIRE_FOR_VEHICLE_PASSENGER_MOUNTED_GUNS = 90
	}

	public static int AiTeam = World.AddRelationshipGroup("aiteam").Hash;

	public static int ExtrasTeam = World.AddRelationshipGroup("aiteam2").Hash;

	public static int playersTeam = Function.Call<int>(Hash.GET_HASH_KEY, "PLAYER");

	public static List<Ped> pedList = new List<Ped>();

	public static List<Ped> pedList2 = new List<Ped>();

	public static bool GangHassle = false;

	public Groups()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		Function.Call(Hash.SET_CUTSCENE_CAN_BE_SKIPPED, false);
		Function.Call(Hash.ENABLE_MOVIE_SUBTITLES, false);
		Audio.SetAudioFlag(AudioFlags.LoadMPData, toggle: true);
		Audio.SetAudioFlag(AudioFlags.WantedMusicDisabled, toggle: true);
		Audio.SetAudioFlag(AudioFlags.DisableFlightMusic, toggle: true);
		Function.Call(Hash.INVALIDATE_IDLE_CAM);
		Function.Call(Hash.INVALIDATE_CINEMATIC_VEHICLE_IDLE_MODE);
		if (Game.Player.Character.Model == PedHash.FreemodeMale01)
		{
			CruelMastersOnlineOffline.IsFreemodeFemale = false;
			CruelMastersOnlineOffline.IsFreemodeMale = true;
		}
		if (Game.Player.Character.Model == PedHash.FreemodeFemale01)
		{
			CruelMastersOnlineOffline.IsFreemodeMale = false;
			CruelMastersOnlineOffline.IsFreemodeFemale = true;
		}
		if (Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Trevor)
		{
			CruelMastersOnlineOffline.IsFreemodeMale = false;
			CruelMastersOnlineOffline.IsFreemodeFemale = false;
		}
		CheckEnemyPeds();
		if (CruelMastersOnlineOffline.NoCopsOnMission)
		{
			Game.Player.WantedLevel = 0;
			Function.Call(Hash.SET_MAX_WANTED_LEVEL, 0);
		}
		else if (!CruelMastersOnlineOffline.ManualMaxWantedLevel)
		{
			Function.Call(Hash.SET_MAX_WANTED_LEVEL, 5);
		}
		if (CruelMastersOnlineOffline.FuckOffCivilians)
		{
			Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0f);
			Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0f);
			Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0f);
			Function.Call(Hash.SET_AMBIENT_VEHICLE_RANGE_MULTIPLIER_THIS_FRAME, 0f);
		}
		if (!CruelMastersOnlineOffline.RadioAllowed)
		{
			if (Game.Player.Character.CurrentVehicle != null)
			{
				Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Game.Player.Character.CurrentVehicle, false);
			}
		}
		else if (Game.Player.Character.CurrentVehicle != null)
		{
			Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Game.Player.Character.CurrentVehicle, true);
		}
		if (CruelMastersOnlineOffline.OnMission)
		{
			if (!GangHassle)
			{
				Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 2, 1862763509, 296331235);
				Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 2, 1862763509, 1166638144);
				Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 2, 1862763509, 2037579709);
				Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 2, 1862763509, 2017343592);
				Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 2, 1862763509, -1821475077);
				Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 2, 1862763509, 1782292358);
				Function.Call(Hash.SET_PLAYER_CAN_BE_HASSLED_BY_GANGS, Game.Player, false);
				GangHassle = true;
			}
		}
		else if (GangHassle)
		{
			Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 255, 1862763509, 296331235);
			Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 255, 1862763509, 1166638144);
			Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 255, 1862763509, 2037579709);
			Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 255, 1862763509, 2017343592);
			Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 255, 1862763509, -1821475077);
			Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 255, 1862763509, 1782292358);
			Function.Call(Hash.SET_PLAYER_CAN_BE_HASSLED_BY_GANGS, Game.Player, true);
			GangHassle = false;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			RemoveEnemyPeds();
			RemoveEnemyPeds2();
		}
	}

	public static void SET_PED_COMBAT_ATTRIBUTES(Ped enemy, int attribute, bool enabled)
	{
		Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, enemy, attribute, enabled);
	}

	public static bool IS_PED_IN_GROUP(Ped ped, int groupId)
	{
		return Function.Call<bool>(Hash.IS_PED_GROUP_MEMBER, ped, groupId);
	}

	public static void SET_INTO_GROUP(Ped ped)
	{
		int num = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character);
		ped.RelationshipGroup = playersTeam;
		Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, ped, num);
		ped.NeverLeavesGroup = true;
		Function.Call(Hash.SET_GROUP_FORMATION_SPACING, num, 1f, 0.9f, 3f);
		Function.Call(Hash.SET_PED_CAN_TELEPORT_TO_GROUP_LEADER, ped, num, 1);
	}

	public static bool IS_PED_USING_ACTION_MODE(Ped player)
	{
		return Function.Call<bool>(Hash.IS_PED_USING_ACTION_MODE, player);
	}

	public static void SET_PED_STEALTH_MOVEMENT(Ped ped, int use = 0, int mode = 0)
	{
		Function.Call(Hash.SET_PED_USING_ACTION_MODE, ped, use, mode);
	}

	public static void SET_PED_USING_ACTION_MODE(Ped ped, bool use, string mode = "DEFAULT_ACTION")
	{
		Function.Call(Hash.SET_PED_USING_ACTION_MODE, ped, use, -1, mode);
	}

	public static void SET_PED_COMBAT_MOVEMENT_ABILITY(Ped ped, int combat_Movement, int combat_Ability)
	{
		Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, combat_Movement);
		Function.Call(Hash.SET_PED_COMBAT_ABILITY, ped, combat_Ability);
	}

	public static bool IS_PED_AT_DESTINATION(Ped ped, Vector3 destination, int distanceto)
	{
		return ped.Position.DistanceTo(destination) < (float)distanceto;
	}

	public static bool IS_PED_AT_DESTINATION_FLOAT(Ped ped, Vector3 destination, float distanceto)
	{
		return ped.Position.DistanceTo(destination) < distanceto;
	}

	public static bool HAS_PLAYER_TRIGGERED_COMBAT()
	{
		if (Game.Player.Character.IsShooting)
		{
			return true;
		}
		foreach (Ped ped in pedList)
		{
			if (Game.Player.Character.IsAiming && CanSee(ped, Game.Player.Character))
			{
				return true;
			}
			if (Function.Call<bool>(Hash.IS_PED_PERFORMING_MELEE_ACTION, Game.Player.Character) && CanSee(ped, Game.Player.Character))
			{
				return true;
			}
		}
		return false;
	}

	public static bool HAS_PLAYER_TRIGGERED_COMBAT_WITH_VEHICLE(Vehicle vehicle)
	{
		if (Game.Player.Character.IsShooting)
		{
			return true;
		}
		foreach (Ped ped in pedList)
		{
			if (Game.Player.Character.IsAiming && CanSee(ped, Game.Player.Character))
			{
				return true;
			}
			if (Function.Call<bool>(Hash.IS_PED_PERFORMING_MELEE_ACTION, Game.Player.Character) && CanSee(ped, Game.Player.Character))
			{
				return true;
			}
		}
		if (vehicle != null && Game.Player.Character.CurrentVehicle == vehicle)
		{
			return true;
		}
		return false;
	}

	public static bool CanSee(Entity _ent, Entity _target)
	{
		return Function.Call<bool>(Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY_IN_FRONT, _ent, _target);
	}

	public static void ArmEnemyPeds()
	{
		if (pedList.Count <= 0)
		{
			return;
		}
		foreach (Ped ped in pedList)
		{
			if (ped != null)
			{
				Function.Call(Hash.SET_PED_COMBAT_ABILITY, ped, 2);
				Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, 1);
				ped.Armor = 100;
			}
		}
	}

	public static void SetEnemyPedsParams(int shootrate, int accuracy, float health, float armor, bool criticalhits, bool canragdoll)
	{
		if (pedList.Count <= 0)
		{
			return;
		}
		foreach (Ped ped in pedList)
		{
			if (ped != null)
			{
				Function.Call(Hash.SET_PED_SHOOT_RATE, ped, shootrate);
				ped.Accuracy = accuracy;
				ped.HealthFloat = health;
				ped.ArmorFloat = armor;
				ped.CanSufferCriticalHits = criticalhits;
				ped.CanRagdoll = canragdoll;
			}
		}
	}

	public static void SetEnemyPedsConfig(int configflag, bool set)
	{
		if (pedList.Count <= 0)
		{
			return;
		}
		foreach (Ped ped in pedList)
		{
			if (ped != null)
			{
				Function.Call(Hash.SET_PED_CONFIG_FLAG, ped, configflag, set);
			}
		}
	}

	public static void GIVE_AI_RANDOM_WEAPON()
	{
		if (pedList.Count <= 0)
		{
			return;
		}
		foreach (Ped ped in pedList)
		{
			if (ped != null)
			{
				switch (Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, 7))
				{
				case 0:
					ped.Weapons.Give(WeaponHash.AdvancedRifle, 10000, equipNow: true, isAmmoLoaded: true);
					break;
				case 1:
					ped.Weapons.Give(WeaponHash.Pistol, 10000, equipNow: true, isAmmoLoaded: true);
					break;
				case 2:
					ped.Weapons.Give(WeaponHash.PumpShotgun, 10000, equipNow: true, isAmmoLoaded: true);
					break;
				case 3:
					ped.Weapons.Give(WeaponHash.AssaultSMG, 10000, equipNow: true, isAmmoLoaded: true);
					break;
				case 4:
					ped.Weapons.Give(WeaponHash.CarbineRifle, 10000, equipNow: true, isAmmoLoaded: true);
					break;
				case 5:
					ped.Weapons.Give(WeaponHash.SMG, 10000, equipNow: true, isAmmoLoaded: true);
					break;
				case 6:
					ped.Weapons.Give(WeaponHash.WM29Pistol, 10000, equipNow: true, isAmmoLoaded: true);
					break;
				}
			}
		}
	}

	public static void BlipUpEnemyPeds()
	{
		if (pedList.Count <= 0)
		{
			return;
		}
		foreach (Ped item in pedList.ToList())
		{
			if (!(item != null) || !item.IsAlive)
			{
				continue;
			}
			while (item.AttachedBlip == null)
			{
				item.AddBlip();
				Script.Yield();
			}
			if (item.AttachedBlip != null)
			{
				item.AttachedBlip.Sprite = BlipSprite.Enemy;
				if (item.Model == PedHash.Juggernaut01M)
				{
					item.AttachedBlip.Sprite = BlipSprite.TargetBusinessBattle;
				}
				Function.Call(Hash.SHOW_HEIGHT_ON_BLIP, item.AttachedBlip, true);
				item.AttachedBlip.Color = BlipColor.Red;
				item.AttachedBlip.Name = "Enemy";
				item.AttachedBlip.IsShortRange = true;
				item.AttachedBlip.DisplayType = BlipDisplayType.MiniMapOnly;
				item.AttachedBlip.Scale = 0.7f;
				item.RelationshipGroup = AiTeam;
			}
		}
	}

	public static void BlipUpEnemyPeds2()
	{
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item in pedList2)
		{
			if (item != null && item.IsAlive)
			{
				while (item.AttachedBlip == null)
				{
					item.AddBlip();
					Script.Yield();
				}
				item.AttachedBlip.Sprite = BlipSprite.Enemy;
				item.AttachedBlip.Color = BlipColor.Red;
				item.AttachedBlip.Name = "Enemy";
				item.RelationshipGroup = AiTeam;
			}
		}
	}

	public static void CheckEnemyPeds2()
	{
		if (pedList.Count > 0)
		{
			foreach (Ped item in pedList.ToList())
			{
				if (item != null && item.IsDead && item.AttachedBlip != null)
				{
					item.AttachedBlip.Delete();
				}
			}
		}
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item2 in pedList2.ToList())
		{
			if (item2 != null && item2.IsDead && item2.AttachedBlip != null)
			{
				item2.AttachedBlip.Delete();
			}
		}
	}

	public static void CheckEnemyPeds()
	{
		if (pedList.Count > 0)
		{
			foreach (Ped item in pedList.ToList())
			{
				if (!(item != null))
				{
					continue;
				}
				if (item.IsDead)
				{
					if (item.AttachedBlip != null)
					{
						item.AttachedBlip.Delete();
					}
					item.MarkAsNoLongerNeeded();
					pedList.Remove(item);
				}
				else if (Interiors.GET_INTERIOR_FROM_ENTITY(item) == Interiors.GET_INTERIOR_FROM_ENTITY(Game.Player.Character))
				{
					if (item.AttachedBlip != null)
					{
						item.AttachedBlip.Alpha = 255;
					}
				}
				else if (item.AttachedBlip != null)
				{
					item.AttachedBlip.Alpha = 0;
				}
			}
		}
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item2 in pedList2.ToList())
		{
			if (!(item2 != null))
			{
				continue;
			}
			if (item2.IsDead)
			{
				if (item2.AttachedBlip != null)
				{
					item2.AttachedBlip.Delete();
				}
			}
			else if (Interiors.GET_INTERIOR_FROM_ENTITY(item2) == Interiors.GET_INTERIOR_FROM_ENTITY(Game.Player.Character))
			{
				if (item2.AttachedBlip != null)
				{
					item2.AttachedBlip.Alpha = 255;
				}
			}
			else if (item2.AttachedBlip != null)
			{
				item2.AttachedBlip.Alpha = 0;
			}
		}
	}

	public static void ClearEnemyPedsList()
	{
		if (pedList.Count > 0)
		{
			foreach (Ped item in pedList.ToList())
			{
				if (item != null)
				{
					pedList.Remove(item);
				}
			}
		}
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item2 in pedList2.ToList())
		{
			if (item2 != null)
			{
				pedList2.Remove(item2);
			}
		}
	}

	public static void ClearEnemyPedsList2()
	{
		if (pedList.Count > 0)
		{
			foreach (Ped item in pedList.ToList())
			{
				if (item != null)
				{
					item.MarkAsNoLongerNeeded();
					pedList.Remove(item);
				}
			}
		}
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item2 in pedList2.ToList())
		{
			if (item2 != null)
			{
				item2.MarkAsNoLongerNeeded();
				pedList2.Remove(item2);
			}
		}
	}

	public static void RemoveEnemyPeds()
	{
		if (pedList.Count > 0)
		{
			foreach (Ped item in pedList.ToList())
			{
				if (item != null)
				{
					if (item.AttachedBlip != null)
					{
						item.AttachedBlip.Delete();
					}
					item.Delete();
					pedList.Remove(item);
				}
			}
		}
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item2 in pedList2.ToList())
		{
			if (item2 != null)
			{
				if (item2.AttachedBlip != null)
				{
					item2.AttachedBlip.Delete();
				}
				item2.Delete();
				pedList2.Remove(item2);
			}
		}
	}

	public static void RemoveEnemyPeds2()
	{
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item in pedList2.ToList())
		{
			if (item != null)
			{
				if (item.AttachedBlip != null)
				{
					item.AttachedBlip.Delete();
				}
				item.Delete();
				pedList2.Remove(item);
			}
		}
	}

	public static void TaskEnemyPeds()
	{
		if (pedList.Count <= 0)
		{
			return;
		}
		foreach (Ped item in pedList.ToList())
		{
			if (!(item != null))
			{
				continue;
			}
			foreach (Ped ped in pedList)
			{
				if (ped != null)
				{
					Function.Call(Hash.TASK_COMBAT_PED, ped, Game.Player.Character, -1);
					Function.Call(Hash.SET_COMBAT_FLOAT, ped, 5, 1f);
					Function.Call(Hash.SET_COMBAT_FLOAT, ped, 8, 1f);
					Function.Call(Hash.SET_PED_SPHERE_DEFENSIVE_AREA, ped, ped.Position.X, ped.Position.Y, ped.Position.Z, 10f, 1, 0);
					Function.Call(Hash.SET_PED_COMBAT_RANGE, ped, 1);
				}
			}
		}
	}

	public static void TaskEnemyPeds2()
	{
		if (pedList2.Count <= 0)
		{
			return;
		}
		foreach (Ped item in pedList2.ToList())
		{
			if (item != null)
			{
				item.Task.FightAgainst(Game.Player.Character);
				item.AlwaysKeepTask = true;
				item.BlockPermanentEvents = true;
			}
		}
	}

	public static void SPAWN_AI(PedHash pedmodel, Vector3 positiontospawn, float heading, WeaponHash weaponmodel, int armor, int accuracy, bool setascop, int combatability, int combatmovement, Relationship relation, bool AlwaysKeppTask, bool BlockPermenentEvents)
	{
		Ped ped = World.CreatePed(pedmodel, positiontospawn, heading);
		ped.Weapons.Give(weaponmodel, 10000, equipNow: true, isAmmoLoaded: true);
		ped.RelationshipGroup = AiTeam;
		ped.Armor = armor;
		ped.Accuracy = accuracy;
		Function.Call(Hash.SET_PED_AS_COP, ped, setascop);
		if (setascop)
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, ped, 0, 1, true);
		}
		Function.Call(Hash.SET_PED_COMBAT_ABILITY, ped, combatability);
		Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, combatmovement);
		CruelMastersOnlineOffline.SetRelationshipBetweenGroups(relation, AiTeam, playersTeam);
		CruelMastersOnlineOffline.SetRelationshipBetweenGroups(relation, playersTeam, AiTeam);
		ped.AlwaysKeepTask = AlwaysKeppTask;
		ped.BlockPermanentEvents = BlockPermenentEvents;
		ped.DropsEquippedWeaponOnDeath = false;
		Function.Call(Hash.SET_PED_LOD_MULTIPLIER, ped, 100f);
		while (!pedList.Contains(ped))
		{
			pedList.Add(ped);
			Script.Wait(0);
		}
	}

	public static void SPAWN_AI2(PedHash pedmodel, Vector3 positiontospawn, float heading, WeaponHash weaponmodel, int armor, int accuracy, bool setascop, int combatability, int combatmovement, Relationship relation, bool AlwaysKeppTask, bool BlockPermenentEvents)
	{
		Ped ped = World.CreatePed(pedmodel, positiontospawn, heading);
		ped.Weapons.Give(weaponmodel, 10000, equipNow: true, isAmmoLoaded: true);
		ped.RelationshipGroup = AiTeam;
		ped.Armor = armor;
		ped.Accuracy = accuracy;
		Function.Call(Hash.SET_PED_AS_COP, ped, setascop);
		if (setascop)
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, ped, 0, 1, true);
		}
		Function.Call(Hash.SET_PED_COMBAT_ABILITY, ped, combatability);
		Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, combatmovement);
		pedList2.Add(ped);
		CruelMastersOnlineOffline.SetRelationshipBetweenGroups(relation, AiTeam, playersTeam);
		CruelMastersOnlineOffline.SetRelationshipBetweenGroups(relation, playersTeam, AiTeam);
		ped.AlwaysKeepTask = AlwaysKeppTask;
		ped.BlockPermanentEvents = BlockPermenentEvents;
		ped.DropsEquippedWeaponOnDeath = false;
	}
}
