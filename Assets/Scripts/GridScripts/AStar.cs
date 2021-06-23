using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public struct PathNode
    {
        public Node node; public Node fromNode; public int cost;
        public PathNode(Node _node, Node _fromNode, int _cost)
        {
            node = _node;
            fromNode = _fromNode;
            cost = _cost;
        }
    }


    //TODO fix ugly code
    public static List<Node> GetNewPath(Node fromNode, Node toNode)
    {
        int i = 0;
        List<Node> unhandledNodes = new List<Node>();

        Dictionary<Node, PathNode> nodeCosts = new Dictionary<Node, PathNode>();
        unhandledNodes.Add(fromNode);
        nodeCosts.Add(fromNode, new PathNode(fromNode, fromNode, 0));
        while (unhandledNodes.Count > 0)
        {
            i++;
            Node _currentNode = unhandledNodes[0];
            unhandledNodes.Remove(_currentNode);
            foreach (Node nb in _currentNode.neighbours.Keys)
            {
                if (nodeCosts.ContainsKey(nb)) continue;
                if (GridHandler.Grid.GetLink(nb, _currentNode).IsBlocked) continue;
                nodeCosts.Add(nb, new PathNode(nb, _currentNode, nodeCosts[_currentNode].cost + 1));
                unhandledNodes.Add(nb);
            }

            if (nodeCosts.ContainsKey(toNode)) break;
            if (i > 1000) break;
        }
        List<Node> path = new List<Node>();
        if (!nodeCosts.ContainsKey(toNode))
        {
            //TODO handle this further
            Debug.LogWarning("No possible path to node");
            return path;
        }
        Node _n = toNode;
        path.Add(_n);
        while (_n != fromNode)
        {
            i++;
            _n = nodeCosts[_n].fromNode;
            path.Add(_n);
            if (i > 10000) break;
        }
        path.Reverse();
        return path;

    }

}

