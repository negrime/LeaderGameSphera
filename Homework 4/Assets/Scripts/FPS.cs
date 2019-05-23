using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text fpsTxt;
    public int fps;
    public float time;

    void Update()
    {
        fps++;
        time += Time.deltaTime;


        if (time >= 1)
        {
            if (fps < 30)
                fpsTxt.color = Color.red;
            else
                fpsTxt.color = Color.green;
           
            fpsTxt.text = fps.ToString();
            time = 0;
            fps = 0;
        }
    }
}
