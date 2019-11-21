using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public List<GameObject> boxes = new List<GameObject>();
    public LevelController lvl;
    GameObject activeBox;

    public GameObject animationBox;

    public void addBox(GameObject box)
    {
        activeBox = box;
        boxes.Add(box);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int ThrownBoxes()
    {
        int thrown = 0;

        foreach (GameObject b in boxes)
        {
            if (b == null)
            {
                thrown += 1; // was destroyed on force field
            }
            else if (b.GetComponent<Force>().thrown)
            {
                thrown += 1;
            }
        }

        return thrown;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBox && activeBox.GetComponent<Force>().thrown && boxes.Count < lvl.maxNumberOfBoxes)
        {
            activeBox = null;
            animationBox.GetComponent<EnterScreen>().Start();
        }

        if (boxes.Count >= lvl.maxNumberOfBoxes)
        {
            Destroy(animationBox);
        }
    }
}
