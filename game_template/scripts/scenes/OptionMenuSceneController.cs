using Godot;
using System;

public partial class OptionMenuSceneController : SceneController
{
	[Export] private Button backButton;

	public override void _Ready()
	{
		base._Ready();

		backButton.Pressed += delegate { sceneManager.LoadScene("res://scenes/main_menu.tscn"); };
	}
}
