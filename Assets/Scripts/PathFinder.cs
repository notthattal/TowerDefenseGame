using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private List<Waypoint> path = new List<Waypoint>();

    [SerializeField] Waypoint startWaypoint = default, endWaypoint = default;

    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint centerWaypoint = default;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        SetAsPath(endWaypoint);

        Waypoint previousWaypoint = endWaypoint.exploredFrom;

        while (previousWaypoint != startWaypoint)
        {
            SetAsPath(previousWaypoint);
            previousWaypoint = previousWaypoint.exploredFrom;
        }

        SetAsPath(startWaypoint);

        path.Reverse();

    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            centerWaypoint = queue.Dequeue();
            centerWaypoint.wasExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();  
        }
 
    }

    private void HaltIfEndFound()
    {
        if (centerWaypoint == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = direction + centerWaypoint.GetGridPos();
            if (grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (!neighbor.wasExplored && !queue.Contains(neighbor))
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = centerWaypoint;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

}
