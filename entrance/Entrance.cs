using System.Diagnostics.CodeAnalysis;
using Godot;
using Godot.NativeInterop;

public partial class Entrance : Room
{	
	private Door _easyDoor;
	private Door _hardDoor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		base._Ready();

		Player = (Player) GetNode<CharacterBody2D>("Player");

		Door _easyDoor = GetNode<Door>("EasyDoor");
		Door _hardDoor = GetNode<Door>("HardDoor");
		_exitDoors.Add(_easyDoor, "res://hallway/hallway.tscn");
		_exitDoors.Add(_hardDoor, "res://hallway/hallway.tscn");
	}

	/// <summary>
	/// Called when the player interacts with a door.
	/// Transports the user to another scene. 
	/// </summary>
	/// <param name="door">The door that the player interacted with</param>
	protected override void OnEnteredDoor(Door door) {	
		switch (door) {
			case var _ when door.Equals(_easyDoor):
				Player.Difficulty = DifficultyMode.Easy;
				break;
			
			case var _ when door.Equals(_hardDoor):
				Player.Difficulty = DifficultyMode.Hard;
				break;
		}

		base.OnEnteredDoor(door);
	}
}
