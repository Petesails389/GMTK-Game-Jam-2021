using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipShower3D : MonoBehaviour
{
    [SerializeField] TooltipSystem system;

    [SerializeField]
    string header;
    [SerializeField] [TextArea] string content;

    public void OnMouseEnter()
    {

        system.Show(header, content);
        Debug.Log($"Mouse Enters: {gameObject.name}");
    }

    public void OnMouseOver()
    {
        system.Update();
        Debug.Log($"Mouse Moves: {gameObject.name}");
    }

    public void OnMouseExit()
    {
        system.Hide();
        Debug.Log($"Mouse Exits: {gameObject.name}");
    }
}
