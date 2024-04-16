using System;
using Godot;

public partial class TextBox : CanvasLayer
{
	// The Label Node that contains the text
	private Label _label;

	private MarginContainer _textBoxContainer;

	[Export]
	public String Text {
		get { return _label.Text; }
		set {
			_label.Text = value;
			Visible = !value.Equals("");
		}
	}

	public override void _Ready()
	{
		base._Ready();

		_label = (Label) FindChild("Label");
		
		// Hide the TextBox by default since it's automatically empty. 
		Visible = false;
	}
}
