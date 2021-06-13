using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lover : MonoBehaviour
{
    public UnityEvent InLoveEvent;
    public UnityEvent DeniedEvent;
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
                InLoveEvent.Invoke();
                Debug.Log("FallInLove");
            }
            else
            {
                DeniedEvent.Invoke();
            }
        }

    }
}
