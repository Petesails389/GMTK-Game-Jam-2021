using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LoverDetails : ScriptableObject
{
    [Header("(Local) Stats and state")]
    public float Happyness;
    public Item item;
    [Range(5, 0.5f)] public float movementSpeed;

    public List<Node> path = new List<Node>();

    [Header("Traits")]
    public LoveInterest loveInterest;
}
