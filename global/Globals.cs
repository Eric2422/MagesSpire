using Godot;
using System.Collections.Generic;

public partial class Globals : Node
{
    // The difficulty that the player is playing on
    public DifficultyMode Difficulty { get; set; }

    public Dictionary<StringName, KeyState> Keys;

    // How many times the player opened the chest in ChestRoom
    public int TimesOpenedChest;

    public override void _Ready()
    {
        base._Ready();
        Difficulty = DifficultyMode.Easy;

        Keys = new Dictionary<StringName, KeyState>();
        Keys.Add("LibraryKey", KeyState.Unobtained);
        Keys.Add("ChestRoomKey", KeyState.Unobtained);

        TimesOpenedChest = 0;
    }
}