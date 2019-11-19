using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFinish : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.Particle[] m_Particles = new ParticleSystem.Particle[3];

    public GameObject star;

    private bool spawnStars = true;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ps.GetParticles(m_Particles);

        if (!ps.IsAlive() && spawnStars) {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(star, m_Particles[i].position, Quaternion.identity);
                Debug.Log(m_Particles[i].GetCurrentSize(ps));
            }

            spawnStars = false;
        }
        
    }
}
