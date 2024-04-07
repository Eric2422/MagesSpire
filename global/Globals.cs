using Godot;
using System.Collections.Generic;

public partial class Globals : Node
{
    // The difficulty that the player is playing on
    public DifficultyMode Difficulty { get; set; }

    public bool KeyObtained;

    public Dictionary<StringName, KeyState> Keys;

    public override void _Ready()
    {
        base._Ready();

        Keys = new Dictionary<StringName, KeyState>();
        Keys.Add("LibraryKey", KeyState.Unobtained);
        Keys.Add("TorchRoomKey", KeyState.Unobtained);

        Difficulty = DifficultyMode.Easy;
        KeyObtained = false;
    }
}