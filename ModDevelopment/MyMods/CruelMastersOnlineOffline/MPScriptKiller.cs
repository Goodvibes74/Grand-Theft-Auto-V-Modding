using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPScriptKiller : Script
{
	public static bool Run_Kill;

	public MPScriptKiller()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (Game.IsControlJustPressed(Control.Context))
		{
		}
		if (!Run_Kill)
		{
			Run_Kill = true;
		}
		if (CruelMastersOnlineOffline.ContinueCOO && !Game.IsLoading && !Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE) && !Screen.IsFadingIn)
		{
			if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "atm_trigger"))
			{
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "atm_trigger");
			}
			if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "re_atmrobbery"))
			{
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_atmrobbery");
			}
			if (Function.Call<bool>(Hash.DOES_SCRIPT_EXIST, "vehicle_gen_controller"))
			{
				Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "vehicle_gen_controller");
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}

	public static int GET_SCRIPT_TO_SCRIPTS(string scripttokill)
	{
		int result = 0;
		int num = Game.GameTime + 5000;
		bool flag = false;
		Function.Call(Hash.SCRIPT_THREAD_ITERATOR_RESET);
		return result;
	}

	public static void KILL_THIS_SCRIPT(int threadID)
	{
		if (Function.Call<bool>(Hash.IS_THREAD_ACTIVE, threadID))
		{
			if (CruelMastersOnlineOffline.DEBUG)
			{
				Notification.Show("terminated this script thread");
			}
			Function.Call(Hash.TERMINATE_THREAD, threadID);
		}
	}
}
