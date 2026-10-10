using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

public static class PlayerSwitch
{
	public enum ePlayerSwitchTypes
	{
		SWITCH_TYPE_AUTO,
		SWITCH_TYPE_LONG,
		SWITCH_TYPE_MEDIUM,
		SWITCH_TYPE_SHORT
	}

	public static void SwitchBetweenPeds(Ped ped1, Ped destination)
	{
		ResetSwitch();
		int num = Function.Call<int>(Hash.GET_IDEAL_PLAYER_SWITCH_TYPE, ped1.Position.X, ped1.Position.Y, ped1.Position.Z, destination.Position.X, destination.Position.Y, World.GetGroundHeight(new Vector2(destination.Position.X, destination.Position.Y)));
		if (num == 3 || num == 1 || num == 0)
		{
			num = 2;
		}
		START_PLAYER_SWITCH(ped1, destination, 0, ePlayerSwitchTypes.SWITCH_TYPE_SHORT);
		Script.Wait(1000);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
		Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
		Script.Wait(500);
		if (num == 1)
		{
			while (GET_PLAYER_SWITCH_STATE() < 8)
			{
				Script.Yield();
			}
		}
		Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, destination, 0, true);
		SWITCH_IN_PLAYER(destination);
		Function.Call(Hash.SET_PLAYER_SWITCH_OUTRO, destination.Position.X, destination.Position.Y, World.GetGroundHeight(new Vector2(destination.Position.X, destination.Position.Y)), destination.Rotation.X, destination.Rotation.Y, destination.Rotation.Z, GameplayCamera.FieldOfView, 0f, 2);
		Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
		while (IS_PLAYER_SWITCH_IN_PROGRESS())
		{
			Script.Wait(0);
		}
	}

	public static void ResetSwitch()
	{
		if (IS_PLAYER_SWITCH_IN_PROGRESS())
		{
			STOP_PLAYER_SWITCH();
		}
	}

	public static void START_PLAYER_SWITCH(Ped from, Ped to, int flags, ePlayerSwitchTypes switchType)
	{
		Function.Call(Hash.START_PLAYER_SWITCH, from, to, flags, (int)switchType);
	}

	public static bool IS_PLAYER_SWITCH_IN_PROGRESS()
	{
		return Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS);
	}

	public static bool IS_SWITCH_READY_FOR_DESCENT()
	{
		return Function.Call<bool>(Hash.IS_SWITCH_READY_FOR_DESCENT);
	}

	public static int GET_PLAYER_SWITCH_STATE()
	{
		return Function.Call<int>(Hash.GET_PLAYER_SWITCH_STATE);
	}

	public static void STOP_PLAYER_SWITCH()
	{
		if (IS_PLAYER_SWITCH_IN_PROGRESS())
		{
			Function.Call(Hash.STOP_PLAYER_SWITCH);
		}
	}

	public static ePlayerSwitchTypes GET_IDEAL_PLAYER_SWITCH_TYPE(float startx, float starty, float startz, float endx, float endy, float endz)
	{
		return (ePlayerSwitchTypes)Function.Call<int>(Hash.GET_IDEAL_PLAYER_SWITCH_TYPE, startx, starty, startz, endx, endy, endz);
	}

	public static void _SWITCH_OUT_PLAYER(Ped ped, int flags, int switchType)
	{
		Function.Call(Hash.SWITCH_TO_MULTI_FIRSTPART, ped, flags, switchType);
	}

	public static void SWITCH_IN_PLAYER(Ped ped)
	{
		Function.Call(Hash.SWITCH_TO_MULTI_SECONDPART, ped);
	}
}
