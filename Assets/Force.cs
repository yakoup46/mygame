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
                rb.AddForce(dir * Mathf.Max((4 * Mathf.Cos(dir.magnitude / 27)), 2), ForceMode2D.Impulse);
                thrown = true;
            }

            canThrow = false;
        }
    }
}
