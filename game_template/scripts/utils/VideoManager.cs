using Godot;
using System;

public partial class VideoManager : Node
{
    public void SetOption(string key, Variant value){
        switch(key){
            case "full_screen":
                SetFullScreen(value.AsBool());
                break;
            case "resolution":
                SetResolution(value.AsVector2I());
                break;
            default:
                return;
        }
    }

    public void SetFullScreen(bool fullscreen ){
        var displayFullScreen = DisplayServer.WindowMode.ExclusiveFullscreen;
        var displayWindowed = DisplayServer.WindowMode.Windowed;
        DisplayServer.WindowSetMode(fullscreen ?  displayFullScreen : displayWindowed);
    }

    public void SetResolution(Vector2I targetRes){
        // var targetRes = resolutions[index];
        GetWindow().Size = targetRes;
        CenterWindow();
    }

    public void CenterWindow(){
        var screenCenter = DisplayServer.ScreenGetPosition() + DisplayServer.ScreenGetSize() / 2;
        var windowSize = GetWindow().GetSizeWithDecorations();
        GetWindow().Position = screenCenter - windowSize / 2;
    }
}
