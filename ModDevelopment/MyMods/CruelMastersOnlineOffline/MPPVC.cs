using System;
using System.IO;
using GTA;

namespace CruelMastersOnlineOffline;

internal class MPPVC : Script
{
	public MPPVC()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if ((CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG) || !File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml") || !(CruelMastersOnlineOffline.PlayerVehicle != null))
		{
			return;
		}
		if (Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle)
		{
			if (CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip != null)
			{
				CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Alpha = 0;
			}
		}
		else if (CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip != null)
		{
			CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Alpha = 255;
		}
		if (CruelMastersOnlineOffline.PlayerVehicle.IsDead)
		{
			if (CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip != null)
			{
				CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Delete();
			}
			CruelMastersOnlineOffline.PlayerVehicle.MarkAsNoLongerNeeded();
			CruelMastersOnlineOffline.PlayerVehicle = null;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}
}
