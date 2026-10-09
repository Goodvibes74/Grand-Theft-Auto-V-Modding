// HelloAsi: shows a notification when the game has loaded, then, while the toggle key is on,
// draws the player's position on screen every frame.

#include "script.h"

#include <cstdio>

// No key by default, so the template can't clash with another mod. To try it, pick a free key from
// docs/mods_info/HOTKEYS.md and set it here, for example VK_PAUSE.
static const DWORD ToggleKey = 0;

static volatile bool togglePressed = false;
static bool showPosition = false;

void OnKeyboardMessage(DWORD key, WORD, BYTE, BOOL, BOOL, BOOL wasDownBefore, BOOL isUpNow)
{
	// Runs on the window thread: only record the press, act on it in the script loop.
	if (ToggleKey != 0 && key == ToggleKey && !isUpNow && !wasDownBefore)
		togglePressed = true;
}

static void Notify(const char* text)
{
	HUD::BEGIN_TEXT_COMMAND_THEFEED_POST("STRING");
	HUD::ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
	HUD::END_TEXT_COMMAND_THEFEED_POST_TICKER(FALSE, TRUE);
}

static void DrawText(const char* text, float x, float y)
{
	HUD::SET_TEXT_FONT(0);
	HUD::SET_TEXT_SCALE(0.0f, 0.4f);
	HUD::SET_TEXT_COLOUR(255, 255, 255, 255);
	HUD::SET_TEXT_OUTLINE();
	HUD::BEGIN_TEXT_COMMAND_DISPLAY_TEXT("STRING");
	HUD::ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(text);
	HUD::END_TEXT_COMMAND_DISPLAY_TEXT(x, y, 0);
}

void ScriptMain()
{
	// Wait until the loading screen is gone.
	while (DLC::GET_IS_LOADING_SCREEN_ACTIVE())
		scriptWait(0);

	Notify("HelloAsi loaded");

	while (true)
	{
		if (togglePressed)
		{
			togglePressed = false;
			showPosition = !showPosition;
		}

		if (showPosition)
		{
			Ped player = PLAYER::PLAYER_PED_ID();
			Vector3 pos = ENTITY::GET_ENTITY_COORDS(player, TRUE);
			char buffer[96];
			std::snprintf(buffer, sizeof(buffer), "X %.1f  Y %.1f  Z %.1f", pos.x, pos.y, pos.z);
			DrawText(buffer, 0.01f, 0.01f);
		}

		// Give control back to the game for one frame. Every loop iteration must wait.
		scriptWait(0);
	}
}
