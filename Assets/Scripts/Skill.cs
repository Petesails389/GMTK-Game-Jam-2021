using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Skills/skill")]
public class Skill : ScriptableObject
{
    [SerializeField] public Sprite icon;
    [SerializeField] WorldObject worldObject;
    public virtual void Trigger(Vector2Int _loc)
    {
        WorldObject _newWorldObject = Instantiate(worldObject, GridHandler.grid.GetNode(_loc).worldPosition, Quaternion.identity);
        _newWorldObject.GetComponent<BoxCollider2D>().enabled = true;
        _newWorldObject.GetComponent<StraightMover>()?.StartMoving(_loc);
        _newWorldObject.currentPosition = _loc;
    }
}
