using Godot;
using System.Collections.Generic;

public partial class Hallway : Scene
{
	private Dictionary<string, bool> keysUsed = new Dictionary<string, bool>();

	private CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (CharacterBody2D)FindChild("Player");

		keysUsed.Add("key1", false);
		keysUsed.Add("key2", false);
	}
}
