using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Renderer _renderer;
    
    public enum BotType {Player, Enemy, Neutral}
    public BotType botType;
    private string _ally;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _ally = botType == BotType.Enemy ? "Enemy" : "Player";
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_ally) && (botType == BotType.Neutral))
        {
            if (_agent == null)
            {
                _agent = gameObject.AddComponent<NavMeshAgent>();
                _renderer.material.color = other.GetComponent<Renderer>().material.color;
                tag = _ally;
                GameManager.Instance.AddUnit(_ally);
            }
        }
    }
}
