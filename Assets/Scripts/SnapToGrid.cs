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
            // float _x = _worldPosition.x - (_worldPosition.x % (0.5f * GridHandler.GridScale.x));
            // float _y = _worldPosition.y - (_worldPosition.y % (0.5f * GridHandler.GridScale.y));
            // Vector2 _gridPosition = new Vector2(_x, _y);
            // transform.position = new Vector3(_gridPosition.x, 0, _gridPosition.y);

        }

        // worldPosition.x -= (worldPosition.x % 0.5f);
        // worldPosition.z -= (worldPosition.z % 0.5f);
        // worldPosition.x = Mathf.Clamp(worldPosition.x, 0, (GridHandler.GridSize.x - 1) * GridHandler.GridScale.x);
        // worldPosition.z = Mathf.Clamp(worldPosition.y, 0, (GridHandler.GridSize.y - 1) * GridHandler.GridScale.y);
        // print(worldPosition);
        // // currentPosition = new Vector2Int(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.z));
    }
}
