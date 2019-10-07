using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int power = 50;

    Rigidbody2D rb;
    Vector2 startPos;

    bool pressed = false;
    bool forceApplied = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            forceApplied = false;
            pressed = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }
    }

    void FixedUpdate()
    {
        if (pressed)
        {
            startPos = transform.position;
        }

        if (!forceApplied && !pressed)
        {
            Vector2 force = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos;

            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(force * power, ForceMode2D.Impulse);

            forceApplied = true;
        }
    }
}
