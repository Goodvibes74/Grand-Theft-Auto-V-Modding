using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CruelMastersOnlineOffline;

public class Door
{
	public enum EDoorState
	{
		Unlocked,
		Locked,
		ForceLockedUntilOutOfArea,
		ForceUnlockedThisFrame,
		ForceLockedThisFrame,
		ForceOpenThisFrame,
		ForceClosedThisFrame
	}

	private uint _doorHash;

	private Vector3 _position;

	private float _heading;

	private bool _locked;

	public uint DoorHash
	{
		get
		{
			return _doorHash;
		}
		set
		{
			_doorHash = value;
		}
	}

	public Vector3 Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public bool Exists => DoorHash != 0;

	public bool IsPhysicsLoaded => Function.Call<bool>(Hash.DOOR_SYSTEM_GET_IS_PHYSICS_LOADED, _doorHash);

	public float OpenRatio
	{
		get
		{
			return Function.Call<float>(Hash.DOOR_SYSTEM_GET_OPEN_RATIO, _doorHash);
		}
		set
		{
			Function.Call(Hash.DOOR_SYSTEM_SET_OPEN_RATIO, _doorHash, value, true, true);
		}
	}

	public float AutomaticDistance
	{
		set
		{
			Function.Call(Hash.DOOR_SYSTEM_SET_AUTOMATIC_DISTANCE, _doorHash, value, true, true);
		}
	}

	public float AutomaticRate
	{
		set
		{
			Function.Call(Hash.DOOR_SYSTEM_SET_AUTOMATIC_RATE, _doorHash, value, true, true);
		}
	}

	public bool IsClosed => Function.Call<bool>(Hash.IS_DOOR_CLOSED, _doorHash);

	public bool IsLocked
	{
		get
		{
			OutputArgument outputArgument = new OutputArgument();
			OutputArgument outputArgument2 = new OutputArgument();
			Function.Call(Hash.GET_STATE_OF_CLOSEST_DOOR_OF_TYPE, _doorHash, _position.X, _position.Y, _position.Z, outputArgument, outputArgument2);
			return outputArgument.GetResult<bool>();
		}
		set
		{
			Function.Call(Hash.SET_STATE_OF_CLOSEST_DOOR_OF_TYPE, _doorHash, _position.X, _position.Y, _position.Z, value, _heading, false);
			_locked = value;
		}
	}

	public float Heading
	{
		get
		{
			OutputArgument outputArgument = new OutputArgument();
			OutputArgument outputArgument2 = new OutputArgument();
			Function.Call(Hash.GET_STATE_OF_CLOSEST_DOOR_OF_TYPE, _doorHash, _position.X, _position.Y, _position.Z, outputArgument, outputArgument2);
			return outputArgument2.GetResult<float>();
		}
		set
		{
			Function.Call(Hash.SET_STATE_OF_CLOSEST_DOOR_OF_TYPE, _doorHash, _position.X, _position.Y, _position.Z, _locked, value, false);
			_heading = value;
		}
	}

	public EDoorState PendingState => (EDoorState)Function.Call<int>(Hash.DOOR_SYSTEM_GET_DOOR_PENDING_STATE, _doorHash);

	public EDoorState State
	{
		get
		{
			return (EDoorState)Function.Call<int>(Hash.DOOR_SYSTEM_GET_DOOR_STATE, _doorHash);
		}
		set
		{
			Function.Call(Hash.DOOR_SYSTEM_SET_DOOR_STATE, _doorHash, (int)value, true, true);
		}
	}

	public bool IsInMemory => Function.Call<bool>(Hash.IS_DOOR_REGISTERED_WITH_SYSTEM, _doorHash);

	public Door(uint doorHash, Vector3 position)
	{
		_doorHash = doorHash;
		_position = position;
	}

	public Door(Prop doorEntity)
	{
		InitializeFromEntity(doorEntity);
	}

	public Door(Vector3 position)
	{
		Prop prop = (from o in World.GetAllProps()
			where o.Model.ToString().ToLower().Contains("door")
			orderby o.Position.DistanceTo(position)
			select o).FirstOrDefault();
		if (prop != null)
		{
			InitializeFromEntity(prop);
			return;
		}
		Notification.Show($"Couldn't initialize the door for position {position}");
		DoorHash = 0u;
	}

	public void InitializeFromEntity(Prop doorEntity)
	{
		_doorHash = (uint)doorEntity.Model.Hash;
		_position = doorEntity.Position;
	}
}
