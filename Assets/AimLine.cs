using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    LineRenderer line;
    Gradient gradient;
    Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        startPoint = transform.position;
        gradient = line.GetComponent<Gradient>();

        Debug.Log(gradient);

        line.SetPositions(new Vector3[4]{startPoint, startPoint, startPoint, startPoint});
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (Input.GetMouseButton(0))
        {
            Vector3 vector = mousePos - line.GetPosition(3);

            line.SetPositions(new Vector3[4]
            {
                startPoint,
                line.GetPosition(1) + (vector/4 * Time.deltaTime * 8),
                line.GetPosition(2) + (vector/3 * Time.deltaTime * 8),
                line.GetPosition(3) + (vector/2 * Time.deltaTime * 8),
            });
        }
        else
        {
            line.SetPositions(new Vector3[4] { startPoint, startPoint, startPoint, startPoint });
        }
    }
}
