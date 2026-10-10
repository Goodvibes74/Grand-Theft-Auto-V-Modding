using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Elements;
using LemonUI.Menus;
using LemonUI.Scaleform;

namespace CruelMastersOnlineOffline;

internal class MPModShop : Script
{
	public static bool GarageTransactionSpent = false;

	public static int GarageSwitch = 0;

	public static int GarageControlSwitch = 0;

	public static int Show_Color_Index = 0;

	public static bool MenuOpen = false;

	public static ObjectPool MDPool = new ObjectPool();

	public static NativeMenu MainMenu = new NativeMenu("AUTO SHOP", "CATEGORIES", "");

	public MPModShop()
	{
		Tick += onTick;
		Aborted += onShutdown;
		MDPool = new ObjectPool();
		MainMenu = new NativeMenu("", "CATEGORIES", "");
		ScaledTexture banner = new ScaledTexture(MainMenu.Banner.Position, new SizeF(MainMenu.Banner.Size.Width, MainMenu.Banner.Size.Height), "shopui_title_auto_shop", "shopui_title_auto_shop");
		MainMenu.Banner = banner;
		MainMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		MainMenu.ItemCount = CountVisibility.Always;
		MDPool.Add(MainMenu);
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (!CruelMastersOnlineOffline.DEBUG || Game.IsControlJustPressed(Control.Context))
		{
		}
		if (MDPool != null && MDPool.AreAnyVisible)
		{
			SHOW_RGB(CruelMastersOnlineOffline.PlayerVehicle);
			MDPool.Process();
		}
		Blip[] allBlips = World.GetAllBlips(BlipSprite.LosSantosCustoms);
		Blip[] array = allBlips;
		foreach (Blip blip in array)
		{
			Prop[] nearbyProps = World.GetNearbyProps(blip.Position, 20f);
			Prop[] array2 = nearbyProps;
			foreach (Prop prop in array2)
			{
				if (prop != null && prop.IsPositionFrozen)
				{
					prop.IsPositionFrozen = false;
				}
			}
		}
		if (Game.Player.Character.Position.DistanceTo(new Vector3(-1144.699f, -1989.946f, 13.16199f)) < 100f)
		{
			GarageControlSwitch = 0;
		}
		if (Game.Player.Character.Position.DistanceTo(new Vector3(719.5757f, -1088.77f, 22.03f)) < 100f)
		{
			GarageControlSwitch = 1;
		}
		if (Game.Player.Character.Position.DistanceTo(new Vector3(-353.2156f, -135.7295f, 38.73895f)) < 100f)
		{
			GarageControlSwitch = 2;
		}
		if (Game.Player.Character.Position.DistanceTo(new Vector3(1174.841f, 2649.521f, 37.53205f)) < 100f)
		{
			GarageControlSwitch = 3;
		}
		if (Game.Player.Character.Position.DistanceTo(new Vector3(116.5889f, 6620.897f, 31.58369f)) < 100f)
		{
			GarageControlSwitch = 4;
		}
		switch (GarageControlSwitch)
		{
		case 0:
			switch (GarageSwitch)
			{
			case 0:
				if (!(Game.Player.Character.CurrentVehicle != null) || !(Game.Player.Character.Position.DistanceTo(new Vector3(-1144.699f, -1989.946f, 13.16199f)) < 6f))
				{
					break;
				}
				if ((Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle && CruelMastersOnlineOffline.PlayerVehicle.Model.IsCar) || (CruelMastersOnlineOffline.PlayerVehicle.Model.IsMotorcycle && !CruelMastersOnlineOffline.PlayerVehicle.Model.IsBigVehicle))
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(-1142.398f, -1987.646f, 12.16434f);
					CruelMastersOnlineOffline.PlayerVehicle.Heading = 133.8112f;
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence10 = new TaskSequence();
					taskSequence10.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-1151.852f, -1997.39f, 13.18025f), 1f, 5f);
					taskSequence10.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-1155.433f, -2004.5f, 13.18025f), 1f, 5f);
					taskSequence10.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence10);
					taskSequence10.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = true;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.PlayerCannotLeaveCanBeBrokenIntoPersist;
					MOD_SHOP_MENU(CruelMastersOnlineOffline.PlayerVehicle);
					GarageSwitch = 1;
				}
				else
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("This vehicle cannot enter Los Santos Customs.");
				}
				break;
			case 1:
				if (!MDPool.AreAnyVisible)
				{
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					if (GarageTransactionSpent)
					{
						CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(-1150.175f, -1995.835f, 12.91347f);
						CruelMastersOnlineOffline.PlayerVehicle.Heading = 316.657f;
						CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
						GarageTransactionSpent = false;
					}
					else
					{
						MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-1150.175f, -1995.835f, 12.91347f), 316.657f);
						Game.Player.Character.SetIntoVehicle(CruelMastersOnlineOffline.PlayerVehicle, VehicleSeat.Driver);
						CruelMastersOnlineOffline.PlayerVehicle.RadioStation = RadioStation.RadioOff;
						CruelMastersOnlineOffline.CutsceneCam.Delete();
						CruelMastersOnlineOffline.CutsceneCam = null;
						CruelMastersOnlineOffline.CutsceneCam2.Delete();
						CruelMastersOnlineOffline.CutsceneCam2 = null;
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
						CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
						CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
						CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
						CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
						CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					}
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence9 = new TaskSequence();
					taskSequence9.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-1140.353f, -1985.718f, 12.89486f), 1f, 5f);
					taskSequence9.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-1136.159f, -1983.663f, 12.89474f), 1f, 5f);
					taskSequence9.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence9);
					taskSequence9.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					Mobile_Phone.CAN_OPEN_PHONE = true;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
					MPCash.CAN_SEE_CASH = true;
					MPRank.CAN_SEE_RANK_BAR = true;
					MPPlayerList.CAN_SHOW_LIST = true;
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.None;
					GarageSwitch = 0;
				}
				break;
			}
			break;
		case 1:
			switch (GarageSwitch)
			{
			case 0:
				if (!(Game.Player.Character.CurrentVehicle != null) || !(Game.Player.Character.Position.DistanceTo(new Vector3(719.5757f, -1088.77f, 22.03f)) < 6f))
				{
					break;
				}
				if ((Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle && CruelMastersOnlineOffline.PlayerVehicle.Model.IsCar) || (CruelMastersOnlineOffline.PlayerVehicle.Model.IsMotorcycle && !CruelMastersOnlineOffline.PlayerVehicle.Model.IsBigVehicle))
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(717.346f, -1088.722f, 21.07812f);
					CruelMastersOnlineOffline.PlayerVehicle.Heading = 269.0187f;
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence8 = new TaskSequence();
					taskSequence8.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(724.8883f, -1088.828f, 21.92594f), 1f, 5f);
					taskSequence8.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(731.6036f, -1087.519f, 21.89825f), 1f, 5f);
					taskSequence8.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence8);
					taskSequence8.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = true;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.PlayerCannotLeaveCanBeBrokenIntoPersist;
					MOD_SHOP_MENU(CruelMastersOnlineOffline.PlayerVehicle);
					GarageSwitch = 1;
				}
				else
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("This vehicle cannot enter Los Santos Customs.");
				}
				break;
			case 1:
				if (!MDPool.AreAnyVisible)
				{
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					if (GarageTransactionSpent)
					{
						CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(731.7839f, -1088.625f, 21.89871f);
						CruelMastersOnlineOffline.PlayerVehicle.Heading = 88.74612f;
						CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
						GarageTransactionSpent = false;
					}
					else
					{
						MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(731.7839f, -1088.625f, 21.89871f), 88.74612f);
						Game.Player.Character.SetIntoVehicle(CruelMastersOnlineOffline.PlayerVehicle, VehicleSeat.Driver);
						CruelMastersOnlineOffline.PlayerVehicle.RadioStation = RadioStation.RadioOff;
						CruelMastersOnlineOffline.CutsceneCam.Delete();
						CruelMastersOnlineOffline.CutsceneCam = null;
						CruelMastersOnlineOffline.CutsceneCam2.Delete();
						CruelMastersOnlineOffline.CutsceneCam2 = null;
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
						CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
						CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
						CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
						CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
						CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					}
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence7 = new TaskSequence();
					taskSequence7.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(718.3081f, -1088.118f, 22.05315f), 1f, 5f);
					taskSequence7.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(709.1119f, -1084.194f, 22.14146f), 1f, 5f);
					taskSequence7.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence7);
					taskSequence7.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					Mobile_Phone.CAN_OPEN_PHONE = true;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
					MPCash.CAN_SEE_CASH = true;
					MPRank.CAN_SEE_RANK_BAR = true;
					MPPlayerList.CAN_SHOW_LIST = true;
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.None;
					GarageSwitch = 0;
				}
				break;
			}
			break;
		case 2:
			switch (GarageSwitch)
			{
			case 0:
				if (!(Game.Player.Character.CurrentVehicle != null) || !(Game.Player.Character.Position.DistanceTo(new Vector3(-353.2156f, -135.7295f, 38.73895f)) < 6f))
				{
					break;
				}
				if ((Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle && CruelMastersOnlineOffline.PlayerVehicle.Model.IsCar) || (CruelMastersOnlineOffline.PlayerVehicle.Model.IsMotorcycle && !CruelMastersOnlineOffline.PlayerVehicle.Model.IsBigVehicle))
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(-353.2156f, -135.7295f, 37.73895f);
					CruelMastersOnlineOffline.PlayerVehicle.Heading = 249.8934f;
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence6 = new TaskSequence();
					taskSequence6.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-338.1583f, -137.8513f, 38.73921f), 1f, 5f);
					taskSequence6.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-338.1583f, -137.8513f, 38.73921f), 1f, 5f);
					taskSequence6.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence6);
					taskSequence6.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = true;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.PlayerCannotLeaveCanBeBrokenIntoPersist;
					MOD_SHOP_MENU(CruelMastersOnlineOffline.PlayerVehicle);
					GarageSwitch = 1;
				}
				else
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("This vehicle cannot enter Los Santos Customs.");
				}
				break;
			case 1:
				if (!MDPool.AreAnyVisible)
				{
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					if (GarageTransactionSpent)
					{
						CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(-350.903f, -136.6009f, 38.73914f);
						CruelMastersOnlineOffline.PlayerVehicle.Heading = 68.32455f;
						CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
						GarageTransactionSpent = false;
					}
					else
					{
						MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(-350.903f, -136.6009f, 38.73914f), 68.32455f);
						Game.Player.Character.SetIntoVehicle(CruelMastersOnlineOffline.PlayerVehicle, VehicleSeat.Driver);
						CruelMastersOnlineOffline.PlayerVehicle.RadioStation = RadioStation.RadioOff;
						CruelMastersOnlineOffline.CutsceneCam.Delete();
						CruelMastersOnlineOffline.CutsceneCam = null;
						CruelMastersOnlineOffline.CutsceneCam2.Delete();
						CruelMastersOnlineOffline.CutsceneCam2 = null;
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
						CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
						CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
						CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
						CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
						CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					}
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence5 = new TaskSequence();
					taskSequence5.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-373.0048f, -128.2457f, 38.41611f), 1f, 5f);
					taskSequence5.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-373.0048f, -128.2457f, 38.41611f), 1f, 5f);
					taskSequence5.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence5);
					taskSequence5.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					Mobile_Phone.CAN_OPEN_PHONE = true;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
					MPCash.CAN_SEE_CASH = true;
					MPRank.CAN_SEE_RANK_BAR = true;
					MPPlayerList.CAN_SHOW_LIST = true;
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.None;
					GarageSwitch = 0;
				}
				break;
			}
			break;
		case 3:
			switch (GarageSwitch)
			{
			case 0:
				if (!(Game.Player.Character.CurrentVehicle != null) || !(Game.Player.Character.Position.DistanceTo(new Vector3(1174.841f, 2649.521f, 37.53205f)) < 6f))
				{
					break;
				}
				if ((Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle && CruelMastersOnlineOffline.PlayerVehicle.Model.IsCar) || (CruelMastersOnlineOffline.PlayerVehicle.Model.IsMotorcycle && !CruelMastersOnlineOffline.PlayerVehicle.Model.IsBigVehicle))
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 5f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(1174.841f, 2649.521f, 36.53205f);
					CruelMastersOnlineOffline.PlayerVehicle.Heading = 180.0506f;
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence4 = new TaskSequence();
					taskSequence4.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(1175.139f, 2639.967f, 37.4862f), 0.1f, 2f);
					taskSequence4.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(1175.139f, 2639.967f, 37.4862f), 0.1f, 2f);
					taskSequence4.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence4);
					taskSequence4.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = true;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.PlayerCannotLeaveCanBeBrokenIntoPersist;
					MOD_SHOP_MENU(CruelMastersOnlineOffline.PlayerVehicle);
					GarageSwitch = 1;
				}
				else
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("This vehicle cannot enter Los Santos Customs.");
				}
				break;
			case 1:
				if (!MDPool.AreAnyVisible)
				{
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					if (GarageTransactionSpent)
					{
						CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(1174.191f, 2641.028f, 37.49249f);
						CruelMastersOnlineOffline.PlayerVehicle.Heading = 358.8279f;
						CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
						GarageTransactionSpent = false;
					}
					else
					{
						MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(1174.191f, 2641.028f, 37.49249f), 358.8279f);
						Game.Player.Character.SetIntoVehicle(CruelMastersOnlineOffline.PlayerVehicle, VehicleSeat.Driver);
						CruelMastersOnlineOffline.PlayerVehicle.RadioStation = RadioStation.RadioOff;
						CruelMastersOnlineOffline.CutsceneCam.Delete();
						CruelMastersOnlineOffline.CutsceneCam = null;
						CruelMastersOnlineOffline.CutsceneCam2.Delete();
						CruelMastersOnlineOffline.CutsceneCam2 = null;
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
						CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
						CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
						CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
						CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
						CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					}
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence3 = new TaskSequence();
					taskSequence3.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(1174.997f, 2646.997f, 37.50968f), 1f, 5f);
					taskSequence3.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(1182.806f, 2653.755f, 37.54143f), 1f, 5f);
					taskSequence3.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence3);
					taskSequence3.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					Mobile_Phone.CAN_OPEN_PHONE = true;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
					MPCash.CAN_SEE_CASH = true;
					MPRank.CAN_SEE_RANK_BAR = true;
					MPPlayerList.CAN_SHOW_LIST = true;
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.None;
					GarageSwitch = 0;
				}
				break;
			}
			break;
		case 4:
			switch (GarageSwitch)
			{
			case 0:
				if (!(Game.Player.Character.CurrentVehicle != null) || !(Game.Player.Character.Position.DistanceTo(new Vector3(116.5889f, 6620.897f, 31.58369f)) < 6f))
				{
					break;
				}
				if ((Game.Player.Character.CurrentVehicle == CruelMastersOnlineOffline.PlayerVehicle && CruelMastersOnlineOffline.PlayerVehicle.Model.IsCar) || (CruelMastersOnlineOffline.PlayerVehicle.Model.IsMotorcycle && !CruelMastersOnlineOffline.PlayerVehicle.Model.IsBigVehicle))
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 5f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(116.5889f, 6620.897f, 30.58369f);
					CruelMastersOnlineOffline.PlayerVehicle.Heading = 43.21093f;
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence2 = new TaskSequence();
					taskSequence2.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(110.4838f, 6626.656f, 31.51666f), 0.1f, 2f);
					taskSequence2.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(110.4838f, 6626.656f, 31.51666f), 0.1f, 2f);
					taskSequence2.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence2);
					taskSequence2.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = true;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.PlayerCannotLeaveCanBeBrokenIntoPersist;
					MOD_SHOP_MENU(CruelMastersOnlineOffline.PlayerVehicle);
					GarageSwitch = 1;
				}
				else
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("This vehicle cannot enter Los Santos Customs.");
				}
				break;
			case 1:
				if (!MDPool.AreAnyVisible)
				{
					CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
					CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
					CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
					CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					if (GarageTransactionSpent)
					{
						CruelMastersOnlineOffline.PlayerVehicle.Position = new Vector3(110.4842f, 6626.656f, 31.5165f);
						CruelMastersOnlineOffline.PlayerVehicle.Heading = 227.1909f;
						CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
						GarageTransactionSpent = false;
					}
					else
					{
						MPVehicleLoadout.SPAWN_PERSONAL_VEHICLE(new Vector3(110.4842f, 6626.656f, 31.5165f), 227.1909f);
						Game.Player.Character.SetIntoVehicle(CruelMastersOnlineOffline.PlayerVehicle, VehicleSeat.Driver);
						CruelMastersOnlineOffline.PlayerVehicle.RadioStation = RadioStation.RadioOff;
						CruelMastersOnlineOffline.CutsceneCam.Delete();
						CruelMastersOnlineOffline.CutsceneCam = null;
						CruelMastersOnlineOffline.CutsceneCam2.Delete();
						CruelMastersOnlineOffline.CutsceneCam2 = null;
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 50f);
						CruelMastersOnlineOffline.CutsceneCam.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 15f, 1f));
						CruelMastersOnlineOffline.CutsceneCam.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 55f);
						CruelMastersOnlineOffline.CutsceneCam2.AttachTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(-3f, 4f, 1f));
						CruelMastersOnlineOffline.CutsceneCam2.PointAt(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(0f, 0f, 0f));
						World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
						CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 10000, 3, 1);
					}
					Game.Player.CanControlCharacter = false;
					TaskSequence taskSequence = new TaskSequence();
					taskSequence.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(127.6607f, 6610.223f, 31.5779f), 1f, 5f);
					taskSequence.AddTask.DriveTo(CruelMastersOnlineOffline.PlayerVehicle, new Vector3(127.6607f, 6610.223f, 31.5779f), 1f, 5f);
					taskSequence.Close();
					Game.Player.Character.Task.PerformSequence(taskSequence);
					taskSequence.Dispose();
					while (CruelMastersOnlineOffline.CutsceneCam2.IsInterpolating)
					{
						Script.Wait(0);
					}
					Mobile_Phone.CAN_OPEN_PHONE = true;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
					MPCash.CAN_SEE_CASH = true;
					MPRank.CAN_SEE_RANK_BAR = true;
					MPPlayerList.CAN_SHOW_LIST = true;
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					World.RenderingCamera = null;
					Game.Player.CanControlCharacter = true;
					CruelMastersOnlineOffline.PlayerVehicle.IsPositionFrozen = false;
					CruelMastersOnlineOffline.PlayerVehicle.LockStatus = VehicleLockStatus.None;
					GarageSwitch = 0;
				}
				break;
			}
			break;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
	}

	public unsafe static void SHOW_RGB(Vehicle veh)
	{
		if (veh != null)
		{
			int show_Color_Index = Show_Color_Index;
			int num = show_Color_Index;
			if (num == 1)
			{
				int[] array = new int[3];
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				Function.Call(Hash.GET_VEHICLE_TYRE_SMOKE_COLOR, veh, &num2, &num3, &num4);
				array[0] = num2;
				array[1] = num3;
				array[2] = num4;
				Function.Call(Hash.DRAW_RECT, 0.065f, 0.6f, 0.1f, 0.1f, array[0], array[1], array[2], 255, 0);
				Heist_Hud.drawText("- Tyre Smoke -", 0.023f, 0.52f, 0.4f, array[0], array[1], array[2]);
			}
		}
	}

	public static string GET_VEHICLE_NAME_ID()
	{
		MPVehicleLoadout mPVehicleLoadout = new MPVehicleLoadout();
		MPOwnedVehicles mPOwnedVehicles = new MPOwnedVehicles();
		string[] files = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles");
		foreach (string fileName in files)
		{
			mPVehicleLoadout = XMLSerializer.DeserializeXML<MPVehicleLoadout>("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml");
			mPOwnedVehicles = XMLSerializer.DeserializeXML<MPOwnedVehicles>(fileName);
			if (mPVehicleLoadout.CurrenVehicleLoadout[0].VehicleName == mPOwnedVehicles.ownedVehicles[0].VehicleName)
			{
				mPOwnedVehicles = XMLSerializer.DeserializeXML<MPOwnedVehicles>(fileName);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show(mPOwnedVehicles.ownedVehicles[0].VehicleName, blinking: true);
				}
				return mPOwnedVehicles.ownedVehicles[0].VehicleName;
			}
		}
		return "Player Vehicle";
	}

	public static void MOD_SHOP_MENU(Vehicle veh)
	{
		MainMenu.Clear();
		MainMenu.Name = GET_VEHICLE_NAME_ID();
		ScaledTexture banner = new ScaledTexture(MainMenu.Banner.Position, new SizeF(MainMenu.Banner.Size.Width, MainMenu.Banner.Size.Height), "shopui_title_auto_shop", "shopui_title_auto_shop");
		NativeMenu nativeMenu = new NativeMenu("", "Vehicle Mods", "Browse for Vehicle Mods.");
		MDPool.Add(nativeMenu);
		nativeMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu.CloseOnInvalidClick = false;
		nativeMenu.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem = new NativeSubmenuItem(nativeMenu, MainMenu);
		nativeSubmenuItem.AltTitle = "";
		nativeMenu.Buttons.Clear();
		InstructionalButton[] array = new InstructionalButton[2]
		{
			new InstructionalButton("Set Vehicle Mod", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu.Buttons.Add(array[0]);
		nativeMenu.Buttons.Add(array[1]);
		MainMenu.Add(0, nativeSubmenuItem);
		NativeListItem<int> ModTypeItem = new NativeListItem<int>("Mod Type", "Select a Mod Type.");
		int iVar0;
		for (iVar0 = 0; iVar0 < 50; iVar0++)
		{
			if (iVar0 == 17 || iVar0 == 18 || iVar0 == 19 || iVar0 == 20 || iVar0 == 21 || iVar0 == 22)
			{
				continue;
			}
			if (veh.Model.IsBike)
			{
				ModTypeItem.Add(iVar0);
			}
			else if (!veh.Model.IsLowrider)
			{
				if (iVar0 != 23 && iVar0 != 24 && iVar0 != 25 && iVar0 != 26 && iVar0 != 27 && iVar0 != 28 && iVar0 != 29 && iVar0 != 30 && iVar0 != 31 && iVar0 != 32 && iVar0 != 33 && iVar0 != 34 && iVar0 != 35 && iVar0 != 36 && iVar0 != 37 && iVar0 != 38)
				{
					ModTypeItem.Add(iVar0);
				}
			}
			else if (iVar0 != 23 && iVar0 != 24)
			{
				ModTypeItem.Add(iVar0);
			}
		}
		ModTypeItem.GoRight();
		ModTypeItem.GoLeft();
		ModTypeItem.Enabled = true;
		nativeMenu.Add(ModTypeItem);
		NativeListItem<int> ModVarItem = new NativeListItem<int>("Mod Variation", "Select a Mod Type.");
		ModVarItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 0); iVar0++)
		{
			ModVarItem.Add(iVar0 + 1, iVar0);
		}
		ModVarItem.GoRight();
		ModVarItem.GoLeft();
		ModVarItem.Enabled = true;
		nativeMenu.Add(ModVarItem);
		ModTypeItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			ModVarItem.Clear();
			for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, ModTypeItem.SelectedItem); iVar0++)
			{
				ModVarItem.Add(iVar0 + 1, iVar0);
			}
			ModVarItem.GoRight();
			ModVarItem.GoLeft();
			ModVarItem.Enabled = true;
		};
		ModVarItem.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_MOD, veh, ModTypeItem.SelectedItem, ModVarItem.SelectedItem, Function.Call<int>(Hash.GET_VEHICLE_MOD_VARIATION, veh, 24) == 1);
			if (ModVarItem.SelectedItem == -1)
			{
				Function.Call(Hash.REMOVE_VEHICLE_MOD, veh, ModTypeItem.SelectedItem);
			}
		};
		NativeItem nativeItem = new NativeItem("View List of Mod Types", "Open a Google tab to a pastebin that shows you what the numbers mean.");
		nativeItem.Activated += (object sender, EventArgs e) =>
		{
			try
			{
				Process.Start("https://pastebin.com/QzEAn02v");
			}
			catch (Exception ex)
			{
				Console.WriteLine("[MEGAPHONE UI] " + ex.Message);
				Notification.Show("~r~[MEGAPHONE UI] Can't open the Discord invitation link. Make sure your computer has a default browser.");
			}
		};
		nativeMenu.Add(nativeItem);
		NativeMenu nativeMenu2 = new NativeMenu("", "Toggle Mods", "Browse for Toggle Mods.");
		MDPool.Add(nativeMenu2);
		nativeMenu2.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu2.CloseOnInvalidClick = false;
		nativeMenu2.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem2 = new NativeSubmenuItem(nativeMenu2, MainMenu);
		nativeSubmenuItem2.AltTitle = "";
		nativeMenu2.Buttons.Clear();
		InstructionalButton[] array2 = new InstructionalButton[2]
		{
			new InstructionalButton("Toggle Mod", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu2.Buttons.Add(array2[0]);
		nativeMenu2.Buttons.Add(array2[1]);
		MainMenu.Add(1, nativeSubmenuItem2);
		nativeMenu2.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_LIGHTS, veh, 2);
		};
		nativeMenu2.Closing += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_LIGHTS, veh, 0);
			Show_Color_Index = 0;
		};
		NativeCheckboxItem ToggleMods17Item = new NativeCheckboxItem("Nitrous", "Toggle on or off Vehicle mods. (Activate Nitrous)", Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 17));
		nativeMenu2.Add(ToggleMods17Item);
		ToggleMods17Item.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.TOGGLE_VEHICLE_MOD, veh, 17, ToggleMods17Item.Checked);
		};
		NativeCheckboxItem ToggleMods18Item = new NativeCheckboxItem("Turbo", "Toggle on or off Vehicle mods. (Activate Turbo)", Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 18));
		nativeMenu2.Add(ToggleMods18Item);
		ToggleMods18Item.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.TOGGLE_VEHICLE_MOD, veh, 18, ToggleMods18Item.Checked);
		};
		NativeCheckboxItem ToggleMods19Item = new NativeCheckboxItem("Subwoofer", "Toggle on or off Vehicle mods. (Only For Lowriders)", Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 19));
		nativeMenu2.Add(ToggleMods19Item);
		ToggleMods19Item.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.TOGGLE_VEHICLE_MOD, veh, 19, ToggleMods19Item.Checked);
		};
		NativeCheckboxItem ToggleMods20Item = new NativeCheckboxItem("Tyre Smoke", "Toggle on or off Vehicle mods. (To Use Tyre Smoke)", Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 20));
		nativeMenu2.Add(ToggleMods20Item);
		ToggleMods20Item.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.TOGGLE_VEHICLE_MOD, veh, 20, ToggleMods20Item.Checked);
		};
		NativeSliderItem ToggleMods20RItem = new NativeSliderItem("Tyre Smoke R", "Change the Tyre Smokes Red Color.", 255, 0);
		ToggleMods20RItem.Multiplier = 5;
		nativeMenu2.Add(ToggleMods20RItem);
		NativeSliderItem ToggleMods20GItem = new NativeSliderItem("Tyre Smoke G", "Change the Tyre Smokes Green Color.", 255, 0);
		ToggleMods20GItem.Multiplier = 5;
		nativeMenu2.Add(ToggleMods20GItem);
		NativeSliderItem ToggleMods20BItem = new NativeSliderItem("Tyre Smoke B", "Change the Tyre Smokes Blue Color.", 255, 0);
		ToggleMods20BItem.Multiplier = 5;
		nativeMenu2.Add(ToggleMods20BItem);
		ToggleMods20RItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, veh, ToggleMods20RItem.Value, ToggleMods20GItem.Value, ToggleMods20BItem.Value);
			Show_Color_Index = 1;
		};
		ToggleMods20GItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, veh, ToggleMods20RItem.Value, ToggleMods20GItem.Value, ToggleMods20BItem.Value);
			Show_Color_Index = 1;
		};
		ToggleMods20BItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, veh, ToggleMods20RItem.Value, ToggleMods20GItem.Value, ToggleMods20BItem.Value);
			Show_Color_Index = 1;
		};
		NativeCheckboxItem ToggleMods21Item = new NativeCheckboxItem("Hydralics", "Toggle on or off Vehicle mods. (Only For Lowriders)", Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 21));
		nativeMenu2.Add(ToggleMods21Item);
		ToggleMods21Item.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.TOGGLE_VEHICLE_MOD, veh, 21, ToggleMods21Item.Checked);
		};
		NativeCheckboxItem ToggleMods22Item = new NativeCheckboxItem("Xenon Lights", "Toggle on or off Vehicle mods. (To Use Xenon Lights)", Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, veh, 22));
		nativeMenu2.Add(ToggleMods22Item);
		ToggleMods22Item.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.TOGGLE_VEHICLE_MOD, veh, 22, ToggleMods22Item.Checked);
			Function.Call(Hash.SET_VEHICLE_XENON_LIGHT_COLOR_INDEX, veh, -1);
		};
		NativeSliderItem ToggleMods22ColorItem = new NativeSliderItem("Xenon Lights Color", "Change the Color of the Xenon Lights. (0 - 12)", 12, 0);
		ToggleMods22ColorItem.Multiplier = 1;
		nativeMenu2.Add(ToggleMods22ColorItem);
		ToggleMods22ColorItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_XENON_LIGHT_COLOR_INDEX, veh, ToggleMods22ColorItem.Value);
		};
		NativeMenu nativeMenu3 = new NativeMenu("", "Vehicle Paint", "Browse for Vehicle Colors.");
		MDPool.Add(nativeMenu3);
		nativeMenu3.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu3.CloseOnInvalidClick = false;
		nativeMenu3.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem3 = new NativeSubmenuItem(nativeMenu3, MainMenu);
		nativeSubmenuItem3.AltTitle = "";
		MainMenu.Add(2, nativeSubmenuItem3);
		NativeSliderItem VehiclePaintTypeItem = new NativeSliderItem("Paint Type", "Change the Paint Type of the Car. (0 - 6)\n0: Normal\n1: Metallic\n2: Pearl\n3: Matte\n4: Metal\n5: Chrome\n6: Chameleon", 6, 0);
		VehiclePaintTypeItem.Multiplier = 1;
		nativeMenu3.Add(VehiclePaintTypeItem);
		NativeSliderItem VehiclePaintPrimaryItem = new NativeSliderItem("Primary Color", "Change the Primary Color of the Car.", 0, 0);
		VehiclePaintPrimaryItem.Maximum = Function.Call<int>(Hash.GET_NUM_MOD_COLORS, VehiclePaintTypeItem.Value, 1);
		VehiclePaintPrimaryItem.Multiplier = 1;
		nativeMenu3.Add(VehiclePaintPrimaryItem);
		NativeSliderItem VehiclePaintSecondaryItem = new NativeSliderItem("Secondary Color", "Change the Secondary Color of the Car.", 0, 0);
		VehiclePaintSecondaryItem.Maximum = Function.Call<int>(Hash.GET_NUM_MOD_COLORS, VehiclePaintTypeItem.Value, 1);
		VehiclePaintSecondaryItem.Multiplier = 1;
		nativeMenu3.Add(VehiclePaintSecondaryItem);
		NativeSliderItem VehiclePaintPearlItem = new NativeSliderItem("Pearl Color", "Change the Pearl Color of the Car.", 0, 0);
		VehiclePaintPearlItem.Maximum = Function.Call<int>(Hash.GET_NUM_MOD_COLORS, VehiclePaintTypeItem.Value, 1);
		VehiclePaintPearlItem.Multiplier = 1;
		nativeMenu3.Add(VehiclePaintPearlItem);
		VehiclePaintTypeItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_MOD_COLOR_1, veh, VehiclePaintTypeItem.Value, VehiclePaintPrimaryItem.Value, VehiclePaintPearlItem.Value);
			Function.Call(Hash.SET_VEHICLE_MOD_COLOR_2, veh, VehiclePaintTypeItem.Value, VehiclePaintSecondaryItem.Value);
			VehiclePaintPrimaryItem.Maximum = Function.Call<int>(Hash.GET_NUM_MOD_COLORS, VehiclePaintTypeItem.Value, 1);
			VehiclePaintPrimaryItem.Value = 0;
			VehiclePaintSecondaryItem.Maximum = Function.Call<int>(Hash.GET_NUM_MOD_COLORS, VehiclePaintTypeItem.Value, 1);
			VehiclePaintSecondaryItem.Value = 0;
			VehiclePaintPearlItem.Maximum = Function.Call<int>(Hash.GET_NUM_MOD_COLORS, VehiclePaintTypeItem.Value, 1);
			VehiclePaintPearlItem.Value = 0;
		};
		VehiclePaintPrimaryItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_MOD_COLOR_1, veh, VehiclePaintTypeItem.Value, VehiclePaintPrimaryItem.Value, VehiclePaintPearlItem.Value);
		};
		VehiclePaintSecondaryItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_MOD_COLOR_2, veh, VehiclePaintTypeItem.Value, VehiclePaintSecondaryItem.Value);
		};
		VehiclePaintPearlItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_MOD_COLOR_1, veh, VehiclePaintTypeItem.Value, VehiclePaintPrimaryItem.Value, VehiclePaintPearlItem.Value);
		};
		NativeCheckboxItem ToggleCustomPriColorItem = new NativeCheckboxItem("Custom Primary Color", "Toggle on or off Custom Primary RGB Vehicle Color.", check: false);
		nativeMenu3.Add(ToggleCustomPriColorItem);
		NativeSliderItem ToggleCustomPriColorRItem = new NativeSliderItem("Primary Color R", "Change the Primary Colors Red Color.", 255, 0);
		ToggleCustomPriColorRItem.Multiplier = 5;
		nativeMenu3.Add(ToggleCustomPriColorRItem);
		NativeSliderItem ToggleCustomPriColorGItem = new NativeSliderItem("Primary Color G", "Change the Primary Colors Green Color.", 255, 0);
		ToggleCustomPriColorGItem.Multiplier = 5;
		nativeMenu3.Add(ToggleCustomPriColorGItem);
		NativeSliderItem ToggleCustomPriColorBItem = new NativeSliderItem("Primary Color B", "Change the Primary Colors Blue Color.", 255, 0);
		ToggleCustomPriColorBItem.Multiplier = 5;
		nativeMenu3.Add(ToggleCustomPriColorBItem);
		ToggleCustomPriColorRItem.ValueChanged += (object sender, EventArgs e) =>
		{
			if (ToggleCustomPriColorItem.Checked)
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, veh, ToggleCustomPriColorRItem.Value, ToggleCustomPriColorGItem.Value, ToggleCustomPriColorBItem.Value);
			}
		};
		ToggleCustomPriColorGItem.ValueChanged += (object sender, EventArgs e) =>
		{
			if (ToggleCustomPriColorItem.Checked)
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, veh, ToggleCustomPriColorRItem.Value, ToggleCustomPriColorGItem.Value, ToggleCustomPriColorBItem.Value);
			}
		};
		ToggleCustomPriColorBItem.ValueChanged += (object sender, EventArgs e) =>
		{
			if (ToggleCustomPriColorItem.Checked)
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, veh, ToggleCustomPriColorRItem.Value, ToggleCustomPriColorGItem.Value, ToggleCustomPriColorBItem.Value);
			}
		};
		NativeCheckboxItem ToggleCustomSecColorItem = new NativeCheckboxItem("Custom Secondary Color", "Toggle on or off Custom Secondary RGB Vehicle Color.", check: false);
		nativeMenu3.Add(ToggleCustomSecColorItem);
		NativeSliderItem ToggleCustomSecColorRItem = new NativeSliderItem("Secondary Color R", "Change the Secondary Colors Red Color.", 255, 0);
		ToggleCustomSecColorRItem.Multiplier = 5;
		nativeMenu3.Add(ToggleCustomSecColorRItem);
		NativeSliderItem ToggleCustomSecColorGItem = new NativeSliderItem("Secondary Color G", "Change the Secondary Colors Green Color.", 255, 0);
		ToggleCustomSecColorGItem.Multiplier = 5;
		nativeMenu3.Add(ToggleCustomSecColorGItem);
		NativeSliderItem ToggleCustomSecColorBItem = new NativeSliderItem("Secondary Color B", "Change the Secondary Colors Blue Color.", 255, 0);
		ToggleCustomSecColorBItem.Multiplier = 5;
		nativeMenu3.Add(ToggleCustomSecColorBItem);
		ToggleCustomSecColorRItem.ValueChanged += (object sender, EventArgs e) =>
		{
			if (ToggleCustomSecColorItem.Checked)
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, veh, ToggleCustomSecColorRItem.Value, ToggleCustomSecColorGItem.Value, ToggleCustomSecColorBItem.Value);
			}
		};
		ToggleCustomSecColorGItem.ValueChanged += (object sender, EventArgs e) =>
		{
			if (ToggleCustomSecColorItem.Checked)
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, veh, ToggleCustomSecColorRItem.Value, ToggleCustomSecColorGItem.Value, ToggleCustomSecColorBItem.Value);
			}
		};
		ToggleCustomSecColorBItem.ValueChanged += (object sender, EventArgs e) =>
		{
			if (ToggleCustomSecColorItem.Checked)
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, veh, ToggleCustomSecColorRItem.Value, ToggleCustomSecColorGItem.Value, ToggleCustomSecColorBItem.Value);
			}
		};
		ToggleCustomPriColorItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			if (!ToggleCustomPriColorItem.Checked)
			{
				Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_PRIMARY_COLOUR, veh);
				ToggleCustomPriColorRItem.Value = 0;
				ToggleCustomPriColorGItem.Value = 0;
				ToggleCustomPriColorBItem.Value = 0;
				Function.Call(Hash.SET_VEHICLE_MOD_COLOR_1, veh, VehiclePaintTypeItem.Value, VehiclePaintPrimaryItem.Value, VehiclePaintPearlItem.Value);
			}
			else
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, veh, 0, 0, 0);
			}
		};
		ToggleCustomSecColorItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			if (!ToggleCustomSecColorItem.Checked)
			{
				Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_SECONDARY_COLOUR, veh);
				ToggleCustomSecColorRItem.Value = 0;
				ToggleCustomSecColorGItem.Value = 0;
				ToggleCustomSecColorBItem.Value = 0;
				Function.Call(Hash.SET_VEHICLE_MOD_COLOR_2, veh, VehiclePaintTypeItem.Value, VehiclePaintSecondaryItem.Value);
			}
			else
			{
				Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, veh, 0, 0, 0);
			}
		};
		if (veh.Model.IsLowrider)
		{
			NativeSliderItem VehicleLivery1Item = new NativeSliderItem("Livey 1", "Change the Livery 1 Type on the Car.", 0, 0);
			if (Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, veh) != -1)
			{
				VehicleLivery1Item.Maximum = Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, veh);
			}
			VehicleLivery1Item.Multiplier = 1;
			nativeMenu3.Add(VehicleLivery1Item);
			VehicleLivery1Item.ValueChanged += (object sender, EventArgs e) =>
			{
				Function.Call(Hash.SET_VEHICLE_LIVERY, veh, VehicleLivery1Item.Value);
			};
			NativeSliderItem VehicleLivery2Item = new NativeSliderItem("Livey 2", "Change the Livery 2 Type on the Car.", 0, 0);
			if (Function.Call<int>(Hash.GET_VEHICLE_LIVERY2_COUNT, veh) != -1)
			{
				VehicleLivery2Item.Maximum = Function.Call<int>(Hash.GET_VEHICLE_LIVERY2_COUNT, veh);
			}
			VehicleLivery2Item.Multiplier = 1;
			nativeMenu3.Add(VehicleLivery2Item);
			VehicleLivery2Item.ValueChanged += (object sender, EventArgs e) =>
			{
				Function.Call(Hash.SET_VEHICLE_LIVERY2, veh, VehicleLivery2Item.Value);
			};
		}
		NativeMenu nativeMenu4 = new NativeMenu("", "Vehicle Extras", "Browse for Vehicle Extras.");
		MDPool.Add(nativeMenu4);
		nativeMenu4.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu4.CloseOnInvalidClick = false;
		nativeMenu4.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem4 = new NativeSubmenuItem(nativeMenu4, MainMenu);
		nativeSubmenuItem4.AltTitle = "";
		MainMenu.Add(3, nativeSubmenuItem4);
		NativeSliderItem VehicleWindowTintItem = new NativeSliderItem("Window Tint", "Change the tint of the windows on the Car.", Function.Call<int>(Hash.GET_NUM_VEHICLE_WINDOW_TINTS), 0);
		VehicleWindowTintItem.Multiplier = 1;
		nativeMenu4.Add(VehicleWindowTintItem);
		VehicleWindowTintItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_WINDOW_TINT, veh, VehicleWindowTintItem.Value);
		};
		NativeSliderItem VehiclePlateTypeItem = new NativeSliderItem("Number Plate Type", "Change the type of your number plate on the back of the car.", Function.Call<int>(Hash.GET_NUMBER_OF_VEHICLE_NUMBER_PLATES), 0);
		VehiclePlateTypeItem.Multiplier = 1;
		nativeMenu4.Add(VehiclePlateTypeItem);
		VehiclePlateTypeItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh, VehiclePlateTypeItem.Value);
		};
		NativeItem VehiclePlateTextItem = new NativeItem("Number Plate Text", "Change the text on your number plate on the back of the car.", Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, veh) ?? "");
		nativeMenu4.Add(VehiclePlateTextItem);
		VehiclePlateTextItem.Activated += (object sender, EventArgs e) =>
		{
			string text = "";
			text = ONSCREEN_KEYBOARD.GetUserInput("", Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, veh), 8);
			if (Function.Call<bool>(Hash.IS_STRING_NULL_OR_EMPTY, text))
			{
				Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, veh, Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, veh));
				Notification.Show("Text Invalid, Returning Plate to Original.");
			}
			else
			{
				Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, veh, text);
				if (CruelMastersOnlineOffline.DEBUG)
				{
					Notification.Show("Text Accepted, Changing Plate to New Text.");
				}
				VehiclePlateTextItem.AltTitle = text;
			}
		};
		NativeCheckboxItem ToggleNeonLeftItem = new NativeCheckboxItem("Vehicle Neon Left Side", "Toggle on or off Vehicle Neon on the Left Side.", check: false);
		nativeMenu4.Add(ToggleNeonLeftItem);
		NativeCheckboxItem ToggleNeonRightItem = new NativeCheckboxItem("Vehicle Neon Right Side", "Toggle on or off Vehicle Neon on the Right Side.", check: false);
		nativeMenu4.Add(ToggleNeonRightItem);
		NativeCheckboxItem ToggleNeonFrontItem = new NativeCheckboxItem("Vehicle Neon Front Side", "Toggle on or off Vehicle Neon on the Front Side.", check: false);
		nativeMenu4.Add(ToggleNeonFrontItem);
		NativeCheckboxItem ToggleNeonBackItem = new NativeCheckboxItem("Vehicle Neon Back Side", "Toggle on or off Vehicle Neon on the Back Side.", check: false);
		nativeMenu4.Add(ToggleNeonBackItem);
		ToggleNeonLeftItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, veh, 0, ToggleNeonLeftItem.Checked);
			Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, veh, 255, 255, 255);
		};
		ToggleNeonRightItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, veh, 1, ToggleNeonRightItem.Checked);
			Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, veh, 255, 255, 255);
		};
		ToggleNeonFrontItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, veh, 2, ToggleNeonFrontItem.Checked);
			Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, veh, 255, 255, 255);
		};
		ToggleNeonBackItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, veh, 3, ToggleNeonBackItem.Checked);
			Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, veh, 255, 255, 255);
		};
		NativeSliderItem ToggleNeonColorRItem = new NativeSliderItem("Vehicle Neon Color R", "Change the Vehicle Neon Colors Red Color.", 255, 255);
		ToggleNeonColorRItem.Multiplier = 5;
		nativeMenu4.Add(ToggleNeonColorRItem);
		NativeSliderItem ToggleNeonColorGItem = new NativeSliderItem("Vehicle Neon Color G", "Change the Vehicle Neon Colors Green Color.", 255, 255);
		ToggleNeonColorGItem.Multiplier = 5;
		nativeMenu4.Add(ToggleNeonColorGItem);
		NativeSliderItem ToggleNeonColorBItem = new NativeSliderItem("Vehicle Neon Color B", "Change the Vehicle Neon Colors Blue Color.", 255, 255);
		ToggleNeonColorBItem.Multiplier = 5;
		nativeMenu4.Add(ToggleNeonColorBItem);
		ToggleNeonColorRItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, veh, ToggleNeonColorRItem.Value, ToggleNeonColorGItem.Value, ToggleNeonColorBItem.Value);
		};
		ToggleNeonColorGItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, veh, ToggleNeonColorRItem.Value, ToggleNeonColorGItem.Value, ToggleNeonColorBItem.Value);
		};
		ToggleNeonColorBItem.ValueChanged += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, veh, ToggleNeonColorRItem.Value, ToggleNeonColorGItem.Value, ToggleNeonColorBItem.Value);
		};
		for (int i = 0; i < 15; i++)
		{
			if (Function.Call<bool>(Hash.DOES_EXTRA_EXIST, veh, i))
			{
				NativeCheckboxItem ToggleExtrasItem = new NativeCheckboxItem($"Vehicle Extra {i}", "Toggle on or off Vehicle Extras.\nNot Checked/False = Enable Extra\nChecked/True = Disable Extra", check: false);
				nativeMenu4.Add(ToggleExtrasItem);
				ToggleExtrasItem.CheckboxChanged += (object sender, EventArgs e) =>
				{
					Function.Call(Hash.SET_VEHICLE_EXTRA, veh, i, ToggleExtrasItem.Checked);
				};
			}
		}
		NativeMenu nativeMenu5 = new NativeMenu("", "Vehicle Tires", "Browse for Vehicle Tires.");
		MDPool.Add(nativeMenu5);
		nativeMenu5.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu5.CloseOnInvalidClick = false;
		nativeMenu5.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem5 = new NativeSubmenuItem(nativeMenu5, MainMenu);
		nativeSubmenuItem5.AltTitle = "";
		MainMenu.Add(4, nativeSubmenuItem5);
		NativeCheckboxItem ToggleCustomTireItem = new NativeCheckboxItem("Custom Tires", "Toggle on or off Custom tires on this vehicle. (Your tires can be customized)", check: false);
		nativeMenu5.Add(ToggleCustomTireItem);
		NativeListItem<int> WheelTypeItem = new NativeListItem<int>("Wheel Type", "Select a Wheel Type.\n0: Sport\n1: Muscle\n2: Lowrider\n3: SUV\n4: Offroad\n5: Tuner\n6: Bike Wheels\n7: High End\n8: Benny's Originals\n9: Benny's Bespoke\n10: Racing\n11: Street\n12: Track");
		int iVar1;
		for (iVar1 = 0; iVar1 < 13; iVar1++)
		{
			WheelTypeItem.Add(iVar1);
		}
		WheelTypeItem.GoRight();
		WheelTypeItem.GoLeft();
		WheelTypeItem.Enabled = true;
		nativeMenu5.Add(WheelTypeItem);
		NativeListItem<int> WheelModItem = new NativeListItem<int>("Wheel Mod", "Select a Wheel Mod.");
		WheelModItem.Clear();
		for (iVar1 = 0; iVar1 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 23); iVar1++)
		{
			WheelModItem.Add(iVar1, iVar1);
		}
		if (veh.Model.IsBike)
		{
			WheelModItem.Clear();
			for (iVar1 = 0; iVar1 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 24); iVar1++)
			{
				WheelModItem.Add(iVar1, iVar1);
			}
		}
		WheelModItem.GoRight();
		WheelModItem.GoLeft();
		WheelModItem.Enabled = true;
		nativeMenu5.Add(WheelModItem);
		WheelModItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_VEHICLE_MOD, veh, 24, WheelModItem.SelectedItem, ToggleCustomTireItem.Checked);
			Function.Call(Hash.SET_VEHICLE_MOD, veh, 23, WheelModItem.SelectedItem, ToggleCustomTireItem.Checked);
		};
		WheelTypeItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, veh, WheelTypeItem.SelectedItem);
			WheelModItem.Clear();
			for (iVar1 = 0; iVar1 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 23); iVar1++)
			{
				WheelModItem.Add(iVar1, iVar1);
			}
			if (veh.Model.IsBike)
			{
				WheelModItem.Clear();
				for (iVar1 = 0; iVar1 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 24); iVar1++)
				{
					WheelModItem.Add(iVar1, iVar1);
				}
			}
			WheelModItem.GoRight();
			WheelModItem.GoLeft();
			WheelModItem.Enabled = true;
		};
		NativeListItem<int> WheelRimColorItem = new NativeListItem<int>("Rim Color", "Select a Rim Pearl Color.");
		for (iVar1 = 0; iVar1 < Function.Call<int>(Hash.GET_NUM_MOD_COLORS, 0); iVar1++)
		{
			WheelRimColorItem.Add(iVar1);
		}
		WheelRimColorItem.GoRight();
		WheelRimColorItem.GoLeft();
		WheelRimColorItem.Enabled = false;
		nativeMenu5.Add(WheelRimColorItem);
		WheelRimColorItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			if (ToggleCustomTireItem.Checked)
			{
				OutputArgument outputArgument = new OutputArgument();
				OutputArgument outputArgument2 = new OutputArgument();
				Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, veh, outputArgument, outputArgument2);
				Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, veh, outputArgument.GetResult<int>(), WheelRimColorItem.SelectedItem);
			}
		};
		ToggleCustomTireItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			WheelRimColorItem.Enabled = ToggleCustomTireItem.Checked;
			Function.Call(Hash.SET_VEHICLE_MOD, veh, 24, 0, ToggleCustomTireItem.Checked);
			Function.Call(Hash.SET_VEHICLE_MOD, veh, 23, 0, ToggleCustomTireItem.Checked);
			WheelModItem.Clear();
			for (iVar1 = 0; iVar1 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 23); iVar1++)
			{
				WheelModItem.Add(iVar1, iVar1);
			}
			if (veh.Model.IsBike)
			{
				WheelModItem.Clear();
				for (iVar1 = 0; iVar1 < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh, 24); iVar1++)
				{
					WheelModItem.Add(iVar1, iVar1);
				}
			}
			WheelModItem.GoRight();
			WheelModItem.GoLeft();
			WheelModItem.Enabled = true;
		};
		NativeCheckboxItem ToggleBulletProofItem = new NativeCheckboxItem("Bullet Proof Tires", "Toggle on or off bullet proof tires on this vehicle. (Your tires cannot be shot out)", check: false);
		nativeMenu5.Add(ToggleBulletProofItem);
		ToggleBulletProofItem.CheckboxChanged += (object sender, EventArgs e) =>
		{
			if (ToggleBulletProofItem.Checked)
			{
				Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, veh, false);
			}
			else
			{
				Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, veh, true);
			}
		};
		NativeItem nativeItem2 = new NativeItem("Repair Vehicle", "Repair your vehicle if it is damaged.", $"${34000}");
		nativeItem2.Activated += (object sender, EventArgs e) =>
		{
			if (veh.IsDamaged)
			{
				if (MPCash.PROCESS_TRANSACTION(34000) || CruelMastersOnlineOffline.DEBUG)
				{
					Function.Call(Hash.SET_VEHICLE_FIXED, veh);
					Function.Call(Hash.SET_VEHICLE_DEFORMATION_FIXED, veh);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 0);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 1);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 2);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 3);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 4);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 5);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 6);
					Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 7);
					Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 0);
					Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 1);
					Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 2);
					Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 3);
					Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 4);
					Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 5);
					Function.Call(Hash.SET_ENTITY_HEALTH, veh, 1000, 0);
					Function.Call(Hash.SET_VEHICLE_ENGINE_HEALTH, veh, 1000f);
					Function.Call(Hash.SET_VEHICLE_PETROL_TANK_HEALTH, veh, 1000f);
				}
				else
				{
					Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
				}
			}
			else
			{
				Notification.Show("Vehicle does not Require Repair.", blinking: true);
			}
		};
		MainMenu.Add(5, nativeItem2);
		NativeItem nativeItem3 = new NativeItem("Finish Customizing Vehicle", "Purchase your newly upgraded vehicle for a small price and enjoy the miles.", $"${50000}");
		nativeItem3.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(50000) || CruelMastersOnlineOffline.DEBUG)
			{
				Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, veh, 0f);
				Function.Call(Hash.SET_VEHICLE_FIXED, veh);
				Function.Call(Hash.SET_VEHICLE_DEFORMATION_FIXED, veh);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 0);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 1);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 2);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 3);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 4);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 5);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 6);
				Function.Call(Hash.FIX_VEHICLE_WINDOW, veh, 7);
				Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 0);
				Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 1);
				Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 2);
				Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 3);
				Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 4);
				Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, veh, 5);
				Function.Call(Hash.SET_ENTITY_HEALTH, veh, 1000, 0);
				Function.Call(Hash.SET_VEHICLE_ENGINE_HEALTH, veh, 1000f);
				Function.Call(Hash.SET_VEHICLE_PETROL_TANK_HEALTH, veh, 1000f);
				MPVehicleLoadout.SAVE_VEHICLE(CruelMastersOnlineOffline.PlayerVehicle, "scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", GET_VEHICLE_NAME_ID());
				MPOwnedVehicles mPOwnedVehicles = new MPOwnedVehicles();
				string[] files = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles");
				foreach (string fileName in files)
				{
					mPOwnedVehicles = XMLSerializer.DeserializeXML<MPOwnedVehicles>(fileName);
					if (mPOwnedVehicles.ownedVehicles[0].VehicleName == GET_VEHICLE_NAME_ID())
					{
						MPOwnedVehicles.SAVE_PREVIOUS_OWNED_VEHICLE("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", mPOwnedVehicles.ownedVehicles[0].VehicleName);
						if (CruelMastersOnlineOffline.DEBUG)
						{
							Notification.Show(mPOwnedVehicles.ownedVehicles[0].VehicleName + " has now been overwriten.", blinking: true);
						}
						break;
					}
				}
				GarageTransactionSpent = true;
				MainMenu.Visible = false;
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		MainMenu.Add(6, nativeItem3);
		MainMenu.Visible = true;
	}
}
