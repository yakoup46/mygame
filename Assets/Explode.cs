using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public ParticleSystem explosion;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            collision.gameObject.GetComponent<Force>().canDestroy = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool canDestroy = collision.gameObject.GetComponent<Force>().canDestroy;

        if (canDestroy)
        {
            var exp = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            exp.Play();
        }
    }
}
