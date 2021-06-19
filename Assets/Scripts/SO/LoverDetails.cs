using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LoverDetails : ScriptableObject
{
    public string loverName;

    [Header("Stats and state")]
    public float startHappyness;
    public Item startItem;
    [Range(5, 0.5f)] public float movementSpeed;

    [Header("Traits")]
    public List<Personality> personalities = new List<Personality>();

}
