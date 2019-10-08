using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Force : MonoBehaviour
{
    Rigidbody2D rb;
    bool forced;

    public bool time;
    public float force = 1.0f;

    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //if (time)
        //{
        //    rb.AddForce(new Vector2(0.05f, 1) * 2000.0f * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
        //}
        //else
        //{
        //    rb.AddForce(new Vector2(0.05f, 1) * 40.0f * force, ForceMode2D.Impulse);
        //}

        //startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!forced)
        //{
        //    rb.AddForce(transform.up * 10.0f, ForceMode2D.Impulse);
        //    forced = true;
        //}
        //rb.MovePosition(rb.position + new Vector2(0, 1) * Time.fixedDeltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            startPos = transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 dir = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos;
            //rb.AddForce(dir.normalized * dir.magnitude * 2, ForceMode2D.Impulse);
            rb.AddForce(dir * 2, ForceMode2D.Impulse);
        }
    }
}
