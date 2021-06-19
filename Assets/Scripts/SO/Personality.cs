using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personality : ScriptableObject
{
    public enum EFeeling
    {
        Love, Hate
    }

    public string personalityName;
    public string personalityTooltip;
    public Sprite icon;
    public EFeeling feeling;
    public abstract bool Check(Item item);
}
