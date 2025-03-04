using Godot;
using System;

public partial class MainMenu : Control
{
	[Export]
	private Button startButton, optionButton, quitButton;


    public override void _Ready()
    {
        base._Ready();

		startButton.Pressed += delegate { LoadScene("res://scenes/game/game.tscn"); };
		optionButton.Pressed += delegate { LoadScene("res://scenes/option_menu.tscn"); };
		quitButton.Pressed += Quit;
    }

    // public void LoadScene(PackedScene scene){
	// 	GetTree().ChangeSceneToPacked(scene);
	// }
	
	public void LoadScene(string path){
		GetTree().ChangeSceneToFile(path);
	}

	public void Quit(){
		GetTree().Quit();
	}
}