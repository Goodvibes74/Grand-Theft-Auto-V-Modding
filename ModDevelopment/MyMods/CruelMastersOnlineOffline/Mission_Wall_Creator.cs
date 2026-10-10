using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Mission_Wall_Creator : Script
{
	public static bool WallInProgress;

	public static int MISSIONPASSED;

	public static float fVar1;

	public static float fVar9;

	public static float fVar10;

	public static float fVar20;

	public static float fVar21;

	public static float fVar22;

	public static int alpha;

	public Mission_Wall_Creator()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.DEBUG)
		{
			if (Game.IsControlJustPressed(Control.Context))
			{
			}
			if (!Game.IsControlJustPressed(Control.VehicleDuck))
			{
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}

	public unsafe static void DeleteMissionPassScaleform()
	{
		int mISSIONPASSED = MISSIONPASSED;
		Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &mISSIONPASSED);
		MISSIONPASSED = 0;
	}

	public static void RequestMissionPassScaleform()
	{
		Script.Yield();
		MISSIONPASSED = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MP_BIG_MESSAGE_FREEMODE");
	}

	public static void CallFunction(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
	}

	public static bool CallFunctionBool(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
		while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
		{
			Script.Yield();
		}
		return Function.Call<bool>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_BOOL, num);
	}

	public static int CallFunctionInt(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
		while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
		{
			Script.Yield();
		}
		return Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, num);
	}

	public static string CallFunctionString(int Handle, string name, params object[] args)
	{
		Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, name);
		pushArgs(args);
		int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
		while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
		{
			Script.Yield();
		}
		return Function.Call<string>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_STRING, num);
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

	public static float func_14613(float fParam0)
	{
		return fParam0 * 0.0013888889f;
	}

	public static float func_14607(float fParam0)
	{
		return fParam0 * 0.0009259259f;
	}

	public static float func_14612()
	{
		float result = 1f;
		if (Function.Call<bool>(Hash.IS_PC_VERSION))
		{
		}
		return result;
	}

	public static void SET_TEXT_LEFT()
	{
		fVar9 = 0.30500004f;
		fVar10 = 0.693f;
		Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, alpha);
		Function.Call(Hash.SET_TEXT_WRAP, fVar9, fVar10);
		Function.Call(Hash.SET_TEXT_JUSTIFICATION, 1);
		Function.Call(Hash.SET_TEXT_SCALE, 1f, 0.4f);
		Function.Call(Hash.SET_TEXT_CENTRE, false);
		Function.Call(Hash.SET_TEXT_FONT, 0);
	}

	public static void SET_TEXT_RIGHT()
	{
		fVar21 = 0.5f;
		fVar21 += 0.143f;
		fVar22 = fVar21;
		fVar22 -= 0.286f;
		Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, alpha);
		Function.Call(Hash.SET_TEXT_WRAP, fVar20, fVar21);
		Function.Call(Hash.SET_TEXT_JUSTIFICATION, 2);
		Function.Call(Hash.SET_TEXT_SCALE, 1f, 0.4f);
		Function.Call(Hash.SET_TEXT_CENTRE, false);
		Function.Call(Hash.SET_TEXT_FONT, 0);
	}

	public static void DISPLAY_WALL_TEMP()
	{
		WallInProgress = true;
		Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "HUD_321_GO", false, -1);
		DeleteMissionPassScaleform();
		Script.Wait(500);
		DeleteMissionPassScaleform();
		RequestMissionPassScaleform();
		Script.Wait(500);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "WINNER", "CELEBRATION_SOUNDSET", true);
		CallFunction(MISSIONPASSED, "SHOW_MISSION_PASSED_MESSAGE", "~w~Product Sold~w~", "Sell Mission", 100, true, 5, false, 2);
		Screen_Effects.PlayAnimPostFX("SuccessNeutral", 1000, looped: false);
		int num = Game.GameTime + 1000;
		while (Game.GameTime < num)
		{
			Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, MISSIONPASSED, 255, 255, 255, 255, 0);
			Script.Wait(0);
		}
		CallFunction(MISSIONPASSED, "TRANSITION_UP", 0.15f, true);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
		num = Game.GameTime + 400;
		while (Game.GameTime < num)
		{
			Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, MISSIONPASSED, 255, 255, 255, 255, 0);
			Script.Wait(0);
		}
		CallFunction(MISSIONPASSED, "ROLL_DOWN_BACKGROUND");
		alpha = 0;
		num = Game.GameTime + 13000;
		while (Game.GameTime < num)
		{
			if (alpha < 255)
			{
				alpha += 5;
			}
			Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, MISSIONPASSED, 255, 255, 255, 255, 0);
			fVar1 = 0.3f * func_14612();
			fVar1 -= func_14613(6f);
			fVar1 += func_14613(30f) - func_14613(4f);
			Function.Call(Hash.DRAW_RECT, 0.5f, fVar1 - (func_14613(1.5f) - 0.0013888889f), 0.3f, func_14607(1f), 255, 255, 255, alpha, false);
			fVar1 += func_14613(5f);
			SET_TEXT_LEFT();
			fVar20 = fVar9;
			fVar20 = fVar9 + 0.119f / func_14612() / 2.5f;
			Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
			Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Total Amount Sold");
			Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, fVar20, fVar1 + func_14613(4f), 0);
			SET_TEXT_RIGHT();
			Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "ESDOLLA");
			Function.Call(Hash.ADD_TEXT_COMPONENT_FORMATTED_INTEGER, 0, true);
			Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, fVar20, fVar1 + func_14613(4f), 0);
			fVar1 += func_14613(0.6f);
			fVar1 += func_14613(65f);
			fVar1 += func_14613(13f);
			fVar1 += func_14613(2f);
			Function.Call(Hash.DRAW_RECT, 0.5f, fVar1 + func_14613(1f), 0.3f, func_14607(1f), 255, 255, 255, alpha, false);
			Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, alpha);
			Function.Call(Hash.SET_TEXT_WRAP, fVar20, fVar21);
			Function.Call(Hash.SET_TEXT_JUSTIFICATION, 0);
			Function.Call(Hash.SET_TEXT_SCALE, 1f, 0.4f);
			Function.Call(Hash.SET_TEXT_CENTRE, false);
			Function.Call(Hash.SET_TEXT_FONT, 0);
			Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
			Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, "Your Final Take");
			Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.45f, fVar1 + func_14613(8f), 0);
			Function.Call(Hash.SET_TEXT_COLOUR, 255, 255, 255, alpha);
			Function.Call(Hash.SET_TEXT_WRAP, fVar20, fVar21);
			Function.Call(Hash.SET_TEXT_JUSTIFICATION, 0);
			Function.Call(Hash.SET_TEXT_SCALE, 1f, 0.4f);
			Function.Call(Hash.SET_TEXT_CENTRE, false);
			Function.Call(Hash.SET_TEXT_FONT, 0);
			Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "ESDOLLA");
			Function.Call(Hash.ADD_TEXT_COMPONENT_FORMATTED_INTEGER, 0, true);
			Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, 0.55f, fVar1 + func_14613(8f), 0);
			Script.Wait(0);
		}
		Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "HUD_321_GO");
		DeleteMissionPassScaleform();
		WallInProgress = false;
	}
}
