using LemonUI.Menus;

namespace CruelMastersOnlineOffline;

internal class Lemonui_Plus : NativeItem
{
	public int modIndex;

	public Lemonui_Plus(string title, string subtitle, int mod_Index)
		: base(title, subtitle)
	{
		modIndex = mod_Index;
	}
}
