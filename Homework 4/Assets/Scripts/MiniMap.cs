using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public GameObject target;


    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 50, target.transform.position.z);
    }
}
