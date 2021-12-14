using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class FollowPath : MonoBehaviour
    {
        public PathfindingAgent pathfinding;
        private PathfindingGrid.Node targetNode;
        public float followRange = 1f;
        public Rigidbody rb;
        private Vector2 direction;
        
        public void OnEnable()
        {
            targetNode = pathfinding.path[0];
        }

        public void Update()
        {
            if (pathfinding.path != null)
            {
                Vector2 position = new Vector2(transform.position.x, transform.position.z);
                direction = targetNode.coordinates - position;                

                if (Vector2.Distance(targetNode.coordinates, position) < followRange)
                {
                    // Finds the next node in the path
                    targetNode = pathfinding.path[pathfinding.path.IndexOf(targetNode) + 1];
                }
            }
        }

        public void FixedUpdate()
        {
            if (pathfinding.path != null)
            {
                rb.AddForce(new Vector3(direction.x, 0, direction.y) * 3, ForceMode.Force);
            }
        }
    }
}