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
        if (GameManager.Instance.enemyAmount >= GameManager.Instance.playerAmount)
        {
            Debug.Log("tobe pizda");
        }
        
    }
    
    private void Wait()
    {
        
    }
}
