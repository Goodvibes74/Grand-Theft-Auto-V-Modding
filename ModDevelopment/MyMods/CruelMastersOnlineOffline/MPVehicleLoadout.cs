using System.Collections.Generic;
using System.IO;
using GTA;
using GTA.Math;
using GTA.Native;

namespace CruelMastersOnlineOffline;

public class MPVehicleLoadout
{
	public List<VehicleWithComponents> CurrenVehicleLoadout = new List<VehicleWithComponents>();

	public unsafe static void SAVE_VEHICLE(Vehicle veh, string Filename, string name)
	{
		if (veh != null)
		{
		}
		MPVehicleLoadout mPVehicleLoadout = new MPVehicleLoadout();
		VehicleWithComponents vehicleWithComponents = new VehicleWithComponents();
		vehicleWithComponents.VehicleName = name;
		vehicleWithComponents.VehicleHash = veh.Model.Hash;
		vehicleWithComponents.VehicleHandle = veh.Handle;
		int[] array = new int[3];
		int num = default;
		int num2 = default;
		int num3 = default;
		Function.Call(Hash.GET_VEHICLE_MOD_COLOR_1, veh, &num, &num2, &num3);
		array[0] = num;
		array[1] = num2;
		array[2] = num3;
		vehicleWithComponents.ModPaint1 = array;
		int[] array2 = new int[2];
		OutputArgument outputArgument = new OutputArgument();
		OutputArgument outputArgument2 = new OutputArgument();
		Function.Call(Hash.GET_VEHICLE_MOD_COLOR_2, veh, outputArgument, outputArgument2);
		array2[0] = outputArgument.GetResult<int>();
		array2[1] = outputArgument2.GetResult<int>();
		vehicleWithComponents.ModPaint2 = array2;
		vehicleWithComponents.ModPaintIsCustom = new bool[2]
		{
			Function.Call<bool>(Hash.GET_IS_VEHICLE_PRIMARY_COLOUR_CUSTOM, veh),
			Function.Call<bool>(Hash.GET_IS_VEHICLE_SECONDARY_COLOUR_CUSTOM, veh)
		};
		int[] array3 = new int[2];
		OutputArgument outputArgument3 = new OutputArgument();
		OutputArgument outputArgument4 = new OutputArgument();
		Function.Call(Hash.GET_VEHICLE_COLOURS, veh, outputArgument3, outputArgument4);
		array3[0] = outputArgument3.GetResult<int>();
		array3[1] = outputArgument4.GetResult<int>();
		vehicleWithComponents.Paints = array3;
		int[] array4 = new int[3];
		OutputArgument outputArgument5 = new OutputArgument();
		OutputArgument outputArgument6 = new OutputArgument();
		OutputArgument outputArgument7 = new OutputArgument();
		Function.Call(Hash.GET_VEHICLE_CUSTOM_PRIMARY_COLOUR, veh, outputArgument5, outputArgument6, outputArgument7);
		array4[0] = outputArgument5.GetResult<int>();
		array4[1] = outputArgument6.GetResult<int>();
		array4[2] = outputArgument7.GetResult<int>();
		vehicleWithComponents.PrimaryPaint = array4;
		int[] array5 = new int[3];
		OutputArgument outputArgument8 = new OutputArgument();
		OutputArgument outputArgument9 = new OutputArgument();
		OutputArgument outputArgument10 = new OutputArgument();
		Function.Call(Hash.GET_VEHICLE_CUSTOM_SECONDARY_COLOUR, veh, outputArgument8, outputArgument9, outputArgument10);
		array5[0] = outputArgument8.GetResult<int>();
		array5[1] = outputArgument9.GetResult<int>();
		array5[2] = outputArgument10.GetResult<int>();
		vehicleWithComponents.SecondaryPaint = array5;
		int[] array6 = new int[2];
		OutputArgument[] array7 = new OutputArgument[2]
		{
			new OutputArgument(),
			new OutputArgument()
		};
		Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, veh, array7[0], array7[1]);
		array6[0] = array7[0].GetResult<int>();
		array6[1] = array7[1].GetResult<int>();
		vehicleWithComponents.RimPaint = array6;
		int[] array8 = new int[3];
		OutputArgument[] array9 = new OutputArgument[3]
		{
			new OutputArgument(),
			new OutputArgument(),
			new OutputArgument()
		};
		Function.Call(Hash.GET_VEHICLE_TYRE_SMOKE_COLOR, veh, array9[0], array9[1], array9[2]);
		array8[0] = array9[0].GetResult<int>();
		array8[1] = array9[1].GetResult<int>();
		array8[2] = array9[2].GetResult<int>();
		vehicleWithComponents.TyreSmokeRGBColor = array8;
		if (Function.Call<int>(Hash.GET_VEHICLE_MOD_VARIATION, veh, 23) == 1)
		{
			vehicleWithComponents.WheelCustom = true;
		}
		else
		{
			vehicleWithComponents.WheelCustom = false;
		}
		if (veh.Model.IsBike)
		{
			if (Function.Call<int>(Hash.GET_VEHICLE_MOD_VARIATION, veh, 24) == 1)
			{
				vehicleWithComponents.WheelCustom = true;
			}
			else
			{
				vehicleWithComponents.WheelCustom = false;
			}
		}
		int[] array10 = new int[2];
		OutputArgument[] array11 = new OutputArgument[2]
		{
			new OutputArgument(),
			new OutputArgument()
		};
		Function.Call(Hash.GET_VEHICLE_EXTRA_COLOUR_5, veh, array11[0]);
		Function.Call(Hash.GET_VEHICLE_EXTRA_COLOUR_6, veh, array11[1]);
		array10[0] = array11[0].GetResult<int>();
		array10[1] = array11[1].GetResult<int>();
		vehicleWithComponents.ExtraColors = array10;
		int[] liverys = new int[3]
		{
			Function.Call<int>(Hash.GET_VEHICLE_LIVERY, veh),
			Function.Call<int>(Hash.GET_VEHICLE_LIVERY2, veh),
			-1
		};
		vehicleWithComponents.Liverys = liverys;
		vehicleWithComponents.XeonLightColor = Function.Call<int>(Hash.GET_VEHICLE_XENON_LIGHT_COLOR_INDEX, veh);
		vehicleWithComponents.PlateText = Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, veh);
		vehicleWithComponents.PlateType = Function.Call<int>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh);
		vehicleWithComponents.WheelType = Function.Call<int>(Hash.GET_VEHICLE_WHEEL_TYPE, veh);
		vehicleWithComponents.WheelCanBurst = Function.Call<bool>(Hash.GET_VEHICLE_TYRES_CAN_BURST, veh);
		vehicleWithComponents.WindowTint = Function.Call<int>(Hash.GET_VEHICLE_WINDOW_TINT, veh);
		vehicleWithComponents.NeonEnabled = new bool[4]
		{
			Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, veh, 0),
			Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, veh, 1),
			Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, veh, 2),
			Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, veh, 3)
		};
		int[] array12 = new int[4] { 0, 0, 0, -1 };
		OutputArgument[] array13 = new OutputArgument[3]
		{
			new OutputArgument(),
			new OutputArgument(),
			new OutputArgument()
		};
		Function.Call(Hash.GET_VEHICLE_NEON_COLOUR, veh, array13[0], array13[1], array13[2]);
		array12[0] = array13[0].GetResult<int>();
		array12[1] = array13[1].GetResult<int>();
		array12[2] = array13[2].GetResult<int>();
		vehicleWithComponents.NeonRGB = array12;
		bool[] array14 = new bool[14];
		for (int i = 0; i < array14.Length; i++)
		{
			if (Function.Call<bool>(Hash.DOES_EXTRA_EXIST, veh, i))
			{
				if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, veh, i))
				{
					array14[i] = false;
				}
				else
				{
					array14[i] = true;
				}
			}
		}
		vehicleWithComponents.VehicleExtras = array14;
		int[] array15 = new int[50];
		for (int j = 0; j < 49; j++)
		{
			array15[j] = Function.Call<int>(Hash.GET_VEHICLE_MOD, veh, j);
		}
		vehicleWithComponents.VehicleMods = array15;
		vehicleWithComponents.ToggleMods = new bool[6]
		{
			Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 17),
			Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 18),
			Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 19),
			Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 20),
			Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 21),
			Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 22)
		};
		mPVehicleLoadout.CurrenVehicleLoadout.Add(vehicleWithComponents);
		XMLSerializer.SaveToXML(mPVehicleLoadout, Filename);
	}

	public static Vehicle GET_VEHICLE_LOADOUT(string Filename, Vector3 SpawnLoc, float SpawnHeading)
	{
		MPVehicleLoadout mPVehicleLoadout = XMLSerializer.DeserializeXML<MPVehicleLoadout>(Filename);
		Vehicle vehicle = World.CreateVehicle(mPVehicleLoadout.CurrenVehicleLoadout[0].VehicleHash, SpawnLoc, SpawnHeading);
		Function.Call(Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);
		Function.Call(Hash.SET_VEHICLE_MOD_COLOR_1, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].ModPaint1[0], mPVehicleLoadout.CurrenVehicleLoadout[0].ModPaint1[1], mPVehicleLoadout.CurrenVehicleLoadout[0].ModPaint1[2]);
		Function.Call(Hash.SET_VEHICLE_MOD_COLOR_2, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].ModPaint2[0], mPVehicleLoadout.CurrenVehicleLoadout[0].ModPaint2[1]);
		Function.Call(Hash.SET_VEHICLE_COLOURS, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].Paints[0], mPVehicleLoadout.CurrenVehicleLoadout[0].Paints[1]);
		if (mPVehicleLoadout.CurrenVehicleLoadout[0].ModPaintIsCustom[0])
		{
			Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].PrimaryPaint[0], mPVehicleLoadout.CurrenVehicleLoadout[0].PrimaryPaint[1], mPVehicleLoadout.CurrenVehicleLoadout[0].PrimaryPaint[2]);
		}
		if (mPVehicleLoadout.CurrenVehicleLoadout[0].ModPaintIsCustom[1])
		{
			Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].SecondaryPaint[0], mPVehicleLoadout.CurrenVehicleLoadout[0].SecondaryPaint[1], mPVehicleLoadout.CurrenVehicleLoadout[0].SecondaryPaint[2]);
		}
		Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].RimPaint[0], mPVehicleLoadout.CurrenVehicleLoadout[0].RimPaint[1]);
		Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].TyreSmokeRGBColor[0], mPVehicleLoadout.CurrenVehicleLoadout[0].TyreSmokeRGBColor[1], mPVehicleLoadout.CurrenVehicleLoadout[0].TyreSmokeRGBColor[2]);
		Function.Call(Hash.SET_VEHICLE_EXTRA_COLOUR_5, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].ExtraColors[0]);
		Function.Call(Hash.SET_VEHICLE_EXTRA_COLOUR_6, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].ExtraColors[1]);
		Function.Call(Hash.SET_VEHICLE_LIVERY, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].Liverys[0]);
		Function.Call(Hash.SET_VEHICLE_LIVERY2, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].Liverys[1]);
		Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].PlateText);
		Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].PlateType);
		Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].WheelType);
		Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].WheelCanBurst);
		Function.Call(Hash.SET_VEHICLE_WINDOW_TINT, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].WindowTint);
		Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, vehicle, 0f);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, mPVehicleLoadout.CurrenVehicleLoadout[0].NeonEnabled[0]);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, mPVehicleLoadout.CurrenVehicleLoadout[0].NeonEnabled[1]);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, mPVehicleLoadout.CurrenVehicleLoadout[0].NeonEnabled[2]);
		Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, mPVehicleLoadout.CurrenVehicleLoadout[0].NeonEnabled[3]);
		Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].NeonRGB[0], mPVehicleLoadout.CurrenVehicleLoadout[0].NeonRGB[1], mPVehicleLoadout.CurrenVehicleLoadout[0].NeonRGB[2]);
		for (int i = 0; i < mPVehicleLoadout.CurrenVehicleLoadout[0].VehicleExtras.Length; i++)
		{
			Function.Call(Hash.SET_VEHICLE_EXTRA, vehicle, i, mPVehicleLoadout.CurrenVehicleLoadout[0].VehicleExtras[i]);
		}
		for (int j = 0; j < 49; j++)
		{
			Function.Call(Hash.SET_VEHICLE_MOD, vehicle, j, mPVehicleLoadout.CurrenVehicleLoadout[0].VehicleMods[j], Function.Call<int>(Hash.GET_VEHICLE_MOD_VARIATION, vehicle, 24) == 1);
			if (mPVehicleLoadout.CurrenVehicleLoadout[0].VehicleMods[j] == -1)
			{
				Function.Call(Hash.REMOVE_VEHICLE_MOD, vehicle, j);
			}
		}
		Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 23, 0, mPVehicleLoadout.CurrenVehicleLoadout[0].WheelCustom);
		if (vehicle.Model.IsBike)
		{
			Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 24, 0, mPVehicleLoadout.CurrenVehicleLoadout[0].WheelCustom);
		}
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 17, mPVehicleLoadout.CurrenVehicleLoadout[0].ToggleMods[0]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 18, mPVehicleLoadout.CurrenVehicleLoadout[0].ToggleMods[1]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 19, mPVehicleLoadout.CurrenVehicleLoadout[0].ToggleMods[2]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 20, mPVehicleLoadout.CurrenVehicleLoadout[0].ToggleMods[3]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 21, mPVehicleLoadout.CurrenVehicleLoadout[0].ToggleMods[4]);
		Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 22, mPVehicleLoadout.CurrenVehicleLoadout[0].ToggleMods[5]);
		Function.Call(Hash.SET_VEHICLE_XENON_LIGHT_COLOR_INDEX, vehicle, 0);
		if (mPVehicleLoadout.CurrenVehicleLoadout[0].ToggleMods[5])
		{
			Function.Call(Hash.SET_VEHICLE_XENON_LIGHT_COLOR_INDEX, vehicle, mPVehicleLoadout.CurrenVehicleLoadout[0].XeonLightColor);
		}
		return vehicle;
	}

	public static void SPAWN_PERSONAL_VEHICLE(Vector3 SpawnLoc, float SpawnHeading)
	{
		Function.Call(Hash.CLEAR_AREA, SpawnLoc.X, SpawnLoc.Y, SpawnLoc.Z, 30f, 1, 0, 0, false);
		if (CruelMastersOnlineOffline.PlayerVehicle != null)
		{
			CruelMastersOnlineOffline.PlayerVehicle.Delete();
			CruelMastersOnlineOffline.PlayerVehicle = null;
		}
		while (CruelMastersOnlineOffline.PlayerVehicle == null && File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml"))
		{
			CruelMastersOnlineOffline.PlayerVehicle = GET_VEHICLE_LOADOUT("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", SpawnLoc, SpawnHeading);
			Script.Wait(0);
		}
		if (CruelMastersOnlineOffline.PlayerVehicle != null)
		{
			while (CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip == null)
			{
				CruelMastersOnlineOffline.PlayerVehicle.AddBlip();
				Script.Wait(0);
			}
			CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleCar;
			if (CruelMastersOnlineOffline.PlayerVehicle.Model.IsMotorcycle || CruelMastersOnlineOffline.PlayerVehicle.Model.IsBike)
			{
				CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleBike;
			}
			if (CruelMastersOnlineOffline.PlayerVehicle.Model.IsQuadBike)
			{
				CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Sprite = BlipSprite.QuadBike;
			}
			if (CruelMastersOnlineOffline.PlayerVehicle.Model.IsAmphibiousQuadBike)
			{
				CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Sprite = BlipSprite.TechnicalAqua;
			}
			CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Color = BlipColor.White;
			CruelMastersOnlineOffline.PlayerVehicle.AttachedBlip.Name = "Personal Vehicle";
			CruelMastersOnlineOffline.PlayerVehicle.RadioStation = RadioStation.RadioOff;
		}
	}
}
