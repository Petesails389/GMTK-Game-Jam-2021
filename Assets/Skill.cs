using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] GameObject worldObject;
    Vector2Int currentGridLocation;
    public virtual void Trigger(Vector2Int location)
    {
        currentGridLocation = location;
        Instantiate(worldObject, GridHandler.grid.GetNode(location).worldPosition,Quaternion.identity);
    }
}
