using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[CreateAssetMenu]
public class TooltipSystem : ScriptableObject
{
    
    [SerializeField] string objectName;


    public void Show(string _header, string _content)
    {
        Tooltip.instance.gameObject.SetActive(true);
        Tooltip.instance.SetText(_header, _content);
        Tooltip.instance.transform.position = Input.mousePosition;
    }

    public void Hide()
    {
        Tooltip.instance.gameObject.SetActive(false);
    }

    public void Update()
    {
        Tooltip.instance.transform.position = Input.mousePosition;
    }
}
