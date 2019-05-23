using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class Village : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject neutral;
    public Transform spawnPosition;
    public float time;
    private float _currentTime;
    public Bot.BotType botType;


    
    
    void Start()
    {
        _currentTime = 0;
        if (botType == Bot.BotType.Neutral)
        {
           GameManager.Instance.neutralVillages.Add(gameObject); 
        }
        else if (botType == Bot.BotType.Enemy)
        {
            GameManager.Instance.enemyVillages.Add(gameObject);
        }
    }

    void Update()
    {
        if (_currentTime >= time)
        {
            if (botType == Bot.BotType.Neutral)
                Instantiate(neutral, spawnPosition.position + new Vector3(Random.Range(1, 3),0, Random.Range(1, 3)), Quaternion.identity);
            else if (botType == Bot.BotType.Player)
                Instantiate(player, spawnPosition.position + new Vector3(Random.Range(0, 3),0, Random.Range(0, 3)), Quaternion.identity);
            else
            {
                Instantiate(enemy, spawnPosition.position + new Vector3(Random.Range(0, 3),0, Random.Range(0, 3)), Quaternion.identity);
            }
            _currentTime = 0;
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }
}
