using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PersonAction : ScriptableObject
{
    public void Trigger(Person person)
    {
        person.StopMoving();
    }
}
