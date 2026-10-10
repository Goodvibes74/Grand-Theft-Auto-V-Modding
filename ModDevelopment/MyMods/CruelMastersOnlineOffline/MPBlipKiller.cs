using System;
using GTA;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

internal class MPBlipKiller : Script
{
	public MPBlipKiller()
	{
		Tick += onTick;
		Aborted += onShutdown;
	}

	public void onTick(object sender, EventArgs e)
	{
		if (Game.IsLoading || Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE) || Screen.IsFadingIn)
		{
			return;
		}
		Blip[] allBlips = World.GetAllBlips(BlipSprite.BaseJump, BlipSprite.Triathlon, BlipSprite.OffRoadRaceFinish, BlipSprite.RaceAir, BlipSprite.RaceCar, BlipSprite.RaceSea, BlipSprite.Business, BlipSprite.Airport, BlipSprite.MovieTheater, BlipSprite.Lift, BlipSprite.TattooParlor, BlipSprite.Dart, BlipSprite.CarWash, BlipSprite.StripClub, BlipSprite.Fairground, BlipSprite.Barber, BlipSprite.Golf);
		Blip[] array = allBlips;
		foreach (Blip blip in array)
		{
			if (Function.Call<bool>(Hash.DOES_BLIP_EXIST, blip))
			{
				if (blip.Color == BlipColor.White && blip.DisplayType == BlipDisplayType.Default && blip.IsShortRange && !blip.IsHiddenOnLegend)
				{
					Function.Call(Hash.SET_THIS_SCRIPT_CAN_REMOVE_BLIPS_CREATED_BY_ANY_SCRIPT, true);
					blip.Delete();
					Function.Call(Hash.SET_THIS_SCRIPT_CAN_REMOVE_BLIPS_CREATED_BY_ANY_SCRIPT, false);
				}
				if (blip.Color == BlipColor.Michael || blip.Color == BlipColor.Trevor || (blip.Color == BlipColor.Franklin && blip.DisplayType == BlipDisplayType.Default && blip.IsShortRange && !blip.IsHiddenOnLegend && blip.CategoryType == BlipCategoryType.OwnedProperty) || blip.CategoryType == BlipCategoryType.Property)
				{
					Function.Call(Hash.SET_THIS_SCRIPT_CAN_REMOVE_BLIPS_CREATED_BY_ANY_SCRIPT, true);
					blip.Delete();
					Function.Call(Hash.SET_THIS_SCRIPT_CAN_REMOVE_BLIPS_CREATED_BY_ANY_SCRIPT, false);
				}
			}
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		Function.Call(Hash.SET_THIS_SCRIPT_CAN_REMOVE_BLIPS_CREATED_BY_ANY_SCRIPT, false);
	}
}
