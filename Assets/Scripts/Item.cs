using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public CardItemAction cardItemAction;

    public void TriggerCardItem(Person _person)
    {
        cardItemAction.Trigger(_person);
    }
}
