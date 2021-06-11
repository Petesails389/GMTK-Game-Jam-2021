using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int gridLocation;
    public List<Node> neighbours = new List<Node>();

    public Node(Vector2Int _location)
    {
        gridLocation = _location;
    }
}

