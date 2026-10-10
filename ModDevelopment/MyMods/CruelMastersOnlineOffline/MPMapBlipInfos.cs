using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class MPMapBlipInfos : Script
{
	public static Blip current_blip;

	public static int Display = 1;

	public MPMapBlipInfos()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		Function.Call(Hash.RELEASE_CONTROL_OF_FRONTEND);
	}

	public static void GERALD_MAP_BLIP_HANDLE(Blip thisBlip)
	{
	}

	public static void CLEAR_DISPLAY()
	{
		CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT_EMPTY", Display);
	}

	public static void UPDATE_DISPLAY()
	{
		CruelMastersOnlineOffline.CallFunctionFrontend("DISPLAY_DATA_SLOT", Display);
	}

	public static void SHOW_DISPLAY(bool show)
	{
		CruelMastersOnlineOffline.CallFunctionFrontend("SHOW_COLUMN", Display, show);
	}

	public static void SET_TITLE(string title, int rockstarVerified, int rp, int money, string dict, string tex)
	{
		CruelMastersOnlineOffline.CallFunctionFrontend("SET_COLUMN_TITLE", Display, "", title, rockstarVerified, dict, tex, 0, 0, rp, money);
	}

	public static void SET_ICON(int index, string title, string text, int icon, int iconColor, bool completed)
	{
		CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", Display, index, 65, 3, 2, 0, 1, title, text, icon, iconColor, completed);
	}

	public static void SET_TEXT(int index, string title, string text, int textType)
	{
		CruelMastersOnlineOffline.CallFunctionFrontend("SET_DATA_SLOT", Display, index, 65, 3, textType, 0, 0, title, text);
	}

	public static void SET_DESCRIPTION(string text)
	{
		CruelMastersOnlineOffline.CallFunctionFrontend("SET_DESCRIPTION", Display, text, text, text, text, text, text, text, text, text, text, text);
	}
}
