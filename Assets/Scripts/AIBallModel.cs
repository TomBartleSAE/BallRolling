using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBallModel : MonoBehaviour
{
    public float detectRadius = 5f;
    public LayerMask ballLayer;
    public bool isBallNearby = false;
    
    public Collider FindClosestBall()
    {
        // All player and AI balls need to be on the Ball layer
        Collider[] nearbyBalls = Physics.OverlapSphere(transform.position, detectRadius, ballLayer);
        
        if (nearbyBalls.Length == 0)
        {
            isBallNearby = false;
            return null;
        }

        float closestDistance = Mathf.Infinity;
        Collider closestBall = null;
            
        foreach (Collider ball in nearbyBalls)
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestBall = ball;
            }
        }

        isBallNearby = true;
        return closestBall;
    }

    public void Chase()
    {
        Debug.Log("Chase ball");
    }

    public void Flee()
    {
        Debug.Log("Flee from ball");
    }

    public void Gather()
    {
        Debug.Log("Gather");
    }
}
