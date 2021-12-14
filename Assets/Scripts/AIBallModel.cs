using System;
using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

public class AIBallModel : MonoBehaviour
{
    public Rigidbody rb;
    public PathfindingAgent agent;
    public float moveSpeed = 5f;
    public float detectRadius = 5f;
    public LayerMask ballLayer;
    public bool isBallNearby = false;
    public float closestBallSize;
    public float checkInterval = 1f;
    private float checkTimer;
    public Transform target;
    public LayerMask debrisLayer;
    
    public Collider FindClosestBall()
    {
        // All player and AI balls need to be on the Ball layer
        Collider[] nearbyBalls = Physics.OverlapSphere(transform.position, detectRadius, ballLayer);

        float closestDistance = Mathf.Infinity;
        Collider closestBall = null;
            
        foreach (Collider ball in nearbyBalls)
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);

            if (distance < closestDistance && ball != GetComponentInChildren<Collider>())
            {
                closestDistance = distance;
                closestBall = ball;
            }
        }

        if (closestBall != null)
        {
            closestBallSize = closestBall.GetComponentInParent<HealthModel>().myHealth;
            isBallNearby = true;
        }
        else
        {
            isBallNearby = false;
            return null;
        }
        
        return closestBall;
    }

    private void Update()
    {
        checkTimer -= Time.deltaTime;

        if (checkTimer <= 0)
        {
            Collider nearestBall = FindClosestBall();
            if (nearestBall != null)
            {
                target = FindClosestBall().transform;
            }
            checkTimer = checkInterval;
        }
    }

    public void Chase()
    {
        GetComponent<FollowPath>().enabled = false;
        Vector3 chaseDirection = target.position - transform.position;
        chaseDirection.y = 0;
        rb.AddForce(chaseDirection * moveSpeed, ForceMode.Force);
    }

    public void Flee()
    {
        GetComponent<FollowPath>().enabled = false;
        Vector3 fleeDirection = transform.position - target.position;
        fleeDirection.y = 0;
        rb.AddForce(fleeDirection * moveSpeed, ForceMode.Force);
    }

    public void Gather()
    {
        if (target == null)
        {
            // find debris
            Collider[] nearbyDebris = Physics.OverlapSphere(transform.position, 100, debrisLayer);

            float closestDistance = Mathf.Infinity;
            Collider closestDebris = null;
            
            foreach (Collider debris in nearbyDebris)
            {
                float distance = Vector3.Distance(transform.position, debris.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestDebris = debris;
                }
            }

            agent.FindPath(transform.position, closestDebris.transform.position);
            GetComponent<FollowPath>().enabled = true;
        }
    }
}
