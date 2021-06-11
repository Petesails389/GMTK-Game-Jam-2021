using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnTriggerEnterEvent : MonoBehaviour
{
    public UnityEvent<GameObject> triggerEvent;
    void OnTriggerEnter2D(Collider2D col)
    {
        triggerEvent.Invoke(col.gameObject);
    }
}
