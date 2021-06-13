using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooptipTriggerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TooltipSystem tooltipSystem;
    [SerializeField] string header;
    [SerializeField] [TextArea] string content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipSystem.Show(header, content);
    }

    void Update()
    {
        tooltipSystem.Update();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipSystem.Hide();
    }
}