using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    // public static void CreateNoteLinkIndicator(Vector3 _location)
    // {
    //     Instantiate(instance.linkIndicator, _location, Quaternion.identity);
    // }
    // public static GridHandler instance;
    // [SerializeField] GameObject linkIndicator;
    [SerializeField] Vector2 gridScaleToWorld;
    [SerializeField] Vector2Int gridSize;
    public static NodeGrid grid;
    public static Vector2Int GridSize { get; private set; }

    public static Vector2 GridScale { get; private set; }

    void Awake()
    {
        // instance = this;
        CreateNewGrid();
    }

    void CreateNewGrid()
    {
        GridScale = gridScaleToWorld;
        GridSize = gridSize;
        grid = new NodeGrid(gridSize);
        grid.CreateNodes();
        grid.CalculateNeighbours();
        grid.SetWorldPositions(gridScaleToWorld);
    }
}
