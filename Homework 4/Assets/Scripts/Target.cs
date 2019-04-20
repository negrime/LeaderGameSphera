using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{

    public Transform targetMarker;

    private void Start ()
    {
        
    }

    private void UpdateTargets ( Vector3 targetPosition )
    {
      
  //    foreach(NavMeshAgent agent in GameManager.Instance.navAgents)
    //  {
      //   agent.destination = targetPosition;
      //}
    }

    private void Update ()
    {
        if(GetInput()) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) 
            {
                Vector3 targetPosition = hitInfo.point;
              //  UpdateTargets(targetPosition);
                targetMarker.position = targetPosition;
                GameManager.Instance.SetTarget(targetMarker.position);

            }
        }
    }

    private bool GetInput() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos() 
    {
        Debug.DrawLine(targetMarker.position, targetMarker.position + Vector3.up * 5, Color.red);
    }
}
