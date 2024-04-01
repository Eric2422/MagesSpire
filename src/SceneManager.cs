using Godot;

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
		// Save the player's old scene.
		Node oldScene = player.GetParent();
		oldScene.RemoveChild(player);

		// Load the next scene.
		Node newScene = ResourceLoader.Load<PackedScene>(nextScene).Instantiate();

		newScene.AddChild(player);
		oldScene.GetTree().Root.AddChild(newScene);

		// Remove the old scene.
		oldScene.QueueFree();
	}
}
