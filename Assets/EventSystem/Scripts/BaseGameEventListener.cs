using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
    [SerializeField] private E gameEvent;

    public E GameEvent { get => gameEvent; set { gameEvent = value; } }
    [SerializeField] UER unityEventResponse;
    public void OnEventRaised(T item)
    {
        if (unityEventResponse != null){
            unityEventResponse.Invoke(item);
        }
    }

    void OnEnable()
    {
        if (gameEvent == null) return;
        GameEvent.RegisterListener(this);

    }

    void OnDisable()
    {
        if (gameEvent == null) return;
        GameEvent.UnregisterListener(this);

    }
}
