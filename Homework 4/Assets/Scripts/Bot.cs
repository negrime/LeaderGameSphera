using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Renderer _renderer;
    public Transform _player;
    
    public enum BotType {Player, Enemy, Neutral}
    public BotType botType;
    private string _ally;
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _renderer = GetComponent<Renderer>();
        _ally = botType == BotType.Enemy ? "Enemy" : "Player";

        if (botType != BotType.Neutral)
        {
            GameManager.Instance.AddUnit(tag);
            _agent = GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        if (botType == BotType.Enemy)
        {
            _agent.SetDestination(_player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (botType == BotType.Neutral)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                _renderer.material.color = other.gameObject.GetComponent<Renderer>().material.color;
                gameObject.AddComponent<NavMeshAgent>();
                tag = other.gameObject.tag;
                botType = BotType.Player;
                GameManager.Instance.AddUnit(tag);
            }
        }

        if (botType == BotType.Enemy)
        {
            if (other.gameObject.tag.Equals("Player") && (GameManager.Instance.playerAmount > GameManager.Instance.enemyAmount))
            {
                _renderer.material.color = other.gameObject.GetComponent<Renderer>().material.color;
                gameObject.AddComponent<NavMeshAgent>();
                tag = other.gameObject.tag;
                botType = BotType.Player;
            }
        }

        if (botType == BotType.Player)
        {
            if (other.gameObject.tag.Equals("Enemy") && (GameManager.Instance.playerAmount < GameManager.Instance.enemyAmount) && gameObject.name != "Player")
            {
                _renderer.material.color = other.gameObject.GetComponent<Renderer>().material.color;
                gameObject.AddComponent<NavMeshAgent>();
                tag = other.gameObject.tag;
                botType = BotType.Enemy;
            } 
        }
    }
}
