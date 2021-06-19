using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToGrid : MonoBehaviour
{
    public UnityEvent<Vector2Int> OnPlaceEvent;
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
                
                OnPlaceEvent.Invoke(currentPosition);
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
            Vector3 _worldPosition = hit.point;
            _worldPosition.x = Mathf.Round(_worldPosition.x);
            _worldPosition.y = Mathf.Round(_worldPosition.y);
            int _clampX = Mathf.Clamp((int)_worldPosition.x, 0, (GridHandler.GridSize.x - 1));
            int _clampY = Mathf.Clamp((int)_worldPosition.y, 0, (GridHandler.GridSize.y - 1));
            currentPosition = new Vector2Int(_clampX, _clampY);
            transform.position = GridHandler.grid.GetNode(_clampX, _clampY).worldPosition;
        }
    }
}
