#pragma once

#include "main.h"
#include "natives.hpp"

// The script loop. ScriptHookV runs it on a game script thread.
void ScriptMain();

// Receives every key event (see keyboardHandlerRegister in main.h).
void OnKeyboardMessage(DWORD key, WORD repeats, BYTE scanCode, BOOL isExtended, BOOL isWithAlt, BOOL wasDownBefore, BOOL isUpNow);
