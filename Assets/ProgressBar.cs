using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = bar.transform.position;
        pos.x = bar.transform.localScale.x / 2; // this works b/c the bar is centered in the screen

        bar.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
