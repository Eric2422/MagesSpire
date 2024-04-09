using Godot;

public partial class RecursionRoom : Room 
{
	private Door _hallwayDoor;
	// The door that leads the player back over and over
	private Door _recursionDoor;

	public override void _Ready()
	{
		base._Ready();
		
		_hallwayDoor = GetNode<Door>("HallwayDoor");
		_recursionDoor = GetNode<Door>("DummyRoomDoor");
		
		_exitDoors.Add(_hallwayDoor, "res://hallway/hallway.tscn");
		_exitDoors.Add(_recursionDoor, "res://dummy_room/dummy_room.tscn");
	}

	protected override void OnEnteredDoor(Door door)
	{
		if (door.Equals(_recursionDoor) && !_globals.ReturnedInRecursionRoom)
		{
			if (_globals.TimesThroughRecursionRoom > 0 && _globals.Difficulty == DifficultyMode.Easy)
			{
				_textBox.Text = "The room seems rather familiar. Perhaps you should try something else.";
			}

			GetPlayer().Position = _hallwayDoor.Position;
			_globals.TimesThroughRecursionRoom++;
			return;
		}

		else if (door.Equals(_hallwayDoor))
		{
			_globals.ReturnedInRecursionRoom = true;
		}

		base.OnEnteredDoor(door);
	}
}
