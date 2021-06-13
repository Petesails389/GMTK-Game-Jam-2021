using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;
    [SerializeField] TextMeshProUGUI header;
    [SerializeField] TextMeshProUGUI content;

    void Awake(){
        instance = this;
        gameObject.SetActive(false);
    }

    public void SetText(string _header, string _content)
    {
        header.text = _header;
        content.text = _content;
    }
}
