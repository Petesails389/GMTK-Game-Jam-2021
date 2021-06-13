using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SharedLoveBar : ScriptableObject
{
    public float currentValue;
    public List<Lover> lovers = new List<Lover>();
}
