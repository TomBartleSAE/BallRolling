using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathfindingTest : MonoBehaviour
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

    public Vector2Int gridSize;
    public Node[,] gridNodes;
    public LayerMask obstacles;

    private List<Node> openNodes = new List<Node>();
    private List<Node> closedNodes = new List<Node>();

    public Vector2Int start, destination;

    public List<Node> path = new List<Node>();

    private void Awake()
    {
        CalculateGrid();
        FindPath(start, destination);
    }

    public void CalculateGrid()
    {
        gridNodes = new Node[(int) gridSize.x, (int) gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int z = 0; z < gridSize.y; z++)
            {
                gridNodes[x, z] = new Node(); // Nodes need to be initialised before you can set variables
                gridNodes[x, z].coordinates = new Vector2Int(x, z);

                if (Physics.CheckBox(new Vector3(x, 0, z), Vector3.one, Quaternion.identity, obstacles))
                {
                    gridNodes[x, z].blocked = true;
                }
            }
        }
    }

    public void FindPath(Vector2Int start, Vector2Int destination)
    {
        Node currentNode = gridNodes[start.x, start.y];
        openNodes.Add(currentNode);

        // Loops until destination has been found
        while (currentNode != gridNodes[destination.x, destination.y])
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

            if (currentNode == gridNodes[destination.x, destination.y])
            {
                break;
            }

            // Check all grid nodes +/- 1 in both directions (neighbours)
            for (int i = currentNode.coordinates.x - 1; i < currentNode.coordinates.x + 2; i++)
            {
                for (int j = currentNode.coordinates.y - 1; j < currentNode.coordinates.y + 2; j++)
                {
                    if (i > 0 && i < gridSize.x && j > 0 && j < gridSize.y)
                    {
                        Node neighbour = gridNodes[i, j];
                        // Ignore neighbour if blocked or closed
                        if (neighbour.blocked || closedNodes.Contains(neighbour))
                        {
                            continue;
                        }

                        int neighbourDistance = currentNode.gCost +
                                                CalculateDistance(currentNode.coordinates, neighbour.coordinates);

                        if (neighbourDistance < neighbour.gCost || !openNodes.Contains(gridNodes[i, j]))
                        {
                            neighbour.gCost = neighbourDistance;
                            neighbour.hCost = CalculateDistance(neighbour.coordinates, destination);
                            neighbour.fCost = neighbour.gCost + neighbour.hCost;
                            
                            neighbour.parent = currentNode;
                            if (!openNodes.Contains(neighbour))
                            {
                                openNodes.Add(neighbour);
                            }
                        }
                    }
                }
            }
        }

        path.Clear();

        // Generate path based on best nodes' parents
        while (currentNode != gridNodes[start.x, start.y])
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
    }

    public int CalculateDistance(Vector2Int start, Vector2Int end)
    {
        Vector2Int distance = end - start;
        distance = new Vector2Int(Mathf.Abs(distance.x), Mathf.Abs(distance.y)); // This removes any negative numbers
        if (distance.x > distance.y)
        {
            return distance.y * 14 + 10 * (distance.x - distance.y);
        }

        return distance.x * 14 + 10 * (distance.y - distance.x);
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

                        Gizmos.DrawCube(new Vector3(x, 0.5f, z), Vector3.one);
                    }
                }
            }
        }
    }
}