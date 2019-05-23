using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> neutralVillages;
    public List<GameObject> enemyVillages;
    public int enemyAmount;
    public int playerAmount;
    public int totalSum;
    public Transform targetMarker;

    public GameObject player;
    public Vector3 playerTarget;
    public Vector3 enemyTarget;
    public GameObject logTxt;

    private void Awake()
    {
        playerTarget = GameObject.Find("Player").transform.position;
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
        this.playerTarget = target;
        targetMarker.position = target;
    }

    public void SpawnText(Color color, Transform transform, Transform canvas, string message = "+1")
    {
        GameObject go = Instantiate(logTxt, transform.position, Quaternion.identity, canvas);
        go.gameObject.GetComponent<Text>().text = message;
        go.gameObject.GetComponent<Text>().color = color;
    }
}
