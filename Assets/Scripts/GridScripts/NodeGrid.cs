using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid
{
    Vector2Int gridSize;
    List<Node> nodes = new List<Node>();
    Dictionary<Vector2Int, Node> nodeDict = new Dictionary<Vector2Int, Node>();

    public NodeGrid(Vector2Int _gridSize)
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

    public Node GetNode(int _x, int _y)
    {
        if (!nodeDict.ContainsKey(new Vector2Int(_x, _y)))
        {
            Debug.LogWarning($"Trying to get a node thats out does not exist ({_x},{_y}). Returning clamped value location node");
            _x = Mathf.Clamp(_x, 0, gridSize.x - 1);
            _y = Mathf.Clamp(_y, 0, gridSize.y - 1);
        }
        return nodeDict[new Vector2Int(_x, _y)];
    }

    public Node GetNode(Vector2Int _gridPos)
    {
        return GetNode(_gridPos.x, _gridPos.y);
    }

    public bool DoesExist(Vector2Int _gridPos)
    {
        return nodeDict.ContainsKey(_gridPos);
    }

    public Vector3 GetWorldPosition(Vector2Int _gridPos)
    {
        return GetNode(_gridPos).worldPosition;
    }

    public bool AreNeighbours(Node _node1, Node _node2)
    {
        return _node1.neighbours.ContainsKey(_node2);
    }

    public NodeLink GetLink(Node _node1, Node _node2)
    {
        return _node1.GetLink(_node2);
    }

    public NodeLink GetLink(Vector2Int _node1Loc, Vector2Int _node2Loc)
    {
        Node _node1 = GetNode(_node1Loc);
        Node _node2 = GetNode(_node2Loc);
        return GetLink(_node1, _node2);
    }

    public void CalculateNeighbours()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Node _node = GetNode(x, y);
                if (x != gridSize.x - 1)
                {
                    new NodeLink(_node, GetNode(x + 1, y));
                }
                if (y != gridSize.y - 1)
                {
                    new NodeLink(_node, GetNode(x, y + 1));
                }
            }
        }
    }

    public void SetWorldPositions(Vector2 scale)
    {
        foreach (Node _node in nodes)
        {
            _node.worldPosition = new Vector3(scale.x * _node.gridLocation.x, scale.y * _node.gridLocation.y, 0);
        }
    }
}
