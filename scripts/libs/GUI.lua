local GUI = {}
GUI.GUI = {}
GUI.buttonCount = 0
GUI.loaded = false
GUI.selection = 0
GUI.time = 0
GUI.hidden = false
GUI.menuOpen = false

-- Controller mappings: Xbox name first, PlayStation equivalent in parentheses.
-- These are GTA V control IDs, not keyboard key codes from scripts/keys.lua.
GUI.controller = {
	Up = 187,       -- D-pad Up / D-pad Up
	Down = 188,     -- D-pad Down / D-pad Down
	Accept = 201,   -- A / Cross
	Back = 202,     -- B / Circle
	A = 201,        -- A / Cross
	B = 202,        -- B / Circle
	RB = 107,       -- Right Bumper / R1
	LB = 106,       -- Left Bumper / L1
	RL = 205,       -- Right Stick click / R3
	LT = 206        -- Left Trigger / L2
}

-- Menu toggle combos. Hold all three buttons together.
GUI.openCombo = { "A", "RB", "RL" }
GUI.closeCombo = { "B", "LB", "LT" }

function GUI.isKeyboardPressed(key)
	if get_key_pressed ~= nil then
		return get_key_pressed(key)
	end
	return false
end

function GUI.isControllerPressed(control)
	if PAD ~= nil and type(PAD.IS_CONTROL_JUST_PRESSED) == "function" then
		return PAD.IS_CONTROL_JUST_PRESSED(0, control)
	end
	return false
end

function GUI.isComboPressed(combo)
	if type(combo) ~= "table" then
		return false
	end
	for _, controlName in ipairs(combo) do
		local controlId = GUI.controller[controlName]
		if controlId == nil then
			return false
		end
		if not GUI.isControllerPressed(controlId) then
			return false
		end
	end
	return true
end

function GUI.addButton(name, func,args, xmin, xmax, ymin, ymax)
	print("Added Button"..name )
	GUI.GUI[GUI.buttonCount +1] = {}
	GUI.GUI[GUI.buttonCount +1]["name"] = name
	GUI.GUI[GUI.buttonCount+1]["func"] = func
	GUI.GUI[GUI.buttonCount+1]["args"] = args
	GUI.GUI[GUI.buttonCount+1]["active"] = false
	GUI.GUI[GUI.buttonCount+1]["xmin"] = xmin
	GUI.GUI[GUI.buttonCount+1]["ymin"] = ymin * (GUI.buttonCount + 0.01) +0.02
	GUI.GUI[GUI.buttonCount+1]["xmax"] = xmax 
	GUI.GUI[GUI.buttonCount+1]["ymax"] = ymax 
	GUI.buttonCount = GUI.buttonCount+1
end
function GUI.unload()
end
function GUI.init()

	GUI.loaded = true
end
function GUI.tick()
	if GUI.isComboPressed(GUI.openCombo) then
		GUI.hidden = false
		GUI.menuOpen = true
		GUI.time = 0
	elseif GUI.isComboPressed(GUI.closeCombo) then
		GUI.hidden = true
		GUI.menuOpen = false
		GUI.time = 0
	end

	if(not GUI.hidden)then
		if( GUI.time == 0) then
			GUI.time = GAMEPLAY.GET_GAME_TIMER()
		end
		if((GAMEPLAY.GET_GAME_TIMER() - GUI.time)> 100) then
			GUI.updateSelection()
		end	
		GUI.renderGUI()	
		if(not GUI.loaded ) then
			GUI.init()	 
		end
	end
end

function GUI.updateSelection() 
	if(GUI.isKeyboardPressed(Keys.NumPad2) or GUI.isControllerPressed(GUI.controller.Down)) then 
		if(GUI.selection < GUI.buttonCount -1  )then
			GUI.selection = GUI.selection +1
			GUI.time = 0
		end
	elseif (GUI.isKeyboardPressed(Keys.NumPad8) or GUI.isControllerPressed(GUI.controller.Up))then
		if(GUI.selection > 0)then
			GUI.selection = GUI.selection -1
			GUI.time = 0
		end
	elseif (GUI.isKeyboardPressed(Keys.Space) or GUI.isControllerPressed(GUI.controller.Accept)) then
		if(type(GUI.GUI[GUI.selection +1]["func"]) == "function") then
			GUI.GUI[GUI.selection +1]["func"](GUI.GUI[GUI.selection +1]["args"])
		else
			print(type(GUI.GUI[GUI.selection]["func"]))
		end
		GUI.time = 0
	end
	local iterator = 0
	for id, settings in ipairs(GUI.GUI) do
		GUI.GUI[id]["active"] = false
		if(iterator == GUI.selection ) then
			GUI.GUI[iterator +1]["active"] = true
		end
		iterator = iterator +1
	end
end

function GUI.renderGUI()
	 GUI.renderButtons()
end
function GUI.renderBox(xMin,xMax,yMin,yMax,color1,color2,color3,color4)
	GRAPHICS.DRAW_RECT(xMin, yMin,xMax, yMax, color1, color2, color3, color4);
end

function GUI.renderButtons()
	
	for id, settings in pairs(GUI.GUI) do
		local screen_w = 0
		local screen_h = 0
		screen_w, screen_h =  GRAPHICS.GET_SCREEN_RESOLUTION(0, 0)
		boxColor = {70,95,95,255}
		if(settings["active"]) then
			boxColor = {218,242,216,255}
		end
		UI.SET_TEXT_FONT(0)
		UI.SET_TEXT_SCALE(0.0, 0.35)
		UI.SET_TEXT_COLOUR(255, 255, 255, 255)
		UI.SET_TEXT_CENTRE(true)
		UI.SET_TEXT_DROPSHADOW(0, 0, 0, 0, 0)
		UI.SET_TEXT_EDGE(0, 0, 0, 0, 0)
		UI._SET_TEXT_ENTRY("STRING")
		UI._ADD_TEXT_COMPONENT_STRING(settings["name"])
		UI._DRAW_TEXT(settings["xmin"]+ 0.05, (settings["ymin"] - 0.0125 ))
		UI._ADD_TEXT_COMPONENT_STRING(settings["name"])
		GUI.renderBox(settings["xmin"] ,settings["xmax"], settings["ymin"], settings["ymax"],boxColor[1],boxColor[2],boxColor[3],boxColor[4])
	 end     
end
return GUI