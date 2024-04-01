using Godot;
using System;
using System.Collections.Generic;

public partial class Hallway : Node
{
    private Dictionary<string, bool> _keysUsed = new Dictionary<string, bool>();

    private CharacterBody2D _player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _player = (CharacterBody2D)FindChild("Player");

        _keysUsed.Add("key1", false);
        _keysUsed.Add("key2", false);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
