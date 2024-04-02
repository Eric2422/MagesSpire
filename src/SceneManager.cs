using Godot;
using System.Collections.Generic;

public partial class SceneManager : Node
{
	/// <summary>
	/// Changes the scene from the current scene to the next scene.
	/// Transfers the player from this scene to the next.
	/// </summary>
	/// <param name="nextScene">The next scene to be loaded.</param>
	/// <param name="player">The player Node that is being used in the current scene.</param>
	public static void ChangeScene(string nextScene, CharacterBody2D player)
	{
		// Store the player's current scene.
		Node currentScene = player.GetParent();
		currentScene.RemoveChild(player);

		// Load the next scene.
		Scene newScene = (Scene) ResourceLoader.Load<PackedScene>(nextScene).Instantiate();

		newScene.AddChild(player);
		currentScene.GetTree().Root.AddChild(newScene);

		// Reposition the player to the appropriate door.
		Vector2 position = newScene.EntrancePositions[currentScene.Name];
		player.Position = position;

		// Remove the old scene.
		currentScene.QueueFree();
	}
}
