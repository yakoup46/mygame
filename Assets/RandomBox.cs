using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    public Sprite[] boxImages;

    // Start is called before the first frame update
    void Start()
    {
        int size = boxImages.Length;
        
        System.Random rnd = new System.Random();
        int image = rnd.Next(0, size);

        GetComponent<SpriteRenderer>().sprite = boxImages[image];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
