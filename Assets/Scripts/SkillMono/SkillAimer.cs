using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillAimer : MonoBehaviour
{
    public UnityEvent<Vector2Int> OnPlaceEvent;
    public UnityEvent<NodeLink, Vector3> OnPlaceLinkEvent;
    [SerializeField] bool snapToLinks;

    public Sprite icon;
    public Skill skill;

    bool mouseOnMap = false;

    SnapToGrid gridSnapper;

    void Start()
    {
        gridSnapper = GetComponent<SnapToGrid>();
    }

    void Update()
    {
        Place();
    }

    public void Place()
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

            if (Input.GetMouseButtonDown(0) && mouseOnMap)
            {
                if (snapToLinks)
                {
                    OnPlaceLinkEvent.Invoke(gridSnapper.CurrentLink, transform.position);
                }
                else
                {
                    OnPlaceEvent.Invoke(gridSnapper.CurrentNode.gridLocation);
                }
                Destroy(gameObject);

            }
        }
    }

    public void Trigger(Vector2Int _loc)
    {
        skill.Trigger(_loc);
    }
}
