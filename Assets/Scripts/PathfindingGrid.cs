using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGrid : MonoBehaviour
{
    public class Node
    {
        public Vector2Int coordinates;
        public bool blocked;
        public int fCost;
        public int gCost;
        public int hCost;
        public Node parent;
    }

    [SerializeField] private Vector2Int gridStart;
    [SerializeField] private Vector2Int gridEnd;
    public Node[,] nodes;
    [SerializeField] private LayerMask obstacles;

    [HideInInspector] public int gridStartX;
    [HideInInspector] public int gridEndX;
    [HideInInspector] public int gridStartY;
    [HideInInspector] public int gridEndY;

    private void Awake()
    {
        CalculateGrid();
    }

    public void CalculateGrid()
    {
        // These calculations allow for grid end to have lower values than grid start
        // and prevent grid not spawning correctly
        gridStartX = Mathf.Min(gridStart.x, gridEnd.x);
        gridEndX = Mathf.Max(gridStart.x, gridEnd.x);
        gridStartY = Mathf.Min(gridStart.y, gridEnd.y);
        gridEndY = Mathf.Max(gridStart.y, gridEnd.y);
        
        nodes = new Node[gridEndX - gridStartX, gridEndY - gridStartY];

        for (int x = gridStartX; x < gridEndX; x++)
        {
            for (int z = gridStartY; z < gridEndY; z++)
            {
                nodes[x, z] = new Node(); // Nodes need to be initialised before you can set variables
                nodes[x, z].coordinates = new Vector2Int(x, z);

                if (Physics.CheckBox(new Vector3(x, 0, z), Vector3.one, Quaternion.identity, obstacles))
                {
                    nodes[x, z].blocked = true;
                }
            }
        }
    }
    
    public void OnDrawGizmosSelected()
    {
        if (nodes != null)
        {
            for (int x = gridStartX; x < gridEndX; x++)
            {
                for (int z = gridStartY; z < gridEndY; z++)
                {
                    if (nodes[x, z] != null)
                    {
                        if (nodes[x, z].blocked)
                        {
                            Gizmos.color = Color.red;
                        }
                        else
                        {
                            Gizmos.color = Color.green;
                        }

                        Gizmos.DrawCube(new Vector3(x, 0.5f, z), Vector3.one);
                    }
                }
            }
        }
    }
}