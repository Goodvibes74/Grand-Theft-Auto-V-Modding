using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Audios
{
	public static void TRIGGER_MUSIC_EVENT(string musicevent)
	{
		Function.Call(Hash.TRIGGER_MUSIC_EVENT, musicevent);
	}

	public static bool TRIGGER_MUSIC_EVENT_BOOL(string musicevent)
	{
		return Function.Call<bool>(Hash.TRIGGER_MUSIC_EVENT, musicevent);
	}

	public static void PREPARE_MUSIC_EVENT(string musicevent)
	{
		Function.Call(Hash.PREPARE_MUSIC_EVENT, musicevent);
	}

	public static bool PREPARE_MUSIC_EVENT_BOOL(string musicevent)
	{
		return Function.Call<bool>(Hash.PREPARE_MUSIC_EVENT, musicevent);
	}

	public static void Stop_Music_Event()
	{
		Function.Call(Hash.TRIGGER_MUSIC_EVENT, "GTA_ONLINE_STOP_SCORE");
	}
}
