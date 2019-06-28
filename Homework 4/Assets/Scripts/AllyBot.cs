using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyBot : MonoBehaviour
{
    private readonly Vector3[]  _directions = new[] {Vector3.forward, Vector3.left, Vector3.right, new Vector3(0.5f,0,0.5f), new Vector3(-0.5f,0,-0.5f) };
    public bool isSubjection;
    private Material _enemyMaterial;
    private NavMeshAgent _agent;
    public ParticleSystem explosion;


    void Start()
    {
        gameObject.GetComponent<Renderer>().material = _enemyMaterial;
        _agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        foreach (var i  in _directions)
        {
            if (gameObject.name != "EnemyBoss")
            {
                RaycastHit hit;
                Debug.DrawRay(transform.position, i * 50, Color.green);
 
                if(Physics.Raycast(gameObject.transform.position, i, out hit, 50.0f))
                {
    
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.DrawRay(transform.position, i * 50, Color.red);
                        _agent.SetDestination(hit.point);
                    }
                }
            }   
        }
        
        if (isSubjection)
        {
            _agent.SetDestination(GameManager.Instance.enemyTarget);
        }
        
    }
    
    public void Die(GameObject go)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(go);
    }
}
