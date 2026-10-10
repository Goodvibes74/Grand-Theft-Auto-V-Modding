using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

public static class SCRIPT_HUD
{
	public static void REQUEST_SCALEFORM_SCRIPT_HUD_MOVIE(int hudcomp)
	{
		Function.Call(Hash.REQUEST_SCALEFORM_SCRIPT_HUD_MOVIE, hudcomp);
	}

	public static void REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE(int hudcomp)
	{
		Function.Call(Hash.REMOVE_SCALEFORM_SCRIPT_HUD_MOVIE, hudcomp);
	}

	public static bool HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED(int hudcomp)
	{
		return Function.Call<bool>(Hash.HAS_SCALEFORM_SCRIPT_HUD_MOVIE_LOADED, hudcomp);
	}

	public static bool IS_SCRIPTED_HUD_COMPONENT_ACTIVE(int hudcomp)
	{
		return Function.Call<bool>(Hash.IS_SCRIPTED_HUD_COMPONENT_ACTIVE, hudcomp);
	}

	public static void HIDE_SCRIPTED_HUD_COMPONENT_THIS_FRAME(int hudcomp)
	{
		Function.Call(Hash.HIDE_SCRIPTED_HUD_COMPONENT_THIS_FRAME, hudcomp);
	}

	public static void SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME(int hudcomp)
	{
		Function.Call(Hash.SHOW_SCRIPTED_HUD_COMPONENT_THIS_FRAME, hudcomp);
	}

	public static bool IS_SCRIPTED_HUD_COMPONENT_HIDDEN_THIS_FRAME(int hudcomp)
	{
		return Function.Call<bool>(Hash.IS_SCRIPTED_HUD_COMPONENT_HIDDEN_THIS_FRAME, hudcomp);
	}

	public static void CallHudFunction(int hudcomp, string name, params object[] args)
	{
		while (!Function.Call<bool>(Hash.BEGIN_SCALEFORM_SCRIPT_HUD_MOVIE_METHOD, hudcomp, name))
		{
			Script.Wait(0);
		}
		pushArgs(args);
		Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
	}

	public static void pushArgs(object[] args)
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
}
