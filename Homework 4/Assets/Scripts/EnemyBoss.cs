using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : MonoBehaviour
{
    public enum MyEnum
    {
        
    }
    [SerializeField]
    private NavMeshAgent _agent;

    [Header("Settings")] 
    public int minArmyAmount;
    
    private void Start()
    {
        if (_agent == null)
            _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(GameManager.Instance.enemyTarget);
        if (GameManager.Instance.enemyAmount > GameManager.Instance.playerAmount)
        {
            GameManager.Instance.enemyTarget = GameManager.Instance.player.transform.position;
        }
        else
        {
            float min = 0;
            Vector3 target = new Vector3();
            bool index = false;
            foreach (var i in GameManager.Instance.neutralVillages)
            {
                if (!index)
                {
                    min = Vector3.Distance(gameObject.transform.position, i.transform.position);
                    index = true;
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }
                else if (Vector3.Distance(gameObject.transform.position, i.transform.position) < min)
                {
                    min = Vector3.Distance(gameObject.transform.position, i.transform.position);
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }
            }

            GameManager.Instance.enemyTarget = target;
        }
        
    }
    
    private void Wait()
    {
        
    }
}
