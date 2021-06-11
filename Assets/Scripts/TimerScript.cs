using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] Transform timerForeground;

    void Start()
    {
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        timerForeground.localScale = new Vector3(7*(time/100),0.25f,0);
        timerForeground.localPosition = new Vector3((7-timerForeground.localScale.x)/(-2),timerForeground.localPosition.y,0);
        if (time <= 0){
            //end the game
        };
    }
}
