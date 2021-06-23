using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lover : MonoBehaviour
{
    public UnityEvent InLoveEvent;
    public UnityEvent DeniedEvent;
    public LoverDetails details;
    public Item item;
    public Lover other;
    public SharedLoveBar loveBar;
    public ParticleSystem likeFX;
    public ParticleSystem hateFX;
    Mover mov;
    public List<Node> path = new List<Node>();

    public void Init(int x, int y, LoverDetails _lover, SharedLoveBar _loveBar)
    {
        item = _lover.startItem;
        mov = GetComponent<Mover>();

        mov.startNodeLocation = new Vector2Int(x, y);
        details = _lover;
        loveBar = _loveBar;
        loveBar.SetValue(5);

        mov.SetSpeed(details.movementSpeed);
        mov.Init();
    }

    public void CheckLove(GameObject _other)
    {
        if (_other == other.gameObject)
        {
            foreach (Personality _pers in details.personalities)
            {
                if (details.personalities[0].Check(other.item))
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
    }

    public void CheckWorldObject(GameObject _worldObject)
    {
        Item _worldObjectItem = _worldObject.GetComponent<WorldObject>()?.item;
        print("checking world object");
        if (_worldObjectItem != null)
        {
            if (details.personalities[0].Check(_worldObjectItem))
            {
                if (details.personalities[0].feeling == Personality.EFeeling.Hate)
                {
                    hateFX.Play();
                    loveBar.SetValue(loveBar.currentValue - 1);
                }
                if (details.personalities[0].feeling == Personality.EFeeling.Love)
                {
                    if (!hasItem())
                    {
                        item = _worldObjectItem;
                        Destroy(_worldObject);
                    }
                    likeFX.Play();
                    loveBar.SetValue(loveBar.currentValue + 1);
                }
            }
        }
    }

    public bool hasItem()
    {
        return item != null;
    }

    public void DestroyLovers()
    {
        LoveManager.instance.DestroyLovers(this);
    }

    public void SetDetailWindow()
    {
        PersonDetailUI.Set(this);
    }
}
