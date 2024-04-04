using Godot;
using System;

public partial class SignalsManager : Node {
	// Responds to the player going through a door. 
	[Signal]
	public delegate void EnteredDoorEventHandler(Door door);

	[Signal]
	public delegate void InteractedWithBookshelfEventHandler(string bookshelfName);
}
