using GTA;
using GTA.Native;
using System;
using System.Windows.Forms;

namespace PhoneGuard
{
	/// <summary>
	/// Keeps the phone shut while a TrainerV or Menyoo menu is open.
	/// D-pad up is both "menu up" and INPUT_PHONE, and neither trainer blocks the phone or says
	/// whether its menu is open. This script guesses from their open and back buttons and disables
	/// INPUT_PHONE while it thinks a menu is open. It also publishes the guess as the AppDomain flag
	/// "PhoneGuard.MenuOpen", which the CruelMasters phone reads (it ticks before this script).
	/// </summary>
	public class PhoneGuardScript : Script
	{
		private const int InputPhone = 27;

		// Gamepad controls (frontend IDs), matching trainerv.ini and menyooStuff/menyooConfig.ini.
		private const int ControlRb = 206;
		private const int ControlX = 203;
		private const int ControlA = 201;
		private const int ControlB = 202;
		private const int ControlUp = 188;
		private const int ControlDown = 187;
		private const int ControlLeft = 189;
		private const int ControlRight = 190;

		private readonly Keys trainerKey;
		private readonly Keys menyooKey;
		private readonly int backCloseMs;
		private readonly int idleCloseMs;

		private bool menuOpen;
		private int lastInputTime;
		private int lastBackTime = -1;

		public PhoneGuardScript()
		{
			ScriptSettings settings = ScriptSettings.Load(@"scripts\PhoneGuard.ini");
			trainerKey = settings.GetValue("Keys", "TrainerVKey", Keys.F3);
			menyooKey = settings.GetValue("Keys", "MenyooKey", Keys.F8);
			backCloseMs = settings.GetValue("Timing", "BackCloseMs", 3000);
			idleCloseMs = settings.GetValue("Timing", "IdleCloseMs", 20000);

			Tick += OnTick;
			KeyDown += OnKeyDown;
			Aborted += (sender, e) => AppDomain.CurrentDomain.SetData("PhoneGuard.MenuOpen", false);
		}

		private void OnTick(object sender, EventArgs e)
		{
			int now = Game.GameTime;

			// Gamepad open combos: TrainerV RB + X, Menyoo RB + D-pad Left. Pressing one again closes it.
			if (Pressed(ControlRb) && (JustPressed(ControlX) || JustPressed(ControlLeft)))
			{
				Toggle(now);
			}
			else if (menuOpen)
			{
				if (JustPressed(ControlUp) || JustPressed(ControlDown) || JustPressed(ControlLeft) || JustPressed(ControlRight) || JustPressed(ControlA))
				{
					Navigate(now);
				}
				if (JustPressed(ControlB))
				{
					Back(now);
				}
			}

			if (menuOpen)
			{
				// One B press at the top level closes a trainer, but in a submenu it only goes back a level.
				// So a back press closes the guess only if no menu input follows it soon.
				if (lastBackTime >= 0 && now - lastBackTime > backCloseMs)
				{
					menuOpen = false;
				}
				else if (now - lastInputTime > idleCloseMs)
				{
					menuOpen = false;
				}
			}

			if (menuOpen)
			{
				Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, InputPhone, true);
			}
			AppDomain.CurrentDomain.SetData("PhoneGuard.MenuOpen", menuOpen);
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			int now = Game.GameTime;
			if (e.KeyCode == trainerKey || e.KeyCode == menyooKey)
			{
				Toggle(now);
			}
			else if (!menuOpen)
			{
				return;
			}
			else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.NumPad0)
			{
				Back(now);
			}
			else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad5
				|| e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
			{
				Navigate(now);
			}
		}

		private void Toggle(int now)
		{
			menuOpen = !menuOpen;
			lastInputTime = now;
			lastBackTime = -1;
		}

		private void Navigate(int now)
		{
			lastInputTime = now;
			lastBackTime = -1;
		}

		private void Back(int now)
		{
			// Two back presses within a second: the player is backing out of the menu.
			if (lastBackTime >= 0 && now - lastBackTime < 1000)
			{
				menuOpen = false;
			}
			lastInputTime = now;
			lastBackTime = now;
		}

		private static bool Pressed(int control)
		{
			// The DISABLED variants also report controls a trainer has disabled. Menyoo disables the frontend
			// controls while its menu is open, so the plain variants missed every input and the guess timed out.
			return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 2, control);
		}

		private static bool JustPressed(int control)
		{
			return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, 2, control);
		}
	}
}
