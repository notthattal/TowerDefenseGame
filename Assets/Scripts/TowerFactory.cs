using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab = default;
    [SerializeField] Transform towerParent = default;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towers.Count;

        if (baseWaypoint.towerWasPlaced == false && baseWaypoint.towerPrefab && numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else if (numTowers >= towerLimit)
        {
            MoveExistingTower(baseWaypoint);
        }
        else
        {
            print("Cannot place towers here");
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent;
        towers.Enqueue(newTower);

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.towerWasPlaced = true;
        baseWaypoint.isPlaceable = false;
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towers.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.baseWaypoint.towerWasPlaced = false;

        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towers.Enqueue(oldTower);

    }
}
