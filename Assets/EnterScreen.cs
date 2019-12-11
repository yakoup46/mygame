using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScreen : MonoBehaviour
{
    public GameObject box;
    public GameObject floor;

    public GameObject boxController;

    Vector3 startPos;
    Vector3 startScale;

    public void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale;

        iTween.MoveAdd(gameObject, iTween.Hash("y", 4, "time", 0.5f, "easetype", "easeOutQuad", "onupdate", "Moving", "oncomplete", "MoveDone"));
    }

    void Moving()
    {
        float dy = (transform.position - startPos).y;
        
        if (dy > 1)
        {
            iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "duration", 2.0f));
        }

        if (dy > 2.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
    }

    void MoveDone()
    {
        BoxCollider2D floorCollider = floor.GetComponent<BoxCollider2D>();
        float topOfFloorBoxCollider = floor.transform.position.y + floorCollider.bounds.extents.y;

        iTween.MoveTo(gameObject, iTween.Hash("y", topOfFloorBoxCollider + 1, "time", 0.5f, "easetype", "easeInQuad", "oncomplete", "TweenDone"));
    }

    void TweenDone()
    {
        GameObject box = Instantiate(this.box, transform.position, Quaternion.identity);
        box.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;

        transform.position = startPos;
        transform.localScale = startScale;

        box.SetActive(true);

        boxController.GetComponent<BoxController>().addBox(box);
    }
}
