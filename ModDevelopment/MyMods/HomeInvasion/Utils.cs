using System;
using System.Collections.Generic;
using GTA;
using GTA.Math;
using GTA.Native;

namespace HomeInvasion;

public static class Utils
{
	private static Random rand = new Random();

	public static void DisplayHelpTextThisFrame(string text)
	{
		Function.Call(Hash._0x8509B634FBE7DA11, new InputArgument[1] { "STRING" });
		Function.Call(Hash._0x6C188BE134E074AA, new InputArgument[1] { text });
		Function.Call(Hash._0x238FFE5C7B0498A6, new InputArgument[4] { 0, 0, 1, -1 });
	}

	public static void SetInteriorActiveCoords(Vector3 coords)
	{
		int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, new InputArgument[3] { coords.X, coords.Y, coords.Z });
		Function.Call(Hash._0x2CA429C029CCF247, new InputArgument[1] { num });
		Function.Call(Hash._0xE37B76C387BE28ED, new InputArgument[2] { num, 1 });
		Function.Call(Hash._0x6170941419D7D8EC, new InputArgument[2] { num, 0 });
	}

	public static void SetInteriorActive(int interiorID)
	{
		Function.Call(Hash._0x2CA429C029CCF247, new InputArgument[1] { interiorID });
		Function.Call(Hash._0xE37B76C387BE28ED, new InputArgument[2] { interiorID, 1 });
		Function.Call(Hash._0x6170941419D7D8EC, new InputArgument[2] { interiorID, 0 });
	}

	public static void ReloadCurrentInterior()
	{
		Function.Call(Hash._0x2CA429C029CCF247, new InputArgument[1] { GetCurrentInterior() });
		Function.Call(Hash._0xE37B76C387BE28ED, new InputArgument[2]
		{
			GetCurrentInterior(),
			true
		});
		Function.Call(Hash._0x6170941419D7D8EC, new InputArgument[2]
		{
			GetCurrentInterior(),
			false
		});
		Function.Call(Hash._0x41F37C3427C75AE0, new InputArgument[1] { GetCurrentInterior() });
		Function.Call(Hash._0xBD6E84632DD4CB3F, new InputArgument[0]);
		Entity[] allEntities = World.GetAllEntities();
		foreach (Entity entity in allEntities)
		{
			if (Function.Call<int>(Hash._0x2107BA504071A6BB, new InputArgument[1] { entity }) == GetCurrentInterior())
			{
				Function.Call(Hash._0x52923C4710DD9907, new InputArgument[3]
				{
					entity,
					GetCurrentInterior(),
					Function.Call<int>(Hash._0x47C2A06D4F5F424B, new InputArgument[1] { entity })
				});
			}
		}
	}

	public static void ForceRoomInCurrentInterior(this Entity entity)
	{
		Function.Call(Hash._0x52923C4710DD9907, new InputArgument[3]
		{
			entity,
			GetCurrentInterior(),
			Function.Call<int>(Hash._0x47C2A06D4F5F424B, new InputArgument[1] { entity })
		});
	}

	public static int GetCurrentInterior()
	{
		return Function.Call<int>(Hash._0xB0F7F8663821D9C3, new InputArgument[3]
		{
			Game.Player.Character.Position.X,
			Game.Player.Character.Position.Y,
			Game.Player.Character.Position.Z
		});
	}

	public static void DoRandomScenario(this Ped ped)
	{
		List<string> list = new List<string>
		{
			"WORLD_HUMAN_AA_COFFEE", "WORLD_HUMAN_AA_SMOKE", "WORLD_HUMAN_CLIPBOARD", "WORLD_HUMAN_DRINKING", "WORLD_HUMAN_JOG_STANDING", "WORLD_HUMAN_MUSCLE_FLEX", "WORLD_HUMAN_MUSCLE_FREE_WEIGHTS", "WORLD_HUMAN_MUSICIAN", "WORLD_HUMAN_PARTYING", "WORLD_HUMAN_PUSH_UPS",
			"WORLD_HUMAN_SIT_UPS", "WORLD_HUMAN_SMOKING", "WORLD_HUMAN_SMOKING_POT", "WORLD_HUMAN_STAND_MOBILE", "WORLD_HUMAN_YOGA", "WORLD_HUMAN_WINDOW_SHOP_BROWSE", "WORLD_HUMAN_TOURIST_MAP", "WORLD_HUMAN_TOURIST_MOBILE"
		};
		Function.Call(Hash._0x142A02425FF02BD9, new InputArgument[4]
		{
			ped,
			list[rand.Next(0, list.Count)],
			0,
			false
		});
	}

	public static bool IsInList(this Ped ped, List<Ped> list)
	{
		foreach (Ped item in list)
		{
			if (item.Handle == ped.Handle)
			{
				return true;
			}
		}
		return false;
	}

	public static void GiveWeaponIfChance(this Ped ped, int chance)
	{
		int num = rand.Next(0, 101);
		if (chance <= num)
		{
			List<WeaponHash> list = new List<WeaponHash>
			{
				WeaponHash.Pistol,
				WeaponHash.StunGun,
				WeaponHash.Knife,
				WeaponHash.PumpShotgun,
				WeaponHash.Bat,
				WeaponHash.Revolver
			};
			ped.Weapons.Give(list[rand.Next(0, list.Count)], 100, equipNow: true, isAmmoLoaded: true);
		}
	}

	public static void PlayAmbientSpeech(this Ped ped, string speechFile, bool immediately = false, string[] queue = null)
	{
		string text = speechFile;
		if (immediately)
		{
			Function.Call(Hash._0xB8BEC0CA6F0EDB0F, new InputArgument[1] { ped });
		}
		if (queue != null && queue.Length != 0 && !Function.Call<bool>(Hash._0x49B99BF3FDA89A7A, new InputArgument[3] { ped, text, 0 }))
		{
			for (int i = 0; i < queue.Length; i++)
			{
				if (Function.Call<bool>(Hash._0x49B99BF3FDA89A7A, new InputArgument[3]
				{
					ped,
					queue[i],
					0
				}))
				{
					text = queue[i];
					break;
				}
			}
		}
		Function.Call(Hash._0xB9EFD5C25018725A, new InputArgument[2] { "IsDirectorModeActive", 1 });
		Function.Call(Hash._0x8E04FEDD28D42462, new InputArgument[3] { ped, text, "SPEECH_PARAMS_FORCE" });
		Function.Call(Hash._0xB9EFD5C25018725A, new InputArgument[2] { "IsDirectorModeActive", 0 });
	}

	public static bool IsPlayingAnim(this Ped ped, string animDict, string animFile)
	{
		return Function.Call<bool>(Hash._0x1F0B79228E461EC9, new InputArgument[4] { ped, animDict, animFile, 3 });
	}

	public static void TaskPlayAnim(this Ped ped, string animDict, string animFile, int animFlag, int duration)
	{
		Function.Call(Hash._0xD3BD40951412FEF6, new InputArgument[1] { animDict });
		DateTime dateTime = DateTime.Now + TimeSpan.FromMilliseconds(1000.0);
		while (!Function.Call<bool>(Hash._0xD031A9162D01088C, new InputArgument[1] { animDict }))
		{
			Script.Yield();
			if (DateTime.Now >= dateTime)
			{
				return;
			}
		}
		Function.Call(Hash._0xEA47FE3719165B94, new InputArgument[11]
		{
			ped, animDict, animFile, 8f, -4f, duration, animFlag, 0f, false, false,
			false
		});
	}
}
