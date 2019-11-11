using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class Session : object
{
    public static string GetLevel()
    {
        if (PlayerPrefs.HasKey("on_level"))
        {
            return PlayerPrefs.GetString("on_level");
        }

        return "Level1";
    }

    //public static EditorBuildSettingsScene[] GetAllScenes()
    //{
    //    return EditorBuildSettings.scenes;
    //}
}

