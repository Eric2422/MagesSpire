using Godot;

public partial class Door : Interactable
{
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionJustPressed("ui_interact") && _playerInInteractArea)
		{   
			_signalsManager.EmitSignal(SignalsManager.SignalName.EnteredDoor, this);
		}
	}
}
