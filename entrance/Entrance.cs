using Godot;

public partial class Entrance : Room
{
	private Door _easyDoor;
	private Door _hardDoor;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		base._Ready();

		Player = (Player) GetNode<CharacterBody2D>("Player");

		_easyDoor = GetNode<Door>("EasyDoor");
 		_easyDoor.TargetRoom = "hallway";
		GD.Print($"EasyDoor: {_easyDoor}");

		_hardDoor = GetNode<Door>("HardDoor");
		_hardDoor.TargetRoom = "hallway";
		GD.Print($"HardDoor: {_hardDoor}");
	}
}
