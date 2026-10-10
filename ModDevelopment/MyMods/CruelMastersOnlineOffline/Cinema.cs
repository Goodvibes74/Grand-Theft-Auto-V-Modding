using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Cinema : Script
{
	public enum VehicleNames
	{
		CAR,
		PLANE,
		TRAILER,
		QUADBIKE,
		HELI,
		AUTOGYRO,
		BIKE,
		BICYCLE,
		BOAT,
		TRAIN,
		SUBMARINE,
		ALL
	}

	public enum CamShakeType
	{
		GRENADE_EXPLOSION_SHAKE,
		gameplay_explosion_shake,
		SMALL_EXPLOSION_SHAKE,
		HAND_SHAKE,
		jolt_SHAKE,
		LARGE_EXPLOSION_SHAKE,
		MEDIUM_EXPLOSION_SHAKE,
		ROAD_VIBRATION_SHAKE,
		SKY_DIVING_SHAKE,
		VIBRATE_SHAKE,
		DRUNK_SHAKE,
		CLUB_DANCE_SHAKE,
		DRONE_BOOST_SHAKE,
		GUNRUNNING_ENGINE_STOP_SHAKE,
		GUNRUNNING_ENGINE_START_SHAKE,
		GUNRUNNING_LOOP_SHAKE,
		GUNRUNNING_BUMP_SHAKE,
		PLANE_PART_SPEED_SHAKE,
		HIGH_FALL_SHAKE,
		FAMILY5_DRUG_TRIP_SHAKE,
		DEATH_FAIL_IN_EFFECT_SHAKE
	}

	private TextElement myUIText;

	public static bool CinemaActive = false;

	public static float CinemaBars = 2f;

	public static string Cutscene = "";

	public static int ChapterSwitch = 0;

	public static bool[] ChapterActive = new bool[4];

	public Cinema()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CinemaActive)
		{
			DrawBlackBars(CinemaBars);
		}
		if (Cutscene != "" && !Game.IsControlJustPressed(Control.Jump) && !Game.IsControlJustPressed(Control.Attack))
		{
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (1 == 0)
		{
		}
	}

	public static void DrawBlackBars(float height)
	{
		float num = 0.5f * height;
		Function.Call(Hash.DRAW_RECT, 0.5f, num, 1f, height, 0, 0, 0, 255);
		float num2 = 1f - 0.5f * height;
		Function.Call(Hash.DRAW_RECT, 0.5f, num2, 1f, height, 0, 0, 0, 255);
	}

	public static void CinematicShot(int duration, Entity entity, int VehicleNames)
	{
		Function.Call(Hash.CREATE_CINEMATIC_SHOT, -1096069633, duration, VehicleNames, entity);
	}

	public static void ShakeCinematicShot(string shaketype, float intensity)
	{
		Function.Call(Hash.SHAKE_CINEMATIC_CAM, shaketype, intensity);
	}

	public static void Fuck_Off_Idle_Cam()
	{
		Function.Call(Hash.INVALIDATE_IDLE_CAM);
	}

	public static bool IS_CINEMATIC_CAM_RENDERING()
	{
		return Function.Call<bool>(Hash.IS_CINEMATIC_CAM_RENDERING);
	}

	public static bool IS_CINEMATIC_CAM_SHAKING()
	{
		return Function.Call<bool>(Hash.IS_CINEMATIC_CAM_SHAKING);
	}

	public static bool IS_CINEMATIC_CAM_ACTIVE()
	{
		return Function.Call<bool>(Hash.IS_CINEMATIC_CAM_INPUT_ACTIVE);
	}

	public static float CAM_SPLINE_PHASE(Camera camera)
	{
		return Function.Call<float>(Hash.GET_CAM_SPLINE_NODE_PHASE, camera);
	}

	public static float GET_CAM_ANIM_CURRENT_PHASE(Camera cam)
	{
		return Function.Call<float>(Hash.GET_CAM_ANIM_CURRENT_PHASE, cam);
	}

	public static void SET_CUTSCENE(string cutscene)
	{
		Cutscene = cutscene;
	}

	public static void CLEAR_CUTSCENE()
	{
		Cutscene = "";
	}
}
