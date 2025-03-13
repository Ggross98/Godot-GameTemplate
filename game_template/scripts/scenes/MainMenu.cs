using Godot;
using System;

public partial class MainMenu : Control
{
	[Export]
	private Button startButton, optionButton, quitButton;


    public override void _Ready()
    {
        base._Ready();

		startButton.Pressed += delegate { GetNode<SceneManager>("/root/SceneManager").LoadScene("res://scenes/game.tscn"); };
		optionButton.Pressed += delegate { GetNode<SceneManager>("/root/SceneManager").LoadScene("res://scenes/option_menu.tscn"); };
		quitButton.Pressed += Quit;
    }

	public void Quit(){
		GetTree().Quit();
	}
}