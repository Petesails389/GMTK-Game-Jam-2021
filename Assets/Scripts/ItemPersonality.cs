using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Personalities/Item Personality")]
public class ItemPersonality : Personality
{
    public Item itemToCheck;

    public override bool Check(Item _item)
    {
        return (itemToCheck == _item);
    }
}
