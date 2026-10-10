using System;
using System.Drawing;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class RESPAWN : Script
{
	public enum Spawnpointflags
	{
		SPAWNPOINTS_FLAG_DEFAULT = 0,
		SPAWNPOINTS_FLAG_MAY_SPAWN_IN_INTERIOR = 1,
		SPAWNPOINTS_FLAG_MAY_SPAWN_IN_EXTERIOR = 2,
		SPAWNPOINTS_FLAG_ALLOW_NOT_NETWORK_SPAWN_CANDIDATE_POLYS = 4,
		SPAWNPOINTS_FLAG_ALLOW_ISOLATED_POLYS = 8,
		SPAWNPOINTS_FLAG_ALLOW_ROAD_POLYS = 0x10,
		SPAWNPOINTS_FLAG_ONLY_POINTS_AGAINST_EDGES = 0x20
	}

	public static Vector3 misrespawn = new Vector3(0f, 0f, 0f);

	public static float misrespawnhead = 0f;

	public static int miswantedlevel = 0;

	public static bool misretask = false;

	public RESPAWN()
	{
		Tick += onTick;
		Aborted += OnShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!CruelMastersOnlineOffline.OnMission)
		{
			TriggerDeath();
		}
		else
		{
			TriggerDeathMission2(misrespawn, misrespawnhead, Function.Call<int>(Hash.GET_CLOCK_HOURS), Function.Call<int>(Hash.GET_CLOCK_MINUTES), Function.Call<int>(Hash.GET_CLOCK_SECONDS), miswantedlevel, misretask);
		}
	}

	public unsafe static void TriggerDeath()
	{
		int num = Game.GameTime + 2000;
		bool flag = false;
		if (!Game.Player.Character.IsDead || !Game.Player.Character.IsDead)
		{
			return;
		}
		Vector3 vector = Game.Player.Character.Position;
		int num2 = 0;
		int num3 = 2;
		float num4 = 150f;
		if (Interiors.GET_INTERIOR_FROM_ENTITY(Game.Player.Character) != 0)
		{
			num4 = 150f;
			num3 = 1;
		}
		if (Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_ACTIVE))
		{
			Function.Call(Hash.SPAWNPOINTS_CANCEL_SEARCH);
			if (CruelMastersOnlineOffline.DEBUG)
			{
				Notification.Show("Search Canceled");
			}
		}
		Function.Call(Hash.SPAWNPOINTS_START_SEARCH, vector.X, vector.Y, vector.Z, num4, 5f, (Spawnpointflags)num3, 2f, 20000);
		if (CruelMastersOnlineOffline.DEBUG)
		{
			Notification.Show("Search Started");
		}
		while (!Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_COMPLETE))
		{
			if (CruelMastersOnlineOffline.DEBUG)
			{
				Notification.Show("Searching");
			}
			Script.Wait(0);
		}
		num2 = Function.Call<int>(Hash.SPAWNPOINTS_GET_NUM_SEARCH_RESULTS);
		int num5 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, num2);
		Function.Call(Hash.SPAWNPOINTS_GET_SEARCH_RESULT, num5, &vector.X, &vector.Y, &vector.Z);
		if (CruelMastersOnlineOffline.DEBUG)
		{
			Notification.Show($"Search Complete : Spots:{num2} Spot Chosen:{num5}, X{vector.X}, Y{vector.Y}, Z{vector.Z}");
		}
		if (Game.Player.Character.IsInWater)
		{
			if (Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_ACTIVE))
			{
				Function.Call(Hash.SPAWNPOINTS_CANCEL_SEARCH);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Search Canceled");
				}
			}
			OutputArgument outputArgument = new OutputArgument();
			if (Function.Call<bool>(Hash.GET_SAFE_COORD_FOR_PED, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, false, outputArgument, 0))
			{
				vector = outputArgument.GetResult<Vector3>();
			}
		}
		if (num2 == 0)
		{
			vector = Game.Player.Character.Position;
		}
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "OFFMISSION_WASTED");
		Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "OFFMISSION_WASTED", false, -1);
		Function.Call(Hash.START_AUDIO_SCENE, "DEATH_SCENE");
		Script.Wait(50);
		Scaleform scaleform = new Scaleform("MP_BIG_MESSAGE_FREEMODE");
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "MP_Flash", "WastedSounds", true);
		GameplayCamera.Shake(CameraShake.DeathFail, 1.5f);
		Screen_Effects.PlayAnimPostFX("DeathFailMPIn", 0, looped: false);
		int red = 255;
		int num6 = 0;
		int num7 = 0;
		while (!Screen.IsFadedOut)
		{
			if (Game.GameTime > num)
			{
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 3);
				scaleform.CallFunction("SHOW_SHARD_WASTED_MP_MESSAGE", ToColorHexString(Color.FromArgb(255, red, num6, num7), "WASTED"), "", 0, true, true);
				scaleform.Render2D();
				if (!flag)
				{
					Screen_Effects.SET_TRANSITION_TIMECYCLE_MODIFIER("NG_deathfail_BW_base", 10f);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "TextHit", "WastedSounds", true);
					flag = true;
				}
				else
				{
					if (num6 < 255)
					{
						num6 += 5;
					}
					if (num7 < 255)
					{
						num7 += 5;
					}
				}
			}
			Script.Yield();
		}
		while (!Screen.IsFadingIn)
		{
			Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 3);
			scaleform.CallFunction("SHOW_SHARD_WASTED_MP_MESSAGE", ToColorHexString(Color.FromArgb(255, red, num6, num7), "WASTED"), "", 0, true, true);
			scaleform.Render2D();
			Script.Yield();
		}
		Game.Player.Character.Position = new Vector3(vector.X, vector.Y, vector.Z - 1f);
		Function.Call(Hash.STOP_AUDIO_SCENE, "DEATH_SCENE");
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "OFFMISSION_WASTED");
		scaleform.Dispose();
		Screen.StopEffects();
		Screen_Effects.StopAllAnimPostFX();
		Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
		GameplayCamera.StopShaking();
		HudHandler.HudandRadar(Hud: true, Radar: true);
		Screen.FadeIn(500);
	}

	public static void TriggerDeathMission2(Vector3 playerrespawnpoint, float heading, int hours, int minutes, int seconds, int wantedlevel, bool retaskpeds)
	{
		int num = Game.GameTime + 2000;
		bool flag = false;
		if (!Game.Player.Character.IsDead)
		{
			return;
		}
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "OFFMISSION_WASTED");
		Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "OFFMISSION_WASTED", false, -1);
		Function.Call(Hash.START_AUDIO_SCENE, "DEATH_SCENE");
		Script.Wait(50);
		Scaleform scaleform = new Scaleform("MP_BIG_MESSAGE_FREEMODE");
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "MP_Flash", "WastedSounds", true);
		GameplayCamera.Shake(CameraShake.DeathFail, 1.5f);
		Screen_Effects.PlayAnimPostFX("DeathFailMPIn", 0, looped: false);
		int red = 255;
		int num2 = 0;
		int num3 = 0;
		while (!Screen.IsFadedOut)
		{
			if (Game.GameTime > num)
			{
				scaleform.CallFunction("SHOW_SHARD_WASTED_MP_MESSAGE", ToColorHexString(Color.FromArgb(255, red, num2, num3), "WASTED"), "", 0, true, true);
				scaleform.Render2D();
				if (!flag)
				{
					Screen_Effects.SET_TRANSITION_TIMECYCLE_MODIFIER("NG_deathfail_BW_base", 10f);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "TextHit", "WastedSounds", true);
					flag = true;
				}
				else
				{
					if (num2 < 255)
					{
						num2 += 5;
					}
					if (num3 < 255)
					{
						num3 += 5;
					}
				}
			}
			Script.Yield();
		}
		while (!Screen.IsFadingIn)
		{
			scaleform.CallFunction("SHOW_SHARD_WASTED_MP_MESSAGE", ToColorHexString(Color.FromArgb(255, red, num2, num3), "WASTED"), "", 0, true, true);
			scaleform.Render2D();
			Script.Yield();
		}
		Function.Call(Hash.STOP_AUDIO_SCENE, "DEATH_SCENE");
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "OFFMISSION_WASTED");
		scaleform.Dispose();
		Function.Call(Hash.SET_CLOCK_TIME, hours, minutes, seconds);
		Screen.StopEffects();
		Screen_Effects.StopAllAnimPostFX();
		Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
		GameplayCamera.StopShaking();
		HudHandler.HudandRadar(Hud: true, Radar: true);
		playerrespawnpoint.Z--;
		Game.Player.Character.Position = playerrespawnpoint;
		Game.Player.Character.Heading = heading;
		GameplayCamera.RelativeHeading = heading - Game.Player.Character.Heading;
		Game.Player.WantedLevel = wantedlevel;
		Screen.FadeIn(500);
		if (retaskpeds)
		{
			Groups.TaskEnemyPeds();
		}
	}

	public static void SET_MIS_STAT(Vector3 misrespawnpos, float misrespawnheadnum, int miswantedlevelnum, bool misretaskbool)
	{
		misrespawn = misrespawnpos;
		misrespawnhead = misrespawnheadnum;
		miswantedlevel = miswantedlevelnum;
		misretask = misretaskbool;
	}

	public void OnShutdown(object sender, EventArgs e)
	{
		if (true && Function.Call<bool>(Hash.SPAWNPOINTS_IS_SEARCH_ACTIVE))
		{
			Function.Call(Hash.SPAWNPOINTS_CANCEL_SEARCH);
		}
	}

	public static string ColorToHex(Color color)
	{
		return $"{color.R:X2}{color.G:X2}{color.B:X2}";
	}

	public static string ToColorHexString(Color thisColor, string text)
	{
		return "<FONT COLOR='#" + ColorToHex(thisColor) + "'>" + text + "</FONT>";
	}
}
