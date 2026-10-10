using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class ONSCREEN_KEYBOARD : Script
{
	public static int Keyboard_Control = -1;

	public static int Keyboardreturnint = 0;

	public static string Keyboardreturn = "";

	public ONSCREEN_KEYBOARD()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (Keyboard_Control == 0)
		{
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (1 == 0)
		{
		}
	}

	public static string GetUserInput(string windowTitle, string defaultText, int maxLength)
	{
		MPPause.CAN_PAUSE_GAME = false;
		Function.Call(Hash.DISABLE_ALL_CONTROL_ACTIONS, 2);
		Function.Call(Hash.DISPLAY_ONSCREEN_KEYBOARD, true, windowTitle, 0, defaultText, 0, 0, 0, maxLength + 1);
		while (Function.Call<int>(Hash.UPDATE_ONSCREEN_KEYBOARD) == 0)
		{
			Script.Yield();
		}
		Function.Call(Hash.ENABLE_ALL_CONTROL_ACTIONS, 2);
		MPPause.CAN_PAUSE_GAME = true;
		return Function.Call<string>(Hash.GET_ONSCREEN_KEYBOARD_RESULT);
	}
}
