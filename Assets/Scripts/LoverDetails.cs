using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LoverDetails : ScriptableObject
{
    public string loverName;
    public Lover prefab;
    public SharedLoveBar loveBar;

    public LoverDetails soulMateDetails;
    public Lover soulMate;

    [Header("(Local) Stats and state")]
    public float Happyness;
    public Item item;
    [Range(5, 0.5f)] public float movementSpeed;

    public List<Node> path = new List<Node>();

    [Header("Traits")]
    public Personality personality;

    public void Init(int x, int y, Lover _lover)
    {
        loveBar.SetValue(5);
        Mover mov = _lover.GetComponent<Mover>();


        mov.startNodePosition = new Vector2Int(x, y);

        _lover.details = this;
        _lover.loveBar = loveBar;
        _lover.other = soulMate;
        _lover.Init();
    }

    

}
