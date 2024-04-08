using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public partial class Hallway : Room
{
	private Door _entranceDoor;

	// The locked door(i.e. TargetRoom)
	private Door _lockedDoor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		_entranceDoor = GetNode<Door>("EntranceDoor");
		_lockedDoor = GetNode<Door>("TargetRoomDoor");

		_exitDoors.Add(_entranceDoor, "res://entrance/entrance.tscn");
		_exitDoors.Add(GetNode<Door>("LibraryDoor"), "res://library/library.tscn");
		_exitDoors.Add(GetNode<Door>("ChestRoomDoor"), "res://chest_room/chest_room.tscn");
		_exitDoors.Add(_lockedDoor, "res://target_room/target_room.tscn");

		_textBox = GetNode<TextBox>("TextBox");
	}

	/// <summary>
	/// Called when the player interacts with a door.
	/// </summary>
	/// <param name="door">The door that the player interacts with</param>
	protected override void OnEnteredDoor(Door door)
	{
		switch (door)
		{
			// Prevent the player from going back to Entrance
			case var _ when door.Equals(_entranceDoor):
				// Print a message to the TextBox
				_textBox.Text = "The door back to the entrance is blocked.";
				return;

			case var _ when door.Equals(_lockedDoor):
				InteractWithLockedDoor();
				break;

			default:
				base.OnEnteredDoor(door);
				break;
		}
	}


	/// <summary>
	/// Called when the player tries to interact with the 
	/// </summary>
	private void InteractWithLockedDoor()
	{
		// Get the player
		Player player = GetChild<Player>(GetChildCount() - 1);

		switch (_globals.Difficulty)
		{
			case DifficultyMode.Easy:
				// If the player has not obtained the library key yet
				if (_globals.Keys["LibraryKey"] == KeyState.Unobtained && !player.Inventory.Contains("LibraryKey"))
				{
					_textBox.Text = "The door is locked. Search for a key.";
				}

				// If the player has obtained the key but hasn't used it
				else if (_globals.Keys["LibraryKey"] == KeyState.Obtained && player.Inventory.Contains("LibraryKey"))
				{
					_textBox.Text = "You insert the key and unlock the door.";
					player.Inventory.Remove("LibraryKey");
					_globals.Keys["LibraryKey"] = KeyState.Used;
				}

				// If the player has used the key
				else if (_globals.Keys["LibraryKey"] == KeyState.Used && !player.Inventory.Contains("LibraryKey"))
				{
					base.OnEnteredDoor(_lockedDoor);
				}

				break;

			case DifficultyMode.Hard:
				bool bothKeysUnused = _globals.Keys["LibraryKey"] != KeyState.Used && _globals.Keys["ChestRoomKey"] != KeyState.Used;
				bool bothKeysInInventory = player.Inventory.Contains("LibraryKey") && player.Inventory.Contains("ChestRoomKey");

				// If the player is missing at least one key
				if (bothKeysUnused && !bothKeysInInventory)
				{
					_textBox.Text = "The door is locked. Find two keys.";
				}

				// If the player has both keys
				else if (bothKeysUnused && bothKeysInInventory)
				{
					_textBox.Text = "You insert both keys and unlock the door.";
					player.Inventory.Remove("LibraryKey");
					_globals.Keys["LibraryKey"] = KeyState.Used;
                    player.Inventory.Remove("ChestRoomKey");
					_globals.Keys["ChestRoomKey"] = KeyState.Used;
				}

				// The player already unlocked the door
				else
				{
					base.OnEnteredDoor(_lockedDoor);
				}

				break;
		}
	}
}
