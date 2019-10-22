using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPoints : MonoBehaviour
{
    public GameObject white;

    GameObject w1;
    GameObject w2;
    GameObject w3;
    GameObject w4;

    GameObject w5;
    GameObject w6;
    GameObject w7;
    GameObject w8;

    // Start is called before the first frame update
    void Start()
    {
        w1 = Instantiate(white);
        w2 = Instantiate(white);
        w3 = Instantiate(white);
        w4 = Instantiate(white);

        w5 = Instantiate(white);
        w5.GetComponent<SpriteRenderer>().color = Color.red;
        w6 = Instantiate(white);
        w6.GetComponent<SpriteRenderer>().color = Color.red;
        w7 = Instantiate(white);
        w7.GetComponent<SpriteRenderer>().color = Color.red;
        w8 = Instantiate(white);
        w8.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Box")
        {
            Vector2 vel = collision.GetComponent<Rigidbody2D>().velocity;

            if (vel == new Vector2(0, 0))
            {
                Vector2 box = collision.transform.position;
                Vector2 zone = transform.position;

                Vector2 boxBottomLeftPoint = new Vector2(box.x - 1, box.y + 1);
                Vector2 boxBottomRightPoint = new Vector2(box.x + 1, box.y + 1);
                Vector2 boxTopLeftPoint = new Vector2(box.x - 1, box.y - 1);
                Vector2 boxTopRightPoint = new Vector2(box.x + 1, box.y - 1);

                Vector2 zoneBottomLeftPoint = new Vector2(zone.x - 1, zone.y + 1);
                Vector2 zoneBottomRightPoint = new Vector2(zone.x + 1, zone.y + 1);
                Vector2 zoneTopLeftPoint = new Vector2(zone.x - 1, zone.y - 1);
                Vector2 zoneTopRightPoint = new Vector2(zone.x + 1, zone.y - 1);

                w1.transform.position = boxBottomLeftPoint;
                w2.transform.position = boxBottomRightPoint;
                w3.transform.position = boxTopLeftPoint;
                w4.transform.position = boxTopRightPoint;

                w5.transform.position = zoneBottomLeftPoint * (transform.rotation.z / 360);
                w6.transform.position = zoneBottomRightPoint * (transform.rotation.z / 360);
                w7.transform.position = zoneTopLeftPoint * (transform.rotation.z / 360);
                w8.transform.position = zoneTopRightPoint * (transform.rotation.z / 360);
            }
        }
    }
}
