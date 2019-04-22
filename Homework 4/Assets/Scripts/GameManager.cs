using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> villages;
    public int enemyAmount;
    public int playerAmount;
    public int totalSum;
    public Transform targetMarker;

    public GameObject player;
//    public List<NavMeshAgent> navAgents;
    public Vector3 target;

    private void Awake()
    {
        target = GameObject.Find("Player").transform.position;
        Instance = this;
    }

    void Update()
    {
        totalSum = playerAmount + enemyAmount;
    }

    public void AddUnit(string ally)
    {
        if (ally.Equals("Enemy"))
        {
            enemyAmount++;
        }
        else
        {
            playerAmount++;
        }
    }

    public void RemoveUnit(string ally)
    {
        if (ally.Equals("Enemy") && enemyAmount != 0)
        {
            enemyAmount--;
        }
        else if (playerAmount != 0)
        {
            playerAmount--;
        }
    }
    

    public void SetTarget(Vector3 target)
    {
        this.target = target;
        targetMarker.position = target;
    }
}
