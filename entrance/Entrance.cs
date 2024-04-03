using Godot;

public partial class Entrance : Room
{
	private Door _easyDoor;
	private Door _hardDoor;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		base._Ready();

		Player = GetNode<Player>("Player");

		_easyDoor = GetNode<Door>("EasyDoor");
		_easyDoor.TargetRoom = "hallway";

		_hardDoor = GetNode<Door>("HardDoor");
		_hardDoor.TargetRoom = "hallway";
	}
}
