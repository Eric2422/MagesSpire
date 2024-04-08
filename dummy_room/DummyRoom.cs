using Godot;

public partial class DummyRoom : Room
{
	public override void _Ready()
	{
		base._Ready();

		_exitDoors.Add(GetNode<Door>("RecursionRoomDoor"), "res://recursion_room/recursion_room.tscn");

		_textBox.Text = "This is currently the end";
	}
}
