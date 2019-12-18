using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public Text scoreText;
    public Corners targetZone;
    public string nextLevel;
    public BoxController boxes;
    public StarManager stars;
    public UIController UI;
    public GameObject progressBar;

    // public int boxesForThreeStars;
    // public float percentageFor2Stars;
    // public float percentageFor3Stars;
    public int maxNumberOfBoxes;

    // Start is called before the first frame update
    void Start()
    {
        //UI.TrayScene.transform.Find("Details").GetComponent<Text>().text = percentageFor2Stars.ToString() + " | " + percentageFor3Stars.ToString() + " | " + boxesForThreeStars.ToString() + " | " + maxNumberOfBoxes.ToString();
        //boxesForThreeStars += 1; // the box they haven't thrown yet is on the stack
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString("D4"));
    }

    // Update is called once per frame
    void Update()
    {
        int s = 0;
        scoreText.text = targetZone.score.ToString();

        UpdateProgressBar(targetZone.score);

        if (AllBoxesAtRest())
        {
            // one star
            if (targetZone.score > 80)
            {
                stars.PlayStar(1);
                s = 1;
            }
            else if (stars.GetAnimated(1))
            {
                s = 0;
                stars.RemoveStar(1);
            }

            if (targetZone.score > 90)
            {
                stars.PlayStar(2);
                s = 2;
            }
            else if (stars.GetAnimated(2))
            {
                s = 1;
                stars.RemoveStar(2);
            }

            if (targetZone.score > 99)
            {
                s = 3;
                stars.PlayStar(3);
            }
            else if (stars.GetAnimated(3))
            {
                s = 2;
                stars.RemoveStar(3);
            }
            
            if (boxes.ThrownBoxes() == maxNumberOfBoxes || s == 3)
            {
                if (s == 0)
                {
                    UI.ShowLoseScene();
                }
                else if (stars.GetAnimatonDone(s))
                {
                    UI.ShowWinScene();
                    Session.SetStars(SceneManager.GetActiveScene().name, s);
                }
            }

        }
    }

    bool AllBoxesAtRest()
    {
        foreach (GameObject b in boxes.boxes)
        {
            // might be null b/c Explode destroyed it
            if (b!= null && !b.GetComponent<Rigidbody2D>().IsSleeping())
            {
                return false;
            }
        }

        return true;
    }

    void UpdateProgressBar(float score)
    {
        // hard code score out of 100 right now
        // hard code bar starting position of -8

        float percentage = score / 100;

        if (percentage > 1)
        {
            percentage = 1;
        }

        if (percentage > 0)
        {
            //progressBar.transform.localPosition = new Vector3(-8 - (-8 * percentage), progressBar.transform.position.y, progressBar.transform.position.z);
            iTween.MoveTo(progressBar, iTween.Hash("x", -6 - (-6 * percentage), "time", 1.0f, "easetype", "easeOutQuad"));
        }
    }
}
