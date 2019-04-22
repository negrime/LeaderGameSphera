using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
   // public Transform target;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    

    void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                _camera.orthographicSize -= 0.25f;
                transform.position -= new Vector3(0, 25, 0) * Time.deltaTime;
            }
    
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                _camera.orthographicSize += 0.25f;
                transform.position += new Vector3(0, 25, 0) * Time.deltaTime;
            }
    
            if (Input.GetKey(KeyCode.W))
            {
                transform.position -= new Vector3(0, 0, 0.25f);
            }
    
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, 0, 0.25f);
            }
    
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(0.25f, 0,0);
            }
    
            if (Input.GetKey(KeyCode.D))
            {
                transform.position -= new Vector3(0.25f,0,0);  
            }
    }
    
}
