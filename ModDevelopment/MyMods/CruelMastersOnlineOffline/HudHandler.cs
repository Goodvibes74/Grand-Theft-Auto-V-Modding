using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class HudHandler
{
	public static float traveldistance;

	public static List<Blip> SearchAreas = new List<Blip>();

	public static void SET_GPS(Blip blip, int color, bool displayonfoot, bool followplayer)
	{
		if (blip != null)
		{
			Function.Call(Hash.CLEAR_GPS_MULTI_ROUTE);
			Function.Call(Hash.START_GPS_MULTI_ROUTE, color, followplayer, displayonfoot);
			Function.Call(Hash.SET_GPS_MULTI_ROUTE_RENDER, true);
			Function.Call(Hash.ADD_POINT_TO_GPS_MULTI_ROUTE, blip.Position.X, blip.Position.Y, blip.Position.Z);
		}
	}

	public static void CLEAR_GPS_ROUTE()
	{
		Function.Call(Hash.CLEAR_GPS_MULTI_ROUTE);
	}

	public static bool DOES_BLIP_HAVE_GPS_ROUTE(Blip blip)
	{
		return Function.Call<bool>(Hash.DOES_BLIP_HAVE_GPS_ROUTE, blip);
	}

	public static void FLASH_MINIMAP_DISPLAY()
	{
		Function.Call(Hash.FLASH_MINIMAP_DISPLAY);
	}

	public static void CLEAR_ALL_HELP_MESSAGES()
	{
		Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
	}

	public static void HudandRadar(bool Hud, bool Radar)
	{
		Function.Call(Hash.DISPLAY_HUD, Hud);
		Function.Call(Hash.DISPLAY_RADAR, Radar);
	}

	public static void Remove_Wanted_Level()
	{
		Game.Player.WantedLevel = 0;
	}

	public static void Set_Fake_Wanted_Level(int level)
	{
		Function.Call(Hash.SET_FAKE_WANTED_LEVEL, level);
	}

	public static void MissionBlipGPSController(Blip missionBlip)
	{
		if (missionBlip != null)
		{
			traveldistance = Function.Call<float>(Hash.CALCULATE_TRAVEL_DISTANCE_BETWEEN_POINTS, missionBlip.Position.X, missionBlip.Position.Y, missionBlip.Position.Z, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z);
		}
	}

	public static void DrawArrow(int markertype, float x, float y, float z, float x2, float y2, float z2, float rotx, float roty, float rotz, float scalex, float scaley, float scalez, int r, int g, int b, int alpha, bool bobupanddown, bool facecamera, bool rotate, string texturedict, string texturename, bool drawonents)
	{
		Function.Call(Hash.DRAW_MARKER, markertype, x, y, z, x2, y2, z2, rotx, roty, rotz, scalex, scaley, scalez, r, g, b, alpha, bobupanddown, facecamera, 2, rotate, texturedict, texturename, drawonents);
	}

	public static void End_Mission_Ring()
	{
		Audio.SetAudioFlag(AudioFlags.LoadMPData, toggle: true);
		Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Pre_Screen_Stinger", "DLC_HEISTS_PREP_SCREEN_SOUNDS", true);
		Function.Call(Hash.ANIMPOSTFX_PLAY, "HeistCelebEnd", 5000, false);
	}

	public static void BlipUpBlips(List<Blip> list)
	{
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Blip item in list)
		{
			if (item != null)
			{
				item.Sprite = BlipSprite.Standard;
				item.Color = BlipColor.Yellow;
			}
		}
	}

	public static void CheckBlips(List<Blip> list, int radius)
	{
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Blip item in list.ToList())
		{
			if (item != null && Game.Player.Character.Position.DistanceTo(item.Position) < (float)radius)
			{
				item.Alpha = 155;
			}
			else if (item != null && Game.Player.Character.Position.DistanceTo(item.Position) > (float)radius)
			{
				item.Alpha = 255;
			}
		}
	}

	public static void RemoveBlips(List<Blip> list)
	{
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Blip item in list.ToList())
		{
			if (item != null)
			{
				item.Delete();
			}
		}
	}

	public static Blip CREATE_BLIP(Vector3 position)
	{
		return World.CreateBlip(position);
	}

	public static Blip CREATE_BLIP_WITH_RADIUS(Vector3 position, float radius)
	{
		return World.CreateBlip(position, radius);
	}

	public static void ADD_BLIP_TO_LIST(List<Blip> list, Blip blip)
	{
		if (blip != null)
		{
			list.Add(blip);
		}
	}

	public static void SET_PLAYER_WANTED_LEVEL_NO_DROP(Player player, int wantedLevel)
	{
		Function.Call(Hash.SET_PLAYER_WANTED_LEVEL_NO_DROP, player, wantedLevel, false);
	}

	public unsafe static string GetStreetName(Blip ObjectOfreference)
	{
		if (ObjectOfreference != null)
		{
			Vector3 position = ObjectOfreference.Position;
			Hash hash = (Hash)0uL;
			Hash hash2 = (Hash)0uL;
			Function.Call(Hash.GET_STREET_NAME_AT_COORD, position.X, position.Y, position.Z, &hash, &hash2);
			string result = Function.Call<string>(Hash.GET_STREET_NAME_FROM_HASH_KEY, hash);
			string text = Function.Call<string>(Hash.GET_NAME_OF_ZONE, position.X, position.Y, position.Z);
			string text2 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, text);
			return result;
		}
		return "";
	}

	public static string GetZoneName(Blip ObjectOfreference)
	{
		if (ObjectOfreference != null)
		{
			Vector3 position = ObjectOfreference.Position;
			return Function.Call<string>(Hash.GET_NAME_OF_ZONE, position.X, position.Y, position.Z);
		}
		return "";
	}

	public static void SET_BLIP_FLASH(Blip blip = null, bool isFlashing = true, int flashInterval = 800, int flashTimeLeft = 5000)
	{
		if (blip != null)
		{
			blip.IsFlashing = isFlashing;
			blip.FlashInterval = flashInterval;
			blip.FlashTimeLeft = flashTimeLeft;
		}
	}
}
