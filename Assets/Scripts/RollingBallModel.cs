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
            rb.AddForce(other.GetContact(0).normal * other.gameObject.GetComponent<Rigidbody>().velocity.magnitude * 5f, ForceMode.Impulse);
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
        float impactMultiplier = 0.1f; // Scales how much damage is done when hitting another player
        float myImpactForce = rb.velocity.magnitude * health.GetHealth() * impactMultiplier;
        float otherImpactForce = otherBall.GetComponent<Rigidbody>().velocity.magnitude *
                                 otherBall.GetComponent<HealthModel>().GetHealth() * impactMultiplier;
        float impactDifference = otherImpactForce - myImpactForce;
        
        if (impactDifference > 0)
        {
            float totalDebris = 0f;
            for (int i = absorbedDebris.Count; i > 0; i--)
            {
                totalDebris += LoseDebris().GetSize();
                if (totalDebris > impactDifference)
                {
                    break;
                }
            }

            ChangeSize(-impactDifference);
        }
    }

    public void ChangeSize(float amount)
    {
        GetComponent<HealthModel>().ChangeHealth(amount);
        rb.mass += amount;
        ballTransform.localScale += new Vector3(amount, amount, amount);
    }

    public DebrisModel LoseDebris()
    {
        DebrisModel lostDebris = absorbedDebris.Pop();
        lostDebris.transform.position = transform.position;
        StartCoroutine(lostDebris.DelayCollider());
        lostDebris.gameObject.SetActive(true);
        lostDebris.GetComponent<Rigidbody>().AddForce(Vector3.up * 500f);
        return lostDebris;
    }
}