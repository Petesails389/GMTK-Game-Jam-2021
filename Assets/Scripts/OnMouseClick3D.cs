using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnMouseClick3D : MonoBehaviour
{
    public UnityEvent MouseDownEvent;
    void OnMouseDown()
    {
        MouseDownEvent.Invoke();
    }

}
