using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PersonState : ScriptableObject
{
    public bool stopMoving;
    public bool danceMoves;
    public void Trigger(Person person)
    {
        if (stopMoving)
            person.StopMoving();

    }
}
