using Godot;
using System;

public partial class SceneManager : Node
{
	public static void changeScene(string nextScene, CharacterBody2D player) {
		// Save the player's old scene
		Node oldScene = player.GetParent();
		oldScene.RemoveChild(player);

		// Load the next scene
		Node newScene = ResourceLoader.Load<PackedScene>(nextScene).Instantiate();
		
		newScene.AddChild(player);
		oldScene.GetTree().Root.AddChild(newScene);
		
		// Remove the old scene
		oldScene.QueueFree();
	}
}
