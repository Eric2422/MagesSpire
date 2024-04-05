using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Godot;

public partial class Library : Room {
	private Door _hallwayDoor;

	private Bookshelf[] _bookshelves;

	private bool _keyObtained;

	public override void _Ready()
	{
		base._Ready();

		_hallwayDoor = GetNode<Door>("HallwayDoor");
		_exitDoors.Add(_hallwayDoor, "res://hallway/hallway.tscn");

		_keyObtained = false;

		_bookshelves = new Bookshelf[3];
		for (int i=1; i<=3; i++) {
			_bookshelves[i-1] = GetNode<Bookshelf>($"Bookshelf{i}");
		}        
	}

	/// <summary>
	/// Transport the player back when they use the HallwayDoor
	/// </summary>
	/// <param name="door">The door that the player interacts with.
	///                    The only door in this room is the HallwayDoor
	///                    </param>
	protected override void OnEnteredDoor(Door door) {
		base.OnEnteredDoor(door);

		// Disconnect the bookshelf event listener
		_signalsManager.InteractedWithBookshelf -= OnInteractedWithBookshelf;
	}

	/// <summary>
	/// Respond to the player interacting with a bookshelf.
	/// If it is "Bookshelf3", add a key to their inventory.
	/// </summary>
	/// <param name="bookshelfName">The name of the bookshelf that the player interacted with</param>
	protected override void OnInteractedWithBookshelf(Bookshelf bookshelf)
	{
		// Get the player
		Player player = GetChild<Player>(GetChildCount() - 1);

		GD.Print($"Bookshelf: {bookshelf.Name}");

		// If the player interacts with the third bookshelf
		if (bookshelf.Equals(_bookshelves[2]))
		{
			// Add the key to the player's inventory
			player.Inventory.Add("LibraryKey"); 
			GD.Print($"Player inventory: {String.Join(", ", player.Inventory)}"); 
			GD.Print("Key obtained");

			// Create a textbox
			Node textBox =  GD.Load<PackedScene>("res://textbox.tscn").Instantiate();

			// Print a message to the textbox
			Label label = (Label) textBox.FindChild("Textbox");
			label.Text = "You found a key in the bookshelf.";
			AddChild(textBox);

			GD.Print("All children of Library scene:");
			for (int i=0; i<GetChildCount(); i++) {
				GD.Print(GetChild(i));
			}
		}
	}
}
