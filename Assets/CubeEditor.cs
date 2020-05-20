using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] float gridSize = 10f;

    TextMesh textMesh;

    void Start()
    {

    }

    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;

        transform.position = snapPos;
    }
}
