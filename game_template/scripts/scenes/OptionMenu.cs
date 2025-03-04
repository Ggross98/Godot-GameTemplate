using Godot;
using System;

public partial class OptionMenu : Control
{
	[Export] private PackedScene mainMenu;
	[Export] private Button backButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		backButton.Pressed += Back;
		LoadOptions();
	}

	public void LoadOptions(){

	}

	public void SaveOptions(){

	}

	public void Back(){
		SaveOptions();
		GetTree().ChangeSceneToPacked(mainMenu);
	}
}
