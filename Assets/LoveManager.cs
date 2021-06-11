using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Love Manager")]
public class LoveManager : ScriptableObject
{
    public static void CheckLove(GameObject other)
    {
        if (other.CompareTag("Love"))
        {
            Debug.Log("YUS THEY LOVE EACH OTHER<3");
        }
    }
}
