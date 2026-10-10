using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Anims
{
	public static bool IS_ENTITY_PLAYING_ANIM(Ped entity, string animDict, string animName)
	{
		return Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, entity, animDict, animName, 3);
	}

	public static float GET_SYNCHRONIZED_SCENE_PHASE(int sceneID)
	{
		return Function.Call<float>(Hash.GET_SYNCHRONIZED_SCENE_PHASE, sceneID);
	}

	public static void SET_SYNCHRONIZED_SCENE_PHASE(int sceneID, float phase)
	{
		Function.Call(Hash.SET_SYNCHRONIZED_SCENE_PHASE, sceneID, phase);
	}

	public static void SET_SYNCHRONIZED_SCENE_LOOPED(int sceneID, bool toggle)
	{
		Function.Call(Hash.SET_SYNCHRONIZED_SCENE_LOOPED, sceneID, toggle);
	}

	public static void FORCE_ENTITY_AI_AND_ANIMATION_UPDATE(Entity entity)
	{
		Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, entity);
	}

	public static void SET_SYNCHRONIZED_SCENE_RATE(int sceneID, float rate)
	{
		Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, sceneID, rate);
	}

	public static void SET_SYNCHRONIZED_SCENE_HOLD_LAST_FRAME(int sceneID, bool toggle)
	{
		Function.Call(Hash.SET_SYNCHRONIZED_SCENE_RATE, sceneID, toggle);
	}
}
