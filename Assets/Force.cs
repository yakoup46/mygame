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

    public GameObject dot;
    private GameObject[] dots = new GameObject[15];

    public static int power;

    private bool mouseDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //for (int i=0; i < dots.Length; i++)
        //{
        //    dots[i] = Instantiate(dot, transform);
        //    dots[i].transform.position = transform.position;
        //}

        //power.text = "35";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
        {
            startPos = mousePos;
            mouseDown = true;
        }

        if (!thrown && Input.GetMouseButtonUp(0))
        {
            Vector2 dir = mousePos - startPos;

            if (dir.magnitude > 4)
            {
                //dir = dir.sqrMagnitude;
                dir = Vector2.ClampMagnitude(dir, 35);
                rb.AddForce(dir * Mathf.Max((4 * Mathf.Cos(dir.magnitude / 27)), 2), ForceMode2D.Impulse);
                thrown = true;
                //StartCoroutine(SetThrown());
            }

            mouseDown = false;
        }

        if (mouseDown)
        {
           // for (int i = 0; i < dots.Length; i++)
            //{
                //var len = mousePos - tran
             //   dots[i].transform.position = (Vector2)transform.position + (mousePos.normalized / dots.Length) * i;
            //}
        }
    }

    /*
	IEnumerator SetThrown()
	{
		yield return new WaitForSeconds(0.5f);
		thrown = true;
		gameObject.layer = 0;
	}
    */
}
