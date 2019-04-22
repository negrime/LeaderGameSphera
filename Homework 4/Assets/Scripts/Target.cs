using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{

   
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
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            float min = 0;
            Vector3 target = new Vector3();
            bool index = false;
            foreach (var i in GameManager.Instance.villages)
            {
                if (!index)
                {
                    min = Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position);
                    index = true;
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }
                else if (Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position) < min)
                {
                    min = Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position);
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }

            }       
            GameManager.Instance.SetTarget(target);
            
        }
        if(GetInput(ref _mouseBtn)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) 
            {
                Vector3 targetPosition = hitInfo.point;
              //  UpdateTargets(targetPosition);
               // targetMarker.position = targetPosition;

                if (_mouseBtn == 1)
                {
                    GameManager.Instance.player.GetComponent<Bot>().agent.stoppingDistance =
                    Vector3.Distance(GameManager.Instance.player.transform.position, targetPosition) * 0.6f;
                   // GameManager.Instance.player.GetComponent<Bot>().agent.speed = 5;
                }
                else if (_mouseBtn == 0)
                {
                    GameManager.Instance.player.GetComponent<Bot>().agent.stoppingDistance = 1;
                    GameManager.Instance.player.GetComponent<Bot>().agent.speed = 10;
                }
           
                GameManager.Instance.SetTarget(targetPosition);
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
      //  Debug.DrawLine(, targetMarker.position + Vector3.up * 5, Color.red);
    }
}
