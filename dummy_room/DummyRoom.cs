using Godot;

public partial class DummyRoom : Room
{
    public override void _Ready()
    {
        base._Ready();

        _textBox.Text = "This is currently the end";
    }
}