using Godot;
using System;
using System.IO;

public partial class Door : Sprite2D  
{
    // The room that this door leads to.
    //  The name of the file without file extension
    public string TargetRoom { get; set; }

    public override void _Input(InputEvent @event)
    {
        Player player = ((Room) GetParent()).Player;

		// If "e" is pressed and the player is within interaction distance of the hard door.
		Area2D interactArea = (Area2D) FindChild("Area2D");
		if (@event.IsActionPressed("ui_interact") && interactArea.OverlapsBody(player)) {
            // Emit a signal so the scene and player can respond appropriately
            EmitSignal(Player.SignalName.EnteredDoor, Name, TargetRoom);   
		}
    }
}