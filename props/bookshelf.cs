using Godot;

public partial class Bookshelf : Interactable {
    public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionPressed("ui_interact") && _playerInInteractArea)
		{   
			_player.EmitSignal(Player.SignalName.InteractedWithBookshelf, Name);
		}
	}
}