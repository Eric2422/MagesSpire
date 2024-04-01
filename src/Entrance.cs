using Godot;
using System;

public partial class Entrance : Node2D
{	
	private CharacterBody2D _player;
	private Sprite2D _door;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		_player = GetNode<CharacterBody2D>("Player");
		_door = GetNode<Sprite2D>("Door");
	}

	public override void _Input(InputEvent @event)
	{
		// If player hits the escape key, quit the game
		if (@event.IsActionPressed("ui_cancel"))
		{
			GetTree().Quit();
		}
		
		// If "e" is pressed and the player is within interaction distance of the door
		Area2D child = (Area2D) _door.FindChild("Area2D");
		if (@event.IsActionPressed("ui_interact") && child.OverlapsBody(_player)) {
			SceneManager.changeScene("./scenes/hallway.tscn", _player);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
