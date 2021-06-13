using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToGrid : MonoBehaviour
{
    public UnityEvent<GameObject> OnPlaceEvent;
    bool placed = false;

    Vector2Int currentPosition;
    void Update()
    {
        if (!placed)
        {
            FollowMouse();
            if (Input.GetMouseButtonDown(0))
            {
                // placed = true;
                // OnPlaceEvent.Invoke(gameObject);
            }
        }
    }


    void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 _worldPosition = hit.point;
            _worldPosition.x = Mathf.Round(_worldPosition.x);
            _worldPosition.z = Mathf.Round(_worldPosition.z);
            int _clampX = Mathf.Clamp((int)_worldPosition.x,0,(GridHandler.GridSize.x - 1));
            int _clampY = Mathf.Clamp((int)_worldPosition.z,0,(GridHandler.GridSize.y - 1));
            transform.position =GridHandler.grid.GetNode(_clampX,_clampY).worldPosition;
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
