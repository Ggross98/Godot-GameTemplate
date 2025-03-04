using Godot;
using System;

public partial class PausePanel : Panel
{
	[Export] public Button resumeButton, restartButton, optionButton, quitButton;
	[Export] private Button backOptionButton;
	// [Export] private Control buttons;
	[Export] private OptionPanel optionPanel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		optionButton.Pressed += ShowOptionPanel;
		backOptionButton.Pressed += HideOptionPanel;

		HideOptionPanel();
	}

	public void ShowOptionPanel(){
		optionPanel.Show();
	}

	public void HideOptionPanel(){
		optionPanel.Hide();
	}
}
