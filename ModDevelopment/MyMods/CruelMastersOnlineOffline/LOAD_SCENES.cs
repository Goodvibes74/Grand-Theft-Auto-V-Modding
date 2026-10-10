using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class LOAD_SCENES
{
	public static void LOAD_SCENE(float x, float y, float z)
	{
		Function.Call(Hash.LOAD_SCENE, x, y, z);
	}

	public static bool IS_NEW_LOAD_SCENE_ACTIVE()
	{
		return Function.Call<bool>(Hash.IS_NEW_LOAD_SCENE_ACTIVE);
	}

	public static bool IS_NEW_LOAD_SCENE_LOADED()
	{
		return Function.Call<bool>(Hash.IS_NEW_LOAD_SCENE_LOADED);
	}

	public static void NEW_LOAD_SCENE_START(float posX, float posY, float posZ, float offsetX, float offsetY, float offsetZ, float radius, int p7)
	{
		if (!IS_NEW_LOAD_SCENE_ACTIVE() && !IS_NEW_LOAD_SCENE_LOADED())
		{
			Function.Call(Hash.NEW_LOAD_SCENE_START, posX, posY, posZ, offsetX, offsetY, offsetZ, radius, p7);
		}
	}

	public static void NEW_LOAD_SCENE_STOP()
	{
		if (IS_NEW_LOAD_SCENE_ACTIVE())
		{
			Function.Call(Hash.NEW_LOAD_SCENE_STOP);
		}
	}
}
