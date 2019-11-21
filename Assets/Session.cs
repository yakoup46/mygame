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

    public static int[] GetStars(string level)
    {
        string key = string.Format("level_{0}_scores", level);

        if (PlayerPrefs.HasKey(key))
        {
            LevelScores score = JsonUtility.FromJson<LevelScores>(PlayerPrefs.GetString(key));

            return new int[3]
            {
                score.star1,
                score.star2,
                score.star3
            };
        }

        LevelScores ls = new LevelScores();
        ls.level = level;

        PlayerPrefs.SetString(key, JsonUtility.ToJson(ls));
        PlayerPrefs.Save();

        return new int[3]
        {
            ls.star1,
            ls.star2,
            ls.star3
        };
    }

    public static void SetStars(string level, int score)
    {
        string key = string.Format("level_{0}_scores", level);

        LevelScores ls = new LevelScores();
        ls.level = level;

        if (score == 1)
        {
            ls.star1 = 1;
            ls.star2 = 0;
            ls.star3 = 0;
        }
        else if (score == 2)
        {
            ls.star1 = 1;
            ls.star2 = 1;
            ls.star3 = 0;
        }
        else if (score == 3)
        {
            ls.star1 = 1;
            ls.star2 = 1;
            ls.star3 = 1;
        }

        PlayerPrefs.SetString(key, JsonUtility.ToJson(ls));
        PlayerPrefs.Save();
    }
}
