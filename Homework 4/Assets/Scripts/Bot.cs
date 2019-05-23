using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Bot : MonoBehaviour
{
    public NavMeshAgent agent;
    private Renderer _renderer;
    public Transform _player;
    public ParticleSystem explosion;



    public enum BotType {Player, Enemy, Neutral}
    public BotType botType;
    private readonly Vector3[]  _directions = new[] {Vector3.forward, Vector3.left, Vector3.right};
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
        }
        agent = GetComponent<NavMeshAgent>();



    }


    void Update()
    {
        if (botType == BotType.Enemy && Vector3.Distance(_player.position, gameObject.transform.position) < 25 && (!agent.hasPath))
        {
            agent.SetDestination(_player.position);
        }

        // Запуск 3х лучей
        foreach (var i  in _directions)
        {
            if (botType == BotType.Enemy)
            {
                RaycastHit hit;
                Debug.DrawRay(transform.position, i * 50, Color.green);
 
                if(Physics.Raycast(gameObject.transform.position, i, out hit, 50.0f))
                {
    
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.DrawRay(transform.position, i * 50, Color.red);
                        agent.SetDestination(hit.point);
                    }
                }
            }   
        }

        if (botType == BotType.Player)    
         agent.SetDestination(GameManager.Instance.target);
    }

    public void Die(GameObject go)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(go);

    }
    


    private void OnTriggerEnter(Collider other)
    {
        if (botType == BotType.Neutral)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                _renderer.material.color = playerMaterial.color;
               Renderer[] r =  gameObject.GetComponentsInChildren<Renderer>();
               r[1].material.color = playerMaterial.color;


               
             //  kek.material = enemyMaterial;
               agent.stoppingDistance = 3;
               gameObject.tag = other.gameObject.tag;
               botType = BotType.Player;
               GameManager.Instance.AddUnit(tag);
            }
            else if (other.gameObject.tag.Equals("Enemy"))
            {
                _renderer.material.color = enemyMaterial.color;
                tag = other.gameObject.tag;
                botType = BotType.Enemy;
                GameManager.Instance.AddUnit(tag);
            }
        }

        if (botType == BotType.Enemy)
        {
            int rnd = Random.Range(0, 2);
            if ((other.gameObject.tag.Equals("Player") && (other.gameObject.name != "Player")))
            {
                if (rnd == 1)
                {
                    _renderer.material.color = playerMaterial.color;
                    Renderer[] r =  gameObject.GetComponentsInChildren<Renderer>();
                    r[1].material.color = playerMaterial.color;
                    tag = other.gameObject.tag;
                    botType = BotType.Player;
                    GameManager.Instance.RemoveUnit("Enemy");
                    GameManager.Instance.AddUnit("Player");
                }
                else
                {
                    other.GetComponent<Bot>().Die(other.gameObject);
                    GameManager.Instance.RemoveUnit("Player");
                }
            }

        }

        if (botType == BotType.Player)
        {
            int rnd = Random.Range(0, 2);
            if (other.gameObject.tag.Equals("Enemy") && (gameObject.name != "Player"))
            {
                if (rnd == 1)
                {
                    _renderer.material.color = enemyMaterial.color;
                    tag = other.gameObject.tag;
                    botType = BotType.Enemy;
                    GameManager.Instance.RemoveUnit("Player");
                    GameManager.Instance.AddUnit("Enemy");
                }
                else
                {
                    other.GetComponent<Bot>().Die(other.gameObject);
                    GameManager.Instance.RemoveUnit("Enemy");
                }
            }
        }
    }
}
