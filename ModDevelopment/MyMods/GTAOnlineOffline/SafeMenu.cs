using System;
using LemonUI.Menus;

namespace GTAOnlineOffline;

// The original mod (2021) assigned saved values to LemonUI list items without checking that the value is in the list.
// Old LemonUI ignored that; LemonUI 2.x throws InvalidOperationException, which aborts the whole script
// (for example "Mom Name = None" from a fresh ini). This keeps the current selection when the value is not in the list.
internal static class SafeMenu
{
	public static void Select<T>(NativeListItem<T> item, T value)
	{
		try
		{
			item.SelectedItem = value;
		}
		catch (InvalidOperationException)
		{
		}
	}
}
