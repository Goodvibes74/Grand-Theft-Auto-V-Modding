using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPRobbingTill : Script
{
	public static int RobTillSwitch = -1;

	public static bool GaveFirstCash = false;

	public static bool GaveSecondCash = false;

	public static Ped shopKeeper;

	public MPRobbingTill()
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
		switch (RobTillSwitch)
		{
		case -1:
			CruelMastersOnlineOffline.LoadDict("oddjobs@shop_robbery@rob_till");
			CruelMastersOnlineOffline.LoadDict("mp_am_hold_up");
			Script.Wait(50);
			RobTillSwitch = 0;
			break;
		case 0:
		{
			if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("oddjobs@shop_robbery@rob_till"), "enter", 3))
			{
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Robbing Till Started", blinking: true);
				}
				RobTillSwitch = 1;
			}
			Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 50f, PedHash.ShopKeep01);
			Ped[] array = nearbyPeds;
			foreach (Ped ped in array)
			{
				if (ped != null && Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, ped, CruelMastersOnlineOffline.LoadDict("mp_am_hold_up"), "holdup_victim_20s", 3))
				{
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Robbing Register Started", blinking: true);
					}
					shopKeeper = ped;
					RobTillSwitch = 2;
				}
			}
			break;
		}
		case 1:
		{
			float num = Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("oddjobs@shop_robbery@rob_till"), "loop");
			Screen.ShowSubtitle(string.Format("Robbing Till: {0}", Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("oddjobs@shop_robbery@rob_till"), "loop")));
			if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("oddjobs@shop_robbery@rob_till"), "loop", 3))
			{
				if (!GaveFirstCash && num > 0.374f && num <= 0.484f)
				{
					MPCash.ADD_CASH(Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 500, 2500));
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Cash 1 Added", blinking: true);
					}
					MPRank.ADD_RP(Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 18, 25));
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("RP 1 Added", blinking: true);
					}
					GaveFirstCash = true;
				}
				if (!GaveSecondCash && num > 0.824f && num <= 0.92f)
				{
					MPCash.ADD_CASH(Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 500, 2500));
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("Cash 2 Added", blinking: true);
					}
					MPRank.ADD_RP(Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 18, 25));
					if (CruelMastersOnlineOffline.DEBUG)
					{
						Notification.Show("RP 2 Added", blinking: true);
					}
					GaveSecondCash = true;
				}
			}
			else
			{
				GaveFirstCash = false;
				GaveSecondCash = false;
			}
			if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, Game.Player.Character, CruelMastersOnlineOffline.LoadDict("oddjobs@shop_robbery@rob_till"), "exit", 3))
			{
				GaveFirstCash = false;
				GaveSecondCash = false;
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Robbing Till Done", blinking: true);
				}
				RobTillSwitch = 0;
			}
			break;
		}
		case 2:
			if (shopKeeper != null && shopKeeper.IsDead)
			{
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Robbing Register Canceled", blinking: true);
				}
				RobTillSwitch = 0;
			}
			if (shopKeeper != null && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, shopKeeper, CruelMastersOnlineOffline.LoadDict("mp_am_hold_up"), "holdup_victim_20s", 3))
			{
				MPCash.ADD_CASH(Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 2500, 5000));
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Cash 1 Added", blinking: true);
				}
				MPRank.ADD_RP(Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 25, 50));
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("RP 1 Added", blinking: true);
				}
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Robbing Register Ended", blinking: true);
				}
				shopKeeper = null;
				RobTillSwitch = 0;
			}
			break;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}
}
