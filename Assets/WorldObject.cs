using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public Vector2Int currentPosition;
    
    public void DestroyWorldObject(){
        Destroy(gameObject);
    }

}
