using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public Vector2Int currentPosition;

    public Item item;
    public void DestroyWorldObject()
    {
        Destroy(gameObject);
    }

}
