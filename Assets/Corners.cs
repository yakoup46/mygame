using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corners : MonoBehaviour
{
    public GameObject corner;
    //public Text Tarea;

    Vector3[] zoneCorners;
    GameObject point;

    List<Vector2> points = new List<Vector2>();
    //List<GameObject> corners = new List<GameObject>();

    Dictionary<GameObject, float> areas = new Dictionary<GameObject, float>();

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        zoneCorners = GetCorners(transform);
        //point = Instantiate(corner);
        //point.name = "red";
        //point.GetComponent<SpriteRenderer>().color = Color.red;

        //corners.Add(point);

        //for (var i = 0; i < 15; i++)
        //{
        //    corners.Add(Instantiate(point));
        //}
    }

    Vector3[] GetCorners(Transform transform)
    {
        BoxCollider2D box = transform.GetComponent<BoxCollider2D>();

        // The collider's centre point in the world
        Vector3 worldPosition = transform.TransformPoint(0, 0, 0);

        // The collider's local width and height, accounting for scale, divided by 2
        Vector2 size = new Vector2(box.size.x * transform.localScale.x * 0.5f, box.size.y * transform.localScale.y * 0.5f);

        // STEP 1: FIND LOCAL, UN-ROTATED CORNERS
        // Find the 4 corners of the BoxCollider2D in LOCAL space, if the BoxCollider2D had never been rotated
        Vector3 corner1 = new Vector2(-size.x, -size.y);
        Vector3 corner2 = new Vector2(-size.x, size.y);
        Vector3 corner3 = new Vector2(size.x, -size.y);
        Vector3 corner4 = new Vector2(size.x, size.y);

        // STEP 2: ROTATE CORNERS
        // Rotate those 4 corners around the centre of the collider to match its transform.rotation
        corner1 = RotatePointAroundPivot(corner1, Vector3.zero, transform.eulerAngles);
        corner2 = RotatePointAroundPivot(corner2, Vector3.zero, transform.eulerAngles);
        corner3 = RotatePointAroundPivot(corner3, Vector3.zero, transform.eulerAngles);
        corner4 = RotatePointAroundPivot(corner4, Vector3.zero, transform.eulerAngles);

        // STEP 3: FIND WORLD POSITION OF CORNERS
        // Add the 4 rotated corners above to our centre position in WORLD space - and we're done!
        corner1 = worldPosition + corner1;
        corner2 = worldPosition + corner2;
        corner3 = worldPosition + corner3;
        corner4 = worldPosition + corner4;

        return new Vector3[]
        {
            corner1, corner2, corner4, corner3
        };
    }

    // Update is called once per frame
    void Update()
    {
        float totalArea = 0;

        foreach (KeyValuePair<GameObject, float> a in areas)
        {
            totalArea += a.Value;
        }

        // Tarea.text = totalArea.ToString();

        score = (int) totalArea;
    }

    Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        //{
        //for (var i = 0; i < points.Count; i++)
        //{
        //    corners[i].transform.position = new Vector2(-100, 100);
        //}
            points.Clear();

            CheckForLineIntersect(collision);

            //for (var i = 0; i < points.Count; i++)
            //{
             //   corners[i].transform.position = points[i];
    //        }

            Vector2[] pointsA = points.ToArray();

            //not so sure i need this?
            Array.Sort(pointsA, new ClockwiseComparer(collision.transform.position));

            float area = 0;
            int j = pointsA.Length - 1;

            float[] Xs = new float[pointsA.Length];
            float[] Ys = new float[pointsA.Length];

            for (int i=0; i < pointsA.Length; i++)
            {
                Xs[i] = pointsA[i].x;
                Ys[i] = pointsA[i].y;
            }

            for (int i = 0; i < pointsA.Length; i++)
            {
                area += (Xs[j] + Xs[i]) * (Ys[j] - Ys[i]);
                j = i;
            }

            area = (Math.Abs(area / 2.0f) / 5.5f) * 100;

        areas[collision.gameObject] = area;

      
        //}
    }

    void GetColliderPointsInsideZone(Collider2D box, Vector3[] corners, Vector3[] zcorners)
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();

        foreach (Vector3 c in corners)
        {
            if (col.OverlapPoint(c))
            {
                points.Add(c);
            }
        }

        foreach (Vector3 c in zcorners)
        {
            if (box.OverlapPoint(c))
            {
                points.Add(c);
            }
        }
    }

    void CheckForLineIntersect(Collider2D collision)
    {
        Vector3[] collisionCorners = GetCorners(collision.transform);

        for (int i = 0; i <= 3; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                int di = (i + 1) % 4;
                int dj = (j + 1) % 4;

                FindIntersection(
                    new Vector2(collisionCorners[i].x, collisionCorners[i].y),
                    new Vector2(collisionCorners[di].x, collisionCorners[di].y),
                    new Vector2(zoneCorners[j].x, zoneCorners[j].y),
                    new Vector2(zoneCorners[dj].x, zoneCorners[dj].y)
                );
            }
        }

        GetColliderPointsInsideZone(collision, collisionCorners, zoneCorners);
    }

    void FindIntersection(Vector2 s1, Vector2 e1, Vector2 s2, Vector2 e2)
    {
        float a1 = e1.y - s1.y;
        float b1 = s1.x - e1.x;
        float c1 = a1 * (s1.x) + b1 * (s1.y);

        float a2 = e2.y - s2.y;
        float b2 = s2.x - e2.x;
        float c2 = a2 * (s2.x) + b2 * (s2.y);

        float delta = a1 * b2 - a2 * b1;

        if (delta != 0)
        {
            float x = (b2 * c1 - b1 * c2) / delta;
            float y = (a1 * c2 - a2 * c1) / delta;

            // dot on the line
            Vector2 ab1 = e2 - s2;
            Vector2 ac1 = new Vector2(x, y) - s2;

            Vector2 ab2 = e1 - s1; 
            Vector2 ac2 = new Vector2(x, y) - s1;

            if (Vector2.Dot(ab1, ac1) > 0f && ab1.sqrMagnitude >= ac1.sqrMagnitude && Vector2.Dot(ab2, ac2) > 0f && ab2.sqrMagnitude >= ac2.sqrMagnitude)
            {
                points.Add(new Vector2(x, y));
            }
        }
    }
}
public class ClockwiseComparer : IComparer
{
    private Vector2 m_Origin;

    #region Properties

    /// <summary>
    ///     Gets or sets the origin.
    /// </summary>
    /// <value>The origin.</value>
    public Vector2 origin { get { return m_Origin; } set { m_Origin = value; } }

    #endregion

    /// <summary>
    ///     Initializes a new instance of the ClockwiseComparer class.
    /// </summary>
    /// <param name="origin">Origin.</param>
    public ClockwiseComparer(Vector2 origin)
    {
        m_Origin = origin;
    }

    #region IComparer Methods

    /// <summary>
    ///     Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
    /// </summary>
    /// <param name="first">First.</param>
    /// <param name="second">Second.</param>
    public int Compare(object first, object second)
    {
        Vector2 pointA = (Vector2)first;
        Vector2 pointB = (Vector2)second;

        return IsClockwise(pointB, pointA, m_Origin);
    }

    #endregion

    /// <summary>
    ///     Returns 1 if first comes before second in clockwise order.
    ///     Returns -1 if second comes before first.
    ///     Returns 0 if the points are identical.
    /// </summary>
    /// <param name="first">First.</param>
    /// <param name="second">Second.</param>
    /// <param name="origin">Origin.</param>
    public static int IsClockwise(Vector2 first, Vector2 second, Vector2 origin)
    {
        if (first == second)
            return 0;

        Vector2 firstOffset = first - origin;
        Vector2 secondOffset = second - origin;

        float angle1 = Mathf.Atan2(firstOffset.x, firstOffset.y);
        float angle2 = Mathf.Atan2(secondOffset.x, secondOffset.y);

        if (angle1 < angle2)
            return 1;

        if (angle1 > angle2)
            return -1;

        // Check to see which point is closest
        return (firstOffset.sqrMagnitude < secondOffset.sqrMagnitude) ? 1 : -1;
    }
}

