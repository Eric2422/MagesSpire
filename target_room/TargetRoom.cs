using Godot;

public partial class TargetRoom : Room {
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		_exitDoors.Add(GetNode<Door>("HallwayDoor"), "res://hallway/hallway.tscn");
	}
}
