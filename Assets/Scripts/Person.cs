using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] Mover mover;
    [SerializeField] PersonState state;
    [SerializeField] PersonManager personManager;
    
    void Start()
    {
        SetState(state);
        personManager.AddPerson(this);


    }

    public void SetState(PersonState _action)
    {
        state = _action;
        state.Trigger(this);
    }


    public void StopMoving()
    {
        mover.StopMoving();
    }

    public void TriggerItem(GameObject _item)
    {
        // _item.GetComponent<Item>()?.TriggerCardItem(this);
    }

    
}
