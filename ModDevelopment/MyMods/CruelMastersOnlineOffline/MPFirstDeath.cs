using System;
using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class MPFirstDeath : Script
{
	public MPFirstDeath()
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
		MPSaveData mPSaveData = MPSaveData.GET_MAIN_SAVE_DATA("Save Data");
		if (!mPSaveData.FirstDeathSaveDatas[0].FirstDeathCutscene && Game.Player.Character.IsDead && !CruelMastersOnlineOffline.OnMission)
		{
			Script.Wait(5000);
			Function.Call(Hash.START_AUDIO_SCENE, "EPSILON_FADE_TO_WHITE");
			int num = 0;
			while (num < 255)
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.DRAW_RECT, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, num, 0);
				num += 5;
				Script.Wait(0);
			}
			while (Game.Player.Character.IsDead)
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.DRAW_RECT, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255, 0);
				Script.Wait(0);
			}
			int num2 = Game.GameTime + 3000;
			while (Game.GameTime < num2)
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Function.Call(Hash.DRAW_RECT, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255, 0);
				Script.Wait(0);
			}
			string text = "";
			int num3 = 0;
			text = ((Game.Player.Character.Gender != Gender.Male) ? "mp_int_mcs_18_a2" : "mp_int_mcs_18_a1");
			while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED))
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Function.Call(Hash.DRAW_RECT, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255, 0);
				Function.Call(Hash.REQUEST_CUTSCENE, text, 8);
				Script.Yield();
			}
			Function.Call(Hash.START_CUTSCENE_AT_COORDS, -1314.9972f, -1721.0841f, 1.1493f, 0);
			if (Function.Call<bool>(Hash.NETWORK_IS_CLOCK_TIME_OVERRIDDEN))
			{
				Function.Call(Hash.NETWORK_CLEAR_CLOCK_TIME_OVERRIDE);
			}
			Function.Call(Hash.CLEAR_OVERRIDE_WEATHER);
			Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
			Function.Call(Hash.STOP_AUDIO_SCENES);
			Function.Call(Hash.NETWORK_OVERRIDE_CLOCK_TIME, 18, 0, 0);
			Function.Call(Hash.SET_OVERRIDE_WEATHER, "ExtraSunny");
			num2 = Game.GameTime + 50;
			while (Game.GameTime < num2)
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Function.Call(Hash.DRAW_RECT, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255, 0);
				Script.Wait(0);
			}
			while (!Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING))
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Function.Call(Hash.DRAW_RECT, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255, 0);
				Script.Wait(0);
			}
			num = 255;
			while (num > 0)
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Function.Call(Hash.DRAW_RECT, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, num, 0);
				num -= 15;
				Script.Wait(0);
			}
			Function.Call(Hash.STOP_AUDIO_SCENE, "EPSILON_FADE_TO_WHITE");
			Function.Call(Hash.SET_TRANSITION_TIMECYCLE_MODIFIER, "Kifflom", 1f);
			while (!Cutscenes.HAS_CUTSCENE_FINISHED())
			{
				Function.Call(Hash.DISABLE_FRONTEND_THIS_FRAME);
				Function.Call(Hash.SUPPRESS_FRONTEND_RENDERING_THIS_FRAME);
				if (Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE))
				{
					Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, 0);
				}
				Script.Wait(0);
			}
			Function.Call(Hash.REMOVE_CUTSCENE);
			if (Function.Call<bool>(Hash.NETWORK_IS_CLOCK_TIME_OVERRIDDEN))
			{
				Function.Call(Hash.NETWORK_CLEAR_CLOCK_TIME_OVERRIDE);
			}
			Function.Call(Hash.CLEAR_OVERRIDE_WEATHER);
			Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
			Function.Call(Hash.STOP_AUDIO_SCENES);
			mPSaveData.FirstDeathSaveDatas[0].FirstDeathCutscene = true;
			MPSaveData.SAVE_DATA(mPSaveData, "Save Data");
		}
		if (!Game.IsControlJustPressed(Control.Context))
		{
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (Function.Call<bool>(Hash.NETWORK_IS_CLOCK_TIME_OVERRIDDEN))
		{
			Function.Call(Hash.NETWORK_CLEAR_CLOCK_TIME_OVERRIDE);
		}
		Function.Call(Hash.CLEAR_OVERRIDE_WEATHER);
	}
}
