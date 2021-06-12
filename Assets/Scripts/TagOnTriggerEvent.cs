using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TagOnTriggerEvent : MonoBehaviour
{
    public List<UnityEvent<GameObject>> triggerEvents = new List<UnityEvent<GameObject>>();
    [SerializeField] List<string> tagList = new List<string>();

    void OnTriggerEnter2D(Collider2D _col)
    {
        foreach (string _tag in tagList)
        {
            if (_col.CompareTag(_tag))
            {
                triggerEvents[tagList.IndexOf(_tag)].Invoke(_col.gameObject);
            }
        }
    }

}
