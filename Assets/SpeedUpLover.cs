using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpLover : MonoBehaviour
{
    GameObject current;
    [SerializeField] float time;
    float originalSpeed;
    public void SpeedUp(GameObject _gameObject)
    {
        current = _gameObject;

        originalSpeed = _gameObject.GetComponent<Mover>().GetSpeed();
        StartCoroutine("SetSpeed");
    }

    IEnumerator SetSpeed()
    {
        current.GetComponent<Mover>().SetSpeed(0.5f);
        yield return new WaitForSeconds(time);
        current.GetComponent<Mover>().SetSpeed(originalSpeed);
    }

}
