using Godot;
using System;

/// <summary>
/// 场景管理脚本的父类
/// </summary>
public partial class SceneController : Node2D
{
    protected SceneManager sceneManager;
    protected AudioManager audioManager;

    public override void _Ready()
    {
        base._Ready();

        sceneManager = GetNode<SceneManager>("/root/SceneManager");
        audioManager = GetNode<AudioManager>("/root/AudioManager");
    }
}
