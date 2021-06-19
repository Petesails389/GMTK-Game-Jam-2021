using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedLoveBar
{
    public int currentValue = 5;

    public void SetValue(int newValue)
    {
        currentValue = newValue;
        UpdateHeartBar();
    }

    public void UpdateHeartBar()
    {
        PersonDetailUI.UpdateHeartBar(currentValue);
    }
}
