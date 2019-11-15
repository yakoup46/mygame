using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPositionParticleSystem : MonoBehaviour
{
    GameObject particleSys;

    // Start is called before the first frame update
    void Start()
    {
        particleSys = transform.GetChild(0).gameObject;

        Vector2 size = transform.GetComponent<BoxCollider2D>().size;
        float offsetX = -size.x / 2;
        float offsetY = size.y / 2;
        particleSys.GetComponent<Transform>().localPosition = new Vector2(offsetX, offsetY);

        BoxPath bp = particleSys.GetComponent<BoxPath>();
        bp.points[0] = new Vector3(size.x + offsetX, offsetY, transform.position.z);
        bp.points[1] = new Vector3(size.x + offsetX, -size.y + offsetY, transform.position.z);
        bp.points[2] = new Vector3(offsetX, -size.y + offsetY, transform.position.z);
        bp.points[3] = new Vector3(offsetX, offsetY, transform.position.z);
        bp.speed = size.x * 2.5f;
    }
}
