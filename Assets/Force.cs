using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Force : MonoBehaviour
{
    Rigidbody2D rb;
    bool forced;

    public bool time;
    public float force = 1.0f;

    Vector2 startPos;

    public bool canDestroy;

    public bool thrown;
    public bool canThrow;

    public GameObject dot;
    private GameObject[] dots = new GameObject[15];

    public static int power;

    private bool mouseDown;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            startPos = mousePos;
            mouseDown = true;
        }

        if (Input.GetMouseButtonUp(0) && mouseDown)
        {
            mouseDown = false;
            canThrow = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canThrow && !thrown)
        {
            Vector2 dir = mousePos - startPos;

            if (dir.magnitude > 4)
            {
                dir = Vector2.ClampMagnitude(dir, 35);

                float oldMin = 4;
                float oldMax = 35;

                float newMin = 4;
                float nexMax = 15;

                float newDir = (((dir.magnitude - oldMin) * (nexMax - newMin)) / (oldMax - oldMin)) + newMin;


                // dir.magnitude / 35 * 15

                // if (dir.magnitude > 25)
                // {
                //     rb.AddForce(dir.normalized * (Mathf.Pow(dir.magnitude, 0.33f) * 18), ForceMode2D.Impulse);
                //  }
                // else
                // {
                //     rb.AddForce(dir.normalized * (Mathf.Pow(dir.magnitude, 0.33f) * 14), ForceMode2D.Impulse);
                // }

                rb.AddForce(dir.normalized * newDir * 5, ForceMode2D.Impulse);

                thrown = true;
            }

            canThrow = false;
        }
    }
}
