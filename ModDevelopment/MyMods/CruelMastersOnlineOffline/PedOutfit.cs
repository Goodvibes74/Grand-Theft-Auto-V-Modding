using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

public class PedOutfit
{
	public struct OutfitComponent
	{
		public PedVarComp ComponentId;

		public int DrawableId;

		public int TextureId;

		public int PaletteId;

		public void Equip(Ped ped)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, (int)ComponentId, DrawableId, TextureId, PaletteId);
		}
	}

	public enum PedVarComp
	{
		PV_COMP_INVALID = -1,
		PV_COMP_HEAD,
		PV_COMP_BERD,
		PV_COMP_HAIR,
		PV_COMP_UPPR,
		PV_COMP_LOWR,
		PV_COMP_HAND,
		PV_COMP_FEET,
		PV_COMP_TEEF,
		PV_COMP_ACCS,
		PV_COMP_TASK,
		PV_COMP_DECL,
		PV_COMP_JBIB,
		PV_COMP_MAX
	}

	public struct OutfitProp
	{
		public PedPropsData ComponentId;

		public int DrawableId;

		public int TextureId;

		public void Equip(Ped ped)
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, ped, (int)ComponentId, DrawableId, TextureId);
		}
	}

	public enum PedPropsData
	{
		PED_PROP_HATS,
		PED_PROP_GLASSES,
		PED_PROP_EARS,
		PED_PROP_WATCHES
	}

	[StructLayout(LayoutKind.Explicit, Size = 80)]
	public struct HeadBlendData
	{
		[FieldOffset(0)]
		public int ShapeFirst;

		[FieldOffset(8)]
		public int ShapeSecond;

		[FieldOffset(16)]
		public int ShapeThird;

		[FieldOffset(24)]
		public int SkinFirst;

		[FieldOffset(32)]
		public int SkinSecond;

		[FieldOffset(40)]
		public int SkinThird;

		[FieldOffset(48)]
		public float ShapeMix;

		[FieldOffset(56)]
		public float SkinMix;

		[FieldOffset(64)]
		public float ThirdMix;
	}

	public delegate ulong gExtensionListGetDelegate(IntPtr address, ulong list);

	[StructLayout(LayoutKind.Explicit)]
	public struct CPedHeadBlendData
	{
		[FieldOffset(160)]
		public unsafe fixed float faceFeature[20];
	}

	public static float[] FaceFeaturePart = new float[21];

	public static int[] OverlayPart = new int[13]
	{
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1
	};

	public static float[] OpacityPart = new float[13]
	{
		-1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f,
		-1f, -1f, -1f
	};

	public static int[] OutfitPart = new int[13];

	public static int[] OutfitPart2 = new int[13];

	public static int[] OutfitPart3 = new int[9];

	public static int[] OutfitPart4 = new int[9];

	public List<OutfitComponent> Components;

	public List<OutfitProp> Props;

	public static int[] HairPart = new int[3];

	public static bool MaskSetGrabbed = false;

	public static HeadBlendData Data = default;

	public static gExtensionListGetDelegate ExtensionListGet;

	public unsafe static ulong* _id_CPedHeadBlendData;

	public void Equip(Ped ped)
	{
		foreach (OutfitComponent component in Components)
		{
			component.Equip(ped);
		}
		foreach (OutfitProp prop in Props)
		{
			prop.Equip(ped);
		}
	}

	public static void OutfitOFF(Ped NonCutscene)
	{
		if (CruelMastersOnlineOffline.IsFreemodeMale || CruelMastersOnlineOffline.IsFreemodeFemale)
		{
			for (int i = 0; i < OutfitPart.Length; i++)
			{
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, i, OutfitPart[i], OutfitPart2[i], 2);
			}
			for (int j = 0; j < OutfitPart3.Length; j++)
			{
				Function.Call(Hash.SET_PED_PROP_INDEX, NonCutscene, j, OutfitPart3[j], OutfitPart4[j], true);
			}
		}
	}

	public static void GET_OUTFIT(Ped NonCutscene)
	{
		for (int i = 0; i < OutfitPart.Length; i++)
		{
			OutfitPart[i] = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, i);
			OutfitPart2[i] = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, i);
		}
		for (int j = 0; j < OutfitPart3.Length; j++)
		{
			OutfitPart3[j] = Function.Call<int>(Hash.GET_PED_PROP_INDEX, NonCutscene, j);
			OutfitPart4[j] = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, NonCutscene, j);
		}
	}

	public static void TestPatterns(string pattern)
	{
		IntPtr intPtr = Game.FindPattern(pattern, (IntPtr)0);
		if (intPtr != IntPtr.Zero)
		{
			Notification.Show("Pattern found");
		}
		if (intPtr == IntPtr.Zero)
		{
			Notification.Show("Pattern not found");
		}
	}

	public static void MaskON(Ped NonCutscene, int maskdraw, int masktxd)
	{
		if (CruelMastersOnlineOffline.IsFreemodeMale || CruelMastersOnlineOffline.IsFreemodeFemale)
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, NonCutscene, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);
			for (int i = 0; i < 20; i++)
			{
				Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, i, 0f);
			}
			if (maskdraw == 0)
			{
				MaskOFF(NonCutscene);
			}
			else
			{
				Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, maskdraw, masktxd, 1);
			}
		}
	}

	public static void MaskOFF(Ped NonCutscene)
	{
		if (CruelMastersOnlineOffline.IsFreemodeMale || CruelMastersOnlineOffline.IsFreemodeFemale)
		{
			for (int i = 0; i < 20; i++)
			{
				Function.Call(Hash.SET_PED_MICRO_MORPH, NonCutscene, i, FaceFeaturePart[i]);
			}
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, NonCutscene, Data.ShapeFirst, Data.ShapeSecond, Data.ShapeThird, Data.SkinFirst, Data.SkinSecond, Data.SkinThird, Data.ShapeMix, Data.SkinMix, Data.ThirdMix, true);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 1, 0, 0, 2);
		}
	}

	public unsafe static void GET_FACE(Ped NonCutscene)
	{
		HeadBlendData data = default;
		Function.Call(Hash.GET_PED_HEAD_BLEND_DATA, Game.Player.Character, &data);
		Data = data;
		HairPart[0] = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, NonCutscene, 2);
		HairPart[1] = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, NonCutscene, 2);
		int i = 1;
		float num = 0f;
		for (; i < 20; i++)
		{
			FaceFeaturePart[i] = GET_PED_FACE_FEATURE(NonCutscene, i);
		}
	}

	public unsafe static float GET_PED_FACE_FEATURE(Ped ped, int index)
	{
		float num = 0f;
		IntPtr memoryAddress = ped.MemoryAddress;
		if (index >= 0 && index < 20 && memoryAddress != IntPtr.Zero)
		{
			CPedHeadBlendData* pedHeadBlendData = GetPedHeadBlendData(memoryAddress);
			if (pedHeadBlendData != null)
			{
				return pedHeadBlendData->faceFeature[index];
			}
		}
		return 0f;
	}

	public unsafe static void InitHeadBlendData()
	{
		IntPtr intPtr = Game.FindPattern("48 39 5E 38 74 1B 8B 15 ? ? ? ? 48 8D 4F 10 E8", (IntPtr)0);
		if (intPtr != IntPtr.Zero)
		{
			intPtr += 8;
			_id_CPedHeadBlendData = (ulong*)(void*)(intPtr + *(int*)(void*)intPtr + 4);
		}
	}

	public static void InitExtensionListGet()
	{
		IntPtr intPtr = Game.FindPattern("41 83 E0 1F 8B 44 81 08 44 0F A3 C0", (IntPtr)0);
		if (intPtr != IntPtr.Zero)
		{
			intPtr -= 31;
			ExtensionListGet = Marshal.GetDelegateForFunctionPointer<gExtensionListGetDelegate>(intPtr);
		}
	}

	public unsafe static CPedHeadBlendData* GetPedHeadBlendData(IntPtr pedAddr)
	{
		if ((*(byte*)(*(long*)(void*)(pedAddr + 32) + 646) & 2) != 0)
		{
			return (CPedHeadBlendData*)ExtensionListGet(pedAddr + 16, *_id_CPedHeadBlendData);
		}
		return null;
	}

	public unsafe static int STRING_TO_INT(string str, int iVar0)
	{
		if (Function.Call<bool>(Hash.STRING_TO_INT, str, &iVar0))
		{
			return iVar0;
		}
		return 0;
	}

	public static Hash joaat(string str)
	{
		return Function.Call<Hash>(Hash.GET_HASH_KEY, str);
	}

	public static bool STAT_GET_FLOAT(string hash, out float outValue)
	{
		OutputArgument outputArgument = new OutputArgument();
		if (Function.Call<bool>(Hash.STAT_GET_FLOAT, CruelMastersOnlineOffline.joaat(hash), outputArgument, -1))
		{
			outValue = outputArgument.GetResult<float>();
			Notification.Show($"Stat Got: {outValue}");
			return true;
		}
		outValue = 0f;
		return false;
	}

	public unsafe static int STAT_GET_INT(string hash)
	{
		int num = 0;
		if (Function.Call<bool>(Hash.STAT_GET_INT, CruelMastersOnlineOffline.joaat(hash), &num, -1))
		{
			Notification.Show($"Face Features Got: {num}");
			return num;
		}
		return 0;
	}

	public static void GetPedDuffelBagOn(Ped NonCutscene, int texture)
	{
		if (CruelMastersOnlineOffline.IsFreemodeMale || CruelMastersOnlineOffline.IsFreemodeFemale)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, 82, texture, 1);
		}
		if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, 1, 0, 2);
		}
	}

	public static void GetPedDuffelBagOff(Ped NonCutscene)
	{
		if (CruelMastersOnlineOffline.IsFreemodeMale || CruelMastersOnlineOffline.IsFreemodeFemale)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 5, 0, 0, 1);
		}
		if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, NonCutscene, 9, 0, 0, 2);
		}
	}
}
