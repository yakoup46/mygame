using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLine : MonoBehaviour
{
    public int numberOfDots = 10;
    public float dotScale = 1.0f;
    public float dotScaleEase = 1.5f;
    public float dotPosEase = 1.1f;
    public GameObject dotTexture;
    public float maxRange = 320.0f;

    // Timing Values
    public float timeAiming = 0.1f;
    public float timeFadeIn = 0.1f;
    public float timeFadeOut = 0.25f;
    public float timeScale = 0.05f;
    public float timePos = 0.05f;
    public float timeAnim = 0.5f;

    private GameObject[] dotNodes;
    private bool swipe;
    private Vector2 aimPos;
    private float animPhase = 0.0f;

    private Vector2 startPos;
    private bool mouseDown;

    // Start is called before the first frame update
    void Start()
    {
        //aimPos = transform.position;
        dotNodes = new GameObject[numberOfDots];

        for (int i=0; i < numberOfDots; i++)
        {
            dotNodes[i] = Instantiate(dotTexture);

            SpriteRenderer s = dotNodes[i].GetComponent<SpriteRenderer>();
            s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            startPos = mousePos;
            aimPos = mousePos;
            mouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        swipe = Input.GetMouseButton(0);
        animPhase = (animPhase + Time.deltaTime / timeAnim) % 1;

        if (GetComponent<Force>().thrown)
        {
            for (int i = 0; i < numberOfDots; i++)
            {
                Destroy(dotNodes[i]);
            }
        }

        if (mouseDown && !GetComponent<Force>().thrown)
        {
            aimPos = aimPos * (1 - Time.deltaTime / timeAiming) + (mousePos * Time.deltaTime / timeAiming);

            for (int i=0; i < numberOfDots; i++)
            {
                SpriteRenderer s = dotNodes[i].GetComponent<SpriteRenderer>();
                Vector3 off = aimPos - startPos;

                if ((float)i / (float)numberOfDots < animPhase)
                {
                    if (off.magnitude * 1.5 > maxRange)
                    {
                        s.color = new Color(1f, 2-(float) (off.magnitude * 1.5) / maxRange, 2-(float)(off.magnitude * 1.5) / maxRange, Mathf.Lerp(s.color.a, 1, Time.deltaTime / timeFadeIn));
                    }
                    else
                    {
                        s.color = new Color(1f, 1f, 1f, Mathf.Lerp(s.color.a, 1, Time.deltaTime / timeFadeIn));
                    }
                }
                else
                {
                    if (off.magnitude * 1.5 > maxRange)
                    {
                        s.color = new Color(1f, 2 - (float)(off.magnitude * 1.5) / maxRange, 2 - (float)(off.magnitude * 1.5) / maxRange, Mathf.Lerp(s.color.a, 0, Time.deltaTime / timeFadeIn));
                    }
                    else
                    {
                        s.color = new Color(1f, 1f, 1f, Mathf.Lerp(s.color.a, 0, Time.deltaTime / timeFadeOut));
                    }
                }

                dotNodes[i].transform.localScale = dotNodes[i].transform.localScale * (1 - Time.deltaTime / timeScale) + Vector3.one * dotScale * EaseOut((float)i / (float)numberOfDots) * Time.deltaTime / timeScale;

                if (off.magnitude > maxRange)
                {
                    off = off.normalized * maxRange;
                }

                off *= EaseOut((float)i / (float)numberOfDots);

                dotNodes[i].transform.position = dotNodes[i].transform.position * (1 - Time.deltaTime / timePos) + (new Vector3(transform.position.x, transform.position.y, 0) + off) * Time.deltaTime / timePos;
            }
        }
        else if (!GetComponent<Force>().thrown)
        {
            aimPos = aimPos * (1 - Time.deltaTime / timeAiming) + (Vector2) transform.position * Time.deltaTime / timeAiming;

            for (int i = 0; i < numberOfDots; i++)
            {
                SpriteRenderer s = dotNodes[i].GetComponent<SpriteRenderer>();
                s.color = new Color(s.color.r, s.color.g, s.color.b, Mathf.Lerp(s.color.a, 0, Time.deltaTime / timeFadeOut));

                dotNodes[i].transform.localScale = dotNodes[i].transform.localScale * (1 - Time.deltaTime / timeScale);
                dotNodes[i].transform.position = dotNodes[i].transform.position * (1 - Time.deltaTime / timePos) + transform.position * Time.deltaTime / timePos;
            }
        }
    }

    private float EaseOut(float k)
    {
        return k;
    }
}
