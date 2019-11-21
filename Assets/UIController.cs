using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public bool OnUIScene = false;

    // "Scenes" the UI
    public GameObject LandingScene;
    public GameObject LevelScene;
    public GameObject PauseScene;
    public GameObject LoseScene;
    public GameObject WinScene;
    public GameObject TrayScene;

    public GameObject Background;

    // Start is called before the first frame update
    void Start()
    {
        if (OnUIScene)
        {
            LandingScene.SetActive(true);
        }
        else
        {
            Background.SetActive(false);
            HideAllScenes();
            PauseScene.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameScene()
    {
        Background.SetActive(false);
        HideAllScenes();
        SceneManager.LoadScene("0001");
        PauseScene.SetActive(true);
    }

    public void ShowLevelScene()
    {
        HideAllScenes();
        LevelScene.SetActive(true);
    }

    public void ShowLandingScene()
    {
        HideAllScenes();
        LandingScene.SetActive(true);
    }

    public void ShowLoseScene()
    {
        HideAllScenes();
        LoseScene.SetActive(true);
    }

    public void ShowWinScene()
    {
        HideAllScenes();
        WinScene.SetActive(true);
    }

    void HideAllScenes()
    {
        LandingScene.SetActive(false);
        LevelScene.SetActive(false);
        PauseScene.SetActive(false);
        LoseScene.SetActive(false);
        WinScene.SetActive(false);
        TrayScene.SetActive(false);
    }
}
