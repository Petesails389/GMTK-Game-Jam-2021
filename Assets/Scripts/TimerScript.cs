using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] Transform timerForeground;
    [SerializeField] bool timing;
    private GameObject[] players;
    private float currentTime;
    private float gfxWidth;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Love");
        currentTime = time;
        gfxWidth = timerForeground.localScale.x;
    }

    void Update()
    {
        if(timing){
            currentTime -= Time.deltaTime;
        }
        timerForeground.localScale = new Vector3(gfxWidth*(currentTime/time),0.25f,0);
        timerForeground.localPosition = new Vector3((7-timerForeground.localScale.x)/(-2),timerForeground.localPosition.y,0);
        if (currentTime <= 0){
            foreach(GameObject player in players){
                player.GetComponent<Person>().StopMoving();
            }
            timing = false;
        };
    }
}
