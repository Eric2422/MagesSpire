using System;
using Godot;

public partial class TextBox : CanvasLayer
{
    // The text displayed by the TextBox
    private Label _label;

    public override void _Ready()
    {
        base._Ready();

        _label = (Label) FindChild("Label");
    }

    public void SetLabelText(String text)
    {
        _label.Text = text;
    }
}