using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int gridLocation;
    public Vector3 worldPosition = Vector3.zero;
    public Dictionary<Node, NodeLink> neighbours = new Dictionary<Node, NodeLink>();
    public Node(Vector2Int _location)
    {
        gridLocation = _location;
    }

    public void AddNeighbour(Node _node, NodeLink _link)
    {
        neighbours.Add(_node, _link);
    }

    public NodeLink GetLink(Node _toNode)
    {
        return neighbours[_toNode];
    }

    public Node GetRandomNeighbour()
    {
        int _randomInt = Random.Range(0, neighbours.Count);
        List<Node> _nodes = new List<Node>(neighbours.Keys);
        return _nodes[_randomInt];
    }

    
}

