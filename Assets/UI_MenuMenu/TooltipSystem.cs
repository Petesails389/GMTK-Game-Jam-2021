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
        Tooltip.instance.Show();
        Tooltip.instance.SetText(_header, _content);
        Tooltip.instance.transform.position = Input.mousePosition;
    }

    public void Hide()
    {
        Tooltip.instance.Hide();
    }

}
