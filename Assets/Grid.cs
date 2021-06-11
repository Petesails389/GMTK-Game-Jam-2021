using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    Vector2Int gridSize;
    List<Node> nodes = new List<Node>();
    Dictionary<Vector2Int, Node> nodeDict = new Dictionary<Vector2Int, Node>();

    public Grid(Vector2Int _gridSize)
    {
        gridSize = _gridSize;
    }

    public void CreateNodes()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Node _newNode = new Node(new Vector2Int(x, y));
                nodes.Add(_newNode);
                nodeDict.Add(new Vector2Int(x, y), _newNode);
            }
        }
    }

    public Node GetNode(int x, int y)
    {
        return nodeDict[new Vector2Int(x, y)];
    }

    public void CalculateNeighbours()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Node _node = GetNode(x, y);
                if (x != 0) _node.neighbours.Add(GetNode(x - 1, y));
                if (x != gridSize.x - 1) _node.neighbours.Add(GetNode(x + 1, y));
                if (y != 0) _node.neighbours.Add(GetNode(x, y - 1));
                if (y != gridSize.y - 1) _node.neighbours.Add(GetNode(x, y + 1));
            }
        }
    }
}
