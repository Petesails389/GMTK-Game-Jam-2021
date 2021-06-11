using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [SerializeField] Transform guy;
    Grid grid;
    void Start()
    {
        grid = new Grid(gridSize);
        grid.CreateNodes();
        grid.CalculateNeighbours();

        print(grid.GetNode(0, 1).neighbours.Count);
        StartCoroutine("MoveBetweenNodes");
    }

    IEnumerator MoveBetweenNodes()
    {
        Vector2Int _pos = new Vector2Int(0, 0);
        for (int i = 0; i < 10; i++)
        {
            Node _node = grid.GetNode(_pos.x, _pos.y);
            int _randomInt = Random.Range(0, _node.neighbours.Count);
            _pos = _node.neighbours[_randomInt].gridLocation;
            print(_pos);
            guy.position = ((Vector3Int)_pos);
            yield return new WaitForSeconds(1f);
        }

    }
}
