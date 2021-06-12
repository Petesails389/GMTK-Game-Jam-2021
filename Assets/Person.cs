using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] Mover mover;
    [SerializeField] PersonAction action;
    [SerializeField] List<PersonFeature> personFeatures = new List<PersonFeature>();

    public void SetAction(PersonAction _action){
        action = _action;
        action.Trigger(this);
    }

    public void StopMoving(){
        mover.Stop();
    }
}
