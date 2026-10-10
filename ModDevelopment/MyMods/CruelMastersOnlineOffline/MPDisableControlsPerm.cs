using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class MPDisableControlsPerm : Script
{
	public MPDisableControlsPerm()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch >= 2 || CruelMastersOnlineOffline.DEBUG)
		{
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 199, 1);
			Function.Call(Hash.DISABLE_CONTROL_ACTION, 2, 200, 1);
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}
}
