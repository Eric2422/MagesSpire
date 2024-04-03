using Godot;
using System.Collections.Generic;

public partial class Hallway : Room
{
	// Stores the keys that the player has to find
	private Dictionary<string, bool> _keysUsed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		Player = (Player)FindChild("Player");

		// Both keys are not used yet, so set them to false
		_keysUsed = new Dictionary<string, bool>();
		_keysUsed.Add("key1", false);
		_keysUsed.Add("key2", false);

		// Rooms that the player can enter from.
		string[] enteringRooms = { "Entrance", "Library", "TorchRoom", "TargetRoom" };
		// Add each into EntrancePositions
		foreach (string room in enteringRooms)
		{
			// Assign all the doors to the rooms they lead to 
			Door door = GetNode<Door>($"{room}Door");
			door.TargetRoom = room.ToLower();
		}
	}
}
