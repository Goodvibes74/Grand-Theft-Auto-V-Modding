using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

public class MPOwnedVehicles
{
	public List<OwnedVehicle> ownedVehicles = new List<OwnedVehicle>();

	public static void SAVE_PREVIOUS_OWNED_VEHICLE(string LoadoutFilename, string name)
	{
		MPVehicleLoadout mPVehicleLoadout = XMLSerializer.DeserializeXML<MPVehicleLoadout>(LoadoutFilename);
		MPOwnedVehicles mPOwnedVehicles = new MPOwnedVehicles();
		OwnedVehicle ownedVehicle = new OwnedVehicle();
		ownedVehicle.VehicleName = name;
		ownedVehicle.VehicleID = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles").Count();
		ownedVehicle.VehicleStats = mPVehicleLoadout.CurrenVehicleLoadout[0];
		mPOwnedVehicles.ownedVehicles.Add(ownedVehicle);
		XMLSerializer.SaveToXML(mPOwnedVehicles, "scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles\\" + mPOwnedVehicles.ownedVehicles[0].VehicleName + ".xml");
	}

	public static Vehicle GET_VEHICLE_LOADOUT(string Filename, Vector3 SpawnLoc, float SpawnHeading)
	{
		MPOwnedVehicles mPOwnedVehicles = XMLSerializer.DeserializeXML<MPOwnedVehicles>(Filename);
		Vehicle vehicle = World.CreateVehicle(mPOwnedVehicles.ownedVehicles[0].VehicleStats.VehicleHash, SpawnLoc, SpawnHeading);
		Function.Call(Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);
		Function.Call(Hash.SET_VEHICLE_MOD_COLOR_1, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ModPaint1[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.ModPaint1[1], mPOwnedVehicles.ownedVehicles[0].VehicleStats.ModPaint1[2]);
		Function.Call(Hash.SET_VEHICLE_MOD_COLOR_2, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ModPaint2[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.ModPaint2[1]);
		Function.Call(Hash.SET_VEHICLE_COLOURS, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.Paints[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.Paints[1]);
		if (mPOwnedVehicles.ownedVehicles[0].VehicleStats.ModPaintIsCustom[0])
		{
			Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.PrimaryPaint[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.PrimaryPaint[1], mPOwnedVehicles.ownedVehicles[0].VehicleStats.PrimaryPaint[2]);
		}
		if (mPOwnedVehicles.ownedVehicles[0].VehicleStats.ModPaintIsCustom[1])
		{
			Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.SecondaryPaint[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.SecondaryPaint[1], mPOwnedVehicles.ownedVehicles[0].VehicleStats.SecondaryPaint[2]);
		}
		Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.RimPaint[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.RimPaint[1]);
		Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.TyreSmokeRGBColor[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.TyreSmokeRGBColor[1], mPOwnedVehicles.ownedVehicles[0].VehicleStats.TyreSmokeRGBColor[2]);
		Function.Call(Hash.SET_VEHICLE_EXTRA_COLOUR_5, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ExtraColors[0]);
		Function.Call(Hash.SET_VEHICLE_EXTRA_COLOUR_6, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ExtraColors[1]);
		Function.Call(Hash.SET_VEHICLE_XENON_LIGHT_COLOR_INDEX, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.XeonLightColor);
		Function.Call(Hash.SET_VEHICLE_LIVERY, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.Liverys[0]);
		Function.Call(Hash.SET_VEHICLE_LIVERY2, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.Liverys[1]);
		Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.PlateText);
		Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.PlateType);
		Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.WheelType);
		Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.WheelCanBurst);
		Function.Call(Hash.SET_VEHICLE_WINDOW_TINT, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.WindowTint);
		Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, vehicle, 0f);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, mPOwnedVehicles.ownedVehicles[0].VehicleStats.NeonEnabled[0]);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, mPOwnedVehicles.ownedVehicles[0].VehicleStats.NeonEnabled[1]);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, mPOwnedVehicles.ownedVehicles[0].VehicleStats.NeonEnabled[2]);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, mPOwnedVehicles.ownedVehicles[0].VehicleStats.NeonEnabled[3]);
		Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, vehicle, mPOwnedVehicles.ownedVehicles[0].VehicleStats.NeonRGB[0], mPOwnedVehicles.ownedVehicles[0].VehicleStats.NeonRGB[1], mPOwnedVehicles.ownedVehicles[0].VehicleStats.NeonRGB[2]);
		for (int i = 0; i < mPOwnedVehicles.ownedVehicles[0].VehicleStats.VehicleExtras.Length; i++)
		{
			Function.Call(Hash.SET_VEHICLE_EXTRA, vehicle, i, mPOwnedVehicles.ownedVehicles[0].VehicleStats.VehicleExtras[i]);
		}
		for (int j = 0; j < 49; j++)
		{
			Function.Call(Hash.SET_VEHICLE_MOD, vehicle, j, mPOwnedVehicles.ownedVehicles[0].VehicleStats.VehicleMods[j], Function.Call<int>(Hash.GET_VEHICLE_MOD_VARIATION, vehicle, 24) == 1);
			if (mPOwnedVehicles.ownedVehicles[0].VehicleStats.VehicleMods[j] == -1)
			{
				Function.Call(Hash.REMOVE_VEHICLE_MOD, vehicle, j);
			}
		}
		Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 23, 0, mPOwnedVehicles.ownedVehicles[0].VehicleStats.WheelCustom);
		if (vehicle.Model.IsBike)
		{
			Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 24, 0, mPOwnedVehicles.ownedVehicles[0].VehicleStats.WheelCustom);
		}
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 17, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ToggleMods[0]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 18, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ToggleMods[1]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 19, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ToggleMods[2]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 20, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ToggleMods[3]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 21, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ToggleMods[4]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 22, mPOwnedVehicles.ownedVehicles[0].VehicleStats.ToggleMods[5]);
		return vehicle;
	}

	public static void SET_CURRENT_VEHICLE(string vehiclename)
	{
		MPVehicleLoadout mPVehicleLoadout = new MPVehicleLoadout();
		MPOwnedVehicles mPOwnedVehicles = new MPOwnedVehicles();
		string[] files = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles");
		foreach (string text in files)
		{
			mPOwnedVehicles = XMLSerializer.DeserializeXML<MPOwnedVehicles>(text);
			if (mPOwnedVehicles.ownedVehicles[0].VehicleName == vehiclename)
			{
				Vehicle vehicle = GET_VEHICLE_LOADOUT(text, Game.Player.Character.Position.Around(60f), 0f);
				MPVehicleLoadout.SAVE_VEHICLE(vehicle, "scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", mPOwnedVehicles.ownedVehicles[0].VehicleName);
				vehicle.Delete();
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show(mPOwnedVehicles.ownedVehicles[0].VehicleName + " is now your current vehicle", blinking: true);
				}
				break;
			}
		}
	}
}
