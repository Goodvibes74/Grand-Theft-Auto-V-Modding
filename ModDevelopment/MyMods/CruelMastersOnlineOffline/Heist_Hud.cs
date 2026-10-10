using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class Heist_Hud : Script
{
	public static int Potential_Take = 250000;

	public static int Actual_Take = 0;

	public static float PreActual_Take = 0f;

	public static int TakeFlashGreen = 0;

	public static int TakeFlashRed = 0;

	public static int TeamLives = 0;

	public static int PreTeamLives = 0;

	public static int LivesFlashRed = 0;

	public static int CheckList_Show = 0;

	public static bool TAKE_BAR_SHOW = false;

	public static bool ITEM_BAR_SHOW = false;

	public static string ItemType = "";

	public static int Items = 0;

	public static bool[] Grabbed = new bool[5];

	public static bool[] Delivered = new bool[5];

	public static int[] ColorRGB = new int[4] { 255, 255, 255, 0 };

	public static bool COP_BAR_SHOW = false;

	public static DateTime CopTime;

	public static int Coptime = 0;

	public static float Bag_Capacity = 0f;

	public static int Loot_Bag = 0;

	public static bool[] Challenges = new bool[7];

	public Heist_Hud()
	{
		Tick += onTick;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (TAKE_BAR_SHOW)
		{
			TAKE_BAR();
		}
		if (ITEM_BAR_SHOW)
		{
			ITEM_BAR(ItemType, Items, Grabbed, Delivered, ColorRGB);
		}
		if (COP_BAR_SHOW)
		{
			COP_BAR(Coptime);
		}
	}

	public static void TAKE_BAR()
	{
		drawSprite2("timerbars", "all_black_bg", 0.88f, 0.906f, 0.26f, 0.05f, 255, 255, 255, 130);
		drawText("TAKE", 0.8f, 0.885f, 0.56f, 255, 255, 255);
		if ((float)Actual_Take < 0f)
		{
			Actual_Take = 0;
		}
		if ((float)Actual_Take > PreActual_Take)
		{
			Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "LOCAL_PLYR_CASH_COUNTER_INCREASE", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS", 1);
			PreActual_Take = Actual_Take;
			TakeFlashGreen = Game.GameTime + 300;
		}
		else if ((float)Actual_Take < PreActual_Take)
		{
			PreActual_Take = Actual_Take;
			TakeFlashRed = Game.GameTime + 300;
		}
		if (TakeFlashRed < Game.GameTime)
		{
			drawText2("$ " + Actual_Take.ToString("#,##0"), 0.85f, 0.885f, 0.56f, 255, 255, 255, drawright: true);
		}
		if (TakeFlashRed > Game.GameTime)
		{
			drawText2("$ " + Actual_Take.ToString("#,##0"), 0.85f, 0.885f, 0.56f, 215, 0, 0, drawright: true);
		}
		if (TakeFlashGreen < Game.GameTime)
		{
		}
		if (TakeFlashGreen > Game.GameTime)
		{
			drawText2("$ " + Actual_Take.ToString("#,##0"), 0.85f, 0.885f, 0.56f, 0, 215, 0, drawright: true);
		}
		OutputArgument outputArgument = new OutputArgument();
		if (Function.Call<bool>(Hash.GET_PED_LAST_DAMAGE_BONE, Game.Player.Character, outputArgument))
		{
			Function.Call(Hash.CLEAR_PED_LAST_DAMAGE_BONE, Game.Player.Character);
			int result = outputArgument.GetResult<int>();
			if (result == 24817 && Actual_Take > 0)
			{
				Actual_Take -= Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 2000, 4001);
			}
			if (CruelMastersOnlineOffline.DEBUG)
			{
				Notification.Show($"You got shot in bone: {result}");
			}
		}
	}

	public static void ITEM_BAR(string itemtype, int items, bool[] grabbed, bool[] delivered, int[] colorrgb)
	{
		drawSprite2("timerbars", "all_black_bg", 0.88f, 0.85f, 0.2f, 0.03f, 255, 255, 255, 130);
		if (items >= 1)
		{
			drawSprite2("timerbars", "circle_checkpoints_outline", 0.97f, 0.85f, 1f / 64f, 1f / 36f, 255, 255, 255, 130);
			if (grabbed[0])
			{
				drawSprite2("timerbars", "circle_checkpoints", 0.97f, 0.85f, 1f / 64f, 1f / 36f, colorrgb[0], colorrgb[1], colorrgb[2], 255);
				if (delivered[0])
				{
					drawSprite3("timerbar_sr", "timer_cross", 0.97f, 0.85f, 0.013020833f, 0.023148147f, 0f, 0, 0, 0, 250);
				}
			}
		}
		if (items >= 2)
		{
			drawSprite2("timerbars", "circle_checkpoints_outline", 0.958f, 0.85f, 1f / 64f, 1f / 36f, 255, 255, 255, 130);
			if (grabbed[1])
			{
				drawSprite2("timerbars", "circle_checkpoints", 0.958f, 0.85f, 1f / 64f, 1f / 36f, colorrgb[0], colorrgb[1], colorrgb[2], 255);
				if (delivered[1])
				{
					drawSprite3("timerbar_sr", "timer_cross", 0.958f, 0.85f, 0.013020833f, 0.023148147f, 0f, 0, 0, 0, 250);
				}
			}
		}
		if (items >= 3)
		{
			drawSprite2("timerbars", "circle_checkpoints_outline", 0.946f, 0.85f, 1f / 64f, 1f / 36f, 255, 255, 255, 130);
			if (grabbed[2])
			{
				drawSprite2("timerbars", "circle_checkpoints", 0.946f, 0.85f, 1f / 64f, 1f / 36f, colorrgb[0], colorrgb[1], colorrgb[2], 255);
				if (delivered[2])
				{
					drawSprite3("timerbar_sr", "timer_cross", 0.946f, 0.85f, 0.013020833f, 0.023148147f, 0f, 0, 0, 0, 250);
				}
			}
		}
		if (items >= 4)
		{
			drawSprite2("timerbars", "circle_checkpoints_outline", 0.934f, 0.85f, 1f / 64f, 1f / 36f, 255, 255, 255, 130);
			if (grabbed[3])
			{
				drawSprite2("timerbars", "circle_checkpoints", 0.934f, 0.85f, 1f / 64f, 1f / 36f, colorrgb[0], colorrgb[1], colorrgb[2], 255);
				if (delivered[3])
				{
					drawSprite3("timerbar_sr", "timer_cross", 0.934f, 0.85f, 0.013020833f, 0.023148147f, 0f, 0, 0, 0, 250);
				}
			}
		}
		drawText(itemtype, 0.81f, 0.836f, 0.35f, 255, 255, 255);
	}

	public static void ITEM_BAR_RESET()
	{
		ITEM_BAR_SHOW = false;
		Items = 0;
		ItemType = "";
		ColorRGB[0] = 255;
		ColorRGB[1] = 255;
		ColorRGB[2] = 255;
		Grabbed[0] = false;
		Grabbed[1] = false;
		Grabbed[2] = false;
		Grabbed[3] = false;
		Delivered[0] = false;
		Delivered[1] = false;
		Delivered[2] = false;
		Delivered[3] = false;
	}

	public static void CHALLENGE_RESET()
	{
		for (int i = 0; i < Challenges.Length; i++)
		{
			Challenges[i] = false;
		}
	}

	public static void CHALLENGE_SET(int chal, bool set)
	{
		Challenges[chal] = set;
	}

	public static void COP_BAR(int coptime)
	{
		TimeSpan timeSpan = CopTime.AddSeconds(coptime) - DateTime.Now;
		drawSprite2("timerbars", "all_black_bg", 0.88f, 0.96f, 0.26f, 0.05f, 255, 255, 255, 130);
		drawText("DISPATCH:", 0.8f, 0.94f, 0.56f, 255, 255, 255);
		drawText2($"{timeSpan:mm\\:ss}", 0.8f, 0.94f, 0.56f, 255, 255, 255, drawright: true);
		if (timeSpan.Seconds == 5 && CruelMastersOnlineOffline.SoundID6 == 0)
		{
			CruelMastersOnlineOffline.SoundID6 = Function.Call<int>(Hash.GET_SOUND_ID);
			Function.Call(Hash.PLAY_SOUND_FRONTEND, CruelMastersOnlineOffline.SoundID6, "5S", "MP_MISSION_COUNTDOWN_SOUNDSET", false);
		}
		if (timeSpan.Seconds <= 5 && timeSpan.Minutes == 0)
		{
			drawText("DISPATCH:", 0.8f, 0.94f, 0.56f, 255, 0, 0);
			drawText2($"{timeSpan:mm\\:ss}", 0.8f, 0.94f, 0.56f, 255, 0, 0, drawright: true);
		}
		if (timeSpan <= TimeSpan.Zero)
		{
			Audio.StopSound(CruelMastersOnlineOffline.SoundID6);
			Audio.ReleaseSound(CruelMastersOnlineOffline.SoundID6);
			CruelMastersOnlineOffline.SoundID6 = 0;
			COP_BAR_SHOW = false;
		}
	}

	public static void drawSprite2(string textureDict, string textureName, float screenX, float screenY, float width, float height, int r, int g, int b, int alpha)
	{
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, textureDict, 0);
		if (Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, textureDict))
		{
			Function.Call(Hash.DRAW_SPRITE, textureDict, textureName, screenX, screenY, width, height, 0, r, g, b, alpha, 0);
		}
	}

	public static void drawSprite3(string textureDict, string textureName, float screenX, float screenY, float width, float height, float heading, int r, int g, int b, int alpha)
	{
		Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, textureDict, 0);
		if (Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, textureDict))
		{
			Function.Call(Hash.DRAW_SPRITE, textureDict, textureName, screenX, screenY, width, height, heading, r, g, b, alpha, 0, 0);
		}
	}

	public static void drawText3(string text, float x, float y, float scale, int r, int g, int b, int justify, float wrapx, float wrapy)
	{
		Function.Call(Hash.SET_TEXT_WRAP, 0f, 1f);
		Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
		Function.Call(Hash.SET_TEXT_COLOUR, r, g, b, 255);
		Function.Call(Hash.SET_TEXT_SCALE, 0f, scale);
		Function.Call(Hash.SET_TEXT_JUSTIFICATION, justify);
		Function.Call(Hash.SET_TEXT_WRAP, wrapx, wrapy);
		Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, x, y, 0.1);
	}

	public static void drawText2(string text, float x, float y, float scale, int r, int g, int b, bool drawright)
	{
		Function.Call(Hash.SET_TEXT_RIGHT_JUSTIFY, drawright);
		Function.Call(Hash.SET_TEXT_WRAP, 0f, 1f);
		Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
		Function.Call(Hash.SET_TEXT_COLOUR, r, g, b, 255);
		Function.Call(Hash.SET_TEXT_SCALE, 0f, scale);
		Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, x, y, 0.1);
	}

	public static void drawText(string text, float x, float y, float scale, int r, int g, int b)
	{
		Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, "STRING");
		Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
		Function.Call(Hash.SET_TEXT_COLOUR, r, g, b, 255);
		Function.Call(Hash.SET_TEXT_SCALE, 0f, scale);
		Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, x, y, 0.1);
	}

	public static float progresswidth(float percent)
	{
		return 0.08f * percent;
	}

	public static float progressxcoord(float percent)
	{
		float num = 0.04f * percent;
		return 0.9f + num;
	}

	public static void Display_Context(string text)
	{
		if (Game.GameTime > CruelMastersOnlineOffline.lastHelpTime + CruelMastersOnlineOffline.helpInterval)
		{
			CruelMastersOnlineOffline.lastHelpTime = Game.GameTime;
			CruelMastersOnlineOffline.DisplayHelpText(text);
		}
	}

	public static void DrawArrow(int markertype, float x, float y, float z, float x2, float y2, float z2, float rotx, float roty, float rotz, float scalex, float scaley, float scalez, int r, int g, int b, int alpha, bool bobupanddown, bool facecamera, bool rotate, string texturedict, string texturename, bool drawonents)
	{
		Function.Call(Hash.DRAW_MARKER, markertype, x, y, z, x2, y2, z2, rotx, roty, rotz, scalex, scaley, scalez, r, g, b, alpha, bobupanddown, facecamera, 2, rotate, texturedict, texturename, drawonents);
	}
}
