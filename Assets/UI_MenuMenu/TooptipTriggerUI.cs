using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooptipTriggerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TooltipSystem tooltipSystem;
    [SerializeField] public string header;
    [SerializeField] [TextArea] public string content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipSystem.Show(header, content);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipSystem.Hide();
    }
}