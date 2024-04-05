using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class Hallway : Room
{
	// Stores the keys that the player has to find
	private Dictionary<string, bool> _keysUsed;

	private Door _entranceDoor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		// Both keys are not used yet, so set them to false
		_keysUsed = new Dictionary<string, bool>();
		_keysUsed.Add("key1", false);
		_keysUsed.Add("key2", false);

		_entranceDoor = GetNode<Door>("EntranceDoor");

		_exitDoors.Add(_entranceDoor, "res://entrance/entrance.tscn");
		_exitDoors.Add(GetNode<Door>("LibraryDoor"), "res://library/library.tscn");
		_exitDoors.Add(GetNode<Door>("TorchRoomDoor"), "res://torch_room/torch_room.tscn");
		_exitDoors.Add(GetNode<Door>("TargetRoomDoor"), "res://target_room/target_room.tscn");
	}
	
	/// <summary>
	/// Called when the player interacts with a door.
	/// </summary>
	/// <param name="door">The door that the player interacts with</param>
	protected override void OnEnteredDoor(Door door) {
		// If the door being accessed is the EntranceDoor, do nothing.
		// The player is not supposed to be able to go back. 
		if (door.Equals(_entranceDoor)) {
			return;
		}

		base.OnEnteredDoor(door);
	}
}
