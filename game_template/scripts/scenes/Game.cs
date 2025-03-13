using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class Game : Node2D
{
	[Export] private Button pauseButton;
    [Export] private PausePanel pausePanel;

    public override void _Ready()
    {
        base._Ready();

        pausePanel.Hide();

        pauseButton.Pressed += Pause;
        pausePanel.resumeButton.Pressed += Resume;
        pausePanel.restartButton.Pressed += Restart;
        pausePanel.quitButton.Pressed += Quit;
    }

    public void Pause(){
        pausePanel.Show();
    }

    public void Resume(){
        pausePanel.Hide();
    }

    public void Restart(){
        pausePanel.Hide();
    }

    public void Quit(){
        GetNode<SceneManager>("/root/SceneManager").LoadScene("res://scenes/main_menu.tscn");
    }

}