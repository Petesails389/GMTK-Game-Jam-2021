using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StateSpriteChanger : ScriptableObject
{
    public List<Sprite> sprites;
    public List<PersonState> states;

    public Sprite GetSprite(PersonState _state)
    {
        if (states.Contains(_state))
        {
            return sprites[states.IndexOf(_state)];
        }
        else
        {
            return null;
        }
    }
}
