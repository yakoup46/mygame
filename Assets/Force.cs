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

    public bool thrown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = transform.position;
        }

        if (!thrown && Input.GetMouseButtonUp(0))
        {
            Vector2 dir = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos;

            if (dir.magnitude > 7)
            {
                rb.AddForce(dir * 2, ForceMode2D.Impulse);
                StartCoroutine(SetThrown());
            }
        }
    }
    IEnumerator SetThrown()
    {
        yield return new WaitForSeconds(0.5f);
        thrown = true;
        gameObject.layer = 0;
    }
}
