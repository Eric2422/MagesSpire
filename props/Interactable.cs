using Godot;

public partial class Interactable : Node2D {
	protected static SignalsManager SignalsManager;

	// The name of the signal that the Interactable emits
	protected StringName _emittedSignal = null;

    protected Area2D _interactArea;

	protected Player _player;

	protected bool _playerInInteractArea;

	public override void _Ready()
	{
		base._Ready();

		SignalsManager = GetNode<SignalsManager>("/root/SignalsManager");

		_interactArea = GetNode<Area2D>("Area2D");
		_player = GetParent().GetNode<Player>("Player");

		_playerInInteractArea = false;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionJustPressed("ui_interact") && _playerInInteractArea)
		{
			SignalsManager.EmitSignal(_emittedSignal, this);
		}
	}

	private void OnArea2DBodyEntered(Node2D body)
	{
		if (body == null) { 
			return; 
		}

		_playerInInteractArea = true;
	}

	private void OnArea2DBodyExited(Node2D body) {
		if (body == null) { 
			return; 
		}

		_playerInInteractArea = false;
	}
}