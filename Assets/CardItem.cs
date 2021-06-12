using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardItem : ScriptableObject
{
    [SerializeField] PersonAction actionToSet;
    public void Trigger(Person _person)
    {
        _person.SetAction(actionToSet);
    }
}
