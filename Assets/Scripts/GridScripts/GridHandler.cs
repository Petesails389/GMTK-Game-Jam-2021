using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] Vector2 gridScaleToWorld;
    [SerializeField] Vector2Int gridSize;
    public static NodeGrid Grid;
    public static Vector2Int GridSize { get; private set; }
    public static Vector2 GridScale { get; private set; }

    void Awake()
    {
        CreateNewGrid();
    }

    void CreateNewGrid()
    {
        GridSize = gridSize;
        GridScale = gridScaleToWorld;
        Grid = new NodeGrid(gridSize, gridScaleToWorld);
    }
}
