using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Alarms : Script
{
	public static int Alarm_Sounds = 0;

	public static int AlarmSwitch = 0;

	public static bool[] AlarmActive = new bool[8];

	public Alarms()
	{
		Tick += onTick;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (AlarmActive[0])
		{
			Cayo_Perico_Alarm();
		}
		if (AlarmActive[1])
		{
			MORGUE_Alarm(cleanup: false);
		}
		else
		{
			MORGUE_Alarm(cleanup: true);
		}
		if (AlarmActive[2])
		{
			FLEECA_Alarm(cleanup: false);
		}
		if (AlarmActive[5])
		{
			Sub_Alarm(cleanup: false);
		}
		if (AlarmActive[6])
		{
			Silo_Alarm(cleanup: false);
		}
	}

	public static void Cayo_Perico_Alarm()
	{
		Prop[] allProps = World.GetAllProps(CruelMastersOnlineOffline.RequestModel("collision_921o1po"));
		Prop[] array = allProps;
		foreach (Prop prop in array)
		{
			if (prop != null)
			{
				prop.IsPositionFrozen = false;
			}
		}
		switch (AlarmSwitch)
		{
		case 0:
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01", false, -1);
			Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLCHEI4_GENERIC_01", false, -1);
			AlarmSwitch = 1;
			break;
		case 1:
			if (Alarm_Sounds == 0)
			{
				Alarm_Sounds = Function.Call<int>(Hash.GET_SOUND_ID);
				break;
			}
			Function.Call(Hash.PLAY_SOUND_FROM_COORD, Alarm_Sounds, "Alarm_Oneshot", 5019.995f, -5730.475f, 50.4737f, "DLC_H4_Island_Alarms_Sounds", false, 200f, false);
			AlarmSwitch = 2;
			break;
		case 2:
			if (Audio.HasSoundFinished(Alarm_Sounds))
			{
				Audio.StopSound(Alarm_Sounds);
				Audio.ReleaseSound(Alarm_Sounds);
				Alarm_Sounds = 0;
				AlarmSwitch = 1;
			}
			break;
		}
	}

	public static void IAA_Facility_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (!cleanup)
			{
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "ALARM_KLAXON_02", false, -1);
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "ALARM_KLAXON_02", false, -1);
				Script.Wait(50);
				AlarmSwitch = 1;
			}
			break;
		case 1:
			if (Alarm_Sounds == 0)
			{
				Alarm_Sounds = Function.Call<int>(Hash.GET_SOUND_ID);
				break;
			}
			Function.Call(Hash.PLAY_SOUND_FROM_COORD, Alarm_Sounds, "Klaxon_02", 2051.412f, 2969.325f, -58.96179f, "ALARMS_SOUNDSET", true, 200f, 0);
			AlarmSwitch = 2;
			break;
		case 2:
			if (cleanup)
			{
				Audio.StopSound(Alarm_Sounds);
				Audio.ReleaseSound(Alarm_Sounds);
				Alarm_Sounds = 0;
				AlarmSwitch = 0;
			}
			break;
		}
	}

	public static void FLEECA_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (!cleanup)
			{
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "ALARM_BELL_01", false, -1);
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "ALARM_BELL_01", false, -1);
				Script.Wait(50);
				AlarmSwitch = 1;
			}
			break;
		case 1:
			if (Alarm_Sounds == 0)
			{
				Alarm_Sounds = Function.Call<int>(Hash.GET_SOUND_ID);
				break;
			}
			Function.Call(Hash.PLAY_SOUND_FROM_COORD, Alarm_Sounds, "Bell_01", 1173.424f, 2712.193f, 39.58252f, "ALARMS_SOUNDSET", true, 50f, 0);
			AlarmSwitch = 2;
			break;
		case 2:
			if (cleanup)
			{
				Audio.StopSound(Alarm_Sounds);
				Audio.ReleaseSound(Alarm_Sounds);
				Alarm_Sounds = 0;
				AlarmSwitch = 0;
			}
			break;
		}
	}

	public static void The_Union_Depository_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (!cleanup)
			{
				if (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "BIG_SCORE_HEIST_VAULT_ALARMS") && Function.Call<bool>(Hash.PREPARE_ALARM, "BIG_SCORE_HEIST_VAULT_ALARMS"))
				{
					Function.Call(Hash.START_ALARM, "BIG_SCORE_HEIST_VAULT_ALARMS", true);
				}
				if (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "BIG_SCORE_HEIST_VAULT_ALARMS"))
				{
					AlarmSwitch = 1;
				}
			}
			break;
		case 1:
			if (cleanup)
			{
				if (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "BIG_SCORE_HEIST_VAULT_ALARMS"))
				{
					Function.Call(Hash.STOP_ALARM, "BIG_SCORE_HEIST_VAULT_ALARMS", true);
				}
				else
				{
					AlarmSwitch = 0;
				}
			}
			break;
		}
	}

	public static void Prologue_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (!cleanup)
			{
				if (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "PROLOGUE_VAULT_ALARMS") && Function.Call<bool>(Hash.PREPARE_ALARM, "PROLOGUE_VAULT_ALARMS"))
				{
					Function.Call(Hash.START_ALARM, "PROLOGUE_VAULT_ALARMS", true);
				}
				if (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "PROLOGUE_VAULT_ALARMS"))
				{
					AlarmSwitch = 1;
				}
			}
			break;
		case 1:
			if (cleanup)
			{
				if (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "PROLOGUE_VAULT_ALARMS"))
				{
					Function.Call(Hash.STOP_ALARM, "PROLOGUE_VAULT_ALARMS", true);
				}
				else
				{
					AlarmSwitch = 0;
				}
			}
			break;
		}
	}

	public static void FIB_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (cleanup)
			{
				break;
			}
			while (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS"))
			{
				if (Function.Call<bool>(Hash.PREPARE_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS"))
				{
					Function.Call(Hash.START_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS", true);
				}
				Script.Yield();
			}
			while (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER"))
			{
				if (Function.Call<bool>(Hash.PREPARE_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER"))
				{
					Function.Call(Hash.START_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER", true);
				}
				Script.Yield();
			}
			while (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B"))
			{
				if (Function.Call<bool>(Hash.PREPARE_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B"))
				{
					Function.Call(Hash.START_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B", true);
				}
				Script.Yield();
			}
			if (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS") && Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER") && Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B"))
			{
				AlarmSwitch = 1;
			}
			break;
		case 1:
			if (cleanup)
			{
				while (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS"))
				{
					Function.Call(Hash.STOP_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS", true);
					Script.Yield();
				}
				while (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER"))
				{
					Function.Call(Hash.STOP_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER", true);
					Script.Yield();
				}
				while (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B"))
				{
					Function.Call(Hash.STOP_ALARM, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B", true);
					Script.Yield();
				}
				if (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS") && !Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER") && !Function.Call<bool>(Hash.IS_ALARM_PLAYING, "AGENCY_HEIST_FIB_TOWER_ALARMS_UPPER_B"))
				{
					AlarmSwitch = 0;
				}
			}
			break;
		}
	}

	public static void Silo_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (!cleanup)
			{
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CHRISTMAS2017/XM_SILO");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_CHRISTMAS2017/XM_SILO", false, -1);
				Script.Wait(500);
				AlarmSwitch = 1;
			}
			break;
		case 1:
			if (Alarm_Sounds == 0)
			{
				Alarm_Sounds = Function.Call<int>(Hash.GET_SOUND_ID);
				break;
			}
			Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, -1, "missile_system_armed", Game.Player.Character, "dlc_xm_silo_finale_sounds", false, 0);
			Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, Alarm_Sounds, "launch_alarm_loop", Game.Player.Character, "dlc_xm_silo_finale_sounds", false, 0);
			AlarmSwitch = 2;
			break;
		case 2:
			if (cleanup)
			{
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CHRISTMAS2017/XM_SILO");
				Audio.StopSound(Alarm_Sounds);
				Audio.ReleaseSound(Alarm_Sounds);
				Alarm_Sounds = 0;
				AlarmSwitch = 0;
			}
			break;
		}
	}

	public static void Sub_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (!cleanup)
			{
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CHRISTMAS2017/XM_SUBMARINE");
				Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_CHRISTMAS2017/XM_SUBMARINE", false, -1);
				Script.Wait(500);
				AlarmSwitch = 1;
			}
			break;
		case 1:
			if (Alarm_Sounds == 0)
			{
				Alarm_Sounds = Function.Call<int>(Hash.GET_SOUND_ID);
				break;
			}
			Function.Call(Hash.PLAY_SOUND_FROM_COORD, Alarm_Sounds, "alarm_loop", 514.3f, 4838.5f, -61.7f, "dlc_xm_submarine_sounds", false, 0, 0);
			AlarmSwitch = 2;
			break;
		case 2:
			if (cleanup)
			{
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_CHRISTMAS2017/XM_SUBMARINE");
				Audio.StopSound(Alarm_Sounds);
				Audio.ReleaseSound(Alarm_Sounds);
				Alarm_Sounds = 0;
				AlarmSwitch = 0;
			}
			break;
		}
	}

	public static void MORGUE_Alarm(bool cleanup)
	{
		switch (AlarmSwitch)
		{
		case 0:
			if (cleanup)
			{
				break;
			}
			while (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "FBI_01_MORGUE_ALARMS"))
			{
				if (Function.Call<bool>(Hash.PREPARE_ALARM, "FBI_01_MORGUE_ALARMS"))
				{
					Function.Call(Hash.START_ALARM, "FBI_01_MORGUE_ALARMS", true);
				}
				Script.Yield();
			}
			if (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "FBI_01_MORGUE_ALARMS"))
			{
				AlarmSwitch = 1;
			}
			break;
		case 1:
			if (cleanup)
			{
				while (Function.Call<bool>(Hash.IS_ALARM_PLAYING, "FBI_01_MORGUE_ALARMS"))
				{
					Function.Call(Hash.STOP_ALARM, "FBI_01_MORGUE_ALARMS", true);
					Script.Yield();
				}
				if (!Function.Call<bool>(Hash.IS_ALARM_PLAYING, "FBI_01_MORGUE_ALARMS"))
				{
					AlarmSwitch = 0;
				}
			}
			break;
		}
	}

	public static void STOP_ALL_ALARMS(bool stop)
	{
		Function.Call(Hash.STOP_ALL_ALARMS, stop);
	}
}
