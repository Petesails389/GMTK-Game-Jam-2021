using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    public static Grid grid;

    void Awake()
    {
        grid = new Grid(gridSize);
        grid.CreateNodes();
        grid.CalculateNeighbours();
    }


}
