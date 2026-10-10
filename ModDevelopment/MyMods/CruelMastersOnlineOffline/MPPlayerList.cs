using System;
using System.IO;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPPlayerList : Script
{
	public enum DisplayType
	{
		NUMBER_ONLY,
		ICON,
		NONE
	}

	public enum RightIconType
	{
		NONE = 0,
		INACTIVE_HEADSET = 48,
		MUTED_HEADSET = 49,
		ACTIVE_HEADSET = 47,
		RANK_FREEMODE = 65,
		KICK = 64,
		LOBBY_DRIVER = 79,
		LOBBY_CODRIVER = 80,
		SPECTATOR = 66,
		BOUNTY = 115,
		DEAD = 116,
		DPAD_GANG_CEO = 121,
		DPAD_GANG_BIKER = 122,
		DPAD_DOWN_TARGET = 123
	}

	public static int PlayerList = 0;

	public static int PlayerListswtich = 0;

	public static int[] handle = new int[8];

	public static int JobPoints = 0;

	public static int ListTimer = 0;

	public static bool CAN_SHOW_LIST = true;

	public MPPlayerList()
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
		switch (PlayerListswtich)
		{
		case 0:
			if (Game.IsControlJustPressed(Control.MultiplayerInfo) && CAN_SHOW_LIST && Cutscenes.HAS_CUTSCENE_FINISHED() && Hud.IsRadarVisible && Hud.IsVisible && !Game.Player.Character.IsDead && !PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS() && Function.Call<Hash>(Hash.GET_CURRENT_FRONTEND_MENU_VERSION) == (Hash)4294967295uL)
			{
				DeletePlayerListScaleform();
				RequestPlayerListScaleform();
				Script.Wait(500);
				PlayerListswtich = 1;
			}
			break;
		case 1:
		{
			string text = "Freeroam";
			if (CruelMastersOnlineOffline.OnMission)
			{
				text = "On Mission";
			}
			string text2 = Function.Call<string>(Hash.GET_PEDHEADSHOT_TXD_STRING, handle[7]);
			int num2 = 0;
			int num3 = 0;
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 1);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 2);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 3);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 4);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 5);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 6);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 7);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT_EMPTY", 0, 8);
			Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT", 0, MPRank.PlayerLevel, CruelMastersOnlineOffline.Player_Name, 111, 65, "", JobPoints.ToString(), 0, "JobPoints", text2, text2, "C");
			string[] files = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Companions");
			foreach (string fileName in files)
			{
				MPAiInfo mPAiInfo = XMLSerializer.DeserializeXML<MPAiInfo>(fileName);
				for (int k = 0; k < MPAiCreator.Companions.Length; k++)
				{
					if (MPAiCreator.Companions[k] != null && MPAiCreator.Companions[k].AttachedBlip != null && Function.Call<bool>(Hash.ARE_STRINGS_EQUAL, MPAiCreator.Companions[k].AttachedBlip.Name, mPAiInfo.ownedInfos[0].Name))
					{
						handle[k] = Function.Call<int>(Hash.REGISTER_PEDHEADSHOT, MPAiCreator.Companions[k]);
						while (!Function.Call<bool>(Hash.IS_PEDHEADSHOT_READY, handle[k]))
						{
							Script.Wait(0);
						}
						string text3 = Function.Call<string>(Hash.GET_PEDHEADSHOT_TXD_STRING, handle[k]);
						Wall_Creator.CallFunction(PlayerList, "SET_DATA_SLOT", num3 + 1, MPRank.PlayerLevel, mPAiInfo.ownedInfos[0].Name, 111, 65, "", JobPoints.ToString(), 0, "JobPoints", text3, text3, "F");
						num2++;
						num3++;
					}
				}
			}
			if (num2 == 0)
			{
				Wall_Creator.CallFunction(PlayerList, "SET_TITLE", $"GTA OFFLINE (Private, {1})", text, "2");
			}
			else
			{
				Wall_Creator.CallFunction(PlayerList, "SET_TITLE", $"GTA OFFLINE (Private, {num2 + 1})", text, "2");
			}
			Wall_Creator.CallFunction(PlayerList, "DISPLAY_VIEW");
			ListTimer = Game.GameTime + 6000;
			PlayerListswtich = 2;
			break;
		}
		case 2:
		{
			Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 7);
			Function.Call(Hash.DRAW_SCALEFORM_MOVIE, PlayerList, 0.12f, 0.3f, 0.28f, 0.6f, 255, 255, 255, 255, 0);
			Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
			if (Game.GameTime <= ListTimer)
			{
				break;
			}
			int num = 1000;
			while (Game.GameTime < num)
			{
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 7);
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE, PlayerList, 0.12f, 0.3f, 0.28f, 0.6f, 255, 255, 255, 255, 0);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Script.Wait(0);
			}
			for (int i = 0; i < handle.Length; i++)
			{
				if (Function.Call<bool>(Hash.IS_PEDHEADSHOT_VALID, handle[i]))
				{
					Function.Call(Hash.UNREGISTER_PEDHEADSHOT, handle[i]);
				}
				handle[i] = 0;
			}
			DeletePlayerListScaleform();
			ListTimer = 0;
			PlayerListswtich = 0;
			break;
		}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (PlayerList != 0)
		{
			DeletePlayerListScaleform();
		}
		for (int i = 0; i <= 32; i++)
		{
			if (Function.Call<bool>(Hash.IS_PEDHEADSHOT_VALID, i))
			{
				Function.Call(Hash.UNREGISTER_PEDHEADSHOT, i);
			}
		}
	}

	private unsafe void DeletePlayerListScaleform()
	{
		int playerList = PlayerList;
		Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &playerList);
		PlayerList = 0;
		for (int i = 0; i < handle.Length; i++)
		{
			if (Function.Call<bool>(Hash.IS_PEDHEADSHOT_VALID, handle[i]))
			{
				Function.Call(Hash.UNREGISTER_PEDHEADSHOT, handle[i]);
			}
			handle[i] = 0;
		}
		Script.Yield();
	}

	private void RequestPlayerListScaleform()
	{
		PlayerList = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "MP_MM_CARD_FREEMODE");
		handle[7] = Function.Call<int>(Hash.REGISTER_PEDHEADSHOT, Game.Player.Character);
	}
}
