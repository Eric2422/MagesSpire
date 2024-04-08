using Godot;

public partial class Chest : Interactable
{
	public override void _Ready()
	{
		base._Ready();

		_emittedSignal = SignalsManager.SignalName.OpenedChest;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
	}
}
