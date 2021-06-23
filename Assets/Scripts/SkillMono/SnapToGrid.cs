using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToGrid : MonoBehaviour
{
    public UnityEvent<Vector2Int> OnPlaceEvent;
    public UnityEvent<NodeLink, Vector3> OnPlaceLinkEvent;

    [SerializeField] bool snapToLinks;
    NodeLink currentLink;
    bool placed = false;
    bool mouseOnMap = false;
    Vector2Int currentPosition;
    void Update()
    {
        if (!placed)
        {
            FollowMouse();
            if (Input.GetMouseButtonDown(0) && mouseOnMap)
            {
                placed = true;
                if (snapToLinks)
                {
                    OnPlaceLinkEvent.Invoke(currentLink, transform.position);
                }
                else
                {
                    OnPlaceEvent.Invoke(currentPosition);
                }
            }
        }
    }


    void FollowMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        mouseOnMap = false;
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Map"))
            {
                mouseOnMap = true;
            }
            else
            {
                mouseOnMap = false;
            }

            //TODO Fix horrible code
            Vector2 _worldLocation = hit.point;

            //TODO create V2 Extension (RoundAndClamp)
            _worldLocation.x = Mathf.Round(_worldLocation.x);
            _worldLocation.y = Mathf.Round(_worldLocation.y);

            int _clampX = Mathf.Clamp((int)_worldLocation.x, 0, (GridHandler.GridSize.x - 1));
            int _clampY = Mathf.Clamp((int)_worldLocation.y, 0, (GridHandler.GridSize.y - 1));

            currentPosition = new Vector2Int(_clampX, _clampY);

            if (snapToLinks)
            {
                Node _closestNode = GridHandler.grid.GetNode(currentPosition);
                Vector2 _relativeMouse = hit.point - currentPosition;

                if (Mathf.Abs(_relativeMouse.x) > Mathf.Abs(_relativeMouse.y))
                {
                    _relativeMouse.y = 0;
                    //TODO: Normalized?
                    _relativeMouse.x = _relativeMouse.x < 0 ? -1 : 1;
                }
                else
                {
                    _relativeMouse.x = 0;
                    _relativeMouse.y = _relativeMouse.y < 0 ? -1 : 1;
                }

                //TODO: Remove _tmp
                Vector2 _tmp = _closestNode.gridLocation + _relativeMouse;
                Vector3 _relativeWorldPosition = new Vector3(_relativeMouse.x, _relativeMouse.y) / 2;
                Vector2Int _neighbourPos = new Vector2Int((int)_tmp.x, (int)_tmp.y);

                if (GridHandler.grid.DoesExist(_neighbourPos))
                {
                    currentLink = _closestNode.GetLink(GridHandler.grid.GetNode(_neighbourPos));
                    transform.position = GridHandler.grid.GetNode(currentPosition).worldPosition + _relativeWorldPosition;
                }
            }
            else
            {
                transform.position = GridHandler.grid.GetNode(currentPosition).worldPosition;
            }

        }
    }
}
