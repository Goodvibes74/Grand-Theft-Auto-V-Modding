using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Screen_Effects
{
	public static void CLEAR_ALL_HELP_MESSAGES()
	{
		Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
	}

	public static void End_Mission_Ring()
	{
		Audio.SetAudioFlag(AudioFlags.LoadMPData, toggle: true);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_PREP_SCREEN_SOUNDS", true);
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebEnd", 5000, false);
	}

	public static void SET_TIMECYCLE_MODIFIER(string timecycle)
	{
		Function.Call(Hash.SET_TIMECYCLE_MODIFIER, timecycle);
	}

	public static void SET_TIMECYCLE_MODIFIER_STRENGTH(float timecyclestrength)
	{
		Function.Call(Hash.SET_TIMECYCLE_MODIFIER_STRENGTH, timecyclestrength);
	}

	public static void SET_TRANSITION_TIMECYCLE_MODIFIER(string timecycle, float timecyclestrength)
	{
		Function.Call(Hash.SET_TRANSITION_TIMECYCLE_MODIFIER, timecycle, timecyclestrength);
	}

	public static void CLEAR_TIMECYCLE_MODIFIER()
	{
		Function.Call(Hash.CLEAR_TIMECYCLE_MODIFIER);
	}

	public static void PlayAnimPostFX(string animpostfxname, int duration, bool looped)
	{
		Function.Call(Hash.ANIMPOSTFX_PLAY, animpostfxname, duration, looped);
	}

	public static void StopAllAnimPostFX()
	{
		Function.Call(Hash.ANIMPOSTFX_STOP_ALL);
	}
}
