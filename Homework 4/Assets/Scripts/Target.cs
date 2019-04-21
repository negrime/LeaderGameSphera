using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{

    public Transform targetMarker;
    private int _mouseBtn = -1;



    private void UpdateTargets ( Vector3 targetPosition )
    {
      
  //    foreach(NavMeshAgent agent in GameManager.Instance.navAgents)
    //  {
      //   agent.destination = targetPosition;
      //}
    }

    private void Update ()
    {
        if(GetInput(ref _mouseBtn)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) 
            {
                Vector3 targetPosition = hitInfo.point;
              //  UpdateTargets(targetPosition);
                targetMarker.position = targetPosition;

                if (_mouseBtn == 1)
                {
                    GameManager.Instance.player.GetComponent<Bot>().agent.stoppingDistance =
                        Vector3.Distance(GameManager.Instance.player.transform.position, targetMarker.position) / 2;
                    GameManager.Instance.player.GetComponent<Bot>().agent.speed = 5;
                }
                else if (_mouseBtn == 0)
                {
                    GameManager.Instance.player.GetComponent<Bot>().agent.stoppingDistance = 1;
                    GameManager.Instance.player.GetComponent<Bot>().agent.speed = 10;
                }
           
                GameManager.Instance.SetTarget(targetMarker.position);


            }
        }
    }

    private bool GetInput(ref int btn)
    {
        if(Input.GetMouseButtonDown(0))
        {
            btn = 0;
            return true;
        }

        if(Input.GetMouseButtonDown(1))
        {
            btn = 1;
            return true;
        }



        return false;
    }

    private void OnDrawGizmos() 
    {
        Debug.DrawLine(targetMarker.position, targetMarker.position + Vector3.up * 5, Color.red);
    }
}
