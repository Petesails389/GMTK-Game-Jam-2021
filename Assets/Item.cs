using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public CardItem cardItem;

    public void TriggerCardItem(GameObject _person)
    {
        Person _p = _person.GetComponent<Person>();
        if (_p != null) cardItem.Trigger(_p);
    }
}
