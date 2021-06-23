using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLink
{
    bool isBlocked = false;

    public bool IsBlocked => isBlocked;
    public Vector2 location;
    public Node node1;
    public Node node2;

    public NodeLink(Node _node1, Node _node2)
    {
        node1 = _node1;
        node2 = _node2;
        node1.AddNeighbour(_node2, this);
        node2.AddNeighbour(_node1, this);
        // Debug.Log($"New Link {_loc}");
        // GridHandler.CreateNoteLinkIndicator(_loc);
    }

    public void SetBlocked(bool _blocked)
    {
        isBlocked = _blocked;
    }
}
