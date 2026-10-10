using System;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class MPTeleporter : Script
{
	public MPTeleporter()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (!Game.IsControlJustPressed(Control.Context))
		{
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		Function.Call(Hash.STOP_PLAYER_TELEPORT);
	}

	public static void STOP_PLAYER_TELEPORT()
	{
		Function.Call(Hash.STOP_PLAYER_TELEPORT);
	}

	public static bool IS_PLAYER_TELEPORT_ACTIVE()
	{
		return Function.Call<bool>(Hash.IS_PLAYER_TELEPORT_ACTIVE);
	}

	public static bool UPDATE_PLAYER_TELEPORT(Player player)
	{
		return Function.Call<bool>(Hash.UPDATE_PLAYER_TELEPORT, player);
	}

	public static void START_PLAYER_TELEPORT(Player player, Vector3 pos, float heading, bool teleportVehicle = true, bool snapToGround = true, bool fadePlayerOut = true)
	{
		Function.Call(Hash.START_PLAYER_TELEPORT, player, pos.X, pos.Y, pos.Z, heading, teleportVehicle, snapToGround, fadePlayerOut);
	}

	public static void TELEPORT_PLAYER(Player player, Vector3 pos, float heading, bool teleportVehicle = true, bool snapToGround = true, bool fadePlayerOut = true, int timer = 5000)
	{
		START_PLAYER_TELEPORT(player, pos, heading, teleportVehicle, snapToGround, fadePlayerOut);
		int num = Game.GameTime + timer;
		while (!UPDATE_PLAYER_TELEPORT(player) || num < Game.GameTime)
		{
			Script.Wait(0);
		}
	}
}
