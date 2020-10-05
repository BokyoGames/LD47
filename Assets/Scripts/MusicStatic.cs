using System.Collections;
using System.Collections.Generic;

public class MusicStatic
{
    public static Dictionary<string, bool> enabled_music = new Dictionary<string, bool>{
         { "0", true }, 
         { "1", false }, 
         { "2", false }, 
         { "3", false }, 
         { "4", false }, 
         { "5", false }, 
         { "6", false }, 
         { "7", false }, 
         { "8", false }, 
         { "9", false }, 
         { "A", false }, 
         { "B", false }, 
         { "C", false }, 
         { "D", false }, 
         { "E", false } 
    };

    public static void EnableTrack(string track)
    {
        MusicStatic.enabled_music[track] = true;
    }

    public static void DisableTrack(string track)
    {
        MusicStatic.enabled_music[track] = false;
    }

    public static string ToDashString()
    {
        string result = "";
        foreach(KeyValuePair<string, bool> entry in MusicStatic.enabled_music)
        {
            // do something with entry.Value or entry.Key
            if(entry.Value == true)
                result+=entry.Key;
        }

        return result;
    }
}
