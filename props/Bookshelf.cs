using Godot;

public partial class Bookshelf : Interactable {
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		
		GD.Print("You hit an input!");

		if (Input.IsActionPressed("ui_interact") && _playerInInteractArea)
		{   
			GD.Print("Player interacted with bookshelf");
			_player.EmitSignal(SignalsManager.SignalName.InteractedWithBookshelf, Name);
		}
	}
}
