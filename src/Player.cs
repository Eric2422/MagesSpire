using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -400.0f;
	
	// Get the gravity from the project setqtings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	public AnimatedSprite2D _playerSprite;

	public override void _Ready()
	{
		_playerSprite = GetNode<AnimatedSprite2D>("PlayerSprite");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float) delta;
		}

		// Handle Jump
		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction
		float direction = Input.GetAxis("ui_left", "ui_right");
		
		// Accelerate the player
		if (direction != 0)
		{
			velocity.X = Mathf.MoveToward(Velocity.X, direction * Speed, 8);
			
			// Reflect the sprite to face the direction player is moving
			_playerSprite.FlipH = direction != 1.0f;
		}
		// Deccelerate the player
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, 8);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
