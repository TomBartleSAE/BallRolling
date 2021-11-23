using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathfindingAgent : MonoBehaviour
{
    private Grid2D grid2D;

    private List<Grid2D.Node> openNodes = new List<Grid2D.Node>();
    private List<Grid2D.Node> closedNodes = new List<Grid2D.Node>();

    public Vector2Int start, destination;

    public List<Grid2D.Node> path = new List<Grid2D.Node>();

    private void Start()
    {
        grid2D = FindObjectOfType<Grid2D>();
        //FindPath(start, destination);
    }

    public void FindPath(Vector2Int start, Vector2Int destination)
    {
        foreach (Grid2D.Node node in grid2D.nodes)
        {
            node.parent = null;
            node.gCost = 0;
            node.hCost = 0;
            node.fCost = 0;
        }
        openNodes.Clear();
        closedNodes.Clear();
        
        
        Grid2D.Node currentNode = grid2D.nodes[start.x, start.y];
        openNodes.Add(currentNode);

        // Loops until destination has been found
        while (currentNode != grid2D.nodes[destination.x, destination.y])
        {
            // Find neighbour with lowest f cost
            int lowestFCost = openNodes[0].fCost;
            foreach (Grid2D.Node node in openNodes)
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

            if (currentNode == grid2D.nodes[destination.x, destination.y])
            {
                break;
            }

            // Check all grid nodes +/- 1 in both directions (neighbours)
            for (int i = currentNode.coordinates.x - 1; i < currentNode.coordinates.x + 2; i++)
            {
                for (int j = currentNode.coordinates.y - 1; j < currentNode.coordinates.y + 2; j++)
                {
                    if (i >= grid2D.gridStartX && i <= grid2D.gridEndX && j >= grid2D.gridStartY && j <= grid2D.gridEndY)
                    {
                        Grid2D.Node neighbour = grid2D.nodes[i, j];
                        // Ignore neighbour if blocked or closed
                        if (neighbour.blocked || closedNodes.Contains(neighbour))
                        {
                            continue;
                        }

                        int neighbourDistance = currentNode.gCost +
                                                CalculateDistance(currentNode.coordinates, neighbour.coordinates);

                        if (neighbourDistance < neighbour.gCost || !openNodes.Contains(grid2D.nodes[i, j]))
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
        while (currentNode != grid2D.nodes[start.x, start.y])
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

    private void OnDrawGizmosSelected()
    {
        if (grid2D != null)
        {
            for (int x = grid2D.gridStartX; x < grid2D.gridEndX; x++)
            {
                for (int z = grid2D.gridStartY; z < grid2D.gridEndY; z++)
                {
                    if (grid2D.nodes[x, z] != null)
                    {
                        if (openNodes.Contains(grid2D.nodes[x, z]))
                        {
                            Gizmos.color = Color.green;
                            Gizmos.DrawCube(new Vector3(x, 0.5f, z), Vector3.one);
                        }
                        if (closedNodes.Contains(grid2D.nodes[x, z]))
                        {
                            Gizmos.color = Color.yellow;
                            Gizmos.DrawCube(new Vector3(x, 0.5f, z), Vector3.one);
                        }
                        if (path.Contains(grid2D.nodes[x,z]))
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawCube(new Vector3(x, 0.5f, z), Vector3.one);
                        }
                    }
                }
            }
        }
    }
}