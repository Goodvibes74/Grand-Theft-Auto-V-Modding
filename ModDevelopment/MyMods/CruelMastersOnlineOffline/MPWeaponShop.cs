using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Elements;
using LemonUI.Menus;

namespace CruelMastersOnlineOffline;

internal class MPWeaponShop : Script
{
	[StructLayout(LayoutKind.Explicit, Size = 312)]
	public struct DlcWeaponData
	{
		[FieldOffset(0)]
		public int validCheck;

		[FieldOffset(8)]
		public int weaponHash;

		[FieldOffset(24)]
		public int weaponCost;

		[FieldOffset(32)]
		public int ammoCost;

		[FieldOffset(40)]
		public int ammoType;

		[FieldOffset(48)]
		public int defaultClipSize;

		[FieldOffset(56)]
		public unsafe fixed byte nameLabel[64];

		[FieldOffset(120)]
		public unsafe fixed byte descLabel[64];

		[FieldOffset(184)]
		public unsafe fixed byte desc2Label[64];

		[FieldOffset(248)]
		public unsafe fixed byte upperCaseNameLabel[64];

		public bool IsValid => !Function.Call<bool>(GTA.Native.Hash.IS_CONTENT_ITEM_LOCKED, validCheck);

		public WeaponHash Hash => (WeaponHash)weaponHash;

		public unsafe string DisplayName
		{
			get
			{
				fixed (byte* value = nameLabel)
				{
					return PtrToStringUTF8(new IntPtr(value));
				}
			}
		}

		public unsafe string DescriptionLabel
		{
			get
			{
				fixed (byte* value = descLabel)
				{
					return PtrToStringUTF8(new IntPtr(value));
				}
			}
		}
	}

	[StructLayout(LayoutKind.Explicit, Size = 272)]
	internal struct DlcWeaponComponentData
	{
		[FieldOffset(0)]
		private int attachBone;

		[FieldOffset(8)]
		private int bActiveByDefault;

		[FieldOffset(24)]
		private int componentHash;

		[FieldOffset(40)]
		private int componentCost;

		[FieldOffset(48)]
		private unsafe fixed byte name[64];

		[FieldOffset(112)]
		private unsafe fixed byte desc[64];

		public WeaponComponentHash Hash => (WeaponComponentHash)componentHash;

		public WeaponAttachmentPoint AttachmentPoint => (WeaponAttachmentPoint)attachBone;

		public unsafe string DisplayName
		{
			get
			{
				fixed (byte* value = name)
				{
					return PtrToStringUTF8(new IntPtr(value));
				}
			}
		}

		public unsafe string DescriptionLabel
		{
			get
			{
				fixed (byte* value = desc)
				{
					return PtrToStringUTF8(new IntPtr(value));
				}
			}
		}
	}

	public static List<Ped> shopowners = new List<Ped>();

	public static ObjectPool MenuPool = new ObjectPool();

	public static NativeMenu GunStore;

	public static bool MenuIsOpen = false;

	private Prop[] gundoors = World.GetAllProps(97297972, -8873588);

	public MPWeaponShop()
	{
		Tick += onTick;
		Aborted += onShutdown;
		GunStore = new NativeMenu("", "SELECT AN OPTION");
		ScaledTexture banner = new ScaledTexture(GunStore.Banner.Position, new SizeF(GunStore.Banner.Size.Width, GunStore.Banner.Size.Height), "shopui_title_gunclub", "shopui_title_gunclub");
		GunStore.Banner = banner;
		GunStore.MouseBehavior = MenuMouseBehavior.Disabled;
		GunStore.CloseOnInvalidClick = false;
		MenuPool.Add(GunStore);
	}

	public unsafe static void SETUP_GUN_STORE_MENU()
	{
		OwnedWeapons weaponownership = XMLSerializer.DeserializeXML<OwnedWeapons>("scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
		MPLoadout weaponLoadout = XMLSerializer.DeserializeXML<MPLoadout>("scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\CurrentLoadout.xml");
		GunStore.Clear();
		ScaledTexture banner = new ScaledTexture(GunStore.Banner.Position, new SizeF(GunStore.Banner.Size.Width, GunStore.Banner.Size.Height), "shopui_title_gunclub", "shopui_title_gunclub");
		NativeMenu nativeMenu = new NativeMenu("", "Melee Weapons", "Browse for a Melee Weapon.");
		MenuPool.Add(nativeMenu);
		nativeMenu.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu.CloseOnInvalidClick = false;
		nativeMenu.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem = new NativeSubmenuItem(nativeMenu, GunStore);
		nativeSubmenuItem.AltTitle = "";
		GunStore.Add(0, nativeSubmenuItem);
		NativeMenu nativeMenu2 = new NativeMenu("", "Handguns", "Browse for a Handgun.");
		MenuPool.Add(nativeMenu2);
		nativeMenu2.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu2.CloseOnInvalidClick = false;
		nativeMenu2.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem2 = new NativeSubmenuItem(nativeMenu2, GunStore);
		nativeSubmenuItem2.AltTitle = "";
		GunStore.Add(1, nativeSubmenuItem2);
		NativeMenu nativeMenu3 = new NativeMenu("", "Submachine Guns", "Browse for a Submachine Gun.");
		MenuPool.Add(nativeMenu3);
		nativeMenu3.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu3.CloseOnInvalidClick = false;
		nativeMenu3.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem3 = new NativeSubmenuItem(nativeMenu3, GunStore);
		nativeSubmenuItem3.AltTitle = "";
		GunStore.Add(2, nativeSubmenuItem3);
		NativeMenu nativeMenu4 = new NativeMenu("", "Shotguns", "Browse for a Shotgun.");
		MenuPool.Add(nativeMenu4);
		nativeMenu4.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu4.CloseOnInvalidClick = false;
		nativeMenu4.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem4 = new NativeSubmenuItem(nativeMenu4, GunStore);
		nativeSubmenuItem4.AltTitle = "";
		GunStore.Add(3, nativeSubmenuItem4);
		NativeMenu nativeMenu5 = new NativeMenu("", "Assault Rifles", "Browse for a Assault Rifle.");
		MenuPool.Add(nativeMenu5);
		nativeMenu5.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu5.CloseOnInvalidClick = false;
		nativeMenu5.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem5 = new NativeSubmenuItem(nativeMenu5, GunStore);
		nativeSubmenuItem5.AltTitle = "";
		GunStore.Add(4, nativeSubmenuItem5);
		NativeMenu nativeMenu6 = new NativeMenu("", "Light Machine Guns", "Browse for a Light Machine Gun.");
		MenuPool.Add(nativeMenu6);
		nativeMenu6.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu6.CloseOnInvalidClick = false;
		nativeMenu6.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem6 = new NativeSubmenuItem(nativeMenu6, GunStore);
		nativeSubmenuItem6.AltTitle = "";
		GunStore.Add(5, nativeSubmenuItem6);
		NativeMenu nativeMenu7 = new NativeMenu("", "Sniper Rifles", "Browse for a Sniper Rifle.");
		MenuPool.Add(nativeMenu7);
		nativeMenu7.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu7.CloseOnInvalidClick = false;
		nativeMenu7.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem7 = new NativeSubmenuItem(nativeMenu7, GunStore);
		nativeSubmenuItem7.AltTitle = "";
		GunStore.Add(6, nativeSubmenuItem7);
		NativeMenu nativeMenu8 = new NativeMenu("", "Heavy Weapons", "Browse for a Heavy Weapon.");
		MenuPool.Add(nativeMenu8);
		nativeMenu8.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu8.CloseOnInvalidClick = false;
		nativeMenu8.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem8 = new NativeSubmenuItem(nativeMenu8, GunStore);
		nativeSubmenuItem8.AltTitle = "";
		GunStore.Add(7, nativeSubmenuItem8);
		NativeMenu nativeMenu9 = new NativeMenu("", "Throwables", "Browse for a Throwable.");
		MenuPool.Add(nativeMenu9);
		nativeMenu9.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu9.CloseOnInvalidClick = false;
		nativeMenu9.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem9 = new NativeSubmenuItem(nativeMenu9, GunStore);
		nativeSubmenuItem9.AltTitle = "";
		GunStore.Add(8, nativeSubmenuItem9);
		NativeMenu nativeMenu10 = new NativeMenu("", "Miscellaneous", "Browse for a Miscellaneous Item.");
		MenuPool.Add(nativeMenu10);
		nativeMenu10.MouseBehavior = MenuMouseBehavior.Disabled;
		nativeMenu10.CloseOnInvalidClick = false;
		nativeMenu10.Banner = banner;
		NativeSubmenuItem nativeSubmenuItem10 = new NativeSubmenuItem(nativeMenu10, GunStore);
		nativeSubmenuItem10.AltTitle = "";
		GunStore.Add(9, nativeSubmenuItem10);
		Dictionary<WeaponGroup, List<WeaponInfo>> dictionary = new Dictionary<WeaponGroup, List<WeaponInfo>>
		{
			[WeaponGroup.Melee] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.Knife, 400, 1, null, null, null, null, null, 0, 0),
				new WeaponInfo(WeaponHash.Hammer, 500, 1, null, null, null, null, null, 0, 0),
				new WeaponInfo(WeaponHash.Bottle, 300, 1, null, null, null, null, null, 0, 0),
				new WeaponInfo(WeaponHash.Dagger, 2000, 1, null, null, null, null, null, 0, 0),
				new WeaponInfo(WeaponHash.Hatchet, 750, 1, null, null, null, null, null, 0, 0),
				new WeaponInfo(WeaponHash.Nightstick, 400, 3, null, null, null, null, null, 0, 0)
			},
			[WeaponGroup.Pistol] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.Pistol, 2500, 1, new List<string> { "COMPONENT_PISTOL_CLIP_01", "COMPONENT_PISTOL_CLIP_02", "COMPONENT_AT_PI_FLSH", "COMPONENT_AT_PI_SUPP_02", "COMPONENT_PISTOL_VARMOD_LUXE" }, new List<int> { 0, 9175, 1675, 12050, 46500 }, new List<int> { 1, 3, 4, 5, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SUPP", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_FLASH", "WCD_PI_SUPP", "WCD_VAR_P" }, 24, 57),
				new WeaponInfo(WeaponHash.Pistol50, 2500, 1, new List<string> { "COMPONENT_PISTOL50_CLIP_01", "COMPONENT_PISTOL50_CLIP_02", "COMPONENT_AT_PI_FLSH", "COMPONENT_AT_AR_SUPP_02", "COMPONENT_PISTOL50_VARMOD_LUXE" }, new List<int> { 0, 9500, 2000, 12250, 50000 }, new List<int> { 1, 1, 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SUPP", "WCT_VAR_SIL" }, new List<string> { "WCD_P50_CLIP1", "WCD_P50_CLIP2", "WCD_FLASH", "WCD_PI_SUPP", "WCD_VAR_P50" }, 24, 57),
				new WeaponInfo(WeaponHash.CombatPistol, 3200, 9, new List<string> { "COMPONENT_COMBATPISTOL_CLIP_01", "COMPONENT_COMBATPISTOL_CLIP_02", "COMPONENT_AT_PI_FLSH", "COMPONENT_AT_PI_SUPP", "COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER" }, new List<int> { 0, 9200, 1825, 12100, 36250 }, new List<int> { 1, 10, 11, 12, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SUPP", "WCT_VAR_GOLD" }, new List<string> { "WCD_CP_CLIP1", "WCD_CP_CLIP2", "WCD_FLASH", "WCD_PI_SUPP", "WCD_VAR_CBP" }, 24, 57),
				new WeaponInfo(WeaponHash.APPistol, 5000, 33, new List<string> { "COMPONENT_APPISTOL_CLIP_01", "COMPONENT_APPISTOL_CLIP_02", "COMPONENT_AT_PI_FLSH", "COMPONENT_AT_PI_SUPP", "COMPONENT_APPISTOL_VARMOD_LUXE" }, new List<int> { 0, 9400, 1975, 12200, 39500 }, new List<int> { 1, 34, 35, 36, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SUPP", "WCT_VAR_METAL" }, new List<string> { "WCD_AP_CLIP1", "WCD_AP_CLIP2", "WCD_FLASH", "WCD_PI_SUPP", "WCD_VAR_AP" }, 16, 85),
				new WeaponInfo(WeaponHash.SNSPistol, 2750, 1, new List<string> { "COMPONENT_SNSPISTOL_CLIP_01", "COMPONENT_SNSPISTOL_CLIP_02", "COMPONENT_SNSPISTOL_VARMOD_LOWRIDER" }, new List<int> { 0, 9150, 34750 }, new List<int> { 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_VAR_WOOD" }, new List<string> { "WCD_P_CLIP1", "WCD_P_CLIP2", "WCD_VAR_SNS" }, 12, 29),
				new WeaponInfo(WeaponHash.HeavyPistol, 3750, 1, new List<string> { "COMPONENT_HEAVYPISTOL_CLIP_01", "COMPONENT_HEAVYPISTOL_CLIP_02", "COMPONENT_AT_PI_FLSH", "COMPONENT_AT_PI_SUPP", "COMPONENT_HEAVYPISTOL_VARMOD_LUXE" }, new List<int> { 0, 9200, 1775, 12100, 30000 }, new List<int> { 1, 1, 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SUPP", "WCT_VAR_WOOD" }, new List<string> { "WCD_P_CLIP1", "WCD_P_CLIP2", "WCD_FLASH", "WCD_PI_SUPP", "WCD_VAR_HPST" }, 36, 85),
				new WeaponInfo(WeaponHash.VintagePistol, 3450, 1, new List<string> { "COMPONENT_VINTAGEPISTOL_CLIP_01", "COMPONENT_VINTAGEPISTOL_CLIP_02", "COMPONENT_AT_PI_SUPP" }, new List<int> { 0, 9275, 12150 }, new List<int> { 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_SUPP" }, new List<string> { "WCD_P_CLIP1", "WCD_P_CLIP2", "WCD_PI_SUPP" }, 12, 29),
				new WeaponInfo(WeaponHash.UpNAtomizer, 0, 1, null, null, null, null, null, 0, 0)
			},
			[WeaponGroup.SMG] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.MicroSMG, 3750, 5, new List<string> { "COMPONENT_MICROSMG_CLIP_01", "COMPONENT_MICROSMG_CLIP_02", "COMPONENT_AT_PI_FLSH", "COMPONENT_AT_SCOPE_MACRO", "COMPONENT_AT_AR_SUPP_02", "COMPONENT_MICROSMG_VARMOD_LUXE" }, new List<int> { 0, 9325, 1900, 10800, 12150, 37750 }, new List<int> { 5, 6, 7, 8, 9, 5 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SCOPE_MAC", "WCT_SUPP", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_FLASH", "WCD_SCOPE_MAC", "WCD_PI_SUPP", "WCD_VAR_P" }, 32, 60),
				new WeaponInfo(WeaponHash.SMG, 7500, 11, new List<string> { "COMPONENT_SMG_CLIP_01", "COMPONENT_SMG_CLIP_02", "COMPONENT_SMG_CLIP_03", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SCOPE_MACRO_02", "COMPONENT_AT_PI_SUPP", "COMPONENT_SMG_VARMOD_LUXE" }, new List<int> { 0, 9475, 23600, 2050, 10825, 12250, 48250 }, new List<int> { 11, 12, 13, 13, 14, 15, 11 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_CLIP_DRM", "WCT_FLASH", "WCT_SCOPE_MAC", "WCT_SUPP", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_CLIP3", "WCD_FLASH", "WCD_SCOPE_MAC", "WCD_PI_SUPP", "WCD_VAR_P" }, 60, 113),
				new WeaponInfo(WeaponHash.AssaultSMG, 12550, 29, new List<string> { "COMPONENT_ASSAULTSMG_CLIP_01", "COMPONENT_ASSAULTSMG_CLIP_02", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_SCOPE_MACRO", "COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER" }, new List<int> { 0, 9700, 2275, 12400, 10875, 44000 }, new List<int> { 29, 30, 31, 32, 33, 29 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SUPP", "WCT_SCOPE_MAC", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_FLASH", "WCD_PI_SUPP", "WCD_SCOPE_MAC", "WCD_VAR_P" }, 60, 113)
			},
			[WeaponGroup.Shotgun] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.SawnOffShotgun, 2500, 1, new List<string> { "COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE" }, new List<int> { 34250 }, new List<int> { 1 }, new List<string> { "WCT_VAR_METAL" }, new List<string> { "WCD_VAR_P" }, 16, 24),
				new WeaponInfo(WeaponHash.PumpShotgun, 3500, 17, new List<string> { "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SR_SUPP", "COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER" }, new List<int> { 1750, 12350, 42250 }, new List<int> { 18, 19, 11 }, new List<string> { "WCT_FLASH", "WCT_SUPP", "WCT_VAR_GOLD" }, new List<string> { "WCD_FLASH", "WCD_AR_SUPP", "WCD_VAR_P" }, 16, 24),
				new WeaponInfo(WeaponHash.AssaultShotgun, 10000, 37, new List<string> { "COMPONENT_ASSAULTSHOTGUN_CLIP_01", "COMPONENT_ASSAULTSHOTGUN_CLIP_02", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_AR_SUPP" }, new List<int> { 0, 9625, 4275, 2200, 12350 }, new List<int> { 37, 38, 39, 40, 41 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_GRIP", "WCT_FLASH", "WCT_SUPP" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_GRIP", "WCD_FLASH", "WCD_AR_SUPP" }, 16, 24),
				new WeaponInfo(WeaponHash.BullpupShotgun, 8000, 1, new List<string> { "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_AR_SUPP_02" }, new List<int> { 4100, 2300, 12450 }, new List<int> { 2, 3, 4 }, new List<string> { "WCT_GRIP", "WCT_FLASH", "WCT_SUPP" }, new List<string> { "WCD_GRIP", "WCD_FLASH", "WCD_AR_SUPP" }, 16, 24),
				new WeaponInfo(WeaponHash.Musket, 21400, 1, null, null, null, null, null, 2, 3),
				new WeaponInfo(WeaponHash.HeavyShotgun, 13550, 1, new List<string> { "COMPONENT_HEAVYSHOTGUN_CLIP_01", "COMPONENT_HEAVYSHOTGUN_CLIP_02", "COMPONENT_HEAVYSHOTGUN_CLIP_03", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_AR_SUPP_02" }, new List<int> { 0, 9900, 26200, 4375, 2400, 12475 }, new List<int> { 1, 1, 1, 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_CLIP_DRM", "WCT_GRIP", "WCT_FLASH", "WCT_SUPP" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_CLIP3", "WCD_GRIP", "WCD_FLASH", "WCD_AR_SUPP" }, 12, 18)
			},
			[WeaponGroup.AssaultRifle] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.AssaultRifle, 8550, 24, new List<string> { "COMPONENT_ASSAULTRIFLE_CLIP_01", "COMPONENT_ASSAULTRIFLE_CLIP_02", "COMPONENT_ASSAULTRIFLE_CLIP_03", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SCOPE_MACRO", "COMPONENT_AT_AR_SUPP_02", "COMPONENT_ASSAULTRIFLE_VARMOD_LUXE" }, new List<int> { 0, 9550, 24250, 4200, 2125, 10850, 12300, 36000 }, new List<int> { 24, 25, 26, 26, 27, 28, 29, 24 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_CLIP_DRM", "WCT_GRIP", "WCT_FLASH", "WCT_SCOPE_MAC", "WCT_SUPP", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_CLIP3", "WCD_GRIP", "WCD_FLASH", "WCD_SCOPE_MAC", "WCD_AR_SUPP", "WCD_VAR_P" }, 60, 108),
				new WeaponInfo(WeaponHash.CarbineRifle, 13000, 42, new List<string> { "COMPONENT_CARBINERIFLE_CLIP_01", "COMPONENT_CARBINERIFLE_CLIP_02", "COMPONENT_CARBINERIFLE_CLIP_03", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SCOPE_MEDIUM", "COMPONENT_AT_AR_SUPP", "COMPONENT_CARBINERIFLE_VARMOD_LUXE" }, new List<int> { 0, 9775, 25550, 4350, 2350, 10900, 12450, 44750 }, new List<int> { 42, 43, 44, 44, 45, 46, 47, 42 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_CLIP_BOX", "WCT_GRIP", "WCT_FLASH", "WCT_SCOPE_MED", "WCT_SUPP", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_CLIP3", "WCD_GRIP", "WCD_FLASH", "WCD_SCOPE_MED", "WCD_AR_SUPP", "WCD_VAR_P" }, 60, 108),
				new WeaponInfo(WeaponHash.AdvancedRifle, 14250, 70, new List<string> { "COMPONENT_ADVANCEDRIFLE_CLIP_01", "COMPONENT_ADVANCEDRIFLE_CLIP_02", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SCOPE_SMALL", "COMPONENT_AT_AR_SUPP", "COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE" }, new List<int> { 0, 9925, 2425, 10950, 12500, 41250 }, new List<int> { 70, 71, 72, 73, 74, 70 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SCOPE_SML", "WCT_SUPP", "WCT_VAR_METAL" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_FLASH", "WCD_SCOPE_SML", "WCD_AR_SUPP", "WCD_VAR_P" }, 60, 108),
				new WeaponInfo(WeaponHash.SpecialCarbine, 14750, 1, new List<string> { "COMPONENT_SPECIALCARBINE_CLIP_01", "COMPONENT_SPECIALCARBINE_CLIP_02", "COMPONENT_SPECIALCARBINE_CLIP_03", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SCOPE_MEDIUM", "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER" }, new List<int> { 0, 9975, 27500, 2525, 11500, 12500, 4350, 45000 }, new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_CLIP_DRM", "WCT_FLASH", "WCT_SCOPE_MED", "WCT_SUPP", "WCT_GRIP", "WCT_VAR_ETCHM" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_CLIP3", "WCD_FLASH", "WCD_SCOPE_MED", "WCD_AR_SUPP", "WCD_GRIP", "WCD_VAR_SCAR" }, 60, 108),
				new WeaponInfo(WeaponHash.BullpupRifle, 14500, 1, new List<string> { "COMPONENT_BULLPUPRIFLE_CLIP_01", "COMPONENT_BULLPUPRIFLE_CLIP_02", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SCOPE_SMALL", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_AR_SUPP", "COMPONENT_BULLPUPRIFLE_VARMOD_LOW" }, new List<int> { 0, 9950, 2575, 11350, 4275, 12500, 41500 }, new List<int> { 1, 1, 1, 1, 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SCOPE_SML", "WCT_GRIP", "WCT_SUPP", "WCT_VAR_METAL" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_FLASH", "WCD_SCOPE_SML", "WCD_GRIP", "WCD_AR_SUPP", "WCD_VAR_BPR" }, 60, 108)
			},
			[WeaponGroup.MG] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.MG, 13500, 50, new List<string> { "COMPONENT_MG_CLIP_01", "COMPONENT_MG_CLIP_02", "COMPONENT_AT_SCOPE_SMALL_02", "COMPONENT_MG_VARMOD_LOWRIDER" }, new List<int> { 0, 9850, 10925, 39000 }, new List<int> { 50, 51, 52, 50 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_SCOPE_SML", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_SCOPE_SML", "WCD_VAR_P" }, 108, 150),
				new WeaponInfo(WeaponHash.CombatMG, 14800, 80, new List<string> { "COMPONENT_COMBATMG_CLIP_01", "COMPONENT_COMBATMG_CLIP_02", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_SCOPE_MEDIUM", "COMPONENT_COMBATMG_VARMOD_LOWRIDER" }, new List<int> { 0, 10000, 4425, 10975, 35000 }, new List<int> { 80, 81, 82, 83, 80 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_GRIP", "WCT_SCOPE_SML", "WCT_VAR_ETCHM" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_GRIP", "WCD_SCOPE_SML", "WCD_VAR_P" }, 200, 277),
				new WeaponInfo(WeaponHash.Gusenberg, 14600, 1, new List<string> { "COMPONENT_GUSENBERG_CLIP_01", "COMPONENT_GUSENBERG_CLIP_02" }, new List<int> { 0, 9960 }, new List<int> { 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2" }, 60, 83)
			},
			[WeaponGroup.Sniper] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.SniperRifle, 20000, 21, new List<string> { "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_SCOPE_MAX", "COMPONENT_SNIPERRIFLE_VARMOD_LUXE" }, new List<int> { 0, 12050, 12500, 32500 }, new List<int> { 21, 22, 23, 21 }, new List<string> { "WCT_SUPP", "WCT_SCOPE_MAX", "WCT_VAR_WOOD" }, new List<string> { "WCD_SR_SUPP", "WCD_SCOPE_MAX", "WCD_VAR_P" }, 20, 145),
				new WeaponInfo(WeaponHash.HeavySniper, 38150, 90, new List<string> { "COMPONENT_AT_SCOPE_LARGE", "COMPONENT_AT_SCOPE_MAX" }, new List<int> { 0, 12500 }, new List<int> { 90, 91 }, new List<string> { "WCT_SCOPE_LRG", "WCT_SCOPE_MAX" }, new List<string> { "WCD_SCOPE_LRG", "WCD_SCOPE_MAX" }, 12, 87),
				new WeaponInfo(WeaponHash.MarksmanRifle, 15750, 1, new List<string> { "COMPONENT_MARKSMANRIFLE_CLIP_01", "COMPONENT_MARKSMANRIFLE_CLIP_02", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_AR_SUPP", "COMPONENT_AT_AR_AFGRIP", "COMPONENT_MARKSMANRIFLE_VARMOD_LUXE" }, new List<int> { 0, 9030, 2550, 12500, 4400, 43000 }, new List<int> { 1, 1, 1, 1, 1, 1 }, new List<string> { "WCT_CLIP1", "WCT_CLIP2", "WCT_FLASH", "WCT_SUPP", "WCT_GRIP", "WCT_VAR_GOLD" }, new List<string> { "WCD_CLIP1", "WCD_CLIP2", "WCD_FLASH", "WCD_AR_SUPP", "WCD_GRIP", "WCD_VAR_MKRF" }, 16, 116)
			},
			[WeaponGroup.Heavy] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.GrenadeLauncher, 32400, 60, new List<string> { "COMPONENT_AT_AR_AFGRIP", "COMPONENT_AT_AR_FLSH", "COMPONENT_AT_SCOPE_SMALL" }, new List<int> { 4500, 2500, 11000 }, new List<int> { 61, 62, 63 }, new List<string> { "WCT_GRIP", "WCT_FLASH", "WCT_SCOPE_MAC" }, new List<string> { "WCD_GRIP", "WCD_FLASH", "WCD_SCOPE_SML" }, 1, 250),
				new WeaponInfo(WeaponHash.RPG, 26250, 100, null, null, null, null, null, 2, 1000),
				new WeaponInfo(WeaponHash.Minigun, 47000, 120, null, null, null, null, null, 100, 150),
				new WeaponInfo(WeaponHash.Firework, 0, 1, null, null, null, null, null, 2, 1200),
				new WeaponInfo(WeaponHash.HomingLauncher, 75000, 1, null, null, null, null, null, 2, 1500)
			},
			[WeaponGroup.Thrown] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.Grenade, 250, 15, null, null, null, null, null, 1, 250),
				new WeaponInfo(WeaponHash.StickyBomb, 600, 19, null, null, null, null, null, 1, 600),
				new WeaponInfo(WeaponHash.BZGas, 150, 13, null, null, null, null, null, 1, 150),
				new WeaponInfo(WeaponHash.Molotov, 200, 31, null, null, null, null, null, 1, 200),
				new WeaponInfo(WeaponHash.Flare, 8000, 50, null, null, null, null, null, 1, 8000),
				new WeaponInfo(WeaponHash.PetrolCan, 100, 21, null, null, null, null, null, 1000, 100),
				new WeaponInfo(WeaponHash.ProximityMine, 1000, 1, null, null, null, null, null, 1, 1000)
			},
			[WeaponGroup.Parachute] = new List<WeaponInfo>
			{
				new WeaponInfo(WeaponHash.Parachute, 0, 1, null, null, null, null, null, 1, 0)
			}
		};
		for (int i = 0; i < dictionary[WeaponGroup.Melee].Count; i++)
		{
			string text = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.Melee][i].weaponHash));
			string description = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.Melee][i].weaponHash));
			int weaponcost = dictionary[WeaponGroup.Melee][i].weaponCost;
			int rankNeeded = dictionary[WeaponGroup.Melee][i].rankNeeded;
			WeaponHash weaponHash = dictionary[WeaponGroup.Melee][i].weaponHash;
			List<string> compHashName = dictionary[WeaponGroup.Melee][i].compHashName;
			List<string> compLabel = dictionary[WeaponGroup.Melee][i].compLabel;
			List<string> compDesc = dictionary[WeaponGroup.Melee][i].compDesc;
			List<int> compCost = dictionary[WeaponGroup.Melee][i].compCost;
			List<int> compRank = dictionary[WeaponGroup.Melee][i].compRank;
			NativeMenu nativeMenu11 = new NativeMenu("", text, "");
			MenuPool.Add(nativeMenu11);
			nativeMenu11.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu11.CloseOnInvalidClick = false;
			nativeMenu11.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem11 = new NativeSubmenuItem(nativeMenu11, nativeMenu);
			nativeSubmenuItem11.AltTitle = "";
			nativeSubmenuItem11.Title = text;
			nativeMenu.Add(nativeSubmenuItem11);
			NativeItem WeaponsItem = new NativeItem(text, description, "");
			if (!weaponownership.Weapon.Contains(weaponHash))
			{
				if (MPRank.PlayerLevel >= rankNeeded)
				{
					WeaponsItem.AltTitle = $"${weaponcost}";
					WeaponsItem.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost))
						{
							if (!weaponownership.Weapon.Contains(weaponHash))
							{
								weaponownership.Weapon.Add(weaponHash);
							}
							Game.Player.Character.Weapons.Give(weaponHash, 1, equipNow: false, isAmmoLoaded: true);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							WeaponsItem.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem.Description = $"This item unlocks at Rank {rankNeeded}.";
					BadgeSet badgeSet = new BadgeSet();
					badgeSet.NormalDictionary = "commonmenu";
					badgeSet.NormalTexture = "shop_lock";
					badgeSet.HoveredDictionary = "commonmenu";
					badgeSet.HoveredTexture = "shop_lock";
					WeaponsItem.RightBadgeSet = badgeSet;
				}
			}
			else
			{
				BadgeSet badgeSet2 = new BadgeSet();
				badgeSet2.NormalDictionary = "commonmenu";
				badgeSet2.NormalTexture = "shop_gunclub_icon_a";
				badgeSet2.HoveredDictionary = "commonmenu";
				badgeSet2.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem.RightBadgeSet = badgeSet2;
			}
			nativeMenu11.Add(WeaponsItem);
			if (compHashName == null)
			{
				continue;
			}
			for (int num = 0; num < compHashName.Count; num++)
			{
				WeaponComponentHash compShopName = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName[num]);
				string text2 = "";
				string text3 = "";
				int compShopCost = 0;
				int num2 = 0;
				text2 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel[num]);
				text3 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc[num]);
				compShopCost = compCost[num];
				num2 = compRank[num];
				NativeItem WeaponsCompItem = new NativeItem(text2, text3, $"${compShopCost}");
				WeaponsCompItem.AltTitle = "";
				if (!weaponownership.Components.Contains(compShopName))
				{
					if (MPRank.PlayerLevel >= num2)
					{
						WeaponsCompItem.AltTitle = $"${compShopCost}";
						WeaponsCompItem.Activated += (object sender, EventArgs e) =>
						{
							if (weaponownership.Weapon.Contains(weaponHash))
							{
								if (MPCash.PROCESS_TRANSACTION(compShopCost))
								{
									if (!weaponownership.Components.Contains(compShopName))
									{
										weaponownership.Components.Add(compShopName);
									}
									Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash, compShopName);
									MPLoadout.SAVE_CURRENT_LOADOUT();
									XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
									WeaponsCompItem.AltTitle = "";
									BadgeSet rightBadgeSet = new BadgeSet
									{
										NormalDictionary = "commonmenu",
										NormalTexture = "shop_gunclub_icon_a",
										HoveredDictionary = "commonmenu",
										HoveredTexture = "shop_gunclub_icon_b"
									};
									WeaponsCompItem.RightBadgeSet = rightBadgeSet;
								}
								else
								{
									Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
								}
							}
							else
							{
								Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
							}
						};
					}
					else
					{
						WeaponsCompItem.Description = $"This item unlocks at Rank {num2}.";
						BadgeSet badgeSet3 = new BadgeSet();
						badgeSet3.NormalDictionary = "commonmenu";
						badgeSet3.NormalTexture = "shop_lock";
						badgeSet3.HoveredDictionary = "commonmenu";
						badgeSet3.HoveredTexture = "shop_lock";
						WeaponsCompItem.RightBadgeSet = badgeSet3;
					}
				}
				else
				{
					WeaponsCompItem.AltTitle = "";
					BadgeSet badgeSet4 = new BadgeSet();
					badgeSet4.NormalDictionary = "commonmenu";
					badgeSet4.NormalTexture = "shop_gunclub_icon_a";
					badgeSet4.HoveredDictionary = "commonmenu";
					badgeSet4.HoveredTexture = "shop_gunclub_icon_b";
					WeaponsCompItem.RightBadgeSet = badgeSet4;
					WeaponsCompItem.Activated += (object sender, EventArgs e) =>
					{
						Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash, compShopName);
						MPLoadout.SAVE_CURRENT_LOADOUT();
						Notification.Show("Component Equipped", blinking: true);
					};
				}
				nativeMenu11.Add(WeaponsCompItem);
			}
		}
		for (int num3 = 0; num3 < dictionary[WeaponGroup.Pistol].Count; num3++)
		{
			string text4 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.Pistol][num3].weaponHash));
			string description2 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.Pistol][num3].weaponHash));
			if (dictionary[WeaponGroup.Pistol][num3].weaponHash == WeaponHash.Pistol)
			{
				description2 = "Standard Pistol.";
			}
			int weaponcost2 = dictionary[WeaponGroup.Pistol][num3].weaponCost;
			int rankNeeded2 = dictionary[WeaponGroup.Pistol][num3].rankNeeded;
			WeaponHash weaponHash2 = dictionary[WeaponGroup.Pistol][num3].weaponHash;
			List<string> compHashName2 = dictionary[WeaponGroup.Pistol][num3].compHashName;
			List<string> compLabel2 = dictionary[WeaponGroup.Pistol][num3].compLabel;
			List<string> compDesc2 = dictionary[WeaponGroup.Pistol][num3].compDesc;
			List<int> compCost2 = dictionary[WeaponGroup.Pistol][num3].compCost;
			List<int> compRank2 = dictionary[WeaponGroup.Pistol][num3].compRank;
			int ammoPer = dictionary[WeaponGroup.Pistol][num3].AmmoPer;
			int ammoCost = dictionary[WeaponGroup.Pistol][num3].AmmoCost;
			NativeMenu nativeMenu12 = new NativeMenu("", text4, "");
			MenuPool.Add(nativeMenu12);
			nativeMenu12.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu12.CloseOnInvalidClick = false;
			nativeMenu12.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem12 = new NativeSubmenuItem(nativeMenu12, nativeMenu2);
			nativeSubmenuItem12.AltTitle = "";
			nativeSubmenuItem12.Title = text4;
			nativeMenu2.Add(nativeSubmenuItem12);
			NativeItem WeaponsItem2 = new NativeItem(text4, description2, "");
			if (!weaponownership.Weapon.Contains(weaponHash2))
			{
				if (MPRank.PlayerLevel >= rankNeeded2)
				{
					WeaponsItem2.AltTitle = $"${weaponcost2}";
					WeaponsItem2.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost2))
						{
							if (!weaponownership.Weapon.Contains(weaponHash2))
							{
								weaponownership.Weapon.Add(weaponHash2);
							}
							Game.Player.Character.Weapons.Give(weaponHash2, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem2.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem2.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem2.Description = $"This item unlocks at Rank {rankNeeded2}.";
					BadgeSet badgeSet5 = new BadgeSet();
					badgeSet5.NormalDictionary = "commonmenu";
					badgeSet5.NormalTexture = "shop_lock";
					badgeSet5.HoveredDictionary = "commonmenu";
					badgeSet5.HoveredTexture = "shop_lock";
					WeaponsItem2.RightBadgeSet = badgeSet5;
				}
			}
			else
			{
				BadgeSet badgeSet6 = new BadgeSet();
				badgeSet6.NormalDictionary = "commonmenu";
				badgeSet6.NormalTexture = "shop_gunclub_icon_a";
				badgeSet6.HoveredDictionary = "commonmenu";
				badgeSet6.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem2.RightBadgeSet = badgeSet6;
			}
			nativeMenu12.Add(WeaponsItem2);
			if (compHashName2 != null)
			{
				for (int num4 = 0; num4 < compHashName2.Count; num4++)
				{
					WeaponComponentHash compShopName2 = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName2[num4]);
					string text5 = "";
					string text6 = "";
					int compShopCost2 = 0;
					int compShopRank = 0;
					text5 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel2[num4]);
					text6 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc2[num4]);
					compShopCost2 = compCost2[num4];
					compShopRank = compRank2[num4];
					NativeItem WeaponsCompItem2 = new NativeItem(text5, text6, $"${compShopCost2}");
					WeaponsCompItem2.AltTitle = "";
					if (!weaponownership.Components.Contains(compShopName2))
					{
						if (MPRank.PlayerLevel >= compShopRank)
						{
							WeaponsCompItem2.AltTitle = $"${compShopCost2}";
						}
						else
						{
							WeaponsCompItem2.Description = $"This item unlocks at Rank {compShopRank}.";
							BadgeSet badgeSet7 = new BadgeSet();
							badgeSet7.NormalDictionary = "commonmenu";
							badgeSet7.NormalTexture = "shop_lock";
							badgeSet7.HoveredDictionary = "commonmenu";
							badgeSet7.HoveredTexture = "shop_lock";
							WeaponsCompItem2.RightBadgeSet = badgeSet7;
						}
					}
					else
					{
						WeaponsCompItem2.AltTitle = "";
						BadgeSet badgeSet8 = new BadgeSet();
						if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash2, compShopName2))
						{
							badgeSet8.NormalDictionary = "commonmenu";
							badgeSet8.NormalTexture = "shop_tick_icon";
							badgeSet8.HoveredDictionary = "commonmenu";
							badgeSet8.HoveredTexture = "shop_tick_icon";
							WeaponsCompItem2.RightBadgeSet = badgeSet8;
						}
						else
						{
							badgeSet8.NormalDictionary = "commonmenu";
							badgeSet8.NormalTexture = "shop_gunclub_icon_a";
							badgeSet8.HoveredDictionary = "commonmenu";
							badgeSet8.HoveredTexture = "shop_gunclub_icon_b";
							WeaponsCompItem2.RightBadgeSet = badgeSet8;
						}
					}
					WeaponsCompItem2.Activated += (object sender, EventArgs e) =>
					{
						if (!weaponownership.Components.Contains(compShopName2) && !weaponLoadout.CurrentLoadout[0].Components.Contains(compShopName2))
						{
							if (MPRank.PlayerLevel >= compShopRank)
							{
								WeaponsCompItem2.AltTitle = $"${compShopCost2}";
								if (weaponownership.Weapon.Contains(weaponHash2))
								{
									if (MPCash.PROCESS_TRANSACTION(compShopCost2))
									{
										if (!weaponownership.Components.Contains(compShopName2))
										{
											weaponownership.Components.Add(compShopName2);
										}
										Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash2, compShopName2);
										MPLoadout.SAVE_CURRENT_LOADOUT();
										XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
										WeaponsCompItem2.AltTitle = "";
										BadgeSet rightBadgeSet = new BadgeSet
										{
											NormalDictionary = "commonmenu",
											NormalTexture = "shop_gunclub_icon_a",
											HoveredDictionary = "commonmenu",
											HoveredTexture = "shop_gunclub_icon_b"
										};
										WeaponsCompItem2.RightBadgeSet = rightBadgeSet;
									}
									else
									{
										Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
									}
								}
								else
								{
									Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
								}
							}
							else
							{
								WeaponsCompItem2.Description = $"This item unlocks at Rank {compShopRank}.";
								BadgeSet rightBadgeSet2 = new BadgeSet
								{
									NormalDictionary = "commonmenu",
									NormalTexture = "shop_lock",
									HoveredDictionary = "commonmenu",
									HoveredTexture = "shop_lock"
								};
								WeaponsCompItem2.RightBadgeSet = rightBadgeSet2;
							}
						}
						else if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash2, compShopName2))
						{
							Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash2, compShopName2);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Equipped", blinking: true);
							BadgeSet rightBadgeSet3 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsCompItem2.RightBadgeSet = rightBadgeSet3;
						}
						else
						{
							Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, weaponHash2, compShopName2);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Unequipped", blinking: true);
							BadgeSet rightBadgeSet4 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_tick_icon",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_tick_icon"
							};
							WeaponsCompItem2.RightBadgeSet = rightBadgeSet4;
						}
					};
					nativeMenu12.Add(WeaponsCompItem2);
				}
			}
			NativeListItem<int> WeaponsTintItem = new NativeListItem<int>("Tint", "0 - Normal~n~1 - Green~n~2 - Gold~n~3 - Pink~n~4 - Army~n~5 - LSPD~n~6 - Orange~n~7 - Platinum", 0, 1, 2, 3, 4, 5, 6, 7);
			if (Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash2) >= 0)
			{
				WeaponsTintItem.SelectedIndex = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash2);
			}
			WeaponsTintItem.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
			{
				Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash2, WeaponsTintItem.SelectedItem);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				Notification.Show("Tint Changed", blinking: true);
			};
			if (WeaponsTintItem.Items.Count > 0)
			{
				nativeMenu12.Add(WeaponsTintItem);
			}
			NativeItem WeaponsAmmoItem = new NativeItem($"Rounds x {ammoPer}", "", $"${ammoCost}");
			int num5 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash2, &num5))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash2) < num5)
				{
					WeaponsAmmoItem.AltTitle = $"${ammoCost}";
					WeaponsAmmoItem.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem.AltTitle = "FULL";
					WeaponsAmmoItem.Enabled = false;
				}
			}
			WeaponsAmmoItem.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash2, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash2) < num27)
					{
						WeaponsAmmoItem.AltTitle = $"${ammoCost}";
						WeaponsAmmoItem.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash2))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost))
							{
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash2, ammoPer);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem.AltTitle = "FULL";
						WeaponsAmmoItem.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu12.Add(WeaponsAmmoItem);
		}
		for (int num6 = 0; num6 < dictionary[WeaponGroup.SMG].Count; num6++)
		{
			string text7 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.SMG][num6].weaponHash));
			string description3 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.SMG][num6].weaponHash));
			int weaponcost3 = dictionary[WeaponGroup.SMG][num6].weaponCost;
			int rankNeeded3 = dictionary[WeaponGroup.SMG][num6].rankNeeded;
			WeaponHash weaponHash3 = dictionary[WeaponGroup.SMG][num6].weaponHash;
			List<string> compHashName3 = dictionary[WeaponGroup.SMG][num6].compHashName;
			List<string> compLabel3 = dictionary[WeaponGroup.SMG][num6].compLabel;
			List<string> compDesc3 = dictionary[WeaponGroup.SMG][num6].compDesc;
			List<int> compCost3 = dictionary[WeaponGroup.SMG][num6].compCost;
			List<int> compRank3 = dictionary[WeaponGroup.SMG][num6].compRank;
			int ammoPer2 = dictionary[WeaponGroup.SMG][num6].AmmoPer;
			int ammoCost2 = dictionary[WeaponGroup.SMG][num6].AmmoCost;
			NativeMenu nativeMenu13 = new NativeMenu("", text7, "");
			MenuPool.Add(nativeMenu13);
			nativeMenu13.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu13.CloseOnInvalidClick = false;
			nativeMenu13.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem13 = new NativeSubmenuItem(nativeMenu13, nativeMenu3);
			nativeSubmenuItem13.AltTitle = "";
			nativeSubmenuItem13.Title = text7;
			nativeMenu3.Add(nativeSubmenuItem13);
			NativeItem WeaponsItem3 = new NativeItem(text7, description3, "");
			if (!weaponownership.Weapon.Contains(weaponHash3))
			{
				if (MPRank.PlayerLevel >= rankNeeded3)
				{
					WeaponsItem3.AltTitle = $"${weaponcost3}";
					WeaponsItem3.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost3))
						{
							if (!weaponownership.Weapon.Contains(weaponHash3))
							{
								weaponownership.Weapon.Add(weaponHash3);
							}
							Game.Player.Character.Weapons.Give(weaponHash3, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem3.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem3.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem3.Description = $"This item unlocks at Rank {rankNeeded3}.";
					BadgeSet badgeSet9 = new BadgeSet();
					badgeSet9.NormalDictionary = "commonmenu";
					badgeSet9.NormalTexture = "shop_lock";
					badgeSet9.HoveredDictionary = "commonmenu";
					badgeSet9.HoveredTexture = "shop_lock";
					WeaponsItem3.RightBadgeSet = badgeSet9;
				}
			}
			else
			{
				BadgeSet badgeSet10 = new BadgeSet();
				badgeSet10.NormalDictionary = "commonmenu";
				badgeSet10.NormalTexture = "shop_gunclub_icon_a";
				badgeSet10.HoveredDictionary = "commonmenu";
				badgeSet10.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem3.RightBadgeSet = badgeSet10;
			}
			nativeMenu13.Add(WeaponsItem3);
			if (compHashName3 != null)
			{
				for (int num7 = 0; num7 < compHashName3.Count; num7++)
				{
					WeaponComponentHash compShopName3 = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName3[num7]);
					string text8 = "";
					string text9 = "";
					int compShopCost3 = 0;
					int compShopRank2 = 0;
					text8 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel3[num7]);
					text9 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc3[num7]);
					compShopCost3 = compCost3[num7];
					compShopRank2 = compRank3[num7];
					NativeItem WeaponsCompItem3 = new NativeItem(text8, text9, $"${compShopCost3}");
					WeaponsCompItem3.AltTitle = "";
					if (!weaponownership.Components.Contains(compShopName3))
					{
						if (MPRank.PlayerLevel >= compShopRank2)
						{
							WeaponsCompItem3.AltTitle = $"${compShopCost3}";
						}
						else
						{
							WeaponsCompItem3.Description = $"This item unlocks at Rank {compShopRank2}.";
							BadgeSet badgeSet11 = new BadgeSet();
							badgeSet11.NormalDictionary = "commonmenu";
							badgeSet11.NormalTexture = "shop_lock";
							badgeSet11.HoveredDictionary = "commonmenu";
							badgeSet11.HoveredTexture = "shop_lock";
							WeaponsCompItem3.RightBadgeSet = badgeSet11;
						}
					}
					else
					{
						WeaponsCompItem3.AltTitle = "";
						BadgeSet badgeSet12 = new BadgeSet();
						if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash3, compShopName3))
						{
							badgeSet12.NormalDictionary = "commonmenu";
							badgeSet12.NormalTexture = "shop_tick_icon";
							badgeSet12.HoveredDictionary = "commonmenu";
							badgeSet12.HoveredTexture = "shop_tick_icon";
							WeaponsCompItem3.RightBadgeSet = badgeSet12;
						}
						else
						{
							badgeSet12.NormalDictionary = "commonmenu";
							badgeSet12.NormalTexture = "shop_gunclub_icon_a";
							badgeSet12.HoveredDictionary = "commonmenu";
							badgeSet12.HoveredTexture = "shop_gunclub_icon_b";
							WeaponsCompItem3.RightBadgeSet = badgeSet12;
						}
					}
					WeaponsCompItem3.Activated += (object sender, EventArgs e) =>
					{
						if (!weaponownership.Components.Contains(compShopName3) && !weaponLoadout.CurrentLoadout[0].Components.Contains(compShopName3))
						{
							if (MPRank.PlayerLevel >= compShopRank2)
							{
								WeaponsCompItem3.AltTitle = $"${compShopCost3}";
								if (weaponownership.Weapon.Contains(weaponHash3))
								{
									if (MPCash.PROCESS_TRANSACTION(compShopCost3))
									{
										if (!weaponownership.Components.Contains(compShopName3))
										{
											weaponownership.Components.Add(compShopName3);
										}
										Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash3, compShopName3);
										MPLoadout.SAVE_CURRENT_LOADOUT();
										XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
										WeaponsCompItem3.AltTitle = "";
										BadgeSet rightBadgeSet = new BadgeSet
										{
											NormalDictionary = "commonmenu",
											NormalTexture = "shop_gunclub_icon_a",
											HoveredDictionary = "commonmenu",
											HoveredTexture = "shop_gunclub_icon_b"
										};
										WeaponsCompItem3.RightBadgeSet = rightBadgeSet;
									}
									else
									{
										Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
									}
								}
								else
								{
									Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
								}
							}
							else
							{
								WeaponsCompItem3.Description = $"This item unlocks at Rank {compShopRank2}.";
								BadgeSet rightBadgeSet2 = new BadgeSet
								{
									NormalDictionary = "commonmenu",
									NormalTexture = "shop_lock",
									HoveredDictionary = "commonmenu",
									HoveredTexture = "shop_lock"
								};
								WeaponsCompItem3.RightBadgeSet = rightBadgeSet2;
							}
						}
						else if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash3, compShopName3))
						{
							Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash3, compShopName3);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Equipped", blinking: true);
							BadgeSet rightBadgeSet3 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsCompItem3.RightBadgeSet = rightBadgeSet3;
						}
						else
						{
							Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, weaponHash3, compShopName3);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Unequipped", blinking: true);
							BadgeSet rightBadgeSet4 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_tick_icon",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_tick_icon"
							};
							WeaponsCompItem3.RightBadgeSet = rightBadgeSet4;
						}
					};
					nativeMenu13.Add(WeaponsCompItem3);
				}
			}
			NativeListItem<int> WeaponsTintItem2 = new NativeListItem<int>("Tint", "0 - Normal~n~1 - Green~n~2 - Gold~n~3 - Pink~n~4 - Army~n~5 - LSPD~n~6 - Orange~n~7 - Platinum", 0, 1, 2, 3, 4, 5, 6, 7);
			if (Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash3) >= 0)
			{
				WeaponsTintItem2.SelectedIndex = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash3);
			}
			WeaponsTintItem2.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
			{
				Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash3, WeaponsTintItem2.SelectedItem);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				Notification.Show("Tint Changed", blinking: true);
			};
			if (WeaponsTintItem2.Items.Count > 0)
			{
				nativeMenu13.Add(WeaponsTintItem2);
			}
			NativeItem WeaponsAmmoItem2 = new NativeItem($"Rounds x {ammoPer2}", "", $"${ammoCost2}");
			int num8 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash3, &num8))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash3) < num8)
				{
					WeaponsAmmoItem2.AltTitle = $"${ammoCost2}";
					WeaponsAmmoItem2.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem2.AltTitle = "FULL";
					WeaponsAmmoItem2.Enabled = false;
				}
			}
			WeaponsAmmoItem2.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash3, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash3) < num27)
					{
						WeaponsAmmoItem2.AltTitle = $"${ammoCost2}";
						WeaponsAmmoItem2.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash3))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost2))
							{
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash3, ammoPer2);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem2.AltTitle = "FULL";
						WeaponsAmmoItem2.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu13.Add(WeaponsAmmoItem2);
		}
		for (int num9 = 0; num9 < dictionary[WeaponGroup.Shotgun].Count; num9++)
		{
			string text10 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.Shotgun][num9].weaponHash));
			string description4 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.Shotgun][num9].weaponHash));
			int weaponcost4 = dictionary[WeaponGroup.Shotgun][num9].weaponCost;
			int rankNeeded4 = dictionary[WeaponGroup.Shotgun][num9].rankNeeded;
			WeaponHash weaponHash4 = dictionary[WeaponGroup.Shotgun][num9].weaponHash;
			List<string> compHashName4 = dictionary[WeaponGroup.Shotgun][num9].compHashName;
			List<string> compLabel4 = dictionary[WeaponGroup.Shotgun][num9].compLabel;
			List<string> compDesc4 = dictionary[WeaponGroup.Shotgun][num9].compDesc;
			List<int> compCost4 = dictionary[WeaponGroup.Shotgun][num9].compCost;
			List<int> compRank4 = dictionary[WeaponGroup.Shotgun][num9].compRank;
			int ammoPer3 = dictionary[WeaponGroup.Shotgun][num9].AmmoPer;
			int ammoCost3 = dictionary[WeaponGroup.Shotgun][num9].AmmoCost;
			NativeMenu nativeMenu14 = new NativeMenu("", text10, "");
			MenuPool.Add(nativeMenu14);
			nativeMenu14.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu14.CloseOnInvalidClick = false;
			nativeMenu14.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem14 = new NativeSubmenuItem(nativeMenu14, nativeMenu4);
			nativeSubmenuItem14.AltTitle = "";
			nativeSubmenuItem14.Title = text10;
			nativeMenu4.Add(nativeSubmenuItem14);
			NativeItem WeaponsItem4 = new NativeItem(text10, description4, "");
			if (!weaponownership.Weapon.Contains(weaponHash4))
			{
				if (MPRank.PlayerLevel >= rankNeeded4)
				{
					WeaponsItem4.AltTitle = $"${weaponcost4}";
					WeaponsItem4.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost4))
						{
							if (!weaponownership.Weapon.Contains(weaponHash4))
							{
								weaponownership.Weapon.Add(weaponHash4);
							}
							Game.Player.Character.Weapons.Give(weaponHash4, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem4.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem4.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem4.Description = $"This item unlocks at Rank {rankNeeded4}.";
					BadgeSet badgeSet13 = new BadgeSet();
					badgeSet13.NormalDictionary = "commonmenu";
					badgeSet13.NormalTexture = "shop_lock";
					badgeSet13.HoveredDictionary = "commonmenu";
					badgeSet13.HoveredTexture = "shop_lock";
					WeaponsItem4.RightBadgeSet = badgeSet13;
				}
			}
			else
			{
				BadgeSet badgeSet14 = new BadgeSet();
				badgeSet14.NormalDictionary = "commonmenu";
				badgeSet14.NormalTexture = "shop_gunclub_icon_a";
				badgeSet14.HoveredDictionary = "commonmenu";
				badgeSet14.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem4.RightBadgeSet = badgeSet14;
			}
			nativeMenu14.Add(WeaponsItem4);
			if (compHashName4 != null)
			{
				for (int num10 = 0; num10 < compHashName4.Count; num10++)
				{
					WeaponComponentHash compShopName4 = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName4[num10]);
					string text11 = "";
					string text12 = "";
					int compShopCost4 = 0;
					int compShopRank3 = 0;
					text11 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel4[num10]);
					text12 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc4[num10]);
					compShopCost4 = compCost4[num10];
					compShopRank3 = compRank4[num10];
					NativeItem WeaponsCompItem4 = new NativeItem(text11, text12, $"${compShopCost4}");
					WeaponsCompItem4.AltTitle = "";
					if (!weaponownership.Components.Contains(compShopName4))
					{
						if (MPRank.PlayerLevel >= compShopRank3)
						{
							WeaponsCompItem4.AltTitle = $"${compShopCost4}";
						}
						else
						{
							WeaponsCompItem4.Description = $"This item unlocks at Rank {compShopRank3}.";
							BadgeSet badgeSet15 = new BadgeSet();
							badgeSet15.NormalDictionary = "commonmenu";
							badgeSet15.NormalTexture = "shop_lock";
							badgeSet15.HoveredDictionary = "commonmenu";
							badgeSet15.HoveredTexture = "shop_lock";
							WeaponsCompItem4.RightBadgeSet = badgeSet15;
						}
					}
					else
					{
						WeaponsCompItem4.AltTitle = "";
						BadgeSet badgeSet16 = new BadgeSet();
						if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash4, compShopName4))
						{
							badgeSet16.NormalDictionary = "commonmenu";
							badgeSet16.NormalTexture = "shop_tick_icon";
							badgeSet16.HoveredDictionary = "commonmenu";
							badgeSet16.HoveredTexture = "shop_tick_icon";
							WeaponsCompItem4.RightBadgeSet = badgeSet16;
						}
						else
						{
							badgeSet16.NormalDictionary = "commonmenu";
							badgeSet16.NormalTexture = "shop_gunclub_icon_a";
							badgeSet16.HoveredDictionary = "commonmenu";
							badgeSet16.HoveredTexture = "shop_gunclub_icon_b";
							WeaponsCompItem4.RightBadgeSet = badgeSet16;
						}
					}
					WeaponsCompItem4.Activated += (object sender, EventArgs e) =>
					{
						if (!weaponownership.Components.Contains(compShopName4) && !weaponLoadout.CurrentLoadout[0].Components.Contains(compShopName4))
						{
							if (MPRank.PlayerLevel >= compShopRank3)
							{
								WeaponsCompItem4.AltTitle = $"${compShopCost4}";
								if (weaponownership.Weapon.Contains(weaponHash4))
								{
									if (MPCash.PROCESS_TRANSACTION(compShopCost4))
									{
										if (!weaponownership.Components.Contains(compShopName4))
										{
											weaponownership.Components.Add(compShopName4);
										}
										Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash4, compShopName4);
										MPLoadout.SAVE_CURRENT_LOADOUT();
										XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
										WeaponsCompItem4.AltTitle = "";
										BadgeSet rightBadgeSet = new BadgeSet
										{
											NormalDictionary = "commonmenu",
											NormalTexture = "shop_gunclub_icon_a",
											HoveredDictionary = "commonmenu",
											HoveredTexture = "shop_gunclub_icon_b"
										};
										WeaponsCompItem4.RightBadgeSet = rightBadgeSet;
									}
									else
									{
										Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
									}
								}
								else
								{
									Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
								}
							}
							else
							{
								WeaponsCompItem4.Description = $"This item unlocks at Rank {compShopRank3}.";
								BadgeSet rightBadgeSet2 = new BadgeSet
								{
									NormalDictionary = "commonmenu",
									NormalTexture = "shop_lock",
									HoveredDictionary = "commonmenu",
									HoveredTexture = "shop_lock"
								};
								WeaponsCompItem4.RightBadgeSet = rightBadgeSet2;
							}
						}
						else if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash4, compShopName4))
						{
							Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash4, compShopName4);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Equipped", blinking: true);
							BadgeSet rightBadgeSet3 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsCompItem4.RightBadgeSet = rightBadgeSet3;
						}
						else
						{
							Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, weaponHash4, compShopName4);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Unequipped", blinking: true);
							BadgeSet rightBadgeSet4 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_tick_icon",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_tick_icon"
							};
							WeaponsCompItem4.RightBadgeSet = rightBadgeSet4;
						}
					};
					nativeMenu14.Add(WeaponsCompItem4);
				}
			}
			NativeListItem<int> WeaponsTintItem3 = new NativeListItem<int>("Tint", "0 - Normal~n~1 - Green~n~2 - Gold~n~3 - Pink~n~4 - Army~n~5 - LSPD~n~6 - Orange~n~7 - Platinum", 0, 1, 2, 3, 4, 5, 6, 7);
			if (Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash4) >= 0)
			{
				WeaponsTintItem3.SelectedIndex = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash4);
			}
			WeaponsTintItem3.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
			{
				Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash4, WeaponsTintItem3.SelectedItem);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				Notification.Show("Tint Changed", blinking: true);
			};
			if (WeaponsTintItem3.Items.Count > 0)
			{
				nativeMenu14.Add(WeaponsTintItem3);
			}
			NativeItem WeaponsAmmoItem3 = new NativeItem($"Rounds x {ammoPer3}", "", $"${ammoCost3}");
			int num11 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash4, &num11))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash4) < num11)
				{
					WeaponsAmmoItem3.AltTitle = $"${ammoCost3}";
					WeaponsAmmoItem3.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem3.AltTitle = "FULL";
					WeaponsAmmoItem3.Enabled = false;
				}
			}
			WeaponsAmmoItem3.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash4, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash4) < num27)
					{
						WeaponsAmmoItem3.AltTitle = $"${ammoCost3}";
						WeaponsAmmoItem3.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash4))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost3))
							{
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash4, ammoPer3);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem3.AltTitle = "FULL";
						WeaponsAmmoItem3.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu14.Add(WeaponsAmmoItem3);
		}
		for (int num12 = 0; num12 < dictionary[WeaponGroup.AssaultRifle].Count; num12++)
		{
			string text13 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.AssaultRifle][num12].weaponHash));
			string description5 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.AssaultRifle][num12].weaponHash));
			int weaponcost5 = dictionary[WeaponGroup.AssaultRifle][num12].weaponCost;
			int rankNeeded5 = dictionary[WeaponGroup.AssaultRifle][num12].rankNeeded;
			WeaponHash weaponHash5 = dictionary[WeaponGroup.AssaultRifle][num12].weaponHash;
			List<string> compHashName5 = dictionary[WeaponGroup.AssaultRifle][num12].compHashName;
			List<string> compLabel5 = dictionary[WeaponGroup.AssaultRifle][num12].compLabel;
			List<string> compDesc5 = dictionary[WeaponGroup.AssaultRifle][num12].compDesc;
			List<int> compCost5 = dictionary[WeaponGroup.AssaultRifle][num12].compCost;
			List<int> compRank5 = dictionary[WeaponGroup.AssaultRifle][num12].compRank;
			int ammoPer4 = dictionary[WeaponGroup.AssaultRifle][num12].AmmoPer;
			int ammoCost4 = dictionary[WeaponGroup.AssaultRifle][num12].AmmoCost;
			NativeMenu nativeMenu15 = new NativeMenu("", text13, "");
			MenuPool.Add(nativeMenu15);
			nativeMenu15.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu15.CloseOnInvalidClick = false;
			nativeMenu15.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem15 = new NativeSubmenuItem(nativeMenu15, nativeMenu5);
			nativeSubmenuItem15.AltTitle = "";
			nativeSubmenuItem15.Title = text13;
			nativeMenu5.Add(nativeSubmenuItem15);
			NativeItem WeaponsItem5 = new NativeItem(text13, description5, "");
			if (!weaponownership.Weapon.Contains(weaponHash5))
			{
				if (MPRank.PlayerLevel >= rankNeeded5)
				{
					WeaponsItem5.AltTitle = $"${weaponcost5}";
					WeaponsItem5.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost5))
						{
							if (!weaponownership.Weapon.Contains(weaponHash5))
							{
								weaponownership.Weapon.Add(weaponHash5);
							}
							Game.Player.Character.Weapons.Give(weaponHash5, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem5.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem5.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem5.Description = $"This item unlocks at Rank {rankNeeded5}.";
					BadgeSet badgeSet17 = new BadgeSet();
					badgeSet17.NormalDictionary = "commonmenu";
					badgeSet17.NormalTexture = "shop_lock";
					badgeSet17.HoveredDictionary = "commonmenu";
					badgeSet17.HoveredTexture = "shop_lock";
					WeaponsItem5.RightBadgeSet = badgeSet17;
				}
			}
			else
			{
				BadgeSet badgeSet18 = new BadgeSet();
				badgeSet18.NormalDictionary = "commonmenu";
				badgeSet18.NormalTexture = "shop_gunclub_icon_a";
				badgeSet18.HoveredDictionary = "commonmenu";
				badgeSet18.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem5.RightBadgeSet = badgeSet18;
			}
			nativeMenu15.Add(WeaponsItem5);
			if (compHashName5 != null)
			{
				for (int num13 = 0; num13 < compHashName5.Count; num13++)
				{
					WeaponComponentHash compShopName5 = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName5[num13]);
					string text14 = "";
					string text15 = "";
					int compShopCost5 = 0;
					int compShopRank4 = 0;
					text14 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel5[num13]);
					text15 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc5[num13]);
					compShopCost5 = compCost5[num13];
					compShopRank4 = compRank5[num13];
					NativeItem WeaponsCompItem5 = new NativeItem(text14, text15, $"${compShopCost5}");
					WeaponsCompItem5.AltTitle = "";
					if (!weaponownership.Components.Contains(compShopName5))
					{
						if (MPRank.PlayerLevel >= compShopRank4)
						{
							WeaponsCompItem5.AltTitle = $"${compShopCost5}";
						}
						else
						{
							WeaponsCompItem5.Description = $"This item unlocks at Rank {compShopRank4}.";
							BadgeSet badgeSet19 = new BadgeSet();
							badgeSet19.NormalDictionary = "commonmenu";
							badgeSet19.NormalTexture = "shop_lock";
							badgeSet19.HoveredDictionary = "commonmenu";
							badgeSet19.HoveredTexture = "shop_lock";
							WeaponsCompItem5.RightBadgeSet = badgeSet19;
						}
					}
					else
					{
						WeaponsCompItem5.AltTitle = "";
						BadgeSet badgeSet20 = new BadgeSet();
						if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash5, compShopName5))
						{
							badgeSet20.NormalDictionary = "commonmenu";
							badgeSet20.NormalTexture = "shop_tick_icon";
							badgeSet20.HoveredDictionary = "commonmenu";
							badgeSet20.HoveredTexture = "shop_tick_icon";
							WeaponsCompItem5.RightBadgeSet = badgeSet20;
						}
						else
						{
							badgeSet20.NormalDictionary = "commonmenu";
							badgeSet20.NormalTexture = "shop_gunclub_icon_a";
							badgeSet20.HoveredDictionary = "commonmenu";
							badgeSet20.HoveredTexture = "shop_gunclub_icon_b";
							WeaponsCompItem5.RightBadgeSet = badgeSet20;
						}
					}
					WeaponsCompItem5.Activated += (object sender, EventArgs e) =>
					{
						if (!weaponownership.Components.Contains(compShopName5) && !weaponLoadout.CurrentLoadout[0].Components.Contains(compShopName5))
						{
							if (MPRank.PlayerLevel >= compShopRank4)
							{
								WeaponsCompItem5.AltTitle = $"${compShopCost5}";
								if (weaponownership.Weapon.Contains(weaponHash5))
								{
									if (MPCash.PROCESS_TRANSACTION(compShopCost5))
									{
										if (!weaponownership.Components.Contains(compShopName5))
										{
											weaponownership.Components.Add(compShopName5);
										}
										Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash5, compShopName5);
										MPLoadout.SAVE_CURRENT_LOADOUT();
										XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
										WeaponsCompItem5.AltTitle = "";
										BadgeSet rightBadgeSet = new BadgeSet
										{
											NormalDictionary = "commonmenu",
											NormalTexture = "shop_gunclub_icon_a",
											HoveredDictionary = "commonmenu",
											HoveredTexture = "shop_gunclub_icon_b"
										};
										WeaponsCompItem5.RightBadgeSet = rightBadgeSet;
									}
									else
									{
										Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
									}
								}
								else
								{
									Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
								}
							}
							else
							{
								WeaponsCompItem5.Description = $"This item unlocks at Rank {compShopRank4}.";
								BadgeSet rightBadgeSet2 = new BadgeSet
								{
									NormalDictionary = "commonmenu",
									NormalTexture = "shop_lock",
									HoveredDictionary = "commonmenu",
									HoveredTexture = "shop_lock"
								};
								WeaponsCompItem5.RightBadgeSet = rightBadgeSet2;
							}
						}
						else if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash5, compShopName5))
						{
							Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash5, compShopName5);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Equipped", blinking: true);
							BadgeSet rightBadgeSet3 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsCompItem5.RightBadgeSet = rightBadgeSet3;
						}
						else
						{
							Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, weaponHash5, compShopName5);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Unequipped", blinking: true);
							BadgeSet rightBadgeSet4 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_tick_icon",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_tick_icon"
							};
							WeaponsCompItem5.RightBadgeSet = rightBadgeSet4;
						}
					};
					nativeMenu15.Add(WeaponsCompItem5);
				}
			}
			NativeListItem<int> WeaponsTintItem4 = new NativeListItem<int>("Tint", "0 - Normal~n~1 - Green~n~2 - Gold~n~3 - Pink~n~4 - Army~n~5 - LSPD~n~6 - Orange~n~7 - Platinum", 0, 1, 2, 3, 4, 5, 6, 7);
			if (Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash5) >= 0)
			{
				WeaponsTintItem4.SelectedIndex = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash5);
			}
			WeaponsTintItem4.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
			{
				Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash5, WeaponsTintItem4.SelectedItem);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				Notification.Show("Tint Changed", blinking: true);
			};
			if (WeaponsTintItem4.Items.Count > 0)
			{
				nativeMenu15.Add(WeaponsTintItem4);
			}
			NativeItem WeaponsAmmoItem4 = new NativeItem($"Rounds x {ammoPer4}", "", $"${ammoCost4}");
			int num14 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash5, &num14))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash5) < num14)
				{
					WeaponsAmmoItem4.AltTitle = $"${ammoCost4}";
					WeaponsAmmoItem4.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem4.AltTitle = "FULL";
					WeaponsAmmoItem4.Enabled = false;
				}
			}
			WeaponsAmmoItem4.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash5, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash5) < num27)
					{
						WeaponsAmmoItem4.AltTitle = $"${ammoCost4}";
						WeaponsAmmoItem4.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash5))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost4))
							{
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash5, ammoPer4);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem4.AltTitle = "FULL";
						WeaponsAmmoItem4.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu15.Add(WeaponsAmmoItem4);
		}
		for (int num15 = 0; num15 < dictionary[WeaponGroup.MG].Count; num15++)
		{
			string text16 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.MG][num15].weaponHash));
			string description6 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.MG][num15].weaponHash));
			int weaponcost6 = dictionary[WeaponGroup.MG][num15].weaponCost;
			int rankNeeded6 = dictionary[WeaponGroup.MG][num15].rankNeeded;
			WeaponHash weaponHash6 = dictionary[WeaponGroup.MG][num15].weaponHash;
			List<string> compHashName6 = dictionary[WeaponGroup.MG][num15].compHashName;
			List<string> compLabel6 = dictionary[WeaponGroup.MG][num15].compLabel;
			List<string> compDesc6 = dictionary[WeaponGroup.MG][num15].compDesc;
			List<int> compCost6 = dictionary[WeaponGroup.MG][num15].compCost;
			List<int> compRank6 = dictionary[WeaponGroup.MG][num15].compRank;
			int ammoPer5 = dictionary[WeaponGroup.MG][num15].AmmoPer;
			int ammoCost5 = dictionary[WeaponGroup.MG][num15].AmmoCost;
			NativeMenu nativeMenu16 = new NativeMenu("", text16, "");
			MenuPool.Add(nativeMenu16);
			nativeMenu16.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu16.CloseOnInvalidClick = false;
			nativeMenu16.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem16 = new NativeSubmenuItem(nativeMenu16, nativeMenu6);
			nativeSubmenuItem16.AltTitle = "";
			nativeSubmenuItem16.Title = text16;
			nativeMenu6.Add(nativeSubmenuItem16);
			NativeItem WeaponsItem6 = new NativeItem(text16, description6, "");
			if (!weaponownership.Weapon.Contains(weaponHash6))
			{
				if (MPRank.PlayerLevel >= rankNeeded6)
				{
					WeaponsItem6.AltTitle = $"${weaponcost6}";
					WeaponsItem6.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost6))
						{
							if (!weaponownership.Weapon.Contains(weaponHash6))
							{
								weaponownership.Weapon.Add(weaponHash6);
							}
							Game.Player.Character.Weapons.Give(weaponHash6, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem6.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem6.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem6.Description = $"This item unlocks at Rank {rankNeeded6}.";
					BadgeSet badgeSet21 = new BadgeSet();
					badgeSet21.NormalDictionary = "commonmenu";
					badgeSet21.NormalTexture = "shop_lock";
					badgeSet21.HoveredDictionary = "commonmenu";
					badgeSet21.HoveredTexture = "shop_lock";
					WeaponsItem6.RightBadgeSet = badgeSet21;
				}
			}
			else
			{
				BadgeSet badgeSet22 = new BadgeSet();
				badgeSet22.NormalDictionary = "commonmenu";
				badgeSet22.NormalTexture = "shop_gunclub_icon_a";
				badgeSet22.HoveredDictionary = "commonmenu";
				badgeSet22.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem6.RightBadgeSet = badgeSet22;
			}
			nativeMenu16.Add(WeaponsItem6);
			if (compHashName6 != null)
			{
				for (int num16 = 0; num16 < compHashName6.Count; num16++)
				{
					WeaponComponentHash compShopName6 = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName6[num16]);
					string text17 = "";
					string text18 = "";
					int compShopCost6 = 0;
					int compShopRank5 = 0;
					text17 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel6[num16]);
					text18 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc6[num16]);
					compShopCost6 = compCost6[num16];
					compShopRank5 = compRank6[num16];
					NativeItem WeaponsCompItem6 = new NativeItem(text17, text18, $"${compShopCost6}");
					WeaponsCompItem6.AltTitle = "";
					if (!weaponownership.Components.Contains(compShopName6))
					{
						if (MPRank.PlayerLevel >= compShopRank5)
						{
							WeaponsCompItem6.AltTitle = $"${compShopCost6}";
						}
						else
						{
							WeaponsCompItem6.Description = $"This item unlocks at Rank {compShopRank5}.";
							BadgeSet badgeSet23 = new BadgeSet();
							badgeSet23.NormalDictionary = "commonmenu";
							badgeSet23.NormalTexture = "shop_lock";
							badgeSet23.HoveredDictionary = "commonmenu";
							badgeSet23.HoveredTexture = "shop_lock";
							WeaponsCompItem6.RightBadgeSet = badgeSet23;
						}
					}
					else
					{
						WeaponsCompItem6.AltTitle = "";
						BadgeSet badgeSet24 = new BadgeSet();
						if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash6, compShopName6))
						{
							badgeSet24.NormalDictionary = "commonmenu";
							badgeSet24.NormalTexture = "shop_tick_icon";
							badgeSet24.HoveredDictionary = "commonmenu";
							badgeSet24.HoveredTexture = "shop_tick_icon";
							WeaponsCompItem6.RightBadgeSet = badgeSet24;
						}
						else
						{
							badgeSet24.NormalDictionary = "commonmenu";
							badgeSet24.NormalTexture = "shop_gunclub_icon_a";
							badgeSet24.HoveredDictionary = "commonmenu";
							badgeSet24.HoveredTexture = "shop_gunclub_icon_b";
							WeaponsCompItem6.RightBadgeSet = badgeSet24;
						}
					}
					WeaponsCompItem6.Activated += (object sender, EventArgs e) =>
					{
						if (!weaponownership.Components.Contains(compShopName6) && !weaponLoadout.CurrentLoadout[0].Components.Contains(compShopName6))
						{
							if (MPRank.PlayerLevel >= compShopRank5)
							{
								WeaponsCompItem6.AltTitle = $"${compShopCost6}";
								if (weaponownership.Weapon.Contains(weaponHash6))
								{
									if (MPCash.PROCESS_TRANSACTION(compShopCost6))
									{
										if (!weaponownership.Components.Contains(compShopName6))
										{
											weaponownership.Components.Add(compShopName6);
										}
										Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash6, compShopName6);
										MPLoadout.SAVE_CURRENT_LOADOUT();
										XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
										WeaponsCompItem6.AltTitle = "";
										BadgeSet rightBadgeSet = new BadgeSet
										{
											NormalDictionary = "commonmenu",
											NormalTexture = "shop_gunclub_icon_a",
											HoveredDictionary = "commonmenu",
											HoveredTexture = "shop_gunclub_icon_b"
										};
										WeaponsCompItem6.RightBadgeSet = rightBadgeSet;
									}
									else
									{
										Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
									}
								}
								else
								{
									Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
								}
							}
							else
							{
								WeaponsCompItem6.Description = $"This item unlocks at Rank {compShopRank5}.";
								BadgeSet rightBadgeSet2 = new BadgeSet
								{
									NormalDictionary = "commonmenu",
									NormalTexture = "shop_lock",
									HoveredDictionary = "commonmenu",
									HoveredTexture = "shop_lock"
								};
								WeaponsCompItem6.RightBadgeSet = rightBadgeSet2;
							}
						}
						else if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash6, compShopName6))
						{
							Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash6, compShopName6);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Equipped", blinking: true);
							BadgeSet rightBadgeSet3 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsCompItem6.RightBadgeSet = rightBadgeSet3;
						}
						else
						{
							Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, weaponHash6, compShopName6);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Unequipped", blinking: true);
							BadgeSet rightBadgeSet4 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_tick_icon",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_tick_icon"
							};
							WeaponsCompItem6.RightBadgeSet = rightBadgeSet4;
						}
					};
					nativeMenu16.Add(WeaponsCompItem6);
				}
			}
			NativeListItem<int> WeaponsTintItem5 = new NativeListItem<int>("Tint", "0 - Normal~n~1 - Green~n~2 - Gold~n~3 - Pink~n~4 - Army~n~5 - LSPD~n~6 - Orange~n~7 - Platinum", 0, 1, 2, 3, 4, 5, 6, 7);
			if (Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash6) >= 0)
			{
				WeaponsTintItem5.SelectedIndex = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash6);
			}
			WeaponsTintItem5.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
			{
				Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash6, WeaponsTintItem5.SelectedItem);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				Notification.Show("Tint Changed", blinking: true);
			};
			if (WeaponsTintItem5.Items.Count > 0)
			{
				nativeMenu16.Add(WeaponsTintItem5);
			}
			NativeItem WeaponsAmmoItem5 = new NativeItem($"Rounds x {ammoPer5}", "", $"${ammoCost5}");
			int num17 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash6, &num17))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash6) < num17)
				{
					WeaponsAmmoItem5.AltTitle = $"${ammoCost5}";
					WeaponsAmmoItem5.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem5.AltTitle = "FULL";
					WeaponsAmmoItem5.Enabled = false;
				}
			}
			WeaponsAmmoItem5.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash6, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash6) < num27)
					{
						WeaponsAmmoItem5.AltTitle = $"${ammoCost5}";
						WeaponsAmmoItem5.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash6))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost5))
							{
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash6, ammoPer5);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem5.AltTitle = "FULL";
						WeaponsAmmoItem5.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu16.Add(WeaponsAmmoItem5);
		}
		for (int num18 = 0; num18 < dictionary[WeaponGroup.Sniper].Count; num18++)
		{
			string text19 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.Sniper][num18].weaponHash));
			string description7 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.Sniper][num18].weaponHash));
			int weaponcost7 = dictionary[WeaponGroup.Sniper][num18].weaponCost;
			int rankNeeded7 = dictionary[WeaponGroup.Sniper][num18].rankNeeded;
			WeaponHash weaponHash7 = dictionary[WeaponGroup.Sniper][num18].weaponHash;
			List<string> compHashName7 = dictionary[WeaponGroup.Sniper][num18].compHashName;
			List<string> compLabel7 = dictionary[WeaponGroup.Sniper][num18].compLabel;
			List<string> compDesc7 = dictionary[WeaponGroup.Sniper][num18].compDesc;
			List<int> compCost7 = dictionary[WeaponGroup.Sniper][num18].compCost;
			List<int> compRank7 = dictionary[WeaponGroup.Sniper][num18].compRank;
			int ammoPer6 = dictionary[WeaponGroup.Sniper][num18].AmmoPer;
			int ammoCost6 = dictionary[WeaponGroup.Sniper][num18].AmmoCost;
			NativeMenu nativeMenu17 = new NativeMenu("", text19, "");
			MenuPool.Add(nativeMenu17);
			nativeMenu17.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu17.CloseOnInvalidClick = false;
			nativeMenu17.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem17 = new NativeSubmenuItem(nativeMenu17, nativeMenu7);
			nativeSubmenuItem17.AltTitle = "";
			nativeSubmenuItem17.Title = text19;
			nativeMenu7.Add(nativeSubmenuItem17);
			NativeItem WeaponsItem7 = new NativeItem(text19, description7, "");
			if (!weaponownership.Weapon.Contains(weaponHash7))
			{
				if (MPRank.PlayerLevel >= rankNeeded7)
				{
					WeaponsItem7.AltTitle = $"${weaponcost7}";
					WeaponsItem7.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost7))
						{
							if (!weaponownership.Weapon.Contains(weaponHash7))
							{
								weaponownership.Weapon.Add(weaponHash7);
							}
							Game.Player.Character.Weapons.Give(weaponHash7, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem7.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem7.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem7.Description = $"This item unlocks at Rank {rankNeeded7}.";
					BadgeSet badgeSet25 = new BadgeSet();
					badgeSet25.NormalDictionary = "commonmenu";
					badgeSet25.NormalTexture = "shop_lock";
					badgeSet25.HoveredDictionary = "commonmenu";
					badgeSet25.HoveredTexture = "shop_lock";
					WeaponsItem7.RightBadgeSet = badgeSet25;
				}
			}
			else
			{
				BadgeSet badgeSet26 = new BadgeSet();
				badgeSet26.NormalDictionary = "commonmenu";
				badgeSet26.NormalTexture = "shop_gunclub_icon_a";
				badgeSet26.HoveredDictionary = "commonmenu";
				badgeSet26.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem7.RightBadgeSet = badgeSet26;
			}
			nativeMenu17.Add(WeaponsItem7);
			if (compHashName7 != null)
			{
				for (int num19 = 0; num19 < compHashName7.Count; num19++)
				{
					WeaponComponentHash compShopName7 = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName7[num19]);
					string text20 = "";
					string text21 = "";
					int compShopCost7 = 0;
					int compShopRank6 = 0;
					text20 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel7[num19]);
					text21 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc7[num19]);
					compShopCost7 = compCost7[num19];
					compShopRank6 = compRank7[num19];
					NativeItem WeaponsCompItem7 = new NativeItem(text20, text21, $"${compShopCost7}");
					WeaponsCompItem7.AltTitle = "";
					if (!weaponownership.Components.Contains(compShopName7))
					{
						if (MPRank.PlayerLevel >= compShopRank6)
						{
							WeaponsCompItem7.AltTitle = $"${compShopCost7}";
						}
						else
						{
							WeaponsCompItem7.Description = $"This item unlocks at Rank {compShopRank6}.";
							BadgeSet badgeSet27 = new BadgeSet();
							badgeSet27.NormalDictionary = "commonmenu";
							badgeSet27.NormalTexture = "shop_lock";
							badgeSet27.HoveredDictionary = "commonmenu";
							badgeSet27.HoveredTexture = "shop_lock";
							WeaponsCompItem7.RightBadgeSet = badgeSet27;
						}
					}
					else
					{
						WeaponsCompItem7.AltTitle = "";
						BadgeSet badgeSet28 = new BadgeSet();
						if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash7, compShopName7))
						{
							badgeSet28.NormalDictionary = "commonmenu";
							badgeSet28.NormalTexture = "shop_tick_icon";
							badgeSet28.HoveredDictionary = "commonmenu";
							badgeSet28.HoveredTexture = "shop_tick_icon";
							WeaponsCompItem7.RightBadgeSet = badgeSet28;
						}
						else
						{
							badgeSet28.NormalDictionary = "commonmenu";
							badgeSet28.NormalTexture = "shop_gunclub_icon_a";
							badgeSet28.HoveredDictionary = "commonmenu";
							badgeSet28.HoveredTexture = "shop_gunclub_icon_b";
							WeaponsCompItem7.RightBadgeSet = badgeSet28;
						}
					}
					WeaponsCompItem7.Activated += (object sender, EventArgs e) =>
					{
						if (!weaponownership.Components.Contains(compShopName7) && !weaponLoadout.CurrentLoadout[0].Components.Contains(compShopName7))
						{
							if (MPRank.PlayerLevel >= compShopRank6)
							{
								WeaponsCompItem7.AltTitle = $"${compShopCost7}";
								if (weaponownership.Weapon.Contains(weaponHash7))
								{
									if (MPCash.PROCESS_TRANSACTION(compShopCost7))
									{
										if (!weaponownership.Components.Contains(compShopName7))
										{
											weaponownership.Components.Add(compShopName7);
										}
										Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash7, compShopName7);
										MPLoadout.SAVE_CURRENT_LOADOUT();
										XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
										WeaponsCompItem7.AltTitle = "";
										BadgeSet rightBadgeSet = new BadgeSet
										{
											NormalDictionary = "commonmenu",
											NormalTexture = "shop_gunclub_icon_a",
											HoveredDictionary = "commonmenu",
											HoveredTexture = "shop_gunclub_icon_b"
										};
										WeaponsCompItem7.RightBadgeSet = rightBadgeSet;
									}
									else
									{
										Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
									}
								}
								else
								{
									Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
								}
							}
							else
							{
								WeaponsCompItem7.Description = $"This item unlocks at Rank {compShopRank6}.";
								BadgeSet rightBadgeSet2 = new BadgeSet
								{
									NormalDictionary = "commonmenu",
									NormalTexture = "shop_lock",
									HoveredDictionary = "commonmenu",
									HoveredTexture = "shop_lock"
								};
								WeaponsCompItem7.RightBadgeSet = rightBadgeSet2;
							}
						}
						else if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash7, compShopName7))
						{
							Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash7, compShopName7);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Equipped", blinking: true);
							BadgeSet rightBadgeSet3 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsCompItem7.RightBadgeSet = rightBadgeSet3;
						}
						else
						{
							Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, weaponHash7, compShopName7);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Unequipped", blinking: true);
							BadgeSet rightBadgeSet4 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_tick_icon",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_tick_icon"
							};
							WeaponsCompItem7.RightBadgeSet = rightBadgeSet4;
						}
					};
					nativeMenu17.Add(WeaponsCompItem7);
				}
			}
			NativeListItem<int> WeaponsTintItem6 = new NativeListItem<int>("Tint", "0 - Normal~n~1 - Green~n~2 - Gold~n~3 - Pink~n~4 - Army~n~5 - LSPD~n~6 - Orange~n~7 - Platinum", 0, 1, 2, 3, 4, 5, 6, 7);
			if (Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash7) >= 0)
			{
				WeaponsTintItem6.SelectedIndex = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash7);
			}
			WeaponsTintItem6.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
			{
				Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash7, WeaponsTintItem6.SelectedItem);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				Notification.Show("Tint Changed", blinking: true);
			};
			if (WeaponsTintItem6.Items.Count > 0)
			{
				nativeMenu17.Add(WeaponsTintItem6);
			}
			NativeItem WeaponsAmmoItem6 = new NativeItem($"Rounds x {ammoPer6}", "", $"${ammoCost6}");
			int num20 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash7, &num20))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash7) < num20)
				{
					WeaponsAmmoItem6.AltTitle = $"${ammoCost6}";
					WeaponsAmmoItem6.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem6.AltTitle = "FULL";
					WeaponsAmmoItem6.Enabled = false;
				}
			}
			WeaponsAmmoItem6.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash7, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash7) < num27)
					{
						WeaponsAmmoItem6.AltTitle = $"${ammoCost6}";
						WeaponsAmmoItem6.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash7))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost6))
							{
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash7, ammoPer6);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem6.AltTitle = "FULL";
						WeaponsAmmoItem6.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu17.Add(WeaponsAmmoItem6);
		}
		for (int num21 = 0; num21 < dictionary[WeaponGroup.Heavy].Count; num21++)
		{
			string text22 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.Heavy][num21].weaponHash));
			string description8 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.Heavy][num21].weaponHash));
			int weaponcost8 = dictionary[WeaponGroup.Heavy][num21].weaponCost;
			int rankNeeded8 = dictionary[WeaponGroup.Heavy][num21].rankNeeded;
			WeaponHash weaponHash8 = dictionary[WeaponGroup.Heavy][num21].weaponHash;
			List<string> compHashName8 = dictionary[WeaponGroup.Heavy][num21].compHashName;
			List<string> compLabel8 = dictionary[WeaponGroup.Heavy][num21].compLabel;
			List<string> compDesc8 = dictionary[WeaponGroup.Heavy][num21].compDesc;
			List<int> compCost8 = dictionary[WeaponGroup.Heavy][num21].compCost;
			List<int> compRank8 = dictionary[WeaponGroup.Heavy][num21].compRank;
			int ammoPer7 = dictionary[WeaponGroup.Heavy][num21].AmmoPer;
			int ammoCost7 = dictionary[WeaponGroup.Heavy][num21].AmmoCost;
			NativeMenu nativeMenu18 = new NativeMenu("", text22, "");
			MenuPool.Add(nativeMenu18);
			nativeMenu18.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu18.CloseOnInvalidClick = false;
			nativeMenu18.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem18 = new NativeSubmenuItem(nativeMenu18, nativeMenu8);
			nativeSubmenuItem18.AltTitle = "";
			nativeSubmenuItem18.Title = text22;
			nativeMenu8.Add(nativeSubmenuItem18);
			NativeItem WeaponsItem8 = new NativeItem(text22, description8, "");
			if (!weaponownership.Weapon.Contains(weaponHash8))
			{
				if (MPRank.PlayerLevel >= rankNeeded8)
				{
					WeaponsItem8.AltTitle = $"${weaponcost8}";
					WeaponsItem8.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost8))
						{
							if (!weaponownership.Weapon.Contains(weaponHash8))
							{
								weaponownership.Weapon.Add(weaponHash8);
							}
							Game.Player.Character.Weapons.Give(weaponHash8, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem8.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem8.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem8.Description = $"This item unlocks at Rank {rankNeeded8}.";
					BadgeSet badgeSet29 = new BadgeSet();
					badgeSet29.NormalDictionary = "commonmenu";
					badgeSet29.NormalTexture = "shop_lock";
					badgeSet29.HoveredDictionary = "commonmenu";
					badgeSet29.HoveredTexture = "shop_lock";
					WeaponsItem8.RightBadgeSet = badgeSet29;
				}
			}
			else
			{
				BadgeSet badgeSet30 = new BadgeSet();
				badgeSet30.NormalDictionary = "commonmenu";
				badgeSet30.NormalTexture = "shop_gunclub_icon_a";
				badgeSet30.HoveredDictionary = "commonmenu";
				badgeSet30.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem8.RightBadgeSet = badgeSet30;
			}
			nativeMenu18.Add(WeaponsItem8);
			if (compHashName8 != null)
			{
				for (int num22 = 0; num22 < compHashName8.Count; num22++)
				{
					WeaponComponentHash compShopName8 = (WeaponComponentHash)CruelMastersOnlineOffline.joaat(compHashName8[num22]);
					string text23 = "";
					string text24 = "";
					int compShopCost8 = 0;
					int compShopRank7 = 0;
					text23 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compLabel8[num22]);
					text24 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, compDesc8[num22]);
					compShopCost8 = compCost8[num22];
					compShopRank7 = compRank8[num22];
					NativeItem WeaponsCompItem8 = new NativeItem(text23, text24, $"${compShopCost8}");
					WeaponsCompItem8.AltTitle = "";
					if (!weaponownership.Components.Contains(compShopName8))
					{
						if (MPRank.PlayerLevel >= compShopRank7)
						{
							WeaponsCompItem8.AltTitle = $"${compShopCost8}";
						}
						else
						{
							WeaponsCompItem8.Description = $"This item unlocks at Rank {compShopRank7}.";
							BadgeSet badgeSet31 = new BadgeSet();
							badgeSet31.NormalDictionary = "commonmenu";
							badgeSet31.NormalTexture = "shop_lock";
							badgeSet31.HoveredDictionary = "commonmenu";
							badgeSet31.HoveredTexture = "shop_lock";
							WeaponsCompItem8.RightBadgeSet = badgeSet31;
						}
					}
					else
					{
						WeaponsCompItem8.AltTitle = "";
						BadgeSet badgeSet32 = new BadgeSet();
						if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash8, compShopName8))
						{
							badgeSet32.NormalDictionary = "commonmenu";
							badgeSet32.NormalTexture = "shop_tick_icon";
							badgeSet32.HoveredDictionary = "commonmenu";
							badgeSet32.HoveredTexture = "shop_tick_icon";
							WeaponsCompItem8.RightBadgeSet = badgeSet32;
						}
						else
						{
							badgeSet32.NormalDictionary = "commonmenu";
							badgeSet32.NormalTexture = "shop_gunclub_icon_a";
							badgeSet32.HoveredDictionary = "commonmenu";
							badgeSet32.HoveredTexture = "shop_gunclub_icon_b";
							WeaponsCompItem8.RightBadgeSet = badgeSet32;
						}
					}
					WeaponsCompItem8.Activated += (object sender, EventArgs e) =>
					{
						if (!weaponownership.Components.Contains(compShopName8) && !weaponLoadout.CurrentLoadout[0].Components.Contains(compShopName8))
						{
							if (MPRank.PlayerLevel >= compShopRank7)
							{
								WeaponsCompItem8.AltTitle = $"${compShopCost8}";
								if (weaponownership.Weapon.Contains(weaponHash8))
								{
									if (MPCash.PROCESS_TRANSACTION(compShopCost8))
									{
										if (!weaponownership.Components.Contains(compShopName8))
										{
											weaponownership.Components.Add(compShopName8);
										}
										Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash8, compShopName8);
										MPLoadout.SAVE_CURRENT_LOADOUT();
										XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
										WeaponsCompItem8.AltTitle = "";
										BadgeSet rightBadgeSet = new BadgeSet
										{
											NormalDictionary = "commonmenu",
											NormalTexture = "shop_gunclub_icon_a",
											HoveredDictionary = "commonmenu",
											HoveredTexture = "shop_gunclub_icon_b"
										};
										WeaponsCompItem8.RightBadgeSet = rightBadgeSet;
									}
									else
									{
										Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
									}
								}
								else
								{
									Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
								}
							}
							else
							{
								WeaponsCompItem8.Description = $"This item unlocks at Rank {compShopRank7}.";
								BadgeSet rightBadgeSet2 = new BadgeSet
								{
									NormalDictionary = "commonmenu",
									NormalTexture = "shop_lock",
									HoveredDictionary = "commonmenu",
									HoveredTexture = "shop_lock"
								};
								WeaponsCompItem8.RightBadgeSet = rightBadgeSet2;
							}
						}
						else if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Game.Player.Character, weaponHash8, compShopName8))
						{
							Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Game.Player.Character, weaponHash8, compShopName8);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Equipped", blinking: true);
							BadgeSet rightBadgeSet3 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsCompItem8.RightBadgeSet = rightBadgeSet3;
						}
						else
						{
							Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, Game.Player.Character, weaponHash8, compShopName8);
							MPLoadout.SAVE_CURRENT_LOADOUT();
							Notification.Show("Component Unequipped", blinking: true);
							BadgeSet rightBadgeSet4 = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_tick_icon",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_tick_icon"
							};
							WeaponsCompItem8.RightBadgeSet = rightBadgeSet4;
						}
					};
					nativeMenu18.Add(WeaponsCompItem8);
				}
			}
			NativeListItem<int> WeaponsTintItem7 = new NativeListItem<int>("Tint", "0 - Normal~n~1 - Green~n~2 - Gold~n~3 - Pink~n~4 - Army~n~5 - LSPD~n~6 - Orange~n~7 - Platinum", 0, 1, 2, 3, 4, 5, 6, 7);
			if (Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash8) >= 0)
			{
				WeaponsTintItem7.SelectedIndex = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash8);
			}
			WeaponsTintItem7.ItemChanged += (object sender, ItemChangedEventArgs<int> e) =>
			{
				Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, Game.Player.Character, weaponHash8, WeaponsTintItem7.SelectedItem);
				MPLoadout.SAVE_CURRENT_LOADOUT();
				Notification.Show("Tint Changed", blinking: true);
			};
			if (WeaponsTintItem7.Items.Count > 0)
			{
				nativeMenu18.Add(WeaponsTintItem7);
			}
			NativeItem WeaponsAmmoItem7 = new NativeItem($"Rounds x {ammoPer7}", "", $"${ammoCost7}");
			int num23 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash8, &num23))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash8) < num23)
				{
					WeaponsAmmoItem7.AltTitle = $"${ammoCost7}";
					WeaponsAmmoItem7.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem7.AltTitle = "FULL";
					WeaponsAmmoItem7.Enabled = false;
				}
			}
			WeaponsAmmoItem7.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash8, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash8) < num27)
					{
						WeaponsAmmoItem7.AltTitle = $"${ammoCost7}";
						WeaponsAmmoItem7.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash8))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost7))
							{
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash8, ammoPer7);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem7.AltTitle = "FULL";
						WeaponsAmmoItem7.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu18.Add(WeaponsAmmoItem7);
		}
		for (int num24 = 0; num24 < dictionary[WeaponGroup.Thrown].Count; num24++)
		{
			string text25 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.Thrown][num24].weaponHash));
			string text26 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.Thrown][num24].weaponHash));
			int weaponcost9 = dictionary[WeaponGroup.Thrown][num24].weaponCost;
			int rankNeeded9 = dictionary[WeaponGroup.Thrown][num24].rankNeeded;
			WeaponHash weaponHash9 = dictionary[WeaponGroup.Thrown][num24].weaponHash;
			List<string> compHashName9 = dictionary[WeaponGroup.Thrown][num24].compHashName;
			List<string> compLabel9 = dictionary[WeaponGroup.Thrown][num24].compLabel;
			List<string> compDesc9 = dictionary[WeaponGroup.Thrown][num24].compDesc;
			List<int> compCost9 = dictionary[WeaponGroup.Thrown][num24].compCost;
			List<int> compRank9 = dictionary[WeaponGroup.Thrown][num24].compRank;
			int ammoPer8 = dictionary[WeaponGroup.Thrown][num24].AmmoPer;
			int ammoCost8 = dictionary[WeaponGroup.Thrown][num24].AmmoCost;
			if (text26 == "NULL")
			{
				text26 = "Standard Throwable Weapon.";
			}
			NativeMenu nativeMenu19 = new NativeMenu("", text25, "");
			MenuPool.Add(nativeMenu19);
			nativeMenu19.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu19.CloseOnInvalidClick = false;
			nativeMenu19.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem19 = new NativeSubmenuItem(nativeMenu19, nativeMenu9);
			nativeSubmenuItem19.AltTitle = "";
			nativeSubmenuItem19.Title = text25;
			nativeMenu9.Add(nativeSubmenuItem19);
			NativeItem WeaponsItem9 = new NativeItem(text25, text26, "");
			if (!weaponownership.Weapon.Contains(weaponHash9))
			{
				if (MPRank.PlayerLevel >= rankNeeded9)
				{
					WeaponsItem9.AltTitle = $"${weaponcost9}";
					WeaponsItem9.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost9))
						{
							if (!weaponownership.Weapon.Contains(weaponHash9))
							{
								weaponownership.Weapon.Add(weaponHash9);
							}
							Game.Player.Character.Weapons.Give(weaponHash9, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem9.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem9.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem9.Description = $"This item unlocks at Rank {rankNeeded9}.";
					BadgeSet badgeSet33 = new BadgeSet();
					badgeSet33.NormalDictionary = "commonmenu";
					badgeSet33.NormalTexture = "shop_lock";
					badgeSet33.HoveredDictionary = "commonmenu";
					badgeSet33.HoveredTexture = "shop_lock";
					WeaponsItem9.RightBadgeSet = badgeSet33;
				}
			}
			else
			{
				BadgeSet badgeSet34 = new BadgeSet();
				badgeSet34.NormalDictionary = "commonmenu";
				badgeSet34.NormalTexture = "shop_gunclub_icon_a";
				badgeSet34.HoveredDictionary = "commonmenu";
				badgeSet34.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem9.RightBadgeSet = badgeSet34;
			}
			nativeMenu19.Add(WeaponsItem9);
			NativeItem WeaponsAmmoItem8 = new NativeItem($"Rounds x {ammoPer8}", "", $"${ammoCost8}");
			int num25 = 0;
			if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash9, &num25))
			{
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash9) < num25)
				{
					WeaponsAmmoItem8.AltTitle = $"${ammoCost8}";
					WeaponsAmmoItem8.Enabled = true;
				}
				else
				{
					WeaponsAmmoItem8.AltTitle = "FULL";
					WeaponsAmmoItem8.Enabled = false;
				}
			}
			WeaponsAmmoItem8.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character, weaponHash9, &num27))
				{
					if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash9) < num27)
					{
						WeaponsAmmoItem8.AltTitle = $"${ammoCost8}";
						WeaponsAmmoItem8.Enabled = true;
						if (weaponownership.Weapon.Contains(weaponHash9))
						{
							if (MPCash.PROCESS_TRANSACTION(ammoCost8))
							{
								if (weaponHash9 == WeaponHash.PetrolCan && !Game.Player.Character.Weapons.HasWeapon(weaponHash9))
								{
									Game.Player.Character.Weapons.Give(weaponHash9, 100, equipNow: false, isAmmoLoaded: true);
								}
								Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash9, ammoPer8);
								MPLoadout.SAVE_CURRENT_LOADOUT();
							}
							else
							{
								Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
							}
						}
						else
						{
							Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
						}
					}
					else
					{
						WeaponsAmmoItem8.AltTitle = "FULL";
						WeaponsAmmoItem8.Enabled = false;
						Notification.Show("Transaction Failed: Max Ammo", blinking: true);
					}
				}
			};
			nativeMenu19.Add(WeaponsAmmoItem8);
		}
		for (int num26 = 0; num26 < dictionary[WeaponGroup.Parachute].Count; num26++)
		{
			string text27 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayNameFromHash(dictionary[WeaponGroup.Parachute][num26].weaponHash));
			string text28 = Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, GetDisplayDescriptionFromHash(dictionary[WeaponGroup.Parachute][num26].weaponHash));
			int weaponcost10 = dictionary[WeaponGroup.Parachute][num26].weaponCost;
			int rankNeeded10 = dictionary[WeaponGroup.Parachute][num26].rankNeeded;
			WeaponHash weaponHash10 = dictionary[WeaponGroup.Parachute][num26].weaponHash;
			List<string> compHashName10 = dictionary[WeaponGroup.Parachute][num26].compHashName;
			List<string> compLabel10 = dictionary[WeaponGroup.Parachute][num26].compLabel;
			List<string> compDesc10 = dictionary[WeaponGroup.Parachute][num26].compDesc;
			List<int> compCost10 = dictionary[WeaponGroup.Parachute][num26].compCost;
			List<int> compRank10 = dictionary[WeaponGroup.Parachute][num26].compRank;
			int ammoPer9 = dictionary[WeaponGroup.Parachute][num26].AmmoPer;
			int ammoCost9 = dictionary[WeaponGroup.Parachute][num26].AmmoCost;
			if (text27 == "Invalid")
			{
				text27 = "Parachute";
			}
			if (text28 == "NULL")
			{
				text28 = "Standard Parachute.";
			}
			NativeMenu nativeMenu20 = new NativeMenu("", text27, "");
			MenuPool.Add(nativeMenu20);
			nativeMenu20.MouseBehavior = MenuMouseBehavior.Disabled;
			nativeMenu20.CloseOnInvalidClick = false;
			nativeMenu20.Banner = banner;
			NativeSubmenuItem nativeSubmenuItem20 = new NativeSubmenuItem(nativeMenu20, nativeMenu10);
			nativeSubmenuItem20.AltTitle = "";
			nativeSubmenuItem20.Title = text27;
			nativeMenu10.Add(nativeSubmenuItem20);
			NativeItem WeaponsItem10 = new NativeItem(text27, text28, "");
			if (!weaponownership.Weapon.Contains(weaponHash10))
			{
				if (MPRank.PlayerLevel >= rankNeeded10)
				{
					WeaponsItem10.AltTitle = $"${weaponcost10}";
					WeaponsItem10.Activated += (object sender, EventArgs e) =>
					{
						if (MPCash.PROCESS_TRANSACTION(weaponcost10))
						{
							if (!weaponownership.Weapon.Contains(weaponHash10))
							{
								weaponownership.Weapon.Add(weaponHash10);
							}
							Game.Player.Character.Weapons.Give(weaponHash10, 1, equipNow: false, isAmmoLoaded: true);
							XMLSerializer.SaveToXML(weaponownership, "scripts\\CruelMastersOnlineOfflineAssets\\Weapons\\OwnedWeaponary.xml");
							MPLoadout.SAVE_CURRENT_LOADOUT();
							WeaponsItem10.AltTitle = "";
							BadgeSet rightBadgeSet = new BadgeSet
							{
								NormalDictionary = "commonmenu",
								NormalTexture = "shop_gunclub_icon_a",
								HoveredDictionary = "commonmenu",
								HoveredTexture = "shop_gunclub_icon_b"
							};
							WeaponsItem10.RightBadgeSet = rightBadgeSet;
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					};
				}
				else
				{
					WeaponsItem10.Description = $"This item unlocks at Rank {rankNeeded10}.";
					BadgeSet badgeSet35 = new BadgeSet();
					badgeSet35.NormalDictionary = "commonmenu";
					badgeSet35.NormalTexture = "shop_lock";
					badgeSet35.HoveredDictionary = "commonmenu";
					badgeSet35.HoveredTexture = "shop_lock";
					WeaponsItem10.RightBadgeSet = badgeSet35;
				}
			}
			else
			{
				BadgeSet badgeSet36 = new BadgeSet();
				badgeSet36.NormalDictionary = "commonmenu";
				badgeSet36.NormalTexture = "shop_gunclub_icon_a";
				badgeSet36.HoveredDictionary = "commonmenu";
				badgeSet36.HoveredTexture = "shop_gunclub_icon_b";
				WeaponsItem10.RightBadgeSet = badgeSet36;
			}
			nativeMenu20.Add(WeaponsItem10);
			NativeItem WeaponsAmmoItem9 = new NativeItem($"Rounds x {ammoPer9}", "", $"${ammoCost9}");
			if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash10) < 1)
			{
				WeaponsAmmoItem9.AltTitle = $"${ammoCost9}";
				WeaponsAmmoItem9.Enabled = true;
			}
			else
			{
				WeaponsAmmoItem9.AltTitle = "FULL";
				WeaponsAmmoItem9.Enabled = false;
			}
			WeaponsAmmoItem9.Activated += (object sender, EventArgs e) =>
			{
				int num27 = 0;
				if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Game.Player.Character, weaponHash10) < 1)
				{
					WeaponsAmmoItem9.AltTitle = $"${ammoCost9}";
					WeaponsAmmoItem9.Enabled = true;
					if (weaponownership.Weapon.Contains(weaponHash10))
					{
						if (MPCash.PROCESS_TRANSACTION(ammoCost9))
						{
							if (weaponHash10 == WeaponHash.Parachute && !Game.Player.Character.Weapons.HasWeapon(weaponHash10))
							{
								Game.Player.Character.Weapons.Give(weaponHash10, 1, equipNow: false, isAmmoLoaded: true);
							}
							Function.Call(Hash.ADD_AMMO_TO_PED, Game.Player.Character, weaponHash10, ammoPer9);
							MPLoadout.SAVE_CURRENT_LOADOUT();
						}
						else
						{
							Notification.Show("Transaction Failed: Not Enough Money", blinking: true);
						}
					}
					else
					{
						Notification.Show("Transaction Failed: Weapon Not Owned", blinking: true);
					}
				}
				else
				{
					WeaponsAmmoItem9.AltTitle = "FULL";
					WeaponsAmmoItem9.Enabled = false;
					Notification.Show("Transaction Failed: Max Ammo", blinking: true);
				}
			};
			nativeMenu20.Add(WeaponsAmmoItem9);
		}
	}

	public void onTick(object sender, EventArgs e)
	{
		if (CruelMastersOnlineOffline.StorySwitch < 2 && !CruelMastersOnlineOffline.DEBUG)
		{
			return;
		}
		if (MenuPool != null && MenuPool.AreAnyVisible)
		{
			MenuPool.Process();
		}
		if (shopowners.Count == 0)
		{
			Vector3[] array = new Vector3[11]
			{
				new Vector3(1691.958f, 3761.067f, 34.70532f),
				new Vector3(254.2388f, -50.63042f, 69.94106f),
				new Vector3(842.48f, -1035.667f, 28.19486f),
				new Vector3(-331.9211f, 6085.159f, 31.45476f),
				new Vector3(-662.1957f, -933.3081f, 21.82924f),
				new Vector3(-1303.764f, -394.7151f, 36.69576f),
				new Vector3(-1119.132f, 2699.972f, 18.55415f),
				new Vector3(-3173.759f, 1088.667f, 20.83875f),
				new Vector3(2567.888f, 292.1664f, 108.7349f),
				new Vector3(23.01255f, -1105.32f, 29.79703f),
				new Vector3(809.8918f, -2159.331f, 29.61902f)
			};
			float[] array2 = new float[11]
			{
				231.4799f, 68.35813f, 358.0862f, 224.7119f, 177.0904f, 75.50185f, 219.2255f, 246.7184f, 357.877f, 159.212f,
				357.4059f
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (!(Game.Player.Character.Position.DistanceTo(array[i]) < 20f) || CruelMastersOnlineOffline.OnMission)
				{
					continue;
				}
				gundoors = World.GetAllProps(97297972, -8873588);
				Prop[] array3 = gundoors;
				foreach (Prop prop in array3)
				{
					if (prop != null)
					{
						while (prop.IsPositionFrozen)
						{
							prop.IsPositionFrozen = false;
							Script.Wait(0);
						}
					}
				}
				Ped ped = World.CreatePed(PedHash.GunVanSeller, new Vector3(array[i].X, array[i].Y, array[i].Z - 1f), array2[i]);
				ped.AlwaysKeepTask = true;
				ped.BlockPermanentEvents = true;
				ped.CanRagdoll = false;
				ped.RelationshipGroup = Groups.playersTeam;
				ped.IsInvincible = true;
				ped.IsPositionFrozen = true;
				CruelMastersOnlineOffline.LoadDict("random@shop_gunstore");
				CruelMastersOnlineOffline.LoadDict("random@shop_gunstore");
				ped.Task.PlayAnimation("random@shop_gunstore", "_idle", 8f, 8f, -1, AnimationFlags.Loop, -1000f);
				shopowners.Add(ped);
				break;
			}
		}
		else
		{
			int[] array4 = new int[11]
			{
				200961, 140289, 153857, 180481, 168193, 164609, 175617, 176385, 178689, 137729,
				248065
			};
			for (int k = 0; k < array4.Length; k++)
			{
				if (Interiors.GET_INTERIOR_FROM_ENTITY(Game.Player.Character) == array4[k] && !CruelMastersOnlineOffline.DEBUG)
				{
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 21, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 22, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 24, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 25, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 140, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 141, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 142, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 44, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 44, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 37, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 12, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 13, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 14, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 15, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 16, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 17, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 17, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 261, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 262, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 157, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 158, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 159, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 160, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 161, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 162, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 163, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 164, true);
					Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 165, true);
					if ((WeaponHash)Game.Player.Character.Weapons.Current != WeaponHash.Unarmed)
					{
						Game.Player.Character.Weapons.Select(WeaponHash.Unarmed, equipNow: true);
					}
				}
			}
			if (shopowners[0] != null && Game.Player.Character.Position.DistanceTo(shopowners[0].Position) > 30f)
			{
				foreach (Ped item in shopowners.ToList())
				{
					if (item != null)
					{
						item.Delete();
						shopowners.Remove(item);
					}
				}
			}
			if (shopowners.Count > 0 && shopowners[0] != null)
			{
				if (Game.Player.Character.Position.DistanceTo(shopowners[0].Position) < 2f && Function.Call<bool>(Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY_IN_FRONT, Game.Player.Character, shopowners[0]) && !CruelMastersOnlineOffline.OnMission && !MenuPool.AreAnyVisible)
				{
					GTA.UI.Screen.ShowHelpTextThisFrame("Press ~INPUT_CONTEXT~ to browse weapons.");
					if (Game.IsControlJustPressed(Control.Context))
					{
						Mobile_Phone.CAN_OPEN_PHONE = false;
						MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = false;
						MPCash.CAN_SEE_CASH = false;
						MPRank.CAN_SEE_RANK_BAR = false;
						MPPlayerList.CAN_SHOW_LIST = false;
						MenuIsOpen = true;
						SETUP_GUN_STORE_MENU();
						GunStore.Visible = !GunStore.Visible;
					}
				}
				if (MenuIsOpen && !MenuPool.AreAnyVisible)
				{
					Mobile_Phone.CAN_OPEN_PHONE = true;
					MPInteractionMenu.CAN_OPEN_INTERACTION_MENU = true;
					MPCash.CAN_SEE_CASH = true;
					MPRank.CAN_SEE_RANK_BAR = true;
					MPPlayerList.CAN_SHOW_LIST = true;
					GunStore.Visible = false;
					MenuIsOpen = false;
				}
			}
		}
		if (Game.IsControlJustPressed(Control.Context))
		{
		}
		if (!Game.IsControlJustPressed(Control.VehicleDuck))
		{
		}
	}

	public void onShutdown(object sender, EventArgs e)
	{
		if (shopowners.Count <= 0)
		{
			return;
		}
		foreach (Ped item in shopowners.ToList())
		{
			if (item != null)
			{
				item.Delete();
				shopowners.Remove(item);
			}
		}
	}

	public static void SET_WEAPON_OWNERSHIP()
	{
		OwnedWeapons ownedWeapons = new OwnedWeapons
		{
			Weapon = new List<WeaponHash>(),
			Components = new List<WeaponComponentHash>(),
			CompTint = new List<int>(),
			Tint = new List<int>()
		};
		foreach (WeaponHash enumValue in typeof(WeaponHash).GetEnumValues())
		{
			if (!Game.Player.Character.Weapons.HasWeapon(enumValue))
			{
				continue;
			}
			if (!ownedWeapons.Weapon.Contains(enumValue))
			{
				ownedWeapons.Weapon.Add(enumValue);
			}
			foreach (WeaponComponentHash enumValue2 in typeof(WeaponComponentHash).GetEnumValues())
			{
				if (!Game.Player.Character.Weapons[enumValue].Components[enumValue2].Active)
				{
					continue;
				}
				if (!ownedWeapons.Components.Contains(enumValue2))
				{
					ownedWeapons.Components.Add(enumValue2);
				}
				if (!enumValue2.ToString().Contains("Camo"))
				{
					continue;
				}
				for (int i = 0; i < 32; i++)
				{
					if (!ownedWeapons.CompTint.Contains(i))
					{
						ownedWeapons.CompTint.Add(i);
					}
				}
			}
			for (int j = 0; j < Function.Call<int>(Hash.GET_WEAPON_TINT_COUNT, enumValue); j++)
			{
				if (!ownedWeapons.Tint.Contains(j))
				{
					ownedWeapons.Tint.Add(j);
				}
			}
			OwnedWeapons.OwnedWeapon.Add(ownedWeapons);
		}
		XMLSerializer.SaveToXML(OwnedWeapons.OwnedWeapon[0], "scripts\\CruelMastersOnlineOfflineAssets\\OwnedWeaponary.xml");
	}

	public unsafe static DlcWeaponData RETURN_WEAPON_DATA_SP(WeaponHash wep)
	{
		int num = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS_SP);
		int i = 0;
		DlcWeaponData result = default;
		for (; i < num; i++)
		{
			if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA_SP, i, &result) && result.Hash == wep)
			{
				return result;
			}
		}
		return result;
	}

	public unsafe static DlcWeaponData RETURN_WEAPON_DATA_MP(WeaponHash wep)
	{
		int num = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS);
		int i = 0;
		DlcWeaponData result = default;
		for (; i < num; i++)
		{
			if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, i, &result) && result.Hash == wep)
			{
				return result;
			}
		}
		return result;
	}

	public unsafe static DlcWeaponComponentData RETURN_WEAPON_DATA_MP(WeaponHash wep, WeaponComponentHash wepcomp)
	{
		int num = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS);
		int i = 0;
		DlcWeaponData dlcWeaponData = default;
		int num2 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPON_COMPONENTS);
		int j = 0;
		DlcWeaponComponentData result = default;
		for (; i < num && (!Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, i, &dlcWeaponData) || dlcWeaponData.Hash != wep); i++)
		{
		}
		for (; j < num2; j++)
		{
			if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, i, j, &result) && result.Hash == wepcomp)
			{
				return result;
			}
		}
		return result;
	}

	public unsafe static string PtrToStringUTF8(IntPtr ptr)
	{
		if (ptr == IntPtr.Zero)
		{
			return string.Empty;
		}
		byte* ptr2 = (byte*)ptr.ToPointer();
		int i;
		for (i = 0; ptr2[i] != 0; i++)
		{
		}
		return PtrToStringUTF8(ptr, i);
	}

	public unsafe static string PtrToStringUTF8(IntPtr ptr, int len)
	{
		if (len < 0)
		{
			throw new ArgumentException(null, "len");
		}
		if (ptr == IntPtr.Zero)
		{
			return null;
		}
		if (len == 0)
		{
			return string.Empty;
		}
		return Encoding.UTF8.GetString((byte*)ptr.ToPointer(), len);
	}

	public unsafe static string GetDisplayNameFromHash(WeaponHash hash)
	{
		switch (hash)
		{
		case WeaponHash.Unarmed:
			return "WT_UNARMED";
		case WeaponHash.Knife:
			return "WT_KNIFE";
		case WeaponHash.Nightstick:
			return "WT_NGTSTK";
		case WeaponHash.Hammer:
			return "WT_HAMMER";
		case WeaponHash.Bat:
			return "WT_BAT";
		case WeaponHash.Crowbar:
			return "WT_CROWBAR";
		case WeaponHash.GolfClub:
			return "WT_GOLFCLUB";
		case WeaponHash.Pistol:
			return "WT_PIST";
		case WeaponHash.CombatPistol:
			return "WT_PIST_CBT";
		case WeaponHash.Pistol50:
			return "WT_PIST_50";
		case WeaponHash.APPistol:
			return "WT_PIST_AP";
		case WeaponHash.StunGun:
			return "WT_STUN";
		case WeaponHash.MicroSMG:
			return "WT_SMG_MCR";
		case WeaponHash.SMG:
			return "WT_SMG";
		case WeaponHash.AssaultSMG:
			return "WT_SMG_ASL";
		case WeaponHash.AssaultRifle:
			return "WT_RIFLE_ASL";
		case WeaponHash.CarbineRifle:
			return "WT_RIFLE_CBN";
		case WeaponHash.AdvancedRifle:
			return "WT_RIFLE_ADV";
		case WeaponHash.MG:
			return "WT_MG";
		case WeaponHash.CombatMG:
			return "WT_MG_CBT";
		case WeaponHash.PumpShotgun:
			return "WT_SG_PMP";
		case WeaponHash.SawnOffShotgun:
			return "WT_SG_SOF";
		case WeaponHash.AssaultShotgun:
			return "WT_SG_ASL";
		case WeaponHash.BullpupShotgun:
			return "WT_SG_BLP";
		case WeaponHash.SniperRifle:
			return "WT_SNIP_RIF";
		case WeaponHash.HeavySniper:
			return "WT_SNIP_HVY";
		case WeaponHash.GrenadeLauncher:
			return "WT_GL";
		case WeaponHash.RPG:
			return "WT_RPG";
		case WeaponHash.Minigun:
			return "WT_MINIGUN";
		case WeaponHash.Grenade:
			return "WT_GNADE";
		case WeaponHash.StickyBomb:
			return "WT_GNADE_STK";
		case WeaponHash.SmokeGrenade:
			return "WT_GNADE_SMK";
		case WeaponHash.BZGas:
			return "WT_BZGAS";
		case WeaponHash.Molotov:
			return "WT_MOLOTOV";
		case WeaponHash.FireExtinguisher:
			return "WT_FIRE";
		case WeaponHash.PetrolCan:
			return "WT_PETROL";
		case WeaponHash.Ball:
			return "WT_BALL";
		case WeaponHash.Flare:
			return "WT_FLARE";
		case WeaponHash.Bottle:
			return "WT_BOTTLE";
		case WeaponHash.Dagger:
			return "WT_DAGGER";
		case WeaponHash.Hatchet:
			return "WT_HATCHET";
		case WeaponHash.Machete:
			return "WT_MACHETE";
		case WeaponHash.KnuckleDuster:
			return "WT_KNUCKLE";
		case WeaponHash.SNSPistol:
			return "WT_SNSPISTOL";
		case WeaponHash.VintagePistol:
			return "WT_VPISTOL";
		case WeaponHash.HeavyPistol:
			return "WT_HVYPISTOL";
		case WeaponHash.MarksmanPistol:
			return "WT_MKPISTOL";
		case WeaponHash.Gusenberg:
			return "WT_GUSENBERG";
		case WeaponHash.MachinePistol:
			return "WT_MCHPIST";
		case WeaponHash.CombatPDW:
			return "WT_COMBATPDW";
		case WeaponHash.SpecialCarbine:
			return "WT_SPCARBINE";
		case WeaponHash.HeavyShotgun:
			return "WT_HVYSHOT";
		case WeaponHash.Musket:
			return "WT_MUSKET";
		case WeaponHash.MarksmanRifle:
			return "WT_MKRIFLE";
		case WeaponHash.Firework:
			return "WT_FWRKLNCHR";
		case WeaponHash.HomingLauncher:
			return "WT_HOMLNCH";
		case WeaponHash.Railgun:
			return "WT_RAILGUN";
		case WeaponHash.ProximityMine:
			return "WT_PRXMINE";
		case WeaponHash.Snowball:
			return "WT_SNWBALL";
		default:
		{
			int i = 0;
			DlcWeaponData dlcWeaponData = default;
			for (int num = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS); i < num; i++)
			{
				if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, i, &dlcWeaponData) && dlcWeaponData.Hash == hash)
				{
					return dlcWeaponData.DisplayName;
				}
			}
			return "WT_INVALID";
		}
		}
	}

	public unsafe static string GetDisplayDescriptionFromHash(WeaponHash hash)
	{
		switch (hash)
		{
		case WeaponHash.Unarmed:
			return "WTD_UNARMED";
		case WeaponHash.Knife:
			return "WTD_KNIFE";
		case WeaponHash.Nightstick:
			return "WTD_NGTSTK";
		case WeaponHash.Hammer:
			return "WTD_HAMMER";
		case WeaponHash.Bat:
			return "WTD_BAT";
		case WeaponHash.Crowbar:
			return "WTD_CROWBAR";
		case WeaponHash.GolfClub:
			return "WTD_GOLFCLUB";
		case WeaponHash.Pistol:
			return "WTD_PIST";
		case WeaponHash.CombatPistol:
			return "WTD_PIST_CBT";
		case WeaponHash.Pistol50:
			return "WTD_PIST_50";
		case WeaponHash.APPistol:
			return "WTD_PIST_AP";
		case WeaponHash.StunGun:
			return "WTD_STUN";
		case WeaponHash.MicroSMG:
			return "WTD_SMG_MCR";
		case WeaponHash.SMG:
			return "WTD_SMG";
		case WeaponHash.AssaultSMG:
			return "WTD_SMG_ASL";
		case WeaponHash.AssaultRifle:
			return "WTD_RIFLE_ASL";
		case WeaponHash.CarbineRifle:
			return "WTD_RIFLE_CBN";
		case WeaponHash.AdvancedRifle:
			return "WTD_RIFLE_ADV";
		case WeaponHash.MG:
			return "WTD_MG";
		case WeaponHash.CombatMG:
			return "WTD_MG_CBT";
		case WeaponHash.PumpShotgun:
			return "WTD_SG_PMP";
		case WeaponHash.SawnOffShotgun:
			return "WTD_SG_SOF";
		case WeaponHash.AssaultShotgun:
			return "WTD_SG_ASL";
		case WeaponHash.BullpupShotgun:
			return "WTD_SG_BLP";
		case WeaponHash.SniperRifle:
			return "WTD_SNIP_RIF";
		case WeaponHash.HeavySniper:
			return "WTD_SNIP_HVY";
		case WeaponHash.GrenadeLauncher:
			return "WTD_GL";
		case WeaponHash.RPG:
			return "WTD_RPG";
		case WeaponHash.Minigun:
			return "WTD_MINIGUN";
		case WeaponHash.Grenade:
			return "WTD_GNADE";
		case WeaponHash.StickyBomb:
			return "WTD_GNADE_STK";
		case WeaponHash.SmokeGrenade:
			return "WTD_GNADE_SMK";
		case WeaponHash.BZGas:
			return "WTD_BZGAS";
		case WeaponHash.Molotov:
			return "WTD_MOLOTOV";
		case WeaponHash.FireExtinguisher:
			return "WTD_FIRE";
		case WeaponHash.PetrolCan:
			return "WTD_PETROL";
		case WeaponHash.Ball:
			return "WTD_BALL";
		case WeaponHash.Flare:
			return "WTD_FLARE";
		case WeaponHash.Bottle:
			return "WTD_BOTTLE";
		case WeaponHash.Dagger:
			return "WTD_DAGGER";
		case WeaponHash.Hatchet:
			return "WTD_HATCHET";
		case WeaponHash.Machete:
			return "WTD_MACHETE";
		case WeaponHash.KnuckleDuster:
			return "WTD_KNUCKLE";
		case WeaponHash.SNSPistol:
			return "WTD_SNSPISTOL";
		case WeaponHash.VintagePistol:
			return "WTD_VPISTOL";
		case WeaponHash.HeavyPistol:
			return "WTD_HVYPISTOL";
		case WeaponHash.MarksmanPistol:
			return "WTD_MKPISTOL";
		case WeaponHash.Gusenberg:
			return "WTD_GUSENBERG";
		case WeaponHash.MachinePistol:
			return "WTD_MCHPIST";
		case WeaponHash.CombatPDW:
			return "WTD_COMBATPDW";
		case WeaponHash.SpecialCarbine:
			return "WTD_SPCARBINE";
		case WeaponHash.HeavyShotgun:
			return "WTD_HVYSHOT";
		case WeaponHash.Musket:
			return "WTD_MUSKET";
		case WeaponHash.MarksmanRifle:
			return "WTD_MKRIFLE";
		case WeaponHash.Firework:
			return "WTD_FWRKLNCHR";
		case WeaponHash.HomingLauncher:
			return "WTD_HOMLNCH";
		case WeaponHash.Railgun:
			return "WTD_RAILGUN";
		case WeaponHash.ProximityMine:
			return "WTD_PRXMINE";
		case WeaponHash.Snowball:
			return "WTD_SNWBALL";
		default:
		{
			int i = 0;
			DlcWeaponData dlcWeaponData = default;
			for (int num = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS); i < num; i++)
			{
				if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, i, &dlcWeaponData) && dlcWeaponData.Hash == hash)
				{
					return dlcWeaponData.DescriptionLabel;
				}
			}
			return "WTD_INVALID";
		}
		}
	}

	public unsafe static int func_83(int iParam0, DlcWeaponData uParam1)
	{
		int num = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS);
		for (int i = 0; i < num; i++)
		{
			if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, i, &uParam1) && uParam1.Hash == (WeaponHash)iParam0)
			{
				return i;
			}
		}
		return -1;
	}
}
