using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPath : MonoBehaviour
{
    public Vector3[] points = new Vector3[4];
    public float speed;
    
    int atPos = 0;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.localPosition, points[atPos]) < 0.01f)
        {
            transform.localPosition = points[atPos];
            atPos += 1;

            if (atPos > 3)
            {
                atPos = 0;
            }
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, points[atPos], Time.deltaTime * speed);
    }
}
