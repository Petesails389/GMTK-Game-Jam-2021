using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SharedLoveBar
{
    public int currentValue;

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
