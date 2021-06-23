using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid
{
    public readonly Vector2Int gridSize;
    public readonly Vector2 gridScaleToWorld;

    List<Node> nodes = new List<Node>();
    Dictionary<Vector2Int, Node> nodeDict = new Dictionary<Vector2Int, Node>();

    //Constructor methods
    public NodeGrid(Vector2Int _gridSize, Vector2 _gridScaleToWorld)
    {
        gridSize = _gridSize;
        CreateNodes();
        gridScaleToWorld = _gridScaleToWorld;
        SetWorldPositions();
        CalculateNeighbours();
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
    
    public void SetWorldPositions()
    {
        foreach (Node _node in nodes)
        {
            _node.worldPosition = new Vector3(gridScaleToWorld.x * _node.gridLocation.x, gridScaleToWorld.y * _node.gridLocation.y, 0);
        }
    }

    //Helper funcs
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

    public Vector2 GetLinkLocation(NodeLink _link)
    {
        return (Vector2)(_link.node2.gridLocation + _link.node1.gridLocation) / 2;
    }

    public Vector2Int GetNeighbourLocationFromPosition(Vector2Int _nodeLocation, Vector2 _position)
    {
        Vector2 _relativePos = new Vector2(_position.x - _nodeLocation.x, _position.y - _nodeLocation.y);

        //Check wether distance x is bigger then y, and set smaller to 0. 
        if (Mathf.Abs(_relativePos.x) > Mathf.Abs(_relativePos.y))
            _relativePos.y = 0;
        else
            _relativePos.x = 0;

        _relativePos.Normalize();

        return _nodeLocation + new Vector2Int((int)_relativePos.x, (int)_relativePos.y);
    }

    public Node GetNodeFromPosition(Vector2 _position)
    {
        int _x = (int)Mathf.Round(_position.x);
        int _y = (int)Mathf.Round(_position.y);

        Vector2Int _newPosition = new Vector2Int(_x, _y);
        _newPosition.Clamp(Vector2Int.zero, gridSize - Vector2Int.one);

        return GetNode(_newPosition);
    }
}
