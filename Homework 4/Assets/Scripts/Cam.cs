using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Camera _camera;
    public float movementSpeed;
    public float zoomSpeed;
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
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && _camera.transform.position.y >= 15) 
            {
                _camera.orthographicSize -= 0.25f;
                transform.position -= new Vector3(0, zoomSpeed, 0) * Time.deltaTime;
            }
    
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && _camera.transform.position.y <= 75)
            {
                _camera.orthographicSize += 0.25f;
                transform.position += new Vector3(0, zoomSpeed, 0) * Time.deltaTime;
            }
    
            if (Input.GetKey(KeyCode.W))
            {
                transform.position -= new Vector3(0, 0, movementSpeed);
            }
    
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, 0, movementSpeed);
            }
    
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(movementSpeed, 0,0);
            }
    
            if (Input.GetKey(KeyCode.D))
            {
                transform.position -= new Vector3(movementSpeed,0,0);  
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.position = new Vector3(GameManager.Instance.player.transform.position.x,transform.position.y, GameManager.Instance.player.transform.position.z + 50);
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = 1;
            }
            else
            {
                movementSpeed = .5f;
            }
    }
}
