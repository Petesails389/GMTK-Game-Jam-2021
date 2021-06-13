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

    public NodeLink(Vector2 _loc, Node _node1, Node _node2)
    {
        foreach (NodeLink _link in _node1.links)
        {
            if (_link.location == _loc)
            {
                return;
            }
        }
        foreach (NodeLink _link in _node2.links)
        {
            if (_link.location == _loc)
            {
                return;
            }
        }
        location = _loc;
        node1 = _node1;
        node2 = _node2;
        node1.links.Add(this);
        node2.links.Add(this);
        
        // Debug.Log($"New Link {_loc}");
        // GridHandler.CreateNoteLinkIndicator(_loc);
    }

    public void SetBlocked(bool _blocked)
    {
        isBlocked = _blocked;
    }
}
