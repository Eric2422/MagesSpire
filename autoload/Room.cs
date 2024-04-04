using Godot;
using System.Collections.Generic;

public partial class Room : Node
{
	public Player Player { get; set; }

	/// <summary>
	/// Called every frame.
	/// </summary>
	/// <param name="delta">The elapsed time since the previous frame.</param>
	public override void _Process(double delta)
	{
		// If player hits the escape key, quit the game
		if (Input.IsActionPressed("ui_cancel"))
		{
			GetTree().Quit();
		}
	}
}
