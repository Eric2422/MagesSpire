using Godot;

public partial class Bookshelf : Interactable 
{
	public override void _Ready()
	{
		base._Ready();

		_emittedSignal = SignalsManager.SignalName.InteractedWithBookshelf;

		// Prevent misfires during instantiation
		_playerInInteractArea = false;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
	}
}
