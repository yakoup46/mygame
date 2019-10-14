using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    List<GameObject> boxes = new List<GameObject>();
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

    // Update is called once per frame
    void Update()
    {
        if (activeBox && activeBox.GetComponent<Force>().thrown)
        {
            activeBox = null;
            animationBox.GetComponent<EnterScreen>().Start();
        }
    }
}
