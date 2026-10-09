using System;
using System.Globalization;
using System.Xml;
using GTA;
using GTA.Native;

namespace HomeInvasion;

// Police behaviour, read from the <Cops> block in scripts\HomeInvasion.xml.
// Every value is optional: a missing or invalid entry keeps the default below,
// and the defaults match the original mod, so an old XML file still works.
public static class CopSettings
{
	// Wanted level given when someone calls the police or you leave with a witness alive (0 to 5).
	public static int WantedLevel = 2;

	// Delay between the call and the units arriving inside the home, in milliseconds.
	public static int DispatchDelayMinMs = 5000;

	public static int DispatchDelayMaxMs = 20000;

	// false: the mod spawns no cops or SWAT of its own, so a police overhaul (RDE) handles the response.
	public static bool SpawnInteriorUnits = true;

	// Chance (0 to 100) that the arriving units are a SWAT team instead of police.
	public static int SwatChancePercent = 25;

	public static int SwatCount = 2;

	public static int SwatArmor = 100;

	public static WeaponHash SwatWeapon = WeaponHash.SMG;

	// Chance (0 to 100) that a second officer arrives with the first.
	public static int SecondCopChancePercent = 50;

	public static WeaponHash CopWeapon = WeaponHash.PumpShotgun;

	public static WeaponHash SecondCopWeapon = WeaponHash.Pistol;

	// Chance (0 to 100) that a startled witness phones the police, once per home.
	// The original picked it with a 1-in-6 roll.
	public static int CallPolicePercent = 17;

	public static void Load(XmlDocument doc)
	{
		XmlNode cops = doc.SelectSingleNode("//Cops");
		if (cops == null)
		{
			return;
		}
		WantedLevel = ReadInt(cops, "WantedLevel", WantedLevel, 0, 5);
		DispatchDelayMinMs = ReadInt(cops, "DispatchDelayMinMs", DispatchDelayMinMs, 0, 600000);
		DispatchDelayMaxMs = ReadInt(cops, "DispatchDelayMaxMs", DispatchDelayMaxMs, 0, 600000);
		if (DispatchDelayMaxMs < DispatchDelayMinMs)
		{
			DispatchDelayMaxMs = DispatchDelayMinMs;
		}
		SpawnInteriorUnits = ReadBool(cops, "SpawnInteriorUnits", SpawnInteriorUnits);
		SwatChancePercent = ReadInt(cops, "SwatChancePercent", SwatChancePercent, 0, 100);
		SwatCount = ReadInt(cops, "SwatCount", SwatCount, 0, 8);
		SwatArmor = ReadInt(cops, "SwatArmor", SwatArmor, 0, 100);
		SwatWeapon = ReadWeapon(cops, "SwatWeapon", SwatWeapon);
		SecondCopChancePercent = ReadInt(cops, "SecondCopChancePercent", SecondCopChancePercent, 0, 100);
		CopWeapon = ReadWeapon(cops, "CopWeapon", CopWeapon);
		SecondCopWeapon = ReadWeapon(cops, "SecondCopWeapon", SecondCopWeapon);
		CallPolicePercent = ReadInt(cops, "CallPolicePercent", CallPolicePercent, 0, 100);
	}

	private static string ReadValue(XmlNode parent, string name)
	{
		XmlNode node = parent.SelectSingleNode(name);
		if (node == null)
		{
			return null;
		}
		XmlAttribute attr = node.Attributes["value"];
		return attr != null ? attr.InnerText : node.InnerText;
	}

	private static int ReadInt(XmlNode parent, string name, int fallback, int min, int max)
	{
		int value;
		if (!int.TryParse(ReadValue(parent, name), NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
		{
			return fallback;
		}
		return Math.Max(min, Math.Min(max, value));
	}

	private static bool ReadBool(XmlNode parent, string name, bool fallback)
	{
		bool value;
		return bool.TryParse(ReadValue(parent, name), out value) ? value : fallback;
	}

	private static WeaponHash ReadWeapon(XmlNode parent, string name, WeaponHash fallback)
	{
		string text = ReadValue(parent, name);
		if (string.IsNullOrEmpty(text))
		{
			return fallback;
		}
		try
		{
			return (WeaponHash)Enum.Parse(typeof(WeaponHash), text.Trim(), true);
		}
		catch (ArgumentException)
		{
			return fallback;
		}
	}
}
