using Godot;
using System.Collections.Generic;

public partial class Scene : Node2D
{
    // 
    protected Dictionary<Scene, Vector2> Entrances = new Dictionary<Scene, Vector2>();

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