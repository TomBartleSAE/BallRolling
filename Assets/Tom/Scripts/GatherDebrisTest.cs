using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GatherDebrisTest : MonoBehaviour
{
    private PathfindingAgent agent;
    private Rigidbody rb;
    
    public Transform target;
    public LayerMask debrisLayer;
    public float speed = 1f;

    private PathfindingGrid.Node currentNode;

    public float radius = 25f;

    private void Awake()
    {
        agent = GetComponent<PathfindingAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target == null)
        {
            Collider[] nearbyDebris = Physics.OverlapSphere(transform.position, radius, debrisLayer);

            float bestDistance = Mathf.Infinity;
            Collider closestDebris = null;
            foreach (Collider debris in nearbyDebris)
            {
                float distance = Vector3.Distance(transform.position, debris.transform.position);
                if (distance < bestDistance)
                {
                    closestDebris = debris;
                    bestDistance = distance;
                }
            }

            if (closestDebris != null)
            {
                target = closestDebris.transform;
            }

            Vector2Int pathStart = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
            Vector2Int pathEnd = new Vector2Int(Mathf.RoundToInt(target.position.x), Mathf.RoundToInt(target.position.z));
            agent.FindPath(pathStart,pathEnd);
            currentNode = agent.path.Last();
        }

        Vector2 position = new Vector2(transform.position.x, transform.position.z);
        Vector2 direction = (currentNode.coordinates - position).normalized;
        rb.AddForce(new Vector3(direction.x,0,direction.y) * (speed / Vector2.Distance(currentNode.coordinates,position)), ForceMode.Force);

        if (Vector2.Distance(currentNode.coordinates, position) < 2f && currentNode != agent.path.First())
        {
            currentNode = agent.path[agent.path.IndexOf(currentNode) - 1];
        }

        if (Vector2.Distance(position, new Vector2(target.position.x, target.position.z)) < 0.5f)
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}