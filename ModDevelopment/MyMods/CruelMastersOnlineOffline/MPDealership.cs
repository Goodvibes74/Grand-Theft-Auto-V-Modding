using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Elements;
using LemonUI.Menus;
using LemonUI.Scaleform;

namespace CruelMastersOnlineOffline;

internal class MPDealership : Script
{
	public static Blip SimeonDealershipBlip;

	public static Vehicle ShownVehicle;

	public static bool MenuOpen = false;

	public static ObjectPool MDPool = new ObjectPool();

	public static NativeMenu MainMenu = new NativeMenu("DEALERSHIP", "CATEGORIES", "");

	public MPDealership()
	{
		Tick += onTick;
		Aborted += onShutdown;
		MDPool = new ObjectPool();
		MainMenu = new NativeMenu("", "CATEGORIES", "");
		ScaledTexture banner = new ScaledTexture(MainMenu.Banner.Position, new SizeF(MainMenu.Banner.Size.Width, MainMenu.Banner.Size.Height), "shopui_title_premium_deluxe_motorsport", "shopui_title_premium_deluxe_motorsport");
		MainMenu.Banner = banner;
		MainMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		MainMenu.NoItemsText = "There are no items available";
		MainMenu.ItemCount = CountVisibility.Always;
		MDPool.Add(MainMenu);
	}

	public static void DEALERSHIP_MENU()
	{
		MainMenu.Clear();
		MainMenu.Name = "CATEGORIES";
		MainMenu.Buttons.Clear();
		InstructionalButton[] array = new InstructionalButton[2]
		{
			new InstructionalButton("Select", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		MainMenu.Buttons.Add(array[0]);
		MainMenu.Buttons.Add(array[1]);
		MainMenu.NoItemsText = "There are no items available";
		ScaledTexture banner = new ScaledTexture(MainMenu.Banner.Position, new SizeF(MainMenu.Banner.Size.Width, MainMenu.Banner.Size.Height), "shopui_title_premium_deluxe_motorsport", "shopui_title_premium_deluxe_motorsport");
		NativeMenu nativeMenu = new NativeMenu("", "Compacts", "Browse for Compacts.");
		MDPool.Add(nativeMenu);
		nativeMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu.CloseOnInvalidClick = false;
		nativeMenu.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem = new NativeSubmenuItem(nativeMenu, MainMenu);
		nativeSubmenuItem.AltTitle = "";
		nativeMenu.Buttons.Clear();
		InstructionalButton[] array2 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu.Buttons.Add(array2[0]);
		nativeMenu.Buttons.Add(array2[1]);
		nativeMenu.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(0, nativeSubmenuItem);
		NativeItem nativeItem = new NativeItem("Dinka Blista", "Purchase The Dinka Blista.", "$16,000");
		nativeItem.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Blista, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.27685f), new Vector3(0f, 0f, 332.41f), 40f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(16000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Blista", 16000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu.Add(nativeItem);
		NativeItem nativeItem2 = new NativeItem("Karin Dilettante", "Purchase The Karin Dilettante.", "$25,000");
		nativeItem2.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dilettante, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.27685f), new Vector3(0f, 0f, 332.41f), 40f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem2.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(25000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin Dilettante", 25000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu.Add(nativeItem2);
		NativeItem nativeItem3 = new NativeItem("Weeny Issi", "Purchase The Weeny Issi.", "$18,000");
		nativeItem3.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Issi2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.27685f), new Vector3(0f, 0f, 332.41f), 40f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem3.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(18000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Weeny Issi", 18000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu.Add(nativeItem3);
		NativeItem nativeItem4 = new NativeItem("Bollokan Prairie", "Purchase The Bollokan Prairie.", "$25,000");
		nativeItem4.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Prairie, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.27685f), new Vector3(0f, 0f, 332.41f), 40f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem4.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(25000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bollokan Prairie", 25000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu.Add(nativeItem4);
		NativeItem nativeItem5 = new NativeItem("Benefactor Panto", "Purchase The Benefactor Panto.", "$85,000");
		nativeItem5.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Panto, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.27685f), new Vector3(0f, 0f, 332.41f), 40f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem5.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(85000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Panto", 85000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu.Add(nativeItem5);
		NativeItem nativeItem6 = new NativeItem("Declasse Rhapsody", "Purchase The Declasse Rhapsody.", "$140,000");
		nativeItem6.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Rhapsody, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.27685f), new Vector3(0f, 0f, 332.41f), 40f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem6.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(140000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Rhapsody", 140000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu.Add(nativeItem6);
		NativeMenu nativeMenu2 = new NativeMenu("", "Coupes", "Browse for Coupes.");
		MDPool.Add(nativeMenu2);
		nativeMenu2.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu2.CloseOnInvalidClick = false;
		nativeMenu2.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem2 = new NativeSubmenuItem(nativeMenu2, MainMenu);
		nativeSubmenuItem2.AltTitle = "";
		nativeMenu2.Buttons.Clear();
		InstructionalButton[] array3 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu2.Buttons.Add(array3[0]);
		nativeMenu2.Buttons.Add(array3[1]);
		nativeMenu2.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(1, nativeSubmenuItem2);
		NativeItem nativeItem7 = new NativeItem("Enus Cognoscenti Cabrio", "Purchase The Enus Cognoscenti Cabrio.", "$185,000");
		nativeItem7.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.CogCabrio, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem7.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(185000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Enus Cognoscenti Cabrio", 185000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem7);
		NativeItem nativeItem8 = new NativeItem("Dewbauchee Exemplar", "Purchase The Dewbauchee Exemplar.", "$205,000");
		nativeItem8.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Exemplar, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem8.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(205000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dewbauchee Exemplar", 205000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem8);
		NativeItem nativeItem9 = new NativeItem("Ocelot F620", "Purchase The Ocelot F620.", "$80,000");
		nativeItem9.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.F620, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem9.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(80000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Ocelot F620", 80000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem9);
		NativeItem nativeItem10 = new NativeItem("Lampadati Felon", "Purchase The Lampadati Felon.", "$100,000");
		nativeItem10.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Felon, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem10.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(100000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Lampadati Felon", 100000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem10);
		NativeItem nativeItem11 = new NativeItem("Lampadati Felon GT", "Purchase The Lampadati Felon GT.", "$95,000");
		nativeItem11.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Felon2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem11.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(95000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Lampadati Felon GT", 95000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem11);
		NativeItem nativeItem12 = new NativeItem("Ocelot Jackal", "Purchase The Ocelot Jackal.", "$60,000");
		nativeItem12.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Jackal, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem12.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(60000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Ocelot Jackal", 60000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem12);
		NativeItem nativeItem13 = new NativeItem("Übermacht Oracle", "Purchase The Übermacht Oracle.", "$80,000");
		nativeItem13.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Oracle2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem13.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(80000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Übermacht Oracle", 80000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem13);
		NativeItem nativeItem14 = new NativeItem("Übermacht Oracle XS", "Purchase The Übermacht Oracle XS.", "$82,000");
		nativeItem14.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Oracle, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem14.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(82000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Übermacht Oracle XS", 82000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem14);
		NativeItem nativeItem15 = new NativeItem("Übermacht Sentinel", "Purchase The Übermacht Sentinel.", "$95,000");
		nativeItem15.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sentinel2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem15.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(95000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Übermacht Sentinel", 95000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem15);
		NativeItem nativeItem16 = new NativeItem("Übermacht Sentinel XS", "Purchase The Übermacht Sentinel XS.", "$60,000");
		nativeItem16.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sentinel, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem16.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(60000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Übermacht Sentinel XS", 60000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem16);
		NativeItem nativeItem17 = new NativeItem("Übermacht Zion", "Purchase The Übermacht Zion.", "$60,000");
		nativeItem17.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Zion, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem17.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(60000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Übermacht Zion", 60000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem17);
		NativeItem nativeItem18 = new NativeItem("Übermacht Zion Cabrio", "Purchase The Übermacht Zion Cabrio.", "$65,000");
		nativeItem18.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Zion2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.87685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem18.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(65000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Übermacht Zion Cabrio", 65000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu2.Add(nativeItem18);
		NativeMenu nativeMenu3 = new NativeMenu("", "Bikes", "Browse for Bikes.");
		MDPool.Add(nativeMenu3);
		nativeMenu3.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu3.CloseOnInvalidClick = false;
		nativeMenu3.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem3 = new NativeSubmenuItem(nativeMenu3, MainMenu);
		nativeSubmenuItem3.AltTitle = "";
		nativeMenu3.Buttons.Clear();
		InstructionalButton[] array4 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Bike", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu3.Buttons.Add(array4[0]);
		nativeMenu3.Buttons.Add(array4[1]);
		nativeMenu3.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(2, nativeSubmenuItem3);
		NativeItem nativeItem19 = new NativeItem("BMX", "Purchase The BMX.", "$800");
		nativeItem19.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bmx, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem19.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(800) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("BMX", 800);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu3.Add(nativeItem19);
		NativeItem nativeItem20 = new NativeItem("Cruiser", "Purchase The Cruiser.", "$800");
		nativeItem20.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Cruiser, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem20.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(800) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Cruiser", 800);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu3.Add(nativeItem20);
		NativeItem nativeItem21 = new NativeItem("Endurex Race Bike", "Purchase The Endurex Race Bike.", "$10,000");
		nativeItem21.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.TriBike2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem21.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Endurex Race Bike", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu3.Add(nativeItem21);
		NativeItem nativeItem22 = new NativeItem("Fixter", "Purchase The Fixter.", "$11,547");
		nativeItem22.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Fixter, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem22.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(11547) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Fixter", 11547);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu3.Add(nativeItem22);
		NativeItem nativeItem23 = new NativeItem("Scorcher", "Purchase The Scorcher.", "$2,000");
		nativeItem23.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Scorcher, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem23.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(2000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Scorcher", 2000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu3.Add(nativeItem23);
		NativeItem nativeItem24 = new NativeItem("Tri-Cycles Race Bike", "Purchase The Tri-Cycles Race Bike.", "$10,000");
		nativeItem24.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.TriBike3, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem24.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Tri-Cycles Race Bike", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu3.Add(nativeItem24);
		NativeItem nativeItem25 = new NativeItem("Whippet Race Bike", "Purchase The Whippet Race Bike.", "$10,000");
		nativeItem25.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.TriBike, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem25.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Whippet Race Bike", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu3.Add(nativeItem25);
		NativeMenu nativeMenu4 = new NativeMenu("", "Motorcycles", "Browse for Motorcycles.");
		MDPool.Add(nativeMenu4);
		nativeMenu4.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu4.CloseOnInvalidClick = false;
		nativeMenu4.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem4 = new NativeSubmenuItem(nativeMenu4, MainMenu);
		nativeSubmenuItem4.AltTitle = "";
		nativeMenu4.Buttons.Clear();
		InstructionalButton[] array5 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Motorcycle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu4.Buttons.Add(array5[0]);
		nativeMenu4.Buttons.Add(array5[1]);
		nativeMenu4.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(3, nativeSubmenuItem4);
		NativeItem nativeItem26 = new NativeItem("Dinka Akuma", "Purchase The Dinka Akuma.", "$9,000");
		nativeItem26.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Akuma, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem26.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Akuma", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem26);
		NativeItem nativeItem27 = new NativeItem("Western Bagger", "Purchase The Western Bagger.", "$16,000");
		nativeItem27.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bagger, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem27.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(16000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Western Bagger", 16000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem27);
		NativeItem nativeItem28 = new NativeItem("Pegassi Bati 801", "Purchase The Pegassi Bati 801.", "$15,000");
		nativeItem28.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bati, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem28.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(15000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pegassi Bati 801", 15000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem28);
		NativeItem nativeItem29 = new NativeItem("Pegassi Bati 801RR", "Purchase The Pegassi Bati 801RR.", "$15,000");
		nativeItem29.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bati2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem29.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(15000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pegassi Bati 801RR", 15000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem29);
		NativeItem nativeItem30 = new NativeItem("Nagasaki Carbon RS", "Purchase The Nagasaki Carbon RS.", "$40,000");
		nativeItem30.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.CarbonRS, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem30.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(40000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Nagasaki Carbon RS", 40000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem30);
		NativeItem nativeItem31 = new NativeItem("Dinka Double-T", "Purchase The Dinka Double-T.", "$12,000");
		nativeItem31.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Double, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem31.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(12000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Double-T", 12000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem31);
		NativeItem nativeItem32 = new NativeItem("Faggio", "Purchase The Faggio.", "$5,000");
		nativeItem32.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Faggio2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem32.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(5000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Faggio", 5000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem32);
		NativeItem nativeItem33 = new NativeItem("LCC Hexer", "Purchase The LCC Hexer.", "$15,000");
		nativeItem33.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Hexer, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem33.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(15000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("LCC Hexer", 15000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem33);
		NativeItem nativeItem34 = new NativeItem("Principe Nemesis", "Purchase The Principe Nemesis.", "$12,000");
		nativeItem34.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Nemesis, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem34.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(12000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Principe Nemesis", 12000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem34);
		NativeItem nativeItem35 = new NativeItem("Shitzu PCJ 600", "Purchase The Shitzu PCJ 600.", "$9,000");
		nativeItem35.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.PCJ, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem35.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Shitzu PCJ 600", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem35);
		NativeItem nativeItem36 = new NativeItem("Pegassi Ruffian", "Purchase The Pegassi Ruffian.", "$10,000");
		nativeItem36.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Ruffian, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem36.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pegassi Ruffian", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem36);
		NativeItem nativeItem37 = new NativeItem("Maibatsu Sanchez", "Purchase The Maibatsu Sanchez.", "$8,000");
		nativeItem37.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sanchez2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem37.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(8000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Maibatsu Sanchez", 8000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem37);
		NativeItem nativeItem38 = new NativeItem("Maibatsu Sanchez (Livery)", "Purchase The Maibatsu Sanchez (Livery).", "$7,000");
		nativeItem38.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sanchez, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem38.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(7000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Maibatsu Sanchez (Livery)", 7000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem38);
		NativeItem nativeItem39 = new NativeItem("Shitzu Vader", "Purchase The Shitzu Vader.", "$9,000");
		nativeItem39.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Vader, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem39.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Shitzu Vader", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem39);
		NativeItem nativeItem40 = new NativeItem("Dinka Thrust", "Purchase The Dinka Thrust.", "$75,000");
		nativeItem40.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Thrust, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem40.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(75000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Thrust", 75000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem40);
		NativeItem nativeItem41 = new NativeItem("Western Sovereign", "Purchase The Western Sovereign.", "$90,000");
		nativeItem41.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sovereign, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem41.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(90000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Western Sovereign", 90000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem41);
		NativeItem nativeItem42 = new NativeItem("Shitzu Hakuchou", "Purchase The Shitzu Hakuchou.", "$82,000");
		nativeItem42.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Hakuchou, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem42.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(82000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Shitzu Hakuchou", 82000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem42);
		NativeItem nativeItem43 = new NativeItem("LCC Innovation", "Purchase The LCC Innovation.", "$92,500");
		nativeItem43.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Innovation, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem43.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(92500) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("LCC Innovation", 92500);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu4.Add(nativeItem43);
		NativeMenu nativeMenu5 = new NativeMenu("", "Muscle Vehicles", "Browse for Muscle Vehicles.");
		MDPool.Add(nativeMenu5);
		nativeMenu5.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu5.CloseOnInvalidClick = false;
		nativeMenu5.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem5 = new NativeSubmenuItem(nativeMenu5, MainMenu);
		nativeSubmenuItem5.AltTitle = "";
		nativeMenu5.Buttons.Clear();
		InstructionalButton[] array6 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu5.Buttons.Add(array6[0]);
		nativeMenu5.Buttons.Add(array6[1]);
		nativeMenu5.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(4, nativeSubmenuItem5);
		NativeItem nativeItem44 = new NativeItem("Albany Buccaneer", "Purchase The Albany Buccaneer.", "$29,000");
		nativeItem44.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Buccaneer, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem44.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(29000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Buccaneer", 29000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem44);
		NativeItem nativeItem45 = new NativeItem("Vapid Dominator", "Purchase The Vapid Dominator.", "$35,000");
		nativeItem45.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dominator, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem45.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(35000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Dominator", 35000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem45);
		NativeItem nativeItem46 = new NativeItem("Bravado Gauntlet", "Purchase The Bravado Gauntlet.", "$32,000");
		nativeItem46.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Gauntlet, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem46.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(32000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Gauntlet", 32000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem46);
		NativeItem nativeItem47 = new NativeItem("Vapid Hotknife", "Purchase The Vapid Hotknife.", "$90,000");
		nativeItem47.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Hotknife, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem47.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(90000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Hotknife", 90000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem47);
		NativeItem nativeItem48 = new NativeItem("Imponte Phoenix", "Purchase The Imponte Phoenix.", "$20,000");
		nativeItem48.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Phoenix, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem48.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(20000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Imponte Phoenix", 20000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem48);
		NativeItem nativeItem49 = new NativeItem("Cheval Picador", "Purchase The Cheval Picador.", "$9,000");
		nativeItem49.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Picador, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem49.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Cheval Picador", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem49);
		NativeItem nativeItem50 = new NativeItem("Bravado Rat-Loader", "Purchase The Bravado Rat-Loader.", "FREE");
		nativeItem50.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.RatLoader, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem50.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Rat-Loader", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem50);
		NativeItem nativeItem51 = new NativeItem("Imponte Ruiner", "Purchase The Imponte Ruiner.", "$10,000");
		nativeItem51.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Ruiner, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem51.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Imponte Ruiner", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem51);
		NativeItem nativeItem52 = new NativeItem("Declasse Sabre Turbo", "Purchase The Declasse Sabre Turbo.", "$15,000");
		nativeItem52.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.SabreGT, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem52.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(15000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Sabre Turbo", 15000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem52);
		NativeItem nativeItem53 = new NativeItem("Declasse Vigero", "Purchase The Declasse Vigero.", "$21,000");
		nativeItem53.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Vigero, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem53.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(21000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Vigero", 21000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem53);
		NativeItem nativeItem54 = new NativeItem("Declasse Voodoo", "Purchase The Declasse Voodoo.", "FREE");
		nativeItem54.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Voodoo2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem54.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Voodoo", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem54);
		NativeItem nativeItem55 = new NativeItem("Vapid Blade", "Purchase The Vapid Blade.", "$160,000");
		nativeItem55.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Blade, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem55.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(160000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Blade", 160000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem55);
		NativeItem nativeItem56 = new NativeItem("Vapid Pißwasser Dominator", "Purchase The Vapid Pißwasser Dominator.", "FREE");
		nativeItem56.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dominator2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem56.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Pißwasser Dominator", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem56);
		NativeItem nativeItem57 = new NativeItem("Imponte Duke O'Death", "Purchase The Imponte Duke O'Death.", "FREE");
		nativeItem57.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dukes2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem57.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Imponte Duke O'Death", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem57);
		NativeItem nativeItem58 = new NativeItem("Imponte Dukes", "Purchase The Imponte Dukes.", "FREE");
		nativeItem58.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dukes, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem58.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Imponte Dukes", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem58);
		NativeItem nativeItem59 = new NativeItem("Bravado Redwood Gauntlet", "Purchase The Bravado Redwood Gauntlet.", "FREE");
		nativeItem59.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Gauntlet2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem59.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Redwood Gauntlet", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem59);
		NativeItem nativeItem60 = new NativeItem("Declasse Stallion", "Purchase The Declasse Stallion.", "FREE");
		nativeItem60.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Stalion, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem60.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Stallion", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem60);
		NativeItem nativeItem61 = new NativeItem("Declasse Burger Shot Stallion", "Purchase The Declasse Burger Shot Stallion.", "FREE");
		nativeItem61.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Stalion2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem61.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Burger Shot Stallion", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem61);
		NativeItem nativeItem62 = new NativeItem("Bravado Rat-Truck", "Purchase The Bravado Rat-Truck.", "$28,125");
		nativeItem62.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.RatLoader2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem62.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(28125) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Rat-Truck", 28125);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem62);
		NativeItem nativeItem63 = new NativeItem("Vapid Slamvan", "Purchase The Vapid Slamvan.", "$37,125");
		nativeItem63.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.SlamVan, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem63.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(37125) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Slamvan", 37125);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu5.Add(nativeItem63);
		NativeMenu nativeMenu6 = new NativeMenu("", "Off-Road Vehicles", "Browse for Off-Road Vehicles.");
		MDPool.Add(nativeMenu6);
		nativeMenu6.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu6.CloseOnInvalidClick = false;
		nativeMenu6.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem6 = new NativeSubmenuItem(nativeMenu6, MainMenu);
		nativeSubmenuItem6.AltTitle = "";
		nativeMenu6.Buttons.Clear();
		InstructionalButton[] array7 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu6.Buttons.Add(array7[0]);
		nativeMenu6.Buttons.Add(array7[1]);
		nativeMenu6.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(5, nativeSubmenuItem6);
		NativeItem nativeItem64 = new NativeItem("Nagasaki Blazer", "Purchase The Nagasaki Blazer.", "$8,000");
		nativeItem64.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Blazer, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem64.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(8000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Nagasaki Blazer", 8000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem64);
		NativeItem nativeItem65 = new NativeItem("Canis Bodhi", "Purchase The Canis Bodhi.", "$25,000");
		nativeItem65.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bodhi2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem65.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(25000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Canis Bodhi", 25000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem65);
		NativeItem nativeItem66 = new NativeItem("BF Dune Buggy", "Purchase The BF Dune Buggy.", "$20,000");
		nativeItem66.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dune, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem66.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(20000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("BF Dune Buggy", 20000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem66);
		NativeItem nativeItem67 = new NativeItem("Bravado Duneloader", "Purchase The Bravado Duneloader.", "FREE");
		nativeItem67.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.DLoader, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem67.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Duneloader", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem67);
		NativeItem nativeItem68 = new NativeItem("Nagasaki Hot Rod Blazer", "Purchase The Nagasaki Hot Rod Blazer.", "$69,000");
		nativeItem68.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Blazer3, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem68.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(69000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Nagasaki Hot Rod Blazer", 69000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem68);
		NativeItem nativeItem69 = new NativeItem("BF Injection", "Purchase The BF Injection.", "$16,000");
		nativeItem69.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.BfInjection, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem69.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(16000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("BF Injection", 16000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem69);
		NativeItem nativeItem70 = new NativeItem("Canis Mesa (Merryweather)", "Purchase The Canis Mesa (Merryweather).", "$87,000");
		nativeItem70.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Mesa3, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem70.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(87000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Canis Mesa (Merryweather)", 87000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem70);
		NativeItem nativeItem71 = new NativeItem("Declasse Rancher XL", "Purchase The Declasse Rancher XL.", "$9,000");
		nativeItem71.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.RancherXL, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem71.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Rancher XL", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem71);
		NativeItem nativeItem72 = new NativeItem("Karin Rebel", "Purchase The Karin Rebel.", "$22,000");
		nativeItem72.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Rebel2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem72.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(22000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin Rebel", 22000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem72);
		NativeItem nativeItem73 = new NativeItem("Karin Rusty Rebel", "Purchase The Karin Rebel.", "FREE");
		nativeItem73.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Rebel, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem73.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin Rusty Rebel", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem73);
		NativeItem nativeItem74 = new NativeItem("Vapid Sandking SWB", "Purchase The Vapid Sandking SWB.", "$38,000");
		nativeItem74.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sandking2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1103.216f, 26.77685f), new Vector3(0f, 0f, 332.41f), 50f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem74.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(38000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Sandking SWB", 38000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem74);
		NativeItem nativeItem75 = new NativeItem("Mammoth Patriot", "Purchase The Mammoth Patriot.", "$50,000");
		nativeItem75.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Patriot, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem75.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(50000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Mammoth Patriot", 50000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem75);
		NativeItem nativeItem76 = new NativeItem("Declasse Tornado Mariachi", "Purchase The Declasse Tornado Mariachi.", "FREE");
		nativeItem76.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Tornado4, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem76.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Tornado Mariachi", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem76);
		NativeItem nativeItem77 = new NativeItem("BF Bifta", "Purchase The BF Bifta.", "$75,000");
		nativeItem77.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bifta, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem77.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(75000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("BF Bifta", 75000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem77);
		NativeItem nativeItem78 = new NativeItem("Canis Kalahari", "Purchase The Canis Kalahari.", "$40,000");
		nativeItem78.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Kalahari, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem78.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(40000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Canis Kalahari", 40000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu6.Add(nativeItem78);
		NativeMenu nativeMenu7 = new NativeMenu("", "Sedans", "Browse for Sedans.");
		MDPool.Add(nativeMenu7);
		nativeMenu7.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu7.CloseOnInvalidClick = false;
		nativeMenu7.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem7 = new NativeSubmenuItem(nativeMenu7, MainMenu);
		nativeSubmenuItem7.AltTitle = "";
		nativeMenu7.Buttons.Clear();
		InstructionalButton[] array8 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu7.Buttons.Add(array8[0]);
		nativeMenu7.Buttons.Add(array8[1]);
		nativeMenu7.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(6, nativeSubmenuItem7);
		NativeItem nativeItem79 = new NativeItem("Declasse Asea", "Purchase The Declasse Asea.", "$12,000");
		nativeItem79.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Asea, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem79.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(12000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Asea", 12000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem79);
		NativeItem nativeItem80 = new NativeItem("Karin Asterope", "Purchase The Karin Asterope.", "$26,000");
		nativeItem80.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Asterope, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem80.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(26000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin Asterope", 26000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem80);
		NativeItem nativeItem81 = new NativeItem("Albany Emperor", "Purchase The Albany Emperor.", "FREE");
		nativeItem81.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Emperor, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem81.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Emperor", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem81);
		NativeItem nativeItem82 = new NativeItem("Cheval Fugitive", "Purchase The Cheval Fugitive.", "$24,000");
		nativeItem82.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Fugitive, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem82.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(24000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Cheval Fugitive", 24000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem82);
		NativeItem nativeItem83 = new NativeItem("Vulcar Ingot", "Purchase The Vulcar Ingot.", "$9,000");
		nativeItem83.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Ingot, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem83.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vulcar Ingot", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem83);
		NativeItem nativeItem84 = new NativeItem("Karin Intruder", "Purchase The Karin Intruder.", "$16,000");
		nativeItem84.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Intruder, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem84.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(16000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin Intruder", 16000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem84);
		NativeItem nativeItem85 = new NativeItem("Declasse Premier", "Purchase The Declasse Premier.", "$10,000");
		nativeItem85.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Premier, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem85.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Premier", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem85);
		NativeItem nativeItem86 = new NativeItem("Albany Primo", "Purchase The Albany Primo.", "$9,000");
		nativeItem86.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Primo, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem86.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Primo", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem86);
		NativeItem nativeItem87 = new NativeItem("Dundreary Regina", "Purchase The Dundreary Regina.", "$8,000");
		nativeItem87.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Regina, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem87.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(8000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dundreary Regina", 8000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem87);
		NativeItem nativeItem88 = new NativeItem("Chariot Romero Hearse", "Purchase The Chariot Romero Hearse.", "$45,000");
		nativeItem88.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Romero, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem88.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(45000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Chariot Romero Hearse", 45000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem88);
		NativeItem nativeItem89 = new NativeItem("Benefactor Schafter", "Purchase The Benefactor Schafter.", "$65,000");
		nativeItem89.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Schafter2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem89.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(65000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Schafter", 65000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem89);
		NativeItem nativeItem90 = new NativeItem("Vapid Stanier", "Purchase The Vapid Stanier.", "$10,000");
		nativeItem90.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Stanier, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem90.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Stanier", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem90);
		NativeItem nativeItem91 = new NativeItem("Zirconium Stratum", "Purchase The Zirconium Stratum.", "$10,000");
		nativeItem91.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Stratum, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem91.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Zirconium Stratum", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem91);
		NativeItem nativeItem92 = new NativeItem("Enus Super Diamond", "Purchase The Enus Super Diamond.", "$150,000");
		nativeItem92.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Superd, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem92.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(150000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Enus Super Diamond", 150000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem92);
		NativeItem nativeItem93 = new NativeItem("Cheval Surge", "Purchase The Cheval Surge.", "$38,000");
		nativeItem93.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Surge, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem93.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(38000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Cheval Surge", 38000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem93);
		NativeItem nativeItem94 = new NativeItem("Obey Tailgater", "Purchase The Obey Tailgater.", "$55,000");
		nativeItem94.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Tailgater, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem94.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(55000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Obey Tailgater", 55000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem94);
		NativeItem nativeItem95 = new NativeItem("Albany Washington", "Purchase The Albany Washington.", "$15,000");
		nativeItem95.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Washington, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem95.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(15000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Washington", 15000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem95);
		NativeItem nativeItem96 = new NativeItem("Benefactor Glendale", "Purchase The Benefactor Glendale.", "$150,000");
		nativeItem96.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Glendale, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem96.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(150000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Glendale", 150000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem96);
		NativeItem nativeItem97 = new NativeItem("Vulcar Warrener", "Purchase The Vulcar Warrener.", "$120,000");
		nativeItem97.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Warrener, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem97.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(120000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vulcar Warrener", 120000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu7.Add(nativeItem97);
		NativeMenu nativeMenu8 = new NativeMenu("", "Sport Cars", "Browse for Sport Cars.");
		MDPool.Add(nativeMenu8);
		nativeMenu8.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu8.CloseOnInvalidClick = false;
		nativeMenu8.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem8 = new NativeSubmenuItem(nativeMenu8, MainMenu);
		nativeSubmenuItem8.AltTitle = "";
		nativeMenu8.Buttons.Clear();
		InstructionalButton[] array9 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu8.Buttons.Add(array9[0]);
		nativeMenu8.Buttons.Add(array9[1]);
		nativeMenu8.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(7, nativeSubmenuItem8);
		NativeItem nativeItem98 = new NativeItem("Obey 9F", "Purchase The Obey 9F.", "$120,000");
		nativeItem98.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Ninef, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem98.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(120000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Obey 9F", 120000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem98);
		NativeItem nativeItem99 = new NativeItem("Obey 9F Cabrio", "Purchase The Obey 9F Cabrio.", "$130,000");
		nativeItem99.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Ninef2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem99.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(130000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Obey 9F Cabrio", 130000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem99);
		NativeItem nativeItem100 = new NativeItem("Bravado Banshee", "Purchase The Bravado Banshee.", "$105,000");
		nativeItem100.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Banshee, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem100.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(105000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Banshee", 105000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem100);
		NativeItem nativeItem101 = new NativeItem("Bravado Buffalo", "Purchase The Bravado Buffalo.", "$35,000");
		nativeItem101.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Buffalo, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem101.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(35000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Buffalo", 35000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem101);
		NativeItem nativeItem102 = new NativeItem("Bravado Buffalo S", "Purchase The Bravado Buffalo S.", "$96,000");
		nativeItem102.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Buffalo2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem102.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(96000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Buffalo S", 96000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem102);
		NativeItem nativeItem103 = new NativeItem("Grotti Carbonizzare", "Purchase The Grotti Carbonizzare.", "$195,000");
		nativeItem103.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Carbonizzare, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem103.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(195000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Grotti Carbonizzare", 195000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem103);
		NativeItem nativeItem104 = new NativeItem("Pfister Comet", "Purchase The Pfister Comet.", "$100,000");
		nativeItem104.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Comet2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem104.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(100000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pfister Comet", 100000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem104);
		NativeItem nativeItem105 = new NativeItem("Invetero Coquette", "Purchase The Invetero Coquette.", "$138,000");
		nativeItem105.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Coquette, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem105.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(138000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Invetero Coquette", 138000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem105);
		NativeItem nativeItem106 = new NativeItem("Annis Elegy RH8", "Purchase The Annis Elegy RH8.", "$95,000");
		nativeItem106.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Elegy2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem106.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(95000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Annis Elegy RH8", 95000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem106);
		NativeItem nativeItem107 = new NativeItem("Benefactor Feltzer", "Purchase The Benefactor Feltzer.", "$145,000");
		nativeItem107.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Feltzer2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem107.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(145000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Feltzer", 145000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem107);
		NativeItem nativeItem108 = new NativeItem("Schyster Fusilade", "Purchase The Schyster Fusilade.", "$36,000");
		nativeItem108.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Fusilade, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem108.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(36000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Schyster Fusilade", 36000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem108);
		NativeItem nativeItem109 = new NativeItem("Karin Futo", "Purchase The Karin Futo.", "$9,000");
		nativeItem109.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Futo, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem109.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(9000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin Futo", 9000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem109);
		NativeItem nativeItem110 = new NativeItem("Maibatsu Penumbra", "Purchase The Maibatsu Penumbra.", "$24,000");
		nativeItem110.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Penumbra, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem110.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(24000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Maibatsu Penumbra", 24000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem110);
		NativeItem nativeItem111 = new NativeItem("Dewbauchee Rapid GT", "Purchase The Dewbauchee Rapid GT.", "$132,000");
		nativeItem111.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.RapidGT, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem111.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(132000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dewbauchee Rapid GT", 132000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem111);
		NativeItem nativeItem112 = new NativeItem("Dewbauchee Rapid GT Cabrio", "Purchase The Dewbauchee Rapid GT Cabrio.", "$140,000");
		nativeItem112.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.RapidGT2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem112.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(140000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dewbauchee Rapid GT Cabrio", 140000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem112);
		NativeItem nativeItem113 = new NativeItem("Benefactor Schwartzer", "Purchase The Benefactor Schwartzer.", "$80,000");
		nativeItem113.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Schwarzer, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem113.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(80000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Schwartzer", 80000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem113);
		NativeItem nativeItem114 = new NativeItem("Karin Sultan", "Purchase The Karin Sultan.", "$12,000");
		nativeItem114.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sultan, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem114.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(12000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin Sultan", 12000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem114);
		NativeItem nativeItem115 = new NativeItem("Benefactor Surano", "Purchase The Benefactor Surano.", "$110,000");
		nativeItem115.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Surano, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem115.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(110000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Surano", 110000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem115);
		NativeItem nativeItem116 = new NativeItem("Hijak Khamelion", "Purchase The Hijak Khamelion.", "$100,000");
		nativeItem116.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Khamelion, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem116.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(100000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Hijak Khamelion", 100000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem116);
		NativeItem nativeItem117 = new NativeItem("Albany Alpha", "Purchase The Albany Alpha.", "$150,000");
		nativeItem117.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Alpha, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem117.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(150000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Alpha", 150000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem117);
		NativeItem nativeItem118 = new NativeItem("Dinka Jester", "Purchase The Dinka Jester.", "$240,000");
		nativeItem118.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Jester, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem118.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(240000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Jester", 240000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem118);
		NativeItem nativeItem119 = new NativeItem("Dewbauchee Massacro", "Purchase The Dewbauchee Massacro.", "$275,000");
		nativeItem119.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Massacro, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem119.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(275000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dewbauchee Massacro", 275000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem119);
		NativeItem nativeItem120 = new NativeItem("Lampadati Furore GT", "Purchase The Lampadati Furore GT.", "$448,000");
		nativeItem120.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Furoregt, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem120.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(448000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Lampadati Furore GT", 448000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem120);
		NativeItem nativeItem121 = new NativeItem("Dinka Blista Compact", "Purchase The Dinka Blista Compact.", "$42,000");
		nativeItem121.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Blista2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem121.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(42000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Blista Compact", 42000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem121);
		NativeItem nativeItem122 = new NativeItem("Dinka Go Go Monkey Blista", "Purchase The Dinka Go Go Monkey Blista.", "FREE");
		nativeItem122.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Blista3, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem122.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Go Go Monkey Blista", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem122);
		NativeItem nativeItem123 = new NativeItem("Bravado Sprunk Buffalo", "Purchase The Bravado Sprunk Buffalo.", "FREE");
		nativeItem123.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Buffalo3, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem123.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Sprunk Buffalo", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem123);
		NativeItem nativeItem124 = new NativeItem("Dinka Jester (Racecar)", "Purchase The Dinka Jester (Racecar).", "$350,000");
		nativeItem124.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Jester2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem124.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(350000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dinka Jester (Racecar)", 350000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem124);
		NativeItem nativeItem125 = new NativeItem("Dewbauchee Massacro (Racecar)", "Purchase The Dewbauchee Massacro (Racecar).", "$385,000");
		nativeItem125.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Massacro2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem125.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(385000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dewbauchee Massacro (Racecar)", 385000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu8.Add(nativeItem125);
		NativeMenu nativeMenu9 = new NativeMenu("", "Sports Classics", "Browse for Sports Classics.");
		MDPool.Add(nativeMenu9);
		nativeMenu9.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu9.CloseOnInvalidClick = false;
		nativeMenu9.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem9 = new NativeSubmenuItem(nativeMenu9, MainMenu);
		nativeSubmenuItem9.AltTitle = "";
		nativeMenu9.Buttons.Clear();
		InstructionalButton[] array10 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu9.Buttons.Add(array10[0]);
		nativeMenu9.Buttons.Add(array10[1]);
		nativeMenu9.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(8, nativeSubmenuItem9);
		NativeItem nativeItem126 = new NativeItem("Dewbauchee JB 700", "Purchase The Dewbauchee JB 700.", "$350,000");
		nativeItem126.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.JB700, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem126.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(350000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dewbauchee JB 700", 350000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem126);
		NativeItem nativeItem127 = new NativeItem("Albany Manana", "Purchase The Albany Manana.", "$10,000");
		nativeItem127.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Manana, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem127.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(10000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Manana", 10000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem127);
		NativeItem nativeItem128 = new NativeItem("Pegassi Monroe", "Purchase The Pegassi Monroe.", "$490,000");
		nativeItem128.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Monroe, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem128.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(490000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pegassi Monroe", 490000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem128);
		NativeItem nativeItem129 = new NativeItem("Vapid Peyote", "Purchase The Vapid Peyote.", "$38,000");
		nativeItem129.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Peyote, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem129.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(38000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Peyote", 38000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem129);
		NativeItem nativeItem130 = new NativeItem("Grotti Stinger", "Purchase The Grotti Stinger.", "$850,000");
		nativeItem130.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Stinger, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem130.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(850000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Grotti Stinger", 850000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem130);
		NativeItem nativeItem131 = new NativeItem("Grotti Stinger GT", "Purchase The Grotti Stinger GT.", "$875,000");
		nativeItem131.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.StingerGT, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem131.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(875000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Grotti Stinger GT", 875000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem131);
		NativeItem nativeItem132 = new NativeItem("Declasse Tornado", "Purchase The Declasse Tornado.", "$30,000");
		nativeItem132.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Tornado, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem132.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(30000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Tornado", 30000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem132);
		NativeItem nativeItem133 = new NativeItem("Declasse Tornado Convertible", "Purchase The Declasse Tornado Convertible.", "$30,000");
		nativeItem133.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Tornado2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem133.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(30000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Tornado Convertible", 30000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem133);
		NativeItem nativeItem134 = new NativeItem("Truffade Z-Type", "Purchase The Truffade Z-Type.", "$950,000");
		nativeItem134.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.ZType, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem134.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(950000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Truffade Z-Type", 950000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem134);
		NativeItem nativeItem135 = new NativeItem("Albany Roosevelt", "Purchase The Albany Roosevelt.", "$750,000");
		nativeItem135.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.BType, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem135.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(750000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Roosevelt", 750000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem135);
		NativeItem nativeItem136 = new NativeItem("Lampadati Pigalle", "Purchase The Lampadati Pigalle.", "$400,000");
		nativeItem136.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Pigalle, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem136.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(400000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Lampadati Pigalle", 400000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem136);
		NativeItem nativeItem137 = new NativeItem("Invetero Coquette Classic", "Purchase The Invetero Coquette Classic.", "FREE");
		nativeItem137.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Coquette2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem137.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Invetero Coquette Classic", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu9.Add(nativeItem137);
		NativeMenu nativeMenu10 = new NativeMenu("", "Supers", "Browse for Supers.");
		MDPool.Add(nativeMenu10);
		nativeMenu10.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu10.CloseOnInvalidClick = false;
		nativeMenu10.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem10 = new NativeSubmenuItem(nativeMenu10, MainMenu);
		nativeSubmenuItem10.AltTitle = "";
		nativeMenu10.Buttons.Clear();
		InstructionalButton[] array11 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu10.Buttons.Add(array11[0]);
		nativeMenu10.Buttons.Add(array11[1]);
		nativeMenu10.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(9, nativeSubmenuItem10);
		NativeItem nativeItem138 = new NativeItem("Truffade Adder", "Purchase The Truffade Adder.", "$1,000,000");
		nativeItem138.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Adder, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.47685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem138.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(1000000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Truffade Adder", 1000000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem138);
		NativeItem nativeItem139 = new NativeItem("Vapid Bullet", "Purchase The Vapid Bullet.", "$155,000");
		nativeItem139.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bullet, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem139.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(155000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Bullet", 155000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem139);
		NativeItem nativeItem140 = new NativeItem("Grotti Cheetah", "Purchase The Grotti Cheetah.", "$650,000");
		nativeItem140.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Cheetah, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem140.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(650000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Grotti Cheetah", 650000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem140);
		NativeItem nativeItem141 = new NativeItem("Overflod Entity XF", "Purchase The Overflod Entity XF.", "$795,000");
		nativeItem141.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.EntityXF, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem141.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(795000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Overflod Entity XF", 795000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem141);
		NativeItem nativeItem142 = new NativeItem("Pegassi Infernus", "Purchase The Pegassi Infernus.", "$440,000");
		nativeItem142.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Infernus, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem142.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(440000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pegassi Infernus", 440000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem142);
		NativeItem nativeItem143 = new NativeItem("Pegassi Vacca", "Purchase The Pegassi Vacca.", "$240,000");
		nativeItem143.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Vacca, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem143.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(240000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pegassi Vacca", 240000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem143);
		NativeItem nativeItem144 = new NativeItem("Coil Voltic", "Purchase The Coil Voltic.", "$150,000");
		nativeItem144.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Voltic, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem144.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(150000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Coil Voltic", 150000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem144);
		NativeItem nativeItem145 = new NativeItem("Grotti Turismo R", "Purchase The Grotti Turismo R.", "FREE");
		nativeItem145.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Turismor, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem145.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(0) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Grotti Turismo R", 0);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem145);
		NativeItem nativeItem146 = new NativeItem("Pegassi Zentorno", "Purchase The Pegassi Zentorno.", "$725,000");
		nativeItem146.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Zentorno, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem146.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(725000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Pegassi Zentorno", 725000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu10.Add(nativeItem146);
		NativeMenu nativeMenu11 = new NativeMenu("", "SUVS", "Browse for SUVS.");
		MDPool.Add(nativeMenu11);
		nativeMenu11.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu11.CloseOnInvalidClick = false;
		nativeMenu11.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem11 = new NativeSubmenuItem(nativeMenu11, MainMenu);
		nativeSubmenuItem11.AltTitle = "";
		nativeMenu11.Buttons.Clear();
		InstructionalButton[] array12 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu11.Buttons.Add(array12[0]);
		nativeMenu11.Buttons.Add(array12[1]);
		nativeMenu11.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(10, nativeSubmenuItem11);
		NativeItem nativeItem147 = new NativeItem("Gallivanter Baller", "Purchase The Gallivanter Baller.", "$83,000");
		nativeItem147.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Baller, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.67685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem147.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(83000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Gallivanter Baller", 83000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem147);
		NativeItem nativeItem148 = new NativeItem("Gallivanter Baller II", "Purchase The Gallivanter Baller II.", "$90,000");
		nativeItem148.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Baller2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem148.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(90000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Gallivanter Baller II", 90000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem148);
		NativeItem nativeItem149 = new NativeItem("Karin BeeJay XL", "Purchase The Karin BeeJay XL.", "$27,000");
		nativeItem149.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.BJXL, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem149.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(27000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Karin BeeJay XL", 27000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem149);
		NativeItem nativeItem150 = new NativeItem("Albany Cavalcade", "Purchase The Albany Cavalcade.", "$60,000");
		nativeItem150.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Cavalcade, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem150.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(60000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Cavalcade", 60000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem150);
		NativeItem nativeItem151 = new NativeItem("Albany Cavalcade II", "Purchase The Albany Cavalcade II.", "$70,000");
		nativeItem151.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Cavalcade2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem151.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(70000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Albany Cavalcade II", 70000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem151);
		NativeItem nativeItem152 = new NativeItem("Benefactor Dubsta", "Purchase The Benefactor Dubsta.", "$70,000");
		nativeItem152.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dubsta, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem152.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(70000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Dubsta", 70000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem152);
		NativeItem nativeItem153 = new NativeItem("Fathom FQ 2", "Purchase The Fathom FQ 2.", "$50,000");
		nativeItem153.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.FQ2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem153.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(50000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Fathom FQ 2", 50000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem153);
		NativeItem nativeItem154 = new NativeItem("Declasse Granger", "Purchase The Declasse Granger.", "$35,000");
		nativeItem154.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Granger, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem154.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(35000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Declasse Granger", 35000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem154);
		NativeItem nativeItem155 = new NativeItem("Bravado Gresley", "Purchase The Bravado Gresley.", "$29,000");
		nativeItem155.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Gresley, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem155.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(29000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Gresley", 29000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem155);
		NativeItem nativeItem156 = new NativeItem("Emperor Habanero", "Purchase The Emperor Habanero.", "$42,000");
		nativeItem156.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Habanero, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem156.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(42000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Emperor Habanero", 42000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem156);
		NativeItem nativeItem157 = new NativeItem("Dundreary Landstalker", "Purchase The Dundreary Landstalker.", "$58,000");
		nativeItem157.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Landstalker, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem157.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(58000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Dundreary Landstalker", 58000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem157);
		NativeItem nativeItem158 = new NativeItem("Canis Mesa", "Purchase The Canis Mesa.", "$30,000");
		nativeItem158.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Mesa, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem158.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(30000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Canis Mesa", 30000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem158);
		NativeItem nativeItem159 = new NativeItem("Vapid Radius", "Purchase The Vapid Radius.", "$32,000");
		nativeItem159.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Radi, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem159.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(32000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Radius", 32000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem159);
		NativeItem nativeItem160 = new NativeItem("Obey Rocoto", "Purchase The Obey Rocoto.", "$85,000");
		nativeItem160.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Rocoto, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem160.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(85000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Obey Rocoto", 85000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem160);
		NativeItem nativeItem161 = new NativeItem("Canis Seminole", "Purchase The Canis Seminole.", "$30,000");
		nativeItem161.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Seminole, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem161.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(30000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Canis Seminole", 30000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem161);
		NativeItem nativeItem162 = new NativeItem("Benefactor Serrano", "Purchase The Benefactor Serrano.", "$60,000");
		nativeItem162.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Serrano, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem162.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(60000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Serrano", 60000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem162);
		NativeItem nativeItem163 = new NativeItem("Benefactor Dubsta 2", "Purchase The Benefactor Dubsta 2.", "$70,000");
		nativeItem163.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dubsta2, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem163.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(70000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Dubsta 2", 70000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem163);
		NativeItem nativeItem164 = new NativeItem("Enus Huntley S", "Purchase The Enus Huntley S.", "$195,000");
		nativeItem164.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Huntley, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem164.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(195000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Enus Huntley S", 195000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem164);
		NativeItem nativeItem165 = new NativeItem("Benefactor Dubsta 6x6", "Purchase The Benefactor Dubsta 6x6.", "$249,000");
		nativeItem165.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Dubsta3, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem165.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(249000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Benefactor Dubsta 6x6", 249000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu11.Add(nativeItem165);
		NativeMenu nativeMenu12 = new NativeMenu("", "Utility Vehicles", "Browse for Utility Vehicles.");
		MDPool.Add(nativeMenu12);
		nativeMenu12.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu12.CloseOnInvalidClick = false;
		nativeMenu12.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem12 = new NativeSubmenuItem(nativeMenu12, MainMenu);
		nativeSubmenuItem12.AltTitle = "";
		nativeMenu12.Buttons.Clear();
		InstructionalButton[] array13 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu12.Buttons.Add(array13[0]);
		nativeMenu12.Buttons.Add(array13[1]);
		nativeMenu12.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(11, nativeSubmenuItem12);
		NativeItem nativeItem166 = new NativeItem("Caddy (Golf)", "Purchase The Caddy (Golf).", "$15,000");
		nativeItem166.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Caddy, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.67685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem166.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(15000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Caddy (Golf)", 15000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu12.Add(nativeItem166);
		NativeItem nativeItem167 = new NativeItem("Sadler", "Purchase The Sadler.", "$35,000");
		nativeItem167.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Sadler, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem167.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(35000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Sadler", 35000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu12.Add(nativeItem167);
		NativeMenu nativeMenu13 = new NativeMenu("", "Vans", "Browse for Vans.");
		MDPool.Add(nativeMenu13);
		nativeMenu13.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu13.CloseOnInvalidClick = false;
		nativeMenu13.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem13 = new NativeSubmenuItem(nativeMenu13, MainMenu);
		nativeSubmenuItem13.AltTitle = "";
		nativeMenu13.Buttons.Clear();
		InstructionalButton[] array14 = new InstructionalButton[2]
		{
			new InstructionalButton("Purchase Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		nativeMenu13.Buttons.Add(array14[0]);
		nativeMenu13.Buttons.Add(array14[1]);
		nativeMenu13.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
		};
		MainMenu.Add(12, nativeSubmenuItem13);
		NativeItem nativeItem168 = new NativeItem("Bravado Bison", "Purchase The Bravado Bison.", "$30,000");
		nativeItem168.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Bison, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.67685f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem168.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(30000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Bison", 30000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem168);
		NativeItem nativeItem169 = new NativeItem("Vapid Bobcat XL", "Purchase The Vapid Bobcat XL.", "$23,000");
		nativeItem169.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.BobcatXL, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem169.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(23000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Bobcat XL", 23000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem169);
		NativeItem nativeItem170 = new NativeItem("Vapid Minivan", "Purchase The Vapid Minivan.", "$30,000");
		nativeItem170.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Minivan, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem170.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(30000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Minivan", 30000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem170);
		NativeItem nativeItem171 = new NativeItem("Bravado Rumpo", "Purchase The Bravado Rumpo.", "$13,000");
		nativeItem171.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Rumpo, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem171.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(13000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Rumpo", 13000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem171);
		NativeItem nativeItem172 = new NativeItem("Vapid Speedo", "Purchase The Vapid Speedo.", "$25,000");
		nativeItem172.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Speedo, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem172.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(25000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Vapid Speedo", 25000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem172);
		NativeItem nativeItem173 = new NativeItem("BF Surfer", "Purchase The BF Surfer.", "$11,000");
		nativeItem173.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Surfer, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem173.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(11000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("BF Surfer", 11000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem173);
		NativeItem nativeItem174 = new NativeItem("Bravado Youga", "Purchase The Bravado Youga.", "$16,000");
		nativeItem174.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Youga, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem174.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(16000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Youga", 16000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem174);
		NativeItem nativeItem175 = new NativeItem("Bravado Paradise", "Purchase The Bravado Paradise.", "$25,000");
		nativeItem175.Selected += (object sender, SelectedEventArgs e) =>
		{
			if (ShownVehicle != null)
			{
				ShownVehicle.Delete();
				ShownVehicle = null;
			}
			if (ShownVehicle == null)
			{
				ShownVehicle = World.CreateVehicle(VehicleHash.Paradise, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
				ShownVehicle.IsPositionFrozen = true;
				ShownVehicle.IsCollisionEnabled = false;
			}
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
			CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.88325f, -1102.216f, 26.576849f), new Vector3(0f, 0f, 332.41f), 45f);
			CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
			CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
		};
		nativeItem175.Activated += (object sender, EventArgs e) =>
		{
			if (MPCash.PROCESS_TRANSACTION(25000) || CruelMastersOnlineOffline.DEBUG)
			{
				PURCHASE_VEHICLE("Bravado Paradise", 25000);
			}
			else
			{
				Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
			}
		};
		nativeMenu13.Add(nativeItem175);
		MenuOpen = true;
	}

	public static void PURCHASE_VEHICLE(string vehiclestartname, int vehiclecost)
	{
		string text = "";
		text = ONSCREEN_KEYBOARD.GetUserInput("", vehiclestartname, 60);
		if (Function.Call<bool>(Hash.IS_STRING_NULL_OR_EMPTY, text))
		{
			MPCash.ADD_CASH(vehiclecost);
			Notification.Show("Transaction Failed: Invalid Name, Money returned.");
			return;
		}
		if (File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles\\" + text + ".xml"))
		{
			MPCash.ADD_CASH(vehiclecost);
			Notification.Show("Transaction Failed: Name Already Exists, Money returned.");
			return;
		}
		if (CruelMastersOnlineOffline.PlayerVehicle != null)
		{
			CruelMastersOnlineOffline.PlayerVehicle.Delete();
			CruelMastersOnlineOffline.PlayerVehicle = null;
		}
		MPVehicleLoadout.SAVE_VEHICLE(ShownVehicle, "scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", text);
		MPOwnedVehicles.SAVE_PREVIOUS_OWNED_VEHICLE("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml", text);
	}

	public static void DEALERSHIP_SELL_MENU()
	{
		MainMenu.Clear();
		MainMenu.Name = "CURRENT VEHICLES";
		MainMenu.Buttons.Clear();
		InstructionalButton[] array = new InstructionalButton[3]
		{
			new InstructionalButton("", Control.Attack),
			new InstructionalButton("Sell Vehicle", Control.FrontendAccept),
			new InstructionalButton("Back", Control.PhoneCancel)
		};
		MainMenu.Buttons.Add(array[0]);
		MainMenu.Buttons.Add(array[1]);
		MainMenu.Buttons.Add(array[2]);
		MainMenu.NoItemsText = "You Don't Own any Vehicles.";
		ScaledTexture scaledTexture = new ScaledTexture(MainMenu.Banner.Position, new SizeF(MainMenu.Banner.Size.Width, MainMenu.Banner.Size.Height), "shopui_title_premium_deluxe_motorsport", "shopui_title_premium_deluxe_motorsport");
		int num = 0;
		if (Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles").Count() > -1)
		{
			string[] files = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles");
			foreach (string file in files)
			{
				MPOwnedVehicles getcurrentowned = new MPOwnedVehicles();
				getcurrentowned = XMLSerializer.DeserializeXML<MPOwnedVehicles>(file);
				NativeItem OwnedVehicleItem = new NativeItem(getcurrentowned.ownedVehicles[0].VehicleName, "Sell the " + getcurrentowned.ownedVehicles[0].VehicleName + " for $" + (Function.Call<int>(Hash.GET_VEHICLE_MODEL_VALUE, getcurrentowned.ownedVehicles[0].VehicleStats.VehicleHash) / 3).ToString("N0") + ".", "$" + (Function.Call<int>(Hash.GET_VEHICLE_MODEL_VALUE, getcurrentowned.ownedVehicles[0].VehicleStats.VehicleHash) / 3).ToString("N0"));
				OwnedVehicleItem.Selected += (object sender, SelectedEventArgs e) =>
				{
					if (ShownVehicle != null)
					{
						ShownVehicle.Delete();
						ShownVehicle = null;
					}
					if (ShownVehicle == null)
					{
						ShownVehicle = MPOwnedVehicles.GET_VEHICLE_LOADOUT(file, new Vector3(-44.28328f, -1098.583f, 25.42234f), 117.0062f);
						ShownVehicle.IsPositionFrozen = true;
						ShownVehicle.IsCollisionEnabled = false;
					}
					if (CruelMastersOnlineOffline.CutsceneCam2 != null)
					{
						CruelMastersOnlineOffline.CutsceneCam2.Delete();
						CruelMastersOnlineOffline.CutsceneCam2 = null;
					}
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(new Vector3(-46.38325f, -1102.216f, 26.67685f), new Vector3(0f, 0f, 332.41f), 50f);
					CruelMastersOnlineOffline.CutsceneCam2.PointAt(ShownVehicle, new Vector3(1f, 0f, 0f));
					CruelMastersOnlineOffline.CutsceneCam2.Shake(CameraShake.Hand, 0.3f);
					CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 2000, 3, 1);
				};
				OwnedVehicleItem.Activated += (object sender, EventArgs e) =>
				{
					OwnedVehicleItem.Title = "SOLD";
					OwnedVehicleItem.Enabled = false;
					MPCash.ADD_CASH(Function.Call<int>(Hash.GET_VEHICLE_MODEL_VALUE, getcurrentowned.ownedVehicles[0].VehicleStats.VehicleHash) / 3);
					MPVehicleLoadout mPVehicleLoadout = XMLSerializer.DeserializeXML<MPVehicleLoadout>("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml");
					if (mPVehicleLoadout.CurrenVehicleLoadout[0].VehicleName == getcurrentowned.ownedVehicles[0].VehicleName)
					{
						if (File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml"))
						{
							File.Delete("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\CurrentVehicle.xml");
						}
						if (CruelMastersOnlineOffline.PlayerVehicle != null)
						{
							CruelMastersOnlineOffline.PlayerVehicle.Delete();
							CruelMastersOnlineOffline.PlayerVehicle = null;
						}
					}
					File.Delete("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles\\" + getcurrentowned.ownedVehicles[0].VehicleName + ".xml");
					string[] files2 = Directory.GetFiles("scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles");
					foreach (string fileName in files2)
					{
						MPOwnedVehicles mPOwnedVehicles = new MPOwnedVehicles();
						mPOwnedVehicles = XMLSerializer.DeserializeXML<MPOwnedVehicles>(fileName);
						if (mPOwnedVehicles.ownedVehicles[0].VehicleID > 0)
						{
							mPOwnedVehicles.ownedVehicles[0].VehicleID--;
						}
						XMLSerializer.SaveToXML(mPOwnedVehicles, "scripts\\CruelMastersOnlineOfflineAssets\\Vehicles\\Owned Vehicles\\" + mPOwnedVehicles.ownedVehicles[0].VehicleName + ".xml");
					}
					Notification.Show(getcurrentowned.ownedVehicles[0].VehicleName + " Sold for $" + (Function.Call<int>(Hash.GET_VEHICLE_MODEL_VALUE, getcurrentowned.ownedVehicles[0].VehicleStats.VehicleHash) / 3).ToString("N0") + ".", blinking: true);
					MainMenu.Visible = false;
				};
				MainMenu.Add(num, OwnedVehicleItem);
				num++;
			}
		}
		MenuOpen = true;
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
			MDPool.Process();
		}
		if (!CruelMastersOnlineOffline.OnMission)
		{
			if (SimeonDealershipBlip == null)
			{
				SimeonDealershipBlip = World.CreateBlip(new Vector3(-47.86579f, -1097.077f, 26.42234f));
			}
			else
			{
				SimeonDealershipBlip.Sprite = BlipSprite.SimeonCarShowroom;
				SimeonDealershipBlip.Color = BlipColor.White;
				SimeonDealershipBlip.Name = "Dealership";
				SimeonDealershipBlip.Alpha = 255;
				SimeonDealershipBlip.Priority = 5;
				SimeonDealershipBlip.IsShortRange = true;
			}
			if (Game.Player.Character.Position.DistanceTo(new Vector3(-47.82288f, -1096.888f, 26.42235f)) < 10f && !MenuOpen)
			{
				World.DrawMarker(MarkerType.Cylinder, new Vector3(-47.82288f, -1096.888f, 24.82235f), Vector3.Zero, Vector3.Zero, new Vector3(1.5f, 1.5f, 1.5f), Color.Aqua);
			}
			if (Game.Player.Character.Position.DistanceTo(new Vector3(-47.82288f, -1096.888f, 26.42235f)) < 1.3f)
			{
				GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to browse the dealership.");
				if (Game.IsControlJustPressed(Control.Context) && !MDPool.AreAnyVisible)
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					while (CruelMastersOnlineOffline.CutsceneCam == null)
					{
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(-47.39991f, -1103.096f, 26.33568f), new Vector3(0f, 0f, 328.2f), 30f);
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Shake(CameraShake.Hand, 0.3f);
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					Vehicle[] nearbyVehicles = World.GetNearbyVehicles(new Vector3(-47.82288f, -1096.888f, 26.42235f), 10f);
					Vehicle[] array = nearbyVehicles;
					foreach (Vehicle vehicle in array)
					{
						if (vehicle != null)
						{
							vehicle.Delete();
						}
					}
					Game.Player.Character.Position = new Vector3(-47.57949f, -1096.614f, 25.42235f);
					Game.Player.Character.Heading = 160.7511f;
					Game.Player.CanControlCharacter = false;
					DEALERSHIP_MENU();
					MainMenu.Visible = !MainMenu.Visible;
				}
			}
			if (Game.Player.Character.Position.DistanceTo(new Vector3(-33.8319f, -1098.543f, 26.42236f)) < 10f && !MenuOpen)
			{
				World.DrawMarker(MarkerType.Cylinder, new Vector3(-33.8319f, -1098.543f, 24.82236f), Vector3.Zero, Vector3.Zero, new Vector3(1.5f, 1.5f, 1.5f), Color.ForestGreen);
			}
			if (Game.Player.Character.Position.DistanceTo(new Vector3(-33.8319f, -1098.543f, 26.42236f)) < 1.3f)
			{
				GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to sell a owned vehicle.");
				if (Game.IsControlJustPressed(Control.Context) && !MDPool.AreAnyVisible)
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					while (CruelMastersOnlineOffline.CutsceneCam == null)
					{
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(-47.39991f, -1103.096f, 26.33568f), new Vector3(0f, 0f, 328.2f), 30f);
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Shake(CameraShake.Hand, 0.3f);
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					Vehicle[] nearbyVehicles2 = World.GetNearbyVehicles(new Vector3(-47.82288f, -1096.888f, 26.42235f), 10f);
					Vehicle[] array2 = nearbyVehicles2;
					foreach (Vehicle vehicle2 in array2)
					{
						if (vehicle2 != null)
						{
							vehicle2.Delete();
						}
					}
					Game.Player.Character.Position = new Vector3(-33.76583f, -1098.598f, 25.42233f);
					Game.Player.Character.Heading = 98.32634f;
					Game.Player.CanControlCharacter = false;
					DEALERSHIP_SELL_MENU();
					MainMenu.Visible = !MainMenu.Visible;
				}
			}
			if (MenuOpen && !MDPool.AreAnyVisible)
			{
				Mobile_Phone.CAN_OPEN_PHONE = true;
				MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
				MPCash.CAN_SEE_CASH = true;
				MPRank.CAN_SEE_RANK_BAR = true;
				MPPlayerList.CAN_SHOW_LIST = true;
				if (ShownVehicle != null)
				{
					ShownVehicle.Delete();
					ShownVehicle = null;
				}
				if (CruelMastersOnlineOffline.CutsceneCam != null)
				{
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
				}
				World.RenderingCamera = null;
				Cameras.RESET_GAMEPLAY_CAM();
				Game.Player.CanControlCharacter = true;
				MenuOpen = false;
			}
		}
		else if (SimeonDealershipBlip != null)
		{
			SimeonDealershipBlip.Alpha = 0;
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (SimeonDealershipBlip != null)
		{
			SimeonDealershipBlip.Delete();
		}
		if (ShownVehicle != null)
		{
			ShownVehicle.Delete();
		}
	}

	public static void SET_CAM_NORMAL()
	{
		if (CruelMastersOnlineOffline.CutsceneCam != null)
		{
			CruelMastersOnlineOffline.CutsceneCam.StopPointing();
			CruelMastersOnlineOffline.CutsceneCam.Detach();
			CruelMastersOnlineOffline.CutsceneCam.Position = new Vector3(-47.39991f, -1103.096f, 26.33568f);
			CruelMastersOnlineOffline.CutsceneCam.Rotation = new Vector3(0f, 0f, 328.2f);
			CruelMastersOnlineOffline.CutsceneCam.FieldOfView = 30f;
			CruelMastersOnlineOffline.CutsceneCam.Shake(CameraShake.Hand, 0.3f);
			if (CruelMastersOnlineOffline.CutsceneCam2 != null)
			{
				CruelMastersOnlineOffline.CutsceneCam2.InterpTo(CruelMastersOnlineOffline.CutsceneCam, 2000, 3, 1);
				CruelMastersOnlineOffline.CutsceneCam2.Delete();
				CruelMastersOnlineOffline.CutsceneCam2 = null;
			}
		}
	}
}
