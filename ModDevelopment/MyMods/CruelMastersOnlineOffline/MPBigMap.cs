using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPBigMap : Script
{
	public static int UseSwitch;

	public static int Timer;

	public static int Timer2;

	public MPBigMap()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (Hud.IsRadarVisible)
		{
			switch (UseSwitch)
			{
			case 0:
				if (Game.IsControlJustPressed(Control.MultiplayerInfo) && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL)
				{
					Timer = Game.GameTime + 1000;
					Timer2 = 0;
					UseSwitch = 1;
				}
				break;
			case 1:
				if (Game.IsControlJustPressed(Control.MultiplayerInfo) && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL)
				{
					Function.Call(Hash.SET_BIGMAP_ACTIVE, true, false);
					Function.Call(Hash.DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS, true);
					Timer2 = Game.GameTime + 10000;
					UseSwitch = 2;
				}
				else if (Game.GameTime > Timer)
				{
					Timer = 0;
					UseSwitch = 0;
				}
				break;
			case 2:
				if (Game.GameTime > Timer2 || Game.IsControlJustPressed(Control.MultiplayerInfo))
				{
					Function.Call(Hash.SET_BIGMAP_ACTIVE, false, false);
					Function.Call(Hash.DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS, false);
					Timer = 0;
					Timer2 = 0;
					UseSwitch = 0;
				}
				break;
			}
		}
		else
		{
			Function.Call(Hash.SET_BIGMAP_ACTIVE, false, false);
			Function.Call(Hash.DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS, false);
			Timer = 0;
			Timer2 = 0;
			UseSwitch = 0;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		Function.Call(Hash.SET_BIGMAP_ACTIVE, false, false);
		Function.Call(Hash.DISPLAY_PLAYER_NAME_TAGS_ON_BLIPS, false);
	}
}
