using System;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPVoiceLinePed : Script
{
	public static Ped VLPed;

	public MPVoiceLinePed()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if ((CruelMastersOnlineOffline.StorySwitch >= 2 || CruelMastersOnlineOffline.DEBUG) && !Game.IsLoading && !Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE) && !Screen.IsFadingIn)
		{
			while (VLPed == null)
			{
				VLPed = World.CreatePed(PedHash.FreemodeMale01, new Vector3(-1818.896f, -355.6931f, 92.67699f), 345.5821f);
				Script.Wait(0);
			}
			if (VLPed != null)
			{
				VLPed.IsPositionFrozen = true;
				VLPed.IsCollisionEnabled = false;
				VLPed.IsVisible = false;
				VLPed.IsInvincible = true;
				VLPed.CanRagdoll = false;
				VLPed.RelationshipGroup = Groups.playersTeam;
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (VLPed != null)
		{
			VLPed.Delete();
		}
	}
}
