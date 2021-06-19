using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int gridLocation;
    public Vector3 worldPosition = Vector3.zero;
    public List<Node> neighbours = new List<Node>();
    public List<NodeLink> links = new List<NodeLink>();
    public Node(Vector2Int _location)
    {
        gridLocation = _location;
    }
}

