using Godot;
using System;

public partial class OptionMenu : Control
{
	[Export] private Button backButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		backButton.Pressed += delegate { GetNode<SceneManager>("/root/SceneManager").LoadScene("res://scenes/main_menu.tscn"); };
	}
}
