using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToGrid : MonoBehaviour
{
    public UnityEvent<GameObject> OnPlaceEvent;
    bool placed = true;
    Vector2Int currentPosition;
    void Update()
    {
        if (!placed)
        {
            FollowMouse();
            if (Input.GetMouseButtonDown(0))
            {
                placed = true;
                OnPlaceEvent.Invoke(gameObject);
            }
        }
        if(placed){
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                Debug.Log(hit.transform);
                if(hit.collider == gameObject.GetComponent<BoxCollider2D>()){
                    placed = false;
                }
            }
        }
    }

    void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.x = Mathf.Clamp(worldPosition.x, 0, GridHandler.GridSize.x - 1);
        worldPosition.y = Mathf.Clamp(worldPosition.y, 0, GridHandler.GridSize.y - 1);
        currentPosition = new Vector2Int(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));
        transform.position = new Vector3(currentPosition.x, currentPosition.y, worldPosition.z);
    }
}
