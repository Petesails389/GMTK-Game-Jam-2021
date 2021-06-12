using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardItemAction : ScriptableObject
{
    public abstract void Trigger(Person _person);
}
