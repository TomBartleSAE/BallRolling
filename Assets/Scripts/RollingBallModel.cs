using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RollingBallModel : MonoBehaviour
{
    public Rigidbody rb;
    public Transform ballTransform;
    private HealthModel health;

    public Stack<DebrisModel> absorbedDebris = new Stack<DebrisModel>();

    private void Awake()
    {
        health = GetComponent<HealthModel>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponentInParent<RollingBallModel>())
        {
            HitBall(other.gameObject);
        }
        
        if (other.gameObject.GetComponentInParent<DebrisModel>())
        {
            absorbedDebris.Push(other.gameObject.GetComponent<DebrisModel>());
            ChangeSize(other.gameObject.GetComponentInParent<DebrisModel>().GetSize());
            other.gameObject.GetComponentInParent<HealthModel>().ChangeHealth(-1f);
        }
    }

    public void HitBall(GameObject otherBall)
    {
        float myImpactForce = 0; // = rb.velocity.magnitude * health;
        float otherImpactForce = 0; // = otherBall.GetComponent<Rigidbody>().velocity.magnitude * otherBall.GetComponent<Health>();
        float impactDifference = otherImpactForce - myImpactForce;
        
        if (impactDifference > 0)
        {
            // reduce health
            // reduce ball size

            float totalDebris = 0f;
            for (int i = absorbedDebris.Count; i > 0; i--)
            {
                DebrisModel lostDebris = absorbedDebris.Pop();
                lostDebris.transform.position = transform.position;
                StartCoroutine(lostDebris.DelayCollider());
                lostDebris.gameObject.SetActive(true);
                lostDebris.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(50f,100f));
                
                totalDebris += lostDebris.GetSize();
                if (totalDebris > impactDifference)
                {
                    break;
                }
            }
        }
    }

    public void ChangeSize(float amount)
    {
        GetComponent<HealthModel>().ChangeHealth(amount);
        rb.mass += amount;
        ballTransform.localScale += new Vector3(amount, amount, amount);
    }
}
