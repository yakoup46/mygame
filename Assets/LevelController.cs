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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = targetZone.score.ToString();

        Debug.Log(targetZone.score);
        
        if (AllBoxesAtRest() && targetZone.score >= 100)
        {
            SceneManager.LoadScene(nextLevel);
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
