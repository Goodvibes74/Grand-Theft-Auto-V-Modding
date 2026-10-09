// Types used by the native functions in natives.hpp. They match the official ScriptHookV SDK's types.h.
// Every game object (ped, vehicle, blip, ...) is an int handle: a number the game gives you to refer to it.

#pragma once

#include <windows.h>

typedef DWORD Void;
typedef DWORD Any;
typedef DWORD uint;
typedef DWORD Hash;
typedef int Entity;
typedef int Player;
typedef int FireId;
typedef int Ped;
typedef int Vehicle;
typedef int Cam;
typedef int CarGenerator;
typedef int Group;
typedef int Train;
typedef int Pickup;
typedef int Object;
typedef int Weapon;
typedef int Interior;
typedef int Blip;
typedef int Texture;
typedef int TextureDict;
typedef int CoverPoint;
typedef int Camera;
typedef int TaskSequence;
typedef int ColourIndex;
typedef int Sphere;
typedef int ScrHandle;

// The game stores each float of a vector in its own 8-byte slot, hence the padding.
#pragma pack(push, 1)
struct Vector3
{
	float x;
	DWORD _paddingx;
	float y;
	DWORD _paddingy;
	float z;
	DWORD _paddingz;
};
#pragma pack(pop)

static_assert(sizeof(Vector3) == 24, "Vector3 must match the game's 3 x 8-byte layout");
