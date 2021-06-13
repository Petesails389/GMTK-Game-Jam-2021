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
    Mover mov;
    public void Init()
    {
        mov = GetComponent<Mover>();

        mov.SetSpeed(details.movementSpeed);
        mov.Init();
    }

    public void CheckLove(GameObject _other)
    {
        if (_other == other.gameObject)
        {
            if (details.loveInterest.conditionCheck.Check(other.details))
            {
                InLoveEvent.Invoke();
                Debug.Log("FallInLove");
                Invoke("DestroyLovers", 5);
            }
            else
            {
                DeniedEvent.Invoke();
            }
        }

    }

    public void CheckWorldObject(GameObject _worldObject)
    {
        print("checking world object");
        if (_worldObject.GetComponent<WorldObject>().item != null)
        {
            if (details.loveInterest.conditionCheck.CheckWorldObject(_worldObject.GetComponent<WorldObject>()))
            {
                if (details.loveInterest.feeling == LoveInterest.EFeeling.Hate)
                {
                    loveBar.SetValue(loveBar.currentValue - 1);
                }
                if (details.loveInterest.feeling == LoveInterest.EFeeling.Love)
                {
                    loveBar.SetValue(loveBar.currentValue + 1);
                }
            }
        }
    }

    public void DestroyLovers()
    {
        LoveManager.instance.DestroyLovers(this);
    }

    public void SetDetailWindow()
    {
        print(details);
        PersonDetailUI.Set(details);
    }
}
