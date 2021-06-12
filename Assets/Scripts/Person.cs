using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] StateSpriteChanger spriteChanger;
    [SerializeField] Mover mover;
    [SerializeField] PersonState state;
    [SerializeField] List<PersonFeature> personFeatures = new List<PersonFeature>();

    [SerializeField] PersonManager personManager;
    void Start()
    {
        SetState(state);
        personManager.AddPerson(this);


    }

    public void SetState(PersonState _action)
    {
        
        GetComponent<SpriteRenderer>().sprite = spriteChanger.GetSprite(_action);
        state = _action;
        state.Trigger(this);
        if (state.danceMoves)
        {
            StartCoroutine("FlipSprite");
        }
    }

    IEnumerator FlipSprite()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void StopMoving()
    {
        mover.Stop();
    }

    public void TriggerItem(GameObject _item)
    {
        _item.GetComponent<Item>()?.TriggerCardItem(this);
    }

    public void CheckLove(GameObject _other)
    {
        PersonState _otherState = _other.GetComponent<Person>().state;
        foreach (PersonFeature _feat in personFeatures)
        {
            Debug.Log(_feat.ToString());
            if (_feat is LoveConditionFeature)
            {
                LoveConditionFeature _con = _feat as LoveConditionFeature;
                if (_con.CheckCondition(_otherState))
                {
                    Debug.Log("FALL IN LOVE");
                }
            }
        }
    }
}
