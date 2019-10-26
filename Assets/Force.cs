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

    public GameObject dot;
    private GameObject[] dots = new GameObject[15];

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
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
        {
            startPos = transform.position;
            mouseDown = true;
        }

        if (!thrown && Input.GetMouseButtonUp(0))
        {
            Vector2 dir = mousePos - startPos;

            if (dir.magnitude > 7)
            {
                rb.AddForce(dir * 2, ForceMode2D.Impulse);
                StartCoroutine(SetThrown());
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

	IEnumerator SetThrown()
	{
		yield return new WaitForSeconds(0.5f);
		thrown = true;
		gameObject.layer = 0;
	}
}
