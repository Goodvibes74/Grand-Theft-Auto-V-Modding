# GTA V Legacy Lua Menu Controls

This project includes a lightweight Lua GUI menu that can be controlled with both keyboard and gamepad input.

## Activate the menu

The menu is controlled through the addin loader. The example menu is present in `scripts/addins/exampleGUI.lua`, but it is disabled by default because the GUI setup is commented out.

To activate it:

1. Open `scripts/addins/exampleGUI.lua`
2. Uncomment the `exampleGUI.GUI = Libs["GUI"]` block
3. Uncomment the `GUI.addButton(...)` lines
4. Save the file and reload the mod script

Once the addin runs, the menu becomes active and the script will begin checking input.

## Keyboard controls

The default keyboard bindings are defined in `scripts/libs/GUI.lua`:

- `NumPad8` = move selection up
- `NumPad2` = move selection down
- `Space` = activate the currently selected button

These are checked with the helper function `get_key_pressed()`.

## Controller controls

Controller support is also enabled in `scripts/libs/GUI.lua` using `PAD.IS_CONTROL_JUST_PRESSED(...)`.

The menu supports the usual dual-stick / D-pad style controls for Xbox and PlayStation controllers:

- D-pad Up / Left stick Up = move selection up
- D-pad Down / Left stick Down = move selection down
- A / Cross = activate the selected button

The controller mapping is defined in the `GUI.controller` table and can be adjusted if needed.

## Files involved

- `scripts/main.lua` - loads the libs and addins
- `scripts/libs/GUI.lua` - handles menu rendering and input
- `scripts/addins/exampleGUI.lua` - example menu setup
- `scripts/keys.lua` - keyboard key mapping

## Troubleshooting

If the menu does not respond:

- Make sure the addin is enabled in `scripts/addins/exampleGUI.lua`
- Check that `scripts/main.lua` is loading the modules correctly
- Confirm the game is not blocking input while a menu or phone is open
- If needed, adjust the numbers in `GUI.controller` to the correct GTA control IDs for your setup

## Quick summary

Keyboard:

- `NumPad8` / `NumPad2` = browse
- `Space` = select

Controller:

- D-pad Up / Down = browse
- A / Cross = select

If you want to add more buttons or custom actions, just add new `GUI.addButton(...)` entries in the example GUI init block.
