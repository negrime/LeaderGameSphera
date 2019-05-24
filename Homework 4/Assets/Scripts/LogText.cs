using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class LogText : MonoBehaviour
{

    public float speed;
    void Update()
    {
        transform.Translate(speed * Vector3.up * Time.deltaTime, Space.World);
        Destroy(gameObject, 1.5f);
    }
}
