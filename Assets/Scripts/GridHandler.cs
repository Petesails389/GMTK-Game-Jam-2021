using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    public static Grid grid;


    public static Vector2Int GridSize { get; private set; }

    void Awake()
    {
        GridSize = gridSize;
        grid = new Grid(gridSize);
        grid.CreateNodes();
        grid.CalculateNeighbours();
    }


}
