using Godot;
using System.Collections.Generic;

public partial class Scene : Node2D
{
    // Stores the position that the player will be in if they come from the given scene. 
    public Dictionary<string, Vector2> entrancePositions;

    public override void _Ready()
    {
        entrancePositions = new Dictionary<string, Vector2>();
    }

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