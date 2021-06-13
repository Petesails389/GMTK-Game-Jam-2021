using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class HasItemCheck : ConditionCheck
{
    public Item itemToCheck;

    public override bool Check(LoverDetails _details)
    {
        return (_details.item == itemToCheck);
    }
}
