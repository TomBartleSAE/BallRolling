using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBallModel : MonoBehaviour
{
    public Rigidbody rb;
    public Transform ballTransform;
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponentInParent<RollingBallModel>())
        {
            HitBall(other.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<DebrisModel>())
        {
            Absorb(other.GetComponentInParent<DebrisModel>().GetSize());
            other.GetComponentInParent<HealthModel>().ChangeHealth(-1f);
        }
    }

    public void HitBall(GameObject otherBall)
    {
        // myImpactForce = velocity * size;
        // otherImpactForce = velocity * size;
        
        // if myImpactForce < otherImpactForce
        // reduce health
        // reduce ball size
    }

    public void Absorb(float amount)
    {
        GetComponent<HealthModel>().ChangeHealth(amount);
        //rb.mass += amount;
        ballTransform.localScale += new Vector3(amount, amount, amount);
    }
}
