using Godot;

public partial class Door : Interactable
{
	// The room that this door leads to
	[Export]
	public string targetRoom;

	public override void _Ready()
	{
		base._Ready();

		_emittedSignal = SignalsManager.SignalName.EnteredDoor;
	}
}
