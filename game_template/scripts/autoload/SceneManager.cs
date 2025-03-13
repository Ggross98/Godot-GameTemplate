using Godot;
using System;

public partial class SceneManager : Node
{
    public void LoadScene(string path){
        GetTree().ChangeSceneToFile(path);
    }

    public void LoadScene(PackedScene scene){
        GetTree().ChangeSceneToPacked(scene);
    }
}
