using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LoveInterest : ScriptableObject
{
    public enum EFeeling
    {
        Love, Hate
    }
    public Sprite icon;
    public EFeeling feeling;
    public ConditionCheck conditionCheck;

}
