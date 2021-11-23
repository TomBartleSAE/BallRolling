using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3D : GridBase
{
    public class Node
    {
        public Vector3Int coordinates;
        public bool blocked;
        public int fCost;
        public int gCost;
        public int hCost;
        public Node parent;
    }

    [SerializeField] private Vector3Int gridStart;
    [SerializeField] private Vector3Int gridEnd;
    public Node[,,] nodes;
    [SerializeField] private LayerMask obstacles;

    [HideInInspector] public int gridStartX;
    [HideInInspector] public int gridEndX;
    [HideInInspector] public int gridStartY;
    [HideInInspector] public int gridEndY;
    [HideInInspector] public int gridStartZ;
    [HideInInspector] public int gridEndZ;

    [Range(0f,1f)]
    public float gridAlpha = 0.2f;

    private void Awake()
    {
        GenerateGrid();
    }

    public override void GenerateGrid()
    {
        base.GenerateGrid();

        // These calculations allow for grid end to have lower values than grid start
        // and prevent grid not spawning correctly
        // gridStartX = Mathf.Min(gridStart.x, gridEnd.x);
        // gridEndX = Mathf.Max(gridStart.x, gridEnd.x);
        // gridStartY = Mathf.Min(gridStart.y, gridEnd.y);
        // gridEndY = Mathf.Max(gridStart.y, gridEnd.y);
        // gridStartZ = Mathf.Min(gridStart.z, gridEnd.z);
        // gridEndZ = Mathf.Max(gridStart.z, gridEnd.z);

        nodes = new Node[gridEndX - gridStartX, gridEndY - gridStartY, gridEndZ - gridStartZ];

        for (int x = gridStartX; x < gridEndX; x++)
        {
            for (int y = gridStartY; y < gridEndY; y++)
            {
                for (int z = gridStartZ; z < gridEndZ; z++)
                {
                    nodes[x - gridStartX, y - gridStartY, z - gridStartZ] = new Node(); // Nodes need to be initialised before you can set variables
                    nodes[x - gridStartX, y - gridStartY, z - gridStartZ].coordinates = new Vector3Int(x, y, z);

                    if (Physics.CheckBox(new Vector3(x, y, z), Vector3.one, Quaternion.identity, obstacles))
                    {
                        nodes[x - gridStartX, y - gridStartY, z - gridStartZ].blocked = true;
                    }
                }
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        gridStartX = Mathf.Min(gridStart.x, gridEnd.x);
        gridEndX = Mathf.Max(gridStart.x, gridEnd.x);
        gridStartY = Mathf.Min(gridStart.y, gridEnd.y);
        gridEndY = Mathf.Max(gridStart.y, gridEnd.y);
        gridStartZ = Mathf.Min(gridStart.z, gridEnd.z);
        gridEndZ = Mathf.Max(gridStart.z, gridEnd.z);
        
        Vector3 centre = new Vector3((gridStartX + gridEndX) / 2, (gridStartY + gridEndY) / 2,
            (gridStartZ + gridEndZ) / 2);
        Vector3 size = new Vector3(gridEndX - gridStartX, gridEndY - gridStartY, gridEndZ - gridStartZ);
        Gizmos.DrawWireCube(centre, size);
        
        if (nodes != null)
        {
            for (int x = gridStartX; x < gridEndX; x++)
            {
                for (int y = gridStartY; y < gridEndY; y++)
                {
                    for (int z = gridStartZ; z < gridEndZ; z++)
                    {
                        if (nodes[x - gridStartX, y - gridStartY, z - gridStartZ] != null)
                        {
                            if (nodes[x - gridStartX, y - gridStartY, z - gridStartZ].blocked)
                            {
                                Gizmos.color = new Color(1, 0, 0, gridAlpha);
                            }
                            else
                            {
                                Gizmos.color = new Color(0, 1, 0, gridAlpha);
                            }

                            Gizmos.DrawCube(new Vector3(x, y, z), Vector3.one);
                        }
                    }
                }
            }
        }
    }
}