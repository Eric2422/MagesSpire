using System;
using Godot;

public partial class Door : Node2D
{
	// The room that this door leads to.
	//  The name of the file without file extension
	public string TargetRoom { get; set; }

	private Area2D _interactArea;

	private Player _player;

	private bool _playerInInteractArea;

	public override void _Ready()
	{
		base._Ready();

		_interactArea = GetNode<Area2D>("Area2D");
		_player = ((Room) GetParent()).GetNode<Player>("Player");

		_playerInInteractArea = false;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (Input.IsActionPressed("ui_interact") && _playerInInteractArea)
		{   
			_player.EmitSignal(Player.SignalName.EnteredDoor, Name, TargetRoom);
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
