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
		_easyDoor = (Door) GetNode<Sprite2D>("EasyDoor");
		_easyDoor.TargetRoom = "hallway";

		_hardDoor = (Door) GetNode<Sprite2D>("HardDoor");
		_hardDoor.TargetRoom = "hallway";
	}
}
