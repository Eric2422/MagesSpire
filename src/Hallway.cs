using Godot;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public partial class Hallway : Room
{
	// Stores the keys that the player has to find
	private Dictionary<string, bool> _keysUsed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		Player = (Player) FindChild("Player");

		// Both keys are not used yet, so set them to false
		_keysUsed = new Dictionary<string, bool>();
		_keysUsed.Add("key1", false);
		_keysUsed.Add("key2", false);

		// Scenes that the player can enter from.
		string[] enteringScenes = {"Entrance", "Library", "TorchRoom", "TargetRoom"};
		// Add each into EntrancePositions
		foreach (string scene in enteringScenes)
		{
			Door door = GetNode<Door>($"{scene}Door");
			EntrancePositions.Add(scene, door.Position);
		}
	}

	public override void _Input(InputEvent @event)
	{
		
	}
}
