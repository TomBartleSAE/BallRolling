using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall_ViewModel : MonoBehaviour
{
    public ParticleSystem deathParticles;
    public HealthModel myHealth;

    void Start()
    {
        myHealth.DeathEvent += DeathEffects;
    }

    public void DeathEffects(GameObject ball)
    {
        Debug.Log("Particles");
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(deathParticles, 3f);
    }
}
