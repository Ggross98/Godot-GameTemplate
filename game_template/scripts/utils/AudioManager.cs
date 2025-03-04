using Godot;
using System;
using System.Collections.Generic;

public partial class AudioManager : Node
{
    private const string MUSIC_BUS = "Music", SOUND_BUS = "Sound";
    private List<AudioStreamPlayer> musicPlayers, soundPlayers;
    private int currentMusicPlayer;
    private const int DEFAULT_SOUND_PLAYER_COUNT = 10;

    public override void _Ready()
    {
        base._Ready();

        LoadMusicManager();
        LoadSoundManager();
    }

    public void PlayMusic(AudioStream stream){
        var player0 = musicPlayers[currentMusicPlayer];
        var player1 = musicPlayers[1 - currentMusicPlayer];

        player0.Stop();
        player0.Stream = null;

        player1.Stream = stream;
        player1.Play();

        currentMusicPlayer = 1 - currentMusicPlayer;
    }

    public void PlaySound(AudioStream stream){
        AudioStreamPlayer player = null;
        for(int i = 0; i < soundPlayers.Count; i++){
            if(!soundPlayers[i].Playing){
                player = soundPlayers[i];
                break;
            }
        }
        if(player == null){
            player = AddSoundPlayer();
        }
        player.Stream = stream;
        player.Play();
    }

    private int GetBusIndex(string bus){
        switch(bus){
            case MUSIC_BUS:
                return 1;
            case SOUND_BUS:
                return 2;
            default:
                return 0;
        }
    }

    public void SetOption(string key, Variant value){
        switch(key){
            case "music_volume":
                SetVolume(MUSIC_BUS, (float)value.AsDouble());
                break;
            case "music_mute":
                SetMute(MUSIC_BUS, value.AsBool());
                break;
            case "sound_volume":
                SetVolume(SOUND_BUS, (float)value.AsDouble());
                break;
            case "sound_mute":
                SetMute(SOUND_BUS, value.AsBool());
                break;
            default:
                return;
        }
    }

    public void SetVolume(string bus, float volume){
        var db = Mathf.LinearToDb(volume);
        AudioServer.SetBusVolumeDb(GetBusIndex(bus), db);
    }

    public void SetMute(string bus, bool mute){
        AudioServer.SetBusMute(GetBusIndex(bus), mute);
    }

    private void LoadMusicManager(){
        musicPlayers = new List<AudioStreamPlayer>();
        for(int i = 0; i < 2; i++){
            var audioPlayer = new AudioStreamPlayer();
            audioPlayer.Name = "MusicPlayer_" + i;
            audioPlayer.Bus = MUSIC_BUS;
            audioPlayer.ProcessMode = ProcessModeEnum.Always;

            AddChild(audioPlayer);
            musicPlayers.Add(audioPlayer);
        }
        currentMusicPlayer = 0;
    }

    private void LoadSoundManager(){
        soundPlayers = new List<AudioStreamPlayer>();
        for(int i = 0; i < DEFAULT_SOUND_PLAYER_COUNT; i++){
            AddSoundPlayer();
        }
    }

    private AudioStreamPlayer AddSoundPlayer(){

        if(soundPlayers == null){
            soundPlayers = new List<AudioStreamPlayer>();
        }

        var audioPlayer = new AudioStreamPlayer();
        audioPlayer.Name = "SoundPlayer_" + soundPlayers.Count;
        audioPlayer.Bus = SOUND_BUS;
        audioPlayer.ProcessMode = ProcessModeEnum.Pausable;

        AddChild(audioPlayer);
        soundPlayers.Add(audioPlayer);
        
        return audioPlayer;
    }
}
