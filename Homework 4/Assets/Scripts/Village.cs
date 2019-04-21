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
    public float currentTime;
    public Bot.BotType botType;

    public float timeKek;
    public float curTime;
    public bool isSeizing;
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (currentTime >= time)
        {
            if (botType == Bot.BotType.Neutral)
                Instantiate(neutral, spawnPosition.position + new Vector3(Random.Range(0, 3),0, Random.Range(0, 3)), Quaternion.identity);
            else if (botType == Bot.BotType.Player)
                Instantiate(player, spawnPosition.position + new Vector3(Random.Range(0, 3),0, Random.Range(0, 3)), Quaternion.identity);
            else
            {
                Instantiate(enemy, spawnPosition.position + new Vector3(Random.Range(0, 3),0, Random.Range(0, 3)), Quaternion.identity);
            }
            currentTime = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
        }

        if (isSeizing)
        {
            curTime += Time.deltaTime;   
        }
    }

   /* private void OnTriggerStay(Collider other)
    {

        
        if (botType == Bot.BotType.Neutral && (other.gameObject.CompareTag("Player")))
        {
            isSeizing = true;
            if (curTime > timeKek)
            {
                curTime = 0;
                botType = Bot.BotType.Player;
            }
        }

        if (botType == Bot.BotType.Enemy && (other.gameObject.CompareTag("Player")))
        {
            isSeizing = true;
            if (curTime > timeKek)
            {
                curTime = 0;
                botType = Bot.BotType.Player;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isSeizing = false;
        curTime = 0;
    }
    */
}
