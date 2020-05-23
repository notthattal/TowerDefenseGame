using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    const int gridSize = 10;

    //public okay as is data class
    public bool wasExplored = false;
    public bool isPlaceable = true;
    public bool towerWasPlaced = false;
    public Waypoint exploredFrom = default;

    [SerializeField] public Tower towerPrefab = default;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int (
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
         );
    }

    public void SetTopColor(Color color)
    {
        try
        {
            MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
            topMeshRenderer.material.color = color;
        }
        catch { }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Cannot place tower here");
            }
        }
    }
}
