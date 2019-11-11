using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.enabled) // the platform effector disables this
        {
            var exp = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            exp.Play();
        }
    }
}
