using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoverDataObject
{
    public string loverName;

    [Header("Stats and state")]
    public float startHappyness;
    public Item startItem;
    [Range(5, 0.5f)] public float movementSpeed;

    [Header("Traits")]
    public List<Personality> personalities = new List<Personality>();

}