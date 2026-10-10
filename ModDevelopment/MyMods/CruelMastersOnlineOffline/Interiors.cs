using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Interiors
{
	public static void IslandLoad(bool isislandloaded)
	{
		Function.Call(Hash.SET_SCENARIO_GROUP_ENABLED, "Heist_Island_Peds", isislandloaded);
		int num = Function.Call<int>(Hash.GET_ZONE_FROM_NAME_ID, "IsHeist");
		Function.Call(Hash.SET_ZONE_ENABLED, num, isislandloaded);
		Function.Call(Hash.SET_ISLAND_ENABLED, "HeistIsland", isislandloaded);
		Function.Call(Hash.SET_USE_ISLAND_MAP, isislandloaded);
		Function.Call(Hash.SET_AMBIENT_ZONE_LIST_STATE_PERSISTENT, "azl_dlc_hei4_island_zones", 1, 1);
		Function.Call(Hash.SET_AMBIENT_ZONE_LIST_STATE_PERSISTENT, "AZL_DLC_Hei4_Island_Disabled_Zones", 1, 1);
		Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_01_left", isislandloaded);
		Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_01_right", isislandloaded);
		Function.Call(Hash.SET_ALLOW_STREAM_HEIST_ISLAND_NODES, isislandloaded);
		if (isislandloaded)
		{
			Function.Call(Hash.SET_CALMED_WAVE_HEIGHT_SCALER, 0.02f);
		}
		else
		{
			Function.Call(Hash.SET_CALMED_WAVE_HEIGHT_SCALER, 1f);
		}
		if (!isislandloaded)
		{
			Function.Call(Hash.REMOVE_IPL, "h4_islandx");
			Function.Call(Hash.REMOVE_IPL, "h4_islandx_disc_strandedshark");
			Function.Call(Hash.REMOVE_IPL, "h4_islandx_disc_strandedshark_lod");
			Function.Call(Hash.REMOVE_IPL, "h4_islandx_disc_strandedwhale");
			Function.Call(Hash.REMOVE_IPL, "h4_islandx_disc_strandedwhale_lod");
			Function.Call(Hash.REMOVE_IPL, "h4_islandx_props");
			Function.Call(Hash.REMOVE_IPL, "h4_islandx_props_lod");
			Function.Call(Hash.REMOVE_IPL, "h4_islandx_sea_mines");
		}
		else
		{
			Function.Call(Hash.REQUEST_IPL, "h4_islandx");
			Function.Call(Hash.REQUEST_IPL, "h4_islandx_disc_strandedshark");
			Function.Call(Hash.REQUEST_IPL, "h4_islandx_disc_strandedshark_lod");
			Function.Call(Hash.REQUEST_IPL, "h4_islandx_disc_strandedwhale");
			Function.Call(Hash.REQUEST_IPL, "h4_islandx_disc_strandedwhale_lod");
			Function.Call(Hash.REQUEST_IPL, "h4_islandx_props");
			Function.Call(Hash.REQUEST_IPL, "h4_islandx_props_lod");
			Function.Call(Hash.REQUEST_IPL, "h4_islandx_sea_mines");
		}
	}

	public static void LoadNorthYankton()
	{
		Function.Call(Hash.REQUEST_IPL, "plg_01");
		Function.Call(Hash.REQUEST_IPL, "prologue01");
		Function.Call(Hash.REQUEST_IPL, "prologue01_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01c");
		Function.Call(Hash.REQUEST_IPL, "prologue01c_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01d");
		Function.Call(Hash.REQUEST_IPL, "prologue01d_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01e");
		Function.Call(Hash.REQUEST_IPL, "prologue01e_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01f");
		Function.Call(Hash.REQUEST_IPL, "prologue01f_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01g");
		Function.Call(Hash.REQUEST_IPL, "prologue01h");
		Function.Call(Hash.REQUEST_IPL, "prologue01h_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01i");
		Function.Call(Hash.REQUEST_IPL, "prologue01i_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01j");
		Function.Call(Hash.REQUEST_IPL, "prologue01j_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01k");
		Function.Call(Hash.REQUEST_IPL, "prologue01k_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue01z");
		Function.Call(Hash.REQUEST_IPL, "prologue01z_lod");
		Function.Call(Hash.REQUEST_IPL, "plg_02");
		Function.Call(Hash.REQUEST_IPL, "prologue02");
		Function.Call(Hash.REQUEST_IPL, "prologue02_lod");
		Function.Call(Hash.REQUEST_IPL, "plg_03");
		Function.Call(Hash.REQUEST_IPL, "prologue03");
		Function.Call(Hash.REQUEST_IPL, "prologue03_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue03b");
		Function.Call(Hash.REQUEST_IPL, "prologue03b_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue03_grv_dug");
		Function.Call(Hash.REQUEST_IPL, "prologue03_grv_dug_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue_grv_torch");
		Function.Call(Hash.REQUEST_IPL, "plg_04");
		Function.Call(Hash.REQUEST_IPL, "prologue04");
		Function.Call(Hash.REQUEST_IPL, "prologue04_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue04b");
		Function.Call(Hash.REQUEST_IPL, "prologue04b_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue04_cover");
		Function.Call(Hash.REQUEST_IPL, "des_protree_end");
		Function.Call(Hash.REQUEST_IPL, "des_protree_start");
		Function.Call(Hash.REQUEST_IPL, "des_protree_start_lod");
		Function.Call(Hash.REQUEST_IPL, "plg_05");
		Function.Call(Hash.REQUEST_IPL, "prologue05");
		Function.Call(Hash.REQUEST_IPL, "prologue05_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue05b");
		Function.Call(Hash.REQUEST_IPL, "prologue05b_lod");
		Function.Call(Hash.REQUEST_IPL, "plg_06");
		Function.Call(Hash.REQUEST_IPL, "prologue06");
		Function.Call(Hash.REQUEST_IPL, "prologue06_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue06b");
		Function.Call(Hash.REQUEST_IPL, "prologue06b_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue06_int");
		Function.Call(Hash.REQUEST_IPL, "prologue06_int_lod");
		Function.Call(Hash.REQUEST_IPL, "prologue06_pannel");
		Function.Call(Hash.REQUEST_IPL, "prologue06_pannel_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue_m2_door");
		Function.Call(Hash.REMOVE_IPL, "prologue_m2_door_lod");
		Function.Call(Hash.REQUEST_IPL, "plg_occl_00");
		Function.Call(Hash.REQUEST_IPL, "prologue_occl");
		Function.Call(Hash.REQUEST_IPL, "plg_rd");
		Function.Call(Hash.REQUEST_IPL, "prologuerd");
		Function.Call(Hash.REQUEST_IPL, "prologuerdb");
		Function.Call(Hash.REQUEST_IPL, "prologuerd_lod");
	}

	public static void UnLoadNorthYankton()
	{
		Function.Call(Hash.REMOVE_IPL, "plg_01");
		Function.Call(Hash.REMOVE_IPL, "prologue01");
		Function.Call(Hash.REMOVE_IPL, "prologue01_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01c");
		Function.Call(Hash.REMOVE_IPL, "prologue01c_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01d");
		Function.Call(Hash.REMOVE_IPL, "prologue01d_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01e");
		Function.Call(Hash.REMOVE_IPL, "prologue01e_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01f");
		Function.Call(Hash.REMOVE_IPL, "prologue01f_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01g");
		Function.Call(Hash.REMOVE_IPL, "prologue01h");
		Function.Call(Hash.REMOVE_IPL, "prologue01h_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01i");
		Function.Call(Hash.REMOVE_IPL, "prologue01i_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01j");
		Function.Call(Hash.REMOVE_IPL, "prologue01j_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01k");
		Function.Call(Hash.REMOVE_IPL, "prologue01k_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue01z");
		Function.Call(Hash.REMOVE_IPL, "prologue01z_lod");
		Function.Call(Hash.REMOVE_IPL, "plg_02");
		Function.Call(Hash.REMOVE_IPL, "prologue02");
		Function.Call(Hash.REMOVE_IPL, "prologue02_lod");
		Function.Call(Hash.REMOVE_IPL, "plg_03");
		Function.Call(Hash.REMOVE_IPL, "prologue03");
		Function.Call(Hash.REMOVE_IPL, "prologue03_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue03b");
		Function.Call(Hash.REMOVE_IPL, "prologue03b_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue03_grv_dug");
		Function.Call(Hash.REMOVE_IPL, "prologue03_grv_dug_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue_grv_torch");
		Function.Call(Hash.REMOVE_IPL, "plg_04");
		Function.Call(Hash.REMOVE_IPL, "prologue04");
		Function.Call(Hash.REMOVE_IPL, "prologue04_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue04b");
		Function.Call(Hash.REMOVE_IPL, "prologue04b_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue04_cover");
		Function.Call(Hash.REMOVE_IPL, "des_protree_end");
		Function.Call(Hash.REMOVE_IPL, "des_protree_start");
		Function.Call(Hash.REMOVE_IPL, "des_protree_start_lod");
		Function.Call(Hash.REMOVE_IPL, "plg_05");
		Function.Call(Hash.REMOVE_IPL, "prologue05");
		Function.Call(Hash.REMOVE_IPL, "prologue05_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue05b");
		Function.Call(Hash.REMOVE_IPL, "prologue05b_lod");
		Function.Call(Hash.REMOVE_IPL, "plg_06");
		Function.Call(Hash.REMOVE_IPL, "prologue06");
		Function.Call(Hash.REMOVE_IPL, "prologue06_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue06b");
		Function.Call(Hash.REMOVE_IPL, "prologue06b_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue06_int");
		Function.Call(Hash.REMOVE_IPL, "prologue06_int_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue06_pannel");
		Function.Call(Hash.REMOVE_IPL, "prologue06_pannel_lod");
		Function.Call(Hash.REMOVE_IPL, "prologue_m2_door");
		Function.Call(Hash.REMOVE_IPL, "prologue_m2_door_lod");
		Function.Call(Hash.REMOVE_IPL, "plg_occl_00");
		Function.Call(Hash.REMOVE_IPL, "prologue_occl");
		Function.Call(Hash.REMOVE_IPL, "plg_rd");
		Function.Call(Hash.REMOVE_IPL, "prologuerd");
		Function.Call(Hash.REMOVE_IPL, "prologuerdb");
		Function.Call(Hash.REMOVE_IPL, "prologuerd_lod");
	}

	public static void REMOVE_IPL(string iplName)
	{
		Function.Call(Hash.REMOVE_IPL, iplName);
	}

	public static void REQUEST_IPL(string iplName)
	{
		Function.Call(Hash.REQUEST_IPL, iplName);
	}

	public static bool IS_IPL_ACTIVE(string iplName)
	{
		return Function.Call<bool>(Hash.IS_IPL_ACTIVE, iplName);
	}

	public static bool IS_ENTITY_IN_ZONE(Entity entity, string zone)
	{
		return Function.Call<bool>(Hash.IS_ENTITY_IN_ZONE, entity, zone);
	}

	public static bool IS_ENTITY_IN_INTERIOR(Entity entity, float interiorx, float interiory, float interiorz)
	{
		return Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, interiorx, interiory, interiorz) == Function.Call<int>(Hash.GET_INTERIOR_FROM_ENTITY, entity);
	}

	public static int GET_INTERIOR_FROM_ENTITY(Entity entity)
	{
		return Function.Call<int>(Hash.GET_INTERIOR_FROM_ENTITY, entity);
	}

	public static Hash GET_ROOM_KEY_FROM_ENTITY(Entity entity)
	{
		return Function.Call<Hash>(Hash.GET_ROOM_KEY_FROM_ENTITY, entity);
	}

	public static void PIN_INTERIOR_IN_MEMORY(int interior)
	{
		Function.Call(Hash.PIN_INTERIOR_IN_MEMORY, interior);
	}

	public static void UNPIN_INTERIOR(int interior)
	{
		Function.Call(Hash.UNPIN_INTERIOR, interior);
	}

	public static bool IS_INTERIOR_READY(int interior)
	{
		return Function.Call<bool>(Hash.IS_INTERIOR_READY, interior);
	}

	public static void ACTIVATE_INTERIOR_ENTITY_SET(int interior, string entitysetname)
	{
		Function.Call(Hash.ACTIVATE_INTERIOR_ENTITY_SET, interior, entitysetname);
	}

	public static void DEACTIVATE_INTERIOR_ENTITY_SET(int interior, string entitysetname)
	{
		Function.Call(Hash.DEACTIVATE_INTERIOR_ENTITY_SET, interior, entitysetname);
	}

	public static bool IS_INTERIOR_ENTITY_SET_ACTIVE(int interior, string entitysetname)
	{
		return Function.Call<bool>(Hash.IS_INTERIOR_ENTITY_SET_ACTIVE, interior, entitysetname);
	}

	public static void _SET_INTERIOR_ENTITY_SET_COLOR(int interior, string entitysetname, int color)
	{
		Function.Call(Hash.SET_INTERIOR_ENTITY_SET_TINT_INDEX, interior, entitysetname, color);
	}

	public static void REFRESH_INTERIOR(int interior)
	{
		Function.Call(Hash.REFRESH_INTERIOR, interior);
	}
}
