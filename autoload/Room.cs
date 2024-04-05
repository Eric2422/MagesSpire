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
		_signalsManager.InteractedWithBookshelf += OnInteractedWithBookshelf;

		_exitDoors = new Dictionary<Door, string>();
	}

	public override void _Input(InputEvent @event) {
		// If player hits the escape key, quit the game
		if (Input.IsActionPressed("ui_cancel"))
		{
			GetTree().Quit();
		}
	}

	/// <summary>
	/// A method to be overrided. Called when the player interacts with a door.
	/// Disconnects this Room's EnteredDoorEventHandler and changes the scene.
	/// </summary>
	/// <param name="door"></param>
	protected virtual void OnEnteredDoor(Door door) {
		// Disconnect the EnteredDoorEventHandler
		_signalsManager.EnteredDoor -= OnEnteredDoor;

		// Change the scene
		_scenesManager.ChangeScene(_exitDoors[door]);
	}

	/// <summary>
	/// Called when the player interacts with a bookshelf.
	/// Does nothing.
	/// </summary>
	protected virtual void OnInteractedWithBookshelf(Bookshelf bookshelf) {
	}
}
