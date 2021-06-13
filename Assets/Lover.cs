using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lover : MonoBehaviour
{
    public LoverDetails details;
    public Lover other;
    public SharedLoveBar loveBar;
    void Awake()
    {
        GetComponent<Mover>().SetSpeed(details.movementSpeed);
    }
    public void CheckLove(GameObject _other)
    {
        if (_other == other.gameObject)
        {
            if (details.loveInterest.conditionCheck.Check(other.details))
            {
                Debug.Log("FallInLove");
            }
        }
        // PersonState _otherState = _other.GetComponent<Person>().state;
        // foreach (PersonFeature _feat in personFeatures)
        // {
        //     Debug.Log(_feat.ToString());
        //     if (_feat is LoveConditionFeature)
        //     {
        //         LoveConditionFeature _con = _feat as LoveConditionFeature;
        //         if (_con.CheckCondition(_otherState))
        //         {
        //             Debug.Log("FALL IN LOVE");
        //         }
        //     }
        // }
    }
}
