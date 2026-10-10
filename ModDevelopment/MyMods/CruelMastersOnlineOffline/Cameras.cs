using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Cameras : Script
{
	public static Camera WORLD_CREATE_CAMERA(Vector3 pos, Vector3 rot, float fov)
	{
		return World.CreateCamera(pos, rot, fov);
	}

	public static void RENDER_SCRIPT_CAMS(bool render, bool ease, int easeTime, bool p3, bool p4, bool p5)
	{
		Function.Call(Hash.RENDER_SCRIPT_CAMS, render, ease, easeTime, p3, p4, p5);
	}

	public static void WORLD_RENDERING_CAMERA(Camera cam)
	{
		World.RenderingCamera = cam;
	}

	public static float CAM_SPLINE_PHASE(Camera camera)
	{
		return Function.Call<float>(Hash.GET_CAM_SPLINE_NODE_PHASE, camera);
	}

	public static float GET_CAM_ANIM_CURRENT_PHASE(Camera cam)
	{
		return Function.Call<float>(Hash.GET_CAM_ANIM_CURRENT_PHASE, cam);
	}

	public static bool IS_CAM_INTERPOLATING(Camera cam)
	{
		return Function.Call<bool>(Hash.IS_CAM_INTERPOLATING, cam);
	}

	public static void RESET_GAMEPLAY_CAM()
	{
		GameplayCamera.RelativeHeading = Game.Player.Character.Heading - Game.Player.Character.Heading;
		GameplayCamera.RelativePitch = 0f;
	}

	public static void SET_NEXT_CAM_PARAMS(Camera cam, Vector3 pos, Vector3 rot, float fov)
	{
		cam.Position = pos;
		cam.Rotation = rot;
		cam.FieldOfView = fov;
	}
}
