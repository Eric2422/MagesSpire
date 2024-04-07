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
		Globals globals = GetNode<Globals>("/root/Globals");
		switch (door) {
			case var _ when door.Equals(_easyDoor):
				globals.Difficulty = DifficultyMode.Easy;
				break;
			
			case var _ when door.Equals(_hardDoor):
				globals.Difficulty = DifficultyMode.Hard;
				break;
		}

		base.OnEnteredDoor(door);
	}
}
