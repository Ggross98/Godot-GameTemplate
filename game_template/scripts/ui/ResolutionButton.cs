using Godot;
using Godot.Collections;

public partial class ResolutionButton : OptionButton
{
	private Dictionary<string, int> dict = new Dictionary<string, int>();

    public void AddOption(Vector2I res){
        string r = string.Format("{0:D}x{1:D}", res.X, res.Y);
        if(!dict.ContainsKey(r)){
            int idx = dict.Count;
            AddItem(r, idx);
            dict[r] = idx;
        }
    }

    public void SelectOption(Vector2I res){
        string r = string.Format("{0:D}x{1:D}", res.X, res.Y);
        if(dict.ContainsKey(r)){
            int idx = dict[r];
            Select(idx);
        }
    }
}
