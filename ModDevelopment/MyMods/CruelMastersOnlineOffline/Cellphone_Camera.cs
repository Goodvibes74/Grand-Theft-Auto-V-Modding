using System;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Cellphone_Camera : Script
{
	public static bool Camera_Active = false;

	public static bool Photo_Active = false;

	public static int Camera_Control = 0;

	public static int ButtonPressTimer = 0;

	public static int CAMERA_SHUTTER = 0;

	public static Camera CellCam;

	public static float camrotz = 0f;

	public static float camrotx = 0f;

	public static float camzoom = 50f;

	public static float camzoommin = 50f;

	public static float camzoommax = 0f;

	public Cellphone_Camera()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (true)
		{
			if (CellCam != null)
			{
				CellCam.Delete();
			}
			Function.Call(Hash.SET_PLAYER_CONTROL, Game.Player, true, 0);
		}
	}

	public static void CAMERA_CONTROL(Camera cam)
	{
		if (cam != null)
		{
			Scaleform scaleform = new Scaleform("instructional_buttons");
			scaleform.CallFunction("CLEAR_ALL");
			scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
			scaleform.CallFunction("CREATE_CONTAINER");
			scaleform.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 177, 0), "Exit");
			scaleform.CallFunction("SET_DATA_SLOT", 1, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 172, 0), "");
			scaleform.CallFunction("SET_DATA_SLOT", 2, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 173, 0), "Zoom");
			scaleform.CallFunction("SET_DATA_SLOT", 3, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 1, 0), "Pan Camera");
			scaleform.CallFunction("SET_DATA_SLOT", 4, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 0, 201, 0), "Take Photo");
			scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
			scaleform.Render2D();
			Heist_Hud.drawSprite2("cs_nhp_overlay_grid", "overlay_grid", 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255);
			cam.Rotation = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_ROT, 2);
			if (camzoom > 50f)
			{
				camzoom = 50f;
			}
			if (camzoom < 30f)
			{
				camzoom = 30f;
			}
			if (Game.IsControlPressed(Control.PhoneUp))
			{
				camzoom -= 0.5f;
				cam.FieldOfView = camzoom;
			}
			if (Game.IsControlPressed(Control.PhoneDown))
			{
				camzoom += 0.5f;
				cam.FieldOfView = camzoom;
			}
		}
	}

	public unsafe static void DeleteShutterScaleforms()
	{
		int cAMERA_SHUTTER = CAMERA_SHUTTER;
		Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &cAMERA_SHUTTER);
		CAMERA_SHUTTER = 0;
	}

	public static void RequestShutterScaleforms()
	{
		CAMERA_SHUTTER = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "CAMERA_SHUTTER");
	}
}
