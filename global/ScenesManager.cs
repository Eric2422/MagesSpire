using Godot;
using System.Collections.Generic;

public partial class ScenesManager : Node
{
	public Node CurrentScene { get; set; }

	public HashSet<StringName> _availableScenes;

	public override void _Ready()
	{
		Viewport root = GetTree().Root;
		CurrentScene = root.GetChild(root.GetChildCount() - 1);

		_availableScenes = new()
        {
            "res://entrance/entrance.tscn",
            "res://hallway/hallway.tscn",
            "res://library/library.tscn",
            "res://chest_room/chest_room.tscn",
            "res://recursion_room/recursion_room.tscn",
            "res://dummy_room/dummy_room.tscn"
        };
	}

	/// <summary>
	/// Changes the scene from the current scene to the next scene.
	/// Transfers the player from this scene to the next.
	/// </summary>
	/// <param name="sceneName">The next scene to be loaded.</param>
	public void ChangeScene(StringName sceneName)
	{
		// If the scene cannot be loaded, cancel
		if (!_availableScenes.Contains(sceneName)) {
			return;
		}

		// Wait until it is safe to change scenes
		// Otherwise, it may interrupt some code that is still executing
		CallDeferred(MethodName.DeferredChangeScene, sceneName);
	}

	public void DeferredChangeScene(string scenePath)
	{
		// Remove the player from the current scene
		Player player = CurrentScene.GetNode<Player>("Player");
		CurrentScene.RemoveChild(player);

		// It is now safe to remove the current scene.
		string oldSceneName = CurrentScene.Name;
		CurrentScene.Free();

		// Load a new scene.
		var nextScene = GD.Load<PackedScene>(scenePath).Instantiate();
		
		// Add the player to the scene as a child
		nextScene.AddChild(player);
		player.Owner = nextScene;
		
		CurrentScene = nextScene;

		// Reposition the player to the appropriate door.
		player.Position = CurrentScene.GetNode<Node2D>($"{oldSceneName}Door").Position;

		// Add it to the active scene, as child of root.
		GetTree().Root.AddChild(CurrentScene);

		// Optionally, to make it compatible with the SceneTree.change_scene_to_file() API.
		GetTree().CurrentScene = CurrentScene;
	}
}
