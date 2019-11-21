using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            Transform s1 = levels[i].transform.Find("Star1");
            Transform s2 = levels[i].transform.Find("Star2");
            Transform s3 = levels[i].transform.Find("Star3");

            int[] scores = Session.GetStars(levels[i].name);

            if (scores[0] == 0)
            {
                Color s1c = s1.GetComponent<Image>().color;
                s1c.a = 0.25f;
                s1.GetComponent<Image>().color = s1c;
            }

            if (scores[1] == 0)
            {
                Color s2c = s1.GetComponent<Image>().color;
                s2c.a = 0.25f;
                s2.GetComponent<Image>().color = s2c;
            }

            if (scores[2] == 0)
            {
                Color s3c = s1.GetComponent<Image>().color;
                s3c.a = 0.25f;
                s3.GetComponent<Image>().color = s3c;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
