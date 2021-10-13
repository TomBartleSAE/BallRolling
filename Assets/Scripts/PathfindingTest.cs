using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathfindingTest : MonoBehaviour
{
    public class Node
    {
        public Vector2 coordinates;
        public bool blocked;
        public int fCost;
        public int gCost;
        public int hCost;
        public Node parent;
    }

    public Vector2 gridSize;
    public Node[,] gridNodes;
    public LayerMask obstacles;

    private List<Node> openNodes = new List<Node>();
    private List<Node> closedNodes = new List<Node>();

    public Vector2 start, destination;

    public List<Node> path = new List<Node>();

    private void Start()
    {
        CalculateGrid();
        FindPath(start,destination);
    }

    public void CalculateGrid()
    {
        gridNodes = new Node[(int) gridSize.x, (int) gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int z = 0; z < gridSize.y; z++)
            {
                gridNodes[x, z] = new Node(); // Nodes need to be initialised before you can set variables
                gridNodes[x, z].coordinates = new Vector2(x, z);

                if (Physics.CheckBox(new Vector3(x, 0, z), Vector3.one, Quaternion.identity, obstacles))
                {
                    gridNodes[x, z].blocked = true;
                }
            }
        }
    }

    public void FindPath(Vector2 start, Vector2 destination)
    {
        Node currentNode = gridNodes[(int) start.x, (int) start.y];
        openNodes.Add(currentNode);
        
        // Loops until destination has been found
        while (currentNode != gridNodes[(int) destination.x, (int) destination.y])
        {
            // Find neighbour with lowest f cost
            int lowestFCost = openNodes[0].fCost;
            foreach (Node node in openNodes)
            {
                if (node.fCost <= lowestFCost)
                {
                    lowestFCost = node.fCost;
                    currentNode = node;
                }
            }
            
            // Close new current node
            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);

            if (currentNode == gridNodes[(int) destination.x, (int) destination.y])
            {
                break;
            }
            
            // Check all grid nodes +/- 1 in both directions (neighbours)
            for (int i = (int)currentNode.coordinates.x - 1; i < currentNode.coordinates.x + 2; i++)
            {
                for (int j = (int)currentNode.coordinates.y - 1; j < currentNode.coordinates.y + 2; j++)
                {
                    if (i > 0 && i < gridSize.x && j > 0 && j <  gridSize.y)
                    {
                        // Ignore neighbour if blocked or closed
                        if (gridNodes[i, j].blocked || closedNodes.Contains(gridNodes[i, j]))
                        {
                            continue;
                        }
                        
                        // TODO: Check if new path to neighbour is shorter
                        if (!openNodes.Contains(gridNodes[i, j]))
                        {
                            CalculateCosts(gridNodes[i,j].coordinates,destination);
                            gridNodes[i, j].parent = currentNode;
                            if (!openNodes.Contains(gridNodes[i, j]))
                            {
                                openNodes.Add(gridNodes[i, j]);
                            }
                        }
                    }
                }
            }
        }
        
        path.Clear();
        
        // Generate path based on best nodes' parents
        while (currentNode != gridNodes[(int) start.x, (int) start.y])
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
    }

    public void CalculateCosts(Vector2 point, Vector2 destination)
    {
        Node node = gridNodes[(int)point.x,(int)point.y];
        if (!node.blocked)
        {
            node.gCost = Mathf.RoundToInt(Vector2.Distance(point, node.coordinates) * 10f);

            Vector2 distance = destination - node.coordinates;
            distance = new Vector2(Mathf.Abs(distance.x), Mathf.Abs(distance.y)); // This removes any negative numbers
            // HACK? Surely there's a better way to find the distance to the end
            while (distance != Vector2.zero)
            {
                if (distance.x > 0 && distance.y > 0)
                {
                    node.hCost += 14;
                    distance -= Vector2.one;
                }
                else if (distance.x > 0)
                {
                    node.hCost += 10;
                    distance -= new Vector2(1, 0);
                }
                else if (distance.y > 0)
                {
                    node.hCost += 10;
                    distance -= new Vector2(0, 1);
                }
            }

            node.fCost = node.gCost + node.hCost;
        }
    }

    public void OnDrawGizmos()
    {
        if (gridNodes != null)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.y; z++)
                {
                    if (gridNodes[x, z] != null)
                    {
                        if (gridNodes[x, z].blocked)
                        {
                            Gizmos.color = Color.red;
                        }
                        else if (path.Contains(gridNodes[x, z]))
                        {
                            Gizmos.color = Color.blue;
                        }
                        else
                        {
                            Gizmos.color = Color.green;
                        }

                        Gizmos.DrawCube(new Vector3(x, 0, z), Vector3.one);
                    }
                }
            }
        }
    }
}