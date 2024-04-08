using Godot;

public partial class Interactable : Node2D {
	protected static SignalsManager SignalsManager;

	// The name of the signal that the Interactable emits
	protected StringName _emittedSignal = null;

	protected Area2D _interactArea;

	protected Player _player;

	public override void _Ready()
	{
		base._Ready();

		SignalsManager = GetNode<SignalsManager>("/root/SignalsManager");

		_interactArea = GetNode<Area2D>("Area2D");
		_player = GetParent().GetNode<Player>("Player");
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionJustPressed("ui_interact") && _interactArea.GetOverlappingBodies().Contains(_player))
		{
			SignalsManager.EmitSignal(_emittedSignal, this);
		}
	}
}
