using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxPath : MonoBehaviour
{
    public Vector2[] points = new Vector2[4];

    Vector2 target;
    int atPos = 0;
    Vector2[] relPoints = new Vector2[4];

    // Start is called before the first frame update
    void Start()
    {
        Vector2 startPos = transform.position;

        for (int i = 0; i < points.Length; i++)
        {
            relPoints[i] = points[i] + startPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, relPoints[atPos]) < 0.01f)
        {
            transform.position = relPoints[atPos];
            atPos += 1;

            if (atPos > 3)
            {
                atPos = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, relPoints[atPos], Time.deltaTime * 10);
    }
}
