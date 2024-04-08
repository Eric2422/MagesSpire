using Godot;

public partial class RecursionRoom : Room 
{
	public override void _Ready()
	{
		base._Ready();

		_exitDoors.Add(GetNode<Door>("HallwayDoor"), "res://hallway/hallway.tscn");
		_exitDoors.Add(GetNode<Door>("DummyRoomDoor"), "");
	}
}
