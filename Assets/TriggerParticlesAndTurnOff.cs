using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParticlesAndTurnOff : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] float turnOffAfterSeconds;
    public void Trigger()
    {
        particle.Play();
        Invoke("TurnOff", turnOffAfterSeconds);
    }

    public void TurnOff(){
        particle.Stop();
    }

}
