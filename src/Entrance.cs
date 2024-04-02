using Godot;

public partial class Entrance : Scene
{
	private CharacterBody2D player;
	private Sprite2D door;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		base._Ready();

		player = GetNode<CharacterBody2D>("Player");
		door = GetNode<Sprite2D>("Door");

		// Add the places where the player will enter
		entrancePositions.Add("Hallway", door.Position);
	}

	public override void _Input(InputEvent @event)
	{		
		// If "e" is pressed and the player is within interaction distance of the door.
		Area2D child = (Area2D) door.FindChild("Area2D");
		if (@event.IsActionPressed("ui_interact") && child.OverlapsBody(player)) {
			SceneManager.ChangeScene("./scenes/hallway.tscn", player);
		}
	}
}
