using Godot;
using System;

public partial class MainMenuSceneController : SceneController
{
	[Export]
	private Button startButton, optionButton, quitButton;


    public override void _Ready()
    {
        base._Ready();

		startButton.Pressed += delegate { sceneManager.LoadScene("res://scenes/game.tscn"); };
		optionButton.Pressed += delegate { sceneManager.LoadScene("res://scenes/option_menu.tscn"); };
		quitButton.Pressed += Quit;
    }

	public void Quit(){
		GetTree().Quit();
	}
}