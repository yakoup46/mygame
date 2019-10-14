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

    public GameObject trajectoryDotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 6; i++)
        {
            GameObject trajectoryDot = Instantiate(trajectoryDotPrefab);
            trajectoryDot.transform.position = CalculatePosition(0.25f * i);
        }
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

    private Vector2 CalculatePosition(float elapsedTime)
    {
        return new Vector2(0f, -240f) * elapsedTime * elapsedTime * 0.5f +
               new Vector2(20f, 80f) * elapsedTime + Vector2.zero;
    }
}
