using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CardSetPersonState : CardItemAction
{
    [SerializeField] PersonState stateToSet;
    public override void Trigger(Person _person)
    {
        _person.SetState(stateToSet);
    }
}
