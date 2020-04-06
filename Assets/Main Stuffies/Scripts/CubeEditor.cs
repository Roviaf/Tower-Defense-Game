﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    
    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnaptoGrid();
        UpdatestheLabel();
    }

    private void SnaptoGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }

    private void UpdatestheLabel()
    {

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string textLabel = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = textLabel;
        gameObject.name = "Cube " + textLabel;
    }
}