using Godot;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public partial class Hallway : Scene
{
	// Stores the keys that the player has to find
	private Dictionary<string, bool> keysUsed;

	private CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		player = (CharacterBody2D) FindChild("Player");

		// Both keys are not used yet, so set them to false
		keysUsed = new Dictionary<string, bool>();
		keysUsed.Add("key1", false);
		keysUsed.Add("key2", false);

		// Scenes that the player can enter from.
		string[] enteringScenes = {"Entrance", "Library", "TorchRoom", "TargetRoom"};
		foreach (string scene in enteringScenes)
		{
			Sprite2D door = GetNode<Sprite2D>($"{scene}Door");
			entrancePositions.Add(scene, door.Position);
		}
	}
}
