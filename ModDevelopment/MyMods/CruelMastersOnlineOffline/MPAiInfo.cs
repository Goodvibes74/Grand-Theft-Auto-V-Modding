using System.Collections.Generic;
using System.IO;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

public class MPAiInfo
{
	public List<AIInfo> ownedInfos = new List<AIInfo>();

	public static Ped CREATE_COMPANION(string FileName, Vector3 pos, float heading)
	{
		MPAiInfo mPAiInfo = new MPAiInfo();
		Ped ped = null;
		if (File.Exists(FileName))
		{
			mPAiInfo = XMLSerializer.DeserializeXML<MPAiInfo>(FileName);
		}
		if (mPAiInfo.ownedInfos[0].Gender == 0)
		{
			ped = World.CreatePed(PedHash.FreemodeMale01, pos, heading);
		}
		if (mPAiInfo.ownedInfos[0].Gender == 1)
		{
			ped = World.CreatePed(PedHash.FreemodeFemale01, pos, heading);
		}
		if (ped.Exists())
		{
			Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, ped);
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, ped, 0, 0, 0, 0, 0, 0, 0f, 0f, 0f, false);
			while (ped.AttachedBlip == null)
			{
				ped.AddBlip();
				Script.Wait(0);
			}
			ped.AttachedBlip.Sprite = BlipSprite.Standard;
			ped.AttachedBlip.Color = Game.PlayerBlip.Color;
			ped.AttachedBlip.Name = mPAiInfo.ownedInfos[0].Name;
			Function.Call(Hash.SHOW_OUTLINE_INDICATOR_ON_BLIP, ped.AttachedBlip, true);
			Function.Call(Hash.SHOW_HEADING_INDICATOR_ON_BLIP, ped.AttachedBlip, true);
			Function.Call(Hash.SHOW_FRIEND_INDICATOR_ON_BLIP, ped.AttachedBlip, true);
			Function.Call(Hash.SHOW_CREW_INDICATOR_ON_BLIP, ped.AttachedBlip, true);
			Function.Call(Hash.SET_BLIP_SCALE, ped.AttachedBlip, 1f);
			Function.Call(Hash.SET_BLIP_CATEGORY, ped.AttachedBlip, 7);
			Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, ped);
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, ped, mPAiInfo.ownedInfos[0].HeadBlendData[0], mPAiInfo.ownedInfos[0].HeadBlendData[1], 0, mPAiInfo.ownedInfos[0].HeadBlendData[2], 0, 0, 0f, 0f, 0f, false);
			for (int i = 1; i < 20; i++)
			{
				Function.Call(Hash.SET_PED_MICRO_MORPH, ped, i, mPAiInfo.ownedInfos[0].FacialFeatures[i]);
			}
			for (int i = 0; i < 10; i++)
			{
				if (mPAiInfo.ownedInfos[0].Overlay[i] != -1)
				{
					Function.Call(Hash.SET_PED_HEAD_OVERLAY, ped, i, mPAiInfo.ownedInfos[0].Overlay[i], mPAiInfo.ownedInfos[0].OverlayOpac[i]);
				}
				if (i != 4 || i != 5 || i != 8)
				{
					Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, ped, i, 1, mPAiInfo.ownedInfos[0].HairColor, 0);
				}
			}
			Function.Call(Hash.SET_PED_HAIR_TINT, ped, mPAiInfo.ownedInfos[0].HairColor, 0);
			Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, ped, mPAiInfo.ownedInfos[0].EyeColor);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, ped, 4, 1, mPAiInfo.ownedInfos[0].MakeupColor, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, ped, 5, 1, mPAiInfo.ownedInfos[0].MakeupColor, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, ped, 8, 1, mPAiInfo.ownedInfos[0].LipstickColor, 0);
			MPCustomOutfits outfit = mPAiInfo.ownedInfos[0].Outfit;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 1, mPAiInfo.ownedInfos[0].Mask[0], mPAiInfo.ownedInfos[0].Mask[1], 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 2, mPAiInfo.ownedInfos[0].Hair, 0, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 3, outfit.CustomOutfits[0].BodyType, outfit.CustomOutfits[0].BodyTypeVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 4, outfit.CustomOutfits[0].Pants, outfit.CustomOutfits[0].PantsVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 5, outfit.CustomOutfits[0].BAP, outfit.CustomOutfits[0].BAPVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 6, outfit.CustomOutfits[0].Shoes, outfit.CustomOutfits[0].ShoesVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 7, outfit.CustomOutfits[0].Accs, outfit.CustomOutfits[0].AccsVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 8, outfit.CustomOutfits[0].US, outfit.CustomOutfits[0].USVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 9, outfit.CustomOutfits[0].BA, outfit.CustomOutfits[0].BAVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 10, outfit.CustomOutfits[0].Decals, outfit.CustomOutfits[0].DecalsVar, 2);
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, 11, outfit.CustomOutfits[0].Tops, outfit.CustomOutfits[0].TopsVar, 2);
			if (outfit.CustomOutfits[0].Hats != -1)
			{
				Function.Call(Hash.SET_PED_PROP_INDEX, ped, 0, outfit.CustomOutfits[0].Hats, outfit.CustomOutfits[0].HatsVar, true);
			}
			if (outfit.CustomOutfits[0].Glasses != -1)
			{
				Function.Call(Hash.SET_PED_PROP_INDEX, ped, 1, outfit.CustomOutfits[0].Glasses, outfit.CustomOutfits[0].GlassesVar, true);
			}
			if (outfit.CustomOutfits[0].EarAccs != -1)
			{
				Function.Call(Hash.SET_PED_PROP_INDEX, ped, 2, outfit.CustomOutfits[0].EarAccs, outfit.CustomOutfits[0].EarAccsVar, true);
			}
			if (outfit.CustomOutfits[0].Watches != -1)
			{
				Function.Call(Hash.SET_PED_PROP_INDEX, ped, 6, outfit.CustomOutfits[0].Watches, outfit.CustomOutfits[0].WatchesVar, true);
			}
			if (outfit.CustomOutfits[0].Bracelets != -1)
			{
				Function.Call(Hash.SET_PED_PROP_INDEX, ped, 7, outfit.CustomOutfits[0].Bracelets, outfit.CustomOutfits[0].BraceletsVar, true);
			}
			Groups.SET_INTO_GROUP(ped);
			return ped;
		}
		return null;
	}
}
