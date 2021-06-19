using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;
    [SerializeField] TextMeshProUGUI header;
    [SerializeField] TextMeshProUGUI content;
    [SerializeField] GameObject panel;
    void Awake()
    {
        instance = this;
        Hide();
    }

    public void SetText(string _header, string _content)
    {
        header.text = _header;
        content.text = _content;
    }

    public void Show(){
        panel.gameObject.SetActive(true);
    }

    public void Hide(){
        panel.gameObject.SetActive(false);
    }
}
