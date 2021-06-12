using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LoveConditionFeature : PersonFeature
{
    public PersonState isDoing;

    public bool CheckCondition(PersonState _state)
    {
        if (isDoing == null || _state == null) return false;
        return _state.Equals(isDoing);
    }
}
