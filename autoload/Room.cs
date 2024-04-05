using Godot;
using System.Collections.Generic;

public partial class Room : Node
{
	protected SignalsManager _signalsManager;
	protected ScenesManager _scenesManager;

	public Player Player { get; set; }

	// Stores the Room's doors and the filepath of the scenes they lead to
	protected Dictionary<Door, string> _exitDoors;
	
    public override void _Ready()
    {
        base._Ready();

		_signalsManager = GetNode<SignalsManager>("/root/SignalsManager");
		_scenesManager = GetNode<ScenesManager>("/root/ScenesManager");

		_signalsManager.EnteredDoor += OnEnteredDoor;

		_exitDoors = new Dictionary<Door, string>();
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

	/// <summary>
	/// An empty method to be overrided. Called when the player interacts with a door. 
	/// </summary>
	/// <param name="door"></param>
	protected virtual void OnEnteredDoor(Door door) {
	}
}
