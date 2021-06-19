using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIRotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward*(Time.deltaTime*50));
    }
}
