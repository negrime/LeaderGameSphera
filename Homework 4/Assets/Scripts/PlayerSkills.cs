using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [Header("Meteorite")] 
    private bool _meteorIsReady;
    public float meteorCooldownTime;
    private float _time;
    public GameObject meteorite;

    private void Start()
    {
        _time = meteorCooldownTime;
    }

    void Update()
    {
        _time += Time.deltaTime;
        UiManager.Ui.SetCooldown(_time / meteorCooldownTime);
        if (_time >= meteorCooldownTime)
        {
            _meteorIsReady = true;
        }
        if (Input.GetKeyDown(KeyCode.X) && _meteorIsReady)
        {
            Instantiate(meteorite, new Vector3(transform.position.x, transform.position.y + 60, transform.position.z), Quaternion.identity);
            _time = 0;
            _meteorIsReady = false;
        }
    }

 
}
