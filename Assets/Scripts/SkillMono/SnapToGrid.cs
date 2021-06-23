using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToGrid : MonoBehaviour
{

    [SerializeField] bool snapToLinks;
    NodeLink currentLink;

    Node currentNode;
    public Node CurrentNode { get => currentNode; }
    public NodeLink CurrentLink { get => currentLink; }

    void Update()
    {
        FollowMouse();
    }

    void FollowMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            currentNode = GridHandler.Grid.GetNodeFromPosition(hit.point);

            if (snapToLinks)
            {
                Vector2Int _neighbourPos = GridHandler.Grid.GetNeighbourLocationFromPosition(CurrentNode.gridLocation, hit.point);

                if (GridHandler.Grid.DoesExist(_neighbourPos))
                {
                    Node _neighbour = GridHandler.Grid.GetNode(_neighbourPos);
                    currentLink = CurrentNode.GetLink(_neighbour);
                    transform.position = GridHandler.Grid.GetLinkLocation(CurrentLink);
                }
            }
            else
            {
                transform.position = CurrentNode.worldPosition;
            }
        }
    }


}
