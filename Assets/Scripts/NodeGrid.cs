using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid
{
    Vector2Int gridSize;
    List<Node> nodes = new List<Node>();
    Dictionary<Vector2Int, Node> nodeDict = new Dictionary<Vector2Int, Node>();
    Dictionary<Vector2, NodeLink> linkDict = new Dictionary<Vector2, NodeLink>();

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
            _x = Mathf.Clamp(_x, 0, gridSize.x-1);
            _y = Mathf.Clamp(_y, 0, gridSize.y-1);
        }
        return nodeDict[new Vector2Int(_x, _y)];
    }

    public Node GetNode(Vector2Int _gridPos)
    {
        return GetNode(_gridPos.x, _gridPos.y);
    }

    public bool doesExist(Vector2Int _gridPos)
    {
        return nodeDict.ContainsKey(_gridPos);
    }

    public Vector3 GetWorldPosition(Vector2Int _gridPos)
    {
        return GetNode(_gridPos).worldPosition;
    }

    public bool areNeighbours(Node _node1, Node _node2)
    {
        return _node1.neighbours.Contains(_node2);
    }

    public NodeLink GetLink(Node _node1, Node _node2)
    {
        Vector2 _dir = _node2.gridLocation - _node1.gridLocation;
        if (!areNeighbours(_node1, _node2))
        {
            _dir = _dir.normalized;
            Debug.LogWarning($"Trying to get link from nodes that aren't neighbours{_node1.gridLocation},{_node2.gridLocation}. Returning link to node in same direction {_dir}");

        }
        Vector2 _loc = _node1.gridLocation + _dir * 0.5f;
        if (!linkDict.ContainsKey(_loc))
        {
            Debug.LogError($"Link with this location {_loc}, is not in the dictionary!!");
        }
        return linkDict[_loc];
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
                if (x != 0)
                {
                    _node.neighbours.Add(GetNode(x - 1, y));

                    Vector2 _linkLoc = new Vector2(x - 0.5f, y);
                    if (!linkDict.ContainsKey(_linkLoc))
                    {
                        NodeLink _newLink = new NodeLink(_linkLoc, _node, GetNode(x - 1, y));
                        linkDict.Add(_linkLoc, _newLink);
                    }
                }
                if (x != gridSize.x - 1)
                {
                    _node.neighbours.Add(GetNode(x + 1, y));
                    Vector2 _linkLoc = new Vector2(x + 0.5f, y);
                    if (!linkDict.ContainsKey(_linkLoc))
                    {
                        NodeLink _newLink = new NodeLink(_linkLoc, _node, GetNode(x + 1, y));
                        linkDict.Add(_linkLoc, _newLink);
                    }
                }
                if (y != 0)
                {
                    _node.neighbours.Add(GetNode(x, y - 1));
                    Vector2 _linkLoc = new Vector2(x, y - 0.5f);
                    if (!linkDict.ContainsKey(_linkLoc))
                    {
                        NodeLink _newLink = new NodeLink(_linkLoc, _node, GetNode(x, y - 1));
                        linkDict.Add(_linkLoc, _newLink);
                    }
                }
                if (y != gridSize.y - 1)
                {
                    _node.neighbours.Add(GetNode(x, y + 1));

                    Vector2 _linkLoc = new Vector2(x, y - 0.5f);
                    if (!linkDict.ContainsKey(_linkLoc))
                    {
                        NodeLink _newLink = new NodeLink(_linkLoc, _node, GetNode(x, y + 1));
                        linkDict.Add(_linkLoc, _newLink);
                    }
                }
            }

        }
        Debug.Log(GetLink(GetNode(3, 3), GetNode(3, 2)));
    }

    public void SetWorldPositions(Vector2 scale)
    {
        foreach (Node _node in nodes)
        {
            _node.worldPosition = new Vector3(scale.x * _node.gridLocation.x, scale.y * _node.gridLocation.y, 0);
        }
    }
}
