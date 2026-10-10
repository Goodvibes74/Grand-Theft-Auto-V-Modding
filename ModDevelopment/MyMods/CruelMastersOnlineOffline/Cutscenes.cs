using GTA;
using GTA.Native;

namespace CruelMastersOnlineOffline;

internal class Cutscenes : Script
{
	public enum CUTSCENE_SECTION
	{
		CS_SECTION_1 = 1,
		CS_SECTION_2 = 2,
		CS_SECTION_3 = 4,
		CS_SECTION_4 = 8,
		CS_SECTION_5 = 0x10,
		CS_SECTION_6 = 0x20,
		CS_SECTION_7 = 0x40,
		CS_SECTION_8 = 0x80,
		CS_SECTION_9 = 0x100,
		CS_SECTION_10 = 0x200,
		CS_SECTION_11 = 0x400,
		CS_SECTION_12 = 0x800,
		CS_SECTION_13 = 0x1000,
		CS_SECTION_14 = 0x2000,
		CS_SECTION_15 = 0x4000,
		CS_SECTION_16 = 0x8000,
		CS_SECTION_17 = 0x10000,
		CS_SECTION_18 = 0x20000,
		CS_SECTION_19 = 0x40000,
		CS_SECTION_20 = 0x80000,
		CS_SECTION_21 = 0x100000,
		CS_SECTION_22 = 0x200000,
		CS_SECTION_23 = 0x400000,
		CS_SECTION_24 = 0x800000,
		CS_SECTION_25 = 0x1000000,
		CS_SECTION_26 = 0x2000000,
		CS_SECTION_27 = 0x4000000,
		CS_SECTION_28 = 0x8000000,
		CS_SECTION_29 = 0x10000000,
		CS_SECTION_30 = 0x20000000,
		CS_SECTION_31 = 0x40000000
	}

	public static int GET_CUTSCENE_TIME()
	{
		return Function.Call<int>(Hash.GET_CUTSCENE_TIME);
	}

	public static bool HAS_CUTSCENE_FINISHED()
	{
		return Function.Call<bool>(Hash.HAS_CUTSCENE_FINISHED);
	}

	public static bool HAS_CUTSCENE_LOADED()
	{
		return Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED);
	}

	public static void RegisterEntityForCutscene(Entity entity, string cutsceneEntityName, int p2 = 2, int p4 = 0)
	{
		Function.Call(Hash.REGISTER_ENTITY_FOR_CUTSCENE, entity, cutsceneEntityName, p2, 0, p4);
	}
}
