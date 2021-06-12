using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Love Manager")]
public class LoveManager : ScriptableObject
{
    public static void CheckLove(GameObject other)
    {
        Debug.Log($"Love: {other.name}");
    }//

    public static void CheckEvent(GameObject other)
    {
        
        Debug.Log($"Event: {other.name}");
    }
}
