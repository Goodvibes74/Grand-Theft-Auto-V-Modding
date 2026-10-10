using GTA;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ModGuide
{
	// One control of a mod, as read from ModGuide.xml.
	internal sealed class ModControl
	{
		public string Action;
		public string Keyboard;
		public string Xbox;
		public string PlayStation;
		public string Note;
	}

	internal sealed class ModEntry
	{
		public string Name;
		public string Description;
		public string Activate;
		public string Config;
		public List<ModControl> Controls = new List<ModControl>();
	}

	public class ModGuideScript : Script
	{
		private static readonly string[] DisplayModes = { "Keyboard", "Xbox", "PlayStation" };

		private readonly ObjectPool pool = new ObjectPool();
		private readonly NativeMenu mainMenu = new NativeMenu("Mod Guide", "Installed mods");
		private readonly NativeListItem<string> displayItem = new NativeListItem<string>("Show controls for", "Choose which keys or buttons the lists show. Every control's description always lists all three.", DisplayModes);
		private readonly List<KeyValuePair<NativeItem, ModControl>> controlItems = new List<KeyValuePair<NativeItem, ModControl>>();

		private Keys menuKey = Keys.F12;
		private GTA.Control controllerHold = GTA.Control.FrontendRb;
		private GTA.Control controllerPress = GTA.Control.FrontendDown;
		private string controllerType = "Xbox";

		public ModGuideScript()
		{
			LoadSettings();

			pool.Add(mainMenu);
			mainMenu.Add(displayItem);
			displayItem.ItemChanged += (sender, e) => RefreshControlLabels();

			BuildMenus();

			Tick += OnTick;
			KeyDown += OnKeyDown;
		}

		private void LoadSettings()
		{
			ScriptSettings settings = ScriptSettings.Load(Path.Combine(BaseDirectory, "ModGuide.ini"));

			if (Enum.TryParse(settings.GetValue("Keys", "MenuKey", "F12"), true, out Keys key))
				menuKey = key;
			if (Enum.TryParse(settings.GetValue("Keys", "ControllerHold", "FrontendRb"), true, out GTA.Control hold))
				controllerHold = hold;
			if (Enum.TryParse(settings.GetValue("Keys", "ControllerPress", "FrontendDown"), true, out GTA.Control press))
				controllerPress = press;

			string type = settings.GetValue("Display", "ControllerType", "Xbox");
			controllerType = type.Equals("PlayStation", StringComparison.OrdinalIgnoreCase) ? "PlayStation" : "Xbox";
		}

		private void BuildMenus()
		{
			List<ModEntry> mods;
			try
			{
				mods = LoadMods(Path.Combine(BaseDirectory, "ModGuide.xml"));
			}
			catch (Exception ex)
			{
				mainMenu.Add(new NativeItem("ModGuide.xml could not be read", ex.Message));
				Notification.PostTicker("~r~Mod Guide:~s~ ModGuide.xml could not be read. See ScriptHookVDotNet.log.", true);
				throw;
			}

			foreach (ModEntry mod in mods)
			{
				NativeMenu modMenu = new NativeMenu("Mod Guide", mod.Name);
				pool.Add(modMenu);

				NativeSubmenuItem modItem = mainMenu.AddSubMenu(modMenu);
				modItem.Description = mod.Description;

				modMenu.Add(new NativeItem("What it does", mod.Description));
				if (!string.IsNullOrEmpty(mod.Activate))
					modMenu.Add(new NativeItem("How to activate", mod.Activate));

				foreach (ModControl control in mod.Controls)
				{
					NativeItem item = new NativeItem(control.Action, DescribeControl(control));
					modMenu.Add(item);
					controlItems.Add(new KeyValuePair<NativeItem, ModControl>(item, control));
				}

				if (!string.IsNullOrEmpty(mod.Config))
					modMenu.Add(new NativeItem("Settings file", mod.Config + "~n~How to edit it: docs/mods_info/SETTINGS.md"));
			}
		}

		private static List<ModEntry> LoadMods(string path)
		{
			XDocument doc = XDocument.Load(path);
			return doc.Root.Elements("Mod").Select(m => new ModEntry
			{
				Name = (string)m.Attribute("name") ?? "Unnamed mod",
				Description = Clean((string)m.Element("Description")),
				Activate = Clean((string)m.Element("Activate")),
				Config = Clean((string)m.Element("Config")),
				Controls = m.Elements("Control").Select(c => new ModControl
				{
					Action = (string)c.Attribute("action") ?? "",
					Keyboard = (string)c.Attribute("keyboard") ?? "none",
					Xbox = (string)c.Attribute("xbox") ?? "none",
					PlayStation = (string)c.Attribute("playstation") ?? "none",
					Note = (string)c.Attribute("note"),
				}).ToList(),
			}).ToList();
		}

		// Collapses the indentation and line breaks of multi-line XML text into single spaces.
		private static string Clean(string text)
		{
			if (text == null)
				return null;
			return string.Join(" ", text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries));
		}

		private static string DescribeControl(ModControl control)
		{
			string text = "Keyboard: " + control.Keyboard + "~n~Xbox: " + control.Xbox + "~n~PlayStation: " + control.PlayStation;
			if (!string.IsNullOrEmpty(control.Note))
				text += "~n~" + control.Note;
			return text;
		}

		private void RefreshControlLabels()
		{
			string mode = displayItem.SelectedItem;
			foreach (KeyValuePair<NativeItem, ModControl> pair in controlItems)
			{
				ModControl control = pair.Value;
				pair.Key.AltTitle = mode == "Xbox" ? control.Xbox : mode == "PlayStation" ? control.PlayStation : control.Keyboard;
			}
		}

		private void OpenMenu()
		{
			// Show the device the player is using right now.
			string mode = Game.LastInputMethod == InputMethod.GamePad ? controllerType : "Keyboard";
			displayItem.SelectedIndex = Array.IndexOf(DisplayModes, mode);
			RefreshControlLabels();
			mainMenu.Visible = true;
		}

		private void OnTick(object sender, EventArgs e)
		{
			pool.Process();

			// D-pad up is both "menu up" and the phone. Block the phone while the guide is open: the
			// control disable covers the story-mode phone, the AppDomain flag covers the CruelMasters
			// phone, which ticks before this script.
			bool open = pool.AreAnyVisible;
			AppDomain.CurrentDomain.SetData("ModGuide.MenuOpen", open);
			if (open)
				Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, 27, true);

			// Controller combo: hold the first button, press the second. Only checked on a gamepad,
			// because the frontend controls are also mapped to keyboard keys.
			// The Game.IsControl* calls are marked obsolete in SHVDN 3.7 but still work, and their
			// replacement takes a different control type that ModGuide.ini can't name.
#pragma warning disable CS0618
			if (!pool.AreAnyVisible
				&& Game.LastInputMethod == InputMethod.GamePad
				&& Game.IsControlPressed(controllerHold)
				&& Game.IsControlJustPressed(controllerPress))
			{
				OpenMenu();
			}
#pragma warning restore CS0618
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != menuKey)
				return;

			if (pool.AreAnyVisible)
				pool.HideAll();
			else
				OpenMenu();
		}
	}
}
