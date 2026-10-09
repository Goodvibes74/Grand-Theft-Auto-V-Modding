// Entry point. Windows calls DllMain when the ASI loader (dinput8.dll) loads HelloAsi.asi into GTA5.exe.
// Only register and unregister here: natives can't be called from DllMain.

#include "script.h"

BOOL APIENTRY DllMain(HMODULE module, DWORD reason, LPVOID)
{
	switch (reason)
	{
	case DLL_PROCESS_ATTACH:
		scriptRegister(module, ScriptMain);
		keyboardHandlerRegister(OnKeyboardMessage);
		break;
	case DLL_PROCESS_DETACH:
		scriptUnregister(module);
		keyboardHandlerUnregister(OnKeyboardMessage);
		break;
	}
	return TRUE;
}
