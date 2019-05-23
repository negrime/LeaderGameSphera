using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] wayPoints;
    private int pointIndex;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pointIndex = Random.Range(0, wayPoints.Length);
        SetPoint();
    }


    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = gameObject.transform.TransformDirection(new Vector3(0, 0.2f, 1));
        Debug.DrawRay(transform.position, fwd * 5, Color.green);
 
        if (Physics.Raycast(gameObject.transform.position, fwd, out hit, 5.0f))//Есть пересечение
        {

            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position, fwd * 50, Color.red);
                
            }
        }

        if (agent.remainingDistance < 0.1f)
        {
            SetPoint();
        }
    }

    private void SetPoint()
    {
        agent.SetDestination(wayPoints[pointIndex].transform.position);
        pointIndex = Random.Range(0, wayPoints.Length);
    }
}
