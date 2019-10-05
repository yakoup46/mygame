using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int power = 50;

    Rigidbody2D rb;
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("THERE");
            startPos = transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 force = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos;

            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(force * power, ForceMode2D.Impulse);
            print("HERE");
        }
    }
}
