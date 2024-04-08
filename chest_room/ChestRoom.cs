using Godot;
public partial class ChestRoom : Room {
	private Chest _chest;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		_exitDoors.Add(GetNode<Door>("HallwayDoor"), "res://hallway/hallway.tscn");

		_chest = GetNode<Chest>("Chest");
        _signalsManager.OpenedChest += OnOpenedChest;
	}

    protected override void OnEnteredDoor(Door door) {
        // Remove the listener for OpenedChest
        _signalsManager.OpenedChest -= OnOpenedChest;

        base.OnEnteredDoor(door);
    }

    /// <summary>
    /// Handles the player opening the chest
    /// </summary>
    private void OnOpenedChest() {
        if (_globals.TimesOpenedChest == 0) {
            _textBox.Text = @"There is a note in the chest: ""Were you not concerned about this being a mimic?
Who knows, maybe if you come back later, this chest will be replaced by a mimic.""";
        }

        else if (_globals.TimesOpenedChest == 1)
        {
            _textBox.Text = "Somehow there is a key in the chest that you didn't see earlier.";
            _globals.Keys["ChestRoomKey"] = KeyState.Obtained;
            GetPlayer().Inventory.Add("ChestRoomKey");
        }

        else if (_globals.TimesOpenedChest >= 2 && _globals.TimesOpenedChest < 10)
        {
            _textBox.Text = $"There is a note in the chest: \"You've already checked this chest {_globals.TimesOpenedChest} times already. There's nothing left in this chest.\"";
        }

        else 
        {
            _textBox.Text = "There is a note in the chest: \"I have to commend you for your perseverance.\"";
        }
        
        _globals.TimesOpenedChest++;
    }
}   
