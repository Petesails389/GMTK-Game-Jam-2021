using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoveManager.instance.loverDetailsInGame[0].loveBar.SetValue(4);
            PersonDetailUI.instance.nameText.text = "fj";
        }
    }
}
