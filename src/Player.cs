using System;
using System.Runtime.InteropServices;
using Godot;

public partial class Player : CharacterBody2D
{
	// Get the gravity from the project setqtings to be synced with RigidBody nodes.
	public float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	// The difficulty that the player is playing on
	public DifficultyMode Difficulty { get; set; }

	// Responds to the player going through a door. 
	[Signal]
	public delegate void EnteredDoorEventHandler(string doorName, string roomName);

	private const float Speed = 160.0f;
	private const float JumpVelocity = -400.0f;

	private AnimatedSprite2D playerSprite;

	public override void _Ready()
	{
		playerSprite = GetNode<AnimatedSprite2D>("PlayerSprite");

		EnteredDoor += HandleEnteredDoor;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction
		float direction = Input.GetAxis("ui_left", "ui_right");

		// If either left or right are pressed, accelerate the player.
		if (direction != 0)
		{
			velocity.X = Mathf.MoveToward(Velocity.X, direction * Speed, 8);

			// Reflect the sprite to face the direction player is moving.
			playerSprite.FlipH = direction != 1.0f;
		}
		// Else, deccelerate the player.
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, 8);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	// Respond to the player entering a door
	public void HandleEnteredDoor(string doorName, string roomName) {
		// Change the scene.
		SceneManager.ChangeScene(roomName, this);
		
		// Handle special door names
		switch (doorName) 
		{
			case "EasyDoor":
				Difficulty = DifficultyMode.Easy;
				break;
			
			case "HardDoor":
				Difficulty = DifficultyMode.Hard;
				break;
		}
	}
}