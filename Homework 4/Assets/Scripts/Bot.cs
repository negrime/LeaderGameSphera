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

    [Header("Materials")] 
    public Material playerMaterial;
    public Material enemyMaterial;
   
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _renderer = GetComponent<Renderer>();
       
        if (botType != BotType.Neutral)
        {
            GameManager.Instance.AddUnit(tag);
            _agent = GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        if (botType == BotType.Enemy && Vector3.Distance(_player.position, gameObject.transform.position) < 25)
        {
            _agent.SetDestination(_player.position);
        }

        if (botType == BotType.Player)
        {
            _agent.SetDestination(GameManager.Instance.target);
        }
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if (botType == BotType.Neutral)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                _renderer.material.color = playerMaterial.color;
               _agent = gameObject.AddComponent<NavMeshAgent>();
               _agent.stoppingDistance = 3;
                tag = other.gameObject.tag;
                botType = BotType.Player;
                GameManager.Instance.AddUnit(tag);
            
            }
            else if (other.gameObject.tag.Equals("Enemy"))
            {
                _renderer.material.color = enemyMaterial.color;
                _agent = gameObject.AddComponent<NavMeshAgent>();
                tag = other.gameObject.tag;
                botType = BotType.Enemy;
                GameManager.Instance.AddUnit(tag);
            }
        }

        if (botType == BotType.Enemy)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 1 && (other.gameObject.tag.Equals("Player") && (other.gameObject.name != "Player")))
          //  if (other.gameObject.tag.Equals("Player") && (GameManager.Instance.playerAmount > GameManager.Instance.enemyAmount))
            {
                _renderer.material.color = playerMaterial.color;
                tag = other.gameObject.tag;
                botType = BotType.Player;
                GameManager.Instance.RemoveUnit("Enemy");
                GameManager.Instance.AddUnit("Player");
            }

        }

        if (botType == BotType.Player)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 1 && (other.gameObject.tag.Equals("Enemy") && gameObject.name != "Player"))
            //if (other.gameObject.tag.Equals("Enemy") && (GameManager.Instance.playerAmount < GameManager.Instance.enemyAmount) && gameObject.name != "Player")
            {
                _renderer.material.color = enemyMaterial.color;
                tag = other.gameObject.tag;
                botType = BotType.Enemy;
                GameManager.Instance.RemoveUnit("Player");
                GameManager.Instance.AddUnit("Enemy");
                
            } 
        }
    }
}
