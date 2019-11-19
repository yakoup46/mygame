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

    public int boxesForThreeStars;
    public float percentageFor2Stars;
    public float percentageFor3Stars;
    public int maxNumberOfBoxes;

    // Start is called before the first frame update
    void Start()
    {
        boxesForThreeStars += 1; // the box they haven't thrown yet is on the stack
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = targetZone.score.ToString();

        if (AllBoxesAtRest())
        {
            if (boxes.boxes.Count <= boxesForThreeStars)
            {
                if (targetZone.score > percentageFor2Stars)
                {
                    stars.PlayStar(1);
                    stars.PlayStar(2);
                }
                else
                {
                    if (stars.GetAnimated(1))
                    {
                        stars.RemoveStar(1);
                    }

                    if (stars.GetAnimated(2))
                    {
                        stars.RemoveStar(2);
                    }
                }

                if (targetZone.score > percentageFor3Stars)
                {
                    stars.PlayStar(3);
                    UI.ShowWinScene();
                }
                else if (stars.GetAnimated(3))
                {
                    stars.RemoveStar(3);
                }
            }
            else
            {
                if (targetZone.score > percentageFor2Stars)
                {
                    stars.PlayStar(1);
                }
                else if (stars.GetAnimated(1))
                {
                    stars.RemoveStar(1);
                }

                if (targetZone.score > percentageFor3Stars)
                {
                    stars.PlayStar(2);
                }
                else if (stars.GetAnimated(2))
                {
                    stars.RemoveStar(2);
                }
            }


            if (boxes.boxes.Count > maxNumberOfBoxes + 1)
            {
                if (!stars.GetAnimated(1) && !stars.GetAnimated(2))
                {
                    UI.ShowLoseScene();
                }
                else
                {
                    UI.ShowWinScene();
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
}
