using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphablend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeOut()
    {
        iTween.ColorTo(gameObject, iTween.Hash("a", 0, "time", 0.75f, "easetype", "easeInQuad", "oncomplete", "FadeIn"));
    }

    void FadeIn()
    {
        iTween.ColorTo(gameObject, iTween.Hash("a", 1, "time", 0.75f, "easetype", "easeInQuad", "oncomplete", "FadeOut"));
    }
}
