using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public partial class OptionPanel : Panel
{
	[Export] private ResolutionButton resolutionButton;
    [Export] private Slider musicVolumeSlider, soundVolumeSlider;
    [Export] private TextureButton fullScreenButton, musicMuteButton, soundMuteButton;

    private ConfigManager configManager;
	private List<Vector2I> resolutions;

    public override void _Ready()
    {
        base._Ready();  

        configManager = GetNode<ConfigManager>("/root/ConfigManager");
        LoadOptions();
    }

	public void LoadOptions(){

        List<Vector2I> defaultResolutions = new List<Vector2I>(){
            new Vector2I(2560, 1440),
            new Vector2I(1920, 1080),
            new Vector2I(1600, 900),
            new Vector2I(1366, 768),
            new Vector2I(1280, 720),
        };
        LoadResolutions(defaultResolutions);

        

        fullScreenButton.ButtonPressed = configManager.GetOptionValue("video", "full_screen").AsBool();
        fullScreenButton.Pressed += delegate {
            // SetFullScreen(fullScreenButton.ButtonPressed);
            configManager.SaveOptionValue("video", "full_screen", fullScreenButton.ButtonPressed);
        };

        musicVolumeSlider.Value = configManager.GetOptionValue("audio", "music_volume").AsDouble();
        musicVolumeSlider.ValueChanged += delegate { 
            configManager.SaveOptionValue("audio", "music_volume", musicVolumeSlider.Value); 
        };
        musicMuteButton.ButtonPressed = configManager.GetOptionValue("audio", "music_mute").AsBool();
        musicMuteButton.Pressed += delegate {
            configManager.SaveOptionValue("audio", "music_mute", musicMuteButton.ButtonPressed);
        };

        soundVolumeSlider.Value = configManager.GetOptionValue("audio", "sound_volume").AsDouble();
        soundVolumeSlider.ValueChanged += delegate { 
            configManager.SaveOptionValue("audio", "sound_volume", soundVolumeSlider.Value); 
        };
        soundMuteButton.ButtonPressed = configManager.GetOptionValue("audio", "sound_mute").AsBool();
        soundMuteButton.Pressed += delegate {
            configManager.SaveOptionValue("audio", "sound_mute", soundMuteButton.ButtonPressed);
        };
    
	}

    // public void SetFullScreen(bool fullscreen ){
    //     var displayFullScreen = DisplayServer.WindowMode.ExclusiveFullscreen;
    //     var displayWindowed = DisplayServer.WindowMode.Windowed;
    //     DisplayServer.WindowSetMode(fullscreen ?  displayFullScreen : displayWindowed);
    // }

	public void LoadResolutions(List<Vector2I> _resolutions){
		resolutions = _resolutions;

		var currentRes = GetWindow().Size;
		if(!resolutions.Contains(currentRes)){
			resolutions.Add(currentRes);
		}
        
		foreach(var res in resolutions){
            resolutionButton.AddOption(res);
        }
        
        resolutionButton.SelectOption(currentRes);
		GD.Print(currentRes);

        resolutionButton.ItemSelected += delegate {
            var targetRes = resolutions[resolutionButton.Selected];
            configManager.SaveOptionValue("video", "resolution", targetRes);
            // SetResolution(resolutionButton.Selected);
        };
	}

    // public void SetResolution(int index){
    //     var targetRes = resolutions[index];
    //     GetWindow().Size = targetRes;
    //     CenterWindow();
    // }

    // public void CenterWindow(){
    //     var screenCenter = DisplayServer.ScreenGetPosition() + DisplayServer.ScreenGetSize() / 2;
    //     var windowSize = GetWindow().GetSizeWithDecorations();
    //     GetWindow().Position = screenCenter - windowSize / 2;
    // }

}
