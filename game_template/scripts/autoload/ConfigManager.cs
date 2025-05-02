using Godot;

public partial class ConfigManager : Node
{
    private ConfigFile config = new ConfigFile();
    private const string SETTINGS_FILE_PATH = "user://settings.ini";
    private AudioManager audioManager;
    private VideoManager videoManager;

    public override void _Ready()
    {
        base._Ready();

        // Get video and audio managers
        audioManager = GetNode<AudioManager>("/root/AudioManager");
        videoManager = GetNode<VideoManager>("/root/VideoManager");

        // Try load or initialize options
        if(FileAccess.FileExists(SETTINGS_FILE_PATH)){
            config.Load(SETTINGS_FILE_PATH);
        }
        // Video options
        if(!config.HasSectionKey("video", "full_screen")) config.SetValue("video", "full_screen", false);
        if(!config.HasSectionKey("video", "resolution")) config.SetValue("video", "resolution", new Vector2I(1920, 1080));
        // Audio options
        if(!config.HasSectionKey("audio", "music_volume")) config.SetValue("audio", "music_volume", 1.0f);
        if(!config.HasSectionKey("audio", "music_mute")) config.SetValue("audio", "music_mute", false);
        if(!config.HasSectionKey("audio", "sound_volume")) config.SetValue("audio", "sound_volume", 1.0f);
        if(!config.HasSectionKey("audio", "sound_mute")) config.SetValue("audio", "sound_mute", false);

        // Save .ini file
        config.Save(SETTINGS_FILE_PATH);

        // Set all options
        foreach(var key in new string[]{"resolution", "full_screen"}){
            videoManager.SetOption(key, GetOptionValue("video", key));
        }
        foreach(var key in new string[]{"music_volume", "music_mute", "sound_volume", "sound_mute"}){
            audioManager.SetOption(key, GetOptionValue("audio", key));
        }
    }

    public Variant GetOptionValue(string section, string key){
        return config.GetValue(section, key);
    }

    public void SaveOptionValue(string section, string key, Variant value){

        switch(section){
            case "video":
                videoManager.SetOption(key, value);
                break;
            case "audio":
                audioManager.SetOption(key, value);
                break;
            default:
                return;
        }

        config.SetValue(section, key, value);
        config.Save(SETTINGS_FILE_PATH);
    }

}
