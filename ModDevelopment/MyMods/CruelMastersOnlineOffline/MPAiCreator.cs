using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;
using LemonUI.Scaleform;

namespace CruelMastersOnlineOffline;

internal class MPAiCreator : Script
{
	public static ObjectPool MenuPool = new ObjectPool();

	public static NativeMenu CharCreator;

	public static Blip AiCreatorBlip;

	public static string MPName = "";

	public static int MPHairColor = 0;

	public static int MPMask = 0;

	public static int MPEyeColor = 0;

	public static int MPMakeupColor = 0;

	public static int MPLipstickColor = 0;

	public static int MPGender = 0;

	public static int TestCutsceneAnim = 0;

	public static int Menu_Switch = 0;

	public static int ScaleID;

	public static int ScaleID2;

	public static int ScaleID3;

	public static int ScaleID4;

	public static int ScaleID5;

	public static int ScaleID6;

	public static int RenderID;

	public static int RenderID2;

	public static int RenderID3;

	public static int RenderID4;

	public static int RenderID5;

	public static int RenderID6;

	public static bool CloseApparelMenu = true;

	public static string CurrentlyEditingAiName = "Ai Friend";

	public static bool ReEditingAi = false;

	public static AIInfo MyAiInfo;

	public static MPCustomOutfits MyCustomOutfit;

	public static Ped[] Companions = new Ped[7];

	public static int vehpascount = 1;

	public static int GroupCount = 0;

	public MPAiCreator()
	{
		Tick += onTick;
		Aborted += onShutdown;
		SETUP_CHAR_CREATOR_MENU();
	}

	public static void SETUP_CHAR_CREATOR_MENU()
	{
		CharCreator = new NativeMenu("Character Creator", "New Character");
		CharCreator.Banner.Color = Color.Aqua;
		CharCreator.MouseBehavior = MenuMouseBehavior.Disabled;
		CharCreator.Buttons.Clear();
		InstructionalButton[] array = new InstructionalButton[3]
		{
			new InstructionalButton("Cancel", Control.VehicleDuck),
			new InstructionalButton("Back", Control.PhoneCancel),
			new InstructionalButton("Select", Control.FrontendAccept)
		};
		CharCreator.Buttons.Add(array[0]);
		CharCreator.Buttons.Add(array[1]);
		CharCreator.Buttons.Add(array[2]);
		MenuPool.Add(CharCreator);
		NativeListItem<string> Sexbutton = new NativeListItem<string>("Sex", "Select the gender of your Character.~n~(WARNING - This WILL reset your characters current features when changed.)", "Male", "Female");
		CharCreator.Add(Sexbutton);
		NativeMenu nativeMenu = new NativeMenu("Character Creator", "Heritage", "Select to choose your parents.");
		MenuPool.Add(nativeMenu);
		NativeSubmenuItem nativeSubmenuItem = new NativeSubmenuItem(nativeMenu, CharCreator);
		nativeSubmenuItem.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem);
		nativeSubmenuItem.Activated += (object sender, EventArgs e) =>
		{
			while (CruelMastersOnlineOffline.CutsceneCam2 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
				Script.Wait(0);
			}
			Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam, true);
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
			CruelMastersOnlineOffline.CutsceneCam2.FieldOfView = 43f;
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
		};
		nativeSubmenuItem.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.CutsceneCam2.InterpTo(CruelMastersOnlineOffline.CutsceneCam, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			CruelMastersOnlineOffline.CutsceneCam2.Delete();
			CruelMastersOnlineOffline.CutsceneCam2 = null;
		};
		NativeListItem<int> FaceList = new NativeListItem<int>("Face", "", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45);
		NativeListItem<int> ParentList = new NativeListItem<int>("Parent", "", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45);
		NativeListItem<int> STList = new NativeListItem<int>("Skin Tone", "", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);
		nativeMenu.Add(FaceList);
		nativeMenu.Add(ParentList);
		nativeMenu.Add(STList);
		FaceList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, FaceList.SelectedItem, ParentList.SelectedItem, 0, STList.SelectedItem, 0, 0, 0f, 0f, 0f, false);
		};
		ParentList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, FaceList.SelectedItem, ParentList.SelectedItem, 0, STList.SelectedItem, 0, 0, 0f, 0f, 0f, false);
		};
		STList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, FaceList.SelectedItem, ParentList.SelectedItem, 0, STList.SelectedItem, 0, 0, 0f, 0f, 0f, false);
		};
		NativeMenu nativeMenu2 = new NativeMenu("Character Creator", "Features", "Select to alter your facial features.");
		MenuPool.Add(nativeMenu2);
		nativeMenu2.MouseBehavior = MenuMouseBehavior.Movement;
		nativeMenu2.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem2 = new NativeSubmenuItem(nativeMenu2, CharCreator);
		nativeSubmenuItem2.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem2);
		nativeSubmenuItem2.Activated += (object sender, EventArgs e) =>
		{
			while (CruelMastersOnlineOffline.CutsceneCam2 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
				Script.Wait(0);
			}
			Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam, true);
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
			CruelMastersOnlineOffline.CutsceneCam2.FieldOfView = 43f;
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
		};
		nativeSubmenuItem2.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.CutsceneCam2.InterpTo(CruelMastersOnlineOffline.CutsceneCam, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			CruelMastersOnlineOffline.CutsceneCam2.Delete();
			CruelMastersOnlineOffline.CutsceneCam2 = null;
		};
		NativeListItem<int> HairCList = new NativeListItem<int>("Hair Color", "Make changes to your Appearance.");
		for (int num = 0; num < Function.Call<int>(Hash.GET_NUM_PED_HAIR_TINTS); num++)
		{
			HairCList.Add(num);
		}
		NativeListItem<int> EyeBrowList = new NativeListItem<int>("Eyebrows", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 2); num++)
		{
			EyeBrowList.Add(num);
		}
		NativeListItem<int> BrowList = new NativeListItem<int>("Brow", "Make changes to your physical features.", -1);
		int iVar0;
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 2); iVar0++)
		{
			BrowList.Add(iVar0);
		}
		nativeMenu2.Add(BrowList);
		NativeGridPanel BrowPanel = new NativeGridPanel();
		BrowPanel.LabelLeft = "In";
		BrowPanel.LabelTop = "Up";
		BrowPanel.LabelRight = "Out";
		BrowPanel.LabelBottom = "Down";
		BrowList.Panel = BrowPanel;
		BrowList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, BrowList.SelectedItem, 1f);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			EyeBrowList.SelectedItem = BrowList.SelectedItem;
		};
		BrowPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 6, BrowPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 7, BrowPanel.X * 2f - 1f);
		};
		NativeItem nativeItem = new NativeItem("Eyes", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem);
		NativeGridPanel EyePanel = new NativeGridPanel();
		EyePanel.LabelLeft = "Wide";
		EyePanel.LabelRight = "Squint";
		EyePanel.Style = GridStyle.Row;
		nativeItem.Panel = EyePanel;
		EyePanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 11, EyePanel.X * 2f - 1f);
		};
		NativeItem nativeItem2 = new NativeItem("Nose", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem2);
		NativeGridPanel NosePanel = new NativeGridPanel();
		NosePanel.LabelLeft = "Narrow";
		NosePanel.LabelTop = "Up";
		NosePanel.LabelRight = "Wide";
		NosePanel.LabelBottom = "Down";
		nativeItem2.Panel = NosePanel;
		NosePanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 0, NosePanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 1, NosePanel.Y * 2f - 1f);
		};
		NativeItem nativeItem3 = new NativeItem("Nose Profile", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem3);
		NativeGridPanel NosePPanel = new NativeGridPanel();
		NosePPanel.LabelLeft = "Short";
		NosePPanel.LabelTop = "Crooked";
		NosePPanel.LabelRight = "Long";
		NosePPanel.LabelBottom = "Curved";
		nativeItem3.Panel = NosePPanel;
		NosePPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 2, NosePPanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 3, NosePPanel.Y * 2f - 1f);
		};
		NativeItem nativeItem4 = new NativeItem("Nose Tip", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem4);
		NativeGridPanel NoseTPanel = new NativeGridPanel();
		NoseTPanel.LabelLeft = "Broken Left";
		NoseTPanel.LabelTop = "Tip Up";
		NoseTPanel.LabelRight = "Broken Right";
		NoseTPanel.LabelBottom = "Tip Down";
		nativeItem4.Panel = NoseTPanel;
		NoseTPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 4, NoseTPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 5, NoseTPanel.X * 2f - 1f);
		};
		NativeItem nativeItem5 = new NativeItem("Cheekbones", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem5);
		NativeGridPanel CheekBPanel = new NativeGridPanel();
		CheekBPanel.LabelLeft = "In";
		CheekBPanel.LabelTop = "Up";
		CheekBPanel.LabelRight = "Out";
		CheekBPanel.LabelBottom = "Down";
		nativeItem5.Panel = CheekBPanel;
		CheekBPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 8, CheekBPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 9, CheekBPanel.X * 2f - 1f);
		};
		NativeItem nativeItem6 = new NativeItem("Cheeks", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem6);
		NativeGridPanel CheeksPanel = new NativeGridPanel();
		CheeksPanel.LabelLeft = "Puffed";
		CheeksPanel.LabelRight = "Gaunt";
		CheeksPanel.Style = GridStyle.Row;
		nativeItem6.Panel = CheeksPanel;
		CheeksPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 10, CheeksPanel.X * 2f - 1f);
		};
		NativeItem nativeItem7 = new NativeItem("Lips", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem7);
		NativeGridPanel LipsPanel = new NativeGridPanel();
		LipsPanel.LabelLeft = "Fat";
		LipsPanel.LabelRight = "Thin";
		LipsPanel.Style = GridStyle.Row;
		nativeItem7.Panel = LipsPanel;
		LipsPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 12, LipsPanel.X * 2f - 1f);
		};
		NativeItem nativeItem8 = new NativeItem("Jaw", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem8);
		NativeGridPanel JawPanel = new NativeGridPanel();
		JawPanel.LabelLeft = "Narrow";
		JawPanel.LabelTop = "Round";
		JawPanel.LabelRight = "Wide";
		JawPanel.LabelBottom = "Squared";
		nativeItem8.Panel = JawPanel;
		JawPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 13, JawPanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 14, JawPanel.Y * 2f - 1f);
		};
		NativeItem nativeItem9 = new NativeItem("Chin Profile", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem9);
		NativeGridPanel ChinPPanel = new NativeGridPanel();
		ChinPPanel.LabelLeft = "In";
		ChinPPanel.LabelTop = "Up";
		ChinPPanel.LabelRight = "Out";
		ChinPPanel.LabelBottom = "Down";
		nativeItem9.Panel = ChinPPanel;
		ChinPPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 15, ChinPPanel.Y * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 16, ChinPPanel.X * 2f - 1f);
		};
		NativeItem nativeItem10 = new NativeItem("Chin Shape", "Make changes to your physical features.");
		nativeMenu2.Add(nativeItem10);
		NativeGridPanel ChinSPanel = new NativeGridPanel();
		ChinSPanel.LabelLeft = "Pointed";
		ChinSPanel.LabelTop = "Rounded";
		ChinSPanel.LabelRight = "Square";
		ChinSPanel.LabelBottom = "Bum";
		nativeItem10.Panel = ChinSPanel;
		ChinSPanel.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 17, ChinSPanel.X * 2f - 1f);
			Function.Call(Hash.SET_PED_MICRO_MORPH, Game.Player.Character, 18, ChinSPanel.Y * 2f - 1f);
		};
		NativeMenu nativeMenu3 = new NativeMenu("Character Creator", "Appearance", "Select to change your Appearance.");
		MenuPool.Add(nativeMenu3);
		nativeMenu3.MouseBehavior = MenuMouseBehavior.Movement;
		nativeMenu3.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem3 = new NativeSubmenuItem(nativeMenu3, CharCreator);
		nativeSubmenuItem3.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem3);
		nativeSubmenuItem3.Activated += (object sender, EventArgs e) =>
		{
			while (CruelMastersOnlineOffline.CutsceneCam2 == null)
			{
				CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
				Script.Wait(0);
			}
			Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam, true);
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
			CruelMastersOnlineOffline.CutsceneCam2.FieldOfView = 43f;
			CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
		};
		nativeSubmenuItem3.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			CruelMastersOnlineOffline.CutsceneCam2.InterpTo(CruelMastersOnlineOffline.CutsceneCam, 200, 0, 0);
			Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
			CruelMastersOnlineOffline.CutsceneCam2.Delete();
			CruelMastersOnlineOffline.CutsceneCam2 = null;
		};
		NativeListItem<int> HairList = new NativeListItem<int>("Hair", "Make changes to your Appearance.");
		for (int num2 = 0; num2 < 23; num2++)
		{
			HairList.Add(num2);
		}
		nativeMenu3.Add(HairList);
		nativeMenu3.Add(HairCList);
		MPHairColor = 0;
		HairList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 2, HairList.SelectedItem, 0, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
		};
		HairCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HAIR_TINT, Game.Player.Character, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			MPHairColor = HairCList.SelectedItem;
		};
		HairList.GoRight();
		HairList.GoLeft();
		HairList.Enabled = true;
		HairCList.GoRight();
		HairCList.GoLeft();
		HairCList.Enabled = true;
		nativeMenu3.Add(EyeBrowList);
		NativeGridPanel Opac2 = new NativeGridPanel();
		Opac2.LabelLeft = "0%";
		Opac2.LabelRight = "100%";
		Opac2.Style = GridStyle.Row;
		EyeBrowList.Panel = Opac2;
		PedOutfit.OverlayPart[2] = -1;
		PedOutfit.OpacityPart[2] = 0f;
		EyeBrowList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, EyeBrowList.SelectedItem, Opac2.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[2] = EyeBrowList.SelectedItem;
			PedOutfit.OpacityPart[2] = Opac2.X;
		};
		Opac2.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 2, EyeBrowList.SelectedItem, Opac2.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 2, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[2] = EyeBrowList.SelectedItem;
			PedOutfit.OpacityPart[2] = Opac2.X;
		};
		EyeBrowList.GoRight();
		EyeBrowList.GoLeft();
		EyeBrowList.Enabled = true;
		NativeListItem<int> FacialHairList = new NativeListItem<int>("Facial Hair", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 1); num++)
		{
			FacialHairList.Add(num);
		}
		nativeMenu3.Add(FacialHairList);
		NativeGridPanel Opac3 = new NativeGridPanel();
		Opac3.LabelLeft = "0%";
		Opac3.LabelRight = "100%";
		Opac3.Style = GridStyle.Row;
		FacialHairList.Panel = Opac3;
		PedOutfit.OverlayPart[1] = -1;
		PedOutfit.OpacityPart[1] = 0f;
		FacialHairList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 1, FacialHairList.SelectedItem, Opac3.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[1] = FacialHairList.SelectedItem;
			PedOutfit.OpacityPart[1] = Opac3.X;
		};
		Opac3.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 1, FacialHairList.SelectedItem, Opac3.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 1, 1, HairCList.SelectedItem, 0);
			PedOutfit.OverlayPart[1] = FacialHairList.SelectedItem;
			PedOutfit.OpacityPart[1] = Opac3.X;
		};
		FacialHairList.GoRight();
		FacialHairList.GoLeft();
		FacialHairList.Enabled = true;
		NativeListItem<int> SkinBlemList = new NativeListItem<int>("Skin Blemishes", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 0); num++)
		{
			SkinBlemList.Add(num);
		}
		nativeMenu3.Add(SkinBlemList);
		NativeGridPanel Opac4 = new NativeGridPanel();
		Opac4.LabelLeft = "0%";
		Opac4.LabelRight = "100%";
		Opac4.Style = GridStyle.Row;
		SkinBlemList.Panel = Opac4;
		SkinBlemList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 0, SkinBlemList.SelectedItem, Opac4.X);
			PedOutfit.OverlayPart[0] = SkinBlemList.SelectedItem;
			PedOutfit.OpacityPart[0] = Opac4.X;
		};
		Opac4.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 0, SkinBlemList.SelectedItem, Opac4.X);
			PedOutfit.OverlayPart[0] = SkinBlemList.SelectedItem;
			PedOutfit.OpacityPart[0] = Opac4.X;
		};
		SkinBlemList.GoRight();
		SkinBlemList.GoLeft();
		SkinBlemList.Enabled = true;
		NativeListItem<int> SkinAgeList = new NativeListItem<int>("Skin Aging", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 3); num++)
		{
			SkinAgeList.Add(num);
		}
		nativeMenu3.Add(SkinAgeList);
		NativeGridPanel Opac5 = new NativeGridPanel();
		Opac5.LabelLeft = "0%";
		Opac5.LabelRight = "100%";
		Opac5.Style = GridStyle.Row;
		SkinAgeList.Panel = Opac5;
		SkinAgeList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 3, SkinAgeList.SelectedItem, Opac5.X);
			PedOutfit.OverlayPart[3] = SkinAgeList.SelectedItem;
			PedOutfit.OpacityPart[3] = Opac5.X;
		};
		Opac5.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 3, SkinAgeList.SelectedItem, Opac5.X);
			PedOutfit.OverlayPart[3] = SkinAgeList.SelectedItem;
			PedOutfit.OpacityPart[3] = Opac5.X;
		};
		SkinAgeList.GoRight();
		SkinAgeList.GoLeft();
		SkinAgeList.Enabled = true;
		NativeListItem<int> SkinCompList = new NativeListItem<int>("Skin Complexion", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 6); num++)
		{
			SkinCompList.Add(num);
		}
		nativeMenu3.Add(SkinCompList);
		NativeGridPanel Opac6 = new NativeGridPanel();
		Opac6.LabelLeft = "0%";
		Opac6.LabelRight = "100%";
		Opac6.Style = GridStyle.Row;
		SkinCompList.Panel = Opac6;
		SkinCompList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 6, SkinCompList.SelectedItem, Opac6.X);
			PedOutfit.OverlayPart[6] = SkinCompList.SelectedItem;
			PedOutfit.OpacityPart[6] = Opac6.X;
		};
		Opac6.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 6, SkinCompList.SelectedItem, Opac6.X);
			PedOutfit.OverlayPart[6] = SkinCompList.SelectedItem;
			PedOutfit.OpacityPart[6] = Opac6.X;
		};
		SkinCompList.GoRight();
		SkinCompList.GoLeft();
		SkinCompList.Enabled = true;
		NativeListItem<int> MAFList = new NativeListItem<int>("Moles & Freckles", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 9); num++)
		{
			MAFList.Add(num);
		}
		nativeMenu3.Add(MAFList);
		NativeGridPanel Opac9 = new NativeGridPanel();
		Opac9.LabelLeft = "0%";
		Opac9.LabelRight = "100%";
		Opac9.Style = GridStyle.Row;
		MAFList.Panel = Opac9;
		MAFList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 9, MAFList.SelectedItem, Opac9.X);
			PedOutfit.OverlayPart[9] = MAFList.SelectedItem;
			PedOutfit.OpacityPart[9] = Opac9.X;
		};
		Opac9.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 9, MAFList.SelectedItem, Opac9.X);
			PedOutfit.OverlayPart[9] = MAFList.SelectedItem;
			PedOutfit.OpacityPart[9] = Opac9.X;
		};
		MAFList.GoRight();
		MAFList.GoLeft();
		MAFList.Enabled = true;
		NativeListItem<int> SDList = new NativeListItem<int>("Skin Damage", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 7); num++)
		{
			SDList.Add(num);
		}
		nativeMenu3.Add(SDList);
		NativeGridPanel Opac10 = new NativeGridPanel();
		Opac10.LabelLeft = "0%";
		Opac10.LabelRight = "100%";
		Opac10.Style = GridStyle.Row;
		SDList.Panel = Opac10;
		SDList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 7, SDList.SelectedItem, Opac10.X);
			PedOutfit.OverlayPart[7] = SDList.SelectedItem;
			PedOutfit.OpacityPart[7] = Opac10.X;
		};
		Opac10.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 7, SDList.SelectedItem, Opac10.X);
			PedOutfit.OverlayPart[7] = SDList.SelectedItem;
			PedOutfit.OpacityPart[7] = Opac10.X;
		};
		SDList.GoRight();
		SDList.GoLeft();
		SDList.Enabled = true;
		NativeListItem<int> EyeCList = new NativeListItem<int>("Eye Color", "Make changes to your Appearance.");
		for (int num = 0; num < 32; num++)
		{
			EyeCList.Add(num);
		}
		nativeMenu3.Add(EyeCList);
		EyeCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_HEAD_BLEND_EYE_COLOR, Game.Player.Character, EyeCList.SelectedItem);
			MPEyeColor = EyeCList.SelectedItem;
		};
		EyeCList.GoRight();
		EyeCList.GoLeft();
		EyeCList.Enabled = true;
		NativeListItem<int> EyeMList = new NativeListItem<int>("Eye Makeup", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 4); num++)
		{
			EyeMList.Add(num);
		}
		nativeMenu3.Add(EyeMList);
		NativeGridPanel Opac11 = new NativeGridPanel();
		Opac11.LabelLeft = "0%";
		Opac11.LabelRight = "100%";
		Opac11.Style = GridStyle.Row;
		EyeMList.Panel = Opac11;
		EyeMList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		Opac11.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		EyeMList.GoRight();
		EyeMList.GoLeft();
		EyeMList.Enabled = true;
		NativeListItem<int> BlushList = new NativeListItem<int>("Blush", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 5); num++)
		{
			BlushList.Add(num);
		}
		nativeMenu3.Add(BlushList);
		NativeGridPanel Opac12 = new NativeGridPanel();
		Opac12.LabelLeft = "0%";
		Opac12.LabelRight = "100%";
		Opac12.Style = GridStyle.Row;
		BlushList.Panel = Opac12;
		BlushList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac12.X);
			PedOutfit.OverlayPart[5] = BlushList.SelectedItem;
			PedOutfit.OpacityPart[5] = Opac12.X;
		};
		Opac12.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac12.X);
			PedOutfit.OverlayPart[5] = BlushList.SelectedItem;
			PedOutfit.OpacityPart[5] = Opac12.X;
		};
		BlushList.GoRight();
		BlushList.GoLeft();
		BlushList.Enabled = true;
		NativeListItem<int> MakeupCList = new NativeListItem<int>("Makeup Color", "Make changes to your Appearance.");
		for (int num = 0; num < Function.Call<int>(Hash.GET_NUM_PED_MAKEUP_TINTS); num++)
		{
			MakeupCList.Add(num);
		}
		nativeMenu3.Add(MakeupCList);
		EyeMList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 4, 1, MakeupCList.SelectedItem, 0);
			MPMakeupColor = MakeupCList.SelectedItem;
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		BlushList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 5, BlushList.SelectedItem, Opac12.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 5, 1, MakeupCList.SelectedItem, 0);
			PedOutfit.OverlayPart[5] = BlushList.SelectedItem;
			PedOutfit.OpacityPart[5] = Opac12.X;
		};
		MakeupCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 4, EyeMList.SelectedItem, Opac11.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 4, 1, MakeupCList.SelectedItem, 0);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 5, 1, MakeupCList.SelectedItem, 0);
			MPMakeupColor = MakeupCList.SelectedItem;
			PedOutfit.OverlayPart[4] = EyeMList.SelectedItem;
			PedOutfit.OpacityPart[4] = Opac11.X;
		};
		EyeMList.GoRight();
		EyeMList.GoLeft();
		EyeMList.Enabled = true;
		BlushList.GoRight();
		BlushList.GoLeft();
		BlushList.Enabled = true;
		MakeupCList.GoRight();
		MakeupCList.GoLeft();
		MakeupCList.Enabled = true;
		NativeListItem<int> LipstickList = new NativeListItem<int>("Lipstick", "Make changes to your Appearance.", -1);
		for (int num = 0; num < Function.Call<int>(Hash.GET_PED_HEAD_OVERLAY_NUM, 8); num++)
		{
			LipstickList.Add(num);
		}
		nativeMenu3.Add(LipstickList);
		NativeGridPanel Opac13 = new NativeGridPanel();
		Opac13.LabelLeft = "0%";
		Opac13.LabelRight = "100%";
		Opac13.Style = GridStyle.Row;
		LipstickList.Panel = Opac13;
		LipstickList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		Opac13.ValuesChanged += (object sender, GridValueChangedArgs e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		LipstickList.GoRight();
		LipstickList.GoLeft();
		LipstickList.Enabled = true;
		NativeListItem<int> LipstickCList = new NativeListItem<int>("Lipstick Color", "Make changes to your Appearance.");
		for (int num = 0; num < Function.Call<int>(Hash.GET_NUM_PED_MAKEUP_TINTS); num++)
		{
			LipstickCList.Add(num);
		}
		nativeMenu3.Add(LipstickCList);
		LipstickList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 8, 1, LipstickCList.SelectedItem, 0);
			MPLipstickColor = LipstickCList.SelectedItem;
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		LipstickCList.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, 8, LipstickList.SelectedItem, Opac13.X);
			Function.Call(Hash.SET_PED_HEAD_OVERLAY_TINT, Game.Player.Character, 8, 1, LipstickCList.SelectedItem, 0);
			MPLipstickColor = LipstickCList.SelectedItem;
			PedOutfit.OverlayPart[8] = LipstickList.SelectedItem;
			PedOutfit.OpacityPart[8] = Opac13.X;
		};
		LipstickList.GoRight();
		LipstickList.GoLeft();
		LipstickList.Enabled = true;
		LipstickCList.GoRight();
		LipstickCList.GoLeft();
		LipstickCList.Enabled = true;
		NativeMenu nativeMenu4 = new NativeMenu("Character Creator", "Apparel", "Select to change your Apparel.");
		MenuPool.Add(nativeMenu4);
		NativeSubmenuItem nativeSubmenuItem4 = new NativeSubmenuItem(nativeMenu4, CharCreator);
		nativeSubmenuItem4.AltTitle = "";
		CharCreator.Add(nativeSubmenuItem4);
		NativeListItem<int> GlassesList = new NativeListItem<int>("Glasses", "Make changes to your Apparel.");
		NativeListItem<int> nativeListItem = new NativeListItem<int>("Glasses Variation", "Make changes to your Apparel.", -1);
		nativeSubmenuItem4.Activated += (object sender, EventArgs e) =>
		{
			Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_intro", 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
			GlassesList.Clear();
			if (Game.Player.Character.Gender == Gender.Male)
			{
				for (int i = -1; i < 40; i++)
				{
					GlassesList.Add(i + 1, i);
				}
			}
			else
			{
				for (int j = -1; j < 42; j++)
				{
					GlassesList.Add(j + 1, j);
				}
			}
			GlassesList.GoRight();
			GlassesList.GoLeft();
			GlassesList.Enabled = true;
		};
		NativeMenu nativeMenu5 = new NativeMenu("", "Body Type", "Browse for a Body Type.");
		MenuPool.Add(nativeMenu5);
		nativeMenu5.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu5.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem5 = new NativeSubmenuItem(nativeMenu5, nativeMenu4);
		nativeSubmenuItem5.AltTitle = "";
		nativeMenu4.Add(0, nativeSubmenuItem5);
		nativeMenu5.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.1f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu5.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> TorsoCompItem = new NativeListItem<int>("Component", "Select a Component.");
		TorsoCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 3); iVar0++)
		{
			TorsoCompItem.Add(iVar0 + 1, iVar0);
		}
		TorsoCompItem.GoRight();
		TorsoCompItem.GoLeft();
		TorsoCompItem.Enabled = true;
		nativeMenu5.Add(TorsoCompItem);
		NativeListItem<int> TorsoCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		TorsoCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 3, 0); iVar0++)
		{
			TorsoCompVarItem.Add(iVar0, iVar0);
		}
		TorsoCompVarItem.GoRight();
		TorsoCompVarItem.GoLeft();
		TorsoCompVarItem.Enabled = true;
		nativeMenu5.Add(TorsoCompVarItem);
		TorsoCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			TorsoCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 3, TorsoCompItem.SelectedItem); iVar0++)
			{
				TorsoCompVarItem.Add(iVar0, iVar0);
			}
			TorsoCompVarItem.GoRight();
			TorsoCompVarItem.GoLeft();
			TorsoCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 3, TorsoCompItem.SelectedItem, 0, 2);
		};
		TorsoCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 3, TorsoCompItem.SelectedItem, TorsoCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu6 = new NativeMenu("", "Pants", "Browse for some Pants.");
		MenuPool.Add(nativeMenu6);
		nativeMenu6.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu6.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem6 = new NativeSubmenuItem(nativeMenu6, nativeMenu4);
		nativeSubmenuItem6.AltTitle = "";
		nativeMenu4.Add(1, nativeSubmenuItem6);
		nativeMenu6.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, -0.2f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -0.4f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 40f);
		};
		nativeMenu6.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> PantsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		PantsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 4); iVar0++)
		{
			PantsCompItem.Add(iVar0 + 1, iVar0);
		}
		PantsCompItem.GoRight();
		PantsCompItem.GoLeft();
		PantsCompItem.Enabled = true;
		nativeMenu6.Add(PantsCompItem);
		NativeListItem<int> PantsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		PantsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 4, 0); iVar0++)
		{
			PantsCompVarItem.Add(iVar0, iVar0);
		}
		PantsCompVarItem.GoRight();
		PantsCompVarItem.GoLeft();
		PantsCompVarItem.Enabled = true;
		nativeMenu6.Add(PantsCompVarItem);
		PantsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			PantsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 4, PantsCompItem.SelectedItem); iVar0++)
			{
				PantsCompVarItem.Add(iVar0, iVar0);
			}
			PantsCompVarItem.GoRight();
			PantsCompVarItem.GoLeft();
			PantsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 4, PantsCompItem.SelectedItem, 0, 2);
		};
		PantsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 4, PantsCompItem.SelectedItem, PantsCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu7 = new NativeMenu("", "Bags and Parachutes", "Browse for some Bags and Parachutes.");
		MenuPool.Add(nativeMenu7);
		nativeMenu7.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu7.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem7 = new NativeSubmenuItem(nativeMenu7, nativeMenu4);
		nativeSubmenuItem7.AltTitle = "";
		nativeMenu4.Add(2, nativeSubmenuItem7);
		nativeMenu7.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.5f, -0.6f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 50f);
		};
		nativeMenu7.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> BAPCompItem = new NativeListItem<int>("Component", "Select a Component.");
		BAPCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 5); iVar0++)
		{
			BAPCompItem.Add(iVar0 + 1, iVar0);
		}
		BAPCompItem.GoRight();
		BAPCompItem.GoLeft();
		BAPCompItem.Enabled = true;
		nativeMenu7.Add(BAPCompItem);
		NativeListItem<int> BAPCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		BAPCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 5, 0); iVar0++)
		{
			BAPCompVarItem.Add(iVar0, iVar0);
		}
		BAPCompVarItem.GoRight();
		BAPCompVarItem.GoLeft();
		BAPCompVarItem.Enabled = true;
		nativeMenu7.Add(BAPCompVarItem);
		BAPCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			BAPCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 5, BAPCompItem.SelectedItem); iVar0++)
			{
				BAPCompVarItem.Add(iVar0, iVar0);
			}
			BAPCompVarItem.GoRight();
			BAPCompVarItem.GoLeft();
			BAPCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 5, BAPCompItem.SelectedItem, 0, 2);
		};
		BAPCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 5, BAPCompItem.SelectedItem, BAPCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu8 = new NativeMenu("", "Shoes", "Browse for some Shoes.");
		MenuPool.Add(nativeMenu8);
		nativeMenu8.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu8.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem8 = new NativeSubmenuItem(nativeMenu8, nativeMenu4);
		nativeSubmenuItem8.AltTitle = "";
		nativeMenu4.Add(3, nativeSubmenuItem8);
		nativeMenu8.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.2f, 0.9f, -0.8f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -1f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 40f);
		};
		nativeMenu8.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> ShoeCompItem = new NativeListItem<int>("Component", "Select a Component.");
		ShoeCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 6); iVar0++)
		{
			ShoeCompItem.Add(iVar0 + 1, iVar0);
		}
		ShoeCompItem.GoRight();
		ShoeCompItem.GoLeft();
		ShoeCompItem.Enabled = true;
		nativeMenu8.Add(ShoeCompItem);
		NativeListItem<int> ShoeCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		ShoeCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 6, 0); iVar0++)
		{
			ShoeCompVarItem.Add(iVar0, iVar0);
		}
		ShoeCompVarItem.GoRight();
		ShoeCompVarItem.GoLeft();
		ShoeCompVarItem.Enabled = true;
		nativeMenu8.Add(ShoeCompVarItem);
		ShoeCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			ShoeCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 6, ShoeCompItem.SelectedItem); iVar0++)
			{
				ShoeCompVarItem.Add(iVar0, iVar0);
			}
			ShoeCompVarItem.GoRight();
			ShoeCompVarItem.GoLeft();
			ShoeCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 6, ShoeCompItem.SelectedItem, 0, 2);
		};
		ShoeCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 6, ShoeCompItem.SelectedItem, ShoeCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu9 = new NativeMenu("", "Accessories", "Browse for some Accessories.");
		MenuPool.Add(nativeMenu9);
		nativeMenu9.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu9.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem9 = new NativeSubmenuItem(nativeMenu9, nativeMenu4);
		nativeSubmenuItem9.AltTitle = "";
		nativeMenu4.Add(4, nativeSubmenuItem9);
		nativeMenu9.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 2f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu9.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> AccsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		AccsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 7); iVar0++)
		{
			AccsCompItem.Add(iVar0 + 1, iVar0);
		}
		AccsCompItem.GoRight();
		AccsCompItem.GoLeft();
		AccsCompItem.Enabled = true;
		nativeMenu9.Add(AccsCompItem);
		NativeListItem<int> AccsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		AccsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 7, 0); iVar0++)
		{
			AccsCompVarItem.Add(iVar0, iVar0);
		}
		AccsCompVarItem.GoRight();
		AccsCompVarItem.GoLeft();
		AccsCompVarItem.Enabled = true;
		nativeMenu9.Add(AccsCompVarItem);
		AccsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			AccsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 7, AccsCompItem.SelectedItem); iVar0++)
			{
				AccsCompVarItem.Add(iVar0, iVar0);
			}
			AccsCompVarItem.GoRight();
			AccsCompVarItem.GoLeft();
			AccsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 7, AccsCompItem.SelectedItem, 0, 2);
		};
		AccsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 7, AccsCompItem.SelectedItem, AccsCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu10 = new NativeMenu("", "Undershirts", "Browse for some Undershirts.");
		MenuPool.Add(nativeMenu10);
		nativeMenu10.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu10.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem10 = new NativeSubmenuItem(nativeMenu10, nativeMenu4);
		nativeSubmenuItem10.AltTitle = "";
		nativeMenu4.Add(5, nativeSubmenuItem10);
		nativeMenu10.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu10.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> USCompItem = new NativeListItem<int>("Component", "Select a Component.");
		USCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 8); iVar0++)
		{
			USCompItem.Add(iVar0 + 1, iVar0);
		}
		USCompItem.GoRight();
		USCompItem.GoLeft();
		USCompItem.Enabled = true;
		nativeMenu10.Add(USCompItem);
		NativeListItem<int> USCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		USCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 8, 0); iVar0++)
		{
			USCompVarItem.Add(iVar0, iVar0);
		}
		USCompVarItem.GoRight();
		USCompVarItem.GoLeft();
		USCompVarItem.Enabled = true;
		nativeMenu10.Add(USCompVarItem);
		USCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			USCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 8, USCompItem.SelectedItem); iVar0++)
			{
				USCompVarItem.Add(iVar0, iVar0);
			}
			USCompVarItem.GoRight();
			USCompVarItem.GoLeft();
			USCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 8, USCompItem.SelectedItem, 0, 2);
		};
		USCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 8, USCompItem.SelectedItem, USCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu11 = new NativeMenu("", "Body Armors", "Browse for some Body Armors.");
		MenuPool.Add(nativeMenu11);
		nativeMenu11.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu11.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem11 = new NativeSubmenuItem(nativeMenu11, nativeMenu4);
		nativeSubmenuItem11.AltTitle = "";
		nativeMenu4.Add(6, nativeSubmenuItem11);
		nativeMenu11.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu11.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> BACompItem = new NativeListItem<int>("Component", "Select a Component.");
		BACompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 9); iVar0++)
		{
			BACompItem.Add(iVar0 + 1, iVar0);
		}
		BACompItem.GoRight();
		BACompItem.GoLeft();
		BACompItem.Enabled = true;
		nativeMenu11.Add(BACompItem);
		NativeListItem<int> BACompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		BACompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 9, 0); iVar0++)
		{
			BACompVarItem.Add(iVar0, iVar0);
		}
		BACompVarItem.GoRight();
		BACompVarItem.GoLeft();
		BACompVarItem.Enabled = true;
		nativeMenu11.Add(BACompVarItem);
		BACompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			BACompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 9, BACompItem.SelectedItem); iVar0++)
			{
				BACompVarItem.Add(iVar0, iVar0);
			}
			BACompVarItem.GoRight();
			BACompVarItem.GoLeft();
			BACompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 9, BACompItem.SelectedItem, 0, 2);
		};
		BACompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 9, BACompItem.SelectedItem, BACompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu12 = new NativeMenu("", "Decals", "Browse for some Decals.");
		MenuPool.Add(nativeMenu12);
		nativeMenu12.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu12.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem12 = new NativeSubmenuItem(nativeMenu12, nativeMenu4);
		nativeSubmenuItem12.AltTitle = "";
		nativeMenu4.Add(7, nativeSubmenuItem12);
		NativeListItem<int> DecalCompItem = new NativeListItem<int>("Component", "Select a Component.");
		DecalCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 10); iVar0++)
		{
			DecalCompItem.Add(iVar0 + 1, iVar0);
		}
		DecalCompItem.GoRight();
		DecalCompItem.GoLeft();
		DecalCompItem.Enabled = true;
		nativeMenu12.Add(DecalCompItem);
		NativeListItem<int> DecalCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		DecalCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 10, 0); iVar0++)
		{
			DecalCompVarItem.Add(iVar0, iVar0);
		}
		DecalCompVarItem.GoRight();
		DecalCompVarItem.GoLeft();
		DecalCompVarItem.Enabled = true;
		nativeMenu12.Add(DecalCompVarItem);
		DecalCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			DecalCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 10, DecalCompItem.SelectedItem); iVar0++)
			{
				DecalCompVarItem.Add(iVar0, iVar0);
			}
			DecalCompVarItem.GoRight();
			DecalCompVarItem.GoLeft();
			DecalCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 10, DecalCompItem.SelectedItem, 0, 2);
		};
		DecalCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 10, DecalCompItem.SelectedItem, DecalCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu13 = new NativeMenu("", "Tops", "Browse for some Tops.");
		MenuPool.Add(nativeMenu13);
		nativeMenu13.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu13.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem13 = new NativeSubmenuItem(nativeMenu13, nativeMenu4);
		nativeSubmenuItem13.AltTitle = "";
		nativeMenu4.Add(8, nativeSubmenuItem13);
		nativeMenu13.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 1.5f, 0.3f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.3f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu13.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> TopsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		TopsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 11); iVar0++)
		{
			TopsCompItem.Add(iVar0 + 1, iVar0);
		}
		TopsCompItem.GoRight();
		TopsCompItem.GoLeft();
		TopsCompItem.Enabled = true;
		nativeMenu13.Add(TopsCompItem);
		NativeListItem<int> TopsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		TopsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 11, 0); iVar0++)
		{
			TopsCompVarItem.Add(iVar0, iVar0);
		}
		TopsCompVarItem.GoRight();
		TopsCompVarItem.GoLeft();
		TopsCompVarItem.Enabled = true;
		nativeMenu13.Add(TopsCompVarItem);
		TopsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			TopsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 11, TopsCompItem.SelectedItem); iVar0++)
			{
				TopsCompVarItem.Add(iVar0, iVar0);
			}
			TopsCompVarItem.GoRight();
			TopsCompVarItem.GoLeft();
			TopsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 11, TopsCompItem.SelectedItem, 0, 2);
		};
		TopsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 11, TopsCompItem.SelectedItem, TopsCompVarItem.SelectedItem, 2);
		};
		NativeMenu nativeMenu14 = new NativeMenu("", "Hats", "Browse for some Hats.");
		MenuPool.Add(nativeMenu14);
		nativeMenu14.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu14.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem14 = new NativeSubmenuItem(nativeMenu14, nativeMenu4);
		nativeSubmenuItem14.AltTitle = "";
		nativeMenu4.Add(9, nativeSubmenuItem14);
		nativeMenu14.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.2f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu14.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> HatsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		HatsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 0); iVar0++)
		{
			HatsCompItem.Add(iVar0 + 1, iVar0);
		}
		HatsCompItem.GoRight();
		HatsCompItem.GoLeft();
		HatsCompItem.Enabled = true;
		nativeMenu14.Add(HatsCompItem);
		NativeListItem<int> HatsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		HatsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 0, 0); iVar0++)
		{
			HatsCompVarItem.Add(iVar0, iVar0);
		}
		HatsCompVarItem.GoRight();
		HatsCompVarItem.GoLeft();
		HatsCompVarItem.Enabled = true;
		nativeMenu14.Add(HatsCompVarItem);
		HatsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			HatsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 0, HatsCompItem.SelectedItem); iVar0++)
			{
				HatsCompVarItem.Add(iVar0, iVar0);
			}
			HatsCompVarItem.GoRight();
			HatsCompVarItem.GoLeft();
			HatsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 0, HatsCompItem.SelectedItem, 0, true);
			if (HatsCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0, 0);
			}
		};
		HatsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 0, HatsCompItem.SelectedItem, HatsCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu15 = new NativeMenu("", "Glasses", "Browse for some Glasses.");
		MenuPool.Add(nativeMenu15);
		nativeMenu15.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu15.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem15 = new NativeSubmenuItem(nativeMenu15, nativeMenu4);
		nativeSubmenuItem15.AltTitle = "";
		nativeMenu4.Add(10, nativeSubmenuItem15);
		nativeMenu15.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.2f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu15.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> GlassesCompItem = new NativeListItem<int>("Component", "Select a Component.");
		GlassesCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 1); iVar0++)
		{
			GlassesCompItem.Add(iVar0 + 1, iVar0);
		}
		GlassesCompItem.GoRight();
		GlassesCompItem.GoLeft();
		GlassesCompItem.Enabled = true;
		nativeMenu15.Add(GlassesCompItem);
		NativeListItem<int> GlassesCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		GlassesCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 1, 0); iVar0++)
		{
			GlassesCompVarItem.Add(iVar0, iVar0);
		}
		GlassesCompVarItem.GoRight();
		GlassesCompVarItem.GoLeft();
		GlassesCompVarItem.Enabled = true;
		nativeMenu15.Add(GlassesCompVarItem);
		GlassesCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			GlassesCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 1, GlassesCompItem.SelectedItem); iVar0++)
			{
				GlassesCompVarItem.Add(iVar0, iVar0);
			}
			GlassesCompVarItem.GoRight();
			GlassesCompVarItem.GoLeft();
			GlassesCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 1, GlassesCompItem.SelectedItem, 1, true);
			if (GlassesCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 1, 0);
			}
		};
		GlassesCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 1, GlassesCompItem.SelectedItem, GlassesCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu16 = new NativeMenu("", "Ear Accessories", "Browse for some Ear Accessories.");
		MenuPool.Add(nativeMenu16);
		nativeMenu16.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu16.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem16 = new NativeSubmenuItem(nativeMenu16, nativeMenu4);
		nativeSubmenuItem16.AltTitle = "";
		nativeMenu4.Add(11, nativeSubmenuItem16);
		nativeMenu16.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.5f, 0.3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu16.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeItem nativeItem11 = new NativeItem("View Left Side", "Switch View of Camera to see a different Point of View.");
		nativeItem11.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.5f, 0.3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu16.Add(nativeItem11);
		NativeItem nativeItem12 = new NativeItem("View Right Side", "Switch View of Camera to see a different Point of View.");
		nativeItem12.Activated += (object sender, EventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.5f, 0.3f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu16.Add(nativeItem12);
		NativeListItem<int> EarAccsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		EarAccsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 2); iVar0++)
		{
			EarAccsCompItem.Add(iVar0 + 1, iVar0);
		}
		EarAccsCompItem.GoRight();
		EarAccsCompItem.GoLeft();
		EarAccsCompItem.Enabled = true;
		nativeMenu16.Add(EarAccsCompItem);
		NativeListItem<int> EarAccsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		EarAccsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 2, 0); iVar0++)
		{
			EarAccsCompVarItem.Add(iVar0, iVar0);
		}
		EarAccsCompVarItem.GoRight();
		EarAccsCompVarItem.GoLeft();
		EarAccsCompVarItem.Enabled = true;
		nativeMenu16.Add(EarAccsCompVarItem);
		EarAccsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			EarAccsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 2, EarAccsCompItem.SelectedItem); iVar0++)
			{
				EarAccsCompVarItem.Add(iVar0, iVar0);
			}
			EarAccsCompVarItem.GoRight();
			EarAccsCompVarItem.GoLeft();
			EarAccsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 2, EarAccsCompItem.SelectedItem, 1, true);
			if (EarAccsCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 2, 0);
			}
		};
		EarAccsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 2, EarAccsCompItem.SelectedItem, EarAccsCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu17 = new NativeMenu("", "Watches", "Browse for some Watches.");
		MenuPool.Add(nativeMenu17);
		nativeMenu17.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu17.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem17 = new NativeSubmenuItem(nativeMenu17, nativeMenu4);
		nativeSubmenuItem17.AltTitle = "";
		nativeMenu4.Add(12, nativeSubmenuItem17);
		nativeMenu17.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.7f, 0.2f, -0.05f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -0.05f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 45f);
		};
		nativeMenu17.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> WatchesCompItem = new NativeListItem<int>("Component", "Select a Component.");
		WatchesCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 6); iVar0++)
		{
			WatchesCompItem.Add(iVar0 + 1, iVar0);
		}
		WatchesCompItem.GoRight();
		WatchesCompItem.GoLeft();
		WatchesCompItem.Enabled = true;
		nativeMenu17.Add(WatchesCompItem);
		NativeListItem<int> WatchesCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		WatchesCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 6, 0); iVar0++)
		{
			WatchesCompVarItem.Add(iVar0, iVar0);
		}
		WatchesCompVarItem.GoRight();
		WatchesCompVarItem.GoLeft();
		WatchesCompVarItem.Enabled = true;
		nativeMenu17.Add(WatchesCompVarItem);
		WatchesCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			WatchesCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 6, WatchesCompItem.SelectedItem); iVar0++)
			{
				WatchesCompVarItem.Add(iVar0, iVar0);
			}
			WatchesCompVarItem.GoRight();
			WatchesCompVarItem.GoLeft();
			WatchesCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 6, WatchesCompItem.SelectedItem, 1, true);
			if (WatchesCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 6, 0);
			}
		};
		WatchesCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 6, WatchesCompItem.SelectedItem, WatchesCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu18 = new NativeMenu("", "Bracelets", "Browse for some Bracelets.");
		MenuPool.Add(nativeMenu18);
		nativeMenu18.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu18.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem18 = new NativeSubmenuItem(nativeMenu18, nativeMenu4);
		nativeSubmenuItem18.AltTitle = "";
		nativeMenu4.Add(13, nativeSubmenuItem18);
		nativeMenu18.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0.7f, 0.2f, -0.05f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, -0.05f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 45f);
		};
		nativeMenu18.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> BraceletsCompItem = new NativeListItem<int>("Component", "Select a Component.");
		BraceletsCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 7); iVar0++)
		{
			BraceletsCompItem.Add(iVar0 + 1, iVar0);
		}
		BraceletsCompItem.GoRight();
		BraceletsCompItem.GoLeft();
		BraceletsCompItem.Enabled = true;
		nativeMenu18.Add(BraceletsCompItem);
		NativeListItem<int> BraceletsCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		BraceletsCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 7, 0); iVar0++)
		{
			BraceletsCompVarItem.Add(iVar0, iVar0);
		}
		BraceletsCompVarItem.GoRight();
		BraceletsCompVarItem.GoLeft();
		BraceletsCompVarItem.Enabled = true;
		nativeMenu18.Add(BraceletsCompVarItem);
		BraceletsCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			BraceletsCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, 7, BraceletsCompItem.SelectedItem); iVar0++)
			{
				BraceletsCompVarItem.Add(iVar0, iVar0);
			}
			BraceletsCompVarItem.GoRight();
			BraceletsCompVarItem.GoLeft();
			BraceletsCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 7, BraceletsCompItem.SelectedItem, 1, true);
			if (BraceletsCompItem.SelectedItem == -1)
			{
				Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 7, 0);
			}
		};
		BraceletsCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 7, BraceletsCompItem.SelectedItem, BraceletsCompVarItem.SelectedItem, true);
		};
		NativeMenu nativeMenu19 = new NativeMenu("", "Masks", "Browse for some Masks.");
		MenuPool.Add(nativeMenu19);
		nativeMenu19.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu19.CloseOnInvalidClick = false;
		NativeSubmenuItem nativeSubmenuItem19 = new NativeSubmenuItem(nativeMenu19, nativeMenu4);
		nativeSubmenuItem19.AltTitle = "";
		nativeMenu4.Add(10, nativeSubmenuItem19);
		nativeMenu19.Opening += (object sender, CancelEventArgs e) =>
		{
			Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, -0.2f, 1f, 0.6f, true);
			Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam, Game.Player.Character, 0f, 0f, 0.6f, true);
			Function.Call(Hash.SET_CAM_FOV, CruelMastersOnlineOffline.CutsceneCam, 35f);
		};
		nativeMenu19.Closing += (object sender, CancelEventArgs e) =>
		{
			SET_CAM_NORMAL();
		};
		NativeListItem<int> MasksCompItem = new NativeListItem<int>("Component", "Select a Component.");
		MasksCompItem.Clear();
		for (iVar0 = -1; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 1); iVar0++)
		{
			MasksCompItem.Add(iVar0 + 1, iVar0);
		}
		MasksCompItem.GoRight();
		MasksCompItem.GoLeft();
		MasksCompItem.Enabled = true;
		nativeMenu19.Add(MasksCompItem);
		NativeListItem<int> MasksCompVarItem = new NativeListItem<int>("Variation", "Select a Variation for your current Component.");
		MasksCompVarItem.Clear();
		for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 1, 0); iVar0++)
		{
			MasksCompVarItem.Add(iVar0, iVar0);
		}
		MasksCompVarItem.GoRight();
		MasksCompVarItem.GoLeft();
		MasksCompVarItem.Enabled = true;
		nativeMenu19.Add(MasksCompVarItem);
		MasksCompItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			MasksCompVarItem.Clear();
			for (iVar0 = 0; iVar0 < Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, 1, MasksCompItem.SelectedItem); iVar0++)
			{
				MasksCompVarItem.Add(iVar0, iVar0);
			}
			MasksCompVarItem.GoRight();
			MasksCompVarItem.GoLeft();
			MasksCompVarItem.Enabled = true;
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 1, MasksCompItem.SelectedItem, 0, 2);
		};
		MasksCompVarItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
		{
			Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, 1, MasksCompItem.SelectedItem, MasksCompVarItem.SelectedItem, 2);
		};
		foreach (NativeSubmenuItem item in nativeSubmenuItem4.Menu)
		{
			item.Menu.Opening += (object sender, CancelEventArgs e) =>
			{
				Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_loop", 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
			};
		}
		nativeSubmenuItem4.Menu.Closing += (object sender, CancelEventArgs e) =>
		{
			if (CloseApparelMenu)
			{
				SET_CAM_NORMAL();
				Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
			}
		};
		Sexbutton.ItemChanged += (object sender, ItemChangedEventArgs<string> e) =>
		{
			if (Sexbutton.SelectedItem == "Male")
			{
				Game.Player.ChangeModel(RequestModel(PedHash.FreemodeMale01));
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, 0, 0, 0, 0, 0, 0, 0f, 0f, 0f, false);
				PedOutfit pedOutfit = new PedOutfit
				{
					Components = new List<PedOutfit.OutfitComponent>(),
					Props = new List<PedOutfit.OutfitProp>()
				};
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
					DrawableId = 15,
					TextureId = 9,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
					DrawableId = 12,
					TextureId = 12,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
					DrawableId = 17,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
					DrawableId = 2,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
					DrawableId = 0,
					TextureId = 2,
					PaletteId = 0
				});
				pedOutfit.Equip(Game.Player.Character);
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
				Anims.SET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim, 1f);
				MPGender = 0;
			}
			if (Sexbutton.SelectedItem == "Female")
			{
				Game.Player.ChangeModel(RequestModel(PedHash.FreemodeFemale01));
				Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
				Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, 0, 0, 0, 0, 0, 0, 0f, 0f, 0f, false);
				PedOutfit pedOutfit2 = new PedOutfit
				{
					Components = new List<PedOutfit.OutfitComponent>(),
					Props = new List<PedOutfit.OutfitProp>()
				};
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
					DrawableId = 4,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
					DrawableId = 3,
					TextureId = 8,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
					DrawableId = 4,
					TextureId = 2,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
					DrawableId = 1,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
					DrawableId = 3,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
					DrawableId = 0,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Components.Add(new PedOutfit.OutfitComponent
				{
					ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
					DrawableId = 32,
					TextureId = 0,
					PaletteId = 0
				});
				pedOutfit2.Equip(Game.Player.Character);
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
				Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
				Anims.SET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim, 1f);
				MPGender = 1;
			}
		};
		NativeItem nativeItem13 = new NativeItem("Save & Continue", "Ready to save this Character?", "");
		CharCreator.Add(nativeItem13);
		nativeItem13.Activated += (object sender, EventArgs e) =>
		{
			if (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3))
			{
				CharCreator.Visible = !CharCreator.Visible;
				string defaultText = "Ai Friend";
				if (ReEditingAi)
				{
					defaultText = CurrentlyEditingAiName;
				}
				string userInput = ONSCREEN_KEYBOARD.GetUserInput("", defaultText, 15);
				if (!Function.Call<bool>(Hash.IS_STRING_NULL_OR_EMPTY, userInput))
				{
					MyAiInfo = new AIInfo();
					MyAiInfo.Name = userInput;
					Wall_Creator.CallFunction(ScaleID, "SET_BOARD", userInput, "", "LOS SANTOS POLICE DEPT", "ONLINE - OFFLINE", "", 1, 1);
					Menu_Switch = 2;
				}
			}
		};
	}

	public unsafe void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (MenuPool != null && MenuPool.AreAnyVisible)
		{
			MenuPool.Process();
		}
		if (Game.Player.Character.CurrentVehicle != null && Game.Player.Character.CurrentVehicle.AttachedBlip != null)
		{
			if (vehpascount > 1)
			{
				Function.Call(Hash.SHOW_NUMBER_ON_BLIP, Game.Player.Character.CurrentVehicle.AttachedBlip, vehpascount);
			}
			else
			{
				Function.Call(Hash.HIDE_NUMBER_ON_BLIP, Game.Player.Character.CurrentVehicle.AttachedBlip, vehpascount);
			}
		}
		for (int i = 0; i < Companions.Length; i++)
		{
			if (Companions[i] != null)
			{
				if (Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, Game.Player.Character))
				{
					if (!Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, Companions[i]))
					{
						Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, Companions[i], 1, "DEFAULT_ACTION");
					}
				}
				else if (Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, Companions[i]))
				{
					Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, Companions[i], 0, "DEFAULT_ACTION");
				}
				if (Companions[i].AttachedBlip != null)
				{
					if (Companions[i].CurrentVehicle != null)
					{
						Companions[i].AttachedBlip.Alpha = 0;
					}
					else
					{
						Companions[i].AttachedBlip.Alpha = 255;
					}
				}
				if (Companions[i].IsDead)
				{
					if (Companions[i].AttachedBlip != null)
					{
						Notification.Show("<b>" + Companions[i].AttachedBlip.Name + "</b> Died.");
						Companions[i].AttachedBlip.Delete();
					}
					Companions[i].MarkAsNoLongerNeeded();
					Companions[i] = null;
				}
				if (vehpascount < 7)
				{
					vehpascount++;
				}
			}
			else if (vehpascount > 1)
			{
				vehpascount--;
			}
		}
		int num = Function.Call<int>(Hash.GET_PLAYER_GROUP, Game.Player);
		int num2 = default;
		int groupCount = default;
		Function.Call(Hash.GET_GROUP_SIZE, num, &num2, &groupCount);
		GroupCount = groupCount;
		if (!CruelMastersOnlineOffline.OnMission)
		{
			if (AiCreatorBlip == null)
			{
				AiCreatorBlip = World.CreateBlip(new Vector3(-1047.051f, -2742.971f, 21.3594f));
			}
			else
			{
				AiCreatorBlip.Sprite = BlipSprite.VIP;
				AiCreatorBlip.Color = BlipColor.Blue2;
				AiCreatorBlip.Name = "Ai Creator";
				AiCreatorBlip.Alpha = 255;
				AiCreatorBlip.Priority = 5;
				AiCreatorBlip.IsShortRange = true;
			}
			switch (Menu_Switch)
			{
			case 0:
				if (Game.Player.Character.Position.DistanceTo(new Vector3(-1047.051f, -2742.971f, 21.3594f)) < 10f)
				{
					World.DrawMarker(MarkerType.Cylinder, new Vector3(-1047.051f, -2742.971f, 19.7594f), Vector3.Zero, Vector3.Zero, new Vector3(1.5f, 1.5f, 1.5f), Color.Aqua);
				}
				if (!(Game.Player.Character.Position.DistanceTo(new Vector3(-1047.051f, -2742.971f, 21.3594f)) < 1.3f))
				{
					break;
				}
				GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter the Ai Creator.");
				if (Game.IsControlJustPressed(Control.Context))
				{
					Mobile_Phone.CAN_OPEN_PHONE = false;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
					MPCash.CAN_SEE_CASH = false;
					MPRank.CAN_SEE_RANK_BAR = false;
					MPPlayerList.CAN_SHOW_LIST = false;
					Mobile_Phone.CAN_OPEN_PHONE = false;
					Script.Wait(1000);
					PlayerSwitch._SWITCH_OUT_PLAYER(Game.Player.Character, 3, 1);
					int num4 = Game.GameTime + 5000;
					while (Game.GameTime < num4)
					{
						Script.Wait(0);
					}
					Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
					Game.Player.Character.Heading = 93.56179f;
					Cameras.RESET_GAMEPLAY_CAM();
					HudHandler.HudandRadar(Hud: false, Radar: false);
					Function.Call(Hash.ALLOW_PLAYER_SWITCH_DESCENT);
					Function.Call(Hash.ALLOW_PLAYER_SWITCH_PAN);
					PlayerSwitch.SWITCH_IN_PLAYER(Game.Player.Character);
					while (PlayerSwitch.IS_PLAYER_SWITCH_IN_PROGRESS())
					{
						LOAD_SCENES.LOAD_SCENE(405.9204f, -997.1423f, -99.00402f);
						Script.Wait(0);
					}
					GTA.UI.Screen.FadeOut(0);
					Script.Wait(2000);
					Game.Player.Character.Position = new Vector3(405.9204f, -997.1423f, -100.00402f);
					Game.Player.Character.Heading = 93.56179f;
					Cameras.RESET_GAMEPLAY_CAM();
					if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
					{
						Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
					}
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
					LoadDict("mp_character_creation@customise@male_a");
					LoadDict("mp_character_creation@customise@male_a");
					Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM", false, -1);
					Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator", false, -1);
					Script.Wait(50);
					int scaleID3 = ScaleID;
					Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID3);
					ScaleID = 0;
					int scaleID4 = ScaleID2;
					Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID4);
					ScaleID2 = 0;
					Script.Yield();
					Script.Wait(500);
					ScaleID = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "MUGSHOT_BOARD_01");
					Script.Wait(500);
					ScaleID2 = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE_WITH_IGNORE_SUPER_WIDESCREEN, "DIGITAL_CAMERA");
					Script.Wait(500);
					while (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
					{
						Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
						Script.Wait(0);
					}
					while (!Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
					{
						Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "ID_Text", 0);
						Script.Wait(0);
					}
					Function.Call(Hash.LINK_NAMED_RENDERTARGET, Game.GenerateHash("prop_police_id_text"));
					RenderID = Function.Call<int>(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, "ID_Text");
					Wall_Creator.CallFunction(ScaleID, "SET_BOARD", "Ai Friend", "", "LOS SANTOS POLICE DEPT", "ONLINE - OFFLINE", "", 1, 1);
					Game.Player.ChangeModel(RequestModel(PedHash.Michael));
					Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
					Script.Wait(500);
					Game.Player.ChangeModel(RequestModel(PedHash.FreemodeMale01));
					Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
					Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Game.Player.Character, 0, 0, 0, 0, 0, 0, 0f, 0f, 0f, false);
					PedOutfit pedOutfit = new PedOutfit
					{
						Components = new List<PedOutfit.OutfitComponent>(),
						Props = new List<PedOutfit.OutfitProp>()
					};
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_UPPR,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_LOWR,
						DrawableId = 15,
						TextureId = 9,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_HAND,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_FEET,
						DrawableId = 12,
						TextureId = 12,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TEEF,
						DrawableId = 17,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_ACCS,
						DrawableId = 2,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_TASK,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_DECL,
						DrawableId = 0,
						TextureId = 0,
						PaletteId = 0
					});
					pedOutfit.Components.Add(new PedOutfit.OutfitComponent
					{
						ComponentId = PedOutfit.PedVarComp.PV_COMP_JBIB,
						DrawableId = 0,
						TextureId = 2,
						PaletteId = 0
					});
					pedOutfit.Equip(Game.Player.Character);
					Props.RemoveProps();
					Props.SPAWN_PROP_NO_OFFSET(RequestModel("prop_police_id_board"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
					Props.SPAWN_PROP_NO_OFFSET(RequestModel("prop_police_id_text"), Game.Player.Character.Position, Vector3.Zero, dynamic: false, frozen: true, collision: false, IsInvincible: true, IsVisible: true);
					Props.propList[1].AttachTo(Props.propList[0], new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
					Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "mugshot");
					Function.Call(Hash.CLEAR_ALL_HELP_MESSAGES);
					while (CruelMastersOnlineOffline.CutsceneCam == null)
					{
						CruelMastersOnlineOffline.CutsceneCam = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SPLINE_CAMERA", 0);
						Script.Wait(0);
					}
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					CruelMastersOnlineOffline.CutsceneCam.FieldOfView = 50f;
					TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "intro", 0.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
					Function.Call(Hash.PLAY_FACIAL_ANIM, Game.Player.Character, "intro_facial", LoadDict("mp_character_creation@customise@male_a"));
					Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Props.propList[0], Game.Player.Character, Game.Player.Character.Bones[Bone.PHRightHand].Index, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 2, 1);
					Function.Call(Hash.FORCE_ENTITY_AI_AND_ANIMATION_UPDATE, Props.propList[0]);
					Function.Call(Hash.SET_CAM_SPLINE_PHASE, CruelMastersOnlineOffline.CutsceneCam, 1f);
					Function.Call(Hash.SET_CAM_SPLINE_DURATION, CruelMastersOnlineOffline.CutsceneCam, 13000);
					Function.Call(Hash.ADD_CAM_SPLINE_NODE, CruelMastersOnlineOffline.CutsceneCam, 402.865f, -1003.475f, -98.36557f, 0f, 0f, 358.6678f, 1, 100, 0);
					Function.Call(Hash.ADD_CAM_SPLINE_NODE, CruelMastersOnlineOffline.CutsceneCam, 402.8563f, -999.9777f, -98.44982f, -6.103765f, 0.008221734f, 43f / 75f, 1, 100, 0);
					GTA.UI.Screen.FadeIn(1000);
					Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lights_on", "GTAO_MUGSHOT_ROOM_SOUNDS", false);
					while (Cameras.CAM_SPLINE_PHASE(CruelMastersOnlineOffline.CutsceneCam) < 1f)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Script.Wait(0);
					}
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
					while (CruelMastersOnlineOffline.CutsceneCam == null)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						CruelMastersOnlineOffline.CutsceneCam = World.CreateCamera(new Vector3(402.8563f, -999.9777f, -98.44982f), new Vector3(-6.103765f, 0.008221734f, 43f / 75f), 50f);
						Script.Wait(0);
					}
					World.RenderingCamera = CruelMastersOnlineOffline.CutsceneCam;
					TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
					Function.Call(Hash.CLEAR_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character);
					Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character, "mood_Happy_1", 0);
					Menu_Switch = 1;
				}
				break;
			case 1:
			{
				Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
				Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
				Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
				if (Function.Call<bool>(Hash.IS_USING_KEYBOARD_AND_MOUSE, 2))
				{
					if (Game.IsControlPressed(Control.Cover) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(Control.Cover))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
					if (Game.IsControlPressed(Control.Context) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(Control.Context))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
				}
				else
				{
					if (Game.IsControlPressed(Control.SelectWeapon) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(Control.Cover))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_l_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_l_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
					if (Game.IsControlPressed(Control.Cover) && (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_outro", 3)))
					{
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_intro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_intro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
						while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) >= 1f || Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
						{
							Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
							Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
							Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
							Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
							Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
							if (MenuPool != null && MenuPool.AreAnyVisible)
							{
								MenuPool.Process();
							}
							if (!Game.IsControlPressed(Control.Context))
							{
								break;
							}
							Script.Wait(0);
						}
						TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
						Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "profile_r_outro", 0.0, 0.0, 0, 0, 1148846080, 0);
						Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "profile_r_outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
						Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: false);
					}
				}
				string[] array2 = new string[3] { "a", "b", "c" };
				if (Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_loop", 3))
				{
					Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_" + array2[Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array2.Length)], 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
				}
				if (Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_intro", 3) || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_a", 3) || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_b", 3) || Function.Call<bool>(Hash.HAS_ENTITY_ANIM_FINISHED, Game.Player.Character, LoadDict("mp_character_creation@customise@male_a"), "drop_clothes_c", 3))
				{
					Game.Player.Character.Task.PlayAnimation(LoadDict("mp_character_creation@customise@male_a"), "drop_loop", 8f, 8f, -1, AnimationFlags.StayInEndFrame, -1000f);
				}
				if (!MenuPool.AreAnyVisible)
				{
					CharCreator.Visible = !CharCreator.Visible;
				}
				if (!Game.IsControlJustPressed(Control.VehicleDuck))
				{
					break;
				}
				GTA.UI.Screen.FadeOut(1000);
				int num6 = Game.GameTime + 1000;
				while (Game.GameTime < num6)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					if (MenuPool != null && MenuPool.AreAnyVisible)
					{
						MenuPool.Process();
					}
					Script.Wait(0);
				}
				foreach (NativeMenu item in MenuPool)
				{
					if (item.Visible)
					{
						item.Visible = false;
					}
				}
				if (CruelMastersOnlineOffline.CutsceneCam != null)
				{
					CruelMastersOnlineOffline.CutsceneCam.Delete();
					CruelMastersOnlineOffline.CutsceneCam = null;
				}
				if (CruelMastersOnlineOffline.CutsceneCam2 != null)
				{
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
				}
				World.RenderingCamera = null;
				Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
				LoadingPrompt.Hide();
				Props.RemoveProps();
				if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
				{
					Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
				}
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
				Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
				int scaleID5 = ScaleID;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID5);
				ScaleID = 0;
				int scaleID6 = ScaleID2;
				Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID6);
				ScaleID2 = 0;
				Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
				Screen_Effects.StopAllAnimPostFX();
				Function.Call(Hash.STOP_AUDIO_SCENES);
				Game.Player.Character.Task.ClearAllImmediately();
				Game.Player.Character.Position = new Vector3(-1047.058f, -2743.042f, 20.3594f);
				Game.Player.Character.Heading = 294.6984f;
				CruelMastersOnlineOffline.GET_MAIN_CHARACTER();
				MPLoadout.GET_CURRENT_LOADOUT();
				Cameras.RESET_GAMEPLAY_CAM();
				HudHandler.HudandRadar(Hud: true, Radar: true);
				Mobile_Phone.CAN_OPEN_PHONE = true;
				MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
				MPCash.CAN_SEE_CASH = true;
				MPRank.CAN_SEE_RANK_BAR = true;
				MPPlayerList.CAN_SHOW_LIST = true;
				Mobile_Phone.CAN_OPEN_PHONE = true;
				if (ReEditingAi)
				{
					ReEditingAi = false;
				}
				Script.Wait(1000);
				GTA.UI.Screen.FadeIn(1000);
				Menu_Switch = 0;
				break;
			}
			case 2:
			{
				while (CruelMastersOnlineOffline.CutsceneCam2 == null)
				{
					CruelMastersOnlineOffline.CutsceneCam2 = World.CreateCamera(Vector3.Zero, Vector3.Zero, 50f);
					Script.Wait(0);
				}
				Function.Call(Hash.SET_CAM_ACTIVE, CruelMastersOnlineOffline.CutsceneCam, true);
				Function.Call(Hash.ATTACH_CAM_TO_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0.1f, 1f, 0.6f, true);
				Function.Call(Hash.POINT_CAM_AT_ENTITY, CruelMastersOnlineOffline.CutsceneCam2, Game.Player.Character, 0f, 0f, 0.6f, true);
				CruelMastersOnlineOffline.CutsceneCam2.FieldOfView = 43f;
				CruelMastersOnlineOffline.CutsceneCam.InterpTo(CruelMastersOnlineOffline.CutsceneCam2, 200, 0, 0);
				Function.Call(Hash.PLAY_SOUND, -1, "Zoom_In", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
				Wall_Creator.CallFunction(ScaleID2, "SHOW_REMAINING_PHOTOS", false);
				Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_FRAME", true);
				Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_BORDER", false);
				Wall_Creator.CallFunction(ScaleID2, "OPEN_SHUTTER");
				string[] array = new string[5] { "", "_a", "_b", "_c", "_d" };
				int num5 = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, 0, array.Length);
				Game.Player.Character.Task.ClearAllImmediately();
				TestCutsceneAnim = 0;
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "outro", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "outro", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				while (Anims.GET_SYNCHRONIZED_SCENE_PHASE(TestCutsceneAnim) < 1f)
				{
					Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
					Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
					Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
					Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
					Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
					Scaleform scaleform2 = new Scaleform("instructional_buttons");
					scaleform2.CallFunction("CLEAR_ALL");
					scaleform2.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
					scaleform2.CallFunction("CREATE_CONTAINER");
					scaleform2.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 201, 0), "Accept");
					scaleform2.CallFunction("SET_DATA_SLOT", 1, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 177, 0), "Return to Menu");
					scaleform2.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
					scaleform2.Render2D();
					Script.Wait(0);
				}
				TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
				Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "outro_loop", 0.0, 0.0, 0, 0, 1148846080, 0);
				Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "outro_loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
				Anims.SET_SYNCHRONIZED_SCENE_LOOPED(TestCutsceneAnim, toggle: true);
				Menu_Switch = 3;
				break;
			}
			case 3:
			{
				Scaleform scaleform = new Scaleform("instructional_buttons");
				scaleform.CallFunction("CLEAR_ALL");
				scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0);
				scaleform.CallFunction("CREATE_CONTAINER");
				scaleform.CallFunction("SET_DATA_SLOT", 0, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 201, 0), "Accept");
				scaleform.CallFunction("SET_DATA_SLOT", 1, Function.Call<string>(Hash.GET_CONTROL_INSTRUCTIONAL_BUTTONS_STRING, 2, 177, 0), "Return to Menu");
				scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1);
				scaleform.Render2D();
				Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
				Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
				Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
				Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
				Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
				if (Game.IsControlJustPressed(Control.PhoneCancel))
				{
					CruelMastersOnlineOffline.CutsceneCam2.InterpTo(CruelMastersOnlineOffline.CutsceneCam, 200, 0, 0);
					Function.Call(Hash.PLAY_SOUND, -1, "Zoom_Out", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
					Wall_Creator.CallFunction(ScaleID, "SET_BOARD", "Ai Friend", "", "LOS SANTOS POLICE DEPT", "ONLINE - OFFLINE", "", 1, 1);
					CruelMastersOnlineOffline.CutsceneCam2.Delete();
					CruelMastersOnlineOffline.CutsceneCam2 = null;
					TestCutsceneAnim = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, 404.9315f, -997.8859f, -98.85f, 0.0, 0.0, -40f, 2);
					Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, TestCutsceneAnim, LoadDict("mp_character_creation@customise@male_a"), "loop", 0.0, 0.0, 0, 0, 1148846080, 0);
					Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, Game.Player.Character, TestCutsceneAnim, "loop", LoadDict("mp_character_creation@customise@male_a"), 1000f, 0f, 0, 1000f);
					Menu_Switch = 1;
				}
				if (Game.IsControlJustPressed(Control.FrontendAccept))
				{
					if (ReEditingAi && File.Exists("scripts\\CruelMastersOnlineOfflineAssets\\Companions\\" + CurrentlyEditingAiName + ".xml"))
					{
						File.Delete("scripts\\CruelMastersOnlineOfflineAssets\\Companions\\" + CurrentlyEditingAiName + ".xml");
					}
					LoadingPrompt.Show("Saving " + MyAiInfo.Name, LoadingSpinnerType.SocialClubSaving);
					Wall_Creator.CallFunction(ScaleID2, "CLOSE_SHUTTER", 250);
					Function.Call(Hash.PLAY_SOUND, -1, "Take_Picture", "MUGSHOT_CHARACTER_CREATION_SOUNDS", false, 0, true);
					Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "mp_gr_int01_white");
					int num3 = Game.GameTime + 5000;
					while (Game.GameTime < num3)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, false);
					Function.Call(Hash.CLEAR_FACIAL_IDLE_ANIM_OVERRIDE, Game.Player.Character);
					LoadingPrompt.Show("Loading", LoadingSpinnerType.SocialClubSaving);
					Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_FRAME", false);
					Wall_Creator.CallFunction(ScaleID2, "SHOW_PHOTO_BORDER", true);
					Wall_Creator.CallFunction(ScaleID2, "OPEN_SHUTTER", 250);
					num3 = Game.GameTime + 11000;
					while (Game.GameTime < num3)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					PedOutfit.InitHeadBlendData();
					PedOutfit.InitExtensionListGet();
					num3 = Game.GameTime + 2000;
					while (Game.GameTime < num3)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					PedOutfit.GET_FACE(Game.Player.Character);
					PedOutfit.GET_OUTFIT(Game.Player.Character);
					num3 = Game.GameTime + 1000;
					while (Game.GameTime < num3)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					MPAiInfo mPAiInfo = new MPAiInfo();
					MyAiInfo.FacialFeatures = PedOutfit.FaceFeaturePart;
					int[] headBlendData = new int[3]
					{
						PedOutfit.Data.ShapeFirst,
						PedOutfit.Data.ShapeSecond,
						PedOutfit.Data.SkinFirst
					};
					MyAiInfo.HeadBlendData = headBlendData;
					MyAiInfo.Hair = PedOutfit.HairPart[0];
					MyAiInfo.HairColor = MPHairColor;
					MyAiInfo.EyeColor = MPEyeColor;
					MyAiInfo.MakeupColor = MPMakeupColor;
					MyAiInfo.LipstickColor = MPLipstickColor;
					MyAiInfo.Overlay = PedOutfit.OverlayPart;
					MyAiInfo.OverlayOpac = PedOutfit.OpacityPart;
					MyAiInfo.Gender = MPGender;
					int[] mask = new int[2]
					{
						Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 1),
						Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 1)
					};
					MyAiInfo.Mask = mask;
					MyCustomOutfit = new MPCustomOutfits();
					OutfitInfo outfitInfo = new OutfitInfo();
					outfitInfo.BodyType = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 3);
					outfitInfo.BodyTypeVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 3);
					outfitInfo.Pants = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 4);
					outfitInfo.PantsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 4);
					outfitInfo.BAP = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 5);
					outfitInfo.BAPVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 5);
					outfitInfo.Shoes = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 6);
					outfitInfo.ShoesVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 6);
					outfitInfo.Accs = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 7);
					outfitInfo.AccsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 7);
					outfitInfo.US = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 8);
					outfitInfo.USVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 8);
					outfitInfo.BA = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 9);
					outfitInfo.BAVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 9);
					outfitInfo.Decals = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 10);
					outfitInfo.DecalsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 10);
					outfitInfo.Tops = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 11);
					outfitInfo.TopsVar = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, 11);
					outfitInfo.Hats = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 0);
					outfitInfo.HatsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 0);
					outfitInfo.Glasses = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 1);
					outfitInfo.GlassesVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 1);
					outfitInfo.EarAccs = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 2);
					outfitInfo.EarAccsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 2);
					outfitInfo.Watches = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 6);
					outfitInfo.WatchesVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 6);
					outfitInfo.Bracelets = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 7);
					outfitInfo.BraceletsVar = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, 7);
					MyCustomOutfit.CustomOutfits.Add(outfitInfo);
					MyAiInfo.Outfit = MyCustomOutfit;
					mPAiInfo.ownedInfos.Add(MyAiInfo);
					GTA.UI.Screen.FadeOut(1000);
					num3 = Game.GameTime + 1000;
					while (Game.GameTime < num3)
					{
						Function.Call(Hash.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT, ScaleID, 2);
						Function.Call(Hash.SET_TEXT_RENDER_ID, RenderID);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_ORDER, 4);
						Function.Call(Hash.SET_SCRIPT_GFX_DRAW_BEHIND_PAUSEMENU, 1);
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE, ScaleID, 0.108f, 0.125f, 0.3f, 0.25f, 255, 255, 255, 255);
						Function.Call(Hash.SET_TEXT_RENDER_ID, Function.Call<int>(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID));
						Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, ScaleID2, 255, 255, 255, 255, 0);
						Script.Wait(0);
					}
					XMLSerializer.SaveToXML(mPAiInfo, "scripts\\CruelMastersOnlineOfflineAssets\\Companions\\" + MyAiInfo.Name + ".xml");
					if (CruelMastersOnlineOffline.CutsceneCam != null)
					{
						CruelMastersOnlineOffline.CutsceneCam.Delete();
						CruelMastersOnlineOffline.CutsceneCam = null;
					}
					if (CruelMastersOnlineOffline.CutsceneCam2 != null)
					{
						CruelMastersOnlineOffline.CutsceneCam2.Delete();
						CruelMastersOnlineOffline.CutsceneCam2 = null;
					}
					World.RenderingCamera = null;
					Function.Call(Hash.TOGGLE_PAUSED_RENDERPHASES, true);
					LoadingPrompt.Hide();
					Props.RemoveProps();
					if (Function.Call<bool>(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ID_Text"))
					{
						Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ID_Text");
					}
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "Mugshot_Character_Creator");
					Function.Call(Hash.RELEASE_NAMED_SCRIPT_AUDIO_BANK, "DLC_GTAO/MUGSHOT_ROOM");
					int scaleID = ScaleID;
					Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
					ScaleID = 0;
					int scaleID2 = ScaleID2;
					Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID2);
					ScaleID2 = 0;
					Screen_Effects.CLEAR_TIMECYCLE_MODIFIER();
					Screen_Effects.StopAllAnimPostFX();
					Function.Call(Hash.STOP_AUDIO_SCENES);
					Game.Player.Character.Task.ClearAllImmediately();
					Game.Player.Character.Position = new Vector3(-1047.058f, -2743.042f, 20.3594f);
					Game.Player.Character.Heading = 294.6984f;
					CruelMastersOnlineOffline.GET_MAIN_CHARACTER();
					MPLoadout.GET_CURRENT_LOADOUT();
					Cameras.RESET_GAMEPLAY_CAM();
					HudHandler.HudandRadar(Hud: true, Radar: true);
					Mobile_Phone.CAN_OPEN_PHONE = true;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
					MPCash.CAN_SEE_CASH = true;
					MPRank.CAN_SEE_RANK_BAR = true;
					MPPlayerList.CAN_SHOW_LIST = true;
					Mobile_Phone.CAN_OPEN_PHONE = true;
					if (ReEditingAi)
					{
						ReEditingAi = false;
					}
					Script.Wait(1000);
					GTA.UI.Screen.FadeIn(1000);
					Menu_Switch = 0;
				}
				break;
			}
			}
		}
		else if (AiCreatorBlip != null)
		{
			AiCreatorBlip.Alpha = 0;
		}
	}

	public unsafe void onShutdown(object sender, EventArgs e)
	{
		for (int i = 0; i < Companions.Length; i++)
		{
			if (Companions[i] != null)
			{
				if (Companions[i].AttachedBlip != null)
				{
					Companions[i].AttachedBlip.Delete();
				}
				Companions[i].Delete();
			}
		}
		if (AiCreatorBlip != null)
		{
			AiCreatorBlip.Delete();
			AiCreatorBlip = null;
		}
		if (ScaleID != 0)
		{
			int scaleID = ScaleID;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID);
			ScaleID = 0;
		}
		if (ScaleID2 != 0)
		{
			int scaleID2 = ScaleID2;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID2);
			ScaleID2 = 0;
		}
		if (ScaleID3 != 0)
		{
			int scaleID3 = ScaleID3;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID3);
			ScaleID3 = 0;
		}
		if (ScaleID4 != 0)
		{
			int scaleID4 = ScaleID4;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID4);
			ScaleID4 = 0;
		}
		if (ScaleID5 != 0)
		{
			int scaleID5 = ScaleID5;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID5);
			ScaleID5 = 0;
		}
		if (ScaleID6 != 0)
		{
			int scaleID6 = ScaleID6;
			Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &scaleID6);
			ScaleID6 = 0;
		}
	}

	public static string LoadTexureDict(string dict)
	{
		while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, dict))
		{
			Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, dict);
			Script.Yield();
		}
		return dict;
	}

	public static string LoadCutsceneWithFlag(string cutscene, int playbackflag)
	{
		while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED, cutscene))
		{
			Function.Call(Hash.REQUEST_CUTSCENE_WITH_PLAYBACK_LIST, cutscene, playbackflag, 8);
			Script.Yield();
		}
		return cutscene;
	}

	public static string LoadCutscene(string cutscene)
	{
		while (!Function.Call<bool>(Hash.HAS_CUTSCENE_LOADED, cutscene))
		{
			Function.Call(Hash.REQUEST_CUTSCENE, cutscene, 8);
			Script.Yield();
		}
		return cutscene;
	}

	public static string LoadDict(string dict)
	{
		while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, dict))
		{
			Function.Call(Hash.REQUEST_ANIM_DICT, dict);
			Script.Yield();
		}
		return dict;
	}

	public static string LoadStream(string name, string dict)
	{
		while (!Function.Call<bool>(Hash.LOAD_STREAM, name, dict))
		{
			Function.Call(Hash.LOAD_STREAM, name, dict);
			Script.Yield();
		}
		return dict;
	}

	public static int LoadStream(string name, int dict)
	{
		while (!Function.Call<bool>(Hash.LOAD_STREAM, name, dict))
		{
			Function.Call(Hash.LOAD_STREAM, name, dict);
			Script.Yield();
		}
		return dict;
	}

	public static Model RequestModel(int Name)
	{
		Model result = new Model(Name);
		result.Request(10000);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Model RequestModel(PedHash Name)
	{
		Model result = new Model(Name);
		result.Request(10000);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Model RequestModel(VehicleHash Name)
	{
		Model result = new Model(Name);
		result.Request(10000);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Model RequestModel(string Name)
	{
		Model result = new Model(Name);
		result.Request(250);
		if (result.IsInCdImage && result.IsValid)
		{
			while (!result.IsLoaded)
			{
				Script.Wait(50);
			}
			return result;
		}
		result.MarkAsNoLongerNeeded();
		return result;
	}

	public static Hash joaat(string hash)
	{
		return Function.Call<Hash>(Hash.GET_HASH_KEY, hash);
	}

	public static void SET_CAM_NORMAL()
	{
		CruelMastersOnlineOffline.CutsceneCam.Detach();
		CruelMastersOnlineOffline.CutsceneCam.StopPointing();
		CruelMastersOnlineOffline.CutsceneCam.Position = new Vector3(402.8563f, -999.9777f, -98.44982f);
		CruelMastersOnlineOffline.CutsceneCam.Rotation = new Vector3(-6.103765f, 0.008221734f, 43f / 75f);
	}
}
