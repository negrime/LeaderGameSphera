using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public GameObject target;
    [SerializeField]
    private int _cameraHeight;


    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, _cameraHeight, target.transform.position.z);
    }
}
