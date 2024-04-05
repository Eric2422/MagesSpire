using Godot;

public partial class Door : Interactable
{
	public override void _Ready()
	{
		base._Ready();

		_emittedSignal = SignalsManager.SignalName.EnteredDoor;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
	}
}
