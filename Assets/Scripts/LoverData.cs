using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lover Data Object")]
public class LoverData : ScriptableObject
{
    public List<Couple> couples = new List<Couple>();
}
