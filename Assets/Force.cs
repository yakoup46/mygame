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

	bool mouseDown;

	public GameObject white;

	GameObject[] whites = new GameObject[30];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

		for (int i = 0; i < 30; i++)
		{
			whites[i] = Instantiate(white);
		}

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
			Vector2 start = startPos;

			for (int i=0; i < 30 ; i++)
			{
				Vector2 vel = (((mousePos - startPos) * 65) / rb.mass) * Time.fixedDeltaTime;

				Vector2 step = PlotTrajectoryAtTime(start, vel, 0.5f * i); ;
				whites[i].transform.position = step;
			}

		}
    }

    IEnumerator SetThrown()
    {
        yield return new WaitForSeconds(0.5f);
        thrown = true;
        gameObject.layer = 0;
    }

	public Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, float time)
	{
		return (Vector2) start + (Vector2) startVelocity * time + Physics2D.gravity * time * time * 0.5f;
	}

	//public void PlotTrajectory(Vector3 start, Vector3 startVelocity, float timestep, float maxTime)
	//{
	//	Vector3 prev = start;
	//	for (int i = 1; ; i++)
	//	{
	//		float t = timestep * i;
	//		if (t > maxTime) break;
	//		Vector3 pos = PlotTrajectoryAtTime(start, startVelocity, t);
	//		if (Physics.Linecast(prev, pos)) break;
	//		Debug.DrawLine(prev, pos, Color.red);
	//		prev = pos;
	//	}
	//}
}
