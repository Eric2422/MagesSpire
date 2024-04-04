using Godot;

public partial class Signals : Node {
    // Responds to the player going through a door. 
    [Signal]
    public delegate void EnteredDoorEventHandler(string doorName, string roomName);

    [Signal]
    public delegate void InteractedWithBookshelfEventHandler(string bookshelfName);
}