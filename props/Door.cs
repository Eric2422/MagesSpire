using Godot;

public partial class Door : Interactable
{
	// The room that this door leads to.
	//  The name of the file without file extension
	public string TargetRoom { get; set; }

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionJustPressed("ui_interact") && _playerInInteractArea)
		{   
			_player.EmitSignal(Player.SignalName.EnteredDoor, Name, TargetRoom);
		}
	}
}
